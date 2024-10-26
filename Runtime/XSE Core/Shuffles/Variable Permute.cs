using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 shuffle_epi16(v128 a, v128 b)
        {
            if (Architecture.IsTableLookupSupported)
            {
                b = adds_epu16(b, b);
                b = shuffle_epi8(b, new v128(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                b = adds_epu8(b, new v128(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));

                return shuffle_epi8(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_shuffle_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                b = Avx2.mm256_adds_epu16(b, b);
                b = Avx2.mm256_shuffle_epi8(b, new v256(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14, 0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                b = Avx2.mm256_adds_epu8(b, new v256(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));

                return Avx2.mm256_shuffle_epi8(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 permutevar_epi32(v128 a, v128 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.permutevar_ps(a, b);
            }
            else if (Architecture.IsTableLookupSupported)
            {
                b = slli_epi32(b, 2);
                b = shuffle_epi8(b, new v128(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                b = adds_epu8(b, new v128(0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3));

                return shuffle_epi8(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 permutevar_epi64(v128 a, v128 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.permutevar_pd(a, b);
            }
            if (Architecture.IsTableLookupSupported)
            {
                b = slli_epi64(b, 3);
                b = shuffle_epi8(b, new v128(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                b = adds_epu8(b, new v128(0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7));

                return shuffle_epi8(a, b);
            }
            else throw new IllegalInstructionException();
        }
    }
}
