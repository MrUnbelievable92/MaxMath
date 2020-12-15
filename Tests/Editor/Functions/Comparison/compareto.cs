using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class compareto
    {
        [Test]
        public static void Int()
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

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void UInt()
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

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Long()
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

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void ULong()
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

            Assert.AreEqual(result, true);
        }
    }
}