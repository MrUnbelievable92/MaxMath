using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_trunc
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(math.isnan(math.trunc(quarter.NaN)));
            Assert.AreEqual(quarter.NegativeInfinity, math.trunc(quarter.NegativeInfinity));
            Assert.AreEqual(quarter.PositiveInfinity, math.trunc(quarter.PositiveInfinity));

            quarter q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float)quarter.MaxValue), (float)math.trunc(quarter.MaxValue));

            while (q != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float)q), (float)math.trunc(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.trunc(q).value, 0b1000_0000);
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((quarter2)quarter.NaN))));
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, math.trunc((quarter2)quarter.NegativeInfinity));
            Assert.AreEqual((quarter2)quarter.PositiveInfinity, math.trunc((quarter2)quarter.PositiveInfinity));

            quarter2 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float2)quarter.MaxValue), (float2)math.trunc((quarter2)quarter.MaxValue));

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float2)q), (float2)math.trunc(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.trunc(q)) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.asquarter(rng.NextByte2());
                quarter2 trunced = math.trunc(q);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((quarter3)quarter.NaN))));
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, math.trunc((quarter3)quarter.NegativeInfinity));
            Assert.AreEqual((quarter3)quarter.PositiveInfinity, math.trunc((quarter3)quarter.PositiveInfinity));

            quarter3 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float3)quarter.MaxValue), (float3)math.trunc((quarter3)quarter.MaxValue));

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float3)q), (float3)math.trunc(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.trunc(q)) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.asquarter(rng.NextByte3());
                quarter3 trunced = math.trunc(q);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((quarter4)quarter.NaN))));
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, math.trunc((quarter4)quarter.NegativeInfinity));
            Assert.AreEqual((quarter4)quarter.PositiveInfinity, math.trunc((quarter4)quarter.PositiveInfinity));

            quarter4 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float4)quarter.MaxValue), (float4)math.trunc((quarter4)quarter.MaxValue));

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float4)q), (float4)math.trunc(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.trunc(q)) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.asquarter(rng.NextByte4());
                quarter4 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((quarter8)quarter.NaN))));
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, math.trunc((quarter8)quarter.NegativeInfinity));
            Assert.AreEqual((quarter8)quarter.PositiveInfinity, math.trunc((quarter8)quarter.PositiveInfinity));

            quarter8 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float8)quarter.MaxValue), (float8)math.trunc((quarter8)quarter.MaxValue));

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float8)q), (float8)math.trunc(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.trunc(q)) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.asquarter(rng.NextByte8());
                quarter8 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter16()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((quarter16)quarter.NaN))));
            Assert.AreEqual((quarter16)quarter.NegativeInfinity, math.trunc((quarter16)quarter.NegativeInfinity));
            Assert.AreEqual((quarter16)quarter.PositiveInfinity, math.trunc((quarter16)quarter.PositiveInfinity));

            quarter16 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float8)(((quarter16)quarter.MaxValue)).v8_0), (float8)math.trunc(((quarter16)quarter.MaxValue)).v8_0);
            Assert.AreEqual(math.trunc((float8)(((quarter16)quarter.MaxValue)).v8_8), (float8)math.trunc(((quarter16)quarter.MaxValue)).v8_8);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float8)q.v8_0), (float8)math.trunc(q).v8_0);
                Assert.AreEqual(math.trunc((float8)q.v8_8), (float8)math.trunc(q).v8_8);

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.trunc(q)) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.asquarter(rng.NextByte16());
                quarter16 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter32()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((quarter32)quarter.NaN))));
            Assert.AreEqual((quarter32)quarter.NegativeInfinity, math.trunc((quarter32)quarter.NegativeInfinity));
            Assert.AreEqual((quarter32)quarter.PositiveInfinity, math.trunc((quarter32)quarter.PositiveInfinity));

            quarter32 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float8)(((quarter32)quarter.MaxValue)).v8_0),  (float8)math.trunc(((quarter32)quarter.MaxValue)).v8_0);
            Assert.AreEqual(math.trunc((float8)(((quarter32)quarter.MaxValue)).v8_8),  (float8)math.trunc(((quarter32)quarter.MaxValue)).v8_8);
            Assert.AreEqual(math.trunc((float8)(((quarter32)quarter.MaxValue)).v8_16), (float8)math.trunc(((quarter32)quarter.MaxValue)).v8_16);
            Assert.AreEqual(math.trunc((float8)(((quarter32)quarter.MaxValue)).v8_24), (float8)math.trunc(((quarter32)quarter.MaxValue)).v8_24);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float8)q.v8_0),  (float8)math.trunc(q).v8_0);
                Assert.AreEqual(math.trunc((float8)q.v8_8),  (float8)math.trunc(q).v8_8);
                Assert.AreEqual(math.trunc((float8)q.v8_16), (float8)math.trunc(q).v8_16);
                Assert.AreEqual(math.trunc((float8)q.v8_24), (float8)math.trunc(q).v8_24);

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(math.asbyte(math.trunc(q)) == 0b1000_0000));
                }

                q = math.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.asquarter(rng.NextByte32());
                quarter32 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }


        [Test]
        public static void _half()
        {
            Assert.IsTrue(math.isnan(math.trunc((half)float.NaN)));
            Assert.AreEqual((half)float.NegativeInfinity, math.trunc((half)float.NegativeInfinity));
            Assert.AreEqual((half)float.PositiveInfinity, math.trunc((half)float.PositiveInfinity));

            half q = half.MinValue;
            Assert.AreEqual(math.trunc((float)half.MaxValue), (float)math.trunc(half.MaxValue));

            while (q != half.MaxValue)
            {
                Assert.AreEqual(math.trunc((float)q), (float)math.trunc(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.trunc(q).value, 0x8000);
                }

                q = math.nextgreater(q);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((half2)float.NaN))));
            Assert.AreEqual((half2)float.NegativeInfinity, math.trunc((half2)float.NegativeInfinity));
            Assert.AreEqual((half2)float.PositiveInfinity, math.trunc((half2)float.PositiveInfinity));

            half2 q = half.MinValue;
            Assert.AreEqual(math.trunc((float2)half.MaxValue), (float2)math.trunc((half2)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.trunc((float2)q), (float2)math.trunc(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.trunc(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.ashalf(rng.NextUShort2());
                half2 trunced = math.trunc(q);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((half3)float.NaN))));
            Assert.AreEqual((half3)float.NegativeInfinity, math.trunc((half3)float.NegativeInfinity));
            Assert.AreEqual((half3)float.PositiveInfinity, math.trunc((half3)float.PositiveInfinity));

            half3 q = half.MinValue;
            Assert.AreEqual(math.trunc((float3)half.MaxValue), (float3)math.trunc((half3)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.trunc((float3)q), (float3)math.trunc(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.trunc(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.ashalf(rng.NextUShort3());
                half3 trunced = math.trunc(q);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((half4)float.NaN))));
            Assert.AreEqual((half4)float.NegativeInfinity, math.trunc((half4)float.NegativeInfinity));
            Assert.AreEqual((half4)float.PositiveInfinity, math.trunc((half4)float.PositiveInfinity));

            half4 q = half.MinValue;
            Assert.AreEqual(math.trunc((float4)half.MaxValue), (float4)math.trunc((half4)half.MaxValue));

            while (q.x != half.MaxValue)
            {
                Assert.AreEqual(math.trunc((float4)q), (float4)math.trunc(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.trunc(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.ashalf(rng.NextUShort4());
                half4 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((half8)float.NaN))));
            Assert.AreEqual((half8)float.NegativeInfinity, math.trunc((half8)float.NegativeInfinity));
            Assert.AreEqual((half8)float.PositiveInfinity, math.trunc((half8)float.PositiveInfinity));

            half8 q = half.MinValue;
            Assert.AreEqual(math.trunc((float8)half.MaxValue), (float8)math.trunc((half8)half.MaxValue));

            while (q.x0 != half.MaxValue)
            {
                Assert.AreEqual(math.trunc((float8)q), (float8)math.trunc(q));

                if (math.all((float8)q < 0f) && math.all((float8)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asushort(math.trunc(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.ashalf(rng.NextUShort8());
                half8 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _half16()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((half16)float.NaN))));
            Assert.AreEqual((half16)float.NegativeInfinity, math.trunc((half16)float.NegativeInfinity));
            Assert.AreEqual((half16)float.PositiveInfinity, math.trunc((half16)float.PositiveInfinity));

            half16 q = half.MinValue;
            Assert.AreEqual(math.trunc((float8)(((half16)half.MaxValue)).v8_0), (float8)math.trunc(((half16)half.MaxValue)).v8_0);
            Assert.AreEqual(math.trunc((float8)(((half16)half.MaxValue)).v8_8), (float8)math.trunc(((half16)half.MaxValue)).v8_8);

            while (q.x0 != half.MaxValue)
            {
                Assert.AreEqual(math.trunc((float8)q.v8_0), (float8)math.trunc(q).v8_0);
                Assert.AreEqual(math.trunc((float8)q.v8_8), (float8)math.trunc(q).v8_8);

                if ((float)q.x0 < 0f && (float)q.x0 > -1f)
                {
                    Assert.IsTrue(math.all(math.asushort(math.trunc(q)) == 0x8000));
                }

                q = math.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = math.ashalf(rng.NextUShort16());
                half16 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], math.trunc((float)q[j]));
                    }
                }
            }
        }


        [Test]
        public static void _float()
        {
            Assert.IsTrue(math.isnan(math.trunc((float)float.NaN)));
            Assert.AreEqual((float)float.NegativeInfinity, math.trunc((float)float.NegativeInfinity));
            Assert.AreEqual((float)float.PositiveInfinity, math.trunc((float)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((float)float.MaxValue), (float)math.trunc(float.MaxValue));

            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float q = rng.NextFloat(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.trunc((float)q), (float)math.trunc(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.asuint(math.trunc(q)), 0x8000_0000u);
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((float2)float.NaN))));
            Assert.AreEqual((float2)float.NegativeInfinity, math.trunc((float2)float.NegativeInfinity));
            Assert.AreEqual((float2)float.PositiveInfinity, math.trunc((float2)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((float2)float.MaxValue), (float2)math.trunc((float2)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float2 q = rng.NextFloat2(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.trunc((float2)q), (float2)math.trunc(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.trunc(q)) == 0x8000_0000u));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                float2 q = math.asfloat(rng.NextUInt2());
                float2 trunced = math.trunc(q);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], Unity.Mathematics.math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((float3)float.NaN))));
            Assert.AreEqual((float3)float.NegativeInfinity, math.trunc((float3)float.NegativeInfinity));
            Assert.AreEqual((float3)float.PositiveInfinity, math.trunc((float3)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((float3)float.MaxValue), (float3)math.trunc((float3)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float3 q = rng.NextFloat3(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.trunc((float3)q), (float3)math.trunc(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.trunc(q)) == 0x8000_0000u));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                float3 q = math.asfloat(rng.NextUInt3());
                float3 trunced = math.trunc(q);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], Unity.Mathematics.math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((float4)float.NaN))));
            Assert.AreEqual((float4)float.NegativeInfinity, math.trunc((float4)float.NegativeInfinity));
            Assert.AreEqual((float4)float.PositiveInfinity, math.trunc((float4)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((float4)float.MaxValue), (float4)math.trunc((float4)float.MaxValue));
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float4 q = rng.NextFloat4(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.trunc((float4)q), (float4)math.trunc(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.trunc(q)) == 0x8000_0000u));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                float4 q = math.asfloat(rng.NextUInt4());
                float4 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], Unity.Mathematics.math.trunc((float)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((float8)float.NaN))));
            Assert.AreEqual((float8)float.NegativeInfinity, math.trunc((float8)float.NegativeInfinity));
            Assert.AreEqual((float8)float.PositiveInfinity, math.trunc((float8)float.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc(((float8)float.MaxValue).v4_0), math.trunc((float8)float.MaxValue).v4_0);
            
            Random32 rng = Random32.New;
            for (int i = 0; i < 256; i++)
            {
                float8 q = rng.NextFloat8(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.trunc(q.v4_0), math.trunc(q).v4_0);
                Assert.AreEqual(Unity.Mathematics.math.trunc(q.v4_4), math.trunc(q).v4_4);

                if (math.all((float8)q < 0f) && math.all((float8)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asuint(math.trunc(q)) == 0x8000_0000u));
                }
            }

            for (int i = 0; i < 32; i++)
            {
                float8 q = math.asfloat(rng.NextUInt8());
                float8 trunced = math.trunc(q);

                for (int j = 0; j < 8; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((float)trunced[j], Unity.Mathematics.math.trunc((float)q[j]));
                    }
                }
            }
        }


        [Test]
        public static void _double()
        {
            Assert.IsTrue(math.isnan(math.trunc((double)double.NaN)));
            Assert.AreEqual((double)double.NegativeInfinity, math.trunc((double)double.NegativeInfinity));
            Assert.AreEqual((double)double.PositiveInfinity, math.trunc((double)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((double)double.MaxValue), (double)math.trunc(double.MaxValue));

            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double q = rng.NextDouble(-100_000, 100_000);

                Assert.AreEqual(Unity.Mathematics.math.trunc((double)q), (double)math.trunc(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(math.asulong(math.trunc(q)), 0x8000_0000_0000_0000ul);
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((double2)double.NaN))));
            Assert.AreEqual((double2)double.NegativeInfinity, math.trunc((double2)double.NegativeInfinity));
            Assert.AreEqual((double2)double.PositiveInfinity, math.trunc((double2)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((double2)double.MaxValue), (double2)math.trunc((double2)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double2 q = rng.NextDouble2(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.trunc((double2)q), (double2)math.trunc(q));

                if (math.all((double2)q < 0f) && math.all((double2)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asulong(math.trunc(q)) == 0x8000_0000_0000_0000ul));
                }
            }

            for (int i = 0; i < 64; i++)
            {
                double2 q = math.asdouble(rng.NextULong2());
                double2 trunced = math.trunc(q);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((double)trunced[j], Unity.Mathematics.math.trunc((double)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((double3)double.NaN))));
            Assert.AreEqual((double3)double.NegativeInfinity, math.trunc((double3)double.NegativeInfinity));
            Assert.AreEqual((double3)double.PositiveInfinity, math.trunc((double3)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((double3)double.MaxValue), (double3)math.trunc((double3)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double3 q = rng.NextDouble3(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.trunc((double3)q), (double3)math.trunc(q));

                if (math.all((double3)q < 0f) && math.all((double3)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asulong(math.trunc(q)) == 0x8000_0000_0000_0000ul));
                }
            }

            for (int i = 0; i < 64; i++)
            {
                double3 q = math.asdouble(rng.NextULong3());
                double3 trunced = math.trunc(q);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((double)trunced[j], Unity.Mathematics.math.trunc((double)q[j]));
                    }
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Assert.IsTrue(math.all(math.isnan(math.trunc((double4)double.NaN))));
            Assert.AreEqual((double4)double.NegativeInfinity, math.trunc((double4)double.NegativeInfinity));
            Assert.AreEqual((double4)double.PositiveInfinity, math.trunc((double4)double.PositiveInfinity));

            Assert.AreEqual(Unity.Mathematics.math.trunc((double4)double.MaxValue), (double4)math.trunc((double4)double.MaxValue));
            
            Random64 rng = Random64.New;
            for (int i = 0; i < 256; i++)
            {
                double4 q = rng.NextDouble4(-100_000, 100_000);
                Assert.AreEqual(Unity.Mathematics.math.trunc((double4)q), (double4)math.trunc(q));

                if (math.all((double4)q < 0f) && math.all((double4)q > -1f))
                {
                    Assert.IsTrue(math.all(math.asulong(math.trunc(q)) == 0x8000_0000_0000_0000ul));
                }
            }

            for (int i = 0; i < 64; i++)
            {
                double4 q = math.asdouble(rng.NextULong4());
                double4 trunced = math.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
                    {
                        Assert.IsNaN(trunced[j]);
                    }
                    else
                    {
                        Assert.AreEqual((double)trunced[j], Unity.Mathematics.math.trunc((double)q[j]));
                    }
                }
            }
        }
    }
}
