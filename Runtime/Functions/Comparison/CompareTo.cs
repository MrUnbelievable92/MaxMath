using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(int x, int y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(uint x, uint y)
        {
            return touint8(x > y) - touint8(x < y);
        }


        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(long x, long y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(ulong x, ulong y)
        {
            return touint8(x > y) - touint8(x < y);
        }


        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(float x, float y)
        {
            return touint8(x > y) - touint8(x < y);
        }

        /// <summary>       Returns -1 if x is smaller than y, 1 if x is greater than y or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  [return: AssumeRange(-1, 1)]
        public static int compareto(double x, double y)
        {
            return touint8(x > y) - touint8(x < y);
        }
    }
}