using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.LUT.FACTORIAL;
using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    public static class PROMISE_comb
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;
            byte2 n;
            byte2 k;
            byte2 normal;
            byte2 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte2(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;
            byte3 n;
            byte3 k;
            byte3 normal;
            byte3 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte3(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;
            byte4 n;
            byte4 k;
            byte4 normal;
            byte4 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte4(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;
            byte8 n;
            byte8 k;
            byte8 normal;
            byte8 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte8(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;
            byte16 n;
            byte16 k;
            byte16 normal;
            byte16 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte16(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;
            byte32 n;
            byte32 k;
            byte32 normal;
            byte32 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextByte32(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 32; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextByte32(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 32; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextByte32(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 32; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextByte32(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextByte32(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 32; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= byte.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

         
        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;
            ushort2 n;
            ushort2 k;
            ushort2 normal;
            ushort2 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUShort2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort2(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort2(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextUShort2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;
            ushort3 n;
            ushort3 k;
            ushort3 normal;
            ushort3 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUShort3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort3(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort3(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextUShort3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;
            ushort4 n;
            ushort4 k;
            ushort4 normal;
            ushort4 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUShort4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort4(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort4(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextUShort4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;
            ushort8 n;
            ushort8 k;
            ushort8 normal;
            ushort8 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort8(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUShort8(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort8(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort8(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextUShort8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;
            ushort16 n;
            ushort16 k;
            ushort16 normal;
            ushort16 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUShort16(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUShort16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUShort16(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUShort16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort16(0, MAX_INVERSE_FACTORIAL_U16 + 1);
                k = rng.NextUShort16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe2);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }

                n = rng.NextUShort16(0, MAX_INVERSE_FACTORIAL_U8 + 1);
                k = rng.NextUShort16(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe3);
                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ushort.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        
        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;
            uint n;
            uint k;
            uint normal;
            uint promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                if (maxmath.comb((UInt128)n, (UInt128)k, Promise.Unsafe0) <= uint.MaxValue)
                {
                    Assert.AreEqual(normal, promise);
                }

                n = rng.NextUInt(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                if (maxmath.comb((UInt128)n, (UInt128)k, Promise.Unsafe0) <= uint.MaxValue)
                {
                    Assert.AreEqual(normal, promise);
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;
            uint2 n;
            uint2 k;
            uint2 normal;
            uint2 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUInt2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;
            uint3 n;
            uint3 k;
            uint3 normal;
            uint3 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUInt3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;
            uint4 n;
            uint4 k;
            uint4 normal;
            uint4 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUInt4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;
            uint8 n;
            uint8 k;
            uint8 normal;
            uint8 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt8(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextUInt8(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextUInt8(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= uint.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;
            ulong n;
            ulong k;
            ulong normal;
            ulong promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                if (maxmath.comb((UInt128)n, (UInt128)k, Promise.Unsafe0) <= ulong.MaxValue)
                {
                    Assert.AreEqual(normal, promise);
                }

                n = rng.NextULong(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextULong(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                if (maxmath.comb((UInt128)n, (UInt128)k, Promise.Unsafe0) <= ulong.MaxValue)
                {
                    Assert.AreEqual(normal, promise);
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;
            ulong2 n;
            ulong2 k;
            ulong2 normal;
            ulong2 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong2(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ulong.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextULong2(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextULong2(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ulong.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;
            ulong3 n;
            ulong3 k;
            ulong3 normal;
            ulong3 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong3(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ulong.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextULong3(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextULong3(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ulong.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;
            ulong4 n;
            ulong4 k;
            ulong4 normal;
            ulong4 promise;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextULong4(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextULong4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe0);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ulong.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
                
                n = rng.NextULong4(0, MAX_INVERSE_FACTORIAL_U32 + 1);
                k = rng.NextULong4(0, n + 1);
                normal = maxmath.comb(n, k);
                promise = maxmath.comb(n, k, maxmath.Promise.Unsafe1);
                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.comb((UInt128)n[j], (UInt128)k[j], Promise.Unsafe0) <= ulong.MaxValue)
                    {
                        Assert.AreEqual(normal[j], promise[j]);
                    }
                }
            }
        }

        
        [Test]
        public static void _uint128()
        {
            Random128 rng = Random128.New;
            UInt128 n;
            UInt128 k;

            for (int i = 0; i < 24; i++)
            {
                n = rng.NextUInt128(0, MAX_INVERSE_FACTORIAL_U128 + 1);
                k = rng.NextUInt128(0, n + 1);
                Assert.AreEqual(maxmath.comb(n, k), maxmath.comb(n, k, maxmath.Promise.Unsafe0));

                n = rng.NextUInt128(0, MAX_INVERSE_FACTORIAL_U64 + 1);
                k = rng.NextUInt128(0, n + 1);
                Assert.AreEqual(maxmath.comb(n, k), maxmath.comb(n, k, maxmath.Promise.Unsafe1));
            }
        }
    }
}
