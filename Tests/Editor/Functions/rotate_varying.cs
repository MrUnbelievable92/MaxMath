using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class rotate_varying
    {
        private const int NUM_ROTATION_TESTS = 4;

        [Test]
        public static void ror_uint8()
        {
            bool result = true;

            for (int i = 0; i < UInt8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    uint8 test = maxmath.ror(UInt8.TestData_LHS[i], UInt8.TestData_RHS[i]);

                    result &= test.x0 == math.ror(UInt8.TestData_LHS[i].x0, (int)UInt8.TestData_RHS[i].x0);
                    result &= test.x1 == math.ror(UInt8.TestData_LHS[i].x1, (int)UInt8.TestData_RHS[i].x1);
                    result &= test.x2 == math.ror(UInt8.TestData_LHS[i].x2, (int)UInt8.TestData_RHS[i].x2);
                    result &= test.x3 == math.ror(UInt8.TestData_LHS[i].x3, (int)UInt8.TestData_RHS[i].x3);
                    result &= test.x4 == math.ror(UInt8.TestData_LHS[i].x4, (int)UInt8.TestData_RHS[i].x4);
                    result &= test.x5 == math.ror(UInt8.TestData_LHS[i].x5, (int)UInt8.TestData_RHS[i].x5);
                    result &= test.x6 == math.ror(UInt8.TestData_LHS[i].x6, (int)UInt8.TestData_RHS[i].x6);
                    result &= test.x7 == math.ror(UInt8.TestData_LHS[i].x7, (int)UInt8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ror_ulong4()
        {
            bool result = true;

            for (int i = 0; i < ULong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    ulong4 test = maxmath.ror(ULong4.TestData_LHS[i], ULong4.TestData_RHS[i]);

                    result &= test.x == math.ror(ULong4.TestData_LHS[i].x, (int)ULong4.TestData_RHS[i].x);
                    result &= test.y == math.ror(ULong4.TestData_LHS[i].y, (int)ULong4.TestData_RHS[i].y);
                    result &= test.z == math.ror(ULong4.TestData_LHS[i].z, (int)ULong4.TestData_RHS[i].z);
                    result &= test.w == math.ror(ULong4.TestData_LHS[i].w, (int)ULong4.TestData_RHS[i].w);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_uint8()
        {
            bool result = true;

            for (int i = 0; i < UInt8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    uint8 test = maxmath.rol(UInt8.TestData_LHS[i], UInt8.TestData_RHS[i]);

                    result &= test.x0 == math.rol(UInt8.TestData_LHS[i].x0, (int)UInt8.TestData_RHS[i].x0);
                    result &= test.x1 == math.rol(UInt8.TestData_LHS[i].x1, (int)UInt8.TestData_RHS[i].x1);
                    result &= test.x2 == math.rol(UInt8.TestData_LHS[i].x2, (int)UInt8.TestData_RHS[i].x2);
                    result &= test.x3 == math.rol(UInt8.TestData_LHS[i].x3, (int)UInt8.TestData_RHS[i].x3);
                    result &= test.x4 == math.rol(UInt8.TestData_LHS[i].x4, (int)UInt8.TestData_RHS[i].x4);
                    result &= test.x5 == math.rol(UInt8.TestData_LHS[i].x5, (int)UInt8.TestData_RHS[i].x5);
                    result &= test.x6 == math.rol(UInt8.TestData_LHS[i].x6, (int)UInt8.TestData_RHS[i].x6);
                    result &= test.x7 == math.rol(UInt8.TestData_LHS[i].x7, (int)UInt8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_ulong4()
        {
            bool result = true;

            for (int i = 0; i < ULong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    ulong4 test = maxmath.rol(ULong4.TestData_LHS[i], ULong4.TestData_RHS[i]);

                    result &= test.x == math.rol(ULong4.TestData_LHS[i].x, (int)ULong4.TestData_RHS[i].x);
                    result &= test.y == math.rol(ULong4.TestData_LHS[i].y, (int)ULong4.TestData_RHS[i].y);
                    result &= test.z == math.rol(ULong4.TestData_LHS[i].z, (int)ULong4.TestData_RHS[i].z);
                    result &= test.w == math.rol(ULong4.TestData_LHS[i].w, (int)ULong4.TestData_RHS[i].w);
                }
            }

            Assert.AreEqual(true, result);
        }
    }
}
