using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class Byte8
    {
        internal const int NUM_TESTS = 4;


        internal static byte8[] TestData_LHS => new byte8[]
        {
            new byte8(183, 55, 99, 76, 65, 1, 211, 35),
            new byte8(22, 12, 16, 211, 99, 80, 54, 39),      // EQUAL
            new byte8(87, byte.MaxValue, 17, 21, 0, 47, 32, 156),
            new byte8(byte.MinValue, 13, 111, 66, 199, 39, 250, 121)
        };

        internal static byte8[] TestData_RHS => new byte8[]
        {
            new byte8(12, 8, 53, 98, 2, 173, 97, 44),
            new byte8(22, 12, 16, 211, 99, 80, 54, 39),      // EQUAL
            new byte8(17, 87, 9, 182, 239, 45, 90, 162),
            new byte8(2, 9, 200, 192, 87, 219, 182, 43)
        };

        internal static int[] TestData_int32 => new int[]
        {
            7,
            3,
            2,
            0
        };


        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte()
        {
            byte8 x = new byte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte()
        {
            byte8 x = new byte8(TestData_LHS[0].x0);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x0 &
                   x.x2 == TestData_LHS[0].x0 &
                   x.x3 == TestData_LHS[0].x0 &
                   x.x4 == TestData_LHS[0].x0 &
                   x.x5 == TestData_LHS[0].x0 &
                   x.x6 == TestData_LHS[0].x0 &
                   x.x7 == TestData_LHS[0].x0;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte2_Byte2_Byte2_Byte2()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte2(TestData_LHS[0].x2, TestData_LHS[0].x3), new byte2(TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte2_Byte3_Byte3()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new byte3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte3_Byte2_Byte3()
        {
            byte8 x = new byte8(new byte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new byte2(TestData_LHS[0].x3, TestData_LHS[0].x4), new byte3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte3_Byte3_Byte2()
        {
            byte8 x = new byte8(new byte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new byte3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte4_Byte2_Byte2()
        {
            byte8 x = new byte8(new byte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new byte2(TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte2_Byte4_Byte2()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte2_Byte2_Byte4()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte2(TestData_LHS[0].x2, TestData_LHS[0].x3), new byte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "byte8")]
        public static bool Constructor_Byte4_Byte4()
        {
            byte8 x = new byte8(new byte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new byte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }


        [UnitTest("Types", "byte8")]
        public static bool Indexer()
        {
            return TestData_LHS[0][0] == TestData_LHS[0].x0 &
                   TestData_LHS[0][1] == TestData_LHS[0].x1 &
                   TestData_LHS[0][2] == TestData_LHS[0].x2 &
                   TestData_LHS[0][3] == TestData_LHS[0].x3 &
                   TestData_LHS[0][4] == TestData_LHS[0].x4 &
                   TestData_LHS[0][5] == TestData_LHS[0].x5 &
                   TestData_LHS[0][6] == TestData_LHS[0].x6 &
                   TestData_LHS[0][7] == TestData_LHS[0].x7;
        }


        [UnitTest("Types", "byte8")]
        public static bool Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 + TestData_RHS[i].x0) & 
                          x.x1 == (byte)(TestData_LHS[i].x1 + TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 + TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 + TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 + TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 + TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 + TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 + TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 - TestData_RHS[i].x0) &
                          x.x1 == (byte)(TestData_LHS[i].x1 - TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 - TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 - TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 - TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 - TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 - TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 - TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 * TestData_RHS[i].x0) &
                          x.x1 == (byte)(TestData_LHS[i].x1 * TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 * TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 * TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 * TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 * TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 * TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 * TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 / TestData_RHS[i].x0) &
                          x.x1 == (byte)(TestData_LHS[i].x1 / TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 / TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 / TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 / TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 / TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 / TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 / TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 % TestData_RHS[i].x0) &
                          x.x1 == (byte)(TestData_LHS[i].x1 % TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 % TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 % TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 % TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 % TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 % TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 % TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 & TestData_RHS[i].x0) &
                          x.x1 == (byte)(TestData_LHS[i].x1 & TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 & TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 & TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 & TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 & TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 & TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 & TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 | TestData_RHS[i].x0) &
                          x.x1 == (byte)(TestData_LHS[i].x1 | TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 | TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 | TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 | TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 | TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 | TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 | TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 == (byte)(TestData_LHS[i].x0 ^ TestData_RHS[i].x0) &
                          x.x1 == (byte)(TestData_LHS[i].x1 ^ TestData_RHS[i].x1) &
                          x.x2 == (byte)(TestData_LHS[i].x2 ^ TestData_RHS[i].x2) &
                          x.x3 == (byte)(TestData_LHS[i].x3 ^ TestData_RHS[i].x3) &
                          x.x4 == (byte)(TestData_LHS[i].x4 ^ TestData_RHS[i].x4) &
                          x.x5 == (byte)(TestData_LHS[i].x5 ^ TestData_RHS[i].x5) &
                          x.x6 == (byte)(TestData_LHS[i].x6 ^ TestData_RHS[i].x6) &
                          x.x7 == (byte)(TestData_LHS[i].x7 ^ TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = ~TestData_LHS[i];

                result &= x.x0 == (byte)(~TestData_LHS[i].x0) &
                          x.x1 == (byte)(~TestData_LHS[i].x1) &
                          x.x2 == (byte)(~TestData_LHS[i].x2) &
                          x.x3 == (byte)(~TestData_LHS[i].x3) &
                          x.x4 == (byte)(~TestData_LHS[i].x4) &
                          x.x5 == (byte)(~TestData_LHS[i].x5) &
                          x.x6 == (byte)(~TestData_LHS[i].x6) &
                          x.x7 == (byte)(~TestData_LHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    byte8 x = TestData_LHS[i] << TestData_int32[j];

                    result &= x.x0 == (byte)(TestData_LHS[i].x0 << TestData_int32[j]) & 
                              x.x1 == (byte)(TestData_LHS[i].x1 << TestData_int32[j]) &
                              x.x2 == (byte)(TestData_LHS[i].x2 << TestData_int32[j]) &
                              x.x3 == (byte)(TestData_LHS[i].x3 << TestData_int32[j]) &
                              x.x4 == (byte)(TestData_LHS[i].x4 << TestData_int32[j]) &
                              x.x5 == (byte)(TestData_LHS[i].x5 << TestData_int32[j]) &
                              x.x6 == (byte)(TestData_LHS[i].x6 << TestData_int32[j]) &
                              x.x7 == (byte)(TestData_LHS[i].x7 << TestData_int32[j]);
                }
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    byte8 x = TestData_LHS[i] >> TestData_int32[j];

                    result &= x.x0 == (byte)(TestData_LHS[i].x0 >> TestData_int32[j]) &
                              x.x1 == (byte)(TestData_LHS[i].x1 >> TestData_int32[j]) &
                              x.x2 == (byte)(TestData_LHS[i].x2 >> TestData_int32[j]) &
                              x.x3 == (byte)(TestData_LHS[i].x3 >> TestData_int32[j]) &
                              x.x4 == (byte)(TestData_LHS[i].x4 >> TestData_int32[j]) &
                              x.x5 == (byte)(TestData_LHS[i].x5 >> TestData_int32[j]) &
                              x.x6 == (byte)(TestData_LHS[i].x6 >> TestData_int32[j]) &
                              x.x7 == (byte)(TestData_LHS[i].x7 >> TestData_int32[j]);
                }
            }

            return result;
        }


        [UnitTest("Types", "byte8")]
        public static bool Equal()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x2 x = TestData_LHS[i] == TestData_RHS[i];

                result &= x.Equals(new bool4x2(new bool4(TestData_LHS[i].x0 == TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 == TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 == TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 == TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 == TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 == TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 == TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 == TestData_RHS[i].x7)));
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x2 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.Equals(new bool4x2(new bool4(TestData_LHS[i].x0 < TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 < TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 < TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 < TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 < TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 < TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 < TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 < TestData_RHS[i].x7)));
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool GreaterThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x2 x = TestData_LHS[i] > TestData_RHS[i];

                result &= x.Equals(new bool4x2(new bool4(TestData_LHS[i].x0 > TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 > TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 > TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 > TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 > TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 > TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 > TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 > TestData_RHS[i].x7)));
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool NotEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x2 x = TestData_LHS[i] != TestData_RHS[i];

                result &= x.Equals(new bool4x2(new bool4(TestData_LHS[i].x0 != TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 != TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 != TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 != TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 != TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 != TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 != TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 != TestData_RHS[i].x7)));
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool LessThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x2 x = TestData_LHS[i] <= TestData_RHS[i];

                result &= x.Equals(new bool4x2(new bool4(TestData_LHS[i].x0 <= TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 <= TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 <= TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 <= TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 <= TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 <= TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 <= TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 <= TestData_RHS[i].x7)));
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool GreaterThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x2 x = TestData_LHS[i] >= TestData_RHS[i];

                result &= x.Equals(new bool4x2(new bool4(TestData_LHS[i].x0 >= TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 >= TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 >= TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 >= TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 >= TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 >= TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 >= TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 >= TestData_RHS[i].x7)));
            }

            return result;
        }


        [UnitTest("Types", "byte8")]
        public static bool AllEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool x = TestData_LHS[i].Equals(TestData_RHS[i]);

                result &= x == (TestData_LHS[i].x0 == TestData_RHS[i].x0 &
                                TestData_LHS[i].x1 == TestData_RHS[i].x1 &
                                TestData_LHS[i].x2 == TestData_RHS[i].x2 &
                                TestData_LHS[i].x3 == TestData_RHS[i].x3 &
                                TestData_LHS[i].x4 == TestData_RHS[i].x4 &
                                TestData_LHS[i].x5 == TestData_RHS[i].x5 &
                                TestData_LHS[i].x6 == TestData_RHS[i].x6 &
                                TestData_LHS[i].x7 == TestData_RHS[i].x7);
            }

            return result;
        }


        [UnitTest("Types", "byte8")]
        public static bool Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                byte4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                byte4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                byte4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                byte4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;


                byte3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                byte3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                byte3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                byte3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                byte3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                byte3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;


                byte2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                byte2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                byte2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                byte2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                byte2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                byte2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                byte2 v2_6 = TestData_LHS[i].v2_6;
                result &= v2_6.x == TestData_LHS[i].x6 &
                          v2_6.y == TestData_LHS[i].x7;
            }


            return result;
        }


        [UnitTest("Types", "byte8")]
        public static bool Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v128 x = TestData_LHS[i];

                result &= x.Byte0 == TestData_LHS[i].x0 &
                          x.Byte1 == TestData_LHS[i].x1 &
                          x.Byte2 == TestData_LHS[i].x2 &
                          x.Byte3 == TestData_LHS[i].x3 &
                          x.Byte4 == TestData_LHS[i].x4 &
                          x.Byte5 == TestData_LHS[i].x5 &
                          x.Byte6 == TestData_LHS[i].x6 &
                          x.Byte7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = TestData_LHS[i];
                v128 c = x;
                x = c;

                result &= x.x0 == TestData_LHS[i].x0 &
                          x.x1 == TestData_LHS[i].x1 &
                          x.x2 == TestData_LHS[i].x2 &
                          x.x3 == TestData_LHS[i].x3 &
                          x.x4 == TestData_LHS[i].x4 &
                          x.x5 == TestData_LHS[i].x5 &
                          x.x6 == TestData_LHS[i].x6 &
                          x.x7 == TestData_LHS[i].x7;
            }

            return result;
        }


        [UnitTest("Types", "byte8")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i];

                result &= x.x0 == TestData_LHS[i].x0 &
                          x.x1 == TestData_LHS[i].x1 &
                          x.x2 == TestData_LHS[i].x2 &
                          x.x3 == TestData_LHS[i].x3 &
                          x.x4 == TestData_LHS[i].x4 &
                          x.x5 == TestData_LHS[i].x5 &
                          x.x6 == TestData_LHS[i].x6 &
                          x.x7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort8 x = TestData_LHS[i];

                result &= x.x0 == TestData_LHS[i].x0 &
                          x.x1 == TestData_LHS[i].x1 &
                          x.x2 == TestData_LHS[i].x2 &
                          x.x3 == TestData_LHS[i].x3 &
                          x.x4 == TestData_LHS[i].x4 &
                          x.x5 == TestData_LHS[i].x5 &
                          x.x6 == TestData_LHS[i].x6 &
                          x.x7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Cast_ToInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i];

                result &= x.x0 == TestData_LHS[i].x0 &
                          x.x1 == TestData_LHS[i].x1 &
                          x.x2 == TestData_LHS[i].x2 &
                          x.x3 == TestData_LHS[i].x3 &
                          x.x4 == TestData_LHS[i].x4 &
                          x.x5 == TestData_LHS[i].x5 &
                          x.x6 == TestData_LHS[i].x6 &
                          x.x7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Cast_ToUInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i];

                result &= x.x0 == TestData_LHS[i].x0 &
                          x.x1 == TestData_LHS[i].x1 &
                          x.x2 == TestData_LHS[i].x2 &
                          x.x3 == TestData_LHS[i].x3 &
                          x.x4 == TestData_LHS[i].x4 &
                          x.x5 == TestData_LHS[i].x5 &
                          x.x6 == TestData_LHS[i].x6 &
                          x.x7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "byte8")]
        public static bool Cast_ToFloat()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = TestData_LHS[i];

                result &= maxmath.approx(x.x0, (float)TestData_LHS[i].x0) &
                          maxmath.approx(x.x1, (float)TestData_LHS[i].x1) &
                          maxmath.approx(x.x2, (float)TestData_LHS[i].x2) &
                          maxmath.approx(x.x3, (float)TestData_LHS[i].x3) &
                          maxmath.approx(x.x4, (float)TestData_LHS[i].x4) &
                          maxmath.approx(x.x5, (float)TestData_LHS[i].x5) &
                          maxmath.approx(x.x6, (float)TestData_LHS[i].x6) &
                          maxmath.approx(x.x7, (float)TestData_LHS[i].x7);
            }

            return result;
        }
    }
#endif
}