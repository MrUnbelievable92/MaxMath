namespace MaxMath
{
    internal static partial class LUT
    {
        internal static class CVT_INT_FP
        {
            public const ulong USF_CVT_EPU64_PD_LIMIT = (1ul << 52) - 1;
            public const long ABS_MASK_USF_CVT_EPI64_PD_LIMIT = 1L << 51;
            
            internal const float LIMIT_PRECISE_U32_F32 = 8_388_608f;
            internal const double LIMIT_PRECISE_U64_F64 = 4_503_599_627_370_496d;
        }
    }
}
