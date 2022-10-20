using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(v128 dividend_f32, v128 divisor_f32)
        {
            if (Sse2.IsSse2Supported)
            {
                //if (BurstCompiler.FloatMode == FloatMode.Fast)
                //{
                //    v128 divisorRcp = Sse.rcp_ps(divisor_f32);
                //    v128 approxQuotient = Sse.mul_ps(dividend_f32, divisorRcp);
                //    v128 precisionLossCompensation = fnmadd_ps(divisorRcp, divisor_f32, Sse2.set1_epi32(0x4000_0002));
                //
                //    return Sse2.cvttps_epi32(Sse.mul_ps(precisionLossCompensation, approxQuotient));
                //}
                //else
                //{
                    // actually faster on newer CPUs than reciprocal multiplication
                    return Sse2.cvttps_epi32(Sse.div_ps(dividend_f32, divisor_f32));
                //}
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(v256 dividend_f32, v256 divisor_f32)
        {
            if (Avx.IsAvxSupported)
            {
                //if (BurstCompiler.FloatMode == FloatMode.Fast)
                //{
                //    v256 divisorRcp = Avx.mm256_rcp_ps(divisor_f32);
                //    v256 approxQuotient = Avx.mm256_mul_ps(dividend_f32, divisorRcp);
                //    v256 precisionLossCompensation = mm256_fnmadd_ps(divisorRcp, divisor_f32, Avx.mm256_set1_epi32(0x4000_0002));
                //
                //    return Avx.mm256_cvttps_epi32(Avx.mm256_mul_ps(precisionLossCompensation, approxQuotient));
                //}
                //else
                //{
                    // actually faster on newer CPUs than reciprocal multiplication
                    return Avx.mm256_cvttps_epi32(Avx.mm256_div_ps(dividend_f32, divisor_f32));
                //}
            } 
            else throw new IllegalInstructionException();
        }
    }
}