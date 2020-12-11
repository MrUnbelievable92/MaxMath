using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class Int2
    {
        internal const int NUM_TESTS = 4;


        internal static int2[] TestData_LHS => new int2[]
        {
            new int2(1855043, 55775),
            new int2(-22662, 12),
            new int2(44897, int.MaxValue),
            new int2(int.MinValue, -13743)
        };

        internal static int2[] TestData_RHS => new int2[]
        {
            new int2(-557347, 1448),
            new int2(1004, 8886),
            new int2(1544, 1900763),
            new int2(1147, -5532)
        };


        [UnitTest("Types", "int2")]
        public static bool Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte2 x = (byte2)TestData_LHS[i];

                result &= x.x == (byte)TestData_LHS[i].x &
                          x.y == (byte)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "int2")]
        public static bool Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 x = (sbyte2)TestData_LHS[i];

                result &= x.x == (sbyte)TestData_LHS[i].x &
                          x.y == (sbyte)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "int2")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short2 x = (short2)TestData_LHS[i];

                result &= x.x == (short)TestData_LHS[i].x &
                          x.y == (short)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "int2")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort2 x = (ushort2)TestData_LHS[i];

                result &= x.x == (ushort)TestData_LHS[i].x &
                          x.y == (ushort)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "int2")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long2 x = TestData_LHS[i];

                result &= x.x == (long)TestData_LHS[i].x &
                          x.y == (long)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "int2")]
        public static bool Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong2 x = (ulong2)TestData_LHS[i];

                result &= x.x == (ulong)TestData_LHS[i].x &
                          x.y == (ulong)TestData_LHS[i].y;
            }

            return result;
        }
    }
}