using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_long3x3
    {
        private const int COLUMNS = 3;
        private const int ROWS = 3;


        [Test]
        public static void op_UnaryNegation()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 test = -l;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 test = l;
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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 test = l;
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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                long3x3 test = l + r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                long3x3 test = l - r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                long3x3 test = l * r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long r = rng.NextLong();

                long3x3 testL = l * r;
                long3x3 testR = r * l;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long3x3 test = l / r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long r = rng.NextLong();
                r = (long)(r == 0 ? 1 : r);

                long3x3 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long l = rng.NextLong();

                long3x3 testR = l / r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long3x3 test = l % r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long r = rng.NextLong();
                r = (long)(r == 0 ? 1 : r);

                long3x3 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                long l = rng.NextLong();

                long3x3 testR = l % r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                long3x3 test = l & r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                long3x3 test = l | r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                long3x3 test = ~l;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                long3x3 test = l ^ r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                int r = (int)rng.NextLong(0, 64);

                long3x3 test = l << r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                int r = (int)rng.NextLong(0, 64);

                long3x3 test = l >> r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                bool3x3 test = l == r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                bool3x3 test = l != r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                bool3x3 test = l < r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                bool3x3 test = l > r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                bool3x3 test = l <= r;

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
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                bool3x3 test = l >= r;

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

                long3x3 test = x;

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
        public static void op_ConvertFrom_ulong3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x3 x = new ulong3x3(rng.NextULong3(), rng.NextULong3(), rng.NextULong3());

                long3x3 test = (long3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int3x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int3x3 x = new int3x3(rng.NextInt3(), rng.NextInt3(), rng.NextInt3());

                long3x3 test = (long3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint3x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint3x3 x = new uint3x3(rng.NextUInt3(), rng.NextUInt3(), rng.NextUInt3());

                long3x3 test = (long3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float3x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3x3 x = new float3x3(rng.NextFloat3(2f * long.MinValue, 2f * long.MaxValue), rng.NextFloat3(2f * long.MinValue, 2f * long.MaxValue), rng.NextFloat3(2f * long.MinValue, 2f * long.MaxValue));

                long3x3 test = (long3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3x3 x = new double3x3(rng.NextDouble3(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble3(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble3(-(long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG, (long)Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1));

                long3x3 test = (long3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x3 x = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                int3x3 test = (int3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x3 x = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                uint3x3 test = (uint3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x3 x = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                float3x3 test = (float3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x3 x = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                double3x3 test = (double3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (double3)x[j]);
                }
            }
        }


        [Test]
        public static void Equals()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x3 l = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());
                long3x3 r = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

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
                long3* columns = stackalloc long3[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextLong3();
                }

                long3x3 test = new long3x3(columns[0], columns[1], columns[2]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}