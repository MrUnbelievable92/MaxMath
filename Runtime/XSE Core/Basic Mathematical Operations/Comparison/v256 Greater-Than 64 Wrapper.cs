using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epi64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(a, 0, elements))
                {
                    v256 sign = Avx2.mm256_srai_epi32(b, 31);
                    return Avx2.mm256_shuffle_epi32(sign, Sse.SHUFFLE(3, 3, 1, 1));
                }
                if (constexpr.ALL_LE_EPU64(a, int.MaxValue, elements) && constexpr.ALL_LE_EPU64(b, int.MaxValue, elements))
                {
                    v256 cmp = Avx2.mm256_cmpgt_epi32(a, b);
                    return Avx2.mm256_shuffle_epi32(cmp, Sse.SHUFFLE(2, 2, 0, 0));
                }
                if (constexpr.ALL_POW2_EPU64(a, elements) && constexpr.ALL_GE_EPI64(a, 0, elements) && constexpr.ALL_GE_EPI64(b, 0, elements))
                {
                    return Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(b, mm256_neg_epi64(a)));
                }


                return Avx2.mm256_cmpgt_epi64(a, b);
            }
            else throw new IllegalInstructionException();
        }
    }
}