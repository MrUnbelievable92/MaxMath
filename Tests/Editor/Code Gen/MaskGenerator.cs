using DevTools;
using MaxMath.Intrinsics;
using System.Collections.Generic;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    internal class MaskGenerator
    {
        internal MaskGenerator(int num, int bitWidth)
        {
            Num = num;
            BitWidth = bitWidth;
        }

        private int Num;
        private int BitWidth;

        private bool UseV128 => Num * BitWidth <= 128;
        private bool UseV256 => !UseV128;
        private string BaseType => BitWidth == 64 ? "ulong" : (BitWidth == 32 ? "uint" : (BitWidth == 16 ? "ushort" : "byte"));
        private string BaseVector => BaseType + (UseV128 ? (BitWidth == 64 ? "2" : (BitWidth == 32 ? "4" : (BitWidth == 16 ? "8"  : "16"))) 
                                                         : (BitWidth == 64 ? "4" : (BitWidth == 32 ? "8" : (BitWidth == 16 ? "16" : "32"))));

        private string GetField(int i)
        {
            if (Num <= 4)
            {
                return i == 0 ? "x" : (i == 1 ? "y" : (i == 2 ? "z" : "w"));
            }
            else
            {
                return $"x{i}";
            }
        }
        private string CreateReferences()
        {
            return "using System;\r\n" +
                   "using System.Diagnostics;\r\n" +
                   "using System.Runtime.CompilerServices;\r\n" +
                   "using System.Runtime.InteropServices;\r\n" +
                   "using DevTools;\r\n" +
                   "\r\n" +
                   "using static MaxMath.Intrinsics.Xse;\r\n" +
                   "using static Unity.Burst.Intrinsics.X86;\r\n" +
                   "using static MaxMath.math;\r\n";
        }
        private string CreateAttributes()
        {
            return $"\t[StructLayout(LayoutKind.Explicit, Size = {(UseV128 ? "16" : "32")})]\r\n" +
                   $"\t[DebuggerTypeProxy(typeof(mask{BitWidth}x{Num}.DebuggerProxy))]";
        }
        private string CreateDebuggerProxy()
        {
            string result = "\t\tinternal sealed class DebuggerProxy\r\n" +
                            "\t\t{\r\n";

            for (int i = 0; i < Num; i++)
            {
                result += $"\t\t\tpublic bool {GetField(i)};\r\n";
            }
            result += "\r\n";

            result += $"\t\t\tpublic DebuggerProxy(mask{BitWidth}x{Num} v)\r\n" +
                       "\t\t\t{\r\n";

            string vector = UseV128 ? "v128" : "v256";
            char[] baseType = BaseType.ToCharArray();
            baseType[0] = char.ToUpper(baseType[0]);
            if (BitWidth != 8)
            {
                baseType[1] = char.ToUpper(baseType[1]);

                result += "\t\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                          "\t\t\t\t{\r\n";
                for (int i = 0; i < Num; i++)
                {
                    result += $"\t\t\t\t\t{GetField(i)} = (({vector})v.mask).{new string(baseType)}{i} != 0;\r\n";
                }
                result += "\t\t\t\t}\r\n" +
                          "\t\t\t\telse\r\n" +
                          "\t\t\t\t{\r\n";
                for (int i = 0; i < Num; i++)
                {
                    result += $"\t\t\t\t\t{GetField(i)} = (({vector})v.mask).Byte{i} != 0;\r\n";
                }
                result += "\t\t\t\t}\r\n";
            }
            else
            {
                for (int i = 0; i < Num; i++)
                {
                    result += $"\t\t\t\t{GetField(i)} = (({vector})v.mask).Byte{i} != 0;\r\n";
                }
            }

            result += "\t\t\t}\r\n" +
                      "\t\t}\r\n";

            return result;
        }
        private string CreateCTORs()
        {
            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
                            $"\t\tinternal mask{BitWidth}x{Num}({(UseV128 ? "v128" : "v256")} mask)\r\n" +
                             "\t\t{\r\n" +
                             "\t\t\tthis.mask = mask;\r\n" +
                             "\t\t}\r\n";

            if (UseV256)
            {
                result += "\r\n";
                result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
                          $"\t\tinternal mask{BitWidth}x{Num}(v128 maskLo, v128 maskHi)\r\n" +
                           "\t\t{\r\n" +
                           "\t\t\tthis.mask = new ulong4(maskLo, maskHi);\r\n" +
                           "\t\t}\r\n";
            }

            result += "\r\n";
            
     //     string cvtSplat = $"({BaseType})-tolong(v)";
     //     switch (Num)
     //     {
     //         case 2:
     //         {
     //             result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                       $"\t\tpublic mask{BitWidth}x{Num}(bool x, bool y)\r\n" +
     //                        "\t\t{\r\n" +
     //                       $"\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                       $"\t\t\tv[0] = to{BaseType}(x);\r\n" +
     //                       $"\t\t\tv[1] = to{BaseType}(y);\r\n" +
     //                        "\r\n" +
     //                        "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                        "\t\t\t{\r\n" +
     //                       $"\t\t\t\tv = 0 - v;\r\n" +
     //                        "\t\t\t}\r\n" +
     //                        "\r\n" +
     //                       $"\t\t\tmask = *(ulong{(UseV128 ? "2" : "4")}*)&v;\r\n" +
     //                        "\t\t}\r\n";
     //             
     //             result += "\r\n";
     //
     //             result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                       $"\t\tpublic mask{BitWidth}x{Num}(bool v)\r\n" +
     //                        "\t\t{\r\n" +
     //                       $"\t\t\t{BaseType} cvt = {cvtSplat};\r\n" +
     //                        "\r\n";
     //
     //
     //             if (UseV256)
     //             {
     //                 result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
     //                            "\t\t\t{\r\n" +
     //                           $"\t\t\t\tmask = Xse.mm256_set_epi{BitWidth}(cvt);\r\n" +
     //                            "\t\t\t}\r\n" +  
     //                            "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                            "\t\t\t{\r\n" +
     //                           $"\t\t\t\tmask = new ulong4(Xse.set_epi{BitWidth}(cvt), Xse.set_epi{BitWidth}(cvt));\r\n" +
     //                            "\t\t\t}\r\n" +
     //                            "\t\t\telse\r\n" +
     //                            "\t\t\t{\r\n" +
     //                           $"\t\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                           $"\t\t\t\tv[0] = cvt;\r\n" +
     //                           $"\t\t\t\tv[1] = cvt;\r\n" +
     //                           $"\t\t\t\tmask = *(ulong4*)&v;\r\n" +
     //                            "\t\t\t}\r\n" +
     //                            "\t\t}\r\n";
     //             }
     //             else
     //             {
     //                 result +=  "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                            "\t\t\t{\r\n" +
     //                           $"\t\t\t\tmask = Xse.set_epi{BitWidth}(cvt);\r\n" +
     //                            "\t\t\t}\r\n" +
     //                            "\t\t\telse\r\n" +
     //                            "\t\t\t{\r\n" +
     //                           $"\t\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                           $"\t\t\t\tv[0] = cvt;\r\n" +
     //                           $"\t\t\t\tv[1] = cvt;\r\n" +
     //                           $"\t\t\t\tmask = *(ulong2*)&v;\r\n" +
     //                            "\t\t\t}\r\n" +
     //                            "\t\t}\r\n";
     //             }
     //
     //             return result;
     //         }
     //         case 3:
     //         {
     //             result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                       $"\t\tpublic mask{BitWidth}x{Num}(bool x, bool y, bool z)\r\n" +
     //                        "\t\t{\r\n" +
     //                       $"\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                       $"\t\t\tv[0] = to{BaseType}(x);\r\n" +
     //                       $"\t\t\tv[1] = to{BaseType}(y);\r\n" +
     //                       $"\t\t\tv[2] = to{BaseType}(z);\r\n" +
     //                        "\r\n" +
     //                        "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                        "\t\t\t{\r\n" +
     //                       $"\t\t\t\tv = 0 - v;\r\n" +
     //                        "\t\t\t}\r\n" +
     //                        "\r\n" +
     //                       $"\t\t\tmask = *(ulong{(UseV128 ? "2" : "4")}*)&v;\r\n" +
     //                        "\t\t}\r\n";
     //             
     //             result += "\r\n";
     //
     //             result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                       $"\t\tpublic mask{BitWidth}x{Num}(bool x, mask{BitWidth}x2 yz)\r\n" +
     //                        "\t\t{\r\n" +
     //                        "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                        "\t\t\t{\r\n" +
     //                       $"\t\t\t\t\r\n" +
     //                        "\t\t\t}\r\n" +
     //                        "\t\t\telse\r\n" +
     //                        "\t\t\t{\r\n" +
     //                       $"\t\t\t\t\r\n" +
     //                        "\t\t\t}\r\n" +
     //                        "\t\t}\r\n";
     //             
     //             result += "\r\n";
     //
     // /// <summary>Constructs a bool3 vector from a bool2 vector and a bool value.</summary>
     // /// <param name="xy">The constructed vector's xy components will be set to this value.</param>
     // /// <param name="z">The constructed vector's z component will be set to this value.</param>
     // [MethodImpl(MethodImplOptions.AggressiveInlining)]
     // public bool3(bool2 xy, bool z)
     // {
     //     this.x = xy.x;
     //     this.y = xy.y;
     //     this.z = z;
     // }
     //
     // /// <summary>Constructs a bool3 vector from a single bool value by assigning it to every component.</summary>
     // /// <param name="v">bool to convert to bool3</param>
     // [MethodImpl(MethodImplOptions.AggressiveInlining)]
     // public bool3(bool v)
     // {
     //     this.x = v;
     //     this.y = v;
     //     this.z = v;
     // }
     //         }
     //           case 4:
     //           {
     //               result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                         $"\t\tpublic mask{BitWidth}x{Num}(bool x, bool y, bool z, bool w)\r\n" +
     //                          "\t\t{\r\n" +
     //                         $"\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                         $"\t\t\tv[0] = to{BaseType}(x);\r\n" +
     //                         $"\t\t\tv[1] = to{BaseType}(y);\r\n" +
     //                         $"\t\t\tv[2] = to{BaseType}(z);\r\n" +
     //                         $"\t\t\tv[3] = to{BaseType}(w);\r\n" +
     //                          "\r\n" +
     //                          "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                          "\t\t\t{\r\n" +
     //                         $"\t\t\t\tv = 0 - v;\r\n" +
     //                          "\t\t\t}\r\n" +
     //                          "\r\n" +
     //                         $"\t\t\tmask = *(ulong{(UseV128 ? "2" : "4")}*)&v;\r\n" +
     //                          "\t\t}\r\n";
     //               
     //               result += "\r\n";
     //           }
     //           case 8:
     //           {
     //               result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                         $"\t\tpublic mask{BitWidth}x{Num}(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7)\r\n" +
     //                          "\t\t{\r\n" +
     //                         $"\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                         $"\t\t\tv[0] = to{BaseType}(x0);\r\n" +
     //                         $"\t\t\tv[1] = to{BaseType}(x1);\r\n" +
     //                         $"\t\t\tv[2] = to{BaseType}(x2);\r\n" +
     //                         $"\t\t\tv[3] = to{BaseType}(x3);\r\n" +
     //                         $"\t\t\tv[4] = to{BaseType}(x4);\r\n" +
     //                         $"\t\t\tv[5] = to{BaseType}(x5);\r\n" +
     //                         $"\t\t\tv[6] = to{BaseType}(x6);\r\n" +
     //                         $"\t\t\tv[7] = to{BaseType}(x7);\r\n" +
     //                          "\r\n" +
     //                          "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                          "\t\t\t{\r\n" +
     //                         $"\t\t\t\tv = 0 - v;\r\n" +
     //                          "\t\t\t}\r\n" +
     //                          "\r\n" +
     //                         $"\t\t\tmask = *(ulong{(UseV128 ? "2" : "4")}*)&v;\r\n" +
     //                          "\t\t}\r\n";
     //               
     //               result += "\r\n";
     //           }
     //           case 16:
     //           {
     //               result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                         $"\t\tpublic mask{BitWidth}x{Num}(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15)\r\n" +
     //                          "\t\t{\r\n" +
     //                         $"\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                         $"\t\t\tv[0]  = to{BaseType}(x0);\r\n"  +
     //                         $"\t\t\tv[1]  = to{BaseType}(x1);\r\n"  +
     //                         $"\t\t\tv[2]  = to{BaseType}(x2);\r\n"  +
     //                         $"\t\t\tv[3]  = to{BaseType}(x3);\r\n"  +
     //                         $"\t\t\tv[4]  = to{BaseType}(x4);\r\n"  +
     //                         $"\t\t\tv[5]  = to{BaseType}(x5);\r\n"  +
     //                         $"\t\t\tv[6]  = to{BaseType}(x6);\r\n"  +
     //                         $"\t\t\tv[7]  = to{BaseType}(x7);\r\n"  +
     //                         $"\t\t\tv[8]  = to{BaseType}(x8);\r\n"  +
     //                         $"\t\t\tv[9]  = to{BaseType}(x9);\r\n"  +
     //                         $"\t\t\tv[10] = to{BaseType}(x10);\r\n" +
     //                         $"\t\t\tv[11] = to{BaseType}(x11);\r\n" +
     //                         $"\t\t\tv[12] = to{BaseType}(x12);\r\n" +
     //                         $"\t\t\tv[13] = to{BaseType}(x13);\r\n" +
     //                         $"\t\t\tv[14] = to{BaseType}(x14);\r\n" +
     //                         $"\t\t\tv[15] = to{BaseType}(x15);\r\n" +
     //                          "\r\n" +
     //                          "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                          "\t\t\t{\r\n" +
     //                         $"\t\t\t\tv = 0 - v;\r\n" +
     //                          "\t\t\t}\r\n" +
     //                          "\r\n" +
     //                         $"\t\t\tmask = *(ulong{(UseV128 ? "2" : "4")}*)&v;\r\n" +
     //                          "\t\t}\r\n";
     //               
     //               result += "\r\n";
     //           }
     //           case 32:
     //           {
     //               result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
     //                         $"\t\tpublic mask{BitWidth}x{Num}(bool x0, bool x1, bool x2, bool x3, bool x4, bool x5, bool x6, bool x7, bool x8, bool x9, bool x10, bool x11, bool x12, bool x13, bool x14, bool x15, bool x16, bool x17, bool x18, bool x19, bool x20, bool x21, bool x22, bool x23, bool x24, bool x25, bool x26, bool x27, bool x28, bool x29, bool x30, bool x31)\r\n" +
     //                          "\t\t{\r\n" +
     //                         $"\t\t\t{BaseVector} v = Uninitialized<{BaseVector}>.Create()\r\n" +
     //                         $"\t\t\tv[0]  = to{BaseType}(x0);\r\n"  +
     //                         $"\t\t\tv[1]  = to{BaseType}(x1);\r\n"  +
     //                         $"\t\t\tv[2]  = to{BaseType}(x2);\r\n"  +
     //                         $"\t\t\tv[3]  = to{BaseType}(x3);\r\n"  +
     //                         $"\t\t\tv[4]  = to{BaseType}(x4);\r\n"  +
     //                         $"\t\t\tv[5]  = to{BaseType}(x5);\r\n"  +
     //                         $"\t\t\tv[6]  = to{BaseType}(x6);\r\n"  +
     //                         $"\t\t\tv[7]  = to{BaseType}(x7);\r\n"  +
     //                         $"\t\t\tv[8]  = to{BaseType}(x8);\r\n"  +
     //                         $"\t\t\tv[9]  = to{BaseType}(x9);\r\n"  +
     //                         $"\t\t\tv[10] = to{BaseType}(x10);\r\n" +
     //                         $"\t\t\tv[11] = to{BaseType}(x11);\r\n" +
     //                         $"\t\t\tv[12] = to{BaseType}(x12);\r\n" +
     //                         $"\t\t\tv[13] = to{BaseType}(x13);\r\n" +
     //                         $"\t\t\tv[14] = to{BaseType}(x14);\r\n" +
     //                         $"\t\t\tv[15] = to{BaseType}(x15);\r\n" +
     //                         $"\t\t\tv[16] = to{BaseType}(x16);\r\n" +
     //                         $"\t\t\tv[17] = to{BaseType}(x17);\r\n" +
     //                         $"\t\t\tv[18] = to{BaseType}(x18);\r\n" +
     //                         $"\t\t\tv[19] = to{BaseType}(x19);\r\n" +
     //                         $"\t\t\tv[20] = to{BaseType}(x20);\r\n" +
     //                         $"\t\t\tv[21] = to{BaseType}(x21);\r\n" +
     //                         $"\t\t\tv[22] = to{BaseType}(x22);\r\n" +
     //                         $"\t\t\tv[23] = to{BaseType}(x23);\r\n" +
     //                         $"\t\t\tv[24] = to{BaseType}(x24);\r\n" +
     //                         $"\t\t\tv[25] = to{BaseType}(x25);\r\n" +
     //                         $"\t\t\tv[26] = to{BaseType}(x26);\r\n" +
     //                         $"\t\t\tv[27] = to{BaseType}(x27);\r\n" +
     //                         $"\t\t\tv[28] = to{BaseType}(x28);\r\n" +
     //                         $"\t\t\tv[29] = to{BaseType}(x29);\r\n" +
     //                         $"\t\t\tv[30] = to{BaseType}(x30);\r\n" +
     //                         $"\t\t\tv[31] = to{BaseType}(x31);\r\n" +
     //                          "\r\n" +
     //                          "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
     //                          "\t\t\t{\r\n" +
     //                         $"\t\t\t\tv = 0 - v;\r\n" +
     //                          "\t\t\t}\r\n" +
     //                          "\r\n" +
     //                         $"\t\t\tmask = *(ulong{(UseV128 ? "2" : "4")}*)&v;\r\n" +
     //                          "\t\t}\r\n";
     //               
     //               result += "\r\n";
     //           }
     //
     //         default: throw Assert.Unreachable();
     //     }
            return result;
        }
        private string CreateFieldsAsProperties()
        {
            string result = string.Empty;

            for (int i = 0; i < Num; i++)
            {
                result += $"\t\tpublic bool {GetField(i)}\r\n" +
                           "\t\t{\r\n" +
                           "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\t\treadonly get => this[{i}];\r\n" +
                          $"\r\n" +
                           "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\t\tset => this[{i}] = value;\r\n" +
                           "\t\t}\r\n";
            }

            return result;
        }
        private string CreateSIMDRegisterConversionOperators()
        {
            string result = $"\t\tpublic static implicit operator v{(UseV128 ? "128" : "256")}(mask{BitWidth}x{Num} input)\r\n" +
                             "\t\t{\r\n" +
                            $"\t\t\tif ({(UseV128 ? "ArchitectureInfo.IsSIMDSupported" : "Avx2.IsAvx2Supported")})\r\n" +
                             "\t\t\t{\r\n" +
                             "\t\t\t\treturn mask.mask;\r\n" +
                             "\t\t\t}\r\n" +
                             "\t\t\telse throw new IllegalInstructionException();\r\n" +
                             "\t\t}\r\n";

            result += "\r\n";

            result += $"\t\tpublic static implicit operator mask{BitWidth}x{Num}(v{(UseV128 ? "128" : "256")} input)\r\n" +
                       "\t\t{\r\n" +
                      $"\t\t\tif ({(UseV128 ? "ArchitectureInfo.IsSIMDSupported" : "Avx2.IsAvx2Supported")})\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn new mask{BitWidth}x{Num}(input);\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t\telse throw new IllegalInstructionException();\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        private string CreateMaskConversionOperators()
        {
            static string CreateConvertWithin128(int num, int from, int to)
            {
                return $"\t\tpublic static implicit operator mask{to}x{num}(mask{from}x{num} input)\r\n" +
                        "\t\t{\r\n" +
                        "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                        "\t\t\t{\r\n" +
                       $"\t\t\t\treturn cvtepi{from}_epi{to}(input, {num});\r\n" +
                        "\t\t\t}\r\n" +
                        "\t\t\telse\r\n" +
                        "\t\t\t{\r\n" +
                       $"\t\t\t\treturn *(mask{to}x{num}*)&input;\r\n" +
                        "\t\t\t}\r\n" +
                        "\t\t}\r\n";
            }

            static string CreateConvertTo256(int num, int from, int to)
            {
                string result = $"\t\tpublic static implicit operator mask{to}x{num}(mask{from}x{num} input)\r\n" +
                                 "\t\t{\r\n" +
                                 "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                                 "\t\t\t{\r\n" +
                                $"\t\t\t\treturn Avx2.mm256_cvtepi{from}_epi{to}(input);\r\n" +
                                 "\t\t\t}\r\n" +
                                 "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                                 "\t\t\t{\r\n";

                switch (from)
                {
                    case 8:
                    {
                        switch (to)
                        {
                            case 16:
                            {
                                result += $"\t\t\t\tv128 lo = cvt2x2epi8_epi16(input, out v128 hi);\r\n";
                                result += $"\t\t\t\treturn new mask{to}x{num}(lo, hi);\r\n";
                                break;
                            }
                            case 32:
                            {
                                result += $"\t\t\t\treturn new mask{to}x{num}(cvtepi8_epi32(input), cvtepi8_epi32(bsrli_si128(input, 4 * sizeof(byte))));\r\n";
                                break;
                            }
                            case 64:
                            {
                                result += $"\t\t\t\treturn new mask{to}x{num}(cvtepi8_epi64(input), cvtepi8_epi64(bsrli_si128(input, 2 * sizeof(byte))));\r\n";
                                break;
                            }
                            default: throw DevTools.Assert.Unreachable();
                        }

                        break;
                    }
                    case 16:
                    {
                        switch (to)
                        {
                            case 32:
                            {
                                result += $"\t\t\t\tv128 lo = cvt2x2epi16_epi32(input, out v128 hi);\r\n";
                                result += $"\t\t\t\treturn new mask{to}x{num}(lo, hi);\r\n";
                                break;
                            }
                            case 64:
                            {
                                result += $"\t\t\t\treturn new mask{to}x{num}(cvtepi16_epi64(input), cvtepi16_epi64(bsrli_si128(input, 2 * sizeof(ushort))));\r\n";
                                break;
                            }
                            default: throw DevTools.Assert.Unreachable();
                        }

                        break;
                    }
                    case 32:
                    {
                        result += $"\t\t\t\tv128 lo = cvt2x2epi32_epi64(input, out v128 hi);\r\n";
                        result += $"\t\t\t\treturn new mask{to}x{num}(lo, hi);\r\n";
                        break;
                    }

                    default: throw DevTools.Assert.Unreachable();
                }

                result +=  "\t\t\t}\r\n" +
                           "\t\t\telse\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\tvoid* stack = stackalloc mask{from}x{num}[2]\r\n" +
                           "\t\t\t\t{\r\n" +
                           "\t\t\t\t\tinput,\r\n" +
                           "\t\t\t\t\tdefault\r\n" +
                           "\t\t\t\t}\r\n" +
                          $"\t\t\t\treturn *(mask{to}x{num}*)stack;\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t}\r\n";

                return result;
            }

            static string CreateConvertFrom256(int num, int from, int to)
            {
                string result = $"\t\tpublic static implicit operator mask{to}x{num}(mask{from}x{num} input)\r\n" +
                                 "\t\t{\r\n" +
                                 "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                                 "\t\t\t{\r\n" +
                                $"\t\t\t\treturn mm256_cvtepi{from}_epi{to}(input);\r\n" +
                                 "\t\t\t}\r\n" +
                                 "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                                 "\t\t\t{\r\n";

                switch (from)
                {
                    case 64:
                    {
                        switch (to)
                        {
                            case 32:
                            {
                                result += "\t\t\t\treturn cvt2x2epi64_epi32(input.mask.xy, input.mask.zw);\r\n";
                                break;
                            }
                            default:
                            {
                                result += $"\t\t\t\treturn new mask{to}x{num}(cvtepi{from}_epi{to}(input.mask.xy), cvtepi{from}_epi{to}(input.mask.zw));\r\n";
                                break;
                            }
                        }

                        break;
                    }
                    case 32:
                    {
                        switch (to)
                        {
                            case 16:
                            {
                                result += "\t\t\t\treturn cvt2x2epi32_epi16(input.mask.xy, input.mask.zw);\r\n";
                                break;
                            }
                            default:
                            {
                                result += $"\t\t\t\treturn new mask{to}x{num}(cvtepi{from}_epi{to}(input.mask.xy), cvtepi{from}_epi{to}(input.mask.zw));\r\n";
                                break;
                            }
                        }

                        break;
                    }
                    case 16:
                    {
                        result += "\t\t\t\treturn cvt2x2epi16_epi8(input.mask.xy, input.mask.zw);\r\n";
                        break;
                    }

                    default: throw DevTools.Assert.Unreachable();
                }

                result +=  "\t\t\t}\r\n" +
                           "\t\t\telse\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn new mask{to}x{num}((v128)input, default);\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t}\r\n";

                return result;
            }

            switch (Num)
            {
                case 2:
                {
                    if (BitWidth == 8)
                    {
                        return CreateConvertWithin128(Num, 16, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 16) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 32) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 64);
                    }
                    else if (BitWidth == 16)
                    {
                        return CreateConvertWithin128(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 32) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 64);
                    }
                    else if (BitWidth == 32)
                    {
                        return CreateConvertWithin128(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 64);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                case 3:
                {
                    if (BitWidth == 8)
                    {
                        return CreateConvertWithin128(Num, 16, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertFrom256(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 16) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 32) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 64);
                    }
                    else if (BitWidth == 16)
                    {
                        return CreateConvertWithin128(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertFrom256(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 32) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 64);
                    }
                    else if (BitWidth == 32)
                    {
                        return CreateConvertFrom256(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 64);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                case 4:
                {
                    if (BitWidth == 8)
                    {
                        return CreateConvertWithin128(Num, 16, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertFrom256(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 16) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 32) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 64);
                    }
                    else if (BitWidth == 16)
                    {
                        return CreateConvertWithin128(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertFrom256(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 32) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 64);
                    }
                    else if (BitWidth == 32)
                    {
                        return CreateConvertFrom256(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 64);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                case 8:
                {
                    if (BitWidth == 8)
                    {
                        return CreateConvertWithin128(Num, 16, BitWidth) +
                               "\r\n" +
                               CreateConvertFrom256(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertWithin128(Num, BitWidth, 16) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 32);
                    }
                    else if (BitWidth == 16)
                    {
                        return CreateConvertFrom256(Num, 64, BitWidth) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 64);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                case 16:
                {
                    if (BitWidth == 8)
                    {
                        return CreateConvertFrom256(Num, 16, BitWidth) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 16);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                case 32:
                {
                    return string.Empty;
                }

                default : throw DevTools.Assert.Unreachable();
            }
        }
        private string CreateboolXConversionOperators()
        {
            string result = $"\t\tpublic static implicit operator bool{Num}(mask{BitWidth}x{Num} input)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn RegisterConversion.ToBool{Num}(RegisterConversion.IsTrue{BitWidth}(input));\r\n";
            }
            else
            {
                string boolHalf = string.Empty;
                switch (BitWidth)
                {
                    case 8:
                    {
                        boolHalf = "16";
                        break;
                    }
                    case 16:
                    {
                        boolHalf = "8";
                        break;
                    }
                    case 32:
                    {
                        boolHalf = "4";
                        break;
                    }
                    case 64:
                    {
                        boolHalf = "2";
                        break;
                    }

                    default: throw DevTools.Assert.Unreachable();
                }
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn RegisterConversion.ToBool{Num}(RegisterConversion.IsTrue{BitWidth}(input));\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\tv128 lo = RegisterConversion.ToBool{boolHalf}(RegisterConversion.IsTrue{BitWidth}(input.xy));\r\n" +
                          $"\t\t\t\tv128 hi = RegisterConversion.ToBool{boolHalf}(RegisterConversion.IsTrue{BitWidth}(input.zw));\r\n" +
                           "\r\n";

                switch (BitWidth)
                {
                    case 8:
                    {
                        result += "\t\t\t\treturn new bool32((bool16)lo, (bool16)hi);\r\n";
                        break;
                    }
                    case 16:
                    {
                        result += "\t\t\t\treturn unpacklo_epi64(lo, hi);\r\n";
                        break;
                    }
                    case 32:
                    {
                        result += "\t\t\t\treturn unpacklo_epi32(lo, hi);\r\n";
                        break;
                    }
                    case 64:
                    {
                        result += "\t\t\t\treturn unpacklo_epi16(lo, hi);\r\n";
                        break;
                    }

                    default: throw DevTools.Assert.Unreachable();
                }
            }

            result += "\t\t\t}\r\n" +
                      "\t\t\telse\r\n" +
                      "\t\t\t{\r\n" +
                     $"\t\t\t\treturn *(bool{Num}*)&input;\r\n" +
                      "\t\t\t}\r\n" +
                      "\t\t}\r\n";

            result += "\r\n";

            result += $"\t\tpublic static implicit operator mask{BitWidth}x{Num}(bool{Num} input)\r\n" +
                       "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n";

                string cast = string.Empty;
                if (BitWidth == 8)
                {
                    cast = "input";
                }
                else
                {
                    cast = $"cvtepu8_epi{BitWidth}(input, {Num})";
                }

                result +=  $"\t\t\t\treturn cmpeq_epi{BitWidth}({cast}, set1_epi{BitWidth}{(BitWidth == 64 ? "x" : string.Empty)}(1));\r\n";
            }
            else
            {
                result += "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                          "\t\t\t{\r\n";

                string cast = string.Empty;
                if (BitWidth == 8)
                {
                    cast = "input";
                }
                else
                {
                    cast = $"Avx2.mm256_cvtepu8_epi{BitWidth}(input)";
                }

                result += $"\t\t\t\treturn Avx2.mm256_cmpeq_epi{BitWidth}({cast}, mm256_set1_epi{BitWidth}{(BitWidth == 64 ? "x" : string.Empty)}(1));\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n";

                string lo = string.Empty;
                string hi = string.Empty;
                switch (BitWidth)
                {
                    case 8:
                    {
                        lo = "input.v16_0";
                        hi = "input.v16_16";
                        break;
                    }
                    case 16:
                    {
                        lo = "cvtepu8_epi16(input.v8_0)";
                        hi = "cvtepu8_epi16(input.v8_8)";
                        break;
                    }
                    case 32:
                    {
                        lo = "cvtepu8_epi32(input.v4_0)";
                        hi = "cvtepu8_epi32(input.v4_4)";
                        break;
                    }
                    case 64:
                    {
                        lo = "cvtepu8_epi64(input.xy)";
                        if (Num == 4)
                        {
                            hi = "cvtepu8_epi64(input.zw)";
                        }
                        else
                        {
                            hi = "cvtsi64x_si128(*(byte*)&input.z)";
                        }
                        break;
                    }
                    default: throw DevTools.Assert.Unreachable();
                }
                result += $"\t\t\t\treturn new mask{BitWidth}x{Num}(cmpeq_epi{BitWidth}({lo}, set1_epi{BitWidth}{(BitWidth == 64 ? "x" : string.Empty)}(1)), cmpeq_epi{BitWidth}({hi}, set1_epi{BitWidth}{(BitWidth == 64 ? "x" : string.Empty)}(1)))\r\n";

            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn *(mask{BitWidth}x{Num}*)&input;\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        private string CreateboolConversionOperator()
        {
            string result = $"\t\tpublic static implicit operator mask{BitWidth}x{Num}(bool input)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result += "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                          "\t\t\t{\r\n" +
                          "\t\t\t\treturn set1_epi64x(-tolong(input));\r\n" +
                          "\t\t\t}\r\n";
            }
            else
            {
                result += "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                          "\t\t\t{\r\n" +
                          "\t\t\t\treturn mm256_set1_epi64x(-tolong(input));\r\n" +
                          "\t\t\t}\r\n" +
                          "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                          "\t\t\t{\r\n" +
                         $"\t\t\t\treturn new mask{BitWidth}x{Num}(set1_epi64x(-tolong(input)), set1_epi64x(-tolong(input)));\r\n" +
                          "\t\t\t}\r\n";
            }

            result += "\t\t\telse\r\n" +
                      "\t\t\t{\r\n" +
                     $"\t\t\t\treturn (bool{Num})input;\r\n" +
                      "\t\t\t}\r\n" +
                      "\t\t}\r\n";

            return result;
        }
        private string CreateShuffles()
        {
            string result = string.Empty;

            if (Num > 4)
            {
                foreach (SubVector subVector in new SubVectorIterator(Num).Generate())
                {
                    result += $"\t\tpublic mask{BitWidth}x{subVector.Length} {subVector.Name}\r\n" +
                               "\t\t{\r\n"+
                               "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                              $"\t\t\treadonly get\r\n" +
                               "\t\t\t{\r\n" +
                               "\t\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\treturn (mask.Reinterpret<{(UseV128 ? "ulong2" : "ulong4")}, {BaseVector}>()).{subVector.Name};\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t\telse\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\treturn (mask.Reinterpret<{(UseV128 ? "ulong2" : "ulong4")}, {(UseV128 ? "byte16" : "byte32")}>()).{subVector.Name};\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t}\r\n" +
                               "\r\n" +
                               "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                               "\t\t\tset\r\n" +
                               "\t\t\t{\r\n" +
                               "\t\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\t{BaseVector} reinterpret = mask.Reinterpret<{(UseV128 ? "ulong2" : "ulong4")}, {BaseVector}>();\r\n" +
                              $"\t\t\t\t\treinterpret.{subVector.Name} = value;\r\n" +
                              $"\t\t\t\t\tthis = reinterpret.Reinterpret<{BaseVector}, mask{BitWidth}x{Num}>();\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t\telse\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\t{BaseVector} reinterpret = mask.Reinterpret<{(UseV128 ? "ulong2" : "ulong4")}, {(UseV128 ? "byte16" : "byte32")}>();\r\n" +
                              $"\t\t\t\t\treinterpret.{subVector.Name} = value;\r\n" +
                              $"\t\t\t\t\tthis = reinterpret.Reinterpret<{(UseV128 ? "byte16" : "byte32")}, mask{BitWidth}x{Num}>();\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t}\r\n" +
                               "\t\t}\r\n";
                }
            }
            else
            {
                foreach (Swizzle swizzle in new SwizzleIterator(Num).Generate())
                {
                    result += $"\t\tpublic mask{BitWidth}x{swizzle.Indices.Length} {swizzle.Name}\r\n" +
                               "\t\t{\r\n"+
                               "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                              $"\t\t\treadonly get\r\n" +
                               "\t\t\t{\r\n" +
                               "\t\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\tmask{BitWidth}x{Num} stack = this;\r\n" +
                              $"\t\t\t\t\treturn (*({BaseType}{(Num == 2 ? "2" : "4")}*)&stack).{swizzle.Name};\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t\telse\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\tmask{BitWidth}x{Num} stack = this;\r\n" +
                              $"\t\t\t\t\treturn (*(bool4*)&stack).{swizzle.Name};\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t}\r\n";

                    if (swizzle.AllUnique)
                    {
                        result +=  "\r\n" +
                                   "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\t\tset\r\n" +
                                   "\t\t\t{\r\n" +
                                   "\t\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                                   "\t\t\t\t{\r\n" +
                                  $"\t\t\t\t\tmask{BitWidth}x{Num} stack = this;\r\n" +
                                  $"\t\t\t\t\t{BaseType}{(Num == 2 ? "2" : "4")} slice = *({BaseType}{(Num == 2 ? "2" : "4")}*)&stack;\r\n" +
                                  $"\t\t\t\t\tslice.{swizzle.Name} = value;\r\n" +
                                  $"\t\t\t\t\t*({BaseType}{(Num == 2 ? "2" : "4")}*)&stack = slice;\r\n" +
                                  $"\t\t\t\t\tthis = stack;\r\n" +
                                   "\t\t\t\t}\r\n" +
                                   "\t\t\t\telse\r\n" +
                                   "\t\t\t\t{\r\n" +
                                  $"\t\t\t\t\tmask{BitWidth}x{Num} stack = this;\r\n" +
                                   "\t\t\t\t\tbool4 slice = *(bool4*)&stack;\r\n" +
                                  $"\t\t\t\t\tslice.{swizzle.Name} = value;\r\n" +
                                  $"\t\t\t\t\t*(bool4*)&stack = slice;\r\n" +
                                  $"\t\t\t\t\tthis = stack;\r\n" +
                                   "\t\t\t\t}\r\n" +
                                   "\t\t\t}\r\n";
                    }

                    result += "\t\t}\r\n";

                }
            }

            return result;
        }
        private string CreateIndexOperator()
        {
            string result = "\t\tpublic bool this[int index]\r\n" +
                            "\t\t{\r\n" +
                            "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            "\t\t\treadonly get\r\n" +
                            "\t\t\t{\r\n" +
                           $"Assert.IsWithinArrayBounds(index, {Num});\r\n" +
                            "\r\n" +
                            "\t\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                            "\t\t\t\t{\r\n" +
                           $"\t\t\t\t\treturn mask.Reinterpret<{(UseV128 ? "ulong2" : "ulong4")}, {BaseVector}>()[index] != 0;\r\n" +
                            "\t\t\t\t}\r\n" +
                            "\t\t\t\telse\r\n" +
                            "\t\t\t\t{\r\n" +
                           $"\t\t\t\t\treturn ((bool{Num})this)[index];\r\n" +
                            "\t\t\t\t}\r\n" +
                            "\t\t\t}\r\n";

            result += "\r\n";
            result +=  "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                       "\t\t\tset\r\n" +
                       "\t\t\t{\r\n" +
                      $"Assert.IsWithinArrayBounds(index, {Num});\r\n" +
                       "\r\n" +
                       "\t\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                       "\t\t\t\t{\r\n" +
                      $"\t\t\t\t\t{BaseVector} reinterpret = mask.Reinterpret<{(UseV128 ? "ulong2" : "ulong4")}, {BaseVector}>();\r\n" +
                      $"\t\t\t\t\treinterpret[index] = ({BaseType})-tolong(value);\r\n" +
                      $"\t\t\t\t\tmask = reinterpret.Reinterpret<{BaseVector}, {(UseV128 ? "ulong2" : "ulong4")}>();\r\n" +
                       "\t\t\t\t}\r\n" +
                       "\t\t\t\telse\r\n" +
                       "\t\t\t\t{\r\n" +
                      $"\t\t\t\t\tbool{Num} reinterpret = this;\r\n" +
                      $"\t\t\t\t\treinterpret[index] = value;\r\n" +
                      $"\t\t\t\t\tthis = reinterpret;\r\n" +
                       "\t\t\t\t}\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        private string CreateBitwiseOperator(char bitwiseOperator)
        {
            string operatorToString = bitwiseOperator == '&' ? "and" : (bitwiseOperator == '|' ? "or" : "xor");

            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (mask{BitWidth}x{Num} left, mask{BitWidth}x{Num} right)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn {operatorToString}_si128(left, right);\r\n";
            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                           $"\t\t\t\treturn Avx2.mm256_{operatorToString}_si256(left, right);\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn new mask{BitWidth}x{Num}({operatorToString}_si128(left.mask.xy, right.mask.xy), {operatorToString}_si128(left.mask.zw, right.mask.zw));\r\n";
            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn (bool{Num})left {bitwiseOperator} (bool{Num})right;\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        private string CreateNOT()
        {
            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static mask{BitWidth}x{Num} operator ! (mask{BitWidth}x{Num} value)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn not_si128(value);\r\n";
            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                           $"\t\t\t\treturn mm256_not_si256(value);\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn new mask{BitWidth}x{Num}(not_si128(value.mask.xy), not_si128(value.mask.zw));\r\n";
            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn !(bool{Num})value;\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        private string CreateEqual(bool notEqual)
        {
            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static mask{BitWidth}x{Num} operator {(notEqual ? "!=" : "==")} (mask{BitWidth}x{Num} left, mask{BitWidth}x{Num} right)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn {(notEqual ? $"xor_si128(left, right)" : $"cmpeq_epi{BitWidth}(left, right)")};\r\n";
            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn {(notEqual ? $"Avx2.mm256_xor_si256(left, right)" : $"Avx2.mm256_cmpeq_epi{BitWidth}(left, right)")};\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn new mask{BitWidth}x{Num}({(notEqual ? $"xor_si128(left.xy, right.xy)" : $"cmpeq_epi{BitWidth}(left.xy, right.xy)")}, {(notEqual ? $"xor_si128(left.zw, right.zw)" : $"cmpeq_epi{BitWidth}(left.zw, right.zw)")});\r\n";
            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn (bool{Num})left {(notEqual ? "!=" : "==")} (bool{Num})right;\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        //no boxing allowed for ref structs, only 1 parameter version using implicit casts
        private string CreateEquals()
        {
            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic readonly bool Equals(mask{BitWidth}x{Num} other)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn alltrue_si128<{BaseType}>(cmpeq_epi{BitWidth}(this, other, {Num}));\r\n";

            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn mm256_alltrue_si256<{BaseType}>(Avx2.mm256_cmpeq_epi{BitWidth}(this, other, {Num}));\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (ArchitectureInfo.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\tbool lo = alltrue_si128<{BaseType}>(cmpeq_epi{BitWidth}(this.mask.xy, other.mask.xy, {Num / 2}));\r\n" +
                          $"\t\t\t\tbool hi = {(Num == 3 ? "this.mask.z == other.mask.z;" : $"alltrue_si128<{BaseType}>(cmpeq_epi{BitWidth}(this.mask.zw, other.mask.zw, {Num / 2}));")}\r\n" +
                           "\t\t\t\treturn lo & hi;\r\n";
            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn ((bool{Num})this).Equals((bool{Num})other);\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        private string CreateGetHashCode()
        {
            return "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                   "\t\tpublic override readonly int GetHashCode()\r\n" +
                   "\t\t{\r\n" +
                   "\t\t\treturn bitmask(this);\r\n" +
                   "\t\t}\r\n";
        }
        private string CreateToString()
        {
            return  "\t\tpublic override readonly string ToString()\r\n" +
                    "\t\t{\r\n" +
                   $"\t\t\treturn ((bool{Num})this).ToString();\r\n" +
                    "\t\t}\r\n";
        }

        public override string ToString()
        {
            string result = CreateReferences();
            result += "\r\n";

            result += "namespace MaxMath\r\n{\r\n";

            result += CreateAttributes();
            result += "\r\n";

            result += $"\tunsafe public readonly ref struct mask{BitWidth}x{Num} : IEquatable<mask{BitWidth}x{Num}>\r\n" +
                       "\t{\r\n";

            result += CreateDebuggerProxy();
            result += "\r\n";
            result += "\r\n";

            result += $"\t\tprivate readonly ulong{(UseV128 ? "2" : "4")} mask;\r\n";
            result += "\r\n";
            result += "\r\n";

            result += CreateCTORs();
            result += "\r\n";
            result += "\r\n";

            result += CreateFieldsAsProperties();
            result += "\r\n";
            result += "\r\n";

            result += CreateShuffles();
            result += "\r\n";
            result += "\r\n";

            result += CreateIndexOperator();
            result += "\r\n";
            result += "\r\n";

            result += CreateSIMDRegisterConversionOperators();
            result += "\r\n";
            result += CreateMaskConversionOperators();
            result += "\r\n";
            result += CreateboolXConversionOperators();
            result += "\r\n";
            result += CreateboolConversionOperator();
            result += "\r\n";

            result += "\r\n";

            result += CreateNOT();
            result += "\r\n";
            result += CreateBitwiseOperator('&');
            result += "\r\n";
            result += CreateBitwiseOperator('|');
            result += "\r\n";
            result += CreateBitwiseOperator('^');
            result += "\r\n";
            result += CreateEqual(true);
            result += "\r\n";
            result += CreateEqual(false);
            result += "\r\n";

            result += "\r\n";

            result += CreateEquals();
            result += "\r\n";
            result += CreateGetHashCode();
            result += "\r\n";
            result += CreateToString();

            result += "\t}\r\n";
            result += "}\r\n";
            return result;
        }

        internal static (string, string)[] GenerateAllMasks()
        {
            return new (string, string)[]
            {
                (("mask8x2"),   new MaskGenerator(2,  8).ToString()),
                (("mask8x3"),   new MaskGenerator(3,  8).ToString()),
                (("mask8x4"),   new MaskGenerator(4,  8).ToString()),
                (("mask8x8"),   new MaskGenerator(8,  8).ToString()),
                (("mask8x16"),  new MaskGenerator(16, 8).ToString()),
                (("mask8x32"),  new MaskGenerator(32, 8).ToString()),

                (("mask16x2"),  new MaskGenerator(2,  16).ToString()),
                (("mask16x3"),  new MaskGenerator(3,  16).ToString()),
                (("mask16x4"),  new MaskGenerator(4,  16).ToString()),
                (("mask16x8"),  new MaskGenerator(8,  16).ToString()),
                (("mask16x16"), new MaskGenerator(16, 16).ToString()),

                (("mask32x2"), new MaskGenerator(2, 32).ToString()),
                (("mask32x3"), new MaskGenerator(3, 32).ToString()),
                (("mask32x4"), new MaskGenerator(4, 32).ToString()),
                (("mask32x8"), new MaskGenerator(8, 32).ToString()),

                (("mask64x2"), new MaskGenerator(2, 64).ToString()),
                (("mask64x3"), new MaskGenerator(3, 64).ToString()),
                (("mask64x4"), new MaskGenerator(4, 64).ToString()),
            };
        }
    }
}
