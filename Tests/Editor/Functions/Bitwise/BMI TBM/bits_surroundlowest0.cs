using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    unsafe public static class f_bits_surroundlowest0
    {
        private static void TestByte(byte original, byte testValue)
        {
            Assert.AreEqual(testValue, (byte)~bits_extractlowest0(original));
        }

        private static void TestUShort(ushort original, ushort testValue)
        {
            Assert.AreEqual(testValue, (ushort)~bits_extractlowest0(original));
        }

        private static void TestUInt(uint original, uint testValue)
        {
            Assert.AreEqual(testValue, ~bits_extractlowest0(original));
        }

        private static void TestULong(ulong original, ulong testValue)
        {
            Assert.AreEqual(testValue, ~bits_extractlowest0(original));
        }

        private static void TestUInt128(UInt128 original, UInt128 testValue)
        {
            Assert.AreEqual(testValue, ~bits_extractlowest0(original));
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 32; i++)
            {
                UInt128 test = rng.NextUInt128();

                TestUInt128(test, bits_surroundlowest0(test));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte test = rng.NextByte();

                TestByte(test, bits_surroundlowest0(test));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 test = rng.NextByte2();
                byte2 result = bits_surroundlowest0(test);

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
                byte3 result = bits_surroundlowest0(test);

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
                byte4 result = bits_surroundlowest0(test);

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
                byte8 result = bits_surroundlowest0(test);

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
                byte16 result = bits_surroundlowest0(test);

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
                byte32 result = bits_surroundlowest0(test);

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

                TestUShort(test, bits_surroundlowest0(test));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 test = rng.NextUShort2();
                ushort2 result = bits_surroundlowest0(test);

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
                ushort3 result = bits_surroundlowest0(test);

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
                ushort4 result = bits_surroundlowest0(test);

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
                ushort8 result = bits_surroundlowest0(test);

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
                ushort16 result = bits_surroundlowest0(test);

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

                TestUInt(test, bits_surroundlowest0(test));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 test = rng.NextUInt2();
                uint2 result = bits_surroundlowest0(test);

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
                uint3 result = bits_surroundlowest0(test);

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
                uint4 result = bits_surroundlowest0(test);

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
                uint8 result = bits_surroundlowest0(test);

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

                TestULong(test, bits_surroundlowest0(test));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 test = rng.NextULong2();
                ulong2 result = bits_surroundlowest0(test);

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
                ulong3 result = bits_surroundlowest0(test);

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
                ulong4 result = bits_surroundlowest0(test);

                for (int j = 0; j < 4; j++)
                {
                    TestULong(test[j], result[j]);
                }
            }
        }
    }
}
