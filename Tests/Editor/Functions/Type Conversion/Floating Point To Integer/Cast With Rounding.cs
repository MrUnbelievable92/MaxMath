using NUnit.Framework;


using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath.Tests
{
    unsafe public static class f_roundtosbyte
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(-15f, 15f + float.Epsilon);

                Assert.AreEqual((sbyte)math.round(q), math.roundtosbyte(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(-15f, 15f + float.Epsilon);

                Assert.AreEqual((sbyte2)math.round(q), math.roundtosbyte(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(-15f, 15f + float.Epsilon);

                Assert.AreEqual((sbyte3)math.round(q), math.roundtosbyte(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(-15f, 15f + float.Epsilon);

                Assert.AreEqual((sbyte4)math.round(q), math.roundtosbyte(q));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter8 q = (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon);

                Assert.AreEqual((sbyte8)math.round((float8)q), math.roundtosbyte(q));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter16 q = new quarter16((quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon));

                Assert.AreEqual(new sbyte16((sbyte8)math.round((float8)q.v8_0), (sbyte8)math.round((float8)q.v8_8)), math.roundtosbyte(q));
            }
        }

        [Test]
        public static void _quarter32()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter32 q = new quarter32((quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon));

                Assert.AreEqual(new sbyte32((sbyte8)math.round((float8)q.v8_0), (sbyte8)math.round((float8)q.v8_8), (sbyte8)math.round((float8)q.v8_16), (sbyte8)math.round((float8)q.v8_24)), math.roundtosbyte(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte)math.round(h), math.roundtosbyte(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte2)math.round(h), math.roundtosbyte(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte3)math.round(h), math.roundtosbyte(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte4)math.round(h), math.roundtosbyte(h));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half8 h = (half8)rng.NextFloat8(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte8)math.round(h), math.roundtosbyte(h));
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half16 q = new half16((half8)rng.NextFloat8(sbyte.MinValue, sbyte.MaxValue + 1), (half8)rng.NextFloat8(sbyte.MinValue, sbyte.MaxValue + 1));

                Assert.AreEqual(new sbyte16((sbyte8)math.round((float8)q.v8_0), (sbyte8)math.round((float8)q.v8_8)), math.roundtosbyte(q));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte)math.round(f), math.roundtosbyte(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte2)math.round(f), math.roundtosbyte(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte3)math.round(f), math.roundtosbyte(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte4)math.round(f), math.roundtosbyte(f));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float8 f = rng.NextFloat8(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte8)math.round(f), math.roundtosbyte(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte)math.round(d), math.roundtosbyte(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte2)math.round(d), math.roundtosbyte(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte3)math.round(d), math.roundtosbyte(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4(sbyte.MinValue, sbyte.MaxValue + 1);

                Assert.AreEqual((sbyte4)math.round(d), math.roundtosbyte(d));
            }
        }
    }

    unsafe public static class f_roundtobyte
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(0f, 15f + float.Epsilon);

                Assert.AreEqual((byte)math.round(q), math.roundtobyte(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(0f, 15f + float.Epsilon);

                Assert.AreEqual((byte2)math.round(q), math.roundtobyte(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(0f, 15f + float.Epsilon);

                Assert.AreEqual((byte3)math.round(q), math.roundtobyte(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(0f, 15f + float.Epsilon);

                Assert.AreEqual((byte4)math.round(q), math.roundtobyte(q));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter8 q = (quarter8)rng.NextFloat8(0f, 15f + float.Epsilon);

                Assert.AreEqual((byte8)math.round((float8)q), math.roundtobyte(q));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter16 q = new quarter16((quarter8)rng.NextFloat8(0f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(0f, 15f + float.Epsilon));

                Assert.AreEqual(new byte16((byte8)math.round((float8)q.v8_0), (byte8)math.round((float8)q.v8_8)), math.roundtobyte(q));
            }
        }

        [Test]
        public static void _quarter32()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter32 q = new quarter32((quarter8)rng.NextFloat8(0f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(0f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(0f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(0f, 15f + float.Epsilon));

                Assert.AreEqual(new byte32((byte8)math.round((float8)q.v8_0), (byte8)math.round((float8)q.v8_8), (byte8)math.round((float8)q.v8_16), (byte8)math.round((float8)q.v8_24)), math.roundtobyte(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte)math.round(h), math.roundtobyte(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte2)math.round(h), math.roundtobyte(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte3)math.round(h), math.roundtobyte(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte4)math.round(h), math.roundtobyte(h));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half8 h = (half8)rng.NextFloat8((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte8)math.round(h), math.roundtobyte(h));
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half16 q = new half16((half8)rng.NextFloat8((float)byte.MinValue, byte.MaxValue + 1), (half8)rng.NextFloat8((float)byte.MinValue, byte.MaxValue + 1));

                Assert.AreEqual(new byte16((byte8)math.round((float8)q.v8_0), (byte8)math.round((float8)q.v8_8)), math.roundtobyte(q));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte)math.round(f), math.roundtobyte(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte2)math.round(f), math.roundtobyte(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte3)math.round(f), math.roundtobyte(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte4)math.round(f), math.roundtobyte(f));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float8 f = rng.NextFloat8((float)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte8)math.round(f), math.roundtobyte(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte)math.round(d), math.roundtobyte(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2((double)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte2)math.round(d), math.roundtobyte(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3((double)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte3)math.round(d), math.roundtobyte(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4((double)byte.MinValue, byte.MaxValue + 1);

                Assert.AreEqual((byte4)math.round(d), math.roundtobyte(d));
            }
        }
    }

    unsafe public static class f_roundtoshort
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(-15f, 15f + float.Epsilon);

                Assert.AreEqual((short)math.round(q), math.roundtoshort(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(-15f, 15f + float.Epsilon);

                Assert.AreEqual((short2)math.round(q), math.roundtoshort(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(-15f, 15f + float.Epsilon);

                Assert.AreEqual((short3)math.round(q), math.roundtoshort(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(-15f, 15f + float.Epsilon);

                Assert.AreEqual((short4)math.round(q), math.roundtoshort(q));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter8 q = (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon);

                Assert.AreEqual((short8)math.round((float8)q), math.roundtoshort(q));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter16 q = new quarter16((quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon), (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon));

                Assert.AreEqual(new short16((short8)math.round((float8)q.v8_0), (short8)math.round((float8)q.v8_8)), math.roundtoshort(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short)math.round(h), math.roundtoshort(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short2)math.round(h), math.roundtoshort(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short3)math.round(h), math.roundtoshort(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short4)math.round(h), math.roundtoshort(h));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half8 h = (half8)rng.NextFloat8(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short8)math.round(h), math.roundtoshort(h));
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half16 q = new half16((half8)rng.NextFloat8(-15f, 15f + float.Epsilon), (half8)rng.NextFloat8(-15f, 15f + float.Epsilon));

                Assert.AreEqual(new short16((short8)math.round((float8)q.v8_0), (short8)math.round((float8)q.v8_8)), math.roundtoshort(q));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short)math.round(f), math.roundtoshort(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short2)math.round(f), math.roundtoshort(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short3)math.round(f), math.roundtoshort(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short4)math.round(f), math.roundtoshort(f));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float8 f = rng.NextFloat8(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short8)math.round(f), math.roundtoshort(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short)math.round(d), math.roundtoshort(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short2)math.round(d), math.roundtoshort(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short3)math.round(d), math.roundtoshort(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4(short.MinValue, short.MaxValue + 1);

                Assert.AreEqual((short4)math.round(d), math.roundtoshort(d));
            }
        }
    }

    unsafe public static class f_roundtoushort
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(0f, 15f + float.Epsilon);

                Assert.AreEqual((ushort)math.round(q), math.roundtoushort(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(0f, 15f + float.Epsilon);

                Assert.AreEqual((ushort2)math.round(q), math.roundtoushort(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(0f, 15f + float.Epsilon);

                Assert.AreEqual((ushort3)math.round(q), math.roundtoushort(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(0f, 15f + float.Epsilon);

                Assert.AreEqual((ushort4)math.round(q), math.roundtoushort(q));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter8 q = (quarter8)rng.NextFloat8(0f, 15f + float.Epsilon);

                Assert.AreEqual((ushort8)math.round((float8)q), math.roundtoushort(q));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter16 q = new quarter16((quarter8)rng.NextFloat8(0, 15f + float.Epsilon), (quarter8)rng.NextFloat8(0, 15f + float.Epsilon));

                Assert.AreEqual(new ushort16((ushort8)math.round((float8)q.v8_0), (ushort8)math.round((float8)q.v8_8)), math.roundtoushort(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(ushort.MinValue, half.MaxValue + float.Epsilon);

                Assert.AreEqual((ushort)math.round(h), math.roundtoushort(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2((float)ushort.MinValue, half.MaxValue + float.Epsilon);

                Assert.AreEqual((ushort2)math.round(h), math.roundtoushort(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3((float)ushort.MinValue, half.MaxValue + float.Epsilon);

                Assert.AreEqual((ushort3)math.round(h), math.roundtoushort(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4((float)ushort.MinValue, half.MaxValue + float.Epsilon);

                Assert.AreEqual((ushort4)math.round(h), math.roundtoushort(h));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half8 h = (half8)rng.NextFloat8((float)ushort.MinValue, half.MaxValue + float.Epsilon);

                Assert.AreEqual((ushort8)math.round(h), math.roundtoushort(h));
            }
        }

        [Test]
        public static void _half16()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half16 q = new half16((half8)rng.NextFloat8((float)ushort.MinValue, half.MaxValue + float.Epsilon), (half8)rng.NextFloat8((float)ushort.MinValue, half.MaxValue + float.Epsilon));

                Assert.AreEqual(new ushort16((ushort8)math.round((float8)q.v8_0), (ushort8)math.round((float8)q.v8_8)), math.roundtoushort(q));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort)math.round(f), math.roundtoushort(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2((float)ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort2)math.round(f), math.roundtoushort(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3((float)ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort3)math.round(f), math.roundtoushort(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4((float)ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort4)math.round(f), math.roundtoushort(f));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float8 f = rng.NextFloat8((float)ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort8)math.round(f), math.roundtoushort(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort)math.round(d), math.roundtoushort(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2((double)ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort2)math.round(d), math.roundtoushort(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3((double)ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort3)math.round(d), math.roundtoushort(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4((double)ushort.MinValue, ushort.MaxValue + 1);

                Assert.AreEqual((ushort4)math.round(d), math.roundtoushort(d));
            }
        }
    }

    unsafe public static class f_roundtoint
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(-15f, 15f + float.Epsilon);

                Assert.AreEqual((int)math.round(q), math.roundtoint(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(-15f, 15f + float.Epsilon);

                Assert.AreEqual((int2)math.round(q), math.roundtoint(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(-15f, 15f + float.Epsilon);

                Assert.AreEqual((int3)math.round(q), math.roundtoint(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(-15f, 15f + float.Epsilon);

                Assert.AreEqual((int4)math.round(q), math.roundtoint(q));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter8 q = (quarter8)rng.NextFloat8(-15f, 15f + float.Epsilon);

                Assert.AreEqual((int8)math.round((float8)q), math.roundtoint(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((int)math.round(h), math.roundtoint(h));

                h = (half)rng.NextFloat(half.MinValue, half.MaxValue);

                Assert.AreEqual((int)math.round(h), math.roundtoint(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((int2)(float2)math.round(h), math.roundtoint(h));

                h = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);

                Assert.AreEqual((int2)(float2)math.round(h), math.roundtoint(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((int3)(float3)math.round(h), math.roundtoint(h));

                h = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);

                Assert.AreEqual((int3)(float3)math.round(h), math.roundtoint(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((int4)(float4)math.round(h), math.roundtoint(h));

                h = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);

                Assert.AreEqual((int4)(float4)math.round(h), math.roundtoint(h));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half8 h = (half8)rng.NextFloat8(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((int8)math.round(h), math.roundtoint(h));

                h = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);

                Assert.AreEqual((int8)(float8)math.round(h), math.roundtoint(h));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((int)math.round(f), math.roundtoint(f));

                f = rng.NextFloat(int.MinValue, int.MaxValue);

                Assert.AreEqual((int)math.round(f), math.roundtoint(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((int2)math.round(f), math.roundtoint(f));

                f = (float2)rng.NextFloat2(int.MinValue, int.MaxValue);

                Assert.AreEqual((int2)math.round(f), math.roundtoint(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((int3)math.round(f), math.roundtoint(f));

                f = (float3)rng.NextFloat3(int.MinValue, int.MaxValue);

                Assert.AreEqual((int3)math.round(f), math.roundtoint(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((int4)math.round(f), math.roundtoint(f));

                f = (float4)rng.NextFloat4(int.MinValue, int.MaxValue);

                Assert.AreEqual((int4)math.round(f), math.roundtoint(f));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float8 f = rng.NextFloat8(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((int8)math.round(f), math.roundtoint(f));

                f = (float8)rng.NextFloat8(int.MinValue, int.MaxValue);

                Assert.AreEqual((int8)math.round(f), math.roundtoint(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(int.MinValue, int.MaxValue + 1L);

                Assert.AreEqual((int)math.round(d), math.roundtoint(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2(int.MinValue, int.MaxValue + 1L);

                Assert.AreEqual((int2)math.round(d), math.roundtoint(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3(int.MinValue, int.MaxValue + 1L);

                Assert.AreEqual((int3)math.round(d), math.roundtoint(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4(int.MinValue, int.MaxValue + 1L);

                Assert.AreEqual((int4)math.round(d), math.roundtoint(d));
            }
        }
    }

    unsafe public static class f_roundtouint
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(0f, 15f + float.Epsilon);

                Assert.AreEqual((uint)math.round((float)q), math.roundtouint(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(0f, 15f + float.Epsilon);

                Assert.AreEqual((uint2)math.round((float2)q), math.roundtouint(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(0f, 15f + float.Epsilon);

                Assert.AreEqual((uint3)math.round((float3)q), math.roundtouint(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(0f, 15f + float.Epsilon);

                Assert.AreEqual((uint4)math.round((float4)q), math.roundtouint(q));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                quarter8 q = (quarter8)rng.NextFloat8(0f, 15f + float.Epsilon);

                Assert.AreEqual((uint8)math.round((float8)q), math.roundtouint(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint)math.round(h), math.roundtouint(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint2)(float2)math.round(h), math.roundtouint(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint3)(float3)math.round(h), math.roundtouint(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint4)(float4)math.round(h), math.roundtouint(h));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                half8 h = (half8)rng.NextFloat8(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint8)math.round(h), math.roundtouint(h));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint)math.round(f), math.roundtouint(f));

                f = rng.NextFloat(0, uint.MaxValue);

                Assert.AreEqual((uint)math.round(f), math.roundtouint(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2((float)0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint2)math.round(f), math.roundtouint(f));

                f = rng.NextFloat2(0, uint.MaxValue);

                Assert.AreEqual((uint2)math.round(f), math.roundtouint(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3((float)0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint3)math.round(f), math.roundtouint(f));

                f = rng.NextFloat3(0, uint.MaxValue);

                Assert.AreEqual((uint3)math.round(f), math.roundtouint(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4((float)0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint4)math.round(f), math.roundtouint(f));

                f = rng.NextFloat4(0, uint.MaxValue);

                Assert.AreEqual((uint4)math.round(f), math.roundtouint(f));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 64; i++)
            {
                float8 f = rng.NextFloat8(0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((uint8)math.round(f), math.roundtouint(f));

                f = rng.NextFloat8(0, uint.MaxValue);

                Assert.AreEqual((uint8)math.round(f), math.roundtouint(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(uint.MinValue, uint.MaxValue + 1ul);

                Assert.AreEqual((uint)math.round(d), math.roundtouint(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2((double)uint.MinValue, uint.MaxValue + 1ul);

                Assert.AreEqual((uint2)math.round(d), math.roundtouint(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3((double)uint.MinValue, uint.MaxValue + 1ul);

                Assert.AreEqual((uint3)math.round(d), math.roundtouint(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4((double)uint.MinValue, uint.MaxValue + 1ul);

                Assert.AreEqual((uint4)math.round(d), math.roundtouint(d));
            }
        }
    }

    unsafe public static class f_roundtolong
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(-15f, 15f + float.Epsilon);

                Assert.AreEqual((long)math.round(q), math.roundtolong(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(-15f, 15f + float.Epsilon);

                Assert.AreEqual((long2)math.round(q), math.roundtolong(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(-15f, 15f + float.Epsilon);

                Assert.AreEqual((long3)math.round(q), math.roundtolong(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(-15f, 15f + float.Epsilon);

                Assert.AreEqual((long4)math.round(q), math.roundtolong(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((long)math.round(h), math.roundtolong(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((long2)(float2)math.round(h), math.roundtolong(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((long3)(float3)math.round(h), math.roundtolong(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((long4)(float4)math.round(h), math.roundtolong(h));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((long)math.round(f), math.roundtolong(f));

                f = rng.NextFloat(long.MinValue, long.MaxValue);

                Assert.AreEqual((long)math.round(f), math.roundtolong(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((long2)math.round(f), math.roundtolong(f));

                f = (float2)rng.NextFloat2(long.MinValue, long.MaxValue);

                Assert.AreEqual((long2)math.round(f), math.roundtolong(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((long3)math.round(f), math.roundtolong(f));

                f = (float3)rng.NextFloat3(long.MinValue, long.MaxValue);

                Assert.AreEqual((long3)math.round(f), math.roundtolong(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((long4)math.round(f), math.roundtolong(f));

                f = (float4)rng.NextFloat4(long.MinValue, long.MaxValue);

                Assert.AreEqual((long4)math.round(f), math.roundtolong(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(-(1L << F64_MANTISSA_BITS), (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((long)math.round(d), math.roundtolong(d));

                d = rng.NextDouble(long.MinValue, long.MaxValue);

                Assert.AreEqual((long)math.round(d), math.roundtolong(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2(-(1L << F64_MANTISSA_BITS), (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((long2)math.round(d), math.roundtolong(d));

                d = rng.NextDouble2(long.MinValue, long.MaxValue);

                Assert.AreEqual((long2)math.round(d), math.roundtolong(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3(-(1L << F64_MANTISSA_BITS), (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((long3)math.round(d), math.roundtolong(d));

                d = rng.NextDouble3(long.MinValue, long.MaxValue);

                Assert.AreEqual((long3)math.round(d), math.roundtolong(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4(-(1L << F64_MANTISSA_BITS), (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((long4)math.round(d), math.roundtolong(d));

                d = rng.NextDouble4(long.MinValue, long.MaxValue);

                Assert.AreEqual((long4)math.round(d), math.roundtolong(d));
            }
        }
    }

    unsafe public static class f_roundtoulong
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(0f, 15f + float.Epsilon);

                Assert.AreEqual((ulong)math.round(q), math.roundtoulong(q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter2 q = (quarter2)rng.NextFloat2(0f, 15f + float.Epsilon);

                Assert.AreEqual((ulong2)math.round(q), math.roundtoulong(q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter3 q = (quarter3)rng.NextFloat3(0f, 15f + float.Epsilon);

                Assert.AreEqual((ulong3)math.round(q), math.roundtoulong(q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter4 q = (quarter4)rng.NextFloat4(0f, 15f + float.Epsilon);

                Assert.AreEqual((ulong4)math.round(q), math.roundtoulong(q));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong)math.round(h), math.roundtoulong(h));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half2 h = (half2)rng.NextFloat2(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong2)(float2)math.round(h), math.roundtoulong(h));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half3 h = (half3)rng.NextFloat3(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong3)(float3)math.round(h), math.roundtoulong(h));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half4 h = (half4)rng.NextFloat4(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong4)(float4)math.round(h), math.roundtoulong(h));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong)math.round(f), math.roundtoulong(f));

                f = rng.NextFloat(0, ulong.MaxValue);

                Assert.AreEqual((ulong)math.round(f), math.roundtoulong(f));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float2 f = rng.NextFloat2((float)0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong2)math.round(f), math.roundtoulong(f));

                f = (float2)rng.NextFloat2(0, ulong.MaxValue);

                Assert.AreEqual((ulong2)math.round(f), math.roundtoulong(f));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float3 f = rng.NextFloat3((float)0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong3)math.round(f), math.roundtoulong(f));

                f = (float3)rng.NextFloat3(0, ulong.MaxValue);

                Assert.AreEqual((ulong3)math.round(f), math.roundtoulong(f));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float4 f = rng.NextFloat4((float)0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong4)math.round(f), math.roundtoulong(f));

                f = (float4)rng.NextFloat4(0, ulong.MaxValue);

                Assert.AreEqual((ulong4)math.round(f), math.roundtoulong(f));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(0d, (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong)math.round(d), math.roundtoulong(d));

                d = rng.NextDouble(0d, ulong.MaxValue);

                Assert.AreEqual((ulong)math.round(d), math.roundtoulong(d));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double2 d = rng.NextDouble2((double)0d, (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong2)math.round(d), math.roundtoulong(d));

                d = (double2)rng.NextDouble2(0d, ulong.MaxValue);

                Assert.AreEqual((ulong2)math.round(d), math.roundtoulong(d));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double3 d = rng.NextDouble3((double)0d, (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong3)math.round(d), math.roundtoulong(d));

                d = (double3)rng.NextDouble3(0d, ulong.MaxValue);

                Assert.AreEqual((ulong3)math.round(d), math.roundtoulong(d));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double4 d = rng.NextDouble4((double)0d, (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((ulong4)math.round(d), math.roundtoulong(d));

                d = (double4)rng.NextDouble4(0d, ulong.MaxValue);

                Assert.AreEqual((ulong4)math.round(d), math.roundtoulong(d));
            }
        }
    }

    unsafe public static class f_roundtoint128
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (Int128 i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(-15f, 15f + float.Epsilon);

                Assert.AreEqual((Int128)math.round(q), math.roundtoint128(q));
            }
        }

        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (Int128 i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(-(1 << F16_MANTISSA_BITS), (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((Int128)math.round(h), math.roundtoint128(h));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (Int128 i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(-(1 << F32_MANTISSA_BITS), (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((Int128)math.round(f), math.roundtoint128(f));

                f = rng.NextFloat(Int128.MinValue, Int128.MaxValue);

                Assert.AreEqual((Int128)math.round(f), math.roundtoint128(f));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (Int128 i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(-(1L << F64_MANTISSA_BITS), (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((Int128)math.round(d), math.roundtoint128(d));

                d = rng.NextDouble(Int128.MinValue, Int128.MaxValue);

                Assert.AreEqual((Int128)math.round(d), math.roundtoint128(d));
            }
        }

    }

    unsafe public static class f_roundtouint128
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                quarter q = (quarter)rng.NextFloat(0f, 15f + float.Epsilon);

                Assert.AreEqual((UInt128)math.round(q), math.roundtouint128(q));
            }
        }

        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                half h = (half)rng.NextFloat(0, (1 << F16_MANTISSA_BITS) + 1);

                Assert.AreEqual((UInt128)math.round(h), math.roundtouint128(h));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (long i = 0; i < 64; i++)
            {
                float f = rng.NextFloat(0, (1 << F32_MANTISSA_BITS) + 1);

                Assert.AreEqual((UInt128)math.round(f), math.roundtouint128(f));

                f = rng.NextFloat(0, UInt128.MaxValue);

                Assert.AreEqual((UInt128)math.round(f), math.roundtouint128(f));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 64; i++)
            {
                double d = rng.NextDouble(0d, (1L << F64_MANTISSA_BITS) + 1);

                Assert.AreEqual((UInt128)math.round(d), math.roundtouint128(d));

                d = rng.NextDouble(0d, UInt128.MaxValue);

                Assert.AreEqual((UInt128)math.round(d), math.roundtouint128(d));
            }
        }
    }
}
