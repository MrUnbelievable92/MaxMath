using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using DevTools;
using MaxMath.Intrinsics;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU8(b, elements);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi8(b));
                    }
                    else
                    {
                        result = divmullo_epu8(a, b, b, out _, noOverflow: true, elements);
                    }

                    Assume.floormultiple(result.Byte0,  a.Byte0,  b.Byte0,  pow2);
                    Assume.floormultiple(result.Byte1,  a.Byte1,  b.Byte1,  pow2);

                    if (elements > 2)
                    {
                        Assume.floormultiple(result.Byte2,  a.Byte2,  b.Byte2,  pow2);

                        if (elements > 3)
                        {
                            Assume.floormultiple(result.Byte3,  a.Byte3,  b.Byte3,  pow2);

                            if (elements > 4)
                            {
                                Assume.floormultiple(result.Byte4,  a.Byte4,  b.Byte4,  pow2);
                                Assume.floormultiple(result.Byte5,  a.Byte5,  b.Byte5,  pow2);
                                Assume.floormultiple(result.Byte6,  a.Byte6,  b.Byte6,  pow2);
                                Assume.floormultiple(result.Byte7,  a.Byte7,  b.Byte7,  pow2);

                                if (elements > 8)
                                {
                                    Assume.floormultiple(result.Byte8,  a.Byte8,  b.Byte8,  pow2);
                                    Assume.floormultiple(result.Byte9,  a.Byte9,  b.Byte9,  pow2);
                                    Assume.floormultiple(result.Byte10, a.Byte10, b.Byte10, pow2);
                                    Assume.floormultiple(result.Byte11, a.Byte11, b.Byte11, pow2);
                                    Assume.floormultiple(result.Byte12, a.Byte12, b.Byte12, pow2);
                                    Assume.floormultiple(result.Byte13, a.Byte13, b.Byte13, pow2);
                                    Assume.floormultiple(result.Byte14, a.Byte14, b.Byte14, pow2);
                                    Assume.floormultiple(result.Byte15, a.Byte15, b.Byte15, pow2);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU16(b, elements);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi16(b));
                    }
                    else
                    {
                        result = mullo_epi16(b, div_epu16(a, b, elements));
                    }
                    
                    Assume.floormultiple(result.UShort0, a.UShort0, b.UShort0, pow2);
                    Assume.floormultiple(result.UShort1, a.UShort1, b.UShort1, pow2);

                    if (elements > 2)
                    {
                        Assume.floormultiple(result.UShort2, a.UShort2, b.UShort2, pow2);

                        if (elements > 3)
                        {
                            Assume.floormultiple(result.UShort3, a.UShort3, b.UShort3, pow2);
                            
                            if (elements > 4)
                            {
                                Assume.floormultiple(result.UShort4, a.UShort4, b.UShort4, pow2);
                                Assume.floormultiple(result.UShort5, a.UShort5, b.UShort5, pow2);
                                Assume.floormultiple(result.UShort6, a.UShort6, b.UShort6, pow2);
                                Assume.floormultiple(result.UShort7, a.UShort7, b.UShort7, pow2);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU32(b, elements);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi32(b));
                    }
                    else
                    {
                        result = mullo_epi32(b, div_epu32(a, b, elements), elements);
                    }

                    Assume.floormultiple(result.UInt0, a.UInt0, b.UInt0, pow2);
                    Assume.floormultiple(result.UInt1, a.UInt1, b.UInt1, pow2);

                    if (elements > 2)
                    {
                        Assume.floormultiple(result.UInt2, a.UInt2, b.UInt2, pow2);

                        if (elements > 3)
                        {
                            Assume.floormultiple(result.UInt3, a.UInt3, b.UInt3, pow2);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epu64(v128 a, v128 b, bool pow2 = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU64(b);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi64(b));
                    }
                    else
                    {
                        result = sub_epi64(a, rem_epu64(a, b));
                    }

                    Assume.floormultiple(result.ULong0, a.ULong0, b.ULong0, pow2);
                    Assume.floormultiple(result.ULong1, a.ULong1, b.ULong1, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU8(b, elements);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi8(b));
                    }
                    else
                    {
                        v128 ux = nonNegative ? a : abs_epi8(a);
                        if (nonNegative)
                        {
                            result = divmullo_epu8(ux, b, b, out _, elements: elements);
                        }
                        else
                        {
                            v128 uq = divrem_epu8(ux, b, out v128 ur, elements: elements);
                            v128 umag = mullo_epi8(sub_epi8(uq, andnot_si128(cmpeq_epi8(ur, setzero_si128()), srai_epi8(a, 7))), b, elements);
                            if (Ssse3.IsSsse3Supported)
                            {
                                result = sign_epi8(umag, a);
                            }
                            else
                            {
                                result = srai_epi8(a, 7);
                                result = sub_epi8(xor_si128(umag, result), result);
                            }
                        }
                    }

                    Assume.floormultiple(result.SByte0,  a.SByte0,  b.Byte0,  pow2);
                    Assume.floormultiple(result.SByte1,  a.SByte1,  b.Byte1,  pow2);

                    if (elements > 2)
                    {
                        Assume.floormultiple(result.SByte2,  a.SByte2,  b.Byte2,  pow2);

                        if (elements > 3)
                        {
                            Assume.floormultiple(result.SByte3,  a.SByte3,  b.Byte3,  pow2);

                            if (elements > 4)
                            {
                                Assume.floormultiple(result.SByte4,  a.SByte4,  b.Byte4,  pow2);
                                Assume.floormultiple(result.SByte5,  a.SByte5,  b.Byte5,  pow2);
                                Assume.floormultiple(result.SByte6,  a.SByte6,  b.Byte6,  pow2);
                                Assume.floormultiple(result.SByte7,  a.SByte7,  b.Byte7,  pow2);

                                if (elements > 8)
                                {
                                    Assume.floormultiple(result.SByte8,  a.SByte8,  b.Byte8,  pow2);
                                    Assume.floormultiple(result.SByte9,  a.SByte9,  b.Byte9,  pow2);
                                    Assume.floormultiple(result.SByte10, a.SByte10, b.Byte10, pow2);
                                    Assume.floormultiple(result.SByte11, a.SByte11, b.Byte11, pow2);
                                    Assume.floormultiple(result.SByte12, a.SByte12, b.Byte12, pow2);
                                    Assume.floormultiple(result.SByte13, a.SByte13, b.Byte13, pow2);
                                    Assume.floormultiple(result.SByte14, a.SByte14, b.Byte14, pow2);
                                    Assume.floormultiple(result.SByte15, a.SByte15, b.Byte15, pow2);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU16(b, elements);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi16(b));
                    }
                    else
                    {
                        v128 ux = nonNegative ? a : abs_epi16(a);
                        if (nonNegative)
                        {
                            v128 q = div_epu16(ux, b, elements);
                            result = Sse2.mullo_epi16(q, b);
                        }
                        else
                        {
                            v128 uq = divrem_epu16(ux, b, out v128 ur, elements);
                            v128 umag = Sse2.mullo_epi16(sub_epi16(uq, andnot_si128(cmpeq_epi16(ur, setzero_si128()), srai_epi16(a, 15))), b);
                            if (Ssse3.IsSsse3Supported)
                            {
                                result = sign_epi16(umag, a);
                            }
                            else
                            {
                                result = srai_epi16(a, 15);
                                result = sub_epi16(xor_si128(umag, result), result);
                            }
                        }
                    }

                    Assume.floormultiple(result.SShort0, a.SShort0, b.UShort0, pow2);
                    Assume.floormultiple(result.SShort1, a.SShort1, b.UShort1, pow2);

                    if (elements > 2)
                    {
                        Assume.floormultiple(result.SShort2, a.SShort2, b.UShort2, pow2);

                        if (elements > 3)
                        {
                            Assume.floormultiple(result.SShort3, a.SShort3, b.UShort3, pow2);

                            if (elements > 4)
                            {
                                Assume.floormultiple(result.SShort4, a.SShort4, b.UShort4, pow2);
                                Assume.floormultiple(result.SShort5, a.SShort5, b.UShort5, pow2);
                                Assume.floormultiple(result.SShort6, a.SShort6, b.UShort6, pow2);
                                Assume.floormultiple(result.SShort7, a.SShort7, b.UShort7, pow2);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU32(b, elements);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi32(b));
                    }
                    else
                    {
                        v128 ux = nonNegative ? a : abs_epi32(a);
                        if (nonNegative)
                        {
                            v128 q = div_epu32(ux, b, elements);
                            result = mullo_epi32(q, b, elements);
                        }
                        else
                        {
                            v128 uq = divrem_epu32(ux, b, out v128 ur, elements);
                            v128 umag = mullo_epi32(sub_epi32(uq, andnot_si128(cmpeq_epi32(ur, setzero_si128()), srai_epi32(a, 31))), b, elements);
                            if (Ssse3.IsSsse3Supported)
                            {
                                result = sign_epi32(umag, a);
                            }
                            else
                            {
                                result = srai_epi32(a, 31);
                                result = sub_epi32(xor_si128(umag, result), result);
                            }
                        }
                    }

                    Assume.floormultiple(result.SInt0, a.SInt0, b.UInt0, pow2);
                    Assume.floormultiple(result.SInt1, a.SInt1, b.UInt1, pow2);

                    if (elements > 2)
                    {
                        Assume.floormultiple(result.SInt2, a.SInt2, b.UInt2, pow2);

                        if (elements > 3)
                        {
                            Assume.floormultiple(result.SInt3, a.SInt3, b.UInt3, pow2);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epi64(v128 a, v128 b, bool pow2 = false, bool nonNegative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU64(b);

                    v128 result;

                    if (pow2)
                    {
                        result = and_si128(a, neg_epi64(b));
                    }
                    else
                    {
                        v128 ux = nonNegative ? a : abs_epi64(a);
                        if (nonNegative)
                        {
                            v128 q = div_epu64(ux, b);
                            result = mullo_epi64(q, b);
                        }
                        else
                        {
                            v128 uq = divrem_epu64(ux, b, out v128 ur);
                            v128 umag = mullo_epi64(sub_epi64(uq, andnot_si128(cmpeq_epi64(ur, setzero_si128()), srai_epi64(a, 63))), b);
                            result = srai_epi64(a, 63);
                            result = sub_epi64(xor_si128(umag, result), result);
                        }
                    }

                    Assume.floormultiple(result.SLong0, a.SLong0, b.ULong0, pow2);
                    Assume.floormultiple(result.SLong1, a.SLong1, b.ULong1, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu8(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU8(b);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi8(b));
                    }
                    else
                    {
                        result = mm256_divmullo_epu8(a, b, b, out _, noOverflow: true);
                    }

                    Assume.floormultiple(result.Byte0,  a.Byte0,  b.Byte0,  pow2);
                    Assume.floormultiple(result.Byte1,  a.Byte1,  b.Byte1,  pow2);
                    Assume.floormultiple(result.Byte2,  a.Byte2,  b.Byte2,  pow2);
                    Assume.floormultiple(result.Byte3,  a.Byte3,  b.Byte3,  pow2);
                    Assume.floormultiple(result.Byte4,  a.Byte4,  b.Byte4,  pow2);
                    Assume.floormultiple(result.Byte5,  a.Byte5,  b.Byte5,  pow2);
                    Assume.floormultiple(result.Byte6,  a.Byte6,  b.Byte6,  pow2);
                    Assume.floormultiple(result.Byte7,  a.Byte7,  b.Byte7,  pow2);
                    Assume.floormultiple(result.Byte8,  a.Byte8,  b.Byte8,  pow2);
                    Assume.floormultiple(result.Byte9,  a.Byte9,  b.Byte9,  pow2);
                    Assume.floormultiple(result.Byte10, a.Byte10, b.Byte10, pow2);
                    Assume.floormultiple(result.Byte11, a.Byte11, b.Byte11, pow2);
                    Assume.floormultiple(result.Byte12, a.Byte12, b.Byte12, pow2);
                    Assume.floormultiple(result.Byte13, a.Byte13, b.Byte13, pow2);
                    Assume.floormultiple(result.Byte14, a.Byte14, b.Byte14, pow2);
                    Assume.floormultiple(result.Byte15, a.Byte15, b.Byte15, pow2);
                    Assume.floormultiple(result.Byte16, a.Byte16, b.Byte16, pow2);
                    Assume.floormultiple(result.Byte17, a.Byte17, b.Byte17, pow2);
                    Assume.floormultiple(result.Byte18, a.Byte18, b.Byte18, pow2);
                    Assume.floormultiple(result.Byte19, a.Byte19, b.Byte19, pow2);
                    Assume.floormultiple(result.Byte20, a.Byte20, b.Byte20, pow2);
                    Assume.floormultiple(result.Byte21, a.Byte21, b.Byte21, pow2);
                    Assume.floormultiple(result.Byte22, a.Byte22, b.Byte22, pow2);
                    Assume.floormultiple(result.Byte23, a.Byte23, b.Byte23, pow2);
                    Assume.floormultiple(result.Byte24, a.Byte24, b.Byte24, pow2);
                    Assume.floormultiple(result.Byte25, a.Byte25, b.Byte25, pow2);
                    Assume.floormultiple(result.Byte26, a.Byte26, b.Byte26, pow2);
                    Assume.floormultiple(result.Byte27, a.Byte27, b.Byte27, pow2);
                    Assume.floormultiple(result.Byte28, a.Byte28, b.Byte28, pow2);
                    Assume.floormultiple(result.Byte29, a.Byte29, b.Byte29, pow2);
                    Assume.floormultiple(result.Byte30, a.Byte30, b.Byte30, pow2);
                    Assume.floormultiple(result.Byte31, a.Byte31, b.Byte31, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu16(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU16(b);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi16(b));
                    }
                    else
                    {
                        result = Avx2.mm256_mullo_epi16(b, mm256_div_epu16(a, b));
                    }

                    Assume.floormultiple(result.UShort0,  a.UShort0,  b.UShort0,  pow2);
                    Assume.floormultiple(result.UShort1,  a.UShort1,  b.UShort1,  pow2);
                    Assume.floormultiple(result.UShort2,  a.UShort2,  b.UShort2,  pow2);
                    Assume.floormultiple(result.UShort3,  a.UShort3,  b.UShort3,  pow2);
                    Assume.floormultiple(result.UShort4,  a.UShort4,  b.UShort4,  pow2);
                    Assume.floormultiple(result.UShort5,  a.UShort5,  b.UShort5,  pow2);
                    Assume.floormultiple(result.UShort6,  a.UShort6,  b.UShort6,  pow2);
                    Assume.floormultiple(result.UShort7,  a.UShort7,  b.UShort7,  pow2);
                    Assume.floormultiple(result.UShort8,  a.UShort8,  b.UShort8,  pow2);
                    Assume.floormultiple(result.UShort9,  a.UShort9,  b.UShort9,  pow2);
                    Assume.floormultiple(result.UShort10, a.UShort10, b.UShort10, pow2);
                    Assume.floormultiple(result.UShort11, a.UShort11, b.UShort11, pow2);
                    Assume.floormultiple(result.UShort12, a.UShort12, b.UShort12, pow2);
                    Assume.floormultiple(result.UShort13, a.UShort13, b.UShort13, pow2);
                    Assume.floormultiple(result.UShort14, a.UShort14, b.UShort14, pow2);
                    Assume.floormultiple(result.UShort15, a.UShort15, b.UShort15, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu32(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU32(b);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi32(b));
                    }
                    else
                    {
                        result = Avx2.mm256_mullo_epi32(b, mm256_div_epu32(a, b));
                    }

                    Assume.floormultiple(result.UInt0, a.UInt0, b.UInt0, pow2);
                    Assume.floormultiple(result.UInt1, a.UInt1, b.UInt1, pow2);
                    Assume.floormultiple(result.UInt2, a.UInt2, b.UInt2, pow2);
                    Assume.floormultiple(result.UInt3, a.UInt3, b.UInt3, pow2);
                    Assume.floormultiple(result.UInt4, a.UInt4, b.UInt4, pow2);
                    Assume.floormultiple(result.UInt5, a.UInt5, b.UInt5, pow2);
                    Assume.floormultiple(result.UInt6, a.UInt6, b.UInt6, pow2);
                    Assume.floormultiple(result.UInt7, a.UInt7, b.UInt7, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU64(b, elements);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi64(b));
                    }
                    else
                    {
                        result = Avx2.mm256_sub_epi64(a, mm256_rem_epu64(a, b, elements: elements));
                    }

                    Assume.floormultiple(result.ULong0, a.ULong0, b.ULong0, pow2);
                    Assume.floormultiple(result.ULong1, a.ULong1, b.ULong1, pow2);
                    Assume.floormultiple(result.ULong2, a.ULong2, b.ULong2, pow2);
                    
                    if (elements > 3)
                    {
                        Assume.floormultiple(result.ULong3, a.ULong3, b.ULong3, pow2);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi8(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU8(b);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi8(b));
                    }
                    else
                    {
                        v256 ux = nonNegative ? a : mm256_abs_epi8(a);
                        if (nonNegative)
                        {
                            result = mm256_divmullo_epu8(ux, b, b, out _);
                        }
                        else
                        {
                            v256 uq = mm256_divrem_epu8(ux, b, out v256 ur);
                            v256 umag = mm256_mullo_epi8(Avx2.mm256_sub_epi8(uq, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(ur, Avx.mm256_setzero_si256()), mm256_srai_epi8(a, 7))), b);
                            result = Avx2.mm256_sign_epi8(umag, a);
                        }
                    }

                    Assume.floormultiple(result.SByte0,  a.SByte0,  b.Byte0,  pow2);
                    Assume.floormultiple(result.SByte1,  a.SByte1,  b.Byte1,  pow2);
                    Assume.floormultiple(result.SByte2,  a.SByte2,  b.Byte2,  pow2);
                    Assume.floormultiple(result.SByte3,  a.SByte3,  b.Byte3,  pow2);
                    Assume.floormultiple(result.SByte4,  a.SByte4,  b.Byte4,  pow2);
                    Assume.floormultiple(result.SByte5,  a.SByte5,  b.Byte5,  pow2);
                    Assume.floormultiple(result.SByte6,  a.SByte6,  b.Byte6,  pow2);
                    Assume.floormultiple(result.SByte7,  a.SByte7,  b.Byte7,  pow2);
                    Assume.floormultiple(result.SByte8,  a.SByte8,  b.Byte8,  pow2);
                    Assume.floormultiple(result.SByte9,  a.SByte9,  b.Byte9,  pow2);
                    Assume.floormultiple(result.SByte10, a.SByte10, b.Byte10, pow2);
                    Assume.floormultiple(result.SByte11, a.SByte11, b.Byte11, pow2);
                    Assume.floormultiple(result.SByte12, a.SByte12, b.Byte12, pow2);
                    Assume.floormultiple(result.SByte13, a.SByte13, b.Byte13, pow2);
                    Assume.floormultiple(result.SByte14, a.SByte14, b.Byte14, pow2);
                    Assume.floormultiple(result.SByte15, a.SByte15, b.Byte15, pow2);
                    Assume.floormultiple(result.SByte16, a.SByte16, b.Byte16, pow2);
                    Assume.floormultiple(result.SByte17, a.SByte17, b.Byte17, pow2);
                    Assume.floormultiple(result.SByte18, a.SByte18, b.Byte18, pow2);
                    Assume.floormultiple(result.SByte19, a.SByte19, b.Byte19, pow2);
                    Assume.floormultiple(result.SByte20, a.SByte20, b.Byte20, pow2);
                    Assume.floormultiple(result.SByte21, a.SByte21, b.Byte21, pow2);
                    Assume.floormultiple(result.SByte22, a.SByte22, b.Byte22, pow2);
                    Assume.floormultiple(result.SByte23, a.SByte23, b.Byte23, pow2);
                    Assume.floormultiple(result.SByte24, a.SByte24, b.Byte24, pow2);
                    Assume.floormultiple(result.SByte25, a.SByte25, b.Byte25, pow2);
                    Assume.floormultiple(result.SByte26, a.SByte26, b.Byte26, pow2);
                    Assume.floormultiple(result.SByte27, a.SByte27, b.Byte27, pow2);
                    Assume.floormultiple(result.SByte28, a.SByte28, b.Byte28, pow2);
                    Assume.floormultiple(result.SByte29, a.SByte29, b.Byte29, pow2);
                    Assume.floormultiple(result.SByte30, a.SByte30, b.Byte30, pow2);
                    Assume.floormultiple(result.SByte31, a.SByte31, b.Byte31, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi16(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU16(b);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi16(b));
                    }
                    else
                    {
                        v256 ux = nonNegative ? a : mm256_abs_epi16(a);
                        if (nonNegative)
                        {
                            v256 q = mm256_div_epu16(ux, b);
                            result = Avx2.mm256_mullo_epi16(q, b);
                        }
                        else
                        {
                            v256 uq = mm256_divrem_epu16(ux, b, out v256 ur);
                            v256 umag = Avx2.mm256_mullo_epi16(Avx2.mm256_sub_epi16(uq, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(ur, Avx.mm256_setzero_si256()), mm256_srai_epi16(a, 15))), b);
                            result = Avx2.mm256_sign_epi16(umag, a);
                        }
                    }

                    Assume.floormultiple(result.SShort0,  a.SShort0,  b.UShort0,  pow2);
                    Assume.floormultiple(result.SShort1,  a.SShort1,  b.UShort1,  pow2);
                    Assume.floormultiple(result.SShort2,  a.SShort2,  b.UShort2,  pow2);
                    Assume.floormultiple(result.SShort3,  a.SShort3,  b.UShort3,  pow2);
                    Assume.floormultiple(result.SShort4,  a.SShort4,  b.UShort4,  pow2);
                    Assume.floormultiple(result.SShort5,  a.SShort5,  b.UShort5,  pow2);
                    Assume.floormultiple(result.SShort6,  a.SShort6,  b.UShort6,  pow2);
                    Assume.floormultiple(result.SShort7,  a.SShort7,  b.UShort7,  pow2);
                    Assume.floormultiple(result.SShort8,  a.SShort8,  b.UShort8,  pow2);
                    Assume.floormultiple(result.SShort9,  a.SShort9,  b.UShort9,  pow2);
                    Assume.floormultiple(result.SShort10, a.SShort10, b.UShort10, pow2);
                    Assume.floormultiple(result.SShort11, a.SShort11, b.UShort11, pow2);
                    Assume.floormultiple(result.SShort12, a.SShort12, b.UShort12, pow2);
                    Assume.floormultiple(result.SShort13, a.SShort13, b.UShort13, pow2);
                    Assume.floormultiple(result.SShort14, a.SShort14, b.UShort14, pow2);
                    Assume.floormultiple(result.SShort15, a.SShort15, b.UShort15, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi32(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU32(b);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi32(b));
                    }
                    else
                    {
                        v256 ux = nonNegative ? a : mm256_abs_epi32(a);
                        if (nonNegative)
                        {
                            v256 q = mm256_div_epu32(ux, b);
                            result = Avx2.mm256_mullo_epi32(q, b);
                        }
                        else
                        {
                            v256 uq = mm256_divrem_epu32(ux, b, out v256 ur);
                            v256 umag = Avx2.mm256_mullo_epi32(Avx2.mm256_sub_epi32(uq, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(ur, Avx.mm256_setzero_si256()), mm256_srai_epi32(a, 31))), b);
                            result = Avx2.mm256_sign_epi32(umag, a);
                        }
                    }

                    Assume.floormultiple(result.SInt0, a.SInt0, b.UInt0, pow2);
                    Assume.floormultiple(result.SInt1, a.SInt1, b.UInt1, pow2);
                    Assume.floormultiple(result.SInt2, a.SInt2, b.UInt2, pow2);
                    Assume.floormultiple(result.SInt3, a.SInt3, b.UInt3, pow2);
                    Assume.floormultiple(result.SInt4, a.SInt4, b.UInt4, pow2);
                    Assume.floormultiple(result.SInt5, a.SInt5, b.UInt5, pow2);
                    Assume.floormultiple(result.SInt6, a.SInt6, b.UInt6, pow2);
                    Assume.floormultiple(result.SInt7, a.SInt7, b.UInt7, pow2);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    pow2 |= constexpr.ALL_POW2_EPU64(b, elements);

                    v256 result;

                    if (pow2)
                    {
                        result = Avx2.mm256_and_si256(a, mm256_neg_epi64(b));
                    }
                    else
                    {
                        v256 ux = nonNegative ? a : mm256_abs_epi64(a);
                        if (nonNegative)
                        {
                            v256 q = mm256_div_epu64(ux, b, elements: elements);
                            result = mm256_mullo_epi64(q, b, elements: elements);
                        }
                        else
                        {
                            v256 uq = mm256_divrem_epu64(ux, b, out v256 ur, elements: elements);
                            v256 umag = mm256_mullo_epi64(Avx2.mm256_sub_epi64(uq, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(ur, Avx.mm256_setzero_si256()), mm256_srai_epi64(a, 63))), b, elements: elements);
                            result = mm256_srai_epi64(a, 63);
                            result = Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(umag, result), result);
                        }
                    }

                    Assume.floormultiple(result.SLong0, a.SLong0, b.ULong0, pow2);
                    Assume.floormultiple(result.SLong1, a.SLong1, b.ULong1, pow2);
                    Assume.floormultiple(result.SLong2, a.SLong2, b.ULong2, pow2);

                    if (elements > 3)
                    {
                        Assume.floormultiple(result.SLong3, a.SLong3, b.ULong3, pow2);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_ps(b, floor_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_floor_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_pd(b, floor_pd(div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_floor_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(byte result, byte x, byte n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (n - 1)) == 0);
            }

            constexpr.ASSUME(result == x - (byte)(x % n));
            constexpr.ASSUME(result <= x);
            constexpr.ASSUME((byte)(x - result) < n);
            constexpr.ASSUME((x < n) == (result == 0));
            constexpr.ASSUME((byte)(result % n) == 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(ushort result, ushort x, ushort n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (n - 1)) == 0);
            }

            constexpr.ASSUME(result == x - (ushort)(x % n));
            constexpr.ASSUME(result <= x);
            constexpr.ASSUME((ushort)(x - result) < n);
            constexpr.ASSUME((x < n) == (result == 0));
            constexpr.ASSUME((ushort)(result % n) == 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(uint result, uint x, uint n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (n - 1)) == 0);
            }

            constexpr.ASSUME(result == x - (x % n));
            constexpr.ASSUME(result <= x);
            constexpr.ASSUME(x - result < n);
            constexpr.ASSUME((x < n) == (result == 0));
            constexpr.ASSUME(result % n == 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(ulong result, ulong x, ulong n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (n - 1)) == 0);
            }

            constexpr.ASSUME(result == n * (x / n));
            constexpr.ASSUME(result <= x);
            constexpr.ASSUME(x - result < n);
            constexpr.ASSUME((x < n) == (result == 0));
            constexpr.ASSUME(result % n == 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(sbyte result, sbyte x, byte n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (sbyte)(n - 1)) == 0);
            }
        
            bool overflow = (n > (byte)sbyte.MaxValue)
                         || (x < 0 && x < sbyte.MinValue + ((sbyte)n - 1));

            if (constexpr.IS_FALSE(overflow))
            {
                constexpr.ASSUME((result % (sbyte)n) == 0);
                constexpr.ASSUME(result <= x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(short result, short x, ushort n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (short)(n - 1)) == 0);
            }
        
            bool overflow = (n > (ushort)short.MaxValue)
                         || (x < 0 && x < short.MinValue + ((short)n - 1));

            if (constexpr.IS_FALSE(overflow))
            {
                constexpr.ASSUME((result % (short)n) == 0);
                constexpr.ASSUME(result <= x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(int result, int x, uint n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (int)(n - 1)) == 0);
            }

            bool overflow = (n > (uint)int.MaxValue)
                         || (x < 0 && x < int.MinValue + ((int)n - 1));

            if (constexpr.IS_FALSE(overflow))
            {
                constexpr.ASSUME((result % (int)n) == 0);
                constexpr.ASSUME(result <= x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void floormultiple(long result, long x, ulong n, bool promisePow2)
        {
            if (promisePow2 || constexpr.IS_TRUE(math.ispow2(n)))
            {
                constexpr.ASSUME((result & (long)(n - 1)) == 0);
            }
        
            bool overflow = (n > (ulong)long.MaxValue)
                         || (x < 0 && x < long.MinValue + ((long)n - 1));

            if (constexpr.IS_FALSE(overflow))
            {
                constexpr.ASSUME((result % (long)n) == 0);
                constexpr.ASSUME(result <= x);
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floormultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            UInt128 result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                result = x & (0ul - n);

                constexpr.ASSUME((result & (n - 1)) == 0);
            }
            else
            {
                result = x - (x % n);
            }

            //constexpr.ASSUME(result == n * (x / n));
            constexpr.ASSUME(result <= x);
            constexpr.ASSUME(x - result < n);
            constexpr.ASSUME((x < n) == (result == 0));
            constexpr.ASSUME(result % n == 0);

            return result;
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floormultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            Int128 result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                result = x & -((Int128)n);
            }
            else
            {
                bool xNeg = !(promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0)) && x < 0;

                UInt128 ux = (UInt128)(xNeg ? -x : x);

                UInt128 uq = divrem(ux, n, out UInt128 ur);
                UInt128 umag = xNeg
                             ? (ur == 0 ? uq * n : (uq + 1) * n)
                             : uq * n;

                result = xNeg ? -(Int128)umag : (Int128)umag;
            }

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                constexpr.ASSUME((result & (Int128)(n - 1)) == 0);
            }
        
            bool overflow = (n > (UInt128)Int128.MaxValue)
                         || (x < 0 && x < Int128.MinValue + ((Int128)n - 1));

            if (constexpr.IS_FALSE(overflow))
            {
                //constexpr.ASSUME((result % (Int128)n) == 0);
                constexpr.ASSUME(result <= x);
            }

            return result;
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floormultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            ulong result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                result = x & (0ul - n);
            }
            else
            {
                result = x - (x % n);
            }

            Assume.floormultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floormultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu64(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floormultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu64(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong3(floormultiple(x.xy, n.xy, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floormultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu64(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong4(floormultiple(x.xy, n.xy, promises), floormultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floormultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            long result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                result = x & (long)(0 - n);
            }
            else
            {
                bool xNeg = !(promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0)) && x < 0;

                ulong ux = (ulong)(xNeg ? -x : x);

                ulong uq = divrem(ux, n, out ulong ur);
                ulong umag = xNeg
                           ? (ur == 0 ? uq * n : (uq + 1) * n)
                           : uq * n;

                result = xNeg ? -(long)umag : (long)umag;
            }

            Assume.floormultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floormultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floormultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long3(floormultiple(x.xy, n.xy, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floormultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long4(floormultiple(x.xy, n.xy, promises), floormultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint floormultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            uint result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                result = x & (0u - n);
            }
            else
            {
                result = x - (x % n);
            }

            Assume.floormultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 floormultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu32(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new uint2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 floormultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu32(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new uint3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 floormultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu32(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new uint4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floormultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu32(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new uint8(floormultiple(x.v4_0, n.v4_0, promises), floormultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floormultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            int result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                result = x & (int)(0 - n);
            }
            else
            {
                bool xNeg = !(promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0)) && x < 0;

                uint ux = (uint)(xNeg ? -x : x);

                uint uq = divrem(ux, n, out uint ur);
                uint umag = xNeg
                             ? (ur == 0 ? uq * n : (uq + 1) * n)
                             : uq * n;

                result = xNeg ? -(int)umag : (int)umag;
            }

            Assume.floormultiple(result, x, n, promises.Promises(Promise.Unsafe0));

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floormultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi32(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floormultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi32(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floormultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi32(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floormultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int8(floormultiple(x.v4_0, n.v4_0, promises), floormultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floormultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return (ushort)floormultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floormultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floormultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floormultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floormultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort8(floormultiple(x.x0, n.x0, promises),
                                   floormultiple(x.x1, n.x1, promises),
                                   floormultiple(x.x2, n.x2, promises),
                                   floormultiple(x.x3, n.x3, promises),
                                   floormultiple(x.x4, n.x4, promises),
                                   floormultiple(x.x5, n.x5, promises),
                                   floormultiple(x.x6, n.x6, promises),
                                   floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floormultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu16(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort16(floormultiple(x.v8_0, n.v8_0, promises), floormultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floormultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)floormultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floormultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floormultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floormultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floormultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short8(floormultiple(x.x0, n.x0, promises),
                                  floormultiple(x.x1, n.x1, promises),
                                  floormultiple(x.x2, n.x2, promises),
                                  floormultiple(x.x3, n.x3, promises),
                                  floormultiple(x.x4, n.x4, promises),
                                  floormultiple(x.x5, n.x5, promises),
                                  floormultiple(x.x6, n.x6, promises),
                                  floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floormultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short16(floormultiple(x.v8_0, n.v8_0, promises), floormultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floormultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return (byte)floormultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floormultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floormultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floormultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floormultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte8(floormultiple(x.x0, n.x0, promises),
                                 floormultiple(x.x1, n.x1, promises),
                                 floormultiple(x.x2, n.x2, promises),
                                 floormultiple(x.x3, n.x3, promises),
                                 floormultiple(x.x4, n.x4, promises),
                                 floormultiple(x.x5, n.x5, promises),
                                 floormultiple(x.x6, n.x6, promises),
                                 floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floormultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 16, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte16(floormultiple(x.x0,  n.x0,  promises),
                                  floormultiple(x.x1,  n.x1,  promises),
                                  floormultiple(x.x2,  n.x2,  promises),
                                  floormultiple(x.x3,  n.x3,  promises),
                                  floormultiple(x.x4,  n.x4,  promises),
                                  floormultiple(x.x5,  n.x5,  promises),
                                  floormultiple(x.x6,  n.x6,  promises),
                                  floormultiple(x.x7,  n.x7,  promises),
                                  floormultiple(x.x8,  n.x8,  promises),
                                  floormultiple(x.x9,  n.x9,  promises),
                                  floormultiple(x.x10, n.x10, promises),
                                  floormultiple(x.x11, n.x11, promises),
                                  floormultiple(x.x12, n.x12, promises),
                                  floormultiple(x.x13, n.x13, promises),
                                  floormultiple(x.x14, n.x14, promises),
                                  floormultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 floormultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu8(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte32(floormultiple(x.v16_0, n.v16_0, promises), floormultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floormultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)floormultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floormultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floormultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floormultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floormultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte8(floormultiple(x.x0, n.x0, promises),
                                  floormultiple(x.x1, n.x1, promises),
                                  floormultiple(x.x2, n.x2, promises),
                                  floormultiple(x.x3, n.x3, promises),
                                  floormultiple(x.x4, n.x4, promises),
                                  floormultiple(x.x5, n.x5, promises),
                                  floormultiple(x.x6, n.x6, promises),
                                  floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floormultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte16(floormultiple(x.x0,  n.x0,  promises),
                                   floormultiple(x.x1,  n.x1,  promises),
                                   floormultiple(x.x2,  n.x2,  promises),
                                   floormultiple(x.x3,  n.x3,  promises),
                                   floormultiple(x.x4,  n.x4,  promises),
                                   floormultiple(x.x5,  n.x5,  promises),
                                   floormultiple(x.x6,  n.x6,  promises),
                                   floormultiple(x.x7,  n.x7,  promises),
                                   floormultiple(x.x8,  n.x8,  promises),
                                   floormultiple(x.x9,  n.x9,  promises),
                                   floormultiple(x.x10, n.x10, promises),
                                   floormultiple(x.x11, n.x11, promises),
                                   floormultiple(x.x12, n.x12, promises),
                                   floormultiple(x.x13, n.x13, promises),
                                   floormultiple(x.x14, n.x14, promises),
                                   floormultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 floormultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(floormultiple(x.v16_0, n.v16_0, promises), floormultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float floormultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * floor(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 floormultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_ps(x, m, 2);
            }
            else
            {
                return new float2(floormultiple(x.x, m.x), floormultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 floormultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_ps(x, m, 3);
            }
            else
            {
                return new float3(floormultiple(x.x, m.x), floormultiple(x.y, m.y), floormultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 floormultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_ps(x, m, 4);
            }
            else
            {
                return new float4(floormultiple(x.x, m.x), floormultiple(x.y, m.y), floormultiple(x.z, m.z), floormultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 floormultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_floormult_ps(x, m);
            }
            else
            {
                return new float8(floormultiple(x.v4_0, m.v4_0), floormultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double floormultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * floor(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 floormultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floormult_ps(x, m, 2);
            }
            else
            {
                return new double2(floormultiple(x.x, m.x), floormultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 floormultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_floormult_ps(x, m);
            }
            else
            {
                return new double3(floormultiple(x.xy, m.xy), floormultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 floormultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_floormult_ps(x, m);
            }
            else
            {
                return new double4(floormultiple(x.xy, m.xy), floormultiple(x.zw, m.zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple floormultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * floor(x / m);
        }
    }
}