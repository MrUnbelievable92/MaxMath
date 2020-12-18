using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class Short8
    {
        internal const int NUM_TESTS = 4;


        internal static short8[] TestData_LHS => new short8[]
        {
            new short8{x0 = -18300,
					   x1 = 55,
					   x2 = -9639,
					   x3 = 763,
					   x4 = -5097,
					   x5 = 11,
					   x6 = 2131,
                       x7 = -3825},
					  
            new short8{x0 = 212,
					   x1 = 18892,
					   x2 = -16,
					   x3 = 2311,
					   x4 = 99,
					   x5 = -5680,
					   x6 = 549,
					   x7 = -9432},
					         
            new short8{x0 = 87,
					   x1 = short.MaxValue,
					   x2 = 17,
					   x3 = 1747,
					   x4 = 0,
					   x5 = 4127,
					   x6 = 392,
                       x7 = 21156},
					  
            new short8{x0 = short.MinValue,
					   x1 = -1563,
					   x2 = 11221,
					   x3 = -1446,
					   x4 = 1979,
					   x5 = -399,
					   x6 = 2502,
					   x7 = 121}
        };

        internal static short8[] TestData_RHS => new short8[]
        {
            new short8{x0 = 12,
					   x1 = -8,
					   x2 = 5383,
					   x3 = 98,
					   x4 = -4242,
					   x5 = -17996,
					   x6 = 970,
                       x7 = 44},

            TestData_LHS[1],

            new short8{x0 = 17955,
					   x1 = -827,
					   x2 = -9643,
					   x3 = 18862,
					   x4 = 239,
					   x5 = -435,
					   x6 = -9750,
					   x7 = -162},
					  
            new short8{x0 = 2,
					   x1 = -963,
					   x2 = 20540,
					   x3 = 19242,
					   x4 = 8967,
					   x5 = -26789,
					   x6 = -1862,
                       x7 = 43}
        };


        [Test]
        public static void Constructor_Short_Short_Short_Short_Short_Short_Short_Short()
        {
            short8 x = new short8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

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
        public static void Constructor_Short()
        {
            short8 x = new short8(TestData_LHS[0].x0);

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
        public static void Constructor_Short2_Short2_Short2_Short2()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short2(TestData_LHS[0].x2, TestData_LHS[0].x3), new short2(TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Short2_Short3_Short3()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new short3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Short3_Short2_Short3()
        {
            short8 x = new short8(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short2(TestData_LHS[0].x3, TestData_LHS[0].x4), new short3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Short3_Short3_Short2()
        {
            short8 x = new short8(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Short4_Short2_Short2()
        {
            short8 x = new short8(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short2(TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Short2_Short4_Short2()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Short2_Short2_Short4()
        {
            short8 x = new short8(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short2(TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Short4_Short4()
        {
            short8 x = new short8(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Subtract()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Multiply()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Divide()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Remainder()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Negate()
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

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void AND()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void OR()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void XOR()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NOT()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    short8 x = TestData_LHS[i] << j;

                    result &= x.x0 == (short)(TestData_LHS[i].x0 << j) & 
                              x.x1 == (short)(TestData_LHS[i].x1 << j) &
                              x.x2 == (short)(TestData_LHS[i].x2 << j) &
                              x.x3 == (short)(TestData_LHS[i].x3 << j) &
                              x.x4 == (short)(TestData_LHS[i].x4 << j) &
                              x.x5 == (short)(TestData_LHS[i].x5 << j) &
                              x.x6 == (short)(TestData_LHS[i].x6 << j) &
                              x.x7 == (short)(TestData_LHS[i].x7 << j);
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
                for (int j = 0; j < 16; j++)
                {
                    short8 x = TestData_LHS[i] >> j;

                    result &= x.x0 == (short)(TestData_LHS[i].x0 >> j) &
                              x.x1 == (short)(TestData_LHS[i].x1 >> j) &
                              x.x2 == (short)(TestData_LHS[i].x2 >> j) &
                              x.x3 == (short)(TestData_LHS[i].x3 >> j) &
                              x.x4 == (short)(TestData_LHS[i].x4 >> j) &
                              x.x5 == (short)(TestData_LHS[i].x5 >> j) &
                              x.x6 == (short)(TestData_LHS[i].x6 >> j) &
                              x.x7 == (short)(TestData_LHS[i].x7 >> j);
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
        public static void Shuffle()
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


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Cast_ToV128()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_FromV128()
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
        public static void Cast_ToInt()
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

        [Test]
        public static void Cast_ToFloat()
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

            Assert.AreEqual(true, result);
        }
    }
}