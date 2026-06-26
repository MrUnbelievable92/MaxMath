using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_lzcnt
    {
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();

                Assert.AreEqual(new sbyte2((sbyte)math.lzcnt(x.x), (sbyte)math.lzcnt(x.y)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();

                Assert.AreEqual(new sbyte3((sbyte)math.lzcnt(x.x), (sbyte)math.lzcnt(x.y), (sbyte)math.lzcnt(x.z)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();

                Assert.AreEqual(new sbyte4((sbyte)math.lzcnt(x.x), (sbyte)math.lzcnt(x.y), (sbyte)math.lzcnt(x.z), (sbyte)math.lzcnt(x.w)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();

                Assert.AreEqual(new sbyte8((sbyte)math.lzcnt(x.x0),
                                           (sbyte)math.lzcnt(x.x1),
                                           (sbyte)math.lzcnt(x.x2),
                                           (sbyte)math.lzcnt(x.x3),
                                           (sbyte)math.lzcnt(x.x4),
                                           (sbyte)math.lzcnt(x.x5),
                                           (sbyte)math.lzcnt(x.x6),
                                           (sbyte)math.lzcnt(x.x7)),
                                math.lzcnt(x));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();

                Assert.AreEqual(new sbyte16((sbyte)math.lzcnt(x.x0),
                                            (sbyte)math.lzcnt(x.x1),
                                            (sbyte)math.lzcnt(x.x2),
                                            (sbyte)math.lzcnt(x.x3),
                                            (sbyte)math.lzcnt(x.x4),
                                            (sbyte)math.lzcnt(x.x5),
                                            (sbyte)math.lzcnt(x.x6),
                                            (sbyte)math.lzcnt(x.x7),
                                            (sbyte)math.lzcnt(x.x8),
                                            (sbyte)math.lzcnt(x.x9),
                                            (sbyte)math.lzcnt(x.x10),
                                            (sbyte)math.lzcnt(x.x11),
                                            (sbyte)math.lzcnt(x.x12),
                                            (sbyte)math.lzcnt(x.x13),
                                            (sbyte)math.lzcnt(x.x14),
                                            (sbyte)math.lzcnt(x.x15)),
                                math.lzcnt(x));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();

                Assert.AreEqual(new sbyte32((sbyte)math.lzcnt(x.x0),
                                            (sbyte)math.lzcnt(x.x1),
                                            (sbyte)math.lzcnt(x.x2),
                                            (sbyte)math.lzcnt(x.x3),
                                            (sbyte)math.lzcnt(x.x4),
                                            (sbyte)math.lzcnt(x.x5),
                                            (sbyte)math.lzcnt(x.x6),
                                            (sbyte)math.lzcnt(x.x7),
                                            (sbyte)math.lzcnt(x.x8),
                                            (sbyte)math.lzcnt(x.x9),
                                            (sbyte)math.lzcnt(x.x10),
                                            (sbyte)math.lzcnt(x.x11),
                                            (sbyte)math.lzcnt(x.x12),
                                            (sbyte)math.lzcnt(x.x13),
                                            (sbyte)math.lzcnt(x.x14),
                                            (sbyte)math.lzcnt(x.x15),
                                            (sbyte)math.lzcnt(x.x16),
                                            (sbyte)math.lzcnt(x.x17),
                                            (sbyte)math.lzcnt(x.x18),
                                            (sbyte)math.lzcnt(x.x19),
                                            (sbyte)math.lzcnt(x.x20),
                                            (sbyte)math.lzcnt(x.x21),
                                            (sbyte)math.lzcnt(x.x22),
                                            (sbyte)math.lzcnt(x.x23),
                                            (sbyte)math.lzcnt(x.x24),
                                            (sbyte)math.lzcnt(x.x25),
                                            (sbyte)math.lzcnt(x.x26),
                                            (sbyte)math.lzcnt(x.x27),
                                            (sbyte)math.lzcnt(x.x28),
                                            (sbyte)math.lzcnt(x.x29),
                                            (sbyte)math.lzcnt(x.x30),
                                            (sbyte)math.lzcnt(x.x31)),
                                math.lzcnt(x));
            }
        }


        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)math.lzcnt(x.x), (byte)math.lzcnt(x.y)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)math.lzcnt(x.x), (byte)math.lzcnt(x.y), (byte)math.lzcnt(x.z)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)math.lzcnt(x.x), (byte)math.lzcnt(x.y), (byte)math.lzcnt(x.z), (byte)math.lzcnt(x.w)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)math.lzcnt(x.x0),
                                          (byte)math.lzcnt(x.x1),
                                          (byte)math.lzcnt(x.x2),
                                          (byte)math.lzcnt(x.x3),
                                          (byte)math.lzcnt(x.x4),
                                          (byte)math.lzcnt(x.x5),
                                          (byte)math.lzcnt(x.x6),
                                          (byte)math.lzcnt(x.x7)),
                                math.lzcnt(x));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();

                Assert.AreEqual(new byte16((byte)math.lzcnt(x.x0),
                                           (byte)math.lzcnt(x.x1),
                                           (byte)math.lzcnt(x.x2),
                                           (byte)math.lzcnt(x.x3),
                                           (byte)math.lzcnt(x.x4),
                                           (byte)math.lzcnt(x.x5),
                                           (byte)math.lzcnt(x.x6),
                                           (byte)math.lzcnt(x.x7),
                                           (byte)math.lzcnt(x.x8),
                                           (byte)math.lzcnt(x.x9),
                                           (byte)math.lzcnt(x.x10),
                                           (byte)math.lzcnt(x.x11),
                                           (byte)math.lzcnt(x.x12),
                                           (byte)math.lzcnt(x.x13),
                                           (byte)math.lzcnt(x.x14),
                                           (byte)math.lzcnt(x.x15)),
                                math.lzcnt(x));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)math.lzcnt(x.x0),
                                           (byte)math.lzcnt(x.x1),
                                           (byte)math.lzcnt(x.x2),
                                           (byte)math.lzcnt(x.x3),
                                           (byte)math.lzcnt(x.x4),
                                           (byte)math.lzcnt(x.x5),
                                           (byte)math.lzcnt(x.x6),
                                           (byte)math.lzcnt(x.x7),
                                           (byte)math.lzcnt(x.x8),
                                           (byte)math.lzcnt(x.x9),
                                           (byte)math.lzcnt(x.x10),
                                           (byte)math.lzcnt(x.x11),
                                           (byte)math.lzcnt(x.x12),
                                           (byte)math.lzcnt(x.x13),
                                           (byte)math.lzcnt(x.x14),
                                           (byte)math.lzcnt(x.x15),
                                           (byte)math.lzcnt(x.x16),
                                           (byte)math.lzcnt(x.x17),
                                           (byte)math.lzcnt(x.x18),
                                           (byte)math.lzcnt(x.x19),
                                           (byte)math.lzcnt(x.x20),
                                           (byte)math.lzcnt(x.x21),
                                           (byte)math.lzcnt(x.x22),
                                           (byte)math.lzcnt(x.x23),
                                           (byte)math.lzcnt(x.x24),
                                           (byte)math.lzcnt(x.x25),
                                           (byte)math.lzcnt(x.x26),
                                           (byte)math.lzcnt(x.x27),
                                           (byte)math.lzcnt(x.x28),
                                           (byte)math.lzcnt(x.x29),
                                           (byte)math.lzcnt(x.x30),
                                           (byte)math.lzcnt(x.x31)),
                                math.lzcnt(x));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();

                Assert.AreEqual(new short2((short)math.lzcnt(x.x), (short)math.lzcnt(x.y)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();

                Assert.AreEqual(new short3((short)math.lzcnt(x.x), (short)math.lzcnt(x.y), (short)math.lzcnt(x.z)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();

                Assert.AreEqual(new short4((short)math.lzcnt(x.x), (short)math.lzcnt(x.y), (short)math.lzcnt(x.z), (short)math.lzcnt(x.w)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();

                Assert.AreEqual(new short8((short)math.lzcnt(x.x0),
                                           (short)math.lzcnt(x.x1),
                                           (short)math.lzcnt(x.x2),
                                           (short)math.lzcnt(x.x3),
                                           (short)math.lzcnt(x.x4),
                                           (short)math.lzcnt(x.x5),
                                           (short)math.lzcnt(x.x6),
                                           (short)math.lzcnt(x.x7)),
                                math.lzcnt(x));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();

                Assert.AreEqual(new short16((short)math.lzcnt(x.x0),
                                            (short)math.lzcnt(x.x1),
                                            (short)math.lzcnt(x.x2),
                                            (short)math.lzcnt(x.x3),
                                            (short)math.lzcnt(x.x4),
                                            (short)math.lzcnt(x.x5),
                                            (short)math.lzcnt(x.x6),
                                            (short)math.lzcnt(x.x7),
                                            (short)math.lzcnt(x.x8),
                                            (short)math.lzcnt(x.x9),
                                            (short)math.lzcnt(x.x10),
                                            (short)math.lzcnt(x.x11),
                                            (short)math.lzcnt(x.x12),
                                            (short)math.lzcnt(x.x13),
                                            (short)math.lzcnt(x.x14),
                                            (short)math.lzcnt(x.x15)),
                                math.lzcnt(x));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)math.lzcnt(x.x), (ushort)math.lzcnt(x.y)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)math.lzcnt(x.x), (ushort)math.lzcnt(x.y), (ushort)math.lzcnt(x.z)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)math.lzcnt(x.x), (ushort)math.lzcnt(x.y), (ushort)math.lzcnt(x.z), (ushort)math.lzcnt(x.w)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)math.lzcnt(x.x0),
                                            (ushort)math.lzcnt(x.x1),
                                            (ushort)math.lzcnt(x.x2),
                                            (ushort)math.lzcnt(x.x3),
                                            (ushort)math.lzcnt(x.x4),
                                            (ushort)math.lzcnt(x.x5),
                                            (ushort)math.lzcnt(x.x6),
                                            (ushort)math.lzcnt(x.x7)),
                                math.lzcnt(x));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)math.lzcnt(x.x0),
                                             (ushort)math.lzcnt(x.x1),
                                             (ushort)math.lzcnt(x.x2),
                                             (ushort)math.lzcnt(x.x3),
                                             (ushort)math.lzcnt(x.x4),
                                             (ushort)math.lzcnt(x.x5),
                                             (ushort)math.lzcnt(x.x6),
                                             (ushort)math.lzcnt(x.x7),
                                             (ushort)math.lzcnt(x.x8),
                                             (ushort)math.lzcnt(x.x9),
                                             (ushort)math.lzcnt(x.x10),
                                             (ushort)math.lzcnt(x.x11),
                                             (ushort)math.lzcnt(x.x12),
                                             (ushort)math.lzcnt(x.x13),
                                             (ushort)math.lzcnt(x.x14),
                                             (ushort)math.lzcnt(x.x15)),
                                math.lzcnt(x));
            }
        }


        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8();

                Assert.AreEqual(new int8((int)math.lzcnt(x.x0),
                                         (int)math.lzcnt(x.x1),
                                         (int)math.lzcnt(x.x2),
                                         (int)math.lzcnt(x.x3),
                                         (int)math.lzcnt(x.x4),
                                         (int)math.lzcnt(x.x5),
                                         (int)math.lzcnt(x.x6),
                                         (int)math.lzcnt(x.x7)),
                                math.lzcnt(x));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();

                Assert.AreEqual(new int8((int)math.lzcnt(x.x0),
                                         (int)math.lzcnt(x.x1),
                                         (int)math.lzcnt(x.x2),
                                         (int)math.lzcnt(x.x3),
                                         (int)math.lzcnt(x.x4),
                                         (int)math.lzcnt(x.x5),
                                         (int)math.lzcnt(x.x6),
                                         (int)math.lzcnt(x.x7)),
                                math.lzcnt(x));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();

                Assert.AreEqual(new long2((long)math.lzcnt(x.x), (long)math.lzcnt(x.y)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();

                Assert.AreEqual(new long3((long)math.lzcnt(x.x), (long)math.lzcnt(x.y), (long)math.lzcnt(x.z)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();

                Assert.AreEqual(new long4((long)math.lzcnt(x.x), (long)math.lzcnt(x.y), (long)math.lzcnt(x.z), (long)math.lzcnt(x.w)), math.lzcnt(x));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y), (ulong)math.lzcnt(x.z)), math.lzcnt(x));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y), (ulong)math.lzcnt(x.z), (ulong)math.lzcnt(x.w)), math.lzcnt(x));
            }
        }
    }
}