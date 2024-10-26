using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        private static v128 F16_ABS_MASK
        {
            get
            {
                if (Architecture.IsSIMDSupported)
                {
                    return set1_epi16(maxmath.bitmask16(F16_BITS - 1));
                }
                else throw new IllegalInstructionException();
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpord_ph(v128 a, v128 b, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LT_EPU16(a, 1 << 15, elements) && constexpr.ALL_LT_EPU16(b, 1 << 15, elements))
                {
                    return and_si128(cmpgt_epi16(set1_epi16(F16_SIGNALING_EXPONENT + 1), a),
                                     cmpgt_epi16(set1_epi16(F16_SIGNALING_EXPONENT + 1), b));
                }
                else
                {
                    return and_si128(cmpgt_epi16(set1_epi16(F16_SIGNALING_EXPONENT + 1), and_si128(a, F16_ABS_MASK)),
                                     cmpgt_epi16(set1_epi16(F16_SIGNALING_EXPONENT + 1), and_si128(b, F16_ABS_MASK)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpunord_ph(v128 a, v128 b, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LT_EPU16(a, 1 << 15, elements) && constexpr.ALL_LT_EPU16(b, 1 << 15, elements))
                {
                    return or_si128(cmpgt_epi16(a, set1_epi16(F16_SIGNALING_EXPONENT)),
                                    cmpgt_epi16(b, set1_epi16(F16_SIGNALING_EXPONENT)));
                }
                else
                {
                    return or_si128(cmpgt_epi16(and_si128(a, F16_ABS_MASK), set1_epi16(F16_SIGNALING_EXPONENT)),
                                    cmpgt_epi16(and_si128(b, F16_ABS_MASK), set1_epi16(F16_SIGNALING_EXPONENT)));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpeq_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return cmpeq_epi16(slli_epi16(b, 1), setzero_si128());
                    }
                    else
                    {
                        return andnot_si128(cmpunord_ph(b, b), cmpeq_epi16(slli_epi16(b, 1), setzero_si128()));
                    }
                }
                else if (constexpr.ALL_EQ_EPU16(b, 0, elements) || constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return cmpeq_epi16(slli_epi16(a, 1), setzero_si128());
                    }
                    else
                    {
                        return andnot_si128(cmpunord_ph(a, a), cmpeq_epi16(slli_epi16(a, 1), setzero_si128()));
                    }
                }
                else
                {
                    v128 equalValues = cmpeq_epi16(a, b);

                    if (promiseNeitherNaN)
                    {
                        if (promiseNeitherZero)
                        {
                            return equalValues;
                        }
                        else
                        {
                            v128 neitherZero = cmpeq_epi16(setzero_si128(), slli_epi16(or_si128(a, b), 1));

                            return or_si128(neitherZero, equalValues);
                        }
                    }
                    else
                    {
                        v128 eitherNaN = cmpunord_ph(a, b, elements);

                        if (promiseNeitherZero)
                        {
                            return andnot_si128(eitherNaN, equalValues);
                        }
                        else
                        {
                            v128 neitherZero = cmpeq_epi16(setzero_si128(), slli_epi16(or_si128(a, b), 1));

                            return ternarylogic_si128(eitherNaN, neitherZero, equalValues, TernaryOperation.OxOE);
                        }
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpneq_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return not_si128(cmpeq_epi16(slli_epi16(b, 1), setzero_si128()));
                    }
                    else
                    {
                        return andnot_si128(cmpeq_epi16(slli_epi16(b, 1), setzero_si128()), cmpord_ph(b, b));
                    }
                }
                else if (constexpr.ALL_EQ_EPU16(b, 0, elements) || constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return not_si128(cmpeq_epi16(slli_epi16(a, 1), setzero_si128()));
                    }
                    else
                    {
                        return andnot_si128(cmpeq_epi16(slli_epi16(a, 1), setzero_si128()), cmpord_ph(a, a));
                    }
                }
                else
                {
                    v128 equalValues = cmpeq_epi16(a, b);

                    if (promiseNeitherNaN)
                    {
                        if (promiseNeitherZero)
                        {
                            return not_si128(equalValues);
                        }
                        else
                        {
                            v128 bothZero = cmpeq_epi16(setzero_si128(), slli_epi16(or_si128(a, b), 1));

                            return nor_si128(bothZero, equalValues);
                        }
                    }
                    else
                    {
                        v128 eitherNaN = cmpunord_ph(a, b, elements);

                        if (promiseNeitherZero)
                        {
                            return ornot_si128(equalValues, eitherNaN);
                        }
                        else
                        {
                            v128 bothZero = cmpeq_epi16(setzero_si128(), slli_epi16(or_si128(a, b), 1));

                            return ternarylogic_si128(eitherNaN, bothZero, equalValues, TernaryOperation.OxF1);
                        }
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmplt_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU16(b, 0, elements) || constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    v128 negative = cmpgt_epi16(setzero_si128(), a);
                    v128 zero = cmpeq_epi16(setzero_si128(), slli_epi16(a, 1));

                    if (promiseNeitherNaN)
                    {
                        return andnot_si128(zero, negative);
                    }
                    else
                    {
                        return ternarylogic_si128(cmpunord_ph(a, a), zero, negative, TernaryOperation.OxO2);
                    }
                }
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    v128 positive = cmpgt_epi16(b, setzero_si128());
                    v128 zero = cmpeq_epi16(setzero_si128(), slli_epi16(b, 1));

                    if (promiseNeitherNaN)
                    {
                        return andnot_si128(zero, positive);
                    }
                    else
                    {
                        return ternarylogic_si128(cmpunord_ph(b, b), zero, positive, TernaryOperation.OxO2);
                    }
                }


                v128 equalValues = cmpeq_epi16(a, b);

                v128 signA = srai_epi16(a, 15);
                v128 signB = srai_epi16(b, 15);
                v128 equalSigns = cmpeq_epi16(signA, signB);
                v128 ifEqualSigns;
                //if (Avx512.IsAvx512Supported)
                //{
                //    ifEqualSigns = ternarylogic_si128(equalValues, signA, cmple_epu16(b, a, elements), TernaryOperation.OxO9);
                //}
                //else
                //{
                      ifEqualSigns = ternarylogic_si128(equalValues, signA, cmpgt_epu16(b, a, elements), TernaryOperation.OxO6);
                //}

                v128 orderedCmp;
                if (promiseNeitherZero)
                {
                    orderedCmp = blendv_si128(signA, ifEqualSigns, equalSigns);
                }
                else
                {
                    v128 bothZero = cmpeq_epi16(setzero_si128(), slli_epi16(or_si128(a, b), 1));
                    v128 ifOppositeSigns = andnot_si128(bothZero, signA);
                    orderedCmp = blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                }

                if (promiseNeitherNaN)
                {
                    return orderedCmp;
                }
                else
                {
                    v128 eitherNaN = cmpunord_ph(a, b, elements);

                    return andnot_si128(eitherNaN, orderedCmp);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cmplt_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmple_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPU16(b, 0, elements) || constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    v128 intLEzero = cmpgt_epi16(set1_epi16(1), a);

                    if (promiseNeitherNaN)
                    {
                        return intLEzero;
                    }
                    else
                    {
                        return andnot_si128(cmpunord_ph(a, a), intLEzero);
                    }
                }
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    v128 uintGEzero = cmpgt_epi16(b, setzero_si128());
                    v128 negativeZero = cmpeq_epi16(b, set1_epi16(1 << 15));

                    if (promiseNeitherNaN)
                    {
                        return or_si128(uintGEzero, negativeZero);
                    }
                    else
                    {
                        return ternarylogic_si128(cmpunord_ph(b, b), uintGEzero, negativeZero, TernaryOperation.OxOE);
                    }
                }


                v128 equalValues = cmpeq_epi16(a, b);

                v128 signA = srai_epi16(a, 15);
                v128 signB = srai_epi16(b, 15);
                v128 equalSigns = cmpeq_epi16(signA, signB);
                v128 ifEqualSigns;
                //if (Avx512.IsAvx512Supported)
                //{
                //    ifEqualSigns = ternarylogic_si128(equalValues, signA, cmple_epu16(b, a, elements), TernaryOperation.OxF9);
                //}
                //else
                //{
                      ifEqualSigns = ternarylogic_si128(equalValues, signA, cmpgt_epu16(b, a, elements), TernaryOperation.OxF6);
                //}

                v128 orderedCmp;
                if (promiseNeitherZero)
                {
                    orderedCmp = blendv_si128(setall_si128(), ifEqualSigns, equalSigns);
                }
                else
                {
                    v128 bothZero = cmpeq_epi16(setzero_si128(), slli_epi16(or_si128(a, b), 1));
                    v128 ifOppositeSigns = or_si128(bothZero, signA);
                    orderedCmp = blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                }

                if (promiseNeitherNaN)
                {
                    return orderedCmp;
                }
                else
                {
                    v128 eitherNaN = cmpunord_ph(a, b, elements);

                    return andnot_si128(eitherNaN, orderedCmp);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpge_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cmple_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpngt_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cmple_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpnlt_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cmpge_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpnge_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cmplt_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpnle_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                return cmpgt_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }
    }
}
