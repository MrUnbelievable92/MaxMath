using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_rotate
    {
        private const int NUM_ROTATION_TESTS = 4;
        private const uint RNG_SEED = 135166u;

        [Test]
        public static void ror_byte16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_byte16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 8);
                    byte16 test = maxmath.ror(t_byte16.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.ror(t_byte16.TestData_LHS[i].x0  | (t_byte16.TestData_LHS[i].x0  << 8) | (t_byte16.TestData_LHS[i].x0  << 16) | (t_byte16.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.ror(t_byte16.TestData_LHS[i].x1  | (t_byte16.TestData_LHS[i].x1  << 8) | (t_byte16.TestData_LHS[i].x1  << 16) | (t_byte16.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.ror(t_byte16.TestData_LHS[i].x2  | (t_byte16.TestData_LHS[i].x2  << 8) | (t_byte16.TestData_LHS[i].x2  << 16) | (t_byte16.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.ror(t_byte16.TestData_LHS[i].x3  | (t_byte16.TestData_LHS[i].x3  << 8) | (t_byte16.TestData_LHS[i].x3  << 16) | (t_byte16.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.ror(t_byte16.TestData_LHS[i].x4  | (t_byte16.TestData_LHS[i].x4  << 8) | (t_byte16.TestData_LHS[i].x4  << 16) | (t_byte16.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.ror(t_byte16.TestData_LHS[i].x5  | (t_byte16.TestData_LHS[i].x5  << 8) | (t_byte16.TestData_LHS[i].x5  << 16) | (t_byte16.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.ror(t_byte16.TestData_LHS[i].x6  | (t_byte16.TestData_LHS[i].x6  << 8) | (t_byte16.TestData_LHS[i].x6  << 16) | (t_byte16.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.ror(t_byte16.TestData_LHS[i].x7  | (t_byte16.TestData_LHS[i].x7  << 8) | (t_byte16.TestData_LHS[i].x7  << 16) | (t_byte16.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.ror(t_byte16.TestData_LHS[i].x8  | (t_byte16.TestData_LHS[i].x8  << 8) | (t_byte16.TestData_LHS[i].x8  << 16) | (t_byte16.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.ror(t_byte16.TestData_LHS[i].x9  | (t_byte16.TestData_LHS[i].x9  << 8) | (t_byte16.TestData_LHS[i].x9  << 16) | (t_byte16.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.ror(t_byte16.TestData_LHS[i].x10 | (t_byte16.TestData_LHS[i].x10 << 8) | (t_byte16.TestData_LHS[i].x10 << 16) | (t_byte16.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.ror(t_byte16.TestData_LHS[i].x11 | (t_byte16.TestData_LHS[i].x11 << 8) | (t_byte16.TestData_LHS[i].x11 << 16) | (t_byte16.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.ror(t_byte16.TestData_LHS[i].x12 | (t_byte16.TestData_LHS[i].x12 << 8) | (t_byte16.TestData_LHS[i].x12 << 16) | (t_byte16.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.ror(t_byte16.TestData_LHS[i].x13 | (t_byte16.TestData_LHS[i].x13 << 8) | (t_byte16.TestData_LHS[i].x13 << 16) | (t_byte16.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.ror(t_byte16.TestData_LHS[i].x14 | (t_byte16.TestData_LHS[i].x14 << 8) | (t_byte16.TestData_LHS[i].x14 << 16) | (t_byte16.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.ror(t_byte16.TestData_LHS[i].x15 | (t_byte16.TestData_LHS[i].x15 << 8) | (t_byte16.TestData_LHS[i].x15 << 16) | (t_byte16.TestData_LHS[i].x15 << 24), n);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ror_byte32()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_byte32.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 8);
                    byte32 test = maxmath.ror(t_byte32.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.ror(t_byte32.TestData_LHS[i].x0  | (t_byte32.TestData_LHS[i].x0  << 8) | (t_byte32.TestData_LHS[i].x0  << 16) | (t_byte32.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.ror(t_byte32.TestData_LHS[i].x1  | (t_byte32.TestData_LHS[i].x1  << 8) | (t_byte32.TestData_LHS[i].x1  << 16) | (t_byte32.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.ror(t_byte32.TestData_LHS[i].x2  | (t_byte32.TestData_LHS[i].x2  << 8) | (t_byte32.TestData_LHS[i].x2  << 16) | (t_byte32.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.ror(t_byte32.TestData_LHS[i].x3  | (t_byte32.TestData_LHS[i].x3  << 8) | (t_byte32.TestData_LHS[i].x3  << 16) | (t_byte32.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.ror(t_byte32.TestData_LHS[i].x4  | (t_byte32.TestData_LHS[i].x4  << 8) | (t_byte32.TestData_LHS[i].x4  << 16) | (t_byte32.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.ror(t_byte32.TestData_LHS[i].x5  | (t_byte32.TestData_LHS[i].x5  << 8) | (t_byte32.TestData_LHS[i].x5  << 16) | (t_byte32.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.ror(t_byte32.TestData_LHS[i].x6  | (t_byte32.TestData_LHS[i].x6  << 8) | (t_byte32.TestData_LHS[i].x6  << 16) | (t_byte32.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.ror(t_byte32.TestData_LHS[i].x7  | (t_byte32.TestData_LHS[i].x7  << 8) | (t_byte32.TestData_LHS[i].x7  << 16) | (t_byte32.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.ror(t_byte32.TestData_LHS[i].x8  | (t_byte32.TestData_LHS[i].x8  << 8) | (t_byte32.TestData_LHS[i].x8  << 16) | (t_byte32.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.ror(t_byte32.TestData_LHS[i].x9  | (t_byte32.TestData_LHS[i].x9  << 8) | (t_byte32.TestData_LHS[i].x9  << 16) | (t_byte32.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.ror(t_byte32.TestData_LHS[i].x10 | (t_byte32.TestData_LHS[i].x10 << 8) | (t_byte32.TestData_LHS[i].x10 << 16) | (t_byte32.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.ror(t_byte32.TestData_LHS[i].x11 | (t_byte32.TestData_LHS[i].x11 << 8) | (t_byte32.TestData_LHS[i].x11 << 16) | (t_byte32.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.ror(t_byte32.TestData_LHS[i].x12 | (t_byte32.TestData_LHS[i].x12 << 8) | (t_byte32.TestData_LHS[i].x12 << 16) | (t_byte32.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.ror(t_byte32.TestData_LHS[i].x13 | (t_byte32.TestData_LHS[i].x13 << 8) | (t_byte32.TestData_LHS[i].x13 << 16) | (t_byte32.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.ror(t_byte32.TestData_LHS[i].x14 | (t_byte32.TestData_LHS[i].x14 << 8) | (t_byte32.TestData_LHS[i].x14 << 16) | (t_byte32.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.ror(t_byte32.TestData_LHS[i].x15 | (t_byte32.TestData_LHS[i].x15 << 8) | (t_byte32.TestData_LHS[i].x15 << 16) | (t_byte32.TestData_LHS[i].x15 << 24), n);
                    result &= test.x16 == (byte)math.ror(t_byte32.TestData_LHS[i].x16 | (t_byte32.TestData_LHS[i].x16 << 8) | (t_byte32.TestData_LHS[i].x16 << 16) | (t_byte32.TestData_LHS[i].x16 << 24), n);
                    result &= test.x17 == (byte)math.ror(t_byte32.TestData_LHS[i].x17 | (t_byte32.TestData_LHS[i].x17 << 8) | (t_byte32.TestData_LHS[i].x17 << 16) | (t_byte32.TestData_LHS[i].x17 << 24), n);
                    result &= test.x18 == (byte)math.ror(t_byte32.TestData_LHS[i].x18 | (t_byte32.TestData_LHS[i].x18 << 8) | (t_byte32.TestData_LHS[i].x18 << 16) | (t_byte32.TestData_LHS[i].x18 << 24), n);
                    result &= test.x19 == (byte)math.ror(t_byte32.TestData_LHS[i].x19 | (t_byte32.TestData_LHS[i].x19 << 8) | (t_byte32.TestData_LHS[i].x19 << 16) | (t_byte32.TestData_LHS[i].x19 << 24), n);
                    result &= test.x20 == (byte)math.ror(t_byte32.TestData_LHS[i].x20 | (t_byte32.TestData_LHS[i].x20 << 8) | (t_byte32.TestData_LHS[i].x20 << 16) | (t_byte32.TestData_LHS[i].x20 << 24), n);
                    result &= test.x21 == (byte)math.ror(t_byte32.TestData_LHS[i].x21 | (t_byte32.TestData_LHS[i].x21 << 8) | (t_byte32.TestData_LHS[i].x21 << 16) | (t_byte32.TestData_LHS[i].x21 << 24), n);
                    result &= test.x22 == (byte)math.ror(t_byte32.TestData_LHS[i].x22 | (t_byte32.TestData_LHS[i].x22 << 8) | (t_byte32.TestData_LHS[i].x22 << 16) | (t_byte32.TestData_LHS[i].x22 << 24), n);
                    result &= test.x23 == (byte)math.ror(t_byte32.TestData_LHS[i].x23 | (t_byte32.TestData_LHS[i].x23 << 8) | (t_byte32.TestData_LHS[i].x23 << 16) | (t_byte32.TestData_LHS[i].x23 << 24), n);
                    result &= test.x24 == (byte)math.ror(t_byte32.TestData_LHS[i].x24 | (t_byte32.TestData_LHS[i].x24 << 8) | (t_byte32.TestData_LHS[i].x24 << 16) | (t_byte32.TestData_LHS[i].x24 << 24), n);
                    result &= test.x25 == (byte)math.ror(t_byte32.TestData_LHS[i].x25 | (t_byte32.TestData_LHS[i].x25 << 8) | (t_byte32.TestData_LHS[i].x25 << 16) | (t_byte32.TestData_LHS[i].x25 << 24), n);
                    result &= test.x26 == (byte)math.ror(t_byte32.TestData_LHS[i].x26 | (t_byte32.TestData_LHS[i].x26 << 8) | (t_byte32.TestData_LHS[i].x26 << 16) | (t_byte32.TestData_LHS[i].x26 << 24), n);
                    result &= test.x27 == (byte)math.ror(t_byte32.TestData_LHS[i].x27 | (t_byte32.TestData_LHS[i].x27 << 8) | (t_byte32.TestData_LHS[i].x27 << 16) | (t_byte32.TestData_LHS[i].x27 << 24), n);
                    result &= test.x28 == (byte)math.ror(t_byte32.TestData_LHS[i].x28 | (t_byte32.TestData_LHS[i].x28 << 8) | (t_byte32.TestData_LHS[i].x28 << 16) | (t_byte32.TestData_LHS[i].x28 << 24), n);
                    result &= test.x29 == (byte)math.ror(t_byte32.TestData_LHS[i].x29 | (t_byte32.TestData_LHS[i].x29 << 8) | (t_byte32.TestData_LHS[i].x29 << 16) | (t_byte32.TestData_LHS[i].x29 << 24), n);
                    result &= test.x30 == (byte)math.ror(t_byte32.TestData_LHS[i].x30 | (t_byte32.TestData_LHS[i].x30 << 8) | (t_byte32.TestData_LHS[i].x30 << 16) | (t_byte32.TestData_LHS[i].x30 << 24), n);
                    result &= test.x31 == (byte)math.ror(t_byte32.TestData_LHS[i].x31 | (t_byte32.TestData_LHS[i].x31 << 8) | (t_byte32.TestData_LHS[i].x31 << 16) | (t_byte32.TestData_LHS[i].x31 << 24), n);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ror_ushort8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ushort8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 16);
                    ushort8 test = maxmath.ror(t_ushort8.TestData_LHS[i], n);

                    result &= test.x0 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x0 | (t_ushort8.TestData_LHS[i].x0 << 16), n);
                    result &= test.x1 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x1 | (t_ushort8.TestData_LHS[i].x1 << 16), n);
                    result &= test.x2 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x2 | (t_ushort8.TestData_LHS[i].x2 << 16), n);
                    result &= test.x3 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x3 | (t_ushort8.TestData_LHS[i].x3 << 16), n);
                    result &= test.x4 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x4 | (t_ushort8.TestData_LHS[i].x4 << 16), n);
                    result &= test.x5 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x5 | (t_ushort8.TestData_LHS[i].x5 << 16), n);
                    result &= test.x6 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x6 | (t_ushort8.TestData_LHS[i].x6 << 16), n);
                    result &= test.x7 == (ushort)math.ror(t_ushort8.TestData_LHS[i].x7 | (t_ushort8.TestData_LHS[i].x7 << 16), n);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ror_ushort16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ushort16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 16);
                    ushort16 test = maxmath.ror(t_ushort16.TestData_LHS[i], n);

                    result &= test.x0  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x0  | (t_ushort16.TestData_LHS[i].x0  << 16), n);
                    result &= test.x1  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x1  | (t_ushort16.TestData_LHS[i].x1  << 16), n);
                    result &= test.x2  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x2  | (t_ushort16.TestData_LHS[i].x2  << 16), n);
                    result &= test.x3  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x3  | (t_ushort16.TestData_LHS[i].x3  << 16), n);
                    result &= test.x4  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x4  | (t_ushort16.TestData_LHS[i].x4  << 16), n);
                    result &= test.x5  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x5  | (t_ushort16.TestData_LHS[i].x5  << 16), n);
                    result &= test.x6  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x6  | (t_ushort16.TestData_LHS[i].x6  << 16), n);
                    result &= test.x7  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x7  | (t_ushort16.TestData_LHS[i].x7  << 16), n);
                    result &= test.x8  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x8  | (t_ushort16.TestData_LHS[i].x8  << 16), n);
                    result &= test.x9  == (ushort)math.ror(t_ushort16.TestData_LHS[i].x9  | (t_ushort16.TestData_LHS[i].x9  << 16), n);
                    result &= test.x10 == (ushort)math.ror(t_ushort16.TestData_LHS[i].x10 | (t_ushort16.TestData_LHS[i].x10 << 16), n);
                    result &= test.x11 == (ushort)math.ror(t_ushort16.TestData_LHS[i].x11 | (t_ushort16.TestData_LHS[i].x11 << 16), n);
                    result &= test.x12 == (ushort)math.ror(t_ushort16.TestData_LHS[i].x12 | (t_ushort16.TestData_LHS[i].x12 << 16), n);
                    result &= test.x13 == (ushort)math.ror(t_ushort16.TestData_LHS[i].x13 | (t_ushort16.TestData_LHS[i].x13 << 16), n);
                    result &= test.x14 == (ushort)math.ror(t_ushort16.TestData_LHS[i].x14 | (t_ushort16.TestData_LHS[i].x14 << 16), n);
                    result &= test.x15 == (ushort)math.ror(t_ushort16.TestData_LHS[i].x15 | (t_ushort16.TestData_LHS[i].x15 << 16), n);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ror_uint8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_uint8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 32);
                    uint8 test = maxmath.ror(t_uint8.TestData_LHS[i], n);

                    result &= test.x0 == math.ror(t_uint8.TestData_LHS[i].x0, n);
                    result &= test.x1 == math.ror(t_uint8.TestData_LHS[i].x1, n);
                    result &= test.x2 == math.ror(t_uint8.TestData_LHS[i].x2, n);
                    result &= test.x3 == math.ror(t_uint8.TestData_LHS[i].x3, n);
                    result &= test.x4 == math.ror(t_uint8.TestData_LHS[i].x4, n);
                    result &= test.x5 == math.ror(t_uint8.TestData_LHS[i].x5, n);
                    result &= test.x6 == math.ror(t_uint8.TestData_LHS[i].x6, n);
                    result &= test.x7 == math.ror(t_uint8.TestData_LHS[i].x7, n);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ror_ulong2()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ulong2.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 64);
                    ulong2 test = maxmath.ror(t_ulong2.TestData_LHS[i], n);

                    result &= test.x == math.ror(t_ulong2.TestData_LHS[i].x, n);
                    result &= test.y == math.ror(t_ulong2.TestData_LHS[i].y, n);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ror_ulong4()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ulong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 64);
                    ulong4 test = maxmath.ror(t_ulong4.TestData_LHS[i], n);

                    result &= test.x == math.ror(t_ulong4.TestData_LHS[i].x, n);
                    result &= test.y == math.ror(t_ulong4.TestData_LHS[i].y, n);
                    result &= test.z == math.ror(t_ulong4.TestData_LHS[i].z, n);
                    result &= test.w == math.ror(t_ulong4.TestData_LHS[i].w, n);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void rol_byte16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_byte16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 8);
                    byte16 test = maxmath.rol(t_byte16.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.rol(t_byte16.TestData_LHS[i].x0  | (t_byte16.TestData_LHS[i].x0  << 8) | (t_byte16.TestData_LHS[i].x0  << 16) | (t_byte16.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.rol(t_byte16.TestData_LHS[i].x1  | (t_byte16.TestData_LHS[i].x1  << 8) | (t_byte16.TestData_LHS[i].x1  << 16) | (t_byte16.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.rol(t_byte16.TestData_LHS[i].x2  | (t_byte16.TestData_LHS[i].x2  << 8) | (t_byte16.TestData_LHS[i].x2  << 16) | (t_byte16.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.rol(t_byte16.TestData_LHS[i].x3  | (t_byte16.TestData_LHS[i].x3  << 8) | (t_byte16.TestData_LHS[i].x3  << 16) | (t_byte16.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.rol(t_byte16.TestData_LHS[i].x4  | (t_byte16.TestData_LHS[i].x4  << 8) | (t_byte16.TestData_LHS[i].x4  << 16) | (t_byte16.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.rol(t_byte16.TestData_LHS[i].x5  | (t_byte16.TestData_LHS[i].x5  << 8) | (t_byte16.TestData_LHS[i].x5  << 16) | (t_byte16.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.rol(t_byte16.TestData_LHS[i].x6  | (t_byte16.TestData_LHS[i].x6  << 8) | (t_byte16.TestData_LHS[i].x6  << 16) | (t_byte16.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.rol(t_byte16.TestData_LHS[i].x7  | (t_byte16.TestData_LHS[i].x7  << 8) | (t_byte16.TestData_LHS[i].x7  << 16) | (t_byte16.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.rol(t_byte16.TestData_LHS[i].x8  | (t_byte16.TestData_LHS[i].x8  << 8) | (t_byte16.TestData_LHS[i].x8  << 16) | (t_byte16.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.rol(t_byte16.TestData_LHS[i].x9  | (t_byte16.TestData_LHS[i].x9  << 8) | (t_byte16.TestData_LHS[i].x9  << 16) | (t_byte16.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.rol(t_byte16.TestData_LHS[i].x10 | (t_byte16.TestData_LHS[i].x10 << 8) | (t_byte16.TestData_LHS[i].x10 << 16) | (t_byte16.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.rol(t_byte16.TestData_LHS[i].x11 | (t_byte16.TestData_LHS[i].x11 << 8) | (t_byte16.TestData_LHS[i].x11 << 16) | (t_byte16.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.rol(t_byte16.TestData_LHS[i].x12 | (t_byte16.TestData_LHS[i].x12 << 8) | (t_byte16.TestData_LHS[i].x12 << 16) | (t_byte16.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.rol(t_byte16.TestData_LHS[i].x13 | (t_byte16.TestData_LHS[i].x13 << 8) | (t_byte16.TestData_LHS[i].x13 << 16) | (t_byte16.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.rol(t_byte16.TestData_LHS[i].x14 | (t_byte16.TestData_LHS[i].x14 << 8) | (t_byte16.TestData_LHS[i].x14 << 16) | (t_byte16.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.rol(t_byte16.TestData_LHS[i].x15 | (t_byte16.TestData_LHS[i].x15 << 8) | (t_byte16.TestData_LHS[i].x15 << 16) | (t_byte16.TestData_LHS[i].x15 << 24), n);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_byte32()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_byte32.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 8);
                    byte32 test = maxmath.rol(t_byte32.TestData_LHS[i], n);

                    result &= test.x0  == (byte)math.rol(t_byte32.TestData_LHS[i].x0  | (t_byte32.TestData_LHS[i].x0  << 8) | (t_byte32.TestData_LHS[i].x0  << 16) | (t_byte32.TestData_LHS[i].x0  << 24), n);
                    result &= test.x1  == (byte)math.rol(t_byte32.TestData_LHS[i].x1  | (t_byte32.TestData_LHS[i].x1  << 8) | (t_byte32.TestData_LHS[i].x1  << 16) | (t_byte32.TestData_LHS[i].x1  << 24), n);
                    result &= test.x2  == (byte)math.rol(t_byte32.TestData_LHS[i].x2  | (t_byte32.TestData_LHS[i].x2  << 8) | (t_byte32.TestData_LHS[i].x2  << 16) | (t_byte32.TestData_LHS[i].x2  << 24), n);
                    result &= test.x3  == (byte)math.rol(t_byte32.TestData_LHS[i].x3  | (t_byte32.TestData_LHS[i].x3  << 8) | (t_byte32.TestData_LHS[i].x3  << 16) | (t_byte32.TestData_LHS[i].x3  << 24), n);
                    result &= test.x4  == (byte)math.rol(t_byte32.TestData_LHS[i].x4  | (t_byte32.TestData_LHS[i].x4  << 8) | (t_byte32.TestData_LHS[i].x4  << 16) | (t_byte32.TestData_LHS[i].x4  << 24), n);
                    result &= test.x5  == (byte)math.rol(t_byte32.TestData_LHS[i].x5  | (t_byte32.TestData_LHS[i].x5  << 8) | (t_byte32.TestData_LHS[i].x5  << 16) | (t_byte32.TestData_LHS[i].x5  << 24), n);
                    result &= test.x6  == (byte)math.rol(t_byte32.TestData_LHS[i].x6  | (t_byte32.TestData_LHS[i].x6  << 8) | (t_byte32.TestData_LHS[i].x6  << 16) | (t_byte32.TestData_LHS[i].x6  << 24), n);
                    result &= test.x7  == (byte)math.rol(t_byte32.TestData_LHS[i].x7  | (t_byte32.TestData_LHS[i].x7  << 8) | (t_byte32.TestData_LHS[i].x7  << 16) | (t_byte32.TestData_LHS[i].x7  << 24), n);
                    result &= test.x8  == (byte)math.rol(t_byte32.TestData_LHS[i].x8  | (t_byte32.TestData_LHS[i].x8  << 8) | (t_byte32.TestData_LHS[i].x8  << 16) | (t_byte32.TestData_LHS[i].x8  << 24), n);
                    result &= test.x9  == (byte)math.rol(t_byte32.TestData_LHS[i].x9  | (t_byte32.TestData_LHS[i].x9  << 8) | (t_byte32.TestData_LHS[i].x9  << 16) | (t_byte32.TestData_LHS[i].x9  << 24), n);
                    result &= test.x10 == (byte)math.rol(t_byte32.TestData_LHS[i].x10 | (t_byte32.TestData_LHS[i].x10 << 8) | (t_byte32.TestData_LHS[i].x10 << 16) | (t_byte32.TestData_LHS[i].x10 << 24), n);
                    result &= test.x11 == (byte)math.rol(t_byte32.TestData_LHS[i].x11 | (t_byte32.TestData_LHS[i].x11 << 8) | (t_byte32.TestData_LHS[i].x11 << 16) | (t_byte32.TestData_LHS[i].x11 << 24), n);
                    result &= test.x12 == (byte)math.rol(t_byte32.TestData_LHS[i].x12 | (t_byte32.TestData_LHS[i].x12 << 8) | (t_byte32.TestData_LHS[i].x12 << 16) | (t_byte32.TestData_LHS[i].x12 << 24), n);
                    result &= test.x13 == (byte)math.rol(t_byte32.TestData_LHS[i].x13 | (t_byte32.TestData_LHS[i].x13 << 8) | (t_byte32.TestData_LHS[i].x13 << 16) | (t_byte32.TestData_LHS[i].x13 << 24), n);
                    result &= test.x14 == (byte)math.rol(t_byte32.TestData_LHS[i].x14 | (t_byte32.TestData_LHS[i].x14 << 8) | (t_byte32.TestData_LHS[i].x14 << 16) | (t_byte32.TestData_LHS[i].x14 << 24), n);
                    result &= test.x15 == (byte)math.rol(t_byte32.TestData_LHS[i].x15 | (t_byte32.TestData_LHS[i].x15 << 8) | (t_byte32.TestData_LHS[i].x15 << 16) | (t_byte32.TestData_LHS[i].x15 << 24), n);
                    result &= test.x16 == (byte)math.rol(t_byte32.TestData_LHS[i].x16 | (t_byte32.TestData_LHS[i].x16 << 8) | (t_byte32.TestData_LHS[i].x16 << 16) | (t_byte32.TestData_LHS[i].x16 << 24), n);
                    result &= test.x17 == (byte)math.rol(t_byte32.TestData_LHS[i].x17 | (t_byte32.TestData_LHS[i].x17 << 8) | (t_byte32.TestData_LHS[i].x17 << 16) | (t_byte32.TestData_LHS[i].x17 << 24), n);
                    result &= test.x18 == (byte)math.rol(t_byte32.TestData_LHS[i].x18 | (t_byte32.TestData_LHS[i].x18 << 8) | (t_byte32.TestData_LHS[i].x18 << 16) | (t_byte32.TestData_LHS[i].x18 << 24), n);
                    result &= test.x19 == (byte)math.rol(t_byte32.TestData_LHS[i].x19 | (t_byte32.TestData_LHS[i].x19 << 8) | (t_byte32.TestData_LHS[i].x19 << 16) | (t_byte32.TestData_LHS[i].x19 << 24), n);
                    result &= test.x20 == (byte)math.rol(t_byte32.TestData_LHS[i].x20 | (t_byte32.TestData_LHS[i].x20 << 8) | (t_byte32.TestData_LHS[i].x20 << 16) | (t_byte32.TestData_LHS[i].x20 << 24), n);
                    result &= test.x21 == (byte)math.rol(t_byte32.TestData_LHS[i].x21 | (t_byte32.TestData_LHS[i].x21 << 8) | (t_byte32.TestData_LHS[i].x21 << 16) | (t_byte32.TestData_LHS[i].x21 << 24), n);
                    result &= test.x22 == (byte)math.rol(t_byte32.TestData_LHS[i].x22 | (t_byte32.TestData_LHS[i].x22 << 8) | (t_byte32.TestData_LHS[i].x22 << 16) | (t_byte32.TestData_LHS[i].x22 << 24), n);
                    result &= test.x23 == (byte)math.rol(t_byte32.TestData_LHS[i].x23 | (t_byte32.TestData_LHS[i].x23 << 8) | (t_byte32.TestData_LHS[i].x23 << 16) | (t_byte32.TestData_LHS[i].x23 << 24), n);
                    result &= test.x24 == (byte)math.rol(t_byte32.TestData_LHS[i].x24 | (t_byte32.TestData_LHS[i].x24 << 8) | (t_byte32.TestData_LHS[i].x24 << 16) | (t_byte32.TestData_LHS[i].x24 << 24), n);
                    result &= test.x25 == (byte)math.rol(t_byte32.TestData_LHS[i].x25 | (t_byte32.TestData_LHS[i].x25 << 8) | (t_byte32.TestData_LHS[i].x25 << 16) | (t_byte32.TestData_LHS[i].x25 << 24), n);
                    result &= test.x26 == (byte)math.rol(t_byte32.TestData_LHS[i].x26 | (t_byte32.TestData_LHS[i].x26 << 8) | (t_byte32.TestData_LHS[i].x26 << 16) | (t_byte32.TestData_LHS[i].x26 << 24), n);
                    result &= test.x27 == (byte)math.rol(t_byte32.TestData_LHS[i].x27 | (t_byte32.TestData_LHS[i].x27 << 8) | (t_byte32.TestData_LHS[i].x27 << 16) | (t_byte32.TestData_LHS[i].x27 << 24), n);
                    result &= test.x28 == (byte)math.rol(t_byte32.TestData_LHS[i].x28 | (t_byte32.TestData_LHS[i].x28 << 8) | (t_byte32.TestData_LHS[i].x28 << 16) | (t_byte32.TestData_LHS[i].x28 << 24), n);
                    result &= test.x29 == (byte)math.rol(t_byte32.TestData_LHS[i].x29 | (t_byte32.TestData_LHS[i].x29 << 8) | (t_byte32.TestData_LHS[i].x29 << 16) | (t_byte32.TestData_LHS[i].x29 << 24), n);
                    result &= test.x30 == (byte)math.rol(t_byte32.TestData_LHS[i].x30 | (t_byte32.TestData_LHS[i].x30 << 8) | (t_byte32.TestData_LHS[i].x30 << 16) | (t_byte32.TestData_LHS[i].x30 << 24), n);
                    result &= test.x31 == (byte)math.rol(t_byte32.TestData_LHS[i].x31 | (t_byte32.TestData_LHS[i].x31 << 8) | (t_byte32.TestData_LHS[i].x31 << 16) | (t_byte32.TestData_LHS[i].x31 << 24), n);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void rol_ushort8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ushort8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 16);
                    ushort8 test = maxmath.rol(t_ushort8.TestData_LHS[i], n);

                    result &= test.x0 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x0 | (t_ushort8.TestData_LHS[i].x0 << 16), n);
                    result &= test.x1 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x1 | (t_ushort8.TestData_LHS[i].x1 << 16), n);
                    result &= test.x2 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x2 | (t_ushort8.TestData_LHS[i].x2 << 16), n);
                    result &= test.x3 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x3 | (t_ushort8.TestData_LHS[i].x3 << 16), n);
                    result &= test.x4 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x4 | (t_ushort8.TestData_LHS[i].x4 << 16), n);
                    result &= test.x5 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x5 | (t_ushort8.TestData_LHS[i].x5 << 16), n);
                    result &= test.x6 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x6 | (t_ushort8.TestData_LHS[i].x6 << 16), n);
                    result &= test.x7 == (ushort)math.rol(t_ushort8.TestData_LHS[i].x7 | (t_ushort8.TestData_LHS[i].x7 << 16), n);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_ushort16()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ushort16.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 16);
                    ushort16 test = maxmath.rol(t_ushort16.TestData_LHS[i], n);

                    result &= test.x0  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x0  | (t_ushort16.TestData_LHS[i].x0  << 16), n);
                    result &= test.x1  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x1  | (t_ushort16.TestData_LHS[i].x1  << 16), n);
                    result &= test.x2  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x2  | (t_ushort16.TestData_LHS[i].x2  << 16), n);
                    result &= test.x3  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x3  | (t_ushort16.TestData_LHS[i].x3  << 16), n);
                    result &= test.x4  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x4  | (t_ushort16.TestData_LHS[i].x4  << 16), n);
                    result &= test.x5  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x5  | (t_ushort16.TestData_LHS[i].x5  << 16), n);
                    result &= test.x6  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x6  | (t_ushort16.TestData_LHS[i].x6  << 16), n);
                    result &= test.x7  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x7  | (t_ushort16.TestData_LHS[i].x7  << 16), n);
                    result &= test.x8  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x8  | (t_ushort16.TestData_LHS[i].x8  << 16), n);
                    result &= test.x9  == (ushort)math.rol(t_ushort16.TestData_LHS[i].x9  | (t_ushort16.TestData_LHS[i].x9  << 16), n);
                    result &= test.x10 == (ushort)math.rol(t_ushort16.TestData_LHS[i].x10 | (t_ushort16.TestData_LHS[i].x10 << 16), n);
                    result &= test.x11 == (ushort)math.rol(t_ushort16.TestData_LHS[i].x11 | (t_ushort16.TestData_LHS[i].x11 << 16), n);
                    result &= test.x12 == (ushort)math.rol(t_ushort16.TestData_LHS[i].x12 | (t_ushort16.TestData_LHS[i].x12 << 16), n);
                    result &= test.x13 == (ushort)math.rol(t_ushort16.TestData_LHS[i].x13 | (t_ushort16.TestData_LHS[i].x13 << 16), n);
                    result &= test.x14 == (ushort)math.rol(t_ushort16.TestData_LHS[i].x14 | (t_ushort16.TestData_LHS[i].x14 << 16), n);
                    result &= test.x15 == (ushort)math.rol(t_ushort16.TestData_LHS[i].x15 | (t_ushort16.TestData_LHS[i].x15 << 16), n);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void rol_uint8()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_uint8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 32);
                    uint8 test = maxmath.rol(t_uint8.TestData_LHS[i], n);

                    result &= test.x0 == math.rol(t_uint8.TestData_LHS[i].x0, n);
                    result &= test.x1 == math.rol(t_uint8.TestData_LHS[i].x1, n);
                    result &= test.x2 == math.rol(t_uint8.TestData_LHS[i].x2, n);
                    result &= test.x3 == math.rol(t_uint8.TestData_LHS[i].x3, n);
                    result &= test.x4 == math.rol(t_uint8.TestData_LHS[i].x4, n);
                    result &= test.x5 == math.rol(t_uint8.TestData_LHS[i].x5, n);
                    result &= test.x6 == math.rol(t_uint8.TestData_LHS[i].x6, n);
                    result &= test.x7 == math.rol(t_uint8.TestData_LHS[i].x7, n);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void rol_ulong2()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ulong2.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 64);
                    ulong2 test = maxmath.rol(t_ulong2.TestData_LHS[i], n);

                    result &= test.x == math.rol(t_ulong2.TestData_LHS[i].x, n);
                    result &= test.y == math.rol(t_ulong2.TestData_LHS[i].y, n);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_ulong4()
        {
            bool result = true;
            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < t_ulong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    int n = rng.NextInt(0, 64);
                    ulong4 test = maxmath.rol(t_ulong4.TestData_LHS[i], n);

                    result &= test.x == math.rol(t_ulong4.TestData_LHS[i].x, n);
                    result &= test.y == math.rol(t_ulong4.TestData_LHS[i].y, n);
                    result &= test.z == math.rol(t_ulong4.TestData_LHS[i].z, n);
                    result &= test.w == math.rol(t_ulong4.TestData_LHS[i].w, n);
                }
            }

            Assert.AreEqual(true, result);
        }
    }
}