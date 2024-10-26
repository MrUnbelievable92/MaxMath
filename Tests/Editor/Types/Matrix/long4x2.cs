using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_long4x2
    {
        private const int COLUMNS = 2;
        private const int ROWS = 4;


        [Test]
        public static void op_UnaryNegation()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 test = -l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], -l[j]);
                }
            }
        }

        [Test]
        public static void op_Increment()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 test = l;
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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 test = l;
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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                long4x2 test = l + r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                long4x2 test = l - r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                long4x2 test = l * r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] * r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply_long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long r = rng.NextLong();

                long4x2 testL = l * r;
                long4x2 testR = r * l;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long4x2 test = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] / r[j]);
                }
            }
        }

        [Test]
        public static void op_Division_long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long r = rng.NextLong();
                r = (long)(r == 0 ? 1 : r);

                long4x2 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long l = rng.NextLong();

                long4x2 testR = l / r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long4x2 test = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] % r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus_long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long r = rng.NextLong();
                r = (long)(r == 0 ? 1 : r);

                long4x2 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long l = rng.NextLong();

                long4x2 testR = l % r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                long4x2 test = l & r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                long4x2 test = l | r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());

                long4x2 test = ~l;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                long4x2 test = l ^ r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                int r = (int)rng.NextLong(0, 64);

                long4x2 test = l << r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                int r = (int)rng.NextLong(0, 64);

                long4x2 test = l >> r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                bool4x2 test = l == r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                bool4x2 test = l != r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                bool4x2 test = l < r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                bool4x2 test = l > r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                bool4x2 test = l <= r;

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
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

                bool4x2 test = l >= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >= r[j]);
                }
            }
        }


        [Test]
        public static void op_ConvertFrom_long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long x = rng.NextLong();

                long4x2 test = x;

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
        public static void op_ConvertFrom_ulong4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong4x2 x = new ulong4x2(rng.NextULong4(), rng.NextULong4());

                long4x2 test = (long4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int4x2 x = new int4x2(rng.NextInt4(), rng.NextInt4());

                long4x2 test = (long4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint4x2 x = new uint4x2(rng.NextUInt4(), rng.NextUInt4());

                long4x2 test = (long4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4x2 x = new float4x2(rng.NextFloat4(2f * long.MinValue, 2f * long.MaxValue), rng.NextFloat4(2f * long.MinValue, 2f * long.MaxValue));

                long4x2 test = (long4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4x2 x = new double4x2(rng.NextDouble4(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble4(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1));

                long4x2 test = (long4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 x = new long4x2(rng.NextLong4(), rng.NextLong4());

                int4x2 test = (int4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 x = new long4x2(rng.NextLong4(), rng.NextLong4());

                uint4x2 test = (uint4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 x = new long4x2(rng.NextLong4(), rng.NextLong4());

                float4x2 test = (float4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 x = new long4x2(rng.NextLong4(), rng.NextLong4());

                double4x2 test = (double4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (double4)x[j]);
                }
            }
        }


        [Test]
        public static void Equals()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 l = new long4x2(rng.NextLong4(), rng.NextLong4());
                long4x2 r = new long4x2(rng.NextLong4(), rng.NextLong4());

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
                long4* columns = stackalloc long4[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextLong4();
                }

                long4x2 test = new long4x2(columns[0], columns[1]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}