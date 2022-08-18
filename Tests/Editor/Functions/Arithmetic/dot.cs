using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class dot
    {
        [Test]
        public static void byte32Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte32.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.__byte32.TestData_LHS[i], Tests.__byte32.TestData_RHS[i]);
                
                result &= x == (Tests.__byte32.TestData_LHS[i].x0  * Tests.__byte32.TestData_RHS[i].x0  +
                                Tests.__byte32.TestData_LHS[i].x1  * Tests.__byte32.TestData_RHS[i].x1  +
                                Tests.__byte32.TestData_LHS[i].x2  * Tests.__byte32.TestData_RHS[i].x2  +
                                Tests.__byte32.TestData_LHS[i].x3  * Tests.__byte32.TestData_RHS[i].x3  +
                                Tests.__byte32.TestData_LHS[i].x4  * Tests.__byte32.TestData_RHS[i].x4  +
                                Tests.__byte32.TestData_LHS[i].x5  * Tests.__byte32.TestData_RHS[i].x5  +
                                Tests.__byte32.TestData_LHS[i].x6  * Tests.__byte32.TestData_RHS[i].x6  +
                                Tests.__byte32.TestData_LHS[i].x7  * Tests.__byte32.TestData_RHS[i].x7  +
                                Tests.__byte32.TestData_LHS[i].x8  * Tests.__byte32.TestData_RHS[i].x8  +
                                Tests.__byte32.TestData_LHS[i].x9  * Tests.__byte32.TestData_RHS[i].x9  +
                                Tests.__byte32.TestData_LHS[i].x10 * Tests.__byte32.TestData_RHS[i].x10 +
                                Tests.__byte32.TestData_LHS[i].x11 * Tests.__byte32.TestData_RHS[i].x11 +
                                Tests.__byte32.TestData_LHS[i].x12 * Tests.__byte32.TestData_RHS[i].x12 +
                                Tests.__byte32.TestData_LHS[i].x13 * Tests.__byte32.TestData_RHS[i].x13 +
                                Tests.__byte32.TestData_LHS[i].x14 * Tests.__byte32.TestData_RHS[i].x14 +
                                Tests.__byte32.TestData_LHS[i].x15 * Tests.__byte32.TestData_RHS[i].x15 +
                                Tests.__byte32.TestData_LHS[i].x16 * Tests.__byte32.TestData_RHS[i].x16 +
                                Tests.__byte32.TestData_LHS[i].x17 * Tests.__byte32.TestData_RHS[i].x17 +
                                Tests.__byte32.TestData_LHS[i].x18 * Tests.__byte32.TestData_RHS[i].x18 +
                                Tests.__byte32.TestData_LHS[i].x19 * Tests.__byte32.TestData_RHS[i].x19 +
                                Tests.__byte32.TestData_LHS[i].x20 * Tests.__byte32.TestData_RHS[i].x20 +
                                Tests.__byte32.TestData_LHS[i].x21 * Tests.__byte32.TestData_RHS[i].x21 +
                                Tests.__byte32.TestData_LHS[i].x22 * Tests.__byte32.TestData_RHS[i].x22 +
                                Tests.__byte32.TestData_LHS[i].x23 * Tests.__byte32.TestData_RHS[i].x23 +
                                Tests.__byte32.TestData_LHS[i].x24 * Tests.__byte32.TestData_RHS[i].x24 +
                                Tests.__byte32.TestData_LHS[i].x25 * Tests.__byte32.TestData_RHS[i].x25 +
                                Tests.__byte32.TestData_LHS[i].x26 * Tests.__byte32.TestData_RHS[i].x26 +
                                Tests.__byte32.TestData_LHS[i].x27 * Tests.__byte32.TestData_RHS[i].x27 +
                                Tests.__byte32.TestData_LHS[i].x28 * Tests.__byte32.TestData_RHS[i].x28 +
                                Tests.__byte32.TestData_LHS[i].x29 * Tests.__byte32.TestData_RHS[i].x29 +
                                Tests.__byte32.TestData_LHS[i].x30 * Tests.__byte32.TestData_RHS[i].x30 +
                                Tests.__byte32.TestData_LHS[i].x31 * Tests.__byte32.TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte32SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte32.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.__sbyte32.TestData_LHS[i], Tests.__sbyte32.TestData_RHS[i]);
                
                result &= x == (Tests.__sbyte32.TestData_LHS[i].x0  * Tests.__sbyte32.TestData_RHS[i].x0  +
                                Tests.__sbyte32.TestData_LHS[i].x1  * Tests.__sbyte32.TestData_RHS[i].x1  +
                                Tests.__sbyte32.TestData_LHS[i].x2  * Tests.__sbyte32.TestData_RHS[i].x2  +
                                Tests.__sbyte32.TestData_LHS[i].x3  * Tests.__sbyte32.TestData_RHS[i].x3  +
                                Tests.__sbyte32.TestData_LHS[i].x4  * Tests.__sbyte32.TestData_RHS[i].x4  +
                                Tests.__sbyte32.TestData_LHS[i].x5  * Tests.__sbyte32.TestData_RHS[i].x5  +
                                Tests.__sbyte32.TestData_LHS[i].x6  * Tests.__sbyte32.TestData_RHS[i].x6  +
                                Tests.__sbyte32.TestData_LHS[i].x7  * Tests.__sbyte32.TestData_RHS[i].x7  +
                                Tests.__sbyte32.TestData_LHS[i].x8  * Tests.__sbyte32.TestData_RHS[i].x8  +
                                Tests.__sbyte32.TestData_LHS[i].x9  * Tests.__sbyte32.TestData_RHS[i].x9  +
                                Tests.__sbyte32.TestData_LHS[i].x10 * Tests.__sbyte32.TestData_RHS[i].x10 +
                                Tests.__sbyte32.TestData_LHS[i].x11 * Tests.__sbyte32.TestData_RHS[i].x11 +
                                Tests.__sbyte32.TestData_LHS[i].x12 * Tests.__sbyte32.TestData_RHS[i].x12 +
                                Tests.__sbyte32.TestData_LHS[i].x13 * Tests.__sbyte32.TestData_RHS[i].x13 +
                                Tests.__sbyte32.TestData_LHS[i].x14 * Tests.__sbyte32.TestData_RHS[i].x14 +
                                Tests.__sbyte32.TestData_LHS[i].x15 * Tests.__sbyte32.TestData_RHS[i].x15 +
                                Tests.__sbyte32.TestData_LHS[i].x16 * Tests.__sbyte32.TestData_RHS[i].x16 +
                                Tests.__sbyte32.TestData_LHS[i].x17 * Tests.__sbyte32.TestData_RHS[i].x17 +
                                Tests.__sbyte32.TestData_LHS[i].x18 * Tests.__sbyte32.TestData_RHS[i].x18 +
                                Tests.__sbyte32.TestData_LHS[i].x19 * Tests.__sbyte32.TestData_RHS[i].x19 +
                                Tests.__sbyte32.TestData_LHS[i].x20 * Tests.__sbyte32.TestData_RHS[i].x20 +
                                Tests.__sbyte32.TestData_LHS[i].x21 * Tests.__sbyte32.TestData_RHS[i].x21 +
                                Tests.__sbyte32.TestData_LHS[i].x22 * Tests.__sbyte32.TestData_RHS[i].x22 +
                                Tests.__sbyte32.TestData_LHS[i].x23 * Tests.__sbyte32.TestData_RHS[i].x23 +
                                Tests.__sbyte32.TestData_LHS[i].x24 * Tests.__sbyte32.TestData_RHS[i].x24 +
                                Tests.__sbyte32.TestData_LHS[i].x25 * Tests.__sbyte32.TestData_RHS[i].x25 +
                                Tests.__sbyte32.TestData_LHS[i].x26 * Tests.__sbyte32.TestData_RHS[i].x26 +
                                Tests.__sbyte32.TestData_LHS[i].x27 * Tests.__sbyte32.TestData_RHS[i].x27 +
                                Tests.__sbyte32.TestData_LHS[i].x28 * Tests.__sbyte32.TestData_RHS[i].x28 +
                                Tests.__sbyte32.TestData_LHS[i].x29 * Tests.__sbyte32.TestData_RHS[i].x29 +
                                Tests.__sbyte32.TestData_LHS[i].x30 * Tests.__sbyte32.TestData_RHS[i].x30 +
                                Tests.__sbyte32.TestData_LHS[i].x31 * Tests.__sbyte32.TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short2.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.__short2.TestData_LHS[i], Tests.__short2.TestData_RHS[i]);

                result &= x == (Tests.__short2.TestData_LHS[i].x * Tests.__short2.TestData_RHS[i].x +
                                Tests.__short2.TestData_LHS[i].y * Tests.__short2.TestData_RHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short3.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.__short3.TestData_LHS[i], Tests.__short3.TestData_RHS[i]);

                result &= x == (Tests.__short3.TestData_LHS[i].x * Tests.__short3.TestData_RHS[i].x +
                                Tests.__short3.TestData_LHS[i].y * Tests.__short3.TestData_RHS[i].y +
                                Tests.__short3.TestData_LHS[i].z * Tests.__short3.TestData_RHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short4.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.__short4.TestData_LHS[i], Tests.__short4.TestData_RHS[i]);

                result &= x == (Tests.__short4.TestData_LHS[i].x * Tests.__short4.TestData_RHS[i].x +
                                Tests.__short4.TestData_LHS[i].y * Tests.__short4.TestData_RHS[i].y +
                                Tests.__short4.TestData_LHS[i].z * Tests.__short4.TestData_RHS[i].z +
                                Tests.__short4.TestData_LHS[i].w * Tests.__short4.TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short8.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.__short8.TestData_LHS[i], Tests.__short8.TestData_RHS[i]);

                result &= x == (Tests.__short8.TestData_LHS[i].x0 * Tests.__short8.TestData_RHS[i].x0 +
                                Tests.__short8.TestData_LHS[i].x1 * Tests.__short8.TestData_RHS[i].x1 +
                                Tests.__short8.TestData_LHS[i].x2 * Tests.__short8.TestData_RHS[i].x2 +
                                Tests.__short8.TestData_LHS[i].x3 * Tests.__short8.TestData_RHS[i].x3 +
                                Tests.__short8.TestData_LHS[i].x4 * Tests.__short8.TestData_RHS[i].x4 +
                                Tests.__short8.TestData_LHS[i].x5 * Tests.__short8.TestData_RHS[i].x5 +
                                Tests.__short8.TestData_LHS[i].x6 * Tests.__short8.TestData_RHS[i].x6 +
                                Tests.__short8.TestData_LHS[i].x7 * Tests.__short8.TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short16.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.__short16.TestData_LHS[i], Tests.__short16.TestData_RHS[i]);

                result &= x == (Tests.__short16.TestData_LHS[i].x0  * Tests.__short16.TestData_RHS[i].x0  +
                                Tests.__short16.TestData_LHS[i].x1  * Tests.__short16.TestData_RHS[i].x1  +
                                Tests.__short16.TestData_LHS[i].x2  * Tests.__short16.TestData_RHS[i].x2  +
                                Tests.__short16.TestData_LHS[i].x3  * Tests.__short16.TestData_RHS[i].x3  +
                                Tests.__short16.TestData_LHS[i].x4  * Tests.__short16.TestData_RHS[i].x4  +
                                Tests.__short16.TestData_LHS[i].x5  * Tests.__short16.TestData_RHS[i].x5  +
                                Tests.__short16.TestData_LHS[i].x6  * Tests.__short16.TestData_RHS[i].x6  +
                                Tests.__short16.TestData_LHS[i].x7  * Tests.__short16.TestData_RHS[i].x7  +
                                Tests.__short16.TestData_LHS[i].x8  * Tests.__short16.TestData_RHS[i].x8  +
                                Tests.__short16.TestData_LHS[i].x9  * Tests.__short16.TestData_RHS[i].x9  +
                                Tests.__short16.TestData_LHS[i].x10 * Tests.__short16.TestData_RHS[i].x10 +
                                Tests.__short16.TestData_LHS[i].x11 * Tests.__short16.TestData_RHS[i].x11 +
                                Tests.__short16.TestData_LHS[i].x12 * Tests.__short16.TestData_RHS[i].x12 +
                                Tests.__short16.TestData_LHS[i].x13 * Tests.__short16.TestData_RHS[i].x13 +
                                Tests.__short16.TestData_LHS[i].x14 * Tests.__short16.TestData_RHS[i].x14 +
                                Tests.__short16.TestData_LHS[i].x15 * Tests.__short16.TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort2.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.__ushort2.TestData_LHS[i], Tests.__ushort2.TestData_RHS[i]);

                result &= x == ((uint)Tests.__ushort2.TestData_LHS[i].x * Tests.__ushort2.TestData_RHS[i].x +
                                (uint)Tests.__ushort2.TestData_LHS[i].y * Tests.__ushort2.TestData_RHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort3.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.__ushort3.TestData_LHS[i], Tests.__ushort3.TestData_RHS[i]);

                result &= x == ((uint)Tests.__ushort3.TestData_LHS[i].x * Tests.__ushort3.TestData_RHS[i].x +
                                (uint)Tests.__ushort3.TestData_LHS[i].y * Tests.__ushort3.TestData_RHS[i].y +
                                (uint)Tests.__ushort3.TestData_LHS[i].z * Tests.__ushort3.TestData_RHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort4.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.__ushort4.TestData_LHS[i], Tests.__ushort4.TestData_RHS[i]);

                result &= x == ((uint)Tests.__ushort4.TestData_LHS[i].x * Tests.__ushort4.TestData_RHS[i].x +
                                (uint)Tests.__ushort4.TestData_LHS[i].y * Tests.__ushort4.TestData_RHS[i].y +
                                (uint)Tests.__ushort4.TestData_LHS[i].z * Tests.__ushort4.TestData_RHS[i].z +
                                (uint)Tests.__ushort4.TestData_LHS[i].w * Tests.__ushort4.TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort8.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.__ushort8.TestData_LHS[i], Tests.__ushort8.TestData_RHS[i]);

                result &= x == ((uint)Tests.__ushort8.TestData_LHS[i].x0 * Tests.__ushort8.TestData_RHS[i].x0 +
                                (uint)Tests.__ushort8.TestData_LHS[i].x1 * Tests.__ushort8.TestData_RHS[i].x1 +
                                (uint)Tests.__ushort8.TestData_LHS[i].x2 * Tests.__ushort8.TestData_RHS[i].x2 +
                                (uint)Tests.__ushort8.TestData_LHS[i].x3 * Tests.__ushort8.TestData_RHS[i].x3 +
                                (uint)Tests.__ushort8.TestData_LHS[i].x4 * Tests.__ushort8.TestData_RHS[i].x4 +
                                (uint)Tests.__ushort8.TestData_LHS[i].x5 * Tests.__ushort8.TestData_RHS[i].x5 +
                                (uint)Tests.__ushort8.TestData_LHS[i].x6 * Tests.__ushort8.TestData_RHS[i].x6 +
                                (uint)Tests.__ushort8.TestData_LHS[i].x7 * Tests.__ushort8.TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort16.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.__ushort16.TestData_LHS[i], Tests.__ushort16.TestData_RHS[i]);

                result &= x == ((uint)Tests.__ushort16.TestData_LHS[i].x0  * Tests.__ushort16.TestData_RHS[i].x0  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x1  * Tests.__ushort16.TestData_RHS[i].x1  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x2  * Tests.__ushort16.TestData_RHS[i].x2  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x3  * Tests.__ushort16.TestData_RHS[i].x3  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x4  * Tests.__ushort16.TestData_RHS[i].x4  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x5  * Tests.__ushort16.TestData_RHS[i].x5  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x6  * Tests.__ushort16.TestData_RHS[i].x6  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x7  * Tests.__ushort16.TestData_RHS[i].x7  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x8  * Tests.__ushort16.TestData_RHS[i].x8  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x9  * Tests.__ushort16.TestData_RHS[i].x9  +
                                (uint)Tests.__ushort16.TestData_LHS[i].x10 * Tests.__ushort16.TestData_RHS[i].x10 +
                                (uint)Tests.__ushort16.TestData_LHS[i].x11 * Tests.__ushort16.TestData_RHS[i].x11 +
                                (uint)Tests.__ushort16.TestData_LHS[i].x12 * Tests.__ushort16.TestData_RHS[i].x12 +
                                (uint)Tests.__ushort16.TestData_LHS[i].x13 * Tests.__ushort16.TestData_RHS[i].x13 +
                                (uint)Tests.__ushort16.TestData_LHS[i].x14 * Tests.__ushort16.TestData_RHS[i].x14 +
                                (uint)Tests.__ushort16.TestData_LHS[i].x15 * Tests.__ushort16.TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }
    }
}