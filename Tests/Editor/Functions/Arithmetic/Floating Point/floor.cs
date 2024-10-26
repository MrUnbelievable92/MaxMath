using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_floor
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(maxmath.isnan(maxmath.floor(quarter.NaN)));
            Assert.AreEqual(quarter.NegativeInfinity, maxmath.floor(quarter.NegativeInfinity));
            Assert.AreEqual(quarter.PositiveInfinity, maxmath.floor(quarter.PositiveInfinity));

            quarter q = quarter.MinValue;
            Assert.AreEqual(maxmath.floor(q), quarter.NegativeInfinity);
            q = maxmath.nextgreater(q);

            while (q != quarter.MaxValue)
            {
                Assert.AreEqual(math.floor((float)q), (float)maxmath.floor(q));

                if (q < 0f && q > -1f)
                {
                    Assert.IsTrue((maxmath.floor(q).value & 0b1000_0000) == 0b1000_0000);
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(math.floor((float)q), (float)maxmath.floor(q));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.floor((quarter2)quarter.NaN))));
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, maxmath.floor((quarter2)quarter.NegativeInfinity));
            Assert.AreEqual((quarter2)quarter.PositiveInfinity, maxmath.floor((quarter2)quarter.PositiveInfinity));

            quarter2 q = quarter.MinValue;
            Assert.AreEqual((quarter2)quarter.NegativeInfinity, maxmath.floor(q));
            q = maxmath.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.floor((float2)q), (float2)maxmath.floor(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asbyte(maxmath.floor(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.floor((quarter3)quarter.NaN))));
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, maxmath.floor((quarter3)quarter.NegativeInfinity));
            Assert.AreEqual((quarter3)quarter.PositiveInfinity, maxmath.floor((quarter3)quarter.PositiveInfinity));

            quarter3 q = quarter.MinValue;
            Assert.AreEqual((quarter3)quarter.NegativeInfinity, maxmath.floor(q));
            q = maxmath.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.floor((float3)q), (float3)maxmath.floor(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asbyte(maxmath.floor(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(math.floor((float3)q), (float3)maxmath.floor(q));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.floor((quarter4)quarter.NaN))));
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, maxmath.floor((quarter4)quarter.NegativeInfinity));
            Assert.AreEqual((quarter4)quarter.PositiveInfinity, maxmath.floor((quarter4)quarter.PositiveInfinity));

            quarter4 q = quarter.MinValue;
            Assert.AreEqual((quarter4)quarter.NegativeInfinity, maxmath.floor(q));
            q = maxmath.nextgreater(q);

            while (q.x != quarter.MaxValue)
            {
                Assert.AreEqual(math.floor((float4)q), (float4)maxmath.floor(q));

                if (math.all(q < 0f) && math.all(q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asbyte(maxmath.floor(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(math.floor((float4)q), (float4)maxmath.floor(q));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.floor((quarter8)quarter.NaN))));
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, maxmath.floor((quarter8)quarter.NegativeInfinity));
            Assert.AreEqual((quarter8)quarter.PositiveInfinity, maxmath.floor((quarter8)quarter.PositiveInfinity));

            quarter8 q = quarter.MinValue;
            Assert.AreEqual((quarter8)quarter.NegativeInfinity, maxmath.floor(q));
            q = maxmath.nextgreater(q);

            while (q.x0 != quarter.MaxValue)
            {
                Assert.AreEqual(maxmath.floor((float8)q), (float8)maxmath.floor(q));

                if (maxmath.all(q < 0f) && maxmath.all(q > -1f))
                {
                    Assert.IsTrue(maxmath.all((maxmath.asbyte(maxmath.floor(q)) & 0b1000_0000) == 0b1000_0000));
                }

                q = maxmath.nextgreater(q);
            }

            Assert.AreEqual(maxmath.floor((float8)q), (float8)maxmath.floor(q));
        }


        [Test]
        public static void _half()
        {
            Assert.IsTrue(maxmath.isnan(maxmath.floor((half)float.NaN)));
            Assert.AreEqual((half)float.NegativeInfinity, maxmath.floor((half)float.NegativeInfinity));
            Assert.AreEqual((half)float.PositiveInfinity, maxmath.floor((half)float.PositiveInfinity));

            half q = half.MinValueAsHalf;
            Assert.AreEqual(math.floor((float)half.MaxValueAsHalf), (float)maxmath.floor(half.MaxValueAsHalf));

            while (q != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.floor((float)q), (float)maxmath.floor(q));

                if (q < 0f && q > -1f)
                {
                    Assert.AreEqual(maxmath.floor(q).value & 0x8000, 0x8000);
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.floor((half2)float.NaN))));
            Assert.AreEqual((half2)float.NegativeInfinity, maxmath.floor((half2)float.NegativeInfinity));
            Assert.AreEqual((half2)float.PositiveInfinity, maxmath.floor((half2)float.PositiveInfinity));

            half2 q = half.MinValueAsHalf;
            Assert.AreEqual(math.floor((float2)half.MaxValueAsHalf), (float2)maxmath.floor((half2)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.floor((float2)q), (float2)maxmath.floor(q));

                if (math.all((float2)q < 0f) && math.all((float2)q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asushort(maxmath.floor(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.floor((half3)float.NaN))));
            Assert.AreEqual((half3)float.NegativeInfinity, maxmath.floor((half3)float.NegativeInfinity));
            Assert.AreEqual((half3)float.PositiveInfinity, maxmath.floor((half3)float.PositiveInfinity));

            half3 q = half.MinValueAsHalf;
            Assert.AreEqual(math.floor((float3)half.MaxValueAsHalf), (float3)maxmath.floor((half3)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.floor((float3)q), (float3)maxmath.floor(q));

                if (math.all((float3)q < 0f) && math.all((float3)q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asushort(maxmath.floor(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(maxmath.isnan(maxmath.floor((half4)float.NaN))));
            Assert.AreEqual((half4)float.NegativeInfinity, maxmath.floor((half4)float.NegativeInfinity));
            Assert.AreEqual((half4)float.PositiveInfinity, maxmath.floor((half4)float.PositiveInfinity));

            half4 q = half.MinValueAsHalf;
            Assert.AreEqual(math.floor((float4)half.MaxValueAsHalf), (float4)maxmath.floor((half4)half.MaxValueAsHalf));

            while (q.x != half.MaxValueAsHalf)
            {
                Assert.AreEqual(math.floor((float4)q), (float4)maxmath.floor(q));

                if (math.all((float4)q < 0f) && math.all((float4)q > -1f))
                {
                    Assert.IsTrue(math.all((maxmath.asushort(maxmath.floor(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }

        [Test]
        public static void _half8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnan(maxmath.floor((half8)float.NaN))));
            Assert.AreEqual((half8)float.NegativeInfinity, maxmath.floor((half8)float.NegativeInfinity));
            Assert.AreEqual((half8)float.PositiveInfinity, maxmath.floor((half8)float.PositiveInfinity));

            half8 q = half.MinValueAsHalf;
            Assert.AreEqual(maxmath.floor((float8)half.MaxValueAsHalf), (float8)maxmath.floor((half8)half.MaxValueAsHalf));

            while (q.x0 != half.MaxValueAsHalf)
            {
                Assert.AreEqual(maxmath.floor((float8)q), (float8)maxmath.floor(q));

                if (maxmath.all((float8)q < 0f) && maxmath.all((float8)q > -1f))
                {
                    Assert.IsTrue(maxmath.all((maxmath.asushort(maxmath.floor(q)) & 0x8000) == 0x8000));
                }

                q = maxmath.nextgreater(q);
            }
        }
    }
}
