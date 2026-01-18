using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_reverse
    {
        [Test]
        public static void _byte2()
        {
            byte2 test = default(byte2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (byte)i;
            }

            byte2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _byte3()
        {
            byte3 test = default(byte3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (byte)i;
            }

            byte3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _byte4()
        {
            byte4 test = default(byte4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (byte)i;
            }

            byte4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _byte8()
        {
            byte8 test = default(byte8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (byte)i;
            }

            byte8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _byte16()
        {
            byte16 test = default(byte16);

            for (int i = 0; i < 16; i++)
            {
                test[i] = (byte)i;
            }

            byte16 reversed = maxmath.reverse(test);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(reversed[i], test[16 - 1 - i]);
            }
        }

        [Test]
        public static void _byte32()
        {
            byte32 test = default(byte32);

            for (int i = 0; i < 32; i++)
            {
                test[i] = (byte)i;
            }

            byte32 reversed = maxmath.reverse(test);

            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(reversed[i], test[32 - 1 - i]);
            }
        }

        [Test]
        public static void _ushort2()
        {
            ushort2 test = default(ushort2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (ushort)i;
            }

            ushort2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _ushort3()
        {
            ushort3 test = default(ushort3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (ushort)i;
            }

            ushort3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _ushort4()
        {
            ushort4 test = default(ushort4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (ushort)i;
            }

            ushort4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _ushort8()
        {
            ushort8 test = default(ushort8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (ushort)i;
            }

            ushort8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _ushort16()
        {
            ushort16 test = default(ushort16);

            for (int i = 0; i < 16; i++)
            {
                test[i] = (ushort)i;
            }

            ushort16 reversed = maxmath.reverse(test);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(reversed[i], test[16 - 1 - i]);
            }
        }

        [Test]
        public static void _uint2()
        {
            uint2 test = default(uint2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (uint)i;
            }

            uint2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _uint3()
        {
            uint3 test = default(uint3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (uint)i;
            }

            uint3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _uint4()
        {
            uint4 test = default(uint4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (uint)i;
            }

            uint4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _uint8()
        {
            uint8 test = default(uint8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (uint)i;
            }

            uint8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _ulong2()
        {
            ulong2 test = default(ulong2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (ulong)i;
            }

            ulong2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _ulong3()
        {
            ulong3 test = default(ulong3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (ulong)i;
            }

            ulong3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _ulong4()
        {
            ulong4 test = default(ulong4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (ulong)i;
            }

            ulong4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }


        [Test]
        public static void _sbyte2()
        {
            sbyte2 test = default(sbyte2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (sbyte)i;
            }

            sbyte2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _sbyte3()
        {
            sbyte3 test = default(sbyte3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (sbyte)i;
            }

            sbyte3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _sbyte4()
        {
            sbyte4 test = default(sbyte4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (sbyte)i;
            }

            sbyte4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _sbyte8()
        {
            sbyte8 test = default(sbyte8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (sbyte)i;
            }

            sbyte8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _sbyte16()
        {
            sbyte16 test = default(sbyte16);

            for (int i = 0; i < 16; i++)
            {
                test[i] = (sbyte)i;
            }

            sbyte16 reversed = maxmath.reverse(test);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(reversed[i], test[16 - 1 - i]);
            }
        }

        [Test]
        public static void _sbyte32()
        {
            sbyte32 test = default(sbyte32);

            for (int i = 0; i < 32; i++)
            {
                test[i] = (sbyte)i;
            }

            sbyte32 reversed = maxmath.reverse(test);

            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(reversed[i], test[32 - 1 - i]);
            }
        }

        [Test]
        public static void _short2()
        {
            short2 test = default(short2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (short)i;
            }

            short2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _short3()
        {
            short3 test = default(short3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (short)i;
            }

            short3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _short4()
        {
            short4 test = default(short4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (short)i;
            }

            short4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _short8()
        {
            short8 test = default(short8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (short)i;
            }

            short8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _short16()
        {
            short16 test = default(short16);

            for (int i = 0; i < 16; i++)
            {
                test[i] = (short)i;
            }

            short16 reversed = maxmath.reverse(test);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(reversed[i], test[16 - 1 - i]);
            }
        }

        [Test]
        public static void _int2()
        {
            int2 test = default(int2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (int)i;
            }

            int2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _int3()
        {
            int3 test = default(int3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (int)i;
            }

            int3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _int4()
        {
            int4 test = default(int4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (int)i;
            }

            int4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _int8()
        {
            int8 test = default(int8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (int)i;
            }

            int8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _long2()
        {
            long2 test = default(long2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (long)i;
            }

            long2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _long3()
        {
            long3 test = default(long3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (long)i;
            }

            long3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _long4()
        {
            long4 test = default(long4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (long)i;
            }

            long4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }


        [Test]
        public static void _quarter2()
        {
            quarter2 test = default(quarter2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (quarter)i;
            }

            quarter2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _quarter3()
        {
            quarter3 test = default(quarter3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (quarter)i;
            }

            quarter3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _quarter4()
        {
            quarter4 test = default(quarter4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (quarter)i;
            }

            quarter4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _quarter8()
        {
            quarter8 test = default(quarter8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (quarter)i;
            }

            quarter8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _quarter16()
        {
            quarter16 test = default(quarter16);

            for (int i = 0; i < 16; i++)
            {
                test[i] = (quarter)i;
            }

            quarter16 reversed = maxmath.reverse(test);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(reversed[i], test[16 - 1 - i]);
            }
        }

        [Test]
        public static void _quarter32()
        {
            quarter32 test = default(quarter32);

            for (int i = 0; i < 32; i++)
            {
                test[i] = (quarter)i;
            }

            quarter32 reversed = maxmath.reverse(test);

            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(reversed[i], test[32 - 1 - i]);
            }
        }

        [Test]
        public static void _half2()
        {
            half2 test = default(half2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (half)i;
            }

            half2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _half3()
        {
            half3 test = default(half3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (half)i;
            }

            half3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _half4()
        {
            half4 test = default(half4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (half)i;
            }

            half4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _half8()
        {
            half8 test = default(half8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (half)i;
            }

            half8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _half16()
        {
            half16 test = default(half16);

            for (int i = 0; i < 16; i++)
            {
                test[i] = (half)i;
            }

            half16 reversed = maxmath.reverse(test);

            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual(reversed[i], test[16 - 1 - i]);
            }
        }

        [Test]
        public static void _float2()
        {
            float2 test = default(float2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (float)i;
            }

            float2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _float3()
        {
            float3 test = default(float3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (float)i;
            }

            float3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _float4()
        {
            float4 test = default(float4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (float)i;
            }

            float4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }

        [Test]
        public static void _float8()
        {
            float8 test = default(float8);

            for (int i = 0; i < 8; i++)
            {
                test[i] = (float)i;
            }

            float8 reversed = maxmath.reverse(test);

            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(reversed[i], test[8 - 1 - i]);
            }
        }

        [Test]
        public static void _double2()
        {
            double2 test = default(double2);

            for (int i = 0; i < 2; i++)
            {
                test[i] = (double)i;
            }

            double2 reversed = maxmath.reverse(test);

            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(reversed[i], test[2 - 1 - i]);
            }
        }

        [Test]
        public static void _double3()
        {
            double3 test = default(double3);

            for (int i = 0; i < 3; i++)
            {
                test[i] = (double)i;
            }

            double3 reversed = maxmath.reverse(test);

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(reversed[i], test[3 - 1 - i]);
            }
        }

        [Test]
        public static void _double4()
        {
            double4 test = default(double4);

            for (int i = 0; i < 4; i++)
            {
                test[i] = (double)i;
            }

            double4 reversed = maxmath.reverse(test);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(reversed[i], test[4 - 1 - i]);
            }
        }
    }
}
