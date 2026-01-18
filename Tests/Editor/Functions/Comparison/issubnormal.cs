using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_issubnormal
    {
        [Test]
        public static void _quarter()
        {
            Assert.IsFalse(maxmath.issubnormal((quarter)(15f)));
            Assert.IsFalse(maxmath.issubnormal((quarter)(-15f)));
            Assert.IsFalse(maxmath.issubnormal((quarter)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsFalse(maxmath.issubnormal((quarter)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))));
            Assert.IsTrue(maxmath.issubnormal((quarter)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.issubnormal((quarter)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.issubnormal(quarter.Epsilon));
            Assert.IsTrue(maxmath.issubnormal(-quarter.Epsilon));
            Assert.IsFalse(maxmath.issubnormal((quarter)(0f)));
            Assert.IsFalse(maxmath.issubnormal((quarter)(-0f)));
            Assert.IsFalse(maxmath.issubnormal(quarter.PositiveInfinity));
            Assert.IsFalse(maxmath.issubnormal(quarter.NegativeInfinity));
            Assert.IsFalse(maxmath.issubnormal(quarter.NaN));
        }

        [Test]
        public static void _half()
        {
            Assert.IsFalse(maxmath.issubnormal((half)(15f)));
            Assert.IsFalse(maxmath.issubnormal((half)(-15f)));
            Assert.IsFalse(maxmath.issubnormal((half)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsFalse(maxmath.issubnormal((half)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))));
            Assert.IsTrue(maxmath.issubnormal((half)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.issubnormal((half)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.issubnormal(maxmath.ashalf((ushort)1)));
            Assert.IsTrue(maxmath.issubnormal((half)(-maxmath.ashalf((ushort)1))));
            Assert.IsFalse(maxmath.issubnormal((half)(0f)));
            Assert.IsFalse(maxmath.issubnormal((half)(-0f)));
            Assert.IsFalse(maxmath.issubnormal((half)float.PositiveInfinity));
            Assert.IsFalse(maxmath.issubnormal((half)float.NegativeInfinity));
            Assert.IsFalse(maxmath.issubnormal((half)float.NaN));
        }

        [Test]
        public static void _float()
        {
            Assert.IsFalse(maxmath.issubnormal(132757f));
            Assert.IsFalse(maxmath.issubnormal(-132757f));
            Assert.IsFalse(maxmath.issubnormal(math.FLT_MIN_NORMAL));
            Assert.IsFalse(maxmath.issubnormal(-math.FLT_MIN_NORMAL));
            Assert.IsTrue(maxmath.issubnormal(maxmath.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsTrue(maxmath.issubnormal(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)));
            Assert.IsTrue(maxmath.issubnormal(float.Epsilon));
            Assert.IsTrue(maxmath.issubnormal(-float.Epsilon));
            Assert.IsFalse(maxmath.issubnormal(0f));
            Assert.IsFalse(maxmath.issubnormal(-0f));
            Assert.IsFalse(maxmath.issubnormal(float.PositiveInfinity));
            Assert.IsFalse(maxmath.issubnormal(float.NegativeInfinity));
            Assert.IsFalse(maxmath.issubnormal(float.NaN));
        }

        [Test]
        public static void _double()
        {
            Assert.IsFalse(maxmath.issubnormal(132757d));
            Assert.IsFalse(maxmath.issubnormal(-132757d));
            Assert.IsFalse(maxmath.issubnormal(math.DBL_MIN_NORMAL));
            Assert.IsFalse(maxmath.issubnormal(-math.DBL_MIN_NORMAL));
            Assert.IsTrue(maxmath.issubnormal(maxmath.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsTrue(maxmath.issubnormal(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)));
            Assert.IsTrue(maxmath.issubnormal(double.Epsilon));
            Assert.IsTrue(maxmath.issubnormal(-double.Epsilon));
            Assert.IsFalse(maxmath.issubnormal(0f));
            Assert.IsFalse(maxmath.issubnormal(-0f));
            Assert.IsFalse(maxmath.issubnormal(double.PositiveInfinity));
            Assert.IsFalse(maxmath.issubnormal(double.NegativeInfinity));
            Assert.IsFalse(maxmath.issubnormal(double.NaN));
        }

        [Test]
        public static void _quadruple()
        {
            Assert.IsFalse(maxmath.issubnormal((quadruple)(132757d)));
            Assert.IsFalse(maxmath.issubnormal((quadruple)(-132757d)));
            Assert.IsFalse(maxmath.issubnormal(maxmath.QUAD_MIN_NORMAL));
            Assert.IsFalse(maxmath.issubnormal(-maxmath.QUAD_MIN_NORMAL));
            Assert.IsTrue(maxmath.issubnormal(maxmath.asquadruple(maxmath.asuint128(maxmath.QUAD_MIN_NORMAL) - 1)));
            Assert.IsTrue(maxmath.issubnormal(-maxmath.asquadruple(maxmath.asuint128(maxmath.QUAD_MIN_NORMAL) - 1)));
            Assert.IsTrue(maxmath.issubnormal(quadruple.Epsilon));
            Assert.IsTrue(maxmath.issubnormal(-quadruple.Epsilon));
            Assert.IsFalse(maxmath.issubnormal((quadruple)(0f)));
            Assert.IsFalse(maxmath.issubnormal((quadruple)(-0f)));
            Assert.IsFalse(maxmath.issubnormal(quadruple.PositiveInfinity));
            Assert.IsFalse(maxmath.issubnormal(quadruple.NegativeInfinity));
            Assert.IsFalse(maxmath.issubnormal(quadruple.NaN));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)(15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)(-15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter2)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter2)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter2)(quarter.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter2)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter2)quarter.NaN)));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)(15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)(-15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter3)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter3)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter3)(quarter.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter3)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter3)quarter.NaN)));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)(15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)(-15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter4)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter4)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter4)(quarter.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((quarter4)(-quarter.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)quarter.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)quarter.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((quarter4)quarter.NaN)));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)(15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)(-15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter8)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter8)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter8)(quarter.Epsilon))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter8)(-quarter.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)quarter.PositiveInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)quarter.NegativeInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter8)quarter.NaN)));
        }

        [Test]
        public static void _quarter16()
        {
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)(15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)(-15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter16)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter16)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter16)(quarter.Epsilon))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter16)(-quarter.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)quarter.PositiveInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)quarter.NegativeInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter16)quarter.NaN)));
        }

        [Test]
        public static void _quarter32()
        {
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)(15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)(-15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)(-maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter32)(maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter32)(-maxmath.nextsmaller(maxmath.asquarter((byte)(1 << quarter.MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter32)(quarter.Epsilon))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((quarter32)(-quarter.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)quarter.PositiveInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)quarter.NegativeInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((quarter32)quarter.NaN)));
        }

        [Test]
        public static void _half2()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)(15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)(-15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half2)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half2)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half2)maxmath.ashalf((ushort)1))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half2)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)float.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)float.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((half2)float.NaN)));
        }

        [Test]
        public static void _half3()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)(15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)(-15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half3)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half3)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half3)maxmath.ashalf((ushort)1))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half3)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)float.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)float.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((half3)float.NaN)));
        }

        [Test]
        public static void _half4()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)(15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)(-15f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half4)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half4)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half4)maxmath.ashalf((ushort)1))));
            Assert.IsTrue(math.all(maxmath.issubnormal((half4)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)float.PositiveInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)float.NegativeInfinity)));
            Assert.IsFalse(math.all(maxmath.issubnormal((half4)float.NaN)));
        }

        [Test]
        public static void _half8()
        {
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)(15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)(-15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half8)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half8)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half8)maxmath.ashalf((ushort)1))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half8)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)float.PositiveInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)float.NegativeInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half8)float.NaN)));
        }

        [Test]
        public static void _half16()
        {
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)(15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)(-15f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)(-maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half16)(maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half16)(-maxmath.nextsmaller(maxmath.ashalf((ushort)(1 << LUT.FLOATING_POINT.F16_MANTISSA_BITS)))))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half16)maxmath.ashalf((ushort)1))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((half16)(-maxmath.ashalf((ushort)1)))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)float.PositiveInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)float.NegativeInfinity)));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((half16)float.NaN)));
        }

        [Test]
        public static void _float2()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(132757f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(-132757f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float2)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float2)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float2)(float.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float2)(-float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float2)(float.NaN))));
        }

        [Test]
        public static void _float3()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(132757f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(-132757f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float3)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float3)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float3)(float.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float3)(-float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float3)(float.NaN))));
        }

        [Test]
        public static void _float4()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(132757f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(-132757f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float4)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float4)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float4)(float.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((float4)(-float.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(float.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(float.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((float4)(float.NaN))));
        }

        [Test]
        public static void _float8()
        {
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(132757f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(-132757f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(math.FLT_MIN_NORMAL))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(-math.FLT_MIN_NORMAL))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((float8)(maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((float8)(-maxmath.nextsmaller(math.FLT_MIN_NORMAL)))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((float8)(float.Epsilon))));
            Assert.IsTrue(maxmath.all(maxmath.issubnormal((float8)(-float.Epsilon))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(-0f))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(float.PositiveInfinity))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(float.NegativeInfinity))));
            Assert.IsFalse(maxmath.all(maxmath.issubnormal((float8)(float.NaN))));
        }

        [Test]
        public static void _double2()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(132757d))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(-132757d))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(-math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double2)(maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double2)(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double2)(double.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double2)(-double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double2)(double.NaN))));
        }

        [Test]
        public static void _double3()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(132757d))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(-132757d))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(-math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double3)(maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double3)(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double3)(double.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double3)(-double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double3)(double.NaN))));
        }

        [Test]
        public static void _double4()
        {
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(132757d))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(-132757d))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(math.DBL_MIN_NORMAL))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(-math.DBL_MIN_NORMAL))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double4)(maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double4)(-maxmath.nextsmaller(math.DBL_MIN_NORMAL)))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double4)(double.Epsilon))));
            Assert.IsTrue(math.all(maxmath.issubnormal((double4)(-double.Epsilon))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(-0f))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(double.PositiveInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(double.NegativeInfinity))));
            Assert.IsFalse(math.all(maxmath.issubnormal((double4)(double.NaN))));
        }

    }
}
