using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class Byte32
    {
        internal const int NUM_TESTS = 4;


        internal static byte32[] TestData_LHS => new byte32[]
        {
            new byte32(183, 55, 99, 76, 65, 1, 211, 35, 75, 99, 211, 54, 68, 32, 254, 177, 35, 75, 99, 211, 66, 199, 39, 250, 121, 3, 32, 21, 0, 47, 32, 64),
            new byte32(22, 12, 32, 211, 99, 80, 54, 39, 76, 65, 1, 211, 35, 75, 99, 211, 21, 8, 47, 32, 182, 239, 45, 90, 222, 3, 32, 198, 6, 34, 9, 47),      // EQUAL
            new byte32(87, byte.MaxValue, 17, 21, 0, 47, 32, 156, 87, 21, 47, 170, 54, 222, 12, 88, 239, 45, 90, 222, 3, 87, 99, 17, 21, 199, 39, 250, 121, 121, 3, 32),
            new byte32(byte.MinValue, 13, 111, 66, 199, 39, 250, 121, 32, 211, 187, 99, 80, 3, 32, 198, 6, 34, 124, 15, 99, 242, 99, 158, 80, 54, 39, 76, 65, 1, 92, 13)
        };

        internal static byte32[] TestData_RHS => new byte32[]
        {
            new byte32(12, 8, 53, 98, 2, 173, 97, 44, 87, 219, 182, 43, 211, 35, 75, 99, 121, 3, 32, 45, 90, 222, 3, 87, 99, 12, 32, 211, 99, 80, 237, 211),
            new byte32(22, 12, 32, 211, 99, 80, 54, 39, 76, 65, 1, 211, 35, 75, 99, 211, 21, 8, 47, 32, 182, 239, 45, 90, 222, 3, 32, 198, 6, 34, 9, 47),      // EQUAL
            new byte32(17, 87, 9, 182, 239, 45, 90, 122, 177, 12, 47, 149, 65, 7, 127, 88, 242, 99, 158, 92, 13, 80, 33, 54, 39, 32, 211, 99, 80, 76, 65, 1),
            new byte32(2, 9, 200, 47, 149, 65, 7, 127, 192, 219, 182, 43, 43, 2, 242, 99, 158, 92, 13, 21, 45, 90, 2, 99, 22, 32, 211, 99, 80, 3, 87, 99)
        };

        internal static int[] TestData_int32 => new int[]
        {
            7,
            3,
            2,
            0
        };


        [UnitTest("Types", "byte32")]
        public static bool Constructor_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte()
        {
            byte32 x = new byte32(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15, TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19 , TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23, TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31);

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

        [UnitTest("Types", "byte32")]
        public static bool Constructor_Byte()
        {
            byte32 x = new byte32(TestData_LHS[0].x0);

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

        [UnitTest("Types", "byte32")]
        public static bool Constructor_Byte16_Byte16()
        {
            byte32 x = new byte32(new byte16(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15), new byte16(TestData_LHS[0].x16, TestData_LHS[0].x17, TestData_LHS[0].x18, TestData_LHS[0].x19, TestData_LHS[0].x20, TestData_LHS[0].x21, TestData_LHS[0].x22, TestData_LHS[0].x23, TestData_LHS[0].x24, TestData_LHS[0].x25, TestData_LHS[0].x26, TestData_LHS[0].x27, TestData_LHS[0].x28, TestData_LHS[0].x29, TestData_LHS[0].x30, TestData_LHS[0].x31));

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


        [UnitTest("Types", "byte32")]
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


        [UnitTest("Types", "byte32")]
        public static bool Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  + TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  + TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  + TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  + TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  + TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  + TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  + TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  + TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  + TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  + TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 + TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 + TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 + TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 + TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 + TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 + TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 + TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 + TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 + TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 + TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 + TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 + TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 + TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 + TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 + TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 + TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 + TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 + TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 + TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 + TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 + TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 + TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  - TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  - TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  - TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  - TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  - TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  - TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  - TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  - TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  - TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  - TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 - TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 - TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 - TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 - TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 - TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 - TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 - TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 - TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 - TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 - TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 - TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 - TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 - TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 - TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 - TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 - TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 - TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 - TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 - TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 - TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 - TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 - TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  * TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  * TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  * TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  * TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  * TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  * TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  * TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  * TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  * TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  * TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 * TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 * TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 * TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 * TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 * TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 * TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 * TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 * TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 * TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 * TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 * TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 * TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 * TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 * TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 * TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 * TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 * TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 * TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 * TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 * TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 * TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 * TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  / TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  / TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  / TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  / TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  / TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  / TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  / TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  / TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  / TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  / TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 / TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 / TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 / TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 / TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 / TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 / TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 / TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 / TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 / TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 / TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 / TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 / TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 / TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 / TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 / TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 / TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 / TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 / TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 / TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 / TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 / TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 / TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  % TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  % TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  % TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  % TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  % TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  % TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  % TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  % TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  % TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  % TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 % TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 % TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 % TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 % TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 % TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 % TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 % TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 % TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 % TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 % TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 % TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 % TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 % TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 % TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 % TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 % TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 % TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 % TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 % TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 % TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 % TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 % TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  & TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  & TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  & TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  & TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  & TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  & TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  & TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  & TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  & TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  & TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 & TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 & TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 & TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 & TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 & TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 & TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 & TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 & TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 & TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 & TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 & TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 & TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 & TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 & TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 & TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 & TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 & TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 & TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 & TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 & TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 & TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 & TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  | TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  | TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  | TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  | TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  | TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  | TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  | TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  | TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  | TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  | TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 | TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 | TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 | TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 | TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 | TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 | TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 | TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 | TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 | TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 | TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 | TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 | TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 | TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 | TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 | TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 | TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 | TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 | TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 | TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 | TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 | TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 | TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 ==  (byte)(TestData_LHS[i].x0  ^ TestData_RHS[i].x0)  & 
                          x.x1 ==  (byte)(TestData_LHS[i].x1  ^ TestData_RHS[i].x1)  &
                          x.x2 ==  (byte)(TestData_LHS[i].x2  ^ TestData_RHS[i].x2)  &
                          x.x3 ==  (byte)(TestData_LHS[i].x3  ^ TestData_RHS[i].x3)  &
                          x.x4 ==  (byte)(TestData_LHS[i].x4  ^ TestData_RHS[i].x4)  &
                          x.x5 ==  (byte)(TestData_LHS[i].x5  ^ TestData_RHS[i].x5)  &
                          x.x6 ==  (byte)(TestData_LHS[i].x6  ^ TestData_RHS[i].x6)  &
                          x.x7 ==  (byte)(TestData_LHS[i].x7  ^ TestData_RHS[i].x7)  &
                          x.x8 ==  (byte)(TestData_LHS[i].x8  ^ TestData_RHS[i].x8)  &
                          x.x9 ==  (byte)(TestData_LHS[i].x9  ^ TestData_RHS[i].x9)  &
                          x.x10 == (byte)(TestData_LHS[i].x10 ^ TestData_RHS[i].x10) &
                          x.x11 == (byte)(TestData_LHS[i].x11 ^ TestData_RHS[i].x11) &
                          x.x12 == (byte)(TestData_LHS[i].x12 ^ TestData_RHS[i].x12) &
                          x.x13 == (byte)(TestData_LHS[i].x13 ^ TestData_RHS[i].x13) &
                          x.x14 == (byte)(TestData_LHS[i].x14 ^ TestData_RHS[i].x14) &
                          x.x15 == (byte)(TestData_LHS[i].x15 ^ TestData_RHS[i].x15) &
                          x.x16 == (byte)(TestData_LHS[i].x16 ^ TestData_RHS[i].x16) &
                          x.x17 == (byte)(TestData_LHS[i].x17 ^ TestData_RHS[i].x17) &
                          x.x18 == (byte)(TestData_LHS[i].x18 ^ TestData_RHS[i].x18) &
                          x.x19 == (byte)(TestData_LHS[i].x19 ^ TestData_RHS[i].x19) &
                          x.x20 == (byte)(TestData_LHS[i].x20 ^ TestData_RHS[i].x20) &
                          x.x21 == (byte)(TestData_LHS[i].x21 ^ TestData_RHS[i].x21) &
                          x.x22 == (byte)(TestData_LHS[i].x22 ^ TestData_RHS[i].x22) &
                          x.x23 == (byte)(TestData_LHS[i].x23 ^ TestData_RHS[i].x23) &
                          x.x24 == (byte)(TestData_LHS[i].x24 ^ TestData_RHS[i].x24) &
                          x.x25 == (byte)(TestData_LHS[i].x25 ^ TestData_RHS[i].x25) &
                          x.x26 == (byte)(TestData_LHS[i].x26 ^ TestData_RHS[i].x26) &
                          x.x27 == (byte)(TestData_LHS[i].x27 ^ TestData_RHS[i].x27) &
                          x.x28 == (byte)(TestData_LHS[i].x28 ^ TestData_RHS[i].x28) &
                          x.x29 == (byte)(TestData_LHS[i].x29 ^ TestData_RHS[i].x29) &
                          x.x30 == (byte)(TestData_LHS[i].x30 ^ TestData_RHS[i].x30) &
                          x.x31 == (byte)(TestData_LHS[i].x31 ^ TestData_RHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = ~TestData_LHS[i];

                result &= x.x0 ==  (byte)(~TestData_LHS[i].x0)  & 
                          x.x1 ==  (byte)(~TestData_LHS[i].x1)  &
                          x.x2 ==  (byte)(~TestData_LHS[i].x2)  &
                          x.x3 ==  (byte)(~TestData_LHS[i].x3)  &
                          x.x4 ==  (byte)(~TestData_LHS[i].x4)  &
                          x.x5 ==  (byte)(~TestData_LHS[i].x5)  &
                          x.x6 ==  (byte)(~TestData_LHS[i].x6)  &
                          x.x7 ==  (byte)(~TestData_LHS[i].x7)  &
                          x.x8 ==  (byte)(~TestData_LHS[i].x8)  &
                          x.x9 ==  (byte)(~TestData_LHS[i].x9)  &
                          x.x10 == (byte)(~TestData_LHS[i].x10) &
                          x.x11 == (byte)(~TestData_LHS[i].x11) &
                          x.x12 == (byte)(~TestData_LHS[i].x12) &
                          x.x13 == (byte)(~TestData_LHS[i].x13) &
                          x.x14 == (byte)(~TestData_LHS[i].x14) &
                          x.x15 == (byte)(~TestData_LHS[i].x15) &
                          x.x16 == (byte)(~TestData_LHS[i].x16) &
                          x.x17 == (byte)(~TestData_LHS[i].x17) &
                          x.x18 == (byte)(~TestData_LHS[i].x18) &
                          x.x19 == (byte)(~TestData_LHS[i].x19) &
                          x.x20 == (byte)(~TestData_LHS[i].x20) &
                          x.x21 == (byte)(~TestData_LHS[i].x21) &
                          x.x22 == (byte)(~TestData_LHS[i].x22) &
                          x.x23 == (byte)(~TestData_LHS[i].x23) &
                          x.x24 == (byte)(~TestData_LHS[i].x24) &
                          x.x25 == (byte)(~TestData_LHS[i].x25) &
                          x.x26 == (byte)(~TestData_LHS[i].x26) &
                          x.x27 == (byte)(~TestData_LHS[i].x27) &
                          x.x28 == (byte)(~TestData_LHS[i].x28) &
                          x.x29 == (byte)(~TestData_LHS[i].x29) &
                          x.x30 == (byte)(~TestData_LHS[i].x30) &
                          x.x31 == (byte)(~TestData_LHS[i].x31);
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    byte32 x = TestData_LHS[i] << TestData_int32[j];

                    result &= x.x0 ==  (byte)(TestData_LHS[i].x0  << TestData_int32[j]) & 
                              x.x1 ==  (byte)(TestData_LHS[i].x1  << TestData_int32[j]) &
                              x.x2 ==  (byte)(TestData_LHS[i].x2  << TestData_int32[j]) &
                              x.x3 ==  (byte)(TestData_LHS[i].x3  << TestData_int32[j]) &
                              x.x4 ==  (byte)(TestData_LHS[i].x4  << TestData_int32[j]) &
                              x.x5 ==  (byte)(TestData_LHS[i].x5  << TestData_int32[j]) &
                              x.x6 ==  (byte)(TestData_LHS[i].x6  << TestData_int32[j]) &
                              x.x7 ==  (byte)(TestData_LHS[i].x7  << TestData_int32[j]) &
                              x.x8 ==  (byte)(TestData_LHS[i].x8  << TestData_int32[j]) &
                              x.x9 ==  (byte)(TestData_LHS[i].x9  << TestData_int32[j]) &
                              x.x10 == (byte)(TestData_LHS[i].x10 << TestData_int32[j]) &
                              x.x11 == (byte)(TestData_LHS[i].x11 << TestData_int32[j]) &
                              x.x12 == (byte)(TestData_LHS[i].x12 << TestData_int32[j]) &
                              x.x13 == (byte)(TestData_LHS[i].x13 << TestData_int32[j]) &
                              x.x14 == (byte)(TestData_LHS[i].x14 << TestData_int32[j]) &
                              x.x15 == (byte)(TestData_LHS[i].x15 << TestData_int32[j]) &
                              x.x16 == (byte)(TestData_LHS[i].x16 << TestData_int32[j]) &
                              x.x17 == (byte)(TestData_LHS[i].x17 << TestData_int32[j]) &
                              x.x18 == (byte)(TestData_LHS[i].x18 << TestData_int32[j]) &
                              x.x19 == (byte)(TestData_LHS[i].x19 << TestData_int32[j]) &
                              x.x20 == (byte)(TestData_LHS[i].x20 << TestData_int32[j]) &
                              x.x21 == (byte)(TestData_LHS[i].x21 << TestData_int32[j]) &
                              x.x22 == (byte)(TestData_LHS[i].x22 << TestData_int32[j]) &
                              x.x23 == (byte)(TestData_LHS[i].x23 << TestData_int32[j]) &
                              x.x24 == (byte)(TestData_LHS[i].x24 << TestData_int32[j]) &
                              x.x25 == (byte)(TestData_LHS[i].x25 << TestData_int32[j]) &
                              x.x26 == (byte)(TestData_LHS[i].x26 << TestData_int32[j]) &
                              x.x27 == (byte)(TestData_LHS[i].x27 << TestData_int32[j]) &
                              x.x28 == (byte)(TestData_LHS[i].x28 << TestData_int32[j]) &
                              x.x29 == (byte)(TestData_LHS[i].x29 << TestData_int32[j]) &
                              x.x30 == (byte)(TestData_LHS[i].x30 << TestData_int32[j]) &
                              x.x31 == (byte)(TestData_LHS[i].x31 << TestData_int32[j]);
                }
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    byte32 x = TestData_LHS[i] >> TestData_int32[j];

                    result &= x.x0 ==  (byte)(TestData_LHS[i].x0  >> TestData_int32[j]) & 
                              x.x1 ==  (byte)(TestData_LHS[i].x1  >> TestData_int32[j]) &
                              x.x2 ==  (byte)(TestData_LHS[i].x2  >> TestData_int32[j]) &
                              x.x3 ==  (byte)(TestData_LHS[i].x3  >> TestData_int32[j]) &
                              x.x4 ==  (byte)(TestData_LHS[i].x4  >> TestData_int32[j]) &
                              x.x5 ==  (byte)(TestData_LHS[i].x5  >> TestData_int32[j]) &
                              x.x6 ==  (byte)(TestData_LHS[i].x6  >> TestData_int32[j]) &
                              x.x7 ==  (byte)(TestData_LHS[i].x7  >> TestData_int32[j]) &
                              x.x8 ==  (byte)(TestData_LHS[i].x8  >> TestData_int32[j]) &
                              x.x9 ==  (byte)(TestData_LHS[i].x9  >> TestData_int32[j]) &
                              x.x10 == (byte)(TestData_LHS[i].x10 >> TestData_int32[j]) &
                              x.x11 == (byte)(TestData_LHS[i].x11 >> TestData_int32[j]) &
                              x.x12 == (byte)(TestData_LHS[i].x12 >> TestData_int32[j]) &
                              x.x13 == (byte)(TestData_LHS[i].x13 >> TestData_int32[j]) &
                              x.x14 == (byte)(TestData_LHS[i].x14 >> TestData_int32[j]) &
                              x.x15 == (byte)(TestData_LHS[i].x15 >> TestData_int32[j]) &
                              x.x16 == (byte)(TestData_LHS[i].x16 >> TestData_int32[j]) &
                              x.x17 == (byte)(TestData_LHS[i].x17 >> TestData_int32[j]) &
                              x.x18 == (byte)(TestData_LHS[i].x18 >> TestData_int32[j]) &
                              x.x19 == (byte)(TestData_LHS[i].x19 >> TestData_int32[j]) &
                              x.x20 == (byte)(TestData_LHS[i].x20 >> TestData_int32[j]) &
                              x.x21 == (byte)(TestData_LHS[i].x21 >> TestData_int32[j]) &
                              x.x22 == (byte)(TestData_LHS[i].x22 >> TestData_int32[j]) &
                              x.x23 == (byte)(TestData_LHS[i].x23 >> TestData_int32[j]) &
                              x.x24 == (byte)(TestData_LHS[i].x24 >> TestData_int32[j]) &
                              x.x25 == (byte)(TestData_LHS[i].x25 >> TestData_int32[j]) &
                              x.x26 == (byte)(TestData_LHS[i].x26 >> TestData_int32[j]) &
                              x.x27 == (byte)(TestData_LHS[i].x27 >> TestData_int32[j]) &
                              x.x28 == (byte)(TestData_LHS[i].x28 >> TestData_int32[j]) &
                              x.x29 == (byte)(TestData_LHS[i].x29 >> TestData_int32[j]) &
                              x.x30 == (byte)(TestData_LHS[i].x30 >> TestData_int32[j]) &
                              x.x31 == (byte)(TestData_LHS[i].x31 >> TestData_int32[j]);
                }
            }

            return result;
        }


        [UnitTest("Types", "byte32")]
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

        [UnitTest("Types", "byte32")]
        public static bool LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.x0  == TestData_LHS[i].x0  < TestData_RHS[i].x0;
                result &= x.x1  == TestData_LHS[i].x1  < TestData_RHS[i].x1;
                result &= x.x2  == TestData_LHS[i].x2  < TestData_RHS[i].x2;
                result &= x.x3  == TestData_LHS[i].x3  < TestData_RHS[i].x3;
                result &= x.x4  == TestData_LHS[i].x4  < TestData_RHS[i].x4;
                result &= x.x5  == TestData_LHS[i].x5  < TestData_RHS[i].x5;
                result &= x.x6  == TestData_LHS[i].x6  < TestData_RHS[i].x6;
                result &= x.x7  == TestData_LHS[i].x7  < TestData_RHS[i].x7;
                result &= x.x8  == TestData_LHS[i].x8  < TestData_RHS[i].x8;
                result &= x.x9  == TestData_LHS[i].x9  < TestData_RHS[i].x9;
                result &= x.x10 == TestData_LHS[i].x10 < TestData_RHS[i].x10;
                result &= x.x11 == TestData_LHS[i].x11 < TestData_RHS[i].x11;
                result &= x.x12 == TestData_LHS[i].x12 < TestData_RHS[i].x12;
                result &= x.x13 == TestData_LHS[i].x13 < TestData_RHS[i].x13;
                result &= x.x14 == TestData_LHS[i].x14 < TestData_RHS[i].x14;
                result &= x.x15 == TestData_LHS[i].x15 < TestData_RHS[i].x15;
                result &= x.x16 == TestData_LHS[i].x16 < TestData_RHS[i].x16;
                result &= x.x17 == TestData_LHS[i].x17 < TestData_RHS[i].x17;
                result &= x.x18 == TestData_LHS[i].x18 < TestData_RHS[i].x18;
                result &= x.x19 == TestData_LHS[i].x19 < TestData_RHS[i].x19;
                result &= x.x20 == TestData_LHS[i].x20 < TestData_RHS[i].x20;
                result &= x.x21 == TestData_LHS[i].x21 < TestData_RHS[i].x21;
                result &= x.x22 == TestData_LHS[i].x22 < TestData_RHS[i].x22;
                result &= x.x23 == TestData_LHS[i].x23 < TestData_RHS[i].x23;
                result &= x.x24 == TestData_LHS[i].x24 < TestData_RHS[i].x24;
                result &= x.x25 == TestData_LHS[i].x25 < TestData_RHS[i].x25;
                result &= x.x26 == TestData_LHS[i].x26 < TestData_RHS[i].x26;
                result &= x.x27 == TestData_LHS[i].x27 < TestData_RHS[i].x27;
                result &= x.x28 == TestData_LHS[i].x28 < TestData_RHS[i].x28;
                result &= x.x29 == TestData_LHS[i].x29 < TestData_RHS[i].x29;
                result &= x.x30 == TestData_LHS[i].x30 < TestData_RHS[i].x30;
                result &= x.x31 == TestData_LHS[i].x31 < TestData_RHS[i].x31; 
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
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

        [UnitTest("Types", "byte32")]
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

        [UnitTest("Types", "byte32")]
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

        [UnitTest("Types", "byte32")]
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


        [UnitTest("Types", "byte32")]
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


        [UnitTest("Types", "byte32")]
        public static bool Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte16 v16_0 = TestData_LHS[i].v16_0;
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

                byte16 v16_16 = TestData_LHS[i].v16_16;
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


        [UnitTest("Types", "byte32")]
        public static bool Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v256 x = TestData_LHS[i];

                result &= x.Byte0  == TestData_LHS[i].x0  &
                          x.Byte1  == TestData_LHS[i].x1  &
                          x.Byte2  == TestData_LHS[i].x2  &
                          x.Byte3  == TestData_LHS[i].x3  &
                          x.Byte4  == TestData_LHS[i].x4  &
                          x.Byte5  == TestData_LHS[i].x5  &
                          x.Byte6  == TestData_LHS[i].x6  &
                          x.Byte7  == TestData_LHS[i].x7  &
                          x.Byte8  == TestData_LHS[i].x8  &
                          x.Byte9  == TestData_LHS[i].x9  &
                          x.Byte10 == TestData_LHS[i].x10 &
                          x.Byte11 == TestData_LHS[i].x11 &
                          x.Byte12 == TestData_LHS[i].x12 &
                          x.Byte13 == TestData_LHS[i].x13 &
                          x.Byte14 == TestData_LHS[i].x14 &
                          x.Byte15 == TestData_LHS[i].x15 &
                          x.Byte16 == TestData_LHS[i].x16 &
                          x.Byte17 == TestData_LHS[i].x17 &
                          x.Byte18 == TestData_LHS[i].x18 &
                          x.Byte19 == TestData_LHS[i].x19 &
                          x.Byte20 == TestData_LHS[i].x20 &
                          x.Byte21 == TestData_LHS[i].x21 &
                          x.Byte22 == TestData_LHS[i].x22 &
                          x.Byte23 == TestData_LHS[i].x23 &
                          x.Byte24 == TestData_LHS[i].x24 &
                          x.Byte25 == TestData_LHS[i].x25 &
                          x.Byte26 == TestData_LHS[i].x26 &
                          x.Byte27 == TestData_LHS[i].x27 &
                          x.Byte28 == TestData_LHS[i].x28 &
                          x.Byte29 == TestData_LHS[i].x29 &
                          x.Byte30 == TestData_LHS[i].x30 &
                          x.Byte31 == TestData_LHS[i].x31;
            }

            return result;
        }

        [UnitTest("Types", "byte32")]
        public static bool Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 x = TestData_LHS[i];
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