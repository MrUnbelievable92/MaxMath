using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class cmin
    {
        [Test]
        public static void Byte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__byte2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__byte2.TestData_LHS[i].x,
                                        (int)Tests.__byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__byte3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__byte3.TestData_LHS[i].x,
                               math.min((int)Tests.__byte3.TestData_LHS[i].y,
                                        (int)Tests.__byte3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__byte4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__byte4.TestData_LHS[i].x,
                               math.min((int)Tests.__byte4.TestData_LHS[i].y,
                               math.min((int)Tests.__byte4.TestData_LHS[i].z,
                                        (int)Tests.__byte4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__byte8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__byte8.TestData_LHS[i].x0,
                               math.min((int)Tests.__byte8.TestData_LHS[i].x1,
                               math.min((int)Tests.__byte8.TestData_LHS[i].x2,
                               math.min((int)Tests.__byte8.TestData_LHS[i].x3,
                               math.min((int)Tests.__byte8.TestData_LHS[i].x4,
                               math.min((int)Tests.__byte8.TestData_LHS[i].x5,
                               math.min((int)Tests.__byte8.TestData_LHS[i].x6,
                                        (int)Tests.__byte8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__byte16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__byte16.TestData_LHS[i].x0,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x1,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x2,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x3,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x4,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x5,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x6,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x7,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x8,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x9,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x10,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x11,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x12,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x13,
                               math.min((int)Tests.__byte16.TestData_LHS[i].x14,
                                        (int)Tests.__byte16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__byte32.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__byte32.TestData_LHS[i].x0,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x1,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x2,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x3,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x4,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x5,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x6,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x7,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x8,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x9,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x10,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x11,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x12,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x13,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x14,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x15,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x16,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x17,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x18,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x19,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x20,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x21,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x22,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x23,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x24,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x25,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x26,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x27,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x28,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x29,
                               math.min((int)Tests.__byte32.TestData_LHS[i].x30,
                                        (int)Tests.__byte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__sbyte2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__sbyte2.TestData_LHS[i].x,
                                        (int)Tests.__sbyte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__sbyte3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__sbyte3.TestData_LHS[i].x,
                               math.min((int)Tests.__sbyte3.TestData_LHS[i].y,
                                        (int)Tests.__sbyte3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__sbyte4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__sbyte4.TestData_LHS[i].x,
                               math.min((int)Tests.__sbyte4.TestData_LHS[i].y,
                               math.min((int)Tests.__sbyte4.TestData_LHS[i].z,
                                        (int)Tests.__sbyte4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__sbyte8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__sbyte8.TestData_LHS[i].x0,
                               math.min((int)Tests.__sbyte8.TestData_LHS[i].x1,
                               math.min((int)Tests.__sbyte8.TestData_LHS[i].x2,
                               math.min((int)Tests.__sbyte8.TestData_LHS[i].x3,
                               math.min((int)Tests.__sbyte8.TestData_LHS[i].x4,
                               math.min((int)Tests.__sbyte8.TestData_LHS[i].x5,
                               math.min((int)Tests.__sbyte8.TestData_LHS[i].x6,
                                        (int)Tests.__sbyte8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__sbyte16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__sbyte16.TestData_LHS[i].x0,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x1,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x2,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x3,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x4,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x5,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x6,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x7,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x8,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x9,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x10,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x11,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x12,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x13,
                               math.min((int)Tests.__sbyte16.TestData_LHS[i].x14,
                                        (int)Tests.__sbyte16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__sbyte32.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__sbyte32.TestData_LHS[i].x0,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x1,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x2,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x3,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x4,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x5,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x6,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x7,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x8,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x9,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x10,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x11,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x12,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x13,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x14,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x15,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x16,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x17,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x18,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x19,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x20,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x21,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x22,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x23,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x24,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x25,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x26,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x27,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x28,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x29,
                               math.min((int)Tests.__sbyte32.TestData_LHS[i].x30,
                                        (int)Tests.__sbyte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__short2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__short2.TestData_LHS[i].x,
                                        (int)Tests.__short2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__short3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__short3.TestData_LHS[i].x,
                               math.min((int)Tests.__short3.TestData_LHS[i].y,
                                        (int)Tests.__short3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__short4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__short4.TestData_LHS[i].x,
                               math.min((int)Tests.__short4.TestData_LHS[i].y,
                               math.min((int)Tests.__short4.TestData_LHS[i].z,
                                        (int)Tests.__short4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__short8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__short8.TestData_LHS[i].x0,
                               math.min((int)Tests.__short8.TestData_LHS[i].x1,
                               math.min((int)Tests.__short8.TestData_LHS[i].x2,
                               math.min((int)Tests.__short8.TestData_LHS[i].x3,
                               math.min((int)Tests.__short8.TestData_LHS[i].x4,
                               math.min((int)Tests.__short8.TestData_LHS[i].x5,
                               math.min((int)Tests.__short8.TestData_LHS[i].x6,
                                        (int)Tests.__short8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__short16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__short16.TestData_LHS[i].x0,
                               math.min((int)Tests.__short16.TestData_LHS[i].x1,
                               math.min((int)Tests.__short16.TestData_LHS[i].x2,
                               math.min((int)Tests.__short16.TestData_LHS[i].x3,
                               math.min((int)Tests.__short16.TestData_LHS[i].x4,
                               math.min((int)Tests.__short16.TestData_LHS[i].x5,
                               math.min((int)Tests.__short16.TestData_LHS[i].x6,
                               math.min((int)Tests.__short16.TestData_LHS[i].x7,
                               math.min((int)Tests.__short16.TestData_LHS[i].x8,
                               math.min((int)Tests.__short16.TestData_LHS[i].x9,
                               math.min((int)Tests.__short16.TestData_LHS[i].x10,
                               math.min((int)Tests.__short16.TestData_LHS[i].x11,
                               math.min((int)Tests.__short16.TestData_LHS[i].x12,
                               math.min((int)Tests.__short16.TestData_LHS[i].x13,
                               math.min((int)Tests.__short16.TestData_LHS[i].x14,
                                        (int)Tests.__short16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__ushort2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__ushort2.TestData_LHS[i].x,
                                        (int)Tests.__ushort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__ushort3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__ushort3.TestData_LHS[i].x,
                               math.min((int)Tests.__ushort3.TestData_LHS[i].y,
                                        (int)Tests.__ushort3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__ushort4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__ushort4.TestData_LHS[i].x,
                               math.min((int)Tests.__ushort4.TestData_LHS[i].y,
                               math.min((int)Tests.__ushort4.TestData_LHS[i].z,
                                        (int)Tests.__ushort4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__ushort8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__ushort8.TestData_LHS[i].x0,
                               math.min((int)Tests.__ushort8.TestData_LHS[i].x1,
                               math.min((int)Tests.__ushort8.TestData_LHS[i].x2,
                               math.min((int)Tests.__ushort8.TestData_LHS[i].x3,
                               math.min((int)Tests.__ushort8.TestData_LHS[i].x4,
                               math.min((int)Tests.__ushort8.TestData_LHS[i].x5,
                               math.min((int)Tests.__ushort8.TestData_LHS[i].x6,
                                        (int)Tests.__ushort8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__ushort16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__ushort16.TestData_LHS[i].x0,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x1,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x2,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x3,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x4,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x5,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x6,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x7,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x8,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x9,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x10,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x11,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x12,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x13,
                               math.min((int)Tests.__ushort16.TestData_LHS[i].x14,
                                        (int)Tests.__ushort16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.__int8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.__int8.TestData_LHS[i].x0,
                               math.min((int)Tests.__int8.TestData_LHS[i].x1,
                               math.min((int)Tests.__int8.TestData_LHS[i].x2,
                               math.min((int)Tests.__int8.TestData_LHS[i].x3,
                               math.min((int)Tests.__int8.TestData_LHS[i].x4,
                               math.min((int)Tests.__int8.TestData_LHS[i].x5,
                               math.min((int)Tests.__int8.TestData_LHS[i].x6,
                                        (int)Tests.__int8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UInt8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__uint8.NUM_TESTS; i++)
            {
                uint x = maxmath.cmin(Tests.__uint8.TestData_LHS[i]);

                result &= x == math.min(Tests.__uint8.TestData_LHS[i].x0,
                               math.min(Tests.__uint8.TestData_LHS[i].x1,
                               math.min(Tests.__uint8.TestData_LHS[i].x2,
                               math.min(Tests.__uint8.TestData_LHS[i].x3,
                               math.min(Tests.__uint8.TestData_LHS[i].x4,
                               math.min(Tests.__uint8.TestData_LHS[i].x5,
                               math.min(Tests.__uint8.TestData_LHS[i].x6,
                                        Tests.__uint8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long2.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(Tests.__long2.TestData_LHS[i]);

                result &= x == math.min(Tests.__long2.TestData_LHS[i].x,
                                        Tests.__long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long3.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(Tests.__long3.TestData_LHS[i]);

                result &= x == math.min(Tests.__long3.TestData_LHS[i].x,
                               math.min(Tests.__long3.TestData_LHS[i].y,
                                        Tests.__long3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long4.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(Tests.__long4.TestData_LHS[i]);

                result &= x == math.min(Tests.__long4.TestData_LHS[i].x,
                               math.min(Tests.__long4.TestData_LHS[i].y,
                               math.min(Tests.__long4.TestData_LHS[i].z,
                                        Tests.__long4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ULong2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong2.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(Tests.__ulong2.TestData_LHS[i]);

                result &= x == math.min(Tests.__ulong2.TestData_LHS[i].x,
                                        Tests.__ulong2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong3.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(Tests.__ulong3.TestData_LHS[i]);

                result &= x == math.min(Tests.__ulong3.TestData_LHS[i].x,
                               math.min(Tests.__ulong3.TestData_LHS[i].y,
                                        Tests.__ulong3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong4.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(Tests.__ulong4.TestData_LHS[i]);

                result &= x == math.min(Tests.__ulong4.TestData_LHS[i].x,
                               math.min(Tests.__ulong4.TestData_LHS[i].y,
                               math.min(Tests.__ulong4.TestData_LHS[i].z,
                                        Tests.__ulong4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Float8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__float8.NUM_TESTS; i++)
            {
                float x = maxmath.cmin(Tests.__float8.TestData_LHS[i]);

                result &= x == math.min(Tests.__float8.TestData_LHS[i].x0,
                               math.min(Tests.__float8.TestData_LHS[i].x1,
                               math.min(Tests.__float8.TestData_LHS[i].x2,
                               math.min(Tests.__float8.TestData_LHS[i].x3,
                               math.min(Tests.__float8.TestData_LHS[i].x4,
                               math.min(Tests.__float8.TestData_LHS[i].x5,
                               math.min(Tests.__float8.TestData_LHS[i].x6,
                                        Tests.__float8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }
    }
}