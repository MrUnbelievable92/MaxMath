using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte2 x)
        {
            return max(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte8 x)
        {
            return cmax(max(x, X86.Sse2.shufflelo_epi16(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte16 x)
        {
            return cmax(max(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmax(byte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte2 x)
        {
            return max(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte8 x)
        {
            return cmax(max(x, X86.Sse2.shufflelo_epi16(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte16 x)
        {
            return cmax(max(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmax(sbyte32 x)
        {
            return cmax(max(x.v16_0, x.v16_16));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short2 x)
        {
            return max(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short8 x)
        {
            return cmax(max(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmax(short16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort2 x)
        {
            return max(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort8 x)
        {
            return cmax(max(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmax(ushort16 x)
        {
            return cmax(max(x.v8_0, x.v8_8));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmax(int8 x)
        {
            v128 int4 = X86.Sse4_1.max_epi32(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            int4 = X86.Sse4_1.max_epi32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(X86.Sse4_1.max_epi32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 0, 0, 1))), 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmax(uint8 x)
        {
            v128 int4 = X86.Sse4_1.max_epu32(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            int4 = X86.Sse4_1.max_epu32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)(X86.Sse4_1.extract_epi32(X86.Sse4_1.max_epu32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 0, 0, 1))), 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long2 x)
        {
            return max(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmax(long4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong2 x)
        {
            return max(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong3 x)
        {
            x = max(x, x.zyz);

            return max(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmax(ulong4 x)
        {
            x = max(x, x.wzww);

            return max(x, x.yyyy).x;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmax(float8 x)
        {
            v128 int4 = X86.Sse.max_ps(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            int4 = X86.Sse.max_ps(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse.max_ps(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 0, 0, 1))).Float0;
        }
    }
}