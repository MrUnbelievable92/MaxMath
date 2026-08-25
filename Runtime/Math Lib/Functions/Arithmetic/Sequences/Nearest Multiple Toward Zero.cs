using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using DevTools;
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
            public static v128 truncmult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return floormult_epu8(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return floormult_epu16(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return floormult_epu32(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epu64(v128 a, v128 b, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return floormult_epu64(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI8(a, 0, elements))
                        {
                            result = and_si128(a, neg_epi8(b));
                        }
                        else
                        {
                            v128 mask = dec_epi8(b);

                            result = andnot_si128(mask, add_epi8(a, and_si128(mask, srai_epi8(a, 7))));
                        }
                    }
                    else
                    {
                        result = divmullo_epi8(a, b, b, out _, noOverflow: true, saturated: false, elements);
                    }

                    Assume.truncmultiple(result.SByte0,  a.SByte0,  b.Byte0,  pow2);
                    Assume.truncmultiple(result.SByte1,  a.SByte1,  b.Byte1,  pow2);

                    if (elements > 2)
                    {
                        Assume.truncmultiple(result.SByte2,  a.SByte2,  b.Byte2,  pow2);

                        if (elements > 3)
                        {
                            Assume.truncmultiple(result.SByte3,  a.SByte3,  b.Byte3,  pow2);

                            if (elements > 4)
                            {
                                Assume.truncmultiple(result.SByte4,  a.SByte4,  b.Byte4,  pow2);
                                Assume.truncmultiple(result.SByte5,  a.SByte5,  b.Byte5,  pow2);
                                Assume.truncmultiple(result.SByte6,  a.SByte6,  b.Byte6,  pow2);
                                Assume.truncmultiple(result.SByte7,  a.SByte7,  b.Byte7,  pow2);

                                if (elements > 8)
                                {
                                    Assume.truncmultiple(result.SByte8,  a.SByte8,  b.Byte8,  pow2);
                                    Assume.truncmultiple(result.SByte9,  a.SByte9,  b.Byte9,  pow2);
                                    Assume.truncmultiple(result.SByte10, a.SByte10, b.Byte10, pow2);
                                    Assume.truncmultiple(result.SByte11, a.SByte11, b.Byte11, pow2);
                                    Assume.truncmultiple(result.SByte12, a.SByte12, b.Byte12, pow2);
                                    Assume.truncmultiple(result.SByte13, a.SByte13, b.Byte13, pow2);
                                    Assume.truncmultiple(result.SByte14, a.SByte14, b.Byte14, pow2);
                                    Assume.truncmultiple(result.SByte15, a.SByte15, b.Byte15, pow2);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI16(a, 0, elements))
                        {
                            result = and_si128(a, neg_epi16(b));
                        }
                        else
                        {
                            v128 mask = dec_epi16(b);

                            result = andnot_si128(mask, add_epi16(a, and_si128(mask, srai_epi16(a, 15))));
                        }
                    }
                    else
                    {
                        result = mullo_epi16(b, div_epi16(a, b, elements: elements));
                    }

                    Assume.truncmultiple(result.SShort0, a.SShort0, b.UShort0, pow2);
                    Assume.truncmultiple(result.SShort1, a.SShort1, b.UShort1, pow2);

                    if (elements > 2)
                    {
                        Assume.truncmultiple(result.SShort2, a.SShort2, b.UShort2, pow2);

                        if (elements > 3)
                        {
                            Assume.truncmultiple(result.SShort3, a.SShort3, b.UShort3, pow2);

                            if (elements > 4)
                            {
                                Assume.truncmultiple(result.SShort4, a.SShort4, b.UShort4, pow2);
                                Assume.truncmultiple(result.SShort5, a.SShort5, b.UShort5, pow2);
                                Assume.truncmultiple(result.SShort6, a.SShort6, b.UShort6, pow2);
                                Assume.truncmultiple(result.SShort7, a.SShort7, b.UShort7, pow2);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI32(a, 0, elements))
                        {
                            result = and_si128(a, neg_epi32(b));
                        }
                        else
                        {
                            v128 mask = dec_epi32(b);

                            result = andnot_si128(mask, add_epi32(a, and_si128(mask, srai_epi32(a, 31))));
                        }
                    }
                    else
                    {
                        result = mullo_epi32(b, div_epi32(a, b, elements), elements);
                    }

                    Assume.truncmultiple(result.SInt0, a.SInt0, b.UInt0, pow2);
                    Assume.truncmultiple(result.SInt1, a.SInt1, b.UInt1, pow2);

                    if (elements > 2)
                    {
                        Assume.truncmultiple(result.SInt2, a.SInt2, b.UInt2, pow2);

                        if (elements > 3)
                        {
                            Assume.truncmultiple(result.SInt3, a.SInt3, b.UInt3, pow2);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi64(v128 a, v128 b, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI64(a, 0))
                        {
                            result = and_si128(a, neg_epi64(b));
                        }
                        else
                        {
                            v128 mask = dec_epi64(b);

                            result = andnot_si128(mask, add_epi64(a, and_si128(mask, srai_epi64(a, 63))));
                        }
                    }
                    else
                    {
                        result = sub_epi64(a, rem_epi64(a, b));
                    }

                    Assume.truncmultiple(result.SLong0, a.SLong0, b.ULong0, pow2);
                    Assume.truncmultiple(result.SLong1, a.SLong1, b.ULong1, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu8(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu8(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu16(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu16(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu32(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu32(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu64(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi8(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI8(a, 0))
                        {
                            result = Avx2.mm256_and_si256(a, mm256_neg_epi8(b));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi8(b);

                            result = Avx2.mm256_andnot_si256(mask, Avx2.mm256_add_epi8(a, Avx2.mm256_and_si256(mask, mm256_srai_epi8(a, 7))));
                        }
                    }
                    else
                    {
                        result = mm256_divmullo_epi8(a, b, b, out _, noOverflow: true);
                    }

                    Assume.truncmultiple(result.SByte0,  a.SByte0,  b.Byte0,  pow2);
                    Assume.truncmultiple(result.SByte1,  a.SByte1,  b.Byte1,  pow2);
                    Assume.truncmultiple(result.SByte2,  a.SByte2,  b.Byte2,  pow2);
                    Assume.truncmultiple(result.SByte3,  a.SByte3,  b.Byte3,  pow2);
                    Assume.truncmultiple(result.SByte4,  a.SByte4,  b.Byte4,  pow2);
                    Assume.truncmultiple(result.SByte5,  a.SByte5,  b.Byte5,  pow2);
                    Assume.truncmultiple(result.SByte6,  a.SByte6,  b.Byte6,  pow2);
                    Assume.truncmultiple(result.SByte7,  a.SByte7,  b.Byte7,  pow2);
                    Assume.truncmultiple(result.SByte8,  a.SByte8,  b.Byte8,  pow2);
                    Assume.truncmultiple(result.SByte9,  a.SByte9,  b.Byte9,  pow2);
                    Assume.truncmultiple(result.SByte10, a.SByte10, b.Byte10, pow2);
                    Assume.truncmultiple(result.SByte11, a.SByte11, b.Byte11, pow2);
                    Assume.truncmultiple(result.SByte12, a.SByte12, b.Byte12, pow2);
                    Assume.truncmultiple(result.SByte13, a.SByte13, b.Byte13, pow2);
                    Assume.truncmultiple(result.SByte14, a.SByte14, b.Byte14, pow2);
                    Assume.truncmultiple(result.SByte15, a.SByte15, b.Byte15, pow2);
                    Assume.truncmultiple(result.SByte16, a.SByte16, b.Byte16, pow2);
                    Assume.truncmultiple(result.SByte17, a.SByte17, b.Byte17, pow2);
                    Assume.truncmultiple(result.SByte18, a.SByte18, b.Byte18, pow2);
                    Assume.truncmultiple(result.SByte19, a.SByte19, b.Byte19, pow2);
                    Assume.truncmultiple(result.SByte20, a.SByte20, b.Byte20, pow2);
                    Assume.truncmultiple(result.SByte21, a.SByte21, b.Byte21, pow2);
                    Assume.truncmultiple(result.SByte22, a.SByte22, b.Byte22, pow2);
                    Assume.truncmultiple(result.SByte23, a.SByte23, b.Byte23, pow2);
                    Assume.truncmultiple(result.SByte24, a.SByte24, b.Byte24, pow2);
                    Assume.truncmultiple(result.SByte25, a.SByte25, b.Byte25, pow2);
                    Assume.truncmultiple(result.SByte26, a.SByte26, b.Byte26, pow2);
                    Assume.truncmultiple(result.SByte27, a.SByte27, b.Byte27, pow2);
                    Assume.truncmultiple(result.SByte28, a.SByte28, b.Byte28, pow2);
                    Assume.truncmultiple(result.SByte29, a.SByte29, b.Byte29, pow2);
                    Assume.truncmultiple(result.SByte30, a.SByte30, b.Byte30, pow2);
                    Assume.truncmultiple(result.SByte31, a.SByte31, b.Byte31, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi16(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI16(a, 0))
                        {
                            result = Avx2.mm256_and_si256(a, mm256_neg_epi16(b));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi16(b);

                            result = Avx2.mm256_andnot_si256(mask, Avx2.mm256_add_epi16(a, Avx2.mm256_and_si256(mask, Avx2.mm256_srai_epi16(a, 15))));
                        }
                    }
                    else
                    {
                        result = Avx2.mm256_mullo_epi16(b, mm256_div_epi16(a, b));
                    }

                    Assume.truncmultiple(result.SShort0,  a.SShort0,  b.UShort0,  pow2);
                    Assume.truncmultiple(result.SShort1,  a.SShort1,  b.UShort1,  pow2);
                    Assume.truncmultiple(result.SShort2,  a.SShort2,  b.UShort2,  pow2);
                    Assume.truncmultiple(result.SShort3,  a.SShort3,  b.UShort3,  pow2);
                    Assume.truncmultiple(result.SShort4,  a.SShort4,  b.UShort4,  pow2);
                    Assume.truncmultiple(result.SShort5,  a.SShort5,  b.UShort5,  pow2);
                    Assume.truncmultiple(result.SShort6,  a.SShort6,  b.UShort6,  pow2);
                    Assume.truncmultiple(result.SShort7,  a.SShort7,  b.UShort7,  pow2);
                    Assume.truncmultiple(result.SShort8,  a.SShort8,  b.UShort8,  pow2);
                    Assume.truncmultiple(result.SShort9,  a.SShort9,  b.UShort9,  pow2);
                    Assume.truncmultiple(result.SShort10, a.SShort10, b.UShort10, pow2);
                    Assume.truncmultiple(result.SShort11, a.SShort11, b.UShort11, pow2);
                    Assume.truncmultiple(result.SShort12, a.SShort12, b.UShort12, pow2);
                    Assume.truncmultiple(result.SShort13, a.SShort13, b.UShort13, pow2);
                    Assume.truncmultiple(result.SShort14, a.SShort14, b.UShort14, pow2);
                    Assume.truncmultiple(result.SShort15, a.SShort15, b.UShort15, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi32(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI32(a, 0))
                        {
                            result = Avx2.mm256_and_si256(a, mm256_neg_epi32(b));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi32(b);

                            result = Avx2.mm256_andnot_si256(mask, Avx2.mm256_add_epi32(a, Avx2.mm256_and_si256(mask, Avx2.mm256_srai_epi32(a, 31))));
                        }
                    }
                    else
                    {
                        result = Avx2.mm256_mullo_epi32(b, mm256_div_epi32(a, b));
                    }

                    Assume.truncmultiple(result.SInt0, a.SInt0, b.UInt0, pow2);
                    Assume.truncmultiple(result.SInt1, a.SInt1, b.UInt1, pow2);
                    Assume.truncmultiple(result.SInt2, a.SInt2, b.UInt2, pow2);
                    Assume.truncmultiple(result.SInt3, a.SInt3, b.UInt3, pow2);
                    Assume.truncmultiple(result.SInt4, a.SInt4, b.UInt4, pow2);
                    Assume.truncmultiple(result.SInt5, a.SInt5, b.UInt5, pow2);
                    Assume.truncmultiple(result.SInt6, a.SInt6, b.UInt6, pow2);
                    Assume.truncmultiple(result.SInt7, a.SInt7, b.UInt7, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI64(a, 0, elements))
                        {
                            result = Avx2.mm256_and_si256(a, mm256_neg_epi64(b));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi64(b);

                            result = Avx2.mm256_andnot_si256(mask, Avx2.mm256_add_epi64(a, Avx2.mm256_and_si256(mask, mm256_srai_epi64(a, 63, elements))));
                        }
                    }
                    else
                    {
                        result = Avx2.mm256_sub_epi64(a, mm256_rem_epi64(a, b, elements: elements));
                    }

                    Assume.truncmultiple(result.SLong0, a.SLong0, b.ULong0, pow2);
                    Assume.truncmultiple(result.SLong1, a.SLong1, b.ULong1, pow2);
                    Assume.truncmultiple(result.SLong2, a.SLong2, b.ULong2, pow2);

                    if (elements > 3)
                    {
                        Assume.truncmultiple(result.SLong3, a.SLong3, b.ULong3, pow2);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_ps(b, trunc_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_trunc_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_pd(b, trunc_pd(div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_trunc_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void truncmultiple(sbyte result, sbyte x, byte n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (n - 1)) == 0);
            }

            constexpr.ASSUME((result % (sbyte)n) == 0);

            if (constexpr.IS_TRUE(x >= 0))
            {
                constexpr.ASSUME(result >= 0);
                constexpr.ASSUME(result <= x);
                if (constexpr.IS_TRUE(n <= sbyte.MaxValue))
                {
                    constexpr.ASSUME((sbyte)(x - result) < n);
                }
            }
            else if (constexpr.IS_TRUE(x < 0))
            {
                constexpr.ASSUME(result <= 0);
                constexpr.ASSUME(result >= x);
                if (constexpr.IS_TRUE(n <= sbyte.MaxValue))
                {
                    constexpr.ASSUME((sbyte)(result - x) < n);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void truncmultiple(short result, short x, ushort n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (n - 1)) == 0);
            }

            constexpr.ASSUME((result % (short)n) == 0);
            
            if (constexpr.IS_TRUE(x >= 0))
            {
                constexpr.ASSUME(result >= 0);
                constexpr.ASSUME(result <= x);
                if (constexpr.IS_TRUE(n <= short.MaxValue))
                {
                    constexpr.ASSUME((short)(x - result) < n);
                }
            }
            else if (constexpr.IS_TRUE(x < 0))
            {
                constexpr.ASSUME(result <= 0);
                constexpr.ASSUME(result >= x);
                if (constexpr.IS_TRUE(n <= short.MaxValue))
                {
                    constexpr.ASSUME((short)(result - x) < n);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void truncmultiple(int result, int x, uint n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (int)(n - 1)) == 0);
            }

            constexpr.ASSUME((result % (int)n) == 0);
            
            if (constexpr.IS_TRUE(x >= 0))
            {
                constexpr.ASSUME(result >= 0);
                constexpr.ASSUME(result <= x);
                if (constexpr.IS_TRUE(n <= int.MaxValue))
                {
                    constexpr.ASSUME(x - result < (int)n);
                }
            }
            else if (constexpr.IS_TRUE(x < 0))
            {
                constexpr.ASSUME(result <= 0);
                constexpr.ASSUME(result >= x);
                if (constexpr.IS_TRUE(n <= int.MaxValue))
                {
                    constexpr.ASSUME(result - x < (int)n);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void truncmultiple(long result, long x, ulong n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (long)(n - 1)) == 0);
            }

            constexpr.ASSUME((result % (long)n) == 0);
            
            if (constexpr.IS_TRUE(x >= 0))
            {
                constexpr.ASSUME(result >= 0);
                constexpr.ASSUME(result <= x);
                if (constexpr.IS_TRUE(n <= long.MaxValue))
                {
                    constexpr.ASSUME(x - result < (long)n);
                }
            }
            else if (constexpr.IS_TRUE(x < 0))
            {
                constexpr.ASSUME(result <= 0);
                constexpr.ASSUME(result >= x);
                if (constexpr.IS_TRUE(n <= long.MaxValue))
                {
                    constexpr.ASSUME(result - x < (long)n);
                }
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 truncmultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 truncmultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            Int128 result;
            
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
                {
                    result = x & -(Int128)n;
                }
                else
                {
                    UInt128 mask = n - 1;

                    result = andnot(x + ((Int128)mask & (x >> 127)), (Int128)mask);
                }
            }
            else
            {
                result = (Int128)n * (x / (Int128)n);
            }
            
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                constexpr.ASSUME((result & (Int128)(n - 1)) == 0);
            }

            //constexpr.ASSUME((result % (Int128)n) == 0);
            
            if (constexpr.IS_TRUE(x >= 0))
            {
                constexpr.ASSUME(result >= 0);
                constexpr.ASSUME(result <= x);
                if (constexpr.IS_TRUE(n <= (UInt128)Int128.MaxValue))
                {
                    constexpr.ASSUME(x - result < (Int128)n);
                }
            }
            else if (constexpr.IS_TRUE(x < 0))
            {
                constexpr.ASSUME(result <= 0);
                constexpr.ASSUME(result >= x);
                if (constexpr.IS_TRUE(n <= (UInt128)Int128.MaxValue))
                {
                    constexpr.ASSUME(result - x < (Int128)n);
                }
            }

            return result;
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong truncmultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 truncmultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 truncmultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 truncmultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long truncmultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            long result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
                {
                    result = x & -(long)n;
                }
                else
                {
                    ulong mask = n - 1;

                    result = andnot(x + ((long)mask & (x >> 63)), (long)mask);
                }
            }
            else
            {
                result = (long)n * (x / (long)n);
            }

            Assume.truncmultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 truncmultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 truncmultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long3(truncmultiple(x.xy, n.xy, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 truncmultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long4(truncmultiple(x.xy, n.xy, promises), truncmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint truncmultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 truncmultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 truncmultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 truncmultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 truncmultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int truncmultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            int result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
                {
                    result = x & -(int)n;
                }
                else
                {
                    uint mask = n - 1;

                    result = andnot(x + ((int)mask & (x >> 31)), (int)mask);
                }
            }
            else
            {
                result = (int)n * (x / (int)n);
            }

            Assume.truncmultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 truncmultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi32(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 truncmultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi32(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int3(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 truncmultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi32(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int4(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises), truncmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 truncmultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int8(truncmultiple(x.v4_0, n.v4_0, promises), truncmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort truncmultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 truncmultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 truncmultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 truncmultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 truncmultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 truncmultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short truncmultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)truncmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 truncmultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 truncmultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short3(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 truncmultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short4(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises), truncmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 truncmultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short8(truncmultiple(x.x0, n.x0, promises),
                                  truncmultiple(x.x1, n.x1, promises),
                                  truncmultiple(x.x2, n.x2, promises),
                                  truncmultiple(x.x3, n.x3, promises),
                                  truncmultiple(x.x4, n.x4, promises),
                                  truncmultiple(x.x5, n.x5, promises),
                                  truncmultiple(x.x6, n.x6, promises),
                                  truncmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 truncmultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short16(truncmultiple(x.v8_0, n.v8_0, promises), truncmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte truncmultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 truncmultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 truncmultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 truncmultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 truncmultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 truncmultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 truncmultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte truncmultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)truncmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 truncmultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 truncmultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte3(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 truncmultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte4(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises), truncmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 truncmultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte8(truncmultiple(x.x0, n.x0, promises),
                                  truncmultiple(x.x1, n.x1, promises),
                                  truncmultiple(x.x2, n.x2, promises),
                                  truncmultiple(x.x3, n.x3, promises),
                                  truncmultiple(x.x4, n.x4, promises),
                                  truncmultiple(x.x5, n.x5, promises),
                                  truncmultiple(x.x6, n.x6, promises),
                                  truncmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 truncmultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte16(truncmultiple(x.x0,  n.x0,  promises),
                                   truncmultiple(x.x1,  n.x1,  promises),
                                   truncmultiple(x.x2,  n.x2,  promises),
                                   truncmultiple(x.x3,  n.x3,  promises),
                                   truncmultiple(x.x4,  n.x4,  promises),
                                   truncmultiple(x.x5,  n.x5,  promises),
                                   truncmultiple(x.x6,  n.x6,  promises),
                                   truncmultiple(x.x7,  n.x7,  promises),
                                   truncmultiple(x.x8,  n.x8,  promises),
                                   truncmultiple(x.x9,  n.x9,  promises),
                                   truncmultiple(x.x10, n.x10, promises),
                                   truncmultiple(x.x11, n.x11, promises),
                                   truncmultiple(x.x12, n.x12, promises),
                                   truncmultiple(x.x13, n.x13, promises),
                                   truncmultiple(x.x14, n.x14, promises),
                                   truncmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 truncmultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(truncmultiple(x.v16_0, n.v16_0, promises), truncmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float truncmultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * trunc(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 truncmultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_ps(x, m, 2);
            }
            else
            {
                return new float2(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 truncmultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_ps(x, m, 3);
            }
            else
            {
                return new float3(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y), truncmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 truncmultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_ps(x, m, 4);
            }
            else
            {
                return new float4(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y), truncmultiple(x.z, m.z), truncmultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 truncmultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_truncmult_ps(x, m);
            }
            else
            {
                return new float8(truncmultiple(x.v4_0, m.v4_0), truncmultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double truncmultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * trunc(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 truncmultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.truncmult_ps(x, m, 2);
            }
            else
            {
                return new double2(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 truncmultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_truncmult_ps(x, m);
            }
            else
            {
                return new double3(truncmultiple(x.xy, m.xy), truncmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 truncmultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_truncmult_ps(x, m);
            }
            else
            {
                return new double4(truncmultiple(x.xy, m.xy), truncmultiple(x.zw, m.zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple truncmultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * trunc(x / m);
        }
    }
}