using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class first
    {
        private const int NUM_TESTS = 8;
        private const uint RNG_SEED = 1747u;


        [UnitTest("Functions", "Bitwise", "First")]
        public static bool Bool2()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool2 x = rng.NextBool2();

                int test = maxmath.first(x);

                int j = 0;
                while (j < 2 && !x[j])
                {
                    j++;
                }

                result &= test == j;
            }

            int testt = maxmath.first(default(bool2));

            return result && maxmath.first(default(bool2)) == 4;
        }

        [UnitTest("Functions", "Bitwise", "First")]
        public static bool Bool3()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = rng.NextBool3();

                int test = maxmath.first(x);

                int j = 0;
                while (j < 3 && !x[j])
                {
                    j++;
                }

                result &= test == j;
            }

            return result && maxmath.first(default(bool3)) == 4;
        }

        [UnitTest("Functions", "Bitwise", "First")]
        public static bool Bool4()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = rng.NextBool4();

                int test = maxmath.first(x);

                int j = 0;
                while (j < 4 && !x[j])
                {
                    j++;
                }

                result &= test == j;
            }

            return result && maxmath.first(default(bool4)) == 4;
        }

        [UnitTest("Functions", "Bitwise", "First")]
        public static bool Bool8()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = rng.NextBool8();

                int test = maxmath.first(x);

                int j = 0;
                while (j < 8 && !x[j])
                {
                    j++;
                }

                result &= test == j;
            }

            return result && maxmath.first(default(bool8)) == 8;
        }

        [UnitTest("Functions", "Bitwise", "First")]
        public static bool Bool16()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = new bool16(rng.NextBool8(), rng.NextBool8());

                int test = maxmath.first(x);

                int j = 0;
                while (j < 16 && !x[j])
                {
                    j++;
                }

                result &= test == j;
            }

            return result && maxmath.first(default(bool16)) == 32;
        }

        [UnitTest("Functions", "Bitwise", "First")]
        public static bool Bool32()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = new bool32(rng.NextBool8(), rng.NextBool8(), rng.NextBool8(), rng.NextBool8());

                int test = maxmath.first(x);

                int j = 0;
                while (j < 32 && !x[j])
                {
                    j++;
                }

                result &= test == j;
            }

            return result && maxmath.first(default(bool32)) == 32;
        }
    }
}