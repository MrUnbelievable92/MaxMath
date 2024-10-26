//#define TESTING

using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sll_epi8(v128 a, v128 count, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 7ul);
#endif

            if (Sse2.IsSse2Supported)
            {
                return slli_epi8(a, count.SInt0, inRange);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 8);

                if (!inRange && (count.ULong0 & ~7ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vdupq_n_s8(count.SByte0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srl_epi8(v128 a, v128 count, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 7ul);
#endif

            if (Sse2.IsSse2Supported)
            {
                return srli_epi8(a, count.SInt0, inRange);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 8);

                if (!inRange && (count.ULong0 & ~7ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u8(a, Arm.Neon.vdupq_n_s8((sbyte)-count.SByte0));
                }
            }
            else throw new IllegalInstructionException();
        }
       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sra_epi8(v128 a, v128 count, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 7ul);
#endif

            if (Sse2.IsSse2Supported)
            {
                return srai_epi8(a, count.SInt0, inRange);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 8);

                if (!inRange && (count.ULong0 & ~7ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s8(a, 7);
                }
                else
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vdupq_n_s8((sbyte)-count.SByte0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srl_epi8(v256 a, v256 count)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_srli_epi8(a, count.SInt0);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sll_epi8(v256 a, v256 count)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_slli_epi8(a, count.SInt0);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sra_epi8(v256 a, v256 count)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_srai_epi8(a, count.SInt0);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi8(v128 a, int n, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 7);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 1))
                {
                    return add_epi8(a, a);
                }
                if (constexpr.IS_TRUE(n == 2))
                {
                    v128 a2 = add_epi8(a, a);

                    return add_epi8(a2, a2);
                }


                v128 mask = set1_epi8((byte)(0b1111_1111 >> n));

                return slli_epi16(and_si128(a, mask), n);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sll_epi8(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }
       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi8(v128 a, int n, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 7);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 7))
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return blendv_epi8(setzero_si128(), set1_epi8(1), a);
                    }
                    else
                    {
                        return neg_epi8(cmpgt_epi8(setzero_si128(), a));
                    }
                }
                if (constexpr.IS_TRUE(n == 1))
                {
                    return srli_epi16(andnot_si128(set1_epi8(1), a), 1);
                }

                v128 mask = set1_epi8((byte)(0b1111_1111 << n));

                return srli_epi16(and_si128(a, mask), n);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return srl_epi8(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }
       
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi8(v128 a, int n, bool inRange = false, byte elements = 16)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 7);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 7))
                {
                    if (constexpr.ALL_GE_EPI8(a, 0, elements))
                    {
                        return setzero_si128();
                    }
                    if (constexpr.ALL_LT_EPI8(a, 0, elements))
                    {
                        return setall_si128();
                    }

                    return cmpgt_epi8(setzero_si128(), a);
                }

                if (Sse4_1.IsSse41Supported)
                {
                    if (elements <= 8)
                    {
                        return cvtepi16_epi8(srai_epi16(cvtepi8_epi16(a), n));
                    }
                }

                v128 even = srai_epi16(slli_epi16(a, 8), n + 8);
                v128 odd = srai_epi16(a, n);

                return blendv_si128(even, odd, new v128(0xFF00_FF00));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sra_epi8(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi8(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 1))
                {
                    return Avx2.mm256_add_epi8(a, a);
                }
                if (constexpr.IS_TRUE(n == 2))
                {
                    v256 a2 = Avx2.mm256_add_epi8(a, a);

                    return Avx2.mm256_add_epi8(a2, a2);
                }


                v256 mask = mm256_set1_epi8((byte)(0b1111_1111 >> n));

                return mm256_slli_epi16(Avx2.mm256_and_si256(a, mask), n);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi8(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 7))
                {
                    return mm256_neg_epi8(Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a));
                }
                if (constexpr.IS_TRUE(n == 1))
                {
                    return mm256_srli_epi16(Avx2.mm256_andnot_si256(mm256_set1_epi8(1), a), 1);
                }

                v256 mask = mm256_set1_epi8((byte)(0b1111_1111 << n));

                return mm256_srli_epi16(Avx2.mm256_and_si256(a, mask), n);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi8(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 8))
                {
                    return a;
                }
                if (constexpr.IS_TRUE(n == 7))
                {
                    if (constexpr.ALL_GE_EPI8(a, 0))
                    {
                        return Avx.mm256_setzero_si256();
                    }
                    if (constexpr.ALL_LT_EPI8(a, 0))
                    {
                        return mm256_setall_si256();
                    }

                    return Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a);
                }

                v256 even = mm256_srai_epi16(mm256_slli_epi16(a, 8), n + 8);
                v256 odd = mm256_srai_epi16(a, n);

                return mm256_blendv_si256(even, odd, new v256(0xFF00_FF00));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi8(v128 a, v128 b, bool inRange = false, bool noOverflow = false, byte elements = 16)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<byte16, byte>(b, 0, 7, elements);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return slli_epi8(a, b.Byte0, inRange);
                }

                //if (Avx512.IsAvx512Supported)
                //{
                //    if (elements <= 8)
                //    {
                //        v128 r16 = sllv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b));
                //
                //        return noOverflow ? packus_epi16(r16, r16) : cvtepi16_epi8(r16);
                //    }
                //    else
                //    {
                //        v128 loA16 = cvt2x2epu8_epi16(a, out v128 hiA16);
                //        v128 loB16 = cvt2x2epu8_epi16(b, out v128 hiB16);
                //
                //        v128 r16Lo = sllv_epi16(loA16, loB16);
                //        v128 r16Hi = sllv_epi16(hiA16, hiB16);
                //
                //        return noOverflow ? packus_epi16(r16Lo, r16Hi) : cvt2x2epi16_epi8(r16Lo, r16Hi);
                //    }
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        return cvtepi32_epi8(sllv_epi32(cvtepu8_epi32(a), cvtepu8_epi32(b)));
                    }
                    else if (elements == 8)
                    {
                        v128 loA32 = cvt2x2epu8_epi32(a, out v128 hiA32);
                        v128 loB32 = cvt2x2epu8_epi32(b, out v128 hiB32);

                        v128 loR32 = sllv_epi32(loA32, loB32);
                        v128 hiR32 = sllv_epi32(hiA32, hiB32);

                        v128 r16 = packs_epi32(loR32, hiR32);

                        return noOverflow ? packus_epi16(r16, r16) : cvtepi16_epi8(r16);
                    }
                    else
                    {
                        cvt4x4epu8_epi32(a, out v128 a0, out v128 a1, out v128 a2, out v128 a3);
                        cvt4x4epu8_epi32(b, out v128 b0, out v128 b1, out v128 b2, out v128 b3);

                        v128 r0 = sllv_epi32(a0, b0);
                        v128 r1 = sllv_epi32(a1, b1);
                        v128 r2 = sllv_epi32(a2, b2);
                        v128 r3 = sllv_epi32(a3, b3);

                        v128 r16lo = packs_epi32(r0, r1);
                        v128 r16hi = packs_epi32(r2, r3);

                        return noOverflow ? packus_epi16(r16lo, r16hi) : cvt2x2epi16_epi8(r16lo, r16hi);
                    }
                }

                if (constexpr.IS_CONST(b))
                {
                    return mullo_epi8(a, new v128((byte)(1 << b.Byte0), (byte)(1 << b.Byte1), (byte)(1 << b.Byte2), (byte)(1 << b.Byte3), (byte)(1 << b.Byte4), (byte)(1 << b.Byte5), (byte)(1 << b.Byte6), (byte)(1 << b.Byte7), (byte)(1 << b.Byte8), (byte)(1 << b.Byte9), (byte)(1 << b.Byte10), (byte)(1 << b.Byte11), (byte)(1 << b.Byte12), (byte)(1 << b.Byte13), (byte)(1 << b.Byte14), (byte)(1 << b.Byte15)), elements);
                }

                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                    {
                        v128 LOOKUP = new v128((byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0);

                        return shuffle_epi8(LOOKUP, b);
                    }

                    v128 POW2_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,     0, 0, 0, 0, 0, 0, 0, 0);
                    v128 mulValues = shuffle_epi8(POW2_MASK, b);

                    return mullo_epi8(a, mulValues, elements);
                }
                else
                {
                    int shift = 1;

                    v128 result = setzero_si128();
                    if (!constexpr.ALL_NEQ_EPU8(b, 0, elements))
                    {
                        result = and_si128(a, cmpeq_epi8(setzero_si128(), b));
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 1, elements))
                    {
                        a = slli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(1), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 1, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 2, elements))
                    {
                        a = slli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(2), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 2, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 3, elements))
                    {
                        a = slli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(3), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 3, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 4, elements))
                    {
                        a = slli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(4), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 4, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 5, elements))
                    {
                        a = slli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(5), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 5, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 6, elements))
                    {
                        a = slli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(6), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 6, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 7, elements))
                    {
                        a = slli_epi8(a, shift);
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(7), b)));
                    }

                    return result;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU8(b, 7, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u8(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u8(Arm.Neon.vshlq_u8(a, b), Arm.Neon.vcltq_u8(b, set1_epi8(8)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi8(v128 a, v128 b, bool inRange = false, byte elements = 16) 
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<byte16, byte>(b, 0, 7, elements);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return srli_epi8(a, b.Byte0, inRange);
                }

                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                    {
                        v128 LOOKUP = new v128((byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                        return shuffle_epi8(LOOKUP, b);
                    }
                }
                
                //if (Avx512.IsAvx512Supported)
                //{
                //    if (elements <= 8)
                //    {
                //        v128 r16 = srlv_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b));
                //
                //        return packus_epi16(r16, r16);
                //    }
                //    else
                //    {
                //        v128 loA16 = cvt2x2epu8_epi16(a, out v128 hiA16);
                //        v128 loB16 = cvt2x2epu8_epi16(b, out v128 hiB16);
                //
                //        v128 r16Lo = srlv_epi16(loA16, loB16);
                //        v128 r16Hi = srlv_epi16(hiA16, hiB16);
                //
                //        return packus_epi16(r16Lo, r16Hi);
                //    }
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        return cvtepi32_epi8(srlv_epi32(cvtepu8_epi32(a), cvtepu8_epi32(b)));
                    }
                    else if (elements == 8)
                    {
                        v128 loA32 = cvt2x2epu8_epi32(a, out v128 hiA32);
                        v128 loB32 = cvt2x2epu8_epi32(b, out v128 hiB32);

                        v128 loR32 = srlv_epi32(loA32, loB32);
                        v128 hiR32 = srlv_epi32(hiA32, hiB32);

                        v128 r16 = packus_epi32(loR32, hiR32);

                        return packus_epi16(r16, r16);
                    }
                    else
                    {
                        cvt4x4epu8_epi32(a, out v128 a0, out v128 a1, out v128 a2, out v128 a3);
                        cvt4x4epu8_epi32(b, out v128 b0, out v128 b1, out v128 b2, out v128 b3);

                        v128 r0 = srlv_epi32(a0, b0);
                        v128 r1 = srlv_epi32(a1, b1);
                        v128 r2 = srlv_epi32(a2, b2);
                        v128 r3 = srlv_epi32(a3, b3);

                        v128 r16lo = packus_epi32(r0, r1);
                        v128 r16hi = packus_epi32(r2, r3);

                        return packus_epi16(r16lo, r16hi);
                    }
                }
                else
                {
                    int shift = 1;

                    v128 result = setzero_si128();
                    if (!constexpr.ALL_NEQ_EPU8(b, 0, elements))
                    {
                        result = and_si128(a, cmpeq_epi8(setzero_si128(), b));
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 1, elements))
                    {
                        a = srli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(1), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 1, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 2, elements))
                    {
                        a = srli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(2), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 2, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 3, elements))
                    {
                        a = srli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(3), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 3, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 4, elements))
                    {
                        a = srli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(4), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 4, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 5, elements))
                    {
                        a = srli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(5), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 5, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 6, elements))
                    {
                        a = srli_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(6), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 6, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 7, elements))
                    {
                        a = srli_epi8(a, shift);
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(7), b)));
                    }

                    return result;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU8(b, 7, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u8(a, Arm.Neon.vnegq_s8(b));
                }
                else
                {
                    return Arm.Neon.vshlq_u8(a, Arm.Neon.vnegq_s8(Arm.Neon.vminq_u8(b, Arm.Neon.vdupq_n_u8(7))));
                }
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi8(v128 a, v128 b, bool inRange = false, byte elements = 16)
        {
#if TESTING
if (inRange) VectorAssert.IsBetween<byte16, byte>(b, 0, 7, elements);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU8(b, elements))
                {
                    return srai_epi8(a, b.Byte0, inRange: inRange, elements: elements);
                }

                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a, elements))
                    {
                        v128 LOOKUP = new v128((sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                        return shuffle_epi8(LOOKUP, b);
                    }
                }
                
                //if (Avx512.IsAvx512Supported)
                //{
                //    if (elements <= 8)
                //    {
                //        v128 r16 = srav_epi16(cvtepi8_epi16(a), cvtepi8_epi16(b));
                //
                //        return packs_epi16(r16, r16);
                //    }
                //    else
                //    {
                //        v128 loA16 = cvt2x2epi8_epi16(a, out v128 hiA16);
                //        v128 loB16 = cvt2x2epi8_epi16(b, out v128 hiB16);
                //
                //        v128 r16Lo = srav_epi16(loA16, loB16);
                //        v128 r16Hi = srav_epi16(hiA16, hiB16);
                //
                //        return packs_epi16(r16Lo, r16Hi);
                //    }
                //}
                //else
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        return cvtepi32_epi8(srav_epi32(cvtepi8_epi32(a), cvtepu8_epi32(b)));
                    }
                    else if (elements == 8)
                    {
                        v128 loA32 = cvt2x2epi8_epi32(a, out v128 hiA32);
                        v128 loB32 = cvt2x2epu8_epi32(b, out v128 hiB32);

                        v128 loR32 = srav_epi32(loA32, loB32);
                        v128 hiR32 = srav_epi32(hiA32, hiB32);

                        v128 r16 = packs_epi32(loR32, hiR32);

                        return packs_epi16(r16, r16);
                    }
                    else
                    {
                        cvt4x4epi8_epi32(a, out v128 a0, out v128 a1, out v128 a2, out v128 a3);
                        cvt4x4epu8_epi32(b, out v128 b0, out v128 b1, out v128 b2, out v128 b3);

                        v128 r0 = srav_epi32(a0, b0);
                        v128 r1 = srav_epi32(a1, b1);
                        v128 r2 = srav_epi32(a2, b2);
                        v128 r3 = srav_epi32(a3, b3);

                        v128 r16lo = packs_epi32(r0, r1);
                        v128 r16hi = packs_epi32(r2, r3);

                        return packs_epi16(r16lo, r16hi);
                    }
                }
                else
                {
                    int shift = 1;

                    v128 result = setzero_si128();
                    if (!constexpr.ALL_NEQ_EPU8(b, 0, elements))
                    {
                        result = and_si128(a, cmpeq_epi8(setzero_si128(), b));
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 1, elements))
                    {
                        a = srai_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(1), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 1, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 2, elements))
                    {
                        a = srai_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(2), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 2, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 3, elements))
                    {
                        a = srai_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(3), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 3, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 4, elements))
                    {
                        a = srai_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(4), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 4, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 5, elements))
                    {
                        a = srai_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(5), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 5, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 6, elements))
                    {
                        a = srai_epi8(a, shift);
                        shift = 1;
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(6), b)));
                    }
                    else
                    {
                        shift++;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 6, elements))
                    {
                        return result;
                    }

                    if (!constexpr.ALL_NEQ_EPU8(b, 7, elements))
                    {
                        a = srai_epi8(a, shift);
                        result = or_si128(result, and_si128(a, cmpeq_epi8(set1_epi8(7), b)));
                    }

                    return result;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU8(b, 7, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vnegq_s8(b));
                }
                else
                {
                    return Arm.Neon.vshlq_s8(a, Arm.Neon.vnegq_s8(Arm.Neon.vminq_u8(b, Arm.Neon.vdupq_n_u8(7))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sllv_epi8(v256 a, v256 b, bool noOverflow = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8))
                {
                    return Avx.mm256_setzero_si256();
                }

                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_slli_epi8(a, b.Byte0);
                }

                if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                {
                    v256 LOOKUP = new v256((byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                           (byte)(a.Byte0 << 0), (byte)(a.Byte0 << 1), (byte)(a.Byte0 << 2), (byte)(a.Byte0 << 3), (byte)(a.Byte0 << 4), (byte)(a.Byte0 << 5), (byte)(a.Byte0 << 6), (byte)(a.Byte0 << 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    return Avx2.mm256_shuffle_epi8(LOOKUP, b);
                }

                
                //if (Avx512.IsAvx512Supported)
                //{
                //    v256 loA16 = mm256_cvt2x2epu8_epi16(a, out v256 hiA16);
                //    v256 loB16 = mm256_cvt2x2epu8_epi16(b, out v256 hiB16);
                //    
                //    v256 r16Lo = mm256_sllv_epi16(loA16, loB16);
                //    v256 r16Hi = mm256_sllv_epi16(hiA16, hiB16);
                //    
                //    return noOverflow ? Avx2.mm256_packus_epi16(r16Lo, r16Hi) : mm256_cvt2x2epi16_epi8(r16Lo, r16Hi);
                //}
                //else
                {
                    mm256_cvt4x4epu8_epi32(a, out v256 a0, out v256 a1, out v256 a2, out v256 a3);
                    mm256_cvt4x4epu8_epi32(b, out v256 b0, out v256 b1, out v256 b2, out v256 b3);
                    
                    v256 r0 = Avx2.mm256_sllv_epi32(a0, b0);
                    v256 r1 = Avx2.mm256_sllv_epi32(a1, b1);
                    v256 r2 = Avx2.mm256_sllv_epi32(a2, b2);
                    v256 r3 = Avx2.mm256_sllv_epi32(a3, b3);
                    
                    v256 r16lo = Avx2.mm256_packs_epi32(r0, r1);
                    v256 r16hi = Avx2.mm256_packs_epi32(r2, r3);
                    
                    return noOverflow ? Avx2.mm256_packus_epi16(r16lo, r16hi) : mm256_cvt2x2epi16_epi8(r16lo, r16hi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srlv_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8))
                {
                    return Avx.mm256_setzero_si256();
                }

                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_srli_epi8(a, b.Byte0);
                }

                if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                {
                    v256 LOOKUP = new v256((byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                           (byte)(a.Byte0 >> 0), (byte)(a.Byte0 >> 1), (byte)(a.Byte0 >> 2), (byte)(a.Byte0 >> 3), (byte)(a.Byte0 >> 4), (byte)(a.Byte0 >> 5), (byte)(a.Byte0 >> 6), (byte)(a.Byte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    return Avx2.mm256_shuffle_epi8(LOOKUP, b);
                }
                
                //if (Avx512.IsAvx512Supported)
                //{
                //    v256 loA16 = mm256_cvt2x2epi8_epi16(a, out v256 hiA16);
                //    v256 loB16 = mm256_cvt2x2epi8_epi16(b, out v256 hiB16);
                //    
                //    v256 r16Lo = mm256_srlv_epi16(loA16, loB16);
                //    v256 r16Hi = mm256_srlv_epi16(hiA16, hiB16);
                //    
                //    return Avx2.mm256_packus_epi16(r16Lo, r16Hi);
                //}
                else
                {
                    mm256_cvt4x4epu8_epi32(a, out v256 a0, out v256 a1, out v256 a2, out v256 a3);
                    mm256_cvt4x4epu8_epi32(b, out v256 b0, out v256 b1, out v256 b2, out v256 b3);
                    
                    v256 r0 = Avx2.mm256_srlv_epi32(a0, b0);
                    v256 r1 = Avx2.mm256_srlv_epi32(a1, b1);
                    v256 r2 = Avx2.mm256_srlv_epi32(a2, b2);
                    v256 r3 = Avx2.mm256_srlv_epi32(a3, b3);
                    
                    v256 r16lo = Avx2.mm256_packus_epi32(r0, r1);
                    v256 r16hi = Avx2.mm256_packus_epi32(r2, r3);
                    
                    return Avx2.mm256_packus_epi16(r16lo, r16hi);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srav_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU8(b, 8))
                {
                    return Avx.mm256_setzero_si256();
                }

                if (constexpr.ALL_SAME_EPU8(b))
                {
                    return mm256_srai_epi8(a, b.Byte0);
                }

                if (constexpr.IS_CONST(a.Byte0) && constexpr.ALL_SAME_EPU8(a))
                {
                    v256 LOOKUP = new v256((sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0,
                                           (sbyte)(a.SByte0 >> 0), (sbyte)(a.SByte0 >> 1), (sbyte)(a.SByte0 >> 2), (sbyte)(a.SByte0 >> 3), (sbyte)(a.SByte0 >> 4), (sbyte)(a.SByte0 >> 5), (sbyte)(a.SByte0 >> 6), (sbyte)(a.SByte0 >> 7), 0, 0, 0, 0, 0, 0, 0, 0);

                    return Avx2.mm256_shuffle_epi8(LOOKUP, b);
                }
                
                //if (Avx512.IsAvx512Supported)
                //{
                //    v256 loA16 = mm256_cvt2x2epi8_epi16(a, out v256 hiA16);
                //    v256 loB16 = mm256_cvt2x2epi8_epi16(b, out v256 hiB16);
                //    
                //    v256 r16Lo = mm256_srav_epi16(loA16, loB16);
                //    v256 r16Hi = mm256_srav_epi16(hiA16, hiB16);
                //    
                //    return Avx2.mm256_packs_epi16(r16Lo, r16Hi);
                //}
                //else
                {
                    mm256_cvt4x4epi8_epi32(a, out v256 a0, out v256 a1, out v256 a2, out v256 a3);
                    mm256_cvt4x4epu8_epi32(b, out v256 b0, out v256 b1, out v256 b2, out v256 b3);
                    
                    v256 r0 = Avx2.mm256_srav_epi32(a0, b0);
                    v256 r1 = Avx2.mm256_srav_epi32(a1, b1);
                    v256 r2 = Avx2.mm256_srav_epi32(a2, b2);
                    v256 r3 = Avx2.mm256_srav_epi32(a3, b3);
                    
                    v256 r16lo = Avx2.mm256_packs_epi32(r0, r1);
                    v256 r16hi = Avx2.mm256_packs_epi32(r2, r3);
                    
                    return Avx2.mm256_packs_epi16(r16lo, r16hi);
                }
            }
            else throw new IllegalInstructionException();
        }

        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sll_epi16(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 15ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.sll_epi16(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 16);

                if (!inRange && (count.ULong0 & ~15ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vdupq_n_s16(count.SShort0));
                }
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srl_epi16(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 15ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.srl_epi16(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 16);

                if (!inRange && (count.ULong0 & ~15ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u16(a, Arm.Neon.vdupq_n_s16((short)-count.SShort0));
                }
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sra_epi16(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 15ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.sra_epi16(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 16);

                if (!inRange && (count.ULong0 & ~15ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s16(a, 15);
                }
                else
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vdupq_n_s16((short)-count.SShort0));
                }
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi16(v128 a, int n, bool inRange = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return sll_epi16(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srli_epi16(v128 a, int n, bool inRange = false)
		{
            if (Architecture.IsSIMDSupported)
			{
                return srl_epi16(a, cvtsi32_si128(n), inRange);
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi16(v128 a, int n, bool inRange = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return sra_epi16(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi16(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi16(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi16(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi16(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi16(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi16(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi16(v128 a, v128 b, bool inRange = false, bool noOverflow = false, byte elements = 8)
        {
if (inRange) VectorAssert.IsBetween<ushort8, ushort>(b, 0, 15, elements);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return slli_epi16(a, b.UShort0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 aLo = cvt2x2epu16_epi32(a, out v128 aHi);
                        v128 bLo = cvt2x2epu16_epi32(b, out v128 bHi);

                        aLo = sllv_epi32(aLo, bLo);
                        aHi = sllv_epi32(aHi, bHi);

                        return noOverflow ? packs_epi32(aLo, aHi) : cvt2x2epi32_epi16(aLo, aHi);
                    }
                    else
                    {
                        return cvtepi32_epi16(sllv_epi32(cvtepu16_epi32(a), cvtepu16_epi32(b)), elements);
                    }
                }

                if (constexpr.IS_CONST(b))
                {
                    return mullo_epi16(a, new v128((short)(1 << b.SShort0), (short)(1 << b.SShort1), (short)(1 << b.SShort2), (short)(1 << b.SShort3), (short)(1 << b.SShort4), (short)(1 << b.SShort5), (short)(1 << b.SShort6), (short)(1 << b.SShort7)));
                }

                if (Sse4_1.IsSse41Supported)
                {
                    if (elements <= 3)
                    {
                        v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

                        v128 _x = sll_epi16(a, shuffle_epi8(b, shuffleMask));
                        shuffleMask = insert_epi8(shuffleMask, 2, 0);
                        v128 _y = sll_epi16(a, shuffle_epi8(b, shuffleMask));
                        v128 _xy = blend_epi16(_x, _y, 0b0000_0010);

                        if (elements == 2)
                        {
                            return _xy;
                        }

                        shuffleMask = insert_epi8(shuffleMask, 4, 0);
                        v128 _z = sll_epi16(a, shuffle_epi8(b, shuffleMask));


                        return blend_epi16(_xy, _z, 0b0000_0100);
                    }
                }

                if (Ssse3.IsSsse3Supported)
                {
                    v128 POW2_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3, 1 << 4, 1 << 5, 1 << 6, 1 << 7,       0, 0, 0, 0, 0, 0, 0, 0);

                    v128 mulValues = packus_epi16(b, b);

                    v128 pow8to15 = sub_epi8(mulValues, set1_epi8(8));
                    pow8to15 = shuffle_epi8(POW2_MASK, pow8to15);

                    v128 mulLo = shuffle_epi8(POW2_MASK, mulValues);

                    mulValues = unpacklo_epi8(mulLo, pow8to15);

                    if (constexpr.ALL_EQ_EPI16(a, 1))
                    {
                        return mulValues;
                    }
                    else
                    {
                        return mullo_epi16(a, mulValues);
                    }
                }
                else
                {
                    v128 EPI16_MASK = new v128(15, 0, 0, 0);

                    v128 elementMask = new v128(ushort.MaxValue, 0, 0, 0);

                    v128 result0 = sll_epi16(a, and_si128(b, EPI16_MASK));
                    result0 = and_si128(result0, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    b = bsrli_si128(b, sizeof(short));
                    v128 result1 = sll_epi16(a, and_si128(b, EPI16_MASK));
                    result1 = and_si128(result1, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    result0 = or_si128(result0, result1);

                    if (elements > 2)
                    {
                        b = bsrli_si128(b, sizeof(short));
                        result1 = sll_epi16(a, and_si128(b, EPI16_MASK));
                        result1 = and_si128(result1, elementMask);
                        elementMask = bslli_si128(elementMask, sizeof(short));
                        result0 = or_si128(result0, result1);

                        if (elements > 3)
                        {
                            b = bsrli_si128(b, sizeof(short));
                            result1 = sll_epi16(a, and_si128(b, EPI16_MASK));
                            result1 = and_si128(result1, elementMask);
                            elementMask = bslli_si128(elementMask, sizeof(short));
                            result0 = or_si128(result0, result1);

                            if (elements > 4)
                            {
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sll_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sll_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sll_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sll_epi16(a, b);
                                result1 = and_si128(result1, elementMask);
                                result0 = or_si128(result0, result1);
                            }
                        }
                    }

                    return result0;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU16(b, 15, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u16(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u16(Arm.Neon.vshlq_u16(a, b), Arm.Neon.vcltq_u16(b, set1_epi16(16)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi16(v128 a, v128 b, bool inRange = false, byte elements = 8)
        {
if (inRange) VectorAssert.IsBetween<ushort8, ushort>(b, 0, 15, elements);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return srli_epi16(a, b.UShort0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 a32Lo = cvt2x2epu16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epu16_epi32(b, out v128 b32Hi);

                        v128 lo = srlv_epi32(a32Lo, b32Lo);
                        v128 hi = srlv_epi32(a32Hi, b32Hi);

                        return packus_epi32(lo, hi);
                    }
                    else
                    {
                        return cvtepi32_epi16(srlv_epi32(cvtepu16_epi32(a), cvtepu16_epi32(b)), elements);
                    }
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

                    v128 _x = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 2, 0);
                    v128 _y = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_0010);

                    if (elements == 2)
                    {
                        return _xy;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _z = srl_epi16(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        return blend_epi16(_xy, _z, 0b0000_0100);
                    }

                    shuffleMask = insert_epi8(shuffleMask, 6, 0);
                    v128 _w = srl_epi16(a, shuffle_epi8(b, shuffleMask));

                    v128 _zw = blend_epi16(_z, _w, 0b0000_1000);

                    v128 result = blend_epi16(_xy, _zw, 0b0000_1100);

                    if (elements == 4)
                    {
                        return result;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0001_0000);

                    shuffleMask = insert_epi8(shuffleMask, 10, 0);
                    shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0010_0000);

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0100_0000);

                    shuffleMask = insert_epi8(shuffleMask, 14, 0);
                    shift = srl_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b1000_0000);


                    return result;
                }
                else
                {
                    v128 EPI16_MASK = new v128(15, 0, 0, 0);

                    v128 elementMask = new v128(ushort.MaxValue, 0, 0, 0);

                    v128 result0 = srl_epi16(a, and_si128(b, EPI16_MASK));
                    result0 = and_si128(result0, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    b = bsrli_si128(b, sizeof(short));
                    v128 result1 = srl_epi16(a, and_si128(b, EPI16_MASK));
                    result1 = and_si128(result1, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    result0 = or_si128(result0, result1);

                    if (elements > 2)
                    {
                        b = bsrli_si128(b, sizeof(short));
                        result1 = srl_epi16(a, and_si128(b, EPI16_MASK));
                        result1 = and_si128(result1, elementMask);
                        elementMask = bslli_si128(elementMask, sizeof(short));
                        result0 = or_si128(result0, result1);

                        if (elements > 3)
                        {
                            b = bsrli_si128(b, sizeof(short));
                            result1 = srl_epi16(a, and_si128(b, EPI16_MASK));
                            result1 = and_si128(result1, elementMask);
                            elementMask = bslli_si128(elementMask, sizeof(short));
                            result0 = or_si128(result0, result1);

                            if (elements > 4)
                            {
                                b = bsrli_si128(b, sizeof(short));
                                result1 = srl_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = srl_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = srl_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = srl_epi16(a, b);
                                result1 = and_si128(result1, elementMask);
                                result0 = or_si128(result0, result1);
                            }
                        }
                    }

                    return result0;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU16(b, 15, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u16(a, Arm.Neon.vnegq_s16(b));
                }
                else
                {
                    return Arm.Neon.vshlq_u16(a, Arm.Neon.vnegq_s16(Arm.Neon.vminq_u16(b, Arm.Neon.vdupq_n_u16(15))));
                }
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi16(v128 a, v128 b, bool inRange = false, byte elements = 8)
        {
if (inRange) VectorAssert.IsBetween<ushort8, ushort>(b, 0, 15, elements);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU16(b, elements))
                {
                    return srai_epi16(a, b.UShort0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (elements > 4)
                    {
                        v128 a32Lo = cvt2x2epi16_epi32(a, out v128 a32Hi);
                        v128 b32Lo = cvt2x2epi16_epi32(b, out v128 b32Hi);

                        v128 lo = srav_epi32(a32Lo, b32Lo);
                        v128 hi = srav_epi32(a32Hi, b32Hi);

                        return packs_epi32(lo, hi);
                    }
                    else
                    {
                        return cvtepi32_epi16(srav_epi32(cvtepi16_epi32(a), cvtepu16_epi32(b)), elements);
                    }
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);

                    v128 _x = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 2, 0);
                    v128 _y = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_0010);

                    if (elements == 2)
                    {
                        return _xy;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _z = sra_epi16(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        return blend_epi16(_xy, _z, 0b0000_0100);
                    }

                    shuffleMask = insert_epi8(shuffleMask, 6, 0);
                    v128 _w = sra_epi16(a, shuffle_epi8(b, shuffleMask));

                    v128 _zw = blend_epi16(_z, _w, 0b0000_1000);

                    v128 result = blend_epi16(_xy, _zw, 0b0000_1100);

                    if (elements == 4)
                    {
                        return result;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0001_0000);

                    shuffleMask = insert_epi8(shuffleMask, 10, 0);
                    shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0010_0000);

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b0100_0000);

                    shuffleMask =insert_epi8(shuffleMask, 14, 0);
                    shift = sra_epi16(a, shuffle_epi8(b, shuffleMask));
                    result = blend_epi16(result, shift, 0b1000_0000);


                    return result;
                }
                else
                {
                    v128 EPI16_MASK = new v128(15, 0, 0, 0);

                    v128 elementMask = new v128(ushort.MaxValue, 0, 0, 0);

                    v128 result0 = sra_epi16(a, and_si128(b, EPI16_MASK));
                    result0 = and_si128(result0, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    b = bsrli_si128(b, sizeof(short));
                    v128 result1 = sra_epi16(a, and_si128(b, EPI16_MASK));
                    result1 = and_si128(result1, elementMask);
                    elementMask = bslli_si128(elementMask, sizeof(short));
                    result0 = or_si128(result0, result1);

                    if (elements > 2)
                    {
                        b = bsrli_si128(b, sizeof(short));
                        result1 = sra_epi16(a, and_si128(b, EPI16_MASK));
                        result1 = and_si128(result1, elementMask);
                        elementMask = bslli_si128(elementMask, sizeof(short));
                        result0 = or_si128(result0, result1);

                        if (elements > 3)
                        {
                            b = bsrli_si128(b, sizeof(short));
                            result1 = sra_epi16(a, and_si128(b, EPI16_MASK));
                            result1 = and_si128(result1, elementMask);
                            elementMask = bslli_si128(elementMask, sizeof(short));
                            result0 = or_si128(result0, result1);

                            if (elements > 4)
                            {
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sra_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sra_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sra_epi16(a, and_si128(b, EPI16_MASK));
                                result1 = and_si128(result1, elementMask);
                                elementMask = bslli_si128(elementMask, sizeof(short));
                                result0 = or_si128(result0, result1);
                                b = bsrli_si128(b, sizeof(short));
                                result1 = sra_epi16(a, b);
                                result1 = and_si128(result1, elementMask);
                                result0 = or_si128(result0, result1);
                            }
                        }
                    }

                    return result0;
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU16(b, 15, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vnegq_s16(b));
                }
                else
                {
                    return Arm.Neon.vshlq_s16(a, Arm.Neon.vnegq_s16(Arm.Neon.vminq_u16(b, Arm.Neon.vdupq_n_u16(15))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sllv_epi16(v256 a, v256 b, bool noOverflow = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16))
                {
                    return Avx.mm256_setzero_si256();
                }

                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_slli_epi16(a, b.UShort0);
                }

                if (constexpr.IS_CONST(b))
                {
                    return Avx2.mm256_mullo_epi16(a, new v256((short)(1 << b.SShort0), (short)(1 << b.SShort1), (short)(1 << b.SShort2), (short)(1 << b.SShort3), (short)(1 << b.SShort4), (short)(1 << b.SShort5), (short)(1 << b.SShort6), (short)(1 << b.SShort7), (short)(1 << b.SShort8), (short)(1 << b.SShort9), (short)(1 << b.SShort10), (short)(1 << b.SShort11), (short)(1 << b.SShort12), (short)(1 << b.SShort13), (short)(1 << b.SShort14), (short)(1 << b.SShort15)));
                }

                v256 aLo = mm256_cvt2x2epi16_epi32(a, out v256 aHi);
                v256 bLo = mm256_cvt2x2epi16_epi32(b, out v256 bHi);

                aLo = Avx2.mm256_sllv_epi32(aLo, bLo);
                aHi = Avx2.mm256_sllv_epi32(aHi, bHi);

                return noOverflow ? Avx2.mm256_packs_epi32(aLo, aHi) : mm256_cvt2x2epi32_epi16(aLo, aHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srlv_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16))
                {
                    return Avx.mm256_setzero_si256();
                }

                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_srli_epi16(a, b.UShort0);
                }

                v256 aLo = mm256_cvt2x2epu16_epi32(a, out v256 aHi);
                v256 bLo = mm256_cvt2x2epu16_epi32(b, out v256 bHi);

                aLo = Avx2.mm256_srlv_epi32(aLo, bLo);
                aHi = Avx2.mm256_srlv_epi32(aHi, bHi);

                return Avx2.mm256_packus_epi32(aLo, aHi);
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srav_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU16(b, 16))
                {
                    return Avx.mm256_setzero_si256();
                }

                if (constexpr.ALL_SAME_EPU16(b))
                {
                    return mm256_srai_epi16(a, b.UShort0);
                }

                v256 aLo = mm256_cvt2x2epi16_epi32(a, out v256 aHi);
                v256 bLo = mm256_cvt2x2epi16_epi32(b, out v256 bHi);

                aLo = Avx2.mm256_srav_epi32(aLo, bLo);
                aHi = Avx2.mm256_srav_epi32(aHi, bHi);

                return Avx2.mm256_packs_epi32(aLo, aHi);
            }
            else throw new IllegalInstructionException();
        }
		

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sll_epi32(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 31ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.sll_epi32(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 32);

                if (!inRange && (count.ULong0 & ~31ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vdupq_n_s32(count.SInt0));
                }
            }
			else throw new IllegalInstructionException();
		}
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srl_epi32(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 31ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.srl_epi32(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 32);

                if (!inRange && (count.ULong0 & ~31ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u32(a, Arm.Neon.vdupq_n_s32(-count.SInt0));
                }
            }
			else throw new IllegalInstructionException();
		}
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sra_epi32(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 31ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.sra_epi32(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 32);

                if (!inRange && (count.ULong0 & ~31ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s32(a, 31);
                }
                else
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vdupq_n_s32(-count.SInt0));
                }
            }
			else throw new IllegalInstructionException();
		}
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 slli_epi32(v128 a, int imm8, bool inRange = false)
		{
            if (Architecture.IsSIMDSupported)
			{
                return sll_epi32(a, cvtsi32_si128(imm8), inRange);
			}
			else throw new IllegalInstructionException();
		}
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srli_epi32(v128 a, int imm8, bool inRange = false)
		{
            if (Architecture.IsSIMDSupported)
			{
                return srl_epi32(a, cvtsi32_si128(imm8), inRange);
			}
			else throw new IllegalInstructionException();
		}
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srai_epi32(v128 a, int imm8, bool inRange = false)
		{
            if (Architecture.IsSIMDSupported)
			{
                return sra_epi32(a, cvtsi32_si128(imm8), inRange);
			}
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi32(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi32(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi32(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi32(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi32(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi32(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi32(v128 a, v128 b, bool inRange = false, byte elements = 4)
        {
if (inRange) VectorAssert.IsBetween<uint4, uint>(RegisterConversion.ToUInt4(b), 0, 31, elements);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU32(b, 32, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return slli_epi32(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.sllv_epi32(a, b);
                }

                if (Sse4_1.IsSse41Supported)
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return mullo_epi32(a, new v128(1 << b.SInt0, 1 << b.SInt1, 1 << b.SInt2, 1 << b.SInt3));
                    }

                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = sll_epi32(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _y = sll_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_1100);

                    if (elements == 2)
                    {
                        return _xy;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _z = sll_epi32(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        return blend_epi16(_xy, _z, 0b0011_0000);
                    }

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    v128 _w = sll_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _zw = blend_epi16(_z, _w, 0b1100_0000);

                    return blend_epi16(_xy, _zw, 0b1111_0000);
                }
                else
                {
                    if (constexpr.IS_CONST(b) && elements > 3)
                    {
                        return mullo_epi32(a, new v128(1 << b.SInt0, 1 << b.SInt1, 1 << b.SInt2, 1 << b.SInt3));
                    }

                    v128 MASK = cvtsi32_si128(-1);

                    v128 _x = sll_epi32(a,                               and_si128(MASK, b));
                    v128 _y = sll_epi32(bsrli_si128(a, 1 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 1 * sizeof(int))));

                    if (elements == 2)
                    {
                        return unpacklo_epi32(_x, _y);
                    }

                    v128 lo = unpacklo_epi32(_x, _y);
                    v128 _z = sll_epi32(bsrli_si128(a, 2 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 2 * sizeof(int))));

                    if (elements == 3)
                    {
                        return unpacklo_epi64(lo, _z);
                    }

                    v128 _w = sll_epi32(bsrli_si128(a, 3 * sizeof(int)), bsrli_si128(b, 3 * sizeof(int)));

                    v128 hi = unpacklo_epi32(_z, _w);

                    return unpacklo_epi64(lo, hi);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU32(b, 31, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u32(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u32(Arm.Neon.vshlq_u32(a, b), Arm.Neon.vcltq_u32(b, set1_epi32(32)));
                }
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi32(v128 a, v128 b, bool inRange = false, byte elements = 4)
        {
if (inRange) VectorAssert.IsBetween<uint4, uint>(RegisterConversion.ToUInt4(b), 0, 31, elements);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU32(b, 32, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return srli_epi32(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srlv_epi32(a, b);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = srl_epi32(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _y = srl_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_1100);

                    if (elements == 2)
                    {
                        return _xy;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _z = srl_epi32(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        return blend_epi16(_xy, _z, 0b0011_0000);
                    }

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    v128 _w = srl_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _zw = blend_epi16(_z, _w, 0b1100_0000);

                    return blend_epi16(_xy, _zw, 0b1111_0000);
                }
                else
                {
                    v128 MASK = cvtsi32_si128(-1);

                    v128 _x = srl_epi32(a,                               and_si128(MASK, b));
                    v128 _y = srl_epi32(bsrli_si128(a, 1 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 1 * sizeof(int))));

                    if (elements == 2)
                    {
                        return unpacklo_epi32(_x, _y);
                    }

                    v128 lo = unpacklo_epi32(_x, _y);
                    v128 _z = srl_epi32(bsrli_si128(a, 2 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 2 * sizeof(int))));

                    if (elements == 3)
                    {
                        return unpacklo_epi64(lo, _z);
                    }

                    v128 _w = srl_epi32(bsrli_si128(a, 3 * sizeof(int)), bsrli_si128(b, 3 * sizeof(int)));

                    v128 hi = unpacklo_epi32(_z, _w);

                    return unpacklo_epi64(lo, hi);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU32(b, 31, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u32(a, Arm.Neon.vnegq_s32(b));
                }
                else
                {
                    return Arm.Neon.vshlq_u32(a, Arm.Neon.vnegq_s32(Arm.Neon.vminq_u32(b, Arm.Neon.vdupq_n_u32(31))));
                }
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi32(v128 a, v128 b, bool inRange = false, byte elements = 4)
        {
if (inRange) VectorAssert.IsBetween<uint4, uint>(RegisterConversion.ToUInt4(b), 0, 31, elements);

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU32(b, 32, elements))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU32(b, elements))
                {
                    return srai_epi32(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srav_epi32(a, b);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = sra_epi32(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 4, 0);
                    v128 _y = sra_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _xy = blend_epi16(_x, _y, 0b0000_1100);

                    if (elements == 2)
                    {
                        return _xy;
                    }

                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _z = sra_epi32(a, shuffle_epi8(b, shuffleMask));

                    if (elements == 3)
                    {
                        return blend_epi16(_xy, _z, 0b0011_0000);
                    }

                    shuffleMask = insert_epi8(shuffleMask, 12, 0);
                    v128 _w = sra_epi32(a, shuffle_epi8(b, shuffleMask));
                    v128 _zw = blend_epi16(_z, _w, 0b1100_0000);

                    return blend_epi16(_xy, _zw, 0b1111_0000);
                }
                else
                {
                    v128 MASK = cvtsi32_si128(-1);

                    v128 _x = sra_epi32(a,                               and_si128(MASK, b));
                    v128 _y = sra_epi32(bsrli_si128(a, 1 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 1 * sizeof(int))));

                    if (elements == 2)
                    {
                        return unpacklo_epi32(_x, _y);
                    }

                    v128 lo = unpacklo_epi32(_x, _y);
                    v128 _z = sra_epi32(bsrli_si128(a, 2 * sizeof(int)), and_si128(MASK, bsrli_si128(b, 2 * sizeof(int))));

                    if (elements == 3)
                    {
                        return unpacklo_epi64(lo, _z);
                    }

                    v128 _w = sra_epi32(bsrli_si128(a, 3 * sizeof(int)), bsrli_si128(b, 3 * sizeof(int)));

                    v128 hi = unpacklo_epi32(_z, _w);

                    return unpacklo_epi64(lo, hi);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU32(b, 31, elements);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vnegq_s32(b));
                }
                else
                {
                    return Arm.Neon.vshlq_s32(a, Arm.Neon.vnegq_s32(Arm.Neon.vminq_u32(b, Arm.Neon.vdupq_n_u32(31))));
                }
            }
            else throw new IllegalInstructionException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 sll_epi64(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 63ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.sll_epi64(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 64);

                if (!inRange && (count.ULong0 & ~63ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_s64(a, Arm.Neon.vdupq_n_s64(count.SLong0));
                }
            }
			else throw new IllegalInstructionException();
		}
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 srl_epi64(v128 a, v128 count, bool inRange = false)
		{
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 63ul);
#endif

			if (Sse2.IsSse2Supported)
			{
				return Sse2.srl_epi64(a, count);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 64);

                if (!inRange && (count.ULong0 & ~63ul) != 0)
                {
                    return setzero_si128();
                }
                else
                {
                    return Arm.Neon.vshlq_u64(a, Arm.Neon.vdupq_n_s64(-count.SLong0));
                }
            }
			else throw new IllegalInstructionException();
		}
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sra_epi64(v128 a, v128 count, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(count.ULong0, 0ul, 63ul);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(count.ULong0 <= 0 | count.ULong0 >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return srl_epi64(a, count, inRange);
                }

                v128 sign = shuffle_epi32(srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));

                if (constexpr.IS_CONST(count.ULong0))
                {
                    if (count.ULong0 == 63)
                    {
                        return sign;
                    }
                    if (count.ULong0 <= 32)
                    {
                        return blend_epi16(srl_epi64(a, count), sra_epi32(a, count), 0b1100_1100);
                    }
                }

                v128 shiftedSign = sll_epi64(sign, subs_epu16(cvtsi64x_si128(64), count));

                return or_si128(shiftedSign, srl_epi64(a, count));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                inRange |= constexpr.IS_TRUE(count.ULong0 < 64);

                if (!inRange && (count.ULong0 & ~63ul) != 0)
                {
                    return Arm.Neon.vshrq_n_s64(a, 63);
                }
                else
                {
                    return Arm.Neon.vshlq_s64(a, Arm.Neon.vdupq_n_s64(-count.SLong0));
                }
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_sra_epi64(v256 a, v128 count)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(count.ULong0 <= 0 | count.ULong0 >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return Avx2.mm256_srl_epi64(a, count);
                }

                v256 sign = Avx2.mm256_shuffle_epi32(Avx2.mm256_srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));

                if (constexpr.IS_CONST(count.ULong0))
                {
                    if (count.ULong0 == 63)
                    {
                        return sign;
                    }
                    if (count.ULong0 <= 32)
                    {
                        return Avx2.mm256_blend_epi16(Avx2.mm256_srl_epi64(a, count), Avx2.mm256_sra_epi32(a, count), 0b1100_1100);
                    }
                }

                v256 shiftedSign = Avx2.mm256_sll_epi64(sign, subs_epu16(cvtsi64x_si128(64), count));

                return Avx2.mm256_or_si256(shiftedSign, Avx2.mm256_srl_epi64(a, count));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi64(v128 a, int n, bool inRange = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return sll_epi64(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi64(v128 a, int n, bool inRange = false)
        {
            if (Architecture.IsSIMDSupported)
            {
                return srl_epi64(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi64(v128 a, int n, bool inRange = false)
        {
#if TESTING
if (inRange) Assert.IsBetween(n, 0, 63);
#endif

            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return srli_epi64(a, n);
                }

                v128 sign = shuffle_epi32(srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));

                if (constexpr.IS_CONST(n))
                {
                    if (n == 63)
                    {
                        return sign;
                    }
                    if (n <= 32)
                    {
                        return blend_epi16(srli_epi64(a, n), srai_epi32(a, n), 0b1100_1100);
                    }
                }

                v128 shiftedSign = slli_epi64(sign, 64 - n);

                return or_si128(shiftedSign, srli_epi64(a, n));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return sra_epi64(a, cvtsi32_si128(n), inRange);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi64(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi64(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi64(v256 a, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi64(a, cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi64(v256 a, int n, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 64))
                {
                    return a;
                }
                if (constexpr.ALL_GE_EPI64(a, 0, elements))
                {
                    return mm256_srli_epi64(a, n);
                }

                v256 sign = Avx2.mm256_shuffle_epi32(Avx2.mm256_srai_epi32(a, 31), Sse.SHUFFLE(3, 3, 1, 1));

                if (constexpr.IS_CONST(n))
                {
                    if (n == 63)
                    {
                        return sign;
                    }
                    if (n <= 32)
                    {
                        return Avx2.mm256_blend_epi32(mm256_srli_epi64(a, n), mm256_srai_epi32(a, n), 0b1010_1010);
                    }
                }

                v256 shiftedSign = mm256_slli_epi64(sign, 64 - n);

                return Avx2.mm256_or_si256(shiftedSign, mm256_srli_epi64(a, n));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 sllv_epi64(v128 a, v128 b, bool inRange = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return slli_epi64(a, b.SInt0, inRange);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.sllv_epi64(a, b);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = sll_epi64(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _y = sll_epi64(a, shuffle_epi8(b, shuffleMask));

                    return blend_epi16(_x, _y, 0b1111_0000);
                }
                else
                {
                    v128 MASK = cvtsi64x_si128(-1);

                    v128 _x = sll_epi64(a,                                 and_si128(MASK, b));
                    v128 _y = sll_epi64(bsrli_si128(a, 1 * sizeof(ulong)), bsrli_si128(b, 1 * sizeof(ulong)));

                    return unpacklo_epi64(_x, _y);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU64(b, 63);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u64(a, b);
                }
                else
                {
                    return Arm.Neon.vandq_u64(Arm.Neon.vshlq_u64(a, b), Arm.Neon.vcltq_u64(b, set1_epi64x(64)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srlv_epi64(v128 a, v128 b, bool inRange = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64))
                {
                    return setzero_si128();
                }

                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return srli_epi64(a, b.SInt0);
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.srlv_epi64(a, b);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    v128 shuffleMask = new v128(0, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1);
                    v128 _x = srl_epi64(a, shuffle_epi8(b, shuffleMask));
                    shuffleMask = insert_epi8(shuffleMask, 8, 0);
                    v128 _y = srl_epi64(a, shuffle_epi8(b, shuffleMask));

                    return blend_epi16(_x, _y, 0b1111_0000);
                }
                else
                {
                    v128 MASK = cvtsi64x_si128(-1);

                    v128 _x = srl_epi64(a,                                 and_si128(MASK, b));
                    v128 _y = srl_epi64(bsrli_si128(a, 1 * sizeof(ulong)), bsrli_si128(b, 1 * sizeof(ulong)));

                    return unpacklo_epi64(_x, _y);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU64(b, 63);

                if (inRange)
                {
                    return Arm.Neon.vshlq_u64(a, Arm.Neon.vnegq_s64(b));
                }
                else
                {
                    return Arm.Neon.vandq_u64(Arm.Neon.vshlq_u64(a, Arm.Neon.vnegq_s64(b)), Arm.Neon.vcltq_u64(b, set1_epi64x(64)));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srav_epi64(v128 a, v128 b, bool inRange = false)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return srai_epi64(a, b.SInt0, inRange);
                }
                if (constexpr.ALL_GE_EPI64(a, 0))
                {
                    return srlv_epi64(a, b);
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LT_EPI64(b, 32))
                    {
                        v128 shiftLo = srlv_epi64(a, b);
                        v128 shiftHi = srav_epi32(a, shuffle_epi32(b, Sse.SHUFFLE(2, 2, 0, 0)));

                        return Avx2.blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                    }
                    else if (constexpr.ALL_GT_EPI64(b, 31))
                    {
                        v128 shiftHi = srai_epi32(a, 31);
                        v128 shiftLo = srav_epi32(shuffle_epi32(a, Sse.SHUFFLE(3, 3, 1, 1)), sub_epi64(b, set1_epi64x(32)));

                        return Avx2.blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                    }

                    v128 sign = srai_epi64(a, 63);
                    v128 shiftedSign = sllv_epi64(sign, sub_epi64(new v128(64L), b));

                    return or_si128(shiftedSign, srlv_epi64(a, b));
                }
                else
                {
                    return new v128(a.SLong0 >> b.SInt0, a.SLong1 >> b.SInt2);
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
				inRange |= constexpr.ALL_LE_EPU64(b, 63);

                if (inRange)
                {
                    return Arm.Neon.vshlq_s64(a, Arm.Neon.vnegq_s64(b));
                }
                else
                {
                    return Arm.Neon.vbslq_u64(Arm.Neon.vcltq_u64(b, set1_epi64x(64)), Arm.Neon.vshlq_s64(a, Arm.Neon.vnegq_s64(b)), Arm.Neon.vshrq_n_s64(a, 63));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srav_epi64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPU64(b, 64, elements))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_SAME_EPU64(b))
                {
                    return mm256_srai_epi64(a, b.SInt0, elements);
                }

                if (constexpr.ALL_GE_EPI64(a, 0, elements))
                {
                    return Avx2.mm256_srlv_epi64(a, b);
                }
                if (constexpr.ALL_LT_EPI64(b, 32, elements))
                {
                    v256 shiftLo = Avx2.mm256_srlv_epi64(a, b);
                    v256 shiftHi = Avx2.mm256_srav_epi32(a, Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(2, 2, 0, 0)));

                    return Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                }
                else if (constexpr.ALL_GT_EPI64(b, 31, elements))
                {
                    v256 shiftHi = Avx2.mm256_srai_epi32(a, 31);
                    v256 shiftLo = Avx2.mm256_srav_epi32(Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(3, 3, 1, 1)), Avx2.mm256_sub_epi64(b, mm256_set1_epi64x(32)));

                    return Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
                }

                v256 sign = mm256_srai_epi64(a, 63, elements);
                v256 shiftedSign = Avx2.mm256_sllv_epi64(sign, Avx2.mm256_sub_epi64(new v256(64L), b));

                return Avx2.mm256_or_si256(shiftedSign, Avx2.mm256_srlv_epi64(a, b));
            }
            else throw new IllegalInstructionException();
        }
    }
}