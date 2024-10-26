using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_ispow2
    {
        [Test]
        public static void _byte2()
        {
            bool result = true;

            for (int i = 0; i < t_byte2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(t_byte2.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)t_byte2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)t_byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte3()
        {
            bool result = true;

            for (int i = 0; i < t_byte3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(t_byte3.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)t_byte3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)t_byte3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)t_byte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte4()
        {
            bool result = true;

            for (int i = 0; i < t_byte4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(t_byte4.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)t_byte4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)t_byte4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)t_byte4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((uint)t_byte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte8()
        {
            bool result = true;

            for (int i = 0; i < t_byte8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(t_byte8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((uint)t_byte8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((uint)t_byte8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((uint)t_byte8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((uint)t_byte8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((uint)t_byte8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((uint)t_byte8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((uint)t_byte8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((uint)t_byte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte16()
        {
            bool result = true;

            for (int i = 0; i < t_byte16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(t_byte16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)t_byte16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)t_byte16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)t_byte16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)t_byte16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)t_byte16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)t_byte16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)t_byte16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)t_byte16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)t_byte16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)t_byte16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)t_byte16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)t_byte16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)t_byte16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)t_byte16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)t_byte16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)t_byte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _byte32()
        {
            bool result = true;

            for (int i = 0; i < t_byte32.NUM_TESTS; i++)
            {
                bool32 t = maxmath.ispow2(t_byte32.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)t_byte32.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)t_byte32.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)t_byte32.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)t_byte32.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)t_byte32.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)t_byte32.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)t_byte32.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)t_byte32.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)t_byte32.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)t_byte32.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)t_byte32.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)t_byte32.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)t_byte32.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)t_byte32.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)t_byte32.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)t_byte32.TestData_LHS[i].x15);
                result &= t.x16 == math.ispow2((uint)t_byte32.TestData_LHS[i].x16);
                result &= t.x17 == math.ispow2((uint)t_byte32.TestData_LHS[i].x17);
                result &= t.x18 == math.ispow2((uint)t_byte32.TestData_LHS[i].x18);
                result &= t.x19 == math.ispow2((uint)t_byte32.TestData_LHS[i].x19);
                result &= t.x20 == math.ispow2((uint)t_byte32.TestData_LHS[i].x20);
                result &= t.x21 == math.ispow2((uint)t_byte32.TestData_LHS[i].x21);
                result &= t.x22 == math.ispow2((uint)t_byte32.TestData_LHS[i].x22);
                result &= t.x23 == math.ispow2((uint)t_byte32.TestData_LHS[i].x23);
                result &= t.x24 == math.ispow2((uint)t_byte32.TestData_LHS[i].x24);
                result &= t.x25 == math.ispow2((uint)t_byte32.TestData_LHS[i].x25);
                result &= t.x26 == math.ispow2((uint)t_byte32.TestData_LHS[i].x26);
                result &= t.x27 == math.ispow2((uint)t_byte32.TestData_LHS[i].x27);
                result &= t.x28 == math.ispow2((uint)t_byte32.TestData_LHS[i].x28);
                result &= t.x29 == math.ispow2((uint)t_byte32.TestData_LHS[i].x29);
                result &= t.x30 == math.ispow2((uint)t_byte32.TestData_LHS[i].x30);
                result &= t.x31 == math.ispow2((uint)t_byte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort2()
        {
            bool result = true;

            for (int i = 0; i < t_ushort2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(t_ushort2.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)t_ushort2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)t_ushort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort3()
        {
            bool result = true;

            for (int i = 0; i < t_ushort3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(t_ushort3.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)t_ushort3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)t_ushort3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)t_ushort3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort4()
        {
            bool result = true;

            for (int i = 0; i < t_ushort4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(t_ushort4.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)t_ushort4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)t_ushort4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)t_ushort4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((uint)t_ushort4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort8()
        {
            bool result = true;

            for (int i = 0; i < t_ushort8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(t_ushort8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((uint)t_ushort8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ushort16()
        {
            bool result = true;

            for (int i = 0; i < t_ushort16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(t_ushort16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)t_ushort16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)t_ushort16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)t_ushort16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)t_ushort16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)t_ushort16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)t_ushort16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)t_ushort16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _uint8()
        {
            bool result = true;

            for (int i = 0; i < t_uint8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(t_uint8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2(t_uint8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2(t_uint8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2(t_uint8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2(t_uint8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2(t_uint8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2(t_uint8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2(t_uint8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2(t_uint8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ulong2()
        {
            bool result = true;

            for (int i = 0; i < t_ulong2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(t_ulong2.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(t_ulong2.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(t_ulong2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ulong3()
        {
            bool result = true;

            for (long i = 0; i < t_ulong3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(t_ulong3.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(t_ulong3.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(t_ulong3.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(t_ulong3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _ulong4()
        {
            bool result = true;

            for (long i = 0; i < t_ulong4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(t_ulong4.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(t_ulong4.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(t_ulong4.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(t_ulong4.TestData_LHS[i].z);
                result &= t.w == maxmath.ispow2(t_ulong4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _sbyte2()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(t_sbyte2.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)t_sbyte2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)t_sbyte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte3()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(t_sbyte3.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)t_sbyte3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)t_sbyte3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)t_sbyte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte4()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(t_sbyte4.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)t_sbyte4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)t_sbyte4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)t_sbyte4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((int)t_sbyte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte8()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(t_sbyte8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((int)t_sbyte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte16()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(t_sbyte16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)t_sbyte16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)t_sbyte16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)t_sbyte16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)t_sbyte16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)t_sbyte16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)t_sbyte16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)t_sbyte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte32()
        {
            bool result = true;

            for (int i = 0; i < t_sbyte32.NUM_TESTS; i++)
            {
                bool32 t = maxmath.ispow2(t_sbyte32.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)t_sbyte32.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x15);
                result &= t.x16 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x16);
                result &= t.x17 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x17);
                result &= t.x18 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x18);
                result &= t.x19 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x19);
                result &= t.x20 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x20);
                result &= t.x21 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x21);
                result &= t.x22 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x22);
                result &= t.x23 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x23);
                result &= t.x24 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x24);
                result &= t.x25 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x25);
                result &= t.x26 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x26);
                result &= t.x27 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x27);
                result &= t.x28 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x28);
                result &= t.x29 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x29);
                result &= t.x30 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x30);
                result &= t.x31 == math.ispow2((int)t_sbyte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _short2()
        {
            bool result = true;

            for (int i = 0; i < t_short2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(t_short2.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)t_short2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)t_short2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short3()
        {
            bool result = true;

            for (int i = 0; i < t_short3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(t_short3.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)t_short3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)t_short3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)t_short3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short4()
        {
            bool result = true;

            for (int i = 0; i < t_short4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(t_short4.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)t_short4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)t_short4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)t_short4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((int)t_short4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short8()
        {
            bool result = true;

            for (int i = 0; i < t_short8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(t_short8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((int)t_short8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((int)t_short8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((int)t_short8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((int)t_short8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((int)t_short8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((int)t_short8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((int)t_short8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((int)t_short8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short16()
        {
            bool result = true;

            for (int i = 0; i < t_short16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(t_short16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)t_short16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)t_short16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)t_short16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)t_short16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)t_short16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)t_short16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)t_short16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)t_short16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)t_short16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)t_short16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)t_short16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)t_short16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)t_short16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)t_short16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)t_short16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)t_short16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _int8()
        {
            bool result = true;

            for (int i = 0; i < t_int8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(t_int8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2(t_int8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2(t_int8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2(t_int8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2(t_int8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2(t_int8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2(t_int8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2(t_int8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2(t_int8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _long2()
        {
            bool result = true;

            for (int i = 0; i < t_long2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(t_long2.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(t_long2.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(t_long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long3()
        {
            bool result = true;

            for (long i = 0; i < t_long3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(t_long3.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(t_long3.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(t_long3.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(t_long3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long4()
        {
            bool result = true;

            for (long i = 0; i < t_long4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(t_long4.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(t_long4.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(t_long4.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(t_long4.TestData_LHS[i].z);
                result &= t.w == maxmath.ispow2(t_long4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }
    }
}