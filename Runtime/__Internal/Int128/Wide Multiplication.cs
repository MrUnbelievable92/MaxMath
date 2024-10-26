using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

namespace MaxMath
{
    unsafe public readonly partial struct UInt128
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 umul128(ulong x, ulong y)
        {
            ulong lo64 = Common.umul128(x, y, out ulong hi64);

            return new UInt128(lo64, hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 imul128(long x, long y)
        {
            UInt128 lo = umul128((ulong)x, (ulong)y);
            ulong hi = lo.hi64;

            if (constexpr.IS_TRUE(x >= 0 && y >= 0))
            {
                ;
            }
            else
            {
                hi -= (ulong)(((x >> 63) & y) + ((y >> 63) & x));
            }

            return new Int128(lo.lo64, hi);
        }
    }
}
