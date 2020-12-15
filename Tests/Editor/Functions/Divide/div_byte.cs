using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class div_byte
    {
        [Test]
        public static void Byte16_10()
        {
            bool result = true;

            for (int i = 0; i < Byte16.NUM_TESTS; i++)
            {
                byte16 x = Byte16.TestData_LHS[i] / 10;

                result &= x.x0 ==  (byte)(Byte16.TestData_LHS[i].x0  / 10) & 
                          x.x1 ==  (byte)(Byte16.TestData_LHS[i].x1  / 10) &
                          x.x2 ==  (byte)(Byte16.TestData_LHS[i].x2  / 10) &
                          x.x3 ==  (byte)(Byte16.TestData_LHS[i].x3  / 10) &
                          x.x4 ==  (byte)(Byte16.TestData_LHS[i].x4  / 10) &
                          x.x5 ==  (byte)(Byte16.TestData_LHS[i].x5  / 10) &
                          x.x6 ==  (byte)(Byte16.TestData_LHS[i].x6  / 10) &
                          x.x7 ==  (byte)(Byte16.TestData_LHS[i].x7  / 10) &
                          x.x8 ==  (byte)(Byte16.TestData_LHS[i].x8  / 10) &
                          x.x9 ==  (byte)(Byte16.TestData_LHS[i].x9  / 10) &
                          x.x10 == (byte)(Byte16.TestData_LHS[i].x10 / 10) &
                          x.x11 == (byte)(Byte16.TestData_LHS[i].x11 / 10) &
                          x.x12 == (byte)(Byte16.TestData_LHS[i].x12 / 10) &
                          x.x13 == (byte)(Byte16.TestData_LHS[i].x13 / 10) &
                          x.x14 == (byte)(Byte16.TestData_LHS[i].x14 / 10) &
                          x.x15 == (byte)(Byte16.TestData_LHS[i].x15 / 10);
            }

            Assert.AreEqual(result, true);
        }
        [Test]
        public static void Byte32_10()
        {
            bool result = true;

            for (int i = 0; i < Byte32.NUM_TESTS; i++)
            {
                byte32 x = Byte32.TestData_LHS[i] / 10;

                result &= x.x0 ==  (byte)(Byte32.TestData_LHS[i].x0  / 10) & 
                          x.x1 ==  (byte)(Byte32.TestData_LHS[i].x1  / 10) &
                          x.x2 ==  (byte)(Byte32.TestData_LHS[i].x2  / 10) &
                          x.x3 ==  (byte)(Byte32.TestData_LHS[i].x3  / 10) &
                          x.x4 ==  (byte)(Byte32.TestData_LHS[i].x4  / 10) &
                          x.x5 ==  (byte)(Byte32.TestData_LHS[i].x5  / 10) &
                          x.x6 ==  (byte)(Byte32.TestData_LHS[i].x6  / 10) &
                          x.x7 ==  (byte)(Byte32.TestData_LHS[i].x7  / 10) &
                          x.x8 ==  (byte)(Byte32.TestData_LHS[i].x8  / 10) &
                          x.x9 ==  (byte)(Byte32.TestData_LHS[i].x9  / 10) &
                          x.x10 == (byte)(Byte32.TestData_LHS[i].x10 / 10) &
                          x.x11 == (byte)(Byte32.TestData_LHS[i].x11 / 10) &
                          x.x12 == (byte)(Byte32.TestData_LHS[i].x12 / 10) &
                          x.x13 == (byte)(Byte32.TestData_LHS[i].x13 / 10) &
                          x.x14 == (byte)(Byte32.TestData_LHS[i].x14 / 10) &
                          x.x15 == (byte)(Byte32.TestData_LHS[i].x15 / 10) &
                          x.x16 == (byte)(Byte32.TestData_LHS[i].x16 / 10) &
                          x.x17 == (byte)(Byte32.TestData_LHS[i].x17 / 10) &
                          x.x18 == (byte)(Byte32.TestData_LHS[i].x18 / 10) &
                          x.x19 == (byte)(Byte32.TestData_LHS[i].x19 / 10) &
                          x.x20 == (byte)(Byte32.TestData_LHS[i].x20 / 10) &
                          x.x21 == (byte)(Byte32.TestData_LHS[i].x21 / 10) &
                          x.x22 == (byte)(Byte32.TestData_LHS[i].x22 / 10) &
                          x.x23 == (byte)(Byte32.TestData_LHS[i].x23 / 10) &
                          x.x24 == (byte)(Byte32.TestData_LHS[i].x24 / 10) &
                          x.x25 == (byte)(Byte32.TestData_LHS[i].x25 / 10) &
                          x.x26 == (byte)(Byte32.TestData_LHS[i].x26 / 10) &
                          x.x27 == (byte)(Byte32.TestData_LHS[i].x27 / 10) &
                          x.x28 == (byte)(Byte32.TestData_LHS[i].x28 / 10) &
                          x.x29 == (byte)(Byte32.TestData_LHS[i].x29 / 10) &
                          x.x30 == (byte)(Byte32.TestData_LHS[i].x30 / 10) &
                          x.x31 == (byte)(Byte32.TestData_LHS[i].x31 / 10);
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Byte16_100()
        {
            bool result = true;

            for (int i = 0; i < Byte16.NUM_TESTS; i++)
            {
                byte16 x = Byte16.TestData_LHS[i] / 100;

                result &= x.x0 ==  (byte)(Byte16.TestData_LHS[i].x0  / 100) & 
                          x.x1 ==  (byte)(Byte16.TestData_LHS[i].x1  / 100) &
                          x.x2 ==  (byte)(Byte16.TestData_LHS[i].x2  / 100) &
                          x.x3 ==  (byte)(Byte16.TestData_LHS[i].x3  / 100) &
                          x.x4 ==  (byte)(Byte16.TestData_LHS[i].x4  / 100) &
                          x.x5 ==  (byte)(Byte16.TestData_LHS[i].x5  / 100) &
                          x.x6 ==  (byte)(Byte16.TestData_LHS[i].x6  / 100) &
                          x.x7 ==  (byte)(Byte16.TestData_LHS[i].x7  / 100) &
                          x.x8 ==  (byte)(Byte16.TestData_LHS[i].x8  / 100) &
                          x.x9 ==  (byte)(Byte16.TestData_LHS[i].x9  / 100) &
                          x.x10 == (byte)(Byte16.TestData_LHS[i].x10 / 100) &
                          x.x11 == (byte)(Byte16.TestData_LHS[i].x11 / 100) &
                          x.x12 == (byte)(Byte16.TestData_LHS[i].x12 / 100) &
                          x.x13 == (byte)(Byte16.TestData_LHS[i].x13 / 100) &
                          x.x14 == (byte)(Byte16.TestData_LHS[i].x14 / 100) &
                          x.x15 == (byte)(Byte16.TestData_LHS[i].x15 / 100);
            }

            Assert.AreEqual(result, true);
        }
        [Test]
        public static void Byte32_100()
        {
            bool result = true;

            for (int i = 0; i < Byte32.NUM_TESTS; i++)
            {
                byte32 x = Byte32.TestData_LHS[i] / 100;

                result &= x.x0 ==  (byte)(Byte32.TestData_LHS[i].x0  / 100) & 
                          x.x1 ==  (byte)(Byte32.TestData_LHS[i].x1  / 100) &
                          x.x2 ==  (byte)(Byte32.TestData_LHS[i].x2  / 100) &
                          x.x3 ==  (byte)(Byte32.TestData_LHS[i].x3  / 100) &
                          x.x4 ==  (byte)(Byte32.TestData_LHS[i].x4  / 100) &
                          x.x5 ==  (byte)(Byte32.TestData_LHS[i].x5  / 100) &
                          x.x6 ==  (byte)(Byte32.TestData_LHS[i].x6  / 100) &
                          x.x7 ==  (byte)(Byte32.TestData_LHS[i].x7  / 100) &
                          x.x8 ==  (byte)(Byte32.TestData_LHS[i].x8  / 100) &
                          x.x9 ==  (byte)(Byte32.TestData_LHS[i].x9  / 100) &
                          x.x10 == (byte)(Byte32.TestData_LHS[i].x10 / 100) &
                          x.x11 == (byte)(Byte32.TestData_LHS[i].x11 / 100) &
                          x.x12 == (byte)(Byte32.TestData_LHS[i].x12 / 100) &
                          x.x13 == (byte)(Byte32.TestData_LHS[i].x13 / 100) &
                          x.x14 == (byte)(Byte32.TestData_LHS[i].x14 / 100) &
                          x.x15 == (byte)(Byte32.TestData_LHS[i].x15 / 100) &
                          x.x16 == (byte)(Byte32.TestData_LHS[i].x16 / 100) &
                          x.x17 == (byte)(Byte32.TestData_LHS[i].x17 / 100) &
                          x.x18 == (byte)(Byte32.TestData_LHS[i].x18 / 100) &
                          x.x19 == (byte)(Byte32.TestData_LHS[i].x19 / 100) &
                          x.x20 == (byte)(Byte32.TestData_LHS[i].x20 / 100) &
                          x.x21 == (byte)(Byte32.TestData_LHS[i].x21 / 100) &
                          x.x22 == (byte)(Byte32.TestData_LHS[i].x22 / 100) &
                          x.x23 == (byte)(Byte32.TestData_LHS[i].x23 / 100) &
                          x.x24 == (byte)(Byte32.TestData_LHS[i].x24 / 100) &
                          x.x25 == (byte)(Byte32.TestData_LHS[i].x25 / 100) &
                          x.x26 == (byte)(Byte32.TestData_LHS[i].x26 / 100) &
                          x.x27 == (byte)(Byte32.TestData_LHS[i].x27 / 100) &
                          x.x28 == (byte)(Byte32.TestData_LHS[i].x28 / 100) &
                          x.x29 == (byte)(Byte32.TestData_LHS[i].x29 / 100) &
                          x.x30 == (byte)(Byte32.TestData_LHS[i].x30 / 100) &
                          x.x31 == (byte)(Byte32.TestData_LHS[i].x31 / 100);
            }

            Assert.AreEqual(result, true);
        }
    }
}