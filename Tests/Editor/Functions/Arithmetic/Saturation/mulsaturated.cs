using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_mulsaturated
    {
        [Test]
        public static void _byte2()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte2 left = rng.NextByte2();
                byte2 right = rng.NextByte2();
                byte2 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > byte.MaxValue ? byte.MaxValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte3 left = rng.NextByte3();
                byte3 right = rng.NextByte3();
                byte3 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > byte.MaxValue ? byte.MaxValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte4 left = rng.NextByte4();
                byte4 right = rng.NextByte4();
                byte4 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > byte.MaxValue ? byte.MaxValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte8 left = rng.NextByte8();
                byte8 right = rng.NextByte8();
                byte8 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > byte.MaxValue ? byte.MaxValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte16 left = rng.NextByte16();
                byte16 right = rng.NextByte16();
                byte16 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > byte.MaxValue ? byte.MaxValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte32 left = rng.NextByte32();
                byte32 right = rng.NextByte32();
                byte32 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 32; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > byte.MaxValue ? byte.MaxValue : productNormal, (int)product[j]);
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort2 left = rng.NextUShort2();
                ushort2 right = rng.NextUShort2();
                ushort2 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    uint productNormal = (uint)left[j] * (uint)right[j];
                    Assert.AreEqual(productNormal > ushort.MaxValue ? ushort.MaxValue : productNormal, (uint)product[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort3 left = rng.NextUShort3();
                ushort3 right = rng.NextUShort3();
                ushort3 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    uint productNormal = (uint)left[j] * (uint)right[j];
                    Assert.AreEqual(productNormal > ushort.MaxValue ? ushort.MaxValue : productNormal, (uint)product[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort4 left = rng.NextUShort4();
                ushort4 right = rng.NextUShort4();
                ushort4 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    uint productNormal = (uint)left[j] * (uint)right[j];
                    Assert.AreEqual(productNormal > ushort.MaxValue ? ushort.MaxValue : productNormal, (uint)product[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort8 left = rng.NextUShort8();
                ushort8 right = rng.NextUShort8();
                ushort8 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    uint productNormal = (uint)left[j] * (uint)right[j];
                    Assert.AreEqual(productNormal > ushort.MaxValue ? ushort.MaxValue : productNormal, (uint)product[j]);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            for (int i = 0; i < 100; i++)
            {
                ushort16 left = rng.NextUShort16();
                ushort16 right = rng.NextUShort16();
                ushort16 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    uint productNormal = (uint)left[j] * (uint)right[j];
                    Assert.AreEqual(productNormal > ushort.MaxValue ? ushort.MaxValue : productNormal, (uint)product[j]);
                }
            }
        }


        [Test]
        public static void _uint2()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint2 left = rng.NextUInt2();
                uint2 right = rng.NextUInt2();
                uint2 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    ulong productNormal = (ulong)left[j] * (ulong)right[j];
                    Assert.AreEqual(productNormal > uint.MaxValue ? uint.MaxValue : productNormal, (ulong)product[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint3 left = rng.NextUInt3();
                uint3 right = rng.NextUInt3();
                uint3 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    ulong productNormal = (ulong)left[j] * (ulong)right[j];
                    Assert.AreEqual(productNormal > uint.MaxValue ? uint.MaxValue : productNormal, (ulong)product[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint4 left = rng.NextUInt4();
                uint4 right = rng.NextUInt4();
                uint4 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    ulong productNormal = (ulong)left[j] * (ulong)right[j];
                    Assert.AreEqual(productNormal > uint.MaxValue ? uint.MaxValue : productNormal, (ulong)product[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                uint8 left = rng.NextUInt8();
                uint8 right = rng.NextUInt8();
                uint8 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    ulong productNormal = (ulong)left[j] * (ulong)right[j];
                    Assert.AreEqual(productNormal > uint.MaxValue ? uint.MaxValue : productNormal, (ulong)product[j]);
                }
            }
        }


        [Test]
        public static void _ulong2()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                ulong2 left = rng.NextULong2();
                ulong2 right = rng.NextULong2();
                ulong2 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    BigInteger productNormal = (BigInteger)left[j] * (BigInteger)right[j];
                    Assert.AreEqual(productNormal > ulong.MaxValue ? ulong.MaxValue : productNormal, (BigInteger)product[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                ulong3 left = rng.NextULong3();
                ulong3 right = rng.NextULong3();
                ulong3 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    BigInteger productNormal = (BigInteger)left[j] * (BigInteger)right[j];
                    Assert.AreEqual(productNormal > ulong.MaxValue ? ulong.MaxValue : productNormal, (BigInteger)product[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                ulong4 left = rng.NextULong4();
                ulong4 right = rng.NextULong4();
                ulong4 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    BigInteger productNormal = (BigInteger)left[j] * (BigInteger)right[j];
                    Assert.AreEqual(productNormal > ulong.MaxValue ? ulong.MaxValue : productNormal, (BigInteger)product[j]);
                }
            }
        }


        [Test]
        public static void _sbyte2()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte2 left = rng.NextSByte2();
                sbyte2 right = rng.NextSByte2();
                sbyte2 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > sbyte.MaxValue ? sbyte.MaxValue : productNormal < sbyte.MinValue ? sbyte.MinValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte3 left = rng.NextSByte3();
                sbyte3 right = rng.NextSByte3();
                sbyte3 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > sbyte.MaxValue ? sbyte.MaxValue : productNormal < sbyte.MinValue ? sbyte.MinValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte4 left = rng.NextSByte4();
                sbyte4 right = rng.NextSByte4();
                sbyte4 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > sbyte.MaxValue ? sbyte.MaxValue : productNormal < sbyte.MinValue ? sbyte.MinValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte8 left = rng.NextSByte8();
                sbyte8 right = rng.NextSByte8();
                sbyte8 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > sbyte.MaxValue ? sbyte.MaxValue : productNormal < sbyte.MinValue ? sbyte.MinValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte16 left = rng.NextSByte16();
                sbyte16 right = rng.NextSByte16();
                sbyte16 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > sbyte.MaxValue ? sbyte.MaxValue : productNormal < sbyte.MinValue ? sbyte.MinValue : productNormal, (int)product[j]);
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                sbyte32 left = rng.NextSByte32();
                sbyte32 right = rng.NextSByte32();
                sbyte32 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 32; j++)
                {
                    int productNormal = left[j] * right[j];
                    Assert.AreEqual(productNormal > sbyte.MaxValue ? sbyte.MaxValue : productNormal < sbyte.MinValue ? sbyte.MinValue : productNormal, (int)product[j]);
                }
            }
        }


        [Test]
        public static void _short2()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);
            short2 product;
            short2 left;
            short2 right;

            for (int i = 0; i < 100; i++)
            {
                left = rng.NextShort2();
                right = rng.NextShort2();
                product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    int productNormal = (int)left[j] * (int)right[j];
                    Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
                }
            }

            left = rng.NextShort2();
            product = maxmath.mulsaturated(left, 2);

            for (int j = 0; j < 2; j++)
            {
                int productNormal = (int)left[j] * 2;
                Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
            }
        }

        [Test]
        public static void _short3()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);
            short3 product;
            short3 left;
            short3 right;

            for (int i = 0; i < 100; i++)
            {
                left = rng.NextShort3();
                right = rng.NextShort3();
                product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    int productNormal = (int)left[j] * (int)right[j];
                    Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
                }
            }

            left = rng.NextShort3();
            product = maxmath.mulsaturated(left, 2);

            for (int j = 0; j < 3; j++)
            {
                int productNormal = (int)left[j] * 2;
                Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
            }
        }

        [Test]
        public static void _short4()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);
            short4 product;
            short4 left;
            short4 right;

            for (int i = 0; i < 100; i++)
            {
                left = rng.NextShort4();
                right = rng.NextShort4();
                product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    int productNormal = (int)left[j] * (int)right[j];
                    Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
                }
            }

            left = rng.NextShort4();
            product = maxmath.mulsaturated(left, 2);

            for (int j = 0; j < 4; j++)
            {
                int productNormal = (int)left[j] * 2;
                Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
            }
        }

        [Test]
        public static void _short8()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);
            short8 product;
            short8 left;
            short8 right;

            for (int i = 0; i < 100; i++)
            {
                left = rng.NextShort8();
                right = rng.NextShort8();
                product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    int productNormal = (int)left[j] * (int)right[j];
                    Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
                }
            }

            left = rng.NextShort8();
            product = maxmath.mulsaturated(left, 2);

            for (int j = 0; j < 8; j++)
            {
                int productNormal = (int)left[j] * 2;
                Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
            }
        }

        [Test]
        public static void _short16()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);
            short16 product;
            short16 left;
            short16 right;

            for (int i = 0; i < 100; i++)
            {
                left = rng.NextShort16();
                right = rng.NextShort16();
                product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 16; j++)
                {
                    int productNormal = (int)left[j] * (int)right[j];
                    Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
                }
            }

            left = rng.NextShort16();
            product = maxmath.mulsaturated(left, 2);

            for (int j = 0; j < 16; j++)
            {
                int productNormal = (int)left[j] * 2;
                Assert.AreEqual(productNormal > short.MaxValue ? short.MaxValue : productNormal < short.MinValue ? short.MinValue : productNormal, (int)product[j]);
            }
        }


        [Test]
        public static void _int2()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int2 left = rng.NextInt2();
                int2 right = rng.NextInt2();
                int2 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    long productNormal = (long)left[j] * (long)right[j];
                    Assert.AreEqual(productNormal > int.MaxValue ? int.MaxValue : productNormal < int.MinValue ? int.MinValue : productNormal, (long)product[j]);
                }
            }
        }

        [Test]
        public static void _int3()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int3 left = rng.NextInt3();
                int3 right = rng.NextInt3();
                int3 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    long productNormal = (long)left[j] * (long)right[j];
                    Assert.AreEqual(productNormal > int.MaxValue ? int.MaxValue : productNormal < int.MinValue ? int.MinValue : productNormal, (long)product[j]);
                }
            }
        }

        [Test]
        public static void _int4()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int4 left = rng.NextInt4();
                int4 right = rng.NextInt4();
                int4 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    long productNormal = (long)left[j] * (long)right[j];
                    Assert.AreEqual(productNormal > int.MaxValue ? int.MaxValue : productNormal < int.MinValue ? int.MinValue : productNormal, (long)product[j]);
                }
            }
        }

        [Test]
        public static void _int8()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            for (int i = 0; i < 100; i++)
            {
                int8 left = rng.NextInt8();
                int8 right = rng.NextInt8();
                int8 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 8; j++)
                {
                    long productNormal = (long)left[j] * (long)right[j];
                    Assert.AreEqual(productNormal > int.MaxValue ? int.MaxValue : productNormal < int.MinValue ? int.MinValue : productNormal, (long)product[j]);
                }
            }
        }


        [Test]
        public static void _long2()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                long2 left = rng.NextLong2();
                long2 right = rng.NextLong2();
                long2 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 2; j++)
                {
                    BigInteger productNormal = (BigInteger)left[j] * (BigInteger)right[j];
                    Assert.AreEqual(productNormal > long.MaxValue ? long.MaxValue : productNormal < long.MinValue ? long.MinValue : productNormal, (BigInteger)product[j]);
                }
            }
        }

        [Test]
        public static void _long3()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                long3 left = rng.NextLong3();
                long3 right = rng.NextLong3();
                long3 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 3; j++)
                {
                    BigInteger productNormal = (BigInteger)left[j] * (BigInteger)right[j];
                    Assert.AreEqual(productNormal > long.MaxValue ? long.MaxValue : productNormal < long.MinValue ? long.MinValue : productNormal, (BigInteger)product[j]);
                }
            }
        }

        [Test]
        public static void _long4()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            for (int i = 0; i < 100; i++)
            {
                long4 left = rng.NextLong4();
                long4 right = rng.NextLong4();
                long4 product = maxmath.mulsaturated(left, right);

                for (int j = 0; j < 4; j++)
                {
                    BigInteger productNormal = (BigInteger)left[j] * (BigInteger)right[j];
                    Assert.AreEqual(productNormal > long.MaxValue ? long.MaxValue : productNormal < long.MinValue ? long.MinValue : productNormal, (BigInteger)product[j]);
                }
            }
        }


        [Test]
        public static void _Int128()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random128 rng = new Random128(seed);

            for (int i = 0; i < 100; i++)
            {
                Int128 left = rng.NextInt128();
                Int128 right = rng.NextInt128();
                Int128 product = maxmath.mulsaturated(left, right);

                BigInteger productNormal = (BigInteger)left * (BigInteger)right;
                Assert.AreEqual(productNormal > Int128.MaxValue ? Int128.MaxValue : productNormal < Int128.MinValue ? Int128.MinValue : productNormal, (BigInteger)product);
            }
        }
    }
}