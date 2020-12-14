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

                result &= x.x0  == Tests.UShort8.TestData_LHS[i].x0  / 3;
                result &= x.x1  == Tests.UShort8.TestData_LHS[i].x1  / 3;
                result &= x.x2  == Tests.UShort8.TestData_LHS[i].x2  / 3;
                result &= x.x3  == Tests.UShort8.TestData_LHS[i].x3  / 3;
                result &= x.x4  == Tests.UShort8.TestData_LHS[i].x4  / 3;
                result &= x.x5  == Tests.UShort8.TestData_LHS[i].x5  / 3;
                result &= x.x6  == Tests.UShort8.TestData_LHS[i].x6  / 3;
                result &= x.x7  == Tests.UShort8.TestData_LHS[i].x7  / 3;
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

        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort8_10()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                ushort8 x = Tests.UShort8.TestData_LHS[i] / 10;

                result &= x.x0  == Tests.UShort8.TestData_LHS[i].x0  / 10;
                result &= x.x1  == Tests.UShort8.TestData_LHS[i].x1  / 10;
                result &= x.x2  == Tests.UShort8.TestData_LHS[i].x2  / 10;
                result &= x.x3  == Tests.UShort8.TestData_LHS[i].x3  / 10;
                result &= x.x4  == Tests.UShort8.TestData_LHS[i].x4  / 10;
                result &= x.x5  == Tests.UShort8.TestData_LHS[i].x5  / 10;
                result &= x.x6  == Tests.UShort8.TestData_LHS[i].x6  / 10;
                result &= x.x7  == Tests.UShort8.TestData_LHS[i].x7  / 10;
            }

            return result;
        }
        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort16_10()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                ushort16 x = Tests.UShort16.TestData_LHS[i] / 10;

                result &= x.x0  == Tests.UShort16.TestData_LHS[i].x0  / 10;
                result &= x.x1  == Tests.UShort16.TestData_LHS[i].x1  / 10;
                result &= x.x2  == Tests.UShort16.TestData_LHS[i].x2  / 10;
                result &= x.x3  == Tests.UShort16.TestData_LHS[i].x3  / 10;
                result &= x.x4  == Tests.UShort16.TestData_LHS[i].x4  / 10;
                result &= x.x5  == Tests.UShort16.TestData_LHS[i].x5  / 10;
                result &= x.x6  == Tests.UShort16.TestData_LHS[i].x6  / 10;
                result &= x.x7  == Tests.UShort16.TestData_LHS[i].x7  / 10;
                result &= x.x8  == Tests.UShort16.TestData_LHS[i].x8  / 10;
                result &= x.x9  == Tests.UShort16.TestData_LHS[i].x9  / 10;
                result &= x.x10 == Tests.UShort16.TestData_LHS[i].x10 / 10;
                result &= x.x11 == Tests.UShort16.TestData_LHS[i].x11 / 10;
                result &= x.x12 == Tests.UShort16.TestData_LHS[i].x12 / 10;
                result &= x.x13 == Tests.UShort16.TestData_LHS[i].x13 / 10;
                result &= x.x14 == Tests.UShort16.TestData_LHS[i].x14 / 10;
                result &= x.x15 == Tests.UShort16.TestData_LHS[i].x15 / 10;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort8_100()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                ushort8 x = Tests.UShort8.TestData_LHS[i] / 100;

                result &= x.x0  == Tests.UShort8.TestData_LHS[i].x0  / 100;
                result &= x.x1  == Tests.UShort8.TestData_LHS[i].x1  / 100;
                result &= x.x2  == Tests.UShort8.TestData_LHS[i].x2  / 100;
                result &= x.x3  == Tests.UShort8.TestData_LHS[i].x3  / 100;
                result &= x.x4  == Tests.UShort8.TestData_LHS[i].x4  / 100;
                result &= x.x5  == Tests.UShort8.TestData_LHS[i].x5  / 100;
                result &= x.x6  == Tests.UShort8.TestData_LHS[i].x6  / 100;
                result &= x.x7  == Tests.UShort8.TestData_LHS[i].x7  / 100;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort16_100()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                ushort16 x = Tests.UShort16.TestData_LHS[i] / 100;

                result &= x.x0  == Tests.UShort16.TestData_LHS[i].x0  / 100;
                result &= x.x1  == Tests.UShort16.TestData_LHS[i].x1  / 100;
                result &= x.x2  == Tests.UShort16.TestData_LHS[i].x2  / 100;
                result &= x.x3  == Tests.UShort16.TestData_LHS[i].x3  / 100;
                result &= x.x4  == Tests.UShort16.TestData_LHS[i].x4  / 100;
                result &= x.x5  == Tests.UShort16.TestData_LHS[i].x5  / 100;
                result &= x.x6  == Tests.UShort16.TestData_LHS[i].x6  / 100;
                result &= x.x7  == Tests.UShort16.TestData_LHS[i].x7  / 100;
                result &= x.x8  == Tests.UShort16.TestData_LHS[i].x8  / 100;
                result &= x.x9  == Tests.UShort16.TestData_LHS[i].x9  / 100;
                result &= x.x10 == Tests.UShort16.TestData_LHS[i].x10 / 100;
                result &= x.x11 == Tests.UShort16.TestData_LHS[i].x11 / 100;
                result &= x.x12 == Tests.UShort16.TestData_LHS[i].x12 / 100;
                result &= x.x13 == Tests.UShort16.TestData_LHS[i].x13 / 100;
                result &= x.x14 == Tests.UShort16.TestData_LHS[i].x14 / 100;
                result &= x.x15 == Tests.UShort16.TestData_LHS[i].x15 / 100;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort8_1000()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                ushort8 x = Tests.UShort8.TestData_LHS[i] / 1000;

                result &= x.x0  == Tests.UShort8.TestData_LHS[i].x0  / 1000;
                result &= x.x1  == Tests.UShort8.TestData_LHS[i].x1  / 1000;
                result &= x.x2  == Tests.UShort8.TestData_LHS[i].x2  / 1000;
                result &= x.x3  == Tests.UShort8.TestData_LHS[i].x3  / 1000;
                result &= x.x4  == Tests.UShort8.TestData_LHS[i].x4  / 1000;
                result &= x.x5  == Tests.UShort8.TestData_LHS[i].x5  / 1000;
                result &= x.x6  == Tests.UShort8.TestData_LHS[i].x6  / 1000;
                result &= x.x7  == Tests.UShort8.TestData_LHS[i].x7  / 1000;
            }

            return result;
        }
        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort16_1000()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                ushort16 x = Tests.UShort16.TestData_LHS[i] / 1000;

                result &= x.x0  == Tests.UShort16.TestData_LHS[i].x0  / 1000;
                result &= x.x1  == Tests.UShort16.TestData_LHS[i].x1  / 1000;
                result &= x.x2  == Tests.UShort16.TestData_LHS[i].x2  / 1000;
                result &= x.x3  == Tests.UShort16.TestData_LHS[i].x3  / 1000;
                result &= x.x4  == Tests.UShort16.TestData_LHS[i].x4  / 1000;
                result &= x.x5  == Tests.UShort16.TestData_LHS[i].x5  / 1000;
                result &= x.x6  == Tests.UShort16.TestData_LHS[i].x6  / 1000;
                result &= x.x7  == Tests.UShort16.TestData_LHS[i].x7  / 1000;
                result &= x.x8  == Tests.UShort16.TestData_LHS[i].x8  / 1000;
                result &= x.x9  == Tests.UShort16.TestData_LHS[i].x9  / 1000;
                result &= x.x10 == Tests.UShort16.TestData_LHS[i].x10 / 1000;
                result &= x.x11 == Tests.UShort16.TestData_LHS[i].x11 / 1000;
                result &= x.x12 == Tests.UShort16.TestData_LHS[i].x12 / 1000;
                result &= x.x13 == Tests.UShort16.TestData_LHS[i].x13 / 1000;
                result &= x.x14 == Tests.UShort16.TestData_LHS[i].x14 / 1000;
                result &= x.x15 == Tests.UShort16.TestData_LHS[i].x15 / 1000;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort8_10000()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                ushort8 x = Tests.UShort8.TestData_LHS[i] / 10000;

                result &= x.x0  == Tests.UShort8.TestData_LHS[i].x0  / 10000;
                result &= x.x1  == Tests.UShort8.TestData_LHS[i].x1  / 10000;
                result &= x.x2  == Tests.UShort8.TestData_LHS[i].x2  / 10000;
                result &= x.x3  == Tests.UShort8.TestData_LHS[i].x3  / 10000;
                result &= x.x4  == Tests.UShort8.TestData_LHS[i].x4  / 10000;
                result &= x.x5  == Tests.UShort8.TestData_LHS[i].x5  / 10000;
                result &= x.x6  == Tests.UShort8.TestData_LHS[i].x6  / 10000;
                result &= x.x7  == Tests.UShort8.TestData_LHS[i].x7  / 10000;
            }

            return result;
        }
        [UnitTest("Functions", "Arithmetic", "Div")]
        public static bool UShort16_10000()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                ushort16 x = Tests.UShort16.TestData_LHS[i] / 10000;

                result &= x.x0  == Tests.UShort16.TestData_LHS[i].x0  / 10000;
                result &= x.x1  == Tests.UShort16.TestData_LHS[i].x1  / 10000;
                result &= x.x2  == Tests.UShort16.TestData_LHS[i].x2  / 10000;
                result &= x.x3  == Tests.UShort16.TestData_LHS[i].x3  / 10000;
                result &= x.x4  == Tests.UShort16.TestData_LHS[i].x4  / 10000;
                result &= x.x5  == Tests.UShort16.TestData_LHS[i].x5  / 10000;
                result &= x.x6  == Tests.UShort16.TestData_LHS[i].x6  / 10000;
                result &= x.x7  == Tests.UShort16.TestData_LHS[i].x7  / 10000;
                result &= x.x8  == Tests.UShort16.TestData_LHS[i].x8  / 10000;
                result &= x.x9  == Tests.UShort16.TestData_LHS[i].x9  / 10000;
                result &= x.x10 == Tests.UShort16.TestData_LHS[i].x10 / 10000;
                result &= x.x11 == Tests.UShort16.TestData_LHS[i].x11 / 10000;
                result &= x.x12 == Tests.UShort16.TestData_LHS[i].x12 / 10000;
                result &= x.x13 == Tests.UShort16.TestData_LHS[i].x13 / 10000;
                result &= x.x14 == Tests.UShort16.TestData_LHS[i].x14 / 10000;
                result &= x.x15 == Tests.UShort16.TestData_LHS[i].x15 / 10000;
            }

            return result;
        }
    }
}