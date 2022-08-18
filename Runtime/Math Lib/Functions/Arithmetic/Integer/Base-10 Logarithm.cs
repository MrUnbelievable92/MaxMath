using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
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
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU8(a, (byte)sbyte.MaxValue, elements))
                    {
                        return log10_epi8(a);
                    }
                    else
                    {
                        v128 TEN = Sse2.set1_epi8(10);
                        v128 HUNDRED = Sse2.set1_epi8(100);

                        v128 result = cmpge_epu8(a, TEN, elements);
                        result = negmask_epi8(result);
                        result = Sse2.sub_epi8(result, cmpge_epu8(a, HUNDRED, elements));

                        constexpr.ASSUME_LE_EPU8(a, 2);

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
                        v256 TEN = Avx.mm256_set1_epi8(10);
                        v256 HUNDRED = Avx.mm256_set1_epi8(100);

                        v256 result = mm256_cmpge_epu8(a, TEN);
                        result = Avx2.mm256_abs_epi8(result);
                        result = Avx2.mm256_sub_epi8(result, mm256_cmpge_epu8(a, HUNDRED));
                        
                        constexpr.ASSUME_LE_EPU8(a, 2);

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            public static v128 log10_epi8(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 NINE = Sse2.set1_epi8(9);
                    v128 NINETY_NINE = Sse2.set1_epi8(99);

                    v128 result = Sse2.cmpgt_epi8(a, NINE);
                    result = negmask_epi8(result);
                    result = Sse2.sub_epi8(result, Sse2.cmpgt_epi8(a, NINETY_NINE));

                    constexpr.ASSUME_LE_EPU8(a, 2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            public static v256 mm256_log10_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 NINE = Avx.mm256_set1_epi8(9);
                    v256 NINETY_NINE = Avx.mm256_set1_epi8(99);

                    v256 result = Avx2.mm256_cmpgt_epi8(a, NINE);
                    result = Avx2.mm256_abs_epi8(result);
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_cmpgt_epi8(a, NINETY_NINE));

                    constexpr.ASSUME_LE_EPU8(a, 2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            public static v128 log10_epu16(v128 a, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue))
                    {
                        return log10_epi16(a, elements);
                    }
                    else 
                    {
                        if (elements == 2)
                        {
                            v128 cmp = new v128(10, 10,   100, 100,   1_000, 1_000,   10_000, 10_000);

                            v128 splat = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                            v128 cmp_negated = cmpge_epu16(splat, cmp);
                            cmp = negmask_epi16(cmp_negated); 
                            cmp = Sse2.sub_epi16(cmp, Sse2.bsrli_si128(cmp_negated, 4 * sizeof(short)));
                            cmp = Sse2.add_epi16(cmp, Sse2.bsrli_si128(cmp, 2 * sizeof(short)));

                            return cmp;
                        }
                        else
                        {
                            v128 result;

                            if (Sse4_1.IsSse41Supported)
                            {
                                v128 _0 = Sse2.set1_epi16(10);
                                v128 _1 = Sse2.set1_epi16(100);
                                v128 _2 = Sse2.set1_epi16(1_000);
                                v128 _3 = Sse2.set1_epi16(10_000);

                                result = Ssse3.abs_epi16(cmpge_epu16(a, _0, elements));
                                result = Sse2.sub_epi16(result, cmpge_epu16(a, _1, elements));
                                result = Sse2.sub_epi16(result, cmpge_epu16(a, _2, elements));
                                result = Sse2.sub_epi16(result, cmpge_epu16(a, _3, elements));
                            }
                            else
                            {
                                v128 _0 = Sse2.set1_epi16(9);
                                v128 _1 = Sse2.set1_epi16(99);
                                v128 _2 = Sse2.set1_epi16(999);
                                v128 _3 = Sse2.set1_epi16(9_999);

                                result = neg_epi16(cmpgt_epu16(a, _0, elements));
                                result = Sse2.sub_epi16(result, cmpgt_epu16(a, _1, elements));
                                result = Sse2.sub_epi16(result, cmpgt_epu16(a, _2, elements));
                                result = Sse2.sub_epi16(result, cmpgt_epu16(a, _3, elements));
                            }

                            constexpr.ASSUME_LE_EPU16(result, 4);

                            return result;
                        }
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
                        v256 TEN = Avx.mm256_set1_epi16(10);
                        v256 HUNDRED = Avx.mm256_set1_epi16(100);
                        v256 _1_000 = Avx.mm256_set1_epi16(1_000);
                        v256 _10_000 = Avx.mm256_set1_epi16(10_000);

                        v256 result = mm256_cmpge_epu16(a, TEN);
                        result = Avx2.mm256_abs_epi16(result);
                        result = Avx2.mm256_sub_epi16(result, mm256_cmpge_epu16(a, HUNDRED));
                        result = Avx2.mm256_sub_epi16(result, mm256_cmpge_epu16(a, _1_000));
                        result = Avx2.mm256_sub_epi16(result, mm256_cmpge_epu16(a, _10_000));

                        constexpr.ASSUME_LE_EPU16(result, 4);

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            public static v128 log10_epi16(v128 a, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                    {
                        return log10_epu8(a, (byte)(elements * 2)); // 0 stays 0 (high bits)
                    }
                    else 
                    {
                        v128 result;

                        if (elements == 2)
                        {
                            v128 splat = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                            v128 cmp = new v128(9, 9,   99, 99,   999, 999,   9_999, 9_999);

                            v128 cmp_negated = Sse2.cmpgt_epi16(splat, cmp);
                            result = negmask_epi16(cmp_negated); 
                            result = Sse2.sub_epi16(result, Sse2.bsrli_si128(cmp_negated, 4 * sizeof(short)));
                            result = Sse2.add_epi16(result, Sse2.bsrli_si128(result, 2 * sizeof(short)));
                        }
                        else
                        {
                            v128 NINE = Sse2.set1_epi16(9);
                            v128 NINETY_NINE = Sse2.set1_epi16(99);
                            v128 _999 = Sse2.set1_epi16(999);
                            v128 _9_999 = Sse2.set1_epi16(9_999);
                            
                            result = Sse2.cmpgt_epi16(a, NINE);
                            result = negmask_epi16(result);
                            result = Sse2.sub_epi16(result, Sse2.cmpgt_epi16(a, NINETY_NINE));
                            result = Sse2.sub_epi16(result, Sse2.cmpgt_epi16(a, _999));
                            result = Sse2.sub_epi16(result, Sse2.cmpgt_epi16(a, _9_999));

                            return result;
                        }

                        constexpr.ASSUME_LE_EPU16(result, 4);

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
                    if (constexpr.ALL_LE_EPU16(a, byte.MaxValue))
                    {
                        return mm256_log10_epu8(a); // 0 stays 0 (high bits)
                    }
                    else 
                    { 
                        v256 NINE = Avx.mm256_set1_epi16(9);
                        v256 NINETY_NINE = Avx.mm256_set1_epi16(99);
                        v256 _999 = Avx.mm256_set1_epi16(999);
                        v256 _9_999 = Avx.mm256_set1_epi16(9_999);

                        v256 result = Avx2.mm256_cmpgt_epi16(a, NINE);
                        result = Avx2.mm256_abs_epi16(result);
                        result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, NINETY_NINE));
                        result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, _999));
                        result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, _9_999));

                        constexpr.ASSUME_LE_EPU16(result, 4);

                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            public static v128 log10_epu32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
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
                                if (Sse4_1.IsSse41Supported)
                                {
                                    v128 MASK_10 = Sse2.set1_epi32(10);
                                    v128 MASK_100 = Sse2.set1_epi32(100);
                                    v128 MASK_1000 = Sse2.set1_epi32(1_000);
                                    v128 MASK_10000 = Sse2.set1_epi32(10_000);
                                    v128 MASK_100000 = Sse2.set1_epi32(100_000);
                                    v128 MASK_1000000 = Sse2.set1_epi32(1_000_000);
                                    v128 MASK_10000000 = Sse2.set1_epi32(10_000_000);
                                    v128 MASK_100000000 = Sse2.set1_epi32(100_000_000);
                                    v128 MASK_1000000000 = Sse2.set1_epi32(1_000_000_000);

                                    v128 result_10 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_10));
                                    v128 result_100 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_100));
                                    v128 result_1000 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_1000));
                                    v128 result_10000 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_10000));
                                    v128 result_100000 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_100000));
                                    v128 result_1000000 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_1000000));
                                    v128 result_10000000 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_10000000));
                                    v128 result_100000000 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_100000000));
                                    v128 result_1000000000 = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_1000000000));
                                    
                                    result_10 = Ssse3.abs_epi32(result_10);
                                    result_100 = Ssse3.abs_epi32(result_100);
                                    result_1000 = Ssse3.abs_epi32(result_1000);
                                    result_10000 = Ssse3.abs_epi32(result_10000);

                                    result_10 = Sse2.sub_epi32(result_10, result_100000);
                                    result_100 = Sse2.sub_epi32(result_100, result_1000000);
                                    result_1000 = Sse2.sub_epi32(result_1000, result_10000000);
                                    result_10000 = Sse2.sub_epi32(result_10000, result_100000000);

                                    result_10 = Sse2.sub_epi32(result_10, result_1000000000);

                                    result_100 = Sse2.add_epi32(result_100, result_1000);
                                    result_1000 = Sse2.add_epi32(result_10000, result_10);

                                    result = Sse2.add_epi32(result_100, result_1000);
                                }
                                else
                                {
                                    v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                    v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 LAST = new v128(999_999_999);
                                    
                                    v128 xxxx = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = Sse2.shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                    v128 zzzz = Sse2.shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2));
                                    v128 wwww = Sse2.shuffle_epi32(a, Sse.SHUFFLE(3, 3, 3, 3));
                                         
                                    v128 xResult = Xse.cmpgt_epu32(xxxx, MASK_SMALL);
                                    v128 yResult = Xse.cmpgt_epu32(yyyy, MASK_SMALL);
                                    v128 zResult = Xse.cmpgt_epu32(zzzz, MASK_SMALL);
                                    v128 wResult = Xse.cmpgt_epu32(wwww, MASK_SMALL);
                                    xResult = Xse.neg_epi32(xResult);
                                    yResult = Xse.neg_epi32(yResult);
                                    zResult = Xse.neg_epi32(zResult);
                                    wResult = Xse.neg_epi32(wResult);
                                    xResult = Sse2.sub_epi32(xResult, Xse.cmpgt_epu32(xxxx, MASK_LARGE));
                                    yResult = Sse2.sub_epi32(yResult, Xse.cmpgt_epu32(yyyy, MASK_LARGE));
                                    zResult = Sse2.sub_epi32(zResult, Xse.cmpgt_epu32(zzzz, MASK_LARGE));
                                    wResult = Sse2.sub_epi32(wResult, Xse.cmpgt_epu32(wwww, MASK_LARGE));
                                    xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 2 * sizeof(uint)));
                                    yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 2 * sizeof(uint)));
                                    zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 2 * sizeof(uint)));
                                    wResult = Sse2.add_epi32(wResult, Sse2.bsrli_si128(wResult, 2 * sizeof(uint)));
                                    xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 1 * sizeof(uint)));
                                    yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 1 * sizeof(uint)));
                                    zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 1 * sizeof(uint)));
                                    wResult = Sse2.add_epi32(wResult, Sse2.bsrli_si128(wResult, 1 * sizeof(uint)));
                                    
                                    v128 lastCMP = Sse2.cmpeq_epi32(Xse.max_epu32(a, LAST), a);
                                    
                                    v128 xy = Sse2.unpacklo_epi32(xResult, yResult);
                                    v128 zw = Sse2.unpacklo_epi32(zResult, wResult);
                                    result = Sse2.unpacklo_epi64(xy, zw);
                                    result = Sse2.sub_epi32(result, lastCMP);
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
                                    v256 _y = Avx2.mm256_broadcastd_epi32(Sse2.bsrli_si128(a, 1 * sizeof(uint)));
                                    v256 _z = Avx2.mm256_broadcastd_epi32(Sse2.bsrli_si128(a, 2 * sizeof(uint)));

                                    v256 resultX = Xse.mm256_cmpge_epu32(_x, MASK); 
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = Xse.mm256_cmpge_epu32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);
                                    v256 resultZ = Xse.mm256_cmpge_epu32(_z, MASK);
                                    v128 hiZ = Avx2.mm256_extracti128_si256(resultZ, 1);

                                    v128 resultX128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultY));
                                    v128 resultZ128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultZ));

                                    v128 lastCMP = Sse2.cmpeq_epi32(Sse4_1.max_epu32(a, LAST), a);

                                    resultX128 = Sse2.sub_epi32(resultX128, hiX);
                                    resultY128 = Sse2.sub_epi32(resultY128, hiY);
                                    resultZ128 = Sse2.sub_epi32(resultZ128, hiZ);

                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 2 * sizeof(uint)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 2 * sizeof(uint)));
                                    resultZ128 = Sse2.add_epi32(resultZ128, Sse2.bsrli_si128(resultZ128, 2 * sizeof(uint)));
                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 1 * sizeof(uint)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 1 * sizeof(uint)));
                                    resultZ128 = Sse2.add_epi32(resultZ128, Sse2.bsrli_si128(resultZ128, 1 * sizeof(uint)));
                                    
                                    v128 xy = Sse2.unpacklo_epi32(resultX128, resultY128);
                                    result = Sse2.unpacklo_epi64(xy, resultZ128);
                                    result = Sse2.sub_epi32(result, lastCMP);
                                }
                                else
                                {
                                    v128 xxxx = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = Sse2.shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                    v128 zzzz = Sse2.shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2));
                                         
                                    if (Sse4_1.IsSse41Supported)
                                    {
                                        v128 MASK_SMALL = new v128(10, 100, 1_000, 10_000);
                                        v128 MASK_LARGE = new v128(100_000, 1_000_000, 10_000_000, 100_000_000);
                                        v128 MASK_LAST  = new v128(1_000_000_000);

                                        v128 xResult = Sse2.cmpeq_epi32(xxxx, Sse4_1.max_epu32(xxxx, MASK_SMALL));
                                        v128 yResult = Sse2.cmpeq_epi32(yyyy, Sse4_1.max_epu32(yyyy, MASK_SMALL));
                                        v128 zResult = Sse2.cmpeq_epi32(zzzz, Sse4_1.max_epu32(zzzz, MASK_SMALL));
                                        xResult = Ssse3.abs_epi32(xResult);
                                        yResult = Ssse3.abs_epi32(yResult);
                                        zResult = Ssse3.abs_epi32(zResult);
                                        xResult = Sse2.sub_epi32(xResult, Sse2.cmpeq_epi32(xxxx, Sse4_1.max_epu32(xxxx, MASK_LARGE)));
                                        yResult = Sse2.sub_epi32(yResult, Sse2.cmpeq_epi32(yyyy, Sse4_1.max_epu32(yyyy, MASK_LARGE)));
                                        zResult = Sse2.sub_epi32(zResult, Sse2.cmpeq_epi32(zzzz, Sse4_1.max_epu32(zzzz, MASK_LARGE)));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 2 * sizeof(uint)));
                                        zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 2 * sizeof(uint)));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 1 * sizeof(uint)));
                                        zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 1 * sizeof(uint)));
                                        
                                        v128 lastCMP = Xse.cmpgt_epu32(a, MASK_LAST);

                                        v128 xy = Sse2.unpacklo_epi32(xResult, yResult);
                                        result = Sse2.unpacklo_epi64(xy, zResult);
                                        result = Sse2.sub_epi32(result, lastCMP);
                                    }
                                    else
                                    {
                                        v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                        v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                        v128 MASK_LAST  = new v128(999_999_999);

                                        v128 xResult = Xse.cmpgt_epu32(xxxx, MASK_SMALL);
                                        v128 yResult = Xse.cmpgt_epu32(yyyy, MASK_SMALL);
                                        v128 zResult = Xse.cmpgt_epu32(zzzz, MASK_SMALL);

                                        xResult = Xse.neg_epi32(xResult);
                                        yResult = Xse.neg_epi32(yResult);
                                        zResult = Xse.neg_epi32(zResult);
                                        xResult = Sse2.sub_epi32(xResult, Xse.cmpgt_epu32(xxxx, MASK_LARGE));
                                        yResult = Sse2.sub_epi32(yResult, Xse.cmpgt_epu32(yyyy, MASK_LARGE));
                                        zResult = Sse2.sub_epi32(zResult, Xse.cmpgt_epu32(zzzz, MASK_LARGE));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 2 * sizeof(uint)));
                                        zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 2 * sizeof(uint)));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 1 * sizeof(uint)));
                                        zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 1 * sizeof(uint)));
                                        
                                        v128 lastCMP = Xse.cmpgt_epu32(a, MASK_LAST);

                                        v128 xy = Sse2.unpacklo_epi32(xResult, yResult);
                                        result = Sse2.unpacklo_epi64(xy, zResult);
                                        result = Sse2.sub_epi32(result, lastCMP);
                                    }
                                }

                                break;
                            }
                            case 2:
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    v256 MASK = new v256(10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000);
                                    v128 LAST = Sse2.cvtsi64x_si128((1_000_000_000L << 32) | 1_000_000_000);

                                    v256 _x = Avx2.mm256_broadcastd_epi32(a);
                                    v256 _y = Avx2.mm256_broadcastd_epi32(Sse2.bsrli_si128(a, 1 * sizeof(uint)));

                                    v256 resultX = Xse.mm256_cmpge_epu32(_x, MASK); 
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = Xse.mm256_cmpge_epu32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);

                                    v128 resultX128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultY));

                                    v128 lastCMP = Sse2.cmpeq_epi32(Sse4_1.max_epu32(a, LAST), a);

                                    resultX128 = Sse2.sub_epi32(resultX128, hiX);
                                    resultY128 = Sse2.sub_epi32(resultY128, hiY);

                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 2 * sizeof(uint)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 2 * sizeof(uint)));
                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 1 * sizeof(uint)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 1 * sizeof(uint)));

                                    v128 xy = Sse2.unpacklo_epi32(resultX128, resultY128);
                                    result = Sse2.sub_epi32(xy, lastCMP);
                                }
                                else
                                {
                                    v128 xxxx = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = Sse2.shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                         
                                    if (Sse4_1.IsSse41Supported)
                                    {
                                        v128 MASK_SMALL = new v128(10, 100, 1_000, 10_000);
                                        v128 MASK_LARGE = new v128(100_000, 1_000_000, 10_000_000, 100_000_000);
                                        v128 MASK_LAST  = Sse2.cvtsi64x_si128((1_000_000_000L << 32) | 1_000_000_000L);

                                        v128 xResult = Sse2.cmpeq_epi32(xxxx, Sse4_1.max_epu32(xxxx, MASK_SMALL));
                                        v128 yResult = Sse2.cmpeq_epi32(yyyy, Sse4_1.max_epu32(yyyy, MASK_SMALL));
                                        xResult = Ssse3.abs_epi32(xResult);
                                        yResult = Ssse3.abs_epi32(yResult);
                                        xResult = Sse2.sub_epi32(xResult, Sse2.cmpeq_epi32(xxxx, Sse4_1.max_epu32(xxxx, MASK_LARGE)));
                                        yResult = Sse2.sub_epi32(yResult, Sse2.cmpeq_epi32(yyyy, Sse4_1.max_epu32(yyyy, MASK_LARGE)));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 2 * sizeof(uint)));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 1 * sizeof(uint)));
                                        
                                        v128 lastCMP = Sse2.cmpeq_epi32(a, Sse4_1.max_epu32(a, MASK_LAST));

                                        v128 xy = Sse2.unpacklo_epi32(xResult, yResult);
                                        result = Sse2.sub_epi32(xy, lastCMP);
                                    }
                                    else
                                    {
                                        v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                        v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                        v128 MASK_LAST  = Sse2.cvtsi64x_si128((999_999_999L << 32) | 999_999_999L);

                                        v128 xResult = Xse.cmpgt_epu32(xxxx, MASK_SMALL);
                                        v128 yResult = Xse.cmpgt_epu32(yyyy, MASK_SMALL);
                                        xResult = Xse.neg_epi32(xResult);
                                        yResult = Xse.neg_epi32(yResult);
                                        xResult = Sse2.sub_epi32(xResult, Xse.cmpgt_epu32(xxxx, MASK_LARGE));
                                        yResult = Sse2.sub_epi32(yResult, Xse.cmpgt_epu32(yyyy, MASK_LARGE));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 2 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 2 * sizeof(uint)));
                                        xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 1 * sizeof(uint)));
                                        yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 1 * sizeof(uint)));
                                        
                                        v128 lastCMP = Xse.cmpgt_epu32(a, MASK_LAST);

                                        v128 xy = Sse2.unpacklo_epi32(xResult, yResult);
                                        result = Sse2.sub_epi32(xy, lastCMP);
                                    }
                                }

                                break;
                            }
                            default: result = a; break;
                        }

                        constexpr.ASSUME_LE_EPU32(result, 9);

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
                        v256 MASK_10 = Avx.mm256_set1_epi32(10);
                        v256 MASK_100 = Avx.mm256_set1_epi32(100);
                        v256 MASK_1000 = Avx.mm256_set1_epi32(1_000);
                        v256 MASK_10000 = Avx.mm256_set1_epi32(10_000);
                        v256 MASK_100000 = Avx.mm256_set1_epi32(100_000);
                        v256 MASK_1000000 = Avx.mm256_set1_epi32(1_000_000);
                        v256 MASK_10000000 = Avx.mm256_set1_epi32(10_000_000);
                        v256 MASK_100000000 = Avx.mm256_set1_epi32(100_000_000);
                        v256 MASK_1000000000 = Avx.mm256_set1_epi32(1_000_000_000);

                        v256 result_10 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_10));
                        v256 result_100 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_100));
                        v256 result_1000 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_1000));
                        v256 result_10000 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_10000));
                        v256 result_100000 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_100000));
                        v256 result_1000000 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_1000000));
                        v256 result_10000000 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_10000000));
                        v256 result_100000000 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_100000000));
                        v256 result_1000000000 = Avx2.mm256_cmpeq_epi32(a, Avx2.mm256_max_epu32(a, MASK_1000000000));
                        
                        result_10 = Avx2.mm256_abs_epi32(result_10);
                        result_100 = Avx2.mm256_abs_epi32(result_100);
                        result_1000 = Avx2.mm256_abs_epi32(result_1000);
                        result_10000 = Avx2.mm256_abs_epi32(result_10000);

                        result_10 = Avx2.mm256_sub_epi32(result_10, result_100000);
                        result_100 = Avx2.mm256_sub_epi32(result_100, result_1000000);
                        result_1000 = Avx2.mm256_sub_epi32(result_1000, result_10000000);
                        result_10000 = Avx2.mm256_sub_epi32(result_10000, result_100000000);

                        result_10 = Avx2.mm256_sub_epi32(result_10, result_1000000000);

                        result_100 = Avx2.mm256_add_epi32(result_100, result_1000);
                        result_1000 = Avx2.mm256_add_epi32(result_10000, result_10);

                        return Avx2.mm256_add_epi32(result_100, result_1000);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            public static v128 log10_epi32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
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
                                v128 MASK_9 = Sse2.set1_epi32(9);
                                v128 MASK_99 = Sse2.set1_epi32(99);
                                v128 MASK_999 = Sse2.set1_epi32(999);
                                v128 MASK_9999 = Sse2.set1_epi32(9_999);
                                v128 MASK_99999 = Sse2.set1_epi32(99_999);
                                v128 MASK_999999 = Sse2.set1_epi32(999_999);
                                v128 MASK_9999999 = Sse2.set1_epi32(9_999_999);
                                v128 MASK_99999999 = Sse2.set1_epi32(99_999_999);
                                v128 MASK_999999999 = Sse2.set1_epi32(999_999_999);
                                
                                v128 result_9 = Sse2.cmpgt_epi32(a, MASK_9);
                                v128 result_99 = Sse2.cmpgt_epi32(a, MASK_99);
                                v128 result_999 = Sse2.cmpgt_epi32(a, MASK_999);
                                v128 result_9999 = Sse2.cmpgt_epi32(a, MASK_9999);
                                v128 result_99999 = Sse2.cmpgt_epi32(a, MASK_99999);
                                v128 result_999999 = Sse2.cmpgt_epi32(a, MASK_999999);
                                v128 result_9999999 = Sse2.cmpgt_epi32(a, MASK_9999999);
                                v128 result_99999999 = Sse2.cmpgt_epi32(a, MASK_99999999);
                                v128 result_999999999 = Sse2.cmpgt_epi32(a, MASK_999999999);
                                
                                result_9 = negmask_epi32(result_9);
                                result_99 = negmask_epi32(result_99);
                                result_999 = negmask_epi32(result_999);
                                result_9999 = negmask_epi32(result_9999);

                                result_9 = Sse2.sub_epi32(result_9, result_99999);
                                result_99 = Sse2.sub_epi32(result_99, result_999999);
                                result_999 = Sse2.sub_epi32(result_999, result_9999999);
                                result_9999 = Sse2.sub_epi32(result_9999, result_99999999);

                                result_9 = Sse2.sub_epi32(result_9, result_999999999);

                                result_99 = Sse2.add_epi32(result_99, result_999);
                                result_999 = Sse2.add_epi32(result_9999, result_9);

                                result = Sse2.add_epi32(result_99, result_999);

                                break;
                            }
                            case 3:
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    v256 MASK = new v256(9, 99, 999, 9_999, 99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 LAST = new v128(999_999_999);

                                    v256 _x = Avx2.mm256_broadcastd_epi32(a);
                                    v256 _y = Avx2.mm256_broadcastd_epi32(Sse2.bsrli_si128(a, 1 * sizeof(int)));
                                    v256 _z = Avx2.mm256_broadcastd_epi32(Sse2.bsrli_si128(a, 2 * sizeof(int)));

                                    v256 resultX = Avx2.mm256_cmpgt_epi32(_x, MASK); 
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = Avx2.mm256_cmpgt_epi32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);
                                    v256 resultZ = Avx2.mm256_cmpgt_epi32(_z, MASK);
                                    v128 hiZ = Avx2.mm256_extracti128_si256(resultZ, 1);

                                    v128 resultX128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultY));
                                    v128 resultZ128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultZ));

                                    v128 lastCMP = Sse2.cmpgt_epi32(a, LAST);

                                    resultX128 = Sse2.sub_epi32(resultX128, hiX);
                                    resultY128 = Sse2.sub_epi32(resultY128, hiY);
                                    resultZ128 = Sse2.sub_epi32(resultZ128, hiZ);

                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 2 * sizeof(int)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 2 * sizeof(int)));
                                    resultZ128 = Sse2.add_epi32(resultZ128, Sse2.bsrli_si128(resultZ128, 2 * sizeof(int)));
                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 1 * sizeof(int)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 1 * sizeof(int)));
                                    resultZ128 = Sse2.add_epi32(resultZ128, Sse2.bsrli_si128(resultZ128, 1 * sizeof(int)));

                                    v128 xy = Sse2.unpacklo_epi32(resultX128, resultY128);
                                    result = Sse2.unpacklo_epi64(xy, resultZ128);
                                    result = Sse2.sub_epi32(result, lastCMP);
                                }
                                else
                                {
                                    v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                    v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 MASK_LAST = new v128(999_999_999);

                                    v128 xxxx = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = Sse2.shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                    v128 zzzz = Sse2.shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2));
                                         
                                    v128 xResult = Sse2.cmpgt_epi32(xxxx, MASK_SMALL);
                                    v128 yResult = Sse2.cmpgt_epi32(yyyy, MASK_SMALL);
                                    v128 zResult = Sse2.cmpgt_epi32(zzzz, MASK_SMALL);

                                    xResult = negmask_epi32(xResult);
                                    yResult = negmask_epi32(yResult);
                                    zResult = negmask_epi32(zResult);
                                    xResult = Sse2.sub_epi32(xResult, Sse2.cmpgt_epi32(xxxx, MASK_LARGE));
                                    yResult = Sse2.sub_epi32(yResult, Sse2.cmpgt_epi32(yyyy, MASK_LARGE));
                                    zResult = Sse2.sub_epi32(zResult, Sse2.cmpgt_epi32(zzzz, MASK_LARGE));
                                    xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 2 * sizeof(int)));
                                    yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 2 * sizeof(int)));
                                    zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 2 * sizeof(int)));
                                    xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 1 * sizeof(int)));
                                    yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 1 * sizeof(int)));
                                    zResult = Sse2.add_epi32(zResult, Sse2.bsrli_si128(zResult, 1 * sizeof(int)));
                                    
                                    v128 lastCMP = Sse2.cmpgt_epi32(a, MASK_LAST);

                                    v128 xy = Sse2.unpacklo_epi32(xResult, yResult);
                                    result = Sse2.unpacklo_epi64(xy, zResult);
                                    result = Sse2.sub_epi32(result, lastCMP);
                                }

                                break;
                            }
                            case 2:
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    v256 MASK = new v256(9, 99, 999, 9_999, 99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 LAST = Sse2.cvtsi64x_si128((999_999_999L << 32) | 999_999_999);

                                    v256 _x = Avx2.mm256_broadcastd_epi32(a);
                                    v256 _y = Avx2.mm256_broadcastd_epi32(Sse2.bsrli_si128(a, 1 * sizeof(int)));

                                    v256 resultX = Avx2.mm256_cmpgt_epi32(_x, MASK); 
                                    v128 hiX = Avx2.mm256_extracti128_si256(resultX, 1);
                                    v256 resultY = Avx2.mm256_cmpgt_epi32(_y, MASK);
                                    v128 hiY = Avx2.mm256_extracti128_si256(resultY, 1);

                                    v128 resultX128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultX));
                                    v128 resultY128 = Ssse3.abs_epi32(Avx.mm256_castsi256_si128(resultY));

                                    v128 lastCMP = Sse2.cmpgt_epi32(a, LAST);

                                    resultX128 = Sse2.sub_epi32(resultX128, hiX);
                                    resultY128 = Sse2.sub_epi32(resultY128, hiY);

                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 2 * sizeof(int)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 2 * sizeof(int)));
                                    resultX128 = Sse2.add_epi32(resultX128, Sse2.bsrli_si128(resultX128, 1 * sizeof(int)));
                                    resultY128 = Sse2.add_epi32(resultY128, Sse2.bsrli_si128(resultY128, 1 * sizeof(int)));

                                    result = Sse2.unpacklo_epi32(resultX128, resultY128);
                                    result = Sse2.sub_epi32(result, lastCMP);
                                }
                                else
                                {
                                    v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                                    v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);
                                    v128 MASK_LAST  = Sse2.cvtsi64x_si128((999_999_999L << 32) | 999_999_999L);

                                    v128 xxxx = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                                    v128 yyyy = Sse2.shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                                         
                                    v128 xResult = Sse2.cmpgt_epi32(xxxx, MASK_SMALL);
                                    v128 yResult = Sse2.cmpgt_epi32(yyyy, MASK_SMALL);

                                    xResult = negmask_epi32(xResult);
                                    yResult = negmask_epi32(yResult);
                                    xResult = Sse2.sub_epi32(xResult, Sse2.cmpgt_epi32(xxxx, MASK_LARGE));
                                    yResult = Sse2.sub_epi32(yResult, Sse2.cmpgt_epi32(yyyy, MASK_LARGE));
                                    xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 2 * sizeof(int)));
                                    yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 2 * sizeof(int)));
                                    xResult = Sse2.add_epi32(xResult, Sse2.bsrli_si128(xResult, 1 * sizeof(int)));
                                    yResult = Sse2.add_epi32(yResult, Sse2.bsrli_si128(yResult, 1 * sizeof(int)));
                                    
                                    v128 lastCMP = Sse2.cmpgt_epi32(a, MASK_LAST);

                                    result = Sse2.unpacklo_epi32(xResult, yResult);
                                    result = Sse2.sub_epi32(result, lastCMP);
                                }
                                break;
                            }
                            default: result = a; break;
                        }

                        constexpr.ASSUME_LE_EPU32(result, 9);

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
                    if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue))
                    {
                        return mm256_log10_epu16(a); // 0 stays 0 (high bits)
                    }
                    else 
                    { 
                        v256 MASK_9 = Avx.mm256_set1_epi32(9);
                        v256 MASK_99 = Avx.mm256_set1_epi32(99);
                        v256 MASK_999 = Avx.mm256_set1_epi32(999);
                        v256 MASK_9999 = Avx.mm256_set1_epi32(9_999);
                        v256 MASK_99999 = Avx.mm256_set1_epi32(99_999);
                        v256 MASK_999999 = Avx.mm256_set1_epi32(999_999);
                        v256 MASK_9999999 = Avx.mm256_set1_epi32(9_999_999);
                        v256 MASK_99999999 = Avx.mm256_set1_epi32(99_999_999);
                        v256 MASK_999999999 = Avx.mm256_set1_epi32(999_999_999);

                        v256 result_9 = Avx2.mm256_cmpgt_epi32(a, MASK_9);
                        v256 result_99 = Avx2.mm256_cmpgt_epi32(a, MASK_99);
                        v256 result_999 = Avx2.mm256_cmpgt_epi32(a, MASK_999);
                        v256 result_9999 = Avx2.mm256_cmpgt_epi32(a, MASK_9999);
                        v256 result_99999 = Avx2.mm256_cmpgt_epi32(a, MASK_99999);
                        v256 result_999999 = Avx2.mm256_cmpgt_epi32(a, MASK_999999);
                        v256 result_9999999 = Avx2.mm256_cmpgt_epi32(a, MASK_9999999);
                        v256 result_99999999 = Avx2.mm256_cmpgt_epi32(a, MASK_99999999);
                        v256 result_999999999 = Avx2.mm256_cmpgt_epi32(a, MASK_999999999);
                        
                        result_9 = Avx2.mm256_abs_epi32(result_9);
                        result_99 = Avx2.mm256_abs_epi32(result_99);
                        result_999 = Avx2.mm256_abs_epi32(result_999);
                        result_9999 = Avx2.mm256_abs_epi32(result_9999);

                        result_9 = Avx2.mm256_sub_epi32(result_9, result_99999);
                        result_99 = Avx2.mm256_sub_epi32(result_99, result_999999);
                        result_999 = Avx2.mm256_sub_epi32(result_999, result_9999999);
                        result_9999 = Avx2.mm256_sub_epi32(result_9999, result_99999999);

                        result_9 = Avx2.mm256_sub_epi32(result_9, result_999999999);

                        result_99 = Avx2.mm256_add_epi32(result_99, result_999);
                        result_999 = Avx2.mm256_add_epi32(result_9999, result_9);

                        return Avx2.mm256_add_epi32(result_99, result_999);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            [SkipLocalsInit]
            public static v128 log10_epu64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                    {
                        return log10_epu32(a);
                    }
                }
                
                // STACKALLOC >1kB???
                UInt128* guess = stackalloc UInt128[65]
                {
                    new UInt128(0, 19) - 10000000000000000000ul,
                    new UInt128(0, 18) - 1000000000000000000ul,
                    new UInt128(0, 18) - 1000000000000000000ul,
                    new UInt128(0, 18) - 1000000000000000000ul,
                    new UInt128(0, 18) - 1000000000000000000ul,
                    new UInt128(0, 17) - 100000000000000000ul,
                    new UInt128(0, 17) - 100000000000000000ul,
                    new UInt128(0, 17) - 100000000000000000ul,
                    new UInt128(0, 16) - 10000000000000000ul,
                    new UInt128(0, 16) - 10000000000000000ul,
                    new UInt128(0, 16) - 10000000000000000ul,
                    new UInt128(0, 15) - 1000000000000000ul,
                    new UInt128(0, 15) - 1000000000000000ul,
                    new UInt128(0, 15) - 1000000000000000ul,
                    new UInt128(0, 15) - 1000000000000000ul,
                    new UInt128(0, 14) - 100000000000000ul,
                    new UInt128(0, 14) - 100000000000000ul,
                    new UInt128(0, 14) - 100000000000000ul,
                    new UInt128(0, 13) - 10000000000000ul,
                    new UInt128(0, 13) - 10000000000000ul,
                    new UInt128(0, 13) - 10000000000000ul,
                    new UInt128(0, 12) - 1000000000000ul,
                    new UInt128(0, 12) - 1000000000000ul,
                    new UInt128(0, 12) - 1000000000000ul,
                    new UInt128(0, 12) - 1000000000000ul,
                    new UInt128(0, 11) - 100000000000ul,
                    new UInt128(0, 11) - 100000000000ul,
                    new UInt128(0, 11) - 100000000000ul,
                    new UInt128(0, 10) - 10000000000ul,
                    new UInt128(0, 10) - 10000000000ul,
                    new UInt128(0, 10) - 10000000000ul,
                    new UInt128(0, 9)  - 1000000000ul,
                    new UInt128(0, 9)  - 1000000000ul,
                    new UInt128(0, 9)  - 1000000000ul,
                    new UInt128(0, 9)  - 1000000000ul,
                    new UInt128(0, 8)  - 100000000ul, 
                    new UInt128(0, 8)  - 100000000ul, 
                    new UInt128(0, 8)  - 100000000ul, 
                    new UInt128(0, 7)  - 10000000ul, 
                    new UInt128(0, 7)  - 10000000ul, 
                    new UInt128(0, 7)  - 10000000ul, 
                    new UInt128(0, 6)  - 1000000ul,
                    new UInt128(0, 6)  - 1000000ul,
                    new UInt128(0, 6)  - 1000000ul,
                    new UInt128(0, 6)  - 1000000ul,
                    new UInt128(0, 5)  - 100000ul,
                    new UInt128(0, 5)  - 100000ul,
                    new UInt128(0, 5)  - 100000ul,
                    new UInt128(0, 4)  - 10000ul,
                    new UInt128(0, 4)  - 10000ul,
                    new UInt128(0, 4)  - 10000ul,
                    new UInt128(0, 3)  - 1000ul,
                    new UInt128(0, 3)  - 1000ul,
                    new UInt128(0, 3)  - 1000ul,
                    new UInt128(0, 3)  - 1000ul,
                    new UInt128(0, 2)  - 100ul,
                    new UInt128(0, 2)  - 100ul,
                    new UInt128(0, 2)  - 100ul,
                    new UInt128(0, 1)  - 10ul,
                    new UInt128(0, 1)  - 10ul,
                    new UInt128(0, 1)  - 10ul,
                    new UInt128(0, 0), 
                    new UInt128(0, 0), 
                    new UInt128(0, 0), 
                    new UInt128(0, 0), 
                };
                
                UInt128 adjust0 = guess[math.lzcnt(a.ULong0)];
                UInt128 adjust1 = guess[math.lzcnt(a.ULong1)];
                
                return new v128((adjust0 + a.ULong0).hi64, (adjust1 + a.ULong1).hi64);
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
                        // STACKALLOC >1kB???
                        UInt128* guess = stackalloc UInt128[65]
                        {
                            new UInt128(0, 19) - 10000000000000000000ul,
                            new UInt128(0, 18) - 1000000000000000000ul,
                            new UInt128(0, 18) - 1000000000000000000ul,
                            new UInt128(0, 18) - 1000000000000000000ul,
                            new UInt128(0, 18) - 1000000000000000000ul,
                            new UInt128(0, 17) - 100000000000000000ul,
                            new UInt128(0, 17) - 100000000000000000ul,
                            new UInt128(0, 17) - 100000000000000000ul,
                            new UInt128(0, 16) - 10000000000000000ul,
                            new UInt128(0, 16) - 10000000000000000ul,
                            new UInt128(0, 16) - 10000000000000000ul,
                            new UInt128(0, 15) - 1000000000000000ul,
                            new UInt128(0, 15) - 1000000000000000ul,
                            new UInt128(0, 15) - 1000000000000000ul,
                            new UInt128(0, 15) - 1000000000000000ul,
                            new UInt128(0, 14) - 100000000000000ul,
                            new UInt128(0, 14) - 100000000000000ul,
                            new UInt128(0, 14) - 100000000000000ul,
                            new UInt128(0, 13) - 10000000000000ul,
                            new UInt128(0, 13) - 10000000000000ul,
                            new UInt128(0, 13) - 10000000000000ul,
                            new UInt128(0, 12) - 1000000000000ul,
                            new UInt128(0, 12) - 1000000000000ul,
                            new UInt128(0, 12) - 1000000000000ul,
                            new UInt128(0, 12) - 1000000000000ul,
                            new UInt128(0, 11) - 100000000000ul,
                            new UInt128(0, 11) - 100000000000ul,
                            new UInt128(0, 11) - 100000000000ul,
                            new UInt128(0, 10) - 10000000000ul,
                            new UInt128(0, 10) - 10000000000ul,
                            new UInt128(0, 10) - 10000000000ul,
                            new UInt128(0, 9)  - 1000000000ul,
                            new UInt128(0, 9)  - 1000000000ul,
                            new UInt128(0, 9)  - 1000000000ul,
                            new UInt128(0, 9)  - 1000000000ul,
                            new UInt128(0, 8)  - 100000000ul, 
                            new UInt128(0, 8)  - 100000000ul, 
                            new UInt128(0, 8)  - 100000000ul, 
                            new UInt128(0, 7)  - 10000000ul, 
                            new UInt128(0, 7)  - 10000000ul, 
                            new UInt128(0, 7)  - 10000000ul, 
                            new UInt128(0, 6)  - 1000000ul,
                            new UInt128(0, 6)  - 1000000ul,
                            new UInt128(0, 6)  - 1000000ul,
                            new UInt128(0, 6)  - 1000000ul,
                            new UInt128(0, 5)  - 100000ul,
                            new UInt128(0, 5)  - 100000ul,
                            new UInt128(0, 5)  - 100000ul,
                            new UInt128(0, 4)  - 10000ul,
                            new UInt128(0, 4)  - 10000ul,
                            new UInt128(0, 4)  - 10000ul,
                            new UInt128(0, 3)  - 1000ul,
                            new UInt128(0, 3)  - 1000ul,
                            new UInt128(0, 3)  - 1000ul,
                            new UInt128(0, 3)  - 1000ul,
                            new UInt128(0, 2)  - 100ul,
                            new UInt128(0, 2)  - 100ul,
                            new UInt128(0, 2)  - 100ul,
                            new UInt128(0, 1)  - 10ul,
                            new UInt128(0, 1)  - 10ul,
                            new UInt128(0, 1)  - 10ul,
                            new UInt128(0, 0), 
                            new UInt128(0, 0), 
                            new UInt128(0, 0), 
                            new UInt128(0, 0), 
                        };
                        
                        UInt128 adjust0 = guess[math.lzcnt(a.ULong0)];
                        UInt128 adjust1 = guess[math.lzcnt(a.ULong1)];
                        UInt128 adjust2 = guess[math.lzcnt(a.ULong2)];

                        v128 lo = new v128((adjust0 + a.ULong0).hi64, (adjust1 + a.ULong1).hi64);
                        v128 hi = Sse2.cvtsi64x_si128((long)((adjust2 + a.ULong2).hi64));
                        if (elements > 3)
                        {
                            UInt128 adjust3 = guess[math.lzcnt(a.ULong3)];
                            hi = Sse2.unpacklo_epi64(hi, Sse2.cvtsi64x_si128((long)((adjust3 + a.ULong3).hi64)));
                        }
                        
                        return new v256(lo, hi);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            [SkipLocalsInit]
            public static v128 log10_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
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
                    return mm256_log10_epu64(a, elements);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
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
                UInt128* lut = stackalloc UInt128[] 
                { 
                    10000000000000000000ul, 
                    /*100000000000000000000: */ new UInt128(0x6BC7_5E2D_6310_0000, 0x0000_0000_0000_0005),
                    /*1000000000000000000000: */ new UInt128(0x35C9_ADC5_DEA0_0000, 0x0000_0000_0000_0036),
                    /*10000000000000000000000: */ new UInt128(0x19E0_C9BA_B240_0000, 0x0000_0000_0000_021E),
                    /*100000000000000000000000: */ new UInt128(0x02C7_E14A_F680_0000, 0x0000_0000_0000_152D),
                    /*1000000000000000000000000: */ new UInt128(0x1BCE_CCED_A100_0000, 0x0000_0000_0000_D3C2),
                    /*10000000000000000000000000: */ new UInt128(0x1614_0148_4A00_0000, 0x0000_0000_0008_4595),
                    /*100000000000000000000000000: */ new UInt128(0xDCC8_0CD2_E400_0000, 0x0000_0000_0052_B7D2),
                    /*1000000000000000000000000000: */ new UInt128(0x9FD0_803C_E800_0000, 0x0000_0000_033B_2E3C),
                    /*10000000000000000000000000000: */ new UInt128(0x3E25_0261_1000_0000, 0x0000_0000_204F_CE5E),
                    /*100000000000000000000000000000: */ new UInt128(0x6D72_17CA_A000_0000, 0x0000_0001_431E_0FAE),
                    /*1000000000000000000000000000000: */ new UInt128(0x4674_EDEA_4000_0000, 0x0000_000C_9F2C_9CD0),
                    /*10000000000000000000000000000000: */ new UInt128(0xC091_4B26_8000_0000, 0x0000_007E_37BE_2022),
                    /*100000000000000000000000000000000: */ new UInt128(0x85AC_EF81_0000_0000, 0x0000_04EE_2D6D_415B), 
                    /*1000000000000000000000000000000000: */ new UInt128(0x38C1_5B0A_0000_0000, 0x0000_314D_C644_8D93), 
                    /*10000000000000000000000000000000000: */ new UInt128(0x378D_8E64_0000_0000, 0x0001_ED09_BEAD_87C0), 
                    /*100000000000000000000000000000000000: */ new UInt128(0x2B87_8FE8_0000_0000, 0x0013_4261_72C7_4D82), 
                    /*1000000000000000000000000000000000000: */ new UInt128(0xB34B_9F10_0000_0000, 0x00C0_97CE_7BC9_0715),
                    /*10000000000000000000000000000000000000: */ new UInt128(0x00F4_36A0_0000_0000, 0x0785_EE10_D5DA_46D9),
                    /*100000000000000000000000000000000000000: */ new UInt128(0x098A_2240_0000_0000, 0x4B3B_4CA8_5A86_C47A)
                };
            
                
                uint result = 128 - (uint)math.lzcnt(x.hi64);
                result = (result * 157_287) >> 19;
                result -= tobyte(x < lut[result - 19]);

                // fails at 10^31 = 10000000000000000000000000000000
                // fails at 10^34 = 10000000000000000000000000000000000
                // fails at 10^37 = 10000000000000000000000000000000000000
                // thus...
                if (Hint.Unlikely(result >= 30 & isdivisible(result, 3)))
                {
                    result += tobyte(x >= lut[result - 18]);
                }
                
                return result;
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        [return: AssumeRange(0ul, 2ul)]
        public static byte intlog10(byte x)
        {
            return (byte)(tobyte(x >= 10) + tobyte(x >= 100));
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intlog10(byte2 x)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            return (sbyte)(tobyte(x >= 10) + tobyte(x >= 100));
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intlog10(sbyte2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.log10_epi8(x);
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.log10_epi8(x);
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.log10_epi8(x);
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
            if (Sse2.IsSse2Supported)
            {
                return Xse.log10_epi8(x);
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
            if (Sse2.IsSse2Supported)
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
            if (Xse.constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intlog10((byte)x);
            }

            return (ushort)(tobyte(x >= 10) + tobyte(x >= 100) + tobyte(x >= 1_000) + tobyte(x >= 10_000));
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intlog10(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Xse.constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intlog10((byte)x);
            }

            return (short)(tobyte(x >= 10) + tobyte(x >= 100) + tobyte(x >= 1_000) + tobyte(x >= 10_000));
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intlog10(short2 x)
        {
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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
            if (Sse2.IsSse2Supported)
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


        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [return: AssumeRange(0ul, 9ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static uint intlog10(uint x)
        {
            if (Xse.constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                return intlog10((ushort)x);
            }

            if (Sse4_1.IsSse41Supported)
            {
                v128 MASK_SMALL = new v128(10, 100, 1_000, 10_000);
                v128 MASK_LARGE = new v128(100_000, 1_000_000, 10_000_000, 100_000_000);

                v128 splat = Sse2.shuffle_epi32(Sse2.cvtsi32_si128((int)x), Sse.SHUFFLE(0, 0, 0, 0));

                v128 cmp = Xse.negmask_epi32(Xse.cmpge_epu32(splat, MASK_SMALL));
                cmp = Sse2.sub_epi32(cmp, Xse.cmpge_epu32(splat, MASK_LARGE));

                return tobyte(x >= 1_000_000_000) + Xse.vsum_epi32(cmp, true, 4).UInt0;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);

                v128 splat = Sse2.shuffle_epi32(Sse2.cvtsi32_si128((int)x), Sse.SHUFFLE(0, 0, 0, 0));

                v128 cmp = Xse.negmask_epi32(Xse.cmpgt_epu32(splat, MASK_SMALL));
                cmp = Sse2.sub_epi32(cmp, Xse.cmpgt_epu32(splat, MASK_LARGE));

                return tobyte(x >= 1_000_000_000) + Xse.vsum_epi32(cmp, true, 4).UInt0;
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

                ulong adjust = guess[math.lzcnt(x)];

                return (uint)((adjust + x) >> 32);
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint2 intlog10(uint2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.log10_epu32(RegisterConversion.ToV128(x), 2));
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

                ulong adjustX = guess[math.lzcnt(x.x)];
                ulong adjustY = guess[math.lzcnt(x.y)];

                return new uint2((uint)((adjustX + x.x) >> 32), 
                                 (uint)((adjustY + x.y) >> 32));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint3 intlog10(uint3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.log10_epu32(RegisterConversion.ToV128(x), 3));
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

                ulong adjustX = guess[math.lzcnt(x.x)];
                ulong adjustY = guess[math.lzcnt(x.y)];
                ulong adjustZ = guess[math.lzcnt(x.z)];

                return new uint3((uint)((adjustX + x.x) >> 32), 
                                 (uint)((adjustY + x.y) >> 32), 
                                 (uint)((adjustZ + x.z) >> 32));
            }
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        public static uint4 intlog10(uint4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.log10_epu32(RegisterConversion.ToV128(x), 4));
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

                ulong adjustX = guess[math.lzcnt(x.x)];
                ulong adjustY = guess[math.lzcnt(x.y)];
                ulong adjustZ = guess[math.lzcnt(x.z)];
                ulong adjustW = guess[math.lzcnt(x.w)];

                return new uint4((uint)((adjustX + x.x) >> 32), 
                                 (uint)((adjustY + x.y) >> 32), 
                                 (uint)((adjustZ + x.z) >> 32), 
                                 (uint)((adjustW + x.w) >> 32));
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
            else if (Sse2.IsSse2Supported)
            {
                return new uint8(intlog10(x.v4_0), intlog10(x.v4_4));
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

                ulong adjust0 = guess[math.lzcnt(x.x0)];
                ulong adjust1 = guess[math.lzcnt(x.x1)];
                ulong adjust2 = guess[math.lzcnt(x.x2)];
                ulong adjust3 = guess[math.lzcnt(x.x3)];
                ulong adjust4 = guess[math.lzcnt(x.x4)];
                ulong adjust5 = guess[math.lzcnt(x.x5)];
                ulong adjust6 = guess[math.lzcnt(x.x6)];
                ulong adjust7 = guess[math.lzcnt(x.x7)];

                return new uint8((uint)((adjust0 + x.x0) >> 32), 
                                 (uint)((adjust1 + x.x1) >> 32), 
                                 (uint)((adjust2 + x.x2) >> 32), 
                                 (uint)((adjust3 + x.x3) >> 32), 
                                 (uint)((adjust4 + x.x4) >> 32), 
                                 (uint)((adjust5 + x.x5) >> 32), 
                                 (uint)((adjust6 + x.x6) >> 32), 
                                 (uint)((adjust7 + x.x7) >> 32));
            }
        }


        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        [return: AssumeRange(0, 9)]
        public static int intlog10(int x)
        {
            if (Xse.constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                return intlog10((short)x);
            }

            if (Sse2.IsSse2Supported)
            {
                v128 MASK_SMALL = new v128(9, 99, 999, 9_999);
                v128 MASK_LARGE = new v128(99_999, 999_999, 9_999_999, 99_999_999);

                v128 splat = Sse2.shuffle_epi32(Sse2.cvtsi32_si128(x), Sse.SHUFFLE(0, 0, 0, 0));
                v128 cmp = Sse2.cmpgt_epi32(splat, MASK_SMALL);

                cmp = Xse.negmask_epi32(cmp);
                cmp = Sse2.sub_epi32(cmp, Sse2.cmpgt_epi32(splat, MASK_LARGE));
                cmp = Sse2.add_epi32(cmp, Sse2.bsrli_si128(cmp, 2 * sizeof(int)));
                cmp = Sse2.add_epi32(cmp, Sse2.bsrli_si128(cmp, 1 * sizeof(int)));

                return tobyte(x > 999_999_999) + cmp.SInt0;
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int2>(Xse.log10_epi32(RegisterConversion.ToV128(x), 2));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int3>(Xse.log10_epi32(RegisterConversion.ToV128(x), 3));
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
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int4>(Xse.log10_epi32(RegisterConversion.ToV128(x), 4));
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
            else if (Sse2.IsSse2Supported)
            {
                return new int8(intlog10(x.v4_0), intlog10(x.v4_4));
            }
            else
            {
                return (int8)intlog10((uint8)x);
            }
        }


        /// <summary>       Computes the base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        [return: AssumeRange(0ul, 19ul)]
        [SkipLocalsInit]
        public static ulong intlog10(ulong x)
        {
            if (Xse.constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intlog10((uint)x);
            }

            UInt128* guess = stackalloc UInt128[65]
            {
                new UInt128(0, 19) - 10000000000000000000ul,
                new UInt128(0, 18) - 1000000000000000000ul,
                new UInt128(0, 18) - 1000000000000000000ul,
                new UInt128(0, 18) - 1000000000000000000ul,
                new UInt128(0, 18) - 1000000000000000000ul,
                new UInt128(0, 17) - 100000000000000000ul,
                new UInt128(0, 17) - 100000000000000000ul,
                new UInt128(0, 17) - 100000000000000000ul,
                new UInt128(0, 16) - 10000000000000000ul,
                new UInt128(0, 16) - 10000000000000000ul,
                new UInt128(0, 16) - 10000000000000000ul,
                new UInt128(0, 15) - 1000000000000000ul,
                new UInt128(0, 15) - 1000000000000000ul,
                new UInt128(0, 15) - 1000000000000000ul,
                new UInt128(0, 15) - 1000000000000000ul,
                new UInt128(0, 14) - 100000000000000ul,
                new UInt128(0, 14) - 100000000000000ul,
                new UInt128(0, 14) - 100000000000000ul,
                new UInt128(0, 13) - 10000000000000ul,
                new UInt128(0, 13) - 10000000000000ul,
                new UInt128(0, 13) - 10000000000000ul,
                new UInt128(0, 12) - 1000000000000ul,
                new UInt128(0, 12) - 1000000000000ul,
                new UInt128(0, 12) - 1000000000000ul,
                new UInt128(0, 12) - 1000000000000ul,
                new UInt128(0, 11) - 100000000000ul,
                new UInt128(0, 11) - 100000000000ul,
                new UInt128(0, 11) - 100000000000ul,
                new UInt128(0, 10) - 10000000000ul,
                new UInt128(0, 10) - 10000000000ul,
                new UInt128(0, 10) - 10000000000ul,
                new UInt128(0, 9)  - 1000000000ul,
                new UInt128(0, 9)  - 1000000000ul,
                new UInt128(0, 9)  - 1000000000ul,
                new UInt128(0, 9)  - 1000000000ul,
                new UInt128(0, 8)  - 100000000ul, 
                new UInt128(0, 8)  - 100000000ul, 
                new UInt128(0, 8)  - 100000000ul, 
                new UInt128(0, 7)  - 10000000ul, 
                new UInt128(0, 7)  - 10000000ul, 
                new UInt128(0, 7)  - 10000000ul, 
                new UInt128(0, 6)  - 1000000ul,
                new UInt128(0, 6)  - 1000000ul,
                new UInt128(0, 6)  - 1000000ul,
                new UInt128(0, 6)  - 1000000ul,
                new UInt128(0, 5)  - 100000ul,
                new UInt128(0, 5)  - 100000ul,
                new UInt128(0, 5)  - 100000ul,
                new UInt128(0, 4)  - 10000ul,
                new UInt128(0, 4)  - 10000ul,
                new UInt128(0, 4)  - 10000ul,
                new UInt128(0, 3)  - 1000ul,
                new UInt128(0, 3)  - 1000ul,
                new UInt128(0, 3)  - 1000ul,
                new UInt128(0, 3)  - 1000ul,
                new UInt128(0, 2)  - 100ul,
                new UInt128(0, 2)  - 100ul,
                new UInt128(0, 2)  - 100ul,
                new UInt128(0, 1)  - 10ul,
                new UInt128(0, 1)  - 10ul,
                new UInt128(0, 1)  - 10ul,
                new UInt128(0, 0), 
                new UInt128(0, 0), 
                new UInt128(0, 0), 
                new UInt128(0, 0), 
            };
            
            UInt128 adjust = guess[math.lzcnt(x)];
            
            return (adjust + x).hi64;
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intlog10(ulong2 x)
        {
            if (Sse2.IsSse2Supported)
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
            if (Xse.constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                return intlog10((uint)x);
            }

            return (long)intlog10((ulong)x);
        }

        /// <summary>       Computes the componentwise base-10 logarithm of <paramref name="x"/>. <paramref name="x"/> must be greater than or equal to 0, otherwise the result is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intlog10(long2 x)
        {
            if (Sse2.IsSse2Supported)
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