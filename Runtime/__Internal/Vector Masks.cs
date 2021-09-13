using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    internal static class Mask
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 BlendV(v128 a, v128 b, v128 mask, bool integer = true)
        {
            if (Sse4_1.IsSse41Supported)
            {
                if (integer)
                {
                    return Sse4_1.blendv_epi8(a, b, mask);
                }
                else
                {
                    return Sse4_1.blendv_ps(a, b, mask);
                }
            }
            else if (Sse2.IsSse2Supported)
            {
                // UNSAFE - performs bit-by-bit blend and not byte-by-byte
                if (integer)
                {
                    return Sse2.or_si128(Sse2.and_si128(mask, b),
                                         Sse2.andnot_si128(mask, a));
                }
                else
                {
                    return Sse.or_ps(Sse.and_ps(mask, b),
                                     Sse.andnot_ps(mask, a));
                }
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 BlendEpi16_SSE2(v128 a, v128 b, byte mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return BlendV(a, b, new v128((short)(-((mask >> 0) & 1)),
                                             (short)(-((mask >> 1) & 1)),
                                             (short)(-((mask >> 2) & 1)),
                                             (short)(-((mask >> 3) & 1)),
                                             (short)(-((mask >> 4) & 1)),
                                             (short)(-((mask >> 5) & 1)),
                                             (short)(-((mask >> 6) & 1)),
                                             (short)(-((mask >> 7) & 1))));
            }
            else throw new CPUFeatureCheckException();
        }


        // Burst replaces compile-time constant masks ("mask") going through these functions with an immediate 32 bit value. 
        // This is 
        //   a) a workaround for the compiler requiring a constant
        //   b) useful for runtime bit-arrays

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long2 Long2FromInt(int mask)
        {
            return new long2((long)(mask << 63) >> 63, (long)(mask << 62) >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long3 Long3FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(Int4FromInt(mask));
            }
            else if (Sse4_1.IsSse41Supported)
            {
                return new long3(Sse4_1.cvtepi32_epi64(Int2FromInt(mask)), (long)(mask << 61) >> 63);
            }
            else
            {
                return new long3((long)(mask << 63) >> 63, (long)(mask << 62) >> 63, (long)(mask << 61) >> 63);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long4 Long4FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(Int4FromInt(mask));
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 ints = Int4FromInt(mask);

                return new long4(Sse4_1.cvtepi32_epi64(ints), Sse4_1.cvtepi32_epi64(Sse2.bsrli_si128(ints, 2 * sizeof(int))));
            }
            else
            {
                return new long4((long)(mask << 63) >> 63, (long)(mask << 62) >> 63, (long)(mask << 61) >> 63, (long)(mask << 60) >> 63);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int2FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 shiftBoolsToSignBit = Avx2.sllv_epi32(Sse2.set1_epi32(mask), Sse2.cvtsi64x_si128(31L | (30L << 32)));

                return Sse2.srai_epi32(shiftBoolsToSignBit, 31);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi64x_si128(1L | (2L << 32));

                v128 isolated = Sse2.and_si128(Sse2.set1_epi32(mask), BIT_ISOLATION_MASK);

                return Sse2.cmpeq_epi32(BIT_ISOLATION_MASK, isolated);
            }
            else
            {
                return UnityMathematicsLink.Tov128(new int2(mask << 31, mask << 30) >> 31);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 shiftBoolsToSignBit = Avx2.sllv_epi32(Sse2.set1_epi32(mask), new v128(31, 30, 29, 28));

                return Sse2.srai_epi32(shiftBoolsToSignBit, 31);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3);

                v128 isolated = Sse2.and_si128(Sse2.set1_epi32(mask), BIT_ISOLATION_MASK);

                return Sse2.cmpeq_epi32(BIT_ISOLATION_MASK, isolated);
            }
            else
            {
                return UnityMathematicsLink.Tov128(new int4(mask << 31, mask << 30, mask << 29, mask << 28) >> 31);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 Int8FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shiftBoolsToSignBit = Avx2.mm256_sllv_epi32(Avx.mm256_set1_epi32(mask), new v256(31, 30, 29, 28, 27, 26, 25, 24));

                return Avx2.mm256_srai_epi32(shiftBoolsToSignBit, 31);
            }
            else if (Avx.IsAvxSupported)
            {
                v128 BIT_ISOLATION_MASK_LO = new v128(1 << 0, 1 << 1, 1 << 2, 1 << 3);
                v128 BIT_ISOLATION_MASK_HI = new v128(1 << 4, 1 << 5, 1 << 6, 1 << 7);

                v128 isolated_lo = Sse2.and_si128(Sse2.set1_epi32(mask), BIT_ISOLATION_MASK_LO);
                v128 isolated_hi = Sse2.and_si128(Sse2.set1_epi32(mask), BIT_ISOLATION_MASK_HI);

                isolated_lo = Sse2.cmpeq_epi32(BIT_ISOLATION_MASK_LO, isolated_lo);
                isolated_hi = Sse2.cmpeq_epi32(BIT_ISOLATION_MASK_HI, isolated_hi);

                return Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(isolated_lo), isolated_hi, 1);
            }
            else
            {
                return new int8(mask << 31, mask << 30, mask << 29, mask << 28, mask << 27, mask << 26, mask << 25, mask << 24) >> 31;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short2FromInt(int mask)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi32_si128(0x0002_0001);

                v128 broadcast = Sse2.shufflelo_epi16(Sse2.cvtsi32_si128(mask), Sse.SHUFFLE(0, 0, 0, 0));
                v128 isolated = Sse2.and_si128(broadcast, BIT_ISOLATION_MASK);

                return Sse2.cmpeq_epi16(isolated, BIT_ISOLATION_MASK);
            }
            else
            {
                return new short2((short)(mask << 15), (short)(mask << 14)) >> 15;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short4FromInt(int mask)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi64x_si128(0x0008_0004_0002_0001);

                v128 broadcast = Sse2.shufflelo_epi16(Sse2.cvtsi32_si128(mask), Sse.SHUFFLE(0, 0, 0, 0));
                v128 isolated = Sse2.and_si128(broadcast, BIT_ISOLATION_MASK);

                return Sse2.cmpeq_epi16(isolated, BIT_ISOLATION_MASK);
            }
            else
            {
                return new short4((short)(mask << 3), (short)(mask << 2), (short)(mask << 1), (short)mask) >> 15;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short8FromInt(int mask)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 BIT_ISOLATION_MASK = new v128(0x0008_0004_0002_0001, 0x0080_0040_0020_0010);

                v128 broadcast = Ssse3.shuffle_epi8(Sse2.cvtsi32_si128(mask), Sse2.setzero_si128());
                v128 isolated = Sse2.and_si128(broadcast, BIT_ISOLATION_MASK);

                return Sse2.cmpeq_epi16(isolated, BIT_ISOLATION_MASK);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = new v128(0x0008_0004_0002_0001, 0x0080_0040_0020_0010);

                v128 broadcast = Sse2.shufflelo_epi16(Sse2.cvtsi32_si128(mask), Sse.SHUFFLE(0, 0, 0, 0));
                broadcast = Sse2.unpacklo_epi64(broadcast, broadcast);
                v128 isolated = Sse2.and_si128(broadcast, BIT_ISOLATION_MASK);

                return Sse2.cmpeq_epi16(isolated, BIT_ISOLATION_MASK);
            }
            else
            {
                return new short8((short)(mask << 7), (short)(mask << 6), (short)(mask << 5), (short)(mask << 4), (short)(mask << 3), (short)(mask << 2), (short)(mask << 1), (short)mask) >> 15;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 Short16FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 broadcast = Avx.mm256_set1_epi32(mask);

                v256 shiftBoolsToSignBit_Lo = Avx2.mm256_sllv_epi32(broadcast, new v256(31, 30, 29, 28, 27, 26, 25, 24));
                v256 shiftBoolsToSignBit_Hi = Avx2.mm256_sllv_epi32(broadcast, new v256(23, 22, 21, 20, 19, 18, 17, 16));
                                                                  
                v256 signSaturated = Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi16(shiftBoolsToSignBit_Lo, shiftBoolsToSignBit_Hi),
                                                                  Sse.SHUFFLE(3, 1, 2, 0));
                return Avx2.mm256_srai_epi16(signSaturated, 15);
            }
            else
            {
                return new short16((short)(mask << 15), (short)(mask << 14), (short)(mask << 13), (short)(mask << 12), (short)(mask << 11), (short)(mask << 10), (short)(mask << 9), (short)(mask << 8), (short)(mask << 7), (short)(mask << 6), (short)(mask << 5), (short)(mask << 4), (short)(mask << 3), (short)(mask << 2), (short)(mask << 1), (short)mask) >> 15;
            }
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SByte2FromInt(int mask)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi32_si128(0x02_01); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                v128 shuf = Ssse3.shuffle_epi8(broadcast, Sse2.setzero_si128());

                return Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(shuf, BIT_ISOLATION_MASK));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi32_si128(0x02_01); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                v128 shuf = Sse2.unpacklo_epi8(broadcast, broadcast);

                return Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(shuf, BIT_ISOLATION_MASK));
            }
            else 
            {
                return (byte2)(new int2(mask << 31, mask << 30) >> 31);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SByte4FromInt(int mask)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi32_si128(0x08_04_02_01); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                v128 shuf = Ssse3.shuffle_epi8(broadcast, Sse2.setzero_si128());

                return Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(shuf, BIT_ISOLATION_MASK));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi32_si128(0x08_04_02_01); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                v128 shuf = Sse2.unpacklo_epi8(broadcast, broadcast);
                shuf = Sse2.shufflelo_epi16(shuf, Sse.SHUFFLE(0, 0, 0, 0));

                return Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(shuf, BIT_ISOLATION_MASK));
            }
            else 
            {
                return (byte4)(new int4(mask << 31, mask << 30, mask << 29, mask << 28) >> 31);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SByte8FromInt(int mask)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi64x_si128(unchecked((long)0x80_40_20_10_08_04_02_01)); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                v128 shuf = Ssse3.shuffle_epi8(broadcast, Sse2.setzero_si128());

                return Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(shuf, BIT_ISOLATION_MASK));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.cvtsi64x_si128(unchecked((long)0x80_40_20_10_08_04_02_01)); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                v128 shuf = Sse2.unpacklo_epi8(broadcast, broadcast);
                shuf = Sse2.shufflelo_epi16(shuf, Sse.SHUFFLE(0, 0, 0, 0));

                return Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(shuf, BIT_ISOLATION_MASK));
            }
            else 
            {
                return (byte8)(new int8(mask << 31, mask << 30, mask << 29, mask << 28, mask << 27, mask << 26, mask << 25, mask << 24) >> 31);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SByte16FromInt(int mask)
        {
            if (Ssse3.IsSsse3Supported)
            {
                v128 SHUFFLE_MASK = new v128(0x00_00_00_00_00_00_00_00, 0x01_01_01_01_01_01_01_01); 
                v128 BIT_ISOLATION_MASK = Sse2.set1_epi64x(unchecked((long)0x80_40_20_10_08_04_02_01)); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                broadcast = Ssse3.shuffle_epi8(broadcast, SHUFFLE_MASK);

                return Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(broadcast, BIT_ISOLATION_MASK));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 BIT_ISOLATION_MASK = Sse2.set1_epi64x(unchecked((long)0x80_40_20_10_08_04_02_01)); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);
                broadcast = Sse2.unpacklo_epi8(broadcast, broadcast);
                broadcast = Sse2.unpacklo_epi8(broadcast, broadcast);
                broadcast = Sse2.shuffle_epi32(broadcast, Sse.SHUFFLE(1, 1, 0, 0));

                v128 isolated = Sse2.and_si128(broadcast, BIT_ISOLATION_MASK);

                return Sse2.cmpeq_epi8(isolated, BIT_ISOLATION_MASK);
            }
            else 
            {
                return (sbyte16)(short16)Short16FromInt(mask);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 SByte32FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 SHUFFLE_MASK = Avx.mm256_set_epi64x(0x03_03_03_03_03_03_03_03, 0x02_02_02_02_02_02_02_02, 0x01_01_01_01_01_01_01_01, 0x00_00_00_00_00_00_00_00); 
                v256 BIT_ISOLATION_MASK = Avx.mm256_set1_epi64x(unchecked((long)0x80_40_20_10_08_04_02_01)); 
                
                v256 broadcast = Avx2.mm256_shuffle_epi8(Avx.mm256_set1_epi32(mask), SHUFFLE_MASK);
                v256 isolated = Avx2.mm256_andnot_si256(broadcast, BIT_ISOLATION_MASK);

                return Avx2.mm256_cmpeq_epi8(isolated, Avx.mm256_setzero_si256());
            }
            else if (Ssse3.IsSsse3Supported)
            {
                v128 SHUFFLE_MASK_LO = Sse2.set_epi64x(0x01_01_01_01_01_01_01_01, 0x00_00_00_00_00_00_00_00); 
                v128 SHUFFLE_MASK_HI = Sse2.set_epi64x(0x03_03_03_03_03_03_03_03, 0x02_02_02_02_02_02_02_02); 
                v128 BIT_ISOLATION_MASK = Sse2.set1_epi64x(unchecked((long)0x80_40_20_10_08_04_02_01)); 

                v128 broadcast = Sse2.cvtsi32_si128(mask);

                v128 broadcast_lo = Ssse3.shuffle_epi8(broadcast, SHUFFLE_MASK_LO);
                v128 broadcast_hi = Ssse3.shuffle_epi8(broadcast, SHUFFLE_MASK_HI);

                v128 isolated_lo = Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(broadcast_lo, BIT_ISOLATION_MASK));
                v128 isolated_hi = Sse2.cmpeq_epi8(BIT_ISOLATION_MASK, Sse2.and_si128(broadcast_hi, BIT_ISOLATION_MASK));

                return new sbyte32(isolated_lo, isolated_hi);
            }
            else
            {
                return new sbyte32(SByte16FromInt(mask), SByte16FromInt(mask >> 16));
            }
        }
    }
}