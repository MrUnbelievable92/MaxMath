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

            for (int i = 0; i < Tests.__byte2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.__byte2.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.__byte2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.__byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.__byte3.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.__byte3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.__byte3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.__byte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.__byte4.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.__byte4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.__byte4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.__byte4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((uint)Tests.__byte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.__byte8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((uint)Tests.__byte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.__byte16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)Tests.__byte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte32.NUM_TESTS; i++)
            {
                bool32 t = maxmath.ispow2(Tests.__byte32.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x15);
                result &= t.x16 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x16);
                result &= t.x17 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x17);
                result &= t.x18 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x18);
                result &= t.x19 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x19);
                result &= t.x20 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x20);
                result &= t.x21 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x21);
                result &= t.x22 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x22);
                result &= t.x23 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x23);
                result &= t.x24 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x24);
                result &= t.x25 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x25);
                result &= t.x26 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x26);
                result &= t.x27 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x27);
                result &= t.x28 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x28);
                result &= t.x29 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x29);
                result &= t.x30 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x30);
                result &= t.x31 == math.ispow2((uint)Tests.__byte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.__ushort2.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.__ushort2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.__ushort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.__ushort3.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.__ushort3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.__ushort3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.__ushort3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.__ushort4.TestData_LHS[i]);

                result &= t.x == math.ispow2((uint)Tests.__ushort4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((uint)Tests.__ushort4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((uint)Tests.__ushort4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((uint)Tests.__ushort4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.__ushort8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((uint)Tests.__ushort8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.__ushort16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((uint)Tests.__ushort16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UInt8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__uint8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.__uint8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2(Tests.__uint8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2(Tests.__uint8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2(Tests.__uint8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2(Tests.__uint8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2(Tests.__uint8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2(Tests.__uint8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2(Tests.__uint8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2(Tests.__uint8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ULong2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.__ulong2.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.__ulong2.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.__ulong2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong3()
        {
            bool result = true;

            for (long i = 0; i < Tests.__ulong3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.__ulong3.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.__ulong3.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.__ulong3.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.__ulong3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong4()
        {
            bool result = true;

            for (long i = 0; i < Tests.__ulong4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.__ulong4.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.__ulong4.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.__ulong4.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.__ulong4.TestData_LHS[i].z);
                result &= t.w == maxmath.ispow2(Tests.__ulong4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.__sbyte2.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.__sbyte2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.__sbyte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.__sbyte3.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.__sbyte3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.__sbyte3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.__sbyte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.__sbyte4.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.__sbyte4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.__sbyte4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.__sbyte4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((int)Tests.__sbyte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.__sbyte8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((int)Tests.__sbyte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.__sbyte16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)Tests.__sbyte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte32.NUM_TESTS; i++)
            {
                bool32 t = maxmath.ispow2(Tests.__sbyte32.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x15);
                result &= t.x16 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x16);
                result &= t.x17 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x17);
                result &= t.x18 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x18);
                result &= t.x19 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x19);
                result &= t.x20 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x20);
                result &= t.x21 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x21);
                result &= t.x22 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x22);
                result &= t.x23 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x23);
                result &= t.x24 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x24);
                result &= t.x25 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x25);
                result &= t.x26 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x26);
                result &= t.x27 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x27);
                result &= t.x28 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x28);
                result &= t.x29 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x29);
                result &= t.x30 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x30);
                result &= t.x31 == math.ispow2((int)Tests.__sbyte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.__short2.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.__short2.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.__short2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.__short3.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.__short3.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.__short3.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.__short3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.__short4.TestData_LHS[i]);

                result &= t.x == math.ispow2((int)Tests.__short4.TestData_LHS[i].x);
                result &= t.y == math.ispow2((int)Tests.__short4.TestData_LHS[i].y);
                result &= t.z == math.ispow2((int)Tests.__short4.TestData_LHS[i].z);
                result &= t.w == math.ispow2((int)Tests.__short4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.__short8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2((int)Tests.__short8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short16.NUM_TESTS; i++)
            {
                bool16 t = maxmath.ispow2(Tests.__short16.TestData_LHS[i]);

                result &= t.x0  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x0 );
                result &= t.x1  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x1 );
                result &= t.x2  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x2 );
                result &= t.x3  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x3 );
                result &= t.x4  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x4 );
                result &= t.x5  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x5 );
                result &= t.x6  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x6 );
                result &= t.x7  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x7 );
                result &= t.x8  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x8 );
                result &= t.x9  == math.ispow2((int)Tests.__short16.TestData_LHS[i].x9 );
                result &= t.x10 == math.ispow2((int)Tests.__short16.TestData_LHS[i].x10);
                result &= t.x11 == math.ispow2((int)Tests.__short16.TestData_LHS[i].x11);
                result &= t.x12 == math.ispow2((int)Tests.__short16.TestData_LHS[i].x12);
                result &= t.x13 == math.ispow2((int)Tests.__short16.TestData_LHS[i].x13);
                result &= t.x14 == math.ispow2((int)Tests.__short16.TestData_LHS[i].x14);
                result &= t.x15 == math.ispow2((int)Tests.__short16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int8.NUM_TESTS; i++)
            {
                bool8 t = maxmath.ispow2(Tests.__int8.TestData_LHS[i]);

                result &= t.x0 == math.ispow2(Tests.__int8.TestData_LHS[i].x0);
                result &= t.x1 == math.ispow2(Tests.__int8.TestData_LHS[i].x1);
                result &= t.x2 == math.ispow2(Tests.__int8.TestData_LHS[i].x2);
                result &= t.x3 == math.ispow2(Tests.__int8.TestData_LHS[i].x3);
                result &= t.x4 == math.ispow2(Tests.__int8.TestData_LHS[i].x4);
                result &= t.x5 == math.ispow2(Tests.__int8.TestData_LHS[i].x5);
                result &= t.x6 == math.ispow2(Tests.__int8.TestData_LHS[i].x6);
                result &= t.x7 == math.ispow2(Tests.__int8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long2.NUM_TESTS; i++)
            {
                bool2 t = maxmath.ispow2(Tests.__long2.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.__long2.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.__long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (long i = 0; i < Tests.__long3.NUM_TESTS; i++)
            {
                bool3 t = maxmath.ispow2(Tests.__long3.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.__long3.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.__long3.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.__long3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (long i = 0; i < Tests.__long4.NUM_TESTS; i++)
            {
                bool4 t = maxmath.ispow2(Tests.__long4.TestData_LHS[i]);

                result &= t.x == maxmath.ispow2(Tests.__long4.TestData_LHS[i].x);
                result &= t.y == maxmath.ispow2(Tests.__long4.TestData_LHS[i].y);
                result &= t.z == maxmath.ispow2(Tests.__long4.TestData_LHS[i].z);
                result &= t.w == maxmath.ispow2(Tests.__long4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }
    }
}