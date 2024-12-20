using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_ulong2x2
    {
        private const int COLUMNS = 2;
        private const int ROWS = 2;


        [Test]
        public static void op_Increment()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 test = l;
                test++;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] + 1);
                }
            }
        }

        [Test]
        public static void op_Decrement()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 test = l;
                test--;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] - 1);
                }
            }
        }

        [Test]
        public static void op_Addition()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                ulong2x2 test = l + r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] + r[j]);
                }
            }
        }

        [Test]
        public static void op_Subtraction()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                ulong2x2 test = l - r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] - r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                ulong2x2 test = l * r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] * r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply_ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong r = rng.NextULong();

                ulong2x2 testL = l * r;
                ulong2x2 testR = r * l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] * r);
                    Assert.AreEqual(testR[j], r * l[j]);
                }
            }
        }

        [Test]
        public static void op_Division()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong2x2 test = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] / r[j]);
                }
            }
        }

        [Test]
        public static void op_Division_ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong r = rng.NextULong();
                r = (ulong)(r == 0 ? 1 : r);

                ulong2x2 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong l = rng.NextULong();

                ulong2x2 testR = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l / r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong2x2 test = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] % r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus_ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong r = rng.NextULong();
                r = (ulong)(r == 0 ? 1 : r);

                ulong2x2 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong l = rng.NextULong();

                ulong2x2 testR = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l % r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseAnd()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                ulong2x2 test = l & r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] & r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseOr()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                ulong2x2 test = l | r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] | r[j]);
                }
            }
        }

        [Test]
        public static void op_OnesComplement()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                ulong2x2 test = ~l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], ~l[j]);
                }
            }
        }

        [Test]
        public static void op_ExclusiveOr()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                ulong2x2 test = l ^ r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] ^ r[j]);
                }
            }
        }

        [Test]
        public static void op_LeftShift_int()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                int r = (int)rng.NextULong(0, 64);

                ulong2x2 test = l << r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] << r);
                }
            }
        }

        [Test]
        public static void op_RightShift_int()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                int r = (int)rng.NextULong(0, 64);

                ulong2x2 test = l >> r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >> r);
                }
            }
        }


        [Test]
        public static void op_Equality()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                bool2x2 test = l == r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] == r[j]);
                }
            }
        }

        [Test]
        public static void op_Inequality()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                bool2x2 test = l != r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] != r[j]);
                }
            }
        }

        [Test]
        public static void op_LessThan()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                bool2x2 test = l < r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] < r[j]);
                }
            }
        }

        [Test]
        public static void op_GreaterThan()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                bool2x2 test = l > r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] > r[j]);
                }
            }
        }

        [Test]
        public static void op_LessThanOrEqual()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                bool2x2 test = l <= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] <= r[j]);
                }
            }
        }

        [Test]
        public static void op_GreaterThanOrEqual()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                bool2x2 test = l >= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >= r[j]);
                }
            }
        }


        [Test]
        public static void op_ConvertFrom_ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong x = rng.NextULong();

                ulong2x2 test = x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    for (int k = 0; k < ROWS; k++)
                    {
                        Assert.AreEqual(test[j][k], x);
                    }
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x2 x = new long2x2(rng.NextLong2(), rng.NextLong2());

                ulong2x2 test = (ulong2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int2x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2x2 x = new int2x2(rng.NextInt2(), rng.NextInt2());

                ulong2x2 test = (ulong2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint2x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2x2 x = new uint2x2(rng.NextUInt2(), rng.NextUInt2());

                ulong2x2 test = (ulong2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float2x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2x2 x = new float2x2(rng.NextFloat2(0, 2f * ulong.MaxValue), rng.NextFloat2(0, 2f * ulong.MaxValue));

                ulong2x2 test = (ulong2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2x2 x = new double2x2(rng.NextDouble2(0, Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble2(0, Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1));

                ulong2x2 test = (ulong2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 x = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                int2x2 test = (int2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 x = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                uint2x2 test = (uint2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 x = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                float2x2 test = (float2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double2x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 x = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                double2x2 test = (double2x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (double2)x[j]);
                }
            }
        }


        [Test]
        public static void Equals()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x2 l = new ulong2x2(rng.NextULong2(), rng.NextULong2());
                ulong2x2 r = new ulong2x2(rng.NextULong2(), rng.NextULong2());

                bool test = l.Equals(r);
                bool cmp = true;

                for (int j = 0; j < COLUMNS; j++)
                {
                    cmp &= l[j].Equals(r[j]);
                }

                Assert.AreEqual(test, cmp);
                Assert.IsTrue(l.Equals(l));
            }
        }


        [Test]
        public static void get_Item_int()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2* columns = stackalloc ulong2[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextULong2();
                }

                ulong2x2 test = new ulong2x2(columns[0], columns[1]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}