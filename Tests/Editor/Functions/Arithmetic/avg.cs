using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class avg
    {
        [Test]
        public static void Byte2()
        {
            for (int i = 0; i < Tests.__byte2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__byte2.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__byte2.TestData_LHS[i])) / 2);
            }
        }

        [Test]
        public static void Byte3()
        {
            for (int i = 0; i < Tests.__byte3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__byte3.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__byte3.TestData_LHS[i])) / 3);
            }
        }

        [Test]
        public static void Byte4()
        {
            for (int i = 0; i < Tests.__byte4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__byte4.TestData_LHS[i]),
                                (1u + maxmath.csum(Tests.__byte4.TestData_LHS[i])) / 4u);
            }
        }

        [Test]
        public static void Byte8()
        {
            for (int i = 0; i < Tests.__byte8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__byte8.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__byte8.TestData_LHS[i])) / 8);
            }
        }

        [Test]
        public static void Byte16()
        {
            for (int i = 0; i < Tests.__byte16.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__byte16.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__byte16.TestData_LHS[i])) / 16);
            }
        }

        [Test]
        public static void Byte32()
        {
            for (int i = 0; i < Tests.__byte32.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__byte32.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__byte32.TestData_LHS[i])) / 32);
            }
        }


        [Test]
        public static void UShort2()
        {
            for (int i = 0; i < Tests.__ushort2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__ushort2.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__ushort2.TestData_LHS[i])) / 2);
            }
        }

        [Test]
        public static void UShort3()
        {
            for (int i = 0; i < Tests.__ushort3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__ushort3.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__ushort3.TestData_LHS[i])) / 3);
            }
        }

        [Test]
        public static void UShort4()
        {
            for (int i = 0; i < Tests.__ushort4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__ushort4.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__ushort4.TestData_LHS[i])) / 4);
            }
        }

        [Test]
        public static void UShort8()
        {
            for (int i = 0; i < Tests.__ushort8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__ushort8.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__ushort8.TestData_LHS[i])) / 8);
            }
        }

        [Test]
        public static void UShort16()
        {
            for (int i = 0; i < Tests.__ushort16.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.avg(Tests.__ushort16.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__ushort16.TestData_LHS[i])) / 16);
            }
        }


        [Test]
        public static void byte2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte2.NUM_TESTS; i++)
            {
                short2 x = maxmath.avg(Tests.__byte2.TestData_LHS[i], Tests.__byte2.TestData_RHS[i]);

                result &= x.x == (((Tests.__byte2.TestData_LHS[i].x + Tests.__byte2.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__byte2.TestData_LHS[i].x + Tests.__byte2.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__byte2.TestData_LHS[i].y + Tests.__byte2.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__byte2.TestData_LHS[i].y + Tests.__byte2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte3.NUM_TESTS; i++)
            {
                short3 x = maxmath.avg(Tests.__byte3.TestData_LHS[i], Tests.__byte3.TestData_RHS[i]);

                result &= x.x == (((Tests.__byte3.TestData_LHS[i].x + Tests.__byte3.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__byte3.TestData_LHS[i].x + Tests.__byte3.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__byte3.TestData_LHS[i].y + Tests.__byte3.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__byte3.TestData_LHS[i].y + Tests.__byte3.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.__byte3.TestData_LHS[i].z + Tests.__byte3.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.__byte3.TestData_LHS[i].z + Tests.__byte3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte4.NUM_TESTS; i++)
            {
                short4 x = maxmath.avg(Tests.__byte4.TestData_LHS[i], Tests.__byte4.TestData_RHS[i]);

                result &= x.x == (((Tests.__byte4.TestData_LHS[i].x + Tests.__byte4.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__byte4.TestData_LHS[i].x + Tests.__byte4.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__byte4.TestData_LHS[i].y + Tests.__byte4.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__byte4.TestData_LHS[i].y + Tests.__byte4.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.__byte4.TestData_LHS[i].z + Tests.__byte4.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.__byte4.TestData_LHS[i].z + Tests.__byte4.TestData_RHS[i].z) / 2;
                result &= x.w == (((Tests.__byte4.TestData_LHS[i].w + Tests.__byte4.TestData_RHS[i].w) > 0 ? 1 : -1) + Tests.__byte4.TestData_LHS[i].w + Tests.__byte4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte8.NUM_TESTS; i++)
            {
                short8 x = maxmath.avg(Tests.__byte8.TestData_LHS[i], Tests.__byte8.TestData_RHS[i]);

                result &= x.x0 == (((Tests.__byte8.TestData_LHS[i].x0 + Tests.__byte8.TestData_RHS[i].x0) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x0 + Tests.__byte8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (((Tests.__byte8.TestData_LHS[i].x1 + Tests.__byte8.TestData_RHS[i].x1) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x1 + Tests.__byte8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (((Tests.__byte8.TestData_LHS[i].x2 + Tests.__byte8.TestData_RHS[i].x2) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x2 + Tests.__byte8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (((Tests.__byte8.TestData_LHS[i].x3 + Tests.__byte8.TestData_RHS[i].x3) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x3 + Tests.__byte8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (((Tests.__byte8.TestData_LHS[i].x4 + Tests.__byte8.TestData_RHS[i].x4) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x4 + Tests.__byte8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (((Tests.__byte8.TestData_LHS[i].x5 + Tests.__byte8.TestData_RHS[i].x5) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x5 + Tests.__byte8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (((Tests.__byte8.TestData_LHS[i].x6 + Tests.__byte8.TestData_RHS[i].x6) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x6 + Tests.__byte8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (((Tests.__byte8.TestData_LHS[i].x7 + Tests.__byte8.TestData_RHS[i].x7) > 0 ? 1 : -1) + Tests.__byte8.TestData_LHS[i].x7 + Tests.__byte8.TestData_RHS[i].x7) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte16x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte16.NUM_TESTS; i++)
            {
                sbyte16 x = maxmath.avg(Tests.__sbyte16.TestData_LHS[i], Tests.__sbyte16.TestData_RHS[i]);

                result &= x.x0  == (((Tests.__sbyte16.TestData_LHS[i].x0  + Tests.__sbyte16.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x0  + Tests.__sbyte16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.__sbyte16.TestData_LHS[i].x1  + Tests.__sbyte16.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x1  + Tests.__sbyte16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.__sbyte16.TestData_LHS[i].x2  + Tests.__sbyte16.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x2  + Tests.__sbyte16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.__sbyte16.TestData_LHS[i].x3  + Tests.__sbyte16.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x3  + Tests.__sbyte16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.__sbyte16.TestData_LHS[i].x4  + Tests.__sbyte16.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x4  + Tests.__sbyte16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.__sbyte16.TestData_LHS[i].x5  + Tests.__sbyte16.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x5  + Tests.__sbyte16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.__sbyte16.TestData_LHS[i].x6  + Tests.__sbyte16.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x6  + Tests.__sbyte16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.__sbyte16.TestData_LHS[i].x7  + Tests.__sbyte16.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x7  + Tests.__sbyte16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.__sbyte16.TestData_LHS[i].x8  + Tests.__sbyte16.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x8  + Tests.__sbyte16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.__sbyte16.TestData_LHS[i].x9  + Tests.__sbyte16.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x9  + Tests.__sbyte16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.__sbyte16.TestData_LHS[i].x10 + Tests.__sbyte16.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x10 + Tests.__sbyte16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.__sbyte16.TestData_LHS[i].x11 + Tests.__sbyte16.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x11 + Tests.__sbyte16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.__sbyte16.TestData_LHS[i].x12 + Tests.__sbyte16.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x12 + Tests.__sbyte16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.__sbyte16.TestData_LHS[i].x13 + Tests.__sbyte16.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x13 + Tests.__sbyte16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.__sbyte16.TestData_LHS[i].x14 + Tests.__sbyte16.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x14 + Tests.__sbyte16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.__sbyte16.TestData_LHS[i].x15 + Tests.__sbyte16.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x15 + Tests.__sbyte16.TestData_RHS[i].x15) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte32x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte32.NUM_TESTS; i++)
            {
                sbyte32 x = maxmath.avg(Tests.__sbyte32.TestData_LHS[i], Tests.__sbyte32.TestData_RHS[i]);

                result &= x.x0  == (((Tests.__sbyte32.TestData_LHS[i].x0  + Tests.__sbyte32.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x0  + Tests.__sbyte32.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.__sbyte32.TestData_LHS[i].x1  + Tests.__sbyte32.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x1  + Tests.__sbyte32.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.__sbyte32.TestData_LHS[i].x2  + Tests.__sbyte32.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x2  + Tests.__sbyte32.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.__sbyte32.TestData_LHS[i].x3  + Tests.__sbyte32.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x3  + Tests.__sbyte32.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.__sbyte32.TestData_LHS[i].x4  + Tests.__sbyte32.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x4  + Tests.__sbyte32.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.__sbyte32.TestData_LHS[i].x5  + Tests.__sbyte32.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x5  + Tests.__sbyte32.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.__sbyte32.TestData_LHS[i].x6  + Tests.__sbyte32.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x6  + Tests.__sbyte32.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.__sbyte32.TestData_LHS[i].x7  + Tests.__sbyte32.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x7  + Tests.__sbyte32.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.__sbyte32.TestData_LHS[i].x8  + Tests.__sbyte32.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x8  + Tests.__sbyte32.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.__sbyte32.TestData_LHS[i].x9  + Tests.__sbyte32.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x9  + Tests.__sbyte32.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.__sbyte32.TestData_LHS[i].x10 + Tests.__sbyte32.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x10 + Tests.__sbyte32.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.__sbyte32.TestData_LHS[i].x11 + Tests.__sbyte32.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x11 + Tests.__sbyte32.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.__sbyte32.TestData_LHS[i].x12 + Tests.__sbyte32.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x12 + Tests.__sbyte32.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.__sbyte32.TestData_LHS[i].x13 + Tests.__sbyte32.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x13 + Tests.__sbyte32.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.__sbyte32.TestData_LHS[i].x14 + Tests.__sbyte32.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x14 + Tests.__sbyte32.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.__sbyte32.TestData_LHS[i].x15 + Tests.__sbyte32.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x15 + Tests.__sbyte32.TestData_RHS[i].x15) / 2;
                result &= x.x16 == (((Tests.__sbyte32.TestData_LHS[i].x16 + Tests.__sbyte32.TestData_RHS[i].x16) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x16 + Tests.__sbyte32.TestData_RHS[i].x16) / 2;
                result &= x.x17 == (((Tests.__sbyte32.TestData_LHS[i].x17 + Tests.__sbyte32.TestData_RHS[i].x17) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x17 + Tests.__sbyte32.TestData_RHS[i].x17) / 2;
                result &= x.x18 == (((Tests.__sbyte32.TestData_LHS[i].x18 + Tests.__sbyte32.TestData_RHS[i].x18) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x18 + Tests.__sbyte32.TestData_RHS[i].x18) / 2;
                result &= x.x19 == (((Tests.__sbyte32.TestData_LHS[i].x19 + Tests.__sbyte32.TestData_RHS[i].x19) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x19 + Tests.__sbyte32.TestData_RHS[i].x19) / 2;
                result &= x.x20 == (((Tests.__sbyte32.TestData_LHS[i].x20 + Tests.__sbyte32.TestData_RHS[i].x20) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x20 + Tests.__sbyte32.TestData_RHS[i].x20) / 2;
                result &= x.x21 == (((Tests.__sbyte32.TestData_LHS[i].x21 + Tests.__sbyte32.TestData_RHS[i].x21) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x21 + Tests.__sbyte32.TestData_RHS[i].x21) / 2;
                result &= x.x22 == (((Tests.__sbyte32.TestData_LHS[i].x22 + Tests.__sbyte32.TestData_RHS[i].x22) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x22 + Tests.__sbyte32.TestData_RHS[i].x22) / 2;
                result &= x.x23 == (((Tests.__sbyte32.TestData_LHS[i].x23 + Tests.__sbyte32.TestData_RHS[i].x23) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x23 + Tests.__sbyte32.TestData_RHS[i].x23) / 2;
                result &= x.x24 == (((Tests.__sbyte32.TestData_LHS[i].x24 + Tests.__sbyte32.TestData_RHS[i].x24) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x24 + Tests.__sbyte32.TestData_RHS[i].x24) / 2;
                result &= x.x25 == (((Tests.__sbyte32.TestData_LHS[i].x25 + Tests.__sbyte32.TestData_RHS[i].x25) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x25 + Tests.__sbyte32.TestData_RHS[i].x25) / 2;
                result &= x.x26 == (((Tests.__sbyte32.TestData_LHS[i].x26 + Tests.__sbyte32.TestData_RHS[i].x26) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x26 + Tests.__sbyte32.TestData_RHS[i].x26) / 2;
                result &= x.x27 == (((Tests.__sbyte32.TestData_LHS[i].x27 + Tests.__sbyte32.TestData_RHS[i].x27) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x27 + Tests.__sbyte32.TestData_RHS[i].x27) / 2;
                result &= x.x28 == (((Tests.__sbyte32.TestData_LHS[i].x28 + Tests.__sbyte32.TestData_RHS[i].x28) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x28 + Tests.__sbyte32.TestData_RHS[i].x28) / 2;
                result &= x.x29 == (((Tests.__sbyte32.TestData_LHS[i].x29 + Tests.__sbyte32.TestData_RHS[i].x29) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x29 + Tests.__sbyte32.TestData_RHS[i].x29) / 2;
                result &= x.x30 == (((Tests.__sbyte32.TestData_LHS[i].x30 + Tests.__sbyte32.TestData_RHS[i].x30) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x30 + Tests.__sbyte32.TestData_RHS[i].x30) / 2;
                result &= x.x31 == (((Tests.__sbyte32.TestData_LHS[i].x31 + Tests.__sbyte32.TestData_RHS[i].x31) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x31 + Tests.__sbyte32.TestData_RHS[i].x31) / 2;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void short2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short2.NUM_TESTS; i++)
            {
                short2 x = maxmath.avg(Tests.__short2.TestData_LHS[i], Tests.__short2.TestData_RHS[i]);

                result &= x.x == (((Tests.__short2.TestData_LHS[i].x + Tests.__short2.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__short2.TestData_LHS[i].x + Tests.__short2.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__short2.TestData_LHS[i].y + Tests.__short2.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__short2.TestData_LHS[i].y + Tests.__short2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short3.NUM_TESTS; i++)
            {
                short3 x = maxmath.avg(Tests.__short3.TestData_LHS[i], Tests.__short3.TestData_RHS[i]);

                result &= x.x == (((Tests.__short3.TestData_LHS[i].x + Tests.__short3.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__short3.TestData_LHS[i].x + Tests.__short3.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__short3.TestData_LHS[i].y + Tests.__short3.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__short3.TestData_LHS[i].y + Tests.__short3.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.__short3.TestData_LHS[i].z + Tests.__short3.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.__short3.TestData_LHS[i].z + Tests.__short3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short4.NUM_TESTS; i++)
            {
                short4 x = maxmath.avg(Tests.__short4.TestData_LHS[i], Tests.__short4.TestData_RHS[i]);

                result &= x.x == (((Tests.__short4.TestData_LHS[i].x + Tests.__short4.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].x + Tests.__short4.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__short4.TestData_LHS[i].y + Tests.__short4.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].y + Tests.__short4.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.__short4.TestData_LHS[i].z + Tests.__short4.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].z + Tests.__short4.TestData_RHS[i].z) / 2;
                result &= x.w == (((Tests.__short4.TestData_LHS[i].w + Tests.__short4.TestData_RHS[i].w) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].w + Tests.__short4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short8.NUM_TESTS; i++)
            {
                short8 x = maxmath.avg(Tests.__short8.TestData_LHS[i], Tests.__short8.TestData_RHS[i]);

                result &= x.x0 == (((Tests.__short8.TestData_LHS[i].x0 + Tests.__short8.TestData_RHS[i].x0) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x0 + Tests.__short8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (((Tests.__short8.TestData_LHS[i].x1 + Tests.__short8.TestData_RHS[i].x1) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x1 + Tests.__short8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (((Tests.__short8.TestData_LHS[i].x2 + Tests.__short8.TestData_RHS[i].x2) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x2 + Tests.__short8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (((Tests.__short8.TestData_LHS[i].x3 + Tests.__short8.TestData_RHS[i].x3) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x3 + Tests.__short8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (((Tests.__short8.TestData_LHS[i].x4 + Tests.__short8.TestData_RHS[i].x4) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x4 + Tests.__short8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (((Tests.__short8.TestData_LHS[i].x5 + Tests.__short8.TestData_RHS[i].x5) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x5 + Tests.__short8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (((Tests.__short8.TestData_LHS[i].x6 + Tests.__short8.TestData_RHS[i].x6) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x6 + Tests.__short8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (((Tests.__short8.TestData_LHS[i].x7 + Tests.__short8.TestData_RHS[i].x7) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x7 + Tests.__short8.TestData_RHS[i].x7) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short16x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short16.NUM_TESTS; i++)
            {
                short16 x = maxmath.avg(Tests.__short16.TestData_LHS[i], Tests.__short16.TestData_RHS[i]);

                result &= x.x0  == (((Tests.__short16.TestData_LHS[i].x0  + Tests.__short16.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x0  + Tests.__short16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.__short16.TestData_LHS[i].x1  + Tests.__short16.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x1  + Tests.__short16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.__short16.TestData_LHS[i].x2  + Tests.__short16.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x2  + Tests.__short16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.__short16.TestData_LHS[i].x3  + Tests.__short16.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x3  + Tests.__short16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.__short16.TestData_LHS[i].x4  + Tests.__short16.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x4  + Tests.__short16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.__short16.TestData_LHS[i].x5  + Tests.__short16.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x5  + Tests.__short16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.__short16.TestData_LHS[i].x6  + Tests.__short16.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x6  + Tests.__short16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.__short16.TestData_LHS[i].x7  + Tests.__short16.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x7  + Tests.__short16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.__short16.TestData_LHS[i].x8  + Tests.__short16.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x8  + Tests.__short16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.__short16.TestData_LHS[i].x9  + Tests.__short16.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x9  + Tests.__short16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.__short16.TestData_LHS[i].x10 + Tests.__short16.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x10 + Tests.__short16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.__short16.TestData_LHS[i].x11 + Tests.__short16.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x11 + Tests.__short16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.__short16.TestData_LHS[i].x12 + Tests.__short16.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x12 + Tests.__short16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.__short16.TestData_LHS[i].x13 + Tests.__short16.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x13 + Tests.__short16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.__short16.TestData_LHS[i].x14 + Tests.__short16.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x14 + Tests.__short16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.__short16.TestData_LHS[i].x15 + Tests.__short16.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x15 + Tests.__short16.TestData_RHS[i].x15) / 2;
            }

            Assert.AreEqual(true, result);
        }
    }
}