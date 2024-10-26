using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_l1clear
    {
        private static void TestByte(byte original, byte test)
        {
            int leading1s = maxmath.l1cnt(original);

            for (int j = 0; j < 8 - leading1s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (byte)j), maxmath.testbit(test, (byte)j));
            }
            for (int j = 8 - leading1s; j < 8; j++)
            {
                Assert.IsFalse(maxmath.testbit(test, (byte)j));
            }
        }

        private static void TestUShort(ushort original, ushort test)
        {
            int leading1s = maxmath.l1cnt(original);

            for (int j = 0; j < 16 - leading1s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (ushort)j), maxmath.testbit(test, (ushort)j));
            }
            for (int j = 16 - leading1s; j < 16; j++)
            {
                Assert.IsFalse(maxmath.testbit(test, (ushort)j));
            }
        }

        private static void TestUInt(uint original, uint test)
        {
            int leading1s = maxmath.l1cnt(original);

            for (int j = 0; j < 32 - leading1s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (uint)j), maxmath.testbit(test, (uint)j));
            }
            for (int j = 32 - leading1s; j < 32; j++)
            {
                Assert.IsFalse(maxmath.testbit(test, (uint)j));
            }
        }

        private static void TestULong(ulong original, ulong test)
        {
            int leading1s = maxmath.l1cnt(original);

            for (int j = 0; j < 64 - leading1s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (ulong)j), maxmath.testbit(test, (ulong)j));
            }
            for (int j = 64 - leading1s; j < 64; j++)
            {
                Assert.IsFalse(maxmath.testbit(test, (ulong)j));
            }
        }

        private static void TestUInt128(UInt128 original, UInt128 test)
        {
            int leading1s = maxmath.l1cnt(original);

            for (int j = 0; j < 128 - leading1s; j++)
            {
                Assert.AreEqual(maxmath.testbit(original, (uint)j), maxmath.testbit(test, (uint)j));
            }
            for (int j = 128 - leading1s; j < 128; j++)
            {
                Assert.IsFalse(maxmath.testbit(test, (uint)j));
            }
        }


        [Test]
        public static void _UInt128()
        {
            TestUInt128((UInt128)0, maxmath.l1clear((UInt128)0));
            TestUInt128(UInt128.MaxValue, maxmath.l1clear(UInt128.MaxValue));

            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 original = rng.NextUInt128();
                UInt128 test = maxmath.l1clear(original);

                TestUInt128(original, test);
            }
        }


        [Test]
        public static void _byte()
        {
            TestByte((byte)0, maxmath.l1clear((byte)0));
            TestByte(byte.MaxValue, maxmath.l1clear(byte.MaxValue));

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte original = rng.NextByte();
                byte test = maxmath.l1clear(original);

                TestByte(original, test);
            }
        }

        [Test]
        public static void _byte2()
        {
            TestByte((byte)0, maxmath.l1clear((byte2)0).x);
            TestByte(byte.MaxValue, maxmath.l1clear((byte2)byte.MaxValue).x);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 original = rng.NextByte2();
                byte2 test = maxmath.l1clear(original);

                for (int j = 0; j < 2; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            TestByte((byte)0, maxmath.l1clear((byte3)0).x);
            TestByte(byte.MaxValue, maxmath.l1clear((byte3)byte.MaxValue).x);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 original = rng.NextByte3();
                byte3 test = maxmath.l1clear(original);

                for (int j = 0; j < 3; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            TestByte((byte)0, maxmath.l1clear((byte4)0).x);
            TestByte(byte.MaxValue, maxmath.l1clear((byte4)byte.MaxValue).x);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 original = rng.NextByte4();
                byte4 test = maxmath.l1clear(original);

                for (int j = 0; j < 4; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            TestByte((byte)0, maxmath.l1clear((byte8)0).x0);
            TestByte(byte.MaxValue, maxmath.l1clear((byte8)byte.MaxValue).x0);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 original = rng.NextByte8();
                byte8 test = maxmath.l1clear(original);

                for (int j = 0; j < 8; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            TestByte((byte)0, maxmath.l1clear((byte16)0).x0);
            TestByte(byte.MaxValue, maxmath.l1clear((byte16)byte.MaxValue).x0);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 original = rng.NextByte16();
                byte16 test = maxmath.l1clear(original);

                for (int j = 0; j < 16; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            TestByte((byte)0, maxmath.l1clear((byte32)0).x0);
            TestByte(byte.MaxValue, maxmath.l1clear((byte32)byte.MaxValue).x0);

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 original = rng.NextByte32();
                byte32 test = maxmath.l1clear(original);

                for (int j = 0; j < 32; j++)
                {
                    TestByte(original[j], test[j]);
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            TestUShort((ushort)0, maxmath.l1clear((ushort)0));
            TestUShort(ushort.MaxValue, maxmath.l1clear(ushort.MaxValue));

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort original = rng.NextUShort();
                ushort test = maxmath.l1clear(original);

                TestUShort(original, test);
            }
        }

        [Test]
        public static void _ushort2()
        {
            TestUShort((ushort)0, maxmath.l1clear((ushort2)0).x);
            TestUShort(ushort.MaxValue, maxmath.l1clear((ushort2)ushort.MaxValue).x);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 original = rng.NextUShort2();
                ushort2 test = maxmath.l1clear(original);

                for (int j = 0; j < 2; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            TestUShort((ushort)0, maxmath.l1clear((ushort3)0).x);
            TestUShort(ushort.MaxValue, maxmath.l1clear((ushort3)ushort.MaxValue).x);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 original = rng.NextUShort3();
                ushort3 test = maxmath.l1clear(original);

                for (int j = 0; j < 3; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            TestUShort((ushort)0, maxmath.l1clear((ushort4)0).x);
            TestUShort(ushort.MaxValue, maxmath.l1clear((ushort4)ushort.MaxValue).x);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 original = rng.NextUShort4();
                ushort4 test = maxmath.l1clear(original);

                for (int j = 0; j < 4; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            TestUShort((ushort)0, maxmath.l1clear((ushort8)0).x0);
            TestUShort(ushort.MaxValue, maxmath.l1clear((ushort8)ushort.MaxValue).x0);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 original = rng.NextUShort8();
                ushort8 test = maxmath.l1clear(original);

                for (int j = 0; j < 8; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushorl16()
        {
            TestUShort((ushort)0, maxmath.l1clear((ushort16)0).x0);
            TestUShort(ushort.MaxValue, maxmath.l1clear((ushort16)ushort.MaxValue).x0);

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 original = rng.NextUShort16();
                ushort16 test = maxmath.l1clear(original);

                for (int j = 0; j < 16; j++)
                {
                    TestUShort(original[j], test[j]);
                }
            }
        }


        [Test]
        public static void _uint()
        {
            TestUInt((uint)0, maxmath.l1clear((uint)0));
            TestUInt(uint.MaxValue, maxmath.l1clear(uint.MaxValue));

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint original = rng.NextUInt();
                uint test = maxmath.l1clear(original);

                TestUInt(original, test);
            }
        }

        [Test]
        public static void _uint2()
        {
            TestUInt((uint)0, maxmath.l1clear((uint2)0).x);
            TestUInt(uint.MaxValue, maxmath.l1clear((uint2)uint.MaxValue).x);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 original = rng.NextUInt2();
                uint2 test = maxmath.l1clear(original);

                for (int j = 0; j < 2; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            TestUInt((uint)0, maxmath.l1clear((uint3)0).x);
            TestUInt(uint.MaxValue, maxmath.l1clear((uint3)uint.MaxValue).x);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 original = rng.NextUInt3();
                uint3 test = maxmath.l1clear(original);

                for (int j = 0; j < 3; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            TestUInt((uint)0, maxmath.l1clear((uint4)0).x);
            TestUInt(uint.MaxValue, maxmath.l1clear((uint4)uint.MaxValue).x);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 original = rng.NextUInt4();
                uint4 test = maxmath.l1clear(original);

                for (int j = 0; j < 4; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            TestUInt((uint)0, maxmath.l1clear((uint8)0).x0);
            TestUInt(uint.MaxValue, maxmath.l1clear((uint8)uint.MaxValue).x0);

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 original = rng.NextUInt8();
                uint8 test = maxmath.l1clear(original);

                for (int j = 0; j < 8; j++)
                {
                    TestUInt(original[j], test[j]);
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            TestULong((ulong)0, maxmath.l1clear((ulong)0));
            TestULong(ulong.MaxValue, maxmath.l1clear(ulong.MaxValue));

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong original = rng.NextULong();
                ulong test = maxmath.l1clear(original);

                TestULong(original, test);
            }
        }

        [Test]
        public static void _ulong2()
        {
            TestULong((ulong)0, maxmath.l1clear((ulong2)0).x);
            TestULong(ulong.MaxValue, maxmath.l1clear((ulong2)ulong.MaxValue).x);

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 original = rng.NextULong2();
                ulong2 test = maxmath.l1clear(original);

                for (int j = 0; j < 2; j++)
                {
                    TestULong(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            TestULong((ulong)0, maxmath.l1clear((ulong3)0).x);
            TestULong(ulong.MaxValue, maxmath.l1clear((ulong3)ulong.MaxValue).x);

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 original = rng.NextULong3();
                ulong3 test = maxmath.l1clear(original);

                for (int j = 0; j < 3; j++)
                {
                    TestULong(original[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            TestULong((ulong)0, maxmath.l1clear((ulong4)0).x);
            TestULong(ulong.MaxValue, maxmath.l1clear((ulong4)ulong.MaxValue).x);

            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 original = rng.NextULong4();
                ulong4 test = maxmath.l1clear(original);

                for (int j = 0; j < 4; j++)
                {
                    TestULong(original[j], test[j]);
                }
            }
        }
    }
}
