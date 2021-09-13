using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class rotate_varying
    {
        private const int NUM_ROTATION_TESTS = 4;


        [Test]
        public static void ror_sbyte8()
        {
            bool result = true;

            for (int i = 0; i < __sbyte8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    sbyte8 test = maxmath.ror(__sbyte8.TestData_LHS[i], __sbyte8.TestData_RHS[i]);

                    result &= test.x0 == maxmath.ror(__sbyte8.TestData_LHS[i].x0, __sbyte8.TestData_RHS[i].x0);
                    result &= test.x1 == maxmath.ror(__sbyte8.TestData_LHS[i].x1, __sbyte8.TestData_RHS[i].x1);
                    result &= test.x2 == maxmath.ror(__sbyte8.TestData_LHS[i].x2, __sbyte8.TestData_RHS[i].x2);
                    result &= test.x3 == maxmath.ror(__sbyte8.TestData_LHS[i].x3, __sbyte8.TestData_RHS[i].x3);
                    result &= test.x4 == maxmath.ror(__sbyte8.TestData_LHS[i].x4, __sbyte8.TestData_RHS[i].x4);
                    result &= test.x5 == maxmath.ror(__sbyte8.TestData_LHS[i].x5, __sbyte8.TestData_RHS[i].x5);
                    result &= test.x6 == maxmath.ror(__sbyte8.TestData_LHS[i].x6, __sbyte8.TestData_RHS[i].x6);
                    result &= test.x7 == maxmath.ror(__sbyte8.TestData_LHS[i].x7, __sbyte8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ror_short8()
        {
            bool result = true;

            for (int i = 0; i < __short8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    short8 test = maxmath.ror(__short8.TestData_LHS[i], __short8.TestData_RHS[i]);

                    result &= test.x0 == maxmath.ror(__short8.TestData_LHS[i].x0, __short8.TestData_RHS[i].x0);
                    result &= test.x1 == maxmath.ror(__short8.TestData_LHS[i].x1, __short8.TestData_RHS[i].x1);
                    result &= test.x2 == maxmath.ror(__short8.TestData_LHS[i].x2, __short8.TestData_RHS[i].x2);
                    result &= test.x3 == maxmath.ror(__short8.TestData_LHS[i].x3, __short8.TestData_RHS[i].x3);
                    result &= test.x4 == maxmath.ror(__short8.TestData_LHS[i].x4, __short8.TestData_RHS[i].x4);
                    result &= test.x5 == maxmath.ror(__short8.TestData_LHS[i].x5, __short8.TestData_RHS[i].x5);
                    result &= test.x6 == maxmath.ror(__short8.TestData_LHS[i].x6, __short8.TestData_RHS[i].x6);
                    result &= test.x7 == maxmath.ror(__short8.TestData_LHS[i].x7, __short8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ror_uint8()
        {
            bool result = true;

            for (int i = 0; i < __uint8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    uint8 test = maxmath.ror(__uint8.TestData_LHS[i], __uint8.TestData_RHS[i]);

                    result &= test.x0 == math.ror(__uint8.TestData_LHS[i].x0, (int)__uint8.TestData_RHS[i].x0);
                    result &= test.x1 == math.ror(__uint8.TestData_LHS[i].x1, (int)__uint8.TestData_RHS[i].x1);
                    result &= test.x2 == math.ror(__uint8.TestData_LHS[i].x2, (int)__uint8.TestData_RHS[i].x2);
                    result &= test.x3 == math.ror(__uint8.TestData_LHS[i].x3, (int)__uint8.TestData_RHS[i].x3);
                    result &= test.x4 == math.ror(__uint8.TestData_LHS[i].x4, (int)__uint8.TestData_RHS[i].x4);
                    result &= test.x5 == math.ror(__uint8.TestData_LHS[i].x5, (int)__uint8.TestData_RHS[i].x5);
                    result &= test.x6 == math.ror(__uint8.TestData_LHS[i].x6, (int)__uint8.TestData_RHS[i].x6);
                    result &= test.x7 == math.ror(__uint8.TestData_LHS[i].x7, (int)__uint8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ror_ulong4()
        {
            bool result = true;

            for (int i = 0; i < __ulong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    ulong4 test = maxmath.ror(__ulong4.TestData_LHS[i], __ulong4.TestData_RHS[i]);

                    result &= test.x == math.ror(__ulong4.TestData_LHS[i].x, (int)__ulong4.TestData_RHS[i].x);
                    result &= test.y == math.ror(__ulong4.TestData_LHS[i].y, (int)__ulong4.TestData_RHS[i].y);
                    result &= test.z == math.ror(__ulong4.TestData_LHS[i].z, (int)__ulong4.TestData_RHS[i].z);
                    result &= test.w == math.ror(__ulong4.TestData_LHS[i].w, (int)__ulong4.TestData_RHS[i].w);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void rol_sbyte8()
        {
            bool result = true;

            for (int i = 0; i < __sbyte8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    sbyte8 test = maxmath.rol(__sbyte8.TestData_LHS[i], __sbyte8.TestData_RHS[i]);

                    result &= test.x0 == maxmath.rol(__sbyte8.TestData_LHS[i].x0, __sbyte8.TestData_RHS[i].x0);
                    result &= test.x1 == maxmath.rol(__sbyte8.TestData_LHS[i].x1, __sbyte8.TestData_RHS[i].x1);
                    result &= test.x2 == maxmath.rol(__sbyte8.TestData_LHS[i].x2, __sbyte8.TestData_RHS[i].x2);
                    result &= test.x3 == maxmath.rol(__sbyte8.TestData_LHS[i].x3, __sbyte8.TestData_RHS[i].x3);
                    result &= test.x4 == maxmath.rol(__sbyte8.TestData_LHS[i].x4, __sbyte8.TestData_RHS[i].x4);
                    result &= test.x5 == maxmath.rol(__sbyte8.TestData_LHS[i].x5, __sbyte8.TestData_RHS[i].x5);
                    result &= test.x6 == maxmath.rol(__sbyte8.TestData_LHS[i].x6, __sbyte8.TestData_RHS[i].x6);
                    result &= test.x7 == maxmath.rol(__sbyte8.TestData_LHS[i].x7, __sbyte8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_short8()
        {
            bool result = true;

            for (int i = 0; i < __short8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    short8 test = maxmath.rol(__short8.TestData_LHS[i], __short8.TestData_RHS[i]);

                    result &= test.x0 == maxmath.rol(__short8.TestData_LHS[i].x0, __short8.TestData_RHS[i].x0);
                    result &= test.x1 == maxmath.rol(__short8.TestData_LHS[i].x1, __short8.TestData_RHS[i].x1);
                    result &= test.x2 == maxmath.rol(__short8.TestData_LHS[i].x2, __short8.TestData_RHS[i].x2);
                    result &= test.x3 == maxmath.rol(__short8.TestData_LHS[i].x3, __short8.TestData_RHS[i].x3);
                    result &= test.x4 == maxmath.rol(__short8.TestData_LHS[i].x4, __short8.TestData_RHS[i].x4);
                    result &= test.x5 == maxmath.rol(__short8.TestData_LHS[i].x5, __short8.TestData_RHS[i].x5);
                    result &= test.x6 == maxmath.rol(__short8.TestData_LHS[i].x6, __short8.TestData_RHS[i].x6);
                    result &= test.x7 == maxmath.rol(__short8.TestData_LHS[i].x7, __short8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_uint8()
        {
            bool result = true;

            for (int i = 0; i < __uint8.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    uint8 test = maxmath.rol(__uint8.TestData_LHS[i], __uint8.TestData_RHS[i]);

                    result &= test.x0 == math.rol(__uint8.TestData_LHS[i].x0, (int)__uint8.TestData_RHS[i].x0);
                    result &= test.x1 == math.rol(__uint8.TestData_LHS[i].x1, (int)__uint8.TestData_RHS[i].x1);
                    result &= test.x2 == math.rol(__uint8.TestData_LHS[i].x2, (int)__uint8.TestData_RHS[i].x2);
                    result &= test.x3 == math.rol(__uint8.TestData_LHS[i].x3, (int)__uint8.TestData_RHS[i].x3);
                    result &= test.x4 == math.rol(__uint8.TestData_LHS[i].x4, (int)__uint8.TestData_RHS[i].x4);
                    result &= test.x5 == math.rol(__uint8.TestData_LHS[i].x5, (int)__uint8.TestData_RHS[i].x5);
                    result &= test.x6 == math.rol(__uint8.TestData_LHS[i].x6, (int)__uint8.TestData_RHS[i].x6);
                    result &= test.x7 == math.rol(__uint8.TestData_LHS[i].x7, (int)__uint8.TestData_RHS[i].x7);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void rol_ulong4()
        {
            bool result = true;

            for (int i = 0; i < __ulong4.NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_ROTATION_TESTS; j++)
                {
                    ulong4 test = maxmath.rol(__ulong4.TestData_LHS[i], __ulong4.TestData_RHS[i]);

                    result &= test.x == math.rol(__ulong4.TestData_LHS[i].x, (int)__ulong4.TestData_RHS[i].x);
                    result &= test.y == math.rol(__ulong4.TestData_LHS[i].y, (int)__ulong4.TestData_RHS[i].y);
                    result &= test.z == math.rol(__ulong4.TestData_LHS[i].z, (int)__ulong4.TestData_RHS[i].z);
                    result &= test.w == math.rol(__ulong4.TestData_LHS[i].w, (int)__ulong4.TestData_RHS[i].w);
                }
            }

            Assert.AreEqual(true, result);
        }
    }
}
