using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpeq_epi64(v128 a, v128 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cmpeq_epi64(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 cmpeq32 = cmpeq_epi32(a, b);

                cmpeq32 = and_si128(cmpeq32, srli_epi64(cmpeq32, 32));

                return shuffle_epi32(cmpeq32, Sse.SHUFFLE(2, 2, 0, 0));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vceqq_u64(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epi64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(a, 0))
                {
                    v128 sign = srai_epi32(b, 31);
                    return shuffle_epi32(sign, Sse.SHUFFLE(3, 3, 1, 1));
                }
                if (constexpr.ALL_LE_EPU64(a, int.MaxValue) && constexpr.ALL_LE_EPU64(b, int.MaxValue))
                {
                    v128 cmp = cmpgt_epi32(a, b);
                    return shuffle_epi32(cmp, Sse.SHUFFLE(2, 2, 0, 0));
                }
                if (constexpr.ALL_POW2_EPU64(a) && constexpr.ALL_GE_EPI64(a, 0) && constexpr.ALL_GE_EPI64(b, 0))
                {
                    return cmpeq_epi64(setzero_si128(), and_si128(b, neg_epi64(a)));
                }


                if (Sse4_2.IsSse42Supported)
                {
                    return Sse4_2.cmpgt_epi64(a, b);
                }
                else
                {
                    v128 cmp = sub_epi64(b, a);

                    v128 sign = andnot_si128(xor_si128(a, b), cmp);
                    cmp = or_si128(andnot_si128(a, b), sign);
                    v128 splat = srai_epi32(cmp, 31);

                    return shuffle_epi32(splat, Sse.SHUFFLE(3, 3, 1, 1));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgtq_s64(a, b);
            }
            else throw new IllegalInstructionException();
        }
    }
}