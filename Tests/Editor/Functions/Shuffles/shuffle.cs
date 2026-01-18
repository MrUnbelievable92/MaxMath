using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    public static class f_shuffle
    {
        [Test]
        public static void _bool2_byte2()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool2_sbyte2()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool2_ushort2()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool2_short2()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool2_uint2()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool2_int2()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool2_ulong2()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool2_long2()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                bool2 lhs = rngLHS.NextBool2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                bool2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_byte3()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_sbyte3()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_ushort3()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_short3()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_uint3()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_int3()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_ulong3()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool3_long3()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                bool3 lhs = rngLHS.NextBool3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                bool3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_byte4()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_sbyte4()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_ushort4()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_short4()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_uint4()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_int4()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_ulong4()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool4_long4()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                bool4 lhs = rngLHS.NextBool4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                bool4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool8_byte8()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool8 lhs = rngLHS.NextBool8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                bool8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool8_sbyte8()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool8 lhs = rngLHS.NextBool8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                bool8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool8_ushort8()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool8 lhs = rngLHS.NextBool8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                bool8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool8_short8()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool8 lhs = rngLHS.NextBool8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                bool8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool8_uint8()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool8 lhs = rngLHS.NextBool8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                bool8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool8_int8()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                bool8 lhs = rngLHS.NextBool8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                bool8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool16_byte16()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool16 lhs = rngLHS.NextBool16();
                byte16 rhs = rngRHS.NextByte16(0, 16);
                bool16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool16_sbyte16()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool16 lhs = rngLHS.NextBool16();
                sbyte16 rhs = rngRHS.NextSByte16(0, 16);
                bool16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool16_ushort16()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool16 lhs = rngLHS.NextBool16();
                ushort16 rhs = rngRHS.NextUShort16(0, 16);
                bool16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool16_short16()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                bool16 lhs = rngLHS.NextBool16();
                short16 rhs = rngRHS.NextShort16(0, 16);
                bool16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool32_byte32()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool32 lhs = rngLHS.NextBool32();
                byte32 rhs = rngRHS.NextByte32(0, 32);
                bool32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _bool32_sbyte32()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                bool32 lhs = rngLHS.NextBool32();
                sbyte32 rhs = rngRHS.NextSByte32(0, 32);
                bool32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }


        [Test]
        public static void _byte2_byte2()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte2_sbyte2()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte2_ushort2()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte2_short2()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte2_uint2()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte2_int2()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte2_ulong2()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte2_long2()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 lhs = rngLHS.NextByte2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                byte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_byte3()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_sbyte3()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_ushort3()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_short3()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_uint3()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_int3()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_ulong3()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte3_long3()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 lhs = rngLHS.NextByte3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                byte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_byte4()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_sbyte4()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_ushort4()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_short4()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_uint4()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_int4()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_ulong4()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte4_long4()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 lhs = rngLHS.NextByte4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                byte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte8_byte8()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 lhs = rngLHS.NextByte8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                byte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte8_sbyte8()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 lhs = rngLHS.NextByte8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                byte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte8_ushort8()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 lhs = rngLHS.NextByte8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                byte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte8_short8()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 lhs = rngLHS.NextByte8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                byte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte8_uint8()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 lhs = rngLHS.NextByte8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                byte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte8_int8()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 lhs = rngLHS.NextByte8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                byte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte16_byte16()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 lhs = rngLHS.NextByte16();
                byte16 rhs = rngRHS.NextByte16(0, 16);
                byte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte16_sbyte16()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 lhs = rngLHS.NextByte16();
                sbyte16 rhs = rngRHS.NextSByte16(0, 16);
                byte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte16_ushort16()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 lhs = rngLHS.NextByte16();
                ushort16 rhs = rngRHS.NextUShort16(0, 16);
                byte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte16_short16()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                byte16 lhs = rngLHS.NextByte16();
                short16 rhs = rngRHS.NextShort16(0, 16);
                byte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte32_byte32()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 lhs = rngLHS.NextByte32();
                byte32 rhs = rngRHS.NextByte32(0, 32);
                byte32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _byte32_sbyte32()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte32 lhs = rngLHS.NextByte32();
                sbyte32 rhs = rngRHS.NextSByte32(0, 32);
                byte32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_byte2()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_sbyte2()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_ushort2()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_short2()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_uint2()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_int2()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_ulong2()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte2_long2()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 lhs = rngLHS.NextSByte2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                sbyte2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_byte3()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_sbyte3()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_ushort3()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_short3()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_uint3()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_int3()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_ulong3()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte3_long3()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 lhs = rngLHS.NextSByte3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                sbyte3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_byte4()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_sbyte4()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_ushort4()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_short4()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_uint4()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_int4()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_ulong4()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte4_long4()
        {
            Random8 rngLHS = Random8.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 lhs = rngLHS.NextSByte4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                sbyte4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte8_byte8()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 lhs = rngLHS.NextSByte8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                sbyte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte8_sbyte8()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 lhs = rngLHS.NextSByte8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                sbyte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte8_ushort8()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 lhs = rngLHS.NextSByte8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                sbyte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte8_short8()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 lhs = rngLHS.NextSByte8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                sbyte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte8_uint8()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 lhs = rngLHS.NextSByte8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                sbyte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte8_int8()
        {
            Random8 rngLHS = Random8.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 lhs = rngLHS.NextSByte8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                sbyte8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte16_byte16()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 lhs = rngLHS.NextSByte16();
                byte16 rhs = rngRHS.NextByte16(0, 16);
                sbyte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte16_sbyte16()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 lhs = rngLHS.NextSByte16();
                sbyte16 rhs = rngRHS.NextSByte16(0, 16);
                sbyte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte16_ushort16()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 lhs = rngLHS.NextSByte16();
                ushort16 rhs = rngRHS.NextUShort16(0, 16);
                sbyte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte16_short16()
        {
            Random8 rngLHS = Random8.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte16 lhs = rngLHS.NextSByte16();
                short16 rhs = rngRHS.NextShort16(0, 16);
                sbyte16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte32_byte32()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte32 lhs = rngLHS.NextSByte32();
                byte32 rhs = rngRHS.NextByte32(0, 32);
                sbyte32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _sbyte32_sbyte32()
        {
            Random8 rngLHS = Random8.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte32 lhs = rngLHS.NextSByte32();
                sbyte32 rhs = rngRHS.NextSByte32(0, 32);
                sbyte32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_byte2()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_sbyte2()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_ushort2()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_short2()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_uint2()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_int2()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_ulong2()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort2_long2()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 lhs = rngLHS.NextUShort2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                ushort2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_byte3()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_sbyte3()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_ushort3()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_short3()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_uint3()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_int3()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_ulong3()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort3_long3()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 lhs = rngLHS.NextUShort3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                ushort3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_byte4()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_sbyte4()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_ushort4()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_short4()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_uint4()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_int4()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_ulong4()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort4_long4()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 lhs = rngLHS.NextUShort4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                ushort4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort8_byte8()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 lhs = rngLHS.NextUShort8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                ushort8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort8_sbyte8()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 lhs = rngLHS.NextUShort8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                ushort8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort8_ushort8()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 lhs = rngLHS.NextUShort8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                ushort8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort8_short8()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 lhs = rngLHS.NextUShort8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                ushort8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort8_uint8()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 lhs = rngLHS.NextUShort8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                ushort8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort8_int8()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 lhs = rngLHS.NextUShort8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                ushort8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort16_byte16()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 lhs = rngLHS.NextUShort16();
                byte16 rhs = rngRHS.NextByte16(0, 16);
                ushort16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort16_sbyte16()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 lhs = rngLHS.NextUShort16();
                sbyte16 rhs = rngRHS.NextSByte16(0, 16);
                ushort16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort16_ushort16()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 lhs = rngLHS.NextUShort16();
                ushort16 rhs = rngRHS.NextUShort16(0, 16);
                ushort16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ushort16_short16()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort16 lhs = rngLHS.NextUShort16();
                short16 rhs = rngRHS.NextShort16(0, 16);
                ushort16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_byte2()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_sbyte2()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_ushort2()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_short2()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_uint2()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_int2()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_ulong2()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short2_long2()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                short2 lhs = rngLHS.NextShort2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                short2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_byte3()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_sbyte3()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_ushort3()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_short3()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_uint3()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_int3()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_ulong3()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short3_long3()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                short3 lhs = rngLHS.NextShort3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                short3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_byte4()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_sbyte4()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_ushort4()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_short4()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_uint4()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_int4()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_ulong4()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short4_long4()
        {
            Random16 rngLHS = Random16.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                short4 lhs = rngLHS.NextShort4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                short4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short8_byte8()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short8 lhs = rngLHS.NextShort8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                short8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short8_sbyte8()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short8 lhs = rngLHS.NextShort8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                short8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short8_ushort8()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short8 lhs = rngLHS.NextShort8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                short8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short8_short8()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short8 lhs = rngLHS.NextShort8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                short8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short8_uint8()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short8 lhs = rngLHS.NextShort8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                short8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short8_int8()
        {
            Random16 rngLHS = Random16.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                short8 lhs = rngLHS.NextShort8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                short8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short16_byte16()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short16 lhs = rngLHS.NextShort16();
                byte16 rhs = rngRHS.NextByte16(0, 16);
                short16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short16_sbyte16()
        {
            Random16 rngLHS = Random16.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                short16 lhs = rngLHS.NextShort16();
                sbyte16 rhs = rngRHS.NextSByte16(0, 16);
                short16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short16_ushort16()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short16 lhs = rngLHS.NextShort16();
                ushort16 rhs = rngRHS.NextUShort16(0, 16);
                short16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _short16_short16()
        {
            Random16 rngLHS = Random16.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short16 lhs = rngLHS.NextShort16();
                short16 rhs = rngRHS.NextShort16(0, 16);
                short16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }


        [Test]
        public static void _uint2_byte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint2_sbyte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint2_ushort2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint2_short2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint2_uint2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint2_int2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint2_ulong2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint2_long2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                uint2 lhs = rngLHS.NextUInt2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                uint2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_byte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_sbyte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_ushort3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_short3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_uint3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_int3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_ulong3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint3_long3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                uint3 lhs = rngLHS.NextUInt3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                uint3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_byte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_sbyte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_ushort4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_short4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_uint4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_int4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_ulong4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint4_long4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                uint4 lhs = rngLHS.NextUInt4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                uint4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint8_byte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 lhs = rngLHS.NextUInt8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                uint8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint8_sbyte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 lhs = rngLHS.NextUInt8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                uint8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint8_ushort8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 lhs = rngLHS.NextUInt8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                uint8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint8_short8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 lhs = rngLHS.NextUInt8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                uint8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint8_uint8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 lhs = rngLHS.NextUInt8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                uint8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _uint8_int8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                uint8 lhs = rngLHS.NextUInt8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                uint8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_byte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_sbyte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_ushort2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_short2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_uint2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_int2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_ulong2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int2_long2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                int2 lhs = rngLHS.NextInt2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                int2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_byte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_sbyte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_ushort3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_short3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_uint3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_int3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_ulong3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int3_long3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                int3 lhs = rngLHS.NextInt3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                int3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_byte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_sbyte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_ushort4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_short4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_uint4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_int4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_ulong4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int4_long4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                int4 lhs = rngLHS.NextInt4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                int4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int8_byte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int8 lhs = rngLHS.NextInt8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                int8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int8_sbyte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                int8 lhs = rngLHS.NextInt8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                int8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int8_ushort8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int8 lhs = rngLHS.NextInt8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                int8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int8_short8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                int8 lhs = rngLHS.NextInt8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                int8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int8_uint8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int8 lhs = rngLHS.NextInt8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                int8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _int8_int8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                int8 lhs = rngLHS.NextInt8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                int8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }



        [Test]
        public static void _ulong2_byte2()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong2_sbyte2()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong2_ushort2()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong2_short2()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong2_uint2()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong2_int2()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong2_ulong2()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong2_long2()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong2 lhs = rngLHS.NextULong2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                ulong2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_byte3()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_sbyte3()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_ushort3()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_short3()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_uint3()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_int3()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_ulong3()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong3_long3()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong3 lhs = rngLHS.NextULong3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                ulong3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_byte4()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_sbyte4()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_ushort4()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_short4()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_uint4()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_int4()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_ulong4()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _ulong4_long4()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                ulong4 lhs = rngLHS.NextULong4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                ulong4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_byte2()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_sbyte2()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_ushort2()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_short2()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_uint2()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_int2()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_ulong2()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long2_long2()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long2 lhs = rngLHS.NextLong2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                long2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_byte3()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_sbyte3()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_ushort3()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_short3()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_uint3()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_int3()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_ulong3()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long3_long3()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long3 lhs = rngLHS.NextLong3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                long3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_byte4()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_sbyte4()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_ushort4()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_short4()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_uint4()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_int4()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_ulong4()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _long4_long4()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                long4 lhs = rngLHS.NextLong4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                long4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_byte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                byte2 rhs = rngRHS.NextByte2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_sbyte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_ushort2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_short2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                short2 rhs = rngRHS.NextShort2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_uint2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_int2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                int2 rhs = rngRHS.NextInt2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_ulong2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter2_long2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                quarter2 lhs = (quarter2)rngLHS.NextFloat2(quarter.MinValue, quarter.MaxValue);
                long2 rhs = rngRHS.NextLong2(0, 2);
                quarter2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_byte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                byte3 rhs = rngRHS.NextByte3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_sbyte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_ushort3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_short3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                short3 rhs = rngRHS.NextShort3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_uint3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_int3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                int3 rhs = rngRHS.NextInt3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_ulong3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter3_long3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                quarter3 lhs = (quarter3)rngLHS.NextFloat3(quarter.MinValue, quarter.MaxValue);
                long3 rhs = rngRHS.NextLong3(0, 3);
                quarter3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_byte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                byte4 rhs = rngRHS.NextByte4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_sbyte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_ushort4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_short4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                short4 rhs = rngRHS.NextShort4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_uint4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_int4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                int4 rhs = rngRHS.NextInt4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_ulong4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter4_long4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                quarter4 lhs = (quarter4)rngLHS.NextFloat4(quarter.MinValue, quarter.MaxValue);
                long4 rhs = rngRHS.NextLong4(0, 4);
                quarter4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter8_byte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter8 lhs = (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue);
                byte8 rhs = rngRHS.NextByte8(0, 8);
                quarter8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter8_sbyte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter8 lhs = (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue);
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                quarter8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter8_ushort8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter8 lhs = (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue);
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                quarter8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter8_short8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter8 lhs = (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue);
                short8 rhs = rngRHS.NextShort8(0, 8);
                quarter8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter8_uint8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter8 lhs = (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue);
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                quarter8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter8_int8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter8 lhs = (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue);
                int8 rhs = rngRHS.NextInt8(0, 8);
                quarter8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter16_byte16()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter16 lhs = new quarter16((quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue));
                byte16 rhs = rngRHS.NextByte16(0, 16);
                quarter16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter16_sbyte16()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter16 lhs = new quarter16((quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue));
                sbyte16 rhs = rngRHS.NextSByte16(0, 16);
                quarter16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter16_ushort16()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter16 lhs = new quarter16((quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue));
                ushort16 rhs = rngRHS.NextUShort16(0, 8);
                quarter16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter16_short16()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                quarter16 lhs = new quarter16((quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue));
                short16 rhs = rngRHS.NextShort16(0, 8);
                quarter16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter32_byte32()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter32 lhs = new quarter32((quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue));
                byte32 rhs = rngRHS.NextByte32(0, 32);
                quarter32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _quarter32_sbyte32()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                quarter32 lhs = new quarter32((quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rngLHS.NextFloat8(quarter.MinValue, quarter.MaxValue));
                sbyte32 rhs = rngRHS.NextSByte32(0, 32);
                quarter32 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_byte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                byte2 rhs = rngRHS.NextByte2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_sbyte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_ushort2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_short2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                short2 rhs = rngRHS.NextShort2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_uint2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_int2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                int2 rhs = rngRHS.NextInt2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_ulong2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half2_long2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                half2 lhs = (half2)rngLHS.NextFloat2(half.MinValue, half.MaxValue);
                long2 rhs = rngRHS.NextLong2(0, 2);
                half2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_byte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                byte3 rhs = rngRHS.NextByte3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_sbyte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_ushort3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_short3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                short3 rhs = rngRHS.NextShort3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_uint3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_int3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                int3 rhs = rngRHS.NextInt3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_ulong3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half3_long3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                half3 lhs = (half3)rngLHS.NextFloat3(half.MinValue, half.MaxValue);
                long3 rhs = rngRHS.NextLong3(0, 3);
                half3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_byte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                byte4 rhs = rngRHS.NextByte4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_sbyte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_ushort4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_short4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                short4 rhs = rngRHS.NextShort4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_uint4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_int4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                int4 rhs = rngRHS.NextInt4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_ulong4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half4_long4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                half4 lhs = (half4)rngLHS.NextFloat4(half.MinValue, half.MaxValue);
                long4 rhs = rngRHS.NextLong4(0, 4);
                half4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half8_byte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half8 lhs = (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue);
                byte8 rhs = rngRHS.NextByte8(0, 8);
                half8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half8_sbyte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half8 lhs = (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue);
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                half8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half8_ushort8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half8 lhs = (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue);
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                half8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half8_short8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half8 lhs = (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue);
                short8 rhs = rngRHS.NextShort8(0, 8);
                half8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half8_uint8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half8 lhs = (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue);
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                half8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half8_int8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                half8 lhs = (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue);
                int8 rhs = rngRHS.NextInt8(0, 8);
                half8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half16_byte16()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half16 lhs = new half16((half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue), (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue));
                byte16 rhs = rngRHS.NextByte16(0, 8);
                half16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half16_sbyte16()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                half16 lhs = new half16((half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue), (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue));
                sbyte16 rhs = rngRHS.NextSByte16(0, 8);
                half16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half16_ushort16()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half16 lhs = new half16((half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue), (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue));
                ushort16 rhs = rngRHS.NextUShort16(0, 8);
                half16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _half16_short16()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                half16 lhs = new half16((half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue), (half8)rngLHS.NextFloat8(half.MinValue, half.MaxValue));
                short16 rhs = rngRHS.NextShort16(0, 8);
                half16 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }


        [Test]
        public static void _float2_byte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float2_sbyte2()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float2_ushort2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float2_short2()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float2_uint2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float2_int2()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float2_ulong2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float2_long2()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                float2 lhs = (float2)rngLHS.NextFloat2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                float2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_byte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_sbyte3()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_ushort3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_short3()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_uint3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_int3()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_ulong3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float3_long3()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                float3 lhs = (float3)rngLHS.NextFloat3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                float3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_byte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_sbyte4()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_ushort4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_short4()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_uint4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_int4()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_ulong4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float4_long4()
        {
            Random32 rngLHS = Random32.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                float4 lhs = (float4)rngLHS.NextFloat4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                float4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float8_byte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float8 lhs = (float8)rngLHS.NextFloat8();
                byte8 rhs = rngRHS.NextByte8(0, 8);
                float8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float8_sbyte8()
        {
            Random32 rngLHS = Random32.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                float8 lhs = (float8)rngLHS.NextFloat8();
                sbyte8 rhs = rngRHS.NextSByte8(0, 8);
                float8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float8_ushort8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float8 lhs = (float8)rngLHS.NextFloat8();
                ushort8 rhs = rngRHS.NextUShort8(0, 8);
                float8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float8_short8()
        {
            Random32 rngLHS = Random32.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                float8 lhs = (float8)rngLHS.NextFloat8();
                short8 rhs = rngRHS.NextShort8(0, 8);
                float8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float8_uint8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float8 lhs = (float8)rngLHS.NextFloat8();
                uint8 rhs = rngRHS.NextUInt8(0, 8);
                float8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _float8_int8()
        {
            Random32 rngLHS = Random32.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                float8 lhs = (float8)rngLHS.NextFloat8();
                int8 rhs = rngRHS.NextInt8(0, 8);
                float8 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }


        [Test]
        public static void _double2_byte2()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                byte2 rhs = rngRHS.NextByte2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double2_sbyte2()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                sbyte2 rhs = rngRHS.NextSByte2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double2_ushort2()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                ushort2 rhs = rngRHS.NextUShort2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double2_short2()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                short2 rhs = rngRHS.NextShort2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double2_uint2()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                uint2 rhs = rngRHS.NextUInt2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double2_int2()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                int2 rhs = rngRHS.NextInt2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double2_ulong2()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                ulong2 rhs = rngRHS.NextULong2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double2_long2()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                double2 lhs = (double2)rngLHS.NextDouble2();
                long2 rhs = rngRHS.NextLong2(0, 2);
                double2 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_byte3()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                byte3 rhs = rngRHS.NextByte3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_sbyte3()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                sbyte3 rhs = rngRHS.NextSByte3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_ushort3()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                ushort3 rhs = rngRHS.NextUShort3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_short3()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                short3 rhs = rngRHS.NextShort3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_uint3()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                uint3 rhs = rngRHS.NextUInt3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_int3()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                int3 rhs = rngRHS.NextInt3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_ulong3()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                ulong3 rhs = rngRHS.NextULong3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double3_long3()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                double3 lhs = (double3)rngLHS.NextDouble3();
                long3 rhs = rngRHS.NextLong3(0, 3);
                double3 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_byte4()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                byte4 rhs = rngRHS.NextByte4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_sbyte4()
        {
            Random64 rngLHS = Random64.New;
            Random8 rngRHS = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                sbyte4 rhs = rngRHS.NextSByte4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_ushort4()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                ushort4 rhs = rngRHS.NextUShort4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_short4()
        {
            Random64 rngLHS = Random64.New;
            Random16 rngRHS = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                short4 rhs = rngRHS.NextShort4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_uint4()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                uint4 rhs = rngRHS.NextUInt4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_int4()
        {
            Random64 rngLHS = Random64.New;
            Random32 rngRHS = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                int4 rhs = rngRHS.NextInt4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_ulong4()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                ulong4 rhs = rngRHS.NextULong4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }

        [Test]
        public static void _double4_long4()
        {
            Random64 rngLHS = Random64.New;
            Random64 rngRHS = Random64.New;

            for (int i = 0; i < 32; i++)
            {
                double4 lhs = (double4)rngLHS.NextDouble4();
                long4 rhs = rngRHS.NextLong4(0, 4);
                double4 shuf = shuffle(lhs, rhs);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(shuf[j], lhs[(int)rhs[j]]);
                }
            }
        }
    }
}
