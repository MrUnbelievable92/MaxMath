using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_minmaxmag
    {
        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 l = rng.NextInt2(int.MinValue / 2, int.MaxValue / 2);
                int2 r = rng.NextInt2(int.MinValue / 2, int.MaxValue / 2);

                maxmath.minmaxmag(l, r, out int2 minstd, out int2 maxstd);
                maxmath.minmaxmag(l, r, out int2 minusf, out int2 maxusf, Promise.NoOverflow);

                Assert.AreEqual(minstd, minusf);
                Assert.AreEqual(maxstd, maxusf);
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

                maxmath.minmaxmag(l, r, out int3 minstd, out int3 maxstd);
                maxmath.minmaxmag(l, r, out int3 minusf, out int3 maxusf, Promise.NoOverflow);

                Assert.AreEqual(minstd, minusf);
                Assert.AreEqual(maxstd, maxusf);
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

                maxmath.minmaxmag(l, r, out int4 minstd, out int4 maxstd);
                maxmath.minmaxmag(l, r, out int4 minusf, out int4 maxusf, Promise.NoOverflow);

                Assert.AreEqual(minstd, minusf);
                Assert.AreEqual(maxstd, maxusf);
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

                maxmath.minmaxmag(l, r, out int8 minstd, out int8 maxstd);
                maxmath.minmaxmag(l, r, out int8 minusf, out int8 maxusf, Promise.NoOverflow);

                Assert.AreEqual(minstd, minusf);
                Assert.AreEqual(maxstd, maxusf);
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

                maxmath.minmaxmag(l, r, out long2 minstd, out long2 maxstd);
                maxmath.minmaxmag(l, r, out long2 minusf, out long2 maxusf, Promise.NoOverflow);

                Assert.AreEqual(minstd, minusf);
                Assert.AreEqual(maxstd, maxusf);
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

                maxmath.minmaxmag(l, r, out long3 minstd, out long3 maxstd);
                maxmath.minmaxmag(l, r, out long3 minusf, out long3 maxusf, Promise.NoOverflow);

                Assert.AreEqual(minstd, minusf);
                Assert.AreEqual(maxstd, maxusf);
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

                maxmath.minmaxmag(l, r, out long4 minstd, out long4 maxstd);
                maxmath.minmaxmag(l, r, out long4 minusf, out long4 maxusf, Promise.NoOverflow);

                Assert.AreEqual(minstd, minusf);
                Assert.AreEqual(maxstd, maxusf);
            }
        }
    }
}
