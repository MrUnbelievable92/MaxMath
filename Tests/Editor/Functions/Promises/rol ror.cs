using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_rotatevarying
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte2 random = rng.NextByte2();
                byte2 shift  = rng.NextByte2(0, 8);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte3 random = rng.NextByte3();
                byte3 shift  = rng.NextByte3(0, 8);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte4 random = rng.NextByte4();
                byte4 shift  = rng.NextByte4(0, 8);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte8 random = rng.NextByte8();
                byte8 shift  = rng.NextByte8(0, 8);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte16 random = rng.NextByte16();
                byte16 shift  = rng.NextByte16(0, 8);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte32 random = rng.NextByte32();
                byte32 shift  = rng.NextByte32(0, 8);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort2 random = rng.NextUShort2();
                ushort2 shift  = rng.NextUShort2(0, 16);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 random = rng.NextUShort3();
                ushort3 shift  = rng.NextUShort3(0, 16);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 random = rng.NextUShort4();
                ushort4 shift  = rng.NextUShort4(0, 16);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 random = rng.NextUShort8();
                ushort8 shift  = rng.NextUShort8(0, 16);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 random = rng.NextUShort16();
                ushort16 shift  = rng.NextUShort16(0, 16);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint2 random = rng.NextUInt2();
                uint2 shift  = rng.NextUInt2(0, 32);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint3 random = rng.NextUInt3();
                uint3 shift  = rng.NextUInt3(0, 32);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint4 random = rng.NextUInt4();
                uint4 shift  = rng.NextUInt4(0, 32);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint8 random = rng.NextUInt8();
                uint8 shift  = rng.NextUInt8(0, 32);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong2 random = rng.NextULong2();
                ulong2 shift  = rng.NextULong2(0, 64);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong3 random = rng.NextULong3();
                ulong3 shift  = rng.NextULong3(0, 64);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong4 random = rng.NextULong4();
                ulong4 shift  = rng.NextULong4(0, 64);

                Assert.AreEqual(maxmath.rol(random, shift), maxmath.rol(random, shift, Promise.NoOverflow));
                Assert.AreEqual(maxmath.ror(random, shift), maxmath.ror(random, shift, Promise.NoOverflow));
            }
        }
    }
}
