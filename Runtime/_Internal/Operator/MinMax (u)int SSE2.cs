using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 min_int(v128 a, v128 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epi32(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi32(a, b));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 min_uint(v128 a, v128 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epu32(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, greater_mask_uint(a, b));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 max_int(v128 a, v128 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epi32(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi32(b, a));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 max_uint(v128 a, v128 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epu32(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, greater_mask_uint(b, a));
            }
            else throw new CPUFeatureCheckException();
        }
    }
}