using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    internal static class Hash
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int _128bit(v128 v)
        {
            // .NET equivalent to (u)long.GetHashCode() => 
            // 1: Long0 ^ Long1
            // 2: Int0 ^ Int1

            v = Sse2.xor_si128(v, Sse2.shuffle_epi32(v, Sse.SHUFFLE(0, 0, 3, 2)));
            v = Sse2.xor_si128(v, Sse2.shuffle_epi32(v, Sse.SHUFFLE(0, 0, 0, 1)));

            return Sse4_1.extract_epi32(v, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int _256bit(v256 v)
        {
            // 0: v128_0 ^ v128_1

            return _128bit(Sse2.xor_si128(Avx.mm256_castsi256_si128(v),
                                          Avx2.mm256_extracti128_si256(v, 1)));
        }
    }
}