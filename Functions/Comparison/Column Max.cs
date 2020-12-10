using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the maximum component of a byte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte2 x)
        {
            return max(x, x.yy).x;
        }

        /// <summary>       Returns the maximum component of a byte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        /// <summary>       Returns the maximum component of a byte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        /// <summary>       Returns the maximum component of a byte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte8 x)
        {
            return cmax(max(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        /// <summary>       Returns the maximum component of a byte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte16 x)
        {
            return cmax(max(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        /// <summary>       Returns the maximum component of a byte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the maximum component of an sbyte2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte2 x)
        {
            return max(x, x.yy).x;
        }

        /// <summary>       Returns the maximum component of an sbyte3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        /// <summary>       Returns the maximum component of an sbyte4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        /// <summary>       Returns the maximum component of an sbyte8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte8 x)
        {
            return cmax(max(x, Sse2.shufflelo_epi16(x, Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        /// <summary>       Returns the maximum component of an sbyte16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte16 x)
        {
            return cmax(max(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        /// <summary>       Returns the maximum component of an sbyte32 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        /// <summary>       Returns the maximum component of a short2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short2 x)
        {
            return max(x, x.yy).x;
        }

        /// <summary>       Returns the maximum component of a short3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        /// <summary>       Returns the maximum component of a short4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        /// <summary>       Returns the maximum component of a short8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short8 x)
        {
            return cmax(max(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        /// <summary>       Returns the maximum component of a short16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the maximum component of a ushort2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort2 x)
        {
            return max(x, x.yy).x;
        }

        /// <summary>       Returns the maximum component of a ushort3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        /// <summary>       Returns the maximum component of a ushort4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        /// <summary>       Returns the maximum component of a ushort8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort8 x)
        {
            return cmax(max(x, Sse2.shuffle_epi32(x, Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        /// <summary>       Returns the maximum component of a ushort16 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        /// <summary>       Returns the maximum component of an int8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmax(int8 x)
        {
            v128 int4 = Sse4_1.max_epi32(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            int4 = Sse4_1.max_epi32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse4_1.extract_epi32(Sse4_1.max_epi32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 0, 0, 1))), 0);
        }


        /// <summary>       Returns the maximum component of a uint8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmax(uint8 x)
        {
            v128 int4 = Sse4_1.max_epu32(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            int4 = Sse4_1.max_epu32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)(Sse4_1.extract_epi32(Sse4_1.max_epu32(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 0, 0, 1))), 0));
        }


        /// <summary>       Returns the maximum component of a long2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long2 x)
        {
            return max(x, x.yy).x;
        }

        /// <summary>       Returns the maximum component of a long3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        /// <summary>       Returns the maximum component of a long4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }


        /// <summary>       Returns the maximum component of a ulong2 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong2 x)
        {
            return max(x, x.yy).x;
        }

        /// <summary>       Returns the maximum component of a ulong3 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        /// <summary>       Returns the maximum component of a ulong4 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }


        /// <summary>       Returns the maximum component of a float8 vector.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmax(float8 x)
        {
            v128 int4 = Sse.max_ps(Avx.mm256_castsi256_si128(x), Avx2.mm256_extracti128_si256(x, 1));

            int4 = Sse.max_ps(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 1, 2, 3)));

            return Sse.max_ps(int4, Sse2.shuffle_epi32(int4, Sse.SHUFFLE(0, 0, 0, 1))).Float0;
        }
    }
}