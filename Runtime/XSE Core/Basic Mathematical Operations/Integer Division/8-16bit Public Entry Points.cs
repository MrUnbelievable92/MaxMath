using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu8(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constdiv_epu8(dividend, divisor, elements);
                }

                if (Architecture.IsTableLookupSupported)
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

                if (elements > 8)
                {
                    return DivRemBitwise(dividend, divisor, out _, 16);
                }
                else if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epu16_ps(cvtepu8_epi16(dividend), out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(cvtepu8_epi16(divisor),  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

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
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu8_ps(dividend), cvtepu8_ps(divisor));

                    if (Architecture.IsTableLookupSupported)
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
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor) && !saturated)
                {
                    return constdiv_epi8(dividend, divisor, elements);
                }

                if (elements > 8)
                {
                    v128 quotients = DivRemBitwiseSigned(dividend, divisor, out _, 16);

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
                else if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epi16_ps(cvtepi8_epi16(dividend), out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(cvtepi8_epi16(divisor),  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);
                    
                    if (saturated)
                    {
                        v128 shorts = packs_epi32(intsLo, intsHi);
                        return packs_epi16(shorts, shorts);
                    }
                    else
                    {
                        if (Sse2.IsSse2Supported)
                        {
                            v128 shorts = packs_epi32(intsLo, intsHi);
                            return cvtepi16_epi8(shorts, elements);
                        }
                        else
                        {
                            return unpacklo_epi32(cvtepi32_epi8(intsLo), cvtepi32_epi8(intsHi));
                        }
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi8_ps(dividend), cvtepi8_ps(divisor));

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

                return DivRemBitwise(dividend, divisor, out _);
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


                v256 result = DivRemBitwiseSigned(dividend, divisor, out _);

                if (saturated)
                {
                    v256 MIN_VALUE = mm256_set1_epi8(sbyte.MinValue);

                    v256 overflow = Avx2.mm256_cmpeq_epi8(dividend, MIN_VALUE);
                    overflow = Avx2.mm256_and_si256(overflow, Avx2.mm256_cmpeq_epi8(divisor, mm256_setall_si256()));

                    return Avx2.mm256_add_epi8(result, overflow);
                }
                else
                {
                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu8(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constrem_epu8(dividend, divisor, elements);
                }

                if (Architecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU8(divisor, 16, elements))
                    {
                        if (elements <= 8)
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16, elements);
                
                            return Divider<byte>.bmrem_epu8(dividend, divisor, mul16, elements);
                        }
                        else
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16Lo, out v128 mul16Hi);
                
                            return Divider<byte>.bmrem_epu8(dividend, divisor, mul16Lo, mul16Hi);
                        }
                    }
                }

                if (elements > 8)
                {
                    DivRemBitwise(dividend, divisor, out v128 result, 16);

                    return result;
                }
                else
                {
                    v128 result;

                    if (elements > 4)
                    {
                        v128 castDividend = cvtepu8_epi16(dividend);
                        v128 castDivisor = cvtepu8_epi16(divisor);
                        v128 leftLo  = cvt2x2epu16_ps(castDividend, out v128 leftHi);
                        v128 rightLo = cvt2x2epu16_ps(castDivisor,  out v128 rightHi);
                        v128 quotientsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                        v128 quotientsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                        v128 quotients16 = packs_epi32(quotientsLo, quotientsHi);
                        v128 rem16 = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));

                        result = packus_epi16(rem16, rem16);
                    }
                    else if (Architecture.IsMul32Supported)
                    {
                        v128 castDividend = cvtepu8_epi32(dividend);
                        v128 castDivisor = cvtepu8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(castDividend), cvtepi32_ps(castDivisor));
                        v128 rem32 = sub_epi32(castDividend, mullo_epi32(castDivisor, quotients32));

                        result = cvtepi32_epi8(rem32, elements);
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        v128 castDividend = cvtepu8_epi16(dividend);
                        v128 castDivisor = cvtepu8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu16_ps(castDividend), cvtepu16_ps(castDivisor));
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        v128 rem16 = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));

                        result = packus_epi16(rem16, rem16);
                    }
                    else throw new IllegalInstructionException();

                    constexpr.ASSUME_LT_EPU8(result, divisor, elements);
                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi8(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constrem_epi8(dividend, divisor, elements);
                }


                if (elements > 8)
                {
                    DivRemBitwiseSigned(dividend, divisor, out v128 result, 16);

                    return result;
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepi8_epi16(dividend);
                    v128 castDivisor = cvtepi8_epi16(divisor);
                    v128 leftLo  = cvt2x2epi16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(castDivisor,  out v128 rightHi);
                    v128 quotientsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 quotientsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    v128 quotients16 = packs_epi32(quotientsLo, quotientsHi);
                    v128 rem16 = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));

                    return packs_epi16(rem16, rem16);
                }
                else
                {
                    if (Architecture.IsMul32Supported)
                    {
                        v128 castDividend = cvtepi8_epi32(dividend);
                        v128 castDivisor = cvtepi8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(castDividend), cvtepi32_ps(castDivisor));
                        v128 rem32 = sub_epi32(castDividend, mullo_epi32(castDivisor, quotients32));

                        return cvtepi32_epi8(rem32, elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepi8_epi16(dividend);
                        v128 castDivisor = cvtepi8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(cvtepi16_epi32(castDividend)), cvtepi32_ps(cvtepi16_epi32(castDivisor)));
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        v128 rem16 = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));

                        return packs_epi16(rem16, rem16);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu8(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constrem_epu8(dividend, divisor);
                }

                if (constexpr.ALL_LE_EPU8(divisor, 16))
                {
                    Divider<byte>.mm256_bminitLE16_epu8(divisor, out v256 mul16Lo, out v256 mul16Hi);

                    return Divider<byte>.mm256_bmrem_epu8(dividend, divisor, mul16Lo, mul16Hi);
                }

                DivRemBitwise(dividend, divisor, out v256 result);
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


                DivRemBitwiseSigned(dividend, divisor, out v256 result);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu8(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epu8(dividend, divisor, elements);
                    return constdiv_epu8(dividend, divisor, elements);
                }

                if (Architecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU8(divisor, 16, elements))
                    {
                        if (elements <= 8)
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16, elements);

                            remainder = Divider<byte>.bmrem_epu8(dividend, divisor, mul16, elements);
                            return Divider<byte>.bmdiv_epu8(dividend, divisor, mul16, Promise.Nothing, elements);
                        }
                        else
                        {
                            Divider<byte>.bminitLE16_epu8(divisor, out v128 mul16Lo, out v128 mul16Hi);

                            remainder = Divider<byte>.bmrem_epu8(dividend, divisor, mul16Lo, mul16Hi);
                            return Divider<byte>.bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing);
                        }
                    }
                }

                if (elements > 8)
                {
                    return DivRemBitwise(dividend, divisor, out remainder, elements);
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepu8_epi16(dividend);
                    v128 castDivisor = cvtepu8_epi16(divisor);
                    v128 leftLo  = cvt2x2epu16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(castDivisor,  out v128 rightHi);
                    v128 quotientsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 quotientsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    v128 quotients16 = packs_epi32(quotientsLo, quotientsHi);
                    remainder = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));
                    remainder = packus_epi16(remainder, remainder);
                    
                    constexpr.ASSUME_LT_EPU8(remainder, divisor, elements);
                    return packus_epi16(quotients16, quotients16);
                }
                else
                {
                    if (Architecture.IsMul32Supported)
                    {
                        v128 castDividend = cvtepu8_epi32(dividend);
                        v128 castDivisor = cvtepu8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(castDividend), cvtepi32_ps(castDivisor));
                        v128 rem32 = sub_epi32(castDividend, mullo_epi32(castDivisor, quotients32));

                        remainder = cvtepi32_epi8(rem32);
                        constexpr.ASSUME_LT_EPU8(remainder, divisor, elements);
                        return cvtepi32_epi8(quotients32, elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepu8_epi16(dividend);
                        v128 castDivisor = cvtepu8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu16_ps(castDividend), cvtepu16_ps(castDivisor));
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        remainder = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));
                        remainder = packus_epi16(remainder, remainder);
                        
                        constexpr.ASSUME_LT_EPU8(remainder, divisor, elements);
                        return packus_epi16(quotients16, quotients16);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi8(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epi8(dividend, divisor, elements);
                    return constdiv_epi8(dividend, divisor, elements);
                }


                if (elements > 8)
                {
                    return DivRemBitwiseSigned(dividend, divisor, out remainder);
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepi8_epi16(dividend);
                    v128 castDivisor = cvtepi8_epi16(divisor);
                    v128 leftLo  = cvt2x2epi16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(castDivisor,  out v128 rightHi);
                    v128 quotientsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 quotientsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    v128 quotients16 = packs_epi32(quotientsLo, quotientsHi);
                    remainder = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));
                    remainder = packs_epi16(remainder, remainder);

                    if (constexpr.ALL_GT_EPI8(dividend, sbyte.MinValue, elements) || constexpr.ALL_NEQ_EPI8(dividend, -1, elements))
                    {
                        return packs_epi16(quotients16, quotients16);
                    }
                    else
                    {
                        return cvtepi16_epi8(quotients16);
                    }
                }
                else
                {
                    if (Architecture.IsMul32Supported)
                    {
                        v128 castDividend = cvtepi8_epi32(dividend);
                        v128 castDivisor = cvtepi8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(castDividend), cvtepi32_ps(castDivisor));
                        v128 rem32 = sub_epi32(castDividend, mullo_epi32(castDivisor, quotients32));
                        remainder = cvtepi32_epi8(rem32, elements);

                        return cvtepi32_epi8(quotients32, elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepi8_epi16(dividend);
                        v128 castDivisor = cvtepi8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(cvtepi16_epi32(castDividend)), cvtepi32_ps(cvtepi16_epi32(castDivisor)));
                        v128 quotients16 = packs_epi32(quotients32, quotients32);
                        remainder = sub_epi16(castDividend, mullo_epi16(castDivisor, quotients16));
                        remainder = packs_epi16(remainder, remainder);

                        if (constexpr.ALL_GT_EPI8(dividend, sbyte.MinValue, elements) || constexpr.ALL_NEQ_EPI8(dividend, -1, elements))
                        {
                            return packs_epi16(quotients16, quotients16);
                        }
                        else
                        {
                            return cvtepi16_epi8(quotients16);
                        }
                    }

                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu8(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epu8(dividend, divisor);
                    return mm256_constdiv_epu8(dividend, divisor);
                }

                if (constexpr.ALL_LE_EPU8(divisor, 16))
                {
                    Divider<byte>.mm256_bminitLE16_epu8(divisor, out v256 mul16Lo, out v256 mul16Hi);

                    remainder = Divider<byte>.mm256_bmrem_epu8(dividend, divisor, mul16Lo, mul16Hi);
                    return Divider<byte>.mm256_bmdiv_epu8(dividend, divisor, mul16Lo, mul16Hi, Promise.Nothing);
                }

                v256 quotients = DivRemBitwise(dividend, divisor, out remainder);
                constexpr.ASSUME_LT_EPU8(remainder, divisor);
                return quotients;
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


                return DivRemBitwiseSigned(dividend, divisor, out remainder);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi16(v128 dividend, v128 divisor, bool saturated = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor) && !saturated)
                {
                    return constdiv_epi16(dividend, divisor, elements);
                }


                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epi16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(divisor,  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (saturated)
                    {
                        return packs_epi32(intsLo, intsHi);
                    }
                    else
                    {
                        return cvt2x2epi32_epi16(intsLo, intsHi);
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(cvtepi16_epi32(dividend)), cvtepi32_ps(cvtepi16_epi32(divisor)));

                    if (saturated || (constexpr.ALL_GT_EPI16(dividend, ushort.MinValue, elements) || constexpr.ALL_NEQ_EPI16(divisor, -1, elements)))
                    {
                        return packs_epi32(ints, ints);
                    }
                    else
                    {
                        return cvtepi32_epi16(ints, elements);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constdiv_epu16(dividend, divisor, elements);
                }

                return impl_div_epu16(dividend, divisor, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi16(v256 dividend, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor) && !saturated)
                {
                    return mm256_constdiv_epi16(dividend, divisor);
                }


                v256 dividendLo = mm256_cvt2x2epi16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epi16_ps(divisor,  out v256 divisorHi);

                v256 lo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendLo, divisorLo);
                v256 hi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendHi, divisorHi);

                if (saturated || (constexpr.ALL_GT_EPI16(dividend, ushort.MinValue) || constexpr.ALL_NEQ_EPI16(divisor, -1)))
                {
                    return Avx2.mm256_packs_epi32(lo, hi);
                }
                else
                {
                    return mm256_cvt2x2epi32_epi16(lo, hi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constdiv_epu16(dividend, divisor);
                }

                return mm256_impl_div_epu16(dividend, divisor);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constrem_epi16(dividend, divisor, elements);
                }


                v128 quotient = div_epi16(dividend, divisor, false, elements);

                return sub_epi16(dividend, mullo_epi16(quotient, divisor));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return constrem_epu16(dividend, divisor, elements);
                }


                v128 quotient = div_epu16(dividend, divisor, elements);

                v128 result = sub_epi16(dividend, mullo_epi16(quotient, divisor));
                constexpr.ASSUME_LT_EPU16(result, divisor, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constrem_epi16(dividend, divisor);
                }


                v256 quotient = mm256_div_epi16(dividend, divisor, false);

                return Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return mm256_constrem_epu16(dividend, divisor);
                }


                v256 quotient = mm256_div_epu16(dividend, divisor);

                v256 result = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
                constexpr.ASSUME_LT_EPU16(result, divisor);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi16(v128 dividend, v128 divisor, out v128 remainder, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epi16(dividend, divisor, elements);
                    return constdiv_epi16(dividend, divisor, elements);
                }


                v128 quotient = div_epi16(dividend, divisor, false, elements);
                remainder = sub_epi16(dividend, mullo_epi16(quotient, divisor));
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu16(v128 dividend, v128 divisor, out v128 remainder, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = constrem_epu16(dividend, divisor, elements);
                    return constdiv_epu16(dividend, divisor, elements);
                }


                v128 quotient = div_epu16(dividend, divisor, elements);
                remainder = sub_epi16(dividend, mullo_epi16(quotient, divisor));
                constexpr.ASSUME_LT_EPU16(remainder, divisor, elements);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi16(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epi16(dividend, divisor);
                    return mm256_constdiv_epi16(dividend, divisor);
                }


                v256 quotient = mm256_div_epi16(dividend, divisor, false);
                remainder = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu16(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    remainder = mm256_constrem_epu16(dividend, divisor);
                    return mm256_constdiv_epu16(dividend, divisor);
                }


                v256 quotient = mm256_div_epu16(dividend, divisor);
                remainder = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
                constexpr.ASSUME_LT_EPU16(remainder, divisor);
                return quotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divadd_epu8(v128 dividend, v128 divisor, v128 summand, bool correctOverflow = true, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return add_epi8(summand, constdiv_epu8(dividend, divisor, elements));
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 8)
                    {
                        return add_epi8(summand, div_epu8(dividend, divisor, elements));
                    }
                    else if (elements > 4)
                    {
                        v128 leftLo    = cvt2x2epu16_ps(cvtepu8_epi16(dividend), out v128 leftHi);
                        v128 rightLo   = cvt2x2epu16_ps(cvtepu8_epi16(divisor),  out v128 rightHi);
                        v128 summandLo = cvt2x2epu16_ps(cvtepu8_epi16(divisor),  out v128 summandHi);
                        v128 intsLo = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(leftLo, rightLo, summandLo);
                        v128 intsHi = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(leftHi, rightHi, summandHi);

                        v128 shorts = packs_epi32(intsLo, intsHi);

                        if (correctOverflow)
                        {
                            return cvtepi16_epi8(shorts);
                        }
                        else
                        {
                            return packus_epi16(shorts, shorts);
                        }
                    }
                    else
                    {
                        v128 ints = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(cvtepu8_ps(dividend), cvtepu8_ps(divisor), cvtepu8_ps(summand));

                        return cvtepi32_epi8(ints, elements);
                    }
                }
                else
                {
                    return add_epi8(div_epu8(dividend, divisor, elements), summand);
                }
            }
            else throw new IllegalInstructionException();
        }

        /// <summary> SAFE RANGE (SUMMAND ONLY): [0, byte.MaxValue] </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfdivadd_epu16(v128 dividend, v128 divisor, v128 summand, byte elements = 8, bool correctOverflow = true)
        {
VectorAssert.IsNotGreater<ushort8, ushort>(summand, byte.MaxValue, elements);
            
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return add_epi16(summand, constdiv_epu16(dividend, divisor, elements));
                }

                return impl_usfdivadd_epu16(dividend, divisor, summand, elements, correctOverflow);
            }
            else throw new IllegalInstructionException();
        }

        /// <summary> SAFE RANGE (SUMMAND ONLY): [0, byte.MaxValue] </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfdivadd_epu16(v256 dividend, v256 divisor, v256 summand, bool correctOverflow = true)
        {
VectorAssert.IsNotGreater<ushort16, ushort>(summand, byte.MaxValue, 16);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    return Avx2.mm256_add_epi16(mm256_constdiv_epu16(dividend, divisor), summand);
                }

                return mm256_impl_usfdivadd_epu16(dividend, divisor, summand, correctOverflow);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_div_epu16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epu16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(divisor, out v128 rightHi);

                    v128 qLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 qHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return packus_epi32(qLo, qHi);
                    }
                    else
                    {
                        return cvt2x2epi32_epi16(qLo, qHi);
                    }
                }
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu16_ps(dividend), cvtepu16_ps(divisor));

                    if (Sse4_1.IsSse41Supported)
                    {
                        return packus_epi32(ints, ints);
                    }
                    else
                    {
                        return cvtepi32_epi16(ints, elements);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_div_epu16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 dividendLo = mm256_cvt2x2epu16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epu16_ps(divisor,  out v256 divisorHi);

                v256 lo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendLo, divisorLo);
                v256 hi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendHi, divisorHi);

                return Avx2.mm256_packus_epi32(lo, hi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_usfdivadd_epu16(v128 dividend, v128 divisor, v128 summand, byte elements = 8, bool correctOverflow = true)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 leftLo    = cvt2x2epu16_ps(dividend, out v128 leftHi);
                        v128 rightLo   = cvt2x2epu16_ps(divisor, out v128 rightHi);
                        v128 summandLo = cvt2x2epu16_ps(summand, out v128 summandHi);

                        v128 qLo = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(leftLo, rightLo, summandLo);
                        v128 qHi = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(leftHi, rightHi, summandHi);

                        if (correctOverflow)
                        {
                            return cvt2x2epi32_epi16(qLo, qHi);
                        }
                        else
                        {
                            return packus_epi32(qLo, qHi);
                        }
                    }
                    else
                    {
                        v128 ints = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(cvtepu16_ps(dividend), cvtepu16_ps(divisor), cvtepu16_ps(summand));

                        if (correctOverflow)
                        {
                            return cvtepi32_epi16(ints, elements);
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                return packus_epi32(ints, ints);
                            }
                            else
                            {
                                return cvtepi32_epi16(ints, elements);
                            }
                        }
                    }
                }
                else
                {
                    return add_epi16(impl_div_epu16(dividend, divisor, elements), summand);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_usfdivadd_epu16(v256 dividend, v256 divisor, v256 summand, bool correctOverflow = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 dividendLo = mm256_cvt2x2epu16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epu16_ps(divisor,  out v256 divisorHi);
                v256 summandLo  = mm256_cvt2x2epu16_ps(summand,  out v256 summandHi);

                v256 lo = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(dividendLo, divisorLo, summandLo);
                v256 hi = USFDIVADD_FLOATV_EPU16_RANGE_RET_INT(dividendHi, divisorHi, summandHi);

                if (correctOverflow)
                {
                    return mm256_cvt2x2epi32_epi16(lo, hi);
                }
                else
                {
                    return Avx2.mm256_packus_epi32(lo, hi);
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}