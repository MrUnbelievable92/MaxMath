using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class __uint4
    {
        internal const int NUM_TESTS = 4;


        internal static uint4[] TestData_LHS => new uint4[]
        {
            new uint4(18550, 5577, 448, 688532),
            new uint4(4466, 14, 6499, 6558886),
            new uint4(4489, uint.MaxValue, 44, 19763),
            new uint4(uint.MinValue, 147, 1, 32)
        };

        internal static uint4[] TestData_RHS => new uint4[]
        {
            new uint4(78550, 55677, 12648, 248532),
            new uint4(12466, 354, 6499, 655086),
            new uint4(4929, uint.MaxValue, 404, 19763),
            new uint4(uint.MinValue, 1451, 111, 122)
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

            Assert.AreEqual(true, result);
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

            Assert.AreEqual(true, result);
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

            Assert.AreEqual(true, result);
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

            Assert.AreEqual(true, result);
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

            Assert.AreEqual(true, result);
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

            Assert.AreEqual(true, result);
        }
    }
}