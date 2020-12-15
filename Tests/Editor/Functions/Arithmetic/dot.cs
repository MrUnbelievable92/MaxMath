using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class dot
    {
        [Test]
        public static void Byte32Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte32.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.Byte32.TestData_LHS[i], Tests.Byte32.TestData_RHS[i]);
                
                result &= x == (Tests.Byte32.TestData_LHS[i].x0  * Tests.Byte32.TestData_RHS[i].x0  +
                                Tests.Byte32.TestData_LHS[i].x1  * Tests.Byte32.TestData_RHS[i].x1  +
                                Tests.Byte32.TestData_LHS[i].x2  * Tests.Byte32.TestData_RHS[i].x2  +
                                Tests.Byte32.TestData_LHS[i].x3  * Tests.Byte32.TestData_RHS[i].x3  +
                                Tests.Byte32.TestData_LHS[i].x4  * Tests.Byte32.TestData_RHS[i].x4  +
                                Tests.Byte32.TestData_LHS[i].x5  * Tests.Byte32.TestData_RHS[i].x5  +
                                Tests.Byte32.TestData_LHS[i].x6  * Tests.Byte32.TestData_RHS[i].x6  +
                                Tests.Byte32.TestData_LHS[i].x7  * Tests.Byte32.TestData_RHS[i].x7  +
                                Tests.Byte32.TestData_LHS[i].x8  * Tests.Byte32.TestData_RHS[i].x8  +
                                Tests.Byte32.TestData_LHS[i].x9  * Tests.Byte32.TestData_RHS[i].x9  +
                                Tests.Byte32.TestData_LHS[i].x10 * Tests.Byte32.TestData_RHS[i].x10 +
                                Tests.Byte32.TestData_LHS[i].x11 * Tests.Byte32.TestData_RHS[i].x11 +
                                Tests.Byte32.TestData_LHS[i].x12 * Tests.Byte32.TestData_RHS[i].x12 +
                                Tests.Byte32.TestData_LHS[i].x13 * Tests.Byte32.TestData_RHS[i].x13 +
                                Tests.Byte32.TestData_LHS[i].x14 * Tests.Byte32.TestData_RHS[i].x14 +
                                Tests.Byte32.TestData_LHS[i].x15 * Tests.Byte32.TestData_RHS[i].x15 +
                                Tests.Byte32.TestData_LHS[i].x16 * Tests.Byte32.TestData_RHS[i].x16 +
                                Tests.Byte32.TestData_LHS[i].x17 * Tests.Byte32.TestData_RHS[i].x17 +
                                Tests.Byte32.TestData_LHS[i].x18 * Tests.Byte32.TestData_RHS[i].x18 +
                                Tests.Byte32.TestData_LHS[i].x19 * Tests.Byte32.TestData_RHS[i].x19 +
                                Tests.Byte32.TestData_LHS[i].x20 * Tests.Byte32.TestData_RHS[i].x20 +
                                Tests.Byte32.TestData_LHS[i].x21 * Tests.Byte32.TestData_RHS[i].x21 +
                                Tests.Byte32.TestData_LHS[i].x22 * Tests.Byte32.TestData_RHS[i].x22 +
                                Tests.Byte32.TestData_LHS[i].x23 * Tests.Byte32.TestData_RHS[i].x23 +
                                Tests.Byte32.TestData_LHS[i].x24 * Tests.Byte32.TestData_RHS[i].x24 +
                                Tests.Byte32.TestData_LHS[i].x25 * Tests.Byte32.TestData_RHS[i].x25 +
                                Tests.Byte32.TestData_LHS[i].x26 * Tests.Byte32.TestData_RHS[i].x26 +
                                Tests.Byte32.TestData_LHS[i].x27 * Tests.Byte32.TestData_RHS[i].x27 +
                                Tests.Byte32.TestData_LHS[i].x28 * Tests.Byte32.TestData_RHS[i].x28 +
                                Tests.Byte32.TestData_LHS[i].x29 * Tests.Byte32.TestData_RHS[i].x29 +
                                Tests.Byte32.TestData_LHS[i].x30 * Tests.Byte32.TestData_RHS[i].x30 +
                                Tests.Byte32.TestData_LHS[i].x31 * Tests.Byte32.TestData_RHS[i].x31);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void SByte32SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.SByte32.TestData_LHS[i], Tests.SByte32.TestData_RHS[i]);
                
                result &= x == (Tests.SByte32.TestData_LHS[i].x0  * Tests.SByte32.TestData_RHS[i].x0  +
                                Tests.SByte32.TestData_LHS[i].x1  * Tests.SByte32.TestData_RHS[i].x1  +
                                Tests.SByte32.TestData_LHS[i].x2  * Tests.SByte32.TestData_RHS[i].x2  +
                                Tests.SByte32.TestData_LHS[i].x3  * Tests.SByte32.TestData_RHS[i].x3  +
                                Tests.SByte32.TestData_LHS[i].x4  * Tests.SByte32.TestData_RHS[i].x4  +
                                Tests.SByte32.TestData_LHS[i].x5  * Tests.SByte32.TestData_RHS[i].x5  +
                                Tests.SByte32.TestData_LHS[i].x6  * Tests.SByte32.TestData_RHS[i].x6  +
                                Tests.SByte32.TestData_LHS[i].x7  * Tests.SByte32.TestData_RHS[i].x7  +
                                Tests.SByte32.TestData_LHS[i].x8  * Tests.SByte32.TestData_RHS[i].x8  +
                                Tests.SByte32.TestData_LHS[i].x9  * Tests.SByte32.TestData_RHS[i].x9  +
                                Tests.SByte32.TestData_LHS[i].x10 * Tests.SByte32.TestData_RHS[i].x10 +
                                Tests.SByte32.TestData_LHS[i].x11 * Tests.SByte32.TestData_RHS[i].x11 +
                                Tests.SByte32.TestData_LHS[i].x12 * Tests.SByte32.TestData_RHS[i].x12 +
                                Tests.SByte32.TestData_LHS[i].x13 * Tests.SByte32.TestData_RHS[i].x13 +
                                Tests.SByte32.TestData_LHS[i].x14 * Tests.SByte32.TestData_RHS[i].x14 +
                                Tests.SByte32.TestData_LHS[i].x15 * Tests.SByte32.TestData_RHS[i].x15 +
                                Tests.SByte32.TestData_LHS[i].x16 * Tests.SByte32.TestData_RHS[i].x16 +
                                Tests.SByte32.TestData_LHS[i].x17 * Tests.SByte32.TestData_RHS[i].x17 +
                                Tests.SByte32.TestData_LHS[i].x18 * Tests.SByte32.TestData_RHS[i].x18 +
                                Tests.SByte32.TestData_LHS[i].x19 * Tests.SByte32.TestData_RHS[i].x19 +
                                Tests.SByte32.TestData_LHS[i].x20 * Tests.SByte32.TestData_RHS[i].x20 +
                                Tests.SByte32.TestData_LHS[i].x21 * Tests.SByte32.TestData_RHS[i].x21 +
                                Tests.SByte32.TestData_LHS[i].x22 * Tests.SByte32.TestData_RHS[i].x22 +
                                Tests.SByte32.TestData_LHS[i].x23 * Tests.SByte32.TestData_RHS[i].x23 +
                                Tests.SByte32.TestData_LHS[i].x24 * Tests.SByte32.TestData_RHS[i].x24 +
                                Tests.SByte32.TestData_LHS[i].x25 * Tests.SByte32.TestData_RHS[i].x25 +
                                Tests.SByte32.TestData_LHS[i].x26 * Tests.SByte32.TestData_RHS[i].x26 +
                                Tests.SByte32.TestData_LHS[i].x27 * Tests.SByte32.TestData_RHS[i].x27 +
                                Tests.SByte32.TestData_LHS[i].x28 * Tests.SByte32.TestData_RHS[i].x28 +
                                Tests.SByte32.TestData_LHS[i].x29 * Tests.SByte32.TestData_RHS[i].x29 +
                                Tests.SByte32.TestData_LHS[i].x30 * Tests.SByte32.TestData_RHS[i].x30 +
                                Tests.SByte32.TestData_LHS[i].x31 * Tests.SByte32.TestData_RHS[i].x31);
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.Short2.TestData_LHS[i], Tests.Short2.TestData_RHS[i]);

                result &= x == (Tests.Short2.TestData_LHS[i].x * Tests.Short2.TestData_RHS[i].x +
                                Tests.Short2.TestData_LHS[i].y * Tests.Short2.TestData_RHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.Short3.TestData_LHS[i], Tests.Short3.TestData_RHS[i]);

                result &= x == (Tests.Short3.TestData_LHS[i].x * Tests.Short3.TestData_RHS[i].x +
                                Tests.Short3.TestData_LHS[i].y * Tests.Short3.TestData_RHS[i].y +
                                Tests.Short3.TestData_LHS[i].z * Tests.Short3.TestData_RHS[i].z);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.Short4.TestData_LHS[i], Tests.Short4.TestData_RHS[i]);

                result &= x == (Tests.Short4.TestData_LHS[i].x * Tests.Short4.TestData_RHS[i].x +
                                Tests.Short4.TestData_LHS[i].y * Tests.Short4.TestData_RHS[i].y +
                                Tests.Short4.TestData_LHS[i].z * Tests.Short4.TestData_RHS[i].z +
                                Tests.Short4.TestData_LHS[i].w * Tests.Short4.TestData_RHS[i].w);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.Short8.TestData_LHS[i], Tests.Short8.TestData_RHS[i]);

                result &= x == (Tests.Short8.TestData_LHS[i].x0 * Tests.Short8.TestData_RHS[i].x0 +
                                Tests.Short8.TestData_LHS[i].x1 * Tests.Short8.TestData_RHS[i].x1 +
                                Tests.Short8.TestData_LHS[i].x2 * Tests.Short8.TestData_RHS[i].x2 +
                                Tests.Short8.TestData_LHS[i].x3 * Tests.Short8.TestData_RHS[i].x3 +
                                Tests.Short8.TestData_LHS[i].x4 * Tests.Short8.TestData_RHS[i].x4 +
                                Tests.Short8.TestData_LHS[i].x5 * Tests.Short8.TestData_RHS[i].x5 +
                                Tests.Short8.TestData_LHS[i].x6 * Tests.Short8.TestData_RHS[i].x6 +
                                Tests.Short8.TestData_LHS[i].x7 * Tests.Short8.TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                int x = maxmath.dot(Tests.Short16.TestData_LHS[i], Tests.Short16.TestData_RHS[i]);

                result &= x == (Tests.Short16.TestData_LHS[i].x0  * Tests.Short16.TestData_RHS[i].x0  +
                                Tests.Short16.TestData_LHS[i].x1  * Tests.Short16.TestData_RHS[i].x1  +
                                Tests.Short16.TestData_LHS[i].x2  * Tests.Short16.TestData_RHS[i].x2  +
                                Tests.Short16.TestData_LHS[i].x3  * Tests.Short16.TestData_RHS[i].x3  +
                                Tests.Short16.TestData_LHS[i].x4  * Tests.Short16.TestData_RHS[i].x4  +
                                Tests.Short16.TestData_LHS[i].x5  * Tests.Short16.TestData_RHS[i].x5  +
                                Tests.Short16.TestData_LHS[i].x6  * Tests.Short16.TestData_RHS[i].x6  +
                                Tests.Short16.TestData_LHS[i].x7  * Tests.Short16.TestData_RHS[i].x7  +
                                Tests.Short16.TestData_LHS[i].x8  * Tests.Short16.TestData_RHS[i].x8  +
                                Tests.Short16.TestData_LHS[i].x9  * Tests.Short16.TestData_RHS[i].x9  +
                                Tests.Short16.TestData_LHS[i].x10 * Tests.Short16.TestData_RHS[i].x10 +
                                Tests.Short16.TestData_LHS[i].x11 * Tests.Short16.TestData_RHS[i].x11 +
                                Tests.Short16.TestData_LHS[i].x12 * Tests.Short16.TestData_RHS[i].x12 +
                                Tests.Short16.TestData_LHS[i].x13 * Tests.Short16.TestData_RHS[i].x13 +
                                Tests.Short16.TestData_LHS[i].x14 * Tests.Short16.TestData_RHS[i].x14 +
                                Tests.Short16.TestData_LHS[i].x15 * Tests.Short16.TestData_RHS[i].x15);
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort2.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.UShort2.TestData_LHS[i], Tests.UShort2.TestData_RHS[i]);

                result &= x == ((uint)Tests.UShort2.TestData_LHS[i].x * Tests.UShort2.TestData_RHS[i].x +
                                (uint)Tests.UShort2.TestData_LHS[i].y * Tests.UShort2.TestData_RHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort3.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.UShort3.TestData_LHS[i], Tests.UShort3.TestData_RHS[i]);

                result &= x == ((uint)Tests.UShort3.TestData_LHS[i].x * Tests.UShort3.TestData_RHS[i].x +
                                (uint)Tests.UShort3.TestData_LHS[i].y * Tests.UShort3.TestData_RHS[i].y +
                                (uint)Tests.UShort3.TestData_LHS[i].z * Tests.UShort3.TestData_RHS[i].z);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort4.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.UShort4.TestData_LHS[i], Tests.UShort4.TestData_RHS[i]);

                result &= x == ((uint)Tests.UShort4.TestData_LHS[i].x * Tests.UShort4.TestData_RHS[i].x +
                                (uint)Tests.UShort4.TestData_LHS[i].y * Tests.UShort4.TestData_RHS[i].y +
                                (uint)Tests.UShort4.TestData_LHS[i].z * Tests.UShort4.TestData_RHS[i].z +
                                (uint)Tests.UShort4.TestData_LHS[i].w * Tests.UShort4.TestData_RHS[i].w);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.UShort8.TestData_LHS[i], Tests.UShort8.TestData_RHS[i]);

                result &= x == ((uint)Tests.UShort8.TestData_LHS[i].x0 * Tests.UShort8.TestData_RHS[i].x0 +
                                (uint)Tests.UShort8.TestData_LHS[i].x1 * Tests.UShort8.TestData_RHS[i].x1 +
                                (uint)Tests.UShort8.TestData_LHS[i].x2 * Tests.UShort8.TestData_RHS[i].x2 +
                                (uint)Tests.UShort8.TestData_LHS[i].x3 * Tests.UShort8.TestData_RHS[i].x3 +
                                (uint)Tests.UShort8.TestData_LHS[i].x4 * Tests.UShort8.TestData_RHS[i].x4 +
                                (uint)Tests.UShort8.TestData_LHS[i].x5 * Tests.UShort8.TestData_RHS[i].x5 +
                                (uint)Tests.UShort8.TestData_LHS[i].x6 * Tests.UShort8.TestData_RHS[i].x6 +
                                (uint)Tests.UShort8.TestData_LHS[i].x7 * Tests.UShort8.TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                uint x = maxmath.dot(Tests.UShort16.TestData_LHS[i], Tests.UShort16.TestData_RHS[i]);

                result &= x == ((uint)Tests.UShort16.TestData_LHS[i].x0  * Tests.UShort16.TestData_RHS[i].x0  +
                                (uint)Tests.UShort16.TestData_LHS[i].x1  * Tests.UShort16.TestData_RHS[i].x1  +
                                (uint)Tests.UShort16.TestData_LHS[i].x2  * Tests.UShort16.TestData_RHS[i].x2  +
                                (uint)Tests.UShort16.TestData_LHS[i].x3  * Tests.UShort16.TestData_RHS[i].x3  +
                                (uint)Tests.UShort16.TestData_LHS[i].x4  * Tests.UShort16.TestData_RHS[i].x4  +
                                (uint)Tests.UShort16.TestData_LHS[i].x5  * Tests.UShort16.TestData_RHS[i].x5  +
                                (uint)Tests.UShort16.TestData_LHS[i].x6  * Tests.UShort16.TestData_RHS[i].x6  +
                                (uint)Tests.UShort16.TestData_LHS[i].x7  * Tests.UShort16.TestData_RHS[i].x7  +
                                (uint)Tests.UShort16.TestData_LHS[i].x8  * Tests.UShort16.TestData_RHS[i].x8  +
                                (uint)Tests.UShort16.TestData_LHS[i].x9  * Tests.UShort16.TestData_RHS[i].x9  +
                                (uint)Tests.UShort16.TestData_LHS[i].x10 * Tests.UShort16.TestData_RHS[i].x10 +
                                (uint)Tests.UShort16.TestData_LHS[i].x11 * Tests.UShort16.TestData_RHS[i].x11 +
                                (uint)Tests.UShort16.TestData_LHS[i].x12 * Tests.UShort16.TestData_RHS[i].x12 +
                                (uint)Tests.UShort16.TestData_LHS[i].x13 * Tests.UShort16.TestData_RHS[i].x13 +
                                (uint)Tests.UShort16.TestData_LHS[i].x14 * Tests.UShort16.TestData_RHS[i].x14 +
                                (uint)Tests.UShort16.TestData_LHS[i].x15 * Tests.UShort16.TestData_RHS[i].x15);
            }

            Assert.AreEqual(result, true);
        }
    }
}