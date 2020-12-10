using DevTools;

namespace MaxMath.Tests
{
    unsafe public static class shr_a
    {
        [UnitTest("Functions", "Bitwise", "ShiftArithmeticRight")]
        public static bool Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                long2 x = maxmath.shr_a(Tests.Long2.TestData_LHS[i], new long2(Tests.Long2.TestData_int32[0], Tests.Long2.TestData_int32[3]));

                result &= x.x == Tests.Long2.TestData_LHS[i].x >> (int)Tests.Long2.TestData_int32[0];
                result &= x.y == Tests.Long2.TestData_LHS[i].y >> (int)Tests.Long2.TestData_int32[3];
            }

            return result;
        }

        [UnitTest("Functions", "Bitwise", "ShiftArithmeticRight")]
        public static bool Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                long3 x = maxmath.shr_a(Tests.Long3.TestData_LHS[i], new long3(Tests.Long3.TestData_int32[0], Tests.Long3.TestData_int32[1], Tests.Long3.TestData_int32[3]));

                result &= x.x == Tests.Long3.TestData_LHS[i].x >> (int)Tests.Long3.TestData_int32[0];
                result &= x.y == Tests.Long3.TestData_LHS[i].y >> (int)Tests.Long3.TestData_int32[1];
                result &= x.z == Tests.Long3.TestData_LHS[i].z >> (int)Tests.Long3.TestData_int32[3];
            }

            return result;
        }

        [UnitTest("Functions", "Bitwise", "ShiftArithmeticRight")]
        public static bool Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                long4 x = maxmath.shr_a(Tests.Long4.TestData_LHS[i], new long4(Tests.Long4.TestData_int32[0], Tests.Long4.TestData_int32[1], Tests.Long4.TestData_int32[2], Tests.Long4.TestData_int32[3]));

                result &= x.x == Tests.Long4.TestData_LHS[i].x >> (int)Tests.Long4.TestData_int32[0];
                result &= x.y == Tests.Long4.TestData_LHS[i].y >> (int)Tests.Long4.TestData_int32[1];
                result &= x.z == Tests.Long4.TestData_LHS[i].z >> (int)Tests.Long4.TestData_int32[2];
                result &= x.w == Tests.Long4.TestData_LHS[i].w >> (int)Tests.Long4.TestData_int32[3];
            }

            return result;
        }
    }
}