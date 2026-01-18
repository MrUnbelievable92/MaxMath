using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_tohalfunsafe
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte b = rng.NextByte();

                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte2 b = rng.NextByte2();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte3 b = rng.NextByte3();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte4 b = rng.NextByte4();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte8 b = rng.NextByte8();
                
                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte16 b = rng.NextByte16();
                
                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort b = rng.NextUShort();

                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUShort(0, 2048);

                Promise p = Promise.Unsafe0 | (b != 0 ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort2 b = rng.NextUShort2();

                if (math.all(b != 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUShort2(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 b = rng.NextUShort3();

                if (math.all(b != 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUShort3(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 b = rng.NextUShort4();

                if (math.all(b != 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUShort4(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 b = rng.NextUShort8();

                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUShort8(0, 2048);

                Promise p = Promise.Unsafe0 | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 b = rng.NextUShort16();

                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUShort16(0, 2048);

                Promise p = Promise.Unsafe0 | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, p));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint b = rng.NextUInt();

                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUInt(0, 2048);

                Promise p = Promise.Unsafe0 | (b != 0 ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint2 b = rng.NextUInt2();

                if (math.all(b != 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUInt2(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint3 b = rng.NextUInt3();

                if (math.all(b != 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUInt3(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint4 b = rng.NextUInt4();

                if (math.all(b != 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUInt4(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint8 b = rng.NextUInt8();

                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUInt8(0, 2048);

                Promise p = Promise.Unsafe0 | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, p));
            }
        }

        
        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong b = rng.NextULong();

                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextULong(0, 2048);

                Promise p = Promise.Unsafe0 | (b != 0 ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong2 b = rng.NextULong2();

                if (math.all(b != 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextULong2(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong3 b = rng.NextULong3();

                if (math.all(b != 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextULong3(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong4 b = rng.NextULong4();

                if (math.all(b != 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextULong4(0, 2048);

                Promise p = Promise.Unsafe0 | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, p));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 24; i++)
            {
                UInt128 b = rng.NextUInt128();

                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }

                b = rng.NextUInt128(0, 2048);

                Promise p = Promise.Unsafe0 | (b != 0 ? Promise.NonZero : Promise.Nothing);
                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, p));
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte b = rng.NextSByte();
                
                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (b >= 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing)));
                }
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 b = rng.NextSByte2();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 b = rng.NextSByte3();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 b = rng.NextSByte4();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 b = rng.NextSByte8();
                
                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (maxmath.all(b >= 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 b = rng.NextSByte16();
                
                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (maxmath.all(b >= 0))
                {
                    Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short b = rng.NextShort();
                
                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (b >= 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextShort(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (b != 0)
                {
                    p |= Promise.NonZero;
                }
                
                if (b >= 0)
                {
                    p |= Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 b = rng.NextShort2();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextShort2(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 b = rng.NextShort3();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextShort3(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 b = rng.NextShort4();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextShort4(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 b = rng.NextShort8();
                
                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (maxmath.all(b >= 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextShort8(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (maxmath.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (maxmath.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 b = rng.NextShort16();
                
                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (maxmath.all(b >= 0))
                {
                    Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextShort16(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (maxmath.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (maxmath.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, p));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int b = rng.NextInt();
                
                if (b != 0)
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (b >= 0)
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextInt(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (b != 0)
                {
                    p |= Promise.NonZero;
                }
                
                if (b >= 0)
                {
                    p |= Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 b = rng.NextInt2();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextInt2(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 b = rng.NextInt3();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextInt3(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 b = rng.NextInt4();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextInt4(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual(Helper.ToHalf(b), maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 b = rng.NextInt8();
                
                if (maxmath.all(b != 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (maxmath.all(b >= 0))
                {
                    Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextInt8(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (maxmath.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (maxmath.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (maxmath.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, p));
            }
        }

        
        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long b = rng.NextLong();
                
                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (b >= 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextLong(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (b != 0)
                {
                    p |= Promise.NonZero;
                }
                
                if (b >= 0)
                {
                    p |= Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long2 b = rng.NextLong2();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextLong2(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long3 b = rng.NextLong3();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextLong3(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, p));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long4 b = rng.NextLong4();
                
                if (math.all(b != 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (math.all(b >= 0))
                {
                    Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextLong4(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (math.all(b != 0))
                {
                    p |= Promise.NonZero;
                }
                
                if (math.all(b >= 0))
                {
                    p |= Promise.ZeroOrGreater | (math.all(b != 0) ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, p));
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 24; i++)
            {
                Int128 b = rng.NextInt128();
                
                if (b != 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                }
                
                if (b >= 0)
                {
                    Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing)));
                }

                b = rng.NextInt128(-2047, 2048);
                Promise p = Promise.Unsafe0;

                if (b != 0)
                {
                    p |= Promise.NonZero;
                }
                
                if (b >= 0)
                {
                    p |= Promise.ZeroOrGreater | (b != 0 ? Promise.NonZero : Promise.Nothing);
                }
                    
                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, p));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                quarter b = (quarter)rng.NextFloat(-15.5f, 15.5f);

                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((half)maxmath.abs(b), maxmath.tohalfunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                quarter2 b = (quarter2)rng.NextFloat2(-15.5f, 15.5f);

                Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((half2)maxmath.abs(b), maxmath.tohalfunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                quarter3 b = (quarter3)rng.NextFloat3(-15.5f, 15.5f);

                Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((half3)maxmath.abs(b), maxmath.tohalfunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                quarter4 b = (quarter4)rng.NextFloat4(-15.5f, 15.5f);

                Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((half4)maxmath.abs(b), maxmath.tohalfunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                quarter8 b = (quarter8)rng.NextFloat8(-15.5f, 15.5f);

                Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((half8)maxmath.abs(b), maxmath.tohalfunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                quarter16 b = new quarter16((quarter8)rng.NextFloat8(-15.5f, 15.5f), (quarter8)rng.NextFloat8(-15.5f, 15.5f));

                Assert.AreEqual((half16)b, maxmath.tohalfunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((half16)maxmath.abs(b), maxmath.tohalfunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float b = rng.NextFloat(half.MinValue, half.MaxValue);

                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float2 b = rng.NextFloat2(half.MinValue, half.MaxValue);

                Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half2)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float3 b = rng.NextFloat3(half.MinValue, half.MaxValue);

                Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half3)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float4 b = rng.NextFloat4(half.MinValue, half.MaxValue);

                Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half4)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float8 b = rng.NextFloat8(half.MinValue, half.MaxValue);

                Assert.AreEqual((half8)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half8)maxmath.abs(b), maxmath.tohalfunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double b = rng.NextDouble(half.MinValue, half.MaxValue);

                Assert.AreEqual((half)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double2 b = rng.NextDouble2(half.MinValue, half.MaxValue);

                Assert.AreEqual((half2)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half2)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double3 b = rng.NextDouble3(half.MinValue, half.MaxValue);

                Assert.AreEqual((half3)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half3)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double4 b = rng.NextDouble4(half.MinValue, half.MaxValue);

                Assert.AreEqual((half4)b, maxmath.tohalfunsafe(b, Promise.NonZero));
                Assert.AreEqual((half4)math.abs(b), maxmath.tohalfunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }
    }
}
