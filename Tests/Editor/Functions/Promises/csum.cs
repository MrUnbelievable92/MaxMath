using NUnit.Framework;

namespace MaxMath.Tests
{
    public static class PROMISE_csum
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte2 b = rng.NextByte2(0, byte.MaxValue / 2);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte3 b = rng.NextByte3(0, byte.MaxValue / 3);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte4 b = rng.NextByte4(0, byte.MaxValue / 4);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        
        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort2 b = rng.NextUShort2(0, ushort.MaxValue / 2);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 b = rng.NextUShort3(0, ushort.MaxValue / 3);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 b = rng.NextUShort4(0, ushort.MaxValue / 4);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 b = rng.NextUShort8(0, ushort.MaxValue / 8);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 b = rng.NextUShort16(0, ushort.MaxValue / 16);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 b = rng.NextSByte2(sbyte.MinValue / 2, sbyte.MaxValue / 2);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 b = rng.NextSByte3(sbyte.MinValue / 3, sbyte.MaxValue / 3);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 b = rng.NextSByte4(sbyte.MinValue / 4, sbyte.MaxValue / 4);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 b = rng.NextSByte8(sbyte.MinValue / 8, sbyte.MaxValue / 8);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 b = rng.NextSByte16(sbyte.MinValue / 16, sbyte.MaxValue / 16);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte32 b = rng.NextSByte32(sbyte.MinValue / 32, sbyte.MaxValue / 32);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        
        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 b = rng.NextShort2(short.MinValue / 2, short.MaxValue / 2);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 b = rng.NextShort3(short.MinValue / 3, short.MaxValue / 3);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 b = rng.NextShort4(short.MinValue / 4, short.MaxValue / 4);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 b = rng.NextShort8(short.MinValue / 8, short.MaxValue / 8);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 b = rng.NextShort16(short.MinValue / 16, short.MaxValue / 16);
                
                Assert.AreEqual(maxmath.csum(b), maxmath.csum(b, maxmath.Promise.NoOverflow));
            }
        }
    }
}
