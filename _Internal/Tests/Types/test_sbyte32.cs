using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class SByte32
    {
        internal const int NUM_TESTS = 4;


        internal static sbyte32[] TestData_LHS => new sbyte32[]
        {
            new sbyte32(-83, 55, 99, 76, 65, 1, -11, 35, 75, 99, -11, 54, 68, 32, -54, -77, 35, 75, 99, -11, 66, -99, 39, -50, 121, 3, 32, 21, 0, 47, 32, 64),
            new sbyte32(22, 12, 32, -11, 99, 80, 54, -39, 76, 65, 1, -11, 35, 75, 99, -11, 21, 9, 47, 32, -82, -39, 45, 90, -22, 3, 32, -98, -6, -34, 3, 47),      // EQUAL
            new sbyte32(87, sbyte.MaxValue, 17, 21, 0, 47, 32, -56, 87, 21, 47, -70, 54, -22, 12, -88, -39, 45, 90, -22, 3, 87, 99, 17, 21, -99, 39, -50, 121, -121, 3, 32),
            new sbyte32(sbyte.MinValue, -13, 111, 66, -99, 39, -50, 121, 32, -11, -87, 99, 80, -3, 32, -98, 6, 34, 124, 15, 99, -42, 99, -58, 80, 54, 39, 76, 65, 1, 92, 13)
        };

        internal static sbyte32[] TestData_RHS => new sbyte32[]
        {
            new sbyte32(12, 8, 53, 98, 2, -73, 97, 44, 87, -19, -82, 43, -11, 35, 75, 99, 121, 3, 32, 45, 90, -22, 3, 87, 99, 12, 32, -11, 99, 80, -37, -11),
            new sbyte32(22, 12, 32, -11, 99, 80, 54, -39, 76, 65, 1, -11, 35, 75, 99, -11, 21, 9, 47, 32, -82, -39, 45, 90, -22, 3, 32, -98, -6, -34, 3, 47),      // EQUAL
            new sbyte32(17, 87, -9, -82, -39, 45, 90, 122, -77, 12, 47, -49, 65, 7, 127, 88, -42, 99, -58, 92, 13, 80, 33, 54, 39, 32, -11, 99, 80, 76, 65, 1),
            new sbyte32(2, 9, -20, 47, -49, 65, -7, 127, -92, -19, -82, 43, 43, 2, -42, 99, -58, 92, 13, -21, 45, -90, 2, 99, 22, 32, -11, 99, 80, 3, 87, 99)
        };

        internal static int[] TestData_int32 => new int[]
        {
            7,
            3,
            2,
            0
        };


        [UnitTest("Types", "sbyte32")]
        public static bool Constructor_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte()
        {
            sbyte32 x = new sbyte32(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15, TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19 , TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23, TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31);

            return x.x0  == TestData_LHS[0].x0 &
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
                   x.x31 == TestData_LHS[0].x31;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Constructor_SByte()
        {
            sbyte32 x = new sbyte32(TestData_LHS[0].x0);

            return x.x0  == TestData_LHS[0].x0 &
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
                   x.x31 == TestData_LHS[0].x0;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Constructor_SByte16_SByte16()
        {
            sbyte32 x = new sbyte32(new sbyte16(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15), new sbyte16(TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19, TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23, TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31));

            return x.x0  == TestData_LHS[0].x0 &
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
                   x.x31 == TestData_LHS[0].x31;
        }


        [UnitTest("Types", "sbyte32")]
        public static bool Indexer()
        {
            return TestData_LHS[0][0]  == TestData_LHS[0].x0  &
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
                   TestData_LHS[0][31] == TestData_LHS[0].x31;
        }


        [UnitTest("Types", "sbyte32")]
        public static bool Add()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Subtract()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Multiply()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Divide()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Remainder()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Negate()
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

            return result;
        }


        [UnitTest("Types", "sbyte32")]
        public static bool AND()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool OR()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool XOR()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool NOT()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    sbyte32 x = TestData_LHS[i] << TestData_int32[j];

                    result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  << TestData_int32[j]) & 
                              x.x1 ==  (sbyte)(TestData_LHS[i].x1  << TestData_int32[j]) &
                              x.x2 ==  (sbyte)(TestData_LHS[i].x2  << TestData_int32[j]) &
                              x.x3 ==  (sbyte)(TestData_LHS[i].x3  << TestData_int32[j]) &
                              x.x4 ==  (sbyte)(TestData_LHS[i].x4  << TestData_int32[j]) &
                              x.x5 ==  (sbyte)(TestData_LHS[i].x5  << TestData_int32[j]) &
                              x.x6 ==  (sbyte)(TestData_LHS[i].x6  << TestData_int32[j]) &
                              x.x7 ==  (sbyte)(TestData_LHS[i].x7  << TestData_int32[j]) &
                              x.x8 ==  (sbyte)(TestData_LHS[i].x8  << TestData_int32[j]) &
                              x.x9 ==  (sbyte)(TestData_LHS[i].x9  << TestData_int32[j]) &
                              x.x10 == (sbyte)(TestData_LHS[i].x10 << TestData_int32[j]) &
                              x.x11 == (sbyte)(TestData_LHS[i].x11 << TestData_int32[j]) &
                              x.x12 == (sbyte)(TestData_LHS[i].x12 << TestData_int32[j]) &
                              x.x13 == (sbyte)(TestData_LHS[i].x13 << TestData_int32[j]) &
                              x.x14 == (sbyte)(TestData_LHS[i].x14 << TestData_int32[j]) &
                              x.x15 == (sbyte)(TestData_LHS[i].x15 << TestData_int32[j]) &
                              x.x16 == (sbyte)(TestData_LHS[i].x16 << TestData_int32[j]) &
                              x.x17 == (sbyte)(TestData_LHS[i].x17 << TestData_int32[j]) &
                              x.x18 == (sbyte)(TestData_LHS[i].x18 << TestData_int32[j]) &
                              x.x19 == (sbyte)(TestData_LHS[i].x19 << TestData_int32[j]) &
                              x.x20 == (sbyte)(TestData_LHS[i].x20 << TestData_int32[j]) &
                              x.x21 == (sbyte)(TestData_LHS[i].x21 << TestData_int32[j]) &
                              x.x22 == (sbyte)(TestData_LHS[i].x22 << TestData_int32[j]) &
                              x.x23 == (sbyte)(TestData_LHS[i].x23 << TestData_int32[j]) &
                              x.x24 == (sbyte)(TestData_LHS[i].x24 << TestData_int32[j]) &
                              x.x25 == (sbyte)(TestData_LHS[i].x25 << TestData_int32[j]) &
                              x.x26 == (sbyte)(TestData_LHS[i].x26 << TestData_int32[j]) &
                              x.x27 == (sbyte)(TestData_LHS[i].x27 << TestData_int32[j]) &
                              x.x28 == (sbyte)(TestData_LHS[i].x28 << TestData_int32[j]) &
                              x.x29 == (sbyte)(TestData_LHS[i].x29 << TestData_int32[j]) &
                              x.x30 == (sbyte)(TestData_LHS[i].x30 << TestData_int32[j]) &
                              x.x31 == (sbyte)(TestData_LHS[i].x31 << TestData_int32[j]);
                }
            }

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    sbyte32 x = TestData_LHS[i] >> TestData_int32[j];

                    result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  >> TestData_int32[j]) & 
                              x.x1 ==  (sbyte)(TestData_LHS[i].x1  >> TestData_int32[j]) &
                              x.x2 ==  (sbyte)(TestData_LHS[i].x2  >> TestData_int32[j]) &
                              x.x3 ==  (sbyte)(TestData_LHS[i].x3  >> TestData_int32[j]) &
                              x.x4 ==  (sbyte)(TestData_LHS[i].x4  >> TestData_int32[j]) &
                              x.x5 ==  (sbyte)(TestData_LHS[i].x5  >> TestData_int32[j]) &
                              x.x6 ==  (sbyte)(TestData_LHS[i].x6  >> TestData_int32[j]) &
                              x.x7 ==  (sbyte)(TestData_LHS[i].x7  >> TestData_int32[j]) &
                              x.x8 ==  (sbyte)(TestData_LHS[i].x8  >> TestData_int32[j]) &
                              x.x9 ==  (sbyte)(TestData_LHS[i].x9  >> TestData_int32[j]) &
                              x.x10 == (sbyte)(TestData_LHS[i].x10 >> TestData_int32[j]) &
                              x.x11 == (sbyte)(TestData_LHS[i].x11 >> TestData_int32[j]) &
                              x.x12 == (sbyte)(TestData_LHS[i].x12 >> TestData_int32[j]) &
                              x.x13 == (sbyte)(TestData_LHS[i].x13 >> TestData_int32[j]) &
                              x.x14 == (sbyte)(TestData_LHS[i].x14 >> TestData_int32[j]) &
                              x.x15 == (sbyte)(TestData_LHS[i].x15 >> TestData_int32[j]) &
                              x.x16 == (sbyte)(TestData_LHS[i].x16 >> TestData_int32[j]) &
                              x.x17 == (sbyte)(TestData_LHS[i].x17 >> TestData_int32[j]) &
                              x.x18 == (sbyte)(TestData_LHS[i].x18 >> TestData_int32[j]) &
                              x.x19 == (sbyte)(TestData_LHS[i].x19 >> TestData_int32[j]) &
                              x.x20 == (sbyte)(TestData_LHS[i].x20 >> TestData_int32[j]) &
                              x.x21 == (sbyte)(TestData_LHS[i].x21 >> TestData_int32[j]) &
                              x.x22 == (sbyte)(TestData_LHS[i].x22 >> TestData_int32[j]) &
                              x.x23 == (sbyte)(TestData_LHS[i].x23 >> TestData_int32[j]) &
                              x.x24 == (sbyte)(TestData_LHS[i].x24 >> TestData_int32[j]) &
                              x.x25 == (sbyte)(TestData_LHS[i].x25 >> TestData_int32[j]) &
                              x.x26 == (sbyte)(TestData_LHS[i].x26 >> TestData_int32[j]) &
                              x.x27 == (sbyte)(TestData_LHS[i].x27 >> TestData_int32[j]) &
                              x.x28 == (sbyte)(TestData_LHS[i].x28 >> TestData_int32[j]) &
                              x.x29 == (sbyte)(TestData_LHS[i].x29 >> TestData_int32[j]) &
                              x.x30 == (sbyte)(TestData_LHS[i].x30 >> TestData_int32[j]) &
                              x.x31 == (sbyte)(TestData_LHS[i].x31 >> TestData_int32[j]);
                }
            }

            return result;
        }


        [UnitTest("Types", "sbyte32")]
        public static bool Equal()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool LessThan()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool GreaterThan()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool NotEqual()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool LessThanOrEqual()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool GreaterThanOrEqual()
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

            return result;
        }


        [UnitTest("Types", "sbyte32")]
        public static bool AllEqual()
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

            return result;
        }


        [UnitTest("Types", "sbyte32")]
        public static bool Shuffle()
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


            return result;
        }


        [UnitTest("Types", "sbyte32")]
        public static bool Cast_ToV128()
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

            return result;
        }

        [UnitTest("Types", "sbyte32")]
        public static bool Cast_FromV128()
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

            return result;
        }
    }
#endif
}