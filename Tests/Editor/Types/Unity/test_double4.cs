using NUnit.Framework;
using Unity.Mathematics;
namespace MaxMath.Tests
{
    unsafe public static class Double4
    {
        internal const int NUM_TESTS = 4;


        internal static double4[] TestData_LHS => new double4[]
        {
            new double4(18550.44f, 5577.5f, 448.84f, 688532.15f),
            new double4(4466.4f, 14, 6499, 6558886.5f),
            new double4(4489.7f, double.MaxValue, 44.4f, 19763f),
            new double4(double.MinValue, 147.44f, 1, 32.8654f)
        };

        internal static double4[] TestData_RHS => new double4[]
        {
            new double4(18.44f, 5577.5f, -18.84f, -158532.15f),
            new double4(446.4f, 1.1413414, 6264.99, -258886.5f),
            new double4(449.7f, double.MaxValue, 44.4f, 10.61234413f),
            new double4(double.MinValue, 147.44f, 1, 3234337.654f)
        };


        [Test]
        public static void Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte4 x = (byte4)TestData_LHS[i];

                result &= x.x == (byte)TestData_LHS[i].x &
                          x.y == (byte)TestData_LHS[i].y &
                          x.z == (byte)TestData_LHS[i].z &
                          x.w == (byte)TestData_LHS[i].w;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 x = (sbyte4)TestData_LHS[i];

                result &= x.x == (sbyte)TestData_LHS[i].x &
                          x.y == (sbyte)TestData_LHS[i].y &
                          x.z == (sbyte)TestData_LHS[i].z &
                          x.w == (sbyte)TestData_LHS[i].w;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short4 x = (short4)TestData_LHS[i];

                result &= x.x == (short)TestData_LHS[i].x &
                          x.y == (short)TestData_LHS[i].y &
                          x.z == (short)TestData_LHS[i].z &
                          x.w == (short)TestData_LHS[i].w;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort4 x = (ushort4)TestData_LHS[i];

                result &= x.x == (ushort)TestData_LHS[i].x &
                          x.y == (ushort)TestData_LHS[i].y &
                          x.z == (ushort)TestData_LHS[i].z &
                          x.w == (ushort)TestData_LHS[i].w;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToLong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                long4 x = (long4)TestData_LHS[i];

                result &= x.x == (long)TestData_LHS[i].x &
                          x.y == (long)TestData_LHS[i].y &
                          x.z == (long)TestData_LHS[i].z &
                          x.w == (long)TestData_LHS[i].w;
            }

            Assert.AreEqual(result, true);
        }

        [Test]
        public static void Cast_ToULong()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ulong4 x = (ulong4)TestData_LHS[i];

                result &= x.x == (ulong)TestData_LHS[i].x &
                          x.y == (ulong)TestData_LHS[i].y &
                          x.z == (ulong)TestData_LHS[i].z &
                          x.w == (ulong)TestData_LHS[i].w;
            }

            Assert.AreEqual(result, true);
        }
    }
}