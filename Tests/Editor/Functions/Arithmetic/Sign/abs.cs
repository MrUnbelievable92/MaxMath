using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_abs
    {
        [Test]
        public static void _Int128()
        {
            Random128 rng = new Random128("139715197519570146162068");

            for (int i = 0; i < 100; i++)
            {
                Int128 x = rng.NextInt128();

                Assert.AreEqual(maxmath.abs(x), x < 0 ? -x : x);
            }
        }

        [Test]
        public static void _long2()
        {
            bool result = true;

            for (int i = 0; i < t_long2.NUM_TESTS; i++)
            {
                long2 x = maxmath.abs(t_long2.TestData_LHS[i]);

                result &= x.x == math.abs(t_long2.TestData_LHS[i].x) &
                          x.y == math.abs(t_long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long3()
        {
            bool result = true;

            for (int i = 0; i < t_long3.NUM_TESTS; i++)
            {
                long3 x = maxmath.abs(t_long3.TestData_LHS[i]);

                result &= x.x == math.abs(t_long3.TestData_LHS[i].x) &
                          x.y == math.abs(t_long3.TestData_LHS[i].y) &
                          x.z == math.abs(t_long3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long4()
        {
            bool result = true;

            for (int i = 0; i < t_long4.NUM_TESTS; i++)
            {
                long4 x = maxmath.abs(t_long4.TestData_LHS[i]);

                result &= x.x == math.abs(t_long4.TestData_LHS[i].x) &
                          x.y == math.abs(t_long4.TestData_LHS[i].y) &
                          x.z == math.abs(t_long4.TestData_LHS[i].z) &
                          x.w == math.abs(t_long4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _float8()
        {
            bool result = true;

            for (int i = 0; i < t_float8.NUM_TESTS; i++)
            {
                float8 x = maxmath.abs(t_float8.TestData_LHS[i]);

                result &= x.x0 == math.abs(t_float8.TestData_LHS[i].x0) &
                          x.x1 == math.abs(t_float8.TestData_LHS[i].x1) &
                          x.x2 == math.abs(t_float8.TestData_LHS[i].x2) &
                          x.x3 == math.abs(t_float8.TestData_LHS[i].x3) &
                          x.x4 == math.abs(t_float8.TestData_LHS[i].x4) &
                          x.x5 == math.abs(t_float8.TestData_LHS[i].x5) &
                          x.x6 == math.abs(t_float8.TestData_LHS[i].x6) &
                          x.x7 == math.abs(t_float8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }
    }
}