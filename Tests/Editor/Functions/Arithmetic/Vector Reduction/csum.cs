using NUnit.Framework;

namespace MaxMath.Tests
{
    /// __float8 implicitly tested by testing Int8
    unsafe public static class f_csum
    {
        [Test]
        public static void _byte2()
        {
            bool result = true;

            for (int i = 0; i < t_byte2.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_byte2.TestData_LHS[i]);

                result &= x == ((uint)t_byte2.TestData_LHS[i].x +
                                (uint)t_byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte3()
        {
            bool result = true;

            for (int i = 0; i < t_byte3.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_byte3.TestData_LHS[i]);

                result &= x == ((uint)t_byte3.TestData_LHS[i].x +
                                (uint)t_byte3.TestData_LHS[i].y +
                                (uint)t_byte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte4()
        {
            bool result = true;

            for (int i = 0; i < t_byte4.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_byte4.TestData_LHS[i]);

                result &= x == ((uint)t_byte4.TestData_LHS[i].x +
                                (uint)t_byte4.TestData_LHS[i].y +
                                (uint)t_byte4.TestData_LHS[i].z +
                                (uint)t_byte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte8()
        {
            bool result = true;

            for (int i = 0; i < t_byte8.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_byte8.TestData_LHS[i]);

                result &= x == ((uint)t_byte8.TestData_LHS[i].x0 +
                                (uint)t_byte8.TestData_LHS[i].x1 +
                                (uint)t_byte8.TestData_LHS[i].x2 +
                                (uint)t_byte8.TestData_LHS[i].x3 +
                                (uint)t_byte8.TestData_LHS[i].x4 +
                                (uint)t_byte8.TestData_LHS[i].x5 +
                                (uint)t_byte8.TestData_LHS[i].x6 +
                                (uint)t_byte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte16()
        {
            bool result = true;

            for (int i = 0; i < t_byte16.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_byte16.TestData_LHS[i]);

                result &= x == ((uint)t_byte16.TestData_LHS[i].x0 +
                                (uint)t_byte16.TestData_LHS[i].x1 +
                                (uint)t_byte16.TestData_LHS[i].x2 +
                                (uint)t_byte16.TestData_LHS[i].x3 +
                                (uint)t_byte16.TestData_LHS[i].x4 +
                                (uint)t_byte16.TestData_LHS[i].x5 +
                                (uint)t_byte16.TestData_LHS[i].x6 +
                                (uint)t_byte16.TestData_LHS[i].x7 +
                                (uint)t_byte16.TestData_LHS[i].x8 +
                                (uint)t_byte16.TestData_LHS[i].x9 +
                                (uint)t_byte16.TestData_LHS[i].x10 +
                                (uint)t_byte16.TestData_LHS[i].x11 +
                                (uint)t_byte16.TestData_LHS[i].x12 +
                                (uint)t_byte16.TestData_LHS[i].x13 +
                                (uint)t_byte16.TestData_LHS[i].x14 +
                                (uint)t_byte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte32()
        {
            bool result = true;

            for (int i = 0; i < t_byte32.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_byte32.TestData_LHS[i]);

                result &= x == ((uint)t_byte32.TestData_LHS[i].x0 +
                                (uint)t_byte32.TestData_LHS[i].x1 +
                                (uint)t_byte32.TestData_LHS[i].x2 +
                                (uint)t_byte32.TestData_LHS[i].x3 +
                                (uint)t_byte32.TestData_LHS[i].x4 +
                                (uint)t_byte32.TestData_LHS[i].x5 +
                                (uint)t_byte32.TestData_LHS[i].x6 +
                                (uint)t_byte32.TestData_LHS[i].x7 +
                                (uint)t_byte32.TestData_LHS[i].x8 +
                                (uint)t_byte32.TestData_LHS[i].x9 +
                                (uint)t_byte32.TestData_LHS[i].x10 +
                                (uint)t_byte32.TestData_LHS[i].x11 +
                                (uint)t_byte32.TestData_LHS[i].x12 +
                                (uint)t_byte32.TestData_LHS[i].x13 +
                                (uint)t_byte32.TestData_LHS[i].x14 +
                                (uint)t_byte32.TestData_LHS[i].x15 +
                                (uint)t_byte32.TestData_LHS[i].x16 +
                                (uint)t_byte32.TestData_LHS[i].x17 +
                                (uint)t_byte32.TestData_LHS[i].x18 +
                                (uint)t_byte32.TestData_LHS[i].x19 +
                                (uint)t_byte32.TestData_LHS[i].x20 +
                                (uint)t_byte32.TestData_LHS[i].x21 +
                                (uint)t_byte32.TestData_LHS[i].x22 +
                                (uint)t_byte32.TestData_LHS[i].x23 +
                                (uint)t_byte32.TestData_LHS[i].x24 +
                                (uint)t_byte32.TestData_LHS[i].x25 +
                                (uint)t_byte32.TestData_LHS[i].x26 +
                                (uint)t_byte32.TestData_LHS[i].x27 +
                                (uint)t_byte32.TestData_LHS[i].x28 +
                                (uint)t_byte32.TestData_LHS[i].x29 +
                                (uint)t_byte32.TestData_LHS[i].x30 +
                                (uint)t_byte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _sbyte2()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte2.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_sbyte2.TestData_LHS[i]);

                result &= x == ((int)t_sbyte2.TestData_LHS[i].x +
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
                int x = maxmath.csum(t_sbyte3.TestData_LHS[i]);

                result &= x == ((int)t_sbyte3.TestData_LHS[i].x +
                                (int)t_sbyte3.TestData_LHS[i].y +
                                (int)t_sbyte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte4()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte4.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_sbyte4.TestData_LHS[i]);

                result &= x == ((int)t_sbyte4.TestData_LHS[i].x +
                                (int)t_sbyte4.TestData_LHS[i].y +
                                (int)t_sbyte4.TestData_LHS[i].z +
                                (int)t_sbyte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte8()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte8.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_sbyte8.TestData_LHS[i]);

                result &= x == ((int)t_sbyte8.TestData_LHS[i].x0 +
                                (int)t_sbyte8.TestData_LHS[i].x1 +
                                (int)t_sbyte8.TestData_LHS[i].x2 +
                                (int)t_sbyte8.TestData_LHS[i].x3 +
                                (int)t_sbyte8.TestData_LHS[i].x4 +
                                (int)t_sbyte8.TestData_LHS[i].x5 +
                                (int)t_sbyte8.TestData_LHS[i].x6 +
                                (int)t_sbyte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte16()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte16.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_sbyte16.TestData_LHS[i]);

                result &= x == ((int)t_sbyte16.TestData_LHS[i].x0 +
                                (int)t_sbyte16.TestData_LHS[i].x1 +
                                (int)t_sbyte16.TestData_LHS[i].x2 +
                                (int)t_sbyte16.TestData_LHS[i].x3 +
                                (int)t_sbyte16.TestData_LHS[i].x4 +
                                (int)t_sbyte16.TestData_LHS[i].x5 +
                                (int)t_sbyte16.TestData_LHS[i].x6 +
                                (int)t_sbyte16.TestData_LHS[i].x7 +
                                (int)t_sbyte16.TestData_LHS[i].x8 +
                                (int)t_sbyte16.TestData_LHS[i].x9 +
                                (int)t_sbyte16.TestData_LHS[i].x10 +
                                (int)t_sbyte16.TestData_LHS[i].x11 +
                                (int)t_sbyte16.TestData_LHS[i].x12 +
                                (int)t_sbyte16.TestData_LHS[i].x13 +
                                (int)t_sbyte16.TestData_LHS[i].x14 +
                                (int)t_sbyte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte32()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte32.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_sbyte32.TestData_LHS[i]);

                result &= x == ((int)t_sbyte32.TestData_LHS[i].x0 +
                                (int)t_sbyte32.TestData_LHS[i].x1 +
                                (int)t_sbyte32.TestData_LHS[i].x2 +
                                (int)t_sbyte32.TestData_LHS[i].x3 +
                                (int)t_sbyte32.TestData_LHS[i].x4 +
                                (int)t_sbyte32.TestData_LHS[i].x5 +
                                (int)t_sbyte32.TestData_LHS[i].x6 +
                                (int)t_sbyte32.TestData_LHS[i].x7 +
                                (int)t_sbyte32.TestData_LHS[i].x8 +
                                (int)t_sbyte32.TestData_LHS[i].x9 +
                                (int)t_sbyte32.TestData_LHS[i].x10 +
                                (int)t_sbyte32.TestData_LHS[i].x11 +
                                (int)t_sbyte32.TestData_LHS[i].x12 +
                                (int)t_sbyte32.TestData_LHS[i].x13 +
                                (int)t_sbyte32.TestData_LHS[i].x14 +
                                (int)t_sbyte32.TestData_LHS[i].x15 +
                                (int)t_sbyte32.TestData_LHS[i].x16 +
                                (int)t_sbyte32.TestData_LHS[i].x17 +
                                (int)t_sbyte32.TestData_LHS[i].x18 +
                                (int)t_sbyte32.TestData_LHS[i].x19 +
                                (int)t_sbyte32.TestData_LHS[i].x20 +
                                (int)t_sbyte32.TestData_LHS[i].x21 +
                                (int)t_sbyte32.TestData_LHS[i].x22 +
                                (int)t_sbyte32.TestData_LHS[i].x23 +
                                (int)t_sbyte32.TestData_LHS[i].x24 +
                                (int)t_sbyte32.TestData_LHS[i].x25 +
                                (int)t_sbyte32.TestData_LHS[i].x26 +
                                (int)t_sbyte32.TestData_LHS[i].x27 +
                                (int)t_sbyte32.TestData_LHS[i].x28 +
                                (int)t_sbyte32.TestData_LHS[i].x29 +
                                (int)t_sbyte32.TestData_LHS[i].x30 +
                                (int)t_sbyte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort2()
        {
            bool result = true;

            for (int i = 0; i < t_ushort2.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_ushort2.TestData_LHS[i]);

                result &= x == ((uint)t_ushort2.TestData_LHS[i].x +
                                (uint)t_ushort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort3()
        {
            bool result = true;

            for (int i = 0; i < t_ushort3.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_ushort3.TestData_LHS[i]);

                result &= x == ((uint)t_ushort3.TestData_LHS[i].x +
                                (uint)t_ushort3.TestData_LHS[i].y +
                                (uint)t_ushort3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort4()
        {
            bool result = true;

            for (int i = 0; i < t_ushort4.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_ushort4.TestData_LHS[i]);

                result &= x == ((uint)t_ushort4.TestData_LHS[i].x +
                                (uint)t_ushort4.TestData_LHS[i].y +
                                (uint)t_ushort4.TestData_LHS[i].z +
                                (uint)t_ushort4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort8()
        {
            bool result = true;

            for (int i = 0; i < t_ushort8.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_ushort8.TestData_LHS[i]);

                result &= x == ((uint)t_ushort8.TestData_LHS[i].x0 +
                                (uint)t_ushort8.TestData_LHS[i].x1 +
                                (uint)t_ushort8.TestData_LHS[i].x2 +
                                (uint)t_ushort8.TestData_LHS[i].x3 +
                                (uint)t_ushort8.TestData_LHS[i].x4 +
                                (uint)t_ushort8.TestData_LHS[i].x5 +
                                (uint)t_ushort8.TestData_LHS[i].x6 +
                                (uint)t_ushort8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort16()
        {
            bool result = true;

            for (int i = 0; i < t_ushort16.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_ushort16.TestData_LHS[i]);

                result &= x == ((uint)t_ushort16.TestData_LHS[i].x0 +
                                (uint)t_ushort16.TestData_LHS[i].x1 +
                                (uint)t_ushort16.TestData_LHS[i].x2 +
                                (uint)t_ushort16.TestData_LHS[i].x3 +
                                (uint)t_ushort16.TestData_LHS[i].x4 +
                                (uint)t_ushort16.TestData_LHS[i].x5 +
                                (uint)t_ushort16.TestData_LHS[i].x6 +
                                (uint)t_ushort16.TestData_LHS[i].x7 +
                                (uint)t_ushort16.TestData_LHS[i].x8 +
                                (uint)t_ushort16.TestData_LHS[i].x9 +
                                (uint)t_ushort16.TestData_LHS[i].x10 +
                                (uint)t_ushort16.TestData_LHS[i].x11 +
                                (uint)t_ushort16.TestData_LHS[i].x12 +
                                (uint)t_ushort16.TestData_LHS[i].x13 +
                                (uint)t_ushort16.TestData_LHS[i].x14 +
                                (uint)t_ushort16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _short2()
        {
            bool result = true;

            for (int i = 0; i < t_short2.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_short2.TestData_LHS[i]);

                result &= x == ((int)t_short2.TestData_LHS[i].x +
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
                int x = maxmath.csum(t_short3.TestData_LHS[i]);

                result &= x == ((int)t_short3.TestData_LHS[i].x +
                                (int)t_short3.TestData_LHS[i].y +
                                (int)t_short3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short4()
        {
            bool result = true;

            for (int i = 0; i < t_short4.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_short4.TestData_LHS[i]);

                result &= x == ((int)t_short4.TestData_LHS[i].x +
                                (int)t_short4.TestData_LHS[i].y +
                                (int)t_short4.TestData_LHS[i].z +
                                (int)t_short4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short8()
        {
            bool result = true;

            for (int i = 0; i < t_short8.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_short8.TestData_LHS[i]);

                result &= x == ((int)t_short8.TestData_LHS[i].x0 +
                                (int)t_short8.TestData_LHS[i].x1 +
                                (int)t_short8.TestData_LHS[i].x2 +
                                (int)t_short8.TestData_LHS[i].x3 +
                                (int)t_short8.TestData_LHS[i].x4 +
                                (int)t_short8.TestData_LHS[i].x5 +
                                (int)t_short8.TestData_LHS[i].x6 +
                                (int)t_short8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short16()
        {
            bool result = true;

            for (int i = 0; i < t_short16.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_short16.TestData_LHS[i]);

                result &= x == ((int)t_short16.TestData_LHS[i].x0 +
                                (int)t_short16.TestData_LHS[i].x1 +
                                (int)t_short16.TestData_LHS[i].x2 +
                                (int)t_short16.TestData_LHS[i].x3 +
                                (int)t_short16.TestData_LHS[i].x4 +
                                (int)t_short16.TestData_LHS[i].x5 +
                                (int)t_short16.TestData_LHS[i].x6 +
                                (int)t_short16.TestData_LHS[i].x7 +
                                (int)t_short16.TestData_LHS[i].x8 +
                                (int)t_short16.TestData_LHS[i].x9 +
                                (int)t_short16.TestData_LHS[i].x10 +
                                (int)t_short16.TestData_LHS[i].x11 +
                                (int)t_short16.TestData_LHS[i].x12 +
                                (int)t_short16.TestData_LHS[i].x13 +
                                (int)t_short16.TestData_LHS[i].x14 +
                                (int)t_short16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _int8()
        {
            bool result = true;

            for (int i = 0; i < t_int8.NUM_TESTS; i++)
            {
                int x = maxmath.csum(t_int8.TestData_LHS[i]);

                result &= x == (t_int8.TestData_LHS[i].x0 +
                                t_int8.TestData_LHS[i].x1 +
                                t_int8.TestData_LHS[i].x2 +
                                t_int8.TestData_LHS[i].x3 +
                                t_int8.TestData_LHS[i].x4 +
                                t_int8.TestData_LHS[i].x5 +
                                t_int8.TestData_LHS[i].x6 +
                                t_int8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _uint8()
        {
            bool result = true;

            for (int i = 0; i < t_uint8.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(t_uint8.TestData_LHS[i]);

                result &= x == (t_uint8.TestData_LHS[i].x0 +
                                t_uint8.TestData_LHS[i].x1 +
                                t_uint8.TestData_LHS[i].x2 +
                                t_uint8.TestData_LHS[i].x3 +
                                t_uint8.TestData_LHS[i].x4 +
                                t_uint8.TestData_LHS[i].x5 +
                                t_uint8.TestData_LHS[i].x6 +
                                t_uint8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _long2()
        {
            bool result = true;

            for (int i = 0; i < t_long2.NUM_TESTS; i++)
            {
                long x = maxmath.csum(t_long2.TestData_LHS[i]);

                result &= x == (t_long2.TestData_LHS[i].x +
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
                long x = maxmath.csum(t_long3.TestData_LHS[i]);

                result &= x == (t_long3.TestData_LHS[i].x +
                                t_long3.TestData_LHS[i].y +
                                t_long3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long4()
        {
            bool result = true;

            for (int i = 0; i < t_long4.NUM_TESTS; i++)
            {
                long x = maxmath.csum(t_long4.TestData_LHS[i]);

                result &= x == (t_long4.TestData_LHS[i].x +
                                t_long4.TestData_LHS[i].y +
                                t_long4.TestData_LHS[i].z +
                                t_long4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ulong2()
        {
            bool result = true;

            for (int i = 0; i < t_ulong2.NUM_TESTS; i++)
            {
                ulong x = maxmath.csum(t_ulong2.TestData_LHS[i]);

                result &= x == (t_ulong2.TestData_LHS[i].x +
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
                ulong x = maxmath.csum(t_ulong3.TestData_LHS[i]);

                result &= x == (t_ulong3.TestData_LHS[i].x +
                                t_ulong3.TestData_LHS[i].y +
                                t_ulong3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ulong4()
        {
            bool result = true;

            for (int i = 0; i < t_ulong4.NUM_TESTS; i++)
            {
                ulong x = maxmath.csum(t_ulong4.TestData_LHS[i]);

                result &= x == (t_ulong4.TestData_LHS[i].x +
                                t_ulong4.TestData_LHS[i].y +
                                t_ulong4.TestData_LHS[i].z +
                                t_ulong4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _float8()
        {
            bool result = true;

            for (int i = 0; i < t_float8.NUM_TESTS; i++)
            {
                float x = maxmath.csum(t_float8.TestData_LHS[i]);

                result &= maxmath.approx(x, (t_float8.TestData_LHS[i].x0 +
                                             t_float8.TestData_LHS[i].x1 +
                                             t_float8.TestData_LHS[i].x2 +
                                             t_float8.TestData_LHS[i].x3 +
                                             t_float8.TestData_LHS[i].x4 +
                                             t_float8.TestData_LHS[i].x5 +
                                             t_float8.TestData_LHS[i].x6 +
                                             t_float8.TestData_LHS[i].x7), 0.01f);
            }

            Assert.AreEqual(true, result);
        }
    }
}