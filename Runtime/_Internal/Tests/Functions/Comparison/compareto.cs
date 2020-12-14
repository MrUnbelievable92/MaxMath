using DevTools;

namespace MaxMath.Tests
{
    unsafe public static class compareto
    {
        [UnitTest("Functions", "Comparison", "CompareTo")]
        public static bool Int()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result &= maxmath.compareto(Tests.Int8.TestData_LHS[i][j], Tests.Int8.TestData_RHS[i][j]) 
                              ==
                              Tests.Int8.TestData_LHS[i][j].CompareTo(Tests.Int8.TestData_RHS[i][j]);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Bitwise", "CompareTo")]
        public static bool UInt()
        {
            bool result = true;

            for (int i = 0; i < Tests.UInt8.NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    result &= maxmath.compareto(Tests.UInt8.TestData_LHS[i][j], Tests.UInt8.TestData_RHS[i][j])
                              ==
                              Tests.UInt8.TestData_LHS[i][j].CompareTo(Tests.UInt8.TestData_RHS[i][j]);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "CompareTo")]
        public static bool Long()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result &= maxmath.compareto(Tests.Long4.TestData_LHS[i][j], Tests.Long4.TestData_RHS[i][j])
                              ==
                              Tests.Long4.TestData_LHS[i][j].CompareTo(Tests.Long4.TestData_RHS[i][j]);
                }
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "CompareTo")]
        public static bool ULong()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result &= maxmath.compareto(Tests.ULong4.TestData_LHS[i][j], Tests.ULong4.TestData_RHS[i][j])
                              ==
                              Tests.ULong4.TestData_LHS[i][j].CompareTo(Tests.ULong4.TestData_RHS[i][j]);
                }
            }

            return result;
        }
    }
}