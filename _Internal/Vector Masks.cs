using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // manual sign-extend
    internal static class Mask
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long2 Long2FromInt(int imm8)
        {
            return new long2((long)(((ulong)imm8 << 63)) >> 63, ((long)((ulong)imm8 << 62)) >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long3 Long3FromInt(int imm8)
        {
            int3 shiftBoolsToSignBit = maxmath.shl(new int3(imm8), new int3(31, 30, 29));

            return (long3)(shiftBoolsToSignBit >> 31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long4 Long4FromInt(int imm8)
        {
            int4 shiftBoolsToSignBit = maxmath.shl(new int4(imm8), new int4(31, 30, 29, 28));

            return (long4)(shiftBoolsToSignBit >> 31);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int2 Int2FromInt(int imm8)
        {
            return new int2((imm8 << 31) >> 31, (imm8 << 30) >> 31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int3 Int3FromInt(int imm8)
        {
            int3 shiftBoolsToSignBit = maxmath.shl(new int3(imm8), new int3(31, 30, 29));

            return shiftBoolsToSignBit >> 31;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int4 Int4FromInt(int imm8)
        {
            int4 shiftBoolsToSignBit = maxmath.shl(new int4(imm8), new int4(31, 30, 29, 28));

            return shiftBoolsToSignBit >> 31;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int8 Int8FromInt(int imm8)
        {
            int8 shiftBoolsToSignBit = maxmath.shl(new int8(imm8), new int8(31, 30, 29, 28, 27, 26, 25, 24));

            return shiftBoolsToSignBit >> 31;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 Short16FromInt(int imm8)
        {
            int8 broadcast = imm8;

            int8 shiftBoolsToSignBit_Lo = maxmath.shl(broadcast, new int8(31, 30, 29, 28, 27, 26, 25, 24));
            int8 shiftBoolsToSignBit_Hi = maxmath.shl(broadcast, new int8(23, 22, 21, 20, 19, 18, 17, 16));

            short16 signSaturated = Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi16(shiftBoolsToSignBit_Lo, shiftBoolsToSignBit_Hi),
                                                                 Sse.SHUFFLE(3, 1, 2, 0));
            return signSaturated >> 15;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte16 SByte16FromInt(int imm8)
        {
            int8 broadcast = imm8;

            int8 shiftBoolsToSignBit_Lo = maxmath.shl(broadcast, new int8(31, 30, 29, 28, 27, 26, 25, 24));
            int8 shiftBoolsToSignBit_Hi = maxmath.shl(broadcast, new int8(23, 22, 21, 20, 19, 18, 17, 16));

            short16 signSaturated = Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi16(shiftBoolsToSignBit_Lo, shiftBoolsToSignBit_Hi),
                                                                 Sse.SHUFFLE(3, 1, 2, 0));
            return (sbyte16)(signSaturated >> 15);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 SByte32FromInt(int imm8)
        {
            int8 broadcast = imm8;

            int8 shiftBoolsToSignBit_LoLo = maxmath.shl(broadcast, new int8(31, 30, 29, 28, 27, 26, 25, 24));
            int8 shiftBoolsToSignBit_LoHi = maxmath.shl(broadcast, new int8(23, 22, 21, 20, 19, 18, 17, 16));
            int8 shiftBoolsToSignBit_HiLo = maxmath.shl(broadcast, new int8(15, 14, 13, 12, 11, 10, 9,  8));
            int8 shiftBoolsToSignBit_HiHi = maxmath.shl(broadcast, new int8(7,  6,  5,  4,  3,  2,  1,  0));

            short16 signSaturated_Lo = Avx2.mm256_packs_epi32(shiftBoolsToSignBit_LoLo, shiftBoolsToSignBit_LoHi);
            short16 signSaturated_Hi = Avx2.mm256_packs_epi32(shiftBoolsToSignBit_HiLo, shiftBoolsToSignBit_HiHi);

            return X86.Avx2.mm256_permutevar8x32_epi32(Avx2.mm256_packs_epi16(signSaturated_Lo >> 15, signSaturated_Hi >> 15), 
                                                       new v256(0, 4, 1, 5, 2, 6, 3, 7));
        }
    }
}