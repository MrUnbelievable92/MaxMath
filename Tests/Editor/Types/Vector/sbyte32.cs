using NUnit.Framework;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class t_sbyte32
    {
        internal const int NUM_TESTS = 4;


        internal static sbyte32[] TestData_LHS => new sbyte32[]
        {
            new sbyte32{x0  = -83,
					    x1  = 55,
					    x2  = 99,
					    x3  = 76,
					    x4  = 65,
					    x5  = 1,
					    x6  = -11,
					    x7  = 35,
					    x8  = 75,
					    x9  = 99,
					    x10 = -11,
					    x11 = 54,
					    x12 = 68,
					    x13 = 32,
					    x14 = -54,
					    x15 = -77,
					    x16 = 35,
					    x17 = 75,
					    x18 = 99,
					    x19 = -11,
					    x20 = 66,
					    x21 = -99,
					    x22 = 39,
					    x23 = -50,
					    x24 = 121,
					    x25 = 3,
					    x26 = 32,
					    x27 = 21,
					    x28 = 13,
					    x29 = 47,
					    x30 = 32,
					    x31 = 64},

            new sbyte32{x0  = 22,
					    x1  = 12,
					    x2  = 32,
					    x3  = -11,
					    x4  = 99,
					    x5  = 80,
					    x6  = 54,
					    x7  = -39,
					    x8  = 76,
					    x9  = 65,
					    x10 = 1,
					    x11 = -11,
					    x12 = 35,
					    x13 = 75,
					    x14 = 99,
					    x15 = -11,
					    x16 = 21,
					    x17 = 9,
					    x18 = 47,
					    x19 = 32,
					    x20 = -82,
					    x21 = -39,
					    x22 = 45,
					    x23 = 90,
					    x24 = -22,
					    x25 = 3,
					    x26 = 32,
					    x27 = -98,
					    x28 = -6,
					    x29 = -34,
					    x30 = 3,
					    x31 = 47},

            new sbyte32{x0  = 87,
					    x1  = sbyte.MaxValue,
					    x2  = 17,
					    x3  = 21,
					    x4  = 0,
					    x5  = 47,
					    x6  = 32,
					    x7  = -56,
					    x8  = 87,
					    x9  = 21,
					    x10 = 47,
					    x11 = -70,
					    x12 = 54,
					    x13 = -22,
					    x14 = 12,
					    x15 = -88,
					    x16 = -39,
					    x17 = 45,
					    x18 = 90,
					    x19 = -22,
					    x20 = 3,
					    x21 = 87,
					    x22 = 99,
					    x23 = 17,
					    x24 = 21,
					    x25 = -99,
					    x26 = 39,
					    x27 = -50,
					    x28 = 121,
					    x29 = -121,
					    x30 = 3,
					    x31 = 32},

            new sbyte32{x0  = sbyte.MinValue,
					    x1  = -13,
					    x2  = 111,
					    x3  = 66,
					    x4  = -99,
					    x5  = 39,
					    x6  = -50,
					    x7  = 121,
					    x8  = 32,
					    x9  = -11,
					    x10 = -87,
					    x11 = 99,
					    x12 = 80,
					    x13 = -3,
					    x14 = 32,
					    x15 = -98,
					    x16 = 6,
					    x17 = 34,
					    x18 = 124,
					    x19 = 15,
					    x20 = 99,
					    x21 = -42,
					    x22 = 99,
					    x23 = -58,
					    x24 = 80,
					    x25 = 54,
					    x26 = 39,
					    x27 = 76,
					    x28 = 65,
					    x29 = 1,
					    x30 = 92,
                        x31 = 13}
        };

        internal static sbyte32[] TestData_RHS => new sbyte32[]
        {
            new sbyte32{x0  = 12,
					    x1  = 8,
					    x2  = 53,
					    x3  = 98,
					    x4  = 2,
					    x5  = -73,
					    x6  = 97,
					    x7  = 44,
					    x8  = 87,
					    x9  = -19,
					    x10 = -82,
					    x11 = 43,
					    x12 = -11,
					    x13 = 35,
					    x14 = 75,
					    x15 = 99,
					    x16 = 121,
					    x17 = 3,
					    x18 = 32,
					    x19 = 45,
					    x20 = 90,
					    x21 = -22,
					    x22 = 3,
					    x23 = 87,
					    x24 = 99,
					    x25 = 12,
					    x26 = 32,
					    x27 = -11,
					    x28 = 99,
					    x29 = 80,
					    x30 = -37,
                        x31 = -11},

            TestData_LHS[1],

            new sbyte32{x0  = 17,
					    x1  = 87,
					    x2  = -9,
					    x3  = -82,
					    x4  = -39,
					    x5  = 45,
					    x6  = 90,
					    x7  = 122,
					    x8  = -77,
					    x9  = 12,
					    x10 = 47,
					    x11 = -49,
					    x12 = 65,
					    x13 = 7,
					    x14 = 127,
					    x15 = 88,
					    x16 = -42,
					    x17 = 99,
					    x18 = -58,
					    x19 = 92,
					    x20 = 13,
					    x21 = 80,
					    x22 = 33,
					    x23 = 54,
					    x24 = 39,
					    x25 = 32,
					    x26 = -11,
					    x27 = 99,
					    x28 = 80,
					    x29 = 76,
					    x30 = 65,
					    x31 = 1},

            new sbyte32{x0  = 2,
					    x1  = 9,
					    x2  = -20,
					    x3  = 47,
					    x4  = -49,
					    x5  = 65,
					    x6  = -7,
					    x7  = 127,
					    x8  = -92,
					    x9  = -19,
					    x10 = -82,
					    x11 = 43,
					    x12 = 43,
					    x13 = 2,
					    x14 = -42,
					    x15 = 99,
					    x16 = -58,
					    x17 = 92,
					    x18 = 13,
					    x19 = -21,
					    x20 = 45,
					    x21 = -90,
					    x22 = 2,
					    x23 = 99,
					    x24 = 22,
					    x25 = 32,
					    x26 = -11,
					    x27 = 99,
					    x28 = 80,
					    x29 = 3,
					    x30 = 87,
                        x31 = 99}
        };


        [Test]
        public static void Constructor___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte___sbyte_SByte()
        {
            sbyte32 x = new sbyte32(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15, TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19 , TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23, TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31);

            Assert.AreEqual(x.x0  == TestData_LHS[0].x0 &
                   x.x1  == TestData_LHS[0].x1 &
                   x.x2  == TestData_LHS[0].x2 &
                   x.x3  == TestData_LHS[0].x3 &
                   x.x4  == TestData_LHS[0].x4 &
                   x.x5  == TestData_LHS[0].x5 &
                   x.x6  == TestData_LHS[0].x6 &
                   x.x7  == TestData_LHS[0].x7 &
                   x.x8  == TestData_LHS[0].x8 &
                   x.x9  == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15 &
                   x.x16 == TestData_LHS[0].x16 &
                   x.x17 == TestData_LHS[0].x17 &
                   x.x18 == TestData_LHS[0].x18 &
                   x.x19 == TestData_LHS[0].x19 &
                   x.x20 == TestData_LHS[0].x20 &
                   x.x21 == TestData_LHS[0].x21 &
                   x.x22 == TestData_LHS[0].x22 &
                   x.x23 == TestData_LHS[0].x23 &
                   x.x24 == TestData_LHS[0].x24 &
                   x.x25 == TestData_LHS[0].x25 &
                   x.x26 == TestData_LHS[0].x26 &
                   x.x27 == TestData_LHS[0].x27 &
                   x.x28 == TestData_LHS[0].x28 &
                   x.x29 == TestData_LHS[0].x29 &
                   x.x30 == TestData_LHS[0].x30 &
                   x.x31 == TestData_LHS[0].x31, true);
        }

        [Test]
        public static void Constructor_SByte()
        {
            sbyte32 x = new sbyte32(TestData_LHS[0].x0);

            Assert.AreEqual(x.x0  == TestData_LHS[0].x0 &
                   x.x1  == TestData_LHS[0].x0 &
                   x.x2  == TestData_LHS[0].x0 &
                   x.x3  == TestData_LHS[0].x0 &
                   x.x4  == TestData_LHS[0].x0 &
                   x.x5  == TestData_LHS[0].x0 &
                   x.x6  == TestData_LHS[0].x0 &
                   x.x7  == TestData_LHS[0].x0 &
                   x.x8  == TestData_LHS[0].x0 &
                   x.x9  == TestData_LHS[0].x0 &
                   x.x10 == TestData_LHS[0].x0 &
                   x.x11 == TestData_LHS[0].x0 &
                   x.x12 == TestData_LHS[0].x0 &
                   x.x13 == TestData_LHS[0].x0 &
                   x.x14 == TestData_LHS[0].x0 &
                   x.x15 == TestData_LHS[0].x0 &
                   x.x16 == TestData_LHS[0].x0 &
                   x.x17 == TestData_LHS[0].x0 &
                   x.x18 == TestData_LHS[0].x0 &
                   x.x19 == TestData_LHS[0].x0 &
                   x.x20 == TestData_LHS[0].x0 &
                   x.x21 == TestData_LHS[0].x0 &
                   x.x22 == TestData_LHS[0].x0 &
                   x.x23 == TestData_LHS[0].x0 &
                   x.x24 == TestData_LHS[0].x0 &
                   x.x25 == TestData_LHS[0].x0 &
                   x.x26 == TestData_LHS[0].x0 &
                   x.x27 == TestData_LHS[0].x0 &
                   x.x28 == TestData_LHS[0].x0 &
                   x.x29 == TestData_LHS[0].x0 &
                   x.x30 == TestData_LHS[0].x0 &
                   x.x31 == TestData_LHS[0].x0, true);
        }

        [Test]
        public static void Constructor___sbyte8___sbyte8___sbyte8_SByte8()
        {
            sbyte32 x = new sbyte32(new sbyte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15), new sbyte8(TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19, TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23), new sbyte8(TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31));

            Assert.AreEqual(x.x0  == TestData_LHS[0].x0 &
                   x.x1  == TestData_LHS[0].x1 &
                   x.x2  == TestData_LHS[0].x2 &
                   x.x3  == TestData_LHS[0].x3 &
                   x.x4  == TestData_LHS[0].x4 &
                   x.x5  == TestData_LHS[0].x5 &
                   x.x6  == TestData_LHS[0].x6 &
                   x.x7  == TestData_LHS[0].x7 &
                   x.x8  == TestData_LHS[0].x8 &
                   x.x9  == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15 &
                   x.x16 == TestData_LHS[0].x16 &
                   x.x17 == TestData_LHS[0].x17 &
                   x.x18 == TestData_LHS[0].x18 &
                   x.x19 == TestData_LHS[0].x19 &
                   x.x20 == TestData_LHS[0].x20 &
                   x.x21 == TestData_LHS[0].x21 &
                   x.x22 == TestData_LHS[0].x22 &
                   x.x23 == TestData_LHS[0].x23 &
                   x.x24 == TestData_LHS[0].x24 &
                   x.x25 == TestData_LHS[0].x25 &
                   x.x26 == TestData_LHS[0].x26 &
                   x.x27 == TestData_LHS[0].x27 &
                   x.x28 == TestData_LHS[0].x28 &
                   x.x29 == TestData_LHS[0].x29 &
                   x.x30 == TestData_LHS[0].x30 &
                   x.x31 == TestData_LHS[0].x31, true);
        }

        [Test]
        public static void Constructor___sbyte16___sbyte8_SByte8()
        {
            sbyte32 x = new sbyte32(new sbyte16(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15), new sbyte8(TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19, TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23), new sbyte8(TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31));

            Assert.AreEqual(x.x0  == TestData_LHS[0].x0 &
                   x.x1  == TestData_LHS[0].x1 &
                   x.x2  == TestData_LHS[0].x2 &
                   x.x3  == TestData_LHS[0].x3 &
                   x.x4  == TestData_LHS[0].x4 &
                   x.x5  == TestData_LHS[0].x5 &
                   x.x6  == TestData_LHS[0].x6 &
                   x.x7  == TestData_LHS[0].x7 &
                   x.x8  == TestData_LHS[0].x8 &
                   x.x9  == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15 &
                   x.x16 == TestData_LHS[0].x16 &
                   x.x17 == TestData_LHS[0].x17 &
                   x.x18 == TestData_LHS[0].x18 &
                   x.x19 == TestData_LHS[0].x19 &
                   x.x20 == TestData_LHS[0].x20 &
                   x.x21 == TestData_LHS[0].x21 &
                   x.x22 == TestData_LHS[0].x22 &
                   x.x23 == TestData_LHS[0].x23 &
                   x.x24 == TestData_LHS[0].x24 &
                   x.x25 == TestData_LHS[0].x25 &
                   x.x26 == TestData_LHS[0].x26 &
                   x.x27 == TestData_LHS[0].x27 &
                   x.x28 == TestData_LHS[0].x28 &
                   x.x29 == TestData_LHS[0].x29 &
                   x.x30 == TestData_LHS[0].x30 &
                   x.x31 == TestData_LHS[0].x31, true);
        }

        [Test]
        public static void Constructor___sbyte8___sbyte16_SByte8()
        {
            sbyte32 x = new sbyte32(new sbyte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte16(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15, TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19, TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23), new sbyte8(TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31));

            Assert.AreEqual(x.x0  == TestData_LHS[0].x0 &
                   x.x1  == TestData_LHS[0].x1 &
                   x.x2  == TestData_LHS[0].x2 &
                   x.x3  == TestData_LHS[0].x3 &
                   x.x4  == TestData_LHS[0].x4 &
                   x.x5  == TestData_LHS[0].x5 &
                   x.x6  == TestData_LHS[0].x6 &
                   x.x7  == TestData_LHS[0].x7 &
                   x.x8  == TestData_LHS[0].x8 &
                   x.x9  == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15 &
                   x.x16 == TestData_LHS[0].x16 &
                   x.x17 == TestData_LHS[0].x17 &
                   x.x18 == TestData_LHS[0].x18 &
                   x.x19 == TestData_LHS[0].x19 &
                   x.x20 == TestData_LHS[0].x20 &
                   x.x21 == TestData_LHS[0].x21 &
                   x.x22 == TestData_LHS[0].x22 &
                   x.x23 == TestData_LHS[0].x23 &
                   x.x24 == TestData_LHS[0].x24 &
                   x.x25 == TestData_LHS[0].x25 &
                   x.x26 == TestData_LHS[0].x26 &
                   x.x27 == TestData_LHS[0].x27 &
                   x.x28 == TestData_LHS[0].x28 &
                   x.x29 == TestData_LHS[0].x29 &
                   x.x30 == TestData_LHS[0].x30 &
                   x.x31 == TestData_LHS[0].x31, true);
        }

        [Test]
        public static void Constructor___sbyte8___sbyte8_SByte16()
        {
            sbyte32 x = new sbyte32(new sbyte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15), new sbyte16(TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19, TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23, TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31));

            Assert.AreEqual(x.x0  == TestData_LHS[0].x0 &
                   x.x1  == TestData_LHS[0].x1 &
                   x.x2  == TestData_LHS[0].x2 &
                   x.x3  == TestData_LHS[0].x3 &
                   x.x4  == TestData_LHS[0].x4 &
                   x.x5  == TestData_LHS[0].x5 &
                   x.x6  == TestData_LHS[0].x6 &
                   x.x7  == TestData_LHS[0].x7 &
                   x.x8  == TestData_LHS[0].x8 &
                   x.x9  == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15 &
                   x.x16 == TestData_LHS[0].x16 &
                   x.x17 == TestData_LHS[0].x17 &
                   x.x18 == TestData_LHS[0].x18 &
                   x.x19 == TestData_LHS[0].x19 &
                   x.x20 == TestData_LHS[0].x20 &
                   x.x21 == TestData_LHS[0].x21 &
                   x.x22 == TestData_LHS[0].x22 &
                   x.x23 == TestData_LHS[0].x23 &
                   x.x24 == TestData_LHS[0].x24 &
                   x.x25 == TestData_LHS[0].x25 &
                   x.x26 == TestData_LHS[0].x26 &
                   x.x27 == TestData_LHS[0].x27 &
                   x.x28 == TestData_LHS[0].x28 &
                   x.x29 == TestData_LHS[0].x29 &
                   x.x30 == TestData_LHS[0].x30 &
                   x.x31 == TestData_LHS[0].x31, true);
        }

        [Test]
        public static void Constructor___sbyte16_SByte16()
        {
            sbyte32 x = new sbyte32(new sbyte16(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15), new sbyte16(TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19, TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23, TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31));

            Assert.AreEqual(x.x0  == TestData_LHS[0].x0 &
                   x.x1  == TestData_LHS[0].x1 &
                   x.x2  == TestData_LHS[0].x2 &
                   x.x3  == TestData_LHS[0].x3 &
                   x.x4  == TestData_LHS[0].x4 &
                   x.x5  == TestData_LHS[0].x5 &
                   x.x6  == TestData_LHS[0].x6 &
                   x.x7  == TestData_LHS[0].x7 &
                   x.x8  == TestData_LHS[0].x8 &
                   x.x9  == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15 &
                   x.x16 == TestData_LHS[0].x16 &
                   x.x17 == TestData_LHS[0].x17 &
                   x.x18 == TestData_LHS[0].x18 &
                   x.x19 == TestData_LHS[0].x19 &
                   x.x20 == TestData_LHS[0].x20 &
                   x.x21 == TestData_LHS[0].x21 &
                   x.x22 == TestData_LHS[0].x22 &
                   x.x23 == TestData_LHS[0].x23 &
                   x.x24 == TestData_LHS[0].x24 &
                   x.x25 == TestData_LHS[0].x25 &
                   x.x26 == TestData_LHS[0].x26 &
                   x.x27 == TestData_LHS[0].x27 &
                   x.x28 == TestData_LHS[0].x28 &
                   x.x29 == TestData_LHS[0].x29 &
                   x.x30 == TestData_LHS[0].x30 &
                   x.x31 == TestData_LHS[0].x31, true);
        }


        [Test]
        public static void Indexer()
        {
            Assert.AreEqual(TestData_LHS[0][0]  == TestData_LHS[0].x0  &
                   TestData_LHS[0][1]  == TestData_LHS[0].x1  &
                   TestData_LHS[0][2]  == TestData_LHS[0].x2  &
                   TestData_LHS[0][3]  == TestData_LHS[0].x3  &
                   TestData_LHS[0][4]  == TestData_LHS[0].x4  &
                   TestData_LHS[0][5]  == TestData_LHS[0].x5  &
                   TestData_LHS[0][6]  == TestData_LHS[0].x6  &
                   TestData_LHS[0][7]  == TestData_LHS[0].x7  &
                   TestData_LHS[0][8]  == TestData_LHS[0].x8  &
                   TestData_LHS[0][9]  == TestData_LHS[0].x9  &
                   TestData_LHS[0][10] == TestData_LHS[0].x10 &
                   TestData_LHS[0][11] == TestData_LHS[0].x11 &
                   TestData_LHS[0][12] == TestData_LHS[0].x12 &
                   TestData_LHS[0][13] == TestData_LHS[0].x13 &
                   TestData_LHS[0][14] == TestData_LHS[0].x14 &
                   TestData_LHS[0][15] == TestData_LHS[0].x15 &
                   TestData_LHS[0][16] == TestData_LHS[0].x16 &
                   TestData_LHS[0][17] == TestData_LHS[0].x17 &
                   TestData_LHS[0][18] == TestData_LHS[0].x18 &
                   TestData_LHS[0][19] == TestData_LHS[0].x19 &
                   TestData_LHS[0][20] == TestData_LHS[0].x20 &
                   TestData_LHS[0][21] == TestData_LHS[0].x21 &
                   TestData_LHS[0][22] == TestData_LHS[0].x22 &
                   TestData_LHS[0][23] == TestData_LHS[0].x23 &
                   TestData_LHS[0][24] == TestData_LHS[0].x24 &
                   TestData_LHS[0][25] == TestData_LHS[0].x25 &
                   TestData_LHS[0][26] == TestData_LHS[0].x26 &
                   TestData_LHS[0][27] == TestData_LHS[0].x27 &
                   TestData_LHS[0][28] == TestData_LHS[0].x28 &
                   TestData_LHS[0][29] == TestData_LHS[0].x29 &
                   TestData_LHS[0][30] == TestData_LHS[0].x30 &
                   TestData_LHS[0][31] == TestData_LHS[0].x31, true);

            for (int i = 0; i < 32; i++)
            {
                sbyte32 x = TestData_LHS[0];

                x[i] = 0;
                Assert.AreEqual(x[i], 0);

                for (int j = 0; j < i; j++)
                {
                    Assert.AreEqual(x[j], TestData_LHS[0][j]);
                }

                for (int j = i + 1; j < 32; j++)
                {
                    Assert.AreEqual(x[j], TestData_LHS[0][j]);
                }
            }
        }


        [Test]
        public static void op_Addition()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  + TestData_RHS[i].x0)  &
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  + TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  + TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  + TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  + TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  + TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  + TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  + TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  + TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  + TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 + TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 + TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 + TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 + TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 + TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 + TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 + TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 + TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 + TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 + TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 + TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 + TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 + TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 + TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 + TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 + TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 + TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 + TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 + TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 + TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 + TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 + TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_Subtraction()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  - TestData_RHS[i].x0)  &
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  - TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  - TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  - TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  - TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  - TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  - TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  - TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  - TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  - TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 - TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 - TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 - TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 - TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 - TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 - TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 - TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 - TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 - TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 - TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 - TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 - TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 - TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 - TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 - TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 - TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 - TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 - TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 - TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 - TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 - TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 - TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void CONSTMultiply()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                Assert.AreEqual(TestData_LHS[0] * (sbyte)i, new sbyte32((sbyte)(TestData_LHS[0].x0  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x1  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x2  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x3  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x4  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x5  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x6  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x7  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x8  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x9  * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x10 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x11 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x12 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x13 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x14 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x15 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x16 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x17 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x18 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x19 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x20 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x21 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x22 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x23 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x24 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x25 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x26 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x27 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x28 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x29 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x30 * (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x31 * (sbyte)i)));
            }
        }

        [Test]
        public static void CONSTDivide()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                Assert.AreEqual(TestData_LHS[0] / (sbyte)i, new sbyte32((sbyte)(TestData_LHS[0].x0  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x1  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x2  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x3  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x4  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x5  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x6  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x7  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x8  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x9  / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x10 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x11 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x12 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x13 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x14 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x15 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x16 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x17 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x18 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x19 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x20 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x21 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x22 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x23 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x24 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x25 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x26 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x27 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x28 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x29 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x30 / (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x31 / (sbyte)i)));
            }
        }

        [Test]
        public static void CONSTRem()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                Assert.AreEqual(TestData_LHS[0] % (sbyte)i, new sbyte32((sbyte)(TestData_LHS[0].x0  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x1  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x2  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x3  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x4  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x5  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x6  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x7  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x8  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x9  % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x10 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x11 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x12 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x13 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x14 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x15 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x16 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x17 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x18 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x19 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x20 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x21 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x22 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x23 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x24 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x25 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x26 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x27 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x28 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x29 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x30 % (sbyte)i),
                                                                      (sbyte)(TestData_LHS[0].x31 % (sbyte)i)));
            }
        }

        [Test]
        public static void op_Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  * TestData_RHS[i].x0)  &
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  * TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  * TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  * TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  * TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  * TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  * TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  * TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  * TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  * TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 * TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 * TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 * TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 * TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 * TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 * TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 * TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 * TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 * TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 * TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 * TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 * TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 * TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 * TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 * TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 * TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 * TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 * TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 * TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 * TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 * TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 * TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_Division()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  / TestData_RHS[i].x0)  &
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  / TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  / TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  / TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  / TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  / TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  / TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  / TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  / TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  / TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 / TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 / TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 / TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 / TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 / TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 / TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 / TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 / TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 / TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 / TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 / TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 / TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 / TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 / TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 / TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 / TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 / TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 / TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 / TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 / TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 / TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 / TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_Modulus()
        {
            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] % TestData_RHS[i];

                Assert.AreEqual(x, new sbyte32((sbyte)(TestData_LHS[i].x0  % TestData_RHS[i].x0),
                                               (sbyte)(TestData_LHS[i].x1  % TestData_RHS[i].x1),
                                               (sbyte)(TestData_LHS[i].x2  % TestData_RHS[i].x2),
                                               (sbyte)(TestData_LHS[i].x3  % TestData_RHS[i].x3),
                                               (sbyte)(TestData_LHS[i].x4  % TestData_RHS[i].x4),
                                               (sbyte)(TestData_LHS[i].x5  % TestData_RHS[i].x5),
                                               (sbyte)(TestData_LHS[i].x6  % TestData_RHS[i].x6),
                                               (sbyte)(TestData_LHS[i].x7  % TestData_RHS[i].x7),
                                               (sbyte)(TestData_LHS[i].x8  % TestData_RHS[i].x8),
                                               (sbyte)(TestData_LHS[i].x9  % TestData_RHS[i].x9),
                                               (sbyte)(TestData_LHS[i].x10 % TestData_RHS[i].x10),
                                               (sbyte)(TestData_LHS[i].x11 % TestData_RHS[i].x11),
                                               (sbyte)(TestData_LHS[i].x12 % TestData_RHS[i].x12),
                                               (sbyte)(TestData_LHS[i].x13 % TestData_RHS[i].x13),
                                               (sbyte)(TestData_LHS[i].x14 % TestData_RHS[i].x14),
                                               (sbyte)(TestData_LHS[i].x15 % TestData_RHS[i].x15),
                                               (sbyte)(TestData_LHS[i].x16 % TestData_RHS[i].x16),
                                               (sbyte)(TestData_LHS[i].x17 % TestData_RHS[i].x17),
                                               (sbyte)(TestData_LHS[i].x18 % TestData_RHS[i].x18),
                                               (sbyte)(TestData_LHS[i].x19 % TestData_RHS[i].x19),
                                               (sbyte)(TestData_LHS[i].x20 % TestData_RHS[i].x20),
                                               (sbyte)(TestData_LHS[i].x21 % TestData_RHS[i].x21),
                                               (sbyte)(TestData_LHS[i].x22 % TestData_RHS[i].x22),
                                               (sbyte)(TestData_LHS[i].x23 % TestData_RHS[i].x23),
                                               (sbyte)(TestData_LHS[i].x24 % TestData_RHS[i].x24),
                                               (sbyte)(TestData_LHS[i].x25 % TestData_RHS[i].x25),
                                               (sbyte)(TestData_LHS[i].x26 % TestData_RHS[i].x26),
                                               (sbyte)(TestData_LHS[i].x27 % TestData_RHS[i].x27),
                                               (sbyte)(TestData_LHS[i].x28 % TestData_RHS[i].x28),
                                               (sbyte)(TestData_LHS[i].x29 % TestData_RHS[i].x29),
                                               (sbyte)(TestData_LHS[i].x30 % TestData_RHS[i].x30),
                                               (sbyte)(TestData_LHS[i].x31 % TestData_RHS[i].x31)));
            }
        }

        [Test]
        public static void Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = -TestData_LHS[i];

                result &= x.x0 ==  (sbyte)(-TestData_LHS[i].x0)  &
                          x.x1 ==  (sbyte)(-TestData_LHS[i].x1)  &
                          x.x2 ==  (sbyte)(-TestData_LHS[i].x2)  &
                          x.x3 ==  (sbyte)(-TestData_LHS[i].x3)  &
                          x.x4 ==  (sbyte)(-TestData_LHS[i].x4)  &
                          x.x5 ==  (sbyte)(-TestData_LHS[i].x5)  &
                          x.x6 ==  (sbyte)(-TestData_LHS[i].x6)  &
                          x.x7 ==  (sbyte)(-TestData_LHS[i].x7)  &
                          x.x8 ==  (sbyte)(-TestData_LHS[i].x8)  &
                          x.x9 ==  (sbyte)(-TestData_LHS[i].x9)  &
                          x.x10 == (sbyte)(-TestData_LHS[i].x10) &
                          x.x11 == (sbyte)(-TestData_LHS[i].x11) &
                          x.x12 == (sbyte)(-TestData_LHS[i].x12) &
                          x.x13 == (sbyte)(-TestData_LHS[i].x13) &
                          x.x14 == (sbyte)(-TestData_LHS[i].x14) &
                          x.x15 == (sbyte)(-TestData_LHS[i].x15) &
                          x.x16 == (sbyte)(-TestData_LHS[i].x16) &
                          x.x17 == (sbyte)(-TestData_LHS[i].x17) &
                          x.x18 == (sbyte)(-TestData_LHS[i].x18) &
                          x.x19 == (sbyte)(-TestData_LHS[i].x19) &
                          x.x20 == (sbyte)(-TestData_LHS[i].x20) &
                          x.x21 == (sbyte)(-TestData_LHS[i].x21) &
                          x.x22 == (sbyte)(-TestData_LHS[i].x22) &
                          x.x23 == (sbyte)(-TestData_LHS[i].x23) &
                          x.x24 == (sbyte)(-TestData_LHS[i].x24) &
                          x.x25 == (sbyte)(-TestData_LHS[i].x25) &
                          x.x26 == (sbyte)(-TestData_LHS[i].x26) &
                          x.x27 == (sbyte)(-TestData_LHS[i].x27) &
                          x.x28 == (sbyte)(-TestData_LHS[i].x28) &
                          x.x29 == (sbyte)(-TestData_LHS[i].x29) &
                          x.x30 == (sbyte)(-TestData_LHS[i].x30) &
                          x.x31 == (sbyte)(-TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void op_BitwiseAnd()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  & TestData_RHS[i].x0)  &
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  & TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  & TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  & TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  & TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  & TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  & TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  & TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  & TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  & TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 & TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 & TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 & TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 & TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 & TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 & TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 & TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 & TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 & TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 & TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 & TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 & TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 & TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 & TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 & TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 & TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 & TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 & TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 & TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 & TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 & TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 & TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_BitwiseOr()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  | TestData_RHS[i].x0)  &
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  | TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  | TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  | TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  | TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  | TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  | TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  | TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  | TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  | TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 | TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 | TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 | TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 | TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 | TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 | TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 | TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 | TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 | TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 | TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 | TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 | TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 | TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 | TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 | TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 | TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 | TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 | TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 | TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 | TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 | TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 | TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_ExclusiveOr()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  ^ TestData_RHS[i].x0)  &
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  ^ TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  ^ TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  ^ TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  ^ TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  ^ TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  ^ TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  ^ TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  ^ TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  ^ TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 ^ TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 ^ TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 ^ TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 ^ TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 ^ TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 ^ TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 ^ TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 ^ TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 ^ TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 ^ TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 ^ TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 ^ TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 ^ TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 ^ TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 ^ TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 ^ TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 ^ TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 ^ TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 ^ TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 ^ TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 ^ TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 ^ TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = ~TestData_LHS[i];

                result &= x.x0 ==  (sbyte)(~TestData_LHS[i].x0)  &
                          x.x1 ==  (sbyte)(~TestData_LHS[i].x1)  &
                          x.x2 ==  (sbyte)(~TestData_LHS[i].x2)  &
                          x.x3 ==  (sbyte)(~TestData_LHS[i].x3)  &
                          x.x4 ==  (sbyte)(~TestData_LHS[i].x4)  &
                          x.x5 ==  (sbyte)(~TestData_LHS[i].x5)  &
                          x.x6 ==  (sbyte)(~TestData_LHS[i].x6)  &
                          x.x7 ==  (sbyte)(~TestData_LHS[i].x7)  &
                          x.x8 ==  (sbyte)(~TestData_LHS[i].x8)  &
                          x.x9 ==  (sbyte)(~TestData_LHS[i].x9)  &
                          x.x10 == (sbyte)(~TestData_LHS[i].x10) &
                          x.x11 == (sbyte)(~TestData_LHS[i].x11) &
                          x.x12 == (sbyte)(~TestData_LHS[i].x12) &
                          x.x13 == (sbyte)(~TestData_LHS[i].x13) &
                          x.x14 == (sbyte)(~TestData_LHS[i].x14) &
                          x.x15 == (sbyte)(~TestData_LHS[i].x15) &
                          x.x16 == (sbyte)(~TestData_LHS[i].x16) &
                          x.x17 == (sbyte)(~TestData_LHS[i].x17) &
                          x.x18 == (sbyte)(~TestData_LHS[i].x18) &
                          x.x19 == (sbyte)(~TestData_LHS[i].x19) &
                          x.x20 == (sbyte)(~TestData_LHS[i].x20) &
                          x.x21 == (sbyte)(~TestData_LHS[i].x21) &
                          x.x22 == (sbyte)(~TestData_LHS[i].x22) &
                          x.x23 == (sbyte)(~TestData_LHS[i].x23) &
                          x.x24 == (sbyte)(~TestData_LHS[i].x24) &
                          x.x25 == (sbyte)(~TestData_LHS[i].x25) &
                          x.x26 == (sbyte)(~TestData_LHS[i].x26) &
                          x.x27 == (sbyte)(~TestData_LHS[i].x27) &
                          x.x28 == (sbyte)(~TestData_LHS[i].x28) &
                          x.x29 == (sbyte)(~TestData_LHS[i].x29) &
                          x.x30 == (sbyte)(~TestData_LHS[i].x30) &
                          x.x31 == (sbyte)(~TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sbyte32 x = TestData_LHS[i] << j;

                    result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  << j) &
                              x.x1 ==  (sbyte)(TestData_LHS[i].x1  << j) &
                              x.x2 ==  (sbyte)(TestData_LHS[i].x2  << j) &
                              x.x3 ==  (sbyte)(TestData_LHS[i].x3  << j) &
                              x.x4 ==  (sbyte)(TestData_LHS[i].x4  << j) &
                              x.x5 ==  (sbyte)(TestData_LHS[i].x5  << j) &
                              x.x6 ==  (sbyte)(TestData_LHS[i].x6  << j) &
                              x.x7 ==  (sbyte)(TestData_LHS[i].x7  << j) &
                              x.x8 ==  (sbyte)(TestData_LHS[i].x8  << j) &
                              x.x9 ==  (sbyte)(TestData_LHS[i].x9  << j) &
                              x.x10 == (sbyte)(TestData_LHS[i].x10 << j) &
                              x.x11 == (sbyte)(TestData_LHS[i].x11 << j) &
                              x.x12 == (sbyte)(TestData_LHS[i].x12 << j) &
                              x.x13 == (sbyte)(TestData_LHS[i].x13 << j) &
                              x.x14 == (sbyte)(TestData_LHS[i].x14 << j) &
                              x.x15 == (sbyte)(TestData_LHS[i].x15 << j) &
                              x.x16 == (sbyte)(TestData_LHS[i].x16 << j) &
                              x.x17 == (sbyte)(TestData_LHS[i].x17 << j) &
                              x.x18 == (sbyte)(TestData_LHS[i].x18 << j) &
                              x.x19 == (sbyte)(TestData_LHS[i].x19 << j) &
                              x.x20 == (sbyte)(TestData_LHS[i].x20 << j) &
                              x.x21 == (sbyte)(TestData_LHS[i].x21 << j) &
                              x.x22 == (sbyte)(TestData_LHS[i].x22 << j) &
                              x.x23 == (sbyte)(TestData_LHS[i].x23 << j) &
                              x.x24 == (sbyte)(TestData_LHS[i].x24 << j) &
                              x.x25 == (sbyte)(TestData_LHS[i].x25 << j) &
                              x.x26 == (sbyte)(TestData_LHS[i].x26 << j) &
                              x.x27 == (sbyte)(TestData_LHS[i].x27 << j) &
                              x.x28 == (sbyte)(TestData_LHS[i].x28 << j) &
                              x.x29 == (sbyte)(TestData_LHS[i].x29 << j) &
                              x.x30 == (sbyte)(TestData_LHS[i].x30 << j) &
                              x.x31 == (sbyte)(TestData_LHS[i].x31 << j);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sbyte32 x = TestData_LHS[i] >> j;

                    result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  >> j) &
                              x.x1 ==  (sbyte)(TestData_LHS[i].x1  >> j) &
                              x.x2 ==  (sbyte)(TestData_LHS[i].x2  >> j) &
                              x.x3 ==  (sbyte)(TestData_LHS[i].x3  >> j) &
                              x.x4 ==  (sbyte)(TestData_LHS[i].x4  >> j) &
                              x.x5 ==  (sbyte)(TestData_LHS[i].x5  >> j) &
                              x.x6 ==  (sbyte)(TestData_LHS[i].x6  >> j) &
                              x.x7 ==  (sbyte)(TestData_LHS[i].x7  >> j) &
                              x.x8 ==  (sbyte)(TestData_LHS[i].x8  >> j) &
                              x.x9 ==  (sbyte)(TestData_LHS[i].x9  >> j) &
                              x.x10 == (sbyte)(TestData_LHS[i].x10 >> j) &
                              x.x11 == (sbyte)(TestData_LHS[i].x11 >> j) &
                              x.x12 == (sbyte)(TestData_LHS[i].x12 >> j) &
                              x.x13 == (sbyte)(TestData_LHS[i].x13 >> j) &
                              x.x14 == (sbyte)(TestData_LHS[i].x14 >> j) &
                              x.x15 == (sbyte)(TestData_LHS[i].x15 >> j) &
                              x.x16 == (sbyte)(TestData_LHS[i].x16 >> j) &
                              x.x17 == (sbyte)(TestData_LHS[i].x17 >> j) &
                              x.x18 == (sbyte)(TestData_LHS[i].x18 >> j) &
                              x.x19 == (sbyte)(TestData_LHS[i].x19 >> j) &
                              x.x20 == (sbyte)(TestData_LHS[i].x20 >> j) &
                              x.x21 == (sbyte)(TestData_LHS[i].x21 >> j) &
                              x.x22 == (sbyte)(TestData_LHS[i].x22 >> j) &
                              x.x23 == (sbyte)(TestData_LHS[i].x23 >> j) &
                              x.x24 == (sbyte)(TestData_LHS[i].x24 >> j) &
                              x.x25 == (sbyte)(TestData_LHS[i].x25 >> j) &
                              x.x26 == (sbyte)(TestData_LHS[i].x26 >> j) &
                              x.x27 == (sbyte)(TestData_LHS[i].x27 >> j) &
                              x.x28 == (sbyte)(TestData_LHS[i].x28 >> j) &
                              x.x29 == (sbyte)(TestData_LHS[i].x29 >> j) &
                              x.x30 == (sbyte)(TestData_LHS[i].x30 >> j) &
                              x.x31 == (sbyte)(TestData_LHS[i].x31 >> j);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Equal()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = TestData_LHS[i] == TestData_RHS[i];

                result &= x.Equals(new bool32(TestData_LHS[i].x0  == TestData_RHS[i].x0,
                                              TestData_LHS[i].x1  == TestData_RHS[i].x1,
                                              TestData_LHS[i].x2  == TestData_RHS[i].x2,
                                              TestData_LHS[i].x3  == TestData_RHS[i].x3,
                                              TestData_LHS[i].x4  == TestData_RHS[i].x4,
                                              TestData_LHS[i].x5  == TestData_RHS[i].x5,
                                              TestData_LHS[i].x6  == TestData_RHS[i].x6,
                                              TestData_LHS[i].x7  == TestData_RHS[i].x7,
                                              TestData_LHS[i].x8  == TestData_RHS[i].x8,
                                              TestData_LHS[i].x9  == TestData_RHS[i].x9,
                                              TestData_LHS[i].x10 == TestData_RHS[i].x10,
                                              TestData_LHS[i].x11 == TestData_RHS[i].x11,
                                              TestData_LHS[i].x12 == TestData_RHS[i].x12,
                                              TestData_LHS[i].x13 == TestData_RHS[i].x13,
                                              TestData_LHS[i].x14 == TestData_RHS[i].x14,
                                              TestData_LHS[i].x15 == TestData_RHS[i].x15,
                                              TestData_LHS[i].x16 == TestData_RHS[i].x16,
                                              TestData_LHS[i].x17 == TestData_RHS[i].x17,
                                              TestData_LHS[i].x18 == TestData_RHS[i].x18,
                                              TestData_LHS[i].x19 == TestData_RHS[i].x19,
                                              TestData_LHS[i].x20 == TestData_RHS[i].x20,
                                              TestData_LHS[i].x21 == TestData_RHS[i].x21,
                                              TestData_LHS[i].x22 == TestData_RHS[i].x22,
                                              TestData_LHS[i].x23 == TestData_RHS[i].x23,
                                              TestData_LHS[i].x24 == TestData_RHS[i].x24,
                                              TestData_LHS[i].x25 == TestData_RHS[i].x25,
                                              TestData_LHS[i].x26 == TestData_RHS[i].x26,
                                              TestData_LHS[i].x27 == TestData_RHS[i].x27,
                                              TestData_LHS[i].x28 == TestData_RHS[i].x28,
                                              TestData_LHS[i].x29 == TestData_RHS[i].x29,
                                              TestData_LHS[i].x30 == TestData_RHS[i].x30,
                                              TestData_LHS[i].x31 == TestData_RHS[i].x31));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.Equals(new bool32(TestData_LHS[i].x0  < TestData_RHS[i].x0,
                                              TestData_LHS[i].x1  < TestData_RHS[i].x1,
                                              TestData_LHS[i].x2  < TestData_RHS[i].x2,
                                              TestData_LHS[i].x3  < TestData_RHS[i].x3,
                                              TestData_LHS[i].x4  < TestData_RHS[i].x4,
                                              TestData_LHS[i].x5  < TestData_RHS[i].x5,
                                              TestData_LHS[i].x6  < TestData_RHS[i].x6,
                                              TestData_LHS[i].x7  < TestData_RHS[i].x7,
                                              TestData_LHS[i].x8  < TestData_RHS[i].x8,
                                              TestData_LHS[i].x9  < TestData_RHS[i].x9,
                                              TestData_LHS[i].x10 < TestData_RHS[i].x10,
                                              TestData_LHS[i].x11 < TestData_RHS[i].x11,
                                              TestData_LHS[i].x12 < TestData_RHS[i].x12,
                                              TestData_LHS[i].x13 < TestData_RHS[i].x13,
                                              TestData_LHS[i].x14 < TestData_RHS[i].x14,
                                              TestData_LHS[i].x15 < TestData_RHS[i].x15,
                                              TestData_LHS[i].x16 < TestData_RHS[i].x16,
                                              TestData_LHS[i].x17 < TestData_RHS[i].x17,
                                              TestData_LHS[i].x18 < TestData_RHS[i].x18,
                                              TestData_LHS[i].x19 < TestData_RHS[i].x19,
                                              TestData_LHS[i].x20 < TestData_RHS[i].x20,
                                              TestData_LHS[i].x21 < TestData_RHS[i].x21,
                                              TestData_LHS[i].x22 < TestData_RHS[i].x22,
                                              TestData_LHS[i].x23 < TestData_RHS[i].x23,
                                              TestData_LHS[i].x24 < TestData_RHS[i].x24,
                                              TestData_LHS[i].x25 < TestData_RHS[i].x25,
                                              TestData_LHS[i].x26 < TestData_RHS[i].x26,
                                              TestData_LHS[i].x27 < TestData_RHS[i].x27,
                                              TestData_LHS[i].x28 < TestData_RHS[i].x28,
                                              TestData_LHS[i].x29 < TestData_RHS[i].x29,
                                              TestData_LHS[i].x30 < TestData_RHS[i].x30,
                                              TestData_LHS[i].x31 < TestData_RHS[i].x31));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = TestData_LHS[i] > TestData_RHS[i];

                result &= x.Equals(new bool32(TestData_LHS[i].x0  > TestData_RHS[i].x0,
                                              TestData_LHS[i].x1  > TestData_RHS[i].x1,
                                              TestData_LHS[i].x2  > TestData_RHS[i].x2,
                                              TestData_LHS[i].x3  > TestData_RHS[i].x3,
                                              TestData_LHS[i].x4  > TestData_RHS[i].x4,
                                              TestData_LHS[i].x5  > TestData_RHS[i].x5,
                                              TestData_LHS[i].x6  > TestData_RHS[i].x6,
                                              TestData_LHS[i].x7  > TestData_RHS[i].x7,
                                              TestData_LHS[i].x8  > TestData_RHS[i].x8,
                                              TestData_LHS[i].x9  > TestData_RHS[i].x9,
                                              TestData_LHS[i].x10 > TestData_RHS[i].x10,
                                              TestData_LHS[i].x11 > TestData_RHS[i].x11,
                                              TestData_LHS[i].x12 > TestData_RHS[i].x12,
                                              TestData_LHS[i].x13 > TestData_RHS[i].x13,
                                              TestData_LHS[i].x14 > TestData_RHS[i].x14,
                                              TestData_LHS[i].x15 > TestData_RHS[i].x15,
                                              TestData_LHS[i].x16 > TestData_RHS[i].x16,
                                              TestData_LHS[i].x17 > TestData_RHS[i].x17,
                                              TestData_LHS[i].x18 > TestData_RHS[i].x18,
                                              TestData_LHS[i].x19 > TestData_RHS[i].x19,
                                              TestData_LHS[i].x20 > TestData_RHS[i].x20,
                                              TestData_LHS[i].x21 > TestData_RHS[i].x21,
                                              TestData_LHS[i].x22 > TestData_RHS[i].x22,
                                              TestData_LHS[i].x23 > TestData_RHS[i].x23,
                                              TestData_LHS[i].x24 > TestData_RHS[i].x24,
                                              TestData_LHS[i].x25 > TestData_RHS[i].x25,
                                              TestData_LHS[i].x26 > TestData_RHS[i].x26,
                                              TestData_LHS[i].x27 > TestData_RHS[i].x27,
                                              TestData_LHS[i].x28 > TestData_RHS[i].x28,
                                              TestData_LHS[i].x29 > TestData_RHS[i].x29,
                                              TestData_LHS[i].x30 > TestData_RHS[i].x30,
                                              TestData_LHS[i].x31 > TestData_RHS[i].x31));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NotEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = TestData_LHS[i] != TestData_RHS[i];

                result &= x.Equals(new bool32(TestData_LHS[i].x0  != TestData_RHS[i].x0,
                                              TestData_LHS[i].x1  != TestData_RHS[i].x1,
                                              TestData_LHS[i].x2  != TestData_RHS[i].x2,
                                              TestData_LHS[i].x3  != TestData_RHS[i].x3,
                                              TestData_LHS[i].x4  != TestData_RHS[i].x4,
                                              TestData_LHS[i].x5  != TestData_RHS[i].x5,
                                              TestData_LHS[i].x6  != TestData_RHS[i].x6,
                                              TestData_LHS[i].x7  != TestData_RHS[i].x7,
                                              TestData_LHS[i].x8  != TestData_RHS[i].x8,
                                              TestData_LHS[i].x9  != TestData_RHS[i].x9,
                                              TestData_LHS[i].x10 != TestData_RHS[i].x10,
                                              TestData_LHS[i].x11 != TestData_RHS[i].x11,
                                              TestData_LHS[i].x12 != TestData_RHS[i].x12,
                                              TestData_LHS[i].x13 != TestData_RHS[i].x13,
                                              TestData_LHS[i].x14 != TestData_RHS[i].x14,
                                              TestData_LHS[i].x15 != TestData_RHS[i].x15,
                                              TestData_LHS[i].x16 != TestData_RHS[i].x16,
                                              TestData_LHS[i].x17 != TestData_RHS[i].x17,
                                              TestData_LHS[i].x18 != TestData_RHS[i].x18,
                                              TestData_LHS[i].x19 != TestData_RHS[i].x19,
                                              TestData_LHS[i].x20 != TestData_RHS[i].x20,
                                              TestData_LHS[i].x21 != TestData_RHS[i].x21,
                                              TestData_LHS[i].x22 != TestData_RHS[i].x22,
                                              TestData_LHS[i].x23 != TestData_RHS[i].x23,
                                              TestData_LHS[i].x24 != TestData_RHS[i].x24,
                                              TestData_LHS[i].x25 != TestData_RHS[i].x25,
                                              TestData_LHS[i].x26 != TestData_RHS[i].x26,
                                              TestData_LHS[i].x27 != TestData_RHS[i].x27,
                                              TestData_LHS[i].x28 != TestData_RHS[i].x28,
                                              TestData_LHS[i].x29 != TestData_RHS[i].x29,
                                              TestData_LHS[i].x30 != TestData_RHS[i].x30,
                                              TestData_LHS[i].x31 != TestData_RHS[i].x31));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = TestData_LHS[i] <= TestData_RHS[i];

                result &= x.Equals(new bool32(TestData_LHS[i].x0  <= TestData_RHS[i].x0,
                                              TestData_LHS[i].x1  <= TestData_RHS[i].x1,
                                              TestData_LHS[i].x2  <= TestData_RHS[i].x2,
                                              TestData_LHS[i].x3  <= TestData_RHS[i].x3,
                                              TestData_LHS[i].x4  <= TestData_RHS[i].x4,
                                              TestData_LHS[i].x5  <= TestData_RHS[i].x5,
                                              TestData_LHS[i].x6  <= TestData_RHS[i].x6,
                                              TestData_LHS[i].x7  <= TestData_RHS[i].x7,
                                              TestData_LHS[i].x8  <= TestData_RHS[i].x8,
                                              TestData_LHS[i].x9  <= TestData_RHS[i].x9,
                                              TestData_LHS[i].x10 <= TestData_RHS[i].x10,
                                              TestData_LHS[i].x11 <= TestData_RHS[i].x11,
                                              TestData_LHS[i].x12 <= TestData_RHS[i].x12,
                                              TestData_LHS[i].x13 <= TestData_RHS[i].x13,
                                              TestData_LHS[i].x14 <= TestData_RHS[i].x14,
                                              TestData_LHS[i].x15 <= TestData_RHS[i].x15,
                                              TestData_LHS[i].x16 <= TestData_RHS[i].x16,
                                              TestData_LHS[i].x17 <= TestData_RHS[i].x17,
                                              TestData_LHS[i].x18 <= TestData_RHS[i].x18,
                                              TestData_LHS[i].x19 <= TestData_RHS[i].x19,
                                              TestData_LHS[i].x20 <= TestData_RHS[i].x20,
                                              TestData_LHS[i].x21 <= TestData_RHS[i].x21,
                                              TestData_LHS[i].x22 <= TestData_RHS[i].x22,
                                              TestData_LHS[i].x23 <= TestData_RHS[i].x23,
                                              TestData_LHS[i].x24 <= TestData_RHS[i].x24,
                                              TestData_LHS[i].x25 <= TestData_RHS[i].x25,
                                              TestData_LHS[i].x26 <= TestData_RHS[i].x26,
                                              TestData_LHS[i].x27 <= TestData_RHS[i].x27,
                                              TestData_LHS[i].x28 <= TestData_RHS[i].x28,
                                              TestData_LHS[i].x29 <= TestData_RHS[i].x29,
                                              TestData_LHS[i].x30 <= TestData_RHS[i].x30,
                                              TestData_LHS[i].x31 <= TestData_RHS[i].x31));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = TestData_LHS[i] >= TestData_RHS[i];

                result &= x.Equals(new bool32(TestData_LHS[i].x0  >= TestData_RHS[i].x0,
                                              TestData_LHS[i].x1  >= TestData_RHS[i].x1,
                                              TestData_LHS[i].x2  >= TestData_RHS[i].x2,
                                              TestData_LHS[i].x3  >= TestData_RHS[i].x3,
                                              TestData_LHS[i].x4  >= TestData_RHS[i].x4,
                                              TestData_LHS[i].x5  >= TestData_RHS[i].x5,
                                              TestData_LHS[i].x6  >= TestData_RHS[i].x6,
                                              TestData_LHS[i].x7  >= TestData_RHS[i].x7,
                                              TestData_LHS[i].x8  >= TestData_RHS[i].x8,
                                              TestData_LHS[i].x9  >= TestData_RHS[i].x9,
                                              TestData_LHS[i].x10 >= TestData_RHS[i].x10,
                                              TestData_LHS[i].x11 >= TestData_RHS[i].x11,
                                              TestData_LHS[i].x12 >= TestData_RHS[i].x12,
                                              TestData_LHS[i].x13 >= TestData_RHS[i].x13,
                                              TestData_LHS[i].x14 >= TestData_RHS[i].x14,
                                              TestData_LHS[i].x15 >= TestData_RHS[i].x15,
                                              TestData_LHS[i].x16 >= TestData_RHS[i].x16,
                                              TestData_LHS[i].x17 >= TestData_RHS[i].x17,
                                              TestData_LHS[i].x18 >= TestData_RHS[i].x18,
                                              TestData_LHS[i].x19 >= TestData_RHS[i].x19,
                                              TestData_LHS[i].x20 >= TestData_RHS[i].x20,
                                              TestData_LHS[i].x21 >= TestData_RHS[i].x21,
                                              TestData_LHS[i].x22 >= TestData_RHS[i].x22,
                                              TestData_LHS[i].x23 >= TestData_RHS[i].x23,
                                              TestData_LHS[i].x24 >= TestData_RHS[i].x24,
                                              TestData_LHS[i].x25 >= TestData_RHS[i].x25,
                                              TestData_LHS[i].x26 >= TestData_RHS[i].x26,
                                              TestData_LHS[i].x27 >= TestData_RHS[i].x27,
                                              TestData_LHS[i].x28 >= TestData_RHS[i].x28,
                                              TestData_LHS[i].x29 >= TestData_RHS[i].x29,
                                              TestData_LHS[i].x30 >= TestData_RHS[i].x30,
                                              TestData_LHS[i].x31 >= TestData_RHS[i].x31));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void AllEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool x = TestData_LHS[i].Equals(TestData_RHS[i]);

                result &= x == (TestData_LHS[i].x0  == TestData_RHS[i].x0  &
                                TestData_LHS[i].x1  == TestData_RHS[i].x1  &
                                TestData_LHS[i].x2  == TestData_RHS[i].x2  &
                                TestData_LHS[i].x3  == TestData_RHS[i].x3  &
                                TestData_LHS[i].x4  == TestData_RHS[i].x4  &
                                TestData_LHS[i].x5  == TestData_RHS[i].x5  &
                                TestData_LHS[i].x6  == TestData_RHS[i].x6  &
                                TestData_LHS[i].x7  == TestData_RHS[i].x7  &
                                TestData_LHS[i].x8  == TestData_RHS[i].x8  &
                                TestData_LHS[i].x9  == TestData_RHS[i].x9  &
                                TestData_LHS[i].x10 == TestData_RHS[i].x10 &
                                TestData_LHS[i].x11 == TestData_RHS[i].x11 &
                                TestData_LHS[i].x12 == TestData_RHS[i].x12 &
                                TestData_LHS[i].x13 == TestData_RHS[i].x13 &
                                TestData_LHS[i].x14 == TestData_RHS[i].x14 &
                                TestData_LHS[i].x15 == TestData_RHS[i].x15 &
                                TestData_LHS[i].x16 == TestData_RHS[i].x16 &
                                TestData_LHS[i].x17 == TestData_RHS[i].x17 &
                                TestData_LHS[i].x18 == TestData_RHS[i].x18 &
                                TestData_LHS[i].x19 == TestData_RHS[i].x19 &
                                TestData_LHS[i].x20 == TestData_RHS[i].x20 &
                                TestData_LHS[i].x21 == TestData_RHS[i].x21 &
                                TestData_LHS[i].x22 == TestData_RHS[i].x22 &
                                TestData_LHS[i].x23 == TestData_RHS[i].x23 &
                                TestData_LHS[i].x24 == TestData_RHS[i].x24 &
                                TestData_LHS[i].x25 == TestData_RHS[i].x25 &
                                TestData_LHS[i].x26 == TestData_RHS[i].x26 &
                                TestData_LHS[i].x27 == TestData_RHS[i].x27 &
                                TestData_LHS[i].x28 == TestData_RHS[i].x28 &
                                TestData_LHS[i].x29 == TestData_RHS[i].x29 &
                                TestData_LHS[i].x30 == TestData_RHS[i].x30 &
                                TestData_LHS[i].x31 == TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ShuffleGetter()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 v16_0 = TestData_LHS[i].v16_0;
                result &= v16_0.x0  == TestData_LHS[i].x0  &
                          v16_0.x1  == TestData_LHS[i].x1  &
                          v16_0.x2  == TestData_LHS[i].x2  &
                          v16_0.x3  == TestData_LHS[i].x3  &
                          v16_0.x4  == TestData_LHS[i].x4  &
                          v16_0.x5  == TestData_LHS[i].x5  &
                          v16_0.x6  == TestData_LHS[i].x6  &
                          v16_0.x7  == TestData_LHS[i].x7  &
                          v16_0.x8  == TestData_LHS[i].x8  &
                          v16_0.x9  == TestData_LHS[i].x9  &
                          v16_0.x10 == TestData_LHS[i].x10 &
                          v16_0.x11 == TestData_LHS[i].x11 &
                          v16_0.x12 == TestData_LHS[i].x12 &
                          v16_0.x13 == TestData_LHS[i].x13 &
                          v16_0.x14 == TestData_LHS[i].x14 &
                          v16_0.x15 == TestData_LHS[i].x15;

                sbyte16 v16_1 = TestData_LHS[i].v16_1;
                result &= v16_1.x0 == TestData_LHS[i].x1 &
                          v16_1.x1 == TestData_LHS[i].x2 &
                          v16_1.x2 == TestData_LHS[i].x3 &
                          v16_1.x3 == TestData_LHS[i].x4 &
                          v16_1.x4 == TestData_LHS[i].x5 &
                          v16_1.x5 == TestData_LHS[i].x6 &
                          v16_1.x6 == TestData_LHS[i].x7 &
                          v16_1.x7 == TestData_LHS[i].x8 &
                          v16_1.x8 == TestData_LHS[i].x9 &
                          v16_1.x9 == TestData_LHS[i].x10 &
                          v16_1.x10 == TestData_LHS[i].x11 &
                          v16_1.x11 == TestData_LHS[i].x12 &
                          v16_1.x12 == TestData_LHS[i].x13 &
                          v16_1.x13 == TestData_LHS[i].x14 &
                          v16_1.x14 == TestData_LHS[i].x15 &
                          v16_1.x15 == TestData_LHS[i].x16;

                sbyte16 v16_2 = TestData_LHS[i].v16_2;
                result &= v16_2.x0 == TestData_LHS[i].x2 &
                          v16_2.x1 == TestData_LHS[i].x3 &
                          v16_2.x2 == TestData_LHS[i].x4 &
                          v16_2.x3 == TestData_LHS[i].x5 &
                          v16_2.x4 == TestData_LHS[i].x6 &
                          v16_2.x5 == TestData_LHS[i].x7 &
                          v16_2.x6 == TestData_LHS[i].x8 &
                          v16_2.x7 == TestData_LHS[i].x9 &
                          v16_2.x8 == TestData_LHS[i].x10 &
                          v16_2.x9 == TestData_LHS[i].x11 &
                          v16_2.x10 == TestData_LHS[i].x12 &
                          v16_2.x11 == TestData_LHS[i].x13 &
                          v16_2.x12 == TestData_LHS[i].x14 &
                          v16_2.x13 == TestData_LHS[i].x15 &
                          v16_2.x14 == TestData_LHS[i].x16 &
                          v16_2.x15 == TestData_LHS[i].x17;

                sbyte16 v16_3 = TestData_LHS[i].v16_3;
                result &= v16_3.x0 == TestData_LHS[i].x3 &
                          v16_3.x1 == TestData_LHS[i].x4 &
                          v16_3.x2 == TestData_LHS[i].x5 &
                          v16_3.x3 == TestData_LHS[i].x6 &
                          v16_3.x4 == TestData_LHS[i].x7 &
                          v16_3.x5 == TestData_LHS[i].x8 &
                          v16_3.x6 == TestData_LHS[i].x9 &
                          v16_3.x7 == TestData_LHS[i].x10 &
                          v16_3.x8 == TestData_LHS[i].x11 &
                          v16_3.x9 == TestData_LHS[i].x12 &
                          v16_3.x10 == TestData_LHS[i].x13 &
                          v16_3.x11 == TestData_LHS[i].x14 &
                          v16_3.x12 == TestData_LHS[i].x15 &
                          v16_3.x13 == TestData_LHS[i].x16 &
                          v16_3.x14 == TestData_LHS[i].x17 &
                          v16_3.x15 == TestData_LHS[i].x18;

                sbyte16 v16_4 = TestData_LHS[i].v16_4;
                result &= v16_4.x0 == TestData_LHS[i].x4 &
                          v16_4.x1 == TestData_LHS[i].x5 &
                          v16_4.x2 == TestData_LHS[i].x6 &
                          v16_4.x3 == TestData_LHS[i].x7 &
                          v16_4.x4 == TestData_LHS[i].x8 &
                          v16_4.x5 == TestData_LHS[i].x9 &
                          v16_4.x6 == TestData_LHS[i].x10 &
                          v16_4.x7 == TestData_LHS[i].x11 &
                          v16_4.x8 == TestData_LHS[i].x12 &
                          v16_4.x9 == TestData_LHS[i].x13 &
                          v16_4.x10 == TestData_LHS[i].x14 &
                          v16_4.x11 == TestData_LHS[i].x15 &
                          v16_4.x12 == TestData_LHS[i].x16 &
                          v16_4.x13 == TestData_LHS[i].x17 &
                          v16_4.x14 == TestData_LHS[i].x18 &
                          v16_4.x15 == TestData_LHS[i].x19;

                sbyte16 v16_5 = TestData_LHS[i].v16_5;
                result &= v16_5.x0 == TestData_LHS[i].x5 &
                          v16_5.x1 == TestData_LHS[i].x6 &
                          v16_5.x2 == TestData_LHS[i].x7 &
                          v16_5.x3 == TestData_LHS[i].x8 &
                          v16_5.x4 == TestData_LHS[i].x9 &
                          v16_5.x5 == TestData_LHS[i].x10 &
                          v16_5.x6 == TestData_LHS[i].x11 &
                          v16_5.x7 == TestData_LHS[i].x12 &
                          v16_5.x8 == TestData_LHS[i].x13 &
                          v16_5.x9 == TestData_LHS[i].x14 &
                          v16_5.x10 == TestData_LHS[i].x15 &
                          v16_5.x11 == TestData_LHS[i].x16 &
                          v16_5.x12 == TestData_LHS[i].x17 &
                          v16_5.x13 == TestData_LHS[i].x18 &
                          v16_5.x14 == TestData_LHS[i].x19 &
                          v16_5.x15 == TestData_LHS[i].x20;

                sbyte16 v16_6 = TestData_LHS[i].v16_6;
                result &= v16_6.x0 == TestData_LHS[i].x6 &
                          v16_6.x1 == TestData_LHS[i].x7 &
                          v16_6.x2 == TestData_LHS[i].x8 &
                          v16_6.x3 == TestData_LHS[i].x9 &
                          v16_6.x4 == TestData_LHS[i].x10 &
                          v16_6.x5 == TestData_LHS[i].x11 &
                          v16_6.x6 == TestData_LHS[i].x12 &
                          v16_6.x7 == TestData_LHS[i].x13 &
                          v16_6.x8 == TestData_LHS[i].x14 &
                          v16_6.x9 == TestData_LHS[i].x15 &
                          v16_6.x10 == TestData_LHS[i].x16 &
                          v16_6.x11 == TestData_LHS[i].x17 &
                          v16_6.x12 == TestData_LHS[i].x18 &
                          v16_6.x13 == TestData_LHS[i].x19 &
                          v16_6.x14 == TestData_LHS[i].x20 &
                          v16_6.x15 == TestData_LHS[i].x21;

                sbyte16 v16_7 = TestData_LHS[i].v16_7;
                result &= v16_7.x0 == TestData_LHS[i].x7 &
                          v16_7.x1 == TestData_LHS[i].x8 &
                          v16_7.x2 == TestData_LHS[i].x9 &
                          v16_7.x3 == TestData_LHS[i].x10 &
                          v16_7.x4 == TestData_LHS[i].x11 &
                          v16_7.x5 == TestData_LHS[i].x12 &
                          v16_7.x6 == TestData_LHS[i].x13 &
                          v16_7.x7 == TestData_LHS[i].x14 &
                          v16_7.x8 == TestData_LHS[i].x15 &
                          v16_7.x9 == TestData_LHS[i].x16 &
                          v16_7.x10 == TestData_LHS[i].x17 &
                          v16_7.x11 == TestData_LHS[i].x18 &
                          v16_7.x12 == TestData_LHS[i].x19 &
                          v16_7.x13 == TestData_LHS[i].x20 &
                          v16_7.x14 == TestData_LHS[i].x21 &
                          v16_7.x15 == TestData_LHS[i].x22;

                sbyte16 v16_8 = TestData_LHS[i].v16_8;
                result &= v16_8.x0 == TestData_LHS[i].x8 &
                          v16_8.x1 == TestData_LHS[i].x9 &
                          v16_8.x2 == TestData_LHS[i].x10 &
                          v16_8.x3 == TestData_LHS[i].x11 &
                          v16_8.x4 == TestData_LHS[i].x12 &
                          v16_8.x5 == TestData_LHS[i].x13 &
                          v16_8.x6 == TestData_LHS[i].x14 &
                          v16_8.x7 == TestData_LHS[i].x15 &
                          v16_8.x8 == TestData_LHS[i].x16 &
                          v16_8.x9 == TestData_LHS[i].x17 &
                          v16_8.x10 == TestData_LHS[i].x18 &
                          v16_8.x11 == TestData_LHS[i].x19 &
                          v16_8.x12 == TestData_LHS[i].x20 &
                          v16_8.x13 == TestData_LHS[i].x21 &
                          v16_8.x14 == TestData_LHS[i].x22 &
                          v16_8.x15 == TestData_LHS[i].x23;

                sbyte16 v16_9 = TestData_LHS[i].v16_9;
                result &= v16_9.x0 == TestData_LHS[i].x9 &
                          v16_9.x1 == TestData_LHS[i].x10 &
                          v16_9.x2 == TestData_LHS[i].x11 &
                          v16_9.x3 == TestData_LHS[i].x12 &
                          v16_9.x4 == TestData_LHS[i].x13 &
                          v16_9.x5 == TestData_LHS[i].x14 &
                          v16_9.x6 == TestData_LHS[i].x15 &
                          v16_9.x7 == TestData_LHS[i].x16 &
                          v16_9.x8 == TestData_LHS[i].x17 &
                          v16_9.x9 == TestData_LHS[i].x18 &
                          v16_9.x10 == TestData_LHS[i].x19 &
                          v16_9.x11 == TestData_LHS[i].x20 &
                          v16_9.x12 == TestData_LHS[i].x21 &
                          v16_9.x13 == TestData_LHS[i].x22 &
                          v16_9.x14 == TestData_LHS[i].x23 &
                          v16_9.x15 == TestData_LHS[i].x24;

                sbyte16 v16_10 = TestData_LHS[i].v16_10;
                result &= v16_10.x0 == TestData_LHS[i].x10 &
                          v16_10.x1 == TestData_LHS[i].x11 &
                          v16_10.x2 == TestData_LHS[i].x12 &
                          v16_10.x3 == TestData_LHS[i].x13 &
                          v16_10.x4 == TestData_LHS[i].x14 &
                          v16_10.x5 == TestData_LHS[i].x15 &
                          v16_10.x6 == TestData_LHS[i].x16 &
                          v16_10.x7 == TestData_LHS[i].x17 &
                          v16_10.x8 == TestData_LHS[i].x18 &
                          v16_10.x9 == TestData_LHS[i].x19 &
                          v16_10.x10 == TestData_LHS[i].x20 &
                          v16_10.x11 == TestData_LHS[i].x21 &
                          v16_10.x12 == TestData_LHS[i].x22 &
                          v16_10.x13 == TestData_LHS[i].x23 &
                          v16_10.x14 == TestData_LHS[i].x24 &
                          v16_10.x15 == TestData_LHS[i].x25;

                sbyte16 v16_11 = TestData_LHS[i].v16_11;
                result &= v16_11.x0 == TestData_LHS[i].x11 &
                          v16_11.x1 == TestData_LHS[i].x12 &
                          v16_11.x2 == TestData_LHS[i].x13 &
                          v16_11.x3 == TestData_LHS[i].x14 &
                          v16_11.x4 == TestData_LHS[i].x15 &
                          v16_11.x5 == TestData_LHS[i].x16 &
                          v16_11.x6 == TestData_LHS[i].x17 &
                          v16_11.x7 == TestData_LHS[i].x18 &
                          v16_11.x8 == TestData_LHS[i].x19 &
                          v16_11.x9 == TestData_LHS[i].x20 &
                          v16_11.x10 == TestData_LHS[i].x21 &
                          v16_11.x11 == TestData_LHS[i].x22 &
                          v16_11.x12 == TestData_LHS[i].x23 &
                          v16_11.x13 == TestData_LHS[i].x24 &
                          v16_11.x14 == TestData_LHS[i].x25 &
                          v16_11.x15 == TestData_LHS[i].x26;

                sbyte16 v16_12 = TestData_LHS[i].v16_12;
                result &= v16_12.x0 == TestData_LHS[i].x12 &
                          v16_12.x1 == TestData_LHS[i].x13 &
                          v16_12.x2 == TestData_LHS[i].x14 &
                          v16_12.x3 == TestData_LHS[i].x15 &
                          v16_12.x4 == TestData_LHS[i].x16 &
                          v16_12.x5 == TestData_LHS[i].x17 &
                          v16_12.x6 == TestData_LHS[i].x18 &
                          v16_12.x7 == TestData_LHS[i].x19 &
                          v16_12.x8 == TestData_LHS[i].x20 &
                          v16_12.x9 == TestData_LHS[i].x21 &
                          v16_12.x10 == TestData_LHS[i].x22 &
                          v16_12.x11 == TestData_LHS[i].x23 &
                          v16_12.x12 == TestData_LHS[i].x24 &
                          v16_12.x13 == TestData_LHS[i].x25 &
                          v16_12.x14 == TestData_LHS[i].x26 &
                          v16_12.x15 == TestData_LHS[i].x27;

                sbyte16 v16_13 = TestData_LHS[i].v16_13;
                result &= v16_13.x0 == TestData_LHS[i].x13 &
                          v16_13.x1 == TestData_LHS[i].x14 &
                          v16_13.x2 == TestData_LHS[i].x15 &
                          v16_13.x3 == TestData_LHS[i].x16 &
                          v16_13.x4 == TestData_LHS[i].x17 &
                          v16_13.x5 == TestData_LHS[i].x18 &
                          v16_13.x6 == TestData_LHS[i].x19 &
                          v16_13.x7 == TestData_LHS[i].x20 &
                          v16_13.x8 == TestData_LHS[i].x21 &
                          v16_13.x9 == TestData_LHS[i].x22 &
                          v16_13.x10 == TestData_LHS[i].x23 &
                          v16_13.x11 == TestData_LHS[i].x24 &
                          v16_13.x12 == TestData_LHS[i].x25 &
                          v16_13.x13 == TestData_LHS[i].x26 &
                          v16_13.x14 == TestData_LHS[i].x27 &
                          v16_13.x15 == TestData_LHS[i].x28;

                sbyte16 v16_14 = TestData_LHS[i].v16_14;
                result &= v16_14.x0 == TestData_LHS[i].x14 &
                          v16_14.x1 == TestData_LHS[i].x15 &
                          v16_14.x2 == TestData_LHS[i].x16 &
                          v16_14.x3 == TestData_LHS[i].x17 &
                          v16_14.x4 == TestData_LHS[i].x18 &
                          v16_14.x5 == TestData_LHS[i].x19 &
                          v16_14.x6 == TestData_LHS[i].x20 &
                          v16_14.x7 == TestData_LHS[i].x21 &
                          v16_14.x8 == TestData_LHS[i].x22 &
                          v16_14.x9 == TestData_LHS[i].x23 &
                          v16_14.x10 == TestData_LHS[i].x24 &
                          v16_14.x11 == TestData_LHS[i].x25 &
                          v16_14.x12 == TestData_LHS[i].x26 &
                          v16_14.x13 == TestData_LHS[i].x27 &
                          v16_14.x14 == TestData_LHS[i].x28 &
                          v16_14.x15 == TestData_LHS[i].x29;

                sbyte16 v16_15 = TestData_LHS[i].v16_15;
                result &= v16_15.x0 == TestData_LHS[i].x15 &
                          v16_15.x1 == TestData_LHS[i].x16 &
                          v16_15.x2 == TestData_LHS[i].x17 &
                          v16_15.x3 == TestData_LHS[i].x18 &
                          v16_15.x4 == TestData_LHS[i].x19 &
                          v16_15.x5 == TestData_LHS[i].x20 &
                          v16_15.x6 == TestData_LHS[i].x21 &
                          v16_15.x7 == TestData_LHS[i].x22 &
                          v16_15.x8 == TestData_LHS[i].x23 &
                          v16_15.x9 == TestData_LHS[i].x24 &
                          v16_15.x10 == TestData_LHS[i].x25 &
                          v16_15.x11 == TestData_LHS[i].x26 &
                          v16_15.x12 == TestData_LHS[i].x27 &
                          v16_15.x13 == TestData_LHS[i].x28 &
                          v16_15.x14 == TestData_LHS[i].x29 &
                          v16_15.x15 == TestData_LHS[i].x30;

                sbyte16 v16_16 = TestData_LHS[i].v16_16;
                result &= v16_16.x0  == TestData_LHS[i].x16 &
                          v16_16.x1  == TestData_LHS[i].x17 &
                          v16_16.x2  == TestData_LHS[i].x18 &
                          v16_16.x3  == TestData_LHS[i].x19 &
                          v16_16.x4  == TestData_LHS[i].x20 &
                          v16_16.x5  == TestData_LHS[i].x21 &
                          v16_16.x6  == TestData_LHS[i].x22 &
                          v16_16.x7  == TestData_LHS[i].x23 &
                          v16_16.x8  == TestData_LHS[i].x24 &
                          v16_16.x9  == TestData_LHS[i].x25 &
                          v16_16.x10 == TestData_LHS[i].x26 &
                          v16_16.x11 == TestData_LHS[i].x27 &
                          v16_16.x12 == TestData_LHS[i].x28 &
                          v16_16.x13 == TestData_LHS[i].x29 &
                          v16_16.x14 == TestData_LHS[i].x30 &
                          v16_16.x15 == TestData_LHS[i].x31;


                sbyte8 v8_0 = TestData_LHS[i].v8_0;
                result &= v8_0.x0 == TestData_LHS[i].x0 &
                          v8_0.x1 == TestData_LHS[i].x1 &
                          v8_0.x2 == TestData_LHS[i].x2 &
                          v8_0.x3 == TestData_LHS[i].x3 &
                          v8_0.x4 == TestData_LHS[i].x4 &
                          v8_0.x5 == TestData_LHS[i].x5 &
                          v8_0.x6 == TestData_LHS[i].x6 &
                          v8_0.x7 == TestData_LHS[i].x7;

                sbyte8 v8_1 = TestData_LHS[i].v8_1;
                result &= v8_1.x0 == TestData_LHS[i].x1 &
                          v8_1.x1 == TestData_LHS[i].x2 &
                          v8_1.x2 == TestData_LHS[i].x3 &
                          v8_1.x3 == TestData_LHS[i].x4 &
                          v8_1.x4 == TestData_LHS[i].x5 &
                          v8_1.x5 == TestData_LHS[i].x6 &
                          v8_1.x6 == TestData_LHS[i].x7 &
                          v8_1.x7 == TestData_LHS[i].x8;

                sbyte8 v8_2 = TestData_LHS[i].v8_2;
                result &= v8_2.x0 == TestData_LHS[i].x2 &
                          v8_2.x1 == TestData_LHS[i].x3 &
                          v8_2.x2 == TestData_LHS[i].x4 &
                          v8_2.x3 == TestData_LHS[i].x5 &
                          v8_2.x4 == TestData_LHS[i].x6 &
                          v8_2.x5 == TestData_LHS[i].x7 &
                          v8_2.x6 == TestData_LHS[i].x8 &
                          v8_2.x7 == TestData_LHS[i].x9;

                sbyte8 v8_3 = TestData_LHS[i].v8_3;
                result &= v8_3.x0 == TestData_LHS[i].x3 &
                          v8_3.x1 == TestData_LHS[i].x4 &
                          v8_3.x2 == TestData_LHS[i].x5 &
                          v8_3.x3 == TestData_LHS[i].x6 &
                          v8_3.x4 == TestData_LHS[i].x7 &
                          v8_3.x5 == TestData_LHS[i].x8 &
                          v8_3.x6 == TestData_LHS[i].x9 &
                          v8_3.x7 == TestData_LHS[i].x10;

                sbyte8 v8_4 = TestData_LHS[i].v8_4;
                result &= v8_4.x0 == TestData_LHS[i].x4 &
                          v8_4.x1 == TestData_LHS[i].x5 &
                          v8_4.x2 == TestData_LHS[i].x6 &
                          v8_4.x3 == TestData_LHS[i].x7 &
                          v8_4.x4 == TestData_LHS[i].x8 &
                          v8_4.x5 == TestData_LHS[i].x9 &
                          v8_4.x6 == TestData_LHS[i].x10 &
                          v8_4.x7 == TestData_LHS[i].x11;

                sbyte8 v8_5 = TestData_LHS[i].v8_5;
                result &= v8_5.x0 == TestData_LHS[i].x5 &
                          v8_5.x1 == TestData_LHS[i].x6 &
                          v8_5.x2 == TestData_LHS[i].x7 &
                          v8_5.x3 == TestData_LHS[i].x8 &
                          v8_5.x4 == TestData_LHS[i].x9 &
                          v8_5.x5 == TestData_LHS[i].x10 &
                          v8_5.x6 == TestData_LHS[i].x11 &
                          v8_5.x7 == TestData_LHS[i].x12;

                sbyte8 v8_6 = TestData_LHS[i].v8_6;
                result &= v8_6.x0 == TestData_LHS[i].x6 &
                          v8_6.x1 == TestData_LHS[i].x7 &
                          v8_6.x2 == TestData_LHS[i].x8 &
                          v8_6.x3 == TestData_LHS[i].x9 &
                          v8_6.x4 == TestData_LHS[i].x10 &
                          v8_6.x5 == TestData_LHS[i].x11 &
                          v8_6.x6 == TestData_LHS[i].x12 &
                          v8_6.x7 == TestData_LHS[i].x13;

                sbyte8 v8_7 = TestData_LHS[i].v8_7;
                result &= v8_7.x0 == TestData_LHS[i].x7 &
                          v8_7.x1 == TestData_LHS[i].x8 &
                          v8_7.x2 == TestData_LHS[i].x9 &
                          v8_7.x3 == TestData_LHS[i].x10 &
                          v8_7.x4 == TestData_LHS[i].x11 &
                          v8_7.x5 == TestData_LHS[i].x12 &
                          v8_7.x6 == TestData_LHS[i].x13 &
                          v8_7.x7 == TestData_LHS[i].x14;

                sbyte8 v8_8 = TestData_LHS[i].v8_8;
                result &= v8_8.x0 == TestData_LHS[i].x8 &
                          v8_8.x1 == TestData_LHS[i].x9 &
                          v8_8.x2 == TestData_LHS[i].x10 &
                          v8_8.x3 == TestData_LHS[i].x11 &
                          v8_8.x4 == TestData_LHS[i].x12 &
                          v8_8.x5 == TestData_LHS[i].x13 &
                          v8_8.x6 == TestData_LHS[i].x14 &
                          v8_8.x7 == TestData_LHS[i].x15;

                sbyte8 v8_9 = TestData_LHS[i].v8_9;
                result &= v8_9.x0 == TestData_LHS[i].x9 &
                          v8_9.x1 == TestData_LHS[i].x10 &
                          v8_9.x2 == TestData_LHS[i].x11 &
                          v8_9.x3 == TestData_LHS[i].x12 &
                          v8_9.x4 == TestData_LHS[i].x13 &
                          v8_9.x5 == TestData_LHS[i].x14 &
                          v8_9.x6 == TestData_LHS[i].x15 &
                          v8_9.x7 == TestData_LHS[i].x16;

                sbyte8 v8_10 = TestData_LHS[i].v8_10;
                result &= v8_10.x0 == TestData_LHS[i].x10 &
                          v8_10.x1 == TestData_LHS[i].x11 &
                          v8_10.x2 == TestData_LHS[i].x12 &
                          v8_10.x3 == TestData_LHS[i].x13 &
                          v8_10.x4 == TestData_LHS[i].x14 &
                          v8_10.x5 == TestData_LHS[i].x15 &
                          v8_10.x6 == TestData_LHS[i].x16 &
                          v8_10.x7 == TestData_LHS[i].x17;

                sbyte8 v8_11 = TestData_LHS[i].v8_11;
                result &= v8_11.x0 == TestData_LHS[i].x11 &
                          v8_11.x1 == TestData_LHS[i].x12 &
                          v8_11.x2 == TestData_LHS[i].x13 &
                          v8_11.x3 == TestData_LHS[i].x14 &
                          v8_11.x4 == TestData_LHS[i].x15 &
                          v8_11.x5 == TestData_LHS[i].x16 &
                          v8_11.x6 == TestData_LHS[i].x17 &
                          v8_11.x7 == TestData_LHS[i].x18;

                sbyte8 v8_12 = TestData_LHS[i].v8_12;
                result &= v8_12.x0 == TestData_LHS[i].x12 &
                          v8_12.x1 == TestData_LHS[i].x13 &
                          v8_12.x2 == TestData_LHS[i].x14 &
                          v8_12.x3 == TestData_LHS[i].x15 &
                          v8_12.x4 == TestData_LHS[i].x16 &
                          v8_12.x5 == TestData_LHS[i].x17 &
                          v8_12.x6 == TestData_LHS[i].x18 &
                          v8_12.x7 == TestData_LHS[i].x19;

                sbyte8 v8_13 = TestData_LHS[i].v8_13;
                result &= v8_13.x0 == TestData_LHS[i].x13 &
                          v8_13.x1 == TestData_LHS[i].x14 &
                          v8_13.x2 == TestData_LHS[i].x15 &
                          v8_13.x3 == TestData_LHS[i].x16 &
                          v8_13.x4 == TestData_LHS[i].x17 &
                          v8_13.x5 == TestData_LHS[i].x18 &
                          v8_13.x6 == TestData_LHS[i].x19 &
                          v8_13.x7 == TestData_LHS[i].x20;

                sbyte8 v8_14 = TestData_LHS[i].v8_14;
                result &= v8_14.x0 == TestData_LHS[i].x14 &
                          v8_14.x1 == TestData_LHS[i].x15 &
                          v8_14.x2 == TestData_LHS[i].x16 &
                          v8_14.x3 == TestData_LHS[i].x17 &
                          v8_14.x4 == TestData_LHS[i].x18 &
                          v8_14.x5 == TestData_LHS[i].x19 &
                          v8_14.x6 == TestData_LHS[i].x20 &
                          v8_14.x7 == TestData_LHS[i].x21;

                sbyte8 v8_15 = TestData_LHS[i].v8_15;
                result &= v8_15.x0 == TestData_LHS[i].x15 &
                          v8_15.x1 == TestData_LHS[i].x16 &
                          v8_15.x2 == TestData_LHS[i].x17 &
                          v8_15.x3 == TestData_LHS[i].x18 &
                          v8_15.x4 == TestData_LHS[i].x19 &
                          v8_15.x5 == TestData_LHS[i].x20 &
                          v8_15.x6 == TestData_LHS[i].x21 &
                          v8_15.x7 == TestData_LHS[i].x22;

                sbyte8 v8_16 = TestData_LHS[i].v8_16;
                result &= v8_16.x0 == TestData_LHS[i].x16 &
                          v8_16.x1 == TestData_LHS[i].x17 &
                          v8_16.x2 == TestData_LHS[i].x18 &
                          v8_16.x3 == TestData_LHS[i].x19 &
                          v8_16.x4 == TestData_LHS[i].x20 &
                          v8_16.x5 == TestData_LHS[i].x21 &
                          v8_16.x6 == TestData_LHS[i].x22 &
                          v8_16.x7 == TestData_LHS[i].x23;

                sbyte8 v8_17 = TestData_LHS[i].v8_17;
                result &= v8_17.x0 == TestData_LHS[i].x17 &
                          v8_17.x1 == TestData_LHS[i].x18 &
                          v8_17.x2 == TestData_LHS[i].x19 &
                          v8_17.x3 == TestData_LHS[i].x20 &
                          v8_17.x4 == TestData_LHS[i].x21 &
                          v8_17.x5 == TestData_LHS[i].x22 &
                          v8_17.x6 == TestData_LHS[i].x23 &
                          v8_17.x7 == TestData_LHS[i].x24;

                sbyte8 v8_18 = TestData_LHS[i].v8_18;
                result &= v8_18.x0 == TestData_LHS[i].x18 &
                          v8_18.x1 == TestData_LHS[i].x19 &
                          v8_18.x2 == TestData_LHS[i].x20 &
                          v8_18.x3 == TestData_LHS[i].x21 &
                          v8_18.x4 == TestData_LHS[i].x22 &
                          v8_18.x5 == TestData_LHS[i].x23 &
                          v8_18.x6 == TestData_LHS[i].x24 &
                          v8_18.x7 == TestData_LHS[i].x25;

                sbyte8 v8_19 = TestData_LHS[i].v8_19;
                result &= v8_19.x0 == TestData_LHS[i].x19 &
                          v8_19.x1 == TestData_LHS[i].x20 &
                          v8_19.x2 == TestData_LHS[i].x21 &
                          v8_19.x3 == TestData_LHS[i].x22 &
                          v8_19.x4 == TestData_LHS[i].x23 &
                          v8_19.x5 == TestData_LHS[i].x24 &
                          v8_19.x6 == TestData_LHS[i].x25 &
                          v8_19.x7 == TestData_LHS[i].x26;

                sbyte8 v8_20 = TestData_LHS[i].v8_20;
                result &= v8_20.x0 == TestData_LHS[i].x20 &
                          v8_20.x1 == TestData_LHS[i].x21 &
                          v8_20.x2 == TestData_LHS[i].x22 &
                          v8_20.x3 == TestData_LHS[i].x23 &
                          v8_20.x4 == TestData_LHS[i].x24 &
                          v8_20.x5 == TestData_LHS[i].x25 &
                          v8_20.x6 == TestData_LHS[i].x26 &
                          v8_20.x7 == TestData_LHS[i].x27;

                sbyte8 v8_21 = TestData_LHS[i].v8_21;
                result &= v8_21.x0 == TestData_LHS[i].x21 &
                          v8_21.x1 == TestData_LHS[i].x22 &
                          v8_21.x2 == TestData_LHS[i].x23 &
                          v8_21.x3 == TestData_LHS[i].x24 &
                          v8_21.x4 == TestData_LHS[i].x25 &
                          v8_21.x5 == TestData_LHS[i].x26 &
                          v8_21.x6 == TestData_LHS[i].x27 &
                          v8_21.x7 == TestData_LHS[i].x28;

                sbyte8 v8_22 = TestData_LHS[i].v8_22;
                result &= v8_22.x0 == TestData_LHS[i].x22 &
                          v8_22.x1 == TestData_LHS[i].x23 &
                          v8_22.x2 == TestData_LHS[i].x24 &
                          v8_22.x3 == TestData_LHS[i].x25 &
                          v8_22.x4 == TestData_LHS[i].x26 &
                          v8_22.x5 == TestData_LHS[i].x27 &
                          v8_22.x6 == TestData_LHS[i].x28 &
                          v8_22.x7 == TestData_LHS[i].x29;

                sbyte8 v8_23 = TestData_LHS[i].v8_23;
                result &= v8_23.x0 == TestData_LHS[i].x23 &
                          v8_23.x1 == TestData_LHS[i].x24 &
                          v8_23.x2 == TestData_LHS[i].x25 &
                          v8_23.x3 == TestData_LHS[i].x26 &
                          v8_23.x4 == TestData_LHS[i].x27 &
                          v8_23.x5 == TestData_LHS[i].x28 &
                          v8_23.x6 == TestData_LHS[i].x29 &
                          v8_23.x7 == TestData_LHS[i].x30;

                sbyte8 v8_24 = TestData_LHS[i].v8_24;
                result &= v8_24.x0 == TestData_LHS[i].x24 &
                          v8_24.x1 == TestData_LHS[i].x25 &
                          v8_24.x2 == TestData_LHS[i].x26 &
                          v8_24.x3 == TestData_LHS[i].x27 &
                          v8_24.x4 == TestData_LHS[i].x28 &
                          v8_24.x5 == TestData_LHS[i].x29 &
                          v8_24.x6 == TestData_LHS[i].x30 &
                          v8_24.x7 == TestData_LHS[i].x31;


                sbyte4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                sbyte4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                sbyte4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                sbyte4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                sbyte4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;

                sbyte4 v4_5 = TestData_LHS[i].v4_5;
                result &= v4_5.x == TestData_LHS[i].x5 &
                          v4_5.y == TestData_LHS[i].x6 &
                          v4_5.z == TestData_LHS[i].x7 &
                          v4_5.w == TestData_LHS[i].x8;

                sbyte4 v4_6 = TestData_LHS[i].v4_6;
                result &= v4_6.x == TestData_LHS[i].x6 &
                          v4_6.y == TestData_LHS[i].x7 &
                          v4_6.z == TestData_LHS[i].x8 &
                          v4_6.w == TestData_LHS[i].x9;

                sbyte4 v4_7 = TestData_LHS[i].v4_7;
                result &= v4_7.x == TestData_LHS[i].x7 &
                          v4_7.y == TestData_LHS[i].x8 &
                          v4_7.z == TestData_LHS[i].x9 &
                          v4_7.w == TestData_LHS[i].x10;

                sbyte4 v4_8 = TestData_LHS[i].v4_8;
                result &= v4_8.x == TestData_LHS[i].x8 &
                          v4_8.y == TestData_LHS[i].x9 &
                          v4_8.z == TestData_LHS[i].x10 &
                          v4_8.w == TestData_LHS[i].x11;

                sbyte4 v4_9 = TestData_LHS[i].v4_9;
                result &= v4_9.x == TestData_LHS[i].x9 &
                          v4_9.y == TestData_LHS[i].x10 &
                          v4_9.z == TestData_LHS[i].x11 &
                          v4_9.w == TestData_LHS[i].x12;

                sbyte4 v4_10 = TestData_LHS[i].v4_10;
                result &= v4_10.x == TestData_LHS[i].x10 &
                          v4_10.y == TestData_LHS[i].x11 &
                          v4_10.z == TestData_LHS[i].x12 &
                          v4_10.w == TestData_LHS[i].x13;

                sbyte4 v4_11 = TestData_LHS[i].v4_11;
                result &= v4_11.x == TestData_LHS[i].x11 &
                          v4_11.y == TestData_LHS[i].x12 &
                          v4_11.z == TestData_LHS[i].x13 &
                          v4_11.w == TestData_LHS[i].x14;

                sbyte4 v4_12 = TestData_LHS[i].v4_12;
                result &= v4_12.x == TestData_LHS[i].x12 &
                          v4_12.y == TestData_LHS[i].x13 &
                          v4_12.z == TestData_LHS[i].x14 &
                          v4_12.w == TestData_LHS[i].x15;

                sbyte4 v4_13 = TestData_LHS[i].v4_13;
                result &= v4_13.x == TestData_LHS[i].x13 &
                          v4_13.y == TestData_LHS[i].x14 &
                          v4_13.z == TestData_LHS[i].x15 &
                          v4_13.w == TestData_LHS[i].x16;

                sbyte4 v4_14 = TestData_LHS[i].v4_14;
                result &= v4_14.x == TestData_LHS[i].x14 &
                          v4_14.y == TestData_LHS[i].x15 &
                          v4_14.z == TestData_LHS[i].x16 &
                          v4_14.w == TestData_LHS[i].x17;

                sbyte4 v4_15 = TestData_LHS[i].v4_15;
                result &= v4_15.x == TestData_LHS[i].x15 &
                          v4_15.y == TestData_LHS[i].x16 &
                          v4_15.z == TestData_LHS[i].x17 &
                          v4_15.w == TestData_LHS[i].x18;

                sbyte4 v4_16 = TestData_LHS[i].v4_16;
                result &= v4_16.x == TestData_LHS[i].x16 &
                          v4_16.y == TestData_LHS[i].x17 &
                          v4_16.z == TestData_LHS[i].x18 &
                          v4_16.w == TestData_LHS[i].x19;

                sbyte4 v4_17 = TestData_LHS[i].v4_17;
                result &= v4_17.x == TestData_LHS[i].x17 &
                          v4_17.y == TestData_LHS[i].x18 &
                          v4_17.z == TestData_LHS[i].x19 &
                          v4_17.w == TestData_LHS[i].x20;

                sbyte4 v4_18 = TestData_LHS[i].v4_18;
                result &= v4_18.x == TestData_LHS[i].x18 &
                          v4_18.y == TestData_LHS[i].x19 &
                          v4_18.z == TestData_LHS[i].x20 &
                          v4_18.w == TestData_LHS[i].x21;

                sbyte4 v4_19 = TestData_LHS[i].v4_19;
                result &= v4_19.x == TestData_LHS[i].x19 &
                          v4_19.y == TestData_LHS[i].x20 &
                          v4_19.z == TestData_LHS[i].x21 &
                          v4_19.w == TestData_LHS[i].x22;

                sbyte4 v4_20 = TestData_LHS[i].v4_20;
                result &= v4_20.x == TestData_LHS[i].x20 &
                          v4_20.y == TestData_LHS[i].x21 &
                          v4_20.z == TestData_LHS[i].x22 &
                          v4_20.w == TestData_LHS[i].x23;

                sbyte4 v4_21 = TestData_LHS[i].v4_21;
                result &= v4_21.x == TestData_LHS[i].x21 &
                          v4_21.y == TestData_LHS[i].x22 &
                          v4_21.z == TestData_LHS[i].x23 &
                          v4_21.w == TestData_LHS[i].x24;

                sbyte4 v4_22 = TestData_LHS[i].v4_22;
                result &= v4_22.x == TestData_LHS[i].x22 &
                          v4_22.y == TestData_LHS[i].x23 &
                          v4_22.z == TestData_LHS[i].x24 &
                          v4_22.w == TestData_LHS[i].x25;

                sbyte4 v4_23 = TestData_LHS[i].v4_23;
                result &= v4_23.x == TestData_LHS[i].x23 &
                          v4_23.y == TestData_LHS[i].x24 &
                          v4_23.z == TestData_LHS[i].x25 &
                          v4_23.w == TestData_LHS[i].x26;

                sbyte4 v4_24 = TestData_LHS[i].v4_24;
                result &= v4_24.x == TestData_LHS[i].x24 &
                          v4_24.y == TestData_LHS[i].x25 &
                          v4_24.z == TestData_LHS[i].x26 &
                          v4_24.w == TestData_LHS[i].x27;

                sbyte4 v4_25 = TestData_LHS[i].v4_25;
                result &= v4_25.x == TestData_LHS[i].x25 &
                          v4_25.y == TestData_LHS[i].x26 &
                          v4_25.z == TestData_LHS[i].x27 &
                          v4_25.w == TestData_LHS[i].x28;

                sbyte4 v4_26 = TestData_LHS[i].v4_26;
                result &= v4_26.x == TestData_LHS[i].x26 &
                          v4_26.y == TestData_LHS[i].x27 &
                          v4_26.z == TestData_LHS[i].x28 &
                          v4_26.w == TestData_LHS[i].x29;

                sbyte4 v4_27 = TestData_LHS[i].v4_27;
                result &= v4_27.x == TestData_LHS[i].x27 &
                          v4_27.y == TestData_LHS[i].x28 &
                          v4_27.z == TestData_LHS[i].x29 &
                          v4_27.w == TestData_LHS[i].x30;

                sbyte4 v4_28 = TestData_LHS[i].v4_28;
                result &= v4_28.x == TestData_LHS[i].x28 &
                          v4_28.y == TestData_LHS[i].x29 &
                          v4_28.z == TestData_LHS[i].x30 &
                          v4_28.w == TestData_LHS[i].x31;


                sbyte3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                sbyte3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                sbyte3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                sbyte3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                sbyte3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                sbyte3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;

                sbyte3 v3_6 = TestData_LHS[i].v3_6;
                result &= v3_6.x == TestData_LHS[i].x6 &
                          v3_6.y == TestData_LHS[i].x7 &
                          v3_6.z == TestData_LHS[i].x8;

                sbyte3 v3_7 = TestData_LHS[i].v3_7;
                result &= v3_7.x == TestData_LHS[i].x7 &
                          v3_7.y == TestData_LHS[i].x8 &
                          v3_7.z == TestData_LHS[i].x9;

                sbyte3 v3_8 = TestData_LHS[i].v3_8;
                result &= v3_8.x == TestData_LHS[i].x8 &
                          v3_8.y == TestData_LHS[i].x9 &
                          v3_8.z == TestData_LHS[i].x10;

                sbyte3 v3_9 = TestData_LHS[i].v3_9;
                result &= v3_9.x == TestData_LHS[i].x9 &
                          v3_9.y == TestData_LHS[i].x10 &
                          v3_9.z == TestData_LHS[i].x11;

                sbyte3 v3_10 = TestData_LHS[i].v3_10;
                result &= v3_10.x == TestData_LHS[i].x10 &
                          v3_10.y == TestData_LHS[i].x11 &
                          v3_10.z == TestData_LHS[i].x12;

                sbyte3 v3_11 = TestData_LHS[i].v3_11;
                result &= v3_11.x == TestData_LHS[i].x11 &
                          v3_11.y == TestData_LHS[i].x12 &
                          v3_11.z == TestData_LHS[i].x13;

                sbyte3 v3_12 = TestData_LHS[i].v3_12;
                result &= v3_12.x == TestData_LHS[i].x12 &
                          v3_12.y == TestData_LHS[i].x13 &
                          v3_12.z == TestData_LHS[i].x14;

                sbyte3 v3_13 = TestData_LHS[i].v3_13;
                result &= v3_13.x == TestData_LHS[i].x13 &
                          v3_13.y == TestData_LHS[i].x14 &
                          v3_13.z == TestData_LHS[i].x15;

                sbyte3 v3_14 = TestData_LHS[i].v3_14;
                result &= v3_14.x == TestData_LHS[i].x14 &
                          v3_14.y == TestData_LHS[i].x15 &
                          v3_14.z == TestData_LHS[i].x16;

                sbyte3 v3_15 = TestData_LHS[i].v3_15;
                result &= v3_15.x == TestData_LHS[i].x15 &
                          v3_15.y == TestData_LHS[i].x16 &
                          v3_15.z == TestData_LHS[i].x17;

                sbyte3 v3_16 = TestData_LHS[i].v3_16;
                result &= v3_16.x == TestData_LHS[i].x16 &
                          v3_16.y == TestData_LHS[i].x17 &
                          v3_16.z == TestData_LHS[i].x18;

                sbyte3 v3_17 = TestData_LHS[i].v3_17;
                result &= v3_17.x == TestData_LHS[i].x17 &
                          v3_17.y == TestData_LHS[i].x18 &
                          v3_17.z == TestData_LHS[i].x19;

                sbyte3 v3_18 = TestData_LHS[i].v3_18;
                result &= v3_18.x == TestData_LHS[i].x18 &
                          v3_18.y == TestData_LHS[i].x19 &
                          v3_18.z == TestData_LHS[i].x20;

                sbyte3 v3_19 = TestData_LHS[i].v3_19;
                result &= v3_19.x == TestData_LHS[i].x19 &
                          v3_19.y == TestData_LHS[i].x20 &
                          v3_19.z == TestData_LHS[i].x21;

                sbyte3 v3_20 = TestData_LHS[i].v3_20;
                result &= v3_20.x == TestData_LHS[i].x20 &
                          v3_20.y == TestData_LHS[i].x21 &
                          v3_20.z == TestData_LHS[i].x22;

                sbyte3 v3_21 = TestData_LHS[i].v3_21;
                result &= v3_21.x == TestData_LHS[i].x21 &
                          v3_21.y == TestData_LHS[i].x22 &
                          v3_21.z == TestData_LHS[i].x23;

                sbyte3 v3_22 = TestData_LHS[i].v3_22;
                result &= v3_22.x == TestData_LHS[i].x22 &
                          v3_22.y == TestData_LHS[i].x23 &
                          v3_22.z == TestData_LHS[i].x24;

                sbyte3 v3_23 = TestData_LHS[i].v3_23;
                result &= v3_23.x == TestData_LHS[i].x23 &
                          v3_23.y == TestData_LHS[i].x24 &
                          v3_23.z == TestData_LHS[i].x25;

                sbyte3 v3_24 = TestData_LHS[i].v3_24;
                result &= v3_24.x == TestData_LHS[i].x24 &
                          v3_24.y == TestData_LHS[i].x25 &
                          v3_24.z == TestData_LHS[i].x26;

                sbyte3 v3_25 = TestData_LHS[i].v3_25;
                result &= v3_25.x == TestData_LHS[i].x25 &
                          v3_25.y == TestData_LHS[i].x26 &
                          v3_25.z == TestData_LHS[i].x27;

                sbyte3 v3_26 = TestData_LHS[i].v3_26;
                result &= v3_26.x == TestData_LHS[i].x26 &
                          v3_26.y == TestData_LHS[i].x27 &
                          v3_26.z == TestData_LHS[i].x28;

                sbyte3 v3_27 = TestData_LHS[i].v3_27;
                result &= v3_27.x == TestData_LHS[i].x27 &
                          v3_27.y == TestData_LHS[i].x28 &
                          v3_27.z == TestData_LHS[i].x29;

                sbyte3 v3_28 = TestData_LHS[i].v3_28;
                result &= v3_28.x == TestData_LHS[i].x28 &
                          v3_28.y == TestData_LHS[i].x29 &
                          v3_28.z == TestData_LHS[i].x30;

                sbyte3 v3_29 = TestData_LHS[i].v3_29;
                result &= v3_29.x == TestData_LHS[i].x29 &
                          v3_29.y == TestData_LHS[i].x30 &
                          v3_29.z == TestData_LHS[i].x31;


                sbyte2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                sbyte2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                sbyte2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                sbyte2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                sbyte2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                sbyte2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                sbyte2 v2_6 = TestData_LHS[i].v2_6;
                result &= v2_6.x == TestData_LHS[i].x6 &
                          v2_6.y == TestData_LHS[i].x7;

                sbyte2 v2_7 = TestData_LHS[i].v2_7;
                result &= v2_7.x == TestData_LHS[i].x7 &
                          v2_7.y == TestData_LHS[i].x8;

                sbyte2 v2_8 = TestData_LHS[i].v2_8;
                result &= v2_8.x == TestData_LHS[i].x8 &
                          v2_8.y == TestData_LHS[i].x9;

                sbyte2 v2_9 = TestData_LHS[i].v2_9;
                result &= v2_9.x == TestData_LHS[i].x9 &
                          v2_9.y == TestData_LHS[i].x10;

                sbyte2 v2_10 = TestData_LHS[i].v2_10;
                result &= v2_10.x == TestData_LHS[i].x10 &
                          v2_10.y == TestData_LHS[i].x11;

                sbyte2 v2_11 = TestData_LHS[i].v2_11;
                result &= v2_11.x == TestData_LHS[i].x11 &
                          v2_11.y == TestData_LHS[i].x12;

                sbyte2 v2_12 = TestData_LHS[i].v2_12;
                result &= v2_12.x == TestData_LHS[i].x12 &
                          v2_12.y == TestData_LHS[i].x13;

                sbyte2 v2_13 = TestData_LHS[i].v2_13;
                result &= v2_13.x == TestData_LHS[i].x13 &
                          v2_13.y == TestData_LHS[i].x14;

                sbyte2 v2_14 = TestData_LHS[i].v2_14;
                result &= v2_14.x == TestData_LHS[i].x14 &
                          v2_14.y == TestData_LHS[i].x15;

                sbyte2 v2_15 = TestData_LHS[i].v2_15;
                result &= v2_15.x == TestData_LHS[i].x15 &
                          v2_15.y == TestData_LHS[i].x16;

                sbyte2 v2_16 = TestData_LHS[i].v2_16;
                result &= v2_16.x == TestData_LHS[i].x16 &
                          v2_16.y == TestData_LHS[i].x17;

                sbyte2 v2_17 = TestData_LHS[i].v2_17;
                result &= v2_17.x == TestData_LHS[i].x17 &
                          v2_17.y == TestData_LHS[i].x18;

                sbyte2 v2_18 = TestData_LHS[i].v2_18;
                result &= v2_18.x == TestData_LHS[i].x18 &
                          v2_18.y == TestData_LHS[i].x19;

                sbyte2 v2_19 = TestData_LHS[i].v2_19;
                result &= v2_19.x == TestData_LHS[i].x19 &
                          v2_19.y == TestData_LHS[i].x20;

                sbyte2 v2_20 = TestData_LHS[i].v2_20;
                result &= v2_20.x == TestData_LHS[i].x20 &
                          v2_20.y == TestData_LHS[i].x21;

                sbyte2 v2_21 = TestData_LHS[i].v2_21;
                result &= v2_21.x == TestData_LHS[i].x21 &
                          v2_21.y == TestData_LHS[i].x22;

                sbyte2 v2_22 = TestData_LHS[i].v2_22;
                result &= v2_22.x == TestData_LHS[i].x22 &
                          v2_22.y == TestData_LHS[i].x23;

                sbyte2 v2_23 = TestData_LHS[i].v2_23;
                result &= v2_23.x == TestData_LHS[i].x23 &
                          v2_23.y == TestData_LHS[i].x24;

                sbyte2 v2_24 = TestData_LHS[i].v2_24;
                result &= v2_24.x == TestData_LHS[i].x24 &
                          v2_24.y == TestData_LHS[i].x25;

                sbyte2 v2_25 = TestData_LHS[i].v2_25;
                result &= v2_25.x == TestData_LHS[i].x25 &
                          v2_25.y == TestData_LHS[i].x26;

                sbyte2 v2_26 = TestData_LHS[i].v2_26;
                result &= v2_26.x == TestData_LHS[i].x26 &
                          v2_26.y == TestData_LHS[i].x27;

                sbyte2 v2_27 = TestData_LHS[i].v2_27;
                result &= v2_27.x == TestData_LHS[i].x27 &
                          v2_27.y == TestData_LHS[i].x28;

                sbyte2 v2_28 = TestData_LHS[i].v2_28;
                result &= v2_28.x == TestData_LHS[i].x28 &
                          v2_28.y == TestData_LHS[i].x29;

                sbyte2 v2_29 = TestData_LHS[i].v2_29;
                result &= v2_29.x == TestData_LHS[i].x29 &
                          v2_29.y == TestData_LHS[i].x30;

                sbyte2 v2_30 = TestData_LHS[i].v2_30;
                result &= v2_30.x == TestData_LHS[i].x30 &
                          v2_30.y == TestData_LHS[i].x31;
            }


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ShuffleSetter()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 v16_0 = TestData_LHS[i];
                v16_0.v16_0 = t_sbyte16.TestData_LHS[i];
                result &= v16_0.x0  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_0.x1  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_0.x2  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_0.x3  == t_sbyte16.TestData_LHS[i].x3  &
                          v16_0.x4  == t_sbyte16.TestData_LHS[i].x4  &
                          v16_0.x5  == t_sbyte16.TestData_LHS[i].x5  &
                          v16_0.x6  == t_sbyte16.TestData_LHS[i].x6  &
                          v16_0.x7  == t_sbyte16.TestData_LHS[i].x7  &
                          v16_0.x8  == t_sbyte16.TestData_LHS[i].x8  &
                          v16_0.x9  == t_sbyte16.TestData_LHS[i].x9  &
                          v16_0.x10 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_0.x11 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_0.x12 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_0.x13 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_0.x14 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_0.x15 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_0.x16 == TestData_LHS[i].x16 &
                          v16_0.x17 == TestData_LHS[i].x17 &
                          v16_0.x18 == TestData_LHS[i].x18 &
                          v16_0.x19 == TestData_LHS[i].x19 &
                          v16_0.x20 == TestData_LHS[i].x20 &
                          v16_0.x21 == TestData_LHS[i].x21 &
                          v16_0.x22 == TestData_LHS[i].x22 &
                          v16_0.x23 == TestData_LHS[i].x23 &
                          v16_0.x24 == TestData_LHS[i].x24 &
                          v16_0.x25 == TestData_LHS[i].x25 &
                          v16_0.x26 == TestData_LHS[i].x26 &
                          v16_0.x27 == TestData_LHS[i].x27 &
                          v16_0.x28 == TestData_LHS[i].x28 &
                          v16_0.x29 == TestData_LHS[i].x29 &
                          v16_0.x30 == TestData_LHS[i].x30 &
                          v16_0.x31 == TestData_LHS[i].x31;

                sbyte32 v16_1 = TestData_LHS[i];
                v16_1.v16_1 = t_sbyte16.TestData_LHS[i];
                result &= v16_1.x0  == TestData_LHS[i].x0  &
                          v16_1.x1  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_1.x2  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_1.x3  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_1.x4  == t_sbyte16.TestData_LHS[i].x3  &
                          v16_1.x5  == t_sbyte16.TestData_LHS[i].x4  &
                          v16_1.x6  == t_sbyte16.TestData_LHS[i].x5  &
                          v16_1.x7  == t_sbyte16.TestData_LHS[i].x6  &
                          v16_1.x8  == t_sbyte16.TestData_LHS[i].x7  &
                          v16_1.x9  == t_sbyte16.TestData_LHS[i].x8  &
                          v16_1.x10 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_1.x11 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_1.x12 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_1.x13 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_1.x14 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_1.x15 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_1.x16 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_1.x17 == TestData_LHS[i].x17 &
                          v16_1.x18 == TestData_LHS[i].x18 &
                          v16_1.x19 == TestData_LHS[i].x19 &
                          v16_1.x20 == TestData_LHS[i].x20 &
                          v16_1.x21 == TestData_LHS[i].x21 &
                          v16_1.x22 == TestData_LHS[i].x22 &
                          v16_1.x23 == TestData_LHS[i].x23 &
                          v16_1.x24 == TestData_LHS[i].x24 &
                          v16_1.x25 == TestData_LHS[i].x25 &
                          v16_1.x26 == TestData_LHS[i].x26 &
                          v16_1.x27 == TestData_LHS[i].x27 &
                          v16_1.x28 == TestData_LHS[i].x28 &
                          v16_1.x29 == TestData_LHS[i].x29 &
                          v16_1.x30 == TestData_LHS[i].x30 &
                          v16_1.x31 == TestData_LHS[i].x31;

                sbyte32 v16_2 = TestData_LHS[i];
                v16_2.v16_2 = t_sbyte16.TestData_LHS[i];
                result &= v16_2.x0  == TestData_LHS[i].x0  &
                          v16_2.x1  == TestData_LHS[i].x1  &
                          v16_2.x2  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_2.x3  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_2.x4  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_2.x5  == t_sbyte16.TestData_LHS[i].x3  &
                          v16_2.x6  == t_sbyte16.TestData_LHS[i].x4  &
                          v16_2.x7  == t_sbyte16.TestData_LHS[i].x5  &
                          v16_2.x8  == t_sbyte16.TestData_LHS[i].x6  &
                          v16_2.x9  == t_sbyte16.TestData_LHS[i].x7  &
                          v16_2.x10 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_2.x11 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_2.x12 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_2.x13 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_2.x14 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_2.x15 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_2.x16 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_2.x17 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_2.x18 == TestData_LHS[i].x18 &
                          v16_2.x19 == TestData_LHS[i].x19 &
                          v16_2.x20 == TestData_LHS[i].x20 &
                          v16_2.x21 == TestData_LHS[i].x21 &
                          v16_2.x22 == TestData_LHS[i].x22 &
                          v16_2.x23 == TestData_LHS[i].x23 &
                          v16_2.x24 == TestData_LHS[i].x24 &
                          v16_2.x25 == TestData_LHS[i].x25 &
                          v16_2.x26 == TestData_LHS[i].x26 &
                          v16_2.x27 == TestData_LHS[i].x27 &
                          v16_2.x28 == TestData_LHS[i].x28 &
                          v16_2.x29 == TestData_LHS[i].x29 &
                          v16_2.x30 == TestData_LHS[i].x30 &
                          v16_2.x31 == TestData_LHS[i].x31;

                sbyte32 v16_3 = TestData_LHS[i];
                v16_3.v16_3 = t_sbyte16.TestData_LHS[i];
                result &= v16_3.x0  == TestData_LHS[i].x0  &
                          v16_3.x1  == TestData_LHS[i].x1  &
                          v16_3.x2  == TestData_LHS[i].x2  &
                          v16_3.x3  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_3.x4  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_3.x5  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_3.x6  == t_sbyte16.TestData_LHS[i].x3  &
                          v16_3.x7  == t_sbyte16.TestData_LHS[i].x4  &
                          v16_3.x8  == t_sbyte16.TestData_LHS[i].x5  &
                          v16_3.x9  == t_sbyte16.TestData_LHS[i].x6  &
                          v16_3.x10 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_3.x11 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_3.x12 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_3.x13 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_3.x14 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_3.x15 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_3.x16 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_3.x17 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_3.x18 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_3.x19 == TestData_LHS[i].x19 &
                          v16_3.x20 == TestData_LHS[i].x20 &
                          v16_3.x21 == TestData_LHS[i].x21 &
                          v16_3.x22 == TestData_LHS[i].x22 &
                          v16_3.x23 == TestData_LHS[i].x23 &
                          v16_3.x24 == TestData_LHS[i].x24 &
                          v16_3.x25 == TestData_LHS[i].x25 &
                          v16_3.x26 == TestData_LHS[i].x26 &
                          v16_3.x27 == TestData_LHS[i].x27 &
                          v16_3.x28 == TestData_LHS[i].x28 &
                          v16_3.x29 == TestData_LHS[i].x29 &
                          v16_3.x30 == TestData_LHS[i].x30 &
                          v16_3.x31 == TestData_LHS[i].x31;

                sbyte32 v16_4 = TestData_LHS[i];
                v16_4.v16_4 = t_sbyte16.TestData_LHS[i];
                result &= v16_4.x0  == TestData_LHS[i].x0  &
                          v16_4.x1  == TestData_LHS[i].x1  &
                          v16_4.x2  == TestData_LHS[i].x2  &
                          v16_4.x3  == TestData_LHS[i].x3  &
                          v16_4.x4  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_4.x5  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_4.x6  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_4.x7  == t_sbyte16.TestData_LHS[i].x3  &
                          v16_4.x8  == t_sbyte16.TestData_LHS[i].x4  &
                          v16_4.x9  == t_sbyte16.TestData_LHS[i].x5  &
                          v16_4.x10 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_4.x11 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_4.x12 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_4.x13 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_4.x14 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_4.x15 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_4.x16 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_4.x17 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_4.x18 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_4.x19 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_4.x20 == TestData_LHS[i].x20 &
                          v16_4.x21 == TestData_LHS[i].x21 &
                          v16_4.x22 == TestData_LHS[i].x22 &
                          v16_4.x23 == TestData_LHS[i].x23 &
                          v16_4.x24 == TestData_LHS[i].x24 &
                          v16_4.x25 == TestData_LHS[i].x25 &
                          v16_4.x26 == TestData_LHS[i].x26 &
                          v16_4.x27 == TestData_LHS[i].x27 &
                          v16_4.x28 == TestData_LHS[i].x28 &
                          v16_4.x29 == TestData_LHS[i].x29 &
                          v16_4.x30 == TestData_LHS[i].x30 &
                          v16_4.x31 == TestData_LHS[i].x31;

                sbyte32 v16_5 = TestData_LHS[i];
                v16_5.v16_5 = t_sbyte16.TestData_LHS[i];
                result &= v16_5.x0  == TestData_LHS[i].x0  &
                          v16_5.x1  == TestData_LHS[i].x1  &
                          v16_5.x2  == TestData_LHS[i].x2  &
                          v16_5.x3  == TestData_LHS[i].x3  &
                          v16_5.x4  == TestData_LHS[i].x4  &
                          v16_5.x5  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_5.x6  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_5.x7  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_5.x8  == t_sbyte16.TestData_LHS[i].x3  &
                          v16_5.x9  == t_sbyte16.TestData_LHS[i].x4  &
                          v16_5.x10 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_5.x11 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_5.x12 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_5.x13 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_5.x14 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_5.x15 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_5.x16 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_5.x17 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_5.x18 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_5.x19 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_5.x20 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_5.x21 == TestData_LHS[i].x21 &
                          v16_5.x22 == TestData_LHS[i].x22 &
                          v16_5.x23 == TestData_LHS[i].x23 &
                          v16_5.x24 == TestData_LHS[i].x24 &
                          v16_5.x25 == TestData_LHS[i].x25 &
                          v16_5.x26 == TestData_LHS[i].x26 &
                          v16_5.x27 == TestData_LHS[i].x27 &
                          v16_5.x28 == TestData_LHS[i].x28 &
                          v16_5.x29 == TestData_LHS[i].x29 &
                          v16_5.x30 == TestData_LHS[i].x30 &
                          v16_5.x31 == TestData_LHS[i].x31;

                sbyte32 v16_6 = TestData_LHS[i];
                v16_6.v16_6 = t_sbyte16.TestData_LHS[i];
                result &= v16_6.x0  == TestData_LHS[i].x0  &
                          v16_6.x1  == TestData_LHS[i].x1  &
                          v16_6.x2  == TestData_LHS[i].x2  &
                          v16_6.x3  == TestData_LHS[i].x3  &
                          v16_6.x4  == TestData_LHS[i].x4  &
                          v16_6.x5  == TestData_LHS[i].x5  &
                          v16_6.x6  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_6.x7  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_6.x8  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_6.x9  == t_sbyte16.TestData_LHS[i].x3  &
                          v16_6.x10 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_6.x11 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_6.x12 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_6.x13 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_6.x14 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_6.x15 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_6.x16 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_6.x17 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_6.x18 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_6.x19 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_6.x20 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_6.x21 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_6.x22 == TestData_LHS[i].x22 &
                          v16_6.x23 == TestData_LHS[i].x23 &
                          v16_6.x24 == TestData_LHS[i].x24 &
                          v16_6.x25 == TestData_LHS[i].x25 &
                          v16_6.x26 == TestData_LHS[i].x26 &
                          v16_6.x27 == TestData_LHS[i].x27 &
                          v16_6.x28 == TestData_LHS[i].x28 &
                          v16_6.x29 == TestData_LHS[i].x29 &
                          v16_6.x30 == TestData_LHS[i].x30 &
                          v16_6.x31 == TestData_LHS[i].x31;

                sbyte32 v16_7 = TestData_LHS[i];
                v16_7.v16_7 = t_sbyte16.TestData_LHS[i];
                result &= v16_7.x0  == TestData_LHS[i].x0  &
                          v16_7.x1  == TestData_LHS[i].x1  &
                          v16_7.x2  == TestData_LHS[i].x2  &
                          v16_7.x3  == TestData_LHS[i].x3  &
                          v16_7.x4  == TestData_LHS[i].x4  &
                          v16_7.x5  == TestData_LHS[i].x5  &
                          v16_7.x6  == TestData_LHS[i].x6  &
                          v16_7.x7  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_7.x8  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_7.x9  == t_sbyte16.TestData_LHS[i].x2  &
                          v16_7.x10 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_7.x11 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_7.x12 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_7.x13 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_7.x14 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_7.x15 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_7.x16 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_7.x17 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_7.x18 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_7.x19 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_7.x20 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_7.x21 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_7.x22 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_7.x23 == TestData_LHS[i].x23 &
                          v16_7.x24 == TestData_LHS[i].x24 &
                          v16_7.x25 == TestData_LHS[i].x25 &
                          v16_7.x26 == TestData_LHS[i].x26 &
                          v16_7.x27 == TestData_LHS[i].x27 &
                          v16_7.x28 == TestData_LHS[i].x28 &
                          v16_7.x29 == TestData_LHS[i].x29 &
                          v16_7.x30 == TestData_LHS[i].x30 &
                          v16_7.x31 == TestData_LHS[i].x31;

                sbyte32 v16_8 = TestData_LHS[i];
                v16_8.v16_8 = t_sbyte16.TestData_LHS[i];
                result &= v16_8.x0  == TestData_LHS[i].x0  &
                          v16_8.x1  == TestData_LHS[i].x1  &
                          v16_8.x2  == TestData_LHS[i].x2  &
                          v16_8.x3  == TestData_LHS[i].x3  &
                          v16_8.x4  == TestData_LHS[i].x4  &
                          v16_8.x5  == TestData_LHS[i].x5  &
                          v16_8.x6  == TestData_LHS[i].x6  &
                          v16_8.x7  == TestData_LHS[i].x7  &
                          v16_8.x8  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_8.x9  == t_sbyte16.TestData_LHS[i].x1  &
                          v16_8.x10 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_8.x11 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_8.x12 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_8.x13 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_8.x14 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_8.x15 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_8.x16 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_8.x17 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_8.x18 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_8.x19 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_8.x20 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_8.x21 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_8.x22 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_8.x23 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_8.x24 == TestData_LHS[i].x24 &
                          v16_8.x25 == TestData_LHS[i].x25 &
                          v16_8.x26 == TestData_LHS[i].x26 &
                          v16_8.x27 == TestData_LHS[i].x27 &
                          v16_8.x28 == TestData_LHS[i].x28 &
                          v16_8.x29 == TestData_LHS[i].x29 &
                          v16_8.x30 == TestData_LHS[i].x30 &
                          v16_8.x31 == TestData_LHS[i].x31;

                sbyte32 v16_9 = TestData_LHS[i];
                v16_9.v16_9 = t_sbyte16.TestData_LHS[i];
                result &= v16_9.x0  == TestData_LHS[i].x0  &
                          v16_9.x1  == TestData_LHS[i].x1  &
                          v16_9.x2  == TestData_LHS[i].x2  &
                          v16_9.x3  == TestData_LHS[i].x3  &
                          v16_9.x4  == TestData_LHS[i].x4  &
                          v16_9.x5  == TestData_LHS[i].x5  &
                          v16_9.x6  == TestData_LHS[i].x6  &
                          v16_9.x7  == TestData_LHS[i].x7  &
                          v16_9.x8  == TestData_LHS[i].x8  &
                          v16_9.x9  == t_sbyte16.TestData_LHS[i].x0  &
                          v16_9.x10 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_9.x11 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_9.x12 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_9.x13 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_9.x14 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_9.x15 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_9.x16 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_9.x17 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_9.x18 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_9.x19 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_9.x20 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_9.x21 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_9.x22 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_9.x23 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_9.x24 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_9.x25 == TestData_LHS[i].x25 &
                          v16_9.x26 == TestData_LHS[i].x26 &
                          v16_9.x27 == TestData_LHS[i].x27 &
                          v16_9.x28 == TestData_LHS[i].x28 &
                          v16_9.x29 == TestData_LHS[i].x29 &
                          v16_9.x30 == TestData_LHS[i].x30 &
                          v16_9.x31 == TestData_LHS[i].x31;

                sbyte32 v16_10 = TestData_LHS[i];
                v16_10.v16_10 = t_sbyte16.TestData_LHS[i];
                result &= v16_10.x0  == TestData_LHS[i].x0  &
                          v16_10.x1  == TestData_LHS[i].x1  &
                          v16_10.x2  == TestData_LHS[i].x2  &
                          v16_10.x3  == TestData_LHS[i].x3  &
                          v16_10.x4  == TestData_LHS[i].x4  &
                          v16_10.x5  == TestData_LHS[i].x5  &
                          v16_10.x6  == TestData_LHS[i].x6  &
                          v16_10.x7  == TestData_LHS[i].x7  &
                          v16_10.x8  == TestData_LHS[i].x8  &
                          v16_10.x9  == TestData_LHS[i].x9  &
                          v16_10.x10 == t_sbyte16.TestData_LHS[i].x0  &
                          v16_10.x11 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_10.x12 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_10.x13 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_10.x14 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_10.x15 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_10.x16 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_10.x17 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_10.x18 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_10.x19 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_10.x20 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_10.x21 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_10.x22 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_10.x23 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_10.x24 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_10.x25 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_10.x26 == TestData_LHS[i].x26 &
                          v16_10.x27 == TestData_LHS[i].x27 &
                          v16_10.x28 == TestData_LHS[i].x28 &
                          v16_10.x29 == TestData_LHS[i].x29 &
                          v16_10.x30 == TestData_LHS[i].x30 &
                          v16_10.x31 == TestData_LHS[i].x31;

                sbyte32 v16_11 = TestData_LHS[i];
                v16_11.v16_11 = t_sbyte16.TestData_LHS[i];
                result &= v16_11.x0  == TestData_LHS[i].x0  &
                          v16_11.x1  == TestData_LHS[i].x1  &
                          v16_11.x2  == TestData_LHS[i].x2  &
                          v16_11.x3  == TestData_LHS[i].x3  &
                          v16_11.x4  == TestData_LHS[i].x4  &
                          v16_11.x5  == TestData_LHS[i].x5  &
                          v16_11.x6  == TestData_LHS[i].x6  &
                          v16_11.x7  == TestData_LHS[i].x7  &
                          v16_11.x8  == TestData_LHS[i].x8  &
                          v16_11.x9  == TestData_LHS[i].x9  &
                          v16_11.x10 == TestData_LHS[i].x10 &
                          v16_11.x11 == t_sbyte16.TestData_LHS[i].x0  &
                          v16_11.x12 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_11.x13 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_11.x14 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_11.x15 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_11.x16 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_11.x17 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_11.x18 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_11.x19 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_11.x20 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_11.x21 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_11.x22 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_11.x23 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_11.x24 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_11.x25 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_11.x26 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_11.x27 == TestData_LHS[i].x27 &
                          v16_11.x28 == TestData_LHS[i].x28 &
                          v16_11.x29 == TestData_LHS[i].x29 &
                          v16_11.x30 == TestData_LHS[i].x30 &
                          v16_11.x31 == TestData_LHS[i].x31;

                sbyte32 v16_12 = TestData_LHS[i];
                v16_12.v16_12 = t_sbyte16.TestData_LHS[i];
                result &= v16_12.x0  == TestData_LHS[i].x0  &
                          v16_12.x1  == TestData_LHS[i].x1  &
                          v16_12.x2  == TestData_LHS[i].x2  &
                          v16_12.x3  == TestData_LHS[i].x3  &
                          v16_12.x4  == TestData_LHS[i].x4  &
                          v16_12.x5  == TestData_LHS[i].x5  &
                          v16_12.x6  == TestData_LHS[i].x6  &
                          v16_12.x7  == TestData_LHS[i].x7  &
                          v16_12.x8  == TestData_LHS[i].x8  &
                          v16_12.x9  == TestData_LHS[i].x9  &
                          v16_12.x10 == TestData_LHS[i].x10 &
                          v16_12.x11 == TestData_LHS[i].x11 &
                          v16_12.x12 == t_sbyte16.TestData_LHS[i].x0  &
                          v16_12.x13 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_12.x14 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_12.x15 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_12.x16 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_12.x17 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_12.x18 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_12.x19 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_12.x20 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_12.x21 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_12.x22 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_12.x23 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_12.x24 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_12.x25 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_12.x26 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_12.x27 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_12.x28 == TestData_LHS[i].x28 &
                          v16_12.x29 == TestData_LHS[i].x29 &
                          v16_12.x30 == TestData_LHS[i].x30 &
                          v16_12.x31 == TestData_LHS[i].x31;

                sbyte32 v16_13 = TestData_LHS[i];
                v16_13.v16_13 = t_sbyte16.TestData_LHS[i];
                result &= v16_13.x0  == TestData_LHS[i].x0  &
                          v16_13.x1  == TestData_LHS[i].x1  &
                          v16_13.x2  == TestData_LHS[i].x2  &
                          v16_13.x3  == TestData_LHS[i].x3  &
                          v16_13.x4  == TestData_LHS[i].x4  &
                          v16_13.x5  == TestData_LHS[i].x5  &
                          v16_13.x6  == TestData_LHS[i].x6  &
                          v16_13.x7  == TestData_LHS[i].x7  &
                          v16_13.x8  == TestData_LHS[i].x8  &
                          v16_13.x9  == TestData_LHS[i].x9  &
                          v16_13.x10 == TestData_LHS[i].x10 &
                          v16_13.x11 == TestData_LHS[i].x11 &
                          v16_13.x12 == TestData_LHS[i].x12 &
                          v16_13.x13 == t_sbyte16.TestData_LHS[i].x0  &
                          v16_13.x14 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_13.x15 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_13.x16 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_13.x17 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_13.x18 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_13.x19 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_13.x20 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_13.x21 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_13.x22 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_13.x23 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_13.x24 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_13.x25 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_13.x26 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_13.x27 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_13.x28 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_13.x29 == TestData_LHS[i].x29 &
                          v16_13.x30 == TestData_LHS[i].x30 &
                          v16_13.x31 == TestData_LHS[i].x31;

                sbyte32 v16_14 = TestData_LHS[i];
                v16_14.v16_14 = t_sbyte16.TestData_LHS[i];
                result &= v16_14.x0  == TestData_LHS[i].x0  &
                          v16_14.x1  == TestData_LHS[i].x1  &
                          v16_14.x2  == TestData_LHS[i].x2  &
                          v16_14.x3  == TestData_LHS[i].x3  &
                          v16_14.x4  == TestData_LHS[i].x4  &
                          v16_14.x5  == TestData_LHS[i].x5  &
                          v16_14.x6  == TestData_LHS[i].x6  &
                          v16_14.x7  == TestData_LHS[i].x7  &
                          v16_14.x8  == TestData_LHS[i].x8  &
                          v16_14.x9  == TestData_LHS[i].x9  &
                          v16_14.x10 == TestData_LHS[i].x10 &
                          v16_14.x11 == TestData_LHS[i].x11 &
                          v16_14.x12 == TestData_LHS[i].x12 &
                          v16_14.x13 == TestData_LHS[i].x13 &
                          v16_14.x14 == t_sbyte16.TestData_LHS[i].x0  &
                          v16_14.x15 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_14.x16 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_14.x17 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_14.x18 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_14.x19 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_14.x20 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_14.x21 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_14.x22 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_14.x23 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_14.x24 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_14.x25 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_14.x26 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_14.x27 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_14.x28 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_14.x29 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_14.x30 == TestData_LHS[i].x30 &
                          v16_14.x31 == TestData_LHS[i].x31;

                sbyte32 v16_15 = TestData_LHS[i];
                v16_15.v16_15 = t_sbyte16.TestData_LHS[i];
                result &= v16_15.x0  == TestData_LHS[i].x0  &
                          v16_15.x1  == TestData_LHS[i].x1  &
                          v16_15.x2  == TestData_LHS[i].x2  &
                          v16_15.x3  == TestData_LHS[i].x3  &
                          v16_15.x4  == TestData_LHS[i].x4  &
                          v16_15.x5  == TestData_LHS[i].x5  &
                          v16_15.x6  == TestData_LHS[i].x6  &
                          v16_15.x7  == TestData_LHS[i].x7  &
                          v16_15.x8  == TestData_LHS[i].x8  &
                          v16_15.x9  == TestData_LHS[i].x9  &
                          v16_15.x10 == TestData_LHS[i].x10 &
                          v16_15.x11 == TestData_LHS[i].x11 &
                          v16_15.x12 == TestData_LHS[i].x12 &
                          v16_15.x13 == TestData_LHS[i].x13 &
                          v16_15.x14 == TestData_LHS[i].x14 &
                          v16_15.x15 == t_sbyte16.TestData_LHS[i].x0  &
                          v16_15.x16 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_15.x17 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_15.x18 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_15.x19 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_15.x20 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_15.x21 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_15.x22 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_15.x23 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_15.x24 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_15.x25 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_15.x26 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_15.x27 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_15.x28 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_15.x29 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_15.x30 == t_sbyte16.TestData_LHS[i].x15 &
                          v16_15.x31 == TestData_LHS[i].x31;

                sbyte32 v16_16 = TestData_LHS[i];
                v16_16.v16_16 = t_sbyte16.TestData_LHS[i];
                result &= v16_16.x0  == TestData_LHS[i].x0  &
                          v16_16.x1  == TestData_LHS[i].x1  &
                          v16_16.x2  == TestData_LHS[i].x2  &
                          v16_16.x3  == TestData_LHS[i].x3  &
                          v16_16.x4  == TestData_LHS[i].x4  &
                          v16_16.x5  == TestData_LHS[i].x5  &
                          v16_16.x6  == TestData_LHS[i].x6  &
                          v16_16.x7  == TestData_LHS[i].x7  &
                          v16_16.x8  == TestData_LHS[i].x8  &
                          v16_16.x9  == TestData_LHS[i].x9  &
                          v16_16.x10 == TestData_LHS[i].x10 &
                          v16_16.x11 == TestData_LHS[i].x11 &
                          v16_16.x12 == TestData_LHS[i].x12 &
                          v16_16.x13 == TestData_LHS[i].x13 &
                          v16_16.x14 == TestData_LHS[i].x14 &
                          v16_16.x15 == TestData_LHS[i].x15 &
                          v16_16.x16 == t_sbyte16.TestData_LHS[i].x0  &
                          v16_16.x17 == t_sbyte16.TestData_LHS[i].x1  &
                          v16_16.x18 == t_sbyte16.TestData_LHS[i].x2  &
                          v16_16.x19 == t_sbyte16.TestData_LHS[i].x3  &
                          v16_16.x20 == t_sbyte16.TestData_LHS[i].x4  &
                          v16_16.x21 == t_sbyte16.TestData_LHS[i].x5  &
                          v16_16.x22 == t_sbyte16.TestData_LHS[i].x6  &
                          v16_16.x23 == t_sbyte16.TestData_LHS[i].x7  &
                          v16_16.x24 == t_sbyte16.TestData_LHS[i].x8  &
                          v16_16.x25 == t_sbyte16.TestData_LHS[i].x9  &
                          v16_16.x26 == t_sbyte16.TestData_LHS[i].x10 &
                          v16_16.x27 == t_sbyte16.TestData_LHS[i].x11 &
                          v16_16.x28 == t_sbyte16.TestData_LHS[i].x12 &
                          v16_16.x29 == t_sbyte16.TestData_LHS[i].x13 &
                          v16_16.x30 == t_sbyte16.TestData_LHS[i].x14 &
                          v16_16.x31 == t_sbyte16.TestData_LHS[i].x15;



                sbyte32 v8_0 = TestData_LHS[i];
                v8_0.v8_0 = t_sbyte8.TestData_LHS[i];
                result &= v8_0.x0  == t_sbyte8.TestData_LHS[i].x0  &
                          v8_0.x1  == t_sbyte8.TestData_LHS[i].x1  &
                          v8_0.x2  == t_sbyte8.TestData_LHS[i].x2  &
                          v8_0.x3  == t_sbyte8.TestData_LHS[i].x3  &
                          v8_0.x4  == t_sbyte8.TestData_LHS[i].x4  &
                          v8_0.x5  == t_sbyte8.TestData_LHS[i].x5  &
                          v8_0.x6  == t_sbyte8.TestData_LHS[i].x6  &
                          v8_0.x7  == t_sbyte8.TestData_LHS[i].x7  &
                          v8_0.x8  == TestData_LHS[i].x8  &
                          v8_0.x9  == TestData_LHS[i].x9  &
                          v8_0.x10 == TestData_LHS[i].x10 &
                          v8_0.x11 == TestData_LHS[i].x11 &
                          v8_0.x12 == TestData_LHS[i].x12 &
                          v8_0.x13 == TestData_LHS[i].x13 &
                          v8_0.x14 == TestData_LHS[i].x14 &
                          v8_0.x15 == TestData_LHS[i].x15 &
                          v8_0.x16 == TestData_LHS[i].x16 &
                          v8_0.x17 == TestData_LHS[i].x17 &
                          v8_0.x18 == TestData_LHS[i].x18 &
                          v8_0.x19 == TestData_LHS[i].x19 &
                          v8_0.x20 == TestData_LHS[i].x20 &
                          v8_0.x21 == TestData_LHS[i].x21 &
                          v8_0.x22 == TestData_LHS[i].x22 &
                          v8_0.x23 == TestData_LHS[i].x23 &
                          v8_0.x24 == TestData_LHS[i].x24 &
                          v8_0.x25 == TestData_LHS[i].x25 &
                          v8_0.x26 == TestData_LHS[i].x26 &
                          v8_0.x27 == TestData_LHS[i].x27 &
                          v8_0.x28 == TestData_LHS[i].x28 &
                          v8_0.x29 == TestData_LHS[i].x29 &
                          v8_0.x30 == TestData_LHS[i].x30 &
                          v8_0.x31 == TestData_LHS[i].x31;

                sbyte32 v8_1 = TestData_LHS[i];
                v8_1.v8_1 = t_sbyte8.TestData_LHS[i];
                result &= v8_1.x0  == TestData_LHS[i].x0  &
                          v8_1.x1  == t_sbyte8.TestData_LHS[i].x0  &
                          v8_1.x2  == t_sbyte8.TestData_LHS[i].x1  &
                          v8_1.x3  == t_sbyte8.TestData_LHS[i].x2  &
                          v8_1.x4  == t_sbyte8.TestData_LHS[i].x3  &
                          v8_1.x5  == t_sbyte8.TestData_LHS[i].x4  &
                          v8_1.x6  == t_sbyte8.TestData_LHS[i].x5  &
                          v8_1.x7  == t_sbyte8.TestData_LHS[i].x6  &
                          v8_1.x8  == t_sbyte8.TestData_LHS[i].x7 &
                          v8_1.x9  == TestData_LHS[i].x9  &
                          v8_1.x10 == TestData_LHS[i].x10 &
                          v8_1.x11 == TestData_LHS[i].x11 &
                          v8_1.x12 == TestData_LHS[i].x12 &
                          v8_1.x13 == TestData_LHS[i].x13 &
                          v8_1.x14 == TestData_LHS[i].x14 &
                          v8_1.x15 == TestData_LHS[i].x15 &
                          v8_1.x16 == TestData_LHS[i].x16 &
                          v8_1.x17 == TestData_LHS[i].x17 &
                          v8_1.x18 == TestData_LHS[i].x18 &
                          v8_1.x19 == TestData_LHS[i].x19 &
                          v8_1.x20 == TestData_LHS[i].x20 &
                          v8_1.x21 == TestData_LHS[i].x21 &
                          v8_1.x22 == TestData_LHS[i].x22 &
                          v8_1.x23 == TestData_LHS[i].x23 &
                          v8_1.x24 == TestData_LHS[i].x24 &
                          v8_1.x25 == TestData_LHS[i].x25 &
                          v8_1.x26 == TestData_LHS[i].x26 &
                          v8_1.x27 == TestData_LHS[i].x27 &
                          v8_1.x28 == TestData_LHS[i].x28 &
                          v8_1.x29 == TestData_LHS[i].x29 &
                          v8_1.x30 == TestData_LHS[i].x30 &
                          v8_1.x31 == TestData_LHS[i].x31;

                sbyte32 v8_2 = TestData_LHS[i];
                v8_2.v8_2 = t_sbyte8.TestData_LHS[i];
                result &= v8_2.x0  == TestData_LHS[i].x0  &
                          v8_2.x1  == TestData_LHS[i].x1  &
                          v8_2.x2  == t_sbyte8.TestData_LHS[i].x0  &
                          v8_2.x3  == t_sbyte8.TestData_LHS[i].x1  &
                          v8_2.x4  == t_sbyte8.TestData_LHS[i].x2  &
                          v8_2.x5  == t_sbyte8.TestData_LHS[i].x3  &
                          v8_2.x6  == t_sbyte8.TestData_LHS[i].x4  &
                          v8_2.x7  == t_sbyte8.TestData_LHS[i].x5  &
                          v8_2.x8  == t_sbyte8.TestData_LHS[i].x6  &
                          v8_2.x9  == t_sbyte8.TestData_LHS[i].x7 &
                          v8_2.x10 == TestData_LHS[i].x10 &
                          v8_2.x11 == TestData_LHS[i].x11 &
                          v8_2.x12 == TestData_LHS[i].x12 &
                          v8_2.x13 == TestData_LHS[i].x13 &
                          v8_2.x14 == TestData_LHS[i].x14 &
                          v8_2.x15 == TestData_LHS[i].x15 &
                          v8_2.x16 == TestData_LHS[i].x16 &
                          v8_2.x17 == TestData_LHS[i].x17 &
                          v8_2.x18 == TestData_LHS[i].x18 &
                          v8_2.x19 == TestData_LHS[i].x19 &
                          v8_2.x20 == TestData_LHS[i].x20 &
                          v8_2.x21 == TestData_LHS[i].x21 &
                          v8_2.x22 == TestData_LHS[i].x22 &
                          v8_2.x23 == TestData_LHS[i].x23 &
                          v8_2.x24 == TestData_LHS[i].x24 &
                          v8_2.x25 == TestData_LHS[i].x25 &
                          v8_2.x26 == TestData_LHS[i].x26 &
                          v8_2.x27 == TestData_LHS[i].x27 &
                          v8_2.x28 == TestData_LHS[i].x28 &
                          v8_2.x29 == TestData_LHS[i].x29 &
                          v8_2.x30 == TestData_LHS[i].x30 &
                          v8_2.x31 == TestData_LHS[i].x31;

                sbyte32 v8_3 = TestData_LHS[i];
                v8_3.v8_3 = t_sbyte8.TestData_LHS[i];
                result &= v8_3.x0  == TestData_LHS[i].x0  &
                          v8_3.x1  == TestData_LHS[i].x1  &
                          v8_3.x2  == TestData_LHS[i].x2  &
                          v8_3.x3  == t_sbyte8.TestData_LHS[i].x0 &
                          v8_3.x4  == t_sbyte8.TestData_LHS[i].x1 &
                          v8_3.x5  == t_sbyte8.TestData_LHS[i].x2 &
                          v8_3.x6  == t_sbyte8.TestData_LHS[i].x3 &
                          v8_3.x7  == t_sbyte8.TestData_LHS[i].x4 &
                          v8_3.x8  == t_sbyte8.TestData_LHS[i].x5 &
                          v8_3.x9  == t_sbyte8.TestData_LHS[i].x6 &
                          v8_3.x10 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_3.x11 == TestData_LHS[i].x11 &
                          v8_3.x12 == TestData_LHS[i].x12 &
                          v8_3.x13 == TestData_LHS[i].x13 &
                          v8_3.x14 == TestData_LHS[i].x14 &
                          v8_3.x15 == TestData_LHS[i].x15 &
                          v8_3.x16 == TestData_LHS[i].x16 &
                          v8_3.x17 == TestData_LHS[i].x17 &
                          v8_3.x18 == TestData_LHS[i].x18 &
                          v8_3.x19 == TestData_LHS[i].x19 &
                          v8_3.x20 == TestData_LHS[i].x20 &
                          v8_3.x21 == TestData_LHS[i].x21 &
                          v8_3.x22 == TestData_LHS[i].x22 &
                          v8_3.x23 == TestData_LHS[i].x23 &
                          v8_3.x24 == TestData_LHS[i].x24 &
                          v8_3.x25 == TestData_LHS[i].x25 &
                          v8_3.x26 == TestData_LHS[i].x26 &
                          v8_3.x27 == TestData_LHS[i].x27 &
                          v8_3.x28 == TestData_LHS[i].x28 &
                          v8_3.x29 == TestData_LHS[i].x29 &
                          v8_3.x30 == TestData_LHS[i].x30 &
                          v8_3.x31 == TestData_LHS[i].x31;

                sbyte32 v8_4 = TestData_LHS[i];
                v8_4.v8_4 = t_sbyte8.TestData_LHS[i];
                result &= v8_4.x0  == TestData_LHS[i].x0  &
                          v8_4.x1  == TestData_LHS[i].x1  &
                          v8_4.x2  == TestData_LHS[i].x2  &
                          v8_4.x3  == TestData_LHS[i].x3  &
                          v8_4.x4  == t_sbyte8.TestData_LHS[i].x0 &
                          v8_4.x5  == t_sbyte8.TestData_LHS[i].x1 &
                          v8_4.x6  == t_sbyte8.TestData_LHS[i].x2 &
                          v8_4.x7  == t_sbyte8.TestData_LHS[i].x3 &
                          v8_4.x8  == t_sbyte8.TestData_LHS[i].x4 &
                          v8_4.x9  == t_sbyte8.TestData_LHS[i].x5 &
                          v8_4.x10 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_4.x11 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_4.x12 == TestData_LHS[i].x12 &
                          v8_4.x13 == TestData_LHS[i].x13 &
                          v8_4.x14 == TestData_LHS[i].x14 &
                          v8_4.x15 == TestData_LHS[i].x15 &
                          v8_4.x16 == TestData_LHS[i].x16 &
                          v8_4.x17 == TestData_LHS[i].x17 &
                          v8_4.x18 == TestData_LHS[i].x18 &
                          v8_4.x19 == TestData_LHS[i].x19 &
                          v8_4.x20 == TestData_LHS[i].x20 &
                          v8_4.x21 == TestData_LHS[i].x21 &
                          v8_4.x22 == TestData_LHS[i].x22 &
                          v8_4.x23 == TestData_LHS[i].x23 &
                          v8_4.x24 == TestData_LHS[i].x24 &
                          v8_4.x25 == TestData_LHS[i].x25 &
                          v8_4.x26 == TestData_LHS[i].x26 &
                          v8_4.x27 == TestData_LHS[i].x27 &
                          v8_4.x28 == TestData_LHS[i].x28 &
                          v8_4.x29 == TestData_LHS[i].x29 &
                          v8_4.x30 == TestData_LHS[i].x30 &
                          v8_4.x31 == TestData_LHS[i].x31;

                sbyte32 v8_5 = TestData_LHS[i];
                v8_5.v8_5 = t_sbyte8.TestData_LHS[i];
                result &= v8_5.x0  == TestData_LHS[i].x0  &
                          v8_5.x1  == TestData_LHS[i].x1  &
                          v8_5.x2  == TestData_LHS[i].x2  &
                          v8_5.x3  == TestData_LHS[i].x3  &
                          v8_5.x4  == TestData_LHS[i].x4  &
                          v8_5.x5  == t_sbyte8.TestData_LHS[i].x0 &
                          v8_5.x6  == t_sbyte8.TestData_LHS[i].x1 &
                          v8_5.x7  == t_sbyte8.TestData_LHS[i].x2 &
                          v8_5.x8  == t_sbyte8.TestData_LHS[i].x3 &
                          v8_5.x9  == t_sbyte8.TestData_LHS[i].x4 &
                          v8_5.x10 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_5.x11 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_5.x12 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_5.x13 == TestData_LHS[i].x13 &
                          v8_5.x14 == TestData_LHS[i].x14 &
                          v8_5.x15 == TestData_LHS[i].x15 &
                          v8_5.x16 == TestData_LHS[i].x16 &
                          v8_5.x17 == TestData_LHS[i].x17 &
                          v8_5.x18 == TestData_LHS[i].x18 &
                          v8_5.x19 == TestData_LHS[i].x19 &
                          v8_5.x20 == TestData_LHS[i].x20 &
                          v8_5.x21 == TestData_LHS[i].x21 &
                          v8_5.x22 == TestData_LHS[i].x22 &
                          v8_5.x23 == TestData_LHS[i].x23 &
                          v8_5.x24 == TestData_LHS[i].x24 &
                          v8_5.x25 == TestData_LHS[i].x25 &
                          v8_5.x26 == TestData_LHS[i].x26 &
                          v8_5.x27 == TestData_LHS[i].x27 &
                          v8_5.x28 == TestData_LHS[i].x28 &
                          v8_5.x29 == TestData_LHS[i].x29 &
                          v8_5.x30 == TestData_LHS[i].x30 &
                          v8_5.x31 == TestData_LHS[i].x31;

                sbyte32 v8_6 = TestData_LHS[i];
                v8_6.v8_6 = t_sbyte8.TestData_LHS[i];
                result &= v8_6.x0  == TestData_LHS[i].x0  &
                          v8_6.x1  == TestData_LHS[i].x1  &
                          v8_6.x2  == TestData_LHS[i].x2  &
                          v8_6.x3  == TestData_LHS[i].x3  &
                          v8_6.x4  == TestData_LHS[i].x4  &
                          v8_6.x5  == TestData_LHS[i].x5  &
                          v8_6.x6  == t_sbyte8.TestData_LHS[i].x0 &
                          v8_6.x7  == t_sbyte8.TestData_LHS[i].x1 &
                          v8_6.x8  == t_sbyte8.TestData_LHS[i].x2 &
                          v8_6.x9  == t_sbyte8.TestData_LHS[i].x3 &
                          v8_6.x10 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_6.x11 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_6.x12 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_6.x13 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_6.x14 == TestData_LHS[i].x14 &
                          v8_6.x15 == TestData_LHS[i].x15 &
                          v8_6.x16 == TestData_LHS[i].x16 &
                          v8_6.x17 == TestData_LHS[i].x17 &
                          v8_6.x18 == TestData_LHS[i].x18 &
                          v8_6.x19 == TestData_LHS[i].x19 &
                          v8_6.x20 == TestData_LHS[i].x20 &
                          v8_6.x21 == TestData_LHS[i].x21 &
                          v8_6.x22 == TestData_LHS[i].x22 &
                          v8_6.x23 == TestData_LHS[i].x23 &
                          v8_6.x24 == TestData_LHS[i].x24 &
                          v8_6.x25 == TestData_LHS[i].x25 &
                          v8_6.x26 == TestData_LHS[i].x26 &
                          v8_6.x27 == TestData_LHS[i].x27 &
                          v8_6.x28 == TestData_LHS[i].x28 &
                          v8_6.x29 == TestData_LHS[i].x29 &
                          v8_6.x30 == TestData_LHS[i].x30 &
                          v8_6.x31 == TestData_LHS[i].x31;

                sbyte32 v8_7 = TestData_LHS[i];
                v8_7.v8_7 = t_sbyte8.TestData_LHS[i];
                result &= v8_7.x0  == TestData_LHS[i].x0  &
                          v8_7.x1  == TestData_LHS[i].x1  &
                          v8_7.x2  == TestData_LHS[i].x2  &
                          v8_7.x3  == TestData_LHS[i].x3  &
                          v8_7.x4  == TestData_LHS[i].x4  &
                          v8_7.x5  == TestData_LHS[i].x5  &
                          v8_7.x6  == TestData_LHS[i].x6  &
                          v8_7.x7  == t_sbyte8.TestData_LHS[i].x0 &
                          v8_7.x8  == t_sbyte8.TestData_LHS[i].x1 &
                          v8_7.x9  == t_sbyte8.TestData_LHS[i].x2 &
                          v8_7.x10 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_7.x11 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_7.x12 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_7.x13 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_7.x14 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_7.x15 == TestData_LHS[i].x15 &
                          v8_7.x16 == TestData_LHS[i].x16 &
                          v8_7.x17 == TestData_LHS[i].x17 &
                          v8_7.x18 == TestData_LHS[i].x18 &
                          v8_7.x19 == TestData_LHS[i].x19 &
                          v8_7.x20 == TestData_LHS[i].x20 &
                          v8_7.x21 == TestData_LHS[i].x21 &
                          v8_7.x22 == TestData_LHS[i].x22 &
                          v8_7.x23 == TestData_LHS[i].x23 &
                          v8_7.x24 == TestData_LHS[i].x24 &
                          v8_7.x25 == TestData_LHS[i].x25 &
                          v8_7.x26 == TestData_LHS[i].x26 &
                          v8_7.x27 == TestData_LHS[i].x27 &
                          v8_7.x28 == TestData_LHS[i].x28 &
                          v8_7.x29 == TestData_LHS[i].x29 &
                          v8_7.x30 == TestData_LHS[i].x30 &
                          v8_7.x31 == TestData_LHS[i].x31;

                sbyte32 v8_8 = TestData_LHS[i];
                v8_8.v8_8 = t_sbyte8.TestData_LHS[i];
                result &= v8_8.x0  == TestData_LHS[i].x0  &
                          v8_8.x1  == TestData_LHS[i].x1  &
                          v8_8.x2  == TestData_LHS[i].x2  &
                          v8_8.x3  == TestData_LHS[i].x3  &
                          v8_8.x4  == TestData_LHS[i].x4  &
                          v8_8.x5  == TestData_LHS[i].x5  &
                          v8_8.x6  == TestData_LHS[i].x6  &
                          v8_8.x7  == TestData_LHS[i].x7  &
                          v8_8.x8  == t_sbyte8.TestData_LHS[i].x0 &
                          v8_8.x9  == t_sbyte8.TestData_LHS[i].x1 &
                          v8_8.x10 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_8.x11 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_8.x12 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_8.x13 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_8.x14 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_8.x15 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_8.x16 == TestData_LHS[i].x16 &
                          v8_8.x17 == TestData_LHS[i].x17 &
                          v8_8.x18 == TestData_LHS[i].x18 &
                          v8_8.x19 == TestData_LHS[i].x19 &
                          v8_8.x20 == TestData_LHS[i].x20 &
                          v8_8.x21 == TestData_LHS[i].x21 &
                          v8_8.x22 == TestData_LHS[i].x22 &
                          v8_8.x23 == TestData_LHS[i].x23 &
                          v8_8.x24 == TestData_LHS[i].x24 &
                          v8_8.x25 == TestData_LHS[i].x25 &
                          v8_8.x26 == TestData_LHS[i].x26 &
                          v8_8.x27 == TestData_LHS[i].x27 &
                          v8_8.x28 == TestData_LHS[i].x28 &
                          v8_8.x29 == TestData_LHS[i].x29 &
                          v8_8.x30 == TestData_LHS[i].x30 &
                          v8_8.x31 == TestData_LHS[i].x31;

                sbyte32 v8_9 = TestData_LHS[i];
                v8_9.v8_9 = t_sbyte8.TestData_LHS[i];
                result &= v8_9.x0  == TestData_LHS[i].x0  &
                          v8_9.x1  == TestData_LHS[i].x1  &
                          v8_9.x2  == TestData_LHS[i].x2  &
                          v8_9.x3  == TestData_LHS[i].x3  &
                          v8_9.x4  == TestData_LHS[i].x4  &
                          v8_9.x5  == TestData_LHS[i].x5  &
                          v8_9.x6  == TestData_LHS[i].x6  &
                          v8_9.x7  == TestData_LHS[i].x7  &
                          v8_9.x8  == TestData_LHS[i].x8  &
                          v8_9.x9  == t_sbyte8.TestData_LHS[i].x0 &
                          v8_9.x10 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_9.x11 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_9.x12 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_9.x13 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_9.x14 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_9.x15 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_9.x16 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_9.x17 == TestData_LHS[i].x17 &
                          v8_9.x18 == TestData_LHS[i].x18 &
                          v8_9.x19 == TestData_LHS[i].x19 &
                          v8_9.x20 == TestData_LHS[i].x20 &
                          v8_9.x21 == TestData_LHS[i].x21 &
                          v8_9.x22 == TestData_LHS[i].x22 &
                          v8_9.x23 == TestData_LHS[i].x23 &
                          v8_9.x24 == TestData_LHS[i].x24 &
                          v8_9.x25 == TestData_LHS[i].x25 &
                          v8_9.x26 == TestData_LHS[i].x26 &
                          v8_9.x27 == TestData_LHS[i].x27 &
                          v8_9.x28 == TestData_LHS[i].x28 &
                          v8_9.x29 == TestData_LHS[i].x29 &
                          v8_9.x30 == TestData_LHS[i].x30 &
                          v8_9.x31 == TestData_LHS[i].x31;

                sbyte32 v8_10 = TestData_LHS[i];
                v8_10.v8_10 = t_sbyte8.TestData_LHS[i];
                result &= v8_10.x0  == TestData_LHS[i].x0  &
                          v8_10.x1  == TestData_LHS[i].x1  &
                          v8_10.x2  == TestData_LHS[i].x2  &
                          v8_10.x3  == TestData_LHS[i].x3  &
                          v8_10.x4  == TestData_LHS[i].x4  &
                          v8_10.x5  == TestData_LHS[i].x5  &
                          v8_10.x6  == TestData_LHS[i].x6  &
                          v8_10.x7  == TestData_LHS[i].x7  &
                          v8_10.x8  == TestData_LHS[i].x8  &
                          v8_10.x9  == TestData_LHS[i].x9  &
                          v8_10.x10 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_10.x11 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_10.x12 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_10.x13 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_10.x14 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_10.x15 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_10.x16 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_10.x17 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_10.x18 == TestData_LHS[i].x18 &
                          v8_10.x19 == TestData_LHS[i].x19 &
                          v8_10.x20 == TestData_LHS[i].x20 &
                          v8_10.x21 == TestData_LHS[i].x21 &
                          v8_10.x22 == TestData_LHS[i].x22 &
                          v8_10.x23 == TestData_LHS[i].x23 &
                          v8_10.x24 == TestData_LHS[i].x24 &
                          v8_10.x25 == TestData_LHS[i].x25 &
                          v8_10.x26 == TestData_LHS[i].x26 &
                          v8_10.x27 == TestData_LHS[i].x27 &
                          v8_10.x28 == TestData_LHS[i].x28 &
                          v8_10.x29 == TestData_LHS[i].x29 &
                          v8_10.x30 == TestData_LHS[i].x30 &
                          v8_10.x31 == TestData_LHS[i].x31;

                sbyte32 v8_11 = TestData_LHS[i];
                v8_11.v8_11 = t_sbyte8.TestData_LHS[i];
                result &= v8_11.x0  == TestData_LHS[i].x0  &
                          v8_11.x1  == TestData_LHS[i].x1  &
                          v8_11.x2  == TestData_LHS[i].x2  &
                          v8_11.x3  == TestData_LHS[i].x3  &
                          v8_11.x4  == TestData_LHS[i].x4  &
                          v8_11.x5  == TestData_LHS[i].x5  &
                          v8_11.x6  == TestData_LHS[i].x6  &
                          v8_11.x7  == TestData_LHS[i].x7  &
                          v8_11.x8  == TestData_LHS[i].x8  &
                          v8_11.x9  == TestData_LHS[i].x9  &
                          v8_11.x10 == TestData_LHS[i].x10 &
                          v8_11.x11 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_11.x12 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_11.x13 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_11.x14 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_11.x15 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_11.x16 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_11.x17 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_11.x18 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_11.x19 == TestData_LHS[i].x19 &
                          v8_11.x20 == TestData_LHS[i].x20 &
                          v8_11.x21 == TestData_LHS[i].x21 &
                          v8_11.x22 == TestData_LHS[i].x22 &
                          v8_11.x23 == TestData_LHS[i].x23 &
                          v8_11.x24 == TestData_LHS[i].x24 &
                          v8_11.x25 == TestData_LHS[i].x25 &
                          v8_11.x26 == TestData_LHS[i].x26 &
                          v8_11.x27 == TestData_LHS[i].x27 &
                          v8_11.x28 == TestData_LHS[i].x28 &
                          v8_11.x29 == TestData_LHS[i].x29 &
                          v8_11.x30 == TestData_LHS[i].x30 &
                          v8_11.x31 == TestData_LHS[i].x31;

                sbyte32 v8_12 = TestData_LHS[i];
                v8_12.v8_12 = t_sbyte8.TestData_LHS[i];
                result &= v8_12.x0  == TestData_LHS[i].x0  &
                          v8_12.x1  == TestData_LHS[i].x1  &
                          v8_12.x2  == TestData_LHS[i].x2  &
                          v8_12.x3  == TestData_LHS[i].x3  &
                          v8_12.x4  == TestData_LHS[i].x4  &
                          v8_12.x5  == TestData_LHS[i].x5  &
                          v8_12.x6  == TestData_LHS[i].x6  &
                          v8_12.x7  == TestData_LHS[i].x7  &
                          v8_12.x8  == TestData_LHS[i].x8  &
                          v8_12.x9  == TestData_LHS[i].x9  &
                          v8_12.x10 == TestData_LHS[i].x10 &
                          v8_12.x11 == TestData_LHS[i].x11 &
                          v8_12.x12 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_12.x13 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_12.x14 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_12.x15 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_12.x16 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_12.x17 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_12.x18 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_12.x19 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_12.x20 == TestData_LHS[i].x20 &
                          v8_12.x21 == TestData_LHS[i].x21 &
                          v8_12.x22 == TestData_LHS[i].x22 &
                          v8_12.x23 == TestData_LHS[i].x23 &
                          v8_12.x24 == TestData_LHS[i].x24 &
                          v8_12.x25 == TestData_LHS[i].x25 &
                          v8_12.x26 == TestData_LHS[i].x26 &
                          v8_12.x27 == TestData_LHS[i].x27 &
                          v8_12.x28 == TestData_LHS[i].x28 &
                          v8_12.x29 == TestData_LHS[i].x29 &
                          v8_12.x30 == TestData_LHS[i].x30 &
                          v8_12.x31 == TestData_LHS[i].x31;

                sbyte32 v8_13 = TestData_LHS[i];
                v8_13.v8_13 = t_sbyte8.TestData_LHS[i];
                result &= v8_13.x0  == TestData_LHS[i].x0  &
                          v8_13.x1  == TestData_LHS[i].x1  &
                          v8_13.x2  == TestData_LHS[i].x2  &
                          v8_13.x3  == TestData_LHS[i].x3  &
                          v8_13.x4  == TestData_LHS[i].x4  &
                          v8_13.x5  == TestData_LHS[i].x5  &
                          v8_13.x6  == TestData_LHS[i].x6  &
                          v8_13.x7  == TestData_LHS[i].x7  &
                          v8_13.x8  == TestData_LHS[i].x8  &
                          v8_13.x9  == TestData_LHS[i].x9  &
                          v8_13.x10 == TestData_LHS[i].x10 &
                          v8_13.x11 == TestData_LHS[i].x11 &
                          v8_13.x12 == TestData_LHS[i].x12 &
                          v8_13.x13 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_13.x14 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_13.x15 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_13.x16 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_13.x17 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_13.x18 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_13.x19 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_13.x20 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_13.x21 == TestData_LHS[i].x21 &
                          v8_13.x22 == TestData_LHS[i].x22 &
                          v8_13.x23 == TestData_LHS[i].x23 &
                          v8_13.x24 == TestData_LHS[i].x24 &
                          v8_13.x25 == TestData_LHS[i].x25 &
                          v8_13.x26 == TestData_LHS[i].x26 &
                          v8_13.x27 == TestData_LHS[i].x27 &
                          v8_13.x28 == TestData_LHS[i].x28 &
                          v8_13.x29 == TestData_LHS[i].x29 &
                          v8_13.x30 == TestData_LHS[i].x30 &
                          v8_13.x31 == TestData_LHS[i].x31;

                sbyte32 v8_14 = TestData_LHS[i];
                v8_14.v8_14 = t_sbyte8.TestData_LHS[i];
                result &= v8_14.x0  == TestData_LHS[i].x0  &
                          v8_14.x1  == TestData_LHS[i].x1  &
                          v8_14.x2  == TestData_LHS[i].x2  &
                          v8_14.x3  == TestData_LHS[i].x3  &
                          v8_14.x4  == TestData_LHS[i].x4  &
                          v8_14.x5  == TestData_LHS[i].x5  &
                          v8_14.x6  == TestData_LHS[i].x6  &
                          v8_14.x7  == TestData_LHS[i].x7  &
                          v8_14.x8  == TestData_LHS[i].x8  &
                          v8_14.x9  == TestData_LHS[i].x9  &
                          v8_14.x10 == TestData_LHS[i].x10 &
                          v8_14.x11 == TestData_LHS[i].x11 &
                          v8_14.x12 == TestData_LHS[i].x12 &
                          v8_14.x13 == TestData_LHS[i].x13 &
                          v8_14.x14 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_14.x15 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_14.x16 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_14.x17 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_14.x18 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_14.x19 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_14.x20 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_14.x21 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_14.x22 == TestData_LHS[i].x22 &
                          v8_14.x23 == TestData_LHS[i].x23 &
                          v8_14.x24 == TestData_LHS[i].x24 &
                          v8_14.x25 == TestData_LHS[i].x25 &
                          v8_14.x26 == TestData_LHS[i].x26 &
                          v8_14.x27 == TestData_LHS[i].x27 &
                          v8_14.x28 == TestData_LHS[i].x28 &
                          v8_14.x29 == TestData_LHS[i].x29 &
                          v8_14.x30 == TestData_LHS[i].x30 &
                          v8_14.x31 == TestData_LHS[i].x31;

                sbyte32 v8_15 = TestData_LHS[i];
                v8_15.v8_15 = t_sbyte8.TestData_LHS[i];
                result &= v8_15.x0  == TestData_LHS[i].x0  &
                          v8_15.x1  == TestData_LHS[i].x1  &
                          v8_15.x2  == TestData_LHS[i].x2  &
                          v8_15.x3  == TestData_LHS[i].x3  &
                          v8_15.x4  == TestData_LHS[i].x4  &
                          v8_15.x5  == TestData_LHS[i].x5  &
                          v8_15.x6  == TestData_LHS[i].x6  &
                          v8_15.x7  == TestData_LHS[i].x7  &
                          v8_15.x8  == TestData_LHS[i].x8  &
                          v8_15.x9  == TestData_LHS[i].x9  &
                          v8_15.x10 == TestData_LHS[i].x10 &
                          v8_15.x11 == TestData_LHS[i].x11 &
                          v8_15.x12 == TestData_LHS[i].x12 &
                          v8_15.x13 == TestData_LHS[i].x13 &
                          v8_15.x14 == TestData_LHS[i].x14 &
                          v8_15.x15 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_15.x16 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_15.x17 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_15.x18 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_15.x19 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_15.x20 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_15.x21 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_15.x22 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_15.x23 == TestData_LHS[i].x23 &
                          v8_15.x24 == TestData_LHS[i].x24 &
                          v8_15.x25 == TestData_LHS[i].x25 &
                          v8_15.x26 == TestData_LHS[i].x26 &
                          v8_15.x27 == TestData_LHS[i].x27 &
                          v8_15.x28 == TestData_LHS[i].x28 &
                          v8_15.x29 == TestData_LHS[i].x29 &
                          v8_15.x30 == TestData_LHS[i].x30 &
                          v8_15.x31 == TestData_LHS[i].x31;

                sbyte32 v8_16 = TestData_LHS[i];
                v8_16.v8_16 = t_sbyte8.TestData_LHS[i];
                result &= v8_16.x0  == TestData_LHS[i].x0  &
                          v8_16.x1  == TestData_LHS[i].x1  &
                          v8_16.x2  == TestData_LHS[i].x2  &
                          v8_16.x3  == TestData_LHS[i].x3  &
                          v8_16.x4  == TestData_LHS[i].x4  &
                          v8_16.x5  == TestData_LHS[i].x5  &
                          v8_16.x6  == TestData_LHS[i].x6  &
                          v8_16.x7  == TestData_LHS[i].x7  &
                          v8_16.x8  == TestData_LHS[i].x8  &
                          v8_16.x9  == TestData_LHS[i].x9  &
                          v8_16.x10 == TestData_LHS[i].x10 &
                          v8_16.x11 == TestData_LHS[i].x11 &
                          v8_16.x12 == TestData_LHS[i].x12 &
                          v8_16.x13 == TestData_LHS[i].x13 &
                          v8_16.x14 == TestData_LHS[i].x14 &
                          v8_16.x15 == TestData_LHS[i].x15 &
                          v8_16.x16 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_16.x17 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_16.x18 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_16.x19 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_16.x20 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_16.x21 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_16.x22 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_16.x23 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_16.x24 == TestData_LHS[i].x24 &
                          v8_16.x25 == TestData_LHS[i].x25 &
                          v8_16.x26 == TestData_LHS[i].x26 &
                          v8_16.x27 == TestData_LHS[i].x27 &
                          v8_16.x28 == TestData_LHS[i].x28 &
                          v8_16.x29 == TestData_LHS[i].x29 &
                          v8_16.x30 == TestData_LHS[i].x30 &
                          v8_16.x31 == TestData_LHS[i].x31;

                sbyte32 v8_17 = TestData_LHS[i];
                v8_17.v8_17 = t_sbyte8.TestData_LHS[i];
                result &= v8_17.x0  == TestData_LHS[i].x0  &
                          v8_17.x1  == TestData_LHS[i].x1  &
                          v8_17.x2  == TestData_LHS[i].x2  &
                          v8_17.x3  == TestData_LHS[i].x3  &
                          v8_17.x4  == TestData_LHS[i].x4  &
                          v8_17.x5  == TestData_LHS[i].x5  &
                          v8_17.x6  == TestData_LHS[i].x6  &
                          v8_17.x7  == TestData_LHS[i].x7  &
                          v8_17.x8  == TestData_LHS[i].x8  &
                          v8_17.x9  == TestData_LHS[i].x9  &
                          v8_17.x10 == TestData_LHS[i].x10 &
                          v8_17.x11 == TestData_LHS[i].x11 &
                          v8_17.x12 == TestData_LHS[i].x12 &
                          v8_17.x13 == TestData_LHS[i].x13 &
                          v8_17.x14 == TestData_LHS[i].x14 &
                          v8_17.x15 == TestData_LHS[i].x15 &
                          v8_17.x16 == TestData_LHS[i].x16 &
                          v8_17.x17 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_17.x18 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_17.x19 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_17.x20 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_17.x21 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_17.x22 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_17.x23 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_17.x24 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_17.x25 == TestData_LHS[i].x25 &
                          v8_17.x26 == TestData_LHS[i].x26 &
                          v8_17.x27 == TestData_LHS[i].x27 &
                          v8_17.x28 == TestData_LHS[i].x28 &
                          v8_17.x29 == TestData_LHS[i].x29 &
                          v8_17.x30 == TestData_LHS[i].x30 &
                          v8_17.x31 == TestData_LHS[i].x31;

                sbyte32 v8_18 = TestData_LHS[i];
                v8_18.v8_18 = t_sbyte8.TestData_LHS[i];
                result &= v8_18.x0  == TestData_LHS[i].x0  &
                          v8_18.x1  == TestData_LHS[i].x1  &
                          v8_18.x2  == TestData_LHS[i].x2  &
                          v8_18.x3  == TestData_LHS[i].x3  &
                          v8_18.x4  == TestData_LHS[i].x4  &
                          v8_18.x5  == TestData_LHS[i].x5  &
                          v8_18.x6  == TestData_LHS[i].x6  &
                          v8_18.x7  == TestData_LHS[i].x7  &
                          v8_18.x8  == TestData_LHS[i].x8  &
                          v8_18.x9  == TestData_LHS[i].x9  &
                          v8_18.x10 == TestData_LHS[i].x10 &
                          v8_18.x11 == TestData_LHS[i].x11 &
                          v8_18.x12 == TestData_LHS[i].x12 &
                          v8_18.x13 == TestData_LHS[i].x13 &
                          v8_18.x14 == TestData_LHS[i].x14 &
                          v8_18.x15 == TestData_LHS[i].x15 &
                          v8_18.x16 == TestData_LHS[i].x16 &
                          v8_18.x17 == TestData_LHS[i].x17 &
                          v8_18.x18 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_18.x19 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_18.x20 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_18.x21 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_18.x22 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_18.x23 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_18.x24 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_18.x25 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_18.x26 == TestData_LHS[i].x26 &
                          v8_18.x27 == TestData_LHS[i].x27 &
                          v8_18.x28 == TestData_LHS[i].x28 &
                          v8_18.x29 == TestData_LHS[i].x29 &
                          v8_18.x30 == TestData_LHS[i].x30 &
                          v8_18.x31 == TestData_LHS[i].x31;

                sbyte32 v8_19 = TestData_LHS[i];
                v8_19.v8_19 = t_sbyte8.TestData_LHS[i];
                result &= v8_19.x0  == TestData_LHS[i].x0  &
                          v8_19.x1  == TestData_LHS[i].x1  &
                          v8_19.x2  == TestData_LHS[i].x2  &
                          v8_19.x3  == TestData_LHS[i].x3  &
                          v8_19.x4  == TestData_LHS[i].x4  &
                          v8_19.x5  == TestData_LHS[i].x5  &
                          v8_19.x6  == TestData_LHS[i].x6  &
                          v8_19.x7  == TestData_LHS[i].x7  &
                          v8_19.x8  == TestData_LHS[i].x8  &
                          v8_19.x9  == TestData_LHS[i].x9  &
                          v8_19.x10 == TestData_LHS[i].x10 &
                          v8_19.x11 == TestData_LHS[i].x11 &
                          v8_19.x12 == TestData_LHS[i].x12 &
                          v8_19.x13 == TestData_LHS[i].x13 &
                          v8_19.x14 == TestData_LHS[i].x14 &
                          v8_19.x15 == TestData_LHS[i].x15 &
                          v8_19.x16 == TestData_LHS[i].x16 &
                          v8_19.x17 == TestData_LHS[i].x17 &
                          v8_19.x18 == TestData_LHS[i].x18 &
                          v8_19.x19 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_19.x20 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_19.x21 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_19.x22 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_19.x23 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_19.x24 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_19.x25 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_19.x26 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_19.x27 == TestData_LHS[i].x27 &
                          v8_19.x28 == TestData_LHS[i].x28 &
                          v8_19.x29 == TestData_LHS[i].x29 &
                          v8_19.x30 == TestData_LHS[i].x30 &
                          v8_19.x31 == TestData_LHS[i].x31;

                sbyte32 v8_20 = TestData_LHS[i];
                v8_20.v8_20 = t_sbyte8.TestData_LHS[i];
                result &= v8_20.x0  == TestData_LHS[i].x0  &
                          v8_20.x1  == TestData_LHS[i].x1  &
                          v8_20.x2  == TestData_LHS[i].x2  &
                          v8_20.x3  == TestData_LHS[i].x3  &
                          v8_20.x4  == TestData_LHS[i].x4  &
                          v8_20.x5  == TestData_LHS[i].x5  &
                          v8_20.x6  == TestData_LHS[i].x6  &
                          v8_20.x7  == TestData_LHS[i].x7  &
                          v8_20.x8  == TestData_LHS[i].x8  &
                          v8_20.x9  == TestData_LHS[i].x9  &
                          v8_20.x10 == TestData_LHS[i].x10 &
                          v8_20.x11 == TestData_LHS[i].x11 &
                          v8_20.x12 == TestData_LHS[i].x12 &
                          v8_20.x13 == TestData_LHS[i].x13 &
                          v8_20.x14 == TestData_LHS[i].x14 &
                          v8_20.x15 == TestData_LHS[i].x15 &
                          v8_20.x16 == TestData_LHS[i].x16 &
                          v8_20.x17 == TestData_LHS[i].x17 &
                          v8_20.x18 == TestData_LHS[i].x18 &
                          v8_20.x19 == TestData_LHS[i].x19 &
                          v8_20.x20 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_20.x21 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_20.x22 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_20.x23 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_20.x24 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_20.x25 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_20.x26 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_20.x27 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_20.x28 == TestData_LHS[i].x28 &
                          v8_20.x29 == TestData_LHS[i].x29 &
                          v8_20.x30 == TestData_LHS[i].x30 &
                          v8_20.x31 == TestData_LHS[i].x31;

                sbyte32 v8_21 = TestData_LHS[i];
                v8_21.v8_21 = t_sbyte8.TestData_LHS[i];
                result &= v8_21.x0  == TestData_LHS[i].x0  &
                          v8_21.x1  == TestData_LHS[i].x1  &
                          v8_21.x2  == TestData_LHS[i].x2  &
                          v8_21.x3  == TestData_LHS[i].x3  &
                          v8_21.x4  == TestData_LHS[i].x4  &
                          v8_21.x5  == TestData_LHS[i].x5  &
                          v8_21.x6  == TestData_LHS[i].x6  &
                          v8_21.x7  == TestData_LHS[i].x7  &
                          v8_21.x8  == TestData_LHS[i].x8  &
                          v8_21.x9  == TestData_LHS[i].x9  &
                          v8_21.x10 == TestData_LHS[i].x10 &
                          v8_21.x11 == TestData_LHS[i].x11 &
                          v8_21.x12 == TestData_LHS[i].x12 &
                          v8_21.x13 == TestData_LHS[i].x13 &
                          v8_21.x14 == TestData_LHS[i].x14 &
                          v8_21.x15 == TestData_LHS[i].x15 &
                          v8_21.x16 == TestData_LHS[i].x16 &
                          v8_21.x17 == TestData_LHS[i].x17 &
                          v8_21.x18 == TestData_LHS[i].x18 &
                          v8_21.x19 == TestData_LHS[i].x19 &
                          v8_21.x20 == TestData_LHS[i].x20 &
                          v8_21.x21 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_21.x22 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_21.x23 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_21.x24 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_21.x25 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_21.x26 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_21.x27 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_21.x28 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_21.x29 == TestData_LHS[i].x29 &
                          v8_21.x30 == TestData_LHS[i].x30 &
                          v8_21.x31 == TestData_LHS[i].x31;

                sbyte32 v8_22 = TestData_LHS[i];
                v8_22.v8_22 = t_sbyte8.TestData_LHS[i];
                result &= v8_22.x0  == TestData_LHS[i].x0  &
                          v8_22.x1  == TestData_LHS[i].x1  &
                          v8_22.x2  == TestData_LHS[i].x2  &
                          v8_22.x3  == TestData_LHS[i].x3  &
                          v8_22.x4  == TestData_LHS[i].x4  &
                          v8_22.x5  == TestData_LHS[i].x5  &
                          v8_22.x6  == TestData_LHS[i].x6  &
                          v8_22.x7  == TestData_LHS[i].x7  &
                          v8_22.x8  == TestData_LHS[i].x8  &
                          v8_22.x9  == TestData_LHS[i].x9  &
                          v8_22.x10 == TestData_LHS[i].x10 &
                          v8_22.x11 == TestData_LHS[i].x11 &
                          v8_22.x12 == TestData_LHS[i].x12 &
                          v8_22.x13 == TestData_LHS[i].x13 &
                          v8_22.x14 == TestData_LHS[i].x14 &
                          v8_22.x15 == TestData_LHS[i].x15 &
                          v8_22.x16 == TestData_LHS[i].x16 &
                          v8_22.x17 == TestData_LHS[i].x17 &
                          v8_22.x18 == TestData_LHS[i].x18 &
                          v8_22.x19 == TestData_LHS[i].x19 &
                          v8_22.x20 == TestData_LHS[i].x20 &
                          v8_22.x21 == TestData_LHS[i].x21 &
                          v8_22.x22 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_22.x23 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_22.x24 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_22.x25 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_22.x26 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_22.x27 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_22.x28 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_22.x29 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_22.x30 == TestData_LHS[i].x30 &
                          v8_22.x31 == TestData_LHS[i].x31;

                sbyte32 v8_23 = TestData_LHS[i];
                v8_23.v8_23 = t_sbyte8.TestData_LHS[i];
                result &= v8_23.x0  == TestData_LHS[i].x0  &
                          v8_23.x1  == TestData_LHS[i].x1  &
                          v8_23.x2  == TestData_LHS[i].x2  &
                          v8_23.x3  == TestData_LHS[i].x3  &
                          v8_23.x4  == TestData_LHS[i].x4  &
                          v8_23.x5  == TestData_LHS[i].x5  &
                          v8_23.x6  == TestData_LHS[i].x6  &
                          v8_23.x7  == TestData_LHS[i].x7  &
                          v8_23.x8  == TestData_LHS[i].x8  &
                          v8_23.x9  == TestData_LHS[i].x9  &
                          v8_23.x10 == TestData_LHS[i].x10 &
                          v8_23.x11 == TestData_LHS[i].x11 &
                          v8_23.x12 == TestData_LHS[i].x12 &
                          v8_23.x13 == TestData_LHS[i].x13 &
                          v8_23.x14 == TestData_LHS[i].x14 &
                          v8_23.x15 == TestData_LHS[i].x15 &
                          v8_23.x16 == TestData_LHS[i].x16 &
                          v8_23.x17 == TestData_LHS[i].x17 &
                          v8_23.x18 == TestData_LHS[i].x18 &
                          v8_23.x19 == TestData_LHS[i].x19 &
                          v8_23.x20 == TestData_LHS[i].x20 &
                          v8_23.x21 == TestData_LHS[i].x21 &
                          v8_23.x22 == TestData_LHS[i].x22 &
                          v8_23.x23 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_23.x24 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_23.x25 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_23.x26 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_23.x27 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_23.x28 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_23.x29 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_23.x30 == t_sbyte8.TestData_LHS[i].x7 &
                          v8_23.x31 == TestData_LHS[i].x31;

                sbyte32 v8_24 = TestData_LHS[i];
                v8_24.v8_24 = t_sbyte8.TestData_LHS[i];
                result &= v8_24.x0  == TestData_LHS[i].x0  &
                          v8_24.x1  == TestData_LHS[i].x1  &
                          v8_24.x2  == TestData_LHS[i].x2  &
                          v8_24.x3  == TestData_LHS[i].x3  &
                          v8_24.x4  == TestData_LHS[i].x4  &
                          v8_24.x5  == TestData_LHS[i].x5  &
                          v8_24.x6  == TestData_LHS[i].x6  &
                          v8_24.x7  == TestData_LHS[i].x7  &
                          v8_24.x8  == TestData_LHS[i].x8  &
                          v8_24.x9  == TestData_LHS[i].x9  &
                          v8_24.x10 == TestData_LHS[i].x10 &
                          v8_24.x11 == TestData_LHS[i].x11 &
                          v8_24.x12 == TestData_LHS[i].x12 &
                          v8_24.x13 == TestData_LHS[i].x13 &
                          v8_24.x14 == TestData_LHS[i].x14 &
                          v8_24.x15 == TestData_LHS[i].x15 &
                          v8_24.x16 == TestData_LHS[i].x16 &
                          v8_24.x17 == TestData_LHS[i].x17 &
                          v8_24.x18 == TestData_LHS[i].x18 &
                          v8_24.x19 == TestData_LHS[i].x19 &
                          v8_24.x20 == TestData_LHS[i].x20 &
                          v8_24.x21 == TestData_LHS[i].x21 &
                          v8_24.x22 == TestData_LHS[i].x22 &
                          v8_24.x23 == TestData_LHS[i].x23 &
                          v8_24.x24 == t_sbyte8.TestData_LHS[i].x0 &
                          v8_24.x25 == t_sbyte8.TestData_LHS[i].x1 &
                          v8_24.x26 == t_sbyte8.TestData_LHS[i].x2 &
                          v8_24.x27 == t_sbyte8.TestData_LHS[i].x3 &
                          v8_24.x28 == t_sbyte8.TestData_LHS[i].x4 &
                          v8_24.x29 == t_sbyte8.TestData_LHS[i].x5 &
                          v8_24.x30 == t_sbyte8.TestData_LHS[i].x6 &
                          v8_24.x31 == t_sbyte8.TestData_LHS[i].x7;



                sbyte32 v4_0 = TestData_LHS[i];
                v4_0.v4_0 = t_sbyte4.TestData_LHS[i];
                result &= v4_0.x0  == t_sbyte4.TestData_LHS[i].x  &
                          v4_0.x1  == t_sbyte4.TestData_LHS[i].y  &
                          v4_0.x2  == t_sbyte4.TestData_LHS[i].z  &
                          v4_0.x3  == t_sbyte4.TestData_LHS[i].w  &
                          v4_0.x4  == TestData_LHS[i].x4  &
                          v4_0.x5  == TestData_LHS[i].x5  &
                          v4_0.x6  == TestData_LHS[i].x6  &
                          v4_0.x7  == TestData_LHS[i].x7  &
                          v4_0.x8  == TestData_LHS[i].x8  &
                          v4_0.x9  == TestData_LHS[i].x9  &
                          v4_0.x10 == TestData_LHS[i].x10 &
                          v4_0.x11 == TestData_LHS[i].x11 &
                          v4_0.x12 == TestData_LHS[i].x12 &
                          v4_0.x13 == TestData_LHS[i].x13 &
                          v4_0.x14 == TestData_LHS[i].x14 &
                          v4_0.x15 == TestData_LHS[i].x15 &
                          v4_0.x16 == TestData_LHS[i].x16 &
                          v4_0.x17 == TestData_LHS[i].x17 &
                          v4_0.x18 == TestData_LHS[i].x18 &
                          v4_0.x19 == TestData_LHS[i].x19 &
                          v4_0.x20 == TestData_LHS[i].x20 &
                          v4_0.x21 == TestData_LHS[i].x21 &
                          v4_0.x22 == TestData_LHS[i].x22 &
                          v4_0.x23 == TestData_LHS[i].x23 &
                          v4_0.x24 == TestData_LHS[i].x24 &
                          v4_0.x25 == TestData_LHS[i].x25 &
                          v4_0.x26 == TestData_LHS[i].x26 &
                          v4_0.x27 == TestData_LHS[i].x27 &
                          v4_0.x28 == TestData_LHS[i].x28 &
                          v4_0.x29 == TestData_LHS[i].x29 &
                          v4_0.x30 == TestData_LHS[i].x30 &
                          v4_0.x31 == TestData_LHS[i].x31;

                sbyte32 v4_1 = TestData_LHS[i];
                v4_1.v4_1 = t_sbyte4.TestData_LHS[i];
                result &= v4_1.x0  == TestData_LHS[i].x0  &
                          v4_1.x1  == t_sbyte4.TestData_LHS[i].x  &
                          v4_1.x2  == t_sbyte4.TestData_LHS[i].y  &
                          v4_1.x3  == t_sbyte4.TestData_LHS[i].z  &
                          v4_1.x4  == t_sbyte4.TestData_LHS[i].w &
                          v4_1.x5  == TestData_LHS[i].x5  &
                          v4_1.x6  == TestData_LHS[i].x6  &
                          v4_1.x7  == TestData_LHS[i].x7  &
                          v4_1.x8  == TestData_LHS[i].x8  &
                          v4_1.x9  == TestData_LHS[i].x9  &
                          v4_1.x10 == TestData_LHS[i].x10 &
                          v4_1.x11 == TestData_LHS[i].x11 &
                          v4_1.x12 == TestData_LHS[i].x12 &
                          v4_1.x13 == TestData_LHS[i].x13 &
                          v4_1.x14 == TestData_LHS[i].x14 &
                          v4_1.x15 == TestData_LHS[i].x15 &
                          v4_1.x16 == TestData_LHS[i].x16 &
                          v4_1.x17 == TestData_LHS[i].x17 &
                          v4_1.x18 == TestData_LHS[i].x18 &
                          v4_1.x19 == TestData_LHS[i].x19 &
                          v4_1.x20 == TestData_LHS[i].x20 &
                          v4_1.x21 == TestData_LHS[i].x21 &
                          v4_1.x22 == TestData_LHS[i].x22 &
                          v4_1.x23 == TestData_LHS[i].x23 &
                          v4_1.x24 == TestData_LHS[i].x24 &
                          v4_1.x25 == TestData_LHS[i].x25 &
                          v4_1.x26 == TestData_LHS[i].x26 &
                          v4_1.x27 == TestData_LHS[i].x27 &
                          v4_1.x28 == TestData_LHS[i].x28 &
                          v4_1.x29 == TestData_LHS[i].x29 &
                          v4_1.x30 == TestData_LHS[i].x30 &
                          v4_1.x31 == TestData_LHS[i].x31;

                sbyte32 v4_2 = TestData_LHS[i];
                v4_2.v4_2 = t_sbyte4.TestData_LHS[i];
                result &= v4_2.x0  == TestData_LHS[i].x0  &
                          v4_2.x1  == TestData_LHS[i].x1  &
                          v4_2.x2  == t_sbyte4.TestData_LHS[i].x  &
                          v4_2.x3  == t_sbyte4.TestData_LHS[i].y  &
                          v4_2.x4  == t_sbyte4.TestData_LHS[i].z  &
                          v4_2.x5  == t_sbyte4.TestData_LHS[i].w &
                          v4_2.x6  == TestData_LHS[i].x6  &
                          v4_2.x7  == TestData_LHS[i].x7  &
                          v4_2.x8  == TestData_LHS[i].x8  &
                          v4_2.x9  == TestData_LHS[i].x9  &
                          v4_2.x10 == TestData_LHS[i].x10 &
                          v4_2.x11 == TestData_LHS[i].x11 &
                          v4_2.x12 == TestData_LHS[i].x12 &
                          v4_2.x13 == TestData_LHS[i].x13 &
                          v4_2.x14 == TestData_LHS[i].x14 &
                          v4_2.x15 == TestData_LHS[i].x15 &
                          v4_2.x16 == TestData_LHS[i].x16 &
                          v4_2.x17 == TestData_LHS[i].x17 &
                          v4_2.x18 == TestData_LHS[i].x18 &
                          v4_2.x19 == TestData_LHS[i].x19 &
                          v4_2.x20 == TestData_LHS[i].x20 &
                          v4_2.x21 == TestData_LHS[i].x21 &
                          v4_2.x22 == TestData_LHS[i].x22 &
                          v4_2.x23 == TestData_LHS[i].x23 &
                          v4_2.x24 == TestData_LHS[i].x24 &
                          v4_2.x25 == TestData_LHS[i].x25 &
                          v4_2.x26 == TestData_LHS[i].x26 &
                          v4_2.x27 == TestData_LHS[i].x27 &
                          v4_2.x28 == TestData_LHS[i].x28 &
                          v4_2.x29 == TestData_LHS[i].x29 &
                          v4_2.x30 == TestData_LHS[i].x30 &
                          v4_2.x31 == TestData_LHS[i].x31;

                sbyte32 v4_3 = TestData_LHS[i];
                v4_3.v4_3 = t_sbyte4.TestData_LHS[i];
                result &= v4_3.x0  == TestData_LHS[i].x0  &
                          v4_3.x1  == TestData_LHS[i].x1  &
                          v4_3.x2  == TestData_LHS[i].x2  &
                          v4_3.x3  == t_sbyte4.TestData_LHS[i].x  &
                          v4_3.x4  == t_sbyte4.TestData_LHS[i].y  &
                          v4_3.x5  == t_sbyte4.TestData_LHS[i].z  &
                          v4_3.x6  == t_sbyte4.TestData_LHS[i].w &
                          v4_3.x7  == TestData_LHS[i].x7  &
                          v4_3.x8  == TestData_LHS[i].x8  &
                          v4_3.x9  == TestData_LHS[i].x9  &
                          v4_3.x10 == TestData_LHS[i].x10 &
                          v4_3.x11 == TestData_LHS[i].x11 &
                          v4_3.x12 == TestData_LHS[i].x12 &
                          v4_3.x13 == TestData_LHS[i].x13 &
                          v4_3.x14 == TestData_LHS[i].x14 &
                          v4_3.x15 == TestData_LHS[i].x15 &
                          v4_3.x16 == TestData_LHS[i].x16 &
                          v4_3.x17 == TestData_LHS[i].x17 &
                          v4_3.x18 == TestData_LHS[i].x18 &
                          v4_3.x19 == TestData_LHS[i].x19 &
                          v4_3.x20 == TestData_LHS[i].x20 &
                          v4_3.x21 == TestData_LHS[i].x21 &
                          v4_3.x22 == TestData_LHS[i].x22 &
                          v4_3.x23 == TestData_LHS[i].x23 &
                          v4_3.x24 == TestData_LHS[i].x24 &
                          v4_3.x25 == TestData_LHS[i].x25 &
                          v4_3.x26 == TestData_LHS[i].x26 &
                          v4_3.x27 == TestData_LHS[i].x27 &
                          v4_3.x28 == TestData_LHS[i].x28 &
                          v4_3.x29 == TestData_LHS[i].x29 &
                          v4_3.x30 == TestData_LHS[i].x30 &
                          v4_3.x31 == TestData_LHS[i].x31;

                sbyte32 v4_4 = TestData_LHS[i];
                v4_4.v4_4 = t_sbyte4.TestData_LHS[i];
                result &= v4_4.x0  == TestData_LHS[i].x0  &
                          v4_4.x1  == TestData_LHS[i].x1  &
                          v4_4.x2  == TestData_LHS[i].x2  &
                          v4_4.x3  == TestData_LHS[i].x3  &
                          v4_4.x4  == t_sbyte4.TestData_LHS[i].x  &
                          v4_4.x5  == t_sbyte4.TestData_LHS[i].y  &
                          v4_4.x6  == t_sbyte4.TestData_LHS[i].z  &
                          v4_4.x7  == t_sbyte4.TestData_LHS[i].w &
                          v4_4.x8  == TestData_LHS[i].x8  &
                          v4_4.x9  == TestData_LHS[i].x9  &
                          v4_4.x10 == TestData_LHS[i].x10 &
                          v4_4.x11 == TestData_LHS[i].x11 &
                          v4_4.x12 == TestData_LHS[i].x12 &
                          v4_4.x13 == TestData_LHS[i].x13 &
                          v4_4.x14 == TestData_LHS[i].x14 &
                          v4_4.x15 == TestData_LHS[i].x15 &
                          v4_4.x16 == TestData_LHS[i].x16 &
                          v4_4.x17 == TestData_LHS[i].x17 &
                          v4_4.x18 == TestData_LHS[i].x18 &
                          v4_4.x19 == TestData_LHS[i].x19 &
                          v4_4.x20 == TestData_LHS[i].x20 &
                          v4_4.x21 == TestData_LHS[i].x21 &
                          v4_4.x22 == TestData_LHS[i].x22 &
                          v4_4.x23 == TestData_LHS[i].x23 &
                          v4_4.x24 == TestData_LHS[i].x24 &
                          v4_4.x25 == TestData_LHS[i].x25 &
                          v4_4.x26 == TestData_LHS[i].x26 &
                          v4_4.x27 == TestData_LHS[i].x27 &
                          v4_4.x28 == TestData_LHS[i].x28 &
                          v4_4.x29 == TestData_LHS[i].x29 &
                          v4_4.x30 == TestData_LHS[i].x30 &
                          v4_4.x31 == TestData_LHS[i].x31;

                sbyte32 v4_5 = TestData_LHS[i];
                v4_5.v4_5 = t_sbyte4.TestData_LHS[i];
                result &= v4_5.x0  == TestData_LHS[i].x0  &
                          v4_5.x1  == TestData_LHS[i].x1  &
                          v4_5.x2  == TestData_LHS[i].x2  &
                          v4_5.x3  == TestData_LHS[i].x3  &
                          v4_5.x4  == TestData_LHS[i].x4  &
                          v4_5.x5  == t_sbyte4.TestData_LHS[i].x  &
                          v4_5.x6  == t_sbyte4.TestData_LHS[i].y  &
                          v4_5.x7  == t_sbyte4.TestData_LHS[i].z  &
                          v4_5.x8  == t_sbyte4.TestData_LHS[i].w &
                          v4_5.x9  == TestData_LHS[i].x9  &
                          v4_5.x10 == TestData_LHS[i].x10 &
                          v4_5.x11 == TestData_LHS[i].x11 &
                          v4_5.x12 == TestData_LHS[i].x12 &
                          v4_5.x13 == TestData_LHS[i].x13 &
                          v4_5.x14 == TestData_LHS[i].x14 &
                          v4_5.x15 == TestData_LHS[i].x15 &
                          v4_5.x16 == TestData_LHS[i].x16 &
                          v4_5.x17 == TestData_LHS[i].x17 &
                          v4_5.x18 == TestData_LHS[i].x18 &
                          v4_5.x19 == TestData_LHS[i].x19 &
                          v4_5.x20 == TestData_LHS[i].x20 &
                          v4_5.x21 == TestData_LHS[i].x21 &
                          v4_5.x22 == TestData_LHS[i].x22 &
                          v4_5.x23 == TestData_LHS[i].x23 &
                          v4_5.x24 == TestData_LHS[i].x24 &
                          v4_5.x25 == TestData_LHS[i].x25 &
                          v4_5.x26 == TestData_LHS[i].x26 &
                          v4_5.x27 == TestData_LHS[i].x27 &
                          v4_5.x28 == TestData_LHS[i].x28 &
                          v4_5.x29 == TestData_LHS[i].x29 &
                          v4_5.x30 == TestData_LHS[i].x30 &
                          v4_5.x31 == TestData_LHS[i].x31;

                sbyte32 v4_6 = TestData_LHS[i];
                v4_6.v4_6 = t_sbyte4.TestData_LHS[i];
                result &= v4_6.x0  == TestData_LHS[i].x0  &
                          v4_6.x1  == TestData_LHS[i].x1  &
                          v4_6.x2  == TestData_LHS[i].x2  &
                          v4_6.x3  == TestData_LHS[i].x3  &
                          v4_6.x4  == TestData_LHS[i].x4  &
                          v4_6.x5  == TestData_LHS[i].x5  &
                          v4_6.x6  == t_sbyte4.TestData_LHS[i].x  &
                          v4_6.x7  == t_sbyte4.TestData_LHS[i].y  &
                          v4_6.x8  == t_sbyte4.TestData_LHS[i].z  &
                          v4_6.x9  == t_sbyte4.TestData_LHS[i].w &
                          v4_6.x10 == TestData_LHS[i].x10 &
                          v4_6.x11 == TestData_LHS[i].x11 &
                          v4_6.x12 == TestData_LHS[i].x12 &
                          v4_6.x13 == TestData_LHS[i].x13 &
                          v4_6.x14 == TestData_LHS[i].x14 &
                          v4_6.x15 == TestData_LHS[i].x15 &
                          v4_6.x16 == TestData_LHS[i].x16 &
                          v4_6.x17 == TestData_LHS[i].x17 &
                          v4_6.x18 == TestData_LHS[i].x18 &
                          v4_6.x19 == TestData_LHS[i].x19 &
                          v4_6.x20 == TestData_LHS[i].x20 &
                          v4_6.x21 == TestData_LHS[i].x21 &
                          v4_6.x22 == TestData_LHS[i].x22 &
                          v4_6.x23 == TestData_LHS[i].x23 &
                          v4_6.x24 == TestData_LHS[i].x24 &
                          v4_6.x25 == TestData_LHS[i].x25 &
                          v4_6.x26 == TestData_LHS[i].x26 &
                          v4_6.x27 == TestData_LHS[i].x27 &
                          v4_6.x28 == TestData_LHS[i].x28 &
                          v4_6.x29 == TestData_LHS[i].x29 &
                          v4_6.x30 == TestData_LHS[i].x30 &
                          v4_6.x31 == TestData_LHS[i].x31;

                sbyte32 v4_7 = TestData_LHS[i];
                v4_7.v4_7 = t_sbyte4.TestData_LHS[i];
                result &= v4_7.x0  == TestData_LHS[i].x0  &
                          v4_7.x1  == TestData_LHS[i].x1  &
                          v4_7.x2  == TestData_LHS[i].x2  &
                          v4_7.x3  == TestData_LHS[i].x3  &
                          v4_7.x4  == TestData_LHS[i].x4  &
                          v4_7.x5  == TestData_LHS[i].x5  &
                          v4_7.x6  == TestData_LHS[i].x6  &
                          v4_7.x7  == t_sbyte4.TestData_LHS[i].x &
                          v4_7.x8  == t_sbyte4.TestData_LHS[i].y &
                          v4_7.x9  == t_sbyte4.TestData_LHS[i].z &
                          v4_7.x10 == t_sbyte4.TestData_LHS[i].w &
                          v4_7.x11 == TestData_LHS[i].x11 &
                          v4_7.x12 == TestData_LHS[i].x12 &
                          v4_7.x13 == TestData_LHS[i].x13 &
                          v4_7.x14 == TestData_LHS[i].x14 &
                          v4_7.x15 == TestData_LHS[i].x15 &
                          v4_7.x16 == TestData_LHS[i].x16 &
                          v4_7.x17 == TestData_LHS[i].x17 &
                          v4_7.x18 == TestData_LHS[i].x18 &
                          v4_7.x19 == TestData_LHS[i].x19 &
                          v4_7.x20 == TestData_LHS[i].x20 &
                          v4_7.x21 == TestData_LHS[i].x21 &
                          v4_7.x22 == TestData_LHS[i].x22 &
                          v4_7.x23 == TestData_LHS[i].x23 &
                          v4_7.x24 == TestData_LHS[i].x24 &
                          v4_7.x25 == TestData_LHS[i].x25 &
                          v4_7.x26 == TestData_LHS[i].x26 &
                          v4_7.x27 == TestData_LHS[i].x27 &
                          v4_7.x28 == TestData_LHS[i].x28 &
                          v4_7.x29 == TestData_LHS[i].x29 &
                          v4_7.x30 == TestData_LHS[i].x30 &
                          v4_7.x31 == TestData_LHS[i].x31;

                sbyte32 v4_8 = TestData_LHS[i];
                v4_8.v4_8 = t_sbyte4.TestData_LHS[i];
                result &= v4_8.x0  == TestData_LHS[i].x0  &
                          v4_8.x1  == TestData_LHS[i].x1  &
                          v4_8.x2  == TestData_LHS[i].x2  &
                          v4_8.x3  == TestData_LHS[i].x3  &
                          v4_8.x4  == TestData_LHS[i].x4  &
                          v4_8.x5  == TestData_LHS[i].x5  &
                          v4_8.x6  == TestData_LHS[i].x6  &
                          v4_8.x7  == TestData_LHS[i].x7  &
                          v4_8.x8  == t_sbyte4.TestData_LHS[i].x &
                          v4_8.x9  == t_sbyte4.TestData_LHS[i].y &
                          v4_8.x10 == t_sbyte4.TestData_LHS[i].z &
                          v4_8.x11 == t_sbyte4.TestData_LHS[i].w &
                          v4_8.x12 == TestData_LHS[i].x12 &
                          v4_8.x13 == TestData_LHS[i].x13 &
                          v4_8.x14 == TestData_LHS[i].x14 &
                          v4_8.x15 == TestData_LHS[i].x15 &
                          v4_8.x16 == TestData_LHS[i].x16 &
                          v4_8.x17 == TestData_LHS[i].x17 &
                          v4_8.x18 == TestData_LHS[i].x18 &
                          v4_8.x19 == TestData_LHS[i].x19 &
                          v4_8.x20 == TestData_LHS[i].x20 &
                          v4_8.x21 == TestData_LHS[i].x21 &
                          v4_8.x22 == TestData_LHS[i].x22 &
                          v4_8.x23 == TestData_LHS[i].x23 &
                          v4_8.x24 == TestData_LHS[i].x24 &
                          v4_8.x25 == TestData_LHS[i].x25 &
                          v4_8.x26 == TestData_LHS[i].x26 &
                          v4_8.x27 == TestData_LHS[i].x27 &
                          v4_8.x28 == TestData_LHS[i].x28 &
                          v4_8.x29 == TestData_LHS[i].x29 &
                          v4_8.x30 == TestData_LHS[i].x30 &
                          v4_8.x31 == TestData_LHS[i].x31;

                sbyte32 v4_9 = TestData_LHS[i];
                v4_9.v4_9 = t_sbyte4.TestData_LHS[i];
                result &= v4_9.x0  == TestData_LHS[i].x0  &
                          v4_9.x1  == TestData_LHS[i].x1  &
                          v4_9.x2  == TestData_LHS[i].x2  &
                          v4_9.x3  == TestData_LHS[i].x3  &
                          v4_9.x4  == TestData_LHS[i].x4  &
                          v4_9.x5  == TestData_LHS[i].x5  &
                          v4_9.x6  == TestData_LHS[i].x6  &
                          v4_9.x7  == TestData_LHS[i].x7  &
                          v4_9.x8  == TestData_LHS[i].x8  &
                          v4_9.x9  == t_sbyte4.TestData_LHS[i].x &
                          v4_9.x10 == t_sbyte4.TestData_LHS[i].y &
                          v4_9.x11 == t_sbyte4.TestData_LHS[i].z &
                          v4_9.x12 == t_sbyte4.TestData_LHS[i].w &
                          v4_9.x13 == TestData_LHS[i].x13 &
                          v4_9.x14 == TestData_LHS[i].x14 &
                          v4_9.x15 == TestData_LHS[i].x15 &
                          v4_9.x16 == TestData_LHS[i].x16 &
                          v4_9.x17 == TestData_LHS[i].x17 &
                          v4_9.x18 == TestData_LHS[i].x18 &
                          v4_9.x19 == TestData_LHS[i].x19 &
                          v4_9.x20 == TestData_LHS[i].x20 &
                          v4_9.x21 == TestData_LHS[i].x21 &
                          v4_9.x22 == TestData_LHS[i].x22 &
                          v4_9.x23 == TestData_LHS[i].x23 &
                          v4_9.x24 == TestData_LHS[i].x24 &
                          v4_9.x25 == TestData_LHS[i].x25 &
                          v4_9.x26 == TestData_LHS[i].x26 &
                          v4_9.x27 == TestData_LHS[i].x27 &
                          v4_9.x28 == TestData_LHS[i].x28 &
                          v4_9.x29 == TestData_LHS[i].x29 &
                          v4_9.x30 == TestData_LHS[i].x30 &
                          v4_9.x31 == TestData_LHS[i].x31;

                sbyte32 v4_10 = TestData_LHS[i];
                v4_10.v4_10 = t_sbyte4.TestData_LHS[i];
                result &= v4_10.x0  == TestData_LHS[i].x0  &
                          v4_10.x1  == TestData_LHS[i].x1  &
                          v4_10.x2  == TestData_LHS[i].x2  &
                          v4_10.x3  == TestData_LHS[i].x3  &
                          v4_10.x4  == TestData_LHS[i].x4  &
                          v4_10.x5  == TestData_LHS[i].x5  &
                          v4_10.x6  == TestData_LHS[i].x6  &
                          v4_10.x7  == TestData_LHS[i].x7  &
                          v4_10.x8  == TestData_LHS[i].x8  &
                          v4_10.x9  == TestData_LHS[i].x9  &
                          v4_10.x10 == t_sbyte4.TestData_LHS[i].x &
                          v4_10.x11 == t_sbyte4.TestData_LHS[i].y &
                          v4_10.x12 == t_sbyte4.TestData_LHS[i].z &
                          v4_10.x13 == t_sbyte4.TestData_LHS[i].w &
                          v4_10.x14 == TestData_LHS[i].x14 &
                          v4_10.x15 == TestData_LHS[i].x15 &
                          v4_10.x16 == TestData_LHS[i].x16 &
                          v4_10.x17 == TestData_LHS[i].x17 &
                          v4_10.x18 == TestData_LHS[i].x18 &
                          v4_10.x19 == TestData_LHS[i].x19 &
                          v4_10.x20 == TestData_LHS[i].x20 &
                          v4_10.x21 == TestData_LHS[i].x21 &
                          v4_10.x22 == TestData_LHS[i].x22 &
                          v4_10.x23 == TestData_LHS[i].x23 &
                          v4_10.x24 == TestData_LHS[i].x24 &
                          v4_10.x25 == TestData_LHS[i].x25 &
                          v4_10.x26 == TestData_LHS[i].x26 &
                          v4_10.x27 == TestData_LHS[i].x27 &
                          v4_10.x28 == TestData_LHS[i].x28 &
                          v4_10.x29 == TestData_LHS[i].x29 &
                          v4_10.x30 == TestData_LHS[i].x30 &
                          v4_10.x31 == TestData_LHS[i].x31;

                sbyte32 v4_11 = TestData_LHS[i];
                v4_11.v4_11 = t_sbyte4.TestData_LHS[i];
                result &= v4_11.x0  == TestData_LHS[i].x0  &
                          v4_11.x1  == TestData_LHS[i].x1  &
                          v4_11.x2  == TestData_LHS[i].x2  &
                          v4_11.x3  == TestData_LHS[i].x3  &
                          v4_11.x4  == TestData_LHS[i].x4  &
                          v4_11.x5  == TestData_LHS[i].x5  &
                          v4_11.x6  == TestData_LHS[i].x6  &
                          v4_11.x7  == TestData_LHS[i].x7  &
                          v4_11.x8  == TestData_LHS[i].x8  &
                          v4_11.x9  == TestData_LHS[i].x9  &
                          v4_11.x10 == TestData_LHS[i].x10 &
                          v4_11.x11 == t_sbyte4.TestData_LHS[i].x &
                          v4_11.x12 == t_sbyte4.TestData_LHS[i].y &
                          v4_11.x13 == t_sbyte4.TestData_LHS[i].z &
                          v4_11.x14 == t_sbyte4.TestData_LHS[i].w &
                          v4_11.x15 == TestData_LHS[i].x15 &
                          v4_11.x16 == TestData_LHS[i].x16 &
                          v4_11.x17 == TestData_LHS[i].x17 &
                          v4_11.x18 == TestData_LHS[i].x18 &
                          v4_11.x19 == TestData_LHS[i].x19 &
                          v4_11.x20 == TestData_LHS[i].x20 &
                          v4_11.x21 == TestData_LHS[i].x21 &
                          v4_11.x22 == TestData_LHS[i].x22 &
                          v4_11.x23 == TestData_LHS[i].x23 &
                          v4_11.x24 == TestData_LHS[i].x24 &
                          v4_11.x25 == TestData_LHS[i].x25 &
                          v4_11.x26 == TestData_LHS[i].x26 &
                          v4_11.x27 == TestData_LHS[i].x27 &
                          v4_11.x28 == TestData_LHS[i].x28 &
                          v4_11.x29 == TestData_LHS[i].x29 &
                          v4_11.x30 == TestData_LHS[i].x30 &
                          v4_11.x31 == TestData_LHS[i].x31;

                sbyte32 v4_12 = TestData_LHS[i];
                v4_12.v4_12 = t_sbyte4.TestData_LHS[i];
                result &= v4_12.x0  == TestData_LHS[i].x0  &
                          v4_12.x1  == TestData_LHS[i].x1  &
                          v4_12.x2  == TestData_LHS[i].x2  &
                          v4_12.x3  == TestData_LHS[i].x3  &
                          v4_12.x4  == TestData_LHS[i].x4  &
                          v4_12.x5  == TestData_LHS[i].x5  &
                          v4_12.x6  == TestData_LHS[i].x6  &
                          v4_12.x7  == TestData_LHS[i].x7  &
                          v4_12.x8  == TestData_LHS[i].x8  &
                          v4_12.x9  == TestData_LHS[i].x9  &
                          v4_12.x10 == TestData_LHS[i].x10 &
                          v4_12.x11 == TestData_LHS[i].x11 &
                          v4_12.x12 == t_sbyte4.TestData_LHS[i].x &
                          v4_12.x13 == t_sbyte4.TestData_LHS[i].y &
                          v4_12.x14 == t_sbyte4.TestData_LHS[i].z &
                          v4_12.x15 == t_sbyte4.TestData_LHS[i].w &
                          v4_12.x16 == TestData_LHS[i].x16 &
                          v4_12.x17 == TestData_LHS[i].x17 &
                          v4_12.x18 == TestData_LHS[i].x18 &
                          v4_12.x19 == TestData_LHS[i].x19 &
                          v4_12.x20 == TestData_LHS[i].x20 &
                          v4_12.x21 == TestData_LHS[i].x21 &
                          v4_12.x22 == TestData_LHS[i].x22 &
                          v4_12.x23 == TestData_LHS[i].x23 &
                          v4_12.x24 == TestData_LHS[i].x24 &
                          v4_12.x25 == TestData_LHS[i].x25 &
                          v4_12.x26 == TestData_LHS[i].x26 &
                          v4_12.x27 == TestData_LHS[i].x27 &
                          v4_12.x28 == TestData_LHS[i].x28 &
                          v4_12.x29 == TestData_LHS[i].x29 &
                          v4_12.x30 == TestData_LHS[i].x30 &
                          v4_12.x31 == TestData_LHS[i].x31;

                sbyte32 v4_13 = TestData_LHS[i];
                v4_13.v4_13 = t_sbyte4.TestData_LHS[i];
                result &= v4_13.x0  == TestData_LHS[i].x0  &
                          v4_13.x1  == TestData_LHS[i].x1  &
                          v4_13.x2  == TestData_LHS[i].x2  &
                          v4_13.x3  == TestData_LHS[i].x3  &
                          v4_13.x4  == TestData_LHS[i].x4  &
                          v4_13.x5  == TestData_LHS[i].x5  &
                          v4_13.x6  == TestData_LHS[i].x6  &
                          v4_13.x7  == TestData_LHS[i].x7  &
                          v4_13.x8  == TestData_LHS[i].x8  &
                          v4_13.x9  == TestData_LHS[i].x9  &
                          v4_13.x10 == TestData_LHS[i].x10 &
                          v4_13.x11 == TestData_LHS[i].x11 &
                          v4_13.x12 == TestData_LHS[i].x12 &
                          v4_13.x13 == t_sbyte4.TestData_LHS[i].x &
                          v4_13.x14 == t_sbyte4.TestData_LHS[i].y &
                          v4_13.x15 == t_sbyte4.TestData_LHS[i].z &
                          v4_13.x16 == t_sbyte4.TestData_LHS[i].w &
                          v4_13.x17 == TestData_LHS[i].x17 &
                          v4_13.x18 == TestData_LHS[i].x18 &
                          v4_13.x19 == TestData_LHS[i].x19 &
                          v4_13.x20 == TestData_LHS[i].x20 &
                          v4_13.x21 == TestData_LHS[i].x21 &
                          v4_13.x22 == TestData_LHS[i].x22 &
                          v4_13.x23 == TestData_LHS[i].x23 &
                          v4_13.x24 == TestData_LHS[i].x24 &
                          v4_13.x25 == TestData_LHS[i].x25 &
                          v4_13.x26 == TestData_LHS[i].x26 &
                          v4_13.x27 == TestData_LHS[i].x27 &
                          v4_13.x28 == TestData_LHS[i].x28 &
                          v4_13.x29 == TestData_LHS[i].x29 &
                          v4_13.x30 == TestData_LHS[i].x30 &
                          v4_13.x31 == TestData_LHS[i].x31;

                sbyte32 v4_14 = TestData_LHS[i];
                v4_14.v4_14 = t_sbyte4.TestData_LHS[i];
                result &= v4_14.x0  == TestData_LHS[i].x0  &
                          v4_14.x1  == TestData_LHS[i].x1  &
                          v4_14.x2  == TestData_LHS[i].x2  &
                          v4_14.x3  == TestData_LHS[i].x3  &
                          v4_14.x4  == TestData_LHS[i].x4  &
                          v4_14.x5  == TestData_LHS[i].x5  &
                          v4_14.x6  == TestData_LHS[i].x6  &
                          v4_14.x7  == TestData_LHS[i].x7  &
                          v4_14.x8  == TestData_LHS[i].x8  &
                          v4_14.x9  == TestData_LHS[i].x9  &
                          v4_14.x10 == TestData_LHS[i].x10 &
                          v4_14.x11 == TestData_LHS[i].x11 &
                          v4_14.x12 == TestData_LHS[i].x12 &
                          v4_14.x13 == TestData_LHS[i].x13 &
                          v4_14.x14 == t_sbyte4.TestData_LHS[i].x &
                          v4_14.x15 == t_sbyte4.TestData_LHS[i].y &
                          v4_14.x16 == t_sbyte4.TestData_LHS[i].z &
                          v4_14.x17 == t_sbyte4.TestData_LHS[i].w &
                          v4_14.x18 == TestData_LHS[i].x18 &
                          v4_14.x19 == TestData_LHS[i].x19 &
                          v4_14.x20 == TestData_LHS[i].x20 &
                          v4_14.x21 == TestData_LHS[i].x21 &
                          v4_14.x22 == TestData_LHS[i].x22 &
                          v4_14.x23 == TestData_LHS[i].x23 &
                          v4_14.x24 == TestData_LHS[i].x24 &
                          v4_14.x25 == TestData_LHS[i].x25 &
                          v4_14.x26 == TestData_LHS[i].x26 &
                          v4_14.x27 == TestData_LHS[i].x27 &
                          v4_14.x28 == TestData_LHS[i].x28 &
                          v4_14.x29 == TestData_LHS[i].x29 &
                          v4_14.x30 == TestData_LHS[i].x30 &
                          v4_14.x31 == TestData_LHS[i].x31;

                sbyte32 v4_15 = TestData_LHS[i];
                v4_15.v4_15 = t_sbyte4.TestData_LHS[i];
                result &= v4_15.x0  == TestData_LHS[i].x0  &
                          v4_15.x1  == TestData_LHS[i].x1  &
                          v4_15.x2  == TestData_LHS[i].x2  &
                          v4_15.x3  == TestData_LHS[i].x3  &
                          v4_15.x4  == TestData_LHS[i].x4  &
                          v4_15.x5  == TestData_LHS[i].x5  &
                          v4_15.x6  == TestData_LHS[i].x6  &
                          v4_15.x7  == TestData_LHS[i].x7  &
                          v4_15.x8  == TestData_LHS[i].x8  &
                          v4_15.x9  == TestData_LHS[i].x9  &
                          v4_15.x10 == TestData_LHS[i].x10 &
                          v4_15.x11 == TestData_LHS[i].x11 &
                          v4_15.x12 == TestData_LHS[i].x12 &
                          v4_15.x13 == TestData_LHS[i].x13 &
                          v4_15.x14 == TestData_LHS[i].x14 &
                          v4_15.x15 == t_sbyte4.TestData_LHS[i].x &
                          v4_15.x16 == t_sbyte4.TestData_LHS[i].y &
                          v4_15.x17 == t_sbyte4.TestData_LHS[i].z &
                          v4_15.x18 == t_sbyte4.TestData_LHS[i].w &
                          v4_15.x19 == TestData_LHS[i].x19 &
                          v4_15.x20 == TestData_LHS[i].x20 &
                          v4_15.x21 == TestData_LHS[i].x21 &
                          v4_15.x22 == TestData_LHS[i].x22 &
                          v4_15.x23 == TestData_LHS[i].x23 &
                          v4_15.x24 == TestData_LHS[i].x24 &
                          v4_15.x25 == TestData_LHS[i].x25 &
                          v4_15.x26 == TestData_LHS[i].x26 &
                          v4_15.x27 == TestData_LHS[i].x27 &
                          v4_15.x28 == TestData_LHS[i].x28 &
                          v4_15.x29 == TestData_LHS[i].x29 &
                          v4_15.x30 == TestData_LHS[i].x30 &
                          v4_15.x31 == TestData_LHS[i].x31;

                sbyte32 v4_16 = TestData_LHS[i];
                v4_16.v4_16 = t_sbyte4.TestData_LHS[i];
                result &= v4_16.x0  == TestData_LHS[i].x0  &
                          v4_16.x1  == TestData_LHS[i].x1  &
                          v4_16.x2  == TestData_LHS[i].x2  &
                          v4_16.x3  == TestData_LHS[i].x3  &
                          v4_16.x4  == TestData_LHS[i].x4  &
                          v4_16.x5  == TestData_LHS[i].x5  &
                          v4_16.x6  == TestData_LHS[i].x6  &
                          v4_16.x7  == TestData_LHS[i].x7  &
                          v4_16.x8  == TestData_LHS[i].x8  &
                          v4_16.x9  == TestData_LHS[i].x9  &
                          v4_16.x10 == TestData_LHS[i].x10 &
                          v4_16.x11 == TestData_LHS[i].x11 &
                          v4_16.x12 == TestData_LHS[i].x12 &
                          v4_16.x13 == TestData_LHS[i].x13 &
                          v4_16.x14 == TestData_LHS[i].x14 &
                          v4_16.x15 == TestData_LHS[i].x15 &
                          v4_16.x16 == t_sbyte4.TestData_LHS[i].x &
                          v4_16.x17 == t_sbyte4.TestData_LHS[i].y &
                          v4_16.x18 == t_sbyte4.TestData_LHS[i].z &
                          v4_16.x19 == t_sbyte4.TestData_LHS[i].w &
                          v4_16.x20 == TestData_LHS[i].x20 &
                          v4_16.x21 == TestData_LHS[i].x21 &
                          v4_16.x22 == TestData_LHS[i].x22 &
                          v4_16.x23 == TestData_LHS[i].x23 &
                          v4_16.x24 == TestData_LHS[i].x24 &
                          v4_16.x25 == TestData_LHS[i].x25 &
                          v4_16.x26 == TestData_LHS[i].x26 &
                          v4_16.x27 == TestData_LHS[i].x27 &
                          v4_16.x28 == TestData_LHS[i].x28 &
                          v4_16.x29 == TestData_LHS[i].x29 &
                          v4_16.x30 == TestData_LHS[i].x30 &
                          v4_16.x31 == TestData_LHS[i].x31;

                sbyte32 v4_17 = TestData_LHS[i];
                v4_17.v4_17 = t_sbyte4.TestData_LHS[i];
                result &= v4_17.x0  == TestData_LHS[i].x0  &
                          v4_17.x1  == TestData_LHS[i].x1  &
                          v4_17.x2  == TestData_LHS[i].x2  &
                          v4_17.x3  == TestData_LHS[i].x3  &
                          v4_17.x4  == TestData_LHS[i].x4  &
                          v4_17.x5  == TestData_LHS[i].x5  &
                          v4_17.x6  == TestData_LHS[i].x6  &
                          v4_17.x7  == TestData_LHS[i].x7  &
                          v4_17.x8  == TestData_LHS[i].x8  &
                          v4_17.x9  == TestData_LHS[i].x9  &
                          v4_17.x10 == TestData_LHS[i].x10 &
                          v4_17.x11 == TestData_LHS[i].x11 &
                          v4_17.x12 == TestData_LHS[i].x12 &
                          v4_17.x13 == TestData_LHS[i].x13 &
                          v4_17.x14 == TestData_LHS[i].x14 &
                          v4_17.x15 == TestData_LHS[i].x15 &
                          v4_17.x16 == TestData_LHS[i].x16 &
                          v4_17.x17 == t_sbyte4.TestData_LHS[i].x &
                          v4_17.x18 == t_sbyte4.TestData_LHS[i].y &
                          v4_17.x19 == t_sbyte4.TestData_LHS[i].z &
                          v4_17.x20 == t_sbyte4.TestData_LHS[i].w &
                          v4_17.x21 == TestData_LHS[i].x21 &
                          v4_17.x22 == TestData_LHS[i].x22 &
                          v4_17.x23 == TestData_LHS[i].x23 &
                          v4_17.x24 == TestData_LHS[i].x24 &
                          v4_17.x25 == TestData_LHS[i].x25 &
                          v4_17.x26 == TestData_LHS[i].x26 &
                          v4_17.x27 == TestData_LHS[i].x27 &
                          v4_17.x28 == TestData_LHS[i].x28 &
                          v4_17.x29 == TestData_LHS[i].x29 &
                          v4_17.x30 == TestData_LHS[i].x30 &
                          v4_17.x31 == TestData_LHS[i].x31;

                sbyte32 v4_18 = TestData_LHS[i];
                v4_18.v4_18 = t_sbyte4.TestData_LHS[i];
                result &= v4_18.x0  == TestData_LHS[i].x0  &
                          v4_18.x1  == TestData_LHS[i].x1  &
                          v4_18.x2  == TestData_LHS[i].x2  &
                          v4_18.x3  == TestData_LHS[i].x3  &
                          v4_18.x4  == TestData_LHS[i].x4  &
                          v4_18.x5  == TestData_LHS[i].x5  &
                          v4_18.x6  == TestData_LHS[i].x6  &
                          v4_18.x7  == TestData_LHS[i].x7  &
                          v4_18.x8  == TestData_LHS[i].x8  &
                          v4_18.x9  == TestData_LHS[i].x9  &
                          v4_18.x10 == TestData_LHS[i].x10 &
                          v4_18.x11 == TestData_LHS[i].x11 &
                          v4_18.x12 == TestData_LHS[i].x12 &
                          v4_18.x13 == TestData_LHS[i].x13 &
                          v4_18.x14 == TestData_LHS[i].x14 &
                          v4_18.x15 == TestData_LHS[i].x15 &
                          v4_18.x16 == TestData_LHS[i].x16 &
                          v4_18.x17 == TestData_LHS[i].x17 &
                          v4_18.x18 == t_sbyte4.TestData_LHS[i].x &
                          v4_18.x19 == t_sbyte4.TestData_LHS[i].y &
                          v4_18.x20 == t_sbyte4.TestData_LHS[i].z &
                          v4_18.x21 == t_sbyte4.TestData_LHS[i].w &
                          v4_18.x22 == TestData_LHS[i].x22 &
                          v4_18.x23 == TestData_LHS[i].x23 &
                          v4_18.x24 == TestData_LHS[i].x24 &
                          v4_18.x25 == TestData_LHS[i].x25 &
                          v4_18.x26 == TestData_LHS[i].x26 &
                          v4_18.x27 == TestData_LHS[i].x27 &
                          v4_18.x28 == TestData_LHS[i].x28 &
                          v4_18.x29 == TestData_LHS[i].x29 &
                          v4_18.x30 == TestData_LHS[i].x30 &
                          v4_18.x31 == TestData_LHS[i].x31;

                sbyte32 v4_19 = TestData_LHS[i];
                v4_19.v4_19 = t_sbyte4.TestData_LHS[i];
                result &= v4_19.x0  == TestData_LHS[i].x0  &
                          v4_19.x1  == TestData_LHS[i].x1  &
                          v4_19.x2  == TestData_LHS[i].x2  &
                          v4_19.x3  == TestData_LHS[i].x3  &
                          v4_19.x4  == TestData_LHS[i].x4  &
                          v4_19.x5  == TestData_LHS[i].x5  &
                          v4_19.x6  == TestData_LHS[i].x6  &
                          v4_19.x7  == TestData_LHS[i].x7  &
                          v4_19.x8  == TestData_LHS[i].x8  &
                          v4_19.x9  == TestData_LHS[i].x9  &
                          v4_19.x10 == TestData_LHS[i].x10 &
                          v4_19.x11 == TestData_LHS[i].x11 &
                          v4_19.x12 == TestData_LHS[i].x12 &
                          v4_19.x13 == TestData_LHS[i].x13 &
                          v4_19.x14 == TestData_LHS[i].x14 &
                          v4_19.x15 == TestData_LHS[i].x15 &
                          v4_19.x16 == TestData_LHS[i].x16 &
                          v4_19.x17 == TestData_LHS[i].x17 &
                          v4_19.x18 == TestData_LHS[i].x18 &
                          v4_19.x19 == t_sbyte4.TestData_LHS[i].x &
                          v4_19.x20 == t_sbyte4.TestData_LHS[i].y &
                          v4_19.x21 == t_sbyte4.TestData_LHS[i].z &
                          v4_19.x22 == t_sbyte4.TestData_LHS[i].w &
                          v4_19.x23 == TestData_LHS[i].x23 &
                          v4_19.x24 == TestData_LHS[i].x24 &
                          v4_19.x25 == TestData_LHS[i].x25 &
                          v4_19.x26 == TestData_LHS[i].x26 &
                          v4_19.x27 == TestData_LHS[i].x27 &
                          v4_19.x28 == TestData_LHS[i].x28 &
                          v4_19.x29 == TestData_LHS[i].x29 &
                          v4_19.x30 == TestData_LHS[i].x30 &
                          v4_19.x31 == TestData_LHS[i].x31;

                sbyte32 v4_20 = TestData_LHS[i];
                v4_20.v4_20 = t_sbyte4.TestData_LHS[i];
                result &= v4_20.x0  == TestData_LHS[i].x0  &
                          v4_20.x1  == TestData_LHS[i].x1  &
                          v4_20.x2  == TestData_LHS[i].x2  &
                          v4_20.x3  == TestData_LHS[i].x3  &
                          v4_20.x4  == TestData_LHS[i].x4  &
                          v4_20.x5  == TestData_LHS[i].x5  &
                          v4_20.x6  == TestData_LHS[i].x6  &
                          v4_20.x7  == TestData_LHS[i].x7  &
                          v4_20.x8  == TestData_LHS[i].x8  &
                          v4_20.x9  == TestData_LHS[i].x9  &
                          v4_20.x10 == TestData_LHS[i].x10 &
                          v4_20.x11 == TestData_LHS[i].x11 &
                          v4_20.x12 == TestData_LHS[i].x12 &
                          v4_20.x13 == TestData_LHS[i].x13 &
                          v4_20.x14 == TestData_LHS[i].x14 &
                          v4_20.x15 == TestData_LHS[i].x15 &
                          v4_20.x16 == TestData_LHS[i].x16 &
                          v4_20.x17 == TestData_LHS[i].x17 &
                          v4_20.x18 == TestData_LHS[i].x18 &
                          v4_20.x19 == TestData_LHS[i].x19 &
                          v4_20.x20 == t_sbyte4.TestData_LHS[i].x &
                          v4_20.x21 == t_sbyte4.TestData_LHS[i].y &
                          v4_20.x22 == t_sbyte4.TestData_LHS[i].z &
                          v4_20.x23 == t_sbyte4.TestData_LHS[i].w &
                          v4_20.x24 == TestData_LHS[i].x24 &
                          v4_20.x25 == TestData_LHS[i].x25 &
                          v4_20.x26 == TestData_LHS[i].x26 &
                          v4_20.x27 == TestData_LHS[i].x27 &
                          v4_20.x28 == TestData_LHS[i].x28 &
                          v4_20.x29 == TestData_LHS[i].x29 &
                          v4_20.x30 == TestData_LHS[i].x30 &
                          v4_20.x31 == TestData_LHS[i].x31;

                sbyte32 v4_21 = TestData_LHS[i];
                v4_21.v4_21 = t_sbyte4.TestData_LHS[i];
                result &= v4_21.x0  == TestData_LHS[i].x0  &
                          v4_21.x1  == TestData_LHS[i].x1  &
                          v4_21.x2  == TestData_LHS[i].x2  &
                          v4_21.x3  == TestData_LHS[i].x3  &
                          v4_21.x4  == TestData_LHS[i].x4  &
                          v4_21.x5  == TestData_LHS[i].x5  &
                          v4_21.x6  == TestData_LHS[i].x6  &
                          v4_21.x7  == TestData_LHS[i].x7  &
                          v4_21.x8  == TestData_LHS[i].x8  &
                          v4_21.x9  == TestData_LHS[i].x9  &
                          v4_21.x10 == TestData_LHS[i].x10 &
                          v4_21.x11 == TestData_LHS[i].x11 &
                          v4_21.x12 == TestData_LHS[i].x12 &
                          v4_21.x13 == TestData_LHS[i].x13 &
                          v4_21.x14 == TestData_LHS[i].x14 &
                          v4_21.x15 == TestData_LHS[i].x15 &
                          v4_21.x16 == TestData_LHS[i].x16 &
                          v4_21.x17 == TestData_LHS[i].x17 &
                          v4_21.x18 == TestData_LHS[i].x18 &
                          v4_21.x19 == TestData_LHS[i].x19 &
                          v4_21.x20 == TestData_LHS[i].x20 &
                          v4_21.x21 == t_sbyte4.TestData_LHS[i].x &
                          v4_21.x22 == t_sbyte4.TestData_LHS[i].y &
                          v4_21.x23 == t_sbyte4.TestData_LHS[i].z &
                          v4_21.x24 == t_sbyte4.TestData_LHS[i].w &
                          v4_21.x25 == TestData_LHS[i].x25 &
                          v4_21.x26 == TestData_LHS[i].x26 &
                          v4_21.x27 == TestData_LHS[i].x27 &
                          v4_21.x28 == TestData_LHS[i].x28 &
                          v4_21.x29 == TestData_LHS[i].x29 &
                          v4_21.x30 == TestData_LHS[i].x30 &
                          v4_21.x31 == TestData_LHS[i].x31;

                sbyte32 v4_22 = TestData_LHS[i];
                v4_22.v4_22 = t_sbyte4.TestData_LHS[i];
                result &= v4_22.x0  == TestData_LHS[i].x0  &
                          v4_22.x1  == TestData_LHS[i].x1  &
                          v4_22.x2  == TestData_LHS[i].x2  &
                          v4_22.x3  == TestData_LHS[i].x3  &
                          v4_22.x4  == TestData_LHS[i].x4  &
                          v4_22.x5  == TestData_LHS[i].x5  &
                          v4_22.x6  == TestData_LHS[i].x6  &
                          v4_22.x7  == TestData_LHS[i].x7  &
                          v4_22.x8  == TestData_LHS[i].x8  &
                          v4_22.x9  == TestData_LHS[i].x9  &
                          v4_22.x10 == TestData_LHS[i].x10 &
                          v4_22.x11 == TestData_LHS[i].x11 &
                          v4_22.x12 == TestData_LHS[i].x12 &
                          v4_22.x13 == TestData_LHS[i].x13 &
                          v4_22.x14 == TestData_LHS[i].x14 &
                          v4_22.x15 == TestData_LHS[i].x15 &
                          v4_22.x16 == TestData_LHS[i].x16 &
                          v4_22.x17 == TestData_LHS[i].x17 &
                          v4_22.x18 == TestData_LHS[i].x18 &
                          v4_22.x19 == TestData_LHS[i].x19 &
                          v4_22.x20 == TestData_LHS[i].x20 &
                          v4_22.x21 == TestData_LHS[i].x21 &
                          v4_22.x22 == t_sbyte4.TestData_LHS[i].x &
                          v4_22.x23 == t_sbyte4.TestData_LHS[i].y &
                          v4_22.x24 == t_sbyte4.TestData_LHS[i].z &
                          v4_22.x25 == t_sbyte4.TestData_LHS[i].w &
                          v4_22.x26 == TestData_LHS[i].x26 &
                          v4_22.x27 == TestData_LHS[i].x27 &
                          v4_22.x28 == TestData_LHS[i].x28 &
                          v4_22.x29 == TestData_LHS[i].x29 &
                          v4_22.x30 == TestData_LHS[i].x30 &
                          v4_22.x31 == TestData_LHS[i].x31;

                sbyte32 v4_23 = TestData_LHS[i];
                v4_23.v4_23 = t_sbyte4.TestData_LHS[i];
                result &= v4_23.x0  == TestData_LHS[i].x0  &
                          v4_23.x1  == TestData_LHS[i].x1  &
                          v4_23.x2  == TestData_LHS[i].x2  &
                          v4_23.x3  == TestData_LHS[i].x3  &
                          v4_23.x4  == TestData_LHS[i].x4  &
                          v4_23.x5  == TestData_LHS[i].x5  &
                          v4_23.x6  == TestData_LHS[i].x6  &
                          v4_23.x7  == TestData_LHS[i].x7  &
                          v4_23.x8  == TestData_LHS[i].x8  &
                          v4_23.x9  == TestData_LHS[i].x9  &
                          v4_23.x10 == TestData_LHS[i].x10 &
                          v4_23.x11 == TestData_LHS[i].x11 &
                          v4_23.x12 == TestData_LHS[i].x12 &
                          v4_23.x13 == TestData_LHS[i].x13 &
                          v4_23.x14 == TestData_LHS[i].x14 &
                          v4_23.x15 == TestData_LHS[i].x15 &
                          v4_23.x16 == TestData_LHS[i].x16 &
                          v4_23.x17 == TestData_LHS[i].x17 &
                          v4_23.x18 == TestData_LHS[i].x18 &
                          v4_23.x19 == TestData_LHS[i].x19 &
                          v4_23.x20 == TestData_LHS[i].x20 &
                          v4_23.x21 == TestData_LHS[i].x21 &
                          v4_23.x22 == TestData_LHS[i].x22 &
                          v4_23.x23 == t_sbyte4.TestData_LHS[i].x &
                          v4_23.x24 == t_sbyte4.TestData_LHS[i].y &
                          v4_23.x25 == t_sbyte4.TestData_LHS[i].z &
                          v4_23.x26 == t_sbyte4.TestData_LHS[i].w &
                          v4_23.x27 == TestData_LHS[i].x27 &
                          v4_23.x28 == TestData_LHS[i].x28 &
                          v4_23.x29 == TestData_LHS[i].x29 &
                          v4_23.x30 == TestData_LHS[i].x30 &
                          v4_23.x31 == TestData_LHS[i].x31;

                sbyte32 v4_24 = TestData_LHS[i];
                v4_24.v4_24 = t_sbyte4.TestData_LHS[i];
                result &= v4_24.x0  == TestData_LHS[i].x0  &
                          v4_24.x1  == TestData_LHS[i].x1  &
                          v4_24.x2  == TestData_LHS[i].x2  &
                          v4_24.x3  == TestData_LHS[i].x3  &
                          v4_24.x4  == TestData_LHS[i].x4  &
                          v4_24.x5  == TestData_LHS[i].x5  &
                          v4_24.x6  == TestData_LHS[i].x6  &
                          v4_24.x7  == TestData_LHS[i].x7  &
                          v4_24.x8  == TestData_LHS[i].x8  &
                          v4_24.x9  == TestData_LHS[i].x9  &
                          v4_24.x10 == TestData_LHS[i].x10 &
                          v4_24.x11 == TestData_LHS[i].x11 &
                          v4_24.x12 == TestData_LHS[i].x12 &
                          v4_24.x13 == TestData_LHS[i].x13 &
                          v4_24.x14 == TestData_LHS[i].x14 &
                          v4_24.x15 == TestData_LHS[i].x15 &
                          v4_24.x16 == TestData_LHS[i].x16 &
                          v4_24.x17 == TestData_LHS[i].x17 &
                          v4_24.x18 == TestData_LHS[i].x18 &
                          v4_24.x19 == TestData_LHS[i].x19 &
                          v4_24.x20 == TestData_LHS[i].x20 &
                          v4_24.x21 == TestData_LHS[i].x21 &
                          v4_24.x22 == TestData_LHS[i].x22 &
                          v4_24.x23 == TestData_LHS[i].x23 &
                          v4_24.x24 == t_sbyte4.TestData_LHS[i].x &
                          v4_24.x25 == t_sbyte4.TestData_LHS[i].y &
                          v4_24.x26 == t_sbyte4.TestData_LHS[i].z &
                          v4_24.x27 == t_sbyte4.TestData_LHS[i].w &
                          v4_24.x28 == TestData_LHS[i].x28 &
                          v4_24.x29 == TestData_LHS[i].x29 &
                          v4_24.x30 == TestData_LHS[i].x30 &
                          v4_24.x31 == TestData_LHS[i].x31;

                sbyte32 v4_25 = TestData_LHS[i];
                v4_25.v4_25 = t_sbyte4.TestData_LHS[i];
                result &= v4_25.x0  == TestData_LHS[i].x0  &
                          v4_25.x1  == TestData_LHS[i].x1  &
                          v4_25.x2  == TestData_LHS[i].x2  &
                          v4_25.x3  == TestData_LHS[i].x3  &
                          v4_25.x4  == TestData_LHS[i].x4  &
                          v4_25.x5  == TestData_LHS[i].x5  &
                          v4_25.x6  == TestData_LHS[i].x6  &
                          v4_25.x7  == TestData_LHS[i].x7  &
                          v4_25.x8  == TestData_LHS[i].x8  &
                          v4_25.x9  == TestData_LHS[i].x9  &
                          v4_25.x10 == TestData_LHS[i].x10 &
                          v4_25.x11 == TestData_LHS[i].x11 &
                          v4_25.x12 == TestData_LHS[i].x12 &
                          v4_25.x13 == TestData_LHS[i].x13 &
                          v4_25.x14 == TestData_LHS[i].x14 &
                          v4_25.x15 == TestData_LHS[i].x15 &
                          v4_25.x16 == TestData_LHS[i].x16 &
                          v4_25.x17 == TestData_LHS[i].x17 &
                          v4_25.x18 == TestData_LHS[i].x18 &
                          v4_25.x19 == TestData_LHS[i].x19 &
                          v4_25.x20 == TestData_LHS[i].x20 &
                          v4_25.x21 == TestData_LHS[i].x21 &
                          v4_25.x22 == TestData_LHS[i].x22 &
                          v4_25.x23 == TestData_LHS[i].x23 &
                          v4_25.x24 == TestData_LHS[i].x24 &
                          v4_25.x25 == t_sbyte4.TestData_LHS[i].x &
                          v4_25.x26 == t_sbyte4.TestData_LHS[i].y &
                          v4_25.x27 == t_sbyte4.TestData_LHS[i].z &
                          v4_25.x28 == t_sbyte4.TestData_LHS[i].w &
                          v4_25.x29 == TestData_LHS[i].x29 &
                          v4_25.x30 == TestData_LHS[i].x30 &
                          v4_25.x31 == TestData_LHS[i].x31;

                sbyte32 v4_26 = TestData_LHS[i];
                v4_26.v4_26 = t_sbyte4.TestData_LHS[i];
                result &= v4_26.x0  == TestData_LHS[i].x0  &
                          v4_26.x1  == TestData_LHS[i].x1  &
                          v4_26.x2  == TestData_LHS[i].x2  &
                          v4_26.x3  == TestData_LHS[i].x3  &
                          v4_26.x4  == TestData_LHS[i].x4  &
                          v4_26.x5  == TestData_LHS[i].x5  &
                          v4_26.x6  == TestData_LHS[i].x6  &
                          v4_26.x7  == TestData_LHS[i].x7  &
                          v4_26.x8  == TestData_LHS[i].x8  &
                          v4_26.x9  == TestData_LHS[i].x9  &
                          v4_26.x10 == TestData_LHS[i].x10 &
                          v4_26.x11 == TestData_LHS[i].x11 &
                          v4_26.x12 == TestData_LHS[i].x12 &
                          v4_26.x13 == TestData_LHS[i].x13 &
                          v4_26.x14 == TestData_LHS[i].x14 &
                          v4_26.x15 == TestData_LHS[i].x15 &
                          v4_26.x16 == TestData_LHS[i].x16 &
                          v4_26.x17 == TestData_LHS[i].x17 &
                          v4_26.x18 == TestData_LHS[i].x18 &
                          v4_26.x19 == TestData_LHS[i].x19 &
                          v4_26.x20 == TestData_LHS[i].x20 &
                          v4_26.x21 == TestData_LHS[i].x21 &
                          v4_26.x22 == TestData_LHS[i].x22 &
                          v4_26.x23 == TestData_LHS[i].x23 &
                          v4_26.x24 == TestData_LHS[i].x24 &
                          v4_26.x25 == TestData_LHS[i].x25 &
                          v4_26.x26 == t_sbyte4.TestData_LHS[i].x &
                          v4_26.x27 == t_sbyte4.TestData_LHS[i].y &
                          v4_26.x28 == t_sbyte4.TestData_LHS[i].z &
                          v4_26.x29 == t_sbyte4.TestData_LHS[i].w &
                          v4_26.x30 == TestData_LHS[i].x30 &
                          v4_26.x31 == TestData_LHS[i].x31;

                sbyte32 v4_27 = TestData_LHS[i];
                v4_27.v4_27 = t_sbyte4.TestData_LHS[i];
                result &= v4_27.x0  == TestData_LHS[i].x0  &
                          v4_27.x1  == TestData_LHS[i].x1  &
                          v4_27.x2  == TestData_LHS[i].x2  &
                          v4_27.x3  == TestData_LHS[i].x3  &
                          v4_27.x4  == TestData_LHS[i].x4  &
                          v4_27.x5  == TestData_LHS[i].x5  &
                          v4_27.x6  == TestData_LHS[i].x6  &
                          v4_27.x7  == TestData_LHS[i].x7  &
                          v4_27.x8  == TestData_LHS[i].x8  &
                          v4_27.x9  == TestData_LHS[i].x9  &
                          v4_27.x10 == TestData_LHS[i].x10 &
                          v4_27.x11 == TestData_LHS[i].x11 &
                          v4_27.x12 == TestData_LHS[i].x12 &
                          v4_27.x13 == TestData_LHS[i].x13 &
                          v4_27.x14 == TestData_LHS[i].x14 &
                          v4_27.x15 == TestData_LHS[i].x15 &
                          v4_27.x16 == TestData_LHS[i].x16 &
                          v4_27.x17 == TestData_LHS[i].x17 &
                          v4_27.x18 == TestData_LHS[i].x18 &
                          v4_27.x19 == TestData_LHS[i].x19 &
                          v4_27.x20 == TestData_LHS[i].x20 &
                          v4_27.x21 == TestData_LHS[i].x21 &
                          v4_27.x22 == TestData_LHS[i].x22 &
                          v4_27.x23 == TestData_LHS[i].x23 &
                          v4_27.x24 == TestData_LHS[i].x24 &
                          v4_27.x25 == TestData_LHS[i].x25 &
                          v4_27.x26 == TestData_LHS[i].x26 &
                          v4_27.x27 == t_sbyte4.TestData_LHS[i].x &
                          v4_27.x28 == t_sbyte4.TestData_LHS[i].y &
                          v4_27.x29 == t_sbyte4.TestData_LHS[i].z &
                          v4_27.x30 == t_sbyte4.TestData_LHS[i].w &
                          v4_27.x31 == TestData_LHS[i].x31;

                sbyte32 v4_28 = TestData_LHS[i];
                v4_28.v4_28 = t_sbyte4.TestData_LHS[i];
                result &= v4_28.x0  == TestData_LHS[i].x0  &
                          v4_28.x1  == TestData_LHS[i].x1  &
                          v4_28.x2  == TestData_LHS[i].x2  &
                          v4_28.x3  == TestData_LHS[i].x3  &
                          v4_28.x4  == TestData_LHS[i].x4  &
                          v4_28.x5  == TestData_LHS[i].x5  &
                          v4_28.x6  == TestData_LHS[i].x6  &
                          v4_28.x7  == TestData_LHS[i].x7  &
                          v4_28.x8  == TestData_LHS[i].x8  &
                          v4_28.x9  == TestData_LHS[i].x9  &
                          v4_28.x10 == TestData_LHS[i].x10 &
                          v4_28.x11 == TestData_LHS[i].x11 &
                          v4_28.x12 == TestData_LHS[i].x12 &
                          v4_28.x13 == TestData_LHS[i].x13 &
                          v4_28.x14 == TestData_LHS[i].x14 &
                          v4_28.x15 == TestData_LHS[i].x15 &
                          v4_28.x16 == TestData_LHS[i].x16 &
                          v4_28.x17 == TestData_LHS[i].x17 &
                          v4_28.x18 == TestData_LHS[i].x18 &
                          v4_28.x19 == TestData_LHS[i].x19 &
                          v4_28.x20 == TestData_LHS[i].x20 &
                          v4_28.x21 == TestData_LHS[i].x21 &
                          v4_28.x22 == TestData_LHS[i].x22 &
                          v4_28.x23 == TestData_LHS[i].x23 &
                          v4_28.x24 == TestData_LHS[i].x24 &
                          v4_28.x25 == TestData_LHS[i].x25 &
                          v4_28.x26 == TestData_LHS[i].x26 &
                          v4_28.x27 == TestData_LHS[i].x27 &
                          v4_28.x28 == t_sbyte4.TestData_LHS[i].x &
                          v4_28.x29 == t_sbyte4.TestData_LHS[i].y &
                          v4_28.x30 == t_sbyte4.TestData_LHS[i].z &
                          v4_28.x31 == t_sbyte4.TestData_LHS[i].w;



                sbyte32 v3_0 = TestData_LHS[i];
                v3_0.v3_0 = t_sbyte3.TestData_LHS[i];
                result &= v3_0.x0  == t_sbyte3.TestData_LHS[i].x  &
                          v3_0.x1  == t_sbyte3.TestData_LHS[i].y  &
                          v3_0.x2  == t_sbyte3.TestData_LHS[i].z  &
                          v3_0.x3  == TestData_LHS[i].x3  &
                          v3_0.x4  == TestData_LHS[i].x4  &
                          v3_0.x5  == TestData_LHS[i].x5  &
                          v3_0.x6  == TestData_LHS[i].x6  &
                          v3_0.x7  == TestData_LHS[i].x7  &
                          v3_0.x8  == TestData_LHS[i].x8  &
                          v3_0.x9  == TestData_LHS[i].x9  &
                          v3_0.x10 == TestData_LHS[i].x10 &
                          v3_0.x11 == TestData_LHS[i].x11 &
                          v3_0.x12 == TestData_LHS[i].x12 &
                          v3_0.x13 == TestData_LHS[i].x13 &
                          v3_0.x14 == TestData_LHS[i].x14 &
                          v3_0.x15 == TestData_LHS[i].x15 &
                          v3_0.x16 == TestData_LHS[i].x16 &
                          v3_0.x17 == TestData_LHS[i].x17 &
                          v3_0.x18 == TestData_LHS[i].x18 &
                          v3_0.x19 == TestData_LHS[i].x19 &
                          v3_0.x20 == TestData_LHS[i].x20 &
                          v3_0.x21 == TestData_LHS[i].x21 &
                          v3_0.x22 == TestData_LHS[i].x22 &
                          v3_0.x23 == TestData_LHS[i].x23 &
                          v3_0.x24 == TestData_LHS[i].x24 &
                          v3_0.x25 == TestData_LHS[i].x25 &
                          v3_0.x26 == TestData_LHS[i].x26 &
                          v3_0.x27 == TestData_LHS[i].x27 &
                          v3_0.x28 == TestData_LHS[i].x28 &
                          v3_0.x29 == TestData_LHS[i].x29 &
                          v3_0.x30 == TestData_LHS[i].x30 &
                          v3_0.x31 == TestData_LHS[i].x31;

                sbyte32 v3_1 = TestData_LHS[i];
                v3_1.v3_1 = t_sbyte3.TestData_LHS[i];
                result &= v3_1.x0  == TestData_LHS[i].x0  &
                          v3_1.x1  == t_sbyte3.TestData_LHS[i].x  &
                          v3_1.x2  == t_sbyte3.TestData_LHS[i].y  &
                          v3_1.x3  == t_sbyte3.TestData_LHS[i].z &
                          v3_1.x4  == TestData_LHS[i].x4  &
                          v3_1.x5  == TestData_LHS[i].x5  &
                          v3_1.x6  == TestData_LHS[i].x6  &
                          v3_1.x7  == TestData_LHS[i].x7  &
                          v3_1.x8  == TestData_LHS[i].x8  &
                          v3_1.x9  == TestData_LHS[i].x9  &
                          v3_1.x10 == TestData_LHS[i].x10 &
                          v3_1.x11 == TestData_LHS[i].x11 &
                          v3_1.x12 == TestData_LHS[i].x12 &
                          v3_1.x13 == TestData_LHS[i].x13 &
                          v3_1.x14 == TestData_LHS[i].x14 &
                          v3_1.x15 == TestData_LHS[i].x15 &
                          v3_1.x16 == TestData_LHS[i].x16 &
                          v3_1.x17 == TestData_LHS[i].x17 &
                          v3_1.x18 == TestData_LHS[i].x18 &
                          v3_1.x19 == TestData_LHS[i].x19 &
                          v3_1.x20 == TestData_LHS[i].x20 &
                          v3_1.x21 == TestData_LHS[i].x21 &
                          v3_1.x22 == TestData_LHS[i].x22 &
                          v3_1.x23 == TestData_LHS[i].x23 &
                          v3_1.x24 == TestData_LHS[i].x24 &
                          v3_1.x25 == TestData_LHS[i].x25 &
                          v3_1.x26 == TestData_LHS[i].x26 &
                          v3_1.x27 == TestData_LHS[i].x27 &
                          v3_1.x28 == TestData_LHS[i].x28 &
                          v3_1.x29 == TestData_LHS[i].x29 &
                          v3_1.x30 == TestData_LHS[i].x30 &
                          v3_1.x31 == TestData_LHS[i].x31;

                sbyte32 v3_2 = TestData_LHS[i];
                v3_2.v3_2 = t_sbyte3.TestData_LHS[i];
                result &= v3_2.x0  == TestData_LHS[i].x0  &
                          v3_2.x1  == TestData_LHS[i].x1  &
                          v3_2.x2  == t_sbyte3.TestData_LHS[i].x  &
                          v3_2.x3  == t_sbyte3.TestData_LHS[i].y  &
                          v3_2.x4  == t_sbyte3.TestData_LHS[i].z &
                          v3_2.x5  == TestData_LHS[i].x5  &
                          v3_2.x6  == TestData_LHS[i].x6  &
                          v3_2.x7  == TestData_LHS[i].x7  &
                          v3_2.x8  == TestData_LHS[i].x8  &
                          v3_2.x9  == TestData_LHS[i].x9  &
                          v3_2.x10 == TestData_LHS[i].x10 &
                          v3_2.x11 == TestData_LHS[i].x11 &
                          v3_2.x12 == TestData_LHS[i].x12 &
                          v3_2.x13 == TestData_LHS[i].x13 &
                          v3_2.x14 == TestData_LHS[i].x14 &
                          v3_2.x15 == TestData_LHS[i].x15 &
                          v3_2.x16 == TestData_LHS[i].x16 &
                          v3_2.x17 == TestData_LHS[i].x17 &
                          v3_2.x18 == TestData_LHS[i].x18 &
                          v3_2.x19 == TestData_LHS[i].x19 &
                          v3_2.x20 == TestData_LHS[i].x20 &
                          v3_2.x21 == TestData_LHS[i].x21 &
                          v3_2.x22 == TestData_LHS[i].x22 &
                          v3_2.x23 == TestData_LHS[i].x23 &
                          v3_2.x24 == TestData_LHS[i].x24 &
                          v3_2.x25 == TestData_LHS[i].x25 &
                          v3_2.x26 == TestData_LHS[i].x26 &
                          v3_2.x27 == TestData_LHS[i].x27 &
                          v3_2.x28 == TestData_LHS[i].x28 &
                          v3_2.x29 == TestData_LHS[i].x29 &
                          v3_2.x30 == TestData_LHS[i].x30 &
                          v3_2.x31 == TestData_LHS[i].x31;

                sbyte32 v3_3 = TestData_LHS[i];
                v3_3.v3_3 = t_sbyte3.TestData_LHS[i];
                result &= v3_3.x0  == TestData_LHS[i].x0  &
                          v3_3.x1  == TestData_LHS[i].x1  &
                          v3_3.x2  == TestData_LHS[i].x2  &
                          v3_3.x3  == t_sbyte3.TestData_LHS[i].x  &
                          v3_3.x4  == t_sbyte3.TestData_LHS[i].y  &
                          v3_3.x5  == t_sbyte3.TestData_LHS[i].z &
                          v3_3.x6  == TestData_LHS[i].x6  &
                          v3_3.x7  == TestData_LHS[i].x7  &
                          v3_3.x8  == TestData_LHS[i].x8  &
                          v3_3.x9  == TestData_LHS[i].x9  &
                          v3_3.x10 == TestData_LHS[i].x10 &
                          v3_3.x11 == TestData_LHS[i].x11 &
                          v3_3.x12 == TestData_LHS[i].x12 &
                          v3_3.x13 == TestData_LHS[i].x13 &
                          v3_3.x14 == TestData_LHS[i].x14 &
                          v3_3.x15 == TestData_LHS[i].x15 &
                          v3_3.x16 == TestData_LHS[i].x16 &
                          v3_3.x17 == TestData_LHS[i].x17 &
                          v3_3.x18 == TestData_LHS[i].x18 &
                          v3_3.x19 == TestData_LHS[i].x19 &
                          v3_3.x20 == TestData_LHS[i].x20 &
                          v3_3.x21 == TestData_LHS[i].x21 &
                          v3_3.x22 == TestData_LHS[i].x22 &
                          v3_3.x23 == TestData_LHS[i].x23 &
                          v3_3.x24 == TestData_LHS[i].x24 &
                          v3_3.x25 == TestData_LHS[i].x25 &
                          v3_3.x26 == TestData_LHS[i].x26 &
                          v3_3.x27 == TestData_LHS[i].x27 &
                          v3_3.x28 == TestData_LHS[i].x28 &
                          v3_3.x29 == TestData_LHS[i].x29 &
                          v3_3.x30 == TestData_LHS[i].x30 &
                          v3_3.x31 == TestData_LHS[i].x31;

                sbyte32 v3_4 = TestData_LHS[i];
                v3_4.v3_4 = t_sbyte3.TestData_LHS[i];
                result &= v3_4.x0  == TestData_LHS[i].x0  &
                          v3_4.x1  == TestData_LHS[i].x1  &
                          v3_4.x2  == TestData_LHS[i].x2  &
                          v3_4.x3  == TestData_LHS[i].x3  &
                          v3_4.x4  == t_sbyte3.TestData_LHS[i].x  &
                          v3_4.x5  == t_sbyte3.TestData_LHS[i].y  &
                          v3_4.x6  == t_sbyte3.TestData_LHS[i].z &
                          v3_4.x7  == TestData_LHS[i].x7  &
                          v3_4.x8  == TestData_LHS[i].x8  &
                          v3_4.x9  == TestData_LHS[i].x9  &
                          v3_4.x10 == TestData_LHS[i].x10 &
                          v3_4.x11 == TestData_LHS[i].x11 &
                          v3_4.x12 == TestData_LHS[i].x12 &
                          v3_4.x13 == TestData_LHS[i].x13 &
                          v3_4.x14 == TestData_LHS[i].x14 &
                          v3_4.x15 == TestData_LHS[i].x15 &
                          v3_4.x16 == TestData_LHS[i].x16 &
                          v3_4.x17 == TestData_LHS[i].x17 &
                          v3_4.x18 == TestData_LHS[i].x18 &
                          v3_4.x19 == TestData_LHS[i].x19 &
                          v3_4.x20 == TestData_LHS[i].x20 &
                          v3_4.x21 == TestData_LHS[i].x21 &
                          v3_4.x22 == TestData_LHS[i].x22 &
                          v3_4.x23 == TestData_LHS[i].x23 &
                          v3_4.x24 == TestData_LHS[i].x24 &
                          v3_4.x25 == TestData_LHS[i].x25 &
                          v3_4.x26 == TestData_LHS[i].x26 &
                          v3_4.x27 == TestData_LHS[i].x27 &
                          v3_4.x28 == TestData_LHS[i].x28 &
                          v3_4.x29 == TestData_LHS[i].x29 &
                          v3_4.x30 == TestData_LHS[i].x30 &
                          v3_4.x31 == TestData_LHS[i].x31;

                sbyte32 v3_5 = TestData_LHS[i];
                v3_5.v3_5 = t_sbyte3.TestData_LHS[i];
                result &= v3_5.x0  == TestData_LHS[i].x0  &
                          v3_5.x1  == TestData_LHS[i].x1  &
                          v3_5.x2  == TestData_LHS[i].x2  &
                          v3_5.x3  == TestData_LHS[i].x3  &
                          v3_5.x4  == TestData_LHS[i].x4  &
                          v3_5.x5  == t_sbyte3.TestData_LHS[i].x  &
                          v3_5.x6  == t_sbyte3.TestData_LHS[i].y  &
                          v3_5.x7  == t_sbyte3.TestData_LHS[i].z &
                          v3_5.x8  == TestData_LHS[i].x8  &
                          v3_5.x9  == TestData_LHS[i].x9  &
                          v3_5.x10 == TestData_LHS[i].x10 &
                          v3_5.x11 == TestData_LHS[i].x11 &
                          v3_5.x12 == TestData_LHS[i].x12 &
                          v3_5.x13 == TestData_LHS[i].x13 &
                          v3_5.x14 == TestData_LHS[i].x14 &
                          v3_5.x15 == TestData_LHS[i].x15 &
                          v3_5.x16 == TestData_LHS[i].x16 &
                          v3_5.x17 == TestData_LHS[i].x17 &
                          v3_5.x18 == TestData_LHS[i].x18 &
                          v3_5.x19 == TestData_LHS[i].x19 &
                          v3_5.x20 == TestData_LHS[i].x20 &
                          v3_5.x21 == TestData_LHS[i].x21 &
                          v3_5.x22 == TestData_LHS[i].x22 &
                          v3_5.x23 == TestData_LHS[i].x23 &
                          v3_5.x24 == TestData_LHS[i].x24 &
                          v3_5.x25 == TestData_LHS[i].x25 &
                          v3_5.x26 == TestData_LHS[i].x26 &
                          v3_5.x27 == TestData_LHS[i].x27 &
                          v3_5.x28 == TestData_LHS[i].x28 &
                          v3_5.x29 == TestData_LHS[i].x29 &
                          v3_5.x30 == TestData_LHS[i].x30 &
                          v3_5.x31 == TestData_LHS[i].x31;

                sbyte32 v3_6 = TestData_LHS[i];
                v3_6.v3_6 = t_sbyte3.TestData_LHS[i];
                result &= v3_6.x0  == TestData_LHS[i].x0  &
                          v3_6.x1  == TestData_LHS[i].x1  &
                          v3_6.x2  == TestData_LHS[i].x2  &
                          v3_6.x3  == TestData_LHS[i].x3  &
                          v3_6.x4  == TestData_LHS[i].x4  &
                          v3_6.x5  == TestData_LHS[i].x5  &
                          v3_6.x6  == t_sbyte3.TestData_LHS[i].x  &
                          v3_6.x7  == t_sbyte3.TestData_LHS[i].y  &
                          v3_6.x8  == t_sbyte3.TestData_LHS[i].z &
                          v3_6.x9  == TestData_LHS[i].x9  &
                          v3_6.x10 == TestData_LHS[i].x10 &
                          v3_6.x11 == TestData_LHS[i].x11 &
                          v3_6.x12 == TestData_LHS[i].x12 &
                          v3_6.x13 == TestData_LHS[i].x13 &
                          v3_6.x14 == TestData_LHS[i].x14 &
                          v3_6.x15 == TestData_LHS[i].x15 &
                          v3_6.x16 == TestData_LHS[i].x16 &
                          v3_6.x17 == TestData_LHS[i].x17 &
                          v3_6.x18 == TestData_LHS[i].x18 &
                          v3_6.x19 == TestData_LHS[i].x19 &
                          v3_6.x20 == TestData_LHS[i].x20 &
                          v3_6.x21 == TestData_LHS[i].x21 &
                          v3_6.x22 == TestData_LHS[i].x22 &
                          v3_6.x23 == TestData_LHS[i].x23 &
                          v3_6.x24 == TestData_LHS[i].x24 &
                          v3_6.x25 == TestData_LHS[i].x25 &
                          v3_6.x26 == TestData_LHS[i].x26 &
                          v3_6.x27 == TestData_LHS[i].x27 &
                          v3_6.x28 == TestData_LHS[i].x28 &
                          v3_6.x29 == TestData_LHS[i].x29 &
                          v3_6.x30 == TestData_LHS[i].x30 &
                          v3_6.x31 == TestData_LHS[i].x31;

                sbyte32 v3_7 = TestData_LHS[i];
                v3_7.v3_7 = t_sbyte3.TestData_LHS[i];
                result &= v3_7.x0  == TestData_LHS[i].x0  &
                          v3_7.x1  == TestData_LHS[i].x1  &
                          v3_7.x2  == TestData_LHS[i].x2  &
                          v3_7.x3  == TestData_LHS[i].x3  &
                          v3_7.x4  == TestData_LHS[i].x4  &
                          v3_7.x5  == TestData_LHS[i].x5  &
                          v3_7.x6  == TestData_LHS[i].x6  &
                          v3_7.x7  == t_sbyte3.TestData_LHS[i].x  &
                          v3_7.x8  == t_sbyte3.TestData_LHS[i].y  &
                          v3_7.x9  == t_sbyte3.TestData_LHS[i].z &
                          v3_7.x10 == TestData_LHS[i].x10 &
                          v3_7.x11 == TestData_LHS[i].x11 &
                          v3_7.x12 == TestData_LHS[i].x12 &
                          v3_7.x13 == TestData_LHS[i].x13 &
                          v3_7.x14 == TestData_LHS[i].x14 &
                          v3_7.x15 == TestData_LHS[i].x15 &
                          v3_7.x16 == TestData_LHS[i].x16 &
                          v3_7.x17 == TestData_LHS[i].x17 &
                          v3_7.x18 == TestData_LHS[i].x18 &
                          v3_7.x19 == TestData_LHS[i].x19 &
                          v3_7.x20 == TestData_LHS[i].x20 &
                          v3_7.x21 == TestData_LHS[i].x21 &
                          v3_7.x22 == TestData_LHS[i].x22 &
                          v3_7.x23 == TestData_LHS[i].x23 &
                          v3_7.x24 == TestData_LHS[i].x24 &
                          v3_7.x25 == TestData_LHS[i].x25 &
                          v3_7.x26 == TestData_LHS[i].x26 &
                          v3_7.x27 == TestData_LHS[i].x27 &
                          v3_7.x28 == TestData_LHS[i].x28 &
                          v3_7.x29 == TestData_LHS[i].x29 &
                          v3_7.x30 == TestData_LHS[i].x30 &
                          v3_7.x31 == TestData_LHS[i].x31;

                sbyte32 v3_8 = TestData_LHS[i];
                v3_8.v3_8 = t_sbyte3.TestData_LHS[i];
                result &= v3_8.x0  == TestData_LHS[i].x0  &
                          v3_8.x1  == TestData_LHS[i].x1  &
                          v3_8.x2  == TestData_LHS[i].x2  &
                          v3_8.x3  == TestData_LHS[i].x3  &
                          v3_8.x4  == TestData_LHS[i].x4  &
                          v3_8.x5  == TestData_LHS[i].x5  &
                          v3_8.x6  == TestData_LHS[i].x6  &
                          v3_8.x7  == TestData_LHS[i].x7  &
                          v3_8.x8  == t_sbyte3.TestData_LHS[i].x &
                          v3_8.x9  == t_sbyte3.TestData_LHS[i].y &
                          v3_8.x10 == t_sbyte3.TestData_LHS[i].z &
                          v3_8.x11 == TestData_LHS[i].x11 &
                          v3_8.x12 == TestData_LHS[i].x12 &
                          v3_8.x13 == TestData_LHS[i].x13 &
                          v3_8.x14 == TestData_LHS[i].x14 &
                          v3_8.x15 == TestData_LHS[i].x15 &
                          v3_8.x16 == TestData_LHS[i].x16 &
                          v3_8.x17 == TestData_LHS[i].x17 &
                          v3_8.x18 == TestData_LHS[i].x18 &
                          v3_8.x19 == TestData_LHS[i].x19 &
                          v3_8.x20 == TestData_LHS[i].x20 &
                          v3_8.x21 == TestData_LHS[i].x21 &
                          v3_8.x22 == TestData_LHS[i].x22 &
                          v3_8.x23 == TestData_LHS[i].x23 &
                          v3_8.x24 == TestData_LHS[i].x24 &
                          v3_8.x25 == TestData_LHS[i].x25 &
                          v3_8.x26 == TestData_LHS[i].x26 &
                          v3_8.x27 == TestData_LHS[i].x27 &
                          v3_8.x28 == TestData_LHS[i].x28 &
                          v3_8.x29 == TestData_LHS[i].x29 &
                          v3_8.x30 == TestData_LHS[i].x30 &
                          v3_8.x31 == TestData_LHS[i].x31;

                sbyte32 v3_9 = TestData_LHS[i];
                v3_9.v3_9 = t_sbyte3.TestData_LHS[i];
                result &= v3_9.x0  == TestData_LHS[i].x0  &
                          v3_9.x1  == TestData_LHS[i].x1  &
                          v3_9.x2  == TestData_LHS[i].x2  &
                          v3_9.x3  == TestData_LHS[i].x3  &
                          v3_9.x4  == TestData_LHS[i].x4  &
                          v3_9.x5  == TestData_LHS[i].x5  &
                          v3_9.x6  == TestData_LHS[i].x6  &
                          v3_9.x7  == TestData_LHS[i].x7  &
                          v3_9.x8  == TestData_LHS[i].x8  &
                          v3_9.x9  == t_sbyte3.TestData_LHS[i].x &
                          v3_9.x10 == t_sbyte3.TestData_LHS[i].y &
                          v3_9.x11 == t_sbyte3.TestData_LHS[i].z &
                          v3_9.x12 == TestData_LHS[i].x12 &
                          v3_9.x13 == TestData_LHS[i].x13 &
                          v3_9.x14 == TestData_LHS[i].x14 &
                          v3_9.x15 == TestData_LHS[i].x15 &
                          v3_9.x16 == TestData_LHS[i].x16 &
                          v3_9.x17 == TestData_LHS[i].x17 &
                          v3_9.x18 == TestData_LHS[i].x18 &
                          v3_9.x19 == TestData_LHS[i].x19 &
                          v3_9.x20 == TestData_LHS[i].x20 &
                          v3_9.x21 == TestData_LHS[i].x21 &
                          v3_9.x22 == TestData_LHS[i].x22 &
                          v3_9.x23 == TestData_LHS[i].x23 &
                          v3_9.x24 == TestData_LHS[i].x24 &
                          v3_9.x25 == TestData_LHS[i].x25 &
                          v3_9.x26 == TestData_LHS[i].x26 &
                          v3_9.x27 == TestData_LHS[i].x27 &
                          v3_9.x28 == TestData_LHS[i].x28 &
                          v3_9.x29 == TestData_LHS[i].x29 &
                          v3_9.x30 == TestData_LHS[i].x30 &
                          v3_9.x31 == TestData_LHS[i].x31;

                sbyte32 v3_10 = TestData_LHS[i];
                v3_10.v3_10 = t_sbyte3.TestData_LHS[i];
                result &= v3_10.x0  == TestData_LHS[i].x0  &
                          v3_10.x1  == TestData_LHS[i].x1  &
                          v3_10.x2  == TestData_LHS[i].x2  &
                          v3_10.x3  == TestData_LHS[i].x3  &
                          v3_10.x4  == TestData_LHS[i].x4  &
                          v3_10.x5  == TestData_LHS[i].x5  &
                          v3_10.x6  == TestData_LHS[i].x6  &
                          v3_10.x7  == TestData_LHS[i].x7  &
                          v3_10.x8  == TestData_LHS[i].x8  &
                          v3_10.x9  == TestData_LHS[i].x9  &
                          v3_10.x10 == t_sbyte3.TestData_LHS[i].x &
                          v3_10.x11 == t_sbyte3.TestData_LHS[i].y &
                          v3_10.x12 == t_sbyte3.TestData_LHS[i].z &
                          v3_10.x13 == TestData_LHS[i].x13 &
                          v3_10.x14 == TestData_LHS[i].x14 &
                          v3_10.x15 == TestData_LHS[i].x15 &
                          v3_10.x16 == TestData_LHS[i].x16 &
                          v3_10.x17 == TestData_LHS[i].x17 &
                          v3_10.x18 == TestData_LHS[i].x18 &
                          v3_10.x19 == TestData_LHS[i].x19 &
                          v3_10.x20 == TestData_LHS[i].x20 &
                          v3_10.x21 == TestData_LHS[i].x21 &
                          v3_10.x22 == TestData_LHS[i].x22 &
                          v3_10.x23 == TestData_LHS[i].x23 &
                          v3_10.x24 == TestData_LHS[i].x24 &
                          v3_10.x25 == TestData_LHS[i].x25 &
                          v3_10.x26 == TestData_LHS[i].x26 &
                          v3_10.x27 == TestData_LHS[i].x27 &
                          v3_10.x28 == TestData_LHS[i].x28 &
                          v3_10.x29 == TestData_LHS[i].x29 &
                          v3_10.x30 == TestData_LHS[i].x30 &
                          v3_10.x31 == TestData_LHS[i].x31;

                sbyte32 v3_11 = TestData_LHS[i];
                v3_11.v3_11 = t_sbyte3.TestData_LHS[i];
                result &= v3_11.x0  == TestData_LHS[i].x0  &
                          v3_11.x1  == TestData_LHS[i].x1  &
                          v3_11.x2  == TestData_LHS[i].x2  &
                          v3_11.x3  == TestData_LHS[i].x3  &
                          v3_11.x4  == TestData_LHS[i].x4  &
                          v3_11.x5  == TestData_LHS[i].x5  &
                          v3_11.x6  == TestData_LHS[i].x6  &
                          v3_11.x7  == TestData_LHS[i].x7  &
                          v3_11.x8  == TestData_LHS[i].x8  &
                          v3_11.x9  == TestData_LHS[i].x9  &
                          v3_11.x10 == TestData_LHS[i].x10 &
                          v3_11.x11 == t_sbyte3.TestData_LHS[i].x &
                          v3_11.x12 == t_sbyte3.TestData_LHS[i].y &
                          v3_11.x13 == t_sbyte3.TestData_LHS[i].z &
                          v3_11.x14 == TestData_LHS[i].x14 &
                          v3_11.x15 == TestData_LHS[i].x15 &
                          v3_11.x16 == TestData_LHS[i].x16 &
                          v3_11.x17 == TestData_LHS[i].x17 &
                          v3_11.x18 == TestData_LHS[i].x18 &
                          v3_11.x19 == TestData_LHS[i].x19 &
                          v3_11.x20 == TestData_LHS[i].x20 &
                          v3_11.x21 == TestData_LHS[i].x21 &
                          v3_11.x22 == TestData_LHS[i].x22 &
                          v3_11.x23 == TestData_LHS[i].x23 &
                          v3_11.x24 == TestData_LHS[i].x24 &
                          v3_11.x25 == TestData_LHS[i].x25 &
                          v3_11.x26 == TestData_LHS[i].x26 &
                          v3_11.x27 == TestData_LHS[i].x27 &
                          v3_11.x28 == TestData_LHS[i].x28 &
                          v3_11.x29 == TestData_LHS[i].x29 &
                          v3_11.x30 == TestData_LHS[i].x30 &
                          v3_11.x31 == TestData_LHS[i].x31;

                sbyte32 v3_12 = TestData_LHS[i];
                v3_12.v3_12 = t_sbyte3.TestData_LHS[i];
                result &= v3_12.x0  == TestData_LHS[i].x0  &
                          v3_12.x1  == TestData_LHS[i].x1  &
                          v3_12.x2  == TestData_LHS[i].x2  &
                          v3_12.x3  == TestData_LHS[i].x3  &
                          v3_12.x4  == TestData_LHS[i].x4  &
                          v3_12.x5  == TestData_LHS[i].x5  &
                          v3_12.x6  == TestData_LHS[i].x6  &
                          v3_12.x7  == TestData_LHS[i].x7  &
                          v3_12.x8  == TestData_LHS[i].x8  &
                          v3_12.x9  == TestData_LHS[i].x9  &
                          v3_12.x10 == TestData_LHS[i].x10 &
                          v3_12.x11 == TestData_LHS[i].x11 &
                          v3_12.x12 == t_sbyte3.TestData_LHS[i].x &
                          v3_12.x13 == t_sbyte3.TestData_LHS[i].y &
                          v3_12.x14 == t_sbyte3.TestData_LHS[i].z &
                          v3_12.x15 == TestData_LHS[i].x15 &
                          v3_12.x16 == TestData_LHS[i].x16 &
                          v3_12.x17 == TestData_LHS[i].x17 &
                          v3_12.x18 == TestData_LHS[i].x18 &
                          v3_12.x19 == TestData_LHS[i].x19 &
                          v3_12.x20 == TestData_LHS[i].x20 &
                          v3_12.x21 == TestData_LHS[i].x21 &
                          v3_12.x22 == TestData_LHS[i].x22 &
                          v3_12.x23 == TestData_LHS[i].x23 &
                          v3_12.x24 == TestData_LHS[i].x24 &
                          v3_12.x25 == TestData_LHS[i].x25 &
                          v3_12.x26 == TestData_LHS[i].x26 &
                          v3_12.x27 == TestData_LHS[i].x27 &
                          v3_12.x28 == TestData_LHS[i].x28 &
                          v3_12.x29 == TestData_LHS[i].x29 &
                          v3_12.x30 == TestData_LHS[i].x30 &
                          v3_12.x31 == TestData_LHS[i].x31;

                sbyte32 v3_13 = TestData_LHS[i];
                v3_13.v3_13 = t_sbyte3.TestData_LHS[i];
                result &= v3_13.x0  == TestData_LHS[i].x0  &
                          v3_13.x1  == TestData_LHS[i].x1  &
                          v3_13.x2  == TestData_LHS[i].x2  &
                          v3_13.x3  == TestData_LHS[i].x3  &
                          v3_13.x4  == TestData_LHS[i].x4  &
                          v3_13.x5  == TestData_LHS[i].x5  &
                          v3_13.x6  == TestData_LHS[i].x6  &
                          v3_13.x7  == TestData_LHS[i].x7  &
                          v3_13.x8  == TestData_LHS[i].x8  &
                          v3_13.x9  == TestData_LHS[i].x9  &
                          v3_13.x10 == TestData_LHS[i].x10 &
                          v3_13.x11 == TestData_LHS[i].x11 &
                          v3_13.x12 == TestData_LHS[i].x12 &
                          v3_13.x13 == t_sbyte3.TestData_LHS[i].x &
                          v3_13.x14 == t_sbyte3.TestData_LHS[i].y &
                          v3_13.x15 == t_sbyte3.TestData_LHS[i].z &
                          v3_13.x16 == TestData_LHS[i].x16 &
                          v3_13.x17 == TestData_LHS[i].x17 &
                          v3_13.x18 == TestData_LHS[i].x18 &
                          v3_13.x19 == TestData_LHS[i].x19 &
                          v3_13.x20 == TestData_LHS[i].x20 &
                          v3_13.x21 == TestData_LHS[i].x21 &
                          v3_13.x22 == TestData_LHS[i].x22 &
                          v3_13.x23 == TestData_LHS[i].x23 &
                          v3_13.x24 == TestData_LHS[i].x24 &
                          v3_13.x25 == TestData_LHS[i].x25 &
                          v3_13.x26 == TestData_LHS[i].x26 &
                          v3_13.x27 == TestData_LHS[i].x27 &
                          v3_13.x28 == TestData_LHS[i].x28 &
                          v3_13.x29 == TestData_LHS[i].x29 &
                          v3_13.x30 == TestData_LHS[i].x30 &
                          v3_13.x31 == TestData_LHS[i].x31;

                sbyte32 v3_14 = TestData_LHS[i];
                v3_14.v3_14 = t_sbyte3.TestData_LHS[i];
                result &= v3_14.x0  == TestData_LHS[i].x0  &
                          v3_14.x1  == TestData_LHS[i].x1  &
                          v3_14.x2  == TestData_LHS[i].x2  &
                          v3_14.x3  == TestData_LHS[i].x3  &
                          v3_14.x4  == TestData_LHS[i].x4  &
                          v3_14.x5  == TestData_LHS[i].x5  &
                          v3_14.x6  == TestData_LHS[i].x6  &
                          v3_14.x7  == TestData_LHS[i].x7  &
                          v3_14.x8  == TestData_LHS[i].x8  &
                          v3_14.x9  == TestData_LHS[i].x9  &
                          v3_14.x10 == TestData_LHS[i].x10 &
                          v3_14.x11 == TestData_LHS[i].x11 &
                          v3_14.x12 == TestData_LHS[i].x12 &
                          v3_14.x13 == TestData_LHS[i].x13 &
                          v3_14.x14 == t_sbyte3.TestData_LHS[i].x &
                          v3_14.x15 == t_sbyte3.TestData_LHS[i].y &
                          v3_14.x16 == t_sbyte3.TestData_LHS[i].z &
                          v3_14.x17 == TestData_LHS[i].x17 &
                          v3_14.x18 == TestData_LHS[i].x18 &
                          v3_14.x19 == TestData_LHS[i].x19 &
                          v3_14.x20 == TestData_LHS[i].x20 &
                          v3_14.x21 == TestData_LHS[i].x21 &
                          v3_14.x22 == TestData_LHS[i].x22 &
                          v3_14.x23 == TestData_LHS[i].x23 &
                          v3_14.x24 == TestData_LHS[i].x24 &
                          v3_14.x25 == TestData_LHS[i].x25 &
                          v3_14.x26 == TestData_LHS[i].x26 &
                          v3_14.x27 == TestData_LHS[i].x27 &
                          v3_14.x28 == TestData_LHS[i].x28 &
                          v3_14.x29 == TestData_LHS[i].x29 &
                          v3_14.x30 == TestData_LHS[i].x30 &
                          v3_14.x31 == TestData_LHS[i].x31;

                sbyte32 v3_15 = TestData_LHS[i];
                v3_15.v3_15 = t_sbyte3.TestData_LHS[i];
                result &= v3_15.x0  == TestData_LHS[i].x0  &
                          v3_15.x1  == TestData_LHS[i].x1  &
                          v3_15.x2  == TestData_LHS[i].x2  &
                          v3_15.x3  == TestData_LHS[i].x3  &
                          v3_15.x4  == TestData_LHS[i].x4  &
                          v3_15.x5  == TestData_LHS[i].x5  &
                          v3_15.x6  == TestData_LHS[i].x6  &
                          v3_15.x7  == TestData_LHS[i].x7  &
                          v3_15.x8  == TestData_LHS[i].x8  &
                          v3_15.x9  == TestData_LHS[i].x9  &
                          v3_15.x10 == TestData_LHS[i].x10 &
                          v3_15.x11 == TestData_LHS[i].x11 &
                          v3_15.x12 == TestData_LHS[i].x12 &
                          v3_15.x13 == TestData_LHS[i].x13 &
                          v3_15.x14 == TestData_LHS[i].x14 &
                          v3_15.x15 == t_sbyte3.TestData_LHS[i].x &
                          v3_15.x16 == t_sbyte3.TestData_LHS[i].y &
                          v3_15.x17 == t_sbyte3.TestData_LHS[i].z &
                          v3_15.x18 == TestData_LHS[i].x18 &
                          v3_15.x19 == TestData_LHS[i].x19 &
                          v3_15.x20 == TestData_LHS[i].x20 &
                          v3_15.x21 == TestData_LHS[i].x21 &
                          v3_15.x22 == TestData_LHS[i].x22 &
                          v3_15.x23 == TestData_LHS[i].x23 &
                          v3_15.x24 == TestData_LHS[i].x24 &
                          v3_15.x25 == TestData_LHS[i].x25 &
                          v3_15.x26 == TestData_LHS[i].x26 &
                          v3_15.x27 == TestData_LHS[i].x27 &
                          v3_15.x28 == TestData_LHS[i].x28 &
                          v3_15.x29 == TestData_LHS[i].x29 &
                          v3_15.x30 == TestData_LHS[i].x30 &
                          v3_15.x31 == TestData_LHS[i].x31;

                sbyte32 v3_16 = TestData_LHS[i];
                v3_16.v3_16 = t_sbyte3.TestData_LHS[i];
                result &= v3_16.x0  == TestData_LHS[i].x0  &
                          v3_16.x1  == TestData_LHS[i].x1  &
                          v3_16.x2  == TestData_LHS[i].x2  &
                          v3_16.x3  == TestData_LHS[i].x3  &
                          v3_16.x4  == TestData_LHS[i].x4  &
                          v3_16.x5  == TestData_LHS[i].x5  &
                          v3_16.x6  == TestData_LHS[i].x6  &
                          v3_16.x7  == TestData_LHS[i].x7  &
                          v3_16.x8  == TestData_LHS[i].x8  &
                          v3_16.x9  == TestData_LHS[i].x9  &
                          v3_16.x10 == TestData_LHS[i].x10 &
                          v3_16.x11 == TestData_LHS[i].x11 &
                          v3_16.x12 == TestData_LHS[i].x12 &
                          v3_16.x13 == TestData_LHS[i].x13 &
                          v3_16.x14 == TestData_LHS[i].x14 &
                          v3_16.x15 == TestData_LHS[i].x15 &
                          v3_16.x16 == t_sbyte3.TestData_LHS[i].x &
                          v3_16.x17 == t_sbyte3.TestData_LHS[i].y &
                          v3_16.x18 == t_sbyte3.TestData_LHS[i].z &
                          v3_16.x19 == TestData_LHS[i].x19 &
                          v3_16.x20 == TestData_LHS[i].x20 &
                          v3_16.x21 == TestData_LHS[i].x21 &
                          v3_16.x22 == TestData_LHS[i].x22 &
                          v3_16.x23 == TestData_LHS[i].x23 &
                          v3_16.x24 == TestData_LHS[i].x24 &
                          v3_16.x25 == TestData_LHS[i].x25 &
                          v3_16.x26 == TestData_LHS[i].x26 &
                          v3_16.x27 == TestData_LHS[i].x27 &
                          v3_16.x28 == TestData_LHS[i].x28 &
                          v3_16.x29 == TestData_LHS[i].x29 &
                          v3_16.x30 == TestData_LHS[i].x30 &
                          v3_16.x31 == TestData_LHS[i].x31;

                sbyte32 v3_17 = TestData_LHS[i];
                v3_17.v3_17 = t_sbyte3.TestData_LHS[i];
                result &= v3_17.x0  == TestData_LHS[i].x0  &
                          v3_17.x1  == TestData_LHS[i].x1  &
                          v3_17.x2  == TestData_LHS[i].x2  &
                          v3_17.x3  == TestData_LHS[i].x3  &
                          v3_17.x4  == TestData_LHS[i].x4  &
                          v3_17.x5  == TestData_LHS[i].x5  &
                          v3_17.x6  == TestData_LHS[i].x6  &
                          v3_17.x7  == TestData_LHS[i].x7  &
                          v3_17.x8  == TestData_LHS[i].x8  &
                          v3_17.x9  == TestData_LHS[i].x9  &
                          v3_17.x10 == TestData_LHS[i].x10 &
                          v3_17.x11 == TestData_LHS[i].x11 &
                          v3_17.x12 == TestData_LHS[i].x12 &
                          v3_17.x13 == TestData_LHS[i].x13 &
                          v3_17.x14 == TestData_LHS[i].x14 &
                          v3_17.x15 == TestData_LHS[i].x15 &
                          v3_17.x16 == TestData_LHS[i].x16 &
                          v3_17.x17 == t_sbyte3.TestData_LHS[i].x &
                          v3_17.x18 == t_sbyte3.TestData_LHS[i].y &
                          v3_17.x19 == t_sbyte3.TestData_LHS[i].z &
                          v3_17.x20 == TestData_LHS[i].x20 &
                          v3_17.x21 == TestData_LHS[i].x21 &
                          v3_17.x22 == TestData_LHS[i].x22 &
                          v3_17.x23 == TestData_LHS[i].x23 &
                          v3_17.x24 == TestData_LHS[i].x24 &
                          v3_17.x25 == TestData_LHS[i].x25 &
                          v3_17.x26 == TestData_LHS[i].x26 &
                          v3_17.x27 == TestData_LHS[i].x27 &
                          v3_17.x28 == TestData_LHS[i].x28 &
                          v3_17.x29 == TestData_LHS[i].x29 &
                          v3_17.x30 == TestData_LHS[i].x30 &
                          v3_17.x31 == TestData_LHS[i].x31;

                sbyte32 v3_18 = TestData_LHS[i];
                v3_18.v3_18 = t_sbyte3.TestData_LHS[i];
                result &= v3_18.x0  == TestData_LHS[i].x0  &
                          v3_18.x1  == TestData_LHS[i].x1  &
                          v3_18.x2  == TestData_LHS[i].x2  &
                          v3_18.x3  == TestData_LHS[i].x3  &
                          v3_18.x4  == TestData_LHS[i].x4  &
                          v3_18.x5  == TestData_LHS[i].x5  &
                          v3_18.x6  == TestData_LHS[i].x6  &
                          v3_18.x7  == TestData_LHS[i].x7  &
                          v3_18.x8  == TestData_LHS[i].x8  &
                          v3_18.x9  == TestData_LHS[i].x9  &
                          v3_18.x10 == TestData_LHS[i].x10 &
                          v3_18.x11 == TestData_LHS[i].x11 &
                          v3_18.x12 == TestData_LHS[i].x12 &
                          v3_18.x13 == TestData_LHS[i].x13 &
                          v3_18.x14 == TestData_LHS[i].x14 &
                          v3_18.x15 == TestData_LHS[i].x15 &
                          v3_18.x16 == TestData_LHS[i].x16 &
                          v3_18.x17 == TestData_LHS[i].x17 &
                          v3_18.x18 == t_sbyte3.TestData_LHS[i].x &
                          v3_18.x19 == t_sbyte3.TestData_LHS[i].y &
                          v3_18.x20 == t_sbyte3.TestData_LHS[i].z &
                          v3_18.x21 == TestData_LHS[i].x21 &
                          v3_18.x22 == TestData_LHS[i].x22 &
                          v3_18.x23 == TestData_LHS[i].x23 &
                          v3_18.x24 == TestData_LHS[i].x24 &
                          v3_18.x25 == TestData_LHS[i].x25 &
                          v3_18.x26 == TestData_LHS[i].x26 &
                          v3_18.x27 == TestData_LHS[i].x27 &
                          v3_18.x28 == TestData_LHS[i].x28 &
                          v3_18.x29 == TestData_LHS[i].x29 &
                          v3_18.x30 == TestData_LHS[i].x30 &
                          v3_18.x31 == TestData_LHS[i].x31;

                sbyte32 v3_19 = TestData_LHS[i];
                v3_19.v3_19 = t_sbyte3.TestData_LHS[i];
                result &= v3_19.x0  == TestData_LHS[i].x0  &
                          v3_19.x1  == TestData_LHS[i].x1  &
                          v3_19.x2  == TestData_LHS[i].x2  &
                          v3_19.x3  == TestData_LHS[i].x3  &
                          v3_19.x4  == TestData_LHS[i].x4  &
                          v3_19.x5  == TestData_LHS[i].x5  &
                          v3_19.x6  == TestData_LHS[i].x6  &
                          v3_19.x7  == TestData_LHS[i].x7  &
                          v3_19.x8  == TestData_LHS[i].x8  &
                          v3_19.x9  == TestData_LHS[i].x9  &
                          v3_19.x10 == TestData_LHS[i].x10 &
                          v3_19.x11 == TestData_LHS[i].x11 &
                          v3_19.x12 == TestData_LHS[i].x12 &
                          v3_19.x13 == TestData_LHS[i].x13 &
                          v3_19.x14 == TestData_LHS[i].x14 &
                          v3_19.x15 == TestData_LHS[i].x15 &
                          v3_19.x16 == TestData_LHS[i].x16 &
                          v3_19.x17 == TestData_LHS[i].x17 &
                          v3_19.x18 == TestData_LHS[i].x18 &
                          v3_19.x19 == t_sbyte3.TestData_LHS[i].x &
                          v3_19.x20 == t_sbyte3.TestData_LHS[i].y &
                          v3_19.x21 == t_sbyte3.TestData_LHS[i].z &
                          v3_19.x22 == TestData_LHS[i].x22 &
                          v3_19.x23 == TestData_LHS[i].x23 &
                          v3_19.x24 == TestData_LHS[i].x24 &
                          v3_19.x25 == TestData_LHS[i].x25 &
                          v3_19.x26 == TestData_LHS[i].x26 &
                          v3_19.x27 == TestData_LHS[i].x27 &
                          v3_19.x28 == TestData_LHS[i].x28 &
                          v3_19.x29 == TestData_LHS[i].x29 &
                          v3_19.x30 == TestData_LHS[i].x30 &
                          v3_19.x31 == TestData_LHS[i].x31;

                sbyte32 v3_20 = TestData_LHS[i];
                v3_20.v3_20 = t_sbyte3.TestData_LHS[i];
                result &= v3_20.x0  == TestData_LHS[i].x0  &
                          v3_20.x1  == TestData_LHS[i].x1  &
                          v3_20.x2  == TestData_LHS[i].x2  &
                          v3_20.x3  == TestData_LHS[i].x3  &
                          v3_20.x4  == TestData_LHS[i].x4  &
                          v3_20.x5  == TestData_LHS[i].x5  &
                          v3_20.x6  == TestData_LHS[i].x6  &
                          v3_20.x7  == TestData_LHS[i].x7  &
                          v3_20.x8  == TestData_LHS[i].x8  &
                          v3_20.x9  == TestData_LHS[i].x9  &
                          v3_20.x10 == TestData_LHS[i].x10 &
                          v3_20.x11 == TestData_LHS[i].x11 &
                          v3_20.x12 == TestData_LHS[i].x12 &
                          v3_20.x13 == TestData_LHS[i].x13 &
                          v3_20.x14 == TestData_LHS[i].x14 &
                          v3_20.x15 == TestData_LHS[i].x15 &
                          v3_20.x16 == TestData_LHS[i].x16 &
                          v3_20.x17 == TestData_LHS[i].x17 &
                          v3_20.x18 == TestData_LHS[i].x18 &
                          v3_20.x19 == TestData_LHS[i].x19 &
                          v3_20.x20 == t_sbyte3.TestData_LHS[i].x &
                          v3_20.x21 == t_sbyte3.TestData_LHS[i].y &
                          v3_20.x22 == t_sbyte3.TestData_LHS[i].z &
                          v3_20.x23 == TestData_LHS[i].x23 &
                          v3_20.x24 == TestData_LHS[i].x24 &
                          v3_20.x25 == TestData_LHS[i].x25 &
                          v3_20.x26 == TestData_LHS[i].x26 &
                          v3_20.x27 == TestData_LHS[i].x27 &
                          v3_20.x28 == TestData_LHS[i].x28 &
                          v3_20.x29 == TestData_LHS[i].x29 &
                          v3_20.x30 == TestData_LHS[i].x30 &
                          v3_20.x31 == TestData_LHS[i].x31;

                sbyte32 v3_21 = TestData_LHS[i];
                v3_21.v3_21 = t_sbyte3.TestData_LHS[i];
                result &= v3_21.x0  == TestData_LHS[i].x0  &
                          v3_21.x1  == TestData_LHS[i].x1  &
                          v3_21.x2  == TestData_LHS[i].x2  &
                          v3_21.x3  == TestData_LHS[i].x3  &
                          v3_21.x4  == TestData_LHS[i].x4  &
                          v3_21.x5  == TestData_LHS[i].x5  &
                          v3_21.x6  == TestData_LHS[i].x6  &
                          v3_21.x7  == TestData_LHS[i].x7  &
                          v3_21.x8  == TestData_LHS[i].x8  &
                          v3_21.x9  == TestData_LHS[i].x9  &
                          v3_21.x10 == TestData_LHS[i].x10 &
                          v3_21.x11 == TestData_LHS[i].x11 &
                          v3_21.x12 == TestData_LHS[i].x12 &
                          v3_21.x13 == TestData_LHS[i].x13 &
                          v3_21.x14 == TestData_LHS[i].x14 &
                          v3_21.x15 == TestData_LHS[i].x15 &
                          v3_21.x16 == TestData_LHS[i].x16 &
                          v3_21.x17 == TestData_LHS[i].x17 &
                          v3_21.x18 == TestData_LHS[i].x18 &
                          v3_21.x19 == TestData_LHS[i].x19 &
                          v3_21.x20 == TestData_LHS[i].x20 &
                          v3_21.x21 == t_sbyte3.TestData_LHS[i].x &
                          v3_21.x22 == t_sbyte3.TestData_LHS[i].y &
                          v3_21.x23 == t_sbyte3.TestData_LHS[i].z &
                          v3_21.x24 == TestData_LHS[i].x24 &
                          v3_21.x25 == TestData_LHS[i].x25 &
                          v3_21.x26 == TestData_LHS[i].x26 &
                          v3_21.x27 == TestData_LHS[i].x27 &
                          v3_21.x28 == TestData_LHS[i].x28 &
                          v3_21.x29 == TestData_LHS[i].x29 &
                          v3_21.x30 == TestData_LHS[i].x30 &
                          v3_21.x31 == TestData_LHS[i].x31;

                sbyte32 v3_22 = TestData_LHS[i];
                v3_22.v3_22 = t_sbyte3.TestData_LHS[i];
                result &= v3_22.x0  == TestData_LHS[i].x0  &
                          v3_22.x1  == TestData_LHS[i].x1  &
                          v3_22.x2  == TestData_LHS[i].x2  &
                          v3_22.x3  == TestData_LHS[i].x3  &
                          v3_22.x4  == TestData_LHS[i].x4  &
                          v3_22.x5  == TestData_LHS[i].x5  &
                          v3_22.x6  == TestData_LHS[i].x6  &
                          v3_22.x7  == TestData_LHS[i].x7  &
                          v3_22.x8  == TestData_LHS[i].x8  &
                          v3_22.x9  == TestData_LHS[i].x9  &
                          v3_22.x10 == TestData_LHS[i].x10 &
                          v3_22.x11 == TestData_LHS[i].x11 &
                          v3_22.x12 == TestData_LHS[i].x12 &
                          v3_22.x13 == TestData_LHS[i].x13 &
                          v3_22.x14 == TestData_LHS[i].x14 &
                          v3_22.x15 == TestData_LHS[i].x15 &
                          v3_22.x16 == TestData_LHS[i].x16 &
                          v3_22.x17 == TestData_LHS[i].x17 &
                          v3_22.x18 == TestData_LHS[i].x18 &
                          v3_22.x19 == TestData_LHS[i].x19 &
                          v3_22.x20 == TestData_LHS[i].x20 &
                          v3_22.x21 == TestData_LHS[i].x21 &
                          v3_22.x22 == t_sbyte3.TestData_LHS[i].x &
                          v3_22.x23 == t_sbyte3.TestData_LHS[i].y &
                          v3_22.x24 == t_sbyte3.TestData_LHS[i].z &
                          v3_22.x25 == TestData_LHS[i].x25 &
                          v3_22.x26 == TestData_LHS[i].x26 &
                          v3_22.x27 == TestData_LHS[i].x27 &
                          v3_22.x28 == TestData_LHS[i].x28 &
                          v3_22.x29 == TestData_LHS[i].x29 &
                          v3_22.x30 == TestData_LHS[i].x30 &
                          v3_22.x31 == TestData_LHS[i].x31;

                sbyte32 v3_23 = TestData_LHS[i];
                v3_23.v3_23 = t_sbyte3.TestData_LHS[i];
                result &= v3_23.x0  == TestData_LHS[i].x0  &
                          v3_23.x1  == TestData_LHS[i].x1  &
                          v3_23.x2  == TestData_LHS[i].x2  &
                          v3_23.x3  == TestData_LHS[i].x3  &
                          v3_23.x4  == TestData_LHS[i].x4  &
                          v3_23.x5  == TestData_LHS[i].x5  &
                          v3_23.x6  == TestData_LHS[i].x6  &
                          v3_23.x7  == TestData_LHS[i].x7  &
                          v3_23.x8  == TestData_LHS[i].x8  &
                          v3_23.x9  == TestData_LHS[i].x9  &
                          v3_23.x10 == TestData_LHS[i].x10 &
                          v3_23.x11 == TestData_LHS[i].x11 &
                          v3_23.x12 == TestData_LHS[i].x12 &
                          v3_23.x13 == TestData_LHS[i].x13 &
                          v3_23.x14 == TestData_LHS[i].x14 &
                          v3_23.x15 == TestData_LHS[i].x15 &
                          v3_23.x16 == TestData_LHS[i].x16 &
                          v3_23.x17 == TestData_LHS[i].x17 &
                          v3_23.x18 == TestData_LHS[i].x18 &
                          v3_23.x19 == TestData_LHS[i].x19 &
                          v3_23.x20 == TestData_LHS[i].x20 &
                          v3_23.x21 == TestData_LHS[i].x21 &
                          v3_23.x22 == TestData_LHS[i].x22 &
                          v3_23.x23 == t_sbyte3.TestData_LHS[i].x &
                          v3_23.x24 == t_sbyte3.TestData_LHS[i].y &
                          v3_23.x25 == t_sbyte3.TestData_LHS[i].z &
                          v3_23.x26 == TestData_LHS[i].x26 &
                          v3_23.x27 == TestData_LHS[i].x27 &
                          v3_23.x28 == TestData_LHS[i].x28 &
                          v3_23.x29 == TestData_LHS[i].x29 &
                          v3_23.x30 == TestData_LHS[i].x30 &
                          v3_23.x31 == TestData_LHS[i].x31;

                sbyte32 v3_24 = TestData_LHS[i];
                v3_24.v3_24 = t_sbyte3.TestData_LHS[i];
                result &= v3_24.x0  == TestData_LHS[i].x0  &
                          v3_24.x1  == TestData_LHS[i].x1  &
                          v3_24.x2  == TestData_LHS[i].x2  &
                          v3_24.x3  == TestData_LHS[i].x3  &
                          v3_24.x4  == TestData_LHS[i].x4  &
                          v3_24.x5  == TestData_LHS[i].x5  &
                          v3_24.x6  == TestData_LHS[i].x6  &
                          v3_24.x7  == TestData_LHS[i].x7  &
                          v3_24.x8  == TestData_LHS[i].x8  &
                          v3_24.x9  == TestData_LHS[i].x9  &
                          v3_24.x10 == TestData_LHS[i].x10 &
                          v3_24.x11 == TestData_LHS[i].x11 &
                          v3_24.x12 == TestData_LHS[i].x12 &
                          v3_24.x13 == TestData_LHS[i].x13 &
                          v3_24.x14 == TestData_LHS[i].x14 &
                          v3_24.x15 == TestData_LHS[i].x15 &
                          v3_24.x16 == TestData_LHS[i].x16 &
                          v3_24.x17 == TestData_LHS[i].x17 &
                          v3_24.x18 == TestData_LHS[i].x18 &
                          v3_24.x19 == TestData_LHS[i].x19 &
                          v3_24.x20 == TestData_LHS[i].x20 &
                          v3_24.x21 == TestData_LHS[i].x21 &
                          v3_24.x22 == TestData_LHS[i].x22 &
                          v3_24.x23 == TestData_LHS[i].x23 &
                          v3_24.x24 == t_sbyte3.TestData_LHS[i].x &
                          v3_24.x25 == t_sbyte3.TestData_LHS[i].y &
                          v3_24.x26 == t_sbyte3.TestData_LHS[i].z &
                          v3_24.x27 == TestData_LHS[i].x27 &
                          v3_24.x28 == TestData_LHS[i].x28 &
                          v3_24.x29 == TestData_LHS[i].x29 &
                          v3_24.x30 == TestData_LHS[i].x30 &
                          v3_24.x31 == TestData_LHS[i].x31;

                sbyte32 v3_25 = TestData_LHS[i];
                v3_25.v3_25 = t_sbyte3.TestData_LHS[i];
                result &= v3_25.x0  == TestData_LHS[i].x0  &
                          v3_25.x1  == TestData_LHS[i].x1  &
                          v3_25.x2  == TestData_LHS[i].x2  &
                          v3_25.x3  == TestData_LHS[i].x3  &
                          v3_25.x4  == TestData_LHS[i].x4  &
                          v3_25.x5  == TestData_LHS[i].x5  &
                          v3_25.x6  == TestData_LHS[i].x6  &
                          v3_25.x7  == TestData_LHS[i].x7  &
                          v3_25.x8  == TestData_LHS[i].x8  &
                          v3_25.x9  == TestData_LHS[i].x9  &
                          v3_25.x10 == TestData_LHS[i].x10 &
                          v3_25.x11 == TestData_LHS[i].x11 &
                          v3_25.x12 == TestData_LHS[i].x12 &
                          v3_25.x13 == TestData_LHS[i].x13 &
                          v3_25.x14 == TestData_LHS[i].x14 &
                          v3_25.x15 == TestData_LHS[i].x15 &
                          v3_25.x16 == TestData_LHS[i].x16 &
                          v3_25.x17 == TestData_LHS[i].x17 &
                          v3_25.x18 == TestData_LHS[i].x18 &
                          v3_25.x19 == TestData_LHS[i].x19 &
                          v3_25.x20 == TestData_LHS[i].x20 &
                          v3_25.x21 == TestData_LHS[i].x21 &
                          v3_25.x22 == TestData_LHS[i].x22 &
                          v3_25.x23 == TestData_LHS[i].x23 &
                          v3_25.x24 == TestData_LHS[i].x24 &
                          v3_25.x25 == t_sbyte3.TestData_LHS[i].x &
                          v3_25.x26 == t_sbyte3.TestData_LHS[i].y &
                          v3_25.x27 == t_sbyte3.TestData_LHS[i].z &
                          v3_25.x28 == TestData_LHS[i].x28 &
                          v3_25.x29 == TestData_LHS[i].x29 &
                          v3_25.x30 == TestData_LHS[i].x30 &
                          v3_25.x31 == TestData_LHS[i].x31;

                sbyte32 v3_26 = TestData_LHS[i];
                v3_26.v3_26 = t_sbyte3.TestData_LHS[i];
                result &= v3_26.x0  == TestData_LHS[i].x0  &
                          v3_26.x1  == TestData_LHS[i].x1  &
                          v3_26.x2  == TestData_LHS[i].x2  &
                          v3_26.x3  == TestData_LHS[i].x3  &
                          v3_26.x4  == TestData_LHS[i].x4  &
                          v3_26.x5  == TestData_LHS[i].x5  &
                          v3_26.x6  == TestData_LHS[i].x6  &
                          v3_26.x7  == TestData_LHS[i].x7  &
                          v3_26.x8  == TestData_LHS[i].x8  &
                          v3_26.x9  == TestData_LHS[i].x9  &
                          v3_26.x10 == TestData_LHS[i].x10 &
                          v3_26.x11 == TestData_LHS[i].x11 &
                          v3_26.x12 == TestData_LHS[i].x12 &
                          v3_26.x13 == TestData_LHS[i].x13 &
                          v3_26.x14 == TestData_LHS[i].x14 &
                          v3_26.x15 == TestData_LHS[i].x15 &
                          v3_26.x16 == TestData_LHS[i].x16 &
                          v3_26.x17 == TestData_LHS[i].x17 &
                          v3_26.x18 == TestData_LHS[i].x18 &
                          v3_26.x19 == TestData_LHS[i].x19 &
                          v3_26.x20 == TestData_LHS[i].x20 &
                          v3_26.x21 == TestData_LHS[i].x21 &
                          v3_26.x22 == TestData_LHS[i].x22 &
                          v3_26.x23 == TestData_LHS[i].x23 &
                          v3_26.x24 == TestData_LHS[i].x24 &
                          v3_26.x25 == TestData_LHS[i].x25 &
                          v3_26.x26 == t_sbyte3.TestData_LHS[i].x &
                          v3_26.x27 == t_sbyte3.TestData_LHS[i].y &
                          v3_26.x28 == t_sbyte3.TestData_LHS[i].z &
                          v3_26.x29 == TestData_LHS[i].x29 &
                          v3_26.x30 == TestData_LHS[i].x30 &
                          v3_26.x31 == TestData_LHS[i].x31;

                sbyte32 v3_27 = TestData_LHS[i];
                v3_27.v3_27 = t_sbyte3.TestData_LHS[i];
                result &= v3_27.x0  == TestData_LHS[i].x0  &
                          v3_27.x1  == TestData_LHS[i].x1  &
                          v3_27.x2  == TestData_LHS[i].x2  &
                          v3_27.x3  == TestData_LHS[i].x3  &
                          v3_27.x4  == TestData_LHS[i].x4  &
                          v3_27.x5  == TestData_LHS[i].x5  &
                          v3_27.x6  == TestData_LHS[i].x6  &
                          v3_27.x7  == TestData_LHS[i].x7  &
                          v3_27.x8  == TestData_LHS[i].x8  &
                          v3_27.x9  == TestData_LHS[i].x9  &
                          v3_27.x10 == TestData_LHS[i].x10 &
                          v3_27.x11 == TestData_LHS[i].x11 &
                          v3_27.x12 == TestData_LHS[i].x12 &
                          v3_27.x13 == TestData_LHS[i].x13 &
                          v3_27.x14 == TestData_LHS[i].x14 &
                          v3_27.x15 == TestData_LHS[i].x15 &
                          v3_27.x16 == TestData_LHS[i].x16 &
                          v3_27.x17 == TestData_LHS[i].x17 &
                          v3_27.x18 == TestData_LHS[i].x18 &
                          v3_27.x19 == TestData_LHS[i].x19 &
                          v3_27.x20 == TestData_LHS[i].x20 &
                          v3_27.x21 == TestData_LHS[i].x21 &
                          v3_27.x22 == TestData_LHS[i].x22 &
                          v3_27.x23 == TestData_LHS[i].x23 &
                          v3_27.x24 == TestData_LHS[i].x24 &
                          v3_27.x25 == TestData_LHS[i].x25 &
                          v3_27.x26 == TestData_LHS[i].x26 &
                          v3_27.x27 == t_sbyte3.TestData_LHS[i].x &
                          v3_27.x28 == t_sbyte3.TestData_LHS[i].y &
                          v3_27.x29 == t_sbyte3.TestData_LHS[i].z &
                          v3_27.x30 == TestData_LHS[i].x30 &
                          v3_27.x31 == TestData_LHS[i].x31;

                sbyte32 v3_28 = TestData_LHS[i];
                v3_28.v3_28 = t_sbyte3.TestData_LHS[i];
                result &= v3_28.x0  == TestData_LHS[i].x0  &
                          v3_28.x1  == TestData_LHS[i].x1  &
                          v3_28.x2  == TestData_LHS[i].x2  &
                          v3_28.x3  == TestData_LHS[i].x3  &
                          v3_28.x4  == TestData_LHS[i].x4  &
                          v3_28.x5  == TestData_LHS[i].x5  &
                          v3_28.x6  == TestData_LHS[i].x6  &
                          v3_28.x7  == TestData_LHS[i].x7  &
                          v3_28.x8  == TestData_LHS[i].x8  &
                          v3_28.x9  == TestData_LHS[i].x9  &
                          v3_28.x10 == TestData_LHS[i].x10 &
                          v3_28.x11 == TestData_LHS[i].x11 &
                          v3_28.x12 == TestData_LHS[i].x12 &
                          v3_28.x13 == TestData_LHS[i].x13 &
                          v3_28.x14 == TestData_LHS[i].x14 &
                          v3_28.x15 == TestData_LHS[i].x15 &
                          v3_28.x16 == TestData_LHS[i].x16 &
                          v3_28.x17 == TestData_LHS[i].x17 &
                          v3_28.x18 == TestData_LHS[i].x18 &
                          v3_28.x19 == TestData_LHS[i].x19 &
                          v3_28.x20 == TestData_LHS[i].x20 &
                          v3_28.x21 == TestData_LHS[i].x21 &
                          v3_28.x22 == TestData_LHS[i].x22 &
                          v3_28.x23 == TestData_LHS[i].x23 &
                          v3_28.x24 == TestData_LHS[i].x24 &
                          v3_28.x25 == TestData_LHS[i].x25 &
                          v3_28.x26 == TestData_LHS[i].x26 &
                          v3_28.x27 == TestData_LHS[i].x27 &
                          v3_28.x28 == t_sbyte3.TestData_LHS[i].x &
                          v3_28.x29 == t_sbyte3.TestData_LHS[i].y &
                          v3_28.x30 == t_sbyte3.TestData_LHS[i].z &
                          v3_28.x31 == TestData_LHS[i].x31;

                sbyte32 v3_29 = TestData_LHS[i];
                v3_29.v3_29 = t_sbyte3.TestData_LHS[i];
                result &= v3_29.x0  == TestData_LHS[i].x0  &
                          v3_29.x1  == TestData_LHS[i].x1  &
                          v3_29.x2  == TestData_LHS[i].x2  &
                          v3_29.x3  == TestData_LHS[i].x3  &
                          v3_29.x4  == TestData_LHS[i].x4  &
                          v3_29.x5  == TestData_LHS[i].x5  &
                          v3_29.x6  == TestData_LHS[i].x6  &
                          v3_29.x7  == TestData_LHS[i].x7  &
                          v3_29.x8  == TestData_LHS[i].x8  &
                          v3_29.x9  == TestData_LHS[i].x9  &
                          v3_29.x10 == TestData_LHS[i].x10 &
                          v3_29.x11 == TestData_LHS[i].x11 &
                          v3_29.x12 == TestData_LHS[i].x12 &
                          v3_29.x13 == TestData_LHS[i].x13 &
                          v3_29.x14 == TestData_LHS[i].x14 &
                          v3_29.x15 == TestData_LHS[i].x15 &
                          v3_29.x16 == TestData_LHS[i].x16 &
                          v3_29.x17 == TestData_LHS[i].x17 &
                          v3_29.x18 == TestData_LHS[i].x18 &
                          v3_29.x19 == TestData_LHS[i].x19 &
                          v3_29.x20 == TestData_LHS[i].x20 &
                          v3_29.x21 == TestData_LHS[i].x21 &
                          v3_29.x22 == TestData_LHS[i].x22 &
                          v3_29.x23 == TestData_LHS[i].x23 &
                          v3_29.x24 == TestData_LHS[i].x24 &
                          v3_29.x25 == TestData_LHS[i].x25 &
                          v3_29.x26 == TestData_LHS[i].x26 &
                          v3_29.x27 == TestData_LHS[i].x27 &
                          v3_29.x28 == TestData_LHS[i].x28 &
                          v3_29.x29 == t_sbyte3.TestData_LHS[i].x &
                          v3_29.x30 == t_sbyte3.TestData_LHS[i].y &
                          v3_29.x31 == t_sbyte3.TestData_LHS[i].z;


                sbyte32 v2_0 = TestData_LHS[i];
                v2_0.v2_0 = t_sbyte2.TestData_LHS[i];
                result &= v2_0.x0  == t_sbyte2.TestData_LHS[i].x  &
                          v2_0.x1  == t_sbyte2.TestData_LHS[i].y  &
                          v2_0.x2  == TestData_LHS[i].x2  &
                          v2_0.x3  == TestData_LHS[i].x3  &
                          v2_0.x4  == TestData_LHS[i].x4  &
                          v2_0.x5  == TestData_LHS[i].x5  &
                          v2_0.x6  == TestData_LHS[i].x6  &
                          v2_0.x7  == TestData_LHS[i].x7  &
                          v2_0.x8  == TestData_LHS[i].x8  &
                          v2_0.x9  == TestData_LHS[i].x9  &
                          v2_0.x10 == TestData_LHS[i].x10 &
                          v2_0.x11 == TestData_LHS[i].x11 &
                          v2_0.x12 == TestData_LHS[i].x12 &
                          v2_0.x13 == TestData_LHS[i].x13 &
                          v2_0.x14 == TestData_LHS[i].x14 &
                          v2_0.x15 == TestData_LHS[i].x15 &
                          v2_0.x16 == TestData_LHS[i].x16 &
                          v2_0.x17 == TestData_LHS[i].x17 &
                          v2_0.x18 == TestData_LHS[i].x18 &
                          v2_0.x19 == TestData_LHS[i].x19 &
                          v2_0.x20 == TestData_LHS[i].x20 &
                          v2_0.x21 == TestData_LHS[i].x21 &
                          v2_0.x22 == TestData_LHS[i].x22 &
                          v2_0.x23 == TestData_LHS[i].x23 &
                          v2_0.x24 == TestData_LHS[i].x24 &
                          v2_0.x25 == TestData_LHS[i].x25 &
                          v2_0.x26 == TestData_LHS[i].x26 &
                          v2_0.x27 == TestData_LHS[i].x27 &
                          v2_0.x28 == TestData_LHS[i].x28 &
                          v2_0.x29 == TestData_LHS[i].x29 &
                          v2_0.x30 == TestData_LHS[i].x30 &
                          v2_0.x31 == TestData_LHS[i].x31;

                sbyte32 v2_1 = TestData_LHS[i];
                v2_1.v2_1 = t_sbyte2.TestData_LHS[i];
                result &= v2_1.x0  == TestData_LHS[i].x0  &
                          v2_1.x1  == t_sbyte2.TestData_LHS[i].x  &
                          v2_1.x2  == t_sbyte2.TestData_LHS[i].y &
                          v2_1.x3  == TestData_LHS[i].x3  &
                          v2_1.x4  == TestData_LHS[i].x4  &
                          v2_1.x5  == TestData_LHS[i].x5  &
                          v2_1.x6  == TestData_LHS[i].x6  &
                          v2_1.x7  == TestData_LHS[i].x7  &
                          v2_1.x8  == TestData_LHS[i].x8  &
                          v2_1.x9  == TestData_LHS[i].x9  &
                          v2_1.x10 == TestData_LHS[i].x10 &
                          v2_1.x11 == TestData_LHS[i].x11 &
                          v2_1.x12 == TestData_LHS[i].x12 &
                          v2_1.x13 == TestData_LHS[i].x13 &
                          v2_1.x14 == TestData_LHS[i].x14 &
                          v2_1.x15 == TestData_LHS[i].x15 &
                          v2_1.x16 == TestData_LHS[i].x16 &
                          v2_1.x17 == TestData_LHS[i].x17 &
                          v2_1.x18 == TestData_LHS[i].x18 &
                          v2_1.x19 == TestData_LHS[i].x19 &
                          v2_1.x20 == TestData_LHS[i].x20 &
                          v2_1.x21 == TestData_LHS[i].x21 &
                          v2_1.x22 == TestData_LHS[i].x22 &
                          v2_1.x23 == TestData_LHS[i].x23 &
                          v2_1.x24 == TestData_LHS[i].x24 &
                          v2_1.x25 == TestData_LHS[i].x25 &
                          v2_1.x26 == TestData_LHS[i].x26 &
                          v2_1.x27 == TestData_LHS[i].x27 &
                          v2_1.x28 == TestData_LHS[i].x28 &
                          v2_1.x29 == TestData_LHS[i].x29 &
                          v2_1.x30 == TestData_LHS[i].x30 &
                          v2_1.x31 == TestData_LHS[i].x31;

                sbyte32 v2_2 = TestData_LHS[i];
                v2_2.v2_2 = t_sbyte2.TestData_LHS[i];
                result &= v2_2.x0  == TestData_LHS[i].x0  &
                          v2_2.x1  == TestData_LHS[i].x1  &
                          v2_2.x2  == t_sbyte2.TestData_LHS[i].x  &
                          v2_2.x3  == t_sbyte2.TestData_LHS[i].y &
                          v2_2.x4  == TestData_LHS[i].x4  &
                          v2_2.x5  == TestData_LHS[i].x5  &
                          v2_2.x6  == TestData_LHS[i].x6  &
                          v2_2.x7  == TestData_LHS[i].x7  &
                          v2_2.x8  == TestData_LHS[i].x8  &
                          v2_2.x9  == TestData_LHS[i].x9  &
                          v2_2.x10 == TestData_LHS[i].x10 &
                          v2_2.x11 == TestData_LHS[i].x11 &
                          v2_2.x12 == TestData_LHS[i].x12 &
                          v2_2.x13 == TestData_LHS[i].x13 &
                          v2_2.x14 == TestData_LHS[i].x14 &
                          v2_2.x15 == TestData_LHS[i].x15 &
                          v2_2.x16 == TestData_LHS[i].x16 &
                          v2_2.x17 == TestData_LHS[i].x17 &
                          v2_2.x18 == TestData_LHS[i].x18 &
                          v2_2.x19 == TestData_LHS[i].x19 &
                          v2_2.x20 == TestData_LHS[i].x20 &
                          v2_2.x21 == TestData_LHS[i].x21 &
                          v2_2.x22 == TestData_LHS[i].x22 &
                          v2_2.x23 == TestData_LHS[i].x23 &
                          v2_2.x24 == TestData_LHS[i].x24 &
                          v2_2.x25 == TestData_LHS[i].x25 &
                          v2_2.x26 == TestData_LHS[i].x26 &
                          v2_2.x27 == TestData_LHS[i].x27 &
                          v2_2.x28 == TestData_LHS[i].x28 &
                          v2_2.x29 == TestData_LHS[i].x29 &
                          v2_2.x30 == TestData_LHS[i].x30 &
                          v2_2.x31 == TestData_LHS[i].x31;

                sbyte32 v2_3 = TestData_LHS[i];
                v2_3.v2_3 = t_sbyte2.TestData_LHS[i];
                result &= v2_3.x0  == TestData_LHS[i].x0  &
                          v2_3.x1  == TestData_LHS[i].x1  &
                          v2_3.x2  == TestData_LHS[i].x2  &
                          v2_3.x3  == t_sbyte2.TestData_LHS[i].x  &
                          v2_3.x4  == t_sbyte2.TestData_LHS[i].y &
                          v2_3.x5  == TestData_LHS[i].x5  &
                          v2_3.x6  == TestData_LHS[i].x6  &
                          v2_3.x7  == TestData_LHS[i].x7  &
                          v2_3.x8  == TestData_LHS[i].x8  &
                          v2_3.x9  == TestData_LHS[i].x9  &
                          v2_3.x10 == TestData_LHS[i].x10 &
                          v2_3.x11 == TestData_LHS[i].x11 &
                          v2_3.x12 == TestData_LHS[i].x12 &
                          v2_3.x13 == TestData_LHS[i].x13 &
                          v2_3.x14 == TestData_LHS[i].x14 &
                          v2_3.x15 == TestData_LHS[i].x15 &
                          v2_3.x16 == TestData_LHS[i].x16 &
                          v2_3.x17 == TestData_LHS[i].x17 &
                          v2_3.x18 == TestData_LHS[i].x18 &
                          v2_3.x19 == TestData_LHS[i].x19 &
                          v2_3.x20 == TestData_LHS[i].x20 &
                          v2_3.x21 == TestData_LHS[i].x21 &
                          v2_3.x22 == TestData_LHS[i].x22 &
                          v2_3.x23 == TestData_LHS[i].x23 &
                          v2_3.x24 == TestData_LHS[i].x24 &
                          v2_3.x25 == TestData_LHS[i].x25 &
                          v2_3.x26 == TestData_LHS[i].x26 &
                          v2_3.x27 == TestData_LHS[i].x27 &
                          v2_3.x28 == TestData_LHS[i].x28 &
                          v2_3.x29 == TestData_LHS[i].x29 &
                          v2_3.x30 == TestData_LHS[i].x30 &
                          v2_3.x31 == TestData_LHS[i].x31;

                sbyte32 v2_4 = TestData_LHS[i];
                v2_4.v2_4 = t_sbyte2.TestData_LHS[i];
                result &= v2_4.x0  == TestData_LHS[i].x0  &
                          v2_4.x1  == TestData_LHS[i].x1  &
                          v2_4.x2  == TestData_LHS[i].x2  &
                          v2_4.x3  == TestData_LHS[i].x3  &
                          v2_4.x4  == t_sbyte2.TestData_LHS[i].x  &
                          v2_4.x5  == t_sbyte2.TestData_LHS[i].y &
                          v2_4.x6  == TestData_LHS[i].x6  &
                          v2_4.x7  == TestData_LHS[i].x7  &
                          v2_4.x8  == TestData_LHS[i].x8  &
                          v2_4.x9  == TestData_LHS[i].x9  &
                          v2_4.x10 == TestData_LHS[i].x10 &
                          v2_4.x11 == TestData_LHS[i].x11 &
                          v2_4.x12 == TestData_LHS[i].x12 &
                          v2_4.x13 == TestData_LHS[i].x13 &
                          v2_4.x14 == TestData_LHS[i].x14 &
                          v2_4.x15 == TestData_LHS[i].x15 &
                          v2_4.x16 == TestData_LHS[i].x16 &
                          v2_4.x17 == TestData_LHS[i].x17 &
                          v2_4.x18 == TestData_LHS[i].x18 &
                          v2_4.x19 == TestData_LHS[i].x19 &
                          v2_4.x20 == TestData_LHS[i].x20 &
                          v2_4.x21 == TestData_LHS[i].x21 &
                          v2_4.x22 == TestData_LHS[i].x22 &
                          v2_4.x23 == TestData_LHS[i].x23 &
                          v2_4.x24 == TestData_LHS[i].x24 &
                          v2_4.x25 == TestData_LHS[i].x25 &
                          v2_4.x26 == TestData_LHS[i].x26 &
                          v2_4.x27 == TestData_LHS[i].x27 &
                          v2_4.x28 == TestData_LHS[i].x28 &
                          v2_4.x29 == TestData_LHS[i].x29 &
                          v2_4.x30 == TestData_LHS[i].x30 &
                          v2_4.x31 == TestData_LHS[i].x31;

                sbyte32 v2_5 = TestData_LHS[i];
                v2_5.v2_5 = t_sbyte2.TestData_LHS[i];
                result &= v2_5.x0  == TestData_LHS[i].x0  &
                          v2_5.x1  == TestData_LHS[i].x1  &
                          v2_5.x2  == TestData_LHS[i].x2  &
                          v2_5.x3  == TestData_LHS[i].x3  &
                          v2_5.x4  == TestData_LHS[i].x4  &
                          v2_5.x5  == t_sbyte2.TestData_LHS[i].x  &
                          v2_5.x6  == t_sbyte2.TestData_LHS[i].y &
                          v2_5.x7  == TestData_LHS[i].x7  &
                          v2_5.x8  == TestData_LHS[i].x8  &
                          v2_5.x9  == TestData_LHS[i].x9  &
                          v2_5.x10 == TestData_LHS[i].x10 &
                          v2_5.x11 == TestData_LHS[i].x11 &
                          v2_5.x12 == TestData_LHS[i].x12 &
                          v2_5.x13 == TestData_LHS[i].x13 &
                          v2_5.x14 == TestData_LHS[i].x14 &
                          v2_5.x15 == TestData_LHS[i].x15 &
                          v2_5.x16 == TestData_LHS[i].x16 &
                          v2_5.x17 == TestData_LHS[i].x17 &
                          v2_5.x18 == TestData_LHS[i].x18 &
                          v2_5.x19 == TestData_LHS[i].x19 &
                          v2_5.x20 == TestData_LHS[i].x20 &
                          v2_5.x21 == TestData_LHS[i].x21 &
                          v2_5.x22 == TestData_LHS[i].x22 &
                          v2_5.x23 == TestData_LHS[i].x23 &
                          v2_5.x24 == TestData_LHS[i].x24 &
                          v2_5.x25 == TestData_LHS[i].x25 &
                          v2_5.x26 == TestData_LHS[i].x26 &
                          v2_5.x27 == TestData_LHS[i].x27 &
                          v2_5.x28 == TestData_LHS[i].x28 &
                          v2_5.x29 == TestData_LHS[i].x29 &
                          v2_5.x30 == TestData_LHS[i].x30 &
                          v2_5.x31 == TestData_LHS[i].x31;

                sbyte32 v2_6 = TestData_LHS[i];
                v2_6.v2_6 = t_sbyte2.TestData_LHS[i];
                result &= v2_6.x0  == TestData_LHS[i].x0  &
                          v2_6.x1  == TestData_LHS[i].x1  &
                          v2_6.x2  == TestData_LHS[i].x2  &
                          v2_6.x3  == TestData_LHS[i].x3  &
                          v2_6.x4  == TestData_LHS[i].x4  &
                          v2_6.x5  == TestData_LHS[i].x5  &
                          v2_6.x6  == t_sbyte2.TestData_LHS[i].x  &
                          v2_6.x7  == t_sbyte2.TestData_LHS[i].y &
                          v2_6.x8  == TestData_LHS[i].x8  &
                          v2_6.x9  == TestData_LHS[i].x9  &
                          v2_6.x10 == TestData_LHS[i].x10 &
                          v2_6.x11 == TestData_LHS[i].x11 &
                          v2_6.x12 == TestData_LHS[i].x12 &
                          v2_6.x13 == TestData_LHS[i].x13 &
                          v2_6.x14 == TestData_LHS[i].x14 &
                          v2_6.x15 == TestData_LHS[i].x15 &
                          v2_6.x16 == TestData_LHS[i].x16 &
                          v2_6.x17 == TestData_LHS[i].x17 &
                          v2_6.x18 == TestData_LHS[i].x18 &
                          v2_6.x19 == TestData_LHS[i].x19 &
                          v2_6.x20 == TestData_LHS[i].x20 &
                          v2_6.x21 == TestData_LHS[i].x21 &
                          v2_6.x22 == TestData_LHS[i].x22 &
                          v2_6.x23 == TestData_LHS[i].x23 &
                          v2_6.x24 == TestData_LHS[i].x24 &
                          v2_6.x25 == TestData_LHS[i].x25 &
                          v2_6.x26 == TestData_LHS[i].x26 &
                          v2_6.x27 == TestData_LHS[i].x27 &
                          v2_6.x28 == TestData_LHS[i].x28 &
                          v2_6.x29 == TestData_LHS[i].x29 &
                          v2_6.x30 == TestData_LHS[i].x30 &
                          v2_6.x31 == TestData_LHS[i].x31;

                sbyte32 v2_7 = TestData_LHS[i];
                v2_7.v2_7 = t_sbyte2.TestData_LHS[i];
                result &= v2_7.x0  == TestData_LHS[i].x0  &
                          v2_7.x1  == TestData_LHS[i].x1  &
                          v2_7.x2  == TestData_LHS[i].x2  &
                          v2_7.x3  == TestData_LHS[i].x3  &
                          v2_7.x4  == TestData_LHS[i].x4  &
                          v2_7.x5  == TestData_LHS[i].x5  &
                          v2_7.x6  == TestData_LHS[i].x6  &
                          v2_7.x7  == t_sbyte2.TestData_LHS[i].x  &
                          v2_7.x8  == t_sbyte2.TestData_LHS[i].y &
                          v2_7.x9  == TestData_LHS[i].x9  &
                          v2_7.x10 == TestData_LHS[i].x10 &
                          v2_7.x11 == TestData_LHS[i].x11 &
                          v2_7.x12 == TestData_LHS[i].x12 &
                          v2_7.x13 == TestData_LHS[i].x13 &
                          v2_7.x14 == TestData_LHS[i].x14 &
                          v2_7.x15 == TestData_LHS[i].x15 &
                          v2_7.x16 == TestData_LHS[i].x16 &
                          v2_7.x17 == TestData_LHS[i].x17 &
                          v2_7.x18 == TestData_LHS[i].x18 &
                          v2_7.x19 == TestData_LHS[i].x19 &
                          v2_7.x20 == TestData_LHS[i].x20 &
                          v2_7.x21 == TestData_LHS[i].x21 &
                          v2_7.x22 == TestData_LHS[i].x22 &
                          v2_7.x23 == TestData_LHS[i].x23 &
                          v2_7.x24 == TestData_LHS[i].x24 &
                          v2_7.x25 == TestData_LHS[i].x25 &
                          v2_7.x26 == TestData_LHS[i].x26 &
                          v2_7.x27 == TestData_LHS[i].x27 &
                          v2_7.x28 == TestData_LHS[i].x28 &
                          v2_7.x29 == TestData_LHS[i].x29 &
                          v2_7.x30 == TestData_LHS[i].x30 &
                          v2_7.x31 == TestData_LHS[i].x31;

                sbyte32 v2_8 = TestData_LHS[i];
                v2_8.v2_8 = t_sbyte2.TestData_LHS[i];
                result &= v2_8.x0  == TestData_LHS[i].x0  &
                          v2_8.x1  == TestData_LHS[i].x1  &
                          v2_8.x2  == TestData_LHS[i].x2  &
                          v2_8.x3  == TestData_LHS[i].x3  &
                          v2_8.x4  == TestData_LHS[i].x4  &
                          v2_8.x5  == TestData_LHS[i].x5  &
                          v2_8.x6  == TestData_LHS[i].x6  &
                          v2_8.x7  == TestData_LHS[i].x7  &
                          v2_8.x8  == t_sbyte2.TestData_LHS[i].x &
                          v2_8.x9  == t_sbyte2.TestData_LHS[i].y &
                          v2_8.x10 == TestData_LHS[i].x10 &
                          v2_8.x11 == TestData_LHS[i].x11 &
                          v2_8.x12 == TestData_LHS[i].x12 &
                          v2_8.x13 == TestData_LHS[i].x13 &
                          v2_8.x14 == TestData_LHS[i].x14 &
                          v2_8.x15 == TestData_LHS[i].x15 &
                          v2_8.x16 == TestData_LHS[i].x16 &
                          v2_8.x17 == TestData_LHS[i].x17 &
                          v2_8.x18 == TestData_LHS[i].x18 &
                          v2_8.x19 == TestData_LHS[i].x19 &
                          v2_8.x20 == TestData_LHS[i].x20 &
                          v2_8.x21 == TestData_LHS[i].x21 &
                          v2_8.x22 == TestData_LHS[i].x22 &
                          v2_8.x23 == TestData_LHS[i].x23 &
                          v2_8.x24 == TestData_LHS[i].x24 &
                          v2_8.x25 == TestData_LHS[i].x25 &
                          v2_8.x26 == TestData_LHS[i].x26 &
                          v2_8.x27 == TestData_LHS[i].x27 &
                          v2_8.x28 == TestData_LHS[i].x28 &
                          v2_8.x29 == TestData_LHS[i].x29 &
                          v2_8.x30 == TestData_LHS[i].x30 &
                          v2_8.x31 == TestData_LHS[i].x31;

                sbyte32 v2_9 = TestData_LHS[i];
                v2_9.v2_9 = t_sbyte2.TestData_LHS[i];
                result &= v2_9.x0  == TestData_LHS[i].x0  &
                          v2_9.x1  == TestData_LHS[i].x1  &
                          v2_9.x2  == TestData_LHS[i].x2  &
                          v2_9.x3  == TestData_LHS[i].x3  &
                          v2_9.x4  == TestData_LHS[i].x4  &
                          v2_9.x5  == TestData_LHS[i].x5  &
                          v2_9.x6  == TestData_LHS[i].x6  &
                          v2_9.x7  == TestData_LHS[i].x7  &
                          v2_9.x8  == TestData_LHS[i].x8  &
                          v2_9.x9  == t_sbyte2.TestData_LHS[i].x &
                          v2_9.x10 == t_sbyte2.TestData_LHS[i].y &
                          v2_9.x11 == TestData_LHS[i].x11 &
                          v2_9.x12 == TestData_LHS[i].x12 &
                          v2_9.x13 == TestData_LHS[i].x13 &
                          v2_9.x14 == TestData_LHS[i].x14 &
                          v2_9.x15 == TestData_LHS[i].x15 &
                          v2_9.x16 == TestData_LHS[i].x16 &
                          v2_9.x17 == TestData_LHS[i].x17 &
                          v2_9.x18 == TestData_LHS[i].x18 &
                          v2_9.x19 == TestData_LHS[i].x19 &
                          v2_9.x20 == TestData_LHS[i].x20 &
                          v2_9.x21 == TestData_LHS[i].x21 &
                          v2_9.x22 == TestData_LHS[i].x22 &
                          v2_9.x23 == TestData_LHS[i].x23 &
                          v2_9.x24 == TestData_LHS[i].x24 &
                          v2_9.x25 == TestData_LHS[i].x25 &
                          v2_9.x26 == TestData_LHS[i].x26 &
                          v2_9.x27 == TestData_LHS[i].x27 &
                          v2_9.x28 == TestData_LHS[i].x28 &
                          v2_9.x29 == TestData_LHS[i].x29 &
                          v2_9.x30 == TestData_LHS[i].x30 &
                          v2_9.x31 == TestData_LHS[i].x31;

                sbyte32 v2_10 = TestData_LHS[i];
                v2_10.v2_10 = t_sbyte2.TestData_LHS[i];
                result &= v2_10.x0  == TestData_LHS[i].x0  &
                          v2_10.x1  == TestData_LHS[i].x1  &
                          v2_10.x2  == TestData_LHS[i].x2  &
                          v2_10.x3  == TestData_LHS[i].x3  &
                          v2_10.x4  == TestData_LHS[i].x4  &
                          v2_10.x5  == TestData_LHS[i].x5  &
                          v2_10.x6  == TestData_LHS[i].x6  &
                          v2_10.x7  == TestData_LHS[i].x7  &
                          v2_10.x8  == TestData_LHS[i].x8  &
                          v2_10.x9  == TestData_LHS[i].x9  &
                          v2_10.x10 == t_sbyte2.TestData_LHS[i].x &
                          v2_10.x11 == t_sbyte2.TestData_LHS[i].y &
                          v2_10.x12 == TestData_LHS[i].x12 &
                          v2_10.x13 == TestData_LHS[i].x13 &
                          v2_10.x14 == TestData_LHS[i].x14 &
                          v2_10.x15 == TestData_LHS[i].x15 &
                          v2_10.x16 == TestData_LHS[i].x16 &
                          v2_10.x17 == TestData_LHS[i].x17 &
                          v2_10.x18 == TestData_LHS[i].x18 &
                          v2_10.x19 == TestData_LHS[i].x19 &
                          v2_10.x20 == TestData_LHS[i].x20 &
                          v2_10.x21 == TestData_LHS[i].x21 &
                          v2_10.x22 == TestData_LHS[i].x22 &
                          v2_10.x23 == TestData_LHS[i].x23 &
                          v2_10.x24 == TestData_LHS[i].x24 &
                          v2_10.x25 == TestData_LHS[i].x25 &
                          v2_10.x26 == TestData_LHS[i].x26 &
                          v2_10.x27 == TestData_LHS[i].x27 &
                          v2_10.x28 == TestData_LHS[i].x28 &
                          v2_10.x29 == TestData_LHS[i].x29 &
                          v2_10.x30 == TestData_LHS[i].x30 &
                          v2_10.x31 == TestData_LHS[i].x31;

                sbyte32 v2_11 = TestData_LHS[i];
                v2_11.v2_11 = t_sbyte2.TestData_LHS[i];
                result &= v2_11.x0  == TestData_LHS[i].x0  &
                          v2_11.x1  == TestData_LHS[i].x1  &
                          v2_11.x2  == TestData_LHS[i].x2  &
                          v2_11.x3  == TestData_LHS[i].x3  &
                          v2_11.x4  == TestData_LHS[i].x4  &
                          v2_11.x5  == TestData_LHS[i].x5  &
                          v2_11.x6  == TestData_LHS[i].x6  &
                          v2_11.x7  == TestData_LHS[i].x7  &
                          v2_11.x8  == TestData_LHS[i].x8  &
                          v2_11.x9  == TestData_LHS[i].x9  &
                          v2_11.x10 == TestData_LHS[i].x10 &
                          v2_11.x11 == t_sbyte2.TestData_LHS[i].x &
                          v2_11.x12 == t_sbyte2.TestData_LHS[i].y &
                          v2_11.x13 == TestData_LHS[i].x13 &
                          v2_11.x14 == TestData_LHS[i].x14 &
                          v2_11.x15 == TestData_LHS[i].x15 &
                          v2_11.x16 == TestData_LHS[i].x16 &
                          v2_11.x17 == TestData_LHS[i].x17 &
                          v2_11.x18 == TestData_LHS[i].x18 &
                          v2_11.x19 == TestData_LHS[i].x19 &
                          v2_11.x20 == TestData_LHS[i].x20 &
                          v2_11.x21 == TestData_LHS[i].x21 &
                          v2_11.x22 == TestData_LHS[i].x22 &
                          v2_11.x23 == TestData_LHS[i].x23 &
                          v2_11.x24 == TestData_LHS[i].x24 &
                          v2_11.x25 == TestData_LHS[i].x25 &
                          v2_11.x26 == TestData_LHS[i].x26 &
                          v2_11.x27 == TestData_LHS[i].x27 &
                          v2_11.x28 == TestData_LHS[i].x28 &
                          v2_11.x29 == TestData_LHS[i].x29 &
                          v2_11.x30 == TestData_LHS[i].x30 &
                          v2_11.x31 == TestData_LHS[i].x31;

                sbyte32 v2_12 = TestData_LHS[i];
                v2_12.v2_12 = t_sbyte2.TestData_LHS[i];
                result &= v2_12.x0  == TestData_LHS[i].x0  &
                          v2_12.x1  == TestData_LHS[i].x1  &
                          v2_12.x2  == TestData_LHS[i].x2  &
                          v2_12.x3  == TestData_LHS[i].x3  &
                          v2_12.x4  == TestData_LHS[i].x4  &
                          v2_12.x5  == TestData_LHS[i].x5  &
                          v2_12.x6  == TestData_LHS[i].x6  &
                          v2_12.x7  == TestData_LHS[i].x7  &
                          v2_12.x8  == TestData_LHS[i].x8  &
                          v2_12.x9  == TestData_LHS[i].x9  &
                          v2_12.x10 == TestData_LHS[i].x10 &
                          v2_12.x11 == TestData_LHS[i].x11 &
                          v2_12.x12 == t_sbyte2.TestData_LHS[i].x &
                          v2_12.x13 == t_sbyte2.TestData_LHS[i].y &
                          v2_12.x14 == TestData_LHS[i].x14 &
                          v2_12.x15 == TestData_LHS[i].x15 &
                          v2_12.x16 == TestData_LHS[i].x16 &
                          v2_12.x17 == TestData_LHS[i].x17 &
                          v2_12.x18 == TestData_LHS[i].x18 &
                          v2_12.x19 == TestData_LHS[i].x19 &
                          v2_12.x20 == TestData_LHS[i].x20 &
                          v2_12.x21 == TestData_LHS[i].x21 &
                          v2_12.x22 == TestData_LHS[i].x22 &
                          v2_12.x23 == TestData_LHS[i].x23 &
                          v2_12.x24 == TestData_LHS[i].x24 &
                          v2_12.x25 == TestData_LHS[i].x25 &
                          v2_12.x26 == TestData_LHS[i].x26 &
                          v2_12.x27 == TestData_LHS[i].x27 &
                          v2_12.x28 == TestData_LHS[i].x28 &
                          v2_12.x29 == TestData_LHS[i].x29 &
                          v2_12.x30 == TestData_LHS[i].x30 &
                          v2_12.x31 == TestData_LHS[i].x31;

                sbyte32 v2_13 = TestData_LHS[i];
                v2_13.v2_13 = t_sbyte2.TestData_LHS[i];
                result &= v2_13.x0  == TestData_LHS[i].x0  &
                          v2_13.x1  == TestData_LHS[i].x1  &
                          v2_13.x2  == TestData_LHS[i].x2  &
                          v2_13.x3  == TestData_LHS[i].x3  &
                          v2_13.x4  == TestData_LHS[i].x4  &
                          v2_13.x5  == TestData_LHS[i].x5  &
                          v2_13.x6  == TestData_LHS[i].x6  &
                          v2_13.x7  == TestData_LHS[i].x7  &
                          v2_13.x8  == TestData_LHS[i].x8  &
                          v2_13.x9  == TestData_LHS[i].x9  &
                          v2_13.x10 == TestData_LHS[i].x10 &
                          v2_13.x11 == TestData_LHS[i].x11 &
                          v2_13.x12 == TestData_LHS[i].x12 &
                          v2_13.x13 == t_sbyte2.TestData_LHS[i].x &
                          v2_13.x14 == t_sbyte2.TestData_LHS[i].y &
                          v2_13.x15 == TestData_LHS[i].x15 &
                          v2_13.x16 == TestData_LHS[i].x16 &
                          v2_13.x17 == TestData_LHS[i].x17 &
                          v2_13.x18 == TestData_LHS[i].x18 &
                          v2_13.x19 == TestData_LHS[i].x19 &
                          v2_13.x20 == TestData_LHS[i].x20 &
                          v2_13.x21 == TestData_LHS[i].x21 &
                          v2_13.x22 == TestData_LHS[i].x22 &
                          v2_13.x23 == TestData_LHS[i].x23 &
                          v2_13.x24 == TestData_LHS[i].x24 &
                          v2_13.x25 == TestData_LHS[i].x25 &
                          v2_13.x26 == TestData_LHS[i].x26 &
                          v2_13.x27 == TestData_LHS[i].x27 &
                          v2_13.x28 == TestData_LHS[i].x28 &
                          v2_13.x29 == TestData_LHS[i].x29 &
                          v2_13.x30 == TestData_LHS[i].x30 &
                          v2_13.x31 == TestData_LHS[i].x31;

                sbyte32 v2_14 = TestData_LHS[i];
                v2_14.v2_14 = t_sbyte2.TestData_LHS[i];
                result &= v2_14.x0  == TestData_LHS[i].x0  &
                          v2_14.x1  == TestData_LHS[i].x1  &
                          v2_14.x2  == TestData_LHS[i].x2  &
                          v2_14.x3  == TestData_LHS[i].x3  &
                          v2_14.x4  == TestData_LHS[i].x4  &
                          v2_14.x5  == TestData_LHS[i].x5  &
                          v2_14.x6  == TestData_LHS[i].x6  &
                          v2_14.x7  == TestData_LHS[i].x7  &
                          v2_14.x8  == TestData_LHS[i].x8  &
                          v2_14.x9  == TestData_LHS[i].x9  &
                          v2_14.x10 == TestData_LHS[i].x10 &
                          v2_14.x11 == TestData_LHS[i].x11 &
                          v2_14.x12 == TestData_LHS[i].x12 &
                          v2_14.x13 == TestData_LHS[i].x13 &
                          v2_14.x14 == t_sbyte2.TestData_LHS[i].x &
                          v2_14.x15 == t_sbyte2.TestData_LHS[i].y &
                          v2_14.x16 == TestData_LHS[i].x16 &
                          v2_14.x17 == TestData_LHS[i].x17 &
                          v2_14.x18 == TestData_LHS[i].x18 &
                          v2_14.x19 == TestData_LHS[i].x19 &
                          v2_14.x20 == TestData_LHS[i].x20 &
                          v2_14.x21 == TestData_LHS[i].x21 &
                          v2_14.x22 == TestData_LHS[i].x22 &
                          v2_14.x23 == TestData_LHS[i].x23 &
                          v2_14.x24 == TestData_LHS[i].x24 &
                          v2_14.x25 == TestData_LHS[i].x25 &
                          v2_14.x26 == TestData_LHS[i].x26 &
                          v2_14.x27 == TestData_LHS[i].x27 &
                          v2_14.x28 == TestData_LHS[i].x28 &
                          v2_14.x29 == TestData_LHS[i].x29 &
                          v2_14.x30 == TestData_LHS[i].x30 &
                          v2_14.x31 == TestData_LHS[i].x31;

                sbyte32 v2_15 = TestData_LHS[i];
                v2_15.v2_15 = t_sbyte2.TestData_LHS[i];
                result &= v2_15.x0  == TestData_LHS[i].x0  &
                          v2_15.x1  == TestData_LHS[i].x1  &
                          v2_15.x2  == TestData_LHS[i].x2  &
                          v2_15.x3  == TestData_LHS[i].x3  &
                          v2_15.x4  == TestData_LHS[i].x4  &
                          v2_15.x5  == TestData_LHS[i].x5  &
                          v2_15.x6  == TestData_LHS[i].x6  &
                          v2_15.x7  == TestData_LHS[i].x7  &
                          v2_15.x8  == TestData_LHS[i].x8  &
                          v2_15.x9  == TestData_LHS[i].x9  &
                          v2_15.x10 == TestData_LHS[i].x10 &
                          v2_15.x11 == TestData_LHS[i].x11 &
                          v2_15.x12 == TestData_LHS[i].x12 &
                          v2_15.x13 == TestData_LHS[i].x13 &
                          v2_15.x14 == TestData_LHS[i].x14 &
                          v2_15.x15 == t_sbyte2.TestData_LHS[i].x &
                          v2_15.x16 == t_sbyte2.TestData_LHS[i].y &
                          v2_15.x17 == TestData_LHS[i].x17 &
                          v2_15.x18 == TestData_LHS[i].x18 &
                          v2_15.x19 == TestData_LHS[i].x19 &
                          v2_15.x20 == TestData_LHS[i].x20 &
                          v2_15.x21 == TestData_LHS[i].x21 &
                          v2_15.x22 == TestData_LHS[i].x22 &
                          v2_15.x23 == TestData_LHS[i].x23 &
                          v2_15.x24 == TestData_LHS[i].x24 &
                          v2_15.x25 == TestData_LHS[i].x25 &
                          v2_15.x26 == TestData_LHS[i].x26 &
                          v2_15.x27 == TestData_LHS[i].x27 &
                          v2_15.x28 == TestData_LHS[i].x28 &
                          v2_15.x29 == TestData_LHS[i].x29 &
                          v2_15.x30 == TestData_LHS[i].x30 &
                          v2_15.x31 == TestData_LHS[i].x31;

                sbyte32 v2_16 = TestData_LHS[i];
                v2_16.v2_16 = t_sbyte2.TestData_LHS[i];
                result &= v2_16.x0  == TestData_LHS[i].x0  &
                          v2_16.x1  == TestData_LHS[i].x1  &
                          v2_16.x2  == TestData_LHS[i].x2  &
                          v2_16.x3  == TestData_LHS[i].x3  &
                          v2_16.x4  == TestData_LHS[i].x4  &
                          v2_16.x5  == TestData_LHS[i].x5  &
                          v2_16.x6  == TestData_LHS[i].x6  &
                          v2_16.x7  == TestData_LHS[i].x7  &
                          v2_16.x8  == TestData_LHS[i].x8  &
                          v2_16.x9  == TestData_LHS[i].x9  &
                          v2_16.x10 == TestData_LHS[i].x10 &
                          v2_16.x11 == TestData_LHS[i].x11 &
                          v2_16.x12 == TestData_LHS[i].x12 &
                          v2_16.x13 == TestData_LHS[i].x13 &
                          v2_16.x14 == TestData_LHS[i].x14 &
                          v2_16.x15 == TestData_LHS[i].x15 &
                          v2_16.x16 == t_sbyte2.TestData_LHS[i].x &
                          v2_16.x17 == t_sbyte2.TestData_LHS[i].y &
                          v2_16.x18 == TestData_LHS[i].x18 &
                          v2_16.x19 == TestData_LHS[i].x19 &
                          v2_16.x20 == TestData_LHS[i].x20 &
                          v2_16.x21 == TestData_LHS[i].x21 &
                          v2_16.x22 == TestData_LHS[i].x22 &
                          v2_16.x23 == TestData_LHS[i].x23 &
                          v2_16.x24 == TestData_LHS[i].x24 &
                          v2_16.x25 == TestData_LHS[i].x25 &
                          v2_16.x26 == TestData_LHS[i].x26 &
                          v2_16.x27 == TestData_LHS[i].x27 &
                          v2_16.x28 == TestData_LHS[i].x28 &
                          v2_16.x29 == TestData_LHS[i].x29 &
                          v2_16.x30 == TestData_LHS[i].x30 &
                          v2_16.x31 == TestData_LHS[i].x31;

                sbyte32 v2_17 = TestData_LHS[i];
                v2_17.v2_17 = t_sbyte2.TestData_LHS[i];
                result &= v2_17.x0  == TestData_LHS[i].x0  &
                          v2_17.x1  == TestData_LHS[i].x1  &
                          v2_17.x2  == TestData_LHS[i].x2  &
                          v2_17.x3  == TestData_LHS[i].x3  &
                          v2_17.x4  == TestData_LHS[i].x4  &
                          v2_17.x5  == TestData_LHS[i].x5  &
                          v2_17.x6  == TestData_LHS[i].x6  &
                          v2_17.x7  == TestData_LHS[i].x7  &
                          v2_17.x8  == TestData_LHS[i].x8  &
                          v2_17.x9  == TestData_LHS[i].x9  &
                          v2_17.x10 == TestData_LHS[i].x10 &
                          v2_17.x11 == TestData_LHS[i].x11 &
                          v2_17.x12 == TestData_LHS[i].x12 &
                          v2_17.x13 == TestData_LHS[i].x13 &
                          v2_17.x14 == TestData_LHS[i].x14 &
                          v2_17.x15 == TestData_LHS[i].x15 &
                          v2_17.x16 == TestData_LHS[i].x16 &
                          v2_17.x17 == t_sbyte2.TestData_LHS[i].x &
                          v2_17.x18 == t_sbyte2.TestData_LHS[i].y &
                          v2_17.x19 == TestData_LHS[i].x19 &
                          v2_17.x20 == TestData_LHS[i].x20 &
                          v2_17.x21 == TestData_LHS[i].x21 &
                          v2_17.x22 == TestData_LHS[i].x22 &
                          v2_17.x23 == TestData_LHS[i].x23 &
                          v2_17.x24 == TestData_LHS[i].x24 &
                          v2_17.x25 == TestData_LHS[i].x25 &
                          v2_17.x26 == TestData_LHS[i].x26 &
                          v2_17.x27 == TestData_LHS[i].x27 &
                          v2_17.x28 == TestData_LHS[i].x28 &
                          v2_17.x29 == TestData_LHS[i].x29 &
                          v2_17.x30 == TestData_LHS[i].x30 &
                          v2_17.x31 == TestData_LHS[i].x31;

                sbyte32 v2_18 = TestData_LHS[i];
                v2_18.v2_18 = t_sbyte2.TestData_LHS[i];
                result &= v2_18.x0  == TestData_LHS[i].x0  &
                          v2_18.x1  == TestData_LHS[i].x1  &
                          v2_18.x2  == TestData_LHS[i].x2  &
                          v2_18.x3  == TestData_LHS[i].x3  &
                          v2_18.x4  == TestData_LHS[i].x4  &
                          v2_18.x5  == TestData_LHS[i].x5  &
                          v2_18.x6  == TestData_LHS[i].x6  &
                          v2_18.x7  == TestData_LHS[i].x7  &
                          v2_18.x8  == TestData_LHS[i].x8  &
                          v2_18.x9  == TestData_LHS[i].x9  &
                          v2_18.x10 == TestData_LHS[i].x10 &
                          v2_18.x11 == TestData_LHS[i].x11 &
                          v2_18.x12 == TestData_LHS[i].x12 &
                          v2_18.x13 == TestData_LHS[i].x13 &
                          v2_18.x14 == TestData_LHS[i].x14 &
                          v2_18.x15 == TestData_LHS[i].x15 &
                          v2_18.x16 == TestData_LHS[i].x16 &
                          v2_18.x17 == TestData_LHS[i].x17 &
                          v2_18.x18 == t_sbyte2.TestData_LHS[i].x &
                          v2_18.x19 == t_sbyte2.TestData_LHS[i].y &
                          v2_18.x20 == TestData_LHS[i].x20 &
                          v2_18.x21 == TestData_LHS[i].x21 &
                          v2_18.x22 == TestData_LHS[i].x22 &
                          v2_18.x23 == TestData_LHS[i].x23 &
                          v2_18.x24 == TestData_LHS[i].x24 &
                          v2_18.x25 == TestData_LHS[i].x25 &
                          v2_18.x26 == TestData_LHS[i].x26 &
                          v2_18.x27 == TestData_LHS[i].x27 &
                          v2_18.x28 == TestData_LHS[i].x28 &
                          v2_18.x29 == TestData_LHS[i].x29 &
                          v2_18.x30 == TestData_LHS[i].x30 &
                          v2_18.x31 == TestData_LHS[i].x31;

                sbyte32 v2_19 = TestData_LHS[i];
                v2_19.v2_19 = t_sbyte2.TestData_LHS[i];
                result &= v2_19.x0  == TestData_LHS[i].x0  &
                          v2_19.x1  == TestData_LHS[i].x1  &
                          v2_19.x2  == TestData_LHS[i].x2  &
                          v2_19.x3  == TestData_LHS[i].x3  &
                          v2_19.x4  == TestData_LHS[i].x4  &
                          v2_19.x5  == TestData_LHS[i].x5  &
                          v2_19.x6  == TestData_LHS[i].x6  &
                          v2_19.x7  == TestData_LHS[i].x7  &
                          v2_19.x8  == TestData_LHS[i].x8  &
                          v2_19.x9  == TestData_LHS[i].x9  &
                          v2_19.x10 == TestData_LHS[i].x10 &
                          v2_19.x11 == TestData_LHS[i].x11 &
                          v2_19.x12 == TestData_LHS[i].x12 &
                          v2_19.x13 == TestData_LHS[i].x13 &
                          v2_19.x14 == TestData_LHS[i].x14 &
                          v2_19.x15 == TestData_LHS[i].x15 &
                          v2_19.x16 == TestData_LHS[i].x16 &
                          v2_19.x17 == TestData_LHS[i].x17 &
                          v2_19.x18 == TestData_LHS[i].x18 &
                          v2_19.x19 == t_sbyte2.TestData_LHS[i].x &
                          v2_19.x20 == t_sbyte2.TestData_LHS[i].y &
                          v2_19.x21 == TestData_LHS[i].x21 &
                          v2_19.x22 == TestData_LHS[i].x22 &
                          v2_19.x23 == TestData_LHS[i].x23 &
                          v2_19.x24 == TestData_LHS[i].x24 &
                          v2_19.x25 == TestData_LHS[i].x25 &
                          v2_19.x26 == TestData_LHS[i].x26 &
                          v2_19.x27 == TestData_LHS[i].x27 &
                          v2_19.x28 == TestData_LHS[i].x28 &
                          v2_19.x29 == TestData_LHS[i].x29 &
                          v2_19.x30 == TestData_LHS[i].x30 &
                          v2_19.x31 == TestData_LHS[i].x31;

                sbyte32 v2_20 = TestData_LHS[i];
                v2_20.v2_20 = t_sbyte2.TestData_LHS[i];
                result &= v2_20.x0  == TestData_LHS[i].x0  &
                          v2_20.x1  == TestData_LHS[i].x1  &
                          v2_20.x2  == TestData_LHS[i].x2  &
                          v2_20.x3  == TestData_LHS[i].x3  &
                          v2_20.x4  == TestData_LHS[i].x4  &
                          v2_20.x5  == TestData_LHS[i].x5  &
                          v2_20.x6  == TestData_LHS[i].x6  &
                          v2_20.x7  == TestData_LHS[i].x7  &
                          v2_20.x8  == TestData_LHS[i].x8  &
                          v2_20.x9  == TestData_LHS[i].x9  &
                          v2_20.x10 == TestData_LHS[i].x10 &
                          v2_20.x11 == TestData_LHS[i].x11 &
                          v2_20.x12 == TestData_LHS[i].x12 &
                          v2_20.x13 == TestData_LHS[i].x13 &
                          v2_20.x14 == TestData_LHS[i].x14 &
                          v2_20.x15 == TestData_LHS[i].x15 &
                          v2_20.x16 == TestData_LHS[i].x16 &
                          v2_20.x17 == TestData_LHS[i].x17 &
                          v2_20.x18 == TestData_LHS[i].x18 &
                          v2_20.x19 == TestData_LHS[i].x19 &
                          v2_20.x20 == t_sbyte2.TestData_LHS[i].x &
                          v2_20.x21 == t_sbyte2.TestData_LHS[i].y &
                          v2_20.x22 == TestData_LHS[i].x22 &
                          v2_20.x23 == TestData_LHS[i].x23 &
                          v2_20.x24 == TestData_LHS[i].x24 &
                          v2_20.x25 == TestData_LHS[i].x25 &
                          v2_20.x26 == TestData_LHS[i].x26 &
                          v2_20.x27 == TestData_LHS[i].x27 &
                          v2_20.x28 == TestData_LHS[i].x28 &
                          v2_20.x29 == TestData_LHS[i].x29 &
                          v2_20.x30 == TestData_LHS[i].x30 &
                          v2_20.x31 == TestData_LHS[i].x31;

                sbyte32 v2_21 = TestData_LHS[i];
                v2_21.v2_21 = t_sbyte2.TestData_LHS[i];
                result &= v2_21.x0  == TestData_LHS[i].x0  &
                          v2_21.x1  == TestData_LHS[i].x1  &
                          v2_21.x2  == TestData_LHS[i].x2  &
                          v2_21.x3  == TestData_LHS[i].x3  &
                          v2_21.x4  == TestData_LHS[i].x4  &
                          v2_21.x5  == TestData_LHS[i].x5  &
                          v2_21.x6  == TestData_LHS[i].x6  &
                          v2_21.x7  == TestData_LHS[i].x7  &
                          v2_21.x8  == TestData_LHS[i].x8  &
                          v2_21.x9  == TestData_LHS[i].x9  &
                          v2_21.x10 == TestData_LHS[i].x10 &
                          v2_21.x11 == TestData_LHS[i].x11 &
                          v2_21.x12 == TestData_LHS[i].x12 &
                          v2_21.x13 == TestData_LHS[i].x13 &
                          v2_21.x14 == TestData_LHS[i].x14 &
                          v2_21.x15 == TestData_LHS[i].x15 &
                          v2_21.x16 == TestData_LHS[i].x16 &
                          v2_21.x17 == TestData_LHS[i].x17 &
                          v2_21.x18 == TestData_LHS[i].x18 &
                          v2_21.x19 == TestData_LHS[i].x19 &
                          v2_21.x20 == TestData_LHS[i].x20 &
                          v2_21.x21 == t_sbyte2.TestData_LHS[i].x &
                          v2_21.x22 == t_sbyte2.TestData_LHS[i].y &
                          v2_21.x23 == TestData_LHS[i].x23 &
                          v2_21.x24 == TestData_LHS[i].x24 &
                          v2_21.x25 == TestData_LHS[i].x25 &
                          v2_21.x26 == TestData_LHS[i].x26 &
                          v2_21.x27 == TestData_LHS[i].x27 &
                          v2_21.x28 == TestData_LHS[i].x28 &
                          v2_21.x29 == TestData_LHS[i].x29 &
                          v2_21.x30 == TestData_LHS[i].x30 &
                          v2_21.x31 == TestData_LHS[i].x31;

                sbyte32 v2_22 = TestData_LHS[i];
                v2_22.v2_22 = t_sbyte2.TestData_LHS[i];
                result &= v2_22.x0  == TestData_LHS[i].x0  &
                          v2_22.x1  == TestData_LHS[i].x1  &
                          v2_22.x2  == TestData_LHS[i].x2  &
                          v2_22.x3  == TestData_LHS[i].x3  &
                          v2_22.x4  == TestData_LHS[i].x4  &
                          v2_22.x5  == TestData_LHS[i].x5  &
                          v2_22.x6  == TestData_LHS[i].x6  &
                          v2_22.x7  == TestData_LHS[i].x7  &
                          v2_22.x8  == TestData_LHS[i].x8  &
                          v2_22.x9  == TestData_LHS[i].x9  &
                          v2_22.x10 == TestData_LHS[i].x10 &
                          v2_22.x11 == TestData_LHS[i].x11 &
                          v2_22.x12 == TestData_LHS[i].x12 &
                          v2_22.x13 == TestData_LHS[i].x13 &
                          v2_22.x14 == TestData_LHS[i].x14 &
                          v2_22.x15 == TestData_LHS[i].x15 &
                          v2_22.x16 == TestData_LHS[i].x16 &
                          v2_22.x17 == TestData_LHS[i].x17 &
                          v2_22.x18 == TestData_LHS[i].x18 &
                          v2_22.x19 == TestData_LHS[i].x19 &
                          v2_22.x20 == TestData_LHS[i].x20 &
                          v2_22.x21 == TestData_LHS[i].x21 &
                          v2_22.x22 == t_sbyte2.TestData_LHS[i].x &
                          v2_22.x23 == t_sbyte2.TestData_LHS[i].y &
                          v2_22.x24 == TestData_LHS[i].x24 &
                          v2_22.x25 == TestData_LHS[i].x25 &
                          v2_22.x26 == TestData_LHS[i].x26 &
                          v2_22.x27 == TestData_LHS[i].x27 &
                          v2_22.x28 == TestData_LHS[i].x28 &
                          v2_22.x29 == TestData_LHS[i].x29 &
                          v2_22.x30 == TestData_LHS[i].x30 &
                          v2_22.x31 == TestData_LHS[i].x31;

                sbyte32 v2_23 = TestData_LHS[i];
                v2_23.v2_23 = t_sbyte2.TestData_LHS[i];
                result &= v2_23.x0  == TestData_LHS[i].x0  &
                          v2_23.x1  == TestData_LHS[i].x1  &
                          v2_23.x2  == TestData_LHS[i].x2  &
                          v2_23.x3  == TestData_LHS[i].x3  &
                          v2_23.x4  == TestData_LHS[i].x4  &
                          v2_23.x5  == TestData_LHS[i].x5  &
                          v2_23.x6  == TestData_LHS[i].x6  &
                          v2_23.x7  == TestData_LHS[i].x7  &
                          v2_23.x8  == TestData_LHS[i].x8  &
                          v2_23.x9  == TestData_LHS[i].x9  &
                          v2_23.x10 == TestData_LHS[i].x10 &
                          v2_23.x11 == TestData_LHS[i].x11 &
                          v2_23.x12 == TestData_LHS[i].x12 &
                          v2_23.x13 == TestData_LHS[i].x13 &
                          v2_23.x14 == TestData_LHS[i].x14 &
                          v2_23.x15 == TestData_LHS[i].x15 &
                          v2_23.x16 == TestData_LHS[i].x16 &
                          v2_23.x17 == TestData_LHS[i].x17 &
                          v2_23.x18 == TestData_LHS[i].x18 &
                          v2_23.x19 == TestData_LHS[i].x19 &
                          v2_23.x20 == TestData_LHS[i].x20 &
                          v2_23.x21 == TestData_LHS[i].x21 &
                          v2_23.x22 == TestData_LHS[i].x22 &
                          v2_23.x23 == t_sbyte2.TestData_LHS[i].x &
                          v2_23.x24 == t_sbyte2.TestData_LHS[i].y &
                          v2_23.x25 == TestData_LHS[i].x25 &
                          v2_23.x26 == TestData_LHS[i].x26 &
                          v2_23.x27 == TestData_LHS[i].x27 &
                          v2_23.x28 == TestData_LHS[i].x28 &
                          v2_23.x29 == TestData_LHS[i].x29 &
                          v2_23.x30 == TestData_LHS[i].x30 &
                          v2_23.x31 == TestData_LHS[i].x31;

                sbyte32 v2_24 = TestData_LHS[i];
                v2_24.v2_24 = t_sbyte2.TestData_LHS[i];
                result &= v2_24.x0  == TestData_LHS[i].x0  &
                          v2_24.x1  == TestData_LHS[i].x1  &
                          v2_24.x2  == TestData_LHS[i].x2  &
                          v2_24.x3  == TestData_LHS[i].x3  &
                          v2_24.x4  == TestData_LHS[i].x4  &
                          v2_24.x5  == TestData_LHS[i].x5  &
                          v2_24.x6  == TestData_LHS[i].x6  &
                          v2_24.x7  == TestData_LHS[i].x7  &
                          v2_24.x8  == TestData_LHS[i].x8  &
                          v2_24.x9  == TestData_LHS[i].x9  &
                          v2_24.x10 == TestData_LHS[i].x10 &
                          v2_24.x11 == TestData_LHS[i].x11 &
                          v2_24.x12 == TestData_LHS[i].x12 &
                          v2_24.x13 == TestData_LHS[i].x13 &
                          v2_24.x14 == TestData_LHS[i].x14 &
                          v2_24.x15 == TestData_LHS[i].x15 &
                          v2_24.x16 == TestData_LHS[i].x16 &
                          v2_24.x17 == TestData_LHS[i].x17 &
                          v2_24.x18 == TestData_LHS[i].x18 &
                          v2_24.x19 == TestData_LHS[i].x19 &
                          v2_24.x20 == TestData_LHS[i].x20 &
                          v2_24.x21 == TestData_LHS[i].x21 &
                          v2_24.x22 == TestData_LHS[i].x22 &
                          v2_24.x23 == TestData_LHS[i].x23 &
                          v2_24.x24 == t_sbyte2.TestData_LHS[i].x &
                          v2_24.x25 == t_sbyte2.TestData_LHS[i].y &
                          v2_24.x26 == TestData_LHS[i].x26 &
                          v2_24.x27 == TestData_LHS[i].x27 &
                          v2_24.x28 == TestData_LHS[i].x28 &
                          v2_24.x29 == TestData_LHS[i].x29 &
                          v2_24.x30 == TestData_LHS[i].x30 &
                          v2_24.x31 == TestData_LHS[i].x31;

                sbyte32 v2_25 = TestData_LHS[i];
                v2_25.v2_25 = t_sbyte2.TestData_LHS[i];
                result &= v2_25.x0  == TestData_LHS[i].x0  &
                          v2_25.x1  == TestData_LHS[i].x1  &
                          v2_25.x2  == TestData_LHS[i].x2  &
                          v2_25.x3  == TestData_LHS[i].x3  &
                          v2_25.x4  == TestData_LHS[i].x4  &
                          v2_25.x5  == TestData_LHS[i].x5  &
                          v2_25.x6  == TestData_LHS[i].x6  &
                          v2_25.x7  == TestData_LHS[i].x7  &
                          v2_25.x8  == TestData_LHS[i].x8  &
                          v2_25.x9  == TestData_LHS[i].x9  &
                          v2_25.x10 == TestData_LHS[i].x10 &
                          v2_25.x11 == TestData_LHS[i].x11 &
                          v2_25.x12 == TestData_LHS[i].x12 &
                          v2_25.x13 == TestData_LHS[i].x13 &
                          v2_25.x14 == TestData_LHS[i].x14 &
                          v2_25.x15 == TestData_LHS[i].x15 &
                          v2_25.x16 == TestData_LHS[i].x16 &
                          v2_25.x17 == TestData_LHS[i].x17 &
                          v2_25.x18 == TestData_LHS[i].x18 &
                          v2_25.x19 == TestData_LHS[i].x19 &
                          v2_25.x20 == TestData_LHS[i].x20 &
                          v2_25.x21 == TestData_LHS[i].x21 &
                          v2_25.x22 == TestData_LHS[i].x22 &
                          v2_25.x23 == TestData_LHS[i].x23 &
                          v2_25.x24 == TestData_LHS[i].x24 &
                          v2_25.x25 == t_sbyte2.TestData_LHS[i].x &
                          v2_25.x26 == t_sbyte2.TestData_LHS[i].y &
                          v2_25.x27 == TestData_LHS[i].x27 &
                          v2_25.x28 == TestData_LHS[i].x28 &
                          v2_25.x29 == TestData_LHS[i].x29 &
                          v2_25.x30 == TestData_LHS[i].x30 &
                          v2_25.x31 == TestData_LHS[i].x31;

                sbyte32 v2_26 = TestData_LHS[i];
                v2_26.v2_26 = t_sbyte2.TestData_LHS[i];
                result &= v2_26.x0  == TestData_LHS[i].x0  &
                          v2_26.x1  == TestData_LHS[i].x1  &
                          v2_26.x2  == TestData_LHS[i].x2  &
                          v2_26.x3  == TestData_LHS[i].x3  &
                          v2_26.x4  == TestData_LHS[i].x4  &
                          v2_26.x5  == TestData_LHS[i].x5  &
                          v2_26.x6  == TestData_LHS[i].x6  &
                          v2_26.x7  == TestData_LHS[i].x7  &
                          v2_26.x8  == TestData_LHS[i].x8  &
                          v2_26.x9  == TestData_LHS[i].x9  &
                          v2_26.x10 == TestData_LHS[i].x10 &
                          v2_26.x11 == TestData_LHS[i].x11 &
                          v2_26.x12 == TestData_LHS[i].x12 &
                          v2_26.x13 == TestData_LHS[i].x13 &
                          v2_26.x14 == TestData_LHS[i].x14 &
                          v2_26.x15 == TestData_LHS[i].x15 &
                          v2_26.x16 == TestData_LHS[i].x16 &
                          v2_26.x17 == TestData_LHS[i].x17 &
                          v2_26.x18 == TestData_LHS[i].x18 &
                          v2_26.x19 == TestData_LHS[i].x19 &
                          v2_26.x20 == TestData_LHS[i].x20 &
                          v2_26.x21 == TestData_LHS[i].x21 &
                          v2_26.x22 == TestData_LHS[i].x22 &
                          v2_26.x23 == TestData_LHS[i].x23 &
                          v2_26.x24 == TestData_LHS[i].x24 &
                          v2_26.x25 == TestData_LHS[i].x25 &
                          v2_26.x26 == t_sbyte2.TestData_LHS[i].x &
                          v2_26.x27 == t_sbyte2.TestData_LHS[i].y &
                          v2_26.x28 == TestData_LHS[i].x28 &
                          v2_26.x29 == TestData_LHS[i].x29 &
                          v2_26.x30 == TestData_LHS[i].x30 &
                          v2_26.x31 == TestData_LHS[i].x31;

                sbyte32 v2_27 = TestData_LHS[i];
                v2_27.v2_27 = t_sbyte2.TestData_LHS[i];
                result &= v2_27.x0  == TestData_LHS[i].x0  &
                          v2_27.x1  == TestData_LHS[i].x1  &
                          v2_27.x2  == TestData_LHS[i].x2  &
                          v2_27.x3  == TestData_LHS[i].x3  &
                          v2_27.x4  == TestData_LHS[i].x4  &
                          v2_27.x5  == TestData_LHS[i].x5  &
                          v2_27.x6  == TestData_LHS[i].x6  &
                          v2_27.x7  == TestData_LHS[i].x7  &
                          v2_27.x8  == TestData_LHS[i].x8  &
                          v2_27.x9  == TestData_LHS[i].x9  &
                          v2_27.x10 == TestData_LHS[i].x10 &
                          v2_27.x11 == TestData_LHS[i].x11 &
                          v2_27.x12 == TestData_LHS[i].x12 &
                          v2_27.x13 == TestData_LHS[i].x13 &
                          v2_27.x14 == TestData_LHS[i].x14 &
                          v2_27.x15 == TestData_LHS[i].x15 &
                          v2_27.x16 == TestData_LHS[i].x16 &
                          v2_27.x17 == TestData_LHS[i].x17 &
                          v2_27.x18 == TestData_LHS[i].x18 &
                          v2_27.x19 == TestData_LHS[i].x19 &
                          v2_27.x20 == TestData_LHS[i].x20 &
                          v2_27.x21 == TestData_LHS[i].x21 &
                          v2_27.x22 == TestData_LHS[i].x22 &
                          v2_27.x23 == TestData_LHS[i].x23 &
                          v2_27.x24 == TestData_LHS[i].x24 &
                          v2_27.x25 == TestData_LHS[i].x25 &
                          v2_27.x26 == TestData_LHS[i].x26 &
                          v2_27.x27 == t_sbyte2.TestData_LHS[i].x &
                          v2_27.x28 == t_sbyte2.TestData_LHS[i].y &
                          v2_27.x29 == TestData_LHS[i].x29 &
                          v2_27.x30 == TestData_LHS[i].x30 &
                          v2_27.x31 == TestData_LHS[i].x31;

                sbyte32 v2_28 = TestData_LHS[i];
                v2_28.v2_28 = t_sbyte2.TestData_LHS[i];
                result &= v2_28.x0  == TestData_LHS[i].x0  &
                          v2_28.x1  == TestData_LHS[i].x1  &
                          v2_28.x2  == TestData_LHS[i].x2  &
                          v2_28.x3  == TestData_LHS[i].x3  &
                          v2_28.x4  == TestData_LHS[i].x4  &
                          v2_28.x5  == TestData_LHS[i].x5  &
                          v2_28.x6  == TestData_LHS[i].x6  &
                          v2_28.x7  == TestData_LHS[i].x7  &
                          v2_28.x8  == TestData_LHS[i].x8  &
                          v2_28.x9  == TestData_LHS[i].x9  &
                          v2_28.x10 == TestData_LHS[i].x10 &
                          v2_28.x11 == TestData_LHS[i].x11 &
                          v2_28.x12 == TestData_LHS[i].x12 &
                          v2_28.x13 == TestData_LHS[i].x13 &
                          v2_28.x14 == TestData_LHS[i].x14 &
                          v2_28.x15 == TestData_LHS[i].x15 &
                          v2_28.x16 == TestData_LHS[i].x16 &
                          v2_28.x17 == TestData_LHS[i].x17 &
                          v2_28.x18 == TestData_LHS[i].x18 &
                          v2_28.x19 == TestData_LHS[i].x19 &
                          v2_28.x20 == TestData_LHS[i].x20 &
                          v2_28.x21 == TestData_LHS[i].x21 &
                          v2_28.x22 == TestData_LHS[i].x22 &
                          v2_28.x23 == TestData_LHS[i].x23 &
                          v2_28.x24 == TestData_LHS[i].x24 &
                          v2_28.x25 == TestData_LHS[i].x25 &
                          v2_28.x26 == TestData_LHS[i].x26 &
                          v2_28.x27 == TestData_LHS[i].x27 &
                          v2_28.x28 == t_sbyte2.TestData_LHS[i].x &
                          v2_28.x29 == t_sbyte2.TestData_LHS[i].y &
                          v2_28.x30 == TestData_LHS[i].x30 &
                          v2_28.x31 == TestData_LHS[i].x31;

                sbyte32 v2_29 = TestData_LHS[i];
                v2_29.v2_29 = t_sbyte2.TestData_LHS[i];
                result &= v2_29.x0  == TestData_LHS[i].x0  &
                          v2_29.x1  == TestData_LHS[i].x1  &
                          v2_29.x2  == TestData_LHS[i].x2  &
                          v2_29.x3  == TestData_LHS[i].x3  &
                          v2_29.x4  == TestData_LHS[i].x4  &
                          v2_29.x5  == TestData_LHS[i].x5  &
                          v2_29.x6  == TestData_LHS[i].x6  &
                          v2_29.x7  == TestData_LHS[i].x7  &
                          v2_29.x8  == TestData_LHS[i].x8  &
                          v2_29.x9  == TestData_LHS[i].x9  &
                          v2_29.x10 == TestData_LHS[i].x10 &
                          v2_29.x11 == TestData_LHS[i].x11 &
                          v2_29.x12 == TestData_LHS[i].x12 &
                          v2_29.x13 == TestData_LHS[i].x13 &
                          v2_29.x14 == TestData_LHS[i].x14 &
                          v2_29.x15 == TestData_LHS[i].x15 &
                          v2_29.x16 == TestData_LHS[i].x16 &
                          v2_29.x17 == TestData_LHS[i].x17 &
                          v2_29.x18 == TestData_LHS[i].x18 &
                          v2_29.x19 == TestData_LHS[i].x19 &
                          v2_29.x20 == TestData_LHS[i].x20 &
                          v2_29.x21 == TestData_LHS[i].x21 &
                          v2_29.x22 == TestData_LHS[i].x22 &
                          v2_29.x23 == TestData_LHS[i].x23 &
                          v2_29.x24 == TestData_LHS[i].x24 &
                          v2_29.x25 == TestData_LHS[i].x25 &
                          v2_29.x26 == TestData_LHS[i].x26 &
                          v2_29.x27 == TestData_LHS[i].x27 &
                          v2_29.x28 == TestData_LHS[i].x28 &
                          v2_29.x29 == t_sbyte2.TestData_LHS[i].x &
                          v2_29.x30 == t_sbyte2.TestData_LHS[i].y &
                          v2_29.x31 == TestData_LHS[i].x31;

                sbyte32 v2_30 = TestData_LHS[i];
                v2_30.v2_30 = t_sbyte2.TestData_LHS[i];
                result &= v2_30.x0  == TestData_LHS[i].x0  &
                          v2_30.x1  == TestData_LHS[i].x1  &
                          v2_30.x2  == TestData_LHS[i].x2  &
                          v2_30.x3  == TestData_LHS[i].x3  &
                          v2_30.x4  == TestData_LHS[i].x4  &
                          v2_30.x5  == TestData_LHS[i].x5  &
                          v2_30.x6  == TestData_LHS[i].x6  &
                          v2_30.x7  == TestData_LHS[i].x7  &
                          v2_30.x8  == TestData_LHS[i].x8  &
                          v2_30.x9  == TestData_LHS[i].x9  &
                          v2_30.x10 == TestData_LHS[i].x10 &
                          v2_30.x11 == TestData_LHS[i].x11 &
                          v2_30.x12 == TestData_LHS[i].x12 &
                          v2_30.x13 == TestData_LHS[i].x13 &
                          v2_30.x14 == TestData_LHS[i].x14 &
                          v2_30.x15 == TestData_LHS[i].x15 &
                          v2_30.x16 == TestData_LHS[i].x16 &
                          v2_30.x17 == TestData_LHS[i].x17 &
                          v2_30.x18 == TestData_LHS[i].x18 &
                          v2_30.x19 == TestData_LHS[i].x19 &
                          v2_30.x20 == TestData_LHS[i].x20 &
                          v2_30.x21 == TestData_LHS[i].x21 &
                          v2_30.x22 == TestData_LHS[i].x22 &
                          v2_30.x23 == TestData_LHS[i].x23 &
                          v2_30.x24 == TestData_LHS[i].x24 &
                          v2_30.x25 == TestData_LHS[i].x25 &
                          v2_30.x26 == TestData_LHS[i].x26 &
                          v2_30.x27 == TestData_LHS[i].x27 &
                          v2_30.x28 == TestData_LHS[i].x28 &
                          v2_30.x29 == TestData_LHS[i].x29 &
                          v2_30.x30 == t_sbyte2.TestData_LHS[i].x &
                          v2_30.x31 == t_sbyte2.TestData_LHS[i].y;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v256 x = TestData_LHS[i];

                result &= x.SByte0  == TestData_LHS[i].x0  &
                          x.SByte1  == TestData_LHS[i].x1  &
                          x.SByte2  == TestData_LHS[i].x2  &
                          x.SByte3  == TestData_LHS[i].x3  &
                          x.SByte4  == TestData_LHS[i].x4  &
                          x.SByte5  == TestData_LHS[i].x5  &
                          x.SByte6  == TestData_LHS[i].x6  &
                          x.SByte7  == TestData_LHS[i].x7  &
                          x.SByte8  == TestData_LHS[i].x8  &
                          x.SByte9  == TestData_LHS[i].x9  &
                          x.SByte10 == TestData_LHS[i].x10 &
                          x.SByte11 == TestData_LHS[i].x11 &
                          x.SByte12 == TestData_LHS[i].x12 &
                          x.SByte13 == TestData_LHS[i].x13 &
                          x.SByte14 == TestData_LHS[i].x14 &
                          x.SByte15 == TestData_LHS[i].x15 &
                          x.SByte16 == TestData_LHS[i].x16 &
                          x.SByte17 == TestData_LHS[i].x17 &
                          x.SByte18 == TestData_LHS[i].x18 &
                          x.SByte19 == TestData_LHS[i].x19 &
                          x.SByte20 == TestData_LHS[i].x20 &
                          x.SByte21 == TestData_LHS[i].x21 &
                          x.SByte22 == TestData_LHS[i].x22 &
                          x.SByte23 == TestData_LHS[i].x23 &
                          x.SByte24 == TestData_LHS[i].x24 &
                          x.SByte25 == TestData_LHS[i].x25 &
                          x.SByte26 == TestData_LHS[i].x26 &
                          x.SByte27 == TestData_LHS[i].x27 &
                          x.SByte28 == TestData_LHS[i].x28 &
                          x.SByte29 == TestData_LHS[i].x29 &
                          x.SByte30 == TestData_LHS[i].x30 &
                          x.SByte31 == TestData_LHS[i].x31;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i];
                v256 c = x;
                x = c;

                result &= x.x0  == TestData_LHS[i].x0  &
                          x.x1  == TestData_LHS[i].x1  &
                          x.x2  == TestData_LHS[i].x2  &
                          x.x3  == TestData_LHS[i].x3  &
                          x.x4  == TestData_LHS[i].x4  &
                          x.x5  == TestData_LHS[i].x5  &
                          x.x6  == TestData_LHS[i].x6  &
                          x.x7  == TestData_LHS[i].x7  &
                          x.x8  == TestData_LHS[i].x8  &
                          x.x9  == TestData_LHS[i].x9  &
                          x.x10 == TestData_LHS[i].x10 &
                          x.x11 == TestData_LHS[i].x11 &
                          x.x12 == TestData_LHS[i].x12 &
                          x.x13 == TestData_LHS[i].x13 &
                          x.x14 == TestData_LHS[i].x14 &
                          x.x15 == TestData_LHS[i].x15 &
                          x.x16 == TestData_LHS[i].x16 &
                          x.x17 == TestData_LHS[i].x17 &
                          x.x18 == TestData_LHS[i].x18 &
                          x.x19 == TestData_LHS[i].x19 &
                          x.x20 == TestData_LHS[i].x20 &
                          x.x21 == TestData_LHS[i].x21 &
                          x.x22 == TestData_LHS[i].x22 &
                          x.x23 == TestData_LHS[i].x23 &
                          x.x24 == TestData_LHS[i].x24 &
                          x.x25 == TestData_LHS[i].x25 &
                          x.x26 == TestData_LHS[i].x26 &
                          x.x27 == TestData_LHS[i].x27 &
                          x.x28 == TestData_LHS[i].x28 &
                          x.x29 == TestData_LHS[i].x29 &
                          x.x30 == TestData_LHS[i].x30 &
                          x.x31 == TestData_LHS[i].x31;
            }

            Assert.AreEqual(true, result);
        }
    }
}