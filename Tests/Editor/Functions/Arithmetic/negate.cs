using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class negate
    {
        [Test]
        public static void Float()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                bool b = x.NextBool();
                float a = maxmath.negate(Tests.Float8.TestData_LHS[i].x0, b);

                result &= a == (b ? -Tests.Float8.TestData_LHS[i].x0 : Tests.Float8.TestData_LHS[i].x0);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                float2 a = maxmath.negate(Tests.Float2.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Float2.TestData_LHS[i], -Tests.Float2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                float3 a = maxmath.negate(Tests.Float3.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Float3.TestData_LHS[i], -Tests.Float3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Float4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                float4 a = maxmath.negate(Tests.Float4.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Float4.TestData_LHS[i], -Tests.Float4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                float8 a = maxmath.negate(Tests.Float8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.Float8.TestData_LHS[i], -Tests.Float8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Double()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double4.NUM_TESTS; i++)
            {
                bool b = x.NextBool();
                double a = maxmath.negate(Tests.Double4.TestData_LHS[i].x, b);

                result &= a == (b ? -Tests.Double4.TestData_LHS[i].x : Tests.Double4.TestData_LHS[i].x);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Double2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                double2 a = maxmath.negate(Tests.Double2.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Double2.TestData_LHS[i], -Tests.Double2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Double3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                double3 a = maxmath.negate(Tests.Double3.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Double3.TestData_LHS[i], -Tests.Double3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Double4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Double4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                double4 a = maxmath.negate(Tests.Double4.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Double4.TestData_LHS[i], -Tests.Double4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }
    }
}