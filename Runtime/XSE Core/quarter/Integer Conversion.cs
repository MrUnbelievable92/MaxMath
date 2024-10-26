using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            private static v128 INTEGER_MAP_F8 => new v128(0, ((quarter)1f).value, ((quarter)2f).value, ((quarter)3f).value, ((quarter)4f).value, ((quarter)5f).value, ((quarter)6f).value, ((quarter)7f).value, ((quarter)8f).value, ((quarter)9f).value, ((quarter)10f).value, ((quarter)11f).value, ((quarter)12f).value, ((quarter)13f).value, ((quarter)14f).value, ((quarter)15f).value);


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu8_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 16)
            {
                promiseInRange |= constexpr.ALL_LE_EPU8(a, 15, elements);

                if (Architecture.IsTableLookupSupported)
                {
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi8(overflowValue.value), cmpge_epu8(a, set1_epi8(16), elements));

                    return result;
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 __4 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: (byte)(elements <= 4 ? elements : 4));
                    if (elements <= 4) return __4;

                    a = bsrli_si128(a, 4 * sizeof(byte));
                    v128 __8 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4);
                    v128 __4__8 = unpacklo_epi32(__4, __8);
                    if (elements <= 8) return __4__8;

                    a = bsrli_si128(a, 4 * sizeof(byte));
                    v128 __12 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4);
                    a = bsrli_si128(a, 4 * sizeof(byte));
                    v128 __16 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4);
                    v128 __12__16 = unpacklo_epi32(__12, __16);

                    return unpacklo_epi64(__4__8, __12__16);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi8_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 16)
            {
                promiseInRange |= constexpr.ALL_GE_EPI8(a, -15, elements) && constexpr.ALL_LE_EPI8(a, 15, elements);
                promiseAbsolute |= constexpr.ALL_GE_EPI8(a, 0, elements);
                
                if (Architecture.IsTableLookupSupported)
                {
                    v128 abs = promiseAbsolute ? a : abs_epi8(a);
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi8(overflowValue.value), cmpgt_epi8(abs, set1_epi8(15)));
                    result = promiseAbsolute ? result : ternarylogic_si128(result, a, set1_epi8(1 << 7), TernaryOperation.Ox78);

                    return result;
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 __4 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: (byte)(elements <= 4 ? elements : 4));
                    if (elements <= 4) return __4;

                    a = bsrli_si128(a, 4 * sizeof(byte));
                    v128 __8 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4);
                    v128 __4__8 = unpacklo_epi32(__4, __8);
                    if (elements <= 8) return __4__8;

                    a = bsrli_si128(a, 4 * sizeof(byte));
                    v128 __12 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4);
                    a = bsrli_si128(a, 4 * sizeof(byte));
                    v128 __16 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4);
                    v128 __12__16 = unpacklo_epi32(__12, __16);

                    return unpacklo_epi64(__4__8, __12__16);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu16_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 8)
            {
                promiseInRange |= constexpr.ALL_LE_EPU16(a, 15, elements);
                
                if (Architecture.IsTableLookupSupported)
                {
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi16((sbyte)overflowValue.value), cmpge_epu16(a, set1_epi16(16), elements));

                    return packus_epi16(result, result);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (elements <= 4)
                    {
                        return BASE_OVERFLOWCTRL__cvtps_pq(cvtepu16_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: elements);
                    }
                    else
                    {
                        v128 lo_ps = cvt2x2epu16_ps(a, out v128 hi_ps);

                        lo_ps = BASE_OVERFLOWCTRL__cvtps_pq(lo_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4);
                        hi_ps = BASE_OVERFLOWCTRL__cvtps_pq(hi_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4);

                        return unpacklo_epi32(lo_ps, hi_ps);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi16_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 16)
            {
                promiseInRange |= constexpr.ALL_GE_EPI16(a, -15, elements) && constexpr.ALL_LE_EPI16(a, 15, elements);
                promiseAbsolute |= constexpr.ALL_GE_EPI16(a, 0, elements);
                
                if (Architecture.IsTableLookupSupported)
                {
                    v128 abs = promiseAbsolute ? a : abs_epi16(a);
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi16((sbyte)overflowValue.value), cmpgt_epi16(abs, set1_epi16(15)));

                    if (!promiseAbsolute)
                    {
                        v128 sign = and_si128(a, set1_epi16(1 << 15));
                        result = xor_si128(result, srli_epi16(sign, 8));
                    }

                    return packus_epi16(result, result);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (elements <= 4)
                    {
                        return BASE_OVERFLOWCTRL__cvtps_pq(cvtepi16_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: elements);
                    }
                    else
                    {
                        v128 lo_ps = cvt2x2epi16_ps(a, out v128 hi_ps);

                        lo_ps = BASE_OVERFLOWCTRL__cvtps_pq(lo_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4);
                        hi_ps = BASE_OVERFLOWCTRL__cvtps_pq(hi_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4);

                        return unpacklo_epi32(lo_ps, hi_ps);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu32_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 4)
            {
                promiseInRange |= constexpr.ALL_LE_EPU32(a, 15, elements);
                
                if (Architecture.IsTableLookupSupported)
                {
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi32((sbyte)overflowValue.value), cmpge_epu32(a, set1_epi32(16), elements));
                    result = packs_epi32(result, result);

                    return packus_epi16(result, result);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    return BASE_OVERFLOWCTRL__cvtps_pq(cvtepu32_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi32_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 4)
            {
                promiseInRange |= constexpr.ALL_GE_EPI32(a, -15, elements) && constexpr.ALL_LE_EPI32(a, 15, elements);
                promiseAbsolute |= constexpr.ALL_GE_EPI32(a, 0, elements);
                
                if (Architecture.IsTableLookupSupported)
                {
                    v128 abs = promiseAbsolute ? a : abs_epi32(a);
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi32((sbyte)overflowValue.value), cmpgt_epi32(abs, set1_epi32(15)));

                    if (!promiseAbsolute)
                    {
                        v128 sign = and_si128(a, set1_epi32(1 << 31));
                        result = xor_si128(result, srli_epi32(sign, 24));
                    }

                    result = packs_epi32(result, result);

                    return packus_epi16(result, result);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    return BASE_OVERFLOWCTRL__cvtps_pq(cvtepi32_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepu32_pq(v256 a, quarter overflowValue, bool promiseInRange = false)
            {
                promiseInRange |= constexpr.ALL_LE_EPU32(a, 15);

                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), a);
                    result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi32((sbyte)overflowValue.value), mm256_cmpge_epu32(a, mm256_set1_epi32(16)));

                    return mm256_cvtepi32_epi8(result);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepi32_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false)
            {
                promiseInRange |= constexpr.ALL_GE_EPI32(a, -15) && constexpr.ALL_LE_EPI32(a, 15);
                promiseAbsolute |= constexpr.ALL_GE_EPI32(a, 0);

                if (Avx2.IsAvx2Supported)
                {
                    v256 abs = promiseAbsolute ? a : mm256_abs_epi32(a);
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), abs);
                    result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi32((sbyte)overflowValue.value), Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(15)));

                    if (!promiseAbsolute)
                    {
                        v256 sign = Avx2.mm256_and_si256(a, mm256_set1_epi32(1 << 31));
                        result = Avx2.mm256_xor_si256(result, Avx2.mm256_srli_epi32(sign, 24));
                    }

                    return mm256_cvtepi32_epi8(result);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu64_pq(v128 a, quarter overflowValue, bool promiseInRange = false)
            {
                promiseInRange |= constexpr.ALL_LE_EPU64(a, 15);
                
                if (Architecture.IsTableLookupSupported)
                {
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi64x((sbyte)overflowValue.value), cmpgt_epu64(a, set1_epi64x(15)));

                    return cvtepi64_epi8(result);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    int result = quarter.GetInteger(a.ULong0, overflowValue).value;
                    result |= quarter.GetInteger(a.ULong1, overflowValue).value << 8;
                    
                    return cvtsi32_si128(result);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi64_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false)
            {
                promiseInRange |= constexpr.ALL_GE_EPI64(a, -15) && constexpr.ALL_LE_EPI64(a, 15);
                promiseAbsolute |= constexpr.ALL_GE_EPI64(a, 0);
                
                if (Architecture.IsTableLookupSupported)
                {
                    v128 abs = promiseAbsolute ? a : abs_epi64(a);
                    v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                    result = promiseInRange ? result : blendv_si128(result, set1_epi64x((sbyte)overflowValue.value), cmpgt_epi64(abs, set1_epi64x(15)));

                    if (!promiseAbsolute)
                    {
                        v128 sign = and_si128(a, set1_epi64x(1L << 63));
                        result = xor_si128(result, srli_epi64(sign, 56));
                    }

                    result = shuffle_epi32(result, Sse.SHUFFLE(0, 0, 2, 0));
                    result = packs_epi32(result, result);

                    return packus_epi16(result, result);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    int result = quarter.LongToQuarter(a.SLong0, overflowValue).value;
                    result |= quarter.LongToQuarter(a.SLong1, overflowValue).value << 8;
                    
                    return cvtsi32_si128(result);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepu64_pq(v256 a, quarter overflowValue, bool promiseInRange = false, byte elements = 4)
            {
                promiseInRange |= constexpr.ALL_LE_EPU64(a, 15, elements);

                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), a);
                    result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi64x((sbyte)overflowValue.value), mm256_cmpgt_epu64(a, mm256_set1_epi64x(15), elements));
                    v128 result128 = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(result, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
                    result128 = packs_epi32(result128, result128);

                    return packus_epi16(result128, result128);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepi64_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 4)
            {
                promiseInRange |= constexpr.ALL_GE_EPI64(a, -15, elements) && constexpr.ALL_LE_EPI64(a, 15, elements);
                promiseAbsolute |= constexpr.ALL_GE_EPI64(a, 0, elements);

                if (Avx2.IsAvx2Supported)
                {
                    v256 abs = promiseAbsolute ? a : mm256_abs_epi64(a);
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), abs);
                    result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi64x((sbyte)overflowValue.value), mm256_cmpgt_epi64(abs, mm256_set1_epi64x(15), elements));

                    if (!promiseAbsolute)
                    {
                        v256 sign = Avx2.mm256_and_si256(a, mm256_set1_epi64x(1L << 63));
                        result = Avx2.mm256_xor_si256(result, Avx2.mm256_srli_epi64(sign, 56));
                    }

                    v128 result128 = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(result, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
                    result128 = packs_epi32(result128, result128);

                    return packus_epi16(result128, result128);
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
