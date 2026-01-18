using Unity.Mathematics;

namespace MaxMath
{
    internal static partial class LUT
    {
        internal static class CVT_INT_FP
        {
            internal const ulong USF_CVT_EPU64_PD_LIMIT = (1ul << 52) - 1;
            internal const long ABS_MASK_USF_CVT_EPI64_PD_LIMIT = 1L << 51;

            // 2^MANTISSA_BITS
            internal static half LIMIT_PRECISE_U16_F16 => maxmath.ashalf((ushort)0x6400);
            internal const float LIMIT_PRECISE_U32_F32 = 8_388_608f;
            internal const double LIMIT_PRECISE_U64_F64 = 4_503_599_627_370_496d;
            internal static quadruple LIMIT_PRECISE_U128_F128 => new quadruple(0, 0x406F_0000_0000_0000);

            internal static double LIMIT_CVTF64_U64 => maxmath.nextsmaller((double)ulong.MaxValue);

            internal const uint RCP32_PRECISION_LOSS_U8 = 0x3F80_4189;
            internal const uint RCP32_PRECISION_LOSS_U16 = 0x4000_0002;

            internal const uint MAX_ACCURATE_INT_SQRT_F32 = 16_785_406;
            internal const ulong MAX_ACCURATE_INT_SQRT_F64 = 2275475126346874; // NO, larger
            internal static UInt128 MAX_SQRT_F64_NO_UI64_OVERFLOW_UI128 => new UInt128(0xFFFF_FFFF_FFFF_FFFF, 0xFFFF_FFFF_FFFF_FBFF);
        }
    }
}
