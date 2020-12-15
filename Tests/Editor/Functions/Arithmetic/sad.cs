using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class sad
    {
        [Test]
        public static void Byte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte2.NUM_TESTS; i++)
            {
                uint x = maxmath.sad(Tests.Byte2.TestData_LHS[i], Tests.Byte2.TestData_RHS[i]);

                result &= x == (uint)(math.abs((int)Tests.Byte2.TestData_LHS[i].x - (int)Tests.Byte2.TestData_RHS[i].x) +
                                      math.abs((int)Tests.Byte2.TestData_LHS[i].y - (int)Tests.Byte2.TestData_RHS[i].y));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte3.NUM_TESTS; i++)
            {
                uint x = maxmath.sad(Tests.Byte3.TestData_LHS[i], Tests.Byte3.TestData_RHS[i]);

                result &= x == (uint)(math.abs((int)Tests.Byte3.TestData_LHS[i].x - (int)Tests.Byte3.TestData_RHS[i].x) +
                                      math.abs((int)Tests.Byte3.TestData_LHS[i].y - (int)Tests.Byte3.TestData_RHS[i].y) +
                                      math.abs((int)Tests.Byte3.TestData_LHS[i].z - (int)Tests.Byte3.TestData_RHS[i].z));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte4.NUM_TESTS; i++)
            {
                uint x = maxmath.sad(Tests.Byte4.TestData_LHS[i], Tests.Byte4.TestData_RHS[i]);

                result &= x == (uint)(math.abs((int)Tests.Byte4.TestData_LHS[i].x - (int)Tests.Byte4.TestData_RHS[i].x) +
                                      math.abs((int)Tests.Byte4.TestData_LHS[i].y - (int)Tests.Byte4.TestData_RHS[i].y) +
                                      math.abs((int)Tests.Byte4.TestData_LHS[i].z - (int)Tests.Byte4.TestData_RHS[i].z) +
                                      math.abs((int)Tests.Byte4.TestData_LHS[i].w - (int)Tests.Byte4.TestData_RHS[i].w));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte8.NUM_TESTS; i++)
            {
                uint x = maxmath.sad(Tests.Byte8.TestData_LHS[i], Tests.Byte8.TestData_RHS[i]);

                result &= x == (uint)(math.abs((int)Tests.Byte8.TestData_LHS[i].x0 - (int)Tests.Byte8.TestData_RHS[i].x0) +
                                      math.abs((int)Tests.Byte8.TestData_LHS[i].x1 - (int)Tests.Byte8.TestData_RHS[i].x1) +
                                      math.abs((int)Tests.Byte8.TestData_LHS[i].x2 - (int)Tests.Byte8.TestData_RHS[i].x2) +
                                      math.abs((int)Tests.Byte8.TestData_LHS[i].x3 - (int)Tests.Byte8.TestData_RHS[i].x3) +
                                      math.abs((int)Tests.Byte8.TestData_LHS[i].x4 - (int)Tests.Byte8.TestData_RHS[i].x4) +
                                      math.abs((int)Tests.Byte8.TestData_LHS[i].x5 - (int)Tests.Byte8.TestData_RHS[i].x5) +
                                      math.abs((int)Tests.Byte8.TestData_LHS[i].x6 - (int)Tests.Byte8.TestData_RHS[i].x6) +
                                      math.abs((int)Tests.Byte8.TestData_LHS[i].x7 - (int)Tests.Byte8.TestData_RHS[i].x7));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte16.NUM_TESTS; i++)
            {
                uint x = maxmath.sad(Tests.Byte16.TestData_LHS[i], Tests.Byte16.TestData_RHS[i]);

                result &= x == (uint)(math.abs((int)Tests.Byte16.TestData_LHS[i].x0  - (int)Tests.Byte16.TestData_RHS[i].x0 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x1  - (int)Tests.Byte16.TestData_RHS[i].x1 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x2  - (int)Tests.Byte16.TestData_RHS[i].x2 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x3  - (int)Tests.Byte16.TestData_RHS[i].x3 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x4  - (int)Tests.Byte16.TestData_RHS[i].x4 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x5  - (int)Tests.Byte16.TestData_RHS[i].x5 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x6  - (int)Tests.Byte16.TestData_RHS[i].x6 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x7  - (int)Tests.Byte16.TestData_RHS[i].x7 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x8  - (int)Tests.Byte16.TestData_RHS[i].x8 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x9  - (int)Tests.Byte16.TestData_RHS[i].x9 ) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x10 - (int)Tests.Byte16.TestData_RHS[i].x10) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x11 - (int)Tests.Byte16.TestData_RHS[i].x11) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x12 - (int)Tests.Byte16.TestData_RHS[i].x12) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x13 - (int)Tests.Byte16.TestData_RHS[i].x13) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x14 - (int)Tests.Byte16.TestData_RHS[i].x14) +
                                      math.abs((int)Tests.Byte16.TestData_LHS[i].x15 - (int)Tests.Byte16.TestData_RHS[i].x15));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte32.NUM_TESTS; i++)
            {
                uint x = maxmath.sad(Tests.Byte32.TestData_LHS[i], Tests.Byte32.TestData_RHS[i]);

                result &= x == (uint)(math.abs((int)Tests.Byte32.TestData_LHS[i].x0  - (int)Tests.Byte32.TestData_RHS[i].x0 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x1  - (int)Tests.Byte32.TestData_RHS[i].x1 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x2  - (int)Tests.Byte32.TestData_RHS[i].x2 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x3  - (int)Tests.Byte32.TestData_RHS[i].x3 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x4  - (int)Tests.Byte32.TestData_RHS[i].x4 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x5  - (int)Tests.Byte32.TestData_RHS[i].x5 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x6  - (int)Tests.Byte32.TestData_RHS[i].x6 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x7  - (int)Tests.Byte32.TestData_RHS[i].x7 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x8  - (int)Tests.Byte32.TestData_RHS[i].x8 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x9  - (int)Tests.Byte32.TestData_RHS[i].x9 ) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x10 - (int)Tests.Byte32.TestData_RHS[i].x10) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x11 - (int)Tests.Byte32.TestData_RHS[i].x11) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x12 - (int)Tests.Byte32.TestData_RHS[i].x12) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x13 - (int)Tests.Byte32.TestData_RHS[i].x13) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x14 - (int)Tests.Byte32.TestData_RHS[i].x14) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x15 - (int)Tests.Byte32.TestData_RHS[i].x15) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x16 - (int)Tests.Byte32.TestData_RHS[i].x16) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x17 - (int)Tests.Byte32.TestData_RHS[i].x17) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x18 - (int)Tests.Byte32.TestData_RHS[i].x18) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x19 - (int)Tests.Byte32.TestData_RHS[i].x19) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x20 - (int)Tests.Byte32.TestData_RHS[i].x20) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x21 - (int)Tests.Byte32.TestData_RHS[i].x21) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x22 - (int)Tests.Byte32.TestData_RHS[i].x22) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x23 - (int)Tests.Byte32.TestData_RHS[i].x23) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x24 - (int)Tests.Byte32.TestData_RHS[i].x24) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x25 - (int)Tests.Byte32.TestData_RHS[i].x25) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x26 - (int)Tests.Byte32.TestData_RHS[i].x26) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x27 - (int)Tests.Byte32.TestData_RHS[i].x27) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x28 - (int)Tests.Byte32.TestData_RHS[i].x28) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x29 - (int)Tests.Byte32.TestData_RHS[i].x29) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x30 - (int)Tests.Byte32.TestData_RHS[i].x30) +
                                      math.abs((int)Tests.Byte32.TestData_LHS[i].x31 - (int)Tests.Byte32.TestData_RHS[i].x31));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                uint x = maxmath.sad(Tests.SByte32.TestData_LHS[i], Tests.SByte32.TestData_RHS[i]);

                result &= x == (uint)(math.abs((int)Tests.SByte32.TestData_LHS[i].x0  - (int)Tests.SByte32.TestData_RHS[i].x0 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x1  - (int)Tests.SByte32.TestData_RHS[i].x1 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x2  - (int)Tests.SByte32.TestData_RHS[i].x2 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x3  - (int)Tests.SByte32.TestData_RHS[i].x3 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x4  - (int)Tests.SByte32.TestData_RHS[i].x4 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x5  - (int)Tests.SByte32.TestData_RHS[i].x5 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x6  - (int)Tests.SByte32.TestData_RHS[i].x6 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x7  - (int)Tests.SByte32.TestData_RHS[i].x7 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x8  - (int)Tests.SByte32.TestData_RHS[i].x8 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x9  - (int)Tests.SByte32.TestData_RHS[i].x9 ) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x10 - (int)Tests.SByte32.TestData_RHS[i].x10) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x11 - (int)Tests.SByte32.TestData_RHS[i].x11) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x12 - (int)Tests.SByte32.TestData_RHS[i].x12) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x13 - (int)Tests.SByte32.TestData_RHS[i].x13) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x14 - (int)Tests.SByte32.TestData_RHS[i].x14) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x15 - (int)Tests.SByte32.TestData_RHS[i].x15) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x16 - (int)Tests.SByte32.TestData_RHS[i].x16) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x17 - (int)Tests.SByte32.TestData_RHS[i].x17) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x18 - (int)Tests.SByte32.TestData_RHS[i].x18) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x19 - (int)Tests.SByte32.TestData_RHS[i].x19) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x20 - (int)Tests.SByte32.TestData_RHS[i].x20) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x21 - (int)Tests.SByte32.TestData_RHS[i].x21) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x22 - (int)Tests.SByte32.TestData_RHS[i].x22) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x23 - (int)Tests.SByte32.TestData_RHS[i].x23) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x24 - (int)Tests.SByte32.TestData_RHS[i].x24) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x25 - (int)Tests.SByte32.TestData_RHS[i].x25) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x26 - (int)Tests.SByte32.TestData_RHS[i].x26) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x27 - (int)Tests.SByte32.TestData_RHS[i].x27) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x28 - (int)Tests.SByte32.TestData_RHS[i].x28) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x29 - (int)Tests.SByte32.TestData_RHS[i].x29) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x30 - (int)Tests.SByte32.TestData_RHS[i].x30) +
                                      math.abs((int)Tests.SByte32.TestData_LHS[i].x31 - (int)Tests.SByte32.TestData_RHS[i].x31));
            }

            Assert.AreEqual(result, true);
        }
    }
}