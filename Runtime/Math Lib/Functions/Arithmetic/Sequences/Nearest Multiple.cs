using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
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
            public static v128 roundmult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 h = srli_epi8(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU8(b, elements)))
                    {
                        v128 mask = dec_epi8(b);
                        result = and_si128(a, mask);
                        v128 floor = sub_epi8(a, result);
                        v128 overflow = cmpge_epu8(result, sub_epi8(b, h));
                        result = add_epi8(floor, and_si128(overflow, b));
                    }
                    else
                    {
                        result = rem_epu8(a, b, elements);
                        v128 overflow = cmpge_epu8(result, sub_epi8(b, h));
                        v128 subFrom = blendv_epi8(a, b, overflow);
                        result = add_epi8(and_si128(a, overflow), sub_epi8(subFrom, result));
                    }

                    Assume.roundmultiple(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.roundmultiple(result.Byte1,  a.Byte1,  b.Byte1);

                    if (elements > 2)
                    {
                        Assume.roundmultiple(result.Byte2,  a.Byte2,  b.Byte2);

                        if (elements > 3)
                        {
                            Assume.roundmultiple(result.Byte3,  a.Byte3,  b.Byte3);

                            if (elements > 4)
                            {
                                Assume.roundmultiple(result.Byte4,  a.Byte4,  b.Byte4);
                                Assume.roundmultiple(result.Byte5,  a.Byte5,  b.Byte5);
                                Assume.roundmultiple(result.Byte6,  a.Byte6,  b.Byte6);
                                Assume.roundmultiple(result.Byte7,  a.Byte7,  b.Byte7);

                                if (elements > 8)
                                {
                                    Assume.roundmultiple(result.Byte8,  a.Byte8,  b.Byte8);
                                    Assume.roundmultiple(result.Byte9,  a.Byte9,  b.Byte9);
                                    Assume.roundmultiple(result.Byte10, a.Byte10, b.Byte10);
                                    Assume.roundmultiple(result.Byte11, a.Byte11, b.Byte11);
                                    Assume.roundmultiple(result.Byte12, a.Byte12, b.Byte12);
                                    Assume.roundmultiple(result.Byte13, a.Byte13, b.Byte13);
                                    Assume.roundmultiple(result.Byte14, a.Byte14, b.Byte14);
                                    Assume.roundmultiple(result.Byte15, a.Byte15, b.Byte15);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 h = srli_epi16(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU16(b, elements)))
                    {
                        v128 mask = dec_epi16(b);
                        result = and_si128(a, mask);
                        v128 floor = sub_epi16(a, result);
                        v128 overflow = cmpge_epu16(result, sub_epi16(b, h));
                        result = add_epi16(floor, and_si128(overflow, b));
                    }
                    else
                    {
                        result = rem_epu16(a, b, elements);
                        v128 overflow = cmpge_epu16(result, sub_epi16(b, h));
                        v128 subFrom = blendv_si128(a, b, overflow);
                        result = add_epi16(and_si128(a, overflow), sub_epi16(subFrom, result));
                    }

                    Assume.roundmultiple(result.UShort0, a.UShort0, b.UShort0);
                    Assume.roundmultiple(result.UShort1, a.UShort1, b.UShort1);

                    if (elements > 2)
                    {
                        Assume.roundmultiple(result.UShort2, a.UShort2, b.UShort2);

                        if (elements > 3)
                        {
                            Assume.roundmultiple(result.UShort3, a.UShort3, b.UShort3);

                            if (elements > 4)
                            {
                                Assume.roundmultiple(result.UShort4, a.UShort4, b.UShort4);
                                Assume.roundmultiple(result.UShort5, a.UShort5, b.UShort5);
                                Assume.roundmultiple(result.UShort6, a.UShort6, b.UShort6);
                                Assume.roundmultiple(result.UShort7, a.UShort7, b.UShort7);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 h = srli_epi32(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU32(b, elements)))
                    {
                        v128 mask = dec_epi32(b);
                        result = and_si128(a, mask);
                        v128 floor = sub_epi32(a, result);
                        v128 overflow = cmpge_epu32(result, sub_epi32(b, h));
                        result = add_epi32(floor, and_si128(overflow, b));
                    }
                    else
                    {
                        result = rem_epu32(a, b, elements);
                        v128 overflow = cmpge_epu32(result, sub_epi32(b, h));
                        v128 subFrom = blendv_si128(a, b, overflow);
                        result = add_epi32(and_si128(a, overflow), sub_epi32(subFrom, result));
                    }

                    Assume.roundmultiple(result.UInt0, a.UInt0, b.UInt0);
                    Assume.roundmultiple(result.UInt1, a.UInt1, b.UInt1);

                    if (elements > 2)
                    {
                        Assume.roundmultiple(result.UInt2, a.UInt2, b.UInt2);

                        if (elements > 3)
                        {
                            Assume.roundmultiple(result.UInt3, a.UInt3, b.UInt3);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epu64(v128 a, v128 b, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 h = srli_epi64(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU64(b)))
                    {
                        v128 mask = dec_epi64(b);
                        result = and_si128(a, mask);
                        v128 floor = sub_epi64(a, result);
                        v128 overflow;
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    overflow = cmpge_epu64(result, sub_epi64(b, h));
                        //}
                        //else
                        //{
                              overflow = cmpgt_epu64(result, dec_epi64(sub_epi64(b, h)));
                        //}
                        result = add_epi64(floor, and_si128(overflow, b));
                    }
                    else
                    {
                        result = rem_epu64(a, b);
                        v128 overflow;
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    overflow = cmpge_epu64(result, sub_epi64(b, h));
                        //}
                        //else
                        //{
                              overflow = cmpgt_epu64(result, dec_epi64(sub_epi64(b, h)));
                        //}
                        v128 subFrom = blendv_si128(a, b, overflow);
                        result = add_epi64(and_si128(a, overflow), sub_epi64(subFrom, result));
                    }

                    Assume.roundmultiple(result.ULong0, a.ULong0, b.ULong0);
                    Assume.roundmultiple(result.ULong1, a.ULong1, b.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 floorResult = floormult_epi8(a, b, elements, pow2, nonNegative);
                    v128 r = sub_epi8(a, floorResult);
                    v128 h = srli_epi8(b, 1, elements: elements);
                    v128 notRoundUp = cmpgt_epi8(sub_epi8(b, h), r);
                    v128 result = add_epi8(floorResult, andnot_si128(notRoundUp, b));

                    Assume.roundmultiple(result.SByte0,  a.SByte0,  b.Byte0,  pow2);
                    Assume.roundmultiple(result.SByte1,  a.SByte1,  b.Byte1,  pow2);

                    if (elements > 2)
                    {
                        Assume.roundmultiple(result.SByte2,  a.SByte2,  b.Byte2,  pow2);

                        if (elements > 3)
                        {
                            Assume.roundmultiple(result.SByte3,  a.SByte3,  b.Byte3,  pow2);

                            if (elements > 4)
                            {
                                Assume.roundmultiple(result.SByte4,  a.SByte4,  b.Byte4,  pow2);
                                Assume.roundmultiple(result.SByte5,  a.SByte5,  b.Byte5,  pow2);
                                Assume.roundmultiple(result.SByte6,  a.SByte6,  b.Byte6,  pow2);
                                Assume.roundmultiple(result.SByte7,  a.SByte7,  b.Byte7,  pow2);

                                if (elements > 8)
                                {
                                    Assume.roundmultiple(result.SByte8,  a.SByte8,  b.Byte8,  pow2);
                                    Assume.roundmultiple(result.SByte9,  a.SByte9,  b.Byte9,  pow2);
                                    Assume.roundmultiple(result.SByte10, a.SByte10, b.Byte10, pow2);
                                    Assume.roundmultiple(result.SByte11, a.SByte11, b.Byte11, pow2);
                                    Assume.roundmultiple(result.SByte12, a.SByte12, b.Byte12, pow2);
                                    Assume.roundmultiple(result.SByte13, a.SByte13, b.Byte13, pow2);
                                    Assume.roundmultiple(result.SByte14, a.SByte14, b.Byte14, pow2);
                                    Assume.roundmultiple(result.SByte15, a.SByte15, b.Byte15, pow2);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 floorResult = floormult_epi16(a, b, elements, pow2, nonNegative);
                    v128 r = sub_epi16(a, floorResult);
                    v128 h = srli_epi16(b, 1);
                    v128 notRoundUp = cmpgt_epi16(sub_epi16(b, h), r);
                    v128 result = add_epi16(floorResult, andnot_si128(notRoundUp, b));

                    Assume.roundmultiple(result.SShort0, a.SShort0, b.UShort0, pow2);
                    Assume.roundmultiple(result.SShort1, a.SShort1, b.UShort1, pow2);

                    if (elements > 2)
                    {
                        Assume.roundmultiple(result.SShort2, a.SShort2, b.UShort2, pow2);

                        if (elements > 3)
                        {
                            Assume.roundmultiple(result.SShort3, a.SShort3, b.UShort3, pow2);

                            if (elements > 4)
                            {
                                Assume.roundmultiple(result.SShort4, a.SShort4, b.UShort4, pow2);
                                Assume.roundmultiple(result.SShort5, a.SShort5, b.UShort5, pow2);
                                Assume.roundmultiple(result.SShort6, a.SShort6, b.UShort6, pow2);
                                Assume.roundmultiple(result.SShort7, a.SShort7, b.UShort7, pow2);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 floorResult = floormult_epi32(a, b, elements, pow2, nonNegative);
                    v128 r = sub_epi32(a, floorResult);
                    v128 h = srli_epi32(b, 1);
                    v128 notRoundUp = cmpgt_epi32(sub_epi32(b, h), r);
                    v128 result = add_epi32(floorResult, andnot_si128(notRoundUp, b));

                    Assume.roundmultiple(result.SInt0, a.SInt0, b.UInt0, pow2);
                    Assume.roundmultiple(result.SInt1, a.SInt1, b.UInt1, pow2);

                    if (elements > 2)
                    {
                        Assume.roundmultiple(result.SInt2, a.SInt2, b.UInt2, pow2);

                        if (elements > 3)
                        {
                            Assume.roundmultiple(result.SInt3, a.SInt3, b.UInt3, pow2);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_epi64(v128 a, v128 b, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 floorResult = floormult_epi64(a, b, pow2, nonNegative);
                    v128 r = sub_epi64(a, floorResult);
                    v128 h = srli_epi64(b, 1);
                    v128 notRoundUp = cmpgt_epi64(sub_epi64(b, h), r);
                    v128 result = add_epi64(floorResult, andnot_si128(notRoundUp, b));

                    Assume.roundmultiple(result.SLong0, a.SLong0, b.ULong0, pow2);
                    Assume.roundmultiple(result.SLong1, a.SLong1, b.ULong1, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu8(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    v256 h = mm256_srli_epi8(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU8(b)))
                    {
                        v256 mask = mm256_dec_epi8(b);
                        result = Avx2.mm256_and_si256(a, mask);
                        v256 floor = Avx2.mm256_sub_epi8(a, result);
                        v256 overflow = mm256_cmpge_epu8(result, Avx2.mm256_sub_epi8(b, h));
                        result = Avx2.mm256_add_epi8(floor, Avx2.mm256_and_si256(overflow, b));
                    }
                    else
                    {
                        result = mm256_rem_epu8(a, b);
                        v256 overflow = mm256_cmpge_epu8(result, Avx2.mm256_sub_epi8(b, h));
                        v256 subFrom = Avx2.mm256_blendv_epi8(a, b, overflow);
                        result = Avx2.mm256_add_epi8(Avx2.mm256_and_si256(a, overflow), Avx2.mm256_sub_epi8(subFrom, result));
                    }

                    Assume.roundmultiple(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.roundmultiple(result.Byte1,  a.Byte1,  b.Byte1);
                    Assume.roundmultiple(result.Byte2,  a.Byte2,  b.Byte2);
                    Assume.roundmultiple(result.Byte3,  a.Byte3,  b.Byte3);
                    Assume.roundmultiple(result.Byte4,  a.Byte4,  b.Byte4);
                    Assume.roundmultiple(result.Byte5,  a.Byte5,  b.Byte5);
                    Assume.roundmultiple(result.Byte6,  a.Byte6,  b.Byte6);
                    Assume.roundmultiple(result.Byte7,  a.Byte7,  b.Byte7);
                    Assume.roundmultiple(result.Byte8,  a.Byte8,  b.Byte8);
                    Assume.roundmultiple(result.Byte9,  a.Byte9,  b.Byte9);
                    Assume.roundmultiple(result.Byte10, a.Byte10, b.Byte10);
                    Assume.roundmultiple(result.Byte11, a.Byte11, b.Byte11);
                    Assume.roundmultiple(result.Byte12, a.Byte12, b.Byte12);
                    Assume.roundmultiple(result.Byte13, a.Byte13, b.Byte13);
                    Assume.roundmultiple(result.Byte14, a.Byte14, b.Byte14);
                    Assume.roundmultiple(result.Byte15, a.Byte15, b.Byte15);
                    Assume.roundmultiple(result.Byte16, a.Byte16, b.Byte16);
                    Assume.roundmultiple(result.Byte17, a.Byte17, b.Byte17);
                    Assume.roundmultiple(result.Byte18, a.Byte18, b.Byte18);
                    Assume.roundmultiple(result.Byte19, a.Byte19, b.Byte19);
                    Assume.roundmultiple(result.Byte20, a.Byte20, b.Byte20);
                    Assume.roundmultiple(result.Byte21, a.Byte21, b.Byte21);
                    Assume.roundmultiple(result.Byte22, a.Byte22, b.Byte22);
                    Assume.roundmultiple(result.Byte23, a.Byte23, b.Byte23);
                    Assume.roundmultiple(result.Byte24, a.Byte24, b.Byte24);
                    Assume.roundmultiple(result.Byte25, a.Byte25, b.Byte25);
                    Assume.roundmultiple(result.Byte26, a.Byte26, b.Byte26);
                    Assume.roundmultiple(result.Byte27, a.Byte27, b.Byte27);
                    Assume.roundmultiple(result.Byte28, a.Byte28, b.Byte28);
                    Assume.roundmultiple(result.Byte29, a.Byte29, b.Byte29);
                    Assume.roundmultiple(result.Byte30, a.Byte30, b.Byte30);
                    Assume.roundmultiple(result.Byte31, a.Byte31, b.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu16(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    v256 h = mm256_srli_epi16(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU16(b)))
                    {
                        v256 mask = mm256_dec_epi16(b);
                        result = Avx2.mm256_and_si256(a, mask);
                        v256 floor = Avx2.mm256_sub_epi16(a, result);
                        v256 overflow = mm256_cmpge_epu16(result, Avx2.mm256_sub_epi16(b, h));
                        result = Avx2.mm256_add_epi16(floor, Avx2.mm256_and_si256(overflow, b));
                    }
                    else
                    {
                        result = mm256_rem_epu16(a, b);
                        v256 overflow = mm256_cmpge_epu16(result, Avx2.mm256_sub_epi16(b, h));
                        v256 subFrom = mm256_blendv_si256(a, b, overflow);
                        result = Avx2.mm256_add_epi16(Avx2.mm256_and_si256(a, overflow), Avx2.mm256_sub_epi16(subFrom, result));
                    }

                    Assume.roundmultiple(result.UShort0,  a.UShort0,  b.UShort0);
                    Assume.roundmultiple(result.UShort1,  a.UShort1,  b.UShort1);
                    Assume.roundmultiple(result.UShort2,  a.UShort2,  b.UShort2);
                    Assume.roundmultiple(result.UShort3,  a.UShort3,  b.UShort3);
                    Assume.roundmultiple(result.UShort4,  a.UShort4,  b.UShort4);
                    Assume.roundmultiple(result.UShort5,  a.UShort5,  b.UShort5);
                    Assume.roundmultiple(result.UShort6,  a.UShort6,  b.UShort6);
                    Assume.roundmultiple(result.UShort7,  a.UShort7,  b.UShort7);
                    Assume.roundmultiple(result.UShort8,  a.UShort8,  b.UShort8);
                    Assume.roundmultiple(result.UShort9,  a.UShort9,  b.UShort9);
                    Assume.roundmultiple(result.UShort10, a.UShort10, b.UShort10);
                    Assume.roundmultiple(result.UShort11, a.UShort11, b.UShort11);
                    Assume.roundmultiple(result.UShort12, a.UShort12, b.UShort12);
                    Assume.roundmultiple(result.UShort13, a.UShort13, b.UShort13);
                    Assume.roundmultiple(result.UShort14, a.UShort14, b.UShort14);
                    Assume.roundmultiple(result.UShort15, a.UShort15, b.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu32(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    v256 h = mm256_srli_epi32(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU32(b)))
                    {
                        v256 mask = mm256_dec_epi32(b);
                        result = Avx2.mm256_and_si256(a, mask);
                        v256 floor = Avx2.mm256_sub_epi32(a, result);
                        v256 overflow = mm256_cmpge_epu32(result, Avx2.mm256_sub_epi32(b, h));
                        result = Avx2.mm256_add_epi32(floor, Avx2.mm256_and_si256(overflow, b));
                    }
                    else
                    {
                        result = mm256_rem_epu32(a, b);
                        v256 overflow = mm256_cmpge_epu32(result, Avx2.mm256_sub_epi32(b, h));
                        v256 subFrom = mm256_blendv_si256(a, b, overflow);
                        result = Avx2.mm256_add_epi32(Avx2.mm256_and_si256(a, overflow), Avx2.mm256_sub_epi32(subFrom, result));
                    }

                    Assume.roundmultiple(result.UInt0, a.UInt0, b.UInt0);
                    Assume.roundmultiple(result.UInt1, a.UInt1, b.UInt1);
                    Assume.roundmultiple(result.UInt2, a.UInt2, b.UInt2);
                    Assume.roundmultiple(result.UInt3, a.UInt3, b.UInt3);
                    Assume.roundmultiple(result.UInt4, a.UInt4, b.UInt4);
                    Assume.roundmultiple(result.UInt5, a.UInt5, b.UInt5);
                    Assume.roundmultiple(result.UInt6, a.UInt6, b.UInt6);
                    Assume.roundmultiple(result.UInt7, a.UInt7, b.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    v256 h = mm256_srli_epi64(b, 1);

                    if (pow2 || constexpr.IS_TRUE(constexpr.ALL_POW2_EPU64(b, elements)))
                    {
                        v256 mask = mm256_dec_epi64(b);
                        result = Avx2.mm256_and_si256(a, mask);
                        v256 floor = Avx2.mm256_sub_epi64(a, result);
                        v256 overflow;
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    overflow = mm256_cmpge_epu64(result, Avx2.mm256_sub_epi64(b, h));
                        //}
                        //else
                        //{
                              overflow = mm256_cmpgt_epu64(result, mm256_dec_epi64(Avx2.mm256_sub_epi64(b, h)));
                        //}
                        result = Avx2.mm256_add_epi64(floor, Avx2.mm256_and_si256(overflow, b));
                    }
                    else
                    {
                        result = mm256_rem_epu64(a, b, elements: elements);
                        v256 overflow;
                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    overflow = mm256_cmpge_epu64(result, Avx2.mm256_sub_epi64(b, h));
                        //}
                        //else
                        //{
                              overflow = mm256_cmpgt_epu64(result, mm256_dec_epi64(Avx2.mm256_sub_epi64(b, h)));
                        //}
                        v256 subFrom = mm256_blendv_si256(a, b, overflow);
                        result = Avx2.mm256_add_epi64(Avx2.mm256_and_si256(a, overflow), Avx2.mm256_sub_epi64(subFrom, result));
                    }

                    Assume.roundmultiple(result.ULong0, a.ULong0, b.ULong0);
                    Assume.roundmultiple(result.ULong1, a.ULong1, b.ULong1);
                    Assume.roundmultiple(result.ULong2, a.ULong2, b.ULong2);

                    if (elements > 3)
                    {
                        Assume.roundmultiple(result.ULong3, a.ULong3, b.ULong3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi8(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 floorResult = mm256_floormult_epi8(a, b, pow2, nonNegative);
                    v256 r = Avx2.mm256_sub_epi8(a, floorResult);
                    v256 h = mm256_srli_epi8(b, 1);
                    v256 notRoundUp = Avx2.mm256_cmpgt_epi8(Avx2.mm256_sub_epi8(b, h), r);
                    v256 result = Avx2.mm256_add_epi8(floorResult, Avx2.mm256_andnot_si256(notRoundUp, b));

                    Assume.roundmultiple(result.SByte0,  a.SByte0,  b.Byte0,  pow2);
                    Assume.roundmultiple(result.SByte1,  a.SByte1,  b.Byte1,  pow2);
                    Assume.roundmultiple(result.SByte2,  a.SByte2,  b.Byte2,  pow2);
                    Assume.roundmultiple(result.SByte3,  a.SByte3,  b.Byte3,  pow2);
                    Assume.roundmultiple(result.SByte4,  a.SByte4,  b.Byte4,  pow2);
                    Assume.roundmultiple(result.SByte5,  a.SByte5,  b.Byte5,  pow2);
                    Assume.roundmultiple(result.SByte6,  a.SByte6,  b.Byte6,  pow2);
                    Assume.roundmultiple(result.SByte7,  a.SByte7,  b.Byte7,  pow2);
                    Assume.roundmultiple(result.SByte8,  a.SByte8,  b.Byte8,  pow2);
                    Assume.roundmultiple(result.SByte9,  a.SByte9,  b.Byte9,  pow2);
                    Assume.roundmultiple(result.SByte10, a.SByte10, b.Byte10, pow2);
                    Assume.roundmultiple(result.SByte11, a.SByte11, b.Byte11, pow2);
                    Assume.roundmultiple(result.SByte12, a.SByte12, b.Byte12, pow2);
                    Assume.roundmultiple(result.SByte13, a.SByte13, b.Byte13, pow2);
                    Assume.roundmultiple(result.SByte14, a.SByte14, b.Byte14, pow2);
                    Assume.roundmultiple(result.SByte15, a.SByte15, b.Byte15, pow2);
                    Assume.roundmultiple(result.SByte16, a.SByte16, b.Byte16, pow2);
                    Assume.roundmultiple(result.SByte17, a.SByte17, b.Byte17, pow2);
                    Assume.roundmultiple(result.SByte18, a.SByte18, b.Byte18, pow2);
                    Assume.roundmultiple(result.SByte19, a.SByte19, b.Byte19, pow2);
                    Assume.roundmultiple(result.SByte20, a.SByte20, b.Byte20, pow2);
                    Assume.roundmultiple(result.SByte21, a.SByte21, b.Byte21, pow2);
                    Assume.roundmultiple(result.SByte22, a.SByte22, b.Byte22, pow2);
                    Assume.roundmultiple(result.SByte23, a.SByte23, b.Byte23, pow2);
                    Assume.roundmultiple(result.SByte24, a.SByte24, b.Byte24, pow2);
                    Assume.roundmultiple(result.SByte25, a.SByte25, b.Byte25, pow2);
                    Assume.roundmultiple(result.SByte26, a.SByte26, b.Byte26, pow2);
                    Assume.roundmultiple(result.SByte27, a.SByte27, b.Byte27, pow2);
                    Assume.roundmultiple(result.SByte28, a.SByte28, b.Byte28, pow2);
                    Assume.roundmultiple(result.SByte29, a.SByte29, b.Byte29, pow2);
                    Assume.roundmultiple(result.SByte30, a.SByte30, b.Byte30, pow2);
                    Assume.roundmultiple(result.SByte31, a.SByte31, b.Byte31, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi16(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 floorResult = mm256_floormult_epi16(a, b, pow2, nonNegative);
                    v256 r = Avx2.mm256_sub_epi16(a, floorResult);
                    v256 h = mm256_srli_epi16(b, 1);
                    v256 notRoundUp = Avx2.mm256_cmpgt_epi16(Avx2.mm256_sub_epi16(b, h), r);
                    v256 result = Avx2.mm256_add_epi16(floorResult, Avx2.mm256_andnot_si256(notRoundUp, b));

                    Assume.roundmultiple(result.SShort0,  a.SShort0,  b.UShort0,  pow2);
                    Assume.roundmultiple(result.SShort1,  a.SShort1,  b.UShort1,  pow2);
                    Assume.roundmultiple(result.SShort2,  a.SShort2,  b.UShort2,  pow2);
                    Assume.roundmultiple(result.SShort3,  a.SShort3,  b.UShort3,  pow2);
                    Assume.roundmultiple(result.SShort4,  a.SShort4,  b.UShort4,  pow2);
                    Assume.roundmultiple(result.SShort5,  a.SShort5,  b.UShort5,  pow2);
                    Assume.roundmultiple(result.SShort6,  a.SShort6,  b.UShort6,  pow2);
                    Assume.roundmultiple(result.SShort7,  a.SShort7,  b.UShort7,  pow2);
                    Assume.roundmultiple(result.SShort8,  a.SShort8,  b.UShort8,  pow2);
                    Assume.roundmultiple(result.SShort9,  a.SShort9,  b.UShort9,  pow2);
                    Assume.roundmultiple(result.SShort10, a.SShort10, b.UShort10, pow2);
                    Assume.roundmultiple(result.SShort11, a.SShort11, b.UShort11, pow2);
                    Assume.roundmultiple(result.SShort12, a.SShort12, b.UShort12, pow2);
                    Assume.roundmultiple(result.SShort13, a.SShort13, b.UShort13, pow2);
                    Assume.roundmultiple(result.SShort14, a.SShort14, b.UShort14, pow2);
                    Assume.roundmultiple(result.SShort15, a.SShort15, b.UShort15, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi32(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 floorResult = mm256_floormult_epi32(a, b, pow2, nonNegative);
                    v256 r = Avx2.mm256_sub_epi32(a, floorResult);
                    v256 h = mm256_srli_epi32(b, 1);
                    v256 notRoundUp = Avx2.mm256_cmpgt_epi32(Avx2.mm256_sub_epi32(b, h), r);
                    v256 result = Avx2.mm256_add_epi32(floorResult, Avx2.mm256_andnot_si256(notRoundUp, b));

                    Assume.roundmultiple(result.SInt0, a.SInt0, b.UInt0, pow2);
                    Assume.roundmultiple(result.SInt1, a.SInt1, b.UInt1, pow2);
                    Assume.roundmultiple(result.SInt2, a.SInt2, b.UInt2, pow2);
                    Assume.roundmultiple(result.SInt3, a.SInt3, b.UInt3, pow2);
                    Assume.roundmultiple(result.SInt4, a.SInt4, b.UInt4, pow2);
                    Assume.roundmultiple(result.SInt5, a.SInt5, b.UInt5, pow2);
                    Assume.roundmultiple(result.SInt6, a.SInt6, b.UInt6, pow2);
                    Assume.roundmultiple(result.SInt7, a.SInt7, b.UInt7, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 floorResult = mm256_floormult_epi64(a, b, elements, pow2, nonNegative);
                    v256 r = Avx2.mm256_sub_epi64(a, floorResult);
                    v256 h = mm256_srli_epi64(b, 1);
                    v256 notRoundUp = Avx2.mm256_cmpgt_epi64(Avx2.mm256_sub_epi64(b, h), r);
                    v256 result = Avx2.mm256_add_epi64(floorResult, Avx2.mm256_andnot_si256(notRoundUp, b));

                    Assume.roundmultiple(result.SLong0, a.SLong0, b.ULong0, pow2);
                    Assume.roundmultiple(result.SLong1, a.SLong1, b.ULong1, pow2);
                    Assume.roundmultiple(result.SLong2, a.SLong2, b.ULong2, pow2);

                    if (elements > 3)
                    {
                        Assume.roundmultiple(result.SLong3, a.SLong3, b.ULong3, pow2);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_ps(b, round_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_round_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 roundmult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_pd(b, round_pd(div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_roundmult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_round_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    
    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(byte result, byte x, byte n)
        {
            byte b = (byte)(n >> 1);
            if (constexpr.IS_TRUE(x <= (byte)(byte.MaxValue - b)))
            {
                constexpr.ASSUME((byte)(result % n) == 0);
                constexpr.ASSUME(x < b || result >= (byte)(x - b));
                constexpr.ASSUME(result <= (byte)((byte)(x + n) - b) || (byte)(x + n) < x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(ushort result, ushort x, ushort n)
        {
            ushort b = (ushort)(n >> 1);
            if (constexpr.IS_TRUE(x <= (ushort)(ushort.MaxValue - b)))
            {
                constexpr.ASSUME((ushort)(result % n) == 0);
                constexpr.ASSUME(x < b || result >= (ushort)(x - b));
                constexpr.ASSUME(result <= (ushort)((ushort)(x + n) - b) || (ushort)(x + n) < x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(uint result, uint x, uint n)
        {
            uint b = n >> 1;
            if (constexpr.IS_TRUE(x <= uint.MaxValue - b))
            {
                constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(x < b || result >= x - b);
                constexpr.ASSUME(result <= x + n - b || x + n < x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(ulong result, ulong x, ulong n)
        {
            ulong b = n >> 1;
            if (constexpr.IS_TRUE(x <= ulong.MaxValue - b))
            {
                constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(x < b || result >= x - b);
                constexpr.ASSUME(result <= x + n - b || x + n < x);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(sbyte result, sbyte x, byte n, bool pow2)
        {
            byte b = (byte)(n >> 1);
            byte c = (byte)(n - b);

            bool noOverflow = (byte)((byte)x - (1u << 7)) >= b
                           && (byte)((byte)sbyte.MaxValue - (byte)x) >= c;

            if (constexpr.IS_TRUE(noOverflow))
            {
                if (pow2)
                {
                    constexpr.ASSUME(result % (sbyte)n == 0);
                    constexpr.ASSUME(((byte)((byte)result & (byte)(n - 1))) == 0);
                }
                else if (constexpr.IS_TRUE(n <= sbyte.MaxValue))
                {
                    constexpr.ASSUME(result % (sbyte)n == 0);
                }
                else
                {
                    constexpr.ASSUME(result == 0);
                }

                constexpr.ASSUME(result >= (sbyte)((byte)x - b));
                constexpr.ASSUME(result <= (sbyte)((byte)x + c));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(short result, short x, ushort n, bool pow2)
        {
            ushort b = (ushort)(n >> 1);
            ushort c = (ushort)(n - b);

            bool noOverflow = (ushort)((ushort)x - (1u << 15)) >= b
                           && (ushort)((ushort)short.MaxValue - (ushort)x) >= c;

            if (constexpr.IS_TRUE(noOverflow))
            {
                if (pow2)
                {
                    constexpr.ASSUME(result % (short)n == 0);
                    constexpr.ASSUME(((ushort)((ushort)result & (ushort)(n - 1))) == 0);
                }
                else if (constexpr.IS_TRUE(n <= short.MaxValue))
                {
                    constexpr.ASSUME(result % (short)n == 0);
                }
                else
                {
                    constexpr.ASSUME(result == 0);
                }

                constexpr.ASSUME(result >= (short)((ushort)x - b));
                constexpr.ASSUME(result <= (short)((ushort)x + c));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(int result, int x, uint n, bool pow2)
        {
            uint b = n >> 1;
            uint c = n - b;

            bool noOverflow = (uint)x - (1u << 31) >= b
                           && (uint)int.MaxValue - (uint)x >= c;

            if (constexpr.IS_TRUE(noOverflow))
            {
                if (pow2)
                {
                    constexpr.ASSUME(result % (int)n == 0);
                    constexpr.ASSUME(((uint)result & (n - 1)) == 0);
                }
                else if (constexpr.IS_TRUE(n <= int.MaxValue))
                {
                    constexpr.ASSUME(result % (int)n == 0);
                }
                else
                {
                    constexpr.ASSUME(result == 0);
                }

                constexpr.ASSUME(result >= (int)((uint)x - b));
                constexpr.ASSUME(result <= (int)((uint)x + c));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void roundmultiple(long result, long x, ulong n, bool pow2)
        {
            ulong b = n >> 1;
            ulong c = n - b;

            bool noOverflow = (ulong)x - (1ul << 63) >= b
                           && (ulong)long.MaxValue - (ulong)x >= c;

            if (constexpr.IS_TRUE(noOverflow))
            {
                if (pow2)
                {
                    constexpr.ASSUME(result % (long)n == 0);
                    constexpr.ASSUME(((ulong)result & (n - 1)) == 0);
                }
                else if (constexpr.IS_TRUE(n <= long.MaxValue))
                {
                    constexpr.ASSUME(result % (long)n == 0);
                }
                else
                {
                    constexpr.ASSUME(result == 0);
                }

                constexpr.ASSUME(result >= (long)((ulong)x - b));
                constexpr.ASSUME(result <= (long)((ulong)x + c));
            }
        }
    }

    unsafe public static partial class math
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 roundmultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            UInt128 result;
            UInt128 b = n >> 1;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= UInt128.MaxValue - b))
                {
                    result = (x + b) & (0 - n);  
                }
                else
                {
                    UInt128 mask = n - 1;
                    result = x & mask;
                    UInt128 floor = x - result;
                    result = result >= n - b ? floor + n : floor;
                }
            }
            else
            {
                result = x % n;
                result = result >= n - b ? x + (n - result) : x - result;
            }
            
            if (constexpr.IS_TRUE(x <= UInt128.MaxValue - b))
            {
                //constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(x < b || result >= x - b);
                constexpr.ASSUME(result <= x + n - b || x + n < x);
            }

            return result;
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 roundmultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            Int128 floorResult = floormultiple(x, n, promises);
            UInt128 b = n >> 1;
            Int128 r = x - floorResult;
            Int128 result = (UInt128)r >= n - b ? floorResult + (Int128)n : floorResult;
            
            UInt128 c = n - b;
            bool noOverflow = (UInt128)x - ((UInt128)1 << 127) >= b
                           && (UInt128)Int128.MaxValue - (UInt128)x >= c;

            if (constexpr.IS_TRUE(noOverflow))
            {
                if (promises.Promises(Promise.Unsafe0))
                {
                    //constexpr.ASSUME(result % (Int128)n == 0);
                    constexpr.ASSUME(((UInt128)result & (n - 1)) == 0);
                }
                else if (constexpr.IS_TRUE(n <= (UInt128)Int128.MaxValue))
                {
                    //constexpr.ASSUME(result % (Int128)n == 0);
                }
                else
                {
                    constexpr.ASSUME(result == 0);
                }

                constexpr.ASSUME(result >= (Int128)((UInt128)x - b));
                constexpr.ASSUME(result <= (Int128)((UInt128)x + c));
            }

            return result;
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong roundmultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            ulong result;
            ulong b = n >> 1;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= ulong.MaxValue - b))
                {
                    result = (x + b) & (0 - n);  
                }
                else
                {
                    ulong mask = n - 1;
                    result = x & mask;
                    ulong floor = x - result;
                    result = result >= n - b ? floor + n : floor;
                }
            }
            else
            {
                result = x % n;
                result = result >= n - b ? x + (n - result) : x - result;
            }

            Assume.roundmultiple(result, x, n);

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 roundmultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 roundmultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong3(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 roundmultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong4(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long roundmultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            long floorResult = floormultiple(x, n, promises);
            ulong b = n >> 1;
            long r = x - floorResult;
            long result = (ulong)r >= n - b ? floorResult + (long)n : floorResult;

            Assume.roundmultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 roundmultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 roundmultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long3(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 roundmultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long4(roundmultiple(x.xy, n.xy, promises), roundmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint roundmultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            uint result;
            uint b = n >> 1;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= uint.MaxValue - b))
                {
                    result = (x + b) & (0 - n);  
                }
                else
                {
                    uint mask = n - 1;
                    result = x & mask;
                    uint floor = x - result;
                    result = result >= n - b ? floor + n : floor;
                }
            }
            else
            {
                result = x % n;
                result = result >= n - b ? x + (n - result) : x - result;
            }

            Assume.roundmultiple(result, x, n);

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 roundmultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu32(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 roundmultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu32(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 roundmultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu32(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 roundmultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint8(roundmultiple(x.v4_0, n.v4_0, promises), roundmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int roundmultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            int floorResult = floormultiple(x, n, promises);
            uint b = n >> 1;
            int r = x - floorResult;
            int result = (uint)r >= n - b ? floorResult + (int)n : floorResult;

            Assume.roundmultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 roundmultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi32(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 roundmultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi32(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 roundmultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi32(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 roundmultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int8(roundmultiple(x.v4_0, n.v4_0, promises), roundmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort roundmultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return (ushort)roundmultiple((uint)x, n, promises | Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 roundmultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 roundmultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 roundmultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 roundmultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort8(roundmultiple(x.x0, n.x0, promises),
                                   roundmultiple(x.x1, n.x1, promises),
                                   roundmultiple(x.x2, n.x2, promises),
                                   roundmultiple(x.x3, n.x3, promises),
                                   roundmultiple(x.x4, n.x4, promises),
                                   roundmultiple(x.x5, n.x5, promises),
                                   roundmultiple(x.x6, n.x6, promises),
                                   roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 roundmultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort16(roundmultiple(x.v8_0, n.v8_0, promises), roundmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short roundmultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)roundmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 roundmultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 roundmultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 roundmultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 roundmultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short8(roundmultiple(x.x0, n.x0, promises),
                                  roundmultiple(x.x1, n.x1, promises),
                                  roundmultiple(x.x2, n.x2, promises),
                                  roundmultiple(x.x3, n.x3, promises),
                                  roundmultiple(x.x4, n.x4, promises),
                                  roundmultiple(x.x5, n.x5, promises),
                                  roundmultiple(x.x6, n.x6, promises),
                                  roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 roundmultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short16(roundmultiple(x.v8_0, n.v8_0, promises), roundmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte roundmultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return (byte)roundmultiple((uint)x, n, promises | Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 roundmultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 roundmultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 roundmultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 roundmultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte8(roundmultiple(x.x0, n.x0, promises),
                                 roundmultiple(x.x1, n.x1, promises),
                                 roundmultiple(x.x2, n.x2, promises),
                                 roundmultiple(x.x3, n.x3, promises),
                                 roundmultiple(x.x4, n.x4, promises),
                                 roundmultiple(x.x5, n.x5, promises),
                                 roundmultiple(x.x6, n.x6, promises),
                                 roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 roundmultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epu8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte16(roundmultiple(x.x0,  n.x0,  promises),
                                  roundmultiple(x.x1,  n.x1,  promises),
                                  roundmultiple(x.x2,  n.x2,  promises),
                                  roundmultiple(x.x3,  n.x3,  promises),
                                  roundmultiple(x.x4,  n.x4,  promises),
                                  roundmultiple(x.x5,  n.x5,  promises),
                                  roundmultiple(x.x6,  n.x6,  promises),
                                  roundmultiple(x.x7,  n.x7,  promises),
                                  roundmultiple(x.x8,  n.x8,  promises),
                                  roundmultiple(x.x9,  n.x9,  promises),
                                  roundmultiple(x.x10, n.x10, promises),
                                  roundmultiple(x.x11, n.x11, promises),
                                  roundmultiple(x.x12, n.x12, promises),
                                  roundmultiple(x.x13, n.x13, promises),
                                  roundmultiple(x.x14, n.x14, promises),
                                  roundmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword=">>"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 roundmultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epu8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte32(roundmultiple(x.v16_0, n.v16_0, promises), roundmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte roundmultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)roundmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 roundmultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte2(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 roundmultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte3(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 roundmultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte4(roundmultiple(x.x, n.x, promises), roundmultiple(x.y, n.y, promises), roundmultiple(x.z, n.z, promises), roundmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 roundmultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte8(roundmultiple(x.x0, n.x0, promises),
                                  roundmultiple(x.x1, n.x1, promises),
                                  roundmultiple(x.x2, n.x2, promises),
                                  roundmultiple(x.x3, n.x3, promises),
                                  roundmultiple(x.x4, n.x4, promises),
                                  roundmultiple(x.x5, n.x5, promises),
                                  roundmultiple(x.x6, n.x6, promises),
                                  roundmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 roundmultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte16(roundmultiple(x.x0,  n.x0,  promises),
                                   roundmultiple(x.x1,  n.x1,  promises),
                                   roundmultiple(x.x2,  n.x2,  promises),
                                   roundmultiple(x.x3,  n.x3,  promises),
                                   roundmultiple(x.x4,  n.x4,  promises),
                                   roundmultiple(x.x5,  n.x5,  promises),
                                   roundmultiple(x.x6,  n.x6,  promises),
                                   roundmultiple(x.x7,  n.x7,  promises),
                                   roundmultiple(x.x8,  n.x8,  promises),
                                   roundmultiple(x.x9,  n.x9,  promises),
                                   roundmultiple(x.x10, n.x10, promises),
                                   roundmultiple(x.x11, n.x11, promises),
                                   roundmultiple(x.x12, n.x12, promises),
                                   roundmultiple(x.x13, n.x13, promises),
                                   roundmultiple(x.x14, n.x14, promises),
                                   roundmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 roundmultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_roundmult_epi8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(roundmultiple(x.v16_0, n.v16_0, promises), roundmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float roundmultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * round(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 roundmultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_ps(x, m, 2);
            }
            else
            {
                return new float2(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 roundmultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_ps(x, m, 3);
            }
            else
            {
                return new float3(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y), roundmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 roundmultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_ps(x, m, 4);
            }
            else
            {
                return new float4(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y), roundmultiple(x.z, m.z), roundmultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 roundmultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_roundmult_ps(x, m);
            }
            else
            {
                return new float8(roundmultiple(x.v4_0, m.v4_0), roundmultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double roundmultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * round(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 roundmultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.roundmult_ps(x, m, 2);
            }
            else
            {
                return new double2(roundmultiple(x.x, m.x), roundmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 roundmultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_roundmult_ps(x, m);
            }
            else
            {
                return new double3(roundmultiple(x.xy, m.xy), roundmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 roundmultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_roundmult_ps(x, m);
            }
            else
            {
                return new double4(roundmultiple(x.xy, m.xy), roundmultiple(x.zw, m.zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple of <paramref name="m"/> &gt; 0, rounded towards the greater nearest multiple if the difference to both nearest multiples is equal.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple roundmultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * round(x / m);
        }
    }
}