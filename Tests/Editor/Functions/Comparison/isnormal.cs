using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_isnormal
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsTrue(math.isnormal((quarter)(15f)));
            Assert.IsTrue(math.isnormal((quarter)(-15f)));
            Assert.IsTrue(math.isnormal((quarter)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsTrue(math.isnormal((quarter)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsFalse(math.isnormal((quarter)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.isnormal((quarter)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.isnormal(quarter.Epsilon));
            Assert.IsFalse(math.isnormal(-quarter.Epsilon));
            Assert.IsFalse(math.isnormal((quarter)(0f)));
            Assert.IsFalse(math.isnormal((quarter)(-0f)));
            Assert.IsFalse(math.isnormal(quarter.PositiveInfinity));
            Assert.IsFalse(math.isnormal(quarter.NegativeInfinity));
            Assert.IsFalse(math.isnormal(quarter.NaN));
        }

        [Test]
        public static void _half()
        {
            Assert.IsTrue(math.isnormal((half)(15f)));
            Assert.IsTrue(math.isnormal((half)(-15f)));
            Assert.IsTrue(math.isnormal((half)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsTrue(math.isnormal((half)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsFalse(math.isnormal((half)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.isnormal((half)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.isnormal(math.ashalf((ushort)1)));
            Assert.IsFalse(math.isnormal((half)(-math.ashalf((ushort)1))));
            Assert.IsFalse(math.isnormal((half)(0f)));
            Assert.IsFalse(math.isnormal((half)(-0f)));
            Assert.IsFalse(math.isnormal((half)float.PositiveInfinity));
            Assert.IsFalse(math.isnormal((half)float.NegativeInfinity));
            Assert.IsFalse(math.isnormal((half)float.NaN));
        }

        [Test]
        public static void _float()
        {
            Assert.IsTrue(math.isnormal(132757f));
            Assert.IsTrue(math.isnormal(-132757f));
            Assert.IsTrue(math.isnormal(math.FLT_MIN_NORMAL));
            Assert.IsTrue(math.isnormal(-math.FLT_MIN_NORMAL));
            Assert.IsFalse(math.isnormal(math.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsFalse(math.isnormal(-math.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsFalse(math.isnormal(float.Epsilon));
            Assert.IsFalse(math.isnormal(-float.Epsilon));
            Assert.IsFalse(math.isnormal(0f));
            Assert.IsFalse(math.isnormal(-0f));
            Assert.IsFalse(math.isnormal(float.PositiveInfinity));
            Assert.IsFalse(math.isnormal(float.NegativeInfinity));
            Assert.IsFalse(math.isnormal(float.NaN));
        }

        [Test]
        public static void _double()
        {
            Assert.IsTrue(math.isnormal(132757d));
            Assert.IsTrue(math.isnormal(-132757d));
            Assert.IsTrue(math.isnormal(math.DBL_MIN_NORMAL));
            Assert.IsTrue(math.isnormal(-math.DBL_MIN_NORMAL));
            Assert.IsFalse(math.isnormal(math.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsFalse(math.isnormal(-math.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsFalse(math.isnormal(double.Epsilon));
            Assert.IsFalse(math.isnormal(-double.Epsilon));
            Assert.IsFalse(math.isnormal(0f));
            Assert.IsFalse(math.isnormal(-0f));
            Assert.IsFalse(math.isnormal(double.PositiveInfinity));
            Assert.IsFalse(math.isnormal(double.NegativeInfinity));
            Assert.IsFalse(math.isnormal(double.NaN));
        }

        [Test]
        public static void _quadruple()
        {
            Assert.IsTrue(math.isnormal((quadruple)(132757d)));
            Assert.IsTrue(math.isnormal((quadruple)(-132757d)));
            Assert.IsTrue(math.isnormal(math.QUAD_MIN_NORMAL));
            Assert.IsTrue(math.isnormal(-math.QUAD_MIN_NORMAL));
            Assert.IsFalse(math.isnormal(math.asquadruple(math.asuint128(math.QUAD_MIN_NORMAL) - 1)));
            Assert.IsFalse(math.isnormal(-math.asquadruple(math.asuint128(math.QUAD_MIN_NORMAL) - 1)));
            Assert.IsFalse(math.isnormal(quadruple.Epsilon));
            Assert.IsFalse(math.isnormal(-quadruple.Epsilon));
            Assert.IsFalse(math.isnormal((quadruple)(0f)));
            Assert.IsFalse(math.isnormal((quadruple)(-0f)));
            Assert.IsFalse(math.isnormal(quadruple.PositiveInfinity));
            Assert.IsFalse(math.isnormal(quadruple.NegativeInfinity));
            Assert.IsFalse(math.isnormal(quadruple.NaN));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsTrue(math.all(math.isnormal((quarter2)(15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter2)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter2)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((quarter2)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((quarter2)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter2)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter2)(quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter2)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter2)(0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter2)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter2)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter2)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter2)quarter.NaN)));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsTrue(math.all(math.isnormal((quarter3)(15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter3)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter3)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((quarter3)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((quarter3)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter3)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter3)(quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter3)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter3)(0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter3)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter3)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter3)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter3)quarter.NaN)));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsTrue(math.all(math.isnormal((quarter4)(15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter4)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter4)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((quarter4)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((quarter4)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter4)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter4)(quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter4)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter4)(0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter4)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter4)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter4)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter4)quarter.NaN)));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsTrue(math.all(math.isnormal((quarter8)(15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter8)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter8)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((quarter8)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((quarter8)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter8)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter8)(quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter8)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter8)(0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter8)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter8)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter8)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter8)quarter.NaN)));
        }

        [Test]
        public static void _quarter16()
        {
            Assert.IsTrue(math.all(math.isnormal((quarter16)(15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter16)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter16)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((quarter16)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((quarter16)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter16)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter16)(quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter16)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter16)(0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter16)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter16)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter16)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter16)quarter.NaN)));
        }

        [Test]
        public static void _quarter32()
        {
            Assert.IsTrue(math.all(math.isnormal((quarter32)(15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter32)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((quarter32)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((quarter32)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((quarter32)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter32)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((quarter32)(quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter32)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((quarter32)(0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter32)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((quarter32)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter32)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((quarter32)quarter.NaN)));
        }

        [Test]
        public static void _half2()
        {
            Assert.IsTrue(math.all(math.isnormal((half2)(15f))));
            Assert.IsTrue(math.all(math.isnormal((half2)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((half2)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((half2)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((half2)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half2)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half2)math.ashalf((ushort)1))));
            Assert.IsFalse(math.all(math.isnormal((half2)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.isnormal((half2)(0f))));
            Assert.IsFalse(math.all(math.isnormal((half2)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((half2)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half2)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half2)float.NaN)));
        }

        [Test]
        public static void _half3()
        {
            Assert.IsTrue(math.all(math.isnormal((half3)(15f))));
            Assert.IsTrue(math.all(math.isnormal((half3)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((half3)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((half3)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((half3)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half3)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half3)math.ashalf((ushort)1))));
            Assert.IsFalse(math.all(math.isnormal((half3)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.isnormal((half3)(0f))));
            Assert.IsFalse(math.all(math.isnormal((half3)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((half3)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half3)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half3)float.NaN)));
        }

        [Test]
        public static void _half4()
        {
            Assert.IsTrue(math.all(math.isnormal((half4)(15f))));
            Assert.IsTrue(math.all(math.isnormal((half4)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((half4)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((half4)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((half4)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half4)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half4)math.ashalf((ushort)1))));
            Assert.IsFalse(math.all(math.isnormal((half4)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.isnormal((half4)(0f))));
            Assert.IsFalse(math.all(math.isnormal((half4)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((half4)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half4)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half4)float.NaN)));
        }

        [Test]
        public static void _half8()
        {
            Assert.IsTrue(math.all(math.isnormal((half8)(15f))));
            Assert.IsTrue(math.all(math.isnormal((half8)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((half8)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((half8)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((half8)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half8)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half8)math.ashalf((ushort)1))));
            Assert.IsFalse(math.all(math.isnormal((half8)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.isnormal((half8)(0f))));
            Assert.IsFalse(math.all(math.isnormal((half8)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((half8)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half8)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half8)float.NaN)));
        }

        [Test]
        public static void _half16()
        {
            Assert.IsTrue(math.all(math.isnormal((half16)(15f))));
            Assert.IsTrue(math.all(math.isnormal((half16)(-15f))));
            Assert.IsTrue(math.all(math.isnormal((half16)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.isnormal((half16)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.isnormal((half16)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half16)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsFalse(math.all(math.isnormal((half16)math.ashalf((ushort)1))));
            Assert.IsFalse(math.all(math.isnormal((half16)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.isnormal((half16)(0f))));
            Assert.IsFalse(math.all(math.isnormal((half16)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((half16)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half16)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.isnormal((half16)float.NaN)));
        }

        [Test]
        public static void _float2()
        {
            Assert.IsTrue(math.all(math.isnormal((float2)(132757f))));
            Assert.IsTrue(math.all(math.isnormal((float2)(-132757f))));
            Assert.IsTrue(math.all(math.isnormal((float2)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.isnormal((float2)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.isnormal((float2)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float2)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float2)(float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float2)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float2)(0f))));
            Assert.IsFalse(math.all(math.isnormal((float2)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((float2)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float2)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float2)(float.NaN))));
        }

        [Test]
        public static void _float3()
        {
            Assert.IsTrue(math.all(math.isnormal((float3)(132757f))));
            Assert.IsTrue(math.all(math.isnormal((float3)(-132757f))));
            Assert.IsTrue(math.all(math.isnormal((float3)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.isnormal((float3)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.isnormal((float3)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float3)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float3)(float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float3)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float3)(0f))));
            Assert.IsFalse(math.all(math.isnormal((float3)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((float3)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float3)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float3)(float.NaN))));
        }

        [Test]
        public static void _float4()
        {
            Assert.IsTrue(math.all(math.isnormal((float4)(132757f))));
            Assert.IsTrue(math.all(math.isnormal((float4)(-132757f))));
            Assert.IsTrue(math.all(math.isnormal((float4)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.isnormal((float4)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.isnormal((float4)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float4)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float4)(float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float4)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float4)(0f))));
            Assert.IsFalse(math.all(math.isnormal((float4)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((float4)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float4)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float4)(float.NaN))));
        }

        [Test]
        public static void _float8()
        {
            Assert.IsTrue(math.all(math.isnormal((float8)(132757f))));
            Assert.IsTrue(math.all(math.isnormal((float8)(-132757f))));
            Assert.IsTrue(math.all(math.isnormal((float8)(math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.isnormal((float8)(-math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.isnormal((float8)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float8)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((float8)(float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float8)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((float8)(0f))));
            Assert.IsFalse(math.all(math.isnormal((float8)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((float8)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float8)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.isnormal((float8)(float.NaN))));
        }

        [Test]
        public static void _double2()
        {
            Assert.IsTrue(math.all(math.isnormal((double2)(132757d))));
            Assert.IsTrue(math.all(math.isnormal((double2)(-132757d))));
            Assert.IsTrue(math.all(math.isnormal((double2)(math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.isnormal((double2)(-math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.isnormal((double2)(math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((double2)(-math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((double2)(double.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((double2)(-double.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((double2)(0f))));
            Assert.IsFalse(math.all(math.isnormal((double2)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((double2)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(math.isnormal((double2)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(math.isnormal((double2)(double.NaN))));
        }

        [Test]
        public static void _double3()
        {
            Assert.IsTrue(math.all(math.isnormal((double3)(132757d))));
            Assert.IsTrue(math.all(math.isnormal((double3)(-132757d))));
            Assert.IsTrue(math.all(math.isnormal((double3)(math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.isnormal((double3)(-math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.isnormal((double3)(math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((double3)(-math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((double3)(double.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((double3)(-double.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((double3)(0f))));
            Assert.IsFalse(math.all(math.isnormal((double3)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((double3)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(math.isnormal((double3)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(math.isnormal((double3)(double.NaN))));
        }

        [Test]
        public static void _double4()
        {
            Assert.IsTrue(math.all(math.isnormal((double4)(132757d))));
            Assert.IsTrue(math.all(math.isnormal((double4)(-132757d))));
            Assert.IsTrue(math.all(math.isnormal((double4)(math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.isnormal((double4)(-math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.isnormal((double4)(math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((double4)(-math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsFalse(math.all(math.isnormal((double4)(double.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((double4)(-double.Epsilon))));
            Assert.IsFalse(math.all(math.isnormal((double4)(0f))));
            Assert.IsFalse(math.all(math.isnormal((double4)(-0f))));
            Assert.IsFalse(math.all(math.isnormal((double4)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(math.isnormal((double4)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(math.isnormal((double4)(double.NaN))));
        }

    }
}
