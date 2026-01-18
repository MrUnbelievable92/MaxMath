using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
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
                    v128 ONE = set1_epi8(1);

                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi8(ONE, a);
                    }
                    else
                    {
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

                    constexpr.ASSUME_RANGE_EPI8(result, -1, 1);
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

                    constexpr.ASSUME_RANGE_EPI8(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi16(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi16(1);

                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi16(ONE, a);
                    }
                    else
                    {
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

                    constexpr.ASSUME_RANGE_EPI16(result, -1, 1);
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

                    constexpr.ASSUME_RANGE_EPI16(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi32(v128 a, bool ge0 = false, bool le0 = false, bool non0 = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi32(1);

                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi32(ONE, a);
                    }
                    else
                    {
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

                    constexpr.ASSUME_RANGE_EPI32(result, -1, 1);
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

                    constexpr.ASSUME_RANGE_EPI32(result, -1, 1);
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

                    constexpr.ASSUME_RANGE_EPI64(result, -1, 1);
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
                        result = Avx2.mm256_sub_epi64(mm256_srai_epi64(a, 63, elements: elements), mm256_cmpgt_epi64(a, Avx.mm256_setzero_si256()));
                    }

                    constexpr.ASSUME_RANGE_EPI64(result, -1, 1);
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
                        result = set1_epi8((byte)((1 << 7) | maxmath.ONE_AS_QUARTER));
                    }
                    else
                    {
                        result = ternarylogic_si128(set1_epi8(maxmath.ONE_AS_QUARTER), a, SIGN_BIT, TernaryOperation.OxF8);
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
                        result = or_si128(result, cmpgt_epi8(andnot_si128(SIGN_BIT, a), set1_epi8(quarter.SIGNALING_EXPONENT)));
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
                        result = set1_epi16((ushort)((1 << 15) | maxmath.ONE_AS_HALF));
                    }
                    else
                    {
                        result = ternarylogic_si128(set1_epi16(maxmath.ONE_AS_HALF), a, SIGN_BIT, TernaryOperation.OxF8);
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
                        result = mm256_set1_epi8((byte)((1 << 7) | maxmath.ONE_AS_QUARTER));
                    }
                    else
                    {
                        result = mm256_ternarylogic_si256(mm256_set1_epi8(maxmath.ONE_AS_QUARTER), a, SIGN_BIT, TernaryOperation.OxF8);
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
                        result = Avx2.mm256_or_si256(result, Avx2.mm256_cmpgt_epi8(Avx2.mm256_andnot_si256(SIGN_BIT, a), mm256_set1_epi8(quarter.SIGNALING_EXPONENT)));
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
                        result = mm256_set1_epi16((ushort)((1 << 15) | maxmath.ONE_AS_HALF));
                    }
                    else
                    {
                        result = mm256_ternarylogic_si256(mm256_set1_epi16(maxmath.ONE_AS_HALF), a, SIGN_BIT, TernaryOperation.OxF8);
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


    unsafe public static partial class maxmath
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
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return tolong(x.IsNotZero);
            }
            else if (promises.Promises(Promise.ZeroOrLess) || constexpr.IS_TRUE(x <= 0))
            {
                return (long)x.hi64 >> 63;
            }
            else if (promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x.IsNotZero))
            {
                return 1 | ((long)x.hi64 >> 63);
            }
            else
            {
                return ((long)x.hi64 >> 63) | (long)((-x).hi64 >> 63);
            }
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

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte3"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte4"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte8"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte16"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte32"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short3"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short4"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short8"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short16"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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
        public static int sign(int x, Promise promises)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return toint(x != 0);
            }
            else if (promises.Promises(Promise.ZeroOrLess) || constexpr.IS_TRUE(x <= 0))
            {
                return x >> 31;
            }
            else if (promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0))
            {
                return 1 | (x >> 31);
            }
            else
            {
                return (x >> 31) | toint(x > 0);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(int2 x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.soz_epi32(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 2));
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
        public static int3 sign(int3 x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.soz_epi32(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3));
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
        public static int4 sign(int4 x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.soz_epi32(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4));
            }
            else
            {
                return new int4(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises), sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.int8"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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
        public static long sign(long x, Promise promises)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return tolong(x != 0);
            }
            else if (promises.Promises(Promise.ZeroOrLess) || constexpr.IS_TRUE(x <= 0))
            {
                return x >> 63;
            }
            else if (promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0))
            {
                return 1 | (x >> 63);
            }
            else
            {
                return (x >> 63) | tolong(x > 0);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.long2"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.long3"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.long4"/>. 1 for positive components, 0 for zero components and -1 for a negative components
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


        /// <summary>       Returns the sign of a <see cref="MaxMath.quarter"/>. 1.0f for a positive <see cref="MaxMath.quarter"/>, 0.0f for zero and -1.0f for a negative <see cref="MaxMath.quarter"/>
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="MaxMath.quarter.NaN"/>.     </para>
        /// </remarks>
		/// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter sign(quarter x, Promise promises = Promise.Nothing)
        {
            const byte SIGN_BIT = 1 << 7;

            byte result;
            if (promises.Promises(Promise.ZeroOrLess)
             || constexpr.IS_TRUE(x.IsLessThanOrEqualTo(quarter.Zero)))
            {
                result = asbyte((quarter)(-1f));
            }
            else
            {
                result = (byte)(ONE_AS_QUARTER | (asbyte(x) & SIGN_BIT));
            }

            if (!(promises.Promises(Promise.NonZero)
               || constexpr.IS_TRUE(x.IsNotEqualTo(quarter.Zero))))
            {
                byte cmp0;
                if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                 && (promises.Promises(Promise.ZeroOrGreater)
                  || constexpr.IS_TRUE(x.IsGreaterThanOrEqualTo(quarter.Zero) )))
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
                result = andnot(x.value, SIGN_BIT) > quarter.SIGNALING_EXPONENT ? byte.MaxValue : result;
            }
            else
            {
                constexpr.ASSUME(result >= -1f && result <= 1f);
            }

            return asquarter(result);
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter2"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="MaxMath.quarter.NaN"/>.     </para>
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter3"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="MaxMath.quarter.NaN"/>.     </para>
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter4"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="MaxMath.quarter.NaN"/>.     </para>
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="MaxMath.quarter.NaN"/>.     </para>
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter16"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="MaxMath.quarter.NaN"/>.     </para>
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter32"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> equal to 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for any <paramref name="x"/> less than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrLess"/> flag set returns undefined results for any <paramref name="x"/> greater than 0.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for any <paramref name="x"/> that is <see cref="MaxMath.quarter.NaN"/>.     </para>
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
                return RegisterConversion.ToHalf2(Xse.soz_ph(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 2));
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
                return RegisterConversion.ToHalf3(Xse.soz_ph(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 3));
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
                return RegisterConversion.ToHalf4(Xse.soz_ph(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), elements: 4));
            }
            else
            {
                return new half4(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises), sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.half8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
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

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.half16"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
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
        public static float sign(float x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_ps(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), 1).Float0;
            }
            else
            {
                const uint SIGN_BIT = 1u << 31;

                uint result;
                if (promises.Promises(Promise.ZeroOrLess)
                 || constexpr.IS_TRUE(x <= 0f))
                {
                    result = math.asuint((quarter)(-1f));
                }
                else
                {
                    result = math.asuint(1f) | (math.asuint(x) & SIGN_BIT);
                }

                if (!(promises.Promises(Promise.NonZero)
                   || constexpr.IS_TRUE(x != 0f)))
                {
                    uint cmp0;
                    if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                     && (promises.Promises(Promise.ZeroOrGreater)
                      || constexpr.IS_TRUE(x >= 0f)))
                    {
                        cmp0 = math.asuint(x);
                    }
                    else
                    {
                        cmp0 = andnot(math.asuint(x), SIGN_BIT);
                    }

                    result = cmp0 != 0 ? result : 0;
                }

                if (!(promises.Promises(Promise.Unsafe0)
                  || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                  || constexpr.IS_FALSE(math.isnan(x)))
                {
                    result = andnot(math.asuint(x), SIGN_BIT) > F16_SIGNALING_EXPONENT ? uint.MaxValue : result;
                }
                else
                {
                    constexpr.ASSUME(result >= -1f && result <= 1f);
                }

                return math.asfloat(result);
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
        public static float2 sign(float2 x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.soz_ps(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 2));
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
        public static float3 sign(float3 x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.soz_ps(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 3));
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
        public static float4 sign(float4 x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.soz_ps(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 4));
            }
            else
            {
                return new float4(sign(x.x, promises), sign(x.y, promises), sign(x.z, promises), sign(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.float8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components
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
                return new float8(math.sign(x.v4_0), math.sign(x.v4_4));
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
        public static double sign(double x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.soz_pd(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0)).Double0;
            }
            else
            {
                const ulong SIGN_BIT = 1ul << 63;

                ulong result;
                if (promises.Promises(Promise.ZeroOrLess)
                 || constexpr.IS_TRUE(x <= 0d))
                {
                    result = math.asulong((quarter)(-1d));
                }
                else
                {
                    result = math.asulong(1d) | (math.asulong(x) & SIGN_BIT);
                }

                if (!(promises.Promises(Promise.NonZero)
                   || constexpr.IS_TRUE(x != 0d)))
                {
                    ulong cmp0;
                    if (!COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO
                     && (promises.Promises(Promise.ZeroOrGreater)
                      || constexpr.IS_TRUE(x >= 0d)))
                    {
                        cmp0 = math.asulong(x);
                    }
                    else
                    {
                        cmp0 = andnot(math.asulong(x), SIGN_BIT);
                    }

                    result = cmp0 != 0 ? result : 0;
                }

                if (!(promises.Promises(Promise.Unsafe0)
                  || COMPILATION_OPTIONS.FLOAT_NO_NAN)
                  || constexpr.IS_FALSE(math.isnan(x)))
                {
                    result = andnot(math.asulong(x), SIGN_BIT) > F16_SIGNALING_EXPONENT ? ulong.MaxValue : result;
                }
                else
                {
                    constexpr.ASSUME(result >= -1d && result <= 1d);
                }

                return math.asdouble(result);
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
        public static double2 sign(double2 x, Promise promises)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.soz_pd(RegisterConversion.ToV128(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0)));
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
        public static double3 sign(double3 x, Promise promises)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_soz_pd(RegisterConversion.ToV256(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 3));
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
        public static double4 sign(double4 x, Promise promises)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_soz_pd(RegisterConversion.ToV256(x), ge0: promises.Promises(Promise.ZeroOrGreater), le0: promises.Promises(Promise.ZeroOrLess), non0: promises.Promises(Promise.NonZero), notNaN: promises.Promises(Promise.Unsafe0), elements: 4));
            }
            else
            {
                return new double4(sign(x.xy, promises), sign(x.zw, promises));
            }
        }
    }
}