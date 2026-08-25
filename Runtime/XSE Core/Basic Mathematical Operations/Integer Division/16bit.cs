using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi16(v128 dividend, v128 divisor, bool saturated = false, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor) && !saturated)
                {
                    return constdiv_epi16(dividend, divisor, elements);
                }

                v128 result;

                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epi16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(divisor,  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (saturated || (constexpr.ALL_GT_EPI16(dividend, short.MinValue, elements) || constexpr.ALL_NEQ_EPI16(divisor, -1, elements)))
                    {
                        result = packs_epi32(intsLo, intsHi);
                    }
                    else
                    {
                        result = cvt2x2epi32_epi16(intsLo, intsHi);
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(cvtepi16_epi32(dividend)), cvtepi32_ps(cvtepi16_epi32(divisor)));

                    if (saturated || (constexpr.ALL_GT_EPI16(dividend, short.MinValue, elements) || constexpr.ALL_NEQ_EPI16(divisor, -1, elements)))
                    {
                        result = packs_epi32(ints, ints);
                    }
                    else
                    {
                        result = cvtepi32_epi16(ints, elements);
                    }
                }

                if (!saturated)
                {
                    constexpr.ASSUME_DIVISION_EPI16(result, dividend, divisor, elements);
                }
                
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constdiv_epu16(dividend, divisor, elements);
                }

                return impl_div_epu16(dividend, divisor, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi16(v256 dividend, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor) && !saturated)
                {
                    return mm256_constdiv_epi16(dividend, divisor);
                }

                v256 result;

                v256 dividendLo = mm256_cvt2x2epi16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epi16_ps(divisor,  out v256 divisorHi);

                v256 lo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendLo, divisorLo);
                v256 hi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendHi, divisorHi);

                if (saturated || (constexpr.ALL_GT_EPI16(dividend, short.MinValue) || constexpr.ALL_NEQ_EPI16(divisor, -1)))
                {
                    result = Avx2.mm256_packs_epi32(lo, hi);
                }
                else
                {
                    result = mm256_cvt2x2epi32_epi16(lo, hi);
                }
                
                if (!saturated)
                {
                    constexpr.ASSUME_DIVISION_EPI16(result, dividend, divisor);
                }
                
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constdiv_epu16(dividend, divisor);
                }

                return mm256_impl_div_epu16(dividend, divisor);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constrem_epi16(dividend, divisor, elements);
                }

                v128 quotient = div_epi16(dividend, divisor, false, elements);
                v128 result = sub_epi16(dividend, mullo_epi16(quotient, divisor));
                
                constexpr.ASSUME_REMAINDER_EPI16(result, dividend, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constrem_epu16(dividend, divisor, elements);
                }

                v128 quotient = div_epu16(dividend, divisor, elements);
                v128 result = sub_epi16(dividend, mullo_epi16(quotient, divisor));
                
                constexpr.ASSUME_REMAINDER_EPU16(result, dividend, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constrem_epi16(dividend, divisor);
                }

                v256 quotient = mm256_div_epi16(dividend, divisor, false);
                v256 result = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
                
                constexpr.ASSUME_REMAINDER_EPI16(result, dividend, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constrem_epu16(dividend, divisor);
                }

                v256 quotient = mm256_div_epu16(dividend, divisor);
                v256 result = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
                
                constexpr.ASSUME_REMAINDER_EPU16(result, dividend, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi16(v128 dividend, v128 divisor, out v128 remainder, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epi16(dividend, divisor, elements);
                    return constdiv_epi16(dividend, divisor, elements);
                }

                v128 quotient = div_epi16(dividend, divisor, false, elements);
                remainder = sub_epi16(dividend, mullo_epi16(quotient, divisor));

                constexpr.ASSUME_DIVISION_EPI16(quotient, dividend, divisor, elements);
                constexpr.ASSUME_REMAINDER_EPI16(remainder, dividend, divisor, elements);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu16(v128 dividend, v128 divisor, out v128 remainder, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epu16(dividend, divisor, elements);
                    return constdiv_epu16(dividend, divisor, elements);
                }

                v128 quotient = div_epu16(dividend, divisor, elements);
                remainder = sub_epi16(dividend, mullo_epi16(quotient, divisor));

                constexpr.ASSUME_DIVISION_EPU16(quotient, dividend, divisor, elements);
                constexpr.ASSUME_REMAINDER_EPU16(remainder, dividend, divisor, elements);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi16(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epi16(dividend, divisor);
                    return mm256_constdiv_epi16(dividend, divisor);
                }

                v256 quotient = mm256_div_epi16(dividend, divisor, false);
                remainder = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));

                constexpr.ASSUME_DIVISION_EPI16(quotient, dividend, divisor);
                constexpr.ASSUME_REMAINDER_EPI16(remainder, dividend, divisor);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu16(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epu16(dividend, divisor);
                    return mm256_constdiv_epu16(dividend, divisor);
                }

                v256 quotient = mm256_div_epu16(dividend, divisor);
                remainder = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));

                constexpr.ASSUME_DIVISION_EPU16(quotient, dividend, divisor);
                constexpr.ASSUME_REMAINDER_EPU16(remainder, dividend, divisor);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 divsumdiff_epi16(v128 dividendSummandA, v128 dividendSummandB, v128 divisor, bool add, bool saturated = false, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (elements > 4)
                {
                    v128 leftALo = cvt2x2epi16_epi32(dividendSummandA, out v128 leftAHi);
                    v128 leftBLo = cvt2x2epi16_epi32(dividendSummandB, out v128 leftBHi);
                    v128 rightLo = cvt2x2epi16_epi32(divisor, out v128 rightHi);
                    v128 leftLo = add ? add_epi32(leftALo, leftBLo) : sub_epi32(leftALo, leftBLo);
                    v128 leftHi = add ? add_epi32(leftAHi, leftBHi) : sub_epi32(leftAHi, leftBHi);

                    v128 intsLo;
                    v128 intsHi;
                    if (constexpr.IS_CONST(rightLo)
                     && constexpr.IS_CONST(rightHi))
                    {
                        intsLo = constdiv_epi32(leftLo, rightLo);
                        intsHi = constdiv_epi32(leftHi, rightHi);
                    }
                    else
                    {
                        intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(leftLo), cvtepi32_ps(rightLo));
                        intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(leftHi), cvtepi32_ps(rightHi));
                    }
                        
                    if (saturated 
                     || ((constexpr.ALL_GT_EPI32(intsLo, short.MinValue) && constexpr.ALL_LT_EPI32(intsLo, short.MaxValue))
                      && (constexpr.ALL_GT_EPI32(intsHi, short.MinValue) && constexpr.ALL_LT_EPI32(intsHi, short.MaxValue))))
                    {
                        result = packs_epi32(intsLo, intsHi);
                    }
                    else
                    {
                        result = cvt2x2epi32_epi16(intsLo, intsHi);
                    }
                }
                else
                {
                    v128 leftA = cvtepi16_epi32(dividendSummandA);
                    v128 leftB = cvtepi16_epi32(dividendSummandB);
                    v128 right = cvtepi16_epi32(divisor);
                    v128 left = add ? add_epi32(leftA, leftB) : sub_epi32(leftA, leftB);

                    v128 ints;
                    if (constexpr.IS_CONST(right))
                    {
                        ints = constdiv_epi32(left, right);
                    }
                    else
                    {
                        ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(left), cvtepi32_ps(right));
                    }
                        
                    if (saturated 
                     || (constexpr.ALL_GT_EPI32(ints, short.MinValue, elements) && constexpr.ALL_LT_EPI32(ints, short.MaxValue, elements)))
                    {
                        result = packs_epi32(ints, ints);
                    }
                    else
                    {
                        result = cvtepi32_epi16(ints, elements);
                    }
                }

                //if (!saturated)
                //{
                //    constexpr.ASSUME_DIVISION_EPI32(cvtepi16_epi32(result), dividend, divisor, elements);
                //}

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divsumdiff_epi16(v256 dividendSummandA, v256 dividendSummandB, v256 divisor, bool add, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                v256 leftALo = mm256_cvt2x2epi16_epi32(dividendSummandA, out v256 leftAHi);
                v256 leftBLo = mm256_cvt2x2epi16_epi32(dividendSummandB, out v256 leftBHi);
                v256 rightLo = mm256_cvt2x2epi16_epi32(divisor, out v256 rightHi);
                v256 leftLo = add ? Avx2.mm256_add_epi32(leftALo, leftBLo) : Avx2.mm256_sub_epi32(leftALo, leftBLo);
                v256 leftHi = add ? Avx2.mm256_add_epi32(leftAHi, leftBHi) : Avx2.mm256_sub_epi32(leftAHi, leftBHi);

                v256 intsLo;
                v256 intsHi;
                if (constexpr.IS_CONST(rightLo)
                 && constexpr.IS_CONST(rightHi))
                {
                    intsLo = mm256_constdiv_epi32(leftLo, rightLo);
                    intsHi = mm256_constdiv_epi32(leftHi, rightHi);
                }
                else
                {
                    intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(leftLo), Avx.mm256_cvtepi32_ps(rightLo));
                    intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(leftHi), Avx.mm256_cvtepi32_ps(rightHi));
                }
                    
                if (saturated 
                 || ((constexpr.ALL_GT_EPI32(intsLo, short.MinValue) && constexpr.ALL_LT_EPI32(intsLo, short.MaxValue))
                  && (constexpr.ALL_GT_EPI32(intsHi, short.MinValue) && constexpr.ALL_LT_EPI32(intsHi, short.MaxValue))))
                {
                    result = Avx2.mm256_packs_epi32(intsLo, intsHi);
                }
                else
                {
                    result = mm256_cvt2x2epi32_epi16(intsLo, intsHi);
                }

                //if (!saturated)
                //{
                //    constexpr.ASSUME_DIVISION_EPI32(cvtepi16_epi32(result), dividend, divisor, elements);
                //}

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divsumdiff_epu16(v128 dividendSummandA, v128 dividendSummandB, v128 divisor, bool add, bool saturated = false, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (elements > 4)
                {
                    v128 leftALo = cvt2x2epu16_epi32(dividendSummandA, out v128 leftAHi);
                    v128 leftBLo = cvt2x2epu16_epi32(dividendSummandB, out v128 leftBHi);
                    v128 rightLo = cvt2x2epu16_epi32(divisor, out v128 rightHi);
                    v128 leftLo = add ? add_epi32(leftALo, leftBLo) : sub_epi32(leftALo, leftBLo);
                    v128 leftHi = add ? add_epi32(leftAHi, leftBHi) : sub_epi32(leftAHi, leftBHi);

                    v128 intsLo;
                    v128 intsHi;
                    if (constexpr.IS_CONST(rightLo)
                     && constexpr.IS_CONST(rightHi))
                    {
                        intsLo = constdiv_epu32(leftLo, rightLo);
                        intsHi = constdiv_epu32(leftHi, rightHi);
                    }
                    else
                    {
                        intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(leftLo), cvtepi32_ps(rightLo));
                        intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(leftHi), cvtepi32_ps(rightHi));
                    }

                    if (Sse4_1.IsSse41Supported)
                    {
                        if (saturated 
                         || (constexpr.ALL_LE_EPU32(intsLo, ushort.MaxValue))
                          && constexpr.ALL_LE_EPU32(intsHi, ushort.MaxValue))
                        {
                            result = packus_epi32(intsLo, intsHi);
                        }
                        else
                        {
                            result = cvt2x2epi32_epi16(intsLo, intsHi);
                        }
                    }
                    else
                    {
                        result = cvt2x2epi32_epi16(intsLo, intsHi);
                    }
                }
                else
                {
                    v128 leftA = cvtepu16_epi32(dividendSummandA);
                    v128 leftB = cvtepu16_epi32(dividendSummandB);
                    v128 right = cvtepu16_epi32(divisor);
                    v128 left = add ? add_epi32(leftA, leftB) : sub_epi32(leftA, leftB);

                    v128 ints;
                    if (constexpr.IS_CONST(right))
                    {
                        ints = constdiv_epu32(left, right);
                    }
                    else
                    {
                        ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(left), cvtepi32_ps(right));
                    }

                    if (Sse4_1.IsSse41Supported)
                    {
                        if (saturated 
                         || (constexpr.ALL_LE_EPU32(ints, ushort.MaxValue, elements)))
                        {
                            result = packus_epi32(ints, ints);
                        }
                        else
                        {
                            result = cvtepi32_epi16(ints, elements);
                        }
                    }
                    else
                    {
                        result = cvtepi32_epi16(ints, elements);
                    }
                }

                //if (!saturated)
                //{
                //    constexpr.ASSUME_DIVISION_EPI32(cvtepi16_epi32(result), dividend, divisor, elements);
                //}

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divsumdiff_epu16(v256 dividendSummandA, v256 dividendSummandB, v256 divisor, bool add, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                v256 leftALo = mm256_cvt2x2epu16_epi32(dividendSummandA, out v256 leftAHi);
                v256 leftBLo = mm256_cvt2x2epu16_epi32(dividendSummandB, out v256 leftBHi);
                v256 rightLo = mm256_cvt2x2epu16_epi32(divisor, out v256 rightHi);
                v256 leftLo = add ? Avx2.mm256_add_epi32(leftALo, leftBLo) : Avx2.mm256_sub_epi32(leftALo, leftBLo);
                v256 leftHi = add ? Avx2.mm256_add_epi32(leftAHi, leftBHi) : Avx2.mm256_sub_epi32(leftAHi, leftBHi);

                v256 intsLo;
                v256 intsHi;
                if (constexpr.IS_CONST(rightLo)
                 && constexpr.IS_CONST(rightHi))
                {
                    intsLo = mm256_constdiv_epu32(leftLo, rightLo);
                    intsHi = mm256_constdiv_epu32(leftHi, rightHi);
                }
                else
                {
                    intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(leftLo), Avx.mm256_cvtepi32_ps(rightLo));
                    intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(leftHi), Avx.mm256_cvtepi32_ps(rightHi));
                }
                    
                if (saturated 
                 || (constexpr.ALL_LE_EPU32(intsLo, ushort.MaxValue)
                  && constexpr.ALL_LE_EPU32(intsHi, ushort.MaxValue)))
                {
                    result = Avx2.mm256_packus_epi32(intsLo, intsHi);
                }
                else
                {
                    result = mm256_cvt2x2epi32_epi16(intsLo, intsHi);
                }

                //if (!saturated)
                //{
                //    constexpr.ASSUME_DIVISION_EPI32(cvtepi16_epi32(result), dividend, divisor, elements);
                //}

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divsum_epi16(v128 dividendSummandA, v128 dividendSummandB, v128 divisor, bool saturated = false, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return divsumdiff_epi16(dividendSummandA, dividendSummandB, divisor, add: true, saturated: saturated, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divsum_epi16(v256 dividendSummandA, v256 dividendSummandB, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_divsumdiff_epi16(dividendSummandA, dividendSummandB, divisor, add: true, saturated: saturated);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divsum_epu16(v128 dividendSummandA, v128 dividendSummandB, v128 divisor, bool saturated = false, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return divsumdiff_epu16(dividendSummandA, dividendSummandB, divisor, add: true, saturated: saturated, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divsum_epu16(v256 dividendSummandA, v256 dividendSummandB, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_divsumdiff_epu16(dividendSummandA, dividendSummandB, divisor, add: true, saturated: saturated);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divdiff_epi16(v128 dividendMinuend, v128 dividendSubtrahend, v128 divisor, bool saturated = false, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return divsumdiff_epi16(dividendMinuend, dividendSubtrahend, divisor, add: false, saturated: saturated, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divdiff_epi16(v256 dividendMinuend, v256 dividendSubtrahend, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_divsumdiff_epi16(dividendMinuend, dividendSubtrahend, divisor, add: false, saturated: saturated);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divdiff_epu16(v128 dividendMinuend, v128 dividendSubtrahend, v128 divisor, bool saturated = false, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return divsumdiff_epu16(dividendMinuend, dividendSubtrahend, divisor, add: false, saturated: saturated, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divdiff_epu16(v256 dividendMinuend, v256 dividendSubtrahend, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_divsumdiff_epu16(dividendMinuend, dividendSubtrahend, divisor, add: false, saturated: saturated);
            }
            else throw new IllegalInstructionException();
        }


        /// <summary> SAFE RANGE (SUMMAND ONLY): [0, byte.MaxValue] </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfdivadd_epu16(v128 dividend, v128 divisor, v128 summand, byte elements = 8, bool correctOverflow = true)
        {
VectorAssert.IsNotGreater<ushort8, ushort>(summand, byte.MaxValue, elements);

            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return add_epi16(summand, constdiv_epu16(dividend, divisor, elements));
                }

                return impl_usfdivadd_epu16(dividend, divisor, summand, elements, correctOverflow);
            }
            else throw new IllegalInstructionException();
        }

        /// <summary> SAFE RANGE (SUMMAND ONLY): [0, byte.MaxValue] </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfdivadd_epu16(v256 dividend, v256 divisor, v256 summand, bool correctOverflow = true)
        {
VectorAssert.IsNotGreater<ushort16, ushort>(summand, byte.MaxValue, 16);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return Avx2.mm256_add_epi16(mm256_constdiv_epu16(dividend, divisor), summand);
                }

                return mm256_impl_usfdivadd_epu16(dividend, divisor, summand, correctOverflow);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_div_epu16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epu16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(divisor, out v128 rightHi);

                    v128 qLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 qHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (Sse4_1.IsSse41Supported)
                    {
                        result = packus_epi32(qLo, qHi);
                    }
                    else
                    {
                        result = cvt2x2epi32_epi16(qLo, qHi);
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu16_ps(dividend), cvtepu16_ps(divisor));

                    if (Sse4_1.IsSse41Supported)
                    {
                        result = packus_epi32(ints, ints);
                    }
                    else
                    {
                        result = cvtepi32_epi16(ints, elements);
                    }
                }

                constexpr.ASSUME_DIVISION_EPU16(result, dividend, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_div_epu16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 dividendLo = mm256_cvt2x2epu16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epu16_ps(divisor,  out v256 divisorHi);

                v256 lo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendLo, divisorLo);
                v256 hi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendHi, divisorHi);

                v256 result = Avx2.mm256_packus_epi32(lo, hi);

                constexpr.ASSUME_DIVISION_EPU16(result, dividend, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_usfdivadd_epu16(v128 dividend, v128 divisor, v128 summand, byte elements = 8, bool correctOverflow = true)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (BurstArchitecture.IsFMASupported)
                {
                    if (elements > 4)
                    {
                        v128 leftLo    = cvt2x2epu16_ps(dividend, out v128 leftHi);
                        v128 rightLo   = cvt2x2epu16_ps(divisor, out v128 rightHi);
                        v128 summandLo = cvt2x2epu16_ps(summand, out v128 summandHi);

                        v128 qLo = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(leftLo, rightLo, summandLo);
                        v128 qHi = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(leftHi, rightHi, summandHi);

                        if (correctOverflow)
                        {
                            result = cvt2x2epi32_epi16(qLo, qHi);
                        }
                        else
                        {
                            result = packus_epi32(qLo, qHi);
                        }
                    }
                    else
                    {
                        v128 ints = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(cvtepu16_ps(dividend), cvtepu16_ps(divisor), cvtepu16_ps(summand));

                        if (correctOverflow)
                        {
                            result = cvtepi32_epi16(ints, elements);
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                result = packus_epi32(ints, ints);
                            }
                            else
                            {
                                result = cvtepi32_epi16(ints, elements);
                            }
                        }
                    }
                }
                else
                {
                    result = add_epi16(impl_div_epu16(dividend, divisor, elements), summand);
                }

                if (correctOverflow)
                {
                    constexpr.ASSUME(result.UShort0 == (ushort)((ushort)(dividend.UShort0 / divisor.UShort0) + summand.UShort0));
                    constexpr.ASSUME(result.UShort1 == (ushort)((ushort)(dividend.UShort1 / divisor.UShort1) + summand.UShort1));
                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.UShort2 == (ushort)((ushort)(dividend.UShort2 / divisor.UShort2) + summand.UShort2));

                        if (elements > 3)
                        {
                            constexpr.ASSUME(result.UShort3 == (ushort)((ushort)(dividend.UShort3 / divisor.UShort3) + summand.UShort3));

                            if (elements > 4)
                            {
                                constexpr.ASSUME(result.UShort4 == (ushort)((ushort)(dividend.UShort4 / divisor.UShort4) + summand.UShort4));
                                constexpr.ASSUME(result.UShort5 == (ushort)((ushort)(dividend.UShort5 / divisor.UShort5) + summand.UShort5));
                                constexpr.ASSUME(result.UShort6 == (ushort)((ushort)(dividend.UShort6 / divisor.UShort6) + summand.UShort6));
                                constexpr.ASSUME(result.UShort7 == (ushort)((ushort)(dividend.UShort7 / divisor.UShort7) + summand.UShort7));
                            }
                        }
                    }
                }
                else
                {
                    constexpr.ASSUME(result.UShort0 == (((dividend.UShort0 / divisor.UShort0) + summand.UShort0 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort0 / divisor.UShort0) + summand.UShort0));
                    constexpr.ASSUME(result.UShort1 == (((dividend.UShort1 / divisor.UShort1) + summand.UShort1 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort1 / divisor.UShort1) + summand.UShort1));
                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.UShort2 == (((dividend.UShort2 / divisor.UShort2) + summand.UShort2 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort2 / divisor.UShort2) + summand.UShort2));

                        if (elements > 3)
                        {
                            constexpr.ASSUME(result.UShort3 == (((dividend.UShort3 / divisor.UShort3) + summand.UShort3 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort3 / divisor.UShort3) + summand.UShort3));

                            if (elements > 4)
                            {
                                constexpr.ASSUME(result.UShort4 == (((dividend.UShort4 / divisor.UShort4) + summand.UShort4 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort4 / divisor.UShort4) + summand.UShort4));
                                constexpr.ASSUME(result.UShort5 == (((dividend.UShort5 / divisor.UShort5) + summand.UShort5 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort5 / divisor.UShort5) + summand.UShort5));
                                constexpr.ASSUME(result.UShort6 == (((dividend.UShort6 / divisor.UShort6) + summand.UShort6 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort6 / divisor.UShort6) + summand.UShort6));
                                constexpr.ASSUME(result.UShort7 == (((dividend.UShort7 / divisor.UShort7) + summand.UShort7 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort7 / divisor.UShort7) + summand.UShort7));
                            }
                        }
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_usfdivadd_epu16(v256 dividend, v256 divisor, v256 summand, bool correctOverflow = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 dividendLo = mm256_cvt2x2epu16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epu16_ps(divisor,  out v256 divisorHi);
                v256 summandLo  = mm256_cvt2x2epu16_ps(summand,  out v256 summandHi);

                v256 lo = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(dividendLo, divisorLo, summandLo);
                v256 hi = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(dividendHi, divisorHi, summandHi);

                v256 result;
                if (correctOverflow)
                {
                    result = mm256_cvt2x2epi32_epi16(lo, hi);
                }
                else
                {
                    result = Avx2.mm256_packus_epi32(lo, hi);
                }

                if (correctOverflow)
                {
                    constexpr.ASSUME(result.UShort0  == (ushort)((ushort)(dividend.UShort0  / divisor.UShort0)  + summand.UShort0));
                    constexpr.ASSUME(result.UShort1  == (ushort)((ushort)(dividend.UShort1  / divisor.UShort1)  + summand.UShort1));
                    constexpr.ASSUME(result.UShort2  == (ushort)((ushort)(dividend.UShort2  / divisor.UShort2)  + summand.UShort2));
                    constexpr.ASSUME(result.UShort3  == (ushort)((ushort)(dividend.UShort3  / divisor.UShort3)  + summand.UShort3));
                    constexpr.ASSUME(result.UShort4  == (ushort)((ushort)(dividend.UShort4  / divisor.UShort4)  + summand.UShort4));
                    constexpr.ASSUME(result.UShort5  == (ushort)((ushort)(dividend.UShort5  / divisor.UShort5)  + summand.UShort5));
                    constexpr.ASSUME(result.UShort6  == (ushort)((ushort)(dividend.UShort6  / divisor.UShort6)  + summand.UShort6));
                    constexpr.ASSUME(result.UShort7  == (ushort)((ushort)(dividend.UShort7  / divisor.UShort7)  + summand.UShort7));
                    constexpr.ASSUME(result.UShort8  == (ushort)((ushort)(dividend.UShort8  / divisor.UShort8)  + summand.UShort8));
                    constexpr.ASSUME(result.UShort9  == (ushort)((ushort)(dividend.UShort9  / divisor.UShort9)  + summand.UShort9));
                    constexpr.ASSUME(result.UShort10 == (ushort)((ushort)(dividend.UShort10 / divisor.UShort10) + summand.UShort10));
                    constexpr.ASSUME(result.UShort11 == (ushort)((ushort)(dividend.UShort11 / divisor.UShort11) + summand.UShort11));
                    constexpr.ASSUME(result.UShort12 == (ushort)((ushort)(dividend.UShort12 / divisor.UShort12) + summand.UShort12));
                    constexpr.ASSUME(result.UShort13 == (ushort)((ushort)(dividend.UShort13 / divisor.UShort13) + summand.UShort13));
                    constexpr.ASSUME(result.UShort14 == (ushort)((ushort)(dividend.UShort14 / divisor.UShort14) + summand.UShort14));
                    constexpr.ASSUME(result.UShort15 == (ushort)((ushort)(dividend.UShort15 / divisor.UShort15) + summand.UShort15));
                }
                else
                {
                    constexpr.ASSUME(result.UShort0  == (((dividend.UShort0  / divisor.UShort0)  + summand.UShort0  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort0  / divisor.UShort0)  + summand.UShort0));
                    constexpr.ASSUME(result.UShort1  == (((dividend.UShort1  / divisor.UShort1)  + summand.UShort1  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort1  / divisor.UShort1)  + summand.UShort1));
                    constexpr.ASSUME(result.UShort2  == (((dividend.UShort2  / divisor.UShort2)  + summand.UShort2  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort2  / divisor.UShort2)  + summand.UShort2));
                    constexpr.ASSUME(result.UShort3  == (((dividend.UShort3  / divisor.UShort3)  + summand.UShort3  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort3  / divisor.UShort3)  + summand.UShort3));
                    constexpr.ASSUME(result.UShort4  == (((dividend.UShort4  / divisor.UShort4)  + summand.UShort4  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort4  / divisor.UShort4)  + summand.UShort4));
                    constexpr.ASSUME(result.UShort5  == (((dividend.UShort5  / divisor.UShort5)  + summand.UShort5  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort5  / divisor.UShort5)  + summand.UShort5));
                    constexpr.ASSUME(result.UShort6  == (((dividend.UShort6  / divisor.UShort6)  + summand.UShort6  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort6  / divisor.UShort6)  + summand.UShort6));
                    constexpr.ASSUME(result.UShort7  == (((dividend.UShort7  / divisor.UShort7)  + summand.UShort7  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort7  / divisor.UShort7)  + summand.UShort7));
                    constexpr.ASSUME(result.UShort8  == (((dividend.UShort8  / divisor.UShort8)  + summand.UShort8  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort8  / divisor.UShort8)  + summand.UShort8));
                    constexpr.ASSUME(result.UShort9  == (((dividend.UShort9  / divisor.UShort9)  + summand.UShort9  > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort9  / divisor.UShort9)  + summand.UShort9));
                    constexpr.ASSUME(result.UShort10 == (((dividend.UShort10 / divisor.UShort10) + summand.UShort10 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort10 / divisor.UShort10) + summand.UShort10));
                    constexpr.ASSUME(result.UShort11 == (((dividend.UShort11 / divisor.UShort11) + summand.UShort11 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort11 / divisor.UShort11) + summand.UShort11));
                    constexpr.ASSUME(result.UShort12 == (((dividend.UShort12 / divisor.UShort12) + summand.UShort12 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort12 / divisor.UShort12) + summand.UShort12));
                    constexpr.ASSUME(result.UShort13 == (((dividend.UShort13 / divisor.UShort13) + summand.UShort13 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort13 / divisor.UShort13) + summand.UShort13));
                    constexpr.ASSUME(result.UShort14 == (((dividend.UShort14 / divisor.UShort14) + summand.UShort14 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort14 / divisor.UShort14) + summand.UShort14));
                    constexpr.ASSUME(result.UShort15 == (((dividend.UShort15 / divisor.UShort15) + summand.UShort15 > ushort.MaxValue) ? ushort.MaxValue : (ushort)(dividend.UShort15 / divisor.UShort15) + summand.UShort15));
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        
        // confirmed range: dividend: [-(2 * ushort.MaxValue + 1), 2 * ushort.MaxValue]; divisor: [-(ushort.MaxValue + 5), ushort.MaxValue + 5]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(v128 dividend_f32, v128 divisor_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 divisorRcp = rcp_ps(divisor_f32);
                v128 approxQuotient = mul_ps(dividend_f32, divisorRcp);
                v128 precisionLossCompensation = fnmadd_ps(divisorRcp, divisor_f32, set1_epi32(RCP32_PRECISION_LOSS_U16));

                return cvttps_epi32(mul_ps(precisionLossCompensation, approxQuotient));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return cvttps_epi32(div_ps(dividend_f32, divisor_f32));
            }
            else throw new IllegalInstructionException();
        }
        
        // confirmed range: dividend: [-(2 * ushort.MaxValue + 1), 2 * ushort.MaxValue]; divisor: [-(ushort.MaxValue + 5), ushort.MaxValue + 5]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(v256 dividend_f32, v256 divisor_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 divisorRcp = Avx.mm256_rcp_ps(divisor_f32);
                v256 approxQuotient = Avx.mm256_mul_ps(dividend_f32, divisorRcp);
                v256 precisionLossCompensation = mm256_fnmadd_ps(divisorRcp, divisor_f32, mm256_set1_epi32(RCP32_PRECISION_LOSS_U16));

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
                v128 precisionLossCompensation = fnmadd_ps(divisorRcp, divisor_f32, set1_epi32(RCP32_PRECISION_LOSS_U16));

                return cvttps_epi32(fmadd_ps(precisionLossCompensation, approxQuotient, summand_f32));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return cvttps_epi32(add_ps(summand_f32, div_ps(dividend_f32, divisor_f32)));
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
                v256 precisionLossCompensation = mm256_fnmadd_ps(divisorRcp, divisor_f32, mm256_set1_epi32(RCP32_PRECISION_LOSS_U16));

                return Avx.mm256_cvttps_epi32(mm256_fmadd_ps(precisionLossCompensation, approxQuotient, summand_f32));
            }
            else throw new IllegalInstructionException();
        }
    }
}