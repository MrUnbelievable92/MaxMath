using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class nextgreater
    {
        [Test]
        public static void _uint128()
        {
            Random128 rng = Random128.New;

            Assert.AreEqual(UInt128.MaxValue, maxmath.nextgreater(UInt128.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                UInt128 t = rng.NextUInt128();

                Assert.AreEqual(t == UInt128.MaxValue ? UInt128.MaxValue : t + 1, maxmath.nextgreater(t));
            }
        }
        

        [Test]
        public static void _int128()
        {
            Random128 rng = Random128.New;

            Assert.AreEqual(Int128.MaxValue, maxmath.nextgreater(Int128.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                Int128 t = rng.NextInt128();

                Assert.AreEqual(t == Int128.MaxValue ? Int128.MaxValue : t + 1, maxmath.nextgreater(t));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual(byte.MaxValue, maxmath.nextgreater(byte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                byte t = rng.NextByte();

                Assert.AreEqual(t == byte.MaxValue ? byte.MaxValue : (byte)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte2)byte.MaxValue, maxmath.nextgreater((byte2)byte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                byte2 t = rng.NextByte2();

                Assert.AreEqual(maxmath.select(t + 1, t, t == byte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte3)byte.MaxValue, maxmath.nextgreater((byte3)byte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                byte3 t = rng.NextByte3();

                Assert.AreEqual(maxmath.select(t + 1, t, t == byte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte4)byte.MaxValue, maxmath.nextgreater((byte4)byte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                byte4 t = rng.NextByte4();

                Assert.AreEqual(maxmath.select(t + 1, t, t == byte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte8)byte.MaxValue, maxmath.nextgreater((byte8)byte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                byte8 t = rng.NextByte8();

                Assert.AreEqual(maxmath.select(t + 1, t, t == byte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte16)byte.MaxValue, maxmath.nextgreater((byte16)byte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                byte16 t = rng.NextByte16();

                Assert.AreEqual(maxmath.select(t + 1, t, t == byte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((byte32)byte.MaxValue, maxmath.nextgreater((byte32)byte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                byte32 t = rng.NextByte32();

                Assert.AreEqual(maxmath.select(t + 1, t, t == byte.MaxValue), maxmath.nextgreater(t));
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual(sbyte.MaxValue, maxmath.nextgreater(sbyte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte t = rng.NextSByte();

                Assert.AreEqual(t == sbyte.MaxValue ? sbyte.MaxValue : (sbyte)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte2)sbyte.MaxValue, maxmath.nextgreater((sbyte2)sbyte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte2 t = rng.NextSByte2();

                Assert.AreEqual(maxmath.select(t + 1, t, t == sbyte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte3)sbyte.MaxValue, maxmath.nextgreater((sbyte3)sbyte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte3 t = rng.NextSByte3();

                Assert.AreEqual(maxmath.select(t + 1, t, t == sbyte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte4)sbyte.MaxValue, maxmath.nextgreater((sbyte4)sbyte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte4 t = rng.NextSByte4();

                Assert.AreEqual(maxmath.select(t + 1, t, t == sbyte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte8)sbyte.MaxValue, maxmath.nextgreater((sbyte8)sbyte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte8 t = rng.NextSByte8();

                Assert.AreEqual(maxmath.select(t + 1, t, t == sbyte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte16)sbyte.MaxValue, maxmath.nextgreater((sbyte16)sbyte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte16 t = rng.NextSByte16();

                Assert.AreEqual(maxmath.select(t + 1, t, t == sbyte.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            Assert.AreEqual((sbyte32)sbyte.MaxValue, maxmath.nextgreater((sbyte32)sbyte.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                sbyte32 t = rng.NextSByte32();

                Assert.AreEqual(maxmath.select(t + 1, t, t == sbyte.MaxValue), maxmath.nextgreater(t));
            }
        }

        
        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual(ushort.MaxValue, maxmath.nextgreater(ushort.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ushort t = rng.NextUShort();

                Assert.AreEqual(t == ushort.MaxValue ? ushort.MaxValue : (ushort)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort2)ushort.MaxValue, maxmath.nextgreater((ushort2)ushort.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ushort2 t = rng.NextUShort2();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ushort.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort3)ushort.MaxValue, maxmath.nextgreater((ushort3)ushort.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ushort3 t = rng.NextUShort3();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ushort.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort4)ushort.MaxValue, maxmath.nextgreater((ushort4)ushort.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ushort4 t = rng.NextUShort4();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ushort.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort8)ushort.MaxValue, maxmath.nextgreater((ushort8)ushort.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ushort8 t = rng.NextUShort8();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ushort.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((ushort16)ushort.MaxValue, maxmath.nextgreater((ushort16)ushort.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ushort16 t = rng.NextUShort16();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ushort.MaxValue), maxmath.nextgreater(t));
            }
        }

        
        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual(short.MaxValue, maxmath.nextgreater(short.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                short t = rng.NextShort();

                Assert.AreEqual(t == short.MaxValue ? short.MaxValue : (short)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short2)short.MaxValue, maxmath.nextgreater((short2)short.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                short2 t = rng.NextShort2();

                Assert.AreEqual(maxmath.select(t + 1, t, t == short.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short3)short.MaxValue, maxmath.nextgreater((short3)short.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                short3 t = rng.NextShort3();

                Assert.AreEqual(maxmath.select(t + 1, t, t == short.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short4)short.MaxValue, maxmath.nextgreater((short4)short.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                short4 t = rng.NextShort4();

                Assert.AreEqual(maxmath.select(t + 1, t, t == short.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short8)short.MaxValue, maxmath.nextgreater((short8)short.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                short8 t = rng.NextShort8();

                Assert.AreEqual(maxmath.select(t + 1, t, t == short.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            Assert.AreEqual((short16)short.MaxValue, maxmath.nextgreater((short16)short.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                short16 t = rng.NextShort16();

                Assert.AreEqual(maxmath.select(t + 1, t, t == short.MaxValue), maxmath.nextgreater(t));
            }
        }

        
        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual(uint.MaxValue, maxmath.nextgreater(uint.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                uint t = rng.NextUInt();

                Assert.AreEqual(t == uint.MaxValue ? uint.MaxValue : (uint)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint2)uint.MaxValue, maxmath.nextgreater((uint2)uint.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                uint2 t = rng.NextUInt2();

                Assert.AreEqual(math.select(t + 1, t, t == uint.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint3)uint.MaxValue, maxmath.nextgreater((uint3)uint.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                uint3 t = rng.NextUInt3();

                Assert.AreEqual(math.select(t + 1, t, t == uint.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint4)uint.MaxValue, maxmath.nextgreater((uint4)uint.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                uint4 t = rng.NextUInt4();

                Assert.AreEqual(math.select(t + 1, t, t == uint.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((uint8)uint.MaxValue, maxmath.nextgreater((uint8)uint.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                uint8 t = rng.NextUInt8();

                Assert.AreEqual(maxmath.select(t + 1, t, t == uint.MaxValue), maxmath.nextgreater(t));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual(int.MaxValue, maxmath.nextgreater(int.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                int t = rng.NextInt();

                Assert.AreEqual(t == int.MaxValue ? int.MaxValue : (int)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int2)int.MaxValue, maxmath.nextgreater((int2)int.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                int2 t = rng.NextInt2();

                Assert.AreEqual(math.select(t + 1, t, t == int.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int3)int.MaxValue, maxmath.nextgreater((int3)int.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                int3 t = rng.NextInt3();

                Assert.AreEqual(math.select(t + 1, t, t == int.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int4)int.MaxValue, maxmath.nextgreater((int4)int.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                int4 t = rng.NextInt4();

                Assert.AreEqual(math.select(t + 1, t, t == int.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            Assert.AreEqual((int8)int.MaxValue, maxmath.nextgreater((int8)int.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                int8 t = rng.NextInt8();

                Assert.AreEqual(maxmath.select(t + 1, t, t == int.MaxValue), maxmath.nextgreater(t));
            }
        }

        
        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual(ulong.MaxValue, maxmath.nextgreater(ulong.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ulong t = rng.NextULong();

                Assert.AreEqual(t == ulong.MaxValue ? ulong.MaxValue : (ulong)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((ulong2)ulong.MaxValue, maxmath.nextgreater((ulong2)ulong.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ulong2 t = rng.NextULong2();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ulong.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((ulong3)ulong.MaxValue, maxmath.nextgreater((ulong3)ulong.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ulong3 t = rng.NextULong3();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ulong.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((ulong4)ulong.MaxValue, maxmath.nextgreater((ulong4)ulong.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                ulong4 t = rng.NextULong4();

                Assert.AreEqual(maxmath.select(t + 1, t, t == ulong.MaxValue), maxmath.nextgreater(t));
            }
        }
        

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual(long.MaxValue, maxmath.nextgreater(long.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                long t = rng.NextLong();

                Assert.AreEqual(t == long.MaxValue ? long.MaxValue : (long)(t + 1), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((long2)long.MaxValue, maxmath.nextgreater((long2)long.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                long2 t = rng.NextLong2();

                Assert.AreEqual(maxmath.select(t + 1, t, t == long.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((long3)long.MaxValue, maxmath.nextgreater((long3)long.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                long3 t = rng.NextLong3();

                Assert.AreEqual(maxmath.select(t + 1, t, t == long.MaxValue), maxmath.nextgreater(t));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            Assert.AreEqual((long4)long.MaxValue, maxmath.nextgreater((long4)long.MaxValue));

            for (int i = 0; i < 5; i++)
            {
                long4 t = rng.NextLong4();

                Assert.AreEqual(maxmath.select(t + 1, t, t == long.MaxValue), maxmath.nextgreater(t));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater(maxmath.asquarter((byte)0b0111_1111)));
            Assert.AreEqual(maxmath.nextgreater((quarter)float.PositiveInfinity), (quarter)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter)float.NegativeInfinity), (quarter)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater(quarter.MaxValue), (quarter)float.PositiveInfinity);
            Assert.AreEqual(maxmath.asquarter((byte)1), maxmath.nextgreater(maxmath.asquarter((byte)0b1000_0000)));
            Assert.AreEqual(maxmath.asquarter((byte)1), maxmath.nextgreater((quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter f = (quarter)rng.NextFloat(quarter.MinValue / 2, quarter.MaxValue / 2);

                Assert.Greater((float)maxmath.nextgreater(f), (float)f);
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((quarter2)maxmath.asquarter((byte)0b0111_1111)).x);
            Assert.IsNaN(maxmath.nextgreater((quarter2)maxmath.asquarter((byte)0b0111_1111)).y);
            Assert.AreEqual(maxmath.nextgreater((quarter2)(quarter)float.PositiveInfinity), (quarter2)(quarter)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter2)(quarter)float.NegativeInfinity), (quarter2)(quarter)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter2)quarter.MaxValue), (quarter2)(quarter)float.PositiveInfinity);
            Assert.AreEqual((quarter2)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter2)maxmath.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter2)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter2)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter2 f = (quarter2)rng.NextFloat2(quarter.MinValue / 2, quarter.MaxValue / 2);

                Assert.Greater((float)maxmath.nextgreater(f).x, (float)f.x);
                Assert.Greater((float)maxmath.nextgreater(f).y, (float)f.y);
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((quarter3)maxmath.asquarter((byte)0b0111_1111)).x);
            Assert.IsNaN(maxmath.nextgreater((quarter3)maxmath.asquarter((byte)0b0111_1111)).y);
            Assert.IsNaN(maxmath.nextgreater((quarter3)maxmath.asquarter((byte)0b0111_1111)).z);
            Assert.AreEqual(maxmath.nextgreater((quarter3)(quarter)float.PositiveInfinity), (quarter3)(quarter)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter3)(quarter)float.NegativeInfinity), (quarter3)(quarter)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter3)quarter.MaxValue), (quarter3)(quarter)float.PositiveInfinity);
            Assert.AreEqual((quarter3)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter3)maxmath.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter3)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter3)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter3 f = (quarter3)rng.NextFloat3(quarter.MinValue / 2, quarter.MaxValue / 2);

                Assert.Greater((float)maxmath.nextgreater(f).x, (float)f.x);
                Assert.Greater((float)maxmath.nextgreater(f).y, (float)f.y);
                Assert.Greater((float)maxmath.nextgreater(f).z, (float)f.z);
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((quarter4)maxmath.asquarter((byte)0b0111_1111)).x);
            Assert.IsNaN(maxmath.nextgreater((quarter4)maxmath.asquarter((byte)0b0111_1111)).y);
            Assert.IsNaN(maxmath.nextgreater((quarter4)maxmath.asquarter((byte)0b0111_1111)).z);
            Assert.IsNaN(maxmath.nextgreater((quarter4)maxmath.asquarter((byte)0b0111_1111)).w);
            Assert.AreEqual(maxmath.nextgreater((quarter4)(quarter)float.PositiveInfinity), (quarter4)(quarter)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter4)(quarter)float.NegativeInfinity), (quarter4)(quarter)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter4)quarter.MaxValue), (quarter4)(quarter)float.PositiveInfinity);
            Assert.AreEqual((quarter4)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter4)maxmath.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter4)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter4)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter4 f = (quarter4)rng.NextFloat4(quarter.MinValue / 2, quarter.MaxValue / 2);

                Assert.Greater((float)maxmath.nextgreater(f).x, (float)f.x);
                Assert.Greater((float)maxmath.nextgreater(f).y, (float)f.y);
                Assert.Greater((float)maxmath.nextgreater(f).z, (float)f.z);
                Assert.Greater((float)maxmath.nextgreater(f).w, (float)f.w);
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x0);
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x1);
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x2);
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x3);
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x4);
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x5);
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x6);
            Assert.IsNaN(maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b0111_1111)).x7);
            Assert.AreEqual(maxmath.nextgreater((quarter8)(quarter)float.PositiveInfinity), (quarter8)(quarter)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter8)(quarter)float.NegativeInfinity), (quarter8)(quarter)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((quarter8)quarter.MaxValue), (quarter8)(quarter)float.PositiveInfinity);
            Assert.AreEqual((quarter8)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter8)maxmath.asquarter((byte)0b1000_0000)));
            Assert.AreEqual((quarter8)maxmath.asquarter((byte)1), maxmath.nextgreater((quarter8)(quarter)0f));

            for (int i = 0; i < 25; i++)
            {
                quarter8 f = (quarter8)rng.NextFloat8(quarter.MinValue / 2, quarter.MaxValue / 2);

                Assert.Greater((float)maxmath.nextgreater(f).x0, (float)f.x0);
                Assert.Greater((float)maxmath.nextgreater(f).x1, (float)f.x1);
                Assert.Greater((float)maxmath.nextgreater(f).x2, (float)f.x2);
                Assert.Greater((float)maxmath.nextgreater(f).x3, (float)f.x3);
                Assert.Greater((float)maxmath.nextgreater(f).x4, (float)f.x4);
                Assert.Greater((float)maxmath.nextgreater(f).x5, (float)f.x5);
                Assert.Greater((float)maxmath.nextgreater(f).x6, (float)f.x6);
                Assert.Greater((float)maxmath.nextgreater(f).x7, (float)f.x7);
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater(maxmath.ashalf((ushort)0x7FFF)));
            Assert.AreEqual(maxmath.nextgreater((half)float.PositiveInfinity), (half)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((half)float.NegativeInfinity), (half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater(half.MaxValueAsHalf), (half)float.PositiveInfinity);
            Assert.AreEqual(maxmath.ashalf((ushort)1), maxmath.nextgreater(maxmath.ashalf((ushort)0x8000)));
            Assert.AreEqual(maxmath.ashalf((ushort)1), maxmath.nextgreater((half)0f));

            for (int i = 0; i < 25; i++)
            {
                half f = (half)rng.NextFloat(half.MinValueAsHalf / 2, half.MaxValueAsHalf / 2);

                Assert.Greater(maxmath.nextgreater(f), f);
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((half2)maxmath.ashalf((ushort)0x7FFF)).x);
            Assert.IsNaN(maxmath.nextgreater((half2)maxmath.ashalf((ushort)0x7FFF)).y);
            Assert.AreEqual(maxmath.nextgreater((half2)(half)float.PositiveInfinity), (half2)(half)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((half2)(half)float.NegativeInfinity), (half2)(half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((half2)half.MaxValueAsHalf), (half2)(half)float.PositiveInfinity);
            Assert.AreEqual((half2)maxmath.ashalf((ushort)1), maxmath.nextgreater((half2)maxmath.ashalf((ushort)0x8000)));
            Assert.AreEqual((half2)maxmath.ashalf((ushort)1), maxmath.nextgreater((half2)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half2 f = (half2)rng.NextFloat2(half.MinValueAsHalf / 2, half.MaxValueAsHalf / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((half3)maxmath.ashalf((ushort)0x7FFF)).x);
            Assert.IsNaN(maxmath.nextgreater((half3)maxmath.ashalf((ushort)0x7FFF)).y);
            Assert.IsNaN(maxmath.nextgreater((half3)maxmath.ashalf((ushort)0x7FFF)).z);
            Assert.AreEqual(maxmath.nextgreater((half3)(half)float.PositiveInfinity), (half3)(half)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((half3)(half)float.NegativeInfinity), (half3)(half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((half3)half.MaxValueAsHalf), (half3)(half)float.PositiveInfinity);
            Assert.AreEqual((half3)maxmath.ashalf((ushort)1), maxmath.nextgreater((half3)maxmath.ashalf((ushort)0x8000)));
            Assert.AreEqual((half3)maxmath.ashalf((ushort)1), maxmath.nextgreater((half3)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half3 f = (half3)rng.NextFloat3(half.MinValueAsHalf / 2, half.MaxValueAsHalf / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
                Assert.Greater(maxmath.nextgreater(f).z, f.z);
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((half4)maxmath.ashalf((ushort)0x7FFF)).x);
            Assert.IsNaN(maxmath.nextgreater((half4)maxmath.ashalf((ushort)0x7FFF)).y);
            Assert.IsNaN(maxmath.nextgreater((half4)maxmath.ashalf((ushort)0x7FFF)).z);
            Assert.IsNaN(maxmath.nextgreater((half4)maxmath.ashalf((ushort)0x7FFF)).w);
            Assert.AreEqual(maxmath.nextgreater((half4)(half)float.PositiveInfinity), (half4)(half)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((half4)(half)float.NegativeInfinity), (half4)(half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((half4)half.MaxValueAsHalf), (half4)(half)float.PositiveInfinity);
            Assert.AreEqual((half4)maxmath.ashalf((ushort)1), maxmath.nextgreater((half4)maxmath.ashalf((ushort)0x8000)));
            Assert.AreEqual((half4)maxmath.ashalf((ushort)1), maxmath.nextgreater((half4)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half4 f = (half4)rng.NextFloat4(half.MinValueAsHalf / 2, half.MaxValueAsHalf / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
                Assert.Greater(maxmath.nextgreater(f).z, f.z);
                Assert.Greater(maxmath.nextgreater(f).w, f.w);
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x0);
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x1);
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x2);
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x3);
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x4);
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x5);
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x6);
            Assert.IsNaN(maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x7FFF)).x7);
            Assert.AreEqual(maxmath.nextgreater((half8)(half)float.PositiveInfinity), (half8)(half)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((half8)(half)float.NegativeInfinity), (half8)(half)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((half8)half.MaxValueAsHalf), (half8)(half)float.PositiveInfinity);
            Assert.AreEqual((half8)maxmath.ashalf((ushort)1), maxmath.nextgreater((half8)maxmath.ashalf((ushort)0x8000)));
            Assert.AreEqual((half8)maxmath.ashalf((ushort)1), maxmath.nextgreater((half8)(half)0f));

            for (int i = 0; i < 25; i++)
            {
                half8 f = (half8)rng.NextFloat8(half.MinValueAsHalf / 2, half.MaxValueAsHalf / 2);

                Assert.Greater(maxmath.nextgreater(f).x0, f.x0);
                Assert.Greater(maxmath.nextgreater(f).x1, f.x1);
                Assert.Greater(maxmath.nextgreater(f).x2, f.x2);
                Assert.Greater(maxmath.nextgreater(f).x3, f.x3);
                Assert.Greater(maxmath.nextgreater(f).x4, f.x4);
                Assert.Greater(maxmath.nextgreater(f).x5, f.x5);
                Assert.Greater(maxmath.nextgreater(f).x6, f.x6);
                Assert.Greater(maxmath.nextgreater(f).x7, f.x7);
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater(math.asfloat(0x7FFF_FFFF)));
            Assert.AreEqual(maxmath.nextgreater(float.PositiveInfinity), float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater(float.NegativeInfinity), float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater(float.MaxValue), float.PositiveInfinity);
            Assert.AreEqual(float.Epsilon, maxmath.nextgreater(math.asfloat(0x8000_0000)));
            Assert.AreEqual(float.Epsilon, maxmath.nextgreater(0f));

            for (int i = 0; i < 25; i++)
            {
                float f = rng.NextFloat(float.MinValue / 2, float.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f), f);
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((float2)math.asfloat(0x7FFF_FFFF)).x);
            Assert.IsNaN(maxmath.nextgreater((float2)math.asfloat(0x7FFF_FFFF)).y);
            Assert.AreEqual(maxmath.nextgreater((float2)float.PositiveInfinity), (float2)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((float2)float.NegativeInfinity), (float2)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((float2)float.MaxValue), (float2)float.PositiveInfinity);
            Assert.AreEqual((float2)float.Epsilon, maxmath.nextgreater((float2)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float2)float.Epsilon, maxmath.nextgreater((float2)0f));

            for (int i = 0; i < 25; i++)
            {
                float2 f = rng.NextFloat2(float.MinValue / 2, float.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((float3)math.asfloat(0x7FFF_FFFF)).x);
            Assert.IsNaN(maxmath.nextgreater((float3)math.asfloat(0x7FFF_FFFF)).y);
            Assert.IsNaN(maxmath.nextgreater((float3)math.asfloat(0x7FFF_FFFF)).z);
            Assert.AreEqual(maxmath.nextgreater((float3)float.PositiveInfinity), (float3)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((float3)float.NegativeInfinity), (float3)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((float3)float.MaxValue), (float3)float.PositiveInfinity);
            Assert.AreEqual((float3)float.Epsilon, maxmath.nextgreater((float3)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float3)float.Epsilon, maxmath.nextgreater((float3)0f));

            for (int i = 0; i < 25; i++)
            {
                float3 f = rng.NextFloat3(float.MinValue / 2, float.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
                Assert.Greater(maxmath.nextgreater(f).z, f.z);
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((float4)math.asfloat(0x7FFF_FFFF)).x);
            Assert.IsNaN(maxmath.nextgreater((float4)math.asfloat(0x7FFF_FFFF)).y);
            Assert.IsNaN(maxmath.nextgreater((float4)math.asfloat(0x7FFF_FFFF)).z);
            Assert.IsNaN(maxmath.nextgreater((float4)math.asfloat(0x7FFF_FFFF)).w);
            Assert.AreEqual(maxmath.nextgreater((float4)float.PositiveInfinity), (float4)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((float4)float.NegativeInfinity), (float4)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((float4)float.MaxValue), (float4)float.PositiveInfinity);
            Assert.AreEqual((float4)float.Epsilon, maxmath.nextgreater((float4)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float4)float.Epsilon, maxmath.nextgreater((float4)0f));

            for (int i = 0; i < 25; i++)
            {
                float4 f = rng.NextFloat4(float.MinValue / 2, float.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
                Assert.Greater(maxmath.nextgreater(f).z, f.z);
                Assert.Greater(maxmath.nextgreater(f).w, f.w);
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;
            
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x0);
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x1);
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x2);
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x3);
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x4);
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x5);
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x6);
            Assert.IsNaN(maxmath.nextgreater((float8)math.asfloat(0x7FFF_FFFF)).x7);
            Assert.AreEqual(maxmath.nextgreater((float8)float.PositiveInfinity), (float8)float.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((float8)float.NegativeInfinity), (float8)float.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((float8)float.MaxValue), (float8)float.PositiveInfinity);
            Assert.AreEqual((float8)float.Epsilon, maxmath.nextgreater((float8)math.asfloat(0x8000_0000)));
            Assert.AreEqual((float8)float.Epsilon, maxmath.nextgreater((float8)0f));

            for (int i = 0; i < 25; i++)
            {
                float8 f = rng.NextFloat8(float.MinValue / 2, float.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f).x0, f.x0);
                Assert.Greater(maxmath.nextgreater(f).x1, f.x1);
                Assert.Greater(maxmath.nextgreater(f).x2, f.x2);
                Assert.Greater(maxmath.nextgreater(f).x3, f.x3);
                Assert.Greater(maxmath.nextgreater(f).x4, f.x4);
                Assert.Greater(maxmath.nextgreater(f).x5, f.x5);
                Assert.Greater(maxmath.nextgreater(f).x6, f.x6);
                Assert.Greater(maxmath.nextgreater(f).x7, f.x7);
            }
        }

        
        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nextgreater(math.asdouble(0x7FFF_FFFF_FFFF_FFFF)));
            Assert.AreEqual(maxmath.nextgreater(double.PositiveInfinity), double.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater(double.NegativeInfinity), double.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater(double.MaxValue), double.PositiveInfinity);
            Assert.AreEqual(double.Epsilon, maxmath.nextgreater(math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual(double.Epsilon, maxmath.nextgreater(0d));

            for (int i = 0; i < 25; i++)
            {
                double f = rng.NextDouble(double.MinValue / 2, double.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f), f);
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nextgreater((double2)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).x);
            Assert.IsNaN(maxmath.nextgreater((double2)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).y);
            Assert.AreEqual(maxmath.nextgreater((double2)double.PositiveInfinity), (double2)double.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((double2)double.NegativeInfinity), (double2)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((double2)double.MaxValue), (double2)double.PositiveInfinity);
            Assert.AreEqual((double2)double.Epsilon, maxmath.nextgreater((double2)math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual((double2)double.Epsilon, maxmath.nextgreater((double2)0d));

            for (int i = 0; i < 25; i++)
            {
                double2 f = rng.NextDouble2(double.MinValue / 2, double.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nextgreater((double3)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).x);
            Assert.IsNaN(maxmath.nextgreater((double3)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).y);
            Assert.IsNaN(maxmath.nextgreater((double3)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).z);
            Assert.AreEqual(maxmath.nextgreater((double3)double.PositiveInfinity), (double3)double.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((double3)double.NegativeInfinity), (double3)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((double3)double.MaxValue), (double3)double.PositiveInfinity);
            Assert.AreEqual((double3)double.Epsilon, maxmath.nextgreater((double3)math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual((double3)double.Epsilon, maxmath.nextgreater((double3)0d));

            for (int i = 0; i < 25; i++)
            {
                double3 f = rng.NextDouble3(double.MinValue / 2, double.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
                Assert.Greater(maxmath.nextgreater(f).z, f.z);
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;
            
            Assert.IsNaN(maxmath.nextgreater((double4)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).x);
            Assert.IsNaN(maxmath.nextgreater((double4)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).y);
            Assert.IsNaN(maxmath.nextgreater((double4)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).z);
            Assert.IsNaN(maxmath.nextgreater((double4)math.asdouble(0x7FFF_FFFF_FFFF_FFFF)).w);
            Assert.AreEqual(maxmath.nextgreater((double4)double.PositiveInfinity), (double4)double.PositiveInfinity);
            Assert.AreEqual(maxmath.nextgreater((double4)double.NegativeInfinity), (double4)double.NegativeInfinity);
            Assert.AreEqual(maxmath.nextgreater((double4)double.MaxValue), (double4)double.PositiveInfinity);
            Assert.AreEqual((double4)double.Epsilon, maxmath.nextgreater((double4)math.asdouble(0x8000_0000_0000_0000ul)));
            Assert.AreEqual((double4)double.Epsilon, maxmath.nextgreater((double4)0d));

            for (int i = 0; i < 25; i++)
            {
                double4 f = rng.NextDouble4(double.MinValue / 2, double.MaxValue / 2);

                Assert.Greater(maxmath.nextgreater(f).x, f.x);
                Assert.Greater(maxmath.nextgreater(f).y, f.y);
                Assert.Greater(maxmath.nextgreater(f).z, f.z);
                Assert.Greater(maxmath.nextgreater(f).w, f.w);
            }
        }
    }
}
