using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_cprod
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte2 b = rng.NextByte2(0, (byte)math.pow(byte.MaxValue, 1f / 2f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte3 b = rng.NextByte3(0, (byte)math.pow(byte.MaxValue, 1f / 3f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte4 b = rng.NextByte4(0, (byte)math.pow(byte.MaxValue, 1f / 4f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte8 b = rng.NextByte8(0, (byte)math.pow(byte.MaxValue, 1f / 8f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte16 b = rng.NextByte16(0, (byte)math.pow(byte.MaxValue, 1f / 16f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte32 b = rng.NextByte32(0, (byte)math.pow(byte.MaxValue, 1f / 32f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        
        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort2 b = rng.NextUShort2(0, (ushort)math.pow(ushort.MaxValue, 1f / 2f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 b = rng.NextUShort3(0, (ushort)math.pow(ushort.MaxValue, 1f / 3f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 b = rng.NextUShort4(0, (ushort)math.pow(ushort.MaxValue, 1f / 4f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 b = rng.NextUShort8(0, (ushort)math.pow(ushort.MaxValue, 1f / 8f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 b = rng.NextUShort16(0, (ushort)math.pow(ushort.MaxValue, 1f / 16f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 b = rng.NextSByte2((sbyte)-math.pow(sbyte.MaxValue, 1f / 2f), (sbyte)math.pow(sbyte.MaxValue, 1f / 2f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 b = rng.NextSByte3((sbyte)-math.pow(sbyte.MaxValue, 1f / 3f), (sbyte)math.pow(sbyte.MaxValue, 1f / 3f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 b = rng.NextSByte4((sbyte)-math.pow(sbyte.MaxValue, 1f / 4f), (sbyte)math.pow(sbyte.MaxValue, 1f / 4f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 b = rng.NextSByte8((sbyte)-math.pow(sbyte.MaxValue, 1f / 8f), (sbyte)math.pow(sbyte.MaxValue, 1f / 8f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 b = rng.NextSByte16((sbyte)-math.pow(sbyte.MaxValue, 1f / 16f), (sbyte)math.pow(sbyte.MaxValue, 1f / 16f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte32 b = rng.NextSByte32((sbyte)-math.pow(sbyte.MaxValue, 1f / 32f), (sbyte)math.pow(sbyte.MaxValue, 1f / 32f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        
        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 b = rng.NextShort2((short)-math.pow(short.MaxValue, 1f / 2f), (short)math.pow(short.MaxValue, 1f / 2f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 b = rng.NextShort3((short)-math.pow(short.MaxValue, 1f / 3f), (short)math.pow(short.MaxValue, 1f / 3f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 b = rng.NextShort4((short)-math.pow(short.MaxValue, 1f / 4f), (short)math.pow(short.MaxValue, 1f / 4f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 b = rng.NextShort8((short)-math.pow(short.MaxValue, 1f / 8f), (short)math.pow(short.MaxValue, 1f / 8f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 b = rng.NextShort16((short)-math.pow(short.MaxValue, 1f / 16f), (short)math.pow(short.MaxValue, 1f / 16f));
                
                Assert.AreEqual(maxmath.cprod(b), maxmath.cprod(b, maxmath.Promise.NoOverflow));
            }
        }
    }
}
