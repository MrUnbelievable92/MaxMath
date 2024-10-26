using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst;
using DevTools;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

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
                        v128 toFloat = cvtepu8_ps(a);
                        v128 sqrt = rcp_ps(rsqrt_ps(toFloat));
                        v128 toInt = cvttps_epi32(sqrt);

                        a = cvtepi32_epi8(toInt, elements);
                    }
                    else if (elements <= 8)
                    {
                        v128 toFloat_lo = cvtepu8_ps(a);
                        v128 toFloat_hi = cvtepu8_ps(bsrli_si128(a, 4 * sizeof(byte)));
                        v128 sqrt_lo = rcp_ps(rsqrt_ps(toFloat_lo));
                        v128 sqrt_hi = rcp_ps(rsqrt_ps(toFloat_hi));

                        v128 shorts = packs_epi32(cvttps_epi32(sqrt_lo), cvttps_epi32(sqrt_hi));

                        a = packus_epi16(shorts, shorts);
                    }
                    else
                    {
                        v128 shortsLo = cvt2x2epu8_epi16(a, out v128 shortsHi);
                        v128 toFloat_0 = cvt2x2epu16_ps(shortsLo, out v128 toFloat_1);
                        v128 toFloat_2 = cvt2x2epu16_ps(shortsHi, out v128 toFloat_3);

                        v128 sqrt_0 = rcp_ps(rsqrt_ps(toFloat_0));
                        v128 sqrt_1 = rcp_ps(rsqrt_ps(toFloat_1));
                        v128 sqrt_2 = rcp_ps(rsqrt_ps(toFloat_2));
                        v128 sqrt_3 = rcp_ps(rsqrt_ps(toFloat_3));

                        shortsLo = packs_epi32(cvttps_epi32(sqrt_0), cvttps_epi32(sqrt_1));
                        shortsHi = packs_epi32(cvttps_epi32(sqrt_2), cvttps_epi32(sqrt_3));

                        a = packus_epi16(shortsLo, shortsHi);
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
                        sqrt = sub_epi8(sqrt, cmpeq_epi8(a, set1_epi8(225)));
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
                        sqrt = Avx2.mm256_sub_epi8(sqrt, Avx2.mm256_cmpeq_epi8(a, mm256_set1_epi8(225)));
                    }

                    constexpr.ASSUME_LE_EPU8(sqrt, 15);

                    return sqrt;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi16(v128 a, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (elements <= 4)
                    {
                        v128 sqrt;
                        v128 ints;

                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                            {
                                sqrt = rcp_ps(rsqrt_ps(cvtepu16_ps(a)));
                                ints = cvttps_epi32(sqrt);
                                ints = packs_epi32(ints, ints);

                                if (!(constexpr.ALL_NEQ_EPU16(a, 225, elements) || constexpr.ALL_LT_EPU16(a, 225, elements) || constexpr.ALL_GT_EPU16(a, 225, elements)))
                                {
                                    ints = sub_epi16(ints, cmpeq_epi16(a, set1_epi16(225)));
                                }

                                constexpr.ASSUME_LE_EPU16(ints, 15);

                                return ints;
                            }
                        }

                        sqrt = sqrt_ps(cvtepu16_ps(a));
                        ints = cvttps_epi32(sqrt);
                        a = packs_epi32(ints, ints);

                        constexpr.ASSUME_LE_EPU16(a, byte.MaxValue);

                        return a;
                    }
                    else
                    {
                        v128 sqrt_lo;
                        v128 sqrt_hi;
                        v128 shorts;
                        v128 lo = cvt2x2epu16_ps(a, out v128 hi);

                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                            {
                                sqrt_lo = rcp_ps(rsqrt_ps(lo));
                                sqrt_hi = rcp_ps(rsqrt_ps(hi));
                                shorts = packs_epi32(cvttps_epi32(sqrt_lo), cvttps_epi32(sqrt_hi));

                                if (!(constexpr.ALL_NEQ_EPU16(a, 225, elements) || constexpr.ALL_LT_EPU16(a, 225, elements) || constexpr.ALL_GT_EPU16(a, 225, elements)))
                                {
                                    shorts = sub_epi16(shorts, cmpeq_epi16(a, set1_epi16(225)));
                                }

                                constexpr.ASSUME_LE_EPU16(shorts, 15);

                                return shorts;
                            }
                        }

                        sqrt_lo = sqrt_ps(lo);
                        sqrt_hi = sqrt_ps(hi);
                        shorts = packs_epi32(cvttps_epi32(sqrt_lo), cvttps_epi32(sqrt_hi));

                        constexpr.ASSUME_LE_EPU16(shorts, byte.MaxValue);

                        return shorts;
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
                        v256 shorts = mm256_cvtt2x2ps_epu16(sqrtLo, sqrtHi);

                        if (!(constexpr.ALL_NEQ_EPU16(a, 225) || constexpr.ALL_LT_EPU16(a, 225) || constexpr.ALL_GT_EPU16(a, 225)))
                        {
                            shorts = Avx2.mm256_sub_epi16(shorts, Avx2.mm256_cmpeq_epi16(a, mm256_set1_epi16(225)));
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
                if (Architecture.IsSIMDSupported)
                {
                    return sqrt_epi16(a, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_epi16(a);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi32(v128 a, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32, elements))
                    {
                        v128 ints;

                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                            {
                                ints = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU32(a, 225, elements) || constexpr.ALL_LT_EPU32(a, 225, elements) || constexpr.ALL_GT_EPU32(a, 225, elements)))
                                {
                                    ints = sub_epi32(ints, cmpeq_epi32(a, set1_epi32(225)));
                                }

                                constexpr.ASSUME_LE_EPU32(ints, 15);

                                return ints;
                            }
                        }

                        ints = cvttps_epi32(sqrt_ps(cvtepi32_ps(a)));
                        constexpr.ASSUME_LE_EPU32(ints, constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                        
                        return ints;
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            a = cvttpd_epi32(sqrt_pd(cvtepi32_pd(a)));
                        }
                        else
                        {
                            v128 sqrtLo = cvt2x2epi32_pd(a, out v128 sqrtHi);

                            sqrtLo = cvttpd_epi32(sqrt_pd(sqrtLo));
                            sqrtHi = cvttpd_epi32(sqrt_pd(sqrtHi));

                            a = unpacklo_epi64(sqrtLo, sqrtHi);
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
                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                            if (!(constexpr.ALL_NEQ_EPU32(a, 225) || constexpr.ALL_LT_EPU32(a, 225) || constexpr.ALL_GT_EPU32(a, 225)))
                            {
                                ints = Avx2.mm256_sub_epi32(ints, Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(225)));
                            }

                            constexpr.ASSUME_LE_EPU32(ints, 15);

                            return ints;
                        }
                        else
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(ints, constexpr.ALL_LE_EPU32(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

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
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32, elements))
                    {
                        v128 ints;

                        if (Sse2.IsSse2Supported)
                        {
                            if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                            {
                                ints = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU32(a, 225, elements) || constexpr.ALL_LT_EPU32(a, 225, elements) || constexpr.ALL_GT_EPU32(a, 225, elements)))
                                {
                                    ints = sub_epi32(ints, cmpeq_epi32(a, set1_epi32(225)));
                                }

                                constexpr.ASSUME_LE_EPU32(ints, 15);

                                return ints;
                            }
                        }
                            
                        ints = cvttps_epi32(sqrt_ps(cvtepi32_ps(a)));
                        constexpr.ASSUME_LE_EPU32(ints, constexpr.ALL_LE_EPU32(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                        return ints;
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            a = cvttpd_epi32(sqrt_pd(cvtepu32_pd(a)));
                        }
                        else
                        {
                            v128 sqrtLo = cvt2x2epu32_pd(a, out v128 sqrtHi);

                            sqrtLo = cvttpd_epi32(sqrt_pd(sqrtLo));
                            sqrtHi = cvttpd_epi32(sqrt_pd(sqrtHi));

                            a = unpacklo_epi64(sqrtLo, sqrtHi);
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
                    if (constexpr.ALL_LE_EPU32(a, MAX_ACCURATE_INT_SQRT_F32))
                    {
                        if (constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                            if (!(constexpr.ALL_NEQ_EPU32(a, 225) || constexpr.ALL_LT_EPU32(a, 225) || constexpr.ALL_GT_EPU32(a, 225)))
                            {
                                ints = Avx2.mm256_sub_epi32(ints, Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(225)));
                            }

                            constexpr.ASSUME_LE_EPU32(ints, 15);

                            return ints;
                        }
                        else
                        {
                            v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                            constexpr.ASSUME_LE_EPU32(ints, constexpr.ALL_LE_EPU32(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                            return ints;
                        }
                    }
                    else
                    {
                        v256 doublesLo = mm256_cvt2x2epu32_pd(a, out v256 doublesHi);

                        v256 sqrtLo = Avx.mm256_sqrt_pd(doublesLo);
                        v256 sqrtHi = Avx.mm256_sqrt_pd(doublesHi);
                        v256 ints =  mm256_cvtt2x2pd_epu32(sqrtLo, sqrtHi);

                        constexpr.ASSUME_LE_EPU32(ints, ushort.MaxValue);

                        return ints;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return sqrt_ep64(a, signed: true);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return sqrt_ep64(a, signed: false);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epi64x2(v128 a0, v128 a1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (Architecture.IsSIMDSupported)
                {
                    sqrt_ep64x2(a0, a1, out r0, out r1, signed: true);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epu64x2(v128 a0, v128 a1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (Architecture.IsSIMDSupported)
                {
                    sqrt_ep64x2(a0, a1, out r0, out r1, signed: false);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epi64x4(v128 a0, v128 a1, v128 a2, v128 a3, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
            {
                if (Architecture.IsSIMDSupported)
                {
                    sqrt_ep64x4(a0, a1, a2, a3, out r0, out r1, out r2, out r3, signed: true);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epu64x4(v128 a0, v128 a1, v128 a2, v128 a3, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
            {
                if (Architecture.IsSIMDSupported)
                {
                    sqrt_ep64x4(a0, a1, a2, a3, out r0, out r1, out r2, out r3, signed: false);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_ep64(a, signed: true, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_ep64(a, signed: false, elements);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_sqrt_epi64x2(v256 a0, v256 a1, [NoAlias] out v256 r0, [NoAlias] out v256 r1, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_sqrt_ep64x2(a0, a1, out r0, out r1, signed: true, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_sqrt_epu64x2(v256 a0, v256 a1, [NoAlias] out v256 r0, [NoAlias] out v256 r1, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_sqrt_ep64x2(a0, a1, out r0, out r1, signed: false, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep64([NoAlias] ref v128 a, [NoAlias] out v128 mask, [NoAlias] out v128 result, bool signed)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1L);
                    v128 TWO = set1_epi64x(2L);
                    
                    mask = new v128(1ul << 62);
                    mask = srlv_epi64(mask, andnot_si128(ONE, lzcnt_epi64(a)), inRange: constexpr.ALL_GT_EPU64(a, 0));
                    mask = srlv_epi64(mask, and_si128(TWO, signed ? cmpgt_epi64(mask, a) : cmpgt_epu64(mask, a)), inRange: true);
                    
                    result = mask;
                    a = sub_epi64(a, andnot_si128(signed ? cmpgt_epi64(mask, a) : cmpgt_epu64(mask, a), mask));
                    mask = srli_epi64(mask, 2);
                    
                    v128 doneMask;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (Arm.Neon.IsNeonSupported)
                    {
                        ;
                    }
                    else if (Sse2.IsSse2Supported)
                    {
                        if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                        {
                            doneMask = cmpeq_epi64(mask, ZERO);
                    
                            v128 resultAdded = or_si128(result, mask);
                            v128 tempResult = srli_epi64(result, 1);
                            v128 cmp = cmpgt_epu64(resultAdded, a);
                            
                            a = sub_epi64(a, andnot_si128(cmp, resultAdded));
                            tempResult = ternarylogic_si128(cmp, mask, tempResult, TernaryOperation.OxAE);
                            result = blendv_si128(tempResult, result, doneMask);
                            
                            mask = srli_epi64(mask, 2);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep64([NoAlias] ref v128 a, [NoAlias] ref v128 result, [NoAlias] ref v128 mask, v128 doneMask, bool signed)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 resultAdded = or_si128(result, mask);
                    v128 cmp;
                    if (signed)
                    {
                        cmp = cmpgt_epi64(resultAdded, a);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = cmpgt_epu64(resultAdded, a);
                        //}
                        //else 
                        if (Arm.Neon.IsNeonSupported)
                        {
                            cmp = cmpgt_epu64(resultAdded, a);
                        }
                        else
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size 
                                ? cmpgt_epu64(resultAdded, a)
                                : cmpgt_epi64(resultAdded, a);
                        }
                    }
                    
                    if (Architecture.IsVectorShiftSupported)
                    {
                        result = srlv_epi64(result, andnot_si128(doneMask, set1_epi64x(1L)), inRange: true);
                    }
                    else
                    {
                        result = blendv_si128(srli_epi64(result, 1), result, doneMask);
                    }
                    
                    a = sub_epi64(a, andnot_si128(cmp, resultAdded));
                    result = ternarylogic_si128(cmp, mask, result, TernaryOperation.OxAE);
                    mask = srli_epi64(mask, 2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 sqrt_ep64(v128 a, bool signed)
            {
                static bool ContinueLoop(v128 doneMask, v128 mask)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F64))
                    {
                        if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            v128 ints;

                            if (Sse2.IsSse2Supported)
                            {
                                if (constexpr.ALL_LE_EPU64(a, byte.MaxValue))
                                {
                                    ints = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a))));

                                    if (!(constexpr.ALL_NEQ_EPU64(a, 225) || constexpr.ALL_LT_EPU64(a, 225) || constexpr.ALL_GT_EPU64(a, 225)))
                                    {
                                        ints = sub_epi64(ints, cmpeq_epi64(a, set1_epi64x(225)));
                                    }

                                    constexpr.ASSUME_LE_EPU64(ints, 15);

                                    return ints;
                                }
                            }
                            
                            ints = cvttps_epi32(sqrt_ps(cvtepi32_ps(a)));
                            constexpr.ASSUME_LE_EPU64(ints, constexpr.ALL_LE_EPU64(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                            return ints;
                        }
                        else
                        {
                            v128 ints = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a)));
                            constexpr.ASSUME_LE_EPU64(ints, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));

                            return ints;
                        }
                    }

                    
                    PRELOOP_sqrt_ep64(ref a, out v128 mask, out v128 result, signed);
                    v128 doneMask;
                    
                    while (ContinueLoop(doneMask = cmpeq_epi64(mask, setzero_si128()), mask))
                    {
                        LOOP_sqrt_ep64(ref a, ref result, ref mask, doneMask, signed);
                    }
                    
                    constexpr.ASSUME_LE_EPU64(result, uint.MaxValue);
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void sqrt_ep64x2(v128 a0, v128 a1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed)
            {
                static bool ContinueLoop(v128 doneMask0, v128 doneMask1, v128 mask0, v128 mask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        v128 doneMask = and_si128(doneMask0, doneMask1);

                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F64))
                    {
                        if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            if (Sse2.IsSse2Supported)
                            {
                                if (constexpr.ALL_LE_EPU64(a0, byte.MaxValue) && constexpr.ALL_LE_EPU64(a1, byte.MaxValue))
                                {
                                    r0 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a0))));
                                    r1 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a1))));
                    
                                    if (!(constexpr.ALL_NEQ_EPU64(a0, 225) || constexpr.ALL_LT_EPU64(a0, 225) || constexpr.ALL_GT_EPU64(a0, 225)))
                                    {
                                        r0 = sub_epi64(r0, cmpeq_epi64(a0, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a1, 225) || constexpr.ALL_LT_EPU64(a1, 225) || constexpr.ALL_GT_EPU64(a1, 225)))
                                    {
                                        r1 = sub_epi64(r1, cmpeq_epi64(a1, set1_epi64x(225)));
                                    }
                    
                                    constexpr.ASSUME_LE_EPU64(r0, 15);
                                    constexpr.ASSUME_LE_EPU64(r1, 15);
                    
                                    return;
                                }
                            }
                            
                            r0 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a0)));
                            r1 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a1)));
                            constexpr.ASSUME_LE_EPU64(r0, constexpr.ALL_LE_EPU64(a0, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r1, constexpr.ALL_LE_EPU64(a1, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                    
                            return;
                        }
                        else
                        {
                            r0 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a0)));
                            r1 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a1)));
                            constexpr.ASSUME_LE_EPU64(r0, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r1, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                    
                            return;
                        }
                    }

                    
                    PRELOOP_sqrt_ep64(ref a0, out v128 mask0, out r0, signed);
                    PRELOOP_sqrt_ep64(ref a1, out v128 mask1, out r1, signed);
                    v128 doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                    v128 doneMask1 = cmpeq_epi64(mask1, setzero_si128());
                    
                    while (ContinueLoop(doneMask0, doneMask1, mask0, mask1))
                    {
                        LOOP_sqrt_ep64(ref a0, ref r0, ref mask0, doneMask0, signed);
                        LOOP_sqrt_ep64(ref a1, ref r1, ref mask1, doneMask1, signed);
                        doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                        doneMask1 = cmpeq_epi64(mask1, setzero_si128());
                    }
                    
                    constexpr.ASSUME_LE_EPU64(r0, uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r1, uint.MaxValue);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void sqrt_ep64x4(v128 a0, v128 a1, v128 a2, v128 a3, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3, bool signed)
            {
                static bool ContinueLoop(v128 doneMask0, v128 doneMask1, v128 doneMask2, v128 doneMask3, v128 mask0, v128 mask1, v128 mask2, v128 mask3)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(or_si128(mask0, mask1), or_si128(mask2, mask3));

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        v128 doneMask = and_si128(and_si128(doneMask0, doneMask1), and_si128(doneMask2, doneMask3));

                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a2, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a3, MAX_ACCURATE_INT_SQRT_F64))
                    {
                        if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a2, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a3, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            if (Sse2.IsSse2Supported)
                            {
                                if (constexpr.ALL_LE_EPU64(a0, byte.MaxValue) && constexpr.ALL_LE_EPU64(a1, byte.MaxValue) && constexpr.ALL_LE_EPU64(a2, byte.MaxValue) && constexpr.ALL_LE_EPU64(a3, byte.MaxValue))
                                {
                                    r0 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a0))));
                                    r1 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a1))));
                                    r2 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a2))));
                                    r3 = cvttps_epi32(rcp_ps(rsqrt_ps(cvtepi32_ps(a3))));

                                    if (!(constexpr.ALL_NEQ_EPU64(a0, 225) || constexpr.ALL_LT_EPU64(a0, 225) || constexpr.ALL_GT_EPU64(a0, 225)))
                                    {
                                        r0 = sub_epi64(r0, cmpeq_epi64(a0, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a1, 225) || constexpr.ALL_LT_EPU64(a1, 225) || constexpr.ALL_GT_EPU64(a1, 225)))
                                    {
                                        r1 = sub_epi64(r1, cmpeq_epi64(a1, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a2, 225) || constexpr.ALL_LT_EPU64(a2, 225) || constexpr.ALL_GT_EPU64(a2, 225)))
                                    {
                                        r2 = sub_epi64(r2, cmpeq_epi64(a2, set1_epi64x(225)));
                                    }
                                    if (!(constexpr.ALL_NEQ_EPU64(a3, 225) || constexpr.ALL_LT_EPU64(a3, 225) || constexpr.ALL_GT_EPU64(a3, 225)))
                                    {
                                        r3 = sub_epi64(r3, cmpeq_epi64(a3, set1_epi64x(225)));
                                    }

                                    constexpr.ASSUME_LE_EPU64(r0, 15);
                                    constexpr.ASSUME_LE_EPU64(r1, 15);
                                    constexpr.ASSUME_LE_EPU64(r2, 15);
                                    constexpr.ASSUME_LE_EPU64(r3, 15);

                                    return;
                                }
                            }
                            
                            r0 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a0)));
                            r1 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a1)));
                            r2 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a2)));
                            r3 = cvttps_epi32(sqrt_ps(cvtepi32_ps(a3)));
                            constexpr.ASSUME_LE_EPU64(r0, constexpr.ALL_LE_EPU64(a0, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r1, constexpr.ALL_LE_EPU64(a1, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r2, constexpr.ALL_LE_EPU64(a2, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                            constexpr.ASSUME_LE_EPU64(r3, constexpr.ALL_LE_EPU64(a3, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                            return;
                        }
                        else
                        {
                            r0 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a0)));
                            r1 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a1)));
                            r2 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a2)));
                            r3 = cvttpd_epu64(sqrt_pd(usfcvtepu64_pd(a3)));
                            constexpr.ASSUME_LE_EPU64(r0, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r1, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r2, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r3, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));

                            return;
                        }
                    }

                    
                    PRELOOP_sqrt_ep64(ref a0, out v128 mask0, out r0, signed);
                    PRELOOP_sqrt_ep64(ref a1, out v128 mask1, out r1, signed);
                    PRELOOP_sqrt_ep64(ref a2, out v128 mask2, out r2, signed);
                    PRELOOP_sqrt_ep64(ref a3, out v128 mask3, out r3, signed);
                    v128 doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                    v128 doneMask1 = cmpeq_epi64(mask1, setzero_si128());
                    v128 doneMask2 = cmpeq_epi64(mask2, setzero_si128());
                    v128 doneMask3 = cmpeq_epi64(mask3, setzero_si128());
                    
                    while (ContinueLoop(doneMask0, doneMask1, doneMask2, doneMask3, mask0, mask1, mask2, mask3))
                    {
                        LOOP_sqrt_ep64(ref a0, ref r0, ref mask0, doneMask0, signed);
                        LOOP_sqrt_ep64(ref a1, ref r1, ref mask1, doneMask1, signed);
                        LOOP_sqrt_ep64(ref a2, ref r2, ref mask2, doneMask2, signed);
                        LOOP_sqrt_ep64(ref a3, ref r3, ref mask3, doneMask3, signed);
                        doneMask0 = cmpeq_epi64(mask0, setzero_si128());
                        doneMask1 = cmpeq_epi64(mask1, setzero_si128());
                        doneMask2 = cmpeq_epi64(mask2, setzero_si128());
                        doneMask3 = cmpeq_epi64(mask3, setzero_si128());
                    }
                    
                    constexpr.ASSUME_LE_EPU64(r0, uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r1, uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r2, uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r3, uint.MaxValue);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep64([NoAlias] ref v256 a, [NoAlias] out v256 mask, [NoAlias] out v256 result, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = mm256_set1_epi64x(1L);
                    v256 TWO = mm256_set1_epi64x(2L);
                    
                    mask = new v256(1ul << 62);
                    mask = mm256_zeromissing_epi64(mask, elements);
                    mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_andnot_si256(ONE, mm256_lzcnt_epi64(a)));
                    mask = Avx2.mm256_srlv_epi64(mask, Avx2.mm256_and_si256(TWO, signed ? mm256_cmpgt_epi64(mask, a, elements) : mm256_cmpgt_epu64(mask, a, elements)));
                    
                    result = mask;
                    a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(signed ? mm256_cmpgt_epi64(mask, a, elements) : mm256_cmpgt_epu64(mask, a, elements), mask));
                    mask = Avx2.mm256_srli_epi64(mask, 2);
                    
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 resultAdded = Avx2.mm256_or_si256(result, mask);
                        v256 cmp = mm256_cmpgt_epu64(resultAdded, a, elements);
                        v256 tempResult = Avx2.mm256_srli_epi64(result, 1);
                        
                        a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(cmp, resultAdded));
                        tempResult = mm256_ternarylogic_si256(cmp, mask, tempResult, TernaryOperation.OxAE);
                        result = mm256_blendv_si256(tempResult, result, Avx2.mm256_cmpeq_epi64(mask, ZERO));
                        mask = Avx2.mm256_srli_epi64(mask, 2);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep64([NoAlias] ref v256 a, [NoAlias] ref v256 result, [NoAlias] ref v256 mask, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = mm256_set1_epi64x(1L);

                    v256 resultAdded = Avx2.mm256_or_si256(result, mask);
                    v256 cmp;
                    if (signed)
                    {
                        cmp = mm256_cmpgt_epi64(resultAdded, a, elements);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = mm256_cmpgt_epu64(resultAdded, a, elements);
                        //}
                        //else 
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size 
                                ? mm256_cmpgt_epu64(resultAdded, a)
                                : mm256_cmpgt_epi64(resultAdded, a);
                        }
                    }
                    result = Avx2.mm256_srlv_epi64(result, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(mask, ZERO), ONE));
                    
                    a = Avx2.mm256_sub_epi64(a, Avx2.mm256_andnot_si256(cmp, resultAdded));
                    result = mm256_ternarylogic_si256(cmp, mask, result, TernaryOperation.OxAE);
                    mask = Avx2.mm256_srli_epi64(mask, 2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_sqrt_ep64(v256 a, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F64, elements))
                    {
                        if (constexpr.ALL_LE_EPU64(a, MAX_ACCURATE_INT_SQRT_F32, elements))
                        {
                            if (constexpr.ALL_LE_EPU64(a, byte.MaxValue, elements))
                            {
                                v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a))));

                                if (!(constexpr.ALL_NEQ_EPU64(a, 225, elements) || constexpr.ALL_LT_EPU64(a, 225, elements) || constexpr.ALL_GT_EPU64(a, 225, elements)))
                                {
                                    ints = Avx2.mm256_sub_epi64(ints, Avx2.mm256_cmpeq_epi64(a, mm256_set1_epi64x(225)));
                                }

                                constexpr.ASSUME_LE_EPU64(ints, 15);

                                return ints;
                            }
                            else
                            {
                                v256 ints = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a)));

                                constexpr.ASSUME_LE_EPU64(ints, constexpr.ALL_LE_EPU64(a, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                                return ints;
                            }
                        }
                        else
                        {
                            v256 ints = mm256_cvttpd_epu64(Avx.mm256_sqrt_pd(mm256_usfcvtepu64_pd(a)), elements);

                            constexpr.ASSUME_LE_EPU64(ints, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));

                            return ints;
                        }
                    }

                    signed |= constexpr.ALL_LT_EPU64(a, 1ul << 63, elements);

                    PRELOOP_sqrt_ep64(ref a, out v256 mask, out v256 result, signed, elements);
                    mask = mm256_zeromissing_epi64(mask, elements);

                    while (Hint.Likely(Avx.mm256_testz_si256(mask, mask) == 0))
                    {
                        LOOP_sqrt_ep64(ref a, ref result, ref mask, signed, elements);
                    }
                    
                    constexpr.ASSUME_LE_EPU64(result, uint.MaxValue);
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void mm256_sqrt_ep64x2(v256 a0, v256 a1, [NoAlias] out v256 r0, [NoAlias] out v256 r1, bool signed, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F64) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F64))
                    {
                        if (constexpr.ALL_LE_EPU64(a0, MAX_ACCURATE_INT_SQRT_F32) && constexpr.ALL_LE_EPU64(a1, MAX_ACCURATE_INT_SQRT_F32))
                        {
                            if (constexpr.ALL_LE_EPU64(a0, byte.MaxValue) && constexpr.ALL_LE_EPU64(a1, byte.MaxValue))
                            {
                                r0 = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a0))));
                                r1 = Avx.mm256_cvttps_epi32(Avx.mm256_rcp_ps(Avx.mm256_rsqrt_ps(Avx.mm256_cvtepi32_ps(a1))));

                                if (!(constexpr.ALL_NEQ_EPU64(a0, 225) || constexpr.ALL_LT_EPU64(a0, 225) || constexpr.ALL_GT_EPU64(a0, 225)))
                                {
                                    r0 = Avx2.mm256_sub_epi64(r0, Avx2.mm256_cmpeq_epi64(a0, mm256_set1_epi64x(225)));
                                }
                                if (!(constexpr.ALL_NEQ_EPU64(a1, 225) || constexpr.ALL_LT_EPU64(a1, 225) || constexpr.ALL_GT_EPU64(a1, 225)))
                                {
                                    r1 = Avx2.mm256_sub_epi64(r1, Avx2.mm256_cmpeq_epi64(a1, mm256_set1_epi64x(225)));
                                }

                                constexpr.ASSUME_LE_EPU64(r0, 15);
                                constexpr.ASSUME_LE_EPU64(r1, 15);

                                return;
                            }
                            else
                            {
                                r0 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a0)));
                                r1 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(a1)));

                                constexpr.ASSUME_LE_EPU64(r0, constexpr.ALL_LE_EPU64(a0, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));
                                constexpr.ASSUME_LE_EPU64(r1, constexpr.ALL_LE_EPU64(a1, ushort.MaxValue) ? byte.MaxValue : (uint)math.sqrt(MAX_ACCURATE_INT_SQRT_F32));

                                return;
                            }
                        }
                        else
                        {
                            r0 = mm256_cvttpd_epu64(Avx.mm256_sqrt_pd(mm256_usfcvtepu64_pd(a0)));
                            r1 = mm256_cvttpd_epu64(Avx.mm256_sqrt_pd(mm256_usfcvtepu64_pd(a1)));

                            constexpr.ASSUME_LE_EPU64(r0, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));
                            constexpr.ASSUME_LE_EPU64(r1, (ulong)math.sqrt((double)MAX_ACCURATE_INT_SQRT_F64));

                            return;
                        }
                    }

                    bool signed0 = signed | constexpr.ALL_LT_EPU64(a0, 1ul << 63);
                    bool signed1 = signed | constexpr.ALL_LT_EPU64(a1, 1ul << 63);

                    PRELOOP_sqrt_ep64(ref a0, out v256 mask0, out r0, signed0, 4);
                    PRELOOP_sqrt_ep64(ref a1, out v256 mask1, out r1, signed1, 4);

                    mask1 = mm256_zeromissing_epi64(mask1, elements);
                    v256 mask = Avx2.mm256_or_si256(mask0, mask1);

                    while (Hint.Likely(Avx.mm256_testz_si256(mask, mask) == 0))
                    {
                        LOOP_sqrt_ep64(ref a0, ref r0, ref mask0, signed0, 4);
                        LOOP_sqrt_ep64(ref a1, ref r1, ref mask1, signed1, 4);

                        mask = Avx2.mm256_or_si256(mask0, mask1);
                    }
                    
                    constexpr.ASSUME_LE_EPU64(r0, uint.MaxValue);
                    constexpr.ASSUME_LE_EPU64(r1, uint.MaxValue);
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epi128(v128 aLo, v128 aHi)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return sqrt_ep128(aLo, aHi, signed: true);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 sqrt_epu128(v128 aLo, v128 aHi)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return sqrt_ep128(aLo, aHi, signed: false);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epi128x2(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    sqrt_ep128x2(aLo, aHi, bLo, bHi, out r0, out r1, signed: true, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void sqrt_epu128x2(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    sqrt_ep128x2(aLo, aHi, bLo, bHi, out r0, out r1, signed: false, elements);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epi128(v256 aLo, v256 aHi, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_ep128(aLo, aHi, signed: true, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_sqrt_epu128(v256 aLo, v256 aHi, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_sqrt_ep128(aLo, aHi, signed: false, elements);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep128([NoAlias] ref v128 aLo, [NoAlias] ref v128 aHi, [NoAlias] out v128 maskLo, [NoAlias] out v128 maskHi, [NoAlias] out v128 resultLo, [NoAlias] out v128 resultHi, bool signed)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1L);
                    v128 TWO = set1_epi64x(2L);
                    
                    maskLo = set1_epi64x(((UInt128)1 << 126).lo64);
                    maskHi = set1_epi64x(((UInt128)1 << 126).hi64);
                    srlv_epi128(maskLo, maskHi, andnot_si128(ONE, lzcnt_epi128(aLo, aHi)), out maskLo, out maskHi, inRange: constexpr.ALL_NEQ_EPU64(or_si128(aLo, aHi), 0));
                    srlv_epi128(maskLo, maskHi, and_si128(TWO, signed ? cmpgt_epi128(maskLo, maskHi, aLo, aHi) : cmpgt_epu128(maskLo, maskHi, aLo, aHi)), out maskLo, out maskHi, inRange: true);
                    
                    resultLo = maskLo;
                    resultHi = maskHi;
                    v128 subLo = andnot_si128(signed ? cmpgt_epi128(maskLo, maskHi, aLo, aHi) : cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskLo);
                    v128 subHi = andnot_si128(signed ? cmpgt_epi128(maskLo, maskHi, aLo, aHi) : cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskHi);
                    sub_epi128(aLo, aHi, subLo, subHi, out aLo, out aHi);
                    srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                    
                    v128 doneMask;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (Arm.Neon.IsNeonSupported)
                    {
                        ;
                    }
                    else if (Sse2.IsSse2Supported)
                    {
                        if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                        {
                            doneMask = cmpeq_epi128(maskLo, maskHi, ZERO, ZERO);
                    
                            v128 resultAddedLo = or_si128(resultLo, maskLo);
                            v128 resultAddedHi = or_si128(resultHi, maskHi);
                            srli_epi128(resultLo, resultHi, 1, out v128 tempResultLo, out v128 tempResultHi);
                            v128 cmp = cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                            
                            sub_epi128(aLo, aHi, andnot_si128(cmp, resultAddedLo), andnot_si128(cmp, resultAddedHi), out aLo, out aHi);
                            tempResultLo = ternarylogic_si128(cmp, maskLo, tempResultLo, TernaryOperation.OxAE);
                            tempResultHi = ternarylogic_si128(cmp, maskHi, tempResultHi, TernaryOperation.OxAE);
                            resultLo = blendv_si128(tempResultLo, resultLo, doneMask);
                            resultHi = blendv_si128(tempResultHi, resultHi, doneMask);
                            
                            srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep128([NoAlias] ref v128 aLo, [NoAlias] ref v128 aHi, [NoAlias] ref v128 resultLo, [NoAlias] ref v128 resultHi, [NoAlias] ref v128 maskLo, [NoAlias] ref v128 maskHi, v128 doneMask, bool signed)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 resultAddedLo = or_si128(resultLo, maskLo);
                    v128 resultAddedHi = or_si128(resultHi, maskHi);
                    v128 cmp;
                    if (signed)
                    {
                        cmp = cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                        //}
                        //else 
                        if (Arm.Neon.IsNeonSupported)
                        {
                            cmp = cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                        }
                        else
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size 
                                ? cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi)
                                : cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi);
                        }
                    }
                    
                    if (Architecture.IsVectorShiftSupported)
                    {
                        srlv_epi128(resultLo, resultHi, andnot_si128(doneMask, set1_epi64x(1L)), out resultLo, out resultHi, inRange: true);
                    }
                    else
                    {
                        srli_epi128(resultLo, resultHi, 1, out v128 shiftedLo, out v128 shiftedHi);

                        resultLo = blendv_si128(shiftedLo, resultLo, doneMask);
                        resultHi = blendv_si128(shiftedHi, resultHi, doneMask);
                    }
                    
                    sub_epi128(aLo, aHi, andnot_si128(cmp, resultAddedLo), andnot_si128(cmp, resultAddedHi), out aLo, out aHi);
                    resultLo = ternarylogic_si128(cmp, maskLo, resultLo, TernaryOperation.OxAE);
                    resultHi = ternarylogic_si128(cmp, maskHi, resultHi, TernaryOperation.OxAE);
                    srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 sqrt_ep128(v128 aLo, v128 aHi, bool signed)
            {
                static bool ContinueLoop(v128 doneMask, v128 maskLo, v128 maskHi)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(maskLo, maskHi);

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPU64(aHi, 0))
                    {
                        return sqrt_ep64(aLo, signed);
                    }
                    

                    PRELOOP_sqrt_ep128(ref aLo, ref aHi, out v128 maskLo, out v128 maskHi, out v128 resultLo, out v128 resultHi, signed);
                    v128 doneMask;
                    
                    while (ContinueLoop(doneMask = cmpeq_epi128(maskLo, maskHi, setzero_si128(), setzero_si128()), maskLo, maskHi))
                    {
                        LOOP_sqrt_ep128(ref aLo, ref aHi, ref resultLo, ref resultHi, ref maskLo, ref maskHi, doneMask, signed);
                    }
                    
                    return resultLo;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void sqrt_ep128x2(v128 aLo, v128 aHi, v128 bLo, v128 bHi, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed, byte elements = 4)
            {
                static bool ContinueLoop(v128 doneMaskA, v128 doneMaskB, v128 maskALo, v128 maskAHi, v128 maskBLo, v128 maskBHi)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 maskA = or_si128(maskALo, maskAHi);
                        v128 maskB = or_si128(maskBLo, maskBHi);
                        v128 mask  = or_si128(maskA, maskB);

                        return Hint.Likely(testz_si128(mask, mask) == 0);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<long>(and_si128(doneMaskA, doneMaskB)));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPU64(aHi, 0) && constexpr.ALL_EQ_EPU64(bHi, 0))
                    {
                        sqrt_ep64x2(aLo, bLo, out r0, out r1, signed);

                        return;
                    }
                    
                    
                    PRELOOP_sqrt_ep128(ref aLo, ref aHi, out v128 maskALo, out v128 maskAHi, out r0, out v128 resultAHi, signed);
                    PRELOOP_sqrt_ep128(ref bLo, ref bHi, out v128 maskBLo, out v128 maskBHi, out r1, out v128 resultBHi, signed);
                    v128 doneMaskA;
                    v128 doneMaskB;
                    
                    if (Sse4_1.IsSse41Supported)
                    {
                        maskBHi = zeromissing_epi32(maskBHi, (byte)(elements == 3 ? 2 : 4));
                    }

                    while (ContinueLoop(doneMaskA = cmpeq_epi128(maskALo, maskAHi, setzero_si128(), setzero_si128()), 
                                        doneMaskB = cmpeq_epi128(maskBLo, maskBHi, setzero_si128(), setzero_si128()), 
                                        maskALo, maskAHi,
                                        maskBLo, maskBHi))
                    {
                        LOOP_sqrt_ep128(ref aLo, ref aHi, ref r0, ref resultAHi, ref maskALo, ref maskAHi, doneMaskA, signed);
                        LOOP_sqrt_ep128(ref bLo, ref bHi, ref r1, ref resultBHi, ref maskBLo, ref maskBHi, doneMaskB, signed);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_sqrt_ep128([NoAlias] ref v256 aLo, [NoAlias] ref v256 aHi, [NoAlias] out v256 maskLo, [NoAlias] out v256 maskHi, [NoAlias] out v256 resultLo, [NoAlias] out v256 resultHi, bool signed)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = mm256_set1_epi64x(1L);
                    v256 TWO = mm256_set1_epi64x(2L);
                    
                    maskLo = mm256_set1_epi64x(((UInt128)1 << 126).lo64);
                    maskHi = mm256_set1_epi64x(((UInt128)1 << 126).hi64);
                    mm256_srlv_epi128(maskLo, maskHi, Avx2.mm256_andnot_si256(ONE, mm256_lzcnt_epi128(aLo, aHi)), out maskLo, out maskHi);
                    mm256_srlv_epi128(maskLo, maskHi, Avx2.mm256_and_si256(TWO, signed ? mm256_cmpgt_epi128(maskLo, maskHi, aLo, aHi) : mm256_cmpgt_epu128(maskLo, maskHi, aLo, aHi)), out maskLo, out maskHi);
                    
                    resultLo = maskLo;
                    resultHi = maskHi;
                    v256 subLo = Avx2.mm256_andnot_si256(signed ? mm256_cmpgt_epi128(maskLo, maskHi, aLo, aHi) : mm256_cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskLo);
                    v256 subHi = Avx2.mm256_andnot_si256(signed ? mm256_cmpgt_epi128(maskLo, maskHi, aLo, aHi) : mm256_cmpgt_epu128(maskLo, maskHi, aLo, aHi), maskHi);
                    mm256_sub_epi128(aLo, aHi, subLo, subHi, out aLo, out aHi);
                    mm256_srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                    
                    v256 doneMask;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ;
                    //}
                    //else
                    if (!signed && COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        doneMask = mm256_cmpeq_epi128(maskLo, maskHi, ZERO, ZERO);
                    
                        v256 resultAddedLo = Avx2.mm256_or_si256(resultLo, maskLo);
                        v256 resultAddedHi = Avx2.mm256_or_si256(resultHi, maskHi);
                        mm256_srli_epi128(resultLo, resultHi, 1, out v256 tempResultLo, out v256 tempResultHi);
                        v256 cmp = mm256_cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                        
                        mm256_sub_epi128(aLo, aHi, Avx2.mm256_andnot_si256(cmp, resultAddedLo), Avx2.mm256_andnot_si256(cmp, resultAddedHi), out aLo, out aHi);
                        tempResultLo = mm256_ternarylogic_si256(cmp, maskLo, tempResultLo, TernaryOperation.OxAE);
                        tempResultHi = mm256_ternarylogic_si256(cmp, maskHi, tempResultHi, TernaryOperation.OxAE);
                        resultLo = mm256_blendv_si256(tempResultLo, resultLo, doneMask);
                        resultHi = mm256_blendv_si256(tempResultHi, resultHi, doneMask);
                        
                        mm256_srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_sqrt_ep128([NoAlias] ref v256 aLo, [NoAlias] ref v256 aHi, [NoAlias] ref v256 resultLo, [NoAlias] ref v256 resultHi, [NoAlias] ref v256 maskLo, [NoAlias] ref v256 maskHi, v256 doneMask, bool signed)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 resultAddedLo = Avx2.mm256_or_si256(resultLo, maskLo);
                    v256 resultAddedHi = Avx2.mm256_or_si256(resultHi, maskHi);
                    v256 cmp;
                    if (signed)
                    {
                        cmp = mm256_cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi);
                    }
                    else
                    {
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = mm256_cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi);
                        //}
                        //else 
                        {
                            cmp = COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size 
                                ? mm256_cmpgt_epu128(resultAddedLo, resultAddedHi, aLo, aHi)
                                : mm256_cmpgt_epi128(resultAddedLo, resultAddedHi, aLo, aHi);
                        }
                    }
                    
                    mm256_srlv_epi128(resultLo, resultHi, Avx2.mm256_andnot_si256(doneMask, mm256_set1_epi64x(1L)), out resultLo, out resultHi);
                    mm256_sub_epi128(aLo, aHi, Avx2.mm256_andnot_si256(cmp, resultAddedLo), Avx2.mm256_andnot_si256(cmp, resultAddedHi), out aLo, out aHi);
                    resultLo = mm256_ternarylogic_si256(cmp, maskLo, resultLo, TernaryOperation.OxAE);
                    resultHi = mm256_ternarylogic_si256(cmp, maskHi, resultHi, TernaryOperation.OxAE);
                    mm256_srli_epi128(maskLo, maskHi, 2, out maskLo, out maskHi);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_sqrt_ep128(v256 aLo, v256 aHi, bool signed, byte elements = 4)
            {
                static bool ContinueLoop(v256 doneMask, v256 maskLo, v256 maskHi)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 mask = Avx2.mm256_or_si256(maskLo, maskHi);

                        return Hint.Likely(Avx.mm256_testz_si256(mask, mask) == 0);
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU64(aHi, 0, elements))
                    {
                        return mm256_sqrt_ep64(aLo, signed, elements);
                    }
                    

                    PRELOOP_sqrt_ep128(ref aLo, ref aHi, out v256 maskLo, out v256 maskHi, out v256 resultLo, out v256 resultHi, signed);
                    v256 doneMask;
                    maskHi = mm256_zeromissing_epi64(maskHi, elements);

                    while (ContinueLoop(doneMask = mm256_cmpeq_epi128(maskLo, maskHi, Avx.mm256_setzero_si256(), Avx.mm256_setzero_si256()), maskLo, maskHi))
                    {
                        LOOP_sqrt_ep128(ref aLo, ref aHi, ref resultLo, ref resultHi, ref maskLo, ref maskHi, doneMask, signed);
                    }
                    
                    return resultLo;
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
                v128 mov = Xse.cvtsi32_si128(x);
                v128 sqrt = Xse.rcp_ss(Xse.rsqrt_ss(Xse.cvtepi32_ps(mov)));
                v128 toInt = Xse.cvttps_epi32(sqrt);

                if (unsigned)
                {
                    return (byte)(Xse.cvtsi128_si32(toInt) + tobyte(x == 225));
                }
                else
                {
                    return (byte)Xse.cvtsi128_si32(toInt);
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

            mask >>= lzcnt(x) & (-1 << 1);
            if (Hint.Likely(mask > x))
            {
                mask >>= 2;
            }

            if (x >= mask)
            {
                x -= mask;
                result = mask;
            }

            mask >>= 2;

            while (mask != 0)
            {
                UInt128 resultAdded = result | mask;
                result >>= 1;

                if (x >= resultAdded)
                {
                    x -= resultAdded;
                    result |= mask;
                }

                mask >>= 2;
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
VectorAssert.IsNotSmaller<sbyte2, sbyte>(x, 0, 2);

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
VectorAssert.IsNotSmaller<sbyte3, sbyte>(x, 0, 3);

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
VectorAssert.IsNotSmaller<sbyte4, sbyte>(x, 0, 4);

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
VectorAssert.IsNotSmaller<sbyte8, sbyte>(x, 0, 8);

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
VectorAssert.IsNotSmaller<sbyte16, sbyte>(x, 0, 16);

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
VectorAssert.IsNotSmaller<sbyte32, sbyte>(x, 0, 32);

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
            if (constexpr.IS_TRUE(x <= byte.MaxValue))
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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

            if (constexpr.IS_TRUE(x <= byte.MaxValue))
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
VectorAssert.IsNotSmaller<short2, short>(x, 0, 2);
            
            if (Architecture.IsSIMDSupported)
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
VectorAssert.IsNotSmaller<short3, short>(x, 0, 3);
            
            if (Architecture.IsSIMDSupported)
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
VectorAssert.IsNotSmaller<short4, short>(x, 0, 4);

            if (Architecture.IsSIMDSupported)
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
VectorAssert.IsNotSmaller<short8, short>(x, 0, 8);
            
            if (Architecture.IsSIMDSupported)
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
VectorAssert.IsNotSmaller<short16, short>(x, 0, 16);

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
            if (constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                return intsqrt((ushort)x);
            }
            else 
            {
                if (constexpr.IS_TRUE(x <= MAX_ACCURATE_INT_SQRT_F32))
                {
                    return (uint)math.sqrt((float)x);
                }
                else if (constexpr.IS_TRUE(x <= int.MaxValue))
                {
                    return (uint)math.sqrt((double)(int)x);
                }
                else
                {
                    return (uint)math.sqrt((double)x);
                }
            }
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intsqrt(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.sqrt_epu32(RegisterConversion.ToV128(x), 2));
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
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.sqrt_epu32(RegisterConversion.ToV128(x), 3));
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
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.sqrt_epu32(RegisterConversion.ToV128(x), 4));
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

            if (constexpr.IS_TRUE(x <= ushort.MaxValue))
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
VectorAssert.IsNotSmaller<int2, int>(x, 0, 2);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.sqrt_epi32(RegisterConversion.ToV128(x), 2));
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
VectorAssert.IsNotSmaller<int3, int>(x, 0, 3);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.sqrt_epi32(RegisterConversion.ToV128(x), 3));
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
VectorAssert.IsNotSmaller<int4, int>(x, 0, 4);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.sqrt_epi32(RegisterConversion.ToV128(x), 4));
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
VectorAssert.IsNotSmaller<int8, int>(x, 0, 8);

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
            if (constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intsqrt((uint)x);
            }
            else if (constexpr.IS_TRUE(x <= MAX_ACCURATE_INT_SQRT_F64))
            {
                return (ulong)math.sqrt((double)x);
            }
            
            // loop-free, yet tests say the loop version is 25-50% faster; 
            // heavily optimized vectorized loop free version up to 200% slower than loop (unbelievable)
            //
            //ulong vInt = (ulong)sqrt((double)x);
            //
            //if (x == 0)
            //{
            //    return 0;
            //}
            //
            //ulong v = (vInt + (x / vInt)) / 2;
            //return v - tobyte(v * v > x);

            ulong mask = 1ul << 62;
            ulong result = 0;
            
            mask >>= math.lzcnt(x) & (-1 << 1);
            if (Hint.Likely(mask > x))
            {
                mask >>= 2;
            }
            
            if (x >= mask)
            {
                x -= mask;
                result = mask;
            }
            
            mask >>= 2;
            
            while (mask != 0)
            {
                ulong resultAdded = result | mask;
                result >>= 1;
            
                if (x >= resultAdded)
                {
                    x -= resultAdded;
                    result |= mask;
                }
            
                mask >>= 2;
            }
            
            return result;
        }

        /// <summary>       Computes the componentwise integer square root ⌊√<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intsqrt(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
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
            else if (Architecture.IsSIMDSupported)
            {
                Xse.sqrt_epu64x2(x.xy, x.zz, out v128 lo, out v128 hi);

                return new ulong3(lo, hi.ULong0);
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
            else if (Architecture.IsSIMDSupported)
            {
                Xse.sqrt_epu64x2(x.xy, x.zw, out v128 lo, out v128 hi);

                return new ulong4(lo, hi);
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

            if (constexpr.IS_TRUE(x <= uint.MaxValue))
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
VectorAssert.IsNotSmaller<long2, long>(x, 0, 2);
            
            if (Architecture.IsSIMDSupported)
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
VectorAssert.IsNotSmaller<long3, long>(x, 0, 3);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi64(x, 3);
            }
            else if (Architecture.IsSIMDSupported)
            {
                Xse.sqrt_epi64x2(x.xy, x.zz, out v128 lo, out v128 hi);

                return new long3(lo, hi.SLong0);
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
VectorAssert.IsNotSmaller<long4, long>(x, 0, 4);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_sqrt_epi64(x, 4);
            }
            else if (Architecture.IsSIMDSupported)
            {
                Xse.sqrt_epi64x2(x.xy, x.zw, out v128 lo, out v128 hi);

                return new long4(lo, hi);
            }
            else
            {
                return new long4(intsqrt(x.xy), intsqrt(x.zw));
            }
        }
    }
}