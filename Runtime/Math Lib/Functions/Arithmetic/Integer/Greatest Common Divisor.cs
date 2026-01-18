using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
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
            private static bool LOOP_gcd_epu8([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 result, [NoAlias] ref v128 tzcntB, [NoAlias] ref v128 doneMask, [NoAlias] out v128 loopCheck, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    b = srlv_epi8(b, tzcntB, elements: elements);
                    loopCheck = cmpeq_epi8(a, b);

                    minmax_epu8(a, b, out a, out b);
                    b = sub_epi8(b, a);

                    result = blendv_si128(result, a, loopCheck);

                    if (Sse4_1.IsSse41Supported)
                    {
                        if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                        {
                            return true;
                        }
                        else
                        {
                            tzcntB = tzcnt_epi8(b);
                            doneMask = or_si128(doneMask, loopCheck);

                            return false;
                        }
                    }
                    else
                    {
                        doneMask = or_si128(doneMask, loopCheck);

                        if (Hint.Unlikely(alltrue_epi128<byte>(doneMask, elements)))
                        {
                            return true;
                        }
                        else
                        {
                            tzcntB = tzcnt_epi8(b);

                            return false;
                        }
                    }
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
                    b = srlv_epi32(b, tzcntB);
                    loopCheck = cmpeq_epi32(a, b);

                    minmax_epu32(a, b, out a, out b);
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
            private static bool mm256_LOOP_gcd_epu8_epu16([NoAlias] ref v256 a, [NoAlias] ref v256 b, [NoAlias] ref v256 result, [NoAlias] ref v256 tzcntB, [NoAlias] ref v256 doneMask, [NoAlias] out v256 loopCheck, byte elements = 16)
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

                    mm256_minmax_epu32(a, b, out a, out b);
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
            private static void POSTLOOP_gcd_epu8(ref v128 result, v128 shift, v128 result_if_zero_any, v128 checkZeroMask, bool promiseNonZero, byte elements = 8)
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
            public static v128 gcd_epu8(v128 a, v128 b, bool promiseNonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU8(a, 0, elements) && constexpr.ALL_GT_EPU8(b, 0, elements);

                    PRELOOP_gcd_epu8(a, b, out v128 tzcntA, out v128 tzcntB, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;

                    if (Avx2.IsAvx2Supported)
                    {
                        switch (elements)
                        {
                            case 16:
                            {
                                v256 a16 = Avx2.mm256_cvtepu8_epi16(a);
                                v256 b16 = Avx2.mm256_cvtepu8_epi16(b);
                                v256 tzcntA16 = Avx2.mm256_cvtepu8_epi16(tzcntA);
                                v256 tzcntB16 = Avx2.mm256_cvtepu8_epi16(tzcntB);

                                v256 result16 = Avx2.mm256_cvtepu8_epi16(result);
                                v256 doneMask16 = Avx2.mm256_cvtepi8_epi16(doneMask);

                                v256 shift = Avx2.mm256_min_epu16(tzcntA16, tzcntB16);

                                a16 = mm256_srlv_epi16(a16, tzcntA16);

                                while (Hint.Likely(!mm256_LOOP_gcd_epu8_epu16(ref a16, ref b16, ref result16, ref tzcntB16, ref doneMask16, out _, 16)))
                                {

                                }

                                result = mm256_cvtepi16_epi8(mm256_sllv_epi16(result16, shift));

                                break;
                            }
                            case 8:
                            {
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

                                result = mm256_cvtepi32_epi8(Avx2.mm256_sllv_epi32(result32, shift));

                                break;
                            }
                            default:
                            {
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

                                result = cvtepi32_epi8(sllv_epi32(result32, shift), elements);

                                break;
                            }
                        }
                    }
                    else
                    {
                        v128 shift = min_epu8(tzcntA, tzcntB);

                        if (Sse4_1.IsSse41Supported)
                        {
                            doneMask = fillmissing_epi8(doneMask, elements);
                        }

                        a = srlv_epi8(a, tzcntA, inRange: promiseNonZero, elements: elements);

                        while (Hint.Likely(!LOOP_gcd_epu8(ref a, ref b, ref result, ref tzcntB, ref doneMask, out _, elements)))
                        {

                        }

                        result = sllv_epi8(result, shift, inRange: false, noOverflow: true, elements: elements);
                    }

                    if (!promiseNonZero)
                    {
                        result = blendv_si128(result, result_if_zero_any, checkZeroMask);
                    }

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

                    PRELOOP_gcd_epu8(a0, b0, out v128 tzcntA0, out v128 tzcntB0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu8(a1, b1, out v128 tzcntA1, out v128 tzcntB1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    v128 shift0 = min_epu8(tzcntA0, tzcntB0);
                    v128 shift1 = min_epu8(tzcntA1, tzcntB1);

                    a0 = srlv_epi8(a0, tzcntA0, inRange: promiseNonZero);
                    a1 = srlv_epi8(a1, tzcntA1, inRange: promiseNonZero);

                    while (true)
                    {
                        LOOP_gcd_epu8(ref a0, ref b0, ref r0, ref tzcntB0, ref doneMask0, out v128 loopCheck0, 16);
                        LOOP_gcd_epu8(ref a1, ref b1, ref r1, ref tzcntB1, ref doneMask1, out v128 loopCheck1, 16);

                        if (Hint.Unlikely(alltrue_epi128<byte>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                    }

                    POSTLOOP_gcd_epu8(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu8(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu8(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU8(a, 0) && constexpr.ALL_GT_EPU8(b, 0);
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 tzcntA = mm256_tzcnt_epi8(a);
                    v256 tzcntB = mm256_tzcnt_epi8(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 a_is_zero = Avx2.mm256_cmpeq_epi8(a, ZERO);
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi8(b, ZERO);

                        doneMask = Avx2.mm256_or_si256(a_is_zero, b_is_zero);
                        result_if_zero_any = mm256_blendv_si256(Avx2.mm256_and_si256(b, a_is_zero), a, b_is_zero);
                    }

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    a = mm256_srlv_epi8(a, tzcntA);

                    while (Hint.Likely(!mm256_LOOP_gcd_epu8(ref a, ref b, ref result, ref tzcntB, ref doneMask, out _)))
                    {

                    }

                    result = mm256_sllv_epi8(result, shift, noOverflow: true);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }

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

                                result = mm256_cvtepi32_epi16(Avx2.mm256_sllv_epi32(result32, shift));

                                break;
                            }
                            default:
                            {
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

                                result = cvtepi32_epi16(sllv_epi32(result32, shift), elements);

                                break;
                            }
                        }
                    }
                    else
                    {
                        v128 shift = min_epu8(tzcntA, tzcntB);

                        if (Sse4_1.IsSse41Supported)
                        {
                            doneMask = fillmissing_epi16(doneMask, elements);
                        }

                        a = srlv_epi16(a, tzcntA, inRange: promiseNonZero, elements: elements);

                        while (true)
                        {
                            LOOP_gcd_epu16(ref a, ref b, ref result, out v128 loopCheck, tzcntB, elements);

                            if (Sse4_1.IsSse41Supported)
                            {
                                if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                                {
                                    break;
                                }
                                else
                                {
                                    tzcntB = tzcnt_epi16(b);
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
                                    tzcntB = tzcnt_epi16(b);
                                }
                            }
                        }

                        result = sllv_epi16(result, shift, inRange: false, elements: elements);
                    }

                    if (!promiseNonZero)
                    {
                        result = blendv_si128(result, result_if_zero_any, checkZeroMask);
                    }

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

                    PRELOOP_gcd_epu16(a0, b0, out v128 tzcntA0, out v128 tzcntB0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu16(a1, b1, out v128 tzcntA1, out v128 tzcntB1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    v128 shift0 = min_epu16(tzcntA0, tzcntB0);
                    v128 shift1 = min_epu16(tzcntA1, tzcntB1);

                    a0 = srlv_epi16(a0, tzcntA0, inRange: promiseNonZero);
                    a1 = srlv_epi16(a1, tzcntA1, inRange: promiseNonZero);

                    while (true)
                    {
                        LOOP_gcd_epu16(ref a0, ref b0, ref r0, out v128 loopCheck0, tzcntB0);
                        LOOP_gcd_epu16(ref a1, ref b1, ref r1, out v128 loopCheck1, tzcntB1);

                        doneMask0 = or_si128(doneMask0, loopCheck0);
                        doneMask1 = or_si128(doneMask1, loopCheck1);

                        if (Hint.Unlikely(alltrue_epi128<short>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB0 = tzcnt_epi16(b0);
                            tzcntB1 = tzcnt_epi16(b1);
                        }
                    }

                    POSTLOOP_gcd_epu16(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu16(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu16(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU16(a, 0) && constexpr.ALL_GT_EPU16(b, 0);
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 tzcntA = mm256_tzcnt_epi16(a);
                    v256 tzcntB = mm256_tzcnt_epi16(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 a_is_zero = Avx2.mm256_cmpeq_epi16(a, ZERO);
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi16(b, ZERO);

                        doneMask = Avx2.mm256_or_si256(a_is_zero, b_is_zero);
                        result_if_zero_any = mm256_blendv_si256(Avx2.mm256_and_si256(b, a_is_zero), a, b_is_zero);
                    }

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    a = mm256_srlv_epi16(a, tzcntA);

                    while (true)
                    {
                        b = mm256_srlv_epi16(b, tzcntB);
                        v256 loopCheck = Avx2.mm256_cmpeq_epi16(a, b);

                        mm256_minmax_epu16(a, b, out a, out b);
                        b = Avx2.mm256_sub_epi16(b, a);

                        result = mm256_blendv_si256(result, a, loopCheck);

                        if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi16(b);
                            doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        }
                    }

                    result = mm256_sllv_epi16(result, shift);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }

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

                    PRELOOP_gcd_epu32(ref a, b, out v128 tzcntB, out v128 shift, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero, elements);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;

                    if (Sse4_1.IsSse41Supported)
                    {
                        doneMask = fillmissing_epi32(doneMask, elements);
                    }

                    while (true)
                    {
                        LOOP_gcd_epu32(ref a, ref b, ref result, out v128 loopCheck, tzcntB, elements);

                        if (Sse4_1.IsSse41Supported)
                        {
                            if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                            {
                                break;
                            }
                            else
                            {
                                tzcntB = tzcnt_epi32(b, elements);
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
                                tzcntB = tzcnt_epi32(b, elements);
                            }
                        }
                    }

                    POSTLOOP_gcd_epu32(ref result, shift, result_if_zero_any, checkZeroMask, promiseNonZero, elements);

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

                    PRELOOP_gcd_epu32(ref a0, b0, out v128 tzcntB0, out v128 shift0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu32(ref a1, b1, out v128 tzcntB1, out v128 shift1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    while (true)
                    {
                        LOOP_gcd_epu32(ref a0, ref b0, ref r0, out v128 loopCheck0, tzcntB0);
                        LOOP_gcd_epu32(ref a1, ref b1, ref r1, out v128 loopCheck1, tzcntB1);

                        doneMask0 = or_si128(doneMask0, loopCheck0);
                        doneMask1 = or_si128(doneMask1, loopCheck1);

                        if (Hint.Unlikely(alltrue_epi128<int>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB0 = tzcnt_epi32(b0);
                            tzcntB1 = tzcnt_epi32(b1);
                        }
                    }

                    POSTLOOP_gcd_epu32(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu32(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu32(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU32(a, 0) && constexpr.ALL_GT_EPU32(b, 0);
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 tzcntA = mm256_tzcnt_epi32(a);
                    v256 tzcntB = mm256_tzcnt_epi32(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 a_is_zero = Avx2.mm256_cmpeq_epi32(a, ZERO);
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi32(b, ZERO);

                        doneMask = Avx2.mm256_or_si256(a_is_zero, b_is_zero);
                        result_if_zero_any = mm256_blendv_si256(Avx2.mm256_and_si256(b, a_is_zero), a, b_is_zero);
                    }

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    a = Avx2.mm256_srlv_epi32(a, tzcntA);

                    while (true)
                    {
                        b = Avx2.mm256_srlv_epi32(b, tzcntB);
                        v256 loopCheck = Avx2.mm256_cmpeq_epi32(a, b);

                        mm256_minmax_epu32(a, b, out a, out b);
                        b = Avx2.mm256_sub_epi32(b, a);

                        result = mm256_blendv_si256(result, a, loopCheck);

                        if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi32(b);
                            doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        }
                    }

                    result = Avx2.mm256_sllv_epi32(result, shift);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_gcd_epu64([NoAlias] ref v128 a, v128 b, [NoAlias] out v128 tzcntB, [NoAlias] out v128 shift, [NoAlias] out v128 doneMask, [NoAlias] out v128 result, [NoAlias] out v128 result_if_zero_any, bool promiseNonZero)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    v128 tzcntA = tzcnt_epi64(a);
                         tzcntB = tzcnt_epi64(b);
                         shift = min_epu8(tzcntA, tzcntB);

                    result = ZERO;
                    doneMask = ZERO;
                    result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v128 a_is_zero = cmpeq_epi64(a, ZERO);
                        v128 b_is_zero = cmpeq_epi64(b, ZERO);

                        doneMask = or_si128(a_is_zero, b_is_zero);
                        result_if_zero_any = blendv_si128(and_si128(b, a_is_zero), a, b_is_zero);
                    }

                    a = srlv_epi64(a, tzcntA, inRange: promiseNonZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_gcd_epu64([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 result, [NoAlias] out v128 loopCheck, v128 tzcntB)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    b = srlv_epi64(b, tzcntB);
                    loopCheck = cmpeq_epi64(a, b);

                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    minmax_epu64(a, b, out a, out b);
                    //}
                    //else
                    //{
                          xchg_si128(ref a, ref b, cmpgt_epu64(a, b));
                    //}

                    b = sub_epi64(b, a);
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

                    PRELOOP_gcd_epu64(ref a, b, out v128 tzcntB, out v128 shift, out v128 doneMask, out v128 result, out v128 result_if_zero_any, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask = doneMask;

                    while (true)
                    {
                        LOOP_gcd_epu64(ref a, ref b, ref result, out v128 loopCheck, tzcntB);

                        if (Sse4_1.IsSse41Supported)
                        {
                            if (Hint.Unlikely(testc_si128(loopCheck, not_si128(doneMask)) == 1))
                            {
                                break;
                            }
                            else
                            {
                                tzcntB = tzcnt_epi64(b);
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
                                tzcntB = tzcnt_epi64(b);
                            }
                        }
                    }

                    POSTLOOP_gcd_epu64(ref result, shift, result_if_zero_any, checkZeroMask, promiseNonZero);

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

                    PRELOOP_gcd_epu64(ref a0, b0, out v128 tzcntB0, out v128 shift0, out v128 doneMask0, out r0, out v128 result_if_zero_any0, promiseNonZero);
                    PRELOOP_gcd_epu64(ref a1, b1, out v128 tzcntB1, out v128 shift1, out v128 doneMask1, out r1, out v128 result_if_zero_any1, promiseNonZero);

                    // if promiseNonZero
                    v128 checkZeroMask0 = doneMask0;
                    v128 checkZeroMask1 = doneMask1;

                    while (true)
                    {
                        LOOP_gcd_epu64(ref a0, ref b0, ref r0, out v128 loopCheck0, tzcntB0);
                        LOOP_gcd_epu64(ref a1, ref b1, ref r1, out v128 loopCheck1, tzcntB1);

                        doneMask0 = or_si128(doneMask0, loopCheck0);
                        doneMask1 = or_si128(doneMask1, loopCheck1);

                        if (Hint.Unlikely(alltrue_epi128<long>(and_si128(doneMask0, doneMask1))))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB0 = tzcnt_epi64(b0);
                            tzcntB1 = tzcnt_epi64(b1);
                        }
                    }

                    POSTLOOP_gcd_epu64(ref r0, shift0, result_if_zero_any0, checkZeroMask0, promiseNonZero);
                    POSTLOOP_gcd_epu64(ref r1, shift1, result_if_zero_any1, checkZeroMask1, promiseNonZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_gcd_epu64(v256 a, v256 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_GT_EPU64(a, 0, elements) && constexpr.ALL_GT_EPU64(b, 0, elements);
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 tzcntA = mm256_tzcnt_epi64(a);
                    v256 tzcntB = mm256_tzcnt_epi64(b);
                    v256 shift = Avx2.mm256_min_epu8(tzcntA, tzcntB);

                    v256 result = ZERO;
                    v256 doneMask = ZERO;
                    v256 result_if_zero_any = ZERO;

                    if (!promiseNonZero)
                    {
                        v256 a_is_zero = Avx2.mm256_cmpeq_epi64(a, ZERO);
                        v256 b_is_zero = Avx2.mm256_cmpeq_epi64(b, ZERO);

                        doneMask = Avx2.mm256_or_si256(a_is_zero, b_is_zero);
                        result_if_zero_any = mm256_blendv_si256(Avx2.mm256_and_si256(b, a_is_zero), a, b_is_zero);
                    }

                    doneMask = mm256_fillmissing_epi64(doneMask, elements);

                    // if promiseNonZero
                    v256 checkZeroMask = doneMask;

                    a = Avx2.mm256_srlv_epi64(a, tzcntA);

                    while (true)
                    {
                        b = Avx2.mm256_srlv_epi64(b, tzcntB);
                        v256 loopCheck = Avx2.mm256_cmpeq_epi64(a, b);

                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    mm256_minmax_epu64(a, b, out a, out b);
                        //}
                        //else
                        //{
                              mm256_xchg_si256(ref a, ref b, mm256_cmpgt_epu64(a, b));
                        //}

                        b = Avx2.mm256_sub_epi64(b, a);
                        result = mm256_blendv_si256(result, a, loopCheck);

                        if (Hint.Unlikely(Avx.mm256_testc_si256(loopCheck, mm256_not_si256(doneMask)) == 1))
                        {
                            break;
                        }
                        else
                        {
                            tzcntB = mm256_tzcnt_epi64(b);
                            doneMask = Avx2.mm256_or_si256(doneMask, loopCheck);
                        }
                    }

                    result = Avx2.mm256_sllv_epi64(result, shift);
                    if (!promiseNonZero)
                    {
                        result = mm256_blendv_si256(result, result_if_zero_any, checkZeroMask);
                    }


                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LOOP_gcd_u128([NoAlias] ref UInt128 x, [NoAlias] ref UInt128 y, [NoAlias] ref int tzcntY)
        {
            y >>= tzcntY;
            bool test = x == y;
            minmax(x, y, out x, out y);
            y -= x;

            if (Hint.Unlikely(test))
            {
                return true;
            }
            else
            {
                tzcntY = tzcnt(y);
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LOOP_gcd_u64([NoAlias] ref ulong x, [NoAlias] ref ulong y, [NoAlias] ref int tzcntY)
        {
            y >>= tzcntY;
            bool test = x == y;
            minmax(x, y, out x, out y);
            y -= x;

            if (Hint.Unlikely(test))
            {
                return true;
            }
            else
            {
                tzcntY = math.tzcnt(y);
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool LOOP_gcd_u32([NoAlias] ref uint x, [NoAlias] ref uint y, [NoAlias] ref int tzcntY)
        {
            y >>= tzcntY;
            bool test = x == y;
            minmax(x, y, out x, out y);
            y -= x;

            if (Hint.Unlikely(test))
            {
                return true;
            }
            else
            {
                tzcntY = math.tzcnt(y);
                return false;
            }
        }

        /// <summary>       Returns the greatest common divisor of two <see cref="UInt128"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 gcd(UInt128 x, UInt128 y, Promise nonZero = Promise.Nothing)
        {
            if (!(nonZero.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0 && y != 0)))
            {
                if (Hint.Unlikely(x.IsZero)) return y;
                if (Hint.Unlikely(y.IsZero)) return x;
            }

            int tzcntX = tzcnt(x);
            int tzcntY = tzcnt(y);
            int shift = math.min(tzcntX, tzcntY);
            x >>= tzcntX;

            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }

                return x << shift;
            }
            else
            {
                while (Hint.Likely(!LOOP_gcd_u128(ref x, ref y, ref tzcntY)))
                {

                }

                return x << shift;
            }
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
                    return gcd((ulong)x, (ulong)math.abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(y >= 0))
            {
                return gcd((ulong)math.abs(x), (ulong)y, nonZero);
            }
            else
            {
                return gcd((ulong)math.abs(x), (ulong)math.abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.long2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 gcd(long2 x, long2 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ulong2)abs(x), (ulong2)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.long3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 gcd(long3 x, long3 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ulong3)abs(x), (ulong3)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.long4"/>s.
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
            if (!(nonZero.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0 && y != 0)))
            {
                if (Hint.Unlikely(x == 0)) return y;
                if (Hint.Unlikely(y == 0)) return x;
            }

            int tzcntX = math.tzcnt(x);
            int tzcntY = math.tzcnt(y);
            int shift = math.min(tzcntX, tzcntY);
            x >>= tzcntX;

            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }

                return x << shift;
            }
            else
            {
                while (Hint.Likely(!LOOP_gcd_u64(ref x, ref y, ref tzcntY)))
                {

                }

                return x << shift;
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ulong2"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ulong3"/>s.
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
                return new ulong3(gcd(x._xy, y._xy, nonZero), gcd(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ulong4"/>s.
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
                return new ulong4(gcd(x._xy, y._xy, nonZero), gcd(x._zw, y._zw, nonZero));
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
                    return gcd((uint)x, (uint)math.abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(y >= 0))
            {
                return gcd((uint)math.abs(x), (uint)y, nonZero);
            }
            else
            {
                return gcd((uint)math.abs(x), (uint)math.abs(y), nonZero);
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
            if (constexpr.IS_TRUE(math.all(x >= 0)))
            {
                if (constexpr.IS_TRUE(math.all(y >= 0)))
                {
                    return gcd((uint2)x, (uint2)y, nonZero);
                }
                else
                {
                    return gcd((uint2)x, (uint2)math.abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(math.all(y >= 0)))
            {
                return gcd((uint2)math.abs(x), (uint2)y, nonZero);
            }
            else
            {
                return gcd((uint2)math.abs(x), (uint2)math.abs(y), nonZero);
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
            if (constexpr.IS_TRUE(math.all(x >= 0)))
            {
                if (constexpr.IS_TRUE(math.all(y >= 0)))
                {
                    return gcd((uint3)x, (uint3)y, nonZero);
                }
                else
                {
                    return gcd((uint3)x, (uint3)math.abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(math.all(y >= 0)))
            {
                return gcd((uint3)math.abs(x), (uint3)y, nonZero);
            }
            else
            {
                return gcd((uint3)math.abs(x), (uint3)math.abs(y), nonZero);
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
            if (constexpr.IS_TRUE(math.all(x >= 0)))
            {
                if (constexpr.IS_TRUE(math.all(y >= 0)))
                {
                    return gcd((uint4)x, (uint4)y, nonZero);
                }
                else
                {
                    return gcd((uint4)x, (uint4)math.abs(y), nonZero);
                }
            }
            else if (constexpr.IS_TRUE(math.all(y >= 0)))
            {
                return gcd((uint4)math.abs(x), (uint4)y, nonZero);
            }
            else
            {
                return gcd((uint4)math.abs(x), (uint4)math.abs(y), nonZero);
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.int8"/>s.
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
            if (!(nonZero.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0 && y != 0)))
            {
                if (Hint.Unlikely(x == 0)) return y;
                if (Hint.Unlikely(y == 0)) return x;
            }

            int tzcntX = math.tzcnt(x);
            int tzcntY = math.tzcnt(y);
            int shift = math.min(tzcntX, tzcntY);
            x >>= tzcntX;

            if (constexpr.IS_CONST(x) && constexpr.IS_CONST(y))
            {
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }
                if (Hint.Unlikely(LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {
                    return x << shift;
                }

                return x << shift;
            }
            else
            {
                while (Hint.Likely(!LOOP_gcd_u32(ref x, ref y, ref tzcntY)))
                {

                }

                return x << shift;
            }
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
                return RegisterConversion.ToUInt2(Xse.gcd_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 2));
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
                return RegisterConversion.ToUInt3(Xse.gcd_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 3));
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
                return RegisterConversion.ToUInt4(Xse.gcd_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 4));
            }
            else
            {
                return new uint4(gcd(x.x, y.x, nonZero), gcd(x.y, y.y, nonZero), gcd(x.z, y.z, nonZero), gcd(x.w, y.w, nonZero));
            }
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.uint8"/>s.
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
                Xse.gcd_epu32x2(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(y.v4_0), RegisterConversion.ToV128(y.v4_4), out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 gcd(short2 x, short2 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort2)abs(x), (ushort2)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 gcd(short3 x, short3 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort3)abs(x), (ushort3)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 gcd(short4 x, short4 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort4)abs(x), (ushort4)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 gcd(short8 x, short8 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((ushort8)abs(x), (ushort8)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.short16"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort2"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort3"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort4"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort8"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.ushort16"/>s.
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
            return (byte)gcd((int)x, (int)y, nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 gcd(sbyte2 x, sbyte2 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte2)abs(x), (byte2)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 gcd(sbyte3 x, sbyte3 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte3)abs(x), (byte3)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 gcd(sbyte4 x, sbyte4 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte4)abs(x), (byte4)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 gcd(sbyte8 x, sbyte8 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte8)abs(x), (byte8)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 gcd(sbyte16 x, sbyte16 y, Promise nonZero = Promise.Nothing)
        {
            return gcd((byte16)abs(x), (byte16)abs(y), nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.sbyte32"/>s.
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
            return (byte)gcd((uint)x, (uint)y, nonZero);
        }

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte2"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte3"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte4"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte8"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte16"/>s.
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

        /// <summary>       Returns the componentwise greatest common divisor of two <see cref="MaxMath.byte32"/>s.
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
                Xse.gcd_epu64x2(x.v16_0, x.v16_16, y.v16_0, y.v16_16, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new byte32(lo, hi);
            }
            else
            {
                return new byte32(gcd(x.v16_0, y.v16_0, nonZero), gcd(x.v16_16, y.v16_16, nonZero));
            }
        }
    }
}