using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    /// Float/Double implicitly tested by testing Int/Long
    unsafe public static class mask_to_boolx
    {
        private static readonly int NUM_TESTS = 48;
        private static readonly uint RNG_SEED = 489373u;


        [UnitTest("Functions", "Arithmetic", "MaskToBooleans")]
        public static bool Bool2()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt(0, 4);
                bool2 x = maxmath.mask_to_bool2(r);

                for (int j = 0; j < 2; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Bitwise", "MaskToBooleans")]
        public static bool Bool3()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt();
                bool3 x = maxmath.mask_to_bool3(r);

                for (int j = 0; j < 3; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "MaskToBooleans")]
        public static bool Bool4()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt();
                bool4 x = maxmath.mask_to_bool4(r);

                for (int j = 0; j < 4; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "MaskToBooleans")]
        public static bool Bool8()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt(0, byte.MaxValue + 1);
                bool4x2 x = maxmath.mask_to_bool4x2(r);

                for (int j = 0; j < 4; j++)
                {
                    result &= x.c0[j] == System.Convert.ToBoolean((r >> j) & 1);
                    result &= x.c1[j] == System.Convert.ToBoolean((r >> (j + 4)) & 1);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "MaskToBooleans")]
        public static bool Bool16()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt(0, ushort.MaxValue + 1);
                bool4x4 x = maxmath.mask_to_bool4x4(r);

                for (int j = 0; j < 4; j++)
                {
                    result &= x.c0[j] == System.Convert.ToBoolean((r >> j) & 1);
                    result &= x.c1[j] == System.Convert.ToBoolean((r >> (j + 4)) & 1);
                    result &= x.c2[j] == System.Convert.ToBoolean((r >> (j + 8)) & 1);
                    result &= x.c3[j] == System.Convert.ToBoolean((r >> (j + 12)) & 1);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "MaskToBooleans")]
        public static bool Bool32()
        {
            Random32 rng = new Random32(RNG_SEED);

            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int r = rng.NextInt();
                bool32 x = maxmath.mask_to_bool32(r);

                for (int j = 0; j < 32; j++)
                {
                    result &= x[j] == System.Convert.ToBoolean((r >> j) & 1);
                }
            }

            return result;
        }
    }
#endif
}