using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

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


                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epi16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(divisor,  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (saturated)
                    {
                        return packs_epi32(intsLo, intsHi);
                    }
                    else
                    {
                        return cvt2x2epi32_epi16(intsLo, intsHi);
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(cvtepi16_epi32(dividend)), cvtepi32_ps(cvtepi16_epi32(divisor)));

                    if (saturated || (constexpr.ALL_GT_EPI16(dividend, ushort.MinValue, elements) || constexpr.ALL_NEQ_EPI16(divisor, -1, elements)))
                    {
                        return packs_epi32(ints, ints);
                    }
                    else
                    {
                        return cvtepi32_epi16(ints, elements);
                    }
                }
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


                v256 dividendLo = mm256_cvt2x2epi16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epi16_ps(divisor,  out v256 divisorHi);

                v256 lo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendLo, divisorLo);
                v256 hi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendHi, divisorHi);

                if (saturated || (constexpr.ALL_GT_EPI16(dividend, ushort.MinValue) || constexpr.ALL_NEQ_EPI16(divisor, -1)))
                {
                    return Avx2.mm256_packs_epi32(lo, hi);
                }
                else
                {
                    return mm256_cvt2x2epi32_epi16(lo, hi);
                }
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

                return sub_epi16(dividend, mullo_epi16(quotient, divisor));
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
                constexpr.ASSUME_LT_EPU16(result, divisor, elements);
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

                return Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
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
                constexpr.ASSUME_LT_EPU16(result, divisor);
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
                constexpr.ASSUME_LT_EPU16(remainder, divisor, elements);
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
                constexpr.ASSUME_LT_EPU16(remainder, divisor);
                return quotient;
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
                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epu16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(divisor, out v128 rightHi);

                    v128 qLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 qHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return packus_epi32(qLo, qHi);
                    }
                    else
                    {
                        return cvt2x2epi32_epi16(qLo, qHi);
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu16_ps(dividend), cvtepu16_ps(divisor));

                    if (Sse4_1.IsSse41Supported)
                    {
                        return packus_epi32(ints, ints);
                    }
                    else
                    {
                        return cvtepi32_epi16(ints, elements);
                    }
                }
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

                return Avx2.mm256_packus_epi32(lo, hi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_usfdivadd_epu16(v128 dividend, v128 divisor, v128 summand, byte elements = 8, bool correctOverflow = true)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
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
                            return cvt2x2epi32_epi16(qLo, qHi);
                        }
                        else
                        {
                            return packus_epi32(qLo, qHi);
                        }
                    }
                    else
                    {
                        v128 ints = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(cvtepu16_ps(dividend), cvtepu16_ps(divisor), cvtepu16_ps(summand));

                        if (correctOverflow)
                        {
                            return cvtepi32_epi16(ints, elements);
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                return packus_epi32(ints, ints);
                            }
                            else
                            {
                                return cvtepi32_epi16(ints, elements);
                            }
                        }
                    }
                }
                else
                {
                    return add_epi16(impl_div_epu16(dividend, divisor, elements), summand);
                }
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

                if (correctOverflow)
                {
                    return mm256_cvt2x2epi32_epi16(lo, hi);
                }
                else
                {
                    return Avx2.mm256_packus_epi32(lo, hi);
                }
            }
            else throw new IllegalInstructionException();
        }


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