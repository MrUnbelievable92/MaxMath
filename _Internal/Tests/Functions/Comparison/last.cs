using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class last
    {
        private const int NUM_TESTS = 8;
        private const uint RNG_SEED = 1747u;


        [UnitTest("Functions", "Bitwise", "Last")]
        public static bool Bool2()
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

            return result;
        }

        [UnitTest("Functions", "Bitwise", "Last")]
        public static bool Bool3()
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

            return result;
        }

        [UnitTest("Functions", "Bitwise", "Last")]
        public static bool Bool4()
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

            return result;
        }
    }
}