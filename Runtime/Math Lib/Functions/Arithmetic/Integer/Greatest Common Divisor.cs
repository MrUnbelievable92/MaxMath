using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Burst;
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
            private static void PRELOOP_gcd_epu8(v128 a, v128 b, [NoAlias] out v128 tzcntA, [NoAlias] out v128 tzcntB, [NoAlias] out v128 doneMask, [NoAlias] out v128 result, [NoAlias] out v128 result_if_zero_any, bool promiseNonZero)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    tzcntA = tzcnt_epi8(a);
                    tzcntB = tzcnt_epi8(b);

                    result = ZERO;
                    doneMask = ZERO;
                    result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v128 a_is_zero = cmpeq_epi8(a, ZERO);
                        v128 b_is_zero = cmpeq_epi8(b, ZERO);

                        doneMask = or_si128(a_is_zero, b_is_zero);
                        result_if_zero_any = blendv_si128(and_si128(b, a_is_zero), a, b_is_zero);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_gcd_epu8([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 result, [NoAlias] ref v128 tzcntB, [NoAlias] ref v128 doneMask, [NoAlias] out v128 loopCheck, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    b = srlv_epi8(b, tzcntB, elements: elements);
                    loopCheck = cmpeq_epi8(a, b);

                    minmax_epu8(a, b, out a, out b);
                    b = sub_epi8(b, a);

                    result = blendv_si128(result, a, loopCheck);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool mm256_LOOP_gcd_epu8([NoAlias] ref v256 a, [NoAlias] ref v256 b, [NoAlias] ref v256 result, [NoAlias] ref v256 tzcntB, [NoAlias] ref v256 doneMask, [NoAlias] out v256 loopCheck)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    b = mm256_srlv_epi8(b, tzcntB);
                    loopCheck = Avx2.mm256_cmpeq_epi8(a, b);

                    mm256_minmax_epu8(a, b, out a, out b);
                    b = Avx2.mm256_sub_epi8(b, a);

                    result = mm256_blendv_si256(result, a, loopCheck);

                    if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                    {
                        return true;
                    }
                    else
                    {
                        tzcntB = mm256_tzcnt_epi8(b);
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);

                        return false;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool LOOP_gcd_epu8_epu32([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 result, [NoAlias] ref v128 tzcntB, [NoAlias] ref v128 doneMask, [NoAlias] out v128 loopCheck, byte elements = 16)
            {
                if (Avx2.IsAvx2Supported)
                {
                    b = srlv_epi32(b, tzcntB, elements: elements);
                    loopCheck = cmpeq_epi32(a, b);

                    minmax_epu32(a, b, out a, out b, elements: elements);
                    b = sub_epi32(b, a);

                    result = blendv_si128(result, a, loopCheck);

                    if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                    {
                        return true;
                    }
                    else
                    {
                        tzcntB = min_epu8(tzcnt_epi8(b), set1_epi32(8));
                        doneMask = or_si128(doneMask, loopCheck);

                        return false;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool mm256_LOOP_gcd_epu8_epu16([NoAlias] ref v256 a, [NoAlias] ref v256 b, [NoAlias] ref v256 result, [NoAlias] ref v256 tzcntB, [NoAlias] ref v256 doneMask, [NoAlias] out v256 loopCheck)
            {
                if (Avx2.IsAvx2Supported)
                {
                    b = mm256_srlv_epi16(b, tzcntB);
                    loopCheck = Avx2.mm256_cmpeq_epi16(a, b);

                    mm256_minmax_epu16(a, b, out a, out b);
                    b = Avx2.mm256_sub_epi16(b, a);

                    result = mm256_blendv_si256(result, a, loopCheck);

                    if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                    {
                        return true;
                    }
                    else
                    {
                        tzcntB = Avx2.mm256_min_epu8(mm256_tzcnt_epi8(b), mm256_set1_epi16(8));
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);

                        return false;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool mm256_LOOP_gcd_epu8_epu32([NoAlias] ref v256 a, [NoAlias] ref v256 b, [NoAlias] ref v256 result, [NoAlias] ref v256 tzcntB, [NoAlias] ref v256 doneMask, [NoAlias] out v256 loopCheck, byte elements = 16)
            {
                if (Avx2.IsAvx2Supported)
                {
                    b = Avx2.mm256_srlv_epi32(b, tzcntB);
                    loopCheck = Avx2.mm256_cmpeq_epi32(a, b);

                    mm256_minmax_epu32(a, b, out a, out b, elements);
                    b = Avx2.mm256_sub_epi32(b, a);

                    result = mm256_blendv_si256(result, a, loopCheck);

                    if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                    {
                        return true;
                    }
                    else
                    {
                        tzcntB = Avx2.mm256_min_epu8(mm256_tzcnt_epi8(b), mm256_set1_epi32(8));
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);

                        return false;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void POSTLOOP_gcd_epu8(ref v128 result, v128 shift, v128 result_if_zero_any, v128 checkZeroMask, bool promiseNonZero, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    result = sllv_epi8(result, shift, inRange: false, noOverflow: true, elements: elements);

                    if (!promiseNonZero)
                    {
                        result = blendv_si128(result, result_if_zero_any, checkZeroMask);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu8_x16_epu16(v128 a, v128 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU8(a, 0) && constexpr.ALL_GT_EPU8(b, 0);

                    PRELOOP_gcd_epu8(a, b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;
                    
                    v256 a16 = Avx2.mm256_cvtepu8_epi16(a);
                    v256 b16 = Avx2.mm256_cvtepu8_epi16(b);
                    v256 tzcntA16 = Avx2.mm256_cvtepu8_epi16(tzcntA);
                    v256 tzcntB16 = Avx2.mm256_cvtepu8_epi16(tzcntB);

                    v256 result16 = Avx2.mm256_cvtepu8_epi16(result);
                    v256 doneMask16 = Avx2.mm256_cvtepi8_epi16(doneMask);

                    v256 shift = Avx2.mm256_min_epu16(tzcntA16, tzcntB16);

                    a16 = mm256_srlv_epi16(a16, tzcntA16);

                    while (Hint.Likely(!mm256_LOOP_gcd_epu8_epu16(ref a16, ref b16, ref result16, ref tzcntB16, ref doneMask16, out _)))
                    {

                    }

                    result16 = mm256_sllv_epi16(result16, shift);

                    if (!promiseNonZero)
                    {
                        result16 = mm256_blendv_si256(result16, Avx2.mm256_cvtepu8_epi16(result_if_zero_any), Avx2.mm256_cvtepi8_epi16(checkZeroMask));
                    }

                    Assume.gcd(result16.UShort0,  a.Byte0,  b.Byte0);
                    Assume.gcd(result16.UShort1,  a.Byte1,  b.Byte1);
                    Assume.gcd(result16.UShort2,  a.Byte2,  b.Byte2);
                    Assume.gcd(result16.UShort3,  a.Byte3,  b.Byte3);
                    Assume.gcd(result16.UShort4,  a.Byte4,  b.Byte4);
                    Assume.gcd(result16.UShort5,  a.Byte5,  b.Byte5);
                    Assume.gcd(result16.UShort6,  a.Byte6,  b.Byte6);
                    Assume.gcd(result16.UShort7,  a.Byte7,  b.Byte7);
                    Assume.gcd(result16.UShort8,  a.Byte8,  b.Byte8);
                    Assume.gcd(result16.UShort9,  a.Byte9,  b.Byte9);
                    Assume.gcd(result16.UShort10, a.Byte10, b.Byte10);
                    Assume.gcd(result16.UShort11, a.Byte11, b.Byte11);
                    Assume.gcd(result16.UShort12, a.Byte12, b.Byte12);
                    Assume.gcd(result16.UShort13, a.Byte13, b.Byte13);
                    Assume.gcd(result16.UShort14, a.Byte14, b.Byte14);
                    Assume.gcd(result16.UShort15, a.Byte15, b.Byte15);

                    return result16;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu8_x8_epu32(v128 a, v128 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU8(a, 0, 8) && constexpr.ALL_GT_EPU8(b, 0, 8);

                    PRELOOP_gcd_epu8(a, b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;
                    
                    v256 a32 = Avx2.mm256_cvtepu8_epi32(a);
                    v256 b32 = Avx2.mm256_cvtepu8_epi32(b);
                    v256 tzcntA32 = Avx2.mm256_cvtepu8_epi32(tzcntA);
                    v256 tzcntB32 = Avx2.mm256_cvtepu8_epi32(tzcntB);
                    v256 result32 = Avx2.mm256_cvtepu8_epi32(result);
                    v256 doneMask32 = Avx2.mm256_cvtepi8_epi32(doneMask);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA32, tzcntB32);

                    a32 = Avx2.mm256_srlv_epi32(a32, tzcntA32);

                    while (Hint.Likely(!mm256_LOOP_gcd_epu8_epu32(ref a32, ref b32, ref result32, ref tzcntB32, ref doneMask32, out _, 32)))
                    {

                    }

                    result32 = Avx2.mm256_sllv_epi32(result32, shift);

                    if (!promiseNonZero)
                    {
                        result32 = mm256_blendv_si256(result32, Avx2.mm256_cvtepu8_epi32(result_if_zero_any), Avx2.mm256_cvtepi8_epi32(checkZeroMask));
                    }

                    Assume.gcd(result32.UInt0, a.Byte0, b.Byte0);
                    Assume.gcd(result32.UInt1, a.Byte1, b.Byte1);
                    Assume.gcd(result32.UInt2, a.Byte2, b.Byte2);
                    Assume.gcd(result32.UInt3, a.Byte3, b.Byte3);
                    Assume.gcd(result32.UInt4, a.Byte4, b.Byte4);
                    Assume.gcd(result32.UInt5, a.Byte5, b.Byte5);
                    Assume.gcd(result32.UInt6, a.Byte6, b.Byte6);
                    Assume.gcd(result32.UInt7, a.Byte7, b.Byte7);

                    return result32;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu8_x4_epu32(v128 a, v128 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU8(a, 0, elements) && constexpr.ALL_GT_EPU8(b, 0, elements);

                    PRELOOP_gcd_epu8(a, b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);
                    
                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;

                    doneMask = fillmissing_epi8(doneMask, elements);

                    v128 a32 = cvtepu8_epi32(a);
                    v128 b32 = cvtepu8_epi32(b);
                    v128 tzcntA32 = cvtepu8_epi32(tzcntA);
                    v128 tzcntB32 = cvtepu8_epi32(tzcntB);
                    v128 result32 = cvtepu8_epi32(result);
                    v128 doneMask32 = cvtepi8_epi32(doneMask);
                    v128 shift = min_epu8(tzcntA32, tzcntB32);

                    a32 = srlv_epi32(a32, tzcntA32);

                    while (Hint.Likely(!LOOP_gcd_epu8_epu32(ref a32, ref b32, ref result32, ref tzcntB32, ref doneMask32, out _, elements)))
                    {

                    }

                    result32 = sllv_epi32(result32, shift);

                    if (!promiseNonZero)
                    {
                        result32 = blendv_si128(result32, cvtepu8_epi32(result_if_zero_any), cvtepi8_epi32(checkZeroMask));
                    }

                    Assume.gcd(result32.UInt0, a.Byte0, b.Byte0);
                    Assume.gcd(result32.UInt1, a.Byte1, b.Byte1);
                    Assume.gcd(result32.UInt2, a.Byte2, b.Byte2);
                    Assume.gcd(result32.UInt3, a.Byte3, b.Byte3);

                    return result32;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu8(v128 a, v128 b, bool promiseNonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Avx2.IsAvx2Supported)
                    {
                        switch (elements)
                        {
                            case 16:
                            {
                                result = mm256_cvtepi16_epi8(mm256_gcd_epu8_x16_epu16(a, b, promiseNonZero));
                                break;
                            }
                            case 8:
                            {
                                result = mm256_cvtepi32_epi8(mm256_gcd_epu8_x8_epu32(a, b, promiseNonZero));
                                break;
                            }
                            default:
                            {
                                result = cvtepi32_epi8(gcd_epu8_x4_epu32(a, b, promiseNonZero, elements: elements));
                                break;
                            }
                        }
                    }
                    else
                    {
                        promiseNonZero |= constexpr.ALL_GT_EPU8(a, 0, elements) && constexpr.ALL_GT_EPU8(b, 0, elements);
                     
                        v128 __a = a;
                        v128 __b = b;
                        PRELOOP_gcd_epu8(__a, __b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out result, out v128 result_if_zero_any, promiseNonZero);
                        
                        // if promiseNonZero
                        v128 checkZeroMask = doneMask;

                        v128 shift = min_epu8(tzcntA, tzcntB);

                        if (Sse4_1.IsSse41Supported)
                        {
                            doneMask = fillmissing_epi8(doneMask, elements);
                        }

                        __a = srlv_epi8(__a, tzcntA, inRange: promiseNonZero, elements: elements);
                        
                        while (true)
                        {
                            LOOP_gcd_epu8(ref __a, ref __b, ref result, ref tzcntB, ref doneMask, out v128 loopCheck, elements);

                            if (Sse4_1.IsSse41Supported)
                            {
                                if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                                {
                                    break;
                                }
                                else
                                {
                                    tzcntB = tzcnt_epi8(__b);
                                    doneMask = or_si128(doneMask, loopCheck);
                                }
                            }
                            else
                            {
                                doneMask = or_si128(doneMask, loopCheck);

                                if (Hint.Unlikely(alltrue_epi128<byte>(doneMask, elements)))
                                {
                                    break;
                                }
                                else
                                {
                                    tzcntB = tzcnt_epi8(__b);
                                }
                            }
                        }

                        POSTLOOP_gcd_epu8(ref result, shift, result_if_zero_any, checkZeroMask, promiseNonZero, elements);
                    }
                        
                    Assume.gcd(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.gcd(result.Byte1,  a.Byte1,  b.Byte1);
                    Assume.gcd(result.Byte2,  a.Byte2,  b.Byte2);
                    Assume.gcd(result.Byte3,  a.Byte3,  b.Byte3);
                    Assume.gcd(result.Byte4,  a.Byte4,  b.Byte4);
                    Assume.gcd(result.Byte5,  a.Byte5,  b.Byte5);
                    Assume.gcd(result.Byte6,  a.Byte6,  b.Byte6);
                    Assume.gcd(result.Byte7,  a.Byte7,  b.Byte7);
                    Assume.gcd(result.Byte8,  a.Byte8,  b.Byte8);
                    Assume.gcd(result.Byte9,  a.Byte9,  b.Byte9);
                    Assume.gcd(result.Byte10, a.Byte10, b.Byte10);
                    Assume.gcd(result.Byte11, a.Byte11, b.Byte11);
                    Assume.gcd(result.Byte12, a.Byte12, b.Byte12);
                    Assume.gcd(result.Byte13, a.Byte13, b.Byte13);
                    Assume.gcd(result.Byte14, a.Byte14, b.Byte14);
                    Assume.gcd(result.Byte15, a.Byte15, b.Byte15);
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void gcd_epu8x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU8(a0, 0) && constexpr.ALL_GT_EPU8(b0, 0)
                                   && constexpr.ALL_GT_EPU8(a1, 0) && constexpr.ALL_GT_EPU8(b1, 0);

                    v128 __a0 = a0;
                    v128 __a1 = a1;
                    v128 __b0 = b0;
                    v128 __b1 = b1;

                    PRELOOP_gcd_epu8(__a0, __b0, out v128 tzcntA0, out v128 tzcntB0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu8(__a1, __b1, out v128 tzcntA1, out v128 tzcntB1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    v128 shift0 = min_epu8(tzcntA0, tzcntB0);
                    v128 shift1 = min_epu8(tzcntA1, tzcntB1);

                    __a0 = srlv_epi8(__a0, tzcntA0, inRange: promiseNonZero);
                    __a1 = srlv_epi8(__a1, tzcntA1, inRange: promiseNonZero);

                    while (true)
                    {
                        LOOP_gcd_epu8(ref __a0, ref __b0, ref r0, ref tzcntB0, ref doneMask0, out v128 loopCheck0, 16);
                        LOOP_gcd_epu8(ref __a1, ref __b1, ref r1, ref tzcntB1, ref doneMask1, out v128 loopCheck1, 16);

                        doneMask0 = or_si128(doneMask0, loopCheck0);
                        doneMask1 = or_si128(doneMask1, loopCheck1);

                        if (Hint.Unlikely(alltrue_epi128<byte>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB0 = tzcnt_epi8(__b0);
                            tzcntB1 = tzcnt_epi8(__b1);
                        }
                    }

                    POSTLOOP_gcd_epu8(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu8(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);
                        
                    Assume.gcd(r0.Byte0,  a1.Byte0,  b1.Byte0);
                    Assume.gcd(r0.Byte1,  a1.Byte1,  b1.Byte1);
                    Assume.gcd(r0.Byte2,  a1.Byte2,  b1.Byte2);
                    Assume.gcd(r0.Byte3,  a1.Byte3,  b1.Byte3);
                    Assume.gcd(r0.Byte4,  a1.Byte4,  b1.Byte4);
                    Assume.gcd(r0.Byte5,  a1.Byte5,  b1.Byte5);
                    Assume.gcd(r0.Byte6,  a1.Byte6,  b1.Byte6);
                    Assume.gcd(r0.Byte7,  a1.Byte7,  b1.Byte7);
                    Assume.gcd(r0.Byte8,  a1.Byte8,  b1.Byte8);
                    Assume.gcd(r0.Byte9,  a1.Byte9,  b1.Byte9);
                    Assume.gcd(r0.Byte10, a1.Byte10, b1.Byte10);
                    Assume.gcd(r0.Byte11, a1.Byte11, b1.Byte11);
                    Assume.gcd(r0.Byte12, a1.Byte12, b1.Byte12);
                    Assume.gcd(r0.Byte13, a1.Byte13, b1.Byte13);
                    Assume.gcd(r0.Byte14, a1.Byte14, b1.Byte14);
                    Assume.gcd(r0.Byte15, a1.Byte15, b1.Byte15);
                        
                    Assume.gcd(r1.Byte0,  a1.Byte0,  b1.Byte0);
                    Assume.gcd(r1.Byte1,  a1.Byte1,  b1.Byte1);
                    Assume.gcd(r1.Byte2,  a1.Byte2,  b1.Byte2);
                    Assume.gcd(r1.Byte3,  a1.Byte3,  b1.Byte3);
                    Assume.gcd(r1.Byte4,  a1.Byte4,  b1.Byte4);
                    Assume.gcd(r1.Byte5,  a1.Byte5,  b1.Byte5);
                    Assume.gcd(r1.Byte6,  a1.Byte6,  b1.Byte6);
                    Assume.gcd(r1.Byte7,  a1.Byte7,  b1.Byte7);
                    Assume.gcd(r1.Byte8,  a1.Byte8,  b1.Byte8);
                    Assume.gcd(r1.Byte9,  a1.Byte9,  b1.Byte9);
                    Assume.gcd(r1.Byte10, a1.Byte10, b1.Byte10);
                    Assume.gcd(r1.Byte11, a1.Byte11, b1.Byte11);
                    Assume.gcd(r1.Byte12, a1.Byte12, b1.Byte12);
                    Assume.gcd(r1.Byte13, a1.Byte13, b1.Byte13);
                    Assume.gcd(r1.Byte14, a1.Byte14, b1.Byte14);
                    Assume.gcd(r1.Byte15, a1.Byte15, b1.Byte15);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu8(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU8(a, 0) && constexpr.ALL_GT_EPU8(b, 0);

                    v256 __a = a;
                    v256 __b = b;

                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 tzcntA = mm256_tzcnt_epi8(__a);
                    v256 tzcntB = mm256_tzcnt_epi8(__b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 a_is_zero = Avx2.mm256_cmpeq_epi8(__a, ZERO);
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi8(__b, ZERO);

                        doneMask = Avx2.mm256_or_si256(a_is_zero, b_is_zero);
                        result_if_zero_any = mm256_blendv_si256(Avx2.mm256_and_si256(__b, a_is_zero), __a, b_is_zero);
                    }

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    __a = mm256_srlv_epi8(__a, tzcntA);

                    while (Hint.Likely(!mm256_LOOP_gcd_epu8(ref __a, ref __b, ref result, ref tzcntB, ref doneMask, out _)))
                    {

                    }

                    result = mm256_sllv_epi8(result, shift, noOverflow: true);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }

                    Assume.gcd(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.gcd(result.Byte1,  a.Byte1,  b.Byte1);
                    Assume.gcd(result.Byte2,  a.Byte2,  b.Byte2);
                    Assume.gcd(result.Byte3,  a.Byte3,  b.Byte3);
                    Assume.gcd(result.Byte4,  a.Byte4,  b.Byte4);
                    Assume.gcd(result.Byte5,  a.Byte5,  b.Byte5);
                    Assume.gcd(result.Byte6,  a.Byte6,  b.Byte6);
                    Assume.gcd(result.Byte7,  a.Byte7,  b.Byte7);
                    Assume.gcd(result.Byte8,  a.Byte8,  b.Byte8);
                    Assume.gcd(result.Byte9,  a.Byte9,  b.Byte9);
                    Assume.gcd(result.Byte10, a.Byte10, b.Byte10);
                    Assume.gcd(result.Byte11, a.Byte11, b.Byte11);
                    Assume.gcd(result.Byte12, a.Byte12, b.Byte12);
                    Assume.gcd(result.Byte13, a.Byte13, b.Byte13);
                    Assume.gcd(result.Byte14, a.Byte14, b.Byte14);
                    Assume.gcd(result.Byte15, a.Byte15, b.Byte15);
                    Assume.gcd(result.Byte16, a.Byte16, b.Byte16);
                    Assume.gcd(result.Byte17, a.Byte17, b.Byte17);
                    Assume.gcd(result.Byte18, a.Byte18, b.Byte18);
                    Assume.gcd(result.Byte19, a.Byte19, b.Byte19);
                    Assume.gcd(result.Byte20, a.Byte20, b.Byte20);
                    Assume.gcd(result.Byte21, a.Byte21, b.Byte21);
                    Assume.gcd(result.Byte22, a.Byte22, b.Byte22);
                    Assume.gcd(result.Byte23, a.Byte23, b.Byte23);
                    Assume.gcd(result.Byte24, a.Byte24, b.Byte24);
                    Assume.gcd(result.Byte25, a.Byte25, b.Byte25);
                    Assume.gcd(result.Byte26, a.Byte26, b.Byte26);
                    Assume.gcd(result.Byte27, a.Byte27, b.Byte27);
                    Assume.gcd(result.Byte28, a.Byte28, b.Byte28);
                    Assume.gcd(result.Byte29, a.Byte29, b.Byte29);
                    Assume.gcd(result.Byte30, a.Byte30, b.Byte30);
                    Assume.gcd(result.Byte31, a.Byte31, b.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_gcd_epu16(v128 a, v128 b, [NoAlias] out v128 tzcntA, [NoAlias] out v128 tzcntB, [NoAlias] out v128 doneMask, [NoAlias] out v128 result, [NoAlias] out v128 result_if_zero_any, bool promiseNonZero)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    tzcntA = tzcnt_epi16(a);
                    tzcntB = tzcnt_epi16(b);

                    result = ZERO;
                    doneMask = ZERO;
                    result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v128 a_is_zero = cmpeq_epi16(a, ZERO);
                        v128 b_is_zero = cmpeq_epi16(b, ZERO);

                        doneMask = or_si128(a_is_zero, b_is_zero);
                        result_if_zero_any = blendv_si128(and_si128(b, a_is_zero), a, b_is_zero);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_gcd_epu16([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 result, [NoAlias] out v128 loopCheck, v128 tzcntB, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    b = srlv_epi16(b, tzcntB, elements: elements);
                    loopCheck = cmpeq_epi16(a, b);

                    minmax_epu16(a, b, out a, out b);
                    b = sub_epi16(b, a);

                    result = blendv_si128(result, a, loopCheck);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static bool mm256_LOOP_gcd_epu16_epu32([NoAlias] ref v256 a, [NoAlias] ref v256 b, [NoAlias] ref v256 result, [NoAlias] ref v256 tzcntB, [NoAlias] ref v256 doneMask, [NoAlias] out v256 loopCheck)
            {
                if (Avx2.IsAvx2Supported)
                {
                    b = Avx2.mm256_srlv_epi32(b, tzcntB);
                    loopCheck = Avx2.mm256_cmpeq_epi32(a, b);

                    mm256_minmax_epu32(a, b, out a, out b);
                    b = Avx2.mm256_sub_epi32(b, a);

                    result = mm256_blendv_si256(result, a, loopCheck);

                    if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                    {
                        return true;
                    }
                    else
                    {
                        tzcntB = Avx2.mm256_min_epu16(mm256_tzcnt_epi16(b), mm256_set1_epi32(16));
                        doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);

                        return false;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void POSTLOOP_gcd_epu16(ref v128 result, v128 shift, v128 result_if_zero_any, v128 checkZeroMask, bool promiseNonZero, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    result = sllv_epi16(result, shift, inRange: false, elements: elements);

                    if (!promiseNonZero)
                    {
                        result = blendv_si128(result, result_if_zero_any, checkZeroMask);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu16_x8_epu32(v128 a, v128 b, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU16(a, 0) && constexpr.ALL_GT_EPU16(b, 0);

                    PRELOOP_gcd_epu16(a, b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;
                    
                    v256 a32 = Avx2.mm256_cvtepu16_epi32(a);
                    v256 b32 = Avx2.mm256_cvtepu16_epi32(b);
                    v256 tzcntA32 = Avx2.mm256_cvtepu16_epi32(tzcntA);
                    v256 tzcntB32 = Avx2.mm256_cvtepu16_epi32(tzcntB);
                    v256 result32 = Avx2.mm256_cvtepu16_epi32(result);
                    v256 doneMask32 = Avx2.mm256_cvtepi16_epi32(doneMask);
                    v256 shift = Avx2.mm256_min_epu32(tzcntA32, tzcntB32);

                    a32 = Avx2.mm256_srlv_epi32(a32, tzcntA32);

                    while (Hint.Likely(!mm256_LOOP_gcd_epu16_epu32(ref a32, ref b32, ref result32, ref tzcntB32, ref doneMask32, out _)))
                    {

                    }

                    result32 = Avx2.mm256_sllv_epi32(result32, shift);

                    if (!promiseNonZero)
                    {
                        result32 = mm256_blendv_si256(result32, Avx2.mm256_cvtepu16_epi32(result_if_zero_any), Avx2.mm256_cvtepi16_epi32(checkZeroMask));
                    }

                    Assume.gcd(result32.UInt0, a.UShort0, b.UShort0);
                    Assume.gcd(result32.UInt1, a.UShort1, b.UShort1);
                    Assume.gcd(result32.UInt2, a.UShort2, b.UShort2);
                    Assume.gcd(result32.UInt3, a.UShort3, b.UShort3);
                    Assume.gcd(result32.UInt4, a.UShort4, b.UShort4);
                    Assume.gcd(result32.UInt5, a.UShort5, b.UShort5);
                    Assume.gcd(result32.UInt6, a.UShort6, b.UShort6);
                    Assume.gcd(result32.UInt7, a.UShort7, b.UShort7);

                    return result32;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu16_x4_epu32(v128 a, v128 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU16(a, 0, elements) && constexpr.ALL_GT_EPU16(b, 0, elements);

                    PRELOOP_gcd_epu16(a, b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;
                    
                    doneMask = fillmissing_epi16(doneMask, elements);

                    v128 a32 = cvtepu16_epi32(a);
                    v128 b32 = cvtepu16_epi32(b);
                    v128 tzcntA32 = cvtepu16_epi32(tzcntA);
                    v128 tzcntB32 = cvtepu16_epi32(tzcntB);
                    v128 result32 = cvtepu16_epi32(result);
                    v128 doneMask32 = cvtepi16_epi32(doneMask);
                    v128 shift = min_epu8(tzcntA32, tzcntB32);

                    a32 = srlv_epi32(a32, tzcntA32);

                    while (true)
                    {
                        b32 = srlv_epi32(b32, tzcntB32);
                        v128 loopCheck = cmpeq_epi32(a32, b32);

                        minmax_epu32(a32, b32, out a32, out b32);
                        b32 = sub_epi32(b32, a32);

                        result32 = blendv_si128(result32, a32, loopCheck);

                        if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask32)) == 1))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB32 = min_epu16(tzcnt_epi16(b32), set1_epi32(16));
                            doneMask32 = or_si128(doneMask32, loopCheck);
                        }
                    }

                    result32 = sllv_epi32(result32, shift);

                    if (!promiseNonZero)
                    {
                        result32 = blendv_si128(result32, cvtepu16_epi32(result_if_zero_any), cvtepi16_epi32(checkZeroMask));
                    }

                    Assume.gcd(result32.UInt0, a.UShort0, b.UShort0);
                    Assume.gcd(result32.UInt1, a.UShort1, b.UShort1);
                    Assume.gcd(result32.UInt2, a.UShort2, b.UShort2);
                    Assume.gcd(result32.UInt3, a.UShort3, b.UShort3);

                    return result32;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu16(v128 a, v128 b, bool promiseNonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU16(a, 0, elements) && constexpr.ALL_GT_EPU16(b, 0, elements);

                    PRELOOP_gcd_epu16(a, b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;

                    if (Avx2.IsAvx2Supported)
                    {
                        switch (elements)
                        {
                            case 8:
                            {
                                result = mm256_cvtepi32_epi16(mm256_gcd_epu16_x8_epu32(a, b, promiseNonZero));
                                break;
                            }
                            default:
                            {
                                result = cvtepi32_epi16(gcd_epu16_x4_epu32(a, b, promiseNonZero, elements));
                                break;
                            }
                        }
                    }
                    else
                    {
                        v128 __a = a;
                        v128 __b = b;

                        v128 shift = min_epu8(tzcntA, tzcntB);

                        if (Sse4_1.IsSse41Supported)
                        {
                            doneMask = fillmissing_epi16(doneMask, elements);
                        }

                        __a = srlv_epi16(__a, tzcntA, inRange: promiseNonZero, elements: elements);

                        while (true)
                        {
                            LOOP_gcd_epu16(ref __a, ref __b, ref result, out v128 loopCheck, tzcntB, elements);

                            if (Sse4_1.IsSse41Supported)
                            {
                                if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                                {
                                    break;
                                }
                                else
                                {
                                    tzcntB = tzcnt_epi16(__b);
                                    doneMask = or_si128(doneMask, loopCheck);
                                }
                            }
                            else
                            {
                                doneMask = or_si128(doneMask, loopCheck);

                                if (Hint.Unlikely(alltrue_epi128<short>(doneMask, elements)))
                                {
                                    break;
                                }
                                else
                                {
                                    tzcntB = tzcnt_epi16(__b);
                                }
                            }
                        }

                        POSTLOOP_gcd_epu16(ref result, shift, result_if_zero_any, checkZeroMask, promiseNonZero, elements);
                    }

                    Assume.gcd(result.UShort0, a.UShort0, b.UShort0);
                    Assume.gcd(result.UShort1, a.UShort1, b.UShort1);
                    Assume.gcd(result.UShort2, a.UShort2, b.UShort2);
                    Assume.gcd(result.UShort3, a.UShort3, b.UShort3);
                    Assume.gcd(result.UShort4, a.UShort4, b.UShort4);
                    Assume.gcd(result.UShort5, a.UShort5, b.UShort5);
                    Assume.gcd(result.UShort6, a.UShort6, b.UShort6);
                    Assume.gcd(result.UShort7, a.UShort7, b.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void gcd_epu16x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU16(a0, 0) && constexpr.ALL_GT_EPU16(b0, 0)
                                   && constexpr.ALL_GT_EPU16(a1, 0) && constexpr.ALL_GT_EPU16(b1, 0);

                    v128 __a0 = a0;
                    v128 __a1 = a1;
                    v128 __b0 = b0;
                    v128 __b1 = b1;

                    PRELOOP_gcd_epu16(__a0, __b0, out v128 tzcntA0, out v128 tzcntB0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu16(__a1, __b1, out v128 tzcntA1, out v128 tzcntB1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    v128 shift0 = min_epu16(tzcntA0, tzcntB0);
                    v128 shift1 = min_epu16(tzcntA1, tzcntB1);

                    __a0 = srlv_epi16(__a0, tzcntA0, inRange: promiseNonZero);
                    __a1 = srlv_epi16(__a1, tzcntA1, inRange: promiseNonZero);

                    while (true)
                    {
                        LOOP_gcd_epu16(ref __a0, ref __b0, ref r0, out v128 loopCheck0, tzcntB0);
                        LOOP_gcd_epu16(ref __a1, ref __b1, ref r1, out v128 loopCheck1, tzcntB1);

                        doneMask0 = or_si128(doneMask0, loopCheck0);
                        doneMask1 = or_si128(doneMask1, loopCheck1);

                        if (Hint.Unlikely(alltrue_epi128<short>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB0 = tzcnt_epi16(__b0);
                            tzcntB1 = tzcnt_epi16(__b1);
                        }
                    }

                    POSTLOOP_gcd_epu16(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu16(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);

                    Assume.gcd(r0.UShort0, a0.UShort0, b0.UShort0);
                    Assume.gcd(r0.UShort1, a0.UShort1, b0.UShort1);
                    Assume.gcd(r0.UShort2, a0.UShort2, b0.UShort2);
                    Assume.gcd(r0.UShort3, a0.UShort3, b0.UShort3);
                    Assume.gcd(r0.UShort4, a0.UShort4, b0.UShort4);
                    Assume.gcd(r0.UShort5, a0.UShort5, b0.UShort5);
                    Assume.gcd(r0.UShort6, a0.UShort6, b0.UShort6);
                    Assume.gcd(r0.UShort7, a0.UShort7, b0.UShort7);

                    Assume.gcd(r1.UShort0, a1.UShort0, b1.UShort0);
                    Assume.gcd(r1.UShort1, a1.UShort1, b1.UShort1);
                    Assume.gcd(r1.UShort2, a1.UShort2, b1.UShort2);
                    Assume.gcd(r1.UShort3, a1.UShort3, b1.UShort3);
                    Assume.gcd(r1.UShort4, a1.UShort4, b1.UShort4);
                    Assume.gcd(r1.UShort5, a1.UShort5, b1.UShort5);
                    Assume.gcd(r1.UShort6, a1.UShort6, b1.UShort6);
                    Assume.gcd(r1.UShort7, a1.UShort7, b1.UShort7);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu16(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU16(a, 0) && constexpr.ALL_GT_EPU16(b, 0);

                    v256 __a = a;
                    v256 __b = b;

                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 tzcntA = mm256_tzcnt_epi16(__a);
                    v256 tzcntB = mm256_tzcnt_epi16(__b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 a_is_zero = Avx2.mm256_cmpeq_epi16(__a, ZERO);
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi16(__b, ZERO);

                        doneMask = Avx2.mm256_or_si256(a_is_zero, b_is_zero);
                        result_if_zero_any = mm256_blendv_si256(Avx2.mm256_and_si256(__b, a_is_zero), __a, b_is_zero);
                    }

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    __a = mm256_srlv_epi16(__a, tzcntA);

                    while (true)
                    {
                        __b = mm256_srlv_epi16(__b, tzcntB);
                        v256 loopCheck = Avx2.mm256_cmpeq_epi16(__a, __b);

                        mm256_minmax_epu16(__a, __b, out __a, out __b);
                        __b = Avx2.mm256_sub_epi16(__b, __a);

                        result = mm256_blendv_si256(result, __a, loopCheck);

                        if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi16(__b);
                            doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        }
                    }

                    result = mm256_sllv_epi16(result, shift);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }

                    Assume.gcd(result.UShort0,  a.UShort0,  b.UShort0);
                    Assume.gcd(result.UShort1,  a.UShort1,  b.UShort1);
                    Assume.gcd(result.UShort2,  a.UShort2,  b.UShort2);
                    Assume.gcd(result.UShort3,  a.UShort3,  b.UShort3);
                    Assume.gcd(result.UShort4,  a.UShort4,  b.UShort4);
                    Assume.gcd(result.UShort5,  a.UShort5,  b.UShort5);
                    Assume.gcd(result.UShort6,  a.UShort6,  b.UShort6);
                    Assume.gcd(result.UShort7,  a.UShort7,  b.UShort7);
                    Assume.gcd(result.UShort8,  a.UShort8,  b.UShort8);
                    Assume.gcd(result.UShort9,  a.UShort9,  b.UShort9);
                    Assume.gcd(result.UShort10, a.UShort10, b.UShort10);
                    Assume.gcd(result.UShort11, a.UShort11, b.UShort11);
                    Assume.gcd(result.UShort12, a.UShort12, b.UShort12);
                    Assume.gcd(result.UShort13, a.UShort13, b.UShort13);
                    Assume.gcd(result.UShort14, a.UShort14, b.UShort14);
                    Assume.gcd(result.UShort15, a.UShort15, b.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_gcd_epu32([NoAlias] ref v128 a, v128 b, [NoAlias] out v128 tzcntB, [NoAlias] out v128 shift, [NoAlias] out v128 doneMask, [NoAlias] out v128 result, [NoAlias] out v128 result_if_zero_any, bool promiseNonZero, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    v128 tzcntA = tzcnt_epi32(a, elements);
                         tzcntB = tzcnt_epi32(b, elements);
                         shift = min_epu8(tzcntA, tzcntB);

                    result = ZERO;
                    doneMask = ZERO;
                    result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v128 a_is_zero = cmpeq_epi32(a, ZERO);
                        v128 b_is_zero = cmpeq_epi32(b, ZERO);

                        doneMask = or_si128(a_is_zero, b_is_zero);
                        result_if_zero_any = blendv_si128(and_si128(b, a_is_zero), a, b_is_zero);
                    }

                    a = srlv_epi32(a, tzcntA, inRange: promiseNonZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_gcd_epu32([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 result, [NoAlias] out v128 loopCheck, v128 tzcntB, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    b = srlv_epi32(b, tzcntB, elements: elements);
                    loopCheck = cmpeq_epi32(a, b);

                    if (BurstArchitecture.IsMinMaxSupported)
                    {
                        minmax_epu32(a, b, out a, out b);
                    }
                    else
                    {
                        xchg_si128(ref a, ref b, cmpgt_epu32(a, b));
                    }

                    b = sub_epi32(b, a);
                    result = blendv_si128(result, a, loopCheck);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void POSTLOOP_gcd_epu32(ref v128 result, v128 shift, v128 result_if_zero_any, v128 checkZeroMask, bool promiseNonZero, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    result = sllv_epi32(result, shift, inRange: false, elements);

                    if (!promiseNonZero)
                    {
                        result = blendv_si128(result, result_if_zero_any, checkZeroMask);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu32(v128 a, v128 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU32(a, 0, elements) && constexpr.ALL_GT_EPU32(b, 0, elements);

                    v128 __a = a;
                    v128 __b = b;

                    PRELOOP_gcd_epu32(ref __a, __b, out v128 tzcntB, out v128 shift, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero, elements);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;

                    if (Sse4_1.IsSse41Supported)
                    {
                        doneMask = fillmissing_epi32(doneMask, elements);
                    }

                    while (true)
                    {
                        LOOP_gcd_epu32(ref __a, ref __b, ref result, out v128 loopCheck, tzcntB, elements);

                        if (Sse4_1.IsSse41Supported)
                        {
                            if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                            {
                                break;
                            }
                            else
                            {
                                tzcntB = tzcnt_epi32(__b, elements);
                                doneMask = or_si128(doneMask, loopCheck);
                            }
                        }
                        else
                        {
                            doneMask = or_si128(doneMask, loopCheck);

                            if (Hint.Unlikely(alltrue_epi128<uint>(doneMask, elements)))
                            {
                                break;
                            }
                            else
                            {
                                tzcntB = tzcnt_epi32(__b, elements);
                            }
                        }
                    }

                    POSTLOOP_gcd_epu32(ref result, shift, result_if_zero_any, checkZeroMask, promiseNonZero, elements);

                    Assume.gcd(result.UInt0, a.UInt0, b.UInt0);
                    Assume.gcd(result.UInt1, a.UInt1, b.UInt1);
                    Assume.gcd(result.UInt2, a.UInt2, b.UInt2);
                    Assume.gcd(result.UInt3, a.UInt3, b.UInt3);

                    return result;
                }


                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void gcd_epu32x2(v128 a0, v128 a1, v128 b0,v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU32(a0, 0) && constexpr.ALL_GT_EPU32(b0, 0)
                                   && constexpr.ALL_GT_EPU32(a1, 0) && constexpr.ALL_GT_EPU32(b1, 0);

                    v128 __a0 = a0;
                    v128 __a1 = a1;
                    v128 __b0 = b0;
                    v128 __b1 = b1;

                    PRELOOP_gcd_epu32(ref __a0, __b0, out v128 tzcntB0, out v128 shift0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu32(ref __a1, __b1, out v128 tzcntB1, out v128 shift1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    while (true)
                    {
                        LOOP_gcd_epu32(ref __a0, ref __b0, ref r0, out v128 loopCheck0, tzcntB0);
                        LOOP_gcd_epu32(ref __a1, ref __b1, ref r1, out v128 loopCheck1, tzcntB1);

                        doneMask0 = or_si128(doneMask0, loopCheck0);
                        doneMask1 = or_si128(doneMask1, loopCheck1);

                        if (Hint.Unlikely(alltrue_epi128<int>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB0 = tzcnt_epi32(__b0);
                            tzcntB1 = tzcnt_epi32(__b1);
                        }
                    }

                    POSTLOOP_gcd_epu32(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu32(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);

                    Assume.gcd(r0.UInt0, a0.UInt0, b0.UInt0);
                    Assume.gcd(r0.UInt1, a0.UInt1, b0.UInt1);
                    Assume.gcd(r0.UInt2, a0.UInt2, b0.UInt2);
                    Assume.gcd(r0.UInt3, a0.UInt3, b0.UInt3);

                    Assume.gcd(r1.UInt0, a1.UInt0, b1.UInt0);
                    Assume.gcd(r1.UInt1, a1.UInt1, b1.UInt1);
                    Assume.gcd(r1.UInt2, a1.UInt2, b1.UInt2);
                    Assume.gcd(r1.UInt3, a1.UInt3, b1.UInt3);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu32(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU32(a, 0) && constexpr.ALL_GT_EPU32(b, 0);

                    v256 __a = a;
                    v256 __b = b;

                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 tzcntA = mm256_tzcnt_epi32(__a);
                    v256 tzcntB = mm256_tzcnt_epi32(__b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 a_is_zero = Avx2.mm256_cmpeq_epi32(__a, ZERO);
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi32(__b, ZERO);

                        doneMask = Avx2.mm256_or_si256(a_is_zero, b_is_zero);
                        result_if_zero_any = mm256_blendv_si256(Avx2.mm256_and_si256(__b, a_is_zero), __a, b_is_zero);
                    }

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    __a = Avx2.mm256_srlv_epi32(__a, tzcntA);

                    while (true)
                    {
                        __b = Avx2.mm256_srlv_epi32(__b, tzcntB);
                        v256 loopCheck = Avx2.mm256_cmpeq_epi32(__a, __b);

                        mm256_minmax_epu32(__a, __b, out __a, out __b);
                        __b = Avx2.mm256_sub_epi32(__b, __a);

                        result = mm256_blendv_si256(result, __a, loopCheck);

                        if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi32(__b);
                            doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        }
                    }

                    result = Avx2.mm256_sllv_epi32(result, shift);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }

                    Assume.gcd(result.UInt0, a.UInt0, b.UInt0);
                    Assume.gcd(result.UInt1, a.UInt1, b.UInt1);
                    Assume.gcd(result.UInt2, a.UInt2, b.UInt2);
                    Assume.gcd(result.UInt3, a.UInt3, b.UInt3);
                    Assume.gcd(result.UInt4, a.UInt4, b.UInt4);
                    Assume.gcd(result.UInt5, a.UInt5, b.UInt5);
                    Assume.gcd(result.UInt6, a.UInt6, b.UInt6);
                    Assume.gcd(result.UInt7, a.UInt7, b.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_gcd_epu64([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] out v128 shift, [NoAlias] out v128 doneMask, [NoAlias] out v128 result, [NoAlias] out v128 result_if_zero_any, bool promiseNonZero)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    minmax_epu64(a, b, out a, out b);
                    //}
                    //else
                    //{
                          xchg_si128(ref a, ref b, cmpgt_epu64(a, b));
                    //}
                    
                    result = ZERO;
                    doneMask = ZERO;
                    result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v128 b_is_zero = cmpeq_epi64(b, ZERO);

                        doneMask = b_is_zero;
                        result_if_zero_any = blendv_si128(result_if_zero_any, a, b_is_zero);
                    }

                #if DEBUG
                    b = blendv_si128(b, set1_epi64x(1), cmpeq_epi64(b, setzero_si128()));
                #endif

                    a = rem_epu64(a, b, useFPU: true);
                    v128 a_is_zero = cmpeq_epi64(a, ZERO);
                    if (promiseNonZero)
                    {
                        doneMask = a_is_zero;
                    }
                    else
                    {
                        doneMask = or_si128(doneMask, a_is_zero);
                    }
                        
                    result_if_zero_any = blendv_si128(result_if_zero_any, b, a_is_zero);

                    v128 tzcntA = tzcnt_epi64(a);
                    v128 tzcntB = tzcnt_epi64(b);
                    shift = min_epu8(tzcntA, tzcntB);

                    a = srlv_epi64(a, tzcntA);
                    b = srlv_epi64(b, tzcntB);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_gcd_epu64([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 result, [NoAlias] out v128 loopCheck, [NoAlias] out v128 aSubB)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    aSubB = sub_epi64(a, b);
                    v128 aGTb = cmpgt_epu64(a, b);
                    
                    v128 t = b;
                    b = blendv_si128(sub_epi64(b, a), aSubB, aGTb);
                    a = blendv_si128(a, t, aGTb);
                    loopCheck = cmpeq_epi64(andnot_si128(tzmsk_epi64(aSubB), b), setzero_si128());
                    
                    result = blendv_si128(result, a, loopCheck);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void POSTLOOP_gcd_epu64(ref v128 result, v128 shift, v128 result_if_zero_any, v128 checkZeroMask, bool promiseNonZero)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    result = sllv_epi64(result, shift, inRange: false);

                    if (!promiseNonZero)
                    {
                        result = blendv_si128(result, result_if_zero_any, checkZeroMask);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 gcd_epu64(v128 a, v128 b, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU64(a, 0) && constexpr.ALL_GT_EPU64(b, 0);

                    v128 __a = a;
                    v128 __b = b;

                    PRELOOP_gcd_epu64(ref __a, ref __b, out v128 shift, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;

                    while (true)
                    {
                        LOOP_gcd_epu64(ref __a, ref __b, ref result, out v128 loopCheck, out v128 aSubB);

                        if (Sse4_1.IsSse41Supported)
                        {
                            if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                            {
                                break;
                            }
                            else
                            {
                                __b = srlv_epi64(__b, tzcnt_epi64(aSubB));
                                doneMask = or_si128(doneMask, loopCheck);
                            }
                        }
                        else
                        {
                            doneMask = or_si128(doneMask, loopCheck);

                            if (Hint.Unlikely(alltrue_epi128<long>(doneMask)))
                            {
                                break;
                            }
                            else
                            {
                                __b = srlv_epi64(__b, tzcnt_epi64(aSubB));
                            }
                        }
                    }

                    POSTLOOP_gcd_epu64(ref result, shift, result_if_zero_any, checkZeroMask, promiseNonZero);

                    Assume.gcd(result.ULong0, a.ULong0, b.ULong0);
                    Assume.gcd(result.ULong1, a.ULong1, b.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void gcd_epu64x2(v128 a0, v128 a1, v128 b0,v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU64(a0, 0) && constexpr.ALL_GT_EPU64(b0, 0)
                                   && constexpr.ALL_GT_EPU64(a1, 0) && constexpr.ALL_GT_EPU64(b1, 0);

                    v128 __a0 = a0;
                    v128 __a1 = a1;
                    v128 __b0 = b0;
                    v128 __b1 = b1;

                    PRELOOP_gcd_epu64(ref __a0, ref __b0, out v128 shift0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu64(ref __a1, ref __b1, out v128 shift1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    while (true)
                    {
                        LOOP_gcd_epu64(ref __a0, ref __b0, ref r0, out v128 loopCheck0, out v128 aSubB0);
                        LOOP_gcd_epu64(ref __a1, ref __b1, ref r1, out v128 loopCheck1, out v128 aSubB1);

                        doneMask0 = or_si128(doneMask0, loopCheck0);
                        doneMask1 = or_si128(doneMask1, loopCheck1);
                        
                        if (Hint.Unlikely(alltrue_epi128<long>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                        else
                        {
                            __b0 = srlv_epi64(__b0, tzcnt_epi64(aSubB0));
                            __b1 = srlv_epi64(__b1, tzcnt_epi64(aSubB1));
                        }
                    }

                    POSTLOOP_gcd_epu64(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu64(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);

                    Assume.gcd(r0.ULong0, a0.ULong0, b0.ULong0);
                    Assume.gcd(r0.ULong1, a0.ULong1, b0.ULong1);

                    Assume.gcd(r1.ULong0, a1.ULong0, b1.ULong0);
                    Assume.gcd(r1.ULong1, a1.ULong1, b1.ULong1);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu64(v256 a, v256 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU64(a, 0, elements) && constexpr.ALL_GT_EPU64(b, 0, elements);

                    v256 __a = a;
                    v256 __b = b;

                    v256 ZERO = Avx.mm256_setzero_si256();
                    
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    mm256_minmax_epu64(a, b, out a, out b);
                    //}
                    //else
                    //{
                          mm256_xchg_si256(ref __a, ref __b, mm256_cmpgt_epu64(__a, __b));
                    //}
                    
                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi64(__b, ZERO);

                        doneMask = b_is_zero;
                        result_if_zero_any = mm256_blendv_si256(result_if_zero_any, __a, b_is_zero);
                    }

                #if DEBUG
                    __b = mm256_blendv_si256(__b, mm256_set1_epi64x(1), Avx2.mm256_cmpeq_epi64(__b, Avx.mm256_setzero_si256()));
                #endif

                    __a = mm256_rem_epu64(__a, __b, elements: elements);
                    v256 a_is_zero = Avx2.mm256_cmpeq_epi64(__a, ZERO);
                    if (promiseNonZero)
                    {
                        doneMask = a_is_zero;
                    }
                    else
                    {
                        doneMask = Avx2.mm256_or_si256(doneMask, a_is_zero);
                    }
                        
                    result_if_zero_any = mm256_blendv_si256(result_if_zero_any, __b, a_is_zero);

                    v256 tzcntA = mm256_tzcnt_epi64(__a);
                    v256 tzcntB = mm256_tzcnt_epi64(__b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    __a = Avx2.mm256_srlv_epi64(__a, tzcntA);
                    __b = Avx2.mm256_srlv_epi64(__b, tzcntB);

                    doneMask = mm256_fillmissing_epi64(doneMask, elements);

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    while (true)
                    {
                        v256 aSubB = Avx2.mm256_sub_epi64(__a, __b);
                        v256 aGTb = mm256_cmpgt_epu64(__a, __b, elements);
                        
                        v256 t = __b;
                        __b = mm256_blendv_si256(Avx2.mm256_sub_epi64(__b, __a), aSubB, aGTb);
                        __a = mm256_blendv_si256(__a, t, aGTb);
                        v256 loopCheck = Avx2.mm256_cmpeq_epi64(Avx2.mm256_andnot_si256(mm256_tzmsk_epi64(aSubB), __b), ZERO);
                        
                        result = mm256_blendv_si256(result, __a, loopCheck);
                        
                        if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                        {
                            break;
                        }
                        else
                        {
                            __b = Avx2.mm256_srlv_epi64(__b, mm256_tzcnt_epi64(aSubB));
                            doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        }
                    }

                    result = Avx2.mm256_sllv_epi64(result, shift);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }

                    Assume.gcd(result.ULong0, a.ULong0, b.ULong0);
                    Assume.gcd(result.ULong1, a.ULong1, b.ULong1);
                    Assume.gcd(result.ULong2, a.ULong2, b.ULong2);
                    Assume.gcd(result.ULong3, a.ULong3, b.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }
    

    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void gcd(byte result, byte a, byte b)
        {
            if (constexpr.IS_TRUE(a != 0 && b != 0))
            {
                constexpr.ASSUME(a % result == 0);
                constexpr.ASSUME(b % result == 0);
                constexpr.ASSUME(result <= a);
                constexpr.ASSUME(result <= b);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void gcd(ushort result, ushort a, ushort b)
        {
            if (constexpr.IS_TRUE(a != 0 && b != 0))
            {
                constexpr.ASSUME(a % result == 0);
                constexpr.ASSUME(b % result == 0);
                constexpr.ASSUME(result <= a);
                constexpr.ASSUME(result <= b);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void gcd(uint result, uint a, uint b)
        {
            if (constexpr.IS_TRUE(a != 0 && b != 0))
            {
                constexpr.ASSUME(a % result == 0);
                constexpr.ASSUME(b % result == 0);
                constexpr.ASSUME(result <= a);
                constexpr.ASSUME(result <= b);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void gcd(ulong result, ulong a, ulong b)
        {
            if (constexpr.IS_TRUE(a != 0 && b != 0))
            {
                constexpr.ASSUME(a % result == 0);
                constexpr.ASSUME(b % result == 0);
                constexpr.ASSUME(result <= a);
                constexpr.ASSUME(result <= b);
            }
        }
    }


    unsafe public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LOOP_gcd_u128([NoAlias] ref UInt128 x, [NoAlias] ref UInt128 y)
        {
            UInt128 xSubY = x - y;
            if (x > y) 
            { 
                x = y; 
                y = xSubY; 
            }
            else 
            {
                y -= x; 
            }
            y >>= tzcnt(xSubY);

            return y == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LOOP_gcd_u64([NoAlias] ref ulong x, [NoAlias] ref ulong y)
        {
            ulong xSubY = x - y;
            if (x > y) 
            { 
                x = y; 
                y = xSubY; 
            }
            else 
            {
                y -= x; 
            }
            y >>= tzcnt(xSubY);

            return y == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LOOP_gcd_u32([NoAlias] ref uint x, [NoAlias] ref uint y)
        {
            uint xSubY = x - y;
            if (x > y) 
            { 
                x = y; 
                y = xSubY; 
            }
            else 
            {
                y -= x; 
            }
            y >>= tzcnt(xSubY);

            return y == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LOOP_gcd_u8([NoAlias] ref byte x, [NoAlias] ref byte y)
        {
            byte t = (byte)(y >> tzcnt(y));
            if (x > t) 
            { 
                y = (byte)(x - t); 
                x = t; 
            }
            else 
            {
                y = (byte)(t - x);
            }

            return y == 0;
        }

        /// <summary>       Returns the greatest common divisor of two <see cref="UInt128"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 gcd(UInt128 x, UInt128 y, Promise nonZero = Promise.Nothing)
        {
            UInt128 result;

            minmax(x, y, out x, out y);

            if (!(nonZero.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0 && y != 0)))
            {
                if (Hint.Unlikely(y.IsZero))
                {
                    result = x; goto RET;
                }
            }
            
            x %= y;
            if (x == 0) 
            { 
                result = y; goto RET;
            }
            int zu = tzcnt(x);
            int zv = tzcnt(y);
            int shift = min(zu, zv);
            x >>= zu;
            y >>= zv;

            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
            
                result = x << shift; goto RET;
            }
            else
            {
                while (Hint.Likely(!LOOP_gcd_u128(ref x, ref y)))
                {
            
                }
            
                result = x << shift; goto RET;
            }

        RET:
            
            if (constexpr.IS_TRUE(x != 0 && y != 0))
            {
                //constexpr.ASSUME(x % result == 0);
                //constexpr.ASSUME(y % result == 0);
                constexpr.ASSUME(result <= x);
                constexpr.ASSUME(result <= y);
            }

            return result;
        }

        /// <summary>       Returns the greatest common divisor of two <see cref="Int128"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 gcd(Int128 x, Int128 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((UInt128)abs(x), (UInt128)abs(y), nonZero);
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="long"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong gcd(long x, long y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(x >= 0))
            {
                if (constexpr.IS_TRUE(y >= 0))
                {
                    return gcd((ulong)x, (ulong)y, nonZero);
                }
                else
                {
                    return gcd((ulong)x, (ulong)abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(y >= 0))
            {
                return gcd((ulong)abs(x), (ulong)y, nonZero);
            }
            else
            {
                return gcd((ulong)abs(x), (ulong)abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="long2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 gcd(long2 x, long2 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ulong2)abs(x), (ulong2)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="long3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 gcd(long3 x, long3 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ulong3)abs(x), (ulong3)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="long4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 gcd(long4 x, long4 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ulong4)abs(x), (ulong4)abs(y), nonZero);
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="ulong"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong gcd(ulong x, ulong y, Promise nonZero = Promise.Nothing)
        {
            ulong result;

            minmax(x, y, out x, out y);

            if (!(nonZero.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0 && y != 0)))
            {
                if (Hint.Unlikely(y == 0))
                {
                    result = x; goto RET;
                }
            }
            
            x %= y;
            if (x == 0) 
            { 
                result = y; goto RET;
            }
            int zu = tzcnt(x);
            int zv = tzcnt(y);
            int shift = min(zu, zv);
            x >>= zu;
            y >>= zv;

            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }

                result = x << shift; goto RET;
            }
            else
            {
                while (Hint.Likely(!LOOP_gcd_u64(ref x, ref y)))
                {

                }

                result = x << shift; goto RET;
            }

        RET:
            Assume.gcd(result, x, y);

            return result;
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ulong2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 gcd(ulong2 x, ulong2 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ulong2 result = new ulong2(gcd(x.x, y.x), gcd(x.y, y.y));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu64(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new ulong2(gcd(x.x, y.x, nonZero), gcd(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ulong3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 gcd(ulong3 x, ulong3 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ulong3 result = new ulong3(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu64(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.gcd_epu64x2(x.xy, x.zz, y.xy, y.zz, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                return new ulong3(gcd(x.__x0, y.__x0, nonZero), gcd(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ulong4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 gcd(ulong4 x, ulong4 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ulong4 result = new ulong4(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z), gcd(x.w, y.w));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu64(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.gcd_epu64x2(x.xy, x.zw, y.xy, y.zw, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong4(lo, hi);
            }
            else
            {
                return new ulong4(gcd(x.__x0, y.__x0, nonZero), gcd(x.__x2, y.__x2, nonZero));
            }
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="int"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint gcd(int x, int y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(x >= 0))
            {
                if (constexpr.IS_TRUE(y >= 0))
                {
                    return gcd((uint)x, (uint)y, nonZero);
                }
                else
                {
                    return gcd((uint)x, (uint)abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(y >= 0))
            {
                return gcd((uint)abs(x), (uint)y, nonZero);
            }
            else
            {
                return gcd((uint)abs(x), (uint)abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="int2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 gcd(int2 x, int2 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(all(x >= 0)))
            {
                if (constexpr.IS_TRUE(all(y >= 0)))
                {
                    return gcd((uint2)x, (uint2)y, nonZero);
                }
                else
                {
                    return gcd((uint2)x, (uint2)abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(all(y >= 0)))
            {
                return gcd((uint2)abs(x), (uint2)y, nonZero);
            }
            else
            {
                return gcd((uint2)abs(x), (uint2)abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="int3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 gcd(int3 x, int3 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(all(x >= 0)))
            {
                if (constexpr.IS_TRUE(all(y >= 0)))
                {
                    return gcd((uint3)x, (uint3)y, nonZero);
                }
                else
                {
                    return gcd((uint3)x, (uint3)abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(all(y >= 0)))
            {
                return gcd((uint3)abs(x), (uint3)y, nonZero);
            }
            else
            {
                return gcd((uint3)abs(x), (uint3)abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="int4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 gcd(int4 x, int4 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(all(x >= 0)))
            {
                if (constexpr.IS_TRUE(all(y >= 0)))
                {
                    return gcd((uint4)x, (uint4)y, nonZero);
                }
                else
                {
                    return gcd((uint4)x, (uint4)abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(all(y >= 0)))
            {
                return gcd((uint4)abs(x), (uint4)y, nonZero);
            }
            else
            {
                return gcd((uint4)abs(x), (uint4)abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="int8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 gcd(int8 x, int8 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(all(x >= 0)))
            {
                if (constexpr.IS_TRUE(all(y >= 0)))
                {
                    return gcd((uint8)x, (uint8)y, nonZero);
                }
                else
                {
                    return gcd((uint8)x, (uint8)abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(all(y >= 0)))
            {
                return gcd((uint8)abs(x), (uint8)y, nonZero);
            }
            else
            {
                return gcd((uint8)abs(x), (uint8)abs(y), nonZero);
            }
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="uint"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint gcd(uint x, uint y, Promise nonZero = Promise.Nothing)
        {
            uint result;

            minmax(x, y, out x, out y);

            if (!(nonZero.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0 && y != 0)))
            {
                if (Hint.Unlikely(y == 0))
                {
                    result = x; goto RET;
                }
            }
            
            x %= y;
            if (x == 0) 
            {
                result = y; goto RET;
            }
            int zu = tzcnt(x);
            int zv = tzcnt(y);
            int shift = min(zu, zv);
            x >>= zu;
            y >>= zv;

            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y)))
                {
                    result = x << shift; goto RET;
                }

                result = x << shift; goto RET;
            }
            else
            {
                while (Hint.Likely(!LOOP_gcd_u32(ref x, ref y)))
                {

                }

                result = x << shift; goto RET;
            }

        RET:
            Assume.gcd(result, x, y);

            return result;
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="uint2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 gcd(uint2 x, uint2 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                uint2 result = new uint2(gcd(x.x, y.x), gcd(x.y, y.y));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu32(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new uint2(gcd(x.x, y.x, nonZero), gcd(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="uint3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 gcd(uint3 x, uint3 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                uint3 result = new uint3(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu32(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new uint3(gcd(x.x, y.x, nonZero), gcd(x.y, y.y, nonZero), gcd(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="uint4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 gcd(uint4 x, uint4 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                uint4 result = new uint4(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z), gcd(x.w, y.w));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu32(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new uint4(gcd(x.x, y.x, nonZero), gcd(x.y, y.y, nonZero), gcd(x.z, y.z, nonZero), gcd(x.w, y.w, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="uint8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 gcd(uint8 x, uint8 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                uint8 result = new uint8(gcd(x.x0, y.x0),
                                         gcd(x.x1, y.x1),
                                         gcd(x.x2, y.x2),
                                         gcd(x.x3, y.x3),
                                         gcd(x.x4, y.x4),
                                         gcd(x.x5, y.x5),
                                         gcd(x.x6, y.x6),
                                         gcd(x.x7, y.x7));

                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu32(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.gcd_epu32x2(x.v4_0, x.v4_4, y.v4_0, y.v4_4, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new uint8(lo, hi);
            }
            else
            {
                return new uint8(gcd(x.v4_0, y.v4_0, nonZero), gcd(x.v4_4, y.v4_4, nonZero));
            }
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="short"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort gcd(short x, short y, Promise nonZero = Promise.Nothing)
        {
            return (ushort)gcd((int)x, (int)y, nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="short2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 gcd(short2 x, short2 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort2)abs(x), (ushort2)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="short3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 gcd(short3 x, short3 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort3)abs(x), (ushort3)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="short4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 gcd(short4 x, short4 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort4)abs(x), (ushort4)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="short8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 gcd(short8 x, short8 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort8)abs(x), (ushort8)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="short16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 gcd(short16 x, short16 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort16)abs(x), (ushort16)abs(y), nonZero);
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="ushort"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort gcd(ushort x, ushort y, Promise nonZero = Promise.Nothing)
        {
            return (ushort)gcd((uint)x, (uint)y, nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ushort2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 gcd(ushort2 x, ushort2 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ushort2 result = new ushort2(gcd(x.x, y.x), gcd(x.y, y.y));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu16(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new ushort2((ushort)gcd((uint)x.x, (uint)y.x, nonZero), (ushort)gcd((uint)x.y, (uint)y.y, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ushort3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 gcd(ushort3 x, ushort3 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ushort3 result = new ushort3(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu16(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new ushort3((ushort)gcd((uint)x.x, (uint)y.x, nonZero), (ushort)gcd((uint)x.y, (uint)y.y, nonZero), (ushort)gcd((uint)x.z, (uint)y.z, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ushort4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 gcd(ushort4 x, ushort4 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ushort4 result = new ushort4(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z), gcd(x.w, y.w));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu16(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new ushort4((ushort)gcd((uint)x.x, (uint)y.x, nonZero), (ushort)gcd((uint)x.y, (uint)y.y, nonZero), (ushort)gcd((uint)x.z, (uint)y.z, nonZero), (ushort)gcd((uint)x.w, (uint)y.w, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ushort8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 gcd(ushort8 x, ushort8 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ushort8 result = new ushort8(gcd(x.x0, y.x0),
                                             gcd(x.x1, y.x1),
                                             gcd(x.x2, y.x2),
                                             gcd(x.x3, y.x3),
                                             gcd(x.x4, y.x4),
                                             gcd(x.x5, y.x5),
                                             gcd(x.x6, y.x6),
                                             gcd(x.x7, y.x7));

                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu16(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new ushort8((ushort)gcd((uint)x.x0, (uint)y.x0, nonZero),
                                   (ushort)gcd((uint)x.x1, (uint)y.x1, nonZero),
                                   (ushort)gcd((uint)x.x2, (uint)y.x2, nonZero),
                                   (ushort)gcd((uint)x.x3, (uint)y.x3, nonZero),
                                   (ushort)gcd((uint)x.x4, (uint)y.x4, nonZero),
                                   (ushort)gcd((uint)x.x5, (uint)y.x5, nonZero),
                                   (ushort)gcd((uint)x.x6, (uint)y.x6, nonZero),
                                   (ushort)gcd((uint)x.x7, (uint)y.x7, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="ushort16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 gcd(ushort16 x, ushort16 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                ushort16 result = new ushort16(gcd(x.x0,  y.x0),
                                               gcd(x.x1,  y.x1),
                                               gcd(x.x2,  y.x2),
                                               gcd(x.x3,  y.x3),
                                               gcd(x.x4,  y.x4),
                                               gcd(x.x5,  y.x5),
                                               gcd(x.x6,  y.x6),
                                               gcd(x.x7,  y.x7),
                                               gcd(x.x8,  y.x8),
                                               gcd(x.x9,  y.x9),
                                               gcd(x.x10, y.x10),
                                               gcd(x.x11, y.x11),
                                               gcd(x.x12, y.x12),
                                               gcd(x.x13, y.x13),
                                               gcd(x.x14, y.x14),
                                               gcd(x.x15, y.x15));

                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu16(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.gcd_epu16x2(x.v8_0, x.v8_8, y.v8_0, y.v8_8, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ushort16(lo, hi);
            }
            else
            {
                return new ushort16(gcd(x.v8_0, y.v8_0, nonZero), gcd(x.v8_8, y.v8_8, nonZero));
            }
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="sbyte"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte gcd(sbyte x, sbyte y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_TRUE(x >= 0))
            {
                if (constexpr.IS_TRUE(y >= 0))
                {
                    return gcd((byte)x, (byte)y, nonZero);
                }
                else
                {
                    return gcd((byte)x, (byte)abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(y >= 0))
            {
                return gcd((byte)abs(x), (byte)y, nonZero);
            }
            else
            {
                return gcd((byte)abs(x), (byte)abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="sbyte2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 gcd(sbyte2 x, sbyte2 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte2)abs(x), (byte2)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="sbyte3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 gcd(sbyte3 x, sbyte3 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte3)abs(x), (byte3)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="sbyte4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 gcd(sbyte4 x, sbyte4 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte4)abs(x), (byte4)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="sbyte8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 gcd(sbyte8 x, sbyte8 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte8)abs(x), (byte8)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="sbyte16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 gcd(sbyte16 x, sbyte16 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte16)abs(x), (byte16)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="sbyte32"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 gcd(sbyte32 x, sbyte32 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte32)abs(x), (byte32)abs(y), nonZero);
        }


        /// <summary>       Returns the greatest common divisor of two <see cref="byte"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte gcd(byte x, byte y, Promise nonZero = Promise.Nothing)
        {
            if (!(nonZero.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0 && y != 0)))
            {
                if (Hint.Unlikely(x == 0)) return y;
                if (Hint.Unlikely(y == 0)) return x;
            }
            
            int tzcntX = tzcnt(x);
            int tzcntY = tzcnt(y);
            int shift = min(tzcntX, tzcntY);
            x >>= tzcntX;

            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }
                if (Hint.Unlikely(LOOP_gcd_u8(ref x, ref y)))
                {
                    return (byte)(x << shift);
                }

                return (byte)(x << shift);
            }
            else
            {
                while (Hint.Likely(!LOOP_gcd_u8(ref x, ref y)))
                {

                }
                
                return (byte)(x << shift);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="byte2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 gcd(byte2 x, byte2 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                byte2 result = new byte2(gcd(x.x, y.x), gcd(x.y, y.y));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu8(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new byte2((byte)gcd((uint)x.x, (uint)y.x, nonZero), (byte)gcd((uint)x.y, (uint)y.y, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="byte3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 gcd(byte3 x, byte3 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                byte3 result = new byte3(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu8(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new byte3((byte)gcd((uint)x.x, (uint)y.x, nonZero), (byte)gcd((uint)x.y, (uint)y.y, nonZero), (byte)gcd((uint)x.z, (uint)y.z, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="byte4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 gcd(byte4 x, byte4 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                byte4 result = new byte4(gcd(x.x, y.x), gcd(x.y, y.y), gcd(x.z, y.z), gcd(x.w, y.w));
                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu8(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new byte4((byte)gcd((uint)x.x, (uint)y.x, nonZero), (byte)gcd((uint)x.y, (uint)y.y, nonZero), (byte)gcd((uint)x.z, (uint)y.z, nonZero), (byte)gcd((uint)x.w, (uint)y.w, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="byte8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 gcd(byte8 x, byte8 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                byte8 result = new byte8(gcd(x.x0, y.x0),
                                         gcd(x.x1, y.x1),
                                         gcd(x.x2, y.x2),
                                         gcd(x.x3, y.x3),
                                         gcd(x.x4, y.x4),
                                         gcd(x.x5, y.x5),
                                         gcd(x.x6, y.x6),
                                         gcd(x.x7, y.x7));

                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu8(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new byte8((byte)gcd((uint)x.x0, (uint)y.x0, nonZero),
                                 (byte)gcd((uint)x.x1, (uint)y.x1, nonZero),
                                 (byte)gcd((uint)x.x2, (uint)y.x2, nonZero),
                                 (byte)gcd((uint)x.x3, (uint)y.x3, nonZero),
                                 (byte)gcd((uint)x.x4, (uint)y.x4, nonZero),
                                 (byte)gcd((uint)x.x5, (uint)y.x5, nonZero),
                                 (byte)gcd((uint)x.x6, (uint)y.x6, nonZero),
                                 (byte)gcd((uint)x.x7, (uint)y.x7, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="byte16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 gcd(byte16 x, byte16 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                byte16 result = new byte16(gcd(x.x0,  y.x0),
                                           gcd(x.x1,  y.x1),
                                           gcd(x.x2,  y.x2),
                                           gcd(x.x3,  y.x3),
                                           gcd(x.x4,  y.x4),
                                           gcd(x.x5,  y.x5),
                                           gcd(x.x6,  y.x6),
                                           gcd(x.x7,  y.x7),
                                           gcd(x.x8,  y.x8),
                                           gcd(x.x9,  y.x9),
                                           gcd(x.x10, y.x10),
                                           gcd(x.x11, y.x11),
                                           gcd(x.x12, y.x12),
                                           gcd(x.x13, y.x13),
                                           gcd(x.x14, y.x14),
                                           gcd(x.x15, y.x15));

                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.gcd_epu8(x, y, nonZero.Promises(Promise.NonZero), 16);
            }
            else
            {
                return new byte16((byte)gcd((uint)x.x0,  (uint)y.x0,  nonZero),
                                  (byte)gcd((uint)x.x1,  (uint)y.x1,  nonZero),
                                  (byte)gcd((uint)x.x2,  (uint)y.x2,  nonZero),
                                  (byte)gcd((uint)x.x3,  (uint)y.x3,  nonZero),
                                  (byte)gcd((uint)x.x4,  (uint)y.x4,  nonZero),
                                  (byte)gcd((uint)x.x5,  (uint)y.x5,  nonZero),
                                  (byte)gcd((uint)x.x6,  (uint)y.x6,  nonZero),
                                  (byte)gcd((uint)x.x7,  (uint)y.x7,  nonZero),
                                  (byte)gcd((uint)x.x8,  (uint)y.x8,  nonZero),
                                  (byte)gcd((uint)x.x9,  (uint)y.x9,  nonZero),
                                  (byte)gcd((uint)x.x10, (uint)y.x10, nonZero),
                                  (byte)gcd((uint)x.x11, (uint)y.x11, nonZero),
                                  (byte)gcd((uint)x.x12, (uint)y.x12, nonZero),
                                  (byte)gcd((uint)x.x13, (uint)y.x13, nonZero),
                                  (byte)gcd((uint)x.x14, (uint)y.x14, nonZero),
                                  (byte)gcd((uint)x.x15, (uint)y.x15, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="byte32"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 gcd(byte32 x, byte32 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                byte32 result = new byte32(gcd(x.x0,  y.x0),
                                           gcd(x.x1,  y.x1),
                                           gcd(x.x2,  y.x2),
                                           gcd(x.x3,  y.x3),
                                           gcd(x.x4,  y.x4),
                                           gcd(x.x5,  y.x5),
                                           gcd(x.x6,  y.x6),
                                           gcd(x.x7,  y.x7),
                                           gcd(x.x8,  y.x8),
                                           gcd(x.x9,  y.x9),
                                           gcd(x.x10, y.x10),
                                           gcd(x.x11, y.x11),
                                           gcd(x.x12, y.x12),
                                           gcd(x.x13, y.x13),
                                           gcd(x.x14, y.x14),
                                           gcd(x.x15, y.x15),
                                           gcd(x.x16, y.x16),
                                           gcd(x.x17, y.x17),
                                           gcd(x.x18, y.x18),
                                           gcd(x.x19, y.x19),
                                           gcd(x.x20, y.x20),
                                           gcd(x.x21, y.x21),
                                           gcd(x.x22, y.x22),
                                           gcd(x.x23, y.x23),
                                           gcd(x.x24, y.x24),
                                           gcd(x.x25, y.x25),
                                           gcd(x.x26, y.x26),
                                           gcd(x.x27, y.x27),
                                           gcd(x.x28, y.x28),
                                           gcd(x.x29, y.x29),
                                           gcd(x.x30, y.x30),
                                           gcd(x.x31, y.x31));

                if (constexpr.IS_CONST(result))
                {
                    return result;
                }
            }

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_gcd_epu8(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.gcd_epu8x2(x.v16_0, x.v16_16, y.v16_0, y.v16_16, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new byte32(lo, hi);
            }
            else
            {
                return new byte32(gcd(x.v16_0, y.v16_0, nonZero), gcd(x.v16_16, y.v16_16, nonZero));
            }
        }
    }
}