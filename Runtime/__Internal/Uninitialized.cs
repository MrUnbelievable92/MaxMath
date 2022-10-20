using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe internal static class Utility
    {
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T Uninitialized<T>()
            where T : unmanaged
        {
            T t;
            T* dummyPtr = &t;

            return t;
        }
    }
}