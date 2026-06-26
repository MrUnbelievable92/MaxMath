using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_tzcnt
    {
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();

                Assert.AreEqual(new sbyte2((sbyte)math.tzcnt(x.x), (sbyte)math.tzcnt(x.y)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();

                Assert.AreEqual(new sbyte3((sbyte)math.tzcnt(x.x), (sbyte)math.tzcnt(x.y), (sbyte)math.tzcnt(x.z)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();

                Assert.AreEqual(new sbyte4((sbyte)math.tzcnt(x.x), (sbyte)math.tzcnt(x.y), (sbyte)math.tzcnt(x.z), (sbyte)math.tzcnt(x.w)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();

                Assert.AreEqual(new sbyte8((sbyte)math.tzcnt(x.x0),
                                           (sbyte)math.tzcnt(x.x1),
                                           (sbyte)math.tzcnt(x.x2),
                                           (sbyte)math.tzcnt(x.x3),
                                           (sbyte)math.tzcnt(x.x4),
                                           (sbyte)math.tzcnt(x.x5),
                                           (sbyte)math.tzcnt(x.x6),
                                           (sbyte)math.tzcnt(x.x7)),
                                math.tzcnt(x));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();

                Assert.AreEqual(new sbyte16((sbyte)math.tzcnt(x.x0),
                                            (sbyte)math.tzcnt(x.x1),
                                            (sbyte)math.tzcnt(x.x2),
                                            (sbyte)math.tzcnt(x.x3),
                                            (sbyte)math.tzcnt(x.x4),
                                            (sbyte)math.tzcnt(x.x5),
                                            (sbyte)math.tzcnt(x.x6),
                                            (sbyte)math.tzcnt(x.x7),
                                            (sbyte)math.tzcnt(x.x8),
                                            (sbyte)math.tzcnt(x.x9),
                                            (sbyte)math.tzcnt(x.x10),
                                            (sbyte)math.tzcnt(x.x11),
                                            (sbyte)math.tzcnt(x.x12),
                                            (sbyte)math.tzcnt(x.x13),
                                            (sbyte)math.tzcnt(x.x14),
                                            (sbyte)math.tzcnt(x.x15)),
                                math.tzcnt(x));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();

                Assert.AreEqual(new sbyte32((sbyte)math.tzcnt(x.x0),
                                            (sbyte)math.tzcnt(x.x1),
                                            (sbyte)math.tzcnt(x.x2),
                                            (sbyte)math.tzcnt(x.x3),
                                            (sbyte)math.tzcnt(x.x4),
                                            (sbyte)math.tzcnt(x.x5),
                                            (sbyte)math.tzcnt(x.x6),
                                            (sbyte)math.tzcnt(x.x7),
                                            (sbyte)math.tzcnt(x.x8),
                                            (sbyte)math.tzcnt(x.x9),
                                            (sbyte)math.tzcnt(x.x10),
                                            (sbyte)math.tzcnt(x.x11),
                                            (sbyte)math.tzcnt(x.x12),
                                            (sbyte)math.tzcnt(x.x13),
                                            (sbyte)math.tzcnt(x.x14),
                                            (sbyte)math.tzcnt(x.x15),
                                            (sbyte)math.tzcnt(x.x16),
                                            (sbyte)math.tzcnt(x.x17),
                                            (sbyte)math.tzcnt(x.x18),
                                            (sbyte)math.tzcnt(x.x19),
                                            (sbyte)math.tzcnt(x.x20),
                                            (sbyte)math.tzcnt(x.x21),
                                            (sbyte)math.tzcnt(x.x22),
                                            (sbyte)math.tzcnt(x.x23),
                                            (sbyte)math.tzcnt(x.x24),
                                            (sbyte)math.tzcnt(x.x25),
                                            (sbyte)math.tzcnt(x.x26),
                                            (sbyte)math.tzcnt(x.x27),
                                            (sbyte)math.tzcnt(x.x28),
                                            (sbyte)math.tzcnt(x.x29),
                                            (sbyte)math.tzcnt(x.x30),
                                            (sbyte)math.tzcnt(x.x31)),
                                math.tzcnt(x));
            }
        }


        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)math.tzcnt(x.x), (byte)math.tzcnt(x.y)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)math.tzcnt(x.x), (byte)math.tzcnt(x.y), (byte)math.tzcnt(x.z)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)math.tzcnt(x.x), (byte)math.tzcnt(x.y), (byte)math.tzcnt(x.z), (byte)math.tzcnt(x.w)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)math.tzcnt(x.x0),
                                          (byte)math.tzcnt(x.x1),
                                          (byte)math.tzcnt(x.x2),
                                          (byte)math.tzcnt(x.x3),
                                          (byte)math.tzcnt(x.x4),
                                          (byte)math.tzcnt(x.x5),
                                          (byte)math.tzcnt(x.x6),
                                          (byte)math.tzcnt(x.x7)),
                                math.tzcnt(x));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();

                Assert.AreEqual(new byte16((byte)math.tzcnt(x.x0),
                                           (byte)math.tzcnt(x.x1),
                                           (byte)math.tzcnt(x.x2),
                                           (byte)math.tzcnt(x.x3),
                                           (byte)math.tzcnt(x.x4),
                                           (byte)math.tzcnt(x.x5),
                                           (byte)math.tzcnt(x.x6),
                                           (byte)math.tzcnt(x.x7),
                                           (byte)math.tzcnt(x.x8),
                                           (byte)math.tzcnt(x.x9),
                                           (byte)math.tzcnt(x.x10),
                                           (byte)math.tzcnt(x.x11),
                                           (byte)math.tzcnt(x.x12),
                                           (byte)math.tzcnt(x.x13),
                                           (byte)math.tzcnt(x.x14),
                                           (byte)math.tzcnt(x.x15)),
                                math.tzcnt(x));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)math.tzcnt(x.x0),
                                           (byte)math.tzcnt(x.x1),
                                           (byte)math.tzcnt(x.x2),
                                           (byte)math.tzcnt(x.x3),
                                           (byte)math.tzcnt(x.x4),
                                           (byte)math.tzcnt(x.x5),
                                           (byte)math.tzcnt(x.x6),
                                           (byte)math.tzcnt(x.x7),
                                           (byte)math.tzcnt(x.x8),
                                           (byte)math.tzcnt(x.x9),
                                           (byte)math.tzcnt(x.x10),
                                           (byte)math.tzcnt(x.x11),
                                           (byte)math.tzcnt(x.x12),
                                           (byte)math.tzcnt(x.x13),
                                           (byte)math.tzcnt(x.x14),
                                           (byte)math.tzcnt(x.x15),
                                           (byte)math.tzcnt(x.x16),
                                           (byte)math.tzcnt(x.x17),
                                           (byte)math.tzcnt(x.x18),
                                           (byte)math.tzcnt(x.x19),
                                           (byte)math.tzcnt(x.x20),
                                           (byte)math.tzcnt(x.x21),
                                           (byte)math.tzcnt(x.x22),
                                           (byte)math.tzcnt(x.x23),
                                           (byte)math.tzcnt(x.x24),
                                           (byte)math.tzcnt(x.x25),
                                           (byte)math.tzcnt(x.x26),
                                           (byte)math.tzcnt(x.x27),
                                           (byte)math.tzcnt(x.x28),
                                           (byte)math.tzcnt(x.x29),
                                           (byte)math.tzcnt(x.x30),
                                           (byte)math.tzcnt(x.x31)),
                                math.tzcnt(x));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();

                Assert.AreEqual(new short2((short)math.tzcnt(x.x), (short)math.tzcnt(x.y)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();

                Assert.AreEqual(new short3((short)math.tzcnt(x.x), (short)math.tzcnt(x.y), (short)math.tzcnt(x.z)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();

                Assert.AreEqual(new short4((short)math.tzcnt(x.x), (short)math.tzcnt(x.y), (short)math.tzcnt(x.z), (short)math.tzcnt(x.w)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();

                Assert.AreEqual(new short8((short)math.tzcnt(x.x0),
                                           (short)math.tzcnt(x.x1),
                                           (short)math.tzcnt(x.x2),
                                           (short)math.tzcnt(x.x3),
                                           (short)math.tzcnt(x.x4),
                                           (short)math.tzcnt(x.x5),
                                           (short)math.tzcnt(x.x6),
                                           (short)math.tzcnt(x.x7)),
                                math.tzcnt(x));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();

                Assert.AreEqual(new short16((short)math.tzcnt(x.x0),
                                            (short)math.tzcnt(x.x1),
                                            (short)math.tzcnt(x.x2),
                                            (short)math.tzcnt(x.x3),
                                            (short)math.tzcnt(x.x4),
                                            (short)math.tzcnt(x.x5),
                                            (short)math.tzcnt(x.x6),
                                            (short)math.tzcnt(x.x7),
                                            (short)math.tzcnt(x.x8),
                                            (short)math.tzcnt(x.x9),
                                            (short)math.tzcnt(x.x10),
                                            (short)math.tzcnt(x.x11),
                                            (short)math.tzcnt(x.x12),
                                            (short)math.tzcnt(x.x13),
                                            (short)math.tzcnt(x.x14),
                                            (short)math.tzcnt(x.x15)),
                                math.tzcnt(x));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)math.tzcnt(x.x), (ushort)math.tzcnt(x.y)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)math.tzcnt(x.x), (ushort)math.tzcnt(x.y), (ushort)math.tzcnt(x.z)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)math.tzcnt(x.x), (ushort)math.tzcnt(x.y), (ushort)math.tzcnt(x.z), (ushort)math.tzcnt(x.w)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)math.tzcnt(x.x0),
                                            (ushort)math.tzcnt(x.x1),
                                            (ushort)math.tzcnt(x.x2),
                                            (ushort)math.tzcnt(x.x3),
                                            (ushort)math.tzcnt(x.x4),
                                            (ushort)math.tzcnt(x.x5),
                                            (ushort)math.tzcnt(x.x6),
                                            (ushort)math.tzcnt(x.x7)),
                                math.tzcnt(x));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)math.tzcnt(x.x0),
                                             (ushort)math.tzcnt(x.x1),
                                             (ushort)math.tzcnt(x.x2),
                                             (ushort)math.tzcnt(x.x3),
                                             (ushort)math.tzcnt(x.x4),
                                             (ushort)math.tzcnt(x.x5),
                                             (ushort)math.tzcnt(x.x6),
                                             (ushort)math.tzcnt(x.x7),
                                             (ushort)math.tzcnt(x.x8),
                                             (ushort)math.tzcnt(x.x9),
                                             (ushort)math.tzcnt(x.x10),
                                             (ushort)math.tzcnt(x.x11),
                                             (ushort)math.tzcnt(x.x12),
                                             (ushort)math.tzcnt(x.x13),
                                             (ushort)math.tzcnt(x.x14),
                                             (ushort)math.tzcnt(x.x15)),
                                math.tzcnt(x));
            }
        }


        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8();

                Assert.AreEqual(new int8((int)math.tzcnt(x.x0),
                                         (int)math.tzcnt(x.x1),
                                         (int)math.tzcnt(x.x2),
                                         (int)math.tzcnt(x.x3),
                                         (int)math.tzcnt(x.x4),
                                         (int)math.tzcnt(x.x5),
                                         (int)math.tzcnt(x.x6),
                                         (int)math.tzcnt(x.x7)),
                                math.tzcnt(x));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();

                Assert.AreEqual(new int8((int)math.tzcnt(x.x0),
                                         (int)math.tzcnt(x.x1),
                                         (int)math.tzcnt(x.x2),
                                         (int)math.tzcnt(x.x3),
                                         (int)math.tzcnt(x.x4),
                                         (int)math.tzcnt(x.x5),
                                         (int)math.tzcnt(x.x6),
                                         (int)math.tzcnt(x.x7)),
                                math.tzcnt(x));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();

                Assert.AreEqual(new long2((long)math.tzcnt(x.x), (long)math.tzcnt(x.y)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();

                Assert.AreEqual(new long3((long)math.tzcnt(x.x), (long)math.tzcnt(x.y), (long)math.tzcnt(x.z)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();

                Assert.AreEqual(new long4((long)math.tzcnt(x.x), (long)math.tzcnt(x.y), (long)math.tzcnt(x.z), (long)math.tzcnt(x.w)), math.tzcnt(x));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z)), math.tzcnt(x));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)math.tzcnt(x.x), (ulong)math.tzcnt(x.y), (ulong)math.tzcnt(x.z), (ulong)math.tzcnt(x.w)), math.tzcnt(x));
            }
        }
    }
}