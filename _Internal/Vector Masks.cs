using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Burst replaces compile-time constant masks ("imm8") going through these functions with an immediate 32 bit value. 
    // This is 
    //   a) a workaround for the compiler requiring a constant
    //   b) useful for runtime bit-arrays
    internal static class Mask
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long2 Long2FromInt(int mask)
        {
            return new long2((long)(((ulong)mask << 63)) >> 63, ((long)((ulong)mask << 62)) >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long3 Long3FromInt(int mask)
        {
            int3 shiftBoolsToSignBit = maxmath.shl(new int3(mask), new int3(31, 30, 29));

            return (long3)(shiftBoolsToSignBit >> 31);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long4 Long4FromInt(int mask)
        {
            int4 shiftBoolsToSignBit = maxmath.shl(new int4(mask), new int4(31, 30, 29, 28));

            return (long4)(shiftBoolsToSignBit >> 31);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int2 Int2FromInt(int mask)
        {
            return maxmath.shl(new int2(mask), new int2(31, 30)) >> 31;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int3 Int3FromInt(int mask)
        {
            int3 shiftBoolsToSignBit = maxmath.shl(new int3(mask), new int3(31, 30, 29));

            return shiftBoolsToSignBit >> 31;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int4 Int4FromInt(int mask)
        {
            int4 shiftBoolsToSignBit = maxmath.shl(new int4(mask), new int4(31, 30, 29, 28));

            return shiftBoolsToSignBit >> 31;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int8 Int8FromInt(int mask)
        {
            int8 shiftBoolsToSignBit = maxmath.shl(new int8(mask), new int8(31, 30, 29, 28, 27, 26, 25, 24));

            return shiftBoolsToSignBit >> 31;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short2 Short2FromInt(int mask)
        {
            return new short2((short)(mask << 15), (short)(mask << 14)) >> 15;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 Short16FromInt(int mask)
        {
            int8 broadcast = mask;

            int8 shiftBoolsToSignBit_Lo = maxmath.shl(broadcast, new int8(31, 30, 29, 28, 27, 26, 25, 24));
            int8 shiftBoolsToSignBit_Hi = maxmath.shl(broadcast, new int8(23, 22, 21, 20, 19, 18, 17, 16));

            short16 signSaturated = Avx2.mm256_permute4x64_epi64(Avx2.mm256_packs_epi16(shiftBoolsToSignBit_Lo, shiftBoolsToSignBit_Hi),
                                                                 Sse.SHUFFLE(3, 1, 2, 0));
            return signSaturated >> 15;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 SByte32FromInt(int mask)
        {
            int8 broadcast = mask;

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