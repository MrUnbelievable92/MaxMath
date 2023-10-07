using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epu8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU8(b, byte.MinValue, elements))
                    {
                        return decs_epu8(a);
                    }
                    if (constexpr.ALL_EQ_EPU8(b, byte.MaxValue, elements))
                    {
                        return incs_epu8(a);
                    }
                    
                    return Sse2.sub_epi8(a, cmp_epu8(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epu8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU8(b, byte.MinValue))
                    {
                        return mm256_decs_epu8(a);
                    }
                    if (constexpr.ALL_EQ_EPU8(b, byte.MaxValue))
                    {
                        return mm256_incs_epu8(a);
                    }

                    return Avx2.mm256_sub_epi8(a, mm256_cmp_epu8(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epu16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU16(b, ushort.MinValue, elements))
                    {
                        return decs_epu16(a);
                    }
                    if (constexpr.ALL_EQ_EPU16(b, ushort.MaxValue, elements))
                    {
                        return incs_epu16(a);
                    }
                    
                    return Sse2.sub_epi16(a, cmp_epu16(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epu16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU16(b, ushort.MinValue))
                    {
                        return mm256_decs_epu16(a);
                    }
                    if (constexpr.ALL_EQ_EPU16(b, ushort.MaxValue))
                    {
                        return mm256_incs_epu16(a);
                    }

                    return Avx2.mm256_sub_epi16(a, mm256_cmp_epu16(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU32(b, uint.MinValue, elements))
                    {
                        return decs_epu32(a, elements);
                    }
                    if (constexpr.ALL_EQ_EPU32(b, uint.MaxValue, elements))
                    {
                        return incs_epu32(a, elements);
                    }
                    
                    return Sse2.sub_epi32(a, cmp_epu32(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epu32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU32(b, uint.MinValue))
                    {
                        return mm256_decs_epu32(a);
                    }
                    if (constexpr.ALL_EQ_EPU32(b, uint.MaxValue))
                    {
                        return mm256_incs_epu32(a);
                    }
                    
                    return Avx2.mm256_sub_epi32(a, mm256_cmp_epu32(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epu64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU64(b, ulong.MinValue))
                    {
                        return decs_epu64(a);
                    }
                    if (constexpr.ALL_EQ_EPU64(b, ulong.MaxValue))
                    {
                        return incs_epu64(a);
                    }
                    
                    return Sse2.sub_epi64(a, cmp_epu64(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU64(b, ulong.MinValue, elements))
                    {
                        return mm256_decs_epu64(a, elements);
                    }
                    if (constexpr.ALL_EQ_EPU64(b, ulong.MaxValue, elements))
                    {
                        return mm256_incs_epu64(a, elements);
                    }
                    
                    return Avx2.mm256_sub_epi64(a, mm256_cmp_epu64(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, sbyte.MinValue, elements))
                    {
                        return decs_epi8(a);
                    }
                    if (constexpr.ALL_EQ_EPI8(b, sbyte.MaxValue, elements))
                    {
                        return incs_epi8(a);
                    }
                    
                    return Sse2.sub_epi8(a, cmp_epi8(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, sbyte.MinValue))
                    {
                        return mm256_decs_epi8(a);
                    }
                    if (constexpr.ALL_EQ_EPI8(b, sbyte.MaxValue))
                    {
                        return mm256_incs_epi8(a);
                    }
                    
                    return Avx2.mm256_sub_epi8(a, mm256_cmp_epi8(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(b, short.MinValue, elements))
                    {
                        return decs_epi16(a);
                    }
                    if (constexpr.ALL_EQ_EPI16(b, short.MaxValue, elements))
                    {
                        return incs_epi16(a);
                    }
                    
                    return Sse2.sub_epi16(a, cmp_epi16(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epi16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(b, short.MinValue))
                    {
                        return mm256_decs_epi16(a);
                    }
                    if (constexpr.ALL_EQ_EPI16(b, short.MaxValue))
                    {
                        return mm256_incs_epi16(a);
                    }
                    
                    return Avx2.mm256_sub_epi16(a, mm256_cmp_epi16(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(b, int.MinValue, elements))
                    {
                        return decs_epi32(a, elements);
                    }
                    if (constexpr.ALL_EQ_EPI32(b, int.MaxValue, elements))
                    {
                        return incs_epi32(a, elements);
                    }
                    
                    return Sse2.sub_epi32(a, cmp_epi32(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epi32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(b, int.MinValue))
                    {
                        return mm256_decs_epi32(a);
                    }
                    if (constexpr.ALL_EQ_EPI32(b, int.MaxValue))
                    {
                        return mm256_incs_epi32(a);
                    }
                    
                    return Avx2.mm256_sub_epi32(a, mm256_cmp_epi32(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_epi64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, long.MinValue))
                    {
                        return decs_epi64(a);
                    }
                    if (constexpr.ALL_EQ_EPI64(b, long.MaxValue))
                    {
                        return incs_epi64(a);
                    }

                    return Sse2.sub_epi64(a, cmp_epi64(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, long.MinValue, elements))
                    {
                        return mm256_decs_epi64(a, elements);
                    }
                    if (constexpr.ALL_EQ_EPI64(b, long.MaxValue, elements))
                    {
                        return mm256_incs_epi64(a, elements);
                    }
                    
                    return Avx2.mm256_sub_epi64(a, mm256_cmp_epi64(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_pq(v128 a, v128 b, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    //promiseNonZero |= constexpr.ALL_NEQ_PQ(a, 0f, elements);
                    //promisePositive |= constexpr.ALL_GT_PQ(a, 0f, elements);
                    //promiseNegative |= constexpr.ALL_LT_PQ(a, 0f, elements);
                    //promiseNotNanInf |= constexpr.ALL_NOTNAN_PQ(a, elements) && constexpr.ALL_NOTNAN_PQ(b, elements) && constexpr.ALL_NEQ_PQ(a, float.PositiveInfinity, elements) && constexpr.ALL_NEQ_PQ(a, float.NegativeInfinity, elements);
                    
                    v128 ONE = Sse2.set1_epi8(1);

                    v128 isGreater = quarter.Vectorized.cmpgt_pq(a, b, promiseNeitherNaN: promiseNotNanInf, promiseNeitherZero: promiseNonZero && constexpr.ALL_NEQ_EPU8(b, 0, elements) && constexpr.ALL_NEQ_EPU8(b, 0b1000_0000, elements), elements: elements);
                    v128 areDifferent = quarter.Vectorized.cmpneq_pq(a, b, promiseNeitherNaN: promiseNotNanInf, promiseNeitherZero: promiseNonZero && constexpr.ALL_NEQ_EPU8(b, 0, elements) && constexpr.ALL_NEQ_EPU8(b, 0b1000_0000, elements), elements: elements);
                    v128 summand;
                    
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                summand = Sse4_1.blendv_epi8(ONE, setall_si128(), a);
                            }
                            else
                            {
                                summand = Sse2.or_si128(srai_epi8(a, 7), ONE);
                            }
                        }

                        if (!promiseNotNanInf)
                        {
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi8(quarter.SIGNALING_EXPONENT);

                            v128 xInfinite = Sse2.cmpeq_epi8(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            v128 eitherNaN = quarter.Vectorized.cmpunord_pq(a, b, elements);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = Sse2.or_si128(a, eitherNaN);
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = Sse2.set1_epi8(unchecked((sbyte)(1u << 7)));
                        v128 IF_ZERO = Sse2.set1_epi8(unchecked((sbyte)0x82u));

                        v128 isNegativeZero = Sse2.cmpeq_epi8(NEGATIVE_ZERO, a);
                        v128 isPositiveZero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), a);
                        v128 zeroMask = ternarylogic_si128(isNegativeZero, isPositiveZero, isGreater, TernaryOperation.Ox87);

                        summand = ternarylogic_si128(ONE, srai_epi8(a, 7), zeroMask, TernaryOperation.OxF8);
                        v128 aPart0 = ternarylogic_si128(a, isGreater, zeroMask,  TernaryOperation.OxEO);
                        v128 aPart1 = ternarylogic_si128(zeroMask, IF_ZERO, isGreater, TernaryOperation.OxO8);

                        if (promiseNotNanInf)
                        {
                            a = Sse2.or_si128(aPart0, aPart1);
                        }
                        else
                        {                                               
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi8(quarter.SIGNALING_EXPONENT);

                            v128 xInfinite = Sse2.cmpeq_epi8(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            v128 eitherNaN = quarter.Vectorized.cmpunord_pq(a, b, elements);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = ternarylogic_si128(eitherNaN, aPart0, aPart1, TernaryOperation.OxFE);
                        }
                    }

                    summand = ternarylogic_si128(isGreater, summand, areDifferent, TernaryOperation.Ox78);
                    summand = Sse2.sub_epi8(summand, isGreater);
                    
                    if (promisePositive)
                    {
                        return Sse2.sub_epi8(a, summand);
                    }
                    else
                    {
                        return Sse2.add_epi8(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_ph(v128 a, v128 b, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    //promiseNonZero |= constexpr.ALL_NEQ_PH(a, 0f, elements);
                    //promisePositive |= constexpr.ALL_GT_PH(a, 0f, elements);
                    //promiseNegative |= constexpr.ALL_LT_PH(a, 0f, elements);
                    //promiseNotNanInf |= constexpr.ALL_NOTNAN_PH(a, elements) && constexpr.ALL_NOTNAN_PH(b, elements) && constexpr.ALL_NEQ_PH(a, float.PositiveInfinity, elements) && constexpr.ALL_NEQ_PH(a, float.NegativeInfinity, elements);
                    
                    v128 ONE = Sse2.set1_epi16(1);
                    
                    v128 isGreater = cmpgt_ph(a, b, promiseNeitherNaN: promiseNotNanInf, promiseNeitherZero: promiseNonZero && constexpr.ALL_NEQ_EPU16(b, 0, elements) && constexpr.ALL_NEQ_EPU16(b, 0x8000, elements), elements: elements);
                    v128 areDifferent = cmpneq_ph(a, b, promiseNeitherNaN: promiseNotNanInf, promiseNeitherZero: promiseNonZero && constexpr.ALL_NEQ_EPU16(b, 0, elements) && constexpr.ALL_NEQ_EPU16(b, 0x8000, elements), elements: elements);
                    v128 summand;
                    
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            summand = Sse2.or_si128(Sse2.srai_epi16(a, 15), ONE);
                        }

                        if (!promiseNotNanInf)
                        {
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi16(F16_SIGNALING_EXPONENT);

                            v128 xInfinite = Sse2.cmpeq_epi16(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            v128 eitherNaN = cmpunord_ph(a, b, elements);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = Sse2.or_si128(a, eitherNaN);
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = Sse2.set1_epi16(unchecked((short)(1u << 15)));
                        v128 IF_ZERO = Sse2.set1_epi16(unchecked((short)0x8002u));

                        v128 isNegativeZero = Sse2.cmpeq_epi16(NEGATIVE_ZERO, a);
                        v128 isPositiveZero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), a);
                        v128 zeroMask = ternarylogic_si128(isNegativeZero, isPositiveZero, isGreater, TernaryOperation.Ox87);

                        summand = ternarylogic_si128(ONE, Sse2.srai_epi16(a, 15), zeroMask, TernaryOperation.OxF8);
                        v128 aPart0 = ternarylogic_si128(a, isGreater, zeroMask,  TernaryOperation.OxEO);
                        v128 aPart1 = ternarylogic_si128(zeroMask, IF_ZERO, isGreater, TernaryOperation.OxO8);

                        if (promiseNotNanInf)
                        {
                            a = Sse2.or_si128(aPart0, aPart1);
                        }
                        else
                        {                                               
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi16(F16_SIGNALING_EXPONENT);

                            v128 xInfinite = Sse2.cmpeq_epi16(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            v128 eitherNaN = cmpunord_ph(a, b, elements);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = ternarylogic_si128(eitherNaN, aPart0, aPart1, TernaryOperation.OxFE);
                        }
                    }

                    summand = ternarylogic_si128(isGreater, summand, areDifferent, TernaryOperation.Ox78);
                    summand = Sse2.sub_epi16(summand, isGreater);
                    
                    if (promisePositive)
                    {
                        return Sse2.sub_epi16(a, summand);
                    }
                    else
                    {
                        return Sse2.add_epi16(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_ps(v128 a, v128 b, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PS(a, 0f, elements);
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f, elements);
                    promiseNegative |= constexpr.ALL_LT_PS(a, 0f, elements);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PS(a, elements) && constexpr.ALL_NOTNAN_PS(b, elements) && constexpr.ALL_NEQ_PS(a, float.PositiveInfinity, elements) && constexpr.ALL_NEQ_PS(a, float.NegativeInfinity, elements);
                    
                    v128 ONE = Sse2.set1_epi32(1);

                    v128 isGreater = Sse.cmpgt_ps(a, b);
                    v128 areDifferent = Sse.cmpneq_ps(a, b);
                    v128 summand;
                    
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                summand = Sse4_1.blendv_ps(ONE, setall_si128(), a);
                            }
                            else
                            {
                                summand = Sse2.or_si128(Sse2.srai_epi32(a, 31), ONE);
                            }
                        }

                        if (!promiseNotNanInf)
                        {
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi32(F32_SIGNALING_EXPONENT);

                            v128 xInfinite = Sse2.cmpeq_epi32(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            v128 eitherNaN = Sse.cmpunord_ps(a, b);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = Sse2.or_si128(a, eitherNaN);
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = Sse2.set1_epi32(unchecked((int)(1u << 31)));
                        v128 IF_ZERO = Sse2.set1_epi32(unchecked((int)0x8000_0002u));

                        v128 isNegativeZero = Sse2.cmpeq_epi32(NEGATIVE_ZERO, a);
                        v128 isPositiveZero = Sse2.cmpeq_epi32(Sse2.setzero_si128(), a);
                        v128 zeroMask = ternarylogic_si128(isNegativeZero, isPositiveZero, isGreater, TernaryOperation.Ox87);

                        summand = ternarylogic_si128(ONE, Sse2.srai_epi32(a, 31), zeroMask, TernaryOperation.OxF8);
                        v128 aPart0 = ternarylogic_si128(a, isGreater, zeroMask,  TernaryOperation.OxEO);
                        v128 aPart1 = ternarylogic_si128(zeroMask, IF_ZERO, isGreater, TernaryOperation.OxO8);

                        if (promiseNotNanInf)
                        {
                            a = Sse2.or_si128(aPart0, aPart1);
                        }
                        else
                        {                                               
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi32(F32_SIGNALING_EXPONENT);

                            v128 xInfinite = Sse2.cmpeq_epi32(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            v128 eitherNaN = Sse.cmpunord_ps(a, b);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = ternarylogic_si128(eitherNaN, aPart0, aPart1, TernaryOperation.OxFE);
                        }
                    }

                    summand = ternarylogic_si128(isGreater, summand, areDifferent, TernaryOperation.Ox78);
                    summand = Sse2.sub_epi32(summand, isGreater);
                    
                    if (promisePositive)
                    {
                        return Sse2.sub_epi32(a, summand);
                    }
                    else
                    {
                        return Sse2.add_epi32(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_ps(v256 a, v256 b, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PS(a, 0f);
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f);
                    promiseNegative |= constexpr.ALL_LT_PS(a, 0f);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PS(a) && constexpr.ALL_NOTNAN_PS(b) && constexpr.ALL_NEQ_PS(a, float.PositiveInfinity) && constexpr.ALL_NEQ_PS(a, float.NegativeInfinity);
                    
                    v256 ONE = Avx.mm256_set1_epi32(1);

                    v256 isGreater = Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.GT_OQ);
                    v256 areDifferent = Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.NEQ_OQ);
                    v256 summand;
                    
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = mm256_setall_si256();
                        }
                        else
                        {
                            summand = Avx.mm256_blendv_ps(ONE, mm256_setall_si256(), a);
                        }

                        if (!promiseNotNanInf)
                        {
                            v256 SIGNALING_EXPONENT = Avx.mm256_set1_epi32(F32_SIGNALING_EXPONENT);

                            v256 xInfinite = Avx2.mm256_cmpeq_epi32(SIGNALING_EXPONENT, Avx2.mm256_and_si256(SIGNALING_EXPONENT, a));
                            v256 eitherNaN = Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.UNORD_Q);

                            summand = mm256_ternarylogic_si256(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = Avx2.mm256_or_si256(a, eitherNaN);
                        }
                    }
                    else
                    {
                        v256 NEGATIVE_ZERO = Avx.mm256_set1_epi32(unchecked((int)(1u << 31)));
                        v256 IF_ZERO = Avx.mm256_set1_epi32(unchecked((int)0x8000_0002u));

                        v256 isNegativeZero = Avx2.mm256_cmpeq_epi32(NEGATIVE_ZERO, a);
                        v256 isPositiveZero = Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), a);
                        v256 zeroMask = mm256_ternarylogic_si256(isNegativeZero, isPositiveZero, isGreater, TernaryOperation.Ox87);

                        summand = mm256_ternarylogic_si256(ONE, Avx2.mm256_srai_epi32(a, 31), zeroMask, TernaryOperation.OxF8);
                        v256 aPart0 = mm256_ternarylogic_si256(a, isGreater, zeroMask,  TernaryOperation.OxEO);
                        v256 aPart1 = mm256_ternarylogic_si256(zeroMask, IF_ZERO, isGreater, TernaryOperation.OxO8);

                        if (promiseNotNanInf)
                        {
                            a = Avx2.mm256_or_si256(aPart0, aPart1);
                        }
                        else
                        {                                               
                            v256 SIGNALING_EXPONENT = Avx.mm256_set1_epi32(F32_SIGNALING_EXPONENT);

                            v256 xInfinite = Avx2.mm256_cmpeq_epi32(SIGNALING_EXPONENT, Avx2.mm256_and_si256(SIGNALING_EXPONENT, a));
                            v256 eitherNaN = Avx.mm256_cmp_ps(a, b, (int)Avx.CMP.UNORD_Q);

                            summand = mm256_ternarylogic_si256(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = mm256_ternarylogic_si256(eitherNaN, aPart0, aPart1, TernaryOperation.OxFE);
                        }
                    }

                    summand = mm256_ternarylogic_si256(isGreater, summand, areDifferent, TernaryOperation.Ox78);
                    summand = Avx2.mm256_sub_epi32(summand, isGreater);
                    
                    if (promisePositive)
                    {
                        return Avx2.mm256_sub_epi32(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_add_epi32(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 toward_pd(v128 a, v128 b, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0f);
                    promisePositive |= constexpr.ALL_GT_PD(a, 0f);
                    promiseNegative |= constexpr.ALL_LT_PD(a, 0f);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PD(a) && constexpr.ALL_NOTNAN_PD(b) && constexpr.ALL_NEQ_PD(a, double.PositiveInfinity) && constexpr.ALL_NEQ_PD(a, double.NegativeInfinity);
                    
                    v128 ONE = Sse2.set1_epi64x(1);

                    v128 isGreater = Sse2.cmpgt_pd(a, b);
                    v128 areDifferent = Sse2.cmpneq_pd(a, b);
                    v128 summand;
                    
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                summand = Sse4_1.blendv_pd(ONE, setall_si128(), a);
                            }
                            else
                            {
                                summand = Sse2.or_si128(srai_epi64(a, 63), ONE);
                            }
                        }

                        if (!promiseNotNanInf)
                        {
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi64x(F64_SIGNALING_EXPONENT);

                            v128 xInfinite;
                            if (Sse4_1.IsSse41Supported)
                            {
                                xInfinite = Sse4_1.cmpeq_epi64(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            }
                            else
                            {
                                xInfinite = Sse2.shuffle_epi32(Sse2.cmpeq_epi32(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a)), Sse.SHUFFLE(3, 3, 1, 1));
                            }

                            v128 eitherNaN = Sse2.cmpunord_pd(a, b);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = Sse2.or_si128(a, eitherNaN);
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = Sse2.set1_epi64x(unchecked((long)(1ul << 63)));
                        v128 IF_ZERO = Sse2.set1_epi64x(unchecked((long)0x8000_0000_0000_0002ul));

                        v128 isNegativeZero = cmpeq_epi64(NEGATIVE_ZERO, a);
                        v128 isPositiveZero = cmpeq_epi64(Sse2.setzero_si128(), a);
                        v128 zeroMask = ternarylogic_si128(isNegativeZero, isPositiveZero, isGreater, TernaryOperation.Ox87);

                        summand = ternarylogic_si128(ONE, srai_epi64(a, 63), zeroMask, TernaryOperation.OxF8);
                        v128 aPart0 = ternarylogic_si128(a, isGreater, zeroMask,  TernaryOperation.OxEO);
                        v128 aPart1 = ternarylogic_si128(zeroMask, IF_ZERO, isGreater, TernaryOperation.OxO8);

                        if (promiseNotNanInf)
                        {
                            a = Sse2.or_si128(aPart0, aPart1);
                        }
                        else
                        {                                               
                            v128 SIGNALING_EXPONENT = Sse2.set1_epi64x(F64_SIGNALING_EXPONENT);
                            
                            v128 xInfinite;
                            if (Sse4_1.IsSse41Supported)
                            {
                                xInfinite = Sse4_1.cmpeq_epi64(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a));
                            }
                            else
                            {
                                xInfinite = Sse2.shuffle_epi32(Sse2.cmpeq_epi32(SIGNALING_EXPONENT, Sse2.and_si128(SIGNALING_EXPONENT, a)), Sse.SHUFFLE(3, 3, 1, 1));
                            }

                            v128 eitherNaN = Sse2.cmpunord_pd(a, b);

                            summand = ternarylogic_si128(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = ternarylogic_si128(eitherNaN, aPart0, aPart1, TernaryOperation.OxFE);
                        }
                    }

                    summand = ternarylogic_si128(isGreater, summand, areDifferent, TernaryOperation.Ox78);
                    summand = Sse2.sub_epi64(summand, isGreater);
                    
                    if (promisePositive)
                    {
                        return Sse2.sub_epi64(a, summand);
                    }
                    else
                    {
                        return Sse2.add_epi64(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_toward_pd(v256 a, v256 b, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0f, elements);
                    promisePositive |= constexpr.ALL_GT_PD(a, 0f, elements);
                    promiseNegative |= constexpr.ALL_LT_PD(a, 0f, elements);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PD(a, elements) && constexpr.ALL_NOTNAN_PD(b, elements) && constexpr.ALL_NEQ_PD(a, double.PositiveInfinity, elements) && constexpr.ALL_NEQ_PD(a, double.NegativeInfinity, elements);
                    
                    v256 ONE = Avx.mm256_set1_epi64x(1);

                    v256 isGreater = Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.GT_OQ);
                    v256 areDifferent = Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.NEQ_OQ);
                    v256 summand;
                    
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = mm256_setall_si256();
                        }
                        else
                        {
                            summand = Avx.mm256_blendv_pd(ONE, mm256_setall_si256(), a);
                        }

                        if (!promiseNotNanInf)
                        {
                            v256 SIGNALING_EXPONENT = Avx.mm256_set1_epi64x(F64_SIGNALING_EXPONENT);

                            v256 xInfinite = Avx2.mm256_cmpeq_epi64(SIGNALING_EXPONENT, Avx2.mm256_and_si256(SIGNALING_EXPONENT, a));
                            v256 eitherNaN = Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.UNORD_Q);

                            summand = mm256_ternarylogic_si256(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = Avx2.mm256_or_si256(a, eitherNaN);
                        }
                    }
                    else
                    {
                        v256 NEGATIVE_ZERO = Avx.mm256_set1_epi64x(unchecked((long)(1ul << 63)));
                        v256 IF_ZERO = Avx.mm256_set1_epi64x(unchecked((long)0x8000_0000_0000_0002ul));

                        v256 isNegativeZero = Avx2.mm256_cmpeq_epi64(NEGATIVE_ZERO, a);
                        v256 isPositiveZero = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), a);
                        v256 zeroMask = mm256_ternarylogic_si256(isNegativeZero, isPositiveZero, isGreater, TernaryOperation.Ox87);

                        summand = mm256_ternarylogic_si256(ONE, mm256_srai_epi64(a, 63), zeroMask, TernaryOperation.OxF8);
                        v256 aPart0 = mm256_ternarylogic_si256(a, isGreater, zeroMask,  TernaryOperation.OxEO);
                        v256 aPart1 = mm256_ternarylogic_si256(zeroMask, IF_ZERO, isGreater, TernaryOperation.OxO8);

                        if (promiseNotNanInf)
                        {
                            a = Avx2.mm256_or_si256(aPart0, aPart1);
                        }
                        else
                        {                                               
                            v256 SIGNALING_EXPONENT = Avx.mm256_set1_epi64x(F64_SIGNALING_EXPONENT);

                            v256 xInfinite = Avx2.mm256_cmpeq_epi64(SIGNALING_EXPONENT, Avx2.mm256_and_si256(SIGNALING_EXPONENT, a));
                            v256 eitherNaN = Avx.mm256_cmp_pd(a, b, (int)Avx.CMP.UNORD_Q);

                            summand = mm256_ternarylogic_si256(eitherNaN, xInfinite, summand, TernaryOperation.OxO2);
                            a = mm256_ternarylogic_si256(eitherNaN, aPart0, aPart1, TernaryOperation.OxFE);
                        }
                    }

                    summand = mm256_ternarylogic_si256(isGreater, summand, areDifferent, TernaryOperation.Ox78);
                    summand = Avx2.mm256_sub_epi64(summand, isGreater);
                    
                    if (promisePositive)
                    {
                        return Avx2.mm256_sub_epi64(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_add_epi64(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the next closest <see cref="UInt128"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 nexttoward(UInt128 from, UInt128 to)
        {
            return from - (UInt128)compareto(from, to);
        }

        
        /// <summary>       Returns the next closest <see cref="Int128"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 nexttoward(Int128 from, Int128 to)
        {
            return from - compareto(from, to);
        }


        /// <summary>       Returns the next closest <see cref="byte"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte nexttoward(byte from, byte to)
        {
            return (byte)(from - compareto(from, to));
        }

        /// <summary>       Returns a <see cref="MaxMath.byte2"/>, where each component is the next closest <see cref="byte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 nexttoward(byte2 from, byte2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu8(from, to, 2);
            }
            else
            {
                return new byte2(nexttoward(from.x, to.x),
                                 nexttoward(from.y, to.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte3"/>, where each component is the next closest <see cref="byte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 nexttoward(byte3 from, byte3 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu8(from, to, 3);
            }
            else
            {
                return new byte3(nexttoward(from.x, to.x),
                                 nexttoward(from.y, to.y),
                                 nexttoward(from.z, to.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte4"/>, where each component is the next closest <see cref="byte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 nexttoward(byte4 from, byte4 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu8(from, to, 4);
            }
            else
            {
                return new byte4(nexttoward(from.x, to.x),
                                 nexttoward(from.y, to.y),
                                 nexttoward(from.z, to.z),
                                 nexttoward(from.w, to.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte8"/>, where each component is the next closest <see cref="byte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 nexttoward(byte8 from, byte8 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu8(from, to, 8);
            }
            else
            {
                return new byte8(nexttoward(from.x0, to.x0),
                                 nexttoward(from.x1, to.x1),
                                 nexttoward(from.x2, to.x2),
                                 nexttoward(from.x3, to.x3),
                                 nexttoward(from.x4, to.x4),
                                 nexttoward(from.x5, to.x5),
                                 nexttoward(from.x6, to.x6),
                                 nexttoward(from.x7, to.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte16"/>, where each component is the next closest <see cref="byte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 nexttoward(byte16 from, byte16 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu8(from, to, 16);
            }
            else
            {
                return new byte16(nexttoward(from.x0,  to.x0),
                                  nexttoward(from.x1,  to.x1),
                                  nexttoward(from.x2,  to.x2),
                                  nexttoward(from.x3,  to.x3),
                                  nexttoward(from.x4,  to.x4),
                                  nexttoward(from.x5,  to.x5),
                                  nexttoward(from.x6,  to.x6),
                                  nexttoward(from.x7,  to.x7),
                                  nexttoward(from.x8,  to.x8),
                                  nexttoward(from.x9,  to.x9),
                                  nexttoward(from.x10, to.x10),
                                  nexttoward(from.x11, to.x11),
                                  nexttoward(from.x12, to.x12),
                                  nexttoward(from.x13, to.x13),
                                  nexttoward(from.x14, to.x14),
                                  nexttoward(from.x15, to.x15));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.byte32"/>, where each component is the next closest <see cref="byte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 nexttoward(byte32 from, byte32 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epu8(from, to);
            }
            else
            {
                return new byte32(nexttoward(from.v16_0,  to.v16_0),
                                  nexttoward(from.v16_16, to.v16_16));
            }
        }


        /// <summary>       Returns the next closest <see cref="sbyte"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte nexttoward(sbyte from, sbyte to)
        {
            return (sbyte)(from - compareto(from, to));
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte2"/>, where each component is the next closest <see cref="sbyte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 nexttoward(sbyte2 from, sbyte2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi8(from, to, 2);
            }
            else
            {
                return new sbyte2(nexttoward(from.x, to.x),
                                  nexttoward(from.y, to.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte3"/>, where each component is the next closest <see cref="sbyte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 nexttoward(sbyte3 from, sbyte3 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi8(from, to, 3);
            }
            else
            {
                return new sbyte3(nexttoward(from.x, to.x),
                                  nexttoward(from.y, to.y),
                                  nexttoward(from.z, to.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte4"/>, where each component is the next closest <see cref="sbyte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 nexttoward(sbyte4 from, sbyte4 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi8(from, to, 4);
            }
            else
            {
                return new sbyte4(nexttoward(from.x, to.x),
                                  nexttoward(from.y, to.y),
                                  nexttoward(from.z, to.z),
                                  nexttoward(from.w, to.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte8"/>, where each component is the next closest <see cref="sbyte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 nexttoward(sbyte8 from, sbyte8 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi8(from, to, 8);
            }
            else
            {
                return new sbyte8(nexttoward(from.x0, to.x0),
                                  nexttoward(from.x1, to.x1),
                                  nexttoward(from.x2, to.x2),
                                  nexttoward(from.x3, to.x3),
                                  nexttoward(from.x4, to.x4),
                                  nexttoward(from.x5, to.x5),
                                  nexttoward(from.x6, to.x6),
                                  nexttoward(from.x7, to.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte16"/>, where each component is the next closest <see cref="sbyte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 nexttoward(sbyte16 from, sbyte16 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi8(from, to, 16);
            }
            else
            {
                return new sbyte16(nexttoward(from.x0,  to.x0),
                                   nexttoward(from.x1,  to.x1),
                                   nexttoward(from.x2,  to.x2),
                                   nexttoward(from.x3,  to.x3),
                                   nexttoward(from.x4,  to.x4),
                                   nexttoward(from.x5,  to.x5),
                                   nexttoward(from.x6,  to.x6),
                                   nexttoward(from.x7,  to.x7),
                                   nexttoward(from.x8,  to.x8),
                                   nexttoward(from.x9,  to.x9),
                                   nexttoward(from.x10, to.x10),
                                   nexttoward(from.x11, to.x11),
                                   nexttoward(from.x12, to.x12),
                                   nexttoward(from.x13, to.x13),
                                   nexttoward(from.x14, to.x14),
                                   nexttoward(from.x15, to.x15));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.sbyte32"/>, where each component is the next closest <see cref="sbyte"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 nexttoward(sbyte32 from, sbyte32 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epi8(from, to);
            }
            else
            {
                return new sbyte32(nexttoward(from.v16_0,  to.v16_0),
                                   nexttoward(from.v16_16, to.v16_16));
            }
        }


        /// <summary>       Returns the next closest <see cref="ushort"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort nexttoward(ushort from, ushort to)
        {
            return (ushort)(from - compareto(from, to));
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort2"/>, where each component is the next closest <see cref="ushort"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 nexttoward(ushort2 from, ushort2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu16(from, to, 2);
            }
            else
            {
                return new ushort2(nexttoward(from.x, to.x),
                                   nexttoward(from.y, to.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort3"/>, where each component is the next closest <see cref="ushort"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 nexttoward(ushort3 from, ushort3 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu16(from, to, 3);
            }
            else
            {
                return new ushort3(nexttoward(from.x, to.x),
                                   nexttoward(from.y, to.y),
                                   nexttoward(from.z, to.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort4"/>, where each component is the next closest <see cref="ushort"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 nexttoward(ushort4 from, ushort4 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu16(from, to, 4);
            }
            else
            {
                return new ushort4(nexttoward(from.x, to.x),
                                   nexttoward(from.y, to.y),
                                   nexttoward(from.z, to.z),
                                   nexttoward(from.w, to.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort8"/>, where each component is the next closest <see cref="ushort"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 nexttoward(ushort8 from, ushort8 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu16(from, to, 8);
            }
            else
            {
                return new ushort8(nexttoward(from.x0, to.x0),
                                   nexttoward(from.x1, to.x1),
                                   nexttoward(from.x2, to.x2),
                                   nexttoward(from.x3, to.x3),
                                   nexttoward(from.x4, to.x4),
                                   nexttoward(from.x5, to.x5),
                                   nexttoward(from.x6, to.x6),
                                   nexttoward(from.x7, to.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort16"/>, where each component is the next closest <see cref="ushort"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 nexttoward(ushort16 from, ushort16 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epu16(from, to);
            }
            else
            {
                return new ushort16(nexttoward(from.v8_0, to.v8_0),
                                    nexttoward(from.v8_8, to.v8_8));
            }
        }


        /// <summary>       Returns the next closest <see cref="short"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short nexttoward(short from, short to)
        {
            return (short)(from - compareto(from, to));
        }

        /// <summary>       Returns a <see cref="MaxMath.short2"/>, where each component is the next closest <see cref="short"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 nexttoward(short2 from, short2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi16(from, to, 2);
            }
            else
            {
                return new short2(nexttoward(from.x, to.x),
                                  nexttoward(from.y, to.y));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.short3"/>, where each component is the next closest <see cref="quarter"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 nexttoward(short3 from, short3 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi16(from, to, 3);
            }
            else
            {
                return new short3(nexttoward(from.x, to.x),
                                  nexttoward(from.y, to.y),
                                  nexttoward(from.z, to.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/>, where each component is the next closest <see cref="short"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 nexttoward(short4 from, short4 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi16(from, to, 4);
            }
            else
            {
                return new short4(nexttoward(from.x, to.x),
                                  nexttoward(from.y, to.y),
                                  nexttoward(from.z, to.z),
                                  nexttoward(from.w, to.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/>, where each component is the next closest <see cref="short"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 nexttoward(short8 from, short8 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi16(from, to, 8);
            }
            else
            {
                return new short8(nexttoward(from.x0, to.x0),
                                  nexttoward(from.x1, to.x1),
                                  nexttoward(from.x2, to.x2),
                                  nexttoward(from.x3, to.x3),
                                  nexttoward(from.x4, to.x4),
                                  nexttoward(from.x5, to.x5),
                                  nexttoward(from.x6, to.x6),
                                  nexttoward(from.x7, to.x7));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.short16"/>, where each component is the next closest <see cref="short"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 nexttoward(short16 from, short16 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epi16(from, to);
            }
            else
            {
                return new short16(nexttoward(from.v8_0, to.v8_0),
                                   nexttoward(from.v8_8, to.v8_8));
            }
        }


        /// <summary>       Returns the next closest <see cref="uint"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint nexttoward(uint from, uint to)
        {
            return from - (uint)compareto(from, to);
        }

        /// <summary>       Returns a <see cref="uint2"/>, where each component is the next closest <see cref="uint"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 nexttoward(uint2 from, uint2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.toward_epu32(RegisterConversion.ToV128(from), RegisterConversion.ToV128(to), 2));
            }
            else
            {
                return new uint2(nexttoward(from.x, to.x),
                                 nexttoward(from.y, to.y));
            }
        }
        
        /// <summary>       Returns a <see cref="uint3"/>, where each component is the next closest <see cref="quarter"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 nexttoward(uint3 from, uint3 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.toward_epu32(RegisterConversion.ToV128(from), RegisterConversion.ToV128(to), 3));
            }
            else
            {
                return new uint3(nexttoward(from.x, to.x),
                                 nexttoward(from.y, to.y),
                                 nexttoward(from.z, to.z));
            }
        }

        /// <summary>       Returns a <see cref="uint4"/>, where each component is the next closest <see cref="uint"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 nexttoward(uint4 from, uint4 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.toward_epu32(RegisterConversion.ToV128(from), RegisterConversion.ToV128(to), 4));
            }
            else
            {
                return new uint4(nexttoward(from.x, to.x),
                                 nexttoward(from.y, to.y),
                                 nexttoward(from.z, to.z),
                                 nexttoward(from.w, to.w));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.uint8"/>, where each component is the next closest <see cref="uint"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 nexttoward(uint8 from, uint8 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epu32(from, to);
            }
            else
            {
                return new uint8(nexttoward(from.v4_0, to.v4_0),
                                 nexttoward(from.v4_4, to.v4_4));
            }
        }
        

        /// <summary>       Returns the next closest <see cref="int"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int nexttoward(int from, int to)
        {
            return from - compareto(from, to);
        }

        /// <summary>       Returns a <see cref="int2"/>, where each component is the next closest <see cref="int"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 nexttoward(int2 from, int2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.toward_epi32(RegisterConversion.ToV128(from), RegisterConversion.ToV128(to), 2));
            }
            else
            {
                return new int2(nexttoward(from.x, to.x),
                                nexttoward(from.y, to.y));
            }
        }

        /// <summary>       Returns a <see cref="int3"/>, where each component is the next closest <see cref="int"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 nexttoward(int3 from, int3 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.toward_epi32(RegisterConversion.ToV128(from), RegisterConversion.ToV128(to), 3));
            }
            else
            {
                return new int3(nexttoward(from.x, to.x),
                                nexttoward(from.y, to.y),
                                nexttoward(from.z, to.z));
            }
        }

        /// <summary>       Returns a <see cref="int4"/>, where each component is the next closest <see cref="int"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 nexttoward(int4 from, int4 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.toward_epi32(RegisterConversion.ToV128(from), RegisterConversion.ToV128(to), 4));
            }
            else
            {
                return new int4(nexttoward(from.x, to.x),
                                nexttoward(from.y, to.y),
                                nexttoward(from.z, to.z),
                                nexttoward(from.w, to.w));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.int8"/>, where each component is the next closest <see cref="int"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 nexttoward(int8 from, int8 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epi32(from, to);
            }
            else
            {
                return new int8(nexttoward(from.v4_0, to.v4_0),
                                nexttoward(from.v4_4, to.v4_4));
            }
        }

        
        /// <summary>       Returns the next closest <see cref="ulong"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong nexttoward(ulong from, ulong to)
        {
            return from - (ulong)compareto(from, to);
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong2"/>, where each component is the next closest <see cref="ulong"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 nexttoward(ulong2 from, ulong2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epu64(from, to);
            }
            else
            {
                return new ulong2(nexttoward(from.x, to.x),
                                  nexttoward(from.y, to.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong3"/>, where each component is the next closest <see cref="ulong"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 nexttoward(ulong3 from, ulong3 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epu64(from, to, 3);
            }
            else
            {
                return new ulong3(nexttoward(from.xy, to.xy),
                                  nexttoward(from.z,  to.z));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.ulong4"/>, where each component is the next closest <see cref="ulong"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 nexttoward(ulong4 from, ulong4 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epu64(from, to, 4);
            }
            else
            {
                return new ulong4(nexttoward(from.xy, to.xy),
                                  nexttoward(from.zw, to.zw));
            }
        }


        /// <summary>       Returns the next closest <see cref="long"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long nexttoward(long from, long to)
        {
            return from - compareto(from, to);
        }

        /// <summary>       Returns a <see cref="MaxMath.long2"/>, where each component is the next closest <see cref="long"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 nexttoward(long2 from, long2 to)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_epi64(from, to);
            }
            else
            {
                return new long2(nexttoward(from.x, to.x),
                                 nexttoward(from.y, to.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/>, where each component is the next closest <see cref="long"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 nexttoward(long3 from, long3 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epi64(from, to, 3);
            }
            else
            {
                return new long3(nexttoward(from.xy, to.xy),
                                 nexttoward(from.z,  to.z));
            }
        }
        
        /// <summary>       Returns a <see cref="MaxMath.long4"/>, where each component is the next closest <see cref="long"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 nexttoward(long4 from, long4 to)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_epi64(from, to, 4);
            }
            else
            {
                return new long4(nexttoward(from.xy, to.xy),
                                 nexttoward(from.zw, to.zw));
            }
        }


        /// <summary>       Returns the next closest <see cref="quarter"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="quarter.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter nexttoward(quarter from, quarter to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return asquarter(Xse.toward_pq(Sse2.cvtsi32_si128(from.value),
                                               Sse2.cvtsi32_si128(to.value),
                                               promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                               promiseNegative: optimizations.Promises(Promise.Negative), 
                                               promisePositive: optimizations.Promises(Promise.Positive), 
                                               promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                               elements: 1).Byte0);
            }
            else
            {
                int isGreater = -tobyte(from > to);
                int __x = assbyte(from);
                int summand;
                
                if (optimizations.Promises(Promise.NonZero))
                {
                    if (optimizations.Promises(Promise.Positive) | optimizations.Promises(Promise.Negative))
                    {
                        summand = 1;
                    }
                    else
                    {
                        summand = 1 | (__x >> 31);
                    }
                }
                else
                {
                    int zeroMask = -tobyte(__x != unchecked((int)0xFFFF_FF80)) ^ (-tobyte(__x == 0) & isGreater);
                    summand = 1 | ((__x >> 31) & zeroMask);
                    __x = (__x & (isGreater | zeroMask)) | andnot(0x82 & isGreater, zeroMask);
                }
                
                if (!optimizations.Promises(Promise.Unsafe0))
                {
                    int xNotInf = -tobyte((__x & quarter.SIGNALING_EXPONENT) != quarter.SIGNALING_EXPONENT);
                    int eitherNaN = -tobyte(((__x & 0x7F) > quarter.SIGNALING_EXPONENT) | ((assbyte(to) & 0x7F) > quarter.SIGNALING_EXPONENT));
                    summand = andnot(summand & xNotInf, eitherNaN);
                    __x |= eitherNaN;
                }

                summand = (summand ^ isGreater) - isGreater;
                summand &= -tobyte(from != to);

                if (optimizations.Promises(Promise.Negative))
                {
                    return asquarter((byte)(__x - summand));
                }
                else
                {
                    return asquarter((byte)(__x + summand));
                }
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter2"/>, where each component is the next closest <see cref="quarter"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="quarter.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 nexttoward(quarter2 from, quarter2 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_pq(from,
                                     to,
                                     promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                     promiseNegative: optimizations.Promises(Promise.Negative), 
                                     promisePositive: optimizations.Promises(Promise.Positive), 
                                     promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                     elements: 2);
            }
            else
            {
                return new quarter2(nexttoward(from.x, to.x, optimizations),
                                    nexttoward(from.y, to.y, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter3"/>, where each component is the next closest <see cref="quarter"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="quarter.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 nexttoward(quarter3 from, quarter3 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_pq(from,
                                     to,
                                     promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                     promiseNegative: optimizations.Promises(Promise.Negative), 
                                     promisePositive: optimizations.Promises(Promise.Positive), 
                                     promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                     elements: 3);
            }
            else
            {
                return new quarter3(nexttoward(from.x, to.x, optimizations),
                                    nexttoward(from.y, to.y, optimizations),
                                    nexttoward(from.z, to.z, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter4"/>, where each component is the next closest <see cref="quarter"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="quarter.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 nexttoward(quarter4 from, quarter4 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_pq(from,
                                     to,
                                     promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                     promiseNegative: optimizations.Promises(Promise.Negative), 
                                     promisePositive: optimizations.Promises(Promise.Positive), 
                                     promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                     elements: 4);
            }
            else
            {
                return new quarter4(nexttoward(from.x, to.x, optimizations),
                                    nexttoward(from.y, to.y, optimizations),
                                    nexttoward(from.z, to.z, optimizations),
                                    nexttoward(from.w, to.w, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter8"/>, where each component is the next closest <see cref="quarter"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="quarter.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 nexttoward(quarter8 from, quarter8 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_pq(from,
                                     to,
                                     promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                     promiseNegative: optimizations.Promises(Promise.Negative), 
                                     promisePositive: optimizations.Promises(Promise.Positive), 
                                     promiseNotNanInf: optimizations.Promises(Promise.Unsafe0));
            }
            else
            {
                return new quarter8(nexttoward(from.x0, to.x0, optimizations),
                                    nexttoward(from.x1, to.x1, optimizations),
                                    nexttoward(from.x2, to.x2, optimizations),
                                    nexttoward(from.x3, to.x3, optimizations),
                                    nexttoward(from.x4, to.x4, optimizations),
                                    nexttoward(from.x5, to.x5, optimizations),
                                    nexttoward(from.x6, to.x6, optimizations),
                                    nexttoward(from.x7, to.x7, optimizations));
            }
        }


        /// <summary>       Returns the next closest <see cref="half"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN aswell as any '<paramref name="to"/>' that is half.NaN.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half nexttoward(half from, half to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return ashalf(Xse.toward_ph(RegisterConversion.ToV128(from),
                                            RegisterConversion.ToV128(to),
                                            promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                            promiseNegative: optimizations.Promises(Promise.Negative), 
                                            promisePositive: optimizations.Promises(Promise.Positive), 
                                            promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                            elements: 1).UShort0);
            }
            else
            {
                int isGreater = -tobyte(from.IsGreaterThan(to));
                int __x = asshort(from);
                int summand;
                
                if (optimizations.Promises(Promise.NonZero))
                {
                    if (optimizations.Promises(Promise.Positive) | optimizations.Promises(Promise.Negative))
                    {
                        summand = 1;
                    }
                    else
                    {
                        summand = 1 | (__x >> 31);
                    }
                }
                else
                {
                    int zeroMask = -tobyte(__x != unchecked((int)0xFFFF_8000)) ^ (-tobyte(__x == 0) & isGreater);
                    summand = 1 | ((__x >> 31) & zeroMask);
                    __x = (__x & (isGreater | zeroMask)) | andnot(unchecked((int)0xFFFF_8002) & isGreater, zeroMask);
                }
                
                if (!optimizations.Promises(Promise.Unsafe0))
                {
                    int xNotInf = -tobyte((__x & F16_SIGNALING_EXPONENT) != F16_SIGNALING_EXPONENT);
                    int eitherNaN = -tobyte(((__x & 0x7FFF) > F16_SIGNALING_EXPONENT) | ((asushort(to) & 0x7FFF) > F16_SIGNALING_EXPONENT));
                    summand = andnot(summand & xNotInf, eitherNaN);
                    __x |= eitherNaN;
                }

                summand = (summand ^ isGreater) - isGreater;
                summand &= -tobyte(from.IsNotEqualTo(to));

                if (optimizations.Promises(Promise.Negative))
                {
                    return ashalf((ushort)(__x - summand));
                }
                else
                {
                    return ashalf((ushort)(__x + summand));
                }
            }
        }

        /// <summary>       Returns a <see cref="half2"/>, where each component is the next closest <see cref="half"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN aswell as any '<paramref name="to"/>' that is half.NaN.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 nexttoward(half2 from, half2 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToHalf2(Xse.toward_ph(RegisterConversion.ToV128(from),
                                                                RegisterConversion.ToV128(to),
                                                                promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                promisePositive: optimizations.Promises(Promise.Positive), 
                                                                promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                elements: 2));
            }
            else
            {
                return new half2(nexttoward(from.x, to.x, optimizations),
                                 nexttoward(from.y, to.y, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="half3"/>, where each component is the next closest <see cref="half"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN aswell as any '<paramref name="to"/>' that is half.NaN.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 nexttoward(half3 from, half3 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToHalf3(Xse.toward_ph(RegisterConversion.ToV128(from),
                                                                RegisterConversion.ToV128(to),
                                                                promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                promisePositive: optimizations.Promises(Promise.Positive), 
                                                                promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                elements: 3));
            }
            else
            {
                return new half3(nexttoward(from.x, to.x, optimizations),
                                 nexttoward(from.y, to.y, optimizations),
                                 nexttoward(from.z, to.z, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="half4"/>, where each component is the next closest <see cref="half"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN aswell as any '<paramref name="to"/>' that is half.NaN.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 nexttoward(half4 from, half4 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToHalf4(Xse.toward_ph(RegisterConversion.ToV128(from),
                                                                RegisterConversion.ToV128(to),
                                                                promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                promisePositive: optimizations.Promises(Promise.Positive), 
                                                                promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                elements: 4));
            }
            else
            {
                return new half4(nexttoward(from.x, to.x, optimizations),
                                 nexttoward(from.y, to.y, optimizations),
                                 nexttoward(from.z, to.z, optimizations),
                                 nexttoward(from.w, to.w, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.half8"/>, where each component is the next closest <see cref="half"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN aswell as any '<paramref name="to"/>' that is half.NaN.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 nexttoward(half8 from, half8 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_ph(from,
                                     to,
                                     promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                     promiseNegative: optimizations.Promises(Promise.Negative), 
                                     promisePositive: optimizations.Promises(Promise.Positive), 
                                     promiseNotNanInf: optimizations.Promises(Promise.Unsafe0));
            }
            else
            {
                return new half8(nexttoward(from.x0, to.x0, optimizations),
                                 nexttoward(from.x1, to.x1, optimizations),
                                 nexttoward(from.x2, to.x2, optimizations),
                                 nexttoward(from.x3, to.x3, optimizations),
                                 nexttoward(from.x4, to.x4, optimizations),
                                 nexttoward(from.x5, to.x5, optimizations),
                                 nexttoward(from.x6, to.x6, optimizations),
                                 nexttoward(from.x7, to.x7, optimizations));
            }
        }


        /// <summary>       Returns the next closest <see cref="float"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="float.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float nexttoward(float from, float to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_ps(RegisterConversion.ToV128(from),
                                       RegisterConversion.ToV128(to),
                                       promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                       promiseNegative: optimizations.Promises(Promise.Negative), 
                                       promisePositive: optimizations.Promises(Promise.Positive), 
                                       promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                       elements: 1).Float0;
            }
            else
            {
                int isGreater = -tobyte(from > to);
                int __x = math.asint(from);
                int summand;
                
                if (optimizations.Promises(Promise.NonZero))
                {
                    if (optimizations.Promises(Promise.Positive) | optimizations.Promises(Promise.Negative))
                    {
                        summand = 1;
                    }
                    else
                    {
                        summand = 1 | (__x >> 31);
                    }
                }
                else
                {
                    int zeroMask = -tobyte(__x != 1 << 31) ^ (-tobyte(__x == 0) & isGreater);
                    summand = 1 | ((__x >> 31) & zeroMask);
                    __x = (__x & (isGreater | zeroMask)) | (int)andnot(0x8000_0002u & isGreater, (uint)zeroMask);
                }
                
                if (!optimizations.Promises(Promise.Unsafe0))
                {
                    int xNotInf = -tobyte((__x & F32_SIGNALING_EXPONENT) != F32_SIGNALING_EXPONENT);
                    int eitherNaN = -tobyte(((__x & 0x7FFF_FFFF) > F32_SIGNALING_EXPONENT) | ((math.asint(to) & 0x7FFF_FFFF) > F32_SIGNALING_EXPONENT));
                    summand = andnot(summand & xNotInf, eitherNaN);
                    __x |= eitherNaN;
                }

                summand = (summand ^ isGreater) - isGreater;
                summand &= -tobyte(from != to);

                if (optimizations.Promises(Promise.Negative))
                {
                    return math.asfloat(__x - summand);
                }
                else
                {
                    return math.asfloat(__x + summand);
                }
            }
        }

        /// <summary>       Returns a <see cref="float2"/>, where each component is the next closest <see cref="float"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="float.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 nexttoward(float2 from, float2 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(Xse.toward_ps(RegisterConversion.ToV128(from),
                                                                   RegisterConversion.ToV128(to),
                                                                   promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                   promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                   promisePositive: optimizations.Promises(Promise.Positive), 
                                                                   promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                   elements: 2));
            }
            else
            {
                return new float2(nexttoward(from.x, to.x, optimizations),
                                  nexttoward(from.y, to.y, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="float3"/>, where each component is the next closest <see cref="float"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="float.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 nexttoward(float3 from, float3 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat3(Xse.toward_ps(RegisterConversion.ToV128(from),
                                                                   RegisterConversion.ToV128(to),
                                                                   promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                   promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                   promisePositive: optimizations.Promises(Promise.Positive), 
                                                                   promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                   elements: 3));
            }
            else
            {
                return new float3(nexttoward(from.x, to.x, optimizations),
                                  nexttoward(from.y, to.y, optimizations),
                                  nexttoward(from.z, to.z, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="float4"/>, where each component is the next closest <see cref="float"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="float.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 nexttoward(float4 from, float4 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat4(Xse.toward_ps(RegisterConversion.ToV128(from),
                                                                   RegisterConversion.ToV128(to),
                                                                   promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                   promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                   promisePositive: optimizations.Promises(Promise.Positive), 
                                                                   promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                   elements: 4));
            }
            else
            {
                return new float4(nexttoward(from.x, to.x, optimizations),
                                  nexttoward(from.y, to.y, optimizations),
                                  nexttoward(from.z, to.z, optimizations),
                                  nexttoward(from.w, to.w, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.float8"/>, where each component is the next closest <see cref="float"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="float.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 nexttoward(float8 from, float8 to, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_toward_ps(from,
                                           to,
                                           promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                           promiseNegative: optimizations.Promises(Promise.Negative), 
                                           promisePositive: optimizations.Promises(Promise.Positive), 
                                           promiseNotNanInf: optimizations.Promises(Promise.Unsafe0));
            }
            else
            {
                return new float8(nexttoward(from.v4_0, to.v4_0, optimizations),
                                  nexttoward(from.v4_4, to.v4_4, optimizations));
            }
        }


        /// <summary>       Returns the next closest <see cref="double"/> to '<paramref name="from"/>' in the direction of '<paramref name="to"/>'.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="double.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double nexttoward(double from, double to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.toward_pd(RegisterConversion.ToV128(from),
                                       RegisterConversion.ToV128(to),
                                       promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                       promiseNegative: optimizations.Promises(Promise.Negative), 
                                       promisePositive: optimizations.Promises(Promise.Positive), 
                                       promiseNotNanInf: optimizations.Promises(Promise.Unsafe0)).Double0;
            }
            else
            {
                long isGreater = -(long)tobyte(from > to);
                long __x = math.aslong(from);
                long summand;
                
                if (optimizations.Promises(Promise.NonZero))
                {
                    if (optimizations.Promises(Promise.Positive) | optimizations.Promises(Promise.Negative))
                    {
                        summand = 1;
                    }
                    else
                    {
                        summand = 1 | (__x >> 63);
                    }
                }
                else
                {
                    long zeroMask = -(long)tobyte(__x != 1L << 63) ^ (-(long)tobyte(__x == 0) & isGreater);
                    summand = 1 | ((__x >> 63) & zeroMask);
                    __x = (__x & (isGreater | zeroMask)) | (long)andnot(0x8000_0000_0000_0002ul & (ulong)isGreater, (ulong)zeroMask);
                }
                
                if (!optimizations.Promises(Promise.Unsafe0))
                {
                    long xNotInf = -(long)tobyte((__x & F64_SIGNALING_EXPONENT) != F64_SIGNALING_EXPONENT);
                    long eitherNaN = -(long)tobyte(((__x & 0x7FFF_FFFF_FFFF_FFFF) > F64_SIGNALING_EXPONENT) | ((math.aslong(to) & 0x7FFF_FFFF_FFFF_FFFF) > F64_SIGNALING_EXPONENT));
                    summand = andnot(summand & xNotInf, eitherNaN);
                    __x |= eitherNaN;
                }

                summand = (summand ^ isGreater) - isGreater;
                summand &= -(long)tobyte(from != to);

                if (optimizations.Promises(Promise.Negative))
                {
                    return math.asdouble(__x - summand);
                }
                else
                {
                    return math.asdouble(__x + summand);
                }
            }
        }

        /// <summary>       Returns a <see cref="double2"/>, where each component is the next closest <see cref="double"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="double.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 nexttoward(double2 from, double2 to, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(Xse.toward_pd(RegisterConversion.ToV128(from),
                                                                    RegisterConversion.ToV128(to),
                                                                    promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                    promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                    promisePositive: optimizations.Promises(Promise.Positive), 
                                                                    promiseNotNanInf: optimizations.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new double2(nexttoward(from.x, to.x, optimizations),
                                   nexttoward(from.y, to.y, optimizations));
            }
        }

        /// <summary>       Returns a <see cref="double3"/>, where each component is the next closest <see cref="double"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="double.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 nexttoward(double3 from, double3 to, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_toward_pd(RegisterConversion.ToV256(from),
                                                                          RegisterConversion.ToV256(to),
                                                                          promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                          promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                          promisePositive: optimizations.Promises(Promise.Positive), 
                                                                          promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                          elements: 3));
            }
            else
            {
                return new double3(nexttoward(from.xy, to.xy, optimizations),
                                   nexttoward(from.z,  to.z,  optimizations));
            }
        }

        /// <summary>       Returns a <see cref="double4"/>, where each component is the next closest <see cref="double"/> to the corresponding '<paramref name="from"/>' component in the direction of the corresponding '<paramref name="to"/>' component.     </summary>
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any '<paramref name="from"/>' that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any '<paramref name="from"/>' that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="optimizations"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any '<paramref name="from"/>' that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/> aswell as any '<paramref name="to"/>' that is <see cref="double.NaN"/>.      </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 nexttoward(double4 from, double4 to, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_toward_pd(RegisterConversion.ToV256(from),
                                                                          RegisterConversion.ToV256(to),
                                                                          promiseNonZero: optimizations.Promises(Promise.NonZero), 
                                                                          promiseNegative: optimizations.Promises(Promise.Negative), 
                                                                          promisePositive: optimizations.Promises(Promise.Positive), 
                                                                          promiseNotNanInf: optimizations.Promises(Promise.Unsafe0),
                                                                          elements: 4));
            }
            else
            {
                return new double4(nexttoward(from.xy, to.xy, optimizations),
                                   nexttoward(from.zw, to.zw, optimizations));
            }
        }
    }
}
