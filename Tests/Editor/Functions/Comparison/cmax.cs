using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class cmax
    {
        [Test]
        public static void Byte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Byte2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Byte2.TestData_LHS[i].x,
                                        (int)Tests.Byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Byte3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Byte3.TestData_LHS[i].x,
                               math.max((int)Tests.Byte3.TestData_LHS[i].y,
                                        (int)Tests.Byte3.TestData_LHS[i].z));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Byte4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Byte4.TestData_LHS[i].x,
                               math.max((int)Tests.Byte4.TestData_LHS[i].y,
                               math.max((int)Tests.Byte4.TestData_LHS[i].z,
                                        (int)Tests.Byte4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Byte8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Byte8.TestData_LHS[i].x0,
                               math.max((int)Tests.Byte8.TestData_LHS[i].x1,
                               math.max((int)Tests.Byte8.TestData_LHS[i].x2,
                               math.max((int)Tests.Byte8.TestData_LHS[i].x3,
                               math.max((int)Tests.Byte8.TestData_LHS[i].x4,
                               math.max((int)Tests.Byte8.TestData_LHS[i].x5,
                               math.max((int)Tests.Byte8.TestData_LHS[i].x6,
                                        (int)Tests.Byte8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Byte16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Byte16.TestData_LHS[i].x0,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x1,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x2,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x3,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x4,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x5,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x6,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x7,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x8,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x9,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x10,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x11,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x12,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x13,
                               math.max((int)Tests.Byte16.TestData_LHS[i].x14,
                                        (int)Tests.Byte16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Byte32.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Byte32.TestData_LHS[i].x0,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x1,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x2,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x3,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x4,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x5,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x6,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x7,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x8,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x9,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x10,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x11,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x12,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x13,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x14,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x15,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x16,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x17,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x18,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x19,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x20,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x21,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x22,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x23,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x24,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x25,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x26,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x27,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x28,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x29,
                               math.max((int)Tests.Byte32.TestData_LHS[i].x30,
                                        (int)Tests.Byte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.SByte2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.SByte2.TestData_LHS[i].x,
                                        (int)Tests.SByte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.SByte3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.SByte3.TestData_LHS[i].x,
                               math.max((int)Tests.SByte3.TestData_LHS[i].y,
                                        (int)Tests.SByte3.TestData_LHS[i].z));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.SByte4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.SByte4.TestData_LHS[i].x,
                               math.max((int)Tests.SByte4.TestData_LHS[i].y,
                               math.max((int)Tests.SByte4.TestData_LHS[i].z,
                                        (int)Tests.SByte4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.SByte8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.SByte8.TestData_LHS[i].x0,
                               math.max((int)Tests.SByte8.TestData_LHS[i].x1,
                               math.max((int)Tests.SByte8.TestData_LHS[i].x2,
                               math.max((int)Tests.SByte8.TestData_LHS[i].x3,
                               math.max((int)Tests.SByte8.TestData_LHS[i].x4,
                               math.max((int)Tests.SByte8.TestData_LHS[i].x5,
                               math.max((int)Tests.SByte8.TestData_LHS[i].x6,
                                        (int)Tests.SByte8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.SByte16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.SByte16.TestData_LHS[i].x0,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x1,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x2,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x3,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x4,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x5,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x6,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x7,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x8,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x9,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x10,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x11,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x12,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x13,
                               math.max((int)Tests.SByte16.TestData_LHS[i].x14,
                                        (int)Tests.SByte16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.SByte32.TestData_LHS[i]);

                result &= x == math.max((int)Tests.SByte32.TestData_LHS[i].x0,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x1,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x2,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x3,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x4,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x5,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x6,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x7,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x8,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x9,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x10,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x11,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x12,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x13,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x14,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x15,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x16,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x17,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x18,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x19,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x20,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x21,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x22,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x23,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x24,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x25,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x26,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x27,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x28,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x29,
                               math.max((int)Tests.SByte32.TestData_LHS[i].x30,
                                        (int)Tests.SByte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Short2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Short2.TestData_LHS[i].x,
                                        (int)Tests.Short2.TestData_LHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Short3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Short3.TestData_LHS[i].x,
                               math.max((int)Tests.Short3.TestData_LHS[i].y,
                                        (int)Tests.Short3.TestData_LHS[i].z));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Short4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Short4.TestData_LHS[i].x,
                               math.max((int)Tests.Short4.TestData_LHS[i].y,
                               math.max((int)Tests.Short4.TestData_LHS[i].z,
                                        (int)Tests.Short4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Short8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Short8.TestData_LHS[i].x0,
                               math.max((int)Tests.Short8.TestData_LHS[i].x1,
                               math.max((int)Tests.Short8.TestData_LHS[i].x2,
                               math.max((int)Tests.Short8.TestData_LHS[i].x3,
                               math.max((int)Tests.Short8.TestData_LHS[i].x4,
                               math.max((int)Tests.Short8.TestData_LHS[i].x5,
                               math.max((int)Tests.Short8.TestData_LHS[i].x6,
                                        (int)Tests.Short8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Short16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Short16.TestData_LHS[i].x0,
                               math.max((int)Tests.Short16.TestData_LHS[i].x1,
                               math.max((int)Tests.Short16.TestData_LHS[i].x2,
                               math.max((int)Tests.Short16.TestData_LHS[i].x3,
                               math.max((int)Tests.Short16.TestData_LHS[i].x4,
                               math.max((int)Tests.Short16.TestData_LHS[i].x5,
                               math.max((int)Tests.Short16.TestData_LHS[i].x6,
                               math.max((int)Tests.Short16.TestData_LHS[i].x7,
                               math.max((int)Tests.Short16.TestData_LHS[i].x8,
                               math.max((int)Tests.Short16.TestData_LHS[i].x9,
                               math.max((int)Tests.Short16.TestData_LHS[i].x10,
                               math.max((int)Tests.Short16.TestData_LHS[i].x11,
                               math.max((int)Tests.Short16.TestData_LHS[i].x12,
                               math.max((int)Tests.Short16.TestData_LHS[i].x13,
                               math.max((int)Tests.Short16.TestData_LHS[i].x14,
                                        (int)Tests.Short16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort2.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.UShort2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.UShort2.TestData_LHS[i].x,
                                        (int)Tests.UShort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort3.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.UShort3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.UShort3.TestData_LHS[i].x,
                               math.max((int)Tests.UShort3.TestData_LHS[i].y,
                                        (int)Tests.UShort3.TestData_LHS[i].z));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort4.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.UShort4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.UShort4.TestData_LHS[i].x,
                               math.max((int)Tests.UShort4.TestData_LHS[i].y,
                               math.max((int)Tests.UShort4.TestData_LHS[i].z,
                                        (int)Tests.UShort4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.UShort8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.UShort8.TestData_LHS[i].x0,
                               math.max((int)Tests.UShort8.TestData_LHS[i].x1,
                               math.max((int)Tests.UShort8.TestData_LHS[i].x2,
                               math.max((int)Tests.UShort8.TestData_LHS[i].x3,
                               math.max((int)Tests.UShort8.TestData_LHS[i].x4,
                               math.max((int)Tests.UShort8.TestData_LHS[i].x5,
                               math.max((int)Tests.UShort8.TestData_LHS[i].x6,
                                        (int)Tests.UShort8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.UShort16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.UShort16.TestData_LHS[i].x0,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x1,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x2,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x3,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x4,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x5,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x6,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x7,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x8,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x9,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x10,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x11,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x12,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x13,
                               math.max((int)Tests.UShort16.TestData_LHS[i].x14,
                                        (int)Tests.UShort16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.Int8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.Int8.TestData_LHS[i].x0,
                               math.max((int)Tests.Int8.TestData_LHS[i].x1,
                               math.max((int)Tests.Int8.TestData_LHS[i].x2,
                               math.max((int)Tests.Int8.TestData_LHS[i].x3,
                               math.max((int)Tests.Int8.TestData_LHS[i].x4,
                               math.max((int)Tests.Int8.TestData_LHS[i].x5,
                               math.max((int)Tests.Int8.TestData_LHS[i].x6,
                                        (int)Tests.Int8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void UInt8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UInt8.NUM_TESTS; i++)
            {
                uint x = maxmath.cmax(Tests.UInt8.TestData_LHS[i]);

                result &= x == math.max(Tests.UInt8.TestData_LHS[i].x0,
                               math.max(Tests.UInt8.TestData_LHS[i].x1,
                               math.max(Tests.UInt8.TestData_LHS[i].x2,
                               math.max(Tests.UInt8.TestData_LHS[i].x3,
                               math.max(Tests.UInt8.TestData_LHS[i].x4,
                               math.max(Tests.UInt8.TestData_LHS[i].x5,
                               math.max(Tests.UInt8.TestData_LHS[i].x6,
                                        Tests.UInt8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                long x = maxmath.cmax(Tests.Long2.TestData_LHS[i]);

                result &= x == math.max(Tests.Long2.TestData_LHS[i].x,
                                        Tests.Long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                long x = maxmath.cmax(Tests.Long3.TestData_LHS[i]);

                result &= x == math.max(Tests.Long3.TestData_LHS[i].x,
                               math.max(Tests.Long3.TestData_LHS[i].y,
                                        Tests.Long3.TestData_LHS[i].z));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                long x = maxmath.cmax(Tests.Long4.TestData_LHS[i]);

                result &= x == math.max(Tests.Long4.TestData_LHS[i].x,
                               math.max(Tests.Long4.TestData_LHS[i].y,
                               math.max(Tests.Long4.TestData_LHS[i].z,
                                        Tests.Long4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ULong2()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong2.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmax(Tests.ULong2.TestData_LHS[i]);

                result &= x == math.max(Tests.ULong2.TestData_LHS[i].x,
                                        Tests.ULong2.TestData_LHS[i].y);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ULong3()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong3.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmax(Tests.ULong3.TestData_LHS[i]);

                result &= x == math.max(Tests.ULong3.TestData_LHS[i].x,
                               math.max(Tests.ULong3.TestData_LHS[i].y,
                                        Tests.ULong3.TestData_LHS[i].z));
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ULong4()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong4.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmax(Tests.ULong4.TestData_LHS[i]);

                result &= x == math.max(Tests.ULong4.TestData_LHS[i].x,
                               math.max(Tests.ULong4.TestData_LHS[i].y,
                               math.max(Tests.ULong4.TestData_LHS[i].z,
                                        Tests.ULong4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Float8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                float x = maxmath.cmax(Tests.Float8.TestData_LHS[i]);

                result &= x == math.max(Tests.Float8.TestData_LHS[i].x0,
                               math.max(Tests.Float8.TestData_LHS[i].x1,
                               math.max(Tests.Float8.TestData_LHS[i].x2,
                               math.max(Tests.Float8.TestData_LHS[i].x3,
                               math.max(Tests.Float8.TestData_LHS[i].x4,
                               math.max(Tests.Float8.TestData_LHS[i].x5,
                               math.max(Tests.Float8.TestData_LHS[i].x6,
                                        Tests.Float8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(result, true);
        }
    }
}