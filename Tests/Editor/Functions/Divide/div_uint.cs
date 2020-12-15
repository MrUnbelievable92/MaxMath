using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class div_uint
    {
        [Test]
        public static void UInt8_366()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                uint8 x = Tests.UInt8.TestData_LHS[i] / 366;

                result &= x.x0 == Tests.UInt8.TestData_LHS[i].x0 / 366;
                result &= x.x1 == Tests.UInt8.TestData_LHS[i].x1 / 366;
                result &= x.x2 == Tests.UInt8.TestData_LHS[i].x2 / 366;
                result &= x.x3 == Tests.UInt8.TestData_LHS[i].x3 / 366;
                result &= x.x4 == Tests.UInt8.TestData_LHS[i].x4 / 366;
                result &= x.x5 == Tests.UInt8.TestData_LHS[i].x5 / 366;
                result &= x.x6 == Tests.UInt8.TestData_LHS[i].x6 / 366;
                result &= x.x7 == Tests.UInt8.TestData_LHS[i].x7 / 366;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UInt8_365()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                uint8 x = Tests.UInt8.TestData_LHS[i] / 365;

                result &= x.x0 == Tests.UInt8.TestData_LHS[i].x0 / 365;
                result &= x.x1 == Tests.UInt8.TestData_LHS[i].x1 / 365;
                result &= x.x2 == Tests.UInt8.TestData_LHS[i].x2 / 365;
                result &= x.x3 == Tests.UInt8.TestData_LHS[i].x3 / 365;
                result &= x.x4 == Tests.UInt8.TestData_LHS[i].x4 / 365;
                result &= x.x5 == Tests.UInt8.TestData_LHS[i].x5 / 365;
                result &= x.x6 == Tests.UInt8.TestData_LHS[i].x6 / 365;
                result &= x.x7 == Tests.UInt8.TestData_LHS[i].x7 / 365;
            }

            Assert.AreEqual(result, true);
        }
    }
}