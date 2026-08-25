using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_rotate_varying
    {
        [Test]
        public static void ror_sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2(0, 8);

                sbyte2 test = math.ror(l, r);
                sbyte2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3(0, 8);

                sbyte3 test = math.ror(l, r);
                sbyte3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4(0, 8);

                sbyte4 test = math.ror(l, r);
                sbyte4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8(0, 8);

                sbyte8 test = math.ror(l, r);
                sbyte8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16(0, 8);

                sbyte16 test = math.ror(l, r);
                sbyte16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
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

                sbyte32 test = math.ror(l, r);
                sbyte32 std = default;

                for (int j = 0; j < 32; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2(0, 16);

                short2 test = math.ror(l, r);
                short2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3(0, 16);

                short3 test = math.ror(l, r);
                short3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4(0, 16);

                short4 test = math.ror(l, r);
                short4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
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

                short8 test = math.ror(l, r);
                short8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
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

                short16 test = math.ror(l, r);
                short16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint2 l = rng.NextUInt2();
                uint2 r = rng.NextUInt2(0, 32);

                uint2 test = math.ror(l, r);
                uint2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint3 l = rng.NextUInt3();
                uint3 r = rng.NextUInt3(0, 32);

                uint3 test = math.ror(l, r);
                uint3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
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

                uint4 test = math.ror(l, r);
                uint4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

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

                uint8 test = math.ror(l, r);
                uint8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

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

                ulong2 test = math.ror(l, r);
                ulong2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong3 l = rng.NextULong3();
                ulong3 r = rng.NextULong3(0, 63);

                ulong3 test = math.ror(l, r);
                ulong3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
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

                ulong4 test = math.ror(l, r);
                ulong4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }


        [Test]
        public static void rol_sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2(0, 8);

                sbyte2 test = math.rol(l, r);
                sbyte2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3(0, 8);

                sbyte3 test = math.rol(l, r);
                sbyte3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4(0, 8);

                sbyte4 test = math.rol(l, r);
                sbyte4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8(0, 8);

                sbyte8 test = math.rol(l, r);
                sbyte8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
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

                sbyte16 test = math.rol(l, r);
                sbyte16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
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

                sbyte32 test = math.rol(l, r);
                sbyte32 std = default;

                for (int j = 0; j < 32; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2(0, 16);

                short2 test = math.rol(l, r);
                short2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3(0, 16);

                short3 test = math.rol(l, r);
                short3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4(0, 16);

                short4 test = math.rol(l, r);
                short4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
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

                short8 test = math.rol(l, r);
                short8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
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

                short16 test = math.rol(l, r);
                short16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint2 l = rng.NextUInt2();
                uint2 r = rng.NextUInt2(0, 32);

                uint2 test = math.rol(l, r);
                uint2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint3 l = rng.NextUInt3();
                uint3 r = rng.NextUInt3(0, 32);

                uint3 test = math.rol(l, r);
                uint3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
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

                uint4 test = math.rol(l, r);
                uint4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

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

                uint8 test = math.rol(l, r);
                uint8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

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

                ulong2 test = math.rol(l, r);
                ulong2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong3 l = rng.NextULong3();
                ulong3 r = rng.NextULong3(0, 63);

                ulong3 test = math.rol(l, r);
                ulong3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
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

                ulong4 test = math.rol(l, r);
                ulong4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }
        [Test]
        public static void ror_byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte2 l = rng.NextByte2();
                byte2 r = rng.NextByte2(0, 8);

                byte2 test = math.ror(l, r);
                byte2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte3 l = rng.NextByte3();
                byte3 r = rng.NextByte3(0, 8);

                byte3 test = math.ror(l, r);
                byte3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte4 l = rng.NextByte4();
                byte4 r = rng.NextByte4(0, 8);

                byte4 test = math.ror(l, r);
                byte4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte8 l = rng.NextByte8();
                byte8 r = rng.NextByte8(0, 8);

                byte8 test = math.ror(l, r);
                byte8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte16 l = rng.NextByte16();
                byte16 r = rng.NextByte16(0, 8);

                byte16 test = math.ror(l, r);
                byte16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte32 l = rng.NextByte32();
                byte32 r = rng.NextByte32(0, 8);

                byte32 test = math.ror(l, r);
                byte32 std = default;

                for (int j = 0; j < 32; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort2 l = rng.NextUShort2();
                ushort2 r = rng.NextUShort2(0, 16);

                ushort2 test = math.ror(l, r);
                ushort2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort3 l = rng.NextUShort3();
                ushort3 r = rng.NextUShort3(0, 16);

                ushort3 test = math.ror(l, r);
                ushort3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort4 l = rng.NextUShort4();
                ushort4 r = rng.NextUShort4(0, 16);

                ushort4 test = math.ror(l, r);
                ushort4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort8 l = rng.NextUShort8();
                ushort8 r = rng.NextUShort8(0, 16);

                ushort8 test = math.ror(l, r);
                ushort8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort16 l = rng.NextUShort16();
                ushort16 r = rng.NextUShort16(0, 16);

                ushort16 test = math.ror(l, r);
                ushort16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.ror(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2(0, 32);

                int2 test = math.ror(l, r);
                int2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3(0, 32);

                int3 test = math.ror(l, r);
                int3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4(0, 32);

                int4 test = math.ror(l, r);
                int4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8(0, 32);

                int8 test = math.ror(l, r);
                int8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2(0, 64);

                long2 test = math.ror(l, r);
                long2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3(0, 63);

                long3 test = math.ror(l, r);
                long3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void ror_long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4(0, 64);

                long4 test = math.ror(l, r);
                long4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.ror(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.ror(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }


        [Test]
        public static void rol_byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte2 l = rng.NextByte2();
                byte2 r = rng.NextByte2(0, 8);

                byte2 test = math.rol(l, r);
                byte2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte3 l = rng.NextByte3();
                byte3 r = rng.NextByte3(0, 8);

                byte3 test = math.rol(l, r);
                byte3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte4 l = rng.NextByte4();
                byte4 r = rng.NextByte4(0, 8);

                byte4 test = math.rol(l, r);
                byte4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte8 l = rng.NextByte8();
                byte8 r = rng.NextByte8(0, 8);

                byte8 test = math.rol(l, r);
                byte8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte16 l = rng.NextByte16();
                byte16 r = rng.NextByte16(0, 8);

                byte16 test = math.rol(l, r);
                byte16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte32 l = rng.NextByte32();
                byte32 r = rng.NextByte32(0, 8);

                byte32 test = math.rol(l, r);
                byte32 std = default;

                for (int j = 0; j < 32; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort2 l = rng.NextUShort2();
                ushort2 r = rng.NextUShort2(0, 16);

                ushort2 test = math.rol(l, r);
                ushort2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort3 l = rng.NextUShort3();
                ushort3 r = rng.NextUShort3(0, 16);

                ushort3 test = math.rol(l, r);
                ushort3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort4 l = rng.NextUShort4();
                ushort4 r = rng.NextUShort4(0, 16);

                ushort4 test = math.rol(l, r);
                ushort4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort8 l = rng.NextUShort8();
                ushort8 r = rng.NextUShort8(0, 16);

                ushort8 test = math.rol(l, r);
                ushort8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort16 l = rng.NextUShort16();
                ushort16 r = rng.NextUShort16(0, 16);

                ushort16 test = math.rol(l, r);
                ushort16 std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 16; j++)
                {
                    std[j] = math.rol(l[j], r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2(0, 32);

                int2 test = math.rol(l, r);
                int2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3(0, 32);

                int3 test = math.rol(l, r);
                int3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4(0, 32);

                int4 test = math.rol(l, r);
                int4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8(0, 32);

                int8 test = math.rol(l, r);
                int8 std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 8; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2(0, 64);

                long2 test = math.rol(l, r);
                long2 std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 2; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3(0, 63);

                long3 test = math.rol(l, r);
                long3 std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 3; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }

        [Test]
        public static void rol_long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4(0, 64);

                long4 test = math.rol(l, r);
                long4 std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);

                r = math.floormultiple(r, 8);
                test = math.rol(l, r);
                std = default;

                for (int j = 0; j < 4; j++)
                {
                    std[j] = math.rol(l[j], (int)r[j]);
                }

                Assert.AreEqual(std, test);
            }
        }
    }
}