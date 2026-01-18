using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_toquarterunsafe
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte b = rng.NextByte(0, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte2 b = rng.NextByte2(0, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte3 b = rng.NextByte3(0, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte4 b = rng.NextByte4(0, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte8 b = rng.NextByte8(0, 16);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte16 b = rng.NextByte16(0, 16);

                Assert.AreEqual((quarter16)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                byte32 b = rng.NextByte32(0, 16);

                Assert.AreEqual((quarter32)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort b = rng.NextUShort(0, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort2 b = rng.NextUShort2(0, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort3 b = rng.NextUShort3(0, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort4 b = rng.NextUShort4(0, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort8 b = rng.NextUShort8(0, 16);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                ushort16 b = rng.NextUShort16(0, 16);

                Assert.AreEqual((quarter16)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint b = rng.NextUInt(0, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint2 b = rng.NextUInt2(0, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint3 b = rng.NextUInt3(0, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint4 b = rng.NextUInt4(0, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                uint8 b = rng.NextUInt8(0, 16);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong b = rng.NextULong(0, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong2 b = rng.NextULong2(0, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong3 b = rng.NextULong3(0, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                ulong4 b = rng.NextULong4(0, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 24; i++)
            {
                UInt128 b = rng.NextUInt128(0, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte b = rng.NextSByte(-15, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 b = rng.NextSByte2(-15, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter2)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 b = rng.NextSByte3(-15, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter3)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 b = rng.NextSByte4(-15, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter4)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 b = rng.NextSByte8(-15, 16);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter8)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 b = rng.NextSByte16(-15, 16);

                Assert.AreEqual((quarter16)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter16)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte32 b = rng.NextSByte32(-15, 16);

                Assert.AreEqual((quarter32)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter32)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short b = rng.NextShort(-15, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 b = rng.NextShort2(-15, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter2)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 b = rng.NextShort3(-15, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter3)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 b = rng.NextShort4(-15, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter4)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 b = rng.NextShort8(-15, 16);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter8)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 b = rng.NextShort16(-15, 16);

                Assert.AreEqual((quarter16)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter16)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int b = rng.NextInt(-15, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 b = rng.NextInt2(-15, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter2)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 b = rng.NextInt3(-15, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter3)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 b = rng.NextInt4(-15, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter4)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 b = rng.NextInt8(-15, 16);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter8)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long b = rng.NextLong(-15, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long2 b = rng.NextLong2(-15, 16);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter2)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long3 b = rng.NextLong3(-15, 16);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter3)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                long4 b = rng.NextLong4(-15, 16);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter4)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 24; i++)
            {
                Int128 b = rng.NextInt128(-15, 16);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half b = (half)rng.NextFloat(-15.5f, 15.5f);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half2 b = (half2)rng.NextFloat2(-15.5f, 15.5f);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter2)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(b != (float2)0f) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half3 b = (half3)rng.NextFloat3(-15.5f, 15.5f);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter3)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(b != (float3)0f) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half4 b = (half4)rng.NextFloat4(-15.5f, 15.5f);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter4)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(b != (float4)0f) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half8 b = (half8)rng.NextFloat8(-15.5f, 15.5f);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter8)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.all(b != (float8)0f) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half16 b = new half16((half8)rng.NextFloat8(-15.5f, 15.5f), (half8)rng.NextFloat8(-15.5f, 15.5f));

                Assert.AreEqual((quarter16)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter16)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.all(b.v8_0 != (float8)0f) && maxmath.all(b.v8_8 != (float8)0f) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24000; i++)
            {
                float b = rng.NextFloat(-15.5f, 15.5f);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float2 b = rng.NextFloat2(-15.5f, 15.5f);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter2)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float3 b = rng.NextFloat3(-15.5f, 15.5f);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter3)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float4 b = rng.NextFloat4(-15.5f, 15.5f);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter4)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float8 b = rng.NextFloat8(-15.5f, 15.5f);

                Assert.AreEqual((quarter8)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter8)maxmath.abs(b), maxmath.toquarterunsafe(maxmath.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double b = rng.NextDouble(-15.5f, 15.5f);

                Assert.AreEqual((quarter)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double2 b = rng.NextDouble2(-15.5f, 15.5f);

                Assert.AreEqual((quarter2)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter2)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double3 b = rng.NextDouble3(-15.5f, 15.5f);

                Assert.AreEqual((quarter3)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter3)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double4 b = rng.NextDouble4(-15.5f, 15.5f);

                Assert.AreEqual((quarter4)b, maxmath.toquarterunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((quarter4)math.abs(b), maxmath.toquarterunsafe(math.abs(b), Promise.NoOverflow | Promise.ZeroOrGreater));
            }
        }
    }
}
