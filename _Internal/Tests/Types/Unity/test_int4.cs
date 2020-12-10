using DevTools;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class Int4
    {
        internal const int NUM_TESTS = 4;


        internal static int4[] TestData => new int4[]
        {
            new int4(18550, -5577, -448, 688532),
            new int4(4466, 14, 6499, -6558886),
            new int4(-4489, int.MaxValue, 44, 19763),
            new int4(int.MinValue, 147, -1, -32)
        };


        [UnitTest("Types", "int4")]
        public static bool Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte4 x = (byte4)TestData[i];

                result &= x.x == (byte)TestData[i].x &
                          x.y == (byte)TestData[i].y &
                          x.z == (byte)TestData[i].z &
                          x.w == (byte)TestData[i].w;
            }

            return result;
        }

        [UnitTest("Types", "int4")]
        public static bool Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = (sbyte4)TestData[i];

                result &= x.x == (sbyte)TestData[i].x &
                          x.y == (sbyte)TestData[i].y &
                          x.z == (sbyte)TestData[i].z &
                          x.w == (sbyte)TestData[i].w;
            }

            return result;
        }

        [UnitTest("Types", "int4")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short4 x = (short4)TestData[i];

                result &= x.x == (short)TestData[i].x &
                          x.y == (short)TestData[i].y &
                          x.z == (short)TestData[i].z &
                          x.w == (short)TestData[i].w;
            }

            return result;
        }

        [UnitTest("Types", "int4")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort4 x = (ushort4)TestData[i];

                result &= x.x == (ushort)TestData[i].x &
                          x.y == (ushort)TestData[i].y &
                          x.z == (ushort)TestData[i].z &
                          x.w == (ushort)TestData[i].w;
            }

            return result;
        }

        [UnitTest("Types", "int4")]
        public static bool Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long4 x = (long4)TestData[i];

                result &= x.x == (long)TestData[i].x &
                          x.y == (long)TestData[i].y &
                          x.z == (long)TestData[i].z &
                          x.w == (long)TestData[i].w;
            }

            return result;
        }

        [UnitTest("Types", "int4")]
        public static bool Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong4 x = (ulong4)TestData[i];

                result &= x.x == (ulong)TestData[i].x &
                          x.y == (ulong)TestData[i].y &
                          x.z == (ulong)TestData[i].z &
                          x.w == (ulong)TestData[i].w;
            }

            return result;
        }
    }
}