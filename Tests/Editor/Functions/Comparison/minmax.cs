using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_minmax
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte l = rng.NextByte();
                byte r = rng.NextByte();

                maxmath.minmax(l, r, out byte testmin, out byte testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte2 l = rng.NextByte2();
                byte2 r = rng.NextByte2();

                maxmath.minmax(l, r, out byte2 testmin, out byte2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte3 l = rng.NextByte3();
                byte3 r = rng.NextByte3();

                maxmath.minmax(l, r, out byte3 testmin, out byte3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte4 l = rng.NextByte4();
                byte4 r = rng.NextByte4();

                maxmath.minmax(l, r, out byte4 testmin, out byte4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte8 l = rng.NextByte8();
                byte8 r = rng.NextByte8();

                maxmath.minmax(l, r, out byte8 testmin, out byte8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte16 l = rng.NextByte16();
                byte16 r = rng.NextByte16();

                maxmath.minmax(l, r, out byte16 testmin, out byte16 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte32 l = rng.NextByte32();
                byte32 r = rng.NextByte32();

                maxmath.minmax(l, r, out byte32 testmin, out byte32 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }



        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte l = rng.NextSByte();
                sbyte r = rng.NextSByte();

                maxmath.minmax(l, r, out sbyte testmin, out sbyte testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2();

                maxmath.minmax(l, r, out sbyte2 testmin, out sbyte2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out sbyte3 testmin, out sbyte3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out sbyte4 testmin, out sbyte4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out sbyte8 testmin, out sbyte8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out sbyte16 testmin, out sbyte16 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out sbyte32 testmin, out sbyte32 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort l = rng.NextUShort();
                ushort r = rng.NextUShort();

                maxmath.minmax(l, r, out ushort testmin, out ushort testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort2 l = rng.NextUShort2();
                ushort2 r = rng.NextUShort2();

                maxmath.minmax(l, r, out ushort2 testmin, out ushort2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort3 l = rng.NextUShort3();
                ushort3 r = rng.NextUShort3();

                maxmath.minmax(l, r, out ushort3 testmin, out ushort3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort4 l = rng.NextUShort4();
                ushort4 r = rng.NextUShort4();

                maxmath.minmax(l, r, out ushort4 testmin, out ushort4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort8 l = rng.NextUShort8();
                ushort8 r = rng.NextUShort8();

                maxmath.minmax(l, r, out ushort8 testmin, out ushort8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort16 l = rng.NextUShort16();
                ushort16 r = rng.NextUShort16();

                maxmath.minmax(l, r, out ushort16 testmin, out ushort16 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short l = rng.NextShort();
                short r = rng.NextShort();

                maxmath.minmax(l, r, out short testmin, out short testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out short2 testmin, out short2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out short3 testmin, out short3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out short4 testmin, out short4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out short8 testmin, out short8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out short16 testmin, out short16 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint l = rng.NextUInt();
                uint r = rng.NextUInt();

                maxmath.minmax(l, r, out uint testmin, out uint testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint2 l = rng.NextUInt2();
                uint2 r = rng.NextUInt2();

                maxmath.minmax(l, r, out uint2 testmin, out uint2 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint3 l = rng.NextUInt3();
                uint3 r = rng.NextUInt3();

                maxmath.minmax(l, r, out uint3 testmin, out uint3 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint4 l = rng.NextUInt4();
                uint4 r = rng.NextUInt4();

                maxmath.minmax(l, r, out uint4 testmin, out uint4 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint8 l = rng.NextUInt8();
                uint8 r = rng.NextUInt8();

                maxmath.minmax(l, r, out uint8 testmin, out uint8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int l = rng.NextInt();
                int r = rng.NextInt();

                maxmath.minmax(l, r, out int testmin, out int testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
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

                maxmath.minmax(l, r, out int2 testmin, out int2 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
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

                maxmath.minmax(l, r, out int3 testmin, out int3 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
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

                maxmath.minmax(l, r, out int4 testmin, out int4 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
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

                maxmath.minmax(l, r, out int8 testmin, out int8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                ulong l = rng.NextULong();
                ulong r = rng.NextULong();

                maxmath.minmax(l, r, out ulong testmin, out ulong testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                ulong2 l = rng.NextULong2();
                ulong2 r = rng.NextULong2();

                maxmath.minmax(l, r, out ulong2 testmin, out ulong2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                ulong3 l = rng.NextULong3();
                ulong3 r = rng.NextULong3();

                maxmath.minmax(l, r, out ulong3 testmin, out ulong3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                ulong4 l = rng.NextULong4();
                ulong4 r = rng.NextULong4();

                maxmath.minmax(l, r, out ulong4 testmin, out ulong4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long l = rng.NextLong();
                long r = rng.NextLong();

                maxmath.minmax(l, r, out long testmin, out long testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
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

                maxmath.minmax(l, r, out long2 testmin, out long2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out long3 testmin, out long3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
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

                maxmath.minmax(l, r, out long4 testmin, out long4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (long i = 0; i < 8; i++)
            {
                UInt128 l = rng.NextUInt128();
                UInt128 r = rng.NextUInt128();

                maxmath.minmax(l, r, out UInt128 testmin, out UInt128 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (long i = 0; i < 8; i++)
            {
                Int128 l = rng.NextInt128();
                Int128 r = rng.NextInt128();

                maxmath.minmax(l, r, out Int128 testmin, out Int128 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float l = rng.NextFloat();
                float r = rng.NextFloat();

                maxmath.minmax(l, r, out float testmin, out float testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float2 l = rng.NextFloat2();
                float2 r = rng.NextFloat2();

                maxmath.minmax(l, r, out float2 testmin, out float2 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float3 l = rng.NextFloat3();
                float3 r = rng.NextFloat3();

                maxmath.minmax(l, r, out float3 testmin, out float3 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float4 l = rng.NextFloat4();
                float4 r = rng.NextFloat4();

                maxmath.minmax(l, r, out float4 testmin, out float4 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float8 l = rng.NextFloat8();
                float8 r = rng.NextFloat8();

                maxmath.minmax(l, r, out float8 testmin, out float8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double l = rng.NextDouble();
                double r = rng.NextDouble();

                maxmath.minmax(l, r, out double testmin, out double testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double2 l = rng.NextDouble2();
                double2 r = rng.NextDouble2();

                maxmath.minmax(l, r, out double2 testmin, out double2 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double3 l = rng.NextDouble3();
                double3 r = rng.NextDouble3();

                maxmath.minmax(l, r, out double3 testmin, out double3 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double4 l = rng.NextDouble4();
                double4 r = rng.NextDouble4();

                maxmath.minmax(l, r, out double4 testmin, out double4 testmax);

                Assert.AreEqual(testmin, math.min(l, r));
                Assert.AreEqual(testmax, math.max(l, r));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                quarter l = (quarter)rng.NextFloat();
                quarter r = (quarter)rng.NextFloat();

                maxmath.minmax(l, r, out quarter testmin, out quarter testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                quarter2 l = (quarter2)rng.NextFloat2();
                quarter2 r = (quarter2)rng.NextFloat2();

                maxmath.minmax(l, r, out quarter2 testmin, out quarter2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                quarter3 l = (quarter3)rng.NextFloat3();
                quarter3 r = (quarter3)rng.NextFloat3();

                maxmath.minmax(l, r, out quarter3 testmin, out quarter3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                quarter4 l = (quarter4)rng.NextFloat4();
                quarter4 r = (quarter4)rng.NextFloat4();

                maxmath.minmax(l, r, out quarter4 testmin, out quarter4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                quarter8 l = (quarter8)rng.NextFloat8();
                quarter8 r = (quarter8)rng.NextFloat8();

                maxmath.minmax(l, r, out quarter8 testmin, out quarter8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                half l = (half)rng.NextFloat();
                half r = (half)rng.NextFloat();

                maxmath.minmax(l, r, out half testmin, out half testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                half2 l = (half2)rng.NextFloat2();
                half2 r = (half2)rng.NextFloat2();

                maxmath.minmax(l, r, out half2 testmin, out half2 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                half3 l = (half3)rng.NextFloat3();
                half3 r = (half3)rng.NextFloat3();

                maxmath.minmax(l, r, out half3 testmin, out half3 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                half4 l = (half4)rng.NextFloat4();
                half4 r = (half4)rng.NextFloat4();

                maxmath.minmax(l, r, out half4 testmin, out half4 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                half8 l = (half8)rng.NextFloat8();
                half8 r = (half8)rng.NextFloat8();

                maxmath.minmax(l, r, out half8 testmin, out half8 testmax);

                Assert.AreEqual(testmin, maxmath.min(l, r));
                Assert.AreEqual(testmax, maxmath.max(l, r));
            }
        }
    }
}
