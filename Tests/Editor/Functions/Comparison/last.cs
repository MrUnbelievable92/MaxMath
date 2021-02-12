using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class last
    {
        public const int NUM_TESTS = 8;
        private const uint RNG_SEED = 1747u;


        [Test]
        public static void Bool2()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool2 x = rng.NextBool2();

                int test = maxmath.last(x);

                int j = 1;
                while (j != -1 && !x[j])
                {
                    j--;
                }

                result &= test == j;
            }

            Assert.AreEqual(result && maxmath.last(default(bool2)) == -1, true);
        }

        [Test]
        public static void Bool3()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = rng.NextBool3();

                int test = maxmath.last(x);

                int j = 2;
                while (j != -1 && !x[j])
                {
                    j--;
                }

                result &= test == j;
            }

            Assert.AreEqual(result && maxmath.last(default(bool3)) == -1, true);
        }

        [Test]
        public static void Bool4()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = rng.NextBool4();

                int test = maxmath.last(x);

                int j = 3;
                while (j != -1 && !x[j])
                {
                    j--;
                }

                result &= test == j;
            }

            Assert.AreEqual(result && maxmath.last(default(bool4)) == -1, true);
        }

        [Test]
        public static void Bool8()
        {
            bool result = true;

            
            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = rng.NextBool8();

                int test = maxmath.last(x);

                int j = 7;
                while (j != -1 && !x[j])
                {
                    j--;
                }

                result &= test == j;
            }

            Assert.AreEqual(result && maxmath.last(default(bool8)) == -1, true);
        }

        [Test]
        public static void Bool16()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = new bool16(rng.NextBool8(), rng.NextBool8());

                int test = maxmath.last(x);

                int j = 15;
                while (j != -1 && !x[j])
                {
                    j--;
                }

                result &= test == j;
            }

            Assert.AreEqual(result && maxmath.last(default(bool16)) == -1, true);
        }

        [Test]
        public static void Bool32()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = new bool32(rng.NextBool8(), rng.NextBool8(), rng.NextBool8(), rng.NextBool8());

                int test = maxmath.last(x);

                int j = 31;
                while (j != -1 && !x[j])
                {
                    j--;
                }

                result &= test == j;
            }

            Assert.AreEqual(result && maxmath.last(default(bool32)) == -1, true);
        }
    }
}