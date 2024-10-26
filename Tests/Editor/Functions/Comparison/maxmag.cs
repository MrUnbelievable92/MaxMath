using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_maxmag
    {
        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 8; i++)
            {
                Int128 l = rng.NextInt128();
                Int128 r = rng.NextInt128();

                Assert.AreEqual(maxmath.abs(maxmath.maxmag(l, r)), maxmath.max(maxmath.abs(l), maxmath.abs(r)));

                if (maxmath.abs(l) == maxmath.abs(r)) continue;

                if (maxmath.abs(l) == maxmath.abs(maxmath.maxmag(l, r)))
                {
                    Assert.AreEqual(l, maxmath.maxmag(l, r));
                }
                else
                {
                    Assert.AreEqual(r, maxmath.maxmag(l, r));
                }
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte l = rng.NextSByte();
                sbyte r = rng.NextSByte();

                Assert.AreEqual(maxmath.abs(maxmath.maxmag(l, r)), maxmath.max(maxmath.abs(l), maxmath.abs(r)));

                if (maxmath.abs(l) == maxmath.abs(r)) continue;

                if (maxmath.abs(l) == maxmath.abs(maxmath.maxmag(l, r)))
                {
                    Assert.AreEqual(l, maxmath.maxmag(l, r));
                }
                else
                {
                    Assert.AreEqual(r, maxmath.maxmag(l, r));
                }
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2();

                sbyte2 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3();

                sbyte3 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4();

                sbyte4 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8();

                sbyte8 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16();

                sbyte16 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32();

                sbyte32 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short l = rng.NextShort();
                short r = rng.NextShort();

                Assert.AreEqual(maxmath.abs(maxmath.maxmag(l, r)), maxmath.max(maxmath.abs(l), maxmath.abs(r)));

                if (maxmath.abs(l) == maxmath.abs(r)) continue;

                if (maxmath.abs(l) == maxmath.abs(maxmath.maxmag(l, r)))
                {
                    Assert.AreEqual(l, maxmath.maxmag(l, r));
                }
                else
                {
                    Assert.AreEqual(r, maxmath.maxmag(l, r));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2();

                short2 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3();

                short3 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4();

                short4 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8();

                short8 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16();

                short16 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == maxmath.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int l = rng.NextInt();
                int r = rng.NextInt();

                Assert.AreEqual(math.abs(maxmath.maxmag(l, r)), math.max(math.abs(l), math.abs(r)));

                if (math.abs(l) == math.abs(r)) continue;

                if (math.abs(l) == math.abs(maxmath.maxmag(l, r)))
                {
                    Assert.AreEqual(l, maxmath.maxmag(l, r));
                }
                else
                {
                    Assert.AreEqual(r, maxmath.maxmag(l, r));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2();

                int2 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3();

                int3 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4();

                int4 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8();

                int8 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long l = rng.NextLong();
                long r = rng.NextLong();

                Assert.AreEqual(math.abs(maxmath.maxmag(l, r)), math.max(math.abs(l), math.abs(r)));

                if (math.abs(l) == math.abs(r)) continue;

                if (math.abs(l) == math.abs(maxmath.maxmag(l, r)))
                {
                    Assert.AreEqual(l, maxmath.maxmag(l, r));
                }
                else
                {
                    Assert.AreEqual(r, maxmath.maxmag(l, r));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2();

                long2 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3();

                long3 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4();

                long4 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float l = rng.NextFloat();
                float r = rng.NextFloat();

                Assert.AreEqual(math.abs(maxmath.maxmag(l, r)), math.max(math.abs(l), math.abs(r)));

                if (math.abs(l) == math.abs(r)) continue;

                if (math.abs(l) == math.abs(maxmath.maxmag(l, r)))
                {
                    Assert.AreEqual(l, maxmath.maxmag(l, r));
                }
                else
                {
                    Assert.AreEqual(r, maxmath.maxmag(l, r));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float2 l = rng.NextFloat2();
                float2 r = rng.NextFloat2();

                float2 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float3 l = rng.NextFloat3();
                float3 r = rng.NextFloat3();

                float3 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float4 l = rng.NextFloat4();
                float4 r = rng.NextFloat4();

                float4 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                float8 l = rng.NextFloat8();
                float8 r = rng.NextFloat8();

                float8 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), maxmath.max(maxmath.abs(l), maxmath.abs(r))[j]);

                    if (maxmath.abs(l)[j] == maxmath.abs(r)[j]) continue;

                    if (maxmath.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double l = rng.NextDouble();
                double r = rng.NextDouble();

                Assert.AreEqual(math.abs(maxmath.maxmag(l, r)), math.max(math.abs(l), math.abs(r)));

                if (math.abs(l) == math.abs(r)) continue;

                if (math.abs(l) == math.abs(maxmath.maxmag(l, r)))
                {
                    Assert.AreEqual(l, maxmath.maxmag(l, r));
                }
                else
                {
                    Assert.AreEqual(r, maxmath.maxmag(l, r));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double2 l = rng.NextDouble2();
                double2 r = rng.NextDouble2();

                double2 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double3 l = rng.NextDouble3();
                double3 r = rng.NextDouble3();

                double3 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                double4 l = rng.NextDouble4();
                double4 r = rng.NextDouble4();

                double4 test = maxmath.maxmag(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.abs(test[j]), math.max(math.abs(l), math.abs(r))[j]);

                    if (math.abs(l)[j] == math.abs(r)[j]) continue;

                    if (math.abs(l)[j] == math.abs(test[j]))
                    {
                        Assert.AreEqual(l[j], test[j]);
                    }
                    else
                    {
                        Assert.AreEqual(r[j], test[j]);
                    }
                }
            }
        }
    }
}