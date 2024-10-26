using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class f_square
    {
        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 100; i++)
            {
                UInt128 x = rng.NextUInt128();

                Assert.AreEqual(x * x, maxmath.square(x));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 100; i++)
            {
                Int128 x = rng.NextInt128();

                Assert.AreEqual(x * x, maxmath.square(x));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                ulong2 x = rng.NextULong2();

                ulong2 sq = x * x;

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(sq[j], x[j] * x[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                ulong3 x = rng.NextULong3();

                ulong3 sq = x * x;

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(sq[j], x[j] * x[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                ulong4 x = rng.NextULong4();

                ulong4 sq = x * x;

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(sq[j], x[j] * x[j]);
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                long2 x = rng.NextLong2();

                long2 sq = x * x;

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(sq[j], x[j] * x[j]);
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                long3 x = rng.NextLong3();

                long3 sq = x * x;

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(sq[j], x[j] * x[j]);
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                long4 x = rng.NextLong4();

                long4 sq = x * x;

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(sq[j], x[j] * x[j]);
                }
            }
        }
    }
}