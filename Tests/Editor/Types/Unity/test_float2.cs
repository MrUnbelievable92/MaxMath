using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class Float2
    {
        private const int NUM_TESTS = 4;


        internal static float2[] TestData_LHS => new float2[]
        {
            new float2(1855.043f, 5577.5f),
            new float2(-226.62f, 12f),
            new float2(44897f, float.MaxValue),
            new float2(float.MinValue, -137.43f)
        };

        internal static float2[] TestData_RHS => new float2[]
        {
            new float2(1850.44f, -448.84f),
            new float2(-0.14f, 6558886.5f),
            new float2(float.MaxValue, 442.4f),
            new float2(166, 31232.8654f)
        };


        [Test]
        public static void Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte2 x = (byte2)TestData_LHS[i];

                result &= x.x == (byte)TestData_LHS[i].x &
                          x.y == (byte)TestData_LHS[i].y;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 x = (sbyte2)TestData_LHS[i];

                result &= x.x == (sbyte)TestData_LHS[i].x &
                          x.y == (sbyte)TestData_LHS[i].y;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short2 x = (short2)TestData_LHS[i];

                result &= x.x == (short)TestData_LHS[i].x &
                          x.y == (short)TestData_LHS[i].y;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort2 x = (ushort2)TestData_LHS[i];

                result &= x.x == (ushort)TestData_LHS[i].x &
                          x.y == (ushort)TestData_LHS[i].y;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long2 x = (long2)TestData_LHS[i];

                result &= x.x == (long)TestData_LHS[i].x &
                          x.y == (long)TestData_LHS[i].y;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong2 x = (ulong2)TestData_LHS[i];

                result &= x.x == (ulong)TestData_LHS[i].x &
                          x.y == (ulong)TestData_LHS[i].y;
            }

            Assert.AreEqual(result, true);
        }
    }
}