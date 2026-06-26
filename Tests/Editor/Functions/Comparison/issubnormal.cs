using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_issubnormal
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsFalse(math.issubnormal((quarter)(15f)));
            Assert.IsFalse(math.issubnormal((quarter)(-15f)));
            Assert.IsFalse(math.issubnormal((quarter)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsFalse(math.issubnormal((quarter)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsTrue(math.issubnormal((quarter)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.issubnormal((quarter)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.issubnormal(quarter.Epsilon));
            Assert.IsTrue(math.issubnormal(-quarter.Epsilon));
            Assert.IsFalse(math.issubnormal((quarter)(0f)));
            Assert.IsFalse(math.issubnormal((quarter)(-0f)));
            Assert.IsFalse(math.issubnormal(quarter.PositiveInfinity));
            Assert.IsFalse(math.issubnormal(quarter.NegativeInfinity));
            Assert.IsFalse(math.issubnormal(quarter.NaN));
        }

        [Test]
        public static void _half()
        {
            Assert.IsFalse(math.issubnormal((half)(15f)));
            Assert.IsFalse(math.issubnormal((half)(-15f)));
            Assert.IsFalse(math.issubnormal((half)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsFalse(math.issubnormal((half)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsTrue(math.issubnormal((half)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.issubnormal((half)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.issubnormal(math.ashalf((ushort)1)));
            Assert.IsTrue(math.issubnormal((half)(-math.ashalf((ushort)1))));
            Assert.IsFalse(math.issubnormal((half)(0f)));
            Assert.IsFalse(math.issubnormal((half)(-0f)));
            Assert.IsFalse(math.issubnormal((half)float.PositiveInfinity));
            Assert.IsFalse(math.issubnormal((half)float.NegativeInfinity));
            Assert.IsFalse(math.issubnormal((half)float.NaN));
        }

        [Test]
        public static void _float()
        {
            Assert.IsFalse(math.issubnormal(132757f));
            Assert.IsFalse(math.issubnormal(-132757f));
            Assert.IsFalse(math.issubnormal(math.FLT_MIN_NORMAL));
            Assert.IsFalse(math.issubnormal(-math.FLT_MIN_NORMAL));
            Assert.IsTrue(math.issubnormal(math.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsTrue(math.issubnormal(-math.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsTrue(math.issubnormal(float.Epsilon));
            Assert.IsTrue(math.issubnormal(-float.Epsilon));
            Assert.IsFalse(math.issubnormal(0f));
            Assert.IsFalse(math.issubnormal(-0f));
            Assert.IsFalse(math.issubnormal(float.PositiveInfinity));
            Assert.IsFalse(math.issubnormal(float.NegativeInfinity));
            Assert.IsFalse(math.issubnormal(float.NaN));
        }

        [Test]
        public static void _double()
        {
            Assert.IsFalse(math.issubnormal(132757d));
            Assert.IsFalse(math.issubnormal(-132757d));
            Assert.IsFalse(math.issubnormal(math.DBL_MIN_NORMAL));
            Assert.IsFalse(math.issubnormal(-math.DBL_MIN_NORMAL));
            Assert.IsTrue(math.issubnormal(math.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsTrue(math.issubnormal(-math.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsTrue(math.issubnormal(double.Epsilon));
            Assert.IsTrue(math.issubnormal(-double.Epsilon));
            Assert.IsFalse(math.issubnormal(0f));
            Assert.IsFalse(math.issubnormal(-0f));
            Assert.IsFalse(math.issubnormal(double.PositiveInfinity));
            Assert.IsFalse(math.issubnormal(double.NegativeInfinity));
            Assert.IsFalse(math.issubnormal(double.NaN));
        }

        [Test]
        public static void _quadruple()
        {
            Assert.IsFalse(math.issubnormal((quadruple)(132757d)));
            Assert.IsFalse(math.issubnormal((quadruple)(-132757d)));
            Assert.IsFalse(math.issubnormal(math.QUAD_MIN_NORMAL));
            Assert.IsFalse(math.issubnormal(-math.QUAD_MIN_NORMAL));
            Assert.IsTrue(math.issubnormal(math.asquadruple(math.asuint128(math.QUAD_MIN_NORMAL) - 1)));
            Assert.IsTrue(math.issubnormal(-math.asquadruple(math.asuint128(math.QUAD_MIN_NORMAL) - 1)));
            Assert.IsTrue(math.issubnormal(quadruple.Epsilon));
            Assert.IsTrue(math.issubnormal(-quadruple.Epsilon));
            Assert.IsFalse(math.issubnormal((quadruple)(0f)));
            Assert.IsFalse(math.issubnormal((quadruple)(-0f)));
            Assert.IsFalse(math.issubnormal(quadruple.PositiveInfinity));
            Assert.IsFalse(math.issubnormal(quadruple.NegativeInfinity));
            Assert.IsFalse(math.issubnormal(quadruple.NaN));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsFalse(math.all(math.issubnormal((quarter2)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter2)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter2)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter2)(quarter.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((quarter2)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter2)quarter.NaN)));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsFalse(math.all(math.issubnormal((quarter3)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter3)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter3)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter3)(quarter.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((quarter3)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter3)quarter.NaN)));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsFalse(math.all(math.issubnormal((quarter4)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter4)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter4)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter4)(quarter.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((quarter4)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter4)quarter.NaN)));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsFalse(math.all(math.issubnormal((quarter8)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter8)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter8)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter8)(quarter.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((quarter8)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter8)quarter.NaN)));
        }

        [Test]
        public static void _quarter16()
        {
            Assert.IsFalse(math.all(math.issubnormal((quarter16)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter16)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter16)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter16)(quarter.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((quarter16)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter16)quarter.NaN)));
        }

        [Test]
        public static void _quarter32()
        {
            Assert.IsFalse(math.all(math.issubnormal((quarter32)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)(math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)(-math.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter32)(math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter32)(-math.nextsmaller(math.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((quarter32)(quarter.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((quarter32)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((quarter32)quarter.NaN)));
        }

        [Test]
        public static void _half2()
        {
            Assert.IsFalse(math.all(math.issubnormal((half2)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((half2)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((half2)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((half2)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((half2)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half2)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half2)math.ashalf((ushort)1))));
            Assert.IsTrue(math.all(math.issubnormal((half2)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.issubnormal((half2)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((half2)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((half2)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half2)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half2)float.NaN)));
        }

        [Test]
        public static void _half3()
        {
            Assert.IsFalse(math.all(math.issubnormal((half3)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((half3)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((half3)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((half3)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((half3)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half3)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half3)math.ashalf((ushort)1))));
            Assert.IsTrue(math.all(math.issubnormal((half3)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.issubnormal((half3)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((half3)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((half3)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half3)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half3)float.NaN)));
        }

        [Test]
        public static void _half4()
        {
            Assert.IsFalse(math.all(math.issubnormal((half4)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((half4)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((half4)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((half4)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((half4)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half4)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half4)math.ashalf((ushort)1))));
            Assert.IsTrue(math.all(math.issubnormal((half4)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.issubnormal((half4)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((half4)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((half4)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half4)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half4)float.NaN)));
        }

        [Test]
        public static void _half8()
        {
            Assert.IsFalse(math.all(math.issubnormal((half8)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((half8)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((half8)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((half8)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((half8)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half8)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half8)math.ashalf((ushort)1))));
            Assert.IsTrue(math.all(math.issubnormal((half8)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.issubnormal((half8)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((half8)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((half8)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half8)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half8)float.NaN)));
        }

        [Test]
        public static void _half16()
        {
            Assert.IsFalse(math.all(math.issubnormal((half16)(15f))));
            Assert.IsFalse(math.all(math.issubnormal((half16)(-15f))));
            Assert.IsFalse(math.all(math.issubnormal((half16)(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(math.issubnormal((half16)(-math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(math.issubnormal((half16)(math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half16)(-math.nextsmaller(math.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(math.issubnormal((half16)math.ashalf((ushort)1))));
            Assert.IsTrue(math.all(math.issubnormal((half16)(-math.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(math.issubnormal((half16)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((half16)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((half16)float.PositiveInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half16)float.NegativeInfinity)));
            Assert.IsFalse(math.all(math.issubnormal((half16)float.NaN)));
        }

        [Test]
        public static void _float2()
        {
            Assert.IsFalse(math.all(math.issubnormal((float2)(132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(-132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.issubnormal((float2)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float2)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float2)(float.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((float2)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float2)(float.NaN))));
        }

        [Test]
        public static void _float3()
        {
            Assert.IsFalse(math.all(math.issubnormal((float3)(132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(-132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.issubnormal((float3)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float3)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float3)(float.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((float3)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float3)(float.NaN))));
        }

        [Test]
        public static void _float4()
        {
            Assert.IsFalse(math.all(math.issubnormal((float4)(132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(-132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.issubnormal((float4)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float4)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float4)(float.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((float4)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float4)(float.NaN))));
        }

        [Test]
        public static void _float8()
        {
            Assert.IsFalse(math.all(math.issubnormal((float8)(132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(-132757f))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.issubnormal((float8)(math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float8)(-math.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((float8)(float.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((float8)(-float.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((float8)(float.NaN))));
        }

        [Test]
        public static void _double2()
        {
            Assert.IsFalse(math.all(math.issubnormal((double2)(132757d))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(-132757d))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(-math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.issubnormal((double2)(math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((double2)(-math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((double2)(double.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((double2)(-double.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((double2)(double.NaN))));
        }

        [Test]
        public static void _double3()
        {
            Assert.IsFalse(math.all(math.issubnormal((double3)(132757d))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(-132757d))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(-math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.issubnormal((double3)(math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((double3)(-math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((double3)(double.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((double3)(-double.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((double3)(double.NaN))));
        }

        [Test]
        public static void _double4()
        {
            Assert.IsFalse(math.all(math.issubnormal((double4)(132757d))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(-132757d))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(-math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(math.issubnormal((double4)(math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((double4)(-math.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(math.issubnormal((double4)(double.Epsilon))));
            Assert.IsTrue(math.all(math.issubnormal((double4)(-double.Epsilon))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(0f))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(-0f))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(math.issubnormal((double4)(double.NaN))));
        }

    }
}
