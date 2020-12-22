using DevTools;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a sign-extended sbyte value from a signed integer with numbits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte signextend(sbyte x, int numBits)
        {
Assert.IsBetween(numBits, 1, 7);

            return (sbyte)((x << (32 - numBits)) >> (32 - numBits));
        }

        /// <summary>       Returns a sign-extended sbyte2 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 signextend(sbyte2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 7);

            return (x << (8 - numBits)) >> (8 - numBits);
        }

        /// <summary>       Returns a sign-extended sbyte3 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 signextend(sbyte3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 7);

            return (x << (8 - numBits)) >> (8 - numBits);
        }

        /// <summary>       Returns a sign-extended sbyte4 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 signextend(sbyte4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 7);

            return (x << (8 - numBits)) >> (8 - numBits);
        }

        /// <summary>       Returns a sign-extended sbyte8 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 signextend(sbyte8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 7);

            return (x << (8 - numBits)) >> (8 - numBits);
        }

        /// <summary>       Returns a sign-extended sbyte16 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 signextend(sbyte16 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 7);

            return (x << (8 - numBits)) >> (8 - numBits);
        }

        /// <summary>       Returns a sign-extended sbyte32 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 signextend(sbyte32 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 7);

            return (x << (8 - numBits)) >> (8 - numBits);
        }


        /// <summary>       Returns a sign-extended short value from a signed integer with numbits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short signextend(short x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (short)((x << (32 - numBits)) >> (32 - numBits));
        }

        /// <summary>       Returns a sign-extended short2 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 signextend(short2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended short3 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 signextend(short3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended short4 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 signextend(short4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended short8 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 signextend(short8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }

        /// <summary>       Returns a sign-extended short16 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 signextend(short16 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 15);

            return (x << (16 - numBits)) >> (16 - numBits);
        }


        /// <summary>       Returns a sign-extended int value from a signed integer with numbits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int signextend(int x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended int2 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 signextend(int2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended int3 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 signextend(int3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended int4 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 signextend(int4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }

        /// <summary>       Returns a sign-extended int8 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 signextend(int8 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 31);

            return (x << (32 - numBits)) >> (32 - numBits);
        }


        /// <summary>       Returns a sign-extended long value from a signed integer with numbits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long signextend(long x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }

        /// <summary>       Returns a sign-extended long2 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 signextend(long2 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }

        /// <summary>       Returns a sign-extended long3 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 signextend(long3 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }

        /// <summary>       Returns a sign-extended long4 vector from a vector of signed integers with numBits bits.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 signextend(long4 x, int numBits)
        {
Assert.IsBetween(numBits, 1, 63);

            return (x << (64 - numBits)) >> (64 - numBits);
        }
    }
}