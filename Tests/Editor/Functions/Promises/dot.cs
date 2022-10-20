using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_dot
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte2 l = rng.NextByte2(0, 128);
                byte2 r = rng.NextByte2(0, 128);
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextByte2(0, (byte)math.sqrt(ushort.MaxValue / 2));
                r = rng.NextByte2(0, (byte)math.sqrt(ushort.MaxValue / 2));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte3 l = rng.NextByte3(0, 128);
                byte3 r = rng.NextByte3(0, 128);
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextByte3(0, (byte)math.sqrt(ushort.MaxValue / 3));
                r = rng.NextByte3(0, (byte)math.sqrt(ushort.MaxValue / 3));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte4 l = rng.NextByte4(0, 128);
                byte4 r = rng.NextByte4(0, 128);
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextByte4(0, (byte)math.sqrt(ushort.MaxValue / 4));
                r = rng.NextByte4(0, (byte)math.sqrt(ushort.MaxValue / 4));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte8 l = rng.NextByte8(0, 128);
                byte8 r = rng.NextByte8(0, 128);
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextByte8(0, (byte)math.sqrt(ushort.MaxValue / 8));
                r = rng.NextByte8(0, (byte)math.sqrt(ushort.MaxValue / 8));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte16 l = rng.NextByte16(0, 128);
                byte16 r = rng.NextByte16(0, 128);
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextByte16(0, (byte)math.sqrt(ushort.MaxValue / 16));
                r = rng.NextByte16(0, (byte)math.sqrt(ushort.MaxValue / 16));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte32 l = rng.NextByte32(0, 128);
                byte32 r = rng.NextByte32(0, 128);
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextByte32(0, (byte)math.sqrt(ushort.MaxValue / 32));
                r = rng.NextByte32(0, (byte)math.sqrt(ushort.MaxValue / 32));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 l = rng.NextSByte2(-1, 127) + 1;
                sbyte2 r = rng.NextSByte2(-128, 127) + 1;
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextSByte2((sbyte)-math.sqrt(math.abs(short.MinValue) / 2), (sbyte)math.sqrt(short.MaxValue / 2));
                r = rng.NextSByte2((sbyte)-math.sqrt(math.abs(short.MinValue) / 2), (sbyte)math.sqrt(short.MaxValue / 2));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 l = rng.NextSByte3(-1, 127) + 1;
                sbyte3 r = rng.NextSByte3(-128, 127) + 1;
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextSByte3((sbyte)-math.sqrt(math.abs(short.MinValue) / 3), (sbyte)math.sqrt(short.MaxValue / 3));
                r = rng.NextSByte3((sbyte)-math.sqrt(math.abs(short.MinValue) / 3), (sbyte)math.sqrt(short.MaxValue / 3));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 l = rng.NextSByte4(-1, 127) + 1;
                sbyte4 r = rng.NextSByte4(-128, 127) + 1;
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextSByte4((sbyte)-math.sqrt(math.abs(short.MinValue) / 4), (sbyte)math.sqrt(short.MaxValue / 4));
                r = rng.NextSByte4((sbyte)-math.sqrt(math.abs(short.MinValue) / 4), (sbyte)math.sqrt(short.MaxValue / 4));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 l = rng.NextSByte8(-1, 127) + 1;
                sbyte8 r = rng.NextSByte8(-128, 127) + 1;
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextSByte8((sbyte)-math.sqrt(math.abs(short.MinValue) / 8), (sbyte)math.sqrt(short.MaxValue / 8));
                r = rng.NextSByte8((sbyte)-math.sqrt(math.abs(short.MinValue) / 8), (sbyte)math.sqrt(short.MaxValue / 8));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 l = rng.NextSByte16(-1, 127) + 1;
                sbyte16 r = rng.NextSByte16(-128, 127) + 1;
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextSByte16((sbyte)-math.sqrt(math.abs(short.MinValue) / 16), (sbyte)math.sqrt(short.MaxValue / 16));
                r = rng.NextSByte16((sbyte)-math.sqrt(math.abs(short.MinValue) / 16), (sbyte)math.sqrt(short.MaxValue / 16));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte32 l = rng.NextSByte32(-1, 127) + 1;
                sbyte32 r = rng.NextSByte32(-128, 127) + 1;
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.Unsafe0));
                
                l = rng.NextSByte32((sbyte)-math.sqrt(math.abs(short.MinValue) / 32), (sbyte)math.sqrt(short.MaxValue / 32));
                r = rng.NextSByte32((sbyte)-math.sqrt(math.abs(short.MinValue) / 32), (sbyte)math.sqrt(short.MaxValue / 32));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort2 l = rng.NextUShort2(0, (ushort)math.sqrt(ushort.MaxValue / 2));
                ushort2 r = rng.NextUShort2(0, (ushort)math.sqrt(ushort.MaxValue / 2));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 l = rng.NextUShort3(0, (ushort)math.sqrt(ushort.MaxValue / 3));
                ushort3 r = rng.NextUShort3(0, (ushort)math.sqrt(ushort.MaxValue / 3));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 l = rng.NextUShort4(0, (ushort)math.sqrt(ushort.MaxValue / 4));
                ushort4 r = rng.NextUShort4(0, (ushort)math.sqrt(ushort.MaxValue / 4));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 l = rng.NextUShort8(0, (ushort)math.sqrt(ushort.MaxValue / 8));
                ushort8 r = rng.NextUShort8(0, (ushort)math.sqrt(ushort.MaxValue / 8));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 l = rng.NextUShort16(0, (ushort)math.sqrt(ushort.MaxValue / 16));
                ushort16 r = rng.NextUShort16(0, (ushort)math.sqrt(ushort.MaxValue / 16));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 l = rng.NextShort2((short)-math.sqrt(math.abs(short.MinValue) / 2), (short)math.sqrt(short.MaxValue / 2));
                short2 r = rng.NextShort2((short)-math.sqrt(math.abs(short.MinValue) / 2), (short)math.sqrt(short.MaxValue / 2));
                
                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 l = rng.NextShort3((short)-math.sqrt(math.abs(short.MinValue) / 3), (short)math.sqrt(short.MaxValue / 3));
                short3 r = rng.NextShort3((short)-math.sqrt(math.abs(short.MinValue) / 3), (short)math.sqrt(short.MaxValue / 3));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 l = rng.NextShort4((short)-math.sqrt(math.abs(short.MinValue) / 4), (short)math.sqrt(short.MaxValue / 4));
                short4 r = rng.NextShort4((short)-math.sqrt(math.abs(short.MinValue) / 4), (short)math.sqrt(short.MaxValue / 4));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 l = rng.NextShort8((short)-math.sqrt(math.abs(short.MinValue) / 8), (short)math.sqrt(short.MaxValue / 8));
                short8 r = rng.NextShort8((short)-math.sqrt(math.abs(short.MinValue) / 8), (short)math.sqrt(short.MaxValue / 8));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 l = rng.NextShort16((short)-math.sqrt(math.abs(short.MinValue) / 16), (short)math.sqrt(short.MaxValue / 16));
                short16 r = rng.NextShort16((short)-math.sqrt(math.abs(short.MinValue) / 16), (short)math.sqrt(short.MaxValue / 16));

                Assert.AreEqual(maxmath.dot(l, r), maxmath.dot(l, r, maxmath.Promise.NoOverflow));
            }
        }
    }
}
