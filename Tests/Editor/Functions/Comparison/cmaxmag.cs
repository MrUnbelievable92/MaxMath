using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class cmaxmag
    {
        [Test]
        public static void SByte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void SByte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void SByte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void SByte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void SByte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void SByte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void Short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void Short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void Short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void Short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void Short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        
        [Test]
        public static void Int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void Long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void Long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        [Test]
        public static void Long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }

        
        [Test]
        public static void Float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float2 l = rng.NextFloat2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float3 l = rng.NextFloat3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float4 l = rng.NextFloat4();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float8 l = rng.NextFloat8();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(maxmath.cmin(l), maxmath.cmax(l)));
            }
        }


        [Test]
        public static void Double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double2 l = rng.NextDouble2();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double3 l = rng.NextDouble3();

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.maxmag(math.cmin(l), math.cmax(l)));
            }
        }

        [Test]
        public static void Double4()
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