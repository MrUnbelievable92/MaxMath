using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu8(v128 dividend, v128 divisor, byte elements = 16) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.div_epu8(dividend, divisor, elements);
                }


                if (elements > 8)
                {
                    return DivBitwise(dividend, divisor);
                }
                else if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epu16_ps(cvtepu8_epi16(dividend), out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(cvtepu8_epi16(divisor),  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);
                    
                    v128 shorts = Sse2.packs_epi32(intsLo, intsHi);
                    
                    return Sse2.packus_epi16(shorts, shorts);
                }   
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu8_ps(dividend), cvtepu8_ps(divisor));
                    
                    if (Ssse3.IsSsse3Supported)
                    {
                        return cvtepi32_epi8(ints, elements);
                    }
                    else
                    {
                        v128 shorts = Sse2.packs_epi32(ints, ints);
                        return Sse2.packus_epi16(shorts, shorts);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi8(v128 dividend, v128 divisor, bool saturated = false, byte elements = 16) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor) && !saturated)
                {
                    return constexpr.div_epi8(dividend, divisor, elements);
                }


                if (elements > 8)
                {
                    v128 quotients = DivBitwiseSigned(dividend, divisor);

                    if (saturated)
                    {
                        v128 MIN_VALUE = Sse2.set1_epi8(sbyte.MinValue);
                        
                        v128 overflow = Sse2.and_si128(Sse2.cmpeq_epi8(dividend, MIN_VALUE), Sse2.cmpeq_epi8(divisor, setall_si128()));

                        return Sse2.add_epi8(quotients, overflow);
                    }
                    else
                    {
                        return quotients;
                    }
                }
                else if (elements > 4)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 left = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepi8_epi32(dividend));
                        v256 right = Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepi8_epi32(divisor));
                        v256 result32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left, right);

                        if (saturated)
                        {
                            v128 hi = Avx2.mm256_extracti128_si256(result32, 1);
                            v128 _16 = Sse2.packs_epi32(Avx.mm256_castsi256_si128(result32), hi);

                            return Sse2.packs_epi16(_16, _16);
                        }
                        else
                        {
                            return mm256_cvtepi32_epi8(result32);
                        }
                    }
                    else
                    {
                        v128 leftLo  = cvt2x2epi16_ps(cvtepi8_epi16(dividend), out v128 leftHi);
                        v128 rightLo = cvt2x2epi16_ps(cvtepi8_epi16(divisor),  out v128 rightHi);
                        v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                        v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);
                        
                        v128 shorts = Sse2.packs_epi32(intsLo, intsHi);

                        if (saturated)
                        {
                            return Sse2.packs_epi16(shorts, shorts);
                        }
                        else
                        {
                            return cvtepi16_epi8(shorts, elements);
                        }
                    }

                }   
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(cvtepi8_epi32(dividend)), Sse2.cvtepi32_ps(cvtepi8_epi32(divisor)));
                    
                    if (saturated)
                    {
                        v128 shorts = Sse2.packs_epi32(ints, ints);
                        return Sse2.packs_epi16(shorts, shorts);
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
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.mm256_div_epu8(dividend, divisor);
                }
                

                return DivBitwise(dividend, divisor);
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi8(v256 dividend, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(divisor) && !saturated)
                {
                    return constexpr.mm256_div_epi8(dividend, divisor);
                }


                v256 result = DivBitwiseSigned(dividend, divisor);

                if (saturated)
                {
                    v256 MIN_VALUE = Avx.mm256_set1_epi8(unchecked((byte)sbyte.MinValue));
                    
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
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.rem_epu8(dividend, divisor, elements);
                }


                if (elements > 8)
                {
                    return RemBitwise(dividend, divisor, 16);
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepu8_epi16(dividend);
                    v128 castDivisor = cvtepu8_epi16(divisor);
                    v128 leftLo  = cvt2x2epu16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(castDivisor,  out v128 rightHi);
                    v128 quotientsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 quotientsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);
                    
                    v128 quotients16 = Sse2.packs_epi32(quotientsLo, quotientsHi);
                    v128 rem16 = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));
                    
                    return Sse2.packus_epi16(rem16, rem16);
                }   
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 castDividend = cvtepu8_epi32(dividend);
                        v128 castDivisor = cvtepu8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(castDividend), Sse2.cvtepi32_ps(castDivisor));
                        v128 rem32 = Sse2.sub_epi32(castDividend, Sse4_1.mullo_epi32(castDivisor, quotients32));

                        return cvtepi32_epi8(rem32, elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepu8_epi16(dividend);
                        v128 castDivisor = cvtepu8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu16_ps(castDividend), cvtepu16_ps(castDivisor));
                        v128 quotients16 = Sse2.packs_epi32(quotients32, quotients32);
                        v128 rem16 = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));

                        return Sse2.packus_epi16(rem16, rem16);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi8(v128 dividend, v128 divisor, byte elements = 16) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.rem_epi8(dividend, divisor, elements);
                }


                if (elements > 8)
                {
                    return RemBitwiseSigned(dividend, divisor);
                }
                else if (elements > 4)
                {
                    v128 castDividend = cvtepi8_epi16(dividend);
                    v128 castDivisor = cvtepi8_epi16(divisor);
                    v128 leftLo  = cvt2x2epi16_ps(castDividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(castDivisor,  out v128 rightHi);
                    v128 quotientsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 quotientsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);
                    
                    v128 quotients16 = Sse2.packs_epi32(quotientsLo, quotientsHi);
                    v128 rem16 = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));
                    
                    return Sse2.packs_epi16(rem16, rem16);
                }   
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 castDividend = cvtepi8_epi32(dividend);
                        v128 castDivisor = cvtepi8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(castDividend), Sse2.cvtepi32_ps(castDivisor));
                        v128 rem32 = Sse2.sub_epi32(castDividend, Sse4_1.mullo_epi32(castDivisor, quotients32));

                        return cvtepi32_epi8(rem32, elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepi8_epi16(dividend);
                        v128 castDivisor = cvtepi8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(cvtepi16_epi32(castDividend)), Sse2.cvtepi32_ps(cvtepi16_epi32(castDivisor)));
                        v128 quotients16 = Sse2.packs_epi32(quotients32, quotients32);
                        v128 rem16 = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));

                        return Sse2.packs_epi16(rem16, rem16);
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
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.mm256_rem_epu8(dividend, divisor);
                }


                return RemBitwise(dividend, divisor);
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi8(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.mm256_rem_epi8(dividend, divisor);
                }


                return RemBitwiseSigned(dividend, divisor);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu8(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.rem_epu8(dividend, divisor, elements);
                    return constexpr.div_epu8(dividend, divisor, elements);
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
                    
                    v128 quotients16 = Sse2.packs_epi32(quotientsLo, quotientsHi);
                    remainder = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));
                    remainder = Sse2.packus_epi16(remainder, remainder);
                    
                    return Sse2.packus_epi16(quotients16, quotients16);
                }   
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 castDividend = cvtepu8_epi32(dividend);
                        v128 castDivisor = cvtepu8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(castDividend, castDivisor);
                        v128 rem32 = Sse2.sub_epi32(castDividend, Sse4_1.mullo_epi32(castDivisor, quotients32));

                        remainder = cvtepi32_epi8(quotients32);
                        return cvtepi32_epi8(rem32, elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepu8_epi16(dividend);
                        v128 castDivisor = cvtepu8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu16_ps(castDividend), cvtepu16_ps(castDivisor));
                        v128 quotients16 = Sse2.packs_epi32(quotients32, quotients32);
                        remainder = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));
                        remainder = Sse2.packus_epi16(remainder, remainder);

                        return Sse2.packus_epi16(quotients16, quotients16);
                    }
                    
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi8(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.rem_epi8(dividend, divisor, elements);
                    return constexpr.div_epi8(dividend, divisor, elements);
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
                    
                    v128 quotients16 = Sse2.packs_epi32(quotientsLo, quotientsHi);
                    remainder = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));
                    remainder = Sse2.packs_epi16(remainder, remainder);
                    
                    return Sse2.packs_epi16(quotients16, quotients16);
                }   
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 castDividend = cvtepi8_epi32(dividend);
                        v128 castDivisor = cvtepi8_epi32(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(castDividend), Sse2.cvtepi32_ps(castDivisor));
                        v128 rem32 = Sse2.sub_epi32(castDividend, Sse4_1.mullo_epi32(castDivisor, quotients32));
                        remainder = cvtepi32_epi8(rem32, elements);

                        return cvtepi32_epi8(quotients32, elements);
                    }
                    else
                    {
                        v128 castDividend = cvtepi8_epi16(dividend);
                        v128 castDivisor = cvtepi8_epi16(divisor);
                        v128 quotients32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(cvtepi16_epi32(castDividend)), Sse2.cvtepi32_ps(cvtepi16_epi32(castDivisor)));
                        v128 quotients16 = Sse2.packs_epi32(quotients32, quotients32);
                        remainder = Sse2.sub_epi16(castDividend, Sse2.mullo_epi16(castDivisor, quotients16));
                        remainder = Sse2.packs_epi16(remainder, remainder);
                        
                        return Sse2.packs_epi16(quotients16, quotients16);
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
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.mm256_rem_epu8(dividend, divisor);
                    return constexpr.mm256_div_epu8(dividend, divisor);
                }


                return DivRemBitwise(dividend, divisor, out remainder);
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi8(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.mm256_rem_epi8(dividend, divisor);
                    return constexpr.mm256_div_epi8(dividend, divisor);
                }


                return DivRemBitwiseSigned(dividend, divisor, out remainder);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi16(v128 dividend, v128 divisor, bool saturated = false, byte elements = 8) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor) && !saturated)
                {
                    return constexpr.div_epi16(dividend, divisor, elements);
                }


                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epi16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epi16_ps(divisor,  out v128 rightHi);
                    v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (saturated)
                    {
                        return Sse2.packs_epi32(intsLo, intsHi);
                    }
                    else
                    {
                        return cvt2x2epi32_epi16(intsLo, intsHi);
                    }
                }   
                else
                {
                    v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Sse2.cvtepi32_ps(cvtepi16_epi32(dividend)), Sse2.cvtepi32_ps(cvtepi16_epi32(divisor)));
                    
                    if (saturated || (constexpr.ALL_GT_EPI16(dividend, ushort.MinValue, elements) || constexpr.ALL_NEQ_EPI16(divisor, -1, elements)))
                    {
                        return Sse2.packs_epi32(ints, ints);
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
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.div_epu16(dividend, divisor, elements);
                }


                if (elements > 4)
                {
                    v128 leftLo  = cvt2x2epu16_ps(dividend, out v128 leftHi);
                    v128 rightLo = cvt2x2epu16_ps(divisor, out v128 rightHi);

                    v128 qLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                    v128 qHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.packus_epi32(qLo, qHi);
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
                        return Sse4_1.packus_epi32(ints, ints);
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
        public static v256 mm256_div_epi16(v256 dividend, v256 divisor, bool saturated = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(divisor) && !saturated)
                {
                    return constexpr.mm256_div_epi16(dividend, divisor);
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
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.mm256_div_epu16(dividend, divisor);
                }


                v256 dividendLo = mm256_cvt2x2epu16_ps(dividend, out v256 dividendHi);
                v256 divisorLo  = mm256_cvt2x2epu16_ps(divisor,  out v256 divisorHi);

                v256 lo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendLo, divisorLo);
                v256 hi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(dividendHi, divisorHi);

                return Avx2.mm256_packus_epi32(lo, hi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi16(v128 dividend, v128 divisor, byte elements = 8) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.rem_epi16(dividend, divisor, elements);
                }

                
                v128 quotient = div_epi16(dividend, divisor, false, elements);

                return Sse2.sub_epi16(dividend, Sse2.mullo_epi16(quotient, divisor)); 
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu16(v128 dividend, v128 divisor, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.rem_epu16(dividend, divisor, elements);
                }

                
                v128 quotient = div_epu16(dividend, divisor, elements);

                return Sse2.sub_epi16(dividend, Sse2.mullo_epi16(quotient, divisor)); 
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi16(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.mm256_rem_epi16(dividend, divisor);
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
                if (Constant.IsConstantExpression(divisor))
                {
                    return constexpr.mm256_rem_epu16(dividend, divisor);
                }

                
                v256 quotient = mm256_div_epu16(dividend, divisor);

                return Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi16(v128 dividend, v128 divisor, out v128 remainder, byte elements = 8) 
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.rem_epi16(dividend, divisor, elements);
                    return constexpr.div_epi16(dividend, divisor, elements);
                }

                
                v128 quotient = div_epi16(dividend, divisor, false, elements);
                remainder = Sse2.sub_epi16(dividend, Sse2.mullo_epi16(quotient, divisor)); 
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu16(v128 dividend, v128 divisor, out v128 remainder, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.rem_epu16(dividend, divisor, elements);
                    return constexpr.div_epu16(dividend, divisor, elements);
                }

                
                v128 quotient = div_epu16(dividend, divisor, elements);
                remainder = Sse2.sub_epi16(dividend, Sse2.mullo_epi16(quotient, divisor)); 
                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi16(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.mm256_rem_epi16(dividend, divisor);
                    return constexpr.mm256_div_epi16(dividend, divisor);
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
                if (Constant.IsConstantExpression(divisor))
                {
                    remainder = constexpr.mm256_rem_epu16(dividend, divisor);
                    return constexpr.mm256_div_epu16(dividend, divisor);
                }

                
                v256 quotient = mm256_div_epu16(dividend, divisor);
                remainder = Avx2.mm256_sub_epi16(dividend, Avx2.mm256_mullo_epi16(quotient, divisor)); 
                return quotient;
            }
            else throw new IllegalInstructionException();
        }
    }
}