using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long imul128(long x, long y, out long hi)
        {
            ulong lo = Common.umul128((ulong)x, (ulong)y, out ulong high);

            if (Xse.constexpr.IS_TRUE(x >= 0 && y >= 0))
            {
                ;
            }
            else
            {
                high -= (ulong)(((x >> 63) & y) + ((y >> 63) & x));
            }
                
            hi = (long)high;
            return (long)lo;
        }
    }
}