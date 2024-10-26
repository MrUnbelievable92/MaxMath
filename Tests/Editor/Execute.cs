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
            (((bitmask32((uint)quarter.MANTISSA_BITS + 1) << (F32_MANTISSA_BITS - (quarter.MANTISSA_BITS + 1))) | (((-F32_EXPONENT_BIAS + quarter.MAX_UNBIASED_EXPONENT) & bitmask32((uint)F32_EXPONENT_BITS)) << F32_MANTISSA_BITS)) - 1).Log();
            asfloat(((bitmask32((uint)quarter.MANTISSA_BITS + 1) << (F32_MANTISSA_BITS - (quarter.MANTISSA_BITS + 1))) | (((-F32_EXPONENT_BIAS + quarter.MAX_UNBIASED_EXPONENT) & bitmask32((uint)F32_EXPONENT_BITS)) << F32_MANTISSA_BITS)) - 1).Log();
            ////foreach (TestJobGenerator job in TestJobGenerator.GenerateAllJobs())
            ////{
            ////    File.WriteAllText($"E:/testcode/{ job.Type }.cs", job.GenerateJob());
            ////}
            //
            //FunctionGenerator f = new FunctionGenerator()
            //{
            //    GenerateScalar = false,
            //    FunctionName = "isnormal",
            //    GenerateBoolean = false,
            //    GenerateFloatingPoint = true,
            //    GenerateInteger = false,
            //    GenerateMatrix = false,
            //    GenerateVector = true,
            //    ParameterNames = new string[] {"x"}
            //};
            //FunctionGenerator i = new FunctionGenerator()
            //{
            //    GenerateScalar = false,
            //    FunctionName = "issubnormal",
            //    GenerateBoolean = false,
            //    GenerateFloatingPoint = true,
            //    GenerateInteger = false,
            //    GenerateMatrix = false,
            //    GenerateVector = true,
            //    ParameterNames = new string[] {"x"}
            //};
            //
            //string result = f.GenerateFunctions() + "\n" + i.GenerateFunctions();
            //
            //File.WriteAllText($"E:/testcode/hypot.cs", result);
        }
    }
}
