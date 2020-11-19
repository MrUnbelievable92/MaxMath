using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short sgnext(short x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (short)((x << (32 - numBits)) >> (32 - numBits));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 sgnext(short2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 sgnext(short3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 sgnext(short4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 sgnext(short8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 sgnext(short16 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sgnext(int x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sgnext(int2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sgnext(int3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sgnext(int4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 sgnext(int8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long sgnext(long x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 sgnext(long2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 sgnext(long3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 sgnext(long4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }
    }
}