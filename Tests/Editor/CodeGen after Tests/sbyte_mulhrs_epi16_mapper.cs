using System;
using System.Collections.Generic;
using System.IO;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;











// rem

// divrem












namespace MaxMath.Tests
{
    public static class mulhrs_epi16_mapper
    {
        private static string AddColonAndPaddingToNumber(string number)
        {
            switch (number.Length)
            {
                case 1:  return number + ":    ";
                case 2:  return number + ":   ";
                case 3:  return number + ":  ";
                default: return number + ": ";
            }
        }

        public static void Test_sbyte()
        {
            Dictionary<sbyte, short> datasbyte = new Dictionary<sbyte, short>();

            for (int divisor = sbyte.MinValue;divisor <= sbyte.MaxValue / 2 + 1;divisor++)
            {
                if (divisor == 0)
                {
                    continue;
                }

                for (int magic = short.MinValue;magic <= short.MaxValue;magic++)
                {
                    bool corect = true;

                    for (int i = sbyte.MinValue;i <= sbyte.MaxValue;i++)
                    {
                        if ((sbyte)(i / divisor) != (short)(((((int)i * (int)magic) >> 14) + 1) >> 1))
                        {
                            corect = false;
                            break;
                        }    
                    }

                    if (corect)
                    {
                        if (datasbyte.TryGetValue((sbyte)divisor, out short value))
                        {
                            if (magic == -1 || magic == 0 && value != 0)
                            {
                                datasbyte.Remove((sbyte)divisor);
                                datasbyte.Add((sbyte)divisor, (short)magic);

                                UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                            }
                            else if (magic == 1 && (value != 0 && value != -1))
                            {
                                datasbyte.Remove((sbyte)divisor);
                                datasbyte.Add((sbyte)divisor, (short)magic);

                                UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                            }
                            else if (math.ispow2(magic) && (value != 0 && value != -1))
                            {
                                datasbyte.Remove((sbyte)divisor);
                                datasbyte.Add((sbyte)divisor, (short)magic);

                                UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                            }
                            else if (magic == divisor && (value != 0 && value != -1))
                            {
                                datasbyte.Remove((sbyte)divisor);
                                datasbyte.Add((sbyte)divisor, (short)magic);

                                UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                            }
                        }
                        else
                        {
                            datasbyte.Add((sbyte)divisor, (short)magic);
                        }
                    }
                }
            }

            foreach (KeyValuePair<sbyte, short> item in datasbyte)
            {
                for (int i = sbyte.MinValue;i <= sbyte.MaxValue;i++)
                {
                    sbyte8 test = new sbyte8((sbyte)i); 
                    if (!(test / (sbyte)item.Key).Equals((sbyte8)(short8)X86.Ssse3.mulhrs_epi16((short8)test, new short8(item.Value))))
                    {
                        throw new Exception();
                    }
                }
            }

            Generate_Div_sbyte(datasbyte);
        }

        private static void Generate_Div_sbyte(Dictionary<sbyte, short> datasbyte)
        {
            using FileStream streamsbyte = new FileStream("E:/Div SByte by Constant.cs", FileMode.Create);
            using StreamWriter writersbyte = new StreamWriter(streamsbyte);

            UnityEngine.Debug.Log("Optimized " + datasbyte.Count.ToString() + " sbyte divisions");

            string @class = "using Unity.Burst.Intrinsics;\n\nusing static Unity.Burst.Intrinsics.X86;\n\n";
            @class += "namespace MaxMath\n{\n\tunsafe internal static partial class Operator\n\t{\n";
            @class += "\t\tinternal static v128 vdiv_sbyte_const(v128 vector, sbyte divisor, int vectorElementCount)\n\t\t{\n\t\t\t";

            @class += "if (vectorElementCount <= 8)\n\t\t\t{\n\t\t\t\t";
            @class += "if (Ssse3.IsSsse3Supported)\n\t\t\t\t{\n\t\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t\t{";

            foreach (KeyValuePair<sbyte, short> pair in datasbyte)
            {
                if (pair.Key == sbyte.MinValue)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "return Sse2.sub_epi8(Sse2.setzero_si128(), Sse2.cmpeq_epi8(new sbyte4(sbyte.MinValue), vector));";
                }
                else if (pair.Key != -1 && pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "\n\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\tv128 result = Ssse3.mulhrs_epi16(Cast.SByteToShort(vector), new short8(" + pair.Value.ToString() + "));";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\treturn Sse2.packs_epi16(result, result);\n\t\t\t\t\t\t}";
                }
            }

            @class += "\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}\n\t\t\telse\n\t\t\t{\n\t\t\t\t";
            @class += "if (Ssse3.IsSsse3Supported)\n\t\t\t\t{\n\t\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t\t{";

            foreach (KeyValuePair<sbyte, short> pair in datasbyte)
            {
                if (pair.Key == sbyte.MinValue)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "return Sse2.sub_epi8(Sse2.setzero_si128(), Sse2.cmpeq_epi8(new sbyte16(sbyte.MinValue), vector));";
                    @class += "\n";
                }
                else if (pair.Key != -1 && pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString());
                    @class += "\n\t\t\t\t\t\t{\n\t\t\t\t\t\t\tv128 MAGIC = new short8(" + pair.Value.ToString() + ");";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tv128 cvtMask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), vector);";
                    @class += "\n\t\t\t\t\t\t\tv128 lo = Ssse3.mulhrs_epi16(Sse2.unpacklo_epi8(vector, cvtMask), MAGIC);";
                    @class += "\n\t\t\t\t\t\t\tv128 hi = Ssse3.mulhrs_epi16(Sse2.unpackhi_epi8(vector, cvtMask), MAGIC);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\treturn Sse2.packs_epi16(lo, hi);";
                    @class += "\n\t\t\t\t\t\t}";
                }
            }
            @class += "\n\t\t\t\t\t}";
            @class += "\n\t\t\t\t}";

            @class += "\n\t\t\t}";
            
            @class += "\n\n\t\t\treturn new v128((sbyte)(vector.SByte0 / divisor), (sbyte)(vector.SByte1 / divisor), (sbyte)(vector.SByte2 / divisor), (sbyte)(vector.SByte3 / divisor), (sbyte)(vector.SByte4 / divisor), (sbyte)(vector.SByte5 / divisor), (sbyte)(vector.SByte6 / divisor), (sbyte)(vector.SByte7 / divisor), (sbyte)(vector.SByte8 / divisor), (sbyte)(vector.SByte9 / divisor), (sbyte)(vector.SByte10 / divisor), (sbyte)(vector.SByte11 / divisor), (sbyte)(vector.SByte12 / divisor), (sbyte)(vector.SByte13 / divisor), (sbyte)(vector.SByte14 / divisor), (sbyte)(vector.SByte15 / divisor));";

            @class += "\n\t\t}";

            
            @class += "\n\n\t\tinternal static v256 vdiv_sbyte_const(v256 vector, sbyte divisor)\n\t\t{\n\t\t\t";
            @class += "if (Avx2.IsAvx2Supported)\n\t\t\t{\n\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t{";

            foreach (KeyValuePair<sbyte, short> pair in datasbyte)
            {
                if (pair.Key == sbyte.MinValue)
                {
                    @class += "\n\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "return Avx2.mm256_sub_epi8(Avx.mm256_setzero_si256(), Avx2.mm256_cmpeq_epi8(new sbyte32(sbyte.MinValue), vector));";
                    @class += "\n";
                }
                else if (pair.Key != -1 && pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString());
                    @class += "\n\t\t\t\t\t{\n\t\t\t\t\t\tv256 MAGIC = new short16(" + pair.Value.ToString() + ");";
                    @class += "\n\t\t\t\t\t\tv256 cvtMask = Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), vector);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\tv256 lo = Avx2.mm256_mulhrs_epi16(Avx2.mm256_unpacklo_epi8(vector, cvtMask), MAGIC);";
                    @class += "\n\t\t\t\t\t\tv256 hi = Avx2.mm256_mulhrs_epi16(Avx2.mm256_unpackhi_epi8(vector, cvtMask), MAGIC);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\treturn Avx2.mm256_packs_epi16(lo, hi);";
                    @class += "\n\t\t\t\t\t}";
                }
            }


            @class += "\n\t\t\t\t}";
            @class += "\n\t\t\t}";
            
            @class += "\n\n\t\t\treturn new v256((sbyte)(vector.SByte0 / divisor), (sbyte)(vector.SByte1 / divisor), (sbyte)(vector.SByte2 / divisor), (sbyte)(vector.SByte3 / divisor), (sbyte)(vector.SByte4 / divisor), (sbyte)(vector.SByte5 / divisor), (sbyte)(vector.SByte6 / divisor), (sbyte)(vector.SByte7 / divisor), (sbyte)(vector.SByte8 / divisor), (sbyte)(vector.SByte9 / divisor), (sbyte)(vector.SByte10 / divisor), (sbyte)(vector.SByte11 / divisor), (sbyte)(vector.SByte12 / divisor), (sbyte)(vector.SByte13 / divisor), (sbyte)(vector.SByte14 / divisor), (sbyte)(vector.SByte15 / divisor), (sbyte)(vector.SByte16 / divisor), (sbyte)(vector.SByte17 / divisor), (sbyte)(vector.SByte18 / divisor), (sbyte)(vector.SByte19 / divisor), (sbyte)(vector.SByte20 / divisor), (sbyte)(vector.SByte21 / divisor), (sbyte)(vector.SByte22 / divisor), (sbyte)(vector.SByte23 / divisor), (sbyte)(vector.SByte24 / divisor), (sbyte)(vector.SByte25 / divisor), (sbyte)(vector.SByte26 / divisor), (sbyte)(vector.SByte27 / divisor), (sbyte)(vector.SByte28 / divisor), (sbyte)(vector.SByte29 / divisor), (sbyte)(vector.SByte30 / divisor), (sbyte)(vector.SByte31 / divisor));";

            @class += "\n\t\t}";
            @class += "\n\t}";
            @class += "\n}";

            writersbyte.Write(@class);
        }


        public static void Test_byte()
        {
            Dictionary<byte, short> databyte = new Dictionary<byte, short>();

            for (int divisor = 1;divisor <= byte.MaxValue;divisor++)
            {
                for (int magic = short.MinValue;magic <= short.MaxValue;magic++)
                {
                    bool corect = true;

                    for (int i = byte.MinValue;i <= byte.MaxValue;i++)
                    {
                        if ((byte)(i / divisor) != (short)(((((int)i * (int)magic) >> 14) + 1) >> 1))
                        {
                            corect = false;
                            break;
                        }    
                    }

                    if (corect)
                    {
                        if (!math.ispow2(divisor))
                        {
                            if (databyte.TryGetValue((byte)divisor, out short value))
                            {
                                if (magic == -1 || magic == 0)
                                {
                                    databyte.Remove((byte)divisor);
                                    databyte.Add((byte)divisor, (short)magic);

                                    UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                                }
                                else if (magic == 1 && (value != 0 && value != -1))
                                {
                                    databyte.Remove((byte)divisor);
                                    databyte.Add((byte)divisor, (short)magic);

                                    UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                                }
                                else if (math.ispow2(magic) && (value != 0 && value != -1))
                                {
                                    databyte.Remove((byte)divisor);
                                    databyte.Add((byte)divisor, (short)magic);

                                    UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                                }
                                else if (magic == divisor && (value != 0 && value != -1))
                                {
                                    databyte.Remove((byte)divisor);
                                    databyte.Add((byte)divisor, (short)magic);

                                    UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                                }
                                else if ((magic == ushort.MaxValue / divisor + 1) && (value != 1 && value != divisor && value != 0 && value != -1))
                                {
                                    databyte.Remove((byte)divisor);
                                    databyte.Add((byte)divisor, (short)magic);

                                    UnityEngine.Debug.Log("replaced " + value.ToString() + " with " + magic.ToString());
                                }
                            }
                            else
                            {
                                databyte.Add((byte)divisor, (short)magic);
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<byte, short> item in databyte)
            {
                for (int i = 1;i <= byte.MaxValue;i++)
                {
                    byte8 test = new byte8((byte)i); 
                    if (!(test / (byte)item.Key).Equals((byte8)(short8)X86.Ssse3.mulhrs_epi16((short8)test, new short8(item.Value))))
                    {
                        throw new Exception();
                    }
                }
            }

            Generate_Div_byte(databyte);
            Generate_DivRem_byte(databyte);
        }

        private static void Generate_Div_byte(Dictionary<byte, short> databyte)
        {
            byte minKey = 255;

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                minKey = maxmath.min(minKey, pair.Key);
            }

            if (minKey >= byte.MaxValue / 2 + 1)
            {
                return;
            }

            using FileStream streambyte = new FileStream("E:/Div Byte by Constant.cs", FileMode.Create);
            using StreamWriter writerbyte = new StreamWriter(streambyte);

            UnityEngine.Debug.Log("Optimized " + (1 + databyte.Count).ToString() + " byte divisions");

            string @class = "using Unity.Burst.Intrinsics;\n\nusing static Unity.Burst.Intrinsics.X86;\n\n";
            @class += "namespace MaxMath\n{\n\tunsafe internal static partial class Operator\n\t{\n";
            @class += "\t\tinternal static v128 vdiv_byte_const(v128 vector, byte divisor, int vectorElementCount)\n\t\t{\n\t\t\t";

            @class += "if (vectorElementCount <= 8)\n\t\t\t{\n\t\t\t\t";
            @class += "if (Ssse3.IsSsse3Supported)\n\t\t\t\t{\n\t\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t\t{";

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                if (pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "\n\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\tv128 result = Ssse3.mulhrs_epi16(Cast.ByteToShort(vector), new short8(" + pair.Value.ToString() + "));";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\treturn Sse2.packus_epi16(result, result);\n\t\t\t\t\t\t}";
                }
            }

            @class += "\n";
            @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(255.ToString()) +  "return Sse2.sub_epi8(Sse2.setzero_si128(), Sse2.cmpeq_epi8(vector, Sse2.cmpeq_epi32(default(v128), default(v128))));";

            @class += "\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}\n\t\t\telse\n\t\t\t{\n\t\t\t\t";
            @class += "if (Ssse3.IsSsse3Supported)\n\t\t\t\t{\n\t\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t\t{";

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                if (pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString());
                    @class += "\n\t\t\t\t\t\t{\n\t\t\t\t\t\t\tv128 MAGIC = new short8(" + pair.Value.ToString() + ");";
                    @class += "\n\t\t\t\t\t\t\tv128 CVT_MASK = Sse2.setzero_si128();";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tv128 lo = Ssse3.mulhrs_epi16(Sse2.unpacklo_epi8(vector, CVT_MASK), MAGIC);";
                    @class += "\n\t\t\t\t\t\t\tv128 hi = Ssse3.mulhrs_epi16(Sse2.unpackhi_epi8(vector, CVT_MASK), MAGIC);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\treturn Sse2.packus_epi16(lo, hi);";
                    @class += "\n\t\t\t\t\t\t}";
                }
            }

            @class += "\n";
            @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(255.ToString()) +  "return Sse2.sub_epi8(Sse2.setzero_si128(), Sse2.cmpeq_epi8(vector, Sse2.cmpeq_epi32(default(v128), default(v128))));";

            @class += "\n\t\t\t\t\t}";
            @class += "\n\t\t\t\t}";
            @class += "\n\t\t\t}";
            
            @class += "\n\n\t\t\treturn new v128((byte)(vector.Byte0 / divisor), (byte)(vector.Byte1 / divisor), (byte)(vector.Byte2 / divisor), (byte)(vector.Byte3 / divisor), (byte)(vector.Byte4 / divisor), (byte)(vector.Byte5 / divisor), (byte)(vector.Byte6 / divisor), (byte)(vector.Byte7 / divisor), (byte)(vector.Byte8 / divisor), (byte)(vector.Byte9 / divisor), (byte)(vector.Byte10 / divisor), (byte)(vector.Byte11 / divisor), (byte)(vector.Byte12 / divisor), (byte)(vector.Byte13 / divisor), (byte)(vector.Byte14 / divisor), (byte)(vector.Byte15 / divisor));";

            @class += "\n\t\t}";

            
            @class += "\n\n\t\tinternal static v256 vdiv_byte_const(v256 vector, byte divisor)\n\t\t{\n\t\t\t";
            @class += "if (Avx2.IsAvx2Supported)\n\t\t\t{\n\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t{";

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                if (pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString());
                    @class += "\n\t\t\t\t\t{\n\t\t\t\t\t\tv256 MAGIC = new short16(" + pair.Value.ToString() + ");";
                    @class += "\n\t\t\t\t\t\tv256 CVT_MASK = Avx.mm256_setzero_si256();";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\tv256 lo = Avx2.mm256_mulhrs_epi16(Avx2.mm256_unpacklo_epi8(vector, CVT_MASK), MAGIC);";
                    @class += "\n\t\t\t\t\t\tv256 hi = Avx2.mm256_mulhrs_epi16(Avx2.mm256_unpackhi_epi8(vector, CVT_MASK), MAGIC);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\treturn Avx2.mm256_packus_epi16(lo, hi);";
                    @class += "\n\t\t\t\t\t}";
                }
            }

            @class += "\n";
            @class += "\n\t\t\t\t\tcase " + AddColonAndPaddingToNumber(255.ToString()) +  "return Avx2.mm256_sub_epi8(Avx.mm256_setzero_si256(), Avx2.mm256_cmpeq_epi8(vector, Avx2.mm256_cmpeq_epi32(default(v256), default(v256))));";

            @class += "\n\t\t\t\t}";
            @class += "\n\t\t\t}";
            
            @class += "\n\n\t\t\treturn new v256((byte)(vector.Byte0 / divisor), (byte)(vector.Byte1 / divisor), (byte)(vector.Byte2 / divisor), (byte)(vector.Byte3 / divisor), (byte)(vector.Byte4 / divisor), (byte)(vector.Byte5 / divisor), (byte)(vector.Byte6 / divisor), (byte)(vector.Byte7 / divisor), (byte)(vector.Byte8 / divisor), (byte)(vector.Byte9 / divisor), (byte)(vector.Byte10 / divisor), (byte)(vector.Byte11 / divisor), (byte)(vector.Byte12 / divisor), (byte)(vector.Byte13 / divisor), (byte)(vector.Byte14 / divisor), (byte)(vector.Byte15 / divisor), (byte)(vector.Byte16 / divisor), (byte)(vector.Byte17 / divisor), (byte)(vector.Byte18 / divisor), (byte)(vector.Byte19 / divisor), (byte)(vector.Byte20 / divisor), (byte)(vector.Byte21 / divisor), (byte)(vector.Byte22 / divisor), (byte)(vector.Byte23 / divisor), (byte)(vector.Byte24 / divisor), (byte)(vector.Byte25 / divisor), (byte)(vector.Byte26 / divisor), (byte)(vector.Byte27 / divisor), (byte)(vector.Byte28 / divisor), (byte)(vector.Byte29 / divisor), (byte)(vector.Byte30 / divisor), (byte)(vector.Byte31 / divisor));";

            @class += "\n\t\t}";
            @class += "\n\t}";
            @class += "\n}";

            writerbyte.Write(@class);
        }

        private static void Generate_DivRem_byte(Dictionary<byte, short> databyte)
        {
            using FileStream streambyte = new FileStream("E:/DivRem Byte by Constant.cs", FileMode.Create);
            using StreamWriter writerbyte = new StreamWriter(streambyte);

            UnityEngine.Debug.Log("Optimized " + (1 + databyte.Count).ToString() + " byte divisions");

            string @class = "using Unity.Burst.Intrinsics;\n";
            @class += "\n";
            @class += "\nusing static Unity.Burst.Intrinsics.X86;\n";
            @class += "\n";

            @class += "\nnamespace MaxMath";
            @class += "\n{";
            @class += "\n\tunsafe internal static partial class Operator";
            @class += "\n\t{";
            @class += "\n\t\tinternal static v128 vdivrem_byte_const(v128 vector, byte divisor, int vectorElementCount, out v128 remainders)";
            @class += "\n\t\t{";
            @class += "\n\t\t\tif (vectorElementCount <= 8)";
            @class += "\n\t\t\t{";
            @class += "\n\t\t\t\tif (Sse2.IsSse2Supported)";
            @class += "\n\t\t\t\t{";
            @class += "\n\t\t\t\t\tswitch (divisor)";
            @class += "\n\t\t\t\t\t{";

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                if (pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString());
                    @class += "\n\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\tv128 DIV_MAGIC = new short8(" + pair.Value.ToString() + ");";
                    @class += "\n\t\t\t\t\t\t\tv128 REM_MAGIC = new short8(ushort.MaxValue / " + pair.Key.ToString() + " + 1);";
                    @class += "\n\t\t\t\t\t\t\tv128 DIVISOR16 = new short8(divisor);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tv128 cast = Cast.ByteToShort(vector);";
                    @class += "\n\t\t\t\t\t\t\tv128 remainders16 = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast, REM_MAGIC), DIVISOR16);";
                    @class += "\n\t\t\t\t\t\t\tremainders = Sse2.packus_epi16(remainders16, remainders16);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tif (Ssse3.IsSsse3Supported)";
                    @class += "\n\t\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\t\tv128 quotients16 = Ssse3.mulhrs_epi16(cast, DIV_MAGIC);";
                    @class += "\n\t\t\t\t\t\t\t\treturn Sse2.packus_epi16(quotients16, quotients16);";
                    @class += "\n\t\t\t\t\t\t\t}";
                    @class += "\n\t\t\t\t\t\t\telse";
                    @class += "\n\t\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\t\tv128 quotients16 = new v128((byte)((byte)cast.UShort0 / divisor), (byte)((byte)cast.UShort1 / divisor), (byte)((byte)cast.UShort2 / divisor), (byte)((byte)cast.UShort3 / divisor), (byte)((byte)cast.UShort4 / divisor), (byte)((byte)cast.UShort5 / divisor), (byte)((byte)cast.UShort6 / divisor), (byte)((byte)cast.UShort7 / divisor));";
                    @class += "\n\t\t\t\t\t\t\t\treturn Sse2.packus_epi16(quotients16, quotients16);";
                    @class += "\n\t\t\t\t\t\t\t}";
                    @class += "\n\t\t\t\t\t\t}";
                }
            }

            @class += "\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}\n\t\t\telse\n\t\t\t{\n\t\t\t\t";
            @class += "if (Avx2.IsAvx2Supported)\n\t\t\t\t{\n\t\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t\t{";

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                if (pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "\n\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\tv256 DIV_MAGIC = new short16(" + pair.Value.ToString() + ");";
                    @class += "\n\t\t\t\t\t\t\tv256 REM_MAGIC = new short16(ushort.MaxValue / " + pair.Key.ToString() + " + 1);";
                    @class += "\n\t\t\t\t\t\t\tv256 DIVISOR16 = new short16(divisor);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tv256 cast = Avx2.mm256_cvtepu8_epi16(vector);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tv256 remainders16 = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast, REM_MAGIC), DIVISOR16);";
                    @class += "\n\t\t\t\t\t\t\tv256 quotients16 = Avx2.mm256_mulhrs_epi16(cast, DIV_MAGIC);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tremainders = Sse2.packus_epi16(Avx.mm256_castsi256_si128(remainders16), Avx2.mm256_extracti128_si256(remainders16, 1));";
                    @class += "\n\t\t\t\t\t\t\treturn Sse2.packus_epi16(Avx.mm256_castsi256_si128(quotients16), Avx2.mm256_extracti128_si256(quotients16, 1));\n\t\t\t\t\t\t}";
                }
            }

            @class += "\n\t\t\t\t\t}";
            @class += "\n\t\t\t\t}";
            @class += "\n\t\t\t\telse if (Ssse3.IsSsse3Supported)\n\t\t\t\t{\n\t\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t\t{";

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                if (pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "\n\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\tv128 DIV_MAGIC = new short8(" + pair.Value.ToString() + ");";
                    @class += "\n\t\t\t\t\t\t\tv128 REM_MAGIC = new short8(ushort.MaxValue / " + pair.Key.ToString() + " + 1);";
                    @class += "\n\t\t\t\t\t\t\tv128 DIVISOR16 = new short8(divisor);";
                    @class += "\n\t\t\t\t\t\t\tv128 CVT_MASK = Sse2.setzero_si128();";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tv128 cast_lo = Sse2.unpacklo_epi8(vector, CVT_MASK);";
                    @class += "\n\t\t\t\t\t\t\tv128 cast_hi = Sse2.unpackhi_epi8(vector, CVT_MASK);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tv128 remainders16_lo = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast_lo, REM_MAGIC), DIVISOR16);";
                    @class += "\n\t\t\t\t\t\t\tv128 remainders16_hi = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast_hi, REM_MAGIC), DIVISOR16);";
                    @class += "\n\t\t\t\t\t\t\tremainders = Sse2.packus_epi16(remainders16_lo, remainders16_hi);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\t\tif (Ssse3.IsSsse3Supported)\n\t\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\t\tv128 quotients16_lo = Ssse3.mulhrs_epi16(cast_lo, DIV_MAGIC);";
                    @class += "\n\t\t\t\t\t\t\t\tv128 quotients16_hi = Ssse3.mulhrs_epi16(cast_hi, DIV_MAGIC);";
                    @class += "\n\t\t\t\t\t\t\t\treturn Sse2.packus_epi16(quotients16_lo, quotients16_hi);";
                    @class += "\n\t\t\t\t\t\t\t}\n\t\t\t\t\t\t\telse\n\t\t\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\t\t\tv128 quotients16_lo = new v128((byte)((byte)cast_lo.UShort0 / divisor), (byte)((byte)cast_lo.UShort1 / divisor), (byte)((byte)cast_lo.UShort2 / divisor), (byte)((byte)cast_lo.UShort3 / divisor), (byte)((byte)cast_lo.UShort4 / divisor), (byte)((byte)cast_lo.UShort5 / divisor), (byte)((byte)cast_lo.UShort6 / divisor), (byte)((byte)cast_lo.UShort7 / divisor));";
                    @class += "\n\t\t\t\t\t\t\t\tv128 quotients16_hi = new v128((byte)((byte)cast_hi.UShort0 / divisor), (byte)((byte)cast_hi.UShort1 / divisor), (byte)((byte)cast_hi.UShort2 / divisor), (byte)((byte)cast_hi.UShort3 / divisor), (byte)((byte)cast_hi.UShort4 / divisor), (byte)((byte)cast_hi.UShort5 / divisor), (byte)((byte)cast_hi.UShort6 / divisor), (byte)((byte)cast_hi.UShort7 / divisor));";
                    @class += "\n\t\t\t\t\t\t\t\treturn Sse2.packus_epi16(quotients16_lo, quotients16_hi);";
                    @class += "\n\t\t\t\t\t\t\t}";
                    @class += "\n\t\t\t\t\t\t}";
                }
            }
            @class += "\n\t\t\t\t\t}";
            @class += "\n\t\t\t\t}";
            @class += "\n\t\t\t}";

            @class += "\n";
            
            @class += "\n\t\t\tif (Sse2.IsSse2Supported)\n\t\t\t{";
            @class += "\n\t\t\t\tif (vectorElementCount <= 8)\n\t\t\t\t{";
            @class += "\n\t\t\t\t\tv128 REM_MAGIC = new short8((short)(ushort.MaxValue / divisor + 1));";
            @class += "\n\t\t\t\t\tv128 DIVISOR16 = new short8(divisor);";
            @class += "\n";
            @class += "\n\t\t\t\t\tv128 cast = Cast.ByteToShort(vector);";
            @class += "\n\t\t\t\t\tv128 remainders16 = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast, REM_MAGIC), DIVISOR16);";
            @class += "\n";
            @class += "\n\t\t\t\t\tremainders = Sse2.packus_epi16(remainders16, remainders16);";

            @class += "\n\t\t\t\t}\n\t\t\t\telse\n\t\t\t\t{";

            @class += "\n\t\t\t\t\tif (Avx2.IsAvx2Supported)\n\t\t\t\t\t{";
            @class += "\n\t\t\t\t\t\tv256 REM_MAGIC = new short16((short)(ushort.MaxValue / divisor + 1));";
            @class += "\n\t\t\t\t\t\tv256 DIVISOR16 = new short16(divisor);";
            @class += "\n";
            @class += "\n\t\t\t\t\t\tv256 cast = Avx2.mm256_cvtepu8_epi16(vector);";
            @class += "\n";
            @class += "\n\t\t\t\t\t\tv256 remainders16 = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast, REM_MAGIC), DIVISOR16);";
            @class += "\n\t\t\t\t\t\tv256 quotients16 = new v256((byte)((byte)cast.UShort0 / divisor), (byte)((byte)cast.UShort1 / divisor), (byte)((byte)cast.UShort2 / divisor), (byte)((byte)cast.UShort3 / divisor), (byte)((byte)cast.UShort4 / divisor), (byte)((byte)cast.UShort5 / divisor), (byte)((byte)cast.UShort6 / divisor), (byte)((byte)cast.UShort7 / divisor), (byte)((byte)cast.UShort8 / divisor), (byte)((byte)cast.UShort9 / divisor), (byte)((byte)cast.UShort10 / divisor), (byte)((byte)cast.UShort11 / divisor), (byte)((byte)cast.UShort12 / divisor), (byte)((byte)cast.UShort13 / divisor), (byte)((byte)cast.UShort14 / divisor), (byte)((byte)cast.UShort15 / divisor));";
            @class += "\n";
            @class += "\n\t\t\t\t\t\tremainders = Sse2.packus_epi16(Avx.mm256_castsi256_si128(remainders16), Avx2.mm256_extracti128_si256(remainders16, 1));";
            @class += "\n\t\t\t\t\t\treturn Sse2.packus_epi16(Avx.mm256_castsi256_si128(quotients16), Avx2.mm256_extracti128_si256(quotients16, 1));";

            @class += "\n\t\t\t\t\t}\n\t\t\t\t\telse\n\t\t\t\t\t{";

            @class += "\n\t\t\t\t\t\tv128 REM_MAGIC = new short8((short)(ushort.MaxValue / divisor + 1));";
            @class += "\n\t\t\t\t\t\tv128 DIVISOR16 = new short8(divisor);";
            @class += "\n\t\t\t\t\t\tv128 CVT_MASK = Sse2.setzero_si128();";
            @class += "\n";
            @class += "\n\t\t\t\t\t\tv128 cast_lo = Sse2.unpacklo_epi8(vector, CVT_MASK);";
            @class += "\n\t\t\t\t\t\tv128 cast_hi = Sse2.unpackhi_epi8(vector, CVT_MASK);";
            @class += "\n";
            @class += "\n\t\t\t\t\t\tv128 remainders16_lo = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast_lo, REM_MAGIC), DIVISOR16);";
            @class += "\n\t\t\t\t\t\tv128 remainders16_hi = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast_hi, REM_MAGIC), DIVISOR16);";
            @class += "\n";
            @class += "\n\t\t\t\t\t\tremainders = Sse2.packus_epi16(remainders16_lo, remainders16_hi);";
            @class += "\n\t\t\t\t\t}\n\t\t\t\t}\n\t\t\t}";
            @class += "\n\t\t\telse\n\t\t\t{";
            @class += "\n\t\t\t\tremainders = new v128((byte)(vector.Byte0 % divisor), (byte)(vector.Byte1 % divisor), (byte)(vector.Byte2 % divisor), (byte)(vector.Byte3 % divisor), (byte)(vector.Byte4 % divisor), (byte)(vector.Byte5 % divisor), (byte)(vector.Byte6 % divisor), (byte)(vector.Byte7 % divisor), (byte)(vector.Byte8 % divisor), (byte)(vector.Byte9 % divisor), (byte)(vector.Byte10 % divisor), (byte)(vector.Byte11 % divisor), (byte)(vector.Byte12 % divisor), (byte)(vector.Byte13 % divisor), (byte)(vector.Byte14 % divisor), (byte)(vector.Byte15 % divisor));";
            @class += "\n\t\t\t}";

            @class += "\n\n\t\t\treturn new v128((byte)(vector.Byte0 / divisor), (byte)(vector.Byte1 / divisor), (byte)(vector.Byte2 / divisor), (byte)(vector.Byte3 / divisor), (byte)(vector.Byte4 / divisor), (byte)(vector.Byte5 / divisor), (byte)(vector.Byte6 / divisor), (byte)(vector.Byte7 / divisor), (byte)(vector.Byte8 / divisor), (byte)(vector.Byte9 / divisor), (byte)(vector.Byte10 / divisor), (byte)(vector.Byte11 / divisor), (byte)(vector.Byte12 / divisor), (byte)(vector.Byte13 / divisor), (byte)(vector.Byte14 / divisor), (byte)(vector.Byte15 / divisor));";

            @class += "\n\t\t}";

            
            @class += "\n\n\t\tinternal static v256 vdivrem_byte_const(v256 vector, byte divisor, out v256 remainders)\n\t\t{\n\t\t\t";
            @class += "if (Avx2.IsAvx2Supported)\n\t\t\t{\n\t\t\t\t";
            @class += "switch (divisor)\n\t\t\t\t{";

            foreach (KeyValuePair<byte, short> pair in databyte)
            {
                if (pair.Key != 1)
                {
                    @class += "\n\t\t\t\t\tcase " + AddColonAndPaddingToNumber(pair.Key.ToString()) + "\n\t\t\t\t\t{";
                    @class += "\n\t\t\t\t\t\tv256 DIV_MAGIC = new short16(" + pair.Value.ToString() + ");";
                    @class += "\n\t\t\t\t\t\tv256 REM_MAGIC = new short16(ushort.MaxValue / " + pair.Key.ToString() + " + 1);";
                    @class += "\n\t\t\t\t\t\tv256 DIVISOR16 = new short16(divisor);";
                    @class += "\n\t\t\t\t\t\tv256 CVT_MASK = Avx.mm256_setzero_si256();";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\tv256 cast_lo = Avx2.mm256_unpacklo_epi8(vector, CVT_MASK);";
                    @class += "\n\t\t\t\t\t\tv256 cast_hi = Avx2.mm256_unpackhi_epi8(vector, CVT_MASK);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\tv256 remainders16_lo = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast_lo, REM_MAGIC), DIVISOR16);";
                    @class += "\n\t\t\t\t\t\tv256 remainders16_hi = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast_hi, REM_MAGIC), DIVISOR16);";
                    @class += "\n\t\t\t\t\t\tv256 quotients16_lo = Avx2.mm256_mulhrs_epi16(cast_lo, DIV_MAGIC);";
                    @class += "\n\t\t\t\t\t\tv256 quotients16_hi = Avx2.mm256_mulhrs_epi16(cast_hi, DIV_MAGIC);";
                    @class += "\n";
                    @class += "\n\t\t\t\t\t\tremainders = Avx2.mm256_packus_epi16(remainders16_lo, remainders16_hi);";
                    @class += "\n\t\t\t\t\t\treturn Avx2.mm256_packus_epi16(quotients16_lo, quotients16_hi);\n\t\t\t\t\t}";
                }
            }
            @class += "\n\t\t\t\t}";
            @class += "\n\t\t\t}";

            @class += "\n";
            
            @class += "\n\t\t\tif (Avx2.IsAvx2Supported)\n\t\t\t{";
            @class += "\n\t\t\t\tv256 REM_MAGIC = new short16((short)(ushort.MaxValue / divisor + 1));";
            @class += "\n\t\t\t\tv256 DIVISOR16 = new short16(divisor);";
            @class += "\n\t\t\t\tv256 CVT_MASK = Avx.mm256_setzero_si256();";
            @class += "\n";
            @class += "\n\t\t\t\tv256 cast_lo = Avx2.mm256_unpacklo_epi8(vector, CVT_MASK);";
            @class += "\n\t\t\t\tv256 cast_hi = Avx2.mm256_unpackhi_epi8(vector, CVT_MASK);";
            @class += "\n";
            @class += "\n\t\t\t\tv256 remainders16_lo = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast_lo, REM_MAGIC), DIVISOR16);";
            @class += "\n\t\t\t\tv256 remainders16_hi = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast_hi, REM_MAGIC), DIVISOR16);";
            @class += "\n\t\t\t\tv256 quotients16_lo = new v256((byte)((byte)cast_lo.UShort0 / divisor), (byte)((byte)cast_lo.UShort1 / divisor), (byte)((byte)cast_lo.UShort2 / divisor), (byte)((byte)cast_lo.UShort3 / divisor), (byte)((byte)cast_lo.UShort4 / divisor), (byte)((byte)cast_lo.UShort5 / divisor), (byte)((byte)cast_lo.UShort6 / divisor), (byte)((byte)cast_lo.UShort7 / divisor), (byte)((byte)cast_lo.UShort8 / divisor), (byte)((byte)cast_lo.UShort9 / divisor), (byte)((byte)cast_lo.UShort10 / divisor), (byte)((byte)cast_lo.UShort11 / divisor), (byte)((byte)cast_lo.UShort12 / divisor), (byte)((byte)cast_lo.UShort13 / divisor), (byte)((byte)cast_lo.UShort14 / divisor), (byte)((byte)cast_lo.UShort15 / divisor));";
            @class += "\n\t\t\t\tv256 quotients16_hi = new v256((byte)((byte)cast_hi.UShort0 / divisor), (byte)((byte)cast_hi.UShort1 / divisor), (byte)((byte)cast_hi.UShort2 / divisor), (byte)((byte)cast_hi.UShort3 / divisor), (byte)((byte)cast_hi.UShort4 / divisor), (byte)((byte)cast_hi.UShort5 / divisor), (byte)((byte)cast_hi.UShort6 / divisor), (byte)((byte)cast_hi.UShort7 / divisor), (byte)((byte)cast_hi.UShort8 / divisor), (byte)((byte)cast_hi.UShort9 / divisor), (byte)((byte)cast_hi.UShort10 / divisor), (byte)((byte)cast_hi.UShort11 / divisor), (byte)((byte)cast_hi.UShort12 / divisor), (byte)((byte)cast_hi.UShort13 / divisor), (byte)((byte)cast_hi.UShort14 / divisor), (byte)((byte)cast_hi.UShort15 / divisor));";
            @class += "\n";
            @class += "\n\t\t\t\tremainders = Avx2.mm256_packus_epi16(remainders16_lo, remainders16_hi);";
            @class += "\n\t\t\t\treturn Avx2.mm256_packus_epi16(quotients16_lo, quotients16_hi);";
            @class += "\n\t\t\t}";
            @class += "\n";

            @class += "\n\t\t\t\tremainders = new v256((byte)(vector.Byte0 % divisor), (byte)(vector.Byte1 % divisor), (byte)(vector.Byte2 % divisor), (byte)(vector.Byte3 % divisor), (byte)(vector.Byte4 % divisor), (byte)(vector.Byte5 % divisor), (byte)(vector.Byte6 % divisor), (byte)(vector.Byte7 % divisor), (byte)(vector.Byte8 % divisor), (byte)(vector.Byte9 % divisor), (byte)(vector.Byte10 % divisor), (byte)(vector.Byte11 % divisor), (byte)(vector.Byte12 % divisor), (byte)(vector.Byte13 % divisor), (byte)(vector.Byte14 % divisor), (byte)(vector.Byte15 % divisor), (byte)(vector.Byte16 % divisor), (byte)(vector.Byte17 % divisor), (byte)(vector.Byte18 % divisor), (byte)(vector.Byte19 % divisor), (byte)(vector.Byte20 % divisor), (byte)(vector.Byte21 % divisor), (byte)(vector.Byte22 % divisor), (byte)(vector.Byte23 % divisor), (byte)(vector.Byte24 % divisor), (byte)(vector.Byte25 % divisor), (byte)(vector.Byte26 % divisor), (byte)(vector.Byte27 % divisor), (byte)(vector.Byte28 % divisor), (byte)(vector.Byte29 % divisor), (byte)(vector.Byte30 % divisor), (byte)(vector.Byte31 % divisor));";
            @class += "\n\n\t\t\treturn new v256((byte)(vector.Byte0 / divisor), (byte)(vector.Byte1 / divisor), (byte)(vector.Byte2 / divisor), (byte)(vector.Byte3 / divisor), (byte)(vector.Byte4 / divisor), (byte)(vector.Byte5 / divisor), (byte)(vector.Byte6 / divisor), (byte)(vector.Byte7 / divisor), (byte)(vector.Byte8 / divisor), (byte)(vector.Byte9 / divisor), (byte)(vector.Byte10 / divisor), (byte)(vector.Byte11 / divisor), (byte)(vector.Byte12 / divisor), (byte)(vector.Byte13 / divisor), (byte)(vector.Byte14 / divisor), (byte)(vector.Byte15 / divisor), (byte)(vector.Byte16 / divisor), (byte)(vector.Byte17 / divisor), (byte)(vector.Byte18 / divisor), (byte)(vector.Byte19 / divisor), (byte)(vector.Byte20 / divisor), (byte)(vector.Byte21 / divisor), (byte)(vector.Byte22 / divisor), (byte)(vector.Byte23 / divisor), (byte)(vector.Byte24 / divisor), (byte)(vector.Byte25 / divisor), (byte)(vector.Byte26 / divisor), (byte)(vector.Byte27 / divisor), (byte)(vector.Byte28 / divisor), (byte)(vector.Byte29 / divisor), (byte)(vector.Byte30 / divisor), (byte)(vector.Byte31 / divisor));";

            @class += "\n\t\t}";
            @class += "\n\t}";
            @class += "\n}";

            writerbyte.Write(@class);
        }
    }
}