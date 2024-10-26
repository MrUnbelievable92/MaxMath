using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;
using static Unity.Mathematics.math;

namespace MaxMath.Tests
{
    unsafe public static class f_countbits
    {
        private static void TestByte(byte original, byte testValue)
        {
            int ones = 0;

            for (int i = 0; i < 8; i++)
            {
                ones += (original >> i) & 1;
            }

            Assert.AreEqual((byte)ones, testValue);
        }

        private static void TestUShort(ushort original, ushort testValue)
        {
            int ones = 0;

            for (int i = 0; i < 16; i++)
            {
                ones += (original >> i) & 1;
            }

            Assert.AreEqual((ushort)ones, testValue);
        }

        private static void TestUInt(uint original, uint testValue)
        {
            uint ones = 0;

            for (int i = 0; i < 32; i++)
            {
                ones += (original >> i) & 1;
            }

            Assert.AreEqual((uint)ones, testValue);
        }

        private static void TestULong(ulong original, ulong testValue)
        {
            ulong ones = 0;

            for (int i = 0; i < 64; i++)
            {
                ones += (original >> i) & 1;
            }

            Assert.AreEqual((ulong)ones, testValue);
        }

        private static void TestUInt128(UInt128 original, UInt128 testValue)
        {
            UInt128 ones = 0;

            for (int i = 0; i < 128; i++)
            {
                ones += (original >> i) & 1;
            }

            Assert.AreEqual((UInt128)ones, testValue);
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 test = rng.NextUInt128();

                TestUInt128(test, (UInt128)countbits(test));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte test = rng.NextByte();

                TestByte(test, (byte)countbits(test));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 test = rng.NextByte2();
                byte2 result = countbits(test);

                for (int j = 0; j < 2; j++)
                {
                    TestByte(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 test = rng.NextByte3();
                byte3 result = countbits(test);

                for (int j = 0; j < 3; j++)
                {
                    TestByte(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 test = rng.NextByte4();
                byte4 result = countbits(test);

                for (int j = 0; j < 4; j++)
                {
                    TestByte(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 test = rng.NextByte8();
                byte8 result = countbits(test);

                for (int j = 0; j < 8; j++)
                {
                    TestByte(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 test = rng.NextByte16();
                byte16 result = countbits(test);

                for (int j = 0; j < 16; j++)
                {
                    TestByte(test[j], result[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 test = rng.NextByte32();
                byte32 result = countbits(test);

                for (int j = 0; j < 32; j++)
                {
                    TestByte(test[j], result[j]);
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort test = rng.NextUShort();

                TestUShort(test, (ushort)countbits(test));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 test = rng.NextUShort2();
                ushort2 result = countbits(test);

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
                ushort3 result = countbits(test);

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
                ushort4 result = countbits(test);

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
                ushort8 result = countbits(test);

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
                ushort16 result = countbits(test);

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

                TestUInt(test, (uint)countbits(test));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 test = rng.NextUInt2();
                uint2 result = (uint2)countbits(test);

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
                uint3 result = (uint3)countbits(test);

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
                uint4 result = (uint4)countbits(test);

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
                uint8 result = (uint8)countbits(test);

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

                TestULong(test, (ulong)countbits(test));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 test = rng.NextULong2();
                ulong2 result = countbits(test);

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
                ulong3 result = countbits(test);

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
                ulong4 result = countbits(test);

                for (int j = 0; j < 4; j++)
                {
                    TestULong(test[j], result[j]);
                }
            }
        }
    }
}
