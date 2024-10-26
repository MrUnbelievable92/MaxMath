using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_long2x4
    {
        private const int COLUMNS = 4;
        private const int ROWS = 2;


        [Test]
        public static void op_UnaryNegation()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 test = -l;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 test = l;
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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 test = l;
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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                long2x4 test = l + r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                long2x4 test = l - r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                long2x4 test = l * r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long r = rng.NextLong();

                long2x4 testL = l * r;
                long2x4 testR = r * l;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long2x4 test = l / r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long r = rng.NextLong();
                r = (long)(r == 0 ? 1 : r);

                long2x4 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long l = rng.NextLong();

                long2x4 testR = l / r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long2x4 test = l % r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long r = rng.NextLong();
                r = (long)(r == 0 ? 1 : r);

                long2x4 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long l = rng.NextLong();

                long2x4 testR = l % r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                long2x4 test = l & r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                long2x4 test = l | r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                long2x4 test = ~l;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                long2x4 test = l ^ r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                int r = (int)rng.NextLong(0, 64);

                long2x4 test = l << r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                int r = (int)rng.NextLong(0, 64);

                long2x4 test = l >> r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                bool2x4 test = l == r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                bool2x4 test = l != r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                bool2x4 test = l < r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                bool2x4 test = l > r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                bool2x4 test = l <= r;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                bool2x4 test = l >= r;

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

                long2x4 test = x;

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
        public static void op_ConvertFrom_ulong2x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x4 x = new ulong2x4(rng.NextULong2(), rng.NextULong2(), rng.NextULong2(), rng.NextULong2());

                long2x4 test = (long2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int2x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2x4 x = new int2x4(rng.NextInt2(), rng.NextInt2(), rng.NextInt2(), rng.NextInt2());

                long2x4 test = (long2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint2x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2x4 x = new uint2x4(rng.NextUInt2(), rng.NextUInt2(), rng.NextUInt2(), rng.NextUInt2());

                long2x4 test = (long2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float2x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2x4 x = new float2x4(rng.NextFloat2(2f * long.MinValue, 2f * long.MaxValue), rng.NextFloat2(2f * long.MinValue, 2f * long.MaxValue), rng.NextFloat2(2f * long.MinValue, 2f * long.MaxValue), rng.NextFloat2(2f * long.MinValue, 2f * long.MaxValue));

                long2x4 test = (long2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double2x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2x4 x = new double2x4(rng.NextDouble2(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble2(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble2(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble2(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1));

                long2x4 test = (long2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int2x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x4 x = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                int2x4 test = (int2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint2x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x4 x = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                uint2x4 test = (uint2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float2x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x4 x = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                float2x4 test = (float2x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double2x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x4 x = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                double2x4 test = (double2x4)x;

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
                long2x4 l = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());
                long2x4 r = new long2x4(rng.NextLong2(), rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

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
                long2* columns = stackalloc long2[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextLong2();
                }

                long2x4 test = new long2x4(columns[0], columns[1], columns[2], columns[3]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}