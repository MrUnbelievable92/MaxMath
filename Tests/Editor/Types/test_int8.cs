using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class Int8
    {
        internal const int NUM_TESTS = 4;


        internal static int8[] TestData_LHS => new int8[]
        {
            new int8{x0 = 1837300,
					 x1 = 55,
					 x2 = 963259,
					 x3 = -7633,
					 x4 = -65089297,
					 x5 = 134901,
					 x6 = -21333671,
					 x7 = 38233895},
					
            new int8{x0 = 21722562,
					 x1 = -188932,
					 x2 = 153566,
					 x3 = -23188221,
					 x4 = -99599999,
					 x5 = -56822210,
					 x6 = 54779,
					 x7 = 39432},
					       
            new int8{x0 = 85897,
					 x1 = int.MaxValue,
					 x2 = 1217,
					 x3 = -1747,
					 x4 = 0,
					 x5 = 418432327,
					 x6 = -3996422,
					 x7 = 21466156},
					
            new int8{x0 = int.MinValue,
					 x1 = 1563,
					 x2 = -11221,
					 x3 = -61445216,
					 x4 = 131687979,
					 x5 = -399,
					 x6 = 63382502,
					 x7 = -2565771}
        };

        internal static int8[] TestData_RHS => new int8[]
        {
            new int8{x0 = 12,
					 x1 = 832987,
					 x2 = 5387343,
					 x3 = 98,
					 x4 = 42425642,
					 x5 = -1798496,
					 x6 = 978540,
                     x7 = -4853234},

            TestData_LHS[1],

            new int8{x0 = 173899955,
					 x1 = 874227,
					 x2 = -964553,
					 x3 = 18867862,
					 x4 = 266339,
					 x5 = -43552,
					 x6 = 979950,
                     x7 = -13262},
					
            new int8{x0 = 24787,
					 x1 = -963,
					 x2 = 2056740,
					 x3 = -192472,
					 x4 = -8967,
					 x5 = 264288789,
					 x6 = 185262,
					 x7 = 45683}
        };


        [Test]
        public static void Constructor_Int_Int_Int_Int_Int_Int_Int_Int()
        {
            int8 x = new int8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

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
        public static void Constructor_Int()
        {
            int8 x = new int8(TestData_LHS[0].x0);

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
        public static void Constructor_Int2_Int2_Int2_Int2()
        {
            int8 x = new int8(new int2(TestData_LHS[0].x0, TestData_LHS[0].x1), new int2(TestData_LHS[0].x2, TestData_LHS[0].x3), new int2(TestData_LHS[0].x4, TestData_LHS[0].x5), new int2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Int2_Int3_Int3()
        {
            int8 x = new int8(new int2(TestData_LHS[0].x0, TestData_LHS[0].x1), new int3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new int3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Int3_Int2_Int3()
        {
            int8 x = new int8(new int3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new int2(TestData_LHS[0].x3, TestData_LHS[0].x4), new int3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Int3_Int3_Int2()
        {
            int8 x = new int8(new int3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new int3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new int2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Int4_Int2_Int2()
        {
            int8 x = new int8(new int4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new int2(TestData_LHS[0].x4, TestData_LHS[0].x5), new int2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Int2_Int4_Int2()
        {
            int8 x = new int8(new int2(TestData_LHS[0].x0, TestData_LHS[0].x1), new int4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new int2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Int2_Int2_Int4()
        {
            int8 x = new int8(new int2(TestData_LHS[0].x0, TestData_LHS[0].x1), new int2(TestData_LHS[0].x2, TestData_LHS[0].x3), new int4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Int4_Int4()
        {
            int8 x = new int8(new int4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new int4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
                int8 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 + TestData_RHS[i].x0) & 
                          x.x1 == (int)(TestData_LHS[i].x1 + TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 + TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 + TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 + TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 + TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 + TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 + TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 - TestData_RHS[i].x0) &
                          x.x1 == (int)(TestData_LHS[i].x1 - TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 - TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 - TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 - TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 - TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 - TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 - TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 * TestData_RHS[i].x0) &
                          x.x1 == (int)(TestData_LHS[i].x1 * TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 * TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 * TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 * TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 * TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 * TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 * TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 / TestData_RHS[i].x0) &
                          x.x1 == (int)(TestData_LHS[i].x1 / TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 / TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 / TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 / TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 / TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 / TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 / TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 % TestData_RHS[i].x0) &
                          x.x1 == (int)(TestData_LHS[i].x1 % TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 % TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 % TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 % TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 % TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 % TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 % TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = -TestData_LHS[i];

                result &= x.x0 == (int)(-TestData_LHS[i].x0) &
                          x.x1 == (int)(-TestData_LHS[i].x1) &
                          x.x2 == (int)(-TestData_LHS[i].x2) &
                          x.x3 == (int)(-TestData_LHS[i].x3) &
                          x.x4 == (int)(-TestData_LHS[i].x4) &
                          x.x5 == (int)(-TestData_LHS[i].x5) &
                          x.x6 == (int)(-TestData_LHS[i].x6) &
                          x.x7 == (int)(-TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 & TestData_RHS[i].x0) &
                          x.x1 == (int)(TestData_LHS[i].x1 & TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 & TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 & TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 & TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 & TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 & TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 & TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 | TestData_RHS[i].x0) &
                          x.x1 == (int)(TestData_LHS[i].x1 | TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 | TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 | TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 | TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 | TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 | TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 | TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 == (int)(TestData_LHS[i].x0 ^ TestData_RHS[i].x0) &
                          x.x1 == (int)(TestData_LHS[i].x1 ^ TestData_RHS[i].x1) &
                          x.x2 == (int)(TestData_LHS[i].x2 ^ TestData_RHS[i].x2) &
                          x.x3 == (int)(TestData_LHS[i].x3 ^ TestData_RHS[i].x3) &
                          x.x4 == (int)(TestData_LHS[i].x4 ^ TestData_RHS[i].x4) &
                          x.x5 == (int)(TestData_LHS[i].x5 ^ TestData_RHS[i].x5) &
                          x.x6 == (int)(TestData_LHS[i].x6 ^ TestData_RHS[i].x6) &
                          x.x7 == (int)(TestData_LHS[i].x7 ^ TestData_RHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = ~TestData_LHS[i];

                result &= x.x0 == (int)(~TestData_LHS[i].x0) &
                          x.x1 == (int)(~TestData_LHS[i].x1) &
                          x.x2 == (int)(~TestData_LHS[i].x2) &
                          x.x3 == (int)(~TestData_LHS[i].x3) &
                          x.x4 == (int)(~TestData_LHS[i].x4) &
                          x.x5 == (int)(~TestData_LHS[i].x5) &
                          x.x6 == (int)(~TestData_LHS[i].x6) &
                          x.x7 == (int)(~TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    int8 x = TestData_LHS[i] << j;

                    result &= x.x0 == (int)(TestData_LHS[i].x0 << j) & 
                              x.x1 == (int)(TestData_LHS[i].x1 << j) &
                              x.x2 == (int)(TestData_LHS[i].x2 << j) &
                              x.x3 == (int)(TestData_LHS[i].x3 << j) &
                              x.x4 == (int)(TestData_LHS[i].x4 << j) &
                              x.x5 == (int)(TestData_LHS[i].x5 << j) &
                              x.x6 == (int)(TestData_LHS[i].x6 << j) &
                              x.x7 == (int)(TestData_LHS[i].x7 << j);
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
                for (int j = 0; j < 32; j++)
                {
                    int8 x = TestData_LHS[i] >> j;

                    result &= x.x0 == (int)(TestData_LHS[i].x0 >> j) &
                              x.x1 == (int)(TestData_LHS[i].x1 >> j) &
                              x.x2 == (int)(TestData_LHS[i].x2 >> j) &
                              x.x3 == (int)(TestData_LHS[i].x3 >> j) &
                              x.x4 == (int)(TestData_LHS[i].x4 >> j) &
                              x.x5 == (int)(TestData_LHS[i].x5 >> j) &
                              x.x6 == (int)(TestData_LHS[i].x6 >> j) &
                              x.x7 == (int)(TestData_LHS[i].x7 >> j);
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
        public static void ShuffleGetter()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                int4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                int4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                int4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                int4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;


                int3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                int3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                int3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                int3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                int3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                int3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;


                int2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                int2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                int2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                int2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                int2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                int2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                int2 v2_6 = TestData_LHS[i].v2_6;
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
        //        int8 v4_0 = TestData_LHS[i];
        //        v4_0.v4_0 = Int4.TestData_LHS[i];
        //        result &= v4_0.x0 == Int4.TestData_LHS[i].x;
        //        result &= v4_0.x1 == Int4.TestData_LHS[i].y;
        //        result &= v4_0.x2 == Int4.TestData_LHS[i].z;
        //        result &= v4_0.x3 == Int4.TestData_LHS[i].w;
        //        result &= v4_0.x4 == TestData_LHS[i].x4;
        //        result &= v4_0.x5 == TestData_LHS[i].x5;
        //        result &= v4_0.x6 == TestData_LHS[i].x6;
        //        result &= v4_0.x7 == TestData_LHS[i].x7;
        //
        //        int8 v4_1 = TestData_LHS[i];
        //        v4_1.v4_1 = Int4.TestData_LHS[i];
        //        result &= v4_1.x0 == TestData_LHS[i].x0;
        //        result &= v4_1.x1 == Int4.TestData_LHS[i].x;
        //        result &= v4_1.x2 == Int4.TestData_LHS[i].y;
        //        result &= v4_1.x3 == Int4.TestData_LHS[i].z;
        //        result &= v4_1.x4 == Int4.TestData_LHS[i].w;
        //        result &= v4_1.x5 == TestData_LHS[i].x5;
        //        result &= v4_1.x6 == TestData_LHS[i].x6;
        //        result &= v4_1.x7 == TestData_LHS[i].x7;
        //
        //        int8 v4_2 = TestData_LHS[i];
        //        v4_2.v4_2 = Int4.TestData_LHS[i];
        //        result &= v4_2.x0 == TestData_LHS[i].x0;
        //        result &= v4_2.x1 == TestData_LHS[i].x1;
        //        result &= v4_2.x2 == Int4.TestData_LHS[i].x;
        //        result &= v4_2.x3 == Int4.TestData_LHS[i].y;
        //        result &= v4_2.x4 == Int4.TestData_LHS[i].z;
        //        result &= v4_2.x5 == Int4.TestData_LHS[i].w;
        //        result &= v4_2.x6 == TestData_LHS[i].x6;
        //        result &= v4_2.x7 == TestData_LHS[i].x7;
        //        
        //        int8 v4_3 = TestData_LHS[i];
        //        v4_3.v4_3 = Int4.TestData_LHS[i];
        //        result &= v4_3.x0 == TestData_LHS[i].x0;
        //        result &= v4_3.x1 == TestData_LHS[i].x1;
        //        result &= v4_3.x2 == TestData_LHS[i].x2;
        //        result &= v4_3.x3 == Int4.TestData_LHS[i].x;
        //        result &= v4_3.x4 == Int4.TestData_LHS[i].y;
        //        result &= v4_3.x5 == Int4.TestData_LHS[i].z;
        //        result &= v4_3.x6 == Int4.TestData_LHS[i].w;
        //        result &= v4_3.x7 == TestData_LHS[i].x7;
        //        
        //        int8 v4_4 = TestData_LHS[i];
        //        v4_4.v4_4 = Int4.TestData_LHS[i];
        //        result &= v4_4.x0 == TestData_LHS[i].x0;
        //        result &= v4_4.x1 == TestData_LHS[i].x1;
        //        result &= v4_4.x2 == TestData_LHS[i].x2;
        //        result &= v4_4.x3 == TestData_LHS[i].x3;
        //        result &= v4_4.x4 == Int4.TestData_LHS[i].x;
        //        result &= v4_4.x5 == Int4.TestData_LHS[i].y;
        //        result &= v4_4.x6 == Int4.TestData_LHS[i].z;
        //        result &= v4_4.x7 == Int4.TestData_LHS[i].w;
        //
        //
        //        int8 v3_0 = TestData_LHS[i];
        //        v3_0.v3_0 = Int3.TestData_LHS[i];
        //        result &= v3_0.x0 == Int3.TestData_LHS[i].x;
        //        result &= v3_0.x1 == Int3.TestData_LHS[i].y;
        //        result &= v3_0.x2 == Int3.TestData_LHS[i].z;
        //        result &= v3_0.x3 == TestData_LHS[i].x3;
        //        result &= v3_0.x4 == TestData_LHS[i].x4;
        //        result &= v3_0.x5 == TestData_LHS[i].x5;
        //        result &= v3_0.x6 == TestData_LHS[i].x6;
        //        result &= v3_0.x7 == TestData_LHS[i].x7;
        //
        //        int8 v3_1 = TestData_LHS[i];
        //        v3_1.v3_1 = Int3.TestData_LHS[i];
        //        result &= v3_1.x0 == TestData_LHS[i].x0;
        //        result &= v3_1.x1 == Int3.TestData_LHS[i].x;
        //        result &= v3_1.x2 == Int3.TestData_LHS[i].y;
        //        result &= v3_1.x3 == Int3.TestData_LHS[i].z;
        //        result &= v3_1.x4 == TestData_LHS[i].x4;
        //        result &= v3_1.x5 == TestData_LHS[i].x5;
        //        result &= v3_1.x6 == TestData_LHS[i].x6;
        //        result &= v3_1.x7 == TestData_LHS[i].x7;
        //
        //        int8 v3_2 = TestData_LHS[i];
        //        v3_2.v3_2 = Int3.TestData_LHS[i];
        //        result &= v3_2.x0 == TestData_LHS[i].x0;
        //        result &= v3_2.x1 == TestData_LHS[i].x1;
        //        result &= v3_2.x2 == Int3.TestData_LHS[i].x;
        //        result &= v3_2.x3 == Int3.TestData_LHS[i].y;
        //        result &= v3_2.x4 == Int3.TestData_LHS[i].z;
        //        result &= v3_2.x5 == TestData_LHS[i].x5;
        //        result &= v3_2.x6 == TestData_LHS[i].x6;
        //        result &= v3_2.x7 == TestData_LHS[i].x7;
        //
        //        int8 v3_3 = TestData_LHS[i];
        //        v3_3.v3_3 = Int3.TestData_LHS[i];
        //        result &= v3_3.x0 == TestData_LHS[i].x0;
        //        result &= v3_3.x1 == TestData_LHS[i].x1;
        //        result &= v3_3.x2 == TestData_LHS[i].x2;
        //        result &= v3_3.x3 == Int3.TestData_LHS[i].x;
        //        result &= v3_3.x4 == Int3.TestData_LHS[i].y;
        //        result &= v3_3.x5 == Int3.TestData_LHS[i].z;
        //        result &= v3_3.x6 == TestData_LHS[i].x6;
        //        result &= v3_3.x7 == TestData_LHS[i].x7;
        //
        //        int8 v3_4 = TestData_LHS[i];
        //        v3_4.v3_4 = Int3.TestData_LHS[i];
        //        result &= v3_4.x0 == TestData_LHS[i].x0;
        //        result &= v3_4.x1 == TestData_LHS[i].x1;
        //        result &= v3_4.x2 == TestData_LHS[i].x2;
        //        result &= v3_4.x3 == TestData_LHS[i].x3;
        //        result &= v3_4.x4 == Int3.TestData_LHS[i].x;
        //        result &= v3_4.x5 == Int3.TestData_LHS[i].y;
        //        result &= v3_4.x6 == Int3.TestData_LHS[i].z;
        //        result &= v3_4.x7 == TestData_LHS[i].x7;
        //
        //        int8 v3_5 = TestData_LHS[i];
        //        v3_5.v3_5 = Int3.TestData_LHS[i];
        //        result &= v3_5.x0 == TestData_LHS[i].x0;
        //        result &= v3_5.x1 == TestData_LHS[i].x1;
        //        result &= v3_5.x2 == TestData_LHS[i].x2;
        //        result &= v3_5.x3 == TestData_LHS[i].x3;
        //        result &= v3_5.x4 == TestData_LHS[i].x4;
        //        result &= v3_5.x5 == Int3.TestData_LHS[i].x;
        //        result &= v3_5.x6 == Int3.TestData_LHS[i].y;
        //        result &= v3_5.x7 == Int3.TestData_LHS[i].z;
        //
        //
        //        int8 v2_0 = TestData_LHS[i];
        //        v2_0.v2_0 = Int2.TestData_LHS[i];
        //        result &= v2_0.x0 == Int2.TestData_LHS[i].x;
        //        result &= v2_0.x1 == Int2.TestData_LHS[i].y;
        //        result &= v2_0.x2 == TestData_LHS[i].x2;
        //        result &= v2_0.x3 == TestData_LHS[i].x3;
        //        result &= v2_0.x4 == TestData_LHS[i].x4;
        //        result &= v2_0.x5 == TestData_LHS[i].x5;
        //        result &= v2_0.x6 == TestData_LHS[i].x6;
        //        result &= v2_0.x7 == TestData_LHS[i].x7;
        //
        //        int8 v2_1 = TestData_LHS[i];
        //        v2_1.v2_1 = Int2.TestData_LHS[i];
        //        result &= v2_1.x0 == TestData_LHS[i].x0;
        //        result &= v2_1.x1 == Int2.TestData_LHS[i].x;
        //        result &= v2_1.x2 == Int2.TestData_LHS[i].y;
        //        result &= v2_1.x3 == TestData_LHS[i].x3;
        //        result &= v2_1.x4 == TestData_LHS[i].x4;
        //        result &= v2_1.x5 == TestData_LHS[i].x5;
        //        result &= v2_1.x6 == TestData_LHS[i].x6;
        //        result &= v2_1.x7 == TestData_LHS[i].x7;
        //
        //        int8 v2_2 = TestData_LHS[i];
        //        v2_2.v2_2 = Int2.TestData_LHS[i];
        //        result &= v2_2.x0 == TestData_LHS[i].x0;
        //        result &= v2_2.x1 == TestData_LHS[i].x1;
        //        result &= v2_2.x2 == Int2.TestData_LHS[i].x;
        //        result &= v2_2.x3 == Int2.TestData_LHS[i].y;
        //        result &= v2_2.x4 == TestData_LHS[i].x4;
        //        result &= v2_2.x5 == TestData_LHS[i].x5;
        //        result &= v2_2.x6 == TestData_LHS[i].x6;
        //        result &= v2_2.x7 == TestData_LHS[i].x7;
        //
        //        int8 v2_3 = TestData_LHS[i];
        //        v2_3.v2_3 = Int2.TestData_LHS[i];
        //        result &= v2_3.x0 == TestData_LHS[i].x0;
        //        result &= v2_3.x1 == TestData_LHS[i].x1;
        //        result &= v2_3.x2 == TestData_LHS[i].x2;
        //        result &= v2_3.x3 == Int2.TestData_LHS[i].x;
        //        result &= v2_3.x4 == Int2.TestData_LHS[i].y;
        //        result &= v2_3.x5 == TestData_LHS[i].x5;
        //        result &= v2_3.x6 == TestData_LHS[i].x6;
        //        result &= v2_3.x7 == TestData_LHS[i].x7;
        //
        //        int8 v2_4 = TestData_LHS[i];
        //        v2_4.v2_4 = Int2.TestData_LHS[i];
        //        result &= v2_4.x0 == TestData_LHS[i].x0;
        //        result &= v2_4.x1 == TestData_LHS[i].x1;
        //        result &= v2_4.x2 == TestData_LHS[i].x2;
        //        result &= v2_4.x3 == TestData_LHS[i].x3;
        //        result &= v2_4.x4 == Int2.TestData_LHS[i].x;
        //        result &= v2_4.x5 == Int2.TestData_LHS[i].y;
        //        result &= v2_4.x6 == TestData_LHS[i].x6;
        //        result &= v2_4.x7 == TestData_LHS[i].x7;
        //
        //        int8 v2_5 = TestData_LHS[i];
        //        v2_5.v2_5 = Int2.TestData_LHS[i];
        //        result &= v2_5.x0 == TestData_LHS[i].x0;
        //        result &= v2_5.x1 == TestData_LHS[i].x1;
        //        result &= v2_5.x2 == TestData_LHS[i].x2;
        //        result &= v2_5.x3 == TestData_LHS[i].x3;
        //        result &= v2_5.x4 == TestData_LHS[i].x4;
        //        result &= v2_5.x5 == Int2.TestData_LHS[i].x;
        //        result &= v2_5.x6 == Int2.TestData_LHS[i].y;
        //        result &= v2_5.x7 == TestData_LHS[i].x7;
        //
        //        int8 v2_6 = TestData_LHS[i];
        //        v2_6.v2_6 = Int2.TestData_LHS[i];
        //        result &= v2_6.x0 == TestData_LHS[i].x0;
        //        result &= v2_6.x1 == TestData_LHS[i].x1;
        //        result &= v2_6.x2 == TestData_LHS[i].x2;
        //        result &= v2_6.x3 == TestData_LHS[i].x3;
        //        result &= v2_6.x4 == TestData_LHS[i].x4;
        //        result &= v2_6.x5 == TestData_LHS[i].x5;
        //        result &= v2_6.x6 == Int2.TestData_LHS[i].x;
        //        result &= v2_6.x7 == Int2.TestData_LHS[i].y;
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

                result &= x.SInt0 == TestData_LHS[i].x0 &
                          x.SInt1 == TestData_LHS[i].x1 &
                          x.SInt2 == TestData_LHS[i].x2 &
                          x.SInt3 == TestData_LHS[i].x3 &
                          x.SInt4 == TestData_LHS[i].x4 &
                          x.SInt5 == TestData_LHS[i].x5 &
                          x.SInt6 == TestData_LHS[i].x6 &
                          x.SInt7 == TestData_LHS[i].x7;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_FromV256()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = TestData_LHS[i];
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