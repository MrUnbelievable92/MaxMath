using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        // BEXTR 	Bit field extract (with register) 	(src >> start) & ((1 << len) - 1)





        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int blsi(int x)
        {
            return x & -x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int blsr(int x)
        {
            return x & (x - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int blsmsk(int x)
        {
            return x ^ (x - 1);
        }
    }
}