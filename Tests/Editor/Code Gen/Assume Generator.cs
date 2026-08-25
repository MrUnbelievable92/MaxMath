namespace MaxMath.Tests
{
    internal static class AssumeGenerator
    {
        /// <summary>
        /// Expects '{result}' and '{a}' 
        /// </summary>
        internal static string GenerateOneArgument(params string[] expressions)
        {
            static string Generate(string field, int elements, params string[] expressions)
            {
                string result = string.Empty;

                foreach (string expression in expressions) 
                {
                    for (int i = 0; i < elements; i++) 
                    {
                        string fieldNow = "." + field + (i >= 10 ? i.ToString() : i.ToString() + (elements >= 10 ? " " : string.Empty));

                        result += "constexpr.ASSUME("
                                + expression.Replace("{result}", "result" + fieldNow).Replace("{a}", "a" + fieldNow)
                                + ");\r\n";                
                    }

                    result += "\r\n";
                }

                return result;
            }

            return Generate("Byte",   16, expressions) + "\r\n"
                 + Generate("Byte",   32, expressions) + "\r\n"
                 + Generate("UShort", 8,  expressions) + "\r\n"
                 + Generate("UShort", 16, expressions) + "\r\n"
                 + Generate("UInt",   4,  expressions) + "\r\n"
                 + Generate("UInt",   8,  expressions) + "\r\n"
                 + Generate("ULong",  2,  expressions) + "\r\n"
                 + Generate("ULong",  4,  expressions) + "\r\n"
                 + Generate("SByte",  16, expressions) + "\r\n"
                 + Generate("SByte",  32, expressions) + "\r\n"
                 + Generate("SShort", 8,  expressions) + "\r\n"
                 + Generate("SShort", 16, expressions) + "\r\n"
                 + Generate("SInt",   4,  expressions) + "\r\n"
                 + Generate("SInt",   8,  expressions) + "\r\n"
                 + Generate("SLong",  2,  expressions) + "\r\n"
                 + Generate("SLong",  4,  expressions) + "\r\n";
        }

        /// <summary>
        /// Expects '{result}', '{a}' and '{b}'
        /// /// </summary>
        internal static string GenerateTwoArguments(params string[] expressions)
        {
            static string Generate(string field, int elements, params string[] expressions)
            {
                string result = string.Empty;

                foreach (string expression in expressions) 
                {
                    for (int i = 0; i < elements; i++) 
                    {
                        string fieldNow = "." + field + (i >= 10 ? i.ToString() : i.ToString() + (elements >= 10 ? " " : string.Empty));

                        result += "constexpr.ASSUME("
                                + expression.Replace("{result}", "result" + fieldNow).Replace("{a}", "a" + fieldNow).Replace("{b}", "b" + fieldNow)
                                + ");\r\n";                
                    }

                    result += "\r\n";
                }

                return result;
            }

            return Generate("Byte",   16, expressions) + "\r\n"
                 + Generate("Byte",   32, expressions) + "\r\n"
                 + Generate("UShort", 8,  expressions) + "\r\n"
                 + Generate("UShort", 16, expressions) + "\r\n"
                 + Generate("UInt",   4,  expressions) + "\r\n"
                 + Generate("UInt",   8,  expressions) + "\r\n"
                 + Generate("ULong",  2,  expressions) + "\r\n"
                 + Generate("ULong",  4,  expressions) + "\r\n"
                 + Generate("SByte",  16, expressions) + "\r\n"
                 + Generate("SByte",  32, expressions) + "\r\n"
                 + Generate("SShort", 8,  expressions) + "\r\n"
                 + Generate("SShort", 16, expressions) + "\r\n"
                 + Generate("SInt",   4,  expressions) + "\r\n"
                 + Generate("SInt",   8,  expressions) + "\r\n"
                 + Generate("SLong",  2,  expressions) + "\r\n"
                 + Generate("SLong",  4,  expressions) + "\r\n";
        }
    }
}
