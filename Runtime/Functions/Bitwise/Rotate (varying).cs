using System.Runtime.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise result of rotating the bits of a int2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ror(int2 x, int2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int2(math.ror(x.x, n.x), math.ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ror(int3 x, int3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int3(math.ror(x.x, n.x), math.ror(x.y, n.y), math.ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ror(int4 x, int4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int4(math.ror(x.x, n.x), math.ror(x.y, n.y), math.ror(x.z, n.z), math.ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shrl(x, n) | shl(x, -n & 31);
            }
            else
            {
                return new int8(math.ror(x.x0, n.x0), math.ror(x.x1, n.x1), math.ror(x.x2, n.x2), math.ror(x.x3, n.x3), math.ror(x.x4, n.x4), math.ror(x.x5, n.x5), math.ror(x.x6, n.x6), math.ror(x.x7, n.x7));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ror(int2 x, uint2 n)
        {
            return ror(x, (int2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ror(int3 x, uint3 n)
        {
            return ror(x, (int3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ror(int4 x, uint4 n)
        {
            return ror(x, (int4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, uint8 n)
        {
            return ror(x, (int8)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, uint2 n)
        {
            return (uint2)ror((int2)x, (int2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, uint3 n)
        {
            return (uint3)ror((int3)x, (int3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, uint4 n)
        {
            return (uint4)ror((int4)x, (int4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, uint8 n)
        {
            return (uint8)ror((int8)x, (int8)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, int2 n)
        {
            return ror(x, (uint2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, int3 n)
        {
            return ror(x, (uint3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, int4 n)
        {
            return ror(x, (uint4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int8 n)
        {
            return ror(x, (uint8)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, long2 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 63;

                return shrl(x, n) | shl(x, -n & 63);
            }
            else
            {
                return new long2(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 63;

                return shrl(x, n) | shl(x, -n & 63);
            }
            else
            {
                return new long3(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y), math.ror(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 63;

                return shrl(x, n) | shl(x, -n & 63);
            }
            else
            {
                return new long4(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y), math.ror(x.z, (int)n.z), math.ror(x.w, (int)n.w));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, ulong2 n)
        {
            return ror(x, (long2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, ulong3 n)
        {
            return ror(x, (long3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, ulong4 n)
        {
            return ror(x, (long4)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, ulong2 n)
        {
            return (ulong2)ror((long2)x, (long2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, ulong3 n)
        {
            return (ulong3)ror((long3)x, (long3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 right by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, ulong4 n)
        {
            return (ulong4)ror((long4)x, (long4)n);
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
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int2(math.rol(x.x, n.x), math.rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 rol(int3 x, int3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int3(math.rol(x.x, n.x), math.rol(x.y, n.y), math.rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 rol(int4 x, int4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int4(math.rol(x.x, n.x), math.rol(x.y, n.y), math.rol(x.z, n.z), math.rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a int8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 31;

                return shl(x, n) | shrl(x, -n & 31);
            }
            else
            {
                return new int8(math.rol(x.x0, n.x0), math.rol(x.x1, n.x1), math.rol(x.x2, n.x2), math.rol(x.x3, n.x3), math.rol(x.x4, n.x4), math.rol(x.x5, n.x5), math.rol(x.x6, n.x6), math.rol(x.x7, n.x7));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, uint2 n)
        {
            return (uint2)rol((int2)x, (int2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, uint3 n)
        {
            return (uint3)rol((int3)x, (int3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, uint4 n)
        {
            return (uint4)rol((int4)x, (int4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, uint8 n)
        {
            return (uint8)rol((int8)x, (int8)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a uint2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 rol(int2 x, uint2 n)
        {
            return rol(x, (int2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 rol(int3 x, uint3 n)
        {
            return rol(x, (int3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 rol(int4 x, uint4 n)
        {
            return rol(x, (int4)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a uint8 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, uint8 n)
        {
            return rol(x, (int8)n);
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
            if (Avx2.IsAvx2Supported)
            {
                n &= 63;

                return shl(x, n) | shrl(x, -n & 63);
            }
            else
            {
                return new long2(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, long3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 63;

                return shl(x, n) | shrl(x, -n & 63);
            }
            else
            {
                return new long3(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y), math.rol(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, long4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                n &= 63;

                return shl(x, n) | shrl(x, -n & 63);
            }
            else
            {
                return new long4(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y), math.rol(x.z, (int)n.z), math.rol(x.w, (int)n.w));
            }
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a long2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, ulong2 n)
        {
            return rol(x, (long2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, ulong3 n)
        {
            return rol(x, (long3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a long4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, ulong4 n)
        {
            return rol(x, (long4)n);
        }


        /// <summary>       Returns the componentwise result of rotating the bits of a ulong2 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, ulong2 n)
        {
            return (ulong2)rol((long2)x, (long2)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong3 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, ulong3 n)
        {
            return (ulong3)rol((long3)x, (long3)n);
        }

        /// <summary>       Returns the componentwise result of rotating the bits of a ulong4 left by a number of bits specified in the corresponing component in n.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, ulong4 n)
        {
            return (ulong4)rol((long4)x, (long4)n);
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
