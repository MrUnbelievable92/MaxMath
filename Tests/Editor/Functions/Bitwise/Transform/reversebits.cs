using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_reversebits
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte x = rng.NextByte();

                Assert.AreEqual(maxmath.reversebits(x), math.reversebits((ulong)x) >> (64 - 8));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte2 x = rng.NextByte2();

                Assert.AreEqual(maxmath.reversebits(x), (byte2)(math.reversebits((uint2)x) >> (32 - 8)));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte3 x = rng.NextByte3();

                Assert.AreEqual(maxmath.reversebits(x), (byte3)(math.reversebits((uint3)x) >> (32 - 8)));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte4 x = rng.NextByte4();

                Assert.AreEqual(maxmath.reversebits(x), (byte4)(math.reversebits((uint4)x) >> (32 - 8)));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte8 x = rng.NextByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits((ulong)x[j]) >> (64 - 8));
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte16 x = rng.NextByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits((ulong)x[j]) >> (64 - 8));
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                byte32 x = rng.NextByte32();

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits((ulong)x[j]) >> (64 - 8));
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

                Assert.AreEqual(maxmath.reversebits(x), math.reversebits((ulong)x) >> (64 - 16));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort2 x = rng.NextUShort2();

                Assert.AreEqual(maxmath.reversebits(x), (ushort2)(math.reversebits((uint2)x) >> (32 - 16)));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort3 x = rng.NextUShort3();

                Assert.AreEqual(maxmath.reversebits(x), (ushort3)(math.reversebits((uint3)x) >> (32 - 16)));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort4 x = rng.NextUShort4();

                Assert.AreEqual(maxmath.reversebits(x), (ushort4)(math.reversebits((uint4)x) >> (32 - 16)));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                ushort8 x = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits((ulong)x[j]) >> (64 - 16));
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

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits((ulong)x[j]) >> (64 - 16));
                }
            }
        }


        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 64; i++)
            {
                uint8 x = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits((ulong)x[j]) >> (64 - 32));
                }
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong2 x = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits(x[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong3 x = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits(x[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 64; i++)
            {
                ulong4 x = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.reversebits(x)[j], math.reversebits(x[j]));
                }
            }
        }
    }
}