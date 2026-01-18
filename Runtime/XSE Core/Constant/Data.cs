using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        private static v128 NIBBLE_MASK
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return set1_epi8(0x0F);
                }
                else throw new IllegalInstructionException();
            }
        }

        private static v256 MM256_NIBBLE_MASK
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx.IsAvxSupported)
                {
                    return mm256_set1_epi8(0x0F);
                }
                else throw new IllegalInstructionException();
            }
        }


        private static v128 SQUARES_EPU4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return new v128(0, 1, 4, 9, 16, 25, 36, 49, 64, 81, 100, 121, 144, 169, 196, 225);
                }
                else throw new IllegalInstructionException();
            }
        }

        private static v256 MM256_SQUARES_EPU4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx.IsAvxSupported)
                {
                    return new v256(SQUARES_EPU4, SQUARES_EPU4);
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
