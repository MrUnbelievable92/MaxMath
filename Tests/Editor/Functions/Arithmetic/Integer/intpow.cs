using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_intpow
    {
        [Test]
        public static void CONSTpow()
        {
            UInt128 x = 2;

            for (int i = 0; i < 128; i++)
            {
                UInt128 xpow = 1;

                for (int j = 0; j < i; j++)
                {
                    xpow *= x;
                }

                Assert.AreEqual(xpow, maxmath.intpow(x, (uint)i));
            }
        }


        private static Int128 _intpow(Int128 x, UInt128 n)
        {
            Int128 p = x;
            Int128 y = 1;

            while (true)
            {
                if ((n & 1) == 1)
                {
                    y *= p;
                }

                n >>= 1;

                if (n == 0)
                {
                    return y;
                }

                p *= p;
            }
        }

        private static UInt128 _intpow(UInt128 x, UInt128 n)
        {
            UInt128 p = x;
            UInt128 y = 1;

            while (true)
            {
                if ((n & 1) == 1)
                {
                    y *= p;
                }

                n >>= 1;

                if (n == 0)
                {
                    return y;
                }

                p *= p;
            }
        }

        private static long _intpow(long x, ulong n)
        {
            long p = x;
            long y = 1;

            while (true)
            {
                if ((n & 1) == 1)
                {
                    y *= p;
                }

                n >>= 1;

                if (n == 0)
                {
                    return y;
                }

                p *= p;
            }
        }

        private static ulong _intpow(ulong x, ulong n)
        {
            ulong p = x;
            ulong y = 1;

            while (true)
            {
                if ((n & 1) == 1)
                {
                    y *= p;
                }

                n >>= 1;

                if (n == 0)
                {
                    return y;
                }

                p *= p;
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (long i = 0; i < 64; i++)
            {
                Int128 x = rng.NextInt128();
                UInt128 n = rng.NextUInt128(0, (UInt128)1 + ulong.MaxValue);

                Assert.AreEqual(_intpow(x, n), maxmath.intpow(x, n.lo64));
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (long i = 0; i < 64; i++)
            {
                sbyte x = rng.NextSByte();
                byte n = rng.NextByte();

                Assert.AreEqual((int)_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();
                byte2 n = rng.NextByte2();

                Assert.AreEqual(new sbyte2((sbyte)_intpow(x.x, n.x), (sbyte)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();
                byte3 n = rng.NextByte3();

                Assert.AreEqual(new sbyte3((sbyte)_intpow(x.x, n.x), (sbyte)_intpow(x.y, n.y), (sbyte)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();
                byte4 n = rng.NextByte4();

                Assert.AreEqual(new sbyte4((sbyte)_intpow(x.x, n.x), (sbyte)_intpow(x.y, n.y), (sbyte)_intpow(x.z, n.z), (sbyte)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();
                byte8 n = rng.NextByte8();

                Assert.AreEqual(new sbyte8((sbyte)_intpow(x.x0, n.x0),
                                           (sbyte)_intpow(x.x1, n.x1),
                                           (sbyte)_intpow(x.x2, n.x2),
                                           (sbyte)_intpow(x.x3, n.x3),
                                           (sbyte)_intpow(x.x4, n.x4),
                                           (sbyte)_intpow(x.x5, n.x5),
                                           (sbyte)_intpow(x.x6, n.x6),
                                           (sbyte)_intpow(x.x7, n.x7)),
                                maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();
                byte16 n = rng.NextByte16();

                Assert.AreEqual(new sbyte16((sbyte)_intpow(x.x0,  n.x0),
                                            (sbyte)_intpow(x.x1,  n.x1),
                                            (sbyte)_intpow(x.x2,  n.x2),
                                            (sbyte)_intpow(x.x3,  n.x3),
                                            (sbyte)_intpow(x.x4,  n.x4),
                                            (sbyte)_intpow(x.x5,  n.x5),
                                            (sbyte)_intpow(x.x6,  n.x6),
                                            (sbyte)_intpow(x.x7,  n.x7),
                                            (sbyte)_intpow(x.x8,  n.x8),
                                            (sbyte)_intpow(x.x9,  n.x9),
                                            (sbyte)_intpow(x.x10, n.x10),
                                            (sbyte)_intpow(x.x11, n.x11),
                                            (sbyte)_intpow(x.x12, n.x12),
                                            (sbyte)_intpow(x.x13, n.x13),
                                            (sbyte)_intpow(x.x14, n.x14),
                                            (sbyte)_intpow(x.x15, n.x15)),
                                maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();
                byte32 n = rng.NextByte32();

                Assert.AreEqual(new sbyte32((sbyte)_intpow(x.x0,  n.x0),
                                            (sbyte)_intpow(x.x1,  n.x1),
                                            (sbyte)_intpow(x.x2,  n.x2),
                                            (sbyte)_intpow(x.x3,  n.x3),
                                            (sbyte)_intpow(x.x4,  n.x4),
                                            (sbyte)_intpow(x.x5,  n.x5),
                                            (sbyte)_intpow(x.x6,  n.x6),
                                            (sbyte)_intpow(x.x7,  n.x7),
                                            (sbyte)_intpow(x.x8,  n.x8),
                                            (sbyte)_intpow(x.x9,  n.x9),
                                            (sbyte)_intpow(x.x10, n.x10),
                                            (sbyte)_intpow(x.x11, n.x11),
                                            (sbyte)_intpow(x.x12, n.x12),
                                            (sbyte)_intpow(x.x13, n.x13),
                                            (sbyte)_intpow(x.x14, n.x14),
                                            (sbyte)_intpow(x.x15, n.x15),
                                            (sbyte)_intpow(x.x16, n.x16),
                                            (sbyte)_intpow(x.x17, n.x17),
                                            (sbyte)_intpow(x.x18, n.x18),
                                            (sbyte)_intpow(x.x19, n.x19),
                                            (sbyte)_intpow(x.x20, n.x20),
                                            (sbyte)_intpow(x.x21, n.x21),
                                            (sbyte)_intpow(x.x22, n.x22),
                                            (sbyte)_intpow(x.x23, n.x23),
                                            (sbyte)_intpow(x.x24, n.x24),
                                            (sbyte)_intpow(x.x25, n.x25),
                                            (sbyte)_intpow(x.x26, n.x26),
                                            (sbyte)_intpow(x.x27, n.x27),
                                            (sbyte)_intpow(x.x28, n.x28),
                                            (sbyte)_intpow(x.x29, n.x29),
                                            (sbyte)_intpow(x.x30, n.x30),
                                            (sbyte)_intpow(x.x31, n.x31)),
                                maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (long i = 0; i < 64; i++)
            {
                short x = rng.NextShort();
                ushort n = rng.NextUShort();

                Assert.AreEqual((int)_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();
                ushort2 n = rng.NextUShort2();

                Assert.AreEqual(new short2((short)_intpow(x.x, n.x), (short)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();
                ushort3 n = rng.NextUShort3();

                Assert.AreEqual(new short3((short)_intpow(x.x, n.x), (short)_intpow(x.y, n.y), (short)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();
                ushort4 n = rng.NextUShort4();

                Assert.AreEqual(new short4((short)_intpow(x.x, n.x), (short)_intpow(x.y, n.y), (short)_intpow(x.z, n.z), (short)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();
                ushort8 n = rng.NextUShort8();

                Assert.AreEqual(new short8((short)_intpow(x.x0, n.x0),
                                           (short)_intpow(x.x1, n.x1),
                                           (short)_intpow(x.x2, n.x2),
                                           (short)_intpow(x.x3, n.x3),
                                           (short)_intpow(x.x4, n.x4),
                                           (short)_intpow(x.x5, n.x5),
                                           (short)_intpow(x.x6, n.x6),
                                           (short)_intpow(x.x7, n.x7)),
                                maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();
                ushort16 n = rng.NextUShort16();

                Assert.AreEqual(new short16((short)_intpow(x.x0,  n.x0),
                                            (short)_intpow(x.x1,  n.x1),
                                            (short)_intpow(x.x2,  n.x2),
                                            (short)_intpow(x.x3,  n.x3),
                                            (short)_intpow(x.x4,  n.x4),
                                            (short)_intpow(x.x5,  n.x5),
                                            (short)_intpow(x.x6,  n.x6),
                                            (short)_intpow(x.x7,  n.x7),
                                            (short)_intpow(x.x8,  n.x8),
                                            (short)_intpow(x.x9,  n.x9),
                                            (short)_intpow(x.x10, n.x10),
                                            (short)_intpow(x.x11, n.x11),
                                            (short)_intpow(x.x12, n.x12),
                                            (short)_intpow(x.x13, n.x13),
                                            (short)_intpow(x.x14, n.x14),
                                            (short)_intpow(x.x15, n.x15)),
                                maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                int x = rng.NextInt();
                uint n = rng.NextUInt();

                Assert.AreEqual((int)_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();
                uint2 n = rng.NextUInt2();

                Assert.AreEqual(new int2((int)_intpow(x.x, n.x), (int)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();
                uint3 n = rng.NextUInt3();

                Assert.AreEqual(new int3((int)_intpow(x.x, n.x), (int)_intpow(x.y, n.y), (int)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();
                uint4 n = rng.NextUInt4();

                Assert.AreEqual(new int4((int)_intpow(x.x, n.x), (int)_intpow(x.y, n.y), (int)_intpow(x.z, n.z), (int)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8();
                uint8 n = rng.NextUInt8();

                Assert.AreEqual(new int8((int)_intpow(x.x0, n.x0),
                                         (int)_intpow(x.x1, n.x1),
                                         (int)_intpow(x.x2, n.x2),
                                         (int)_intpow(x.x3, n.x3),
                                         (int)_intpow(x.x4, n.x4),
                                         (int)_intpow(x.x5, n.x5),
                                         (int)_intpow(x.x6, n.x6),
                                         (int)_intpow(x.x7, n.x7)),
                                maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long x = rng.NextLong();
                ulong n = rng.NextULong();

                Assert.AreEqual(_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();
                ulong2 n = rng.NextULong2();

                Assert.AreEqual(new long2((long)_intpow(x.x, n.x), (long)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();
                ulong3 n = rng.NextULong3();

                Assert.AreEqual(new long3((long)_intpow(x.x, n.x), (long)_intpow(x.y, n.y), (long)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();
                ulong4 n = rng.NextULong4();

                Assert.AreEqual(new long4((long)_intpow(x.x, n.x), (long)_intpow(x.y, n.y), (long)_intpow(x.z, n.z), (long)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (ulong i = 0; i < 64; i++)
            {
                UInt128 x = rng.NextUInt128();
                UInt128 n = rng.NextUInt128(0, (UInt128)1 + ulong.MaxValue);

                Assert.AreEqual(_intpow(x, n), maxmath.intpow(x, n.lo64));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (ulong i = 0; i < 64; i++)
            {
                byte x = rng.NextByte();
                byte n = rng.NextByte();

                Assert.AreEqual((uint)_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (uint i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();
                byte2 n = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)_intpow(x.x, n.x), (byte)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (uint i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();
                byte3 n = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)_intpow(x.x, n.x), (byte)_intpow(x.y, n.y), (byte)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (uint i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();
                byte4 n = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)_intpow(x.x, n.x), (byte)_intpow(x.y, n.y), (byte)_intpow(x.z, n.z), (byte)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (uint i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();
                byte8 n = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)_intpow(x.x0, n.x0),
                                           (byte)_intpow(x.x1, n.x1),
                                           (byte)_intpow(x.x2, n.x2),
                                           (byte)_intpow(x.x3, n.x3),
                                           (byte)_intpow(x.x4, n.x4),
                                           (byte)_intpow(x.x5, n.x5),
                                           (byte)_intpow(x.x6, n.x6),
                                           (byte)_intpow(x.x7, n.x7)),
                                maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (uint i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();
                byte16 n = rng.NextByte16();

                Assert.AreEqual(new byte16((byte)_intpow(x.x0,  n.x0),
                                            (byte)_intpow(x.x1,  n.x1),
                                            (byte)_intpow(x.x2,  n.x2),
                                            (byte)_intpow(x.x3,  n.x3),
                                            (byte)_intpow(x.x4,  n.x4),
                                            (byte)_intpow(x.x5,  n.x5),
                                            (byte)_intpow(x.x6,  n.x6),
                                            (byte)_intpow(x.x7,  n.x7),
                                            (byte)_intpow(x.x8,  n.x8),
                                            (byte)_intpow(x.x9,  n.x9),
                                            (byte)_intpow(x.x10, n.x10),
                                            (byte)_intpow(x.x11, n.x11),
                                            (byte)_intpow(x.x12, n.x12),
                                            (byte)_intpow(x.x13, n.x13),
                                            (byte)_intpow(x.x14, n.x14),
                                            (byte)_intpow(x.x15, n.x15)),
                                maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (uint i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();
                byte32 n = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)_intpow(x.x0,  n.x0),
                                            (byte)_intpow(x.x1,  n.x1),
                                            (byte)_intpow(x.x2,  n.x2),
                                            (byte)_intpow(x.x3,  n.x3),
                                            (byte)_intpow(x.x4,  n.x4),
                                            (byte)_intpow(x.x5,  n.x5),
                                            (byte)_intpow(x.x6,  n.x6),
                                            (byte)_intpow(x.x7,  n.x7),
                                            (byte)_intpow(x.x8,  n.x8),
                                            (byte)_intpow(x.x9,  n.x9),
                                            (byte)_intpow(x.x10, n.x10),
                                            (byte)_intpow(x.x11, n.x11),
                                            (byte)_intpow(x.x12, n.x12),
                                            (byte)_intpow(x.x13, n.x13),
                                            (byte)_intpow(x.x14, n.x14),
                                            (byte)_intpow(x.x15, n.x15),
                                            (byte)_intpow(x.x16, n.x16),
                                            (byte)_intpow(x.x17, n.x17),
                                            (byte)_intpow(x.x18, n.x18),
                                            (byte)_intpow(x.x19, n.x19),
                                            (byte)_intpow(x.x20, n.x20),
                                            (byte)_intpow(x.x21, n.x21),
                                            (byte)_intpow(x.x22, n.x22),
                                            (byte)_intpow(x.x23, n.x23),
                                            (byte)_intpow(x.x24, n.x24),
                                            (byte)_intpow(x.x25, n.x25),
                                            (byte)_intpow(x.x26, n.x26),
                                            (byte)_intpow(x.x27, n.x27),
                                            (byte)_intpow(x.x28, n.x28),
                                            (byte)_intpow(x.x29, n.x29),
                                            (byte)_intpow(x.x30, n.x30),
                                            (byte)_intpow(x.x31, n.x31)),
                                maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (ulong i = 0; i < 64; i++)
            {
                ushort x = rng.NextUShort();
                ushort n = rng.NextUShort();

                Assert.AreEqual((uint)_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (uint i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 n = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)_intpow(x.x, n.x), (ushort)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (uint i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 n = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)_intpow(x.x, n.x), (ushort)_intpow(x.y, n.y), (ushort)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (uint i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 n = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)_intpow(x.x, n.x), (ushort)_intpow(x.y, n.y), (ushort)_intpow(x.z, n.z), (ushort)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (uint i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();
                ushort8 n = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)_intpow(x.x0, n.x0),
                                           (ushort)_intpow(x.x1, n.x1),
                                           (ushort)_intpow(x.x2, n.x2),
                                           (ushort)_intpow(x.x3, n.x3),
                                           (ushort)_intpow(x.x4, n.x4),
                                           (ushort)_intpow(x.x5, n.x5),
                                           (ushort)_intpow(x.x6, n.x6),
                                           (ushort)_intpow(x.x7, n.x7)),
                                maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (uint i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();
                ushort16 n = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)_intpow(x.x0,  n.x0),
                                            (ushort)_intpow(x.x1,  n.x1),
                                            (ushort)_intpow(x.x2,  n.x2),
                                            (ushort)_intpow(x.x3,  n.x3),
                                            (ushort)_intpow(x.x4,  n.x4),
                                            (ushort)_intpow(x.x5,  n.x5),
                                            (ushort)_intpow(x.x6,  n.x6),
                                            (ushort)_intpow(x.x7,  n.x7),
                                            (ushort)_intpow(x.x8,  n.x8),
                                            (ushort)_intpow(x.x9,  n.x9),
                                            (ushort)_intpow(x.x10, n.x10),
                                            (ushort)_intpow(x.x11, n.x11),
                                            (ushort)_intpow(x.x12, n.x12),
                                            (ushort)_intpow(x.x13, n.x13),
                                            (ushort)_intpow(x.x14, n.x14),
                                            (ushort)_intpow(x.x15, n.x15)),
                                maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (ulong i = 0; i < 64; i++)
            {
                uint x = rng.NextUInt();
                uint n = rng.NextUInt();

                Assert.AreEqual((uint)_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();
                uint2 n = rng.NextUInt2();

                Assert.AreEqual(new uint2((uint)_intpow(x.x, n.x), (uint)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();
                uint3 n = rng.NextUInt3();

                Assert.AreEqual(new uint3((uint)_intpow(x.x, n.x), (uint)_intpow(x.y, n.y), (uint)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();
                uint4 n = rng.NextUInt4();

                Assert.AreEqual(new uint4((uint)_intpow(x.x, n.x), (uint)_intpow(x.y, n.y), (uint)_intpow(x.z, n.z), (uint)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();
                uint8 n = rng.NextUInt8();

                Assert.AreEqual(new uint8((uint)_intpow(x.x0, n.x0),
                                         (uint)_intpow(x.x1, n.x1),
                                         (uint)_intpow(x.x2, n.x2),
                                         (uint)_intpow(x.x3, n.x3),
                                         (uint)_intpow(x.x4, n.x4),
                                         (uint)_intpow(x.x5, n.x5),
                                         (uint)_intpow(x.x6, n.x6),
                                         (uint)_intpow(x.x7, n.x7)),
                                maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong x = rng.NextULong();
                ulong n = rng.NextULong();

                Assert.AreEqual(_intpow(x, n), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 n = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)_intpow(x.x, n.x), (ulong)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();
                ulong3 n = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)_intpow(x.x, n.x), (ulong)_intpow(x.y, n.y), (ulong)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();
                ulong4 n = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)_intpow(x.x, n.x), (ulong)_intpow(x.y, n.y), (ulong)_intpow(x.z, n.z), (ulong)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }
    }
}