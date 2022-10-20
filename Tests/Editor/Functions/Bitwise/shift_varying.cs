using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class shift_varying
    {
        [Test]
        public static void shlv_sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2(0, 8);

                sbyte2 test = maxmath.shl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3(0, 8);

                sbyte3 test = maxmath.shl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4(0, 8);

                sbyte4 test = maxmath.shl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8(0, 8);

                sbyte8 test = maxmath.shl(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16(0, 8);

                sbyte16 test = maxmath.shl(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32(0, 8);

                sbyte32 test = maxmath.shl(l, r);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] << r[j]));
                }
            }
        }


        [Test]
        public static void shlv_short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2(0, 16);

                short2 test = maxmath.shl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3(0, 16);

                short3 test = maxmath.shl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4(0, 16);

                short4 test = maxmath.shl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8(0, 16);

                short8 test = maxmath.shl(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] << r[j]));
                }
            }
        }

        [Test]
        public static void shlv_short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16(0, 16);

                short16 test = maxmath.shl(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] << r[j]));
                }
            }
        }


        [Test]
        public static void shlv_int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2(0, 32);

                int2 test = maxmath.shl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] << (int)r[j]));
                }
            }
        }

        [Test]
        public static void shlv_int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3(0, 32);

                int3 test = maxmath.shl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] << (int)r[j]));
                }
            }
        }

        [Test]
        public static void shlv_int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4(0, 32);

                int4 test = maxmath.shl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] << (int)r[j]));
                }
            }
        }

        [Test]
        public static void shlv_int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8(0, 32);

                int8 test = maxmath.shl(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] << (int)r[j]));
                }
            }
        }


        [Test]
        public static void shlv_long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2(0, 64);

                long2 test = maxmath.shl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] << (int)r[j]));
                }
            }
        }

        [Test]
        public static void shlv_long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3(0, 64);

                long3 test = maxmath.shl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] << (int)r[j]));
                }
            }
        }

        [Test]
        public static void shlv_long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4(0, 64);

                long4 test = maxmath.shl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] << (int)r[j]));
                }
            }
        }


        [Test]
        public static void shrlv_sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2(0, 8);

                sbyte2 test = maxmath.shrl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)((byte)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3(0, 8);

                sbyte3 test = maxmath.shrl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)((byte)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4(0, 8);

                sbyte4 test = maxmath.shrl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)((byte)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8(0, 8);

                sbyte8 test = maxmath.shrl(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)((byte)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16(0, 8);

                sbyte16 test = maxmath.shrl(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)((byte)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32(0, 8);

                sbyte32 test = maxmath.shrl(l, r);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)((byte)l[j] >> r[j]));
                }
            }
        }


        [Test]
        public static void shrlv_short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2(0, 16);

                short2 test = maxmath.shrl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (short)((ushort)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3(0, 16);

                short3 test = maxmath.shrl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (short)((ushort)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4(0, 16);

                short4 test = maxmath.shrl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (short)((ushort)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8(0, 16);

                short8 test = maxmath.shrl(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (short)((ushort)l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16(0, 16);

                short16 test = maxmath.shrl(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (short)((ushort)l[j] >> r[j]));
                }
            }
        }


        [Test]
        public static void shrlv_int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2(0, 32);

                int2 test = maxmath.shrl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (int)((uint)l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3(0, 32);

                int3 test = maxmath.shrl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (int)((uint)l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4(0, 32);

                int4 test = maxmath.shrl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (int)((uint)l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8(0, 32);

                int8 test = maxmath.shrl(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (int)((uint)l[j] >> (int)r[j]));
                }
            }
        }


        [Test]
        public static void shrlv_long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2(0, 64);

                long2 test = maxmath.shrl(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (long)((ulong)l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3(0, 64);

                long3 test = maxmath.shrl(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (long)((ulong)l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrlv_long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4(0, 64);

                long4 test = maxmath.shrl(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (long)((ulong)l[j] >> (int)r[j]));
                }
            }
        }


        [Test]
        public static void shrav_sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = rng.NextSByte2(0, 8);

                sbyte2 test = maxmath.shra(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = rng.NextSByte3(0, 8);

                sbyte3 test = maxmath.shra(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = rng.NextSByte4(0, 8);

                sbyte4 test = maxmath.shra(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = rng.NextSByte8(0, 8);

                sbyte8 test = maxmath.shra(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = rng.NextSByte16(0, 8);

                sbyte16 test = maxmath.shra(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 8; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = rng.NextSByte32(0, 8);

                sbyte32 test = maxmath.shra(l, r);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(l[j] >> r[j]));
                }
            }
        }


        [Test]
        public static void shrav_short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = rng.NextShort2(0, 16);

                short2 test = maxmath.shra(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = rng.NextShort3(0, 16);

                short3 test = maxmath.shra(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = rng.NextShort4(0, 16);

                short4 test = maxmath.shra(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = rng.NextShort8(0, 16);

                short8 test = maxmath.shra(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] >> r[j]));
                }
            }
        }

        [Test]
        public static void shrav_short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 8; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = rng.NextShort16(0, 16);

                short16 test = maxmath.shra(l, r);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (short)(l[j] >> r[j]));
                }
            }
        }


        [Test]
        public static void shrav_int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = rng.NextInt2(0, 32);

                int2 test = maxmath.shra(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrav_int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = rng.NextInt3(0, 32);

                int3 test = maxmath.shra(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrav_int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = rng.NextInt4(0, 32);

                int4 test = maxmath.shra(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrav_int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 8; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = rng.NextInt8(0, 32);

                int8 test = maxmath.shra(l, r);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (int)(l[j] >> (int)r[j]));
                }
            }
        }


        [Test]
        public static void shrav_long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long2 l = rng.NextLong2();
                long2 r = rng.NextLong2(0, 64);

                long2 test = maxmath.shra(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong2();
                r = rng.NextLong2(0, 33);

                test = maxmath.shra(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong2();
                r = rng.NextLong2(32, 63);

                test = maxmath.shra(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong2();
                r = 0;

                test = maxmath.shra(l, r);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrav_long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long3 l = rng.NextLong3();
                long3 r = rng.NextLong3(0, 64);

                long3 test = maxmath.shra(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong3();
                r = rng.NextLong3(0, 33);

                test = maxmath.shra(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong3();
                r = rng.NextLong3(32, 63);

                test = maxmath.shra(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong3();
                r = 0;

                test = maxmath.shra(l, r);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }
            }
        }

        [Test]
        public static void shrav_long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 8; i++)
            {
                long4 l = rng.NextLong4();
                long4 r = rng.NextLong4(0, 64);

                long4 test = maxmath.shra(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong4();
                r = rng.NextLong4(0, 33);

                test = maxmath.shra(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong4();
                r = rng.NextLong4(32, 63);

                test = maxmath.shra(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }

                l = rng.NextLong4();
                r = 0;

                test = maxmath.shra(l, r);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (long)(l[j] >> (int)r[j]));
                }
            }
        }
    }
}
