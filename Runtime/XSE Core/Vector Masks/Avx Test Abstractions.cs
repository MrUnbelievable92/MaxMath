using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mm256_test_all_zeros(v256 a, v256 mask)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_testz_si256(a, mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mm256_test_all_zeros(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_testc_si256(Avx.mm256_setzero_si256(), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mm256_test_all_ones(v256 a, v256 mask)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_testc_si256(a, mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mm256_test_all_ones(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_testc_si256(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mm256_test_mix_zeros_ones(v256 a, v256 mask)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_testnzc_si256(a, mask);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mm256_test_mix_zeros_ones(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_testnzc_si256(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }
    }
}
