using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_byte4x2
    {
        private const int COLUMNS = 2;
        private const int ROWS = 4;


        [Test]
        public static void op_Increment()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 test = l;
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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 test = l;
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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                byte4x2 test = l + r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] + r[j]);
                }
            }
        }

        [Test]
        public static void op_Subtraction()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                byte4x2 test = l - r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] - r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                byte4x2 test = l * r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] * r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply_byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte r = rng.NextByte();

                byte4x2 testL = l * r;
                byte4x2 testR = r * l;

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte4x2 test = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] / r[j]);
                }
            }
        }

        [Test]
        public static void op_Division_byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte r = rng.NextByte();
                r = (byte)(r == 0 ? 1 : r);

                byte4x2 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte l = rng.NextByte();

                byte4x2 testR = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l / r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte4x2 test = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] % r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus_byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte r = rng.NextByte();
                r = (byte)(r == 0 ? 1 : r);

                byte4x2 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte l = rng.NextByte();

                byte4x2 testR = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testR[j], l % r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseAnd()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                byte4x2 test = l & r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] & r[j]);
                }
            }
        }

        [Test]
        public static void op_BitwiseOr()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                byte4x2 test = l | r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] | r[j]);
                }
            }
        }

        [Test]
        public static void op_OnesComplement()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());

                byte4x2 test = ~l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], ~l[j]);
                }
            }
        }

        [Test]
        public static void op_ExclusiveOr()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                byte4x2 test = l ^ r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] ^ r[j]);
                }
            }
        }

        [Test]
        public static void op_LeftShift_int()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte r = rng.NextByte(0, 8);

                byte4x2 test = l << r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] << r);
                }
            }
        }

        [Test]
        public static void op_RightShift_int()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte r = rng.NextByte(0, 8);

                byte4x2 test = l >> r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >> r);
                }
            }
        }


        [Test]
        public static void op_Equality()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

                bool4x2 test = l >= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >= r[j]);
                }
            }
        }


        [Test]
        public static void op_ConvertFrom_byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte x = rng.NextByte();

                byte4x2 test = x;

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
        public static void op_ConvertFrom_sbyte4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x2 x = new sbyte4x2(rng.NextSByte4(), rng.NextSByte4());

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_short4x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x2 x = new short4x2(rng.NextShort4(), rng.NextShort4());

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ushort4x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4x2 x = new ushort4x2(rng.NextUShort4(), rng.NextUShort4());

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
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

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
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

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x2 x = new long4x2(rng.NextLong4(), rng.NextLong4());

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
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

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4x2 x = new float4x2(rng.NextFloat4(0, 2f * byte.MaxValue), rng.NextFloat4(0, 2f * byte.MaxValue));

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4x2 x = new double4x2(rng.NextDouble4(0, 2d* byte.MaxValue), rng.NextDouble4(0, 2d* byte.MaxValue));

                byte4x2 test = (byte4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_short4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

                short4x2 test = (short4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ushort4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

                ushort4x2 test = (ushort4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

                uint4x2 test = (uint4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

                long4x2 test = (long4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

                ulong4x2 test = (ulong4x2)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 x = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x2 l = new byte4x2(rng.NextByte4(), rng.NextByte4());
                byte4x2 r = new byte4x2(rng.NextByte4(), rng.NextByte4());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4* columns = stackalloc byte4[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextByte4();
                }

                byte4x2 test = new byte4x2(columns[0], columns[1]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}