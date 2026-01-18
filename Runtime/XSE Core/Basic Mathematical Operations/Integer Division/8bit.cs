using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu8(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constdiv_epu8(dividend, divisor, elements);
                }

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU8(divisor, 16, elements))
                    {
                        if (elements <= 8)
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16, elements);

                            return Divider<byte>.bmdiv_epu8(dividend, divisor, mul16, Promise.Nothing, elements);
                        }
                        else
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16Lo, out v128 mul16Hi);

                            return Divider<byte>.bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing);
                        }
                    }
                }

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return DivRemBitwise(dividend, divisor, out _, elements);
                }

                if (elements > 8)
                {
                    v128 dividendlo16 = cvt2x2epu8_epi16(dividend, out v128 dividendhi16);
                    v128 dividend0 = cvt2x2epu16_ps(dividendlo16, out v128 dividend1);
                    v128 dividend2 = cvt2x2epu16_ps(dividendhi16, out v128 dividend3);
                    v128 divisorlo16 = cvt2x2epu8_epi16(divisor, out v128 divisorhi16);
                    v128 divisor0 = cvt2x2epu16_ps(divisorlo16, out v128 divisor1);
                    v128 divisor2 = cvt2x2epu16_ps(divisorhi16, out v128 divisor3);

                    v128 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0);
                    v128 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1);
                    v128 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2);
                    v128 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3);

                    return packus_epi16(packs_epi32(q0, q1), packs_epi32(q2, q3));
                }
                else if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epu16_ps(cvtepu8_epi16(dividend), out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(cvtepu8_epi16(divisor),  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftHi, rightHi);

                    if (Sse2.IsSse2Supported)
                    {
                        v128 shorts = packs_epi32(intsLo, intsHi);

                        return packus_epi16(shorts, shorts);
                    }
                    else
                    {
                        return unpacklo_epi32(cvtepi32_epi8(intsLo), cvtepi32_epi8(intsHi));
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepu8_ps(dividend), cvtepu8_ps(divisor));

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        return cvtepi32_epi8(ints, elements);
                    }
                    else
                    {
                        v128 shorts = packs_epi32(ints, ints);
                        return packus_epi16(shorts, shorts);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi8(v128 dividend, v128 divisor, bool saturated = false, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor) && !saturated)
                {
                    return constdiv_epi8(dividend, divisor, elements);
                }

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    v128 quotients = DivRemBitwiseSigned(dividend, divisor, out _, elements);
                    if (saturated)
                    {
                        v128 MIN_VALUE = set1_epi8(sbyte.MinValue);

                        v128 overflow = and_si128(cmpeq_epi8(dividend, MIN_VALUE), cmpeq_epi8(divisor, setall_si128()));

                        return add_epi8(quotients, overflow);
                    }
                    else
                    {
                        return quotients;
                    }
                }

                if (elements > 8)
                {
                    v128 dividend0, dividend1, dividend2, dividend3;
                    v128 divisor0, divisor1, divisor2, divisor3;
                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        cvt4x4epi8_epi32(dividend, out dividend0, out dividend1, out dividend2, out dividend3);
                        cvt4x4epi8_epi32(divisor, out divisor0, out divisor1, out divisor2, out divisor3);

                        dividend0 = cvtepi32_ps(dividend0);
                        dividend1 = cvtepi32_ps(dividend1);
                        dividend2 = cvtepi32_ps(dividend2);
                        dividend3 = cvtepi32_ps(dividend3);
                        divisor0 = cvtepi32_ps(divisor0);
                        divisor1 = cvtepi32_ps(divisor1);
                        divisor2 = cvtepi32_ps(divisor2);
                        divisor3 = cvtepi32_ps(divisor3);
                    }
                    else
                    {
                        v128 dividendlo16 = cvt2x2epi8_epi16(dividend, out v128 dividendhi16);
                        dividend0 = cvt2x2epi16_ps(dividendlo16, out dividend1);
                        dividend2 = cvt2x2epi16_ps(dividendhi16, out dividend3);
                        v128 divisorlo16 = cvt2x2epi8_epi16(divisor, out v128 divisorhi16);
                        divisor0 = cvt2x2epi16_ps(divisorlo16, out divisor1);
                        divisor2 = cvt2x2epi16_ps(divisorhi16, out divisor3);
                    }

                    v128 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0);
                    v128 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1);
                    v128 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2);
                    v128 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3);

                    if (saturated
                     || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue, elements)
                     || constexpr.ALL_NEQ_EPI8(dividend, -1, elements))
                    {
                        return packs_epi16(packs_epi32(q0, q1), packs_epi32(q2, q3));
                    }
                    else
                    {
                        return cvt2x2epi16_epi8(packs_epi32(q0, q1), packs_epi32(q2, q3));
                    }
                }
                else if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epi16_ps(cvtepi8_epi16(dividend), out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(cvtepi8_epi16(divisor),  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftHi, rightHi);

                    v128 shorts = packs_epi32(intsLo, intsHi);

                    if (saturated
                     || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue, elements)
                     || constexpr.ALL_NEQ_EPI8(dividend, -1, elements))
                    {
                        return packs_epi16(shorts, shorts);
                    }
                    else
                    {
                        if (Sse2.IsSse2Supported)
                        {
                            return cvt2x2epi16_epi8(shorts, shorts);
                        }
                        else
                        {
                            return unpacklo_epi32(cvtepi32_epi8(intsLo), cvtepi32_epi8(intsHi));
                        }
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepi8_ps(dividend), cvtepi8_ps(divisor));

                    if (saturated)
                    {
                        v128 shorts = packs_epi32(ints, ints);
                        return packs_epi16(shorts, shorts);
                    }
                    else
                    {
                        return cvtepi32_epi8(ints, elements);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu8(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constdiv_epu8(dividend, divisor);
                }

                if (constexpr.ALL_LE_EPU8(divisor, 16))
                {
                    Divider<byte>.mm256_bminitLE16_epu8(divisor, out v256 mul16Lo, out v256 mul16Hi);

                    return Divider<byte>.mm256_bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing);
                }

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return DivRemBitwise(dividend, divisor, out _);
                }

                v256 dividendlo16 = mm256_cvt2x2epu8_epi16(dividend, out v256 dividendhi16);
                v256 dividend0 = mm256_cvt2x2epu16_ps(dividendlo16, out v256 dividend1);
                v256 dividend2 = mm256_cvt2x2epu16_ps(dividendhi16, out v256 dividend3);
                v256 divisorlo16 = mm256_cvt2x2epu8_epi16(divisor, out v256 divisorhi16);
                v256 divisor0 = mm256_cvt2x2epu16_ps(divisorlo16, out v256 divisor1);
                v256 divisor2 = mm256_cvt2x2epu16_ps(divisorhi16, out v256 divisor3);

                v256 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0);
                v256 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1);
                v256 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2);
                v256 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3);

                return Avx2.mm256_packus_epi16(Avx2.mm256_packs_epi32(q0, q1), Avx2.mm256_packs_epi32(q2, q3));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi8(v256 dividend, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor) && !saturated)
                {
                    return mm256_constdiv_epi8(dividend, divisor);
                }

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return DivRemBitwiseSigned(dividend, divisor, out _);
                }
                else
                {
                    mm256_cvt4x4epi8_epi32(dividend, out v256 dividend0, out v256 dividend1, out v256 dividend2, out v256 dividend3);
                    mm256_cvt4x4epi8_epi32(divisor, out v256 divisor0, out v256 divisor1, out v256 divisor2, out v256 divisor3);

                    v256 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(dividend0), Avx.mm256_cvtepi32_ps(divisor0));
                    v256 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(dividend1), Avx.mm256_cvtepi32_ps(divisor1));
                    v256 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(dividend2), Avx.mm256_cvtepi32_ps(divisor2));
                    v256 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(dividend3), Avx.mm256_cvtepi32_ps(divisor3));

                    if (saturated
                     || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue)
                     || constexpr.ALL_NEQ_EPI8(dividend, -1))
                    {
                        return Avx2.mm256_packs_epi16(Avx2.mm256_packs_epi32(q0, q1), Avx2.mm256_packs_epi32(q2, q3));
                    }
                    else
                    {
                        return mm256_cvt2x2epi16_epi8(Avx2.mm256_packs_epi32(q0, q1), Avx2.mm256_packs_epi32(q2, q3));
                    }
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu8(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (constexpr.IS_CONST(divisor))
                {
                    result = constrem_epu8(dividend, divisor, elements);
                }
                else if (elements > 4
                      && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    DivRemBitwise(dividend, divisor, out result, elements);
                }
                else
                {
                    result = sub_epi8(dividend, divmullo_epu8(dividend, divisor, divisor, out _, noOverflow: true, elements: elements));
                }

                constexpr.ASSUME_LT_EPU8(result, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi8(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constrem_epi8(dividend, divisor, elements);
                }


                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    DivRemBitwiseSigned(dividend, divisor, out v128 result, elements);

                    return result;
                }
                else
                {
                    return sub_epi8(dividend, divmullo_epi8(dividend, divisor, divisor, out _, noOverflow: false, elements: elements));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu8(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;
                if (constexpr.IS_CONST(divisor))
                {
                    result = mm256_constrem_epu8(dividend, divisor);
                }
                else if (constexpr.ALL_LE_EPU8(divisor, 16))
                {
                    Divider<byte>.mm256_bminitLE16_epu8(divisor, out v256 mul16Lo, out v256 mul16Hi);

                    result = Divider<byte>.mm256_bmrem_epu8(dividend, divisor, mul16Lo, mul16Hi);
                }
                else if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    DivRemBitwise(dividend, divisor, out result);
                }
                else
                {
                    result = Avx2.mm256_sub_epi8(dividend, mm256_divmullo_epu8(dividend, divisor, divisor, out _, noOverflow: true));
                }

                constexpr.ASSUME_LT_EPU8(result, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi8(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constrem_epi8(dividend, divisor);
                }

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    DivRemBitwiseSigned(dividend, divisor, out v256 rem);

                    return rem;
                }

                return Avx2.mm256_sub_epi8(dividend, mm256_divmullo_epi8(dividend, divisor, divisor, out _, noOverflow: false));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu8(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient;
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epu8(dividend, divisor, elements);
                    quotient = constdiv_epu8(dividend, divisor, elements);
                }
                else if (elements > 4
                      && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotient = DivRemBitwise(dividend, divisor, out remainder, elements);
                }
                else
                {
                    remainder = sub_epi8(dividend, divmullo_epu8(dividend, divisor, divisor, out quotient, noOverflow: true, elements: elements));
                }

                constexpr.ASSUME_LT_EPU8(remainder, divisor, elements);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi8(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epi8(dividend, divisor, elements);
                    return constdiv_epi8(dividend, divisor, elements);
                }
                else if (elements > 4
                      && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return DivRemBitwiseSigned(dividend, divisor, out remainder, elements);
                }
                else
                {
                    remainder = sub_epi8(dividend, divmullo_epi8(dividend, divisor, divisor, out v128 quotient, noOverflow: false, saturated: false, elements: elements));
                    return quotient;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu8(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient;
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epu8(dividend, divisor);
                    quotient = mm256_constdiv_epu8(dividend, divisor);
                }
                else if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotient = DivRemBitwise(dividend, divisor, out remainder);
                }
                else
                {
                    remainder = Avx2.mm256_sub_epi8(dividend, mm256_divmullo_epu8(dividend, divisor, divisor, out quotient, noOverflow: true));
                }

                constexpr.ASSUME_LT_EPU8(remainder, divisor);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi8(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epi8(dividend, divisor);
                    return mm256_constdiv_epi8(dividend, divisor);
                }
                else if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return DivRemBitwiseSigned(dividend, divisor, out remainder);
                }
                else
                {
                    remainder = Avx2.mm256_sub_epi8(dividend, mm256_divmullo_epi8(dividend, divisor, divisor, out v256 quotient, noOverflow: false, saturated: false));
                    return quotient;
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divadd_epu8(v128 dividend, v128 divisor, v128 summand, bool noOverflow = false, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return add_epi8(summand, constdiv_epu8(dividend, divisor, elements));
                }

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU8(divisor, 16, elements))
                    {
                        if (elements <= 8)
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16, elements);

                            return add_epi8(summand, Divider<byte>.bmdiv_epu8(dividend, divisor, mul16, Promise.Nothing, elements));
                        }
                        else
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16Lo, out v128 mul16Hi);

                            return add_epi8(summand, Divider<byte>.bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing));
                        }
                    }
                }

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return add_epi8(summand, DivRemBitwise(dividend, divisor, out _, elements));
                }
                if (Arm.Neon.IsNeonSupported)
                {
                    return add_epi8(summand, div_epu8(dividend, divisor, elements));
                }

                if (elements > 8)
                {
                    v128 dividendlo16 = cvt2x2epu8_epi16(dividend, out v128 dividendhi16);
                    v128 dividend0 = cvt2x2epu16_ps(dividendlo16, out v128 dividend1);
                    v128 dividend2 = cvt2x2epu16_ps(dividendhi16, out v128 dividend3);
                    v128 divisorlo16 = cvt2x2epu8_epi16(divisor, out v128 divisorhi16);
                    v128 divisor0 = cvt2x2epu16_ps(divisorlo16, out v128 divisor1);
                    v128 divisor2 = cvt2x2epu16_ps(divisorhi16, out v128 divisor3);
                    v128 summandlo16 = cvt2x2epu8_epi16(summand, out v128 summandhi16);
                    v128 summand0 = cvt2x2epu16_ps(summandlo16, out v128 summand1);
                    v128 summand2 = cvt2x2epu16_ps(summandhi16, out v128 summand3);

                    v128 q0 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0, summand0);
                    v128 q1 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1, summand1);
                    v128 q2 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2, summand2);
                    v128 q3 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3, summand3);

                    v128 result16Lo = packs_epi32(q0, q1);
                    v128 result16Hi = packs_epi32(q2, q3);

                    if (noOverflow)
                    {
                        return packus_epi16(result16Lo, result16Hi);
                    }
                    else
                    {
                        return cvt2x2epi16_epi8(result16Lo, result16Hi);
                    }
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepu8_epi16(dividend);
                    v128 castDivisor = cvtepu8_epi16(divisor);
                    v128 leftLo  = cvt2x2epu16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(castDivisor,  out v128 rightHi);
                    v128 summandLo = cvt2x2epu16_ps(cvtepu8_epi16(summand), out v128 summandHi);
                    v128 resultLo = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(leftLo, rightLo, summandLo);
                    v128 resultHi = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(leftHi, rightHi, summandHi);

                    v128 result16 = packs_epi32(resultLo, resultHi);

                    if (noOverflow)
                    {
                        return packus_epi16(result16, result16);
                    }
                    else
                    {
                        return cvtepi16_epi8(result16);
                    }
                }
                else
                {
                    v128 castDividend = cvtepu8_epi32(dividend);
                    v128 castDivisor = cvtepu8_epi32(divisor);
                    v128 castSummand = cvtepu8_epi32(summand);
                    v128 result32 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(cvtepi32_ps(castDividend), cvtepi32_ps(castDivisor), cvtepi32_ps(castSummand));

                    return cvtepi32_epi8(result32, elements);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divadd_epu8(v256 dividend, v256 divisor, v256 summand, bool noOverflow = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return Avx2.mm256_add_epi8(summand, mm256_constdiv_epu8(dividend, divisor));
                }

                if (constexpr.ALL_LE_EPU8(divisor, 16))
                {
                    Divider<byte>.mm256_bminitLE16_epu8(divisor, out v256 mul16Lo, out v256 mul16Hi);

                    return Avx2.mm256_add_epi8(summand, Divider<byte>.mm256_bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing));
                }

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return Avx2.mm256_add_epi8(summand, DivRemBitwise(dividend, divisor, out _));
                }

                mm256_cvt4x4epu8_ps(dividend, out v256 dividend0, out v256 dividend1, out v256 dividend2, out v256 dividend3);
                mm256_cvt4x4epu8_ps(divisor, out v256 divisor0, out v256 divisor1, out v256 divisor2, out v256 divisor3);
                mm256_cvt4x4epu8_ps(summand, out v256 summand0, out v256 summand1, out v256 summand2, out v256 summand3);

                v256 q0 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0, summand0);
                v256 q1 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1, summand1);
                v256 q2 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2, summand2);
                v256 q3 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3, summand3);

                v256 result16Lo = Avx2.mm256_packs_epi32(q0, q1);
                v256 result16Hi = Avx2.mm256_packs_epi32(q2, q3);

                if (noOverflow)
                {
                    return Avx2.mm256_packus_epi16(result16Lo, result16Hi);
                }
                else
                {
                    return mm256_cvt2x2epi16_epi8(result16Lo, result16Hi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divmullo_epu8(v128 dividend, v128 divisor, v128 factor, out v128 quotient, bool noOverflow = false, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mullo_epi8(factor, quotient = constdiv_epu8(dividend, divisor, elements));
                }

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU8(divisor, 16, elements))
                    {
                        if (elements <= 8)
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16, elements);

                            return mullo_epi8(factor, quotient = Divider<byte>.bmdiv_epu8(dividend, divisor, mul16, Promise.Nothing, elements));
                        }
                        else
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16Lo, out v128 mul16Hi);

                            return mullo_epi8(factor, quotient = Divider<byte>.bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing));
                        }
                    }
                }

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return mullo_epi8(factor, quotient = DivRemBitwise(dividend, divisor, out _, elements));
                }
                if (Arm.Neon.IsNeonSupported)
                {
                    return mullo_epi8(factor, quotient = div_epu8(dividend, divisor, elements));
                }

                if (elements > 8)
                {
                    v128 dividendlo16 = cvt2x2epu8_epi16(dividend, out v128 dividendhi16);
                    v128 dividend0 = cvt2x2epu16_ps(dividendlo16, out v128 dividend1);
                    v128 dividend2 = cvt2x2epu16_ps(dividendhi16, out v128 dividend3);
                    v128 divisorlo16 = cvt2x2epu8_epi16(divisor, out v128 divisorhi16);
                    v128 divisor0 = cvt2x2epu16_ps(divisorlo16, out v128 divisor1);
                    v128 divisor2 = cvt2x2epu16_ps(divisorhi16, out v128 divisor3);

                    v128 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0);
                    v128 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1);
                    v128 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2);
                    v128 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3);

                    v128 quotients16Lo = packs_epi32(q0, q1);
                    v128 quotients16Hi = packs_epi32(q2, q3);
                    v128 factorlo16 = cvt2x2epu8_epi16(factor, out v128 factorhi16);
                    v128 mul16Lo = mullo_epi16(factorlo16, quotients16Lo);
                    v128 mul16Hi = mullo_epi16(factorhi16, quotients16Hi);

                    if (noOverflow)
                    {
                        quotient = packus_epi16(quotients16Lo, quotients16Hi);
                        return packus_epi16(mul16Lo, mul16Hi);
                    }
                    else
                    {
                        quotient = cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                        return cvt2x2epi16_epi8(mul16Lo, mul16Hi);
                    }
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepu8_epi16(dividend);
                    v128 castDivisor = cvtepu8_epi16(divisor);
                    v128 leftLo  = cvt2x2epu16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(castDivisor,  out v128 rightHi);
                    v128 quotientsLo = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftLo, rightLo);
                    v128 quotientsHi = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftHi, rightHi);

                    v128 quotients16 = packs_epi32(quotientsLo, quotientsHi);
                    factor = mullo_epi16(cvtepu8_epi16(factor), quotients16);

                    if (noOverflow)
                    {
                        quotient = packus_epi16(quotients16, quotients16);
                        return packus_epi16(factor, factor);
                    }
                    else
                    {
                        quotient = cvtepi16_epi8(quotients16);
                        return cvtepi16_epi8(factor);
                    }
                }
                else
                {
                    if (BurstArchitecture.IsMul32Supported)
                    {
                        v128 castDividend = cvtepu8_epi32(dividend);
                        v128 castDivisor = cvtepu8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepi32_ps(castDividend), cvtepi32_ps(castDivisor));

                        quotient = cvtepi32_epi8(quotients32, elements);
                        return cvtepi32_epi8(mullo_epi32(cvtepu8_epi32(factor), quotients32), elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepu8_epi16(dividend);
                        v128 castDivisor = cvtepu8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepu16_ps(castDividend), cvtepu16_ps(castDivisor));
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        factor = mullo_epi16(cvtepu8_epi16(factor), quotients16);

                        if (noOverflow)
                        {
                            quotient = packus_epi16(quotients16, quotients16);
                            return packus_epi16(factor, factor);
                        }
                        else
                        {
                            quotient = cvtepi16_epi8(quotients16);
                            return cvtepi16_epi8(factor);
                        }
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divmullo_epi8(v128 dividend, v128 divisor, v128 factor, out v128 quotient, bool noOverflow = false, bool saturated = false, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mullo_epi8(factor, quotient = constdiv_epi8(dividend, divisor, elements));
                }

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return mullo_epi8(factor, quotient = DivRemBitwiseSigned(dividend, divisor, out _, elements));
                }
                if (Arm.Neon.IsNeonSupported)
                {
                    return mullo_epi8(factor, quotient = div_epi8(dividend, divisor, elements : elements));
                }

                if (elements > 8)
                {
                    v128 dividendlo16 = cvt2x2epi8_epi16(dividend, out v128 dividendhi16);
                    v128 dividend0 = cvt2x2epi16_ps(dividendlo16, out v128 dividend1);
                    v128 dividend2 = cvt2x2epi16_ps(dividendhi16, out v128 dividend3);
                    v128 divisorlo16 = cvt2x2epi8_epi16(divisor, out v128 divisorhi16);
                    v128 divisor0 = cvt2x2epi16_ps(divisorlo16, out v128 divisor1);
                    v128 divisor2 = cvt2x2epi16_ps(divisorhi16, out v128 divisor3);

                    v128 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0);
                    v128 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1);
                    v128 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2);
                    v128 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3);

                    v128 quotients16Lo = packs_epi32(q0, q1);
                    v128 quotients16Hi = packs_epi32(q2, q3);
                    v128 factorlo16 = cvt2x2epi8_epi16(factor, out v128 factorhi16);
                    v128 mul16Lo = mullo_epi16(factorlo16, quotients16Lo);
                    v128 mul16Hi = mullo_epi16(factorhi16, quotients16Hi);

                    if (noOverflow
                     || (saturated
                      || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue, elements)
                      || constexpr.ALL_NEQ_EPI8(dividend, -1, elements)))
                    {
                        quotient = packs_epi16(quotients16Lo, quotients16Hi);
                        return packs_epi16(mul16Lo, mul16Hi);
                    }
                    else
                    {
                        quotient = cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                        return cvt2x2epi16_epi8(mul16Lo, mul16Hi);
                    }
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepi8_epi16(dividend);
                    v128 castDivisor = cvtepi8_epi16(divisor);
                    v128 leftLo  = cvt2x2epi16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(castDivisor,  out v128 rightHi);
                    v128 quotientsLo = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftLo, rightLo);
                    v128 quotientsHi = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(leftHi, rightHi);

                    v128 quotients16 = packs_epi32(quotientsLo, quotientsHi);
                    factor = mullo_epi16(cvtepi8_epi16(factor), quotients16);

                    if (noOverflow
                     || (saturated
                      || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue, elements)
                      || constexpr.ALL_NEQ_EPI8(dividend, -1, elements)))
                    {
                        quotient = packs_epi16(quotients16, quotients16);
                        return packs_epi16(factor, factor);
                    }
                    else
                    {
                        quotient = cvtepi16_epi8(quotients16);
                        return cvtepi16_epi8(factor);
                    }
                }
                else
                {
                    v128 castDividend = cvtepi8_ps(dividend);
                    v128 castDivisor = cvtepi8_ps(divisor);
                    v128 quotients32 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(castDividend, castDivisor);

                    if (BurstArchitecture.IsMul32Supported)
                    {
                        quotient = cvtepi32_epi8(quotients32, elements);
                        return cvtepi32_epi8(mullo_epi32(cvtepi8_epi32(factor), quotients32), elements);
                    }
                    else
                    {
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        factor = mullo_epi16(cvtepi8_epi16(factor), quotients16);

                        if (noOverflow
                         || (saturated
                          || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue, elements)
                          || constexpr.ALL_NEQ_EPI8(dividend, -1, elements)))
                        {
                            quotient = packs_epi16(quotients16, quotients16);
                            return packs_epi16(factor, factor);
                        }
                        else
                        {
                            quotient = cvtepi16_epi8(quotients16);
                            return cvtepi16_epi8(factor);
                        }
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divmullo_epu8(v256 dividend, v256 divisor, v256 factor, out v256 quotient, bool noOverflow = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_mullo_epi8(factor, quotient = mm256_constdiv_epu8(dividend, divisor));
                }

                if (constexpr.ALL_LE_EPU8(divisor, 16))
                {
                    Divider<byte>.mm256_bminitLE16_epu8(divisor, out v256 mul16Lo, out v256 mul16Hi);

                    return mm256_mullo_epi8(factor, quotient = Divider<byte>.mm256_bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing));
                }

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return mm256_mullo_epi8(factor, quotient = DivRemBitwise(dividend, divisor, out _));
                }

                mm256_cvt4x4epu8_ps(dividend, out v256 dividend0, out v256 dividend1, out v256 dividend2, out v256 dividend3);
                mm256_cvt4x4epu8_ps(divisor, out v256 divisor0, out v256 divisor1, out v256 divisor2, out v256 divisor3);

                v256 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0);
                v256 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1);
                v256 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2);
                v256 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3);

                v256 quotients16Lo = Avx2.mm256_packs_epi32(q0, q1);
                v256 quotients16Hi = Avx2.mm256_packs_epi32(q2, q3);
                v256 factorlo16 = mm256_cvt2x2epu8_epi16(factor, out v256 factorhi16);
                v256 fac16Lo = Avx2.mm256_mullo_epi16(factorlo16, quotients16Lo);
                v256 fac16Hi = Avx2.mm256_mullo_epi16(factorhi16, quotients16Hi);

                if (noOverflow)
                {
                    quotient = Avx2.mm256_packus_epi16(quotients16Lo, quotients16Hi);
                    return Avx2.mm256_packus_epi16(fac16Lo, fac16Hi);
                }
                else
                {
                    quotient = mm256_cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                    return mm256_cvt2x2epi16_epi8(fac16Lo, fac16Hi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divmullo_epi8(v256 dividend, v256 divisor, v256 factor, out v256 quotient, bool noOverflow = false, bool saturated = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_mullo_epi8(factor, quotient = mm256_constdiv_epi8(dividend, divisor));
                }

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return mm256_mullo_epi8(factor, quotient = DivRemBitwiseSigned(dividend, divisor, out _));
                }

                mm256_cvt4x4epi8_ps(dividend, out v256 dividend0, out v256 dividend1, out v256 dividend2, out v256 dividend3);
                mm256_cvt4x4epi8_ps(divisor, out v256 divisor0, out v256 divisor1, out v256 divisor2, out v256 divisor3);

                v256 q0 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend0, divisor0);
                v256 q1 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend1, divisor1);
                v256 q2 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend2, divisor2);
                v256 q3 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(dividend3, divisor3);

                v256 quotients16Lo = Avx2.mm256_packs_epi32(q0, q1);
                v256 quotients16Hi = Avx2.mm256_packs_epi32(q2, q3);
                v256 factorlo16 = mm256_cvt2x2epi8_epi16(factor, out v256 factorhi16);
                v256 fac16Lo = Avx2.mm256_mullo_epi16(factorlo16, quotients16Lo);
                v256 fac16Hi = Avx2.mm256_mullo_epi16(factorhi16, quotients16Hi);

                if (noOverflow
                 || (saturated
                  || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue)
                  || constexpr.ALL_NEQ_EPI8(dividend, -1)))
                {
                    quotient = Avx2.mm256_packs_epi16(quotients16Lo, quotients16Hi);
                    return Avx2.mm256_packs_epi16(fac16Lo, fac16Hi);
                }
                else
                {
                    quotient = mm256_cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                    return mm256_cvt2x2epi16_epi8(fac16Lo, fac16Hi);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(v128 dividend_f32, v128 divisor_f32)
        {
            if (Sse2.IsSse2Supported)
            {
                divisor_f32 = rcp_ps(divisor_f32);
                if (constexpr.IS_CONST(divisor_f32))
                {
                    divisor_f32 = mul_ps(set1_epi32(RCP32_PRECISION_LOSS_U8), divisor_f32);
                }
                else
                {
                    dividend_f32 = mul_ps(set1_epi32(RCP32_PRECISION_LOSS_U8), dividend_f32);
                }
                return cvttps_epi32(mul_ps(dividend_f32, divisor_f32));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return cvttps_epi32(div_ps(dividend_f32, divisor_f32));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(v256 dividend_f32, v256 divisor_f32)
        {
            if (Avx.IsAvxSupported)
            {
                divisor_f32 = Avx.mm256_rcp_ps(divisor_f32);
                if (constexpr.IS_CONST(divisor_f32))
                {
                    divisor_f32 = Avx.mm256_mul_ps(mm256_set1_epi32(RCP32_PRECISION_LOSS_U8), divisor_f32);
                }
                else
                {
                    dividend_f32 = Avx.mm256_mul_ps(mm256_set1_epi32(RCP32_PRECISION_LOSS_U8), dividend_f32);
                }
                return Avx.mm256_cvttps_epi32(Avx.mm256_mul_ps(dividend_f32, divisor_f32));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(v128 dividend_f32, v128 divisor_f32, v128 summand_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                divisor_f32 = rcp_ps(divisor_f32);
                if (constexpr.IS_CONST(divisor_f32))
                {
                    divisor_f32 = mul_ps(set1_epi32(RCP32_PRECISION_LOSS_U8), divisor_f32);
                }
                else
                {
                    dividend_f32 = mul_ps(set1_epi32(RCP32_PRECISION_LOSS_U8), dividend_f32);
                }
                return cvttps_epi32(fmadd_ps(dividend_f32, divisor_f32, summand_f32));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(v256 dividend_f32, v256 divisor_f32, v256 summand_f32)
        {
            if (Avx2.IsAvx2Supported)
            {
                divisor_f32 = Avx.mm256_rcp_ps(divisor_f32);
                if (constexpr.IS_CONST(divisor_f32))
                {
                    divisor_f32 = Avx.mm256_mul_ps(mm256_set1_epi32(RCP32_PRECISION_LOSS_U8), divisor_f32);
                }
                else
                {
                    dividend_f32 = Avx.mm256_mul_ps(mm256_set1_epi32(RCP32_PRECISION_LOSS_U8), dividend_f32);
                }
                return Avx.mm256_cvttps_epi32(mm256_fmadd_ps(dividend_f32, divisor_f32, summand_f32));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivRemBitwise(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 ONE = set1_epi8(1);
                v128 SIGN_BIT = set1_epi8(1 << 7);
                v128 quotients;

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotients = setzero_si128();
                    remainder = setzero_si128();

                    for (int i = 7; i >= 0; i--)
                    {
                        remainder = add_epi8(remainder, remainder);
                        quotients = add_epi8(quotients, quotients);
                        remainder = ternarylogic_si128(ONE, srli_epi16(dividend, i), remainder, TernaryOperation.OxEA);
                        v128 subtractFromRemainder = cmple_epu8(divisor, remainder, elements);
                        remainder = sub_epi8(remainder, and_si128(divisor, subtractFromRemainder));
                        quotients = sub_epi8(quotients, subtractFromRemainder);
                    }
                }
                else
                {
                    v128 flippedDivisor = xor_si128(divisor, SIGN_BIT);
                    v128 bit = and_si128(ONE, srli_epi16(dividend, 7));
                    v128 cmpbit = ternarylogic_si128(SIGN_BIT, ONE, srli_epi16(dividend, 7), TernaryOperation.OxF8);
                    v128 retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = bit;
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = andnot_si128(retainRemainder, ONE);

                    //for (int i = 6; i != 0; i--)
                    //{
                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 6));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 5));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 4));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 3));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 2));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 1));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                    //}
                    ////////////////////////////

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, dividend);
                    cmpbit = ternarylogic_si128(SIGN_BIT, remainder, bit, TernaryOperation.Ox1E);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                }

                constexpr.ASSUME_LT_EPU8(remainder, divisor, elements);
                return quotients;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivRemBitwise(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = mm256_set1_epi8(1);
                v256 SIGN_BIT = mm256_set1_epi8(1 << 7);
                v256 quotients;

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotients = Avx.mm256_setzero_si256();
                    remainder = Avx.mm256_setzero_si256();

                    for (int i = 7; i >= 0; i--)
                    {
                        remainder = Avx2.mm256_add_epi8(remainder, remainder);
                        quotients = Avx2.mm256_add_epi8(quotients, quotients);
                        remainder = mm256_ternarylogic_si256(ONE, mm256_srli_epi16(dividend, i), remainder, TernaryOperation.OxEA);
                        v256 subtractFromRemainder = mm256_cmple_epu8(divisor, remainder);
                        remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractFromRemainder));
                        quotients = Avx2.mm256_sub_epi8(quotients, subtractFromRemainder);
                    }
                }
                else
                {
                    v256 flippedDivisor = Avx2.mm256_xor_si256(divisor, SIGN_BIT);
                    v256 bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 7));
                    v256 cmpbit = mm256_ternarylogic_si256(SIGN_BIT, ONE, Avx2.mm256_srli_epi16(dividend, 7), TernaryOperation.OxF8);
                    v256 retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = bit;
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = Avx2.mm256_andnot_si256(retainRemainder, ONE);

                    //for (int i = 6; i != 0; i--)
                    //{
                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                    //}
                    ////////////////////////////

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, dividend);
                    cmpbit = mm256_ternarylogic_si256(SIGN_BIT, remainder, bit, TernaryOperation.Ox1E);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                }

                constexpr.ASSUME_LT_EPU8(remainder, divisor);
                return quotients;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivRemBitwiseSigned(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    if (elements <= 8)
                    {
                        Divider<sbyte>.bminit_epi8(divisor, out v128 mul16, Promise.Nothing, elements);

                        remainder = Divider<sbyte>.bmrem_epi8(dividend, mul16, divisor, Promise.Nothing, elements);
                        return Divider<sbyte>.bmdiv_epi8(dividend, mul16, divisor, Promise.Nothing, elements);
                    }
                    else
                    {
                        Divider<sbyte>.bminit_epi8(divisor, out v128 mul16Lo, out v128 mul16Hi, Promise.Nothing);

                        remainder = Divider<sbyte>.bmrem_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                        return Divider<sbyte>.bmdiv_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                    }
                }

                v128 unsignedQuotient = DivRemBitwise(abs_epi8(dividend, elements), abs_epi8(divisor, elements), out v128 unsignedRemainder, elements);

                return SIGNED_FROM_UNSIGNED_DIV_EPI8(out remainder, dividend, divisor, unsignedQuotient, unsignedRemainder, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivRemBitwiseSigned(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    Divider<sbyte>.mm256_bminit_epi8(divisor, out v256 mul16Lo, out v256 mul16Hi, Promise.Nothing);

                    remainder = Divider<sbyte>.mm256_bmrem_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                    return Divider<sbyte>.mm256_bmdiv_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                }

                v256 unsignedQuotient = DivRemBitwise(mm256_abs_epi8(dividend), mm256_abs_epi8(divisor), out v256 unsignedRemainders);

                return SIGNED_FROM_UNSIGNED_DIV_EPI8(out remainder, dividend, divisor, unsignedQuotient, unsignedRemainders);
            }
            else throw new IllegalInstructionException();
        }
    }
}