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

            for (int i = 0; i < Tests.__byte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmax(Tests.__byte2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__byte2.TestData_LHS[i].x,
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
                int x = maxmath.cmax(Tests.__byte3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__byte3.TestData_LHS[i].x,
                               math.max((int)Tests.__byte3.TestData_LHS[i].y,
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
                int x = maxmath.cmax(Tests.__byte4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__byte4.TestData_LHS[i].x,
                               math.max((int)Tests.__byte4.TestData_LHS[i].y,
                               math.max((int)Tests.__byte4.TestData_LHS[i].z,
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
                int x = maxmath.cmax(Tests.__byte8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__byte8.TestData_LHS[i].x0,
                               math.max((int)Tests.__byte8.TestData_LHS[i].x1,
                               math.max((int)Tests.__byte8.TestData_LHS[i].x2,
                               math.max((int)Tests.__byte8.TestData_LHS[i].x3,
                               math.max((int)Tests.__byte8.TestData_LHS[i].x4,
                               math.max((int)Tests.__byte8.TestData_LHS[i].x5,
                               math.max((int)Tests.__byte8.TestData_LHS[i].x6,
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
                int x = maxmath.cmax(Tests.__byte16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__byte16.TestData_LHS[i].x0,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x1,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x2,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x3,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x4,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x5,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x6,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x7,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x8,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x9,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x10,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x11,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x12,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x13,
                               math.max((int)Tests.__byte16.TestData_LHS[i].x14,
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
                int x = maxmath.cmax(Tests.__byte32.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__byte32.TestData_LHS[i].x0,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x1,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x2,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x3,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x4,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x5,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x6,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x7,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x8,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x9,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x10,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x11,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x12,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x13,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x14,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x15,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x16,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x17,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x18,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x19,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x20,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x21,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x22,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x23,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x24,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x25,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x26,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x27,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x28,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x29,
                               math.max((int)Tests.__byte32.TestData_LHS[i].x30,
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
                int x = maxmath.cmax(Tests.__sbyte2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__sbyte2.TestData_LHS[i].x,
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
                int x = maxmath.cmax(Tests.__sbyte3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__sbyte3.TestData_LHS[i].x,
                               math.max((int)Tests.__sbyte3.TestData_LHS[i].y,
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
                int x = maxmath.cmax(Tests.__sbyte4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__sbyte4.TestData_LHS[i].x,
                               math.max((int)Tests.__sbyte4.TestData_LHS[i].y,
                               math.max((int)Tests.__sbyte4.TestData_LHS[i].z,
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
                int x = maxmath.cmax(Tests.__sbyte8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__sbyte8.TestData_LHS[i].x0,
                               math.max((int)Tests.__sbyte8.TestData_LHS[i].x1,
                               math.max((int)Tests.__sbyte8.TestData_LHS[i].x2,
                               math.max((int)Tests.__sbyte8.TestData_LHS[i].x3,
                               math.max((int)Tests.__sbyte8.TestData_LHS[i].x4,
                               math.max((int)Tests.__sbyte8.TestData_LHS[i].x5,
                               math.max((int)Tests.__sbyte8.TestData_LHS[i].x6,
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
                int x = maxmath.cmax(Tests.__sbyte16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__sbyte16.TestData_LHS[i].x0,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x1,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x2,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x3,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x4,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x5,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x6,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x7,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x8,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x9,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x10,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x11,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x12,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x13,
                               math.max((int)Tests.__sbyte16.TestData_LHS[i].x14,
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
                int x = maxmath.cmax(Tests.__sbyte32.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__sbyte32.TestData_LHS[i].x0,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x1,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x2,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x3,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x4,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x5,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x6,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x7,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x8,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x9,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x10,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x11,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x12,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x13,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x14,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x15,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x16,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x17,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x18,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x19,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x20,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x21,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x22,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x23,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x24,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x25,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x26,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x27,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x28,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x29,
                               math.max((int)Tests.__sbyte32.TestData_LHS[i].x30,
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
                int x = maxmath.cmax(Tests.__short2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__short2.TestData_LHS[i].x,
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
                int x = maxmath.cmax(Tests.__short3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__short3.TestData_LHS[i].x,
                               math.max((int)Tests.__short3.TestData_LHS[i].y,
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
                int x = maxmath.cmax(Tests.__short4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__short4.TestData_LHS[i].x,
                               math.max((int)Tests.__short4.TestData_LHS[i].y,
                               math.max((int)Tests.__short4.TestData_LHS[i].z,
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
                int x = maxmath.cmax(Tests.__short8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__short8.TestData_LHS[i].x0,
                               math.max((int)Tests.__short8.TestData_LHS[i].x1,
                               math.max((int)Tests.__short8.TestData_LHS[i].x2,
                               math.max((int)Tests.__short8.TestData_LHS[i].x3,
                               math.max((int)Tests.__short8.TestData_LHS[i].x4,
                               math.max((int)Tests.__short8.TestData_LHS[i].x5,
                               math.max((int)Tests.__short8.TestData_LHS[i].x6,
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
                int x = maxmath.cmax(Tests.__short16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__short16.TestData_LHS[i].x0,
                               math.max((int)Tests.__short16.TestData_LHS[i].x1,
                               math.max((int)Tests.__short16.TestData_LHS[i].x2,
                               math.max((int)Tests.__short16.TestData_LHS[i].x3,
                               math.max((int)Tests.__short16.TestData_LHS[i].x4,
                               math.max((int)Tests.__short16.TestData_LHS[i].x5,
                               math.max((int)Tests.__short16.TestData_LHS[i].x6,
                               math.max((int)Tests.__short16.TestData_LHS[i].x7,
                               math.max((int)Tests.__short16.TestData_LHS[i].x8,
                               math.max((int)Tests.__short16.TestData_LHS[i].x9,
                               math.max((int)Tests.__short16.TestData_LHS[i].x10,
                               math.max((int)Tests.__short16.TestData_LHS[i].x11,
                               math.max((int)Tests.__short16.TestData_LHS[i].x12,
                               math.max((int)Tests.__short16.TestData_LHS[i].x13,
                               math.max((int)Tests.__short16.TestData_LHS[i].x14,
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
                int x = maxmath.cmax(Tests.__ushort2.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__ushort2.TestData_LHS[i].x,
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
                int x = maxmath.cmax(Tests.__ushort3.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__ushort3.TestData_LHS[i].x,
                               math.max((int)Tests.__ushort3.TestData_LHS[i].y,
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
                int x = maxmath.cmax(Tests.__ushort4.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__ushort4.TestData_LHS[i].x,
                               math.max((int)Tests.__ushort4.TestData_LHS[i].y,
                               math.max((int)Tests.__ushort4.TestData_LHS[i].z,
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
                int x = maxmath.cmax(Tests.__ushort8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__ushort8.TestData_LHS[i].x0,
                               math.max((int)Tests.__ushort8.TestData_LHS[i].x1,
                               math.max((int)Tests.__ushort8.TestData_LHS[i].x2,
                               math.max((int)Tests.__ushort8.TestData_LHS[i].x3,
                               math.max((int)Tests.__ushort8.TestData_LHS[i].x4,
                               math.max((int)Tests.__ushort8.TestData_LHS[i].x5,
                               math.max((int)Tests.__ushort8.TestData_LHS[i].x6,
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
                int x = maxmath.cmax(Tests.__ushort16.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__ushort16.TestData_LHS[i].x0,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x1,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x2,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x3,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x4,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x5,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x6,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x7,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x8,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x9,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x10,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x11,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x12,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x13,
                               math.max((int)Tests.__ushort16.TestData_LHS[i].x14,
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
                int x = maxmath.cmax(Tests.__int8.TestData_LHS[i]);

                result &= x == math.max((int)Tests.__int8.TestData_LHS[i].x0,
                               math.max((int)Tests.__int8.TestData_LHS[i].x1,
                               math.max((int)Tests.__int8.TestData_LHS[i].x2,
                               math.max((int)Tests.__int8.TestData_LHS[i].x3,
                               math.max((int)Tests.__int8.TestData_LHS[i].x4,
                               math.max((int)Tests.__int8.TestData_LHS[i].x5,
                               math.max((int)Tests.__int8.TestData_LHS[i].x6,
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
                uint x = maxmath.cmax(Tests.__uint8.TestData_LHS[i]);

                result &= x == math.max(Tests.__uint8.TestData_LHS[i].x0,
                               math.max(Tests.__uint8.TestData_LHS[i].x1,
                               math.max(Tests.__uint8.TestData_LHS[i].x2,
                               math.max(Tests.__uint8.TestData_LHS[i].x3,
                               math.max(Tests.__uint8.TestData_LHS[i].x4,
                               math.max(Tests.__uint8.TestData_LHS[i].x5,
                               math.max(Tests.__uint8.TestData_LHS[i].x6,
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
                long x = maxmath.cmax(Tests.__long2.TestData_LHS[i]);

                result &= x == math.max(Tests.__long2.TestData_LHS[i].x,
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
                long x = maxmath.cmax(Tests.__long3.TestData_LHS[i]);

                result &= x == math.max(Tests.__long3.TestData_LHS[i].x,
                               math.max(Tests.__long3.TestData_LHS[i].y,
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
                long x = maxmath.cmax(Tests.__long4.TestData_LHS[i]);

                result &= x == math.max(Tests.__long4.TestData_LHS[i].x,
                               math.max(Tests.__long4.TestData_LHS[i].y,
                               math.max(Tests.__long4.TestData_LHS[i].z,
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
                ulong x = maxmath.cmax(Tests.__ulong2.TestData_LHS[i]);

                result &= x == math.max(Tests.__ulong2.TestData_LHS[i].x,
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
                ulong x = maxmath.cmax(Tests.__ulong3.TestData_LHS[i]);

                result &= x == math.max(Tests.__ulong3.TestData_LHS[i].x,
                               math.max(Tests.__ulong3.TestData_LHS[i].y,
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
                ulong x = maxmath.cmax(Tests.__ulong4.TestData_LHS[i]);

                result &= x == math.max(Tests.__ulong4.TestData_LHS[i].x,
                               math.max(Tests.__ulong4.TestData_LHS[i].y,
                               math.max(Tests.__ulong4.TestData_LHS[i].z,
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
                float x = maxmath.cmax(Tests.__float8.TestData_LHS[i]);

                result &= x == math.max(Tests.__float8.TestData_LHS[i].x0,
                               math.max(Tests.__float8.TestData_LHS[i].x1,
                               math.max(Tests.__float8.TestData_LHS[i].x2,
                               math.max(Tests.__float8.TestData_LHS[i].x3,
                               math.max(Tests.__float8.TestData_LHS[i].x4,
                               math.max(Tests.__float8.TestData_LHS[i].x5,
                               math.max(Tests.__float8.TestData_LHS[i].x6,
                                        Tests.__float8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }
    }
}