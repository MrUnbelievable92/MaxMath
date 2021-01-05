using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Simple hashing based on the .NET standard => XOR
    internal static class Hash
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v24(v128 x)
        {
            return Sse2.and_si128(x, new v128(maxmath.bitmask32(24), 0, 0, 0)).SInt0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v48(v128 x)
        {
            return Sse2.xor_si128(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 2, 2))).SInt0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v64(v128 x)
        {
            return Sse2.xor_si128(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 0, 3, 2))).SInt0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v128(v128 x)
        {
            x = Sse2.xor_si128(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 3, 2)));

            return Sse2.xor_si128(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v192(v256 x)
        {
            v256 temp = Avx2.mm256_xor_si256(x, Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 0, 0, 1)));

            return v64(Sse2.xor_si128(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v256(v256 x)
        {
            return v128(Sse2.xor_si128(Avx.mm256_castsi256_si128(x),
                                       Avx2.mm256_extracti128_si256(x, 1)));
        }
    }
}