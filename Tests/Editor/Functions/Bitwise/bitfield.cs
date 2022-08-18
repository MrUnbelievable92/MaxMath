using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class bitfield
    {
        public static void testbitfield16(ushort xy, byte[] originalValues)
        {
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(byte.MaxValue & (xy >> (8 * i)), originalValues[i]);
            }
        }

        public static void testbitfield32(uint xy, byte[] originalValues)
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(byte.MaxValue & (xy >> (8 * i)), originalValues[i]);
            }
        }

        public static void testbitfield64(ulong xy, byte[] originalValues)
        {
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual(byte.MaxValue & (xy >> (8 * i)), originalValues[i]);
            }
        }

        public static void testbitfield128(UInt128 xy, byte[] originalValues)
        {
            for (int i = 0; i < 16; i++)
            {
                Assert.AreEqual((byte)(byte.MaxValue & (xy >> (8 * i))), originalValues[i]);
            }
        }

        public static void testbitfield32(uint xy, ushort[] originalValues)
        {
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(ushort.MaxValue & (xy >> (16 * i)), originalValues[i]);
            }
        }

        public static void testbitfield64(ulong xy, ushort[] originalValues)
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(ushort.MaxValue & (xy >> (16 * i)), originalValues[i]);
            }
        }

        public static void testbitfield128(UInt128 xy, ushort[] originalValues)
        {
            for (int i = 0; i < 8; i++)
            {
                Assert.AreEqual((ushort)(ushort.MaxValue & (xy >> (16 * i))), originalValues[i]);
            }
        }

        public static void testbitfield64(ulong xy, uint[] originalValues)
        {
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(uint.MaxValue & (xy >> (32 * i)), originalValues[i]);
            }
        }

        public static void testbitfield128(UInt128 xy, uint[] originalValues)
        {
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual((uint)(uint.MaxValue & (xy >> (32 * i))), originalValues[i]);
            }
        }


        public static void testbitfield128(UInt128 xy, ulong[] originalValues)
        {
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(ulong.MaxValue & (xy >> (64 * i)), originalValues[i]);
            }
        }

        [Test]
        public static void __byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[2];
                for (int j = 0; j < 2; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ushort bf = maxmath.bitfield(bytes[0], bytes[1]);
                testbitfield16(bf, bytes);
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                uint bf = maxmath.bitfield(bytes[0], bytes[1], bytes[2], bytes[3]);
                testbitfield32(bf, bytes);
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ulong bf = maxmath.bitfield(bytes[0], bytes[1], bytes[2], bytes[3], bytes[4], bytes[5], bytes[6], bytes[7]);
                testbitfield64(bf, bytes);
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[16];
                for (int j = 0; j < 16; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                UInt128 bf = maxmath.bitfield(bytes[0], bytes[1], bytes[2], bytes[3], bytes[4], bytes[5], bytes[6], bytes[7], bytes[8], bytes[9], bytes[10], bytes[11], bytes[12], bytes[13], bytes[14], bytes[15]);
                testbitfield128(bf, bytes);
            }
        }

        [Test]
        public static void __byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[4];
                for (int j = 0; j < 4; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ushort2 bf = maxmath.bitfield(new byte2(bytes[0], bytes[1]),
                                              new byte2(bytes[2], bytes[3]));
                testbitfield16(bf.x, new byte[] { bytes[0], bytes[2] });
                testbitfield16(bf.y, new byte[] { bytes[1], bytes[3] });
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                uint2 bf = maxmath.bitfield(new byte2(bytes[0], bytes[1]),
                                            new byte2(bytes[2], bytes[3]),
                                            new byte2(bytes[4], bytes[5]),
                                            new byte2(bytes[6], bytes[7]));

                testbitfield32(bf.x, new byte[] { bytes[0], bytes[2], bytes[4], bytes[6] });
                testbitfield32(bf.y, new byte[] { bytes[1], bytes[3], bytes[5], bytes[7] });
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[16];
                for (int j = 0; j < 16; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ulong2 bf = maxmath.bitfield(new byte2(bytes[0],  bytes[1]),
                                             new byte2(bytes[2],  bytes[3]),
                                             new byte2(bytes[4],  bytes[5]),
                                             new byte2(bytes[6],  bytes[7]),
                                             new byte2(bytes[8],  bytes[9]),
                                             new byte2(bytes[10], bytes[11]),
                                             new byte2(bytes[12], bytes[13]),
                                             new byte2(bytes[14], bytes[15]));

                testbitfield64(bf.x, new byte[] { bytes[0], bytes[2], bytes[4], bytes[6], bytes[8], bytes[10], bytes[12], bytes[14] });
                testbitfield64(bf.y, new byte[] { bytes[1], bytes[3], bytes[5], bytes[7], bytes[9], bytes[11], bytes[13], bytes[15] });
            }
        }

        [Test]
        public static void __byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[6];
                for (int j = 0; j < 6; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ushort3 bf = maxmath.bitfield(new byte3(bytes[0], bytes[1], bytes[2]),
                                              new byte3(bytes[3], bytes[4], bytes[5]));
                testbitfield16(bf.x, new byte[] { bytes[0], bytes[3] });
                testbitfield16(bf.y, new byte[] { bytes[1], bytes[4] });
                testbitfield16(bf.z, new byte[] { bytes[2], bytes[5] });
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[12];
                for (int j = 0; j < 12; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                uint3 bf = maxmath.bitfield(new byte3(bytes[0],  bytes[1],  bytes[2]),
                                            new byte3(bytes[3],  bytes[4],  bytes[5]),
                                            new byte3(bytes[6],  bytes[7],  bytes[8]),
                                            new byte3(bytes[9],  bytes[10], bytes[11]));
                testbitfield32(bf.x, new byte[] { bytes[0], bytes[3], bytes[6], bytes[9]  });
                testbitfield32(bf.y, new byte[] { bytes[1], bytes[4], bytes[7], bytes[10] });
                testbitfield32(bf.z, new byte[] { bytes[2], bytes[5], bytes[8], bytes[11] });
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[24];
                for (int j = 0; j < 24; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ulong3 bf = maxmath.bitfield(new byte3(bytes[0],  bytes[1],  bytes[2]),
                                             new byte3(bytes[3],  bytes[4],  bytes[5]),
                                             new byte3(bytes[6],  bytes[7],  bytes[8]),
                                             new byte3(bytes[9],  bytes[10], bytes[11]),
                                             new byte3(bytes[12], bytes[13], bytes[14]),
                                             new byte3(bytes[15], bytes[16], bytes[17]),
                                             new byte3(bytes[18], bytes[19], bytes[20]),
                                             new byte3(bytes[21], bytes[22], bytes[23]));
                testbitfield64(bf.x, new byte[] { bytes[0], bytes[3], bytes[6], bytes[9] , bytes[12], bytes[15], bytes[18], bytes[21] });
                testbitfield64(bf.y, new byte[] { bytes[1], bytes[4], bytes[7], bytes[10], bytes[13], bytes[16], bytes[19], bytes[22] });
                testbitfield64(bf.z, new byte[] { bytes[2], bytes[5], bytes[8], bytes[11], bytes[14], bytes[17], bytes[20], bytes[23] });
            }
        }

        [Test]
        public static void __byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[8];
                for (int j = 0; j < 8; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ushort4 bf = maxmath.bitfield(new byte4(bytes[0], bytes[1], bytes[2], bytes[3]),
                                              new byte4(bytes[4], bytes[5], bytes[6], bytes[7]));
                testbitfield16(bf.x, new byte[] { bytes[0], bytes[4] });
                testbitfield16(bf.y, new byte[] { bytes[1], bytes[5] });
                testbitfield16(bf.z, new byte[] { bytes[2], bytes[6] });
                testbitfield16(bf.w, new byte[] { bytes[3], bytes[7] });
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[16];
                for (int j = 0; j < 16; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                uint4 bf = maxmath.bitfield(new byte4(bytes[0],  bytes[1],  bytes[2],  bytes[3]),
                                            new byte4(bytes[4],  bytes[5],  bytes[6],  bytes[7]),
                                            new byte4(bytes[8],  bytes[9],  bytes[10], bytes[11]),
                                            new byte4(bytes[12], bytes[13], bytes[14], bytes[15]));
                testbitfield32(bf.x, new byte[] { bytes[0], bytes[4], bytes[8],  bytes[12] });
                testbitfield32(bf.y, new byte[] { bytes[1], bytes[5], bytes[9],  bytes[13] });
                testbitfield32(bf.z, new byte[] { bytes[2], bytes[6], bytes[10], bytes[14] });
                testbitfield32(bf.w, new byte[] { bytes[3], bytes[7], bytes[11], bytes[15] });
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[32];
                for (int j = 0; j < 32; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ulong4 bf = maxmath.bitfield(new byte4(bytes[0],  bytes[1],  bytes[2],  bytes[3]),
                                             new byte4(bytes[4],  bytes[5],  bytes[6],  bytes[7]),
                                             new byte4(bytes[8],  bytes[9],  bytes[10], bytes[11]),
                                             new byte4(bytes[12], bytes[13], bytes[14], bytes[15]),
                                             new byte4(bytes[16], bytes[17], bytes[18], bytes[19]),
                                             new byte4(bytes[20], bytes[21], bytes[22], bytes[23]),
                                             new byte4(bytes[24], bytes[25], bytes[26], bytes[27]),
                                             new byte4(bytes[28], bytes[29], bytes[30], bytes[31]));
                testbitfield64(bf.x, new byte[] { bytes[0], bytes[4], bytes[8],  bytes[12], bytes[16], bytes[20], bytes[24], bytes[28], });
                testbitfield64(bf.y, new byte[] { bytes[1], bytes[5], bytes[9],  bytes[13], bytes[17], bytes[21], bytes[25], bytes[29], });
                testbitfield64(bf.z, new byte[] { bytes[2], bytes[6], bytes[10], bytes[14], bytes[18], bytes[22], bytes[26], bytes[30], });
                testbitfield64(bf.w, new byte[] { bytes[3], bytes[7], bytes[11], bytes[15], bytes[19], bytes[23], bytes[27], bytes[31]  });
            }
        }

        [Test]
        public static void __byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[16];
                for (int j = 0; j < 16; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ushort8 bf = maxmath.bitfield(new byte8(bytes[0], bytes[1], bytes[2],  bytes[3],  bytes[4],  bytes[5],  bytes[6],  bytes[7]),
                                              new byte8(bytes[8], bytes[9], bytes[10], bytes[11], bytes[12], bytes[13], bytes[14], bytes[15]));
                testbitfield16(bf.x0, new byte[] { bytes[0], bytes[8] });
                testbitfield16(bf.x1, new byte[] { bytes[1], bytes[9] });
                testbitfield16(bf.x2, new byte[] { bytes[2], bytes[10] });
                testbitfield16(bf.x3, new byte[] { bytes[3], bytes[11] });
                testbitfield16(bf.x4, new byte[] { bytes[4], bytes[12] });
                testbitfield16(bf.x5, new byte[] { bytes[5], bytes[13] });
                testbitfield16(bf.x6, new byte[] { bytes[6], bytes[14] });
                testbitfield16(bf.x7, new byte[] { bytes[7], bytes[15] });
            }

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[32];
                for (int j = 0; j < 32; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                uint8 bf = maxmath.bitfield(new byte8(bytes[0],  bytes[1],  bytes[2],  bytes[3],  bytes[4],  bytes[5],  bytes[6],  bytes[7]),
                                            new byte8(bytes[8],  bytes[9],  bytes[10], bytes[11], bytes[12], bytes[13], bytes[14], bytes[15]),
                                            new byte8(bytes[16], bytes[17], bytes[18], bytes[19], bytes[20], bytes[21], bytes[22], bytes[23]),
                                            new byte8(bytes[24], bytes[25], bytes[26], bytes[27], bytes[28], bytes[29], bytes[30], bytes[31]));
                testbitfield32(bf.x0, new byte[] { bytes[0], bytes[8],  bytes[16], bytes[24], });
                testbitfield32(bf.x1, new byte[] { bytes[1], bytes[9],  bytes[17], bytes[25], });
                testbitfield32(bf.x2, new byte[] { bytes[2], bytes[10], bytes[18], bytes[26], });
                testbitfield32(bf.x3, new byte[] { bytes[3], bytes[11], bytes[19], bytes[27], });
                testbitfield32(bf.x4, new byte[] { bytes[4], bytes[12], bytes[20], bytes[28], });
                testbitfield32(bf.x5, new byte[] { bytes[5], bytes[13], bytes[21], bytes[29], });
                testbitfield32(bf.x6, new byte[] { bytes[6], bytes[14], bytes[22], bytes[30], });
                testbitfield32(bf.x7, new byte[] { bytes[7], bytes[15], bytes[23], bytes[31]  });
            }
        }

        [Test]
        public static void __byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 20; i++)
            {
                byte[] bytes = new byte[32];
                for (int j = 0; j < 32; j++)
                {
                    bytes[j] = rng.NextByte();
                }

                ushort16 bf = maxmath.bitfield(new byte16(bytes[0],  bytes[1],  bytes[2],   bytes[3],   bytes[4],   bytes[5],   bytes[6],   bytes[7],  bytes[8],  bytes[9],  bytes[10], bytes[11], bytes[12], bytes[13], bytes[14], bytes[15]),
                                               new byte16(bytes[16], bytes[17], bytes[18],  bytes[19],  bytes[20],  bytes[21],  bytes[22],  bytes[23], bytes[24], bytes[25], bytes[26], bytes[27], bytes[28], bytes[29], bytes[30], bytes[31]));
                testbitfield16(bf.x0,  new byte[] { bytes[0],  bytes[16] });
                testbitfield16(bf.x1,  new byte[] { bytes[1],  bytes[17] });
                testbitfield16(bf.x2,  new byte[] { bytes[2],  bytes[18] });
                testbitfield16(bf.x3,  new byte[] { bytes[3],  bytes[19] });
                testbitfield16(bf.x4,  new byte[] { bytes[4],  bytes[20] });
                testbitfield16(bf.x5,  new byte[] { bytes[5],  bytes[21] });
                testbitfield16(bf.x6,  new byte[] { bytes[6],  bytes[22] });
                testbitfield16(bf.x7,  new byte[] { bytes[7],  bytes[23] });
                testbitfield16(bf.x8,  new byte[] { bytes[8],  bytes[24] });
                testbitfield16(bf.x9,  new byte[] { bytes[9],  bytes[25] });
                testbitfield16(bf.x10, new byte[] { bytes[10], bytes[26] });
                testbitfield16(bf.x11, new byte[] { bytes[11], bytes[27] });
                testbitfield16(bf.x12, new byte[] { bytes[12], bytes[28] });
                testbitfield16(bf.x13, new byte[] { bytes[13], bytes[29] });
                testbitfield16(bf.x14, new byte[] { bytes[14], bytes[30] });
                testbitfield16(bf.x15, new byte[] { bytes[15], bytes[31] });
            }
        }


        [Test]
        public static void __ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[2];
                for (int j = 0; j < 2; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                uint bf = maxmath.bitfield(ushorts[0], ushorts[1]);
                testbitfield32(bf, ushorts);
            }

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[4];
                for (int j = 0; j < 4; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                ulong bf = maxmath.bitfield(ushorts[0], ushorts[1], ushorts[2], ushorts[3]);
                testbitfield64(bf, ushorts);
            }

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[8];
                for (int j = 0; j < 8; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                UInt128 bf = maxmath.bitfield(ushorts[0], ushorts[1], ushorts[2], ushorts[3], ushorts[4], ushorts[5], ushorts[6], ushorts[7]);
                testbitfield128(bf, ushorts);
            }
        }

        [Test]
        public static void __ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[4];
                for (int j = 0; j < 4; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                uint2 bf = maxmath.bitfield(new ushort2(ushorts[0], ushorts[1]),
                                            new ushort2(ushorts[2], ushorts[3]));
                testbitfield32(bf.x, new ushort[] { ushorts[0], ushorts[2] });
                testbitfield32(bf.y, new ushort[] { ushorts[1], ushorts[3] });
            }

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[8];
                for (int j = 0; j < 8; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                ulong2 bf = maxmath.bitfield(new ushort2(ushorts[0], ushorts[1]),
                                             new ushort2(ushorts[2], ushorts[3]),
                                             new ushort2(ushorts[4], ushorts[5]),
                                             new ushort2(ushorts[6], ushorts[7]));

                testbitfield64(bf.x, new ushort[] { ushorts[0], ushorts[2], ushorts[4], ushorts[6] });
                testbitfield64(bf.y, new ushort[] { ushorts[1], ushorts[3], ushorts[5], ushorts[7] });
            }
        }

        [Test]
        public static void __ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[6];
                for (int j = 0; j < 6; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                uint3 bf = maxmath.bitfield(new ushort3(ushorts[0], ushorts[1], ushorts[2]),
                                            new ushort3(ushorts[3], ushorts[4], ushorts[5]));
                testbitfield32(bf.x, new ushort[] { ushorts[0], ushorts[3] });
                testbitfield32(bf.y, new ushort[] { ushorts[1], ushorts[4] });
                testbitfield32(bf.z, new ushort[] { ushorts[2], ushorts[5] });
            }

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[12];
                for (int j = 0; j < 12; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                ulong3 bf = maxmath.bitfield(new ushort3(ushorts[0],  ushorts[1],  ushorts[2]),
                                             new ushort3(ushorts[3],  ushorts[4],  ushorts[5]),
                                             new ushort3(ushorts[6],  ushorts[7],  ushorts[8]),
                                             new ushort3(ushorts[9],  ushorts[10], ushorts[11]));
                testbitfield64(bf.x, new ushort[] { ushorts[0], ushorts[3], ushorts[6], ushorts[9]  });
                testbitfield64(bf.y, new ushort[] { ushorts[1], ushorts[4], ushorts[7], ushorts[10] });
                testbitfield64(bf.z, new ushort[] { ushorts[2], ushorts[5], ushorts[8], ushorts[11] });
            }
        }

        [Test]
        public static void __ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[8];
                for (int j = 0; j < 8; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                uint4 bf = maxmath.bitfield(new ushort4(ushorts[0], ushorts[1], ushorts[2], ushorts[3]),
                                            new ushort4(ushorts[4], ushorts[5], ushorts[6], ushorts[7]));
                testbitfield32(bf.x, new ushort[] { ushorts[0], ushorts[4] });
                testbitfield32(bf.y, new ushort[] { ushorts[1], ushorts[5] });
                testbitfield32(bf.z, new ushort[] { ushorts[2], ushorts[6] });
                testbitfield32(bf.w, new ushort[] { ushorts[3], ushorts[7] });
            }

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[16];
                for (int j = 0; j < 16; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                ulong4 bf = maxmath.bitfield(new ushort4(ushorts[0],  ushorts[1],  ushorts[2],  ushorts[3]),
                                             new ushort4(ushorts[4],  ushorts[5],  ushorts[6],  ushorts[7]),
                                             new ushort4(ushorts[8],  ushorts[9],  ushorts[10], ushorts[11]),
                                             new ushort4(ushorts[12], ushorts[13], ushorts[14], ushorts[15]));
                testbitfield64(bf.x, new ushort[] { ushorts[0], ushorts[4], ushorts[8],  ushorts[12] });
                testbitfield64(bf.y, new ushort[] { ushorts[1], ushorts[5], ushorts[9],  ushorts[13] });
                testbitfield64(bf.z, new ushort[] { ushorts[2], ushorts[6], ushorts[10], ushorts[14] });
                testbitfield64(bf.w, new ushort[] { ushorts[3], ushorts[7], ushorts[11], ushorts[15] });
            }
        }

        [Test]
        public static void __ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 20; i++)
            {
                ushort[] ushorts = new ushort[16];
                for (int j = 0; j < 16; j++)
                {
                    ushorts[j] = rng.NextUShort();
                }

                uint8 bf = maxmath.bitfield(new ushort8(ushorts[0], ushorts[1], ushorts[2],  ushorts[3],  ushorts[4],  ushorts[5],  ushorts[6],  ushorts[7]),
                                            new ushort8(ushorts[8], ushorts[9], ushorts[10], ushorts[11], ushorts[12], ushorts[13], ushorts[14], ushorts[15]));
                testbitfield32(bf.x0, new ushort[] { ushorts[0], ushorts[8] });
                testbitfield32(bf.x1, new ushort[] { ushorts[1], ushorts[9] });
                testbitfield32(bf.x2, new ushort[] { ushorts[2], ushorts[10] });
                testbitfield32(bf.x3, new ushort[] { ushorts[3], ushorts[11] });
                testbitfield32(bf.x4, new ushort[] { ushorts[4], ushorts[12] });
                testbitfield32(bf.x5, new ushort[] { ushorts[5], ushorts[13] });
                testbitfield32(bf.x6, new ushort[] { ushorts[6], ushorts[14] });
                testbitfield32(bf.x7, new ushort[] { ushorts[7], ushorts[15] });
            }
        }


        [Test]
        public static void __uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                uint[] uints = new uint[2];
                for (int j = 0; j < 2; j++)
                {
                    uints[j] = rng.NextUInt();
                }

                ulong bf = maxmath.bitfield(uints[0], uints[1]);
                testbitfield64(bf, uints);
            }

            for (int i = 0; i < 20; i++)
            {
                uint[] uints = new uint[4];
                for (int j = 0; j < 4; j++)
                {
                    uints[j] = rng.NextUInt();
                }

                UInt128 bf = maxmath.bitfield(uints[0], uints[1], uints[2], uints[3]);
                testbitfield128(bf, uints);
            }
        }

        [Test]
        public static void __uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                uint[] uints = new uint[4];
                for (int j = 0; j < 4; j++)
                {
                    uints[j] = rng.NextUInt();
                }

                ulong2 bf = maxmath.bitfield(new uint2(uints[0], uints[1]),
                                             new uint2(uints[2], uints[3]));
                testbitfield64(bf.x, new uint[] { uints[0], uints[2] });
                testbitfield64(bf.y, new uint[] { uints[1], uints[3] });
            }
        }

        [Test]
        public static void __uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                uint[] uints = new uint[6];
                for (int j = 0; j < 6; j++)
                {
                    uints[j] = rng.NextUInt();
                }

                ulong3 bf = maxmath.bitfield(new uint3(uints[0], uints[1], uints[2]),
                                             new uint3(uints[3], uints[4], uints[5]));
                testbitfield64(bf.x, new uint[] { uints[0], uints[3] });
                testbitfield64(bf.y, new uint[] { uints[1], uints[4] });
                testbitfield64(bf.z, new uint[] { uints[2], uints[5] });
            }
        }

        [Test]
        public static void __uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 20; i++)
            {
                uint[] uints = new uint[8];
                for (int j = 0; j < 8; j++)
                {
                    uints[j] = rng.NextUInt();
                }

                ulong4 bf = maxmath.bitfield(new uint4(uints[0], uints[1], uints[2], uints[3]),
                                             new uint4(uints[4], uints[5], uints[6], uints[7]));
                testbitfield64(bf.x, new uint[] { uints[0], uints[4] });
                testbitfield64(bf.y, new uint[] { uints[1], uints[5] });
                testbitfield64(bf.z, new uint[] { uints[2], uints[6] });
                testbitfield64(bf.w, new uint[] { uints[3], uints[7] });
            }
        }


        [Test]
        public static void __ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 20; i++)
            {
                ulong[] bytes = new ulong[2];
                for (int j = 0; j < 2; j++)
                {
                    bytes[j] = rng.NextULong();
                }

                UInt128 bf = maxmath.bitfield(bytes[0], bytes[1]);
                testbitfield128(bf, bytes);
            }
        }
    }
}