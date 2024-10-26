using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_cavg
    {
        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte3 b = rng.NextByte3(0, byte.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte4 b = rng.NextByte4(0, byte.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));

                b = maxmath.select(b, 1, b == 0);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NonZero));
            }
        }


        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 b = rng.NextUShort3(0, ushort.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 b = rng.NextUShort4(0, ushort.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));

                b = maxmath.select(b, 1, b == 0);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NonZero));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 b = rng.NextUShort8(0, ushort.MaxValue / 8 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 b = rng.NextUShort16(0, ushort.MaxValue / 16 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint2 b = rng.NextUInt2(0, uint.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint3 b = rng.NextUInt3(0, uint.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint4 b = rng.NextUInt4(0, uint.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint8 b = rng.NextUInt8(0, uint.MaxValue / 8 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                ulong2 b = rng.NextULong2(0, ulong.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                ulong3 b = rng.NextULong3(0, ulong.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                ulong4 b = rng.NextULong4(0, ulong.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 b = rng.NextSByte2(-sbyte.MaxValue / 2 - 1, sbyte.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 b = rng.NextSByte3(-sbyte.MaxValue / 3 - 1, sbyte.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 b = rng.NextSByte4(-sbyte.MaxValue / 4 - 1, sbyte.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 b = rng.NextSByte8(-sbyte.MaxValue / 8 - 1, sbyte.MaxValue / 8 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 b = rng.NextSByte16(-sbyte.MaxValue / 16 - 1, sbyte.MaxValue / 16 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte32 b = rng.NextSByte32(-sbyte.MaxValue / 32 - 1, sbyte.MaxValue / 32 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 b = rng.NextShort2(-short.MaxValue / 2 - 1, short.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 b = rng.NextShort3(-short.MaxValue / 3 - 1, short.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 b = rng.NextShort4(-short.MaxValue / 4 - 1, short.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 b = rng.NextShort8(-short.MaxValue / 8 - 1, short.MaxValue / 8 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 b = rng.NextShort16(-short.MaxValue / 16 - 1, short.MaxValue / 16 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 b = rng.NextInt2(-int.MaxValue / 2 - 1, int.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 b = rng.NextInt3(-int.MaxValue / 3 - 1, int.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 b = rng.NextInt4(-int.MaxValue / 4 - 1, int.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 b = rng.NextInt8(-int.MaxValue / 8 - 1, int.MaxValue / 8 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long2 b = rng.NextLong2(-long.MaxValue / 2 - 1, long.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long3 b = rng.NextLong3(-long.MaxValue / 3 - 1, long.MaxValue / 3 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long4 b = rng.NextLong4(-long.MaxValue / 4 - 1, long.MaxValue / 4 - 1);

                Assert.AreEqual(maxmath.cavg(b), maxmath.cavg(b, Promise.NoOverflow));
            }
        }
    }
}
