using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_avg
    {
        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 l = rng.NextShort2(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);
                short2 r = rng.NextShort2(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 l = rng.NextShort3(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);
                short3 r = rng.NextShort3(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 l = rng.NextShort4(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);
                short4 r = rng.NextShort4(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 l = rng.NextShort8(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);
                short8 r = rng.NextShort8(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 l = rng.NextShort16(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);
                short16 r = rng.NextShort16(-short.MaxValue / 2 + 1, short.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 l = rng.NextInt2(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);
                int2 r = rng.NextInt2(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 l = rng.NextInt3(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);
                int3 r = rng.NextInt3(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 l = rng.NextInt4(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);
                int4 r = rng.NextInt4(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 l = rng.NextInt8(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);
                int8 r = rng.NextInt8(-int.MaxValue / 2 + 1, int.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint2 l = rng.NextUInt2(0, uint.MaxValue / 2 - 1);
                uint2 r = rng.NextUInt2(0, uint.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint3 l = rng.NextUInt3(0, uint.MaxValue / 2 - 1);
                uint3 r = rng.NextUInt3(0, uint.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint4 l = rng.NextUInt4(0, uint.MaxValue / 2 - 1);
                uint4 r = rng.NextUInt4(0, uint.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint8 l = rng.NextUInt8(0, uint.MaxValue / 2 - 1);
                uint8 r = rng.NextUInt8(0, uint.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long2 l = rng.NextLong2(-long.MaxValue / 2 + 1, long.MaxValue / 2 - 1);
                long2 r = rng.NextLong2(-long.MaxValue / 2 + 1, long.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long3 l = rng.NextLong3(-long.MaxValue / 2 + 1, long.MaxValue / 2 - 1);
                long3 r = rng.NextLong3(-long.MaxValue / 2 + 1, long.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long4 l = rng.NextLong4(-long.MaxValue / 2 + 1, long.MaxValue / 2 - 1);
                long4 r = rng.NextLong4(-long.MaxValue / 2 + 1, long.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong2 l = rng.NextULong2(0, ulong.MaxValue / 2 - 1);
                ulong2 r = rng.NextULong2(0, ulong.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong3 l = rng.NextULong3(0, ulong.MaxValue / 2 - 1);
                ulong3 r = rng.NextULong3(0, ulong.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong4 l = rng.NextULong4(0, ulong.MaxValue / 2 - 1);
                ulong4 r = rng.NextULong4(0, ulong.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (ulong i = 0; i < 24; i++)
            {
                UInt128 l = rng.NextUInt128(0, UInt128.MaxValue / 2 - 1);
                UInt128 r = rng.NextUInt128(0, UInt128.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (ulong i = 0; i < 24; i++)
            {
                Int128 l = rng.NextInt128(-Int128.MaxValue / 2 + 1, Int128.MaxValue / 2 - 1);
                Int128 r = rng.NextInt128(-Int128.MaxValue / 2 + 1, Int128.MaxValue / 2 - 1);

                Assert.AreEqual(maxmath.avg(l, r), maxmath.avg(l, r, Promise.NoOverflow));
            }
        }
    }
}
