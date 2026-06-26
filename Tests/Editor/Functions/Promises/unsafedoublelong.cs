using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_PROMISE_unsafedouble
    {
        [Test]
        public static void _long2todouble2unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long2 r = rng.NextLong2(-(1L << 51), (1L << 51) + 1);

                Assert.AreEqual((double2)r, math.todoubleunsafe(r, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _long3todouble3unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long3 r = rng.NextLong3(-(1L << 51), (1L << 51) + 1);

                Assert.AreEqual((double3)r, math.todoubleunsafe(r, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _long4todouble4unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long4 r = rng.NextLong4(-(1L << 51), (1L << 51) + 1);

                Assert.AreEqual((double4)r, math.todoubleunsafe(r, Promise.Unsafe1));
            }
        }


        [Test]
        public static void _ulong2todouble2unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong2 r = rng.NextULong2(0, 1ul << 52);

                Assert.AreEqual((double2)r, math.todoubleunsafe(r, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _ulong3todouble3unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong3 r = rng.NextULong3(0, 1ul << 52);

                Assert.AreEqual((double3)r, math.todoubleunsafe(r, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _ulong4todouble4unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong4 r = rng.NextULong4(0, 1ul << 52);

                Assert.AreEqual((double4)r, math.todoubleunsafe(r, Promise.Unsafe1));
            }
        }


        [Test]
        public static void _double2tolong2unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double2 r = rng.NextLong2(-(1L << 51), (1L << 51) + 1);

                Assert.AreEqual((long2)r, math.tolongunsafe(r, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _double3tolong3unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double3 r = rng.NextLong3(-(1L << 51), (1L << 51) + 1);

                Assert.AreEqual((long3)r, math.tolongunsafe(r, Promise.Unsafe1));

                r = rng.NextLong3();

                Assert.AreEqual((long3)r, math.tolongunsafe(r, Promise.Unsafe0));
            }
        }

        [Test]
        public static void _double4tolong4unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double4 r = rng.NextLong4(-(1L << 51), (1L << 51) + 1);

                Assert.AreEqual((long4)r, math.tolongunsafe(r, Promise.Unsafe1));

                r = rng.NextLong4();

                Assert.AreEqual((long4)r, math.tolongunsafe(r, Promise.Unsafe0));
            }
        }


        [Test]
        public static void _double2toulong2unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double2 r = rng.NextULong2(0, 1L << 52);

                Assert.AreEqual((ulong2)r, math.toulongunsafe(r, Promise.Unsafe1));
            }
        }

        [Test]
        public static void _double3toulong3unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double3 r = rng.NextULong3(0, 1L << 52);

                Assert.AreEqual((ulong3)r, math.toulongunsafe(r, Promise.Unsafe1));

                r = rng.NextULong3(0, (ulong)long.MaxValue + 1);

                Assert.AreEqual((ulong3)r, math.toulongunsafe(r, Promise.Unsafe0));
            }
        }

        [Test]
        public static void _double4toulong4unsafe()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double4 r = rng.NextULong4(0, 1L << 52);

                Assert.AreEqual((ulong4)r, math.toulongunsafe(r, Promise.Unsafe1));

                r = rng.NextULong4(0, (ulong)long.MaxValue + 1);

                Assert.AreEqual((ulong4)r, math.toulongunsafe(r, Promise.Unsafe0));
            }
        }
    }
}
