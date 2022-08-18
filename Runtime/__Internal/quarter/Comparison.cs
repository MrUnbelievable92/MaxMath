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
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpeq_pq(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = Sse2.set1_epi8(unchecked((sbyte)((1 << (BITS - 1)) - 1)));

                    if (Xse.constexpr.ALL_EQ_EPU8(a, 0, elements))
                    {
                        return Sse2.cmpeq_epi8(Sse2.and_si128(b, MASK), Sse2.setzero_si128());
                    }
                    else if (Xse.constexpr.ALL_EQ_EPU8(b, 0, elements))
                    {
                        return Sse2.cmpeq_epi8(Sse2.and_si128(a, MASK), Sse2.setzero_si128());
                    } 
                    else
                    {
                        v128 maskeda = Sse2.and_si128(a, MASK);
                        v128 maskedb = Sse2.and_si128(b, MASK);

                        v128 nan = /*NOT!!*/Sse2.or_si128(Sse2.cmpgt_epi8(maskeda, Sse2.set1_epi8(SIGNALING_EXPONENT)),
                                                          Sse2.cmpgt_epi8(maskedb, Sse2.set1_epi8(SIGNALING_EXPONENT)));

                        v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(Sse2.setzero_si128(), maskeda),
                                                   Sse2.cmpeq_epi8(Sse2.setzero_si128(), maskedb));

                        v128 value = Sse2.cmpeq_epi8(a, b);

                        return Xse.ternarylogic_si128(nan, zero, value, TernaryOperation.OxOE);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpneq_pq(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 MASK = Sse2.set1_epi8(unchecked((sbyte)((1 << (BITS - 1)) - 1)));

                    if (Xse.constexpr.ALL_EQ_EPU8(a, 0, elements))
                    {
                        return Xse.not_si128(Sse2.cmpeq_epi8(Sse2.and_si128(b, MASK), Sse2.setzero_si128()));
                    }
                    else if (Xse.constexpr.ALL_EQ_EPU8(b, 0, elements))
                    {
                        return Xse.not_si128(Sse2.cmpeq_epi8(Sse2.and_si128(a, MASK), Sse2.setzero_si128()));
                    } 
                    else
                    {
                        v128 maskedLeft = Sse2.and_si128(a, MASK);
                        v128 maskedRight = Sse2.and_si128(b, MASK);

                        v128 nan = Sse2.or_si128(Sse2.cmpgt_epi8(maskedLeft, Sse2.set1_epi8(SIGNALING_EXPONENT)),
                                                 Sse2.cmpgt_epi8(maskedRight, Sse2.set1_epi8(SIGNALING_EXPONENT)));

                        v128 zero = /*NOT!!*/Sse2.and_si128(Sse2.cmpeq_epi8(Sse2.setzero_si128(), maskedLeft),
                                                            Sse2.cmpeq_epi8(Sse2.setzero_si128(), maskedRight));

                        v128 value = /*NOT!!*/Sse2.cmpeq_epi8(a, b);
                        
                        return Xse.ternarylogic_si128(nan, zero, value, TernaryOperation.OxF1);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool vcmpeq_pq(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Xse.alltrue_epi128<quarter>(cmpeq_pq(a, b, elements), elements);
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
