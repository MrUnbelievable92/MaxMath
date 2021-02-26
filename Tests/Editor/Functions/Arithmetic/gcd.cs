using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class gcd
    {
        private static long _gcd(long x, long y)
        {
            return (long)_gcd((ulong)math.abs(x), (ulong)math.abs(y));
        }

        private static ulong _gcd(ulong x, ulong y)
        {
            return (y == 0) ? x : _gcd(y, x % y);
        }


        [Test]
        public static void int64()
        {
            Random64 rng = new Random64(13255);

            for (int i = 0; i < 64; i++)
            {
                long x = rng.NextLong();
                long y = rng.NextLong();

                Assert.AreEqual(_gcd(x, y), maxmath.gcd(x, y));

                Assert.AreEqual(0, x % _gcd(x, y));
                Assert.AreEqual(0, y % _gcd(x, y));
            }
        }

        [Test]
        public static void uint64()
        {
            Random64 rng = new Random64(13255);

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
        public static void sbyte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();
                sbyte2 y = rng.NextSByte2();

                Assert.AreEqual(new byte2((byte)_gcd(x.x, y.x), (byte)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void sbyte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();
                sbyte3 y = rng.NextSByte3();

                Assert.AreEqual(new byte3((byte)_gcd(x.x, y.x), (byte)_gcd(x.y, y.y), (byte)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void sbyte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();
                sbyte4 y = rng.NextSByte4();

                Assert.AreEqual(new byte4((byte)_gcd(x.x, y.x), (byte)_gcd(x.y, y.y), (byte)_gcd(x.z, y.z), (byte)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void sbyte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();
                sbyte8 y = rng.NextSByte8();

                Assert.AreEqual(new byte8((byte)_gcd(x.x0, y.x0), 
                                          (byte)_gcd(x.x1, y.x1), 
                                          (byte)_gcd(x.x2, y.x2), 
                                          (byte)_gcd(x.x3, y.x3),
                                          (byte)_gcd(x.x4, y.x4),
                                          (byte)_gcd(x.x5, y.x5),
                                          (byte)_gcd(x.x6, y.x6),
                                          (byte)_gcd(x.x7, y.x7)), 
                                maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void sbyte16()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();
                sbyte16 y = rng.NextSByte16();

                Assert.AreEqual(new byte16((byte)_gcd(x.x0,  y.x0),
                                           (byte)_gcd(x.x1,  y.x1),
                                           (byte)_gcd(x.x2,  y.x2),
                                           (byte)_gcd(x.x3,  y.x3),
                                           (byte)_gcd(x.x4,  y.x4),
                                           (byte)_gcd(x.x5,  y.x5),
                                           (byte)_gcd(x.x6,  y.x6),
                                           (byte)_gcd(x.x7,  y.x7),
                                           (byte)_gcd(x.x8,  y.x8),
                                           (byte)_gcd(x.x9,  y.x9),
                                           (byte)_gcd(x.x10, y.x10),
                                           (byte)_gcd(x.x11, y.x11),
                                           (byte)_gcd(x.x12, y.x12),
                                           (byte)_gcd(x.x13, y.x13),
                                           (byte)_gcd(x.x14, y.x14),
                                           (byte)_gcd(x.x15, y.x15)),
                                maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void sbyte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();
                sbyte32 y = rng.NextSByte32();

                Assert.AreEqual(new byte32((byte)_gcd(x.x0,  y.x0),
                                           (byte)_gcd(x.x1,  y.x1),
                                           (byte)_gcd(x.x2,  y.x2),
                                           (byte)_gcd(x.x3,  y.x3),
                                           (byte)_gcd(x.x4,  y.x4),
                                           (byte)_gcd(x.x5,  y.x5),
                                           (byte)_gcd(x.x6,  y.x6),
                                           (byte)_gcd(x.x7,  y.x7),
                                           (byte)_gcd(x.x8,  y.x8),
                                           (byte)_gcd(x.x9,  y.x9),
                                           (byte)_gcd(x.x10, y.x10),
                                           (byte)_gcd(x.x11, y.x11),
                                           (byte)_gcd(x.x12, y.x12),
                                           (byte)_gcd(x.x13, y.x13),
                                           (byte)_gcd(x.x14, y.x14),
                                           (byte)_gcd(x.x15, y.x15),
                                           (byte)_gcd(x.x16, y.x16),
                                           (byte)_gcd(x.x17, y.x17),
                                           (byte)_gcd(x.x18, y.x18),
                                           (byte)_gcd(x.x19, y.x19),
                                           (byte)_gcd(x.x20, y.x20),
                                           (byte)_gcd(x.x21, y.x21),
                                           (byte)_gcd(x.x22, y.x22),
                                           (byte)_gcd(x.x23, y.x23),
                                           (byte)_gcd(x.x24, y.x24),
                                           (byte)_gcd(x.x25, y.x25),
                                           (byte)_gcd(x.x26, y.x26),
                                           (byte)_gcd(x.x27, y.x27),
                                           (byte)_gcd(x.x28, y.x28),
                                           (byte)_gcd(x.x29, y.x29),
                                           (byte)_gcd(x.x30, y.x30),
                                           (byte)_gcd(x.x31, y.x31)),
                                maxmath.gcd(x, y));
            }
        }


        [Test]
        public static void byte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();
                byte2 y = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)_gcd(x.x, y.x), (byte)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void byte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();
                byte3 y = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)_gcd(x.x, y.x), (byte)_gcd(x.y, y.y), (byte)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void byte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();
                byte4 y = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)_gcd(x.x, y.x), (byte)_gcd(x.y, y.y), (byte)_gcd(x.z, y.z), (byte)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void byte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();
                byte8 y = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)_gcd(x.x0, y.x0), 
                                          (byte)_gcd(x.x1, y.x1), 
                                          (byte)_gcd(x.x2, y.x2), 
                                          (byte)_gcd(x.x3, y.x3),
                                          (byte)_gcd(x.x4, y.x4),
                                          (byte)_gcd(x.x5, y.x5),
                                          (byte)_gcd(x.x6, y.x6),
                                          (byte)_gcd(x.x7, y.x7)), 
                                maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void byte16()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();
                byte16 y = rng.NextByte16();

                Assert.AreEqual(new byte16((byte)_gcd(x.x0,  y.x0),
                                           (byte)_gcd(x.x1,  y.x1),
                                           (byte)_gcd(x.x2,  y.x2),
                                           (byte)_gcd(x.x3,  y.x3),
                                           (byte)_gcd(x.x4,  y.x4),
                                           (byte)_gcd(x.x5,  y.x5),
                                           (byte)_gcd(x.x6,  y.x6),
                                           (byte)_gcd(x.x7,  y.x7),
                                           (byte)_gcd(x.x8,  y.x8),
                                           (byte)_gcd(x.x9,  y.x9),
                                           (byte)_gcd(x.x10, y.x10),
                                           (byte)_gcd(x.x11, y.x11),
                                           (byte)_gcd(x.x12, y.x12),
                                           (byte)_gcd(x.x13, y.x13),
                                           (byte)_gcd(x.x14, y.x14),
                                           (byte)_gcd(x.x15, y.x15)),
                                maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void byte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();
                byte32 y = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)_gcd(x.x0,  y.x0),
                                           (byte)_gcd(x.x1,  y.x1),
                                           (byte)_gcd(x.x2,  y.x2),
                                           (byte)_gcd(x.x3,  y.x3),
                                           (byte)_gcd(x.x4,  y.x4),
                                           (byte)_gcd(x.x5,  y.x5),
                                           (byte)_gcd(x.x6,  y.x6),
                                           (byte)_gcd(x.x7,  y.x7),
                                           (byte)_gcd(x.x8,  y.x8),
                                           (byte)_gcd(x.x9,  y.x9),
                                           (byte)_gcd(x.x10, y.x10),
                                           (byte)_gcd(x.x11, y.x11),
                                           (byte)_gcd(x.x12, y.x12),
                                           (byte)_gcd(x.x13, y.x13),
                                           (byte)_gcd(x.x14, y.x14),
                                           (byte)_gcd(x.x15, y.x15),
                                           (byte)_gcd(x.x16, y.x16),
                                           (byte)_gcd(x.x17, y.x17),
                                           (byte)_gcd(x.x18, y.x18),
                                           (byte)_gcd(x.x19, y.x19),
                                           (byte)_gcd(x.x20, y.x20),
                                           (byte)_gcd(x.x21, y.x21),
                                           (byte)_gcd(x.x22, y.x22),
                                           (byte)_gcd(x.x23, y.x23),
                                           (byte)_gcd(x.x24, y.x24),
                                           (byte)_gcd(x.x25, y.x25),
                                           (byte)_gcd(x.x26, y.x26),
                                           (byte)_gcd(x.x27, y.x27),
                                           (byte)_gcd(x.x28, y.x28),
                                           (byte)_gcd(x.x29, y.x29),
                                           (byte)_gcd(x.x30, y.x30),
                                           (byte)_gcd(x.x31, y.x31)),
                                maxmath.gcd(x, y));
            }
        }


        [Test]
        public static void short2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();
                short2 y = rng.NextShort2();

                Assert.AreEqual(new ushort2((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void short3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();
                short3 y = rng.NextShort3();

                Assert.AreEqual(new ushort3((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void short4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();
                short4 y = rng.NextShort4();

                Assert.AreEqual(new ushort4((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z), (ushort)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void short8()
        {
            Random16 rng = new Random16(135);

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
        public static void short16()
        {
            Random16 rng = new Random16(135);

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
        public static void ushort2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 y = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void ushort3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 y = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void ushort4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 y = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)_gcd(x.x, y.x), (ushort)_gcd(x.y, y.y), (ushort)_gcd(x.z, y.z), (ushort)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void ushort8()
        {
            Random16 rng = new Random16(135);

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
        public static void ushort16()
        {
            Random16 rng = new Random16(135);

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
        public static void int2()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();
                int2 y = rng.NextInt2();

                Assert.AreEqual(new uint2((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void int3()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();
                int3 y = rng.NextInt3();

                Assert.AreEqual(new uint3((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void int4()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();
                int4 y = rng.NextInt4();

                Assert.AreEqual(new uint4((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z), (uint)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void int8()
        {
            Random32 rng = new Random32(135);

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
        public static void uint2()
        {
            Random32 rng = new Random32(135);

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();
                uint2 y = rng.NextUInt2();

                Assert.AreEqual(new uint2((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void uint3()
        {
            Random32 rng = new Random32(135);

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();
                uint3 y = rng.NextUInt3();

                Assert.AreEqual(new uint3((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void uint4()
        {
            Random32 rng = new Random32(135);

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();
                uint4 y = rng.NextUInt4();

                Assert.AreEqual(new uint4((uint)_gcd(x.x, y.x), (uint)_gcd(x.y, y.y), (uint)_gcd(x.z, y.z), (uint)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void uint8()
        {
            Random32 rng = new Random32(135);

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
        public static void long2()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();
                long2 y = rng.NextLong2();

                Assert.AreEqual(new ulong2((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void long3()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();
                long3 y = rng.NextLong3();

                Assert.AreEqual(new ulong3((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void long4()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();
                long4 y = rng.NextLong4();

                Assert.AreEqual(new ulong4((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z), (ulong)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }


        [Test]
        public static void ulong2()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 y = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void ulong3()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();
                ulong3 y = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z)), maxmath.gcd(x, y));
            }
        }

        [Test]
        public static void ulong4()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();
                ulong4 y = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)_gcd(x.x, y.x), (ulong)_gcd(x.y, y.y), (ulong)_gcd(x.z, y.z), (ulong)_gcd(x.w, y.w)), maxmath.gcd(x, y));
            }
        }
    }
}