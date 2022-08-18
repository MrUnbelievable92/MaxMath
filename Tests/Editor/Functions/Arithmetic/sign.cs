using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class sign
    {
        [Test]
        public static void Float8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__float8.NUM_TESTS; i++)
            {
                float8 t = maxmath.sign(Tests.__float8.TestData_LHS[i]);

                result &= t.x0 == math.sign(Tests.__float8.TestData_LHS[i].x0);
                result &= t.x1 == math.sign(Tests.__float8.TestData_LHS[i].x1);
                result &= t.x2 == math.sign(Tests.__float8.TestData_LHS[i].x2);
                result &= t.x3 == math.sign(Tests.__float8.TestData_LHS[i].x3);
                result &= t.x4 == math.sign(Tests.__float8.TestData_LHS[i].x4);
                result &= t.x5 == math.sign(Tests.__float8.TestData_LHS[i].x5);
                result &= t.x6 == math.sign(Tests.__float8.TestData_LHS[i].x6);
                result &= t.x7 == math.sign(Tests.__float8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte2.NUM_TESTS; i++)
            {
                sbyte2 t = maxmath.sign(Tests.__sbyte2.TestData_LHS[i]);

                result &= t.x == ((Tests.__sbyte2.TestData_LHS[i].x == 0) ? 0 : ((Tests.__sbyte2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__sbyte2.TestData_LHS[i].y == 0) ? 0 : ((Tests.__sbyte2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte3.NUM_TESTS; i++)
            {
                sbyte3 t = maxmath.sign(Tests.__sbyte3.TestData_LHS[i]);

                result &= t.x == ((Tests.__sbyte3.TestData_LHS[i].x == 0) ? 0 : ((Tests.__sbyte3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__sbyte3.TestData_LHS[i].y == 0) ? 0 : ((Tests.__sbyte3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__sbyte3.TestData_LHS[i].z == 0) ? 0 : ((Tests.__sbyte3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.__sbyte4.NUM_TESTS; i++)
            {
                sbyte4 t = maxmath.sign(Tests.__sbyte4.TestData_LHS[i]);

                result &= t.x == ((Tests.__sbyte4.TestData_LHS[i].x == 0) ? 0 : ((Tests.__sbyte4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__sbyte4.TestData_LHS[i].y == 0) ? 0 : ((Tests.__sbyte4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__sbyte4.TestData_LHS[i].z == 0) ? 0 : ((Tests.__sbyte4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.__sbyte4.TestData_LHS[i].w == 0) ? 0 : ((Tests.__sbyte4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte8.NUM_TESTS; i++)
            {
                sbyte8 t = maxmath.sign(Tests.__sbyte8.TestData_LHS[i]);

                result &= t.x0 == ((Tests.__sbyte8.TestData_LHS[i].x0 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x0 < 0) ? -1 : 1));
                result &= t.x1 == ((Tests.__sbyte8.TestData_LHS[i].x1 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x1 < 0) ? -1 : 1));
                result &= t.x2 == ((Tests.__sbyte8.TestData_LHS[i].x2 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x2 < 0) ? -1 : 1));
                result &= t.x3 == ((Tests.__sbyte8.TestData_LHS[i].x3 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x3 < 0) ? -1 : 1));
                result &= t.x4 == ((Tests.__sbyte8.TestData_LHS[i].x4 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x4 < 0) ? -1 : 1));
                result &= t.x5 == ((Tests.__sbyte8.TestData_LHS[i].x5 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x5 < 0) ? -1 : 1));
                result &= t.x6 == ((Tests.__sbyte8.TestData_LHS[i].x6 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x6 < 0) ? -1 : 1));
                result &= t.x7 == ((Tests.__sbyte8.TestData_LHS[i].x7 == 0) ? 0 : ((Tests.__sbyte8.TestData_LHS[i].x7 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte16.NUM_TESTS; i++)
            {
                sbyte16 t = maxmath.sign(Tests.__sbyte16.TestData_LHS[i]);

                result &= t.x0  == ((Tests.__sbyte16.TestData_LHS[i].x0  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x0  < 0) ? -1 : 1));
                result &= t.x1  == ((Tests.__sbyte16.TestData_LHS[i].x1  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x1  < 0) ? -1 : 1));
                result &= t.x2  == ((Tests.__sbyte16.TestData_LHS[i].x2  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x2  < 0) ? -1 : 1));
                result &= t.x3  == ((Tests.__sbyte16.TestData_LHS[i].x3  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x3  < 0) ? -1 : 1));
                result &= t.x4  == ((Tests.__sbyte16.TestData_LHS[i].x4  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x4  < 0) ? -1 : 1));
                result &= t.x5  == ((Tests.__sbyte16.TestData_LHS[i].x5  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x5  < 0) ? -1 : 1));
                result &= t.x6  == ((Tests.__sbyte16.TestData_LHS[i].x6  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x6  < 0) ? -1 : 1));
                result &= t.x7  == ((Tests.__sbyte16.TestData_LHS[i].x7  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x7  < 0) ? -1 : 1));
                result &= t.x8  == ((Tests.__sbyte16.TestData_LHS[i].x8  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x8  < 0) ? -1 : 1));
                result &= t.x9  == ((Tests.__sbyte16.TestData_LHS[i].x9  == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x9  < 0) ? -1 : 1));
                result &= t.x10 == ((Tests.__sbyte16.TestData_LHS[i].x10 == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x10 < 0) ? -1 : 1));
                result &= t.x11 == ((Tests.__sbyte16.TestData_LHS[i].x11 == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x11 < 0) ? -1 : 1));
                result &= t.x12 == ((Tests.__sbyte16.TestData_LHS[i].x12 == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x12 < 0) ? -1 : 1));
                result &= t.x13 == ((Tests.__sbyte16.TestData_LHS[i].x13 == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x13 < 0) ? -1 : 1));
                result &= t.x14 == ((Tests.__sbyte16.TestData_LHS[i].x14 == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x14 < 0) ? -1 : 1));
                result &= t.x15 == ((Tests.__sbyte16.TestData_LHS[i].x15 == 0) ? 0 : ((Tests.__sbyte16.TestData_LHS[i].x15 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte32.NUM_TESTS; i++)
            {
                sbyte32 t = maxmath.sign(Tests.__sbyte32.TestData_LHS[i]);

                result &= t.x0  == ((Tests.__sbyte32.TestData_LHS[i].x0  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x0  < 0) ? -1 : 1));
                result &= t.x1  == ((Tests.__sbyte32.TestData_LHS[i].x1  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x1  < 0) ? -1 : 1));
                result &= t.x2  == ((Tests.__sbyte32.TestData_LHS[i].x2  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x2  < 0) ? -1 : 1));
                result &= t.x3  == ((Tests.__sbyte32.TestData_LHS[i].x3  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x3  < 0) ? -1 : 1));
                result &= t.x4  == ((Tests.__sbyte32.TestData_LHS[i].x4  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x4  < 0) ? -1 : 1));
                result &= t.x5  == ((Tests.__sbyte32.TestData_LHS[i].x5  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x5  < 0) ? -1 : 1));
                result &= t.x6  == ((Tests.__sbyte32.TestData_LHS[i].x6  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x6  < 0) ? -1 : 1));
                result &= t.x7  == ((Tests.__sbyte32.TestData_LHS[i].x7  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x7  < 0) ? -1 : 1));
                result &= t.x8  == ((Tests.__sbyte32.TestData_LHS[i].x8  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x8  < 0) ? -1 : 1));
                result &= t.x9  == ((Tests.__sbyte32.TestData_LHS[i].x9  == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x9  < 0) ? -1 : 1));
                result &= t.x10 == ((Tests.__sbyte32.TestData_LHS[i].x10 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x10 < 0) ? -1 : 1));
                result &= t.x11 == ((Tests.__sbyte32.TestData_LHS[i].x11 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x11 < 0) ? -1 : 1));
                result &= t.x12 == ((Tests.__sbyte32.TestData_LHS[i].x12 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x12 < 0) ? -1 : 1));
                result &= t.x13 == ((Tests.__sbyte32.TestData_LHS[i].x13 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x13 < 0) ? -1 : 1));
                result &= t.x14 == ((Tests.__sbyte32.TestData_LHS[i].x14 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x14 < 0) ? -1 : 1));
                result &= t.x15 == ((Tests.__sbyte32.TestData_LHS[i].x15 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x15 < 0) ? -1 : 1));
                result &= t.x16 == ((Tests.__sbyte32.TestData_LHS[i].x16 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x16 < 0) ? -1 : 1));
                result &= t.x17 == ((Tests.__sbyte32.TestData_LHS[i].x17 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x17 < 0) ? -1 : 1));
                result &= t.x18 == ((Tests.__sbyte32.TestData_LHS[i].x18 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x18 < 0) ? -1 : 1));
                result &= t.x19 == ((Tests.__sbyte32.TestData_LHS[i].x19 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x19 < 0) ? -1 : 1));
                result &= t.x20 == ((Tests.__sbyte32.TestData_LHS[i].x20 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x20 < 0) ? -1 : 1));
                result &= t.x21 == ((Tests.__sbyte32.TestData_LHS[i].x21 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x21 < 0) ? -1 : 1));
                result &= t.x22 == ((Tests.__sbyte32.TestData_LHS[i].x22 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x22 < 0) ? -1 : 1));
                result &= t.x23 == ((Tests.__sbyte32.TestData_LHS[i].x23 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x23 < 0) ? -1 : 1));
                result &= t.x24 == ((Tests.__sbyte32.TestData_LHS[i].x24 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x24 < 0) ? -1 : 1));
                result &= t.x25 == ((Tests.__sbyte32.TestData_LHS[i].x25 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x25 < 0) ? -1 : 1));
                result &= t.x26 == ((Tests.__sbyte32.TestData_LHS[i].x26 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x26 < 0) ? -1 : 1));
                result &= t.x27 == ((Tests.__sbyte32.TestData_LHS[i].x27 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x27 < 0) ? -1 : 1));
                result &= t.x28 == ((Tests.__sbyte32.TestData_LHS[i].x28 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x28 < 0) ? -1 : 1));
                result &= t.x29 == ((Tests.__sbyte32.TestData_LHS[i].x29 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x29 < 0) ? -1 : 1));
                result &= t.x30 == ((Tests.__sbyte32.TestData_LHS[i].x30 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x30 < 0) ? -1 : 1));
                result &= t.x31 == ((Tests.__sbyte32.TestData_LHS[i].x31 == 0) ? 0 : ((Tests.__sbyte32.TestData_LHS[i].x31 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short2.NUM_TESTS; i++)
            {
                short2 t = maxmath.sign(Tests.__short2.TestData_LHS[i]);

                result &= t.x == ((Tests.__short2.TestData_LHS[i].x == 0) ? 0 : ((Tests.__short2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__short2.TestData_LHS[i].y == 0) ? 0 : ((Tests.__short2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short3.NUM_TESTS; i++)
            {
                short3 t = maxmath.sign(Tests.__short3.TestData_LHS[i]);

                result &= t.x == ((Tests.__short3.TestData_LHS[i].x == 0) ? 0 : ((Tests.__short3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__short3.TestData_LHS[i].y == 0) ? 0 : ((Tests.__short3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__short3.TestData_LHS[i].z == 0) ? 0 : ((Tests.__short3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short4.NUM_TESTS; i++)
            {
                short4 t = maxmath.sign(Tests.__short4.TestData_LHS[i]);

                result &= t.x == ((Tests.__short4.TestData_LHS[i].x == 0) ? 0 : ((Tests.__short4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__short4.TestData_LHS[i].y == 0) ? 0 : ((Tests.__short4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__short4.TestData_LHS[i].z == 0) ? 0 : ((Tests.__short4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.__short4.TestData_LHS[i].w == 0) ? 0 : ((Tests.__short4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short8.NUM_TESTS; i++)
            {
                short8 t = maxmath.sign(Tests.__short8.TestData_LHS[i]);

                result &= t.x0 == ((Tests.__short8.TestData_LHS[i].x0 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x0 < 0) ? -1 : 1));
                result &= t.x1 == ((Tests.__short8.TestData_LHS[i].x1 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x1 < 0) ? -1 : 1));
                result &= t.x2 == ((Tests.__short8.TestData_LHS[i].x2 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x2 < 0) ? -1 : 1));
                result &= t.x3 == ((Tests.__short8.TestData_LHS[i].x3 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x3 < 0) ? -1 : 1));
                result &= t.x4 == ((Tests.__short8.TestData_LHS[i].x4 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x4 < 0) ? -1 : 1));
                result &= t.x5 == ((Tests.__short8.TestData_LHS[i].x5 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x5 < 0) ? -1 : 1));
                result &= t.x6 == ((Tests.__short8.TestData_LHS[i].x6 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x6 < 0) ? -1 : 1));
                result &= t.x7 == ((Tests.__short8.TestData_LHS[i].x7 == 0) ? 0 : ((Tests.__short8.TestData_LHS[i].x7 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short16.NUM_TESTS; i++)
            {
                short16 t = maxmath.sign(Tests.__short16.TestData_LHS[i]);

                result &= t.x0  == ((Tests.__short16.TestData_LHS[i].x0  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x0  < 0) ? -1 : 1));
                result &= t.x1  == ((Tests.__short16.TestData_LHS[i].x1  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x1  < 0) ? -1 : 1));
                result &= t.x2  == ((Tests.__short16.TestData_LHS[i].x2  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x2  < 0) ? -1 : 1));
                result &= t.x3  == ((Tests.__short16.TestData_LHS[i].x3  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x3  < 0) ? -1 : 1));
                result &= t.x4  == ((Tests.__short16.TestData_LHS[i].x4  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x4  < 0) ? -1 : 1));
                result &= t.x5  == ((Tests.__short16.TestData_LHS[i].x5  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x5  < 0) ? -1 : 1));
                result &= t.x6  == ((Tests.__short16.TestData_LHS[i].x6  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x6  < 0) ? -1 : 1));
                result &= t.x7  == ((Tests.__short16.TestData_LHS[i].x7  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x7  < 0) ? -1 : 1));
                result &= t.x8  == ((Tests.__short16.TestData_LHS[i].x8  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x8  < 0) ? -1 : 1));
                result &= t.x9  == ((Tests.__short16.TestData_LHS[i].x9  == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x9  < 0) ? -1 : 1));
                result &= t.x10 == ((Tests.__short16.TestData_LHS[i].x10 == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x10 < 0) ? -1 : 1));
                result &= t.x11 == ((Tests.__short16.TestData_LHS[i].x11 == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x11 < 0) ? -1 : 1));
                result &= t.x12 == ((Tests.__short16.TestData_LHS[i].x12 == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x12 < 0) ? -1 : 1));
                result &= t.x13 == ((Tests.__short16.TestData_LHS[i].x13 == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x13 < 0) ? -1 : 1));
                result &= t.x14 == ((Tests.__short16.TestData_LHS[i].x14 == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x14 < 0) ? -1 : 1));
                result &= t.x15 == ((Tests.__short16.TestData_LHS[i].x15 == 0) ? 0 : ((Tests.__short16.TestData_LHS[i].x15 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int2.NUM_TESTS; i++)
            {
                int2 t = maxmath.sign(Tests.__int2.TestData_LHS[i]);

                result &= t.x == ((Tests.__int2.TestData_LHS[i].x == 0) ? 0 : ((Tests.__int2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__int2.TestData_LHS[i].y == 0) ? 0 : ((Tests.__int2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int3.NUM_TESTS; i++)
            {
                int3 t = maxmath.sign(Tests.__int3.TestData_LHS[i]);

                result &= t.x == ((Tests.__int3.TestData_LHS[i].x == 0) ? 0 : ((Tests.__int3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__int3.TestData_LHS[i].y == 0) ? 0 : ((Tests.__int3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__int3.TestData_LHS[i].z == 0) ? 0 : ((Tests.__int3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int4.NUM_TESTS; i++)
            {
                int4 t = maxmath.sign(Tests.__int4.TestData_LHS[i]);

                result &= t.x == ((Tests.__int4.TestData_LHS[i].x == 0) ? 0 : ((Tests.__int4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__int4.TestData_LHS[i].y == 0) ? 0 : ((Tests.__int4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__int4.TestData_LHS[i].z == 0) ? 0 : ((Tests.__int4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.__int4.TestData_LHS[i].w == 0) ? 0 : ((Tests.__int4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int8.NUM_TESTS; i++)
            {
                int8 t = maxmath.sign(Tests.__int8.TestData_LHS[i]);

                result &= t.x0 == ((Tests.__int8.TestData_LHS[i].x0 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x0 < 0) ? -1 : 1));
                result &= t.x1 == ((Tests.__int8.TestData_LHS[i].x1 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x1 < 0) ? -1 : 1));
                result &= t.x2 == ((Tests.__int8.TestData_LHS[i].x2 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x2 < 0) ? -1 : 1));
                result &= t.x3 == ((Tests.__int8.TestData_LHS[i].x3 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x3 < 0) ? -1 : 1));
                result &= t.x4 == ((Tests.__int8.TestData_LHS[i].x4 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x4 < 0) ? -1 : 1));
                result &= t.x5 == ((Tests.__int8.TestData_LHS[i].x5 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x5 < 0) ? -1 : 1));
                result &= t.x6 == ((Tests.__int8.TestData_LHS[i].x6 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x6 < 0) ? -1 : 1));
                result &= t.x7 == ((Tests.__int8.TestData_LHS[i].x7 == 0) ? 0 : ((Tests.__int8.TestData_LHS[i].x7 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long2.NUM_TESTS; i++)
            {
                long2 t = maxmath.sign(Tests.__long2.TestData_LHS[i]);

                result &= t.x == ((Tests.__long2.TestData_LHS[i].x == 0) ? 0 : ((Tests.__long2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__long2.TestData_LHS[i].y == 0) ? 0 : ((Tests.__long2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (long i = 0; i < Tests.__long3.NUM_TESTS; i++)
            {
                long3 t = maxmath.sign(Tests.__long3.TestData_LHS[i]);

                result &= t.x == ((Tests.__long3.TestData_LHS[i].x == 0) ? 0 : ((Tests.__long3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__long3.TestData_LHS[i].y == 0) ? 0 : ((Tests.__long3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__long3.TestData_LHS[i].z == 0) ? 0 : ((Tests.__long3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (long i = 0; i < Tests.__long4.NUM_TESTS; i++)
            {
                long4 t = maxmath.sign(Tests.__long4.TestData_LHS[i]);

                result &= t.x == ((Tests.__long4.TestData_LHS[i].x == 0) ? 0 : ((Tests.__long4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.__long4.TestData_LHS[i].y == 0) ? 0 : ((Tests.__long4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.__long4.TestData_LHS[i].z == 0) ? 0 : ((Tests.__long4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.__long4.TestData_LHS[i].w == 0) ? 0 : ((Tests.__long4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }
    }
}