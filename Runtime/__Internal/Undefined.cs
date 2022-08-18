using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe internal static class Utils
    {
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Undefined<T>()
            where T : unmanaged
        {
            T t;
            T* dummy = &t;

            return t;
        }
    }
}