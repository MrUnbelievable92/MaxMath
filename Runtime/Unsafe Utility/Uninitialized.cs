using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
//    // C# 10
//    unsafe internal struct Uninitialized<T>
//        where T : unmanaged
//    {
//        private readonly T _value;
//
//        [SkipLocalsInit]
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        internal Uninitialized()
//        {
//            T t;
//#pragma warning disable IDE0059
//            T* dummyPtr = &t;
//#pragma warning restore IDE0059
//            _value = t;
//        }
//
//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        public static implicit operator T(Uninitialized<T> value)
//        {
//            return value._value;
//        }
//    }

    unsafe public struct Uninitialized<T>
        where T : unmanaged
    {
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Create()
        {
            T t;
#pragma warning disable IDE0059
            T* dummyPtr = &t;
#pragma warning restore IDE0059
            return t;
        }
    }
}

