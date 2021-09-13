using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class square
    {
        [Test]
        public static void uint128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 100; i++)
            {
                UInt128 x = rng.NextUInt128();

                Assert.AreEqual(x * x, maxmath.square(x));
            }
        }

        [Test]
        public static void int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 100; i++)
            {
                Int128 x = rng.NextInt128();

                Assert.AreEqual(x * x, maxmath.square(x));
            }
        }
    }
}
