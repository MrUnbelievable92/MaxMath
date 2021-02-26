using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class lzcnt
    {
        [Test]
        public static void sbyte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();

                Assert.AreEqual(new sbyte2((sbyte)maxmath.lzcnt(x.x), (sbyte)maxmath.lzcnt(x.y)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void sbyte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();

                Assert.AreEqual(new sbyte3((sbyte)maxmath.lzcnt(x.x), (sbyte)maxmath.lzcnt(x.y), (sbyte)maxmath.lzcnt(x.z)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void sbyte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();

                Assert.AreEqual(new sbyte4((sbyte)maxmath.lzcnt(x.x), (sbyte)maxmath.lzcnt(x.y), (sbyte)maxmath.lzcnt(x.z), (sbyte)maxmath.lzcnt(x.w)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void sbyte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();

                Assert.AreEqual(new sbyte8((sbyte)maxmath.lzcnt(x.x0), 
                                           (sbyte)maxmath.lzcnt(x.x1), 
                                           (sbyte)maxmath.lzcnt(x.x2), 
                                           (sbyte)maxmath.lzcnt(x.x3),
                                           (sbyte)maxmath.lzcnt(x.x4),
                                           (sbyte)maxmath.lzcnt(x.x5),
                                           (sbyte)maxmath.lzcnt(x.x6),
                                           (sbyte)maxmath.lzcnt(x.x7)), 
                                maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void sbyte16()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();

                Assert.AreEqual(new sbyte16((sbyte)maxmath.lzcnt(x.x0),
                                            (sbyte)maxmath.lzcnt(x.x1),
                                            (sbyte)maxmath.lzcnt(x.x2),
                                            (sbyte)maxmath.lzcnt(x.x3),
                                            (sbyte)maxmath.lzcnt(x.x4),
                                            (sbyte)maxmath.lzcnt(x.x5),
                                            (sbyte)maxmath.lzcnt(x.x6),
                                            (sbyte)maxmath.lzcnt(x.x7),
                                            (sbyte)maxmath.lzcnt(x.x8),
                                            (sbyte)maxmath.lzcnt(x.x9),
                                            (sbyte)maxmath.lzcnt(x.x10),
                                            (sbyte)maxmath.lzcnt(x.x11),
                                            (sbyte)maxmath.lzcnt(x.x12),
                                            (sbyte)maxmath.lzcnt(x.x13),
                                            (sbyte)maxmath.lzcnt(x.x14),
                                            (sbyte)maxmath.lzcnt(x.x15)),
                                maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void sbyte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();

                Assert.AreEqual(new sbyte32((sbyte)maxmath.lzcnt(x.x0),
                                            (sbyte)maxmath.lzcnt(x.x1),
                                            (sbyte)maxmath.lzcnt(x.x2),
                                            (sbyte)maxmath.lzcnt(x.x3),
                                            (sbyte)maxmath.lzcnt(x.x4),
                                            (sbyte)maxmath.lzcnt(x.x5),
                                            (sbyte)maxmath.lzcnt(x.x6),
                                            (sbyte)maxmath.lzcnt(x.x7),
                                            (sbyte)maxmath.lzcnt(x.x8),
                                            (sbyte)maxmath.lzcnt(x.x9),
                                            (sbyte)maxmath.lzcnt(x.x10),
                                            (sbyte)maxmath.lzcnt(x.x11),
                                            (sbyte)maxmath.lzcnt(x.x12),
                                            (sbyte)maxmath.lzcnt(x.x13),
                                            (sbyte)maxmath.lzcnt(x.x14),
                                            (sbyte)maxmath.lzcnt(x.x15),
                                            (sbyte)maxmath.lzcnt(x.x16),
                                            (sbyte)maxmath.lzcnt(x.x17),
                                            (sbyte)maxmath.lzcnt(x.x18),
                                            (sbyte)maxmath.lzcnt(x.x19),
                                            (sbyte)maxmath.lzcnt(x.x20),
                                            (sbyte)maxmath.lzcnt(x.x21),
                                            (sbyte)maxmath.lzcnt(x.x22),
                                            (sbyte)maxmath.lzcnt(x.x23),
                                            (sbyte)maxmath.lzcnt(x.x24),
                                            (sbyte)maxmath.lzcnt(x.x25),
                                            (sbyte)maxmath.lzcnt(x.x26),
                                            (sbyte)maxmath.lzcnt(x.x27),
                                            (sbyte)maxmath.lzcnt(x.x28),
                                            (sbyte)maxmath.lzcnt(x.x29),
                                            (sbyte)maxmath.lzcnt(x.x30),
                                            (sbyte)maxmath.lzcnt(x.x31)),
                                maxmath.lzcnt(x));
            }
        }


        [Test]
        public static void byte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)maxmath.lzcnt(x.x), (byte)maxmath.lzcnt(x.y)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void byte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)maxmath.lzcnt(x.x), (byte)maxmath.lzcnt(x.y), (byte)maxmath.lzcnt(x.z)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void byte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)maxmath.lzcnt(x.x), (byte)maxmath.lzcnt(x.y), (byte)maxmath.lzcnt(x.z), (byte)maxmath.lzcnt(x.w)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void byte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)maxmath.lzcnt(x.x0), 
                                          (byte)maxmath.lzcnt(x.x1), 
                                          (byte)maxmath.lzcnt(x.x2), 
                                          (byte)maxmath.lzcnt(x.x3),
                                          (byte)maxmath.lzcnt(x.x4),
                                          (byte)maxmath.lzcnt(x.x5),
                                          (byte)maxmath.lzcnt(x.x6),
                                          (byte)maxmath.lzcnt(x.x7)), 
                                maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void byte16()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();

                Assert.AreEqual(new byte16((byte)maxmath.lzcnt(x.x0),
                                           (byte)maxmath.lzcnt(x.x1),
                                           (byte)maxmath.lzcnt(x.x2),
                                           (byte)maxmath.lzcnt(x.x3),
                                           (byte)maxmath.lzcnt(x.x4),
                                           (byte)maxmath.lzcnt(x.x5),
                                           (byte)maxmath.lzcnt(x.x6),
                                           (byte)maxmath.lzcnt(x.x7),
                                           (byte)maxmath.lzcnt(x.x8),
                                           (byte)maxmath.lzcnt(x.x9),
                                           (byte)maxmath.lzcnt(x.x10),
                                           (byte)maxmath.lzcnt(x.x11),
                                           (byte)maxmath.lzcnt(x.x12),
                                           (byte)maxmath.lzcnt(x.x13),
                                           (byte)maxmath.lzcnt(x.x14),
                                           (byte)maxmath.lzcnt(x.x15)),
                                maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void byte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)maxmath.lzcnt(x.x0),
                                           (byte)maxmath.lzcnt(x.x1),
                                           (byte)maxmath.lzcnt(x.x2),
                                           (byte)maxmath.lzcnt(x.x3),
                                           (byte)maxmath.lzcnt(x.x4),
                                           (byte)maxmath.lzcnt(x.x5),
                                           (byte)maxmath.lzcnt(x.x6),
                                           (byte)maxmath.lzcnt(x.x7),
                                           (byte)maxmath.lzcnt(x.x8),
                                           (byte)maxmath.lzcnt(x.x9),
                                           (byte)maxmath.lzcnt(x.x10),
                                           (byte)maxmath.lzcnt(x.x11),
                                           (byte)maxmath.lzcnt(x.x12),
                                           (byte)maxmath.lzcnt(x.x13),
                                           (byte)maxmath.lzcnt(x.x14),
                                           (byte)maxmath.lzcnt(x.x15),
                                           (byte)maxmath.lzcnt(x.x16),
                                           (byte)maxmath.lzcnt(x.x17),
                                           (byte)maxmath.lzcnt(x.x18),
                                           (byte)maxmath.lzcnt(x.x19),
                                           (byte)maxmath.lzcnt(x.x20),
                                           (byte)maxmath.lzcnt(x.x21),
                                           (byte)maxmath.lzcnt(x.x22),
                                           (byte)maxmath.lzcnt(x.x23),
                                           (byte)maxmath.lzcnt(x.x24),
                                           (byte)maxmath.lzcnt(x.x25),
                                           (byte)maxmath.lzcnt(x.x26),
                                           (byte)maxmath.lzcnt(x.x27),
                                           (byte)maxmath.lzcnt(x.x28),
                                           (byte)maxmath.lzcnt(x.x29),
                                           (byte)maxmath.lzcnt(x.x30),
                                           (byte)maxmath.lzcnt(x.x31)),
                                maxmath.lzcnt(x));
            }
        }


        [Test]
        public static void short2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();

                Assert.AreEqual(new short2((short)maxmath.lzcnt(x.x), (short)maxmath.lzcnt(x.y)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void short3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();

                Assert.AreEqual(new short3((short)maxmath.lzcnt(x.x), (short)maxmath.lzcnt(x.y), (short)maxmath.lzcnt(x.z)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void short4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();

                Assert.AreEqual(new short4((short)maxmath.lzcnt(x.x), (short)maxmath.lzcnt(x.y), (short)maxmath.lzcnt(x.z), (short)maxmath.lzcnt(x.w)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void short8()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();

                Assert.AreEqual(new short8((short)maxmath.lzcnt(x.x0), 
                                           (short)maxmath.lzcnt(x.x1), 
                                           (short)maxmath.lzcnt(x.x2), 
                                           (short)maxmath.lzcnt(x.x3),
                                           (short)maxmath.lzcnt(x.x4),
                                           (short)maxmath.lzcnt(x.x5),
                                           (short)maxmath.lzcnt(x.x6),
                                           (short)maxmath.lzcnt(x.x7)), 
                                maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void short16()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();

                Assert.AreEqual(new short16((short)maxmath.lzcnt(x.x0),
                                            (short)maxmath.lzcnt(x.x1),
                                            (short)maxmath.lzcnt(x.x2),
                                            (short)maxmath.lzcnt(x.x3),
                                            (short)maxmath.lzcnt(x.x4),
                                            (short)maxmath.lzcnt(x.x5),
                                            (short)maxmath.lzcnt(x.x6),
                                            (short)maxmath.lzcnt(x.x7),
                                            (short)maxmath.lzcnt(x.x8),
                                            (short)maxmath.lzcnt(x.x9),
                                            (short)maxmath.lzcnt(x.x10),
                                            (short)maxmath.lzcnt(x.x11),
                                            (short)maxmath.lzcnt(x.x12),
                                            (short)maxmath.lzcnt(x.x13),
                                            (short)maxmath.lzcnt(x.x14),
                                            (short)maxmath.lzcnt(x.x15)),
                                maxmath.lzcnt(x));
            }
        }


        [Test]
        public static void ushort2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)maxmath.lzcnt(x.x), (ushort)maxmath.lzcnt(x.y)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void ushort3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)maxmath.lzcnt(x.x), (ushort)maxmath.lzcnt(x.y), (ushort)maxmath.lzcnt(x.z)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void ushort4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)maxmath.lzcnt(x.x), (ushort)maxmath.lzcnt(x.y), (ushort)maxmath.lzcnt(x.z), (ushort)maxmath.lzcnt(x.w)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void ushort8()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)maxmath.lzcnt(x.x0), 
                                            (ushort)maxmath.lzcnt(x.x1), 
                                            (ushort)maxmath.lzcnt(x.x2), 
                                            (ushort)maxmath.lzcnt(x.x3),
                                            (ushort)maxmath.lzcnt(x.x4),
                                            (ushort)maxmath.lzcnt(x.x5),
                                            (ushort)maxmath.lzcnt(x.x6),
                                            (ushort)maxmath.lzcnt(x.x7)), 
                                maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void ushort16()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)maxmath.lzcnt(x.x0),
                                             (ushort)maxmath.lzcnt(x.x1),
                                             (ushort)maxmath.lzcnt(x.x2),
                                             (ushort)maxmath.lzcnt(x.x3),
                                             (ushort)maxmath.lzcnt(x.x4),
                                             (ushort)maxmath.lzcnt(x.x5),
                                             (ushort)maxmath.lzcnt(x.x6),
                                             (ushort)maxmath.lzcnt(x.x7),
                                             (ushort)maxmath.lzcnt(x.x8),
                                             (ushort)maxmath.lzcnt(x.x9),
                                             (ushort)maxmath.lzcnt(x.x10),
                                             (ushort)maxmath.lzcnt(x.x11),
                                             (ushort)maxmath.lzcnt(x.x12),
                                             (ushort)maxmath.lzcnt(x.x13),
                                             (ushort)maxmath.lzcnt(x.x14),
                                             (ushort)maxmath.lzcnt(x.x15)),
                                maxmath.lzcnt(x));
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

                Assert.AreEqual(new int8((int)math.lzcnt(x.x0),
                                         (int)math.lzcnt(x.x1),
                                         (int)math.lzcnt(x.x2),
                                         (int)math.lzcnt(x.x3),
                                         (int)math.lzcnt(x.x4),
                                         (int)math.lzcnt(x.x5),
                                         (int)math.lzcnt(x.x6),
                                         (int)math.lzcnt(x.x7)),
                                maxmath.lzcnt(x));
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

                Assert.AreEqual(new uint8((uint)math.lzcnt(x.x0),
                                          (uint)math.lzcnt(x.x1),
                                          (uint)math.lzcnt(x.x2),
                                          (uint)math.lzcnt(x.x3),
                                          (uint)math.lzcnt(x.x4),
                                          (uint)math.lzcnt(x.x5),
                                          (uint)math.lzcnt(x.x6),
                                          (uint)math.lzcnt(x.x7)),
                                maxmath.lzcnt(x));
            }
        }


        [Test]
        public static void long2()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();

                Assert.AreEqual(new long2((long)math.lzcnt(x.x), (long)math.lzcnt(x.y)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void long3()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();

                Assert.AreEqual(new long3((long)math.lzcnt(x.x), (long)math.lzcnt(x.y), (long)math.lzcnt(x.z)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void long4()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();

                Assert.AreEqual(new long4((long)math.lzcnt(x.x), (long)math.lzcnt(x.y), (long)math.lzcnt(x.z), (long)math.lzcnt(x.w)), maxmath.lzcnt(x));
            }
        }


        [Test]
        public static void ulong2()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void ulong3()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y), (ulong)math.lzcnt(x.z)), maxmath.lzcnt(x));
            }
        }

        [Test]
        public static void ulong4()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y), (ulong)math.lzcnt(x.z), (ulong)math.lzcnt(x.w)), maxmath.lzcnt(x));
            }
        }
    }
}