using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class SByte8
    {
        internal const int NUM_TESTS = 4;


        internal static sbyte8[] TestData_LHS => new sbyte8[]
        {
            new sbyte8{x0 = -83,
					   x1 = 55,
					   x2 = -99,
					   x3 = 76,
					   x4 = 65,
					   x5 = 1,
					   x6 = -11,
                       x7 = 35},
					  
            new sbyte8{x0 = 22,
					   x1 = 12,
					   x2 = 16,
					   x3 = -11,
					   x4 = 99,
					   x5 = 80,
					   x6 = 54,
					   x7 = 39},
					        // EQUAL
            new sbyte8{x0 = -87,
					   x1 = sbyte.MaxValue,
					   x2 = 17,
					   x3 = 21,
					   x4 = 0,
					   x5 = 47,
					   x6 = 32,
					   x7 = -56},
					  
            new sbyte8{x0 = sbyte.MinValue,
					   x1 = 13,
					   x2 = -111,
					   x3 = 66,
					   x4 = -99,
					   x5 = 39,
					   x6 = -50,
					   x7 = 121}
        };

        internal static sbyte8[] TestData_RHS => new sbyte8[]
        {
            new sbyte8{x0 = 12,
					   x1 = -8,
					   x2 = 53,
					   x3 = 98,
					   x4 = 2,
					   x5 = -73,
					   x6 = 97,
					   x7 = 44},
					  
            new sbyte8{x0 = 22,
					   x1 = 12,
					   x2 = 16,
					   x3 = -11,
					   x4 = 99,
					   x5 = 80,
					   x6 = 54,
					   x7 = 39},
					        // EQUAL
            new sbyte8{x0 = 17,
					   x1 = -87,
					   x2 = 9,
					   x3 = -82,
					   x4 = -39,
					   x5 = 45,
					   x6 = 90,
					   x7 = -62},
					  
            new sbyte8{x0 = 2,
					   x1 = 9,
					   x2 = -20,
					   x3 = -92,
					   x4 = 87,
					   x5 = -19,
					   x6 = -82,
					   x7 = 43}
        };


        [Test]
        public static void Constructor_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte()
        {
            sbyte8 x = new sbyte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

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
        public static void Constructor_SByte()
        {
            sbyte8 x = new sbyte8(TestData_LHS[0].x0);

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
        public static void Constructor_SByte2_SByte2_SByte2_SByte2()
        {
            sbyte8 x = new sbyte8(new sbyte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new sbyte2(TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte2(TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_SByte2_SByte3_SByte3()
        {
            sbyte8 x = new sbyte8(new sbyte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new sbyte3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new sbyte3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_SByte3_SByte2_SByte3()
        {
            sbyte8 x = new sbyte8(new sbyte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new sbyte2(TestData_LHS[0].x3, TestData_LHS[0].x4), new sbyte3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_SByte3_SByte3_SByte2()
        {
            sbyte8 x = new sbyte8(new sbyte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new sbyte3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_SByte4_SByte2_SByte2()
        {
            sbyte8 x = new sbyte8(new sbyte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte2(TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_SByte2_SByte4_SByte2()
        {
            sbyte8 x = new sbyte8(new sbyte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new sbyte4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_SByte2_SByte2_SByte4()
        {
            sbyte8 x = new sbyte8(new sbyte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new sbyte2(TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_SByte4_SByte4()
        {
            sbyte8 x = new sbyte8(new sbyte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
                sbyte8 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 + TestData_RHS[i].x0) & 
                          x.x1 == (sbyte)(TestData_LHS[i].x1 + TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 + TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 + TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 + TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 + TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 + TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 + TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 - TestData_RHS[i].x0) &
                          x.x1 == (sbyte)(TestData_LHS[i].x1 - TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 - TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 - TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 - TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 - TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 - TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 - TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 * TestData_RHS[i].x0) &
                          x.x1 == (sbyte)(TestData_LHS[i].x1 * TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 * TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 * TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 * TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 * TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 * TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 * TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 / TestData_RHS[i].x0) &
                          x.x1 == (sbyte)(TestData_LHS[i].x1 / TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 / TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 / TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 / TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 / TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 / TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 / TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 % TestData_RHS[i].x0) &
                          x.x1 == (sbyte)(TestData_LHS[i].x1 % TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 % TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 % TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 % TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 % TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 % TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 % TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = -TestData_LHS[i];

                result &= x.x0 == (sbyte)(-TestData_LHS[i].x0) &
                          x.x1 == (sbyte)(-TestData_LHS[i].x1) &
                          x.x2 == (sbyte)(-TestData_LHS[i].x2) &
                          x.x3 == (sbyte)(-TestData_LHS[i].x3) &
                          x.x4 == (sbyte)(-TestData_LHS[i].x4) &
                          x.x5 == (sbyte)(-TestData_LHS[i].x5) &
                          x.x6 == (sbyte)(-TestData_LHS[i].x6) &
                          x.x7 == (sbyte)(-TestData_LHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 & TestData_RHS[i].x0) &
                          x.x1 == (sbyte)(TestData_LHS[i].x1 & TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 & TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 & TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 & TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 & TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 & TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 & TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 | TestData_RHS[i].x0) &
                          x.x1 == (sbyte)(TestData_LHS[i].x1 | TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 | TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 | TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 | TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 | TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 | TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 | TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 == (sbyte)(TestData_LHS[i].x0 ^ TestData_RHS[i].x0) &
                          x.x1 == (sbyte)(TestData_LHS[i].x1 ^ TestData_RHS[i].x1) &
                          x.x2 == (sbyte)(TestData_LHS[i].x2 ^ TestData_RHS[i].x2) &
                          x.x3 == (sbyte)(TestData_LHS[i].x3 ^ TestData_RHS[i].x3) &
                          x.x4 == (sbyte)(TestData_LHS[i].x4 ^ TestData_RHS[i].x4) &
                          x.x5 == (sbyte)(TestData_LHS[i].x5 ^ TestData_RHS[i].x5) &
                          x.x6 == (sbyte)(TestData_LHS[i].x6 ^ TestData_RHS[i].x6) &
                          x.x7 == (sbyte)(TestData_LHS[i].x7 ^ TestData_RHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = ~TestData_LHS[i];

                result &= x.x0 == (sbyte)(~TestData_LHS[i].x0) &
                          x.x1 == (sbyte)(~TestData_LHS[i].x1) &
                          x.x2 == (sbyte)(~TestData_LHS[i].x2) &
                          x.x3 == (sbyte)(~TestData_LHS[i].x3) &
                          x.x4 == (sbyte)(~TestData_LHS[i].x4) &
                          x.x5 == (sbyte)(~TestData_LHS[i].x5) &
                          x.x6 == (sbyte)(~TestData_LHS[i].x6) &
                          x.x7 == (sbyte)(~TestData_LHS[i].x7);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sbyte8 x = TestData_LHS[i] << j;

                    result &= x.x0 == (sbyte)(TestData_LHS[i].x0 << j) & 
                              x.x1 == (sbyte)(TestData_LHS[i].x1 << j) &
                              x.x2 == (sbyte)(TestData_LHS[i].x2 << j) &
                              x.x3 == (sbyte)(TestData_LHS[i].x3 << j) &
                              x.x4 == (sbyte)(TestData_LHS[i].x4 << j) &
                              x.x5 == (sbyte)(TestData_LHS[i].x5 << j) &
                              x.x6 == (sbyte)(TestData_LHS[i].x6 << j) &
                              x.x7 == (sbyte)(TestData_LHS[i].x7 << j);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sbyte8 x = TestData_LHS[i] >> j;

                    result &= x.x0 == (sbyte)(TestData_LHS[i].x0 >> j) &
                              x.x1 == (sbyte)(TestData_LHS[i].x1 >> j) &
                              x.x2 == (sbyte)(TestData_LHS[i].x2 >> j) &
                              x.x3 == (sbyte)(TestData_LHS[i].x3 >> j) &
                              x.x4 == (sbyte)(TestData_LHS[i].x4 >> j) &
                              x.x5 == (sbyte)(TestData_LHS[i].x5 >> j) &
                              x.x6 == (sbyte)(TestData_LHS[i].x6 >> j) &
                              x.x7 == (sbyte)(TestData_LHS[i].x7 >> j);
                }
            }

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
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
            }


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v128 x = TestData_LHS[i];

                result &= x.SByte0 == TestData_LHS[i].x0 &
                          x.SByte1 == TestData_LHS[i].x1 &
                          x.SByte2 == TestData_LHS[i].x2 &
                          x.SByte3 == TestData_LHS[i].x3 &
                          x.SByte4 == TestData_LHS[i].x4 &
                          x.SByte5 == TestData_LHS[i].x5 &
                          x.SByte6 == TestData_LHS[i].x6 &
                          x.SByte7 == TestData_LHS[i].x7;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = TestData_LHS[i];
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

            Assert.AreEqual(result, true);
        }


        [Test]
        public static void Cast_ToShort()
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
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

            Assert.AreEqual(result, true);
        }
    }
}