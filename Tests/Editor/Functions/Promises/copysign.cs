using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_PROMISE_copysign
    {
        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte2 l = rng.NextSByte2();
                sbyte2 r = math.abs(rng.NextSByte2());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte3 l = rng.NextSByte3();
                sbyte3 r = math.abs(rng.NextSByte3());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte4 l = rng.NextSByte4();
                sbyte4 r = math.abs(rng.NextSByte4());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte8 l = rng.NextSByte8();
                sbyte8 r = math.abs(rng.NextSByte8());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte16 l = rng.NextSByte16();
                sbyte16 r = math.abs(rng.NextSByte16());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                sbyte32 l = rng.NextSByte32();
                sbyte32 r = math.abs(rng.NextSByte32());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }



        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short2 l = rng.NextShort2();
                short2 r = math.abs(rng.NextShort2());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short3 l = rng.NextShort3();
                short3 r = math.abs(rng.NextShort3());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short4 l = rng.NextShort4();
                short4 r = math.abs(rng.NextShort4());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short8 l = rng.NextShort8();
                short8 r = math.abs(rng.NextShort8());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                short16 l = rng.NextShort16();
                short16 r = math.abs(rng.NextShort16());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }



        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 l = rng.NextInt2();
                int2 r = math.abs(rng.NextInt2());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 l = rng.NextInt3();
                int3 r = math.abs(rng.NextInt3());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 l = rng.NextInt4();
                int4 r = math.abs(rng.NextInt4());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 l = rng.NextInt8();
                int8 r = math.abs(rng.NextInt8());

                r = math.select(r, 1, r == 0);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }



        [Test]
        public static void _quarter()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                quarter l = math.asquarter(rng.NextSByte());
                quarter r = math.abs(math.asquarter(rng.NextSByte()));

                l = math.select(l, (quarter)1f, math.isnan(l));
                r = math.select(r, (quarter)1f, math.isnan(r));
                r = math.select(r, (quarter)1f, r == (quarter)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                quarter2 l = math.asquarter(rng.NextSByte2());
                quarter2 r = math.abs(math.asquarter(rng.NextSByte2()));

                l = math.select(l, (quarter)1f, math.isnan(l));
                r = math.select(r, (quarter)1f, math.isnan(r));
                r = math.select(r, (quarter)1f, r == (quarter)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                quarter3 l = math.asquarter(rng.NextSByte3());
                quarter3 r = math.abs(math.asquarter(rng.NextSByte3()));

                l = math.select(l, (quarter)1f, math.isnan(l));
                r = math.select(r, (quarter)1f, math.isnan(r));
                r = math.select(r, (quarter)1f, r == (quarter)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                quarter4 l = math.asquarter(rng.NextSByte4());
                quarter4 r = math.abs(math.asquarter(rng.NextSByte4()));

                l = math.select(l, (quarter)1f, math.isnan(l));
                r = math.select(r, (quarter)1f, math.isnan(r));
                r = math.select(r, (quarter)1f, r == (quarter)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                quarter8 l = math.asquarter(rng.NextSByte8());
                quarter8 r = math.abs(math.asquarter(rng.NextSByte8()));

                l = math.select(l, (quarter)1f, math.isnan(l));
                r = math.select(r, (quarter)1f, math.isnan(r));
                r = math.select(r, (quarter)1f, r == (quarter)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _quarter16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                quarter16 l = math.asquarter(rng.NextSByte16());
                quarter16 r = math.abs(math.asquarter(rng.NextSByte16()));

                l = math.select(l, (quarter)1f, math.isnan(l));
                r = math.select(r, (quarter)1f, math.isnan(r));
                r = math.select(r, (quarter)1f, r == (quarter)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _quarter32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 24; i++)
            {
                quarter32 l = math.asquarter(rng.NextSByte32());
                quarter32 r = math.abs(math.asquarter(rng.NextSByte32()));

                l = math.select(l, (quarter)1f, math.isnan(l));
                r = math.select(r, (quarter)1f, math.isnan(r));
                r = math.select(r, (quarter)1f, r == (quarter)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }



        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                half l = math.ashalf(rng.NextShort());
                half r = math.abs(math.ashalf(rng.NextShort()));

                l = math.select(l, (half)1f, math.isnan(l));
                r = math.select(r, (half)1f, math.isnan(r));
                r = math.select(r, (half)1f, r == (half)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                half2 l = math.ashalf(rng.NextShort2());
                half2 r = math.abs(math.ashalf(rng.NextShort2()));

                l = math.select(l, (half)1f, math.isnan(l));
                r = math.select(r, (half)1f, math.isnan(r));
                r = math.select(r, (half)1f, r == (half)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                half3 l = math.ashalf(rng.NextShort3());
                half3 r = math.abs(math.ashalf(rng.NextShort3()));

                l = math.select(l, (half)1f, math.isnan(l));
                r = math.select(r, (half)1f, math.isnan(r));
                r = math.select(r, (half)1f, r == (half)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                half4 l = math.ashalf(rng.NextShort4());
                half4 r = math.abs(math.ashalf(rng.NextShort4()));

                l = math.select(l, (half)1f, math.isnan(l));
                r = math.select(r, (half)1f, math.isnan(r));
                r = math.select(r, (half)1f, r == (half)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                half8 l = math.ashalf(rng.NextShort8());
                half8 r = math.abs(math.ashalf(rng.NextShort8()));

                l = math.select(l, (half)1f, math.isnan(l));
                r = math.select(r, (half)1f, math.isnan(r));
                r = math.select(r, (half)1f, r == (half)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _half16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 24; i++)
            {
                half16 l = math.ashalf(rng.NextShort16());
                half16 r = math.abs(math.ashalf(rng.NextShort16()));

                l = math.select(l, (half)1f, math.isnan(l));
                r = math.select(r, (half)1f, math.isnan(r));
                r = math.select(r, (half)1f, r == (half)0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }


        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float l = rng.NextFloat();
                float r = math.abs(rng.NextFloat());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float2 l = rng.NextFloat2();
                float2 r = math.abs(rng.NextFloat2());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float3 l = rng.NextFloat3();
                float3 r = math.abs(rng.NextFloat3());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float4 l = rng.NextFloat4();
                float4 r = math.abs(rng.NextFloat4());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float8 l = rng.NextFloat8();
                float8 r = math.abs(rng.NextFloat8());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double l = rng.NextDouble();
                double r = math.abs(rng.NextDouble());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double2 l = rng.NextDouble2();
                double2 r = math.abs(rng.NextDouble2());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double3 l = rng.NextDouble3();
                double3 r = math.abs(rng.NextDouble3());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 24; i++)
            {
                double4 l = rng.NextDouble4();
                double4 r = math.abs(rng.NextDouble4());

                r = math.select(r, 1f, r == 0f);

                Assert.AreEqual(math.copysign(l, r), math.copysign(l, r, Promise.NonZero));
            }
        }
    }
}
