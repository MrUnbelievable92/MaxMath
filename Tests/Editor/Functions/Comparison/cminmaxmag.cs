using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class cminmaxmag
    {
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();

                maxmath.cminmaxmag(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();

                maxmath.cminmaxmag(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();

                maxmath.cminmaxmag(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
        
        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();

                maxmath.cminmaxmag(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
        
        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();

                maxmath.cminmaxmag(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
        
        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();

                maxmath.cminmaxmag(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();

                maxmath.cminmaxmag(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();

                maxmath.cminmaxmag(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();

                maxmath.cminmaxmag(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
        
        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();

                maxmath.cminmaxmag(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
        
        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();

                maxmath.cminmaxmag(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();

                maxmath.cminmaxmag(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();

                maxmath.cminmaxmag(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();

                maxmath.cminmaxmag(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
        
        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();

                maxmath.cminmaxmag(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();

                maxmath.cminmaxmag(l, out long testmin, out long testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();

                maxmath.cminmaxmag(l, out long testmin, out long testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();

                maxmath.cminmaxmag(l, out long testmin, out long testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        
        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float2 l = rng.NextFloat2();

                maxmath.cminmaxmag(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float3 l = rng.NextFloat3();

                maxmath.cminmaxmag(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float4 l = rng.NextFloat4();

                maxmath.cminmaxmag(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
        
        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float8 l = rng.NextFloat8();

                maxmath.cminmaxmag(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double2 l = rng.NextDouble2();

                maxmath.cminmaxmag(l, out double testmin, out double testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double3 l = rng.NextDouble3();

                maxmath.cminmaxmag(l, out double testmin, out double testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double4 l = rng.NextDouble4();

                maxmath.cminmaxmag(l, out double testmin, out double testmax);

                Assert.AreEqual(testmin, maxmath.cminmag(l));
                Assert.AreEqual(testmax, maxmath.cmaxmag(l));
            }
        }
    }
}
