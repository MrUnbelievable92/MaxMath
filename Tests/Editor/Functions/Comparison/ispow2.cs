using NUnit.Framework;
using Unity.Mathematics;
using MaxMath;

namespace MaxMath.Tests
{
    unsafe public static class ispow2
    {
        [Test]
        public static void Byte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.Byte2.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.Byte2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.Byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.Byte3.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.Byte3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.Byte3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.Byte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.Byte4.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.Byte4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.Byte4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.Byte4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((uint)Tests.Byte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.Byte8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((uint)Tests.Byte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.Byte16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)Tests.Byte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte32.NUM_TESTS; i++)
            {
                bool32 t = maxmath.ispow2(Tests.Byte32.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x15);
                result &= t.x16 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x16);
                result &= t.x17 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x17);
                result &= t.x18 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x18);
                result &= t.x19 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x19);
                result &= t.x20 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x20);
                result &= t.x21 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x21);
                result &= t.x22 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x22);
                result &= t.x23 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x23);
                result &= t.x24 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x24);
                result &= t.x25 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x25);
                result &= t.x26 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x26);
                result &= t.x27 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x27);
                result &= t.x28 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x28);
                result &= t.x29 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x29);
                result &= t.x30 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x30);
                result &= t.x31 == math.ispow2((uint)Tests.Byte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.UShort2.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.UShort2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.UShort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.UShort3.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.UShort3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.UShort3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.UShort3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.UShort4.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.UShort4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.UShort4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.UShort4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((uint)Tests.UShort4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.UShort8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((uint)Tests.UShort8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.UShort16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)Tests.UShort16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UInt8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UInt8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.UInt8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2(Tests.UInt8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2(Tests.UInt8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2(Tests.UInt8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2(Tests.UInt8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2(Tests.UInt8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2(Tests.UInt8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2(Tests.UInt8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2(Tests.UInt8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ULong2()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.ULong2.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.ULong2.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.ULong2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong3()
        {
            bool result = true;

            for (long i = 0; i < Tests.ULong3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.ULong3.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.ULong3.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.ULong3.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.ULong3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong4()
        {
            bool result = true;

            for (long i = 0; i < Tests.ULong4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.ULong4.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.ULong4.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.ULong4.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.ULong4.TestData_LHS[i].z);
                result &= t.w == maxmath.ispow2(Tests.ULong4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.SByte2.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.SByte2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.SByte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.SByte3.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.SByte3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.SByte3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.SByte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.SByte4.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.SByte4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.SByte4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.SByte4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((int)Tests.SByte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.SByte8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((int)Tests.SByte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.SByte16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)Tests.SByte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                bool32 t = maxmath.ispow2(Tests.SByte32.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x15);
                result &= t.x16 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x16);
                result &= t.x17 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x17);
                result &= t.x18 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x18);
                result &= t.x19 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x19);
                result &= t.x20 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x20);
                result &= t.x21 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x21);
                result &= t.x22 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x22);
                result &= t.x23 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x23);
                result &= t.x24 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x24);
                result &= t.x25 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x25);
                result &= t.x26 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x26);
                result &= t.x27 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x27);
                result &= t.x28 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x28);
                result &= t.x29 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x29);
                result &= t.x30 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x30);
                result &= t.x31 == math.ispow2((int)Tests.SByte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.Short2.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.Short2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.Short2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.Short3.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.Short3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.Short3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.Short3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.Short4.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.Short4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.Short4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.Short4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((int)Tests.Short4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.Short8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((int)Tests.Short8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.Short16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)Tests.Short16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)Tests.Short16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)Tests.Short16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)Tests.Short16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)Tests.Short16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)Tests.Short16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)Tests.Short16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.Int8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2(Tests.Int8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2(Tests.Int8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2(Tests.Int8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2(Tests.Int8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2(Tests.Int8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2(Tests.Int8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2(Tests.Int8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2(Tests.Int8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.Long2.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.Long2.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.Long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (long i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.Long3.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.Long3.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.Long3.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.Long3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (long i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.Long4.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.Long4.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.Long4.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.Long4.TestData_LHS[i].z);
                result &= t.w == maxmath.ispow2(Tests.Long4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }
    }
}