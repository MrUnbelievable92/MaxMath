using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    internal static class Hash
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int _128bit(v128 v)
        {
            return (((ulong)v.ULong0.GetHashCode() << 32) | (ulong)v.ULong1.GetHashCode()).GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int _256bit(v256 v)
        {
            ulong2 temp = (((ulong2)new int2(v.ULong0.GetHashCode(), v.ULong1.GetHashCode())) << 32)
                          |
                          ((ulong2)new int2(v.ULong2.GetHashCode(), v.ULong3.GetHashCode()));

            return ((temp.x << 32) | temp.y).GetHashCode();
        }
    }
}