using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_byte3x3
    {
        private const int COLUMNS = 3;
        private const int ROWS = 3;


        [Test]
        public static void op_Increment()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 test = l;
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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 test = l;
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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                byte3x3 test = l + r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                byte3x3 test = l - r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                byte3x3 test = l * r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte r = rng.NextByte();

                byte3x3 testL = l * r;
                byte3x3 testR = r * l;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte3x3 test = l / r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte r = rng.NextByte();
                r = (byte)(r == 0 ? 1 : r);

                byte3x3 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte l = rng.NextByte();

                byte3x3 testR = l / r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte3x3 test = l % r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte r = rng.NextByte();
                r = (byte)(r == 0 ? 1 : r);

                byte3x3 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte l = rng.NextByte();

                byte3x3 testR = l % r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                byte3x3 test = l & r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                byte3x3 test = l | r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                byte3x3 test = ~l;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                byte3x3 test = l ^ r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte r = rng.NextByte(0, 8);

                byte3x3 test = l << r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte r = rng.NextByte(0, 8);

                byte3x3 test = l >> r;

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
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                bool3x3 test = l >= r;

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

                byte3x3 test = x;

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
        public static void op_ConvertFrom_sbyte3x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3x3 x = new sbyte3x3(rng.NextSByte3(), rng.NextSByte3(), rng.NextSByte3());

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_short3x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3x3 x = new short3x3(rng.NextShort3(), rng.NextShort3(), rng.NextShort3());

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ushort3x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3x3 x = new ushort3x3(rng.NextUShort3(), rng.NextUShort3(), rng.NextUShort3());

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
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

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
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

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3x3 x = new long3x3(rng.NextLong3(), rng.NextLong3(), rng.NextLong3());

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
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

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float3x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3x3 x = new float3x3(rng.NextFloat3(0, 2f * byte.MaxValue), rng.NextFloat3(0, 2f * byte.MaxValue), rng.NextFloat3(0, 2f * byte.MaxValue));

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double3x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3x3 x = new double3x3(rng.NextDouble3(0, 2d* byte.MaxValue), rng.NextDouble3(0, 2d* byte.MaxValue), rng.NextDouble3(0, 2d* byte.MaxValue));

                byte3x3 test = (byte3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_short3x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                short3x3 test = (short3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ushort3x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                ushort3x3 test = (ushort3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int3x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                uint3x3 test = (uint3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long3x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                long3x3 test = (long3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong3x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

                ulong3x3 test = (ulong3x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong3)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float3x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 x = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3x3 l = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());
                byte3x3 r = new byte3x3(rng.NextByte3(), rng.NextByte3(), rng.NextByte3());

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
                byte3* columns = stackalloc byte3[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextByte3();
                }

                byte3x3 test = new byte3x3(columns[0], columns[1], columns[2]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}