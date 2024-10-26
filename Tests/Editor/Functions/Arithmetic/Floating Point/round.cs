using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_round
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(maxmath.isnan(maxmath.round(quarter.NaN)));
            Assert.AreEqual(quarter.NegativeInfinity, maxmath.round(quarter.NegativeInfinity));
            Assert.AreEqual(quarter.PositiveInfinity, maxmath.round(quarter.PositiveInfinity));

            quarter q = quarter.MinValue;
            Assert.AreEqual(maxmath.round(q), quarter.NegativeInfinity);
            q = maxmath.nextgreater(q);

            while (q != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float)q), (float)maxmath.round(q));

                if (q < 0f && q > -1f)
                {
                    Assert.IsTrue((maxmath.round(q).value & 0b1000_0000) == 0b1000_0000);
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.round(q), quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.round((quarter2)quarter.NaN))));
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, maxmath.round((quarter2)quarter.NegativeInfinity));
            Assert.AreEqual((quarter2)quarter.PositiveInfinity, maxmath.round((quarter2)quarter.PositiveInfinity));

            quarter2 q = quarter.MinValue;
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, maxmath.round(q));
            q = maxmath.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float2)q), (float2)maxmath.round(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asbyte(maxmath.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.round(q), (quarter2)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.round((quarter3)quarter.NaN))));
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, maxmath.round((quarter3)quarter.NegativeInfinity));
            Assert.AreEqual((quarter3)quarter.PositiveInfinity, maxmath.round((quarter3)quarter.PositiveInfinity));

            quarter3 q = quarter.MinValue;
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, maxmath.round(q));
            q = maxmath.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float3)q), (float3)maxmath.round(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asbyte(maxmath.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.round(q), (quarter3)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.round((quarter4)quarter.NaN))));
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, maxmath.round((quarter4)quarter.NegativeInfinity));
            Assert.AreEqual((quarter4)quarter.PositiveInfinity, maxmath.round((quarter4)quarter.PositiveInfinity));

            quarter4 q = quarter.MinValue;
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, maxmath.round(q));
            q = maxmath.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.round((float4)q), (float4)maxmath.round(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asbyte(maxmath.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.round(q), (quarter4)quarter.PositiveInfinity);
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.round((quarter8)quarter.NaN))));
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, maxmath.round((quarter8)quarter.NegativeInfinity));
            Assert.AreEqual((quarter8)quarter.PositiveInfinity, maxmath.round((quarter8)quarter.PositiveInfinity));

            quarter8 q = quarter.MinValue;
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, maxmath.round(q));
            q = maxmath.nextgreater(q);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.round((float8)q), (float8)maxmath.round(q));

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all((maxmath.asbyte(maxmath.round(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.round(q), (quarter8)quarter.PositiveInfinity);
        }


        [Test]
        public static void _half()
        {
            Assert.IsTrue(maxmath.isnan(maxmath.round((half)float.NaN)));
            Assert.AreEqual((half)float.NegativeInfinity, maxmath.round((half)float.NegativeInfinity));
            Assert.AreEqual((half)float.PositiveInfinity, maxmath.round((half)float.PositiveInfinity));

            half q = half.MinValueAsHalf;
            Assert.AreEqual(math.round((float)half.MaxValueAsHalf), (float)maxmath.round(half.MaxValueAsHalf));

            while (q != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.round((float)q), (float)maxmath.round(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(maxmath.round(q).value & 0x8000, 0x8000);
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.round((half2)float.NaN))));
            Assert.AreEqual((half2)float.NegativeInfinity, maxmath.round((half2)float.NegativeInfinity));
            Assert.AreEqual((half2)float.PositiveInfinity, maxmath.round((half2)float.PositiveInfinity));

            half2 q = half.MinValueAsHalf;
            Assert.AreEqual(math.round((float2)half.MaxValueAsHalf), (float2)maxmath.round((half2)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.round((float2)q), (float2)maxmath.round(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asushort(maxmath.round(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.round((half3)float.NaN))));
            Assert.AreEqual((half3)float.NegativeInfinity, maxmath.round((half3)float.NegativeInfinity));
            Assert.AreEqual((half3)float.PositiveInfinity, maxmath.round((half3)float.PositiveInfinity));

            half3 q = half.MinValueAsHalf;
            Assert.AreEqual(math.round((float3)half.MaxValueAsHalf), (float3)maxmath.round((half3)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.round((float3)q), (float3)maxmath.round(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asushort(maxmath.round(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.round((half4)float.NaN))));
            Assert.AreEqual((half4)float.NegativeInfinity, maxmath.round((half4)float.NegativeInfinity));
            Assert.AreEqual((half4)float.PositiveInfinity, maxmath.round((half4)float.PositiveInfinity));

            half4 q = half.MinValueAsHalf;
            Assert.AreEqual(math.round((float4)half.MaxValueAsHalf), (float4)maxmath.round((half4)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.round((float4)q), (float4)maxmath.round(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asushort(maxmath.round(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.round((half8)float.NaN))));
            Assert.AreEqual((half8)float.NegativeInfinity, maxmath.round((half8)float.NegativeInfinity));
            Assert.AreEqual((half8)float.PositiveInfinity, maxmath.round((half8)float.PositiveInfinity));

            half8 q = half.MinValueAsHalf;
            Assert.AreEqual(maxmath.round((float8)half.MaxValueAsHalf), (float8)maxmath.round((half8)half.MaxValueAsHalf));

            while (q.x0 != half.MaxValueAsHalf)
            {
                Assert.AreEqual(maxmath.round((float8)q), (float8)maxmath.round(q));

                if (maxmath.all((float8)q < 0f) && maxmath.all((float8)q > -1f))
                {
                    Assert.IsTrue(maxmath.all((maxmath.asushort(maxmath.round(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }
    }
}
