using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_lzfill
    {
        private static void TestByte(byte original, byte test)
        {
            int leading0s = maxmath.lzcnt(original);

            for (int j = 0; j < 8 - leading0s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (byte)j), maxmath.testbit(test, (byte)j));
            }
            for (int j = 8 - leading0s; j < 8; j++)
            {
                Assert.IsTrue(maxmath.testbit(test, (byte)j));
            }
        }

        private static void TestUShort(ushort original, ushort test)
        {
            int leading0s = maxmath.lzcnt(original);

            for (int j = 0; j < 16 - leading0s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (ushort)j), maxmath.testbit(test, (ushort)j));
            }
            for (int j = 16 - leading0s; j < 16; j++)
            {
                Assert.IsTrue(maxmath.testbit(test, (ushort)j));
            }
        }

        private static void TestUInt(uint original, uint test)
        {
            int leading0s = math.lzcnt(original);

            for (int j = 0; j < 32 - leading0s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (uint)j), maxmath.testbit(test, (uint)j));
            }
            for (int j = 32 - leading0s; j < 32; j++)
            {
                Assert.IsTrue(maxmath.testbit(test, (uint)j));
            }
        }

        private static void TestULong(ulong original, ulong test)
        {
            int leading0s = math.lzcnt(original);

            for (int j = 0; j < 64 - leading0s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (ulong)j), maxmath.testbit(test, (ulong)j));
            }
            for (int j = 64 - leading0s; j < 64; j++)
            {
                Assert.IsTrue(maxmath.testbit(test, (ulong)j));
            }
        }

        private static void TestUInt128(UInt128 original, UInt128 test)
        {
            int leading0s = maxmath.lzcnt(original);

            for (int j = 0; j < 128 - leading0s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (uint)j), maxmath.testbit(test, (uint)j));
            }
            for (int j = 128 - leading0s; j < 128; j++)
            {
                Assert.IsTrue(maxmath.testbit(test, (uint)j));
            }
        }


        [Test]
        public static void _UInt128()
        {
            TestUInt128((UInt128)0, maxmath.lzfill((UInt128)0));
            TestUInt128(UInt128.MaxValue, maxmath.lzfill(UInt128.MaxValue));

            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 original = rng.NextUInt128();
                UInt128 test = maxmath.lzfill(original);

                TestUInt128(original, test);
            }
        }


        [Test]
        public static void _byte()
        {
            TestByte((byte)0, maxmath.lzfill((byte)0));
            TestByte(byte.MaxValue, maxmath.lzfill(byte.MaxValue));

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte original = rng.NextByte();
                byte test = maxmath.lzfill(original);

                TestByte(original, test);
            }
        }

        [Test]
        public static void _byte2()
        {
            TestByte((byte)0, maxmath.lzfill((byte2)0).x);
            TestByte(byte.MaxValue, maxmath.lzfill((byte2)byte.MaxValue).x);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 original = rng.NextByte2();
                byte2 test = maxmath.lzfill(original);

                for (int j = 0; j < 2; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            TestByte((byte)0, maxmath.lzfill((byte3)0).x);
            TestByte(byte.MaxValue, maxmath.lzfill((byte3)byte.MaxValue).x);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 original = rng.NextByte3();
                byte3 test = maxmath.lzfill(original);

                for (int j = 0; j < 3; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            TestByte((byte)0, maxmath.lzfill((byte4)0).x);
            TestByte(byte.MaxValue, maxmath.lzfill((byte4)byte.MaxValue).x);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 original = rng.NextByte4();
                byte4 test = maxmath.lzfill(original);

                for (int j = 0; j < 4; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            TestByte((byte)0, maxmath.lzfill((byte8)0).x0);
            TestByte(byte.MaxValue, maxmath.lzfill((byte8)byte.MaxValue).x0);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 original = rng.NextByte8();
                byte8 test = maxmath.lzfill(original);

                for (int j = 0; j < 8; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            TestByte((byte)0, maxmath.lzfill((byte16)0).x0);
            TestByte(byte.MaxValue, maxmath.lzfill((byte16)byte.MaxValue).x0);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 original = rng.NextByte16();
                byte16 test = maxmath.lzfill(original);

                for (int j = 0; j < 16; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            TestByte((byte)0, maxmath.lzfill((byte32)0).x0);
            TestByte(byte.MaxValue, maxmath.lzfill((byte32)byte.MaxValue).x0);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 original = rng.NextByte32();
                byte32 test = maxmath.lzfill(original);

                for (int j = 0; j < 32; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            TestUShort((ushort)0, maxmath.lzfill((ushort)0));
            TestUShort(ushort.MaxValue, maxmath.lzfill(ushort.MaxValue));

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort original = rng.NextUShort();
                ushort test = maxmath.lzfill(original);

                TestUShort(original, test);
            }
        }

        [Test]
        public static void _ushort2()
        {
            TestUShort((ushort)0, maxmath.lzfill((ushort2)0).x);
            TestUShort(ushort.MaxValue, maxmath.lzfill((ushort2)ushort.MaxValue).x);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 original = rng.NextUShort2();
                ushort2 test = maxmath.lzfill(original);

                for (int j = 0; j < 2; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            TestUShort((ushort)0, maxmath.lzfill((ushort3)0).x);
            TestUShort(ushort.MaxValue, maxmath.lzfill((ushort3)ushort.MaxValue).x);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 original = rng.NextUShort3();
                ushort3 test = maxmath.lzfill(original);

                for (int j = 0; j < 3; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            TestUShort((ushort)0, maxmath.lzfill((ushort4)0).x);
            TestUShort(ushort.MaxValue, maxmath.lzfill((ushort4)ushort.MaxValue).x);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 original = rng.NextUShort4();
                ushort4 test = maxmath.lzfill(original);

                for (int j = 0; j < 4; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            TestUShort((ushort)0, maxmath.lzfill((ushort8)0).x0);
            TestUShort(ushort.MaxValue, maxmath.lzfill((ushort8)ushort.MaxValue).x0);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 original = rng.NextUShort8();
                ushort8 test = maxmath.lzfill(original);

                for (int j = 0; j < 8; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushorlz6()
        {
            TestUShort((ushort)0, maxmath.lzfill((ushort16)0).x0);
            TestUShort(ushort.MaxValue, maxmath.lzfill((ushort16)ushort.MaxValue).x0);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 original = rng.NextUShort16();
                ushort16 test = maxmath.lzfill(original);

                for (int j = 0; j < 16; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }


        [Test]
        public static void _uint()
        {
            TestUInt((uint)0, maxmath.lzfill((uint)0));
            TestUInt(uint.MaxValue, maxmath.lzfill(uint.MaxValue));

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint original = rng.NextUInt();
                uint test = maxmath.lzfill(original);

                TestUInt(original, test);
            }
        }

        [Test]
        public static void _uint2()
        {
            TestUInt((uint)0, maxmath.lzfill((uint2)0).x);
            TestUInt(uint.MaxValue, maxmath.lzfill((uint2)uint.MaxValue).x);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 original = rng.NextUInt2();
                uint2 test = maxmath.lzfill(original);

                for (int j = 0; j < 2; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            TestUInt((uint)0, maxmath.lzfill((uint3)0).x);
            TestUInt(uint.MaxValue, maxmath.lzfill((uint3)uint.MaxValue).x);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 original = rng.NextUInt3();
                uint3 test = maxmath.lzfill(original);

                for (int j = 0; j < 3; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            TestUInt((uint)0, maxmath.lzfill((uint4)0).x);
            TestUInt(uint.MaxValue, maxmath.lzfill((uint4)uint.MaxValue).x);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 original = rng.NextUInt4();
                uint4 test = maxmath.lzfill(original);

                for (int j = 0; j < 4; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            TestUInt((uint)0, maxmath.lzfill((uint8)0).x0);
            TestUInt(uint.MaxValue, maxmath.lzfill((uint8)uint.MaxValue).x0);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 original = rng.NextUInt8();
                uint8 test = maxmath.lzfill(original);

                for (int j = 0; j < 8; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            TestULong((ulong)0, maxmath.lzfill((ulong)0));
            TestULong(ulong.MaxValue, maxmath.lzfill(ulong.MaxValue));

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong original = rng.NextULong();
                ulong test = maxmath.lzfill(original);

                TestULong(original, test);
            }
        }

        [Test]
        public static void _ulong2()
        {
            TestULong((ulong)0, maxmath.lzfill((ulong2)0).x);
            TestULong(ulong.MaxValue, maxmath.lzfill((ulong2)ulong.MaxValue).x);

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 original = rng.NextULong2();
                ulong2 test = maxmath.lzfill(original);

                for (int j = 0; j < 2; j++)
                {
                    TestULong(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            TestULong((ulong)0, maxmath.lzfill((ulong3)0).x);
            TestULong(ulong.MaxValue, maxmath.lzfill((ulong3)ulong.MaxValue).x);

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 original = rng.NextULong3();
                ulong3 test = maxmath.lzfill(original);

                for (int j = 0; j < 3; j++)
                {
                    TestULong(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            TestULong((ulong)0, maxmath.lzfill((ulong4)0).x);
            TestULong(ulong.MaxValue, maxmath.lzfill((ulong4)ulong.MaxValue).x);

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 original = rng.NextULong4();
                ulong4 test = maxmath.lzfill(original);

                for (int j = 0; j < 4; j++)
                {
                    TestULong(original[j], test[j]);
                }
            }
        }
    }
}