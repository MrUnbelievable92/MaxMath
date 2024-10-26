using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_cmaxmag
    {
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float2 l = rng.NextFloat2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float3 l = rng.NextFloat3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float4 l = rng.NextFloat4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float8 l = rng.NextFloat8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double2 l = rng.NextDouble2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double3 l = rng.NextDouble3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double4 l = rng.NextDouble4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }
    }
}