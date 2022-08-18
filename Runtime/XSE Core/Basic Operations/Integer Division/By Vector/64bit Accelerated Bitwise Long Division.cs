using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
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
            }

            return new v128(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1);
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


                if (elements == 3)
                {
                    return new v256(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1, a.ULong2 / b.ULong2, 0ul);
                }
                else
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = Avx.mm256_set1_epi64x(1);

                    v256 shift = Avx2.mm256_sub_epi64(mm256_lzcnt_epi64(b), mm256_lzcnt_epi64(a));
                    b = Avx2.mm256_sllv_epi64(b, shift);
                    v256 setZero = mm256_cmpgt_epu64(b, a);
                    a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(setZero, b));
                    v256 quotient = Avx2.mm256_andnot_si256(setZero, ONE);
                    
                    b = Avx2.mm256_srli_epi64(b, 1);
                    v256 foundResultMask = Avx2.mm256_cmpeq_epi64(shift, ZERO);
                    v256 result = Avx2.mm256_and_si256(quotient, foundResultMask);
                    shift = Avx2.mm256_sub_epi64(shift, ONE);

                    while (mm256_notalltrue_epi256<ulong>(mm256_cmpgt_epi64(ZERO, shift), 4))
                    {
                        quotient = Avx2.mm256_slli_epi64(quotient, 1);
                    
                        setZero = mm256_cmpgt_epu64(b, a);
                        a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(setZero, b));
                        quotient = mm256_ternarylogic_si256(setZero, ONE, quotient, TernaryOperation.OxAE);

                        b = Avx2.mm256_srli_epi64(b, 1);
                        foundResultMask = Avx2.mm256_cmpeq_epi64(shift, ZERO);
                        result = mm256_ternarylogic_si256(result, quotient, foundResultMask, TernaryOperation.OxF8);
                        shift = Avx2.mm256_sub_epi64(shift, ONE);
                    } 
                    
                    return result;
                }
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


                if (elements == 3)
                {
                    return new v256(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1, a.ULong2 % b.ULong2, 0ul);
                }
                else
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 shift = Avx2.mm256_sub_epi64(mm256_lzcnt_epi64(b), mm256_lzcnt_epi64(a));
                    b = Avx2.mm256_sllv_epi64(b, shift);
                    a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(mm256_cmpgt_epu64(b, a), b));
                    b = Avx2.mm256_srli_epi64(b, 1);
                    
                    shift = mm256_dec_epi64(shift);
                    v256 foundResultMask = mm256_cmpgt_epi64(ZERO, shift);
                    v256 result = Avx2.mm256_and_si256(a, foundResultMask);

                    while (mm256_notalltrue_epi256<ulong>(mm256_cmpgt_epi64(ZERO, shift), 4))
                    {
                        a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(mm256_cmpgt_epu64(b, a), b));
                        b = Avx2.mm256_srli_epi64(b, 1);
                        
                        foundResultMask = Avx2.mm256_cmpeq_epi64(shift, ZERO);
                        result = mm256_ternarylogic_si256(result, a, foundResultMask, TernaryOperation.OxF8);

                        shift = mm256_dec_epi64(shift);
                    } 
            
                    return result;
                }
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
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements) && constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements))
                {
                    v256 quotient = mm256_usfcvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)));
                    rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements)); 

                    return quotient;
                }


                if (elements == 3)
                {
                    rem = new v256(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1, a.ULong2 % b.ULong2, 0ul);
                    return new v256(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1, a.ULong2 / b.ULong2, 0ul);
                }
                else
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = Avx.mm256_set1_epi64x(1);

                    v256 shift = Avx2.mm256_sub_epi64(mm256_lzcnt_epi64(b), mm256_lzcnt_epi64(a));
                    b = Avx2.mm256_sllv_epi64(b, shift);
                    v256 setZero = mm256_cmpgt_epu64(b, a);
                    a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(setZero, b));
                    v256 quotient = Avx2.mm256_andnot_si256(setZero, ONE);
                    b = Avx2.mm256_srli_epi64(b, 1);

                    v256 foundResultMask = Avx2.mm256_cmpeq_epi64(shift, ZERO);
                    v256 result = Avx2.mm256_and_si256(quotient, foundResultMask);

                    shift = Avx2.mm256_sub_epi64(shift, ONE);
                    foundResultMask = mm256_cmpgt_epi64(ZERO, shift);
                    rem = Avx2.mm256_and_si256(a, foundResultMask);

                    while (mm256_notalltrue_epi256<ulong>(foundResultMask, 4))
                    {
                        quotient = Avx2.mm256_slli_epi64(quotient, 1);
                    
                        setZero = mm256_cmpgt_epu64(b, a);
                        a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(setZero, b));
                        quotient = mm256_ternarylogic_si256(setZero, ONE, quotient, TernaryOperation.OxAE);
                        b = Avx2.mm256_srli_epi64(b, 1);

                        foundResultMask = Avx2.mm256_cmpeq_epi64(shift, ZERO);
                        result = mm256_ternarylogic_si256(result, quotient, foundResultMask, TernaryOperation.OxF8);
                        rem = mm256_ternarylogic_si256(rem, a, foundResultMask, TernaryOperation.OxF8);

                        shift = Avx2.mm256_sub_epi64(shift, ONE);
                        foundResultMask = mm256_cmpgt_epi64(ZERO, shift);
                    } 
                    
                    return result;
                }
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


                if (elements == 3)
                {
                    return new v256(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1, a.SLong2 / b.SLong2, 0L);
                }
                else
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 leftNegative = mm256_cmpgt_epi64(ZERO, a);
                    v256 rightNegative = mm256_cmpgt_epi64(ZERO, b);
                    a = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, leftNegative), leftNegative);
                    b = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(b, rightNegative), rightNegative);

                    v256 quotient = mm256_div_epu64(a, b, elements);
                    v256 mustNegate = Avx2.mm256_xor_si256(leftNegative, rightNegative);
                    
                    return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(quotient, mustNegate), mustNegate);
                }
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


                if (elements == 3)
                {
                    return new v256(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1, a.SLong2 % b.SLong2, 0L);
                }
                else
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 leftNegative = mm256_cmpgt_epi64(ZERO, a);
                    v256 rightNegative = mm256_cmpgt_epi64(ZERO, b);
                    a = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, leftNegative), leftNegative);
                    b = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(b, rightNegative), rightNegative);

                    v256 remainder = mm256_rem_epu64(a, b);

                    return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(remainder, leftNegative), leftNegative);
                }
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
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))
                {
                    v256 quotient = mm256_usfcvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)));
                    rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements)); 

                    return quotient;
                }


                if (elements == 3)
                {
                    rem = new v256(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1, a.SLong2 % b.SLong2, 0L);
                    return new v256(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1, a.SLong2 / b.SLong2, 0L);
                }
                else
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 leftNegative = mm256_cmpgt_epi64(ZERO, a);
                    v256 rightNegative = mm256_cmpgt_epi64(ZERO, b);
                    a = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, leftNegative), leftNegative);
                    b = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(b, rightNegative), rightNegative);

                    v256 quotient = mm256_divrem_epu64(a, b, out v256 remainders);
                    rem = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(remainders, leftNegative), leftNegative);
                    v256 mustNegate = Avx2.mm256_xor_si256(leftNegative, rightNegative);
                    
                    return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(quotient, mustNegate), mustNegate);
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}
