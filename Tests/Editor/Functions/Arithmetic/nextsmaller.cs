using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_nextsmaller
    {
        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            Assert.AreEqual(UInt128.MinValue, math.nextsmaller(UInt128.MinValue));

            for (int i = 0; i < 5; i++)
            {
                UInt128 t = rng.NextUInt128();

                Assert.AreEqual(t == UInt128.MinValue ? UInt128.MinValue : t - 1, math.nextsmaller(t));
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            Assert.AreEqual(Int128.MinValue, math.nextsmaller(Int128.MinValue));

            for (int i = 0; i < 5; i++)
            {
                Int128 t = rng.NextInt128();

                Assert.AreEqual(t == Int128.MinValue ? Int128.MinValue : t - 1, math.nextsmaller(t));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual(byte.MinValue, math.nextsmaller(byte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                byte t = rng.NextByte();

                Assert.AreEqual(t == byte.MinValue ? byte.MinValue : (byte)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte2)byte.MinValue, math.nextsmaller((byte2)byte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                byte2 t = rng.NextByte2();

                Assert.AreEqual(math.select(t - 1, t, t == byte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte3)byte.MinValue, math.nextsmaller((byte3)byte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                byte3 t = rng.NextByte3();

                Assert.AreEqual(math.select(t - 1, t, t == byte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte4)byte.MinValue, math.nextsmaller((byte4)byte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                byte4 t = rng.NextByte4();

                Assert.AreEqual(math.select(t - 1, t, t == byte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte8)byte.MinValue, math.nextsmaller((byte8)byte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                byte8 t = rng.NextByte8();

                Assert.AreEqual(math.select(t - 1, t, t == byte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte16)byte.MinValue, math.nextsmaller((byte16)byte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                byte16 t = rng.NextByte16();

                Assert.AreEqual(math.select(t - 1, t, t == byte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte32)byte.MinValue, math.nextsmaller((byte32)byte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                byte32 t = rng.NextByte32();

                Assert.AreEqual(math.select(t - 1, t, t == byte.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual(sbyte.MinValue, math.nextsmaller(sbyte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte t = rng.NextSByte();

                Assert.AreEqual(t == sbyte.MinValue ? sbyte.MinValue : (sbyte)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte2)sbyte.MinValue, math.nextsmaller((sbyte2)sbyte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte2 t = rng.NextSByte2();

                Assert.AreEqual(math.select(t - 1, t, t == sbyte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte3)sbyte.MinValue, math.nextsmaller((sbyte3)sbyte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte3 t = rng.NextSByte3();

                Assert.AreEqual(math.select(t - 1, t, t == sbyte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte4)sbyte.MinValue, math.nextsmaller((sbyte4)sbyte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte4 t = rng.NextSByte4();

                Assert.AreEqual(math.select(t - 1, t, t == sbyte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte8)sbyte.MinValue, math.nextsmaller((sbyte8)sbyte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte8 t = rng.NextSByte8();

                Assert.AreEqual(math.select(t - 1, t, t == sbyte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte16)sbyte.MinValue, math.nextsmaller((sbyte16)sbyte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte16 t = rng.NextSByte16();

                Assert.AreEqual(math.select(t - 1, t, t == sbyte.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte32)sbyte.MinValue, math.nextsmaller((sbyte32)sbyte.MinValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte32 t = rng.NextSByte32();

                Assert.AreEqual(math.select(t - 1, t, t == sbyte.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual(ushort.MinValue, math.nextsmaller(ushort.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ushort t = rng.NextUShort();

                Assert.AreEqual(t == ushort.MinValue ? ushort.MinValue : (ushort)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort2)ushort.MinValue, math.nextsmaller((ushort2)ushort.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ushort2 t = rng.NextUShort2();

                Assert.AreEqual(math.select(t - 1, t, t == ushort.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort3)ushort.MinValue, math.nextsmaller((ushort3)ushort.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ushort3 t = rng.NextUShort3();

                Assert.AreEqual(math.select(t - 1, t, t == ushort.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort4)ushort.MinValue, math.nextsmaller((ushort4)ushort.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ushort4 t = rng.NextUShort4();

                Assert.AreEqual(math.select(t - 1, t, t == ushort.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort8)ushort.MinValue, math.nextsmaller((ushort8)ushort.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ushort8 t = rng.NextUShort8();

                Assert.AreEqual(math.select(t - 1, t, t == ushort.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort16)ushort.MinValue, math.nextsmaller((ushort16)ushort.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ushort16 t = rng.NextUShort16();

                Assert.AreEqual(math.select(t - 1, t, t == ushort.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual(short.MinValue, math.nextsmaller(short.MinValue));

            for (int i = 0; i < 5; i++)
            {
                short t = rng.NextShort();

                Assert.AreEqual(t == short.MinValue ? short.MinValue : (short)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short2)short.MinValue, math.nextsmaller((short2)short.MinValue));

            for (int i = 0; i < 5; i++)
            {
                short2 t = rng.NextShort2();

                Assert.AreEqual(math.select(t - 1, t, t == short.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short3)short.MinValue, math.nextsmaller((short3)short.MinValue));

            for (int i = 0; i < 5; i++)
            {
                short3 t = rng.NextShort3();

                Assert.AreEqual(math.select(t - 1, t, t == short.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short4)short.MinValue, math.nextsmaller((short4)short.MinValue));

            for (int i = 0; i < 5; i++)
            {
                short4 t = rng.NextShort4();

                Assert.AreEqual(math.select(t - 1, t, t == short.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short8)short.MinValue, math.nextsmaller((short8)short.MinValue));

            for (int i = 0; i < 5; i++)
            {
                short8 t = rng.NextShort8();

                Assert.AreEqual(math.select(t - 1, t, t == short.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short16)short.MinValue, math.nextsmaller((short16)short.MinValue));

            for (int i = 0; i < 5; i++)
            {
                short16 t = rng.NextShort16();

                Assert.AreEqual(math.select(t - 1, t, t == short.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual(uint.MinValue, math.nextsmaller(uint.MinValue));

            for (int i = 0; i < 5; i++)
            {
                uint t = rng.NextUInt();

                Assert.AreEqual(t == uint.MinValue ? uint.MinValue : (uint)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint2)uint.MinValue, math.nextsmaller((uint2)uint.MinValue));

            for (int i = 0; i < 5; i++)
            {
                uint2 t = rng.NextUInt2();

                Assert.AreEqual(math.select(t - 1, t, t == uint.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint3)uint.MinValue, math.nextsmaller((uint3)uint.MinValue));

            for (int i = 0; i < 5; i++)
            {
                uint3 t = rng.NextUInt3();

                Assert.AreEqual(math.select(t - 1, t, t == uint.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint4)uint.MinValue, math.nextsmaller((uint4)uint.MinValue));

            for (int i = 0; i < 5; i++)
            {
                uint4 t = rng.NextUInt4();

                Assert.AreEqual(math.select(t - 1, t, t == uint.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint8)uint.MinValue, math.nextsmaller((uint8)uint.MinValue));

            for (int i = 0; i < 5; i++)
            {
                uint8 t = rng.NextUInt8();

                Assert.AreEqual(math.select(t - 1, t, t == uint.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual(int.MinValue, math.nextsmaller(int.MinValue));

            for (int i = 0; i < 5; i++)
            {
                int t = rng.NextInt();

                Assert.AreEqual(t == int.MinValue ? int.MinValue : (int)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int2)int.MinValue, math.nextsmaller((int2)int.MinValue));

            for (int i = 0; i < 5; i++)
            {
                int2 t = rng.NextInt2();

                Assert.AreEqual(math.select(t - 1, t, t == int.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int3)int.MinValue, math.nextsmaller((int3)int.MinValue));

            for (int i = 0; i < 5; i++)
            {
                int3 t = rng.NextInt3();

                Assert.AreEqual(math.select(t - 1, t, t == int.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int4)int.MinValue, math.nextsmaller((int4)int.MinValue));

            for (int i = 0; i < 5; i++)
            {
                int4 t = rng.NextInt4();

                Assert.AreEqual(math.select(t - 1, t, t == int.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int8)int.MinValue, math.nextsmaller((int8)int.MinValue));

            for (int i = 0; i < 5; i++)
            {
                int8 t = rng.NextInt8();

                Assert.AreEqual(math.select(t - 1, t, t == int.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual(ulong.MinValue, math.nextsmaller(ulong.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ulong t = rng.NextULong();

                Assert.AreEqual(t == ulong.MinValue ? ulong.MinValue : (ulong)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((ulong2)ulong.MinValue, math.nextsmaller((ulong2)ulong.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ulong2 t = rng.NextULong2();

                Assert.AreEqual(math.select(t - 1, t, t == ulong.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((ulong3)ulong.MinValue, math.nextsmaller((ulong3)ulong.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ulong3 t = rng.NextULong3();

                Assert.AreEqual(math.select(t - 1, t, t == ulong.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((ulong4)ulong.MinValue, math.nextsmaller((ulong4)ulong.MinValue));

            for (int i = 0; i < 5; i++)
            {
                ulong4 t = rng.NextULong4();

                Assert.AreEqual(math.select(t - 1, t, t == ulong.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual(long.MinValue, math.nextsmaller(long.MinValue));

            for (int i = 0; i < 5; i++)
            {
                long t = rng.NextLong();

                Assert.AreEqual(t == long.MinValue ? long.MinValue : (long)(t - 1), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((long2)long.MinValue, math.nextsmaller((long2)long.MinValue));

            for (int i = 0; i < 5; i++)
            {
                long2 t = rng.NextLong2();

                Assert.AreEqual(math.select(t - 1, t, t == long.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((long3)long.MinValue, math.nextsmaller((long3)long.MinValue));

            for (int i = 0; i < 5; i++)
            {
                long3 t = rng.NextLong3();

                Assert.AreEqual(math.select(t - 1, t, t == long.MinValue), math.nextsmaller(t));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((long4)long.MinValue, math.nextsmaller((long4)long.MinValue));

            for (int i = 0; i < 5; i++)
            {
                long4 t = rng.NextLong4();

                Assert.AreEqual(math.select(t - 1, t, t == long.MinValue), math.nextsmaller(t));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            Assert.IsNaN(math.nextsmaller(quarter.NaN));
            Assert.AreEqual(math.nextsmaller((quarter)float.PositiveInfinity), (quarter)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((quarter)float.NegativeInfinity), (quarter)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller(quarter.MinValue), (quarter)float.NegativeInfinity);
            Assert.AreEqual(math.asquarter((byte)0b1000_0001), math.nextsmaller(math.asquarter((byte)0b1000_0000)));
            Assert.AreEqual(math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter f = (quarter)rng.NextFloat(quarter.MinValue / 2, quarter.MaxValue / 2);

                Assert.Less((float)math.nextsmaller(f), (float)f);
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((quarter2)quarter.NaN))));
            Assert.AreEqual(math.nextsmaller((quarter2)(quarter)float.PositiveInfinity), (quarter2)(quarter)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((quarter2)(quarter)float.NegativeInfinity), (quarter2)(quarter)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((quarter2)quarter.MinValue), (quarter2)(quarter)float.NegativeInfinity);
            Assert.AreEqual((quarter2)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter2)math.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter2)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter2)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter2 f = (quarter2)rng.NextFloat2(quarter.MinValue / 2, quarter.MaxValue / 2);

                for (int j = 0; j < 2; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((quarter3)quarter.NaN))));
            Assert.AreEqual(math.nextsmaller((quarter3)(quarter)float.PositiveInfinity), (quarter3)(quarter)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((quarter3)(quarter)float.NegativeInfinity), (quarter3)(quarter)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((quarter3)quarter.MinValue), (quarter3)(quarter)float.NegativeInfinity);
            Assert.AreEqual((quarter3)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter3)math.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter3)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter3)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter3 f = (quarter3)rng.NextFloat3(quarter.MinValue / 2, quarter.MaxValue / 2);

                for (int j = 0; j < 3; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((quarter4)quarter.NaN))));
            Assert.AreEqual(math.nextsmaller((quarter4)(quarter)float.PositiveInfinity), (quarter4)(quarter)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((quarter4)(quarter)float.NegativeInfinity), (quarter4)(quarter)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((quarter4)quarter.MinValue), (quarter4)(quarter)float.NegativeInfinity);
            Assert.AreEqual((quarter4)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter4)math.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter4)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter4)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter4 f = (quarter4)rng.NextFloat4(quarter.MinValue / 2, quarter.MaxValue / 2);

                for (int j = 0; j < 4; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((quarter8)quarter.NaN))));
            Assert.AreEqual(math.nextsmaller((quarter8)(quarter)float.PositiveInfinity), (quarter8)(quarter)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((quarter8)(quarter)float.NegativeInfinity), (quarter8)(quarter)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((quarter8)quarter.MinValue), (quarter8)(quarter)float.NegativeInfinity);
            Assert.AreEqual((quarter8)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter8)math.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter8)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter8)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter8 f = (quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2);

                for (int j = 0; j < 8; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((quarter16)quarter.NaN))));
            Assert.AreEqual(math.nextsmaller((quarter16)(quarter)float.PositiveInfinity), (quarter16)(quarter)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((quarter16)(quarter)float.NegativeInfinity), (quarter16)(quarter)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((quarter16)quarter.MinValue), (quarter16)(quarter)float.NegativeInfinity);
            Assert.AreEqual((quarter16)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter16)math.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter16)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter16)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter16 f = new quarter16((quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2), (quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2));

                for (int j = 0; j < 16; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _quarter32()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((quarter32)quarter.NaN))));
            Assert.AreEqual(math.nextsmaller((quarter32)(quarter)float.PositiveInfinity), (quarter32)(quarter)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((quarter32)(quarter)float.NegativeInfinity), (quarter32)(quarter)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((quarter32)quarter.MinValue), (quarter32)(quarter)float.NegativeInfinity);
            Assert.AreEqual((quarter32)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter32)math.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter32)math.asquarter((byte)0b1000_0001), math.nextsmaller((quarter32)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter32 f = new quarter32((quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2), (quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2), (quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2), (quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2));

                for (int j = 0; j < 32; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            Assert.IsNaN(math.nextsmaller(math.ashalf((ushort)0x7C01)));
            Assert.AreEqual(math.nextsmaller((half)float.PositiveInfinity), (half)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((half)float.NegativeInfinity), (half)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller(half.MinValue), (half)float.NegativeInfinity);
            Assert.AreEqual(math.ashalf((ushort)0x8001), math.nextsmaller(math.ashalf((ushort)0x8000)));
            Assert.AreEqual(math.ashalf((ushort)0x8001), math.nextsmaller((half)0f));

            for (int i = 0; i < 25; i++)
            {
                half f = (half)rng.NextFloat(half.MinValue / 2, half.MaxValue / 2);

                Assert.Less((float)math.nextsmaller(f), (float)f);
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((half2)math.ashalf((ushort)0x7C01)))));
            Assert.AreEqual(math.nextsmaller((half2)(half)float.PositiveInfinity), (half2)(half)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((half2)(half)float.NegativeInfinity), (half2)(half)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((half2)half.MinValue), (half2)(half)float.NegativeInfinity);
            Assert.AreEqual((half2)math.ashalf((ushort)0x8001), math.nextsmaller((half2)math.ashalf((ushort)0x8000)));
            Assert.AreEqual((half2)math.ashalf((ushort)0x8001), math.nextsmaller((half2)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half2 f = (half2)rng.NextFloat2(half.MinValue / 2, half.MaxValue / 2);

                for (int j = 0; j < 2; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((half3)math.ashalf((ushort)0x7C01)))));
            Assert.AreEqual(math.nextsmaller((half3)(half)float.PositiveInfinity), (half3)(half)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((half3)(half)float.NegativeInfinity), (half3)(half)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((half3)half.MinValue), (half3)(half)float.NegativeInfinity);
            Assert.AreEqual((half3)math.ashalf((ushort)0x8001), math.nextsmaller((half3)math.ashalf((ushort)0x8000)));
            Assert.AreEqual((half3)math.ashalf((ushort)0x8001), math.nextsmaller((half3)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half3 f = (half3)rng.NextFloat3(half.MinValue / 2, half.MaxValue / 2);

                for (int j = 0; j < 3; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((half4)math.ashalf((ushort)0x7C01)))));
            Assert.AreEqual(math.nextsmaller((half4)(half)float.PositiveInfinity), (half4)(half)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((half4)(half)float.NegativeInfinity), (half4)(half)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((half4)half.MinValue), (half4)(half)float.NegativeInfinity);
            Assert.AreEqual((half4)math.ashalf((ushort)0x8001), math.nextsmaller((half4)math.ashalf((ushort)0x8000)));
            Assert.AreEqual((half4)math.ashalf((ushort)0x8001), math.nextsmaller((half4)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half4 f = (half4)rng.NextFloat4(half.MinValue / 2, half.MaxValue / 2);

                for (int j = 0; j < 4; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((half8)math.ashalf((ushort)0x7C01)))));
            Assert.AreEqual(math.nextsmaller((half8)(half)float.PositiveInfinity), (half8)(half)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((half8)(half)float.NegativeInfinity), (half8)(half)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((half8)half.MinValue), (half8)(half)float.NegativeInfinity);
            Assert.AreEqual((half8)math.ashalf((ushort)0x8001), math.nextsmaller((half8)math.ashalf((ushort)0x8000)));
            Assert.AreEqual((half8)math.ashalf((ushort)0x8001), math.nextsmaller((half8)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half8 f = (half8)rng.NextFloat8(half.MinValue / 2, half.MaxValue / 2);

                for (int j = 0; j < 8; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(math.all(math.isnan(math.nextsmaller((half16)math.ashalf((ushort)0x7C01)))));
            Assert.AreEqual(math.nextsmaller((half16)(half)float.PositiveInfinity), (half16)(half)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((half16)(half)float.NegativeInfinity), (half16)(half)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((half16)half.MinValue), (half16)(half)float.NegativeInfinity);
            Assert.AreEqual((half16)math.ashalf((ushort)0x8001), math.nextsmaller((half16)math.ashalf((ushort)0x8000)));
            Assert.AreEqual((half16)math.ashalf((ushort)0x8001), math.nextsmaller((half16)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half16 f = new half16((half8)rng.NextFloat8(half.MinValue / 2, half.MaxValue / 2), (half8)rng.NextFloat8(half.MinValue / 2, half.MaxValue / 2));

                for (int j = 0; j < 16; j++)
                {
                    Assert.Less((float)math.nextsmaller(f)[j], (float)f[j]);
                }
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            Assert.IsNaN(math.nextsmaller(float.NaN));
            Assert.AreEqual(math.nextsmaller(float.PositiveInfinity), float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller(float.NegativeInfinity), float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller(float.MinValue), float.NegativeInfinity);
            Assert.AreEqual((-float.Epsilon), math.nextsmaller(math.asfloat(0x8000_0000)));
            Assert.AreEqual((-float.Epsilon), math.nextsmaller(0f));

            for (int i = 0; i < 25; i++)
            {
                float f = rng.NextFloat(float.MinValue / 2, float.MaxValue / 2);

                Assert.Less(math.nextsmaller(f), f);
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            Assert.IsNaN(math.nextsmaller((float2)float.NaN).x);
            Assert.IsNaN(math.nextsmaller((float2)float.NaN).y);
            Assert.AreEqual(math.nextsmaller((float2)float.PositiveInfinity), (float2)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((float2)float.NegativeInfinity), (float2)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((float2)float.MinValue), (float2)float.NegativeInfinity);
            Assert.AreEqual((float2)(-float.Epsilon), math.nextsmaller((float2)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float2)(-float.Epsilon), math.nextsmaller((float2)0f));

            for (int i = 0; i < 25; i++)
            {
                float2 f = rng.NextFloat2(float.MinValue / 2, float.MaxValue / 2);

                Assert.Less(math.nextsmaller(f).x, f.x);
                Assert.Less(math.nextsmaller(f).y, f.y);
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            Assert.IsNaN(math.nextsmaller((float3)float.NaN).x);
            Assert.IsNaN(math.nextsmaller((float3)float.NaN).y);
            Assert.IsNaN(math.nextsmaller((float3)float.NaN).z);
            Assert.AreEqual(math.nextsmaller((float3)float.PositiveInfinity), (float3)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((float3)float.NegativeInfinity), (float3)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((float3)float.MinValue), (float3)float.NegativeInfinity);
            Assert.AreEqual((float3)(-float.Epsilon), math.nextsmaller((float3)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float3)(-float.Epsilon), math.nextsmaller((float3)0f));

            for (int i = 0; i < 25; i++)
            {
                float3 f = rng.NextFloat3(float.MinValue / 2, float.MaxValue / 2);

                Assert.Less(math.nextsmaller(f).x, f.x);
                Assert.Less(math.nextsmaller(f).y, f.y);
                Assert.Less(math.nextsmaller(f).z, f.z);
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            Assert.IsNaN(math.nextsmaller((float4)float.NaN).x);
            Assert.IsNaN(math.nextsmaller((float4)float.NaN).y);
            Assert.IsNaN(math.nextsmaller((float4)float.NaN).z);
            Assert.IsNaN(math.nextsmaller((float4)float.NaN).w);
            Assert.AreEqual(math.nextsmaller((float4)float.PositiveInfinity), (float4)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((float4)float.NegativeInfinity), (float4)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((float4)float.MinValue), (float4)float.NegativeInfinity);
            Assert.AreEqual((float4)(-float.Epsilon), math.nextsmaller((float4)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float4)(-float.Epsilon), math.nextsmaller((float4)0f));

            for (int i = 0; i < 25; i++)
            {
                float4 f = rng.NextFloat4(float.MinValue / 2, float.MaxValue / 2);

                Assert.Less(math.nextsmaller(f).x, f.x);
                Assert.Less(math.nextsmaller(f).y, f.y);
                Assert.Less(math.nextsmaller(f).z, f.z);
                Assert.Less(math.nextsmaller(f).w, f.w);
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x0);
            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x1);
            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x2);
            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x3);
            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x4);
            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x5);
            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x6);
            Assert.IsNaN(math.nextsmaller((float8)float.NaN).x7);
            Assert.AreEqual(math.nextsmaller((float8)float.PositiveInfinity), (float8)float.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((float8)float.NegativeInfinity), (float8)float.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((float8)float.MinValue), (float8)float.NegativeInfinity);
            Assert.AreEqual((float8)(-float.Epsilon), math.nextsmaller((float8)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float8)(-float.Epsilon), math.nextsmaller((float8)0f));

            for (int i = 0; i < 25; i++)
            {
                float8 f = rng.NextFloat8(float.MinValue / 2, float.MaxValue / 2);

                Assert.Less(math.nextsmaller(f).x0, f.x0);
                Assert.Less(math.nextsmaller(f).x1, f.x1);
                Assert.Less(math.nextsmaller(f).x2, f.x2);
                Assert.Less(math.nextsmaller(f).x3, f.x3);
                Assert.Less(math.nextsmaller(f).x4, f.x4);
                Assert.Less(math.nextsmaller(f).x5, f.x5);
                Assert.Less(math.nextsmaller(f).x6, f.x6);
                Assert.Less(math.nextsmaller(f).x7, f.x7);
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            Assert.IsNaN(math.nextsmaller(double.NaN));
            Assert.AreEqual(math.nextsmaller(double.PositiveInfinity), double.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller(double.NegativeInfinity), double.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller(double.MinValue), double.NegativeInfinity);
            Assert.AreEqual((-double.Epsilon), math.nextsmaller(math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual((-double.Epsilon), math.nextsmaller(0d));

            for (int i = 0; i < 25; i++)
            {
                double f = rng.NextDouble(double.MinValue / 2, double.MaxValue / 2);

                Assert.Less(math.nextsmaller(f), f);
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            Assert.IsNaN(math.nextsmaller((double2)double.NaN).x);
            Assert.IsNaN(math.nextsmaller((double2)double.NaN).y);
            Assert.AreEqual(math.nextsmaller((double2)double.PositiveInfinity), (double2)double.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((double2)double.NegativeInfinity), (double2)double.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((double2)double.MinValue), (double2)double.NegativeInfinity);
            Assert.AreEqual((double2)(-double.Epsilon), math.nextsmaller((double2)math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual((double2)(-double.Epsilon), math.nextsmaller((double2)0d));

            for (int i = 0; i < 25; i++)
            {
                double2 f = rng.NextDouble2(double.MinValue / 2, double.MaxValue / 2);

                Assert.Less(math.nextsmaller(f).x, f.x);
                Assert.Less(math.nextsmaller(f).y, f.y);
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            Assert.IsNaN(math.nextsmaller((double3)double.NaN).x);
            Assert.IsNaN(math.nextsmaller((double3)double.NaN).y);
            Assert.IsNaN(math.nextsmaller((double3)double.NaN).z);
            Assert.AreEqual(math.nextsmaller((double3)double.PositiveInfinity), (double3)double.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((double3)double.NegativeInfinity), (double3)double.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((double3)double.MinValue), (double3)double.NegativeInfinity);
            Assert.AreEqual((double3)(-double.Epsilon), math.nextsmaller((double3)math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual((double3)(-double.Epsilon), math.nextsmaller((double3)0d));

            for (int i = 0; i < 25; i++)
            {
                double3 f = rng.NextDouble3(double.MinValue / 2, double.MaxValue / 2);

                Assert.Less(math.nextsmaller(f).x, f.x);
                Assert.Less(math.nextsmaller(f).y, f.y);
                Assert.Less(math.nextsmaller(f).z, f.z);
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            Assert.IsNaN(math.nextsmaller((double4)double.NaN).x);
            Assert.IsNaN(math.nextsmaller((double4)double.NaN).y);
            Assert.IsNaN(math.nextsmaller((double4)double.NaN).z);
            Assert.IsNaN(math.nextsmaller((double4)double.NaN).w);
            Assert.AreEqual(math.nextsmaller((double4)double.PositiveInfinity), (double4)double.PositiveInfinity);
            Assert.AreEqual(math.nextsmaller((double4)double.NegativeInfinity), (double4)double.NegativeInfinity);
            Assert.AreEqual(math.nextsmaller((double4)double.MinValue), (double4)double.NegativeInfinity);
            Assert.AreEqual((double4)(-double.Epsilon), math.nextsmaller((double4)math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual((double4)(-double.Epsilon), math.nextsmaller((double4)0d));

            for (int i = 0; i < 25; i++)
            {
                double4 f = rng.NextDouble4(double.MinValue / 2, double.MaxValue / 2);

                Assert.Less(math.nextsmaller(f).x, f.x);
                Assert.Less(math.nextsmaller(f).y, f.y);
                Assert.Less(math.nextsmaller(f).z, f.z);
                Assert.Less(math.nextsmaller(f).w, f.w);
            }
        }
    }
}
