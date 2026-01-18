using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics;

#pragma warning disable CS1718 // comparison to same variable is a test case

namespace MaxMath.Tests
{
    unsafe public static class t_half
    {
        [Test]
        public static void FromFloat()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN((float)q);
                }
                else
                {
                    Assert.AreEqual(q, (half)(float)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                float f = subnormalQuarter ? rng.NextFloat(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                           : rng.NextFloat(half.MinValue, half.MaxValue);

                half q = (half)f;
                half qm1 = maxmath.nextsmaller(q);
                half qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.abs(f - qm1) < math.abs(f - q));
                Assert.IsFalse(math.abs(f - qp1) < math.abs(f - q));
            }
        }

        [Test]
        public static void FromDouble()
        {
            for (int i = 0; i < 256; i++)
            {
                half q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN((double)q);
                }
                else
                {
                    Assert.AreEqual(q, (half)(double)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                double f = subnormalQuarter ? rng.NextDouble(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                            : rng.NextDouble(half.MinValue, half.MaxValue);

                half q = (half)f;
                half qm1 = maxmath.nextsmaller(q);
                half qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.abs(f - qm1) < math.abs(f - q));
                Assert.IsFalse(math.abs(f - qp1) < math.abs(f - q));
            }
        }

        [Test]
        public static void FromFloat2()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half2 q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((float2)q)));
                }
                else
                {
                    Assert.AreEqual(q, (half2)(float2)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat2_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                float2 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(half.MinValue, half.MaxValue);

                half2 q = (half2)f;
                half2 qm1 = maxmath.nextsmaller(q);
                half2 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromDouble2()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half2 q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((double2)q)));
                }
                else
                {
                    Assert.AreEqual(q, (half2)(double2)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble2_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                double2 f = subnormalQuarter ? (double)rng.NextDouble(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                             : (double)rng.NextDouble(half.MinValue, half.MaxValue);

                half2 q = (half2)f;
                half2 qm1 = maxmath.nextsmaller(q);
                half2 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromFloat3()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half3 q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((float3)q)));
                }
                else
                {
                    Assert.AreEqual(q, (half3)(float3)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat3_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 138) subnormalQuarter = true;

                float3 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(half.MinValue, half.MaxValue);

                half3 q = (half3)f;
                half3 qm1 = maxmath.nextsmaller(q);
                half3 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromDouble3()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half3 q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((double3)q)));
                }
                else
                {
                    Assert.AreEqual(q, (half3)(double3)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble3_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 138) subnormalQuarter = true;

                double3 f = subnormalQuarter ? (double)rng.NextDouble(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                             : (double)rng.NextDouble(half.MinValue, half.MaxValue);

                half3 q = (half3)f;
                half3 qm1 = maxmath.nextsmaller(q);
                half3 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromFloat4()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half4 q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((float4)q)));
                }
                else
                {
                    Assert.AreEqual(q, (half4)(float4)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat4_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 148) subnormalQuarter = true;

                float4 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(half.MinValue, half.MaxValue);

                half4 q = (half4)f;
                half4 qm1 = maxmath.nextsmaller(q);
                half4 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromDouble4()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half4 q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q.x))
                {
                    Assert.IsTrue(math.all(math.isnan((double4)q)));
                }
                else
                {
                    Assert.AreEqual(q, (half4)(double4)q);
                }
            }
        }
        
        [Test]
        public static void FromDouble4_RoundToNearest()
        {
            Random64 rng = Random64.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 148) subnormalQuarter = true;

                double4 f = subnormalQuarter ? (double)rng.NextDouble(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                             : (double)rng.NextDouble(half.MinValue, half.MaxValue);

                half4 q = (half4)f;
                half4 qm1 = maxmath.nextsmaller(q);
                half4 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(math.any(math.abs(f - qm1) < math.abs(f - q)));
                Assert.IsFalse(math.any(math.abs(f - qp1) < math.abs(f - q)));
            }
        }

        [Test]
        public static void FromFloat8()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            {
                half8 q = maxmath.ashalf((ushort)i);

                if (maxmath.isnan(q.x0))
                {
                    Assert.IsTrue(maxmath.all(maxmath.isnan((float8)q)));
                }
                else
                {
                    Assert.AreEqual(q, (half8)(float8)q);
                }
            }
        }
        
        [Test]
        public static void FromFloat8_RoundToNearest()
        {
            Random32 rng = Random32.New;
            bool subnormalQuarter = false;

            for (int i = 0; i < 256; i++)
            {
                if (i > 128) subnormalQuarter = true;

                float8 f = subnormalQuarter ? (float)rng.NextFloat(-maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS)), maxmath.ashalf(maxmath.bitmask16(LUT.FLOATING_POINT.F16_MANTISSA_BITS))) 
                                            : (float)rng.NextFloat(half.MinValue, half.MaxValue);

                half8 q = (half8)f;
                half8 qm1 = maxmath.nextsmaller(q);
                half8 qp1 = maxmath.nextgreater(q);
            
                Assert.IsFalse(maxmath.any(maxmath.abs(f - qm1) < maxmath.abs(f - q)));
                Assert.IsFalse(maxmath.any(maxmath.abs(f - qp1) < maxmath.abs(f - q)));
            }
        }
    }
}