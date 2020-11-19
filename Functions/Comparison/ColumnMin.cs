using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte2 x)
        {
            return min(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte8 x)
        {
            return (byte)cmin((ushort8)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte16 x)
        {
            return cmin(min(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cmin(byte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte2 x)
        {
            return min(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte8 x)
        {
            return cmin(min(x, X86.Sse2.shufflelo_epi16(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte16 x)
        {
            return cmin(min(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v8_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cmin(sbyte32 x)
        {
            return cmin(min(x.v16_0, x.v16_16));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short2 x)
        {
            return min(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short8 x)
        {
            return cmin(min(x, X86.Sse2.shuffle_epi32(x, X86.Sse.SHUFFLE(0, 1, 2, 3))).v4_0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cmin(short16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort2 x)
        {
            return min(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort3 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0u, 0xFFFF_0000u, uint.MaxValue, uint.MaxValue))), 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort4 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0, 0, -1, -1))), 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort8 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(x), 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cmin(ushort16 x)
        {
            return cmin(min(x.v8_0, x.v8_8));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cmin(int8 x)
        {
            v128 int4 = X86.Sse4_1.min_epi32(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            int4 = X86.Sse4_1.min_epi32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse4_1.extract_epi32(X86.Sse4_1.min_epi32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 0, 0, 1))), 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cmin(uint8 x)
        {
            v128 int4 = X86.Sse4_1.min_epu32(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            int4 = X86.Sse4_1.min_epu32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return (uint)(X86.Sse4_1.extract_epi32(X86.Sse4_1.min_epu32(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 0, 0, 1))), 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long2 x)
        {
            return min(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cmin(long4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong2 x)
        {
            return min(x, x.yy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong3 x)
        {
            x = min(x, x.zyz);

            return min(x, x.yyy).x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cmin(ulong4 x)
        {
            x = min(x, x.wzww);

            return min(x, x.yyyy).x;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cmin(float8 x)
        {
            v128 int4 = X86.Sse.min_ps(X86.Avx.mm256_castsi256_si128(x), X86.Avx2.mm256_extracti128_si256(x, 1));

            int4 = X86.Sse.min_ps(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 1, 2, 3)));

            return X86.Sse.min_ps(int4, X86.Sse2.shuffle_epi32(int4, X86.Sse.SHUFFLE(0, 0, 0, 1))).Float0;
        }
    }
}