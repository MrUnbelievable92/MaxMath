using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise result of rotating the bits of a int2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ror(int2 x, int2 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ror(int3 x, int3 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ror(int4 x, int4 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int8 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -n & 31);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, uint2 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -(int2)n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, uint3 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -(int3)n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, uint4 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -(int4)n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, uint8 n)
        {
            n &= 31;

            return shrl(x, n) | shl(x, -(int8)n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, int2 n)
        {
            return ror(x, (uint2)x);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, int3 n)
        {
            return ror(x, (uint3)x);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, int4 n)
        {
            return ror(x, (uint4)x);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int8 n)
        {
            return ror(x, (uint8)x);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, long2 n)
        {
            n &= 63;

            return shrl(x, n) | shl(x, -n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, long3 n)
        {
            n &= 63;

            return shrl(x, n) | shl(x, -n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, long4 n)
        {
            n &= 63;

            return shrl(x, n) | shl(x, -n & 63);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, ulong2 n)
        {
            n &= 63;

            return shrl(x, n) | shl(x, -(long2)n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, ulong3 n)
        {
            n &= 63;

            return shrl(x, n) | shl(x, -(long3)n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, ulong4 n)
        {
            n &= 63;

            return shrl(x, n) | shl(x, -(long4)n & 63);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, long2 n)
        {
            return ror(x, (ulong2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, long3 n)
        {
            return ror(x, (ulong3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, long4 n)
        {
            return ror(x, (ulong4)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a int2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 rol(int2 x, int2 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 rol(int3 x, int3 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 rol(int4 x, int4 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int8 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -n & 31);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, uint2 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -(int2)n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, uint3 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -(int3)n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, uint4 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -(int4)n & 31);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, uint8 n)
        {
            n &= 31;

            return shl(x, n) | shrl(x, -(int8)n & 31);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, int2 n)
        {
            return rol(x, (uint2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, int3 n)
        {
            return rol(x, (uint3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, int4 n)
        {
            return rol(x, (uint4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, int8 n)
        {
            return rol(x, (uint8)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, long2 n)
        {
            n &= 63;

            return shl(x, n) | shrl(x, -n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, long3 n)
        {
            n &= 63;

            return shl(x, n) | shrl(x, -n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, long4 n)
        {
            n &= 63;

            return shl(x, n) | shrl(x, -n & 63);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, ulong2 n)
        {
            n &= 63;

            return shl(x, n) | shrl(x, -(long2)n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, ulong3 n)
        {
            n &= 63;

            return shl(x, n) | shrl(x, -(long3)n & 63);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, ulong4 n)
        {
            n &= 63;

            return shl(x, n) | shrl(x, -(long4)n & 63);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, long2 n)
        {
            return rol(x, (ulong2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, long3 n)
        {
            return rol(x, (ulong3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, long4 n)
        {
            return rol(x, (ulong4)n);
        }
    }
}
