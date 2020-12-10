using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class negate
    {
        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Float()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                bool b = x.NextBool();
                float a = maxmath.negate(Tests.Float8.TestData_LHS[i].x0, b);

                result &= a == (b ? -Tests.Float8.TestData_LHS[i].x0 : Tests.Float8.TestData_LHS[i].x0);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Float2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                float2 a = maxmath.negate(Tests.Float2.TestData[i], b);

                result &= math.all(a == (math.select(Tests.Float2.TestData[i], -Tests.Float2.TestData[i], b)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Float3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                float3 a = maxmath.negate(Tests.Float3.TestData[i], b);

                result &= math.all(a == (math.select(Tests.Float3.TestData[i], -Tests.Float3.TestData[i], b)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Float4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                float4 a = maxmath.negate(Tests.Float4.TestData[i], b);

                result &= math.all(a == (math.select(Tests.Float4.TestData[i], -Tests.Float4.TestData[i], b)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Float8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                bool4x2 b = x.NextBool4x2();
                float8 a = maxmath.negate(Tests.Float8.TestData_LHS[i], b);

                result &= a.Equals(maxmath.select(Tests.Float8.TestData_LHS[i], -Tests.Float8.TestData_LHS[i], b));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Double()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double4.NUM_TESTS; i++)
            {
                bool b = x.NextBool();
                double a = maxmath.negate(Tests.Double4.TestData[i].x, b);

                result &= a == (b ? -Tests.Double4.TestData[i].x : Tests.Double4.TestData[i].x);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Double2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                double2 a = maxmath.negate(Tests.Double2.TestData[i], b);

                result &= math.all(a == (math.select(Tests.Double2.TestData[i], -Tests.Double2.TestData[i], b)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Double3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                double3 a = maxmath.negate(Tests.Double3.TestData[i], b);

                result &= math.all(a == (math.select(Tests.Double3.TestData[i], -Tests.Double3.TestData[i], b)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ConditionallyNegate")]
        public static bool Double4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                double4 a = maxmath.negate(Tests.Double4.TestData[i], b);

                result &= math.all(a == (math.select(Tests.Double4.TestData[i], -Tests.Double4.TestData[i], b)));
            }

            return result;
        }
    }
}