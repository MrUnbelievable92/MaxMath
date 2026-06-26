using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_intcbrt
    {
        [Test]
        public static void _UInt128()
        {
            Assert.AreEqual(1, math.intcbrt((UInt128)1));
            Assert.AreEqual(2, math.intcbrt((UInt128)8));
            Assert.AreEqual(3, math.intcbrt((UInt128)27));
            Assert.AreEqual(4, math.intcbrt((UInt128)64));
            Assert.AreEqual(5, math.intcbrt((UInt128)125));
        }

        [Test]
        public static void _Int128()
        {
            Assert.AreEqual(1, math.intcbrt((Int128)1));
            Assert.AreEqual(2, math.intcbrt((Int128)8));
            Assert.AreEqual(3, math.intcbrt((Int128)27));
            Assert.AreEqual(4, math.intcbrt((Int128)64));
            Assert.AreEqual(5, math.intcbrt((Int128)125));

            Assert.AreEqual(-1, math.intcbrt((Int128)(-1)));
            Assert.AreEqual(-2, math.intcbrt((Int128)(-8)));
            Assert.AreEqual(-3, math.intcbrt((Int128)(-27)));
            Assert.AreEqual(-4, math.intcbrt((Int128)(-64)));
            Assert.AreEqual(-5, math.intcbrt((Int128)(-125)));
        }


        [Test]
        public static void _byte1()
        {
            for (int i = 0; i <= 255; i++)
            {
                Assert.AreEqual(math.intcbrt((byte)i), math.intcbrt((ulong)i));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)math.intcbrt(x.x), (byte)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)math.intcbrt(x.x), (byte)math.intcbrt(x.y), (byte)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)math.intcbrt(x.x), (byte)math.intcbrt(x.y), (byte)math.intcbrt(x.z), (byte)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)math.intcbrt(x.x0),
                                          (byte)math.intcbrt(x.x1),
                                          (byte)math.intcbrt(x.x2),
                                          (byte)math.intcbrt(x.x3),
                                          (byte)math.intcbrt(x.x4),
                                          (byte)math.intcbrt(x.x5),
                                          (byte)math.intcbrt(x.x6),
                                          (byte)math.intcbrt(x.x7)),
                                math.intcbrt(x));
            }
        }

        [Test]
        public static void _byte16()
        {
            for (int i = 0; i <= 255; i++)
            {
                Assert.AreEqual(math.intcbrt((byte16)(byte)i), new byte16((byte)math.intcbrt((ulong)i)));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)math.intcbrt(x.x0),
                                           (byte)math.intcbrt(x.x1),
                                           (byte)math.intcbrt(x.x2),
                                           (byte)math.intcbrt(x.x3),
                                           (byte)math.intcbrt(x.x4),
                                           (byte)math.intcbrt(x.x5),
                                           (byte)math.intcbrt(x.x6),
                                           (byte)math.intcbrt(x.x7),
                                           (byte)math.intcbrt(x.x8),
                                           (byte)math.intcbrt(x.x9),
                                           (byte)math.intcbrt(x.x10),
                                           (byte)math.intcbrt(x.x11),
                                           (byte)math.intcbrt(x.x12),
                                           (byte)math.intcbrt(x.x13),
                                           (byte)math.intcbrt(x.x14),
                                           (byte)math.intcbrt(x.x15),
                                           (byte)math.intcbrt(x.x16),
                                           (byte)math.intcbrt(x.x17),
                                           (byte)math.intcbrt(x.x18),
                                           (byte)math.intcbrt(x.x19),
                                           (byte)math.intcbrt(x.x20),
                                           (byte)math.intcbrt(x.x21),
                                           (byte)math.intcbrt(x.x22),
                                           (byte)math.intcbrt(x.x23),
                                           (byte)math.intcbrt(x.x24),
                                           (byte)math.intcbrt(x.x25),
                                           (byte)math.intcbrt(x.x26),
                                           (byte)math.intcbrt(x.x27),
                                           (byte)math.intcbrt(x.x28),
                                           (byte)math.intcbrt(x.x29),
                                           (byte)math.intcbrt(x.x30),
                                           (byte)math.intcbrt(x.x31)),
                                math.intcbrt(x));
            }
        }


        [Test]
        public static void _sbyte1()
        {
            Assert.AreEqual(1, math.intcbrt((sbyte)1));
            Assert.AreEqual(2, math.intcbrt((sbyte)8));
            Assert.AreEqual(3, math.intcbrt((sbyte)27));
            Assert.AreEqual(4, math.intcbrt((sbyte)64));
            Assert.AreEqual(5, math.intcbrt((sbyte)125));

            Assert.AreEqual(-1, math.intcbrt((sbyte)-1));
            Assert.AreEqual(-2, math.intcbrt((sbyte)-8));
            Assert.AreEqual(-3, math.intcbrt((sbyte)-27));
            Assert.AreEqual(-4, math.intcbrt((sbyte)-64));
            Assert.AreEqual(-5, math.intcbrt((sbyte)-125));
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();

                Assert.AreEqual(new sbyte2((sbyte)math.intcbrt(x.x), (sbyte)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();

                Assert.AreEqual(new sbyte3((sbyte)math.intcbrt(x.x), (sbyte)math.intcbrt(x.y), (sbyte)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();

                Assert.AreEqual(new sbyte4((sbyte)math.intcbrt(x.x), (sbyte)math.intcbrt(x.y), (sbyte)math.intcbrt(x.z), (sbyte)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();

                Assert.AreEqual(new sbyte8((sbyte)math.intcbrt(x.x0),
                                           (sbyte)math.intcbrt(x.x1),
                                           (sbyte)math.intcbrt(x.x2),
                                           (sbyte)math.intcbrt(x.x3),
                                           (sbyte)math.intcbrt(x.x4),
                                           (sbyte)math.intcbrt(x.x5),
                                           (sbyte)math.intcbrt(x.x6),
                                           (sbyte)math.intcbrt(x.x7)),
                                math.intcbrt(x));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();

                Assert.AreEqual(new sbyte16((sbyte)math.intcbrt(x.x0),
                                            (sbyte)math.intcbrt(x.x1),
                                            (sbyte)math.intcbrt(x.x2),
                                            (sbyte)math.intcbrt(x.x3),
                                            (sbyte)math.intcbrt(x.x4),
                                            (sbyte)math.intcbrt(x.x5),
                                            (sbyte)math.intcbrt(x.x6),
                                            (sbyte)math.intcbrt(x.x7),
                                            (sbyte)math.intcbrt(x.x8),
                                            (sbyte)math.intcbrt(x.x9),
                                            (sbyte)math.intcbrt(x.x10),
                                            (sbyte)math.intcbrt(x.x11),
                                            (sbyte)math.intcbrt(x.x12),
                                            (sbyte)math.intcbrt(x.x13),
                                            (sbyte)math.intcbrt(x.x14),
                                            (sbyte)math.intcbrt(x.x15)),
                                math.intcbrt(x));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();

                Assert.AreEqual(new sbyte32((sbyte)math.intcbrt(x.x0),
                                            (sbyte)math.intcbrt(x.x1),
                                            (sbyte)math.intcbrt(x.x2),
                                            (sbyte)math.intcbrt(x.x3),
                                            (sbyte)math.intcbrt(x.x4),
                                            (sbyte)math.intcbrt(x.x5),
                                            (sbyte)math.intcbrt(x.x6),
                                            (sbyte)math.intcbrt(x.x7),
                                            (sbyte)math.intcbrt(x.x8),
                                            (sbyte)math.intcbrt(x.x9),
                                            (sbyte)math.intcbrt(x.x10),
                                            (sbyte)math.intcbrt(x.x11),
                                            (sbyte)math.intcbrt(x.x12),
                                            (sbyte)math.intcbrt(x.x13),
                                            (sbyte)math.intcbrt(x.x14),
                                            (sbyte)math.intcbrt(x.x15),
                                            (sbyte)math.intcbrt(x.x16),
                                            (sbyte)math.intcbrt(x.x17),
                                            (sbyte)math.intcbrt(x.x18),
                                            (sbyte)math.intcbrt(x.x19),
                                            (sbyte)math.intcbrt(x.x20),
                                            (sbyte)math.intcbrt(x.x21),
                                            (sbyte)math.intcbrt(x.x22),
                                            (sbyte)math.intcbrt(x.x23),
                                            (sbyte)math.intcbrt(x.x24),
                                            (sbyte)math.intcbrt(x.x25),
                                            (sbyte)math.intcbrt(x.x26),
                                            (sbyte)math.intcbrt(x.x27),
                                            (sbyte)math.intcbrt(x.x28),
                                            (sbyte)math.intcbrt(x.x29),
                                            (sbyte)math.intcbrt(x.x30),
                                            (sbyte)math.intcbrt(x.x31)),
                                math.intcbrt(x));
            }
        }

        [Test]
        public static void _ushort1()
        {
            for (int i = 0; i <= ushort.MaxValue; i++)
            {
                Assert.AreEqual(math.intcbrt((ushort)i), math.intcbrt((ulong)i));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)math.intcbrt(x.x), (ushort)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)math.intcbrt(x.x), (ushort)math.intcbrt(x.y), (ushort)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)math.intcbrt(x.x), (ushort)math.intcbrt(x.y), (ushort)math.intcbrt(x.z), (ushort)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)math.intcbrt(x.x0),
                                            (ushort)math.intcbrt(x.x1),
                                            (ushort)math.intcbrt(x.x2),
                                            (ushort)math.intcbrt(x.x3),
                                            (ushort)math.intcbrt(x.x4),
                                            (ushort)math.intcbrt(x.x5),
                                            (ushort)math.intcbrt(x.x6),
                                            (ushort)math.intcbrt(x.x7)),
                                math.intcbrt(x));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)math.intcbrt(x.x0),
                                             (ushort)math.intcbrt(x.x1),
                                             (ushort)math.intcbrt(x.x2),
                                             (ushort)math.intcbrt(x.x3),
                                             (ushort)math.intcbrt(x.x4),
                                             (ushort)math.intcbrt(x.x5),
                                             (ushort)math.intcbrt(x.x6),
                                             (ushort)math.intcbrt(x.x7),
                                             (ushort)math.intcbrt(x.x8),
                                             (ushort)math.intcbrt(x.x9),
                                             (ushort)math.intcbrt(x.x10),
                                             (ushort)math.intcbrt(x.x11),
                                             (ushort)math.intcbrt(x.x12),
                                             (ushort)math.intcbrt(x.x13),
                                             (ushort)math.intcbrt(x.x14),
                                             (ushort)math.intcbrt(x.x15)),
                                math.intcbrt(x));
            }
        }


        [Test]
        public static void _short1()
        {
            Assert.AreEqual(1, math.intcbrt((short)1));
            Assert.AreEqual(2, math.intcbrt((short)8));
            Assert.AreEqual(3, math.intcbrt((short)27));
            Assert.AreEqual(4, math.intcbrt((short)64));
            Assert.AreEqual(5, math.intcbrt((short)125));

            Assert.AreEqual(-1, math.intcbrt((short)-1));
            Assert.AreEqual(-2, math.intcbrt((short)-8));
            Assert.AreEqual(-3, math.intcbrt((short)-27));
            Assert.AreEqual(-4, math.intcbrt((short)-64));
            Assert.AreEqual(-5, math.intcbrt((short)-125));
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();

                Assert.AreEqual(new short2((short)math.intcbrt(x.x), (short)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();

                Assert.AreEqual(new short3((short)math.intcbrt(x.x), (short)math.intcbrt(x.y), (short)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();

                Assert.AreEqual(new short4((short)math.intcbrt(x.x), (short)math.intcbrt(x.y), (short)math.intcbrt(x.z), (short)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();

                Assert.AreEqual(new short8((short)math.intcbrt(x.x0),
                                           (short)math.intcbrt(x.x1),
                                           (short)math.intcbrt(x.x2),
                                           (short)math.intcbrt(x.x3),
                                           (short)math.intcbrt(x.x4),
                                           (short)math.intcbrt(x.x5),
                                           (short)math.intcbrt(x.x6),
                                           (short)math.intcbrt(x.x7)),
                                math.intcbrt(x));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();

                Assert.AreEqual(new short16((short)math.intcbrt(x.x0),
                                            (short)math.intcbrt(x.x1),
                                            (short)math.intcbrt(x.x2),
                                            (short)math.intcbrt(x.x3),
                                            (short)math.intcbrt(x.x4),
                                            (short)math.intcbrt(x.x5),
                                            (short)math.intcbrt(x.x6),
                                            (short)math.intcbrt(x.x7),
                                            (short)math.intcbrt(x.x8),
                                            (short)math.intcbrt(x.x9),
                                            (short)math.intcbrt(x.x10),
                                            (short)math.intcbrt(x.x11),
                                            (short)math.intcbrt(x.x12),
                                            (short)math.intcbrt(x.x13),
                                            (short)math.intcbrt(x.x14),
                                            (short)math.intcbrt(x.x15)),
                                math.intcbrt(x));
            }
        }


        [Test]
        public static void _uint1()
        {
            Assert.AreEqual(1, math.intcbrt((uint)1));
            Assert.AreEqual(2, math.intcbrt((uint)8));
            Assert.AreEqual(3, math.intcbrt((uint)27));
            Assert.AreEqual(4, math.intcbrt((uint)64));
            Assert.AreEqual(5, math.intcbrt((uint)125));
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();

                Assert.AreEqual(new uint2((uint)math.intcbrt(x.x), (uint)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();

                Assert.AreEqual(new uint3((uint)math.intcbrt(x.x), (uint)math.intcbrt(x.y), (uint)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();

                Assert.AreEqual(new uint4((uint)math.intcbrt(x.x), (uint)math.intcbrt(x.y), (uint)math.intcbrt(x.z), (uint)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();

                Assert.AreEqual(new uint8((uint)math.intcbrt(x.x0),
                                          (uint)math.intcbrt(x.x1),
                                          (uint)math.intcbrt(x.x2),
                                          (uint)math.intcbrt(x.x3),
                                          (uint)math.intcbrt(x.x4),
                                          (uint)math.intcbrt(x.x5),
                                          (uint)math.intcbrt(x.x6),
                                          (uint)math.intcbrt(x.x7)),
                                math.intcbrt(x));
            }
        }


        [Test]
        public static void _int1()
        {
            Assert.AreEqual(1, math.intcbrt((int)1));
            Assert.AreEqual(2, math.intcbrt((int)8));
            Assert.AreEqual(3, math.intcbrt((int)27));
            Assert.AreEqual(4, math.intcbrt((int)64));
            Assert.AreEqual(5, math.intcbrt((int)125));

            Assert.AreEqual(-1, math.intcbrt((int)-1));
            Assert.AreEqual(-2, math.intcbrt((int)-8));
            Assert.AreEqual(-3, math.intcbrt((int)-27));
            Assert.AreEqual(-4, math.intcbrt((int)-64));
            Assert.AreEqual(-5, math.intcbrt((int)-125));
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();

                Assert.AreEqual(new int2((int)math.intcbrt(x.x), (int)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();

                Assert.AreEqual(new int3((int)math.intcbrt(x.x), (int)math.intcbrt(x.y), (int)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();

                Assert.AreEqual(new int4((int)math.intcbrt(x.x), (int)math.intcbrt(x.y), (int)math.intcbrt(x.z), (int)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8();

                Assert.AreEqual(new int8((int)math.intcbrt(x.x0),
                                         (int)math.intcbrt(x.x1),
                                         (int)math.intcbrt(x.x2),
                                         (int)math.intcbrt(x.x3),
                                         (int)math.intcbrt(x.x4),
                                         (int)math.intcbrt(x.x5),
                                         (int)math.intcbrt(x.x6),
                                         (int)math.intcbrt(x.x7)),
                                math.intcbrt(x));
            }
        }


        [Test]
        public static void _ulong1()
        {
            Assert.AreEqual(1, math.intcbrt((ulong)1));
            Assert.AreEqual(2, math.intcbrt((ulong)8));
            Assert.AreEqual(3, math.intcbrt((ulong)27));
            Assert.AreEqual(4, math.intcbrt((ulong)64));
            Assert.AreEqual(5, math.intcbrt((ulong)125));
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)math.intcbrt(x.x), (ulong)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)math.intcbrt(x.x), (ulong)math.intcbrt(x.y), (ulong)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)math.intcbrt(x.x), (ulong)math.intcbrt(x.y), (ulong)math.intcbrt(x.z), (ulong)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }


        [Test]
        public static void _long1()
        {
            Assert.AreEqual(1, math.intcbrt((long)1));
            Assert.AreEqual(2, math.intcbrt((long)8));
            Assert.AreEqual(3, math.intcbrt((long)27));
            Assert.AreEqual(4, math.intcbrt((long)64));
            Assert.AreEqual(5, math.intcbrt((long)125));

            Assert.AreEqual(-1, math.intcbrt((long)-1));
            Assert.AreEqual(-2, math.intcbrt((long)-8));
            Assert.AreEqual(-3, math.intcbrt((long)-27));
            Assert.AreEqual(-4, math.intcbrt((long)-64));
            Assert.AreEqual(-5, math.intcbrt((long)-125));
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();

                Assert.AreEqual(new long2((long)math.intcbrt(x.x), (long)math.intcbrt(x.y)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();

                Assert.AreEqual(new long3((long)math.intcbrt(x.x), (long)math.intcbrt(x.y), (long)math.intcbrt(x.z)), math.intcbrt(x));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();

                Assert.AreEqual(new long4((long)math.intcbrt(x.x), (long)math.intcbrt(x.y), (long)math.intcbrt(x.z), (long)math.intcbrt(x.w)), math.intcbrt(x));
            }
        }
    }
}