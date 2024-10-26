using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_sbyte4x4
    {
        private const int COLUMNS = 4;
        private const int ROWS = 4;


        [Test]
        public static void op_UnaryNegation()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 test = -l;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], -l[j]);
                }
            }
        }

        [Test]
        public static void op_Increment()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 test = l;
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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 test = l;
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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                sbyte4x4 test = l + r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                sbyte4x4 test = l - r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                sbyte4x4 test = l * r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] * r[j]);
                }
            }
        }

        [Test]
        public static void op_Multiply_sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte r = rng.NextSByte();

                sbyte4x4 testL = l * r;
                sbyte4x4 testR = r * l;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte4x4 test = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] / r[j]);
                }
            }
        }

        [Test]
        public static void op_Division_sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte r = rng.NextSByte();
                r = (sbyte)(r == 0 ? 1 : r);

                sbyte4x4 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte l = rng.NextSByte();

                sbyte4x4 testR = l / r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte4x4 test = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] % r[j]);
                }
            }
        }

        [Test]
        public static void op_Modulus_sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte r = rng.NextSByte();
                r = (sbyte)(r == 0 ? 1 : r);

                sbyte4x4 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte l = rng.NextSByte();

                sbyte4x4 testR = l % r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                sbyte4x4 test = l & r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                sbyte4x4 test = l | r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                sbyte4x4 test = ~l;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                sbyte4x4 test = l ^ r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte r = rng.NextSByte(0, 8);

                sbyte4x4 test = l << r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte r = rng.NextSByte(0, 8);

                sbyte4x4 test = l >> r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                bool4x4 test = l == r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                bool4x4 test = l != r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                bool4x4 test = l < r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                bool4x4 test = l > r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                bool4x4 test = l <= r;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                bool4x4 test = l >= r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], l[j] >= r[j]);
                }
            }
        }


        [Test]
        public static void op_ConvertFrom_sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte x = rng.NextSByte();

                sbyte4x4 test = x;

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
        public static void op_ConvertFrom_byte4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4x4 x = new byte4x4(rng.NextByte4(), rng.NextByte4(), rng.NextByte4(), rng.NextByte4());

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_short4x4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4x4 x = new short4x4(rng.NextShort4(), rng.NextShort4(), rng.NextShort4(), rng.NextShort4());

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ushort4x4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4x4 x = new ushort4x4(rng.NextUShort4(), rng.NextUShort4(), rng.NextUShort4(), rng.NextUShort4());

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int4x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int4x4 x = new int4x4(rng.NextInt4(), rng.NextInt4(), rng.NextInt4(), rng.NextInt4());

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint4x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint4x4 x = new uint4x4(rng.NextUInt4(), rng.NextUInt4(), rng.NextUInt4(), rng.NextUInt4());

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long4x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4x4 x = new long4x4(rng.NextLong4(), rng.NextLong4(), rng.NextLong4(), rng.NextLong4());

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ulong4x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong4x4 x = new ulong4x4(rng.NextULong4(), rng.NextULong4(), rng.NextULong4(), rng.NextULong4());

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float4x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4x4 x = new float4x4(rng.NextFloat4(2f * sbyte.MinValue, 2f * sbyte.MaxValue), rng.NextFloat4(2f * sbyte.MinValue, 2f * sbyte.MaxValue), rng.NextFloat4(2f * sbyte.MinValue, 2f * sbyte.MaxValue), rng.NextFloat4(2f * sbyte.MinValue, 2f * sbyte.MaxValue));

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double4x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4x4 x = new double4x4(rng.NextDouble4(2d * sbyte.MinValue, 2d* sbyte.MaxValue), rng.NextDouble4(2d * sbyte.MinValue, 2d* sbyte.MaxValue), rng.NextDouble4(2d * sbyte.MinValue, 2d* sbyte.MaxValue), rng.NextDouble4(2d * sbyte.MinValue, 2d* sbyte.MaxValue));

                sbyte4x4 test = (sbyte4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_short4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                short4x4 test = (short4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ushort4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                ushort4x4 test = (ushort4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                int4x4 test = (int4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                uint4x4 test = (uint4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                long4x4 test = (long4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                ulong4x4 test = (ulong4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                float4x4 test = (float4x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float4)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double4x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4x4 x = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

                double4x4 test = (double4x4)x;

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
                sbyte4x4 l = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());
                sbyte4x4 r = new sbyte4x4(rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4(), rng.NextSByte4());

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
                sbyte4* columns = stackalloc sbyte4[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextSByte4();
                }

                sbyte4x4 test = new sbyte4x4(columns[0], columns[1], columns[2], columns[3]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}