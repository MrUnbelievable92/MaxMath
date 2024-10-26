using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_countzerobits
    {
        private const int NUM_TESTS = 32;


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                UInt128 test = rng.NextUInt128();

                Assert.AreEqual(128 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                Int128 test = rng.NextInt128();

                Assert.AreEqual(128 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte test = rng.NextByte();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte2 test = rng.NextByte2();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte3 test = rng.NextByte3();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte4 test = rng.NextByte4();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte8 test = rng.NextByte8();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte16 test = rng.NextByte16();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte32 test = rng.NextByte32();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte test = rng.NextSByte();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte2 test = rng.NextSByte2();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte3 test = rng.NextSByte3();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte4 test = rng.NextSByte4();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 test = rng.NextSByte8();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 test = rng.NextSByte16();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte32 test = rng.NextSByte32();

                Assert.AreEqual(8 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort test = rng.NextUShort();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort2 test = rng.NextUShort2();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort3 test = rng.NextUShort3();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort4 test = rng.NextUShort4();

            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort8 test = rng.NextUShort8();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort16 test = rng.NextUShort16();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short test = rng.NextShort();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short2 test = rng.NextShort2();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short3 test = rng.NextShort3();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short4 test = rng.NextShort4();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 test = rng.NextShort8();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 test = rng.NextShort16();

                Assert.AreEqual(16 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint test = rng.NextUInt();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint2 test = rng.NextUInt2();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint3 test = rng.NextUInt3();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint4 test = rng.NextUInt4();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                uint8 test = rng.NextUInt8();

                Assert.AreEqual(32 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int test = rng.NextInt();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int2 test = rng.NextInt2();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int3 test = rng.NextInt3();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int4 test = rng.NextInt4();

                Assert.AreEqual(32 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                int8 test = rng.NextInt8();

                Assert.AreEqual(32 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                ulong test = rng.NextULong();

                Assert.AreEqual(64 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                ulong2 test = rng.NextULong2();

                Assert.AreEqual(64 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                ulong3 test = rng.NextULong3();

                Assert.AreEqual(64 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                ulong4 test = rng.NextULong4();

                Assert.AreEqual(64 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                long test = rng.NextLong();

                Assert.AreEqual(64 - math.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                long2 test = rng.NextLong2();

                Assert.AreEqual(64 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                long3 test = rng.NextLong3();

                Assert.AreEqual(64 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for(int i = 0; i < NUM_TESTS; i++)
            {
                long4 test = rng.NextLong4();

                Assert.AreEqual(64 - maxmath.countbits(test), maxmath.countzerobits(test));
            }
        }
    }
}
