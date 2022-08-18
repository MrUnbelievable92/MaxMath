using System.Runtime.CompilerServices;
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
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LT_EPU16(a, 6 * 6 * 6, elements))
                    {
                        return cbrt_absepi8_takingAndReturning_epu16(a);
                    }

                    v128 cb1 = Sse2.set1_epi16(1 * 1 * 1 - 1);
                    v128 cb2 = Sse2.set1_epi16(2 * 2 * 2 - 1);
                    v128 cb3 = Sse2.set1_epi16(3 * 3 * 3 - 1);
                    v128 cb4 = Sse2.set1_epi16(4 * 4 * 4 - 1);
                    v128 cb5 = Sse2.set1_epi16(5 * 5 * 5 - 1);
                    v128 cb6 = Sse2.set1_epi16(6 * 6 * 6 - 1);
                    
                    v128 result = Sse2.sub_epi16(    negmask_epi16(Sse2.cmpgt_epi16(a, cb1)),Sse2.cmpgt_epi16(a, cb2));
                    result = Sse2.sub_epi16(result, Sse2.add_epi16(Sse2.cmpgt_epi16(a, cb3), Sse2.cmpgt_epi16(a, cb4)));
                    result = Sse2.sub_epi16(result, Sse2.add_epi16(Sse2.cmpgt_epi16(a, cb5), Sse2.cmpgt_epi16(a, cb6)));
                    
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

                    v256 cb1 = Avx.mm256_set1_epi16(1 * 1 * 1 - 1);
                    v256 cb2 = Avx.mm256_set1_epi16(2 * 2 * 2 - 1);
                    v256 cb3 = Avx.mm256_set1_epi16(3 * 3 * 3 - 1);
                    v256 cb4 = Avx.mm256_set1_epi16(4 * 4 * 4 - 1);
                    v256 cb5 = Avx.mm256_set1_epi16(5 * 5 * 5 - 1);
                    v256 cb6 = Avx.mm256_set1_epi16(6 * 6 * 6 - 1);
                    
                    v256 result = Avx2.mm256_sub_epi16(    mm256_negmask_epi16(Avx2.mm256_cmpgt_epi16(a, cb1)),Avx2.mm256_cmpgt_epi16(a, cb2));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb3), Avx2.mm256_cmpgt_epi16(a, cb4)));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb5), Avx2.mm256_cmpgt_epi16(a, cb6)));
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 cbrt_absepi8_takingAndReturning_epu16(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cb1 = Sse2.set1_epi16(1 * 1 * 1 - 1);
                    v128 cb2 = Sse2.set1_epi16(2 * 2 * 2 - 1);
                    v128 cb3 = Sse2.set1_epi16(3 * 3 * 3 - 1);
                    v128 cb4 = Sse2.set1_epi16(4 * 4 * 4 - 1);
                    v128 cb5 = Sse2.set1_epi16(5 * 5 * 5 - 1);
                    
                    v128 result = Sse2.sub_epi16(    negmask_epi16(Sse2.cmpgt_epi16(a, cb1)),Sse2.cmpgt_epi16(a, cb2));
                    result = Sse2.sub_epi16(result, Sse2.add_epi16(Sse2.cmpgt_epi16(a, cb3), Sse2.cmpgt_epi16(a, cb4)));
                    result = Sse2.sub_epi16(result, Sse2.cmpgt_epi16(a, cb5));
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 cbrt_absepi8_takingAndReturning_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cb1 = Avx.mm256_set1_epi16(1 * 1 * 1 - 1);
                    v256 cb2 = Avx.mm256_set1_epi16(2 * 2 * 2 - 1);
                    v256 cb3 = Avx.mm256_set1_epi16(3 * 3 * 3 - 1);
                    v256 cb4 = Avx.mm256_set1_epi16(4 * 4 * 4 - 1);
                    v256 cb5 = Avx.mm256_set1_epi16(5 * 5 * 5 - 1);
                    
                    v256 result = Avx2.mm256_sub_epi16(    mm256_negmask_epi16(Avx2.mm256_cmpgt_epi16(a, cb1)),Avx2.mm256_cmpgt_epi16(a, cb2));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb3), Avx2.mm256_cmpgt_epi16(a, cb4)));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, cb5));
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu8(v128 a, bool promiseEPI8range = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (elements > 8)
                    {
                        if (promiseEPI8range || constexpr.ALL_LT_EPU8(a, 128, elements))
                        {
                            return cbrt_epi8(a, true, elements);
                        }


                        v128 cb1 = Sse2.set1_epi8(unchecked((sbyte)(1 * 1 * 1)));
                        v128 cb2 = Sse2.set1_epi8(unchecked((sbyte)(2 * 2 * 2)));
                        v128 cb3 = Sse2.set1_epi8(unchecked((sbyte)(3 * 3 * 3)));
                        v128 cb4 = Sse2.set1_epi8(unchecked((sbyte)(4 * 4 * 4)));
                        v128 cb5 = Sse2.set1_epi8(unchecked((sbyte)(5 * 5 * 5)));
                        v128 cb6 = Sse2.set1_epi8(unchecked((sbyte)(6 * 6 * 6)));

                        v128 result = Sse2.sub_epi8(    negmask_epi8(cmpge_epu8(a, cb1)),cmpge_epu8(a, cb2));
                        result = Sse2.sub_epi8(result, Sse2.add_epi8(cmpge_epu8(a, cb3), cmpge_epu8(a, cb4)));
                        result = Sse2.sub_epi8(result, Sse2.add_epi8(cmpge_epu8(a, cb5), cmpge_epu8(a, cb6)));

                        return result;
                    }
                    else
                    {
                        v128 x = cbrt_epu8_takingAndReturning_epu16(cvtepu8_epi16(a), elements);
                        
                        return Sse2.packus_epi16(x, x);
                    }
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

                    v256 cb1 = Avx.mm256_set1_epi8(1 * 1 * 1);
                    v256 cb2 = Avx.mm256_set1_epi8(2 * 2 * 2);
                    v256 cb3 = Avx.mm256_set1_epi8(3 * 3 * 3);
                    v256 cb4 = Avx.mm256_set1_epi8(4 * 4 * 4);
                    v256 cb5 = Avx.mm256_set1_epi8(5 * 5 * 5);
                    v256 cb6 = Avx.mm256_set1_epi8(6 * 6 * 6);
                    
                    v256 result = Avx2.mm256_sub_epi8(    mm256_negmask_epi8(mm256_cmpge_epu8(a, cb1)),mm256_cmpge_epu8(a, cb2));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(mm256_cmpge_epu8(a, cb3), mm256_cmpge_epu8(a, cb4)));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(mm256_cmpge_epu8(a, cb5), mm256_cmpge_epu8(a, cb6)));
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi8(v128 a, bool promisePositive = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 negative = a;
                    bool NEED_TO_SAVE_SIGN = !(promisePositive || constexpr.ALL_GE_EPI8(a, 0, elements));
                    
                    if (NEED_TO_SAVE_SIGN)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            a = Ssse3.abs_epi8(a);
                        }
                        else
                        {
                            negative = Sse2.cmpgt_epi8(Sse2.setzero_si128(), a);
                            a = Sse2.xor_si128(Sse2.add_epi8(a, negative), negative);
                        }
                    }
                    
                    v128 cb1 = Sse2.set1_epi8(1 * 1 * 1 - 1);
                    v128 cb2 = Sse2.set1_epi8(2 * 2 * 2 - 1);
                    v128 cb3 = Sse2.set1_epi8(3 * 3 * 3 - 1);
                    v128 cb4 = Sse2.set1_epi8(4 * 4 * 4 - 1);
                    v128 cb5 = Sse2.set1_epi8(5 * 5 * 5 - 1);
                    
                    v128 result = Sse2.sub_epi8(    negmask_epi8(Sse2.cmpgt_epi8(a, cb1)),Sse2.cmpgt_epi8(a, cb2));
                    result = Sse2.sub_epi8(result, Sse2.add_epi8(Sse2.cmpgt_epi8(a, cb3), Sse2.cmpgt_epi8(a, cb4)));
                    result = Sse2.sub_epi8(result, Sse2.cmpgt_epi8(a, cb5));
                    
                    if (NEED_TO_SAVE_SIGN)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            result = Ssse3.sign_epi8(result, negative);
                        }
                        else
                        {
                            result = Sse2.xor_si128(Sse2.add_epi8(result, negative), negative);
                        }
                    }
                    
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
                        a = Avx2.mm256_abs_epi8(a);
                    }

                    v256 cb1 = Avx.mm256_set1_epi8(1 * 1 * 1 - 1);
                    v256 cb2 = Avx.mm256_set1_epi8(2 * 2 * 2 - 1);
                    v256 cb3 = Avx.mm256_set1_epi8(3 * 3 * 3 - 1);
                    v256 cb4 = Avx.mm256_set1_epi8(4 * 4 * 4 - 1);
                    v256 cb5 = Avx.mm256_set1_epi8(5 * 5 * 5 - 1);
                    
                    v256 result = Avx2.mm256_sub_epi8(    mm256_negmask_epi8(Avx2.mm256_cmpgt_epi8(a, cb1)),Avx2.mm256_cmpgt_epi8(a, cb2));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(Avx2.mm256_cmpgt_epi8(a, cb3), Avx2.mm256_cmpgt_epi8(a, cb4)));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_cmpgt_epi8(a, cb5));
                    
                    if (NEED_TO_SAVE_SIGN)
                    {
                        result = Avx2.mm256_sign_epi8(result, negative);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu16(v128 a, bool promiseByteRange = false, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (promiseByteRange || constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                    {
                        return cbrt_epu8_takingAndReturning_epu16(a, elements);
                    }
                    else
                    {
                        v128 greaterEqualMask = Sse2.srai_epi16(a, 15);
                        v128 y = Sse2.srli_epi16(a, 15);
                        a = Sse2.and_si128(a, Sse2.set1_epi16(0x7FFF));
                        v128 y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        v128 b = Sse2.add_epi16(y, y4);
                        b = Sse2.add_epi16(inc_epi16(b), Sse2.and_si128(greaterEqualMask, Sse2.slli_epi16(b, 1)));

                        greaterEqualMask = Sse2.cmpgt_epi16(b, Sse2.srli_epi16(a, 12));
                        v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 12));
                        v128 addToY = inc_epi16(greaterEqualMask);
                        a = Sse2.sub_epi16(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = inc_epi16(Sse2.mullo_epi16(Sse2.add_epi16(y, y4), inc_epi16(y)));

                        greaterEqualMask = Sse2.cmpgt_epi16(b, Sse2.srli_epi16(a, 9));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 9));
                        addToY = inc_epi16(greaterEqualMask);
                        a = Sse2.sub_epi16(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = inc_epi16(Sse2.mullo_epi16(Sse2.add_epi16(y, y4), inc_epi16(y)));

                        greaterEqualMask = Sse2.cmpgt_epi16(b, Sse2.srli_epi16(a, 6));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 6));
                        addToY = inc_epi16(greaterEqualMask);
                        a = Sse2.sub_epi16(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = inc_epi16(Sse2.mullo_epi16(Sse2.add_epi16(y, y4), inc_epi16(y)));

                        greaterEqualMask = Sse2.cmpgt_epi16(b, Sse2.srli_epi16(a, 3));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi16(b, 3));
                        addToY = inc_epi16(greaterEqualMask);
                        a = Sse2.sub_epi16(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = inc_epi16(Sse2.mullo_epi16(Sse2.add_epi16(y, y4), inc_epi16(y)));
                        
                        greaterEqualMask = Sse2.cmpgt_epi16(b, a);
                        addToY = inc_epi16(greaterEqualMask);
                        y = Sse2.add_epi16(y, addToY);

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
                        v256 greaterEqualMask = Avx2.mm256_srai_epi16(a, 15);
                        v256 y = Avx2.mm256_srli_epi16(a, 15);
                        a = Avx2.mm256_and_si256(a, Avx.mm256_set1_epi16(0x7FFF));
                        v256 y4 = Avx2.mm256_slli_epi16(y, 2);
                        y = Avx2.mm256_add_epi16(y, y);
                        v256 b = Avx2.mm256_add_epi16(y, y4);
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

                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi16(v128 a, bool promiseAbsolute = false, bool promise8BitRange = false, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (promiseAbsolute || constexpr.ALL_GE_EPI16(a, 0, elements))
                    {
                        return cbrt_epu16(a, promise8BitRange, elements);
                    }
                    else 
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            return Ssse3.sign_epi16(cbrt_epu16(Ssse3.abs_epi16(a), promise8BitRange, elements), a);
                        }
                        else
                        {
                            v128 negative = Sse2.srai_epi16(a, 15);
                            v128 cbrtAbs = cbrt_epu16(Sse2.xor_si128(Sse2.add_epi16(a, negative), negative), promise8BitRange, elements);
                            
                            return Sse2.xor_si128(Sse2.add_epi16(cbrtAbs, negative), negative);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi16(v256 a, bool promiseAbsolute = false, bool promise8BitRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseAbsolute || constexpr.ALL_GE_EPI16(a, 0))
                    {
                        return mm256_cbrt_epu16(a, promise8BitRange);
                    }
                    else
                    {
                        return Avx2.mm256_sign_epi16(mm256_cbrt_epu16(Avx2.mm256_abs_epi16(a), promise8BitRange), a);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu32(v128 a, byte rangeLevelPromise = 0, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (rangeLevelPromise > 0 || constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements))
                    {
                        if (rangeLevelPromise > 1 || constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                        {
                            v128 ONE = Sse2.set1_epi32(1);
                            
                            v128 greaterEqualMask = Sse2.cmpgt_epi32(ONE, Sse2.srli_epi32(a, 6));
                            v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(ONE, 6));
                            v128 y = inc_epi32(greaterEqualMask);
                            a = Sse2.sub_epi32(a, subFromX);
                            v128 y4 = Sse2.slli_epi32(y, 2);
                            y = Sse2.add_epi32(y, y);
                            v128 b = Sse2.add_epi32(y, y4);
                            b = Sse2.add_epi32(inc_epi32(b), Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 1)));
                             
                            greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 3));
                            subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 3));
                            v128 addToY = inc_epi32(greaterEqualMask);
                            a = Sse2.sub_epi32(a, subFromX);
                            y = Sse2.add_epi32(y, addToY);
                            y4 = Sse2.slli_epi32(y, 2);
                            y = Sse2.add_epi32(y, y);
                            b = inc_epi32(Sse2.mullo_epi16(Sse2.add_epi32(y, y4), inc_epi32(y)));
                            greaterEqualMask = Sse2.cmpgt_epi32(b, a);
                            addToY = inc_epi32(greaterEqualMask);
                            y = Sse2.add_epi32(y, addToY);
                            
                            return y;
                        }
                        else
                        {
                            v128 ONE = Sse2.set1_epi32(1);
                            
                            v128 greaterEqualMask = Sse2.srai_epi32(Sse2.slli_epi32(a, 16), 31);
                            v128 subFromX = Sse2.and_si128(greaterEqualMask, Sse2.slli_epi32(ONE, 15));
                            v128 y = Sse2.srli_epi32(a, 15);
                            a = Sse2.sub_epi32(a, subFromX);
                            v128 y4 = Sse2.slli_epi32(y, 2);
                            y = Sse2.add_epi32(y, y);
                            v128 b = Sse2.add_epi32(y, y4);
                            b = Sse2.add_epi32(inc_epi32(b), Sse2.and_si128(greaterEqualMask, Sse2.slli_epi32(b, 1)));
                            
                            greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 12));
                            subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 12));
                            v128 addToY = inc_epi32(greaterEqualMask);
                            a = Sse2.sub_epi32(a, subFromX);
                            y = Sse2.add_epi16(y, addToY);
                            y4 = Sse2.slli_epi16(y, 2);
                            y = Sse2.add_epi16(y, y);
                            b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                            
                            greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 9));
                            subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 9));
                            addToY = inc_epi32(greaterEqualMask);
                            a = Sse2.sub_epi32(a, subFromX);
                            y = Sse2.add_epi16(y, addToY);
                            y4 = Sse2.slli_epi16(y, 2);
                            y = Sse2.add_epi16(y, y);
                            b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                            
                            greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 6));
                            subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 6));
                            addToY = inc_epi32(greaterEqualMask);
                            a = Sse2.sub_epi32(a, subFromX);
                            y = Sse2.add_epi16(y, addToY);
                            y4 = Sse2.slli_epi16(y, 2);
                            y = Sse2.add_epi16(y, y);
                            b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                            
                            greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 3));
                            subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 3));
                            addToY = inc_epi32(greaterEqualMask);
                            a = Sse2.sub_epi32(a, subFromX);
                            y = Sse2.add_epi16(y, addToY);
                            y4 = Sse2.slli_epi16(y, 2);
                            y = Sse2.add_epi16(y, y);
                            b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                            
                            greaterEqualMask = Sse2.cmpgt_epi32(b, a);
                            addToY = inc_epi32(greaterEqualMask);
                            y = Sse2.add_epi32(y, addToY);
                            
                            return y;
                        }
                    }
                    else
                    {
                        v128 ONE = Sse2.set1_epi32(1);

                        v128 greaterEqualMask = Sse2.cmpgt_epi32(ONE, Sse2.srli_epi32(a, 30));
                        v128 subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(ONE, 30));
                        v128 y = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        v128 y4 = Sse2.slli_epi32(y, 2);
                        y = Sse2.add_epi32(y, y);
                        v128 b = Sse2.add_epi32(y, y4);
                        b = Sse2.add_epi32(inc_epi32(b), Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 1)));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 27));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 27));
                        v128 addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 24));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 24));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 21));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 21));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 18));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 18));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 15));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 15));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 12));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 12));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi32(y, addToY);
                        y4 = Sse2.slli_epi32(y, 2);
                        y = Sse2.add_epi32(y, y);
                        b = inc_epi32(mullo_epi32(Sse2.add_epi32(y, y4), inc_epi32(y), elements));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 9));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 9));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi32(y, addToY);
                        y4 = Sse2.slli_epi32(y, 2);
                        y = Sse2.add_epi32(y, y);
                        b = inc_epi32(mullo_epi32(Sse2.add_epi32(y, y4), inc_epi32(y), elements));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 6));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 6));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi32(y, addToY);
                        y4 = Sse2.slli_epi32(y, 2);
                        y = Sse2.add_epi32(y, y);
                        b = inc_epi32(mullo_epi32(Sse2.add_epi32(y, y4), inc_epi32(y), elements));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi32(a, 3));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi32(b, 3));
                        addToY = inc_epi32(greaterEqualMask);
                        a = Sse2.sub_epi32(a, subFromX);
                        y = Sse2.add_epi32(y, addToY);
                        y4 = Sse2.slli_epi32(y, 2);
                        y = Sse2.add_epi32(y, y);
                        b = inc_epi32(mullo_epi32(Sse2.add_epi32(y, y4), inc_epi32(y), elements));
                        
                        greaterEqualMask = Sse2.cmpgt_epi32(b, a);
                        addToY = inc_epi32(greaterEqualMask);
                        y = Sse2.add_epi32(y, addToY);

                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu32(v256 a, byte rangeLevelPromise = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (rangeLevelPromise > 0 || constexpr.ALL_LE_EPU32(a, ushort.MaxValue))
                    {
                        if (rangeLevelPromise > 1 || constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            v256 ONE = Avx.mm256_set1_epi32(1);
                            
                            v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(ONE, Avx2.mm256_srli_epi32(a, 6));
                            v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(ONE, 6));
                            v256 y = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            v256 y4 = Avx2.mm256_slli_epi32(y, 2);
                            y = Avx2.mm256_add_epi32(y, y);
                            v256 b = Avx2.mm256_add_epi32(y, y4);
                            b = Avx2.mm256_add_epi32(mm256_inc_epi32(b), Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 1)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(a, 3));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 3));
                            v256 addToY = mm256_inc_epi32(greaterEqualMask);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            y = Avx2.mm256_add_epi16(y, addToY);
                            y4 = Avx2.mm256_slli_epi16(y, 2);
                            y = Avx2.mm256_add_epi16(y, y);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(y, y4), Avx2.mm256_add_epi16(ONE, y)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, a);
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            y = Avx2.mm256_add_epi32(y, addToY);

                            return y;
                        }
                        else
                        {
                            v256 ONE = Avx.mm256_set1_epi32(1);
                            
                            v256 greaterEqualMask = Avx2.mm256_srai_epi32(Avx2.mm256_slli_epi32(a, 16), 31);
                            v256 subFromX = Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi16(ONE, 15));
                            v256 y = Avx2.mm256_srli_epi32(a, 15);
                            a = Avx2.mm256_sub_epi32(a, subFromX);
                            v256 y4 = Avx2.mm256_slli_epi32(y, 2);
                            y = Avx2.mm256_add_epi32(y, y);
                            v256 b = Avx2.mm256_add_epi32(y, y4);
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

                            return y;
                        }
                    }
                    else
                    {
                        v256 ONE = Avx.mm256_set1_epi32(1);
                        
                        v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(ONE, Avx2.mm256_srli_epi32(a, 30));
                        v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(ONE, 30));
                        v256 y = mm256_inc_epi32(greaterEqualMask);
                        a = Avx2.mm256_sub_epi32(a, subFromX);
                        v256 y4 = Avx2.mm256_slli_epi32(y, 2);
                        y = Avx2.mm256_add_epi32(y, y);
                        v256 b = Avx2.mm256_add_epi32(y, y4);
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

                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi32(v128 a, bool promiseAbsolute = false, byte rangeLevelPromise = 0, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (promiseAbsolute || constexpr.ALL_GE_EPI32(a, 0, elements))
                    {
                        return cbrt_epu32(a, rangeLevelPromise, elements);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            return Ssse3.sign_epi32(cbrt_epu32(Ssse3.abs_epi32(a), rangeLevelPromise, elements), a);
                        }
                        else
                        {
                            v128 negative = Sse2.srai_epi32(a, 31);
                            v128 cbrtAbs = cbrt_epu32(Sse2.xor_si128(Sse2.add_epi32(a, negative), negative), rangeLevelPromise, elements);
                            
                            return Sse2.xor_si128(Sse2.add_epi32(cbrtAbs, negative), negative);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi32(v256 a, bool promiseAbsolute = false, byte rangeLevelPromise = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseAbsolute || constexpr.ALL_GE_EPI32(a, 0))
                    {
                        return mm256_cbrt_epu32(a);
                    }
                    else
                    {
                        return Avx2.mm256_sign_epi32(mm256_cbrt_epu32(Avx2.mm256_abs_epi32(a), rangeLevelPromise), a);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu64(v128 a, byte rangeLevelPromise = 0)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (rangeLevelPromise > 0 || constexpr.ALL_LE_EPU64(a, 1ul << 40))
                    {
                        if (rangeLevelPromise > 1 || constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                        {
                            if (rangeLevelPromise > 2 || constexpr.ALL_LE_EPU64(a, ushort.MaxValue))
                            {
                                if (rangeLevelPromise > 3 || constexpr.ALL_LE_EPU64(a, byte.MaxValue))
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
                            // results within [0, 1ul << 40] have been proven to be correct empirically both with and without FMA instructions
                            return usfcvttpd_epu64(cbrt_pd(usfcvtepu64_pd(a)));
                        }
                    }
                    else
                    {
                        v128 ONE = Sse2.set1_epi64x(1);
                        
                        v128 y = Sse2.srli_epi64(a, 63);
                        v128 greaterEqualMask = neg_epi64(y);
                        a = Sse2.and_si128(a, Sse2.set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));
                        v128 y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        v128 b = Sse2.add_epi64(y, y4);
                        b = Sse2.add_epi64(inc_epi64(b), Sse2.and_si128(greaterEqualMask, Sse2.slli_epi64(b, 1)));
                        
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 60));
                        v128 subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 60));
                        v128 addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 57));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 57));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 54));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 54));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 51));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 51));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y)));
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 48));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 48));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi16(y, addToY);
                        y4 = Sse2.slli_epi16(y, 2);
                        y = Sse2.add_epi16(y, y);
                        b = Sse2.add_epi16(ONE, Sse2.mullo_epi16(Sse2.add_epi16(y, y4), Sse2.add_epi16(ONE, y))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 45));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 45));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 42));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 42));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 39));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 39));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));
                                
                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 36));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 36));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = Sse2.cmpgt_epi32(b, Sse2.srli_epi64(a, 33));
                        subFromX = Sse2.andnot_si128(Sse2.shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Sse2.slli_epi64(b, 33));
                        addToY   = Sse2.andnot_si128(greaterEqualMask, ONE);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 30));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 30));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 27));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 27));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 24));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 24));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 21));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 21));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 18));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 18));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 15));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 15));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 12));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 12));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 9));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 9));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 6));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 6));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));

                        greaterEqualMask = cmpgt_epi64(b, Sse2.srli_epi64(a, 3));
                        subFromX = Sse2.andnot_si128(greaterEqualMask, Sse2.slli_epi64(b, 3));
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        a = Sse2.sub_epi64(a, subFromX);
                        y = Sse2.add_epi64(y, addToY);
                        y4 = Sse2.slli_epi64(y, 2);
                        y = Sse2.add_epi64(y, y);
                        b = inc_epi64(Sse2.mul_epu32(Sse2.add_epi64(y, y4), inc_epi64(y)));
                        
                        greaterEqualMask = cmpgt_epi64(b, a);
                        addToY   = Sse2.add_epi64(ONE, greaterEqualMask);
                        y = Sse2.add_epi64(y, addToY);

                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu64(v256 a, byte rangeLevelPromise = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (rangeLevelPromise > 0 || constexpr.ALL_LE_EPU64(a, 1ul << 40, elements))
                    {
                        if (rangeLevelPromise > 1 || constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                        {
                            if (rangeLevelPromise > 2 || constexpr.ALL_LE_EPU64(a, ushort.MaxValue, elements))
                            {
                                if (rangeLevelPromise > 3 || constexpr.ALL_LE_EPU64(a, byte.MaxValue, elements))
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
                            // results within [0, 1ul << 40] have been proven to be correct empirically both with and without FMA instructions
                            return mm256_usfcvttpd_epu64(mm256_cbrt_pd(mm256_usfcvtepu64_pd(a)));
                        }
                    }
                    else
                    {
                        v256 ONE = Avx.mm256_set1_epi64x(1);
                        
                        v256 y = Avx2.mm256_srli_epi64(a, 63);
                        v256 greaterEqualMask = mm256_neg_epi64(y);
                        a = Avx2.mm256_and_si256(a, Avx.mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));
                        v256 y4 = Avx2.mm256_slli_epi64(y, 2);
                        y = Avx2.mm256_add_epi64(y, y);
                        v256 b = Avx2.mm256_add_epi64(y, y4);
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

                        return y;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi64(v128 a, bool promiseAbs = false, byte rangeLevelPromise = 0)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (promiseAbs || constexpr.ALL_GE_EPI64(a, 0))
                    {
                        return cbrt_epu64(a, rangeLevelPromise);
                    }
                    else
                    {
                        v128 negative = srai_epi64(a, 63);
                        v128 cbrtAbs = cbrt_epu64(Sse2.xor_si128(Sse2.add_epi64(a, negative), negative), rangeLevelPromise);
                        
                        return Sse2.xor_si128(Sse2.add_epi64(cbrtAbs, negative), negative);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi64(v256 a, bool promiseAbs = false, byte rangeLevelPromise = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseAbs || constexpr.ALL_GE_EPI64(a, 0, elements))
                    {
                        return mm256_cbrt_epu64(a, rangeLevelPromise, elements);
                    }
                    else
                    {
                        v256 negative = mm256_srai_epi64(a, 63);
                        v256 cbrtAbs = mm256_cbrt_epu64(Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(a, negative), negative), rangeLevelPromise, elements);
                        
                        return Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(cbrtAbs, negative), negative);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="UInt128"/>.   </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ulong.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [return: AssumeRange(0ul, 6_981_463_658_331ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static ulong intcbrt(UInt128 x, Promise optimizations = Promise.Nothing)
        {
            if (optimizations.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(x.hi64 == 0))
            {
                optimizations = optimizations.GetDemotedUnsafeLevels();

                return intcbrt(x.lo64, optimizations);
            }

            ulong y = 0;
            UInt128 b = (UInt128)1 << 126;

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
            ulong lo = Common.umul128(3 * y, y + 1, out ulong hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 33) >= b) 
            {
                x -= b << 33;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 30) >= b) 
            {
                x -= b << 30;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 27) >= b) 
            {
                x -= b << 27;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 24) >= b) 
            {
                x -= b << 24;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 21) >= b) 
            {
                x -= b << 21;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 18) >= b) 
            {
                x -= b << 18;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 15) >= b) 
            {
                x -= b << 15;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 12) >= b) 
            {
                x -= b << 12;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 9) >= b) 
            {
                x -= b << 9;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 6) >= b) 
            {
                x -= b << 6;
                y++;
            }

            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);
            
            if ((x >> 3) >= b) 
            {
                x -= b << 3;
                y++;
            }
            
            y += y;
            lo = Common.umul128(3 * y, y + 1, out hi);
            b = 1 + new UInt128(lo, hi);

            y += tobyte(x >= b);

            return y;
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="Int128"/>.   </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ulong.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ulong.MaxValue"/>, <see cref="ulong.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [return: AssumeRange(-5_541_191_377_756L, 6_981_463_658_331L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intcbrt(Int128 x, Promise optimizations = Promise.Nothing) 
        {
            if (optimizations.Promises(Promise.ZeroOrGreater) || Xse.constexpr.IS_TRUE(x >= 0))
            {
                optimizations = Promise.ZeroOrGreater | optimizations.GetDemotedUnsafeLevels();

                return (long)intcbrt((UInt128)x, optimizations);
            }
            else
            {
                bool negative = (long)x.hi64 < 0;
                ulong cbrtAbs = intcbrt((UInt128)abs(x), optimizations);

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
            uint b = 1;
            
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

            return (byte)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte2"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intcbrt(byte2 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new byte2(intcbrt(x.x), intcbrt(x.y));
            }
        } 

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte3"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intcbrt(byte3 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new byte3(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte4"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intcbrt(byte4 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new byte4(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z), intcbrt(x.w));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte8"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intcbrt(byte8 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
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

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte16"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intcbrt(byte16 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
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

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.byte32"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </remarks>
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


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </remarks>
        [return: AssumeRange(-5, 6)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static sbyte intcbrt(sbyte x, Promise nonNegative = Promise.Nothing)
        {
            if (nonNegative.Promises(Promise.ZeroOrGreater) || Xse.constexpr.IS_TRUE(x >= 0))
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

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte2"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intcbrt(sbyte2 x, Promise nonNegative = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                return new sbyte2(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte3"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intcbrt(sbyte3 x, Promise nonNegative = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new sbyte3(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative),  intcbrt(x.z, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte4"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intcbrt(sbyte4 x, Promise nonNegative = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new sbyte4(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative),  intcbrt(x.z, nonNegative),  intcbrt(x.w, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte8"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intcbrt(sbyte8 x, Promise nonNegative = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
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

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte16"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intcbrt(sbyte16 x, Promise nonNegative = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
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

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.sbyte32"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </remarks>
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


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </remarks>
        [return: AssumeRange(0ul, 40ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort intcbrt(ushort x, Promise byteRange = Promise.Nothing)
        {
            if (byteRange.Promises(Promise.Unsafe0) || Xse.constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intcbrt((byte)x);
            }

            uint _x = x;
            uint y = _x >> 15;
            _x &= 0x7FFF;

            y += y;
            uint b = ((3 * y) * (y + 1)) + 1;
            
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

            return (ushort)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort2"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intcbrt(ushort2 x, Promise byteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new ushort2(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort3"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intcbrt(ushort3 x, Promise byteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new ushort3(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange), intcbrt(x.z, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort4"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intcbrt(ushort4 x, Promise byteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new ushort4(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange), intcbrt(x.z, byteRange), intcbrt(x.w, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort8"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intcbrt(ushort8 x, Promise byteRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
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

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ushort16"/>.   </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </remarks>
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


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [return: AssumeRange(-32, 40)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static short intcbrt(short x, Promise optimizations = Promise.Nothing)
        {
            if (optimizations.Promises(Promise.ZeroOrGreater) || Xse.constexpr.IS_TRUE(x >= 0))
            {
                return (short)intcbrt((ushort)x, optimizations);
            }
            else
            {
                bool negative = x < 0;
                ushort cbrtAbs = intcbrt((ushort)math.select(x, -x, negative), optimizations);

                return select((short)cbrtAbs, (short)-(short)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short2"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intcbrt(short2 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi16(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new short2(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short3"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intcbrt(short3 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi16(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new short3(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations), intcbrt(x.z, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short4"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intcbrt(short4 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi16(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new short4(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations), intcbrt(x.z, optimizations), intcbrt(x.w, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short8"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intcbrt(short8 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi16(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new short8(intcbrt(x.x0, optimizations), 
                                  intcbrt(x.x1, optimizations),  
                                  intcbrt(x.x2, optimizations),  
                                  intcbrt(x.x3, optimizations),  
                                  intcbrt(x.x4, optimizations),  
                                  intcbrt(x.x5, optimizations),  
                                  intcbrt(x.x6, optimizations),  
                                  intcbrt(x.x7, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.short16"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intcbrt(short16 x, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi16(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short16(intcbrt(x.v8_0, optimizations), intcbrt(x.v8_8, optimizations));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [return: AssumeRange(0ul, 1_625ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intcbrt(uint x, Promise optimizations = Promise.Nothing)
        {
            if (optimizations.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                optimizations = optimizations.GetDemotedUnsafeLevels();

                return intcbrt((ushort)x, optimizations);
            }

            uint y = 0;
            uint b = 1;


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

            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint2"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intcbrt(uint2 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.cbrt_epu32(RegisterConversion.ToV128(x), optimizations.CountUnsafeLevels(), 2));
            }
            else
            {
                return new uint2(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint3"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intcbrt(uint3 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.cbrt_epu32(RegisterConversion.ToV128(x), optimizations.CountUnsafeLevels(), 3));
            }
            else
            {
                return new uint3(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations), intcbrt(x.z, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint4"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intcbrt(uint4 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.cbrt_epu32(RegisterConversion.ToV128(x), optimizations.CountUnsafeLevels(), 4));
            }
            else
            {
                return new uint4(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations), intcbrt(x.z, optimizations), intcbrt(x.w, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.uint8"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intcbrt(uint8 x, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu32(x, optimizations.CountUnsafeLevels());
            }
            else
            {
                return new uint8(intcbrt(x.v4_0, optimizations), intcbrt(x.v4_4, optimizations));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [return: AssumeRange(-1_290, 1_625)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static int intcbrt(int x, Promise optimizations = Promise.Nothing)
        {
            if (optimizations.Promises(Promise.ZeroOrGreater) || Xse.constexpr.IS_TRUE(x >= 0))
            {
                return (int)intcbrt((uint)x, optimizations);
            }
            else
            {
                bool negative = x < 0;
                uint cbrtAbs = intcbrt((uint)math.select(x, -x, negative), optimizations);

                return math.select((int)cbrtAbs, -(int)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int2"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intcbrt(int2 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int2>(Xse.cbrt_epi32(RegisterConversion.ToV128(x), optimizations.Promises(Promise.ZeroOrGreater), optimizations.CountUnsafeLevels(), 2));
            }
            else
            {
                return new int2(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int3"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intcbrt(int3 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int3>(Xse.cbrt_epi32(RegisterConversion.ToV128(x), optimizations.Promises(Promise.ZeroOrGreater), optimizations.CountUnsafeLevels(), 3));
            }
            else
            {
                return new int3(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations), intcbrt(x.z, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int4"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intcbrt(int4 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<int4>(Xse.cbrt_epi32(RegisterConversion.ToV128(x), optimizations.Promises(Promise.ZeroOrGreater), optimizations.CountUnsafeLevels(), 4));
            }
            else
            {
                return new int4(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations), intcbrt(x.z, optimizations), intcbrt(x.w, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="MaxMath.int8"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intcbrt(int8 x, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi32(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.CountUnsafeLevels());
            }
            else
            {
                return new int8(intcbrt(x.v4_0, optimizations), intcbrt(x.v4_4, optimizations));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ulong"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [return: AssumeRange(0ul, 2_642_245ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static ulong intcbrt(ulong x, Promise optimizations = Promise.Nothing)
        {
            if (optimizations.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                optimizations = optimizations.GetDemotedUnsafeLevels();

                return intcbrt((uint)x, optimizations);
            }
            
            ulong y = x >> 63;
            x &= 0x7FFF_FFFF_FFFF_FFFF;
            
            y += y;
            ulong b = ((3 * y) * (y + 1)) + 1;
            
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
            
            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong2"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 40].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intcbrt(ulong2 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epu64(x, optimizations.CountUnsafeLevels());
            }
            else
            {
                optimizations = optimizations.GetDemotedUnsafeLevels();

                return new ulong2(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong3"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 40].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intcbrt(ulong3 x, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu64(x, optimizations.CountUnsafeLevels(), 3);
            }
            else
            {
                ulong2 xy = intcbrt(x.xy, optimizations);
                
                optimizations = optimizations.GetDemotedUnsafeLevels();

                ulong z = intcbrt(x.z, optimizations);

                return new ulong3(xy, z);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="MaxMath.ulong4"/>.   </summary>
        /// <remarks>       
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 40].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intcbrt(ulong4 x, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu64(x, optimizations.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ulong4(intcbrt(x.xy, optimizations), intcbrt(x.zw, optimizations));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="long"/>.   </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [return: AssumeRange(-2_097_152, 2_642_245)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static long intcbrt(long x, Promise optimizations = Promise.Nothing)
        {
            if (optimizations.Promises(Promise.ZeroOrGreater) || Xse.constexpr.IS_TRUE(x >= 0))
            {
                return (long)intcbrt((ulong)x, optimizations);
            }
            else
            {
                bool negative = x < 0;
                ulong cbrtAbs = intcbrt((ulong)math.select(x, -x, negative), optimizations);

                return math.select((long)cbrtAbs, -(long)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.long2"/>.   </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 40] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 40), 1ul &lt;&lt; 40] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intcbrt(long2 x, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_epi64(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.CountUnsafeLevels());
            }
            else
            {
                optimizations = (optimizations.Promises(Promise.ZeroOrGreater) ? Promise.ZeroOrGreater : Promise.Nothing) | optimizations.GetDemotedUnsafeLevels();

                return new long2(intcbrt(x.x, optimizations), intcbrt(x.y, optimizations));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.long3"/>.   </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 40] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 40), 1ul &lt;&lt; 40] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intcbrt(long3 x, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi64(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.CountUnsafeLevels(), 3);
            }
            else
            {
                long2 xy = intcbrt(x.xy, optimizations);
                
                optimizations = (optimizations.Promises(Promise.ZeroOrGreater) ? Promise.ZeroOrGreater : Promise.Nothing) | optimizations.GetDemotedUnsafeLevels();

                long z = intcbrt(x.z, optimizations);

                return new long3(xy, z);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="MaxMath.long4"/>.   </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 40] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 40), 1ul &lt;&lt; 40] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="optimizations"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intcbrt(long4 x, Promise optimizations = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi64(x, optimizations.Promises(Promise.ZeroOrGreater), optimizations.CountUnsafeLevels(), 4);
            }
            else
            {
                return new long4(intcbrt(x.xy, optimizations), intcbrt(x.zw, optimizations));
            }
        }
    }
}