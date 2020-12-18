using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    internal static class Hash
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v48(v128 x)
        {
            return (Sse4_1.extract_epi32(x, 0) ^ Sse2.extract_epi16(x, 2)) ^ (Sse2.extract_epi16(x, 2) << 16);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v64(v128 x)
        {
            return Sse4_1.extract_epi32(x, 0) ^ Sse4_1.extract_epi32(x, 1);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v128(v128 x)
        {
            // .NET equivalent to (u)long.GetHashCode() => 
            // 1: Long0 ^ Long1
            // 2: Int0 ^ Int1

            x = Sse2.xor_si128(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 0, 3, 2)));

            return Sse4_1.extract_epi32(x, 0) ^ Sse4_1.extract_epi32(x, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v192(v256 x)
        {
            return (Avx.mm256_extract_epi32(x, 0) ^ Avx.mm256_extract_epi32(x, 1)) ^ Avx.mm256_extract_epi32(x, 2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int v256(v256 x)
        {
            // 0: v128Lo ^ v128Hi

            return v128(Sse2.xor_si128(Avx.mm256_castsi256_si128(x),
                                       Avx2.mm256_extracti128_si256(x, 1)));
        }
    }
}