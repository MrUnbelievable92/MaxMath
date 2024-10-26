using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace MaxMath.Tests
{
    internal class TestJobGenerator
    {
        internal TestJobGenerator(string type)
        {
            Type = type;

            ConvertAllFunctions();
            SelectFunctionsForType(type);
            InitReferenceCounter();
        }
        
        private void ConvertAllFunctions()
        {
            MethodInfo[] globalFunctions = typeof(maxmath).GetMethods(BindingFlags.Public | BindingFlags.Static);

            SourceCodeWithoutVariableNames = new string[globalFunctions.Length];
            ReturnTypes = new string[globalFunctions.Length];
            ParameterTypes = new string[globalFunctions.Length][];

            for (int i = 0; i < globalFunctions.Length; i++)
            {
                SourceCodeWithoutVariableNames[i] = Reflection.ToSourceCode(globalFunctions[i], false, out ReturnTypes[i], out ParameterTypes[i]);
            }
        }

        private void SelectFunctionsForType(string type)
        {
            System.Collections.Generic.List<string> list_sourceCodeWithoutVariableNames = new();
            System.Collections.Generic.List<string> list_returnTypes = new();
            System.Collections.Generic.List<string[]> list_parameterTypes = new();

            for (int i = 0; i < SourceCodeWithoutVariableNames.Length; i++)
            {
                if (ReturnTypes[i] == type || ParameterTypes[i].Contains(type))
                {
                    list_sourceCodeWithoutVariableNames.Add(SourceCodeWithoutVariableNames[i]);
                    list_returnTypes.Add(ReturnTypes[i]);
                    list_parameterTypes.Add(ParameterTypes[i]);
                }
            }

            SourceCodeWithoutVariableNames = list_sourceCodeWithoutVariableNames.ToArray();
            ReturnTypes = list_returnTypes.ToArray();
            ParameterTypes = list_parameterTypes.ToArray();
        }

        private void InitReferenceCounter()
        {
            ReferenceCounter = new Dictionary<string, int>();

            for (int i = 0; i < SourceCodeWithoutVariableNames.Length; i++)
            {
                if (!ExcludedParameterTypes.Contains(ReturnTypes[i]))
                {
                    ReferenceCounter.TryAdd(ReturnTypes[i], 0);
                }

                foreach (string s in ParameterTypes[i])
                {
                    if (!ExcludedParameterTypes.Contains(s))
                    {
                        ReferenceCounter.TryAdd(s, 0);
                    }
                }
            }
        }

        private string[] ExcludedParameterTypes =
        {
            Reflection.GetTypeName(typeof(Promise))
        };

        private string[] SourceCodeWithoutVariableNames;
        private string[] ReturnTypes;
        private string[][] ParameterTypes;
        private Dictionary<string, int> ReferenceCounter;
        private string Result;

        internal string Type { get; private set; }


        private void AppendJobPreamble()
        {
            Result = "using Unity.Mathematics;\n"
                   + "using Unity.Burst;\n"
                   + "using Unity.Collections;\n"
                   + "using Unity.Jobs;\n"
                   + "using MaxMath;\n"
                   + "\n"
                   + "using static Unity.Mathematics.math;\n"
                   + "using static MaxMath.maxmath;\n"
                   + "\n"
                   + "[BurstCompile(OptimizeFor = OptimizeFor.Size)]\n"
                   + $"public struct Test_{ Type } : IJob\n"
                   + "{\n";
        }

        private string GenerateNativeReferences()
        {
            string result = string.Empty;
            
            foreach (KeyValuePair<string, int> referenceCount in ReferenceCounter)
            {
                for (int i = 0; i < referenceCount.Value; i++)
                {
                    result += $"\tpublic NativeReference<{ referenceCount.Key }> { referenceCount.Key }_{ i };\n";
                }
            }

            return result + "\n";
        }

        private string ReplaceReturnType(string code)
        {
            string type = code.Substring(0, code.IndexOf(" "));

            if (type == "void")
            {
                return code.Substring(code.IndexOf(" ") + 1);
            }
            else
            {
                return $"{ type }_{ ReferenceCounter[type]++ }_value = " + code.Substring(code.IndexOf(" ") + 1);
            }
        }

        private string ReplaceParameters(string code)
        {
            static void CopyKeywords(string code, string keyword, ref string copy, ref int index)
            {
                if (code.Substring(index, keyword.Length) == keyword)
                {
                    copy += keyword;
                    index += keyword.Length;
                }
            }

            int index = code.IndexOf("(") + 1;
            string copy = code.Substring(0, index);

            while (index < code.Length && code[index] != ')') 
            {
                CopyKeywords(code, "ref ", ref copy, ref index);
                CopyKeywords(code, "in ",  ref copy, ref index);
                CopyKeywords(code, "out ", ref copy, ref index);

                string type = string.Empty;

                while (index < code.Length && !(code[index] == ')' || code[index] == ','))
                {
                    type += code[index++];
                }

                if (ExcludedParameterTypes.Contains(type))
                {
                    copy = copy.Substring(0, copy.Length - 2) + ')';

                    return copy;
                }

                copy += $"{ type }_{ ReferenceCounter[type]++ }_value";

                while (index < code.Length && (code[index] == ')' || code[index] == ',' || code[index] == ' '))
                {
                    copy += code[index++];
                }
            }

            return copy;
        }

        private string GenerateLocals()
        {
            string result = string.Empty;
            foreach (KeyValuePair<string, int> referenceCount in ReferenceCounter)
            {
                for (int i = 0; i < referenceCount.Value; i++)
                {
                    result += $"\t\t{ referenceCount.Key } { referenceCount.Key }_{ i }_value = { referenceCount.Key }_{ i }.Value;\n";
                }
            }

            return result + "\n";
        }
        
        private void AppendWriteBack()
        {
            foreach (KeyValuePair<string, int> referenceCount in ReferenceCounter)
            {
                for (int i = 0; i < referenceCount.Value; i++)
                {
                    Result += $"\t\t{ referenceCount.Key }_{ i }.Value = { referenceCount.Key }_{ i }_value;\n";
                }
            }
        }

        private void AppendJobExecuteBody()
        {
            Result += "\tpublic void Execute()\n"
                   + "\t{\n";
            
            int insertLocalsIndex = Result.Length;

            for (int i = 0; i < SourceCodeWithoutVariableNames.Length; i++)
            {
                string modified = ReplaceReturnType(SourceCodeWithoutVariableNames[i]);
                modified = ReplaceParameters(modified);

                Result += $"\t\t{ modified };\n";
            }
            Result += "\n";

            Result = Result.Insert(insertLocalsIndex, GenerateLocals());
            
            AppendWriteBack();

            Result += "\t}\n";
        }


         
        private void AppendJobEpilogue()
        {
            Result += "}\n";
        }

        internal string GenerateJob()
        {
            AppendJobPreamble();

            int nativeReferenceInsertionIndex = Result.Length;
            AppendJobExecuteBody();
            Result = Result.Insert(nativeReferenceInsertionIndex, GenerateNativeReferences());

            AppendJobEpilogue();

            return Result;
        }

        internal static IEnumerable<TestJobGenerator> GenerateAllJobs()
        {
            foreach (Type type in Reflection.AllTypes.Where(t => t != typeof(Promise)
                                                              && t != typeof(void)
                                                              && t != typeof(Unity.Mathematics.math.ShuffleComponent)))
            {
                yield return new TestJobGenerator(Reflection.GetTypeName(type));
            }
        }
    }
}
