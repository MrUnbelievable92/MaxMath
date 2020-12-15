using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class rotate
    {
        private const int NUM_ROTATION_TESTS = 4;
        private const uint RNG_SEED = 135166u;

        [Test]
        public static void ror_byte16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < Byte16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    byte16 test = maxmath.ror(Byte16.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.ror(Byte16.TestData_LHS[i].x0  | (Byte16.TestData_LHS[i].x0  << 8) | (Byte16.TestData_LHS[i].x0  << 16) | (Byte16.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.ror(Byte16.TestData_LHS[i].x1  | (Byte16.TestData_LHS[i].x1  << 8) | (Byte16.TestData_LHS[i].x1  << 16) | (Byte16.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.ror(Byte16.TestData_LHS[i].x2  | (Byte16.TestData_LHS[i].x2  << 8) | (Byte16.TestData_LHS[i].x2  << 16) | (Byte16.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.ror(Byte16.TestData_LHS[i].x3  | (Byte16.TestData_LHS[i].x3  << 8) | (Byte16.TestData_LHS[i].x3  << 16) | (Byte16.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.ror(Byte16.TestData_LHS[i].x4  | (Byte16.TestData_LHS[i].x4  << 8) | (Byte16.TestData_LHS[i].x4  << 16) | (Byte16.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.ror(Byte16.TestData_LHS[i].x5  | (Byte16.TestData_LHS[i].x5  << 8) | (Byte16.TestData_LHS[i].x5  << 16) | (Byte16.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.ror(Byte16.TestData_LHS[i].x6  | (Byte16.TestData_LHS[i].x6  << 8) | (Byte16.TestData_LHS[i].x6  << 16) | (Byte16.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.ror(Byte16.TestData_LHS[i].x7  | (Byte16.TestData_LHS[i].x7  << 8) | (Byte16.TestData_LHS[i].x7  << 16) | (Byte16.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.ror(Byte16.TestData_LHS[i].x8  | (Byte16.TestData_LHS[i].x8  << 8) | (Byte16.TestData_LHS[i].x8  << 16) | (Byte16.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.ror(Byte16.TestData_LHS[i].x9  | (Byte16.TestData_LHS[i].x9  << 8) | (Byte16.TestData_LHS[i].x9  << 16) | (Byte16.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.ror(Byte16.TestData_LHS[i].x10 | (Byte16.TestData_LHS[i].x10 << 8) | (Byte16.TestData_LHS[i].x10 << 16) | (Byte16.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.ror(Byte16.TestData_LHS[i].x11 | (Byte16.TestData_LHS[i].x11 << 8) | (Byte16.TestData_LHS[i].x11 << 16) | (Byte16.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.ror(Byte16.TestData_LHS[i].x12 | (Byte16.TestData_LHS[i].x12 << 8) | (Byte16.TestData_LHS[i].x12 << 16) | (Byte16.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.ror(Byte16.TestData_LHS[i].x13 | (Byte16.TestData_LHS[i].x13 << 8) | (Byte16.TestData_LHS[i].x13 << 16) | (Byte16.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.ror(Byte16.TestData_LHS[i].x14 | (Byte16.TestData_LHS[i].x14 << 8) | (Byte16.TestData_LHS[i].x14 << 16) | (Byte16.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.ror(Byte16.TestData_LHS[i].x15 | (Byte16.TestData_LHS[i].x15 << 8) | (Byte16.TestData_LHS[i].x15 << 16) | (Byte16.TestData_LHS[i].x15 << 24), n);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ror_byte32()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < Byte32.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    byte32 test = maxmath.ror(Byte32.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.ror(Byte32.TestData_LHS[i].x0  | (Byte32.TestData_LHS[i].x0  << 8) | (Byte32.TestData_LHS[i].x0  << 16) | (Byte32.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.ror(Byte32.TestData_LHS[i].x1  | (Byte32.TestData_LHS[i].x1  << 8) | (Byte32.TestData_LHS[i].x1  << 16) | (Byte32.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.ror(Byte32.TestData_LHS[i].x2  | (Byte32.TestData_LHS[i].x2  << 8) | (Byte32.TestData_LHS[i].x2  << 16) | (Byte32.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.ror(Byte32.TestData_LHS[i].x3  | (Byte32.TestData_LHS[i].x3  << 8) | (Byte32.TestData_LHS[i].x3  << 16) | (Byte32.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.ror(Byte32.TestData_LHS[i].x4  | (Byte32.TestData_LHS[i].x4  << 8) | (Byte32.TestData_LHS[i].x4  << 16) | (Byte32.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.ror(Byte32.TestData_LHS[i].x5  | (Byte32.TestData_LHS[i].x5  << 8) | (Byte32.TestData_LHS[i].x5  << 16) | (Byte32.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.ror(Byte32.TestData_LHS[i].x6  | (Byte32.TestData_LHS[i].x6  << 8) | (Byte32.TestData_LHS[i].x6  << 16) | (Byte32.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.ror(Byte32.TestData_LHS[i].x7  | (Byte32.TestData_LHS[i].x7  << 8) | (Byte32.TestData_LHS[i].x7  << 16) | (Byte32.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.ror(Byte32.TestData_LHS[i].x8  | (Byte32.TestData_LHS[i].x8  << 8) | (Byte32.TestData_LHS[i].x8  << 16) | (Byte32.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.ror(Byte32.TestData_LHS[i].x9  | (Byte32.TestData_LHS[i].x9  << 8) | (Byte32.TestData_LHS[i].x9  << 16) | (Byte32.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.ror(Byte32.TestData_LHS[i].x10 | (Byte32.TestData_LHS[i].x10 << 8) | (Byte32.TestData_LHS[i].x10 << 16) | (Byte32.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.ror(Byte32.TestData_LHS[i].x11 | (Byte32.TestData_LHS[i].x11 << 8) | (Byte32.TestData_LHS[i].x11 << 16) | (Byte32.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.ror(Byte32.TestData_LHS[i].x12 | (Byte32.TestData_LHS[i].x12 << 8) | (Byte32.TestData_LHS[i].x12 << 16) | (Byte32.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.ror(Byte32.TestData_LHS[i].x13 | (Byte32.TestData_LHS[i].x13 << 8) | (Byte32.TestData_LHS[i].x13 << 16) | (Byte32.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.ror(Byte32.TestData_LHS[i].x14 | (Byte32.TestData_LHS[i].x14 << 8) | (Byte32.TestData_LHS[i].x14 << 16) | (Byte32.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.ror(Byte32.TestData_LHS[i].x15 | (Byte32.TestData_LHS[i].x15 << 8) | (Byte32.TestData_LHS[i].x15 << 16) | (Byte32.TestData_LHS[i].x15 << 24), n);
                    result &= test.x16 == (byte)math.ror(Byte32.TestData_LHS[i].x16 | (Byte32.TestData_LHS[i].x16 << 8) | (Byte32.TestData_LHS[i].x16 << 16) | (Byte32.TestData_LHS[i].x16 << 24), n);
                    result &= test.x17 == (byte)math.ror(Byte32.TestData_LHS[i].x17 | (Byte32.TestData_LHS[i].x17 << 8) | (Byte32.TestData_LHS[i].x17 << 16) | (Byte32.TestData_LHS[i].x17 << 24), n);
                    result &= test.x18 == (byte)math.ror(Byte32.TestData_LHS[i].x18 | (Byte32.TestData_LHS[i].x18 << 8) | (Byte32.TestData_LHS[i].x18 << 16) | (Byte32.TestData_LHS[i].x18 << 24), n);
                    result &= test.x19 == (byte)math.ror(Byte32.TestData_LHS[i].x19 | (Byte32.TestData_LHS[i].x19 << 8) | (Byte32.TestData_LHS[i].x19 << 16) | (Byte32.TestData_LHS[i].x19 << 24), n);
                    result &= test.x20 == (byte)math.ror(Byte32.TestData_LHS[i].x20 | (Byte32.TestData_LHS[i].x20 << 8) | (Byte32.TestData_LHS[i].x20 << 16) | (Byte32.TestData_LHS[i].x20 << 24), n);
                    result &= test.x21 == (byte)math.ror(Byte32.TestData_LHS[i].x21 | (Byte32.TestData_LHS[i].x21 << 8) | (Byte32.TestData_LHS[i].x21 << 16) | (Byte32.TestData_LHS[i].x21 << 24), n);
                    result &= test.x22 == (byte)math.ror(Byte32.TestData_LHS[i].x22 | (Byte32.TestData_LHS[i].x22 << 8) | (Byte32.TestData_LHS[i].x22 << 16) | (Byte32.TestData_LHS[i].x22 << 24), n);
                    result &= test.x23 == (byte)math.ror(Byte32.TestData_LHS[i].x23 | (Byte32.TestData_LHS[i].x23 << 8) | (Byte32.TestData_LHS[i].x23 << 16) | (Byte32.TestData_LHS[i].x23 << 24), n);
                    result &= test.x24 == (byte)math.ror(Byte32.TestData_LHS[i].x24 | (Byte32.TestData_LHS[i].x24 << 8) | (Byte32.TestData_LHS[i].x24 << 16) | (Byte32.TestData_LHS[i].x24 << 24), n);
                    result &= test.x25 == (byte)math.ror(Byte32.TestData_LHS[i].x25 | (Byte32.TestData_LHS[i].x25 << 8) | (Byte32.TestData_LHS[i].x25 << 16) | (Byte32.TestData_LHS[i].x25 << 24), n);
                    result &= test.x26 == (byte)math.ror(Byte32.TestData_LHS[i].x26 | (Byte32.TestData_LHS[i].x26 << 8) | (Byte32.TestData_LHS[i].x26 << 16) | (Byte32.TestData_LHS[i].x26 << 24), n);
                    result &= test.x27 == (byte)math.ror(Byte32.TestData_LHS[i].x27 | (Byte32.TestData_LHS[i].x27 << 8) | (Byte32.TestData_LHS[i].x27 << 16) | (Byte32.TestData_LHS[i].x27 << 24), n);
                    result &= test.x28 == (byte)math.ror(Byte32.TestData_LHS[i].x28 | (Byte32.TestData_LHS[i].x28 << 8) | (Byte32.TestData_LHS[i].x28 << 16) | (Byte32.TestData_LHS[i].x28 << 24), n);
                    result &= test.x29 == (byte)math.ror(Byte32.TestData_LHS[i].x29 | (Byte32.TestData_LHS[i].x29 << 8) | (Byte32.TestData_LHS[i].x29 << 16) | (Byte32.TestData_LHS[i].x29 << 24), n);
                    result &= test.x30 == (byte)math.ror(Byte32.TestData_LHS[i].x30 | (Byte32.TestData_LHS[i].x30 << 8) | (Byte32.TestData_LHS[i].x30 << 16) | (Byte32.TestData_LHS[i].x30 << 24), n);
                    result &= test.x31 == (byte)math.ror(Byte32.TestData_LHS[i].x31 | (Byte32.TestData_LHS[i].x31 << 8) | (Byte32.TestData_LHS[i].x31 << 16) | (Byte32.TestData_LHS[i].x31 << 24), n);
                }
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ror_ushort8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < UShort8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ushort8 test = maxmath.ror(UShort8.TestData_LHS[i], n);

                    result &= test.x0 == (ushort)math.ror(UShort8.TestData_LHS[i].x0 | (UShort8.TestData_LHS[i].x0 << 16), n);
                    result &= test.x1 == (ushort)math.ror(UShort8.TestData_LHS[i].x1 | (UShort8.TestData_LHS[i].x1 << 16), n);
                    result &= test.x2 == (ushort)math.ror(UShort8.TestData_LHS[i].x2 | (UShort8.TestData_LHS[i].x2 << 16), n);
                    result &= test.x3 == (ushort)math.ror(UShort8.TestData_LHS[i].x3 | (UShort8.TestData_LHS[i].x3 << 16), n);
                    result &= test.x4 == (ushort)math.ror(UShort8.TestData_LHS[i].x4 | (UShort8.TestData_LHS[i].x4 << 16), n);
                    result &= test.x5 == (ushort)math.ror(UShort8.TestData_LHS[i].x5 | (UShort8.TestData_LHS[i].x5 << 16), n);
                    result &= test.x6 == (ushort)math.ror(UShort8.TestData_LHS[i].x6 | (UShort8.TestData_LHS[i].x6 << 16), n);
                    result &= test.x7 == (ushort)math.ror(UShort8.TestData_LHS[i].x7 | (UShort8.TestData_LHS[i].x7 << 16), n);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ror_ushort16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < UShort16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ushort16 test = maxmath.ror(UShort16.TestData_LHS[i], n);

                    result &= test.x0  == (ushort)math.ror(UShort16.TestData_LHS[i].x0  | (UShort16.TestData_LHS[i].x0  << 16), n);
                    result &= test.x1  == (ushort)math.ror(UShort16.TestData_LHS[i].x1  | (UShort16.TestData_LHS[i].x1  << 16), n);
                    result &= test.x2  == (ushort)math.ror(UShort16.TestData_LHS[i].x2  | (UShort16.TestData_LHS[i].x2  << 16), n);
                    result &= test.x3  == (ushort)math.ror(UShort16.TestData_LHS[i].x3  | (UShort16.TestData_LHS[i].x3  << 16), n);
                    result &= test.x4  == (ushort)math.ror(UShort16.TestData_LHS[i].x4  | (UShort16.TestData_LHS[i].x4  << 16), n);
                    result &= test.x5  == (ushort)math.ror(UShort16.TestData_LHS[i].x5  | (UShort16.TestData_LHS[i].x5  << 16), n);
                    result &= test.x6  == (ushort)math.ror(UShort16.TestData_LHS[i].x6  | (UShort16.TestData_LHS[i].x6  << 16), n);
                    result &= test.x7  == (ushort)math.ror(UShort16.TestData_LHS[i].x7  | (UShort16.TestData_LHS[i].x7  << 16), n);
                    result &= test.x8  == (ushort)math.ror(UShort16.TestData_LHS[i].x8  | (UShort16.TestData_LHS[i].x8  << 16), n);
                    result &= test.x9  == (ushort)math.ror(UShort16.TestData_LHS[i].x9  | (UShort16.TestData_LHS[i].x9  << 16), n);
                    result &= test.x10 == (ushort)math.ror(UShort16.TestData_LHS[i].x10 | (UShort16.TestData_LHS[i].x10 << 16), n);
                    result &= test.x11 == (ushort)math.ror(UShort16.TestData_LHS[i].x11 | (UShort16.TestData_LHS[i].x11 << 16), n);
                    result &= test.x12 == (ushort)math.ror(UShort16.TestData_LHS[i].x12 | (UShort16.TestData_LHS[i].x12 << 16), n);
                    result &= test.x13 == (ushort)math.ror(UShort16.TestData_LHS[i].x13 | (UShort16.TestData_LHS[i].x13 << 16), n);
                    result &= test.x14 == (ushort)math.ror(UShort16.TestData_LHS[i].x14 | (UShort16.TestData_LHS[i].x14 << 16), n);
                    result &= test.x15 == (ushort)math.ror(UShort16.TestData_LHS[i].x15 | (UShort16.TestData_LHS[i].x15 << 16), n);
                }
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ror_uint8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < UInt8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    uint8 test = maxmath.ror(UInt8.TestData_LHS[i], n);

                    result &= test.x0 == math.ror(UInt8.TestData_LHS[i].x0, n);
                    result &= test.x1 == math.ror(UInt8.TestData_LHS[i].x1, n);
                    result &= test.x2 == math.ror(UInt8.TestData_LHS[i].x2, n);
                    result &= test.x3 == math.ror(UInt8.TestData_LHS[i].x3, n);
                    result &= test.x4 == math.ror(UInt8.TestData_LHS[i].x4, n);
                    result &= test.x5 == math.ror(UInt8.TestData_LHS[i].x5, n);
                    result &= test.x6 == math.ror(UInt8.TestData_LHS[i].x6, n);
                    result &= test.x7 == math.ror(UInt8.TestData_LHS[i].x7, n);
                }
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ror_ulong2()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < ULong2.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ulong2 test = maxmath.ror(ULong2.TestData_LHS[i], n);

                    result &= test.x == math.ror(ULong2.TestData_LHS[i].x, n);
                    result &= test.y == math.ror(ULong2.TestData_LHS[i].y, n);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ror_ulong4()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < ULong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ulong4 test = maxmath.ror(ULong4.TestData_LHS[i], n);

                    result &= test.x == math.ror(ULong4.TestData_LHS[i].x, n);
                    result &= test.y == math.ror(ULong4.TestData_LHS[i].y, n);
                    result &= test.z == math.ror(ULong4.TestData_LHS[i].z, n);
                    result &= test.w == math.ror(ULong4.TestData_LHS[i].w, n);
                }
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void rol_byte16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < Byte16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    byte16 test = maxmath.rol(Byte16.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.rol(Byte16.TestData_LHS[i].x0  | (Byte16.TestData_LHS[i].x0  << 8) | (Byte16.TestData_LHS[i].x0  << 16) | (Byte16.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.rol(Byte16.TestData_LHS[i].x1  | (Byte16.TestData_LHS[i].x1  << 8) | (Byte16.TestData_LHS[i].x1  << 16) | (Byte16.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.rol(Byte16.TestData_LHS[i].x2  | (Byte16.TestData_LHS[i].x2  << 8) | (Byte16.TestData_LHS[i].x2  << 16) | (Byte16.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.rol(Byte16.TestData_LHS[i].x3  | (Byte16.TestData_LHS[i].x3  << 8) | (Byte16.TestData_LHS[i].x3  << 16) | (Byte16.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.rol(Byte16.TestData_LHS[i].x4  | (Byte16.TestData_LHS[i].x4  << 8) | (Byte16.TestData_LHS[i].x4  << 16) | (Byte16.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.rol(Byte16.TestData_LHS[i].x5  | (Byte16.TestData_LHS[i].x5  << 8) | (Byte16.TestData_LHS[i].x5  << 16) | (Byte16.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.rol(Byte16.TestData_LHS[i].x6  | (Byte16.TestData_LHS[i].x6  << 8) | (Byte16.TestData_LHS[i].x6  << 16) | (Byte16.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.rol(Byte16.TestData_LHS[i].x7  | (Byte16.TestData_LHS[i].x7  << 8) | (Byte16.TestData_LHS[i].x7  << 16) | (Byte16.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.rol(Byte16.TestData_LHS[i].x8  | (Byte16.TestData_LHS[i].x8  << 8) | (Byte16.TestData_LHS[i].x8  << 16) | (Byte16.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.rol(Byte16.TestData_LHS[i].x9  | (Byte16.TestData_LHS[i].x9  << 8) | (Byte16.TestData_LHS[i].x9  << 16) | (Byte16.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.rol(Byte16.TestData_LHS[i].x10 | (Byte16.TestData_LHS[i].x10 << 8) | (Byte16.TestData_LHS[i].x10 << 16) | (Byte16.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.rol(Byte16.TestData_LHS[i].x11 | (Byte16.TestData_LHS[i].x11 << 8) | (Byte16.TestData_LHS[i].x11 << 16) | (Byte16.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.rol(Byte16.TestData_LHS[i].x12 | (Byte16.TestData_LHS[i].x12 << 8) | (Byte16.TestData_LHS[i].x12 << 16) | (Byte16.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.rol(Byte16.TestData_LHS[i].x13 | (Byte16.TestData_LHS[i].x13 << 8) | (Byte16.TestData_LHS[i].x13 << 16) | (Byte16.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.rol(Byte16.TestData_LHS[i].x14 | (Byte16.TestData_LHS[i].x14 << 8) | (Byte16.TestData_LHS[i].x14 << 16) | (Byte16.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.rol(Byte16.TestData_LHS[i].x15 | (Byte16.TestData_LHS[i].x15 << 8) | (Byte16.TestData_LHS[i].x15 << 16) | (Byte16.TestData_LHS[i].x15 << 24), n);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void rol_byte32()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < Byte32.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    byte32 test = maxmath.rol(Byte32.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.rol(Byte32.TestData_LHS[i].x0  | (Byte32.TestData_LHS[i].x0  << 8) | (Byte32.TestData_LHS[i].x0  << 16) | (Byte32.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.rol(Byte32.TestData_LHS[i].x1  | (Byte32.TestData_LHS[i].x1  << 8) | (Byte32.TestData_LHS[i].x1  << 16) | (Byte32.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.rol(Byte32.TestData_LHS[i].x2  | (Byte32.TestData_LHS[i].x2  << 8) | (Byte32.TestData_LHS[i].x2  << 16) | (Byte32.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.rol(Byte32.TestData_LHS[i].x3  | (Byte32.TestData_LHS[i].x3  << 8) | (Byte32.TestData_LHS[i].x3  << 16) | (Byte32.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.rol(Byte32.TestData_LHS[i].x4  | (Byte32.TestData_LHS[i].x4  << 8) | (Byte32.TestData_LHS[i].x4  << 16) | (Byte32.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.rol(Byte32.TestData_LHS[i].x5  | (Byte32.TestData_LHS[i].x5  << 8) | (Byte32.TestData_LHS[i].x5  << 16) | (Byte32.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.rol(Byte32.TestData_LHS[i].x6  | (Byte32.TestData_LHS[i].x6  << 8) | (Byte32.TestData_LHS[i].x6  << 16) | (Byte32.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.rol(Byte32.TestData_LHS[i].x7  | (Byte32.TestData_LHS[i].x7  << 8) | (Byte32.TestData_LHS[i].x7  << 16) | (Byte32.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.rol(Byte32.TestData_LHS[i].x8  | (Byte32.TestData_LHS[i].x8  << 8) | (Byte32.TestData_LHS[i].x8  << 16) | (Byte32.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.rol(Byte32.TestData_LHS[i].x9  | (Byte32.TestData_LHS[i].x9  << 8) | (Byte32.TestData_LHS[i].x9  << 16) | (Byte32.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.rol(Byte32.TestData_LHS[i].x10 | (Byte32.TestData_LHS[i].x10 << 8) | (Byte32.TestData_LHS[i].x10 << 16) | (Byte32.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.rol(Byte32.TestData_LHS[i].x11 | (Byte32.TestData_LHS[i].x11 << 8) | (Byte32.TestData_LHS[i].x11 << 16) | (Byte32.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.rol(Byte32.TestData_LHS[i].x12 | (Byte32.TestData_LHS[i].x12 << 8) | (Byte32.TestData_LHS[i].x12 << 16) | (Byte32.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.rol(Byte32.TestData_LHS[i].x13 | (Byte32.TestData_LHS[i].x13 << 8) | (Byte32.TestData_LHS[i].x13 << 16) | (Byte32.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.rol(Byte32.TestData_LHS[i].x14 | (Byte32.TestData_LHS[i].x14 << 8) | (Byte32.TestData_LHS[i].x14 << 16) | (Byte32.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.rol(Byte32.TestData_LHS[i].x15 | (Byte32.TestData_LHS[i].x15 << 8) | (Byte32.TestData_LHS[i].x15 << 16) | (Byte32.TestData_LHS[i].x15 << 24), n);
                    result &= test.x16 == (byte)math.rol(Byte32.TestData_LHS[i].x16 | (Byte32.TestData_LHS[i].x16 << 8) | (Byte32.TestData_LHS[i].x16 << 16) | (Byte32.TestData_LHS[i].x16 << 24), n);
                    result &= test.x17 == (byte)math.rol(Byte32.TestData_LHS[i].x17 | (Byte32.TestData_LHS[i].x17 << 8) | (Byte32.TestData_LHS[i].x17 << 16) | (Byte32.TestData_LHS[i].x17 << 24), n);
                    result &= test.x18 == (byte)math.rol(Byte32.TestData_LHS[i].x18 | (Byte32.TestData_LHS[i].x18 << 8) | (Byte32.TestData_LHS[i].x18 << 16) | (Byte32.TestData_LHS[i].x18 << 24), n);
                    result &= test.x19 == (byte)math.rol(Byte32.TestData_LHS[i].x19 | (Byte32.TestData_LHS[i].x19 << 8) | (Byte32.TestData_LHS[i].x19 << 16) | (Byte32.TestData_LHS[i].x19 << 24), n);
                    result &= test.x20 == (byte)math.rol(Byte32.TestData_LHS[i].x20 | (Byte32.TestData_LHS[i].x20 << 8) | (Byte32.TestData_LHS[i].x20 << 16) | (Byte32.TestData_LHS[i].x20 << 24), n);
                    result &= test.x21 == (byte)math.rol(Byte32.TestData_LHS[i].x21 | (Byte32.TestData_LHS[i].x21 << 8) | (Byte32.TestData_LHS[i].x21 << 16) | (Byte32.TestData_LHS[i].x21 << 24), n);
                    result &= test.x22 == (byte)math.rol(Byte32.TestData_LHS[i].x22 | (Byte32.TestData_LHS[i].x22 << 8) | (Byte32.TestData_LHS[i].x22 << 16) | (Byte32.TestData_LHS[i].x22 << 24), n);
                    result &= test.x23 == (byte)math.rol(Byte32.TestData_LHS[i].x23 | (Byte32.TestData_LHS[i].x23 << 8) | (Byte32.TestData_LHS[i].x23 << 16) | (Byte32.TestData_LHS[i].x23 << 24), n);
                    result &= test.x24 == (byte)math.rol(Byte32.TestData_LHS[i].x24 | (Byte32.TestData_LHS[i].x24 << 8) | (Byte32.TestData_LHS[i].x24 << 16) | (Byte32.TestData_LHS[i].x24 << 24), n);
                    result &= test.x25 == (byte)math.rol(Byte32.TestData_LHS[i].x25 | (Byte32.TestData_LHS[i].x25 << 8) | (Byte32.TestData_LHS[i].x25 << 16) | (Byte32.TestData_LHS[i].x25 << 24), n);
                    result &= test.x26 == (byte)math.rol(Byte32.TestData_LHS[i].x26 | (Byte32.TestData_LHS[i].x26 << 8) | (Byte32.TestData_LHS[i].x26 << 16) | (Byte32.TestData_LHS[i].x26 << 24), n);
                    result &= test.x27 == (byte)math.rol(Byte32.TestData_LHS[i].x27 | (Byte32.TestData_LHS[i].x27 << 8) | (Byte32.TestData_LHS[i].x27 << 16) | (Byte32.TestData_LHS[i].x27 << 24), n);
                    result &= test.x28 == (byte)math.rol(Byte32.TestData_LHS[i].x28 | (Byte32.TestData_LHS[i].x28 << 8) | (Byte32.TestData_LHS[i].x28 << 16) | (Byte32.TestData_LHS[i].x28 << 24), n);
                    result &= test.x29 == (byte)math.rol(Byte32.TestData_LHS[i].x29 | (Byte32.TestData_LHS[i].x29 << 8) | (Byte32.TestData_LHS[i].x29 << 16) | (Byte32.TestData_LHS[i].x29 << 24), n);
                    result &= test.x30 == (byte)math.rol(Byte32.TestData_LHS[i].x30 | (Byte32.TestData_LHS[i].x30 << 8) | (Byte32.TestData_LHS[i].x30 << 16) | (Byte32.TestData_LHS[i].x30 << 24), n);
                    result &= test.x31 == (byte)math.rol(Byte32.TestData_LHS[i].x31 | (Byte32.TestData_LHS[i].x31 << 8) | (Byte32.TestData_LHS[i].x31 << 16) | (Byte32.TestData_LHS[i].x31 << 24), n);
                }
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void rol_ushort8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < UShort8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ushort8 test = maxmath.rol(UShort8.TestData_LHS[i], n);

                    result &= test.x0 == (ushort)math.rol(UShort8.TestData_LHS[i].x0 | (UShort8.TestData_LHS[i].x0 << 16), n);
                    result &= test.x1 == (ushort)math.rol(UShort8.TestData_LHS[i].x1 | (UShort8.TestData_LHS[i].x1 << 16), n);
                    result &= test.x2 == (ushort)math.rol(UShort8.TestData_LHS[i].x2 | (UShort8.TestData_LHS[i].x2 << 16), n);
                    result &= test.x3 == (ushort)math.rol(UShort8.TestData_LHS[i].x3 | (UShort8.TestData_LHS[i].x3 << 16), n);
                    result &= test.x4 == (ushort)math.rol(UShort8.TestData_LHS[i].x4 | (UShort8.TestData_LHS[i].x4 << 16), n);
                    result &= test.x5 == (ushort)math.rol(UShort8.TestData_LHS[i].x5 | (UShort8.TestData_LHS[i].x5 << 16), n);
                    result &= test.x6 == (ushort)math.rol(UShort8.TestData_LHS[i].x6 | (UShort8.TestData_LHS[i].x6 << 16), n);
                    result &= test.x7 == (ushort)math.rol(UShort8.TestData_LHS[i].x7 | (UShort8.TestData_LHS[i].x7 << 16), n);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void rol_ushort16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < UShort16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ushort16 test = maxmath.rol(UShort16.TestData_LHS[i], n);

                    result &= test.x0  == (ushort)math.rol(UShort16.TestData_LHS[i].x0  | (UShort16.TestData_LHS[i].x0  << 16), n);
                    result &= test.x1  == (ushort)math.rol(UShort16.TestData_LHS[i].x1  | (UShort16.TestData_LHS[i].x1  << 16), n);
                    result &= test.x2  == (ushort)math.rol(UShort16.TestData_LHS[i].x2  | (UShort16.TestData_LHS[i].x2  << 16), n);
                    result &= test.x3  == (ushort)math.rol(UShort16.TestData_LHS[i].x3  | (UShort16.TestData_LHS[i].x3  << 16), n);
                    result &= test.x4  == (ushort)math.rol(UShort16.TestData_LHS[i].x4  | (UShort16.TestData_LHS[i].x4  << 16), n);
                    result &= test.x5  == (ushort)math.rol(UShort16.TestData_LHS[i].x5  | (UShort16.TestData_LHS[i].x5  << 16), n);
                    result &= test.x6  == (ushort)math.rol(UShort16.TestData_LHS[i].x6  | (UShort16.TestData_LHS[i].x6  << 16), n);
                    result &= test.x7  == (ushort)math.rol(UShort16.TestData_LHS[i].x7  | (UShort16.TestData_LHS[i].x7  << 16), n);
                    result &= test.x8  == (ushort)math.rol(UShort16.TestData_LHS[i].x8  | (UShort16.TestData_LHS[i].x8  << 16), n);
                    result &= test.x9  == (ushort)math.rol(UShort16.TestData_LHS[i].x9  | (UShort16.TestData_LHS[i].x9  << 16), n);
                    result &= test.x10 == (ushort)math.rol(UShort16.TestData_LHS[i].x10 | (UShort16.TestData_LHS[i].x10 << 16), n);
                    result &= test.x11 == (ushort)math.rol(UShort16.TestData_LHS[i].x11 | (UShort16.TestData_LHS[i].x11 << 16), n);
                    result &= test.x12 == (ushort)math.rol(UShort16.TestData_LHS[i].x12 | (UShort16.TestData_LHS[i].x12 << 16), n);
                    result &= test.x13 == (ushort)math.rol(UShort16.TestData_LHS[i].x13 | (UShort16.TestData_LHS[i].x13 << 16), n);
                    result &= test.x14 == (ushort)math.rol(UShort16.TestData_LHS[i].x14 | (UShort16.TestData_LHS[i].x14 << 16), n);
                    result &= test.x15 == (ushort)math.rol(UShort16.TestData_LHS[i].x15 | (UShort16.TestData_LHS[i].x15 << 16), n);
                }
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void rol_uint8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < UInt8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    uint8 test = maxmath.rol(UInt8.TestData_LHS[i], n);

                    result &= test.x0 == math.rol(UInt8.TestData_LHS[i].x0, n);
                    result &= test.x1 == math.rol(UInt8.TestData_LHS[i].x1, n);
                    result &= test.x2 == math.rol(UInt8.TestData_LHS[i].x2, n);
                    result &= test.x3 == math.rol(UInt8.TestData_LHS[i].x3, n);
                    result &= test.x4 == math.rol(UInt8.TestData_LHS[i].x4, n);
                    result &= test.x5 == math.rol(UInt8.TestData_LHS[i].x5, n);
                    result &= test.x6 == math.rol(UInt8.TestData_LHS[i].x6, n);
                    result &= test.x7 == math.rol(UInt8.TestData_LHS[i].x7, n);
                }
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void rol_ulong2()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < ULong2.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ulong2 test = maxmath.rol(ULong2.TestData_LHS[i], n);

                    result &= test.x == math.rol(ULong2.TestData_LHS[i].x, n);
                    result &= test.y == math.rol(ULong2.TestData_LHS[i].y, n);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void rol_ulong4()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < ULong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt();
                    ulong4 test = maxmath.rol(ULong4.TestData_LHS[i], n);

                    result &= test.x == math.rol(ULong4.TestData_LHS[i].x, n);
                    result &= test.y == math.rol(ULong4.TestData_LHS[i].y, n);
                    result &= test.z == math.rol(ULong4.TestData_LHS[i].z, n);
                    result &= test.w == math.rol(ULong4.TestData_LHS[i].w, n);
                }
            }

            Assert.AreEqual(result, true);
        }
    }
}
