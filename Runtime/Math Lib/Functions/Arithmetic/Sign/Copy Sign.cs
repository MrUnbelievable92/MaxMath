using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
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
            public static v128 movsign_epi8(v128 a, v128 s, bool nonZeroS = false, bool nonNegativeA = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    nonNegativeA |= constexpr.ALL_GE_EPI8(a, 0, elements);
                    
                    if (constexpr.ALL_EQ_EPI8(a, 1, elements) || constexpr.ALL_EQ_EPI8(a, -1, elements))
                    {
                        result = or_si128(srai_epi8(s, 7), set1_epi8(1));
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 compensated = s;
                            if (!(nonZeroS || constexpr.ALL_NEQ_EPI8(s, 0, elements)))
                            {
                                compensated = sub_epi8(s, cmpeq_epi8(s, setzero_si128()));
                            }
                            
                            result = sign_epi8(nonNegativeA ? a : abs_epi8(a, elements), compensated);
                        }
                        else
                        {
                            result = srai_epi8(nonNegativeA ? s : xor_si128(a, s), 7);
                            result = sub_epi8(xor_si128(a, result), result);
                        }
                    }

                    Assume.copysign(result.SByte0,  a.SByte0,  s.SByte0);
                    Assume.copysign(result.SByte1,  a.SByte1,  s.SByte1);
                    Assume.copysign(result.SByte2,  a.SByte2,  s.SByte2);
                    Assume.copysign(result.SByte3,  a.SByte3,  s.SByte3);
                    Assume.copysign(result.SByte4,  a.SByte4,  s.SByte4);
                    Assume.copysign(result.SByte5,  a.SByte5,  s.SByte5);
                    Assume.copysign(result.SByte6,  a.SByte6,  s.SByte6);
                    Assume.copysign(result.SByte7,  a.SByte7,  s.SByte7);
                    Assume.copysign(result.SByte8,  a.SByte8,  s.SByte8);
                    Assume.copysign(result.SByte9,  a.SByte9,  s.SByte9);
                    Assume.copysign(result.SByte10, a.SByte10, s.SByte10);
                    Assume.copysign(result.SByte11, a.SByte11, s.SByte11);
                    Assume.copysign(result.SByte12, a.SByte12, s.SByte12);
                    Assume.copysign(result.SByte13, a.SByte13, s.SByte13);
                    Assume.copysign(result.SByte14, a.SByte14, s.SByte14);
                    Assume.copysign(result.SByte15, a.SByte15, s.SByte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi8(v256 a, v256 s, bool nonZeroS = false, bool nonNegativeA = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    nonNegativeA |= constexpr.ALL_GE_EPI8(a, 0);

                    if (constexpr.ALL_EQ_EPI8(a, 1) || constexpr.ALL_EQ_EPI8(a, -1))
                    {
                        result = Avx2.mm256_or_si256(mm256_srai_epi8(s, 7), mm256_set1_epi8(1));
                    }
                    else
                    {
                        v256 compensated = s;
                        if (!(nonZeroS || constexpr.ALL_NEQ_EPI8(s, 0)))
                        {
                            compensated = Avx2.mm256_sub_epi8(s, Avx2.mm256_cmpeq_epi8(s, Avx.mm256_setzero_si256()));
                        }
                    
                        result = Avx2.mm256_sign_epi8(nonNegativeA ? a : mm256_abs_epi8(a), compensated);
                    }

                    Assume.copysign(result.SByte0,  a.SByte0,  s.SByte0);
                    Assume.copysign(result.SByte1,  a.SByte1,  s.SByte1);
                    Assume.copysign(result.SByte2,  a.SByte2,  s.SByte2);
                    Assume.copysign(result.SByte3,  a.SByte3,  s.SByte3);
                    Assume.copysign(result.SByte4,  a.SByte4,  s.SByte4);
                    Assume.copysign(result.SByte5,  a.SByte5,  s.SByte5);
                    Assume.copysign(result.SByte6,  a.SByte6,  s.SByte6);
                    Assume.copysign(result.SByte7,  a.SByte7,  s.SByte7);
                    Assume.copysign(result.SByte8,  a.SByte8,  s.SByte8);
                    Assume.copysign(result.SByte9,  a.SByte9,  s.SByte9);
                    Assume.copysign(result.SByte10, a.SByte10, s.SByte10);
                    Assume.copysign(result.SByte11, a.SByte11, s.SByte11);
                    Assume.copysign(result.SByte12, a.SByte12, s.SByte12);
                    Assume.copysign(result.SByte13, a.SByte13, s.SByte13);
                    Assume.copysign(result.SByte14, a.SByte14, s.SByte14);
                    Assume.copysign(result.SByte15, a.SByte15, s.SByte15);
                    Assume.copysign(result.SByte16, a.SByte16, s.SByte16);
                    Assume.copysign(result.SByte17, a.SByte17, s.SByte17);
                    Assume.copysign(result.SByte18, a.SByte18, s.SByte18);
                    Assume.copysign(result.SByte19, a.SByte19, s.SByte19);
                    Assume.copysign(result.SByte20, a.SByte20, s.SByte20);
                    Assume.copysign(result.SByte21, a.SByte21, s.SByte21);
                    Assume.copysign(result.SByte22, a.SByte22, s.SByte22);
                    Assume.copysign(result.SByte23, a.SByte23, s.SByte23);
                    Assume.copysign(result.SByte24, a.SByte24, s.SByte24);
                    Assume.copysign(result.SByte25, a.SByte25, s.SByte25);
                    Assume.copysign(result.SByte26, a.SByte26, s.SByte26);
                    Assume.copysign(result.SByte27, a.SByte27, s.SByte27);
                    Assume.copysign(result.SByte28, a.SByte28, s.SByte28);
                    Assume.copysign(result.SByte29, a.SByte29, s.SByte29);
                    Assume.copysign(result.SByte30, a.SByte30, s.SByte30);
                    Assume.copysign(result.SByte31, a.SByte31, s.SByte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi16(v128 a, v128 s, bool nonZeroS = false, bool nonNegativeA = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    nonNegativeA |= constexpr.ALL_GE_EPI16(a, 0, elements);
                    
                    if (constexpr.ALL_EQ_EPI16(a, 1, elements) || constexpr.ALL_EQ_EPI16(a, -1, elements))
                    {
                        result = or_si128(srai_epi16(s, 15), set1_epi16(1));
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 compensated = s;
                            if (!(nonZeroS || constexpr.ALL_NEQ_EPI16(s, 0, elements)))
                            {
                                compensated = sub_epi16(s, cmpeq_epi16(s, setzero_si128()));
                            }
                            
                            result = sign_epi16(nonNegativeA ? a : abs_epi16(a, elements), compensated);
                        }
                        else
                        {
                            result = srai_epi16(nonNegativeA ? s : xor_si128(a, s), 15);
                            result = sub_epi16(xor_si128(a, result), result);
                        }
                    }

                    Assume.copysign(result.SShort0, a.SShort0, s.SShort0);
                    Assume.copysign(result.SShort1, a.SShort1, s.SShort1);
                    Assume.copysign(result.SShort2, a.SShort2, s.SShort2);
                    Assume.copysign(result.SShort3, a.SShort3, s.SShort3);
                    Assume.copysign(result.SShort4, a.SShort4, s.SShort4);
                    Assume.copysign(result.SShort5, a.SShort5, s.SShort5);
                    Assume.copysign(result.SShort6, a.SShort6, s.SShort6);
                    Assume.copysign(result.SShort7, a.SShort7, s.SShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi16(v256 a, v256 s, bool nonZeroS = false, bool nonNegativeA = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    nonNegativeA |= constexpr.ALL_GE_EPI16(a, 0);

                    if (constexpr.ALL_EQ_EPI16(a, 1) || constexpr.ALL_EQ_EPI16(a, -1))
                    {
                        result = Avx2.mm256_or_si256(mm256_srai_epi16(s, 15), mm256_set1_epi16(1));
                    }
                    else
                    {
                        v256 compensated = s;
                        if (!(nonZeroS || constexpr.ALL_NEQ_EPI16(s, 0)))
                        {
                            compensated = Avx2.mm256_sub_epi16(s, Avx2.mm256_cmpeq_epi16(s, Avx.mm256_setzero_si256()));
                        }
                    
                        result = Avx2.mm256_sign_epi16(nonNegativeA ? a : mm256_abs_epi16(a), compensated);
                    }

                    Assume.copysign(result.SShort0,  a.SShort0,  s.SShort0);
                    Assume.copysign(result.SShort1,  a.SShort1,  s.SShort1);
                    Assume.copysign(result.SShort2,  a.SShort2,  s.SShort2);
                    Assume.copysign(result.SShort3,  a.SShort3,  s.SShort3);
                    Assume.copysign(result.SShort4,  a.SShort4,  s.SShort4);
                    Assume.copysign(result.SShort5,  a.SShort5,  s.SShort5);
                    Assume.copysign(result.SShort6,  a.SShort6,  s.SShort6);
                    Assume.copysign(result.SShort7,  a.SShort7,  s.SShort7);
                    Assume.copysign(result.SShort8,  a.SShort8,  s.SShort8);
                    Assume.copysign(result.SShort9,  a.SShort9,  s.SShort9);
                    Assume.copysign(result.SShort10, a.SShort10, s.SShort10);
                    Assume.copysign(result.SShort11, a.SShort11, s.SShort11);
                    Assume.copysign(result.SShort12, a.SShort12, s.SShort12);
                    Assume.copysign(result.SShort13, a.SShort13, s.SShort13);
                    Assume.copysign(result.SShort14, a.SShort14, s.SShort14);
                    Assume.copysign(result.SShort15, a.SShort15, s.SShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi32(v128 a, v128 s, bool nonZeroS = false, bool nonNegativeA = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    nonNegativeA |= constexpr.ALL_GE_EPI32(a, 0, elements);
                    
                    if (constexpr.ALL_EQ_EPI32(a, 1, elements) || constexpr.ALL_EQ_EPI32(a, -1, elements))
                    {
                        result = or_si128(srai_epi32(s, 31), set1_epi32(1));
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 compensated = s;
                            if (!(nonZeroS || constexpr.ALL_NEQ_EPI32(s, 0, elements)))
                            {
                                compensated = sub_epi32(s, cmpeq_epi32(s, setzero_si128()));
                            }
                            
                            result = sign_epi32(nonNegativeA ? a : abs_epi32(a, elements), compensated);
                        }
                        else
                        {
                            result = srai_epi32(nonNegativeA ? s : xor_si128(a, s), 31);
                            result = sub_epi32(xor_si128(a, result), result);
                        }
                    }

                    Assume.copysign(result.SInt0, a.SInt0, s.SInt0);
                    Assume.copysign(result.SInt1, a.SInt1, s.SInt1);
                    Assume.copysign(result.SInt2, a.SInt2, s.SInt2);
                    Assume.copysign(result.SInt3, a.SInt3, s.SInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi32(v256 a, v256 s, bool nonZeroS = false, bool nonNegativeA = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    nonNegativeA |= constexpr.ALL_GE_EPI32(a, 0);

                    if (constexpr.ALL_EQ_EPI32(a, 1) || constexpr.ALL_EQ_EPI32(a, -1))
                    {
                        result = Avx2.mm256_or_si256(mm256_srai_epi32(s, 15), mm256_set1_epi32(1));
                    }
                    else
                    {
                        v256 compensated = s;
                        if (!(nonZeroS || constexpr.ALL_NEQ_EPI32(s, 0)))
                        {
                            compensated = Avx2.mm256_sub_epi32(s, Avx2.mm256_cmpeq_epi32(s, Avx.mm256_setzero_si256()));
                        }
                    
                        result = Avx2.mm256_sign_epi32(nonNegativeA ? a : mm256_abs_epi32(a), compensated);
                    }

                    Assume.copysign(result.SInt0, a.SInt0, s.SInt0);
                    Assume.copysign(result.SInt1, a.SInt1, s.SInt1);
                    Assume.copysign(result.SInt2, a.SInt2, s.SInt2);
                    Assume.copysign(result.SInt3, a.SInt3, s.SInt3);
                    Assume.copysign(result.SInt4, a.SInt4, s.SInt4);
                    Assume.copysign(result.SInt5, a.SInt5, s.SInt5);
                    Assume.copysign(result.SInt6, a.SInt6, s.SInt6);
                    Assume.copysign(result.SInt7, a.SInt7, s.SInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi64(v128 a, v128 s, bool nonNegativeA = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonNegativeA |= constexpr.ALL_GE_EPI64(a, 0);

                    v128 result;

                    if (constexpr.ALL_EQ_EPI64(a, 1) || constexpr.ALL_EQ_EPI64(a, -1))
                    {
                        result = or_si128(set1_epi64x(1), srai_epi64(s, 63));
                    }
                    else
                    {
                        result = srai_epi64(nonNegativeA ? s : xor_si128(a, s), 63);
                        result = sub_epi64(xor_si128(a, result), result);
                    }

                    Assume.copysign(result.SLong0, a.SLong0, s.SLong0);
                    Assume.copysign(result.SLong1, a.SLong1, s.SLong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi64(v256 a, v256 s, byte elements = 4, bool nonNegativeA = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonNegativeA |= constexpr.ALL_GE_EPI64(a, 0, elements);

                    v256 result;

                    if (constexpr.ALL_EQ_EPI64(a, 1, elements) || constexpr.ALL_EQ_EPI64(a, -1, elements))
                    {
                        result = Avx2.mm256_or_si256(mm256_set1_epi64x(1), mm256_srai_epi64(s, 63, elements));
                    }
                    else
                    {
                        result = mm256_srai_epi64(nonNegativeA ? s : Avx2.mm256_xor_si256(a, s), 63);
                        result = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, result), result);
                    }

                    Assume.copysign(result.SLong0, a.SLong0, s.SLong0);
                    Assume.copysign(result.SLong1, a.SLong1, s.SLong1);
                    Assume.copysign(result.SLong2, a.SLong2, s.SLong2);
                    Assume.copysign(result.SLong3, a.SLong3, s.SLong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_pq(v128 a, v128 s, bool promise = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MASK = set1_epi8(1 << 7);

                    if (!promise)
                    {
                        v128 isZero = cmpeq_epi8(and_si128(s, set1_epi8(0x7F)), setzero_si128());

                        s = andnot_si128(isZero, srai_epi8(s, 7));
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_pq(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = mm256_set1_epi8(1 << 7);

                    if (!promise)
                    {
                        v256 isZero = Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(s, mm256_set1_epi8(0x7F)), Avx.mm256_setzero_si256());

                        s = Avx2.mm256_andnot_si256(isZero, mm256_srai_epi8(s, 7));
                    }

                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_ph(v128 a, v128 s, bool promise = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MASK = set1_epi16(1 << 15);

                    if (!promise)
                    {
                        v128 isZero = cmpeq_epi16(and_si128(s, set1_epi16(0x7FFF)), setzero_si128());

                        s = andnot_si128(isZero, srai_epi16(s, 15));
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_ph(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = mm256_set1_epi16(1 << 15);

                    if (!promise)
                    {
                        v256 isZero = Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(s, mm256_set1_epi16(0x7FFF)), Avx.mm256_setzero_si256());

                        s = Avx2.mm256_andnot_si256(isZero, Avx2.mm256_srai_epi16(s, 15));
                    }

                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_ps(v128 a, v128 s, bool promise = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MASK = new v128(1 << 31);

                    if (!promise)
                    {
                        s = cmplt_ps(s, setzero_ps());
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_ps(v256 a, v256 s, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(1 << 31);

                    if (!promise)
                    {
                        s = mm256_cmplt_ps(s, Avx.mm256_setzero_ps());
                    }

                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_pd(v128 a, v128 s, bool promise = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MASK = new v128(1L << 63);

                    if (!promise)
                    {
                        s = cmplt_pd(s, setzero_ps());
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_pd(v256 a, v256 s, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(1L << 63);

                    if (!promise)
                    {
                        s = mm256_cmplt_pd(s, Avx.mm256_setzero_pd());
                    }

                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }
        }
    }
    

    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void copysign(sbyte result, sbyte x, sbyte y)
        {
            if (constexpr.IS_TRUE(x != sbyte.MinValue))
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : result >= 0);
            }
            else
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : (result >= 0 || (x == sbyte.MinValue && result == sbyte.MinValue)));
            }
                
            constexpr.ASSUME(y < 0 ? result == math.nabs(x) : result == math.abs(x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void copysign(short result, short x, short y)
        {
            if (constexpr.IS_TRUE(x != short.MinValue))
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : result >= 0);
            }
            else
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : (result >= 0 || (x == short.MinValue && result == short.MinValue)));
            }
                
            constexpr.ASSUME(y < 0 ? result == math.nabs(x) : result == math.abs(x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void copysign(int result, int x, int y)
        {
            if (constexpr.IS_TRUE(x != int.MinValue))
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : result >= 0);
            }
            else
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : (result >= 0 || (x == int.MinValue && result == int.MinValue)));
            }
                
            constexpr.ASSUME(y < 0 ? result == math.nabs(x) : result == math.abs(x));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void copysign(long result, long x, long y)
        {
            if (constexpr.IS_TRUE(x != long.MinValue))
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : result >= 0);
            }
            else
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : (result >= 0 || (x == long.MinValue && result == long.MinValue)));
            }
                
            constexpr.ASSUME(y < 0 ? result == math.nabs(x) : result == math.abs(x));
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 copysign(Int128 x, Int128 y)
        {
            ulong temp = (ulong)((long)(x.hi64 ^ y.hi64) >> 63);
            ulong lo = x.lo64 ^ temp;
            ulong hi = x.hi64 ^ temp;
            ulong loResult = lo - temp;
            ulong hiResult = hi - temp;
            hiResult -= tobyte(lo < temp);

            Int128 result = new Int128(loResult, hiResult);
            
            if (constexpr.IS_TRUE(x != Int128.MinValue))
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : result >= 0);
            }
            else
            {
                constexpr.ASSUME(y < 0 ? result <= 0 : (result >= 0 || (x == Int128.MinValue && result == Int128.MinValue)));
            }
                
            constexpr.ASSUME(y < 0 ? result == math.nabs(x) : result == math.abs(x));

            return result;
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte copysign(sbyte x, sbyte y)
        {
            return (sbyte)copysign((int)x, (int)y);
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 copysign(sbyte2 x, sbyte2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                sbyte2 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 copysign(sbyte3 x, sbyte3 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                sbyte3 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 copysign(sbyte4 x, sbyte4 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                sbyte4 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 copysign(sbyte8 x, sbyte8 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                sbyte8 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 copysign(sbyte16 x, sbyte16 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 16);
            }
            else
            {
                sbyte16 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 copysign(sbyte32 x, sbyte32 y, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi8(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(copysign(x.v16_0, y.v16_0, promises), copysign(x.v16_16, y.v16_16, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short copysign(short x, short y)
        {
            return (short)copysign((int)x, (int)y);
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 copysign(short2 x, short2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                short2 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 copysign(short3 x, short3 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                short3 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 copysign(short4 x, short4 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                short4 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 copysign(short8 x, short8 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                short8 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 copysign(short16 x, short16 y, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi16(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short16(copysign(x.v8_0, y.v8_0, promises), copysign(x.v8_8, y.v8_8, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int copysign(int x, int y)
        {
            int result;

            if (constexpr.IS_TRUE(x == 1 || x == -1))
            {
                result = (y >> 31) | 1;
            }
            else
            {
                int temp = (x ^ y) >> 31;
                result = (x ^ temp) - temp;
            }

            Assume.copysign(result, x, y);

            return result;
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 copysign(int2 x, int2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi32(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                int2 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 copysign(int3 x, int3 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi32(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                int3 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 copysign(int4 x, int4 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi32(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                int4 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 copysign(int8 x, int8 y, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi32(x, y, promises.Promises(Promise.NonZero), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int8(copysign(x.v4_0, y.v4_0, promises), copysign(x.v4_4, y.v4_4, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long copysign(long x, long y)
        {
            long result;

            if (constexpr.IS_TRUE(x == 1 || x == -1))
            {
                result = (y >> 63) | 1;
            }
            else
            {
                long temp = (x ^ y) >> 63;
                result = (x ^ temp) - temp;
            }

            Assume.copysign(result, x, y);

            return result;
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 copysign(long2 x, long2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_epi64(x, y, nonNegativeA: promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                long2 temp = (x ^ y) >> 63;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 copysign(long3 x, long3 y, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi64(x, y, 3, nonNegativeA: promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long3(copysign(x.xy, y.xy, promises), copysign(x.z, y.z));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> component that is negative.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 copysign(long4 x, long4 y, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi64(x, y, 4, nonNegativeA: promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long4(copysign(x.xy, y.xy, promises), copysign(x.zw, y.zw, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter copysign(quarter x, quarter y, Promise promises = Promise.Nothing)
        {
            const byte SIGN_MASK = 1 << 7;
            const byte VALUE_MASK = unchecked((byte)(~SIGN_MASK));

            byte _x = asbyte(x);
            byte _y = asbyte(y);

            uint xAbs = (uint)_x & (uint)VALUE_MASK;
            uint ySign;

            if (promises.Promises(Promise.NonZero))
            {
                ySign = SIGN_MASK & (uint)_y;
            }
            else
            {
                ySign = _y & (touint(y != 0) << 7);
            }

            return asquarter((byte)(xAbs | ySign));
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 copysign(quarter2 x, quarter2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter2(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 copysign(quarter3 x, quarter3 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter3(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises), copysign(x.z, y.z, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 copysign(quarter4 x, quarter4 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter4(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises), copysign(x.z, y.z, promises), copysign(x.w, y.w, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 copysign(quarter8 x, quarter8 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter8(copysign(x.x0, y.x0, promises),
                                    copysign(x.x1, y.x1, promises),
                                    copysign(x.x2, y.x2, promises),
                                    copysign(x.x3, y.x3, promises),
                                    copysign(x.x4, y.x4, promises),
                                    copysign(x.x5, y.x5, promises),
                                    copysign(x.x6, y.x6, promises),
                                    copysign(x.x7, y.x7, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 copysign(quarter16 x, quarter16 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter16(copysign(x.x0,  y.x0,  promises),
                                     copysign(x.x1,  y.x1,  promises),
                                     copysign(x.x2,  y.x2,  promises),
                                     copysign(x.x3,  y.x3,  promises),
                                     copysign(x.x4,  y.x4,  promises),
                                     copysign(x.x5,  y.x5,  promises),
                                     copysign(x.x6,  y.x6,  promises),
                                     copysign(x.x7,  y.x7,  promises),
                                     copysign(x.x8,  y.x8,  promises),
                                     copysign(x.x9,  y.x9,  promises),
                                     copysign(x.x10, y.x10, promises),
                                     copysign(x.x11, y.x11, promises),
                                     copysign(x.x12, y.x12, promises),
                                     copysign(x.x13, y.x13, promises),
                                     copysign(x.x14, y.x14, promises),
                                     copysign(x.x15, y.x15, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 copysign(quarter32 x, quarter32 y, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_pq(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter32(copysign(x.v16_0, y.v16_0, promises), copysign(x.v16_16, y.v16_16, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half copysign(half x, half y, Promise promises = Promise.Nothing)
        {
            const ushort SIGN_MASK = 1 << 15;
            const ushort VALUE_MASK = unchecked((ushort)(~SIGN_MASK));

            ushort _x = asushort(x);
            ushort _y = asushort(y);

            uint xAbs = (uint)_x & (uint)VALUE_MASK;
            uint ySign;

            if (promises.Promises(Promise.NonZero))
            {
                ySign = SIGN_MASK & (uint)_y;
            }
            else
            {
                ySign = _y & (touint(y != 0) << 15);
            }

            return ashalf((ushort)(xAbs | ySign));
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 copysign(half2 x, half2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ph(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half2(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 copysign(half3 x, half3 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ph(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half3(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises), copysign(x.z, y.z, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 copysign(half4 x, half4 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ph(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half4(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises), copysign(x.z, y.z, promises), copysign(x.w, y.w, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 copysign(half8 x, half8 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ph(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half8(copysign(x.x0, y.x0, promises), copysign(x.x1, y.x1, promises), copysign(x.x2, y.x2, promises), copysign(x.x3, y.x3, promises), copysign(x.x4, y.x4, promises), copysign(x.x5, y.x5, promises), copysign(x.x6, y.x6, promises), copysign(x.x7, y.x7, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 copysign(half16 x, half16 y, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_ph(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half16(copysign(x.v8_0, y.v8_0, promises), copysign(x.v8_8, y.v8_8, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float copysign(float x, float y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ps(Xse.set_ss(x), Xse.set_ss(y), promises.Promises(Promise.NonZero)).Float0;
            }
            else
            {
                const uint SIGN_MASK = 1u << 31;
                const uint VALUE_MASK = ~SIGN_MASK;

                uint _x = asuint(x);
                uint _y = asuint(y);

                uint xAbs = _x & VALUE_MASK;
                uint ySign;

                if (promises.Promises(Promise.NonZero))
                {
                    ySign = SIGN_MASK & _y;
                }
                else
                {
                    ySign = _y & (touint(y != 0) << 31);
                }

                return asfloat(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>       A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 copysign(float2 x, float2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ps(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new float2(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 copysign(float3 x, float3 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ps(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new float3(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises), copysign(x.z, y.z, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 copysign(float4 x, float4 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_ps(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new float4(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises), copysign(x.z, y.z, promises), copysign(x.w, y.w, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 copysign(float8 x, float8 y, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_movsign_ps(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new float8(copysign(x.v4_0, y.v4_0, promises),
                                  copysign(x.v4_4, y.v4_4, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double copysign(double x, double y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_pd(Xse.set_sd(x), Xse.set_sd(y), promises.Promises(Promise.NonZero)).Double0;
            }
            else
            {
                const ulong MASK = 1ul << 63;

                ulong _x = asulong(x);
                ulong _y = asulong(y);

                ulong xAbs = andnot(_x, MASK);
                ulong ySign;

                if (promises.Promises(Promise.NonZero))
                {
                    ySign = MASK & _y;
                }
                else
                {
                    ySign = _y & (toulong(y != 0) << 63);
                }

                return asdouble(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 copysign(double2 x, double2 y, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.movsign_pd(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new double2(copysign(x.x, y.x, promises), copysign(x.y, y.y, promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 copysign(double3 x, double3 y, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_movsign_pd(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new double3(copysign(x.xy, y.xy, promises),
                                   copysign(x.z,  y.z,  promises));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 copysign(double4 x, double4 y, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_movsign_pd(x, y, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new double4(copysign(x.xy, y.xy, promises),
                                   copysign(x.zw, y.zw, promises));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        /// <remarks>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple copysign(quadruple x, quadruple y, Promise nonZero = Promise.Nothing)
        {
            UInt128 SIGN_MASK = (UInt128)1u << 127;
            UInt128 VALUE_MASK = ~SIGN_MASK;

            UInt128 _x = asuint128(x);
            UInt128 _y = asuint128(y);

            UInt128 xAbs = new UInt128(_x.lo64, _x.hi64 & VALUE_MASK.hi64);
            ulong ySign;

            if (nonZero.Promises(Promise.NonZero))
            {
                ySign = SIGN_MASK.hi64 & _y.hi64;
            }
            else
            {
                ySign = _y.hi64 & (toulong(quadruple.IsNotZero(y)) << 63);
            }

            return asquadruple(new UInt128(xAbs.lo64, xAbs.hi64 | ySign));
        }
    }
}