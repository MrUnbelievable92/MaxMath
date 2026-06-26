using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

internal class CtorGen
{
    private class VectorBuildResult
    {
        public List<string> Lines = new List<string>();
        public string FinalVarName;
        public List<string> InitialVarNameList = new List<string>();
    }

    internal CtorGen(string type, int elements)
    {
        Type = type;
        Elements = elements;
        Compositions = new List<int[]>();
    }

    private readonly string Type;
    private readonly int Elements;
    private readonly List<int[]> Compositions;

    private bool Is16BitType => Type == "short" || Type == "ushort" || Type == "half";

    private void Build(int remaining, List<int> current, int[] sizes)
    {
        if (remaining == 0)
        {
            Compositions.Add(current.ToArray());
            return;
        }

        foreach (int size in sizes)
        {
            if (size <= remaining)
            {
                current.Add(size);
                Build(remaining - size, current, sizes);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private string GenerateParameterList(int[] comp, bool withNames, bool withTypes)
    {
        string s = string.Empty;
        for (int i = 0; i < comp.Length; i++)
        {
            if (i != 0) 
            {
                s += withNames ? ", " : "_";
            }

            if (withTypes)
            {
                s += $"{Type}{comp[i]}";
            }

            if (withNames)
            {
                if (withTypes)
                {
                    s += " ";
                }
                else
                {
                    if (i != 0)
                    {
                        s += " ";
                    }
                }
                s += "v";
                s += i;
            }
            else
            {
                s += "_";
            }
        }
        return s;
    }

    private VectorBuildResult CombinePartsToVectorCode(List<int> parts, string prefix, ref int tempCounter, ref int startVector)
    {
        VectorBuildResult res = new VectorBuildResult();
        if (parts.Count == 0)
            return res;

        for (int i = 0; i < parts.Count; ++i)
        {
            res.InitialVarNameList.Add($"{prefix}_v{i}");
        }

        List<(string name, int size)> nodes = new List<(string, int)>();
        for (int i = 0; i < parts.Count; ++i)
        {
            nodes.Add(($"v{startVector++}", parts[i]));
        }

        while (nodes.Count > 1)
        {
            List<(string, int)> next = new List<(string, int)>();
            for (int i = 0; i < nodes.Count; i += 2)
            {
                if (i + 1 >= nodes.Count)
                {
                    next.Add(nodes[i]);
                }
                else
                {
                    (string name, int size) left = nodes[i];
                    (string name, int size) right = nodes[i + 1];
                    int leftSize = left.size;
                    int shift = Elements - leftSize;
                    shift = Is16BitType ? 2 * shift : shift;
                    string shiftedName = $"{prefix}_t{tempCounter}_shift";
                    string combName = $"{prefix}_t{tempCounter++}";

                    string leftString = left.size == 1 ? $"cvtsi32_si128({left.name})" : left.name;
                    string rightString = right.size == 1 ? $"cvtsi32_si128({right.name})" : right.name;
                    res.Lines.Add($"v128 {shiftedName} = bslli_si128({leftString}, (byte){shift});");
                    res.Lines.Add($"v128 {combName} = alignr_epi8({shiftedName}, {rightString}, (byte){shift});");
                    next.Add((combName, leftSize + right.size));
                }
            }
            nodes = next;
        }

        res.FinalVarName = nodes[0].name;
        return res;
    }

    private void AppendInterleaved(StringBuilder sb, VectorBuildResult build)
    {
        foreach (string line in build.Lines)
        {
            sb.AppendLine("\t\t\t\t" + line);
        }
        sb.AppendLine();
    }

    private int Sum(List<int> arr)
    {
        int s = 0;
        foreach (int v in arr) s += v;
        return s;
    }

    private string[] FieldNamesForSize(int size)
    {
        return size switch
        {
            2 => new[] { "x", "y" },
            3 => new[] { "x", "y", "z" },
            4 => new[] { "x", "y", "z", "w" },
            8 => Enumerable.Range(0, 8).Select(i => "x" + i).ToArray(),
            16 => Enumerable.Range(0, 16).Select(i => "x" + i).ToArray(),
            _ => throw new ArgumentOutOfRangeException(nameof(size), $"unsupported size {size}")
        };
    }

    private string GenerateFallbackCtor(int[] sizes)
    {
        StringBuilder sb = new StringBuilder();

        List<string> paramList = new List<string>();
        for (int i = 0; i < sizes.Length; ++i)
        {
            string t = $"{Type}{sizes[i]}";
            paramList.Add($"{t} p{i}");
        }

        int targetIndex = 0;
        for (int i = 0; i < sizes.Length; ++i)
        {
            int size = sizes[i];
            if (size != 1)
            {
                string[] fields = FieldNamesForSize(size);

                for (int j = 0; j < size; ++j)
                {
                    string paramField = fields[j];
                    string space = targetIndex < 10 && !Is16BitType ? "  " : " ";
                    sb.AppendLine($"\t\t\t\tthis.x{targetIndex}{space}= v{i}.{paramField};");
                    targetIndex++;
                }
            }
            else
            {
                string space = targetIndex < 10 && !Is16BitType ? "  " : " ";
                sb.AppendLine($"\t\t\t\tthis.x{targetIndex}{space}= v{i};");
                targetIndex++;
            }
        }

        return sb.ToString();
    }

    private void FixLastShift(VectorBuildResult build, int finalShift)
    {
        string lastLine = build.Lines[^1];
        int indexOfLastShift = lastLine.LastIndexOf("(byte)") + "(byte)".Length;
        int lastShift;
        if (lastLine[indexOfLastShift + 1] >= '0' 
         && lastLine[indexOfLastShift + 1] <= '9')
        {
            lastShift = int.Parse(lastLine.Substring(indexOfLastShift, 2));
        }
        else
        {
            lastShift = int.Parse(lastLine.Substring(indexOfLastShift, 1));
        }
            
        lastShift -= finalShift;
        lastLine = lastLine.Replace(lastLine.Substring(indexOfLastShift - "(byte)".Length), lastShift.ToString() + ");");
        build.Lines[^1] = lastLine;
    }

    private string GenerateSIMDCtor(int[] sizes)
    {
        int pivot = sizes.Length / 2;
        List<int> leftPart = new List<int>(sizes[..pivot]);
        List<int> rightPart = new List<int>(sizes[pivot..]);

        StringBuilder sb = new StringBuilder();

        int tempCounter = 0;
        int startVector = 0;

        VectorBuildResult leftBuild = CombinePartsToVectorCode(leftPart, "L", ref tempCounter, ref startVector);
        VectorBuildResult rightBuild = CombinePartsToVectorCode(rightPart, "R", ref tempCounter, ref startVector);

        int leftTotal = Sum(leftPart);
        string leftVecName = leftBuild.FinalVarName ?? leftBuild.InitialVarNameList[0];
        string rightVecName = rightBuild.FinalVarName ?? rightBuild.InitialVarNameList[0];

        if (leftPart.Count == 0)
        {
            AppendInterleaved(sb, rightBuild);
            sb.AppendLine($"\t\t\t\tthis = {rightVecName};");
        }
        else if (rightPart.Count == 0)
        {
            AppendInterleaved(sb, leftBuild);
            sb.AppendLine($"\t\t\t\tthis = {leftVecName};");
        }
        else
        { 
            int finalShift = Elements - leftTotal;
            finalShift = Is16BitType ? finalShift * 2 : finalShift;

            if (leftBuild.Lines.Count != 0)
            {
                FixLastShift(leftBuild, finalShift);
            }
            else if (rightBuild.Lines.Count != 0)
            {
                FixLastShift(rightBuild, finalShift);
            }

            string aVec;
            if (leftBuild.Lines.Count != 0)
            {
                AppendInterleaved(sb, leftBuild);
                aVec = leftBuild.FinalVarName;
            }
            else
            {
                string left = sizes[0] == 1 ? "cvtsi32_si128(v0)" : "v0";
                aVec = $"bslli_si128({left}, (byte){sizes[0] * (Is16BitType ? 2 : 1)})";
            }

            if (rightBuild.Lines.Count != 0)
            {
                AppendInterleaved(sb, rightBuild);
            }
            
            sb.AppendLine($"\t\t\t\tthis = alignr_epi8({aVec}, {rightVecName}, (byte){finalShift});");
        }

        return sb.ToString();
    }

    internal string GenerateCTORs()
    {
        Build(Elements, new List<int>(), Elements == 8 ? new int[] { 1, 2, 3, 4 } : (Elements == 16 ? new int[] { 2, 3, 4, 8 } : new int[] { 2, 3, 4, 8, 16 }));

        string result = "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n";

        foreach (int[] comp in Compositions)
        {
            string s = $"\t\tpublic {Type}{Elements}(";
            s += GenerateParameterList(comp, true, true);

            s += ")\r\n";
            s += "\t\t{\r\n";
            s += "\t\t\tif (BurstArchitecture.IsTableLookupSupported)\r\n";
            s += "\t\t\t{\r\n";
            s += GenerateSIMDCtor(comp);
            s += "\t\t\t}\r\n";
            s += "\t\t\telse\r\n";
            s += "\t\t\t{\r\n";
            s += GenerateFallbackCtor(comp);
            s += "\t\t\t}\r\n";
            result += s + "\t\t}\r\n\r\n";
        }

        result = result.Replace($"{Type}1 ", Type + " ");

        return result;
    }

    internal string GenerateUnitTests()
    {
        Build(Elements, new List<int>(), Elements == 8 ? new int[] { 1, 2, 3, 4 } : (Elements == 16 ? new int[] { 2, 3, 4, 8 } : new int[] { 2, 3, 4, 8, 16 }));

        string result = string.Empty;

        foreach (int[] comp in Compositions)
        {
            string s = "\t\t[Test]\r\n";
            s += $"\t\tpublic static void CTOR_";
            s += GenerateParameterList(comp, false, true);

            s += "()\r\n";
            s += "\t\t{\r\n";
            s += "\t\t\t" + (Is16BitType ? "Random16 rng = Random16.New;" : "Random8 rng = Random8.New;") + "\r\n";
            s += "\r\n";

            string rngName = Type == "sbyte" ? "SByte" : (Type == "byte" ? "Byte" : (Type == "short" ? "Short" : "UShort"));

            for (int i = 0; i < comp.Length; i++)
            {
                s += "\t\t\t" + Type + comp[i].ToString() + " v" + i.ToString() + " = rng.Next" + rngName + (comp[i] == 1 ? string.Empty : comp[i].ToString()) + "();\r\n";
            }
            s += "\r\n";

            s += $"\t\t\t{Type}{Elements} test = new {Type}{Elements}({GenerateParameterList(comp, true, false)});\r\n";
            s += "\r\n";
            
            int targetIndex = 0;
            for (int i = 0; i < comp.Length; i++)
            {
                int size = comp[i];
                if (size != 1)
                {
                    string[] fields = FieldNamesForSize(size);

                    for (int j = 0; j < size; ++j)
                    {
                        string paramField = fields[j];
                        s += $"\t\t\tAssert.AreEqual(test.x{targetIndex}, v{i}.{paramField});\r\n";
                        targetIndex++;
                    }
                }
                else
                {
                    s += $"\t\t\tAssert.AreEqual(test.x{targetIndex}, v{i});\r\n";
                    targetIndex++;
                }
            }

            result += s + "\t\t}\r\n\r\n";
        }

        result = result.Replace($"{Type}1 ", Type + " ");
        result = result.Replace("__", "_");
        result = result.Replace("_()", "()");
        result = result.Replace(",  v", ", v");

        return result;
    }
}