using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mul_byte(v256 lhs, v256 rhs)
        {
            v256 productEvenIndices = Avx2.mm256_mullo_epi16(lhs, rhs);

            lhs = Avx2.mm256_srli_epi16(lhs, 8);
            rhs = Avx2.mm256_srli_epi16(rhs, 8);

            v256 productOddIndices = Avx2.mm256_slli_epi16(Avx2.mm256_mullo_epi16(lhs, rhs), 8);

            return Avx2.mm256_blendv_epi8(productOddIndices, 
                                          productEvenIndices, 
                                          new v256(0x00FF_00FF));
        }
    }
}