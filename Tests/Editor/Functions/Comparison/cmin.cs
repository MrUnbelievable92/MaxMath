using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_cmin
    {
        [Test]
        public static void _byte2()
        {
            bool result = true;

            for (int i = 0; i < t_byte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_byte2.TestData_LHS[i]);

                result &= x == math.min((int)t_byte2.TestData_LHS[i].x,
                                        (int)t_byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte3()
        {
            bool result = true;

            for (int i = 0; i < t_byte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_byte3.TestData_LHS[i]);

                result &= x == math.min((int)t_byte3.TestData_LHS[i].x,
                               math.min((int)t_byte3.TestData_LHS[i].y,
                                        (int)t_byte3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte4()
        {
            bool result = true;

            for (int i = 0; i < t_byte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_byte4.TestData_LHS[i]);

                result &= x == math.min((int)t_byte4.TestData_LHS[i].x,
                               math.min((int)t_byte4.TestData_LHS[i].y,
                               math.min((int)t_byte4.TestData_LHS[i].z,
                                        (int)t_byte4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte8()
        {
            bool result = true;

            for (int i = 0; i < t_byte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_byte8.TestData_LHS[i]);

                result &= x == math.min((int)t_byte8.TestData_LHS[i].x0,
                               math.min((int)t_byte8.TestData_LHS[i].x1,
                               math.min((int)t_byte8.TestData_LHS[i].x2,
                               math.min((int)t_byte8.TestData_LHS[i].x3,
                               math.min((int)t_byte8.TestData_LHS[i].x4,
                               math.min((int)t_byte8.TestData_LHS[i].x5,
                               math.min((int)t_byte8.TestData_LHS[i].x6,
                                        (int)t_byte8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte16()
        {
            bool result = true;

            for (int i = 0; i < t_byte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_byte16.TestData_LHS[i]);

                result &= x == math.min((int)t_byte16.TestData_LHS[i].x0,
                               math.min((int)t_byte16.TestData_LHS[i].x1,
                               math.min((int)t_byte16.TestData_LHS[i].x2,
                               math.min((int)t_byte16.TestData_LHS[i].x3,
                               math.min((int)t_byte16.TestData_LHS[i].x4,
                               math.min((int)t_byte16.TestData_LHS[i].x5,
                               math.min((int)t_byte16.TestData_LHS[i].x6,
                               math.min((int)t_byte16.TestData_LHS[i].x7,
                               math.min((int)t_byte16.TestData_LHS[i].x8,
                               math.min((int)t_byte16.TestData_LHS[i].x9,
                               math.min((int)t_byte16.TestData_LHS[i].x10,
                               math.min((int)t_byte16.TestData_LHS[i].x11,
                               math.min((int)t_byte16.TestData_LHS[i].x12,
                               math.min((int)t_byte16.TestData_LHS[i].x13,
                               math.min((int)t_byte16.TestData_LHS[i].x14,
                                        (int)t_byte16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte32()
        {
            bool result = true;

            for (int i = 0; i < t_byte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_byte32.TestData_LHS[i]);

                result &= x == math.min((int)t_byte32.TestData_LHS[i].x0,
                               math.min((int)t_byte32.TestData_LHS[i].x1,
                               math.min((int)t_byte32.TestData_LHS[i].x2,
                               math.min((int)t_byte32.TestData_LHS[i].x3,
                               math.min((int)t_byte32.TestData_LHS[i].x4,
                               math.min((int)t_byte32.TestData_LHS[i].x5,
                               math.min((int)t_byte32.TestData_LHS[i].x6,
                               math.min((int)t_byte32.TestData_LHS[i].x7,
                               math.min((int)t_byte32.TestData_LHS[i].x8,
                               math.min((int)t_byte32.TestData_LHS[i].x9,
                               math.min((int)t_byte32.TestData_LHS[i].x10,
                               math.min((int)t_byte32.TestData_LHS[i].x11,
                               math.min((int)t_byte32.TestData_LHS[i].x12,
                               math.min((int)t_byte32.TestData_LHS[i].x13,
                               math.min((int)t_byte32.TestData_LHS[i].x14,
                               math.min((int)t_byte32.TestData_LHS[i].x15,
                               math.min((int)t_byte32.TestData_LHS[i].x16,
                               math.min((int)t_byte32.TestData_LHS[i].x17,
                               math.min((int)t_byte32.TestData_LHS[i].x18,
                               math.min((int)t_byte32.TestData_LHS[i].x19,
                               math.min((int)t_byte32.TestData_LHS[i].x20,
                               math.min((int)t_byte32.TestData_LHS[i].x21,
                               math.min((int)t_byte32.TestData_LHS[i].x22,
                               math.min((int)t_byte32.TestData_LHS[i].x23,
                               math.min((int)t_byte32.TestData_LHS[i].x24,
                               math.min((int)t_byte32.TestData_LHS[i].x25,
                               math.min((int)t_byte32.TestData_LHS[i].x26,
                               math.min((int)t_byte32.TestData_LHS[i].x27,
                               math.min((int)t_byte32.TestData_LHS[i].x28,
                               math.min((int)t_byte32.TestData_LHS[i].x29,
                               math.min((int)t_byte32.TestData_LHS[i].x30,
                                        (int)t_byte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _sbyte2()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_sbyte2.TestData_LHS[i]);

                result &= x == math.min((int)t_sbyte2.TestData_LHS[i].x,
                                        (int)t_sbyte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte3()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_sbyte3.TestData_LHS[i]);

                result &= x == math.min((int)t_sbyte3.TestData_LHS[i].x,
                               math.min((int)t_sbyte3.TestData_LHS[i].y,
                                        (int)t_sbyte3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte4()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_sbyte4.TestData_LHS[i]);

                result &= x == math.min((int)t_sbyte4.TestData_LHS[i].x,
                               math.min((int)t_sbyte4.TestData_LHS[i].y,
                               math.min((int)t_sbyte4.TestData_LHS[i].z,
                                        (int)t_sbyte4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte8()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_sbyte8.TestData_LHS[i]);

                result &= x == math.min((int)t_sbyte8.TestData_LHS[i].x0,
                               math.min((int)t_sbyte8.TestData_LHS[i].x1,
                               math.min((int)t_sbyte8.TestData_LHS[i].x2,
                               math.min((int)t_sbyte8.TestData_LHS[i].x3,
                               math.min((int)t_sbyte8.TestData_LHS[i].x4,
                               math.min((int)t_sbyte8.TestData_LHS[i].x5,
                               math.min((int)t_sbyte8.TestData_LHS[i].x6,
                                        (int)t_sbyte8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte16()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_sbyte16.TestData_LHS[i]);

                result &= x == math.min((int)t_sbyte16.TestData_LHS[i].x0,
                               math.min((int)t_sbyte16.TestData_LHS[i].x1,
                               math.min((int)t_sbyte16.TestData_LHS[i].x2,
                               math.min((int)t_sbyte16.TestData_LHS[i].x3,
                               math.min((int)t_sbyte16.TestData_LHS[i].x4,
                               math.min((int)t_sbyte16.TestData_LHS[i].x5,
                               math.min((int)t_sbyte16.TestData_LHS[i].x6,
                               math.min((int)t_sbyte16.TestData_LHS[i].x7,
                               math.min((int)t_sbyte16.TestData_LHS[i].x8,
                               math.min((int)t_sbyte16.TestData_LHS[i].x9,
                               math.min((int)t_sbyte16.TestData_LHS[i].x10,
                               math.min((int)t_sbyte16.TestData_LHS[i].x11,
                               math.min((int)t_sbyte16.TestData_LHS[i].x12,
                               math.min((int)t_sbyte16.TestData_LHS[i].x13,
                               math.min((int)t_sbyte16.TestData_LHS[i].x14,
                                        (int)t_sbyte16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte32()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_sbyte32.TestData_LHS[i]);

                result &= x == math.min((int)t_sbyte32.TestData_LHS[i].x0,
                               math.min((int)t_sbyte32.TestData_LHS[i].x1,
                               math.min((int)t_sbyte32.TestData_LHS[i].x2,
                               math.min((int)t_sbyte32.TestData_LHS[i].x3,
                               math.min((int)t_sbyte32.TestData_LHS[i].x4,
                               math.min((int)t_sbyte32.TestData_LHS[i].x5,
                               math.min((int)t_sbyte32.TestData_LHS[i].x6,
                               math.min((int)t_sbyte32.TestData_LHS[i].x7,
                               math.min((int)t_sbyte32.TestData_LHS[i].x8,
                               math.min((int)t_sbyte32.TestData_LHS[i].x9,
                               math.min((int)t_sbyte32.TestData_LHS[i].x10,
                               math.min((int)t_sbyte32.TestData_LHS[i].x11,
                               math.min((int)t_sbyte32.TestData_LHS[i].x12,
                               math.min((int)t_sbyte32.TestData_LHS[i].x13,
                               math.min((int)t_sbyte32.TestData_LHS[i].x14,
                               math.min((int)t_sbyte32.TestData_LHS[i].x15,
                               math.min((int)t_sbyte32.TestData_LHS[i].x16,
                               math.min((int)t_sbyte32.TestData_LHS[i].x17,
                               math.min((int)t_sbyte32.TestData_LHS[i].x18,
                               math.min((int)t_sbyte32.TestData_LHS[i].x19,
                               math.min((int)t_sbyte32.TestData_LHS[i].x20,
                               math.min((int)t_sbyte32.TestData_LHS[i].x21,
                               math.min((int)t_sbyte32.TestData_LHS[i].x22,
                               math.min((int)t_sbyte32.TestData_LHS[i].x23,
                               math.min((int)t_sbyte32.TestData_LHS[i].x24,
                               math.min((int)t_sbyte32.TestData_LHS[i].x25,
                               math.min((int)t_sbyte32.TestData_LHS[i].x26,
                               math.min((int)t_sbyte32.TestData_LHS[i].x27,
                               math.min((int)t_sbyte32.TestData_LHS[i].x28,
                               math.min((int)t_sbyte32.TestData_LHS[i].x29,
                               math.min((int)t_sbyte32.TestData_LHS[i].x30,
                                        (int)t_sbyte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _short2()
        {
            bool result = true;

            for (int i = 0; i < t_short2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_short2.TestData_LHS[i]);

                result &= x == math.min((int)t_short2.TestData_LHS[i].x,
                                        (int)t_short2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short3()
        {
            bool result = true;

            for (int i = 0; i < t_short3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_short3.TestData_LHS[i]);

                result &= x == math.min((int)t_short3.TestData_LHS[i].x,
                               math.min((int)t_short3.TestData_LHS[i].y,
                                        (int)t_short3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short4()
        {
            bool result = true;

            for (int i = 0; i < t_short4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_short4.TestData_LHS[i]);

                result &= x == math.min((int)t_short4.TestData_LHS[i].x,
                               math.min((int)t_short4.TestData_LHS[i].y,
                               math.min((int)t_short4.TestData_LHS[i].z,
                                        (int)t_short4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short8()
        {
            bool result = true;

            for (int i = 0; i < t_short8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_short8.TestData_LHS[i]);

                result &= x == math.min((int)t_short8.TestData_LHS[i].x0,
                               math.min((int)t_short8.TestData_LHS[i].x1,
                               math.min((int)t_short8.TestData_LHS[i].x2,
                               math.min((int)t_short8.TestData_LHS[i].x3,
                               math.min((int)t_short8.TestData_LHS[i].x4,
                               math.min((int)t_short8.TestData_LHS[i].x5,
                               math.min((int)t_short8.TestData_LHS[i].x6,
                                        (int)t_short8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short16()
        {
            bool result = true;

            for (int i = 0; i < t_short16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_short16.TestData_LHS[i]);

                result &= x == math.min((int)t_short16.TestData_LHS[i].x0,
                               math.min((int)t_short16.TestData_LHS[i].x1,
                               math.min((int)t_short16.TestData_LHS[i].x2,
                               math.min((int)t_short16.TestData_LHS[i].x3,
                               math.min((int)t_short16.TestData_LHS[i].x4,
                               math.min((int)t_short16.TestData_LHS[i].x5,
                               math.min((int)t_short16.TestData_LHS[i].x6,
                               math.min((int)t_short16.TestData_LHS[i].x7,
                               math.min((int)t_short16.TestData_LHS[i].x8,
                               math.min((int)t_short16.TestData_LHS[i].x9,
                               math.min((int)t_short16.TestData_LHS[i].x10,
                               math.min((int)t_short16.TestData_LHS[i].x11,
                               math.min((int)t_short16.TestData_LHS[i].x12,
                               math.min((int)t_short16.TestData_LHS[i].x13,
                               math.min((int)t_short16.TestData_LHS[i].x14,
                                        (int)t_short16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort2()
        {
            bool result = true;

            for (int i = 0; i < t_ushort2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_ushort2.TestData_LHS[i]);

                result &= x == math.min((int)t_ushort2.TestData_LHS[i].x,
                                        (int)t_ushort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort3()
        {
            bool result = true;

            for (int i = 0; i < t_ushort3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_ushort3.TestData_LHS[i]);

                result &= x == math.min((int)t_ushort3.TestData_LHS[i].x,
                               math.min((int)t_ushort3.TestData_LHS[i].y,
                                        (int)t_ushort3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort4()
        {
            bool result = true;

            for (int i = 0; i < t_ushort4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_ushort4.TestData_LHS[i]);

                result &= x == math.min((int)t_ushort4.TestData_LHS[i].x,
                               math.min((int)t_ushort4.TestData_LHS[i].y,
                               math.min((int)t_ushort4.TestData_LHS[i].z,
                                        (int)t_ushort4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort8()
        {
            bool result = true;

            for (int i = 0; i < t_ushort8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_ushort8.TestData_LHS[i]);

                result &= x == math.min((int)t_ushort8.TestData_LHS[i].x0,
                               math.min((int)t_ushort8.TestData_LHS[i].x1,
                               math.min((int)t_ushort8.TestData_LHS[i].x2,
                               math.min((int)t_ushort8.TestData_LHS[i].x3,
                               math.min((int)t_ushort8.TestData_LHS[i].x4,
                               math.min((int)t_ushort8.TestData_LHS[i].x5,
                               math.min((int)t_ushort8.TestData_LHS[i].x6,
                                        (int)t_ushort8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort16()
        {
            bool result = true;

            for (int i = 0; i < t_ushort16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_ushort16.TestData_LHS[i]);

                result &= x == math.min((int)t_ushort16.TestData_LHS[i].x0,
                               math.min((int)t_ushort16.TestData_LHS[i].x1,
                               math.min((int)t_ushort16.TestData_LHS[i].x2,
                               math.min((int)t_ushort16.TestData_LHS[i].x3,
                               math.min((int)t_ushort16.TestData_LHS[i].x4,
                               math.min((int)t_ushort16.TestData_LHS[i].x5,
                               math.min((int)t_ushort16.TestData_LHS[i].x6,
                               math.min((int)t_ushort16.TestData_LHS[i].x7,
                               math.min((int)t_ushort16.TestData_LHS[i].x8,
                               math.min((int)t_ushort16.TestData_LHS[i].x9,
                               math.min((int)t_ushort16.TestData_LHS[i].x10,
                               math.min((int)t_ushort16.TestData_LHS[i].x11,
                               math.min((int)t_ushort16.TestData_LHS[i].x12,
                               math.min((int)t_ushort16.TestData_LHS[i].x13,
                               math.min((int)t_ushort16.TestData_LHS[i].x14,
                                        (int)t_ushort16.TestData_LHS[i].x15)))))))))))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _int8()
        {
            bool result = true;

            for (int i = 0; i < t_int8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(t_int8.TestData_LHS[i]);

                result &= x == math.min((int)t_int8.TestData_LHS[i].x0,
                               math.min((int)t_int8.TestData_LHS[i].x1,
                               math.min((int)t_int8.TestData_LHS[i].x2,
                               math.min((int)t_int8.TestData_LHS[i].x3,
                               math.min((int)t_int8.TestData_LHS[i].x4,
                               math.min((int)t_int8.TestData_LHS[i].x5,
                               math.min((int)t_int8.TestData_LHS[i].x6,
                                        (int)t_int8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _uint8()
        {
            bool result = true;

            for (int i = 0; i < t_uint8.NUM_TESTS; i++)
            {
                uint x = maxmath.cmin(t_uint8.TestData_LHS[i]);

                result &= x == math.min(t_uint8.TestData_LHS[i].x0,
                               math.min(t_uint8.TestData_LHS[i].x1,
                               math.min(t_uint8.TestData_LHS[i].x2,
                               math.min(t_uint8.TestData_LHS[i].x3,
                               math.min(t_uint8.TestData_LHS[i].x4,
                               math.min(t_uint8.TestData_LHS[i].x5,
                               math.min(t_uint8.TestData_LHS[i].x6,
                                        t_uint8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _long2()
        {
            bool result = true;

            for (int i = 0; i < t_long2.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(t_long2.TestData_LHS[i]);

                result &= x == math.min(t_long2.TestData_LHS[i].x,
                                        t_long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long3()
        {
            bool result = true;

            for (int i = 0; i < t_long3.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(t_long3.TestData_LHS[i]);

                result &= x == math.min(t_long3.TestData_LHS[i].x,
                               math.min(t_long3.TestData_LHS[i].y,
                                        t_long3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long4()
        {
            bool result = true;

            for (int i = 0; i < t_long4.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(t_long4.TestData_LHS[i]);

                result &= x == math.min(t_long4.TestData_LHS[i].x,
                               math.min(t_long4.TestData_LHS[i].y,
                               math.min(t_long4.TestData_LHS[i].z,
                                        t_long4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ulong2()
        {
            bool result = true;

            for (int i = 0; i < t_ulong2.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(t_ulong2.TestData_LHS[i]);

                result &= x == math.min(t_ulong2.TestData_LHS[i].x,
                                        t_ulong2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ulong3()
        {
            bool result = true;

            for (int i = 0; i < t_ulong3.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(t_ulong3.TestData_LHS[i]);

                result &= x == math.min(t_ulong3.TestData_LHS[i].x,
                               math.min(t_ulong3.TestData_LHS[i].y,
                                        t_ulong3.TestData_LHS[i].z));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ulong4()
        {
            bool result = true;

            for (int i = 0; i < t_ulong4.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(t_ulong4.TestData_LHS[i]);

                result &= x == math.min(t_ulong4.TestData_LHS[i].x,
                               math.min(t_ulong4.TestData_LHS[i].y,
                               math.min(t_ulong4.TestData_LHS[i].z,
                                        t_ulong4.TestData_LHS[i].w)));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _float8()
        {
            bool result = true;

            for (int i = 0; i < t_float8.NUM_TESTS; i++)
            {
                float x = maxmath.cmin(t_float8.TestData_LHS[i]);

                result &= x == math.min(t_float8.TestData_LHS[i].x0,
                               math.min(t_float8.TestData_LHS[i].x1,
                               math.min(t_float8.TestData_LHS[i].x2,
                               math.min(t_float8.TestData_LHS[i].x3,
                               math.min(t_float8.TestData_LHS[i].x4,
                               math.min(t_float8.TestData_LHS[i].x5,
                               math.min(t_float8.TestData_LHS[i].x6,
                                        t_float8.TestData_LHS[i].x7)))))));
            }

            Assert.AreEqual(true, result);
        }
    }
}