using NUnit.Framework;
using System.Numerics;

namespace MaxMath.Tests
{
    public static class f_floordiv
    {
        private static BigInteger __floordiv(BigInteger x, BigInteger y)
        {
            return (x / y) - (x % y != 0 && ((x < 0) != (y < 0)) ? 1 : 0);
        }

        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                byte x = rng.NextByte();
                byte n = rng.NextByte(1, byte.MaxValue);

                Assert.AreEqual(math.floordiv(x, n), (byte)__floordiv(x, n));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                byte2 x = rng.NextByte2();
                byte2 n = rng.NextByte2(1, byte.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (byte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                byte3 x = rng.NextByte3();
                byte3 n = rng.NextByte3(1, byte.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (byte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                byte4 x = rng.NextByte4();
                byte4 n = rng.NextByte4(1, byte.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (byte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                byte8 x = rng.NextByte8();
                byte8 n = rng.NextByte8(1, byte.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (byte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                byte16 x = rng.NextByte16();
                byte16 n = rng.NextByte16(1, byte.MaxValue);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (byte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                byte32 x = rng.NextByte32();
                byte32 n = rng.NextByte32(1, byte.MaxValue);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (byte)__floordiv(x[j], n[j]));
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
                sbyte n = rng.NextSByte();

                n = math.select(n, (sbyte)1, n == 0);
                n = math.select(n, (sbyte)1, (n == -1) & (x == sbyte.MinValue));

                Assert.AreEqual(math.floordiv(x, n), (sbyte)__floordiv(x, n));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                sbyte2 x = rng.NextSByte2();
                sbyte2 n = rng.NextSByte2();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == sbyte.MinValue));

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (sbyte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                sbyte3 x = rng.NextSByte3();
                sbyte3 n = rng.NextSByte3();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == sbyte.MinValue));

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (sbyte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                sbyte4 x = rng.NextSByte4();
                sbyte4 n = rng.NextSByte4();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == sbyte.MinValue));

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (sbyte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                sbyte8 x = rng.NextSByte8();
                sbyte8 n = rng.NextSByte8();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == sbyte.MinValue));

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (sbyte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                sbyte16 x = rng.NextSByte16();
                sbyte16 n = rng.NextSByte16();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == sbyte.MinValue));

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (sbyte)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 256; i++)
            {
                sbyte32 x = rng.NextSByte32();
                sbyte32 n = rng.NextSByte32();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == sbyte.MinValue));

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (sbyte)__floordiv(x[j], n[j]));
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                ushort x = rng.NextUShort();
                ushort n = rng.NextUShort(1, ushort.MaxValue);
                
                Assert.AreEqual(math.floordiv(x, n), (ushort)__floordiv(x, n));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 n = rng.NextUShort2(1, ushort.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ushort)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 n = rng.NextUShort3(1, ushort.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ushort)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 n = rng.NextUShort4(1, ushort.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ushort)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                ushort8 x = rng.NextUShort8();
                ushort8 n = rng.NextUShort8(1, ushort.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ushort)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                ushort16 x = rng.NextUShort16();
                ushort16 n = rng.NextUShort16(1, ushort.MaxValue);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ushort)__floordiv(x[j], n[j]));
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
                short n = rng.NextShort();

                n = math.select(n, (short)1, n == 0);
                n = math.select(n, (short)1, (n == -1) & (x == short.MinValue));
                
                Assert.AreEqual(math.floordiv(x, n), (short)__floordiv(x, n));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                short2 x = rng.NextShort2();
                short2 n = rng.NextShort2();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == short.MinValue));

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (short)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                short3 x = rng.NextShort3();
                short3 n = rng.NextShort3();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == short.MinValue));

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (short)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                short4 x = rng.NextShort4();
                short4 n = rng.NextShort4();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == short.MinValue));

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (short)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                short8 x = rng.NextShort8();
                short8 n = rng.NextShort8();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == short.MinValue));

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (short)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 256; i++)
            {
                short16 x = rng.NextShort16();
                short16 n = rng.NextShort16();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == short.MinValue));

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (short)__floordiv(x[j], n[j]));
                }
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                uint x = rng.NextUInt();
                uint n = rng.NextUInt(1, uint.MaxValue);
                
                Assert.AreEqual(math.floordiv(x, n), (uint)__floordiv(x, n));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                uint2 x = rng.NextUInt2();
                uint2 n = rng.NextUInt2(1, uint.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (uint)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                uint3 x = rng.NextUInt3();
                uint3 n = rng.NextUInt3(1, uint.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (uint)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                uint4 x = rng.NextUInt4();
                uint4 n = rng.NextUInt4(1, uint.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (uint)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                uint8 x = rng.NextUInt8();
                uint8 n = rng.NextUInt8(1, uint.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (uint)__floordiv(x[j], n[j]));
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
                int n = rng.NextInt();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == int.MinValue));
                
                Assert.AreEqual(math.floordiv(x, n), (int)__floordiv(x, n));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                int2 x = rng.NextInt2();
                int2 n = rng.NextInt2();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == int.MinValue));

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (int)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                int3 x = rng.NextInt3();
                int3 n = rng.NextInt3();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == int.MinValue));

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (int)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                int4 x = rng.NextInt4();
                int4 n = rng.NextInt4();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == int.MinValue));

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (int)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 256; i++)
            {
                int8 x = rng.NextInt8();
                int8 n = rng.NextInt8();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == int.MinValue));

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (int)__floordiv(x[j], n[j]));
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 256; i++)
            {
                ulong x = rng.NextULong();
                ulong n = rng.NextULong(1, ulong.MaxValue);
                
                Assert.AreEqual(math.floordiv(x, n), (ulong)__floordiv(x, n));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 256; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 n = rng.NextULong2(1, ulong.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ulong)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 256; i++)
            {
                ulong3 x = rng.NextULong3();
                ulong3 n = rng.NextULong3(1, ulong.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ulong)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 256; i++)
            {
                ulong4 x = rng.NextULong4();
                ulong4 n = rng.NextULong4(1, ulong.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (ulong)__floordiv(x[j], n[j]));
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
                long n = rng.NextLong();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == long.MinValue));
                
                Assert.AreEqual(math.floordiv(x, n), (long)__floordiv(x, n));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 256; i++)
            {
                long2 x = rng.NextLong2();
                long2 n = rng.NextLong2();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == long.MinValue));

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (long)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 256; i++)
            {
                long3 x = rng.NextLong3();
                long3 n = rng.NextLong3();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == long.MinValue));

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (long)__floordiv(x[j], n[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 256; i++)
            {
                long4 x = rng.NextLong4();
                long4 n = rng.NextLong4();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == long.MinValue));

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(math.floordiv(x, n)[j], (long)__floordiv(x[j], n[j]));
                }
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 256; i++)
            {
                UInt128 x = rng.NextUInt128();
                UInt128 n = rng.NextUInt128(1, UInt128.MaxValue);
                
                Assert.AreEqual(math.floordiv(x, n), (UInt128)__floordiv(x, n));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 64; i++)
            {
                Int128 x = rng.NextInt128();
                Int128 n = rng.NextInt128();

                n = math.select(n, 1, n == 0);
                n = math.select(n, 1, (n == -1) & (x == Int128.MinValue));
                
                Assert.AreEqual(math.floordiv(x, n), (Int128)__floordiv(x, n));
            }
        }

    }
}
