using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class isinrange
    {
        [Test]
        public static void Int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                int x = rng.NextInt();
                int max = rng.NextInt();
                int min = rng.NextInt();

                if (min > max)
                {
                    int t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UInt()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                uint x = rng.NextUInt();
                uint max = rng.NextUInt();
                uint min = rng.NextUInt();

                if (min > max)
                {
                    uint t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                long x = rng.NextLong();
                long max = rng.NextLong();
                long min = rng.NextLong();

                if (min > max)
                {
                    long t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void ULong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                ulong x = rng.NextULong();
                ulong max = rng.NextULong();
                ulong min = rng.NextULong();

                if (min > max)
                {
                    ulong t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 100; i++)
            {
                Int128 x = rng.NextInt128();
                Int128 max = rng.NextInt128();
                Int128 min = rng.NextInt128();

                if (min > max)
                {
                    Int128 t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 100; i++)
            {
                UInt128 x = rng.NextUInt128();
                UInt128 max = rng.NextUInt128();
                UInt128 min = rng.NextUInt128();

                if (min > max)
                {
                    UInt128 t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                float x = rng.NextFloat();
                float max = rng.NextFloat();
                float min = rng.NextFloat();

                if (min > max)
                {
                    float t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 100; i++)
            {
                double x = rng.NextDouble();
                double max = rng.NextDouble();
                double min = rng.NextDouble();

                if (min > max)
                {
                    double t = min;
                    min = max;
                    max = t;
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void Byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                byte2 x = rng.NextByte2();
                byte2 max = rng.NextByte2();
                byte2 min = rng.NextByte2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        byte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                byte3 x = rng.NextByte3();
                byte3 max = rng.NextByte3();
                byte3 min = rng.NextByte3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        byte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                byte4 x = rng.NextByte4();
                byte4 max = rng.NextByte4();
                byte4 min = rng.NextByte4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        byte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                byte8 x = rng.NextByte8();
                byte8 max = rng.NextByte8();
                byte8 min = rng.NextByte8();

                for (int j = 0; j < 8; j++)
                {
                    if (min[j] > max[j])
                    {
                        byte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                byte16 x = rng.NextByte16();
                byte16 max = rng.NextByte16();
                byte16 min = rng.NextByte16();

                for (int j = 0; j < 16; j++)
                {
                    if (min[j] > max[j])
                    {
                        byte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                byte32 x = rng.NextByte32();
                byte32 max = rng.NextByte32();
                byte32 min = rng.NextByte32();

                for (int j = 0; j < 32; j++)
                {
                    if (min[j] > max[j])
                    {
                        byte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void SByte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                sbyte2 x = rng.NextSByte2();
                sbyte2 max = rng.NextSByte2();
                sbyte2 min = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        sbyte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void SByte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                sbyte3 x = rng.NextSByte3();
                sbyte3 max = rng.NextSByte3();
                sbyte3 min = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        sbyte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void SByte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                sbyte4 x = rng.NextSByte4();
                sbyte4 max = rng.NextSByte4();
                sbyte4 min = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        sbyte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void SByte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                sbyte8 x = rng.NextSByte8();
                sbyte8 max = rng.NextSByte8();
                sbyte8 min = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    if (min[j] > max[j])
                    {
                        sbyte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void SByte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                sbyte16 x = rng.NextSByte16();
                sbyte16 max = rng.NextSByte16();
                sbyte16 min = rng.NextSByte16();

                for (int j = 0; j < 16; j++)
                {
                    if (min[j] > max[j])
                    {
                        sbyte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void SByte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 100; i++)
            {
                sbyte32 x = rng.NextSByte32();
                sbyte32 max = rng.NextSByte32();
                sbyte32 min = rng.NextSByte32();

                for (int j = 0; j < 32; j++)
                {
                    if (min[j] > max[j])
                    {
                        sbyte t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void UShort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                ushort2 x = rng.NextUShort2();
                ushort2 max = rng.NextUShort2();
                ushort2 min = rng.NextUShort2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        ushort t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UShort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                ushort3 x = rng.NextUShort3();
                ushort3 max = rng.NextUShort3();
                ushort3 min = rng.NextUShort3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        ushort t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UShort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                ushort4 x = rng.NextUShort4();
                ushort4 max = rng.NextUShort4();
                ushort4 min = rng.NextUShort4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        ushort t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UShort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                ushort8 x = rng.NextUShort8();
                ushort8 max = rng.NextUShort8();
                ushort8 min = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    if (min[j] > max[j])
                    {
                        ushort t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UShort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                ushort16 x = rng.NextUShort16();
                ushort16 max = rng.NextUShort16();
                ushort16 min = rng.NextUShort16();

                for (int j = 0; j < 16; j++)
                {
                    if (min[j] > max[j])
                    {
                        ushort t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void Short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                short2 x = rng.NextShort2();
                short2 max = rng.NextShort2();
                short2 min = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        short t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                short3 x = rng.NextShort3();
                short3 max = rng.NextShort3();
                short3 min = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        short t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                short4 x = rng.NextShort4();
                short4 max = rng.NextShort4();
                short4 min = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        short t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                short8 x = rng.NextShort8();
                short8 max = rng.NextShort8();
                short8 min = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    if (min[j] > max[j])
                    {
                        short t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 100; i++)
            {
                short16 x = rng.NextShort16();
                short16 max = rng.NextShort16();
                short16 min = rng.NextShort16();

                for (int j = 0; j < 16; j++)
                {
                    if (min[j] > max[j])
                    {
                        short t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void UInt2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                uint2 x = rng.NextUInt2();
                uint2 max = rng.NextUInt2();
                uint2 min = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        uint t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UInt3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                uint3 x = rng.NextUInt3();
                uint3 max = rng.NextUInt3();
                uint3 min = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        uint t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UInt4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                uint4 x = rng.NextUInt4();
                uint4 max = rng.NextUInt4();
                uint4 min = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        uint t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void UInt8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                uint8 x = rng.NextUInt8();
                uint8 max = rng.NextUInt8();
                uint8 min = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    if (min[j] > max[j])
                    {
                        uint t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void Int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                int2 x = rng.NextInt2();
                int2 max = rng.NextInt2();
                int2 min = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        int t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                int3 x = rng.NextInt3();
                int3 max = rng.NextInt3();
                int3 min = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        int t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                int4 x = rng.NextInt4();
                int4 max = rng.NextInt4();
                int4 min = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        int t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 100; i++)
            {
                int8 x = rng.NextInt8();
                int8 max = rng.NextInt8();
                int8 min = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    if (min[j] > max[j])
                    {
                        int t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void ULong2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 100; i++)
            {
                ulong2 x = rng.NextULong2();
                ulong2 max = rng.NextULong2();
                ulong2 min = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        ulong t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void ULong3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 100; i++)
            {
                ulong3 x = rng.NextULong3();
                ulong3 max = rng.NextULong3();
                ulong3 min = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        ulong t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void ULong4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 100; i++)
            {
                ulong4 x = rng.NextULong4();
                ulong4 max = rng.NextULong4();
                ulong4 min = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        ulong t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void Long2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 100; i++)
            {
                long2 x = rng.NextLong2();
                long2 max = rng.NextLong2();
                long2 min = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        long t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Long3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 100; i++)
            {
                long3 x = rng.NextLong3();
                long3 max = rng.NextLong3();
                long3 min = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        long t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Long4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 100; i++)
            {
                long4 x = rng.NextLong4();
                long4 max = rng.NextLong4();
                long4 min = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        long t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void Float2()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 100; i++)
            {
                float2 x = rng.NextFloat2();
                float2 max = rng.NextFloat2();
                float2 min = rng.NextFloat2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        float t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Float3()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 100; i++)
            {
                float3 x = rng.NextFloat3();
                float3 max = rng.NextFloat3();
                float3 min = rng.NextFloat3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        float t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Float4()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 100; i++)
            {
                float4 x = rng.NextFloat4();
                float4 max = rng.NextFloat4();
                float4 min = rng.NextFloat4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        float t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Float8()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 100; i++)
            {
                float8 x = rng.NextFloat8();
                float8 max = rng.NextFloat8();
                float8 min = rng.NextFloat8();

                for (int j = 0; j < 8; j++)
                {
                    if (min[j] > max[j])
                    {
                        float t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }


        [Test]
        public static void Double2()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 100; i++)
            {
                double2 x = rng.NextDouble2();
                double2 max = rng.NextDouble2();
                double2 min = rng.NextDouble2();

                for (int j = 0; j < 2; j++)
                {
                    if (min[j] > max[j])
                    {
                        double t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Double3()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 100; i++)
            {
                double3 x = rng.NextDouble3();
                double3 max = rng.NextDouble3();
                double3 min = rng.NextDouble3();

                for (int j = 0; j < 3; j++)
                {
                    if (min[j] > max[j])
                    {
                        double t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }

        [Test]
        public static void Double4()
        {
            Random64 rng = Random64.New;

            for (double i = 0; i < 100; i++)
            {
                double4 x = rng.NextDouble4();
                double4 max = rng.NextDouble4();
                double4 min = rng.NextDouble4();

                for (int j = 0; j < 4; j++)
                {
                    if (min[j] > max[j])
                    {
                        double t = min[j];
                        min[j] = max[j];
                        max[j] = t;
                    }
                }

                Assert.AreEqual(x >= min & x <= max, maxmath.isinrange(x, min, max));
            }
        }
    }
}