using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    unsafe public static class f_bitmask8
    {
        private static void TestByte(byte result, byte numBits, byte index)
        {
            uint i = 0;

            while (i < index)
            {
                Assert.IsFalse(testbit(result, i++));
            }
            for (uint j = 0; j < numBits; j++)
            {
                Assert.IsTrue(testbit(result, i++));
            }
            while (i < 8)
            {
                Assert.IsFalse(testbit(result, i++));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte index = rng.NextByte(0, 8);
                byte numBits = rng.NextByte(0, (byte)(1 + 8 - index));
                byte result = bitmask8((uint)numBits, (uint)index);

                TestByte(result, numBits, index);
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 index = rng.NextByte2(0, 8);
                byte2 numBits = rng.NextByte2(0, 1 + 8 - index);
                byte2 result = bitmask8(numBits, index);

                for (int j = 0; j < 2; j++)
                {
                    TestByte(result[j], numBits[j], index[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 index = rng.NextByte3(0, 8);
                byte3 numBits = rng.NextByte3(0, 1 + 8 - index);
                byte3 result = bitmask8(numBits, index);

                for (int j = 0; j < 3; j++)
                {
                    TestByte(result[j], numBits[j], index[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 index = rng.NextByte4(0, 8);
                byte4 numBits = rng.NextByte4(0, 1 + 8 - index);
                byte4 result = bitmask8(numBits, index);

                for (int j = 0; j < 4; j++)
                {
                    TestByte(result[j], numBits[j], index[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 index = rng.NextByte8(0, 8);
                byte8 numBits = rng.NextByte8(0, 1 + 8 - index);
                byte8 result = bitmask8(numBits, index);

                for (int j = 0; j < 8; j++)
                {
                    TestByte(result[j], numBits[j], index[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 index = rng.NextByte16(0, 8);
                byte16 numBits = rng.NextByte16(0, 1 + 8 - index);
                byte16 result = bitmask8(numBits, index);

                for (int j = 0; j < 16; j++)
                {
                    TestByte(result[j], numBits[j], index[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 index = rng.NextByte32(0, 8);
                byte32 numBits = rng.NextByte32(0, 1 + 8 - index);
                byte32 result = bitmask8(numBits, index);

                for (int j = 0; j < 32; j++)
                {
                    TestByte(result[j], numBits[j], index[j]);
                }
            }
        }
    }

    unsafe public static class f_bitmask16
    {
        private static void TestUShort(ushort result, byte numBits, byte index)
        {
            uint i = 0;

            while (i < index)
            {
                Assert.IsFalse(testbit(result, i++));
            }
            for (uint j = 0; j < numBits; j++)
            {
                Assert.IsTrue(testbit(result, i++));
            }
            while (i < 16)
            {
                Assert.IsFalse(testbit(result, i++));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte index = rng.NextByte(0, 16);
                byte numBits = rng.NextByte(0, (byte)(1 + 16 - index));
                ushort result = bitmask16((uint)numBits, (uint)index);

                TestUShort(result, numBits, index);
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 index = rng.NextUShort2(0, 16);
                ushort2 numBits = rng.NextUShort2(0, 1 + 16 - index);
                ushort2 result = bitmask16(numBits, index);

                for (int j = 0; j < 2; j++)
                {
                    TestUShort(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 index = rng.NextUShort3(0, 16);
                ushort3 numBits = rng.NextUShort3(0, 1 + 16 - index);
                ushort3 result = bitmask16(numBits, index);

                for (int j = 0; j < 3; j++)
                {
                    TestUShort(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 index = rng.NextUShort4(0, 16);
                ushort4 numBits = rng.NextUShort4(0, 1 + 16 - index);
                ushort4 result = bitmask16(numBits, index);

                for (int j = 0; j < 4; j++)
                {
                    TestUShort(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 index = rng.NextUShort8(0, 16);
                ushort8 numBits = rng.NextUShort8(0, 1 + 16 - index);
                ushort8 result = bitmask16(numBits, index);

                for (int j = 0; j < 8; j++)
                {
                    TestUShort(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 index = rng.NextUShort16(0, 16);
                ushort16 numBits = rng.NextUShort16(0, 1 + 16 - index);
                ushort16 result = bitmask16(numBits, index);

                for (int j = 0; j < 16; j++)
                {
                    TestUShort(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }
    }

    unsafe public static class f_bitmask32
    {
        private static void TestUInt(uint result, byte numBits, byte index)
        {
            uint i = 0;

            while (i < index)
            {
                Assert.IsFalse(testbit(result, i++));
            }
            for (uint j = 0; j < numBits; j++)
            {
                Assert.IsTrue(testbit(result, i++));
            }
            while (i < 32)
            {
                Assert.IsFalse(testbit(result, i++));
            }
        }


        [Test]
        public static void _uint()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte index = rng.NextByte(0, 32);
                byte numBits = rng.NextByte(0, (byte)(1 + 32 - index));
                uint result = bitmask32((uint)numBits, (uint)index);

                TestUInt(result, numBits, index);
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 index = rng.NextUInt2(0, 32);
                uint2 numBits = rng.NextUInt2(0, 1 + 32 - index);
                uint2 result = bitmask32(numBits, index);

                for (int j = 0; j < 2; j++)
                {
                    TestUInt(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 index = rng.NextUInt3(0, 32);
                uint3 numBits = rng.NextUInt3(0, 1 + 32 - index);
                uint3 result = bitmask32(numBits, index);

                for (int j = 0; j < 3; j++)
                {
                    TestUInt(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 index = rng.NextUInt4(0, 32);
                uint4 numBits = rng.NextUInt4(0, 1 + 32 - index);
                uint4 result = bitmask32(numBits, index);

                for (int j = 0; j < 4; j++)
                {
                    TestUInt(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 index = rng.NextUInt8(0, 32);
                uint8 numBits = rng.NextUInt8(0, 1 + 32 - index);
                uint8 result = bitmask32(numBits, index);

                for (int j = 0; j < 8; j++)
                {
                    TestUInt(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }
    }

    unsafe public static class f_bitmask64
    {
        private static void TestULong(ulong result, byte numBits, byte index)
        {
            uint i = 0;

            while (i < index)
            {
                Assert.IsFalse(testbit(result, (ulong)i++));
            }
            for (uint j = 0; j < numBits; j++)
            {
                Assert.IsTrue(testbit(result, (ulong)i++));
            }
            while (i < 64)
            {
                Assert.IsFalse(testbit(result, (ulong)i++));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte index = rng.NextByte(0, 64);
                byte numBits = rng.NextByte(0, (byte)(1 + 64 - index));
                ulong result = bitmask64((ulong)numBits, (ulong)index);

                TestULong(result, numBits, index);
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 index = rng.NextULong2(0, 64);
                ulong2 numBits = rng.NextULong2(0, 1 + 64 - index);
                ulong2 result = bitmask64(numBits, index);

                for (int j = 0; j < 2; j++)
                {
                    TestULong(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 index = rng.NextULong3(0, 64);
                ulong3 numBits = rng.NextULong3(0, 1 + 64 - index);
                ulong3 result = bitmask64(numBits, index);

                for (int j = 0; j < 3; j++)
                {
                    TestULong(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 index = rng.NextULong4(0, 64);
                ulong4 numBits = rng.NextULong4(0, 1 + 64 - index);
                ulong4 result = bitmask64(numBits, index);

                for (int j = 0; j < 4; j++)
                {
                    TestULong(result[j], (byte)numBits[j], (byte)index[j]);
                }
            }
        }
    }

    unsafe public static class f_bitmask128
    {
        private static void TestUInt128(UInt128 result, byte numBits, byte index)
        {
            uint i = 0;

            while (i < index)
            {
                Assert.IsFalse(testbit(result, i++));
            }
            for (uint j = 0; j < numBits; j++)
            {
                Assert.IsTrue(testbit(result, i++));
            }
            while (i < 128)
            {
                Assert.IsFalse(testbit(result, i++));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte index = rng.NextByte(0, 128);
                byte numBits = rng.NextByte(0, (byte)(1 + 128 - index));
                UInt128 result = bitmask128((ulong)numBits, (ulong)index);

                TestUInt128(result, numBits, index);
            }
        }
    }
}
