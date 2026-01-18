using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_trunc
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(maxmath.isnan(maxmath.trunc(quarter.NaN)));
            Assert.AreEqual(quarter.NegativeInfinity, maxmath.trunc(quarter.NegativeInfinity));
            Assert.AreEqual(quarter.PositiveInfinity, maxmath.trunc(quarter.PositiveInfinity));

            quarter q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float)quarter.MaxValue), (float)maxmath.trunc(quarter.MaxValue));

            while (q != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float)q), (float)maxmath.trunc(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(maxmath.trunc(q).value, 0b1000_0000);
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.trunc((quarter2)quarter.NaN))));
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, maxmath.trunc((quarter2)quarter.NegativeInfinity));
            Assert.AreEqual((quarter2)quarter.PositiveInfinity, maxmath.trunc((quarter2)quarter.PositiveInfinity));

            quarter2 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float2)quarter.MaxValue), (float2)maxmath.trunc((quarter2)quarter.MaxValue));

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float2)q), (float2)maxmath.trunc(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asbyte(maxmath.trunc(q)) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.asquarter(rng.NextByte2());
                quarter2 trunced = maxmath.trunc(q);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.trunc((quarter3)quarter.NaN))));
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, maxmath.trunc((quarter3)quarter.NegativeInfinity));
            Assert.AreEqual((quarter3)quarter.PositiveInfinity, maxmath.trunc((quarter3)quarter.PositiveInfinity));

            quarter3 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float3)quarter.MaxValue), (float3)maxmath.trunc((quarter3)quarter.MaxValue));

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float3)q), (float3)maxmath.trunc(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asbyte(maxmath.trunc(q)) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.asquarter(rng.NextByte3());
                quarter3 trunced = maxmath.trunc(q);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.trunc((quarter4)quarter.NaN))));
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, maxmath.trunc((quarter4)quarter.NegativeInfinity));
            Assert.AreEqual((quarter4)quarter.PositiveInfinity, maxmath.trunc((quarter4)quarter.PositiveInfinity));

            quarter4 q = quarter.MinValue;
            Assert.AreEqual(math.trunc((float4)quarter.MaxValue), (float4)maxmath.trunc((quarter4)quarter.MaxValue));

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.trunc((float4)q), (float4)maxmath.trunc(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asbyte(maxmath.trunc(q)) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.asquarter(rng.NextByte4());
                quarter4 trunced = maxmath.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.trunc((quarter8)quarter.NaN))));
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, maxmath.trunc((quarter8)quarter.NegativeInfinity));
            Assert.AreEqual((quarter8)quarter.PositiveInfinity, maxmath.trunc((quarter8)quarter.PositiveInfinity));

            quarter8 q = quarter.MinValue;
            Assert.AreEqual(maxmath.trunc((float8)quarter.MaxValue), (float8)maxmath.trunc((quarter8)quarter.MaxValue));

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.trunc((float8)q), (float8)maxmath.trunc(q));

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asbyte(maxmath.trunc(q)) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.asquarter(rng.NextByte8());
                quarter8 trunced = maxmath.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.trunc((quarter16)quarter.NaN))));
            Assert.AreEqual((quarter16)quarter.NegativeInfinity, maxmath.trunc((quarter16)quarter.NegativeInfinity));
            Assert.AreEqual((quarter16)quarter.PositiveInfinity, maxmath.trunc((quarter16)quarter.PositiveInfinity));

            quarter16 q = quarter.MinValue;
            Assert.AreEqual(maxmath.trunc((float8)(((quarter16)quarter.MaxValue)).v8_0), (float8)maxmath.trunc(((quarter16)quarter.MaxValue)).v8_0);
            Assert.AreEqual(maxmath.trunc((float8)(((quarter16)quarter.MaxValue)).v8_8), (float8)maxmath.trunc(((quarter16)quarter.MaxValue)).v8_8);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.trunc((float8)q.v8_0), (float8)maxmath.trunc(q).v8_0);
                Assert.AreEqual(maxmath.trunc((float8)q.v8_8), (float8)maxmath.trunc(q).v8_8);

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asbyte(maxmath.trunc(q)) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.asquarter(rng.NextByte16());
                quarter16 trunced = maxmath.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.trunc((quarter32)quarter.NaN))));
            Assert.AreEqual((quarter32)quarter.NegativeInfinity, maxmath.trunc((quarter32)quarter.NegativeInfinity));
            Assert.AreEqual((quarter32)quarter.PositiveInfinity, maxmath.trunc((quarter32)quarter.PositiveInfinity));

            quarter32 q = quarter.MinValue;
            Assert.AreEqual(maxmath.trunc((float8)(((quarter32)quarter.MaxValue)).v8_0),  (float8)maxmath.trunc(((quarter32)quarter.MaxValue)).v8_0);
            Assert.AreEqual(maxmath.trunc((float8)(((quarter32)quarter.MaxValue)).v8_8),  (float8)maxmath.trunc(((quarter32)quarter.MaxValue)).v8_8);
            Assert.AreEqual(maxmath.trunc((float8)(((quarter32)quarter.MaxValue)).v8_16), (float8)maxmath.trunc(((quarter32)quarter.MaxValue)).v8_16);
            Assert.AreEqual(maxmath.trunc((float8)(((quarter32)quarter.MaxValue)).v8_24), (float8)maxmath.trunc(((quarter32)quarter.MaxValue)).v8_24);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.trunc((float8)q.v8_0),  (float8)maxmath.trunc(q).v8_0);
                Assert.AreEqual(maxmath.trunc((float8)q.v8_8),  (float8)maxmath.trunc(q).v8_8);
                Assert.AreEqual(maxmath.trunc((float8)q.v8_16), (float8)maxmath.trunc(q).v8_16);
                Assert.AreEqual(maxmath.trunc((float8)q.v8_24), (float8)maxmath.trunc(q).v8_24);

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asbyte(maxmath.trunc(q)) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.asquarter(rng.NextByte32());
                quarter32 trunced = maxmath.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(maxmath.isnan(maxmath.trunc((half)float.NaN)));
            Assert.AreEqual((half)float.NegativeInfinity, maxmath.trunc((half)float.NegativeInfinity));
            Assert.AreEqual((half)float.PositiveInfinity, maxmath.trunc((half)float.PositiveInfinity));

            half q = half.MinValueAsHalf;
            Assert.AreEqual(math.trunc((float)half.MaxValueAsHalf), (float)maxmath.trunc(half.MaxValueAsHalf));

            while (q != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.trunc((float)q), (float)maxmath.trunc(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(maxmath.trunc(q).value, 0x8000);
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.trunc((half2)float.NaN))));
            Assert.AreEqual((half2)float.NegativeInfinity, maxmath.trunc((half2)float.NegativeInfinity));
            Assert.AreEqual((half2)float.PositiveInfinity, maxmath.trunc((half2)float.PositiveInfinity));

            half2 q = half.MinValueAsHalf;
            Assert.AreEqual(math.trunc((float2)half.MaxValueAsHalf), (float2)maxmath.trunc((half2)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.trunc((float2)q), (float2)maxmath.trunc(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asushort(maxmath.trunc(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.ashalf(rng.NextUShort2());
                half2 trunced = maxmath.trunc(q);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.trunc((half3)float.NaN))));
            Assert.AreEqual((half3)float.NegativeInfinity, maxmath.trunc((half3)float.NegativeInfinity));
            Assert.AreEqual((half3)float.PositiveInfinity, maxmath.trunc((half3)float.PositiveInfinity));

            half3 q = half.MinValueAsHalf;
            Assert.AreEqual(math.trunc((float3)half.MaxValueAsHalf), (float3)maxmath.trunc((half3)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.trunc((float3)q), (float3)maxmath.trunc(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asushort(maxmath.trunc(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.ashalf(rng.NextUShort3());
                half3 trunced = maxmath.trunc(q);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.trunc((half4)float.NaN))));
            Assert.AreEqual((half4)float.NegativeInfinity, maxmath.trunc((half4)float.NegativeInfinity));
            Assert.AreEqual((half4)float.PositiveInfinity, maxmath.trunc((half4)float.PositiveInfinity));

            half4 q = half.MinValueAsHalf;
            Assert.AreEqual(math.trunc((float4)half.MaxValueAsHalf), (float4)maxmath.trunc((half4)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.trunc((float4)q), (float4)maxmath.trunc(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asushort(maxmath.trunc(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.ashalf(rng.NextUShort4());
                half4 trunced = maxmath.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.trunc((half8)float.NaN))));
            Assert.AreEqual((half8)float.NegativeInfinity, maxmath.trunc((half8)float.NegativeInfinity));
            Assert.AreEqual((half8)float.PositiveInfinity, maxmath.trunc((half8)float.PositiveInfinity));

            half8 q = half.MinValueAsHalf;
            Assert.AreEqual(maxmath.trunc((float8)half.MaxValueAsHalf), (float8)maxmath.trunc((half8)half.MaxValueAsHalf));

            while (q.x0 != half.MaxValueAsHalf)
            {
                Assert.AreEqual(maxmath.trunc((float8)q), (float8)maxmath.trunc(q));

                if (maxmath.all((float8)q < 0f) && maxmath.all((float8)q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asushort(maxmath.trunc(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.ashalf(rng.NextUShort8());
                half8 trunced = maxmath.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
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
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.trunc((half16)float.NaN))));
            Assert.AreEqual((half16)float.NegativeInfinity, maxmath.trunc((half16)float.NegativeInfinity));
            Assert.AreEqual((half16)float.PositiveInfinity, maxmath.trunc((half16)float.PositiveInfinity));

            half16 q = half.MinValueAsHalf;
            Assert.AreEqual(maxmath.trunc((float8)(((half16)half.MaxValueAsHalf)).v8_0), (float8)maxmath.trunc(((half16)half.MaxValueAsHalf)).v8_0);
            Assert.AreEqual(maxmath.trunc((float8)(((half16)half.MaxValueAsHalf)).v8_8), (float8)maxmath.trunc(((half16)half.MaxValueAsHalf)).v8_8);

            while (q.x0 != half.MaxValueAsHalf)
            {
                Assert.AreEqual(maxmath.trunc((float8)q.v8_0), (float8)maxmath.trunc(q).v8_0);
                Assert.AreEqual(maxmath.trunc((float8)q.v8_8), (float8)maxmath.trunc(q).v8_8);

                if ((float)q.x0 < 0f && (float)q.x0 > -1f)
                {
                    Assert.IsTrue(maxmath.all(maxmath.asushort(maxmath.trunc(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }

            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                q = maxmath.ashalf(rng.NextUShort16());
                half16 trunced = maxmath.trunc(q);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
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
    }
}
