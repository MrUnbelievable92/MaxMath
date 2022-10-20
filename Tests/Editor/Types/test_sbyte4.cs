using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class __sbyte4
    {
        internal const int NUM_TESTS = 4;


        internal static sbyte4[] TestData_LHS => new sbyte4[]
        {
            new sbyte4{x = -43,
					   y = -55,
					   z = 99,
                       w = 76},
					  
            new sbyte4{x = 22,
					   y = 12,
					   z = 16,
					   w = -11},
					         
            new sbyte4{x = 47,
					   y = sbyte.MaxValue,
					   z = -17,
                       w = 21},
					  
            new sbyte4{x = sbyte.MinValue,
					   y = 13,
					   z = -111,
                       w = 66}
        };

        internal static sbyte4[] TestData_RHS => new sbyte4[]
        {
            new sbyte4{x = 12,
					   y = 4,
					   z = 53,
                       w = 98},

            TestData_LHS[1],

            new sbyte4{x = -17,
					   y = 47,
					   z = 9,
                       w = -42},
					  
            new sbyte4{x = 2,
					   y = 9,
					   z = -80,
					   w = -92}
        };


        [Test]
        public static void Constructor___sbyte___sbyte___sbyte_SByte()
        {
            sbyte4 x = new sbyte4(TestData_LHS[0].x, TestData_LHS[0].y, TestData_LHS[0].z, TestData_LHS[0].w);

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z &
                   x.w == TestData_LHS[0].w, true);
        }

        [Test]
        public static void Constructor_SByte()
        {
            sbyte4 x = new sbyte4(TestData_LHS[0].x);

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].x &
                   x.z == TestData_LHS[0].x &
                   x.w == TestData_LHS[0].x, true);
        }

        [Test]
        public static void Constructor___sbyte2___sbyte_SByte()
        {
            sbyte4 x = new sbyte4(new sbyte2(TestData_LHS[0].x, TestData_LHS[0].y), TestData_LHS[0].z, TestData_LHS[0].w);

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z &
                   x.w == TestData_LHS[0].w, true);
        }

        [Test]
        public static void Constructor___sbyte___sbyte2_SByte()
        {
            sbyte4 x = new sbyte4(TestData_LHS[0].x, new sbyte2(TestData_LHS[0].y, TestData_LHS[0].z), TestData_LHS[0].w);

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z &
                   x.w == TestData_LHS[0].w, true);
        }

        [Test]
        public static void Constructor___sbyte___sbyte_SByte2()
        {
            sbyte4 x = new sbyte4(TestData_LHS[0].x, TestData_LHS[0].y, new sbyte2(TestData_LHS[0].z, TestData_LHS[0].w));

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z &
                   x.w == TestData_LHS[0].w, true);
        }

        [Test]
        public static void Constructor___sbyte2_SByte2()
        {
            sbyte4 x = new sbyte4(new sbyte2(TestData_LHS[0].x, TestData_LHS[0].y), new sbyte2(TestData_LHS[0].z, TestData_LHS[0].w));

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z &
                   x.w == TestData_LHS[0].w, true);
        }

        [Test]
        public static void Constructor___sbyte3_SByte()
        {
            sbyte4 x = new sbyte4(new sbyte3(TestData_LHS[0].x, TestData_LHS[0].y, TestData_LHS[0].z), TestData_LHS[0].w);

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z &
                   x.w == TestData_LHS[0].w, true);
        }

        [Test]
        public static void Constructor___sbyte_SByte3()
        {
            sbyte4 x = new sbyte4(TestData_LHS[0].x, new sbyte3(TestData_LHS[0].y, TestData_LHS[0].z, TestData_LHS[0].w));

            Assert.AreEqual(x.x == TestData_LHS[0].x &
                   x.y == TestData_LHS[0].y &
                   x.z == TestData_LHS[0].z &
                   x.w == TestData_LHS[0].w, true);
        }


        [Test]
        public static void Indexer()
        {
            Assert.AreEqual(TestData_LHS[0][0] == TestData_LHS[0].x &
                   TestData_LHS[0][1] == TestData_LHS[0].y &
                   TestData_LHS[0][2] == TestData_LHS[0].z &
                   TestData_LHS[0][3] == TestData_LHS[0].w, true);

            for (int i = 0; i < 4; i++)
            {
                sbyte4 x = TestData_LHS[0];

                x[i] = 0;
                Assert.AreEqual(x[i], 0);

                for (int j = 0; j < i; j++)
                {
                    Assert.AreEqual(x[j], TestData_LHS[0][j]);
                }

                for (int j = i + 1; j < 4; j++)
                {
                    Assert.AreEqual(x[j], TestData_LHS[0][j]);
                }
            }
        }


        [Test]
        public static void Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x + TestData_RHS[i].x) & 
                          x.y == (sbyte)(TestData_LHS[i].y + TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z + TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w + TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x - TestData_RHS[i].x) & 
                          x.y == (sbyte)(TestData_LHS[i].y - TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z - TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w - TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }
        
        [Test]
        public static void CONSTMultiply()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                Assert.AreEqual(TestData_LHS[0] * (sbyte)i, new sbyte4((sbyte)(TestData_LHS[0].x * (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].y * (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].z * (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].w * (sbyte)i)));
            }
        }

        [Test]
        public static void CONSTDivide()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                Assert.AreEqual(TestData_LHS[0] / (sbyte)i, new sbyte4((sbyte)(TestData_LHS[0].x / (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].y / (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].z / (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].w / (sbyte)i)));
            }
        }

        [Test]
        public static void CONSTRem()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                if (i == 0)
                {
                    continue;
                }

                Assert.AreEqual(TestData_LHS[0] % (sbyte)i, new sbyte4((sbyte)(TestData_LHS[0].x % (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].y % (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].z % (sbyte)i), 
                                                                     (sbyte)(TestData_LHS[0].w % (sbyte)i)));
            }
        }

        [Test]
        public static void Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x * TestData_RHS[i].x) & 
                          x.y == (sbyte)(TestData_LHS[i].y * TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z * TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w * TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x / TestData_RHS[i].x) &
                          x.y == (sbyte)(TestData_LHS[i].y / TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z / TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w / TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x % TestData_RHS[i].x) & 
                          x.y == (sbyte)(TestData_LHS[i].y % TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z % TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w % TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = -TestData_LHS[i];

                result &= x.x == (sbyte)(-TestData_LHS[i].x) &
                          x.y == (sbyte)(-TestData_LHS[i].y) &
                          x.z == (sbyte)(-TestData_LHS[i].z) &
                          x.w == (sbyte)(-TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x & TestData_RHS[i].x) &
                          x.y == (sbyte)(TestData_LHS[i].y & TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z & TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w & TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x | TestData_RHS[i].x) & 
                          x.y == (sbyte)(TestData_LHS[i].y | TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z | TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w | TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x == (sbyte)(TestData_LHS[i].x ^ TestData_RHS[i].x) & 
                          x.y == (sbyte)(TestData_LHS[i].y ^ TestData_RHS[i].y) &
                          x.z == (sbyte)(TestData_LHS[i].z ^ TestData_RHS[i].z) &
                          x.w == (sbyte)(TestData_LHS[i].w ^ TestData_RHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = ~TestData_LHS[i];

                result &= x.x == (sbyte)(~TestData_LHS[i].x) & 
                          x.y == (sbyte)(~TestData_LHS[i].y) &
                          x.z == (sbyte)(~TestData_LHS[i].z) &
                          x.w == (sbyte)(~TestData_LHS[i].w);
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
                    sbyte4 x = TestData_LHS[i] << j;

                    result &= x.x == (sbyte)(TestData_LHS[i].x << j) & 
                              x.y == (sbyte)(TestData_LHS[i].y << j) &
                              x.z == (sbyte)(TestData_LHS[i].z << j) &
                              x.w == (sbyte)(TestData_LHS[i].w << j);
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
                    sbyte4 x = TestData_LHS[i] >> j;

                    result &= x.x == (sbyte)(TestData_LHS[i].x >> j) &
                              x.y == (sbyte)(TestData_LHS[i].y >> j) &
                              x.z == (sbyte)(TestData_LHS[i].z >> j) &
                              x.w == (sbyte)(TestData_LHS[i].w >> j);
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
                bool4 x = TestData_LHS[i] == TestData_RHS[i];

                result &= x.Equals(new bool4(TestData_LHS[i].x == TestData_RHS[i].x,
                                             TestData_LHS[i].y == TestData_RHS[i].y,
                                             TestData_LHS[i].z == TestData_RHS[i].z,
                                             TestData_LHS[i].w == TestData_RHS[i].w));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.Equals(new bool4(TestData_LHS[i].x < TestData_RHS[i].x,
                                             TestData_LHS[i].y < TestData_RHS[i].y,
                                             TestData_LHS[i].z < TestData_RHS[i].z,
                                             TestData_LHS[i].w < TestData_RHS[i].w));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = TestData_LHS[i] > TestData_RHS[i];

                result &= x.Equals(new bool4(TestData_LHS[i].x > TestData_RHS[i].x,
                                             TestData_LHS[i].y > TestData_RHS[i].y,
                                             TestData_LHS[i].z > TestData_RHS[i].z,
                                             TestData_LHS[i].w > TestData_RHS[i].w));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NotEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = TestData_LHS[i] != TestData_RHS[i];

                result &= x.Equals(new bool4(TestData_LHS[i].x != TestData_RHS[i].x,
                                             TestData_LHS[i].y != TestData_RHS[i].y,
                                             TestData_LHS[i].z != TestData_RHS[i].z,
                                             TestData_LHS[i].w != TestData_RHS[i].w));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = TestData_LHS[i] <= TestData_RHS[i];

                result &= x.Equals(new bool4(TestData_LHS[i].x <= TestData_RHS[i].x,
                                             TestData_LHS[i].y <= TestData_RHS[i].y,
                                             TestData_LHS[i].z <= TestData_RHS[i].z,
                                             TestData_LHS[i].w <= TestData_RHS[i].w));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = TestData_LHS[i] >= TestData_RHS[i];

                result &= x.Equals(new bool4(TestData_LHS[i].x >= TestData_RHS[i].x,
                                             TestData_LHS[i].y >= TestData_RHS[i].y,
                                             TestData_LHS[i].z >= TestData_RHS[i].z,
                                             TestData_LHS[i].w >= TestData_RHS[i].w));
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

                result &= x == math.all(new bool4(TestData_LHS[i].x == TestData_RHS[i].x,
                                                  TestData_LHS[i].y == TestData_RHS[i].y,
                                                  TestData_LHS[i].z == TestData_RHS[i].z,
                                                  TestData_LHS[i].w == TestData_RHS[i].w));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ShuffleGetter()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 xxxx = TestData_LHS[i].xxxx;
                result &= xxxx.x == TestData_LHS[i].x &
                          xxxx.y == TestData_LHS[i].x &
                          xxxx.z == TestData_LHS[i].x &
                          xxxx.w == TestData_LHS[i].x;

                sbyte4 xxxy = TestData_LHS[i].xxxy;
                result &= xxxy.x == TestData_LHS[i].x &
                          xxxy.y == TestData_LHS[i].x &
                          xxxy.z == TestData_LHS[i].x &
                          xxxy.w == TestData_LHS[i].y;

                sbyte4 xxxz = TestData_LHS[i].xxxz;
                result &= xxxz.x == TestData_LHS[i].x &
                          xxxz.y == TestData_LHS[i].x &
                          xxxz.z == TestData_LHS[i].x &
                          xxxz.w == TestData_LHS[i].z;

                sbyte4 xxxw = TestData_LHS[i].xxxw;
                result &= xxxw.x == TestData_LHS[i].x &
                          xxxw.y == TestData_LHS[i].x &
                          xxxw.z == TestData_LHS[i].x &
                          xxxw.w == TestData_LHS[i].w;

                sbyte4 xxyx = TestData_LHS[i].xxyx;
                result &= xxyx.x == TestData_LHS[i].x &
                          xxyx.y == TestData_LHS[i].x &
                          xxyx.z == TestData_LHS[i].y &
                          xxyx.w == TestData_LHS[i].x;

                sbyte4 xxyy = TestData_LHS[i].xxyy;
                result &= xxyy.x == TestData_LHS[i].x &
                          xxyy.y == TestData_LHS[i].x &
                          xxyy.z == TestData_LHS[i].y &
                          xxyy.w == TestData_LHS[i].y;

                sbyte4 xxyz = TestData_LHS[i].xxyz;
                result &= xxyz.x == TestData_LHS[i].x &
                          xxyz.y == TestData_LHS[i].x &
                          xxyz.z == TestData_LHS[i].y &
                          xxyz.w == TestData_LHS[i].z;

                sbyte4 xxyw = TestData_LHS[i].xxyw;
                result &= xxyw.x == TestData_LHS[i].x &
                          xxyw.y == TestData_LHS[i].x &
                          xxyw.z == TestData_LHS[i].y &
                          xxyw.w == TestData_LHS[i].w;

                sbyte4 xxzx = TestData_LHS[i].xxzx;
                result &= xxzx.x == TestData_LHS[i].x &
                          xxzx.y == TestData_LHS[i].x &
                          xxzx.z == TestData_LHS[i].z &
                          xxzx.w == TestData_LHS[i].x;

                sbyte4 xxzy = TestData_LHS[i].xxzy;
                result &= xxzy.x == TestData_LHS[i].x &
                          xxzy.y == TestData_LHS[i].x &
                          xxzy.z == TestData_LHS[i].z &
                          xxzy.w == TestData_LHS[i].y;

                sbyte4 xxzz = TestData_LHS[i].xxzz;
                result &= xxzz.x == TestData_LHS[i].x &
                          xxzz.y == TestData_LHS[i].x &
                          xxzz.z == TestData_LHS[i].z &
                          xxzz.w == TestData_LHS[i].z;

                sbyte4 xxzw = TestData_LHS[i].xxzw;
                result &= xxzw.x == TestData_LHS[i].x &
                          xxzw.y == TestData_LHS[i].x &
                          xxzw.z == TestData_LHS[i].z &
                          xxzw.w == TestData_LHS[i].w;

                sbyte4 xxwx = TestData_LHS[i].xxwx;
                result &= xxwx.x == TestData_LHS[i].x &
                          xxwx.y == TestData_LHS[i].x &
                          xxwx.z == TestData_LHS[i].w &
                          xxwx.w == TestData_LHS[i].x;

                sbyte4 xxwy = TestData_LHS[i].xxwy;
                result &= xxwy.x == TestData_LHS[i].x &
                          xxwy.y == TestData_LHS[i].x &
                          xxwy.z == TestData_LHS[i].w &
                          xxwy.w == TestData_LHS[i].y;

                sbyte4 xxwz = TestData_LHS[i].xxwz;
                result &= xxwz.x == TestData_LHS[i].x &
                          xxwz.y == TestData_LHS[i].x &
                          xxwz.z == TestData_LHS[i].w &
                          xxwz.w == TestData_LHS[i].z;

                sbyte4 xxww = TestData_LHS[i].xxww;
                result &= xxww.x == TestData_LHS[i].x &
                          xxww.y == TestData_LHS[i].x &
                          xxww.z == TestData_LHS[i].w &
                          xxww.w == TestData_LHS[i].w;

                sbyte4 xyxx = TestData_LHS[i].xyxx;
                result &= xyxx.x == TestData_LHS[i].x &
                          xyxx.y == TestData_LHS[i].y &
                          xyxx.z == TestData_LHS[i].x &
                          xyxx.w == TestData_LHS[i].x;

                sbyte4 xyxy = TestData_LHS[i].xyxy;
                result &= xyxy.x == TestData_LHS[i].x &
                          xyxy.y == TestData_LHS[i].y &
                          xyxy.z == TestData_LHS[i].x &
                          xyxy.w == TestData_LHS[i].y;

                sbyte4 xyxz = TestData_LHS[i].xyxz;
                result &= xyxz.x == TestData_LHS[i].x &
                          xyxz.y == TestData_LHS[i].y &
                          xyxz.z == TestData_LHS[i].x &
                          xyxz.w == TestData_LHS[i].z;

                sbyte4 xyxw = TestData_LHS[i].xyxw;
                result &= xyxw.x == TestData_LHS[i].x &
                          xyxw.y == TestData_LHS[i].y &
                          xyxw.z == TestData_LHS[i].x &
                          xyxw.w == TestData_LHS[i].w;

                sbyte4 xyyx = TestData_LHS[i].xyyx;
                result &= xyyx.x == TestData_LHS[i].x &
                          xyyx.y == TestData_LHS[i].y &
                          xyyx.z == TestData_LHS[i].y &
                          xyyx.w == TestData_LHS[i].x;

                sbyte4 xyyy = TestData_LHS[i].xyyy;
                result &= xyyy.x == TestData_LHS[i].x &
                          xyyy.y == TestData_LHS[i].y &
                          xyyy.z == TestData_LHS[i].y &
                          xyyy.w == TestData_LHS[i].y;

                sbyte4 xyyz = TestData_LHS[i].xyyz;
                result &= xyyz.x == TestData_LHS[i].x &
                          xyyz.y == TestData_LHS[i].y &
                          xyyz.z == TestData_LHS[i].y &
                          xyyz.w == TestData_LHS[i].z;

                sbyte4 xyyw = TestData_LHS[i].xyyw;
                result &= xyyw.x == TestData_LHS[i].x &
                          xyyw.y == TestData_LHS[i].y &
                          xyyw.z == TestData_LHS[i].y &
                          xyyw.w == TestData_LHS[i].w;

                sbyte4 xyzx = TestData_LHS[i].xyzx;
                result &= xyzx.x == TestData_LHS[i].x &
                          xyzx.y == TestData_LHS[i].y &
                          xyzx.z == TestData_LHS[i].z &
                          xyzx.w == TestData_LHS[i].x;

                sbyte4 xyzy = TestData_LHS[i].xyzy;
                result &= xyzy.x == TestData_LHS[i].x &
                          xyzy.y == TestData_LHS[i].y &
                          xyzy.z == TestData_LHS[i].z &
                          xyzy.w == TestData_LHS[i].y;

                sbyte4 xyzz = TestData_LHS[i].xyzz;
                result &= xyzz.x == TestData_LHS[i].x &
                          xyzz.y == TestData_LHS[i].y &
                          xyzz.z == TestData_LHS[i].z &
                          xyzz.w == TestData_LHS[i].z;

                sbyte4 xywx = TestData_LHS[i].xywx;
                result &= xywx.x == TestData_LHS[i].x &
                          xywx.y == TestData_LHS[i].y &
                          xywx.z == TestData_LHS[i].w &
                          xywx.w == TestData_LHS[i].x;

                sbyte4 xywy = TestData_LHS[i].xywy;
                result &= xywy.x == TestData_LHS[i].x &
                          xywy.y == TestData_LHS[i].y &
                          xywy.z == TestData_LHS[i].w &
                          xywy.w == TestData_LHS[i].y;

                sbyte4 xywz = TestData_LHS[i].xywz;
                result &= xywz.x == TestData_LHS[i].x &
                          xywz.y == TestData_LHS[i].y &
                          xywz.z == TestData_LHS[i].w &
                          xywz.w == TestData_LHS[i].z;

                sbyte4 xyww = TestData_LHS[i].xyww;
                result &= xyww.x == TestData_LHS[i].x &
                          xyww.y == TestData_LHS[i].y &
                          xyww.z == TestData_LHS[i].w &
                          xyww.w == TestData_LHS[i].w;

                sbyte4 xzxx = TestData_LHS[i].xzxx;
                result &= xzxx.x == TestData_LHS[i].x &
                          xzxx.y == TestData_LHS[i].z &
                          xzxx.z == TestData_LHS[i].x &
                          xzxx.w == TestData_LHS[i].x;

                sbyte4 xzxy = TestData_LHS[i].xzxy;
                result &= xzxy.x == TestData_LHS[i].x &
                          xzxy.y == TestData_LHS[i].z &
                          xzxy.z == TestData_LHS[i].x &
                          xzxy.w == TestData_LHS[i].y;

                sbyte4 xzxz = TestData_LHS[i].xzxz;
                result &= xzxz.x == TestData_LHS[i].x &
                          xzxz.y == TestData_LHS[i].z &
                          xzxz.z == TestData_LHS[i].x &
                          xzxz.w == TestData_LHS[i].z;

                sbyte4 xzxw = TestData_LHS[i].xzxw;
                result &= xzxw.x == TestData_LHS[i].x &
                          xzxw.y == TestData_LHS[i].z &
                          xzxw.z == TestData_LHS[i].x &
                          xzxw.w == TestData_LHS[i].w;

                sbyte4 xzyx = TestData_LHS[i].xzyx;
                result &= xzyx.x == TestData_LHS[i].x &
                          xzyx.y == TestData_LHS[i].z &
                          xzyx.z == TestData_LHS[i].y &
                          xzyx.w == TestData_LHS[i].x;

                sbyte4 xzyy = TestData_LHS[i].xzyy;
                result &= xzyy.x == TestData_LHS[i].x &
                          xzyy.y == TestData_LHS[i].z &
                          xzyy.z == TestData_LHS[i].y &
                          xzyy.w == TestData_LHS[i].y;

                sbyte4 xzyz = TestData_LHS[i].xzyz;
                result &= xzyz.x == TestData_LHS[i].x &
                          xzyz.y == TestData_LHS[i].z &
                          xzyz.z == TestData_LHS[i].y &
                          xzyz.w == TestData_LHS[i].z;

                sbyte4 xzyw = TestData_LHS[i].xzyw;
                result &= xzyw.x == TestData_LHS[i].x &
                          xzyw.y == TestData_LHS[i].z &
                          xzyw.z == TestData_LHS[i].y &
                          xzyw.w == TestData_LHS[i].w;

                sbyte4 xzzx = TestData_LHS[i].xzzx;
                result &= xzzx.x == TestData_LHS[i].x &
                          xzzx.y == TestData_LHS[i].z &
                          xzzx.z == TestData_LHS[i].z &
                          xzzx.w == TestData_LHS[i].x;

                sbyte4 xzzy = TestData_LHS[i].xzzy;
                result &= xzzy.x == TestData_LHS[i].x &
                          xzzy.y == TestData_LHS[i].z &
                          xzzy.z == TestData_LHS[i].z &
                          xzzy.w == TestData_LHS[i].y;

                sbyte4 xzzz = TestData_LHS[i].xzzz;
                result &= xzzz.x == TestData_LHS[i].x &
                          xzzz.y == TestData_LHS[i].z &
                          xzzz.z == TestData_LHS[i].z &
                          xzzz.w == TestData_LHS[i].z;

                sbyte4 xzzw = TestData_LHS[i].xzzw;
                result &= xzzw.x == TestData_LHS[i].x &
                          xzzw.y == TestData_LHS[i].z &
                          xzzw.z == TestData_LHS[i].z &
                          xzzw.w == TestData_LHS[i].w;

                sbyte4 xzwx = TestData_LHS[i].xzwx;
                result &= xzwx.x == TestData_LHS[i].x &
                          xzwx.y == TestData_LHS[i].z &
                          xzwx.z == TestData_LHS[i].w &
                          xzwx.w == TestData_LHS[i].x;

                sbyte4 xzwy = TestData_LHS[i].xzwy;
                result &= xzwy.x == TestData_LHS[i].x &
                          xzwy.y == TestData_LHS[i].z &
                          xzwy.z == TestData_LHS[i].w &
                          xzwy.w == TestData_LHS[i].y;

                sbyte4 xzwz = TestData_LHS[i].xzwz;
                result &= xzwz.x == TestData_LHS[i].x &
                          xzwz.y == TestData_LHS[i].z &
                          xzwz.z == TestData_LHS[i].w &
                          xzwz.w == TestData_LHS[i].z;

                sbyte4 xzww = TestData_LHS[i].xzww;
                result &= xzww.x == TestData_LHS[i].x &
                          xzww.y == TestData_LHS[i].z &
                          xzww.z == TestData_LHS[i].w &
                          xzww.w == TestData_LHS[i].w;

                sbyte4 xwxx = TestData_LHS[i].xwxx;
                result &= xwxx.x == TestData_LHS[i].x &
                          xwxx.y == TestData_LHS[i].w &
                          xwxx.z == TestData_LHS[i].x &
                          xwxx.w == TestData_LHS[i].x;

                sbyte4 xwxy = TestData_LHS[i].xwxy;
                result &= xwxy.x == TestData_LHS[i].x &
                          xwxy.y == TestData_LHS[i].w &
                          xwxy.z == TestData_LHS[i].x &
                          xwxy.w == TestData_LHS[i].y;

                sbyte4 xwxz = TestData_LHS[i].xwxz;
                result &= xwxz.x == TestData_LHS[i].x &
                          xwxz.y == TestData_LHS[i].w &
                          xwxz.z == TestData_LHS[i].x &
                          xwxz.w == TestData_LHS[i].z;

                sbyte4 xwxw = TestData_LHS[i].xwxw;
                result &= xwxw.x == TestData_LHS[i].x &
                          xwxw.y == TestData_LHS[i].w &
                          xwxw.z == TestData_LHS[i].x &
                          xwxw.w == TestData_LHS[i].w;

                sbyte4 xwyx = TestData_LHS[i].xwyx;
                result &= xwyx.x == TestData_LHS[i].x &
                          xwyx.y == TestData_LHS[i].w &
                          xwyx.z == TestData_LHS[i].y &
                          xwyx.w == TestData_LHS[i].x;

                sbyte4 xwyy = TestData_LHS[i].xwyy;
                result &= xwyy.x == TestData_LHS[i].x &
                          xwyy.y == TestData_LHS[i].w &
                          xwyy.z == TestData_LHS[i].y &
                          xwyy.w == TestData_LHS[i].y;

                sbyte4 xwyz = TestData_LHS[i].xwyz;
                result &= xwyz.x == TestData_LHS[i].x &
                          xwyz.y == TestData_LHS[i].w &
                          xwyz.z == TestData_LHS[i].y &
                          xwyz.w == TestData_LHS[i].z;

                sbyte4 xwyw = TestData_LHS[i].xwyw;
                result &= xwyw.x == TestData_LHS[i].x &
                          xwyw.y == TestData_LHS[i].w &
                          xwyw.z == TestData_LHS[i].y &
                          xwyw.w == TestData_LHS[i].w;

                sbyte4 xwzx = TestData_LHS[i].xwzx;
                result &= xwzx.x == TestData_LHS[i].x &
                          xwzx.y == TestData_LHS[i].w &
                          xwzx.z == TestData_LHS[i].z &
                          xwzx.w == TestData_LHS[i].x;

                sbyte4 xwzy = TestData_LHS[i].xwzy;
                result &= xwzy.x == TestData_LHS[i].x &
                          xwzy.y == TestData_LHS[i].w &
                          xwzy.z == TestData_LHS[i].z &
                          xwzy.w == TestData_LHS[i].y;

                sbyte4 xwzz = TestData_LHS[i].xwzz;
                result &= xwzz.x == TestData_LHS[i].x &
                          xwzz.y == TestData_LHS[i].w &
                          xwzz.z == TestData_LHS[i].z &
                          xwzz.w == TestData_LHS[i].z;

                sbyte4 xwzw = TestData_LHS[i].xwzw;
                result &= xwzw.x == TestData_LHS[i].x &
                          xwzw.y == TestData_LHS[i].w &
                          xwzw.z == TestData_LHS[i].z &
                          xwzw.w == TestData_LHS[i].w;

                sbyte4 xwwx = TestData_LHS[i].xwwx;
                result &= xwwx.x == TestData_LHS[i].x &
                          xwwx.y == TestData_LHS[i].w &
                          xwwx.z == TestData_LHS[i].w &
                          xwwx.w == TestData_LHS[i].x;

                sbyte4 xwwy = TestData_LHS[i].xwwy;
                result &= xwwy.x == TestData_LHS[i].x &
                          xwwy.y == TestData_LHS[i].w &
                          xwwy.z == TestData_LHS[i].w &
                          xwwy.w == TestData_LHS[i].y;

                sbyte4 xwwz = TestData_LHS[i].xwwz;
                result &= xwwz.x == TestData_LHS[i].x &
                          xwwz.y == TestData_LHS[i].w &
                          xwwz.z == TestData_LHS[i].w &
                          xwwz.w == TestData_LHS[i].z;

                sbyte4 xwww = TestData_LHS[i].xwww;
                result &= xwww.x == TestData_LHS[i].x &
                          xwww.y == TestData_LHS[i].w &
                          xwww.z == TestData_LHS[i].w &
                          xwww.w == TestData_LHS[i].w;

                sbyte4 yxxx = TestData_LHS[i].yxxx;
                result &= yxxx.x == TestData_LHS[i].y &
                          yxxx.y == TestData_LHS[i].x &
                          yxxx.z == TestData_LHS[i].x &
                          yxxx.w == TestData_LHS[i].x;

                sbyte4 yxxy = TestData_LHS[i].yxxy;
                result &= yxxy.x == TestData_LHS[i].y &
                          yxxy.y == TestData_LHS[i].x &
                          yxxy.z == TestData_LHS[i].x &
                          yxxy.w == TestData_LHS[i].y;

                sbyte4 yxxz = TestData_LHS[i].yxxz;
                result &= yxxz.x == TestData_LHS[i].y &
                          yxxz.y == TestData_LHS[i].x &
                          yxxz.z == TestData_LHS[i].x &
                          yxxz.w == TestData_LHS[i].z;

                sbyte4 yxxw = TestData_LHS[i].yxxw;
                result &= yxxw.x == TestData_LHS[i].y &
                          yxxw.y == TestData_LHS[i].x &
                          yxxw.z == TestData_LHS[i].x &
                          yxxw.w == TestData_LHS[i].w;

                sbyte4 yxyx = TestData_LHS[i].yxyx;
                result &= yxyx.x == TestData_LHS[i].y &
                          yxyx.y == TestData_LHS[i].x &
                          yxyx.z == TestData_LHS[i].y &
                          yxyx.w == TestData_LHS[i].x;

                sbyte4 yxyy = TestData_LHS[i].yxyy;
                result &= yxyy.x == TestData_LHS[i].y &
                          yxyy.y == TestData_LHS[i].x &
                          yxyy.z == TestData_LHS[i].y &
                          yxyy.w == TestData_LHS[i].y;

                sbyte4 yxyz = TestData_LHS[i].yxyz;
                result &= yxyz.x == TestData_LHS[i].y &
                          yxyz.y == TestData_LHS[i].x &
                          yxyz.z == TestData_LHS[i].y &
                          yxyz.w == TestData_LHS[i].z;

                sbyte4 yxyw = TestData_LHS[i].yxyw;
                result &= yxyw.x == TestData_LHS[i].y &
                          yxyw.y == TestData_LHS[i].x &
                          yxyw.z == TestData_LHS[i].y &
                          yxyw.w == TestData_LHS[i].w;

                sbyte4 yxzx = TestData_LHS[i].yxzx;
                result &= yxzx.x == TestData_LHS[i].y &
                          yxzx.y == TestData_LHS[i].x &
                          yxzx.z == TestData_LHS[i].z &
                          yxzx.w == TestData_LHS[i].x;

                sbyte4 yxzy = TestData_LHS[i].yxzy;
                result &= yxzy.x == TestData_LHS[i].y &
                          yxzy.y == TestData_LHS[i].x &
                          yxzy.z == TestData_LHS[i].z &
                          yxzy.w == TestData_LHS[i].y;

                sbyte4 yxzz = TestData_LHS[i].yxzz;
                result &= yxzz.x == TestData_LHS[i].y &
                          yxzz.y == TestData_LHS[i].x &
                          yxzz.z == TestData_LHS[i].z &
                          yxzz.w == TestData_LHS[i].z;

                sbyte4 yxzw = TestData_LHS[i].yxzw;
                result &= yxzw.x == TestData_LHS[i].y &
                          yxzw.y == TestData_LHS[i].x &
                          yxzw.z == TestData_LHS[i].z &
                          yxzw.w == TestData_LHS[i].w;

                sbyte4 yxwx = TestData_LHS[i].yxwx;
                result &= yxwx.x == TestData_LHS[i].y &
                          yxwx.y == TestData_LHS[i].x &
                          yxwx.z == TestData_LHS[i].w &
                          yxwx.w == TestData_LHS[i].x;
                          
                sbyte4 yxwy = TestData_LHS[i].yxwy;
                result &= yxwy.x == TestData_LHS[i].y &
                          yxwy.y == TestData_LHS[i].x &
                          yxwy.z == TestData_LHS[i].w &
                          yxwy.w == TestData_LHS[i].y;

                sbyte4 yxwz = TestData_LHS[i].yxwz;
                result &= yxwz.x == TestData_LHS[i].y &
                          yxwz.y == TestData_LHS[i].x &
                          yxwz.z == TestData_LHS[i].w &
                          yxwz.w == TestData_LHS[i].z;

                sbyte4 yxww = TestData_LHS[i].yxww;
                result &= yxww.x == TestData_LHS[i].y &
                          yxww.y == TestData_LHS[i].x &
                          yxww.z == TestData_LHS[i].w &
                          yxww.w == TestData_LHS[i].w;

                sbyte4 yyxx = TestData_LHS[i].yyxx;
                result &= yyxx.x == TestData_LHS[i].y &
                          yyxx.y == TestData_LHS[i].y &
                          yyxx.z == TestData_LHS[i].x &
                          yyxx.w == TestData_LHS[i].x;

                sbyte4 yyxy = TestData_LHS[i].yyxy;
                result &= yyxy.x == TestData_LHS[i].y &
                          yyxy.y == TestData_LHS[i].y &
                          yyxy.z == TestData_LHS[i].x &
                          yyxy.w == TestData_LHS[i].y;

                sbyte4 yyxz = TestData_LHS[i].yyxz;
                result &= yyxz.x == TestData_LHS[i].y &
                          yyxz.y == TestData_LHS[i].y &
                          yyxz.z == TestData_LHS[i].x &
                          yyxz.w == TestData_LHS[i].z;

                sbyte4 yyxw = TestData_LHS[i].yyxw;
                result &= yyxw.x == TestData_LHS[i].y &
                          yyxw.y == TestData_LHS[i].y &
                          yyxw.z == TestData_LHS[i].x &
                          yyxw.w == TestData_LHS[i].w;

                sbyte4 yyyx = TestData_LHS[i].yyyx;
                result &= yyyx.x == TestData_LHS[i].y &
                          yyyx.y == TestData_LHS[i].y &
                          yyyx.z == TestData_LHS[i].y &
                          yyyx.w == TestData_LHS[i].x;

                sbyte4 yyyy = TestData_LHS[i].yyyy;
                result &= yyyy.x == TestData_LHS[i].y &
                          yyyy.y == TestData_LHS[i].y &
                          yyyy.z == TestData_LHS[i].y &
                          yyyy.w == TestData_LHS[i].y;

                sbyte4 yyyz = TestData_LHS[i].yyyz;
                result &= yyyz.x == TestData_LHS[i].y &
                          yyyz.y == TestData_LHS[i].y &
                          yyyz.z == TestData_LHS[i].y &
                          yyyz.w == TestData_LHS[i].z;

                sbyte4 yyyw = TestData_LHS[i].yyyw;
                result &= yyyw.x == TestData_LHS[i].y &
                          yyyw.y == TestData_LHS[i].y &
                          yyyw.z == TestData_LHS[i].y &
                          yyyw.w == TestData_LHS[i].w;

                sbyte4 yyzx = TestData_LHS[i].yyzx;
                result &= yyzx.x == TestData_LHS[i].y &
                          yyzx.y == TestData_LHS[i].y &
                          yyzx.z == TestData_LHS[i].z &
                          yyzx.w == TestData_LHS[i].x;

                sbyte4 yyzy = TestData_LHS[i].yyzy;
                result &= yyzy.x == TestData_LHS[i].y &
                          yyzy.y == TestData_LHS[i].y &
                          yyzy.z == TestData_LHS[i].z &
                          yyzy.w == TestData_LHS[i].y;

                sbyte4 yyzz = TestData_LHS[i].yyzz;
                result &= yyzz.x == TestData_LHS[i].y &
                          yyzz.y == TestData_LHS[i].y &
                          yyzz.z == TestData_LHS[i].z &
                          yyzz.w == TestData_LHS[i].z;

                sbyte4 yyzw = TestData_LHS[i].yyzw;
                result &= yyzw.x == TestData_LHS[i].y &
                          yyzw.y == TestData_LHS[i].y &
                          yyzw.z == TestData_LHS[i].z &
                          yyzw.w == TestData_LHS[i].w;

                sbyte4 yywx = TestData_LHS[i].yywx;
                result &= yywx.x == TestData_LHS[i].y &
                          yywx.y == TestData_LHS[i].y &
                          yywx.z == TestData_LHS[i].w &
                          yywx.w == TestData_LHS[i].x;

                sbyte4 yywy = TestData_LHS[i].yywy;
                result &= yywy.x == TestData_LHS[i].y &
                          yywy.y == TestData_LHS[i].y &
                          yywy.z == TestData_LHS[i].w &
                          yywy.w == TestData_LHS[i].y;

                sbyte4 yywz = TestData_LHS[i].yywz;
                result &= yywz.x == TestData_LHS[i].y &
                          yywz.y == TestData_LHS[i].y &
                          yywz.z == TestData_LHS[i].w &
                          yywz.w == TestData_LHS[i].z;

                sbyte4 yyww = TestData_LHS[i].yyww;
                result &= yyww.x == TestData_LHS[i].y &
                          yyww.y == TestData_LHS[i].y &
                          yyww.z == TestData_LHS[i].w &
                          yyww.w == TestData_LHS[i].w;

                sbyte4 yzxx = TestData_LHS[i].yzxx;
                result &= yzxx.x == TestData_LHS[i].y &
                          yzxx.y == TestData_LHS[i].z &
                          yzxx.z == TestData_LHS[i].x &
                          yzxx.w == TestData_LHS[i].x;

                sbyte4 yzxy = TestData_LHS[i].yzxy;
                result &= yzxy.x == TestData_LHS[i].y &
                          yzxy.y == TestData_LHS[i].z &
                          yzxy.z == TestData_LHS[i].x &
                          yzxy.w == TestData_LHS[i].y;

                sbyte4 yzxz = TestData_LHS[i].yzxz;
                result &= yzxz.x == TestData_LHS[i].y &
                          yzxz.y == TestData_LHS[i].z &
                          yzxz.z == TestData_LHS[i].x &
                          yzxz.w == TestData_LHS[i].z;

                sbyte4 yzxw = TestData_LHS[i].yzxw;
                result &= yzxw.x == TestData_LHS[i].y &
                          yzxw.y == TestData_LHS[i].z &
                          yzxw.z == TestData_LHS[i].x &
                          yzxw.w == TestData_LHS[i].w;

                sbyte4 yzyx = TestData_LHS[i].yzyx;
                result &= yzyx.x == TestData_LHS[i].y &
                          yzyx.y == TestData_LHS[i].z &
                          yzyx.z == TestData_LHS[i].y &
                          yzyx.w == TestData_LHS[i].x;

                sbyte4 yzyy = TestData_LHS[i].yzyy;
                result &= yzyy.x == TestData_LHS[i].y &
                          yzyy.y == TestData_LHS[i].z &
                          yzyy.z == TestData_LHS[i].y &
                          yzyy.w == TestData_LHS[i].y;

                sbyte4 yzyz = TestData_LHS[i].yzyz;
                result &= yzyz.x == TestData_LHS[i].y &
                          yzyz.y == TestData_LHS[i].z &
                          yzyz.z == TestData_LHS[i].y &
                          yzyz.w == TestData_LHS[i].z;

                sbyte4 yzyw = TestData_LHS[i].yzyw;
                result &= yzyw.x == TestData_LHS[i].y &
                          yzyw.y == TestData_LHS[i].z &
                          yzyw.z == TestData_LHS[i].y &
                          yzyw.w == TestData_LHS[i].w;

                sbyte4 yzzx = TestData_LHS[i].yzzx;
                result &= yzzx.x == TestData_LHS[i].y &
                          yzzx.y == TestData_LHS[i].z &
                          yzzx.z == TestData_LHS[i].z &
                          yzzx.w == TestData_LHS[i].x;

                sbyte4 yzzy = TestData_LHS[i].yzzy;
                result &= yzzy.x == TestData_LHS[i].y &
                          yzzy.y == TestData_LHS[i].z &
                          yzzy.z == TestData_LHS[i].z &
                          yzzy.w == TestData_LHS[i].y;

                sbyte4 yzzz = TestData_LHS[i].yzzz;
                result &= yzzz.x == TestData_LHS[i].y &
                          yzzz.y == TestData_LHS[i].z &
                          yzzz.z == TestData_LHS[i].z &
                          yzzz.w == TestData_LHS[i].z;

                sbyte4 yzzw = TestData_LHS[i].yzzw;
                result &= yzzw.x == TestData_LHS[i].y &
                          yzzw.y == TestData_LHS[i].z &
                          yzzw.z == TestData_LHS[i].z &
                          yzzw.w == TestData_LHS[i].w;

                sbyte4 yzwx = TestData_LHS[i].yzwx;
                result &= yzwx.x == TestData_LHS[i].y &
                          yzwx.y == TestData_LHS[i].z &
                          yzwx.z == TestData_LHS[i].w &
                          yzwx.w == TestData_LHS[i].x;

                sbyte4 yzwy = TestData_LHS[i].yzwy;
                result &= yzwy.x == TestData_LHS[i].y &
                          yzwy.y == TestData_LHS[i].z &
                          yzwy.z == TestData_LHS[i].w &
                          yzwy.w == TestData_LHS[i].y;

                sbyte4 yzwz = TestData_LHS[i].yzwz;
                result &= yzwz.x == TestData_LHS[i].y &
                          yzwz.y == TestData_LHS[i].z &
                          yzwz.z == TestData_LHS[i].w &
                          yzwz.w == TestData_LHS[i].z;

                sbyte4 yzww = TestData_LHS[i].yzww;
                result &= yzww.x == TestData_LHS[i].y &
                          yzww.y == TestData_LHS[i].z &
                          yzww.z == TestData_LHS[i].w &
                          yzww.w == TestData_LHS[i].w;

                sbyte4 ywxx = TestData_LHS[i].ywxx;
                result &= ywxx.x == TestData_LHS[i].y &
                          ywxx.y == TestData_LHS[i].w &
                          ywxx.z == TestData_LHS[i].x &
                          ywxx.w == TestData_LHS[i].x;

                sbyte4 ywxy = TestData_LHS[i].ywxy;
                result &= ywxy.x == TestData_LHS[i].y &
                          ywxy.y == TestData_LHS[i].w &
                          ywxy.z == TestData_LHS[i].x &
                          ywxy.w == TestData_LHS[i].y;

                sbyte4 ywxz = TestData_LHS[i].ywxz;
                result &= ywxz.x == TestData_LHS[i].y &
                          ywxz.y == TestData_LHS[i].w &
                          ywxz.z == TestData_LHS[i].x &
                          ywxz.w == TestData_LHS[i].z;

                sbyte4 ywxw = TestData_LHS[i].ywxw;
                result &= ywxw.x == TestData_LHS[i].y &
                          ywxw.y == TestData_LHS[i].w &
                          ywxw.z == TestData_LHS[i].x &
                          ywxw.w == TestData_LHS[i].w;

                sbyte4 ywyx = TestData_LHS[i].ywyx;
                result &= ywyx.x == TestData_LHS[i].y &
                          ywyx.y == TestData_LHS[i].w &
                          ywyx.z == TestData_LHS[i].y &
                          ywyx.w == TestData_LHS[i].x;

                sbyte4 ywyy = TestData_LHS[i].ywyy;
                result &= ywyy.x == TestData_LHS[i].y &
                          ywyy.y == TestData_LHS[i].w &
                          ywyy.z == TestData_LHS[i].y &
                          ywyy.w == TestData_LHS[i].y;

                sbyte4 ywyz = TestData_LHS[i].ywyz;
                result &= ywyz.x == TestData_LHS[i].y &
                          ywyz.y == TestData_LHS[i].w &
                          ywyz.z == TestData_LHS[i].y &
                          ywyz.w == TestData_LHS[i].z;

                sbyte4 ywyw = TestData_LHS[i].ywyw;
                result &= ywyw.x == TestData_LHS[i].y &
                          ywyw.y == TestData_LHS[i].w &
                          ywyw.z == TestData_LHS[i].y &
                          ywyw.w == TestData_LHS[i].w;

                sbyte4 ywzx = TestData_LHS[i].ywzx;
                result &= ywzx.x == TestData_LHS[i].y &
                          ywzx.y == TestData_LHS[i].w &
                          ywzx.z == TestData_LHS[i].z &
                          ywzx.w == TestData_LHS[i].x;

                sbyte4 ywzy = TestData_LHS[i].ywzy;
                result &= ywzy.x == TestData_LHS[i].y &
                          ywzy.y == TestData_LHS[i].w &
                          ywzy.z == TestData_LHS[i].z &
                          ywzy.w == TestData_LHS[i].y;

                sbyte4 ywzz = TestData_LHS[i].ywzz;
                result &= ywzz.x == TestData_LHS[i].y &
                          ywzz.y == TestData_LHS[i].w &
                          ywzz.z == TestData_LHS[i].z &
                          ywzz.w == TestData_LHS[i].z;

                sbyte4 ywzw = TestData_LHS[i].ywzw;
                result &= ywzw.x == TestData_LHS[i].y &
                          ywzw.y == TestData_LHS[i].w &
                          ywzw.z == TestData_LHS[i].z &
                          ywzw.w == TestData_LHS[i].w;

                sbyte4 ywwx = TestData_LHS[i].ywwx;
                result &= ywwx.x == TestData_LHS[i].y &
                          ywwx.y == TestData_LHS[i].w &
                          ywwx.z == TestData_LHS[i].w &
                          ywwx.w == TestData_LHS[i].x;

                sbyte4 ywwy = TestData_LHS[i].ywwy;
                result &= ywwy.x == TestData_LHS[i].y &
                          ywwy.y == TestData_LHS[i].w &
                          ywwy.z == TestData_LHS[i].w &
                          ywwy.w == TestData_LHS[i].y;

                sbyte4 ywwz = TestData_LHS[i].ywwz;
                result &= ywwz.x == TestData_LHS[i].y &
                          ywwz.y == TestData_LHS[i].w &
                          ywwz.z == TestData_LHS[i].w &
                          ywwz.w == TestData_LHS[i].z;

                sbyte4 ywww = TestData_LHS[i].ywww;
                result &= ywww.x == TestData_LHS[i].y &
                          ywww.y == TestData_LHS[i].w &
                          ywww.z == TestData_LHS[i].w &
                          ywww.w == TestData_LHS[i].w;

                sbyte4 zxxx = TestData_LHS[i].zxxx;
                result &= zxxx.x == TestData_LHS[i].z &
                          zxxx.y == TestData_LHS[i].x &
                          zxxx.z == TestData_LHS[i].x &
                          zxxx.w == TestData_LHS[i].x;

                sbyte4 zxxy = TestData_LHS[i].zxxy;
                result &= zxxy.x == TestData_LHS[i].z &
                          zxxy.y == TestData_LHS[i].x &
                          zxxy.z == TestData_LHS[i].x &
                          zxxy.w == TestData_LHS[i].y;

                sbyte4 zxxz = TestData_LHS[i].zxxz;
                result &= zxxz.x == TestData_LHS[i].z &
                          zxxz.y == TestData_LHS[i].x &
                          zxxz.z == TestData_LHS[i].x &
                          zxxz.w == TestData_LHS[i].z;

                sbyte4 zxxw = TestData_LHS[i].zxxw;
                result &= zxxw.x == TestData_LHS[i].z &
                          zxxw.y == TestData_LHS[i].x &
                          zxxw.z == TestData_LHS[i].x &
                          zxxw.w == TestData_LHS[i].w;

                sbyte4 zxyx = TestData_LHS[i].zxyx;
                result &= zxyx.x == TestData_LHS[i].z &
                          zxyx.y == TestData_LHS[i].x &
                          zxyx.z == TestData_LHS[i].y &
                          zxyx.w == TestData_LHS[i].x;

                sbyte4 zxyy = TestData_LHS[i].zxyy;
                result &= zxyy.x == TestData_LHS[i].z &
                          zxyy.y == TestData_LHS[i].x &
                          zxyy.z == TestData_LHS[i].y &
                          zxyy.w == TestData_LHS[i].y;

                sbyte4 zxyz = TestData_LHS[i].zxyz;
                result &= zxyz.x == TestData_LHS[i].z &
                          zxyz.y == TestData_LHS[i].x &
                          zxyz.z == TestData_LHS[i].y &
                          zxyz.w == TestData_LHS[i].z;

                sbyte4 zxyw = TestData_LHS[i].zxyw;
                result &= zxyw.x == TestData_LHS[i].z &
                          zxyw.y == TestData_LHS[i].x &
                          zxyw.z == TestData_LHS[i].y &
                          zxyw.w == TestData_LHS[i].w;

                sbyte4 zxzx = TestData_LHS[i].zxzx;
                result &= zxzx.x == TestData_LHS[i].z &
                          zxzx.y == TestData_LHS[i].x &
                          zxzx.z == TestData_LHS[i].z &
                          zxzx.w == TestData_LHS[i].x;

                sbyte4 zxzy = TestData_LHS[i].zxzy;
                result &= zxzy.x == TestData_LHS[i].z &
                          zxzy.y == TestData_LHS[i].x &
                          zxzy.z == TestData_LHS[i].z &
                          zxzy.w == TestData_LHS[i].y;

                sbyte4 zxzz = TestData_LHS[i].zxzz;
                result &= zxzz.x == TestData_LHS[i].z &
                          zxzz.y == TestData_LHS[i].x &
                          zxzz.z == TestData_LHS[i].z &
                          zxzz.w == TestData_LHS[i].z;

                sbyte4 zxzw = TestData_LHS[i].zxzw;
                result &= zxzw.x == TestData_LHS[i].z &
                          zxzw.y == TestData_LHS[i].x &
                          zxzw.z == TestData_LHS[i].z &
                          zxzw.w == TestData_LHS[i].w;

                sbyte4 zxwx = TestData_LHS[i].zxwx;
                result &= zxwx.x == TestData_LHS[i].z &
                          zxwx.y == TestData_LHS[i].x &
                          zxwx.z == TestData_LHS[i].w &
                          zxwx.w == TestData_LHS[i].x;

                sbyte4 zxwy = TestData_LHS[i].zxwy;
                result &= zxwy.x == TestData_LHS[i].z &
                          zxwy.y == TestData_LHS[i].x &
                          zxwy.z == TestData_LHS[i].w &
                          zxwy.w == TestData_LHS[i].y;

                sbyte4 zxwz = TestData_LHS[i].zxwz;
                result &= zxwz.x == TestData_LHS[i].z &
                          zxwz.y == TestData_LHS[i].x &
                          zxwz.z == TestData_LHS[i].w &
                          zxwz.w == TestData_LHS[i].z;

                sbyte4 zxww = TestData_LHS[i].zxww;
                result &= zxww.x == TestData_LHS[i].z &
                          zxww.y == TestData_LHS[i].x &
                          zxww.z == TestData_LHS[i].w &
                          zxww.w == TestData_LHS[i].w;

                sbyte4 zyxx = TestData_LHS[i].zyxx;
                result &= zyxx.x == TestData_LHS[i].z &
                          zyxx.y == TestData_LHS[i].y &
                          zyxx.z == TestData_LHS[i].x &
                          zyxx.w == TestData_LHS[i].x;

                sbyte4 zyxy = TestData_LHS[i].zyxy;
                result &= zyxy.x == TestData_LHS[i].z &
                          zyxy.y == TestData_LHS[i].y &
                          zyxy.z == TestData_LHS[i].x &
                          zyxy.w == TestData_LHS[i].y;

                sbyte4 zyxz = TestData_LHS[i].zyxz;
                result &= zyxz.x == TestData_LHS[i].z &
                          zyxz.y == TestData_LHS[i].y &
                          zyxz.z == TestData_LHS[i].x &
                          zyxz.w == TestData_LHS[i].z;

                sbyte4 zyxw = TestData_LHS[i].zyxw;
                result &= zyxw.x == TestData_LHS[i].z &
                          zyxw.y == TestData_LHS[i].y &
                          zyxw.z == TestData_LHS[i].x &
                          zyxw.w == TestData_LHS[i].w;

                sbyte4 zyyx = TestData_LHS[i].zyyx;
                result &= zyyx.x == TestData_LHS[i].z &
                          zyyx.y == TestData_LHS[i].y &
                          zyyx.z == TestData_LHS[i].y &
                          zyyx.w == TestData_LHS[i].x;

                sbyte4 zyyy = TestData_LHS[i].zyyy;
                result &= zyyy.x == TestData_LHS[i].z &
                          zyyy.y == TestData_LHS[i].y &
                          zyyy.z == TestData_LHS[i].y &
                          zyyy.w == TestData_LHS[i].y;

                sbyte4 zyyz = TestData_LHS[i].zyyz;
                result &= zyyz.x == TestData_LHS[i].z &
                          zyyz.y == TestData_LHS[i].y &
                          zyyz.z == TestData_LHS[i].y &
                          zyyz.w == TestData_LHS[i].z;

                sbyte4 zyyw = TestData_LHS[i].zyyw;
                result &= zyyw.x == TestData_LHS[i].z &
                          zyyw.y == TestData_LHS[i].y &
                          zyyw.z == TestData_LHS[i].y &
                          zyyw.w == TestData_LHS[i].w;

                sbyte4 zyzx = TestData_LHS[i].zyzx;
                result &= zyzx.x == TestData_LHS[i].z &
                          zyzx.y == TestData_LHS[i].y &
                          zyzx.z == TestData_LHS[i].z &
                          zyzx.w == TestData_LHS[i].x;

                sbyte4 zyzy = TestData_LHS[i].zyzy;
                result &= zyzy.x == TestData_LHS[i].z &
                          zyzy.y == TestData_LHS[i].y &
                          zyzy.z == TestData_LHS[i].z &
                          zyzy.w == TestData_LHS[i].y;

                sbyte4 zyzz = TestData_LHS[i].zyzz;
                result &= zyzz.x == TestData_LHS[i].z &
                          zyzz.y == TestData_LHS[i].y &
                          zyzz.z == TestData_LHS[i].z &
                          zyzz.w == TestData_LHS[i].z;

                sbyte4 zyzw = TestData_LHS[i].zyzw;
                result &= zyzw.x == TestData_LHS[i].z &
                          zyzw.y == TestData_LHS[i].y &
                          zyzw.z == TestData_LHS[i].z &
                          zyzw.w == TestData_LHS[i].w;

                sbyte4 zywx = TestData_LHS[i].zywx;
                result &= zywx.x == TestData_LHS[i].z &
                          zywx.y == TestData_LHS[i].y &
                          zywx.z == TestData_LHS[i].w &
                          zywx.w == TestData_LHS[i].x;

                sbyte4 zywy = TestData_LHS[i].zywy;
                result &= zywy.x == TestData_LHS[i].z &
                          zywy.y == TestData_LHS[i].y &
                          zywy.z == TestData_LHS[i].w &
                          zywy.w == TestData_LHS[i].y;

                sbyte4 zywz = TestData_LHS[i].zywz;
                result &= zywz.x == TestData_LHS[i].z &
                          zywz.y == TestData_LHS[i].y &
                          zywz.z == TestData_LHS[i].w &
                          zywz.w == TestData_LHS[i].z;

                sbyte4 zyww = TestData_LHS[i].zyww;
                result &= zyww.x == TestData_LHS[i].z &
                          zyww.y == TestData_LHS[i].y &
                          zyww.z == TestData_LHS[i].w &
                          zyww.w == TestData_LHS[i].w;

                sbyte4 zzxx = TestData_LHS[i].zzxx;
                result &= zzxx.x == TestData_LHS[i].z &
                          zzxx.y == TestData_LHS[i].z &
                          zzxx.z == TestData_LHS[i].x &
                          zzxx.w == TestData_LHS[i].x;

                sbyte4 zzxy = TestData_LHS[i].zzxy;
                result &= zzxy.x == TestData_LHS[i].z &
                          zzxy.y == TestData_LHS[i].z &
                          zzxy.z == TestData_LHS[i].x &
                          zzxy.w == TestData_LHS[i].y;

                sbyte4 zzxz = TestData_LHS[i].zzxz;
                result &= zzxz.x == TestData_LHS[i].z &
                          zzxz.y == TestData_LHS[i].z &
                          zzxz.z == TestData_LHS[i].x &
                          zzxz.w == TestData_LHS[i].z;

                sbyte4 zzxw = TestData_LHS[i].zzxw;
                result &= zzxw.x == TestData_LHS[i].z &
                          zzxw.y == TestData_LHS[i].z &
                          zzxw.z == TestData_LHS[i].x &
                          zzxw.w == TestData_LHS[i].w;

                sbyte4 zzyx = TestData_LHS[i].zzyx;
                result &= zzyx.x == TestData_LHS[i].z &
                          zzyx.y == TestData_LHS[i].z &
                          zzyx.z == TestData_LHS[i].y &
                          zzyx.w == TestData_LHS[i].x;

                sbyte4 zzyy = TestData_LHS[i].zzyy;
                result &= zzyy.x == TestData_LHS[i].z &
                          zzyy.y == TestData_LHS[i].z &
                          zzyy.z == TestData_LHS[i].y &
                          zzyy.w == TestData_LHS[i].y;

                sbyte4 zzyz = TestData_LHS[i].zzyz;
                result &= zzyz.x == TestData_LHS[i].z &
                          zzyz.y == TestData_LHS[i].z &
                          zzyz.z == TestData_LHS[i].y &
                          zzyz.w == TestData_LHS[i].z;

                sbyte4 zzyw = TestData_LHS[i].zzyw;
                result &= zzyw.x == TestData_LHS[i].z &
                          zzyw.y == TestData_LHS[i].z &
                          zzyw.z == TestData_LHS[i].y &
                          zzyw.w == TestData_LHS[i].w;

                sbyte4 zzzx = TestData_LHS[i].zzzx;
                result &= zzzx.x == TestData_LHS[i].z &
                          zzzx.y == TestData_LHS[i].z &
                          zzzx.z == TestData_LHS[i].z &
                          zzzx.w == TestData_LHS[i].x;

                sbyte4 zzzy = TestData_LHS[i].zzzy;
                result &= zzzy.x == TestData_LHS[i].z &
                          zzzy.y == TestData_LHS[i].z &
                          zzzy.z == TestData_LHS[i].z &
                          zzzy.w == TestData_LHS[i].y;

                sbyte4 zzzz = TestData_LHS[i].zzzz;
                result &= zzzz.x == TestData_LHS[i].z &
                          zzzz.y == TestData_LHS[i].z &
                          zzzz.z == TestData_LHS[i].z &
                          zzzz.w == TestData_LHS[i].z;

                sbyte4 zzzw = TestData_LHS[i].zzzw;
                result &= zzzw.x == TestData_LHS[i].z &
                          zzzw.y == TestData_LHS[i].z &
                          zzzw.z == TestData_LHS[i].z &
                          zzzw.w == TestData_LHS[i].w;

                sbyte4 zzwx = TestData_LHS[i].zzwx;
                result &= zzwx.x == TestData_LHS[i].z &
                          zzwx.y == TestData_LHS[i].z &
                          zzwx.z == TestData_LHS[i].w &
                          zzwx.w == TestData_LHS[i].x;

                sbyte4 zzwy = TestData_LHS[i].zzwy;
                result &= zzwy.x == TestData_LHS[i].z &
                          zzwy.y == TestData_LHS[i].z &
                          zzwy.z == TestData_LHS[i].w &
                          zzwy.w == TestData_LHS[i].y;

                sbyte4 zzwz = TestData_LHS[i].zzwz;
                result &= zzwz.x == TestData_LHS[i].z &
                          zzwz.y == TestData_LHS[i].z &
                          zzwz.z == TestData_LHS[i].w &
                          zzwz.w == TestData_LHS[i].z;

                sbyte4 zzww = TestData_LHS[i].zzww;
                result &= zzww.x == TestData_LHS[i].z &
                          zzww.y == TestData_LHS[i].z &
                          zzww.z == TestData_LHS[i].w &
                          zzww.w == TestData_LHS[i].w;

                sbyte4 zwxx = TestData_LHS[i].zwxx;
                result &= zwxx.x == TestData_LHS[i].z &
                          zwxx.y == TestData_LHS[i].w &
                          zwxx.z == TestData_LHS[i].x &
                          zwxx.w == TestData_LHS[i].x;

                sbyte4 zwxy = TestData_LHS[i].zwxy;
                result &= zwxy.x == TestData_LHS[i].z &
                          zwxy.y == TestData_LHS[i].w &
                          zwxy.z == TestData_LHS[i].x &
                          zwxy.w == TestData_LHS[i].y;

                sbyte4 zwxz = TestData_LHS[i].zwxz;
                result &= zwxz.x == TestData_LHS[i].z &
                          zwxz.y == TestData_LHS[i].w &
                          zwxz.z == TestData_LHS[i].x &
                          zwxz.w == TestData_LHS[i].z;

                sbyte4 zwxw = TestData_LHS[i].zwxw;
                result &= zwxw.x == TestData_LHS[i].z &
                          zwxw.y == TestData_LHS[i].w &
                          zwxw.z == TestData_LHS[i].x &
                          zwxw.w == TestData_LHS[i].w;

                sbyte4 zwyx = TestData_LHS[i].zwyx;
                result &= zwyx.x == TestData_LHS[i].z &
                          zwyx.y == TestData_LHS[i].w &
                          zwyx.z == TestData_LHS[i].y &
                          zwyx.w == TestData_LHS[i].x;

                sbyte4 zwyy = TestData_LHS[i].zwyy;
                result &= zwyy.x == TestData_LHS[i].z &
                          zwyy.y == TestData_LHS[i].w &
                          zwyy.z == TestData_LHS[i].y &
                          zwyy.w == TestData_LHS[i].y;

                sbyte4 zwyz = TestData_LHS[i].zwyz;
                result &= zwyz.x == TestData_LHS[i].z &
                          zwyz.y == TestData_LHS[i].w &
                          zwyz.z == TestData_LHS[i].y &
                          zwyz.w == TestData_LHS[i].z;

                sbyte4 zwyw = TestData_LHS[i].zwyw;
                result &= zwyw.x == TestData_LHS[i].z &
                          zwyw.y == TestData_LHS[i].w &
                          zwyw.z == TestData_LHS[i].y &
                          zwyw.w == TestData_LHS[i].w;

                sbyte4 zwzx = TestData_LHS[i].zwzx;
                result &= zwzx.x == TestData_LHS[i].z &
                          zwzx.y == TestData_LHS[i].w &
                          zwzx.z == TestData_LHS[i].z &
                          zwzx.w == TestData_LHS[i].x;

                sbyte4 zwzy = TestData_LHS[i].zwzy;
                result &= zwzy.x == TestData_LHS[i].z &
                          zwzy.y == TestData_LHS[i].w &
                          zwzy.z == TestData_LHS[i].z &
                          zwzy.w == TestData_LHS[i].y;

                sbyte4 zwzz = TestData_LHS[i].zwzz;
                result &= zwzz.x == TestData_LHS[i].z &
                          zwzz.y == TestData_LHS[i].w &
                          zwzz.z == TestData_LHS[i].z &
                          zwzz.w == TestData_LHS[i].z;

                sbyte4 zwzw = TestData_LHS[i].zwzw;
                result &= zwzw.x == TestData_LHS[i].z &
                          zwzw.y == TestData_LHS[i].w &
                          zwzw.z == TestData_LHS[i].z &
                          zwzw.w == TestData_LHS[i].w;

                sbyte4 zwwx = TestData_LHS[i].zwwx;
                result &= zwwx.x == TestData_LHS[i].z &
                          zwwx.y == TestData_LHS[i].w &
                          zwwx.z == TestData_LHS[i].w &
                          zwwx.w == TestData_LHS[i].x;

                sbyte4 zwwy = TestData_LHS[i].zwwy;
                result &= zwwy.x == TestData_LHS[i].z &
                          zwwy.y == TestData_LHS[i].w &
                          zwwy.z == TestData_LHS[i].w &
                          zwwy.w == TestData_LHS[i].y;

                sbyte4 zwwz = TestData_LHS[i].zwwz;
                result &= zwwz.x == TestData_LHS[i].z &
                          zwwz.y == TestData_LHS[i].w &
                          zwwz.z == TestData_LHS[i].w &
                          zwwz.w == TestData_LHS[i].z;

                sbyte4 zwww = TestData_LHS[i].zwww;
                result &= zwww.x == TestData_LHS[i].z &
                          zwww.y == TestData_LHS[i].w &
                          zwww.z == TestData_LHS[i].w &
                          zwww.w == TestData_LHS[i].w;

                sbyte4 wxxx = TestData_LHS[i].wxxx;
                result &= wxxx.x == TestData_LHS[i].w &
                          wxxx.y == TestData_LHS[i].x &
                          wxxx.z == TestData_LHS[i].x &
                          wxxx.w == TestData_LHS[i].x;

                sbyte4 wxxy = TestData_LHS[i].wxxy;
                result &= wxxy.x == TestData_LHS[i].w &
                          wxxy.y == TestData_LHS[i].x &
                          wxxy.z == TestData_LHS[i].x &
                          wxxy.w == TestData_LHS[i].y;

                sbyte4 wxxz = TestData_LHS[i].wxxz;
                result &= wxxz.x == TestData_LHS[i].w &
                          wxxz.y == TestData_LHS[i].x &
                          wxxz.z == TestData_LHS[i].x &
                          wxxz.w == TestData_LHS[i].z;

                sbyte4 wxxw = TestData_LHS[i].wxxw;
                result &= wxxw.x == TestData_LHS[i].w &
                          wxxw.y == TestData_LHS[i].x &
                          wxxw.z == TestData_LHS[i].x &
                          wxxw.w == TestData_LHS[i].w;

                sbyte4 wxyx = TestData_LHS[i].wxyx;
                result &= wxyx.x == TestData_LHS[i].w &
                          wxyx.y == TestData_LHS[i].x &
                          wxyx.z == TestData_LHS[i].y &
                          wxyx.w == TestData_LHS[i].x;

                sbyte4 wxyy = TestData_LHS[i].wxyy;
                result &= wxyy.x == TestData_LHS[i].w &
                          wxyy.y == TestData_LHS[i].x &
                          wxyy.z == TestData_LHS[i].y &
                          wxyy.w == TestData_LHS[i].y;

                sbyte4 wxyz = TestData_LHS[i].wxyz;
                result &= wxyz.x == TestData_LHS[i].w &
                          wxyz.y == TestData_LHS[i].x &
                          wxyz.z == TestData_LHS[i].y &
                          wxyz.w == TestData_LHS[i].z;

                sbyte4 wxyw = TestData_LHS[i].wxyw;
                result &= wxyw.x == TestData_LHS[i].w &
                          wxyw.y == TestData_LHS[i].x &
                          wxyw.z == TestData_LHS[i].y &
                          wxyw.w == TestData_LHS[i].w;

                sbyte4 wxzx = TestData_LHS[i].wxzx;
                result &= wxzx.x == TestData_LHS[i].w &
                          wxzx.y == TestData_LHS[i].x &
                          wxzx.z == TestData_LHS[i].z &
                          wxzx.w == TestData_LHS[i].x;

                sbyte4 wxzy = TestData_LHS[i].wxzy;
                result &= wxzy.x == TestData_LHS[i].w &
                          wxzy.y == TestData_LHS[i].x &
                          wxzy.z == TestData_LHS[i].z &
                          wxzy.w == TestData_LHS[i].y;

                sbyte4 wxzz = TestData_LHS[i].wxzz;
                result &= wxzz.x == TestData_LHS[i].w &
                          wxzz.y == TestData_LHS[i].x &
                          wxzz.z == TestData_LHS[i].z &
                          wxzz.w == TestData_LHS[i].z;

                sbyte4 wxzw = TestData_LHS[i].wxzw;
                result &= wxzw.x == TestData_LHS[i].w &
                          wxzw.y == TestData_LHS[i].x &
                          wxzw.z == TestData_LHS[i].z &
                          wxzw.w == TestData_LHS[i].w;

                sbyte4 wxwx = TestData_LHS[i].wxwx;
                result &= wxwx.x == TestData_LHS[i].w &
                          wxwx.y == TestData_LHS[i].x &
                          wxwx.z == TestData_LHS[i].w &
                          wxwx.w == TestData_LHS[i].x;

                sbyte4 wxwy = TestData_LHS[i].wxwy;
                result &= wxwy.x == TestData_LHS[i].w &
                          wxwy.y == TestData_LHS[i].x &
                          wxwy.z == TestData_LHS[i].w &
                          wxwy.w == TestData_LHS[i].y;

                sbyte4 wxwz = TestData_LHS[i].wxwz;
                result &= wxwz.x == TestData_LHS[i].w &
                          wxwz.y == TestData_LHS[i].x &
                          wxwz.z == TestData_LHS[i].w &
                          wxwz.w == TestData_LHS[i].z;

                sbyte4 wxww = TestData_LHS[i].wxww;
                result &= wxww.x == TestData_LHS[i].w &
                          wxww.y == TestData_LHS[i].x &
                          wxww.z == TestData_LHS[i].w &
                          wxww.w == TestData_LHS[i].w;

                sbyte4 wyxx = TestData_LHS[i].wyxx;
                result &= wyxx.x == TestData_LHS[i].w &
                          wyxx.y == TestData_LHS[i].y &
                          wyxx.z == TestData_LHS[i].x &
                          wyxx.w == TestData_LHS[i].x;

                sbyte4 wyxy = TestData_LHS[i].wyxy;
                result &= wyxy.x == TestData_LHS[i].w &
                          wyxy.y == TestData_LHS[i].y &
                          wyxy.z == TestData_LHS[i].x &
                          wyxy.w == TestData_LHS[i].y;

                sbyte4 wyxz = TestData_LHS[i].wyxz;
                result &= wyxz.x == TestData_LHS[i].w &
                          wyxz.y == TestData_LHS[i].y &
                          wyxz.z == TestData_LHS[i].x &
                          wyxz.w == TestData_LHS[i].z;

                sbyte4 wyxw = TestData_LHS[i].wyxw;
                result &= wyxw.x == TestData_LHS[i].w &
                          wyxw.y == TestData_LHS[i].y &
                          wyxw.z == TestData_LHS[i].x &
                          wyxw.w == TestData_LHS[i].w;

                sbyte4 wyyx = TestData_LHS[i].wyyx;
                result &= wyyx.x == TestData_LHS[i].w &
                          wyyx.y == TestData_LHS[i].y &
                          wyyx.z == TestData_LHS[i].y &
                          wyyx.w == TestData_LHS[i].x;

                sbyte4 wyyy = TestData_LHS[i].wyyy;
                result &= wyyy.x == TestData_LHS[i].w &
                          wyyy.y == TestData_LHS[i].y &
                          wyyy.z == TestData_LHS[i].y &
                          wyyy.w == TestData_LHS[i].y;

                sbyte4 wyyz = TestData_LHS[i].wyyz;
                result &= wyyz.x == TestData_LHS[i].w &
                          wyyz.y == TestData_LHS[i].y &
                          wyyz.z == TestData_LHS[i].y &
                          wyyz.w == TestData_LHS[i].z;

                sbyte4 wyyw = TestData_LHS[i].wyyw;
                result &= wyyw.x == TestData_LHS[i].w &
                          wyyw.y == TestData_LHS[i].y &
                          wyyw.z == TestData_LHS[i].y &
                          wyyw.w == TestData_LHS[i].w;

                sbyte4 wyzx = TestData_LHS[i].wyzx;
                result &= wyzx.x == TestData_LHS[i].w &
                          wyzx.y == TestData_LHS[i].y &
                          wyzx.z == TestData_LHS[i].z &
                          wyzx.w == TestData_LHS[i].x;

                sbyte4 wyzy = TestData_LHS[i].wyzy;
                result &= wyzy.x == TestData_LHS[i].w &
                          wyzy.y == TestData_LHS[i].y &
                          wyzy.z == TestData_LHS[i].z &
                          wyzy.w == TestData_LHS[i].y;

                sbyte4 wyzz = TestData_LHS[i].wyzz;
                result &= wyzz.x == TestData_LHS[i].w &
                          wyzz.y == TestData_LHS[i].y &
                          wyzz.z == TestData_LHS[i].z &
                          wyzz.w == TestData_LHS[i].z;

                sbyte4 wyzw = TestData_LHS[i].wyzw;
                result &= wyzw.x == TestData_LHS[i].w &
                          wyzw.y == TestData_LHS[i].y &
                          wyzw.z == TestData_LHS[i].z &
                          wyzw.w == TestData_LHS[i].w;

                sbyte4 wywx = TestData_LHS[i].wywx;
                result &= wywx.x == TestData_LHS[i].w &
                          wywx.y == TestData_LHS[i].y &
                          wywx.z == TestData_LHS[i].w &
                          wywx.w == TestData_LHS[i].x;

                sbyte4 wywy = TestData_LHS[i].wywy;
                result &= wywy.x == TestData_LHS[i].w &
                          wywy.y == TestData_LHS[i].y &
                          wywy.z == TestData_LHS[i].w &
                          wywy.w == TestData_LHS[i].y;

                sbyte4 wywz = TestData_LHS[i].wywz;
                result &= wywz.x == TestData_LHS[i].w &
                          wywz.y == TestData_LHS[i].y &
                          wywz.z == TestData_LHS[i].w &
                          wywz.w == TestData_LHS[i].z;

                sbyte4 wyww = TestData_LHS[i].wyww;
                result &= wyww.x == TestData_LHS[i].w &
                          wyww.y == TestData_LHS[i].y &
                          wyww.z == TestData_LHS[i].w &
                          wyww.w == TestData_LHS[i].w;

                sbyte4 wzxx = TestData_LHS[i].wzxx;
                result &= wzxx.x == TestData_LHS[i].w &
                          wzxx.y == TestData_LHS[i].z &
                          wzxx.z == TestData_LHS[i].x &
                          wzxx.w == TestData_LHS[i].x;

                sbyte4 wzxy = TestData_LHS[i].wzxy;
                result &= wzxy.x == TestData_LHS[i].w &
                          wzxy.y == TestData_LHS[i].z &
                          wzxy.z == TestData_LHS[i].x &
                          wzxy.w == TestData_LHS[i].y;

                sbyte4 wzxz = TestData_LHS[i].wzxz;
                result &= wzxz.x == TestData_LHS[i].w &
                          wzxz.y == TestData_LHS[i].z &
                          wzxz.z == TestData_LHS[i].x &
                          wzxz.w == TestData_LHS[i].z;

                sbyte4 wzxw = TestData_LHS[i].wzxw;
                result &= wzxw.x == TestData_LHS[i].w &
                          wzxw.y == TestData_LHS[i].z &
                          wzxw.z == TestData_LHS[i].x &
                          wzxw.w == TestData_LHS[i].w;

                sbyte4 wzyx = TestData_LHS[i].wzyx;
                result &= wzyx.x == TestData_LHS[i].w &
                          wzyx.y == TestData_LHS[i].z &
                          wzyx.z == TestData_LHS[i].y &
                          wzyx.w == TestData_LHS[i].x;

                sbyte4 wzyy = TestData_LHS[i].wzyy;
                result &= wzyy.x == TestData_LHS[i].w &
                          wzyy.y == TestData_LHS[i].z &
                          wzyy.z == TestData_LHS[i].y &
                          wzyy.w == TestData_LHS[i].y;

                sbyte4 wzyz = TestData_LHS[i].wzyz;
                result &= wzyz.x == TestData_LHS[i].w &
                          wzyz.y == TestData_LHS[i].z &
                          wzyz.z == TestData_LHS[i].y &
                          wzyz.w == TestData_LHS[i].z;

                sbyte4 wzyw = TestData_LHS[i].wzyw;
                result &= wzyw.x == TestData_LHS[i].w &
                          wzyw.y == TestData_LHS[i].z &
                          wzyw.z == TestData_LHS[i].y &
                          wzyw.w == TestData_LHS[i].w;

                sbyte4 wzzx = TestData_LHS[i].wzzx;
                result &= wzzx.x == TestData_LHS[i].w &
                          wzzx.y == TestData_LHS[i].z &
                          wzzx.z == TestData_LHS[i].z &
                          wzzx.w == TestData_LHS[i].x;

                sbyte4 wzzy = TestData_LHS[i].wzzy;
                result &= wzzy.x == TestData_LHS[i].w &
                          wzzy.y == TestData_LHS[i].z &
                          wzzy.z == TestData_LHS[i].z &
                          wzzy.w == TestData_LHS[i].y;

                sbyte4 wzzz = TestData_LHS[i].wzzz;
                result &= wzzz.x == TestData_LHS[i].w &
                          wzzz.y == TestData_LHS[i].z &
                          wzzz.z == TestData_LHS[i].z &
                          wzzz.w == TestData_LHS[i].z;

                sbyte4 wzzw = TestData_LHS[i].wzzw;
                result &= wzzw.x == TestData_LHS[i].w &
                          wzzw.y == TestData_LHS[i].z &
                          wzzw.z == TestData_LHS[i].z &
                          wzzw.w == TestData_LHS[i].w;

                sbyte4 wzwx = TestData_LHS[i].wzwx;
                result &= wzwx.x == TestData_LHS[i].w &
                          wzwx.y == TestData_LHS[i].z &
                          wzwx.z == TestData_LHS[i].w &
                          wzwx.w == TestData_LHS[i].x;

                sbyte4 wzwy = TestData_LHS[i].wzwy;
                result &= wzwy.x == TestData_LHS[i].w &
                          wzwy.y == TestData_LHS[i].z &
                          wzwy.z == TestData_LHS[i].w &
                          wzwy.w == TestData_LHS[i].y;

                sbyte4 wzwz = TestData_LHS[i].wzwz;
                result &= wzwz.x == TestData_LHS[i].w &
                          wzwz.y == TestData_LHS[i].z &
                          wzwz.z == TestData_LHS[i].w &
                          wzwz.w == TestData_LHS[i].z;

                sbyte4 wzww = TestData_LHS[i].wzww;
                result &= wzww.x == TestData_LHS[i].w &
                          wzww.y == TestData_LHS[i].z &
                          wzww.z == TestData_LHS[i].w &
                          wzww.w == TestData_LHS[i].w;

                sbyte4 wwxx = TestData_LHS[i].wwxx;
                result &= wwxx.x == TestData_LHS[i].w &
                          wwxx.y == TestData_LHS[i].w &
                          wwxx.z == TestData_LHS[i].x &
                          wwxx.w == TestData_LHS[i].x;

                sbyte4 wwxy = TestData_LHS[i].wwxy;
                result &= wwxy.x == TestData_LHS[i].w &
                          wwxy.y == TestData_LHS[i].w &
                          wwxy.z == TestData_LHS[i].x &
                          wwxy.w == TestData_LHS[i].y;

                sbyte4 wwxz = TestData_LHS[i].wwxz;
                result &= wwxz.x == TestData_LHS[i].w &
                          wwxz.y == TestData_LHS[i].w &
                          wwxz.z == TestData_LHS[i].x &
                          wwxz.w == TestData_LHS[i].z;

                sbyte4 wwxw = TestData_LHS[i].wwxw;
                result &= wwxw.x == TestData_LHS[i].w &
                          wwxw.y == TestData_LHS[i].w &
                          wwxw.z == TestData_LHS[i].x &
                          wwxw.w == TestData_LHS[i].w;

                sbyte4 wwyx = TestData_LHS[i].wwyx;
                result &= wwyx.x == TestData_LHS[i].w &
                          wwyx.y == TestData_LHS[i].w &
                          wwyx.z == TestData_LHS[i].y &
                          wwyx.w == TestData_LHS[i].x;

                sbyte4 wwyy = TestData_LHS[i].wwyy;
                result &= wwyy.x == TestData_LHS[i].w &
                          wwyy.y == TestData_LHS[i].w &
                          wwyy.z == TestData_LHS[i].y &
                          wwyy.w == TestData_LHS[i].y;

                sbyte4 wwyz = TestData_LHS[i].wwyz;
                result &= wwyz.x == TestData_LHS[i].w &
                          wwyz.y == TestData_LHS[i].w &
                          wwyz.z == TestData_LHS[i].y &
                          wwyz.w == TestData_LHS[i].z;

                sbyte4 wwyw = TestData_LHS[i].wwyw;
                result &= wwyw.x == TestData_LHS[i].w &
                          wwyw.y == TestData_LHS[i].w &
                          wwyw.z == TestData_LHS[i].y &
                          wwyw.w == TestData_LHS[i].w;

                sbyte4 wwzx = TestData_LHS[i].wwzx;
                result &= wwzx.x == TestData_LHS[i].w &
                          wwzx.y == TestData_LHS[i].w &
                          wwzx.z == TestData_LHS[i].z &
                          wwzx.w == TestData_LHS[i].x;

                sbyte4 wwzy = TestData_LHS[i].wwzy;
                result &= wwzy.x == TestData_LHS[i].w &
                          wwzy.y == TestData_LHS[i].w &
                          wwzy.z == TestData_LHS[i].z &
                          wwzy.w == TestData_LHS[i].y;

                sbyte4 wwzz = TestData_LHS[i].wwzz;
                result &= wwzz.x == TestData_LHS[i].w &
                          wwzz.y == TestData_LHS[i].w &
                          wwzz.z == TestData_LHS[i].z &
                          wwzz.w == TestData_LHS[i].z;

                sbyte4 wwzw = TestData_LHS[i].wwzw;
                result &= wwzw.x == TestData_LHS[i].w &
                          wwzw.y == TestData_LHS[i].w &
                          wwzw.z == TestData_LHS[i].z &
                          wwzw.w == TestData_LHS[i].w;

                sbyte4 wwwx = TestData_LHS[i].wwwx;
                result &= wwwx.x == TestData_LHS[i].w &
                          wwwx.y == TestData_LHS[i].w &
                          wwwx.z == TestData_LHS[i].w &
                          wwwx.w == TestData_LHS[i].x;

                sbyte4 wwwy = TestData_LHS[i].wwwy;
                result &= wwwy.x == TestData_LHS[i].w &
                          wwwy.y == TestData_LHS[i].w &
                          wwwy.z == TestData_LHS[i].w &
                          wwwy.w == TestData_LHS[i].y;

                sbyte4 wwwz = TestData_LHS[i].wwwz;
                result &= wwwz.x == TestData_LHS[i].w &
                          wwwz.y == TestData_LHS[i].w &
                          wwwz.z == TestData_LHS[i].w &
                          wwwz.w == TestData_LHS[i].z;

                sbyte4 wwww = TestData_LHS[i].wwww;
                result &= wwww.x == TestData_LHS[i].w &
                          wwww.y == TestData_LHS[i].w &
                          wwww.z == TestData_LHS[i].w &
                          wwww.w == TestData_LHS[i].w;


                sbyte3 xxx = TestData_LHS[i].xxx;
                result &= xxx.x == TestData_LHS[i].x &
                          xxx.y == TestData_LHS[i].x &
                          xxx.z == TestData_LHS[i].x;

                sbyte3 xxy = TestData_LHS[i].xxy;
                result &= xxy.x == TestData_LHS[i].x &
                          xxy.y == TestData_LHS[i].x &
                          xxy.z == TestData_LHS[i].y;

                sbyte3 xxz = TestData_LHS[i].xxz;
                result &= xxz.x == TestData_LHS[i].x &
                          xxz.y == TestData_LHS[i].x &
                          xxz.z == TestData_LHS[i].z;

                sbyte3 xxw = TestData_LHS[i].xxw;
                result &= xxw.x == TestData_LHS[i].x &
                          xxw.y == TestData_LHS[i].x &
                          xxw.z == TestData_LHS[i].w;

                sbyte3 xyx = TestData_LHS[i].xyx;
                result &= xyx.x == TestData_LHS[i].x &
                          xyx.y == TestData_LHS[i].y &
                          xyx.z == TestData_LHS[i].x;

                sbyte3 xyy = TestData_LHS[i].xyy;
                result &= xyy.x == TestData_LHS[i].x &
                          xyy.y == TestData_LHS[i].y &
                          xyy.z == TestData_LHS[i].y;

                sbyte3 xyz = TestData_LHS[i].xyz;
                result &= xyz.x == TestData_LHS[i].x &
                          xyz.y == TestData_LHS[i].y &
                          xyz.z == TestData_LHS[i].z;

                sbyte3 xyw = TestData_LHS[i].xyw;
                result &= xyw.x == TestData_LHS[i].x &
                          xyw.y == TestData_LHS[i].y &
                          xyw.z == TestData_LHS[i].w;

                sbyte3 xzx = TestData_LHS[i].xzx;
                result &= xzx.x == TestData_LHS[i].x &
                          xzx.y == TestData_LHS[i].z &
                          xzx.z == TestData_LHS[i].x;

                sbyte3 xzy = TestData_LHS[i].xzy;
                result &= xzy.x == TestData_LHS[i].x &
                          xzy.y == TestData_LHS[i].z &
                          xzy.z == TestData_LHS[i].y;

                sbyte3 xzz = TestData_LHS[i].xzz;
                result &= xzz.x == TestData_LHS[i].x &
                          xzz.y == TestData_LHS[i].z &
                          xzz.z == TestData_LHS[i].z;

                sbyte3 xzw = TestData_LHS[i].xzw;
                result &= xzw.x == TestData_LHS[i].x &
                          xzw.y == TestData_LHS[i].z &
                          xzw.z == TestData_LHS[i].w;

                sbyte3 xwx = TestData_LHS[i].xwx;
                result &= xwx.x == TestData_LHS[i].x &
                          xwx.y == TestData_LHS[i].w &
                          xwx.z == TestData_LHS[i].x;

                sbyte3 xwy = TestData_LHS[i].xwy;
                result &= xwy.x == TestData_LHS[i].x &
                          xwy.y == TestData_LHS[i].w &
                          xwy.z == TestData_LHS[i].y;

                sbyte3 xwz = TestData_LHS[i].xwz;
                result &= xwz.x == TestData_LHS[i].x &
                          xwz.y == TestData_LHS[i].w &
                          xwz.z == TestData_LHS[i].z;

                sbyte3 xww = TestData_LHS[i].xww;
                result &= xww.x == TestData_LHS[i].x &
                          xww.y == TestData_LHS[i].w &
                          xww.z == TestData_LHS[i].w;

                sbyte3 yxx = TestData_LHS[i].yxx;
                result &= yxx.x == TestData_LHS[i].y &
                          yxx.y == TestData_LHS[i].x &
                          yxx.z == TestData_LHS[i].x;

                sbyte3 yxy = TestData_LHS[i].yxy;
                result &= yxy.x == TestData_LHS[i].y &
                          yxy.y == TestData_LHS[i].x &
                          yxy.z == TestData_LHS[i].y;

                sbyte3 yxz = TestData_LHS[i].yxz;
                result &= yxz.x == TestData_LHS[i].y &
                          yxz.y == TestData_LHS[i].x &
                          yxz.z == TestData_LHS[i].z;

                sbyte3 yxw = TestData_LHS[i].yxw;
                result &= yxw.x == TestData_LHS[i].y &
                          yxw.y == TestData_LHS[i].x &
                          yxw.z == TestData_LHS[i].w;

                sbyte3 yyx = TestData_LHS[i].yyx;
                result &= yyx.x == TestData_LHS[i].y &
                          yyx.y == TestData_LHS[i].y &
                          yyx.z == TestData_LHS[i].x;

                sbyte3 yyy = TestData_LHS[i].yyy;
                result &= yyy.x == TestData_LHS[i].y &
                          yyy.y == TestData_LHS[i].y &
                          yyy.z == TestData_LHS[i].y;

                sbyte3 yyz = TestData_LHS[i].yyz;
                result &= yyz.x == TestData_LHS[i].y &
                          yyz.y == TestData_LHS[i].y &
                          yyz.z == TestData_LHS[i].z;

                sbyte3 yyw = TestData_LHS[i].yyw;
                result &= yyw.x == TestData_LHS[i].y &
                          yyw.y == TestData_LHS[i].y &
                          yyw.z == TestData_LHS[i].w;

                sbyte3 yzx = TestData_LHS[i].yzx;
                result &= yzx.x == TestData_LHS[i].y &
                          yzx.y == TestData_LHS[i].z &
                          yzx.z == TestData_LHS[i].x;

                sbyte3 yzy = TestData_LHS[i].yzy;
                result &= yzy.x == TestData_LHS[i].y &
                          yzy.y == TestData_LHS[i].z &
                          yzy.z == TestData_LHS[i].y;

                sbyte3 yzz = TestData_LHS[i].yzz;
                result &= yzz.x == TestData_LHS[i].y &
                          yzz.y == TestData_LHS[i].z &
                          yzz.z == TestData_LHS[i].z;

                sbyte3 yzw = TestData_LHS[i].yzw;
                result &= yzw.x == TestData_LHS[i].y &
                          yzw.y == TestData_LHS[i].z &
                          yzw.z == TestData_LHS[i].w;

                sbyte3 ywx = TestData_LHS[i].ywx;
                result &= ywx.x == TestData_LHS[i].y &
                          ywx.y == TestData_LHS[i].w &
                          ywx.z == TestData_LHS[i].x;

                sbyte3 ywy = TestData_LHS[i].ywy;
                result &= ywy.x == TestData_LHS[i].y &
                          ywy.y == TestData_LHS[i].w &
                          ywy.z == TestData_LHS[i].y;

                sbyte3 ywz = TestData_LHS[i].ywz;
                result &= ywz.x == TestData_LHS[i].y &
                          ywz.y == TestData_LHS[i].w &
                          ywz.z == TestData_LHS[i].z;

                sbyte3 yww = TestData_LHS[i].yww;
                result &= yww.x == TestData_LHS[i].y &
                          yww.y == TestData_LHS[i].w &
                          yww.z == TestData_LHS[i].w;

                sbyte3 zxx = TestData_LHS[i].zxx;
                result &= zxx.x == TestData_LHS[i].z &
                          zxx.y == TestData_LHS[i].x &
                          zxx.z == TestData_LHS[i].x;

                sbyte3 zxy = TestData_LHS[i].zxy;
                result &= zxy.x == TestData_LHS[i].z &
                          zxy.y == TestData_LHS[i].x &
                          zxy.z == TestData_LHS[i].y;

                sbyte3 zxz = TestData_LHS[i].zxz;
                result &= zxz.x == TestData_LHS[i].z &
                          zxz.y == TestData_LHS[i].x &
                          zxz.z == TestData_LHS[i].z;

                sbyte3 zxw = TestData_LHS[i].zxw;
                result &= zxw.x == TestData_LHS[i].z &
                          zxw.y == TestData_LHS[i].x &
                          zxw.z == TestData_LHS[i].w;

                sbyte3 zyx = TestData_LHS[i].zyx;
                result &= zyx.x == TestData_LHS[i].z &
                          zyx.y == TestData_LHS[i].y &
                          zyx.z == TestData_LHS[i].x;

                sbyte3 zyy = TestData_LHS[i].zyy;
                result &= zyy.x == TestData_LHS[i].z &
                          zyy.y == TestData_LHS[i].y &
                          zyy.z == TestData_LHS[i].y;

                sbyte3 zyz = TestData_LHS[i].zyz;
                result &= zyz.x == TestData_LHS[i].z &
                          zyz.y == TestData_LHS[i].y &
                          zyz.z == TestData_LHS[i].z;

                sbyte3 zyw = TestData_LHS[i].zyw;
                result &= zyw.x == TestData_LHS[i].z &
                          zyw.y == TestData_LHS[i].y &
                          zyw.z == TestData_LHS[i].w;

                sbyte3 zzx = TestData_LHS[i].zzx;
                result &= zzx.x == TestData_LHS[i].z &
                          zzx.y == TestData_LHS[i].z &
                          zzx.z == TestData_LHS[i].x;

                sbyte3 zzy = TestData_LHS[i].zzy;
                result &= zzy.x == TestData_LHS[i].z &
                          zzy.y == TestData_LHS[i].z &
                          zzy.z == TestData_LHS[i].y;

                sbyte3 zzz = TestData_LHS[i].zzz;
                result &= zzz.x == TestData_LHS[i].z &
                          zzz.y == TestData_LHS[i].z &
                          zzz.z == TestData_LHS[i].z;

                sbyte3 zzw = TestData_LHS[i].zzw;
                result &= zzw.x == TestData_LHS[i].z &
                          zzw.y == TestData_LHS[i].z &
                          zzw.z == TestData_LHS[i].w;

                sbyte3 zwx = TestData_LHS[i].zwx;
                result &= zwx.x == TestData_LHS[i].z &
                          zwx.y == TestData_LHS[i].w &
                          zwx.z == TestData_LHS[i].x;

                sbyte3 zwy = TestData_LHS[i].zwy;
                result &= zwy.x == TestData_LHS[i].z &
                          zwy.y == TestData_LHS[i].w &
                          zwy.z == TestData_LHS[i].y;

                sbyte3 zwz = TestData_LHS[i].zwz;
                result &= zwz.x == TestData_LHS[i].z &
                          zwz.y == TestData_LHS[i].w &
                          zwz.z == TestData_LHS[i].z;

                sbyte3 zww = TestData_LHS[i].zww;
                result &= zww.x == TestData_LHS[i].z &
                          zww.y == TestData_LHS[i].w &
                          zww.z == TestData_LHS[i].w;

                sbyte3 wxx = TestData_LHS[i].wxx;
                result &= wxx.x == TestData_LHS[i].w &
                          wxx.y == TestData_LHS[i].x &
                          wxx.z == TestData_LHS[i].x;

                sbyte3 wxy = TestData_LHS[i].wxy;
                result &= wxy.x == TestData_LHS[i].w &
                          wxy.y == TestData_LHS[i].x &
                          wxy.z == TestData_LHS[i].y;

                sbyte3 wxz = TestData_LHS[i].wxz;
                result &= wxz.x == TestData_LHS[i].w &
                          wxz.y == TestData_LHS[i].x &
                          wxz.z == TestData_LHS[i].z;

                sbyte3 wxw = TestData_LHS[i].wxw;
                result &= wxw.x == TestData_LHS[i].w &
                          wxw.y == TestData_LHS[i].x &
                          wxw.z == TestData_LHS[i].w;

                sbyte3 wyx = TestData_LHS[i].wyx;
                result &= wyx.x == TestData_LHS[i].w &
                          wyx.y == TestData_LHS[i].y &
                          wyx.z == TestData_LHS[i].x;

                sbyte3 wyy = TestData_LHS[i].wyy;
                result &= wyy.x == TestData_LHS[i].w &
                          wyy.y == TestData_LHS[i].y &
                          wyy.z == TestData_LHS[i].y;

                sbyte3 wyz = TestData_LHS[i].wyz;
                result &= wyz.x == TestData_LHS[i].w &
                          wyz.y == TestData_LHS[i].y &
                          wyz.z == TestData_LHS[i].z;

                sbyte3 wyw = TestData_LHS[i].wyw;
                result &= wyw.x == TestData_LHS[i].w &
                          wyw.y == TestData_LHS[i].y &
                          wyw.z == TestData_LHS[i].w;

                sbyte3 wzx = TestData_LHS[i].wzx;
                result &= wzx.x == TestData_LHS[i].w &
                          wzx.y == TestData_LHS[i].z &
                          wzx.z == TestData_LHS[i].x;

                sbyte3 wzy = TestData_LHS[i].wzy;
                result &= wzy.x == TestData_LHS[i].w &
                          wzy.y == TestData_LHS[i].z &
                          wzy.z == TestData_LHS[i].y;

                sbyte3 wzz = TestData_LHS[i].wzz;
                result &= wzz.x == TestData_LHS[i].w &
                          wzz.y == TestData_LHS[i].z &
                          wzz.z == TestData_LHS[i].z;

                sbyte3 wzw = TestData_LHS[i].wzw;
                result &= wzw.x == TestData_LHS[i].w &
                          wzw.y == TestData_LHS[i].z &
                          wzw.z == TestData_LHS[i].w;

                sbyte3 wwx = TestData_LHS[i].wwx;
                result &= wwx.x == TestData_LHS[i].w &
                          wwx.y == TestData_LHS[i].w &
                          wwx.z == TestData_LHS[i].x;

                sbyte3 wwy = TestData_LHS[i].wwy;
                result &= wwy.x == TestData_LHS[i].w &
                          wwy.y == TestData_LHS[i].w &
                          wwy.z == TestData_LHS[i].y;

                sbyte3 wwz = TestData_LHS[i].wwz;
                result &= wwz.x == TestData_LHS[i].w &
                          wwz.y == TestData_LHS[i].w &
                          wwz.z == TestData_LHS[i].z;

                sbyte3 www = TestData_LHS[i].www;
                result &= www.x == TestData_LHS[i].w &
                          www.y == TestData_LHS[i].w &
                          www.z == TestData_LHS[i].w;

                sbyte2 xx = TestData_LHS[i].xx;
                result &= xx.x == TestData_LHS[i].x &
                          xx.y == TestData_LHS[i].x;

                sbyte2 xy = TestData_LHS[i].xy;
                result &= xy.x == TestData_LHS[i].x &
                          xy.y == TestData_LHS[i].y;

                sbyte2 xz = TestData_LHS[i].xz;
                result &= xz.x == TestData_LHS[i].x &
                          xz.y == TestData_LHS[i].z;

                sbyte2 xw = TestData_LHS[i].xw;
                result &= xw.x == TestData_LHS[i].x &
                          xw.y == TestData_LHS[i].w;

                sbyte2 yx = TestData_LHS[i].yx;
                result &= yx.x == TestData_LHS[i].y &
                          yx.y == TestData_LHS[i].x;

                sbyte2 yy = TestData_LHS[i].yy;
                result &= yy.x == TestData_LHS[i].y &
                          yy.y == TestData_LHS[i].y;

                sbyte2 yz = TestData_LHS[i].yz;
                result &= yz.x == TestData_LHS[i].y &
                          yz.y == TestData_LHS[i].z;

                sbyte2 yw = TestData_LHS[i].yw;
                result &= yw.x == TestData_LHS[i].y &
                          yw.y == TestData_LHS[i].w;

                sbyte2 zx = TestData_LHS[i].zx;
                result &= zx.x == TestData_LHS[i].z &
                          zx.y == TestData_LHS[i].x;

                sbyte2 zy = TestData_LHS[i].zy;
                result &= zy.x == TestData_LHS[i].z &
                          zy.y == TestData_LHS[i].y;

                sbyte2 zz = TestData_LHS[i].zz;
                result &= zz.x == TestData_LHS[i].z &
                          zz.y == TestData_LHS[i].z;

                sbyte2 zw = TestData_LHS[i].zw;
                result &= zw.x == TestData_LHS[i].z &
                          zw.y == TestData_LHS[i].w;

                sbyte2 wx = TestData_LHS[i].wx;
                result &= wx.x == TestData_LHS[i].w &
                          wx.y == TestData_LHS[i].x;

                sbyte2 wy = TestData_LHS[i].wy;
                result &= wy.x == TestData_LHS[i].w &
                          wy.y == TestData_LHS[i].y;

                sbyte2 wz = TestData_LHS[i].wz;
                result &= wz.x == TestData_LHS[i].w &
                          wz.y == TestData_LHS[i].z;

                sbyte2 ww = TestData_LHS[i].ww;
                result &= ww.x == TestData_LHS[i].w &
                          ww.y == TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShuffleSetter()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 xywz = TestData_LHS[i];
                xywz.xywz = TestData_RHS[i];
                result &= xywz.x == TestData_RHS[i].x;
                result &= xywz.y == TestData_RHS[i].y;
                result &= xywz.w == TestData_RHS[i].z;
                result &= xywz.z == TestData_RHS[i].w;

                sbyte4 xzyw = TestData_LHS[i];
                xzyw.xzyw = TestData_RHS[i];
                result &= xzyw.x == TestData_RHS[i].x;
                result &= xzyw.z == TestData_RHS[i].y;
                result &= xzyw.y == TestData_RHS[i].z;
                result &= xzyw.w == TestData_RHS[i].w;

                sbyte4 xzwy = TestData_LHS[i];
                xzwy.xzwy = TestData_RHS[i];
                result &= xzwy.x == TestData_RHS[i].x;
                result &= xzwy.z == TestData_RHS[i].y;
                result &= xzwy.w == TestData_RHS[i].z;
                result &= xzwy.y == TestData_RHS[i].w;

                sbyte4 xwyz = TestData_LHS[i];
                xwyz.xwyz = TestData_RHS[i];
                result &= xwyz.x == TestData_RHS[i].x;
                result &= xwyz.w == TestData_RHS[i].y;
                result &= xwyz.y == TestData_RHS[i].z;
                result &= xwyz.z == TestData_RHS[i].w;

                sbyte4 xwzy = TestData_LHS[i];
                xwzy.xwzy = TestData_RHS[i];
                result &= xwzy.x == TestData_RHS[i].x;
                result &= xwzy.w == TestData_RHS[i].y;
                result &= xwzy.z == TestData_RHS[i].z;
                result &= xwzy.y == TestData_RHS[i].w;

                sbyte4 yxzw = TestData_LHS[i];
                yxzw.yxzw = TestData_RHS[i];
                result &= yxzw.y == TestData_RHS[i].x;
                result &= yxzw.x == TestData_RHS[i].y;
                result &= yxzw.z == TestData_RHS[i].z;
                result &= yxzw.w == TestData_RHS[i].w;

                sbyte4 yxwz = TestData_LHS[i];
                yxwz.yxwz = TestData_RHS[i];
                result &= yxwz.y == TestData_RHS[i].x;
                result &= yxwz.x == TestData_RHS[i].y;
                result &= yxwz.w == TestData_RHS[i].z;
                result &= yxwz.z == TestData_RHS[i].w;

                sbyte4 yzxw = TestData_LHS[i];
                yzxw.yzxw = TestData_RHS[i];
                result &= yzxw.y == TestData_RHS[i].x;
                result &= yzxw.z == TestData_RHS[i].y;
                result &= yzxw.x == TestData_RHS[i].z;
                result &= yzxw.w == TestData_RHS[i].w;

                sbyte4 yzwx = TestData_LHS[i];
                yzwx.yzwx = TestData_RHS[i];
                result &= yzwx.y == TestData_RHS[i].x;
                result &= yzwx.z == TestData_RHS[i].y;
                result &= yzwx.w == TestData_RHS[i].z;
                result &= yzwx.x == TestData_RHS[i].w;

                sbyte4 ywxz = TestData_LHS[i];
                ywxz.ywxz = TestData_RHS[i];
                result &= ywxz.y == TestData_RHS[i].x;
                result &= ywxz.w == TestData_RHS[i].y;
                result &= ywxz.x == TestData_RHS[i].z;
                result &= ywxz.z == TestData_RHS[i].w;

                sbyte4 ywzx = TestData_LHS[i];
                ywzx.ywzx = TestData_RHS[i];
                result &= ywzx.y == TestData_RHS[i].x;
                result &= ywzx.w == TestData_RHS[i].y;
                result &= ywzx.z == TestData_RHS[i].z;
                result &= ywzx.x == TestData_RHS[i].w;

                sbyte4 zxyw = TestData_LHS[i];
                zxyw.zxyw = TestData_RHS[i];
                result &= zxyw.z == TestData_RHS[i].x;
                result &= zxyw.x == TestData_RHS[i].y;
                result &= zxyw.y == TestData_RHS[i].z;
                result &= zxyw.w == TestData_RHS[i].w;

                sbyte4 zxwy = TestData_LHS[i];
                zxwy.zxwy = TestData_RHS[i];
                result &= zxwy.z == TestData_RHS[i].x;
                result &= zxwy.x == TestData_RHS[i].y;
                result &= zxwy.w == TestData_RHS[i].z;
                result &= zxwy.y == TestData_RHS[i].w;

                sbyte4 zyxw = TestData_LHS[i];
                zyxw.zyxw = TestData_RHS[i];
                result &= zyxw.z == TestData_RHS[i].x;
                result &= zyxw.y == TestData_RHS[i].y;
                result &= zyxw.x == TestData_RHS[i].z;
                result &= zyxw.w == TestData_RHS[i].w;

                sbyte4 zywx = TestData_LHS[i];
                zywx.zywx = TestData_RHS[i];
                result &= zywx.z == TestData_RHS[i].x;
                result &= zywx.y == TestData_RHS[i].y;
                result &= zywx.w == TestData_RHS[i].z;
                result &= zywx.x == TestData_RHS[i].w;

                sbyte4 zwxy = TestData_LHS[i];
                zwxy.zwxy = TestData_RHS[i];
                result &= zwxy.z == TestData_RHS[i].x;
                result &= zwxy.w == TestData_RHS[i].y;
                result &= zwxy.x == TestData_RHS[i].z;
                result &= zwxy.y == TestData_RHS[i].w;

                sbyte4 zwyx = TestData_LHS[i];
                zwyx.zwyx = TestData_RHS[i];
                result &= zwyx.z == TestData_RHS[i].x;
                result &= zwyx.w == TestData_RHS[i].y;
                result &= zwyx.y == TestData_RHS[i].z;
                result &= zwyx.x == TestData_RHS[i].w;

                sbyte4 wxyz = TestData_LHS[i];
                wxyz.wxyz = TestData_RHS[i];
                result &= wxyz.w == TestData_RHS[i].x;
                result &= wxyz.x == TestData_RHS[i].y;
                result &= wxyz.y == TestData_RHS[i].z;
                result &= wxyz.z == TestData_RHS[i].w;

                sbyte4 wxzy = TestData_LHS[i];
                wxzy.wxzy = TestData_RHS[i];
                result &= wxzy.w == TestData_RHS[i].x;
                result &= wxzy.x == TestData_RHS[i].y;
                result &= wxzy.z == TestData_RHS[i].z;
                result &= wxzy.y == TestData_RHS[i].w;

                sbyte4 wyxz = TestData_LHS[i];
                wyxz.wyxz = TestData_RHS[i];
                result &= wyxz.w == TestData_RHS[i].x;
                result &= wyxz.y == TestData_RHS[i].y;
                result &= wyxz.x == TestData_RHS[i].z;
                result &= wyxz.z == TestData_RHS[i].w;

                sbyte4 wyzx = TestData_LHS[i];
                wyzx.wyzx = TestData_RHS[i];
                result &= wyzx.w == TestData_RHS[i].x;
                result &= wyzx.y == TestData_RHS[i].y;
                result &= wyzx.z == TestData_RHS[i].z;
                result &= wyzx.x == TestData_RHS[i].w;

                sbyte4 wzxy = TestData_LHS[i];
                wzxy.wzxy = TestData_RHS[i];
                result &= wzxy.w == TestData_RHS[i].x;
                result &= wzxy.z == TestData_RHS[i].y;
                result &= wzxy.x == TestData_RHS[i].z;
                result &= wzxy.y == TestData_RHS[i].w;

                sbyte4 wzyx = TestData_LHS[i];
                wzyx.wzyx = TestData_RHS[i];
                result &= wzyx.w == TestData_RHS[i].x;
                result &= wzyx.z == TestData_RHS[i].y;
                result &= wzyx.y == TestData_RHS[i].z;
                result &= wzyx.x == TestData_RHS[i].w;


                sbyte4 xyz = TestData_LHS[i];
                xyz.xyz = TestData_RHS[i].xyz;
                result &= xyz.x == TestData_RHS[i].x;
                result &= xyz.y == TestData_RHS[i].y;
                result &= xyz.z == TestData_RHS[i].z;
                result &= xyz.w == TestData_LHS[i].w;

                sbyte4 xyw = TestData_LHS[i];
                xyw.xyw = TestData_RHS[i].xyz;
                result &= xyw.x == TestData_RHS[i].x;
                result &= xyw.y == TestData_RHS[i].y;
                result &= xyw.z == TestData_LHS[i].z;
                result &= xyw.w == TestData_RHS[i].z;

                sbyte4 xzy = TestData_LHS[i];
                xzy.xzy = TestData_RHS[i].xyz;
                result &= xzy.x == TestData_RHS[i].x;
                result &= xzy.y == TestData_RHS[i].z;
                result &= xzy.z == TestData_RHS[i].y;
                result &= xzy.w == TestData_LHS[i].w;

                sbyte4 xzw = TestData_LHS[i];
                xzw.xzw = TestData_RHS[i].xyz;
                result &= xzw.x == TestData_RHS[i].x;
                result &= xzw.y == TestData_LHS[i].y;
                result &= xzw.z == TestData_RHS[i].y;
                result &= xzw.w == TestData_RHS[i].z;

                sbyte4 xwy = TestData_LHS[i];
                xwy.xwy = TestData_RHS[i].xyz;
                result &= xwy.x == TestData_RHS[i].x;
                result &= xwy.y == TestData_RHS[i].z;
                result &= xwy.z == TestData_LHS[i].z;
                result &= xwy.w == TestData_RHS[i].y;

                sbyte4 xwz = TestData_LHS[i];
                xwz.xwz = TestData_RHS[i].xyz;
                result &= xwz.x == TestData_RHS[i].x;
                result &= xwz.y == TestData_LHS[i].y;
                result &= xwz.z == TestData_RHS[i].z;
                result &= xwz.w == TestData_RHS[i].y;

                sbyte4 yxz = TestData_LHS[i];
                yxz.yxz = TestData_RHS[i].xyz;
                result &= yxz.x == TestData_RHS[i].y;
                result &= yxz.y == TestData_RHS[i].x;
                result &= yxz.z == TestData_RHS[i].z;
                result &= yxz.w == TestData_LHS[i].w;

                sbyte4 yxw = TestData_LHS[i];
                yxw.yxw = TestData_RHS[i].xyz;
                result &= yxw.x == TestData_RHS[i].y;
                result &= yxw.y == TestData_RHS[i].x;
                result &= yxw.z == TestData_LHS[i].z;
                result &= yxw.w == TestData_RHS[i].z;

                sbyte4 yzx = TestData_LHS[i];
                yzx.yzx = TestData_RHS[i].xyz;
                result &= yzx.x == TestData_RHS[i].z;
                result &= yzx.y == TestData_RHS[i].x;
                result &= yzx.z == TestData_RHS[i].y;
                result &= yzx.w == TestData_LHS[i].w;

                sbyte4 yzw = TestData_LHS[i];
                yzw.yzw = TestData_RHS[i].xyz;
                result &= yzw.x == TestData_LHS[i].x;
                result &= yzw.y == TestData_RHS[i].x;
                result &= yzw.z == TestData_RHS[i].y;
                result &= yzw.w == TestData_RHS[i].z;

                sbyte4 ywx = TestData_LHS[i];
                ywx.ywx = TestData_RHS[i].xyz;
                result &= ywx.x == TestData_RHS[i].z;
                result &= ywx.y == TestData_RHS[i].x;
                result &= ywx.z == TestData_LHS[i].z;
                result &= ywx.w == TestData_RHS[i].y;

                sbyte4 ywz = TestData_LHS[i];
                ywz.ywz = TestData_RHS[i].xyz;
                result &= ywz.x == TestData_LHS[i].x;
                result &= ywz.y == TestData_RHS[i].x;
                result &= ywz.z == TestData_RHS[i].z;
                result &= ywz.w == TestData_RHS[i].y;

                sbyte4 zxy = TestData_LHS[i];
                zxy.zxy = TestData_RHS[i].xyz;
                result &= zxy.x == TestData_RHS[i].y;
                result &= zxy.y == TestData_RHS[i].z;
                result &= zxy.z == TestData_RHS[i].x;
                result &= zxy.w == TestData_LHS[i].w;

                sbyte4 zxw = TestData_LHS[i];
                zxw.zxw = TestData_RHS[i].xyz;
                result &= zxw.x == TestData_RHS[i].y;
                result &= zxw.y == TestData_LHS[i].y;
                result &= zxw.z == TestData_RHS[i].x;
                result &= zxw.w == TestData_RHS[i].z;

                sbyte4 zyx = TestData_LHS[i];
                zyx.zyx = TestData_RHS[i].xyz;
                result &= zyx.x == TestData_RHS[i].z;
                result &= zyx.y == TestData_RHS[i].y;
                result &= zyx.z == TestData_RHS[i].x;
                result &= zyx.w == TestData_LHS[i].w;

                sbyte4 zyw = TestData_LHS[i];
                zyw.zyw = TestData_RHS[i].xyz;
                result &= zyw.x == TestData_LHS[i].x;
                result &= zyw.y == TestData_RHS[i].y;
                result &= zyw.z == TestData_RHS[i].x;
                result &= zyw.w == TestData_RHS[i].z;

                sbyte4 zwx = TestData_LHS[i];
                zwx.zwx = TestData_RHS[i].xyz;
                result &= zwx.x == TestData_RHS[i].z;
                result &= zwx.y == TestData_LHS[i].y;
                result &= zwx.z == TestData_RHS[i].x;
                result &= zwx.w == TestData_RHS[i].y;

                sbyte4 zwy = TestData_LHS[i];
                zwy.zwy = TestData_RHS[i].xyz;
                result &= zwy.x == TestData_LHS[i].x;
                result &= zwy.y == TestData_RHS[i].z;
                result &= zwy.z == TestData_RHS[i].x;
                result &= zwy.w == TestData_RHS[i].y;

                sbyte4 wxy = TestData_LHS[i];
                wxy.wxy = TestData_RHS[i].xyz;
                result &= wxy.x == TestData_RHS[i].y;
                result &= wxy.y == TestData_RHS[i].z;
                result &= wxy.z == TestData_LHS[i].z;
                result &= wxy.w == TestData_RHS[i].x;

                sbyte4 wxz = TestData_LHS[i];
                wxz.wxz = TestData_RHS[i].xyz;
                result &= wxz.x == TestData_RHS[i].y;
                result &= wxz.y == TestData_LHS[i].y;
                result &= wxz.z == TestData_RHS[i].z;
                result &= wxz.w == TestData_RHS[i].x;

                sbyte4 wyx = TestData_LHS[i];
                wyx.wyx = TestData_RHS[i].xyz;
                result &= wyx.x == TestData_RHS[i].z;
                result &= wyx.y == TestData_RHS[i].y;
                result &= wyx.z == TestData_LHS[i].z;
                result &= wyx.w == TestData_RHS[i].x;

                sbyte4 wyz = TestData_LHS[i];
                wyz.wyz = TestData_RHS[i].xyz;
                result &= wyz.x == TestData_LHS[i].x;
                result &= wyz.y == TestData_RHS[i].y;
                result &= wyz.z == TestData_RHS[i].z;
                result &= wyz.w == TestData_RHS[i].x;

                sbyte4 wzx = TestData_LHS[i];
                wzx.wzx = TestData_RHS[i].xyz;
                result &= wzx.x == TestData_RHS[i].z;
                result &= wzx.y == TestData_LHS[i].y;
                result &= wzx.z == TestData_RHS[i].y;
                result &= wzx.w == TestData_RHS[i].x;

                sbyte4 wzy = TestData_LHS[i];
                wzy.wzy = TestData_RHS[i].xyz;
                result &= wzy.x == TestData_LHS[i].x;
                result &= wzy.y == TestData_RHS[i].z;
                result &= wzy.z == TestData_RHS[i].y;
                result &= wzy.w == TestData_RHS[i].x;


                sbyte4 xy = TestData_LHS[i];
                xy.xy = TestData_RHS[i].xy;
                result &= xy.x == TestData_RHS[i].x;
                result &= xy.y == TestData_RHS[i].y;
                result &= xy.z == TestData_LHS[i].z;
                result &= xy.w == TestData_LHS[i].w;

                sbyte4 xz = TestData_LHS[i];
                xz.xz = TestData_RHS[i].xy;
                result &= xz.x == TestData_RHS[i].x;
                result &= xz.y == TestData_LHS[i].y;
                result &= xz.z == TestData_RHS[i].y;
                result &= xz.w == TestData_LHS[i].w;

                sbyte4 xw = TestData_LHS[i];
                xw.xw = TestData_RHS[i].xy;
                result &= xw.x == TestData_RHS[i].x;
                result &= xw.y == TestData_LHS[i].y;
                result &= xw.z == TestData_LHS[i].z;
                result &= xw.w == TestData_RHS[i].y;

                sbyte4 yx = TestData_LHS[i];
                yx.yx = TestData_RHS[i].xy;
                result &= yx.x == TestData_RHS[i].y;
                result &= yx.y == TestData_RHS[i].x;
                result &= yx.z == TestData_LHS[i].z;
                result &= yx.w == TestData_LHS[i].w;

                sbyte4 yz = TestData_LHS[i];
                yz.yz = TestData_RHS[i].xy;
                result &= yz.x == TestData_LHS[i].x;
                result &= yz.y == TestData_RHS[i].x;
                result &= yz.z == TestData_RHS[i].y;
                result &= yz.w == TestData_LHS[i].w;

                sbyte4 yw = TestData_LHS[i];
                yw.yw = TestData_RHS[i].xy;
                result &= yw.x == TestData_LHS[i].x;
                result &= yw.y == TestData_RHS[i].x;
                result &= yw.z == TestData_LHS[i].z;
                result &= yw.w == TestData_RHS[i].y;

                sbyte4 zx = TestData_LHS[i];
                zx.zx = TestData_RHS[i].xy;
                result &= zx.x == TestData_RHS[i].y;
                result &= zx.y == TestData_LHS[i].y;
                result &= zx.z == TestData_RHS[i].x;
                result &= zx.w == TestData_LHS[i].w;

                sbyte4 zy = TestData_LHS[i];
                zy.zy = TestData_RHS[i].xy;
                result &= zy.x == TestData_LHS[i].x;
                result &= zy.y == TestData_RHS[i].y;
                result &= zy.z == TestData_RHS[i].x;
                result &= zy.w == TestData_LHS[i].w;

                sbyte4 zw = TestData_LHS[i];
                zw.zw = TestData_RHS[i].xy;
                result &= zw.x == TestData_LHS[i].x;
                result &= zw.y == TestData_LHS[i].y;
                result &= zw.z == TestData_RHS[i].x;
                result &= zw.w == TestData_RHS[i].y;

                sbyte4 wx = TestData_LHS[i];
                wx.wx = TestData_RHS[i].xy;
                result &= wx.x == TestData_RHS[i].y;
                result &= wx.y == TestData_LHS[i].y;
                result &= wx.z == TestData_LHS[i].z;
                result &= wx.w == TestData_RHS[i].x;

                sbyte4 wy = TestData_LHS[i];
                wy.wy = TestData_RHS[i].xy;
                result &= wy.x == TestData_LHS[i].x;
                result &= wy.y == TestData_RHS[i].y;
                result &= wy.z == TestData_LHS[i].z;
                result &= wy.w == TestData_RHS[i].x;

                sbyte4 wz = TestData_LHS[i];
                wz.wz = TestData_RHS[i].xy;
                result &= wz.x == TestData_LHS[i].x;
                result &= wz.y == TestData_LHS[i].y;
                result &= wz.z == TestData_RHS[i].y;
                result &= wz.w == TestData_RHS[i].x;
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

                result &= x.SByte0 == TestData_LHS[i].x &
                          x.SByte1 == TestData_LHS[i].y &
                          x.SByte2 == TestData_LHS[i].z &
                          x.SByte3 == TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = TestData_LHS[i];
                v128 c = x;
                x = c;

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z &
                          x.w == TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short4 x = TestData_LHS[i];

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z &
                          x.w == TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort4 x = (ushort4)TestData_LHS[i];

                result &= x.x == (ushort)TestData_LHS[i].x &
                          x.y == (ushort)TestData_LHS[i].y &
                          x.z == (ushort)TestData_LHS[i].z &
                          x.w == (ushort)TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int4 x = TestData_LHS[i];

                result &= x.x == TestData_LHS[i].x &
                          x.y == TestData_LHS[i].y &
                          x.z == TestData_LHS[i].z &
                          x.w == TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToUInt()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint4 x = (uint4)TestData_LHS[i];

                result &= x.x == (uint)TestData_LHS[i].x &
                          x.y == (uint)TestData_LHS[i].y &
                          x.z == (uint)TestData_LHS[i].z &
                          x.w == (uint)TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long4 x = TestData_LHS[i];

                result &= x.x == (long)TestData_LHS[i].x &
                          x.y == (long)TestData_LHS[i].y &
                          x.z == (long)TestData_LHS[i].z &
                          x.w == (long)TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong4 x = (ulong4)TestData_LHS[i];

                result &= x.x == (ulong)TestData_LHS[i].x &
                          x.y == (ulong)TestData_LHS[i].y &
                          x.z == (ulong)TestData_LHS[i].z &
                          x.w == (ulong)TestData_LHS[i].w;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToFloat()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                float4 x = TestData_LHS[i];

                result &= maxmath.approx(x.x, (float)TestData_LHS[i].x) &
                          maxmath.approx(x.y, (float)TestData_LHS[i].y) &
                          maxmath.approx(x.z, (float)TestData_LHS[i].z) &
                          maxmath.approx(x.w, (float)TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToDouble()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                double4 x = TestData_LHS[i];

                result &= maxmath.approx(x.x, (double)TestData_LHS[i].x) &
                          maxmath.approx(x.y, (double)TestData_LHS[i].y) &
                          maxmath.approx(x.z, (double)TestData_LHS[i].z) &
                          maxmath.approx(x.w, (double)TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }
    }
}