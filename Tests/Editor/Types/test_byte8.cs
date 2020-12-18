using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class Byte8
    {
        internal const int NUM_TESTS = 4;


        internal static byte8[] TestData_LHS => new byte8[]
        {
            new byte8{ x0 = 183,
	 	               x1 = 55,
	 	               x2 = 99,
	 	               x3 = 76,
	 	               x4 = 65,
	 	               x5 = 1,
	 	               x6 = 211,
	 	               x7 = 35},
	 	
            new byte8{ x0 = 22,
	 	               x1 = 12,
	 	               x2 = 16,
	 	               x3 = 211,
	 	               x4 = 99,
	 	               x5 = 80,
	 	               x6 = 54,
	 	               x7 = 39},
	 	       
            new byte8{ x0 = 87,
	 	               x1 = byte.MaxValue,
	 	               x2 = 17,
	 	               x3 = 21,
	 	               x4 = 0,
	 	               x5 = 47,
	 	               x6 = 32,
	 	               x7 = 156},
	 	
            new byte8{ x0 = byte.MinValue,
	 	               x1 = 13,
	 	               x2 = 111,
	 	               x3 = 66,
	 	               x4 = 199,
	 	               x5 = 39,
	 	               x6 = 250,
	 	               x7 = 121}
        };

        internal static byte8[] TestData_RHS => new byte8[]
        {
            new byte8{ x0 = 12,
	 	               x1 = 8,
	 	               x2 = 53,
	 	               x3 = 98,
	 	               x4 = 2,
	 	               x5 = 173,
	 	               x6 = 97,
	 	               x7 = 44},

            TestData_LHS[1],

            new byte8{ x0 = 17,
	 	               x1 = 87,
	 	               x2 = 9,
	 	               x3 = 182,
	 	               x4 = 239,
	 	               x5 = 45,
	 	               x6 = 90,
	 	               x7 = 162},
	 	
            new byte8{ x0 = 2,
	 	               x1 = 9,
	 	               x2 = 200,
	 	               x3 = 192,
	 	               x4 = 87,
	 	               x5 = 219,
	 	               x6 = 182,
	 	               x7 = 43}
        };


        [Test]
        public static void Constructor_Byte_Byte_Byte_Byte_Byte_Byte_Byte_Byte()
        {
            byte8 x = new byte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7);

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
        public static void Constructor_Byte()
        {
            byte8 x = new byte8(TestData_LHS[0].x0);

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
        public static void Constructor_Byte2_Byte2_Byte2_Byte2()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte2(TestData_LHS[0].x2, TestData_LHS[0].x3), new byte2(TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Byte2_Byte3_Byte3()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte3(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4), new byte3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Byte3_Byte2_Byte3()
        {
            byte8 x = new byte8(new byte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new byte2(TestData_LHS[0].x3, TestData_LHS[0].x4), new byte3(TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Byte3_Byte3_Byte2()
        {
            byte8 x = new byte8(new byte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new byte3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Byte4_Byte2_Byte2()
        {
            byte8 x = new byte8(new byte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new byte2(TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Byte2_Byte4_Byte2()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte4(TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new byte2(TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Byte2_Byte2_Byte4()
        {
            byte8 x = new byte8(new byte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new byte2(TestData_LHS[0].x2, TestData_LHS[0].x3), new byte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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
        public static void Constructor_Byte4_Byte4()
        {
            byte8 x = new byte8(new byte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new byte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7));

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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Subtract()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Multiply()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Divide()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Remainder()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void AND()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void OR()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void XOR()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NOT()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    byte8 x = TestData_LHS[i] << j;

                    result &= x.x0 == (byte)(TestData_LHS[i].x0 << j) & 
                              x.x1 == (byte)(TestData_LHS[i].x1 << j) &
                              x.x2 == (byte)(TestData_LHS[i].x2 << j) &
                              x.x3 == (byte)(TestData_LHS[i].x3 << j) &
                              x.x4 == (byte)(TestData_LHS[i].x4 << j) &
                              x.x5 == (byte)(TestData_LHS[i].x5 << j) &
                              x.x6 == (byte)(TestData_LHS[i].x6 << j) &
                              x.x7 == (byte)(TestData_LHS[i].x7 << j);
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
                for (int j = 0; j < 8; j++)
                {
                    byte8 x = TestData_LHS[i] >> j;

                    result &= x.x0 == (byte)(TestData_LHS[i].x0 >> j) &
                              x.x1 == (byte)(TestData_LHS[i].x1 >> j) &
                              x.x2 == (byte)(TestData_LHS[i].x2 >> j) &
                              x.x3 == (byte)(TestData_LHS[i].x3 >> j) &
                              x.x4 == (byte)(TestData_LHS[i].x4 >> j) &
                              x.x5 == (byte)(TestData_LHS[i].x5 >> j) &
                              x.x6 == (byte)(TestData_LHS[i].x6 >> j) &
                              x.x7 == (byte)(TestData_LHS[i].x7 >> j);
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


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Cast_ToV128()
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_FromV128()
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

            Assert.AreEqual(true, result);
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

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToUShort()
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