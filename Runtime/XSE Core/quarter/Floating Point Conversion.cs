//#define TESTING
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            private const bool QUARTER_CONVERSION_SHIFT_IN_RANGE = 
#if TESTING 
            false;
#else
            true;
#endif
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_ph(v128 q, bool promiseInRange = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    const byte EXPONENT_OFFSET = -F16_EXPONENT_BIAS + quarter.EXPONENT_BIAS;

                    v128 exp = and_si128(q, set1_epi8(quarter.SIGNALING_EXPONENT));
                    v128 frac = and_si128(q, set1_epi8(bitmask8(quarter.MANTISSA_BITS)));
                    
                    v128 expIs0 = cmpeq_epi8(exp, setzero_si128());
                    v128 fracIs0_16 = cvtepi8_epi16(cmpeq_epi8(frac, setzero_si128()));
                    v128 isNaNinf_16 = cvtepi8_epi16(cmpeq_epi8(exp, set1_epi8(quarter.SIGNALING_EXPONENT)));

                    v128 frac_16 = cvtepu8_epi16(frac);
                    v128 denormalExp_16;
                    v128 denormalFrac_16;
                    if (Architecture.IsTableLookupSupported)
                    {
                        v128 shiftDistBase = sub_epi8(new v128(8, 7, 6, 6, 5, 5, 5, 5,   4, 4, 4, 4, 4, 4, 4, 4), set1_epi8(quarter.EXPONENT_BITS));
                        v128 shiftDist_16 = cvtepu8_epi16(shuffle_epi8(shiftDistBase, frac));

                        v128 expLUT = slli_epi16(sub_epi8(set1_epi8(EXPONENT_OFFSET), shiftDistBase), F16_MANTISSA_BITS - quarter.BITS);
                        denormalExp_16 = unpacklo_epi8(setzero_si128(), shuffle_epi8(expLUT, frac));

                        denormalExp_16 = andnot_si128(fracIs0_16, denormalExp_16);
                        denormalFrac_16 = sllv_epi16(frac_16, shiftDist_16, inRange: true, elements: elements);
                    }
                    else
                    {
                        v128 cmpgt1 = cmpgt_epi16(frac_16, set1_epi16(1));
                        v128 cmpgt3 = cmpgt_epi16(frac_16, set1_epi16(3));
                        v128 cmpgt7 = cmpgt_epi16(frac_16, set1_epi16(7));
                        
                        v128 fracSHLgt7_16 = slli_epi16(frac_16, 4 - quarter.EXPONENT_BITS);
                        v128 fracSHLgt3_16 = slli_epi16(frac_16, 5 - quarter.EXPONENT_BITS);
                        v128 fracSHLgt1_16 = slli_epi16(frac_16, 6 - quarter.EXPONENT_BITS);
                        v128 fracSHLgt0_16 = slli_epi16(frac_16, 7 - quarter.EXPONENT_BITS);
                        v128 expSHLgt7_16 = set1_epi16((EXPONENT_OFFSET - (4 - quarter.EXPONENT_BITS)) << F16_MANTISSA_BITS);
                        v128 expSHLgt3_16 = set1_epi16((EXPONENT_OFFSET - (5 - quarter.EXPONENT_BITS)) << F16_MANTISSA_BITS);
                        v128 expSHLgt1_16 = set1_epi16((EXPONENT_OFFSET - (6 - quarter.EXPONENT_BITS)) << F16_MANTISSA_BITS);
                        v128 expSHLgt0_16 = set1_epi16((EXPONENT_OFFSET - (7 - quarter.EXPONENT_BITS)) << F16_MANTISSA_BITS);
                        
                        v128 blend3or7 = blendv_si128(fracSHLgt3_16, fracSHLgt7_16, cmpgt7);
                        v128 blend0or1 = blendv_si128(fracSHLgt0_16, fracSHLgt1_16, cmpgt1);
                        denormalFrac_16 = blendv_si128(blend0or1, blend3or7, cmpgt3);
                        blend3or7 = blendv_si128(expSHLgt3_16, expSHLgt7_16, cmpgt7);
                        blend0or1 = blendv_si128(expSHLgt0_16, expSHLgt1_16, cmpgt1);
                        denormalExp_16 = andnot_si128(fracIs0_16, blendv_si128(blend0or1, blend3or7, cmpgt3));
                    }
                    
                    v128 normalExp_16 = add_epi16(cvtepu8_epi16(exp), set1_epi16(EXPONENT_OFFSET << quarter.MANTISSA_BITS));
                    normalExp_16 = slli_epi16(normalExp_16, F16_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    if (!promiseInRange)
                    {
                        normalExp_16 = blendv_si128(normalExp_16, set1_epi16(F16_SIGNALING_EXPONENT), isNaNinf_16);
                        frac_16      = blendv_si128(frac_16,      inc_epi16(fracIs0_16),              isNaNinf_16);
                    }

                    v128 expIs0_16 = cvtepi8_epi16(expIs0);
                    v128 result_16 = add_epi16(blendv_si128(normalExp_16, denormalExp_16, expIs0_16), slli_epi16(blendv_si128(frac_16, denormalFrac_16, expIs0_16), F16_MANTISSA_BITS - quarter.MANTISSA_BITS));
                    v128 sign_16 = slli_epi16(srli_epi16(cvtepu8_epi16(q), quarter.BITS - 1), F16_BITS - 1);

                    return or_si128(sign_16, result_16);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtsq_ss(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 F8_NAN_INF = cvtsi32_si128(quarter.SIGNALING_EXPONENT);
                    v128 F32_INF = RegisterConversion.ToV128(float.PositiveInfinity);
                    v128 MAGIC = cvtsi32_si128(quarter.F32_MAGIC);
                    v128 exponentMantissa;

                    if (promiseAbsoluteAndInRange || constexpr.IS_TRUE(q.Byte0 <= quarter.MaxValue.value))
                    {
                        exponentMantissa = slli_epi32(q, quarter.F32_SHL_LOSE_SIGN - quarter.F32_SHR_PLACE_MANTISSA);

                        return mul_ss(MAGIC, exponentMantissa);
                    }

                    exponentMantissa = srli_epi32(slli_epi32(q, quarter.F32_SHL_LOSE_SIGN), quarter.F32_SHR_PLACE_MANTISSA);
                    v128 sign = slli_epi32(srli_epi32(q, quarter.BITS - 1), F32_BITS - 1);

                    if (promiseInRange)
                    {
                        return mul_ss(MAGIC, or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = cmpeq_epi32(and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f32 = ternarylogic_si128(exponentMantissa, F32_INF, isNanInf, TernaryOperation.OxF8);

                    return mul_ss(or_si128(sign, f32), blendv_si128(MAGIC, f32, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_ps(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 F8_NAN_INF = set1_epi32(quarter.SIGNALING_EXPONENT);
                    v128 F32_INF = set1_ps(float.PositiveInfinity);
                    v128 MAGIC = set1_epi32(quarter.F32_MAGIC);
                    v128 exponentMantissa;

                    if (promiseAbsoluteAndInRange || constexpr.ALL_LE_EPU8(q, quarter.MaxValue.value, elements))
                    {
                        exponentMantissa = slli_epi32(cvtepu8_epi32(q), quarter.F32_SHL_LOSE_SIGN - quarter.F32_SHR_PLACE_MANTISSA);

                        return mul_ps(MAGIC, exponentMantissa);
                    }

                    q = cvtepu8_epi32(q);
                    exponentMantissa = srli_epi32(slli_epi32(q, quarter.F32_SHL_LOSE_SIGN), quarter.F32_SHR_PLACE_MANTISSA);
                    v128 sign = slli_epi32(srli_epi32(q, quarter.BITS - 1), F32_BITS - 1);

                    if (promiseInRange)
                    {
                        return mul_ps(MAGIC, or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = cmpeq_epi32(and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f32 = ternarylogic_si128(exponentMantissa, F32_INF, isNanInf, TernaryOperation.OxF8);

                    return mul_ps(or_si128(sign, f32), blendv_si128(MAGIC, f32, isNanInf));
                }
                else throw new IllegalInstructionException();
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtpq_ps(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 F8_NAN_INF = mm256_set1_epi32(quarter.SIGNALING_EXPONENT);
                    v256 F32_INF = mm256_set1_ps(float.PositiveInfinity);
                    v256 MAGIC = mm256_set1_epi32(quarter.F32_MAGIC);
                    v256 exponentMantissa;

                    if (promiseAbsoluteAndInRange || constexpr.ALL_LE_EPU8(q, quarter.MaxValue.value, 8))
                    {
                        exponentMantissa = Avx2.mm256_slli_epi32(Avx2.mm256_cvtepu8_epi32(q), quarter.F32_SHL_LOSE_SIGN - quarter.F32_SHR_PLACE_MANTISSA);

                        return Avx.mm256_mul_ps(MAGIC, exponentMantissa);
                    }

                    v256 __q = Avx2.mm256_cvtepu8_epi32(q);
                    exponentMantissa = Avx2.mm256_srli_epi32(Avx2.mm256_slli_epi32(__q, quarter.F32_SHL_LOSE_SIGN), quarter.F32_SHR_PLACE_MANTISSA);
                    v256 sign = Avx2.mm256_slli_epi32(Avx2.mm256_srli_epi32(__q, quarter.BITS - 1), F32_BITS - 1);

                    if (promiseInRange)
                    {
                        return Avx.mm256_mul_ps(MAGIC, Avx2.mm256_or_si256(sign, exponentMantissa));
                    }

                    v256 isNanInf = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(__q, F8_NAN_INF), F8_NAN_INF);
                    v256 f32 = mm256_ternarylogic_si256(exponentMantissa, F32_INF, isNanInf, TernaryOperation.OxF8);

                    return Avx.mm256_mul_ps(Avx2.mm256_or_si256(sign, f32), mm256_blendv_si256(MAGIC, f32, isNanInf));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtsq_sd(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 F8_NAN_INF = cvtsi64x_si128(quarter.SIGNALING_EXPONENT);
                    v128 F64_INF = RegisterConversion.ToV128(double.PositiveInfinity);
                    v128 MAGIC = cvtsi64x_si128(quarter.F64_MAGIC);
                    v128 exponentMantissa;

                    if (promiseAbsoluteAndInRange || constexpr.IS_TRUE(q.Byte0 <= quarter.MaxValue.value))
                    {
                        exponentMantissa = slli_epi64(q, quarter.F64_SHL_LOSE_SIGN - quarter.F64_SHR_PLACE_MANTISSA);

                        return mul_sd(MAGIC, exponentMantissa);
                    }

                    exponentMantissa = srli_epi64(slli_epi64(q, quarter.F64_SHL_LOSE_SIGN), quarter.F64_SHR_PLACE_MANTISSA);
                    v128 sign = slli_epi64(srli_epi64(q, quarter.BITS - 1), F64_BITS - 1);

                    if (promiseInRange)
                    {
                        return mul_sd(MAGIC, or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = cmpeq_epi64(and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f64 = ternarylogic_si128(exponentMantissa, F64_INF, isNanInf, TernaryOperation.OxF8);

                    return mul_sd(or_si128(sign, f64), blendv_si128(MAGIC, f64, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_pd(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 F8_NAN_INF = set1_epi64x(quarter.SIGNALING_EXPONENT);
                    v128 F64_INF = set1_pd(double.PositiveInfinity);
                    v128 MAGIC = set1_epi64x(quarter.F64_MAGIC);
                    v128 exponentMantissa;

                    if (promiseAbsoluteAndInRange || constexpr.ALL_LE_EPU8(q, quarter.MaxValue.value, 2))
                    {
                        exponentMantissa = slli_epi64(cvtepu8_epi64(q), quarter.F64_SHL_LOSE_SIGN - quarter.F64_SHR_PLACE_MANTISSA);

                        return mul_pd(MAGIC, exponentMantissa);
                    }

                    q = cvtepu8_epi64(q);
                    exponentMantissa = srli_epi64(slli_epi64(q, quarter.F64_SHL_LOSE_SIGN), quarter.F64_SHR_PLACE_MANTISSA);
                    v128 sign = slli_epi64(srli_epi64(q, quarter.BITS - 1), F64_BITS - 1);

                    if (promiseInRange)
                    {
                        return mul_pd(MAGIC, or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = cmpeq_epi64(and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f64 = ternarylogic_si128(exponentMantissa, F64_INF, isNanInf, TernaryOperation.OxF8);

                    return mul_pd(or_si128(sign, f64), blendv_si128(MAGIC, f64, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtpq_pd(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 F8_NAN_INF = mm256_set1_epi64x(quarter.SIGNALING_EXPONENT);
                    v256 F64_INF = mm256_set1_pd(double.PositiveInfinity);
                    v256 MAGIC = mm256_set1_epi64x(quarter.F64_MAGIC);
                    v256 exponentMantissa;

                    if (promiseAbsoluteAndInRange || constexpr.ALL_LE_EPU8(q, quarter.MaxValue.value, elements))
                    {
                        exponentMantissa = Avx2.mm256_slli_epi64(Avx2.mm256_cvtepu8_epi64(q), quarter.F64_SHL_LOSE_SIGN - quarter.F64_SHR_PLACE_MANTISSA);

                        return Avx.mm256_mul_pd(MAGIC, exponentMantissa);
                    }

                    v256 __q = Avx2.mm256_cvtepu8_epi64(q);
                    exponentMantissa = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(__q, quarter.F64_SHL_LOSE_SIGN), quarter.F64_SHR_PLACE_MANTISSA);
                    v256 sign = Avx2.mm256_slli_epi64(Avx2.mm256_srli_epi64(__q, quarter.BITS - 1), F64_BITS - 1);

                    if (promiseInRange)
                    {
                        return Avx.mm256_mul_pd(MAGIC, Avx2.mm256_or_si256(sign, exponentMantissa));
                    }

                    v256 isNanInf = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(__q, F8_NAN_INF), F8_NAN_INF);
                    v256 f64 = mm256_ternarylogic_si256(exponentMantissa, F64_INF, isNanInf, TernaryOperation.OxF8);

                    return Avx.mm256_mul_pd(Avx2.mm256_or_si256(sign, f64), Avx.mm256_blendv_pd(MAGIC, f64, isNanInf));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtph_pq(v128 h, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    const int EXPONENT_OFFSET = -F16_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v128 sign = slli_epi16(srli_epi16(h, 15), 7);
                    v128 exp = and_si128(h, set1_epi16(F16_SIGNALING_EXPONENT));
                    v128 frac = and_si128(h, set1_epi16(bitmask16((uint)F16_MANTISSA_BITS)));
                    v128 abs = and_si128(h, set1_epi16(bitmask16(F16_BITS - 1)));
                    
                    v128 denormalF8 = cmpgt_epi16(set1_epi16((EXPONENT_OFFSET << F16_MANTISSA_BITS) + 1), exp);
                    v128 overflow = cmpgt_epi16(abs, set1_epi16(((half)quarter.MaxValue).value));
                    v128 noUnderflow = cmpgt_epi16(exp, set1_epi16((ushort)(((quarter.MIN_UNBIASED_EXPONENT - quarter.MANTISSA_BITS - 1 - F16_EXPONENT_BIAS) << F16_MANTISSA_BITS) - 1)));

                    exp = sub_epi16(exp, set1_epi16(EXPONENT_OFFSET << F16_MANTISSA_BITS));

                    v128 bitIndexDenormal = sub_epi16(set1_epi16(quarter.MANTISSA_BITS - 1), abs_epi16(srai_epi16(exp, F16_MANTISSA_BITS)));
                    v128 denormalFrac = sllv_epi16(negmask_epi16(noUnderflow), bitIndexDenormal, inRange: QUARTER_CONVERSION_SHIFT_IN_RANGE, elements: elements);
                    denormalFrac = or_si128(denormalFrac, srlv_epi16(and_si128(frac, noUnderflow), sub_epi16(set1_epi16(F16_MANTISSA_BITS), bitIndexDenormal), inRange: QUARTER_CONVERSION_SHIFT_IN_RANGE, elements: elements));
                    
                    v128 normalFrac = srli_epi16(frac, F16_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    v128 roundNormal = cmpgt_epi16(and_si128(frac, set1_epi16((ushort)bitmask32((uint)(F16_MANTISSA_BITS - quarter.MANTISSA_BITS)))), setzero_si128());
                    normalFrac = sub_epi16(normalFrac, roundNormal);
                    
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                    {
                        normalFrac = andnot_si128(overflow, normalFrac);
                    }
                    else
                    {
                        v128 NaN = cmpgt_epi16(abs, set1_epi16(F16_SIGNALING_EXPONENT));
                        normalFrac = ternarylogic_si128(NaN, normalFrac, overflow, TernaryOperation.OxF4);
                    }

                    exp = andnot_si128(denormalF8, exp);
                    exp = blendv_si128(srli_epi16(exp, F16_MANTISSA_BITS - quarter.MANTISSA_BITS), set1_epi16(quarter.SIGNALING_EXPONENT), overflow);
                    frac = blendv_si128(normalFrac, denormalFrac, denormalF8);
                    
                    return cvtepi16_epi8(ternarylogic_si128(sign, exp, frac, TernaryOperation.OxFE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtps_pq(v128 s, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return BASE_OVERFLOWCTRL__cvtps_pq(s, quarter.PositiveInfinity, promiseInRange, promiseAbsoluteAndInRange, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtps_pq(v256 s, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    const int EXPONENT_OFFSET = -F32_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v256 sign = Avx2.mm256_slli_epi32(Avx2.mm256_srli_epi32(s, 31), 7);
                    v256 exp = Avx2.mm256_and_si256(s, mm256_set1_epi32(F32_SIGNALING_EXPONENT));
                    v256 frac = Avx2.mm256_and_si256(s, mm256_set1_epi32(bitmask32(F32_MANTISSA_BITS)));
                    v256 abs = Avx2.mm256_and_si256(s, mm256_set1_epi32(bitmask32(F32_BITS - 1)));
                    
                    v256 denormalF8 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32((EXPONENT_OFFSET << F32_MANTISSA_BITS) + 1), exp);
                    v256 overflow = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_ps(quarter.MaxValue));
                    v256 noUnderflow = Avx2.mm256_cmpgt_epi32(exp, mm256_set1_epi32(((quarter.MIN_UNBIASED_EXPONENT - quarter.MANTISSA_BITS - 1 - F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) - 1));

                    exp = Avx2.mm256_sub_epi32(exp, mm256_set1_epi32(EXPONENT_OFFSET << F32_MANTISSA_BITS));

                    v256 bitIndexDenormal = Avx2.mm256_sub_epi32(mm256_set1_epi32(quarter.MANTISSA_BITS - 1), Avx2.mm256_abs_epi32(Avx2.mm256_srai_epi32(exp, F32_MANTISSA_BITS)));
                    v256 denormalFrac = Avx2.mm256_sllv_epi32(mm256_negmask_epi32(noUnderflow), bitIndexDenormal);
                    denormalFrac = Avx2.mm256_or_si256(denormalFrac, Avx2.mm256_srlv_epi32(Avx2.mm256_and_si256(frac, noUnderflow), Avx2.mm256_sub_epi32(mm256_set1_epi32(F32_MANTISSA_BITS), bitIndexDenormal)));
                    
                    v256 normalFrac = Avx2.mm256_srli_epi32(frac, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    v256 roundNormal = Avx2.mm256_cmpgt_epi32(Avx2.mm256_and_si256(frac, mm256_set1_epi32(bitmask32((uint)(F32_MANTISSA_BITS - quarter.MANTISSA_BITS)))), Avx.mm256_setzero_si256());
                    normalFrac = Avx2.mm256_sub_epi32(normalFrac, roundNormal);
                    
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                    {
                        normalFrac = Avx2.mm256_andnot_si256(overflow, normalFrac);
                    }
                    else
                    {
                        v256 NaN = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(F32_SIGNALING_EXPONENT));
                        normalFrac = mm256_ternarylogic_si256(NaN, normalFrac, overflow, TernaryOperation.OxF4);
                    }

                    exp = Avx2.mm256_andnot_si256(denormalF8, exp);
                    exp = mm256_blendv_si256(Avx2.mm256_srli_epi32(exp, F32_MANTISSA_BITS - quarter.MANTISSA_BITS), mm256_set1_epi32(quarter.SIGNALING_EXPONENT), overflow);
                    frac = mm256_blendv_si256(normalFrac, denormalFrac, denormalF8);
                    
                    return mm256_cvtepi32_epi8(mm256_ternarylogic_si256(sign, exp, frac, TernaryOperation.OxFE));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpd_pq(v128 d, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v128 sign = slli_epi64(srli_epi64(d, 63), 7);
                    v128 exp = and_si128(d, set1_epi64x(F64_SIGNALING_EXPONENT));
                    v128 frac = and_si128(d, set1_epi64x(bitmask64((ulong)F64_MANTISSA_BITS)));
                    v128 abs = and_si128(d, set1_epi64x(bitmask64(F64_BITS - 1ul)));
                    
                    v128 denormalF8 = cmpgt_epi64(set1_epi64x((EXPONENT_OFFSET << F64_MANTISSA_BITS) + 1), exp);
                    v128 overflow = cmpgt_epi64(abs, set1_pd(quarter.MaxValue));
                    v128 noUnderflow = cmpgt_epi64(exp, set1_epi64x(((quarter.MIN_UNBIASED_EXPONENT - quarter.MANTISSA_BITS - 1 - F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) - 1));

                    exp = sub_epi64(exp, set1_epi64x(EXPONENT_OFFSET << F64_MANTISSA_BITS));

                    v128 bitIndexDenormal = sub_epi64(set1_epi64x(quarter.MANTISSA_BITS - 1), abs_epi64(srai_epi64(exp, F64_MANTISSA_BITS)));
                    v128 denormalFrac = sllv_epi64(negmask_epi64(noUnderflow), bitIndexDenormal, inRange: true);
                    denormalFrac = or_si128(denormalFrac, srlv_epi64(and_si128(frac, noUnderflow), sub_epi64(set1_epi64x(F64_MANTISSA_BITS), bitIndexDenormal), inRange: true));
                    
                    v128 normalFrac = srli_epi64(frac, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    v128 roundNormal = cmpgt_epi64(and_si128(frac, set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - quarter.MANTISSA_BITS)))), setzero_si128());
                    normalFrac = sub_epi64(normalFrac, roundNormal);
                    
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                    {
                        normalFrac = andnot_si128(overflow, normalFrac);
                    }
                    else
                    {
                        v128 NaN = cmpgt_epi64(abs, set1_epi64x(F64_SIGNALING_EXPONENT));
                        normalFrac = ternarylogic_si128(NaN, normalFrac, overflow, TernaryOperation.OxF4);
                    }

                    exp = andnot_si128(denormalF8, exp);
                    exp = blendv_si128(srli_epi64(exp, F64_MANTISSA_BITS - quarter.MANTISSA_BITS), set1_epi64x(quarter.SIGNALING_EXPONENT), overflow);
                    frac = blendv_si128(normalFrac, denormalFrac, denormalF8);
                    
                    return cvtepi64_epi8(ternarylogic_si128(sign, exp, frac, TernaryOperation.OxFE));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtpd_pq(v256 d, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v256 sign = Avx2.mm256_slli_epi64(Avx2.mm256_srli_epi64(d, 63), 7);
                    v256 exp = Avx2.mm256_and_si256(d, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                    v256 frac = Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)F64_MANTISSA_BITS)));
                    v256 abs = Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64(F64_BITS - 1ul)));
                    
                    v256 denormalF8 = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x((EXPONENT_OFFSET << F64_MANTISSA_BITS) + 1), exp);
                    v256 overflow = Avx2.mm256_cmpgt_epi64(abs, mm256_set1_pd(quarter.MaxValue));
                    v256 noUnderflow = Avx2.mm256_cmpgt_epi64(exp, mm256_set1_epi64x(((quarter.MIN_UNBIASED_EXPONENT - quarter.MANTISSA_BITS - 1 - F64_EXPONENT_BIAS) << F64_MANTISSA_BITS) - 1));

                    exp = Avx2.mm256_sub_epi64(exp, mm256_set1_epi64x(EXPONENT_OFFSET << F64_MANTISSA_BITS));

                    v256 bitIndexDenormal = Avx2.mm256_sub_epi64(mm256_set1_epi64x(quarter.MANTISSA_BITS - 1), mm256_abs_epi64(mm256_srai_epi64(exp, F64_MANTISSA_BITS, elements: elements)));
                    v256 denormalFrac = Avx2.mm256_sllv_epi64(mm256_negmask_epi64(noUnderflow), bitIndexDenormal);
                    denormalFrac = Avx2.mm256_or_si256(denormalFrac, Avx2.mm256_srlv_epi64(Avx2.mm256_and_si256(frac, noUnderflow), Avx2.mm256_sub_epi64(mm256_set1_epi64x(F64_MANTISSA_BITS), bitIndexDenormal)));
                    
                    v256 normalFrac = Avx2.mm256_srli_epi64(frac, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    v256 roundNormal = Avx2.mm256_cmpgt_epi64(Avx2.mm256_and_si256(frac, mm256_set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - quarter.MANTISSA_BITS)))), Avx.mm256_setzero_si256());
                    normalFrac = Avx2.mm256_sub_epi64(normalFrac, roundNormal);
                    
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                    {
                        normalFrac = Avx2.mm256_andnot_si256(overflow, normalFrac);
                    }
                    else
                    {
                        v256 NaN = Avx2.mm256_cmpgt_epi64(abs, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                        normalFrac = mm256_ternarylogic_si256(NaN, normalFrac, overflow, TernaryOperation.OxF4);
                    }

                    exp = Avx2.mm256_andnot_si256(denormalF8, exp);
                    exp = mm256_blendv_si256(Avx2.mm256_srli_epi64(exp, F64_MANTISSA_BITS - quarter.MANTISSA_BITS), mm256_set1_epi64x(quarter.SIGNALING_EXPONENT), overflow);
                    frac = mm256_blendv_si256(normalFrac, denormalFrac, denormalF8);
                    
                    return mm256_cvtepi64_epi8(mm256_ternarylogic_si256(sign, exp, frac, TernaryOperation.OxFE));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 BASE_OVERFLOWCTRL__cvtps_pq(v128 s, quarter overflowValue, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    const int EXPONENT_OFFSET = -F32_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v128 sign = slli_epi32(srli_epi32(s, 31), 7);
                    v128 exp = and_si128(s, set1_epi32(F32_SIGNALING_EXPONENT));
                    v128 frac = and_si128(s, set1_epi32(bitmask32(F32_MANTISSA_BITS)));
                    v128 abs = and_si128(s, set1_epi32(bitmask32(F32_BITS - 1)));
                    
                    v128 denormalF8 = cmpgt_epi32(set1_epi32((EXPONENT_OFFSET << F32_MANTISSA_BITS) + 1), exp);
                    v128 overflow = cmpgt_epi32(abs, set1_ps(quarter.MaxValue));
                    v128 noUnderflow = cmpgt_epi32(exp, set1_epi32(((quarter.MIN_UNBIASED_EXPONENT - quarter.MANTISSA_BITS - 1 - F32_EXPONENT_BIAS) << F32_MANTISSA_BITS) - 1));

                    exp = sub_epi32(exp, set1_epi32(EXPONENT_OFFSET << F32_MANTISSA_BITS));

                    v128 bitIndexDenormal = sub_epi32(set1_epi32(quarter.MANTISSA_BITS - 1), abs_epi32(srai_epi32(exp, F32_MANTISSA_BITS)));
                    v128 denormalFrac = sllv_epi32(negmask_epi32(noUnderflow), bitIndexDenormal, inRange: QUARTER_CONVERSION_SHIFT_IN_RANGE, elements: elements);
                    denormalFrac = or_si128(denormalFrac, srlv_epi32(and_si128(frac, noUnderflow), sub_epi32(set1_epi32(F32_MANTISSA_BITS), bitIndexDenormal), inRange: QUARTER_CONVERSION_SHIFT_IN_RANGE, elements: elements));
                    
                    v128 normalFrac = srli_epi32(frac, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    v128 roundNormal = cmpgt_epi32(and_si128(frac, set1_epi32(bitmask32((uint)(F32_MANTISSA_BITS - quarter.MANTISSA_BITS)))), setzero_si128());
                    normalFrac = sub_epi32(normalFrac, roundNormal);

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                    {
                        normalFrac = andnot_si128(overflow, normalFrac);
                    }
                    else
                    {
                        v128 NaN = cmpgt_epi32(abs, set1_epi32(F32_SIGNALING_EXPONENT));
                        normalFrac = ternarylogic_si128(NaN, normalFrac, overflow, TernaryOperation.OxF4);
                    }

                    exp = andnot_si128(denormalF8, exp);
                    exp = blendv_si128(srli_epi32(exp, F32_MANTISSA_BITS - quarter.MANTISSA_BITS), set1_epi32(overflowValue.value), overflow);
                    frac = blendv_si128(normalFrac, denormalFrac, denormalF8);
                    
                    return cvtepi32_epi8(ternarylogic_si128(sign, exp, frac, TernaryOperation.OxFE));
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
