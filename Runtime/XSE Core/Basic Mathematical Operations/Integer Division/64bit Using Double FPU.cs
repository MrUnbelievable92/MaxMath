using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
    // David Monniaux, Alice Pain. Formally verified 32- and 64-bit integer division using double-precision floating-point arithmetic. 2022. hal-03722203￿
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu64(v128 a, v128 b, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<ulong2, ulong>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epu64(a, b);
                }

                return impl_div_epu64(a, b, useFPU, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu64(v256 a, v256 b, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<ulong4, ulong>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epu64(a, b, elements);
                }

                return mm256_impl_div_epu64(a, b, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu64(v128 a, v128 b, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<ulong2, ulong>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constrem_epu64(a, b);
                }

                v128 result;
                if (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT))
                 && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT)))
                {
                    v128 quotient = cvttpd_epu64(div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));

                    result = sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }
                else
                {
                    if (useFPU && !(constexpr.IS_CONST(a) && constexpr.IS_CONST(b)))
                    {
                        result =  sub_epi64(a, mullo_epi64(div_epu64(a, b, true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max), b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                    }
                    else
                    {
                        result =  new v128(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1);
                    }
                }

                constexpr.ASSUME_LT_EPU64(result, b);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu64(v256 a, v256 b, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<ulong4, ulong>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epu64(a, b, elements);
                }

                v256 result;

                if (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements))
                 && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements)))
                {
                    v256 quotient = mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)), elements: elements);

                    result = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }
                else
                {
                    result = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(mm256_div_epu64(a, b, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, elements), b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }

                constexpr.ASSUME_LT_EPU64(result, b, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu64(v128 a, v128 b, out v128 rem, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<ulong2, ulong>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    rem =  constrem_epu64(a, b);
                    return constdiv_epu64(a, b);
                }

                return impl_divrem_epu64(a, b, out rem, useFPU, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu64(v256 a, v256 b, out v256 rem, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<ulong4, ulong>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    rem =  mm256_constrem_epu64(a, b, elements);
                    return mm256_constdiv_epu64(a, b, elements);
                }

                return mm256_impl_divrem_epu64(a, b, out rem, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi64(v128 a, v128 b, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<long2, long>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epi64(a, b);
                }
                if (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT)))
                 && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))))
                {
                    return cvttpd_epi64(div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));
                }

                if (useFPU && !(constexpr.IS_CONST(a) && constexpr.IS_CONST(b)))
                {
                    v128 unsignedQuotient = div_epu64(abs_epi64(a), abs_epi64(b), true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max);

                    return SIGNED_FROM_UNSIGNED_DIV_EPI64(out _, a, b, unsignedQuotient, default(v128));
                }
                else
                {
                    return new v128(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi64(v256 a, v256 b, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<long4, long>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epi64(a, b, elements);
                }
                if (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements)))
                 && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))))
                {
                    return mm256_cvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)), elements: elements);
                }

                v256 unsignedQuotient = mm256_div_epu64(mm256_abs_epi64(a, elements), mm256_abs_epi64(b, elements), aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, elements);

                return SIGNED_FROM_UNSIGNED_DIV_EPI64(out _, a, b, unsignedQuotient, default(v256), elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi64(v128 a, v128 b, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<long2, long>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constrem_epi64(a, b);
                }
                if (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT)))
                 && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))))
                {
                    v128 quotient = cvttpd_epi64(div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));

                    return sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }

                if (useFPU && !(constexpr.IS_CONST(a) && constexpr.IS_CONST(b)))
                {
                    v128 unsignedRemainder = rem_epu64(abs_epi64(a), abs_epi64(b), true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max);

                    SIGNED_FROM_UNSIGNED_DIV_EPI64(out v128 signedRemainder, a, b, default(v128), unsignedRemainder);

                    return signedRemainder;
                }
                else
                {
                    return new v128(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi64(v256 a, v256 b, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<long4, long>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epi64(a, b, elements);
                }
                if (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements)))
                 && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))))
                {
                    v256 quotient = mm256_cvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)), elements: elements);

                    return Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }

                v256 unsignedRemainder = mm256_rem_epu64(mm256_abs_epi64(a, elements), mm256_abs_epi64(b, elements), aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, elements);

                SIGNED_FROM_UNSIGNED_DIV_EPI64(out v256 signedRemainder, a, b, default(v256), unsignedRemainder);

                return signedRemainder;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi64(v128 a, v128 b, out v128 rem, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<long2, long>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    rem =  constrem_epi64(a, b);
                    return constdiv_epi64(a, b);
                }
                if (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT)))
                 && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))))
                {
                    v128 quotient = cvttpd_epi64(div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));
                    rem = sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));

                    return quotient;
                }

                if (useFPU && !(constexpr.IS_CONST(a) && constexpr.IS_CONST(b)))
                {
                    v128 unsignedQuotient = divrem_epu64(abs_epi64(a), abs_epi64(b), out v128 unsigendRemainder, true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max);

                    return SIGNED_FROM_UNSIGNED_DIV_EPI64(out rem, a, b, unsignedQuotient, unsigendRemainder);
                }
                else
                {
                    rem = new v128(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1);
                    return new v128(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi64(v256 a, v256 b, out v256 rem, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<long4, long>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    rem =  mm256_constrem_epi64(a, b, elements);
                    return mm256_constdiv_epi64(a, b, elements);
                }
                if (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements)))
                 && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))))
                {
                    v256 quotient = mm256_cvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)), elements: elements);
                    rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));

                    return quotient;
                }

                v256 unsignedQuotient = mm256_divrem_epu64(mm256_abs_epi64(a, elements), mm256_abs_epi64(b, elements), out v256 unsigendRemainder, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, elements);

                return SIGNED_FROM_UNSIGNED_DIV_EPI64(out rem, a, b, unsignedQuotient, unsigendRemainder);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_div_epu64(v128 a, v128 b, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT))
                 && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT)))
                {
                    return cvttpd_epu64(div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));
                }
                if (!useFPU || (constexpr.IS_CONST(a) && constexpr.IS_CONST(b)))
                {
                    return new v128(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1);
                }
                
                v128 rcpB = div_pd(set1_pd(1d), (bUSFcvt || bLEu32max) ? usfcvtepu64_pd(b) : cvtepu64_pd(b));
                v128 q1d = mul_pd((aUSFcvt || aLEu32max) ? usfcvtepu64_pd(a) : cvtepu64_pd(a), rcpB);

                v128 q;
                //if (Avx512.IsAvx512Supported)
                //{
                //    v128 q1 = cvtpd_epu64(q1d, promise: true, evenOnTie: true);
                //    v128 r1 = sub_epi64(a, mullo_epi64(b, q1, unsigned_A_lessequalU32Max: bLEu32max));
                //    v128 r1d = cvtepi64_pd(r1);
                //    v128 q3d = mul_pd(r1d, rcpB);
                //
                //    v128 q3 = cvtpd_epi64(q3d, promise: true, evenOnTie: true);
                //    v128 r3 = sub_epi64(r1, mullo_epi64(b, q3, unsigned_A_lessequalU32Max: bLEu32max));
                //    v128 q2 = sub_epi64(q3, srli_epi64(r3, 63));
                //
                //    q = add_epi64(q1, q2);
                //}
                //else
                //{
                      long loQ1 = cvtsd_si64x(q1d);
                      long hiQ1 = cvtsd_si64x(bsrli_si128(q1d, sizeof(double)));
                      long loR1 = (long)extract_epi64(a, 0) - ((long)extract_epi64(b, 0) * loQ1);
                      long hiR1 = (long)extract_epi64(a, 1) - ((long)extract_epi64(b, 1) * hiQ1);
                      v128 loR1d = cvtsi64x_sd(setzero_si128(), loR1);
                      v128 hiR1d = cvtsi64x_sd(setzero_si128(), hiR1);
                      v128 loQ3d = mul_sd(loR1d, rcpB);
                      v128 hiQ3d = mul_sd(hiR1d, bsrli_si128(rcpB, sizeof(double)));
                
                      // TODO extract remainder
                      long loQ3 = cvtsd_si64x(loQ3d);
                      long hiQ3 = cvtsd_si64x(hiQ3d);
                      long loR3 = loR1 - ((long)extract_epi64(b, 0) * loQ3);
                      long hiR3 = hiR1 - ((long)extract_epi64(b, 1) * hiQ3);
                      long loQ2 = loQ1 + loQ3;
                      long hiQ2 = hiQ1 + hiQ3;
                      long loQ = loQ2 - (long)((ulong)loR3 >> 63);
                      long hiQ = hiQ2 - (long)((ulong)hiR3 >> 63);

                      q = unpacklo_epi64(cvtsi64x_si128(loQ), cvtsi64x_si128(hiQ));
                //}

                v128 ONE = set1_epi64x(1);
                v128 divBy1 = cmpeq_epi64(b, ONE);
                v128 qEither0or1 = cmpgt_epi64(setzero_si128(), b); // <- code size optimization over lower latency (ILP). ZERO is used in mm256_mullo_epi64 (AVX2)
                v128 specialResult = blendv_si128(a, andnot_si128(cmplt_epu64(a, b), ONE), qEither0or1);
                v128 blendMSK = or_si128(divBy1, qEither0or1);

                return blendv_si128(q, specialResult, blendMSK);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_div_epu64(v256 a, v256 b, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements))
                 && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements)))
                {
                    return mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)), elements: elements);
                }
                if (constexpr.IS_CONST(a) && constexpr.IS_CONST(b))
                {
                    if (elements == 3)
                    {
                        return new v256(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1, a.ULong2 / b.ULong2, 0);
                    }
                    else
                    {
                        return new v256(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1, a.ULong2 / b.ULong2, a.ULong3 / b.ULong3);
                    }
                }

                v256 rcpB = Avx.mm256_div_pd(mm256_set1_pd(1d), (bUSFcvt || bLEu32max) ? mm256_usfcvtepu64_pd(b) : mm256_cvtepu64_pd(b, elements));
                v256 q1d = Avx.mm256_mul_pd((aUSFcvt || aLEu32max) ? mm256_usfcvtepu64_pd(a) : mm256_cvtepu64_pd(a, elements), rcpB);

                v256 q1;
                //if (Avx512.IsAvx512Supported)
                //{
                //    q1 = mm256_cvtpd_epu64(q1d, elements, promise: true, evenOnTie: true);
                //}
                //else
                //{
                      q1 = mm256_cvtpd_epu64(q1d, elements: elements, evenOnTie: false);
                //}
                v256 r1 = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(b, q1, elements, unsigned_A_lessequalU32Max: bLEu32max));
                v256 r1d = mm256_cvtepi64_pd(r1, elements);
                v256 q3d = Avx.mm256_mul_pd(r1d, rcpB);

                v256 q3;
                //if (Avx512.IsAvx512Supported)
                //{
                //    q3 = mm256_cvtpd_epi64(q3d, elements, promise: true, evenOnTie: true);
                //}
                //else
                //{
                      q3 = mm256_cvtpd_epi64(q3d, elements: elements, evenOnTie: false);
                //}

                // TODO extract remainder
                v256 r3 = Avx2.mm256_sub_epi64(r1, mm256_mullo_epi64(b, q3, elements, unsigned_A_lessequalU32Max: bLEu32max));
                v256 q2 = Avx2.mm256_add_epi64(q1, q3);
                v256 q = Avx2.mm256_sub_epi64(q2, Avx2.mm256_srli_epi64(r3, 63));

                v256 ONE = mm256_set1_epi64x(1);
                v256 divBy1 = Avx2.mm256_cmpeq_epi64(b, ONE);
                v256 qEither0or1 = Avx2.mm256_cmpgt_epi64(Avx.mm256_setzero_si256(), b); // <- code size optimization over lower latency (ILP). ZERO is used in mm256_mullo_epi64 (AVX2)
                v256 specialResult = mm256_blendv_si256(a, Avx2.mm256_andnot_si256(mm256_cmplt_epu64(a, b, elements), ONE), qEither0or1);
                v256 blendMSK = Avx2.mm256_or_si256(divBy1, qEither0or1);

                return mm256_blendv_si256(q, specialResult, blendMSK);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 impl_divrem_epu64(v128 a, v128 b, out v128 rem, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT))
                 && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT)))
                {
                    v128 quotient = cvttpd_epu64(div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));
                    rem = sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));

                    return quotient;
                }

                if (useFPU && !(constexpr.IS_CONST(a) && constexpr.IS_CONST(b)))
                {
                    v128 quotient = impl_div_epu64(a, b, true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max);
                    rem = sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                    constexpr.ASSUME_LT_EPU64(rem, b);
                    return quotient;
                }
                else
                {
                    rem = new v128(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1);
                    constexpr.ASSUME_LT_EPU64(rem, b);
                    return new v128(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_impl_divrem_epu64(v256 a, v256 b, out v256 rem, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements))
                 && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements)))
                {
                    v256 quotient = mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)), elements: elements);
                    rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                    constexpr.ASSUME_LT_EPU64(rem, b, elements);

                    return quotient;
                }
                else
                {
                    v256 quotient = mm256_impl_div_epu64(a, b, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, elements);
                    rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                    constexpr.ASSUME_LT_EPU64(rem, b, elements);
                    return quotient;
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}
