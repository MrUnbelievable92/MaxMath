using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the minimum component of a byte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte2 x)
        {
            return min(x, x.yy).x;
        }

        /// <summary>       Returns the minimum component of a byte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        /// <summary>       Returns the minimum component of a byte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }

        /// <summary>       Returns the minimum component of a byte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte8 x)
        {
            return cmin(min(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        /// <summary>       Returns the minimum component of a byte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte16 x)
        {
            return cmin(min(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        /// <summary>       Returns the minimum component of a byte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the minimum component of an sbyte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte2 x)
        {
            return min(x, x.yy).x;
        }

        /// <summary>       Returns the minimum component of an sbyte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        /// <summary>       Returns the minimum component of an sbyte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }

        /// <summary>       Returns the minimum component of an sbyte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte8 x)
        {
            return cmin(min(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        /// <summary>       Returns the minimum component of an sbyte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte16 x)
        {
            return cmin(min(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        /// <summary>       Returns the minimum component of an sbyte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the minimum component of a short2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short2 x)
        {
            return min(x, x.yy).x;
        }

        /// <summary>       Returns the minimum component of a short3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        /// <summary>       Returns the minimum component of a short4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }

        /// <summary>       Returns the minimum component of a short8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short8 x)
        {
            return cmin(min(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        /// <summary>       Returns the minimum component of a short16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the minimum component of a ushort2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort2 x)
        {
            return min(x, x.yy).x;
        }

        /// <summary>       Returns the minimum component of a ushort3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort3 x)
        {
            return Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0u, 0xFFFF_0000u, uint.MaxValue, uint.MaxValue))).UShort0;
        }

        /// <summary>       Returns the minimum component of a ushort4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort4 x)
        {
            return Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0, 0, -1, -1))).UShort0;
        }

        /// <summary>       Returns the minimum component of a ushort8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort8 x)
        {
            return Sse4_1.minpos_epu16(x).UShort0;
        }

        /// <summary>       Returns the minimum component of a ushort16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the minimum component of an int8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int8 x)
        {
            v128 int4 = Sse4_1.min_epi32(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            int4 = Sse4_1.min_epi32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse4_1.min_epi32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 0, 0, 1))).SInt0;
        }


        /// <summary>       Returns the minimum component of a uint8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint8 x)
        {
            v128 int4 = Sse4_1.min_epu32(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            int4 = Sse4_1.min_epu32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse4_1.min_epu32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 0, 0, 1))).UInt0;
        }


        /// <summary>       Returns the minimum component of a long2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long2 x)
        {
            return min(x, x.yy).x;
        }

        /// <summary>       Returns the minimum component of a long3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        /// <summary>       Returns the minimum component of a long4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }


        /// <summary>       Returns the minimum component of a ulong2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong2 x)
        {
            return min(x, x.yy).x;
        }

        /// <summary>       Returns the minimum component of a ulong3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        /// <summary>       Returns the minimum component of a ulong4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }


        /// <summary>       Returns the minimum component of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float8 x)
        {
            v128 int4 = Sse.min_ps(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            int4 = Sse.min_ps(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse.min_ps(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 0, 0, 1))).Float0;
        }
    }
}