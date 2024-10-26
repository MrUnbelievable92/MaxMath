using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_short4x3
    {
        private const int COLUMNS = 3;
        private const int ROWS = 4;


        [Test]
        public static void op_UnaryNegation()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 test = -l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], -l[j]);
                }
            }
        }

        [Test]
        public static void op_Increment()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 test = l;
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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 test = l;
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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                short4x3 test = l + r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                short4x3 test = l - r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                short4x3 test = l * r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] * r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short r = rng.NextShort();

                short4x3 testL = l * r;
                short4x3 testR = r * l;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short4x3 test = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] / r[j]);
                }
            }
        }

        [Test]
        public static void op_Division_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short r = rng.NextShort();
                r = (short)(r == 0 ? 1 : r);

                short4x3 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short l = rng.NextShort();

                short4x3 testR = l / r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short4x3 test = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] % r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short r = rng.NextShort();
                r = (short)(r == 0 ? 1 : r);

                short4x3 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                short l = rng.NextShort();

                short4x3 testR = l % r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                short4x3 test = l & r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                short4x3 test = l | r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                short4x3 test = ~l;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                short4x3 test = l ^ r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short r = rng.NextShort(0, 16);

                short4x3 test = l << r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short r = rng.NextShort(0, 16);

                short4x3 test = l >> r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                bool4x3 test = l == r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                bool4x3 test = l != r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                bool4x3 test = l < r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                bool4x3 test = l > r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                bool4x3 test = l <= r;

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
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                bool4x3 test = l >= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >= r[j]);
                }
            }
        }


        [Test]
        public static void op_ConvertFrom_short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short x = rng.NextShort();

                short4x3 test = x;

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
        public static void op_ConvertFrom_ushort4x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4x3 x = new ushort4x3(rng.NextUShort4(), rng.NextUShort4(), rng.NextUShort4());

                short4x3 test = (short4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int4x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int4x3 x = new int4x3(rng.NextInt4(), rng.NextInt4(), rng.NextInt4());

                short4x3 test = (short4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint4x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint4x3 x = new uint4x3(rng.NextUInt4(), rng.NextUInt4(), rng.NextUInt4());

                short4x3 test = (short4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long4x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x3 x = new long4x3(rng.NextLong4(), rng.NextLong4(), rng.NextLong4());

                short4x3 test = (short4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ulong4x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong4x3 x = new ulong4x3(rng.NextULong4(), rng.NextULong4(), rng.NextULong4());

                short4x3 test = (short4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float4x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4x3 x = new float4x3(rng.NextFloat4(2f * short.MinValue, 2f * short.MaxValue), rng.NextFloat4(2f * short.MinValue, 2f * short.MaxValue), rng.NextFloat4(2f * short.MinValue, 2f * short.MaxValue));

                short4x3 test = (short4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double4x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4x3 x = new double4x3(rng.NextDouble4(2d * short.MinValue, 2d* short.MaxValue), rng.NextDouble4(2d * short.MinValue, 2d* short.MaxValue), rng.NextDouble4(2d * short.MinValue, 2d* short.MaxValue));

                short4x3 test = (short4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int4x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 x = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                int4x3 test = (int4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint4x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 x = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                uint4x3 test = (uint4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long4x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 x = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                long4x3 test = (long4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong4x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 x = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                ulong4x3 test = (ulong4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float4x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 x = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                float4x3 test = (float4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double4x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 x = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                double4x3 test = (double4x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (double4)x[j]);
                }
            }
        }


        [Test]
        public static void Equals()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x3 l = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());
                short4x3 r = new short4x3(rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

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
                short4* columns = stackalloc short4[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextShort4();
                }

                short4x3 test = new short4x3(columns[0], columns[1], columns[2]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}