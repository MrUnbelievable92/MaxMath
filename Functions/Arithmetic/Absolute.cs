using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 abs(sbyte2 x)
        {
            return X86.Ssse3.abs_epi8(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 abs(sbyte3 x)
        {
            return X86.Ssse3.abs_epi8(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 abs(sbyte4 x)
        {
            return X86.Ssse3.abs_epi8(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 abs(sbyte8 x)
        {
            return X86.Ssse3.abs_epi8(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 abs(sbyte16 x)
        {
            return X86.Ssse3.abs_epi8(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 abs(sbyte32 x)
        {
            return X86.Avx2.mm256_abs_epi8(x);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 abs(short2 x)
        {
            return X86.Ssse3.abs_epi16(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 abs(short3 x)
        {
            return X86.Ssse3.abs_epi16(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 abs(short4 x)
        {
            return X86.Ssse3.abs_epi16(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 abs(short8 x)
        {
            return X86.Ssse3.abs_epi16(x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 abs(short16 x)
        {
            return X86.Avx2.mm256_abs_epi16(x);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 abs(int8 x)
        {
            return X86.Avx2.mm256_abs_epi32(x);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 abs(long2 x)
        {
            long2 mask = X86.Sse4_2.cmpgt_epi64(default(v128), x);

            return (x + mask) ^ mask;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 abs(long3 x)
        {
            long3 mask = X86.Avx2.mm256_cmpgt_epi64(default(v256), x);

            return (x + mask) ^ mask;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 abs(long4 x)
        {
            long4 mask = X86.Avx2.mm256_cmpgt_epi64(default(v256), x);

            return (x + mask) ^ mask;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 abs(float8 x)
        {
            return X86.Avx.mm256_and_ps(x, new v256(maxmath.bitmask32(31)));
        }
    }
}