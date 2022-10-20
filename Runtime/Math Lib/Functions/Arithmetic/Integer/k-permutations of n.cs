using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FACTORIAL;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naiveperm_epu8(v128 n, v128 k, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 nom = gamma_epu8(n, true, elements);
                    v128 denom = gamma_epu8(Sse2.sub_epi8(n, k), true, elements);
                    
                    return div_epu8(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naiveperm_epu8(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu8(n, true);
                    v256 denom = mm256_gamma_epu8(Avx2.mm256_sub_epi8(n, k), true);
                    
                    return mm256_div_epu8(nom, denom);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naiveperm_epu16(v128 n, v128 k, bool epu8range = false, byte elements = 8)
            {
                v128 nom;
                v128 denom;
                if (Sse2.IsSse2Supported)
                {
                    if (epu8range || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8, elements))
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            nom = gamma_epu16_epu8range(n);
                            denom = gamma_epu16_epu8range(Sse2.sub_epi16(n, k));

                            return div_epu16(nom, denom, elements);
                        }
                    }

                    nom = gamma_epu16(n, true, elements);
                    denom = gamma_epu16(Sse2.sub_epi16(n, k), true, elements);
                    
                    return div_epu16(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naiveperm_epu16(v256 n, v256 k, bool epu8range = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (epu8range || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8))
                    {
                        v256 nom = mm256_gamma_epu16_epu8range(n);
                        v256 denom = mm256_gamma_epu16_epu8range(Avx2.mm256_sub_epi16(n, k));
                        
                        return mm256_div_epu16(nom, denom);
                    }
                    else
                    {
                        v256 nom = mm256_gamma_epu16(n, true);
                        v256 denom = mm256_gamma_epu16(Avx2.mm256_sub_epi16(n, k), true);
                        
                        return mm256_div_epu16(nom, denom);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naiveperm_epu32(v128 n, v128 k, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 nom = gamma_epu32(n, true, elements);
                    v128 denom = gamma_epu32(Sse2.sub_epi32(n, k), true, elements);
                    
                    return div_epu32(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naiveperm_epu32(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu32(n, true);
                    v256 denom = mm256_gamma_epu32(Avx2.mm256_sub_epi32(n, k), true);
                    
                    return mm256_div_epu32(nom, denom);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naiveperm_epu64(v128 n, v128 k)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 nom = gamma_epu64(n, true);
                    v128 denom = gamma_epu64(Sse2.sub_epi64(n, k), true);
                    
                    return div_epu64(nom, denom);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naiveperm_epu64(v256 n, v256 k, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu64(n, true, elements);
                    v256 denom = mm256_gamma_epu64(Avx2.mm256_sub_epi64(n, k), true, elements);
                    
                    return mm256_div_epu64(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 perm_epu8(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.Byte0, n.Byte0);
Assert.IsNotGreater(k.Byte1, n.Byte1);
if (elements > 2)
{
    Assert.IsNotGreater(k.Byte2, n.Byte2);
}
if (elements > 3)
{
    Assert.IsNotGreater(k.Byte3, n.Byte3);
}
if (elements > 4)
{
    Assert.IsNotGreater(k.Byte4, n.Byte4);
    Assert.IsNotGreater(k.Byte5, n.Byte5);
    Assert.IsNotGreater(k.Byte6, n.Byte6);
    Assert.IsNotGreater(k.Byte7, n.Byte7);
}
if (elements > 8)
{
    Assert.IsNotGreater(k.Byte8,  n.Byte8);
    Assert.IsNotGreater(k.Byte9,  n.Byte9);
    Assert.IsNotGreater(k.Byte10, n.Byte10);
    Assert.IsNotGreater(k.Byte11, n.Byte11);
    Assert.IsNotGreater(k.Byte12, n.Byte12);
    Assert.IsNotGreater(k.Byte13, n.Byte13);
    Assert.IsNotGreater(k.Byte14, n.Byte14);
    Assert.IsNotGreater(k.Byte15, n.Byte15);
}
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U16, elements))
                            {
                                if (unsafeLevels > 3 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U8, elements))
                                {
                                    return naiveperm_epu8(n, k, elements);
                                }
                                else
                                {
                                    if (elements <= 8)
                                    {
                                        return cvtepi16_epi8(naiveperm_epu16(cvtepu8_epi16(n), cvtepu8_epi16(k), false, elements), elements);
                                    }
                                    else
                                    {
                                        if (Avx2.IsAvx2Supported)
                                        {
                                            return mm256_cvtepi16_epi8(mm256_naiveperm_epu16(Avx2.mm256_cvtepu8_epi16(n), Avx2.mm256_cvtepu8_epi16(k), false));
                                        }
                                        else
                                        {
                                            v128 nLo16 = cvt2x2epu8_epi16(n, out v128 nHi16);
                                            v128 kLo16 = cvt2x2epu8_epi16(k, out v128 kHi16);
                                            
                                            v128 resultLo = naiveperm_epu16(nLo16, kLo16, false);
                                            v128 resultHi = naiveperm_epu16(nHi16, kHi16, false);
                                            
                                            return cvt2x2epi16_epi8(resultLo, resultHi);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (elements <= 4)
                                {
                                    return cvtepi32_epi8(naiveperm_epu32(cvtepu8_epi32(n), cvtepu8_epi32(k), elements), elements);
                                }
                                else
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        if (elements == 8)
                                        {
                                            return mm256_cvtepi32_epi8(mm256_naiveperm_epu32(Avx2.mm256_cvtepu8_epi32(n), Avx2.mm256_cvtepu8_epi32(k)));
                                        }
                                        else
                                        {
                                            v256 loN32 = Avx2.mm256_cvtepu8_epi32(n);
                                            v256 loK32 = Avx2.mm256_cvtepu8_epi32(k);
                                            v256 hiN32 = Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(n, 8 * sizeof(byte)));
                                            v256 hiK32 = Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(k, 8 * sizeof(byte)));

                                            v128 resultLo = mm256_cvtepi32_epi8(mm256_naiveperm_epu32(loN32, loK32));
                                            v128 resultHi = mm256_cvtepi32_epi8(mm256_naiveperm_epu32(hiN32, hiK32));

                                            return Sse2.unpacklo_epi64(resultLo, resultHi);
                                        }
                                    }
                                    else
                                    {
                                        if (elements == 8)
                                        {
                                            v128 loN32 = cvtepu8_epi32(n);
                                            v128 loK32 = cvtepu8_epi32(k);
                                            v128 hiN32 = cvtepu8_epi32(Sse2.bsrli_si128(n, 4 * sizeof(byte)));
                                            v128 hiK32 = cvtepu8_epi32(Sse2.bsrli_si128(k, 4 * sizeof(byte)));

                                            v128 resultLo = cvtepi32_epi8(naiveperm_epu32(loN32, loK32));
                                            v128 resultHi = cvtepi32_epi8(naiveperm_epu32(hiN32, hiK32));

                                            return Sse2.unpacklo_epi32(resultLo, resultHi);
                                        }
                                        else
                                        {
                                            v128 loN16 = cvt2x2epu8_epi16(n, out v128 hiN16);
                                            v128 loK16 = cvt2x2epu8_epi16(k, out v128 hiK16);

                                            v128 n32_0 = cvt2x2epu16_epi32(loN16, out v128 n32_1);
                                            v128 n32_2 = cvt2x2epu16_epi32(hiN16, out v128 n32_3);
                                            v128 k32_0 = cvt2x2epu16_epi32(loK16, out v128 k32_1);
                                            v128 k32_2 = cvt2x2epu16_epi32(hiK16, out v128 k32_3);

                                            v128 result32_0 = naiveperm_epu32(n32_0, k32_0);
                                            v128 result32_1 = naiveperm_epu32(n32_1, k32_1);
                                            v128 result32_2 = naiveperm_epu32(n32_2, k32_2);
                                            v128 result32_3 = naiveperm_epu32(n32_3, k32_3);

                                            v128 result16_0 = cvt2x2epi32_epi16(result32_0, result32_1);
                                            v128 result16_1 = cvt2x2epi32_epi16(result32_2, result32_3);

                                            return cvt2x2epi16_epi8(result16_0, result16_1);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            switch (elements)
                            {
                                case 2:
                                {
                                    return Sse2.unpacklo_epi8(Sse2.cvtsi64x_si128((long)maxmath.perm((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), maxmath.Promise.Unsafe1)),
                                                              Sse2.cvtsi64x_si128((long)maxmath.perm((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), maxmath.Promise.Unsafe1)));
                                }

                                case 3:
                                case 4:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi64_epi8(mm256_div_epu64(mm256_gamma_epu64(Avx2.mm256_cvtepu8_epi64(n), true, elements), mm256_gamma_epu64(Avx2.mm256_sub_epi64(Avx2.mm256_cvtepu8_epi64(n), Avx2.mm256_cvtepu8_epi64(k)), true, elements), elements));
                                    }
                                    else
                                    {
                                        return new v128((byte)maxmath.perm((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 2), (ulong)extract_epi8(k, 2), maxmath.Promise.Unsafe1),
                                                        (byte)(elements == 4 ? maxmath.perm((ulong)extract_epi8(n, 3), (ulong)extract_epi8(k, 3), maxmath.Promise.Unsafe1) : 0),
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0);
                                    }
                                }

                                case 8:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        v256 nLo = Avx2.mm256_cvtepu8_epi64(n);
                                        v256 kLo = Avx2.mm256_cvtepu8_epi64(k);
                                        v256 nHi = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(n, 4 * sizeof(byte)));
                                        v256 kHi = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(k, 4 * sizeof(byte)));

                                        v128 lo = mm256_cvtepi64_epi8(mm256_naiveperm_epu64(nLo, kLo));
                                        v128 hi = mm256_cvtepi64_epi8(mm256_naiveperm_epu64(nHi, kHi));

                                        return Sse2.unpacklo_epi32(lo, hi);
                                    }
                                    else
                                    {
                                        return new v128((byte)maxmath.perm((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 2), (ulong)extract_epi8(k, 2), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 3), (ulong)extract_epi8(k, 3), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 4), (ulong)extract_epi8(k, 4), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 5), (ulong)extract_epi8(k, 5), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 6), (ulong)extract_epi8(k, 6), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 7), (ulong)extract_epi8(k, 7), maxmath.Promise.Unsafe1),
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0);
                                    }
                                }

                                default:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        v256 n0 = Avx2.mm256_cvtepu8_epi64(n);
                                        v256 k0 = Avx2.mm256_cvtepu8_epi64(k);
                                        v256 n1 = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(n,  4 * sizeof(byte)));
                                        v256 k1 = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(k,  4 * sizeof(byte)));
                                        v256 n2 = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(n,  8 * sizeof(byte)));
                                        v256 k2 = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(k,  8 * sizeof(byte)));
                                        v256 n3 = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(n, 12 * sizeof(byte)));
                                        v256 k3 = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(k, 12 * sizeof(byte)));

                                        v128 result0 = mm256_cvtepi64_epi8(mm256_naiveperm_epu64(n0, k0));
                                        v128 result1 = mm256_cvtepi64_epi8(mm256_naiveperm_epu64(n1, k1));
                                        v128 result2 = mm256_cvtepi64_epi8(mm256_naiveperm_epu64(n2, k2));
                                        v128 result3 = mm256_cvtepi64_epi8(mm256_naiveperm_epu64(n3, k3));

                                        return Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(result0, result1), Sse2.unpacklo_epi32(result2, result3));
                                    }
                                    else
                                    {
                                        return new v128((byte)maxmath.perm((ulong)extract_epi8(n, 0),  (ulong)extract_epi8(k, 0),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 1),  (ulong)extract_epi8(k, 1),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 2),  (ulong)extract_epi8(k, 2),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 3),  (ulong)extract_epi8(k, 3),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 4),  (ulong)extract_epi8(k, 4),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 5),  (ulong)extract_epi8(k, 5),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 6),  (ulong)extract_epi8(k, 6),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 7),  (ulong)extract_epi8(k, 7),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 8),  (ulong)extract_epi8(k, 8),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 9),  (ulong)extract_epi8(k, 9),  maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 10), (ulong)extract_epi8(k, 10), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 11), (ulong)extract_epi8(k, 11), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 12), (ulong)extract_epi8(k, 12), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 13), (ulong)extract_epi8(k, 13), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 14), (ulong)extract_epi8(k, 14), maxmath.Promise.Unsafe1),
                                                        (byte)maxmath.perm((ulong)extract_epi8(n, 15), (ulong)extract_epi8(k, 15), maxmath.Promise.Unsafe1));
                                    }
                                }
                            }
                        }
                    }


                    if (elements <= 8)
                    {
                        return cvtepi16_epi8(perm_epu16(cvtepu8_epi16(n), cvtepu8_epi16(k), elements: elements), elements);
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return mm256_cvtepi16_epi8(mm256_perm_epu16(Avx2.mm256_cvtepu8_epi16(n), Avx2.mm256_cvtepu8_epi16(k)));
                        }
                        else
                        {
                            v128 ZERO = Sse2.setzero_si128();

                            v128 resultsFoundMask = Sse2.cmpeq_epi8(k, ZERO);
                            v128 results = Sse2.sub_epi8(ZERO, resultsFoundMask);
                            
                            k = dec_epi8(k);
                            v128 p = n;
                            n = dec_epi8(n);

                            v128 cmp = Sse2.cmpeq_epi8(ZERO, k);
                            results = blendv_si128(results, p, cmp);
                            resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);

                            while (Hint.Likely(notalltrue_epi128<byte>(resultsFoundMask, elements)))
                            {
                                k = dec_epi8(k);
                                p = mullo_epi8(p, n, elements);
                                n = dec_epi8(n);

                                cmp = Sse2.cmpeq_epi8(ZERO, k);
                                results = blendv_si128(results, p, cmp);
                                resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);
                            }

                            return results;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_perm_epu8(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.Byte0,  n.Byte0);
Assert.IsNotGreater(k.Byte1,  n.Byte1);
Assert.IsNotGreater(k.Byte2,  n.Byte2);
Assert.IsNotGreater(k.Byte3,  n.Byte3);
Assert.IsNotGreater(k.Byte4,  n.Byte4);
Assert.IsNotGreater(k.Byte5,  n.Byte5);
Assert.IsNotGreater(k.Byte6,  n.Byte6);
Assert.IsNotGreater(k.Byte7,  n.Byte7);
Assert.IsNotGreater(k.Byte8,  n.Byte8);
Assert.IsNotGreater(k.Byte9,  n.Byte9);
Assert.IsNotGreater(k.Byte10, n.Byte10);
Assert.IsNotGreater(k.Byte11, n.Byte11);
Assert.IsNotGreater(k.Byte12, n.Byte12);
Assert.IsNotGreater(k.Byte13, n.Byte13);
Assert.IsNotGreater(k.Byte14, n.Byte14);
Assert.IsNotGreater(k.Byte15, n.Byte15);
Assert.IsNotGreater(k.Byte16, n.Byte16);
Assert.IsNotGreater(k.Byte17, n.Byte17);
Assert.IsNotGreater(k.Byte18, n.Byte18);
Assert.IsNotGreater(k.Byte19, n.Byte19);
Assert.IsNotGreater(k.Byte20, n.Byte20);
Assert.IsNotGreater(k.Byte21, n.Byte21);
Assert.IsNotGreater(k.Byte22, n.Byte22);
Assert.IsNotGreater(k.Byte23, n.Byte23);
Assert.IsNotGreater(k.Byte24, n.Byte24);
Assert.IsNotGreater(k.Byte25, n.Byte25);
Assert.IsNotGreater(k.Byte26, n.Byte26);
Assert.IsNotGreater(k.Byte27, n.Byte27);
Assert.IsNotGreater(k.Byte28, n.Byte28);
Assert.IsNotGreater(k.Byte29, n.Byte29);
Assert.IsNotGreater(k.Byte30, n.Byte30);
Assert.IsNotGreater(k.Byte31, n.Byte31);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U16))
                            {
                                if (unsafeLevels > 3 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U8))
                                {
                                    return mm256_naiveperm_epu8(n, k);
                                }
                                else
                                {
                                    v256 nLo16 = mm256_cvt2x2epu8_epi16(n, out v256 nHi16);
                                    v256 kLo16 = mm256_cvt2x2epu8_epi16(k, out v256 kHi16);
                            
                                    return mm256_cvt2x2epi16_epi8(mm256_naiveperm_epu16(nLo16, kLo16), mm256_naiveperm_epu16(nHi16, kHi16));
                                }
                            }
                            else
                            {
                                v256 loN16 = mm256_cvt2x2epu8_epi16(n, out v256 hiN16);
                                v256 loK16 = mm256_cvt2x2epu8_epi16(k, out v256 hiK16);
                                
                                v256 n32_0 = mm256_cvt2x2epu16_epi32(loN16, out v256 n32_1);
                                v256 n32_2 = mm256_cvt2x2epu16_epi32(hiN16, out v256 n32_3);
                                v256 k32_0 = mm256_cvt2x2epu16_epi32(loK16, out v256 k32_1);
                                v256 k32_2 = mm256_cvt2x2epu16_epi32(hiK16, out v256 k32_3);
                                
                                v256 result32_0 = mm256_naiveperm_epu32(n32_0, k32_0);
                                v256 result32_1 = mm256_naiveperm_epu32(n32_1, k32_1);
                                v256 result32_2 = mm256_naiveperm_epu32(n32_2, k32_2);
                                v256 result32_3 = mm256_naiveperm_epu32(n32_3, k32_3);
                                
                                v256 result16_0 = mm256_cvt2x2epi32_epi16(result32_0, result32_1);
                                v256 result16_1 = mm256_cvt2x2epi32_epi16(result32_2, result32_3);
                                
                                return mm256_cvt2x2epi16_epi8(result16_0, result16_1);
                            }
                        }
                        else
                        {
                            v256 loN16 = mm256_cvt2x2epu8_epi16(n, out v256 hiN16);
                            v256 loK16 = mm256_cvt2x2epu8_epi16(k, out v256 hiK16);
                            
                            v256 n32_0 = mm256_cvt2x2epu16_epi32(loN16, out v256 n32_1);
                            v256 n32_2 = mm256_cvt2x2epu16_epi32(hiN16, out v256 n32_3);
                            v256 k32_0 = mm256_cvt2x2epu16_epi32(loK16, out v256 k32_1);
                            v256 k32_2 = mm256_cvt2x2epu16_epi32(hiK16, out v256 k32_3);

                            v256 n64_0 = mm256_cvt2x2epu32_epi64(n32_0, out v256 n64_1);
                            v256 n64_2 = mm256_cvt2x2epu32_epi64(n32_1, out v256 n64_3);
                            v256 n64_4 = mm256_cvt2x2epu32_epi64(n32_2, out v256 n64_5);
                            v256 n64_6 = mm256_cvt2x2epu32_epi64(n32_3, out v256 n64_7);
                            v256 k64_0 = mm256_cvt2x2epu32_epi64(k32_0, out v256 k64_1);
                            v256 k64_2 = mm256_cvt2x2epu32_epi64(k32_1, out v256 k64_3);
                            v256 k64_4 = mm256_cvt2x2epu32_epi64(k32_2, out v256 k64_5);
                            v256 k64_6 = mm256_cvt2x2epu32_epi64(k32_3, out v256 k64_7);

                            v256 result64_0 = mm256_naiveperm_epu64(n64_0, k64_0);
                            v256 result64_1 = mm256_naiveperm_epu64(n64_1, k64_1);
                            v256 result64_2 = mm256_naiveperm_epu64(n64_2, k64_2);
                            v256 result64_3 = mm256_naiveperm_epu64(n64_3, k64_3);
                            v256 result64_4 = mm256_naiveperm_epu64(n64_4, k64_4);
                            v256 result64_5 = mm256_naiveperm_epu64(n64_5, k64_5);
                            v256 result64_6 = mm256_naiveperm_epu64(n64_6, k64_6);
                            v256 result64_7 = mm256_naiveperm_epu64(n64_7, k64_7);

                            v256 result32_0 = mm256_cvt2x2epi64_epi32(result64_0, result64_1);
                            v256 result32_1 = mm256_cvt2x2epi64_epi32(result64_2, result64_3);
                            v256 result32_2 = mm256_cvt2x2epi64_epi32(result64_4, result64_5);
                            v256 result32_3 = mm256_cvt2x2epi64_epi32(result64_6, result64_7);

                            v256 result16_0 = mm256_cvt2x2epi32_epi16(result32_0, result32_1);
                            v256 result16_1 = mm256_cvt2x2epi32_epi16(result32_2, result32_3);

                            return mm256_cvt2x2epi16_epi8(result16_0, result16_1);
                        }
                    }


                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 resultsFoundMask = Avx2.mm256_cmpeq_epi8(k, ZERO);
                    v256 results = Avx2.mm256_sub_epi8(ZERO, resultsFoundMask);
                    
                    k = mm256_dec_epi8(k);
                    v256 p = n;
                    n = mm256_dec_epi8(n);

                    v256 cmp = Avx2.mm256_cmpeq_epi8(ZERO, k);
                    results = mm256_blendv_si256(results, p, cmp);
                    resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);

                    while (Hint.Likely(mm256_notalltrue_epi256<byte>(resultsFoundMask, 32)))
                    {
                        k = mm256_dec_epi8(k);
                        p = mm256_mullo_epi8(p, n);
                        n = mm256_dec_epi8(n);

                        cmp = Avx2.mm256_cmpeq_epi8(ZERO, k);
                        results = mm256_blendv_si256(results, p, cmp);
                        resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 perm_epu16(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.UShort0, n.UShort0);
Assert.IsNotGreater(k.UShort1, n.UShort1);
if (elements > 2)
{
    Assert.IsNotGreater(k.UShort2, n.UShort2);
}
if (elements > 3)
{
    Assert.IsNotGreater(k.UShort3, n.UShort3);
}
if (elements > 4)
{
    Assert.IsNotGreater(k.UShort4, n.UShort4);
    Assert.IsNotGreater(k.UShort5, n.UShort5);
    Assert.IsNotGreater(k.UShort6, n.UShort6);
    Assert.IsNotGreater(k.UShort7, n.UShort7);
}
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U16, elements))
                            {
                                return naiveperm_epu16(n, k, unsafeLevels > 3 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8, elements), elements);
                            }
                            else
                            {
                                if (elements <= 4)
                                {
                                    return cvtepi32_epi16(naiveperm_epu32(cvtepu16_epi32(n), cvtepu16_epi32(k), elements), elements);
                                }
                                else
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi32_epi16(mm256_naiveperm_epu32(Avx2.mm256_cvtepu16_epi32(n), Avx2.mm256_cvtepu16_epi32(k)));
                                    }
                                    else
                                    {
                                        v128 nLo32 = cvt2x2epu16_epi32(n, out v128 nHi32);
                                        v128 kLo32 = cvt2x2epu16_epi32(k, out v128 kHi32);

                                        return cvt2x2epi32_epi16(naiveperm_epu32(nLo32, kLo32, elements), naiveperm_epu32(nHi32, kHi32, elements));
                                    }
                                }
                            }
                        }
                        else
                        {
                            switch (elements)
                            {
                                case 2:
                                {
                                    return Sse2.unpacklo_epi16(Sse2.cvtsi32_si128((ushort)maxmath.perm((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), maxmath.Promise.Unsafe1)), 
                                                               Sse2.cvtsi32_si128((ushort)maxmath.perm((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), maxmath.Promise.Unsafe1)));
                                }

                                case 3:
                                case 4:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi64_epi16(mm256_naiveperm_epu64(Avx2.mm256_cvtepu16_epi64(n), Avx2.mm256_cvtepu16_epi64(k), elements));
                                    }
                                    else
                                    {
                                        return new v128((ushort)maxmath.perm((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 2), (ulong)extract_epi16(k, 2), maxmath.Promise.Unsafe1),
                                                        (ushort)(elements == 4 ? maxmath.perm((ulong)extract_epi16(n, 3), (ulong)extract_epi16(k, 3), maxmath.Promise.Unsafe1) : 0),
                                                        0,
                                                        0,
                                                        0,
                                                        0);
                                    }
                                }

                                default:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        v256 n64Lo = Avx2.mm256_cvtepu16_epi64(n);
                                        v256 k64Lo = Avx2.mm256_cvtepu16_epi64(k);
                                        v256 n64Hi = Avx2.mm256_cvtepu16_epi64(Sse2.bsrli_si128(n, 4 * sizeof(ushort)));
                                        v256 k64Hi = Avx2.mm256_cvtepu16_epi64(Sse2.bsrli_si128(k, 4 * sizeof(ushort)));

                                        v256 result64Lo = mm256_naiveperm_epu64(n64Lo, k64Lo);
                                        v256 result64Hi = mm256_naiveperm_epu64(n64Hi, k64Hi);

                                        return Sse2.unpacklo_epi64(mm256_cvtepi64_epi16(result64Lo), mm256_cvtepi64_epi16(result64Hi));
                                    }
                                    else
                                    {
                                        return new v128((ushort)maxmath.perm((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 2), (ulong)extract_epi16(k, 2), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 3), (ulong)extract_epi16(k, 3), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 4), (ulong)extract_epi16(k, 4), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 5), (ulong)extract_epi16(k, 5), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 6), (ulong)extract_epi16(k, 6), maxmath.Promise.Unsafe1),
                                                        (ushort)maxmath.perm((ulong)extract_epi16(n, 7), (ulong)extract_epi16(k, 7), maxmath.Promise.Unsafe1));
                                    }
                                }
                            }
                        }
                    }


                    v128 ZERO = Sse2.setzero_si128();

                    v128 resultsFoundMask = Sse2.cmpeq_epi16(k, ZERO);
                    v128 results = Sse2.sub_epi16(ZERO, resultsFoundMask);
                    
                    k = dec_epi16(k);
                    v128 p = n;
                    n = dec_epi16(n);

                    v128 cmp = Sse2.cmpeq_epi16(ZERO, k);
                    results = blendv_si128(results, p, cmp);
                    resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);

                    while (Hint.Likely(notalltrue_epi128<ushort>(resultsFoundMask, elements)))
                    {
                        k = dec_epi16(k);
                        p = Sse2.mullo_epi16(p, n);
                        n = dec_epi16(n);

                        cmp = Sse2.cmpeq_epi16(ZERO, k);
                        results = blendv_si128(results, p, cmp);
                        resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_perm_epu16(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.UShort0,  n.UShort0);
Assert.IsNotGreater(k.UShort1,  n.UShort1);
Assert.IsNotGreater(k.UShort2,  n.UShort2);
Assert.IsNotGreater(k.UShort3,  n.UShort3);
Assert.IsNotGreater(k.UShort4,  n.UShort4);
Assert.IsNotGreater(k.UShort5,  n.UShort5);
Assert.IsNotGreater(k.UShort6,  n.UShort6);
Assert.IsNotGreater(k.UShort7,  n.UShort7);
Assert.IsNotGreater(k.UShort8,  n.UShort8);
Assert.IsNotGreater(k.UShort9,  n.UShort9);
Assert.IsNotGreater(k.UShort10, n.UShort10);
Assert.IsNotGreater(k.UShort11, n.UShort11);
Assert.IsNotGreater(k.UShort12, n.UShort12);
Assert.IsNotGreater(k.UShort13, n.UShort13);
Assert.IsNotGreater(k.UShort14, n.UShort14);
Assert.IsNotGreater(k.UShort15, n.UShort15);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U16))
                            {
                                return mm256_naiveperm_epu16(n, k, unsafeLevels > 3 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8));
                            }
                            else
                            {
                                v256 nLo32 = mm256_cvt2x2epu16_epi32(n, out v256 nHi32);
                                v256 kLo32 = mm256_cvt2x2epu16_epi32(k, out v256 kHi32);
                        
                                v256 resultLo = mm256_naiveperm_epu32(nLo32, kLo32);
                                v256 resultHi = mm256_naiveperm_epu32(nHi32, kHi32);
                        
                                return mm256_cvt2x2epi32_epi16(resultLo, resultHi);
                            }
                        }
                        else
                        {
                            v256 nLo32 = mm256_cvt2x2epu16_epi32(n, out v256 nHi32);
                            v256 kLo32 = mm256_cvt2x2epu16_epi32(k, out v256 kHi32);
                            v256 n64LoLo = mm256_cvt2x2epu32_epi64(nLo32, out v256 n64LoHi);
                            v256 n64HiLo = mm256_cvt2x2epu32_epi64(nHi32, out v256 n64HiHi);
                            v256 k64LoLo = mm256_cvt2x2epu32_epi64(kLo32, out v256 k64LoHi);
                            v256 k64HiLo = mm256_cvt2x2epu32_epi64(kHi32, out v256 k64HiHi);

                            v256 resultLoLo = mm256_naiveperm_epu64(n64LoLo, k64LoLo);
                            v256 resultLoHi = mm256_naiveperm_epu64(n64LoHi, k64LoHi);
                            v256 resultHiLo = mm256_naiveperm_epu64(n64HiLo, k64HiLo);
                            v256 resultHiHi = mm256_naiveperm_epu64(n64HiHi, k64HiHi);

                            v256 result32Lo = mm256_cvt2x2epi64_epi32(resultLoLo, resultLoHi);
                            v256 result32Hi = mm256_cvt2x2epi64_epi32(resultHiLo, resultHiHi);

                            return mm256_cvt2x2epi32_epi16(result32Lo, result32Hi);
                        }
                    }


                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 resultsFoundMask = Avx2.mm256_cmpeq_epi16(k, ZERO);
                    v256 results = Avx2.mm256_sub_epi16(ZERO, resultsFoundMask);
                    
                    k = mm256_dec_epi16(k);
                    v256 p = n;
                    n = mm256_dec_epi16(n);

                    v256 cmp = Avx2.mm256_cmpeq_epi16(ZERO, k);
                    results = mm256_blendv_si256(results, p, cmp);
                    resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);

                    while (Hint.Likely(mm256_notalltrue_epi256<ushort>(resultsFoundMask, 16)))
                    {
                        k = mm256_dec_epi16(k);
                        p = Avx2.mm256_mullo_epi16(p, n);
                        n = mm256_dec_epi16(n);

                        cmp = Avx2.mm256_cmpeq_epi16(ZERO, k);
                        results = mm256_blendv_si256(results, p, cmp);
                        resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 perm_epu32(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.UInt0, n.UInt0);
Assert.IsNotGreater(k.UInt1, n.UInt1);
if (elements > 2)
{
    Assert.IsNotGreater(k.UInt2, n.UInt2);
}
if (elements > 3)
{
    Assert.IsNotGreater(k.UInt3, n.UInt3);
}
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            return naiveperm_epu32(n, k, elements);
                        }
                        else
                        {
                            if (elements > 2)
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    return mm256_cvtepi64_epi32(mm256_naiveperm_epu64(Avx2.mm256_cvtepu32_epi64(n), Avx2.mm256_cvtepu32_epi64(k), elements));
                                }
                                else
                                {
                                    v128 lo = Sse2.unpacklo_epi32(Sse2.cvtsi32_si128((int)maxmath.perm((ulong)extract_epi32(n, 0), (ulong)extract_epi32(k, 0), maxmath.Promise.Unsafe1)),
                                                                  Sse2.cvtsi32_si128((int)maxmath.perm((ulong)extract_epi32(n, 1), (ulong)extract_epi32(k, 1), maxmath.Promise.Unsafe1)));
                                    v128 hi = Sse2.cvtsi32_si128((int)maxmath.perm((ulong)extract_epi32(n, 2), (ulong)extract_epi32(k, 2), maxmath.Promise.Unsafe1));

                                    if (elements == 4)
                                    {
                                        hi = Sse2.unpacklo_epi32(hi, Sse2.cvtsi32_si128((int)maxmath.perm((ulong)extract_epi32(n, 3), (ulong)extract_epi32(k, 3), maxmath.Promise.Unsafe1)));
                                    }

                                    return Sse2.unpacklo_epi64(lo, hi);
                                }
                            }
                            else
                            {
                                return Sse2.unpacklo_epi32(Sse2.cvtsi32_si128((int)maxmath.perm((ulong)extract_epi32(n, 0), (ulong)extract_epi32(k, 0), maxmath.Promise.Unsafe1)),
                                                           Sse2.cvtsi32_si128((int)maxmath.perm((ulong)extract_epi32(n, 1), (ulong)extract_epi32(k, 1), maxmath.Promise.Unsafe1)));
                            }
                        }
                    }


                    v128 ZERO = Sse2.setzero_si128();

                    v128 resultsFoundMask = Sse2.cmpeq_epi32(k, ZERO);
                    v128 results = Sse2.sub_epi32(ZERO, resultsFoundMask);
                    
                    k = dec_epi32(k);
                    v128 p = n;
                    n = dec_epi32(n);

                    v128 cmp = Sse2.cmpeq_epi32(ZERO, k);
                    results = blendv_si128(results, p, cmp);
                    resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);
                    
                    while (Hint.Likely(notalltrue_epi128<uint>(resultsFoundMask, elements)))
                    {
                        k = dec_epi32(k);
                        p = mullo_epi32(p, n, elements);
                        n = dec_epi32(n);
                    
                        cmp = Sse2.cmpeq_epi32(ZERO, k);
                        results = blendv_si128(results, p, cmp);
                        resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_perm_epu32(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.UInt0, n.UInt0);
Assert.IsNotGreater(k.UInt1, n.UInt1);
Assert.IsNotGreater(k.UInt2, n.UInt2);
Assert.IsNotGreater(k.UInt3, n.UInt3);
Assert.IsNotGreater(k.UInt4, n.UInt4);
Assert.IsNotGreater(k.UInt5, n.UInt5);
Assert.IsNotGreater(k.UInt6, n.UInt6);
Assert.IsNotGreater(k.UInt7, n.UInt7);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            return mm256_naiveperm_epu32(n, k);
                        }
                        else
                        {
                            v256 n64Lo = mm256_cvt2x2epu32_epi64(n, out v256 n64Hi);
                            v256 k64Lo = mm256_cvt2x2epu32_epi64(k, out v256 k64Hi);

                            v256 resultLo = mm256_naiveperm_epu64(n64Lo, k64Lo);
                            v256 resultHi = mm256_naiveperm_epu64(n64Hi, k64Hi);

                            return mm256_cvt2x2epi64_epi32(resultLo, resultHi);
                        }
                    }


                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 resultsFoundMask = Avx2.mm256_cmpeq_epi32(k, ZERO);
                    v256 results = Avx2.mm256_sub_epi32(ZERO, resultsFoundMask);
                    
                    k = mm256_dec_epi32(k);
                    v256 p = n;
                    n = mm256_dec_epi32(n);

                    v256 cmp = Avx2.mm256_cmpeq_epi32(ZERO, k);
                    results = mm256_blendv_si256(results, p, cmp);
                    resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);

                    while (Hint.Likely(mm256_notalltrue_epi256<uint>(resultsFoundMask, 8)))
                    {
                        k = mm256_dec_epi32(k);
                        p = Avx2.mm256_mullo_epi32(p, n);
                        n = mm256_dec_epi32(n);

                        cmp = Avx2.mm256_cmpeq_epi32(ZERO, k);
                        results = mm256_blendv_si256(results, p, cmp);
                        resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 perm_epu64(v128 n, v128 k, byte unsafeLevels = 0)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.ULong0, n.ULong0);
Assert.IsNotGreater(k.ULong1, n.ULong1);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            v128 nFactorial  = gamma_epu64(n, true);
                            v128 nkFactorial = gamma_epu64(Sse2.sub_epi64(n, k), true);
                            
                            return usfcvttpd_epu64(Sse2.div_pd(usfcvtepu64_pd(nFactorial), usfcvtepu64_pd(nkFactorial)));
                        }
                        else
                        {
                            return Sse2.unpacklo_epi64(Sse2.cvtsi64x_si128((long)maxmath.perm(extract_epi64(n, 0), extract_epi64(k, 0), maxmath.Promise.Unsafe1)),
                                                       Sse2.cvtsi64x_si128((long)maxmath.perm(extract_epi64(n, 1), extract_epi64(k, 1), maxmath.Promise.Unsafe1)));
                        }
                    }


                    v128 ZERO = Sse2.setzero_si128();

                    v128 resultsFoundMask = cmpeq_epi64(k, ZERO);
                    v128 results = Sse2.sub_epi64(ZERO, resultsFoundMask);
                    
                    k = dec_epi64(k);
                    v128 p = n;
                    n = dec_epi64(n);

                    v128 cmp = cmpeq_epi64(ZERO, k);
                    results = blendv_si128(results, p, cmp);
                    resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);

                    while (Hint.Likely(notalltrue_epi128<ulong>(resultsFoundMask, 2)))
                    {
                        k = dec_epi64(k);
                        p = mullo_epi64(p, n);
                        n = dec_epi64(n);

                        cmp = cmpeq_epi64(ZERO, k);
                        results = blendv_si128(results, p, cmp);
                        resultsFoundMask = Sse2.or_si128(resultsFoundMask, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_perm_epu64(v256 n, v256 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.ULong0, n.ULong0);
Assert.IsNotGreater(k.ULong1, n.ULong1);
Assert.IsNotGreater(k.ULong2, n.ULong2);
if (elements > 3)
{
    Assert.IsNotGreater(k.ULong3, n.ULong3);
}
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            v256 nFactorial  = mm256_gamma_epu64(n, true);
                            v256 nkFactorial = mm256_gamma_epu64(Avx2.mm256_sub_epi64(n, k), true);
                            
                            return mm256_usfcvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(nFactorial), mm256_usfcvtepu64_pd(nkFactorial)));
                        }
                        else
                        {
                            return mm256_naiveperm_epu64(n, k, elements);
                        }
                    }


                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 resultsFoundMask = Avx2.mm256_cmpeq_epi64(k, ZERO);
                    v256 results = Avx2.mm256_sub_epi64(ZERO, resultsFoundMask);
                    
                    k = mm256_dec_epi64(k);
                    v256 p = n;
                    n = mm256_dec_epi64(n);

                    v256 cmp = Avx2.mm256_cmpeq_epi64(ZERO, k);
                    results = mm256_blendv_si256(results, p, cmp);
                    resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);

                    while (Hint.Likely(mm256_notalltrue_epi256<ulong>(resultsFoundMask, elements)))
                    {
                        k = mm256_dec_epi64(k);
                        p = mm256_mullo_epi64(p, n, elements);
                        n = mm256_dec_epi64(n);

                        cmp = Avx2.mm256_cmpeq_epi64(ZERO, k);
                        results = mm256_blendv_si256(results, p, cmp);
                        resultsFoundMask = Avx2.mm256_or_si256(resultsFoundMask, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 perm(UInt128 n, UInt128 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U128))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
                {
                    return factorial(n.lo64, Promise.NoOverflow) / factorial(n.lo64 - k.lo64, Promise.NoOverflow);
                }
                else
                {
                    return factorial(n, Promise.NoOverflow) / factorial(n - k, Promise.NoOverflow);
                }
            }


            if (Hint.Unlikely(k-- == 0))
            {
                return 1;
            }
            else
            {
                UInt128 p = n--;

                while (Hint.Likely(k-- != 0))
                {
                    p *= n--;
                }

                return p;
            }
        }
        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 perm(Int128 n, Int128 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsTrue(k >= 0);
Assert.IsTrue(n >= 0);
            
            return perm((UInt128)n, (UInt128)k, useFactorial);
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte perm(byte n, byte k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    if (useFactorial.CountUnsafeLevels() > 2 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U16))
                    {
                        if (useFactorial.CountUnsafeLevels() > 3 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U8))
                        {
                            return (byte)(factorial(n, Promise.NoOverflow) / factorial((byte)(n - k), Promise.NoOverflow));
                        }
                        else
                        {
                            return (byte)(factorial((ushort)n, Promise.NoOverflow) / factorial((ushort)(n - k), Promise.NoOverflow));
                        }
                    }
                    else
                    {
                        return (byte)(factorial((uint)n, Promise.NoOverflow) / factorial((uint)(n - k), Promise.NoOverflow));
                    }
                }
                else
                {
                    return (byte)(factorial((ulong)n, Promise.NoOverflow) / factorial((ulong)(n - k), Promise.NoOverflow));
                }
            }


            return (byte)perm((uint)n, (uint)k);
        }
            
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 perm(byte2 n, byte2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu8(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 2);
            }
            else
            {
                return new byte2(perm(n.x, k.x, useFactorial), 
                                 perm(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 perm(byte3 n, byte3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu8(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 3);
            }
            else
            {
                return new byte3(perm(n.x, k.x, useFactorial), 
                                 perm(n.y, k.y, useFactorial), 
                                 perm(n.z, k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 perm(byte4 n, byte4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu8(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 4);
            }
            else
            {
                return new byte4(perm(n.x, k.x, useFactorial), 
                                 perm(n.y, k.y, useFactorial), 
                                 perm(n.z, k.z, useFactorial), 
                                 perm(n.w, k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 perm(byte8 n, byte8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu8(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 8);
            }
            else
            {
                return new byte8(perm(n.x0, k.x0, useFactorial), 
                                 perm(n.x1, k.x1, useFactorial), 
                                 perm(n.x2, k.x2, useFactorial), 
                                 perm(n.x3, k.x3, useFactorial), 
                                 perm(n.x4, k.x4, useFactorial), 
                                 perm(n.x5, k.x5, useFactorial), 
                                 perm(n.x6, k.x6, useFactorial), 
                                 perm(n.x7, k.x7, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 perm(byte16 n, byte16 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu8(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 16);
            }
            else
            {
                return new byte16(perm(n.x0,  k.x0,  useFactorial), 
                                  perm(n.x1,  k.x1,  useFactorial), 
                                  perm(n.x2,  k.x2,  useFactorial), 
                                  perm(n.x3,  k.x3,  useFactorial), 
                                  perm(n.x4,  k.x4,  useFactorial), 
                                  perm(n.x5,  k.x5,  useFactorial), 
                                  perm(n.x6,  k.x6,  useFactorial), 
                                  perm(n.x7,  k.x7,  useFactorial), 
                                  perm(n.x8,  k.x8,  useFactorial), 
                                  perm(n.x9,  k.x9,  useFactorial), 
                                  perm(n.x10, k.x10, useFactorial), 
                                  perm(n.x11, k.x11, useFactorial), 
                                  perm(n.x12, k.x12, useFactorial), 
                                  perm(n.x13, k.x13, useFactorial), 
                                  perm(n.x14, k.x14, useFactorial), 
                                  perm(n.x15, k.x15, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 perm(byte32 n, byte32 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_perm_epu8(n, k, unsafeLevels: useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new byte32(perm(n.v16_0, k.v16_0, useFactorial), perm(n.v16_16, k.v16_16, useFactorial));
            }
        }

        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte perm(sbyte n, sbyte k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNonNegative(n);
Assert.IsNonNegative(k);

            return perm((byte)n, (byte)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 perm(sbyte2 n, sbyte2 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);

            return perm((byte2)n, (byte2)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 perm(sbyte3 n, sbyte3 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);

            return perm((byte3)n, (byte3)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 perm(sbyte4 n, sbyte4 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);
Assert.IsNonNegative(n.w);
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);
Assert.IsNonNegative(k.w);

            return perm((byte4)n, (byte4)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 perm(sbyte8 n, sbyte8 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x0);
Assert.IsNonNegative(n.x1);
Assert.IsNonNegative(n.x2);
Assert.IsNonNegative(n.x3);
Assert.IsNonNegative(n.x4);
Assert.IsNonNegative(n.x5);
Assert.IsNonNegative(n.x6);
Assert.IsNonNegative(n.x7);
Assert.IsNonNegative(k.x0);
Assert.IsNonNegative(k.x1);
Assert.IsNonNegative(k.x2);
Assert.IsNonNegative(k.x3);
Assert.IsNonNegative(k.x4);
Assert.IsNonNegative(k.x5);
Assert.IsNonNegative(k.x6);
Assert.IsNonNegative(k.x7);

            return perm((byte8)n, (byte8)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 perm(sbyte16 n, sbyte16 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x0);
Assert.IsNonNegative(n.x1);
Assert.IsNonNegative(n.x2);
Assert.IsNonNegative(n.x3);
Assert.IsNonNegative(n.x4);
Assert.IsNonNegative(n.x5);
Assert.IsNonNegative(n.x6);
Assert.IsNonNegative(n.x7);
Assert.IsNonNegative(n.x8);
Assert.IsNonNegative(n.x9);
Assert.IsNonNegative(n.x10);
Assert.IsNonNegative(n.x11);
Assert.IsNonNegative(n.x12);
Assert.IsNonNegative(n.x13);
Assert.IsNonNegative(n.x14);
Assert.IsNonNegative(n.x15);
Assert.IsNonNegative(k.x0);
Assert.IsNonNegative(k.x1);
Assert.IsNonNegative(k.x2);
Assert.IsNonNegative(k.x3);
Assert.IsNonNegative(k.x4);
Assert.IsNonNegative(k.x5);
Assert.IsNonNegative(k.x6);
Assert.IsNonNegative(k.x7);
Assert.IsNonNegative(k.x8);
Assert.IsNonNegative(k.x9);
Assert.IsNonNegative(k.x10);
Assert.IsNonNegative(k.x11);
Assert.IsNonNegative(k.x12);
Assert.IsNonNegative(k.x13);
Assert.IsNonNegative(k.x14);
Assert.IsNonNegative(k.x15);

            return perm((byte16)n, (byte16)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 perm(sbyte32 n, sbyte32 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x0);
Assert.IsNonNegative(n.x1);
Assert.IsNonNegative(n.x2);
Assert.IsNonNegative(n.x3);
Assert.IsNonNegative(n.x4);
Assert.IsNonNegative(n.x5);
Assert.IsNonNegative(n.x6);
Assert.IsNonNegative(n.x7);
Assert.IsNonNegative(n.x8);
Assert.IsNonNegative(n.x9);
Assert.IsNonNegative(n.x10);
Assert.IsNonNegative(n.x11);
Assert.IsNonNegative(n.x12);
Assert.IsNonNegative(n.x13);
Assert.IsNonNegative(n.x14);
Assert.IsNonNegative(n.x15);
Assert.IsNonNegative(n.x16);
Assert.IsNonNegative(n.x17);
Assert.IsNonNegative(n.x18);
Assert.IsNonNegative(n.x19);
Assert.IsNonNegative(n.x20);
Assert.IsNonNegative(n.x21);
Assert.IsNonNegative(n.x22);
Assert.IsNonNegative(n.x23);
Assert.IsNonNegative(n.x24);
Assert.IsNonNegative(n.x25);
Assert.IsNonNegative(n.x26);
Assert.IsNonNegative(n.x27);
Assert.IsNonNegative(n.x28);
Assert.IsNonNegative(n.x29);
Assert.IsNonNegative(n.x30);
Assert.IsNonNegative(n.x31);
Assert.IsNonNegative(k.x0);
Assert.IsNonNegative(k.x1);
Assert.IsNonNegative(k.x2);
Assert.IsNonNegative(k.x3);
Assert.IsNonNegative(k.x4);
Assert.IsNonNegative(k.x5);
Assert.IsNonNegative(k.x6);
Assert.IsNonNegative(k.x7);
Assert.IsNonNegative(k.x8);
Assert.IsNonNegative(k.x9);
Assert.IsNonNegative(k.x10);
Assert.IsNonNegative(k.x11);
Assert.IsNonNegative(k.x12);
Assert.IsNonNegative(k.x13);
Assert.IsNonNegative(k.x14);
Assert.IsNonNegative(k.x15);
Assert.IsNonNegative(k.x16);
Assert.IsNonNegative(k.x17);
Assert.IsNonNegative(k.x18);
Assert.IsNonNegative(k.x19);
Assert.IsNonNegative(k.x20);
Assert.IsNonNegative(k.x21);
Assert.IsNonNegative(k.x22);
Assert.IsNonNegative(k.x23);
Assert.IsNonNegative(k.x24);
Assert.IsNonNegative(k.x25);
Assert.IsNonNegative(k.x26);
Assert.IsNonNegative(k.x27);
Assert.IsNonNegative(k.x28);
Assert.IsNonNegative(k.x29);
Assert.IsNonNegative(k.x30);
Assert.IsNonNegative(k.x31);

            return perm((byte32)n, (byte32)k, useFactorial);
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort perm(ushort n, ushort k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    if (useFactorial.CountUnsafeLevels() > 2 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U16))
                    {
                        return (ushort)(factorial(n, Promise.NoOverflow) / factorial((ushort)(n - k), Promise.NoOverflow));
                    }
                    else
                    {
                        return (ushort)(factorial((uint)n, Promise.NoOverflow) / factorial((uint)(n - k), Promise.NoOverflow));
                    }
                }
                else
                {
                    return (ushort)(factorial((ulong)n, Promise.NoOverflow) / factorial((ulong)(n - k), Promise.NoOverflow));
                }
            }


            return (ushort)perm((uint)n, (uint)k);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 perm(ushort2 n, ushort2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu16(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 2);
            }
            else
            {
                return new ushort2(perm(n.x, k.x, useFactorial), 
                                   perm(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 perm(ushort3 n, ushort3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu16(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 3);
            }
            else
            {
                return new ushort3(perm(n.x, k.x, useFactorial), 
                                   perm(n.y, k.y, useFactorial), 
                                   perm(n.z, k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 perm(ushort4 n, ushort4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu16(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 4);
            }
            else
            {
                return new ushort4(perm(n.x, k.x, useFactorial), 
                                   perm(n.y, k.y, useFactorial), 
                                   perm(n.z, k.z, useFactorial), 
                                   perm(n.w, k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 perm(ushort8 n, ushort8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu16(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 8);
            }
            else
            {
                return new ushort8(perm(n.x0, k.x0, useFactorial), 
                                   perm(n.x1, k.x1, useFactorial), 
                                   perm(n.x2, k.x2, useFactorial), 
                                   perm(n.x3, k.x3, useFactorial), 
                                   perm(n.x4, k.x4, useFactorial), 
                                   perm(n.x5, k.x5, useFactorial), 
                                   perm(n.x6, k.x6, useFactorial), 
                                   perm(n.x7, k.x7, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 perm(ushort16 n, ushort16 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_perm_epu16(n, k, unsafeLevels: useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ushort16(perm(n.v8_0, k.v8_0, useFactorial), perm(n.v8_8, k.v8_8, useFactorial));
            }
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort perm(short n, short k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNonNegative(n);
Assert.IsNonNegative(k);

            return perm((ushort)n, (ushort)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 perm(short2 n, short2 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);

            return perm((ushort2)n, (ushort2)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 perm(short3 n, short3 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);

            return perm((ushort3)n, (ushort3)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 perm(short4 n, short4 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);
Assert.IsNonNegative(n.w);
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);
Assert.IsNonNegative(k.w);

            return perm((ushort4)n, (ushort4)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 perm(short8 n, short8 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x0);
Assert.IsNonNegative(n.x1);
Assert.IsNonNegative(n.x2);
Assert.IsNonNegative(n.x3);
Assert.IsNonNegative(n.x4);
Assert.IsNonNegative(n.x5);
Assert.IsNonNegative(n.x6);
Assert.IsNonNegative(n.x7);
Assert.IsNonNegative(k.x0);
Assert.IsNonNegative(k.x1);
Assert.IsNonNegative(k.x2);
Assert.IsNonNegative(k.x3);
Assert.IsNonNegative(k.x4);
Assert.IsNonNegative(k.x5);
Assert.IsNonNegative(k.x6);
Assert.IsNonNegative(k.x7);

            return perm((ushort8)n, (ushort8)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 perm(short16 n, short16 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(n.x0);
Assert.IsNonNegative(n.x1);
Assert.IsNonNegative(n.x2);
Assert.IsNonNegative(n.x3);
Assert.IsNonNegative(n.x4);
Assert.IsNonNegative(n.x5);
Assert.IsNonNegative(n.x6);
Assert.IsNonNegative(n.x7);
Assert.IsNonNegative(n.x8);
Assert.IsNonNegative(n.x9);
Assert.IsNonNegative(n.x10);
Assert.IsNonNegative(n.x11);
Assert.IsNonNegative(n.x12);
Assert.IsNonNegative(n.x13);
Assert.IsNonNegative(n.x14);
Assert.IsNonNegative(n.x15);
Assert.IsNonNegative(k.x0);
Assert.IsNonNegative(k.x1);
Assert.IsNonNegative(k.x2);
Assert.IsNonNegative(k.x3);
Assert.IsNonNegative(k.x4);
Assert.IsNonNegative(k.x5);
Assert.IsNonNegative(k.x6);
Assert.IsNonNegative(k.x7);
Assert.IsNonNegative(k.x8);
Assert.IsNonNegative(k.x9);
Assert.IsNonNegative(k.x10);
Assert.IsNonNegative(k.x11);
Assert.IsNonNegative(k.x12);
Assert.IsNonNegative(k.x13);
Assert.IsNonNegative(k.x14);
Assert.IsNonNegative(k.x15);

            return perm((ushort16)n, (ushort16)k, useFactorial);
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint perm(uint n, uint k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNotGreater(k, n);
            
            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U128))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
                {
                    return (uint)(factorial((ulong)n, Promise.NoOverflow) / factorial((ulong)(n - k), Promise.NoOverflow));
                }
                else
                {
                    return (uint)(factorial((UInt128)n, Promise.NoOverflow) / factorial((UInt128)(n - k), Promise.NoOverflow));
                }
            }


            if (Hint.Unlikely(k-- == 0))
            {
                return 1;
            }
            else
            {
                uint p = n--;

                while (Hint.Likely(k-- != 0))
                {
                    p *= n--;
                }

                return p;
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 perm(uint2 n, uint2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.perm_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 2));
            }
            else
            {
                return new uint2(perm(n.x, k.x, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                 perm(n.y, k.y, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 perm(uint3 n, uint3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.perm_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 3));
            }
            else
            {
                return new uint3(perm(n.x, k.x, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                 perm(n.y, k.y, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                 perm(n.z, k.z, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 perm(uint4 n, uint4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.perm_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 4));
            }
            else
            {
                return new uint4(perm(n.x, k.x, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                 perm(n.y, k.y, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                 perm(n.z, k.z, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                 perm(n.w, k.w, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 perm(uint8 n, uint8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_perm_epu32(n, k, unsafeLevels: useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new uint8(perm(n.v4_0, k.v4_0, useFactorial), perm(n.v4_4, k.v4_4, useFactorial));
            }
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint perm(int n, int k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);
            
            return perm((uint)n, (uint)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 perm(int2 n, int2 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);

            return perm((uint2)n, (uint2)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 perm(int3 n, int3 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);

            return perm((uint3)n, (uint3)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 perm(int4 n, int4 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);
Assert.IsNonNegative(k.w);
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);
Assert.IsNonNegative(n.w);

            return perm((uint4)n, (uint4)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 perm(int8 n, int8 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k.x0);
Assert.IsNonNegative(k.x1);
Assert.IsNonNegative(k.x2);
Assert.IsNonNegative(k.x3);
Assert.IsNonNegative(k.x4);
Assert.IsNonNegative(k.x5);
Assert.IsNonNegative(k.x6);
Assert.IsNonNegative(k.x7);
Assert.IsNonNegative(n.x0);
Assert.IsNonNegative(n.x1);
Assert.IsNonNegative(n.x2);
Assert.IsNonNegative(n.x3);
Assert.IsNonNegative(n.x4);
Assert.IsNonNegative(n.x5);
Assert.IsNonNegative(n.x6);
Assert.IsNonNegative(n.x7);

            return perm((uint8)n, (uint8)k, useFactorial);
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong perm(ulong n, ulong k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNotGreater(k, n);
            
            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U128))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
                {
                    return factorial(n, Promise.NoOverflow) / factorial(n - k, Promise.NoOverflow);
                }
                else
                {
                    return (ulong)(factorial((UInt128)n, Promise.NoOverflow) / factorial((UInt128)(n - k), Promise.NoOverflow));
                }
            }


            if (Hint.Unlikely(k-- == 0))
            {
                return 1;
            }
            else
            {
                ulong p = n--;

                while (Hint.Likely(k-- != 0))
                {
                    p *= n--;
                }

                return p;
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 perm(ulong2 n, ulong2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.perm_epu64(n, k, unsafeLevels: useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ulong2(perm(n.x, k.x, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                  perm(n.y, k.y, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 perm(ulong3 n, ulong3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_perm_epu64(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 3);
            }
            else
            {
                return new ulong3(perm(n.xy, k.xy, useFactorial), 
                                  perm(n.z, k.z, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 perm(ulong4 n, ulong4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_perm_epu64(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 4);
            }
            else
            {
                return new ulong4(perm(n.xy, k.xy, useFactorial), 
                                  perm(n.zw, k.zw, useFactorial));
            }
        }
        

        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong perm(long n, long k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);
            
            return perm((ulong)n, (ulong)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 perm(long2 n, long2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
            
                return Xse.perm_epu64(n, k, unsafeLevels: useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ulong2(perm(n.x, k.x, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing), 
                                  perm(n.y, k.y, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 perm(long3 n, long3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);

                return Xse.mm256_perm_epu64(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 3);
            }
            else
            {
                return new ulong3(perm(n.xy, k.xy, useFactorial), 
                                  perm(n.z, k.z, useFactorial.CountUnsafeLevels() != 0 ? Promise.Unsafe1 : Promise.Nothing));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and with order. Also known as "<paramref name="k"/>-permutations of <paramref name="n"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 perm(long4 n, long4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
Assert.IsNonNegative(k.x);
Assert.IsNonNegative(k.y);
Assert.IsNonNegative(k.z);
Assert.IsNonNegative(k.w);
Assert.IsNonNegative(n.x);
Assert.IsNonNegative(n.y);
Assert.IsNonNegative(n.z);
Assert.IsNonNegative(n.w);

                return Xse.mm256_perm_epu64(n, k, unsafeLevels: useFactorial.CountUnsafeLevels(), elements: 4);
            }
            else
            {
                return new ulong4(perm(n.xy, k.xy, useFactorial), 
                                  perm(n.zw, k.zw, useFactorial));
            }
        }
    }
}