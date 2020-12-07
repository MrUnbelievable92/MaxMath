﻿using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class first
    {
        private static readonly int NUM_TESTS = 8;
        private static readonly uint RNG_SEED = 1747u;


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

            return result;
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

            return result;
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

            return result;
        }
    }
#endif
}