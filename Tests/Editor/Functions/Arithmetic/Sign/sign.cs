using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_sign
    {
        [Test]
        public static void _int128()
        {
            Assert.AreEqual((Int128)0, maxmath.sign((Int128)0));

            Random128 rng = Random128.New;

            for (int i = 0; i < 16; i++)
            {
                Int128 value = rng.NextInt128();

                Assert.AreEqual((int)maxmath.sign(value), value < 0 ? -1 : value == 0 ? 0 : 1);
            }
        }


        [Test]
        public static void _sbyte()
        {
            Assert.AreEqual(0, maxmath.sign((sbyte)0));

            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte value = rng.NextSByte();

                Assert.AreEqual(maxmath.sign(value), value < 0 ? -1 : value == 0 ? 0 : 1);
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Assert.AreEqual((sbyte2)0, maxmath.sign((sbyte2)0));

            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte2 value = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Assert.AreEqual((sbyte3)0, maxmath.sign((sbyte3)0));

            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3 value = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Assert.AreEqual((sbyte4)0, maxmath.sign((sbyte4)0));

            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4 value = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Assert.AreEqual((sbyte8)0, maxmath.sign((sbyte8)0));

            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte8 value = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Assert.AreEqual((sbyte16)0, maxmath.sign((sbyte16)0));

            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte16 value = rng.NextSByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Assert.AreEqual((sbyte32)0, maxmath.sign((sbyte32)0));

            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte32 value = rng.NextSByte32();

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }


        [Test]
        public static void _short()
        {
            Assert.AreEqual(0, maxmath.sign((short)0));

            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short value = rng.NextShort();

                Assert.AreEqual(maxmath.sign(value), value < 0 ? -1 : value == 0 ? 0 : 1);
            }
        }

        [Test]
        public static void _short2()
        {
            Assert.AreEqual((short2)0, maxmath.sign((short2)0));

            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2 value = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Assert.AreEqual((short3)0, maxmath.sign((short3)0));

            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3 value = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Assert.AreEqual((short4)0, maxmath.sign((short4)0));

            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4 value = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Assert.AreEqual((short8)0, maxmath.sign((short8)0));

            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short8 value = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Assert.AreEqual((short16)0, maxmath.sign((short16)0));

            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short16 value = rng.NextShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }


        [Test]
        public static void _int()
        {
            Assert.AreEqual(0, maxmath.sign((int)0));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int value = rng.NextInt();

                Assert.AreEqual(maxmath.sign(value, Promise.Nothing), value < 0 ? -1 : value == 0 ? 0 : 1);
            }
        }

        [Test]
        public static void _int2()
        {
            Assert.AreEqual((int2)0, maxmath.sign((int2)0));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2 value = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Assert.AreEqual((int3)0, maxmath.sign((int3)0));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int3 value = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Assert.AreEqual((int4)0, maxmath.sign((int4)0));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int4 value = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Assert.AreEqual((int8)0, maxmath.sign((int8)0));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int8 value = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }


        [Test]
        public static void _long()
        {
            Assert.AreEqual(0, maxmath.sign((long)0, Promise.Nothing));

            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long value = rng.NextLong();

                Assert.AreEqual(maxmath.sign(value, Promise.Nothing), value < 0 ? -1 : value == 0 ? 0 : 1);
            }
        }

        [Test]
        public static void _long2()
        {
            Assert.AreEqual((long2)0, maxmath.sign((long2)0));

            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2 value = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Assert.AreEqual((long3)0, maxmath.sign((long3)0));

            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3 value = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Assert.AreEqual((long4)0, maxmath.sign((long4)0));

            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4 value = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0 ? -1 : value[j] == 0 ? 0 : 1);
                }
            }
        }


        [Test]
        public static void _quarter()
        {
            Assert.AreEqual(0f, (float)maxmath.sign((quarter)0));
            Assert.AreEqual(0f, (float)maxmath.sign(maxmath.asquarter((byte)(1 << 7))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter value = (quarter)rng.NextFloat(quarter.MinValue, quarter.MaxValue);

                Assert.AreEqual((float)maxmath.sign(value), value < 0f ? -1f : value == 0f ? 0f : 1f);
            }
        }

        [Test]
        public static void _quarter2()
        {
            Assert.AreEqual((float2)0f, (float2)maxmath.sign((quarter2)0));
            Assert.AreEqual((float2)0f, (float2)maxmath.sign(maxmath.asquarter((byte2)(1 << 7))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter2 value = (quarter2)rng.NextFloat2(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Assert.AreEqual((float3)0f, (float3)maxmath.sign((quarter3)0));
            Assert.AreEqual((float3)0f, (float3)maxmath.sign(maxmath.asquarter((byte3)(1 << 7))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter3 value = (quarter3)rng.NextFloat3(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Assert.AreEqual((float4)0f, (float4)maxmath.sign((quarter4)0));
            Assert.AreEqual((float4)0f, (float4)maxmath.sign(maxmath.asquarter((byte4)(1 << 7))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter4 value = (quarter4)rng.NextFloat4(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Assert.AreEqual((float8)0f, (float8)maxmath.sign((quarter8)0));
            Assert.AreEqual((float8)0f, (float8)maxmath.sign(maxmath.asquarter((byte8)(1 << 7))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter8 value = (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _quarter16()
        {
            Assert.AreEqual((quarter16)0f, maxmath.sign((quarter16)0));
            Assert.AreEqual((quarter16)0f, maxmath.sign(maxmath.asquarter((byte16)(1 << 7))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter16 value = new quarter16((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _quarter32()
        {
            Assert.AreEqual((quarter32)0f, maxmath.sign((quarter32)0));
            Assert.AreEqual((quarter32)0f, maxmath.sign(maxmath.asquarter((byte32)(1 << 7))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 32; i++)
            {
                quarter32 value = new quarter32((quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue), (quarter8)rng.NextFloat8(quarter.MinValue, quarter.MaxValue));

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }


        [Test]
        public static void _half()
        {
            Assert.AreEqual(0f, (float)maxmath.sign((half)0));
            Assert.AreEqual(0f, (float)maxmath.sign(maxmath.ashalf((ushort)(1 << 15))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half value = (half)rng.NextFloat(half.MinValue, half.MaxValue);

                Assert.AreEqual((float)maxmath.sign(value), value < 0f ? -1f : value == 0f ? 0f : 1f);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.AreEqual((float2)0f, (float2)maxmath.sign((half2)0));
            Assert.AreEqual((float2)0f, (float2)maxmath.sign(maxmath.ashalf((ushort2)(1 << 15))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half2 value = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Assert.AreEqual((float3)0f, (float3)maxmath.sign((half3)0));
            Assert.AreEqual((float3)0f, (float3)maxmath.sign(maxmath.ashalf((ushort3)(1 << 15))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half3 value = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Assert.AreEqual((float4)0f, (float4)maxmath.sign((half4)0));
            Assert.AreEqual((float4)0f, (float4)maxmath.sign(maxmath.ashalf((ushort4)(1 << 15))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half4 value = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Assert.AreEqual((float8)0f, (float8)maxmath.sign((half8)0));
            Assert.AreEqual((float8)0f, (float8)maxmath.sign(maxmath.ashalf((ushort8)(1 << 15))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half8 value = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }

        [Test]
        public static void _half16()
        {
            Assert.AreEqual((half16)0f, maxmath.sign((half16)0));
            Assert.AreEqual((half16)0f, maxmath.sign(maxmath.ashalf((ushort16)(1 << 15))));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half16 value = new half16((half8)rng.NextFloat8(half.MinValue, half.MaxValue), (half8)rng.NextFloat8(half.MinValue, half.MaxValue));

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual((float)maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }


        [Test]
        public static void _float8()
        {
            Assert.AreEqual((float8)0f, maxmath.sign((float8)0));
            Assert.AreEqual((float8)0f, maxmath.sign(maxmath.asfloat((int8)1 << 31)));

            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float8 value = rng.NextFloat8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.sign(value)[j], value[j] < 0f ? -1f : value[j] == 0f ? 0f : 1f);
                }
            }
        }
    }
}