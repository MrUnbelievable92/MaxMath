using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 not_si128(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return ternarylogic_si128(a, a, a, TernaryOperation.OxOF);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_not_si256(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_ternarylogic_si256(a, a, a, TernaryOperation.OxOF);
            }
            else throw new IllegalInstructionException();
        }
    }
}
