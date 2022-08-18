using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;
using UnityEngine;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_pd(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPI64(x, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(x, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    return usfcvtepi64_pd(x);
                }

                return new v128((double)x.SLong0, (double)x.SLong1);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi64_pd(v256 x, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPI64(x, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(x, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))
                {
                    return mm256_usfcvtepi64_pd(x);
                }


                v256 magic_lo  = new v256(LIMIT_PRECISE_I32_F64);
                v256 magic_hi  = new v256(0x4530_0000_8000_0000);
                v256 magic_dbl = new v256(0x4530_0000_8010_0000);
                
                v256 lo = Avx2.mm256_blend_epi32(magic_lo, x, 0b0101_0101);
                v256 hi = Avx2.mm256_xor_si256(magic_hi, Avx2.mm256_srli_epi64(x, 32));
                
                v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
                v256 result = Avx.mm256_add_pd(hi_dbl, lo);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu64_pd(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU64(x, USF_CVT_EPU64_PD_LIMIT))
                {
                    return usfcvtepu64_pd(x);
                }

                return new v128((double)x.ULong0, (double)x.ULong1);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu64_pd(v256 x, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU64(x, USF_CVT_EPU64_PD_LIMIT, elements))
                {
                    return mm256_usfcvtepu64_pd(x);
                }


                v256 magic_lo  = new v256(LIMIT_PRECISE_I32_F64);
                v256 magic_hi  = new v256(0x4530_0000_0000_0000);
                v256 magic_dbl = new v256(0x4530_0000_0010_0000);

                v256 lo = Avx2.mm256_blend_epi32(magic_lo, x, 0b0101_0101);
                v256 hi = Avx2.mm256_xor_si256(magic_hi, Avx2.mm256_srli_epi64(x, 32));

                v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
                v256 result = Avx.mm256_add_pd(hi_dbl, lo);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epi64(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_PD(x, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_PD(x, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    return usfcvttpd_epi64(x);
                }

                return new v128((long)x.Double0, (long)x.Double1);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpd_epi64(v256 a, byte elements = 4, bool promise = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_PD(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_PD(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    return mm256_usfcvttpd_epi64(a);
                }
                else
                {
                    promise |= constexpr.ALL_GE_PD(a, long.MinValue) && constexpr.ALL_LE_PD(a, long.MaxValue);
                
                    return mm256_cvttpd_epi64_BASE(a, signed: true, elements, promise);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpd_epu64(v256 a, byte elements = 4, bool promise = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_PD(a, 0d) && constexpr.ALL_LE_PD(a, USF_CVT_EPU64_PD_LIMIT, elements))
                {
                    return mm256_usfcvttpd_epu64(a);
                }
                else
                {
                    promise |= constexpr.ALL_GE_PD(a, 0d) && constexpr.ALL_LE_PD(a, long.MaxValue);
                
                    return mm256_cvttpd_epi64_BASE(a, signed: false, elements, promise);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 mm256_cvttpd_epi64_BASE(v256 a, bool signed, byte elements = 4, bool promise = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (elements == 3 && !promise)
                {
                    if (signed)
                    {
                        v128 lo = Avx.mm256_castpd256_pd128(a);
                        v128 hi = Avx.mm256_extractf128_pd(a, 1);

                        v128 resultLoLo = Sse2.cvtsi64x_si128(Sse2.cvttsd_si64x(lo));
                        v128 resultLoHi = Sse2.cvtsi64x_si128(Sse2.cvttsd_si64x(Sse2.bsrli_si128(lo, sizeof(long))));
                        v128 resultHiLo = Sse2.cvtsi64x_si128(Sse2.cvttsd_si64x(hi));

                        lo = Sse2.unpacklo_epi64(resultLoLo, resultLoHi);
                        return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(lo), resultHiLo, 1);
                    }
                    else
                    {
                        v256 result = Avx.mm256_undefined_si256();
                        result.Lo128 = new v128((ulong)a.Double0, (ulong)a.Double1);
                        result.ULong2 = (ulong)a.Double2;

                        return result;
                    }
                }
                else
                {
                    const ulong BIAS = 0x03FFul;
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = Avx.mm256_set1_epi64x(1L);
                    v256 IMPL_ONE = Avx.mm256_set1_epi64x(1L << 52);
                    v256 MANTISSA_MASK = Avx.mm256_set1_epi64x((1L << 52) - 1);

                    v256 biased_exp = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(a, 1), 53);
                    v256 shift_mnt = Avx2.mm256_subs_epu16(new v256(BIAS + 51), biased_exp);
                    v256 shift_int = Avx2.mm256_subs_epu16(biased_exp, new v256(BIAS + 51));
                         
                    v256 mantissa = mm256_ternarylogic_si256(IMPL_ONE, a, MANTISSA_MASK, TernaryOperation.OxF8);
                    v256 int52 = Avx2.mm256_srlv_epi64(Avx2.mm256_srli_epi64(mantissa, 1), shift_mnt);
                    v256 shifted = Avx2.mm256_sllv_epi64(int52, shift_int);
                    v256 restored = Avx2.mm256_sllv_epi64(Avx2.mm256_and_si256(mantissa, ONE), Avx2.mm256_sub_epi64(shift_int, ONE));

                    v256 sign_mask = Avx.mm256_cmp_pd(ZERO, a, (int)Avx.CMP.GT_OQ); // omitted if !signed && promise

                    if (signed)
                    {
                        if (constexpr.ALL_GE_PD(a, 0d, elements))
                        {
                            restored = Avx2.mm256_or_si256(restored, shifted);
                        }
                        else
                        { 
                            restored = mm256_ternarylogic_si256(sign_mask, restored, shifted, TernaryOperation.Ox1E); 
                            restored = Avx2.mm256_sub_epi64(restored, sign_mask);
                        }
                    }
                    else
                    {
                        restored = Avx2.mm256_or_si256(restored, shifted);

                        if (!promise)
                        {
                            restored = mm256_blendv_si256(restored, new v256(1L << 63), sign_mask);
                        }
                    }

                    if (!promise)
                    {
                        v256 OVERFLOW = signed ? new v256(1L << 63) : Avx2.mm256_and_si256(sign_mask, new v256(1L << 63));

                        v256 inRange = Avx2.mm256_cmpgt_epi64(new v256(BIAS + 63ul), biased_exp); // yes, this excludes many unsigned values but it is following the C(#) standard
                        restored = mm256_blendv_si256(OVERFLOW, restored, inRange);
                    }
                    
                    return restored;
                }
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epu64(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_PD(x, USF_CVT_EPU64_PD_LIMIT) && constexpr.ALL_GE_PD(x, 0d))
                {
                    return usfcvttpd_epu64(x);
                }


                return new v128((ulong)x.Double0, (ulong)x.Double1);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu32_ps(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 clamped  = Avx2.mm256_and_si256(new v256(0x7FFF_FFFF), a);
                v256 pow31Mask = Avx2.mm256_and_si256(new v256(0x4F00_0000), Avx2.mm256_srai_epi32(a, 31));

                return Avx.mm256_add_ps(Avx.mm256_cvtepi32_ps(clamped), pow31Mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_ps(v128 a)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse2.cvtepi32_ps(Sse4_1.cvtepu8_epi32(a));
            }
            else if (Sse2.IsSse2Supported)
            {
                return cvtepu16_ps(cvtepu8_epi16(a));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_ps(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 EXP_MASK = Sse2.cvtsi64x_si128(0x4B00_4B00_4B00_4B00);
                v128 MAGIC = Sse.set1_ps(LIMIT_PRECISE_I16_F32);

                return Sse.sub_ps(Sse2.unpacklo_epi16(a, EXP_MASK), MAGIC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_ps(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 clamped  = Sse2.and_si128(new v128(0x7FFF_FFFF), a);
                v128 pow31Mask = Sse2.and_si128(new v128(0x4F00_0000), Sse2.srai_epi32(a, 31));

                return Sse.add_ps(Sse2.cvtepi32_ps(clamped), pow31Mask);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_pd(v128 a)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse2.cvtepi32_pd(Sse4_1.cvtepu8_epi32(a));
            }
            else if (Sse2.IsSse2Supported)
            {
                return cvtepu16_pd(cvtepu8_epi16(a));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.cvtepi32_pd(cvtepu16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue, 2))
                {
                    return Sse2.cvtepi32_pd(a);
                }
                else
                {
                    v128 EXP_MASK = Sse2.set1_epi32(0x4330_0000);
                    v128 MAGIC = Sse2.set1_pd(LIMIT_PRECISE_I32_F64);

                    return Sse2.sub_pd(Sse2.unpacklo_epi32(a, EXP_MASK), MAGIC);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_ps(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPI8(a, 0))
                {
                    return cvtepu8_ps(a);
                }

                return Sse2.cvtepi32_ps(cvtepi8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_ps(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPI16(a, 0))
                {
                    return cvtepu16_ps(a);
                }

                return Sse2.cvtepi32_ps(cvtepi16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPI8(a, 0))
                {
                    return cvtepu8_pd(a);
                }

                return Sse2.cvtepi32_pd(cvtepi8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPI16(a, 0))
                {
                    return cvtepu16_pd(a);
                }

                return Sse2.cvtepi32_pd(cvtepi16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }
    }
}