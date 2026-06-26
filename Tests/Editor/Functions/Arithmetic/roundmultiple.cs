using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_roundmultiple
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte x = rng.NextByte();
                byte n = rng.NextByte(1, byte.MaxValue);

                byte floor = math.floormultiple(x, n);
                byte ceil  = math.ceilmultiple (x, n);
                byte round = math.roundmultiple(x, n);

                if ((byte)(x + n) == math.addsaturated(x, n) && (byte)(x - n) == math.subsaturated(x, n))
                {
                    if ((byte)(ceil - x) > (byte)(x - floor))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                byte2 floor = math.floormultiple(x, n);
                byte2 ceil  = math.ceilmultiple (x, n);
                byte2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((byte)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (byte)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((byte)(ceil[j] - x[j]) > (byte)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                byte3 floor = math.floormultiple(x, n);
                byte3 ceil  = math.ceilmultiple (x, n);
                byte3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((byte)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (byte)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((byte)(ceil[j] - x[j]) > (byte)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                byte4 floor = math.floormultiple(x, n);
                byte4 ceil  = math.ceilmultiple (x, n);
                byte4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((byte)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (byte)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((byte)(ceil[j] - x[j]) > (byte)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                byte8 floor = math.floormultiple(x, n);
                byte8 ceil  = math.ceilmultiple (x, n);
                byte8 round = math.roundmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((byte)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (byte)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((byte)(ceil[j] - x[j]) > (byte)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                byte16 floor = math.floormultiple(x, n);
                byte16 ceil  = math.ceilmultiple (x, n);
                byte16 round = math.roundmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((byte)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (byte)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((byte)(ceil[j] - x[j]) > (byte)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                byte32 floor = math.floormultiple(x, n);
                byte32 ceil  = math.ceilmultiple (x, n);
                byte32 round = math.roundmultiple(x, n);

                for (int j = 0; j < 32; j++)
                {
                    if ((byte)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (byte)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((byte)(ceil[j] - x[j]) > (byte)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte x = rng.NextSByte();
                byte n = rng.NextByte(1, (byte)sbyte.MaxValue);

                sbyte floor = math.floormultiple(x, n);
                sbyte ceil  = math.ceilmultiple (x, n);
                sbyte round = math.roundmultiple(x, n);

                if ((sbyte)(x + (sbyte)n) == math.addsaturated(x, (sbyte)n) && (sbyte)(x - (sbyte)n) == math.subsaturated(x, (sbyte)n))
                {
                    if ((byte)math.abs(math.abs(ceil) - math.abs(x)) > (byte)math.abs(math.abs(x) - math.abs(floor)))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                sbyte2 floor = math.floormultiple(x, n);
                sbyte2 ceil  = math.ceilmultiple (x, n);
                sbyte2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((sbyte)(x[j] + (sbyte)n[j]) == math.addsaturated(x, (sbyte2)n)[j] && (sbyte)(x[j] - (sbyte)n[j]) == math.subsaturated(x, (sbyte2)n)[j])
                    {
                        if ((byte)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (byte)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                sbyte3 floor = math.floormultiple(x, n);
                sbyte3 ceil  = math.ceilmultiple (x, n);
                sbyte3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((sbyte)(x[j] + (sbyte)n[j]) == math.addsaturated(x, (sbyte3)n)[j] && (sbyte)(x[j] - (sbyte)n[j]) == math.subsaturated(x, (sbyte3)n)[j])
                    {
                        if ((byte)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (byte)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                sbyte4 floor = math.floormultiple(x, n);
                sbyte4 ceil  = math.ceilmultiple (x, n);
                sbyte4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((sbyte)(x[j] + (sbyte)n[j]) == math.addsaturated(x, (sbyte4)n)[j] && (sbyte)(x[j] - (sbyte)n[j]) == math.subsaturated(x, (sbyte4)n)[j])
                    {
                        if ((byte)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (byte)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                sbyte8 floor = math.floormultiple(x, n);
                sbyte8 ceil  = math.ceilmultiple (x, n);
                sbyte8 round = math.roundmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((sbyte)(x[j] + (sbyte)n[j]) == math.addsaturated(x, (sbyte8)n)[j] && (sbyte)(x[j] - (sbyte)n[j]) == math.subsaturated(x, (sbyte8)n)[j])
                    {
                        if ((byte)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (byte)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                sbyte16 floor = math.floormultiple(x, n);
                sbyte16 ceil  = math.ceilmultiple (x, n);
                sbyte16 round = math.roundmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((sbyte)(x[j] + (sbyte)n[j]) == math.addsaturated(x, (sbyte16)n)[j] && (sbyte)(x[j] - (sbyte)n[j]) == math.subsaturated(x, (sbyte16)n)[j])
                    {
                        if ((byte)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (byte)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                sbyte32 floor = math.floormultiple(x, n);
                sbyte32 ceil  = math.ceilmultiple (x, n);
                sbyte32 round = math.roundmultiple(x, n);

                for (int j = 0; j < 32; j++)
                {
                    if ((sbyte)(x[j] + (sbyte)n[j]) == math.addsaturated(x, (sbyte32)n)[j] && (sbyte)(x[j] - (sbyte)n[j]) == math.subsaturated(x, (sbyte32)n)[j])
                    {
                        if ((byte)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (byte)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ushort floor = math.floormultiple(x, n);
                ushort ceil  = math.ceilmultiple (x, n);
                ushort round = math.roundmultiple(x, n);

                if ((ushort)(x + n) == math.addsaturated(x, n) && (ushort)(x - n) == math.subsaturated(x, n))
                {
                    if ((ushort)(ceil - x) > (ushort)(x - floor))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                ushort2 floor = math.floormultiple(x, n);
                ushort2 ceil  = math.ceilmultiple (x, n);
                ushort2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((ushort)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ushort)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ushort)(ceil[j] - x[j]) > (ushort)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ushort3 floor = math.floormultiple(x, n);
                ushort3 ceil  = math.ceilmultiple (x, n);
                ushort3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((ushort)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ushort)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ushort)(ceil[j] - x[j]) > (ushort)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ushort4 floor = math.floormultiple(x, n);
                ushort4 ceil  = math.ceilmultiple (x, n);
                ushort4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((ushort)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ushort)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ushort)(ceil[j] - x[j]) > (ushort)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ushort8 floor = math.floormultiple(x, n);
                ushort8 ceil  = math.ceilmultiple (x, n);
                ushort8 round = math.roundmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((ushort)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ushort)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ushort)(ceil[j] - x[j]) > (ushort)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ushort16 floor = math.floormultiple(x, n);
                ushort16 ceil  = math.ceilmultiple (x, n);
                ushort16 round = math.roundmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((ushort)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ushort)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ushort)(ceil[j] - x[j]) > (ushort)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short x = rng.NextShort();
                ushort n = rng.NextUShort(1, (ushort)short.MaxValue);

                short floor = math.floormultiple(x, n);
                short ceil  = math.ceilmultiple (x, n);
                short round = math.roundmultiple(x, n);

                if ((short)(x + (short)n) == math.addsaturated(x, (short)n) && (short)(x - (short)n) == math.subsaturated(x, (short)n))
                {
                    if ((ushort)math.abs(math.abs(ceil) - math.abs(x)) > (ushort)math.abs(math.abs(x) - math.abs(floor)))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                short2 floor = math.floormultiple(x, n);
                short2 ceil  = math.ceilmultiple (x, n);
                short2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((short)(x[j] + (short)n[j]) == math.addsaturated(x, (short2)n)[j] && (short)(x[j] - (short)n[j]) == math.subsaturated(x, (short2)n)[j])
                    {
                        if ((ushort)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ushort)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                short3 floor = math.floormultiple(x, n);
                short3 ceil  = math.ceilmultiple (x, n);
                short3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((short)(x[j] + (short)n[j]) == math.addsaturated(x, (short3)n)[j] && (short)(x[j] - (short)n[j]) == math.subsaturated(x, (short3)n)[j])
                    {
                        if ((ushort)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ushort)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                short4 floor = math.floormultiple(x, n);
                short4 ceil  = math.ceilmultiple (x, n);
                short4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((short)(x[j] + (short)n[j]) == math.addsaturated(x, (short4)n)[j] && (short)(x[j] - (short)n[j]) == math.subsaturated(x, (short4)n)[j])
                    {
                        if ((ushort)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ushort)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                short8 floor = math.floormultiple(x, n);
                short8 ceil  = math.ceilmultiple (x, n);
                short8 round = math.roundmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((short)(x[j] + (short)n[j]) == math.addsaturated(x, (short8)n)[j] && (short)(x[j] - (short)n[j]) == math.subsaturated(x, (short8)n)[j])
                    {
                        if ((ushort)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ushort)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                short16 floor = math.floormultiple(x, n);
                short16 ceil  = math.ceilmultiple (x, n);
                short16 round = math.roundmultiple(x, n);

                for (int j = 0; j < 16; j++)
                {
                    if ((short)(x[j] + (short)n[j]) == math.addsaturated(x, (short16)n)[j] && (short)(x[j] - (short)n[j]) == math.subsaturated(x, (short16)n)[j])
                    {
                        if ((ushort)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ushort)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                uint floor = math.floormultiple(x, n);
                uint ceil  = math.ceilmultiple (x, n);
                uint round = math.roundmultiple(x, n);

                if ((uint)(x + n) == math.addsaturated(x, n) && (uint)(x - n) == math.subsaturated(x, n))
                {
                    if ((uint)(ceil - x) > (uint)(x - floor))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                uint2 floor = math.floormultiple(x, n);
                uint2 ceil  = math.ceilmultiple (x, n);
                uint2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((uint)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (uint)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((uint)(ceil[j] - x[j]) > (uint)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                uint3 floor = math.floormultiple(x, n);
                uint3 ceil  = math.ceilmultiple (x, n);
                uint3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((uint)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (uint)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((uint)(ceil[j] - x[j]) > (uint)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                uint4 floor = math.floormultiple(x, n);
                uint4 ceil  = math.ceilmultiple (x, n);
                uint4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((uint)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (uint)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((uint)(ceil[j] - x[j]) > (uint)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                uint8 floor = math.floormultiple(x, n);
                uint8 ceil  = math.ceilmultiple (x, n);
                uint8 round = math.roundmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((uint)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (uint)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((uint)(ceil[j] - x[j]) > (uint)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
                        }
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
                uint n = rng.NextUInt(1, (uint)int.MaxValue);

                int floor = math.floormultiple(x, n);
                int ceil  = math.ceilmultiple (x, n);
                int round = math.roundmultiple(x, n);

                if ((int)(x + (int)n) == math.addsaturated(x, (int)n) && (int)(x - (int)n) == math.subsaturated(x, (int)n))
                {
                    if ((uint)math.abs(math.abs(ceil) - math.abs(x)) > (uint)math.abs(math.abs(x) - math.abs(floor)))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                int2 floor = math.floormultiple(x, n);
                int2 ceil  = math.ceilmultiple (x, n);
                int2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((int)(x[j] + (int)n[j]) == math.addsaturated(x, (int2)n)[j] && (int)(x[j] - (int)n[j]) == math.subsaturated(x, (int2)n)[j])
                    {
                        if ((uint)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (uint)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                int3 floor = math.floormultiple(x, n);
                int3 ceil  = math.ceilmultiple (x, n);
                int3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((int)(x[j] + (int)n[j]) == math.addsaturated(x, (int3)n)[j] && (int)(x[j] - (int)n[j]) == math.subsaturated(x, (int3)n)[j])
                    {
                        if ((uint)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (uint)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                int4 floor = math.floormultiple(x, n);
                int4 ceil  = math.ceilmultiple (x, n);
                int4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((int)(x[j] + (int)n[j]) == math.addsaturated(x, (int4)n)[j] && (int)(x[j] - (int)n[j]) == math.subsaturated(x, (int4)n)[j])
                    {
                        if ((uint)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (uint)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                int8 floor = math.floormultiple(x, n);
                int8 ceil  = math.ceilmultiple (x, n);
                int8 round = math.roundmultiple(x, n);

                for (int j = 0; j < 8; j++)
                {
                    if ((int)(x[j] + (int)n[j]) == math.addsaturated(x, (int8)n)[j] && (int)(x[j] - (int)n[j]) == math.subsaturated(x, (int8)n)[j])
                    {
                        if ((uint)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (uint)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ulong floor = math.floormultiple(x, n);
                ulong ceil  = math.ceilmultiple (x, n);
                ulong round = math.roundmultiple(x, n);

                if ((ulong)(x + n) == math.addsaturated(x, n) && (ulong)(x - n) == math.subsaturated(x, n))
                {
                    if ((ulong)(ceil - x) > (ulong)(x - floor))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                ulong2 floor = math.floormultiple(x, n);
                ulong2 ceil  = math.ceilmultiple (x, n);
                ulong2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((ulong)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ulong)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ulong)(ceil[j] - x[j]) > (ulong)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ulong3 floor = math.floormultiple(x, n);
                ulong3 ceil  = math.ceilmultiple (x, n);
                ulong3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((ulong)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ulong)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ulong)(ceil[j] - x[j]) > (ulong)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                ulong4 floor = math.floormultiple(x, n);
                ulong4 ceil  = math.ceilmultiple (x, n);
                ulong4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((ulong)(x[j] + n[j]) == math.addsaturated(x, n)[j] && (ulong)(x[j] - n[j]) == math.subsaturated(x, n)[j])
                    {
                        if ((ulong)(ceil[j] - x[j]) > (ulong)(x[j] - floor[j]))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
                        }
                    }
                }
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long x = rng.NextLong();
                ulong n = rng.NextULong(1, (ulong)long.MaxValue);

                long floor = math.floormultiple(x, n);
                long ceil  = math.ceilmultiple (x, n);
                long round = math.roundmultiple(x, n);

                if ((long)(x + (long)n) == math.addsaturated(x, (long)n) && (long)(x - (long)n) == math.subsaturated(x, (long)n))
                {
                    if ((ulong)math.abs(math.abs(ceil) - math.abs(x)) > (ulong)math.abs(math.abs(x) - math.abs(floor)))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
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

                long2 floor = math.floormultiple(x, n);
                long2 ceil  = math.ceilmultiple (x, n);
                long2 round = math.roundmultiple(x, n);

                for (int j = 0; j < 2; j++)
                {
                    if ((long)(x[j] + (long)n[j]) == math.addsaturated(x, (long2)n)[j] && (long)(x[j] - (long)n[j]) == math.subsaturated(x, (long2)n)[j])
                    {
                        if ((ulong)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ulong)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                long3 floor = math.floormultiple(x, n);
                long3 ceil  = math.ceilmultiple (x, n);
                long3 round = math.roundmultiple(x, n);

                for (int j = 0; j < 3; j++)
                {
                    if ((long)(x[j] + (long)n[j]) == math.addsaturated(x, (long3)n)[j] && (long)(x[j] - (long)n[j]) == math.subsaturated(x, (long3)n)[j])
                    {
                        if ((ulong)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ulong)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                long4 floor = math.floormultiple(x, n);
                long4 ceil  = math.ceilmultiple (x, n);
                long4 round = math.roundmultiple(x, n);

                for (int j = 0; j < 4; j++)
                {
                    if ((long)(x[j] + (long)n[j]) == math.addsaturated(x, (long4)n)[j] && (long)(x[j] - (long)n[j]) == math.subsaturated(x, (long4)n)[j])
                    {
                        if ((ulong)math.abs(math.abs(ceil[j]) - math.abs(x[j])) > (ulong)math.abs(math.abs(x[j]) - math.abs(floor[j])))
                        {
                            Assert.AreEqual(round[j], floor[j]);
                        }
                        else
                        {
                            Assert.AreEqual(round[j], ceil[j]);
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

                UInt128 floor = math.floormultiple(x, n);
                UInt128 ceil  = math.ceilmultiple (x, n);
                UInt128 round = math.roundmultiple(x, n);

                if ((UInt128)(x + n) == math.addsaturated(x, n) && (UInt128)(x - n) == math.subsaturated(x, n))
                {
                    if ((UInt128)(ceil - x) > (UInt128)(x - floor))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
                    }
                }
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                Int128 x = rng.NextInt128();
                UInt128 n = rng.NextUInt128(1, (UInt128)Int128.MaxValue);

                Int128 floor = math.floormultiple(x, n);
                Int128 ceil  = math.ceilmultiple (x, n);
                Int128 round = math.roundmultiple(x, n);

                if ((Int128)(x + (Int128)n) == math.addsaturated(x, (Int128)n) && (Int128)(x - (Int128)n) == math.subsaturated(x, (Int128)n))
                {
                    if ((UInt128)math.abs(math.abs(ceil) - math.abs(x)) > (UInt128)math.abs(math.abs(x) - math.abs(floor)))
                    {
                        Assert.AreEqual(round, floor);
                    }
                    else
                    {
                        Assert.AreEqual(round, ceil);
                    }
                }
            }
        }

    }
}
