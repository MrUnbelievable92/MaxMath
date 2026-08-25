using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace MaxMath.Tests
{
    public static class __execute
    {
        [Test]
        public static void Please()
        {
            FunctionGenerator f = new FunctionGenerator()
            {
                GenerateScalar = true,
                FunctionName = "floordiv",
                GenerateBoolean = false,
                GenerateFloatingPoint = false,
                GenerateInteger = true,
                GenerateMatrix = false,
                GenerateVector = true,
                ParameterNames = new string[] {"x", "y"}
            };
            string result = f.GenerateFunctions();
            
            File.WriteAllText($"E:/Floor Division.cs", result);
        }
    }
}
