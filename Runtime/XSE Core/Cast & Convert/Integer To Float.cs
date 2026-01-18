//#define TESTING
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
        private const bool HALF_INTEGER_CONVERSION_SHIFT_IN_RANGE =
#if TESTING
        false;
#else
        true;
#endif

        private static v128 INTEGER_MAP_F8 => new v128(0, ((quarter)1f).value, ((quarter)2f).value, ((quarter)3f).value, ((quarter)4f).value, ((quarter)5f).value, ((quarter)6f).value, ((quarter)7f).value, ((quarter)8f).value, ((quarter)9f).value, ((quarter)10f).value, ((quarter)11f).value, ((quarter)12f).value, ((quarter)13f).value, ((quarter)14f).value, ((quarter)15f).value);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 16)
        {
            promiseInRange |= constexpr.ALL_LE_EPU8(a, 15, elements);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                result = promiseInRange ? result : blendv_si128(result, set1_epi8(overflowValue.value), cmpge_epu8(a, set1_epi8(16), elements));

                return result;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __4 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: (byte)(elements <= 4 ? elements : 4));
                if (elements <= 4) return __4;

                a = bsrli_si128(a, 4 * sizeof(byte));
                v128 __8 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: 4);
                v128 __4__8 = unpacklo_epi32(__4, __8);
                if (elements <= 8) return __4__8;

                a = bsrli_si128(a, 4 * sizeof(byte));
                v128 __12 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: 4);
                a = bsrli_si128(a, 4 * sizeof(byte));
                v128 __16 = BASE_OVERFLOWCTRL__cvtps_pq(cvtepu8_ps(a), promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: 4);
                v128 __12__16 = unpacklo_epi32(__12, __16);

                return unpacklo_epi64(__4__8, __12__16);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false, byte elements = 16)
        {
            promiseInRange |= constexpr.ALL_GE_EPI8(a, -15, elements) && constexpr.ALL_LE_EPI8(a, 15, elements);
            promiseAbs |= constexpr.ALL_GE_EPI8(a, 0, elements);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 abs = promiseAbs ? a : abs_epi8(a);
                v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                result = promiseInRange ? result : blendv_si128(result, set1_epi8(overflowValue.value), cmpgt_epi8(abs, set1_epi8(15)));
                result = promiseAbs ? result : ternarylogic_si128(result, a, set1_epi8(1 << 7), TernaryOperation.Ox78);

                return result;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __4 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbs ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: (byte)(elements <= 4 ? elements : 4));
                if (elements <= 4) return __4;

                a = bsrli_si128(a, 4 * sizeof(byte));
                v128 __8 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbs ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: 4);
                v128 __4__8 = unpacklo_epi32(__4, __8);
                if (elements <= 8) return __4__8;

                a = bsrli_si128(a, 4 * sizeof(byte));
                v128 __12 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbs ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: 4);
                a = bsrli_si128(a, 4 * sizeof(byte));
                v128 __16 = BASE_OVERFLOWCTRL__cvtps_pq(promiseAbs ? cvtepu8_ps(a) : cvtepi32_ps(cvtepi8_epi32(a)), promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: 4);
                v128 __12__16 = unpacklo_epi32(__12, __16);

                return unpacklo_epi64(__4__8, __12__16);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu8_pq(v256 a, quarter overflowValue, bool promiseInRange = false)
        {
            promiseInRange |= constexpr.ALL_LE_EPU8(a, 15);

            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), a);
                result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi8(overflowValue.value), mm256_cmpge_epu8(a, mm256_set1_epi8(16)));

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi8_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            promiseInRange |= constexpr.ALL_GE_EPI8(a, -15) && constexpr.ALL_LE_EPI8(a, 15);
            promiseAbs |= constexpr.ALL_GE_EPI8(a, 0);

            if (Avx2.IsAvx2Supported)
            {
                v256 abs = promiseAbs ? a : Avx2.mm256_abs_epi8(a);
                v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), abs);
                result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi8(overflowValue.value), Avx2.mm256_cmpgt_epi8(abs, mm256_set1_epi8(15)));
                result = promiseAbs ? result : mm256_ternarylogic_si256(result, a, mm256_set1_epi8(1 << 7), TernaryOperation.Ox78);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 8)
        {
            promiseInRange |= constexpr.ALL_LE_EPU16(a, 15, elements);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                result = promiseInRange ? result : blendv_si128(result, set1_epi16((sbyte)overflowValue.value), cmpge_epu16(a, set1_epi16(16), elements));

                return packus_epi16(result, result);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return BASE_OVERFLOWCTRL__cvtps_pq(cvtepu16_ps(a), promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: elements);
                }
                else
                {
                    v128 lo_ps = cvt2x2epu16_ps(a, out v128 hi_ps);

                    lo_ps = BASE_OVERFLOWCTRL__cvtps_pq(lo_ps, promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: 4);
                    hi_ps = BASE_OVERFLOWCTRL__cvtps_pq(hi_ps, promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: 4);

                    return unpacklo_epi32(lo_ps, hi_ps);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false, byte elements = 8)
        {
            promiseInRange |= constexpr.ALL_GE_EPI16(a, -15, elements) && constexpr.ALL_LE_EPI16(a, 15, elements);
            promiseAbs |= constexpr.ALL_GE_EPI16(a, 0, elements);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 abs = promiseAbs ? a : abs_epi16(a);
                v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                result = promiseInRange ? result : blendv_si128(result, set1_epi16((sbyte)overflowValue.value), cmpgt_epi16(abs, set1_epi16(15)));

                if (!promiseAbs)
                {
                    v128 sign = and_si128(a, set1_epi16(1 << 15));
                    result = xor_si128(result, srli_epi16(sign, 8));
                }

                return packus_epi16(result, result);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (elements <= 4)
                {
                    return BASE_OVERFLOWCTRL__cvtps_pq(cvtepi16_ps(a), promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: elements);
                }
                else
                {
                    v128 lo_ps = cvt2x2epi16_ps(a, out v128 hi_ps);

                    lo_ps = BASE_OVERFLOWCTRL__cvtps_pq(lo_ps, promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: 4);
                    hi_ps = BASE_OVERFLOWCTRL__cvtps_pq(hi_ps, promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: 4);

                    return unpacklo_epi32(lo_ps, hi_ps);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepu16_pq(v256 a, quarter overflowValue, bool promiseInRange = false)
        {
            promiseInRange |= constexpr.ALL_LE_EPU16(a, 15);

            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), a);
                result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi16((sbyte)overflowValue.value), mm256_cmpge_epu16(a, mm256_set1_epi16(16)));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(result, result), Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi16_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            promiseInRange |= constexpr.ALL_GE_EPI16(a, -15) && constexpr.ALL_LE_EPI16(a, 15);
            promiseAbs |= constexpr.ALL_GE_EPI16(a, 0);

            if (Avx2.IsAvx2Supported)
            {
                v256 abs = promiseAbs ? a : Avx2.mm256_abs_epi16(a);
                v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), abs);
                result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi16((sbyte)overflowValue.value), Avx2.mm256_cmpgt_epi16(abs, mm256_set1_epi16(15)));

                if (!promiseAbs)
                {
                    v256 sign = Avx2.mm256_and_si256(a, mm256_set1_epi16(1 << 15));
                    result = Avx2.mm256_xor_si256(result, Avx2.mm256_srli_epi16(sign, 8));
                }

                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_packus_epi16(result, result), Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_pq(v128 a, quarter overflowValue, bool promiseInRange = false, byte elements = 4)
        {
            promiseInRange |= constexpr.ALL_LE_EPU32(a, 15, elements);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                result = promiseInRange ? result : blendv_si128(result, set1_epi32((sbyte)overflowValue.value), cmpge_epu32(a, set1_epi32(16), elements));
                result = packs_epi32(result, result);

                return packus_epi16(result, result);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return BASE_OVERFLOWCTRL__cvtps_pq(cvtepu32_ps(a), promiseInRange: promiseInRange, promiseAbs: true, overflowValue: overflowValue, elements: elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false, byte elements = 4)
        {
            promiseInRange |= constexpr.ALL_GE_EPI32(a, -15, elements) && constexpr.ALL_LE_EPI32(a, 15, elements);
            promiseAbs |= constexpr.ALL_GE_EPI32(a, 0, elements);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 abs = promiseAbs ? a : abs_epi32(a);
                v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                result = promiseInRange ? result : blendv_si128(result, set1_epi32((sbyte)overflowValue.value), cmpgt_epi32(abs, set1_epi32(15)));

                if (!promiseAbs)
                {
                    v128 sign = and_si128(a, set1_epi32(1 << 31));
                    result = xor_si128(result, srli_epi32(sign, 24));
                }

                result = packs_epi32(result, result);

                return packus_epi16(result, result);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return BASE_OVERFLOWCTRL__cvtps_pq(cvtepi32_ps(a), promiseInRange: promiseInRange, promiseAbs: promiseAbs, overflowValue: overflowValue, elements: elements);
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
        public static v128 mm256_cvtepi32_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            promiseInRange |= constexpr.ALL_GE_EPI32(a, -15) && constexpr.ALL_LE_EPI32(a, 15);
            promiseAbs |= constexpr.ALL_GE_EPI32(a, 0);

            if (Avx2.IsAvx2Supported)
            {
                v256 abs = promiseAbs ? a : mm256_abs_epi32(a);
                v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), abs);
                result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi32((sbyte)overflowValue.value), Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(15)));

                if (!promiseAbs)
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

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi8(INTEGER_MAP_F8, a);
                result = promiseInRange ? result : blendv_si128(result, set1_epi64x((sbyte)overflowValue.value), cmpgt_epu64(a, set1_epi64x(15)));

                return cvtepi64_epi8(result);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                int result = quarter.GetInteger(a.ULong0, overflowValue).value;
                result |= quarter.GetInteger(a.ULong1, overflowValue).value << 8;

                return cvtsi32_si128(result);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_pq(v128 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            promiseInRange |= constexpr.ALL_GE_EPI64(a, -15) && constexpr.ALL_LE_EPI64(a, 15);
            promiseAbs |= constexpr.ALL_GE_EPI64(a, 0);

            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 abs = promiseAbs ? a : abs_epi64(a);
                v128 result = shuffle_epi8(INTEGER_MAP_F8, abs);
                result = promiseInRange ? result : blendv_si128(result, set1_epi64x((sbyte)overflowValue.value), cmpgt_epi64(abs, set1_epi64x(15)));

                if (!promiseAbs)
                {
                    v128 sign = and_si128(a, set1_epi64x(1L << 63));
                    result = xor_si128(result, srli_epi64(sign, 56));
                }

                result = shuffle_epi32(result, Sse.SHUFFLE(0, 0, 2, 0));
                result = packs_epi32(result, result);

                return packus_epi16(result, result);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                int result = quarter.FromLong(a.SLong0, overflowValue).value;
                result |= quarter.FromLong(a.SLong1, overflowValue).value << 8;

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
        public static v128 mm256_cvtepi64_pq(v256 a, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false, byte elements = 4)
        {
            promiseInRange |= constexpr.ALL_GE_EPI64(a, -15, elements) && constexpr.ALL_LE_EPI64(a, 15, elements);
            promiseAbs |= constexpr.ALL_GE_EPI64(a, 0, elements);

            if (Avx2.IsAvx2Supported)
            {
                v256 abs = promiseAbs ? a : mm256_abs_epi64(a);
                v256 result = Avx2.mm256_shuffle_epi8(new v256(INTEGER_MAP_F8, INTEGER_MAP_F8), abs);
                result = promiseInRange ? result : mm256_blendv_si256(result, mm256_set1_epi64x((sbyte)overflowValue.value), mm256_cmpgt_epi64(abs, mm256_set1_epi64x(15), elements));

                if (!promiseAbs)
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_ph(v128 a, bool promiseNonZero = false, byte elements = 8)
        {
            promiseNonZero |= constexpr.ALL_NEQ_EPU8(a, 0, elements);

            if (BurstArchitecture.IsSIMDSupported)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        if (elements <= 4)
                        {
                            return cvtps_ph(cvtepu8_ps(a));
                        }
                        else
                        {
                            return mm256_cvtps_ph(mm256_cvtepu8_ps(a));
                        }
                    }
                }

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    v128 SHUFFLE_MASK_LO_LZ = new v128(24, 10, 9, 9, 8, 8, 8, 8, 7, 7, 7, 7, 7, 7, 7, 7);
                    v128 SHUFFLE_MASK_HI_LZ = new v128(24,  6, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3);

                    v128 lz = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO_LZ, and_si128(NIBBLE_MASK, a)),
                                       shuffle_epi8(SHUFFLE_MASK_HI_LZ, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                    v128 mantissa16;
                    if (BurstArchitecture.IsVectorShift16Supported)
                    {
                        mantissa16 = sllv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(lz));
                    }
                    else if (BurstArchitecture.IsVectorShiftSupported)
                    {
                        if (elements <= 4)
                        {
                            mantissa16 = cvtepi32_epi16(sllv_epi32(cvtepu8_epi32(a), cvtepu8_epi32(lz)));
                        }
                        else
                        {
                            v128 mantissa32Lo = cvt2x2epu8_epi32(a, out v128 mantissa32Hi);
                            v128 lz32Lo = cvt2x2epu8_epi32(lz, out v128 lz32Hi);
                            mantissa32Lo = sllv_epi32(mantissa32Lo, lz32Lo);
                            mantissa32Hi = sllv_epi32(mantissa32Hi, lz32Hi);
                            mantissa16 = packus_epi32(mantissa32Lo, mantissa32Hi);
                        }
                    }
                    else
                    {
                        mantissa16 = sllv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(lz));
                    }

                    v128 exp = sub_epi8(set1_epi8(24), lz);
                    v128 exp16 = slli_epi16(cvtepu8_epi16(exp), F16_MANTISSA_BITS);

                    return add_epi16(exp16, mantissa16);
                }
                else
                {
                    v128 lz = lzcnt_epi8(a);
                    v128 mantissaShift = add_epi8(lz, set1_epi8(3));

                    v128 exp = sub_epi8(promiseNonZero ? set1_epi8(21) : blendv_si128(set1_epi8(21), set1_epi8(8), cmpeq_epi8(a, setzero_si128())), lz);
                    v128 exp16 = slli_epi16(cvtepu8_epi16(exp), F16_MANTISSA_BITS);

                    v128 mantissa = cvtepu8_epi16(a);
                    mantissa = sllv_epi16(mantissa, cvtepu8_epi16(mantissaShift));

                    return add_epi16(exp16, mantissa);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_ph(v128 a, bool promiseNonZero = false, bool promiseNotNegative = false, byte elements = 8)
        {
            promiseNonZero |= constexpr.ALL_NEQ_EPI8(a, 0, elements);
            promiseNotNegative |= constexpr.ALL_GE_EPI8(a, 0, elements);

            if (BurstArchitecture.IsSIMDSupported)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        return cvtps_ph(cvtepi8_ps(a));
                    }
                    else
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            return mm256_cvtps_ph(mm256_cvtepi8_ps(a));
                        }
                        else
                        {
                            v128 a32Lo = cvt2x2epi8_epi32(a, out v128 a32Hi);

                            return unpacklo_epi64(cvtps_ph(cvtepi32_ps(a32Lo)),
                                                  cvtps_ph(cvtepi32_ps(a32Hi)));
                        }
                    }
                }
                else
                {
                    v128 sign16;
                    v128 exp16;
                    v128 mantissa16;
                    if (promiseNotNegative)
                    {
                        sign16 = setzero_si128();
                    }
                    else
                    {
                        sign16 = and_si128(a, set1_epi8(1 << 7));
                        sign16 = unpacklo_epi8(setzero_si128(), sign16);
                        a = abs_epi8(a);
                    }

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 SHUFFLE_MASK_LO_LZ = new v128(24, 10, 9, 9, 8, 8, 8, 8, 7, 7, 7, 7, 7, 7, 7, 7);
                        v128 SHUFFLE_MASK_HI_LZ = new v128(24,  6, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3);

                        v128 lz = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO_LZ, and_si128(NIBBLE_MASK, a)),
                                           shuffle_epi8(SHUFFLE_MASK_HI_LZ, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                        if (BurstArchitecture.IsVectorShift16Supported)
                        {
                            mantissa16 = sllv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(lz));
                        }
                        else if (BurstArchitecture.IsVectorShiftSupported)
                        {
                            if (elements <= 4)
                            {
                                mantissa16 = cvtepi32_epi16(sllv_epi32(cvtepu8_epi32(a), cvtepu8_epi32(lz)));
                            }
                            else
                            {
                                v128 mantissa32Lo = cvt2x2epu8_epi32(a, out v128 mantissa32Hi);
                                v128 lz32Lo = cvt2x2epu8_epi32(lz, out v128 lz32Hi);
                                mantissa32Lo = sllv_epi32(mantissa32Lo, lz32Lo);
                                mantissa32Hi = sllv_epi32(mantissa32Hi, lz32Hi);
                                mantissa16 = packus_epi32(mantissa32Lo, mantissa32Hi);
                            }
                        }
                        else
                        {
                            mantissa16 = sllv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(lz));
                        }

                        v128 exp = sub_epi8(set1_epi8(24), lz);
                        exp16 = slli_epi16(cvtepu8_epi16(exp), F16_MANTISSA_BITS);
                    }
                    else
                    {
                        v128 lz = lzcnt_epi8(a);
                        v128 mantissaShift = add_epi8(lz, set1_epi8(3));

                        v128 exp = sub_epi8(promiseNonZero ? set1_epi8(21) : blendv_si128(set1_epi8(21), set1_epi8(8), cmpeq_epi8(a, setzero_si128())), lz);
                        exp16 = slli_epi16(cvtepu8_epi16(exp), F16_MANTISSA_BITS);

                        mantissa16 = cvtepu8_epi16(a);
                        mantissa16 = sllv_epi16(mantissa16, cvtepu8_epi16(mantissaShift));
                    }

                    return promiseNotNegative ? add_epi16(exp16, mantissa16) : xor_si128(sign16, add_epi16(exp16, mantissa16));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu8_ph(v128 a, bool promiseNonZero = false)
        {
            promiseNonZero |= constexpr.ALL_NEQ_EPU8(a, 0);

            if (Avx2.IsAvx2Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    v128 lo = mm256_cvtps_ph(mm256_cvtepu8_ps(a));
                    v128 hi = mm256_cvtps_ph(mm256_cvtepu8_ps(bsrli_si128(a, 8 * sizeof(sbyte))));

                    return Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(lo), hi, 1);
                }
                else
                {
                    v128 SHUFFLE_MASK_LO_LZ = new v128(24, 10, 9, 9, 8, 8, 8, 8, 7, 7, 7, 7, 7, 7, 7, 7);
                    v128 SHUFFLE_MASK_HI_LZ = new v128(24,  6, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3);

                    v128 lz = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO_LZ, and_si128(NIBBLE_MASK, a)),
                                       shuffle_epi8(SHUFFLE_MASK_HI_LZ, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                    v256 mantissa16 = Avx2.mm256_cvtepu8_epi16(a);
                    v256 lz16 = Avx2.mm256_cvtepu8_epi16(lz);
                    if (BurstArchitecture.IsVectorShift16Supported)
                    {
                        mantissa16 = mm256_sllv_epi16(mantissa16, lz16);
                    }
                    else
                    {
                        v256 mantissa32Lo = mm256_cvt2x2epu16_epi32(mantissa16, out v256 mantissa32Hi);
                        v256 lz32Lo = mm256_cvt2x2epu16_epi32(lz16, out v256 lz32Hi);
                        mantissa32Lo = Avx2.mm256_sllv_epi32(mantissa32Lo, lz32Lo);
                        mantissa32Hi = Avx2.mm256_sllv_epi32(mantissa32Hi, lz32Hi);
                        mantissa16 = Avx2.mm256_packus_epi32(mantissa32Lo, mantissa32Hi);
                    }

                    v128 exp = sub_epi8(set1_epi8(24), lz);
                    v256 exp16 = Avx2.mm256_slli_epi16(Avx2.mm256_cvtepu8_epi16(exp), F16_MANTISSA_BITS);

                    return Avx2.mm256_add_epi16(exp16, mantissa16);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi8_ph(v128 a, bool promiseNonZero = false, bool promiseNotNegative = false)
        {
            promiseNonZero |= constexpr.ALL_NEQ_EPU8(a, 0);
            promiseNotNegative |= constexpr.ALL_GE_EPI8(a, 0);

            if (Avx2.IsAvx2Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    v128 lo = mm256_cvtps_ph(mm256_cvtepi8_ps(a));
                    v128 hi = mm256_cvtps_ph(mm256_cvtepi8_ps(bsrli_si128(a, 8 * sizeof(byte))));

                    return Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(lo), hi, 1);
                }
                else
                {
                    v256 sign16;
                    if (promiseNotNegative)
                    {
                        sign16 = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        v128 sign = and_si128(a, set1_epi8(1 << 7));
                        sign16 = Avx2.mm256_slli_epi16(Avx2.mm256_cvtepu8_epi16(sign), 8);
                        a = abs_epi8(a);
                    }

                    v128 SHUFFLE_MASK_LO_LZ = new v128(24, 10, 9, 9, 8, 8, 8, 8, 7, 7, 7, 7, 7, 7, 7, 7);
                    v128 SHUFFLE_MASK_HI_LZ = new v128(24,  6, 5, 5, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3);

                    v128 lz = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO_LZ, and_si128(NIBBLE_MASK, a)),
                                       shuffle_epi8(SHUFFLE_MASK_HI_LZ, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                    v256 mantissa16 = Avx2.mm256_cvtepu8_epi16(a);
                    v256 lz16 = Avx2.mm256_cvtepu8_epi16(lz);
                    if (BurstArchitecture.IsVectorShift16Supported)
                    {
                        mantissa16 = mm256_sllv_epi16(mantissa16, lz16);
                    }
                    else
                    {
                        v256 mantissa32Lo = mm256_cvt2x2epu16_epi32(mantissa16, out v256 mantissa32Hi);
                        v256 lz32Lo = mm256_cvt2x2epu16_epi32(lz16, out v256 lz32Hi);
                        mantissa32Lo = Avx2.mm256_sllv_epi32(mantissa32Lo, lz32Lo);
                        mantissa32Hi = Avx2.mm256_sllv_epi32(mantissa32Hi, lz32Hi);
                        mantissa16 = Avx2.mm256_packus_epi32(mantissa32Lo, mantissa32Hi);
                    }

                    v128 exp = sub_epi8(set1_epi8(24), lz);
                    v256 exp16 = Avx2.mm256_slli_epi16(Avx2.mm256_cvtepu8_epi16(exp), F16_MANTISSA_BITS);

                    return promiseNotNegative ? Avx2.mm256_add_epi16(exp16, mantissa16) : Avx2.mm256_xor_si256(sign16, Avx2.mm256_add_epi16(exp16, mantissa16));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_ph(v128 a, half overflowValue, bool nonZero = false, bool inRange = false, bool absBelow2pow11 = false, byte elements = 8)
        {
            inRange |= absBelow2pow11;

            if (Avx2.IsAvx2Supported)
            {
                if (elements <= 4)
                {
                    return cvtps_ph(cvtepu16_ps(a));
                }
                else
                {
                    v128 floatLo = cvt2x2epu16_ps(a, out v128 floatHi);
            
                    return unpacklo_epi64(cvtps_ph(floatLo),
                                          cvtps_ph(floatHi));
                }
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                nonZero |= constexpr.ALL_NEQ_EPI16(a, 0, elements);
                absBelow2pow11 |= constexpr.ALL_LT_EPU16(a, 1 << 11, elements);

                v128 mantissa;
                v128 exp;
                v128 lz;
                if (Ssse3.IsSsse3Supported)
                {
                    v128 SHUFFLE_MASK_LO = new v128(29, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                    v128 SHUFFLE_MASK_HI = new v128(29, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                    v128 lzcnt_bytes = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                                shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                    lz = min_epu8(add_epi8(lzcnt_bytes, set1_epi16(8)),
                                  srli_epi16(lzcnt_bytes, 8));
                }
                else
                {
                    lz = lzcnt_epi16(a);
                }
                
                v128 mantissaShift = sub_epi16(lz, set1_epi16(5));
                
                if (absBelow2pow11)
                {
                    mantissa = sllv_epi16(a, mantissaShift, inRange: HALF_INTEGER_CONVERSION_SHIFT_IN_RANGE, noOverflow: true, elements: elements);
                }
                else
                {
                    v128 mantissaBelow2pow11 = sllv_epi16(a, mantissaShift, inRange: HALF_INTEGER_CONVERSION_SHIFT_IN_RANGE, noOverflow: true, elements: elements);
                    v128 mantissaGE2pow11 = srlv_epi16(a, neg_epi16(mantissaShift), inRange: HALF_INTEGER_CONVERSION_SHIFT_IN_RANGE, elements: elements);

                    mantissa = blendv_si128(mantissaBelow2pow11, mantissaGE2pow11, srai_epi16(mantissaShift, 15));
                }

                if (Ssse3.IsSsse3Supported)
                {
                    exp = sub_epi16(set1_epi16(24), mantissaShift);
                }
                else
                {
                    exp = sub_epi16(nonZero ? set1_epi16(29) : blendv_si128(set1_epi16(29), set1_epi16(16), cmpeq_epi16(a, setzero_si128())), lz);
                }
                
                exp = slli_epi16(exp, F16_MANTISSA_BITS);

                v128 result = add_epi16(exp, mantissa);
                if (!inRange)
                {
                    result = blendv_si128(result, set1_epi16(overflowValue.value), cmpgt_epu16(a, set1_epi16((ushort)half.MaxValue)));
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_ph(v128 a, bool nonZero = false, bool nonNegative = false, bool absBelow2pow11 = false, byte elements = 8)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (elements <= 4)
                {
                    return cvtps_ph(cvtepi16_ps(a));
                }
                else
                {
                    v128 floatLo = cvt2x2epi16_ps(a, out v128 floatHi);

                    return unpacklo_epi64(cvtps_ph(floatLo),
                                          cvtps_ph(floatHi));
                }
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                nonZero |= constexpr.ALL_NEQ_EPI16(a, 0, elements);
                nonNegative |= constexpr.ALL_GE_EPI16(a, 0, elements);
                absBelow2pow11 |= (nonNegative || constexpr.ALL_GT_EPI16(a, -(1 << 11), elements)) && constexpr.ALL_LT_EPI16(a, 1 << 11, elements);
                
                v128 sign;
                v128 exp;
                v128 lz;
                v128 mantissa;
                if (nonNegative)
                {
                    sign = setzero_si128();
                }
                else
                {
                    sign = and_si128(a, set1_epi16(1 << 15));
                    a = abs_epi16(a);
                }

                if (Ssse3.IsSsse3Supported)
                {
                    v128 SHUFFLE_MASK_LO = new v128(29, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                    v128 SHUFFLE_MASK_HI = new v128(29, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                    v128 lzcnt_bytes = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                                shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                    lz = min_epu8(add_epi8(lzcnt_bytes, set1_epi16(8)),
                                  srli_epi16(lzcnt_bytes, 8));
                }
                else
                {
                    lz = lzcnt_epi16(a);
                }
                
                v128 mantissaShift = sub_epi16(lz, set1_epi16(5));
                
                if (absBelow2pow11)
                {
                    mantissa = sllv_epi16(a, mantissaShift, inRange: HALF_INTEGER_CONVERSION_SHIFT_IN_RANGE, noOverflow: true, elements: elements);
                }
                else
                {
                    v128 mantissaBelow2pow11 = sllv_epi16(a, mantissaShift, inRange: HALF_INTEGER_CONVERSION_SHIFT_IN_RANGE, noOverflow: true, elements: elements);
                    v128 mantissaGE2pow11 = srlv_epi16(a, neg_epi16(mantissaShift), inRange: HALF_INTEGER_CONVERSION_SHIFT_IN_RANGE, elements: elements);
                
                    mantissa = blendv_si128(mantissaBelow2pow11, mantissaGE2pow11, srai_epi16(mantissaShift, 15));
                }

                if (Ssse3.IsSsse3Supported)
                {
                    exp = sub_epi16(set1_epi16(24), mantissaShift);
                }
                else
                {
                    exp = sub_epi16(nonZero ? set1_epi16(29) : blendv_si128(set1_epi16(29), set1_epi16(16), cmpeq_epi16(a, setzero_si128())), lz);
                }
                    
                exp = slli_epi16(exp, F16_MANTISSA_BITS);

                return nonNegative ? add_epi16(exp, mantissa) : add_epi16(xor_si128(sign, exp), mantissa);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu16_ph(v256 a, half overflowValue, bool nonZero = false, bool inRange = false, bool absBelow2pow11 = false)
        {
            inRange |= absBelow2pow11;

            if (Avx2.IsAvx2Supported)
            {
                nonZero |= constexpr.ALL_NEQ_EPI16(a, 0);
                absBelow2pow11 |= constexpr.ALL_LT_EPU16(a, 1 << 11);
                
                v256 SHUFFLE_MASK_LO = new v256(29, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4,
                                                29, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v256 SHUFFLE_MASK_HI = new v256(29, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                                                29, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);
                
                v256 lzcnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                       Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                
                v256 lz = Avx2.mm256_min_epu8(Avx2.mm256_add_epi8(lzcnt_bytes, mm256_set1_epi16(8)),
                                              Avx2.mm256_srli_epi16(lzcnt_bytes, 8));

                v256 mantissaShift = Avx2.mm256_sub_epi16(lz, mm256_set1_epi16(5));
                
                v256 mantissa;
                if (absBelow2pow11)
                {
                    mantissa = mm256_sllv_epi16(a, mantissaShift, noOverflow: true);
                }
                else
                {
                    v256 mantissaBelow2pow11 = mm256_sllv_epi16(a, mantissaShift, noOverflow: true);
                    v256 mantissaGE2pow11 = mm256_srlv_epi16(a, mm256_neg_epi16(mantissaShift));
                
                    mantissa = mm256_blendv_si256(mantissaBelow2pow11, mantissaGE2pow11, Avx2.mm256_srai_epi16(mantissaShift, 15));
                }

                v256 exp = Avx2.mm256_sub_epi16(mm256_set1_epi16(24), mantissaShift);
                exp = Avx2.mm256_slli_epi16(exp, F16_MANTISSA_BITS);
                
                v256 result = Avx2.mm256_add_epi16(exp, mantissa);
                if (!inRange)
                {
                    result = mm256_blendv_si256(result, mm256_set1_epi16(overflowValue.value), mm256_cmpgt_epu16(a, mm256_set1_epi16((ushort)half.MaxValue)));
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi16_ph(v256 a, bool nonZero = false, bool nonNegative = false, bool absBelow2pow11 = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonZero |= constexpr.ALL_NEQ_EPI16(a, 0);
                nonNegative |= constexpr.ALL_GE_EPI16(a, 0);
                absBelow2pow11 |= (nonNegative || constexpr.ALL_GT_EPI16(a, -(1 << 11))) && constexpr.ALL_LT_EPI16(a, 1 << 11);
                  
                v256 sign;
                if (nonNegative)
                {
                    sign = Avx.mm256_setzero_si256();
                }
                else
                {
                    sign = Avx2.mm256_and_si256(a, mm256_set1_epi16(1 << 15));
                    a = mm256_abs_epi16(a);
                }

                v256 SHUFFLE_MASK_LO = new v256(29, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4,
                                                29, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                v256 SHUFFLE_MASK_HI = new v256(29, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                                                29, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);
                
                v256 lzcnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                       Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));
                
                v256 lz = Avx2.mm256_min_epu8(Avx2.mm256_add_epi8(lzcnt_bytes, mm256_set1_epi16(8)),
                                              Avx2.mm256_srli_epi16(lzcnt_bytes, 8));
                
                v256 mantissaShift = Avx2.mm256_sub_epi16(lz, mm256_set1_epi16(5));
                v256 mantissa;
                if (absBelow2pow11)
                {
                    mantissa = mm256_sllv_epi16(a, mantissaShift, noOverflow: true);
                }
                else
                {
                    v256 mantissaBelow2pow11 = mm256_sllv_epi16(a, mantissaShift, noOverflow: true);
                    v256 mantissaGE2pow11 = mm256_srlv_epi16(a, mm256_neg_epi16(mantissaShift));
                
                    mantissa = mm256_blendv_si256(mantissaBelow2pow11, mantissaGE2pow11, Avx2.mm256_srai_epi16(mantissaShift, 15));
                }
                    
                v256 exp = Avx2.mm256_sub_epi16(mm256_set1_epi16(24), mantissaShift);
                exp = Avx2.mm256_slli_epi16(exp, F16_MANTISSA_BITS);
                
                return nonNegative ? Avx2.mm256_add_epi16(exp, mantissa) : Avx2.mm256_add_epi16(Avx2.mm256_xor_si256(sign, exp), mantissa);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_ph(v128 a, half overflowValue, bool nonZero = false, bool inRange = false, bool absBelow2pow11 = false, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                inRange |= absBelow2pow11;
                
                if (constexpr.IS_TRUE(overflowValue == float.PositiveInfinity))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (inRange)
                        {
                            return cvtepi32_ph(a, overflowValue, nonZero: nonZero, nonNegative: true, inRange: inRange, absBelow2pow11: absBelow2pow11, elements: elements);
                        }
                    }
                }

                v128 result = cvtepu16_ph(packs_epi32(a, a), overflowValue, nonZero: nonZero, inRange: true, absBelow2pow11: absBelow2pow11, elements: elements);
                if (!inRange)
                {
                    v128 overflowMask = cmpgt_epu32(a, set1_epi32((ushort)half.MaxValue));
                    overflowMask = packs_epi32(overflowMask, overflowMask);
                    result = blendv_si128(result, set1_epi16(overflowValue.value), overflowMask);
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_ph(v128 a, half overflowValue, bool nonZero = false, bool nonNegative = false, bool inRange = false, bool absBelow2pow11 = false, byte elements = 4)
        {
            inRange |= absBelow2pow11;

            if (constexpr.IS_TRUE(overflowValue == float.PositiveInfinity))
            {
                if (Avx2.IsAvx2Supported)
                {
                    return cvtps_ph(cvtepi32_ps(a));
                }
            }
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = cvtepi16_ph(packs_epi32(a, a), nonZero: nonZero, nonNegative: nonNegative, absBelow2pow11: absBelow2pow11);
                if (!inRange)
                {
                    v128 overflowMask = nonNegative ? cmpgt_epi32(a, set1_epi32((ushort)half.MaxValue)) 
                                                    : cmpgt_epu32(abs_epi32(a), set1_epi32((ushort)half.MaxValue));
                    overflowMask = packs_epi32(overflowMask, overflowMask);

                    v128 signedOverflowValue = nonNegative ? set1_epi16(overflowValue.value)
                                                           : or_si128(set1_epi16(overflowValue.value), cvtepi32_epi16(slli_epi32(srli_epi32(a, 31), 15), elements));
                    
                    result = blendv_si128(result, signedOverflowValue, overflowMask);
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepu32_ph(v256 a, half overflowValue, bool nonZero = false, bool inRange = false, bool absBelow2pow11 = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                inRange |= absBelow2pow11;

                if (inRange)
                {
                    return mm256_cvtepi32_ph(a, overflowValue, nonZero: nonZero, nonNegative: true, inRange: inRange, absBelow2pow11: absBelow2pow11);
                }
                else
                {
                    v128 result = cvtepu16_ph(packs_epi32(Avx.mm256_castsi256_si128(a), Avx2.mm256_extracti128_si256(a, 1)), overflowValue, nonZero: nonZero, inRange: true, absBelow2pow11: absBelow2pow11);
                    v256 overflowMask = mm256_cmpgt_epu32(a, mm256_set1_epi32((ushort)half.MaxValue));
                    v128 overflowMask128 = packs_epi32(Avx.mm256_castsi256_si128(overflowMask), Avx2.mm256_extracti128_si256(overflowMask, 1));
                    
                    return blendv_si128(result, set1_epi16(overflowValue.value), overflowMask128);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi32_ph(v256 a, half overflowValue, bool nonZero = false, bool nonNegative = false, bool inRange = false, bool absBelow2pow11 = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                inRange |= absBelow2pow11;

                if (constexpr.IS_TRUE(overflowValue == float.PositiveInfinity))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtps_ph(Avx.mm256_cvtepi32_ps(a));
                    }
                }

                v128 result = cvtepi16_ph(packs_epi32(Avx.mm256_castsi256_si128(a), Avx2.mm256_extracti128_si256(a, 1)), nonZero: nonZero, nonNegative: nonNegative, absBelow2pow11: absBelow2pow11);
                if (!inRange)
                {
                    v256 overflowMask = nonNegative ? Avx2.mm256_cmpgt_epi32(a, mm256_set1_epi32((ushort)half.MaxValue))
                                                    : mm256_cmpgt_epu32(Avx2.mm256_abs_epi32(a), mm256_set1_epi32((ushort)half.MaxValue));
                    v128 overflowMask128 = packs_epi32(Avx.mm256_castsi256_si128(overflowMask), Avx2.mm256_extracti128_si256(overflowMask, 1));

                    v128 signedOverflowValue128;
                    if (nonNegative)
                    {
                        signedOverflowValue128 = set1_epi16(overflowValue.value);
                    }
                    else
                    {
                        v256 signedOverflowValue = Avx2.mm256_slli_epi32(Avx2.mm256_srai_epi32(a, 31), 15);
                        signedOverflowValue128 = packs_epi32(Avx.mm256_castsi256_si128(signedOverflowValue), Avx2.mm256_extracti128_si256(signedOverflowValue, 1));
                        signedOverflowValue128 = or_si128(set1_epi16(overflowValue.value), signedOverflowValue128);
                    }
                    
                    result = blendv_si128(result, signedOverflowValue128, overflowMask128);
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu64_ph(v128 a, half overflowValue, bool nonZero = false, bool inRange = false, bool absBelow2pow11 = false)
        {
            inRange |= absBelow2pow11;

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Avx2.IsAvx2Supported)
                {
                    result = cvtps_ph(cvtepi32_ps(cvtepi64_epi32(a)), elements: 2);
                }
                else
                {
                    result = cvtepu16_ph(cvtepi64_epi16(a), overflowValue, nonZero: nonZero, inRange: true, absBelow2pow11: absBelow2pow11, elements: 2);
                }

                if (!inRange
                 || overflowValue != float.PositiveInfinity)
                {
                    v128 overflowMask = cmpgt_epu64(a, set1_epi64x((ushort)half.MaxValue));
                    overflowMask = cvtepi64_epi16(overflowMask);
                    result = blendv_si128(result, set1_epi16(overflowValue.value), overflowMask);
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_ph(v128 a, half overflowValue, bool nonZero = false, bool nonNegative = false, bool inRange = false, bool absBelow2pow11 = false)
        {
            inRange |= absBelow2pow11;
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Avx2.IsAvx2Supported)
                {
                    result = cvtps_ph(cvtepi32_ps(cvtepi64_epi32(a)), elements: 2);
                }
                else
                {
                    result = cvtepi16_ph(cvtepi64_epi16(a), nonZero: nonZero, nonNegative: nonNegative, absBelow2pow11: absBelow2pow11, elements: 2);
                }

                if (!inRange
                 || overflowValue != float.PositiveInfinity)
                {
                    v128 overflowMask = nonNegative ? cmpgt_epi64(a, set1_epi64x((ushort)half.MaxValue))
                                                    : or_si128(cmpgt_epi64(set1_epi64x(-(ushort)half.MaxValue), a),
                                                               cmpgt_epi64(a, set1_epi64x((ushort)half.MaxValue)));
                    overflowMask = cvtepi64_epi16(overflowMask);
                    
                    v128 signedOverflowValue = nonNegative ? set1_epi16(overflowValue.value)
                                                           : or_si128(set1_epi16(overflowValue.value), cvtepi64_epi16(slli_epi64(srli_epi64(a, 63), 15)));

                    result = blendv_si128(result, signedOverflowValue, overflowMask);
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepu64_ph(v256 a, half overflowValue, bool nonZero = false, bool inRange = false, bool absBelow2pow11 = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                inRange |= absBelow2pow11;
                
                v128 result = cvtps_ph(cvtepi32_ps(mm256_cvtepi64_epi32(a)), elements: elements);

                if (!inRange
                 || overflowValue != float.PositiveInfinity)
                {
                    v256 overflowMask = mm256_cmpgt_epu64(a, mm256_set1_epi64x((ushort)half.MaxValue), elements: elements);
                    v128 overflowMask128 = mm256_cvtepi64_epi16(overflowMask);
                    result = blendv_si128(result, set1_epi16(overflowValue.value), overflowMask128);
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_ph(v256 a, half overflowValue, bool nonZero = false, bool nonNegative = false, bool inRange = false, bool absBelow2pow11 = false, byte elements = 4)
        {
            inRange |= absBelow2pow11;
            
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = cvtps_ph(cvtepi32_ps(mm256_cvtepi64_epi32(a)), elements: elements);

                if (!inRange
                 || overflowValue != float.PositiveInfinity)
                {
                    v256 overflowMask = nonNegative ? mm256_cmpgt_epi64(a, mm256_set1_epi64x((ushort)half.MaxValue), elements: elements)
                                                    : Avx2.mm256_or_si256(mm256_cmpgt_epi64(mm256_set1_epi64x(-(ushort)half.MaxValue), a, elements: elements),
                                                                          mm256_cmpgt_epi64(a, mm256_set1_epi64x((ushort)half.MaxValue), elements: elements));
                    v128 overflowMask128 = mm256_cvtepi64_epi16(overflowMask);
                    
                    v128 signedOverflowValue = nonNegative ? set1_epi16(overflowValue.value)
                                                           : or_si128(set1_epi16(overflowValue.value), mm256_cvtepi64_epi16(Avx2.mm256_slli_epi64(Avx2.mm256_srli_epi64(a, 63), 15)));

                    result = blendv_si128(result, signedOverflowValue, overflowMask128);
                }
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_ps(v128 a)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return cvtepi32_ps(cvtepu8_epi32(a));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return cvtepu16_ps(cvtepu8_epi16(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_ps(v128 a)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
        public static v256 mm256_cvtepu8_ps(v128 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepu8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi8_ps(v128 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_cvtepi32_ps(Avx2.mm256_cvtepi8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_ps(v128 a)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
                    roundIncrement = mm256_ternarylogic_si256(mm256_set1_epi64x(0x40), roundIncrement, jamInv,                     TernaryOperation.OxF4);
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
            if (BurstArchitecture.IsSIMDSupported)
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
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return cvtepu16_pd(cvtepu8_epi16(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_pd(v128 a)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
        public static v256 mm256_cvtepu8_pd(v128 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtepi32_pd(cvtepu8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi8_pd(v128 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtepi32_pd(cvtepi8_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_pd(v128 a)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return cvtepi32_pd(cvtepu16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_pd(v128 a)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
        public static v256 mm256_cvtepu16_pd(v128 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtepi32_pd(cvtepu16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi16_pd(v128 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_cvtepi32_pd(cvtepi16_epi32(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_pd(v128 a)
        {
            if (BurstArchitecture.IsSIMDSupported)
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