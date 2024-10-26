using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_roundmultiple
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte x = rng.NextByte();
                byte n = (byte)(1 << i);

                if (maxmath.subsaturated(maxmath.addsaturated(x, (byte)(n / 2)), (byte)(n - 1)) == (byte)((byte)(x + (byte)(n / 2)) - (byte)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte2 x = rng.NextByte2();
                byte2 n = (byte)(1 << i);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (byte)(n[j] / 2)), (byte)(n[j] - 1)) == (byte)((byte)(x[j] + (byte)(n[j] / 2)) - (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte3 x = rng.NextByte3();
                byte3 n = (byte)(1 << i);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (byte)(n[j] / 2)), (byte)(n[j] - 1)) == (byte)((byte)(x[j] + (byte)(n[j] / 2)) - (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte4 x = rng.NextByte4();
                byte4 n = (byte)(1 << i);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (byte)(n[j] / 2)), (byte)(n[j] - 1)) == (byte)((byte)(x[j] + (byte)(n[j] / 2)) - (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte8 x = rng.NextByte8();
                byte8 n = (byte)(1 << i);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (byte)(n[j] / 2)), (byte)(n[j] - 1)) == (byte)((byte)(x[j] + (byte)(n[j] / 2)) - (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte16 x = rng.NextByte16();
                byte16 n = (byte)(1 << i);

                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (byte)(n[j] / 2)), (byte)(n[j] - 1)) == (byte)((byte)(x[j] + (byte)(n[j] / 2)) - (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                byte32 x = rng.NextByte32();
                byte32 n = (byte)(1 << i);

                for (int j = 0; j < 32; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (byte)(n[j] / 2)), (byte)(n[j] - 1)) == (byte)((byte)(x[j] + (byte)(n[j] / 2)) - (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte x = rng.NextSByte();
                byte n = (byte)(1 << i);

                if (maxmath.subsaturated(maxmath.addsaturated(x, (sbyte)(n / 2)), (sbyte)(n - 1)) == (sbyte)((sbyte)(x + (sbyte)(n / 2)) - (sbyte)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                sbyte x = rng.NextSByte(0, sbyte.MaxValue);
                byte n = rng.NextByte(1, (byte)sbyte.MaxValue);

                if (maxmath.addsaturated(x, (sbyte)(n / 2)) == (sbyte)(x + (sbyte)(n / 2)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.ZeroOrGreater));
                }
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 x = rng.NextSByte2();
                byte2 n = (byte)(1 << i);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)), (sbyte)(n[j] - 1)) == (sbyte)((sbyte)(x[j] + (sbyte)(n[j] / 2)) - (sbyte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                sbyte2 x = rng.NextSByte2(0, sbyte.MaxValue);
                byte2 n = rng.NextByte2(1, (byte)sbyte.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)) == (sbyte)(x[j] + (sbyte)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 x = rng.NextSByte3();
                byte3 n = (byte)(1 << i);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)), (sbyte)(n[j] - 1)) == (sbyte)((sbyte)(x[j] + (sbyte)(n[j] / 2)) - (sbyte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                sbyte3 x = rng.NextSByte3(0, sbyte.MaxValue);
                byte3 n = rng.NextByte3(1, (byte)sbyte.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)) == (sbyte)(x[j] + (sbyte)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 x = rng.NextSByte4();
                byte4 n = (byte)(1 << i);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)), (sbyte)(n[j] - 1)) == (sbyte)((sbyte)(x[j] + (sbyte)(n[j] / 2)) - (sbyte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                sbyte4 x = rng.NextSByte4(0, sbyte.MaxValue);
                byte4 n = rng.NextByte4(1, (byte)sbyte.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)) == (sbyte)(x[j] + (sbyte)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 x = rng.NextSByte8();
                byte8 n = (byte)(1 << i);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)), (sbyte)(n[j] - 1)) == (sbyte)((sbyte)(x[j] + (sbyte)(n[j] / 2)) - (sbyte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                sbyte8 x = rng.NextSByte8(0, sbyte.MaxValue);
                byte8 n = rng.NextByte8(1, (byte)sbyte.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)) == (sbyte)(x[j] + (sbyte)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 x = rng.NextSByte16();
                byte16 n = (byte)(1 << i);

                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)), (sbyte)(n[j] - 1)) == (sbyte)((sbyte)(x[j] + (sbyte)(n[j] / 2)) - (sbyte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                sbyte16 x = rng.NextSByte16(0, sbyte.MaxValue);
                byte16 n = rng.NextByte16(1, (byte)sbyte.MaxValue);

                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)) == (sbyte)(x[j] + (sbyte)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 x = rng.NextSByte32();
                byte32 n = (byte)(1 << i);

                for (int j = 0; j < 32; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)), (sbyte)(n[j] - 1)) == (sbyte)((sbyte)(x[j] + (sbyte)(n[j] / 2)) - (sbyte)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                sbyte32 x = rng.NextSByte32(0, sbyte.MaxValue);
                byte32 n = rng.NextByte32(1, (byte)sbyte.MaxValue);

                for (int j = 0; j < 32; j++)
                {
                    if (maxmath.addsaturated(x[j], (sbyte)(n[j] / 2)) == (sbyte)(x[j] + (sbyte)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort x = rng.NextUShort();
                ushort n = (ushort)(1 << i);

                if (maxmath.subsaturated(maxmath.addsaturated(x, (ushort)(n / 2)), (ushort)(n - 1)) == (ushort)((ushort)(x + (ushort)(n / 2)) - (ushort)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 n = (ushort)(1 << i);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ushort)(n[j] / 2)), (ushort)(n[j] - 1)) == (ushort)((ushort)(x[j] + (ushort)(n[j] / 2)) - (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 n = (ushort)(1 << i);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ushort)(n[j] / 2)), (ushort)(n[j] - 1)) == (ushort)((ushort)(x[j] + (ushort)(n[j] / 2)) - (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 n = (ushort)(1 << i);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ushort)(n[j] / 2)), (ushort)(n[j] - 1)) == (ushort)((ushort)(x[j] + (ushort)(n[j] / 2)) - (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort8 x = rng.NextUShort8();
                ushort8 n = (ushort)(1 << i);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ushort)(n[j] / 2)), (ushort)(n[j] - 1)) == (ushort)((ushort)(x[j] + (ushort)(n[j] / 2)) - (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort16 x = rng.NextUShort16();
                ushort16 n = (ushort)(1 << i);

                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ushort)(n[j] / 2)), (ushort)(n[j] - 1)) == (ushort)((ushort)(x[j] + (ushort)(n[j] / 2)) - (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short x = rng.NextShort();
                ushort n = (ushort)(1 << i);

                if (maxmath.subsaturated(maxmath.addsaturated(x, (short)(n / 2)), (short)(n - 1)) == (short)((short)(x + (short)(n / 2)) - (short)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                short x = rng.NextShort(0, short.MaxValue);
                ushort n = rng.NextUShort(1, (ushort)short.MaxValue);

                if (maxmath.addsaturated(x, (short)(n / 2)) == (short)(x + (short)(n / 2)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.ZeroOrGreater));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2 x = rng.NextShort2();
                ushort2 n = (ushort)(1 << i);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (short)(n[j] / 2)), (short)(n[j] - 1)) == (short)((short)(x[j] + (short)(n[j] / 2)) - (short)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                short2 x = rng.NextShort2(0, short.MaxValue);
                ushort2 n = rng.NextUShort2(1, (ushort)short.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.addsaturated(x[j], (short)(n[j] / 2)) == (short)(x[j] + (short)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3 x = rng.NextShort3();
                ushort3 n = (ushort)(1 << i);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (short)(n[j] / 2)), (short)(n[j] - 1)) == (short)((short)(x[j] + (short)(n[j] / 2)) - (short)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                short3 x = rng.NextShort3(0, short.MaxValue);
                ushort3 n = rng.NextUShort3(1, (ushort)short.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.addsaturated(x[j], (short)(n[j] / 2)) == (short)(x[j] + (short)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4 x = rng.NextShort4();
                ushort4 n = (ushort)(1 << i);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (short)(n[j] / 2)), (short)(n[j] - 1)) == (short)((short)(x[j] + (short)(n[j] / 2)) - (short)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                short4 x = rng.NextShort4(0, short.MaxValue);
                ushort4 n = rng.NextUShort4(1, (ushort)short.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.addsaturated(x[j], (short)(n[j] / 2)) == (short)(x[j] + (short)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short8 x = rng.NextShort8();
                ushort8 n = (ushort)(1 << i);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (short)(n[j] / 2)), (short)(n[j] - 1)) == (short)((short)(x[j] + (short)(n[j] / 2)) - (short)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                short8 x = rng.NextShort8(0, short.MaxValue);
                ushort8 n = rng.NextUShort8(1, (ushort)short.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.addsaturated(x[j], (short)(n[j] / 2)) == (short)(x[j] + (short)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short16 x = rng.NextShort16();
                ushort16 n = (ushort)(1 << i);

                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (short)(n[j] / 2)), (short)(n[j] - 1)) == (short)((short)(x[j] + (short)(n[j] / 2)) - (short)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                short16 x = rng.NextShort16(0, short.MaxValue);
                ushort16 n = rng.NextUShort16(1, (ushort)short.MaxValue);

                for (int j = 0; j < 16; j++)
                {
                    if (maxmath.addsaturated(x[j], (short)(n[j] / 2)) == (short)(x[j] + (short)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint x = rng.NextUInt();
                uint n = (uint)(1 << i);

                if (maxmath.subsaturated(maxmath.addsaturated(x, (uint)(n / 2)), (uint)(n - 1)) == (uint)((uint)(x + (uint)(n / 2)) - (uint)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 x = rng.NextUInt2();
                uint2 n = (uint)(1 << i);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (uint)(n[j] / 2)), (uint)(n[j] - 1)) == (uint)((uint)(x[j] + (uint)(n[j] / 2)) - (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 x = rng.NextUInt3();
                uint3 n = (uint)(1 << i);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (uint)(n[j] / 2)), (uint)(n[j] - 1)) == (uint)((uint)(x[j] + (uint)(n[j] / 2)) - (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 x = rng.NextUInt4();
                uint4 n = (uint)(1 << i);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (uint)(n[j] / 2)), (uint)(n[j] - 1)) == (uint)((uint)(x[j] + (uint)(n[j] / 2)) - (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 x = rng.NextUInt8();
                uint8 n = (uint)(1 << i);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (uint)(n[j] / 2)), (uint)(n[j] - 1)) == (uint)((uint)(x[j] + (uint)(n[j] / 2)) - (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int x = rng.NextInt();
                uint n = (uint)(1 << i);

                if (maxmath.subsaturated(maxmath.addsaturated(x, (int)(n / 2)), (int)(n - 1)) == (int)((int)(x + (int)(n / 2)) - (int)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                int x = rng.NextInt(0, int.MaxValue);
                uint n = rng.NextUInt(1, (uint)int.MaxValue);

                if (maxmath.addsaturated(x, (int)(n / 2)) == (int)(x + (int)(n / 2)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.ZeroOrGreater));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int2 x = rng.NextInt2();
                uint2 n = (uint)(1 << i);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (int)(n[j] / 2)), (int)(n[j] - 1)) == (int)((int)(x[j] + (int)(n[j] / 2)) - (int)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                int2 x = rng.NextInt2(0, int.MaxValue);
                uint2 n = rng.NextUInt2(1, (uint)int.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.addsaturated(x[j], (int)(n[j] / 2)) == (int)(x[j] + (int)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int3 x = rng.NextInt3();
                uint3 n = (uint)(1 << i);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (int)(n[j] / 2)), (int)(n[j] - 1)) == (int)((int)(x[j] + (int)(n[j] / 2)) - (int)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                int3 x = rng.NextInt3(0, int.MaxValue);
                uint3 n = rng.NextUInt3(1, (uint)int.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.addsaturated(x[j], (int)(n[j] / 2)) == (int)(x[j] + (int)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int4 x = rng.NextInt4();
                uint4 n = (uint)(1 << i);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (int)(n[j] / 2)), (int)(n[j] - 1)) == (int)((int)(x[j] + (int)(n[j] / 2)) - (int)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                int4 x = rng.NextInt4(0, int.MaxValue);
                uint4 n = rng.NextUInt4(1, (uint)int.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.addsaturated(x[j], (int)(n[j] / 2)) == (int)(x[j] + (int)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int8 x = rng.NextInt8();
                uint8 n = (uint)(1 << i);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (int)(n[j] / 2)), (int)(n[j] - 1)) == (int)((int)(x[j] + (int)(n[j] / 2)) - (int)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 32; i++)
            {
                int8 x = rng.NextInt8(0, int.MaxValue);
                uint8 n = rng.NextUInt8(1, (uint)int.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.addsaturated(x[j], (int)(n[j] / 2)) == (int)(x[j] + (int)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong x = rng.NextULong();
                ulong n = 1ul << i;

                if (maxmath.subsaturated(maxmath.addsaturated(x, (ulong)(n / 2)), (ulong)(n - 1)) == (ulong)((ulong)(x + (ulong)(n / 2)) - (ulong)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 n = 1ul << i;

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ulong)(n[j] / 2)), (ulong)(n[j] - 1)) == (ulong)((ulong)(x[j] + (ulong)(n[j] / 2)) - (ulong)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();
                ulong3 n = 1ul << i;

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ulong)(n[j] / 2)), (ulong)(n[j] - 1)) == (ulong)((ulong)(x[j] + (ulong)(n[j] / 2)) - (ulong)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();
                ulong4 n = 1ul << i;

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (ulong)(n[j] / 2)), (ulong)(n[j] - 1)) == (ulong)((ulong)(x[j] + (ulong)(n[j] / 2)) - (ulong)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long x = rng.NextLong();
                ulong n = 1ul << i;

                if (maxmath.subsaturated(maxmath.addsaturated(x, (long)(n / 2)), (long)(n - 1)) == (long)((long)(x + (long)(n / 2)) - (long)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }

            for (int i = 0; i < 64; i++)
            {
                long x = rng.NextLong(0, long.MaxValue);
                ulong n = rng.NextULong(1, (ulong)long.MaxValue);

                if (maxmath.addsaturated(x, (long)(n / 2)) == (long)(x + (long)(n / 2)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.ZeroOrGreater));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();
                ulong2 n = 1ul << i;

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (long)(n[j] / 2)), (long)(n[j] - 1)) == (long)((long)(x[j] + (long)(n[j] / 2)) - (long)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2(0, long.MaxValue);
                ulong2 n = rng.NextULong2(1, (ulong)long.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.addsaturated(x[j], (long)(n[j] / 2)) == (long)(x[j] + (long)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3();
                ulong3 n = 1ul << i;

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (long)(n[j] / 2)), (long)(n[j] - 1)) == (long)((long)(x[j] + (long)(n[j] / 2)) - (long)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 64; i++)
            {
                long3 x = rng.NextLong3(0, long.MaxValue);
                ulong3 n = rng.NextULong3(1, (ulong)long.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.addsaturated(x[j], (long)(n[j] / 2)) == (long)(x[j] + (long)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4();
                ulong4 n = 1ul << i;

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.subsaturated(maxmath.addsaturated(x[j], (long)(n[j] / 2)), (long)(n[j] - 1)) == (long)((long)(x[j] + (long)(n[j] / 2)) - (long)(n[j] - 1)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.Unsafe0)[j]);
                    }
                }
            }

            for (int i = 0; i < 64; i++)
            {
                long4 x = rng.NextLong4(0, long.MaxValue);
                ulong4 n = rng.NextULong4(1, (ulong)long.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.addsaturated(x[j], (long)(n[j] / 2)) == (long)(x[j] + (long)(n[j] / 2)))
                    {
                        Assert.AreEqual(maxmath.roundmultiple(x, n)[j], maxmath.roundmultiple(x, n, Promise.ZeroOrGreater)[j]);
                    }
                }
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 128; i++)
            {
                UInt128 x = rng.NextUInt128();
                UInt128 n = (UInt128)1 << i;

                if (maxmath.subsaturated(maxmath.addsaturated(x, (UInt128)(n / 2)), (UInt128)(n - 1)) == (UInt128)((UInt128)(x + (UInt128)(n / 2)) - (UInt128)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 128; i++)
            {
                Int128 x = rng.NextInt128();
                UInt128 n = (UInt128)1 << i;

                if (maxmath.subsaturated(maxmath.addsaturated(x, (Int128)(n / 2)), (Int128)(n - 1)) == (Int128)((Int128)(x + (Int128)(n / 2)) - (Int128)(n - 1)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.Unsafe0));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                Int128 x = rng.NextInt128(0, Int128.MaxValue);
                UInt128 n = rng.NextUInt128(1, (UInt128)Int128.MaxValue);

                if (maxmath.addsaturated(x, (Int128)(n / 2)) == (Int128)(x + (Int128)(n / 2)))
                {
                    Assert.AreEqual(maxmath.roundmultiple(x, n), maxmath.roundmultiple(x, n, Promise.ZeroOrGreater));
                }
            }
        }
    }
}
