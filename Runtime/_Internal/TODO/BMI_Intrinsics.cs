using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long blsi(long x)
        {
            return x & -x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long blsr(long x)
        {
            return x & (x - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long blsmsk(long x)
        {
            return x ^ (x - 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blsi(uint x)
        {
            return x & (uint)-(int)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blsr(uint x)
        {
            return x & (x - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint blsmsk(uint x)
        {
            return x ^ (x - 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blsi(ulong x)
        {
            return x & (ulong)-(long)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blsr(ulong x)
        {
            return x & (x - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong blsmsk(ulong x)
        {
            return x ^ (x - 1);
        }
    }
}