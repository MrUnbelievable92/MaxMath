using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class cminmax
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte2 l = rng.NextByte2();

                maxmath.cminmax(l, out byte testmin, out byte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte3 l = rng.NextByte3();

                maxmath.cminmax(l, out byte testmin, out byte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte4 l = rng.NextByte4();

                maxmath.cminmax(l, out byte testmin, out byte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte8 l = rng.NextByte8();

                maxmath.cminmax(l, out byte testmin, out byte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte16 l = rng.NextByte16();

                maxmath.cminmax(l, out byte testmin, out byte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte32 l = rng.NextByte32();

                maxmath.cminmax(l, out byte testmin, out byte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }


        
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();

                maxmath.cminmax(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();

                maxmath.cminmax(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();

                maxmath.cminmax(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();

                maxmath.cminmax(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();

                maxmath.cminmax(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();

                maxmath.cminmax(l, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort2 l = rng.NextUShort2();

                maxmath.cminmax(l, out ushort testmin, out ushort testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort3 l = rng.NextUShort3();

                maxmath.cminmax(l, out ushort testmin, out ushort testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort4 l = rng.NextUShort4();

                maxmath.cminmax(l, out ushort testmin, out ushort testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort8 l = rng.NextUShort8();

                maxmath.cminmax(l, out ushort testmin, out ushort testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort16 l = rng.NextUShort16();

                maxmath.cminmax(l, out ushort testmin, out ushort testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();

                maxmath.cminmax(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();

                maxmath.cminmax(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();

                maxmath.cminmax(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();

                maxmath.cminmax(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        
        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();

                maxmath.cminmax(l, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint2 l = rng.NextUInt2();

                maxmath.cminmax(l, out uint testmin, out uint testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint3 l = rng.NextUInt3();

                maxmath.cminmax(l, out uint testmin, out uint testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint4 l = rng.NextUInt4();

                maxmath.cminmax(l, out uint testmin, out uint testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }
        
        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint8 l = rng.NextUInt8();

                maxmath.cminmax(l, out uint testmin, out uint testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();

                maxmath.cminmax(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();

                maxmath.cminmax(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();

                maxmath.cminmax(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }
        
        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();

                maxmath.cminmax(l, out int testmin, out int testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                ulong2 l = rng.NextULong2();

                maxmath.cminmax(l, out ulong testmin, out ulong testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                ulong3 l = rng.NextULong3();

                maxmath.cminmax(l, out ulong testmin, out ulong testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                ulong4 l = rng.NextULong4();

                maxmath.cminmax(l, out ulong testmin, out ulong testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }
        

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();

                maxmath.cminmax(l, out long testmin, out long testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();

                maxmath.cminmax(l, out long testmin, out long testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();

                maxmath.cminmax(l, out long testmin, out long testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }

        
        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float2 l = rng.NextFloat2();

                maxmath.cminmax(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float3 l = rng.NextFloat3();

                maxmath.cminmax(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float4 l = rng.NextFloat4();

                maxmath.cminmax(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }
        
        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 8; i++)
            {
                float8 l = rng.NextFloat8();

                maxmath.cminmax(l, out float testmin, out float testmax);

                Assert.AreEqual(testmin, maxmath.cmin(l));
                Assert.AreEqual(testmax, maxmath.cmax(l));
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double2 l = rng.NextDouble2();

                maxmath.cminmax(l, out double testmin, out double testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double3 l = rng.NextDouble3();

                maxmath.cminmax(l, out double testmin, out double testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 8; i++)
            {
                double4 l = rng.NextDouble4();

                maxmath.cminmax(l, out double testmin, out double testmax);

                Assert.AreEqual(testmin, math.cmin(l));
                Assert.AreEqual(testmax, math.cmax(l));
            }
        }
    }
}
