using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu32(v128 a, v128 b, byte elements = 4)
        {
Assert.AreNotEqual(b.UInt0, 0u);
Assert.AreNotEqual(b.UInt1, 0u);
if (elements > 2)    
Assert.AreNotEqual(b.UInt2, 0u);
if (elements > 3)    
Assert.AreNotEqual(b.UInt3, 0u);

            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.div_epu32(a, b, elements);
                }
                if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements) && constexpr.ALL_LE_EPU32(b, ushort.MaxValue, elements))
                {
                    return Sse2.cvttps_epi32(DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(a), Sse2.cvtepi32_ps(b)));
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return div_epi32(a, b);
                }


                if (elements >= 3)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 a64 = Avx2.mm256_cvtepu32_epi64(a);
                        v256 b64 = Avx2.mm256_cvtepu32_epi64(b);
                
                        v256 r64 = mm256_usfcvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a64), mm256_usfcvtepu64_pd(b64)));
                
                        return mm256_cvtepi64_epi32(r64);
                    }
                    else
                    {
                        v128 aLo = cvt2x2epu32_pd(a, out v128 aHi);
                        v128 bLo = cvt2x2epu32_pd(b, out v128 bHi);
                
                        return usfcvtt2x2pd_epu32(Sse2.div_pd(aLo, bLo), Sse2.div_pd(aHi, bHi));
                    }
                }
                else
                {
                    return cvtepi64_epi32(usfcvttpd_epu64(Sse2.div_pd(cvtepu32_pd(a), cvtepu32_pd(b))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu32(v256 a, v256 b)
        {
Assert.AreNotEqual(b.UInt0, 0u);
Assert.AreNotEqual(b.UInt1, 0u);
Assert.AreNotEqual(b.UInt2, 0u);
Assert.AreNotEqual(b.UInt3, 0u);
Assert.AreNotEqual(b.UInt4, 0u);
Assert.AreNotEqual(b.UInt5, 0u);
Assert.AreNotEqual(b.UInt6, 0u);
Assert.AreNotEqual(b.UInt7, 0u);

            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_div_epu32(a, b);
                }
                if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue) && constexpr.ALL_LE_EPU32(b, ushort.MaxValue))
                {
                    return Avx.mm256_cvttps_epi32(DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b)));
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return mm256_div_epi32(a, b);
                }


                v256 a64Lo = mm256_cvt2x2epu32_pd(a, out v256 a64Hi);
                v256 b64Lo = mm256_cvt2x2epu32_pd(b, out v256 b64Hi);
                
                return mm256_usfcvtt2x2pd_epu32(Avx.mm256_div_pd(a64Lo, b64Lo), Avx.mm256_div_pd(a64Hi, b64Hi));
            }
            else throw new IllegalInstructionException();
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi32(v128 a, v128 b, byte elements = 4)
        {
Assert.AreNotEqual(b.SInt0, 0);
Assert.AreNotEqual(b.SInt1, 0);
if (elements > 2)
Assert.AreNotEqual(b.SInt2, 0);
if (elements > 3)
Assert.AreNotEqual(b.SInt3, 0);
                
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.div_epi32(a, b, elements);
                }
                if (constexpr.ALL_GE_EPI32(a, -ushort.MinValue, elements) && constexpr.ALL_LE_EPI32(a, ushort.MaxValue, elements) &&
                    constexpr.ALL_GE_EPI32(b, -ushort.MaxValue, elements) && constexpr.ALL_LE_EPI32(b, ushort.MaxValue, elements))
                {
                    return Sse2.cvttps_epi32(DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(a), Sse2.cvtepi32_ps(b)));
                }
                

                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_cvttpd_epi32(Avx.mm256_div_pd(Avx.mm256_cvtepi32_pd(a), Avx.mm256_cvtepi32_pd(b)));
                }
                else
                {
                    if (elements >= 3)
                    {
                        v128 aLo = cvt2x2epi32_pd(a, out v128 aHi);
                        v128 bLo = cvt2x2epi32_pd(b, out v128 bHi);
                        
                        return usfcvtt2x2pd_epi32(Sse2.div_pd(aLo, bLo), Sse2.div_pd(aHi, bHi));
                    }
                    else
                    {
                        return Sse2.cvttpd_epi32(Sse2.div_pd(Sse2.cvtepi32_pd(a), Sse2.cvtepi32_pd(b)));
                    }

                }            
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi32(v256 a, v256 b)
        {
Assert.AreNotEqual(b.SInt0, 0);
Assert.AreNotEqual(b.SInt1, 0);
Assert.AreNotEqual(b.SInt2, 0);
Assert.AreNotEqual(b.SInt3, 0);
Assert.AreNotEqual(b.SInt4, 0);
Assert.AreNotEqual(b.SInt5, 0);
Assert.AreNotEqual(b.SInt6, 0);
Assert.AreNotEqual(b.SInt7, 0);

            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_div_epi32(a, b);
                }
                if (constexpr.ALL_GE_EPI32(a, -ushort.MinValue) && constexpr.ALL_LE_EPI32(a, ushort.MaxValue) &&
                    constexpr.ALL_GE_EPI32(b, -ushort.MinValue) && constexpr.ALL_LE_EPI32(b, ushort.MaxValue))
                {
                    return Avx.mm256_cvttps_epi32(DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b)));
                }


                v256 a64Lo = mm256_cvt2x2epi32_epi64(a, out v256 a64Hi);
                v256 b64Lo = mm256_cvt2x2epi32_epi64(b, out v256 b64Hi);
                
                return mm256_usfcvtt2x2pd_epi32(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a64Lo), mm256_usfcvtepi64_pd(b64Lo)), Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a64Hi), mm256_usfcvtepi64_pd(b64Hi)));
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.rem_epu32(a, b, elements);
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return rem_epi32(a, b);
                }
                

                return Sse2.sub_epi32(a, mullo_epi32(div_epu32(a, b), b, elements)); 
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_rem_epu32(a, b);
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return mm256_rem_epi32(a, b);
                }
                    
                
                return Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_div_epu32(a, b), b)); 
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.rem_epi32(a, b, elements);
                }

                
                return Sse2.sub_epi32(a, mullo_epi32(div_epi32(a, b), b, elements)); 
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(b))
                {
                    return constexpr.mm256_rem_epi32(a, b);
                }

                
                return Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_div_epi32(a, b), b)); 
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu32(v128 a, v128 b, out v128 rem, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotient = div_epu32(a, b, elements);
                rem = Sse2.sub_epi32(a, mullo_epi32(quotient, b, elements));

                return quotient;
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu32(v256 a, v256 b, out v256 rem)
        {
            if (Sse2.IsSse2Supported)
            {
                v256 quotient = mm256_div_epu32(a, b);
                rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b)); 

                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi32(v128 a, v128 b, out v128 rem, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotient = div_epi32(a, b, elements);
                rem = Sse2.sub_epi32(a, mullo_epi32(quotient, b, elements));

                return quotient;
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi32(v256 a, v256 b, out v256 rem)
        {
            if (Sse2.IsSse2Supported)
            {
                v256 quotient = mm256_div_epi32(a, b);
                rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b)); 

                return quotient;
            }
            else throw new IllegalInstructionException();
        }
    }
}
