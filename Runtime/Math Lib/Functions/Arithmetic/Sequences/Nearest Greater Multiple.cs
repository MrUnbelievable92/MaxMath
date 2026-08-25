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
            public static v128 ceilmult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi8(b);
                            result = andnot_si128(m, add_epi8(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi8(b);
                            result = inc_epi8(or_si128(dec_epi8(a), mask));
                        }
                    }
                    else
                    {
                        v128 qm1 = div_epu8(dec_epi8(a), b, elements);
                        result = andnot_si128(cmpeq_epi8(a, setzero_si128()), mullo_epi8(inc_epi8(qm1), b));
                    }

                    Assume.ceilmultiple(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.ceilmultiple(result.Byte1,  a.Byte1,  b.Byte1);

                    if (elements > 2)
                    {
                        Assume.ceilmultiple(result.Byte2,  a.Byte2,  b.Byte2);

                        if (elements > 3)
                        {
                            Assume.ceilmultiple(result.Byte3,  a.Byte3,  b.Byte3);

                            if (elements > 4)
                            {
                                Assume.ceilmultiple(result.Byte4,  a.Byte4,  b.Byte4);
                                Assume.ceilmultiple(result.Byte5,  a.Byte5,  b.Byte5);
                                Assume.ceilmultiple(result.Byte6,  a.Byte6,  b.Byte6);
                                Assume.ceilmultiple(result.Byte7,  a.Byte7,  b.Byte7);

                                if (elements > 8)
                                {
                                    Assume.ceilmultiple(result.Byte8,  a.Byte8,  b.Byte8);
                                    Assume.ceilmultiple(result.Byte9,  a.Byte9,  b.Byte9);
                                    Assume.ceilmultiple(result.Byte10, a.Byte10, b.Byte10);
                                    Assume.ceilmultiple(result.Byte11, a.Byte11, b.Byte11);
                                    Assume.ceilmultiple(result.Byte12, a.Byte12, b.Byte12);
                                    Assume.ceilmultiple(result.Byte13, a.Byte13, b.Byte13);
                                    Assume.ceilmultiple(result.Byte14, a.Byte14, b.Byte14);
                                    Assume.ceilmultiple(result.Byte15, a.Byte15, b.Byte15);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi16(b);
                            result = andnot_si128(m, add_epi16(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi16(b);
                            result = inc_epi16(or_si128(dec_epi16(a), mask));
                        }
                    }
                    else
                    {
                        v128 qm1 = div_epu16(dec_epi16(a), b, elements);
                        result = andnot_si128(cmpeq_epi16(a, setzero_si128()), mullo_epi16(inc_epi16(qm1), b));
                    }

                    Assume.ceilmultiple(result.UShort0, a.UShort0, b.UShort0);
                    Assume.ceilmultiple(result.UShort1, a.UShort1, b.UShort1);

                    if (elements > 2)
                    {
                        Assume.ceilmultiple(result.UShort2, a.UShort2, b.UShort2);

                        if (elements > 3)
                        {
                            Assume.ceilmultiple(result.UShort3, a.UShort3, b.UShort3);

                            if (elements > 4)
                            {
                                Assume.ceilmultiple(result.UShort4, a.UShort4, b.UShort4);
                                Assume.ceilmultiple(result.UShort5, a.UShort5, b.UShort5);
                                Assume.ceilmultiple(result.UShort6, a.UShort6, b.UShort6);
                                Assume.ceilmultiple(result.UShort7, a.UShort7, b.UShort7);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi32(b);
                            result = andnot_si128(m, add_epi32(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi32(b);
                            result = inc_epi32(or_si128(dec_epi32(a), mask));
                        }
                    }
                    else
                    {
                        v128 qm1 = div_epu32(dec_epi32(a), b, elements);
                        result = andnot_si128(cmpeq_epi32(a, setzero_si128()), mullo_epi32(inc_epi32(qm1), b));
                    }

                    Assume.ceilmultiple(result.UInt0, a.UInt0, b.UInt0);
                    Assume.ceilmultiple(result.UInt1, a.UInt1, b.UInt1);

                    if (elements > 2)
                    {
                        Assume.ceilmultiple(result.UInt2, a.UInt2, b.UInt2);

                        if (elements > 3)
                        {
                            Assume.ceilmultiple(result.UInt3, a.UInt3, b.UInt3);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epu64(v128 a, v128 b, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi64(b);
                            result = andnot_si128(m, add_epi64(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi64(b);
                            result = inc_epi64(or_si128(dec_epi64(a), mask));
                        }
                    }
                    else
                    {
                        result = rem_epu64(a, b);
                        result = add_epi64(a, andnot_si128(cmpeq_epi64(result, setzero_si128()), sub_epi64(b, result)));
                    }

                    Assume.ceilmultiple(result.ULong0, a.ULong0, b.ULong0);
                    Assume.ceilmultiple(result.ULong1, a.ULong1, b.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi8(b);
                            result = andnot_si128(m, add_epi8(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi8(b);
                            result = inc_epi8(or_si128(dec_epi8(a), mask));
                        }
                    }
                    else
                    {
                        v128 truncResult = divmullo_epi8(a, b, b, out _, noOverflow: true, saturated: false, elements);
                        v128 rem = sub_epi8(a, truncResult);
                        v128 upMask = cmpgt_epi8(rem, setzero_si128());
                        result = add_epi8(truncResult, and_si128(upMask, b));
                    }

                    Assume.ceilmultiple(result.SByte0,  a.SByte0,  b.Byte0);
                    Assume.ceilmultiple(result.SByte1,  a.SByte1,  b.Byte1);

                    if (elements > 2)
                    {
                        Assume.ceilmultiple(result.SByte2,  a.SByte2,  b.Byte2);

                        if (elements > 3)
                        {
                            Assume.ceilmultiple(result.SByte3,  a.SByte3,  b.Byte3);

                            if (elements > 4)
                            {
                                Assume.ceilmultiple(result.SByte4,  a.SByte4,  b.Byte4);
                                Assume.ceilmultiple(result.SByte5,  a.SByte5,  b.Byte5);
                                Assume.ceilmultiple(result.SByte6,  a.SByte6,  b.Byte6);
                                Assume.ceilmultiple(result.SByte7,  a.SByte7,  b.Byte7);

                                if (elements > 8)
                                {
                                    Assume.ceilmultiple(result.SByte8,  a.SByte8,  b.Byte8);
                                    Assume.ceilmultiple(result.SByte9,  a.SByte9,  b.Byte9);
                                    Assume.ceilmultiple(result.SByte10, a.SByte10, b.Byte10);
                                    Assume.ceilmultiple(result.SByte11, a.SByte11, b.Byte11);
                                    Assume.ceilmultiple(result.SByte12, a.SByte12, b.Byte12);
                                    Assume.ceilmultiple(result.SByte13, a.SByte13, b.Byte13);
                                    Assume.ceilmultiple(result.SByte14, a.SByte14, b.Byte14);
                                    Assume.ceilmultiple(result.SByte15, a.SByte15, b.Byte15);
                                }
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi16(b);
                            result = andnot_si128(m, add_epi16(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi16(b);
                            result = inc_epi16(or_si128(dec_epi16(a), mask));
                        }
                    }
                    else
                    {
                        v128 q = div_epi16(a, b, elements: elements);
                        v128 truncResult = mullo_epi16(b, q);
                        v128 rem = sub_epi16(a, truncResult);
                        v128 upMask = cmpgt_epi16(rem, setzero_si128());
                        result = add_epi16(truncResult, and_si128(upMask, b));
                    }

                    Assume.ceilmultiple(result.SShort0, a.SShort0, b.UShort0);
                    Assume.ceilmultiple(result.SShort1, a.SShort1, b.UShort1);

                    if (elements > 2)
                    {
                        Assume.ceilmultiple(result.SShort2, a.SShort2, b.UShort2);

                        if (elements > 3)
                        {
                            Assume.ceilmultiple(result.SShort3, a.SShort3, b.UShort3);

                            if (elements > 4)
                            {
                                Assume.ceilmultiple(result.SShort4, a.SShort4, b.UShort4);
                                Assume.ceilmultiple(result.SShort5, a.SShort5, b.UShort5);
                                Assume.ceilmultiple(result.SShort6, a.SShort6, b.UShort6);
                                Assume.ceilmultiple(result.SShort7, a.SShort7, b.UShort7);
                            }
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi32(b);
                            result = andnot_si128(m, add_epi32(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi32(b);
                            result = inc_epi32(or_si128(dec_epi32(a), mask));
                        }
                    }
                    else
                    {
                        v128 q = div_epi32(a, b, elements);
                        v128 truncResult = mullo_epi32(b, q, elements);
                        v128 rem = sub_epi32(a, truncResult);
                        v128 upMask = cmpgt_epi32(rem, setzero_si128());
                        result = add_epi32(truncResult, and_si128(upMask, b));
                    }

                    Assume.ceilmultiple(result.SInt0, a.SInt0, b.UInt0);
                    Assume.ceilmultiple(result.SInt1, a.SInt1, b.UInt1);

                    if (elements > 2)
                    {
                        Assume.ceilmultiple(result.SInt2, a.SInt2, b.UInt2);

                        if (elements > 3)
                        {
                            Assume.ceilmultiple(result.SInt3, a.SInt3, b.UInt3);
                        }
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_epi64(v128 a, v128 b, bool pow2 = false, bool noOverflow = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        if (noOverflow)
                        {
                            v128 m = dec_epi64(b);
                            result = andnot_si128(m, add_epi64(a, m));
                        }
                        else
                        {
                            v128 mask = dec_epi64(b);
                            result = inc_epi64(or_si128(dec_epi64(a), mask));
                        }
                    }
                    else
                    {
                        v128 rem = rem_epi64(a, b);
                        v128 truncResult = sub_epi64(a, rem);
                        v128 upMask = cmpgt_epi64(rem, setzero_si128());
                        result = add_epi64(truncResult, and_si128(upMask, b));
                    }

                    Assume.ceilmultiple(result.SLong0, a.SLong0, b.ULong0);
                    Assume.ceilmultiple(result.SLong1, a.SLong1, b.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu8(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi8(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi8(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi8(b);
                            result = mm256_inc_epi8(Avx2.mm256_or_si256(mm256_dec_epi8(a), mask));
                        }
                    }
                    else
                    {
                        v256 qm1 = mm256_div_epu8(mm256_dec_epi8(a), b);
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256()), mm256_mullo_epi8(mm256_inc_epi8(qm1), b));
                    }

                    Assume.ceilmultiple(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.ceilmultiple(result.Byte1,  a.Byte1,  b.Byte1);
                    Assume.ceilmultiple(result.Byte2,  a.Byte2,  b.Byte2);
                    Assume.ceilmultiple(result.Byte3,  a.Byte3,  b.Byte3);
                    Assume.ceilmultiple(result.Byte4,  a.Byte4,  b.Byte4);
                    Assume.ceilmultiple(result.Byte5,  a.Byte5,  b.Byte5);
                    Assume.ceilmultiple(result.Byte6,  a.Byte6,  b.Byte6);
                    Assume.ceilmultiple(result.Byte7,  a.Byte7,  b.Byte7);
                    Assume.ceilmultiple(result.Byte8,  a.Byte8,  b.Byte8);
                    Assume.ceilmultiple(result.Byte9,  a.Byte9,  b.Byte9);
                    Assume.ceilmultiple(result.Byte10, a.Byte10, b.Byte10);
                    Assume.ceilmultiple(result.Byte11, a.Byte11, b.Byte11);
                    Assume.ceilmultiple(result.Byte12, a.Byte12, b.Byte12);
                    Assume.ceilmultiple(result.Byte13, a.Byte13, b.Byte13);
                    Assume.ceilmultiple(result.Byte14, a.Byte14, b.Byte14);
                    Assume.ceilmultiple(result.Byte15, a.Byte15, b.Byte15);
                    Assume.ceilmultiple(result.Byte16, a.Byte16, b.Byte16);
                    Assume.ceilmultiple(result.Byte17, a.Byte17, b.Byte17);
                    Assume.ceilmultiple(result.Byte18, a.Byte18, b.Byte18);
                    Assume.ceilmultiple(result.Byte19, a.Byte19, b.Byte19);
                    Assume.ceilmultiple(result.Byte20, a.Byte20, b.Byte20);
                    Assume.ceilmultiple(result.Byte21, a.Byte21, b.Byte21);
                    Assume.ceilmultiple(result.Byte22, a.Byte22, b.Byte22);
                    Assume.ceilmultiple(result.Byte23, a.Byte23, b.Byte23);
                    Assume.ceilmultiple(result.Byte24, a.Byte24, b.Byte24);
                    Assume.ceilmultiple(result.Byte25, a.Byte25, b.Byte25);
                    Assume.ceilmultiple(result.Byte26, a.Byte26, b.Byte26);
                    Assume.ceilmultiple(result.Byte27, a.Byte27, b.Byte27);
                    Assume.ceilmultiple(result.Byte28, a.Byte28, b.Byte28);
                    Assume.ceilmultiple(result.Byte29, a.Byte29, b.Byte29);
                    Assume.ceilmultiple(result.Byte30, a.Byte30, b.Byte30);
                    Assume.ceilmultiple(result.Byte31, a.Byte31, b.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu16(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi16(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi16(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi16(b);
                            result = mm256_inc_epi16(Avx2.mm256_or_si256(mm256_dec_epi16(a), mask));
                        }
                    }
                    else
                    {
                        v256 qm1 = mm256_div_epu16(mm256_dec_epi16(a), b);
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256()), Avx2.mm256_mullo_epi16(mm256_inc_epi16(qm1), b));
                    }

                    Assume.ceilmultiple(result.UShort0,  a.UShort0,  b.UShort0);
                    Assume.ceilmultiple(result.UShort1,  a.UShort1,  b.UShort1);
                    Assume.ceilmultiple(result.UShort2,  a.UShort2,  b.UShort2);
                    Assume.ceilmultiple(result.UShort3,  a.UShort3,  b.UShort3);
                    Assume.ceilmultiple(result.UShort4,  a.UShort4,  b.UShort4);
                    Assume.ceilmultiple(result.UShort5,  a.UShort5,  b.UShort5);
                    Assume.ceilmultiple(result.UShort6,  a.UShort6,  b.UShort6);
                    Assume.ceilmultiple(result.UShort7,  a.UShort7,  b.UShort7);
                    Assume.ceilmultiple(result.UShort8,  a.UShort8,  b.UShort8);
                    Assume.ceilmultiple(result.UShort9,  a.UShort9,  b.UShort9);
                    Assume.ceilmultiple(result.UShort10, a.UShort10, b.UShort10);
                    Assume.ceilmultiple(result.UShort11, a.UShort11, b.UShort11);
                    Assume.ceilmultiple(result.UShort12, a.UShort12, b.UShort12);
                    Assume.ceilmultiple(result.UShort13, a.UShort13, b.UShort13);
                    Assume.ceilmultiple(result.UShort14, a.UShort14, b.UShort14);
                    Assume.ceilmultiple(result.UShort15, a.UShort15, b.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu32(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi32(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi32(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi32(b);
                            result = mm256_inc_epi32(Avx2.mm256_or_si256(mm256_dec_epi32(a), mask));
                        }
                    }
                    else
                    {
                        v256 qm1 = mm256_div_epu32(mm256_dec_epi32(a), b);
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256()), Avx2.mm256_mullo_epi32(mm256_inc_epi32(qm1), b));
                    }

                    Assume.ceilmultiple(result.UInt0, a.UInt0, b.UInt0);
                    Assume.ceilmultiple(result.UInt1, a.UInt1, b.UInt1);
                    Assume.ceilmultiple(result.UInt2, a.UInt2, b.UInt2);
                    Assume.ceilmultiple(result.UInt3, a.UInt3, b.UInt3);
                    Assume.ceilmultiple(result.UInt4, a.UInt4, b.UInt4);
                    Assume.ceilmultiple(result.UInt5, a.UInt5, b.UInt5);
                    Assume.ceilmultiple(result.UInt6, a.UInt6, b.UInt6);
                    Assume.ceilmultiple(result.UInt7, a.UInt7, b.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi64(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi64(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi64(b);
                            result = mm256_inc_epi64(Avx2.mm256_or_si256(mm256_dec_epi64(a), mask));
                        }
                    }
                    else
                    {
                        result = mm256_rem_epu64(a, b, elements: elements);
                        result = Avx2.mm256_add_epi64(a, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(result, Avx.mm256_setzero_si256()), Avx2.mm256_sub_epi64(b, result)));
                    }

                    Assume.ceilmultiple(result.ULong0, a.ULong0, b.ULong0);
                    Assume.ceilmultiple(result.ULong1, a.ULong1, b.ULong1);
                    Assume.ceilmultiple(result.ULong2, a.ULong2, b.ULong2);

                    if (elements > 3)
                    {
                        Assume.ceilmultiple(result.ULong3, a.ULong3, b.ULong3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi8(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi8(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi8(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi8(b);
                            result = mm256_inc_epi8(Avx2.mm256_or_si256(mm256_dec_epi8(a), mask));
                        }
                    }
                    else
                    {
                        v256 truncResult = mm256_divmullo_epi8(a, b, b, out _, noOverflow: true);
                        v256 rem = Avx2.mm256_sub_epi8(a, truncResult);
                        v256 upMask = Avx2.mm256_cmpgt_epi8(rem, Avx.mm256_setzero_si256());
                        result = Avx2.mm256_add_epi8(truncResult, Avx2.mm256_and_si256(upMask, b));
                    }

                    Assume.ceilmultiple(result.SByte0,  a.SByte0,  b.Byte0);
                    Assume.ceilmultiple(result.SByte1,  a.SByte1,  b.Byte1);
                    Assume.ceilmultiple(result.SByte2,  a.SByte2,  b.Byte2);
                    Assume.ceilmultiple(result.SByte3,  a.SByte3,  b.Byte3);
                    Assume.ceilmultiple(result.SByte4,  a.SByte4,  b.Byte4);
                    Assume.ceilmultiple(result.SByte5,  a.SByte5,  b.Byte5);
                    Assume.ceilmultiple(result.SByte6,  a.SByte6,  b.Byte6);
                    Assume.ceilmultiple(result.SByte7,  a.SByte7,  b.Byte7);
                    Assume.ceilmultiple(result.SByte8,  a.SByte8,  b.Byte8);
                    Assume.ceilmultiple(result.SByte9,  a.SByte9,  b.Byte9);
                    Assume.ceilmultiple(result.SByte10, a.SByte10, b.Byte10);
                    Assume.ceilmultiple(result.SByte11, a.SByte11, b.Byte11);
                    Assume.ceilmultiple(result.SByte12, a.SByte12, b.Byte12);
                    Assume.ceilmultiple(result.SByte13, a.SByte13, b.Byte13);
                    Assume.ceilmultiple(result.SByte14, a.SByte14, b.Byte14);
                    Assume.ceilmultiple(result.SByte15, a.SByte15, b.Byte15);
                    Assume.ceilmultiple(result.SByte16, a.SByte16, b.Byte16);
                    Assume.ceilmultiple(result.SByte17, a.SByte17, b.Byte17);
                    Assume.ceilmultiple(result.SByte18, a.SByte18, b.Byte18);
                    Assume.ceilmultiple(result.SByte19, a.SByte19, b.Byte19);
                    Assume.ceilmultiple(result.SByte20, a.SByte20, b.Byte20);
                    Assume.ceilmultiple(result.SByte21, a.SByte21, b.Byte21);
                    Assume.ceilmultiple(result.SByte22, a.SByte22, b.Byte22);
                    Assume.ceilmultiple(result.SByte23, a.SByte23, b.Byte23);
                    Assume.ceilmultiple(result.SByte24, a.SByte24, b.Byte24);
                    Assume.ceilmultiple(result.SByte25, a.SByte25, b.Byte25);
                    Assume.ceilmultiple(result.SByte26, a.SByte26, b.Byte26);
                    Assume.ceilmultiple(result.SByte27, a.SByte27, b.Byte27);
                    Assume.ceilmultiple(result.SByte28, a.SByte28, b.Byte28);
                    Assume.ceilmultiple(result.SByte29, a.SByte29, b.Byte29);
                    Assume.ceilmultiple(result.SByte30, a.SByte30, b.Byte30);
                    Assume.ceilmultiple(result.SByte31, a.SByte31, b.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi16(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi16(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi16(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi16(b);
                            result = mm256_inc_epi16(Avx2.mm256_or_si256(mm256_dec_epi16(a), mask));
                        }
                    }
                    else
                    {
                        v256 q = mm256_div_epi16(a, b);
                        v256 truncResult = Avx2.mm256_mullo_epi16(b, q);
                        v256 rem = Avx2.mm256_sub_epi16(a, truncResult);
                        v256 upMask = Avx2.mm256_cmpgt_epi16(rem, Avx.mm256_setzero_si256());
                        result = Avx2.mm256_add_epi16(truncResult, Avx2.mm256_and_si256(upMask, b));
                    }

                    Assume.ceilmultiple(result.SShort0,  a.SShort0,  b.UShort0);
                    Assume.ceilmultiple(result.SShort1,  a.SShort1,  b.UShort1);
                    Assume.ceilmultiple(result.SShort2,  a.SShort2,  b.UShort2);
                    Assume.ceilmultiple(result.SShort3,  a.SShort3,  b.UShort3);
                    Assume.ceilmultiple(result.SShort4,  a.SShort4,  b.UShort4);
                    Assume.ceilmultiple(result.SShort5,  a.SShort5,  b.UShort5);
                    Assume.ceilmultiple(result.SShort6,  a.SShort6,  b.UShort6);
                    Assume.ceilmultiple(result.SShort7,  a.SShort7,  b.UShort7);
                    Assume.ceilmultiple(result.SShort8,  a.SShort8,  b.UShort8);
                    Assume.ceilmultiple(result.SShort9,  a.SShort9,  b.UShort9);
                    Assume.ceilmultiple(result.SShort10, a.SShort10, b.UShort10);
                    Assume.ceilmultiple(result.SShort11, a.SShort11, b.UShort11);
                    Assume.ceilmultiple(result.SShort12, a.SShort12, b.UShort12);
                    Assume.ceilmultiple(result.SShort13, a.SShort13, b.UShort13);
                    Assume.ceilmultiple(result.SShort14, a.SShort14, b.UShort14);
                    Assume.ceilmultiple(result.SShort15, a.SShort15, b.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi32(v256 a, v256 b, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi32(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi32(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi32(b);
                            result = mm256_inc_epi32(Avx2.mm256_or_si256(mm256_dec_epi32(a), mask));
                        }
                    }
                    else
                    {
                        v256 q = mm256_div_epi32(a, b);
                        v256 truncResult = Avx2.mm256_mullo_epi32(b, q);
                        v256 rem = Avx2.mm256_sub_epi32(a, truncResult);
                        v256 upMask = Avx2.mm256_cmpgt_epi32(rem, Avx.mm256_setzero_si256());
                        result = Avx2.mm256_add_epi32(truncResult, Avx2.mm256_and_si256(upMask, b));
                    }

                    Assume.ceilmultiple(result.SInt0, a.SInt0, b.UInt0);
                    Assume.ceilmultiple(result.SInt1, a.SInt1, b.UInt1);
                    Assume.ceilmultiple(result.SInt2, a.SInt2, b.UInt2);
                    Assume.ceilmultiple(result.SInt3, a.SInt3, b.UInt3);
                    Assume.ceilmultiple(result.SInt4, a.SInt4, b.UInt4);
                    Assume.ceilmultiple(result.SInt5, a.SInt5, b.UInt5);
                    Assume.ceilmultiple(result.SInt6, a.SInt6, b.UInt6);
                    Assume.ceilmultiple(result.SInt7, a.SInt7, b.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool noOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        if (noOverflow)
                        {
                            v256 m = mm256_dec_epi64(b);
                            result = Avx2.mm256_andnot_si256(m, Avx2.mm256_add_epi64(a, m));
                        }
                        else
                        {
                            v256 mask = mm256_dec_epi64(b);
                            result = mm256_inc_epi64(Avx2.mm256_or_si256(mm256_dec_epi64(a), mask));
                        }
                    }
                    else
                    {
                        v256 rem = mm256_rem_epi64(a, b, elements: elements);
                        v256 truncResult = Avx2.mm256_sub_epi64(a, rem);
                        v256 upMask = Avx2.mm256_cmpgt_epi64(rem, Avx.mm256_setzero_si256());
                        result = Avx2.mm256_add_epi64(truncResult, Avx2.mm256_and_si256(upMask, b));
                    }

                    Assume.ceilmultiple(result.SLong0, a.SLong0, b.ULong0);
                    Assume.ceilmultiple(result.SLong1, a.SLong1, b.ULong1);
                    Assume.ceilmultiple(result.SLong2, a.SLong2, b.ULong2);

                    if (elements > 3)
                    {
                        Assume.ceilmultiple(result.SLong3, a.SLong3, b.ULong3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_ps(b, ceil_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_ceil_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceilmult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return mul_pd(b, ceil_pd(div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceilmult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_ceil_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    
    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(byte result, byte x, byte n)
        {
            if (constexpr.IS_TRUE(x <= (byte)(byte.MaxValue - (byte)(n - 1))))
            {
                constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(result >= x);
                constexpr.ASSUME(result < (byte)(x + n) || (byte)(x + n) < x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(ushort result, ushort x, ushort n)
        {
            if (constexpr.IS_TRUE(x <= (ushort)(ushort.MaxValue - (ushort)(n - 1))))
            {
                constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(result >= x);
                constexpr.ASSUME(result < (ushort)(x + n) || (ushort)(x + n) < x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(uint result, uint x, uint n)
        {
            if (constexpr.IS_TRUE(x <= uint.MaxValue - (n - 1)))
            {
                constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(result >= x);
                constexpr.ASSUME(result < x + n || x + n < x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(ulong result, ulong x, ulong n)
        {
            if (constexpr.IS_TRUE(x <= ulong.MaxValue - (n - 1)))
            {
                constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(result >= x);
                constexpr.ASSUME(result < x + n || x + n < x);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(sbyte result, sbyte x, byte n)
        {
            if (constexpr.IS_TRUE(x <= (sbyte)(sbyte.MaxValue - (sbyte)(n - 1))))
            {
                constexpr.ASSUME((result % (sbyte)n) == 0);
                constexpr.ASSUME(result >= x);
                if (n <= sbyte.MaxValue)
                {
                    constexpr.ASSUME(result < (sbyte)(x + (sbyte)n) || (sbyte)((sbyte)(x ^ (sbyte)(x + (sbyte)n)) & (sbyte)(n ^ (sbyte)(x + (sbyte)n))) < 0);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(short result, short x, ushort n)
        {
            if (constexpr.IS_TRUE(x <= (short)(short.MaxValue - (short)(n - 1))))
            {
                constexpr.ASSUME((result % (short)n) == 0);
                constexpr.ASSUME(result >= x);
                if (n <= short.MaxValue)
                {
                    constexpr.ASSUME(result < (short)(x + (short)n) || (short)((short)(x ^ (short)(x + (short)n)) & (short)(n ^ (short)(x + (short)n))) < 0);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(int result, int x, uint n)
        {
            if (constexpr.IS_TRUE(n <= int.MaxValue && x <= int.MaxValue - (int)(n - 1)))
            {
                constexpr.ASSUME((result % (int)n) == 0);
                constexpr.ASSUME(result >= x);
                if (n <= int.MaxValue)
                {
                    constexpr.ASSUME(result < x + (int)n || ((x ^ (x + (int)n)) & ((int)n ^ (x + (int)n))) < 0);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ceilmultiple(long result, long x, ulong n)
        {
            if (constexpr.IS_TRUE(x <= long.MaxValue - (long)(n - 1)))
            {
                constexpr.ASSUME((result % (long)n) == 0);
                constexpr.ASSUME(result >= x);
                if (n <= long.MaxValue)
                {
                    constexpr.ASSUME(result < x + (long)n || ((x ^ (x + (long)n)) & ((long)n ^ (x + (long)n))) < 0);
                }
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 ceilmultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            UInt128 result;
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= UInt128.MaxValue - (n - 1)))
                {
                    UInt128 m = n - 1;
                    result = andnot(x + m, m);
                }
                else
                {
                    UInt128 mask = n - 1;
                    result = ((x - 1) | mask) + 1;
                }
            }
            else
            {
                result = x % n;
                result = isdivisible(x, n) ? x : x + (n - result);
            }

            if (constexpr.IS_TRUE(x <= UInt128.MaxValue - (n - 1)))
            {
                //constexpr.ASSUME(result % n == 0);
                constexpr.ASSUME(result >= x);
                constexpr.ASSUME(result < x + n || x + n < x);
            }

            return result;
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 ceilmultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            Int128 result;

            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= Int128.MaxValue - (Int128)(n - 1)))
                {
                    Int128 m = (Int128)n - 1;
                    result = andnot(x + m, m);
                }
                else
                {
                    Int128 mask = (Int128)n - 1;
                    result = ((x - 1) | mask) + 1;
                }
            }
            else
            {
                Int128 r = x % (Int128)n;
                result = r > 0 ? x + ((Int128)n - r) : x - r;
            }
            
            if (constexpr.IS_TRUE(x <= Int128.MaxValue - (Int128)(n - 1)))
            {
                //constexpr.ASSUME((result % (Int128)n) == 0);
                constexpr.ASSUME(result >= x);
                if (n <= (UInt128)Int128.MaxValue)
                {
                    constexpr.ASSUME(result < x + (Int128)n || ((x ^ (x + (Int128)n)) & ((Int128)n ^ (x + (Int128)n))) < 0);
                }
            }

            return result;
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong ceilmultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            ulong result;
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= ulong.MaxValue - (n - 1)))
                {
                    ulong m = n - 1;
                    result = andnot(x + m, m);
                }
                else
                {
                    ulong mask = n - 1;
                    result = ((x - 1) | mask) + 1;
                }
            }
            else
            {
                result = x % n;
                result = isdivisible(x, n) ? x : x + (n - result);
            }

            Assume.ceilmultiple(result, x, n);

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceilmultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceilmultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong3(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceilmultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ulong4(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ceilmultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            long result;
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= long.MaxValue - (long)(n - 1)))
                {
                    long m = (long)n - 1;
                    result = andnot(x + m, m);
                }
                else
                {
                    long mask = (long)n - 1;
                    result = ((x - 1) | mask) + 1;
                }
            }
            else
            {
                long r = x % (long)n;
                result = r > 0 ? x + ((long)n - r) : x - r;
            }

            Assume.ceilmultiple(result, x, n);

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceilmultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceilmultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long3(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceilmultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long4(ceilmultiple(x.xy, n.xy, promises), ceilmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint ceilmultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            uint result;
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= uint.MaxValue - (n - 1)))
                {
                    uint m = n - 1;
                    result = andnot(x + m, m);
                }
                else
                {
                    uint mask = n - 1;
                    result = ((x - 1) | mask) + 1;
                }
            }
            else
            {
                result = x % n;
                result = isdivisible(x, n) ? x : x + (n - result);
            }

            Assume.ceilmultiple(result, x, n);

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ceilmultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu32(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ceilmultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu32(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ceilmultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu32(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceilmultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new uint8(ceilmultiple(x.v4_0, n.v4_0, promises), ceilmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceilmultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            int result;
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.NoOverflow) || constexpr.IS_TRUE(x <= int.MaxValue - (int)(n - 1)))
                {
                    int m = (int)n - 1;
                    result = andnot(x + m, m);
                }
                else
                {
                    int mask = (int)n - 1;
                    result = ((x - 1) | mask) + 1;
                }
            }
            else
            {
                int r = x % (int)n;
                result = r > 0 ? x + ((int)n - r) : x - r;
            }

            Assume.ceilmultiple(result, x, n);

            return result;
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceilmultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi32(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceilmultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi32(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceilmultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi32(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceilmultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(ceilmultiple(x.v4_0, n.v4_0, promises), ceilmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort ceilmultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return (ushort)ceilmultiple((uint)x, n, promises | Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceilmultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceilmultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceilmultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceilmultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort8(ceilmultiple(x.x0, n.x0, promises),
                                   ceilmultiple(x.x1, n.x1, promises),
                                   ceilmultiple(x.x2, n.x2, promises),
                                   ceilmultiple(x.x3, n.x3, promises),
                                   ceilmultiple(x.x4, n.x4, promises),
                                   ceilmultiple(x.x5, n.x5, promises),
                                   ceilmultiple(x.x6, n.x6, promises),
                                   ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceilmultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new ushort16(ceilmultiple(x.v8_0, n.v8_0, promises), ceilmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short ceilmultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)ceilmultiple((int)x, n, promises | Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceilmultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceilmultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceilmultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceilmultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short8(ceilmultiple(x.x0, n.x0, promises),
                                  ceilmultiple(x.x1, n.x1, promises),
                                  ceilmultiple(x.x2, n.x2, promises),
                                  ceilmultiple(x.x3, n.x3, promises),
                                  ceilmultiple(x.x4, n.x4, promises),
                                  ceilmultiple(x.x5, n.x5, promises),
                                  ceilmultiple(x.x6, n.x6, promises),
                                  ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceilmultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short16(ceilmultiple(x.v8_0, n.v8_0, promises), ceilmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ceilmultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return (byte)ceilmultiple((uint)x, n, promises | Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceilmultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceilmultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceilmultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceilmultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte8(ceilmultiple(x.x0, n.x0, promises),
                                 ceilmultiple(x.x1, n.x1, promises),
                                 ceilmultiple(x.x2, n.x2, promises),
                                 ceilmultiple(x.x3, n.x3, promises),
                                 ceilmultiple(x.x4, n.x4, promises),
                                 ceilmultiple(x.x5, n.x5, promises),
                                 ceilmultiple(x.x6, n.x6, promises),
                                 ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceilmultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epu8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte16(ceilmultiple(x.x0,  n.x0,  promises),
                                  ceilmultiple(x.x1,  n.x1,  promises),
                                  ceilmultiple(x.x2,  n.x2,  promises),
                                  ceilmultiple(x.x3,  n.x3,  promises),
                                  ceilmultiple(x.x4,  n.x4,  promises),
                                  ceilmultiple(x.x5,  n.x5,  promises),
                                  ceilmultiple(x.x6,  n.x6,  promises),
                                  ceilmultiple(x.x7,  n.x7,  promises),
                                  ceilmultiple(x.x8,  n.x8,  promises),
                                  ceilmultiple(x.x9,  n.x9,  promises),
                                  ceilmultiple(x.x10, n.x10, promises),
                                  ceilmultiple(x.x11, n.x11, promises),
                                  ceilmultiple(x.x12, n.x12, promises),
                                  ceilmultiple(x.x13, n.x13, promises),
                                  ceilmultiple(x.x14, n.x14, promises),
                                  ceilmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceilmultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epu8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new byte32(ceilmultiple(x.v16_0, n.v16_0, promises), ceilmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ceilmultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)ceilmultiple((int)x, n, promises | Promise.NoOverflow);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceilmultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte2(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceilmultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte3(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceilmultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte4(ceilmultiple(x.x, n.x, promises), ceilmultiple(x.y, n.y, promises), ceilmultiple(x.z, n.z, promises), ceilmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceilmultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte8(ceilmultiple(x.x0, n.x0, promises),
                                  ceilmultiple(x.x1, n.x1, promises),
                                  ceilmultiple(x.x2, n.x2, promises),
                                  ceilmultiple(x.x3, n.x3, promises),
                                  ceilmultiple(x.x4, n.x4, promises),
                                  ceilmultiple(x.x5, n.x5, promises),
                                  ceilmultiple(x.x6, n.x6, promises),
                                  ceilmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceilmultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte16(ceilmultiple(x.x0,  n.x0,  promises),
                                   ceilmultiple(x.x1,  n.x1,  promises),
                                   ceilmultiple(x.x2,  n.x2,  promises),
                                   ceilmultiple(x.x3,  n.x3,  promises),
                                   ceilmultiple(x.x4,  n.x4,  promises),
                                   ceilmultiple(x.x5,  n.x5,  promises),
                                   ceilmultiple(x.x6,  n.x6,  promises),
                                   ceilmultiple(x.x7,  n.x7,  promises),
                                   ceilmultiple(x.x8,  n.x8,  promises),
                                   ceilmultiple(x.x9,  n.x9,  promises),
                                   ceilmultiple(x.x10, n.x10, promises),
                                   ceilmultiple(x.x11, n.x11, promises),
                                   ceilmultiple(x.x12, n.x12, promises),
                                   ceilmultiple(x.x13, n.x13, promises),
                                   ceilmultiple(x.x14, n.x14, promises),
                                   ceilmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><paramref name="n"/> <see langword="-"/> 1<see langword=")"/> that overflows.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceilmultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceilmult_epi8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte32(ceilmultiple(x.v16_0, n.v16_0, promises), ceilmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ceilmultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * ceil(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ceilmultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_ps(x, m, 2);
            }
            else
            {
                return new float2(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ceilmultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_ps(x, m, 3);
            }
            else
            {
                return new float3(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y), ceilmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ceilmultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_ps(x, m, 4);
            }
            else
            {
                return new float4(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y), ceilmultiple(x.z, m.z), ceilmultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 ceilmultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ceilmult_ps(x, m);
            }
            else
            {
                return new float8(ceilmultiple(x.v4_0, m.v4_0), ceilmultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ceilmultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * ceil(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 ceilmultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceilmult_ps(x, m, 2);
            }
            else
            {
                return new double2(ceilmultiple(x.x, m.x), ceilmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ceilmultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ceilmult_ps(x, m);
            }
            else
            {
                return new double3(ceilmultiple(x.xy, m.xy), ceilmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ceilmultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ceilmult_ps(x, m);
            }
            else
            {
                return new double4(ceilmultiple(x.xy, m.xy), ceilmultiple(x.zw, m.zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest greater or equal multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple ceilmultiple(quadruple x, quadruple m)
        {
Assert.IsGreater(m, 0);

            return m * ceil(x / m);
        }
    }
}