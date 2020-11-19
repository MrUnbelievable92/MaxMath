using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class UInt8
    {
        internal const int NUM_TESTS = 4;


        internal static uint8[] TestData_LHS => new uint8[]
        {
            new uint8(1837300, 55, 963259, 7633, 65089297, 134901, 21333671, 38233895),
            new uint8(21722562, 188932, 153566, 23188221, 99599999, 56822210, 54779, 39432),      // EQUAL
            new uint8(85897, uint.MaxValue, 1217, 1747, 0, 418432327, 3996422, 21466156),
            new uint8(uint.MinValue, 1563, 11221, 61445216, 131687979, 399, 63382502, 2565771)
        };

        internal static uint8[] TestData_RHS => new uint8[]
        {
            new uint8(12, 832987, 5387343, 98, 42425642, 1798496, 978540, 4853234),
            new uint8(21722562, 188932, 153566, 23188221, 99599999, 56822210, 54779, 39432),      // EQUAL
            new uint8(173899955, 874227, 964553, 18867862, 266339, 43552, 979950, 13262),
            new uint8(24787, 963, 2056740, 192472, 8967, 264288789, 185262, 45683)
        };

        internal static int[] TestData_int32 => new int[]
        {
            31,
            17,
            6,
            0
        };


        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt_UInt_UInt_UInt_UInt_UInt_UInt_UInt()
        {
            uint8 x = new uint8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt()
        {
            uint8 x = new uint8(TestData_LHS[0].x0);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x0 &
                   x.x2 == TestData_LHS[0].x0 &
                   x.x3 == TestData_LHS[0].x0 &
                   x.x4 == TestData_LHS[0].x0 &
                   x.x5 == TestData_LHS[0].x0 &
                   x.x6 == TestData_LHS[0].x0 &
                   x.x7 == TestData_LHS[0].x0;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt2_UInt2_UInt2_UInt2()
        {
            uint8 x = new uint8(new uint2(TestData_LHS[0].x0, TestData_LHS[0].x1), new uint2(TestData_LHS[0].x2, TestData_LHS[0].x3), new uint2(TestData_LHS[0].x4, TestData_LHS[0].x5), new uint2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt2_UInt3_UInt3()
        {
            uint8 x = new uint8(new uint2(TestData_LHS[0].x0, TestData_LHS[0].x1), new uint3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new uint3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt3_UInt2_UInt3()
        {
            uint8 x = new uint8(new uint3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new uint2(TestData_LHS[0].x3, TestData_LHS[0].x4), new uint3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt3_UInt3_UInt2()
        {
            uint8 x = new uint8(new uint3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new uint3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new uint2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt4_UInt2_UInt2()
        {
            uint8 x = new uint8(new uint4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new uint2(TestData_LHS[0].x4, TestData_LHS[0].x5), new uint2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt2_UInt4_UInt2()
        {
            uint8 x = new uint8(new uint2(TestData_LHS[0].x0, TestData_LHS[0].x1), new uint4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new uint2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt2_UInt2_UInt4()
        {
            uint8 x = new uint8(new uint2(TestData_LHS[0].x0, TestData_LHS[0].x1), new uint2(TestData_LHS[0].x2, TestData_LHS[0].x3), new uint4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "uint8")]
        public static bool Constructor_UInt4_UInt4()
        {
            uint8 x = new uint8(new uint4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new uint4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }


        [UnitTest("Types", "uint8")]
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


        [UnitTest("Types", "uint8")]
        public static bool Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 + TestData_RHS[i].x0) & 
                          x.x1 == (uint)(TestData_LHS[i].x1 + TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 + TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 + TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 + TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 + TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 + TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 + TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 - TestData_RHS[i].x0) &
                          x.x1 == (uint)(TestData_LHS[i].x1 - TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 - TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 - TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 - TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 - TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 - TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 - TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 * TestData_RHS[i].x0) &
                          x.x1 == (uint)(TestData_LHS[i].x1 * TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 * TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 * TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 * TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 * TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 * TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 * TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 / TestData_RHS[i].x0) &
                          x.x1 == (uint)(TestData_LHS[i].x1 / TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 / TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 / TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 / TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 / TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 / TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 / TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 % TestData_RHS[i].x0) &
                          x.x1 == (uint)(TestData_LHS[i].x1 % TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 % TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 % TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 % TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 % TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 % TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 % TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 & TestData_RHS[i].x0) &
                          x.x1 == (uint)(TestData_LHS[i].x1 & TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 & TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 & TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 & TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 & TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 & TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 & TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 | TestData_RHS[i].x0) &
                          x.x1 == (uint)(TestData_LHS[i].x1 | TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 | TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 | TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 | TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 | TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 | TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 | TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 == (uint)(TestData_LHS[i].x0 ^ TestData_RHS[i].x0) &
                          x.x1 == (uint)(TestData_LHS[i].x1 ^ TestData_RHS[i].x1) &
                          x.x2 == (uint)(TestData_LHS[i].x2 ^ TestData_RHS[i].x2) &
                          x.x3 == (uint)(TestData_LHS[i].x3 ^ TestData_RHS[i].x3) &
                          x.x4 == (uint)(TestData_LHS[i].x4 ^ TestData_RHS[i].x4) &
                          x.x5 == (uint)(TestData_LHS[i].x5 ^ TestData_RHS[i].x5) &
                          x.x6 == (uint)(TestData_LHS[i].x6 ^ TestData_RHS[i].x6) &
                          x.x7 == (uint)(TestData_LHS[i].x7 ^ TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = ~TestData_LHS[i];

                result &= x.x0 == (uint)(~TestData_LHS[i].x0) &
                          x.x1 == (uint)(~TestData_LHS[i].x1) &
                          x.x2 == (uint)(~TestData_LHS[i].x2) &
                          x.x3 == (uint)(~TestData_LHS[i].x3) &
                          x.x4 == (uint)(~TestData_LHS[i].x4) &
                          x.x5 == (uint)(~TestData_LHS[i].x5) &
                          x.x6 == (uint)(~TestData_LHS[i].x6) &
                          x.x7 == (uint)(~TestData_LHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    uint8 x = TestData_LHS[i] << TestData_int32[j];

                    result &= x.x0 == (uint)(TestData_LHS[i].x0 << TestData_int32[j]) & 
                              x.x1 == (uint)(TestData_LHS[i].x1 << TestData_int32[j]) &
                              x.x2 == (uint)(TestData_LHS[i].x2 << TestData_int32[j]) &
                              x.x3 == (uint)(TestData_LHS[i].x3 << TestData_int32[j]) &
                              x.x4 == (uint)(TestData_LHS[i].x4 << TestData_int32[j]) &
                              x.x5 == (uint)(TestData_LHS[i].x5 << TestData_int32[j]) &
                              x.x6 == (uint)(TestData_LHS[i].x6 << TestData_int32[j]) &
                              x.x7 == (uint)(TestData_LHS[i].x7 << TestData_int32[j]);
                }
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    uint8 x = TestData_LHS[i] >> TestData_int32[j];

                    result &= x.x0 == (uint)(TestData_LHS[i].x0 >> TestData_int32[j]) &
                              x.x1 == (uint)(TestData_LHS[i].x1 >> TestData_int32[j]) &
                              x.x2 == (uint)(TestData_LHS[i].x2 >> TestData_int32[j]) &
                              x.x3 == (uint)(TestData_LHS[i].x3 >> TestData_int32[j]) &
                              x.x4 == (uint)(TestData_LHS[i].x4 >> TestData_int32[j]) &
                              x.x5 == (uint)(TestData_LHS[i].x5 >> TestData_int32[j]) &
                              x.x6 == (uint)(TestData_LHS[i].x6 >> TestData_int32[j]) &
                              x.x7 == (uint)(TestData_LHS[i].x7 >> TestData_int32[j]);
                }
            }

            return result;
        }


        [UnitTest("Types", "uint8")]
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

        [UnitTest("Types", "uint8")]
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

        [UnitTest("Types", "uint8")]
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

        [UnitTest("Types", "uint8")]
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

        [UnitTest("Types", "uint8")]
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

        [UnitTest("Types", "uint8")]
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


        [UnitTest("Types", "uint8")]
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


        [UnitTest("Types", "uint8")]
        public static bool Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                uint4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                uint4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                uint4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                uint4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;


                uint3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                uint3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                uint3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                uint3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                uint3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                uint3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;


                uint2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                uint2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                uint2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                uint2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                uint2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                uint2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                uint2 v2_6 = TestData_LHS[i].v2_6;
                result &= v2_6.x == TestData_LHS[i].x6 &
                          v2_6.y == TestData_LHS[i].x7;
            }


            return result;
        }


        [UnitTest("Types", "uint8")]
        public static bool Cast_ToV256()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v256 x = TestData_LHS[i];

                result &= x.UInt0 == TestData_LHS[i].x0 &
                          x.UInt1 == TestData_LHS[i].x1 &
                          x.UInt2 == TestData_LHS[i].x2 &
                          x.UInt3 == TestData_LHS[i].x3 &
                          x.UInt4 == TestData_LHS[i].x4 &
                          x.UInt5 == TestData_LHS[i].x5 &
                          x.UInt6 == TestData_LHS[i].x6 &
                          x.UInt7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool Cast_FromV256()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 x = TestData_LHS[i];
                v256 c = x;
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


        [UnitTest("Types", "uint8")]
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

        [UnitTest("Types", "uint8")]
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

        [UnitTest("Types", "uint8")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = (short8)TestData_LHS[i];

                result &= x.x0 == (short)TestData_LHS[i].x0 &
                          x.x1 == (short)TestData_LHS[i].x1 &
                          x.x2 == (short)TestData_LHS[i].x2 &
                          x.x3 == (short)TestData_LHS[i].x3 &
                          x.x4 == (short)TestData_LHS[i].x4 &
                          x.x5 == (short)TestData_LHS[i].x5 &
                          x.x6 == (short)TestData_LHS[i].x6 &
                          x.x7 == (short)TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort8 x = (ushort8)TestData_LHS[i];

                result &= x.x0 == (ushort)TestData_LHS[i].x0 &
                          x.x1 == (ushort)TestData_LHS[i].x1 &
                          x.x2 == (ushort)TestData_LHS[i].x2 &
                          x.x3 == (ushort)TestData_LHS[i].x3 &
                          x.x4 == (ushort)TestData_LHS[i].x4 &
                          x.x5 == (ushort)TestData_LHS[i].x5 &
                          x.x6 == (ushort)TestData_LHS[i].x6 &
                          x.x7 == (ushort)TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "uint8")]
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