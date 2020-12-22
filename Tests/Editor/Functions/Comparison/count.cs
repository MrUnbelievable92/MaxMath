using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class count
    {
        private const int NUM_TESTS = 8;
        private const uint RNG_SEED = 1747u;


        [Test]
        public static void Bool2()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool2 x = rng.NextBool2();

                int test = 0;

                for (int j = 0; j < 2; j++)
                {
                    if (x[j])
                    {
                        test++;
                    }
                }

                result &= test == maxmath.count(x);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Bool3()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool3 x = rng.NextBool3();

                int test = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (x[j])
                    {
                        test++;
                    }
                }

                result &= test == maxmath.count(x);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Bool4()
        {
            bool result = true;

            Random32 rng = new Random32(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4 x = rng.NextBool4();

                int test = 0;

                for (int j = 0; j < 4; j++)
                {
                    if (x[j])
                    {
                        test++;
                    }
                }

                result &= test == maxmath.count(x);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Bool8()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool8 x = rng.NextBool8();

                int test = 0;

                for (int j = 0; j < 8; j++)
                {
                    if (x[j])
                    {
                        test++;
                    }
                }

                result &= test == maxmath.count(x);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Bool16()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = new bool16(rng.NextBool8(), rng.NextBool8());

                int test = 0;

                for (int j = 0; j < 16; j++)
                {
                    if (x[j])
                    {
                        test++;
                    }
                }

                result &= test == maxmath.count(x);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Bool32()
        {
            bool result = true;

            Random64 rng = new Random64(RNG_SEED);

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool32 x = new bool32(rng.NextBool8(), rng.NextBool8(),  rng.NextBool8(), rng.NextBool8());

                int test = 0;

                for (int j = 0; j < 32; j++)
                {
                    if (x[j])
                    {
                        test++;
                    }
                }

                result &= test == maxmath.count(x);
            }

            Assert.AreEqual(true, result);
        }
    }
}