using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst;
using MaxMath.CompilerServices;

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

                v128 result;

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    result = DivRemBitwise(dividend, divisor, out _, elements);
                }
                else if (elements > 8)
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

                    result = packus_epi16(packs_epi32(q0, q1), packs_epi32(q2, q3));
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

                        result = packus_epi16(shorts, shorts);
                    }
                    else
                    {
                        result = unpacklo_epi32(cvtepi32_epi8(intsLo), cvtepi32_epi8(intsHi));
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepu8_ps(dividend), cvtepu8_ps(divisor));

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        result = cvtepi32_epi8(ints, elements);
                    }
                    else
                    {
                        v128 shorts = packs_epi32(ints, ints);
                        result = packus_epi16(shorts, shorts);
                    }
                }
                
                constexpr.ASSUME_DIVISION_EPU8(result, dividend, divisor, elements);
                return result;
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

                v128 result;

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    v128 quotients = DivRemBitwiseSigned(dividend, divisor, out _, elements);
                    if (saturated)
                    {
                        v128 MIN_VALUE = set1_epi8(sbyte.MinValue);

                        v128 overflow = and_si128(cmpeq_epi8(dividend, MIN_VALUE), cmpeq_epi8(divisor, setall_si128()));

                        result = add_epi8(quotients, overflow);
                    }
                    else
                    {
                        result = quotients;
                    }
                }
                else if (elements > 8)
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
                        result = packs_epi16(packs_epi32(q0, q1), packs_epi32(q2, q3));
                    }
                    else
                    {
                        result = cvt2x2epi16_epi8(packs_epi32(q0, q1), packs_epi32(q2, q3));
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
                        result = packs_epi16(shorts, shorts);
                    }
                    else
                    {
                        if (Sse2.IsSse2Supported)
                        {
                            result = cvt2x2epi16_epi8(shorts, shorts);
                        }
                        else
                        {
                            result = unpacklo_epi32(cvtepi32_epi8(intsLo), cvtepi32_epi8(intsHi));
                        }
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepi8_ps(dividend), cvtepi8_ps(divisor));

                    if (saturated)
                    {
                        v128 shorts = packs_epi32(ints, ints);
                        result = packs_epi16(shorts, shorts);
                    }
                    else
                    {
                        result = cvtepi32_epi8(ints, elements);
                    }
                }

                if (!saturated)
                {
                    constexpr.ASSUME_DIVISION_EPI8(result, dividend, divisor, elements);
                }
                else
                {
                    constexpr.ASSUME(result.SByte0  == ((dividend.SByte0  == sbyte.MinValue && divisor.SByte0  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte0  / divisor.SByte0)));
                    constexpr.ASSUME(result.SByte1  == ((dividend.SByte1  == sbyte.MinValue && divisor.SByte1  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte1  / divisor.SByte1)));
                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.SByte2  == ((dividend.SByte2  == sbyte.MinValue && divisor.SByte2  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte2  / divisor.SByte2)));

                        if (elements > 3)
                        {
                            constexpr.ASSUME(result.SByte3  == ((dividend.SByte3  == sbyte.MinValue && divisor.SByte3  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte3  / divisor.SByte3)));

                            if (elements > 4)
                            {
                                constexpr.ASSUME(result.SByte4  == ((dividend.SByte4  == sbyte.MinValue && divisor.SByte4  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte4  / divisor.SByte4)));
                                constexpr.ASSUME(result.SByte5  == ((dividend.SByte5  == sbyte.MinValue && divisor.SByte5  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte5  / divisor.SByte5)));
                                constexpr.ASSUME(result.SByte6  == ((dividend.SByte6  == sbyte.MinValue && divisor.SByte6  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte6  / divisor.SByte6)));
                                constexpr.ASSUME(result.SByte7  == ((dividend.SByte7  == sbyte.MinValue && divisor.SByte7  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte7  / divisor.SByte7)));

                                if (elements > 8)
                                {
                                    constexpr.ASSUME(result.SByte8  == ((dividend.SByte8  == sbyte.MinValue && divisor.SByte8  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte8  / divisor.SByte8)));
                                    constexpr.ASSUME(result.SByte9  == ((dividend.SByte9  == sbyte.MinValue && divisor.SByte9  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte9  / divisor.SByte9)));
                                    constexpr.ASSUME(result.SByte10 == ((dividend.SByte10 == sbyte.MinValue && divisor.SByte10 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte10 / divisor.SByte10)));
                                    constexpr.ASSUME(result.SByte11 == ((dividend.SByte11 == sbyte.MinValue && divisor.SByte11 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte11 / divisor.SByte11)));
                                    constexpr.ASSUME(result.SByte12 == ((dividend.SByte12 == sbyte.MinValue && divisor.SByte12 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte12 / divisor.SByte12)));
                                    constexpr.ASSUME(result.SByte13 == ((dividend.SByte13 == sbyte.MinValue && divisor.SByte13 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte13 / divisor.SByte13)));
                                    constexpr.ASSUME(result.SByte14 == ((dividend.SByte14 == sbyte.MinValue && divisor.SByte14 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte14 / divisor.SByte14)));
                                    constexpr.ASSUME(result.SByte15 == ((dividend.SByte15 == sbyte.MinValue && divisor.SByte15 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte15 / divisor.SByte15)));
                                }
                            }
                        }
                    }
                }

                return result;
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

                v256 result;
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    result = DivRemBitwise(dividend, divisor, out _);
                }
                else
                {
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

                    result = Avx2.mm256_packus_epi16(Avx2.mm256_packs_epi32(q0, q1), Avx2.mm256_packs_epi32(q2, q3));
                }
                
                constexpr.ASSUME_DIVISION_EPU8(result, dividend, divisor);
                return result;
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

                v256 result;

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    result = DivRemBitwiseSigned(dividend, divisor, out _);
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
                        result = Avx2.mm256_packs_epi16(Avx2.mm256_packs_epi32(q0, q1), Avx2.mm256_packs_epi32(q2, q3));
                    }
                    else
                    {
                        result = mm256_cvt2x2epi16_epi8(Avx2.mm256_packs_epi32(q0, q1), Avx2.mm256_packs_epi32(q2, q3));
                    }
                }
                
                if (!saturated)
                {
                    constexpr.ASSUME_DIVISION_EPI8(result, dividend, divisor);
                }
                else
                {
                    constexpr.ASSUME(result.SByte0  == ((dividend.SByte0  == sbyte.MinValue && divisor.SByte0  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte0  / divisor.SByte0)));
                    constexpr.ASSUME(result.SByte1  == ((dividend.SByte1  == sbyte.MinValue && divisor.SByte1  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte1  / divisor.SByte1)));
                    constexpr.ASSUME(result.SByte2  == ((dividend.SByte2  == sbyte.MinValue && divisor.SByte2  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte2  / divisor.SByte2)));
                    constexpr.ASSUME(result.SByte3  == ((dividend.SByte3  == sbyte.MinValue && divisor.SByte3  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte3  / divisor.SByte3)));
                    constexpr.ASSUME(result.SByte4  == ((dividend.SByte4  == sbyte.MinValue && divisor.SByte4  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte4  / divisor.SByte4)));
                    constexpr.ASSUME(result.SByte5  == ((dividend.SByte5  == sbyte.MinValue && divisor.SByte5  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte5  / divisor.SByte5)));
                    constexpr.ASSUME(result.SByte6  == ((dividend.SByte6  == sbyte.MinValue && divisor.SByte6  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte6  / divisor.SByte6)));
                    constexpr.ASSUME(result.SByte7  == ((dividend.SByte7  == sbyte.MinValue && divisor.SByte7  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte7  / divisor.SByte7)));
                    constexpr.ASSUME(result.SByte8  == ((dividend.SByte8  == sbyte.MinValue && divisor.SByte8  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte8  / divisor.SByte8)));
                    constexpr.ASSUME(result.SByte9  == ((dividend.SByte9  == sbyte.MinValue && divisor.SByte9  == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte9  / divisor.SByte9)));
                    constexpr.ASSUME(result.SByte10 == ((dividend.SByte10 == sbyte.MinValue && divisor.SByte10 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte10 / divisor.SByte10)));
                    constexpr.ASSUME(result.SByte11 == ((dividend.SByte11 == sbyte.MinValue && divisor.SByte11 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte11 / divisor.SByte11)));
                    constexpr.ASSUME(result.SByte12 == ((dividend.SByte12 == sbyte.MinValue && divisor.SByte12 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte12 / divisor.SByte12)));
                    constexpr.ASSUME(result.SByte13 == ((dividend.SByte13 == sbyte.MinValue && divisor.SByte13 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte13 / divisor.SByte13)));
                    constexpr.ASSUME(result.SByte14 == ((dividend.SByte14 == sbyte.MinValue && divisor.SByte14 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte14 / divisor.SByte14)));
                    constexpr.ASSUME(result.SByte15 == ((dividend.SByte15 == sbyte.MinValue && divisor.SByte15 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte15 / divisor.SByte15)));
                    constexpr.ASSUME(result.SByte16 == ((dividend.SByte16 == sbyte.MinValue && divisor.SByte16 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte16 / divisor.SByte16)));
                    constexpr.ASSUME(result.SByte17 == ((dividend.SByte17 == sbyte.MinValue && divisor.SByte17 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte17 / divisor.SByte17)));
                    constexpr.ASSUME(result.SByte18 == ((dividend.SByte18 == sbyte.MinValue && divisor.SByte18 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte18 / divisor.SByte18)));
                    constexpr.ASSUME(result.SByte19 == ((dividend.SByte19 == sbyte.MinValue && divisor.SByte19 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte19 / divisor.SByte19)));
                    constexpr.ASSUME(result.SByte20 == ((dividend.SByte20 == sbyte.MinValue && divisor.SByte20 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte20 / divisor.SByte20)));
                    constexpr.ASSUME(result.SByte21 == ((dividend.SByte21 == sbyte.MinValue && divisor.SByte21 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte21 / divisor.SByte21)));
                    constexpr.ASSUME(result.SByte22 == ((dividend.SByte22 == sbyte.MinValue && divisor.SByte22 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte22 / divisor.SByte22)));
                    constexpr.ASSUME(result.SByte23 == ((dividend.SByte23 == sbyte.MinValue && divisor.SByte23 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte23 / divisor.SByte23)));
                    constexpr.ASSUME(result.SByte24 == ((dividend.SByte24 == sbyte.MinValue && divisor.SByte24 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte24 / divisor.SByte24)));
                    constexpr.ASSUME(result.SByte25 == ((dividend.SByte25 == sbyte.MinValue && divisor.SByte25 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte25 / divisor.SByte25)));
                    constexpr.ASSUME(result.SByte26 == ((dividend.SByte26 == sbyte.MinValue && divisor.SByte26 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte26 / divisor.SByte26)));
                    constexpr.ASSUME(result.SByte27 == ((dividend.SByte27 == sbyte.MinValue && divisor.SByte27 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte27 / divisor.SByte27)));
                    constexpr.ASSUME(result.SByte28 == ((dividend.SByte28 == sbyte.MinValue && divisor.SByte28 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte28 / divisor.SByte28)));
                    constexpr.ASSUME(result.SByte29 == ((dividend.SByte29 == sbyte.MinValue && divisor.SByte29 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte29 / divisor.SByte29)));
                    constexpr.ASSUME(result.SByte30 == ((dividend.SByte30 == sbyte.MinValue && divisor.SByte30 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte30 / divisor.SByte30)));
                    constexpr.ASSUME(result.SByte31 == ((dividend.SByte31 == sbyte.MinValue && divisor.SByte31 == -1) ? sbyte.MaxValue : (sbyte)(dividend.SByte31 / divisor.SByte31)));
                }
                return result;
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
                
                constexpr.ASSUME_REMAINDER_EPU8(result, dividend, divisor, elements);
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

                v128 result;

                if (elements > 4
                && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    DivRemBitwiseSigned(dividend, divisor, out result, elements);
                }
                else
                {
                    result = sub_epi8(dividend, divmullo_epi8(dividend, divisor, divisor, out _, noOverflow: false, elements: elements));
                }
                
                constexpr.ASSUME_REMAINDER_EPI8(result, dividend, divisor, elements);
                return result;
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
                
                constexpr.ASSUME_REMAINDER_EPU8(result, dividend, divisor);
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

                v256 result;

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    DivRemBitwiseSigned(dividend, divisor, out result);
                }
                else
                {
                    result = Avx2.mm256_sub_epi8(dividend, mm256_divmullo_epi8(dividend, divisor, divisor, out _, noOverflow: false));
                }
                
                constexpr.ASSUME_REMAINDER_EPI8(result, dividend, divisor);
                return result;
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
                
                constexpr.ASSUME_DIVISION_EPU8(quotient, dividend, divisor, elements);
                constexpr.ASSUME_REMAINDER_EPU8(remainder, dividend, divisor, elements);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi8(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient;

                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epi8(dividend, divisor, elements);
                    quotient = constdiv_epi8(dividend, divisor, elements);
                }
                else if (elements > 4
                      && COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotient = DivRemBitwiseSigned(dividend, divisor, out remainder, elements);
                }
                else
                {
                    remainder = sub_epi8(dividend, divmullo_epi8(dividend, divisor, divisor, out quotient, noOverflow: false, saturated: false, elements: elements));
                }
                
                constexpr.ASSUME_DIVISION_EPI8(quotient, dividend, divisor, elements);
                constexpr.ASSUME_REMAINDER_EPI8(remainder, dividend, divisor, elements);
                return quotient;
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
                
                constexpr.ASSUME_DIVISION_EPU8(quotient, dividend, divisor);
                constexpr.ASSUME_REMAINDER_EPU8(remainder, dividend, divisor);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi8(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient;

                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epi8(dividend, divisor);
                    quotient = mm256_constdiv_epi8(dividend, divisor);
                }
                else if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotient = DivRemBitwiseSigned(dividend, divisor, out remainder);
                }
                else
                {
                    remainder = Avx2.mm256_sub_epi8(dividend, mm256_divmullo_epi8(dividend, divisor, divisor, out quotient, noOverflow: false, saturated: false));
                }
                
                constexpr.ASSUME_DIVISION_EPI8(quotient, dividend, divisor);
                constexpr.ASSUME_REMAINDER_EPI8(remainder, dividend, divisor);
                return quotient;
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

                v128 result;

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
                        result = packus_epi16(result16Lo, result16Hi);
                    }
                    else
                    {
                        result = cvt2x2epi16_epi8(result16Lo, result16Hi);
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
                        result = packus_epi16(result16, result16);
                    }
                    else
                    {
                        result = cvtepi16_epi8(result16);
                    }
                }
                else
                {
                    v128 castDividend = cvtepu8_epi32(dividend);
                    v128 castDivisor = cvtepu8_epi32(divisor);
                    v128 castSummand = cvtepu8_epi32(summand);
                    v128 result32 = DIVADD_FLOATV_UNSIGNED_BYTE_RANGE_RET_INT(cvtepi32_ps(castDividend), cvtepi32_ps(castDivisor), cvtepi32_ps(castSummand));

                    result = cvtepi32_epi8(result32, elements);
                }

			    constexpr.ASSUME(result.Byte0 == (byte)((byte)(dividend.Byte0 / divisor.Byte0) + summand.Byte0));
			    constexpr.ASSUME(result.Byte1 == (byte)((byte)(dividend.Byte1 / divisor.Byte1) + summand.Byte1));
			    if (elements > 2)
                {
                    constexpr.ASSUME(result.Byte2 == (byte)((byte)(dividend.Byte2 / divisor.Byte2) + summand.Byte2));
                    if (elements > 3)
                    {
			            constexpr.ASSUME(result.Byte3 == (byte)((byte)(dividend.Byte3 / divisor.Byte3) + summand.Byte3));
                        if (elements > 4)
                        {
			                constexpr.ASSUME(result.Byte4 == (byte)((byte)(dividend.Byte4 / divisor.Byte4) + summand.Byte4));
			                constexpr.ASSUME(result.Byte5 == (byte)((byte)(dividend.Byte5 / divisor.Byte5) + summand.Byte5));
			                constexpr.ASSUME(result.Byte6 == (byte)((byte)(dividend.Byte6 / divisor.Byte6) + summand.Byte6));
			                constexpr.ASSUME(result.Byte7 == (byte)((byte)(dividend.Byte7 / divisor.Byte7) + summand.Byte7));
                            if (elements > 8)
                            {
			                    constexpr.ASSUME(result.Byte8 == (byte)((byte)(dividend.Byte8 / divisor.Byte8) + summand.Byte8));
			                    constexpr.ASSUME(result.Byte9 == (byte)((byte)(dividend.Byte9 / divisor.Byte9) + summand.Byte9));
			                    constexpr.ASSUME(result.Byte10 == (byte)((byte)(dividend.Byte10 / divisor.Byte10) + summand.Byte10));
			                    constexpr.ASSUME(result.Byte11 == (byte)((byte)(dividend.Byte11 / divisor.Byte11) + summand.Byte11));
			                    constexpr.ASSUME(result.Byte12 == (byte)((byte)(dividend.Byte12 / divisor.Byte12) + summand.Byte12));
			                    constexpr.ASSUME(result.Byte13 == (byte)((byte)(dividend.Byte13 / divisor.Byte13) + summand.Byte13));
			                    constexpr.ASSUME(result.Byte14 == (byte)((byte)(dividend.Byte14 / divisor.Byte14) + summand.Byte14));
			                    constexpr.ASSUME(result.Byte15 == (byte)((byte)(dividend.Byte15 / divisor.Byte15) + summand.Byte15));
                            }
                        }
                    }
                }

                return result;
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

                v256 result;

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
                    result = Avx2.mm256_packus_epi16(result16Lo, result16Hi);
                }
                else
                {
                    result = mm256_cvt2x2epi16_epi8(result16Lo, result16Hi);
                }

			    constexpr.ASSUME(result.Byte0  == (byte)((byte)(dividend.Byte0  / divisor.Byte0)  + summand.Byte0));
			    constexpr.ASSUME(result.Byte1  == (byte)((byte)(dividend.Byte1  / divisor.Byte1)  + summand.Byte1));
			    constexpr.ASSUME(result.Byte2  == (byte)((byte)(dividend.Byte2  / divisor.Byte2)  + summand.Byte2));
			    constexpr.ASSUME(result.Byte3  == (byte)((byte)(dividend.Byte3  / divisor.Byte3)  + summand.Byte3));
			    constexpr.ASSUME(result.Byte4  == (byte)((byte)(dividend.Byte4  / divisor.Byte4)  + summand.Byte4));
			    constexpr.ASSUME(result.Byte5  == (byte)((byte)(dividend.Byte5  / divisor.Byte5)  + summand.Byte5));
			    constexpr.ASSUME(result.Byte6  == (byte)((byte)(dividend.Byte6  / divisor.Byte6)  + summand.Byte6));
			    constexpr.ASSUME(result.Byte7  == (byte)((byte)(dividend.Byte7  / divisor.Byte7)  + summand.Byte7));
			    constexpr.ASSUME(result.Byte8  == (byte)((byte)(dividend.Byte8  / divisor.Byte8)  + summand.Byte8));
			    constexpr.ASSUME(result.Byte9  == (byte)((byte)(dividend.Byte9  / divisor.Byte9)  + summand.Byte9));
			    constexpr.ASSUME(result.Byte10 == (byte)((byte)(dividend.Byte10 / divisor.Byte10) + summand.Byte10));
			    constexpr.ASSUME(result.Byte11 == (byte)((byte)(dividend.Byte11 / divisor.Byte11) + summand.Byte11));
			    constexpr.ASSUME(result.Byte12 == (byte)((byte)(dividend.Byte12 / divisor.Byte12) + summand.Byte12));
			    constexpr.ASSUME(result.Byte13 == (byte)((byte)(dividend.Byte13 / divisor.Byte13) + summand.Byte13));
			    constexpr.ASSUME(result.Byte14 == (byte)((byte)(dividend.Byte14 / divisor.Byte14) + summand.Byte14));
			    constexpr.ASSUME(result.Byte15 == (byte)((byte)(dividend.Byte15 / divisor.Byte15) + summand.Byte15));
			    constexpr.ASSUME(result.Byte16 == (byte)((byte)(dividend.Byte16 / divisor.Byte16) + summand.Byte16));
			    constexpr.ASSUME(result.Byte17 == (byte)((byte)(dividend.Byte17 / divisor.Byte17) + summand.Byte17));
			    constexpr.ASSUME(result.Byte18 == (byte)((byte)(dividend.Byte18 / divisor.Byte18) + summand.Byte18));
			    constexpr.ASSUME(result.Byte19 == (byte)((byte)(dividend.Byte19 / divisor.Byte19) + summand.Byte19));
			    constexpr.ASSUME(result.Byte20 == (byte)((byte)(dividend.Byte20 / divisor.Byte20) + summand.Byte20));
			    constexpr.ASSUME(result.Byte21 == (byte)((byte)(dividend.Byte21 / divisor.Byte21) + summand.Byte21));
			    constexpr.ASSUME(result.Byte22 == (byte)((byte)(dividend.Byte22 / divisor.Byte22) + summand.Byte22));
			    constexpr.ASSUME(result.Byte23 == (byte)((byte)(dividend.Byte23 / divisor.Byte23) + summand.Byte23));
			    constexpr.ASSUME(result.Byte24 == (byte)((byte)(dividend.Byte24 / divisor.Byte24) + summand.Byte24));
			    constexpr.ASSUME(result.Byte25 == (byte)((byte)(dividend.Byte25 / divisor.Byte25) + summand.Byte25));
			    constexpr.ASSUME(result.Byte26 == (byte)((byte)(dividend.Byte26 / divisor.Byte26) + summand.Byte26));
			    constexpr.ASSUME(result.Byte27 == (byte)((byte)(dividend.Byte27 / divisor.Byte27) + summand.Byte27));
			    constexpr.ASSUME(result.Byte28 == (byte)((byte)(dividend.Byte28 / divisor.Byte28) + summand.Byte28));
			    constexpr.ASSUME(result.Byte29 == (byte)((byte)(dividend.Byte29 / divisor.Byte29) + summand.Byte29));
			    constexpr.ASSUME(result.Byte30 == (byte)((byte)(dividend.Byte30 / divisor.Byte30) + summand.Byte30));
			    constexpr.ASSUME(result.Byte31 == (byte)((byte)(dividend.Byte31 / divisor.Byte31) + summand.Byte31));

                return result;
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

                v128 result;

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
                        result = packus_epi16(mul16Lo, mul16Hi);
                    }
                    else
                    {
                        quotient = cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                        result = cvt2x2epi16_epi8(mul16Lo, mul16Hi);
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
                    result = mullo_epi16(cvtepu8_epi16(factor), quotients16);

                    if (noOverflow)
                    {
                        quotient = packus_epi16(quotients16, quotients16);
                        result = packus_epi16(result, result);
                    }
                    else
                    {
                        quotient = cvtepi16_epi8(quotients16);
                        result = cvtepi16_epi8(result);
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
                        result = cvtepi32_epi8(mullo_epi32(cvtepu8_epi32(factor), quotients32), elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepu8_epi16(dividend);
                        v128 castDivisor = cvtepu8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepu16_ps(castDividend), cvtepu16_ps(castDivisor));
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        result = mullo_epi16(cvtepu8_epi16(factor), quotients16);

                        if (noOverflow)
                        {
                            quotient = packus_epi16(quotients16, quotients16);
                            result = packus_epi16(result, result);
                        }
                        else
                        {
                            quotient = cvtepi16_epi8(quotients16);
                            result = cvtepi16_epi8(result);
                        }
                    }
                }

			    constexpr.ASSUME(result.Byte0 == (byte)((byte)(dividend.Byte0 / divisor.Byte0) * factor.Byte0));
			    constexpr.ASSUME(result.Byte1 == (byte)((byte)(dividend.Byte1 / divisor.Byte1) * factor.Byte1));
			    if (elements > 2)
                {
                    constexpr.ASSUME(result.Byte2 == (byte)((byte)(dividend.Byte2 / divisor.Byte2) * factor.Byte2));
                    if (elements > 3)
                    {
			            constexpr.ASSUME(result.Byte3 == (byte)((byte)(dividend.Byte3 / divisor.Byte3) * factor.Byte3));
                        if (elements > 4)
                        {
			                constexpr.ASSUME(result.Byte4 == (byte)((byte)(dividend.Byte4 / divisor.Byte4) * factor.Byte4));
			                constexpr.ASSUME(result.Byte5 == (byte)((byte)(dividend.Byte5 / divisor.Byte5) * factor.Byte5));
			                constexpr.ASSUME(result.Byte6 == (byte)((byte)(dividend.Byte6 / divisor.Byte6) * factor.Byte6));
			                constexpr.ASSUME(result.Byte7 == (byte)((byte)(dividend.Byte7 / divisor.Byte7) * factor.Byte7));
                            if (elements > 8)
                            {
			                    constexpr.ASSUME(result.Byte8 == (byte)((byte)(dividend.Byte8 / divisor.Byte8) * factor.Byte8));
			                    constexpr.ASSUME(result.Byte9 == (byte)((byte)(dividend.Byte9 / divisor.Byte9) * factor.Byte9));
			                    constexpr.ASSUME(result.Byte10 == (byte)((byte)(dividend.Byte10 / divisor.Byte10) * factor.Byte10));
			                    constexpr.ASSUME(result.Byte11 == (byte)((byte)(dividend.Byte11 / divisor.Byte11) * factor.Byte11));
			                    constexpr.ASSUME(result.Byte12 == (byte)((byte)(dividend.Byte12 / divisor.Byte12) * factor.Byte12));
			                    constexpr.ASSUME(result.Byte13 == (byte)((byte)(dividend.Byte13 / divisor.Byte13) * factor.Byte13));
			                    constexpr.ASSUME(result.Byte14 == (byte)((byte)(dividend.Byte14 / divisor.Byte14) * factor.Byte14));
			                    constexpr.ASSUME(result.Byte15 == (byte)((byte)(dividend.Byte15 / divisor.Byte15) * factor.Byte15));
                            }
                        }
                    }
                }

			    constexpr.ASSUME(quotient.Byte0 == (byte)(dividend.Byte0 / divisor.Byte0));
			    constexpr.ASSUME(quotient.Byte1 == (byte)(dividend.Byte1 / divisor.Byte1));
			    if (elements > 2)
                {
                    constexpr.ASSUME(quotient.Byte2 == (byte)(dividend.Byte2 / divisor.Byte2));
                    if (elements > 3)
                    {
			            constexpr.ASSUME(quotient.Byte3 == (byte)(dividend.Byte3 / divisor.Byte3));
                        if (elements > 4)
                        {
			                constexpr.ASSUME(quotient.Byte4 == (byte)(dividend.Byte4 / divisor.Byte4));
			                constexpr.ASSUME(quotient.Byte5 == (byte)(dividend.Byte5 / divisor.Byte5));
			                constexpr.ASSUME(quotient.Byte6 == (byte)(dividend.Byte6 / divisor.Byte6));
			                constexpr.ASSUME(quotient.Byte7 == (byte)(dividend.Byte7 / divisor.Byte7));
                            if (elements > 8)
                            {
			                    constexpr.ASSUME(quotient.Byte8  == (byte)(dividend.Byte8  / divisor.Byte8));
			                    constexpr.ASSUME(quotient.Byte9  == (byte)(dividend.Byte9  / divisor.Byte9));
			                    constexpr.ASSUME(quotient.Byte10 == (byte)(dividend.Byte10 / divisor.Byte10));
			                    constexpr.ASSUME(quotient.Byte11 == (byte)(dividend.Byte11 / divisor.Byte11));
			                    constexpr.ASSUME(quotient.Byte12 == (byte)(dividend.Byte12 / divisor.Byte12));
			                    constexpr.ASSUME(quotient.Byte13 == (byte)(dividend.Byte13 / divisor.Byte13));
			                    constexpr.ASSUME(quotient.Byte14 == (byte)(dividend.Byte14 / divisor.Byte14));
			                    constexpr.ASSUME(quotient.Byte15 == (byte)(dividend.Byte15 / divisor.Byte15));
                            }
                        }
                    }
                }

                return result;
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

                v128 result;

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
                        result = packs_epi16(mul16Lo, mul16Hi);
                    }
                    else
                    {
                        quotient = cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                        result = cvt2x2epi16_epi8(mul16Lo, mul16Hi);
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
                    result = mullo_epi16(cvtepi8_epi16(factor), quotients16);

                    if (noOverflow
                     || (saturated
                      || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue, elements)
                      || constexpr.ALL_NEQ_EPI8(dividend, -1, elements)))
                    {
                        quotient = packs_epi16(quotients16, quotients16);
                        result = packs_epi16(result, result);
                    }
                    else
                    {
                        quotient = cvtepi16_epi8(quotients16);
                        result = cvtepi16_epi8(result);
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
                        result = cvtepi32_epi8(mullo_epi32(cvtepi8_epi32(factor), quotients32), elements);
                    }
                    else
                    {
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        result = mullo_epi16(cvtepi8_epi16(factor), quotients16);

                        if (noOverflow
                         || (saturated
                          || constexpr.ALL_NEQ_EPI8(dividend, sbyte.MinValue, elements)
                          || constexpr.ALL_NEQ_EPI8(dividend, -1, elements)))
                        {
                            quotient = packs_epi16(quotients16, quotients16);
                            result = packs_epi16(result, result);
                        }
                        else
                        {
                            quotient = cvtepi16_epi8(quotients16);
                            result = cvtepi16_epi8(result);
                        }
                    }
                }
                
                if (!saturated
                 || noOverflow)
                {
			        constexpr.ASSUME(result.SByte0 == (sbyte)((sbyte)(dividend.SByte0 / divisor.SByte0) * factor.SByte0));
			        constexpr.ASSUME(result.SByte1 == (sbyte)((sbyte)(dividend.SByte1 / divisor.SByte1) * factor.SByte1));
			        if (elements > 2)
                    {
                        constexpr.ASSUME(result.SByte2 == (sbyte)((sbyte)(dividend.SByte2 / divisor.SByte2) * factor.SByte2));
                        if (elements > 3)
                        {
			                constexpr.ASSUME(result.SByte3 == (sbyte)((sbyte)(dividend.SByte3 / divisor.SByte3) * factor.SByte3));
                            if (elements > 4)
                            {
			                    constexpr.ASSUME(result.SByte4 == (sbyte)((sbyte)(dividend.SByte4 / divisor.SByte4) * factor.SByte4));
			                    constexpr.ASSUME(result.SByte5 == (sbyte)((sbyte)(dividend.SByte5 / divisor.SByte5) * factor.SByte5));
			                    constexpr.ASSUME(result.SByte6 == (sbyte)((sbyte)(dividend.SByte6 / divisor.SByte6) * factor.SByte6));
			                    constexpr.ASSUME(result.SByte7 == (sbyte)((sbyte)(dividend.SByte7 / divisor.SByte7) * factor.SByte7));
                                if (elements > 8)
                                {
			                        constexpr.ASSUME(result.SByte8 == (sbyte)((sbyte)(dividend.SByte8 / divisor.SByte8) * factor.SByte8));
			                        constexpr.ASSUME(result.SByte9 == (sbyte)((sbyte)(dividend.SByte9 / divisor.SByte9) * factor.SByte9));
			                        constexpr.ASSUME(result.SByte10 == (sbyte)((sbyte)(dividend.SByte10 / divisor.SByte10) * factor.SByte10));
			                        constexpr.ASSUME(result.SByte11 == (sbyte)((sbyte)(dividend.SByte11 / divisor.SByte11) * factor.SByte11));
			                        constexpr.ASSUME(result.SByte12 == (sbyte)((sbyte)(dividend.SByte12 / divisor.SByte12) * factor.SByte12));
			                        constexpr.ASSUME(result.SByte13 == (sbyte)((sbyte)(dividend.SByte13 / divisor.SByte13) * factor.SByte13));
			                        constexpr.ASSUME(result.SByte14 == (sbyte)((sbyte)(dividend.SByte14 / divisor.SByte14) * factor.SByte14));
			                        constexpr.ASSUME(result.SByte15 == (sbyte)((sbyte)(dividend.SByte15 / divisor.SByte15) * factor.SByte15));
                                }
                            }
                        }
                    }

			        constexpr.ASSUME(quotient.SByte0 == (sbyte)(dividend.SByte0 / divisor.SByte0));
			        constexpr.ASSUME(quotient.SByte1 == (sbyte)(dividend.SByte1 / divisor.SByte1));
			        if (elements > 2)
                    {
                        constexpr.ASSUME(quotient.SByte2 == (sbyte)(dividend.SByte2 / divisor.SByte2));
                        if (elements > 3)
                        {
			                constexpr.ASSUME(quotient.SByte3 == (sbyte)(dividend.SByte3 / divisor.SByte3));
                            if (elements > 4)
                            {
			                    constexpr.ASSUME(quotient.SByte4 == (sbyte)(dividend.SByte4 / divisor.SByte4));
			                    constexpr.ASSUME(quotient.SByte5 == (sbyte)(dividend.SByte5 / divisor.SByte5));
			                    constexpr.ASSUME(quotient.SByte6 == (sbyte)(dividend.SByte6 / divisor.SByte6));
			                    constexpr.ASSUME(quotient.SByte7 == (sbyte)(dividend.SByte7 / divisor.SByte7));
                                if (elements > 8)
                                {
			                        constexpr.ASSUME(quotient.SByte8  == (sbyte)(dividend.SByte8  / divisor.SByte8));
			                        constexpr.ASSUME(quotient.SByte9  == (sbyte)(dividend.SByte9  / divisor.SByte9));
			                        constexpr.ASSUME(quotient.SByte10 == (sbyte)(dividend.SByte10 / divisor.SByte10));
			                        constexpr.ASSUME(quotient.SByte11 == (sbyte)(dividend.SByte11 / divisor.SByte11));
			                        constexpr.ASSUME(quotient.SByte12 == (sbyte)(dividend.SByte12 / divisor.SByte12));
			                        constexpr.ASSUME(quotient.SByte13 == (sbyte)(dividend.SByte13 / divisor.SByte13));
			                        constexpr.ASSUME(quotient.SByte14 == (sbyte)(dividend.SByte14 / divisor.SByte14));
			                        constexpr.ASSUME(quotient.SByte15 == (sbyte)(dividend.SByte15 / divisor.SByte15));
                                }
                            }
                        }
                    }
                }

                return result;
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

                v256 result;

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
                    result = Avx2.mm256_packus_epi16(fac16Lo, fac16Hi);
                }
                else
                {
                    quotient = mm256_cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                    result = mm256_cvt2x2epi16_epi8(fac16Lo, fac16Hi);
                }

			    constexpr.ASSUME(result.Byte0  == (byte)((byte)(dividend.Byte0  / divisor.Byte0)  * factor.Byte0));
			    constexpr.ASSUME(result.Byte1  == (byte)((byte)(dividend.Byte1  / divisor.Byte1)  * factor.Byte1));
			    constexpr.ASSUME(result.Byte2  == (byte)((byte)(dividend.Byte2  / divisor.Byte2)  * factor.Byte2));
			    constexpr.ASSUME(result.Byte3  == (byte)((byte)(dividend.Byte3  / divisor.Byte3)  * factor.Byte3));
			    constexpr.ASSUME(result.Byte4  == (byte)((byte)(dividend.Byte4  / divisor.Byte4)  * factor.Byte4));
			    constexpr.ASSUME(result.Byte5  == (byte)((byte)(dividend.Byte5  / divisor.Byte5)  * factor.Byte5));
			    constexpr.ASSUME(result.Byte6  == (byte)((byte)(dividend.Byte6  / divisor.Byte6)  * factor.Byte6));
			    constexpr.ASSUME(result.Byte7  == (byte)((byte)(dividend.Byte7  / divisor.Byte7)  * factor.Byte7));
			    constexpr.ASSUME(result.Byte8  == (byte)((byte)(dividend.Byte8  / divisor.Byte8)  * factor.Byte8));
			    constexpr.ASSUME(result.Byte9  == (byte)((byte)(dividend.Byte9  / divisor.Byte9)  * factor.Byte9));
			    constexpr.ASSUME(result.Byte10 == (byte)((byte)(dividend.Byte10 / divisor.Byte10) * factor.Byte10));
			    constexpr.ASSUME(result.Byte11 == (byte)((byte)(dividend.Byte11 / divisor.Byte11) * factor.Byte11));
			    constexpr.ASSUME(result.Byte12 == (byte)((byte)(dividend.Byte12 / divisor.Byte12) * factor.Byte12));
			    constexpr.ASSUME(result.Byte13 == (byte)((byte)(dividend.Byte13 / divisor.Byte13) * factor.Byte13));
			    constexpr.ASSUME(result.Byte14 == (byte)((byte)(dividend.Byte14 / divisor.Byte14) * factor.Byte14));
			    constexpr.ASSUME(result.Byte15 == (byte)((byte)(dividend.Byte15 / divisor.Byte15) * factor.Byte15));
			    constexpr.ASSUME(result.Byte16 == (byte)((byte)(dividend.Byte16 / divisor.Byte16) * factor.Byte16));
			    constexpr.ASSUME(result.Byte17 == (byte)((byte)(dividend.Byte17 / divisor.Byte17) * factor.Byte17));
			    constexpr.ASSUME(result.Byte18 == (byte)((byte)(dividend.Byte18 / divisor.Byte18) * factor.Byte18));
			    constexpr.ASSUME(result.Byte19 == (byte)((byte)(dividend.Byte19 / divisor.Byte19) * factor.Byte19));
			    constexpr.ASSUME(result.Byte20 == (byte)((byte)(dividend.Byte20 / divisor.Byte20) * factor.Byte20));
			    constexpr.ASSUME(result.Byte21 == (byte)((byte)(dividend.Byte21 / divisor.Byte21) * factor.Byte21));
			    constexpr.ASSUME(result.Byte22 == (byte)((byte)(dividend.Byte22 / divisor.Byte22) * factor.Byte22));
			    constexpr.ASSUME(result.Byte23 == (byte)((byte)(dividend.Byte23 / divisor.Byte23) * factor.Byte23));
			    constexpr.ASSUME(result.Byte24 == (byte)((byte)(dividend.Byte24 / divisor.Byte24) * factor.Byte24));
			    constexpr.ASSUME(result.Byte25 == (byte)((byte)(dividend.Byte25 / divisor.Byte25) * factor.Byte25));
			    constexpr.ASSUME(result.Byte26 == (byte)((byte)(dividend.Byte26 / divisor.Byte26) * factor.Byte26));
			    constexpr.ASSUME(result.Byte27 == (byte)((byte)(dividend.Byte27 / divisor.Byte27) * factor.Byte27));
			    constexpr.ASSUME(result.Byte28 == (byte)((byte)(dividend.Byte28 / divisor.Byte28) * factor.Byte28));
			    constexpr.ASSUME(result.Byte29 == (byte)((byte)(dividend.Byte29 / divisor.Byte29) * factor.Byte29));
			    constexpr.ASSUME(result.Byte30 == (byte)((byte)(dividend.Byte30 / divisor.Byte30) * factor.Byte30));
			    constexpr.ASSUME(result.Byte31 == (byte)((byte)(dividend.Byte31 / divisor.Byte31) * factor.Byte31));

			    constexpr.ASSUME(quotient.Byte0  == (byte)(dividend.Byte0  / divisor.Byte0));
			    constexpr.ASSUME(quotient.Byte1  == (byte)(dividend.Byte1  / divisor.Byte1));
			    constexpr.ASSUME(quotient.Byte2  == (byte)(dividend.Byte2  / divisor.Byte2));
			    constexpr.ASSUME(quotient.Byte3  == (byte)(dividend.Byte3  / divisor.Byte3));
			    constexpr.ASSUME(quotient.Byte4  == (byte)(dividend.Byte4  / divisor.Byte4));
			    constexpr.ASSUME(quotient.Byte5  == (byte)(dividend.Byte5  / divisor.Byte5));
			    constexpr.ASSUME(quotient.Byte6  == (byte)(dividend.Byte6  / divisor.Byte6));
			    constexpr.ASSUME(quotient.Byte7  == (byte)(dividend.Byte7  / divisor.Byte7));
			    constexpr.ASSUME(quotient.Byte8  == (byte)(dividend.Byte8  / divisor.Byte8));
			    constexpr.ASSUME(quotient.Byte9  == (byte)(dividend.Byte9  / divisor.Byte9));
			    constexpr.ASSUME(quotient.Byte10 == (byte)(dividend.Byte10 / divisor.Byte10));
			    constexpr.ASSUME(quotient.Byte11 == (byte)(dividend.Byte11 / divisor.Byte11));
			    constexpr.ASSUME(quotient.Byte12 == (byte)(dividend.Byte12 / divisor.Byte12));
			    constexpr.ASSUME(quotient.Byte13 == (byte)(dividend.Byte13 / divisor.Byte13));
			    constexpr.ASSUME(quotient.Byte14 == (byte)(dividend.Byte14 / divisor.Byte14));
			    constexpr.ASSUME(quotient.Byte15 == (byte)(dividend.Byte15 / divisor.Byte15));
			    constexpr.ASSUME(quotient.Byte16 == (byte)(dividend.Byte16 / divisor.Byte16));
			    constexpr.ASSUME(quotient.Byte17 == (byte)(dividend.Byte17 / divisor.Byte17));
			    constexpr.ASSUME(quotient.Byte18 == (byte)(dividend.Byte18 / divisor.Byte18));
			    constexpr.ASSUME(quotient.Byte19 == (byte)(dividend.Byte19 / divisor.Byte19));
			    constexpr.ASSUME(quotient.Byte20 == (byte)(dividend.Byte20 / divisor.Byte20));
			    constexpr.ASSUME(quotient.Byte21 == (byte)(dividend.Byte21 / divisor.Byte21));
			    constexpr.ASSUME(quotient.Byte22 == (byte)(dividend.Byte22 / divisor.Byte22));
			    constexpr.ASSUME(quotient.Byte23 == (byte)(dividend.Byte23 / divisor.Byte23));
			    constexpr.ASSUME(quotient.Byte24 == (byte)(dividend.Byte24 / divisor.Byte24));
			    constexpr.ASSUME(quotient.Byte25 == (byte)(dividend.Byte25 / divisor.Byte25));
			    constexpr.ASSUME(quotient.Byte26 == (byte)(dividend.Byte26 / divisor.Byte26));
			    constexpr.ASSUME(quotient.Byte27 == (byte)(dividend.Byte27 / divisor.Byte27));
			    constexpr.ASSUME(quotient.Byte28 == (byte)(dividend.Byte28 / divisor.Byte28));
			    constexpr.ASSUME(quotient.Byte29 == (byte)(dividend.Byte29 / divisor.Byte29));
			    constexpr.ASSUME(quotient.Byte30 == (byte)(dividend.Byte30 / divisor.Byte30));
			    constexpr.ASSUME(quotient.Byte31 == (byte)(dividend.Byte31 / divisor.Byte31));

                return result;
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

                v256 result;

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
                    result = Avx2.mm256_packs_epi16(fac16Lo, fac16Hi);
                }
                else
                {
                    quotient = mm256_cvt2x2epi16_epi8(quotients16Lo, quotients16Hi);
                    result = mm256_cvt2x2epi16_epi8(fac16Lo, fac16Hi);
                }
                
                if (!saturated)
                {
			        constexpr.ASSUME(result.SByte0  == (sbyte)((sbyte)(dividend.SByte0  / divisor.SByte0)  * factor.SByte0));
			        constexpr.ASSUME(result.SByte1  == (sbyte)((sbyte)(dividend.SByte1  / divisor.SByte1)  * factor.SByte1));
			        constexpr.ASSUME(result.SByte2  == (sbyte)((sbyte)(dividend.SByte2  / divisor.SByte2)  * factor.SByte2));
			        constexpr.ASSUME(result.SByte3  == (sbyte)((sbyte)(dividend.SByte3  / divisor.SByte3)  * factor.SByte3));
			        constexpr.ASSUME(result.SByte4  == (sbyte)((sbyte)(dividend.SByte4  / divisor.SByte4)  * factor.SByte4));
			        constexpr.ASSUME(result.SByte5  == (sbyte)((sbyte)(dividend.SByte5  / divisor.SByte5)  * factor.SByte5));
			        constexpr.ASSUME(result.SByte6  == (sbyte)((sbyte)(dividend.SByte6  / divisor.SByte6)  * factor.SByte6));
			        constexpr.ASSUME(result.SByte7  == (sbyte)((sbyte)(dividend.SByte7  / divisor.SByte7)  * factor.SByte7));
			        constexpr.ASSUME(result.SByte8  == (sbyte)((sbyte)(dividend.SByte8  / divisor.SByte8)  * factor.SByte8));
			        constexpr.ASSUME(result.SByte9  == (sbyte)((sbyte)(dividend.SByte9  / divisor.SByte9)  * factor.SByte9));
			        constexpr.ASSUME(result.SByte10 == (sbyte)((sbyte)(dividend.SByte10 / divisor.SByte10) * factor.SByte10));
			        constexpr.ASSUME(result.SByte11 == (sbyte)((sbyte)(dividend.SByte11 / divisor.SByte11) * factor.SByte11));
			        constexpr.ASSUME(result.SByte12 == (sbyte)((sbyte)(dividend.SByte12 / divisor.SByte12) * factor.SByte12));
			        constexpr.ASSUME(result.SByte13 == (sbyte)((sbyte)(dividend.SByte13 / divisor.SByte13) * factor.SByte13));
			        constexpr.ASSUME(result.SByte14 == (sbyte)((sbyte)(dividend.SByte14 / divisor.SByte14) * factor.SByte14));
			        constexpr.ASSUME(result.SByte15 == (sbyte)((sbyte)(dividend.SByte15 / divisor.SByte15) * factor.SByte15));
			        constexpr.ASSUME(result.SByte16 == (sbyte)((sbyte)(dividend.SByte16 / divisor.SByte16) * factor.SByte16));
			        constexpr.ASSUME(result.SByte17 == (sbyte)((sbyte)(dividend.SByte17 / divisor.SByte17) * factor.SByte17));
			        constexpr.ASSUME(result.SByte18 == (sbyte)((sbyte)(dividend.SByte18 / divisor.SByte18) * factor.SByte18));
			        constexpr.ASSUME(result.SByte19 == (sbyte)((sbyte)(dividend.SByte19 / divisor.SByte19) * factor.SByte19));
			        constexpr.ASSUME(result.SByte20 == (sbyte)((sbyte)(dividend.SByte20 / divisor.SByte20) * factor.SByte20));
			        constexpr.ASSUME(result.SByte21 == (sbyte)((sbyte)(dividend.SByte21 / divisor.SByte21) * factor.SByte21));
			        constexpr.ASSUME(result.SByte22 == (sbyte)((sbyte)(dividend.SByte22 / divisor.SByte22) * factor.SByte22));
			        constexpr.ASSUME(result.SByte23 == (sbyte)((sbyte)(dividend.SByte23 / divisor.SByte23) * factor.SByte23));
			        constexpr.ASSUME(result.SByte24 == (sbyte)((sbyte)(dividend.SByte24 / divisor.SByte24) * factor.SByte24));
			        constexpr.ASSUME(result.SByte25 == (sbyte)((sbyte)(dividend.SByte25 / divisor.SByte25) * factor.SByte25));
			        constexpr.ASSUME(result.SByte26 == (sbyte)((sbyte)(dividend.SByte26 / divisor.SByte26) * factor.SByte26));
			        constexpr.ASSUME(result.SByte27 == (sbyte)((sbyte)(dividend.SByte27 / divisor.SByte27) * factor.SByte27));
			        constexpr.ASSUME(result.SByte28 == (sbyte)((sbyte)(dividend.SByte28 / divisor.SByte28) * factor.SByte28));
			        constexpr.ASSUME(result.SByte29 == (sbyte)((sbyte)(dividend.SByte29 / divisor.SByte29) * factor.SByte29));
			        constexpr.ASSUME(result.SByte30 == (sbyte)((sbyte)(dividend.SByte30 / divisor.SByte30) * factor.SByte30));
			        constexpr.ASSUME(result.SByte31 == (sbyte)((sbyte)(dividend.SByte31 / divisor.SByte31) * factor.SByte31));

			        constexpr.ASSUME(quotient.SByte0  == (sbyte)(dividend.SByte0  / divisor.SByte0));
			        constexpr.ASSUME(quotient.SByte1  == (sbyte)(dividend.SByte1  / divisor.SByte1));
			        constexpr.ASSUME(quotient.SByte2  == (sbyte)(dividend.SByte2  / divisor.SByte2));
			        constexpr.ASSUME(quotient.SByte3  == (sbyte)(dividend.SByte3  / divisor.SByte3));
			        constexpr.ASSUME(quotient.SByte4  == (sbyte)(dividend.SByte4  / divisor.SByte4));
			        constexpr.ASSUME(quotient.SByte5  == (sbyte)(dividend.SByte5  / divisor.SByte5));
			        constexpr.ASSUME(quotient.SByte6  == (sbyte)(dividend.SByte6  / divisor.SByte6));
			        constexpr.ASSUME(quotient.SByte7  == (sbyte)(dividend.SByte7  / divisor.SByte7));
			        constexpr.ASSUME(quotient.SByte8  == (sbyte)(dividend.SByte8  / divisor.SByte8));
			        constexpr.ASSUME(quotient.SByte9  == (sbyte)(dividend.SByte9  / divisor.SByte9));
			        constexpr.ASSUME(quotient.SByte10 == (sbyte)(dividend.SByte10 / divisor.SByte10));
			        constexpr.ASSUME(quotient.SByte11 == (sbyte)(dividend.SByte11 / divisor.SByte11));
			        constexpr.ASSUME(quotient.SByte12 == (sbyte)(dividend.SByte12 / divisor.SByte12));
			        constexpr.ASSUME(quotient.SByte13 == (sbyte)(dividend.SByte13 / divisor.SByte13));
			        constexpr.ASSUME(quotient.SByte14 == (sbyte)(dividend.SByte14 / divisor.SByte14));
			        constexpr.ASSUME(quotient.SByte15 == (sbyte)(dividend.SByte15 / divisor.SByte15));
			        constexpr.ASSUME(quotient.SByte16 == (sbyte)(dividend.SByte16 / divisor.SByte16));
			        constexpr.ASSUME(quotient.SByte17 == (sbyte)(dividend.SByte17 / divisor.SByte17));
			        constexpr.ASSUME(quotient.SByte18 == (sbyte)(dividend.SByte18 / divisor.SByte18));
			        constexpr.ASSUME(quotient.SByte19 == (sbyte)(dividend.SByte19 / divisor.SByte19));
			        constexpr.ASSUME(quotient.SByte20 == (sbyte)(dividend.SByte20 / divisor.SByte20));
			        constexpr.ASSUME(quotient.SByte21 == (sbyte)(dividend.SByte21 / divisor.SByte21));
			        constexpr.ASSUME(quotient.SByte22 == (sbyte)(dividend.SByte22 / divisor.SByte22));
			        constexpr.ASSUME(quotient.SByte23 == (sbyte)(dividend.SByte23 / divisor.SByte23));
			        constexpr.ASSUME(quotient.SByte24 == (sbyte)(dividend.SByte24 / divisor.SByte24));
			        constexpr.ASSUME(quotient.SByte25 == (sbyte)(dividend.SByte25 / divisor.SByte25));
			        constexpr.ASSUME(quotient.SByte26 == (sbyte)(dividend.SByte26 / divisor.SByte26));
			        constexpr.ASSUME(quotient.SByte27 == (sbyte)(dividend.SByte27 / divisor.SByte27));
			        constexpr.ASSUME(quotient.SByte28 == (sbyte)(dividend.SByte28 / divisor.SByte28));
			        constexpr.ASSUME(quotient.SByte29 == (sbyte)(dividend.SByte29 / divisor.SByte29));
			        constexpr.ASSUME(quotient.SByte30 == (sbyte)(dividend.SByte30 / divisor.SByte30));
			        constexpr.ASSUME(quotient.SByte31 == (sbyte)(dividend.SByte31 / divisor.SByte31));
                }

                return result;
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

                constexpr.ASSUME_DIVISION_EPU8(quotients, dividend, divisor, elements);
                constexpr.ASSUME_REMAINDER_EPU8(remainder, dividend, divisor, elements);
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
                
                constexpr.ASSUME_DIVISION_EPU8(quotients, dividend, divisor);
                constexpr.ASSUME_REMAINDER_EPU8(remainder, dividend, divisor);
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

                v128 quotients = SIGNED_FROM_UNSIGNED_DIV_EPI8(out remainder, dividend, divisor, unsignedQuotient, unsignedRemainder, elements);
                
                constexpr.ASSUME_DIVISION_EPI8(quotients, dividend, divisor, elements);
                constexpr.ASSUME_REMAINDER_EPI8(remainder, dividend, divisor, elements);
                return quotients;
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

                v256 quotients = SIGNED_FROM_UNSIGNED_DIV_EPI8(out remainder, dividend, divisor, unsignedQuotient, unsignedRemainders);

                constexpr.ASSUME_DIVISION_EPI8(quotients, dividend, divisor);
                constexpr.ASSUME_REMAINDER_EPI8(remainder, dividend, divisor);
                return quotients;
            }
            else throw new IllegalInstructionException();
        }
    }
}