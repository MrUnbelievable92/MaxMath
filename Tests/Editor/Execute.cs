using System;
using System.IO;
using DevTools;
using NUnit.Framework;

using static MaxMath.LUT.FLOATING_POINT;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    public static class __execute
    {

        [Test]
        public static void Execute()
        {
            foreach ((string, string) mask in MaskGenerator.GenerateAllMasks())
            {
                File.WriteAllText("E:/" + mask.Item1 + ".cs", mask.Item2);
            }
            //foreach (TestJobGenerator job in TestJobGenerator.GenerateAllJobs())
            //{
            //    File.WriteAllText($"E:/testcode/{ job.Type }.cs", job.GenerateJob());
            //}

            //FunctionGenerator f = new FunctionGenerator()
            //{
            //    GenerateScalar = false,
            //    FunctionName = "shuffle",
            //    GenerateBoolean = true,
            //    GenerateFloatingPoint = true,
            //    GenerateInteger = true,
            //    GenerateMatrix = false,
            //    GenerateVector = true,
            //    ParameterNames = new string[] {"x", "idx"}
            //};
            //string result = f.GenerateFunctions();
            //
            //File.WriteAllText($"C:/testcode/Floating Point Classify.cs", result);
        }
    }
}
