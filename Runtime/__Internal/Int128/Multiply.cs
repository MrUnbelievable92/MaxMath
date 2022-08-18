using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

namespace MaxMath
{
    unsafe public partial struct UInt128
    {
        internal static partial class Common
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 umul256(UInt128 left, UInt128 right, out UInt128 high, bool lo = true)
            {
                ulong lolo = Unity.Burst.Intrinsics.Common.umul128(left.lo64, right.lo64, out ulong lohi);
                ulong m1lo = Unity.Burst.Intrinsics.Common.umul128(left.hi64, right.lo64, out ulong m1hi);
                ulong m2lo = Unity.Burst.Intrinsics.Common.umul128(left.lo64, right.hi64, out ulong m2hi);
                ulong hilo = Unity.Burst.Intrinsics.Common.umul128(left.hi64, right.hi64, out ulong hihi);
    
                high = (new UInt128(hilo, hihi) + m1hi) + ((new UInt128(m2lo, m2hi) + m1lo) + lohi).hi64;
    
                return lo ? left * right : 0;
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 imul256(Int128 x, Int128 y, out Int128 hi)
            {
                UInt128 lo = umul256(x.intern, y.intern, out UInt128 high);
    
                if (Xse.constexpr.IS_TRUE(x >= 0 && y >= 0))
                {
                    ;
                }
                else
                {
                    ulong xMask = (ulong)((long)y.hi64 >> 63);
                    ulong yMask = (ulong)((long)x.hi64 >> 63);
    
                    x = new Int128(x.lo64 & xMask, x.hi64 & xMask);
                    y = new Int128(y.lo64 & yMask, y.hi64 & yMask);
                    high -= (UInt128)(x + y);
                }
                    
                hi = (Int128)high;
                return (Int128)lo;
            }
        }
    }
}
