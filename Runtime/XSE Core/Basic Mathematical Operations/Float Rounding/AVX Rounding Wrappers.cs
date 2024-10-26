using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_round_ps(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_ps(a, (int)RoundingMode.FROUND_NINT_NOEXC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_trunc_ps(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_ps(a, (int)RoundingMode.FROUND_TRUNC_NOEXC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_floor_ps(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_ps(a, (int)RoundingMode.FROUND_FLOOR_NOEXC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_ceil_ps(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_ps(a, (int)RoundingMode.FROUND_CEIL_NOEXC);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_round_pd(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_pd(a, (int)RoundingMode.FROUND_NINT_NOEXC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_trunc_pd(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_pd(a, (int)RoundingMode.FROUND_TRUNC_NOEXC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_floor_pd(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_pd(a, (int)RoundingMode.FROUND_FLOOR_NOEXC);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_ceil_pd(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_round_pd(a, (int)RoundingMode.FROUND_CEIL_NOEXC);
            }
            else throw new IllegalInstructionException();
        }
    }
}
