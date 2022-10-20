using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpeq_epi64(v128 x, v128 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cmpeq_epi64(x, y);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 cmpeq32 = Sse2.cmpeq_epi32(x, y);

                cmpeq32 = Sse2.and_si128(cmpeq32, Sse2.srli_epi64(cmpeq32, 32));

                return Sse2.shuffle_epi32(cmpeq32, Sse.SHUFFLE(2, 2, 0, 0));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epi64(v128 x, v128 y)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(x, 0))
                {
                    v128 sign = Sse2.srai_epi32(y, 31);
                    return Sse2.shuffle_epi32(sign, Sse.SHUFFLE(3, 3, 1, 1));
                }
                if (constexpr.ALL_LE_EPU64(x, int.MaxValue) && constexpr.ALL_LE_EPU64(y, int.MaxValue))
                {
                    v128 cmp = Sse2.cmpgt_epi32(x, y);
                    return Sse2.shuffle_epi32(cmp, Sse.SHUFFLE(2, 2, 0, 0));
                }


                if (Sse4_2.IsSse42Supported)
                {
                    return Sse4_2.cmpgt_epi64(x, y);
                }
                else
                {
                    v128 cmp = Sse2.sub_epi64(y, x);

                    v128 sign = Sse2.andnot_si128(Sse2.xor_si128(x, y), cmp);
                    cmp = Sse2.or_si128(Sse2.andnot_si128(x, y), sign);
                    v128 splat = Sse2.srai_epi32(cmp, 31);

                    return Sse2.shuffle_epi32(splat, Sse.SHUFFLE(3, 3, 1, 1));
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}