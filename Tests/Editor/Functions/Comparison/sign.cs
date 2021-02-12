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

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                float8 t = maxmath.sign(Tests.Float8.TestData_LHS[i]);

                result &= t.x0 == math.sign(Tests.Float8.TestData_LHS[i].x0);
                result &= t.x1 == math.sign(Tests.Float8.TestData_LHS[i].x1);
                result &= t.x2 == math.sign(Tests.Float8.TestData_LHS[i].x2);
                result &= t.x3 == math.sign(Tests.Float8.TestData_LHS[i].x3);
                result &= t.x4 == math.sign(Tests.Float8.TestData_LHS[i].x4);
                result &= t.x5 == math.sign(Tests.Float8.TestData_LHS[i].x5);
                result &= t.x6 == math.sign(Tests.Float8.TestData_LHS[i].x6);
                result &= t.x7 == math.sign(Tests.Float8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte2.NUM_TESTS; i++)
            {
                sbyte2 t = maxmath.sign(Tests.SByte2.TestData_LHS[i]);

                result &= t.x == ((Tests.SByte2.TestData_LHS[i].x == 0) ? 0 : ((Tests.SByte2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.SByte2.TestData_LHS[i].y == 0) ? 0 : ((Tests.SByte2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte3.NUM_TESTS; i++)
            {
                sbyte3 t = maxmath.sign(Tests.SByte3.TestData_LHS[i]);

                result &= t.x == ((Tests.SByte3.TestData_LHS[i].x == 0) ? 0 : ((Tests.SByte3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.SByte3.TestData_LHS[i].y == 0) ? 0 : ((Tests.SByte3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.SByte3.TestData_LHS[i].z == 0) ? 0 : ((Tests.SByte3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;
            Random32 x = new Random32(47);

            for (int i = 0; i < Tests.SByte4.NUM_TESTS; i++)
            {
                sbyte4 t = maxmath.sign(Tests.SByte4.TestData_LHS[i]);

                result &= t.x == ((Tests.SByte4.TestData_LHS[i].x == 0) ? 0 : ((Tests.SByte4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.SByte4.TestData_LHS[i].y == 0) ? 0 : ((Tests.SByte4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.SByte4.TestData_LHS[i].z == 0) ? 0 : ((Tests.SByte4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.SByte4.TestData_LHS[i].w == 0) ? 0 : ((Tests.SByte4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte8.NUM_TESTS; i++)
            {
                sbyte8 t = maxmath.sign(Tests.SByte8.TestData_LHS[i]);

                result &= t.x0 == ((Tests.SByte8.TestData_LHS[i].x0 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x0 < 0) ? -1 : 1));
                result &= t.x1 == ((Tests.SByte8.TestData_LHS[i].x1 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x1 < 0) ? -1 : 1));
                result &= t.x2 == ((Tests.SByte8.TestData_LHS[i].x2 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x2 < 0) ? -1 : 1));
                result &= t.x3 == ((Tests.SByte8.TestData_LHS[i].x3 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x3 < 0) ? -1 : 1));
                result &= t.x4 == ((Tests.SByte8.TestData_LHS[i].x4 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x4 < 0) ? -1 : 1));
                result &= t.x5 == ((Tests.SByte8.TestData_LHS[i].x5 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x5 < 0) ? -1 : 1));
                result &= t.x6 == ((Tests.SByte8.TestData_LHS[i].x6 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x6 < 0) ? -1 : 1));
                result &= t.x7 == ((Tests.SByte8.TestData_LHS[i].x7 == 0) ? 0 : ((Tests.SByte8.TestData_LHS[i].x7 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte16.NUM_TESTS; i++)
            {
                sbyte16 t = maxmath.sign(Tests.SByte16.TestData_LHS[i]);

                result &= t.x0  == ((Tests.SByte16.TestData_LHS[i].x0  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x0  < 0) ? -1 : 1));
                result &= t.x1  == ((Tests.SByte16.TestData_LHS[i].x1  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x1  < 0) ? -1 : 1));
                result &= t.x2  == ((Tests.SByte16.TestData_LHS[i].x2  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x2  < 0) ? -1 : 1));
                result &= t.x3  == ((Tests.SByte16.TestData_LHS[i].x3  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x3  < 0) ? -1 : 1));
                result &= t.x4  == ((Tests.SByte16.TestData_LHS[i].x4  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x4  < 0) ? -1 : 1));
                result &= t.x5  == ((Tests.SByte16.TestData_LHS[i].x5  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x5  < 0) ? -1 : 1));
                result &= t.x6  == ((Tests.SByte16.TestData_LHS[i].x6  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x6  < 0) ? -1 : 1));
                result &= t.x7  == ((Tests.SByte16.TestData_LHS[i].x7  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x7  < 0) ? -1 : 1));
                result &= t.x8  == ((Tests.SByte16.TestData_LHS[i].x8  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x8  < 0) ? -1 : 1));
                result &= t.x9  == ((Tests.SByte16.TestData_LHS[i].x9  == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x9  < 0) ? -1 : 1));
                result &= t.x10 == ((Tests.SByte16.TestData_LHS[i].x10 == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x10 < 0) ? -1 : 1));
                result &= t.x11 == ((Tests.SByte16.TestData_LHS[i].x11 == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x11 < 0) ? -1 : 1));
                result &= t.x12 == ((Tests.SByte16.TestData_LHS[i].x12 == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x12 < 0) ? -1 : 1));
                result &= t.x13 == ((Tests.SByte16.TestData_LHS[i].x13 == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x13 < 0) ? -1 : 1));
                result &= t.x14 == ((Tests.SByte16.TestData_LHS[i].x14 == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x14 < 0) ? -1 : 1));
                result &= t.x15 == ((Tests.SByte16.TestData_LHS[i].x15 == 0) ? 0 : ((Tests.SByte16.TestData_LHS[i].x15 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                sbyte32 t = maxmath.sign(Tests.SByte32.TestData_LHS[i]);

                result &= t.x0  == ((Tests.SByte32.TestData_LHS[i].x0  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x0  < 0) ? -1 : 1));
                result &= t.x1  == ((Tests.SByte32.TestData_LHS[i].x1  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x1  < 0) ? -1 : 1));
                result &= t.x2  == ((Tests.SByte32.TestData_LHS[i].x2  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x2  < 0) ? -1 : 1));
                result &= t.x3  == ((Tests.SByte32.TestData_LHS[i].x3  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x3  < 0) ? -1 : 1));
                result &= t.x4  == ((Tests.SByte32.TestData_LHS[i].x4  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x4  < 0) ? -1 : 1));
                result &= t.x5  == ((Tests.SByte32.TestData_LHS[i].x5  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x5  < 0) ? -1 : 1));
                result &= t.x6  == ((Tests.SByte32.TestData_LHS[i].x6  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x6  < 0) ? -1 : 1));
                result &= t.x7  == ((Tests.SByte32.TestData_LHS[i].x7  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x7  < 0) ? -1 : 1));
                result &= t.x8  == ((Tests.SByte32.TestData_LHS[i].x8  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x8  < 0) ? -1 : 1));
                result &= t.x9  == ((Tests.SByte32.TestData_LHS[i].x9  == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x9  < 0) ? -1 : 1));
                result &= t.x10 == ((Tests.SByte32.TestData_LHS[i].x10 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x10 < 0) ? -1 : 1));
                result &= t.x11 == ((Tests.SByte32.TestData_LHS[i].x11 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x11 < 0) ? -1 : 1));
                result &= t.x12 == ((Tests.SByte32.TestData_LHS[i].x12 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x12 < 0) ? -1 : 1));
                result &= t.x13 == ((Tests.SByte32.TestData_LHS[i].x13 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x13 < 0) ? -1 : 1));
                result &= t.x14 == ((Tests.SByte32.TestData_LHS[i].x14 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x14 < 0) ? -1 : 1));
                result &= t.x15 == ((Tests.SByte32.TestData_LHS[i].x15 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x15 < 0) ? -1 : 1));
                result &= t.x16 == ((Tests.SByte32.TestData_LHS[i].x16 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x16 < 0) ? -1 : 1));
                result &= t.x17 == ((Tests.SByte32.TestData_LHS[i].x17 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x17 < 0) ? -1 : 1));
                result &= t.x18 == ((Tests.SByte32.TestData_LHS[i].x18 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x18 < 0) ? -1 : 1));
                result &= t.x19 == ((Tests.SByte32.TestData_LHS[i].x19 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x19 < 0) ? -1 : 1));
                result &= t.x20 == ((Tests.SByte32.TestData_LHS[i].x20 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x20 < 0) ? -1 : 1));
                result &= t.x21 == ((Tests.SByte32.TestData_LHS[i].x21 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x21 < 0) ? -1 : 1));
                result &= t.x22 == ((Tests.SByte32.TestData_LHS[i].x22 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x22 < 0) ? -1 : 1));
                result &= t.x23 == ((Tests.SByte32.TestData_LHS[i].x23 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x23 < 0) ? -1 : 1));
                result &= t.x24 == ((Tests.SByte32.TestData_LHS[i].x24 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x24 < 0) ? -1 : 1));
                result &= t.x25 == ((Tests.SByte32.TestData_LHS[i].x25 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x25 < 0) ? -1 : 1));
                result &= t.x26 == ((Tests.SByte32.TestData_LHS[i].x26 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x26 < 0) ? -1 : 1));
                result &= t.x27 == ((Tests.SByte32.TestData_LHS[i].x27 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x27 < 0) ? -1 : 1));
                result &= t.x28 == ((Tests.SByte32.TestData_LHS[i].x28 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x28 < 0) ? -1 : 1));
                result &= t.x29 == ((Tests.SByte32.TestData_LHS[i].x29 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x29 < 0) ? -1 : 1));
                result &= t.x30 == ((Tests.SByte32.TestData_LHS[i].x30 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x30 < 0) ? -1 : 1));
                result &= t.x31 == ((Tests.SByte32.TestData_LHS[i].x31 == 0) ? 0 : ((Tests.SByte32.TestData_LHS[i].x31 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                short2 t = maxmath.sign(Tests.Short2.TestData_LHS[i]);

                result &= t.x == ((Tests.Short2.TestData_LHS[i].x == 0) ? 0 : ((Tests.Short2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Short2.TestData_LHS[i].y == 0) ? 0 : ((Tests.Short2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                short3 t = maxmath.sign(Tests.Short3.TestData_LHS[i]);

                result &= t.x == ((Tests.Short3.TestData_LHS[i].x == 0) ? 0 : ((Tests.Short3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Short3.TestData_LHS[i].y == 0) ? 0 : ((Tests.Short3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.Short3.TestData_LHS[i].z == 0) ? 0 : ((Tests.Short3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                short4 t = maxmath.sign(Tests.Short4.TestData_LHS[i]);

                result &= t.x == ((Tests.Short4.TestData_LHS[i].x == 0) ? 0 : ((Tests.Short4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Short4.TestData_LHS[i].y == 0) ? 0 : ((Tests.Short4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.Short4.TestData_LHS[i].z == 0) ? 0 : ((Tests.Short4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.Short4.TestData_LHS[i].w == 0) ? 0 : ((Tests.Short4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                short8 t = maxmath.sign(Tests.Short8.TestData_LHS[i]);

                result &= t.x0 == ((Tests.Short8.TestData_LHS[i].x0 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x0 < 0) ? -1 : 1));
                result &= t.x1 == ((Tests.Short8.TestData_LHS[i].x1 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x1 < 0) ? -1 : 1));
                result &= t.x2 == ((Tests.Short8.TestData_LHS[i].x2 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x2 < 0) ? -1 : 1));
                result &= t.x3 == ((Tests.Short8.TestData_LHS[i].x3 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x3 < 0) ? -1 : 1));
                result &= t.x4 == ((Tests.Short8.TestData_LHS[i].x4 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x4 < 0) ? -1 : 1));
                result &= t.x5 == ((Tests.Short8.TestData_LHS[i].x5 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x5 < 0) ? -1 : 1));
                result &= t.x6 == ((Tests.Short8.TestData_LHS[i].x6 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x6 < 0) ? -1 : 1));
                result &= t.x7 == ((Tests.Short8.TestData_LHS[i].x7 == 0) ? 0 : ((Tests.Short8.TestData_LHS[i].x7 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                short16 t = maxmath.sign(Tests.Short16.TestData_LHS[i]);

                result &= t.x0  == ((Tests.Short16.TestData_LHS[i].x0  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x0  < 0) ? -1 : 1));
                result &= t.x1  == ((Tests.Short16.TestData_LHS[i].x1  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x1  < 0) ? -1 : 1));
                result &= t.x2  == ((Tests.Short16.TestData_LHS[i].x2  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x2  < 0) ? -1 : 1));
                result &= t.x3  == ((Tests.Short16.TestData_LHS[i].x3  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x3  < 0) ? -1 : 1));
                result &= t.x4  == ((Tests.Short16.TestData_LHS[i].x4  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x4  < 0) ? -1 : 1));
                result &= t.x5  == ((Tests.Short16.TestData_LHS[i].x5  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x5  < 0) ? -1 : 1));
                result &= t.x6  == ((Tests.Short16.TestData_LHS[i].x6  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x6  < 0) ? -1 : 1));
                result &= t.x7  == ((Tests.Short16.TestData_LHS[i].x7  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x7  < 0) ? -1 : 1));
                result &= t.x8  == ((Tests.Short16.TestData_LHS[i].x8  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x8  < 0) ? -1 : 1));
                result &= t.x9  == ((Tests.Short16.TestData_LHS[i].x9  == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x9  < 0) ? -1 : 1));
                result &= t.x10 == ((Tests.Short16.TestData_LHS[i].x10 == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x10 < 0) ? -1 : 1));
                result &= t.x11 == ((Tests.Short16.TestData_LHS[i].x11 == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x11 < 0) ? -1 : 1));
                result &= t.x12 == ((Tests.Short16.TestData_LHS[i].x12 == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x12 < 0) ? -1 : 1));
                result &= t.x13 == ((Tests.Short16.TestData_LHS[i].x13 == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x13 < 0) ? -1 : 1));
                result &= t.x14 == ((Tests.Short16.TestData_LHS[i].x14 == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x14 < 0) ? -1 : 1));
                result &= t.x15 == ((Tests.Short16.TestData_LHS[i].x15 == 0) ? 0 : ((Tests.Short16.TestData_LHS[i].x15 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int2.NUM_TESTS; i++)
            {
                int2 t = maxmath.sign(Tests.Int2.TestData_LHS[i]);

                result &= t.x == ((Tests.Int2.TestData_LHS[i].x == 0) ? 0 : ((Tests.Int2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Int2.TestData_LHS[i].y == 0) ? 0 : ((Tests.Int2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int3.NUM_TESTS; i++)
            {
                int3 t = maxmath.sign(Tests.Int3.TestData_LHS[i]);

                result &= t.x == ((Tests.Int3.TestData_LHS[i].x == 0) ? 0 : ((Tests.Int3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Int3.TestData_LHS[i].y == 0) ? 0 : ((Tests.Int3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.Int3.TestData_LHS[i].z == 0) ? 0 : ((Tests.Int3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int4.NUM_TESTS; i++)
            {
                int4 t = maxmath.sign(Tests.Int4.TestData_LHS[i]);

                result &= t.x == ((Tests.Int4.TestData_LHS[i].x == 0) ? 0 : ((Tests.Int4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Int4.TestData_LHS[i].y == 0) ? 0 : ((Tests.Int4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.Int4.TestData_LHS[i].z == 0) ? 0 : ((Tests.Int4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.Int4.TestData_LHS[i].w == 0) ? 0 : ((Tests.Int4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                int8 t = maxmath.sign(Tests.Int8.TestData_LHS[i]);

                result &= t.x0 == ((Tests.Int8.TestData_LHS[i].x0 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x0 < 0) ? -1 : 1));
                result &= t.x1 == ((Tests.Int8.TestData_LHS[i].x1 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x1 < 0) ? -1 : 1));
                result &= t.x2 == ((Tests.Int8.TestData_LHS[i].x2 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x2 < 0) ? -1 : 1));
                result &= t.x3 == ((Tests.Int8.TestData_LHS[i].x3 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x3 < 0) ? -1 : 1));
                result &= t.x4 == ((Tests.Int8.TestData_LHS[i].x4 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x4 < 0) ? -1 : 1));
                result &= t.x5 == ((Tests.Int8.TestData_LHS[i].x5 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x5 < 0) ? -1 : 1));
                result &= t.x6 == ((Tests.Int8.TestData_LHS[i].x6 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x6 < 0) ? -1 : 1));
                result &= t.x7 == ((Tests.Int8.TestData_LHS[i].x7 == 0) ? 0 : ((Tests.Int8.TestData_LHS[i].x7 < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                long2 t = maxmath.sign(Tests.Long2.TestData_LHS[i]);

                result &= t.x == ((Tests.Long2.TestData_LHS[i].x == 0) ? 0 : ((Tests.Long2.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Long2.TestData_LHS[i].y == 0) ? 0 : ((Tests.Long2.TestData_LHS[i].y < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (long i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                long3 t = maxmath.sign(Tests.Long3.TestData_LHS[i]);

                result &= t.x == ((Tests.Long3.TestData_LHS[i].x == 0) ? 0 : ((Tests.Long3.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Long3.TestData_LHS[i].y == 0) ? 0 : ((Tests.Long3.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.Long3.TestData_LHS[i].z == 0) ? 0 : ((Tests.Long3.TestData_LHS[i].z < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (long i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                long4 t = maxmath.sign(Tests.Long4.TestData_LHS[i]);

                result &= t.x == ((Tests.Long4.TestData_LHS[i].x == 0) ? 0 : ((Tests.Long4.TestData_LHS[i].x < 0) ? -1 : 1));
                result &= t.y == ((Tests.Long4.TestData_LHS[i].y == 0) ? 0 : ((Tests.Long4.TestData_LHS[i].y < 0) ? -1 : 1));
                result &= t.z == ((Tests.Long4.TestData_LHS[i].z == 0) ? 0 : ((Tests.Long4.TestData_LHS[i].z < 0) ? -1 : 1));
                result &= t.w == ((Tests.Long4.TestData_LHS[i].w == 0) ? 0 : ((Tests.Long4.TestData_LHS[i].w < 0) ? -1 : 1));
            }

            Assert.AreEqual(true, result);
        }
    }
}