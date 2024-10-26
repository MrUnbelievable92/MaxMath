using NUnit.Framework;
using System.Numerics;
using Unity.Mathematics;

using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    unsafe public static class f_avg
    {
        private static void TestByte(byte a, byte b, byte test)
        {
            Assert.AreEqual(test, (byte)((1 + a + b) / 2));
        }

        private static void TestUShort(ushort a, ushort b, ushort test)
        {
            Assert.AreEqual(test, (ushort)((1 + a + b) / 2));
        }

        private static void TestUInt(uint a, uint b, uint test)
        {
            Assert.AreEqual(test, (uint)(((ulong)1 + a + b) / 2));
        }

        private static void TestULong(ulong a, ulong b, ulong test)
        {
            Assert.AreEqual(test, (ulong)(((UInt128)1 + a + b) / 2));
        }

        private static void TestUInt128(UInt128 a, UInt128 b, UInt128 test)
        {
            Assert.AreEqual(test, (UInt128)(((BigInteger)1 + a + b) / 2));
        }

        private static void TestSByte(sbyte a, sbyte b, sbyte test)
        {
            Assert.AreEqual(test, (sbyte)((((a + b) > 0 ? 1 : -1) + a + b) / 2));
        }

        private static void TestShort(short a, short b, short test)
        {
            Assert.AreEqual(test, (short)((((a + b) > 0 ? 1 : -1) + a + b) / 2));
        }

        private static void TestInt(int a, int b, int test)
        {
            Assert.AreEqual(test, (int)(((((long)a + b) > 0 ? 1 : -1) + (long)a + b) / 2));
        }

        private static void TestLong(long a, long b, long test)
        {
            Assert.AreEqual(test, (long)(((((Int128)a + b) > 0 ? 1 : -1) + (Int128)a + b) / 2));
        }

        private static void TestInt128(Int128 a, Int128 b, Int128 test)
        {
            Assert.AreEqual(test, (Int128)(((((BigInteger)a + b) > 0 ? 1 : -1) + (BigInteger)a + b) / 2));
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 a = rng.NextUInt128();
                UInt128 b = rng.NextUInt128();

                TestUInt128(a, b, avg(a, b));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte a = rng.NextByte();
                byte b = rng.NextByte();

                TestByte(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 a = rng.NextByte2();
                byte2 b = rng.NextByte2();
                byte2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 a = rng.NextByte3();
                byte3 b = rng.NextByte3();
                byte3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 a = rng.NextByte4();
                byte4 b = rng.NextByte4();
                byte4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 a = rng.NextByte8();
                byte8 b = rng.NextByte8();
                byte8 result = avg(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 a = rng.NextByte16();
                byte16 b = rng.NextByte16();
                byte16 result = avg(a, b);

                for (int j = 0; j < 16; j++)
                {
                    TestByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 a = rng.NextByte32();
                byte32 b = rng.NextByte32();
                byte32 result = avg(a, b);

                for (int j = 0; j < 32; j++)
                {
                    TestByte(a[j], b[j], result[j]);
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort a = rng.NextUShort();
                ushort b = rng.NextUShort();

                TestUShort(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 a = rng.NextUShort2();
                ushort2 b = rng.NextUShort2();
                ushort2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestUShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 a = rng.NextUShort3();
                ushort3 b = rng.NextUShort3();
                ushort3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestUShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 a = rng.NextUShort4();
                ushort4 b = rng.NextUShort4();
                ushort4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestUShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 a = rng.NextUShort8();
                ushort8 b = rng.NextUShort8();
                ushort8 result = avg(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestUShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 a = rng.NextUShort16();
                ushort16 b = rng.NextUShort16();
                ushort16 result = avg(a, b);

                for (int j = 0; j < 16; j++)
                {
                    TestUShort(a[j], b[j], result[j]);
                }
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint a = rng.NextUInt();
                uint b = rng.NextUInt();

                TestUInt(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 a = rng.NextUInt2();
                uint2 b = rng.NextUInt2();
                uint2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestUInt(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 a = rng.NextUInt3();
                uint3 b = rng.NextUInt3();
                uint3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestUInt(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 a = rng.NextUInt4();
                uint4 b = rng.NextUInt4();
                uint4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestUInt(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 a = rng.NextUInt8();
                uint8 b = rng.NextUInt8();
                uint8 result = avg(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestUInt(a[j], b[j], result[j]);
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong a = rng.NextULong();
                ulong b = rng.NextULong();

                TestULong(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 a = rng.NextULong2();
                ulong2 b = rng.NextULong2();
                ulong2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestULong(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 a = rng.NextULong3();
                ulong3 b = rng.NextULong3();
                ulong3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestULong(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 a = rng.NextULong4();
                ulong4 b = rng.NextULong4();
                ulong4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestULong(a[j], b[j], result[j]);
                }
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                Int128 a = rng.NextInt128();
                Int128 b = rng.NextInt128();

                TestInt128(a, b, avg(a, b));
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte a = rng.NextSByte();
                sbyte b = rng.NextSByte();

                TestSByte(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 a = rng.NextSByte2();
                sbyte2 b = rng.NextSByte2();
                sbyte2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestSByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 a = rng.NextSByte3();
                sbyte3 b = rng.NextSByte3();
                sbyte3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestSByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 a = rng.NextSByte4();
                sbyte4 b = rng.NextSByte4();
                sbyte4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestSByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 a = rng.NextSByte8();
                sbyte8 b = rng.NextSByte8();
                sbyte8 result = avg(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestSByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 a = rng.NextSByte16();
                sbyte16 b = rng.NextSByte16();
                sbyte16 result = avg(a, b);

                for (int j = 0; j < 16; j++)
                {
                    TestSByte(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte32 a = rng.NextSByte32();
                sbyte32 b = rng.NextSByte32();
                sbyte32 result = avg(a, b);

                for (int j = 0; j < 32; j++)
                {
                    TestSByte(a[j], b[j], result[j]);
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short a = rng.NextShort();
                short b = rng.NextShort();

                TestShort(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short2 a = rng.NextShort2();
                short2 b = rng.NextShort2();
                short2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short3 a = rng.NextShort3();
                short3 b = rng.NextShort3();
                short3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short4 a = rng.NextShort4();
                short4 b = rng.NextShort4();
                short4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short8 a = rng.NextShort8();
                short8 b = rng.NextShort8();
                short8 result = avg(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestShort(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short16 a = rng.NextShort16();
                short16 b = rng.NextShort16();
                short16 result = avg(a, b);

                for (int j = 0; j < 16; j++)
                {
                    TestShort(a[j], b[j], result[j]);
                }
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int a = rng.NextInt();
                int b = rng.NextInt();

                TestInt(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int2 a = rng.NextInt2();
                int2 b = rng.NextInt2();
                int2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestInt(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int3 a = rng.NextInt3();
                int3 b = rng.NextInt3();
                int3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestInt(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int4 a = rng.NextInt4();
                int4 b = rng.NextInt4();
                int4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestInt(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int8 a = rng.NextInt8();
                int8 b = rng.NextInt8();
                int8 result = avg(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestInt(a[j], b[j], result[j]);
                }
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long a = rng.NextLong();
                long b = rng.NextLong();

                TestLong(a, b, avg(a, b));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long2 a = rng.NextLong2();
                long2 b = rng.NextLong2();
                long2 result = avg(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestLong(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long3 a = rng.NextLong3();
                long3 b = rng.NextLong3();
                long3 result = avg(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestLong(a[j], b[j], result[j]);
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long4 a = rng.NextLong4();
                long4 b = rng.NextLong4();
                long4 result = avg(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestLong(a[j], b[j], result[j]);
                }
            }
        }
    }
}