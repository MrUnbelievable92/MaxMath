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
            internal static half LIMIT_PRECISE_U16_F16 => maxmath.ashalf((ushort)0x6400); // 1024 
            internal const float LIMIT_PRECISE_U32_F32 = 8_388_608f;
            internal const double LIMIT_PRECISE_U64_F64 = 4_503_599_627_370_496d;
            internal static quadruple LIMIT_PRECISE_U128_F128 => (UInt128)1 << quadruple.MANTISSA_BITS;

            internal const uint MAX_ACCURATE_INT_SQRT_F32 = 16_785_406;
            internal const ulong MAX_ACCURATE_INT_SQRT_F64 = 2270491511357440; // NO, larger
        }
    }
}
