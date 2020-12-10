using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class Double3
    {
        internal const int NUM_TESTS = 4;


        internal static double3[] TestData => new double3[]
        {
            new double3(18550.43f, 5577.5f, 438.84f),
            new double3(3366.3f, 13, 6399),
            new double3(4489.7f, double.MaxValue, 33.3f),
            new double3(double.MinValue, 137.43f, 1)
        };


        [UnitTest("Types", "double3")]
        public static bool Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 x = (byte3)TestData[i];

                result &= x.x == (byte)TestData[i].x &
                          x.y == (byte)TestData[i].y &
                          x.z == (byte)TestData[i].z;
            }

            return result;
        }

        [UnitTest("Types", "double3")]
        public static bool Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte3 x = (sbyte3)TestData[i];

                result &= x.x == (sbyte)TestData[i].x &
                          x.y == (sbyte)TestData[i].y &
                          x.z == (sbyte)TestData[i].z;
            }

            return result;
        }

        [UnitTest("Types", "double3")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short3 x = (short3)TestData[i];

                result &= x.x == (short)TestData[i].x &
                          x.y == (short)TestData[i].y &
                          x.z == (short)TestData[i].z;
            }

            return result;
        }

        [UnitTest("Types", "double3")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort3 x = (ushort3)TestData[i];

                result &= x.x == (ushort)TestData[i].x &
                          x.y == (ushort)TestData[i].y &
                          x.z == (ushort)TestData[i].z;
            }

            return result;
        }

        [UnitTest("Types", "double3")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long3 x = (long3)TestData[i];

                result &= x.x == (long)TestData[i].x &
                          x.y == (long)TestData[i].y &
                          x.z == (long)TestData[i].z;
            }

            return result;
        }

        [UnitTest("Types", "double3")]
        public static bool Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong3 x = (ulong3)TestData[i];

                result &= x.x == (ulong)TestData[i].x &
                          x.y == (ulong)TestData[i].y &
                          x.z == (ulong)TestData[i].z;
            }

            return result;
        }
    }
}