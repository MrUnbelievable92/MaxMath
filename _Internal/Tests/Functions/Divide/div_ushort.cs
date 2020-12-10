using DevTools;

namespace MaxMath.Tests
{
    unsafe public static class div_ushort
    {
        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort8_3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                ushort8 x = Tests.UShort8.TestData_LHS[i] / 3;

                result &= x.x0 == Tests.UShort8.TestData_LHS[i].x0 / 3;
                result &= x.x1 == Tests.UShort8.TestData_LHS[i].x1 / 3;
                result &= x.x2 == Tests.UShort8.TestData_LHS[i].x2 / 3;
                result &= x.x3 == Tests.UShort8.TestData_LHS[i].x3 / 3;
                result &= x.x4 == Tests.UShort8.TestData_LHS[i].x4 / 3;
                result &= x.x5 == Tests.UShort8.TestData_LHS[i].x5 / 3;
                result &= x.x6 == Tests.UShort8.TestData_LHS[i].x6 / 3;
                result &= x.x7 == Tests.UShort8.TestData_LHS[i].x7 / 3;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort16_3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                ushort16 x = Tests.UShort16.TestData_LHS[i] / 3;

                result &= x.x0  == Tests.UShort16.TestData_LHS[i].x0  / 3;
                result &= x.x1  == Tests.UShort16.TestData_LHS[i].x1  / 3;
                result &= x.x2  == Tests.UShort16.TestData_LHS[i].x2  / 3;
                result &= x.x3  == Tests.UShort16.TestData_LHS[i].x3  / 3;
                result &= x.x4  == Tests.UShort16.TestData_LHS[i].x4  / 3;
                result &= x.x5  == Tests.UShort16.TestData_LHS[i].x5  / 3;
                result &= x.x6  == Tests.UShort16.TestData_LHS[i].x6  / 3;
                result &= x.x7  == Tests.UShort16.TestData_LHS[i].x7  / 3;
                result &= x.x8  == Tests.UShort16.TestData_LHS[i].x8  / 3;
                result &= x.x9  == Tests.UShort16.TestData_LHS[i].x9  / 3;
                result &= x.x10 == Tests.UShort16.TestData_LHS[i].x10 / 3;
                result &= x.x11 == Tests.UShort16.TestData_LHS[i].x11 / 3;
                result &= x.x12 == Tests.UShort16.TestData_LHS[i].x12 / 3;
                result &= x.x13 == Tests.UShort16.TestData_LHS[i].x13 / 3;
                result &= x.x14 == Tests.UShort16.TestData_LHS[i].x14 / 3;
                result &= x.x15 == Tests.UShort16.TestData_LHS[i].x15 / 3;
            }

            return result;
        }
    }
}