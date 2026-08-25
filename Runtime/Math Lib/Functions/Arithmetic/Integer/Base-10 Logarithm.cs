using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 log10_epu8(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU8(a, (byte)sbyte.MaxValue, elements))
                    {
                        return log10_epi8(a, elements);
                    }
                    else
                    {
                        v128 TEN = set1_epi8(10);
                        v128 HUNDRED = set1_epi8(100);

                        v128 result = cmpge_epu8(a, TEN, elements);
                        result = neg_epi8(result);
                        result = sub_epi8(result, cmpge_epu8(a, HUNDRED, elements));

                        constexpr.ASSUME_LE_EPU8(result, 2, elements);

                        constexpr.ASSUME_LE_EPU8(result, a, elements);
                        if (constexpr.ALL_GT_EPU8(a, 1, elements))
                        {
                            constexpr.ASSUME_LT_EPU8(result, a, elements);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_log10_epu8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU8(a, (byte)sbyte.MaxValue))
                    {
                        return mm256_log10_epi8(a);
                    }
                    else
                    {
                        v256 TEN = mm256_set1_epi8(10);
                        v256 HUNDRED = mm256_set1_epi8(100);

                        v256 result = mm256_cmpge_epu8(a, TEN);
                        result = mm256_abs_epi8(result);
                        result = Avx2.mm256_sub_epi8(result, mm256_cmpge_epu8(a, HUNDRED));

                        constexpr.ASSUME_LE_EPU8(result, 2);

                        constexpr.ASSUME_LE_EPU8(result, a);
                        if (constexpr.ALL_GT_EPU8(a, 1))
                        {
                            constexpr.ASSUME_LT_EPU8(result, a);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 log10_epi8(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<sbyte16, sbyte>(a, 0, elements);
constexpr.ASSUME_GE_EPI8(a, 0, elements);

                    v128 NINE = set1_epi8(9);
                    v128 NINETY_NINE = set1_epi8(99);

                    v128 result = cmpgt_epi8(a, NINE);
                    result = neg_epi8(result);
                    result = sub_epi8(result, cmpgt_epi8(a, NINETY_NINE));

                    constexpr.ASSUME_LE_EPU8(result, 2, elements);

                    constexpr.ASSUME_LE_EPU8(result, a, elements);
                    if (constexpr.ALL_GT_EPU8(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a, elements);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_log10_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotSmaller<sbyte32, sbyte>(a, 0, 32);
constexpr.ASSUME_GE_EPI8(a, 0, 32);

                    v256 NINE = mm256_set1_epi8(9);
                    v256 NINETY_NINE = mm256_set1_epi8(99);

                    v256 result = Avx2.mm256_cmpgt_epi8(a, NINE);
                    result = mm256_abs_epi8(result);
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_cmpgt_epi8(a, NINETY_NINE));

                    constexpr.ASSUME_LE_EPU8(result, 2);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 log10_epu16(v128 a, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue))
                    {
                        return log10_epi16(a, elements);
                    }
                    else
                    {
                        v128 result;

                        if (elements == 2)
                        {
                            v128 cmp = new v128(10, 10,   100, 100,   1_000, 1_000,   10_000, 10_000);

                            v128 splat = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                            v128 cmp_negated = cmpge_epu16(splat, cmp);
                            result = neg_epi16(cmp_negated);
                            result = sub_epi16(result, bsrli_si128(cmp_negated, 4 * sizeof(short)));
                            result = add_epi16(result, bsrli_si128(result, 2 * sizeof(short)));
                        }
                        else
                        {
                            if (BurstArchitecture.IsMinMaxSupported)
                            {
                                v128 _0 = set1_epi16(10);
                                v128 _1 = set1_epi16(100);
                                v128 _2 = set1_epi16(1_000);
                                v128 _3 = set1_epi16(10_000);

                                result = abs_epi16(cmpge_epu16(a, _0, elements));
                                result = sub_epi16(result, cmpge_epu16(a, _1, elements));
                                result = sub_epi16(result, cmpge_epu16(a, _2, elements));
                                result = sub_epi16(result, cmpge_epu16(a, _3, elements));
                            }
                            else
                            {
                                v128 _0 = set1_epi16(9);
                                v128 _1 = set1_epi16(99);
                                v128 _2 = set1_epi16(999);
                                v128 _3 = set1_epi16(9_999);

                                result = neg_epi16(cmpgt_epu16(a, _0, elements));
                                result = sub_epi16(result, cmpgt_epu16(a, _1, elements));
                                result = sub_epi16(result, cmpgt_epu16(a, _2, elements));
                                result = sub_epi16(result, cmpgt_epu16(a, _3, elements));
                            }
                        }

                        constexpr.ASSUME_LE_EPU16(result, 4, elements);

                        constexpr.ASSUME_LE_EPU16(result, a, elements);
                        if (constexpr.ALL_GT_EPU16(a, 1, elements))
                        {
                            constexpr.ASSUME_LT_EPU16(result, a, elements);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_log10_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue))
                    {
                        return mm256_log10_epi16(a);
                    }
                    else
                    {
                        v256 TEN = mm256_set1_epi16(10);
                        v256 HUNDRED = mm256_set1_epi16(100);
                        v256 _1_000 = mm256_set1_epi16(1_000);
                        v256 _10_000 = mm256_set1_epi16(10_000);

                        v256 result = mm256_cmpge_epu16(a, TEN);
                        result = mm256_abs_epi16(result);
                        result = Avx2.mm256_sub_epi16(result, mm256_cmpge_epu16(a, HUNDRED));
                        result = Avx2.mm256_sub_epi16(result, mm256_cmpge_epu16(a, _1_000));
                        result = Avx2.mm256_sub_epi16(result, mm256_cmpge_epu16(a, _10_000));

                        constexpr.ASSUME_LE_EPU16(result, 4);

                        constexpr.ASSUME_LE_EPU16(result, a);
                        if (constexpr.ALL_GT_EPU16(a, 1))
                        {
                            constexpr.ASSUME_LT_EPU16(result, a);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 log10_epi16(v128 a, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<short8, short>(a, 0, elements);
constexpr.ASSUME_GE_EPI16(a, 0, elements);

                    if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                    {
                        return log10_epu8(a, (byte)(elements * 2)); // 0 stays 0 (high bits)
                    }
                    else
                    {
                        v128 result;

                        if (elements == 2)
                        {
                            v128 splat = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                            v128 cmp = new v128(9, 9,   99, 99,   999, 999,   9_999, 9_999);

                            v128 cmp_negated = cmpgt_epi16(splat, cmp);
                            result = neg_epi16(cmp_negated);
                            result = sub_epi16(result, bsrli_si128(cmp_negated, 4 * sizeof(short)));
                            result = add_epi16(result, bsrli_si128(result, 2 * sizeof(short)));
                        }
                        else
                        {
                            v128 NINE = set1_epi16(9);
                            v128 NINETY_NINE = set1_epi16(99);
                            v128 _999 = set1_epi16(999);
                            v128 _9_999 = set1_epi16(9_999);

                            result = cmpgt_epi16(a, NINE);
                            result = neg_epi16(result);
                            result = sub_epi16(result, cmpgt_epi16(a, NINETY_NINE));
                            result = sub_epi16(result, cmpgt_epi16(a, _999));
                            result = sub_epi16(result, cmpgt_epi16(a, _9_999));
                        }

                        constexpr.ASSUME_LE_EPU16(result, 4, elements);

                        constexpr.ASSUME_LE_EPU16(result, a, elements);
                        if (constexpr.ALL_GT_EPU16(a, 1, elements))
                        {
                            constexpr.ASSUME_LT_EPU16(result, a, elements);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_log10_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotSmaller<short16, short>(a, 0, 16);
constexpr.ASSUME_GE_EPI16(a, 0, 16);

                    if (constexpr.ALL_LE_EPU16(a, byte.MaxValue))
                    {
                        return mm256_log10_epu8(a); // 0 stays 0 (high bits)
                    }
                    else
                    {
                        v256 NINE = mm256_set1_epi16(9);
                        v256 NINETY_NINE = mm256_set1_epi16(99);
                        v256 _999 = mm256_set1_epi16(999);
                        v256 _9_999 = mm256_set1_epi16(9_999);

                        v256 result = Avx2.mm256_cmpgt_epi16(a, NINE);
                        result = mm256_abs_epi16(result);
                        result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, NINETY_NINE));
                        result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, _999));
                        result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, _9_999));

                        constexpr.ASSUME_LE_EPU16(result, 4);

                        constexpr.ASSUME_LE_EPU16(result, a);
                        if (constexpr.ALL_GT_EPU16(a, 1))
                        {
                            constexpr.ASSUME_LT_EPU16(result, a);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 log10_epu32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue, elements))
                    {
                        return log10_epi32(a, elements);
                    }
                    else
                    {
                        v128 result;

                        switch(elements)
                        {
                            case 4:
                            {
                                if (BurstArchitecture.IsMinMaxSupported)
                                {
                                    v128 MASK_10 = set1_epi32(10);
                                    v128 MASK_100 = set1_epi32(100);
                                    v128 MASK_1000 = set1_epi32(1_000);
                                    v128 MASK_10000 = set1_epi32(10_000);
                                    v128 MASK_100000 = set1_epi32(100_000);
                                    v128 MASK_1000000 = set1_epi32(1_000_000);
                                    v128 MASK_10000000 = set1_epi32(10_000_000);
                                    v128 MASK_100000000 = set1_epi32(100_000_000);
                                    v128 MASK_1000000000 = set1_epi32(1_000_000_000);

                                    v128 result_10 = cmpge_epu32(a, MASK_10);
                                    v128 result_100 = cmpge_epu32(a, MASK_100);
                                    v128 result_1000 = cmpge_epu32(a, MASK_1000);
                                    v128 result_10000 = cmpge_epu32(a, MASK_10000);
                                    v128 result_100000 = cmpge_epu32(a, MASK_100000);
                                    v128 result_1000000 = cmpge_epu32(a, MASK_1000000);
                                    v128 result_10000000 = cmpge_epu32(a, MASK_10000000);
                                    v128 result_100000000 = cmpge_epu32(a, MASK_100000000);
                                    v128 result_1000000000 = cmpge_epu32(a, MASK_1000000000);

                                    result_10 = abs_epi32(result_10);
                                    result_100 = abs_epi32(result_100);
                                    result_1000 = abs_epi32(result_1000);
                                    result_10000 = abs_epi32(result_10000);

                                    result_10 = sub_epi32(result_10, result_100000);
                                    result_100 = sub_epi32(result_100, result_1000000);
                                    result_1000 = sub_epi32(result_1000, result_10000000);
                                    result_10000 = sub_epi32(result_10000, result_100000000);

                                    result_10 = sub_epi32(result_10, result_1000000000);

                                    result_100 = add_epi32(result_100, result_1000);
                                    result_1000 = add_epi32(result_10000, result_10);

                                    result = add_epi32(result_100, result_1000);
                                }
                                else
                                {
                                    v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                    v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 LAST = new v128(999_999_999);

                                    v128 xxxx = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                    v128 zzzz = shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2));
                                    v128 wwww = shuffle_epi32(a, Sse.SHUFFLE(3, 3, 3, 3));

                                    v128 xResult = cmpgt_epu32(xxxx, MASK_SMALL);
                                    v128 yResult = cmpgt_epu32(yyyy, MASK_SMALL);
                                    v128 zResult = cmpgt_epu32(zzzz, MASK_SMALL);
                                    v128 wResult = cmpgt_epu32(wwww, MASK_SMALL);
                                    xResult = neg_epi32(xResult);
                                    yResult = neg_epi32(yResult);
                                    zResult = neg_epi32(zResult);
                                    wResult = neg_epi32(wResult);
                                    xResult = sub_epi32(xResult, cmpgt_epu32(xxxx, MASK_LARGE));
                                    yResult = sub_epi32(yResult, cmpgt_epu32(yyyy, MASK_LARGE));
                                    zResult = sub_epi32(zResult, cmpgt_epu32(zzzz, MASK_LARGE));
                                    wResult = sub_epi32(wResult, cmpgt_epu32(wwww, MASK_LARGE));
                                    xResult = add_epi32(xResult, bsrli_si128(xResult, 2 * sizeof(uint)));
                                    yResult = add_epi32(yResult, bsrli_si128(yResult, 2 * sizeof(uint)));
                                    zResult = add_epi32(zResult, bsrli_si128(zResult, 2 * sizeof(uint)));
                                    wResult = add_epi32(wResult, bsrli_si128(wResult, 2 * sizeof(uint)));
                                    xResult = add_epi32(xResult, bsrli_si128(xResult, 1 * sizeof(uint)));
                                    yResult = add_epi32(yResult, bsrli_si128(yResult, 1 * sizeof(uint)));
                                    zResult = add_epi32(zResult, bsrli_si128(zResult, 1 * sizeof(uint)));
                                    wResult = add_epi32(wResult, bsrli_si128(wResult, 1 * sizeof(uint)));

                                    v128 lastCMP = cmpgt_epu32(a, LAST);

                                    v128 xy = unpacklo_epi32(xResult, yResult);
                                    v128 zw = unpacklo_epi32(zResult, wResult);
                                    result = unpacklo_epi64(xy, zw);
                                    result = sub_epi32(result, lastCMP);
                                }

                                break;
                            }
                            case 3:
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    v256 MASK = new v256(10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000);
                                    v128 LAST = new v128(1_000_000_000);

                                    v256 _x = Avx2.mm256_broadcastd_epi32(a);
                                    v256 _y = Avx2.mm256_broadcastd_epi32(bsrli_si128(a, 1 * sizeof(uint)));
                                    v256 _z = Avx2.mm256_broadcastd_epi32(bsrli_si128(a, 2 * sizeof(uint)));

                                    v256 resultX = mm256_cmpge_epu32(_x, MASK);
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = mm256_cmpge_epu32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);
                                    v256 resultZ = mm256_cmpge_epu32(_z, MASK);
                                    v128 hiZ = Avx2.mm256_extracti128_si256(resultZ, 1);

                                    v128 resultX128 = abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = abs_epi32(Avx.mm256_castsi256_si128(resultY));
                                    v128 resultZ128 = abs_epi32(Avx.mm256_castsi256_si128(resultZ));

                                    v128 lastCMP = cmpge_epu32(a, LAST);

                                    resultX128 = sub_epi32(resultX128, hiX);
                                    resultY128 = sub_epi32(resultY128, hiY);
                                    resultZ128 = sub_epi32(resultZ128, hiZ);

                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 2 * sizeof(uint)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 2 * sizeof(uint)));
                                    resultZ128 = add_epi32(resultZ128, bsrli_si128(resultZ128, 2 * sizeof(uint)));
                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 1 * sizeof(uint)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 1 * sizeof(uint)));
                                    resultZ128 = add_epi32(resultZ128, bsrli_si128(resultZ128, 1 * sizeof(uint)));

                                    v128 xy = unpacklo_epi32(resultX128, resultY128);
                                    result = unpacklo_epi64(xy, resultZ128);
                                    result = sub_epi32(result, lastCMP);
                                }
                                else
                                {
                                    v128 xxxx = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                    v128 zzzz = shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2));

                                    if (BurstArchitecture.IsMinMaxSupported)
                                    {
                                        v128 MASK_SMALL = new v128(10, 100, 1_000, 10_000);
                                        v128 MASK_LARGE = new v128(100_000, 1_000_000, 10_000_000, 100_000_000);
                                        v128 MASK_LAST  = new v128(1_000_000_000);

                                        v128 xResult = cmpge_epu32(xxxx, MASK_SMALL);
                                        v128 yResult = cmpge_epu32(yyyy, MASK_SMALL);
                                        v128 zResult = cmpge_epu32(zzzz, MASK_SMALL);
                                        xResult = abs_epi32(xResult);
                                        yResult = abs_epi32(yResult);
                                        zResult = abs_epi32(zResult);
                                        xResult = sub_epi32(xResult, cmpge_epu32(xxxx, MASK_LARGE));
                                        yResult = sub_epi32(yResult, cmpge_epu32(yyyy, MASK_LARGE));
                                        zResult = sub_epi32(zResult, cmpge_epu32(zzzz, MASK_LARGE));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 2 * sizeof(uint)));
                                        zResult = add_epi32(zResult, bsrli_si128(zResult, 2 * sizeof(uint)));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 1 * sizeof(uint)));
                                        zResult = add_epi32(zResult, bsrli_si128(zResult, 1 * sizeof(uint)));

                                        v128 lastCMP = cmpgt_epu32(a, MASK_LAST);

                                        v128 xy = unpacklo_epi32(xResult, yResult);
                                        result = unpacklo_epi64(xy, zResult);
                                        result = sub_epi32(result, lastCMP);
                                    }
                                    else
                                    {
                                        v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                        v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                        v128 MASK_LAST  = new v128(999_999_999);

                                        v128 xResult = cmpgt_epu32(xxxx, MASK_SMALL);
                                        v128 yResult = cmpgt_epu32(yyyy, MASK_SMALL);
                                        v128 zResult = cmpgt_epu32(zzzz, MASK_SMALL);

                                        xResult = neg_epi32(xResult);
                                        yResult = neg_epi32(yResult);
                                        zResult = neg_epi32(zResult);
                                        xResult = sub_epi32(xResult, cmpgt_epu32(xxxx, MASK_LARGE));
                                        yResult = sub_epi32(yResult, cmpgt_epu32(yyyy, MASK_LARGE));
                                        zResult = sub_epi32(zResult, cmpgt_epu32(zzzz, MASK_LARGE));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 2 * sizeof(uint)));
                                        zResult = add_epi32(zResult, bsrli_si128(zResult, 2 * sizeof(uint)));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 1 * sizeof(uint)));
                                        zResult = add_epi32(zResult, bsrli_si128(zResult, 1 * sizeof(uint)));

                                        v128 lastCMP = cmpgt_epu32(a, MASK_LAST);

                                        v128 xy = unpacklo_epi32(xResult, yResult);
                                        result = unpacklo_epi64(xy, zResult);
                                        result = sub_epi32(result, lastCMP);
                                    }
                                }

                                break;
                            }
                            case 2:
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    v256 MASK = new v256(10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000);
                                    v128 LAST = Xse.cvtsi64x_si128((1_000_000_000L << 32) | 1_000_000_000);

                                    v256 _x = Avx2.mm256_broadcastd_epi32(a);
                                    v256 _y = Avx2.mm256_broadcastd_epi32(bsrli_si128(a, 1 * sizeof(uint)));

                                    v256 resultX = mm256_cmpge_epu32(_x, MASK);
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = mm256_cmpge_epu32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);

                                    v128 resultX128 = abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = abs_epi32(Avx.mm256_castsi256_si128(resultY));

                                    v128 lastCMP = cmpge_epu32(a, LAST);

                                    resultX128 = sub_epi32(resultX128, hiX);
                                    resultY128 = sub_epi32(resultY128, hiY);

                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 2 * sizeof(uint)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 2 * sizeof(uint)));
                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 1 * sizeof(uint)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 1 * sizeof(uint)));

                                    v128 xy = unpacklo_epi32(resultX128, resultY128);
                                    result = sub_epi32(xy, lastCMP);
                                }
                                else
                                {
                                    v128 xxxx = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));

                                    if (BurstArchitecture.IsMinMaxSupported)
                                    {
                                        v128 MASK_SMALL = new v128(10, 100, 1_000, 10_000);
                                        v128 MASK_LARGE = new v128(100_000, 1_000_000, 10_000_000, 100_000_000);
                                        v128 MASK_LAST  = Xse.cvtsi64x_si128((1_000_000_000L << 32) | 1_000_000_000L);

                                        v128 xResult = cmpge_epu32(xxxx, MASK_SMALL);
                                        v128 yResult = cmpge_epu32(yyyy, MASK_SMALL);
                                        xResult = abs_epi32(xResult);
                                        yResult = abs_epi32(yResult);
                                        xResult = sub_epi32(xResult, cmpge_epu32(xxxx, MASK_LARGE));
                                        yResult = sub_epi32(yResult, cmpge_epu32(yyyy, MASK_LARGE));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 2 * sizeof(uint)));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 1 * sizeof(uint)));

                                        v128 lastCMP = cmpge_epu32(a, MASK_LAST);

                                        v128 xy = unpacklo_epi32(xResult, yResult);
                                        result = sub_epi32(xy, lastCMP);
                                    }
                                    else
                                    {
                                        v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                        v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                        v128 MASK_LAST  = cvtsi64x_si128((999_999_999L << 32) | 999_999_999L);

                                        v128 xResult = cmpgt_epu32(xxxx, MASK_SMALL);
                                        v128 yResult = cmpgt_epu32(yyyy, MASK_SMALL);
                                        xResult = neg_epi32(xResult);
                                        yResult = neg_epi32(yResult);
                                        xResult = sub_epi32(xResult, cmpgt_epu32(xxxx, MASK_LARGE));
                                        yResult = sub_epi32(yResult, cmpgt_epu32(yyyy, MASK_LARGE));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 2 * sizeof(uint)));
                                        xResult = add_epi32(xResult, bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = add_epi32(yResult, bsrli_si128(yResult, 1 * sizeof(uint)));

                                        v128 lastCMP = cmpgt_epu32(a, MASK_LAST);

                                        v128 xy = unpacklo_epi32(xResult, yResult);
                                        result = sub_epi32(xy, lastCMP);
                                    }
                                }

                                break;
                            }
                            default: result = a; break;
                        }

                        constexpr.ASSUME_LE_EPU32(result, 9, elements);

                        constexpr.ASSUME_LE_EPU32(result, a, elements);
                        if (constexpr.ALL_GT_EPU32(a, 1, elements))
                        {
                            constexpr.ASSUME_LT_EPU32(result, a, elements);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_log10_epu32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue))
                    {
                        return mm256_log10_epi32(a);
                    }
                    else
                    {
                        v256 MASK_10 = mm256_set1_epi32(10);
                        v256 MASK_100 = mm256_set1_epi32(100);
                        v256 MASK_1000 = mm256_set1_epi32(1_000);
                        v256 MASK_10000 = mm256_set1_epi32(10_000);
                        v256 MASK_100000 = mm256_set1_epi32(100_000);
                        v256 MASK_1000000 = mm256_set1_epi32(1_000_000);
                        v256 MASK_10000000 = mm256_set1_epi32(10_000_000);
                        v256 MASK_100000000 = mm256_set1_epi32(100_000_000);
                        v256 MASK_1000000000 = mm256_set1_epi32(1_000_000_000);

                        v256 result_10 = mm256_cmpge_epu32(a, MASK_10);
                        v256 result_100 = mm256_cmpge_epu32(a, MASK_100);
                        v256 result_1000 = mm256_cmpge_epu32(a, MASK_1000);
                        v256 result_10000 = mm256_cmpge_epu32(a, MASK_10000);
                        v256 result_100000 = mm256_cmpge_epu32(a, MASK_100000);
                        v256 result_1000000 = mm256_cmpge_epu32(a, MASK_1000000);
                        v256 result_10000000 = mm256_cmpge_epu32(a, MASK_10000000);
                        v256 result_100000000 = mm256_cmpge_epu32(a, MASK_100000000);
                        v256 result_1000000000 = mm256_cmpge_epu32(a, MASK_1000000000);

                        result_10 = mm256_abs_epi32(result_10);
                        result_100 = mm256_abs_epi32(result_100);
                        result_1000 = mm256_abs_epi32(result_1000);
                        result_10000 = mm256_abs_epi32(result_10000);

                        result_10 = Avx2.mm256_sub_epi32(result_10, result_100000);
                        result_100 = Avx2.mm256_sub_epi32(result_100, result_1000000);
                        result_1000 = Avx2.mm256_sub_epi32(result_1000, result_10000000);
                        result_10000 = Avx2.mm256_sub_epi32(result_10000, result_100000000);

                        result_10 = Avx2.mm256_sub_epi32(result_10, result_1000000000);

                        result_100 = Avx2.mm256_add_epi32(result_100, result_1000);
                        result_1000 = Avx2.mm256_add_epi32(result_10000, result_10);

                        v256 result = Avx2.mm256_add_epi32(result_100, result_1000);

                        constexpr.ASSUME_LE_EPU32(result, 9);

                        constexpr.ASSUME_LE_EPU32(result, a);
                        if (constexpr.ALL_GT_EPU32(a, 1))
                        {
                            constexpr.ASSUME_LT_EPU32(result, a);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 log10_epi32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<int4, int>(a, 0, elements);
constexpr.ASSUME_GE_EPI32(a, 0, elements);

                    if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements))
                    {
                        return log10_epu16(a, (byte)(elements * 2)); // 0 stays 0 (high bits)
                    }
                    else
                    {
                        v128 result;

                        switch(elements)
                        {
                            case 4:
                            {
                                v128 MASK_9 = set1_epi32(9);
                                v128 MASK_99 = set1_epi32(99);
                                v128 MASK_999 = set1_epi32(999);
                                v128 MASK_9999 = set1_epi32(9_999);
                                v128 MASK_99999 = set1_epi32(99_999);
                                v128 MASK_999999 = set1_epi32(999_999);
                                v128 MASK_9999999 = set1_epi32(9_999_999);
                                v128 MASK_99999999 = set1_epi32(99_999_999);
                                v128 MASK_999999999 = set1_epi32(999_999_999);

                                v128 result_9 = cmpgt_epi32(a, MASK_9);
                                v128 result_99 = cmpgt_epi32(a, MASK_99);
                                v128 result_999 = cmpgt_epi32(a, MASK_999);
                                v128 result_9999 = cmpgt_epi32(a, MASK_9999);
                                v128 result_99999 = cmpgt_epi32(a, MASK_99999);
                                v128 result_999999 = cmpgt_epi32(a, MASK_999999);
                                v128 result_9999999 = cmpgt_epi32(a, MASK_9999999);
                                v128 result_99999999 = cmpgt_epi32(a, MASK_99999999);
                                v128 result_999999999 = cmpgt_epi32(a, MASK_999999999);

                                result_9 = neg_epi32(result_9);
                                result_99 = neg_epi32(result_99);
                                result_999 = neg_epi32(result_999);
                                result_9999 = neg_epi32(result_9999);

                                result_9 = sub_epi32(result_9, result_99999);
                                result_99 = sub_epi32(result_99, result_999999);
                                result_999 = sub_epi32(result_999, result_9999999);
                                result_9999 = sub_epi32(result_9999, result_99999999);

                                result_9 = sub_epi32(result_9, result_999999999);

                                result_99 = add_epi32(result_99, result_999);
                                result_999 = add_epi32(result_9999, result_9);

                                result = add_epi32(result_99, result_999);

                                break;
                            }
                            case 3:
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    v256 MASK = new v256(9, 99, 999, 9_999, 99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 LAST = new v128(999_999_999);

                                    v256 _x = Avx2.mm256_broadcastd_epi32(a);
                                    v256 _y = Avx2.mm256_broadcastd_epi32(bsrli_si128(a, 1 * sizeof(int)));
                                    v256 _z = Avx2.mm256_broadcastd_epi32(bsrli_si128(a, 2 * sizeof(int)));

                                    v256 resultX = Avx2.mm256_cmpgt_epi32(_x, MASK);
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = Avx2.mm256_cmpgt_epi32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);
                                    v256 resultZ = Avx2.mm256_cmpgt_epi32(_z, MASK);
                                    v128 hiZ = Avx2.mm256_extracti128_si256(resultZ, 1);

                                    v128 resultX128 = abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = abs_epi32(Avx.mm256_castsi256_si128(resultY));
                                    v128 resultZ128 = abs_epi32(Avx.mm256_castsi256_si128(resultZ));

                                    v128 lastCMP = cmpgt_epi32(a, LAST);

                                    resultX128 = sub_epi32(resultX128, hiX);
                                    resultY128 = sub_epi32(resultY128, hiY);
                                    resultZ128 = sub_epi32(resultZ128, hiZ);

                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 2 * sizeof(int)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 2 * sizeof(int)));
                                    resultZ128 = add_epi32(resultZ128, bsrli_si128(resultZ128, 2 * sizeof(int)));
                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 1 * sizeof(int)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 1 * sizeof(int)));
                                    resultZ128 = add_epi32(resultZ128, bsrli_si128(resultZ128, 1 * sizeof(int)));

                                    v128 xy = unpacklo_epi32(resultX128, resultY128);
                                    result = unpacklo_epi64(xy, resultZ128);
                                    result = sub_epi32(result, lastCMP);
                                }
                                else
                                {
                                    v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                    v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 MASK_LAST = new v128(999_999_999);

                                    v128 xxxx = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                    v128 zzzz = shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2));

                                    v128 xResult = cmpgt_epi32(xxxx, MASK_SMALL);
                                    v128 yResult = cmpgt_epi32(yyyy, MASK_SMALL);
                                    v128 zResult = cmpgt_epi32(zzzz, MASK_SMALL);

                                    xResult = neg_epi32(xResult);
                                    yResult = neg_epi32(yResult);
                                    zResult = neg_epi32(zResult);
                                    xResult = sub_epi32(xResult, cmpgt_epi32(xxxx, MASK_LARGE));
                                    yResult = sub_epi32(yResult, cmpgt_epi32(yyyy, MASK_LARGE));
                                    zResult = sub_epi32(zResult, cmpgt_epi32(zzzz, MASK_LARGE));
                                    xResult = add_epi32(xResult, bsrli_si128(xResult, 2 * sizeof(int)));
                                    yResult = add_epi32(yResult, bsrli_si128(yResult, 2 * sizeof(int)));
                                    zResult = add_epi32(zResult, bsrli_si128(zResult, 2 * sizeof(int)));
                                    xResult = add_epi32(xResult, bsrli_si128(xResult, 1 * sizeof(int)));
                                    yResult = add_epi32(yResult, bsrli_si128(yResult, 1 * sizeof(int)));
                                    zResult = add_epi32(zResult, bsrli_si128(zResult, 1 * sizeof(int)));

                                    v128 lastCMP = cmpgt_epi32(a, MASK_LAST);

                                    v128 xy = unpacklo_epi32(xResult, yResult);
                                    result = unpacklo_epi64(xy, zResult);
                                    result = sub_epi32(result, lastCMP);
                                }

                                break;
                            }
                            case 2:
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    v256 MASK = new v256(9, 99, 999, 9_999, 99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 LAST = Xse.cvtsi64x_si128((999_999_999L << 32) | 999_999_999);

                                    v256 _x = Avx2.mm256_broadcastd_epi32(a);
                                    v256 _y = Avx2.mm256_broadcastd_epi32(bsrli_si128(a, 1 * sizeof(int)));

                                    v256 resultX = Avx2.mm256_cmpgt_epi32(_x, MASK);
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = Avx2.mm256_cmpgt_epi32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);

                                    v128 resultX128 = abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = abs_epi32(Avx.mm256_castsi256_si128(resultY));

                                    v128 lastCMP = cmpgt_epi32(a, LAST);

                                    resultX128 = sub_epi32(resultX128, hiX);
                                    resultY128 = sub_epi32(resultY128, hiY);

                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 2 * sizeof(int)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 2 * sizeof(int)));
                                    resultX128 = add_epi32(resultX128, bsrli_si128(resultX128, 1 * sizeof(int)));
                                    resultY128 = add_epi32(resultY128, bsrli_si128(resultY128, 1 * sizeof(int)));

                                    result = unpacklo_epi32(resultX128, resultY128);
                                    result = sub_epi32(result, lastCMP);
                                }
                                else
                                {
                                    v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                    v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 MASK_LAST  = cvtsi64x_si128((999_999_999L << 32) | 999_999_999L);

                                    v128 xxxx = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));

                                    v128 xResult = cmpgt_epi32(xxxx, MASK_SMALL);
                                    v128 yResult = cmpgt_epi32(yyyy, MASK_SMALL);

                                    xResult = neg_epi32(xResult);
                                    yResult = neg_epi32(yResult);
                                    xResult = sub_epi32(xResult, cmpgt_epi32(xxxx, MASK_LARGE));
                                    yResult = sub_epi32(yResult, cmpgt_epi32(yyyy, MASK_LARGE));
                                    xResult = add_epi32(xResult, bsrli_si128(xResult, 2 * sizeof(int)));
                                    yResult = add_epi32(yResult, bsrli_si128(yResult, 2 * sizeof(int)));
                                    xResult = add_epi32(xResult, bsrli_si128(xResult, 1 * sizeof(int)));
                                    yResult = add_epi32(yResult, bsrli_si128(yResult, 1 * sizeof(int)));

                                    v128 lastCMP = cmpgt_epi32(a, MASK_LAST);

                                    result = unpacklo_epi32(xResult, yResult);
                                    result = sub_epi32(result, lastCMP);
                                }
                                break;
                            }
                            default: result = a; break;
                        }

                        constexpr.ASSUME_LE_EPU32(result, 9, elements);

                        constexpr.ASSUME_LE_EPU32(result, a, elements);
                        if (constexpr.ALL_GT_EPU32(a, 1, elements))
                        {
                            constexpr.ASSUME_LT_EPU32(result, a, elements);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_log10_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotSmaller<int8, int>(a, 0, 8);
constexpr.ASSUME_GE_EPI32(a, 0, 8);

                    if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue))
                    {
                        return mm256_log10_epu16(a); // 0 stays 0 (high bits)
                    }
                    else
                    {
                        v256 MASK_9 = mm256_set1_epi32(9);
                        v256 MASK_99 = mm256_set1_epi32(99);
                        v256 MASK_999 = mm256_set1_epi32(999);
                        v256 MASK_9999 = mm256_set1_epi32(9_999);
                        v256 MASK_99999 = mm256_set1_epi32(99_999);
                        v256 MASK_999999 = mm256_set1_epi32(999_999);
                        v256 MASK_9999999 = mm256_set1_epi32(9_999_999);
                        v256 MASK_99999999 = mm256_set1_epi32(99_999_999);
                        v256 MASK_999999999 = mm256_set1_epi32(999_999_999);

                        v256 result_9 = Avx2.mm256_cmpgt_epi32(a, MASK_9);
                        v256 result_99 = Avx2.mm256_cmpgt_epi32(a, MASK_99);
                        v256 result_999 = Avx2.mm256_cmpgt_epi32(a, MASK_999);
                        v256 result_9999 = Avx2.mm256_cmpgt_epi32(a, MASK_9999);
                        v256 result_99999 = Avx2.mm256_cmpgt_epi32(a, MASK_99999);
                        v256 result_999999 = Avx2.mm256_cmpgt_epi32(a, MASK_999999);
                        v256 result_9999999 = Avx2.mm256_cmpgt_epi32(a, MASK_9999999);
                        v256 result_99999999 = Avx2.mm256_cmpgt_epi32(a, MASK_99999999);
                        v256 result_999999999 = Avx2.mm256_cmpgt_epi32(a, MASK_999999999);

                        result_9 = mm256_abs_epi32(result_9);
                        result_99 = mm256_abs_epi32(result_99);
                        result_999 = mm256_abs_epi32(result_999);
                        result_9999 = mm256_abs_epi32(result_9999);

                        result_9 = Avx2.mm256_sub_epi32(result_9, result_99999);
                        result_99 = Avx2.mm256_sub_epi32(result_99, result_999999);
                        result_999 = Avx2.mm256_sub_epi32(result_999, result_9999999);
                        result_9999 = Avx2.mm256_sub_epi32(result_9999, result_99999999);

                        result_9 = Avx2.mm256_sub_epi32(result_9, result_999999999);

                        result_99 = Avx2.mm256_add_epi32(result_99, result_999);
                        result_999 = Avx2.mm256_add_epi32(result_9999, result_9);

                        v256 result = Avx2.mm256_add_epi32(result_99, result_999);

                        constexpr.ASSUME_LE_EPU32(result, 9);

                        constexpr.ASSUME_LE_EPU32(result, a);
                        if (constexpr.ALL_GT_EPU32(a, 1))
                        {
                            constexpr.ASSUME_LT_EPU32(result, a);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v128 log10_epu64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                    {
                        return log10_epu32(a);
                    }
                }

                v128 result = new v128(math.intlog10(a.ULong0), math.intlog10(a.ULong1));

                constexpr.ASSUME_LE_EPU64(result, 19);

                constexpr.ASSUME_LE_EPU64(result, a);
                if (constexpr.ALL_GT_EPU64(a, 1))
                {
                    constexpr.ASSUME_LT_EPU64(result, a);
                }

                return result;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v256 mm256_log10_epu64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                    {
                        return mm256_log10_epu32(a);
                    }
                    else
                    {
                        v256 result = new v256(math.intlog10(a.ULong0), math.intlog10(a.ULong1), math.intlog10(a.ULong2), math.intlog10(a.ULong3));

                        constexpr.ASSUME_LE_EPU64(result, 19, elements);

                        constexpr.ASSUME_LE_EPU64(result, a);
                        if (constexpr.ALL_GT_EPU64(a, 1, elements))
                        {
                            constexpr.ASSUME_LT_EPU64(result, a, elements);
                        }

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v128 log10_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotSmaller<long2, long>(a, 0, 2);
constexpr.ASSUME_GE_EPI64(a, 0, 2);

                    return log10_epu64(a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SkipLocalsInit]
            public static v256 mm256_log10_epi64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotSmaller<long4, long>(a, 0, elements);
constexpr.ASSUME_GE_EPI64(a, 0, elements);

                    return mm256_log10_epu64(a, elements);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0, 38)]
        public static long intlog10(Int128 x)
        {
            return (long)intlog10((UInt128)x);
        }

        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0ul, 38ul)]
        [SkipLocalsInit]
        public static ulong intlog10(UInt128 x)
        {
            if (Hint.Unlikely(x.hi64 == 0))
            {
                return intlog10(x.lo64);
            }
            else
            {
                uint result = 128 - (uint)lzcnt(x.hi64);
                result = (result * 157_287) >> 19;
                UInt128 guess1;
                uint lutIdx = result - 19;
                constexpr.ASSUME(lutIdx >= 0 && lutIdx <= 19);
                switch (lutIdx)
                {
                    case 0:  guess1 = 10000000000000000000ul; break;
                    case 1:  guess1 = /*100000000000000000000: */ new UInt128(0x6BC7_5E2D_6310_0000, 0x0000_0000_0000_0005); break;
                    case 2:  guess1 = /*1000000000000000000000: */ new UInt128(0x35C9_ADC5_DEA0_0000, 0x0000_0000_0000_0036); break;
                    case 3:  guess1 = /*10000000000000000000000: */ new UInt128(0x19E0_C9BA_B240_0000, 0x0000_0000_0000_021E); break;
                    case 4:  guess1 = /*100000000000000000000000: */ new UInt128(0x02C7_E14A_F680_0000, 0x0000_0000_0000_152D); break;
                    case 5:  guess1 = /*1000000000000000000000000: */ new UInt128(0x1BCE_CCED_A100_0000, 0x0000_0000_0000_D3C2); break;
                    case 6:  guess1 = /*10000000000000000000000000: */ new UInt128(0x1614_0148_4A00_0000, 0x0000_0000_0008_4595); break;
                    case 7:  guess1 = /*100000000000000000000000000: */ new UInt128(0xDCC8_0CD2_E400_0000, 0x0000_0000_0052_B7D2); break;
                    case 8:  guess1 = /*1000000000000000000000000000: */ new UInt128(0x9FD0_803C_E800_0000, 0x0000_0000_033B_2E3C); break;
                    case 9:  guess1 = /*10000000000000000000000000000: */ new UInt128(0x3E25_0261_1000_0000, 0x0000_0000_204F_CE5E); break;
                    case 10: guess1 = /*100000000000000000000000000000: */ new UInt128(0x6D72_17CA_A000_0000, 0x0000_0001_431E_0FAE); break;
                    case 11: guess1 = /*1000000000000000000000000000000: */ new UInt128(0x4674_EDEA_4000_0000, 0x0000_000C_9F2C_9CD0); break;
                    case 12: guess1 = /*10000000000000000000000000000000: */ new UInt128(0xC091_4B26_8000_0000, 0x0000_007E_37BE_2022); break;
                    case 13: guess1 = /*100000000000000000000000000000000: */ new UInt128(0x85AC_EF81_0000_0000, 0x0000_04EE_2D6D_415B); break;
                    case 14: guess1 = /*1000000000000000000000000000000000: */ new UInt128(0x38C1_5B0A_0000_0000, 0x0000_314D_C644_8D93); break;
                    case 15: guess1 = /*10000000000000000000000000000000000: */ new UInt128(0x378D_8E64_0000_0000, 0x0001_ED09_BEAD_87C0); break;
                    case 16: guess1 = /*100000000000000000000000000000000000: */ new UInt128(0x2B87_8FE8_0000_0000, 0x0013_4261_72C7_4D82); break;
                    case 17: guess1 = /*1000000000000000000000000000000000000: */ new UInt128(0xB34B_9F10_0000_0000, 0x00C0_97CE_7BC9_0715); break;
                    case 18: guess1 = /*10000000000000000000000000000000000000: */ new UInt128(0x00F4_36A0_0000_0000, 0x0785_EE10_D5DA_46D9); break;
                    case 19: guess1 = /*100000000000000000000000000000000000000: */ new UInt128(0x098A_2240_0000_0000, 0x4B3B_4CA8_5A86_C47A); break;

                    default: throw Assert.Unreachable();
                };
                result -= tobyte(x < guess1);

                // fails at 10^31 = 10000000000000000000000000000000
                // fails at 10^34 = 10000000000000000000000000000000000
                // fails at 10^37 = 10000000000000000000000000000000000000
                // thus...
                if (Hint.Unlikely(result >= 30 & isdivisible(result, 3)))
                {
                    UInt128 guess2;
                    lutIdx = result - 18;
                    constexpr.ASSUME(lutIdx >= 0 && lutIdx <= 19); // ensuring the same switch table is used
                    switch (lutIdx)
                    {
                        case 0:  guess2 = 10000000000000000000ul; break;
                        case 1:  guess2 = /*100000000000000000000: */ new UInt128(0x6BC7_5E2D_6310_0000, 0x0000_0000_0000_0005); break;
                        case 2:  guess2 = /*1000000000000000000000: */ new UInt128(0x35C9_ADC5_DEA0_0000, 0x0000_0000_0000_0036); break;
                        case 3:  guess2 = /*10000000000000000000000: */ new UInt128(0x19E0_C9BA_B240_0000, 0x0000_0000_0000_021E); break;
                        case 4:  guess2 = /*100000000000000000000000: */ new UInt128(0x02C7_E14A_F680_0000, 0x0000_0000_0000_152D); break;
                        case 5:  guess2 = /*1000000000000000000000000: */ new UInt128(0x1BCE_CCED_A100_0000, 0x0000_0000_0000_D3C2); break;
                        case 6:  guess2 = /*10000000000000000000000000: */ new UInt128(0x1614_0148_4A00_0000, 0x0000_0000_0008_4595); break;
                        case 7:  guess2 = /*100000000000000000000000000: */ new UInt128(0xDCC8_0CD2_E400_0000, 0x0000_0000_0052_B7D2); break;
                        case 8:  guess2 = /*1000000000000000000000000000: */ new UInt128(0x9FD0_803C_E800_0000, 0x0000_0000_033B_2E3C); break;
                        case 9:  guess2 = /*10000000000000000000000000000: */ new UInt128(0x3E25_0261_1000_0000, 0x0000_0000_204F_CE5E); break;
                        case 10: guess2 = /*100000000000000000000000000000: */ new UInt128(0x6D72_17CA_A000_0000, 0x0000_0001_431E_0FAE); break;
                        case 11: guess2 = /*1000000000000000000000000000000: */ new UInt128(0x4674_EDEA_4000_0000, 0x0000_000C_9F2C_9CD0); break;
                        case 12: guess2 = /*10000000000000000000000000000000: */ new UInt128(0xC091_4B26_8000_0000, 0x0000_007E_37BE_2022); break;
                        case 13: guess2 = /*100000000000000000000000000000000: */ new UInt128(0x85AC_EF81_0000_0000, 0x0000_04EE_2D6D_415B); break;
                        case 14: guess2 = /*1000000000000000000000000000000000: */ new UInt128(0x38C1_5B0A_0000_0000, 0x0000_314D_C644_8D93); break;
                        case 15: guess2 = /*10000000000000000000000000000000000: */ new UInt128(0x378D_8E64_0000_0000, 0x0001_ED09_BEAD_87C0); break;
                        case 16: guess2 = /*100000000000000000000000000000000000: */ new UInt128(0x2B87_8FE8_0000_0000, 0x0013_4261_72C7_4D82); break;
                        case 17: guess2 = /*1000000000000000000000000000000000000: */ new UInt128(0xB34B_9F10_0000_0000, 0x00C0_97CE_7BC9_0715); break;
                        case 18: guess2 = /*10000000000000000000000000000000000000: */ new UInt128(0x00F4_36A0_0000_0000, 0x0785_EE10_D5DA_46D9); break;
                        case 19: guess2 = /*100000000000000000000000000000000000000: */ new UInt128(0x098A_2240_0000_0000, 0x4B3B_4CA8_5A86_C47A); break;

                        default: throw Assert.Unreachable();
                    };

                    result += tobyte(x >= guess2);
                }

                constexpr.ASSUME(result <= x);
                if (constexpr.IS_TRUE(x > 1))
                {
                    constexpr.ASSUME(result < x);
                }

                return result;
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0ul, 2ul)]
        public static byte intlog10(byte x)
        {
            byte result = (byte)(tobyte(x >= 10) + tobyte(x >= 100));
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }

            return result;
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intlog10(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu8(x, 2);
            }
            else
            {
                return new byte2(intlog10(x.x), intlog10(x.y));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intlog10(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu8(x, 3);
            }
            else
            {
                return new byte3(intlog10(x.x), intlog10(x.y), intlog10(x.z));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intlog10(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu8(x, 4);
            }
            else
            {
                return new byte4(intlog10(x.x), intlog10(x.y), intlog10(x.z), intlog10(x.w));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intlog10(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu8(x, 8);
            }
            else
            {
                return new byte8(intlog10(x.x0),
                                 intlog10(x.x1),
                                 intlog10(x.x2),
                                 intlog10(x.x3),
                                 intlog10(x.x4),
                                 intlog10(x.x5),
                                 intlog10(x.x6),
                                 intlog10(x.x7));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intlog10(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu8(x, 16);
            }
            else
            {
                return new byte16(intlog10(x.x0),
                                  intlog10(x.x1),
                                  intlog10(x.x2),
                                  intlog10(x.x3),
                                  intlog10(x.x4),
                                  intlog10(x.x5),
                                  intlog10(x.x6),
                                  intlog10(x.x7),
                                  intlog10(x.x8),
                                  intlog10(x.x9),
                                  intlog10(x.x10),
                                  intlog10(x.x11),
                                  intlog10(x.x12),
                                  intlog10(x.x13),
                                  intlog10(x.x14),
                                  intlog10(x.x15));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intlog10(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epu8(x);
            }
            else
            {
                return new byte32(intlog10(x.v16_0),
                                  intlog10(x.v16_16));
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0, 2)]
        public static sbyte intlog10(sbyte x)
        {
            sbyte result = (sbyte)(tobyte(x >= 10) + tobyte(x >= 100));
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }

            return result;
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intlog10(sbyte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi8(x, 2);
            }
            else
            {
                return new sbyte2(intlog10(x.x), intlog10(x.y));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intlog10(sbyte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi8(x, 3);
            }
            else
            {
                return new sbyte3(intlog10(x.x), intlog10(x.y), intlog10(x.z));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intlog10(sbyte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi8(x, 4);
            }
            else
            {
                return new sbyte4(intlog10(x.x), intlog10(x.y), intlog10(x.z), intlog10(x.w));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intlog10(sbyte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi8(x, 8);
            }
            else
            {
                return new sbyte8(intlog10(x.x0),
                                  intlog10(x.x1),
                                  intlog10(x.x2),
                                  intlog10(x.x3),
                                  intlog10(x.x4),
                                  intlog10(x.x5),
                                  intlog10(x.x6),
                                  intlog10(x.x7));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intlog10(sbyte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi8(x);
            }
            else
            {
                return new sbyte16(intlog10(x.x0),
                                   intlog10(x.x1),
                                   intlog10(x.x2),
                                   intlog10(x.x3),
                                   intlog10(x.x4),
                                   intlog10(x.x5),
                                   intlog10(x.x6),
                                   intlog10(x.x7),
                                   intlog10(x.x8),
                                   intlog10(x.x9),
                                   intlog10(x.x10),
                                   intlog10(x.x11),
                                   intlog10(x.x12),
                                   intlog10(x.x13),
                                   intlog10(x.x14),
                                   intlog10(x.x15));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intlog10(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epi8(x);
            }
            else
            {
                return new sbyte32(intlog10(x.v16_0),
                                   intlog10(x.v16_16));
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0ul, 4ul)]
        public static ushort intlog10(ushort x)
        {
            if (constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intlog10((byte)x);
            }

            ushort result = (ushort)(tobyte(x >= 10) + tobyte(x >= 100) + tobyte(x >= 1_000) + tobyte(x >= 10_000));
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }

            return result;
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intlog10(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu16(x, 2);
            }
            else
            {
                return new ushort2(intlog10(x.x), intlog10(x.y));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intlog10(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu16(x, 3);
            }
            else
            {
                return new ushort3(intlog10(x.x), intlog10(x.y), intlog10(x.z));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intlog10(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu16(x, 4);
            }
            else
            {
                return new ushort4(intlog10(x.x), intlog10(x.y), intlog10(x.z), intlog10(x.w));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intlog10(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu16(x, 8);
            }
            else
            {
                return new ushort8(intlog10(x.x0),
                                   intlog10(x.x1),
                                   intlog10(x.x2),
                                   intlog10(x.x3),
                                   intlog10(x.x4),
                                   intlog10(x.x5),
                                   intlog10(x.x6),
                                   intlog10(x.x7));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intlog10(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epu16(x);
            }
            else
            {
                return new ushort16(intlog10(x.v8_0),
                                    intlog10(x.v8_8));
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0, 4)]
        public static short intlog10(short x)
        {
            if (constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intlog10((byte)x);
            }

            short result = (short)(tobyte(x >= 10) + tobyte(x >= 100) + tobyte(x >= 1_000) + tobyte(x >= 10_000));
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }

            return result;
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intlog10(short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi16(x, 2);
            }
            else
            {
                return new short2(intlog10(x.x), intlog10(x.y));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intlog10(short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi16(x, 3);
            }
            else
            {
                return new short3(intlog10(x.x), intlog10(x.y), intlog10(x.z));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intlog10(short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi16(x, 4);
            }
            else
            {
                return new short4(intlog10(x.x), intlog10(x.y), intlog10(x.z), intlog10(x.w));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intlog10(short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi16(x, 8);
            }
            else
            {
                return new short8(intlog10(x.x0),
                                  intlog10(x.x1),
                                  intlog10(x.x2),
                                  intlog10(x.x3),
                                  intlog10(x.x4),
                                  intlog10(x.x5),
                                  intlog10(x.x6),
                                  intlog10(x.x7));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intlog10(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epi16(x);
            }
            else
            {
                return new short16(intlog10(x.v8_0),
                                   intlog10(x.v8_8));
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [return: AssumeRange(0ul, 9ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intlog10(uint x)
        {
            if (constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                return intlog10((ushort)x);
            }

            uint result;

            if (Sse4_1.IsSse41Supported)
            {
                v128 MASK_SMALL = new v128(10, 100, 1_000, 10_000);
                v128 MASK_LARGE = new v128(100_000, 1_000_000, 10_000_000, 100_000_000);

                v128 splat = Xse.set1_epi32(x);

                v128 cmp = Xse.cmpge_epu32(splat, MASK_SMALL);
                cmp = Xse.add_epi32(cmp, Xse.cmpge_epu32(splat, MASK_LARGE));

                result = tobyte(x >= 1_000_000_000) - Xse.vsum_epi32(cmp, true, 4).UInt0;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);

                v128 splat = Xse.set1_epi32(x);

                v128 cmp = Xse.cmpgt_epu32(splat, MASK_SMALL);
                cmp = Xse.add_epi32(cmp, Xse.cmpgt_epu32(splat, MASK_LARGE));

                result = tobyte(x >= 1_000_000_000) - Xse.vsum_epi32(cmp, true, 4).UInt0;
            }
            else
            {
                ulong* guess = stackalloc ulong[33]
                {
                    (9ul << 32) - 1000000000,   (9ul << 32) - 1000000000,   (9ul << 32) - 1000000000,
                    (8ul << 32) - 100000000,   (8ul << 32) - 100000000,   (8ul << 32) - 100000000,
                    (7ul << 32) - 10000000,   (7ul << 32) - 10000000,   (7ul << 32) - 10000000,
                    (6ul << 32) - 1000000,   (6ul << 32) - 1000000,   (6ul << 32) - 1000000,   (6ul << 32) - 1000000,
                    (5ul << 32) - 100000,   (5ul << 32) - 100000,   (5ul << 32) - 100000,
                    (4ul << 32) - 10000,   (4ul << 32) - 10000,   (4ul << 32) - 10000,
                    (3ul << 32) - 1000,   (3ul << 32) - 1000,   (3ul << 32) - 1000,   (3ul << 32) - 1000,
                    (2ul << 32) - 100,   (2ul << 32) - 100,   (2ul << 32) - 100,
                    (1ul << 32) - 10,   (1ul << 32) - 10,   (1ul << 32) - 10,
                    0,                 0,                  0,                   0
                };

                ulong adjust = guess[lzcnt(x)];

                result = (uint)((adjust + x) >> 32);
            }
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }

            return result;
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint2 intlog10(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu32(x, 2);
            }
            else
            {
                return new uint2(intlog10(x.x), intlog10(x.y));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint3 intlog10(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu32(x, 3);
            }
            else
            {
                return new uint3(intlog10(x.x), intlog10(x.y), intlog10(x.z));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint4 intlog10(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu32(x, 4);
            }
            else
            {
                return new uint4(intlog10(x.x), intlog10(x.y), intlog10(x.z), intlog10(x.w));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint8 intlog10(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epu32(x);
            }
            else
            {
                return new uint8(intlog10(x.v4_0), intlog10(x.v4_4));
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0, 9)]
        public static int intlog10(int x)
        {
            if (constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                return intlog10((short)x);
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);

                v128 splat = Xse.set1_epi32(x);
                v128 cmp = Xse.cmpgt_epi32(splat, MASK_SMALL);

                cmp = Xse.add_epi32(cmp, Xse.cmpgt_epi32(splat, MASK_LARGE));
                cmp = Xse.vsum_epi32(cmp, true);

                int result = tobyte(x > 999_999_999) - cmp.SInt0;
            
                constexpr.ASSUME(result <= x);
                if (constexpr.IS_TRUE(x > 1))
                {
                    constexpr.ASSUME(result < x);
                }

                return result;
            }
            else
            {
                return (int)intlog10((uint)x);
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int2 intlog10(int2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi32(x, 2);
            }
            else
            {
                return (int2)intlog10((uint2)x);
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int3 intlog10(int3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi32(x, 3);
            }
            else
            {
                return (int3)intlog10((uint3)x);
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int4 intlog10(int4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi32(x, 4);
            }
            else
            {
                return (int4)intlog10((uint4)x);
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static int8 intlog10(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epi32(x);
            }
            else
            {
                return new int8(intlog10(x.v4_0), intlog10(x.v4_4));
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0ul, 19ul)]
        [SkipLocalsInit]
        public static ulong intlog10(ulong x)
        {
            if (constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intlog10((uint)x);
            }

            UInt128 guess;
            switch (lzcnt(x))
            {
                case 0: 
                    guess = new UInt128(0, 19) - 10000000000000000000ul; break;
                case 1: 
                case 2: 
                case 3: 
                case 4:
                    guess = new UInt128(0, 18) - 1000000000000000000ul; break;
                case 5:
                case 6: 
                case 7: 
                    guess = new UInt128(0, 17) - 100000000000000000ul; break;
                case 8: 
                case 9: 
                case 10:
                    guess = new UInt128(0, 16) - 10000000000000000ul; break;
                case 11:
                case 12:
                case 13:
                case 14:
                    guess = new UInt128(0, 15) - 1000000000000000ul; break;
                case 15:
                case 16:
                case 17:
                    guess = new UInt128(0, 14) - 100000000000000ul; break;
                case 18:
                case 19:
                case 20:
                    guess = new UInt128(0, 13) - 10000000000000ul; break;
                case 21:
                case 22:
                case 23:
                case 24:
                    guess = new UInt128(0, 12) - 1000000000000ul; break;
                case 25:
                case 26:
                case 27:
                    guess = new UInt128(0, 11) - 100000000000ul; break;
                case 28:
                case 29:
                case 30:
                    guess = new UInt128(0, 10) - 10000000000ul; break;
                case 31:
                case 32:
                case 33:
                case 34:
                    guess = new UInt128(0, 9)  - 1000000000ul; break;
                case 35:
                case 36:
                case 37:
                    guess = new UInt128(0, 8)  - 100000000ul; break;
                case 38:
                case 39:
                case 40:
                    guess = new UInt128(0, 7)  - 10000000ul; break;
                case 41:
                case 42:
                case 43:
                case 44:
                    guess = new UInt128(0, 6)  - 1000000ul; break;
                case 45:
                case 46:
                case 47:
                    guess = new UInt128(0, 5)  - 100000ul; break;
                case 48:
                case 49:
                case 50:
                    guess = new UInt128(0, 4)  - 10000ul; break;
                case 51:
                case 52:
                case 53:
                case 54:
                    guess = new UInt128(0, 3)  - 1000ul; break;
                case 55:
                case 56:
                case 57:
                    guess = new UInt128(0, 2)  - 100ul; break;
                case 58:
                case 59:
                case 60:
                    guess = new UInt128(0, 1)  - 10ul; break;
                case 61:
                case 62:
                case 63:
                case 64:
                    guess = new UInt128(0, 0); break;

                default: throw DevTools.Assert.Unreachable();
            };

            ulong result = (guess + x).hi64;
            
            constexpr.ASSUME(result <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(result < x);
            }

            return result;
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intlog10(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epu64(x);
            }
            else
            {
                return new ulong2(intlog10(x.x), intlog10(x.y));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intlog10(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epu64(x, 3);
            }
            else
            {
                return new ulong3(intlog10(x.xy), intlog10(x.z));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intlog10(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epu64(x, 4);
            }
            else
            {
                return new ulong4(intlog10(x.xy), intlog10(x.zw));
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: AssumeRange(0, 18)]
        [SkipLocalsInit]
        public static long intlog10(long x)
        {
            if (constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intlog10((uint)x);
            }

            return (long)intlog10((ulong)x);
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intlog10(long2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.log10_epi64(x);
            }
            else
            {
                return new long2(intlog10(x.x), intlog10(x.y));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intlog10(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epi64(x, 3);
            }
            else
            {
                return new long3(intlog10(x.xy), intlog10(x.z));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intlog10(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_log10_epi64(x, 4);
            }
            else
            {
                return new long4(intlog10(x.xy), intlog10(x.zw));
            }
        }
    }
}