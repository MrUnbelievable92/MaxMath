using System;
using System.Reflection;
using System.Collections.Generic;
using DevTools;
using MaxMath.Intrinsics;
using System.Linq;


namespace MaxMath.Tests
{
    internal class MaskGenerator
    {
        internal MaskGenerator(int num, int bitWidth)
        {
            Num = num;
            BitWidth = bitWidth;
        }

        private readonly int Num;
        private readonly int BitWidth;

        private bool UseV128 => Num * BitWidth <= 128;
        private bool UseV256 => !UseV128;
        private string BaseType => BitWidth == 64 ? "ulong" : (BitWidth == 32 ? "uint" : (BitWidth == 16 ? "ushort" : "byte"));
        private string BaseVector => BaseType + (UseV128 ? (BitWidth == 64 ? "2" : (BitWidth == 32 ? "4" : (BitWidth == 16 ? "8"  : "16"))) 
                                                         : (BitWidth == 64 ? "4" : (BitWidth == 32 ? "8" : (BitWidth == 16 ? "16" : "32"))));
        private string LoHalf
        {
            get
            {
                switch (Num)
                {
                    case 3:
                    case 4:
                    {
                        return "xy";
                    }
                    case 8:
                    {
                        return "v4_0";
                    }
                    case 16:
                    {
                        return "v8_0";
                    }
                    case 32:
                    {
                        return "v16_0";
                    }
                
                    default: throw Assert.Unreachable();
                }
            }
        }
        private string HiHalf
        {
            get
            {
                switch (Num)
                {
                    case 3:
                    case 4:
                    {
                        return "zw";
                    }
                    case 8:
                    {
                        return "v4_4";
                    }
                    case 16:
                    {
                        return "v8_8";
                    }
                    case 32:
                    {
                        return "v16_16";
                    }
                
                    default: throw Assert.Unreachable();
                }
            }
        }


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
            return "using System.Diagnostics;\r\n" +
                   "using System.Runtime.CompilerServices;\r\n" +
                   "using System.Runtime.InteropServices;\r\n" +
                   "using Unity.Burst.Intrinsics;\r\n" +
                   "using DevTools;\r\n" +
                   "using MaxMath.Intrinsics;\r\n" +
                   "\r\n" +
                   "using static MaxMath.Intrinsics.Xse;\r\n" +
                   "using static Unity.Burst.Intrinsics.X86;\r\n" +
                   "using static MaxMath.math;\r\n";
        }
        private string CreateAttributes()
        {
            return $"\t[StructLayout(LayoutKind.Sequential, Pack = 1)]\r\n" +
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

                result += "\t\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
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
        
        internal string GenerateCTORCopies()
        {
            string result = string.Empty;
            foreach (Type type in typeof(MaxMath.math).Assembly.GetTypes())
            {
                if (type.Name != $"bool{Num}")
                {
                    continue;
                }

                bool newV256ForFallback = !UseV128
                                       && !(BitWidth == 8 
                                         && Num == 32);

                foreach (ConstructorInfo ctor in type.GetConstructors())
                {
                    if (!ctor.IsPublic)
                    {
                        continue;
                    }

                    result += $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n";

                    ParameterInfo[] parameters = ctor.GetParameters();

                    if (parameters.Length != 1)
                    {
                        string signature = $"\t\tpublic mask{BitWidth}x{Num}(";
                        string body;

                        if (parameters.Any(p => p.ParameterType == typeof(bool)))
                        {
                            string bodySIMD = $"this = ({(UseV128 ? "v128" : "v256")})new {BaseType}{Num}(";
                            string bodyFallback;
                            if (newV256ForFallback)
                            {
                                bodyFallback = $"this = new v256((v128)new byte{Num}(";
                            }
                            else
                            {
                                bodyFallback = $"this = ({(UseV128 ? "v128" : "v256")})new byte{Num}(";
                            }

                            for (int i = 0; i < parameters.Length; i++)
                            {
                                string typeName = Reflection.GetTypeName(parameters[i].ParameterType, removeNamespace: false);
                                if (typeName != "bool")
                                {
                                    string width = typeName.Substring(typeName.IndexOf("l") + 1);
                                    typeName = typeName.Replace("bool", $"mask{BitWidth}x");
                                    bodySIMD += $"({BaseType}{width})(v128){parameters[i].Name}";
                                    bodyFallback += $"tobyte({parameters[i].Name})";
                                }
                                else
                                {
                                    string signedType = BitWidth == 64 ? "long" : "byte";
                                    bodySIMD += $"({BaseType})-to{signedType}({parameters[i].Name})";
                                    bodyFallback += $"tobyte({parameters[i].Name})";
                                }

                                signature += $"{typeName} {parameters[i].Name}";
                                if (i != parameters.Length - 1)
                                {
                                    signature += ", ";
                                    bodySIMD += ", ";
                                    bodyFallback += ", ";
                                }
                                else
                                {
                                    signature += $")\r\n";
                                    bodySIMD += $");";
                                    bodyFallback += ")";
                                }
                            }
                            
                            if (newV256ForFallback)
                            {
                                bodyFallback += ", default(v128));";
                            }
                            else
                            {
                                bodyFallback += ";";
                            }

                            body =  "\t\t{\r\n"
                                 +  "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n"
                                 +  "\t\t\t{\r\n"
                                 + $"\t\t\t\t{bodySIMD}\r\n"
                                 +  "\t\t\t}\r\n"
                                 +  "\t\t\telse\r\n"
                                 +  "\t\t\t{\r\n"
                                 + $"\t\t\t\t{bodyFallback}\r\n"
                                 +  "\t\t\t}\r\n"
                                 +  "\t\t}\r\n";

                        }
                        else
                        {
                            body = $" => this = ({(UseV128 ? "v128" : "v256")})new {BaseType}{Num}(";

                            for (int i = 0; i < parameters.Length; i++)
                            {
                                string typeName = Reflection.GetTypeName(parameters[i].ParameterType, removeNamespace: false);
                                string width = typeName.Substring(typeName.IndexOf("l") + 1);
                                typeName = typeName.Replace("bool", $"mask{BitWidth}x");
                                body += $"({BaseType}{width})(v128){parameters[i].Name}";

                                signature += $"{typeName} {parameters[i].Name}";
                                if (i != parameters.Length - 1)
                                {
                                    signature += ", ";
                                    body += ", ";
                                }
                                else
                                {
                                    signature += $")";
                                    body += $");";
                                }
                            }
                        }

                        result += signature;
                        result += body;
                    }
                    else
                    {
                        string parameterType = Reflection.GetTypeName(parameters[0].ParameterType, removeNamespace: false);
                        string conversion = $"(mask{BitWidth}x{Num})" + (parameterType.Contains("Unity.Mathematics.") ? $"({parameters[0].ParameterType.Name})" : string.Empty) + parameters[0].Name;

                        result += $"\t\tpublic mask{BitWidth}x{Num}({parameterType} {parameters[0].Name}) => this = {conversion};";
                    }
                    result += "\r\n\r\n";
                }
            }

            result = result.Replace("MaxMath.", string.Empty);
            return result;
        }
        private string CreateCTORs()
        {
            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
                            $"\t\tinternal mask{BitWidth}x{Num}({(UseV128 ? "v128" : "v256")} mask)\r\n" +
                             "\t\t{\r\n" +
                             "\t\t\tthis.mask = mask;\r\n" +
                             "\t\t}\r\n";

            if (Num != 2)
            {
                result += "\r\n";
                result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" + 
                          $"\t\tinternal mask{BitWidth}x{Num}(v128 maskLo, v128 maskHi)\r\n" +
                           "\t\t{\r\n";

                if (UseV256)
                {
                    result += "\t\t\tthis.mask = new ulong4(maskLo, maskHi);\r\n";
                }
                else
                {
                    result += $"\t\t\tthis.mask = (v128)new {BaseType}{(Num == 3 ? "4" : Num.ToString())}(({BaseType}{math.max(Num / 2, 2)})maskLo, ({BaseType}{math.max(Num / 2, 2)})maskHi);\r\n";
                }

                result += "\t\t}\r\n";
            }
            
            result += "\r\n";
            result += GenerateCTORCopies();
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
            string result = $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static implicit operator v{(UseV128 ? "128" : "256")}(mask{BitWidth}x{Num} input)\r\n" +
                             "\t\t{\r\n" +
                            $"\t\t\treturn input.mask;\r\n" +
                             "\t\t}\r\n";

            result += "\r\n";

            result += $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static implicit operator mask{BitWidth}x{Num}(v{(UseV128 ? "128" : "256")} input)\r\n" +
                       "\t\t{\r\n" +
                      $"\t\t\treturn new mask{BitWidth}x{Num} {{ mask = input }};\r\n" +
                       "\t\t}\r\n";

            return result;
        }
        private string CreateMaskConversionOperators()
        {
            static string CreateConvertWithin128(int num, int from, int to)
            {
                return $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                       $"\t\tpublic static implicit operator mask{to}x{num}(mask{from}x{num} input)\r\n" +
                        "\t\t{\r\n" +
                        "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                        "\t\t\t{\r\n" +
                       $"\t\t\t\treturn cvtepi{from}_epi{to}(input);\r\n" +
                        "\t\t\t}\r\n" +
                        "\t\t\telse\r\n" +
                        "\t\t\t{\r\n" +
                       $"\t\t\t\treturn *(mask{to}x{num}*)&input;\r\n" +
                        "\t\t\t}\r\n" +
                        "\t\t}\r\n";
            }

            static string CreateConvertTo256(int num, int from, int to)
            {
                string result = $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                $"\t\tpublic static implicit operator mask{to}x{num}(mask{from}x{num} input)\r\n" +
                                 "\t\t{\r\n" +
                                 "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                                 "\t\t\t{\r\n" +
                                $"\t\t\t\treturn Avx2.mm256_cvtepi{from}_epi{to}(input);\r\n" +
                                 "\t\t\t}\r\n" +
                                 "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
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
                          $"\t\t\t\treturn (bool{num})input;\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t}\r\n";

                return result;
            }

            static string CreateConvertFrom256(int num, int from, int to)
            {
                string result = $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                $"\t\tpublic static implicit operator mask{to}x{num}(mask{from}x{num} input)\r\n" +
                                 "\t\t{\r\n" +
                                 "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                                 "\t\t\t{\r\n" +
                                $"\t\t\t\treturn mm256_cvtepi{from}_epi{to}(input);\r\n" +
                                 "\t\t\t}\r\n" +
                                 "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
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
                                result += "\t\t\t\treturn packs_epi32(input.mask.xy, input.mask.zw);\r\n";
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
                        result += "\t\t\t\treturn packs_epi16(input.mask.xy, input.mask.zw);\r\n";
                        break;
                    }

                    default: throw DevTools.Assert.Unreachable();
                }

                result +=  "\t\t\t}\r\n" +
                           "\t\t\telse\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn (bool{num})input;\r\n" +
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
                        return CreateConvertFrom256(Num, 32, BitWidth) +
                               "\r\n" +
                               CreateConvertTo256(Num, BitWidth, 32);
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
            string result = $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static implicit operator bool{Num}(mask{BitWidth}x{Num} input)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn RegisterConversion.IsTrue{BitWidth}(input);\r\n";
            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn RegisterConversion.IsTrue{BitWidth}(input);\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\tv128 lo = RegisterConversion.IsTrue{BitWidth}(input.{(BitWidth == 64 ? "mask." : string.Empty)}{LoHalf});\r\n" +
                          $"\t\t\t\tv128 hi = RegisterConversion.IsTrue{BitWidth}(input.{(BitWidth == 64 ? "mask." : string.Empty)}{HiHalf});\r\n" +
                           "\r\n";

                switch (BitWidth)
                {
                    case 8:
                    {
                        result += "\t\t\t\treturn new bool32 {__x0 = lo, __x16 = hi };\r\n";
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

            result += $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static implicit operator mask{BitWidth}x{Num}(bool{Num} input)\r\n" +
                       "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n";

                string cast;
                if (BitWidth == 8)
                {
                    cast = "input";
                }
                else
                {
                    cast = $"cvtepu8_epi{BitWidth}(input)";
                }

                result +=  $"\t\t\t\treturn neg_epi{BitWidth}({cast});\r\n";
            }
            else
            {
                result += "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                          "\t\t\t{\r\n";

                string cast;
                if (BitWidth == 8)
                {
                    cast = "input";
                }
                else
                {
                    cast = $"Avx2.mm256_cvtepu8_epi{BitWidth}(input)";
                }

                result += $"\t\t\t\treturn mm256_neg_epi{BitWidth}({cast});\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n";

                string lo;
                string hi;
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
                            hi = "cvtsi64x_si128(tobyte(input.z))";
                        }
                        break;
                    }
                    default: throw DevTools.Assert.Unreachable();
                }
                result += $"\t\t\t\treturn new mask{BitWidth}x{Num}(neg_epi{BitWidth}({lo}), neg_epi{BitWidth}({hi}));\r\n";

            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\tmask{BitWidth}x{Num} result = default(mask{BitWidth}x{Num});\r\n" +
                      $"\t\t\t\t*(bool{Num}*)&result = input;\r\n" +
                      $"\t\t\t\treturn result;\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";

            if (Num <= 4)
            {
                result += "\r\n";
                result += $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\tpublic static implicit operator Unity.Mathematics.bool{Num}(mask{BitWidth}x{Num} input) => (bool{Num})input;\r\n" +
                           "\r\n" +
                          $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\tpublic static implicit operator mask{BitWidth}x{Num}(Unity.Mathematics.bool{Num} input) => (bool{Num})input;\r\n";
            }

            return result;
        }
        private string CreateboolConversionOperator()
        {
            string result = $"\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static implicit operator mask{BitWidth}x{Num}(bool input)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result += "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                          "\t\t\t{\r\n" +
                          "\t\t\t\treturn set1_epi64x(-tolong(input));\r\n" +
                          "\t\t\t}\r\n";
            }
            else
            {
                result += "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                          "\t\t\t{\r\n" +
                          "\t\t\t\treturn mm256_set1_epi64x(-tolong(input));\r\n" +
                          "\t\t\t}\r\n" +
                          "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
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
                               "\t\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\treturn (v128)(({BaseVector}){(UseV128 ? "(v128)" : "(v256)")}mask).{subVector.Name};\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t\telse\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\treturn ((bool{Num})this).{subVector.Name};\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t}\r\n" +
                               "\r\n" +
                               "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                               "\t\t\tset\r\n" +
                               "\t\t\t{\r\n" +
                               "\t\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\t{BaseVector} reinterpret = (({BaseVector}){(UseV128 ? "(v128)" : "(v256)")}mask);\r\n" +
                              $"\t\t\t\t\treinterpret.{subVector.Name} = (v128)value;\r\n" +
                              $"\t\t\t\t\tthis = {(UseV128 ? "(v128)" : "(v256)")}reinterpret;\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t\telse\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\tbool{Num} stack = this;\r\n" +
                              $"\t\t\t\t\tstack.{subVector.Name} = value;\r\n" +
                              $"\t\t\t\t\tthis = stack;\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t}\r\n" +
                               "\t\t}\r\n";
                }
            }
            else
            {
                string cast = UseV128 ? "v128" : "v256";
                foreach (Swizzle swizzle in new SwizzleIterator(Num).Generate())
                {
                    result += $"\t\tpublic {(swizzle.AllUnique ? string.Empty : "readonly ")}mask{BitWidth}x{swizzle.Indices.Length} {swizzle.Name}\r\n" +
                               "\t\t{\r\n"+
                               "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                              $"\t\t\t{(swizzle.AllUnique ? "readonly " : string.Empty)}get\r\n" +
                               "\t\t\t{\r\n" +
                               "\t\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\t{cast} stack = this;\r\n" +
                              $"\t\t\t\t\treturn ({(Num > 2 ? (BitWidth == 64 && swizzle.Name.Length == 2 ? "v128" : cast) : (BitWidth == 64 && swizzle.Name.Length > 2 ? "v256" : cast))})((({BaseType}{(Num == 2 ? "2" : "4")})stack).{swizzle.Name});\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t\telse\r\n" +
                               "\t\t\t\t{\r\n" +
                              $"\t\t\t\t\treturn ((bool{Num})this).{swizzle.Name};\r\n" +
                               "\t\t\t\t}\r\n" +
                               "\t\t\t}\r\n";

                    if (swizzle.AllUnique)
                    {
                        result +=  "\r\n" +
                                   "\t\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\t\tset\r\n" +
                                   "\t\t\t{\r\n" +
                                   "\t\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                                   "\t\t\t\t{\r\n" +
                                  $"\t\t\t\t\t{cast} stack = this;\r\n" +
                                  $"\t\t\t\t\t{BaseType}{(Num == 2 ? "2" : "4")} slice = ({BaseType}{(Num == 2 ? "2" : "4")})stack;\r\n" +
                                  $"\t\t\t\t\tslice.{swizzle.Name} = ({(BitWidth * swizzle.Name.Length > 128 ? "v256" : "v128")})value;\r\n" +
                                  $"\t\t\t\t\tthis = ({cast})slice;\r\n" +
                                   "\t\t\t\t}\r\n" +
                                   "\t\t\t\telse\r\n" +
                                   "\t\t\t\t{\r\n" +
                                  $"\t\t\t\t\tbool{Num} stack = this;\r\n" +
                                  $"\t\t\t\t\tstack.{swizzle.Name} = value;\r\n" +
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
                            "\t\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
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
                       "\t\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
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
        private string CreateOperatorsBetweenMaskTypes(string _operator)
        {
            string result = string.Empty;
            switch (BitWidth)
            {
                case 8:
                {
                    if (Num != 32)
                    {
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask16x{Num} operator {_operator} (mask{BitWidth}x{Num} left, mask16x{Num} right) => (mask16x{Num})left {_operator} right;\r\n"; 
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask16x{Num} operator {_operator} (mask16x{Num} left, mask{BitWidth}x{Num} right) => left {_operator} (mask16x{Num})right;\r\n"; 
                    }
                    if (Num < 16)
                    {
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask32x{Num} operator {_operator} (mask{BitWidth}x{Num} left, mask32x{Num} right) => (mask32x{Num})left {_operator} right;\r\n"; 
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask32x{Num} operator {_operator} (mask32x{Num} left, mask{BitWidth}x{Num} right) => left {_operator} (mask32x{Num})right;\r\n"; 
                    }
                    if (Num < 8)
                    {
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask64x{Num} operator {_operator} (mask{BitWidth}x{Num} left, mask64x{Num} right) => (mask64x{Num})left {_operator} right;\r\n"; 
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask64x{Num} operator {_operator} (mask64x{Num} left, mask{BitWidth}x{Num} right) => left {_operator} (mask64x{Num})right;\r\n"; 
                    }

                    return result;
                }
                case 16:
                {
                    if (Num != 16)
                    {
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask32x{Num} operator {_operator} (mask{BitWidth}x{Num} left, mask32x{Num} right) => (mask32x{Num})left {_operator} right;\r\n"; 
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask32x{Num} operator {_operator} (mask32x{Num} left, mask{BitWidth}x{Num} right) => left {_operator} (mask32x{Num})right;\r\n"; 
                    }
                    if (Num < 8)
                    {
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask64x{Num} operator {_operator} (mask{BitWidth}x{Num} left, mask64x{Num} right) => (mask64x{Num})left {_operator} right;\r\n"; 
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask64x{Num} operator {_operator} (mask64x{Num} left, mask{BitWidth}x{Num} right) => left {_operator} (mask64x{Num})right;\r\n"; 
                    }

                    return result;
                }
                case 32:
                {
                    if (Num != 8)
                    {
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask64x{Num} operator {_operator} (mask{BitWidth}x{Num} left, mask64x{Num} right) => (mask64x{Num})left {_operator} right;\r\n"; 
                        result += "\r\n";
                        result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                                  $"\t\tpublic static mask64x{Num} operator {_operator} (mask64x{Num} left, mask{BitWidth}x{Num} right) => left {_operator} (mask64x{Num})right;\r\n"; 
                    }

                    return result;
                }
                case 64:
                {
                    return result;
                }

                default: throw Assert.Unreachable();
            }
        }
        private string CreateBitwiseOperator(char bitwiseOperator)
        {
            string operatorToString = bitwiseOperator == '&' ? "and" : (bitwiseOperator == '|' ? "or" : "xor");

            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (mask{BitWidth}x{Num} left, mask{BitWidth}x{Num} right)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn {operatorToString}_si128(left, right);\r\n";
            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                           $"\t\t\t\treturn Avx2.mm256_{operatorToString}_si256(left, right);\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn new mask{BitWidth}x{Num}({operatorToString}_si128(left.mask.xy, right.mask.xy), {operatorToString}_si128(left.mask.zw, right.mask.zw));\r\n";
            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn (bool{Num})left {bitwiseOperator} (bool{Num})right;\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";
            
            result +=  "\r\n";
            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (mask{BitWidth}x{Num} left, bool right) => left {bitwiseOperator} (mask{BitWidth}x{Num})right;\r\n"; 
            result += "\r\n";
            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (bool left, mask{BitWidth}x{Num} right) => (mask{BitWidth}x{Num})left {bitwiseOperator} right;\r\n";
            result += "\r\n";
            
            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (mask{BitWidth}x{Num} left, bool{Num} right) => left {bitwiseOperator} (mask{BitWidth}x{Num})right;\r\n"; 
            result += "\r\n";
            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (bool{Num} left, mask{BitWidth}x{Num} right) => (mask{BitWidth}x{Num})left {bitwiseOperator} right;\r\n";

            if (Num <= 4)
            {
                result += "\r\n";
                result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (mask{BitWidth}x{Num} left, Unity.Mathematics.bool{Num} right) => left {bitwiseOperator} (mask{BitWidth}x{Num})right;\r\n"; 
                result += "\r\n";
                result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\tpublic static mask{BitWidth}x{Num} operator {bitwiseOperator} (Unity.Mathematics.bool{Num} left, mask{BitWidth}x{Num} right) => (mask{BitWidth}x{Num})left {bitwiseOperator} right;\r\n"; 
            }

            result += CreateOperatorsBetweenMaskTypes(bitwiseOperator.ToString());

            return result;
        }
        private string CreateNOT()
        {
            string result =  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                            $"\t\tpublic static mask{BitWidth}x{Num} operator ! (mask{BitWidth}x{Num} value)\r\n" +
                             "\t\t{\r\n";

            if (UseV128)
            {
                result +=  "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn not_si128(value);\r\n";
            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                           $"\t\t\t\treturn mm256_not_si256(value);\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
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
                result +=  "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn {(notEqual ? $"xor_si128(left, right)" : $"cmpeq_epi{BitWidth}(left, right)")};\r\n";
            }
            else
            {

                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn {(notEqual ? $"Avx2.mm256_xor_si256(left, right)" : $"Avx2.mm256_cmpeq_epi{BitWidth}(left, right)")};\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n";
                if (BitWidth == 64)
                {
                    result += $"\t\t\t\treturn new mask{BitWidth}x{Num}({(notEqual ? $"xor_si128(left.mask.xy, right.mask.xy)" : $"cmpeq_epi{BitWidth}(left.mask.xy, right.mask.xy)")}, {(notEqual ? $"xor_si128(left.mask.zw, right.mask.zw)" : $"cmpeq_epi{BitWidth}(left.mask.zw, right.mask.zw)")});\r\n";
                }
                else
                {
                    result += $"\t\t\t\treturn new mask{BitWidth}x{Num}({(notEqual ? $"xor_si128(left.{LoHalf}, right.{LoHalf})" : $"cmpeq_epi{BitWidth}(left.{LoHalf}, right.{LoHalf})")}, {(notEqual ? $"xor_si128(left.{HiHalf}, right.{HiHalf})" : $"cmpeq_epi{BitWidth}(left.{HiHalf}, right.{HiHalf})")});\r\n";
                }
            }

            result +=  "\t\t\t}\r\n" +
                       "\t\t\telse\r\n" +
                       "\t\t\t{\r\n" +
                      $"\t\t\t\treturn (bool{Num})left {(notEqual ? "!=" : "==")} (bool{Num})right;\r\n" +
                       "\t\t\t}\r\n" +
                       "\t\t}\r\n";
            result += "\r\n";

            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {(notEqual ? "!=" : "==")} (mask{BitWidth}x{Num} left, bool right) => left {(notEqual ? "!=" : "==")} (mask{BitWidth}x{Num})right;\r\n"; 
            result += "\r\n";
            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {(notEqual ? "!=" : "==")} (bool left, mask{BitWidth}x{Num} right) => (mask{BitWidth}x{Num})left {(notEqual ? "!=" : "==")} right;\r\n"; 
            result += "\r\n";

            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {(notEqual ? "!=" : "==")} (mask{BitWidth}x{Num} left, bool{Num} right) => left {(notEqual ? "!=" : "==")} (mask{BitWidth}x{Num})right;\r\n"; 
            result += "\r\n";
            result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                      $"\t\tpublic static mask{BitWidth}x{Num} operator {(notEqual ? "!=" : "==")} (bool{Num} left, mask{BitWidth}x{Num} right) => (mask{BitWidth}x{Num})left {(notEqual ? "!=" : "==")} right;\r\n"; 

            if (Num <= 4)
            {
                result += "\r\n";
                result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\tpublic static mask{BitWidth}x{Num} operator {(notEqual ? "!=" : "==")} (mask{BitWidth}x{Num} left, Unity.Mathematics.bool{Num} right) => left {(notEqual ? "!=" : "==")} (mask{BitWidth}x{Num})right;\r\n"; 
                result += "\r\n";
                result +=  "\t\t[MethodImpl(MethodImplOptions.AggressiveInlining)]\r\n" +
                          $"\t\tpublic static mask{BitWidth}x{Num} operator {(notEqual ? "!=" : "==")} (Unity.Mathematics.bool{Num} left, mask{BitWidth}x{Num} right) => (mask{BitWidth}x{Num})left {(notEqual ? "!=" : "==")} right;\r\n"; 
            }

            result += CreateOperatorsBetweenMaskTypes((notEqual ? "!=" : "=="));

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
                result +=  "\t\t\tif (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn alltrue_epi128<{BaseType}>(cmpeq_epi{BitWidth}(this, other){(BitWidth == 64 ? string.Empty : $", {Num}")});\r\n";

            }
            else
            {
                result +=  "\t\t\tif (Avx2.IsAvx2Supported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\treturn mm256_alltrue_epi256<{BaseType}>(Avx2.mm256_cmpeq_epi{BitWidth}(this, other){(Num == 3 ? string.Empty : $", {Num}")});\r\n" +
                           "\t\t\t}\r\n" +
                           "\t\t\telse if (BurstArchitecture.IsSIMDSupported)\r\n" +
                           "\t\t\t{\r\n" +
                          $"\t\t\t\tbool lo = alltrue_epi128<{BaseType}>(cmpeq_epi{BitWidth}(this.mask.xy, other.mask.xy));\r\n" +
                          $"\t\t\t\tbool hi = {(Num == 3 ? "this.mask.z == other.mask.z;" : $"alltrue_epi128<{BaseType}>(cmpeq_epi{BitWidth}(this.mask.zw, other.mask.zw));")}\r\n" +
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
            result += "#pragma warning disable CS0660\r\n";
            result += "\r\n";

            result += "namespace MaxMath\r\n{\r\n";

            result += CreateAttributes();
            result += "\r\n";

            result += $"\tunsafe public ref struct mask{BitWidth}x{Num}\r\n" +
                       "\t{\r\n";

            result += CreateDebuggerProxy();
            result += "\r\n";
            result += "\r\n";

            result += $"\t\tinternal ulong{(UseV128 ? "2" : "4")} mask;\r\n";
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
            result += "#pragma warning restore CS0660\r\n";
            return result;
        }

        internal static (string type, string code)[] GenerateAllMasks()
        {
            return new (string type, string code)[]
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
