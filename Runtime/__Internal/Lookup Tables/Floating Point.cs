namespace MaxMath
{
    internal static partial class LUT
    {
        internal static class FLOATING_POINT
        {
            internal const byte MANTISSA_ROUNDING_BITS = 3;

            internal const int F16_BITS                   = F32_BITS / 2;
            internal const int F16_EXPONENT_BITS          = 5;
            internal const int F16_MANTISSA_BITS          = 10;
            internal const int F16_EXPONENT_BIAS          = -(int)(((1L << F16_BITS) - 1) >> (F16_BITS - (F16_EXPONENT_BITS - 1)));
            internal const int F16_MAX_UNBIASED_EXPONENT  = -F16_EXPONENT_BIAS;
            internal const int F16_MIN_UNBIASED_EXPONENT  = F16_EXPONENT_BIAS + 1;
            internal const int F16_SIGNALING_EXPONENT     = (F16_MAX_UNBIASED_EXPONENT - F16_EXPONENT_BIAS + 1) << F16_MANTISSA_BITS;

            internal const int F32_BITS                   = 8 * sizeof(float);
            internal const int F32_EXPONENT_BITS          = 8;
            internal const int F32_MANTISSA_BITS          = 23;
            internal const int F32_EXPONENT_BIAS          = -(int)(((1L << F32_BITS) - 1) >> (F32_BITS - (F32_EXPONENT_BITS - 1)));
            internal const int F32_MAX_UNBIASED_EXPONENT  = -F32_EXPONENT_BIAS;
            internal const int F32_MIN_UNBIASED_EXPONENT  = F32_EXPONENT_BIAS + 1;
            internal const int F32_SIGNALING_EXPONENT     = (F32_MAX_UNBIASED_EXPONENT - F32_EXPONENT_BIAS + 1) << F32_MANTISSA_BITS;

            internal const int  F64_BITS                  = F32_BITS * 2;
            internal const int  F64_EXPONENT_BITS         = 11;
            internal const int  F64_MANTISSA_BITS         = 52;
            internal const int  F64_EXPONENT_BIAS         = -(int)((/*(1L << F64_BITS) - 1*/ulong.MaxValue) >> (F64_BITS - (F64_EXPONENT_BITS - 1)));
            internal const int  F64_MAX_UNBIASED_EXPONENT = -F64_EXPONENT_BIAS;
            internal const int  F64_MIN_UNBIASED_EXPONENT = F64_EXPONENT_BIAS + 1;
            internal const long F64_SIGNALING_EXPONENT    = (F64_MAX_UNBIASED_EXPONENT - F64_EXPONENT_BIAS + 1L) << F64_MANTISSA_BITS;

            internal const float F32_TO_LAST_DIGIT = 1e-6f;
            internal const double F64_TO_LAST_DIGIT = 1e-14d;
            internal static quadruple F128_TO_LAST_DIGIT => /*1e-32q*/ new quadruple(0x2974_CFBC_31DB_4B08, 0x3F94_9F62_3D5A_8A73); 
        }                                                                   
    }
}

