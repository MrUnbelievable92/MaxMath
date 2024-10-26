using System;

namespace MaxMath.Tests
{
    internal static partial class CodeGen
    {
        internal static string GenerateIterated(string separator, int length, Func<int, string> generationAlgorithm)
        {
            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                result += generationAlgorithm(i);

                if (i != length - 1)
                {
                    result += separator;
                }
            }

            return result;
        }
    }
}
