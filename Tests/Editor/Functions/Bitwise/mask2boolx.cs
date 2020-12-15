using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class masktobool
    {
        private const int NUM_TESTS = 48;
        private const uint RNG_SEED = 489373u;


        [Test]
        public static void Bool2()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt(0, 1) | (rng.NextInt(0, 1) << 8);
                bool2 x = maxmath.tobool2(r);

                for (int j = 0; j < 2; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Bool3()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt();
                bool3 x = maxmath.tobool3(r);

                for (int j = 0; j < 3; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Bool4()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt();
                bool4 x = maxmath.tobool4(r);

                for (int j = 0; j < 4; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Bool8()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt(0, byte.MaxValue + 1);
                bool8 x = maxmath.tobool8(r);

                for (int j = 0; j < 8; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Bool16()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt(0, ushort.MaxValue + 1);
                bool16 x = maxmath.tobool16(r);

                for (int j = 0; j < 4; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Bool32()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt();
                bool32 x = maxmath.tobool32(r);

                for (int j = 0; j < 32; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            Assert.AreEqual(result, true);
        }
    }
}