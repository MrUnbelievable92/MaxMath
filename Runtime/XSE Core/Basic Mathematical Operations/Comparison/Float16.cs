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
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.set1_epi16(unchecked((short)((1 << (F16_BITS - 1)) - 1)));
                }
                else throw new IllegalInstructionException();
            }
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpord_ph(v128 a, v128 b, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPU16(a, 1 << 15, elements) && constexpr.ALL_LT_EPU16(b, 1 << 15, elements))
                {
                    return Sse2.and_si128(Sse2.cmpgt_epi16(Sse2.set1_epi16(F16_SIGNALING_EXPONENT + 1), a),
                                          Sse2.cmpgt_epi16(Sse2.set1_epi16(F16_SIGNALING_EXPONENT + 1), b));
                }
                else
                {
                    return Sse2.and_si128(Sse2.cmpgt_epi16(Sse2.set1_epi16(F16_SIGNALING_EXPONENT + 1), Sse2.and_si128(a, F16_ABS_MASK)),
                                          Sse2.cmpgt_epi16(Sse2.set1_epi16(F16_SIGNALING_EXPONENT + 1), Sse2.and_si128(b, F16_ABS_MASK)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpunord_ph(v128 a, v128 b, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPU16(a, 1 << 15, elements) && constexpr.ALL_LT_EPU16(b, 1 << 15, elements))
                {
                    return Sse2.or_si128(Sse2.cmpgt_epi16(a, Sse2.set1_epi16(F16_SIGNALING_EXPONENT)),
                                         Sse2.cmpgt_epi16(b, Sse2.set1_epi16(F16_SIGNALING_EXPONENT)));
                }
                else
                {
                    return Sse2.or_si128(Sse2.cmpgt_epi16(Sse2.and_si128(a, F16_ABS_MASK), Sse2.set1_epi16(F16_SIGNALING_EXPONENT)),
                                         Sse2.cmpgt_epi16(Sse2.and_si128(b, F16_ABS_MASK), Sse2.set1_epi16(F16_SIGNALING_EXPONENT)));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpeq_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return Sse2.cmpeq_epi16(Sse2.slli_epi16(b, 1), Sse2.setzero_si128());
                    }
                    else
                    {
                        return Sse2.andnot_si128(cmpunord_ph(b, b), Sse2.cmpeq_epi16(Sse2.slli_epi16(b, 1), Sse2.setzero_si128()));
                    }
                }
                else if (Xse.constexpr.ALL_EQ_EPU16(b, 0, elements) || Xse.constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return Sse2.cmpeq_epi16(Sse2.slli_epi16(a, 1), Sse2.setzero_si128());
                    }
                    else
                    {
                        return Sse2.andnot_si128(cmpunord_ph(a, a), Sse2.cmpeq_epi16(Sse2.slli_epi16(a, 1), Sse2.setzero_si128()));
                    }
                } 
                else
                {
                    v128 equalValues = Sse2.cmpeq_epi16(a, b);
                    
                    if (promiseNeitherNaN)
                    {
                        if (promiseNeitherZero)
                        {
                            return equalValues;
                        }
                        else
                        {
                            v128 neitherZero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(Sse2.or_si128(a, b), 1));
                            
                            return Sse2.or_si128(neitherZero, equalValues);
                        }
                    }
                    else
                    {
                        v128 eitherNaN = cmpunord_ph(a, b, elements);
                    
                        if (promiseNeitherZero)
                        {
                            return Sse2.andnot_si128(eitherNaN, equalValues);
                        }
                        else
                        {
                            v128 neitherZero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(Sse2.or_si128(a, b), 1));
                    
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
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return not_si128(Sse2.cmpeq_epi16(Sse2.slli_epi16(b, 1), Sse2.setzero_si128()));
                    }
                    else
                    {
                        return Sse2.andnot_si128(Sse2.cmpeq_epi16(Sse2.slli_epi16(b, 1), Sse2.setzero_si128()), cmpord_ph(b, b));
                    }
                }
                else if (Xse.constexpr.ALL_EQ_EPU16(b, 0, elements) || Xse.constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    if (promiseNeitherNaN)
                    {
                        return not_si128(Sse2.cmpeq_epi16(Sse2.slli_epi16(a, 1), Sse2.setzero_si128()));
                    }
                    else
                    {
                        return Sse2.andnot_si128(Sse2.cmpeq_epi16(Sse2.slli_epi16(a, 1), Sse2.setzero_si128()), cmpord_ph(a, a));
                    }
                } 
                else
                {
                    v128 equalValues = Sse2.cmpeq_epi16(a, b);
                    
                    if (promiseNeitherNaN)
                    {
                        if (promiseNeitherZero)
                        {
                            return not_si128(equalValues);
                        }
                        else
                        {
                            v128 bothZero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(Sse2.or_si128(a, b), 1));
                            
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
                            v128 bothZero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(Sse2.or_si128(a, b), 1));
                    
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
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU16(b, 0, elements) || constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    v128 negative = Sse2.cmpgt_epi16(Sse2.setzero_si128(), a);
                    v128 zero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(a, 1));
                
                    if (promiseNeitherNaN)
                    {
                        return Sse2.andnot_si128(zero, negative);
                    }
                    else
                    {
                        return ternarylogic_si128(cmpunord_ph(a, a), zero, negative, TernaryOperation.OxO2);
                    }
                }
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    v128 positive = Sse2.cmpgt_epi16(b, Sse2.setzero_si128());
                    v128 zero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(b, 1));
                
                    if (promiseNeitherNaN)
                    {
                        return Sse2.andnot_si128(zero, positive);
                    }
                    else
                    {
                        return ternarylogic_si128(cmpunord_ph(b, b), zero, positive, TernaryOperation.OxO2);
                    }
                }


                v128 equalValues = Sse2.cmpeq_epi16(a, b);
                
                v128 signA = Sse2.srai_epi16(a, 15);
                v128 signB = Sse2.srai_epi16(b, 15);
                v128 equalSigns = Sse2.cmpeq_epi16(signA, signB);
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
                    v128 bothZero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(Sse2.or_si128(a, b), 1));
                    v128 ifOppositeSigns = Sse2.andnot_si128(bothZero, signA);
                    orderedCmp = blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                }
                
                if (promiseNeitherNaN)
                {
                    return orderedCmp;
                }
                else
                {
                    v128 eitherNaN = cmpunord_ph(a, b, elements);
                
                    return Sse2.andnot_si128(eitherNaN, orderedCmp);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmplt_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmple_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU16(b, 0, elements) || constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                {
                    v128 intLEzero = Sse2.cmpgt_epi16(Sse2.set1_epi16(1), a);
                
                    if (promiseNeitherNaN)
                    {
                        return intLEzero;
                    }
                    else
                    {
                        return Sse2.andnot_si128(cmpunord_ph(a, a), intLEzero);
                    }
                }
                if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                {
                    v128 uintGEzero = Sse2.cmpgt_epi16(b, Sse2.setzero_si128());
                    v128 negativeZero = Sse2.cmpeq_epi16(b, Sse2.set1_epi16(unchecked((short)(1 << 15))));
                
                    if (promiseNeitherNaN)
                    {
                        return Sse2.or_si128(uintGEzero, negativeZero);
                    }
                    else
                    {
                        return ternarylogic_si128(cmpunord_ph(b, b), uintGEzero, negativeZero, TernaryOperation.OxOE);
                    }
                }


                v128 equalValues = Sse2.cmpeq_epi16(a, b);

                v128 signA = Sse2.srai_epi16(a, 15);
                v128 signB = Sse2.srai_epi16(b, 15);
                v128 equalSigns = Sse2.cmpeq_epi16(signA, signB);
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
                    v128 bothZero = Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.slli_epi16(Sse2.or_si128(a, b), 1));
                    v128 ifOppositeSigns = Sse2.or_si128(bothZero, signA);
                    orderedCmp = blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                }

                if (promiseNeitherNaN)
                {
                    return orderedCmp;
                }
                else
                {
                    v128 eitherNaN = cmpunord_ph(a, b, elements);

                    return Sse2.andnot_si128(eitherNaN, orderedCmp);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpge_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmple_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpngt_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmple_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpnlt_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmpge_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpnge_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmplt_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpnle_ph(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                return cmpgt_ph(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
            }
            else throw new IllegalInstructionException();
        }
    }
}
