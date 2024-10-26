using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    unsafe public static class f_reversebytes
    {
        private static void TestUShort(ushort original, ushort testValue)
        {
            Assert.AreEqual(0xFF & (original >> (1 * 8)),   0xFF & (testValue >> (0 * 8)));
            Assert.AreEqual(0xFF & (original >> (0 * 8)),   0xFF & (testValue >> (1 * 8)));
        }

        private static void TestUInt(uint original, uint testValue)
        {
            Assert.AreEqual(0xFF & (original >> (3 * 8)),   0xFF & (testValue >> (0 * 8)));
            Assert.AreEqual(0xFF & (original >> (2 * 8)),   0xFF & (testValue >> (1 * 8)));
            Assert.AreEqual(0xFF & (original >> (1 * 8)),   0xFF & (testValue >> (2 * 8)));
            Assert.AreEqual(0xFF & (original >> (0 * 8)),   0xFF & (testValue >> (3 * 8)));
        }

        private static void TestULong(ulong original, ulong testValue)
        {
            Assert.AreEqual(0xFF & (original >> (7 * 8)),   0xFF & (testValue >> (0 * 8)));
            Assert.AreEqual(0xFF & (original >> (6 * 8)),   0xFF & (testValue >> (1 * 8)));
            Assert.AreEqual(0xFF & (original >> (5 * 8)),   0xFF & (testValue >> (2 * 8)));
            Assert.AreEqual(0xFF & (original >> (4 * 8)),   0xFF & (testValue >> (3 * 8)));
            Assert.AreEqual(0xFF & (original >> (3 * 8)),   0xFF & (testValue >> (4 * 8)));
            Assert.AreEqual(0xFF & (original >> (2 * 8)),   0xFF & (testValue >> (5 * 8)));
            Assert.AreEqual(0xFF & (original >> (1 * 8)),   0xFF & (testValue >> (6 * 8)));
            Assert.AreEqual(0xFF & (original >> (0 * 8)),   0xFF & (testValue >> (7 * 8)));
        }

        private static void TestUInt128(UInt128 original, UInt128 testValue)
        {
            Assert.AreEqual(0xFF & (original >> (15 * 8)),  0xFF & (testValue >> (0 * 8)));
            Assert.AreEqual(0xFF & (original >> (14 * 8)),  0xFF & (testValue >> (1 * 8)));
            Assert.AreEqual(0xFF & (original >> (13 * 8)),  0xFF & (testValue >> (2 * 8)));
            Assert.AreEqual(0xFF & (original >> (12 * 8)),  0xFF & (testValue >> (3 * 8)));
            Assert.AreEqual(0xFF & (original >> (11 * 8)),  0xFF & (testValue >> (4 * 8)));
            Assert.AreEqual(0xFF & (original >> (10 * 8)),  0xFF & (testValue >> (5 * 8)));
            Assert.AreEqual(0xFF & (original >> (9 * 8)),   0xFF & (testValue >> (6 * 8)));
            Assert.AreEqual(0xFF & (original >> (8 * 8)),   0xFF & (testValue >> (7 * 8)));
            Assert.AreEqual(0xFF & (original >> (7 * 8)),   0xFF & (testValue >> (8 * 8)));
            Assert.AreEqual(0xFF & (original >> (6 * 8)),   0xFF & (testValue >> (9 * 8)));
            Assert.AreEqual(0xFF & (original >> (5 * 8)),   0xFF & (testValue >> (10 * 8)));
            Assert.AreEqual(0xFF & (original >> (4 * 8)),   0xFF & (testValue >> (11 * 8)));
            Assert.AreEqual(0xFF & (original >> (3 * 8)),   0xFF & (testValue >> (12 * 8)));
            Assert.AreEqual(0xFF & (original >> (2 * 8)),   0xFF & (testValue >> (13 * 8)));
            Assert.AreEqual(0xFF & (original >> (1 * 8)),   0xFF & (testValue >> (14 * 8)));
            Assert.AreEqual(0xFF & (original >> (0 * 8)),   0xFF & (testValue >> (15 * 8)));
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 test = rng.NextUInt128();

                TestUInt128(test, reversebytes(test));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort test = rng.NextUShort();

                TestUShort(test, reversebytes(test));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 test = rng.NextUShort2();
                ushort2 result = reversebytes(test);

                for (int j = 0; j < 2; j++)
                {
                    TestUShort(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 test = rng.NextUShort3();
                ushort3 result = reversebytes(test);

                for (int j = 0; j < 3; j++)
                {
                    TestUShort(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 test = rng.NextUShort4();
                ushort4 result = reversebytes(test);

                for (int j = 0; j < 4; j++)
                {
                    TestUShort(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 test = rng.NextUShort8();
                ushort8 result = reversebytes(test);

                for (int j = 0; j < 8; j++)
                {
                    TestUShort(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 test = rng.NextUShort16();
                ushort16 result = reversebytes(test);

                for (int j = 0; j < 16; j++)
                {
                    TestUShort(test[j], result[j]);
                }
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint test = rng.NextUInt();

                TestUInt(test, reversebytes(test));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 test = rng.NextUInt2();
                uint2 result = reversebytes(test);

                for (int j = 0; j < 2; j++)
                {
                    TestUInt(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 test = rng.NextUInt3();
                uint3 result = reversebytes(test);

                for (int j = 0; j < 3; j++)
                {
                    TestUInt(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 test = rng.NextUInt4();
                uint4 result = reversebytes(test);

                for (int j = 0; j < 4; j++)
                {
                    TestUInt(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 test = rng.NextUInt8();
                uint8 result = reversebytes(test);

                for (int j = 0; j < 8; j++)
                {
                    TestUInt(test[j], result[j]);
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong test = rng.NextULong();

                TestULong(test, reversebytes(test));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 test = rng.NextULong2();
                ulong2 result = reversebytes(test);

                for (int j = 0; j < 2; j++)
                {
                    TestULong(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 test = rng.NextULong3();
                ulong3 result = reversebytes(test);

                for (int j = 0; j < 3; j++)
                {
                    TestULong(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 test = rng.NextULong4();
                ulong4 result = reversebytes(test);

                for (int j = 0; j < 4; j++)
                {
                    TestULong(test[j], result[j]);
                }
            }
        }
    }
}
