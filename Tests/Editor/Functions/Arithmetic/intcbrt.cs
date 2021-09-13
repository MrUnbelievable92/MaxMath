using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class intcbrt
    {
        [Test]
        public static void uint128()
        {
            Assert.AreEqual(1, maxmath.intcbrt((UInt128)1));
            Assert.AreEqual(2, maxmath.intcbrt((UInt128)8));
            Assert.AreEqual(3, maxmath.intcbrt((UInt128)27));
            Assert.AreEqual(4, maxmath.intcbrt((UInt128)64));
            Assert.AreEqual(5, maxmath.intcbrt((UInt128)125));
        }
        
        [Test]
        public static void int128()
        {
            Assert.AreEqual(1, maxmath.intcbrt((Int128)1));
            Assert.AreEqual(2, maxmath.intcbrt((Int128)8));
            Assert.AreEqual(3, maxmath.intcbrt((Int128)27));
            Assert.AreEqual(4, maxmath.intcbrt((Int128)64));
            Assert.AreEqual(5, maxmath.intcbrt((Int128)125));

            Assert.AreEqual(-1, maxmath.intcbrt((Int128)(-1), true));
            Assert.AreEqual(-2, maxmath.intcbrt((Int128)(-8), true));
            Assert.AreEqual(-3, maxmath.intcbrt((Int128)(-27), true));
            Assert.AreEqual(-4, maxmath.intcbrt((Int128)(-64), true));
            Assert.AreEqual(-5, maxmath.intcbrt((Int128)(-125), true));
        }


        [Test]
        public static void byte1()
        {
            for (int i = 0;i <= 255;i++)
            {
                Assert.AreEqual(maxmath.intcbrt((byte)i), maxmath.intcbrt((ulong)i));
            }
        }

        [Test]
        public static void byte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)maxmath.intcbrt(x.x), (byte)maxmath.intcbrt(x.y)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void byte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)maxmath.intcbrt(x.x), (byte)maxmath.intcbrt(x.y), (byte)maxmath.intcbrt(x.z)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void byte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)maxmath.intcbrt(x.x), (byte)maxmath.intcbrt(x.y), (byte)maxmath.intcbrt(x.z), (byte)maxmath.intcbrt(x.w)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void byte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)maxmath.intcbrt(x.x0), 
                                          (byte)maxmath.intcbrt(x.x1), 
                                          (byte)maxmath.intcbrt(x.x2), 
                                          (byte)maxmath.intcbrt(x.x3),
                                          (byte)maxmath.intcbrt(x.x4),
                                          (byte)maxmath.intcbrt(x.x5),
                                          (byte)maxmath.intcbrt(x.x6),
                                          (byte)maxmath.intcbrt(x.x7)), 
                                maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void byte16()
        {
            for (int i = 0;i <= 255;i++)
            {
                Assert.AreEqual(maxmath.intcbrt((byte16)(byte)i), new byte16((byte)maxmath.intcbrt((ulong)i)));
            }
        }

        [Test]
        public static void byte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)maxmath.intcbrt(x.x0),
                                           (byte)maxmath.intcbrt(x.x1),
                                           (byte)maxmath.intcbrt(x.x2),
                                           (byte)maxmath.intcbrt(x.x3),
                                           (byte)maxmath.intcbrt(x.x4),
                                           (byte)maxmath.intcbrt(x.x5),
                                           (byte)maxmath.intcbrt(x.x6),
                                           (byte)maxmath.intcbrt(x.x7),
                                           (byte)maxmath.intcbrt(x.x8),
                                           (byte)maxmath.intcbrt(x.x9),
                                           (byte)maxmath.intcbrt(x.x10),
                                           (byte)maxmath.intcbrt(x.x11),
                                           (byte)maxmath.intcbrt(x.x12),
                                           (byte)maxmath.intcbrt(x.x13),
                                           (byte)maxmath.intcbrt(x.x14),
                                           (byte)maxmath.intcbrt(x.x15),
                                           (byte)maxmath.intcbrt(x.x16),
                                           (byte)maxmath.intcbrt(x.x17),
                                           (byte)maxmath.intcbrt(x.x18),
                                           (byte)maxmath.intcbrt(x.x19),
                                           (byte)maxmath.intcbrt(x.x20),
                                           (byte)maxmath.intcbrt(x.x21),
                                           (byte)maxmath.intcbrt(x.x22),
                                           (byte)maxmath.intcbrt(x.x23),
                                           (byte)maxmath.intcbrt(x.x24),
                                           (byte)maxmath.intcbrt(x.x25),
                                           (byte)maxmath.intcbrt(x.x26),
                                           (byte)maxmath.intcbrt(x.x27),
                                           (byte)maxmath.intcbrt(x.x28),
                                           (byte)maxmath.intcbrt(x.x29),
                                           (byte)maxmath.intcbrt(x.x30),
                                           (byte)maxmath.intcbrt(x.x31)),
                                maxmath.intcbrt(x));
            }
        }


        [Test]
        public static void sbyte1()
        {
            Assert.AreEqual(1, maxmath.intcbrt((sbyte)1));
            Assert.AreEqual(2, maxmath.intcbrt((sbyte)8));
            Assert.AreEqual(3, maxmath.intcbrt((sbyte)27));
            Assert.AreEqual(4, maxmath.intcbrt((sbyte)64));
            Assert.AreEqual(5, maxmath.intcbrt((sbyte)125));

            Assert.AreEqual(-1, maxmath.intcbrt((sbyte)-1, true));
            Assert.AreEqual(-2, maxmath.intcbrt((sbyte)-8, true));
            Assert.AreEqual(-3, maxmath.intcbrt((sbyte)-27, true));
            Assert.AreEqual(-4, maxmath.intcbrt((sbyte)-64, true));
            Assert.AreEqual(-5, maxmath.intcbrt((sbyte)-125, true));
        }

        [Test]
        public static void sbyte2()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();

                Assert.AreEqual(new sbyte2((sbyte)maxmath.intcbrt(x.x, true), (sbyte)maxmath.intcbrt(x.y, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void sbyte3()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();

                Assert.AreEqual(new sbyte3((sbyte)maxmath.intcbrt(x.x, true), (sbyte)maxmath.intcbrt(x.y, true), (sbyte)maxmath.intcbrt(x.z, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void sbyte4()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();

                Assert.AreEqual(new sbyte4((sbyte)maxmath.intcbrt(x.x, true), (sbyte)maxmath.intcbrt(x.y, true), (sbyte)maxmath.intcbrt(x.z, true), (sbyte)maxmath.intcbrt(x.w, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void sbyte8()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();

                Assert.AreEqual(new sbyte8((sbyte)maxmath.intcbrt(x.x0, true), 
                                           (sbyte)maxmath.intcbrt(x.x1, true), 
                                           (sbyte)maxmath.intcbrt(x.x2, true), 
                                           (sbyte)maxmath.intcbrt(x.x3, true),
                                           (sbyte)maxmath.intcbrt(x.x4, true),
                                           (sbyte)maxmath.intcbrt(x.x5, true),
                                           (sbyte)maxmath.intcbrt(x.x6, true),
                                           (sbyte)maxmath.intcbrt(x.x7, true)), 
                                maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void sbyte16()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();

                Assert.AreEqual(new sbyte16((sbyte)maxmath.intcbrt(x.x0, true),
                                            (sbyte)maxmath.intcbrt(x.x1, true),
                                            (sbyte)maxmath.intcbrt(x.x2, true),
                                            (sbyte)maxmath.intcbrt(x.x3, true),
                                            (sbyte)maxmath.intcbrt(x.x4, true),
                                            (sbyte)maxmath.intcbrt(x.x5, true),
                                            (sbyte)maxmath.intcbrt(x.x6, true),
                                            (sbyte)maxmath.intcbrt(x.x7, true),
                                            (sbyte)maxmath.intcbrt(x.x8, true),
                                            (sbyte)maxmath.intcbrt(x.x9, true),
                                            (sbyte)maxmath.intcbrt(x.x10, true),
                                            (sbyte)maxmath.intcbrt(x.x11, true),
                                            (sbyte)maxmath.intcbrt(x.x12, true),
                                            (sbyte)maxmath.intcbrt(x.x13, true),
                                            (sbyte)maxmath.intcbrt(x.x14, true),
                                            (sbyte)maxmath.intcbrt(x.x15, true)),
                                maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void sbyte32()
        {
            Random8 rng = new Random8(135);

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();

                Assert.AreEqual(new sbyte32((sbyte)maxmath.intcbrt(x.x0, true),
                                            (sbyte)maxmath.intcbrt(x.x1, true),
                                            (sbyte)maxmath.intcbrt(x.x2, true),
                                            (sbyte)maxmath.intcbrt(x.x3, true),
                                            (sbyte)maxmath.intcbrt(x.x4, true),
                                            (sbyte)maxmath.intcbrt(x.x5, true),
                                            (sbyte)maxmath.intcbrt(x.x6, true),
                                            (sbyte)maxmath.intcbrt(x.x7, true),
                                            (sbyte)maxmath.intcbrt(x.x8, true),
                                            (sbyte)maxmath.intcbrt(x.x9, true),
                                            (sbyte)maxmath.intcbrt(x.x10, true),
                                            (sbyte)maxmath.intcbrt(x.x11, true),
                                            (sbyte)maxmath.intcbrt(x.x12, true),
                                            (sbyte)maxmath.intcbrt(x.x13, true),
                                            (sbyte)maxmath.intcbrt(x.x14, true),
                                            (sbyte)maxmath.intcbrt(x.x15, true),
                                            (sbyte)maxmath.intcbrt(x.x16, true),
                                            (sbyte)maxmath.intcbrt(x.x17, true),
                                            (sbyte)maxmath.intcbrt(x.x18, true),
                                            (sbyte)maxmath.intcbrt(x.x19, true),
                                            (sbyte)maxmath.intcbrt(x.x20, true),
                                            (sbyte)maxmath.intcbrt(x.x21, true),
                                            (sbyte)maxmath.intcbrt(x.x22, true),
                                            (sbyte)maxmath.intcbrt(x.x23, true),
                                            (sbyte)maxmath.intcbrt(x.x24, true),
                                            (sbyte)maxmath.intcbrt(x.x25, true),
                                            (sbyte)maxmath.intcbrt(x.x26, true),
                                            (sbyte)maxmath.intcbrt(x.x27, true),
                                            (sbyte)maxmath.intcbrt(x.x28, true),
                                            (sbyte)maxmath.intcbrt(x.x29, true),
                                            (sbyte)maxmath.intcbrt(x.x30, true),
                                            (sbyte)maxmath.intcbrt(x.x31, true)),
                                maxmath.intcbrt(x, true));
            }
        }
        
        [Test]
        public static void ushort1()
        {
            for (int i = 0;i <= ushort.MaxValue;i++)
            {
                Assert.AreEqual(maxmath.intcbrt((ushort)i), maxmath.intcbrt((ulong)i));
            }
        }

        [Test]
        public static void ushort2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)maxmath.intcbrt(x.x), (ushort)maxmath.intcbrt(x.y)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void ushort3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)maxmath.intcbrt(x.x), (ushort)maxmath.intcbrt(x.y), (ushort)maxmath.intcbrt(x.z)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void ushort4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)maxmath.intcbrt(x.x), (ushort)maxmath.intcbrt(x.y), (ushort)maxmath.intcbrt(x.z), (ushort)maxmath.intcbrt(x.w)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void ushort8()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)maxmath.intcbrt(x.x0), 
                                            (ushort)maxmath.intcbrt(x.x1), 
                                            (ushort)maxmath.intcbrt(x.x2), 
                                            (ushort)maxmath.intcbrt(x.x3),
                                            (ushort)maxmath.intcbrt(x.x4),
                                            (ushort)maxmath.intcbrt(x.x5),
                                            (ushort)maxmath.intcbrt(x.x6),
                                            (ushort)maxmath.intcbrt(x.x7)), 
                                maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void ushort16()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)maxmath.intcbrt(x.x0),
                                             (ushort)maxmath.intcbrt(x.x1),
                                             (ushort)maxmath.intcbrt(x.x2),
                                             (ushort)maxmath.intcbrt(x.x3),
                                             (ushort)maxmath.intcbrt(x.x4),
                                             (ushort)maxmath.intcbrt(x.x5),
                                             (ushort)maxmath.intcbrt(x.x6),
                                             (ushort)maxmath.intcbrt(x.x7),
                                             (ushort)maxmath.intcbrt(x.x8),
                                             (ushort)maxmath.intcbrt(x.x9),
                                             (ushort)maxmath.intcbrt(x.x10),
                                             (ushort)maxmath.intcbrt(x.x11),
                                             (ushort)maxmath.intcbrt(x.x12),
                                             (ushort)maxmath.intcbrt(x.x13),
                                             (ushort)maxmath.intcbrt(x.x14),
                                             (ushort)maxmath.intcbrt(x.x15)),
                                maxmath.intcbrt(x));
            }
        }

        
        [Test]
        public static void short1()
        {
            Assert.AreEqual(1, maxmath.intcbrt((short)1));
            Assert.AreEqual(2, maxmath.intcbrt((short)8));
            Assert.AreEqual(3, maxmath.intcbrt((short)27));
            Assert.AreEqual(4, maxmath.intcbrt((short)64));
            Assert.AreEqual(5, maxmath.intcbrt((short)125));

            Assert.AreEqual(-1, maxmath.intcbrt((short)-1, true));
            Assert.AreEqual(-2, maxmath.intcbrt((short)-8, true));
            Assert.AreEqual(-3, maxmath.intcbrt((short)-27, true));
            Assert.AreEqual(-4, maxmath.intcbrt((short)-64, true));
            Assert.AreEqual(-5, maxmath.intcbrt((short)-125, true));
        }

        [Test]
        public static void short2()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();

                Assert.AreEqual(new short2((short)maxmath.intcbrt(x.x, true), (short)maxmath.intcbrt(x.y, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void short3()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();

                Assert.AreEqual(new short3((short)maxmath.intcbrt(x.x, true), (short)maxmath.intcbrt(x.y, true), (short)maxmath.intcbrt(x.z, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void short4()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();

                Assert.AreEqual(new short4((short)maxmath.intcbrt(x.x, true), (short)maxmath.intcbrt(x.y, true), (short)maxmath.intcbrt(x.z, true), (short)maxmath.intcbrt(x.w, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void short8()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();

                Assert.AreEqual(new short8((short)maxmath.intcbrt(x.x0, true), 
                                           (short)maxmath.intcbrt(x.x1, true), 
                                           (short)maxmath.intcbrt(x.x2, true), 
                                           (short)maxmath.intcbrt(x.x3, true),
                                           (short)maxmath.intcbrt(x.x4, true),
                                           (short)maxmath.intcbrt(x.x5, true),
                                           (short)maxmath.intcbrt(x.x6, true),
                                           (short)maxmath.intcbrt(x.x7, true)), 
                                maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void short16()
        {
            Random16 rng = new Random16(135);

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();

                Assert.AreEqual(new short16((short)maxmath.intcbrt(x.x0, true),
                                            (short)maxmath.intcbrt(x.x1, true),
                                            (short)maxmath.intcbrt(x.x2, true),
                                            (short)maxmath.intcbrt(x.x3, true),
                                            (short)maxmath.intcbrt(x.x4, true),
                                            (short)maxmath.intcbrt(x.x5, true),
                                            (short)maxmath.intcbrt(x.x6, true),
                                            (short)maxmath.intcbrt(x.x7, true),
                                            (short)maxmath.intcbrt(x.x8, true),
                                            (short)maxmath.intcbrt(x.x9, true),
                                            (short)maxmath.intcbrt(x.x10, true),
                                            (short)maxmath.intcbrt(x.x11, true),
                                            (short)maxmath.intcbrt(x.x12, true),
                                            (short)maxmath.intcbrt(x.x13, true),
                                            (short)maxmath.intcbrt(x.x14, true),
                                            (short)maxmath.intcbrt(x.x15, true)),
                                maxmath.intcbrt(x, true));
            }
        }

        
        [Test]
        public static void uint1()
        {
            Assert.AreEqual(1, maxmath.intcbrt((uint)1));
            Assert.AreEqual(2, maxmath.intcbrt((uint)8));
            Assert.AreEqual(3, maxmath.intcbrt((uint)27));
            Assert.AreEqual(4, maxmath.intcbrt((uint)64));
            Assert.AreEqual(5, maxmath.intcbrt((uint)125));
        }

        [Test]
        public static void uint2()
        {
            Random32 rng = new Random32(135);

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();

                Assert.AreEqual(new uint2((uint)maxmath.intcbrt(x.x), (uint)maxmath.intcbrt(x.y)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void uint3()
        {
            Random32 rng = new Random32(135);

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();

                Assert.AreEqual(new uint3((uint)maxmath.intcbrt(x.x), (uint)maxmath.intcbrt(x.y), (uint)maxmath.intcbrt(x.z)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void uint4()
        {
            Random32 rng = new Random32(135);

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();

                Assert.AreEqual(new uint4((uint)maxmath.intcbrt(x.x), (uint)maxmath.intcbrt(x.y), (uint)maxmath.intcbrt(x.z), (uint)maxmath.intcbrt(x.w)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void uint8()
        {
            Random32 rng = new Random32(135);

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();

                Assert.AreEqual(new uint8((uint)maxmath.intcbrt(x.x0),
                                          (uint)maxmath.intcbrt(x.x1),
                                          (uint)maxmath.intcbrt(x.x2),
                                          (uint)maxmath.intcbrt(x.x3),
                                          (uint)maxmath.intcbrt(x.x4),
                                          (uint)maxmath.intcbrt(x.x5),
                                          (uint)maxmath.intcbrt(x.x6),
                                          (uint)maxmath.intcbrt(x.x7)),
                                maxmath.intcbrt(x));
            }
        }

        
        [Test]
        public static void int1()
        {
            Assert.AreEqual(1, maxmath.intcbrt((int)1));
            Assert.AreEqual(2, maxmath.intcbrt((int)8));
            Assert.AreEqual(3, maxmath.intcbrt((int)27));
            Assert.AreEqual(4, maxmath.intcbrt((int)64));
            Assert.AreEqual(5, maxmath.intcbrt((int)125));

            Assert.AreEqual(-1, maxmath.intcbrt((int)-1, true));
            Assert.AreEqual(-2, maxmath.intcbrt((int)-8, true));
            Assert.AreEqual(-3, maxmath.intcbrt((int)-27, true));
            Assert.AreEqual(-4, maxmath.intcbrt((int)-64, true));
            Assert.AreEqual(-5, maxmath.intcbrt((int)-125, true));
        }

        [Test]
        public static void int2()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();

                Assert.AreEqual(new int2((int)maxmath.intcbrt(x.x, true), (int)maxmath.intcbrt(x.y, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void int3()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();

                Assert.AreEqual(new int3((int)maxmath.intcbrt(x.x, true), (int)maxmath.intcbrt(x.y, true), (int)maxmath.intcbrt(x.z, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void int4()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();

                Assert.AreEqual(new int4((int)maxmath.intcbrt(x.x, true), (int)maxmath.intcbrt(x.y, true), (int)maxmath.intcbrt(x.z, true), (int)maxmath.intcbrt(x.w, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void int8()
        {
            Random32 rng = new Random32(135);

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8();

                Assert.AreEqual(new int8((int)maxmath.intcbrt(x.x0, true),
                                         (int)maxmath.intcbrt(x.x1, true),
                                         (int)maxmath.intcbrt(x.x2, true),
                                         (int)maxmath.intcbrt(x.x3, true),
                                         (int)maxmath.intcbrt(x.x4, true),
                                         (int)maxmath.intcbrt(x.x5, true),
                                         (int)maxmath.intcbrt(x.x6, true),
                                         (int)maxmath.intcbrt(x.x7, true)),
                                maxmath.intcbrt(x, true));
            }
        }


        [Test]
        public static void ulong1()
        {
            Assert.AreEqual(1, maxmath.intcbrt((ulong)1));
            Assert.AreEqual(2, maxmath.intcbrt((ulong)8));
            Assert.AreEqual(3, maxmath.intcbrt((ulong)27));
            Assert.AreEqual(4, maxmath.intcbrt((ulong)64));
            Assert.AreEqual(5, maxmath.intcbrt((ulong)125));
        }

        [Test]
        public static void ulong2()
        {
            Random64 rng = new Random64(135);

            for (int i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)maxmath.intcbrt(x.x), (ulong)maxmath.intcbrt(x.y)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void ulong3()
        {
            Random64 rng = new Random64(135);

            for (int i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)maxmath.intcbrt(x.x), (ulong)maxmath.intcbrt(x.y), (ulong)maxmath.intcbrt(x.z)), maxmath.intcbrt(x));
            }
        }

        [Test]
        public static void ulong4()
        {
            Random64 rng = new Random64(135);

            for (int i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)maxmath.intcbrt(x.x), (ulong)maxmath.intcbrt(x.y), (ulong)maxmath.intcbrt(x.z), (ulong)maxmath.intcbrt(x.w)), maxmath.intcbrt(x));
            }
        }

        
        [Test]
        public static void long1()
        {
            Assert.AreEqual(1, maxmath.intcbrt((long)1));
            Assert.AreEqual(2, maxmath.intcbrt((long)8));
            Assert.AreEqual(3, maxmath.intcbrt((long)27));
            Assert.AreEqual(4, maxmath.intcbrt((long)64));
            Assert.AreEqual(5, maxmath.intcbrt((long)125));

            Assert.AreEqual(-1, maxmath.intcbrt((long)-1, true));
            Assert.AreEqual(-2, maxmath.intcbrt((long)-8, true));
            Assert.AreEqual(-3, maxmath.intcbrt((long)-27, true));
            Assert.AreEqual(-4, maxmath.intcbrt((long)-64, true));
            Assert.AreEqual(-5, maxmath.intcbrt((long)-125, true));
        }

        [Test]
        public static void long2()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();

                Assert.AreEqual(new long2((long)maxmath.intcbrt(x.x, true), (long)maxmath.intcbrt(x.y, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void long3()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();

                Assert.AreEqual(new long3((long)maxmath.intcbrt(x.x, true), (long)maxmath.intcbrt(x.y, true), (long)maxmath.intcbrt(x.z, true)), maxmath.intcbrt(x, true));
            }
        }

        [Test]
        public static void long4()
        {
            Random64 rng = new Random64(135);

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();

                Assert.AreEqual(new long4((long)maxmath.intcbrt(x.x, true), (long)maxmath.intcbrt(x.y, true), (long)maxmath.intcbrt(x.z, true), (long)maxmath.intcbrt(x.w, true)), maxmath.intcbrt(x, true));
            }
        }
    }
}