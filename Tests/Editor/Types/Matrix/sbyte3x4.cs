using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_sbyte3x4
    {
        private const int COLUMNS = 4;
        private const int ROWS = 3;


        [Test]
        public static void op_UnaryNegation()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 test = -l;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 test = l;
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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 test = l;
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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                sbyte3x4 test = l + r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                sbyte3x4 test = l - r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                sbyte3x4 test = l * r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte r = rng.NextSByte();

                sbyte3x4 testL = l * r;
                sbyte3x4 testR = r * l;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte3x4 test = l / r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte r = rng.NextSByte();
                r = (sbyte)(r == 0 ? 1 : r);

                sbyte3x4 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte l = rng.NextSByte();

                sbyte3x4 testR = l / r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte3x4 test = l % r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte r = rng.NextSByte();
                r = (sbyte)(r == 0 ? 1 : r);

                sbyte3x4 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                sbyte l = rng.NextSByte();

                sbyte3x4 testR = l % r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                sbyte3x4 test = l & r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                sbyte3x4 test = l | r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                sbyte3x4 test = ~l;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                sbyte3x4 test = l ^ r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte r = rng.NextSByte(0, 8);

                sbyte3x4 test = l << r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte r = rng.NextSByte(0, 8);

                sbyte3x4 test = l >> r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                bool3x4 test = l == r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                bool3x4 test = l != r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                bool3x4 test = l < r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                bool3x4 test = l > r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                bool3x4 test = l <= r;

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
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                bool3x4 test = l >= r;

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

                sbyte3x4 test = x;

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
        public static void op_ConvertFrom_byte3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x4 x = new byte3x4(rng.NextByte3(), rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_short3x4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3x4 x = new short3x4(rng.NextShort3(), rng.NextShort3(), rng.NextShort3(), rng.NextShort3());

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ushort3x4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x4 x = new ushort3x4(rng.NextUShort3(), rng.NextUShort3(), rng.NextUShort3(), rng.NextUShort3());

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int3x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int3x4 x = new int3x4(rng.NextInt3(), rng.NextInt3(), rng.NextInt3(), rng.NextInt3());

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint3x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint3x4 x = new uint3x4(rng.NextUInt3(), rng.NextUInt3(), rng.NextUInt3(), rng.NextUInt3());

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long3x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x4 x = new long3x4(rng.NextLong3(), rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ulong3x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3x4 x = new ulong3x4(rng.NextULong3(), rng.NextULong3(), rng.NextULong3(), rng.NextULong3());

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float3x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3x4 x = new float3x4(rng.NextFloat3(2f * sbyte.MinValue, 2f * sbyte.MaxValue), rng.NextFloat3(2f * sbyte.MinValue, 2f * sbyte.MaxValue), rng.NextFloat3(2f * sbyte.MinValue, 2f * sbyte.MaxValue), rng.NextFloat3(2f * sbyte.MinValue, 2f * sbyte.MaxValue));

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double3x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3x4 x = new double3x4(rng.NextDouble3(2d * sbyte.MinValue, 2d* sbyte.MaxValue), rng.NextDouble3(2d * sbyte.MinValue, 2d* sbyte.MaxValue), rng.NextDouble3(2d * sbyte.MinValue, 2d* sbyte.MaxValue), rng.NextDouble3(2d * sbyte.MinValue, 2d* sbyte.MaxValue));

                sbyte3x4 test = (sbyte3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (sbyte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_short3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                short3x4 test = (short3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ushort3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                ushort3x4 test = (ushort3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                int3x4 test = (int3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                uint3x4 test = (uint3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                long3x4 test = (long3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                ulong3x4 test = (ulong3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                float3x4 test = (float3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double3x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 x = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                double3x4 test = (double3x4)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (double3)x[j]);
                }
            }
        }


        [Test]
        public static void Equals()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x4 l = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());
                sbyte3x4 r = new sbyte3x4(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

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
                sbyte3* columns = stackalloc sbyte3[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextSByte3();
                }

                sbyte3x4 test = new sbyte3x4(columns[0], columns[1], columns[2], columns[3]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}