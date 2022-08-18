using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class SaturatedColumnProduct
    {
        [Test]
        public static void byte2()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            for (int i = 0; i < 100; i++)
            {
                byte2 vec = rng.NextByte2();
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                byte2 vec = rng.NextByte2(0, byte.MaxValue / 2);
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                byte3 vec = rng.NextByte3();
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                byte3 vec = rng.NextByte3(0, byte.MaxValue / 3);
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                byte4 vec = rng.NextByte4();
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                byte4 vec = rng.NextByte4(0, byte.MaxValue / 4);
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                byte8 vec = rng.NextByte8();
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                byte8 vec = rng.NextByte8(0, byte.MaxValue / 8);
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                byte16 vec = rng.NextByte16();
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                byte16 vec = rng.NextByte16(0, byte.MaxValue / 16);
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                byte32 vec = rng.NextByte32();
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 32; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                byte32 vec = rng.NextByte32(0, byte.MaxValue / 32);
                byte product = maxmath.cprodsaturated(vec);
                byte stdProduct = 1;

                for (int j = 0; j < 32; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ushort2 vec = rng.NextUShort2();
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ushort2 vec = rng.NextUShort2(0, ushort.MaxValue / 2);
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ushort3 vec = rng.NextUShort3();
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ushort3 vec = rng.NextUShort3(0, ushort.MaxValue / 3);
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ushort4 vec = rng.NextUShort4();
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ushort4 vec = rng.NextUShort4(0, ushort.MaxValue / 4);
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ushort8 vec = rng.NextUShort8();
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ushort8 vec = rng.NextUShort8(0, ushort.MaxValue / 8);
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ushort16 vec = rng.NextUShort16();
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ushort16 vec = rng.NextUShort16(0, ushort.MaxValue / 16);
                ushort product = maxmath.cprodsaturated(vec);
                ushort stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                uint2 vec = rng.NextUInt2();
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                uint2 vec = rng.NextUInt2(0, uint.MaxValue / 2);
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                uint3 vec = rng.NextUInt3();
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                uint3 vec = rng.NextUInt3(0, uint.MaxValue / 3);
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                uint4 vec = rng.NextUInt4();
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                uint4 vec = rng.NextUInt4(0, uint.MaxValue / 4);
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                uint8 vec = rng.NextUInt8();
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                uint8 vec = rng.NextUInt8(0, uint.MaxValue / 8);
                uint product = maxmath.cprodsaturated(vec);
                uint stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ulong2 vec = rng.NextULong2();
                ulong product = maxmath.cprodsaturated(vec);
                ulong stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ulong2 vec = rng.NextULong2(0, ulong.MaxValue / 2);
                ulong product = maxmath.cprodsaturated(vec);
                ulong stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ulong3 vec = rng.NextULong3();
                ulong product = maxmath.cprodsaturated(vec);
                ulong stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ulong3 vec = rng.NextULong3(0, ulong.MaxValue / 3);
                ulong product = maxmath.cprodsaturated(vec);
                ulong stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                ulong4 vec = rng.NextULong4();
                ulong product = maxmath.cprodsaturated(vec);
                ulong stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
            }

            for (int i = 0; i < 100; i++)
            {
                ulong4 vec = rng.NextULong4(0, ulong.MaxValue / 4);
                ulong product = maxmath.cprodsaturated(vec);
                ulong stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct = maxmath.mulsaturated(stdProduct, vec[j]);
                }

                Assert.AreEqual(product, stdProduct);
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
                sbyte2 vec = rng.NextSByte2();
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                sbyte2 vec = rng.NextSByte2(sbyte.MinValue / 2, sbyte.MaxValue / 2);
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
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
                sbyte3 vec = rng.NextSByte3();
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                sbyte3 vec = rng.NextSByte3(sbyte.MinValue / 3, sbyte.MaxValue / 3);
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
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
                sbyte4 vec = rng.NextSByte4();
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                sbyte4 vec = rng.NextSByte4(sbyte.MinValue / 4, sbyte.MaxValue / 4);
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
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
                sbyte8 vec = rng.NextSByte8();
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                sbyte8 vec = rng.NextSByte8(sbyte.MinValue / 8, sbyte.MaxValue / 8);
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
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
                sbyte16 vec = rng.NextSByte16();
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                sbyte16 vec = rng.NextSByte16(sbyte.MinValue / 16, sbyte.MaxValue / 16);
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
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
                sbyte32 vec = rng.NextSByte32();
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 32; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                sbyte32 vec = rng.NextSByte32(sbyte.MinValue / 32, sbyte.MaxValue / 32);
                sbyte product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 32; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, sbyte.MinValue), sbyte.MaxValue));
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
                short2 vec = rng.NextShort2();
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                short2 vec = rng.NextShort2(short.MinValue / 2, short.MaxValue / 2);
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
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
                short3 vec = rng.NextShort3();
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                short3 vec = rng.NextShort3(short.MinValue / 3, short.MaxValue / 3);
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
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
                short4 vec = rng.NextShort4();
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                short4 vec = rng.NextShort4(short.MinValue / 4, short.MaxValue / 4);
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
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
                short8 vec = rng.NextShort8();
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                short8 vec = rng.NextShort8(short.MinValue / 8, short.MaxValue / 8);
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
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
                short16 vec = rng.NextShort16();
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                short16 vec = rng.NextShort16(short.MinValue / 16, short.MaxValue / 16);
                short product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 16; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, short.MinValue), short.MaxValue));
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
                int2 vec = rng.NextInt2();
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                int2 vec = rng.NextInt2(int.MinValue / 2, int.MaxValue / 2);
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
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
                int3 vec = rng.NextInt3();
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                int3 vec = rng.NextInt3(int.MinValue / 3, int.MaxValue / 3);
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
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
                int4 vec = rng.NextInt4();
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                int4 vec = rng.NextInt4(int.MinValue / 4, int.MaxValue / 4);
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
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
                int8 vec = rng.NextInt8();
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                int8 vec = rng.NextInt8(int.MinValue / 8, int.MaxValue / 8);
                int product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 8; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, int.MinValue), int.MaxValue));
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
                long2 vec = rng.NextLong2();
                long product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, long.MinValue), long.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                long2 vec = rng.NextLong2(long.MinValue / 2, long.MaxValue / 2);
                long product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 2; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, long.MinValue), long.MaxValue));
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
                long3 vec = rng.NextLong3();
                long product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, long.MinValue), long.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                long3 vec = rng.NextLong3(long.MinValue / 3, long.MaxValue / 3);
                long product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 3; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, long.MinValue), long.MaxValue));
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
                long4 vec = rng.NextLong4();
                long product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, long.MinValue), long.MaxValue));
            }

            for (int i = 0; i < 100; i++)
            {
                long4 vec = rng.NextLong4(long.MinValue / 4, long.MaxValue / 4);
                long product = maxmath.cprodsaturated(vec);
                BigInteger stdProduct = 1;

                for (int j = 0; j < 4; j++)
                {
                    stdProduct *= vec[j];
                }

                Assert.AreEqual((BigInteger)product, BigInteger.Min(BigInteger.Max(stdProduct, long.MinValue), long.MaxValue));
            }
        }
    }
}