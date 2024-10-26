using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_ulong3x2
    {
        private const int COLUMNS = 2;
        private const int ROWS = 3;


        [Test]
        public static void op_Increment()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 test = l;
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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 test = l;
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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ulong3x2 test = l + r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ulong3x2 test = l - r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ulong3x2 test = l * r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong r = rng.NextULong();

                ulong3x2 testL = l * r;
                ulong3x2 testR = r * l;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong3x2 test = l / r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong r = rng.NextULong();
                r = (ulong)(r == 0 ? 1 : r);

                ulong3x2 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong l = rng.NextULong();

                ulong3x2 testR = l / r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong3x2 test = l % r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong r = rng.NextULong();
                r = (ulong)(r == 0 ? 1 : r);

                ulong3x2 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ulong l = rng.NextULong();

                ulong3x2 testR = l % r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ulong3x2 test = l & r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ulong3x2 test = l | r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ulong3x2 test = ~l;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ulong3x2 test = l ^ r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                int r = (int)rng.NextULong(0, 64);

                ulong3x2 test = l << r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                int r = (int)rng.NextULong(0, 64);

                ulong3x2 test = l >> r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                bool3x2 test = l == r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                bool3x2 test = l != r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                bool3x2 test = l < r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                bool3x2 test = l > r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                bool3x2 test = l <= r;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                bool3x2 test = l >= r;

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

                ulong3x2 test = x;

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
        public static void op_ConvertFrom_long3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x2 x = new long3x2(rng.NextLong3(), rng.NextLong3());

                ulong3x2 test = (ulong3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int3x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int3x2 x = new int3x2(rng.NextInt3(), rng.NextInt3());

                ulong3x2 test = (ulong3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint3x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint3x2 x = new uint3x2(rng.NextUInt3(), rng.NextUInt3());

                ulong3x2 test = (ulong3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float3x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3x2 x = new float3x2(rng.NextFloat3(0, 2f * ulong.MaxValue), rng.NextFloat3(0, 2f * ulong.MaxValue));

                ulong3x2 test = (ulong3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3x2 x = new double3x2(rng.NextDouble3(0, Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1), rng.NextDouble3(0, Helper.MAX_MONO_RUNTIME_CVT_DOUBLE_LONG + 1));

                ulong3x2 test = (ulong3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 x = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                int3x2 test = (int3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 x = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                uint3x2 test = (uint3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 x = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                float3x2 test = (float3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 x = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                double3x2 test = (double3x2)x;

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
                ulong3x2 l = new ulong3x2(rng.NextULong3(), rng.NextULong3());
                ulong3x2 r = new ulong3x2(rng.NextULong3(), rng.NextULong3());

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
                ulong3* columns = stackalloc ulong3[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextULong3();
                }

                ulong3x2 test = new ulong3x2(columns[0], columns[1]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}