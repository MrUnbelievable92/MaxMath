using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_lcm
    {
        private static byte _lcm(sbyte x, sbyte y) => (byte)_lcm((long)x, (long)y);
        private static byte _lcm(byte x, byte y) => (byte)_lcm((ulong)x, (ulong)y);

        private static ushort _lcm(short x, short y) => (ushort)_lcm((long)x, (long)y);
        private static ushort _lcm(ushort x, ushort y) => (ushort)_lcm((ulong)x, (ulong)y);

        private static uint _lcm(int x, int y) => (uint)_lcm((long)x, (long)y);
        private static uint _lcm(uint x, uint y) => (uint)_lcm((ulong)x, (ulong)y);

        private static ulong _lcm(long x, long y)
        {
            return (ulong)math.abs(x) / math.gcd(x, y) * (ulong)math.abs(y);
        }
        private static ulong _lcm(ulong x, ulong y)
        {
            return x / math.gcd(x, y) * y;
        }

        private static UInt128 _lcm(Int128 x, Int128 y)
        {
            return (UInt128)math.abs(x) / math.gcd(x, y) * (UInt128)math.abs(y);
        }
        private static UInt128 _lcm(UInt128 x, UInt128 y)
        {
            return x / math.gcd(x, y) * y;
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                Int128 x = rng.NextInt128();
                Int128 y = rng.NextInt128();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(_lcm(x, y), math.lcm(x, y));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                UInt128 x = rng.NextUInt128();
                UInt128 y = rng.NextUInt128();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(_lcm(x, y), math.lcm(x, y));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            for (int i = 1; i <= sbyte.MaxValue; i++)
            {
                for (int j = 1; j <= sbyte.MaxValue; j++)
                {
                    sbyte2 x = (sbyte)i;
                    sbyte2 y = (sbyte)j;
                    byte2 g = math.lcm(x, y);

                    for (int h = 0; h < 2; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            for (int i = 1; i <= sbyte.MaxValue; i++)
            {
                for (int j = 1; j <= sbyte.MaxValue; j++)
                {
                    sbyte3 x = (sbyte)i;
                    sbyte3 y = (sbyte)j;
                    byte3 g = math.lcm(x, y);

                    for (int h = 0; h < 3; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            for (int i = 1; i <= sbyte.MaxValue; i++)
            {
                for (int j = 1; j <= sbyte.MaxValue; j++)
                {
                    sbyte4 x = (sbyte)i;
                    sbyte4 y = (sbyte)j;
                    byte4 g = math.lcm(x, y);

                    for (int h = 0; h < 4; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            for (int i = 1; i <= sbyte.MaxValue; i++)
            {
                for (int j = 1; j <= sbyte.MaxValue; j++)
                {
                    sbyte8 x = (sbyte)i;
                    sbyte8 y = (sbyte)j;
                    byte8 g = math.lcm(x, y);

                    for (int h = 0; h < 8; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            for (int i = 1; i <= sbyte.MaxValue; i++)
            {
                for (int j = 1; j <= sbyte.MaxValue; j++)
                {
                    sbyte16 x = (sbyte)i;
                    sbyte16 y = (sbyte)j;
                    byte16 g = math.lcm(x, y);

                    for (int h = 0; h < 16; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            for (int i = 1; i <= sbyte.MaxValue; i++)
            {
                for (int j = 1; j <= sbyte.MaxValue; j++)
                {
                    sbyte32 x = (sbyte)i;
                    sbyte32 y = (sbyte)j;
                    byte32 g = math.lcm(x, y);

                    for (int h = 0; h < 32; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }


        [Test]
        public static void _byte2()
        {
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                for (int j = 1; j <= byte.MaxValue; j++)
                {
                    byte2 x = (byte)i;
                    byte2 y = (byte)j;
                    byte2 g = math.lcm(x, y);

                    for (int h = 0; h < 2; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                for (int j = 1; j <= byte.MaxValue; j++)
                {
                    byte3 x = (byte)i;
                    byte3 y = (byte)j;
                    byte3 g = math.lcm(x, y);

                    for (int h = 0; h < 3; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                for (int j = 1; j <= byte.MaxValue; j++)
                {
                    byte4 x = (byte)i;
                    byte4 y = (byte)j;
                    byte4 g = math.lcm(x, y);

                    for (int h = 0; h < 4; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                for (int j = 1; j <= byte.MaxValue; j++)
                {
                    byte8 x = (byte)i;
                    byte8 y = (byte)j;
                    byte8 g = math.lcm(x, y);

                    for (int h = 0; h < 8; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                for (int j = 1; j <= byte.MaxValue; j++)
                {
                    byte16 x = (byte)i;
                    byte16 y = (byte)j;
                    byte16 g = math.lcm(x, y);

                    for (int h = 0; h < 16; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            for (int i = 1; i <= byte.MaxValue; i++)
            {
                for (int j = 1; j <= byte.MaxValue; j++)
                {
                    byte32 x = (byte)i;
                    byte32 y = (byte)j;
                    byte32 g = math.lcm(x, y);

                    for (int h = 0; h < 32; h++)
                    {
                        Assert.AreEqual(g[h], _lcm(x[h], y[h]));
                    }
                }
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();
                short2 y = rng.NextShort2();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort2((ushort)_lcm(x.x, y.x), (ushort)_lcm(x.y, y.y)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();
                short3 y = rng.NextShort3();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort3((ushort)_lcm(x.x, y.x), (ushort)_lcm(x.y, y.y), (ushort)_lcm(x.z, y.z)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();
                short4 y = rng.NextShort4();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort4((ushort)_lcm(x.x, y.x), (ushort)_lcm(x.y, y.y), (ushort)_lcm(x.z, y.z), (ushort)_lcm(x.w, y.w)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();
                short8 y = rng.NextShort8();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort8((ushort)_lcm(x.x0, y.x0),
                                           (ushort)_lcm(x.x1, y.x1),
                                           (ushort)_lcm(x.x2, y.x2),
                                           (ushort)_lcm(x.x3, y.x3),
                                           (ushort)_lcm(x.x4, y.x4),
                                           (ushort)_lcm(x.x5, y.x5),
                                           (ushort)_lcm(x.x6, y.x6),
                                           (ushort)_lcm(x.x7, y.x7)),
                                math.lcm(x, y));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();
                short16 y = rng.NextShort16();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort16((ushort)_lcm(x.x0,  y.x0),
                                            (ushort)_lcm(x.x1,  y.x1),
                                            (ushort)_lcm(x.x2,  y.x2),
                                            (ushort)_lcm(x.x3,  y.x3),
                                            (ushort)_lcm(x.x4,  y.x4),
                                            (ushort)_lcm(x.x5,  y.x5),
                                            (ushort)_lcm(x.x6,  y.x6),
                                            (ushort)_lcm(x.x7,  y.x7),
                                            (ushort)_lcm(x.x8,  y.x8),
                                            (ushort)_lcm(x.x9,  y.x9),
                                            (ushort)_lcm(x.x10, y.x10),
                                            (ushort)_lcm(x.x11, y.x11),
                                            (ushort)_lcm(x.x12, y.x12),
                                            (ushort)_lcm(x.x13, y.x13),
                                            (ushort)_lcm(x.x14, y.x14),
                                            (ushort)_lcm(x.x15, y.x15)),
                                math.lcm(x, y));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 y = rng.NextUShort2();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort2((ushort)_lcm(x.x, y.x), (ushort)_lcm(x.y, y.y)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 y = rng.NextUShort3();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort3((ushort)_lcm(x.x, y.x), (ushort)_lcm(x.y, y.y), (ushort)_lcm(x.z, y.z)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 y = rng.NextUShort4();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort4((ushort)_lcm(x.x, y.x), (ushort)_lcm(x.y, y.y), (ushort)_lcm(x.z, y.z), (ushort)_lcm(x.w, y.w)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();
                ushort8 y = rng.NextUShort8();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort8((ushort)_lcm(x.x0, y.x0),
                                            (ushort)_lcm(x.x1, y.x1),
                                            (ushort)_lcm(x.x2, y.x2),
                                            (ushort)_lcm(x.x3, y.x3),
                                            (ushort)_lcm(x.x4, y.x4),
                                            (ushort)_lcm(x.x5, y.x5),
                                            (ushort)_lcm(x.x6, y.x6),
                                            (ushort)_lcm(x.x7, y.x7)),
                                math.lcm(x, y));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();
                ushort16 y = rng.NextUShort16();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ushort16((ushort)_lcm(x.x0,  y.x0),
                                             (ushort)_lcm(x.x1,  y.x1),
                                             (ushort)_lcm(x.x2,  y.x2),
                                             (ushort)_lcm(x.x3,  y.x3),
                                             (ushort)_lcm(x.x4,  y.x4),
                                             (ushort)_lcm(x.x5,  y.x5),
                                             (ushort)_lcm(x.x6,  y.x6),
                                             (ushort)_lcm(x.x7,  y.x7),
                                             (ushort)_lcm(x.x8,  y.x8),
                                             (ushort)_lcm(x.x9,  y.x9),
                                             (ushort)_lcm(x.x10, y.x10),
                                             (ushort)_lcm(x.x11, y.x11),
                                             (ushort)_lcm(x.x12, y.x12),
                                             (ushort)_lcm(x.x13, y.x13),
                                             (ushort)_lcm(x.x14, y.x14),
                                             (ushort)_lcm(x.x15, y.x15)),
                                math.lcm(x, y));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();
                int2 y = rng.NextInt2();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint2((uint)_lcm(x.x, y.x), (uint)_lcm(x.y, y.y)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();
                int3 y = rng.NextInt3();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint3((uint)_lcm(x.x, y.x), (uint)_lcm(x.y, y.y), (uint)_lcm(x.z, y.z)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();
                int4 y = rng.NextInt4();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint4((uint)_lcm(x.x, y.x), (uint)_lcm(x.y, y.y), (uint)_lcm(x.z, y.z), (uint)_lcm(x.w, y.w)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8();
                int8 y = rng.NextInt8();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint8((uint)_lcm(x.x0, y.x0),
                                         (uint)_lcm(x.x1, y.x1),
                                         (uint)_lcm(x.x2, y.x2),
                                         (uint)_lcm(x.x3, y.x3),
                                         (uint)_lcm(x.x4, y.x4),
                                         (uint)_lcm(x.x5, y.x5),
                                         (uint)_lcm(x.x6, y.x6),
                                         (uint)_lcm(x.x7, y.x7)),
                                math.lcm(x, y));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();
                uint2 y = rng.NextUInt2();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint2((uint)_lcm(x.x, y.x), (uint)_lcm(x.y, y.y)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();
                uint3 y = rng.NextUInt3();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint3((uint)_lcm(x.x, y.x), (uint)_lcm(x.y, y.y), (uint)_lcm(x.z, y.z)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();
                uint4 y = rng.NextUInt4();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint4((uint)_lcm(x.x, y.x), (uint)_lcm(x.y, y.y), (uint)_lcm(x.z, y.z), (uint)_lcm(x.w, y.w)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();
                uint8 y = rng.NextUInt8();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new uint8((uint)_lcm(x.x0, y.x0),
                                          (uint)_lcm(x.x1, y.x1),
                                          (uint)_lcm(x.x2, y.x2),
                                          (uint)_lcm(x.x3, y.x3),
                                          (uint)_lcm(x.x4, y.x4),
                                          (uint)_lcm(x.x5, y.x5),
                                          (uint)_lcm(x.x6, y.x6),
                                          (uint)_lcm(x.x7, y.x7)),
                                math.lcm(x, y));
            }
        }

        
        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long x = rng.NextLong();
                long y = rng.NextLong();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(_lcm(x, y), math.lcm(x, y));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();
                long2 y = rng.NextLong2();

                Assert.AreEqual(new ulong2((ulong)_lcm(x.x, y.x), (ulong)_lcm(x.y, y.y)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();
                long3 y = rng.NextLong3();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ulong3((ulong)_lcm(x.x, y.x), (ulong)_lcm(x.y, y.y), (ulong)_lcm(x.z, y.z)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();
                long4 y = rng.NextLong4();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ulong4((ulong)_lcm(x.x, y.x), (ulong)_lcm(x.y, y.y), (ulong)_lcm(x.z, y.z), (ulong)_lcm(x.w, y.w)), math.lcm(x, y));
            }
        }

        
        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong x = rng.NextULong();
                ulong y = rng.NextULong();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(_lcm(x, y), math.lcm(x, y));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 y = rng.NextULong2();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ulong2((ulong)_lcm(x.x, y.x), (ulong)_lcm(x.y, y.y)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();
                ulong3 y = rng.NextULong3();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ulong3((ulong)_lcm(x.x, y.x), (ulong)_lcm(x.y, y.y), (ulong)_lcm(x.z, y.z)), math.lcm(x, y));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();
                ulong4 y = rng.NextULong4();

                x = math.select(x, 1, x == 0);
                y = math.select(y, 1, y == 0);

                Assert.AreEqual(new ulong4((ulong)_lcm(x.x, y.x), (ulong)_lcm(x.y, y.y), (ulong)_lcm(x.z, y.z), (ulong)_lcm(x.w, y.w)), math.lcm(x, y));
            }
        }
    }
}