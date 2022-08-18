using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class minmaxmag
    {
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2();

                maxmath.minmaxmag(l, r, out sbyte2 testmin, out sbyte2 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3();

                maxmath.minmaxmag(l, r, out sbyte3 testmin, out sbyte3 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4();

                maxmath.minmaxmag(l, r, out sbyte4 testmin, out sbyte4 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
        
        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8();

                maxmath.minmaxmag(l, r, out sbyte8 testmin, out sbyte8 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
        
        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16();

                maxmath.minmaxmag(l, r, out sbyte16 testmin, out sbyte16 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
        
        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32();

                maxmath.minmaxmag(l, r, out sbyte32 testmin, out sbyte32 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2();

                maxmath.minmaxmag(l, r, out short2 testmin, out short2 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3();

                maxmath.minmaxmag(l, r, out short3 testmin, out short3 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4();

                maxmath.minmaxmag(l, r, out short4 testmin, out short4 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
        
        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8();

                maxmath.minmaxmag(l, r, out short8 testmin, out short8 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
        
        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16();

                maxmath.minmaxmag(l, r, out short16 testmin, out short16 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2();

                maxmath.minmaxmag(l, r, out int2 testmin, out int2 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3();

                maxmath.minmaxmag(l, r, out int3 testmin, out int3 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4();

                maxmath.minmaxmag(l, r, out int4 testmin, out int4 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
        
        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8();

                maxmath.minmaxmag(l, r, out int8 testmin, out int8 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2();

                maxmath.minmaxmag(l, r, out long2 testmin, out long2 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3();

                maxmath.minmaxmag(l, r, out long3 testmin, out long3 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4();

                maxmath.minmaxmag(l, r, out long4 testmin, out long4 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        
        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float2 l = rng.NextFloat2();
                float2 r = rng.NextFloat2();

                maxmath.minmaxmag(l, r, out float2 testmin, out float2 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float3 l = rng.NextFloat3();
                float3 r = rng.NextFloat3();

                maxmath.minmaxmag(l, r, out float3 testmin, out float3 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float4 l = rng.NextFloat4();
                float4 r = rng.NextFloat4();

                maxmath.minmaxmag(l, r, out float4 testmin, out float4 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
        
        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float8 l = rng.NextFloat8();
                float8 r = rng.NextFloat8();

                maxmath.minmaxmag(l, r, out float8 testmin, out float8 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double2 l = rng.NextDouble2();
                double2 r = rng.NextDouble2();

                maxmath.minmaxmag(l, r, out double2 testmin, out double2 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double3 l = rng.NextDouble3();
                double3 r = rng.NextDouble3();

                maxmath.minmaxmag(l, r, out double3 testmin, out double3 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double4 l = rng.NextDouble4();
                double4 r = rng.NextDouble4();

                maxmath.minmaxmag(l, r, out double4 testmin, out double4 testmax);

                Assert.AreEqual(testmin, maxmath.minmag(l, r));
                Assert.AreEqual(testmax, maxmath.maxmag(l, r));
            }
        }
    }
}
