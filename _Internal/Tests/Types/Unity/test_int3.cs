using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class Int3
    {
        internal const int NUM_TESTS = 4;


        internal static int3[] TestData => new int3[]
        {
            new int3(1855043, -55775, 43884),
            new int3(-33663, 13, 6399),
            new int3(44897, int.MaxValue, -333),
            new int3(int.MinValue, -13743, -1)
        };


        [UnitTest("Types", "int3")]
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

        [UnitTest("Types", "int3")]
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

        [UnitTest("Types", "int3")]
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

        [UnitTest("Types", "int3")]
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

        [UnitTest("Types", "int3")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long3 x = TestData[i];

                result &= x.x == (long)TestData[i].x &
                          x.y == (long)TestData[i].y &
                          x.z == (long)TestData[i].z;
            }

            return result;
        }

        [UnitTest("Types", "int3")]
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