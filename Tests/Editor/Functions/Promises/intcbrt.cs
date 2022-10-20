using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_intcbrt
    {
        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte b = rng.NextSByte(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 b = rng.NextSByte2(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 b = rng.NextSByte3(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 b = rng.NextSByte4(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 b = rng.NextSByte8(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 b = rng.NextSByte16(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte32 b = rng.NextSByte32(0, sbyte.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));
            }
        }

        
        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short b = rng.NextShort(0, short.MaxValue);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextShort(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextShort(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 b = rng.NextShort2(0, short.MaxValue);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextShort2(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextShort2(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 b = rng.NextShort3(0, short.MaxValue);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextShort3(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextShort3(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 b = rng.NextShort4(0, short.MaxValue);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextShort4(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextShort4(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 b = rng.NextShort8(0, short.MaxValue);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextShort8(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextShort8(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 b = rng.NextShort16(0, short.MaxValue);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextShort16(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextShort16(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));
            }
        }

        
        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort b = rng.NextUShort(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort2 b = rng.NextUShort2(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 b = rng.NextUShort3(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 b = rng.NextUShort4(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 b = rng.NextUShort8(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 b = rng.NextUShort16(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));
            }
        }

        
        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int b = rng.NextInt(0, int.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextInt(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextInt(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextInt(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextInt(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 b = rng.NextInt2(0, int.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextInt2(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextInt2(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextInt2(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextInt2(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 b = rng.NextInt3(0, int.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextInt3(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextInt3(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextInt3(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextInt3(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 b = rng.NextInt4(0, int.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextInt4(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextInt4(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextInt4(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextInt4(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 b = rng.NextInt8(0, int.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextInt8(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextInt8(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextInt8(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextInt8(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        
        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint b = rng.NextUInt(0, uint.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextUInt(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextUInt(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint2 b = rng.NextUInt2(0, uint.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextUInt2(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextUInt2(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint3 b = rng.NextUInt3(0, uint.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextUInt3(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextUInt3(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint4 b = rng.NextUInt4(0, uint.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextUInt4(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextUInt4(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint8 b = rng.NextUInt8(0, uint.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextUInt8(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextUInt8(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));
            }
        }

        
        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long b = rng.NextLong(0, long.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextLong(-uint.MaxValue, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextLong(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextLong(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextLong(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextLong(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe2));

                b = rng.NextLong(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long2 b = rng.NextLong2(0, long.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextLong2(-(1L << 40), (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextLong2(0, (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextLong2(-uint.MaxValue, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextLong2(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextLong2(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe2));

                b = rng.NextLong2(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextLong2(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe3));

                b = rng.NextLong2(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long3 b = rng.NextLong3(0, long.MaxValue);
            
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextLong3(-(1L << 40), (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextLong3(0, (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextLong3(-uint.MaxValue, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextLong3(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextLong3(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe2));

                b = rng.NextLong3(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextLong3(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe3));

                b = rng.NextLong3(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long4 b = rng.NextLong4(0, long.MaxValue);
                
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextLong4(-(1L << 40), (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextLong4(0, (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextLong4(-uint.MaxValue, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextLong4(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextLong4(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe2));

                b = rng.NextLong4(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextLong4(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe3));

                b = rng.NextLong4(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }
        
        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong b = rng.NextULong(0, ulong.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextULong(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextULong(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextULong(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong2 b = rng.NextULong2(0, ulong.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextULong2(0, (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextULong2(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextULong2(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextULong2(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong3 b = rng.NextULong3(0, ulong.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextULong3(0, (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextULong3(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextULong3(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextULong3(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong4 b = rng.NextULong4(0, ulong.MaxValue);
                
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextULong4(0, (1L << 40) + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextULong4(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextULong4(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextULong4(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }

        
        [Test]
        public static void _int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 24; i++)
            {
                Int128 b = rng.NextInt128(0, Int128.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextInt128(-(Int128)ulong.MaxValue, ulong.MaxValue + (Int128)1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe0));

                b = rng.NextInt128(0, ulong.MaxValue + (Int128)1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextInt128(-uint.MaxValue, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe1));

                b = rng.NextInt128(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextInt128(-ushort.MaxValue, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe2));

                b = rng.NextInt128(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextInt128(-byte.MaxValue, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.Unsafe3));

                b = rng.NextInt128(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }

        
        [Test]
        public static void _uint128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 24; i++)
            {
                UInt128 b = rng.NextUInt128(0, UInt128.MaxValue);

                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater));

                b = rng.NextUInt128(0, ulong.MaxValue + (UInt128)1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe0));

                b = rng.NextUInt128(0, uint.MaxValue + 1L);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe1));

                b = rng.NextUInt128(0, ushort.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe2));

                b = rng.NextUInt128(0, byte.MaxValue + 1);
                Assert.AreEqual(maxmath.intcbrt(b), maxmath.intcbrt(b, maxmath.Promise.ZeroOrGreater | maxmath.Promise.Unsafe3));
            }
        }
    }
}
