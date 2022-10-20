using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
    // David Monniaux, Alice Pain. Formally verified 32- and 64-bit integer division using double-precision floating-point arithmetic. 2022. hal-03722203￿
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.AreNotEqual(b.ULong0, 0ul);
Assert.AreNotEqual(b.ULong1, 0ul);
                
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.div_epu64(a, b);
                }
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT) && constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT))
                {
                    return usfcvttpd_epu64(Sse2.div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));
                }

                
                return new v128(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1);
            }
            else throw new IllegalInstructionException();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.AreNotEqual(b.ULong0, 0ul);
Assert.AreNotEqual(b.ULong1, 0ul);
Assert.AreNotEqual(b.ULong2, 0ul);
if (elements > 3)     
Assert.AreNotEqual(b.ULong3, 0ul);

                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_div_epu64(a, b, elements);

                }
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements) && constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements))
                {
                    return mm256_usfcvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)));
                }
                
                
                v256 rcpB = Avx.mm256_div_pd(Avx.mm256_set1_pd(1d), mm256_cvtepu64_pd(b, elements));
                v256 q1d = Avx.mm256_mul_pd(mm256_cvtepu64_pd(a, elements), rcpB);
                
                v256 q1 = mm256_cvtpd_epu64(q1d, elements, promise: true, evenOnTie: false);
                v256 r1 = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(b, q1, elements));
                v256 r1d = mm256_cvtepi64_pd(r1, elements);
                v256 q3d = Avx.mm256_mul_pd(r1d, rcpB);
                
                v256 q3 = mm256_cvtpd_epi64(q3d, elements, promise: true, evenOnTie: false);
                v256 r3 = Avx2.mm256_sub_epi64(r1, mm256_mullo_epi64(b, q3, elements));
                v256 q2 = Avx2.mm256_add_epi64(q3, mm256_srai_epi64(r3, 63));
                    
                v256 q = Avx2.mm256_add_epi64(q1, q2);
                
                v256 ONE = Avx.mm256_set1_epi64x(1);
                v256 divBy1 = Avx2.mm256_cmpeq_epi64(b, ONE);
                v256 qEither0or1 = Avx2.mm256_cmpgt_epi64(Avx.mm256_setzero_si256(), b); // <- code size optimization over lower latency (ILP). ZERO is used in mm256_mullo_epi64 (AVX2)
                v256 specialResult = mm256_blendv_si256(a, Avx2.mm256_andnot_si256(mm256_cmplt_epu64(a, b, elements), ONE), qEither0or1);
                v256 blendMSK = Avx2.mm256_or_si256(divBy1, qEither0or1);
                
                q = mm256_blendv_si256(q, specialResult, blendMSK);
                
                return q;
            }
            else throw new IllegalInstructionException();
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.AreNotEqual(b.ULong0, 0ul);
Assert.AreNotEqual(b.ULong1, 0ul);

                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.rem_epu64(a, b);
                }
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT) && constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT))
                {
                    v128 quotient = usfcvttpd_epu64(Sse2.div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));

                    return Sse2.sub_epi64(a, mullo_epi64(quotient, b));
                }
            }
                
            return new v128(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.AreNotEqual(b.ULong0, 0ul);
Assert.AreNotEqual(b.ULong1, 0ul);
Assert.AreNotEqual(b.ULong2, 0ul);
if (elements > 3)     
Assert.AreNotEqual(b.ULong3, 0ul);

                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_rem_epu64(a, b, elements);
                }
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements) && constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements))
                {
                    v256 quotient = mm256_usfcvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)));

                    return Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements));
                }


                return Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(mm256_div_epu64(a, b, elements), b, elements));
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu64(v128 a, v128 b, out v128 rem)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.AreNotEqual(b.ULong0, 0ul);
Assert.AreNotEqual(b.ULong1, 0ul);

                if (Constant.IsConstantExpression(b))
                {
                    rem =  constexpr.rem_epu64(a, b);
                    return constexpr.div_epu64(a, b);
                }
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT) && constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT))
                {
                    v128 quotient = usfcvttpd_epu64(Sse2.div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));
                    rem = Sse2.sub_epi64(a, mullo_epi64(quotient, b)); 

                    return quotient;
                }
            }

            rem = new v128(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1);
            return new v128(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu64(v256 a, v256 b, out v256 rem, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.AreNotEqual(b.ULong0, 0ul);
Assert.AreNotEqual(b.ULong1, 0ul);
Assert.AreNotEqual(b.ULong2, 0ul);
if (elements > 3)     
Assert.AreNotEqual(b.ULong3, 0ul);

                if (Constant.IsConstantExpression(b))
                {
                    rem =  constexpr.mm256_rem_epu64(a, b, elements);
                    return constexpr.mm256_div_epu64(a, b, elements);
                }


                v256 quotient = mm256_div_epu64(a, b);
                rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements));
                return quotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.AreNotEqual(b.SLong0, 0L);
Assert.AreNotEqual(b.SLong1, 0L);

                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.div_epi64(a, b);
                }
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    return usfcvttpd_epi64(Sse2.div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));
                }
            }

            return new v128(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.AreNotEqual(b.SLong0, 0L);
Assert.AreNotEqual(b.SLong1, 0L);
Assert.AreNotEqual(b.SLong2, 0L);
if (elements > 3)     
Assert.AreNotEqual(b.SLong3, 0L);

                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_div_epi64(a, b, elements);
                }
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))
                {
                    return mm256_usfcvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)));
                }


                v256 ZERO = Avx.mm256_setzero_si256();
                
                v256 leftNegative = mm256_cmpgt_epi64(ZERO, a, elements);
                v256 rightNegative = mm256_cmpgt_epi64(ZERO, b, elements);
                v256 mustNegate = Avx2.mm256_xor_si256(leftNegative, rightNegative);
                a = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, leftNegative), leftNegative);
                b = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(b, rightNegative), rightNegative);
                
                v256 quotient = mm256_div_epu64(a, b, elements);
                
                return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(quotient, mustNegate), mustNegate);
            }
            else throw new IllegalInstructionException();
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.AreNotEqual(b.SLong0, 0L);
Assert.AreNotEqual(b.SLong1, 0L);

                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.rem_epi64(a, b);
                }
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    v128 quotient = usfcvttpd_epi64(Sse2.div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));

                    return Sse2.sub_epi64(a, mullo_epi64(quotient, b));
                }
            }
                
            return new v128(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.AreNotEqual(b.SLong0, 0L);
Assert.AreNotEqual(b.SLong1, 0L);
Assert.AreNotEqual(b.SLong2, 0L);
if (elements > 3)     
Assert.AreNotEqual(b.SLong3, 0L);

                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_rem_epi64(a, b, elements);
                }
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))
                {
                    v256 quotient = mm256_usfcvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)));

                    return Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements));
                }


                v256 ZERO = Avx.mm256_setzero_si256();
                
                v256 leftNegative = mm256_cmpgt_epi64(ZERO, a, elements);
                v256 rightNegative = mm256_cmpgt_epi64(ZERO, b, elements);
                a = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, leftNegative), leftNegative);
                b = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(b, rightNegative), rightNegative);
                
                v256 remainder = mm256_rem_epu64(a, b, elements);
                
                return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(remainder, leftNegative), leftNegative);
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi64(v128 a, v128 b, out v128 rem)
        {
            if (Sse2.IsSse2Supported)
            {
Assert.AreNotEqual(b.SLong0, 0L);
Assert.AreNotEqual(b.SLong1, 0L);

                if (Constant.IsConstantExpression(b))
                {
                    rem =  constexpr.rem_epi64(a, b);
                    return constexpr.div_epi64(a, b);
                }
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    v128 quotient = usfcvttpd_epi64(Sse2.div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));
                    rem = Sse2.sub_epi64(a, mullo_epi64(quotient, b)); 

                    return quotient;
                }
            }

            rem = new v128(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1);
            return new v128(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi64(v256 a, v256 b, out v256 rem, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.AreNotEqual(b.SLong0, 0L);
Assert.AreNotEqual(b.SLong1, 0L);
Assert.AreNotEqual(b.SLong2, 0L);
if (elements > 3)     
Assert.AreNotEqual(b.SLong3, 0L);

                if (Constant.IsConstantExpression(b))
                {
                    rem =  constexpr.mm256_rem_epi64(a, b, elements);
                    return constexpr.mm256_div_epi64(a, b, elements);
                }
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    v256 quotient = mm256_usfcvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)));
                    rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements)); 

                    return quotient;
                }


                v256 ZERO = Avx.mm256_setzero_si256();
                
                v256 leftNegative = mm256_cmpgt_epi64(ZERO, a, elements);
                v256 rightNegative = mm256_cmpgt_epi64(ZERO, b, elements);
                v256 mustNegate = Avx2.mm256_xor_si256(leftNegative, rightNegative);
                a = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, leftNegative), leftNegative);
                b = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(b, rightNegative), rightNegative);
                
                v256 quotientU = mm256_divrem_epu64(a, b, out v256 remainders, elements);
                rem = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(remainders, leftNegative), leftNegative);
                
                return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(quotientU, mustNegate), mustNegate);
            }
            else throw new IllegalInstructionException();
        }
    }
}
