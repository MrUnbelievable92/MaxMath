using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class Short8
    {
        internal const int NUM_TESTS = 4;


        internal static short8[] TestData_LHS => new short8[]
        {
            new short8(-18300, 55, -9639, 763, -5097, 11, 2131, -3825),
            new short8(212, 18892, -16, 2311, 99, -5680, 549, -9432),      // EQUAL
            new short8(87, short.MaxValue, 17, 1747, 0, 4127, 392, 21156),
            new short8(short.MinValue, -1563, 11221, -1446, 1979, -399, 2502, 121)
        };

        internal static short8[] TestData_RHS => new short8[]
        {
            new short8(12, -8, 5383, 98, -4242, -17996, 970, 44),
            new short8(212, 18892, -16, 2311, 99, -5680, 549, -9432),      // EQUAL
            new short8(17955, -827, -9643, 18862, 239, -435, -9750, -162),
            new short8(2, -963, 20540, 19242, 8967, -26789, -1862, 43)
        };

        internal static int[] TestData_int32 => new int[]
        {
            15,
            9,
            6,
            0
        };


        [UnitTest("Types", "short8")]
        public static bool Constructor_Short_Short_Short_Short_Short_Short_Short_Short()
        {
            short8 x = new short8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short()
        {
            short8 x = new short8(TestData_LHS[0].x0);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x0 &
                   x.x2 == TestData_LHS[0].x0 &
                   x.x3 == TestData_LHS[0].x0 &
                   x.x4 == TestData_LHS[0].x0 &
                   x.x5 == TestData_LHS[0].x0 &
                   x.x6 == TestData_LHS[0].x0 &
                   x.x7 == TestData_LHS[0].x0;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short2_Short2_Short2_Short2()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short2(TestData_LHS[0].x2, TestData_LHS[0].x3), new short2(TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short2_Short3_Short3()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new short3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short3_Short2_Short3()
        {
            short8 x = new short8(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short2(TestData_LHS[0].x3, TestData_LHS[0].x4), new short3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short3_Short3_Short2()
        {
            short8 x = new short8(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short4_Short2_Short2()
        {
            short8 x = new short8(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short2(TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short2_Short4_Short2()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short2_Short2_Short4()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short2(TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "short8")]
        public static bool Constructor_Short4_Short4()
        {
            short8 x = new short8(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }


        [UnitTest("Types", "short8")]
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


        [UnitTest("Types", "short8")]
        public static bool Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 + TestData_RHS[i].x0) & 
                          x.x1 == (short)(TestData_LHS[i].x1 + TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 + TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 + TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 + TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 + TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 + TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 + TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 - TestData_RHS[i].x0) &
                          x.x1 == (short)(TestData_LHS[i].x1 - TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 - TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 - TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 - TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 - TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 - TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 - TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 * TestData_RHS[i].x0) &
                          x.x1 == (short)(TestData_LHS[i].x1 * TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 * TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 * TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 * TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 * TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 * TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 * TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 / TestData_RHS[i].x0) &
                          x.x1 == (short)(TestData_LHS[i].x1 / TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 / TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 / TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 / TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 / TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 / TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 / TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 % TestData_RHS[i].x0) &
                          x.x1 == (short)(TestData_LHS[i].x1 % TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 % TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 % TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 % TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 % TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 % TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 % TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = -TestData_LHS[i];

                result &= x.x0 == (short)(-TestData_LHS[i].x0) &
                          x.x1 == (short)(-TestData_LHS[i].x1) &
                          x.x2 == (short)(-TestData_LHS[i].x2) &
                          x.x3 == (short)(-TestData_LHS[i].x3) &
                          x.x4 == (short)(-TestData_LHS[i].x4) &
                          x.x5 == (short)(-TestData_LHS[i].x5) &
                          x.x6 == (short)(-TestData_LHS[i].x6) &
                          x.x7 == (short)(-TestData_LHS[i].x7);
            }

            return result;
        }


        [UnitTest("Types", "short8")]
        public static bool AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 & TestData_RHS[i].x0) &
                          x.x1 == (short)(TestData_LHS[i].x1 & TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 & TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 & TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 & TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 & TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 & TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 & TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 | TestData_RHS[i].x0) &
                          x.x1 == (short)(TestData_LHS[i].x1 | TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 | TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 | TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 | TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 | TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 | TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 | TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 == (short)(TestData_LHS[i].x0 ^ TestData_RHS[i].x0) &
                          x.x1 == (short)(TestData_LHS[i].x1 ^ TestData_RHS[i].x1) &
                          x.x2 == (short)(TestData_LHS[i].x2 ^ TestData_RHS[i].x2) &
                          x.x3 == (short)(TestData_LHS[i].x3 ^ TestData_RHS[i].x3) &
                          x.x4 == (short)(TestData_LHS[i].x4 ^ TestData_RHS[i].x4) &
                          x.x5 == (short)(TestData_LHS[i].x5 ^ TestData_RHS[i].x5) &
                          x.x6 == (short)(TestData_LHS[i].x6 ^ TestData_RHS[i].x6) &
                          x.x7 == (short)(TestData_LHS[i].x7 ^ TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = ~TestData_LHS[i];

                result &= x.x0 == (short)(~TestData_LHS[i].x0) &
                          x.x1 == (short)(~TestData_LHS[i].x1) &
                          x.x2 == (short)(~TestData_LHS[i].x2) &
                          x.x3 == (short)(~TestData_LHS[i].x3) &
                          x.x4 == (short)(~TestData_LHS[i].x4) &
                          x.x5 == (short)(~TestData_LHS[i].x5) &
                          x.x6 == (short)(~TestData_LHS[i].x6) &
                          x.x7 == (short)(~TestData_LHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    short8 x = TestData_LHS[i] << TestData_int32[j];

                    result &= x.x0 == (short)(TestData_LHS[i].x0 << TestData_int32[j]) & 
                              x.x1 == (short)(TestData_LHS[i].x1 << TestData_int32[j]) &
                              x.x2 == (short)(TestData_LHS[i].x2 << TestData_int32[j]) &
                              x.x3 == (short)(TestData_LHS[i].x3 << TestData_int32[j]) &
                              x.x4 == (short)(TestData_LHS[i].x4 << TestData_int32[j]) &
                              x.x5 == (short)(TestData_LHS[i].x5 << TestData_int32[j]) &
                              x.x6 == (short)(TestData_LHS[i].x6 << TestData_int32[j]) &
                              x.x7 == (short)(TestData_LHS[i].x7 << TestData_int32[j]);
                }
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    short8 x = TestData_LHS[i] >> TestData_int32[j];

                    result &= x.x0 == (short)(TestData_LHS[i].x0 >> TestData_int32[j]) &
                              x.x1 == (short)(TestData_LHS[i].x1 >> TestData_int32[j]) &
                              x.x2 == (short)(TestData_LHS[i].x2 >> TestData_int32[j]) &
                              x.x3 == (short)(TestData_LHS[i].x3 >> TestData_int32[j]) &
                              x.x4 == (short)(TestData_LHS[i].x4 >> TestData_int32[j]) &
                              x.x5 == (short)(TestData_LHS[i].x5 >> TestData_int32[j]) &
                              x.x6 == (short)(TestData_LHS[i].x6 >> TestData_int32[j]) &
                              x.x7 == (short)(TestData_LHS[i].x7 >> TestData_int32[j]);
                }
            }

            return result;
        }


        [UnitTest("Types", "short8")]
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

        [UnitTest("Types", "short8")]
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

        [UnitTest("Types", "short8")]
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

        [UnitTest("Types", "short8")]
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

        [UnitTest("Types", "short8")]
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

        [UnitTest("Types", "short8")]
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


        [UnitTest("Types", "short8")]
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


        [UnitTest("Types", "short8")]
        public static bool Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                short4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                short4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                short4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                short4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;


                short3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                short3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                short3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                short3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                short3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                short3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;


                short2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                short2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                short2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                short2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                short2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                short2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                short2 v2_6 = TestData_LHS[i].v2_6;
                result &= v2_6.x == TestData_LHS[i].x6 &
                          v2_6.y == TestData_LHS[i].x7;
            }


            return result;
        }


        [UnitTest("Types", "short8")]
        public static bool Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v128 x = TestData_LHS[i];

                result &= x.SShort0 == TestData_LHS[i].x0 &
                          x.SShort1 == TestData_LHS[i].x1 &
                          x.SShort2 == TestData_LHS[i].x2 &
                          x.SShort3 == TestData_LHS[i].x3 &
                          x.SShort4 == TestData_LHS[i].x4 &
                          x.SShort5 == TestData_LHS[i].x5 &
                          x.SShort6 == TestData_LHS[i].x6 &
                          x.SShort7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = TestData_LHS[i];
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


        [UnitTest("Types", "short8")]
        public static bool Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 x = (byte8)TestData_LHS[i];

                result &= x.x0 == (byte)TestData_LHS[i].x0 &
                          x.x1 == (byte)TestData_LHS[i].x1 &
                          x.x2 == (byte)TestData_LHS[i].x2 &
                          x.x3 == (byte)TestData_LHS[i].x3 &
                          x.x4 == (byte)TestData_LHS[i].x4 &
                          x.x5 == (byte)TestData_LHS[i].x5 &
                          x.x6 == (byte)TestData_LHS[i].x6 &
                          x.x7 == (byte)TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "short8")]
        public static bool Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = (sbyte8)TestData_LHS[i];

                result &= x.x0 == (sbyte)TestData_LHS[i].x0 &
                          x.x1 == (sbyte)TestData_LHS[i].x1 &
                          x.x2 == (sbyte)TestData_LHS[i].x2 &
                          x.x3 == (sbyte)TestData_LHS[i].x3 &
                          x.x4 == (sbyte)TestData_LHS[i].x4 &
                          x.x5 == (sbyte)TestData_LHS[i].x5 &
                          x.x6 == (sbyte)TestData_LHS[i].x6 &
                          x.x7 == (sbyte)TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "short8")]
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

        [UnitTest("Types", "short8")]
        public static bool Cast_ToUInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = (uint8)TestData_LHS[i];

                result &= x.x0 == (uint)TestData_LHS[i].x0 &
                          x.x1 == (uint)TestData_LHS[i].x1 &
                          x.x2 == (uint)TestData_LHS[i].x2 &
                          x.x3 == (uint)TestData_LHS[i].x3 &
                          x.x4 == (uint)TestData_LHS[i].x4 &
                          x.x5 == (uint)TestData_LHS[i].x5 &
                          x.x6 == (uint)TestData_LHS[i].x6 &
                          x.x7 == (uint)TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "short8")]
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