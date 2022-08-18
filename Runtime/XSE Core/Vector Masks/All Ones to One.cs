using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 negmask_epi8(v128 mask, byte elements = 16)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return abs_epi8(mask, elements);
            }
            else if (Sse2.IsSse2Supported)
            {
                return neg_epi8(mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 negmask_epi16(v128 mask, byte elements = 8)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return abs_epi16(mask, elements);
            }
            else if (Sse2.IsSse2Supported)
            {
                return neg_epi16(mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 negmask_epi32(v128 mask, byte elements = 4)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return abs_epi32(mask, elements);
            }
            else if (Sse2.IsSse2Supported)
            {
                return neg_epi32(mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 negmask_epi64(v128 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return neg_epi64(mask);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_negmask_epi8(v256 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_abs_epi8(mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_negmask_epi16(v256 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_abs_epi16(mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_negmask_epi32(v256 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_abs_epi32(mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_negmask_epi64(v256 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_neg_epi64(mask);
            }
            else throw new IllegalInstructionException();
        }
    }
}
