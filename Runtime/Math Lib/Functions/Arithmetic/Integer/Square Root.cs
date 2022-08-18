using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi8(v128 a, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (elements <= 4)
                    {
                        v128 toFloat = Xse.cvtepu8_ps(a);
                        v128 sqrt = Sse.rcp_ps(Sse.rsqrt_ps(toFloat));
                        v128 toInt = Sse2.cvttps_epi32(sqrt);

                        a = Xse.cvtepi32_epi8(toInt, elements);
                    }
                    else if (elements <= 8)
                    {
                        v128 toFloat_lo = Xse.cvtepu8_ps(a);
                        v128 toFloat_hi = Xse.cvtepu8_ps(Sse2.bsrli_si128(a, 4 * sizeof(byte)));
                        v128 sqrt_lo = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_lo));
                        v128 sqrt_hi = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_hi));

                        v128 shorts = Sse2.packs_epi32(Sse2.cvttps_epi32(sqrt_lo), Sse2.cvttps_epi32(sqrt_hi));
                        
                        a = Sse2.packus_epi16(shorts, shorts);
                    }
                    else
                    {
                        v128 shortsLo = cvt2x2epu8_epi16(a, out v128 shortsHi);
                        v128 toFloat_0 = cvt2x2epu16_ps(shortsLo, out v128 toFloat_1);
                        v128 toFloat_2 = cvt2x2epu16_ps(shortsHi, out v128 toFloat_3);

                        v128 sqrt_0 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_0));
                        v128 sqrt_1 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_1));
                        v128 sqrt_2 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_2));
                        v128 sqrt_3 = Sse.rcp_ps(Sse.rsqrt_ps(toFloat_3));

                        shortsLo = Sse2.packs_epi32(Sse2.cvttps_epi32(sqrt_0), Sse2.cvttps_epi32(sqrt_1));
                        shortsHi = Sse2.packs_epi32(Sse2.cvttps_epi32(sqrt_2), Sse2.cvttps_epi32(sqrt_3));

                        a = Sse2.packus_epi16(shortsLo, shortsHi);
                    }

                    constexpr.ASSUME_LE_EPU8(a, 15);

                    return a;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 shortsLo = mm256_cvt2x2epu8_epi16(a, out v256 shortsHi);
                    v256 floats_0_1_2_3___16_17_18_19 = mm256_cvt2x2epu16_ps(shortsLo, out v256 floats_4_5_6_7___20_21_22_23);
                    v256 floats_8_9_10_11___24_25_26_27 = mm256_cvt2x2epu16_ps(shortsHi, out v256 floats_12_13_14_15___28_29_30_31);

                    v256 sqrt_lo  = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(floats_0_1_2_3___16_17_18_19));
                    v256 sqrt_hi  = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(floats_4_5_6_7___20_21_22_23));
                    v256 sqrt_lo2 = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(floats_8_9_10_11___24_25_26_27));
                    v256 sqrt_hi2 = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(floats_12_13_14_15___28_29_30_31));

                    shortsLo = Avx2.mm256_packus_epi32(Avx.mm256_cvttps_epi32(sqrt_lo),  Avx.mm256_cvttps_epi32(sqrt_hi));
                    shortsHi = Avx2.mm256_packus_epi32(Avx.mm256_cvttps_epi32(sqrt_lo2), Avx.mm256_cvttps_epi32(sqrt_hi2));
                    
                    a = Avx2.mm256_packus_epi16(shortsLo, shortsHi);

                    constexpr.ASSUME_LE_EPU8(a, 15);

                    return a;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu8(v128 a, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 sqrt = sqrt_epi8(a, elements);
                    
                    if (!(constexpr.ALL_NEQ_EPU8(a, 225, elements) || constexpr.ALL_LT_EPU8(a, 225, elements) || constexpr.ALL_GT_EPU8(a, 225, elements)))
                    {
                        sqrt = Sse2.sub_epi8(sqrt, Sse2.cmpeq_epi8(a, Sse2.set1_epi8(unchecked((sbyte)225))));
                    }

                    constexpr.ASSUME_LE_EPU8(sqrt, 15);

                    return sqrt;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 sqrt = mm256_sqrt_epi8(a);

                    if (!(constexpr.ALL_NEQ_EPU8(a, 225) || constexpr.ALL_LT_EPU8(a, 225) || constexpr.ALL_GT_EPU8(a, 225)))
                    {
                        sqrt = Avx2.mm256_sub_epi8(sqrt, Avx2.mm256_cmpeq_epi8(a, Avx.mm256_set1_epi8(225)));
                    }

                    constexpr.ASSUME_LE_EPU8(sqrt, 11);

                    return sqrt;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi16(v128 a, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (elements <= 4)
                    {
                        if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                        {
                            v128 sqrt = Sse.rcp_ps(Sse.rsqrt_ps(cvtepu16_ps(a)));
                            v128 ints = Sse2.cvttps_epi32(sqrt);
                            ints = Sse2.packs_epi32(ints, ints);
                            
                            if (!(constexpr.ALL_NEQ_EPU16(a, 225, elements) || constexpr.ALL_LT_EPU16(a, 225, elements) || constexpr.ALL_GT_EPU16(a, 225, elements)))
                            {
                                ints = Sse2.sub_epi16(ints, Sse2.cmpeq_epi16(a, Sse2.set1_epi16(225)));
                            }

                            constexpr.ASSUME_LE_EPU16(ints, 15);

                            return ints;
                        }
                        else
                        {
                            v128 sqrt = Sse.sqrt_ps(cvtepu16_ps(a));
                            v128 ints = Sse2.cvttps_epi32(sqrt);
                            a = Sse2.packs_epi32(ints, ints);

                            constexpr.ASSUME_LE_EPU16(a, byte.MaxValue);

                            return a;
                        }
                    }
                    else
                    {
                        v128 lo = cvt2x2epu16_ps(a, out v128 hi);
                        
                        if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                        {
                            v128 sqrt_lo = Sse.rcp_ps(Sse.rsqrt_ps(lo));
                            v128 sqrt_hi = Sse.rcp_ps(Sse.rsqrt_ps(hi));
                            v128 shorts = Sse2.packs_epi32(Sse2.cvttps_epi32(sqrt_lo), Sse2.cvttps_epi32(sqrt_hi));
                            
                            if (!(constexpr.ALL_NEQ_EPU16(a, 225, elements) || constexpr.ALL_LT_EPU16(a, 225, elements) || constexpr.ALL_GT_EPU16(a, 225, elements)))
                            {
                                shorts = Sse2.sub_epi16(shorts, Sse2.cmpeq_epi16(a, Sse2.set1_epi16(225)));
                            }

                            constexpr.ASSUME_LE_EPU16(shorts, 15);

                            return shorts;
                        }
                        else
                        {
                            v128 sqrt_lo = Sse.sqrt_ps(lo);
                            v128 sqrt_hi = Sse.sqrt_ps(hi);
                            v128 shorts = Sse2.packs_epi32(Sse2.cvttps_epi32(sqrt_lo), Sse2.cvttps_epi32(sqrt_hi));

                            constexpr.ASSUME_LE_EPU16(shorts, byte.MaxValue);

                            return shorts;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 intsLo = mm256_cvt2x2epu16_ps(a, out v256 intsHi);

                    if (constexpr.ALL_LE_EPU16(a, byte.MaxValue))
                    {
                        v256 sqrtLo = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(intsLo));
                        v256 sqrtHi = Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(intsHi));
                        v256 shorts = mm256_usfcvt2x2ps_epu16(Avx.mm256_cvttps_epi32(sqrtLo), Avx.mm256_cvttps_epi32(sqrtHi));

                        if (!(constexpr.ALL_NEQ_EPU16(a, 225) || constexpr.ALL_LT_EPU16(a, 225) || constexpr.ALL_GT_EPU16(a, 225)))
                        {
                            shorts = Avx2.mm256_sub_epi16(shorts, Avx2.mm256_cmpeq_epi16(a, Avx.mm256_set1_epi16(225)));
                        }

                        constexpr.ASSUME_LE_EPU16(shorts, 15);

                        return shorts;
                    }
                    else
                    {
                        v256 sqrtLo = Avx.mm256_sqrt_ps(intsLo);
                        v256 sqrtHi = Avx.mm256_sqrt_ps(intsHi);
                        v256 shorts = Avx2.mm256_packus_epi32(Avx.mm256_cvttps_epi32(sqrtLo), Avx.mm256_cvttps_epi32(sqrtHi));

                        constexpr.ASSUME_LE_EPU16(shorts, byte.MaxValue);

                        return shorts;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu16(v128 a, byte elements = 8)
            {
                return sqrt_epi16(a, elements);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu16(v256 a)
            {
                return mm256_sqrt_epi16(a);
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                        {
                            v128 ints = Sse2.cvttps_epi32(Sse.rcp_ps(Sse.rsqrt_ps(Sse2.cvtepi32_ps(a))));

                            if (!(constexpr.ALL_NEQ_EPU32(a, 225, elements) || constexpr.ALL_LT_EPU32(a, 225, elements) || constexpr.ALL_GT_EPU32(a, 225, elements)))
                            {
                                ints = Sse2.sub_epi32(ints, Sse2.cmpeq_epi32(a, Sse2.set1_epi32(225)));
                            }

                            constexpr.ASSUME_LE_EPU32(ints, 15);

                            return ints;
                        }
                        else
                        {
                            v128 ints = Sse2.cvttps_epi32(Sse.sqrt_ps(Sse2.cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(ints, byte.MaxValue);

                            return ints;
                        }
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            a = Sse2.cvttpd_epi32(Sse2.sqrt_pd(Sse2.cvtepi32_pd(a)));
                        }
                        else
                        {
                            v128 sqrtLo = cvt2x2epi32_pd(a, out v128 sqrtHi);

                            sqrtLo = Sse2.cvttpd_epi32(Sse2.sqrt_pd(sqrtLo));
                            sqrtHi = Sse2.cvttpd_epi32(Sse2.sqrt_pd(sqrtHi));

                            a = Sse2.unpacklo_epi64(sqrtLo, sqrtHi);
                        }

                        constexpr.ASSUME_LE_EPU32(a, ushort.MaxValue);

                        return a;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                            if (!(constexpr.ALL_NEQ_EPU32(a, 225) || constexpr.ALL_LT_EPU32(a, 225) || constexpr.ALL_GT_EPU32(a, 225)))
                            {
                                ints = Avx2.mm256_sub_epi32(ints, Avx2.mm256_cmpeq_epi32(a, Avx.mm256_set1_epi32(225)));
                            }
                            
                            constexpr.ASSUME_LE_EPU32(ints, 15);

                            return ints;
                        }
                        else
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(ints, byte.MaxValue);

                            return ints;
                        }
                    }
                    else
                    {
                        v256 doublesLo = mm256_cvt2x2epi32_pd(a, out v256 doublesHi);

                        v128 sqrtLo = Avx.mm256_cvttpd_epi32(Avx.mm256_sqrt_pd(doublesLo));
                        v128 sqrtHi = Avx.mm256_cvttpd_epi32(Avx.mm256_sqrt_pd(doublesHi));

                        a = Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(sqrtLo), sqrtHi, 1);

                        constexpr.ASSUME_LE_EPU32(a, ushort.MaxValue);

                        return a;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                        {
                            v128 ints = Sse2.cvttps_epi32(Sse.rcp_ps(Sse.rsqrt_ps(Sse2.cvtepi32_ps(a))));

                            if (!(constexpr.ALL_NEQ_EPU32(a, 225, elements) || constexpr.ALL_LT_EPU32(a, 225, elements) || constexpr.ALL_GT_EPU32(a, 225, elements)))
                            {
                                ints = Sse2.sub_epi32(ints, Sse2.cmpeq_epi32(a, Sse2.set1_epi32(225)));
                            }

                            constexpr.ASSUME_LE_EPU32(ints, 15);

                            return ints;
                        }
                        else
                        {
                            v128 ints = Sse2.cvttps_epi32(Sse.sqrt_ps(Sse2.cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(ints, byte.MaxValue);

                            return ints;
                        }
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            a = Sse2.cvttpd_epi32(Sse2.sqrt_pd(cvtepu32_pd(a)));
                        }
                        else
                        {
                            v128 sqrtLo = cvt2x2epu32_pd(a, out v128 sqrtHi);

                            sqrtLo = Sse2.cvttpd_epi32(Sse2.sqrt_pd(sqrtLo));
                            sqrtHi = Sse2.cvttpd_epi32(Sse2.sqrt_pd(sqrtHi));

                            a = Sse2.unpacklo_epi64(sqrtLo, sqrtHi);
                        }

                        constexpr.ASSUME_LE_EPU32(a, ushort.MaxValue);

                        return a;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));
                        
                            if (!(constexpr.ALL_NEQ_EPU32(a, 225) || constexpr.ALL_LT_EPU32(a, 225) || constexpr.ALL_GT_EPU32(a, 225)))
                            {
                                ints = Avx2.mm256_sub_epi32(ints, Avx2.mm256_cmpeq_epi32(a, Avx.mm256_set1_epi32(225)));
                            }
                        
                            constexpr.ASSUME_LE_EPU32(ints, 15);

                            return ints;
                        }
                        else
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(ints, byte.MaxValue);

                            return ints;
                        }
                    }
                    else
                    {
                        v256 doublesLo = mm256_cvt2x2epu32_pd(a, out v256 doublesHi);

                        v256 sqrtLo = Avx.mm256_sqrt_pd(doublesLo);
                        v256 sqrtHi = Avx.mm256_sqrt_pd(doublesHi);
                        v256 ints =  mm256_usfcvtt2x2pd_epu32(sqrtLo, sqrtHi);

                        constexpr.ASSUME_LE_EPU32(ints, ushort.MaxValue);

                        return ints;
                    }
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                    {
                        if (constexpr.ALL_LE_EPU64(a, ushort.MaxValue))
                        {
                            if (constexpr.ALL_LE_EPU64(a, byte.MaxValue))
                            {
                                v128 ints = Sse2.cvttps_epi32(Sse.rcp_ps(Sse.rsqrt_ps(Sse2.cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU64(a, 225) || constexpr.ALL_LT_EPU64(a, 225) || constexpr.ALL_GT_EPU64(a, 225)))
                                {
                                    ints = Sse2.sub_epi64(ints, cmpeq_epi64(a, Sse2.set1_epi64x(225)));
                                }

                                constexpr.ASSUME_LE_EPU64(ints, 15);

                                return ints;
                            }
                            else
                            {
                                v128 ints = Sse2.cvttps_epi32(Sse.sqrt_ps(Sse2.cvtepi32_ps(a)));

                                constexpr.ASSUME_LE_EPU64(ints, byte.MaxValue);

                                return ints;
                            }
                        }
                        else
                        {
                            v128 ints = usfcvttpd_epu64(Sse2.sqrt_pd(usfcvtepu64_pd(a)));

                            constexpr.ASSUME_LE_EPU64(ints, ushort.MaxValue);

                            return ints;
                        }
                    }
                    else
                    {
                        v128 ZERO = Sse2.setzero_si128();
                        v128 ALL_ONES = setall_si128();

                        v128 mask = new v128(1ul << 62);

                        v128 lzcntX = lzcnt_epi64(a);
                        v128 shiftMask = neg_epi64(ALL_ONES);
                        mask = srlv_epi64(mask, Sse2.sub_epi64(lzcntX, Sse2.and_si128(lzcntX, shiftMask)));
                        shiftMask = Sse2.add_epi64(shiftMask, shiftMask);
                        mask = srlv_epi64(mask, Sse2.and_si128(cmpgt_epi64(mask, a), shiftMask));

                        bool notDone;
                        if (Sse4_1.IsSse41Supported)
                        {
                            notDone = Sse4_1.testz_si128(mask, mask) != 1;
                        }
                        else
                        {
                            notDone = 0x0000_FFFF != Sse2.movemask_epi8(cmpeq_epi64(mask, ZERO));
                        }
                        
                        v128 result = mask;

                        if (Hint.Likely(notDone))
                        {
                            v128 subFromX = Sse2.andnot_si128(cmpgt_epi64(mask, a), mask);
                            a = Sse2.sub_epi64(a, subFromX);
                            
                            mask = Sse2.srli_epi64(mask, 2);
                            v128 doneMask = cmpeq_epi64(mask, ZERO);
                            
                            while (Hint.Likely(0x0000_FFFF != Sse2.movemask_epi8(doneMask)))
                            {
                                v128 result_shifted = Sse2.srli_epi64(result, 1);
                                v128 result_added = Sse2.add_epi64(result, mask);
                                v128 blendMask = cmpgt_epi64(result_added, a);
                            
                                a = Sse2.sub_epi64(a, Sse2.andnot_si128(blendMask, result_added));
                                result = Sse2.add_epi64(blendv_si128(result_shifted, result, doneMask), 
                                                        ternarylogic_si128(doneMask, blendMask, mask, TernaryOperation.OxO2));

                                mask = Sse2.srli_epi64(mask, 2);
                            
                                doneMask = cmpeq_epi64(mask, ZERO);
                            }
                        }
                        
                        constexpr.ASSUME_LE_EPU64(result, 3_037_000_499);

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                    {
                        if (constexpr.ALL_LE_EPU64(a, ushort.MaxValue, elements))
                        {
                            if (constexpr.ALL_LE_EPU64(a, byte.MaxValue, elements))
                            {
                                v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU64(a, 225, elements) || constexpr.ALL_LT_EPU64(a, 225, elements) || constexpr.ALL_GT_EPU64(a, 225, elements)))
                                {
                                    ints = Avx2.mm256_sub_epi64(ints, Avx2.mm256_cmpeq_epi64(a, Avx.mm256_set1_epi64x(225)));
                                }

                                constexpr.ASSUME_LE_EPU64(ints, 15);

                                return ints;
                            }
                            else
                            {
                                v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                                constexpr.ASSUME_LE_EPU64(ints, byte.MaxValue);

                                return ints;
                            }
                        }
                        else
                        {
                            v256 ints = mm256_usfcvttpd_epu64(Avx.mm256_sqrt_pd(mm256_usfcvtepu64_pd(a)));

                            constexpr.ASSUME_LE_EPU64(ints, ushort.MaxValue);

                            return ints;
                        }
                    }
                    else
                    {
                        uint BITMASK = elements == 4 ? uint.MaxValue : 0x00FF_FFFF;
                        v256 ZERO = Avx.mm256_setzero_si256();
                        v256 ALL_ONES = mm256_setall_si256();

                        v256 mask = new v256(1ul << 62);

                        v256 lzcntX = mm256_lzcnt_epi64(a);
                        v256 shiftMask = mm256_neg_epi64(ALL_ONES);
                        mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_sub_epi64(lzcntX, Avx2.mm256_and_si256(lzcntX, shiftMask)));
                        shiftMask = Avx2.mm256_add_epi64(shiftMask, shiftMask);
                        mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_and_si256(mm256_cmpgt_epi64(mask, a, elements), shiftMask));

                        v256 doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                        v256 result = mask;

                        if (Hint.Likely(BITMASK != (BITMASK & Avx2.mm256_movemask_epi8(doneMask))))
                        {
                            v256 subFromX = Avx2.mm256_andnot_si256(mm256_cmpgt_epi64(mask, a, elements), mask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            
                            mask = Avx2.mm256_srli_epi64(mask, 2);
                            doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                            
                            while (Hint.Likely(BITMASK != (BITMASK & Avx2.mm256_movemask_epi8(doneMask))))
                            {
                                v256 result_shifted = Avx2.mm256_srli_epi64(result, 1);
                                v256 result_added = Avx2.mm256_add_epi64(result, mask);
                                v256 blendMask = mm256_cmpgt_epi64(result_added, a, elements);
                            
                                a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(blendMask, result_added));
                                result = Avx2.mm256_add_epi64(mm256_blendv_si256(result_shifted, result, doneMask), 
                                                              mm256_ternarylogic_si256(doneMask, blendMask, mask, TernaryOperation.OxO2));
                            
                                mask = Avx2.mm256_srli_epi64(mask, 2);
                            
                                doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                            }
                        }

                        constexpr.ASSUME_LE_EPU64(result, 3_037_000_499);

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, long.MaxValue))
                    {
                        return sqrt_epi64(a);
                    }
                    else
                    {
                        v128 ZERO = Sse2.setzero_si128();
                        v128 ALL_ONES = setall_si128();

                        v128 mask = new v128(1ul << 62);

                        v128 lzcntX = lzcnt_epi64(a);
                        v128 shiftMask = neg_epi64(ALL_ONES);
                        mask = srlv_epi64(mask, Sse2.sub_epi64(lzcntX, Sse2.and_si128(lzcntX, shiftMask)));
                        shiftMask = Sse2.add_epi64(shiftMask, shiftMask);
                        mask = srlv_epi64(mask, Sse2.and_si128(cmpgt_epu64(mask, a), shiftMask));

                        bool notDone;
                        if (Sse4_1.IsSse41Supported)
                        {
                            notDone = Sse4_1.testz_si128(mask, mask) != 1;
                        }
                        else
                        {
                            notDone = 0x0000_FFFF != Sse2.movemask_epi8(cmpeq_epi64(mask, ZERO));
                        }
                        
                        v128 result = mask;

                        if (Hint.Likely(notDone))
                        {
                            v128 subFromX = Sse2.andnot_si128(cmpgt_epu64(mask, a), mask);
                            a = Sse2.sub_epi64(a, subFromX);
                            
                            mask = Sse2.srli_epi64(mask, 2);
                            v128 doneMask = cmpeq_epi64(mask, ZERO);
                            
                            while (Hint.Likely(0x0000_FFFF != Sse2.movemask_epi8(doneMask)))
                            {
                                v128 result_shifted = Sse2.srli_epi64(result, 1);
                                v128 result_added = Sse2.add_epi64(result, mask);
                                v128 blendMask = cmpgt_epu64(result_added, a);
                            
                                a = Sse2.sub_epi64(a, Sse2.andnot_si128(blendMask, result_added));
                                result = Sse2.add_epi64(blendv_si128(result_shifted, result, doneMask), 
                                                        ternarylogic_si128(doneMask, blendMask, mask, TernaryOperation.OxO2));

                                mask = Sse2.srli_epi64(mask, 2);
                            
                                doneMask = cmpeq_epi64(mask, ZERO);
                            }
                        }
                        
                        constexpr.ASSUME_LE_EPU64(result, uint.MaxValue);

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, long.MaxValue, elements))
                    {
                        return mm256_sqrt_epi64(a, elements);
                    }
                    else
                    {
                        uint BITMASK = elements == 4 ? uint.MaxValue : 0x00FF_FFFF;
                        v256 ZERO = Avx.mm256_setzero_si256();
                        v256 ALL_ONES = mm256_setall_si256();

                        v256 mask = new v256(1ul << 62);

                        v256 lzcntX = mm256_lzcnt_epi64(a);
                        v256 shiftMask = mm256_neg_epi64(ALL_ONES);
                        mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_sub_epi64(lzcntX, Avx2.mm256_and_si256(lzcntX, shiftMask)));
                        shiftMask = Avx2.mm256_add_epi64(shiftMask, shiftMask);
                        mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_and_si256(mm256_cmpgt_epu64(mask, a), shiftMask));

                        v256 doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                        v256 result = mask;

                        if (Hint.Likely(BITMASK != (BITMASK & Avx2.mm256_movemask_epi8(doneMask))))
                        {
                            v256 subFromX = Avx2.mm256_andnot_si256(mm256_cmpgt_epu64(mask, a), mask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            
                            mask = Avx2.mm256_srli_epi64(mask, 2);
                            doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                            
                            while (Hint.Likely(BITMASK != (BITMASK & Avx2.mm256_movemask_epi8(doneMask))))
                            {
                                v256 result_shifted = Avx2.mm256_srli_epi64(result, 1);
                                v256 result_added = Avx2.mm256_add_epi64(result, mask);
                                v256 blendMask = mm256_cmpgt_epu64(result_added, a);
                            
                                a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(blendMask, result_added));
                                result = Avx2.mm256_add_epi64(mm256_blendv_si256(result_shifted, result, doneMask), 
                                                              mm256_ternarylogic_si256(doneMask, blendMask, mask, TernaryOperation.OxO2));
                            
                                mask = Avx2.mm256_srli_epi64(mask, 2);
                            
                                doneMask = Avx2.mm256_cmpeq_epi64(mask, ZERO);
                            }
                        }

                        constexpr.ASSUME_LE_EPU64(result, uint.MaxValue);

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        private static byte bytesqrt(byte x, bool unsigned)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mov = Sse2.cvtsi32_si128(x);
                v128 sqrt = Sse.rcp_ss(Sse.rsqrt_ss(Sse2.cvtepi32_ps(mov)));
                v128 toInt = Sse2.cvttps_epi32(sqrt);

                if (unsigned)
                {
                    return (byte)(Sse2.cvtsi128_si32(toInt) + tobyte(x == 225));
                }
                else
                {
                    return (byte)Sse2.cvtsi128_si32(toInt);
                }
            }
            else
            {
                return (byte)math.sqrt(x);
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="UInt128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intsqrt(UInt128 x)
        {
            UInt128 result = 0;
            UInt128 mask = (UInt128)1 << 126;

            int lzcntX = lzcnt(x);
            mask >>= lzcntX - (lzcntX & 1);
            if (Hint.Likely(mask > x))
            {                
                mask >>= 2;
            }

            if (Hint.Likely(mask.IsNotZero))
            {
                if (x >= mask)
                {
                    x -= mask;
                }

                result = mask;
                mask >>= 2;
                
                while (Hint.Likely(mask.IsNotZero))
                {
                    UInt128 resultAdded = result + mask;
                    result >>= 1;

                    if (x >= resultAdded)
                    {
                        x -= resultAdded;
                        result += mask;
                    }

                    mask >>= 2;
                }
            }

            return result.lo64;
        }

        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="Int128"/>.    </summary>
        [return: AssumeRange(0ul, 13_043_817_825_332_782_212ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intsqrt(Int128 x)
        {
Assert.IsNotSmaller(x, 0);

            return intsqrt((UInt128)x);
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="byte"/>.    </summary>
        [return: AssumeRange(0ul, 15ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte intsqrt(byte x)
        {
            return bytesqrt(x, unsigned: true);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intsqrt(byte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu8(x, 2);
            }
            else
            {
                return (byte2)math.sqrt(x);
            }
        } 

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intsqrt(byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu8(x, 3);
            }
            else
            {
                return (byte3)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intsqrt(byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu8(x, 4);
            }
            else
            {
                return (byte4)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intsqrt(byte8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu8(x, 8);
            }
            else
            {
                return (byte8)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intsqrt(byte16 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu8(x, 16);
            }
            else
            {
                return new byte16((byte8)sqrt(x.v8_0), (byte8)sqrt(x.v8_8));  
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intsqrt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu8(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new byte32(Xse.sqrt_epu8(x.v16_0, 16), Xse.sqrt_epu8(x.v16_16, 16));
            }
            else
            {
                return new byte32((byte8)sqrt(x.v8_0), (byte8)sqrt(x.v8_8), (byte8)sqrt(x.v8_16), (byte8)sqrt(x.v8_24));  
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(0, 11)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static sbyte intsqrt(sbyte x)
        {
Assert.IsNonNegative(x);
            
            return (sbyte)bytesqrt((byte)x, unsigned: false);
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intsqrt(sbyte2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi8(x, 2);
            }
            else
            {
                return (sbyte2)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intsqrt(sbyte3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi8(x, 3);
            }
            else
            {
                return (sbyte3)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intsqrt(sbyte4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi8(x, 4);
            }
            else
            {
                return (sbyte4)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intsqrt(sbyte8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi8(x, 8);
            }
            else
            {
                return (sbyte8)sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intsqrt(sbyte16 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi8(x, 16);
            }
            else
            {
                return new sbyte16((sbyte8)sqrt(x.v8_0), (sbyte8)sqrt(x.v8_8));  
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intsqrt(sbyte32 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);
Assert.IsNonNegative(x.x16);
Assert.IsNonNegative(x.x17);
Assert.IsNonNegative(x.x18);
Assert.IsNonNegative(x.x19);
Assert.IsNonNegative(x.x20);
Assert.IsNonNegative(x.x21);
Assert.IsNonNegative(x.x22);
Assert.IsNonNegative(x.x23);
Assert.IsNonNegative(x.x24);
Assert.IsNonNegative(x.x25);
Assert.IsNonNegative(x.x26);
Assert.IsNonNegative(x.x27);
Assert.IsNonNegative(x.x28);
Assert.IsNonNegative(x.x29);
Assert.IsNonNegative(x.x30);
Assert.IsNonNegative(x.x31);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi8(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new sbyte32(Xse.sqrt_epi8(x.v16_0, 16), Xse.sqrt_epi8(x.v16_16, 16));
            }
            else
            {
                return new sbyte32((sbyte8)sqrt(x.v8_0), (sbyte8)sqrt(x.v8_8), (sbyte8)sqrt(x.v8_16), (sbyte8)sqrt(x.v8_24));  
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ushort"/>.    </summary>
        [return: AssumeRange(0ul, (ulong)byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort intsqrt(ushort x)
        {
            if (Xse.constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intsqrt((byte)x);
            }
            else
            {
                return (ushort)math.sqrt(x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intsqrt(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu16(x, 2);
            }
            else
            {
                return (ushort2)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intsqrt(ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu16(x, 3);
            }
            else
            {
                return (ushort3)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intsqrt(ushort4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu16(x, 4);
            }
            else
            {
                return (ushort4)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intsqrt(ushort8 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu16(x, 8);
            }
            else
            {
                return (ushort8)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intsqrt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu16(x);
            }
            else
            {
                return new ushort16(intsqrt(x.v8_0), intsqrt(x.v8_8));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="short"/>.    </summary>
        [return: AssumeRange(0, 181)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static short intsqrt(short x)
        {
Assert.IsNonNegative(x);

            if (Xse.constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intsqrt((byte)x);
            }
            else
            {
                return (short)intsqrt((ushort)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intsqrt(short2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi16(x, 2);
            }
            else
            {
                return (short2)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intsqrt(short3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi16(x, 3);
            }
            else
            {
                return (short3)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intsqrt(short4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi16(x, 4);
            }
            else
            {
                return (short4)(math.sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intsqrt(short8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi16(x, 8);
            }
            else
            {
                return (short8)(sqrt(x));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intsqrt(short16 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
Assert.IsNonNegative(x.x8);
Assert.IsNonNegative(x.x9);
Assert.IsNonNegative(x.x10);
Assert.IsNonNegative(x.x11);
Assert.IsNonNegative(x.x12);
Assert.IsNonNegative(x.x13);
Assert.IsNonNegative(x.x14);
Assert.IsNonNegative(x.x15);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi16(x);
            }
            else
            {
                return new short16(intsqrt(x.v8_0), intsqrt(x.v8_8));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint"/>.    </summary>
        [return: AssumeRange(0ul, (ulong)ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint intsqrt(uint x)
        {
            if (Xse.constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                return intsqrt((ushort)x);
            }
            else if (Xse.constexpr.IS_TRUE(x <= int.MaxValue))
            {
                return (uint)math.sqrt((double)(int)x);
            }
            else
            {
                return (uint)math.sqrt((double)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intsqrt(uint2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.sqrt_epu32(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return (uint2)math.sqrt((double2)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intsqrt(uint3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.sqrt_epu32(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return (uint3)math.sqrt((double3)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intsqrt(uint4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.sqrt_epu32(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return (uint4)math.sqrt((double4)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intsqrt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu32(x);
            }
            else
            {
                return new uint8(intsqrt(x.v4_0), intsqrt(x.v4_4));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int"/>.    </summary>
        [return: AssumeRange(0, 46_340)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int intsqrt(int x)
        {
Assert.IsNonNegative(x);

            if (Xse.constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                return intsqrt((ushort)x);
            }
            else
            {
                return (int)intsqrt((uint)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intsqrt(int2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
            
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int2>(Xse.sqrt_epi32(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return (int2)math.sqrt((double2)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intsqrt(int3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
            
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int3>(Xse.sqrt_epi32(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return (int3)math.sqrt((double3)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intsqrt(int4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);
            
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int4>(Xse.sqrt_epi32(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return (int4)math.sqrt((double4)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intsqrt(int8 x)
        {
Assert.IsNonNegative(x.x0);
Assert.IsNonNegative(x.x1);
Assert.IsNonNegative(x.x2);
Assert.IsNonNegative(x.x3);
Assert.IsNonNegative(x.x4);
Assert.IsNonNegative(x.x5);
Assert.IsNonNegative(x.x6);
Assert.IsNonNegative(x.x7);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi32(x);
            }
            else
            {
                return new int8(intsqrt(x.v4_0), intsqrt(x.v4_4));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="ulong"/>.    </summary>
        [return: AssumeRange(0ul, (ulong)uint.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intsqrt(ulong x)
        {
            if (Xse.constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intsqrt((uint)x);
            }

            ulong result = 0;
            ulong mask = 1ul << 62;

            int lzcntX = math.lzcnt(x);
            mask >>= lzcntX - (lzcntX & 1);
            if (Hint.Likely(mask > x))
            {                
                mask >>= 2;
            }

            if (Hint.Likely(mask != 0))
            {
                if (x >= mask)
                {
                    x -= mask;
                }

                result = mask;
                mask >>= 2;
               
                while (Hint.Likely(mask != 0))
                {
                    ulong resultAdded = result + mask;
                    result >>= 1;

                    if (x >= resultAdded)
                    {
                        x -= resultAdded;
                        result += mask;
                    }

                    mask >>= 2;
                }
            }

            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intsqrt(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epu64(x);
            }
            else
            {
                return new ulong2(intsqrt(x.x), intsqrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intsqrt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu64(x, 3);
            }
            else
            {
                return new ulong3(intsqrt(x.xy), intsqrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intsqrt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epu64(x, 4);
            }
            else
            {
                return new ulong4(intsqrt(x.xy), intsqrt(x.zw));
            }
        }


        /// <summary>       Computes the integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="long"/>.    </summary>
        [return: AssumeRange(0, 3_037_000_499)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static long intsqrt(long x)
        {
Assert.IsNonNegative(x);

            if (Xse.constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intsqrt((uint)x);
            }
            else
            {
                return (long)intsqrt((ulong)x);
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intsqrt(long2 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
            
            if (Sse2.IsSse2Supported)
            {
                return Xse.sqrt_epi64(x);
            }
            else
            {
                return new long2(intsqrt(x.x), intsqrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intsqrt(long3 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi64(x, 3);
            }
            else
            {
                return new long3(intsqrt(x.xy), intsqrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a non-negative <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intsqrt(long4 x)
        {
Assert.IsNonNegative(x.x);
Assert.IsNonNegative(x.y);
Assert.IsNonNegative(x.z);
Assert.IsNonNegative(x.w);
            
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi64(x, 4);
            }
            else
            {
                return new long4(intsqrt(x.xy), intsqrt(x.zw));
            }
        }
    }
}