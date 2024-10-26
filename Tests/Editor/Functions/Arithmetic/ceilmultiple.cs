using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_ceilmultiple
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte x = rng.NextByte();
                byte n = rng.NextByte(1, byte.MaxValue);

                byte rounded = maxmath.ceilmultiple(x, n);

                if ((byte)(x + n) == maxmath.addsaturated(x, (byte)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 x = rng.NextByte2();
                byte2 n = rng.NextByte2(1, byte.MaxValue);

                byte2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((byte)(x[j] + n[j]) == maxmath.addsaturated(x[j], (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 x = rng.NextByte3();
                byte3 n = rng.NextByte3(1, byte.MaxValue);

                byte3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((byte)(x[j] + n[j]) == maxmath.addsaturated(x[j], (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 x = rng.NextByte4();
                byte4 n = rng.NextByte4(1, byte.MaxValue);

                byte4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((byte)(x[j] + n[j]) == maxmath.addsaturated(x[j], (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 x = rng.NextByte8();
                byte8 n = rng.NextByte8(1, byte.MaxValue);

                byte8 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((byte)(x[j] + n[j]) == maxmath.addsaturated(x[j], (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 x = rng.NextByte16();
                byte16 n = rng.NextByte16(1, byte.MaxValue);

                byte16 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((byte)(x[j] + n[j]) == maxmath.addsaturated(x[j], (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 x = rng.NextByte32();
                byte32 n = rng.NextByte32(1, byte.MaxValue);

                byte32 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 32; j++)
                {
                    if ((byte)(x[j] + n[j]) == maxmath.addsaturated(x[j], (byte)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                sbyte x = rng.NextSByte();
                byte n = rng.NextByte(1, (byte)sbyte.MaxValue);

                sbyte rounded = maxmath.ceilmultiple(x, n);

                if ((sbyte)(x - (n - 1)) == maxmath.addsaturated(x, (sbyte)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 x = rng.NextSByte2();
                byte2 n = rng.NextByte2(1, (byte)sbyte.MaxValue);

                sbyte2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((sbyte)(x - ((sbyte2)n - 1))[j] == maxmath.addsaturated(x[j], (sbyte)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 x = rng.NextSByte3();
                byte3 n = rng.NextByte3(1, (byte)sbyte.MaxValue);

                sbyte3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((sbyte)(x - ((sbyte3)n - 1))[j] == maxmath.addsaturated(x[j], (sbyte)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 x = rng.NextSByte4();
                byte4 n = rng.NextByte4(1, (byte)sbyte.MaxValue);

                sbyte4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((sbyte)(x - ((sbyte4)n - 1))[j] == maxmath.addsaturated(x[j], (sbyte)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 x = rng.NextSByte8();
                byte8 n = rng.NextByte8(1, (byte)sbyte.MaxValue);

                sbyte8 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((sbyte)(x - ((sbyte8)n - 1))[j] == maxmath.addsaturated(x[j], (sbyte)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 x = rng.NextSByte16();
                byte16 n = rng.NextByte16(1, (byte)sbyte.MaxValue);

                sbyte16 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((sbyte)(x - ((sbyte16)n - 1))[j] == maxmath.addsaturated(x[j], (sbyte)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte32 x = rng.NextSByte32();
                byte32 n = rng.NextByte32(1, (byte)sbyte.MaxValue);

                sbyte32 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 32; j++)
                {
                    if ((sbyte)(x - ((sbyte32)n - 1))[j] == maxmath.addsaturated(x[j], (sbyte)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort x = rng.NextUShort();
                ushort n = rng.NextUShort(1, ushort.MaxValue);

                ushort rounded = maxmath.ceilmultiple(x, n);

                if ((ushort)(x + n) == maxmath.addsaturated(x, (ushort)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 n = rng.NextUShort2(1, ushort.MaxValue);

                ushort2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((ushort)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 n = rng.NextUShort3(1, ushort.MaxValue);

                ushort3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((ushort)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 n = rng.NextUShort4(1, ushort.MaxValue);

                ushort4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((ushort)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 x = rng.NextUShort8();
                ushort8 n = rng.NextUShort8(1, ushort.MaxValue);

                ushort8 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((ushort)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 x = rng.NextUShort16();
                ushort16 n = rng.NextUShort16(1, ushort.MaxValue);

                ushort16 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((ushort)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ushort)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short x = rng.NextShort();
                ushort n = rng.NextUShort(1, (ushort)short.MaxValue);

                short rounded = maxmath.ceilmultiple(x, n);

                if ((short)(x - (n - 1)) == maxmath.addsaturated(x, (short)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short2 x = rng.NextShort2();
                ushort2 n = rng.NextUShort2(1, (ushort)short.MaxValue);

                short2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((short)(x - ((short2)n - 1))[j] == maxmath.addsaturated(x[j], (short)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short3 x = rng.NextShort3();
                ushort3 n = rng.NextUShort3(1, (ushort)short.MaxValue);

                short3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((short)(x - ((short3)n - 1))[j] == maxmath.addsaturated(x[j], (short)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short4 x = rng.NextShort4();
                ushort4 n = rng.NextUShort4(1, (ushort)short.MaxValue);

                short4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((short)(x - ((short4)n - 1))[j] == maxmath.addsaturated(x[j], (short)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short8 x = rng.NextShort8();
                ushort8 n = rng.NextUShort8(1, (ushort)short.MaxValue);

                short8 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((short)(x - ((short8)n - 1))[j] == maxmath.addsaturated(x[j], (short)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short16 x = rng.NextShort16();
                ushort16 n = rng.NextUShort16(1, (ushort)short.MaxValue);

                short16 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((short)(x - ((short16)n - 1))[j] == maxmath.addsaturated(x[j], (short)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                uint n = rng.NextUInt(1, uint.MaxValue);

                uint rounded = maxmath.ceilmultiple(x, n);

                if ((uint)(x + n) == maxmath.addsaturated(x, (uint)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
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
                uint2 n = rng.NextUInt2(1, uint.MaxValue);

                uint2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((uint)(x[j] + n[j]) == maxmath.addsaturated(x[j], (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                uint3 n = rng.NextUInt3(1, uint.MaxValue);

                uint3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((uint)(x[j] + n[j]) == maxmath.addsaturated(x[j], (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                uint4 n = rng.NextUInt4(1, uint.MaxValue);

                uint4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((uint)(x[j] + n[j]) == maxmath.addsaturated(x[j], (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                uint8 n = rng.NextUInt8(1, uint.MaxValue);

                uint8 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((uint)(x[j] + n[j]) == maxmath.addsaturated(x[j], (uint)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int x = rng.NextInt();
                uint n = rng.NextUInt(1, (uint)int.MaxValue);

                int rounded = maxmath.ceilmultiple(x, n);

                if ((int)(x - (n - 1)) == maxmath.addsaturated(x, (int)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
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
                uint2 n = rng.NextUInt2(1, (uint)int.MaxValue);

                int2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((int)(x - ((int2)n - 1))[j] == maxmath.addsaturated(x[j], (int)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                uint3 n = rng.NextUInt3(1, (uint)int.MaxValue);

                int3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((int)(x - ((int3)n - 1))[j] == maxmath.addsaturated(x[j], (int)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                uint4 n = rng.NextUInt4(1, (uint)int.MaxValue);

                int4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((int)(x - ((int4)n - 1))[j] == maxmath.addsaturated(x[j], (int)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                uint8 n = rng.NextUInt8(1, (uint)int.MaxValue);

                int8 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((int)(x - ((int8)n - 1))[j] == maxmath.addsaturated(x[j], (int)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong x = rng.NextULong();
                ulong n = rng.NextULong(1, ulong.MaxValue);

                ulong rounded = maxmath.ceilmultiple(x, n);

                if ((ulong)(x + n) == maxmath.addsaturated(x, (ulong)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 n = rng.NextULong2(1, ulong.MaxValue);

                ulong2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((ulong)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ulong)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 x = rng.NextULong3();
                ulong3 n = rng.NextULong3(1, ulong.MaxValue);

                ulong3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((ulong)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ulong)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 x = rng.NextULong4();
                ulong4 n = rng.NextULong4(1, ulong.MaxValue);

                ulong4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((ulong)(x[j] + n[j]) == maxmath.addsaturated(x[j], (ulong)(n[j] - 1)))
                    {
                        Assert.AreEqual(0, rounded[j] % n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
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
                ulong n = rng.NextULong(1, (ulong)long.MaxValue);

                long rounded = maxmath.ceilmultiple(x, n);

                if ((long)(x - (long)(n - 1)) == maxmath.addsaturated(x, (long)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % (long)n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long2 x = rng.NextLong2();
                ulong2 n = rng.NextULong2(1, (ulong)long.MaxValue);

                long2 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((long)(x - ((long2)n - 1))[j] == maxmath.addsaturated(x[j], (long)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % (long)n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long3 x = rng.NextLong3();
                ulong3 n = rng.NextULong3(1, (ulong)long.MaxValue);

                long3 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((long)(x - ((long3)n - 1))[j] == maxmath.addsaturated(x[j], (long)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % (long)n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long4 x = rng.NextLong4();
                ulong4 n = rng.NextULong4(1, (ulong)long.MaxValue);

                long4 rounded = maxmath.ceilmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((long)(x - ((long4)n - 1))[j] == maxmath.addsaturated(x[j], (long)(n - 1)[j]))
                    {
                        Assert.AreEqual(0, rounded[j] % (long)n[j]);

                        if (rounded[j] != x[j])
                        {
                            Assert.IsTrue(rounded[j] > x[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 x = rng.NextUInt128();
                UInt128 n = rng.NextUInt128(1, UInt128.MaxValue);

                UInt128 rounded = maxmath.ceilmultiple(x, n);

                if ((UInt128)(x + n) == maxmath.addsaturated(x, (UInt128)(n - 1)))
                {
                    Assert.AreEqual(0, rounded % n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                Int128 x = rng.NextInt128();
                UInt128 n = rng.NextUInt128(1, (UInt128)Int128.MaxValue);

                Int128 rounded = maxmath.ceilmultiple(x, n);

                if ((Int128)(x - (Int128)(n - 1)) == maxmath.addsaturated(x, (Int128)(n - 1)))
                {
                    Assert.AreEqual((Int128)0, rounded % (Int128)n);

                    if (rounded != x)
                    {
                        Assert.IsTrue(rounded > x);
                    }
                }
            }
        }

    }
}
