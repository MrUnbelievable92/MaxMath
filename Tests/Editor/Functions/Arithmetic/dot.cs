using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class f_dot
    {
        [Test]
        public static void _byte32Byte32()
        {
            bool result = true;

            for (int i = 0; i < t_byte32.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(t_byte32.TestData_LHS[i], t_byte32.TestData_RHS[i]);

                result &= x == (t_byte32.TestData_LHS[i].x0  * t_byte32.TestData_RHS[i].x0  +
                                t_byte32.TestData_LHS[i].x1  * t_byte32.TestData_RHS[i].x1  +
                                t_byte32.TestData_LHS[i].x2  * t_byte32.TestData_RHS[i].x2  +
                                t_byte32.TestData_LHS[i].x3  * t_byte32.TestData_RHS[i].x3  +
                                t_byte32.TestData_LHS[i].x4  * t_byte32.TestData_RHS[i].x4  +
                                t_byte32.TestData_LHS[i].x5  * t_byte32.TestData_RHS[i].x5  +
                                t_byte32.TestData_LHS[i].x6  * t_byte32.TestData_RHS[i].x6  +
                                t_byte32.TestData_LHS[i].x7  * t_byte32.TestData_RHS[i].x7  +
                                t_byte32.TestData_LHS[i].x8  * t_byte32.TestData_RHS[i].x8  +
                                t_byte32.TestData_LHS[i].x9  * t_byte32.TestData_RHS[i].x9  +
                                t_byte32.TestData_LHS[i].x10 * t_byte32.TestData_RHS[i].x10 +
                                t_byte32.TestData_LHS[i].x11 * t_byte32.TestData_RHS[i].x11 +
                                t_byte32.TestData_LHS[i].x12 * t_byte32.TestData_RHS[i].x12 +
                                t_byte32.TestData_LHS[i].x13 * t_byte32.TestData_RHS[i].x13 +
                                t_byte32.TestData_LHS[i].x14 * t_byte32.TestData_RHS[i].x14 +
                                t_byte32.TestData_LHS[i].x15 * t_byte32.TestData_RHS[i].x15 +
                                t_byte32.TestData_LHS[i].x16 * t_byte32.TestData_RHS[i].x16 +
                                t_byte32.TestData_LHS[i].x17 * t_byte32.TestData_RHS[i].x17 +
                                t_byte32.TestData_LHS[i].x18 * t_byte32.TestData_RHS[i].x18 +
                                t_byte32.TestData_LHS[i].x19 * t_byte32.TestData_RHS[i].x19 +
                                t_byte32.TestData_LHS[i].x20 * t_byte32.TestData_RHS[i].x20 +
                                t_byte32.TestData_LHS[i].x21 * t_byte32.TestData_RHS[i].x21 +
                                t_byte32.TestData_LHS[i].x22 * t_byte32.TestData_RHS[i].x22 +
                                t_byte32.TestData_LHS[i].x23 * t_byte32.TestData_RHS[i].x23 +
                                t_byte32.TestData_LHS[i].x24 * t_byte32.TestData_RHS[i].x24 +
                                t_byte32.TestData_LHS[i].x25 * t_byte32.TestData_RHS[i].x25 +
                                t_byte32.TestData_LHS[i].x26 * t_byte32.TestData_RHS[i].x26 +
                                t_byte32.TestData_LHS[i].x27 * t_byte32.TestData_RHS[i].x27 +
                                t_byte32.TestData_LHS[i].x28 * t_byte32.TestData_RHS[i].x28 +
                                t_byte32.TestData_LHS[i].x29 * t_byte32.TestData_RHS[i].x29 +
                                t_byte32.TestData_LHS[i].x30 * t_byte32.TestData_RHS[i].x30 +
                                t_byte32.TestData_LHS[i].x31 * t_byte32.TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte32SByte32()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte32.NUM_TESTS; i++)
            {
                int x = maxmath.dot(t_sbyte32.TestData_LHS[i], t_sbyte32.TestData_RHS[i]);

                result &= x == (t_sbyte32.TestData_LHS[i].x0  * t_sbyte32.TestData_RHS[i].x0  +
                                t_sbyte32.TestData_LHS[i].x1  * t_sbyte32.TestData_RHS[i].x1  +
                                t_sbyte32.TestData_LHS[i].x2  * t_sbyte32.TestData_RHS[i].x2  +
                                t_sbyte32.TestData_LHS[i].x3  * t_sbyte32.TestData_RHS[i].x3  +
                                t_sbyte32.TestData_LHS[i].x4  * t_sbyte32.TestData_RHS[i].x4  +
                                t_sbyte32.TestData_LHS[i].x5  * t_sbyte32.TestData_RHS[i].x5  +
                                t_sbyte32.TestData_LHS[i].x6  * t_sbyte32.TestData_RHS[i].x6  +
                                t_sbyte32.TestData_LHS[i].x7  * t_sbyte32.TestData_RHS[i].x7  +
                                t_sbyte32.TestData_LHS[i].x8  * t_sbyte32.TestData_RHS[i].x8  +
                                t_sbyte32.TestData_LHS[i].x9  * t_sbyte32.TestData_RHS[i].x9  +
                                t_sbyte32.TestData_LHS[i].x10 * t_sbyte32.TestData_RHS[i].x10 +
                                t_sbyte32.TestData_LHS[i].x11 * t_sbyte32.TestData_RHS[i].x11 +
                                t_sbyte32.TestData_LHS[i].x12 * t_sbyte32.TestData_RHS[i].x12 +
                                t_sbyte32.TestData_LHS[i].x13 * t_sbyte32.TestData_RHS[i].x13 +
                                t_sbyte32.TestData_LHS[i].x14 * t_sbyte32.TestData_RHS[i].x14 +
                                t_sbyte32.TestData_LHS[i].x15 * t_sbyte32.TestData_RHS[i].x15 +
                                t_sbyte32.TestData_LHS[i].x16 * t_sbyte32.TestData_RHS[i].x16 +
                                t_sbyte32.TestData_LHS[i].x17 * t_sbyte32.TestData_RHS[i].x17 +
                                t_sbyte32.TestData_LHS[i].x18 * t_sbyte32.TestData_RHS[i].x18 +
                                t_sbyte32.TestData_LHS[i].x19 * t_sbyte32.TestData_RHS[i].x19 +
                                t_sbyte32.TestData_LHS[i].x20 * t_sbyte32.TestData_RHS[i].x20 +
                                t_sbyte32.TestData_LHS[i].x21 * t_sbyte32.TestData_RHS[i].x21 +
                                t_sbyte32.TestData_LHS[i].x22 * t_sbyte32.TestData_RHS[i].x22 +
                                t_sbyte32.TestData_LHS[i].x23 * t_sbyte32.TestData_RHS[i].x23 +
                                t_sbyte32.TestData_LHS[i].x24 * t_sbyte32.TestData_RHS[i].x24 +
                                t_sbyte32.TestData_LHS[i].x25 * t_sbyte32.TestData_RHS[i].x25 +
                                t_sbyte32.TestData_LHS[i].x26 * t_sbyte32.TestData_RHS[i].x26 +
                                t_sbyte32.TestData_LHS[i].x27 * t_sbyte32.TestData_RHS[i].x27 +
                                t_sbyte32.TestData_LHS[i].x28 * t_sbyte32.TestData_RHS[i].x28 +
                                t_sbyte32.TestData_LHS[i].x29 * t_sbyte32.TestData_RHS[i].x29 +
                                t_sbyte32.TestData_LHS[i].x30 * t_sbyte32.TestData_RHS[i].x30 +
                                t_sbyte32.TestData_LHS[i].x31 * t_sbyte32.TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _short2()
        {
            bool result = true;

            for (int i = 0; i < t_short2.NUM_TESTS; i++)
            {
                int x = maxmath.dot(t_short2.TestData_LHS[i], t_short2.TestData_RHS[i]);

                result &= x == (t_short2.TestData_LHS[i].x * t_short2.TestData_RHS[i].x +
                                t_short2.TestData_LHS[i].y * t_short2.TestData_RHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short3()
        {
            bool result = true;

            for (int i = 0; i < t_short3.NUM_TESTS; i++)
            {
                int x = maxmath.dot(t_short3.TestData_LHS[i], t_short3.TestData_RHS[i]);

                result &= x == (t_short3.TestData_LHS[i].x * t_short3.TestData_RHS[i].x +
                                t_short3.TestData_LHS[i].y * t_short3.TestData_RHS[i].y +
                                t_short3.TestData_LHS[i].z * t_short3.TestData_RHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short4()
        {
            bool result = true;

            for (int i = 0; i < t_short4.NUM_TESTS; i++)
            {
                int x = maxmath.dot(t_short4.TestData_LHS[i], t_short4.TestData_RHS[i]);

                result &= x == (t_short4.TestData_LHS[i].x * t_short4.TestData_RHS[i].x +
                                t_short4.TestData_LHS[i].y * t_short4.TestData_RHS[i].y +
                                t_short4.TestData_LHS[i].z * t_short4.TestData_RHS[i].z +
                                t_short4.TestData_LHS[i].w * t_short4.TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short8()
        {
            bool result = true;

            for (int i = 0; i < t_short8.NUM_TESTS; i++)
            {
                int x = maxmath.dot(t_short8.TestData_LHS[i], t_short8.TestData_RHS[i]);

                result &= x == (t_short8.TestData_LHS[i].x0 * t_short8.TestData_RHS[i].x0 +
                                t_short8.TestData_LHS[i].x1 * t_short8.TestData_RHS[i].x1 +
                                t_short8.TestData_LHS[i].x2 * t_short8.TestData_RHS[i].x2 +
                                t_short8.TestData_LHS[i].x3 * t_short8.TestData_RHS[i].x3 +
                                t_short8.TestData_LHS[i].x4 * t_short8.TestData_RHS[i].x4 +
                                t_short8.TestData_LHS[i].x5 * t_short8.TestData_RHS[i].x5 +
                                t_short8.TestData_LHS[i].x6 * t_short8.TestData_RHS[i].x6 +
                                t_short8.TestData_LHS[i].x7 * t_short8.TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short16()
        {
            bool result = true;

            for (int i = 0; i < t_short16.NUM_TESTS; i++)
            {
                int x = maxmath.dot(t_short16.TestData_LHS[i], t_short16.TestData_RHS[i]);

                result &= x == (t_short16.TestData_LHS[i].x0  * t_short16.TestData_RHS[i].x0  +
                                t_short16.TestData_LHS[i].x1  * t_short16.TestData_RHS[i].x1  +
                                t_short16.TestData_LHS[i].x2  * t_short16.TestData_RHS[i].x2  +
                                t_short16.TestData_LHS[i].x3  * t_short16.TestData_RHS[i].x3  +
                                t_short16.TestData_LHS[i].x4  * t_short16.TestData_RHS[i].x4  +
                                t_short16.TestData_LHS[i].x5  * t_short16.TestData_RHS[i].x5  +
                                t_short16.TestData_LHS[i].x6  * t_short16.TestData_RHS[i].x6  +
                                t_short16.TestData_LHS[i].x7  * t_short16.TestData_RHS[i].x7  +
                                t_short16.TestData_LHS[i].x8  * t_short16.TestData_RHS[i].x8  +
                                t_short16.TestData_LHS[i].x9  * t_short16.TestData_RHS[i].x9  +
                                t_short16.TestData_LHS[i].x10 * t_short16.TestData_RHS[i].x10 +
                                t_short16.TestData_LHS[i].x11 * t_short16.TestData_RHS[i].x11 +
                                t_short16.TestData_LHS[i].x12 * t_short16.TestData_RHS[i].x12 +
                                t_short16.TestData_LHS[i].x13 * t_short16.TestData_RHS[i].x13 +
                                t_short16.TestData_LHS[i].x14 * t_short16.TestData_RHS[i].x14 +
                                t_short16.TestData_LHS[i].x15 * t_short16.TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort2()
        {
            bool result = true;

            for (int i = 0; i < t_ushort2.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(t_ushort2.TestData_LHS[i], t_ushort2.TestData_RHS[i]);

                result &= x == ((uint)t_ushort2.TestData_LHS[i].x * t_ushort2.TestData_RHS[i].x +
                                (uint)t_ushort2.TestData_LHS[i].y * t_ushort2.TestData_RHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort3()
        {
            bool result = true;

            for (int i = 0; i < t_ushort3.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(t_ushort3.TestData_LHS[i], t_ushort3.TestData_RHS[i]);

                result &= x == ((uint)t_ushort3.TestData_LHS[i].x * t_ushort3.TestData_RHS[i].x +
                                (uint)t_ushort3.TestData_LHS[i].y * t_ushort3.TestData_RHS[i].y +
                                (uint)t_ushort3.TestData_LHS[i].z * t_ushort3.TestData_RHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort4()
        {
            bool result = true;

            for (int i = 0; i < t_ushort4.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(t_ushort4.TestData_LHS[i], t_ushort4.TestData_RHS[i]);

                result &= x == ((uint)t_ushort4.TestData_LHS[i].x * t_ushort4.TestData_RHS[i].x +
                                (uint)t_ushort4.TestData_LHS[i].y * t_ushort4.TestData_RHS[i].y +
                                (uint)t_ushort4.TestData_LHS[i].z * t_ushort4.TestData_RHS[i].z +
                                (uint)t_ushort4.TestData_LHS[i].w * t_ushort4.TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort8()
        {
            bool result = true;

            for (int i = 0; i < t_ushort8.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(t_ushort8.TestData_LHS[i], t_ushort8.TestData_RHS[i]);

                result &= x == ((uint)t_ushort8.TestData_LHS[i].x0 * t_ushort8.TestData_RHS[i].x0 +
                                (uint)t_ushort8.TestData_LHS[i].x1 * t_ushort8.TestData_RHS[i].x1 +
                                (uint)t_ushort8.TestData_LHS[i].x2 * t_ushort8.TestData_RHS[i].x2 +
                                (uint)t_ushort8.TestData_LHS[i].x3 * t_ushort8.TestData_RHS[i].x3 +
                                (uint)t_ushort8.TestData_LHS[i].x4 * t_ushort8.TestData_RHS[i].x4 +
                                (uint)t_ushort8.TestData_LHS[i].x5 * t_ushort8.TestData_RHS[i].x5 +
                                (uint)t_ushort8.TestData_LHS[i].x6 * t_ushort8.TestData_RHS[i].x6 +
                                (uint)t_ushort8.TestData_LHS[i].x7 * t_ushort8.TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort16()
        {
            bool result = true;

            for (int i = 0; i < t_ushort16.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(t_ushort16.TestData_LHS[i], t_ushort16.TestData_RHS[i]);

                result &= x == ((uint)t_ushort16.TestData_LHS[i].x0  * t_ushort16.TestData_RHS[i].x0  +
                                (uint)t_ushort16.TestData_LHS[i].x1  * t_ushort16.TestData_RHS[i].x1  +
                                (uint)t_ushort16.TestData_LHS[i].x2  * t_ushort16.TestData_RHS[i].x2  +
                                (uint)t_ushort16.TestData_LHS[i].x3  * t_ushort16.TestData_RHS[i].x3  +
                                (uint)t_ushort16.TestData_LHS[i].x4  * t_ushort16.TestData_RHS[i].x4  +
                                (uint)t_ushort16.TestData_LHS[i].x5  * t_ushort16.TestData_RHS[i].x5  +
                                (uint)t_ushort16.TestData_LHS[i].x6  * t_ushort16.TestData_RHS[i].x6  +
                                (uint)t_ushort16.TestData_LHS[i].x7  * t_ushort16.TestData_RHS[i].x7  +
                                (uint)t_ushort16.TestData_LHS[i].x8  * t_ushort16.TestData_RHS[i].x8  +
                                (uint)t_ushort16.TestData_LHS[i].x9  * t_ushort16.TestData_RHS[i].x9  +
                                (uint)t_ushort16.TestData_LHS[i].x10 * t_ushort16.TestData_RHS[i].x10 +
                                (uint)t_ushort16.TestData_LHS[i].x11 * t_ushort16.TestData_RHS[i].x11 +
                                (uint)t_ushort16.TestData_LHS[i].x12 * t_ushort16.TestData_RHS[i].x12 +
                                (uint)t_ushort16.TestData_LHS[i].x13 * t_ushort16.TestData_RHS[i].x13 +
                                (uint)t_ushort16.TestData_LHS[i].x14 * t_ushort16.TestData_RHS[i].x14 +
                                (uint)t_ushort16.TestData_LHS[i].x15 * t_ushort16.TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }
    }
}