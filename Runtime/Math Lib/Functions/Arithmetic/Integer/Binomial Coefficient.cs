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
            private static v128 naivecomb_epu8(v128 n, v128 k, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 nom = gamma_epu8(n, true, elements);
                    v128 denom = mullo_epi8(gamma_epu8(k, true, elements), gamma_epu8(Sse2.sub_epi8(n, k), true, elements), elements);
                    
                    return div_epu8(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu8(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu8(n, true);
                    v256 denom = mm256_mullo_epi8(mm256_gamma_epu8(k, true), mm256_gamma_epu8(Avx2.mm256_sub_epi8(n, k), true));
                    
                    return mm256_div_epu8(nom, denom);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naivecomb_epu16(v128 n, v128 k, bool epu8range = false, byte elements = 8)
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
                            denom = Sse2.mullo_epi16(gamma_epu16_epu8range(k), gamma_epu16_epu8range(Sse2.sub_epi16(n, k)));

                            return div_epu16(nom, denom, elements);
                        }
                    }

                    nom = gamma_epu16(n, true, elements);
                    denom = Sse2.mullo_epi16(gamma_epu16(k, true, elements), gamma_epu16(Sse2.sub_epi16(n, k), true, elements));
                    
                    return div_epu16(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu16(v256 n, v256 k, bool epu8range = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (epu8range || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8))
                    {
                        v256 nom = mm256_gamma_epu16_epu8range(n);
                        v256 denom = Avx2.mm256_mullo_epi16(mm256_gamma_epu16_epu8range(k), mm256_gamma_epu16_epu8range(Avx2.mm256_sub_epi16(n, k)));
                        
                        return mm256_div_epu16(nom, denom);
                    }
                    else
                    {
                        v256 nom = mm256_gamma_epu16(n, true);
                        v256 denom = Avx2.mm256_mullo_epi16(mm256_gamma_epu16(k, true), mm256_gamma_epu16(Avx2.mm256_sub_epi16(n, k), true));
                        
                        return mm256_div_epu16(nom, denom);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naivecomb_epu32(v128 n, v128 k, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 nom = gamma_epu32(n, true, elements);
                    v128 denom = mullo_epi32(gamma_epu32(k, true, elements), gamma_epu32(Sse2.sub_epi32(n, k), true, elements));
                    
                    return div_epu32(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu32(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu32(n, true);
                    v256 denom = Avx2.mm256_mullo_epi32(mm256_gamma_epu32(k, true), mm256_gamma_epu32(Avx2.mm256_sub_epi32(n, k), true));
                    
                    return mm256_div_epu32(nom, denom);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naivecomb_epu64(v128 n, v128 k)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 nom = gamma_epu64(n, true);
                    v128 denom = mullo_epi64(gamma_epu64(k, true), gamma_epu64(Sse2.sub_epi64(n, k), true));
                    
                    return div_epu64(nom, denom);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu64(v256 n, v256 k, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu64(n, true, elements);
                    v256 denom = mm256_mullo_epi64(mm256_gamma_epu64(k, true), mm256_gamma_epu64(Avx2.mm256_sub_epi64(n, k), true, elements));
                    
                    return mm256_div_epu64(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epu8(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 16)
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

                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU8(n, (byte)sbyte.MaxValue, elements))
                    {
                        return comb_epi8(n, k, unsafeLevels, elements);
                    }
                    else
                    {
                        if (elements <= 8)
                        {
                            return cvtepi16_epi8(comb_epi16(cvtepu8_epi16(n), cvtepu8_epi16(k), elements: elements), elements);
                        }
                        else
                        {
                            if (Avx2.IsAvx2Supported)
                            {
                                return mm256_cvtepi16_epi8(mm256_comb_epi16(Avx2.mm256_cvtepu8_epi16(n), Avx2.mm256_cvtepu8_epi16(k)));
                            }
                            else
                            {
                                v128 ONE = Sse2.set1_epi8(1);
                                
                                k = Sse2.min_epu8(k, Sse2.sub_epi8(n, k));
                                
                                v128 n2 = n;
                                n = Sse2.sub_epi8(n, ONE);
                                v128 c = Sse2.add_epi8(mullo_epi8(srli_epi8(n2, 1), n, 16), Sse2.and_si128(neg_epi8(Sse2.and_si128(n2, ONE)), srli_epi8(n, 1)));
                                v128 results = blendv_si128(blendv_si128(c, n2, Sse2.cmpeq_epi8(k, ONE)), ONE, Sse2.cmpeq_epi8(k, Sse2.setzero_si128()));
                                v128 i = Sse2.add_epi8(ONE, ONE);
                                v128 cmp = cmple_epu8(k, i);
                                
                                while (Hint.Likely(notalltrue_epi128<byte>(cmp, 16)))
                                {
                                    i = Sse2.add_epi8(i, ONE);
                                    v128 q = divrem_epu8(c, i, out v128 r);
                                    n = Sse2.sub_epi8(n, ONE);
                                    c = Sse2.add_epi8(mullo_epi8(q, n, 16), div_epu8(mullo_epi8(r, n, 16), i));
                                
                                    results = blendv_si128(c, results, cmp);
                                    cmp = cmple_epu8(k, i);
                                }
                        
                                return results;
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epu8(v256 n, v256 k, byte unsafeLevels = 0)
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

                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU8(n, (byte)sbyte.MaxValue))
                    {
                        return mm256_comb_epi8(n, k, unsafeLevels);
                    }
                    else
                    {
                        v256 ONE = Avx.mm256_set1_epi8(1);
                    
                        k = Avx2.mm256_min_epu8(k, Avx2.mm256_sub_epi8(n, k));
                    
                        v256 n2 = n;
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        v256 c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_srli_epi8(n2, 1), n), Avx2.mm256_and_si256(mm256_neg_epi8(Avx2.mm256_and_si256(n2, ONE)), mm256_srli_epi8(n, 1)));
                        v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi8(k, ONE)), ONE, Avx2.mm256_cmpeq_epi8(k, Avx.mm256_setzero_si256()));
                        v256 i = Avx2.mm256_add_epi8(ONE, ONE);
                        v256 cmp = mm256_cmple_epu8(k, i);
                    
                        while (Hint.Likely(mm256_notalltrue_epi256<byte>(cmp, 32)))
                        {
                            i = Avx2.mm256_add_epi8(i, ONE);
                            v256 q = mm256_divrem_epu8(c, i, out v256 r);
                            n = Avx2.mm256_sub_epi8(n, ONE);
                            c = Avx2.mm256_add_epi8(mm256_mullo_epi8(q, n), mm256_div_epu8(mm256_mullo_epi8(r, n), i));
                    
                            results = mm256_blendv_si256(c, results, cmp);
                            cmp = mm256_cmple_epu8(k, i);
                        }
                    
                        return results;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epi8(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.SByte0, n.SByte0);
Assert.IsNotGreater(k.SByte1, n.SByte1);
Assert.IsNonNegative(k.SByte0);                    
Assert.IsNonNegative(n.SByte0);                    
Assert.IsNonNegative(k.SByte1);
Assert.IsNonNegative(n.SByte1);                    
if (elements > 2)
{
Assert.IsNotGreater(k.SByte2, n.SByte2);             
Assert.IsNonNegative(k.SByte2);
Assert.IsNonNegative(n.SByte2);      
}
if (elements > 3)
{
Assert.IsNotGreater(k.SByte3, n.SByte3);      
Assert.IsNonNegative(k.SByte3);
Assert.IsNonNegative(n.SByte3);  
}
if (elements > 4)
{
Assert.IsNotGreater(k.SByte4, n.SByte4);
Assert.IsNotGreater(k.SByte5, n.SByte5);
Assert.IsNotGreater(k.SByte6, n.SByte6);
Assert.IsNotGreater(k.SByte7, n.SByte7);    
Assert.IsNonNegative(k.SByte4);
Assert.IsNonNegative(k.SByte5);
Assert.IsNonNegative(k.SByte6);
Assert.IsNonNegative(k.SByte7);
Assert.IsNonNegative(n.SByte4);      
Assert.IsNonNegative(n.SByte5);      
Assert.IsNonNegative(n.SByte6);      
Assert.IsNonNegative(n.SByte7);  
}
if (elements > 8)
{
Assert.IsNotGreater(k.SByte8,  n.SByte8);
Assert.IsNotGreater(k.SByte9,  n.SByte9);
Assert.IsNotGreater(k.SByte10, n.SByte10);
Assert.IsNotGreater(k.SByte11, n.SByte11);
Assert.IsNotGreater(k.SByte12, n.SByte12);
Assert.IsNotGreater(k.SByte13, n.SByte13);
Assert.IsNotGreater(k.SByte14, n.SByte14);
Assert.IsNotGreater(k.SByte15, n.SByte15);
Assert.IsNonNegative(k.SByte8);
Assert.IsNonNegative(k.SByte9);
Assert.IsNonNegative(k.SByte10);
Assert.IsNonNegative(k.SByte11);
Assert.IsNonNegative(k.SByte12);
Assert.IsNonNegative(k.SByte13);
Assert.IsNonNegative(k.SByte14);
Assert.IsNonNegative(k.SByte15);
Assert.IsNonNegative(n.SByte8);      
Assert.IsNonNegative(n.SByte9);      
Assert.IsNonNegative(n.SByte10);      
Assert.IsNonNegative(n.SByte11);
Assert.IsNonNegative(n.SByte12);      
Assert.IsNonNegative(n.SByte13);      
Assert.IsNonNegative(n.SByte14);      
Assert.IsNonNegative(n.SByte15);  
}

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U16, elements))
                            {
                                if (unsafeLevels > 3 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U8, elements))
                                {
                                    return naivecomb_epu8(n, k, elements);
                                }
                                else
                                {
                                    if (elements <= 8)
                                    {
                                        return cvtepi16_epi8(naivecomb_epu16(cvtepu8_epi16(n), cvtepu8_epi16(k), false, elements), elements);
                                    }
                                    else
                                    {
                                        if (Avx2.IsAvx2Supported)
                                        {
                                            return mm256_cvtepi16_epi8(mm256_naivecomb_epu16(Avx2.mm256_cvtepu8_epi16(n), Avx2.mm256_cvtepu8_epi16(k), false));
                                        }
                                        else
                                        {
                                            v128 nLo16 = cvt2x2epu8_epi16(n, out v128 nHi16);
                                            v128 kLo16 = cvt2x2epu8_epi16(k, out v128 kHi16);
                                            
                                            v128 resultLo = naivecomb_epu16(nLo16, kLo16, false, elements);
                                            v128 resultHi = naivecomb_epu16(nHi16, kHi16, false, elements);
                                            
                                            return cvt2x2epi16_epi8(resultLo, resultHi);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (elements <= 4)
                                {
                                    return cvtepi32_epi8(naivecomb_epu32(cvtepu8_epi32(n), cvtepu8_epi32(k), elements));
                                }
                                else
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        if (elements == 8)
                                        {
                                            return mm256_cvtepi32_epi8(mm256_naivecomb_epu32(Avx2.mm256_cvtepu8_epi32(n), Avx2.mm256_cvtepu8_epi32(k)));
                                        }
                                        else
                                        {
                                            v256 loN32 = Avx2.mm256_cvtepu8_epi32(n);
                                            v256 hiN32 = Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(n, 8 * sizeof(byte)));
                                            v256 loK32 = Avx2.mm256_cvtepu8_epi32(k);
                                            v256 hiK32 = Avx2.mm256_cvtepu8_epi32(Sse2.bsrli_si128(k, 8 * sizeof(byte)));
                    
                                            v128 resultLo = mm256_cvtepi32_epi8(mm256_naivecomb_epu32(loN32, loK32));
                                            v128 resultHi = mm256_cvtepi32_epi8(mm256_naivecomb_epu32(hiN32, hiK32));
                    
                                            return Sse2.unpacklo_epi64(resultLo, resultHi);
                                        }
                                    }
                                    else
                                    {
                                        if (elements == 8)
                                        {
                                            v128 loN32 = cvtepu8_epi32(n);
                                            v128 hiN32 = cvtepu8_epi32(Sse2.bsrli_si128(n, 4 * sizeof(byte)));
                                            v128 loK32 = cvtepu8_epi32(k);
                                            v128 hiK32 = cvtepu8_epi32(Sse2.bsrli_si128(k, 4 * sizeof(byte)));
                    
                                            v128 resultLo = naivecomb_epu32(loN32, loK32);
                                            v128 resultHi = naivecomb_epu32(hiN32, hiK32);
                    
                                            v128 result = cvt2x2epi32_epi16(resultLo, resultHi);

                                            return cvt2x2epi16_epi8(result, result);
                                        }
                                        else
                                        {
                                            v128 loN16 = cvt2x2epu8_epi16(n, out v128 hiN16);
                                            v128 loK16 = cvt2x2epu8_epi16(k, out v128 hiK16);
                    
                                            v128 n32_0 = cvt2x2epu16_epi32(loN16, out v128 n32_1);
                                            v128 n32_2 = cvt2x2epu16_epi32(hiN16, out v128 n32_3);
                                            v128 k32_0 = cvt2x2epu16_epi32(loK16, out v128 k32_1);
                                            v128 k32_2 = cvt2x2epu16_epi32(hiK16, out v128 k32_3);
                    
                                            v128 result32_0 = naivecomb_epu32(n32_0, k32_0);
                                            v128 result32_1 = naivecomb_epu32(n32_1, k32_1);
                                            v128 result32_2 = naivecomb_epu32(n32_2, k32_2);
                                            v128 result32_3 = naivecomb_epu32(n32_3, k32_3);
                    
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
                                    return Sse2.unpacklo_epi8(Sse2.cvtsi64x_si128((long)maxmath.comb((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), maxmath.Promise.Unsafe0)),
                                                              Sse2.cvtsi64x_si128((long)maxmath.comb((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), maxmath.Promise.Unsafe0)));
                                }
                    
                                case 3:
                                case 4:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi64_epi8(mm256_naivecomb_epu64(Avx2.mm256_cvtepu8_epi64(n), Avx2.mm256_cvtepu8_epi64(k), elements));
                                    }
                                    else
                                    {
                                        return new v128((byte)maxmath.comb((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 2), (ulong)extract_epi8(k, 2), maxmath.Promise.Unsafe0),
                                                        (byte)(elements == 4 ? maxmath.comb((ulong)extract_epi8(n, 3), (ulong)extract_epi8(k, 3), maxmath.Promise.Unsafe0) : 0),
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
                                        v256 n64Lo = Avx2.mm256_cvtepu8_epi64(n);
                                        v256 k64Lo = Avx2.mm256_cvtepu8_epi64(k);
                                        v256 n64Hi = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(n, 4 * sizeof(byte)));
                                        v256 k64Hi = Avx2.mm256_cvtepu8_epi64(Sse2.bsrli_si128(k, 4 * sizeof(byte)));

                                        v128 lo = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n64Lo, k64Lo));
                                        v128 hi = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n64Hi, k64Hi));
                    
                                        return Sse2.unpacklo_epi32(lo, hi);
                                    }
                                    else
                                    {
                                        return new v128((byte)maxmath.comb((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 2), (ulong)extract_epi8(k, 2), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 3), (ulong)extract_epi8(k, 3), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 4), (ulong)extract_epi8(k, 4), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 5), (ulong)extract_epi8(k, 5), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 6), (ulong)extract_epi8(k, 6), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 7), (ulong)extract_epi8(k, 7), maxmath.Promise.Unsafe0),
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
                    
                                        v128 result0 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n0, k0));
                                        v128 result1 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n1, k1));
                                        v128 result2 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n2, k2));
                                        v128 result3 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n3, k3));
                    
                                        return Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(result0, result1), Sse2.unpacklo_epi32(result2, result3));
                                    }
                                    else
                                    {
                                        return new v128((byte)maxmath.comb((ulong)extract_epi8(n, 0),  (ulong)extract_epi8(k, 0),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 1),  (ulong)extract_epi8(k, 1),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 2),  (ulong)extract_epi8(k, 2),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 3),  (ulong)extract_epi8(k, 3),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 4),  (ulong)extract_epi8(k, 4),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 5),  (ulong)extract_epi8(k, 5),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 6),  (ulong)extract_epi8(k, 6),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 7),  (ulong)extract_epi8(k, 7),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 8),  (ulong)extract_epi8(k, 8),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 9),  (ulong)extract_epi8(k, 9),  maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 10), (ulong)extract_epi8(k, 10), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 11), (ulong)extract_epi8(k, 11), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 12), (ulong)extract_epi8(k, 12), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 13), (ulong)extract_epi8(k, 13), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 14), (ulong)extract_epi8(k, 14), maxmath.Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 15), (ulong)extract_epi8(k, 15), maxmath.Promise.Unsafe0));
                                    }
                                }
                            }
                        }
                    }


                    if (elements <= 8)
                    {
                        return cvtepi16_epi8(comb_epi16(cvtepu8_epi16(n), cvtepu8_epi16(k), elements: elements), elements);
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            return mm256_cvtepi16_epi8(mm256_comb_epi16(Avx2.mm256_cvtepu8_epi16(n), Avx2.mm256_cvtepu8_epi16(k)));
                        }
                        else
                        {
                            v128 ONE = Sse2.set1_epi8(1);

                            k = Sse2.min_epu8(k, Sse2.sub_epi8(n, k));

                            v128 n2 = n;
                            n = Sse2.sub_epi8(n, ONE);
                            v128 c = Sse2.add_epi8(mullo_epi8(srli_epi8(n2, 1), n, 16), Sse2.and_si128(neg_epi8(Sse2.and_si128(n2, ONE)), srli_epi8(n, 1)));
                            v128 results = blendv_si128(blendv_si128(c, n2, Sse2.cmpeq_epi8(k, ONE)), ONE, Sse2.cmpeq_epi8(k, Sse2.setzero_si128()));
                            v128 i = Sse2.add_epi8(ONE, ONE);
                            v128 cmp = Sse2.cmpgt_epi8(k, i);

                            while (Hint.Likely(notallfalse_epi128<byte>(cmp, 16)))
                            {
                                i = Sse2.add_epi8(i, ONE);
                                v128 q = divrem_epu8(c, i, out v128 r);
                                n = Sse2.sub_epi8(n, ONE);
                                c = Sse2.add_epi8(mullo_epi8(q, n, 16), div_epu8(mullo_epi8(r, n, 16), i));

                                results = blendv_si128(results, c, cmp);
                                cmp = Sse2.cmpgt_epi8(k, i);
                            }

                            return results;
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epi8(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.SByte0,  n.SByte0);
Assert.IsNotGreater(k.SByte1,  n.SByte1);
Assert.IsNotGreater(k.SByte2,  n.SByte2);
Assert.IsNotGreater(k.SByte3,  n.SByte3);
Assert.IsNotGreater(k.SByte4,  n.SByte4);
Assert.IsNotGreater(k.SByte5,  n.SByte5);
Assert.IsNotGreater(k.SByte6,  n.SByte6);
Assert.IsNotGreater(k.SByte7,  n.SByte7);
Assert.IsNotGreater(k.SByte8,  n.SByte8);
Assert.IsNotGreater(k.SByte9,  n.SByte9);
Assert.IsNotGreater(k.SByte10, n.SByte10);
Assert.IsNotGreater(k.SByte11, n.SByte11);
Assert.IsNotGreater(k.SByte12, n.SByte12);
Assert.IsNotGreater(k.SByte13, n.SByte13);
Assert.IsNotGreater(k.SByte14, n.SByte14);
Assert.IsNotGreater(k.SByte15, n.SByte15);
Assert.IsNotGreater(k.SByte16, n.SByte16);
Assert.IsNotGreater(k.SByte17, n.SByte17);
Assert.IsNotGreater(k.SByte18, n.SByte18);
Assert.IsNotGreater(k.SByte19, n.SByte19);
Assert.IsNotGreater(k.SByte20, n.SByte20);
Assert.IsNotGreater(k.SByte21, n.SByte21);
Assert.IsNotGreater(k.SByte22, n.SByte22);
Assert.IsNotGreater(k.SByte23, n.SByte23);
Assert.IsNotGreater(k.SByte24, n.SByte24);
Assert.IsNotGreater(k.SByte25, n.SByte25);
Assert.IsNotGreater(k.SByte26, n.SByte26);
Assert.IsNotGreater(k.SByte27, n.SByte27);
Assert.IsNotGreater(k.SByte28, n.SByte28);
Assert.IsNotGreater(k.SByte29, n.SByte29);
Assert.IsNotGreater(k.SByte30, n.SByte30);
Assert.IsNotGreater(k.SByte31, n.SByte31);
Assert.IsNonNegative(k.SByte0);
Assert.IsNonNegative(k.SByte1);
Assert.IsNonNegative(k.SByte2);
Assert.IsNonNegative(k.SByte3);
Assert.IsNonNegative(k.SByte4);
Assert.IsNonNegative(k.SByte5);
Assert.IsNonNegative(k.SByte6);
Assert.IsNonNegative(k.SByte7);
Assert.IsNonNegative(k.SByte8);
Assert.IsNonNegative(k.SByte9);
Assert.IsNonNegative(k.SByte10);
Assert.IsNonNegative(k.SByte11);
Assert.IsNonNegative(k.SByte12);
Assert.IsNonNegative(k.SByte13);
Assert.IsNonNegative(k.SByte14);
Assert.IsNonNegative(k.SByte15);
Assert.IsNonNegative(k.SByte16);
Assert.IsNonNegative(k.SByte17);
Assert.IsNonNegative(k.SByte18);
Assert.IsNonNegative(k.SByte19);
Assert.IsNonNegative(k.SByte20);
Assert.IsNonNegative(k.SByte21);
Assert.IsNonNegative(k.SByte22);
Assert.IsNonNegative(k.SByte23);
Assert.IsNonNegative(k.SByte24);
Assert.IsNonNegative(k.SByte25);
Assert.IsNonNegative(k.SByte26);
Assert.IsNonNegative(k.SByte27);
Assert.IsNonNegative(k.SByte28);
Assert.IsNonNegative(k.SByte29);
Assert.IsNonNegative(k.SByte30);
Assert.IsNonNegative(k.SByte31);
Assert.IsNonNegative(n.SByte0);
Assert.IsNonNegative(n.SByte1);
Assert.IsNonNegative(n.SByte2);
Assert.IsNonNegative(n.SByte3);
Assert.IsNonNegative(n.SByte4);
Assert.IsNonNegative(n.SByte5);
Assert.IsNonNegative(n.SByte6);
Assert.IsNonNegative(n.SByte7);
Assert.IsNonNegative(n.SByte8);
Assert.IsNonNegative(n.SByte9);
Assert.IsNonNegative(n.SByte10);
Assert.IsNonNegative(n.SByte11);
Assert.IsNonNegative(n.SByte12);
Assert.IsNonNegative(n.SByte13);
Assert.IsNonNegative(n.SByte14);
Assert.IsNonNegative(n.SByte15);
Assert.IsNonNegative(n.SByte16);
Assert.IsNonNegative(n.SByte17);
Assert.IsNonNegative(n.SByte18);
Assert.IsNonNegative(n.SByte19);
Assert.IsNonNegative(n.SByte20);
Assert.IsNonNegative(n.SByte21);
Assert.IsNonNegative(n.SByte22);
Assert.IsNonNegative(n.SByte23);
Assert.IsNonNegative(n.SByte24);
Assert.IsNonNegative(n.SByte25);
Assert.IsNonNegative(n.SByte26);
Assert.IsNonNegative(n.SByte27);
Assert.IsNonNegative(n.SByte28);
Assert.IsNonNegative(n.SByte29);
Assert.IsNonNegative(n.SByte30);
Assert.IsNonNegative(n.SByte31);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U16))
                            {
                                if (unsafeLevels > 3 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U8))
                                {
                                    return mm256_naivecomb_epu8(n, k);
                                }
                                else
                                {
                                    v256 nLo16 = mm256_cvt2x2epu8_epi16(n, out v256 nHi16);
                                    v256 kLo16 = mm256_cvt2x2epu8_epi16(k, out v256 kHi16);
                            
                                    return mm256_cvt2x2epi16_epi8(mm256_naivecomb_epu16(nLo16, kLo16), mm256_naivecomb_epu16(nHi16, kHi16));
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
                                
                                v256 result32_0 = mm256_naivecomb_epu32(n32_0, k32_0);
                                v256 result32_1 = mm256_naivecomb_epu32(n32_1, k32_1);
                                v256 result32_2 = mm256_naivecomb_epu32(n32_2, k32_2);
                                v256 result32_3 = mm256_naivecomb_epu32(n32_3, k32_3);
                                
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
                            
                            v256 result64_0 = mm256_naivecomb_epu64(n64_0, k64_0);
                            v256 result64_1 = mm256_naivecomb_epu64(n64_1, k64_1);
                            v256 result64_2 = mm256_naivecomb_epu64(n64_2, k64_2);
                            v256 result64_3 = mm256_naivecomb_epu64(n64_3, k64_3);
                            v256 result64_4 = mm256_naivecomb_epu64(n64_4, k64_4);
                            v256 result64_5 = mm256_naivecomb_epu64(n64_5, k64_5);
                            v256 result64_6 = mm256_naivecomb_epu64(n64_6, k64_6);
                            v256 result64_7 = mm256_naivecomb_epu64(n64_7, k64_7);
                            
                            v256 result32_0 = mm256_cvt2x2epi64_epi32(result64_0, result64_1);
                            v256 result32_1 = mm256_cvt2x2epi64_epi32(result64_2, result64_3);
                            v256 result32_2 = mm256_cvt2x2epi64_epi32(result64_4, result64_5);
                            v256 result32_3 = mm256_cvt2x2epi64_epi32(result64_6, result64_7);
                            
                            v256 result16_0 = mm256_cvt2x2epi32_epi16(result32_0, result32_1);
                            v256 result16_1 = mm256_cvt2x2epi32_epi16(result32_2, result32_3);
                            
                            return mm256_cvt2x2epi16_epi8(result16_0, result16_1);
                        }
                    }


                    v256 ONE = Avx.mm256_set1_epi8(1);
                    
                    k = Avx2.mm256_min_epu8(k, Avx2.mm256_sub_epi8(n, k));
                    
                    v256 n2 = n;
                    n = Avx2.mm256_sub_epi8(n, ONE);
                    v256 c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_srli_epi8(n2, 1), n), Avx2.mm256_and_si256(mm256_neg_epi8(Avx2.mm256_and_si256(n2, ONE)), mm256_srli_epi8(n, 1)));
                    v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi8(k, ONE)), ONE, Avx2.mm256_cmpeq_epi8(k, Avx.mm256_setzero_si256()));
                    v256 i = Avx2.mm256_add_epi8(ONE, ONE);
                    v256 cmp = Avx2.mm256_cmpgt_epi8(k, i);
                    
                    while (Hint.Likely(mm256_notallfalse_epi256<byte>(cmp, 32)))
                    {
                        i = Avx2.mm256_add_epi8(i, ONE);
                        v256 q = mm256_divrem_epu8(c, i, out v256 r);
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        c = Avx2.mm256_add_epi8(mm256_mullo_epi8(q, n), mm256_div_epu8(mm256_mullo_epi8(r, n), i));
                    
                        results = mm256_blendv_si256(results, c, cmp);
                        cmp = Avx2.mm256_cmpgt_epi8(k, i);
                    }
                    
                    return results;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epu16(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 8)
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

                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU16(n, (ushort)short.MaxValue, elements))
                    {
                        return comb_epi16(n, k, unsafeLevels, elements);
                    }
                    else
                    {
                        v128 ONE = Sse2.set1_epi16(1);
                        
                        k = min_epu16(k, Sse2.sub_epi16(n, k));
                        
                        v128 n2 = n;
                        n = Sse2.sub_epi16(n, ONE);
                        v128 c = Sse2.add_epi16(Sse2.mullo_epi16(Sse2.srli_epi16(n2, 1), n), Sse2.and_si128(neg_epi16(Sse2.and_si128(n2, ONE)), Sse2.srli_epi16(n, 1)));
                        v128 results = blendv_si128(blendv_si128(c, n2, Sse2.cmpeq_epi16(k, ONE)), ONE, Sse2.cmpeq_epi16(k, Sse2.setzero_si128()));
                        v128 i = Sse2.add_epi16(ONE, ONE);

                        if (Sse4_1.IsSse41Supported)
                        {
                            v128 cmp = cmple_epu16(k, i);
                            while (Hint.Likely(notalltrue_epi128<ushort>(cmp, 8)))
                            {
                                i = Sse2.add_epi16(i, ONE);
                                v128 q = divrem_epu16(c, i, out v128 r);
                                n = Sse2.sub_epi16(n, ONE);
                                c = Sse2.add_epi16(Sse2.mullo_epi16(q, n), div_epu16(Sse2.mullo_epi16(r, n), i));
                            
                                results = blendv_si128(c, results, cmp);
                                cmp = cmple_epu16(k, i);
                            }
                        }
                        else
                        {
                            v128 cmp = cmpgt_epu16(k, i);
                            while (Hint.Likely(notallfalse_epi128<ushort>(cmp, 8)))
                            {
                                i = Sse2.add_epi16(i, ONE);
                                v128 q = divrem_epu16(c, i, out v128 r);
                                n = Sse2.sub_epi16(n, ONE);
                                c = Sse2.add_epi16(Sse2.mullo_epi16(q, n), div_epu16(Sse2.mullo_epi16(r, n), i));
                            
                                results = blendv_si128(results, c, cmp);
                                cmp = cmpgt_epu16(k, i);
                            }
                        }
                        
                        
                        return results;
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epu16(v256 n, v256 k, byte unsafeLevels = 0)
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

                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU16(n, (ushort)short.MaxValue))
                    {
                        return mm256_comb_epi16(n, k, unsafeLevels);
                    }
                    else
                    {
                        v256 ONE = Avx.mm256_set1_epi16(1);
                    
                        k = Avx2.mm256_min_epu16(k, Avx2.mm256_sub_epi16(n, k));
                    
                        v256 n2 = n;
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        v256 c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_srli_epi16(n2, 1), n), Avx2.mm256_and_si256(mm256_neg_epi16(Avx2.mm256_and_si256(n2, ONE)), Avx2.mm256_srli_epi16(n, 1)));
                        v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi16(k, ONE)), ONE, Avx2.mm256_cmpeq_epi16(k, Avx.mm256_setzero_si256()));
                        v256 i = Avx2.mm256_add_epi16(ONE, ONE);
                        v256 cmp = mm256_cmple_epu16(k, i);
                    
                        while (Hint.Likely(mm256_notalltrue_epi256<ushort>(cmp, 16)))
                        {
                            i = Avx2.mm256_add_epi16(i, ONE);
                            v256 q = mm256_divrem_epu16(c, i, out v256 r);
                            n = Avx2.mm256_sub_epi16(n, ONE);
                            c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(q, n), mm256_div_epu16(Avx2.mm256_mullo_epi16(r, n), i));
                    
                            results = mm256_blendv_si256(c, results, cmp);
                            cmp = mm256_cmple_epu16(k, i);
                        }
                    
                        return results;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epi16(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.SShort0, n.SShort0);
Assert.IsNotGreater(k.SShort1, n.SShort1);
Assert.IsNonNegative(k.SShort0);                    
Assert.IsNonNegative(n.SShort0);                    
Assert.IsNonNegative(k.SShort1);
Assert.IsNonNegative(n.SShort1);                    
if (elements > 2)
{
Assert.IsNotGreater(k.SShort2, n.SShort2);             
Assert.IsNonNegative(k.SShort2);
Assert.IsNonNegative(n.SShort2);      
}
if (elements > 3)
{
Assert.IsNotGreater(k.SShort3, n.SShort3);      
Assert.IsNonNegative(k.SShort3);
Assert.IsNonNegative(n.SShort3);  
}
if (elements > 4)
{
Assert.IsNotGreater(k.SShort4, n.SShort4);
Assert.IsNotGreater(k.SShort5, n.SShort5);
Assert.IsNotGreater(k.SShort6, n.SShort6);
Assert.IsNotGreater(k.SShort7, n.SShort7);    
Assert.IsNonNegative(k.SShort4);
Assert.IsNonNegative(k.SShort5);
Assert.IsNonNegative(k.SShort6);
Assert.IsNonNegative(k.SShort7);
Assert.IsNonNegative(n.SShort4);      
Assert.IsNonNegative(n.SShort5);      
Assert.IsNonNegative(n.SShort6);      
Assert.IsNonNegative(n.SShort7);  
}

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U16, elements))
                            {
                                return naivecomb_epu16(n, k, unsafeLevels > 3 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8, elements), elements);
                            }
                            else
                            {
                                if (elements <= 4)
                                {
                                    return cvtepi32_epi16(naivecomb_epu32(cvtepu16_epi32(n), cvtepu16_epi32(k), elements), elements);
                                }
                                else
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi32_epi16(mm256_naivecomb_epu32(Avx2.mm256_cvtepu16_epi32(n), Avx2.mm256_cvtepu16_epi32(k)));
                                    }
                                    else
                                    {
                                        v128 nLo32 = cvt2x2epu16_epi32(n, out v128 nHi32);
                                        v128 kLo32 = cvt2x2epu16_epi32(k, out v128 kHi32);

                                        return cvt2x2epi32_epi16(naivecomb_epu32(nLo32, kLo32), naivecomb_epu32(nHi32, kHi32));
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
                                    return Sse2.unpacklo_epi16(Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), maxmath.Promise.Unsafe0)),
                                                               Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), maxmath.Promise.Unsafe0)));
                                }

                                case 3:
                                case 4:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi64_epi16(mm256_naivecomb_epu64(Avx2.mm256_cvtepu16_epi64(n), Avx2.mm256_cvtepu16_epi64(k), elements));
                                    }
                                    else
                                    {
                                        return new v128((ushort)maxmath.comb((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 2), (ulong)extract_epi16(k, 2), maxmath.Promise.Unsafe0),
                                                        (ushort)(elements == 4 ? maxmath.comb((ulong)extract_epi16(n, 3), (ulong)extract_epi16(k, 3), maxmath.Promise.Unsafe0) : 0),
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

                                        v128 result64Lo = mm256_cvtepi64_epi16(mm256_naivecomb_epu64(n64Lo, k64Lo));
                                        v128 result64Hi = mm256_cvtepi64_epi16(mm256_naivecomb_epu64(n64Hi, k64Hi));

                                        return Sse2.unpacklo_epi64(result64Lo, result64Hi);
                                    }
                                    else
                                    {
                                        return new v128((ushort)maxmath.comb((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 2), (ulong)extract_epi16(k, 2), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 3), (ulong)extract_epi16(k, 3), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 4), (ulong)extract_epi16(k, 4), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 5), (ulong)extract_epi16(k, 5), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 6), (ulong)extract_epi16(k, 6), maxmath.Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 7), (ulong)extract_epi16(k, 7), maxmath.Promise.Unsafe0));
                                    }
                                }
                            }
                        }
                    }

                    
                    v128 ONE = Sse2.set1_epi16(1);
                    
                    k = Sse2.min_epi16(k, Sse2.sub_epi16(n, k));
                    
                    v128 n2 = n;
                    n = Sse2.sub_epi16(n, ONE);
                    v128 c = Sse2.add_epi16(Sse2.mullo_epi16(Sse2.srli_epi16(n2, 1), n), Sse2.and_si128(neg_epi16(Sse2.and_si128(n2, ONE)), Sse2.srli_epi16(n, 1)));
                    v128 results = blendv_si128(blendv_si128(c, n2, Sse2.cmpeq_epi16(k, ONE)), ONE, Sse2.cmpeq_epi16(k, Sse2.setzero_si128()));
                    v128 i = Sse2.add_epi16(ONE, ONE);
                    v128 cmp = Sse2.cmpgt_epi16(k, i);
                    
                    while (Hint.Likely(notallfalse_epi128<ushort>(cmp, elements)))
                    {
                        i = Sse2.add_epi16(i, ONE);
                        v128 q = divrem_epu16(c, i, out v128 r, elements);
                        n = Sse2.sub_epi16(n, ONE);
                        c = Sse2.add_epi16(Sse2.mullo_epi16(q, n), div_epu16(Sse2.mullo_epi16(r, n), i, elements));
                    
                        results = blendv_si128(results, c, cmp);
                        cmp = Sse2.cmpgt_epi16(k, i);
                    }
                    
                    return results;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epi16(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.SShort0,  n.SShort0);
Assert.IsNotGreater(k.SShort1,  n.SShort1);
Assert.IsNotGreater(k.SShort2,  n.SShort2);
Assert.IsNotGreater(k.SShort3,  n.SShort3);
Assert.IsNotGreater(k.SShort4,  n.SShort4);
Assert.IsNotGreater(k.SShort5,  n.SShort5);
Assert.IsNotGreater(k.SShort6,  n.SShort6);
Assert.IsNotGreater(k.SShort7,  n.SShort7);
Assert.IsNotGreater(k.SShort8,  n.SShort8);
Assert.IsNotGreater(k.SShort9,  n.SShort9);
Assert.IsNotGreater(k.SShort10, n.SShort10);
Assert.IsNotGreater(k.SShort11, n.SShort11);
Assert.IsNotGreater(k.SShort12, n.SShort12);
Assert.IsNotGreater(k.SShort13, n.SShort13);
Assert.IsNotGreater(k.SShort14, n.SShort14);
Assert.IsNotGreater(k.SShort15, n.SShort15);
Assert.IsNonNegative(k.SShort0);
Assert.IsNonNegative(k.SShort1);
Assert.IsNonNegative(k.SShort2);
Assert.IsNonNegative(k.SShort3);
Assert.IsNonNegative(k.SShort4);
Assert.IsNonNegative(k.SShort5);
Assert.IsNonNegative(k.SShort6);
Assert.IsNonNegative(k.SShort7);
Assert.IsNonNegative(k.SShort8);
Assert.IsNonNegative(k.SShort9);
Assert.IsNonNegative(k.SShort10);
Assert.IsNonNegative(k.SShort11);
Assert.IsNonNegative(k.SShort12);
Assert.IsNonNegative(k.SShort13);
Assert.IsNonNegative(k.SShort14);
Assert.IsNonNegative(k.SShort15);
Assert.IsNonNegative(n.SShort0);
Assert.IsNonNegative(n.SShort1);
Assert.IsNonNegative(n.SShort2);
Assert.IsNonNegative(n.SShort3);
Assert.IsNonNegative(n.SShort4);
Assert.IsNonNegative(n.SShort5);
Assert.IsNonNegative(n.SShort6);
Assert.IsNonNegative(n.SShort7);
Assert.IsNonNegative(n.SShort8);
Assert.IsNonNegative(n.SShort9);
Assert.IsNonNegative(n.SShort10);
Assert.IsNonNegative(n.SShort11);
Assert.IsNonNegative(n.SShort12);
Assert.IsNonNegative(n.SShort13);
Assert.IsNonNegative(n.SShort14);
Assert.IsNonNegative(n.SShort15);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U16))
                            {
                                return mm256_naivecomb_epu16(n, k, unsafeLevels > 3 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8));
                            }
                            else
                            {
                                v256 nLo32 = mm256_cvt2x2epu16_epi32(n, out v256 nHi32);
                                v256 kLo32 = mm256_cvt2x2epu16_epi32(k, out v256 kHi32);

                                v256 resultLo = mm256_naivecomb_epu32(nLo32, kLo32);
                                v256 resultHi = mm256_naivecomb_epu32(nHi32, kHi32);
                        
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

                            v256 resultLoLo = mm256_naivecomb_epu64(n64LoLo, k64LoLo);
                            v256 resultLoHi = mm256_naivecomb_epu64(n64LoHi, k64LoHi);
                            v256 resultHiLo = mm256_naivecomb_epu64(n64HiLo, k64HiLo);
                            v256 resultHiHi = mm256_naivecomb_epu64(n64HiHi, k64HiHi);

                            v256 result32Lo = mm256_cvt2x2epi64_epi32(resultLoLo, resultLoHi);
                            v256 result32Hi = mm256_cvt2x2epi64_epi32(resultHiLo, resultHiHi);

                            return mm256_cvt2x2epi32_epi16(result32Lo, result32Hi);
                        }
                    }


                    v256 ONE = Avx.mm256_set1_epi16(1);
                    
                    k = Avx2.mm256_min_epu16(k, Avx2.mm256_sub_epi16(n, k));
                    
                    v256 n2 = n;
                    n = Avx2.mm256_sub_epi16(n, ONE);
                    v256 c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_srli_epi16(n2, 1), n), Avx2.mm256_and_si256(mm256_neg_epi16(Avx2.mm256_and_si256(n2, ONE)), Avx2.mm256_srli_epi16(n, 1)));
                    v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi16(k, ONE)), ONE, Avx2.mm256_cmpeq_epi16(k, Avx.mm256_setzero_si256()));
                    v256 i = Avx2.mm256_add_epi16(ONE, ONE);
                    v256 cmp = Avx2.mm256_cmpgt_epi16(k, i);
                    
                    while (Hint.Likely(mm256_notallfalse_epi256<ushort>(cmp, 16)))
                    {
                        i = Avx2.mm256_add_epi16(i, ONE);
                        v256 q = mm256_divrem_epu16(c, i, out v256 r);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(q, n), mm256_div_epu16(Avx2.mm256_mullo_epi16(r, n), i));
                    
                        results = mm256_blendv_si256(results, c, cmp);
                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                    }
                    
                    return results;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epi32(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.SInt0, n.SInt0);
Assert.IsNotGreater(k.SInt1, n.SInt1);
Assert.IsNonNegative(k.SInt0);
Assert.IsNonNegative(k.SInt1);
Assert.IsNonNegative(n.SInt0);
Assert.IsNonNegative(n.SInt1);
if (elements > 2)
{
Assert.IsNotGreater(k.SInt2, n.SInt2);
Assert.IsNonNegative(k.SInt2);
Assert.IsNonNegative(n.SInt2);
}
if (elements > 3)
{
Assert.IsNotGreater(k.SInt3, n.SInt3);
Assert.IsNonNegative(k.SInt3);
Assert.IsNonNegative(n.SInt3);
}
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            return naivecomb_epu32(n, k, elements);
                        }
                        else
                        {
                            if (elements > 2)
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    return mm256_cvtepi64_epi32(mm256_naivecomb_epu64(Avx2.mm256_cvtepu32_epi64(n), Avx2.mm256_cvtepu32_epi64(k), elements));
                                }
                                else
                                {
                                    v128 lo = Sse2.unpacklo_epi32(Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 0), (ulong)extract_epi32(k, 0), maxmath.Promise.Unsafe0)),
                                                                  Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 1), (ulong)extract_epi32(k, 1), maxmath.Promise.Unsafe0)));
                                    v128 hi = Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 2), (ulong)extract_epi32(k, 2), maxmath.Promise.Unsafe0));

                                    if (elements == 4)
                                    {
                                        hi = Sse2.unpacklo_epi32(hi, Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 3), (ulong)extract_epi32(k, 3), maxmath.Promise.Unsafe0)));
                                    }

                                    return Sse2.unpacklo_epi64(lo, hi);
                                }
                            }
                            else
                            {
                                return Sse2.unpacklo_epi32(Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 0), (ulong)extract_epi32(k, 0), maxmath.Promise.Unsafe0)),
                                                           Sse2.cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 1), (ulong)extract_epi32(k, 1), maxmath.Promise.Unsafe0)));
                            }
                        }
                    }


                    v128 ONE = Sse2.set1_epi32(1);

                    k = min_epi32(k, Sse2.sub_epi32(n, k));

                    v128 n2 = n;
                    n = Sse2.sub_epi32(n, ONE);
                    v128 c = Sse2.add_epi32(mullo_epi32(Sse2.srli_epi32(n2, 1), n, elements), Sse2.and_si128(neg_epi32(Sse2.and_si128(n2, ONE)), Sse2.srli_epi32(n, 1)));
                    v128 results = blendv_si128(blendv_si128(c, n2, Sse2.cmpeq_epi32(k, ONE)), ONE, Sse2.cmpeq_epi32(k, Sse2.setzero_si128()));
                    v128 i = Sse2.add_epi32(ONE, ONE);
                    v128 cmp = Sse2.cmpgt_epi32(k, i);

                    while (Hint.Likely(notallfalse_epi128<uint>(cmp, elements)))
                    {
                        i = Sse2.add_epi32(i, ONE);
                        v128 q = divrem_epu32(c, i, out v128 r, elements);
                        n = Sse2.sub_epi32(n, ONE);
                        c = Sse2.add_epi32(mullo_epi32(q, n, elements), div_epu32(mullo_epi32(r, n, elements), i, elements));

                        results = blendv_si128(results, c, cmp);
                        cmp = Sse2.cmpgt_epi32(k, i);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epi32(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.SInt0, n.SInt0);
Assert.IsNotGreater(k.SInt1, n.SInt1);
Assert.IsNotGreater(k.SInt2, n.SInt2);
Assert.IsNotGreater(k.SInt3, n.SInt3);
Assert.IsNotGreater(k.SInt4, n.SInt4);
Assert.IsNotGreater(k.SInt5, n.SInt5);
Assert.IsNotGreater(k.SInt6, n.SInt6);
Assert.IsNotGreater(k.SInt7, n.SInt7);
Assert.IsNonNegative(k.SInt0);
Assert.IsNonNegative(k.SInt1);
Assert.IsNonNegative(k.SInt2);
Assert.IsNonNegative(k.SInt3);
Assert.IsNonNegative(k.SInt4);
Assert.IsNonNegative(k.SInt5);
Assert.IsNonNegative(k.SInt6);
Assert.IsNonNegative(k.SInt7);
Assert.IsNonNegative(n.SInt0);
Assert.IsNonNegative(n.SInt1);
Assert.IsNonNegative(n.SInt2);
Assert.IsNonNegative(n.SInt3);
Assert.IsNonNegative(n.SInt4);
Assert.IsNonNegative(n.SInt5);
Assert.IsNonNegative(n.SInt6);
Assert.IsNonNegative(n.SInt7);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            return mm256_naivecomb_epu32(n, k);
                        }
                        else
                        {
                            v256 n64Lo = mm256_cvt2x2epu32_epi64(n, out v256 n64Hi);
                            v256 k64Lo = mm256_cvt2x2epu32_epi64(k, out v256 k64Hi);
                            
                            v256 resultLo = mm256_naivecomb_epu64(n64Lo, k64Lo);
                            v256 resultHi = mm256_naivecomb_epu64(n64Hi, k64Hi);
                            
                            return mm256_cvt2x2epi64_epi32(resultLo, resultHi);
                        }
                    }


                    v256 ONE = Avx.mm256_set1_epi32(1);

                    k = Avx2.mm256_min_epi32(k, Avx2.mm256_sub_epi32(n, k));

                    v256 n2 = n;
                    n = Avx2.mm256_sub_epi32(n, ONE);
                    v256 c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_srli_epi32(n2, 1), n), Avx2.mm256_and_si256(mm256_neg_epi32(Avx2.mm256_and_si256(n2, ONE)), Avx2.mm256_srli_epi32(n, 1)));
                    v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi32(k, ONE)), ONE, Avx2.mm256_cmpeq_epi32(k, Avx.mm256_setzero_si256()));
                    v256 i = Avx2.mm256_add_epi32(ONE, ONE);
                    v256 cmp = Avx2.mm256_cmpgt_epi32(k, i);

                    while (Hint.Likely(mm256_notallfalse_epi256<uint>(cmp, 8)))
                    {
                        i = Avx2.mm256_add_epi32(i, ONE);
                        v256 q = mm256_divrem_epu32(c, i, out v256 r);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(q, n), mm256_div_epu32(Avx2.mm256_mullo_epi32(r, n), i));

                        results = mm256_blendv_si256(results, c, cmp);
                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epu32(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 4)
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

                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU32(n, int.MaxValue))
                    {
                        return comb_epi32(n, k, unsafeLevels, elements);
                    }
                    else
                    {
                        v128 ONE = Sse2.set1_epi32(1);

                        k = min_epu32(k, Sse2.sub_epi32(n, k));

                        v128 n2 = n;
                        n = Sse2.sub_epi32(n, ONE);
                        v128 c = Sse2.add_epi32(mullo_epi32(Sse2.srli_epi32(n2, 1), n, elements), Sse2.and_si128(neg_epi32(Sse2.and_si128(n2, ONE)), Sse2.srli_epi32(n, 1)));
                        v128 results = blendv_si128(blendv_si128(c, n2, Sse2.cmpeq_epi32(k, ONE)), ONE, Sse2.cmpeq_epi32(k, Sse2.setzero_si128()));
                        v128 i = Sse2.add_epi32(ONE, ONE);

                        if (Sse4_1.IsSse41Supported)
                        {
                            v128 cmp = cmple_epu32(k, i, elements);
                            while (Hint.Likely(notalltrue_epi128<uint>(cmp, elements)))
                            {
                                i = Sse2.add_epi32(i, ONE);
                                v128 q = divrem_epu32(c, i, out v128 r);
                                n = Sse2.sub_epi32(n, ONE);
                                c = Sse2.add_epi32(mullo_epi32(q, n, elements), div_epu32(mullo_epi32(r, n, elements), i, elements));

                                results = blendv_si128(c, results, cmp);
                                cmp = cmple_epu32(k, i, elements);
                            }
                        }
                        else
                        {
                            v128 cmp = cmpgt_epu32(k, i, elements);
                            while (Hint.Likely(notallfalse_epi128<uint>(cmp, elements)))
                            {
                                i = Sse2.add_epi32(i, ONE);
                                v128 q = divrem_epu32(c, i, out v128 r);
                                n = Sse2.sub_epi32(n, ONE);
                                c = Sse2.add_epi32(mullo_epi32(q, n, elements), div_epu32(mullo_epi32(r, n, elements), i, elements));

                                results = blendv_si128(results, c, cmp);
                                cmp = cmpgt_epu32(k, i, elements);
                            }
                        }

                        return results;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epu32(v256 n, v256 k, byte unsafeLevels = 0)
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

                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU32(n, int.MaxValue))
                    {
                        return mm256_comb_epi32(n, k, unsafeLevels);
                    }
                    else
                    {
                        v256 ONE = Avx.mm256_set1_epi32(1);

                        k = Avx2.mm256_min_epu32(k, Avx2.mm256_sub_epi32(n, k));

                        v256 n2 = n;
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        v256 c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_srli_epi32(n2, 1), n), Avx2.mm256_and_si256(mm256_neg_epi32(Avx2.mm256_and_si256(n2, ONE)), Avx2.mm256_srli_epi32(n, 1)));
                        v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi32(k, ONE)), ONE, Avx2.mm256_cmpeq_epi32(k, Avx.mm256_setzero_si256()));
                        v256 i = Avx2.mm256_add_epi32(ONE, ONE);
                        v256 cmp = mm256_cmple_epu32(k, i);

                        while (Hint.Likely(mm256_notalltrue_epi256<uint>(cmp, 8)))
                        {
                            i = Avx2.mm256_add_epi32(i, ONE);
                            v256 q = mm256_divrem_epu32(c, i, out v256 r);
                            n = Avx2.mm256_sub_epi32(n, ONE);
                            c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(q, n), mm256_div_epu32(Avx2.mm256_mullo_epi32(r, n), i));

                            results = mm256_blendv_si256(c, results, cmp);
                            cmp = mm256_cmple_epu32(k, i);
                        }

                        return results;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epi64(v128 n, v128 k, byte unsafeLevels = 0)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.SLong0, n.SLong0);
Assert.IsNotGreater(k.SLong1, n.SLong1);
Assert.IsNonNegative(k.SLong0);
Assert.IsNonNegative(k.SLong1);
Assert.IsNonNegative(n.SLong0);
Assert.IsNonNegative(n.SLong1);
                    
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            v128 nFactorial  = gamma_epu64(n, true);
                            v128 kFactorial  = gamma_epu64(k, true);
                            v128 nkFactorial = gamma_epu64(Sse2.sub_epi64(n, k), true);

                            return usfcvttpd_epu64(Sse2.div_pd(usfcvtepu64_pd(nFactorial), usfcvtepu64_pd(mullo_epi64(kFactorial, nkFactorial))));
                        }
                        else
                        {
                            return Sse2.unpacklo_epi64(Sse2.cvtsi64x_si128((long)maxmath.comb(extract_epi64(n, 0), extract_epi64(k, 0), maxmath.Promise.Unsafe0)),
                                                       Sse2.cvtsi64x_si128((long)maxmath.comb(extract_epi64(n, 1), extract_epi64(k, 1), maxmath.Promise.Unsafe0)));
                        }
                    }


                    v128 ONE = Sse2.set1_epi64x(1);

                    k = min_epi64(k, Sse2.sub_epi64(n, k));

                    v128 n2 = n;
                    n = Sse2.sub_epi64(n, ONE);
                    v128 c = Sse2.add_epi64(mullo_epi64(Sse2.srli_epi64(n2, 1), n), Sse2.and_si128(neg_epi64(Sse2.and_si128(n2, ONE)), Sse2.srli_epi64(n, 1)));
                    v128 results = blendv_si128(blendv_si128(c, n2, cmpeq_epi64(k, ONE)), ONE, cmpeq_epi64(k, Sse2.setzero_si128()));
                    v128 i = Sse2.add_epi64(ONE, ONE);
                    v128 cmp = cmpgt_epi64(k, i);

                    while (Hint.Likely(notallfalse_epi128<ulong>(cmp, 2)))
                    {
                        i = Sse2.add_epi64(i, ONE);
                        v128 q = divrem_epu64(c, i, out v128 r);
                        n = Sse2.sub_epi64(n, ONE);
                        c = Sse2.add_epi64(mullo_epi64(q, n), div_epu64(mullo_epi64(r, n), i));

                        results = blendv_si128(results, c, cmp);
                        cmp = cmpgt_epi64(k, i);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epi64(v256 n, v256 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
Assert.IsNotGreater(k.SLong0, n.SLong0);
Assert.IsNotGreater(k.SLong1, n.SLong1);
Assert.IsNotGreater(k.SLong2, n.SLong2);
Assert.IsNonNegative(k.SLong0);
Assert.IsNonNegative(k.SLong1);
Assert.IsNonNegative(k.SLong2);
Assert.IsNonNegative(n.SLong0);
Assert.IsNonNegative(n.SLong1);
Assert.IsNonNegative(n.SLong2);
if (elements > 3)
{
    Assert.IsNotGreater(k.SLong3, n.SLong3);
    Assert.IsNonNegative(k.SLong3);
    Assert.IsNonNegative(n.SLong3);
}
                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            v256 nFactorial  = mm256_gamma_epu64(n, true);
                            v256 kFactorial  = mm256_gamma_epu64(k, true);
                            v256 nkFactorial = mm256_gamma_epu64(Avx2.mm256_sub_epi64(n, k), true);
                    
                            return mm256_usfcvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(nFactorial), mm256_usfcvtepu64_pd(mm256_mullo_epi64(kFactorial, nkFactorial, elements))));
                        }
                        else
                        {
                            return mm256_naivecomb_epu64(n, k, elements);
                        }
                    }


                    v256 ONE = Avx.mm256_set1_epi64x(1);

                    k = mm256_min_epi64(k, Avx2.mm256_sub_epi64(n, k));

                    v256 n2 = n;
                    n = Avx2.mm256_sub_epi64(n, ONE);
                    v256 c = Avx2.mm256_add_epi64(mm256_mullo_epi64(Avx2.mm256_srli_epi64(n2, 1), n, elements), Avx2.mm256_and_si256(mm256_neg_epi64(Avx2.mm256_and_si256(n2, ONE)), Avx2.mm256_srli_epi64(n, 1)));
                    v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi64(k, ONE)), ONE, Avx2.mm256_cmpeq_epi64(k, Avx.mm256_setzero_si256()));
                    v256 i = Avx2.mm256_add_epi64(ONE, ONE);
                    v256 cmp = mm256_cmpgt_epi64(k, i, elements);

                    while (Hint.Likely(mm256_notallfalse_epi256<ulong>(cmp, elements)))
                    {
                        i = Avx2.mm256_add_epi64(i, ONE);
                        v256 q = mm256_divrem_epu64(c, i, out v256 r, elements);
                        n = Avx2.mm256_sub_epi64(n, ONE);
                        c = Avx2.mm256_add_epi64(mm256_mullo_epi64(q, n, elements), mm256_div_epu64(mm256_mullo_epi64(r, n, elements), i, elements));

                        results = mm256_blendv_si256(results, c, cmp);
                        cmp = mm256_cmpgt_epi64(k, i, elements);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 comb_epu64(v128 n, v128 k, byte unsafeLevels = 0)
            {
                if (Sse2.IsSse2Supported)
                {
Assert.IsNotGreater(k.ULong0, n.ULong0);
Assert.IsNotGreater(k.ULong1, n.ULong1);

                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU64(n, long.MaxValue))
                    {
                        return comb_epi64(n, k, unsafeLevels);
                    }
                    else
                    {
                        v128 ONE = Sse2.set1_epi64x(1);

                        k = min_epu64(k, Sse2.sub_epi64(n, k));

                        v128 n2 = n;
                        n = Sse2.sub_epi64(n, ONE);
                        v128 c = Sse2.add_epi64(mullo_epi64(Sse2.srli_epi64(n2, 1), n), Sse2.and_si128(neg_epi64(Sse2.and_si128(n2, ONE)), Sse2.srli_epi64(n, 1)));
                        v128 results = blendv_si128(blendv_si128(c, n2, cmpeq_epi64(k, ONE)), ONE, cmpeq_epi64(k, Sse2.setzero_si128()));
                        v128 i = Sse2.add_epi64(ONE, ONE);
                        v128 cmp = cmpgt_epu64(k, i);

                        while (Hint.Likely(notallfalse_epi128<ulong>(cmp, 2)))
                        {
                            i = Sse2.add_epi64(i, ONE);
                            v128 q = divrem_epu64(c, i, out v128 r);
                            n = Sse2.sub_epi64(n, ONE);
                            c = Sse2.add_epi64(mullo_epi64(q, n), div_epu64(mullo_epi64(r, n), i));

                            results = blendv_si128(results, c, cmp);
                            cmp = cmpgt_epu64(k, i);
                        }

                        return results;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_comb_epu64(v256 n, v256 k, byte unsafeLevels = 0, byte elements = 4)
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
                    if (unsafeLevels != 0 || constexpr.ALL_LE_EPU64(n, long.MaxValue, elements))
                    {
                        return mm256_comb_epi64(n, k, unsafeLevels, elements);
                    }
                    else
                    {
                        v256 ONE = Avx.mm256_set1_epi64x(1);

                        k = mm256_min_epu64(k, Avx2.mm256_sub_epi64(n, k));

                        v256 n2 = n;
                        n = Avx2.mm256_sub_epi64(n, ONE);
                        v256 c = Avx2.mm256_add_epi64(mm256_mullo_epi64(Avx2.mm256_srli_epi64(n2, 1), n, elements), Avx2.mm256_and_si256(mm256_neg_epi64(Avx2.mm256_and_si256(n2, ONE)), Avx2.mm256_srli_epi64(n, 1)));
                        v256 results = mm256_blendv_si256(mm256_blendv_si256(c, n2, Avx2.mm256_cmpeq_epi64(k, ONE)), ONE, Avx2.mm256_cmpeq_epi64(k, Avx.mm256_setzero_si256()));
                        v256 i = Avx2.mm256_add_epi64(ONE, ONE);
                        v256 cmp = mm256_cmpgt_epu64(k, i, elements);

                        while (Hint.Likely(mm256_notallfalse_epi256<ulong>(cmp, elements)))
                        {
                            i = Avx2.mm256_add_epi64(i, ONE);
                            v256 q = mm256_divrem_epu64(c, i, out v256 r, elements);
                            n = Avx2.mm256_sub_epi64(n, ONE);
                            c = Avx2.mm256_add_epi64(mm256_mullo_epi64(q, n, elements), mm256_div_epu64(mm256_mullo_epi64(r, n), i, elements));

                            results = mm256_blendv_si256(results, c, cmp);
                            cmp = mm256_cmpgt_epu64(k, i, elements);
                        }

                        return results;
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 128 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 comb(UInt128 n, UInt128 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U128))
            {
                return factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial(n - k, Promise.NoOverflow));
            }


            k = min(k, n - k);
            if (Hint.Unlikely(k.IsZero)) 
            {
                return 1;
            }
            
            UInt128 c = n--;
            
            if (Hint.Likely(k > 1))
            {
                c = ((c >> 1) * n) + (((UInt128)(-(Int128)(c & 1))) & (n >> 1));
            
                UInt128 i = 2;
                while (Hint.Likely(k > i++))
                {
                    UInt128 q = divrem(c, i, out UInt128 r);
                    n--;
                    c = (q * n) + ((r * n) / i);
                }
            }
            
            return c;
        }
        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 128 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 comb(Int128 n, Int128 k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsTrue(k >= 0);
Assert.IsTrue(n >= 0);
            
            return comb((UInt128)n, (UInt128)k, useFactorial);
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte comb(byte n, byte k, Promise useFactorial = Promise.Nothing) 
        {
            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    if (useFactorial.CountUnsafeLevels() > 2 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U16))
                    {
                        if (useFactorial.CountUnsafeLevels() > 3 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U8))
                        {
                            return (byte)(factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial((byte)(n - k), Promise.NoOverflow)));
                        }
                        else
                        {
                            return (byte)(factorial((ushort)n, Promise.NoOverflow) / (factorial((ushort)k, Promise.NoOverflow) * factorial((ushort)(n - k), Promise.NoOverflow)));
                        }
                    }
                    else
                    {
                        return (byte)(factorial((uint)n, Promise.NoOverflow) / (factorial((uint)k, Promise.NoOverflow) * factorial((uint)(n - k), Promise.NoOverflow)));
                    }
                }
                else
                {
                    return (byte)(factorial((ulong)n, Promise.NoOverflow) / (factorial((ulong)k, Promise.NoOverflow) * factorial((ulong)(n - k), Promise.NoOverflow)));
                }
            }


            k = min(k, (byte)(n - k));
            if (Hint.Unlikely(k == 0)) 
            {
                return 1;
            }
            
            byte c = n--;
            
            if (Hint.Likely(k > 1))
            {
                c = (byte)((byte)((c >> 1) * n) + (byte)((-(c & 1)) & (n >> 1)));
            
                byte i = 2;
                while (Hint.Likely(k > i++))
                {
                    byte q = divrem(c, i, out byte r);
                    n--;
                    c = (byte)((byte)(q * n) + (byte)((byte)(r * n) / i));
                }
            }
            
            return c;
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 comb(byte2 n, byte2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new byte2(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 comb(byte3 n, byte3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new byte3(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial), 
                                 comb(n.z, k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 comb(byte4 n, byte4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new byte4(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial), 
                                 comb(n.z, k.z, useFactorial), 
                                 comb(n.w, k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 comb(byte8 n, byte8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new byte8(comb(n.x0, k.x0, useFactorial),
                                 comb(n.x1, k.x1, useFactorial),
                                 comb(n.x2, k.x2, useFactorial),
                                 comb(n.x3, k.x3, useFactorial),
                                 comb(n.x4, k.x4, useFactorial),
                                 comb(n.x5, k.x5, useFactorial),
                                 comb(n.x6, k.x6, useFactorial),
                                 comb(n.x7, k.x7, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 comb(byte16 n, byte16 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 16);
            }
            else
            {
                return new byte16(comb(n.x0,  k.x0,  useFactorial),
                                  comb(n.x1,  k.x1,  useFactorial),
                                  comb(n.x2,  k.x2,  useFactorial),
                                  comb(n.x3,  k.x3,  useFactorial),
                                  comb(n.x4,  k.x4,  useFactorial),
                                  comb(n.x5,  k.x5,  useFactorial),
                                  comb(n.x6,  k.x6,  useFactorial),
                                  comb(n.x7,  k.x7,  useFactorial),
                                  comb(n.x8,  k.x8,  useFactorial),
                                  comb(n.x9,  k.x9,  useFactorial),
                                  comb(n.x10, k.x10, useFactorial),
                                  comb(n.x11, k.x11, useFactorial),
                                  comb(n.x12, k.x12, useFactorial),
                                  comb(n.x13, k.x13, useFactorial),
                                  comb(n.x14, k.x14, useFactorial),
                                  comb(n.x15, k.x15, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 comb(byte32 n, byte32 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu8(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new byte32(comb(n.v16_0,  k.v16_0,  useFactorial), 
                                  comb(n.v16_16, k.v16_16, useFactorial));
            }
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte comb(sbyte n, sbyte k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);
            
            return comb((byte)n, (byte)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 comb(sbyte2 n, sbyte2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new byte2((byte)comb((int)n.x, (int)k.x, useFactorial), 
                                 (byte)comb((int)n.y, (int)k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 comb(sbyte3 n, sbyte3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new byte3((byte)comb((int)n.x, (int)k.x, useFactorial), 
                                 (byte)comb((int)n.y, (int)k.y, useFactorial), 
                                 (byte)comb((int)n.z, (int)k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 comb(sbyte4 n, sbyte4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new byte4((byte)comb((int)n.x, (int)k.x, useFactorial), 
                                 (byte)comb((int)n.y, (int)k.y, useFactorial), 
                                 (byte)comb((int)n.z, (int)k.z, useFactorial), 
                                 (byte)comb((int)n.w, (int)k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 comb(sbyte8 n, sbyte8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new byte8((byte)comb((int)n.x0, (int)k.x0, useFactorial),
                                 (byte)comb((int)n.x1, (int)k.x1, useFactorial),
                                 (byte)comb((int)n.x2, (int)k.x2, useFactorial),
                                 (byte)comb((int)n.x3, (int)k.x3, useFactorial),
                                 (byte)comb((int)n.x4, (int)k.x4, useFactorial),
                                 (byte)comb((int)n.x5, (int)k.x5, useFactorial),
                                 (byte)comb((int)n.x6, (int)k.x6, useFactorial),
                                 (byte)comb((int)n.x7, (int)k.x7, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 comb(sbyte16 n, sbyte16 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi8(n, k, 16, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new byte16((byte)comb((int)n.x0,  (int)k.x0,  useFactorial),
                                  (byte)comb((int)n.x1,  (int)k.x1,  useFactorial),
                                  (byte)comb((int)n.x2,  (int)k.x2,  useFactorial),
                                  (byte)comb((int)n.x3,  (int)k.x3,  useFactorial),
                                  (byte)comb((int)n.x4,  (int)k.x4,  useFactorial),
                                  (byte)comb((int)n.x5,  (int)k.x5,  useFactorial),
                                  (byte)comb((int)n.x6,  (int)k.x6,  useFactorial),
                                  (byte)comb((int)n.x7,  (int)k.x7,  useFactorial),
                                  (byte)comb((int)n.x8,  (int)k.x8,  useFactorial),
                                  (byte)comb((int)n.x9,  (int)k.x9,  useFactorial),
                                  (byte)comb((int)n.x10, (int)k.x10, useFactorial),
                                  (byte)comb((int)n.x11, (int)k.x11, useFactorial),
                                  (byte)comb((int)n.x12, (int)k.x12, useFactorial),
                                  (byte)comb((int)n.x13, (int)k.x13, useFactorial),
                                  (byte)comb((int)n.x14, (int)k.x14, useFactorial),
                                  (byte)comb((int)n.x15, (int)k.x15, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 8 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 comb(sbyte32 n, sbyte32 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi8(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new byte32(comb(n.v16_0,  k.v16_0,  useFactorial), 
                                  comb(n.v16_16, k.v16_16, useFactorial));
            }
        }
        
        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort comb(ushort n, ushort k, Promise useFactorial = Promise.Nothing) 
        {
            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    if (useFactorial.CountUnsafeLevels() > 2 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U16))
                    {
                        if (useFactorial.CountUnsafeLevels() > 3 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U8))
                        {
                            return (ushort)(factorial((byte)n, Promise.NoOverflow) / (factorial((byte)k, Promise.NoOverflow) * factorial((byte)(n - k), Promise.NoOverflow)));
                        }
                        else
                        {
                            return (ushort)(factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial((ushort)(n - k), Promise.NoOverflow)));
                        }
                    }
                    else
                    {
                        return (ushort)(factorial((uint)n, Promise.NoOverflow) / (factorial((uint)k, Promise.NoOverflow) * factorial((uint)(n - k), Promise.NoOverflow)));
                    }
                }
                else
                {
                    return (ushort)(factorial((ulong)n, Promise.NoOverflow) / (factorial((ulong)k, Promise.NoOverflow) * factorial((ulong)(n - k), Promise.NoOverflow)));
                }
            }


            k = min(k, (ushort)(n - k));
            if (Hint.Unlikely(k == 0)) 
            {
                return 1;
            }
            
            ushort c = n--;
            
            if (Hint.Likely(k > 1))
            {
                c = (ushort)((ushort)((c >> 1) * n) + (ushort)((-(c & 1)) & (n >> 1)));
            
                ushort i = 2;
                while (Hint.Likely(k > i++))
                {
                    ushort q = divrem(c, i, out ushort r);
                    n--;
                    c = (ushort)((ushort)(q * n) + (ushort)((ushort)(r * n) / i));
                }
            }
            
            return c;
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 comb(ushort2 n, ushort2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new ushort2(comb(n.x, k.x, useFactorial), 
                                   comb(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 comb(ushort3 n, ushort3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new ushort3(comb(n.x, k.x, useFactorial), 
                                   comb(n.y, k.y, useFactorial), 
                                   comb(n.z, k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 comb(ushort4 n, ushort4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ushort4(comb(n.x, k.x, useFactorial), 
                                   comb(n.y, k.y, useFactorial), 
                                   comb(n.z, k.z, useFactorial), 
                                   comb(n.w, k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 comb(ushort8 n, ushort8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new ushort8(comb(n.x0, k.x0, useFactorial),
                                   comb(n.x1, k.x1, useFactorial),
                                   comb(n.x2, k.x2, useFactorial),
                                   comb(n.x3, k.x3, useFactorial),
                                   comb(n.x4, k.x4, useFactorial),
                                   comb(n.x5, k.x5, useFactorial),
                                   comb(n.x6, k.x6, useFactorial),
                                   comb(n.x7, k.x7, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 comb(ushort16 n, ushort16 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu16(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ushort16(comb(n.v8_0, k.v8_0, useFactorial), 
                                    comb(n.v8_8, k.v8_8, useFactorial));
            }
        }
        
        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort comb(short n, short k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);
            
            return comb((short)n, (short)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 comb(short2 n, short2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new ushort2((ushort)comb((int)n.x, (int)k.x, useFactorial), 
                                   (ushort)comb((int)n.y, (int)k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 comb(short3 n, short3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new ushort3((ushort)comb((int)n.x, (int)k.x, useFactorial), 
                                   (ushort)comb((int)n.y, (int)k.y, useFactorial), 
                                   (ushort)comb((int)n.z, (int)k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 comb(short4 n, short4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ushort4((ushort)comb((int)n.x, (int)k.x, useFactorial), 
                                   (ushort)comb((int)n.y, (int)k.y, useFactorial), 
                                   (ushort)comb((int)n.z, (int)k.z, useFactorial), 
                                   (ushort)comb((int)n.w, (int)k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 comb(short8 n, short8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new ushort8((ushort)comb((int)n.x0, (int)k.x0, useFactorial),
                                   (ushort)comb((int)n.x1, (int)k.x1, useFactorial),
                                   (ushort)comb((int)n.x2, (int)k.x2, useFactorial),
                                   (ushort)comb((int)n.x3, (int)k.x3, useFactorial),
                                   (ushort)comb((int)n.x4, (int)k.x4, useFactorial),
                                   (ushort)comb((int)n.x5, (int)k.x5, useFactorial),
                                   (ushort)comb((int)n.x6, (int)k.x6, useFactorial),
                                   (ushort)comb((int)n.x7, (int)k.x7, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 16 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 comb(short16 n, short16 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi16(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ushort16(comb(n.v8_0, k.v8_0, useFactorial), 
                                    comb(n.v8_8, k.v8_8, useFactorial));
            }
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint comb(uint n, uint k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNotGreater(k, n);
            
            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    return factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial(n - k, Promise.NoOverflow));
                }
                else
                {
                    return (uint)(factorial((ulong)n, Promise.NoOverflow) / (factorial((ulong)k, Promise.NoOverflow) * factorial((ulong)n - (ulong)k, Promise.NoOverflow)));
                }
            }

            
            k = math.min(k, n - k);
            if (Hint.Unlikely(k == 0)) 
            {
                return 1;
            }
            
            uint c = n--;
            
            if (Hint.Likely(k > 1))
            {
                c = ((c >> 1) * n) + (((uint)-(int)(c & 1)) & (n >> 1));
            
                uint i = 2;
                while (Hint.Likely(k > i++))
                {
                    uint q = divrem(c, i, out uint r);
                    n--;
                    c = (q * n) + ((r * n) / i);
                }
            }
            
            return c;
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 comb(uint2 n, uint2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.comb_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 2));
            }
            else
            {
                return new uint2(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 comb(uint3 n, uint3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.comb_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 3));
            }
            else
            {
                return new uint3(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial), 
                                 comb(n.z, k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 comb(uint4 n, uint4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.comb_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 4));
            }
            else
            {
                return new uint4(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial), 
                                 comb(n.z, k.z, useFactorial), 
                                 comb(n.w, k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 comb(uint8 n, uint8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu32(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new uint8(comb(n.v4_0, k.v4_0, useFactorial), 
                                 comb(n.v4_4, k.v4_4, useFactorial));
            }
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint comb(int n, int k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);
            
            return comb((uint)n, (uint)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 comb(int2 n, int2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.comb_epi32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 2));
            }
            else
            {
                return new uint2(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 comb(int3 n, int3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.comb_epi32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 3));
            }
            else
            {
                return new uint3(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial), 
                                 comb(n.z, k.z, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 comb(int4 n, int4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.comb_epi32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 4));
            }
            else
            {
                return new uint4(comb(n.x, k.x, useFactorial), 
                                 comb(n.y, k.y, useFactorial), 
                                 comb(n.z, k.z, useFactorial), 
                                 comb(n.w, k.w, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 comb(int8 n, int8 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi32(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new uint8(comb(n.v4_0, k.v4_0, useFactorial), 
                                 comb(n.v4_4, k.v4_4, useFactorial));
            }
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong comb(ulong n, ulong k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || Xse.constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    return (ulong)factorial((uint)n, Promise.NoOverflow) / (ulong)(factorial((uint)k, Promise.NoOverflow) * factorial((uint)n - (uint)k, Promise.NoOverflow));
                }
                else
                {
                    return factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial(n - k, Promise.NoOverflow));
                }
            }


            k = math.min(k, n - k);
            if (Hint.Unlikely(k == 0)) 
            {
                return 1;
            }
            
            ulong c = n--;
            
            if (Hint.Likely(k > 1))
            {
                c = ((c >> 1) * n) + (((ulong)-(long)(c & 1)) & (n >> 1));
            
                ulong i = 2;
                while (Hint.Likely(k > i++))
                {
                    ulong q = divrem(c, i, out ulong r);
                    n--;
                    c = (q * n) + ((r * n) / i);
                }
            }
            
            return c;
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 comb(ulong2 n, ulong2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epu64(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ulong2(comb(n.x, k.x, useFactorial), 
                                  comb(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 comb(ulong3 n, ulong3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu64(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new ulong3(comb(n.xy, k.xy, useFactorial), 
                                  comb(n.z,  k.z,  useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 comb(ulong4 n, ulong4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu64(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ulong4(comb(n.xy, k.xy, useFactorial), 
                                  comb(n.zw, k.zw, useFactorial));
            }
        }

        
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong comb(long n, long k, Promise useFactorial = Promise.Nothing) 
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);
            
            return comb((ulong)n, (ulong)k, useFactorial);
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 comb(long2 n, long2 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.comb_epi64(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ulong2(comb(n.x, k.x, useFactorial), 
                                  comb(n.y, k.y, useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 comb(long3 n, long3 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi64(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new ulong3(comb(n.xy, k.xy, useFactorial), 
                                  comb(n.z,  k.z,  useFactorial));
            }
        }
        
        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Arguments that produce an unsigned 64 bit overflow are undefined.     </summary>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 comb(long4 n, long4 k, Promise useFactorial = Promise.Nothing) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi64(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ulong4(comb(n.xy, k.xy, useFactorial), 
                                  comb(n.zw, k.zw, useFactorial));
            }
        }
    }
}