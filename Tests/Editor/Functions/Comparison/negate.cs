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

            for (int i = 0; i < Tests.Float2.NUM_TESTS; i++)
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


        [Test]
        public static void SByte2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.SByte2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                sbyte2 a = maxmath.negate(Tests.SByte2.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.SByte2.TestData_LHS[i], -Tests.SByte2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.SByte3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                sbyte3 a = maxmath.negate(Tests.SByte3.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.SByte3.TestData_LHS[i], -Tests.SByte3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.SByte4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                sbyte4 a = maxmath.negate(Tests.SByte4.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.SByte4.TestData_LHS[i], -Tests.SByte4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.SByte8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                sbyte8 a = maxmath.negate(Tests.SByte8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.SByte8.TestData_LHS[i], -Tests.SByte8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.SByte16.NUM_TESTS; i++)
            {
                bool16 b = x.NextBool16();
                sbyte16 a = maxmath.negate(Tests.SByte16.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.SByte16.TestData_LHS[i], -Tests.SByte16.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                bool32 b = x.NextBool32();
                sbyte32 a = maxmath.negate(Tests.SByte32.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.SByte32.TestData_LHS[i], -Tests.SByte32.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                short2 a = maxmath.negate(Tests.Short2.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.Short2.TestData_LHS[i], -Tests.Short2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                short3 a = maxmath.negate(Tests.Short3.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.Short3.TestData_LHS[i], -Tests.Short3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                short4 a = maxmath.negate(Tests.Short4.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.Short4.TestData_LHS[i], -Tests.Short4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                short8 a = maxmath.negate(Tests.Short8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.Short8.TestData_LHS[i], -Tests.Short8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                bool16 b = x.NextBool16();
                short16 a = maxmath.negate(Tests.Short16.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.Short16.TestData_LHS[i], -Tests.Short16.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Int2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                int2 a = maxmath.negate(Tests.Int2.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Int2.TestData_LHS[i], -Tests.Int2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Int3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                int3 a = maxmath.negate(Tests.Int3.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Int3.TestData_LHS[i], -Tests.Int3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Int4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                int4 a = maxmath.negate(Tests.Int4.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.Int4.TestData_LHS[i], -Tests.Int4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                int8 a = maxmath.negate(Tests.Int8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.Int8.TestData_LHS[i], -Tests.Int8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                long2 a = maxmath.negate(Tests.Long2.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.Long2.TestData_LHS[i], -Tests.Long2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (long i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                long3 a = maxmath.negate(Tests.Long3.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.Long3.TestData_LHS[i], -Tests.Long3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (long i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                long4 a = maxmath.negate(Tests.Long4.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.Long4.TestData_LHS[i], -Tests.Long4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }
    }
}