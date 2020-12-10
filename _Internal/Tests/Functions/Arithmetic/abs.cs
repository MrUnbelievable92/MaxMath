using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class abs
    {
        [UnitTest("Functions", "Arithmetic", "Absolute")]
        public static bool Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                long2 x = maxmath.abs(Tests.Long2.TestData_LHS[i]);

                result &= x.x == math.abs(Tests.Long2.TestData_LHS[i].x) &
                          x.y == math.abs(Tests.Long2.TestData_LHS[i].y);
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Absolute")]
        public static bool Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                long3 x = maxmath.abs(Tests.Long3.TestData_LHS[i]);

                result &= x.x == math.abs(Tests.Long3.TestData_LHS[i].x) &
                          x.y == math.abs(Tests.Long3.TestData_LHS[i].y) &
                          x.z == math.abs(Tests.Long3.TestData_LHS[i].z);
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Absolute")]
        public static bool Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                long4 x = maxmath.abs(Tests.Long4.TestData_LHS[i]);

                result &= x.x == math.abs(Tests.Long4.TestData_LHS[i].x) &
                          x.y == math.abs(Tests.Long4.TestData_LHS[i].y) &
                          x.z == math.abs(Tests.Long4.TestData_LHS[i].z) &
                          x.w == math.abs(Tests.Long4.TestData_LHS[i].w);
            }

            return result;
        }


        [UnitTest("Functions", "Arithmetic", "Absolute")]
        public static bool Float8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                float8 x = maxmath.abs(Tests.Float8.TestData_LHS[i]);

                result &= x.x0 == math.abs(Tests.Float8.TestData_LHS[i].x0) &
                          x.x1 == math.abs(Tests.Float8.TestData_LHS[i].x1) &
                          x.x2 == math.abs(Tests.Float8.TestData_LHS[i].x2) &
                          x.x3 == math.abs(Tests.Float8.TestData_LHS[i].x3) &
                          x.x4 == math.abs(Tests.Float8.TestData_LHS[i].x4) &
                          x.x5 == math.abs(Tests.Float8.TestData_LHS[i].x5) &
                          x.x6 == math.abs(Tests.Float8.TestData_LHS[i].x6) &
                          x.x7 == math.abs(Tests.Float8.TestData_LHS[i].x7);
            }

            return result;
        }
    }
}