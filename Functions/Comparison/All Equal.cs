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
            return ((byte16)Avx2.broadcastb_epi8(c)).Equals((byte16)Ssse3.shuffle_epi8(c, new v128(0, 1, 2,   0,   0, 1, 2,   0,  0, 1, 2,   0,   0, 1, 2,   0)));
        }


        /// <summary>       Returns true if all components of a byte4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte4 c)
        {
            return ((byte16)Avx2.broadcastb_epi8(c)).Equals((byte16)Avx2.broadcastd_epi32(c));
        }


        /// <summary>       Returns true if all components of a byte8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte8 c)
        {
            return ((byte16)Avx2.broadcastb_epi8(c)).Equals((byte16)Ssse3.shuffle_epi8(c, new v128(1, 2, 3, 4, 5, 6, 7,    0, 0, 0, 0, 0, 0, 0, 0, 0)));
        }


        /// <summary>       Returns true if all components of a byte16 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte16 c)
        {
            return ((byte16)Avx2.broadcastb_epi8(c)).Equals(c);
        }


        /// <summary>       Returns true if all components of a byte32 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(byte32 c)
        {
            return ((byte32)Avx2.mm256_broadcastb_epi8(Avx.mm256_castsi256_si128(c))).Equals(c);
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
            return ((short8)Avx2.broadcastw_epi16(c)).Equals((short8)Ssse3.shuffle_epi8(c, new v128(0, 1, 2, 3, 4, 5,   0, 1,    0, 1, 2, 3, 4, 5,    0, 1)));
        }

        /// <summary>       Returns true if all components of a short4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short4 c)
        {
            return ((short8)Avx2.broadcastw_epi16(c)).Equals((short8)Avx2.broadcastq_epi64(c));
        }

        /// <summary>       Returns true if all components of a short8 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short8 c)
        {
            return ((short8)Avx2.broadcastw_epi16(c)).Equals(c);
        }

        /// <summary>       Returns true if all components of a short16 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(short16 c)
        {
            return ((short16)Avx2.mm256_broadcastw_epi16(Avx.mm256_castsi256_si128(c))).Equals(c);
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
            return c.xx.Equals(c.yz);
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
            return Avx2.mm256_broadcastd_epi32(Avx.mm256_castsi256_si128(c)).Equals(c);
        }


        /// <summary>       Returns true if all components of a uint3 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(uint3 c)
        {
            return c.xx.Equals(c.yz);
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
            return c.xx.Equals(c.yz);
        }

        /// <summary>       Returns true if all components of a long4 vector have the same value.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool all_eq(long4 c)
        {
            return c.xxxx.Equals(c);
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