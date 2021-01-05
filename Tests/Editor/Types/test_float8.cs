using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class Float8
    {
        internal const int NUM_TESTS = 4;


        internal static float8[] TestData_LHS => new float8[]
        {
            new float8{ x0 = 1837.300f,
	                    x1 = 55f,
	                    x2 = 963259f,
	                    x3 = -7633f,
	                    x4 = -65089.297f,
	                    x5 = 134901f,
	                    x6 = -21333.671f,
                        x7 = 38233895f},
	
            new float8{ x0 = 21722562f,
	                    x1 = -1889.32f,
	                    x2 = 153566f,
	                    x3 = -2318.8221f,
	                    x4 = -99599999f,
	                    x5 = -5682.2210f,
	                    x6 = 547.79f,
                        x7 = 394.32f},
	       
            new float8{ x0 = 85897f,
	                    x1 = float.MaxValue,
	                    x2 = 1217f,
	                    x3 = -1747f,
	                    x4 = 0f,
	                    x5 = 4184.32327f,
	                    x6 = -39964.22f,
                        x7 = 21466156f},
	
            new float8{ x0 = float.MinValue,
	                    x1 = 1563f,
	                    x2 = -11221f,
	                    x3 = -61445216f,
	                    x4 = 1316879.79f,
	                    x5 = -399f,
	                    x6 = 63382.502f,
                        x7 = -2565771f}
        };

        internal static float8[] TestData_RHS => new float8[]
        {
            new float8{ x0 = 12f,
	                    x1 = 83.2987f,
	                    x2 = 53873.43f,
	                    x3 = 98f,
	                    x4 = 42425642f,
	                    x5 = -1798.496f,
	                    x6 = 978540f,
                        x7 = -48532.34f},

            TestData_LHS[1],

            new float8{ x0 = 173899.955f,
	                    x1 = 874227f,
	                    x2 = -964553f,
	                    x3 = 18.867862f,
	                    x4 = 266339f,
	                    x5 = -43552f,
	                    x6 = 979950f,
                        x7 = -13262f},
	
            new float8{ x0 = 24787f,
	                    x1 = -963f,
	                    x2 = 2056.740f,
	                    x3 = -192472f,
	                    x4 = -8967f,
	                    x5 = 26.4288789f,
	                    x6 = 1.85262f,
                        x7 = 45683f}
        };


        [Test]
        public static void Constructor_Float_Float_Float_Float_Float_Float_Float_Float()
        {
            float8 x = new float8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float()
        {
            float8 x = new float8(TestData_LHS[0].x0);

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x0 &
                   x.x2 == TestData_LHS[0].x0 &
                   x.x3 == TestData_LHS[0].x0 &
                   x.x4 == TestData_LHS[0].x0 &
                   x.x5 == TestData_LHS[0].x0 &
                   x.x6 == TestData_LHS[0].x0 &
                   x.x7 == TestData_LHS[0].x0, true);
        }

        [Test]
        public static void Constructor_Float2_Float2_Float2_Float2()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float2(TestData_LHS[0].x2, TestData_LHS[0].x3), new float2(TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float2_Float3_Float3()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new float3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float3_Float2_Float3()
        {
            float8 x = new float8(new float3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new float2(TestData_LHS[0].x3, TestData_LHS[0].x4), new float3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float3_Float3_Float2()
        {
            float8 x = new float8(new float3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new float3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float4_Float2_Float2()
        {
            float8 x = new float8(new float4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new float2(TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float2_Float4_Float2()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new float2(TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float2_Float2_Float4()
        {
            float8 x = new float8(new float2(TestData_LHS[0].x0, TestData_LHS[0].x1), new float2(TestData_LHS[0].x2, TestData_LHS[0].x3), new float4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }

        [Test]
        public static void Constructor_Float4_Float4()
        {
            float8 x = new float8(new float4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new float4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7, true);
        }


        [Test]
        public static void Indexer()
        {
            Assert.AreEqual(TestData_LHS[0][0] == TestData_LHS[0].x0 &
                   TestData_LHS[0][1] == TestData_LHS[0].x1 &
                   TestData_LHS[0][2] == TestData_LHS[0].x2 &
                   TestData_LHS[0][3] == TestData_LHS[0].x3 &
                   TestData_LHS[0][4] == TestData_LHS[0].x4 &
                   TestData_LHS[0][5] == TestData_LHS[0].x5 &
                   TestData_LHS[0][6] == TestData_LHS[0].x6 &
                   TestData_LHS[0][7] == TestData_LHS[0].x7, true);
        }


        [Test]
        public static void Add()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Subtract()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Multiply()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Divide()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Remainder()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Negate()
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

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Equal()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = TestData_LHS[i] == TestData_RHS[i];

                result &= x.Equals(new bool8(new bool4(TestData_LHS[i].x0 == TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 == TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 == TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 == TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 == TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 == TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 == TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 == TestData_RHS[i].x7)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.Equals(new bool8(new bool4(TestData_LHS[i].x0 < TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 < TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 < TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 < TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 < TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 < TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 < TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 < TestData_RHS[i].x7)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = TestData_LHS[i] > TestData_RHS[i];

                result &= x.Equals(new bool8(new bool4(TestData_LHS[i].x0 > TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 > TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 > TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 > TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 > TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 > TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 > TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 > TestData_RHS[i].x7)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NotEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = TestData_LHS[i] != TestData_RHS[i];

                result &= x.Equals(new bool8(new bool4(TestData_LHS[i].x0 != TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 != TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 != TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 != TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 != TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 != TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 != TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 != TestData_RHS[i].x7)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = TestData_LHS[i] <= TestData_RHS[i];

                result &= x.Equals(new bool8(new bool4(TestData_LHS[i].x0 <= TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 <= TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 <= TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 <= TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 <= TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 <= TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 <= TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 <= TestData_RHS[i].x7)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = TestData_LHS[i] >= TestData_RHS[i];

                result &= x.Equals(new bool8(new bool4(TestData_LHS[i].x0 >= TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1 >= TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2 >= TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3 >= TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4 >= TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5 >= TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6 >= TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7 >= TestData_RHS[i].x7)));
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

                result &= x == (TestData_LHS[i].x0 == TestData_RHS[i].x0 &
                                TestData_LHS[i].x1 == TestData_RHS[i].x1 &
                                TestData_LHS[i].x2 == TestData_RHS[i].x2 &
                                TestData_LHS[i].x3 == TestData_RHS[i].x3 &
                                TestData_LHS[i].x4 == TestData_RHS[i].x4 &
                                TestData_LHS[i].x5 == TestData_RHS[i].x5 &
                                TestData_LHS[i].x6 == TestData_RHS[i].x6 &
                                TestData_LHS[i].x7 == TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ShuffleGetter()
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


            Assert.AreEqual(true, result);
        }

        //[Test]
        //public static void ShuffleSetter()
        //{
        //    bool result = true;
        //
        //    for (int i = 0; i < NUM_TESTS; i++)
        //    {
        //        float8 v4_0 = TestData_LHS[i];
        //        v4_0.v4_0 = Float4.TestData_LHS[i];
        //        result &= v4_0.x0 == Float4.TestData_LHS[i].x;
        //        result &= v4_0.x1 == Float4.TestData_LHS[i].y;
        //        result &= v4_0.x2 == Float4.TestData_LHS[i].z;
        //        result &= v4_0.x3 == Float4.TestData_LHS[i].w;
        //        result &= v4_0.x4 == TestData_LHS[i].x4;
        //        result &= v4_0.x5 == TestData_LHS[i].x5;
        //        result &= v4_0.x6 == TestData_LHS[i].x6;
        //        result &= v4_0.x7 == TestData_LHS[i].x7;
        //
        //        float8 v4_1 = TestData_LHS[i];
        //        v4_1.v4_1 = Float4.TestData_LHS[i];
        //        result &= v4_1.x0 == TestData_LHS[i].x0;
        //        result &= v4_1.x1 == Float4.TestData_LHS[i].x;
        //        result &= v4_1.x2 == Float4.TestData_LHS[i].y;
        //        result &= v4_1.x3 == Float4.TestData_LHS[i].z;
        //        result &= v4_1.x4 == Float4.TestData_LHS[i].w;
        //        result &= v4_1.x5 == TestData_LHS[i].x5;
        //        result &= v4_1.x6 == TestData_LHS[i].x6;
        //        result &= v4_1.x7 == TestData_LHS[i].x7;
        //
        //        float8 v4_2 = TestData_LHS[i];
        //        v4_2.v4_2 = Float4.TestData_LHS[i];
        //        result &= v4_2.x0 == TestData_LHS[i].x0;
        //        result &= v4_2.x1 == TestData_LHS[i].x1;
        //        result &= v4_2.x2 == Float4.TestData_LHS[i].x;
        //        result &= v4_2.x3 == Float4.TestData_LHS[i].y;
        //        result &= v4_2.x4 == Float4.TestData_LHS[i].z;
        //        result &= v4_2.x5 == Float4.TestData_LHS[i].w;
        //        result &= v4_2.x6 == TestData_LHS[i].x6;
        //        result &= v4_2.x7 == TestData_LHS[i].x7;
        //        
        //        float8 v4_3 = TestData_LHS[i];
        //        v4_3.v4_3 = Float4.TestData_LHS[i];
        //        result &= v4_3.x0 == TestData_LHS[i].x0;
        //        result &= v4_3.x1 == TestData_LHS[i].x1;
        //        result &= v4_3.x2 == TestData_LHS[i].x2;
        //        result &= v4_3.x3 == Float4.TestData_LHS[i].x;
        //        result &= v4_3.x4 == Float4.TestData_LHS[i].y;
        //        result &= v4_3.x5 == Float4.TestData_LHS[i].z;
        //        result &= v4_3.x6 == Float4.TestData_LHS[i].w;
        //        result &= v4_3.x7 == TestData_LHS[i].x7;
        //        
        //        float8 v4_4 = TestData_LHS[i];
        //        v4_4.v4_4 = Float4.TestData_LHS[i];
        //        result &= v4_4.x0 == TestData_LHS[i].x0;
        //        result &= v4_4.x1 == TestData_LHS[i].x1;
        //        result &= v4_4.x2 == TestData_LHS[i].x2;
        //        result &= v4_4.x3 == TestData_LHS[i].x3;
        //        result &= v4_4.x4 == Float4.TestData_LHS[i].x;
        //        result &= v4_4.x5 == Float4.TestData_LHS[i].y;
        //        result &= v4_4.x6 == Float4.TestData_LHS[i].z;
        //        result &= v4_4.x7 == Float4.TestData_LHS[i].w;
        //
        //
        //        float8 v3_0 = TestData_LHS[i];
        //        v3_0.v3_0 = Float3.TestData_LHS[i];
        //        result &= v3_0.x0 == Float3.TestData_LHS[i].x;
        //        result &= v3_0.x1 == Float3.TestData_LHS[i].y;
        //        result &= v3_0.x2 == Float3.TestData_LHS[i].z;
        //        result &= v3_0.x3 == TestData_LHS[i].x3;
        //        result &= v3_0.x4 == TestData_LHS[i].x4;
        //        result &= v3_0.x5 == TestData_LHS[i].x5;
        //        result &= v3_0.x6 == TestData_LHS[i].x6;
        //        result &= v3_0.x7 == TestData_LHS[i].x7;
        //
        //        float8 v3_1 = TestData_LHS[i];
        //        v3_1.v3_1 = Float3.TestData_LHS[i];
        //        result &= v3_1.x0 == TestData_LHS[i].x0;
        //        result &= v3_1.x1 == Float3.TestData_LHS[i].x;
        //        result &= v3_1.x2 == Float3.TestData_LHS[i].y;
        //        result &= v3_1.x3 == Float3.TestData_LHS[i].z;
        //        result &= v3_1.x4 == TestData_LHS[i].x4;
        //        result &= v3_1.x5 == TestData_LHS[i].x5;
        //        result &= v3_1.x6 == TestData_LHS[i].x6;
        //        result &= v3_1.x7 == TestData_LHS[i].x7;
        //
        //        float8 v3_2 = TestData_LHS[i];
        //        v3_2.v3_2 = Float3.TestData_LHS[i];
        //        result &= v3_2.x0 == TestData_LHS[i].x0;
        //        result &= v3_2.x1 == TestData_LHS[i].x1;
        //        result &= v3_2.x2 == Float3.TestData_LHS[i].x;
        //        result &= v3_2.x3 == Float3.TestData_LHS[i].y;
        //        result &= v3_2.x4 == Float3.TestData_LHS[i].z;
        //        result &= v3_2.x5 == TestData_LHS[i].x5;
        //        result &= v3_2.x6 == TestData_LHS[i].x6;
        //        result &= v3_2.x7 == TestData_LHS[i].x7;
        //
        //        float8 v3_3 = TestData_LHS[i];
        //        v3_3.v3_3 = Float3.TestData_LHS[i];
        //        result &= v3_3.x0 == TestData_LHS[i].x0;
        //        result &= v3_3.x1 == TestData_LHS[i].x1;
        //        result &= v3_3.x2 == TestData_LHS[i].x2;
        //        result &= v3_3.x3 == Float3.TestData_LHS[i].x;
        //        result &= v3_3.x4 == Float3.TestData_LHS[i].y;
        //        result &= v3_3.x5 == Float3.TestData_LHS[i].z;
        //        result &= v3_3.x6 == TestData_LHS[i].x6;
        //        result &= v3_3.x7 == TestData_LHS[i].x7;
        //
        //        float8 v3_4 = TestData_LHS[i];
        //        v3_4.v3_4 = Float3.TestData_LHS[i];
        //        result &= v3_4.x0 == TestData_LHS[i].x0;
        //        result &= v3_4.x1 == TestData_LHS[i].x1;
        //        result &= v3_4.x2 == TestData_LHS[i].x2;
        //        result &= v3_4.x3 == TestData_LHS[i].x3;
        //        result &= v3_4.x4 == Float3.TestData_LHS[i].x;
        //        result &= v3_4.x5 == Float3.TestData_LHS[i].y;
        //        result &= v3_4.x6 == Float3.TestData_LHS[i].z;
        //        result &= v3_4.x7 == TestData_LHS[i].x7;
        //
        //        float8 v3_5 = TestData_LHS[i];
        //        v3_5.v3_5 = Float3.TestData_LHS[i];
        //        result &= v3_5.x0 == TestData_LHS[i].x0;
        //        result &= v3_5.x1 == TestData_LHS[i].x1;
        //        result &= v3_5.x2 == TestData_LHS[i].x2;
        //        result &= v3_5.x3 == TestData_LHS[i].x3;
        //        result &= v3_5.x4 == TestData_LHS[i].x4;
        //        result &= v3_5.x5 == Float3.TestData_LHS[i].x;
        //        result &= v3_5.x6 == Float3.TestData_LHS[i].y;
        //        result &= v3_5.x7 == Float3.TestData_LHS[i].z;
        //
        //
        //        float8 v2_0 = TestData_LHS[i];
        //        v2_0.v2_0 = Float2.TestData_LHS[i];
        //        result &= v2_0.x0 == Float2.TestData_LHS[i].x;
        //        result &= v2_0.x1 == Float2.TestData_LHS[i].y;
        //        result &= v2_0.x2 == TestData_LHS[i].x2;
        //        result &= v2_0.x3 == TestData_LHS[i].x3;
        //        result &= v2_0.x4 == TestData_LHS[i].x4;
        //        result &= v2_0.x5 == TestData_LHS[i].x5;
        //        result &= v2_0.x6 == TestData_LHS[i].x6;
        //        result &= v2_0.x7 == TestData_LHS[i].x7;
        //
        //        float8 v2_1 = TestData_LHS[i];
        //        v2_1.v2_1 = Float2.TestData_LHS[i];
        //        result &= v2_1.x0 == TestData_LHS[i].x0;
        //        result &= v2_1.x1 == Float2.TestData_LHS[i].x;
        //        result &= v2_1.x2 == Float2.TestData_LHS[i].y;
        //        result &= v2_1.x3 == TestData_LHS[i].x3;
        //        result &= v2_1.x4 == TestData_LHS[i].x4;
        //        result &= v2_1.x5 == TestData_LHS[i].x5;
        //        result &= v2_1.x6 == TestData_LHS[i].x6;
        //        result &= v2_1.x7 == TestData_LHS[i].x7;
        //
        //        float8 v2_2 = TestData_LHS[i];
        //        v2_2.v2_2 = Float2.TestData_LHS[i];
        //        result &= v2_2.x0 == TestData_LHS[i].x0;
        //        result &= v2_2.x1 == TestData_LHS[i].x1;
        //        result &= v2_2.x2 == Float2.TestData_LHS[i].x;
        //        result &= v2_2.x3 == Float2.TestData_LHS[i].y;
        //        result &= v2_2.x4 == TestData_LHS[i].x4;
        //        result &= v2_2.x5 == TestData_LHS[i].x5;
        //        result &= v2_2.x6 == TestData_LHS[i].x6;
        //        result &= v2_2.x7 == TestData_LHS[i].x7;
        //
        //        float8 v2_3 = TestData_LHS[i];
        //        v2_3.v2_3 = Float2.TestData_LHS[i];
        //        result &= v2_3.x0 == TestData_LHS[i].x0;
        //        result &= v2_3.x1 == TestData_LHS[i].x1;
        //        result &= v2_3.x2 == TestData_LHS[i].x2;
        //        result &= v2_3.x3 == Float2.TestData_LHS[i].x;
        //        result &= v2_3.x4 == Float2.TestData_LHS[i].y;
        //        result &= v2_3.x5 == TestData_LHS[i].x5;
        //        result &= v2_3.x6 == TestData_LHS[i].x6;
        //        result &= v2_3.x7 == TestData_LHS[i].x7;
        //
        //        float8 v2_4 = TestData_LHS[i];
        //        v2_4.v2_4 = Float2.TestData_LHS[i];
        //        result &= v2_4.x0 == TestData_LHS[i].x0;
        //        result &= v2_4.x1 == TestData_LHS[i].x1;
        //        result &= v2_4.x2 == TestData_LHS[i].x2;
        //        result &= v2_4.x3 == TestData_LHS[i].x3;
        //        result &= v2_4.x4 == Float2.TestData_LHS[i].x;
        //        result &= v2_4.x5 == Float2.TestData_LHS[i].y;
        //        result &= v2_4.x6 == TestData_LHS[i].x6;
        //        result &= v2_4.x7 == TestData_LHS[i].x7;
        //
        //        float8 v2_5 = TestData_LHS[i];
        //        v2_5.v2_5 = Float2.TestData_LHS[i];
        //        result &= v2_5.x0 == TestData_LHS[i].x0;
        //        result &= v2_5.x1 == TestData_LHS[i].x1;
        //        result &= v2_5.x2 == TestData_LHS[i].x2;
        //        result &= v2_5.x3 == TestData_LHS[i].x3;
        //        result &= v2_5.x4 == TestData_LHS[i].x4;
        //        result &= v2_5.x5 == Float2.TestData_LHS[i].x;
        //        result &= v2_5.x6 == Float2.TestData_LHS[i].y;
        //        result &= v2_5.x7 == TestData_LHS[i].x7;
        //
        //        float8 v2_6 = TestData_LHS[i];
        //        v2_6.v2_6 = Float2.TestData_LHS[i];
        //        result &= v2_6.x0 == TestData_LHS[i].x0;
        //        result &= v2_6.x1 == TestData_LHS[i].x1;
        //        result &= v2_6.x2 == TestData_LHS[i].x2;
        //        result &= v2_6.x3 == TestData_LHS[i].x3;
        //        result &= v2_6.x4 == TestData_LHS[i].x4;
        //        result &= v2_6.x5 == TestData_LHS[i].x5;
        //        result &= v2_6.x6 == Float2.TestData_LHS[i].x;
        //        result &= v2_6.x7 == Float2.TestData_LHS[i].y;
        //    }
        //
        //    Assert.AreEqual(true, result);
        //}


        [Test]
        public static void Cast_ToV256()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_FromV256()
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

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Cast_ToByte()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToSByte()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToShort()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToUShort()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToInt()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToUInt()
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

            Assert.AreEqual(true, result);
        }
    }
}