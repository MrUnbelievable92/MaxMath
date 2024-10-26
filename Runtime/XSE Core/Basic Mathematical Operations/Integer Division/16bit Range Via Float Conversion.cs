using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(v128 dividend_f32, v128 divisor_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 divisorRcp = rcp_ps(divisor_f32);
                v128 approxQuotient = mul_ps(dividend_f32, divisorRcp);
                v128 precisionLossCompensation = fnmadd_ps(divisorRcp, divisor_f32, set1_epi32(0x4000_0002));

                return cvttps_epi32(mul_ps(precisionLossCompensation, approxQuotient));
            }
            else if (Architecture.IsSIMDSupported)
            {
                return cvttps_epi32(div_ps(dividend_f32, divisor_f32));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(v256 dividend_f32, v256 divisor_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 divisorRcp = Avx.mm256_rcp_ps(divisor_f32);
                v256 approxQuotient = Avx.mm256_mul_ps(dividend_f32, divisorRcp);
                v256 precisionLossCompensation = mm256_fnmadd_ps(divisorRcp, divisor_f32, mm256_set1_epi32(0x4000_0002));

                return Avx.mm256_cvttps_epi32(Avx.mm256_mul_ps(precisionLossCompensation, approxQuotient));
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvttps_epi32(Avx.mm256_div_ps(dividend_f32, divisor_f32));
            }
            else throw new IllegalInstructionException();
        }

        /// <summary> SAFE RANGE (SUMMAND ONLY): [0, byte.MaxValue] </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(v128 dividend_f32, v128 divisor_f32, v128 summand_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 divisorRcp = rcp_ps(divisor_f32);
                v128 approxQuotient = mul_ps(dividend_f32, divisorRcp);
                v128 precisionLossCompensation = fnmadd_ps(divisorRcp, divisor_f32, set1_epi32(0x4000_0002));

                return cvttps_epi32(fmadd_ps(precisionLossCompensation, approxQuotient, summand_f32));
            }
            else throw new IllegalInstructionException();
        }

        /// <summary> SAFE RANGE (SUMMAND ONLY): [0, byte.MaxValue] </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(v256 dividend_f32, v256 divisor_f32, v256 summand_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 divisorRcp = Avx.mm256_rcp_ps(divisor_f32);
                v256 approxQuotient = Avx.mm256_mul_ps(dividend_f32, divisorRcp);
                v256 precisionLossCompensation = mm256_fnmadd_ps(divisorRcp, divisor_f32, mm256_set1_epi32(0x4000_0002));

                return Avx.mm256_cvttps_epi32(mm256_fmadd_ps(precisionLossCompensation, approxQuotient, summand_f32));
            }
            else throw new IllegalInstructionException();
        }
    }
}