using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_ushort3x2
    {
        private const int COLUMNS = 2;
        private const int ROWS = 3;


        [Test]
        public static void op_Increment()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 test = l;
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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 test = l;
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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ushort3x2 test = l + r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] + r[j]);
                }
            }
        }

        [Test]
        public static void op_Subtraction()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ushort3x2 test = l - r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] - r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ushort3x2 test = l * r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] * r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply_ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort r = rng.NextUShort();

                ushort3x2 testL = l * r;
                ushort3x2 testR = r * l;

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ushort3x2 test = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] / r[j]);
                }
            }
        }

        [Test]
        public static void op_Division_ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort r = rng.NextUShort();
                r = (ushort)(r == 0 ? 1 : r);

                ushort3x2 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ushort l = rng.NextUShort();

                ushort3x2 testR = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l / r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ushort3x2 test = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] % r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus_ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort r = rng.NextUShort();
                r = (ushort)(r == 0 ? 1 : r);

                ushort3x2 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                ushort l = rng.NextUShort();

                ushort3x2 testR = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l % r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseAnd()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ushort3x2 test = l & r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] & r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseOr()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ushort3x2 test = l | r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] | r[j]);
                }
            }
        }

        [Test]
        public static void op_OnesComplement()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ushort3x2 test = ~l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], ~l[j]);
                }
            }
        }

        [Test]
        public static void op_ExclusiveOr()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ushort3x2 test = l ^ r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] ^ r[j]);
                }
            }
        }

        [Test]
        public static void op_LeftShift_int()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort r = rng.NextUShort(0, 16);

                ushort3x2 test = l << r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] << r);
                }
            }
        }

        [Test]
        public static void op_RightShift_int()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort r = rng.NextUShort(0, 16);

                ushort3x2 test = l >> r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >> r);
                }
            }
        }


        [Test]
        public static void op_Equality()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                bool3x2 test = l >= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >= r[j]);
                }
            }
        }


        [Test]
        public static void op_ConvertFrom_ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort x = rng.NextUShort();

                ushort3x2 test = x;

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
        public static void op_ConvertFrom_short3x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3x2 x = new short3x2(rng.NextShort3(), rng.NextShort3());

                ushort3x2 test = (ushort3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
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

                ushort3x2 test = (ushort3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
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

                ushort3x2 test = (ushort3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
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

                ushort3x2 test = (ushort3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ulong3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x2 x = new ulong3x2(rng.NextULong3(), rng.NextULong3());

                ushort3x2 test = (ushort3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float3x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3x2 x = new float3x2(rng.NextFloat3(0, 2f * ushort.MaxValue), rng.NextFloat3(0, 2f * ushort.MaxValue));

                ushort3x2 test = (ushort3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double3x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3x2 x = new double3x2(rng.NextDouble3(0, 2d* ushort.MaxValue), rng.NextDouble3(0, 2d* ushort.MaxValue));

                ushort3x2 test = (ushort3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int3x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 x = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 x = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                uint3x2 test = (uint3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long3x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 x = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                long3x2 test = (long3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong3x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 x = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

                ulong3x2 test = (ulong3x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float3x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 x = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 x = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x2 l = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());
                ushort3x2 r = new ushort3x2(rng.NextUShort3(), rng.NextUShort3());

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
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3* columns = stackalloc ushort3[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextUShort3();
                }

                ushort3x2 test = new ushort3x2(columns[0], columns[1]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}