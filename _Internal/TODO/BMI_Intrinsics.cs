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
    }
}