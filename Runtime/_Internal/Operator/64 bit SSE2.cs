using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 equals_mask_long(v128 x, v128 y)
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
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_long(v128 x, v128 y)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return Sse4_2.cmpgt_epi64(x, y);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 cmp = Sse2.sub_epi64(y, x);

                v128 sign = Sse2.andnot_si128(Sse2.xor_si128(x, y), cmp);
                cmp = Sse2.or_si128(Sse2.andnot_si128(x, y), sign);
                v128 splat = Sse2.srai_epi32(cmp, 31);

                return Sse2.shuffle_epi32(splat, Sse.SHUFFLE(3, 3, 1, 1));
            }
            else throw new CPUFeatureCheckException();
        }
    }
}
