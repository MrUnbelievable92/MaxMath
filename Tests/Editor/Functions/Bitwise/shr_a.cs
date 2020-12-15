using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class shra
    {
        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                for (int j = 0; j < 64; j += 2)
                {
                    long2 x = maxmath.shra(Tests.Long2.TestData_LHS[i], new long2(math.min(j, 63), math.min(j + 1, 63)));

                    result &= x.x == Tests.Long2.TestData_LHS[i].x >> math.min(j, 63);
                    result &= x.y == Tests.Long2.TestData_LHS[i].y >> math.min(j + 1, 63);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                for (int j = 0; j < 64; j += 3)
                {
                    long3 x = maxmath.shra(Tests.Long3.TestData_LHS[i], new long3(math.min(j, 63), math.min(j + 1, 63), math.min(j + 2, 63)));

                    result &= x.x == Tests.Long3.TestData_LHS[i].x >> math.min(j, 63);
                    result &= x.y == Tests.Long3.TestData_LHS[i].y >> math.min(j + 1, 63);
                    result &= x.z == Tests.Long3.TestData_LHS[i].z >> math.min(j + 2, 63);
                }
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 64; j += 4)
                {
                    long4 x = maxmath.shra(Tests.Long4.TestData_LHS[i], new long4(math.min(j, 63), math.min(j + 1, 63), math.min(j + 2, 63), math.min(j + 3, 63)));

                    result &= x.x == Tests.Long4.TestData_LHS[i].x >> math.min(j, 63);
                    result &= x.y == Tests.Long4.TestData_LHS[i].y >> math.min(j + 1, 63);
                    result &= x.z == Tests.Long4.TestData_LHS[i].z >> math.min(j + 2, 63);
                    result &= x.w == Tests.Long4.TestData_LHS[i].w >> math.min(j + 3, 63);
                }
            }

            Assert.AreEqual(result, true);
        }
    }
}