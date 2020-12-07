using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

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

            v = X86.Sse2.xor_si128(v, X86.Sse2.shuffle_epi32(v, X86.Sse.SHUFFLE(0, 0, 3, 2)));
            v = X86.Sse2.xor_si128(v, X86.Sse2.shuffle_epi32(v, X86.Sse.SHUFFLE(0, 0, 0, 1)));

            return X86.Sse4_1.extract_epi32(v, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int _256bit(v256 v)
        {
            // 0: v128_0 ^ v128_1

            return _128bit(X86.Sse2.xor_si128(X86.Avx.mm256_castsi256_si128(v),
                                              X86.Avx2.mm256_extracti128_si256(v, 1)));
        }
    }
}