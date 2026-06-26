using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_ceil
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(math.isnan(math.ceil(quarter.NaN)));
            Assert.AreEqual(quarter.NegativeInfinity, math.ceil(quarter.NegativeInfinity));
            Assert.AreEqual(quarter.PositiveInfinity, math.ceil(quarter.PositiveInfinity));

            quarter q = quarter.MinValue;

            while (q != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float)q), (float)math.ceil(q));

                if (q < 0f && q > -1f)
                {
                    Assert.IsTrue(math.ceil(q).value >= 0b1000_0000);
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.ceil(q), quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((quarter2)quarter.NaN))));
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, math.ceil((quarter2)quarter.NegativeInfinity));
            Assert.AreEqual((quarter2)quarter.PositiveInfinity, math.ceil((quarter2)quarter.PositiveInfinity));

            quarter2 q = quarter.MinValue;

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float2)q), (float2)math.ceil(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.ceil(q)) >= 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.ceil(q), (quarter2)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((quarter3)quarter.NaN))));
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, math.ceil((quarter3)quarter.NegativeInfinity));
            Assert.AreEqual((quarter3)quarter.PositiveInfinity, math.ceil((quarter3)quarter.PositiveInfinity));

            quarter3 q = quarter.MinValue;

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float3)q), (float3)math.ceil(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.ceil(q)) >= 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.ceil(q), (quarter3)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((quarter4)quarter.NaN))));
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, math.ceil((quarter4)quarter.NegativeInfinity));
            Assert.AreEqual((quarter4)quarter.PositiveInfinity, math.ceil((quarter4)quarter.PositiveInfinity));

            quarter4 q = quarter.MinValue;

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float4)q), (float4)math.ceil(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.ceil(q)) >= 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.ceil(q), (quarter4)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((quarter8)quarter.NaN))));
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, math.ceil((quarter8)quarter.NegativeInfinity));
            Assert.AreEqual((quarter8)quarter.PositiveInfinity, math.ceil((quarter8)quarter.PositiveInfinity));

            quarter8 q = quarter.MinValue;

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float8)q), (float8)math.ceil(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.ceil(q)) >= 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.ceil(q), (quarter8)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter16()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((quarter16)quarter.NaN))));
            Assert.AreEqual((quarter16)quarter.NegativeInfinity, math.ceil((quarter16)quarter.NegativeInfinity));
            Assert.AreEqual((quarter16)quarter.PositiveInfinity, math.ceil((quarter16)quarter.PositiveInfinity));

            quarter16 q = quarter.MinValue;

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float8)q.v8_0), (float8)math.ceil(q).v8_0);
                Assert.AreEqual(math.ceil((float8)q.v8_8), (float8)math.ceil(q).v8_8);

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.ceil(q)) >= 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.ceil(q), (quarter16)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter32()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((quarter32)quarter.NaN))));
            Assert.AreEqual((quarter32)quarter.NegativeInfinity, math.ceil((quarter32)quarter.NegativeInfinity));
            Assert.AreEqual((quarter32)quarter.PositiveInfinity, math.ceil((quarter32)quarter.PositiveInfinity));

            quarter32 q = quarter.MinValue;

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float8)q.v8_0),  (float8)math.ceil(q).v8_0);
                Assert.AreEqual(math.ceil((float8)q.v8_8),  (float8)math.ceil(q).v8_8);
                Assert.AreEqual(math.ceil((float8)q.v8_16), (float8)math.ceil(q).v8_16);
                Assert.AreEqual(math.ceil((float8)q.v8_24), (float8)math.ceil(q).v8_24);

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.ceil(q)) >= 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.ceil(q), (quarter32)quarter.PositiveInfinity);
        }


        [Test]
        public static void _half()
        {
            Assert.IsTrue(math.isnan(math.ceil((half)float.NaN)));
            Assert.AreEqual((half)float.NegativeInfinity, math.ceil((half)float.NegativeInfinity));
            Assert.AreEqual((half)float.PositiveInfinity, math.ceil((half)float.PositiveInfinity));

            half q = half.MinValue;
            Assert.AreEqual(math.ceil((float)half.MaxValue), (float)math.ceil(half.MaxValue));

            while (q != half.MaxValue)
            {
                Assert.AreEqual(math.ceil((float)q), (float)math.ceil(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.ceil(q).value, 0x8000);
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((half2)float.NaN))));
            Assert.AreEqual((half2)float.NegativeInfinity, math.ceil((half2)float.NegativeInfinity));
            Assert.AreEqual((half2)float.PositiveInfinity, math.ceil((half2)float.PositiveInfinity));

            half2 q = half.MinValue;
            Assert.AreEqual(math.ceil((float2)half.MaxValue), (float2)math.ceil((half2)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.ceil((float2)q), (float2)math.ceil(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.ceil(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((half3)float.NaN))));
            Assert.AreEqual((half3)float.NegativeInfinity, math.ceil((half3)float.NegativeInfinity));
            Assert.AreEqual((half3)float.PositiveInfinity, math.ceil((half3)float.PositiveInfinity));

            half3 q = half.MinValue;
            Assert.AreEqual(math.ceil((float3)half.MaxValue), (float3)math.ceil((half3)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.ceil((float3)q), (float3)math.ceil(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.ceil(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((half4)float.NaN))));
            Assert.AreEqual((half4)float.NegativeInfinity, math.ceil((half4)float.NegativeInfinity));
            Assert.AreEqual((half4)float.PositiveInfinity, math.ceil((half4)float.PositiveInfinity));

            half4 q = half.MinValue;
            Assert.AreEqual(math.ceil((float4)half.MaxValue), (float4)math.ceil((half4)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.ceil((float4)q), (float4)math.ceil(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.ceil(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half8()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((half8)float.NaN))));
            Assert.AreEqual((half8)float.NegativeInfinity, math.ceil((half8)float.NegativeInfinity));
            Assert.AreEqual((half8)float.PositiveInfinity, math.ceil((half8)float.PositiveInfinity));

            half8 q = half.MinValue;
            Assert.AreEqual(math.ceil((float8)half.MaxValue), (float8)math.ceil((half8)half.MaxValue));

            while (q.x0 != half.MaxValue)
            {
                Assert.AreEqual(math.ceil((float8)q), (float8)math.ceil(q));

                if (math.all((float8)q < 0f) && math.all((float8)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.ceil(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half16()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((half16)float.NaN))));
            Assert.AreEqual((half16)float.NegativeInfinity, math.ceil((half16)float.NegativeInfinity));
            Assert.AreEqual((half16)float.PositiveInfinity, math.ceil((half16)float.PositiveInfinity));

            half16 q = half.MinValue;
            Assert.AreEqual(math.ceil((float8)(((half16)half.MaxValue)).v8_0), (float8)math.ceil(((half16)half.MaxValue)).v8_0);
            Assert.AreEqual(math.ceil((float8)(((half16)half.MaxValue)).v8_8), (float8)math.ceil(((half16)half.MaxValue)).v8_8);

            while (q.x0 != half.MaxValue)
            {
                Assert.AreEqual(math.ceil((float8)q.v8_0), (float8)math.ceil(q).v8_0);
                Assert.AreEqual(math.ceil((float8)q.v8_8), (float8)math.ceil(q).v8_8);

                if ((float)q.x0 < 0f && (float)q.x0 > -1f)
                {
                    Assert.IsTrue(math.all(math.asushort(math.ceil(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }


        [Test]
        public static void _float()
        {
            Assert.IsTrue(math.isnan(math.ceil((float)float.NaN)));
            Assert.AreEqual((float)float.NegativeInfinity, math.ceil((float)float.NegativeInfinity));
            Assert.AreEqual((float)float.PositiveInfinity, math.ceil((float)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((float)float.MaxValue), (float)math.ceil(float.MaxValue));

            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float q = rng.NextFloat(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.ceil((float)q), (float)math.ceil(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.asuint(math.ceil(q)), 0x8000_0000u);
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((float2)float.NaN))));
            Assert.AreEqual((float2)float.NegativeInfinity, math.ceil((float2)float.NegativeInfinity));
            Assert.AreEqual((float2)float.PositiveInfinity, math.ceil((float2)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((float2)float.MaxValue), (float2)math.ceil((float2)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float2 q = rng.NextFloat2(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.ceil((float2)q), (float2)math.ceil(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.ceil(q)) == 0x8000_0000u));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((float3)float.NaN))));
            Assert.AreEqual((float3)float.NegativeInfinity, math.ceil((float3)float.NegativeInfinity));
            Assert.AreEqual((float3)float.PositiveInfinity, math.ceil((float3)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((float3)float.MaxValue), (float3)math.ceil((float3)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float3 q = rng.NextFloat3(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.ceil((float3)q), (float3)math.ceil(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.ceil(q)) == 0x8000_0000u));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((float4)float.NaN))));
            Assert.AreEqual((float4)float.NegativeInfinity, math.ceil((float4)float.NegativeInfinity));
            Assert.AreEqual((float4)float.PositiveInfinity, math.ceil((float4)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((float4)float.MaxValue), (float4)math.ceil((float4)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float4 q = rng.NextFloat4(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.ceil((float4)q), (float4)math.ceil(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.ceil(q)) == 0x8000_0000u));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((float8)float.NaN))));
            Assert.AreEqual((float8)float.NegativeInfinity, math.ceil((float8)float.NegativeInfinity));
            Assert.AreEqual((float8)float.PositiveInfinity, math.ceil((float8)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil(((float8)float.MaxValue).v4_0), math.ceil((float8)float.MaxValue).v4_0);
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float8 q = rng.NextFloat8(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.ceil(q.v4_0), ((float8)math.ceil(q)).v4_0);
                Assert.AreEqual(Unity.Mathematics.math.ceil(q.v4_4), ((float8)math.ceil(q)).v4_4);

                if (math.all((float8)q < 0f) && math.all((float8)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.ceil(q)) == 0x8000_0000u));
                }
            }
        }


        [Test]
        public static void _double()
        {
            Assert.IsTrue(math.isnan(math.ceil((double)double.NaN)));
            Assert.AreEqual((double)double.NegativeInfinity, math.ceil((double)double.NegativeInfinity));
            Assert.AreEqual((double)double.PositiveInfinity, math.ceil((double)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((double)double.MaxValue), (double)math.ceil(double.MaxValue));

            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double q = rng.NextDouble(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.ceil((double)q), (double)math.ceil(q));

                if (q < 0d && q > -1d)
                {
                    Assert.AreEqual(math.asulong(math.ceil(q)), 0x8000_0000_0000_0000ul);
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((double2)double.NaN))));
            Assert.AreEqual((double2)double.NegativeInfinity, math.ceil((double2)double.NegativeInfinity));
            Assert.AreEqual((double2)double.PositiveInfinity, math.ceil((double2)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((double2)double.MaxValue), (double2)math.ceil((double2)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double2 q = rng.NextDouble2(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.ceil((double2)q), (double2)math.ceil(q));

                if (math.all((double2)q < 0d) && math.all((double2)q > -1d))
                {
                    Assert.IsTrue(math.all(math.asulong(math.ceil(q)) == 0x8000_0000_0000_0000ul));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((double3)double.NaN))));
            Assert.AreEqual((double3)double.NegativeInfinity, math.ceil((double3)double.NegativeInfinity));
            Assert.AreEqual((double3)double.PositiveInfinity, math.ceil((double3)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((double3)double.MaxValue), (double3)math.ceil((double3)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double3 q = rng.NextDouble3(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.ceil((double3)q), (double3)math.ceil(q));

                if (math.all((double3)q < 0d) && math.all((double3)q > -1d))
                {
                    Assert.IsTrue(math.all(math.asulong(math.ceil(q)) == 0x8000_0000_0000_0000ul));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Assert.IsTrue(math.all(math.isnan(math.ceil((double4)double.NaN))));
            Assert.AreEqual((double4)double.NegativeInfinity, math.ceil((double4)double.NegativeInfinity));
            Assert.AreEqual((double4)double.PositiveInfinity, math.ceil((double4)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.ceil((double4)double.MaxValue), (double4)math.ceil((double4)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double4 q = rng.NextDouble4(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.ceil((double4)q), (double4)math.ceil(q));

                if (math.all((double4)q < 0d) && math.all((double4)q > -1d))
                {
                    Assert.IsTrue(math.all(math.asulong(math.ceil(q)) == 0x8000_0000_0000_0000ul));
                }
            }
        }
    }
}
