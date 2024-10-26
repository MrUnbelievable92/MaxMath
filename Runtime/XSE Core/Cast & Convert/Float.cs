using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_ps(v128 a)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return cvtepi32_ps(cvtepu8_epi32(a));
            }
            else if (Architecture.IsSIMDSupported)
            {
                return cvtepu16_ps(cvtepu8_epi16(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_ps(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_GE_EPI8(a, 0))
                {
                    return cvtepu8_ps(a);
                }

                return cvtepi32_ps(cvtepi8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_ps(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_GE_EPI16(a, 0))
                {
                    return cvtepu16_ps(a);
                }

                return cvtepi32_ps(cvtepi16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_ps(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 EXP_MASK = set1_epi16(0x4B00);
                v128 MAGIC = set1_ps(LIMIT_PRECISE_U32_F32);

                return sub_ps(unpacklo_epi16(a, EXP_MASK), MAGIC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi16_ps(v128 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepi16_epi32(a));
            }
            else if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtepi32_ps(Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(cvt2x2epi16_epi32(a, out v128 hi)), hi, 1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu16_ps(v128 a)
        {
            if (Avx.IsAvxSupported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu16_epi32(a));
                    }
                }

                v128 EXP_MASK = set1_epi16(0x4B00);
                v256 MAGIC = Avx.mm256_set1_ps(LIMIT_PRECISE_U32_F32);

                return Avx.mm256_sub_ps(Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(unpacklo_epi16(a, EXP_MASK)), unpackhi_epi16(a, EXP_MASK), 1), MAGIC);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_ps(v128 a, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue, elements))
                {
                    return cvtepi32_ps(a);
                }

                v128 aLo = and_si128(a, set1_epi32(maxmath.bitmask32(16)));
                v128 aHi = srli_epi32(a, 16);

                v128 cvtLo = cvtepi32_ps(aLo);
                v128 cvtHi = cvtepi32_ps(aHi);

                return fmadd_ps(set1_ps(1 << 16), cvtHi, cvtLo);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcvtq_f32_u32(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu32_ps(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue))
                {
                    return Avx.mm256_cvtepi32_ps(a);
                }

                v256 aLo = Avx2.mm256_and_si256(a, mm256_set1_epi32(maxmath.bitmask32(16)));
                v256 aHi = Avx2.mm256_srli_epi32(a, 16);

                v256 cvtLo = Avx.mm256_cvtepi32_ps(aLo);
                v256 cvtHi = Avx.mm256_cvtepi32_ps(aHi);

                return mm256_fmadd_ps(mm256_set1_ps(1 << 16), cvtHi, cvtLo);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu64_ps(v128 a, byte elements = 2)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                {
                    if (constexpr.ALL_LE_EPU64(a, int.MaxValue, elements))
                    {
                        return cvtepi32_ps(cvtepi64_epi32(a));
                    }
                    else
                    {
                        return cvtepu32_ps(cvtepi64_epi32(a), 3);
                    }
                }

                if (elements == 1)
                {
                    return cvtsi32_si128(math.asint((float)a.ULong0));
                }
                else
                {
                    return unpacklo_epi32(cvtsi32_si128(math.asint((float)a.ULong0)),
                                          cvtsi32_si128(math.asint((float)a.ULong1)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepu64_ps(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                {
                    if (constexpr.ALL_LE_EPU64(a, int.MaxValue, elements))
                    {
                        return cvtepi32_ps(mm256_cvtepi64_epi32(a));
                    }
                    else
                    {
                        return cvtepu32_ps(mm256_cvtepi64_epi32(a));
                    }
                }
                else
                {
                   v256 ZERO = Avx.mm256_setzero_si256();
                   v256 ONE = mm256_set1_epi64x(1);
       
                   v256 log2 = mm256_lzcnt_epi64(a);
                   log2 = Avx2.mm256_sub_epi64(log2, mm256_set1_epi64x(33));
       
                   v256 posShift = Avx2.mm256_sllv_epi64(a, log2);
                   v256 negShift = Avx2.mm256_srlv_epi64(a, mm256_neg_epi64(log2));
                   v256 sig = Avx.mm256_blendv_pd(posShift, negShift, log2);
                   
                    v256 jamInv = Avx2.mm256_cmpeq_epi64(ZERO, Avx2.mm256_and_si256(a, Avx2.mm256_sub_epi64(Avx2.mm256_sllv_epi64(ONE, mm256_neg_epi64(log2)), ONE))); 
                    v256 roundIncrement = Avx2.mm256_andnot_si256(negShift, mm256_srli_epi64(log2, 63));
                    roundIncrement = mm256_ternarylogic_si256(mm256_set1_epi64x(0x40), roundIncrement, jamInv,                     TernaryOperation.OxF4);;
                    v256 roundMask = mm256_ternarylogic_si256(roundIncrement,          sig,            mm256_set1_epi64x(0x7F),    TernaryOperation.Ox78);
                    
                    sig = Avx2.mm256_srli_epi64(Avx2.mm256_add_epi64(sig, roundIncrement), 7);
                    sig = Avx2.mm256_and_si256(sig, Avx2.mm256_add_epi64(mm256_setall_si256(), Avx2.mm256_cmpeq_epi64(roundMask, ZERO)));

                    v256 exp = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(ZERO, a), Avx2.mm256_sub_epi64(mm256_set1_epi64x(0x9C), log2));
                    v256 result64 = Avx2.mm256_add_epi64(sig, Avx2.mm256_slli_epi64(exp, F32_MANTISSA_BITS));

                    return mm256_cvtepi64_epi32(result64);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_ps(v128 a, byte elements = 2)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPI64(a, uint.MaxValue, elements)
                 && constexpr.ALL_GE_EPI64(a, uint.MinValue, elements))
                {
                    return cvtepu32_ps(cvtepi64_epi32(a), 3);
                }
                if (constexpr.ALL_LE_EPI64(a, int.MaxValue, elements)
                 && constexpr.ALL_GE_EPI64(a, int.MinValue, elements))
                {
                    return cvtepi32_ps(cvtepi64_epi32(a));
                }

                if (elements == 1)
                {
                    return cvtsi32_si128(math.asint((float)a.SLong0));
                }
                else
                {
                    return unpacklo_epi32(cvtsi32_si128(math.asint((float)a.SLong0)),
                                          cvtsi32_si128(math.asint((float)a.SLong1)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_ps(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPI64(a, uint.MaxValue, elements)
                 && constexpr.ALL_GE_EPI64(a, uint.MinValue, elements))
                {
                    return cvtepu32_ps(mm256_cvtepi64_epi32(a), 3);
                }
                if (constexpr.ALL_LE_EPI64(a, int.MaxValue, elements)
                 && constexpr.ALL_GE_EPI64(a, int.MinValue, elements))
                {
                    return cvtepi32_ps(mm256_cvtepi64_epi32(a));
                }

                return unpacklo_epi64(cvtepi64_ps(a.Lo128),
                                      (elements == 3) ? cvtsi32_si128(math.asint((float)a.SLong2))
                                                      : cvtepi64_ps(a.Hi128));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_pd(v128 a)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return cvtepi32_pd(cvtepu8_epi32(a));
            }
            else if (Architecture.IsSIMDSupported)
            {
                return cvtepu16_pd(cvtepu8_epi16(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_pd(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_GE_EPI8(a, 0))
                {
                    return cvtepu8_pd(a);
                }

                return cvtepi32_pd(cvtepi8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_pd(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_pd(cvtepu16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_pd(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_GE_EPI16(a, 0))
                {
                    return cvtepu16_pd(a);
                }

                return cvtepi32_pd(cvtepi16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_pd(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue, 2))
                {
                    return cvtepi32_pd(a);
                }
                else
                {
                    v128 EXP_MASK = set1_epi32(0x4330_0000);
                    v128 MAGIC = set1_pd(LIMIT_PRECISE_U64_F64);

                    return sub_pd(unpacklo_epi32(a, EXP_MASK), MAGIC);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu32_pd(v128 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue, elements))
                {
                    return Avx.mm256_cvtepi32_pd(a);
                }
                else
                {
                    v256 EXP_MASK = mm256_set1_epi64x(0x4330_0000_0000_0000);
                    v256 MAGIC = mm256_set1_pd(LIMIT_PRECISE_U64_F64);

                    return Avx.mm256_sub_pd(Avx2.mm256_or_si256(Avx2.mm256_cvtepu32_epi64(a), EXP_MASK), MAGIC);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))
                {
                    return usfcvtepi64_pd(a);
                }

                return new v128((double)a.SLong0, (double)a.SLong1);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcvtq_f64_s64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu64_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT))
                {
                    return usfcvtepu64_pd(a);
                }
                
                v128 magic_lo  = new v128(LIMIT_PRECISE_U64_F64);
                v128 magic_hi  = new v128(0x4530_0000_0000_0000);
                v128 magic_dbl = new v128(0x4530_0000_0010_0000);
                
                v128 hi = xor_si128(magic_hi, srli_epi64(a, 32));
                v128 lo;
                if (Sse4_1.IsSse41Supported)
                {
                    lo = blend_epi16(magic_lo, a, 0b011_0011);
                }
                else
                {
                    lo = or_si128(magic_lo, and_si128(a, set1_epi64x(uint.MaxValue)));
                }

                v128 hi_dbl = sub_pd(hi, magic_dbl);
                v128 result = add_pd(hi_dbl, lo);

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcvtq_f64_u64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi64_pd(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))
                {
                    return mm256_usfcvtepi64_pd(a);
                }


                v256 magic_lo  = new v256(LIMIT_PRECISE_U64_F64);
                v256 magic_hi  = new v256(0x4530_0000_8000_0000);
                v256 magic_dbl = new v256(0x4530_0000_8010_0000);

                v256 lo = Avx2.mm256_blend_epi32(magic_lo, a, 0b0101_0101);
                v256 hi = Avx2.mm256_xor_si256(magic_hi, Avx2.mm256_srli_epi64(a, 32));

                v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
                v256 result = Avx.mm256_add_pd(hi_dbl, lo);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu64_pd(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements))
                {
                    return mm256_usfcvtepu64_pd(a);
                }


                v256 magic_lo  = new v256(LIMIT_PRECISE_U64_F64);
                v256 magic_hi  = new v256(0x4530_0000_0000_0000);
                v256 magic_dbl = new v256(0x4530_0000_0010_0000);

                v256 lo = Avx2.mm256_blend_epi32(magic_lo, a, 0b0101_0101);
                v256 hi = Avx2.mm256_xor_si256(magic_hi, Avx2.mm256_srli_epi64(a, 32));

                v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
                v256 result = Avx.mm256_add_pd(hi_dbl, lo);

                return result;
            }
            else throw new IllegalInstructionException();
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epi8(v128 a, byte elements = 16, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvttpq_epi8(a, true, elements, positive);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epi8(v128 a, byte elements = 16, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi8(BASE_cvtpq_epi32(a, signed: true, positive: positive, elements: elements));
                }
                else if (elements <= 8)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi8(BASE_mm256_cvtpq_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi8(BASE_cvtpq_epi32(a,                                signed: true, positive: positive, elements: elements));
                        v128 hi = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, elements: elements));

                        return unpacklo_epi32(lo, hi);
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v128 lo = mm256_cvtepi32_epi8(BASE_mm256_cvtpq_epi32(a,                                signed: true, positive: positive, trunc: false));
                        v128 hi = mm256_cvtepi32_epi8(BASE_mm256_cvtpq_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, trunc: false));

                        return unpacklo_epi64(lo, hi);
                    }
                    else
                    {
                        v128 _0 = cvtepi32_epi8(BASE_cvtpq_epi32(a,                                 signed: true, positive: positive, elements: elements));
                        v128 _1 = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 4  * sizeof(byte)), signed: true, positive: positive, elements: elements));
                        v128 _2 = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 8  * sizeof(byte)), signed: true, positive: positive, elements: elements));
                        v128 _3 = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 12 * sizeof(byte)), signed: true, positive: positive, elements: elements));

                        v128 lo = unpacklo_epi32(_0, _1);
                        v128 hi = unpacklo_epi32(_2, _3);

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epu8(v128 a, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvttpq_epi8(a, false, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epu8(v128 a, byte elements = 16, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi8(BASE_cvtpq_epi32(a, signed: false, elements: elements));
                }
                else if (elements <= 8)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi8(BASE_mm256_cvtpq_epi32(a, signed: false, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi8(BASE_cvtpq_epi32(a,                                signed: false, elements: elements));
                        v128 hi = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, elements: elements));

                        return unpacklo_epi32(lo, hi);
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v128 lo = mm256_cvtepi32_epi8(BASE_mm256_cvtpq_epi32(a,                                signed: false, nonZero: nonZero, trunc: false));
                        v128 hi = mm256_cvtepi32_epi8(BASE_mm256_cvtpq_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: false));

                        return unpacklo_epi64(lo, hi);
                    }
                    else
                    {
                        v128 _0 = cvtepi32_epi8(BASE_cvtpq_epi32(a,                                 signed: false, elements: elements));
                        v128 _1 = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 4  * sizeof(byte)), signed: false, elements: elements));
                        v128 _2 = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 8  * sizeof(byte)), signed: false, elements: elements));
                        v128 _3 = cvtepi32_epi8(BASE_cvtpq_epi32(bsrli_si128(a, 12 * sizeof(byte)), signed: false, elements: elements));

                        v128 lo = unpacklo_epi32(_0, _1);
                        v128 hi = unpacklo_epi32(_2, _3);

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epi16(v128 a, byte elements = 8, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi8_epi16(cvttpq_epi8(a, elements, positive));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epi16(v128 a, byte elements = 8, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi16(BASE_cvtpq_epi32(a, signed: true, positive: positive, elements: elements));
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi16(BASE_mm256_cvtpq_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi16(BASE_cvtpq_epi32(a,                                signed: true, positive: positive, elements: elements));
                        v128 hi = cvtepi32_epi16(BASE_cvtpq_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, elements: elements));

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epu16(v128 a, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepu8_epi16(cvttpq_epu8(a, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epu16(v128 a, byte elements = 8, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi16(BASE_cvtpq_epi32(a, signed: false, elements: elements));
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi16(BASE_mm256_cvtpq_epi32(a, signed: false, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi16(BASE_cvtpq_epi32(a,                                signed: false, elements: elements));
                        v128 hi = cvtepi32_epi16(BASE_cvtpq_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, elements: elements));

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epi32(v128 a, byte elements = 4, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi8_epi32(cvttpq_epi8(a, elements, positive));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epi32(v128 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpq_epi32(a, signed: true, positive: positive, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epu32(v128 a, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepu8_epi32(cvttpq_epu8(a, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epu32(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpq_epi32(a, signed: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpq_epi32(v128 a, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi32(cvttpq_epi8(a, 8, positive));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtpq_epi32(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpq_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpq_epu32(v128 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi32(cvttpq_epu8(a, 8));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtpq_epu32(v128 a, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpq_epi32(a, signed: false, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epi64(v128 a, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi8_epi64(cvttpq_epi8(a, 2, positive));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epi64(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpq_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpq_epu64(v128 a, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepu8_epi64(cvttpq_epu8(a, 2));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpq_epu64(v128 a, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpq_epi64(a, signed: false, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpq_epi64(v128 a, byte elements = 4, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(cvttpq_epi8(a, elements, positive));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtpq_epi64(v128 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpq_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpq_epu64(v128 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(cvttpq_epu8(a, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtpq_epu64(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpq_epi64(a, signed: false, nonZero: nonZero, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epi8(v128 a, byte elements = 8, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi8(BASE_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));
                }
                else if (elements <= 8)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: true));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi8(BASE_cvtph_epi32(a,                                signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));
                        v128 hi = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));

                        return unpacklo_epi32(lo, hi);
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v128 lo = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a,                                signed: true, positive: positive, nonZero: nonZero, trunc: true));
                        v128 hi = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: true));

                        return unpacklo_epi64(lo, hi);
                    }
                    else
                    {
                        v128 _0 = cvtepi32_epi8(BASE_cvtph_epi32(a,                                 signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));
                        v128 _1 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4  * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));
                        v128 _2 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 8  * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));
                        v128 _3 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 12 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));

                        v128 lo = unpacklo_epi32(_0, _1);
                        v128 hi = unpacklo_epi32(_2, _3);

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epi8(v128 a, byte elements = 8, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi8(BASE_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));
                }
                else if (elements <= 8)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi8(BASE_cvtph_epi32(a,                                signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));
                        v128 hi = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));

                        return unpacklo_epi32(lo, hi);
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v128 lo = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a,                                signed: true, positive: positive, nonZero: nonZero, trunc: false));
                        v128 hi = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: false));

                        return unpacklo_epi64(lo, hi);
                    }
                    else
                    {
                        v128 _0 = cvtepi32_epi8(BASE_cvtph_epi32(a,                                 signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));
                        v128 _1 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4  * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));
                        v128 _2 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 8  * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));
                        v128 _3 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 12 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));

                        v128 lo = unpacklo_epi32(_0, _1);
                        v128 hi = unpacklo_epi32(_2, _3);

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epu8(v128 a, byte elements = 8, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi8(BASE_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: true, elements: elements));
                }
                else if (elements <= 8)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: true));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi8(BASE_cvtph_epi32(a,                                signed: false, nonZero: nonZero, trunc: true, elements: elements));
                        v128 hi = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: true, elements: elements));

                        return unpacklo_epi32(lo, hi);
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v128 lo = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a,                                signed: false, nonZero: nonZero, trunc: true));
                        v128 hi = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: true));

                        return unpacklo_epi64(lo, hi);
                    }
                    else
                    {
                        v128 _0 = cvtepi32_epi8(BASE_cvtph_epi32(a,                                 signed: false, nonZero: nonZero, trunc: true, elements: elements));
                        v128 _1 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4  * sizeof(byte)), signed: false, nonZero: nonZero, trunc: true, elements: elements));
                        v128 _2 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 8  * sizeof(byte)), signed: false, nonZero: nonZero, trunc: true, elements: elements));
                        v128 _3 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 12 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: true, elements: elements));

                        v128 lo = unpacklo_epi32(_0, _1);
                        v128 hi = unpacklo_epi32(_2, _3);

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epu8(v128 a, byte elements = 8, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi8(BASE_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: false, elements: elements));
                }
                else if (elements <= 8)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi8(BASE_cvtph_epi32(a,                                signed: false, nonZero: nonZero, trunc: false, elements: elements));
                        v128 hi = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: false, elements: elements));

                        return unpacklo_epi32(lo, hi);
                    }
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v128 lo = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(a,                                signed: false, nonZero: nonZero, trunc: false));
                        v128 hi = mm256_cvtepi32_epi8(BASE_mm256_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: false));

                        return unpacklo_epi64(lo, hi);
                    }
                    else
                    {
                        v128 _0 = cvtepi32_epi8(BASE_cvtph_epi32(a,                                 signed: false, nonZero: nonZero, trunc: false, elements: elements));
                        v128 _1 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 4  * sizeof(byte)), signed: false, nonZero: nonZero, trunc: false, elements: elements));
                        v128 _2 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 8  * sizeof(byte)), signed: false, nonZero: nonZero, trunc: false, elements: elements));
                        v128 _3 = cvtepi32_epi8(BASE_cvtph_epi32(bsrli_si128(a, 12 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: false, elements: elements));

                        v128 lo = unpacklo_epi32(_0, _1);
                        v128 hi = unpacklo_epi32(_2, _3);

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epi16(v128 a, byte elements = 8, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi16(BASE_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi16(BASE_mm256_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: true));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi16(BASE_cvtph_epi32(a,                                signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));
                        v128 hi = cvtepi32_epi16(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements));

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epi16(v128 a, byte elements = 8, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi16(BASE_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi16(BASE_mm256_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi16(BASE_cvtph_epi32(a,                                signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));
                        v128 hi = cvtepi32_epi16(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements));

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epu16(v128 a, byte elements = 8, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi16(BASE_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: true, elements: elements));
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi16(BASE_mm256_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: true));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi16(BASE_cvtph_epi32(a,                                signed: false, nonZero: nonZero, trunc: true, elements: elements));
                        v128 hi = cvtepi32_epi16(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: true, elements: elements));

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epu16(v128 a, byte elements = 8, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return cvtepi32_epi16(BASE_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: false, elements: elements));
                }
                else
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi16(BASE_mm256_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: false));
                    }
                    else
                    {
                        v128 lo = cvtepi32_epi16(BASE_cvtph_epi32(a,                                signed: false, nonZero: nonZero, trunc: false, elements: elements));
                        v128 hi = cvtepi32_epi16(BASE_cvtph_epi32(bsrli_si128(a, 4 * sizeof(byte)), signed: false, nonZero: nonZero, trunc: false, elements: elements));

                        return unpacklo_epi64(lo, hi);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epi32(v128 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epi32(v128 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epu32(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epu32(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttph_epi32(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtph_epi32(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi32(a, signed: true, positive: positive, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttph_epu32(v128 a, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtph_epu32(v128 a, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi32(a, signed: false, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epi64(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epi64(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttph_epu64(v128 a, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi64(a, signed: false, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtph_epu64(v128 a, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtph_epi64(a, signed: false, nonZero: nonZero, trunc: false);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttph_epi64(v128 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtph_epi64(v128 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttph_epu64(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi64(a, signed: false, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtph_epu64(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtph_epi64(a, signed: false, nonZero: nonZero, trunc: false, elements: elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttps_epi8(v128 a, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvttps_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtps_epi8(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttps_epu8(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvttps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtps_epu8(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttps_epi8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi8(Avx.mm256_cvttps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtps_epi8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi8(Avx.mm256_cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttps_epu8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi8(Avx.mm256_cvttps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtps_epu8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi8(Avx.mm256_cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttps_epi16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvttps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtps_epi16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttps_epu16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvttps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtps_epu16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttps_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi16(Avx.mm256_cvttps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtps_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi16(Avx.mm256_cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttps_epu16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi16(Avx.mm256_cvttps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtps_epu16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi32_epi16(Avx.mm256_cvtps_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtps_epu32(v128 a, byte elements = 4, bool nonZero = false, bool evenOnTie = true)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtps_epu32(a, nonZero: nonZero, trunc: false, elements: elements, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttps_epu32(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtps_epu32(a, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtps_epu32(v256 a, bool evenOnTie = true, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtps_epu32(a, nonZero: nonZero, trunc: false, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttps_epu32(v256 a, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtps_epu32(a, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtps_epi64(v128 a, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtps_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttps_epi64(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtps_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtps_epu64(v128 a, bool evenOnTie = true, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtps_epi64(a, signed: false, nonZero: nonZero, trunc: false, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttps_epu64(v128 a, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtps_epi64(a, signed: false, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtps_epi64(v128 a, byte elements = 4, bool nonZero = false, bool positive = false, bool evenOnTie = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtps_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttps_epi64(v128 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtps_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtps_epu64(v128 a, byte elements = 4, bool nonZero = false, bool evenOnTie = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtps_epi64(a, signed: false, nonZero: nonZero, trunc: false, elements: elements, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttps_epu64(v128 a, byte elements = 4, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtps_epi64(a, signed: false, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpd_epi8(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvtpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epi8(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvttpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpd_epu8(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvtpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epu8(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi8(cvttpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtpd_epi8(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi8(Avx.mm256_cvtpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttpd_epi8(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi8(Avx.mm256_cvttpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtpd_epu8(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi8(Avx.mm256_cvtpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttpd_epu8(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi8(Avx.mm256_cvttpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpd_epi16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvtpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epi16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvttpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpd_epu16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvtpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epu16(v128 a)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi32_epi16(cvttpd_epi32(a), 2);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtpd_epi16(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi16(Avx.mm256_cvtpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttpd_epi16(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi16(Avx.mm256_cvttpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtpd_epu16(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi16(Avx.mm256_cvtpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttpd_epu16(v256 a, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return cvtepi32_epi16(Avx.mm256_cvttpd_epi32(a), elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpd_epu32(v128 a, bool evenOnTie = true, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi64_epi32(BASE_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: false, evenOnTie: evenOnTie));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epu32(v128 a, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cvtepi64_epi32(BASE_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: true));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtpd_epu32(v256 a, byte elements = 4, bool nonZero = false, bool evenOnTie = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi64_epi32(BASE_mm256_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: false, elements: elements, evenOnTie: evenOnTie));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvttpd_epu32(v256 a, byte elements = 4, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvtepi64_epi32(BASE_mm256_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: true, elements: elements));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpd_epi64(v128 a, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpd_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epi64(v128 a, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpd_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtpd_epu64(v128 a, bool evenOnTie = true, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: false, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvttpd_epu64(v128 a, bool nonZero = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return BASE_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: true);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtpd_epi64(v256 a, byte elements = 4, bool nonZero = false, bool positive = false, bool evenOnTie = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpd_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: false, elements: elements, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpd_epi64(v256 a, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpd_epi64(a, signed: true, positive: positive, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtpd_epu64(v256 a, byte elements = 4, bool nonZero = false, bool evenOnTie = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: false, elements: elements, evenOnTie: evenOnTie);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvttpd_epu64(v256 a, byte elements = 4, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                return BASE_mm256_cvtpd_epi64(a, signed: false, nonZero: nonZero, trunc: true, elements: elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvttpq_epi8(v128 a, bool signed, byte elements = 16, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                positive |= (constexpr.ALL_GT_EPU8(a, 0, elements) && constexpr.ALL_LT_EPU8(a, 1 << 7, elements));

                v128 exp = srli_epi8(a, quarter.MANTISSA_BITS);
                v128 mantissa = and_si128(a, set1_epi8(maxmath.bitmask8(quarter.MANTISSA_BITS)));
                
                v128 lo;
                v128 hi;
                if (Architecture.IsTableLookupSupported)
                {
                    v128 shr = shuffle_epi8(new v128(4, 4, 4, 4, 3, 2, 1, 0,   4, 4, 4, 4, 3, 2, 1, 0), exp);
                    hi = shuffle_epi8(new v128(0, 0, 0, 1, 2, 4, 8, 0,   0, 0, 0,-1,-2,-4,-8, 0), exp);
                
                    lo = srlv_epi8(mantissa, shr, elements: elements, inRange: true);
                    if (signed && !positive)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            lo = sign_epi8(lo, a);
                        }
                        else
                        {
                            v128 signMask = srai_epi8(a, 7, elements: elements);
                            lo = sub_epi8(xor_si128(lo, signMask), signMask);
                        }
                    }
                }
                else
                {
                    v128 absExp = exp;
                    if (signed && !positive)
                    {
                        absExp = and_si128(absExp, set1_epi8(maxmath.bitmask8(quarter.EXPONENT_BITS)));
                    }
                
                    v128 expGT2 = cmpgt_epi8(absExp, set1_epi8(2));
                    v128 expGT3 = cmpgt_epi8(absExp, set1_epi8(3));
                    v128 expGT4 = cmpgt_epi8(absExp, set1_epi8(4));
                    v128 expGT5 = cmpgt_epi8(absExp, set1_epi8(5));
                
                    hi = negmask_epi8(expGT2, elements: elements);
                    hi = add_epi8(hi, and_si128(hi, expGT3));
                    hi = add_epi8(hi, and_si128(hi, expGT4));
                    hi = add_epi8(hi, and_si128(hi, expGT5));
                
                    v128 shr0 = mantissa;
                    v128 shr1 = srli_epi8(mantissa, 1);
                    v128 shr2 = srli_epi8(mantissa, 2);
                    v128 shr3 = srli_epi8(mantissa, 3);

                    lo = blendv_si128(blendv_si128(blendv_si128(shr0, shr3, expGT3), shr2, expGT4), shr1, expGT5);
                    if (signed && !positive)
                    {
                        v128 signMask = srai_epi8(a, 7, elements: elements);
                        hi = sub_epi8(xor_si128(hi, signMask), signMask);
                        lo = sub_epi8(xor_si128(lo, signMask), signMask);
                    }
                }
                
                return add_epi8(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvtpq_epi32(v128 a, bool signed, bool evenOnTie = true, byte elements = 4, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                positive |= (constexpr.ALL_GT_EPU8(a, 0, elements) && constexpr.ALL_LT_EPU8(a, 1 << 7, elements));

                v128 IMPLICIT_ONE = set1_epi32(1u << quarter.MANTISSA_BITS);
                v128 MANTISSA_MASK = set1_epi32(maxmath.bitmask32(quarter.MANTISSA_BITS));
                v128 EXP = set1_epi32(math.abs(quarter.EXPONENT_BIAS) + quarter.MANTISSA_BITS);
                
                v128 a32 = cvtepu8_epi32(a);
                
                v128 biasedExponent;
                v128 isZero;
                if (positive || !signed)
                {
                    biasedExponent = srli_epi32(a32, quarter.MANTISSA_BITS);
                    isZero = cmpgt_epi32(set1_epi32(((quarter)0.5f).value), a32);
                }
                else
                {
                    biasedExponent = srli_epi32(slli_epi32(a32, 1 + 24), quarter.MANTISSA_BITS + 1 + 24);
                    isZero = cmpgt_epu32(slli_epi32(set1_epi32(((quarter)0.5f).value), 1 + 24), slli_epi32(a32, 1 + 24));
                }
                
                v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a32, MANTISSA_MASK, TernaryOperation.OxF8);
                v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                v128 shift_int = subs_epu16(biasedExponent, EXP);
                
                v128 result = sllv_epi32(mantissa, shift_int, elements: elements);
                
                v128 ifRound = neg_epi16(cmpgt_epi16(EXP, biasedExponent));
                v128 round = sllv_epi32(ifRound, dec_epi32(shift_mnt), elements: elements);
                if (evenOnTie)
                {
                    round = sub_epi32(round, andnot_si128(srlv_epi32(mantissa, shift_mnt, elements: elements), ifRound));
                }
                result = add_epi32(result, round);
                
                result = andnot_si128(isZero, result);
                result = srlv_epi32(result, shift_mnt, elements: elements);
                
                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU8(a, 1 << 7, elements))
                    {
                        v128 signMask = cmpge_epu8(a, set1_epi8(0b1000_0001));
                
                        if (Ssse3.IsSsse3Supported)
                        {
                            signMask = or_si128(signMask, neg_epi8(cmpeq_epi8(signMask, setzero_si128())));
                            result = sign_epi32(result, cvtepi8_epi32(signMask));
                        }
                        else
                        {
                            signMask = cvtepi8_epi32(signMask);
                
                            result = xor_si128(result, signMask);
                            result = sub_epi32(result, signMask);
                        }
                    }
                }
                
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 BASE_mm256_cvtpq_epi32(v128 a, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonZero |= (constexpr.ALL_NEQ_EPU8(a, 0, 8) && constexpr.ALL_NEQ_EPU8(a, 1 << 7, 8));
                positive |= (constexpr.ALL_GT_EPU8(a, 0, 8) && constexpr.ALL_LT_EPU8(a, 1 << 7, 8));

                v256 IMPLICIT_ONE = mm256_set1_epi32(1u << quarter.MANTISSA_BITS);
                v256 MANTISSA_MASK = mm256_set1_epi32(maxmath.bitmask32(quarter.MANTISSA_BITS));
                v256 EXP = mm256_set1_epi32(math.abs(quarter.EXPONENT_BIAS) + quarter.MANTISSA_BITS);

                v256 a32 = Avx2.mm256_cvtepu8_epi32(a);

                v256 biasedExponent;
                v256 isZero;
                if (positive || !signed)
                {
                    biasedExponent = Avx2.mm256_srli_epi32(a32, quarter.MANTISSA_BITS);
                    isZero = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(((quarter)(trunc ? 1f : 0.5f)).value), a32);
                }
                else
                {
                    biasedExponent = Avx2.mm256_srli_epi32(Avx2.mm256_slli_epi32(a32, 1 + 24), quarter.MANTISSA_BITS + 1 + 24);
                    isZero = mm256_cmpgt_epu32(Avx2.mm256_slli_epi32(mm256_set1_epi32(((quarter)(trunc ? 1f : 0.5f)).value), 1 + 24), Avx2.mm256_slli_epi32(a32, 1 + 24));
                }
                
                v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a32, MANTISSA_MASK, TernaryOperation.OxF8);
                v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                v256 result = Avx2.mm256_sllv_epi32(mantissa, shift_int);

                if (!trunc)
                {
                    v256 ifRound = mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(EXP, biasedExponent));
                    v256 round = Avx2.mm256_sllv_epi32(ifRound, mm256_dec_epi32(shift_mnt));
                    if (evenOnTie)
                    {
                        round = Avx2.mm256_sub_epi32(round, Avx2.mm256_andnot_si256(Avx2.mm256_srlv_epi32(mantissa, shift_mnt), ifRound));
                    }
                    result = Avx2.mm256_add_epi32(result, round);
                }
                
                result = Avx2.mm256_andnot_si256(isZero, result);
                result = Avx2.mm256_srlv_epi32(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU8(a, 1 << 7, 8))
                    {
                        v128 signMask = cmpge_epu8(a, set1_epi8(0b1000_0001));
                        signMask = or_si128(signMask, neg_epi8(cmpeq_epi8(signMask, setzero_si128())));

                        result = Avx2.mm256_sign_epi32(result, Avx2.mm256_cvtepi8_epi32(signMask));
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvtpq_epi64(v128 a, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                nonZero |= (constexpr.ALL_NEQ_EPU8(a, 0, 2) && constexpr.ALL_NEQ_EPU8(a, 1 << 7, 2));
                positive |= (constexpr.ALL_GT_EPU8(a, 0, 2) && constexpr.ALL_LT_EPU8(a, 1 << 7, 2));

                v128 IMPLICIT_ONE = set1_epi64x(1u << quarter.MANTISSA_BITS);
                v128 MANTISSA_MASK = set1_epi64x(maxmath.bitmask32(quarter.MANTISSA_BITS));
                v128 EXP = set1_epi64x(math.abs(quarter.EXPONENT_BIAS) + quarter.MANTISSA_BITS);

                v128 a64 = cvtepu8_epi64(a);

                v128 biasedExponent;
                v128 isZero;
                if (positive || !signed)
                {
                    biasedExponent = srli_epi64(a64, quarter.MANTISSA_BITS);
                    isZero = shuffle_epi32(cmpgt_epi32(set1_epi32(((quarter)(trunc ? 1f : 0.5f)).value), a64), Sse.SHUFFLE(2, 2, 0, 0));
                }
                else
                {
                    biasedExponent = srli_epi64(slli_epi64(a64, 1 + 56), quarter.MANTISSA_BITS + 1 + 56);
                    isZero = shuffle_epi32(cmpgt_epu32(slli_epi64(set1_epi64x(((quarter)(trunc ? 1f : 0.5f)).value), 1 + 56 - 32), slli_epi64(a64, 1 + 56 - 32)), Sse.SHUFFLE(3, 3, 1, 1));
                }
                
                v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a64, MANTISSA_MASK, TernaryOperation.OxF8);
                v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                v128 shift_int = subs_epu16(biasedExponent, EXP);

                v128 result = sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v128 ifRound = neg_epi16(cmpgt_epi16(EXP, biasedExponent));
                    v128 round = sllv_epi64(ifRound, dec_epi64(shift_mnt));
                    if (evenOnTie)
                    {
                        round = sub_epi64(round, andnot_si128(srlv_epi64(mantissa, shift_mnt), ifRound));
                    }
                    result = add_epi64(result, round);
                }
                
                result = andnot_si128(isZero, result);
                result = srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU8(a, 1 << 7, 2))
                    {
                        v128 signMask = cmpge_epu8(a, set1_epi8(0b1000_0001));
                        signMask = cvtepi8_epi64(signMask);

                        result = xor_si128(result, signMask);
                        result = sub_epi64(result, signMask);
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 BASE_mm256_cvtpq_epi64(v128 a, bool signed, bool trunc, bool evenOnTie = true, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonZero |= (constexpr.ALL_NEQ_EPU8(a, 0, elements) && constexpr.ALL_NEQ_EPU8(a, 1 << 7, elements));
                positive |= (constexpr.ALL_GT_EPU8(a, 0, elements) && constexpr.ALL_LT_EPU8(a, 1 << 7, elements));

                v256 IMPLICIT_ONE = mm256_set1_epi64x(1u << quarter.MANTISSA_BITS);
                v256 MANTISSA_MASK = mm256_set1_epi64x(maxmath.bitmask32(quarter.MANTISSA_BITS));
                v256 EXP = mm256_set1_epi64x(math.abs(quarter.EXPONENT_BIAS) + quarter.MANTISSA_BITS);

                v256 a64 = Avx2.mm256_cvtepu8_epi64(a);

                v256 biasedExponent;
                v256 isZero;
                if (positive || !signed)
                {
                    biasedExponent = Avx2.mm256_srli_epi64(a64, quarter.MANTISSA_BITS);
                    isZero = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(mm256_set1_epi64x(((quarter)(trunc ? 1f : 0.5f)).value), a64), Sse.SHUFFLE(2, 2, 0, 0));
                }
                else
                {
                    biasedExponent = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(a64, 1 + 56), quarter.MANTISSA_BITS + 1 + 56);
                    isZero = Avx2.mm256_shuffle_epi32(mm256_cmpgt_epu32(Avx2.mm256_slli_epi64(mm256_set1_epi64x(((quarter)(trunc ? 1f : 0.5f)).value), 56 + 1), Avx2.mm256_slli_epi64(a64, 56 + 1)), Sse.SHUFFLE(3, 3, 1, 1));
                }
                
                v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a64, MANTISSA_MASK, TernaryOperation.OxF8);
                v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                v256 result = Avx2.mm256_sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v256 ifRound = mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(EXP, biasedExponent));
                    v256 round = Avx2.mm256_sllv_epi64(ifRound, mm256_dec_epi64(shift_mnt));
                    if (evenOnTie)
                    {
                        round = Avx2.mm256_sub_epi64(round, Avx2.mm256_andnot_si256(Avx2.mm256_srlv_epi64(mantissa, shift_mnt), ifRound));
                    }
                    result = Avx2.mm256_add_epi64(result, round);
                }
                
                result = Avx2.mm256_andnot_si256(isZero, result);
                result = Avx2.mm256_srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU8(a, 1 << 7, elements))
                    {
                        v128 signMask = cmpge_epu8(a, set1_epi8(0b1000_0001));
                        v256 signMask256 = Avx2.mm256_cvtepi8_epi64(signMask);

                        result = Avx2.mm256_xor_si256(result, signMask256);
                        result = Avx2.mm256_sub_epi64(result, signMask256);
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvtph_epi32(v128 a, bool signed, bool trunc, bool evenOnTie = true, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                nonZero |= (constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU16(a, 1 << 15, elements));
                positive |= (constexpr.ALL_GT_EPU16(a, 0, elements) && constexpr.ALL_LT_EPU16(a, 1 << 15, elements));

                v128 IMPLICIT_ONE = set1_epi32(1u << F16_MANTISSA_BITS);
                v128 MANTISSA_MASK = set1_epi32(maxmath.bitmask32(F16_MANTISSA_BITS));
                v128 EXP = set1_epi32(math.abs(F16_EXPONENT_BIAS) + F16_MANTISSA_BITS);

                v128 a32 = cvtepu16_epi32(a);

                v128 biasedExponent;
                v128 isZero;
                if (positive || !signed)
                {
                    biasedExponent = srli_epi32(a32, F16_MANTISSA_BITS);
                    isZero = cmpgt_epi32(set1_epi32(((half)(trunc ? 1f : 0.5f)).value), a32);
                }
                else
                {
                    biasedExponent = srli_epi32(slli_epi32(a32, 1 + 16), F16_MANTISSA_BITS + 1 + 16);
                    isZero = cmpgt_epu32(slli_epi32(set1_epi32(((half)(trunc ? 1f : 0.5f)).value), 1 + 16), slli_epi32(a32, 1 + 16));
                }
                
                v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a32, MANTISSA_MASK, TernaryOperation.OxF8);
                v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                v128 shift_int = subs_epu16(biasedExponent, EXP);

                v128 result = sllv_epi32(mantissa, shift_int, elements: elements);

                if (!trunc)
                {
                    v128 ifRound = neg_epi16(cmpgt_epi16(EXP, biasedExponent));
                    v128 round = sllv_epi32(ifRound, dec_epi32(shift_mnt), elements: elements);
                    if (evenOnTie)
                    {
                        round = sub_epi32(round, andnot_si128(srlv_epi32(mantissa, shift_mnt, elements: elements), ifRound));
                    }
                    result = add_epi32(result, round);
                }
                
                result = andnot_si128(isZero, result);
                result = srlv_epi32(result, shift_mnt, elements: elements);

                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU16(a, 1 << 15, elements))
                    {
                        v128 signMask = cmpge_epu16(a, set1_epi16(0x8001));

                        if (Ssse3.IsSsse3Supported)
                        {
                            signMask = or_si128(signMask, neg_epi16(cmpeq_epi16(signMask, setzero_si128())));
                            result = sign_epi32(result, cvtepi16_epi32(signMask));
                        }
                        else
                        {
                            signMask = cvtepi16_epi32(signMask);

                            result = xor_si128(result, signMask);
                            result = sub_epi32(result, signMask);
                        }
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 BASE_mm256_cvtph_epi32(v128 a, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonZero |= (constexpr.ALL_NEQ_EPU16(a, 0, 8) && constexpr.ALL_NEQ_EPU16(a, 1 << 15, 8));
                positive |= (constexpr.ALL_GT_EPU16(a, 0, 8) && constexpr.ALL_LT_EPU16(a, 1 << 15, 8));

                v256 IMPLICIT_ONE = mm256_set1_epi32(1u << F16_MANTISSA_BITS);
                v256 MANTISSA_MASK = mm256_set1_epi32(maxmath.bitmask32(F16_MANTISSA_BITS));
                v256 EXP = mm256_set1_epi32(math.abs(F16_EXPONENT_BIAS) + F16_MANTISSA_BITS);

                v256 a32 = Avx2.mm256_cvtepu16_epi32(a);
                
                v256 biasedExponent;
                v256 isZero;
                if (positive || !signed)
                {
                    biasedExponent = Avx2.mm256_srli_epi32(a32, F16_MANTISSA_BITS);
                    isZero = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(((half)(trunc ? 1f : 0.5f)).value), a32);
                }
                else
                {
                    biasedExponent = Avx2.mm256_srli_epi32(Avx2.mm256_slli_epi32(a32, 1 + 16), F16_MANTISSA_BITS + 1 + 16);
                    isZero = mm256_cmpgt_epu32(Avx2.mm256_slli_epi32(mm256_set1_epi32(((half)(trunc ? 1f : 0.5f)).value), 1 + 16), Avx2.mm256_slli_epi32(a32, 1 + 16));
                }
                
                v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a32, MANTISSA_MASK, TernaryOperation.OxF8);
                v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                v256 result = Avx2.mm256_sllv_epi32(mantissa, shift_int);

                if (!trunc)
                {
                    v256 ifRound = mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(EXP, biasedExponent));
                    v256 round = Avx2.mm256_sllv_epi32(ifRound, mm256_dec_epi32(shift_mnt));
                    if (evenOnTie)
                    {
                        round = Avx2.mm256_sub_epi32(round, Avx2.mm256_andnot_si256(Avx2.mm256_srlv_epi32(mantissa, shift_mnt), ifRound));
                    }
                    result = Avx2.mm256_add_epi32(result, round);
                }
                
                result = Avx2.mm256_andnot_si256(isZero, result);
                result = Avx2.mm256_srlv_epi32(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU16(a, 1 << 15))
                    {
                        v128 signMask = cmpge_epu16(a, set1_epi16(0x8001));
                        signMask = or_si128(signMask, neg_epi16(cmpeq_epi16(signMask, setzero_si128())));

                        result = Avx2.mm256_sign_epi32(result, Avx2.mm256_cvtepi16_epi32(signMask));
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvtph_epi64(v128 a, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                nonZero |= (constexpr.ALL_NEQ_EPU16(a, 0, 2) && constexpr.ALL_NEQ_EPU16(a, 1 << 15, 2));
                positive |= (constexpr.ALL_GT_EPU16(a, 0, 2) && constexpr.ALL_LT_EPU16(a, 1 << 15, 2));

                v128 IMPLICIT_ONE = set1_epi64x(1u << F16_MANTISSA_BITS);
                v128 MANTISSA_MASK = set1_epi64x(maxmath.bitmask32(F16_MANTISSA_BITS));
                v128 EXP = set1_epi64x(math.abs(F16_EXPONENT_BIAS) + F16_MANTISSA_BITS);

                v128 a64 = cvtepu16_epi64(a);

                v128 biasedExponent;
                v128 isZero;
                if (positive || !signed)
                {
                    biasedExponent = srli_epi64(a64, F16_MANTISSA_BITS);
                    isZero = shuffle_epi32(cmpgt_epi32(set1_epi64x(((half)(trunc ? 1f : 0.5f)).value), a64), Sse.SHUFFLE(2, 2, 0, 0));
                }
                else
                {
                    biasedExponent = srli_epi64(slli_epi64(a64, 1 + 48), F16_MANTISSA_BITS + 1 + 48);
                    isZero = shuffle_epi32(cmpgt_epu32(slli_epi64(set1_epi64x(((half)(trunc ? 1f : 0.5f)).value), 1 + 48), slli_epi64(a64, 1 + 48)), Sse.SHUFFLE(3, 3, 1, 1));
                }
                
                v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a64, MANTISSA_MASK, TernaryOperation.OxF8);
                v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                v128 shift_int = subs_epu16(biasedExponent, EXP);

                v128 result = sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v128 ifRound = neg_epi16(cmpgt_epi16(EXP, biasedExponent));
                    v128 round = sllv_epi64(ifRound, dec_epi64(shift_mnt));
                    if (evenOnTie)
                    {
                        round = sub_epi64(round, andnot_si128(srlv_epi64(mantissa, shift_mnt), ifRound));
                    }
                    result = add_epi64(result, round);
                }
                
                result = andnot_si128(isZero, result);
                result = srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU16(a, 1 << 5, 2))
                    {
                        v128 signMask = cmpge_epu16(a, set1_epi16(0x8001));
                        signMask = cvtepi16_epi64(signMask);

                        result = xor_si128(result, signMask);
                        result = sub_epi64(result, signMask);
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 BASE_mm256_cvtph_epi64(v128 a, bool signed, bool trunc, bool evenOnTie = true, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonZero |= (constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU16(a, 1 << 15, elements));
                positive |= (constexpr.ALL_GT_EPU16(a, 0, elements) && constexpr.ALL_LT_EPU16(a, 1 << 15, elements));

                v256 IMPLICIT_ONE = mm256_set1_epi64x(1u << F16_MANTISSA_BITS);
                v256 MANTISSA_MASK = mm256_set1_epi64x(maxmath.bitmask32(F16_MANTISSA_BITS));
                v256 EXP = mm256_set1_epi64x(math.abs(F16_EXPONENT_BIAS) + F16_MANTISSA_BITS);

                v256 a64 = Avx2.mm256_cvtepu16_epi64(a);

                v256 biasedExponent;
                v256 isZero;
                if (positive || !signed)
                {
                    biasedExponent = Avx2.mm256_srli_epi64(a64, F16_MANTISSA_BITS);
                    isZero = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(mm256_set1_epi64x(((half)(trunc ? 1f : 0.5f)).value), a64), Sse.SHUFFLE(2, 2, 0, 0));
                }
                else
                {
                    biasedExponent = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(a64, 1 + 48), F16_MANTISSA_BITS + 1 + 48);
                    isZero = Avx2.mm256_shuffle_epi32(mm256_cmpgt_epu32(mm256_slli_epi64(mm256_set1_epi64x(((half)(trunc ? 1f : 0.5f)).value), 1 + 48), mm256_slli_epi64(a64, 1 + 48)), Sse.SHUFFLE(3, 3, 1, 1));
                }
                
                v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a64, MANTISSA_MASK, TernaryOperation.OxF8);
                v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                v256 result = Avx2.mm256_sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v256 ifRound = mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(EXP, biasedExponent));
                    v256 round = Avx2.mm256_sllv_epi64(ifRound, mm256_dec_epi64(shift_mnt));
                    if (evenOnTie)
                    {
                        round = Avx2.mm256_sub_epi64(round, Avx2.mm256_andnot_si256(Avx2.mm256_srlv_epi64(mantissa, shift_mnt), ifRound));
                    }
                    result = Avx2.mm256_add_epi64(result, round);
                }
                
                result = Avx2.mm256_andnot_si256(isZero, result);
                result = Avx2.mm256_srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_LT_EPU16(a, 1 << 15, elements))
                    {
                        v128 signMask = cmpge_epu16(a, set1_epi16(0x8001));
                        v256 signMask256 = Avx2.mm256_cvtepi16_epi64(signMask);

                        result = Avx2.mm256_xor_si256(result, signMask256);
                        result = Avx2.mm256_sub_epi64(result, signMask256);
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvtps_epu32(v128 a, bool trunc, byte elements = 4, bool evenOnTie = true, bool nonZero = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (!trunc)
                {
                    if (constexpr.ALL_GE_PS(a, 0f, elements) && constexpr.ALL_LE_PS(a, int.MaxValue, elements))
                    {
                        return cvtps_epi32(a);
                    }
                }
                
                nonZero |= constexpr.ALL_NEQ_PS(a, 0, elements);

                if (Avx2.IsAvx2Supported)
                {
                    if (trunc)
                    {
                        v128 IMPLICIT_ONE = set1_epi32(1u << F32_MANTISSA_BITS);
                        v128 MANTISSA_MASK = set1_epi32(maxmath.bitmask32(F32_MANTISSA_BITS));
                        v128 EXP = set1_epi32(math.abs(F32_EXPONENT_BIAS) + F32_MANTISSA_BITS);

                        v128 biasedExponent = srli_epi32(a, F32_MANTISSA_BITS);
                        v128 isZero = cmpgt_epi32(set1_ps(1f), a);
                        
                        v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a, MANTISSA_MASK, TernaryOperation.OxF8);
                        v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                        v128 shift_int = subs_epu16(biasedExponent, EXP);

                        v128 result = sllv_epi32(mantissa, shift_int, elements: elements);
                        result = srlv_epi32(result, shift_mnt, elements: elements);
                        result = andnot_si128(isZero, result);

                        return result;
                    }
                }

                if (elements == 4)
                {
                    if (trunc)
                    {
                        v128 signedCvt = cvttps_epi32(a);
                        v128 outsideSignedRange = srai_epi32(signedCvt, 31);
                        v128 overflow = sub_ps(a, set1_epi32(0x4F00_0000));
                        overflow = cvttps_epi32(overflow);

                        return ternarylogic_si128(signedCvt, outsideSignedRange, overflow, TernaryOperation.OxF8);
                    }
                    else
                    {
                        v128 signedCvt = cvtps_epi32(a);
                        v128 outsideSignedRange = srai_epi32(signedCvt, 31);
                        v128 overflow = sub_ps(a, set1_epi32(0x4F00_0000));
                        overflow = cvtps_epi32(overflow);

                        return ternarylogic_si128(signedCvt, outsideSignedRange, overflow, TernaryOperation.OxF8);
                    }
                }
                if (trunc)
                {
                    uint u0 = (uint)cvttss_si64(a);
                    uint u1 = (uint)cvttss_si64(bsrli_si128(a, 1 * sizeof(float)));
                    v128 u01 = unpacklo_epi32(cvtsi32_si128(u0), cvtsi32_si128(u1));

                    if (elements > 2)
                    {
                        uint u2 = (uint)cvttss_si64(bsrli_si128(a, 2 * sizeof(float)));

                        return unpacklo_epi64(u01, cvtsi32_si128(u2));
                    }
                    else
                    {
                        return u01;
                    }
                }
                else
                {
                    uint u0 = (uint)cvtss_si64(a);
                    uint u1 = (uint)cvtss_si64(bsrli_si128(a, 1 * sizeof(float)));
                    v128 u01 = unpacklo_epi32(cvtsi32_si128(u0), cvtsi32_si128(u1));

                    if (elements > 2)
                    {
                        uint u2 = (uint)cvtss_si64(bsrli_si128(a, 2 * sizeof(float)));

                        return unpacklo_epi64(u01, cvtsi32_si128(u2));
                    }
                    else
                    {
                        return u01;
                    }
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                if (trunc)
                {
                    return Arm.Neon.vcvtq_u32_f32(a);
                }
                else
                {
                    return Arm.Neon.vcvtnq_u32_f32(a);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 BASE_mm256_cvtps_epu32(v256 a, bool trunc, bool evenOnTie = true, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (trunc)
                {
                    v256 IMPLICIT_ONE = mm256_set1_epi32(1u << F32_MANTISSA_BITS);
                    v256 MANTISSA_MASK = mm256_set1_epi32(maxmath.bitmask32(F32_MANTISSA_BITS));
                    v256 EXP = mm256_set1_epi32(math.abs(F32_EXPONENT_BIAS) + F32_MANTISSA_BITS);

                    v256 biasedExponent = Avx2.mm256_srli_epi32(a, F32_MANTISSA_BITS);
                    v256 isZero = Avx2.mm256_cmpgt_epi32(mm256_set1_ps(1f), a);
                    
                    v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a, MANTISSA_MASK, TernaryOperation.OxF8);
                    v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                    v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                    v256 result = Avx2.mm256_sllv_epi32(mantissa, shift_int);
                    result = Avx2.mm256_srlv_epi32(result, shift_mnt);
                    result = Avx2.mm256_andnot_si256(isZero, result);

                    return result;
                }
                else
                {
                    if (constexpr.ALL_GE_PS(a, 0f) && constexpr.ALL_LE_PS(a, int.MaxValue))
                    {
                        return Avx.mm256_cvtps_epi32(a);
                    }

                    v256 signedCvt = Avx.mm256_cvtps_epi32(a);
                    v256 outsideSignedRange = mm256_srai_epi32(signedCvt, 31);
                    v256 overflow = Avx.mm256_sub_ps(a, mm256_set1_epi32(0x4F00_0000));
                    overflow = Avx.mm256_cvtps_epi32(overflow);
                    
                    return mm256_ternarylogic_si256(signedCvt, outsideSignedRange, overflow, TernaryOperation.OxF8);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvtps_epi64(v128 a, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (Avx2.IsAvx2Supported)
                {
                    ;
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (signed)
                    {
                        if (trunc)
                        {
                            return unpacklo_epi64(cvtsi64x_si128(cvttss_si64(a)), cvtsi64x_si128(cvttss_si64(bsrli_si128(a, sizeof(float)))));
                        }
                        else
                        {
                            return unpacklo_epi64(cvtsi64x_si128(cvttss_si64(a)), cvtsi64x_si128(cvttss_si64(bsrli_si128(a, sizeof(float)))));
                        }
                    }
                }

                nonZero |= constexpr.ALL_NEQ_PS(a, 0, 2);
                positive |= constexpr.ALL_GT_PS(a, 0, 2);

                v128 IMPLICIT_ONE = set1_epi64x(1L << F32_MANTISSA_BITS);
                v128 MANTISSA_MASK = set1_epi64x(maxmath.bitmask64((long)F32_MANTISSA_BITS));
                v128 EXP = set1_epi64x(math.abs(F32_EXPONENT_BIAS) + F32_MANTISSA_BITS);

                v128 a64 = cvtepu32_epi64(a);

                v128 biasedExponent;
                v128 isZero;
                if (positive || !signed)
                {
                    biasedExponent = srli_epi64(a64, F32_MANTISSA_BITS);
                    isZero = cmpgt_epi32(set1_ps(trunc ? 1f : 0.5f), a);
                }
                else
                {
                    biasedExponent = srli_epi64(slli_epi64(a64, 1 + 32), F32_MANTISSA_BITS + 1 + 32);
                    isZero = cmpgt_epu32(slli_epi32(set1_ps(trunc ? 1f : 0.5f), 1), slli_epi32(a, 1));
                }

                if (Sse4_1.IsSse41Supported)
                {
                    isZero = cvtepi32_epi64(isZero);
                }
                else
                {
                    isZero = shuffle_epi32(isZero, Sse.SHUFFLE(1, 1, 0, 0));
                }

                v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a64, MANTISSA_MASK, TernaryOperation.OxF8);
                v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                v128 shift_int = subs_epu16(biasedExponent, EXP);

                v128 result = sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v128 ifRound = neg_epi16(cmpgt_epi16(EXP, biasedExponent));
                    v128 round = sllv_epi64(ifRound, dec_epi64(shift_mnt));
                    if (evenOnTie)
                    {
                        round = sub_epi64(round, andnot_si128(srlv_epi64(mantissa, shift_mnt), ifRound));
                    }

                    result = add_epi64(result, round);
                }
                
                result = andnot_si128(isZero, result);
                result = srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_GE_PS(a, 0f, 2))
                    {
                        v128 signMask = cmpgt_ps(setzero_si128(), a);
                        signMask = shuffle_epi32(signMask, Sse.SHUFFLE(1, 1, 0, 0));

                        result = xor_si128(result, signMask);
                        result = sub_epi64(result, signMask);
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 BASE_mm256_cvtps_epi64(v128 a, bool signed, bool trunc, bool evenOnTie = true, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonZero |= constexpr.ALL_NEQ_PS(a, 0, elements);
                positive |= constexpr.ALL_GT_PS(a, 0, elements);

                v256 IMPLICIT_ONE = mm256_set1_epi64x(1L << F32_MANTISSA_BITS);
                v256 MANTISSA_MASK = mm256_set1_epi64x(maxmath.bitmask64((long)F32_MANTISSA_BITS));
                v256 EXP = mm256_set1_epi64x(math.abs(F32_EXPONENT_BIAS) + F32_MANTISSA_BITS);

                v256 a64 = Avx2.mm256_cvtepu32_epi64(a);

                v256 biasedExponent;
                v256 isZero;
                if (positive || (!signed && nonZero) || (!signed && !COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO) | constexpr.ALL_LT_EPU32(a, 1u << 31, elements) || constexpr.ALL_GT_PS(a, 0f, elements))
                {
                    biasedExponent = Avx2.mm256_srli_epi64(a64, F32_MANTISSA_BITS);
                    isZero = Avx2.mm256_cvtepi32_epi64(cmpgt_epi32(set1_ps(trunc ? 1f : 0.5f), a));
                }
                else
                {
                    biasedExponent = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(a64, 1 + 32), F32_MANTISSA_BITS + 1 + 32);
                    isZero = Avx2.mm256_cvtepi32_epi64(cmpgt_epu32(slli_epi32(set1_ps(trunc ? 1f : 0.5f), 1), slli_epi32(a, 1)));
                }
                
                v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a64, MANTISSA_MASK, TernaryOperation.OxF8);
                v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                v256 result = Avx2.mm256_sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v256 ifRound = mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(EXP, biasedExponent));
                    v256 round = Avx2.mm256_sllv_epi64(ifRound, mm256_dec_epi64(shift_mnt));
                    if (evenOnTie)
                    {
                        round = Avx2.mm256_sub_epi64(round, Avx2.mm256_andnot_si256(Avx2.mm256_srlv_epi64(mantissa, shift_mnt), ifRound));
                    }

                    result = Avx2.mm256_add_epi64(result, round);
                }
                
                result = Avx2.mm256_andnot_si256(isZero, result);
                result = Avx2.mm256_srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_GE_PS(a, 0f, elements))
                    {
                        v128 signMask = cmpgt_ps(setzero_si128(), a);
                        v256 signMask256 = Avx2.mm256_cvtepi32_epi64(signMask);

                        result = Avx2.mm256_xor_si256(result, signMask256);
                        result = Avx2.mm256_sub_epi64(result, signMask256);
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 BASE_cvtpd_epi64(v128 a, bool signed, bool trunc, bool evenOnTie = true, bool nonZero = false, bool positive = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (!trunc)
                {
                    if (signed)
                    {
                        if (constexpr.ALL_GE_PD(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT + 1d) && constexpr.ALL_LE_PD(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT - 1d))
                        {
                            return usfcvtpd_epi64(a);
                        }
                    }
                    else
                    {
                        if (constexpr.ALL_GE_PD(a, 0d) && constexpr.ALL_LE_PD(a, USF_CVT_EPU64_PD_LIMIT - 1d))
                        {
                            return usfcvtpd_epu64(a);
                        }
                    }
                }
                if (Avx2.IsAvx2Supported)
                {
                    ;
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (signed)
                    {
                        if (trunc)
                        {
                            return unpacklo_epi64(cvtsi64x_si128(cvttsd_si64x(a)), cvtsi64x_si128(cvttsd_si64x(bsrli_si128(a, sizeof(double)))));
                        }
                        else
                        {
                            return unpacklo_epi64(cvtsi64x_si128(cvtsd_si64x(a)), cvtsi64x_si128(cvtsd_si64x(bsrli_si128(a, sizeof(double)))));
                        }
                    }
                }

                nonZero |= constexpr.ALL_NEQ_PD(a, 0, 2);
                positive |= constexpr.ALL_GT_PD(a, 0, 2);

                v128 IMPLICIT_ONE = set1_epi64x(1L << F64_MANTISSA_BITS);
                v128 MANTISSA_MASK = set1_epi64x(maxmath.bitmask64((long)F64_MANTISSA_BITS));
                v128 EXP = set1_epi64x(math.abs(F64_EXPONENT_BIAS) + F64_MANTISSA_BITS);

                v128 biasedExponent;
                v128 isZero;
                if (positive || (!signed && nonZero) || (!signed && !COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO) | constexpr.ALL_LT_EPU64(a, 1ul << 63) || constexpr.ALL_GT_PD(a, 0d))
                {
                    biasedExponent = srli_epi64(a, F64_MANTISSA_BITS);
                    isZero = cmpgt_epi64(set1_pd(trunc ? 1d : 0.5d), a);
                }
                else
                {
                    biasedExponent = srli_epi64(slli_epi64(a, 1), F64_MANTISSA_BITS + 1);
                    isZero = cmpgt_epu64(slli_epi64(set1_pd(trunc ? 1d : 0.5d), 1), slli_epi64(a, 1));
                }
                
                v128 mantissa = ternarylogic_si128(IMPLICIT_ONE, a, MANTISSA_MASK, TernaryOperation.OxF8);
                v128 shift_mnt = subs_epu16(EXP, biasedExponent);
                v128 shift_int = subs_epu16(biasedExponent, EXP);

                v128 result = sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v128 ifRound = neg_epi16(cmpgt_epi16(EXP, biasedExponent));
                    v128 round = sllv_epi64(ifRound, dec_epi64(shift_mnt));

                    if (evenOnTie)
                    {
                        round = sub_epi64(round, andnot_si128(srlv_epi64(mantissa, shift_mnt), ifRound));
                    }

                    result = add_epi64(result, round);
                }
                
                result = andnot_si128(isZero, result);
                result = srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_GE_PD(a, 0d))
                    {
                        v128 signMask = cmpgt_pd(setzero_si128(), a);

                        result = xor_si128(result, signMask);
                        result = sub_epi64(result, signMask);
                    }
                }

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                if (signed)
                {
                    if (trunc)
                    {
                        return Arm.Neon.vcvtq_s64_f64(a);
                    }
                    else
                    {
                        return Arm.Neon.vcvtnq_s64_f64(a);
                    }
                }
                else
                {
                    if (trunc)
                    {
                        return Arm.Neon.vcvtq_u64_f64(a);
                    }
                    else
                    {
                        return Arm.Neon.vcvtnq_u64_f64(a);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 BASE_mm256_cvtpd_epi64(v256 a, bool signed, bool trunc, bool evenOnTie = true, byte elements = 4, bool nonZero = false, bool positive = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (!trunc)
                {
                    if (signed)
                    {
                        if (constexpr.ALL_GE_PD(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT + 1d, elements) && constexpr.ALL_LE_PD(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT - 1d, elements))
                        {
                            return mm256_usfcvtpd_epi64(a);
                        }
                    }
                    else
                    {
                        if (constexpr.ALL_GE_PD(a, 0d, elements) && constexpr.ALL_LE_PD(a, USF_CVT_EPU64_PD_LIMIT - 1d, elements))
                        {
                            return mm256_usfcvtpd_epu64(a);
                        }
                    }
                }

                nonZero |= constexpr.ALL_NEQ_PD(a, 0, elements);
                positive |= constexpr.ALL_GT_PD(a, 0, elements);

                v256 IMPLICIT_ONE = mm256_set1_epi64x(1L << F64_MANTISSA_BITS);
                v256 MANTISSA_MASK = mm256_set1_epi64x(maxmath.bitmask64((long)F64_MANTISSA_BITS));
                v256 EXP = mm256_set1_epi64x(math.abs(F64_EXPONENT_BIAS) + F64_MANTISSA_BITS);

                v256 biasedExponent;
                v256 isZero;
                if (positive || (!signed && nonZero) || (!signed && !COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO) | constexpr.ALL_LT_EPU64(a, 1ul << 63, elements) || constexpr.ALL_GT_PD(a, 0d, elements))
                {
                    biasedExponent = Avx2.mm256_srli_epi64(a, F64_MANTISSA_BITS);
                    isZero = mm256_cmpgt_epi64(mm256_set1_pd(trunc ? 1d : 0.5d), a);
                }
                else
                {
                    biasedExponent = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(a, 1), F64_MANTISSA_BITS + 1);
                    isZero = mm256_cmpgt_epu64(mm256_slli_epi64(mm256_set1_pd(trunc ? 1d : 0.5d), 1), mm256_slli_epi64(a, 1));
                }
                
                v256 mantissa = mm256_ternarylogic_si256(IMPLICIT_ONE, a, MANTISSA_MASK, TernaryOperation.OxF8);
                v256 shift_mnt = Avx2.mm256_subs_epu16(EXP, biasedExponent);
                v256 shift_int = Avx2.mm256_subs_epu16(biasedExponent, EXP);

                v256 result = Avx2.mm256_sllv_epi64(mantissa, shift_int);

                if (!trunc)
                {
                    v256 ifRound = mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(EXP, biasedExponent));
                    v256 round = Avx2.mm256_sllv_epi64(ifRound, mm256_dec_epi64(shift_mnt));
                    if (evenOnTie)
                    {
                        round = Avx2.mm256_sub_epi64(round, Avx2.mm256_andnot_si256(Avx2.mm256_srlv_epi64(mantissa, shift_mnt), ifRound));
                    }

                    result = Avx2.mm256_add_epi64(result, round);
                }
                
                result = Avx2.mm256_andnot_si256(isZero, result);
                result = Avx2.mm256_srlv_epi64(result, shift_mnt);

                if (signed)
                {
                    if (!constexpr.ALL_GE_PD(a, 0d, elements))
                    {
                        v256 signMask = mm256_cmpgt_pd(Avx.mm256_setzero_si256(), a);

                        result = Avx2.mm256_xor_si256(result, signMask);
                        result = Avx2.mm256_sub_epi64(result, signMask);
                    }
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvtpd_epu64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(LIMIT_PRECISE_U64_F64);

                return xor_pd(add_pd(a, MASK), MASK);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return cvtpd_epu64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvtpd_epu64(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                v256 MASK = new v256(LIMIT_PRECISE_U64_F64);

                return Avx.mm256_xor_pd(Avx.mm256_add_pd(a, MASK), MASK);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvtpd_epi64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(0x4338_0000_0000_0000);

                return sub_epi64(add_pd(a, MASK), MASK);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return cvtpd_epi64(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvtpd_epi64(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MASK = new v256(0x4338_0000_0000_0000);

                return Avx2.mm256_sub_epi64(Avx.mm256_add_pd(a, MASK), MASK);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvtepu64_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(LIMIT_PRECISE_U64_F64);

                return sub_pd(or_si128(a, MASK), MASK);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return cvtepu64_pd(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvtepu64_pd(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                v256 MASK = new v256(LIMIT_PRECISE_U64_F64);

                return Avx.mm256_sub_pd(Avx.mm256_or_pd(a, MASK), MASK);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvtepi64_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(0x4338_0000_0000_0000);

                return sub_pd(add_epi64(a, MASK), MASK);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return cvtepi64_pd(a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvtepi64_pd(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MASK = new v256(0x4338_0000_0000_0000);

                return Avx.mm256_sub_pd(Avx2.mm256_add_epi64(a, MASK), MASK);
            }
            else throw new IllegalInstructionException();
        }
    }
}