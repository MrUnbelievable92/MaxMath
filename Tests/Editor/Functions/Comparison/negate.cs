using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class negate
    {
        [Test]
        public static void Int128()
        {
            bool result = true;
            Random128 x = new Random128(47);

            for (int i = 0; i < 100; i++)
            {
                bool b = x.NextBool();
                Int128 __int = x.NextInt128();

                Int128 a = maxmath.negate(__int, b);

                result &= a == (b ? -__int : __int);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Float()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__float8.NUM_TESTS; i++)
            {
                bool b = x.NextBool();
                float a = maxmath.negate(Tests.__float8.TestData_LHS[i].x0, b);

                result &= a == (b ? -Tests.__float8.TestData_LHS[i].x0 : Tests.__float8.TestData_LHS[i].x0);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__float2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                float2 a = maxmath.negate(Tests.__float2.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__float2.TestData_LHS[i], -Tests.__float2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__float3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                float3 a = maxmath.negate(Tests.__float3.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__float3.TestData_LHS[i], -Tests.__float3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__float4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                float4 a = maxmath.negate(Tests.__float4.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__float4.TestData_LHS[i], -Tests.__float4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Float8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.__float8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                float8 a = maxmath.negate(Tests.__float8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.__float8.TestData_LHS[i], -Tests.__float8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Double()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__double4.NUM_TESTS; i++)
            {
                bool b = x.NextBool();
                double a = maxmath.negate(Tests.__double4.TestData_LHS[i].x, b);

                result &= a == (b ? -Tests.__double4.TestData_LHS[i].x : Tests.__double4.TestData_LHS[i].x);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Double2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__double2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                double2 a = maxmath.negate(Tests.__double2.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__double2.TestData_LHS[i], -Tests.__double2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Double3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__double3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                double3 a = maxmath.negate(Tests.__double3.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__double3.TestData_LHS[i], -Tests.__double3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Double4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__double4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                double4 a = maxmath.negate(Tests.__double4.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__double4.TestData_LHS[i], -Tests.__double4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__sbyte2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                sbyte2 a = maxmath.negate(Tests.__sbyte2.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__sbyte2.TestData_LHS[i], -Tests.__sbyte2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__sbyte3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                sbyte3 a = maxmath.negate(Tests.__sbyte3.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__sbyte3.TestData_LHS[i], -Tests.__sbyte3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__sbyte4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                sbyte4 a = maxmath.negate(Tests.__sbyte4.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__sbyte4.TestData_LHS[i], -Tests.__sbyte4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.__sbyte8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                sbyte8 a = maxmath.negate(Tests.__sbyte8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.__sbyte8.TestData_LHS[i], -Tests.__sbyte8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.__sbyte16.NUM_TESTS; i++)
            {
                bool16 b = x.NextBool16();
                sbyte16 a = maxmath.negate(Tests.__sbyte16.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.__sbyte16.TestData_LHS[i], -Tests.__sbyte16.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.__sbyte32.NUM_TESTS; i++)
            {
                bool32 b = x.NextBool32();
                sbyte32 a = maxmath.negate(Tests.__sbyte32.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.__sbyte32.TestData_LHS[i], -Tests.__sbyte32.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__short2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                short2 a = maxmath.negate(Tests.__short2.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__short2.TestData_LHS[i], -Tests.__short2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__short3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                short3 a = maxmath.negate(Tests.__short3.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__short3.TestData_LHS[i], -Tests.__short3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__short4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                short4 a = maxmath.negate(Tests.__short4.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__short4.TestData_LHS[i], -Tests.__short4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.__short8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                short8 a = maxmath.negate(Tests.__short8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.__short8.TestData_LHS[i], -Tests.__short8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.__short16.NUM_TESTS; i++)
            {
                bool16 b = x.NextBool16();
                short16 a = maxmath.negate(Tests.__short16.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.__short16.TestData_LHS[i], -Tests.__short16.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__int2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                int2 a = maxmath.negate(Tests.__int2.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__int2.TestData_LHS[i], -Tests.__int2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__int3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                int3 a = maxmath.negate(Tests.__int3.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__int3.TestData_LHS[i], -Tests.__int3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__int4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                int4 a = maxmath.negate(Tests.__int4.TestData_LHS[i], b);

                result &= math.all(a == (math.select(Tests.__int4.TestData_LHS[i], -Tests.__int4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int8()
        {
            bool result = true;
            Random64 x = new Random64(47);

            for (int i = 0; i < Tests.__int8.NUM_TESTS; i++)
            {
                bool8 b = x.NextBool8();
                int8 a = maxmath.negate(Tests.__int8.TestData_LHS[i], b);

                result &= maxmath.all(a == maxmath.select(Tests.__int8.TestData_LHS[i], -Tests.__int8.TestData_LHS[i], b));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__long2.NUM_TESTS; i++)
            {
                bool2 b = x.NextBool2();
                long2 a = maxmath.negate(Tests.__long2.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__long2.TestData_LHS[i], -Tests.__long2.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (long i = 0; i < Tests.__long3.NUM_TESTS; i++)
            {
                bool3 b = x.NextBool3();
                long3 a = maxmath.negate(Tests.__long3.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__long3.TestData_LHS[i], -Tests.__long3.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (long i = 0; i < Tests.__long4.NUM_TESTS; i++)
            {
                bool4 b = x.NextBool4();
                long4 a = maxmath.negate(Tests.__long4.TestData_LHS[i], b);

                result &= math.all(a == (maxmath.select(Tests.__long4.TestData_LHS[i], -Tests.__long4.TestData_LHS[i], b)));
            }

            Assert.AreEqual(true, result);
        }
    }
}