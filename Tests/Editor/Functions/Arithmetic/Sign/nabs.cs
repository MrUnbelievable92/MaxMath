using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    unsafe public static class f_nabs
    {
        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 16; i++)
            {
                Int128 test = rng.NextInt128();

                Assert.AreEqual(nabs(test), test > 0 ? -test : test);
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte test = rng.NextSByte();

                Assert.AreEqual(nabs(test), test > 0 ? -test : test);
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte2 original = rng.NextSByte2();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3 original = rng.NextSByte3();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4 original = rng.NextSByte4();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte8 original = rng.NextSByte8();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte16 original = rng.NextSByte16();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte32 original = rng.NextSByte32();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short test = rng.NextShort();

                Assert.AreEqual(nabs(test), test > 0 ? -test : test);
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2 original = rng.NextShort2();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3 original = rng.NextShort3();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4 original = rng.NextShort4();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short8 original = rng.NextShort8();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short16 original = rng.NextShort16();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int test = rng.NextInt();

                Assert.AreEqual(nabs(test), test > 0 ? -test : test);
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2 original = rng.NextInt2();

                Assert.AreEqual(nabs(original), math.select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int3 original = rng.NextInt3();

                Assert.AreEqual(nabs(original), math.select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int4 original = rng.NextInt4();

                Assert.AreEqual(nabs(original), math.select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int8 original = rng.NextInt8();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long test = rng.NextLong();

                Assert.AreEqual(nabs(test), test > 0 ? -test : test);
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2 original = rng.NextLong2();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3 original = rng.NextLong3();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4 original = rng.NextLong4();

                Assert.AreEqual(nabs(original), select(original, -original, original > 0));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter test = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(nabs(test), (quarter)(test > 0 ? -test : test));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter2 test = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(nabs(test), select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter3 test = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(nabs(test), select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter4 test = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(nabs(test), select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter8 test = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual(nabs(test), select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter16 test = new quarter16((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                Assert.AreEqual(nabs(test), select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _quarter32()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter32 test = new quarter32((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                Assert.AreEqual(nabs(test), select(test, -test, test > 0));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half test = (half)rng.NextFloat();

                Assert.AreEqual(nabs(test), (half)(test > 0 ? -test : test));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half2 test = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);

                Assert.AreEqual(nabs(test), select(test, (half2)(-(float2)test), (float2)test > 0));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half3 test = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);

                Assert.AreEqual(nabs(test), select(test, (half3)(-(float3)test), (float3)test > 0));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half4 test = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);

                Assert.AreEqual(nabs(test), select(test, (half4)(-(float4)test), (float4)test > 0));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half8 test = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);

                Assert.AreEqual(nabs(test), select(test, (half8)(-(float8)test), (float8)test > 0));
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half16 test = new half16((half8)rng.NextFloat8(half.MinValue, half.MaxValue), (half8)rng.NextFloat8(half.MinValue, half.MaxValue));

                Assert.AreEqual(nabs(test), select(test, new half16((half8)(-(float8)test.v8_0), (half8)(-(float8)test.v8_8)), new bool16((float8)test.v8_0 > 0, (float8)test.v8_8 > 0)));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float test = rng.NextFloat();

                Assert.AreEqual(nabs(test), test > 0 ? -test : test);
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2 test = rng.NextFloat2(float.MinValue / 2, float.MaxValue / 2);

                Assert.AreEqual(nabs(test), math.select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3 test = rng.NextFloat3(float.MinValue / 2, float.MaxValue / 2);

                Assert.AreEqual(nabs(test), math.select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4 test = rng.NextFloat4(float.MinValue / 2, float.MaxValue / 2);

                Assert.AreEqual(nabs(test), math.select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float8 test = rng.NextFloat8(float.MinValue / 2, float.MaxValue / 2);

                Assert.AreEqual(nabs(test), select(test, -test, test > 0));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double test = rng.NextDouble();

                Assert.AreEqual(nabs(test), test > 0 ? -test : test);
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2 test = rng.NextDouble2(double.MinValue / 2, double.MaxValue / 2);

                Assert.AreEqual(nabs(test), math.select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3 test = rng.NextDouble3(double.MinValue / 2, double.MaxValue / 2);

                Assert.AreEqual(nabs(test), math.select(test, -test, test > 0));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4 test = rng.NextDouble4(double.MinValue / 2, double.MaxValue / 2);

                Assert.AreEqual(nabs(test), math.select(test, -test, test > 0));
            }
        }
    }
}