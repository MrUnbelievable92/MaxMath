using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    internal static class Cast
    {
        internal const float F32_PRECISION_THRESHOLD = 8_388_608f;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UShortToFloat(v128 v)
        {
            return X86.Sse.sub_ps(X86.Sse2.unpacklo_epi16(v, new ushort4(0x4B00)), new v128(F32_PRECISION_THRESHOLD));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v128 v)
        {
            return X86.Ssse3.shuffle_epi8(v, new v128(0, 2, 4, 6, 8, 10, 12, 14,    0, 0, 0, 0, 0, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v256 v)
        {
            return X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permute4x64_epi64(X86.Avx2.mm256_shuffle_epi8(v, new v256(0, 2, 4, 6, 8, 10, 12, 14,   0, 0, 0, 0, 0, 0, 0, 0,   0, 2, 4, 6, 8, 10, 12, 14,    0, 0, 0, 0, 0, 0, 0, 0)),
                                                                                  X86.Sse.SHUFFLE(0, 0,   2, 0)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToByte4(v128 v)
        {
            return X86.Ssse3.shuffle_epi8(v, new v128(0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToByte8(v256 v)
        {
            v = X86.Avx2.mm256_shuffle_epi8(v, new v256(0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,    0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

            return X86.Sse2.unpacklo_epi32(X86.Avx.mm256_castsi256_si128(v),
                                           X86.Avx2.mm256_extracti128_si256(v, 1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int2ToShort2(v128 v)
        {
            return X86.Sse2.shufflelo_epi16(v, X86.Sse.SHUFFLE(3, 3, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToShort4(v128 v)
        {
            return X86.Ssse3.shuffle_epi8(v, new v128(0, 1,   4, 5,   8, 9,    12, 13,    0, 0, 0, 0, 0, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToShort8(v256 v)
        {
            v = X86.Avx2.mm256_shuffle_epi8(v, new v256(0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0,   0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0));

            return X86.Sse2.unpacklo_epi64(X86.Avx.mm256_castsi256_si128(v), 
                                           X86.Avx2.mm256_extracti128_si256(v, 1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToByte2(v128 v)
        {
            return X86.Ssse3.shuffle_epi8(v, new v128(0, 8,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToByte4(v256 v)
        {
            return Int4ToByte4(Long4ToInt4(v));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToShort2(v128 v)
        {
            return X86.Ssse3.shuffle_epi8(v, new v128(0, 1, 8, 9,      0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToShort4(v256 v)
        {
            return Int4ToShort4(Long4ToInt4(v));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToInt2(v128 v)
        {
            return X86.Sse2.shuffle_epi32(v, X86.Sse.SHUFFLE(3, 3, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToInt4(v256 v)
        {
            return X86.Avx.mm256_castsi256_si128(X86.Avx2.mm256_permutevar8x32_epi32(v, new v256(0, 2, 4, 6,   0, 0, 0, 0)));
        }
    }
}