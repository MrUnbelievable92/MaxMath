using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_gcd
    {
        private static byte _gcd(sbyte x, sbyte y) => (byte)_gcd((long)x, (long)y);
        private static byte _gcd(byte x, byte y) => (byte)_gcd((ulong)x, (ulong)y);

        private static ushort _gcd(short x, short y) => (ushort)_gcd((long)x, (long)y);
        private static ushort _gcd(ushort x, ushort y) => (ushort)_gcd((ulong)x, (ulong)y);

        private static uint _gcd(int x, int y) => (uint)_gcd((long)x, (long)y);
        private static uint _gcd(uint x, uint y) => (uint)_gcd((ulong)x, (ulong)y);

        private static ulong _gcd(long x, long y)
        {
            return _gcd((ulong)math.abs(x), (ulong)math.abs(y));
        }
        private static ulong _gcd(ulong x, ulong y)
        {
            return (y == 0) ? x : _gcd(y, x % y);
        }

        private static UInt128 _gcd(Int128 x, Int128 y)
        {
            return _gcd((UInt128)maxmath.abs(x), (UInt128)maxmath.abs(y));
        }
        private static UInt128 _gcd(UInt128 x, UInt128 y)
        {
            return (y == 0) ? x : _gcd(y, x % y);
        }


        [Test]
        public static void _int64()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long x = rng.NextLong();
                long y = rng.NextLong();

                Assert.AreEqual(_gcd(x, y), maxmath.gcd(x, y));

                Assert.AreEqual(0, x % (long)_gcd(x, y));
                Assert.AreEqual(0, y % (long)_gcd(x, y));
            }
        }

        [Test]
        public static void _uint64()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong x = rng.NextULong();
                ulong y = rng.NextULong();

                Assert.AreEqual(_gcd(x, y), maxmath.gcd(x, y));

                Assert.AreEqual(0, x % _gcd(x, y));
                Assert.AreEqual(0, y % _gcd(x, y));
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                Int128 x = rng.NextInt128();
                Int128 y = rng.NextInt128();

                Assert.AreEqual(_gcd(x, y), maxmath.gcd(x, y));

                Assert.AreEqual((Int128)0, x % (Int128)_gcd(x, y));
                Assert.AreEqual((Int128)0, y % (Int128)_gcd(x, y));
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

                Assert.AreEqual(_gcd(x, y), maxmath.gcd(x, y));

                Assert.AreEqual((UInt128)0, x % _gcd(x, y));
                Assert.AreEqual((UInt128)0, y % _gcd(x, y));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            for (int i = 0; i <= sbyte.MaxValue; i++)
            {
                for (int j = 0; j <= sbyte.MaxValue; j++)
                {
                    sbyte2 x = (sbyte)i;
                    sbyte2 y = (sbyte)j;
                    byte2 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 2; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            for (int i = 0; i <= sbyte.MaxValue; i++)
            {
                for (int j = 0; j <= sbyte.MaxValue; j++)
                {
                    sbyte3 x = (sbyte)i;
                    sbyte3 y = (sbyte)j;
                    byte3 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 3; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            for (int i = 0; i <= sbyte.MaxValue; i++)
            {
                for (int j = 0; j <= sbyte.MaxValue; j++)
                {
                    sbyte4 x = (sbyte)i;
                    sbyte4 y = (sbyte)j;
                    byte4 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 4; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            for (int i = 0; i <= sbyte.MaxValue; i++)
            {
                for (int j = 0; j <= sbyte.MaxValue; j++)
                {
                    sbyte8 x = (sbyte)i;
                    sbyte8 y = (sbyte)j;
                    byte8 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 8; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            for (int i = 0; i <= sbyte.MaxValue; i++)
            {
                for (int j = 0; j <= sbyte.MaxValue; j++)
                {
                    sbyte16 x = (sbyte)i;
                    sbyte16 y = (sbyte)j;
                    byte16 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 16; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            for (int i = 0; i <= sbyte.MaxValue; i++)
            {
                for (int j = 0; j <= sbyte.MaxValue; j++)
                {
                    sbyte32 x = (sbyte)i;
                    sbyte32 y = (sbyte)j;
                    byte32 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 32; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }


        [Test]
        public static void _byte2()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte2 x = (byte)i;
                    byte2 y = (byte)j;
                    byte2 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 2; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte3 x = (byte)i;
                    byte3 y = (byte)j;
                    byte3 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 3; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte4 x = (byte)i;
                    byte4 y = (byte)j;
                    byte4 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 4; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte8 x = (byte)i;
                    byte8 y = (byte)j;
                    byte8 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 8; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte16 x = (byte)i;
                    byte16 y = (byte)j;
                    byte16 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 16; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte32 x = (byte)i;
                    byte32 y = (byte)j;
                    byte32 g = maxmath.gcd(x, y);

                    for (int h = 0; h < 32; h++)
                    {
                        Assert.AreEqual(g[h], _gcd(x[h], y[h]));
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

                Assert.AreEqual(new ushort2((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort3((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort4((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z), (ushort)_gcd(x.w, y.w)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort8((ushort)_gcd(x.x0, y.x0),
                                           (ushort)_gcd(x.x1, y.x1),
                                           (ushort)_gcd(x.x2, y.x2),
                                           (ushort)_gcd(x.x3, y.x3),
                                           (ushort)_gcd(x.x4, y.x4),
                                           (ushort)_gcd(x.x5, y.x5),
                                           (ushort)_gcd(x.x6, y.x6),
                                           (ushort)_gcd(x.x7, y.x7)),
                                maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort16((ushort)_gcd(x.x0,  y.x0),
                                            (ushort)_gcd(x.x1,  y.x1),
                                            (ushort)_gcd(x.x2,  y.x2),
                                            (ushort)_gcd(x.x3,  y.x3),
                                            (ushort)_gcd(x.x4,  y.x4),
                                            (ushort)_gcd(x.x5,  y.x5),
                                            (ushort)_gcd(x.x6,  y.x6),
                                            (ushort)_gcd(x.x7,  y.x7),
                                            (ushort)_gcd(x.x8,  y.x8),
                                            (ushort)_gcd(x.x9,  y.x9),
                                            (ushort)_gcd(x.x10, y.x10),
                                            (ushort)_gcd(x.x11, y.x11),
                                            (ushort)_gcd(x.x12, y.x12),
                                            (ushort)_gcd(x.x13, y.x13),
                                            (ushort)_gcd(x.x14, y.x14),
                                            (ushort)_gcd(x.x15, y.x15)),
                                maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort2((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort3((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort4((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z), (ushort)_gcd(x.w, y.w)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort8((ushort)_gcd(x.x0, y.x0),
                                            (ushort)_gcd(x.x1, y.x1),
                                            (ushort)_gcd(x.x2, y.x2),
                                            (ushort)_gcd(x.x3, y.x3),
                                            (ushort)_gcd(x.x4, y.x4),
                                            (ushort)_gcd(x.x5, y.x5),
                                            (ushort)_gcd(x.x6, y.x6),
                                            (ushort)_gcd(x.x7, y.x7)),
                                maxmath.gcd(x, y));
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

                Assert.AreEqual(new ushort16((ushort)_gcd(x.x0,  y.x0),
                                             (ushort)_gcd(x.x1,  y.x1),
                                             (ushort)_gcd(x.x2,  y.x2),
                                             (ushort)_gcd(x.x3,  y.x3),
                                             (ushort)_gcd(x.x4,  y.x4),
                                             (ushort)_gcd(x.x5,  y.x5),
                                             (ushort)_gcd(x.x6,  y.x6),
                                             (ushort)_gcd(x.x7,  y.x7),
                                             (ushort)_gcd(x.x8,  y.x8),
                                             (ushort)_gcd(x.x9,  y.x9),
                                             (ushort)_gcd(x.x10, y.x10),
                                             (ushort)_gcd(x.x11, y.x11),
                                             (ushort)_gcd(x.x12, y.x12),
                                             (ushort)_gcd(x.x13, y.x13),
                                             (ushort)_gcd(x.x14, y.x14),
                                             (ushort)_gcd(x.x15, y.x15)),
                                maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint2((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint3((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint4((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z), (uint)_gcd(x.w, y.w)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint8((uint)_gcd(x.x0, y.x0),
                                         (uint)_gcd(x.x1, y.x1),
                                         (uint)_gcd(x.x2, y.x2),
                                         (uint)_gcd(x.x3, y.x3),
                                         (uint)_gcd(x.x4, y.x4),
                                         (uint)_gcd(x.x5, y.x5),
                                         (uint)_gcd(x.x6, y.x6),
                                         (uint)_gcd(x.x7, y.x7)),
                                maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint2((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint3((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint4((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z), (uint)_gcd(x.w, y.w)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new uint8((uint)_gcd(x.x0, y.x0),
                                          (uint)_gcd(x.x1, y.x1),
                                          (uint)_gcd(x.x2, y.x2),
                                          (uint)_gcd(x.x3, y.x3),
                                          (uint)_gcd(x.x4, y.x4),
                                          (uint)_gcd(x.x5, y.x5),
                                          (uint)_gcd(x.x6, y.x6),
                                          (uint)_gcd(x.x7, y.x7)),
                                maxmath.gcd(x, y));
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

                Assert.AreEqual(new ulong2((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ulong3((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ulong4((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z), (ulong)_gcd(x.w, y.w)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ulong2((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ulong3((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z)), maxmath.gcd(x, y));
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

                Assert.AreEqual(new ulong4((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z), (ulong)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }
    }
}