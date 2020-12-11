using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class UInt2
    {
        internal const int NUM_TESTS = 4;


        internal static uint2[] TestData_LHS => new uint2[]
        {
            new uint2(1855043, 55775),
            new uint2(22662, 12),
            new uint2(44897, uint.MaxValue),
            new uint2(uint.MinValue, 13743)
        };

        internal static uint2[] TestData_RHS => new uint2[]
        {
            new uint2(12648, 248532),
            new uint2(354, 6499),
            new uint2(uint.MaxValue, 19763),
            new uint2(1451, 111)
        };


        [UnitTest("Types", "uint2")]
        public static bool Cast_ToByte()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                byte2 x = (byte2)TestData_LHS[i];

                result &= x.x == (byte)TestData_LHS[i].x &
                          x.y == (byte)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToSByte()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 x = (sbyte2)TestData_LHS[i];

                result &= x.x == (sbyte)TestData_LHS[i].x &
                          x.y == (sbyte)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                short2 x = (short2)TestData_LHS[i];

                result &= x.x == (short)TestData_LHS[i].x &
                          x.y == (short)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                ushort2 x = (ushort2)TestData_LHS[i];

                result &= x.x == (ushort)TestData_LHS[i].x &
                          x.y == (ushort)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                long2 x = TestData_LHS[i];

                result &= x.x == (long)TestData_LHS[i].x &
                          x.y == (long)TestData_LHS[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToULong()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                ulong2 x = (ulong2)TestData_LHS[i];

                result &= x.x == (ulong)TestData_LHS[i].x &
                          x.y == (ulong)TestData_LHS[i].y;
            }

            return result;
        }
    }
}