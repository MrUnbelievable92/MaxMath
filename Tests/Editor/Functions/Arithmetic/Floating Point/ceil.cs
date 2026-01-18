using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_ceil
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(maxmath.isnan(maxmath.ceil(quarter.NaN)));
            Assert.AreEqual(quarter.NegativeInfinity, maxmath.ceil(quarter.NegativeInfinity));
            Assert.AreEqual(quarter.PositiveInfinity, maxmath.ceil(quarter.PositiveInfinity));

            quarter q = quarter.MinValue;

            while (q != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float)q), (float)maxmath.ceil(q));

                if (q < 0f && q > -1f)
                {
                    Assert.IsTrue(maxmath.ceil(q).value >= 0b1000_0000);
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.ceil(q), quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.ceil((quarter2)quarter.NaN))));
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, maxmath.ceil((quarter2)quarter.NegativeInfinity));
            Assert.AreEqual((quarter2)quarter.PositiveInfinity, maxmath.ceil((quarter2)quarter.PositiveInfinity));

            quarter2 q = quarter.MinValue;

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float2)q), (float2)maxmath.ceil(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asbyte(maxmath.ceil(q)) >= 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.ceil(q), (quarter2)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.ceil((quarter3)quarter.NaN))));
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, maxmath.ceil((quarter3)quarter.NegativeInfinity));
            Assert.AreEqual((quarter3)quarter.PositiveInfinity, maxmath.ceil((quarter3)quarter.PositiveInfinity));

            quarter3 q = quarter.MinValue;

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float3)q), (float3)maxmath.ceil(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asbyte(maxmath.ceil(q)) >= 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.ceil(q), (quarter3)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.ceil((quarter4)quarter.NaN))));
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, maxmath.ceil((quarter4)quarter.NegativeInfinity));
            Assert.AreEqual((quarter4)quarter.PositiveInfinity, maxmath.ceil((quarter4)quarter.PositiveInfinity));

            quarter4 q = quarter.MinValue;

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.ceil((float4)q), (float4)maxmath.ceil(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asbyte(maxmath.ceil(q)) >= 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.ceil(q), (quarter4)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.ceil((quarter8)quarter.NaN))));
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, maxmath.ceil((quarter8)quarter.NegativeInfinity));
            Assert.AreEqual((quarter8)quarter.PositiveInfinity, maxmath.ceil((quarter8)quarter.PositiveInfinity));

            quarter8 q = quarter.MinValue;

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.ceil((float8)q), (float8)maxmath.ceil(q));

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asbyte(maxmath.ceil(q)) >= 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.ceil(q), (quarter8)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter16()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.ceil((quarter16)quarter.NaN))));
            Assert.AreEqual((quarter16)quarter.NegativeInfinity, maxmath.ceil((quarter16)quarter.NegativeInfinity));
            Assert.AreEqual((quarter16)quarter.PositiveInfinity, maxmath.ceil((quarter16)quarter.PositiveInfinity));

            quarter16 q = quarter.MinValue;

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.ceil((float8)q.v8_0), (float8)maxmath.ceil(q).v8_0);
                Assert.AreEqual(maxmath.ceil((float8)q.v8_8), (float8)maxmath.ceil(q).v8_8);

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asbyte(maxmath.ceil(q)) >= 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.ceil(q), (quarter16)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter32()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.ceil((quarter32)quarter.NaN))));
            Assert.AreEqual((quarter32)quarter.NegativeInfinity, maxmath.ceil((quarter32)quarter.NegativeInfinity));
            Assert.AreEqual((quarter32)quarter.PositiveInfinity, maxmath.ceil((quarter32)quarter.PositiveInfinity));

            quarter32 q = quarter.MinValue;

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.ceil((float8)q.v8_0),  (float8)maxmath.ceil(q).v8_0);
                Assert.AreEqual(maxmath.ceil((float8)q.v8_8),  (float8)maxmath.ceil(q).v8_8);
                Assert.AreEqual(maxmath.ceil((float8)q.v8_16), (float8)maxmath.ceil(q).v8_16);
                Assert.AreEqual(maxmath.ceil((float8)q.v8_24), (float8)maxmath.ceil(q).v8_24);

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asbyte(maxmath.ceil(q)) >= 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.ceil(q), (quarter32)quarter.PositiveInfinity);
        }


        [Test]
        public static void _half()
        {
            Assert.IsTrue(maxmath.isnan(maxmath.ceil((half)float.NaN)));
            Assert.AreEqual((half)float.NegativeInfinity, maxmath.ceil((half)float.NegativeInfinity));
            Assert.AreEqual((half)float.PositiveInfinity, maxmath.ceil((half)float.PositiveInfinity));

            half q = half.MinValueAsHalf;
            Assert.AreEqual(math.ceil((float)half.MaxValueAsHalf), (float)maxmath.ceil(half.MaxValueAsHalf));

            while (q != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.ceil((float)q), (float)maxmath.ceil(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(maxmath.ceil(q).value, 0x8000);
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.ceil((half2)float.NaN))));
            Assert.AreEqual((half2)float.NegativeInfinity, maxmath.ceil((half2)float.NegativeInfinity));
            Assert.AreEqual((half2)float.PositiveInfinity, maxmath.ceil((half2)float.PositiveInfinity));

            half2 q = half.MinValueAsHalf;
            Assert.AreEqual(math.ceil((float2)half.MaxValueAsHalf), (float2)maxmath.ceil((half2)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.ceil((float2)q), (float2)maxmath.ceil(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asushort(maxmath.ceil(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.ceil((half3)float.NaN))));
            Assert.AreEqual((half3)float.NegativeInfinity, maxmath.ceil((half3)float.NegativeInfinity));
            Assert.AreEqual((half3)float.PositiveInfinity, maxmath.ceil((half3)float.PositiveInfinity));

            half3 q = half.MinValueAsHalf;
            Assert.AreEqual(math.ceil((float3)half.MaxValueAsHalf), (float3)maxmath.ceil((half3)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.ceil((float3)q), (float3)maxmath.ceil(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asushort(maxmath.ceil(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.ceil((half4)float.NaN))));
            Assert.AreEqual((half4)float.NegativeInfinity, maxmath.ceil((half4)float.NegativeInfinity));
            Assert.AreEqual((half4)float.PositiveInfinity, maxmath.ceil((half4)float.PositiveInfinity));

            half4 q = half.MinValueAsHalf;
            Assert.AreEqual(math.ceil((float4)half.MaxValueAsHalf), (float4)maxmath.ceil((half4)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.ceil((float4)q), (float4)maxmath.ceil(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all(maxmath.asushort(maxmath.ceil(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.ceil((half8)float.NaN))));
            Assert.AreEqual((half8)float.NegativeInfinity, maxmath.ceil((half8)float.NegativeInfinity));
            Assert.AreEqual((half8)float.PositiveInfinity, maxmath.ceil((half8)float.PositiveInfinity));

            half8 q = half.MinValueAsHalf;
            Assert.AreEqual(maxmath.ceil((float8)half.MaxValueAsHalf), (float8)maxmath.ceil((half8)half.MaxValueAsHalf));

            while (q.x0 != half.MaxValueAsHalf)
            {
                Assert.AreEqual(maxmath.ceil((float8)q), (float8)maxmath.ceil(q));

                if (maxmath.all((float8)q < 0f) && maxmath.all((float8)q > -1f))
                {
                    Assert.IsTrue(maxmath.all(maxmath.asushort(maxmath.ceil(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half16()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.ceil((half16)float.NaN))));
            Assert.AreEqual((half16)float.NegativeInfinity, maxmath.ceil((half16)float.NegativeInfinity));
            Assert.AreEqual((half16)float.PositiveInfinity, maxmath.ceil((half16)float.PositiveInfinity));

            half16 q = half.MinValueAsHalf;
            Assert.AreEqual(maxmath.ceil((float8)(((half16)half.MaxValueAsHalf)).v8_0), (float8)maxmath.ceil(((half16)half.MaxValueAsHalf)).v8_0);
            Assert.AreEqual(maxmath.ceil((float8)(((half16)half.MaxValueAsHalf)).v8_8), (float8)maxmath.ceil(((half16)half.MaxValueAsHalf)).v8_8);

            while (q.x0 != half.MaxValueAsHalf)
            {
                Assert.AreEqual(maxmath.ceil((float8)q.v8_0), (float8)maxmath.ceil(q).v8_0);
                Assert.AreEqual(maxmath.ceil((float8)q.v8_8), (float8)maxmath.ceil(q).v8_8);

                if ((float)q.x0 < 0f && (float)q.x0 > -1f)
                {
                    Assert.IsTrue(maxmath.all(maxmath.asushort(maxmath.ceil(q)) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }
    }
}
