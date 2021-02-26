using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class tzcnt
    {
        [Test]
        public static void sbyte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();

                Assert.AreEqual(new sbyte2((sbyte)maxmath.tzcnt(x.x), (sbyte)maxmath.tzcnt(x.y)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void sbyte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();

                Assert.AreEqual(new sbyte3((sbyte)maxmath.tzcnt(x.x), (sbyte)maxmath.tzcnt(x.y), (sbyte)maxmath.tzcnt(x.z)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void sbyte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();

                Assert.AreEqual(new sbyte4((sbyte)maxmath.tzcnt(x.x), (sbyte)maxmath.tzcnt(x.y), (sbyte)maxmath.tzcnt(x.z), (sbyte)maxmath.tzcnt(x.w)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void sbyte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();

                Assert.AreEqual(new sbyte8((sbyte)maxmath.tzcnt(x.x0),
                                           (sbyte)maxmath.tzcnt(x.x1),
                                           (sbyte)maxmath.tzcnt(x.x2),
                                           (sbyte)maxmath.tzcnt(x.x3),
                                           (sbyte)maxmath.tzcnt(x.x4),
                                           (sbyte)maxmath.tzcnt(x.x5),
                                           (sbyte)maxmath.tzcnt(x.x6),
                                           (sbyte)maxmath.tzcnt(x.x7)),
                                maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void sbyte16()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();

                Assert.AreEqual(new sbyte16((sbyte)maxmath.tzcnt(x.x0),
                                            (sbyte)maxmath.tzcnt(x.x1),
                                            (sbyte)maxmath.tzcnt(x.x2),
                                            (sbyte)maxmath.tzcnt(x.x3),
                                            (sbyte)maxmath.tzcnt(x.x4),
                                            (sbyte)maxmath.tzcnt(x.x5),
                                            (sbyte)maxmath.tzcnt(x.x6),
                                            (sbyte)maxmath.tzcnt(x.x7),
                                            (sbyte)maxmath.tzcnt(x.x8),
                                            (sbyte)maxmath.tzcnt(x.x9),
                                            (sbyte)maxmath.tzcnt(x.x10),
                                            (sbyte)maxmath.tzcnt(x.x11),
                                            (sbyte)maxmath.tzcnt(x.x12),
                                            (sbyte)maxmath.tzcnt(x.x13),
                                            (sbyte)maxmath.tzcnt(x.x14),
                                            (sbyte)maxmath.tzcnt(x.x15)),
                                maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void sbyte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();

                Assert.AreEqual(new sbyte32((sbyte)maxmath.tzcnt(x.x0),
                                            (sbyte)maxmath.tzcnt(x.x1),
                                            (sbyte)maxmath.tzcnt(x.x2),
                                            (sbyte)maxmath.tzcnt(x.x3),
                                            (sbyte)maxmath.tzcnt(x.x4),
                                            (sbyte)maxmath.tzcnt(x.x5),
                                            (sbyte)maxmath.tzcnt(x.x6),
                                            (sbyte)maxmath.tzcnt(x.x7),
                                            (sbyte)maxmath.tzcnt(x.x8),
                                            (sbyte)maxmath.tzcnt(x.x9),
                                            (sbyte)maxmath.tzcnt(x.x10),
                                            (sbyte)maxmath.tzcnt(x.x11),
                                            (sbyte)maxmath.tzcnt(x.x12),
                                            (sbyte)maxmath.tzcnt(x.x13),
                                            (sbyte)maxmath.tzcnt(x.x14),
                                            (sbyte)maxmath.tzcnt(x.x15),
                                            (sbyte)maxmath.tzcnt(x.x16),
                                            (sbyte)maxmath.tzcnt(x.x17),
                                            (sbyte)maxmath.tzcnt(x.x18),
                                            (sbyte)maxmath.tzcnt(x.x19),
                                            (sbyte)maxmath.tzcnt(x.x20),
                                            (sbyte)maxmath.tzcnt(x.x21),
                                            (sbyte)maxmath.tzcnt(x.x22),
                                            (sbyte)maxmath.tzcnt(x.x23),
                                            (sbyte)maxmath.tzcnt(x.x24),
                                            (sbyte)maxmath.tzcnt(x.x25),
                                            (sbyte)maxmath.tzcnt(x.x26),
                                            (sbyte)maxmath.tzcnt(x.x27),
                                            (sbyte)maxmath.tzcnt(x.x28),
                                            (sbyte)maxmath.tzcnt(x.x29),
                                            (sbyte)maxmath.tzcnt(x.x30),
                                            (sbyte)maxmath.tzcnt(x.x31)),
                                maxmath.tzcnt(x));
            }
        }


        [Test]
        public static void byte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)maxmath.tzcnt(x.x), (byte)maxmath.tzcnt(x.y)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void byte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)maxmath.tzcnt(x.x), (byte)maxmath.tzcnt(x.y), (byte)maxmath.tzcnt(x.z)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void byte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)maxmath.tzcnt(x.x), (byte)maxmath.tzcnt(x.y), (byte)maxmath.tzcnt(x.z), (byte)maxmath.tzcnt(x.w)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void byte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)maxmath.tzcnt(x.x0),
                                          (byte)maxmath.tzcnt(x.x1),
                                          (byte)maxmath.tzcnt(x.x2),
                                          (byte)maxmath.tzcnt(x.x3),
                                          (byte)maxmath.tzcnt(x.x4),
                                          (byte)maxmath.tzcnt(x.x5),
                                          (byte)maxmath.tzcnt(x.x6),
                                          (byte)maxmath.tzcnt(x.x7)),
                                maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void byte16()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();

                Assert.AreEqual(new byte16((byte)maxmath.tzcnt(x.x0),
                                           (byte)maxmath.tzcnt(x.x1),
                                           (byte)maxmath.tzcnt(x.x2),
                                           (byte)maxmath.tzcnt(x.x3),
                                           (byte)maxmath.tzcnt(x.x4),
                                           (byte)maxmath.tzcnt(x.x5),
                                           (byte)maxmath.tzcnt(x.x6),
                                           (byte)maxmath.tzcnt(x.x7),
                                           (byte)maxmath.tzcnt(x.x8),
                                           (byte)maxmath.tzcnt(x.x9),
                                           (byte)maxmath.tzcnt(x.x10),
                                           (byte)maxmath.tzcnt(x.x11),
                                           (byte)maxmath.tzcnt(x.x12),
                                           (byte)maxmath.tzcnt(x.x13),
                                           (byte)maxmath.tzcnt(x.x14),
                                           (byte)maxmath.tzcnt(x.x15)),
                                maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void byte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)maxmath.tzcnt(x.x0),
                                           (byte)maxmath.tzcnt(x.x1),
                                           (byte)maxmath.tzcnt(x.x2),
                                           (byte)maxmath.tzcnt(x.x3),
                                           (byte)maxmath.tzcnt(x.x4),
                                           (byte)maxmath.tzcnt(x.x5),
                                           (byte)maxmath.tzcnt(x.x6),
                                           (byte)maxmath.tzcnt(x.x7),
                                           (byte)maxmath.tzcnt(x.x8),
                                           (byte)maxmath.tzcnt(x.x9),
                                           (byte)maxmath.tzcnt(x.x10),
                                           (byte)maxmath.tzcnt(x.x11),
                                           (byte)maxmath.tzcnt(x.x12),
                                           (byte)maxmath.tzcnt(x.x13),
                                           (byte)maxmath.tzcnt(x.x14),
                                           (byte)maxmath.tzcnt(x.x15),
                                           (byte)maxmath.tzcnt(x.x16),
                                           (byte)maxmath.tzcnt(x.x17),
                                           (byte)maxmath.tzcnt(x.x18),
                                           (byte)maxmath.tzcnt(x.x19),
                                           (byte)maxmath.tzcnt(x.x20),
                                           (byte)maxmath.tzcnt(x.x21),
                                           (byte)maxmath.tzcnt(x.x22),
                                           (byte)maxmath.tzcnt(x.x23),
                                           (byte)maxmath.tzcnt(x.x24),
                                           (byte)maxmath.tzcnt(x.x25),
                                           (byte)maxmath.tzcnt(x.x26),
                                           (byte)maxmath.tzcnt(x.x27),
                                           (byte)maxmath.tzcnt(x.x28),
                                           (byte)maxmath.tzcnt(x.x29),
                                           (byte)maxmath.tzcnt(x.x30),
                                           (byte)maxmath.tzcnt(x.x31)),
                                maxmath.tzcnt(x));
            }
        }


        [Test]
        public static void short2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();

                Assert.AreEqual(new short2((short)maxmath.tzcnt(x.x), (short)maxmath.tzcnt(x.y)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void short3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();

                Assert.AreEqual(new short3((short)maxmath.tzcnt(x.x), (short)maxmath.tzcnt(x.y), (short)maxmath.tzcnt(x.z)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void short4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();

                Assert.AreEqual(new short4((short)maxmath.tzcnt(x.x), (short)maxmath.tzcnt(x.y), (short)maxmath.tzcnt(x.z), (short)maxmath.tzcnt(x.w)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void short8()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();

                Assert.AreEqual(new short8((short)maxmath.tzcnt(x.x0),
                                           (short)maxmath.tzcnt(x.x1),
                                           (short)maxmath.tzcnt(x.x2),
                                           (short)maxmath.tzcnt(x.x3),
                                           (short)maxmath.tzcnt(x.x4),
                                           (short)maxmath.tzcnt(x.x5),
                                           (short)maxmath.tzcnt(x.x6),
                                           (short)maxmath.tzcnt(x.x7)),
                                maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void short16()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();

                Assert.AreEqual(new short16((short)maxmath.tzcnt(x.x0),
                                            (short)maxmath.tzcnt(x.x1),
                                            (short)maxmath.tzcnt(x.x2),
                                            (short)maxmath.tzcnt(x.x3),
                                            (short)maxmath.tzcnt(x.x4),
                                            (short)maxmath.tzcnt(x.x5),
                                            (short)maxmath.tzcnt(x.x6),
                                            (short)maxmath.tzcnt(x.x7),
                                            (short)maxmath.tzcnt(x.x8),
                                            (short)maxmath.tzcnt(x.x9),
                                            (short)maxmath.tzcnt(x.x10),
                                            (short)maxmath.tzcnt(x.x11),
                                            (short)maxmath.tzcnt(x.x12),
                                            (short)maxmath.tzcnt(x.x13),
                                            (short)maxmath.tzcnt(x.x14),
                                            (short)maxmath.tzcnt(x.x15)),
                                maxmath.tzcnt(x));
            }
        }


        [Test]
        public static void ushort2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)maxmath.tzcnt(x.x), (ushort)maxmath.tzcnt(x.y)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void ushort3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)maxmath.tzcnt(x.x), (ushort)maxmath.tzcnt(x.y), (ushort)maxmath.tzcnt(x.z)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void ushort4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)maxmath.tzcnt(x.x), (ushort)maxmath.tzcnt(x.y), (ushort)maxmath.tzcnt(x.z), (ushort)maxmath.tzcnt(x.w)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void ushort8()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)maxmath.tzcnt(x.x0),
                                            (ushort)maxmath.tzcnt(x.x1),
                                            (ushort)maxmath.tzcnt(x.x2),
                                            (ushort)maxmath.tzcnt(x.x3),
                                            (ushort)maxmath.tzcnt(x.x4),
                                            (ushort)maxmath.tzcnt(x.x5),
                                            (ushort)maxmath.tzcnt(x.x6),
                                            (ushort)maxmath.tzcnt(x.x7)),
                                maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void ushort16()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)maxmath.tzcnt(x.x0),
                                             (ushort)maxmath.tzcnt(x.x1),
                                             (ushort)maxmath.tzcnt(x.x2),
                                             (ushort)maxmath.tzcnt(x.x3),
                                             (ushort)maxmath.tzcnt(x.x4),
                                             (ushort)maxmath.tzcnt(x.x5),
                                             (ushort)maxmath.tzcnt(x.x6),
                                             (ushort)maxmath.tzcnt(x.x7),
                                             (ushort)maxmath.tzcnt(x.x8),
                                             (ushort)maxmath.tzcnt(x.x9),
                                             (ushort)maxmath.tzcnt(x.x10),
                                             (ushort)maxmath.tzcnt(x.x11),
                                             (ushort)maxmath.tzcnt(x.x12),
                                             (ushort)maxmath.tzcnt(x.x13),
                                             (ushort)maxmath.tzcnt(x.x14),
                                             (ushort)maxmath.tzcnt(x.x15)),
                                maxmath.tzcnt(x));
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

                Assert.AreEqual(new int8((int)math.tzcnt(x.x0),
                                         (int)math.tzcnt(x.x1),
                                         (int)math.tzcnt(x.x2),
                                         (int)math.tzcnt(x.x3),
                                         (int)math.tzcnt(x.x4),
                                         (int)math.tzcnt(x.x5),
                                         (int)math.tzcnt(x.x6),
                                         (int)math.tzcnt(x.x7)),
                                maxmath.tzcnt(x));
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

                Assert.AreEqual(new uint8((uint)math.tzcnt(x.x0),
                                          (uint)math.tzcnt(x.x1),
                                          (uint)math.tzcnt(x.x2),
                                          (uint)math.tzcnt(x.x3),
                                          (uint)math.tzcnt(x.x4),
                                          (uint)math.tzcnt(x.x5),
                                          (uint)math.tzcnt(x.x6),
                                          (uint)math.tzcnt(x.x7)),
                                maxmath.tzcnt(x));
            }
        }


        [Test]
        public static void long2()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();

                Assert.AreEqual(new long2((long)math.tzcnt(x.x), (long)math.tzcnt(x.y)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void long3()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();

                Assert.AreEqual(new long3((long)math.tzcnt(x.x), (long)math.tzcnt(x.y), (long)math.tzcnt(x.z)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void long4()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();

                Assert.AreEqual(new long4((long)math.tzcnt(x.x), (long)math.tzcnt(x.y), (long)math.tzcnt(x.z), (long)math.tzcnt(x.w)), maxmath.tzcnt(x));
            }
        }


        [Test]
        public static void ulong2()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void ulong3()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z)), maxmath.tzcnt(x));
            }
        }

        [Test]
        public static void ulong4()
        {
            Random64 rng = new Random64(135);

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z), (ulong)math.tzcnt(x.w)), maxmath.tzcnt(x));
            }
        }
    }
}