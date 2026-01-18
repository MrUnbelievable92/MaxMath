using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_mulwide
    {
        private static void TestByte(byte x, byte y, byte lo, byte hi)
        {
            uint real = (uint)x * (uint)y;

            Assert.AreEqual(real, (uint)lo | ((uint)hi << 8));
        }
        
        private static void TestUShort(ushort x, ushort y, ushort lo, ushort hi)
        {
            uint real = (uint)x * (uint)y;

            Assert.AreEqual(real, (uint)lo | ((uint)hi << 16));
        }
        
        private static void TestUInt(uint x, uint y, uint lo, uint hi)
        {
            ulong real = (ulong)x * (ulong)y;

            Assert.AreEqual(real, (ulong)lo | ((ulong)hi << 32));
        }
        
        private static void TestULong(ulong x, ulong y, ulong lo, ulong hi)
        {
            UInt128 real = (UInt128)x * (UInt128)y;

            Assert.AreEqual(real, (UInt128)lo | ((UInt128)hi << 64));
        }
        
        private static void TestUInt128(UInt128 x, UInt128 y, UInt128 lo, UInt128 hi)
        {
            BigInteger real = (BigInteger)x * (BigInteger)y;

            Assert.AreEqual(real, (BigInteger)lo | ((BigInteger)hi << 128));
        }
        
        private static void TestSByte(sbyte x, sbyte y, sbyte lo, sbyte hi)
        {
            int real = (int)x * (int)y;

            Assert.AreEqual(real, (int)(byte)lo | ((int)hi << 8));
        }
        
        private static void TestShort(short x, short y, short lo, short hi)
        {
            int real = (int)x * (int)y;

            Assert.AreEqual(real, (int)(ushort)lo | ((int)hi << 16));
        }
        
        private static void TestInt(int x, int y, int lo, int hi)
        {
            long real = (long)x * (long)y;

            Assert.AreEqual(real, (long)(uint)lo | ((long)hi << 32));
        }
        
        private static void TestLong(long x, long y, long lo, long hi)
        {
            Int128 real = (Int128)x * (Int128)y;

            Assert.AreEqual(real, (Int128)(ulong)lo | ((Int128)hi << 64));
        }
        
        private static void TestInt128(Int128 x, Int128 y, Int128 lo, Int128 hi)
        {
            BigInteger real = (BigInteger)x * (BigInteger)y;

            Assert.AreEqual(real, (BigInteger)(UInt128)lo | ((BigInteger)hi << 128));
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                Int128 x = rng.NextInt128();
                Int128 y = rng.NextInt128();

                maxmath.mulwide(x, y, out Int128 lo, out Int128 hi);

                TestInt128(x, y, lo, hi);
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                UInt128 x = rng.NextUInt128();
                UInt128 y = rng.NextUInt128();

                maxmath.mulwide(x, y, out UInt128 lo, out UInt128 hi);

                TestUInt128(x, y, lo, hi);
            }
        }


        [Test]
        public static void _sbyte()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                for (int j = sbyte.MinValue; j <= sbyte.MaxValue; j++)
                {
                    sbyte x = (sbyte)i;
                    sbyte y = (sbyte)j;
                    maxmath.mulwide(x, y, out sbyte lo, out sbyte hi);

                    TestSByte(x, y, lo, hi);
                }
            }
        }
        
        [Test]
        public static void _sbyte2()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                for (int j = sbyte.MinValue; j <= sbyte.MaxValue; j++)
                {
                    sbyte2 x = (sbyte)i;
                    sbyte2 y = (sbyte)j;
                    maxmath.mulwide(x, y, out sbyte2 lo, out sbyte2 hi);

                    for (int h = 0; h < 2; h++)
                    {
                        TestSByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                for (int j = sbyte.MinValue; j <= sbyte.MaxValue; j++)
                {
                    sbyte3 x = (sbyte)i;
                    sbyte3 y = (sbyte)j;
                    maxmath.mulwide(x, y, out sbyte3 lo, out sbyte3 hi);

                    for (int h = 0; h < 3; h++)
                    {
                        TestSByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                for (int j = sbyte.MinValue; j <= sbyte.MaxValue; j++)
                {
                    sbyte4 x = (sbyte)i;
                    sbyte4 y = (sbyte)j;
                    maxmath.mulwide(x, y, out sbyte4 lo, out sbyte4 hi);

                    for (int h = 0; h < 4; h++)
                    {
                        TestSByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                for (int j = sbyte.MinValue; j <= sbyte.MaxValue; j++)
                {
                    sbyte8 x = (sbyte)i;
                    sbyte8 y = (sbyte)j;
                    maxmath.mulwide(x, y, out sbyte8 lo, out sbyte8 hi);

                    for (int h = 0; h < 8; h++)
                    {
                        TestSByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                for (int j = sbyte.MinValue; j <= sbyte.MaxValue; j++)
                {
                    sbyte16 x = (sbyte)i;
                    sbyte16 y = (sbyte)j;
                    maxmath.mulwide(x, y, out sbyte16 lo, out sbyte16 hi);

                    for (int h = 0; h < 16; h++)
                    {
                        TestSByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            for (int i = sbyte.MinValue; i <= sbyte.MaxValue; i++)
            {
                for (int j = sbyte.MinValue; j <= sbyte.MaxValue; j++)
                {
                    sbyte32 x = (sbyte)i;
                    sbyte32 y = (sbyte)j;
                    maxmath.mulwide(x, y, out sbyte32 lo, out sbyte32 hi);

                    for (int h = 0; h < 32; h++)
                    {
                        TestSByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }
        

        [Test]
        public static void _byte()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte x = (byte)i;
                    byte y = (byte)j;
                    maxmath.mulwide(x, y, out byte lo, out byte hi);

                    TestByte(x, y, lo, hi);
                }
            }
        }
        
        [Test]
        public static void _byte2()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte2 x = (byte)i;
                    byte2 y = (byte)j;
                    maxmath.mulwide(x, y, out byte2 lo, out byte2 hi);

                    for (int h = 0; h < 2; h++)
                    {
                        TestByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte3 x = (byte)i;
                    byte3 y = (byte)j;
                    maxmath.mulwide(x, y, out byte3 lo, out byte3 hi);

                    for (int h = 0; h < 3; h++)
                    {
                        TestByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte4 x = (byte)i;
                    byte4 y = (byte)j;
                    maxmath.mulwide(x, y, out byte4 lo, out byte4 hi);

                    for (int h = 0; h < 4; h++)
                    {
                        TestByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte8 x = (byte)i;
                    byte8 y = (byte)j;
                    maxmath.mulwide(x, y, out byte8 lo, out byte8 hi);

                    for (int h = 0; h < 8; h++)
                    {
                        TestByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte16 x = (byte)i;
                    byte16 y = (byte)j;
                    maxmath.mulwide(x, y, out byte16 lo, out byte16 hi);

                    for (int h = 0; h < 16; h++)
                    {
                        TestByte(x[h], y[h], lo[h], hi[h]);
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            for (int i = 0; i <= byte.MaxValue; i++)
            {
                for (int j = 0; j <= byte.MaxValue; j++)
                {
                    byte32 x = (byte)i;
                    byte32 y = (byte)j;
                    maxmath.mulwide(x, y, out byte32 lo, out byte32 hi);

                    for (int h = 0; h < 32; h++)
                    {
                        TestByte(x[h], y[h], lo[h], hi[h]);
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
                short y = rng.NextShort();
                maxmath.mulwide(x, y, out short lo, out short hi);

                TestShort(x, y, lo, hi);
            }
        }
        
        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short2 x = rng.NextShort2();
                short2 y = rng.NextShort2();
                maxmath.mulwide(x, y, out short2 lo, out short2 hi);

                for (int h = 0; h < 2; h++)
                {
                    TestShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short3 x = rng.NextShort3();
                short3 y = rng.NextShort3();
                maxmath.mulwide(x, y, out short3 lo, out short3 hi);

                for (int h = 0; h < 3; h++)
                {
                    TestShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short4 x = rng.NextShort4();
                short4 y = rng.NextShort4();
                maxmath.mulwide(x, y, out short4 lo, out short4 hi);

                for (int h = 0; h < 4; h++)
                {
                    TestShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short8 x = rng.NextShort8();
                short8 y = rng.NextShort8();
                maxmath.mulwide(x, y, out short8 lo, out short8 hi);

                for (int h = 0; h < 8; h++)
                {
                    TestShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                short16 x = rng.NextShort16();
                short16 y = rng.NextShort16();
                maxmath.mulwide(x, y, out short16 lo, out short16 hi);

                for (int h = 0; h < 16; h++)
                {
                    TestShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        
        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort x = rng.NextUShort();
                ushort y = rng.NextUShort();
                maxmath.mulwide(x, y, out ushort lo, out ushort hi);

                TestUShort(x, y, lo, hi);
            }
        }
        
        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 y = rng.NextUShort2();
                maxmath.mulwide(x, y, out ushort2 lo, out ushort2 hi);

                for (int h = 0; h < 2; h++)
                {
                    TestUShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 y = rng.NextUShort3();
                maxmath.mulwide(x, y, out ushort3 lo, out ushort3 hi);

                for (int h = 0; h < 3; h++)
                {
                    TestUShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 y = rng.NextUShort4();
                maxmath.mulwide(x, y, out ushort4 lo, out ushort4 hi);

                for (int h = 0; h < 4; h++)
                {
                    TestUShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();
                ushort8 y = rng.NextUShort8();
                maxmath.mulwide(x, y, out ushort8 lo, out ushort8 hi);

                for (int h = 0; h < 8; h++)
                {
                    TestUShort(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort16 x = rng.NextUShort16();
                ushort16 y = rng.NextUShort16();
                maxmath.mulwide(x, y, out ushort16 lo, out ushort16 hi);

                for (int h = 0; h < 16; h++)
                {
                    TestUShort(x[h], y[h], lo[h], hi[h]);
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
                int y = rng.NextInt();
                maxmath.mulwide(x, y, out int lo, out int hi);

                TestInt(x, y, lo, hi);
            }
        }
        
        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int2 x = rng.NextInt2();
                int2 y = rng.NextInt2();
                maxmath.mulwide(x, y, out int2 lo, out int2 hi);

                for (int h = 0; h < 2; h++)
                {
                    TestInt(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int3 x = rng.NextInt3();
                int3 y = rng.NextInt3();
                maxmath.mulwide(x, y, out int3 lo, out int3 hi);

                for (int h = 0; h < 3; h++)
                {
                    TestInt(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int4 x = rng.NextInt4();
                int4 y = rng.NextInt4();
                maxmath.mulwide(x, y, out int4 lo, out int4 hi);

                for (int h = 0; h < 4; h++)
                {
                    TestInt(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                int8 x = rng.NextInt8();
                int8 y = rng.NextInt8();
                maxmath.mulwide(x, y, out int8 lo, out int8 hi);

                for (int h = 0; h < 8; h++)
                {
                    TestInt(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        
        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                uint x = rng.NextUInt();
                uint y = rng.NextUInt();
                maxmath.mulwide(x, y, out uint lo, out uint hi);

                TestUInt(x, y, lo, hi);
            }
        }
        
        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                uint2 x = rng.NextUInt2();
                uint2 y = rng.NextUInt2();
                maxmath.mulwide(x, y, out uint2 lo, out uint2 hi);

                for (int h = 0; h < 2; h++)
                {
                    TestUInt(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                uint3 x = rng.NextUInt3();
                uint3 y = rng.NextUInt3();
                maxmath.mulwide(x, y, out uint3 lo, out uint3 hi);

                for (int h = 0; h < 3; h++)
                {
                    TestUInt(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                uint4 x = rng.NextUInt4();
                uint4 y = rng.NextUInt4();
                maxmath.mulwide(x, y, out uint4 lo, out uint4 hi);

                for (int h = 0; h < 4; h++)
                {
                    TestUInt(x[h], y[h], lo[h], hi[h]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();
                uint8 y = rng.NextUInt8();
                maxmath.mulwide(x, y, out uint8 lo, out uint8 hi);

                for (int h = 0; h < 8; h++)
                {
                    TestUInt(x[h], y[h], lo[h], hi[h]);
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
                long y = rng.NextLong();
                maxmath.mulwide(x, y, out long lo, out long hi);

                TestLong(x, y, lo, hi);
            }
        }
        
        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                long2 x = rng.NextLong2();
                long2 y = rng.NextLong2();
                maxmath.mulwide(x, y, out long2 lo, out long2 hi);

                for (int h = 0; h < 2; h++)
                {
                    TestLong(x[h], y[h], lo[h], hi[h]);
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
                long3 y = rng.NextLong3();
                maxmath.mulwide(x, y, out long3 lo, out long3 hi);

                for (int h = 0; h < 3; h++)
                {
                    TestLong(x[h], y[h], lo[h], hi[h]);
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
                long4 y = rng.NextLong4();
                maxmath.mulwide(x, y, out long4 lo, out long4 hi);

                for (int h = 0; h < 4; h++)
                {
                    TestLong(x[h], y[h], lo[h], hi[h]);
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
                ulong y = rng.NextULong();
                maxmath.mulwide(x, y, out ulong lo, out ulong hi);

                TestULong(x, y, lo, hi);
            }
        }
        
        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 y = rng.NextULong2();
                maxmath.mulwide(x, y, out ulong2 lo, out ulong2 hi);

                for (int h = 0; h < 2; h++)
                {
                    TestULong(x[h], y[h], lo[h], hi[h]);
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
                ulong3 y = rng.NextULong3();
                maxmath.mulwide(x, y, out ulong3 lo, out ulong3 hi);

                for (int h = 0; h < 3; h++)
                {
                    TestULong(x[h], y[h], lo[h], hi[h]);
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
                ulong4 y = rng.NextULong4();
                maxmath.mulwide(x, y, out ulong4 lo, out ulong4 hi);

                for (int h = 0; h < 4; h++)
                {
                    TestULong(x[h], y[h], lo[h], hi[h]);
                }
            }
        }
    }
}