using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class t_byte2x3
    {
        private const int COLUMNS = 3;
        private const int ROWS = 2;


        [Test]
        public static void op_Increment()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 test = l;
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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 test = l;
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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                byte2x3 test = l + r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                byte2x3 test = l - r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                byte2x3 test = l * r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte r = rng.NextByte();

                byte2x3 testL = l * r;
                byte2x3 testR = r * l;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte2x3 test = l / r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte r = rng.NextByte();
                r = (byte)(r == 0 ? 1 : r);

                byte2x3 testL = l / r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] / r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte l = rng.NextByte();

                byte2x3 testR = l / r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte2x3 test = l % r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte r = rng.NextByte();
                r = (byte)(r == 0 ? 1 : r);

                byte2x3 testL = l % r;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(testL[j], l[j] % r);
                }
            }

            for (int i = 0; i < 16; i++)
            {
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                for (int j = 0; j < COLUMNS; j++)
                {
                    r[j] = maxmath.select(r[j], 1, r[j] == 0);
                }

                byte l = rng.NextByte();

                byte2x3 testR = l % r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                byte2x3 test = l & r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                byte2x3 test = l | r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                byte2x3 test = ~l;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                byte2x3 test = l ^ r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte r = rng.NextByte(0, 8);

                byte2x3 test = l << r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte r = rng.NextByte(0, 8);

                byte2x3 test = l >> r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                bool2x3 test = l == r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                bool2x3 test = l != r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                bool2x3 test = l < r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                bool2x3 test = l > r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                bool2x3 test = l <= r;

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
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                bool2x3 test = l >= r;

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

                byte2x3 test = x;

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
        public static void op_ConvertFrom_sbyte2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte2x3 x = new sbyte2x3(rng.NextSByte2(), rng.NextSByte2(), rng.NextSByte2());

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_short2x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2x3 x = new short2x3(rng.NextShort2(), rng.NextShort2(), rng.NextShort2());

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ushort2x3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort2x3 x = new ushort2x3(rng.NextUShort2(), rng.NextUShort2(), rng.NextUShort2());

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_int2x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2x3 x = new int2x3(rng.NextInt2(), rng.NextInt2(), rng.NextInt2());

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_uint2x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2x3 x = new uint2x3(rng.NextUInt2(), rng.NextUInt2(), rng.NextUInt2());

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_long2x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2x3 x = new long2x3(rng.NextLong2(), rng.NextLong2(), rng.NextLong2());

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_ulong2x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2x3 x = new ulong2x3(rng.NextULong2(), rng.NextULong2(), rng.NextULong2());

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_float2x3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2x3 x = new float2x3(rng.NextFloat2(0, 2f * byte.MaxValue), rng.NextFloat2(0, 2f * byte.MaxValue), rng.NextFloat2(0, 2f * byte.MaxValue));

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertFrom_double2x3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2x3 x = new double2x3(rng.NextDouble2(0, 2d* byte.MaxValue), rng.NextDouble2(0, 2d* byte.MaxValue), rng.NextDouble2(0, 2d* byte.MaxValue));

                byte2x3 test = (byte2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (byte2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_short2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                short2x3 test = (short2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (short2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ushort2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                ushort2x3 test = (ushort2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ushort2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_int2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                int2x3 test = (int2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (int2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_uint2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                uint2x3 test = (uint2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (uint2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_long2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                long2x3 test = (long2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (long2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_ulong2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                ulong2x3 test = (ulong2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (ulong2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_float2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                float2x3 test = (float2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (float2)x[j]);
                }
            }
        }

        [Test]
        public static void op_ConvertTo_double2x3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 x = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

                double2x3 test = (double2x3)x;

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], (double2)x[j]);
                }
            }
        }


        [Test]
        public static void Equals()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2x3 l = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());
                byte2x3 r = new byte2x3(rng.NextByte2(), rng.NextByte2(), rng.NextByte2());

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
                byte2* columns = stackalloc byte2[COLUMNS];

                for (int j = 0; j < COLUMNS; j++)
                {
                    columns[i] = rng.NextByte2();
                }

                byte2x3 test = new byte2x3(columns[0], columns[1], columns[2]);

                for (int j = 0; j < COLUMNS; j++)
                {
                    Assert.AreEqual(test[j], columns[j]);
                }
            }
        }
    }
}