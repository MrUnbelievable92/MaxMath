using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
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
            private static v128 cbrt_epu8_takingAndReturning_epu16(v128 a, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LT_EPU16(a, 6 * 6 * 6, elements))
                    {
                        return cbrt_absepi8_takingAndReturning_epu16(a);
                    }

                    v128 cb1 = set1_epi16(1 * 1 * 1 - 1);
                    v128 cb2 = set1_epi16(2 * 2 * 2 - 1);
                    v128 cb3 = set1_epi16(3 * 3 * 3 - 1);
                    v128 cb4 = set1_epi16(4 * 4 * 4 - 1);
                    v128 cb5 = set1_epi16(5 * 5 * 5 - 1);
                    v128 cb6 = set1_epi16(6 * 6 * 6 - 1);

                    v128 result = sub_epi16(    negmask_epi16(cmpgt_epi16(a, cb1)),cmpgt_epi16(a, cb2));
                    result      = sub_epi16(result, add_epi16(cmpgt_epi16(a, cb3), cmpgt_epi16(a, cb4)));
                    result      = sub_epi16(result, add_epi16(cmpgt_epi16(a, cb5), cmpgt_epi16(a, cb6)));

                    constexpr.ASSUME_LE_EPU16(result, 6);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 cbrt_epu8_takingAndReturning_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LT_EPU16(a, 6 * 6 * 6))
                    {
                        return cbrt_absepi8_takingAndReturning_epu16(a);
                    }

                    v256 cb1 = mm256_set1_epi16(1 * 1 * 1 - 1);
                    v256 cb2 = mm256_set1_epi16(2 * 2 * 2 - 1);
                    v256 cb3 = mm256_set1_epi16(3 * 3 * 3 - 1);
                    v256 cb4 = mm256_set1_epi16(4 * 4 * 4 - 1);
                    v256 cb5 = mm256_set1_epi16(5 * 5 * 5 - 1);
                    v256 cb6 = mm256_set1_epi16(6 * 6 * 6 - 1);

                    v256 result = Avx2.mm256_sub_epi16(    mm256_negmask_epi16(Avx2.mm256_cmpgt_epi16(a, cb1)),Avx2.mm256_cmpgt_epi16(a, cb2));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb3), Avx2.mm256_cmpgt_epi16(a, cb4)));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb5), Avx2.mm256_cmpgt_epi16(a, cb6)));
                    
                    constexpr.ASSUME_LE_EPU16(result, 6);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 cbrt_absepi8_takingAndReturning_epu16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 cb1 = set1_epi16(1 * 1 * 1 - 1);
                    v128 cb2 = set1_epi16(2 * 2 * 2 - 1);
                    v128 cb3 = set1_epi16(3 * 3 * 3 - 1);
                    v128 cb4 = set1_epi16(4 * 4 * 4 - 1);
                    v128 cb5 = set1_epi16(5 * 5 * 5 - 1);

                    v128 result = sub_epi16(    negmask_epi16(cmpgt_epi16(a, cb1)),cmpgt_epi16(a, cb2));
                    result      = sub_epi16(result, add_epi16(cmpgt_epi16(a, cb3), cmpgt_epi16(a, cb4)));
                    result      = sub_epi16(result, cmpgt_epi16(a, cb5));
                    
                    constexpr.ASSUME_LE_EPU16(result, 5);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 cbrt_absepi8_takingAndReturning_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cb1 = mm256_set1_epi16(1 * 1 * 1 - 1);
                    v256 cb2 = mm256_set1_epi16(2 * 2 * 2 - 1);
                    v256 cb3 = mm256_set1_epi16(3 * 3 * 3 - 1);
                    v256 cb4 = mm256_set1_epi16(4 * 4 * 4 - 1);
                    v256 cb5 = mm256_set1_epi16(5 * 5 * 5 - 1);

                    v256 result = Avx2.mm256_sub_epi16(    mm256_negmask_epi16(Avx2.mm256_cmpgt_epi16(a, cb1)),Avx2.mm256_cmpgt_epi16(a, cb2));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb3), Avx2.mm256_cmpgt_epi16(a, cb4)));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, cb5));
                    
                    constexpr.ASSUME_LE_EPU16(result, 5);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu8(v128 a, bool promiseEPI8range = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;

                    if (elements > 8)
                    {
                        if (promiseEPI8range || constexpr.ALL_LT_EPU8(a, 128, elements))
                        {
                            return cbrt_epi8(a, true, elements);
                        }

                        v128 cb1 = set1_epi8(1 * 1 * 1);
                        v128 cb2 = set1_epi8(2 * 2 * 2);
                        v128 cb3 = set1_epi8(3 * 3 * 3);
                        v128 cb4 = set1_epi8(4 * 4 * 4);
                        v128 cb5 = set1_epi8(5 * 5 * 5);
                        v128 cb6 = set1_epi8(6 * 6 * 6);

                        result = sub_epi8(    negmask_epi8(cmpge_epu8(a, cb1)),cmpge_epu8(a, cb2));
                        result = sub_epi8(result, add_epi8(cmpge_epu8(a, cb3), cmpge_epu8(a, cb4)));
                        result = sub_epi8(result, add_epi8(cmpge_epu8(a, cb5), cmpge_epu8(a, cb6)));
                    }
                    else
                    {
                        v128 x = cbrt_epu8_takingAndReturning_epu16(cvtepu8_epi16(a), elements);
                        result = packus_epi16(x, x);
                    }
                        
                    constexpr.ASSUME_LE_EPU8(result, 6);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu8(v256 a, bool promiseEPI8range = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseEPI8range || constexpr.ALL_LT_EPU8(a, 128))
                    {
                        return mm256_cbrt_epi8(a, true);
                    }

                    v256 cb1 = mm256_set1_epi8(1 * 1 * 1);
                    v256 cb2 = mm256_set1_epi8(2 * 2 * 2);
                    v256 cb3 = mm256_set1_epi8(3 * 3 * 3);
                    v256 cb4 = mm256_set1_epi8(4 * 4 * 4);
                    v256 cb5 = mm256_set1_epi8(5 * 5 * 5);
                    v256 cb6 = mm256_set1_epi8(6 * 6 * 6);

                    v256 result = Avx2.mm256_sub_epi8(    mm256_negmask_epi8(mm256_cmpge_epu8(a, cb1)),mm256_cmpge_epu8(a, cb2));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(mm256_cmpge_epu8(a, cb3), mm256_cmpge_epu8(a, cb4)));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(mm256_cmpge_epu8(a, cb5), mm256_cmpge_epu8(a, cb6)));
                    
                    constexpr.ASSUME_LE_EPU8(result, 6);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi8(v128 a, bool promisePositive = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 negative = a;
                    bool NEED_TO_SAVE_SIGN = !(promisePositive || constexpr.ALL_GE_EPI8(a, 0, elements));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        a = abs_epi8(a);
                    }

                    v128 cb1 = set1_epi8(1 * 1 * 1 - 1);
                    v128 cb2 = set1_epi8(2 * 2 * 2 - 1);
                    v128 cb3 = set1_epi8(3 * 3 * 3 - 1);
                    v128 cb4 = set1_epi8(4 * 4 * 4 - 1);
                    v128 cb5 = set1_epi8(5 * 5 * 5 - 1);

                    v128 result = sub_epi8(    negmask_epi8(cmpgt_epi8(a, cb1)),cmpgt_epi8(a, cb2));
                    result      = sub_epi8(result, add_epi8(cmpgt_epi8(a, cb3), cmpgt_epi8(a, cb4)));
                    result      = sub_epi8(result, cmpgt_epi8(a, cb5));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            result = sign_epi8(result, negative);
                        }
                        else
                        {
                            negative = srai_epi8(negative, 7, elements: elements);

                            result = xor_si128(add_epi8(result, negative), negative);
                        }
                    }
                    
                    constexpr.ASSUME_RANGE_EPI8(result, NEED_TO_SAVE_SIGN ? -5 : 0, 5);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi8(v256 a, bool promisePositive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 negative = a;
                    bool NEED_TO_SAVE_SIGN = !(promisePositive || constexpr.ALL_GE_EPI8(a, 0));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        a = mm256_abs_epi8(a);
                    }

                    v256 cb1 = mm256_set1_epi8(1 * 1 * 1 - 1);
                    v256 cb2 = mm256_set1_epi8(2 * 2 * 2 - 1);
                    v256 cb3 = mm256_set1_epi8(3 * 3 * 3 - 1);
                    v256 cb4 = mm256_set1_epi8(4 * 4 * 4 - 1);
                    v256 cb5 = mm256_set1_epi8(5 * 5 * 5 - 1);

                    v256 result = Avx2.mm256_sub_epi8(    mm256_negmask_epi8(Avx2.mm256_cmpgt_epi8(a, cb1)),Avx2.mm256_cmpgt_epi8(a, cb2));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(Avx2.mm256_cmpgt_epi8(a, cb3), Avx2.mm256_cmpgt_epi8(a, cb4)));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_cmpgt_epi8(a, cb5));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        result = Avx2.mm256_sign_epi8(result, negative);
                    }
                    
                    constexpr.ASSUME_RANGE_EPI8(result, NEED_TO_SAVE_SIGN ? -5 : 0, 5);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu16(v128 a, bool promiseByteRange = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promiseByteRange || constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                    {
                        return cbrt_epu8_takingAndReturning_epu16(a, elements);
                    }
                    else
                    {
                        v128 y;
                        v128 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            y = setzero_si128();

                            for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3) 
                            {
                                y = add_epi16(y, y);
                                v128 y3 = add_epi16(y, slli_epi16(y, 1));
                                b = inc_epi16(mullo_epi16(y3, inc_epi16(y)));
                            
                                v128 greaterEqualMask = cmpgt_epi16(b, srli_epi16(a, c, inRange: true));
                                v128 subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, c, inRange: true));
                                v128 addToY = inc_epi16(greaterEqualMask);
                                a = sub_epi16(a, subFromX);
                                y = add_epi16(y, addToY);
                            }
                        }
                        else
                        {
                            v128 greaterEqualMask = srai_epi16(a, 15);
                            y = srli_epi16(a, 15);
                            a = and_si128(a, set1_epi16(0x7FFF));
                            v128 y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(y, y4);
                            b = add_epi16(inc_epi16(b), and_si128(greaterEqualMask, slli_epi16(b, 1)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(a, 12));
                            v128 subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 12));
                            v128 addToY = inc_epi16(greaterEqualMask);
                            a = sub_epi16(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = inc_epi16(mullo_epi16(add_epi16(y, y4), inc_epi16(y)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(a, 9));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 9));
                            addToY = inc_epi16(greaterEqualMask);
                            a = sub_epi16(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = inc_epi16(mullo_epi16(add_epi16(y, y4), inc_epi16(y)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(a, 6));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 6));
                            addToY = inc_epi16(greaterEqualMask);
                            a = sub_epi16(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = inc_epi16(mullo_epi16(add_epi16(y, y4), inc_epi16(y)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(a, 3));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 3));
                            addToY = inc_epi16(greaterEqualMask);
                            a = sub_epi16(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = inc_epi16(mullo_epi16(add_epi16(y, y4), inc_epi16(y)));

                            greaterEqualMask = cmpgt_epi16(b, a);
                            addToY = inc_epi16(greaterEqualMask);
                            y = add_epi16(y, addToY);
                        }

                        constexpr.ASSUME_LE_EPU16(y, 40);
                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu16(v256 a, bool promiseByteRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseByteRange || constexpr.ALL_LE_EPU16(a, byte.MaxValue))
                    {
                        return cbrt_epu8_takingAndReturning_epu16(a);
                    }
                    else
                    {
                        v256 y;
                        v256 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            y = Avx.mm256_setzero_si256();

                            for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3) 
                            {
                                y = Avx2.mm256_add_epi16(y, y);
                                v256 y3 = Avx2.mm256_add_epi16(y, mm256_slli_epi16(y, 1));
                                b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(y3, mm256_inc_epi16(y)));
                            
                                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, mm256_srli_epi16(a, c));
                                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi16(b, c));
                                v256 addToY = mm256_inc_epi16(greaterEqualMask);
                                a = Avx2.mm256_sub_epi16(a, subFromX);
                                y = Avx2.mm256_add_epi16(y, addToY);
                            }
                        }
                        else
                        {
                            v256 greaterEqualMask = Avx2.mm256_srai_epi16(a, 15);
                            y = Avx2.mm256_srli_epi16(a, 15);
                            a = Avx2.mm256_and_si256(a, mm256_set1_epi16(0x7FFF));
                            v256 y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(y, y4);
                            b = Avx2.mm256_add_epi16(mm256_inc_epi16(b), Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 1)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(a, 12));
                            v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 12));
                            v256 addToY = mm256_inc_epi16(greaterEqualMask);
                            a = Avx2.mm256_sub_epi16(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), mm256_inc_epi16(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(a, 9));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 9));
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            a = Avx2.mm256_sub_epi16(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), mm256_inc_epi16(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(a, 6));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 6));
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            a = Avx2.mm256_sub_epi16(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), mm256_inc_epi16(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(a, 3));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 3));
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            a = Avx2.mm256_sub_epi16(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), mm256_inc_epi16(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, a);
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            y = Avx2.mm256_add_epi16(y, addToY);
                        }
                        
                        constexpr.ASSUME_LE_EPU16(y, 40);
                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi16(v128 a, bool promiseAbsolute = false, bool promise8BitRange = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;

                    if (promiseAbsolute || constexpr.ALL_GE_EPI16(a, 0, elements))
                    {
                        result = cbrt_epu16(a, promise8BitRange, elements);

                        constexpr.ASSUME_RANGE_EPI16(result, 0, 32);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            result = sign_epi16(cbrt_epu16(abs_epi16(a), promise8BitRange, elements), a);
                        }
                        else
                        {
                            v128 negative = srai_epi16(a, 15);
                            v128 cbrtAbs = cbrt_epu16(xor_si128(add_epi16(a, negative), negative), promise8BitRange, elements);

                            result = xor_si128(add_epi16(cbrtAbs, negative), negative);
                        }

                        constexpr.ASSUME_RANGE_EPI16(result, -32, 32);
                    }
                        
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi16(v256 a, bool promiseAbsolute = false, bool promise8BitRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (promiseAbsolute || constexpr.ALL_GE_EPI16(a, 0))
                    {
                        result = mm256_cbrt_epu16(a, promise8BitRange);

                        constexpr.ASSUME_RANGE_EPI16(result, 0, 32);
                    }
                    else
                    {
                        result = Avx2.mm256_sign_epi16(mm256_cbrt_epu16(mm256_abs_epi16(a), promise8BitRange), a);

                        constexpr.ASSUME_RANGE_EPI16(result, -32, 32);
                    }
                        
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu32(v128 a, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                        {
                            return cbrt_epu8_takingAndReturning_epu16(a);
                        }
                        else
                        {
                            v128 y;
                            v128 b;
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                y = setzero_si128();

                                for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3) 
                                {
                                    y = add_epi32(y, y);
                                    v128 y3 = add_epi32(y, slli_epi32(y, 1));
                                    b = inc_epi32(mullo_epi32(y3, inc_epi32(y)));
                                
                                    v128 greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, c, inRange: true));
                                    v128 subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, c, inRange: true));
                                    v128 addToY = inc_epi32(greaterEqualMask);
                                    a = sub_epi32(a, subFromX);
                                    y = add_epi32(y, addToY);
                                }
                            }
                            else
                            {
                                v128 ONE = set1_epi32(1);

                                v128 greaterEqualMask = srai_epi32(slli_epi32(a, 16), 31);
                                v128 subFromX = and_si128(greaterEqualMask, slli_epi32(ONE, 15));
                                y = srli_epi32(a, 15);
                                a = sub_epi32(a, subFromX);
                                v128 y4 = slli_epi32(y, 2);
                                y = add_epi32(y, y);
                                b = add_epi32(y, y4);
                                b = add_epi32(inc_epi32(b), and_si128(greaterEqualMask, slli_epi32(b, 1)));

                                greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 12));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 12));
                                v128 addToY = inc_epi32(greaterEqualMask);
                                a = sub_epi32(a, subFromX);
                                y = add_epi16(y, addToY);
                                y4 = slli_epi16(y, 2);
                                y = add_epi16(y, y);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                                greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 9));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 9));
                                addToY = inc_epi32(greaterEqualMask);
                                a = sub_epi32(a, subFromX);
                                y = add_epi16(y, addToY);
                                y4 = slli_epi16(y, 2);
                                y = add_epi16(y, y);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                                greaterEqualMask = cmpgt_epi32(b,srli_epi32(a, 6));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 6));
                                addToY = inc_epi32(greaterEqualMask);
                                a = sub_epi32(a, subFromX);
                                y = add_epi16(y, addToY);
                                y4 = slli_epi16(y, 2);
                                y = add_epi16(y, y);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                                greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 3));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 3));
                                addToY = inc_epi32(greaterEqualMask);
                                a = sub_epi32(a, subFromX);
                                y = add_epi16(y, addToY);
                                y4 = slli_epi16(y, 2);
                                y = add_epi16(y, y);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                                greaterEqualMask = cmpgt_epi32(b, a);
                                addToY = inc_epi32(greaterEqualMask);
                                y = add_epi32(y, addToY);
                            }
                            
                            constexpr.ASSUME_LE_EPU32(y, 40);
                            return y;
                        }
                    }
                    else
                    {
                        v128 y;
                        v128 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            y = setzero_si128();
                        
                            for (int c = sizeof(uint) * 8 / 3 * 3; c >= 0; c -= 3) 
                            {
                                y = add_epi32(y, y);
                                v128 y3 = add_epi32(y, slli_epi32(y, 1));
                                b = inc_epi32(mullo_epi32(y3, inc_epi32(y)));
                            
                                v128 greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, c, inRange: true));
                                v128 subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, c, inRange: true));
                                v128 addToY = inc_epi32(greaterEqualMask);
                                a = sub_epi32(a, subFromX);
                                y = add_epi32(y, addToY);
                            }
                        }
                        else
                        {
                            v128 ONE = set1_epi32(1);

                            v128 greaterEqualMask = cmpgt_epi32(ONE, srli_epi32(a, 30));
                            v128 subFromX = andnot_si128(greaterEqualMask, slli_epi32(ONE, 30));
                            y = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            v128 y4 = slli_epi32(y, 2);
                            y = add_epi32(y, y);
                            b = add_epi32(y, y4);
                            b = add_epi32(inc_epi32(b), andnot_si128(greaterEqualMask, slli_epi32(b, 1)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 27));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 27));
                            v128 addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 24));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 24));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 21));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 21));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 18));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 18));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 15));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 15));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 12));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 12));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi32(y, addToY);
                            y4 = slli_epi32(y, 2);
                            y = add_epi32(y, y);
                            b = inc_epi32(mullo_epi32(add_epi32(y, y4), inc_epi32(y), elements));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 9));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 9));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi32(y, addToY);
                            y4 = slli_epi32(y, 2);
                            y = add_epi32(y, y);
                            b = inc_epi32(mullo_epi32(add_epi32(y, y4), inc_epi32(y), elements));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 6));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 6));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi32(y, addToY);
                            y4 = slli_epi32(y, 2);
                            y = add_epi32(y, y);
                            b = inc_epi32(mullo_epi32(add_epi32(y, y4), inc_epi32(y), elements));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(a, 3));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 3));
                            addToY = inc_epi32(greaterEqualMask);
                            a = sub_epi32(a, subFromX);
                            y = add_epi32(y, addToY);
                            y4 = slli_epi32(y, 2);
                            y = add_epi32(y, y);
                            b = inc_epi32(mullo_epi32(add_epi32(y, y4), inc_epi32(y), elements));

                            greaterEqualMask = cmpgt_epi32(b, a);
                            addToY = inc_epi32(greaterEqualMask);
                            y = add_epi32(y, addToY);
                        }
                        
                        constexpr.ASSUME_LE_EPU32(y, 1_625);
                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu32(v256 a, byte rangePromiseLevel = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU32(a, ushort.MaxValue))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            return cbrt_epu8_takingAndReturning_epu16(a);
                        }
                        else
                        {
                            v256 y;
                            v256 b;
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                y = Avx.mm256_setzero_si256();

                                for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3) 
                                {
                                    y = Avx2.mm256_add_epi32(y, y);
                                    v256 y3 = Avx2.mm256_add_epi32(y, mm256_slli_epi32(y, 1));
                                    b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(y3, mm256_inc_epi32(y)));
                                
                                    v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, mm256_srli_epi32(a, c));
                                    v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi32(b, c));
                                    v256 addToY = mm256_inc_epi32(greaterEqualMask);
                                    a = Avx2.mm256_sub_epi32(a, subFromX);
                                    y = Avx2.mm256_add_epi32(y, addToY);
                                }
                            }
                            else
                            {
                                v256 ONE = mm256_set1_epi32(1);

                                v256 greaterEqualMask = Avx2.mm256_srai_epi32(Avx2.mm256_slli_epi32(a, 16), 31);
                                v256 subFromX = Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi16(ONE, 15));
                                y = Avx2.mm256_srli_epi32(a, 15);
                                a = Avx2.mm256_sub_epi32(a, subFromX);
                                v256 y4 = Avx2.mm256_slli_epi32(y, 2);
                                y = Avx2.mm256_add_epi32(y, y);
                                b = Avx2.mm256_add_epi32(y, y4);
                                b = Avx2.mm256_add_epi32(mm256_inc_epi32(b), Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 1)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 12));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 12));
                                v256 addToY = mm256_inc_epi32(greaterEqualMask);
                                a = Avx2.mm256_sub_epi32(a, subFromX);
                                y = Avx2.mm256_add_epi16(y, addToY);
                                y4 = Avx2.mm256_slli_epi16(y, 2);
                                y = Avx2.mm256_add_epi16(y, y);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 9));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 9));
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                a = Avx2.mm256_sub_epi32(a, subFromX);
                                y = Avx2.mm256_add_epi16(y, addToY);
                                y4 = Avx2.mm256_slli_epi16(y, 2);
                                y = Avx2.mm256_add_epi16(y, y);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 6));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 6));
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                a = Avx2.mm256_sub_epi32(a, subFromX);
                                y = Avx2.mm256_add_epi16(y, addToY);
                                y4 = Avx2.mm256_slli_epi16(y, 2);
                                y = Avx2.mm256_add_epi16(y, y);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 3));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 3));
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                a = Avx2.mm256_sub_epi32(a, subFromX);
                                y = Avx2.mm256_add_epi16(y, addToY);
                                y4 = Avx2.mm256_slli_epi16(y, 2);
                                y = Avx2.mm256_add_epi16(y, y);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, a);
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                y = Avx2.mm256_add_epi32(y, addToY);
                            }
                            
                            constexpr.ASSUME_LE_EPU32(y, 40);
                            return y;
                        }
                    }
                    else
                    {
                        v256 y;
                        v256 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            y = Avx.mm256_setzero_si256();
                        
                            for (int c = sizeof(uint) * 8 / 3 * 3; c >= 0; c -= 3) 
                            {
                                y = Avx2.mm256_add_epi32(y, y);
                                v256 y3 = Avx2.mm256_add_epi32(y, mm256_slli_epi32(y, 1));
                                b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(y3, mm256_inc_epi32(y)));
                            
                                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, mm256_srli_epi32(a, c));
                                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi32(b, c));
                                v256 addToY = mm256_inc_epi32(greaterEqualMask);
                                a = Avx2.mm256_sub_epi32(a, subFromX);
                                y = Avx2.mm256_add_epi32(y, addToY);
                            }
                        }
                        else
                        {
                            v256 ONE = mm256_set1_epi32(1);

                            v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(ONE, Avx2.mm256_srli_epi32(a, 30));
                            v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(ONE, 30));
                            y = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            v256 y4 = Avx2.mm256_slli_epi32(y, 2);
                            y = Avx2.mm256_add_epi32(y, y);
                            b = Avx2.mm256_add_epi32(y, y4);
                            b = Avx2.mm256_add_epi32(mm256_inc_epi32(b), Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 1)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 27));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 27));
                            v256 addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 24));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 24));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 21));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 21));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 18));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 18));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 15));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 15));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 12));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 12));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi32(y, addToY);
                            y4 = Avx2.mm256_slli_epi32(y, 2);
                            y = Avx2.mm256_add_epi32(y, y);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, y4), mm256_inc_epi32(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 9));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 9));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi32(y, addToY);
                            y4 = Avx2.mm256_slli_epi32(y, 2);
                            y = Avx2.mm256_add_epi32(y, y);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, y4), mm256_inc_epi32(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 6));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 6));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi32(y, addToY);
                            y4 = Avx2.mm256_slli_epi32(y, 2);
                            y = Avx2.mm256_add_epi32(y, y);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, y4), mm256_inc_epi32(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 3));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 3));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi32(y, addToY);
                            y4 = Avx2.mm256_slli_epi32(y, 2);
                            y = Avx2.mm256_add_epi32(y, y);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(y, y4), mm256_inc_epi32(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, a);
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            y = Avx2.mm256_add_epi32(y, addToY);
                        }
                        
                        constexpr.ASSUME_LE_EPU32(y, 1_625);
                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi32(v128 a, bool promiseAbsolute = false, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;

                    if (promiseAbsolute || constexpr.ALL_GE_EPI32(a, 0, elements))
                    {
                        result = cbrt_epu32(a, rangePromiseLevel, elements);

                        constexpr.ASSUME_RANGE_EPI32(result, 0, 1_290);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            result = sign_epi32(cbrt_epu32(abs_epi32(a), rangePromiseLevel, elements), a);
                        }
                        else
                        {
                            v128 negative = srai_epi32(a, 31);
                            v128 cbrtAbs = cbrt_epu32(xor_si128(add_epi32(a, negative), negative), rangePromiseLevel, elements);

                            result = xor_si128(add_epi32(cbrtAbs, negative), negative);
                        }

                        constexpr.ASSUME_RANGE_EPI32(result, -1_290, 1_290);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi32(v256 a, bool promiseAbsolute = false, byte rangePromiseLevel = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    
                    if (promiseAbsolute || constexpr.ALL_GE_EPI32(a, 0))
                    {
                        result = mm256_cbrt_epu32(a);

                        constexpr.ASSUME_RANGE_EPI32(result, 0, 1_290);
                    }
                    else
                    {
                        result = Avx2.mm256_sign_epi32(mm256_cbrt_epu32(mm256_abs_epi32(a), rangePromiseLevel), a);

                        constexpr.ASSUME_RANGE_EPI32(result, -1_290, 1_290);
                    }
                        
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu64(v128 a, byte rangePromiseLevel = 0)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU64(a, 1ul << 48))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                        {
                            if (rangePromiseLevel > 2 || constexpr.ALL_LE_EPU64(a, ushort.MaxValue))
                            {
                                if (rangePromiseLevel > 3 || constexpr.ALL_LE_EPU64(a, byte.MaxValue))
                                {
                                    return cbrt_epu8_takingAndReturning_epu16(a, 8);
                                }
                                else
                                {
                                    return cbrt_epu16(a);
                                }
                            }
                            else
                            {
                                return cbrt_epu32(a, 0, 4);
                            }
                        }
                        else
                        {
                            // results within [0, 1ul << 48] have been proven to be correct empirically both with and without FMA instructions
                            v128 result = cvttpd_epu64(cbrt_pd(usfcvtepu64_pd(a), promisePositive: true, promiseNormalized: true));

                            constexpr.ASSUME_LE_EPU64(result, 65536 /*maxmath.intcbrt(1ul << 48)*/);
                            return result;
                        }
                    }
                    else
                    {
                        v128 y;
                        v128 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            y = setzero_si128();
                        
                            for (int c = sizeof(ulong) * 8 / 3 * 3; c >= 0; c -= 3) 
                            {
                                y = add_epi64(y, y);
                                v128 y3 = add_epi64(y, slli_epi64(y, 1));
                                b = inc_epi64(mul_epu32(y3, inc_epi64(y)));
                            
                                v128 greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, c, inRange: true));
                                v128 subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, c, inRange: true));
                                v128 addToY = inc_epi64(greaterEqualMask);
                                a = sub_epi64(a, subFromX);
                                y = add_epi64(y, addToY);
                            }
                        }
                        else
                        {
                            v128 ONE = set1_epi64x(1);

                            y = srli_epi64(a, 63);
                            v128 greaterEqualMask = neg_epi64(y);
                            a = and_si128(a, set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));
                            v128 y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = add_epi64(y, y4);
                            b = add_epi64(inc_epi64(b), and_si128(greaterEqualMask, slli_epi64(b, 1)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 60));
                            v128 subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 60));
                            v128 addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 57));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 57));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 54));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 54));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 51));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 51));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 48));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 48));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi16(y, addToY);
                            y4 = slli_epi16(y, 2);
                            y = add_epi16(y, y);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(y, y4), add_epi16(ONE, y))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 45));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 45));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 42));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 42));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 39));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 39));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 36));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 36));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(a, 33));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 33));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 30));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 30));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 27));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 27));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 24));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 24));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 21));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 21));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 18));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 18));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 15));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 15));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 12));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 12));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 9));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 9));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 6));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 6));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(a, 3));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 3));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            a = sub_epi64(a, subFromX);
                            y = add_epi64(y, addToY);
                            y4 = slli_epi64(y, 2);
                            y = add_epi64(y, y);
                            b = inc_epi64(mul_epu32(add_epi64(y, y4), inc_epi64(y)));

                            greaterEqualMask = cmpgt_epi64(b, a);
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            y = add_epi64(y, addToY);
                        }

                        constexpr.ASSUME_LE_EPU64(y, 2_642_245);
                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu64(v256 a, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU64(a, 1ul << 48, elements))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                        {
                            if (rangePromiseLevel > 2 || constexpr.ALL_LE_EPU64(a, ushort.MaxValue, elements))
                            {
                                if (rangePromiseLevel > 3 || constexpr.ALL_LE_EPU64(a, byte.MaxValue, elements))
                                {
                                    return cbrt_epu8_takingAndReturning_epu16(a);
                                }
                                else
                                {
                                    return mm256_cbrt_epu16(a);
                                }
                            }
                            else
                            {
                                return mm256_cbrt_epu32(a);
                            }
                        }
                        else
                        {
                            // results within [0, 1ul << 48] have been proven to be correct empirically both with and without FMA instructions
                            v256 result = mm256_cvttpd_epu64(mm256_cbrt_pd(mm256_usfcvtepu64_pd(a), promisePositive: true, promiseNormalized: true), elements);

                            constexpr.ASSUME_LE_EPU64(result, 65536 /*maxmath.intcbrt(1ul << 48)*/, elements);
                            return result;
                        }
                    }
                    else
                    {
                        v256 y;
                        v256 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            y = Avx.mm256_setzero_si256();
                        
                            for (int c = sizeof(ulong) * 8 / 3 * 3; c >= 0; c -= 3) 
                            {
                                y = Avx2.mm256_add_epi64(y, y);
                                v256 y3 = Avx2.mm256_add_epi64(y, mm256_slli_epi64(y, 1));
                                b = mm256_inc_epi64(Avx2.mm256_mul_epu32(y3, mm256_inc_epi64(y)));
                            
                                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, mm256_srli_epi64(a, c));
                                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi64(b, c));
                                v256 addToY = mm256_inc_epi64(greaterEqualMask);
                                a = Avx2.mm256_sub_epi64(a, subFromX);
                                y = Avx2.mm256_add_epi64(y, addToY);
                            }
                        }
                        else
                        {
                            v256 ONE = mm256_set1_epi64x(1);

                            y = Avx2.mm256_srli_epi64(a, 63);
                            v256 greaterEqualMask = mm256_neg_epi64(y);
                            a = Avx2.mm256_and_si256(a, mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));
                            v256 y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = Avx2.mm256_add_epi64(y, y4);
                            b = Avx2.mm256_add_epi64(mm256_inc_epi64(b), Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 1)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 60));
                            v256 subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 60));
                            v256 addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 57));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 57));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 54));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 54));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 51));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 51));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 48));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 48));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 45));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 45));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 42));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 42));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 39));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 39));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 36));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 36));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(a, 33));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 33));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 30));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 30));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 27));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 27));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 24));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 24));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 21));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 21));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 18));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 18));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 15));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 15));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 12));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 12));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 9));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 9));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 6));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 6));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(a, 3));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 3));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            a = Avx2.mm256_sub_epi64(a, subFromX);
                            y = Avx2.mm256_add_epi64(y, addToY);
                            y4 = Avx2.mm256_slli_epi64(y, 2);
                            y = Avx2.mm256_add_epi64(y, y);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(y, y4), mm256_inc_epi64(y)));

                            greaterEqualMask = mm256_cmpgt_epi64(b, a);
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            y = Avx2.mm256_add_epi64(y, addToY);
                        }
                        
                        constexpr.ASSUME_LE_EPU64(y, 2_642_245);
                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi64(v128 a, bool promiseAbs = false, byte rangePromiseLevel = 0)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI64(a, 0))
                    {
                        result = cbrt_epu64(a, rangePromiseLevel);

                        constexpr.ASSUME_RANGE_EPI64(result, 0, 2_097_152);
                    }
                    else
                    {
                        v128 negative = srai_epi64(a, 63);
                        v128 cbrtAbs = cbrt_epu64(xor_si128(add_epi64(a, negative), negative), rangePromiseLevel);

                        result = xor_si128(add_epi64(cbrtAbs, negative), negative);

                        constexpr.ASSUME_RANGE_EPI64(result, -2_097_152, 2_097_152);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi64(v256 a, bool promiseAbs = false, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI64(a, 0, elements))
                    {
                        result = mm256_cbrt_epu64(a, rangePromiseLevel, elements);

                        constexpr.ASSUME_RANGE_EPI64(result, 0, 2_097_152);
                    }
                    else
                    {
                        v256 negative = mm256_srai_epi64(a, 63, elements);
                        v256 cbrtAbs = mm256_cbrt_epu64(Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(a, negative), negative), rangePromiseLevel, elements);

                        result = Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(cbrtAbs, negative), negative);

                        constexpr.ASSUME_RANGE_EPI64(result, -2_097_152, 2_097_152);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="UInt128"/>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ulong.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 6_981_463_658_331ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intcbrt(UInt128 x, Promise promises = Promise.Nothing)
        {
            if (promises.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(x.hi64 == 0))
            {
                promises.DemoteUnsafeLevels();

                return intcbrt(x.lo64, promises);
            }

            ulong y = 0;
            UInt128 b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                for (int c = sizeof(UInt128) * 8 / 3 * 3; c >= 0; c -= 3) 
                {
                    y += y;
                    b = ((UInt128)(3 * y) * (y + 1)) + 1;
                    if (x >> c >= b)
                    {
                        x -= b << c; 
                        y++;
                    }
                }
            }
            else
            {
                b = (UInt128)1 << 126;

                if ((x.hi64 >> (126 - 64)) != 0)
                {
                    x -= b;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (123 - 64)) >= b.lo64)
                {
                    x -= b << 123;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (120 - 64)) >= b.lo64)
                {
                    x -= b << 120;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (117 - 64)) >= b.lo64)
                {
                    x -= b << 117;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (114 - 64)) >= b.lo64)
                {
                    x -= b << 114;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (111 - 64)) >= b.lo64)
                {
                    x -= b << 111;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (108 - 64)) >= b.lo64)
                {
                    x -= b << 108;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (105 - 64)) >= b.lo64)
                {
                    x -= b << 105;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (102 - 64)) >= b.lo64)
                {
                    x -= b << 102;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (99 - 64)) >= b.lo64)
                {
                    x -= b << 99;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (96 - 64)) >= b.lo64)
                {
                    x -= b << 96;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (93 - 64)) >= b.lo64)
                {
                    x -= b << 93;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (90 - 64)) >= b.lo64)
                {
                    x -= b << 90;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (87 - 64)) >= b.lo64)
                {
                    x -= b << 87;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (84 - 64)) >= b.lo64)
                {
                    x -= b << 84;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (81 - 64)) >= b.lo64)
                {
                    x -= b << 81;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (78 - 64)) >= b.lo64)
                {
                    x -= b << 78;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (75 - 64)) >= b.lo64)
                {
                    x -= b << 75;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (72 - 64)) >= b.lo64)
                {
                    x -= b << 72;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (69 - 64)) >= b.lo64)
                {
                    x -= b << 69;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x.hi64 >> (66 - 64)) >= b.lo64)
                {
                    x -= b << 66;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 63) >= b.lo64)
                {
                    x -= b << 63;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 60) >= b.lo64)
                {
                    x -= b << 60;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 57) >= b.lo64)
                {
                    x -= b << 57;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 54) >= b.lo64)
                {
                    x -= b << 54;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 51) >= b.lo64)
                {
                    x -= b << 51;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 48) >= b.lo64)
                {
                    x -= b << 48;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 45) >= b.lo64)
                {
                    x -= b << 45;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 42) >= b.lo64)
                {
                    x -= b << 42;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 39) >= b.lo64)
                {
                    x -= b << 39;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;    // ((1704458887ul * 3) * (1704458887ul + 1)) + 1 at max; last safe ulong

                if ((x >> 36) >= b.lo64)
                {
                    x -= b << 36;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 33) >= b)
                {
                    x -= b << 33;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 30) >= b)
                {
                    x -= b << 30;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 27) >= b)
                {
                    x -= b << 27;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 24) >= b)
                {
                    x -= b << 24;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 21) >= b)
                {
                    x -= b << 21;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 18) >= b)
                {
                    x -= b << 18;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 15) >= b)
                {
                    x -= b << 15;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 12) >= b)
                {
                    x -= b << 12;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 9) >= b)
                {
                    x -= b << 9;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 6) >= b)
                {
                    x -= b << 6;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((x >> 3) >= b)
                {
                    x -= b << 3;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                y += tobyte(x >= b);
            }

            return y;
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="Int128"/>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ulong.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ulong.MaxValue"/>, <see cref="ulong.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-5_541_191_377_756L, 5_541_191_377_756L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intcbrt(Int128 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                promises.DemoteUnsafeLevels();
                promises |= Promise.ZeroOrGreater;

                return (long)intcbrt((UInt128)x, promises);
            }
            else
            {
                bool negative = (long)x.hi64 < 0;
                ulong cbrtAbs = intcbrt((UInt128)abs(x), promises);

                return math.select((long)cbrtAbs, -(long)cbrtAbs, negative);
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte"/>.   </summary>
        [return: AssumeRange(0ul, 6ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte intcbrt(byte x)
        {
            uint _x = x;
            uint y = 0;
            uint b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                for (int c = sizeof(byte) * 8 / 3 * 3; c >= 0; c -= 3) 
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (_x >> c >= b)
                    {
                        _x -= b << c; 
                        y++;
                    }
                }
            }
            else
            {
                b = 1;

                if ((_x >> 6) != 0)
                {
                    _x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((_x >> 3) >= b)
                {
                    _x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(_x >= b);
            }

            return (byte)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte2"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intcbrt(byte2 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new byte2(intcbrt(x.x), intcbrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte3"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intcbrt(byte3 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new byte3(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte4"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intcbrt(byte4 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new byte4(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z), intcbrt(x.w));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte8"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intcbrt(byte8 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new byte8(intcbrt(x.x0),
                                 intcbrt(x.x1),
                                 intcbrt(x.x2),
                                 intcbrt(x.x3),
                                 intcbrt(x.x4),
                                 intcbrt(x.x5),
                                 intcbrt(x.x6),
                                 intcbrt(x.x7));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte16"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intcbrt(byte16 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 16);
            }
            else
            {
                return new byte16(intcbrt(x.x0),
                                  intcbrt(x.x1),
                                  intcbrt(x.x2),
                                  intcbrt(x.x3),
                                  intcbrt(x.x4),
                                  intcbrt(x.x5),
                                  intcbrt(x.x6),
                                  intcbrt(x.x7),
                                  intcbrt(x.x8),
                                  intcbrt(x.x9),
                                  intcbrt(x.x10),
                                  intcbrt(x.x11),
                                  intcbrt(x.x12),
                                  intcbrt(x.x13),
                                  intcbrt(x.x14),
                                  intcbrt(x.x15));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte32"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intcbrt(byte32 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte32(intcbrt(x.v16_0, absSByteRange), intcbrt(x.v16_16, absSByteRange));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-5, 5)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte intcbrt(sbyte x, Promise nonNegative = Promise.Nothing)
        {
            if (nonNegative.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (sbyte)intcbrt((byte)x);
            }
            else
            {
                bool negative = x < 0;
                byte cbrtAbs = intcbrt((byte)math.select(x, -x, negative));

                return select((sbyte)cbrtAbs, (sbyte)-(sbyte)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte2"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intcbrt(sbyte2 x, Promise nonNegative = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                return new sbyte2(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte3"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intcbrt(sbyte3 x, Promise nonNegative = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new sbyte3(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative),  intcbrt(x.z, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte4"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intcbrt(sbyte4 x, Promise nonNegative = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new sbyte4(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative),  intcbrt(x.z, nonNegative),  intcbrt(x.w, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte8"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intcbrt(sbyte8 x, Promise nonNegative = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                return new sbyte8(intcbrt(x.x0, nonNegative),
                                  intcbrt(x.x1, nonNegative),
                                  intcbrt(x.x2, nonNegative),
                                  intcbrt(x.x3, nonNegative),
                                  intcbrt(x.x4, nonNegative),
                                  intcbrt(x.x5, nonNegative),
                                  intcbrt(x.x6, nonNegative),
                                  intcbrt(x.x7, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte16"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intcbrt(sbyte16 x, Promise nonNegative = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 16);
            }
            else
            {
                return new sbyte16(intcbrt(x.x0,  nonNegative),
                                   intcbrt(x.x1,  nonNegative),
                                   intcbrt(x.x2,  nonNegative),
                                   intcbrt(x.x3,  nonNegative),
                                   intcbrt(x.x4,  nonNegative),
                                   intcbrt(x.x5,  nonNegative),
                                   intcbrt(x.x6,  nonNegative),
                                   intcbrt(x.x7,  nonNegative),
                                   intcbrt(x.x8,  nonNegative),
                                   intcbrt(x.x9,  nonNegative),
                                   intcbrt(x.x10, nonNegative),
                                   intcbrt(x.x11, nonNegative),
                                   intcbrt(x.x12, nonNegative),
                                   intcbrt(x.x13, nonNegative),
                                   intcbrt(x.x14, nonNegative),
                                   intcbrt(x.x15, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte32"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intcbrt(sbyte32 x, Promise nonNegative = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(intcbrt(x.v16_0, nonNegative), intcbrt(x.v16_16, nonNegative));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 40ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort intcbrt(ushort x, Promise byteRange = Promise.Nothing)
        {
            if (byteRange.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intcbrt((byte)x);
            }
            
            uint _x = x;
            uint y;
            uint b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                y = 0;

                for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3) 
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (_x >> c >= b)
                    {
                        _x -= b << c; 
                        y++;
                    }
                }
            }
            else
            {
                y = _x >> 15;
                _x &= 0x7FFF;

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((_x >> 12) >= b)
                {
                    _x -= b << 12;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((_x >> 9) >= b)
                {
                    _x -= b << 9;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((_x >> 6) >= b)
                {
                    _x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((_x >> 3) >= b)
                {
                    _x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(_x >= b);
            }

            return (ushort)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort2"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intcbrt(ushort2 x, Promise byteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new ushort2(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort3"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intcbrt(ushort3 x, Promise byteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new ushort3(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange), intcbrt(x.z, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort4"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intcbrt(ushort4 x, Promise byteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new ushort4(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange), intcbrt(x.z, byteRange), intcbrt(x.w, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort8"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intcbrt(ushort8 x, Promise byteRange = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new ushort8(intcbrt(x.x0, byteRange),
                                   intcbrt(x.x1, byteRange),
                                   intcbrt(x.x2, byteRange),
                                   intcbrt(x.x3, byteRange),
                                   intcbrt(x.x4, byteRange),
                                   intcbrt(x.x5, byteRange),
                                   intcbrt(x.x6, byteRange),
                                   intcbrt(x.x7, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort16"/>.
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intcbrt(ushort16 x, Promise byteRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort16(intcbrt(x.v8_0, byteRange), intcbrt(x.v8_8, byteRange));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-32, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short intcbrt(short x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (short)intcbrt((ushort)x, promises);
            }
            else
            {
                bool negative = x < 0;
                ushort cbrtAbs = intcbrt((ushort)math.select(x, -x, negative), promises);

                return select((short)cbrtAbs, (short)-(short)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intcbrt(short2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new short2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intcbrt(short3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new short3(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intcbrt(short4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new short4(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises), intcbrt(x.w, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intcbrt(short8 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new short8(intcbrt(x.x0, promises),
                                  intcbrt(x.x1, promises),
                                  intcbrt(x.x2, promises),
                                  intcbrt(x.x3, promises),
                                  intcbrt(x.x4, promises),
                                  intcbrt(x.x5, promises),
                                  intcbrt(x.x6, promises),
                                  intcbrt(x.x7, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short16"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intcbrt(short16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short16(intcbrt(x.v8_0, promises), intcbrt(x.v8_8, promises));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 1_625ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intcbrt(uint x, Promise promises = Promise.Nothing)
        {
            if (promises.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                promises.DemoteUnsafeLevels();

                return intcbrt((ushort)x, promises);
            }

            uint y = 0;
            uint b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                for (int c = sizeof(uint) * 8 / 3 * 3; c >= 0; c -= 3) 
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (x >> c >= b)
                    {
                        x -= b << c; 
                        y++;
                    }
                }
            }
            else
            {
                b = 1;

                if ((x >> 30) != 0)
                {
                    x -= b << 30;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 27) >= b)
                {
                    x -= b << 27;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 24) >= b)
                {
                    x -= b << 24;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 21) >= b)
                {
                    x -= b << 21;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 18) >= b)
                {
                    x -= b << 18;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 15) >= b)
                {
                    x -= b << 15;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 12) >= b)
                {
                    x -= b << 12;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 9) >= b)
                {
                    x -= b << 9;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 6) >= b)
                {
                    x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 3) >= b)
                {
                    x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(x >= b);
            }

            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intcbrt(uint2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.cbrt_epu32(RegisterConversion.ToV128(x), promises.CountUnsafeLevels(), 2));
            }
            else
            {
                return new uint2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intcbrt(uint3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cbrt_epu32(RegisterConversion.ToV128(x), promises.CountUnsafeLevels(), 3));
            }
            else
            {
                return new uint3(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intcbrt(uint4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.cbrt_epu32(RegisterConversion.ToV128(x), promises.CountUnsafeLevels(), 4));
            }
            else
            {
                return new uint4(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises), intcbrt(x.w, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.uint8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intcbrt(uint8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu32(x, promises.CountUnsafeLevels());
            }
            else
            {
                return new uint8(intcbrt(x.v4_0, promises), intcbrt(x.v4_4, promises));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-1_290, 1_290)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intcbrt(int x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (int)intcbrt((uint)x, promises);
            }
            else
            {
                bool negative = x < 0;
                uint cbrtAbs = intcbrt((uint)math.select(x, -x, negative), promises);

                return math.select((int)cbrtAbs, -(int)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intcbrt(int2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cbrt_epi32(RegisterConversion.ToV128(x), promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 2));
            }
            else
            {
                return new int2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intcbrt(int3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cbrt_epi32(RegisterConversion.ToV128(x), promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 3));
            }
            else
            {
                return new int3(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intcbrt(int4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cbrt_epi32(RegisterConversion.ToV128(x), promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 4));
            }
            else
            {
                return new int4(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises), intcbrt(x.w, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.int8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intcbrt(int8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi32(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels());
            }
            else
            {
                return new int8(intcbrt(x.v4_0, promises), intcbrt(x.v4_4, promises));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ulong"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 2_642_245ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intcbrt(ulong x, Promise promises = Promise.Nothing)
        {
            if (promises.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                promises.DemoteUnsafeLevels();

                return intcbrt((uint)x, promises);
            }
            
            ulong y;
            ulong b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                y = 0;
                for (int c = sizeof(ulong) * 8 / 3 * 3; c >= 0; c -= 3) 
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (x >> c >= b)
                    {
                        x -= b << c; 
                        y++;
                    }
                }
            }
            else
            {
                y = x >> 63;
                x &= 0x7FFF_FFFF_FFFF_FFFF;

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 60) >= b)
                {
                    x -= b << 60;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 57) >= b)
                {
                    x -= b << 57;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 54) >= b)
                {
                    x -= b << 54;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 51) >= b)
                {
                    x -= b << 51;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 48) >= b)
                {
                    x -= b << 48;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 45) >= b)
                {
                    x -= b << 45;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 42) >= b)
                {
                    x -= b << 42;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 39) >= b)
                {
                    x -= b << 39;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 36) >= b)
                {
                    x -= b << 36;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 33) >= b)
                {
                    x -= b << 33;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 30) >= b)
                {
                    x -= b << 30;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 27) >= b)
                {
                    x -= b << 27;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 24) >= b)
                {
                    x -= b << 24;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 21) >= b)
                {
                    x -= b << 21;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 18) >= b)
                {
                    x -= b << 18;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 15) >= b)
                {
                    x -= b << 15;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 12) >= b)
                {
                    x -= b << 12;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 9) >= b)
                {
                    x -= b << 9;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 6) >= b)
                {
                    x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((x >> 3) >= b)
                {
                    x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(x >= b);
            }

            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intcbrt(ulong2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu64(x, promises.CountUnsafeLevels());
            }
            else
            {
                promises.DemoteUnsafeLevels();

                return new ulong2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intcbrt(ulong3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu64(x, promises.CountUnsafeLevels(), 3);
            }
            else
            {
                ulong2 xy = intcbrt(x.xy, promises);

                promises.DemoteUnsafeLevels();

                ulong z = intcbrt(x.z, promises);

                return new ulong3(xy, z);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intcbrt(ulong4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu64(x, promises.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ulong4(intcbrt(x.xy, promises), intcbrt(x.zw, promises));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="long"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-2_097_152, 2_097_152)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intcbrt(long x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (long)intcbrt((ulong)x, promises);
            }
            else
            {
                bool negative = x < 0;
                ulong cbrtAbs = intcbrt((ulong)math.select(x, -x, negative), promises);

                return math.select((long)cbrtAbs, -(long)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.long2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 48), 1ul &lt;&lt; 48] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intcbrt(long2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi64(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels());
            }
            else
            {
                promises.DemoteUnsafeLevels();
                promises |= promises.Promises(Promise.ZeroOrGreater) ? Promise.ZeroOrGreater : Promise.Nothing;

                return new long2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.long3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 47] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 48), 1ul &lt;&lt; 48] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intcbrt(long3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi64(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 3);
            }
            else
            {
                long2 xy = intcbrt(x.xy, promises);

                promises.DemoteUnsafeLevels();
                promises = promises.Promises(Promise.ZeroOrGreater) ? Promise.ZeroOrGreater : Promise.Nothing;

                long z = intcbrt(x.z, promises);

                return new long3(xy, z);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.long4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 47] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 48), 1ul &lt;&lt; 48] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intcbrt(long4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi64(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 4);
            }
            else
            {
                return new long4(intcbrt(x.xy, promises), intcbrt(x.zw, promises));
            }
        }
    }
}