using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public readonly partial struct quarter : IEquatable<quarter>, IComparable<quarter>, IComparable, IFormattable, IConvertible
    {
        internal static partial class Vectorized
        {
            private static v128 INTEGER_MAP => new v128(((quarter)0f).value, ((quarter)1f).value, ((quarter)2f).value, ((quarter)3f).value, ((quarter)4f).value, ((quarter)5f).value, ((quarter)6f).value, ((quarter)7f).value, ((quarter)8f).value, ((quarter)9f).value, ((quarter)10f).value, ((quarter)11f).value, ((quarter)12f).value, ((quarter)13f).value, ((quarter)14f).value, ((quarter)15f).value);

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu8_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 16)
            {
                promiseInRange |= Xse.constexpr.ALL_LE_EPU8(a, 15, elements);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, a);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi8((sbyte)overflowValue.value), Xse.cmpge_epu8(a, Sse2.set1_epi8(16), elements));
                    
                    return result;
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 __4 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(Xse.cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: (byte)(elements <= 4 ? elements : 4)), (byte)(elements <= 4 ? elements : 4));
                    if (elements <= 4) return __4;

                    a = Sse2.bsrli_si128(a, 4 * sizeof(byte));
                    v128 __8 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(Xse.cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4));
                    v128 __4__8 = Sse2.unpacklo_epi32(__4, __8);
                    if (elements == 8) return __4__8;

                    a = Sse2.bsrli_si128(a, 4 * sizeof(byte));
                    v128 __12 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(Xse.cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4));
                    a = Sse2.bsrli_si128(a, 4 * sizeof(byte));
                    v128 __16 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(Xse.cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4));
                    v128 __12__16 = Sse2.unpacklo_epi32(__12, __16);

                    return Sse2.unpacklo_epi64(__4__8, __12__16);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi8_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 16)
            {
                promiseInRange |= Xse.constexpr.ALL_GE_EPI8(a, -15, elements) && Xse.constexpr.ALL_LE_EPI8(a, 15, elements);
                promiseAbsolute |= Xse.constexpr.ALL_GE_EPI8(a, 0, elements);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 abs = promiseAbsolute ? a : Ssse3.abs_epi8(a);
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, abs);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi8((sbyte)overflowValue.value), Sse2.cmpgt_epi8(abs, Sse2.set1_epi8(15)));
                    result = promiseAbsolute ? result : Xse.ternarylogic_si128(result, a, Sse2.set1_epi8(unchecked((sbyte)(1 << 7))), TernaryOperation.Ox78);
                    
                    return result;
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 __4 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? Xse.cvtepu8_ps(a) : Sse2.cvtepi32_ps(Xse.cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: (byte)(elements <= 4 ? elements : 4)), (byte)(elements <= 4 ? elements : 4));
                    if (elements <= 4) return __4;

                    a = Sse2.bsrli_si128(a, 4 * sizeof(byte));
                    v128 __8 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? Xse.cvtepu8_ps(a) : Sse2.cvtepi32_ps(Xse.cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4));
                    v128 __4__8 = Sse2.unpacklo_epi32(__4, __8);
                    if (elements == 8) return __4__8;

                    a = Sse2.bsrli_si128(a, 4 * sizeof(byte));
                    v128 __12 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? Xse.cvtepu8_ps(a) : Sse2.cvtepi32_ps(Xse.cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4));
                    a = Sse2.bsrli_si128(a, 4 * sizeof(byte));
                    v128 __16 = Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(promiseAbsolute ? Xse.cvtepu8_ps(a) : Sse2.cvtepi32_ps(Xse.cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4));
                    v128 __12__16 = Sse2.unpacklo_epi32(__12, __16);

                    return Sse2.unpacklo_epi64(__4__8, __12__16);
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu16_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 8)
            {
                promiseInRange |= Xse.constexpr.ALL_LE_EPU16(a, 15, elements);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, a);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi16((sbyte)overflowValue.value), Xse.cmpge_epu16(a, Sse2.set1_epi16(16), elements));
                    
                    return Sse2.packus_epi16(result, result);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (elements <= 4)
                    {
                        return Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(Xse.cvtepu16_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: elements), elements);
                    }
                    else
                    {
                        v128 lo_ps = Xse.cvt2x2epu16_ps(a, out v128 hi_ps);
                        
                        lo_ps = BASE_OVERFLOWCTRL__cvtps_pq(lo_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4);
                        hi_ps = BASE_OVERFLOWCTRL__cvtps_pq(hi_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: 4);
                    
                        return Sse2.unpacklo_epi32(Xse.cvtepi32_epi8(lo_ps), Xse.cvtepi32_epi8(hi_ps));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi16_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 16)
            {
                promiseInRange |= Xse.constexpr.ALL_GE_EPI16(a, -15, elements) && Xse.constexpr.ALL_LE_EPI16(a, 15, elements);
                promiseAbsolute |= Xse.constexpr.ALL_GE_EPI16(a, 0, elements);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 abs = promiseAbsolute ? a : Ssse3.abs_epi16(a);
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, abs);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi16((sbyte)overflowValue.value), Sse2.cmpgt_epi16(abs, Sse2.set1_epi16(15)));

                    if (!promiseAbsolute)
                    {
                        v128 sign = Sse2.and_si128(a, Sse2.set1_epi16(unchecked((short)(1 << 15))));
                        result = Sse2.xor_si128(result, Sse2.srli_epi16(sign, 8));
                    }
                    
                    return Sse2.packus_epi16(result, result);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (elements <= 4)
                    {
                        return Xse.cvtepi32_epi8(BASE_OVERFLOWCTRL__cvtps_pq(Xse.cvtepi16_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: elements), elements);
                    }
                    else
                    {
                        v128 lo_ps = Xse.cvt2x2epi16_ps(a, out v128 hi_ps);
                        
                        lo_ps = BASE_OVERFLOWCTRL__cvtps_pq(lo_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4);
                        hi_ps = BASE_OVERFLOWCTRL__cvtps_pq(hi_ps, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: 4);
                    
                        return Sse2.unpacklo_epi32(Xse.cvtepi32_epi8(lo_ps), Xse.cvtepi32_epi8(hi_ps));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu32_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 4)
            {
                promiseInRange |= Xse.constexpr.ALL_LE_EPU32(a, 15, elements);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, a);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi32((sbyte)overflowValue.value), Xse.cmpge_epu32(a, Sse2.set1_epi32(16), elements));
                    result = Sse2.packs_epi32(result, result);
                    
                    return Sse2.packus_epi16(result, result);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result = BASE_OVERFLOWCTRL__cvtps_pq(Xse.cvtepu32_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseInRange, overflowValue: overflowValue, elements: elements);
                    
                    return Xse.cvtepi32_epi8(result, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi32_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 4)
            {
                promiseInRange |= Xse.constexpr.ALL_GE_EPI32(a, -15, elements) && Xse.constexpr.ALL_LE_EPI32(a, 15, elements);
                promiseAbsolute |= Xse.constexpr.ALL_GE_EPI32(a, 0, elements);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 abs = promiseAbsolute ? a : Ssse3.abs_epi32(a);
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, abs);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi32((sbyte)overflowValue.value), Sse2.cmpgt_epi32(abs, Sse2.set1_epi32(15)));

                    if (!promiseAbsolute)
                    {
                        v128 sign = Sse2.and_si128(a, Sse2.set1_epi32(unchecked((int)(1 << 31))));
                        result = Sse2.xor_si128(result, Sse2.srli_epi32(sign, 24));
                    }
                    
                    result = Sse2.packs_epi32(result, result);
                    
                    return Sse2.packus_epi16(result, result);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result = BASE_OVERFLOWCTRL__cvtps_pq(Sse2.cvtepi32_ps(a), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, overflowValue: overflowValue, elements: elements);
                    
                    return Xse.cvtepi32_epi8(result);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepu32_pq(v256 a, quarter overflowValue, bool promiseInRange = false)
            {
                promiseInRange |= Xse.constexpr.ALL_LE_EPU32(a, 15);

                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP, INTEGER_MAP), a);
                    result = promiseInRange ? result : Xse.mm256_blendv_si256(result, Avx.mm256_set1_epi32((sbyte)overflowValue.value), Xse.mm256_cmpge_epu32(a, Avx.mm256_set1_epi32(16)));
                    
                    return Xse.mm256_cvtepi32_epi8(result);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepi32_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false)
            {
                promiseInRange |= Xse.constexpr.ALL_GE_EPI32(a, -15) && Xse.constexpr.ALL_LE_EPI32(a, 15);
                promiseAbsolute |= Xse.constexpr.ALL_GE_EPI32(a, 0);

                if (Avx2.IsAvx2Supported)
                {
                    v256 abs = promiseAbsolute ? a : Avx2.mm256_abs_epi32(a);
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP, INTEGER_MAP), abs);
                    result = promiseInRange ? result : Xse.mm256_blendv_si256(result, Avx.mm256_set1_epi32((sbyte)overflowValue.value), Avx2.mm256_cmpgt_epi32(abs, Avx.mm256_set1_epi32(15)));

                    if (!promiseAbsolute)
                    {
                        v256 sign = Avx2.mm256_and_si256(a, Avx.mm256_set1_epi32(unchecked((int)(1 << 31))));
                        result = Avx2.mm256_xor_si256(result, Avx2.mm256_srli_epi32(sign, 24));
                    }
                    
                    return Xse.mm256_cvtepi32_epi8(result);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepu64_pq(v128 a, quarter overflowValue, bool promiseInRange = false)
            {
                promiseInRange |= Xse.constexpr.ALL_LE_EPU64(a, 15);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, a);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi64x((sbyte)overflowValue.value), Xse.cmpgt_epu64(a, Sse2.set1_epi64x(15)));
                    
                    return Xse.cvtepi64_epi8(result);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (promiseInRange)
                    {
                        v128 result = BASE_OVERFLOWCTRL__cvtps_pq(Sse2.cvtepi32_ps(a), promiseInRange: true, promiseAbsoluteAndInRange: true, overflowValue: overflowValue);

                        return Xse.cvtepi64_epi8(result);
                    }
                    else if (Xse.constexpr.ALL_LE_EPU64(a, int.MaxValue))
                    {
                        v128 result = BASE_OVERFLOWCTRL__cvtps_pq(Sse2.cvtepi32_ps(a), promiseInRange: false, promiseAbsoluteAndInRange: false, overflowValue: overflowValue);

                        return Xse.cvtepi64_epi8(result);
                    }
                    else
                    {
                        int result = quarter.GetInteger(a.ULong0, overflowValue).value;
                        result |= quarter.GetInteger(a.ULong1, overflowValue).value << 8;

                        return Sse2.cvtsi32_si128(result);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtepi64_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false)
            {
                promiseInRange |= Xse.constexpr.ALL_GE_EPI64(a, -15) && Xse.constexpr.ALL_LE_EPI64(a, 15);
                promiseAbsolute |= Xse.constexpr.ALL_GE_EPI64(a, 0);

                if (Ssse3.IsSsse3Supported)
                {
                    v128 abs = promiseAbsolute ? a : Xse.abs_epi64(a);
                    v128 result = Ssse3.shuffle_epi8(INTEGER_MAP, abs);
                    result = promiseInRange ? result : Xse.blendv_si128(result, Sse2.set1_epi64x((sbyte)overflowValue.value), Xse.cmpgt_epi64(abs, Sse2.set1_epi64x(15)));

                    if (!promiseAbsolute)
                    {
                        v128 sign = Sse2.and_si128(a, Sse2.set1_epi64x(unchecked((long)(1L << 63))));
                        result = Sse2.xor_si128(result, Sse2.srli_epi64(sign, 56));
                    }

                    result = Sse2.shuffle_epi32(result, Sse.SHUFFLE(0, 0, 2, 0));
                    result = Sse2.packs_epi32(result, result);
                    
                    return Sse2.packus_epi16(result, result);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (promiseInRange)
                    {
                        v128 result = BASE_OVERFLOWCTRL__cvtps_pq(Sse2.cvtepi32_ps(a), promiseInRange: true, promiseAbsoluteAndInRange: promiseAbsolute, overflowValue: overflowValue);

                        return Xse.cvtepi64_epi8(result);
                    }
                    else if (Xse.constexpr.ALL_GE_EPI64(a, int.MinValue) && Xse.constexpr.ALL_LE_EPI64(a, int.MaxValue))
                    {
                        v128 result = BASE_OVERFLOWCTRL__cvtps_pq(Sse2.cvtepi32_ps(a), promiseInRange: false, promiseAbsoluteAndInRange: false, overflowValue: overflowValue);

                        return Xse.cvtepi64_epi8(result);
                    }
                    else
                    {
                        int result = quarter.LongToQuarter(a.SLong0, overflowValue).value;
                        result |= quarter.LongToQuarter(a.SLong1, overflowValue).value << 8;

                        return Sse2.cvtsi32_si128(result);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepu64_pq(v256 a, quarter overflowValue, bool promiseInRange = false, byte elements = 4)
            {
                promiseInRange |= Xse.constexpr.ALL_LE_EPU64(a, 15, elements);

                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP, INTEGER_MAP), a);
                    result = promiseInRange ? result : Xse.mm256_blendv_si256(result, Avx.mm256_set1_epi64x((sbyte)overflowValue.value), Xse.mm256_cmpgt_epu64(a, Avx.mm256_set1_epi64x(15), elements));
                    v128 result128 = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(result, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
                    result128 = Sse2.packs_epi32(result128, result128);

                    return Sse2.packus_epi16(result128, result128);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtepi64_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 4)
            {
                promiseInRange |= Xse.constexpr.ALL_GE_EPI64(a, -15, elements) && Xse.constexpr.ALL_LE_EPI64(a, 15, elements);
                promiseAbsolute |= Xse.constexpr.ALL_GE_EPI64(a, 0, elements);

                if (Avx2.IsAvx2Supported)
                {
                    v256 abs = promiseAbsolute ? a : Xse.mm256_abs_epi64(a);
                    v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP, INTEGER_MAP), abs);
                    result = promiseInRange ? result : Xse.mm256_blendv_si256(result, Avx.mm256_set1_epi64x((sbyte)overflowValue.value), Xse.mm256_cmpgt_epi64(abs, Avx.mm256_set1_epi64x(15), elements));

                    if (!promiseAbsolute)
                    {
                        v256 sign = Avx2.mm256_and_si256(a, Avx.mm256_set1_epi64x(unchecked((long)(1L << 63))));
                        result = Avx2.mm256_xor_si256(result, Avx2.mm256_srli_epi64(sign, 56));
                    }
                    
                    v128 result128 = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(result, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
                    result128 = Sse2.packs_epi32(result128, result128);

                    return Sse2.packus_epi16(result128, result128);
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
