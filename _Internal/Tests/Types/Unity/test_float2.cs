using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class Float2
    {
        private static float NUM_TESTS = 4;


        internal static float2[] TestData => new float2[]
        {
            new float2(1855.043f, 5577.5f),
            new float2(-226.62f, 12f),
            new float2(44897f, float.MaxValue),
            new float2(float.MinValue, -137.43f)
        };


        [UnitTest("Types", "float2")]
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

        [UnitTest("Types", "float2")]
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

        [UnitTest("Types", "float2")]
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

        [UnitTest("Types", "float2")]
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

        [UnitTest("Types", "float2")]
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

        [UnitTest("Types", "float2")]
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