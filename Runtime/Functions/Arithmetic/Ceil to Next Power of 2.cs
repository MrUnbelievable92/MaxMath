using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ceilpow2(byte2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ceilpow2(byte3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ceilpow2(byte4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ceilpow2(byte8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ceilpow2(byte16 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ceilpow2(byte32 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ceilpow2(sbyte2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ceilpow2(sbyte3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ceilpow2(sbyte4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ceilpow2(sbyte8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ceilpow2(sbyte16 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ceilpow2(sbyte32 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ceilpow2(ushort2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ceilpow2(ushort3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ceilpow2(ushort4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ceilpow2(ushort8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ceilpow2(ushort16 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ceilpow2(short2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ceilpow2(short3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ceilpow2(short4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ceilpow2(short8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ceilpow2(short16 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ceilpow2(int8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ceilpow2(uint8 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ceilpow2(long2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ceilpow2(long3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ceilpow2(long4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return x + 1;
        }


        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ceilpow2(ulong2 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ceilpow2(ulong3 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return x + 1;
        }

        /// <summary>       Returns the result of a componentwise calculation of the smallest power of two greater than or equal to the input.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ceilpow2(ulong4 x)
        {
            x -= 1;
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            x |= x >> 32;

            return x + 1;
        }
    }
}
