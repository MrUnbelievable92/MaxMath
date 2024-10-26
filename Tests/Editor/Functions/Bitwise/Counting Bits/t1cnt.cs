using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_t1cnt
    {
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte2 x = rng.NextSByte2();

                Assert.AreEqual(new sbyte2((sbyte)maxmath.t1cnt(x.x), (sbyte)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte3 x = rng.NextSByte3();

                Assert.AreEqual(new sbyte3((sbyte)maxmath.t1cnt(x.x), (sbyte)maxmath.t1cnt(x.y), (sbyte)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte4 x = rng.NextSByte4();

                Assert.AreEqual(new sbyte4((sbyte)maxmath.t1cnt(x.x), (sbyte)maxmath.t1cnt(x.y), (sbyte)maxmath.t1cnt(x.z), (sbyte)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte8 x = rng.NextSByte8();

                Assert.AreEqual(new sbyte8((sbyte)maxmath.t1cnt(x.x0),
                                           (sbyte)maxmath.t1cnt(x.x1),
                                           (sbyte)maxmath.t1cnt(x.x2),
                                           (sbyte)maxmath.t1cnt(x.x3),
                                           (sbyte)maxmath.t1cnt(x.x4),
                                           (sbyte)maxmath.t1cnt(x.x5),
                                           (sbyte)maxmath.t1cnt(x.x6),
                                           (sbyte)maxmath.t1cnt(x.x7)),
                                maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte16 x = rng.NextSByte16();

                Assert.AreEqual(new sbyte16((sbyte)maxmath.t1cnt(x.x0),
                                            (sbyte)maxmath.t1cnt(x.x1),
                                            (sbyte)maxmath.t1cnt(x.x2),
                                            (sbyte)maxmath.t1cnt(x.x3),
                                            (sbyte)maxmath.t1cnt(x.x4),
                                            (sbyte)maxmath.t1cnt(x.x5),
                                            (sbyte)maxmath.t1cnt(x.x6),
                                            (sbyte)maxmath.t1cnt(x.x7),
                                            (sbyte)maxmath.t1cnt(x.x8),
                                            (sbyte)maxmath.t1cnt(x.x9),
                                            (sbyte)maxmath.t1cnt(x.x10),
                                            (sbyte)maxmath.t1cnt(x.x11),
                                            (sbyte)maxmath.t1cnt(x.x12),
                                            (sbyte)maxmath.t1cnt(x.x13),
                                            (sbyte)maxmath.t1cnt(x.x14),
                                            (sbyte)maxmath.t1cnt(x.x15)),
                                maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte32 x = rng.NextSByte32();

                Assert.AreEqual(new sbyte32((sbyte)maxmath.t1cnt(x.x0),
                                            (sbyte)maxmath.t1cnt(x.x1),
                                            (sbyte)maxmath.t1cnt(x.x2),
                                            (sbyte)maxmath.t1cnt(x.x3),
                                            (sbyte)maxmath.t1cnt(x.x4),
                                            (sbyte)maxmath.t1cnt(x.x5),
                                            (sbyte)maxmath.t1cnt(x.x6),
                                            (sbyte)maxmath.t1cnt(x.x7),
                                            (sbyte)maxmath.t1cnt(x.x8),
                                            (sbyte)maxmath.t1cnt(x.x9),
                                            (sbyte)maxmath.t1cnt(x.x10),
                                            (sbyte)maxmath.t1cnt(x.x11),
                                            (sbyte)maxmath.t1cnt(x.x12),
                                            (sbyte)maxmath.t1cnt(x.x13),
                                            (sbyte)maxmath.t1cnt(x.x14),
                                            (sbyte)maxmath.t1cnt(x.x15),
                                            (sbyte)maxmath.t1cnt(x.x16),
                                            (sbyte)maxmath.t1cnt(x.x17),
                                            (sbyte)maxmath.t1cnt(x.x18),
                                            (sbyte)maxmath.t1cnt(x.x19),
                                            (sbyte)maxmath.t1cnt(x.x20),
                                            (sbyte)maxmath.t1cnt(x.x21),
                                            (sbyte)maxmath.t1cnt(x.x22),
                                            (sbyte)maxmath.t1cnt(x.x23),
                                            (sbyte)maxmath.t1cnt(x.x24),
                                            (sbyte)maxmath.t1cnt(x.x25),
                                            (sbyte)maxmath.t1cnt(x.x26),
                                            (sbyte)maxmath.t1cnt(x.x27),
                                            (sbyte)maxmath.t1cnt(x.x28),
                                            (sbyte)maxmath.t1cnt(x.x29),
                                            (sbyte)maxmath.t1cnt(x.x30),
                                            (sbyte)maxmath.t1cnt(x.x31)),
                                maxmath.t1cnt(x));
            }
        }


        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(new byte2((byte)maxmath.t1cnt(x.x), (byte)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(new byte3((byte)maxmath.t1cnt(x.x), (byte)maxmath.t1cnt(x.y), (byte)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(new byte4((byte)maxmath.t1cnt(x.x), (byte)maxmath.t1cnt(x.y), (byte)maxmath.t1cnt(x.z), (byte)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                Assert.AreEqual(new byte8((byte)maxmath.t1cnt(x.x0),
                                          (byte)maxmath.t1cnt(x.x1),
                                          (byte)maxmath.t1cnt(x.x2),
                                          (byte)maxmath.t1cnt(x.x3),
                                          (byte)maxmath.t1cnt(x.x4),
                                          (byte)maxmath.t1cnt(x.x5),
                                          (byte)maxmath.t1cnt(x.x6),
                                          (byte)maxmath.t1cnt(x.x7)),
                                maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();

                Assert.AreEqual(new byte16((byte)maxmath.t1cnt(x.x0),
                                           (byte)maxmath.t1cnt(x.x1),
                                           (byte)maxmath.t1cnt(x.x2),
                                           (byte)maxmath.t1cnt(x.x3),
                                           (byte)maxmath.t1cnt(x.x4),
                                           (byte)maxmath.t1cnt(x.x5),
                                           (byte)maxmath.t1cnt(x.x6),
                                           (byte)maxmath.t1cnt(x.x7),
                                           (byte)maxmath.t1cnt(x.x8),
                                           (byte)maxmath.t1cnt(x.x9),
                                           (byte)maxmath.t1cnt(x.x10),
                                           (byte)maxmath.t1cnt(x.x11),
                                           (byte)maxmath.t1cnt(x.x12),
                                           (byte)maxmath.t1cnt(x.x13),
                                           (byte)maxmath.t1cnt(x.x14),
                                           (byte)maxmath.t1cnt(x.x15)),
                                maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                Assert.AreEqual(new byte32((byte)maxmath.t1cnt(x.x0),
                                           (byte)maxmath.t1cnt(x.x1),
                                           (byte)maxmath.t1cnt(x.x2),
                                           (byte)maxmath.t1cnt(x.x3),
                                           (byte)maxmath.t1cnt(x.x4),
                                           (byte)maxmath.t1cnt(x.x5),
                                           (byte)maxmath.t1cnt(x.x6),
                                           (byte)maxmath.t1cnt(x.x7),
                                           (byte)maxmath.t1cnt(x.x8),
                                           (byte)maxmath.t1cnt(x.x9),
                                           (byte)maxmath.t1cnt(x.x10),
                                           (byte)maxmath.t1cnt(x.x11),
                                           (byte)maxmath.t1cnt(x.x12),
                                           (byte)maxmath.t1cnt(x.x13),
                                           (byte)maxmath.t1cnt(x.x14),
                                           (byte)maxmath.t1cnt(x.x15),
                                           (byte)maxmath.t1cnt(x.x16),
                                           (byte)maxmath.t1cnt(x.x17),
                                           (byte)maxmath.t1cnt(x.x18),
                                           (byte)maxmath.t1cnt(x.x19),
                                           (byte)maxmath.t1cnt(x.x20),
                                           (byte)maxmath.t1cnt(x.x21),
                                           (byte)maxmath.t1cnt(x.x22),
                                           (byte)maxmath.t1cnt(x.x23),
                                           (byte)maxmath.t1cnt(x.x24),
                                           (byte)maxmath.t1cnt(x.x25),
                                           (byte)maxmath.t1cnt(x.x26),
                                           (byte)maxmath.t1cnt(x.x27),
                                           (byte)maxmath.t1cnt(x.x28),
                                           (byte)maxmath.t1cnt(x.x29),
                                           (byte)maxmath.t1cnt(x.x30),
                                           (byte)maxmath.t1cnt(x.x31)),
                                maxmath.t1cnt(x));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();

                Assert.AreEqual(new short2((short)maxmath.t1cnt(x.x), (short)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();

                Assert.AreEqual(new short3((short)maxmath.t1cnt(x.x), (short)maxmath.t1cnt(x.y), (short)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();

                Assert.AreEqual(new short4((short)maxmath.t1cnt(x.x), (short)maxmath.t1cnt(x.y), (short)maxmath.t1cnt(x.z), (short)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();

                Assert.AreEqual(new short8((short)maxmath.t1cnt(x.x0),
                                           (short)maxmath.t1cnt(x.x1),
                                           (short)maxmath.t1cnt(x.x2),
                                           (short)maxmath.t1cnt(x.x3),
                                           (short)maxmath.t1cnt(x.x4),
                                           (short)maxmath.t1cnt(x.x5),
                                           (short)maxmath.t1cnt(x.x6),
                                           (short)maxmath.t1cnt(x.x7)),
                                maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();

                Assert.AreEqual(new short16((short)maxmath.t1cnt(x.x0),
                                            (short)maxmath.t1cnt(x.x1),
                                            (short)maxmath.t1cnt(x.x2),
                                            (short)maxmath.t1cnt(x.x3),
                                            (short)maxmath.t1cnt(x.x4),
                                            (short)maxmath.t1cnt(x.x5),
                                            (short)maxmath.t1cnt(x.x6),
                                            (short)maxmath.t1cnt(x.x7),
                                            (short)maxmath.t1cnt(x.x8),
                                            (short)maxmath.t1cnt(x.x9),
                                            (short)maxmath.t1cnt(x.x10),
                                            (short)maxmath.t1cnt(x.x11),
                                            (short)maxmath.t1cnt(x.x12),
                                            (short)maxmath.t1cnt(x.x13),
                                            (short)maxmath.t1cnt(x.x14),
                                            (short)maxmath.t1cnt(x.x15)),
                                maxmath.t1cnt(x));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(new ushort2((ushort)maxmath.t1cnt(x.x), (ushort)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(new ushort3((ushort)maxmath.t1cnt(x.x), (ushort)maxmath.t1cnt(x.y), (ushort)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(new ushort4((ushort)maxmath.t1cnt(x.x), (ushort)maxmath.t1cnt(x.y), (ushort)maxmath.t1cnt(x.z), (ushort)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                Assert.AreEqual(new ushort8((ushort)maxmath.t1cnt(x.x0),
                                            (ushort)maxmath.t1cnt(x.x1),
                                            (ushort)maxmath.t1cnt(x.x2),
                                            (ushort)maxmath.t1cnt(x.x3),
                                            (ushort)maxmath.t1cnt(x.x4),
                                            (ushort)maxmath.t1cnt(x.x5),
                                            (ushort)maxmath.t1cnt(x.x6),
                                            (ushort)maxmath.t1cnt(x.x7)),
                                maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();

                Assert.AreEqual(new ushort16((ushort)maxmath.t1cnt(x.x0),
                                             (ushort)maxmath.t1cnt(x.x1),
                                             (ushort)maxmath.t1cnt(x.x2),
                                             (ushort)maxmath.t1cnt(x.x3),
                                             (ushort)maxmath.t1cnt(x.x4),
                                             (ushort)maxmath.t1cnt(x.x5),
                                             (ushort)maxmath.t1cnt(x.x6),
                                             (ushort)maxmath.t1cnt(x.x7),
                                             (ushort)maxmath.t1cnt(x.x8),
                                             (ushort)maxmath.t1cnt(x.x9),
                                             (ushort)maxmath.t1cnt(x.x10),
                                             (ushort)maxmath.t1cnt(x.x11),
                                             (ushort)maxmath.t1cnt(x.x12),
                                             (ushort)maxmath.t1cnt(x.x13),
                                             (ushort)maxmath.t1cnt(x.x14),
                                             (ushort)maxmath.t1cnt(x.x15)),
                                maxmath.t1cnt(x));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();

                Assert.AreEqual(new int2((int)maxmath.t1cnt(x.x), (int)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();

                Assert.AreEqual(new int3((int)maxmath.t1cnt(x.x), (int)maxmath.t1cnt(x.y), (int)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();

                Assert.AreEqual(new int4((int)maxmath.t1cnt(x.x), (int)maxmath.t1cnt(x.y), (int)maxmath.t1cnt(x.z), (int)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
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

                Assert.AreEqual(new int8((int)maxmath.t1cnt(x.x0),
                                         (int)maxmath.t1cnt(x.x1),
                                         (int)maxmath.t1cnt(x.x2),
                                         (int)maxmath.t1cnt(x.x3),
                                         (int)maxmath.t1cnt(x.x4),
                                         (int)maxmath.t1cnt(x.x5),
                                         (int)maxmath.t1cnt(x.x6),
                                         (int)maxmath.t1cnt(x.x7)),
                                maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();

                Assert.AreEqual(new int2((int)maxmath.t1cnt(x.x), (int)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();

                Assert.AreEqual(new int3((int)maxmath.t1cnt(x.x), (int)maxmath.t1cnt(x.y), (int)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();

                Assert.AreEqual(new int4((int)maxmath.t1cnt(x.x), (int)maxmath.t1cnt(x.y), (int)maxmath.t1cnt(x.z), (int)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
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

                Assert.AreEqual(new int8((int)maxmath.t1cnt(x.x0),
                                         (int)maxmath.t1cnt(x.x1),
                                         (int)maxmath.t1cnt(x.x2),
                                         (int)maxmath.t1cnt(x.x3),
                                         (int)maxmath.t1cnt(x.x4),
                                         (int)maxmath.t1cnt(x.x5),
                                         (int)maxmath.t1cnt(x.x6),
                                         (int)maxmath.t1cnt(x.x7)),
                                maxmath.t1cnt(x));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();

                Assert.AreEqual(new long2((long)maxmath.t1cnt(x.x), (long)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();

                Assert.AreEqual(new long3((long)maxmath.t1cnt(x.x), (long)maxmath.t1cnt(x.y), (long)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();

                Assert.AreEqual(new long4((long)maxmath.t1cnt(x.x), (long)maxmath.t1cnt(x.y), (long)maxmath.t1cnt(x.z), (long)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                Assert.AreEqual(new ulong2((ulong)maxmath.t1cnt(x.x), (ulong)maxmath.t1cnt(x.y)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                Assert.AreEqual(new ulong3((ulong)maxmath.t1cnt(x.x), (ulong)maxmath.t1cnt(x.y), (ulong)maxmath.t1cnt(x.z)), maxmath.t1cnt(x));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                Assert.AreEqual(new ulong4((ulong)maxmath.t1cnt(x.x), (ulong)maxmath.t1cnt(x.y), (ulong)maxmath.t1cnt(x.z), (ulong)maxmath.t1cnt(x.w)), maxmath.t1cnt(x));
            }
        }
    }
}