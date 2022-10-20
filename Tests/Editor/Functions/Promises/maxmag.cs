using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_maxmag
    {
        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 l = rng.NextInt2(int.MinValue / 2, int.MaxValue / 2);
                int2 r = rng.NextInt2(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.maxmag(l, r), maxmath.maxmag(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 l = rng.NextInt3(int.MinValue / 2, int.MaxValue / 2);
                int3 r = rng.NextInt3(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.maxmag(l, r), maxmath.maxmag(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 l = rng.NextInt4(int.MinValue / 2, int.MaxValue / 2);
                int4 r = rng.NextInt4(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.maxmag(l, r), maxmath.maxmag(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 l = rng.NextInt8(int.MinValue / 2, int.MaxValue / 2);
                int8 r = rng.NextInt8(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.maxmag(l, r), maxmath.maxmag(l, r, maxmath.Promise.NoOverflow));
            }
        }

        
        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long2 l = rng.NextLong2(long.MinValue / 2, long.MaxValue / 2);
                long2 r = rng.NextLong2(long.MinValue / 2, long.MaxValue / 2);

                Assert.AreEqual(maxmath.maxmag(l, r), maxmath.maxmag(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long3 l = rng.NextLong3(long.MinValue / 2, long.MaxValue / 2);
                long3 r = rng.NextLong3(long.MinValue / 2, long.MaxValue / 2);

                Assert.AreEqual(maxmath.maxmag(l, r), maxmath.maxmag(l, r, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long4 l = rng.NextLong4(long.MinValue / 2, long.MaxValue / 2);
                long4 r = rng.NextLong4(long.MinValue / 2, long.MaxValue / 2);

                Assert.AreEqual(maxmath.maxmag(l, r), maxmath.maxmag(l, r, maxmath.Promise.NoOverflow));
            }
        }
    }
}
