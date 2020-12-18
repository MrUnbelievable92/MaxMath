using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class SByte32
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
					    x28 = 0,
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
        public static void Constructor_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte()
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
        public static void Constructor_SByte16_SByte16()
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
        }


        [Test]
        public static void Add()
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
        public static void Subtract()
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
        public static void Multiply()
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
        public static void Divide()
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
        public static void Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  % TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  % TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  % TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  % TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  % TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  % TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  % TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  % TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  % TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  % TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 % TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 % TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 % TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 % TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 % TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 % TestData_RHS[i].x15) &
                          x.x16 == (sbyte)(TestData_LHS[i].x16 % TestData_RHS[i].x16) &
                          x.x17 == (sbyte)(TestData_LHS[i].x17 % TestData_RHS[i].x17) &
                          x.x18 == (sbyte)(TestData_LHS[i].x18 % TestData_RHS[i].x18) &
                          x.x19 == (sbyte)(TestData_LHS[i].x19 % TestData_RHS[i].x19) &
                          x.x20 == (sbyte)(TestData_LHS[i].x20 % TestData_RHS[i].x20) &
                          x.x21 == (sbyte)(TestData_LHS[i].x21 % TestData_RHS[i].x21) &
                          x.x22 == (sbyte)(TestData_LHS[i].x22 % TestData_RHS[i].x22) &
                          x.x23 == (sbyte)(TestData_LHS[i].x23 % TestData_RHS[i].x23) &
                          x.x24 == (sbyte)(TestData_LHS[i].x24 % TestData_RHS[i].x24) &
                          x.x25 == (sbyte)(TestData_LHS[i].x25 % TestData_RHS[i].x25) &
                          x.x26 == (sbyte)(TestData_LHS[i].x26 % TestData_RHS[i].x26) &
                          x.x27 == (sbyte)(TestData_LHS[i].x27 % TestData_RHS[i].x27) &
                          x.x28 == (sbyte)(TestData_LHS[i].x28 % TestData_RHS[i].x28) &
                          x.x29 == (sbyte)(TestData_LHS[i].x29 % TestData_RHS[i].x29) &
                          x.x30 == (sbyte)(TestData_LHS[i].x30 % TestData_RHS[i].x30) &
                          x.x31 == (sbyte)(TestData_LHS[i].x31 % TestData_RHS[i].x31);
            }

            Assert.AreEqual(true, result);
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
        public static void AND()
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
        public static void OR()
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
        public static void XOR()
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
        public static void Shuffle()
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