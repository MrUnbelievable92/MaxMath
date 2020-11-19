using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class Double2
    {
        internal static double NUM_TESTS = 4;


        internal static double2[] TestData => new double2[]
        {
            new double2(18558863.043d, 55736767.5d),
            new double2(-2222256.62d, 1686422d),
            new double2(44568.897d, double.MaxValue),
            new double2(double.MinValue, -145667.43d)
        };


        [UnitTest("Types", "double2")]
        public static bool Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte2 x = (byte2)TestData[i];

                result &= x.x == (byte)TestData[i].x &
                          x.y == (byte)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "double2")]
        public static bool Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 x = (sbyte2)TestData[i];

                result &= x.x == (sbyte)TestData[i].x &
                          x.y == (sbyte)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "double2")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short2 x = (short2)TestData[i];

                result &= x.x == (short)TestData[i].x &
                          x.y == (short)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "double2")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort2 x = (ushort2)TestData[i];

                result &= x.x == (ushort)TestData[i].x &
                          x.y == (ushort)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "double2")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long2 x = (long2)TestData[i];

                result &= x.x == (long)TestData[i].x &
                          x.y == (long)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "double2")]
        public static bool Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong2 x = (ulong2)TestData[i];

                result &= x.x == (ulong)TestData[i].x &
                          x.y == (ulong)TestData[i].y;
            }

            return result;
        }
    }
#endif
}