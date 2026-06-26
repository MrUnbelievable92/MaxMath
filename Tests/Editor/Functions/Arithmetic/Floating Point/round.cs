using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_round
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(math.isnan(math.round(quarter.NaN)));
            Assert.AreEqual(quarter.NegativeInfinity, math.round(quarter.NegativeInfinity));
            Assert.AreEqual(quarter.PositiveInfinity, math.round(quarter.PositiveInfinity));

            quarter q = quarter.MinValue;
            Assert.AreEqual(math.round(q), quarter.NegativeInfinity);
            q = math.nextgreater(q);

            while (q != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float)q), (float)math.round(q));

                if (q < 0f && q > -1f)
                {
                    Assert.IsTrue((math.round(q).value & 0b1000_0000) == 0b1000_0000);
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.round(q), quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((quarter2)quarter.NaN))));
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, math.round((quarter2)quarter.NegativeInfinity));
            Assert.AreEqual((quarter2)quarter.PositiveInfinity, math.round((quarter2)quarter.PositiveInfinity));

            quarter2 q = quarter.MinValue;
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, math.round(q));
            q = math.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float2)q), (float2)math.round(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((math.asbyte(math.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.round(q), (quarter2)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((quarter3)quarter.NaN))));
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, math.round((quarter3)quarter.NegativeInfinity));
            Assert.AreEqual((quarter3)quarter.PositiveInfinity, math.round((quarter3)quarter.PositiveInfinity));

            quarter3 q = quarter.MinValue;
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, math.round(q));
            q = math.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float3)q), (float3)math.round(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((math.asbyte(math.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.round(q), (quarter3)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((quarter4)quarter.NaN))));
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, math.round((quarter4)quarter.NegativeInfinity));
            Assert.AreEqual((quarter4)quarter.PositiveInfinity, math.round((quarter4)quarter.PositiveInfinity));

            quarter4 q = quarter.MinValue;
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, math.round(q));
            q = math.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float4)q), (float4)math.round(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((math.asbyte(math.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.round(q), (quarter4)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((quarter8)quarter.NaN))));
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, math.round((quarter8)quarter.NegativeInfinity));
            Assert.AreEqual((quarter8)quarter.PositiveInfinity, math.round((quarter8)quarter.PositiveInfinity));

            quarter8 q = quarter.MinValue;
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, math.round(q));
            q = math.nextgreater(q);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float8)q), (float8)math.round(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((math.asbyte(math.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.round(q), (quarter8)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter16()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((quarter16)quarter.NaN))));
            Assert.AreEqual((quarter16)quarter.NegativeInfinity, math.round((quarter16)quarter.NegativeInfinity));
            Assert.AreEqual((quarter16)quarter.PositiveInfinity, math.round((quarter16)quarter.PositiveInfinity));

            quarter16 q = quarter.MinValue;
            Assert.AreEqual((quarter16)quarter.NegativeInfinity, math.round(q));
            q = math.nextgreater(q);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float8)q.v8_0), (float8)math.round(q).v8_0);
                Assert.AreEqual(math.round((float8)q.v8_8), (float8)math.round(q).v8_8);

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((math.asbyte(math.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.round(q), (quarter16)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter32()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((quarter32)quarter.NaN))));
            Assert.AreEqual((quarter32)quarter.NegativeInfinity, math.round((quarter32)quarter.NegativeInfinity));
            Assert.AreEqual((quarter32)quarter.PositiveInfinity, math.round((quarter32)quarter.PositiveInfinity));

            quarter32 q = quarter.MinValue;
            Assert.AreEqual((quarter32)quarter.NegativeInfinity, math.round(q));
            q = math.nextgreater(q);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float8)q.v8_0),  (float8)math.round(q).v8_0);
                Assert.AreEqual(math.round((float8)q.v8_8),  (float8)math.round(q).v8_8);
                Assert.AreEqual(math.round((float8)q.v8_16), (float8)math.round(q).v8_16);
                Assert.AreEqual(math.round((float8)q.v8_24), (float8)math.round(q).v8_24);

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((math.asbyte(math.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Assert.AreEqual(math.round(q), (quarter32)quarter.PositiveInfinity);
        }


        [Test]
        public static void _half()
        {
            Assert.IsTrue(math.isnan(math.round((half)float.NaN)));
            Assert.AreEqual((half)float.NegativeInfinity, math.round((half)float.NegativeInfinity));
            Assert.AreEqual((half)float.PositiveInfinity, math.round((half)float.PositiveInfinity));

            half q = half.MinValue;
            Assert.AreEqual(math.round((float)half.MaxValue), (float)math.round(half.MaxValue));

            while (q != half.MaxValue)
            {
                Assert.AreEqual(math.round((float)q), (float)math.round(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.round(q).value & 0x8000, 0x8000);
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((half2)float.NaN))));
            Assert.AreEqual((half2)float.NegativeInfinity, math.round((half2)float.NegativeInfinity));
            Assert.AreEqual((half2)float.PositiveInfinity, math.round((half2)float.PositiveInfinity));

            half2 q = half.MinValue;
            Assert.AreEqual(math.round((float2)half.MaxValue), (float2)math.round((half2)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.round((float2)q), (float2)math.round(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asushort(math.round(q)) & 0x8000) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((half3)float.NaN))));
            Assert.AreEqual((half3)float.NegativeInfinity, math.round((half3)float.NegativeInfinity));
            Assert.AreEqual((half3)float.PositiveInfinity, math.round((half3)float.PositiveInfinity));

            half3 q = half.MinValue;
            Assert.AreEqual(math.round((float3)half.MaxValue), (float3)math.round((half3)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.round((float3)q), (float3)math.round(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asushort(math.round(q)) & 0x8000) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((half4)float.NaN))));
            Assert.AreEqual((half4)float.NegativeInfinity, math.round((half4)float.NegativeInfinity));
            Assert.AreEqual((half4)float.PositiveInfinity, math.round((half4)float.PositiveInfinity));

            half4 q = half.MinValue;
            Assert.AreEqual(math.round((float4)half.MaxValue), (float4)math.round((half4)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.round((float4)q), (float4)math.round(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asushort(math.round(q)) & 0x8000) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half8()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((half8)float.NaN))));
            Assert.AreEqual((half8)float.NegativeInfinity, math.round((half8)float.NegativeInfinity));
            Assert.AreEqual((half8)float.PositiveInfinity, math.round((half8)float.PositiveInfinity));

            half8 q = half.MinValue;
            Assert.AreEqual(math.round((float8)half.MaxValue), (float8)math.round((half8)half.MaxValue));

            while (q.x0 != half.MaxValue)
            {
                Assert.AreEqual(math.round((float8)q), (float8)math.round(q));

                if (math.all((float8)q < 0f) && math.all((float8)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asushort(math.round(q)) & 0x8000) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half16()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((half16)float.NaN))));
            Assert.AreEqual((half16)float.NegativeInfinity, math.round((half16)float.NegativeInfinity));
            Assert.AreEqual((half16)float.PositiveInfinity, math.round((half16)float.PositiveInfinity));

            half16 q = half.MinValue;
            Assert.AreEqual(math.round((float8)(((half16)half.MaxValue)).v8_0), (float8)math.round(((half16)half.MaxValue)).v8_0);
            Assert.AreEqual(math.round((float8)(((half16)half.MaxValue)).v8_8), (float8)math.round(((half16)half.MaxValue)).v8_8);

            while (q.x0 != half.MaxValue)
            {
                Assert.AreEqual(math.round((float8)q.v8_0), (float8)math.round(q).v8_0);
                Assert.AreEqual(math.round((float8)q.v8_8), (float8)math.round(q).v8_8);

                if ((float)q.x0 < 0f && (float)q.x0 > -1f)
                {
                    Assert.IsTrue(math.all((math.asushort(math.round(q)) & 0x8000) == 0x8000));
                }

                q = math.nextgreater(q);
            }
        }


        [Test]
        public static void _float()
        {
            Assert.IsTrue(math.isnan(math.round((float)float.NaN)));
            Assert.AreEqual((float)float.NegativeInfinity, math.round((float)float.NegativeInfinity));
            Assert.AreEqual((float)float.PositiveInfinity, math.round((float)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((float)float.MaxValue), (float)math.round(float.MaxValue));

            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float q = rng.NextFloat(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((float)q), (float)math.round(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.asuint(math.round(q)) & 0x8000_0000u, 0x8000_0000u);
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((float2)float.NaN))));
            Assert.AreEqual((float2)float.NegativeInfinity, math.round((float2)float.NegativeInfinity));
            Assert.AreEqual((float2)float.PositiveInfinity, math.round((float2)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((float2)float.MaxValue), (float2)math.round((float2)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float2 q = rng.NextFloat2(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((float2)q), (float2)math.round(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asuint(math.round(q)) & 0x8000_0000u) == 0x8000_0000u));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((float3)float.NaN))));
            Assert.AreEqual((float3)float.NegativeInfinity, math.round((float3)float.NegativeInfinity));
            Assert.AreEqual((float3)float.PositiveInfinity, math.round((float3)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((float3)float.MaxValue), (float3)math.round((float3)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float3 q = rng.NextFloat3(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((float3)q), (float3)math.round(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asuint(math.round(q)) & 0x8000_0000u) == 0x8000_0000u));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _float4()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((float4)float.NaN))));
            Assert.AreEqual((float4)float.NegativeInfinity, math.round((float4)float.NegativeInfinity));
            Assert.AreEqual((float4)float.PositiveInfinity, math.round((float4)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((float4)float.MaxValue), (float4)math.round((float4)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float4 q = rng.NextFloat4(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((float4)q), (float4)math.round(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asuint(math.round(q)) & 0x8000_0000u) == 0x8000_0000u));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _float8()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((float8)float.NaN))));
            Assert.AreEqual((float8)float.NegativeInfinity, math.round((float8)float.NegativeInfinity));
            Assert.AreEqual((float8)float.PositiveInfinity, math.round((float8)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round(((float8)float.MaxValue).v4_0), math.round((float8)float.MaxValue).v4_0);
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float8 q = rng.NextFloat8(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round(q.v4_0), math.round(q).v4_0);
                Assert.AreEqual(Unity.Mathematics.math.round(q.v4_4), math.round(q).v4_4);

                if (math.all((float8)q < 0f) && math.all((float8)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asuint(math.round(q)) & 0x8000_0000u) == 0x8000_0000u));
                }

                q = math.nextgreater(q);
            }
        }


        [Test]
        public static void _double()
        {
            Assert.IsTrue(math.isnan(math.round((double)double.NaN)));
            Assert.AreEqual((double)double.NegativeInfinity, math.round((double)double.NegativeInfinity));
            Assert.AreEqual((double)double.PositiveInfinity, math.round((double)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((double)double.MaxValue), (double)math.round(double.MaxValue));

            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double q = rng.NextDouble(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((double)q), (double)math.round(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.asulong(math.round(q)) & 0x8000_0000_0000_0000ul, 0x8000_0000_0000_0000ul);
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((double2)double.NaN))));
            Assert.AreEqual((double2)double.NegativeInfinity, math.round((double2)double.NegativeInfinity));
            Assert.AreEqual((double2)double.PositiveInfinity, math.round((double2)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((double2)double.MaxValue), (double2)math.round((double2)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double2 q = rng.NextDouble2(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((double2)q), (double2)math.round(q));

                if (math.all((double2)q < 0f) && math.all((double2)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asulong(math.round(q)) & 0x8000_0000_0000_0000ul) == 0x8000_0000_0000_0000ul));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((double3)double.NaN))));
            Assert.AreEqual((double3)double.NegativeInfinity, math.round((double3)double.NegativeInfinity));
            Assert.AreEqual((double3)double.PositiveInfinity, math.round((double3)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((double3)double.MaxValue), (double3)math.round((double3)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double3 q = rng.NextDouble3(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((double3)q), (double3)math.round(q));

                if (math.all((double3)q < 0f) && math.all((double3)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asulong(math.round(q)) & 0x8000_0000_0000_0000ul) == 0x8000_0000_0000_0000ul));
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _double4()
        {
            Assert.IsTrue(math.all(math.isnan(math.round((double4)double.NaN))));
            Assert.AreEqual((double4)double.NegativeInfinity, math.round((double4)double.NegativeInfinity));
            Assert.AreEqual((double4)double.PositiveInfinity, math.round((double4)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.round((double4)double.MaxValue), (double4)math.round((double4)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double4 q = rng.NextDouble4(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.round((double4)q), (double4)math.round(q));

                if (math.all((double4)q < 0f) && math.all((double4)q > -1f))
                {
                    Assert.IsTrue(math.all((math.asulong(math.round(q)) & 0x8000_0000_0000_0000ul) == 0x8000_0000_0000_0000ul));
                }

                q = math.nextgreater(q);
            }
        }
    }
}
