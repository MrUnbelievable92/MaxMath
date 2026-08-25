using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi8(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    
                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi8(set1_epi8(1), a);
                    }
                    else
                    {
                        v128 ONE = set1_epi8(1);

                        if (ge0 || constexpr.ALL_GE_EPI8(a, 0, elements))
                        {
                            result = andnot_si128(cmpeq_epi8(a, setzero_si128()), ONE);
                        }
                        else if (le0 || constexpr.ALL_LE_EPI8(a, 0, elements))
                        {
                            result = srai_epi8(a, 7, elements: elements);
                        }
                        else if (non0 || constexpr.ALL_NEQ_EPI8(a, 0, elements))
                        {
                            result = or_si128(ONE, srai_epi8(a, 7, elements: elements));
                        }
                        else
                        {
                            result = sub_epi8(srai_epi8(a, 7, elements: elements), cmpgt_epi8(a, setzero_si128()));
                        }
                    }

                    Assume.sign(result.SByte0,  a.SByte0);
                    Assume.sign(result.SByte1,  a.SByte1);

                    if (elements > 2)
                    {
                        Assume.sign(result.SByte2,  a.SByte2);

                        if (elements > 3)
                        {
                            Assume.sign(result.SByte3,  a.SByte3);

                            if (elements > 4)
                            {
                                Assume.sign(result.SByte4,  a.SByte4);
                                Assume.sign(result.SByte5,  a.SByte5);
                                Assume.sign(result.SByte6,  a.SByte6);
                                Assume.sign(result.SByte7,  a.SByte7);

                                if (elements > 8)
                                {
                                    Assume.sign(result.SByte8,  a.SByte8);
                                    Assume.sign(result.SByte9,  a.SByte9);
                                    Assume.sign(result.SByte10, a.SByte10);
                                    Assume.sign(result.SByte11, a.SByte11);
                                    Assume.sign(result.SByte12, a.SByte12);
                                    Assume.sign(result.SByte13, a.SByte13);
                                    Assume.sign(result.SByte14, a.SByte14);
                                    Assume.sign(result.SByte15, a.SByte15);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sign_epi8(mm256_set1_epi8(1), a);

                    Assume.sign(result.SByte0,  a.SByte0);
                    Assume.sign(result.SByte1,  a.SByte1);
                    Assume.sign(result.SByte2,  a.SByte2);
                    Assume.sign(result.SByte3,  a.SByte3);
                    Assume.sign(result.SByte4,  a.SByte4);
                    Assume.sign(result.SByte5,  a.SByte5);
                    Assume.sign(result.SByte6,  a.SByte6);
                    Assume.sign(result.SByte7,  a.SByte7);
                    Assume.sign(result.SByte8,  a.SByte8);
                    Assume.sign(result.SByte9,  a.SByte9);
                    Assume.sign(result.SByte10, a.SByte10);
                    Assume.sign(result.SByte11, a.SByte11);
                    Assume.sign(result.SByte12, a.SByte12);
                    Assume.sign(result.SByte13, a.SByte13);
                    Assume.sign(result.SByte14, a.SByte14);
                    Assume.sign(result.SByte15, a.SByte15);
                    Assume.sign(result.SByte16, a.SByte16);
                    Assume.sign(result.SByte17, a.SByte17);
                    Assume.sign(result.SByte18, a.SByte18);
                    Assume.sign(result.SByte19, a.SByte19);
                    Assume.sign(result.SByte20, a.SByte20);
                    Assume.sign(result.SByte21, a.SByte21);
                    Assume.sign(result.SByte22, a.SByte22);
                    Assume.sign(result.SByte23, a.SByte23);
                    Assume.sign(result.SByte24, a.SByte24);
                    Assume.sign(result.SByte25, a.SByte25);
                    Assume.sign(result.SByte26, a.SByte26);
                    Assume.sign(result.SByte27, a.SByte27);
                    Assume.sign(result.SByte28, a.SByte28);
                    Assume.sign(result.SByte29, a.SByte29);
                    Assume.sign(result.SByte30, a.SByte30);
                    Assume.sign(result.SByte31, a.SByte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi16(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi16(set1_epi16(1), a);
                    }
                    else
                    {
                        v128 ONE = set1_epi16(1);

                        if (ge0 || constexpr.ALL_GE_EPI16(a, 0, elements))
                        {
                            result = andnot_si128(cmpeq_epi16(a, setzero_si128()), ONE);
                        }
                        else if (le0 || constexpr.ALL_LE_EPI16(a, 0, elements))
                        {
                            result = srai_epi16(a, 15);
                        }
                        else if (non0 || constexpr.ALL_NEQ_EPI16(a, 0, elements))
                        {
                            result = or_si128(ONE, srai_epi16(a, 15));
                        }
                        else
                        {
                            result = sub_epi16(srai_epi16(a, 15), cmpgt_epi16(a, setzero_si128()));
                        }
                    }

                    Assume.sign(result.SShort0, a.SShort0);
                    Assume.sign(result.SShort1, a.SShort1);

                    if (elements > 2)
                    {
                        Assume.sign(result.SShort2, a.SShort2);

                        if (elements > 3)
                        {
                            Assume.sign(result.SShort3, a.SShort3);

                            if (elements > 4)
                            {
                                Assume.sign(result.SShort4, a.SShort4);
                                Assume.sign(result.SShort5, a.SShort5);
                                Assume.sign(result.SShort6, a.SShort6);
                                Assume.sign(result.SShort7, a.SShort7);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sign_epi16(mm256_set1_epi16(1), a);

                    Assume.sign(result.SShort0,  a.SShort0);
                    Assume.sign(result.SShort1,  a.SShort1);
                    Assume.sign(result.SShort2,  a.SShort2);
                    Assume.sign(result.SShort3,  a.SShort3);
                    Assume.sign(result.SShort4,  a.SShort4);
                    Assume.sign(result.SShort5,  a.SShort5);
                    Assume.sign(result.SShort6,  a.SShort6);
                    Assume.sign(result.SShort7,  a.SShort7);
                    Assume.sign(result.SShort8,  a.SShort8);
                    Assume.sign(result.SShort9,  a.SShort9);
                    Assume.sign(result.SShort10, a.SShort10);
                    Assume.sign(result.SShort11, a.SShort11);
                    Assume.sign(result.SShort12, a.SShort12);
                    Assume.sign(result.SShort13, a.SShort13);
                    Assume.sign(result.SShort14, a.SShort14);
                    Assume.sign(result.SShort15, a.SShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi32(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi32(set1_epi32(1), a);
                    }
                    else
                    {
                        v128 ONE = set1_epi32(1);

                        if (ge0 || constexpr.ALL_GE_EPI32(a, 0, elements))
                        {
                            result = andnot_si128(cmpeq_epi32(a, setzero_si128()), ONE);
                        }
                        else if (le0 || constexpr.ALL_LE_EPI32(a, 0, elements))
                        {
                            result = srai_epi32(a, 31);
                        }
                        else if (non0 || constexpr.ALL_NEQ_EPI32(a, 0, elements))
                        {
                            result = or_si128(ONE, srai_epi32(a, 31));
                        }
                        else
                        {
                            result = sub_epi32(srai_epi32(a, 31), cmpgt_epi32(a, setzero_si128()));
                        }
                    }

                    Assume.sign(result.SInt0, a.SInt0);
                    Assume.sign(result.SInt1, a.SInt1);

                    if (elements > 2)
                    {
                        Assume.sign(result.SInt2, a.SInt2);

                        if (elements > 3)
                        {
                            Assume.sign(result.SInt3, a.SInt3);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sign_epi32(mm256_set1_epi32(1), a);

                    Assume.sign(result.SInt0, a.SInt0);
                    Assume.sign(result.SInt1, a.SInt1);
                    Assume.sign(result.SInt2, a.SInt2);
                    Assume.sign(result.SInt3, a.SInt3);
                    Assume.sign(result.SInt4, a.SInt4);
                    Assume.sign(result.SInt5, a.SInt5);
                    Assume.sign(result.SInt6, a.SInt6);
                    Assume.sign(result.SInt7, a.SInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi64(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi64x(1);

                    v128 result;
                    if (ge0 || constexpr.ALL_GE_EPI64(a, 0))
                    {
                        result = andnot_si128(cmpeq_epi64(a, setzero_si128()), ONE);
                    }
                    else if (le0 || constexpr.ALL_LE_EPI64(a, 0))
                    {
                        result = srai_epi64(a, 63);
                    }
                    else if (non0 || constexpr.ALL_NEQ_EPI64(a, 0))
                    {
                        result = or_si128(ONE, srai_epi64(a, 63));
                    }
                    else
                    {
                        result = sub_epi64(srai_epi64(a, 63), cmpgt_epi64(a, setzero_si128()));
                    }

                    Assume.sign(result.SLong0, a.SLong0);
                    Assume.sign(result.SLong1, a.SLong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi64(v256 a, bool ge0 = false, bool le0 = false, bool non0 = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ONE = mm256_set1_epi64x(1);

                    v256 result;
                    if (ge0 || constexpr.ALL_GE_EPI64(a, 0, elements))
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256()), ONE);
                    }
                    else if (le0 || constexpr.ALL_LE_EPI64(a, 0, elements))
                    {
                        result = mm256_srai_epi64(a, 63, elements: elements);
                    }
                    else if (non0 || constexpr.ALL_NEQ_EPI64(a, 0, elements))
                    {
                        result = Avx2.mm256_or_si256(ONE, mm256_srai_epi64(a, 63, elements: elements));
                    }
                    else
                    {
                        result = Avx2.mm256_sub_epi64(mm256_srai_epi64(a, 63, elements: elements), Avx2.mm256_cmpgt_epi64(a, Avx.mm256_setzero_si256()));
                    }

                    Assume.sign(result.SLong0, a.SLong0);
                    Assume.sign(result.SLong1, a.SLong1);

                    if (elements > 2)
                    {
                        Assume.sign(result.SLong2, a.SLong2);

                        if (elements > 3)
                        {
                            Assume.sign(result.SLong3, a.SLong3);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_pq(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 SIGN_BIT = set1_epi8(1 << 7);

                    v128 result;
                    if (le0
                     /*|| constexpr.ALL_LE_PQ(a, 0, elements)*/)
                    {
                        result = set1_epi8((byte)((1 << 7) | math.ONE_AS_QUARTER));
                    }
                    else
                    {
                        result = ternarylogic_si128(set1_epi8(math.ONE_AS_QUARTER), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       /*|| constexpr.ALL_NEQ_PQ(a, 0, elements)*/))
                    {
                        v128 cmp0;
                        if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                         && (ge0
                          /*|| constexpr.ALL_GE_PQ(a, 0, elements)*/))
                        {
                            cmp0 = a;
                        }
                        else
                        {
                            cmp0 = andnot_si128(SIGN_BIT, a);
                        }

                        result = andnot_si128(cmpeq_epi8(setzero_si128(), cmp0), result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      /*|| constexpr.ALL_NOTNAN_PQ(a, elements)*/)
                    {
                        result = or_si128(result, cmpgt_epi8(andnot_si128(SIGN_BIT, a), set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        /*constexpr.ASSUME_RANGE_PQ(result, -1f, 1f);*/
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_ph(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 SIGN_BIT = set1_epi16(1 << 15);

                    v128 result;
                    if (le0
                     /*|| constexpr.ALL_LE_PH(a, 0, elements)*/)
                    {
                        result = set1_epi16((ushort)((1 << 15) | math.ONE_AS_HALF));
                    }
                    else
                    {
                        result = ternarylogic_si128(set1_epi16(math.ONE_AS_HALF), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       /*|| constexpr.ALL_NEQ_PH(a, 0, elements)*/))
                    {
                        v128 cmp0;
                        if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                         && (ge0
                          /*|| constexpr.ALL_GE_PH(a, 0, elements)*/))
                        {
                            cmp0 = a;
                        }
                        else
                        {
                            cmp0 = andnot_si128(SIGN_BIT, a);
                        }

                        result = andnot_si128(cmpeq_epi16(setzero_si128(), cmp0), result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      /*|| constexpr.ALL_NOTNAN_PH(a, elements)*/)
                    {
                        result = or_si128(result, cmpgt_epi16(andnot_si128(SIGN_BIT, a), set1_epi16(F16_SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        /*constexpr.ASSUME_RANGE_PH(result, -1f, 1f);*/
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_ps(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 SIGN_BIT = set1_epi32(1 << 31);

                    v128 result;
                    if (le0
                     || constexpr.ALL_LE_PS(a, 0, elements))
                    {
                        result = set1_ps(-1f);
                    }
                    else
                    {
                        result = ternarylogic_si128(set1_ps(1f), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       || constexpr.ALL_NEQ_PS(a, 0, elements)))
                    {
                        v128 cmp0;
                        if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                         && (ge0
                          || constexpr.ALL_GE_PS(a, 0, elements)))
                        {
                            cmp0 = a;
                        }
                        else
                        {
                            cmp0 = andnot_ps(SIGN_BIT, a);
                        }

                        result = andnot_ps(cmpeq_epi32(setzero_si128(), cmp0), result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      || constexpr.ALL_NOTNAN_PS(a, elements))
                    {
                        result = or_ps(result, cmpgt_epi32(andnot_ps(SIGN_BIT, a), set1_epi32(F32_SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        constexpr.ASSUME_RANGE_PS(result, -1f, 1f);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_pd(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 SIGN_BIT = set1_epi64x(1ul << 63);

                    v128 result;
                    if (le0
                     || constexpr.ALL_LE_PD(a, 0))
                    {
                        result = set1_pd(-1d);
                    }
                    else
                    {
                        result = ternarylogic_si128(set1_pd(1d), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       || constexpr.ALL_NEQ_PD(a, 0)))
                    {
                        v128 cmp0;
                        if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                         && (ge0
                          || constexpr.ALL_GE_PD(a, 0)))
                        {
                            cmp0 = a;
                        }
                        else
                        {
                            cmp0 = andnot_pd(SIGN_BIT, a);
                        }

                        result = andnot_pd(cmpeq_epi64(setzero_si128(), cmp0), result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      || constexpr.ALL_NOTNAN_PD(a))
                    {

                        result = or_pd(result, cmpunord_pd(a, a));
                    }
                    else
                    {
                        constexpr.ASSUME_RANGE_PD(result, -1f, 1f);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_pq(v256 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SIGN_BIT = mm256_set1_epi8(1 << 7);

                    v256 result;
                    if (le0
                     /*|| constexpr.ALL_LE_PQ(a, 0, elements)*/)
                    {
                        result = mm256_set1_epi8((byte)((1 << 7) | math.ONE_AS_QUARTER));
                    }
                    else
                    {
                        result = mm256_ternarylogic_si256(mm256_set1_epi8(math.ONE_AS_QUARTER), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       /*|| constexpr.ALL_NEQ_PQ(a, 0, elements)*/))
                    {
                        v256 cmp0;
                        if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                         && (ge0
                          /*|| constexpr.ALL_GE_PQ(a, 0, elements)*/))
                        {
                            cmp0 = a;
                        }
                        else
                        {
                            cmp0 = Avx2.mm256_andnot_si256(SIGN_BIT, a);
                        }

                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), cmp0), result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      /*|| constexpr.ALL_NOTNAN_PQ(a, elements)*/)
                    {
                        result = Avx2.mm256_or_si256(result, Avx2.mm256_cmpgt_epi8(Avx2.mm256_andnot_si256(SIGN_BIT, a), mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        /*constexpr.ASSUME_RANGE_PQ(result, -1f, 1f);*/
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_ph(v256 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SIGN_BIT = mm256_set1_epi16(1 << 15);

                    v256 result;
                    if (le0
                     /*|| constexpr.ALL_LE_PH(a, 0, elements)*/)
                    {
                        result = mm256_set1_epi16((ushort)((1 << 15) | math.ONE_AS_HALF));
                    }
                    else
                    {
                        result = mm256_ternarylogic_si256(mm256_set1_epi16(math.ONE_AS_HALF), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       /*|| constexpr.ALL_NEQ_PH(a, 0, elements)*/))
                    {
                        v256 cmp0;
                        if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                         && (ge0
                          /*|| constexpr.ALL_GE_PH(a, 0, elements)*/))
                        {
                            cmp0 = a;
                        }
                        else
                        {
                            cmp0 = Avx2.mm256_andnot_si256(SIGN_BIT, a);
                        }

                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(Avx.mm256_setzero_si256(), cmp0), result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      /*|| constexpr.ALL_NOTNAN_PH(a, elements)*/)
                    {
                        result = Avx2.mm256_or_si256(result, Avx2.mm256_cmpgt_epi16(Avx2.mm256_andnot_si256(SIGN_BIT, a), mm256_set1_epi16(F16_SIGNALING_EXPONENT)));
                    }
                    else
                    {
                        /*constexpr.ASSUME_RANGE_PH(result, -1f, 1f);*/
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_ps(v256 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 SIGN_BIT = Avx.mm256_set1_epi32(1 << 31);

                    v256 result;
                    if (le0
                     || constexpr.ALL_LE_PS(a, 0))
                    {
                        result = Avx.mm256_set1_ps(-1f);
                    }
                    else
                    {
                        result = mm256_ternarylogic_si256(Avx.mm256_set1_ps(1f), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       || constexpr.ALL_NEQ_PS(a, 0)))
                    {
                        v256 cmpeq0;
                        if (Avx2.IsAvx2Supported)
                        {
                            if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                             && (ge0
                              || constexpr.ALL_GE_PS(a, 0)))
                            {
                                cmpeq0 = Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), a);
                            }
                            else
                            {
                                cmpeq0 = Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), Avx.mm256_andnot_ps(SIGN_BIT, a));
                            }
                        }
                        else
                        {
                            cmpeq0 = mm256_cmpeq_ps(Avx.mm256_setzero_si256(), a);
                        }

                        result = Avx.mm256_andnot_ps(cmpeq0, result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      || constexpr.ALL_NOTNAN_PS(a))
                    {
                        v256 cmpNaN;
                        if (Avx2.IsAvx2Supported)
                        {
                            cmpNaN = Avx2.mm256_cmpgt_epi32(Avx.mm256_andnot_ps(SIGN_BIT, a), Avx.mm256_set1_epi32(F32_SIGNALING_EXPONENT));
                        }
                        else
                        {
                            cmpNaN = mm256_cmpunord_ps(a, a);
                        }

                        result = Avx.mm256_or_ps(result, cmpNaN);
                    }
                    else
                    {
                        constexpr.ASSUME_RANGE_PS(result, -1f, 1f);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_pd(v256 a, bool ge0 = false, bool le0 = false, bool non0 = false, bool notNaN = false, byte elements = 4)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 SIGN_BIT = mm256_set1_epi64x(1ul << 63);

                    v256 result;
                    if (le0
                     || constexpr.ALL_LE_PD(a, 0, elements))
                    {
                        result = Avx.mm256_set1_pd(-1d);
                    }
                    else
                    {
                        result = mm256_ternarylogic_si256(Avx.mm256_set1_pd(1d), a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    if (!(non0
                       || constexpr.ALL_NEQ_PD(a, 0, elements)))
                    {
                        v256 cmpeq0;
                        if (Avx2.IsAvx2Supported)
                        {
                            if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                             && (ge0
                              || constexpr.ALL_GE_PD(a, 0, elements)))
                            {
                                cmpeq0 = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), a);
                            }
                            else
                            {
                                cmpeq0 = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx.mm256_andnot_pd(SIGN_BIT, a));
                            }
                        }
                        else
                        {
                            cmpeq0 = mm256_cmpeq_pd(Avx.mm256_setzero_si256(), a);
                        }

                        result = Avx.mm256_andnot_pd(cmpeq0, result);
                    }

                    if (!(notNaN
                      || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                      || constexpr.ALL_NOTNAN_PD(a, elements))
                    {
                        result = Avx.mm256_or_pd(result, mm256_cmpunord_pd(a, a));
                    }
                    else
                    {
                        constexpr.ASSUME_RANGE_PD(result, -1d, 1d);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }
    

    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void sign(sbyte result, sbyte x)
        {
            constexpr.ASSUME((x < 0)  == (result == -1));
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x > 0)  == (result == 1));
            constexpr.ASSUME(result == -1 || result == 0 || result == 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void sign(short result, short x)
        {
            constexpr.ASSUME((x < 0)  == (result == -1));
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x > 0)  == (result == 1));
            constexpr.ASSUME(result == -1 || result == 0 || result == 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void sign(int result, int x)
        {
            constexpr.ASSUME((x < 0)  == (result == -1));
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x > 0)  == (result == 1));
            constexpr.ASSUME(result == -1 || result == 0 || result == 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void sign(long result, long x)
        {
            constexpr.ASSUME((x < 0)  == (result == -1));
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x > 0)  == (result == 1));
            constexpr.ASSUME(result == -1 || result == 0 || result == 1);
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns the sign of an <see cref="Int128"/>. 1 for a positive <see cref="Int128"/>, 0 for zero and -1 for a negative <see cref="Int128"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long sign(Int128 x, Promise promises = Promise.Nothing)
        {
            long result;

            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                result = tolong(x.IsNotZero);
            }
            else if (promises.Promises(Promise.ZeroOrLess) || constexpr.IS_TRUE(x <= 0))
            {
                result = (long)x.hi64 >> 63;
            }
            else if (promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x.IsNotZero))
            {
                result = 1 | ((long)x.hi64 >> 63);
            }
            else
            {
                result = ((long)x.hi64 >> 63) | (long)((-x).hi64 >> 63);
            }
            
            constexpr.ASSUME((x < 0)  == (result == -1));
            constexpr.ASSUME((x == 0) == (result == 0));
            constexpr.ASSUME((x > 0)  == (result == 1));
            constexpr.ASSUME(result == -1 || result == 0 || result == 1);

            return result;
        }


        /// <summary>       Returns the sign of an <see cref="sbyte"/>. 1 for a positive <see cref="sbyte"/>, 0 for zero and -1 for a negative <see cref="sbyte"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(sbyte x, Promise promises = Promise.Nothing)
        {
            return sign((int)x, promises);
        }

        /// <summary>       Returns the componentwise sign of an <see cref="sbyte2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 sign(sbyte2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new sbyte2((sbyte)sign(x.x, promises), (sbyte)sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="sbyte3"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 sign(sbyte3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new sbyte3((sbyte)sign(x.x, promises), (sbyte)sign(x.y, promises), (sbyte)sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="sbyte4"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 sign(sbyte4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new sbyte4((sbyte)sign(x.x, promises), (sbyte)sign(x.y, promises), (sbyte)sign(x.z, promises), (sbyte)sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="sbyte8"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 sign(sbyte8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new sbyte8((sbyte)sign(x.x0, promises),
                                  (sbyte)sign(x.x1, promises),
                                  (sbyte)sign(x.x2, promises),
                                  (sbyte)sign(x.x3, promises),
                                  (sbyte)sign(x.x4, promises),
                                  (sbyte)sign(x.x5, promises),
                                  (sbyte)sign(x.x6, promises),
                                  (sbyte)sign(x.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="sbyte16"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 sign(sbyte16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 16);
            }
            else
            {
                return new sbyte16((sbyte)sign(x.x0,  promises),
                                   (sbyte)sign(x.x1,  promises),
                                   (sbyte)sign(x.x2,  promises),
                                   (sbyte)sign(x.x3,  promises),
                                   (sbyte)sign(x.x4,  promises),
                                   (sbyte)sign(x.x5,  promises),
                                   (sbyte)sign(x.x6,  promises),
                                   (sbyte)sign(x.x7,  promises),
                                   (sbyte)sign(x.x8,  promises),
                                   (sbyte)sign(x.x9,  promises),
                                   (sbyte)sign(x.x10, promises),
                                   (sbyte)sign(x.x11, promises),
                                   (sbyte)sign(x.x12, promises),
                                   (sbyte)sign(x.x13, promises),
                                   (sbyte)sign(x.x14, promises),
                                   (sbyte)sign(x.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="sbyte32"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 sign(sbyte32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi8(x);
            }
            else
            {
                return new sbyte32(sign(x.v16_0, promises), sign(x.v16_16, promises));
            }
        }


        /// <summary>       Returns the sign of a <see cref="short"/>. 1 for a positive <see cref="short"/>, 0 for zero and -1 for a negative <see cref="short"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(short x, Promise promises = Promise.Nothing)
        {
            return sign((int)x, promises);
        }

        /// <summary>       Returns the componentwise sign of a <see cref="short2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 sign(short2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new short2((short)sign(x.x, promises), (short)sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="short3"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 sign(short3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new short3((short)sign(x.x, promises), (short)sign(x.y, promises), (short)sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="short4"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 sign(short4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new short4((short)sign(x.x, promises), (short)sign(x.y, promises), (short)sign(x.z, promises), (short)sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="short8"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 sign(short8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new short8((short)sign(x.x0, promises),
                                  (short)sign(x.x1, promises),
                                  (short)sign(x.x2, promises),
                                  (short)sign(x.x3, promises),
                                  (short)sign(x.x4, promises),
                                  (short)sign(x.x5, promises),
                                  (short)sign(x.x6, promises),
                                  (short)sign(x.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="short16"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 sign(short16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi16(x);
            }
            else
            {
                return new short16(sign(x.v8_0, promises), sign(x.v8_8, promises));
            }
        }


        /// <summary>       Returns the sign of an <see cref="int"/>. 1 for a positive <see cref="int"/>, 0 for zero and -1 for a negative <see cref="int"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(int x, Promise promises = Promise.Nothing)
        {
            int result;

            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                result = toint(x != 0);
            }
            else if (promises.Promises(Promise.ZeroOrLess) || constexpr.IS_TRUE(x <= 0))
            {
                result = x >> 31;
            }
            else if (promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0))
            {
                result = 1 | (x >> 31);
            }
            else
            {
                result = (x >> 31) | toint(x > 0);
            }

            Assume.sign(result, x);

            return result;
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(int2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi32(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new int2(sign(x.x, promises), sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int3"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(int3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi32(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new int3(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int4"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(int4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi32(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new int4(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises), sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int8"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 sign(int8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi32(x);
            }
            else
            {
                return new int8(sign(x.v4_0, promises), sign(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the sign of a <see cref="long"/>. 1 for a positive <see cref="long"/>, 0 for zero and -1 for a negative <see cref="long"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [return: AssumeRange(-1L, 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long sign(long x, Promise promises = Promise.Nothing)
        {
            long result;

            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                result = tolong(x != 0);
            }
            else if (promises.Promises(Promise.ZeroOrLess) || constexpr.IS_TRUE(x <= 0))
            {
                result = x >> 63;
            }
            else if (promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0))
            {
                result = 1 | (x >> 63);
            }
            else
            {
                result = (x >> 63) | tolong(x > 0);
            }

            Assume.sign(result, x);

            return result;
        }

        /// <summary>       Returns the componentwise sign of a <see cref="long2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 sign(long2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_epi64(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new long2(sign(x.x, promises), sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="long3"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 sign(long3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi64(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new long3(sign(x.xy, promises), sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="long4"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 sign(long4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi64(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new long4(sign(x.xy, promises), sign(x.zw, promises));
            }
        }


        /// <summary>       Returns the sign of a <see cref="quarter"/>. 1.0f for a positive <see cref="quarter"/>, 0.0f for zero and -1.0f for a negative <see cref="quarter"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter sign(quarter x, Promise promises = Promise.Nothing)
        {
            const byte SIGN_BIT = 1 << 7;

            byte result;
            if (promises.Promises(Promise.ZeroOrLess)
             || constexpr.IS_TRUE(x.IsLessThanOrEqualTo(MaxMath.quarter.Zero)))
            {
                result = asbyte((quarter)(-1f));
            }
            else
            {
                result = (byte)(ONE_AS_QUARTER | (asbyte(x) & SIGN_BIT));
            }

            if (!(promises.Promises(Promise.NonZero)
               || constexpr.IS_TRUE(x.IsNotEqualTo(MaxMath.quarter.Zero))))
            {
                byte cmp0;
                if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                 && (promises.Promises(Promise.ZeroOrGreater)
                  || constexpr.IS_TRUE(x.IsGreaterThanOrEqualTo(MaxMath.quarter.Zero) )))
                {
                    cmp0 = asbyte(x);
                }
                else
                {
                    cmp0 = andnot(asbyte(x), SIGN_BIT);
                }

                result = (byte)(cmp0 != 0 ? result : 0);
            }

            if (!(promises.Promises(Promise.Unsafe0)
              || COMPILATION_OPTIONS.FLOAT_NO_NAN)
              || constexpr.IS_FALSE(isnan(x)))
            {
                result = andnot(x.value, SIGN_BIT) > MaxMath.quarter.SIGNALING_EXPONENT ? byte.MaxValue : result;
            }
            else
            {
                constexpr.ASSUME(result >= -1f && result <= 1f);
            }

            return asquarter(result);
        }

        /// <summary>       Returns the componentwise sign of a <see cref="quarter2"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 sign(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new quarter2(sign(x.x, promises), sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="quarter3"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 sign(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new quarter3(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="quarter4"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 sign(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new quarter4(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises), sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="quarter8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 sign(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new quarter8(sign(x.x0, promises),
                                    sign(x.x1, promises),
                                    sign(x.x2, promises),
                                    sign(x.x3, promises),
                                    sign(x.x4, promises),
                                    sign(x.x5, promises),
                                    sign(x.x6, promises),
                                    sign(x.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="quarter16"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 sign(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter16(sign(x.x0, promises),
                                     sign(x.x1, promises),
                                     sign(x.x2, promises),
                                     sign(x.x3, promises),
                                     sign(x.x4, promises),
                                     sign(x.x5, promises),
                                     sign(x.x6, promises),
                                     sign(x.x7, promises),
                                     sign(x.x8, promises),
                                     sign(x.x9, promises),
                                     sign(x.x10, promises),
                                     sign(x.x11, promises),
                                     sign(x.x12, promises),
                                     sign(x.x13, promises),
                                     sign(x.x14, promises),
                                     sign(x.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="quarter32"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 sign(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_pq(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter32(sign(x.v16_0, promises), sign(x.v16_16, promises));
            }
        }


        /// <summary>       Returns the sign of a <see cref="half"/>. 1.0f for a positive <see cref="half"/>, 0.0f for zero and -1.0f for a negative <see cref="half"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="half.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half sign(half x, Promise promises = Promise.Nothing)
        {
            const ushort SIGN_BIT = 1 << 15;

            ushort result;
            if (promises.Promises(Promise.ZeroOrLess)
             || constexpr.IS_TRUE(x.IsLessThanOrEqualTo(default(half))))
            {
                result = asushort((half)(-1f));
            }
            else
            {
                result = (ushort)(ONE_AS_HALF | (asushort(x) & SIGN_BIT));
            }

            if (!(promises.Promises(Promise.NonZero)
               || constexpr.IS_TRUE(x.IsNotEqualTo(default(half)))))
            {
                ushort cmp0;
                if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                 && (promises.Promises(Promise.ZeroOrGreater)
                  || constexpr.IS_TRUE(x.IsGreaterThanOrEqualTo(default(half)))))
                {
                    cmp0 = asushort(x);
                }
                else
                {
                    cmp0 = andnot(asushort(x), SIGN_BIT);
                }

                result = (ushort)(cmp0 != 0 ? result : 0);
            }

            if (!(promises.Promises(Promise.Unsafe0)
              || COMPILATION_OPTIONS.FLOAT_NO_NAN)
              || constexpr.IS_FALSE(isnan(x)))
            {
                result = andnot(x.value, SIGN_BIT) > F16_SIGNALING_EXPONENT ? ushort.MaxValue : result;
            }
            else
            {
                constexpr.ASSUME(result >= -1f && result <= 1f);
            }

            return ashalf(result);
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half2"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="half.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 sign(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ph(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new half2(sign(x.x, promises), sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half3"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="half.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 sign(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ph(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new half3(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half4"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="half.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 sign(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ph(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new half4(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises), sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="half.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 sign(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ph(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new half8(sign(x.x0, promises),
                                 sign(x.x1, promises),
                                 sign(x.x2, promises),
                                 sign(x.x3, promises),
                                 sign(x.x4, promises),
                                 sign(x.x5, promises),
                                 sign(x.x6, promises),
                                 sign(x.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half16"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="half.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 sign(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_ph(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half16(sign(x.v8_0, promises), sign(x.v8_8, promises));
            }
        }


        /// <summary>       Returns the sign of a <see cref="float"/>. 1.0f for a positive <see cref="float"/>, 0.0f for zero and -1.0f for a negative <see cref="float"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="float.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sign(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ps(Xse.set_ss(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), 1).Float0;
            }
            else
            {
                const uint SIGN_BIT = 1u << 31;

                uint result;
                if (promises.Promises(Promise.ZeroOrLess)
                 || constexpr.IS_TRUE(x <= 0f))
                {
                    result = asuint(-1f);
                }
                else
                {
                    result = asuint(1f) | (asuint(x) & SIGN_BIT);
                }

                if (!(promises.Promises(Promise.NonZero)
                   || constexpr.IS_TRUE(x != 0f)))
                {
                    uint cmp0;
                    if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                     && (promises.Promises(Promise.ZeroOrGreater)
                      || constexpr.IS_TRUE(x >= 0f)))
                    {
                        cmp0 = asuint(x);
                    }
                    else
                    {
                        cmp0 = andnot(asuint(x), SIGN_BIT);
                    }

                    result = cmp0 != 0 ? result : 0;
                }

                if (!(promises.Promises(Promise.Unsafe0)
                  || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                  || constexpr.IS_FALSE(isnan(x)))
                {
                    result = andnot(asuint(x), SIGN_BIT) > F32_SIGNALING_EXPONENT ? uint.MaxValue : result;
                }
                else
                {
                    constexpr.ASSUME(result >= -1f && result <= 1f);
                }

                return asfloat(result);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="float2"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="float.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 sign(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ps(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 2);
            }
            else
            {
                return new float2(sign(x.x, promises), sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="float3"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="float.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 sign(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ps(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 3);
            }
            else
            {
                return new float3(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="float4"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="float.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 sign(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ps(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 4);
            }
            else
            {
                return new float4(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises), sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="float8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="float.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sign(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_soz_ps(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new float8(sign(x.v4_0), sign(x.v4_4));
            }
        }


        /// <summary>       Returns the sign of a <see cref="double"/>. 1.0f for a positive <see cref="double"/>, 0.0f for zero and -1.0f for a negative <see cref="double"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="double.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sign(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pd(Xse.set_sd(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0)).Double0;
            }
            else
            {
                const ulong SIGN_BIT = 1ul << 63;

                ulong result;
                if (promises.Promises(Promise.ZeroOrLess)
                 || constexpr.IS_TRUE(x <= 0d))
                {
                    result = asulong(-1d);
                }
                else
                {
                    result = asulong(1d) | (asulong(x) & SIGN_BIT);
                }

                if (!(promises.Promises(Promise.NonZero)
                   || constexpr.IS_TRUE(x != 0d)))
                {
                    ulong cmp0;
                    if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                     && (promises.Promises(Promise.ZeroOrGreater)
                      || constexpr.IS_TRUE(x >= 0d)))
                    {
                        cmp0 = asulong(x);
                    }
                    else
                    {
                        cmp0 = andnot(asulong(x), SIGN_BIT);
                    }

                    result = cmp0 != 0 ? result : 0;
                }

                if (!(promises.Promises(Promise.Unsafe0)
                  || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                  || constexpr.IS_FALSE(isnan(x)))
                {
                    result = andnot(asulong(x), SIGN_BIT) > F64_SIGNALING_EXPONENT ? ulong.MaxValue : result;
                }
                else
                {
                    constexpr.ASSUME(result >= -1d && result <= 1d);
                }

                return asdouble(result);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="double2"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="double.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 sign(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pd(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new double2(sign(x.x, promises), sign(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="double3"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="double.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 sign(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_soz_pd(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 3);
            }
            else
            {
                return new double3(sign(x.xy, promises), sign(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="double4"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="double.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 sign(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_soz_pd(x, ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 4);
            }
            else
            {
                return new double4(sign(x.xy, promises), sign(x.zw, promises));
            }
        }


        /// <summary>       Returns the sign of a <see cref="quadruple"/> value. -1 if it is less than zero, 0 if it is zero and 1 if it is greater than zero.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(quadruple x)
        {
            int signBit = (int)(x.value.hi64 >> 63);
            int isNonZero;
            int isNegative = signBit;

            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                UInt128 withoutSignBit = x.value << 1;
                isNonZero = tobyte(withoutSignBit.IsNotZero);
                isNegative &= isNonZero;
            }
            else
            {
                isNonZero = tobyte(x.value.IsNotZero);
            }

            int isPositive = andnot(isNonZero, signBit);
            return isPositive - isNegative;
        }
    }
}