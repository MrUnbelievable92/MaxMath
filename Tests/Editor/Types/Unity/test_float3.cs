using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class Float3
    {
        internal const int NUM_TESTS = 4;


        internal static float3[] TestData_LHS => new float3[]
        {
            new float3(18550.43f, 5577.5f, 438.84f),
            new float3(3366.3f, 13, 6399),
            new float3(4489.7f, float.MaxValue, 33.3f),
            new float3(float.MinValue, 137.43f, 1)
        };

        internal static float3[] TestData_RHS => new float3[]
        {
            new float3(1850.44f, -448.84f, 67532.15f),
            new float3(-0.14f, 6499.1351f, 6558886.5f),
            new float3(589.7f, float.MaxValue, 442.4f),
            new float3(14721.44f, 166, 31232.8654f)
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