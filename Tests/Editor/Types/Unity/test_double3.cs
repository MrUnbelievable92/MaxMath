using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class Double3
    {
        internal const int NUM_TESTS = 4;


        internal static double3[] TestData_LHS => new double3[]
        {
            new double3(18550.43f, 5577.5f, 438.84f),
            new double3(3366.3f, 13, 6399),
            new double3(4489.7f, double.MaxValue, 33.3f),
            new double3(double.MinValue, 137.43f, 1)
        };

        internal static double3[] TestData_RHS => new double3[]
        {
            new double3(18.44f, 5577.5f, -158532.15f),
            new double3(446.4f, 6264.99, -258886.5f),
            new double3(449.7f, double.MaxValue, 10.61234413f),
            new double3( 147.44f, 1, 3234337.654f)
        };


        [Test]
        public static void Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = (byte3)TestData_LHS[i];

                result &= x.x == (byte)TestData_LHS[i].x &
                          x.y == (byte)TestData_LHS[i].y &
                          x.z == (byte)TestData_LHS[i].z;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte3 x = (sbyte3)TestData_LHS[i];

                result &= x.x == (sbyte)TestData_LHS[i].x &
                          x.y == (sbyte)TestData_LHS[i].y &
                          x.z == (sbyte)TestData_LHS[i].z;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short3 x = (short3)TestData_LHS[i];

                result &= x.x == (short)TestData_LHS[i].x &
                          x.y == (short)TestData_LHS[i].y &
                          x.z == (short)TestData_LHS[i].z;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort3 x = (ushort3)TestData_LHS[i];

                result &= x.x == (ushort)TestData_LHS[i].x &
                          x.y == (ushort)TestData_LHS[i].y &
                          x.z == (ushort)TestData_LHS[i].z;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long3 x = (long3)TestData_LHS[i];

                result &= x.x == (long)TestData_LHS[i].x &
                          x.y == (long)TestData_LHS[i].y &
                          x.z == (long)TestData_LHS[i].z;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong3 x = (ulong3)TestData_LHS[i];

                result &= x.x == (ulong)TestData_LHS[i].x &
                          x.y == (ulong)TestData_LHS[i].y &
                          x.z == (ulong)TestData_LHS[i].z;
            }

            Assert.AreEqual(result, true);
        }
    }
}