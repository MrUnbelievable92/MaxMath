using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_cmaxmag
    {
        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 l = rng.NextInt2(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.cmaxmag(l, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 l = rng.NextInt3(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.cmaxmag(l, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 l = rng.NextInt4(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.cmaxmag(l, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 l = rng.NextInt8(int.MinValue / 2, int.MaxValue / 2);

                Assert.AreEqual(maxmath.cmaxmag(l), maxmath.cmaxmag(l, maxmath.Promise.NoOverflow));
            }
        }
    }
}
