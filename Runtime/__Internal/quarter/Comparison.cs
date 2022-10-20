using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public readonly partial struct quarter : IEquatable<quarter>, IComparable<quarter>, IComparable, IFormattable, IConvertible
    {
        internal static partial class Vectorized
        {
            private static v128 ABS_MASK
            {
                get
                {
                    if (Sse2.IsSse2Supported)
                    {
                        return Sse2.set1_epi8(unchecked((sbyte)((1 << (BITS - 1)) - 1)));
                    }
                    else throw new IllegalInstructionException();
                }
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpord_pq(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.ALL_LT_EPU8(a, 1 << 7) && Xse.constexpr.ALL_LT_EPU8(b, 1 << 7))
                    {
                        return Sse2.and_si128(Sse2.cmpgt_epi8(Sse2.set1_epi8(SIGNALING_EXPONENT + 1), a),
                                              Sse2.cmpgt_epi8(Sse2.set1_epi8(SIGNALING_EXPONENT + 1), b));
                    }
                    else
                    {
                        return Sse2.and_si128(Sse2.cmpgt_epi8(Sse2.set1_epi8(SIGNALING_EXPONENT + 1), Sse2.and_si128(a, ABS_MASK)),
                                              Sse2.cmpgt_epi8(Sse2.set1_epi8(SIGNALING_EXPONENT + 1), Sse2.and_si128(b, ABS_MASK)));
                    }

                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpunord_pq(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.ALL_LT_EPU8(a, 1 << 7) && Xse.constexpr.ALL_LT_EPU8(b, 1 << 7))
                    {
                        return Sse2.or_si128(Sse2.cmpgt_epi8(Sse2.and_si128(a, ABS_MASK), Sse2.set1_epi8(SIGNALING_EXPONENT)),
                                             Sse2.cmpgt_epi8(Sse2.and_si128(b, ABS_MASK), Sse2.set1_epi8(SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        return Sse2.or_si128(Sse2.cmpgt_epi8(a, Sse2.set1_epi8(SIGNALING_EXPONENT)),
                                             Sse2.cmpgt_epi8(b, Sse2.set1_epi8(SIGNALING_EXPONENT)));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpeq_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.ALL_EQ_EPU8(a, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return Sse2.cmpeq_epi8(Xse.slli_epi8(b, 1), Sse2.setzero_si128());
                        }
                        else
                        {
                            return Sse2.andnot_si128(cmpunord_pq(b, b), Sse2.cmpeq_epi8(Xse.slli_epi8(b, 1), Sse2.setzero_si128()));
                        }
                    }
                    else if (Xse.constexpr.ALL_EQ_EPU8(b, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return Sse2.cmpeq_epi8(Xse.slli_epi8(a, 1), Sse2.setzero_si128());
                        }
                        else
                        {
                            return Sse2.andnot_si128(cmpunord_pq(a, a), Sse2.cmpeq_epi8(Xse.slli_epi8(a, 1), Sse2.setzero_si128()));
                        }
                    } 
                    else
                    {
                        v128 equalValues = Sse2.cmpeq_epi8(a, b);

                        if (promiseNeitherNaN)
                        {
                            if (promiseNeitherZero)
                            {
                                return equalValues;
                            }
                            else
                            {
                                v128 bothZero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(Sse2.or_si128(a, b), 1));
                                
                                return Sse2.or_si128(bothZero, equalValues);
                            }
                        }
                        else
                        {
                            v128 eitherNaN = cmpunord_pq(a, b, elements);

                            if (promiseNeitherZero)
                            {
                                return Sse2.andnot_si128(eitherNaN, equalValues);
                            }
                            else
                            {
                                v128 bothZero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(Sse2.or_si128(a, b), 1));

                                return Xse.ternarylogic_si128(eitherNaN, bothZero, equalValues, TernaryOperation.OxOE);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpneq_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.ALL_EQ_EPU8(a, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return Xse.not_si128(Sse2.cmpeq_epi8(Xse.slli_epi8(b, 1), Sse2.setzero_si128()));
                        }
                        else
                        {
                            return Sse2.andnot_si128(Sse2.cmpeq_epi8(Xse.slli_epi8(b, 1), Sse2.setzero_si128()), cmpord_pq(b, b));
                        }
                    }
                    else if (Xse.constexpr.ALL_EQ_EPU8(b, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        if (promiseNeitherNaN)
                        {
                            return Xse.not_si128(Sse2.cmpeq_epi8(Xse.slli_epi8(a, 1), Sse2.setzero_si128()));
                        }
                        else
                        {
                            return Sse2.andnot_si128(Sse2.cmpeq_epi8(Xse.slli_epi8(a, 1), Sse2.setzero_si128()), cmpord_pq(a, a));
                        }
                    } 
                    else
                    {
                        v128 equalValues = Sse2.cmpeq_epi8(a, b);
                        
                        if (promiseNeitherNaN)
                        {
                            if (promiseNeitherZero)
                            {
                                return Xse.not_si128(equalValues);
                            }
                            else
                            {
                                v128 bothZero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(Sse2.or_si128(a, b), 1));
                                
                                return Xse.nor_si128(equalValues, bothZero);
                            }
                        }
                        else
                        {
                            v128 eitherNaN = cmpunord_pq(a, b, elements);
                        
                            if (promiseNeitherZero)
                            {
                                return Xse.ornot_si128(equalValues, eitherNaN);
                            }
                            else
                            {
                                v128 bothZero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(Sse2.or_si128(a, b), 1));
                        
                                return Xse.ternarylogic_si128(eitherNaN, bothZero, equalValues, TernaryOperation.OxF1);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmplt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.ALL_EQ_EPU8(b, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        v128 negative = Sse2.cmpgt_epi8(Sse2.setzero_si128(), a);
                        v128 zero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(a, 1));
                    
                        if (promiseNeitherNaN)
                        {
                            return Sse2.andnot_si128(zero, negative);
                        }
                        else
                        {
                            return Xse.ternarylogic_si128(cmpunord_pq(a, a), zero, negative, TernaryOperation.OxO2);
                        }
                    }
                    if (Xse.constexpr.ALL_EQ_EPU8(a, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        v128 positive = Sse2.cmpgt_epi8(b, Sse2.setzero_si128());
                        v128 zero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(b, 1));
                    
                        if (promiseNeitherNaN)
                        {
                            return Sse2.andnot_si128(zero, positive);
                        }
                        else
                        {
                            return Xse.ternarylogic_si128(cmpunord_pq(b, b), zero, positive, TernaryOperation.OxO2);
                        }
                    }


                    v128 equalValues = Sse2.cmpeq_epi8(a, b);

                    v128 signA = Xse.srai_epi8(a, 7);
                    v128 signB = Xse.srai_epi8(b, 7);
                    v128 equalSigns = Sse2.cmpeq_epi8(signA, signB);
                    v128 ifEqualSigns;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ifEqualSigns = Xse.ternarylogic_si128(equalValues, signA, Xse.cmple_epu8(b, a, elements), TernaryOperation.OxO9);
                    //}
                    //else
                    //{
                          ifEqualSigns = Xse.ternarylogic_si128(equalValues, signA, Xse.cmpgt_epu8(b, a, elements), TernaryOperation.OxO6);
                    //}

                    v128 orderedCmp;
                    if (promiseNeitherZero)
                    {
                        orderedCmp = Xse.blendv_si128(signA, ifEqualSigns, equalSigns);
                    }
                    else
                    {
                        v128 bothZero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(Sse2.or_si128(a, b), 1));
                        v128 ifOppositeSigns = Sse2.andnot_si128(bothZero, signA);
                        orderedCmp = Xse.blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                    }

                    if (promiseNeitherNaN)
                    {
                        return orderedCmp;
                    }
                    else
                    {
                        v128 eitherNaN = cmpunord_pq(a, b, elements);

                        return Sse2.andnot_si128(eitherNaN, orderedCmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpgt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return cmplt_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmple_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.ALL_EQ_EPU8(b, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                    {
                        v128 intLEzero = Sse2.cmpgt_epi8(Sse2.set1_epi8(1), a);
                    
                        if (promiseNeitherNaN)
                        {
                            return intLEzero;
                        }
                        else
                        {
                            return Sse2.andnot_si128(cmpunord_pq(a, a), intLEzero);
                        }
                    }
                    if (Xse.constexpr.ALL_EQ_EPU8(a, 0, elements) || Xse.constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                    {
                        v128 uintGEzero = Sse2.cmpgt_epi8(b, Sse2.setzero_si128());
                        v128 negativeZero = Sse2.cmpeq_epi8(b, Sse2.set1_epi8(unchecked((sbyte)(1 << 7))));
                    
                        if (promiseNeitherNaN)
                        {
                            return Sse2.or_si128(uintGEzero, negativeZero);
                        }
                        else
                        {
                            return Xse.ternarylogic_si128(cmpunord_pq(b, b), uintGEzero, negativeZero, TernaryOperation.OxOE);
                        }
                    }


                    v128 equalValues = Sse2.cmpeq_epi8(a, b);

                    v128 signA = Xse.srai_epi8(a, 7);
                    v128 signB = Xse.srai_epi8(b, 7);
                    v128 equalSigns = Sse2.cmpeq_epi8(signA, signB);
                    v128 ifEqualSigns;
                    //if (Avx512.IsAvx512Supported)
                    //{
                    //    ifEqualSigns = Xse.ternarylogic_si128(equalValues, signA, Xse.cmple_epu8(b, a, elements), TernaryOperation.OxF9);
                    //}
                    //else
                    //{
                          ifEqualSigns = Xse.ternarylogic_si128(equalValues, signA, Xse.cmpgt_epu8(b, a, elements), TernaryOperation.OxF6);
                    //}

                    v128 orderedCmp;
                    if (promiseNeitherZero)
                    {
                        orderedCmp = Xse.blendv_si128(Xse.setall_si128(), ifEqualSigns, equalSigns);
                    }
                    else
                    {
                        v128 bothZero = Sse2.cmpeq_epi8(Sse2.setzero_si128(), Xse.slli_epi8(Sse2.or_si128(a, b), 1));
                        v128 ifOppositeSigns = Sse2.or_si128(bothZero, signA);
                        orderedCmp = Xse.blendv_si128(ifOppositeSigns, ifEqualSigns, equalSigns);
                    }

                    if (promiseNeitherNaN)
                    {
                        return orderedCmp;
                    }
                    else
                    {
                        v128 eitherNaN = cmpunord_pq(a, b, elements);

                        return Sse2.andnot_si128(eitherNaN, orderedCmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpge_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return cmple_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpngt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return cmple_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnlt_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return cmpge_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnge_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return cmplt_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnle_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return cmpgt_pq(b, a, promiseNeitherNaN, promiseNeitherZero, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool vcmpeq_pq(v128 a, v128 b, bool promiseNeitherNaN = false, bool promiseNeitherZero = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Xse.alltrue_epi128<quarter>(cmpeq_pq(a, b, promiseNeitherNaN, promiseNeitherZero, elements), elements);
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
