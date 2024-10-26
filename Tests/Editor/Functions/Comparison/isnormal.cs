using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_isnormal
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(maxmath.isnormal((quarter)(15f)));
            Assert.IsTrue(maxmath.isnormal((quarter)(-15f)));
            Assert.IsTrue(maxmath.isnormal((quarter)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsTrue(maxmath.isnormal((quarter)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsFalse(maxmath.isnormal((quarter)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.isnormal((quarter)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.isnormal(quarter.Epsilon));
            Assert.IsFalse(maxmath.isnormal(-quarter.Epsilon));
            Assert.IsFalse(maxmath.isnormal((quarter)(0f)));
            Assert.IsFalse(maxmath.isnormal((quarter)(-0f)));
            Assert.IsFalse(maxmath.isnormal(quarter.PositiveInfinity));
            Assert.IsFalse(maxmath.isnormal(quarter.NegativeInfinity));
            Assert.IsFalse(maxmath.isnormal(quarter.NaN));
        }

        [Test]
        public static void _half()
        {
            Assert.IsTrue(maxmath.isnormal((half)(15f)));
            Assert.IsTrue(maxmath.isnormal((half)(-15f)));
            Assert.IsTrue(maxmath.isnormal((half)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsTrue(maxmath.isnormal((half)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsFalse(maxmath.isnormal((half)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.isnormal((half)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.isnormal(maxmath.ashalf((ushort)1)));
            Assert.IsFalse(maxmath.isnormal((half)(-maxmath.ashalf((ushort)1))));
            Assert.IsFalse(maxmath.isnormal((half)(0f)));
            Assert.IsFalse(maxmath.isnormal((half)(-0f)));
            Assert.IsFalse(maxmath.isnormal((half)float.PositiveInfinity));
            Assert.IsFalse(maxmath.isnormal((half)float.NegativeInfinity));
            Assert.IsFalse(maxmath.isnormal((half)float.NaN));
        }

        [Test]
        public static void _float()
        {
            Assert.IsTrue(maxmath.isnormal(132757f));
            Assert.IsTrue(maxmath.isnormal(-132757f));
            Assert.IsTrue(maxmath.isnormal(math.FLT_MIN_NORMAL));
            Assert.IsTrue(maxmath.isnormal(-math.FLT_MIN_NORMAL));
            Assert.IsFalse(maxmath.isnormal(maxmath.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsFalse(maxmath.isnormal(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsFalse(maxmath.isnormal(float.Epsilon));
            Assert.IsFalse(maxmath.isnormal(-float.Epsilon));
            Assert.IsFalse(maxmath.isnormal(0f));
            Assert.IsFalse(maxmath.isnormal(-0f));
            Assert.IsFalse(maxmath.isnormal(float.PositiveInfinity));
            Assert.IsFalse(maxmath.isnormal(float.NegativeInfinity));
            Assert.IsFalse(maxmath.isnormal(float.NaN));
        }

        [Test]
        public static void _double()
        {
            Assert.IsTrue(maxmath.isnormal(132757d));
            Assert.IsTrue(maxmath.isnormal(-132757d));
            Assert.IsTrue(maxmath.isnormal(math.DBL_MIN_NORMAL));
            Assert.IsTrue(maxmath.isnormal(-math.DBL_MIN_NORMAL));
            Assert.IsFalse(maxmath.isnormal(maxmath.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsFalse(maxmath.isnormal(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsFalse(maxmath.isnormal(double.Epsilon));
            Assert.IsFalse(maxmath.isnormal(-double.Epsilon));
            Assert.IsFalse(maxmath.isnormal(0f));
            Assert.IsFalse(maxmath.isnormal(-0f));
            Assert.IsFalse(maxmath.isnormal(double.PositiveInfinity));
            Assert.IsFalse(maxmath.isnormal(double.NegativeInfinity));
            Assert.IsFalse(maxmath.isnormal(double.NaN));
        }

        [Test]
        public static void _quadruple()
        {
            Assert.IsTrue(maxmath.isnormal((quadruple)(132757d)));
            Assert.IsTrue(maxmath.isnormal((quadruple)(-132757d)));
            Assert.IsTrue(maxmath.isnormal(maxmath.QUAD_MIN_NORMAL));
            Assert.IsTrue(maxmath.isnormal(-maxmath.QUAD_MIN_NORMAL));
            Assert.IsFalse(maxmath.isnormal(maxmath.asquadruple(maxmath.asuint128(maxmath.QUAD_MIN_NORMAL) - 1)));
            Assert.IsFalse(maxmath.isnormal(-maxmath.asquadruple(maxmath.asuint128(maxmath.QUAD_MIN_NORMAL) - 1)));
            Assert.IsFalse(maxmath.isnormal(quadruple.Epsilon));
            Assert.IsFalse(maxmath.isnormal(-quadruple.Epsilon));
            Assert.IsFalse(maxmath.isnormal((quadruple)(0f)));
            Assert.IsFalse(maxmath.isnormal((quadruple)(-0f)));
            Assert.IsFalse(maxmath.isnormal(quadruple.PositiveInfinity));
            Assert.IsFalse(maxmath.isnormal(quadruple.NegativeInfinity));
            Assert.IsFalse(maxmath.isnormal(quadruple.NaN));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((quarter2)(15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter2)(-15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter2)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter2)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)(quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter2)quarter.NaN)));
        }
        
        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((quarter3)(15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter3)(-15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter3)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter3)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)(quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter3)quarter.NaN)));
        }
        
        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((quarter4)(15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter4)(-15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter4)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.isnormal((quarter4)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)(quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((quarter4)quarter.NaN)));
        }
        
        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnormal((quarter8)(15f))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((quarter8)(-15f))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((quarter8)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((quarter8)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)(quarter.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)(-quarter.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)quarter.PositiveInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)quarter.NegativeInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((quarter8)quarter.NaN)));
        }
        
        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((half2)(15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((half2)(-15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((half2)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.isnormal((half2)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)maxmath.ashalf((ushort)1))));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)float.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)float.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((half2)float.NaN)));
        }
        
        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((half3)(15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((half3)(-15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((half3)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.isnormal((half3)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)maxmath.ashalf((ushort)1))));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)float.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)float.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((half3)float.NaN)));
        }
        
        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((half4)(15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((half4)(-15f))));
            Assert.IsTrue(math.all(maxmath.isnormal((half4)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.isnormal((half4)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)maxmath.ashalf((ushort)1))));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)float.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)float.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.isnormal((half4)float.NaN)));
        }
        
        [Test]
        public static void _half8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnormal((half8)(15f))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((half8)(-15f))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((half8)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((half8)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)maxmath.ashalf((ushort)1))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)float.PositiveInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)float.NegativeInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((half8)float.NaN)));
        }
        
        [Test]
        public static void _float2()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((float2)(132757f))));
            Assert.IsTrue(math.all(maxmath.isnormal((float2)(-132757f))));
            Assert.IsTrue(math.all(maxmath.isnormal((float2)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.isnormal((float2)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(-float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((float2)(float.NaN))));
        }
        
        [Test]
        public static void _float3()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((float3)(132757f))));
            Assert.IsTrue(math.all(maxmath.isnormal((float3)(-132757f))));
            Assert.IsTrue(math.all(maxmath.isnormal((float3)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.isnormal((float3)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(-float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((float3)(float.NaN))));
        }
        
        [Test]
        public static void _float4()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((float4)(132757f))));
            Assert.IsTrue(math.all(maxmath.isnormal((float4)(-132757f))));
            Assert.IsTrue(math.all(maxmath.isnormal((float4)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.isnormal((float4)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(-float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((float4)(float.NaN))));
        }
        
        [Test]
        public static void _float8()
        {
            Assert.IsTrue(maxmath.all(maxmath.isnormal((float8)(132757f))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((float8)(-132757f))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((float8)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(maxmath.all(maxmath.isnormal((float8)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(float.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(-float.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(float.PositiveInfinity))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(float.NegativeInfinity))));
            Assert.IsFalse(maxmath.all(maxmath.isnormal((float8)(float.NaN))));
        }
        
        [Test]
        public static void _double2()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((double2)(132757d))));
            Assert.IsTrue(math.all(maxmath.isnormal((double2)(-132757d))));
            Assert.IsTrue(math.all(maxmath.isnormal((double2)(math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.isnormal((double2)(-math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(-double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((double2)(double.NaN))));
        }
        
        [Test]
        public static void _double3()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((double3)(132757d))));
            Assert.IsTrue(math.all(maxmath.isnormal((double3)(-132757d))));
            Assert.IsTrue(math.all(maxmath.isnormal((double3)(math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.isnormal((double3)(-math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(-double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((double3)(double.NaN))));
        }
        
        [Test]
        public static void _double4()
        {
            Assert.IsTrue(math.all(maxmath.isnormal((double4)(132757d))));
            Assert.IsTrue(math.all(maxmath.isnormal((double4)(-132757d))));
            Assert.IsTrue(math.all(maxmath.isnormal((double4)(math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.isnormal((double4)(-math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(-double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(-0f))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.isnormal((double4)(double.NaN))));
        }

    }
}
