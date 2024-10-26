using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_comb
    {
        private static BigInteger realbinom<T>(BigInteger n, BigInteger k, out bool overflow)
            where T : unmanaged
        {
            BigInteger res = n;

            k = BigInteger.Min(k, n - k);
            if (k == 0)
            {
                overflow = false;
                return 1;
            }

            for (int i = 1; i < k; ++i)
            {
                res *= (n - i);
                res /= (i + 1);
            }

            overflow = res >= (BigInteger)1 << (8 * sizeof(T));

            return res;
        }

        private static void AssertEqual(byte cmp, byte n, byte k)
        {
            BigInteger real = realbinom<byte>(n, k, out bool overflow);

            if (!overflow)
            {
                Assert.AreEqual(cmp, (byte)real);
            }
        }

        private static void AssertEqual(ushort cmp, ushort n, ushort k)
        {
            BigInteger real = realbinom<ushort>(n, k, out bool overflow);

            if (!overflow)
            {
                try
                {
                    Assert.AreEqual(cmp, (ushort)real);
                }
                catch
                {
                    UnityEngine.Debug.Log(n);
                    UnityEngine.Debug.Log(k);
                    UnityEngine.Debug.Log(cmp);
                    UnityEngine.Debug.Log(real);
                    throw;
                }
            }
        }

        private static void AssertEqual(uint cmp, uint n, uint k)
        {
            BigInteger real = realbinom<uint>(n, k, out bool overflow);

            if (!overflow)
            {
                Assert.AreEqual(cmp, (uint)real);
            }
        }

        private static void AssertEqual(ulong cmp, ulong n, ulong k)
        {
            BigInteger real = realbinom<ulong>(n, k, out bool overflow);

            if (!overflow)
            {
                Assert.AreEqual(cmp, (ulong)real);
            }
        }

        private static void AssertEqual(UInt128 cmp, UInt128 n, UInt128 k)
        {
            BigInteger real = realbinom<UInt128>(n, k, out bool overflow);

            if (!overflow)
            {
                Assert.AreEqual(cmp, (UInt128)real);
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 8; i++)
            {
                UInt128 n = rng.NextUInt128(1, UInt128.MaxValue);
                UInt128 k = n - 1;

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextUInt128(1, UInt128.MaxValue);
                k = rng.NextUInt128(0, n + 1);
                k = maxmath.select(k, n - 10000, n - k > 10000);

                AssertEqual(maxmath.comb((UInt128)n, (UInt128)k), (UInt128)n, (UInt128)k);
                AssertEqual(maxmath.comb((UInt128)n, (UInt128)0), (UInt128)n, (UInt128)0);
                AssertEqual(maxmath.comb((UInt128)n, (UInt128)1), (UInt128)n, (UInt128)1);
                AssertEqual(maxmath.comb((UInt128)1, (UInt128)0), (UInt128)1, (UInt128)0);
                AssertEqual(maxmath.comb((UInt128)1, (UInt128)1), (UInt128)1, (UInt128)1);
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 8; i++)
            {
                Int128 n = rng.NextInt128(1, Int128.MaxValue);
                Int128 k = n - 1;

                Assert.AreEqual(maxmath.comb(n, k), (UInt128)n);

                n = rng.NextInt128(1, Int128.MaxValue);
                k = rng.NextInt128(0, n + 1);
                k = maxmath.select(k, n - 10000, n - k > 10000);

                AssertEqual(maxmath.comb((Int128)n, (Int128)k), (UInt128)n, (UInt128)k);
                AssertEqual(maxmath.comb((Int128)n, (Int128)0), (UInt128)n, (UInt128)0);
                AssertEqual(maxmath.comb((Int128)n, (Int128)1), (UInt128)n, (UInt128)1);
                AssertEqual(maxmath.comb((Int128)1, (Int128)0), (UInt128)1, (UInt128)0);
                AssertEqual(maxmath.comb((Int128)1, (Int128)1), (UInt128)1, (UInt128)1);
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (byte i = 0; i < 8; i++)
            {
                byte n = rng.NextByte(1, byte.MaxValue);
                byte k = (byte)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextByte(1, byte.MaxValue);
                k = rng.NextByte(0, (byte)(n + 1));
                k = maxmath.select(k, (byte)(n - 100), n - k > 100);

                AssertEqual(maxmath.comb((byte)n, (byte)k), (byte)n, (byte)k);
                AssertEqual(maxmath.comb((byte)n, (byte)0), (byte)n, (byte)0);
                AssertEqual(maxmath.comb((byte)n, (byte)1), (byte)n, (byte)1);
                AssertEqual(maxmath.comb((byte)1, (byte)0), (byte)1, (byte)0);
                AssertEqual(maxmath.comb((byte)1, (byte)1), (byte)1, (byte)1);
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte2 n = rng.NextByte2(1, 64);
                byte2 k = n - 1;
                byte2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextByte2(1, byte.MaxValue);
                k = rng.NextByte2(0, maxmath.min(rng.NextByte2(1, byte.MaxValue), maxmath.subsaturated(n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new byte2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new byte2(0, 1)[j]);
                }

                c = maxmath.comb(n, new byte2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new byte2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new byte2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new byte2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new byte2(1), new byte2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new byte2(1), new byte2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte3 n = rng.NextByte3(1, 64);
                byte3 k = n - 1;
                byte3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextByte3(1, byte.MaxValue);
                k = rng.NextByte3(0, maxmath.min(rng.NextByte3(1, byte.MaxValue), maxmath.subsaturated(n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new byte3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new byte3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new byte3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new byte3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new byte3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new byte3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new byte3(1), new byte3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new byte3(1), new byte3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte4 n = rng.NextByte4(1, 64);
                byte4 k = n - 1;
                byte4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextByte4(1, byte.MaxValue);
                k = rng.NextByte4(0, maxmath.min(rng.NextByte4(1, byte.MaxValue), maxmath.subsaturated(n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new byte4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new byte4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new byte4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new byte4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new byte4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new byte4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new byte4(1), new byte4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new byte4(1), new byte4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte8 n = rng.NextByte8(1, 64);
                byte8 k = n - 1;
                byte8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);

                n = rng.NextByte8(1, byte.MaxValue);
                k = rng.NextByte8(0, maxmath.min(rng.NextByte8(1, byte.MaxValue), maxmath.subsaturated(n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new byte8(0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new byte8(0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new byte8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new byte8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1)[j]);
                }

                c = maxmath.comb(n, new byte8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new byte8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new byte8(1), new byte8(0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new byte8(1), new byte8(1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte16 n = rng.NextByte16(1, 64);
                byte16 k = n - 1;
                byte16 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x15, n.x15);

                n = rng.NextByte16(1, byte.MaxValue);
                k = rng.NextByte16(0, maxmath.min(rng.NextByte16(1, byte.MaxValue), maxmath.subsaturated(n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new byte16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], new byte16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new byte16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], new byte16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1)[j]);
                }

                c = maxmath.comb(n, new byte16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], new byte16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new byte16(1), new byte16(0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new byte16(1), new byte16(1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte32 n = rng.NextByte32(1, 64);
                byte32 k = n - 1;
                byte32 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x15, n.x15);
                Assert.AreEqual(c.x16, n.x16);
                Assert.AreEqual(c.x17, n.x17);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x19, n.x19);
                Assert.AreEqual(c.x20, n.x20);
                Assert.AreEqual(c.x21, n.x21);
                Assert.AreEqual(c.x22, n.x22);
                Assert.AreEqual(c.x23, n.x23);
                Assert.AreEqual(c.x24, n.x24);
                Assert.AreEqual(c.x25, n.x25);
                Assert.AreEqual(c.x26, n.x26);
                Assert.AreEqual(c.x27, n.x27);
                Assert.AreEqual(c.x28, n.x28);
                Assert.AreEqual(c.x29, n.x29);
                Assert.AreEqual(c.x30, n.x30);
                Assert.AreEqual(c.x31, n.x31);

                n = rng.NextByte32(1, byte.MaxValue);
                k = rng.NextByte32(0, maxmath.min(rng.NextByte32(1, byte.MaxValue), maxmath.subsaturated(n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new byte32(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], n[j], new byte32(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new byte32(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1, k.x16, 1, k.x18, 1, k.x20, 1, k.x22, 1, k.x24, 1, k.x26, 1, k.x28, 1, k.x30, 1));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], n[j], new byte32(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1, k.x16, 1, k.x18, 1, k.x20, 1, k.x22, 1, k.x24, 1, k.x26, 1, k.x28, 1, k.x30, 1)[j]);
                }

                c = maxmath.comb(n, new byte32(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0, k.x16, 0, k.x18, 0, k.x20, 0, k.x22, 0, k.x24, 0, k.x26, 0, k.x28, 0, k.x30, 0));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], n[j], new byte32(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0, k.x16, 0, k.x18, 0, k.x20, 0, k.x22, 0, k.x24, 0, k.x26, 0, k.x28, 0, k.x30, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new byte32(1), new byte32(0));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new byte32(1), new byte32(1));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (sbyte i = 0; i < 8; i++)
            {
                sbyte n = rng.NextSByte(1, sbyte.MaxValue);
                sbyte k = (sbyte)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextSByte(1, sbyte.MaxValue);
                k = rng.NextSByte(0, (sbyte)(n + 1));
                k = maxmath.select(k, (sbyte)(n - 100), n - k > 100);

                AssertEqual(maxmath.comb((sbyte)n, (sbyte)k), (byte)n, (byte)k);
                AssertEqual(maxmath.comb((sbyte)n, (sbyte)0), (byte)n, (byte)0);
                AssertEqual(maxmath.comb((sbyte)n, (sbyte)1), (byte)n, (byte)1);
                AssertEqual(maxmath.comb((sbyte)1, (sbyte)0), (byte)1, (byte)0);
                AssertEqual(maxmath.comb((sbyte)1, (sbyte)1), (byte)1, (byte)1);
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 n = rng.NextSByte2(1, 64);
                sbyte2 k = n - 1;
                byte2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextSByte2(1, sbyte.MaxValue);
                k = rng.NextSByte2(0, maxmath.min(rng.NextSByte2(1, sbyte.MaxValue), (sbyte2)maxmath.subsaturated((byte2)n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 0);
                }

                c = maxmath.comb(n, new sbyte2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte2(0, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 1);
                }

                c = maxmath.comb(new sbyte2(1), new sbyte2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new sbyte2(1), new sbyte2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 n = rng.NextSByte3(1, 64);
                sbyte3 k = n - 1;
                byte3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextSByte3(1, sbyte.MaxValue);
                k = rng.NextSByte3(0, maxmath.min(rng.NextSByte3(1, sbyte.MaxValue), (sbyte3)maxmath.subsaturated((byte3)n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 0);
                }

                c = maxmath.comb(n, new sbyte3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new sbyte3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new sbyte3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 1);
                }

                c = maxmath.comb(new sbyte3(1), new sbyte3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new sbyte3(1), new sbyte3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 n = rng.NextSByte4(1, 64);
                sbyte4 k = n - 1;
                byte4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextSByte4(1, sbyte.MaxValue);
                k = rng.NextSByte4(0, maxmath.min(rng.NextSByte4(1, sbyte.MaxValue), (sbyte4)maxmath.subsaturated((byte4)n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 0);
                }

                c = maxmath.comb(n, new sbyte4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 1);
                }

                c = maxmath.comb(new sbyte4(1), new sbyte4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new sbyte4(1), new sbyte4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 n = rng.NextSByte8(1, 64);
                sbyte8 k = n - 1;
                byte8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);

                n = rng.NextSByte8(1, sbyte.MaxValue);
                k = rng.NextSByte8(0, maxmath.min(rng.NextSByte8(1, sbyte.MaxValue), (sbyte8)maxmath.subsaturated((byte8)n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 0);
                }

                c = maxmath.comb(n, new sbyte8(0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte8(0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 1);
                }

                c = maxmath.comb(new sbyte8(1), new sbyte8(0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new sbyte8(1), new sbyte8(1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 n = rng.NextSByte16(1, 64);
                sbyte16 k = n - 1;
                byte16 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x15, n.x15);

                n = rng.NextSByte16(1, sbyte.MaxValue);
                k = rng.NextSByte16(0, maxmath.min(rng.NextSByte16(1, sbyte.MaxValue), (sbyte16)maxmath.subsaturated((byte16)n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 0);
                }

                c = maxmath.comb(n, new sbyte16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 1);
                }

                c = maxmath.comb(new sbyte16(1), new sbyte16(0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new sbyte16(1), new sbyte16(1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 n = rng.NextSByte32(1, 64);
                sbyte32 k = n - 1;
                byte32 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x15, n.x15);
                Assert.AreEqual(c.x16, n.x16);
                Assert.AreEqual(c.x17, n.x17);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x19, n.x19);
                Assert.AreEqual(c.x20, n.x20);
                Assert.AreEqual(c.x21, n.x21);
                Assert.AreEqual(c.x22, n.x22);
                Assert.AreEqual(c.x23, n.x23);
                Assert.AreEqual(c.x24, n.x24);
                Assert.AreEqual(c.x25, n.x25);
                Assert.AreEqual(c.x26, n.x26);
                Assert.AreEqual(c.x27, n.x27);
                Assert.AreEqual(c.x28, n.x28);
                Assert.AreEqual(c.x29, n.x29);
                Assert.AreEqual(c.x30, n.x30);
                Assert.AreEqual(c.x31, n.x31);

                n = rng.NextSByte32(1, sbyte.MaxValue);
                k = rng.NextSByte32(0, maxmath.min(rng.NextSByte32(1, sbyte.MaxValue), (sbyte32)maxmath.subsaturated((byte32)n, 25)));

                c = maxmath.comb(n, k);
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 0);
                }

                c = maxmath.comb(n, new sbyte32(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte32(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte32(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1, k.x16, 1, k.x18, 1, k.x20, 1, k.x22, 1, k.x24, 1, k.x26, 1, k.x28, 1, k.x30, 1));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte32(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1, k.x16, 1, k.x18, 1, k.x20, 1, k.x22, 1, k.x24, 1, k.x26, 1, k.x28, 1, k.x30, 1)[j]);
                }

                c = maxmath.comb(n, new sbyte32(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0, k.x16, 0, k.x18, 0, k.x20, 0, k.x22, 0, k.x24, 0, k.x26, 0, k.x28, 0, k.x30, 0));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], (byte)n[j], (byte)new sbyte32(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0, k.x16, 0, k.x18, 0, k.x20, 0, k.x22, 0, k.x24, 0, k.x26, 0, k.x28, 0, k.x30, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], (byte)n[j], 1);
                }

                c = maxmath.comb(new sbyte32(1), new sbyte32(0));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new sbyte32(1), new sbyte32(1));
                for (int j = 0; j < 32; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (ushort i = 0; i < 8; i++)
            {
                ushort n = rng.NextUShort(1, ushort.MaxValue);
                ushort k = (ushort)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextUShort(1, ushort.MaxValue);
                k = rng.NextUShort(0, (ushort)(n + 1));
                k = maxmath.select(k, (ushort)(n - 1000), n - k > 1000);

                AssertEqual(maxmath.comb((ushort)n, (ushort)k), (ushort)n, (ushort)k);
                AssertEqual(maxmath.comb((ushort)n, (ushort)0), (ushort)n, (ushort)0);
                AssertEqual(maxmath.comb((ushort)n, (ushort)1), (ushort)n, (ushort)1);
                AssertEqual(maxmath.comb((ushort)1, (ushort)0), (ushort)1, (ushort)0);
                AssertEqual(maxmath.comb((ushort)1, (ushort)1), (ushort)1, (ushort)1);
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort2 n = rng.NextUShort2(1, 64);
                ushort2 k = n - 1;
                ushort2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextUShort2(1, ushort.MaxValue);
                k = rng.NextUShort2(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ushort2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new ushort2(0, 1)[j]);
                }

                c = maxmath.comb(n, new ushort2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new ushort2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new ushort2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new ushort2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ushort2(1), new ushort2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ushort2(1), new ushort2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort3 n = rng.NextUShort3(1, 64);
                ushort3 k = n - 1;
                ushort3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextUShort3(1, ushort.MaxValue);
                k = rng.NextUShort3(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ushort3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new ushort3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new ushort3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new ushort3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new ushort3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new ushort3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ushort3(1), new ushort3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ushort3(1), new ushort3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort4 n = rng.NextUShort4(1, 64);
                ushort4 k = n - 1;
                ushort4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextUShort4(1, ushort.MaxValue);
                k = rng.NextUShort4(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ushort4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new ushort4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new ushort4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new ushort4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new ushort4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new ushort4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ushort4(1), new ushort4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ushort4(1), new ushort4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort8 n = rng.NextUShort8(1, 64);
                ushort8 k = n - 1;
                ushort8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);

                n = rng.NextUShort8(1, ushort.MaxValue);
                k = rng.NextUShort8(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ushort8(0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new ushort8(0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new ushort8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new ushort8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1)[j]);
                }

                c = maxmath.comb(n, new ushort8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new ushort8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ushort8(1), new ushort8(0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ushort8(1), new ushort8(1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                ushort16 n = rng.NextUShort16(1, 64);
                ushort16 k = n - 1;
                ushort16 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x15, n.x15);

                n = rng.NextUShort16(1, ushort.MaxValue);
                k = rng.NextUShort16(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ushort16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], new ushort16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new ushort16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], new ushort16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1)[j]);
                }

                c = maxmath.comb(n, new ushort16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], new ushort16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ushort16(1), new ushort16(0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ushort16(1), new ushort16(1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (short i = 0; i < 8; i++)
            {
                short n = rng.NextShort(1, short.MaxValue);
                short k = (short)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextShort(1, short.MaxValue);
                k = rng.NextShort(0, (short)(n + 1));
                k = maxmath.select(k, (short)(n - 1000), n - k > 1000);

                AssertEqual(maxmath.comb((short)n, (short)k), (ushort)n, (ushort)k);
                AssertEqual(maxmath.comb((short)n, (short)0), (ushort)n, (ushort)0);
                AssertEqual(maxmath.comb((short)n, (short)1), (ushort)n, (ushort)1);
                AssertEqual(maxmath.comb((short)1, (short)0), (ushort)1, (ushort)0);
                AssertEqual(maxmath.comb((short)1, (short)1), (ushort)1, (ushort)1);
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 n = rng.NextShort2(1, 64);
                short2 k = n - 1;
                ushort2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextShort2(1, short.MaxValue);
                k = rng.NextShort2(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 0);
                }

                c = maxmath.comb(n, new short2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short2(0, 1)[j]);
                }

                c = maxmath.comb(n, new short2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new short2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 1);
                }

                c = maxmath.comb(new short2(1), new short2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new short2(1), new short2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 n = rng.NextShort3(1, 64);
                short3 k = n - 1;
                ushort3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextShort3(1, short.MaxValue);
                k = rng.NextShort3(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 0);
                }

                c = maxmath.comb(n, new short3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new short3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new short3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 1);
                }

                c = maxmath.comb(new short3(1), new short3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new short3(1), new short3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 n = rng.NextShort4(1, 64);
                short4 k = n - 1;
                ushort4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextShort4(1, short.MaxValue);
                k = rng.NextShort4(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 0);
                }

                c = maxmath.comb(n, new short4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new short4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new short4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 1);
                }

                c = maxmath.comb(new short4(1), new short4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new short4(1), new short4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 n = rng.NextShort8(1, 64);
                short8 k = n - 1;
                ushort8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);

                n = rng.NextShort8(1, short.MaxValue);
                k = rng.NextShort8(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 0);
                }

                c = maxmath.comb(n, new short8(0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short8(0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new short8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1)[j]);
                }

                c = maxmath.comb(n, new short8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 1);
                }

                c = maxmath.comb(new short8(1), new short8(0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new short8(1), new short8(1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 n = rng.NextShort16(1, 64);
                short16 k = n - 1;
                ushort16 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0,  n.x0);
                Assert.AreEqual(c.x1,  n.x1);
                Assert.AreEqual(c.x2,  n.x2);
                Assert.AreEqual(c.x3,  n.x3);
                Assert.AreEqual(c.x4,  n.x4);
                Assert.AreEqual(c.x5,  n.x5);
                Assert.AreEqual(c.x6,  n.x6);
                Assert.AreEqual(c.x7,  n.x7);
                Assert.AreEqual(c.x8,  n.x8);
                Assert.AreEqual(c.x9,  n.x9);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x11, n.x11);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x13, n.x13);
                Assert.AreEqual(c.x10, n.x10);
                Assert.AreEqual(c.x15, n.x15);

                n = rng.NextShort16(1, short.MaxValue);
                k = rng.NextShort16(0, n + 1);
                k = maxmath.select(k, n - 1000, n - k > 1000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 0);
                }

                c = maxmath.comb(n, new short16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short16(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new short16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short16(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1, k.x8, 1, k.x10, 1, k.x12, 1, k.x14, 1)[j]);
                }

                c = maxmath.comb(n, new short16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], (ushort)new short16(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0, k.x8, 0, k.x10, 0, k.x12, 0, k.x14, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], (ushort)n[j], 1);
                }

                c = maxmath.comb(new short16(1), new short16(0));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new short16(1), new short16(1));
                for (int j = 0; j < 16; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 8; i++)
            {
                uint n = rng.NextUInt(1, uint.MaxValue);
                uint k = (uint)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextUInt(1, uint.MaxValue);
                k = rng.NextUInt(0, (uint)(n + 1));
                k = math.select(k, (uint)(n - 2000), n - k > 2000);

                AssertEqual(maxmath.comb((uint)n, (uint)k), (uint)n, (uint)k);
                AssertEqual(maxmath.comb((uint)n, (uint)0), (uint)n, (uint)0);
                AssertEqual(maxmath.comb((uint)n, (uint)1), (uint)n, (uint)1);
                AssertEqual(maxmath.comb((uint)1, (uint)0), (uint)1, (uint)0);
                AssertEqual(maxmath.comb((uint)1, (uint)1), (uint)1, (uint)1);
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint2 n = rng.NextUInt2(1, 64);
                uint2 k = n - 1;
                uint2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextUInt2(1, uint.MaxValue);
                k = rng.NextUInt2(0, n + 1);
                k = math.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new uint2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new uint2(0, 1)[j]);
                }

                c = maxmath.comb(n, new uint2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new uint2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new uint2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new uint2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new uint2(1), new uint2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new uint2(1), new uint2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint3 n = rng.NextUInt3(1, 64);
                uint3 k = n - 1;
                uint3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextUInt3(1, uint.MaxValue);
                k = rng.NextUInt3(0, n + 1);
                k = math.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new uint3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new uint3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new uint3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new uint3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new uint3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new uint3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new uint3(1), new uint3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new uint3(1), new uint3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint4 n = rng.NextUInt4(1, 64);
                uint4 k = n - 1;
                uint4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextUInt4(1, uint.MaxValue);
                k = rng.NextUInt4(0, n + 1);
                k = math.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new uint4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new uint4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new uint4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new uint4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new uint4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new uint4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new uint4(1), new uint4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new uint4(1), new uint4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                uint8 n = rng.NextUInt8(1, 64);
                uint8 k = n - 1;
                uint8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);

                n = rng.NextUInt8(1, uint.MaxValue);
                k = rng.NextUInt8(0, n + 1);
                k = maxmath.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new uint8(0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new uint8(0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new uint8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new uint8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1)[j]);
                }

                c = maxmath.comb(n, new uint8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], new uint8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new uint8(1), new uint8(0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new uint8(1), new uint8(1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int n = rng.NextInt(1, int.MaxValue);
                int k = (int)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextInt(1, int.MaxValue);
                k = rng.NextInt(0, (int)(n + 1));
                k = math.select(k, (int)(n - 2000), n - k > 2000);

                AssertEqual(maxmath.comb((int)n, (int)k), (uint)n, (uint)k);
                AssertEqual(maxmath.comb((int)n, (int)0), (uint)n, (uint)0);
                AssertEqual(maxmath.comb((int)n, (int)1), (uint)n, (uint)1);
                AssertEqual(maxmath.comb((int)1, (int)0), (uint)1, (uint)0);
                AssertEqual(maxmath.comb((int)1, (int)1), (uint)1, (uint)1);
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 n = rng.NextInt2(1, 64);
                int2 k = n - 1;
                uint2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextInt2(1, int.MaxValue);
                k = rng.NextInt2(0, n + 1);
                k = math.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 0);
                }

                c = maxmath.comb(n, new int2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int2(0, 1)[j]);
                }

                c = maxmath.comb(n, new int2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new int2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 1);
                }

                c = maxmath.comb(new int2(1), new int2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new int2(1), new int2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 n = rng.NextInt3(1, 64);
                int3 k = n - 1;
                uint3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextInt3(1, int.MaxValue);
                k = rng.NextInt3(0, n + 1);
                k = math.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 0);
                }

                c = maxmath.comb(n, new int3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new int3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new int3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 1);
                }

                c = maxmath.comb(new int3(1), new int3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new int3(1), new int3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 n = rng.NextInt4(1, 64);
                int4 k = n - 1;
                uint4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextInt4(1, int.MaxValue);
                k = rng.NextInt4(0, n + 1);
                k = math.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 0);
                }

                c = maxmath.comb(n, new int4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new int4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new int4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 1);
                }

                c = maxmath.comb(new int4(1), new int4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new int4(1), new int4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 n = rng.NextInt8(1, 64);
                int8 k = n - 1;
                uint8 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x0, n.x0);
                Assert.AreEqual(c.x1, n.x1);
                Assert.AreEqual(c.x2, n.x2);
                Assert.AreEqual(c.x3, n.x3);
                Assert.AreEqual(c.x4, n.x4);
                Assert.AreEqual(c.x5, n.x5);
                Assert.AreEqual(c.x6, n.x6);
                Assert.AreEqual(c.x7, n.x7);

                n = rng.NextInt8(1, int.MaxValue);
                k = rng.NextInt8(0, n + 1);
                k = maxmath.select(k, n - 2000, n - k > 2000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 0);
                }

                c = maxmath.comb(n, new int8(0, 1, 0, 1, 0, 1, 0, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int8(0, 1, 0, 1, 0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new int8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int8(k.x0, 1, k.x2, 1, k.x4, 1, k.x6, 1)[j]);
                }

                c = maxmath.comb(n, new int8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (uint)n[j], (uint)new int8(k.x0, 0, k.x2, 0, k.x4, 0, k.x6, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], (uint)n[j], 1);
                }

                c = maxmath.comb(new int8(1), new int8(0));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new int8(1), new int8(1));
                for (int j = 0; j < 8; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 8; i++)
            {
                ulong n = rng.NextULong(1, ulong.MaxValue);
                ulong k = (ulong)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextULong(1, ulong.MaxValue);
                k = rng.NextULong(0, (ulong)(n + 1));
                k = math.select(k, (ulong)(n - 5000), n - k > 5000);

                AssertEqual(maxmath.comb((ulong)n, (ulong)k), (ulong)n, (ulong)k);
                AssertEqual(maxmath.comb((ulong)n, (ulong)0), (ulong)n, (ulong)0);
                AssertEqual(maxmath.comb((ulong)n, (ulong)1), (ulong)n, (ulong)1);
                AssertEqual(maxmath.comb((ulong)1, (ulong)0), (ulong)1, (ulong)0);
                AssertEqual(maxmath.comb((ulong)1, (ulong)1), (ulong)1, (ulong)1);
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                ulong2 n = rng.NextULong2(1, 64);
                ulong2 k = n - 1;
                ulong2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextULong2(1, ulong.MaxValue);
                k = rng.NextULong2(0, n + 1);
                k = maxmath.select(k, n - 5000, n - k > 5000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ulong2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new ulong2(0, 1)[j]);
                }

                c = maxmath.comb(n, new ulong2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new ulong2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new ulong2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], new ulong2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ulong2(1), new ulong2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ulong2(1), new ulong2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                ulong3 n = rng.NextULong3(1, 64);
                ulong3 k = n - 1;
                ulong3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextULong3(1, ulong.MaxValue);
                k = rng.NextULong3(0, n + 1);
                k = maxmath.select(k, n - 5000, n - k > 5000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ulong3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new ulong3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new ulong3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new ulong3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new ulong3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], new ulong3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ulong3(1), new ulong3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ulong3(1), new ulong3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                ulong4 n = rng.NextULong4(1, 64);
                ulong4 k = n - 1;
                ulong4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextULong4(1, ulong.MaxValue);
                k = rng.NextULong4(0, n + 1);
                k = maxmath.select(k, n - 5000, n - k > 5000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 0);
                }

                c = maxmath.comb(n, new ulong4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new ulong4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new ulong4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new ulong4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new ulong4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], new ulong4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], n[j], 1);
                }

                c = maxmath.comb(new ulong4(1), new ulong4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new ulong4(1), new ulong4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 8; i++)
            {
                long n = rng.NextLong(1, long.MaxValue);
                long k = (long)(n - 1);

                Assert.AreEqual(maxmath.comb(n, k), n);

                n = rng.NextLong(1, long.MaxValue);
                k = rng.NextLong(0, (long)(n + 1));
                k = math.select(k, (long)(n - 5000), n - k > 5000);

                AssertEqual(maxmath.comb((long)n, (long)k), (ulong)n, (ulong)k);
                AssertEqual(maxmath.comb((long)n, (long)0), (ulong)n, (ulong)0);
                AssertEqual(maxmath.comb((long)n, (long)1), (ulong)n, (ulong)1);
                AssertEqual(maxmath.comb((long)1, (long)0), (ulong)1, (ulong)0);
                AssertEqual(maxmath.comb((long)1, (long)1), (ulong)1, (ulong)1);
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long2 n = rng.NextLong2(1, 64);
                long2 k = n - 1;
                ulong2 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);

                n = rng.NextLong2(1, long.MaxValue);
                k = rng.NextLong2(0, n + 1);
                k = maxmath.select(k, n - 5000, n - k > 5000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], 0);
                }

                c = maxmath.comb(n, new long2(0, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long2(0, 1)[j]);
                }

                c = maxmath.comb(n, new long2(k.x, 1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long2(k.x, 1)[j]);
                }

                c = maxmath.comb(n, new long2(k.x, 0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long2(k.x, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], 1);
                }

                c = maxmath.comb(new long2(1), new long2(0));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new long2(1), new long2(1));
                for (int j = 0; j < 2; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long3 n = rng.NextLong3(1, 64);
                long3 k = n - 1;
                ulong3 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);

                n = rng.NextLong3(1, long.MaxValue);
                k = rng.NextLong3(0, n + 1);
                k = maxmath.select(k, n - 5000, n - k > 5000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], 0);
                }

                c = maxmath.comb(n, new long3(0, 1, 0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long3(0, 1, 0)[j]);
                }

                c = maxmath.comb(n, new long3(k.x, 1, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long3(k.x, 1, k.z)[j]);
                }

                c = maxmath.comb(n, new long3(k.x, 0, k.z));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long3(k.x, 0, k.z)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], 1);
                }

                c = maxmath.comb(new long3(1), new long3(0));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new long3(1), new long3(1));
                for (int j = 0; j < 3; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long4 n = rng.NextLong4(1, 64);
                long4 k = n - 1;
                ulong4 c;

                c = maxmath.comb(n, k);
                Assert.AreEqual(c.x, n.x);
                Assert.AreEqual(c.y, n.y);
                Assert.AreEqual(c.z, n.z);
                Assert.AreEqual(c.w, n.w);

                n = rng.NextLong4(1, long.MaxValue);
                k = rng.NextLong4(0, n + 1);
                k = maxmath.select(k, n - 5000, n - k > 5000);

                c = maxmath.comb(n, k);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)k[j]);
                }

                c = maxmath.comb(n, 0);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], 0);
                }

                c = maxmath.comb(n, new long4(0, 1, 0, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long4(0, 1, 0, 1)[j]);
                }

                c = maxmath.comb(n, new long4(k.x, 1, k.z, 1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long4(k.x, 1, k.z, 1)[j]);
                }

                c = maxmath.comb(n, new long4(k.x, 0, k.z, 0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], (ulong)new long4(k.x, 0, k.z, 0)[j]);
                }

                c = maxmath.comb(n, 1);
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], (ulong)n[j], 1);
                }

                c = maxmath.comb(new long4(1), new long4(0));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 0);
                }

                c = maxmath.comb(new long4(1), new long4(1));
                for (int j = 0; j < 4; j++)
                {
                    AssertEqual(c[j], 1, 1);
                }
            }
        }
    }
}
