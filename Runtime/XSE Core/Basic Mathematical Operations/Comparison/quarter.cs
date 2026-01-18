using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            private static v128 ABS_MASK_PQ
            {
                get
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return set1_epi8(maxmath.bitmask8(quarter.BITS - 1));
                    }
                    else throw new IllegalInstructionException();
                }
            }

            private static v256 MM256_ABS_MASK_PQ
            {
                get
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_set1_epi8(maxmath.bitmask8(quarter.BITS - 1));
                    }
                    else throw new IllegalInstructionException();
                }
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpord_pq(v128 a, v128 b, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LT_EPU8(a, 1 << 7, elements) && constexpr.ALL_LT_EPU8(b, 1 << 7, elements))
                    {
                        return and_si128(cmpgt_epi8(set1_epi8(quarter.SIGNALING_EXPONENT + 1), a),
                                         cmpgt_epi8(set1_epi8(quarter.SIGNALING_EXPONENT + 1), b));
                    }
                    else
                    {
                        return and_si128(cmpgt_epi8(set1_epi8(quarter.SIGNALING_EXPONENT + 1), and_si128(a, ABS_MASK_PQ)),
                                         cmpgt_epi8(set1_epi8(quarter.SIGNALING_EXPONENT + 1), and_si128(b, ABS_MASK_PQ)));
                    }

                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpunord_pq(v128 a, v128 b, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LT_EPU8(a, 1 << 7, elements) && constexpr.ALL_LT_EPU8(b, 1 << 7, elements))
                    {
                        return or_si128(cmpgt_epi8(and_si128(a, ABS_MASK_PQ), set1_epi8(quarter.SIGNALING_EXPONENT)),
                                        cmpgt_epi8(and_si128(b, ABS_MASK_PQ), set1_epi8(quarter.SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        return or_si128(cmpgt_epi8(a, set1_epi8(quarter.SIGNALING_EXPONENT)),
                                        cmpgt_epi8(b, set1_epi8(quarter.SIGNALING_EXPONENT)));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpeq_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPU8(a, 0, elements) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return cmpeq_epi8(slli_epi8(b, 1), setzero_si128());
                        }
                        else
                        {
                            return andnot_si128(cmpunord_pq(b, b), cmpeq_epi8(slli_epi8(b, 1), setzero_si128()));
                        }
                    }
                    else if (constexpr.ALL_EQ_EPU8(b, 0, elements) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return cmpeq_epi8(slli_epi8(a, 1), setzero_si128());
                        }
                        else
                        {
                            return andnot_si128(cmpunord_pq(a, a), cmpeq_epi8(slli_epi8(a, 1), setzero_si128()));
                        }
                    }
                    else
                    {
                        v128 equalValues = cmpeq_epi8(a, b);

                        if (promiseNeitherNaN)
                        {
                            if (promiseNeitherZero)
                            {
                                return equalValues;
                            }
                            else
                            {
                                v128 bothZero = cmpeq_epi8(setzero_si128(), slli_epi8(or_si128(a, b), 1));

                                return or_si128(bothZero, equalValues);
                            }
                        }
                        else
                        {
                            v128 eitherNaN = cmpunord_pq(a, b, elements);

                            if (promiseNeitherZero)
                            {
                                return andnot_si128(eitherNaN, equalValues);
                            }
                            else
                            {
                                v128 bothZero = cmpeq_epi8(setzero_si128(), slli_epi8(or_si128(a, b), 1));

                                return ternarylogic_si128(eitherNaN, bothZero, equalValues, TernaryOperation.OxOE);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpneq_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPU8(a, 0, elements) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return not_si128(cmpeq_epi8(slli_epi8(b, 1), setzero_si128()));
                        }
                        else
                        {
                            return andnot_si128(cmpeq_epi8(slli_epi8(b, 1), setzero_si128()), cmpord_pq(b, b));
                        }
                    }
                    else if (constexpr.ALL_EQ_EPU8(b, 0, elements) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return not_si128(cmpeq_epi8(slli_epi8(a, 1), setzero_si128()));
                        }
                        else
                        {
                            return andnot_si128(cmpeq_epi8(slli_epi8(a, 1), setzero_si128()), cmpord_pq(a, a));
                        }
                    }
                    else
                    {
                        v128 equalValues = cmpeq_epi8(a, b);

                        if (promiseNeitherNaN)
                        {
                            if (promiseNeitherZero)
                            {
                                return not_si128(equalValues);
                            }
                            else
                            {
                                v128 bothZero = cmpeq_epi8(setzero_si128(), slli_epi8(or_si128(a, b), 1));

                                return nor_si128(equalValues, bothZero);
                            }
                        }
                        else
                        {
                            v128 eitherNaN = cmpunord_pq(a, b, elements);

                            if (promiseNeitherZero)
                            {
                                return ornot_si128(equalValues, eitherNaN);
                            }
                            else
                            {
                                v128 bothZero = cmpeq_epi8(setzero_si128(), slli_epi8(or_si128(a, b), 1));

                                return ternarylogic_si128(eitherNaN, bothZero, equalValues, TernaryOperation.OxF1);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmplt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPU8(b, 0, elements) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        v128 negative = cmpgt_epi8(setzero_si128(), a);
                        v128 zero = cmpeq_epi8(setzero_si128(), slli_epi8(a, 1));

                        if (promiseNeitherNaN)
                        {
                            return andnot_si128(zero, negative);
                        }
                        else
                        {
                            return ternarylogic_si128(cmpunord_pq(a, a), zero, negative, TernaryOperation.OxO2);
                        }
                    }
                    if (constexpr.ALL_EQ_EPU8(a, 0, elements) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        v128 positive = cmpgt_epi8(b, setzero_si128());
                        v128 zero = cmpeq_epi8(setzero_si128(), slli_epi8(b, 1));

                        if (promiseNeitherNaN)
                        {
                            return andnot_si128(zero, positive);
                        }
                        else
                        {
                            return ternarylogic_si128(cmpunord_pq(b, b), zero, positive, TernaryOperation.OxO2);
                        }
                    }


                    v128 equalValues = cmpeq_epi8(a, b);

                    v128 signA = srai_epi8(a, 7);
                    v128 signB = srai_epi8(b, 7);
                    v128 equalSigns = cmpeq_epi8(signA, signB);
                    v128 ifEqualSigns;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ifEqualSigns = ternarylogic_si128(equalValues, signA, cmple_epu8(b, a, elements), TernaryOperation.OxO9);
                    //}
                    //else
                    //{
                          ifEqualSigns = ternarylogic_si128(equalValues, signA, cmpgt_epu8(b, a, elements), TernaryOperation.OxO6);
                    //}

                    v128 orderedCmp;
                    if (promiseNeitherZero)
                    {
                        orderedCmp = blendv_si128(signA, ifEqualSigns, equalSigns);
                    }
                    else
                    {
                        v128 bothZero = cmpeq_epi8(setzero_si128(), slli_epi8(or_si128(a, b), 1));
                        v128 ifOppositeSigns = andnot_si128(bothZero, signA);
                        orderedCmp = blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                    }

                    if (promiseNeitherNaN)
                    {
                        return orderedCmp;
                    }
                    else
                    {
                        v128 eitherNaN = cmpunord_pq(a, b, elements);

                        return andnot_si128(eitherNaN, orderedCmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpgt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return cmplt_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmple_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPU8(b, 0, elements) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        v128 intLEzero = cmpgt_epi8(set1_epi8(1), a);

                        if (promiseNeitherNaN)
                        {
                            return intLEzero;
                        }
                        else
                        {
                            return andnot_si128(cmpunord_pq(a, a), intLEzero);
                        }
                    }
                    if (constexpr.ALL_EQ_EPU8(a, 0, elements) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        v128 uintGEzero = cmpgt_epi8(b, setall_si128());
                        v128 negativeZero = cmpeq_epi8(b, set1_epi8(1 << 7));

                        if (promiseNeitherNaN)
                        {
                            return or_si128(uintGEzero, negativeZero);
                        }
                        else
                        {
                            return ternarylogic_si128(cmpunord_pq(b, b), uintGEzero, negativeZero, TernaryOperation.OxOE);
                        }
                    }


                    v128 equalValues = cmpeq_epi8(a, b);

                    v128 signA = srai_epi8(a, 7);
                    v128 signB = srai_epi8(b, 7);
                    v128 equalSigns = cmpeq_epi8(signA, signB);
                    v128 ifEqualSigns;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ifEqualSigns = ternarylogic_si128(equalValues, signA, cmple_epu8(b, a, elements), TernaryOperation.OxF9);
                    //}
                    //else
                    //{
                          ifEqualSigns = ternarylogic_si128(equalValues, signA, cmpgt_epu8(b, a, elements), TernaryOperation.OxF6);
                    //}

                    v128 orderedCmp;
                    if (promiseNeitherZero)
                    {
                        orderedCmp = blendv_si128(setall_si128(), ifEqualSigns, equalSigns);
                    }
                    else
                    {
                        v128 bothZero = cmpeq_epi8(setzero_si128(), slli_epi8(or_si128(a, b), 1));
                        v128 ifOppositeSigns = or_si128(bothZero, signA);
                        orderedCmp = blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                    }

                    if (promiseNeitherNaN)
                    {
                        return orderedCmp;
                    }
                    else
                    {
                        v128 eitherNaN = cmpunord_pq(a, b, elements);

                        return andnot_si128(eitherNaN, orderedCmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpge_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return cmple_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpngt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return cmple_pq(a, b, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnlt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return cmpge_pq(a, b, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnge_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return cmplt_pq(a, b, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnle_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return cmpgt_pq(a, b, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool vcmpeq_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return alltrue_epi128<quarter>(cmpeq_pq(a, b, promiseNeitherNaN, promiseNeitherZero, elements), elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpord_pq(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LT_EPU8(a, 1 << 7) && constexpr.ALL_LT_EPU8(b, 1 << 7))
                    {
                        return Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(mm256_set1_epi8(quarter.SIGNALING_EXPONENT + 1), a),
                                                    Avx2.mm256_cmpgt_epi8(mm256_set1_epi8(quarter.SIGNALING_EXPONENT + 1), b));
                    }
                    else
                    {
                        return Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(mm256_set1_epi8(quarter.SIGNALING_EXPONENT + 1), Avx2.mm256_and_si256(a, MM256_ABS_MASK_PQ)),
                                                    Avx2.mm256_cmpgt_epi8(mm256_set1_epi8(quarter.SIGNALING_EXPONENT + 1), Avx2.mm256_and_si256(b, MM256_ABS_MASK_PQ)));
                    }

                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpunord_pq(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LT_EPU8(a, 1 << 7) && constexpr.ALL_LT_EPU8(b, 1 << 7))
                    {
                        return Avx2.mm256_or_si256(Avx2.mm256_cmpgt_epi8(Avx2.mm256_and_si256(a, MM256_ABS_MASK_PQ), mm256_set1_epi8(quarter.SIGNALING_EXPONENT)),
                                                   Avx2.mm256_cmpgt_epi8(Avx2.mm256_and_si256(b, MM256_ABS_MASK_PQ), mm256_set1_epi8(quarter.SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        return Avx2.mm256_or_si256(Avx2.mm256_cmpgt_epi8(a, mm256_set1_epi8(quarter.SIGNALING_EXPONENT)),
                                                   Avx2.mm256_cmpgt_epi8(b, mm256_set1_epi8(quarter.SIGNALING_EXPONENT)));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpeq_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU8(a, 0) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000))
                    {
                        if (promiseNeitherNaN)
                        {
                            return Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(b, 1), Avx.mm256_setzero_si256());
                        }
                        else
                        {
                            return Avx2.mm256_andnot_si256(mm256_cmpunord_pq(b, b), Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(b, 1), Avx.mm256_setzero_si256()));
                        }
                    }
                    else if (constexpr.ALL_EQ_EPU8(b, 0) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000))
                    {
                        if (promiseNeitherNaN)
                        {
                            return Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(a, 1), Avx.mm256_setzero_si256());
                        }
                        else
                        {
                            return Avx2.mm256_andnot_si256(mm256_cmpunord_pq(a, a), Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(a, 1), Avx.mm256_setzero_si256()));
                        }
                    }
                    else
                    {
                        v256 equalValues = Avx2.mm256_cmpeq_epi8(a, b);

                        if (promiseNeitherNaN)
                        {
                            if (promiseNeitherZero)
                            {
                                return equalValues;
                            }
                            else
                            {
                                v256 bothZero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(Avx2.mm256_or_si256(a, b), 1));

                                return Avx2.mm256_or_si256(bothZero, equalValues);
                            }
                        }
                        else
                        {
                            v256 eitherNaN = mm256_cmpunord_pq(a, b);

                            if (promiseNeitherZero)
                            {
                                return Avx2.mm256_andnot_si256(eitherNaN, equalValues);
                            }
                            else
                            {
                                v256 bothZero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(Avx2.mm256_or_si256(a, b), 1));

                                return mm256_ternarylogic_si256(eitherNaN, bothZero, equalValues, TernaryOperation.OxOE);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpneq_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU8(a, 0) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000))
                    {
                        if (promiseNeitherNaN)
                        {
                            return mm256_not_si256(Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(b, 1), Avx.mm256_setzero_si256()));
                        }
                        else
                        {
                            return Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(b, 1), Avx.mm256_setzero_si256()), mm256_cmpord_pq(b, b));
                        }
                    }
                    else if (constexpr.ALL_EQ_EPU8(b, 0) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000))
                    {
                        if (promiseNeitherNaN)
                        {
                            return mm256_not_si256(Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(a, 1), Avx.mm256_setzero_si256()));
                        }
                        else
                        {
                            return Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(mm256_slli_epi8(a, 1), Avx.mm256_setzero_si256()), mm256_cmpord_pq(a, a));
                        }
                    }
                    else
                    {
                        v256 equalValues = Avx2.mm256_cmpeq_epi8(a, b);

                        if (promiseNeitherNaN)
                        {
                            if (promiseNeitherZero)
                            {
                                return mm256_not_si256(equalValues);
                            }
                            else
                            {
                                v256 bothZero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(Avx2.mm256_or_si256(a, b), 1));

                                return mm256_nor_si256(equalValues, bothZero);
                            }
                        }
                        else
                        {
                            v256 eitherNaN = mm256_cmpunord_pq(a, b);

                            if (promiseNeitherZero)
                            {
                                return mm256_ornot_si256(equalValues, eitherNaN);
                            }
                            else
                            {
                                v256 bothZero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(Avx2.mm256_or_si256(a, b), 1));

                                return mm256_ternarylogic_si256(eitherNaN, bothZero, equalValues, TernaryOperation.OxF1);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmplt_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU8(b, 0) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000))
                    {
                        v256 negative = Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a);
                        v256 zero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(a, 1));

                        if (promiseNeitherNaN)
                        {
                            return Avx2.mm256_andnot_si256(zero, negative);
                        }
                        else
                        {
                            return mm256_ternarylogic_si256(mm256_cmpunord_pq(a, a), zero, negative, TernaryOperation.OxO2);
                        }
                    }
                    if (constexpr.ALL_EQ_EPU8(a, 0) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000))
                    {
                        v256 positive = Avx2.mm256_cmpgt_epi8(b, Avx.mm256_setzero_si256());
                        v256 zero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(b, 1));

                        if (promiseNeitherNaN)
                        {
                            return Avx2.mm256_andnot_si256(zero, positive);
                        }
                        else
                        {
                            return mm256_ternarylogic_si256(mm256_cmpunord_pq(b, b), zero, positive, TernaryOperation.OxO2);
                        }
                    }


                    v256 equalValues = Avx2.mm256_cmpeq_epi8(a, b);

                    v256 signA = mm256_srai_epi8(a, 7);
                    v256 signB = mm256_srai_epi8(b, 7);
                    v256 equalSigns = Avx2.mm256_cmpeq_epi8(signA, signB);
                    v256 ifEqualSigns;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ifEqualSigns = ternarylogic_si256(equalValues, signA, cmple_epu8(b, a), TernaryOperation.OxO9);
                    //}
                    //else
                    //{
                          ifEqualSigns = mm256_ternarylogic_si256(equalValues, signA, mm256_cmpgt_epu8(b, a), TernaryOperation.OxO6);
                    //}

                    v256 orderedCmp;
                    if (promiseNeitherZero)
                    {
                        orderedCmp = mm256_blendv_si256(signA, ifEqualSigns, equalSigns);
                    }
                    else
                    {
                        v256 bothZero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(Avx2.mm256_or_si256(a, b), 1));
                        v256 ifOppositeSigns = Avx2.mm256_andnot_si256(bothZero, signA);
                        orderedCmp = mm256_blendv_si256(ifOppositeSigns, ifEqualSigns, equalSigns);
                    }

                    if (promiseNeitherNaN)
                    {
                        return orderedCmp;
                    }
                    else
                    {
                        v256 eitherNaN = mm256_cmpunord_pq(a, b);

                        return Avx2.mm256_andnot_si256(eitherNaN, orderedCmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpgt_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_cmplt_pq(b, a, promiseNeitherNaN, promiseNeitherZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmple_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU8(b, 0) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000))
                    {
                        v256 intLEzero = Avx2.mm256_cmpgt_epi8(mm256_set1_epi8(1), a);

                        if (promiseNeitherNaN)
                        {
                            return intLEzero;
                        }
                        else
                        {
                            return Avx2.mm256_andnot_si256(mm256_cmpunord_pq(a, a), intLEzero);
                        }
                    }
                    if (constexpr.ALL_EQ_EPU8(a, 0) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000))
                    {
                        v256 uintGEzero = Avx2.mm256_cmpgt_epi8(b, mm256_setall_si256());
                        v256 negativeZero = Avx2.mm256_cmpeq_epi8(b, mm256_set1_epi8(1 << 7));

                        if (promiseNeitherNaN)
                        {
                            return Avx2.mm256_or_si256(uintGEzero, negativeZero);
                        }
                        else
                        {
                            return mm256_ternarylogic_si256(mm256_cmpunord_pq(b, b), uintGEzero, negativeZero, TernaryOperation.OxOE);
                        }
                    }


                    v256 equalValues = Avx2.mm256_cmpeq_epi8(a, b);

                    v256 signA = mm256_srai_epi8(a, 7);
                    v256 signB = mm256_srai_epi8(b, 7);
                    v256 equalSigns = Avx2.mm256_cmpeq_epi8(signA, signB);
                    v256 ifEqualSigns;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ifEqualSigns = ternarylogic_si256(equalValues, signA, cmple_epu8(b, a), TernaryOperation.OxF9);
                    //}
                    //else
                    //{
                          ifEqualSigns = mm256_ternarylogic_si256(equalValues, signA, mm256_cmpgt_epu8(b, a), TernaryOperation.OxF6);
                    //}

                    v256 orderedCmp;
                    if (promiseNeitherZero)
                    {
                        orderedCmp = mm256_blendv_si256(mm256_setall_si256(), ifEqualSigns, equalSigns);
                    }
                    else
                    {
                        v256 bothZero = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_slli_epi8(Avx2.mm256_or_si256(a, b), 1));
                        v256 ifOppositeSigns = Avx2.mm256_or_si256(bothZero, signA);
                        orderedCmp = mm256_blendv_si256(ifOppositeSigns, ifEqualSigns, equalSigns);
                    }

                    if (promiseNeitherNaN)
                    {
                        return orderedCmp;
                    }
                    else
                    {
                        v256 eitherNaN = mm256_cmpunord_pq(a, b);

                        return Avx2.mm256_andnot_si256(eitherNaN, orderedCmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpge_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_cmple_pq(b, a, promiseNeitherNaN, promiseNeitherZero);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpngt_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_cmple_pq(a, b, promiseNeitherNaN, promiseNeitherZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnlt_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_cmpge_pq(a, b, promiseNeitherNaN, promiseNeitherZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnge_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_cmplt_pq(a, b, promiseNeitherNaN, promiseNeitherZero);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnle_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_cmpgt_pq(a, b, promiseNeitherNaN, promiseNeitherZero);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool mm256_vcmpeq_pq(v256 a, v256 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_alltrue_epi256<quarter>(mm256_cmpeq_pq(a, b, promiseNeitherNaN, promiseNeitherZero));
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
