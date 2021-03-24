using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class intpow
    {
        private static long _intpow(long x, ulong n)
        {
            long p = x;
            long y = 1;

            while (true)
            {
                if ((n % 2) == 1)
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
                if ((n % 2) == 1)
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


        public static void sbyte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();
                byte2 n = rng.NextByte2();

                Assert.AreEqual(new sbyte2((sbyte)_intpow(x.x, n.x), (sbyte)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void sbyte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();
                byte3 n = rng.NextByte3();

                Assert.AreEqual(new sbyte3((sbyte)_intpow(x.x, n.x), (sbyte)_intpow(x.y, n.y), (sbyte)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void sbyte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();
                byte4 n = rng.NextByte4();

                Assert.AreEqual(new sbyte4((sbyte)_intpow(x.x, n.x), (sbyte)_intpow(x.y, n.y), (sbyte)_intpow(x.z, n.z), (sbyte)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void sbyte8()
        {
            Random8 rng = new Random8(135);

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
        public static void sbyte16()
        {
            Random8 rng = new Random8(135);

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
        public static void sbyte32()
        {
            Random8 rng = new Random8(135);

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
        public static void short2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();
                ushort2 n = rng.NextUShort2();

                Assert.AreEqual(new short2((short)_intpow(x.x, n.x), (short)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void short3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();
                ushort3 n = rng.NextUShort3();

                Assert.AreEqual(new short3((short)_intpow(x.x, n.x), (short)_intpow(x.y, n.y), (short)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void short4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();
                ushort4 n = rng.NextUShort4();

                Assert.AreEqual(new short4((short)_intpow(x.x, n.x), (short)_intpow(x.y, n.y), (short)_intpow(x.z, n.z), (short)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void short8()
        {
            Random16 rng = new Random16(135);

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
        public static void short16()
        {
            Random16 rng = new Random16(135);

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
        public static void int2()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();
                uint2 n = rng.NextUInt2();

                Assert.AreEqual(new int2((int)_intpow(x.x, n.x), (int)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }
        
        [Test]
        public static void int3()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();
                uint3 n = rng.NextUInt3();

                Assert.AreEqual(new int3((int)_intpow(x.x, n.x), (int)_intpow(x.y, n.y), (int)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }
        [Test]
        public static void int4()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();
                uint4 n = rng.NextUInt4();

                Assert.AreEqual(new int4((int)_intpow(x.x, n.x), (int)_intpow(x.y, n.y), (int)_intpow(x.z, n.z), (int)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void int8()
        {
            Random32 rng = new Random32(135);

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
        public static void long2()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();
                ulong2 n = rng.NextULong2();

                Assert.AreEqual(new long2((long)_intpow(x.x, n.x), (long)_intpow(x.y, n.y)), maxmath.intpow(x, n));
            }
        }


        [Test]
        public static void long3()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();
                ulong3 n = rng.NextULong3();

                Assert.AreEqual(new long3((long)_intpow(x.x, n.x), (long)_intpow(x.y, n.y), (long)_intpow(x.z, n.z)), maxmath.intpow(x, n));
            }
        }

        [Test]
        public static void long4()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();
                ulong4 n = rng.NextULong4();

                Assert.AreEqual(new long4((long)_intpow(x.x, n.x), (long)_intpow(x.y, n.y), (long)_intpow(x.z, n.z), (long)_intpow(x.w, n.w)), maxmath.intpow(x, n));
            }
        }
    }
}