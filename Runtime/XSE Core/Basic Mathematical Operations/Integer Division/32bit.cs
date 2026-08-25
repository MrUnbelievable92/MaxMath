using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epu32(a, b, elements);
                }

                return impl_div_epu32(a, b, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu32(v256 a, v256 b, uint maxValuePromise = uint.MaxValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epu32(a, b);
                }

                return mm256_impl_div_epu32(a, b, maxValuePromise);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epi32(a, b, elements);
                }

                return impl_div_epi32(a, b, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epi32(a, b);
                }

                return mm256_divrem_epi32(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constrem_epu32(a, b, elements);
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue)
                 && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return rem_epi32(a, b);
                }

                v128 result = sub_epi32(a, mullo_epi32(div_epu32(a, b, elements), b, elements));

                constexpr.ASSUME_REMAINDER_EPU32(result, a, b, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epu32(a, b);
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue)
                 && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return mm256_rem_epi32(a, b);
                }

                v256 result = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_div_epu32(a, b), b));

                constexpr.ASSUME_REMAINDER_EPU32(result, a, b);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constrem_epi32(a, b, elements);
                }

                v128 result = sub_epi32(a, mullo_epi32(div_epi32(a, b, elements), b, elements));

                constexpr.ASSUME_REMAINDER_EPI32(result, a, b, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epi32(a, b);
                }

                v256 result = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_div_epi32(a, b), b));

                constexpr.ASSUME_REMAINDER_EPI32(result, a, b);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu32(v128 a, v128 b, out v128 rem, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = div_epu32(a, b, elements);
                rem = sub_epi32(a, mullo_epi32(quotient, b, elements));

                constexpr.ASSUME_DIVISION_EPU32(quotient, a, b, elements);
                constexpr.ASSUME_REMAINDER_EPU32(rem, a, b, elements);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu32(v256 a, v256 b, out v256 rem)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = mm256_div_epu32(a, b);
                rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b));

                constexpr.ASSUME_DIVISION_EPU32(quotient, a, b);
                constexpr.ASSUME_REMAINDER_EPU32(rem, a, b);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi32(v128 a, v128 b, out v128 rem, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = div_epi32(a, b, elements);
                rem = sub_epi32(a, mullo_epi32(quotient, b, elements));

                constexpr.ASSUME_DIVISION_EPI32(quotient, a, b, elements);
                constexpr.ASSUME_REMAINDER_EPI32(rem, a, b, elements);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi32(v256 a, v256 b, out v256 rem)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient;

                if (constexpr.ALL_GE_EPI32(a, -byte.MinValue)
                 && constexpr.ALL_LE_EPI32(a, byte.MaxValue)
                 && constexpr.ALL_GE_EPI32(b, -byte.MinValue)
                 && constexpr.ALL_LE_EPI32(b, byte.MaxValue))
                {
                    quotient = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b));
                    rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b));
                }
                else if (constexpr.ALL_GE_EPI32(a, -ushort.MinValue)
                      && constexpr.ALL_LE_EPI32(a, ushort.MaxValue)
                      && constexpr.ALL_GE_EPI32(b, -ushort.MinValue)
                      && constexpr.ALL_LE_EPI32(b, ushort.MaxValue))
                {
                    quotient = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b));
                    rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b));
                }
                else if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    v256 a64Lo = Avx.mm256_cvtepi32_pd(a.Lo128);
                    v256 a64Hi = Avx.mm256_cvtepi32_pd(a.Hi128);
                    v256 b64Lo = Avx.mm256_cvtepi32_pd(b.Lo128);
                    v256 b64Hi = Avx.mm256_cvtepi32_pd(b.Hi128);

                    quotient = new v256(Avx.mm256_cvttpd_epi32(Avx.mm256_div_pd(a64Lo, b64Lo)),
                                        Avx.mm256_cvttpd_epi32(Avx.mm256_div_pd(a64Hi, b64Hi)));
                    rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b));
                }
                else
                {
                    v256 a64Lo = mm256_cvt2x2epu32_pd(mm256_abs_epi32(a), out v256 a64Hi);
                    v256 b64Lo = mm256_cvt2x2epu32_pd(mm256_abs_epi32(b), out v256 b64Hi);

                    quotient = mm256_cvtt2x2pd_epu32(Avx.mm256_div_pd(a64Lo, b64Lo), Avx.mm256_div_pd(a64Hi, b64Hi));
                    quotient = SIGNED_FROM_UNSIGNED_DIV_EPI32(out rem, a, b, quotient, Avx2.mm256_sub_epi32(mm256_abs_epi32(a), Avx2.mm256_mullo_epi32(quotient, mm256_abs_epi32(b))));
                }
                
                constexpr.ASSUME_DIVISION_EPI32(quotient, a, b);
                constexpr.ASSUME_REMAINDER_EPI32(rem, a, b);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_div_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements)
                 && constexpr.ALL_LE_EPU32(b, byte.MaxValue, elements))
                {
                    result = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepi32_ps(a), cvtepi32_ps(b));
                }
                else if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements)
                      && constexpr.ALL_LE_EPU32(b, ushort.MaxValue, elements))
                {
                    result = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(a), cvtepi32_ps(b));
                }
                else if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue, elements)
                      && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue, elements))
                {
                    result = impl_div_epi32(a, b, elements);
                }
                else if (elements >= 3)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 a64 = Avx2.mm256_cvtepu32_epi64(a);
                        v256 b64 = Avx2.mm256_cvtepu32_epi64(b);

                        v256 r64 = mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a64), mm256_usfcvtepu64_pd(b64)), elements);

                        result = mm256_cvtepi64_epi32(r64);
                    }
                    else
                    {
                        v128 aLo = cvt2x2epu32_pd(a, out v128 aHi);
                        v128 bLo = cvt2x2epu32_pd(b, out v128 bHi);

                        result = cvtt2x2pd_epu32(div_pd(aLo, bLo), div_pd(aHi, bHi));
                    }
                }
                else
                {
                    result = cvtepi64_epi32(cvttpd_epu64(div_pd(cvtepu32_pd(a), cvtepu32_pd(b))));
                }

                constexpr.ASSUME_DIVISION_EPU32(result, a, b, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_div_epu32(v256 a, v256 b, uint maxValuePromise = uint.MaxValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                if (constexpr.IS_TRUE(maxValuePromise <= byte.MaxValue)
                 || (constexpr.ALL_LE_EPU32(a, byte.MaxValue) && constexpr.ALL_LE_EPU32(b, byte.MaxValue)))
                {
                    result = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b));
                }
                else if (constexpr.IS_TRUE(maxValuePromise <= ushort.MaxValue)
                      || (constexpr.ALL_LE_EPU32(a, ushort.MaxValue) && constexpr.ALL_LE_EPU32(b, ushort.MaxValue)))
                {
                    result = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b));
                }
                else if (constexpr.IS_TRUE(maxValuePromise <= (uint)int.MaxValue)
                      || (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue)))
                {
                    result = mm256_divrem_epi32(a, b, out _);
                }
                else
                {
                    v256 a64Lo = mm256_cvt2x2epu32_pd(a, out v256 a64Hi);
                    v256 b64Lo = mm256_cvt2x2epu32_pd(b, out v256 b64Hi);

                    result = mm256_cvtt2x2pd_epu32(Avx.mm256_div_pd(a64Lo, b64Lo), Avx.mm256_div_pd(a64Hi, b64Hi));
                }

                constexpr.ASSUME_DIVISION_EPU32(result, a, b);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_div_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (constexpr.ALL_GE_EPI32(a, -byte.MinValue, elements)
                 && constexpr.ALL_LE_EPI32(a, byte.MaxValue, elements)
                 && constexpr.ALL_GE_EPI32(b, -byte.MaxValue, elements)
                 && constexpr.ALL_LE_EPI32(b, byte.MaxValue, elements))
                {
                    result = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepi32_ps(a), cvtepi32_ps(b));
                }
                else if (constexpr.ALL_GE_EPI32(a, -ushort.MinValue, elements)
                      && constexpr.ALL_LE_EPI32(a, ushort.MaxValue, elements)
                      && constexpr.ALL_GE_EPI32(b, -ushort.MaxValue, elements)
                      && constexpr.ALL_LE_EPI32(b, ushort.MaxValue, elements))
                {
                    result = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(a), cvtepi32_ps(b));
                }
                else if (Avx2.IsAvx2Supported)
                {
                    result = Avx.mm256_cvttpd_epi32(Avx.mm256_div_pd(Avx.mm256_cvtepi32_pd(a), Avx.mm256_cvtepi32_pd(b)));
                }
                else
                {
                    if (elements > 2)
                    {
                        v128 aLo = cvt2x2epi32_pd(a, out v128 aHi);
                        v128 bLo = cvt2x2epi32_pd(b, out v128 bHi);

                        result = cvtt2x2pd_epi32(div_pd(aLo, bLo), div_pd(aHi, bHi));
                    }
                    else
                    {
                        result = cvttpd_epi32(div_pd(cvtepi32_pd(a), cvtepi32_pd(b)));
                    }
                }

                constexpr.ASSUME_DIVISION_EPI32(result, a, b, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divsum_epu32(v128 summandA0, v128 summandA1, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                v128 overflowTestSum = add_epi32(summandA0, summandA1);
                if (constexpr.ALL_GE_EPU32(overflowTestSum, summandA0, elements)
                 || constexpr.ALL_GE_EPU32(overflowTestSum, summandA1, elements))
                {
                    return div_epu32(overflowTestSum, b, elements);
                }

                if (elements == 2)
                {
                    v128 a64_0 = cvtepu32_epi64(summandA0);
                    v128 a64_1 = cvtepu32_epi64(summandA1);
                    v128 a64 = add_epi64(a64_0, a64_1);
                    v128 b64 = cvtepu32_epi64(b);

                    if (constexpr.IS_CONST(b64))
                    {
                        result = constdiv_epu64(a64, b64);
                    }
                    else
                    {
                        result = cvttpd_epu64(div_pd(usfcvtepu64_pd(a64), usfcvtepu64_pd(b64)));
                    }

                    result = cvtepi64_epi32(result);
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 a64 = Avx2.mm256_add_epi64(Avx2.mm256_cvtepu32_epi64(summandA0), Avx2.mm256_cvtepu32_epi64(summandA1));
                        v256 b64 = Avx2.mm256_cvtepu32_epi64(b);

                        v256 result256;
                        if (constexpr.IS_CONST(b64))
                        {
                            result256 = mm256_constdiv_epu64(a64, b64, elements);
                        }
                        else
                        {
                            result256 = mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a64), mm256_usfcvtepu64_pd(b64)), elements);
                        }

                        result = mm256_cvtepi64_epi32(result256);
                    }
                    else
                    {
                        v128 a64_0lo = cvt2x2epu32_epi64(summandA0, out v128 a64_0hi);
                        v128 a64_1lo = cvt2x2epu32_epi64(summandA1, out v128 a64_1hi);
                        v128 a64lo = add_epi64(a64_0lo, a64_1lo);
                        v128 a64hi = add_epi64(a64_0hi, a64_1hi);
                        v128 b64lo = cvt2x2epu32_epi64(b, out v128 b64hi);

                        if (constexpr.IS_CONST(b64lo)
                         && constexpr.IS_CONST(b64hi))
                        {
                            v128 rlo = constdiv_epu64(a64lo, b64lo);
                            v128 rhi = constdiv_epu64(a64hi, b64hi);
                            result = cvt2x2epi64_epi32(rlo, rhi);
                        }
                        else
                        {
                            v128 rlo = div_pd(usfcvtepu64_pd(a64lo), usfcvtepu64_pd(b64lo));
                            v128 rhi = div_pd(usfcvtepu64_pd(a64hi), usfcvtepu64_pd(b64hi));
                            result = cvtt2x2pd_epu32(rlo, rhi);
                        }
                    }
                }

                //constexpr.ASSUME_DIVISION_EPU32(result, a, b, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divsum_epu32(v256 summandA0, v256 summandA1, v256 b, uint maxValuePromise = uint.MaxValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                v256 overflowTestSum = Avx2.mm256_add_epi32(summandA0, summandA1);
                if (constexpr.ALL_GE_EPU32(overflowTestSum, summandA0)
                 || constexpr.ALL_GE_EPU32(overflowTestSum, summandA1))
                {
                    return mm256_div_epu32(overflowTestSum, b, maxValuePromise);
                }

                v256 a64_0lo = mm256_cvt2x2epu32_epi64(summandA0, out v256 a64_0hi);
                v256 a64_1lo = mm256_cvt2x2epu32_epi64(summandA1, out v256 a64_1hi);
                v256 a64lo = Avx2.mm256_add_epi64(a64_0lo, a64_1lo);
                v256 a64hi = Avx2.mm256_add_epi64(a64_0hi, a64_1hi);
                v256 b64lo = mm256_cvt2x2epu32_epi64(b, out v256 b64hi);
                
                if (constexpr.IS_CONST(b64lo)
                 && constexpr.IS_CONST(b64hi))
                {
                    v256 rlo = mm256_constdiv_epu64(a64lo, b64lo);
                    v256 rhi = mm256_constdiv_epu64(a64hi, b64hi);
                    result = mm256_cvt2x2epi64_epi32(rlo, rhi);
                }
                else
                {
                    v256 rlo = Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a64lo), mm256_usfcvtepu64_pd(b64lo));
                    v256 rhi = Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a64hi), mm256_usfcvtepu64_pd(b64hi));
                    result = mm256_cvtt2x2pd_epu32(rlo, rhi);
                }

                //constexpr.ASSUME_DIVISION_EPU32(result, a, b);
                return result;
            }
            else throw new IllegalInstructionException();
        }
    }
}
