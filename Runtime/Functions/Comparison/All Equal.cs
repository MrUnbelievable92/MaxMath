using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if all components of a byte3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte3 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return c.xxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z;
            }
        }


        /// <summary>       Returns true if all components of a byte4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte4 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return c.xxxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z & c.x == c.w;
            }
        }


        /// <summary>       Returns true if all components of a byte8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte8 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return ((byte8)Ssse3.shuffle_epi8(c, default(v128))).Equals(c);
            }
            else
            {
                return ((c.x0 == c.x1 & c.x0 == c.x2) & (c.x0 == c.x3 & c.x0 == c.x4)) & ((c.x0 == c.x5 & c.x0 == c.x6) & c.x0 == c.x7);
            }
        }


        /// <summary>       Returns true if all components of a byte16 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte16 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return ((byte16)Ssse3.shuffle_epi8(c, default(v128))).Equals(c);
            }
            else
            {
                return (((c.x0 == c.x1 & c.x0 == c.x2) & (c.x0 == c.x3 & c.x0 == c.x4)) & ((c.x0 == c.x5 & c.x0 == c.x6) & (c.x0 == c.x7 & c.x0 == c.x8))) & (((c.x0 == c.x9 & c.x0 == c.x10) & (c.x0 == c.x11 & c.x0 == c.x12)) & ((c.x0 == c.x13 & c.x0 == c.x14) & c.x0 == c.x15));
            }
        }


        /// <summary>       Returns true if all components of a byte32 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ((byte32)Avx2.mm256_broadcastb_epi8(Avx.mm256_castsi256_si128(c))).Equals(c);
            }
            else
            {
                return all_eq(c.v16_0) & all_eq(c.v16_16) & c.v16_0.Equals(c.v16_16);
            }
        }



        /// <summary>       Returns true if all components of an sbyte3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte3 c)
        {
            return all_eq((byte3)c);
        }

        /// <summary>       Returns true if all components of an sbyte4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte4 c)
        {
            return all_eq((byte4)c);
        }

        /// <summary>       Returns true if all components of an sbyte8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte8 c)
        {
            return all_eq((byte8)c);
        }

        /// <summary>       Returns true if all components of an sbyte16 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte16 c)
        {
            return all_eq((byte16)c);
        }

        /// <summary>       Returns true if all components of an sbyte32 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(sbyte32 c)
        {
            return all_eq((byte32)c);
        }


        /// <summary>       Returns true if all components of a short3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short3 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return c.xxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z;
            }
        }

        /// <summary>       Returns true if all components of a short4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short4 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return c.xxxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z & c.x == c.w;
            }
        }

        /// <summary>       Returns true if all components of a short8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short8 c)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return ((short8)Ssse3.shuffle_epi8(c, new v128(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1))).Equals(c);
            }
            else
            {
                return ((c.x0 == c.x1 & c.x0 == c.x2) & (c.x0 == c.x3 & c.x0 == c.x4)) & ((c.x0 == c.x5 & c.x0 == c.x6) & c.x0 == c.x7);
            }
        }

        /// <summary>       Returns true if all components of a short16 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short16 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return ((short16)Avx2.mm256_broadcastw_epi16(Avx.mm256_castsi256_si128(c))).Equals(c);
            }
            else
            {
                return all_eq(c.v8_0) & all_eq(c.v8_8) & c.v8_0.Equals(c.v8_8);
            }
        }


        /// <summary>       Returns true if all components of a ushort3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort3 c)
        {
            return all_eq((short3)c);
        }

        /// <summary>       Returns true if all components of a ushort4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort4 c)
        {
            return all_eq((short4)c);
        }

        /// <summary>       Returns true if all components of a ushort8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort8 c)
        {
            return all_eq((short8)c);
        }

        /// <summary>       Returns true if all components of a ushort16 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ushort16 c)
        {
            return all_eq((short16)c);
        }


        /// <summary>       Returns true if all components of an int3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int3 c)
        {
            return c.xxx.Equals(c);
        }

        /// <summary>       Returns true if all components of an int4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int4 c)
        {
            return c.xxxx.Equals(c);
        }

        /// <summary>       Returns true if all components of an int8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_broadcastd_epi32(Avx.mm256_castsi256_si128(c)).Equals(c);
            }
            else
            {
                return all_eq(c.v4_0) & all_eq(c.v4_4) & c.v4_0.Equals(c.v4_4);
            }
        }


        /// <summary>       Returns true if all components of a uint3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint3 c)
        {
            return c.xxx.Equals(c);
        }

        /// <summary>       Returns true if all components of a uint4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint4 c)
        {
            return c.xxxx.Equals(c);
        }

        /// <summary>       Returns true if all components of a uint8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint8 c)
        {
            return all_eq((int8)c);
        }


        /// <summary>       Returns true if all components of a long3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.xx.Equals(c.yz);
            }
            else
            {
                return c.x == c.y & c.x == c.z;
            }
        }

        /// <summary>       Returns true if all components of a long4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                return c.xxxx.Equals(c);
            }
            else
            {
                return c.x == c.y & c.x == c.z & c.x == c.w;
            }
        }


        /// <summary>       Returns true if all components of a ulong3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ulong3 c)
        {
            return all_eq((long3)c);
        }

        /// <summary>       Returns true if all components of a ulong4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(ulong4 c)
        {
            return all_eq((long4)c);
        }
    }
}