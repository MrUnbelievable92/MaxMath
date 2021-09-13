using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class abs
    {
        [Test]
        public static void Int128()
        {
            Random128 rng = new Random128("139715197519570146162068");

            for (int i = 0; i < 100; i++)
            {
                Int128 x = rng.NextInt128();

                Assert.AreEqual(maxmath.abs(x), x < 0 ? -x : x);
            }
        }

        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long2.NUM_TESTS; i++)
            {
                long2 x = maxmath.abs(Tests.__long2.TestData_LHS[i]);

                result &= x.x == math.abs(Tests.__long2.TestData_LHS[i].x) &
                          x.y == math.abs(Tests.__long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long3.NUM_TESTS; i++)
            {
                long3 x = maxmath.abs(Tests.__long3.TestData_LHS[i]);

                result &= x.x == math.abs(Tests.__long3.TestData_LHS[i].x) &
                          x.y == math.abs(Tests.__long3.TestData_LHS[i].y) &
                          x.z == math.abs(Tests.__long3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long4.NUM_TESTS; i++)
            {
                long4 x = maxmath.abs(Tests.__long4.TestData_LHS[i]);

                result &= x.x == math.abs(Tests.__long4.TestData_LHS[i].x) &
                          x.y == math.abs(Tests.__long4.TestData_LHS[i].y) &
                          x.z == math.abs(Tests.__long4.TestData_LHS[i].z) &
                          x.w == math.abs(Tests.__long4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Float8()
        {
            bool result = true;

            for (int i = 0; i < Tests.__float8.NUM_TESTS; i++)
            {
                float8 x = maxmath.abs(Tests.__float8.TestData_LHS[i]);

                result &= x.x0 == math.abs(Tests.__float8.TestData_LHS[i].x0) &
                          x.x1 == math.abs(Tests.__float8.TestData_LHS[i].x1) &
                          x.x2 == math.abs(Tests.__float8.TestData_LHS[i].x2) &
                          x.x3 == math.abs(Tests.__float8.TestData_LHS[i].x3) &
                          x.x4 == math.abs(Tests.__float8.TestData_LHS[i].x4) &
                          x.x5 == math.abs(Tests.__float8.TestData_LHS[i].x5) &
                          x.x6 == math.abs(Tests.__float8.TestData_LHS[i].x6) &
                          x.x7 == math.abs(Tests.__float8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }
    }
}