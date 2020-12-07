﻿using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class Float8
    {
        internal const int NUM_TESTS = 4;


        internal static float8[] TestData_LHS => new float8[]
        {
            new float8(1837.300f, 55, 963259, -7633, -65089.297f, 134901, -21333.671f, 38233895),
            new float8(21722562, -1889.32f, 153566, -2318.8221f, -99599999, -5682.2210f, 547.79f, 394.32f),      // EQUAL
            new float8(85897, float.MaxValue, 1217, -1747, 0, 4184.32327f, -39964.22f, 21466156),
            new float8(float.MinValue, 1563, -11221, -61445216, 1316879.79f, -399, 63382.502f, -2565771)
        };

        internal static float8[] TestData_RHS => new float8[]
        {
            new float8(12, 83.2987f, 53873.43f, 98, 42425642, -1798.496f, 978540, -48532.34f),
            new float8(21722562, -1889.32f, 153566, -2318.8221f, -99599999, -5682.2210f, 547.79f, 394.32f),      // EQUAL
            new float8(173899.955f, 874227, -964553, 18.867862f, 266339, -43552, 979950, -13262),
            new float8(24787, -963, 2056.740f, -192472, -8967, 26.4288789f, 1.85262f, 45683)
        };


        [UnitTest("Types", "float8")]
        public static bool Constructor_Float_Float_Float_Float_Float_Float_Float_Float()
        {
            float8 x = new float8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float()
        {
            float8 x = new float8(TestData_LHS[0].x0);

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x0 &
                   x.x2 == TestData_LHS[0].x0 &
                   x.x3 == TestData_LHS[0].x0 &
                   x.x4 == TestData_LHS[0].x0 &
                   x.x5 == TestData_LHS[0].x0 &
                   x.x6 == TestData_LHS[0].x0 &
                   x.x7 == TestData_LHS[0].x0;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float2_Float2_Float2_Float2()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float2(TestData_LHS[0].x2, TestData_LHS[0].x3), new float2(TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float2_Float3_Float3()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new float3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float3_Float2_Float3()
        {
            float8 x = new float8(new float3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new float2(TestData_LHS[0].x3, TestData_LHS[0].x4), new float3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float3_Float3_Float2()
        {
            float8 x = new float8(new float3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new float3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float4_Float2_Float2()
        {
            float8 x = new float8(new float4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new float2(TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float2_Float4_Float2()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float2_Float2_Float4()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float2(TestData_LHS[0].x2, TestData_LHS[0].x3), new float4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }

        [UnitTest("Types", "float8")]
        public static bool Constructor_Float4_Float4()
        {
            float8 x = new float8(new float4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new float4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            return x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7;
        }


        [UnitTest("Types", "float8")]
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


        [UnitTest("Types", "float8")]
        public static bool Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 == (float)(TestData_LHS[i].x0 + TestData_RHS[i].x0) & 
                          x.x1 == (float)(TestData_LHS[i].x1 + TestData_RHS[i].x1) &
                          x.x2 == (float)(TestData_LHS[i].x2 + TestData_RHS[i].x2) &
                          x.x3 == (float)(TestData_LHS[i].x3 + TestData_RHS[i].x3) &
                          x.x4 == (float)(TestData_LHS[i].x4 + TestData_RHS[i].x4) &
                          x.x5 == (float)(TestData_LHS[i].x5 + TestData_RHS[i].x5) &
                          x.x6 == (float)(TestData_LHS[i].x6 + TestData_RHS[i].x6) &
                          x.x7 == (float)(TestData_LHS[i].x7 + TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "float8")]
        public static bool Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 == (float)(TestData_LHS[i].x0 - TestData_RHS[i].x0) &
                          x.x1 == (float)(TestData_LHS[i].x1 - TestData_RHS[i].x1) &
                          x.x2 == (float)(TestData_LHS[i].x2 - TestData_RHS[i].x2) &
                          x.x3 == (float)(TestData_LHS[i].x3 - TestData_RHS[i].x3) &
                          x.x4 == (float)(TestData_LHS[i].x4 - TestData_RHS[i].x4) &
                          x.x5 == (float)(TestData_LHS[i].x5 - TestData_RHS[i].x5) &
                          x.x6 == (float)(TestData_LHS[i].x6 - TestData_RHS[i].x6) &
                          x.x7 == (float)(TestData_LHS[i].x7 - TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "float8")]
        public static bool Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 == (float)(TestData_LHS[i].x0 * TestData_RHS[i].x0) &
                          x.x1 == (float)(TestData_LHS[i].x1 * TestData_RHS[i].x1) &
                          x.x2 == (float)(TestData_LHS[i].x2 * TestData_RHS[i].x2) &
                          x.x3 == (float)(TestData_LHS[i].x3 * TestData_RHS[i].x3) &
                          x.x4 == (float)(TestData_LHS[i].x4 * TestData_RHS[i].x4) &
                          x.x5 == (float)(TestData_LHS[i].x5 * TestData_RHS[i].x5) &
                          x.x6 == (float)(TestData_LHS[i].x6 * TestData_RHS[i].x6) &
                          x.x7 == (float)(TestData_LHS[i].x7 * TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "float8")]
        public static bool Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 == (float)(TestData_LHS[i].x0 / TestData_RHS[i].x0) &
                          x.x1 == (float)(TestData_LHS[i].x1 / TestData_RHS[i].x1) &
                          x.x2 == (float)(TestData_LHS[i].x2 / TestData_RHS[i].x2) &
                          x.x3 == (float)(TestData_LHS[i].x3 / TestData_RHS[i].x3) &
                          x.x4 == (float)(TestData_LHS[i].x4 / TestData_RHS[i].x4) &
                          x.x5 == (float)(TestData_LHS[i].x5 / TestData_RHS[i].x5) &
                          x.x6 == (float)(TestData_LHS[i].x6 / TestData_RHS[i].x6) &
                          x.x7 == (float)(TestData_LHS[i].x7 / TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "float8")]
        public static bool Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 == (float)(TestData_LHS[i].x0 % TestData_RHS[i].x0) &
                          x.x1 == (float)(TestData_LHS[i].x1 % TestData_RHS[i].x1) &
                          x.x2 == (float)(TestData_LHS[i].x2 % TestData_RHS[i].x2) &
                          x.x3 == (float)(TestData_LHS[i].x3 % TestData_RHS[i].x3) &
                          x.x4 == (float)(TestData_LHS[i].x4 % TestData_RHS[i].x4) &
                          x.x5 == (float)(TestData_LHS[i].x5 % TestData_RHS[i].x5) &
                          x.x6 == (float)(TestData_LHS[i].x6 % TestData_RHS[i].x6) &
                          x.x7 == (float)(TestData_LHS[i].x7 % TestData_RHS[i].x7);
            }

            return result;
        }

        [UnitTest("Types", "float8")]
        public static bool Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = -TestData_LHS[i];

                result &= x.x0 == (float)(-TestData_LHS[i].x0) &
                          x.x1 == (float)(-TestData_LHS[i].x1) &
                          x.x2 == (float)(-TestData_LHS[i].x2) &
                          x.x3 == (float)(-TestData_LHS[i].x3) &
                          x.x4 == (float)(-TestData_LHS[i].x4) &
                          x.x5 == (float)(-TestData_LHS[i].x5) &
                          x.x6 == (float)(-TestData_LHS[i].x6) &
                          x.x7 == (float)(-TestData_LHS[i].x7);
            }

            return result;
        }


        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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


        [UnitTest("Types", "float8")]
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


        [UnitTest("Types", "float8")]
        public static bool Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                float4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                float4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                float4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                float4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;


                float3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                float3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                float3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                float3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                float3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                float3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;


                float2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                float2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                float2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                float2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                float2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                float2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                float2 v2_6 = TestData_LHS[i].v2_6;
                result &= v2_6.x == TestData_LHS[i].x6 &
                          v2_6.y == TestData_LHS[i].x7;
            }


            return result;
        }


        [UnitTest("Types", "float8")]
        public static bool Cast_ToV256()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v256 x = TestData_LHS[i];

                result &= x.Float0 == TestData_LHS[i].x0 &
                          x.Float1 == TestData_LHS[i].x1 &
                          x.Float2 == TestData_LHS[i].x2 &
                          x.Float3 == TestData_LHS[i].x3 &
                          x.Float4 == TestData_LHS[i].x4 &
                          x.Float5 == TestData_LHS[i].x5 &
                          x.Float6 == TestData_LHS[i].x6 &
                          x.Float7 == TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "float8")]
        public static bool Cast_FromV256()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float8 x = TestData_LHS[i];
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


        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
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

        [UnitTest("Types", "float8")]
        public static bool Cast_ToInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = (int8)TestData_LHS[i];

                result &= x.x0 == (int)TestData_LHS[i].x0 &
                          x.x1 == (int)TestData_LHS[i].x1 &
                          x.x2 == (int)TestData_LHS[i].x2 &
                          x.x3 == (int)TestData_LHS[i].x3 &
                          x.x4 == (int)TestData_LHS[i].x4 &
                          x.x5 == (int)TestData_LHS[i].x5 &
                          x.x6 == (int)TestData_LHS[i].x6 &
                          x.x7 == (int)TestData_LHS[i].x7;
            }

            return result;
        }

        [UnitTest("Types", "float8")]
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
    }
#endif
}