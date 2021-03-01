using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    internal static class Mask
    {
        internal static v128 BlendV(v128 a, v128 b, v128 mask)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blendv_epi8(a, b, mask);
            }
            else if (Sse2.IsSse2Supported)
            {
                // UNSAFE - performs bit-by-bit blend and not byte-by-byte
                return Sse2.or_si128(Sse2.and_si128(mask, b),
                                     Sse2.andnot_si128(mask, a));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 BlendEpi16_SSE2(v128 a, v128 b, int mask)
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

        internal static long2 Long2FromInt(int mask)
        {
            return new long2((long)(mask << 63) >> 63, (long)(mask << 62) >> 63);
        }

        internal static long3 Long3FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                int3 shiftBoolsToSignBit = maxmath.shl(mask, new int3(31, 30, 29));

                return (long3)(shiftBoolsToSignBit >> 31);
            }
            else
            {
                return new long3((long)(mask << 63) >> 63, (long)(mask << 62) >> 63, (long)(mask << 61) >> 63);
            }
        }

        internal static long4 Long4FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                int4 shiftBoolsToSignBit = maxmath.shl(mask, new int4(31, 30, 29, 28));

                return (long4)(shiftBoolsToSignBit >> 31);
            }
            else
            {
                return new long4((long)(mask << 63) >> 63, (long)(mask << 62) >> 63, (long)(mask << 61) >> 63, (long)(mask << 60) >> 63);
            }
        }


        internal static int2 Int2FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return maxmath.shl(mask, new int2(31, 30)) >> 31;
            }
            else
            {
                return new int2(mask << 31, mask << 30) >> 31;
            }
        }

        internal static int3 Int3FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                int3 shiftBoolsToSignBit = maxmath.shl(mask, new int3(31, 30, 29));

                return shiftBoolsToSignBit >> 31;
            }
            else
            {
                return new int3(mask << 31, mask << 30, mask << 29) >> 31;
            }
        }

        internal static int4 Int4FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                int4 shiftBoolsToSignBit = maxmath.shl(mask, new int4(31, 30, 29, 28));

                return shiftBoolsToSignBit >> 31;
            }
            else
            {
                return new int4(mask << 31, mask << 30, mask << 29, mask << 28) >> 31;
            }
        }

        internal static int8 Int8FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 shiftBoolsToSignBit = maxmath.shl(mask, new int8(31, 30, 29, 28, 27, 26, 25, 24));

                return shiftBoolsToSignBit >> 31;
            }
            else
            {
                return new int8(mask << 31, mask << 30, mask << 29, mask << 28, mask << 27, mask << 26, mask << 25, mask << 24) >> 31;
            }
        }


        internal static short2 Short2FromInt(int mask)
        {
            return new short2((short)(mask << 15), (short)(mask << 14)) >> 15;
        }

        internal static short16 Short16FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 broadcast = mask;

                int8 shiftBoolsToSignBit_Lo = maxmath.shl(broadcast, new int8(31, 30, 29, 28, 27, 26, 25, 24));
                int8 shiftBoolsToSignBit_Hi = maxmath.shl(broadcast, new int8(23, 22, 21, 20, 19, 18, 17, 16));

                short16 signSaturated = Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi16(shiftBoolsToSignBit_Lo, shiftBoolsToSignBit_Hi),
                                                                     Sse.SHUFFLE(3, 1, 2, 0));
                return signSaturated >> 15;
            }
            else
            {
                return new short16((short)(mask << 15), (short)(mask << 14), (short)(mask << 13), (short)(mask << 12), (short)(mask << 11), (short)(mask << 10), (short)(mask << 9), (short)(mask << 8), (short)(mask << 7), (short)(mask << 6), (short)(mask << 5), (short)(mask << 4), (short)(mask << 3), (short)(mask << 2), (short)(mask << 1), (short)mask) >> 15;
            }
        }

        internal static sbyte32 SByte32FromInt(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 broadcast = mask;

                int8 shiftBoolsToSignBit_LoLo = maxmath.shl(broadcast, new int8(31, 30, 29, 28, 27, 26, 25, 24));
                int8 shiftBoolsToSignBit_LoHi = maxmath.shl(broadcast, new int8(23, 22, 21, 20, 19, 18, 17, 16));
                int8 shiftBoolsToSignBit_HiLo = maxmath.shl(broadcast, new int8(15, 14, 13, 12, 11, 10,  9,  8));
                int8 shiftBoolsToSignBit_HiHi = maxmath.shl(broadcast, new int8( 7,  6,  5,  4,  3,  2,  1,  0));

                short16 signSaturated_Lo = Avx2.mm256_packs_epi32(shiftBoolsToSignBit_LoLo, shiftBoolsToSignBit_LoHi);
                short16 signSaturated_Hi = Avx2.mm256_packs_epi32(shiftBoolsToSignBit_HiLo, shiftBoolsToSignBit_HiHi);

                return Avx2.mm256_permutevar8x32_epi32(Avx2.mm256_packs_epi16(signSaturated_Lo >> 15, signSaturated_Hi >> 15),
                                                       new v256(0, 4, 1, 5, 2, 6, 3, 7));
            }
            else
            {
                return new sbyte32((sbyte16)Short16FromInt(mask), (sbyte16)Short16FromInt(mask >> 16));
            }
        }
    }
}