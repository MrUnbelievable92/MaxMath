using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_copysign
    {
        const int NUM_TESTS = 10;

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 x = rng.NextInt128();
                Int128 y = rng.NextInt128();

                Int128 z = maxmath.copysign(x, y);

                if (y < 0)
                {
                    Assert.AreEqual(z, -maxmath.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, maxmath.abs(x));
                }
            }
        }

        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte x = rng.NextSByte();
                sbyte y = rng.NextSByte();

                sbyte z = maxmath.copysign(x, y);

                if (y < 0)
                {
                    Assert.AreEqual(z, -maxmath.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, maxmath.abs(x));
                }
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 x = rng.NextSByte2();
                sbyte2 y = rng.NextSByte2();

                sbyte2 z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 x = rng.NextSByte2(0, sbyte.MaxValue);
                sbyte2 y = rng.NextSByte2();
                y = maxmath.select(y, 1, y == 0);

                sbyte2 z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte3 x = rng.NextSByte3();
                sbyte3 y = rng.NextSByte3();

                sbyte3 z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte3 x = rng.NextSByte3(0, sbyte.MaxValue);
                sbyte3 y = rng.NextSByte3();
                y = maxmath.select(y, 1, y == 0);

                sbyte3 z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = rng.NextSByte4();
                sbyte4 y = rng.NextSByte4();

                sbyte4 z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = rng.NextSByte4(0, sbyte.MaxValue);
                sbyte4 y = rng.NextSByte4();
                y = maxmath.select(y, 1, y == 0);

                sbyte4 z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = rng.NextSByte8();
                sbyte8 y = rng.NextSByte8();

                sbyte8 z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 x = rng.NextSByte8(0, sbyte.MaxValue);
                sbyte8 y = rng.NextSByte8();
                y = maxmath.select(y, 1, y == 0);

                sbyte8 z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = rng.NextSByte16();
                sbyte16 y = rng.NextSByte16();

                sbyte16 z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = rng.NextSByte16(0, sbyte.MaxValue);
                sbyte16 y = rng.NextSByte16();
                y = maxmath.select(y, 1, y == 0);

                sbyte16 z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = rng.NextSByte32();
                sbyte32 y = rng.NextSByte32();

                sbyte32 z = maxmath.copysign(x, y);

                for (int j = 0; j < 32; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 x = rng.NextSByte32(0, sbyte.MaxValue);
                sbyte32 y = rng.NextSByte32();
                y = maxmath.select(y, 1, y == 0);

                sbyte32 z = maxmath.copysign(x, y);

                for (int j = 0; j < 32; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short x = rng.NextShort();
                short y = rng.NextShort();

                short z = maxmath.copysign(x, y);

                if (y < 0)
                {
                    Assert.AreEqual(z, -maxmath.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, maxmath.abs(x));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short2 x = rng.NextShort2();
                short2 y = rng.NextShort2();

                short2 z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short2 x = rng.NextShort2(0, short.MaxValue);
                short2 y = rng.NextShort2();
                y = maxmath.select(y, 1, y == 0);

                short2 z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short3 x = rng.NextShort3();
                short3 y = rng.NextShort3();

                short3 z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short3 x = rng.NextShort3(0, short.MaxValue);
                short3 y = rng.NextShort3();
                y = maxmath.select(y, 1, y == 0);

                short3 z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short4 x = rng.NextShort4();
                short4 y = rng.NextShort4();

                short4 z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short4 x = rng.NextShort4(0, short.MaxValue);
                short4 y = rng.NextShort4();
                y = maxmath.select(y, 1, y == 0);

                short4 z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = rng.NextShort8();
                short8 y = rng.NextShort8();

                short8 z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 x = rng.NextShort8(0, short.MaxValue);
                short8 y = rng.NextShort8();
                y = maxmath.select(y, 1, y == 0);

                short8 z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = rng.NextShort16();
                short16 y = rng.NextShort16();

                short16 z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = rng.NextShort16(0, short.MaxValue);
                short16 y = rng.NextShort16();
                y = maxmath.select(y, 1, y == 0);

                short16 z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -maxmath.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int x = rng.NextInt();
                int y = rng.NextInt();

                int z = maxmath.copysign(x, y);

                if (y < 0)
                {
                    Assert.AreEqual(z, -math.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, math.abs(x));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int2 x = rng.NextInt2();
                int2 y = rng.NextInt2();

                int2 z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int2 x = rng.NextInt2(0, int.MaxValue);
                int2 y = rng.NextInt2();
                y = math.select(y, 1, y == 0);

                int2 z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int3 x = rng.NextInt3();
                int3 y = rng.NextInt3();

                int3 z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int3 x = rng.NextInt3(0, int.MaxValue);
                int3 y = rng.NextInt3();
                y = math.select(y, 1, y == 0);

                int3 z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int4 x = rng.NextInt4();
                int4 y = rng.NextInt4();

                int4 z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int4 x = rng.NextInt4(0, int.MaxValue);
                int4 y = rng.NextInt4();
                y = math.select(y, 1, y == 0);

                int4 z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = rng.NextInt8();
                int8 y = rng.NextInt8();

                int8 z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 x = rng.NextInt8(0, int.MaxValue);
                int8 y = rng.NextInt8();
                y = maxmath.select(y, 1, y == 0);

                int8 z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long x = rng.NextLong();
                long y = rng.NextLong();

                long z = maxmath.copysign(x, y);

                if (y < 0)
                {
                    Assert.AreEqual(z, -math.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, math.abs(x));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long2 x = rng.NextLong2();
                long2 y = rng.NextLong2();

                long2 z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long3 x = rng.NextLong3();
                long3 y = rng.NextLong3();

                long3 z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long4 x = rng.NextLong4();
                long4 y = rng.NextLong4();

                long4 z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }
        }


        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            quarter x;
            quarter y;
            quarter z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (quarter)rng.NextFloat();
                y = (quarter)rng.NextFloat();
                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, maxmath.nabs(x));
                }
                else
                {
                    Assert.AreEqual(z, maxmath.abs(x));
                }

                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, maxmath.nabs(x));
                }
                else
                {
                    Assert.AreEqual(z, maxmath.abs(x));
                }
            }

            x = (quarter)rng.NextFloat();
            y = (quarter)0f;
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, maxmath.abs(x));

            x = (quarter)rng.NextFloat();
            y = maxmath.asquarter(1 << 7);
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, maxmath.abs(x));
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            quarter2 x;
            quarter2 y;
            quarter2 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (quarter2)rng.NextFloat2();
                y = (quarter2)rng.NextFloat2();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (quarter2)rng.NextFloat2();
            y = (quarter)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (quarter2)rng.NextFloat2();
            y = maxmath.asquarter(1 << 7);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            quarter3 x;
            quarter3 y;
            quarter3 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (quarter3)rng.NextFloat3();
                y = (quarter3)rng.NextFloat3();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (quarter3)rng.NextFloat3();
            y = (quarter)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (quarter3)rng.NextFloat3();
            y = maxmath.asquarter(1 << 7);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            quarter4 x;
            quarter4 y;
            quarter4 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (quarter4)rng.NextFloat4();
                y = (quarter4)rng.NextFloat4();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (quarter4)rng.NextFloat4();
            y = (quarter)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (quarter4)rng.NextFloat4();
            y = maxmath.asquarter(1 << 7);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            quarter8 x;
            quarter8 y;
            quarter8 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (quarter8)rng.NextFloat8();
                y = (quarter8)rng.NextFloat8();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (quarter8)rng.NextFloat8();
            y = (quarter)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 8; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (quarter8)rng.NextFloat8();
            y = maxmath.asquarter(1 << 7);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 8; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            quarter16 x;
            quarter16 y;
            quarter16 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = new quarter16((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
                y = new quarter16((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = new quarter16((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
            y = (quarter)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 16; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = new quarter16((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
            y = maxmath.asquarter(1 << 7);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 16; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _quarter32()
        {
            Random32 rng = Random32.New;

            quarter32 x;
            quarter32 y;
            quarter32 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = new quarter32((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
                y = new quarter32((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 32; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 32; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = new quarter32((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
            y = (quarter)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 32; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = new quarter32((quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8(), (quarter8)rng.NextFloat8());
            y = maxmath.asquarter(1 << 7);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 32; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            half x;
            half y;
            half z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (half)rng.NextFloat();
                y = (half)rng.NextFloat();
                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, maxmath.nabs(x));
                }
                else
                {
                    Assert.AreEqual(z, maxmath.abs(x));
                }

                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, maxmath.nabs(x));
                }
                else
                {
                    Assert.AreEqual(z, maxmath.abs(x));
                }
            }

            x = (half)rng.NextFloat();
            y = (half)0f;
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, maxmath.abs(x));

            x = (half)rng.NextFloat();
            y = maxmath.ashalf(1 << 15);
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, maxmath.abs(x));
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            half2 x;
            half2 y;
            half2 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (half2)rng.NextFloat2();
                y = (half2)rng.NextFloat2();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (half2)rng.NextFloat2();
            y = (half)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (half2)rng.NextFloat2();
            y = maxmath.ashalf(1 << 15);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            half3 x;
            half3 y;
            half3 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (half3)rng.NextFloat3();
                y = (half3)rng.NextFloat3();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (half3)rng.NextFloat3();
            y = (half)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (half3)rng.NextFloat3();
            y = maxmath.ashalf(1 << 15);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            half4 x;
            half4 y;
            half4 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (half4)rng.NextFloat4();
                y = (half4)rng.NextFloat4();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (half4)rng.NextFloat4();
            y = (half)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (half4)rng.NextFloat4();
            y = maxmath.ashalf(1 << 15);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            half8 x;
            half8 y;
            half8 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = (half8)rng.NextFloat8();
                y = (half8)rng.NextFloat8();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = (half8)rng.NextFloat8();
            y = (half)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 8; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = (half8)rng.NextFloat8();
            y = maxmath.ashalf(1 << 15);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 8; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            half16 x;
            half16 y;
            half16 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = new half16((half8)rng.NextFloat8(), (half8)rng.NextFloat8());
                y = new half16((half8)rng.NextFloat8(), (half8)rng.NextFloat8());
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 16; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], maxmath.nabs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], maxmath.abs(x[j]));
                    }
                }
            }

            x = new half16((half8)rng.NextFloat8(), (half8)rng.NextFloat8());
            y = (half)0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 16; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }

            x = new half16((half8)rng.NextFloat8(), (half8)rng.NextFloat8());
            y = maxmath.ashalf(1 << 15);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 16; j++)
            {
                Assert.AreEqual(z[j], maxmath.abs(x[j]));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            float x;
            float y;
            float z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextFloat();
                y = rng.NextFloat();
                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, -math.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, math.abs(x));
                }

                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, -math.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, math.abs(x));
                }
            }

            x = rng.NextFloat();
            y = 0f;
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, math.abs(x));

            x = rng.NextFloat();
            y = math.asfloat(1 << 31);
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, math.abs(x));
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            float2 x;
            float2 y;
            float2 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextFloat2();
                y = rng.NextFloat2();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            x = rng.NextFloat2();
            y = 0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }

            x = rng.NextFloat2();
            y = math.asfloat(1 << 31);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            float3 x;
            float3 y;
            float3 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextFloat3();
                y = rng.NextFloat3();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            x = rng.NextFloat3();
            y = 0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }

            x = rng.NextFloat3();
            y = math.asfloat(1 << 31);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            float4 x;
            float4 y;
            float4 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextFloat4();
                y = rng.NextFloat4();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            x = rng.NextFloat4();
            y = 0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }

            x = rng.NextFloat4();
            y = math.asfloat(1 << 31);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            float8 x;
            float8 y;
            float8 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextFloat8();
                y = rng.NextFloat8();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 8; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            x = rng.NextFloat8();
            y = 0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 8; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }

            x = rng.NextFloat8();
            y = math.asfloat(1 << 31);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 8; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            double x;
            double y;
            double z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextDouble();
                y = rng.NextDouble();
                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, -math.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, math.abs(x));
                }

                z = maxmath.copysign(x, y);

                if (y < 0f)
                {
                    Assert.AreEqual(z, -math.abs(x));
                }
                else
                {
                    Assert.AreEqual(z, math.abs(x));
                }
            }

            x = rng.NextDouble();
            y = 0f;
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, math.abs(x));

            x = rng.NextDouble();
            y = math.asdouble(1L << 63);
            z = maxmath.copysign(x, y);
            Assert.AreEqual(z, math.abs(x));
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            double2 x;
            double2 y;
            double2 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextDouble2();
                y = rng.NextDouble2();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 2; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            x = rng.NextDouble2();
            y = 0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }

            x = rng.NextDouble2();
            y = math.asdouble(1L << 63);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 2; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            double3 x;
            double3 y;
            double3 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextDouble3();
                y = rng.NextDouble3();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 3; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            x = rng.NextDouble3();
            y = 0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }

            x = rng.NextDouble3();
            y = math.asdouble(1L << 63);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 3; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            double4 x;
            double4 y;
            double4 z;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                x = rng.NextDouble4();
                y = rng.NextDouble4();
                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }

                z = maxmath.copysign(x, y);

                for (int j = 0; j < 4; j++)
                {
                    if (y[j] < 0f)
                    {
                        Assert.AreEqual(z[j], -math.abs(x[j]));
                    }
                    else
                    {
                        Assert.AreEqual(z[j], math.abs(x[j]));
                    }
                }
            }

            x = rng.NextDouble4();
            y = 0f;
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }

            x = rng.NextDouble4();
            y = math.asdouble(1L << 63);
            z = maxmath.copysign(x, y);
            for (int j = 0; j < 4; j++)
            {
                Assert.AreEqual(z[j], math.abs(x[j]));
            }
        }
    }
}