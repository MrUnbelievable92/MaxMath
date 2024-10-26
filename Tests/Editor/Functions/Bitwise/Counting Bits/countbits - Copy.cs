using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;
using static Unity.Mathematics.math;

namespace MaxMath.Tests
{
    unsafe public static class f_parityodd
    {
        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 test = rng.NextUInt128();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte test = rng.NextByte();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 test = rng.NextByte2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 test = rng.NextByte3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 test = rng.NextByte4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 test = rng.NextByte8();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 test = rng.NextByte16();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 test = rng.NextByte32();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort test = rng.NextUShort();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 test = rng.NextUShort2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 test = rng.NextUShort3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 test = rng.NextUShort4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 test = rng.NextUShort8();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 test = rng.NextUShort16();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint test = rng.NextUInt();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 test = rng.NextUInt2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 test = rng.NextUInt3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 test = rng.NextUInt4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 test = rng.NextUInt8();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong test = rng.NextULong();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 test = rng.NextULong2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 test = rng.NextULong3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 test = rng.NextULong4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }
        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                Int128 test = rng.NextInt128();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte test = rng.NextSByte();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 test = rng.NextSByte2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 test = rng.NextSByte3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 test = rng.NextSByte4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 test = rng.NextSByte8();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 test = rng.NextSByte16();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte32 test = rng.NextSByte32();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short test = rng.NextShort();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short2 test = rng.NextShort2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short3 test = rng.NextShort3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short4 test = rng.NextShort4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short8 test = rng.NextShort8();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short16 test = rng.NextShort16();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int test = rng.NextInt();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int2 test = rng.NextInt2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int3 test = rng.NextInt3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int4 test = rng.NextInt4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int8 test = rng.NextInt8();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long test = rng.NextLong();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long2 test = rng.NextLong2();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long3 test = rng.NextLong3();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long4 test = rng.NextLong4();

                Assert.AreEqual(parityodd(test), (countbits(test) & 1) == 1);
            }
        }
    }


    unsafe public static class f_parityeven
    {
        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 test = rng.NextUInt128();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte test = rng.NextByte();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 test = rng.NextByte2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 test = rng.NextByte3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 test = rng.NextByte4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 test = rng.NextByte8();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 test = rng.NextByte16();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 test = rng.NextByte32();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort test = rng.NextUShort();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 test = rng.NextUShort2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 test = rng.NextUShort3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 test = rng.NextUShort4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 test = rng.NextUShort8();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 test = rng.NextUShort16();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint test = rng.NextUInt();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 test = rng.NextUInt2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 test = rng.NextUInt3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 test = rng.NextUInt4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 test = rng.NextUInt8();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong test = rng.NextULong();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 test = rng.NextULong2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 test = rng.NextULong3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 test = rng.NextULong4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }
        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                Int128 test = rng.NextInt128();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte test = rng.NextSByte();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 test = rng.NextSByte2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 test = rng.NextSByte3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 test = rng.NextSByte4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 test = rng.NextSByte8();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 test = rng.NextSByte16();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte32 test = rng.NextSByte32();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short test = rng.NextShort();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short2 test = rng.NextShort2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short3 test = rng.NextShort3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short4 test = rng.NextShort4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short8 test = rng.NextShort8();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short16 test = rng.NextShort16();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int test = rng.NextInt();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int2 test = rng.NextInt2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int3 test = rng.NextInt3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int4 test = rng.NextInt4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int8 test = rng.NextInt8();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long test = rng.NextLong();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long2 test = rng.NextLong2();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long3 test = rng.NextLong3();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long4 test = rng.NextLong4();

                Assert.AreEqual(parityeven(test), (countbits(test) & 1) == 0);
            }
        }
    }
}
