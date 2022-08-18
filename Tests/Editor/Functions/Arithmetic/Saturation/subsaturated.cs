using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class SaturatedDifference
    {
        [Test]
        public static void byte2()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte2 left = rng.NextByte2();
                byte2 right = rng.NextByte2();
                byte2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(right[j] >= left[j] ? byte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void byte3()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte3 left = rng.NextByte3();
                byte3 right = rng.NextByte3();
                byte3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(right[j] >= left[j] ? byte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void byte4()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte4 left = rng.NextByte4();
                byte4 right = rng.NextByte4();
                byte4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(right[j] >= left[j] ? byte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void byte8()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte8 left = rng.NextByte8();
                byte8 right = rng.NextByte8();
                byte8 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(right[j] >= left[j] ? byte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void byte16()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte16 left = rng.NextByte16();
                byte16 right = rng.NextByte16();
                byte16 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(right[j] >= left[j] ? byte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void byte32()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte32 left = rng.NextByte32();
                byte32 right = rng.NextByte32();
                byte32 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 32; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(right[j] >= left[j] ? byte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }


        [Test]
        public static void ushort2()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort2 left = rng.NextUShort2();
                ushort2 right = rng.NextUShort2();
                ushort2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    uint sumNormal = (uint)left[j] - (uint)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ushort.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void ushort3()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort3 left = rng.NextUShort3();
                ushort3 right = rng.NextUShort3();
                ushort3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    uint sumNormal = (uint)left[j] - (uint)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ushort.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void ushort4()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort4 left = rng.NextUShort4();
                ushort4 right = rng.NextUShort4();
                ushort4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    uint sumNormal = (uint)left[j] - (uint)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ushort.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void ushort8()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort8 left = rng.NextUShort8();
                ushort8 right = rng.NextUShort8();
                ushort8 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    uint sumNormal = (uint)left[j] - (uint)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ushort.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void ushort16()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort16 left = rng.NextUShort16();
                ushort16 right = rng.NextUShort16();
                ushort16 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    uint sumNormal = (uint)left[j] - (uint)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ushort.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }


        [Test]
        public static void uint2()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint2 left = rng.NextUInt2();
                uint2 right = rng.NextUInt2();
                uint2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    ulong sumNormal = (ulong)left[j] - (ulong)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? uint.MinValue : sumNormal, (ulong)sum[j]);
                }
            }
        }

        [Test]
        public static void uint3()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint3 left = rng.NextUInt3();
                uint3 right = rng.NextUInt3();
                uint3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    ulong sumNormal = (ulong)left[j] - (ulong)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? uint.MinValue : sumNormal, (ulong)sum[j]);
                }
            }
        }

        [Test]
        public static void uint4()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint4 left = rng.NextUInt4();
                uint4 right = rng.NextUInt4();
                uint4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    ulong sumNormal = (ulong)left[j] - (ulong)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? uint.MinValue : sumNormal, (ulong)sum[j]);
                }
            }
        }

        [Test]
        public static void uint8()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint8 left = rng.NextUInt8();
                uint8 right = rng.NextUInt8();
                uint8 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    ulong sumNormal = (ulong)left[j] - (ulong)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? uint.MinValue : sumNormal, (ulong)sum[j]);
                }
            }
        }


        [Test]
        public static void ulong2()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                ulong2 left = rng.NextULong2();
                ulong2 right = rng.NextULong2();
                ulong2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    BigInteger sumNormal = (BigInteger)left[j] - (BigInteger)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ulong.MinValue : sumNormal, (BigInteger)sum[j]);
                }
            }
        }

        [Test]
        public static void ulong3()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                ulong3 left = rng.NextULong3();
                ulong3 right = rng.NextULong3();
                ulong3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    BigInteger sumNormal = (BigInteger)left[j] - (BigInteger)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ulong.MinValue : sumNormal, (BigInteger)sum[j]);
                }
            }
        }

        [Test]
        public static void ulong4()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                ulong4 left = rng.NextULong4();
                ulong4 right = rng.NextULong4();
                ulong4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    BigInteger sumNormal = (BigInteger)left[j] - (BigInteger)right[j];
                    Assert.AreEqual(right[j] >= left[j] ? ulong.MinValue : sumNormal, (BigInteger)sum[j]);
                }
            }
        }


        [Test]
        public static void uint128()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random128 rng = new Random128(seed);

            for (int i = 0; i < 100; i++)
            {
                UInt128 left = rng.NextUInt128();
                UInt128 right = rng.NextUInt128();
                UInt128 sum = maxmath.subsaturated(left, right);
                
                BigInteger sumNormal = (BigInteger)left - (BigInteger)right;
                Assert.AreEqual(right >= left ? UInt128.MinValue : sumNormal, (BigInteger)sum);
            }
        }


        [Test]
        public static void sbyte2()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte2 left = rng.NextSByte2();
                sbyte2 right = rng.NextSByte2();
                sbyte2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(sumNormal > sbyte.MaxValue ? sbyte.MaxValue : sumNormal < sbyte.MinValue ? sbyte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void sbyte3()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte3 left = rng.NextSByte3();
                sbyte3 right = rng.NextSByte3();
                sbyte3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(sumNormal > sbyte.MaxValue ? sbyte.MaxValue : sumNormal < sbyte.MinValue ? sbyte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void sbyte4()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte4 left = rng.NextSByte4();
                sbyte4 right = rng.NextSByte4();
                sbyte4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(sumNormal > sbyte.MaxValue ? sbyte.MaxValue : sumNormal < sbyte.MinValue ? sbyte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void sbyte8()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte8 left = rng.NextSByte8();
                sbyte8 right = rng.NextSByte8();
                sbyte8 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(sumNormal > sbyte.MaxValue ? sbyte.MaxValue : sumNormal < sbyte.MinValue ? sbyte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void sbyte16()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte16 left = rng.NextSByte16();
                sbyte16 right = rng.NextSByte16();
                sbyte16 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(sumNormal > sbyte.MaxValue ? sbyte.MaxValue : sumNormal < sbyte.MinValue ? sbyte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void sbyte32()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte32 left = rng.NextSByte32();
                sbyte32 right = rng.NextSByte32();
                sbyte32 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 32; j++)
                {
                    int sumNormal = left[j] - right[j];
                    Assert.AreEqual(sumNormal > sbyte.MaxValue ? sbyte.MaxValue : sumNormal < sbyte.MinValue ? sbyte.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }


        [Test]
        public static void short2()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                short2 left = rng.NextShort2();
                short2 right = rng.NextShort2();
                short2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    int sumNormal = (int)left[j] - (int)right[j];
                    Assert.AreEqual(sumNormal > short.MaxValue ? short.MaxValue : sumNormal < short.MinValue ? short.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void short3()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                short3 left = rng.NextShort3();
                short3 right = rng.NextShort3();
                short3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    int sumNormal = (int)left[j] - (int)right[j];
                    Assert.AreEqual(sumNormal > short.MaxValue ? short.MaxValue : sumNormal < short.MinValue ? short.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void short4()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                short4 left = rng.NextShort4();
                short4 right = rng.NextShort4();
                short4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    int sumNormal = (int)left[j] - (int)right[j];
                    Assert.AreEqual(sumNormal > short.MaxValue ? short.MaxValue : sumNormal < short.MinValue ? short.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void short8()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                short8 left = rng.NextShort8();
                short8 right = rng.NextShort8();
                short8 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    int sumNormal = (int)left[j] - (int)right[j];
                    Assert.AreEqual(sumNormal > short.MaxValue ? short.MaxValue : sumNormal < short.MinValue ? short.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }

        [Test]
        public static void short16()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                short16 left = rng.NextShort16();
                short16 right = rng.NextShort16();
                short16 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    int sumNormal = (int)left[j] - (int)right[j];
                    Assert.AreEqual(sumNormal > short.MaxValue ? short.MaxValue : sumNormal < short.MinValue ? short.MinValue : sumNormal, (int)sum[j]);
                }
            }
        }


        [Test]
        public static void int2()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int2 left = rng.NextInt2();
                int2 right = rng.NextInt2();
                int2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    long sumNormal = (long)left[j] - (long)right[j];
                    Assert.AreEqual(sumNormal > int.MaxValue ? int.MaxValue : sumNormal < int.MinValue ? int.MinValue : sumNormal, (long)sum[j]);
                }
            }
        }

        [Test]
        public static void int3()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int3 left = rng.NextInt3();
                int3 right = rng.NextInt3();
                int3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    long sumNormal = (long)left[j] - (long)right[j];
                    Assert.AreEqual(sumNormal > int.MaxValue ? int.MaxValue : sumNormal < int.MinValue ? int.MinValue : sumNormal, (long)sum[j]);
                }
            }
        }

        [Test]
        public static void int4()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int4 left = rng.NextInt4();
                int4 right = rng.NextInt4();
                int4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    long sumNormal = (long)left[j] - (long)right[j];
                    Assert.AreEqual(sumNormal > int.MaxValue ? int.MaxValue : sumNormal < int.MinValue ? int.MinValue : sumNormal, (long)sum[j]);
                }
            }
        }

        [Test]
        public static void int8()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int8 left = rng.NextInt8();
                int8 right = rng.NextInt8();
                int8 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    long sumNormal = (long)left[j] - (long)right[j];
                    Assert.AreEqual(sumNormal > int.MaxValue ? int.MaxValue : sumNormal < int.MinValue ? int.MinValue : sumNormal, (long)sum[j]);
                }
            }
        }


        [Test]
        public static void long2()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                long2 left = rng.NextLong2();
                long2 right = rng.NextLong2();
                long2 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    BigInteger sumNormal = (BigInteger)left[j] - (BigInteger)right[j];
                    Assert.AreEqual(sumNormal > long.MaxValue ? long.MaxValue : sumNormal < long.MinValue ? long.MinValue : sumNormal, (BigInteger)sum[j]);
                }
            }
        }

        [Test]
        public static void long3()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                long3 left = rng.NextLong3();
                long3 right = rng.NextLong3();
                long3 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    BigInteger sumNormal = (BigInteger)left[j] - (BigInteger)right[j];
                    Assert.AreEqual(sumNormal > long.MaxValue ? long.MaxValue : sumNormal < long.MinValue ? long.MinValue : sumNormal, (BigInteger)sum[j]);
                }
            }
        }

        [Test]
        public static void long4()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                long4 left = rng.NextLong4();
                long4 right = rng.NextLong4();
                long4 sum = maxmath.subsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    BigInteger sumNormal = (BigInteger)left[j] - (BigInteger)right[j];
                    Assert.AreEqual(sumNormal > long.MaxValue ? long.MaxValue : sumNormal < long.MinValue ? long.MinValue : sumNormal, (BigInteger)sum[j]);
                }
            }
        }

        
        [Test]
        public static void int128()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random128 rng = new Random128(seed);

            for (int i = 0; i < 100; i++)
            {
                Int128 left = rng.NextInt128();
                Int128 right = rng.NextInt128();
                Int128 sum = maxmath.subsaturated(left, right);
                
                BigInteger sumNormal = (BigInteger)left - (BigInteger)right;
                Assert.AreEqual(sumNormal > Int128.MaxValue ? Int128.MaxValue : sumNormal < Int128.MinValue ? Int128.MinValue : sumNormal, (BigInteger)sum);
            }
        }
    }
}