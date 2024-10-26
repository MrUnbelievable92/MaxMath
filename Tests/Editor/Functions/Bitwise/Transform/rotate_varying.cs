using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_rotate_varying
    {
        [Test]
        public static void ror_sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16(0, 8);

                sbyte16 test = maxmath.ror(l, r);
                sbyte16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = maxmath.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32(0, 8);

                sbyte32 test = maxmath.ror(l, r);
                sbyte32 std = default;

                for (int j = 0; j < 32; j++)
                {
                    std[j] = maxmath.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8(0, 16);

                short8 test = maxmath.ror(l, r);
                short8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = maxmath.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16(0, 16);

                short16 test = maxmath.ror(l, r);
                short16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = maxmath.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint4 l = rng.NextUInt4();
                uint4 r = rng.NextUInt4(0, 32);

                uint4 test = maxmath.ror(l, r);
                uint4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint8 l = rng.NextUInt8();
                uint8 r = rng.NextUInt8(0, 32);

                uint8 test = maxmath.ror(l, r);
                uint8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong2 l = rng.NextULong2();
                ulong2 r = rng.NextULong2(0, 64);

                ulong2 test = maxmath.ror(l, r);
                ulong2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong4 l = rng.NextULong4();
                ulong4 r = rng.NextULong4(0, 64);

                ulong4 test = maxmath.ror(l, r);
                ulong4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }
        [Test]
        public static void rol_sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16(0, 8);

                sbyte16 test = maxmath.rol(l, r);
                sbyte16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = maxmath.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32(0, 8);

                sbyte32 test = maxmath.rol(l, r);
                sbyte32 std = default;

                for (int j = 0; j < 32; j++)
                {
                    std[j] = maxmath.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8(0, 16);

                short8 test = maxmath.rol(l, r);
                short8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = maxmath.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16(0, 16);

                short16 test = maxmath.rol(l, r);
                short16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = maxmath.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint4 l = rng.NextUInt4();
                uint4 r = rng.NextUInt4(0, 32);

                uint4 test = maxmath.rol(l, r);
                uint4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint8 l = rng.NextUInt8();
                uint8 r = rng.NextUInt8(0, 32);

                uint8 test = maxmath.rol(l, r);
                uint8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong2 l = rng.NextULong2();
                ulong2 r = rng.NextULong2(0, 64);

                ulong2 test = maxmath.rol(l, r);
                ulong2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong4 l = rng.NextULong4();
                ulong4 r = rng.NextULong4(0, 64);

                ulong4 test = maxmath.rol(l, r);
                ulong4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }
    }
}