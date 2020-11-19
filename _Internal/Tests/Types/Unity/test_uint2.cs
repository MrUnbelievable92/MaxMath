using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class UInt2
    {
        internal const int NUM_TESTS = 4;


        internal static uint2[] TestData => new uint2[]
        {
            new uint2(1855043, 55775),
            new uint2(22662, 12),
            new uint2(44897, uint.MaxValue),
            new uint2(uint.MinValue, 13743)
        };


        [UnitTest("Types", "uint2")]
        public static bool Cast_ToByte()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                byte2 x = (byte2)TestData[i];

                result &= x.x == (byte)TestData[i].x &
                          x.y == (byte)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToSByte()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 x = (sbyte2)TestData[i];

                result &= x.x == (sbyte)TestData[i].x &
                          x.y == (sbyte)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                short2 x = (short2)TestData[i];

                result &= x.x == (short)TestData[i].x &
                          x.y == (short)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                ushort2 x = (ushort2)TestData[i];

                result &= x.x == (ushort)TestData[i].x &
                          x.y == (ushort)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
            {
                long2 x = TestData[i];

                result &= x.x == (long)TestData[i].x &
                          x.y == (long)TestData[i].y;
            }

            return result;
        }

        [UnitTest("Types", "uint2")]
        public static bool Cast_ToULong()
        {
            bool result = true;

            for (uint i = 0; i < NUM_TESTS; i++)
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