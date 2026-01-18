//#define TESTING
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            private const bool QUARTER_FLOAT_CONVERSION_SHIFT_IN_RANGE =
// if it _IS_ out of range, it gets thrown away anyway. This is needed to turn of checks
#if TESTING
            false;
#else
            true;
#endif
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_ph(v128 q, bool promiseInRange = false, bool promiseAbs = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                    if (BurstArchitecture.IsTableLookupSupported)
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

                    if (promiseAbs)
                    {
                        return result_16;
                    }
                    else
                    {
                        v128 sign_16 = slli_epi16(srli_epi16(cvtepu8_epi16(q), quarter.BITS - 1), F16_BITS - 1);

                        return or_si128(sign_16, result_16);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtpq_ph(v128 q, bool promiseInRange = false, bool promiseAbs = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    const byte EXPONENT_OFFSET = -F16_EXPONENT_BIAS + quarter.EXPONENT_BIAS;

                    v128 exp = and_si128(q, set1_epi8(quarter.SIGNALING_EXPONENT));
                    v128 frac = and_si128(q, set1_epi8(bitmask8(quarter.MANTISSA_BITS)));

                    v128 expIs0 = cmpeq_epi8(exp, setzero_si128());
                    v256 fracIs0_16 = Avx2.mm256_cvtepi8_epi16(cmpeq_epi8(frac, setzero_si128()));
                    v256 isNaNinf_16 = Avx2.mm256_cvtepi8_epi16(cmpeq_epi8(exp, set1_epi8(quarter.SIGNALING_EXPONENT)));

                    v256 frac_16 = Avx2.mm256_cvtepu8_epi16(frac);
                    v128 shiftDistBase = sub_epi8(new v128(8, 7, 6, 6, 5, 5, 5, 5,   4, 4, 4, 4, 4, 4, 4, 4), set1_epi8(quarter.EXPONENT_BITS));
                    v256 shiftDist_16 = Avx2.mm256_cvtepu8_epi16(shuffle_epi8(shiftDistBase, frac));

                    v128 expLUT = slli_epi16(sub_epi8(set1_epi8(EXPONENT_OFFSET), shiftDistBase), F16_MANTISSA_BITS - quarter.BITS);
                    v256 denormalExp_16 = Avx2.mm256_unpacklo_epi8(Avx.mm256_setzero_si256(), Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(shuffle_epi8(expLUT, frac)), Sse.SHUFFLE(1, 1, 0, 0)));

                    denormalExp_16 = Avx2.mm256_andnot_si256(fracIs0_16, denormalExp_16);
                    v256 denormalFrac_16 = mm256_sllv_epi16(frac_16, shiftDist_16);

                    v256 normalExp_16 = Avx2.mm256_add_epi16(Avx2.mm256_cvtepu8_epi16(exp), mm256_set1_epi16(EXPONENT_OFFSET << quarter.MANTISSA_BITS));
                    normalExp_16 = Avx2.mm256_slli_epi16(normalExp_16, F16_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    if (!promiseInRange)
                    {
                        normalExp_16 = mm256_blendv_si256(normalExp_16, mm256_set1_epi16(F16_SIGNALING_EXPONENT), isNaNinf_16);
                        frac_16      = mm256_blendv_si256(frac_16,      mm256_inc_epi16(fracIs0_16),              isNaNinf_16);
                    }

                    v256 expIs0_16 = Avx2.mm256_cvtepi8_epi16(expIs0);
                    v256 result_16 = Avx2.mm256_add_epi16(mm256_blendv_si256(normalExp_16, denormalExp_16, expIs0_16), Avx2.mm256_slli_epi16(mm256_blendv_si256(frac_16, denormalFrac_16, expIs0_16), F16_MANTISSA_BITS - quarter.MANTISSA_BITS));

                    if (promiseAbs)
                    {
                        return result_16;
                    }
                    else
                    {
                        v256 sign_16 = Avx2.mm256_slli_epi16(Avx2.mm256_srli_epi16(Avx2.mm256_cvtepu8_epi16(q), quarter.BITS - 1), F16_BITS - 1);

                        return Avx2.mm256_or_si256(sign_16, result_16);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_ps(v128 q, bool promiseInRange = false, bool promiseAbs = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 F8_SIGNALING = set1_epi32(quarter.SIGNALING_EXPONENT);
                    v128 F32_SIGNALING = set1_epi32(F32_SIGNALING_EXPONENT);

                    
                    v128 q32 = cvtepu8_epi32(q);
                    v128 fusedExponentMantissa = promiseAbs ? slli_epi32(q32, quarter.F32_SHL_LOSE_SIGN - quarter.F32_SHR_PLACE_MANTISSA)
                                                            : srli_epi32(slli_epi32(q32, quarter.F32_SHL_LOSE_SIGN), quarter.F32_SHR_PLACE_MANTISSA);

                    if (promiseAbs)
                    {
                        fusedExponentMantissa = mul_ps(fusedExponentMantissa, set1_epi32(quarter.F32_MAGIC));

                        if (promiseInRange)
                        {
                            return fusedExponentMantissa;
                        }
                        else
                        {
                            v128 NaNinf = cmpeq_epi32(and_si128(q32, F8_SIGNALING), F8_SIGNALING);

                            return ternarylogic_si128(fusedExponentMantissa, NaNinf, F32_SIGNALING, TernaryOperation.OxF8);
                        }
                    }
                    else
                    {
                        if (BurstArchitecture.IsBlendSupported)
                        {
                            fusedExponentMantissa = mul_ps(fusedExponentMantissa, blendv_epi8(set1_epi32(quarter.F32_MAGIC), 
                                                                                              set1_epi32((1 << (F32_BITS - 1)) ^ quarter.F32_MAGIC), 
                                                                                              cvtepi8_epi32(q)));
                            if (promiseInRange)
                            {
                                return fusedExponentMantissa;
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi32(and_si128(q32, F8_SIGNALING), F8_SIGNALING);
                                
                                return ternarylogic_si128(fusedExponentMantissa, NaNinf, F32_SIGNALING, TernaryOperation.OxF8);
                            }
                        }
                        else
                        {
                            fusedExponentMantissa = mul_ps(fusedExponentMantissa, set1_epi32(quarter.F32_MAGIC));
                            v128 sign = slli_epi32(srli_epi32(q32, quarter.BITS - 1), F32_BITS - 1);
                            
                            if (promiseInRange)
                            {
                                return xor_ps(sign, fusedExponentMantissa);
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi32(and_si128(q32, F8_SIGNALING), F8_SIGNALING);
                                sign = ternarylogic_si128(sign, NaNinf, F32_SIGNALING, TernaryOperation.OxF8);
                                
                                return or_ps(fusedExponentMantissa, sign);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtpq_ps(v128 q, bool promiseInRange = false, bool promiseAbs = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 F8_SIGNALING = mm256_set1_epi32(quarter.SIGNALING_EXPONENT);
                    v256 F32_SIGNALING = mm256_set1_epi32(F32_SIGNALING_EXPONENT);

                    
                    v256 q32 = Avx2.mm256_cvtepu8_epi32(q);
                    v256 fusedExponentMantissa = promiseAbs ? Avx2.mm256_slli_epi32(q32, quarter.F32_SHL_LOSE_SIGN - quarter.F32_SHR_PLACE_MANTISSA)
                                                            : Avx2.mm256_srli_epi32(Avx2.mm256_slli_epi32(q32, quarter.F32_SHL_LOSE_SIGN), quarter.F32_SHR_PLACE_MANTISSA);

                    if (promiseAbs)
                    {
                        fusedExponentMantissa = Avx.mm256_mul_ps(fusedExponentMantissa, mm256_set1_epi32(quarter.F32_MAGIC));
                    }
                    else
                    {
                        fusedExponentMantissa = Avx.mm256_mul_ps(fusedExponentMantissa, Avx2.mm256_blendv_epi8(mm256_set1_epi32(quarter.F32_MAGIC), 
                                                                                                      mm256_set1_epi32((1 << (F32_BITS - 1)) ^ quarter.F32_MAGIC), 
                                                                                                      Avx2.mm256_cvtepi8_epi32(q)));
                    }

                    if (promiseInRange)
                    {
                        return fusedExponentMantissa;
                    }
                    else
                    {
                        v256 NaNinf = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(q32, F8_SIGNALING), F8_SIGNALING);
                    
                        return mm256_ternarylogic_si256(fusedExponentMantissa, NaNinf, F32_SIGNALING, TernaryOperation.OxF8);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_pd(v128 q, bool promiseInRange = false, bool promiseAbs = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 F8_SIGNALING = set1_epi64x(quarter.SIGNALING_EXPONENT);
                    v128 F64_SIGNALING = set1_epi64x(F64_SIGNALING_EXPONENT);

                    
                    v128 q64 = cvtepu8_epi64(q);
                    v128 fusedExponentMantissa = promiseAbs ? slli_epi64(q64, quarter.F64_SHL_LOSE_SIGN - quarter.F64_SHR_PLACE_MANTISSA)
                                                            : srli_epi64(slli_epi64(q64, quarter.F64_SHL_LOSE_SIGN), quarter.F64_SHR_PLACE_MANTISSA);

                    if (promiseAbs)
                    {
                        fusedExponentMantissa = mul_pd(fusedExponentMantissa, set1_epi64x(quarter.F64_MAGIC));

                        if (promiseInRange)
                        {
                            return fusedExponentMantissa;
                        }
                        else
                        {
                            v128 NaNinf = cmpeq_epi64(and_si128(q64, F8_SIGNALING), F8_SIGNALING);

                            return ternarylogic_si128(fusedExponentMantissa, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                        }
                    }
                    else
                    {
                        if (BurstArchitecture.IsBlendSupported)
                        {
                            fusedExponentMantissa = mul_pd(fusedExponentMantissa, blendv_epi8(set1_epi64x(quarter.F64_MAGIC), 
                                                                                              set1_epi64x((1ul << (F64_BITS - 1)) ^ quarter.F64_MAGIC), 
                                                                                              cvtepi8_epi64(q)));
                            if (promiseInRange)
                            {
                                return fusedExponentMantissa;
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi64(and_si128(q64, F8_SIGNALING), F8_SIGNALING);
                                
                                return ternarylogic_si128(fusedExponentMantissa, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                            }
                        }
                        else
                        {
                            fusedExponentMantissa = mul_pd(fusedExponentMantissa, set1_epi64x(quarter.F64_MAGIC));
                            v128 sign = slli_epi64(srli_epi64(q64, quarter.BITS - 1), F64_BITS - 1);
                            
                            if (promiseInRange)
                            {
                                return xor_pd(sign, fusedExponentMantissa);
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi64(and_si128(q64, F8_SIGNALING), F8_SIGNALING);
                                sign = ternarylogic_si128(sign, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                                
                                return or_pd(fusedExponentMantissa, sign);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtpq_pd(v128 q, bool promiseInRange = false, bool promiseAbs = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 F8_SIGNALING = mm256_set1_epi64x(quarter.SIGNALING_EXPONENT);
                    v256 F64_SIGNALING = mm256_set1_epi64x(F64_SIGNALING_EXPONENT);

                    
                    v256 q64 = Avx2.mm256_cvtepu8_epi64(q);
                    v256 fusedExponentMantissa = promiseAbs ? Avx2.mm256_slli_epi64(q64, quarter.F64_SHL_LOSE_SIGN - quarter.F64_SHR_PLACE_MANTISSA)
                                                            : Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(q64, quarter.F64_SHL_LOSE_SIGN), quarter.F64_SHR_PLACE_MANTISSA);

                    if (promiseAbs)
                    {
                        fusedExponentMantissa = Avx.mm256_mul_pd(fusedExponentMantissa, mm256_set1_epi64x(quarter.F64_MAGIC));
                    }
                    else
                    {
                        fusedExponentMantissa = Avx.mm256_mul_pd(fusedExponentMantissa, Avx2.mm256_blendv_epi8(mm256_set1_epi64x(quarter.F64_MAGIC), 
                                                                                                               mm256_set1_epi64x((1ul << (F64_BITS - 1)) ^ quarter.F64_MAGIC), 
                                                                                                               Avx2.mm256_cvtepi8_epi64(q)));
                    }

                    if (promiseInRange)
                    {
                        return fusedExponentMantissa;
                    }
                    else
                    {
                        v256 NaNinf = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(q64, F8_SIGNALING), F8_SIGNALING);
                        
                        return mm256_ternarylogic_si256(fusedExponentMantissa, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtph_pq(v128 h, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    //promiseInRange |= constexpr.ALL_GE_PH(h, quarter.MinValue, elements) & constexpr.ALL_LE_PH(h, quarter.MaxValue, elements);
                    //promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PH(h, 0f, elements) : constexpr.ALL_GE_PH(h, 0f, elements);

                    const int EXPONENT_OFFSET = -F16_EXPONENT_BIAS + quarter.EXPONENT_BIAS;

                    v128 sign = slli_epi16(srli_epi16(h, F16_BITS - 1), quarter.BITS - 1);
                    v128 exp = and_si128(h, set1_epi16(F16_SIGNALING_EXPONENT));
                    v128 frac = and_si128(h, set1_epi16(bitmask16((uint)F16_MANTISSA_BITS)));
                    v128 abs = and_si128(h, set1_epi16(bitmask16(F16_BITS - 1)));

                    v128 denormalF8 = cmpgt_epi16(set1_epi16((EXPONENT_OFFSET << F16_MANTISSA_BITS) + 1), exp);
                    v128 overflow = cmpgt_epi16(abs, set1_epi16(((half)quarter.MaxValue).value));
                    v128 noUnderflow = cmpgt_epi16(exp, set1_epi16(((EXPONENT_OFFSET - quarter.MANTISSA_BITS) << F16_MANTISSA_BITS) - 1));

                    exp = sub_epi16(exp, set1_epi16(EXPONENT_OFFSET << F16_MANTISSA_BITS));
                    
                    v128 bitIndexDenormal = sub_epi16(set1_epi16(quarter.MANTISSA_BITS - 1), abs_epi16(srai_epi16(exp, F16_MANTISSA_BITS)));
                    v128 denormalFrac = sllv_epi16(neg_epi16(noUnderflow), bitIndexDenormal);
                    denormalFrac = or_si128(denormalFrac, srlv_epi16(and_si128(frac, noUnderflow), sub_epi16(set1_epi16(F16_MANTISSA_BITS), bitIndexDenormal)));
                    v128 denormalRoundingBit = sllv_epi16(set1_epi16(1), sub_epi16(set1_epi16(F16_MANTISSA_BITS - 1), bitIndexDenormal));
                    v128 roundDenormal = ternarylogic_si128(noUnderflow, cmpeq_epi16(setzero_si128(), and_si128(h, denormalRoundingBit)), srai_epi16(bitIndexDenormal, 15),  TernaryOperation.OxBO);
                    denormalFrac = sub_epi16(denormalFrac, roundDenormal);
                    if (!promiseAbs)
                    {
                        denormalFrac = or_si128(denormalFrac, sign);
                    }

                    exp = srli_epi16(exp, F16_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    exp = promiseInRange ? exp : blendv_si128(exp, set1_epi16(quarter.SIGNALING_EXPONENT), overflow);
                    v128 normalFrac = srli_epi16(frac, F16_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    normalFrac = promiseAbs ? or_si128(normalFrac, exp)
                                            : ternarylogic_si128(sign, normalFrac, exp, TernaryOperation.OxFE);
                    v128 roundNormal = cmpgt_epi16(and_si128(h, set1_epi16(bitmask16(F16_MANTISSA_BITS - quarter.MANTISSA_BITS))), set1_epi16(1 << (F16_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                    normalFrac = sub_epi16(normalFrac, roundNormal);
                    
                    if (!promiseInRange)
                    {
                        if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                        {
                            normalFrac = blendv_si128(normalFrac, or_si128(set1_epi16(quarter.PositiveInfinity.value), sign), overflow);
                        }
                        else
                        {
                            v128 NaN = cmpgt_epi16(abs, set1_epi16(F16_SIGNALING_EXPONENT));
                            normalFrac = blendv_si128(normalFrac, ternarylogic_si128(sign, set1_epi16(quarter.PositiveInfinity.value), NaN, TernaryOperation.OxFE), overflow);
                        }
                    }

                    v128 result = promiseNotSubnormal ? normalFrac : blendv_si128(normalFrac, denormalFrac, denormalF8);

                    return cvtepi16_epi8(result, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtph_pq(v256 h, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    //promiseInRange |= constexpr.ALL_GE_PH(h, quarter.MinValue) & constexpr.ALL_LE_PH(h, quarter.MaxValue);
                    //promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PH(h, 0f) : constexpr.ALL_GE_PH(h, 0f);

                    const int EXPONENT_OFFSET = -F16_EXPONENT_BIAS + quarter.EXPONENT_BIAS;

                    v256 sign = Avx2.mm256_slli_epi16(Avx2.mm256_srli_epi16(h, F16_BITS - 1), quarter.BITS - 1);
                    v256 exp = Avx2.mm256_and_si256(h, mm256_set1_epi16(F16_SIGNALING_EXPONENT));
                    v256 frac = Avx2.mm256_and_si256(h, mm256_set1_epi16(bitmask16((uint)F16_MANTISSA_BITS)));
                    v256 abs = Avx2.mm256_and_si256(h, mm256_set1_epi16(bitmask16(F16_BITS - 1)));

                    v256 denormalF8 = Avx2.mm256_cmpgt_epi16(mm256_set1_epi16((EXPONENT_OFFSET << F16_MANTISSA_BITS) + 1), exp);
                    v256 overflow = Avx2.mm256_cmpgt_epi16(abs, mm256_set1_epi16(((half)quarter.MaxValue).value));
                    v256 noUnderflow = Avx2.mm256_cmpgt_epi16(exp, mm256_set1_epi16((ushort)(((EXPONENT_OFFSET - quarter.MANTISSA_BITS) << F16_MANTISSA_BITS) - 1)));

                    exp = Avx2.mm256_sub_epi16(exp, mm256_set1_epi16(EXPONENT_OFFSET << F16_MANTISSA_BITS));
                    
                    v256 bitIndexDenormal = Avx2.mm256_sub_epi16(mm256_set1_epi16(quarter.MANTISSA_BITS - 1), mm256_abs_epi16(Avx2.mm256_srai_epi16(exp, F16_MANTISSA_BITS)));
                    v256 denormalFrac = mm256_sllv_epi16(mm256_neg_epi16(noUnderflow), bitIndexDenormal);
                    denormalFrac = Avx2.mm256_or_si256(denormalFrac, mm256_srlv_epi16(Avx2.mm256_and_si256(frac, noUnderflow), Avx2.mm256_sub_epi16(mm256_set1_epi16(F16_MANTISSA_BITS), bitIndexDenormal)));
                    v256 denormalRoundingBit = mm256_sllv_epi16(mm256_set1_epi16(1), Avx2.mm256_sub_epi16(mm256_set1_epi16(F16_MANTISSA_BITS - 1), bitIndexDenormal));
                    v256 roundDenormal = mm256_ternarylogic_si256(noUnderflow, Avx2.mm256_cmpeq_epi16(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(h, denormalRoundingBit)), Avx2.mm256_srai_epi16(bitIndexDenormal, 15),  TernaryOperation.OxBO);
                    denormalFrac = Avx2.mm256_sub_epi16(denormalFrac, roundDenormal);
                    if (!promiseAbs)
                    {
                        denormalFrac = Avx2.mm256_or_si256(denormalFrac, sign);
                    }

                    exp = mm256_srli_epi16(exp, F16_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    exp = promiseInRange ? exp : mm256_blendv_si256(exp, mm256_set1_epi16(quarter.SIGNALING_EXPONENT), overflow);
                    v256 normalFrac = Avx2.mm256_srli_epi16(frac, F16_MANTISSA_BITS - quarter.MANTISSA_BITS);
                    normalFrac = promiseAbs ? Avx2.mm256_or_si256(normalFrac, exp)
                                            : mm256_ternarylogic_si256(sign, normalFrac, exp, TernaryOperation.OxFE);
                    v256 roundNormal = Avx2.mm256_cmpgt_epi16(Avx2.mm256_and_si256(h, mm256_set1_epi16(bitmask16(F16_MANTISSA_BITS - quarter.MANTISSA_BITS))), mm256_set1_epi16(1 << (F16_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                    normalFrac = Avx2.mm256_sub_epi16(normalFrac, roundNormal);
                    
                    if (!promiseInRange)
                    {
                        if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                        {
                            normalFrac = mm256_blendv_si256(normalFrac, Avx2.mm256_or_si256(mm256_set1_epi16(quarter.PositiveInfinity.value), sign), overflow);
                        }
                        else
                        {
                            v256 NaN = Avx2.mm256_cmpgt_epi16(abs, mm256_set1_epi16(F16_SIGNALING_EXPONENT));
                            normalFrac = mm256_blendv_si256(normalFrac, mm256_ternarylogic_si256(sign, mm256_set1_epi16(quarter.PositiveInfinity.value), NaN, TernaryOperation.OxFE), overflow);
                        }
                    }

                    v256 result = promiseNotSubnormal ? normalFrac : mm256_blendv_si256(normalFrac, denormalFrac, denormalF8);

                    return mm256_cvtepi16_epi8(result);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtps_pq(v128 s, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return BASE_OVERFLOWCTRL__cvtps_pq(s, quarter.PositiveInfinity, promiseInRange, promiseAbs, promiseNotSubnormal, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtps_pq(v256 s, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseInRange |= constexpr.ALL_GE_PS(s, quarter.MinValue) & constexpr.ALL_LE_PS(s, quarter.MaxValue);
                    promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PS(s, 0f) : constexpr.ALL_GE_PS(s, 0f);
                    
                    const int EXPONENT_OFFSET = -F32_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v256 exp = Avx2.mm256_and_si256(s, mm256_set1_epi32(F32_SIGNALING_EXPONENT));
                    v256 noUnderflow = Avx2.mm256_cmpgt_epi32(exp, mm256_set1_epi32(((EXPONENT_OFFSET - quarter.MANTISSA_BITS) << F32_MANTISSA_BITS) - 1));
                    
                    if (promiseInRange && promiseNotSubnormal)
                    {
                        v256 inRange = Avx.mm256_mul_ps(s, mm256_set1_ps(1f / math.asfloat(quarter.F32_MAGIC)));
                        v256 aligned = mm256_srli_epi32(inRange, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        if (!promiseAbs)
                        {
                            v256 sign32 = mm256_slli_epi32(mm256_srli_epi32(s, F32_BITS - 1), quarter.BITS - 1);
                            aligned = Avx2.mm256_xor_si256(aligned, sign32);
                        }
                        
                        v256 round = Avx2.mm256_cmpgt_epi32(Avx2.mm256_and_si256(s, mm256_set1_epi32(bitmask32(F32_MANTISSA_BITS - quarter.MANTISSA_BITS))), mm256_set1_epi32(1 << (F32_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        round = Avx2.mm256_and_si256(noUnderflow, round);
                        aligned = Avx2.mm256_sub_epi32(aligned, round);
                        
                        return mm256_cvtepi32_epi8(aligned);
                    }
                    else
                    {
                        v256 sign = Avx2.mm256_slli_epi32(Avx2.mm256_srli_epi32(s, F32_BITS - 1), quarter.BITS - 1);
                        v256 frac = Avx2.mm256_and_si256(s, mm256_set1_epi32(bitmask32(F32_MANTISSA_BITS)));
                        v256 abs = Avx2.mm256_and_si256(s, mm256_set1_epi32(bitmask32(F32_BITS - 1)));
                        
                        v256 denormalF8 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32((EXPONENT_OFFSET << F32_MANTISSA_BITS) + 1), exp);
                        v256 overflow = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_ps(quarter.MaxValue));
                        
                        exp = Avx2.mm256_sub_epi32(exp, mm256_set1_epi32(EXPONENT_OFFSET << F32_MANTISSA_BITS));
                        
                        v256 bitIndexDenormal = Avx2.mm256_sub_epi32(mm256_set1_epi32(quarter.MANTISSA_BITS - 1), mm256_abs_epi32(Avx2.mm256_srai_epi32(exp, F32_MANTISSA_BITS)));
                        v256 denormalFrac = Avx2.mm256_sllv_epi32(mm256_neg_epi32(noUnderflow), bitIndexDenormal);
                        denormalFrac = Avx2.mm256_or_si256(denormalFrac, Avx2.mm256_srlv_epi32(Avx2.mm256_and_si256(frac, noUnderflow), Avx2.mm256_sub_epi32(mm256_set1_epi32(F32_MANTISSA_BITS), bitIndexDenormal)));
                        v256 denormalRoundingBit = Avx2.mm256_sllv_epi32(mm256_set1_epi32(1), Avx2.mm256_sub_epi32(mm256_set1_epi32(F32_MANTISSA_BITS - 1), bitIndexDenormal));
                        v256 roundDenormal = mm256_ternarylogic_si256(noUnderflow, Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(s, denormalRoundingBit)), Avx2.mm256_srai_epi32(bitIndexDenormal, 31),  TernaryOperation.OxBO);
                        denormalFrac = Avx2.mm256_sub_epi32(denormalFrac, roundDenormal);
                        if (!promiseAbs)
                        {
                            denormalFrac = Avx2.mm256_or_si256(denormalFrac, sign);
                        }

                        exp = Avx2.mm256_srli_epi32(exp, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        exp = promiseInRange ? exp : mm256_blendv_si256(exp, mm256_set1_epi32(quarter.SIGNALING_EXPONENT), overflow);
                        v256 normalFrac = Avx2.mm256_srli_epi32(frac, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        normalFrac = promiseAbs ? Avx2.mm256_or_si256(normalFrac, exp)
                                                : mm256_ternarylogic_si256(sign, normalFrac, exp, TernaryOperation.OxFE);
                        v256 roundNormal = Avx2.mm256_cmpgt_epi32(Avx2.mm256_and_si256(s, mm256_set1_epi32(bitmask32(F32_MANTISSA_BITS - quarter.MANTISSA_BITS))), mm256_set1_epi32(1 << (F32_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        normalFrac = Avx2.mm256_sub_epi32(normalFrac, roundNormal);
                        
                        if (!promiseInRange)
                        {
                            if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                            {
                                normalFrac = mm256_blendv_si256(normalFrac, Avx2.mm256_or_si256(mm256_set1_epi32(quarter.PositiveInfinity.value), sign), overflow);
                            }
                            else
                            {
                                v256 NaN = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(F32_SIGNALING_EXPONENT));
                                normalFrac = mm256_blendv_si256(normalFrac, mm256_ternarylogic_si256(sign, mm256_set1_epi32(quarter.PositiveInfinity.value), NaN, TernaryOperation.OxFE), overflow);
                            }
                        }

                        v256 result = promiseNotSubnormal ? normalFrac : mm256_blendv_si256(normalFrac, denormalFrac, denormalF8);

                        return mm256_cvtepi32_epi8(result);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpd_pq(v128 d, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseInRange |= constexpr.ALL_GE_PD(d, quarter.MinValue) & constexpr.ALL_LE_PD(d, quarter.MaxValue);
                    promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PD(d, 0d) : constexpr.ALL_GE_PD(d, 0d);
                    
                    const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v128 exp = and_si128(d, set1_epi64x(F64_SIGNALING_EXPONENT));
                    v128 noUnderflow = cmpgt_epi64(exp, set1_epi64x(((ulong)(EXPONENT_OFFSET - quarter.MANTISSA_BITS) << F64_MANTISSA_BITS) - 1));
                    
                    if (promiseInRange && promiseNotSubnormal)
                    {
                        v128 inRange = mul_pd(d, set1_pd(1f / math.asdouble(quarter.F64_MAGIC)));
                        v128 aligned = srli_epi64(inRange, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        if (!promiseAbs)
                        {
                            v128 sign64 = slli_epi64(srli_epi64(d, F64_BITS - 1), quarter.BITS - 1);
                            aligned = xor_si128(aligned, sign64);
                        }
                        
                        v128 round = cmpgt_epi64(and_si128(d, set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - quarter.MANTISSA_BITS)))), set1_epi64x(1ul << (F64_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        round = and_si128(noUnderflow, round);
                        aligned = sub_epi64(aligned, round);
                        
                        return cvtepi64_epi8(aligned);
                    }
                    else
                    {
                        v128 sign = slli_epi64(srli_epi64(d, F64_BITS - 1), quarter.BITS - 1);
                        v128 frac = and_si128(d, set1_epi64x(bitmask64((ulong)F64_MANTISSA_BITS)));
                        v128 abs = and_si128(d, set1_epi64x(bitmask64((ulong)(F64_BITS - 1))));
                        
                        v128 denormalF8 = cmpgt_epi64(set1_epi64x(((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS) + 1), exp);
                        v128 overflow = cmpgt_epi64(abs, set1_pd(quarter.MaxValue));
                        
                        exp = sub_epi64(exp, set1_epi64x((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS));
                        
                        v128 bitIndexDenormal = sub_epi64(set1_epi64x(quarter.MANTISSA_BITS - 1), abs_epi64(srai_epi64(exp, F64_MANTISSA_BITS)));
                        v128 denormalFrac = sllv_epi64(neg_epi64(noUnderflow), bitIndexDenormal);
                        denormalFrac = or_si128(denormalFrac, srlv_epi64(and_si128(frac, noUnderflow), sub_epi64(set1_epi64x(F64_MANTISSA_BITS), bitIndexDenormal)));
                        v128 denormalRoundingBit = sllv_epi64(set1_epi64x(1), sub_epi64(set1_epi64x(F64_MANTISSA_BITS - 1), bitIndexDenormal));
                        v128 roundDenormal = ternarylogic_si128(noUnderflow, cmpeq_epi64(setzero_si128(), and_si128(d, denormalRoundingBit)), srai_epi64(bitIndexDenormal, 63),  TernaryOperation.OxBO);
                        denormalFrac = sub_epi64(denormalFrac, roundDenormal);
                        if (!promiseAbs)
                        {
                            denormalFrac = or_si128(denormalFrac, sign);
                        }

                        exp = srli_epi64(exp, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        exp = promiseInRange ? exp : blendv_si128(exp, set1_epi64x(quarter.SIGNALING_EXPONENT), overflow);
                        v128 normalFrac = srli_epi64(frac, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        normalFrac = promiseAbs ? or_si128(normalFrac, exp)
                                                : ternarylogic_si128(sign, normalFrac, exp, TernaryOperation.OxFE);
                        v128 roundNormal = cmpgt_epi64(and_si128(d, set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - quarter.MANTISSA_BITS)))), set1_epi64x(1ul << (F64_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        normalFrac = sub_epi64(normalFrac, roundNormal);
                        
                        if (!promiseInRange)
                        {
                            if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                            {
                                normalFrac = blendv_si128(normalFrac, or_si128(set1_epi64x(quarter.PositiveInfinity.value), sign), overflow);
                            }
                            else
                            {
                                v128 NaN = cmpgt_epi64(abs, set1_epi64x(F64_SIGNALING_EXPONENT));
                                normalFrac = blendv_si128(normalFrac, ternarylogic_si128(sign, set1_epi64x(quarter.PositiveInfinity.value), NaN, TernaryOperation.OxFE), overflow);
                            }
                        }

                        v128 result = promiseNotSubnormal ? normalFrac : blendv_si128(normalFrac, denormalFrac, denormalF8);

                        return cvtepi64_epi8(result);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtpd_pq(v256 d, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseInRange |= constexpr.ALL_GE_PD(d, quarter.MinValue, elements) & constexpr.ALL_LE_PD(d, quarter.MaxValue, elements);
                    promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PD(d, 0d, elements) : constexpr.ALL_GE_PD(d, 0d, elements);
                    
                    const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + quarter.EXPONENT_BIAS;

                    v256 exp = Avx2.mm256_and_si256(d, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                    v256 noUnderflow = mm256_cmpgt_epi64(exp, mm256_set1_epi64x(((ulong)(EXPONENT_OFFSET - quarter.MANTISSA_BITS) << F64_MANTISSA_BITS) - 1));
                    
                    if (promiseInRange && promiseNotSubnormal)
                    {
                        v256 inRange = Avx.mm256_mul_pd(d, mm256_set1_pd(1d / math.asdouble(quarter.F64_MAGIC)));
                        v256 aligned = mm256_srli_epi64(inRange, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        if (!promiseAbs)
                        {
                            v256 sign64 = mm256_slli_epi64(mm256_srli_epi64(d, F64_BITS - 1), quarter.BITS - 1);
                            aligned = Avx2.mm256_xor_si256(aligned, sign64);
                        }
                        
                        v256 round = mm256_cmpgt_epi64(Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - quarter.MANTISSA_BITS)))), mm256_set1_epi64x(1 << (F64_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        round = Avx2.mm256_and_si256(noUnderflow, round);
                        aligned = Avx2.mm256_sub_epi64(aligned, round);
                        
                        return mm256_cvtepi64_epi8(aligned);
                    }
                    else
                    {
                        v256 sign = Avx2.mm256_slli_epi64(Avx2.mm256_srli_epi64(d, F64_BITS - 1), quarter.BITS - 1);
                        v256 frac = Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)F64_MANTISSA_BITS)));
                        v256 abs = Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)F64_BITS - 1)));
                        
                        v256 denormalF8 = mm256_cmpgt_epi64(mm256_set1_epi64x(((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS) + 1), exp);
                        v256 overflow = mm256_cmpgt_epi64(abs, mm256_set1_pd(quarter.MaxValue));
                        
                        exp = Avx2.mm256_sub_epi64(exp, mm256_set1_epi64x((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS));
                        
                        v256 bitIndexDenormal = Avx2.mm256_sub_epi64(mm256_set1_epi64x(quarter.MANTISSA_BITS - 1), mm256_abs_epi64(mm256_srai_epi64(exp, F64_MANTISSA_BITS)));
                        v256 denormalFrac = Avx2.mm256_sllv_epi64(mm256_neg_epi64(noUnderflow), bitIndexDenormal);
                        denormalFrac = Avx2.mm256_or_si256(denormalFrac, Avx2.mm256_srlv_epi64(Avx2.mm256_and_si256(frac, noUnderflow), Avx2.mm256_sub_epi64(mm256_set1_epi64x(F64_MANTISSA_BITS), bitIndexDenormal)));
                        v256 denormalRoundingBit = Avx2.mm256_sllv_epi64(mm256_set1_epi64x(1), Avx2.mm256_sub_epi64(mm256_set1_epi64x(F64_MANTISSA_BITS - 1), bitIndexDenormal));
                        v256 roundDenormal = mm256_ternarylogic_si256(noUnderflow, Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(d, denormalRoundingBit)), mm256_srai_epi64(bitIndexDenormal, 63),  TernaryOperation.OxBO);
                        denormalFrac = Avx2.mm256_sub_epi64(denormalFrac, roundDenormal);
                        if (!promiseAbs)
                        {
                            denormalFrac = Avx2.mm256_or_si256(denormalFrac, sign);
                        }

                        exp = Avx2.mm256_srli_epi64(exp, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        exp = promiseInRange ? exp : mm256_blendv_si256(exp, mm256_set1_epi64x(quarter.SIGNALING_EXPONENT), overflow);
                        v256 normalFrac = Avx2.mm256_srli_epi64(frac, F64_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        normalFrac = promiseAbs ? Avx2.mm256_or_si256(normalFrac, exp)
                                                : mm256_ternarylogic_si256(sign, normalFrac, exp, TernaryOperation.OxFE);
                        v256 roundNormal = mm256_cmpgt_epi64(Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - quarter.MANTISSA_BITS)))), mm256_set1_epi64x(1ul << (F64_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        normalFrac = Avx2.mm256_sub_epi64(normalFrac, roundNormal);
                        
                        if (!promiseInRange)
                        {
                            if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                            {
                                normalFrac = mm256_blendv_si256(normalFrac, Avx2.mm256_or_si256(mm256_set1_epi64x(quarter.PositiveInfinity.value), sign), overflow);
                            }
                            else
                            {
                                v256 NaN = mm256_cmpgt_epi64(abs, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                                normalFrac = mm256_blendv_si256(normalFrac, mm256_ternarylogic_si256(sign, mm256_set1_epi64x(quarter.PositiveInfinity.value), NaN, TernaryOperation.OxFE), overflow);
                            }
                        }

                        v256 result = promiseNotSubnormal ? normalFrac : mm256_blendv_si256(normalFrac, denormalFrac, denormalF8);

                        return mm256_cvtepi64_epi8(result);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 BASE_OVERFLOWCTRL__cvtps_pq(v128 s, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseInRange |= constexpr.ALL_GE_PS(s, quarter.MinValue, elements) & constexpr.ALL_LE_PS(s, quarter.MaxValue, elements);
                    promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PS(s, 0f, elements) : constexpr.ALL_GE_PS(s, 0f, elements);
                    
                    const int EXPONENT_OFFSET = -F32_EXPONENT_BIAS + quarter.EXPONENT_BIAS;
                    
                    v128 exp = and_si128(s, set1_epi32(F32_SIGNALING_EXPONENT));
                    v128 noUnderflow = cmpgt_epi32(exp, set1_epi32(((EXPONENT_OFFSET - quarter.MANTISSA_BITS) << F32_MANTISSA_BITS) - 1));
                    
                    if (promiseInRange && promiseNotSubnormal)
                    {
                        v128 inRange = mul_ps(s, set1_ps(1f / math.asfloat(quarter.F32_MAGIC)));
                        v128 aligned = srli_epi32(inRange, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        if (!promiseAbs)
                        {
                            v128 sign32 = slli_epi32(srli_epi32(s, F32_BITS - 1), quarter.BITS - 1);
                            aligned = xor_si128(aligned, sign32);
                        }
                        
                        v128 round = cmpgt_epi32(and_si128(s, set1_epi32(bitmask32(F32_MANTISSA_BITS - quarter.MANTISSA_BITS))), set1_epi32(1 << (F32_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        round = and_si128(noUnderflow, round);
                        aligned = sub_epi32(aligned, round);
                        
                        return cvtepi32_epi8(aligned, elements);
                    }
                    else
                    {
                        v128 sign = slli_epi32(srli_epi32(s, F32_BITS - 1), quarter.BITS - 1);
                        v128 frac = and_si128(s, set1_epi32(bitmask32(F32_MANTISSA_BITS)));
                        v128 abs = and_si128(s, set1_epi32(bitmask32(F32_BITS - 1)));
                        
                        v128 denormalF8 = cmpgt_epi32(set1_epi32((EXPONENT_OFFSET << F32_MANTISSA_BITS) + 1), exp);
                        v128 overflow = cmpgt_epi32(abs, set1_ps(quarter.MaxValue));
                        
                        exp = sub_epi32(exp, set1_epi32(EXPONENT_OFFSET << F32_MANTISSA_BITS));
                        
                        v128 bitIndexDenormal = sub_epi32(set1_epi32(quarter.MANTISSA_BITS - 1), abs_epi32(srai_epi32(exp, F32_MANTISSA_BITS)));
                        v128 denormalFrac = sllv_epi32(neg_epi32(noUnderflow), bitIndexDenormal);
                        denormalFrac = or_si128(denormalFrac, srlv_epi32(and_si128(frac, noUnderflow), sub_epi32(set1_epi32(F32_MANTISSA_BITS), bitIndexDenormal)));
                        v128 denormalRoundingBit = sllv_epi32(set1_epi32(1), sub_epi32(set1_epi32(F32_MANTISSA_BITS - 1), bitIndexDenormal));
                        v128 roundDenormal = ternarylogic_si128(noUnderflow, cmpeq_epi32(setzero_si128(), and_si128(s, denormalRoundingBit)), srai_epi32(bitIndexDenormal, 31),  TernaryOperation.OxBO);
                        denormalFrac = sub_epi32(denormalFrac, roundDenormal);
                        if (!promiseAbs)
                        {
                            denormalFrac = or_si128(denormalFrac, sign);
                        }
                        
                        exp = srli_epi32(exp, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        v128 normalFrac = srli_epi32(frac, F32_MANTISSA_BITS - quarter.MANTISSA_BITS);
                        normalFrac = promiseAbs ? or_si128(normalFrac, exp)
                                                : ternarylogic_si128(sign, normalFrac, exp, TernaryOperation.OxFE);
                        v128 roundNormal = cmpgt_epi32(and_si128(s, set1_epi32(bitmask32(F32_MANTISSA_BITS - quarter.MANTISSA_BITS))), set1_epi32(1 << (F32_MANTISSA_BITS - quarter.MANTISSA_BITS - 1)));
                        normalFrac = sub_epi32(normalFrac, roundNormal);
                        
                        if (!promiseInRange)
                        {
                            if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                            {
                                normalFrac = blendv_si128(normalFrac, or_si128(set1_epi32(overflowValue.value), sign), overflow);
                            }
                            else
                            {
                                v128 NaN = cmpgt_epi32(abs, set1_epi32(F32_SIGNALING_EXPONENT));
                                normalFrac = blendv_si128(normalFrac, ternarylogic_si128(sign, set1_epi32(overflowValue.value), NaN, TernaryOperation.OxFE), overflow);
                            }
                        }

                        v128 result = promiseNotSubnormal ? normalFrac : blendv_si128(normalFrac, denormalFrac, denormalF8);
                        
                        return cvtepi32_epi8(result, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtph_ps(v128 h, bool promiseInRange = false, bool promiseAbs = false, byte elements = 4)
            {
                if (F16C.IsF16CSupported)
                {
                    return F16C.cvtph_ps(h);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 F16_SIGNALING = set1_epi32(HalfExtensions.SIGNALING_EXPONENT);
                    v128 F32_SIGNALING = set1_epi32(F32_SIGNALING_EXPONENT);

                    
                    v128 q32 = cvtepu16_epi32(h);
                    v128 fusedExponentMantissa = promiseAbs ? slli_epi32(q32, HalfExtensions.F32_SHL_LOSE_SIGN - HalfExtensions.F32_SHR_PLACE_MANTISSA)
                                                            : srli_epi32(slli_epi32(q32, HalfExtensions.F32_SHL_LOSE_SIGN), HalfExtensions.F32_SHR_PLACE_MANTISSA);

                    if (promiseAbs)
                    {
                        fusedExponentMantissa = mul_ps(fusedExponentMantissa, set1_epi32(HalfExtensions.F32_MAGIC));

                        if (promiseInRange)
                        {
                            return fusedExponentMantissa;
                        }
                        else
                        {
                            v128 NaNinf = cmpeq_epi32(and_si128(q32, F16_SIGNALING), F16_SIGNALING);

                            return ternarylogic_si128(fusedExponentMantissa, NaNinf, F32_SIGNALING, TernaryOperation.OxF8);
                        }
                    }
                    else
                    {
                        if (BurstArchitecture.IsBlendSupported)
                        {
                            fusedExponentMantissa = mul_ps(fusedExponentMantissa, blendv_si128(set1_epi32(HalfExtensions.F32_MAGIC), 
                                                                                               set1_epi32((1 << (F32_BITS - 1)) ^ HalfExtensions.F32_MAGIC), 
                                                                                               cvtepi16_epi32(srai_epi16(h, HalfExtensions.BITS - 1))));
                            if (promiseInRange)
                            {
                                return fusedExponentMantissa;
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi32(and_si128(q32, F16_SIGNALING), F16_SIGNALING);
                                
                                return ternarylogic_si128(fusedExponentMantissa, NaNinf, F32_SIGNALING, TernaryOperation.OxF8);
                            }
                        }
                        else
                        {
                            fusedExponentMantissa = mul_ps(fusedExponentMantissa, set1_epi32(HalfExtensions.F32_MAGIC));
                            v128 sign = slli_epi32(srli_epi32(q32, HalfExtensions.BITS - 1), F32_BITS - 1);
                            
                            if (promiseInRange)
                            {
                                return xor_ps(sign, fusedExponentMantissa);
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi32(and_si128(q32, F16_SIGNALING), F16_SIGNALING);
                                sign = ternarylogic_si128(sign, NaNinf, F32_SIGNALING, TernaryOperation.OxF8);
                                
                                return or_ps(fusedExponentMantissa, sign);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtph_ps(v128 h)
            {
                if (F16C.IsF16CSupported)
                {
                    return F16C.mm256_cvtph_ps(h);
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtph_pd(v128 h, bool promiseInRange = false, bool promiseAbs = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            return cvtps_pd(cvtph_ps(h));
                        }
                    }

                    v128 F16_SIGNALING = set1_epi64x(HalfExtensions.SIGNALING_EXPONENT);
                    v128 F64_SIGNALING = set1_epi64x(F64_SIGNALING_EXPONENT);

                    
                    v128 q64 = cvtepu16_epi64(h);
                    v128 fusedExponentMantissa = promiseAbs ? slli_epi64(q64, HalfExtensions.F64_SHL_LOSE_SIGN - HalfExtensions.F64_SHR_PLACE_MANTISSA)
                                                            : srli_epi64(slli_epi64(q64, HalfExtensions.F64_SHL_LOSE_SIGN), HalfExtensions.F64_SHR_PLACE_MANTISSA);

                    if (promiseAbs)
                    {
                        fusedExponentMantissa = mul_pd(fusedExponentMantissa, set1_epi64x(HalfExtensions.F64_MAGIC));

                        if (promiseInRange)
                        {
                            return fusedExponentMantissa;
                        }
                        else
                        {
                            v128 NaNinf = cmpeq_epi64(and_si128(q64, F16_SIGNALING), F16_SIGNALING);

                            return ternarylogic_si128(fusedExponentMantissa, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                        }
                    }
                    else
                    {
                        if (BurstArchitecture.IsBlendSupported)
                        {
                            fusedExponentMantissa = mul_pd(fusedExponentMantissa, blendv_si128(set1_epi64x(HalfExtensions.F64_MAGIC), 
                                                                                               set1_epi64x((1ul << (F64_BITS - 1)) ^ HalfExtensions.F64_MAGIC), 
                                                                                               cvtepi16_epi64(srai_epi16(h, HalfExtensions.BITS - 1))));
                            if (promiseInRange)
                            {
                                return fusedExponentMantissa;
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi64(and_si128(q64, F16_SIGNALING), F16_SIGNALING);
                                
                                return ternarylogic_si128(fusedExponentMantissa, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                            }
                        }
                        else
                        {
                            fusedExponentMantissa = mul_pd(fusedExponentMantissa, set1_epi64x(HalfExtensions.F64_MAGIC));
                            v128 sign = slli_epi64(srli_epi64(q64, HalfExtensions.BITS - 1), F64_BITS - 1);
                            
                            if (promiseInRange)
                            {
                                return xor_pd(sign, fusedExponentMantissa);
                            }
                            else
                            {
                                v128 NaNinf = cmpeq_epi64(and_si128(q64, F16_SIGNALING), F16_SIGNALING);
                                sign = ternarylogic_si128(sign, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                                
                                return or_pd(fusedExponentMantissa, sign);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtph_pd(v128 h, bool promiseInRange = false, bool promiseAbs = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return Avx.mm256_cvtps_pd(cvtph_ps(h));
                    }

                    v256 F16_SIGNALING = mm256_set1_epi64x(HalfExtensions.SIGNALING_EXPONENT);
                    v256 F64_SIGNALING = mm256_set1_epi64x(F64_SIGNALING_EXPONENT);

                    
                    v256 q64 = Avx2.mm256_cvtepu16_epi64(h);
                    v256 fusedExponentMantissa = promiseAbs ? mm256_slli_epi64(q64, HalfExtensions.F64_SHL_LOSE_SIGN - HalfExtensions.F64_SHR_PLACE_MANTISSA)
                                                            : mm256_srli_epi64(mm256_slli_epi64(q64, HalfExtensions.F64_SHL_LOSE_SIGN), HalfExtensions.F64_SHR_PLACE_MANTISSA);

                    if (promiseAbs)
                    {
                        fusedExponentMantissa = Avx.mm256_mul_pd(fusedExponentMantissa, mm256_set1_epi64x(HalfExtensions.F64_MAGIC));
                    }
                    else
                    {
                        fusedExponentMantissa = Avx.mm256_mul_pd(fusedExponentMantissa, mm256_blendv_si256(mm256_set1_epi64x(HalfExtensions.F64_MAGIC), 
                                                                                                           mm256_set1_epi64x((1ul << (F64_BITS - 1)) ^ HalfExtensions.F64_MAGIC), 
                                                                                                           Avx2.mm256_cvtepi16_epi64(srai_epi16(h, HalfExtensions.BITS - 1))));
                    }

                    if (promiseInRange)
                    {
                        return fusedExponentMantissa;
                    }
                    else
                    {
                        v256 NaNinf = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(q64, F16_SIGNALING), F16_SIGNALING);

                        return mm256_ternarylogic_si256(fusedExponentMantissa, NaNinf, F64_SIGNALING, TernaryOperation.OxF8);
                    }
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtps_ph(v128 s, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false, byte elements = 4)
            {
                if (F16C.IsF16CSupported)
                {
                    return F16C.cvtps_ph(s, (int)RoundingMode.FROUND_NINT_NOEXC);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseInRange |= constexpr.ALL_GE_PS(s, Unity.Mathematics.half.MinValue, elements) & constexpr.ALL_LE_PS(s, Unity.Mathematics.half.MaxValue, elements);
                    promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PS(s, 0f, elements) : constexpr.ALL_GE_PS(s, 0f, elements);
                    
                    const int EXPONENT_OFFSET = -F32_EXPONENT_BIAS + HalfExtensions.EXPONENT_BIAS;
                    
                    v128 exp = and_si128(s, set1_epi32(F32_SIGNALING_EXPONENT));
                    v128 noUnderflow = cmpgt_epi32(exp, set1_epi32(((EXPONENT_OFFSET - HalfExtensions.MANTISSA_BITS) << F32_MANTISSA_BITS) - 1));
                    
                    if (promiseInRange && promiseNotSubnormal)
                    {
                        v128 inRange = mul_ps(s, set1_ps(1f / math.asfloat(HalfExtensions.F32_MAGIC)));
                        v128 aligned = srli_epi32(inRange, F32_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        if (!promiseAbs)
                        {
                            v128 sign32 = slli_epi32(srli_epi32(s, F32_BITS - 1), HalfExtensions.BITS - 1);
                            aligned = xor_si128(aligned, sign32);
                        }
                        
                        v128 round = cmpgt_epi32(and_si128(s, set1_epi32(bitmask32(F32_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS))), set1_epi32(1 << (F32_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS - 1)));
                        round = and_si128(noUnderflow, round);
                        aligned = sub_epi32(aligned, round);
                        
                        return cvtepi32_epi16(aligned, elements);
                    }
                    else
                    {
                        v128 sign = slli_epi32(srli_epi32(s, F32_BITS - 1), HalfExtensions.BITS - 1);
                        v128 frac = and_si128(s, set1_epi32(bitmask32(F32_MANTISSA_BITS)));
                        v128 abs = and_si128(s, set1_epi32(bitmask32(F32_BITS - 1)));
                        
                        v128 denormalF8 = cmpgt_epi32(set1_epi32((EXPONENT_OFFSET << F32_MANTISSA_BITS) + 1), exp);
                        v128 overflow = cmpgt_epi32(abs, set1_ps(Unity.Mathematics.half.MaxValue));
                        
                        exp = sub_epi32(exp, set1_epi32(EXPONENT_OFFSET << F32_MANTISSA_BITS));
                        
                        v128 bitIndexDenormal = sub_epi32(set1_epi32(HalfExtensions.MANTISSA_BITS - 1), abs_epi32(srai_epi32(exp, F32_MANTISSA_BITS)));
                        v128 denormalFrac = sllv_epi32(neg_epi32(noUnderflow), bitIndexDenormal);
                        denormalFrac = or_si128(denormalFrac, srlv_epi32(and_si128(frac, noUnderflow), sub_epi32(set1_epi32(F32_MANTISSA_BITS), bitIndexDenormal)));
                        v128 denormalRoundingBit = sllv_epi32(set1_epi32(1), sub_epi32(set1_epi32(F32_MANTISSA_BITS - 1), bitIndexDenormal));
                        v128 roundDenormal = ternarylogic_si128(noUnderflow, cmpeq_epi32(setzero_si128(), and_si128(s, denormalRoundingBit)), srai_epi32(bitIndexDenormal, 31),  TernaryOperation.OxBO);
                        denormalFrac = sub_epi32(denormalFrac, roundDenormal);
                        if (!promiseAbs)
                        {
                            denormalFrac = or_si128(denormalFrac, sign);
                        }
                        
                        exp = srli_epi32(exp, F32_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        exp = promiseInRange ? exp : blendv_si128(exp, set1_epi32(HalfExtensions.SIGNALING_EXPONENT), overflow);
                        v128 normalFrac = srli_epi32(frac, F32_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);

                        normalFrac = promiseAbs ? or_si128(normalFrac, exp)
                                                : ternarylogic_si128(sign, normalFrac, exp, TernaryOperation.OxFE);
                        v128 roundNormal = cmpgt_epi32(and_si128(s, set1_epi32(bitmask32(F32_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS))), set1_epi32(1 << (F32_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS - 1)));
                        normalFrac = sub_epi32(normalFrac, roundNormal);
                        
                        if (!promiseInRange)
                        {
                            if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                            {
                                normalFrac = blendv_si128(normalFrac, or_si128(set1_epi32(((half)float.PositiveInfinity).value), sign), overflow);
                            }
                            else
                            {
                                v128 NaN = cmpgt_epi32(abs, set1_epi32(F32_SIGNALING_EXPONENT));
                                normalFrac = blendv_si128(normalFrac, ternarylogic_si128(sign, set1_epi32(((half)float.PositiveInfinity).value), NaN, TernaryOperation.OxFE), overflow);
                            }
                        }

                        v128 result = promiseNotSubnormal ? normalFrac : blendv_si128(normalFrac, denormalFrac, denormalF8);

                        return cvtepi32_epi16(result, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtps_ph(v256 s)
            {
                if (F16C.IsF16CSupported)
                {
                    return F16C.mm256_cvtps_ph(s, (int)RoundingMode.FROUND_NINT_NOEXC);
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpd_ph(v128 d, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            return cvtps_ph(cvtpd_ps(d));
                        }
                    }
                        
                    promiseInRange |= constexpr.ALL_GE_PD(d, Unity.Mathematics.half.MinValue) & constexpr.ALL_LE_PD(d, Unity.Mathematics.half.MaxValue);
                    promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PD(d, 0d) : constexpr.ALL_GE_PD(d, 0d);
                    
                    const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + HalfExtensions.EXPONENT_BIAS;
                    
                    v128 exp = and_si128(d, set1_epi64x(F64_SIGNALING_EXPONENT));
                    v128 noUnderflow = cmpgt_epi64(exp, set1_epi64x(((ulong)(EXPONENT_OFFSET - HalfExtensions.MANTISSA_BITS) << F64_MANTISSA_BITS) - 1));
                    
                    if (promiseInRange && promiseNotSubnormal)
                    {
                        v128 inRange = mul_pd(d, set1_pd(1f / math.asdouble(HalfExtensions.F64_MAGIC)));
                        v128 aligned = srli_epi64(inRange, F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        if (!promiseAbs)
                        {
                            v128 sign64 = slli_epi64(srli_epi64(d, F64_BITS - 1), HalfExtensions.BITS - 1);
                            aligned = xor_si128(aligned, sign64);
                        }
                        
                        v128 round = cmpgt_epi64(and_si128(d, set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS)))), set1_epi64x(1ul << (F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS - 1)));
                        round = and_si128(noUnderflow, round);
                        aligned = sub_epi64(aligned, round);
                        
                        return cvtepi64_epi16(aligned);
                    }
                    else
                    {
                        v128 sign = slli_epi64(srli_epi64(d, F64_BITS - 1), HalfExtensions.BITS - 1);
                        v128 frac = and_si128(d, set1_epi64x(bitmask64((ulong)F64_MANTISSA_BITS)));
                        v128 abs = and_si128(d, set1_epi64x(bitmask64((ulong)(F64_BITS - 1))));
                        
                        v128 denormalF8 = cmpgt_epi64(set1_epi64x(((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS) + 1), exp);
                        v128 overflow = cmpgt_epi64(abs, set1_pd(Unity.Mathematics.half.MaxValue));
                        
                        exp = sub_epi64(exp, set1_epi64x((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS));
                        
                        v128 bitIndexDenormal = sub_epi64(set1_epi64x(HalfExtensions.MANTISSA_BITS - 1), abs_epi64(srai_epi64(exp, F64_MANTISSA_BITS)));
                        v128 denormalFrac = sllv_epi64(neg_epi64(noUnderflow), bitIndexDenormal);
                        denormalFrac = or_si128(denormalFrac, srlv_epi64(and_si128(frac, noUnderflow), sub_epi64(set1_epi64x(F64_MANTISSA_BITS), bitIndexDenormal)));
                        v128 denormalRoundingBit = sllv_epi64(set1_epi64x(1), sub_epi64(set1_epi64x(F64_MANTISSA_BITS - 1), bitIndexDenormal));
                        v128 roundDenormal = ternarylogic_si128(noUnderflow, cmpeq_epi64(setzero_si128(), and_si128(d, denormalRoundingBit)), srai_epi64(bitIndexDenormal, 63),  TernaryOperation.OxBO);
                        denormalFrac = sub_epi64(denormalFrac, roundDenormal);
                        if (!promiseAbs)
                        {
                            denormalFrac = or_si128(denormalFrac, sign);
                        }

                        exp = srli_epi64(exp, F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        exp = promiseInRange ? exp : blendv_si128(exp, set1_epi64x(HalfExtensions.SIGNALING_EXPONENT), overflow);
                        v128 normalFrac = srli_epi64(frac, F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        normalFrac = promiseAbs ? or_si128(normalFrac, exp)
                                                : ternarylogic_si128(sign, normalFrac, exp, TernaryOperation.OxFE);
                        v128 roundNormal = cmpgt_epi64(and_si128(d, set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS)))), set1_epi64x(1ul << (F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS - 1)));
                        normalFrac = sub_epi64(normalFrac, roundNormal);
                        
                        if (!promiseInRange)
                        {
                            if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                            {
                                normalFrac = blendv_si128(normalFrac, or_si128(set1_epi64x(((half)float.PositiveInfinity).value), sign), overflow);
                            }
                            else
                            {
                                v128 NaN = cmpgt_epi64(abs, set1_epi64x(F64_SIGNALING_EXPONENT));
                                normalFrac = blendv_si128(normalFrac, ternarylogic_si128(sign, set1_epi64x(((half)float.PositiveInfinity).value), NaN, TernaryOperation.OxFE), overflow);
                            }
                        }

                        v128 result = promiseNotSubnormal ? normalFrac : blendv_si128(normalFrac, denormalFrac, denormalF8);

                        return cvtepi64_epi16(result);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtpd_ph(v256 d, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return cvtps_ph(Avx.mm256_cvtpd_ps(d));
                    }
                        
                    promiseInRange |= constexpr.ALL_GE_PD(d, Unity.Mathematics.half.MinValue, elements) & constexpr.ALL_LE_PD(d, Unity.Mathematics.half.MaxValue, elements);
                    promiseAbs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? constexpr.ALL_GT_PD(d, 0d, elements) : constexpr.ALL_GE_PD(d, 0d, elements);
                    
                    const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + HalfExtensions.EXPONENT_BIAS;

                    v256 exp = Avx2.mm256_and_si256(d, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                    v256 noUnderflow = mm256_cmpgt_epi64(exp, mm256_set1_epi64x(((ulong)(EXPONENT_OFFSET - HalfExtensions.MANTISSA_BITS) << F64_MANTISSA_BITS) - 1));
                    
                    if (promiseInRange && promiseNotSubnormal)
                    {
                        v256 inRange = Avx.mm256_mul_pd(d, mm256_set1_pd(1d / math.asdouble(HalfExtensions.F64_MAGIC)));
                        v256 aligned = mm256_srli_epi64(inRange, F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        if (!promiseAbs)
                        {
                            v256 sign64 = mm256_slli_epi64(mm256_srli_epi64(d, F64_BITS - 1), HalfExtensions.BITS - 1);
                            aligned = Avx2.mm256_xor_si256(aligned, sign64);
                        }
                        
                        v256 round = mm256_cmpgt_epi64(Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS)))), mm256_set1_epi64x(1 << (F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS - 1)));
                        round = Avx2.mm256_and_si256(noUnderflow, round);
                        aligned = Avx2.mm256_sub_epi64(aligned, round);
                        
                        return mm256_cvtepi64_epi16(aligned);
                    }
                    else
                    {
                        v256 sign = Avx2.mm256_slli_epi64(Avx2.mm256_srli_epi64(d, F64_BITS - 1), HalfExtensions.BITS - 1);
                        v256 frac = Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)F64_MANTISSA_BITS)));
                        v256 abs = Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)F64_BITS - 1)));
                        
                        v256 denormalF8 = mm256_cmpgt_epi64(mm256_set1_epi64x(((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS) + 1), exp);
                        v256 overflow = mm256_cmpgt_epi64(abs, mm256_set1_pd(Unity.Mathematics.half.MaxValue));
                        
                        exp = Avx2.mm256_sub_epi64(exp, mm256_set1_epi64x((ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS));
                        
                        v256 bitIndexDenormal = Avx2.mm256_sub_epi64(mm256_set1_epi64x(HalfExtensions.MANTISSA_BITS - 1), mm256_abs_epi64(mm256_srai_epi64(exp, F64_MANTISSA_BITS)));
                        v256 denormalFrac = Avx2.mm256_sllv_epi64(mm256_neg_epi64(noUnderflow), bitIndexDenormal);
                        denormalFrac = Avx2.mm256_or_si256(denormalFrac, Avx2.mm256_srlv_epi64(Avx2.mm256_and_si256(frac, noUnderflow), Avx2.mm256_sub_epi64(mm256_set1_epi64x(F64_MANTISSA_BITS), bitIndexDenormal)));
                        v256 denormalRoundingBit = Avx2.mm256_sllv_epi64(mm256_set1_epi64x(1), Avx2.mm256_sub_epi64(mm256_set1_epi64x(F64_MANTISSA_BITS - 1), bitIndexDenormal));
                        v256 roundDenormal = mm256_ternarylogic_si256(noUnderflow, Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(d, denormalRoundingBit)), mm256_srai_epi64(bitIndexDenormal, 63),  TernaryOperation.OxBO);
                        denormalFrac = Avx2.mm256_sub_epi64(denormalFrac, roundDenormal);
                        if (!promiseAbs)
                        {
                            denormalFrac = Avx2.mm256_or_si256(denormalFrac, sign);
                        }

                        exp = Avx2.mm256_srli_epi64(exp, F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        exp = promiseInRange ? exp : mm256_blendv_si256(exp, mm256_set1_epi64x(HalfExtensions.SIGNALING_EXPONENT), overflow);
                        v256 normalFrac = Avx2.mm256_srli_epi64(frac, F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS);
                        normalFrac = promiseAbs ? Avx2.mm256_or_si256(normalFrac, exp)
                                                : mm256_ternarylogic_si256(sign, normalFrac, exp, TernaryOperation.OxFE);
                        v256 roundNormal = mm256_cmpgt_epi64(Avx2.mm256_and_si256(d, mm256_set1_epi64x(bitmask64((ulong)(F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS)))), mm256_set1_epi64x(1ul << (F64_MANTISSA_BITS - HalfExtensions.MANTISSA_BITS - 1)));
                        normalFrac = Avx2.mm256_sub_epi64(normalFrac, roundNormal);
                        
                        if (!promiseInRange)
                        {
                            if (COMPILATION_OPTIONS.FLOAT_NO_NAN)
                            {
                                normalFrac = mm256_blendv_si256(normalFrac, Avx2.mm256_or_si256(mm256_set1_epi64x(((half)float.PositiveInfinity).value), sign), overflow);
                            }
                            else
                            {
                                v256 NaN = mm256_cmpgt_epi64(abs, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                                normalFrac = mm256_blendv_si256(normalFrac, mm256_ternarylogic_si256(sign, mm256_set1_epi64x(((half)float.PositiveInfinity).value), NaN, TernaryOperation.OxFE), overflow);
                            }
                        }

                        v256 result = promiseNotSubnormal ? normalFrac : mm256_blendv_si256(normalFrac, denormalFrac, denormalF8);

                        return mm256_cvtepi64_epi16(result);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
