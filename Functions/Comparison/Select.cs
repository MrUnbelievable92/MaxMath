using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 select(byte2 a, byte2 b, bool2 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte2*)&c, default(byte2)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 select(byte3 a, byte3 b, bool3 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte3*)&c, default(byte3)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 select(byte4 a, byte4 b, bool4 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte4*)&c, default(byte4)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 select(byte8 a, byte8 b, bool4x2 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte8*)&c, default(byte8)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 select(byte16 a, byte16 b, bool4x4 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte16*)&c, default(byte16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 select(byte32 a, byte32 b, bool32 c)
        {
            return X86.Avx2.mm256_blendv_epi8(b, a, X86.Avx2.mm256_cmpeq_epi8((v256)c, (byte32)0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 select(sbyte2 a, sbyte2 b, bool2 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte2*)&c, default(byte2)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 select(sbyte3 a, sbyte3 b, bool3 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte3*)&c, default(byte3)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 select(sbyte4 a, sbyte4 b, bool4 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte4*)&c, default(byte4)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 select(sbyte8 a, sbyte8 b, bool4x2 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte8*)&c, default(byte8)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 select(sbyte16 a, sbyte16 b, bool4x4 c)
        {
            return X86.Sse4_1.blendv_epi8(b, a, X86.Sse2.cmpeq_epi8(*(byte16*)&c, default(byte16)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 select(sbyte32 a, sbyte32 b, bool32 c)
        {
            return X86.Avx2.mm256_blendv_epi8(b, a, X86.Avx2.mm256_cmpeq_epi8((v256)c, (byte32)0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 select(ushort2 a, ushort2 b, bool2 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte2*)&c, default(byte2))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 select(ushort3 a, ushort3 b, bool3 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte3*)&c, default(byte3))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 select(ushort4 a, ushort4 b, bool4 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte4*)&c, default(byte4))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 select(ushort8 a, ushort8 b, bool4x2 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte8*)&c, default(byte8))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 select(ushort16 a, ushort16 b, bool4x4 c)
        {
            return X86.Avx2.mm256_blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte16*)&c, default(byte16))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 select(short2 a, short2 b, bool2 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte2*)&c, default(byte2))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 select(short3 a, short3 b, bool3 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte3*)&c, default(byte3))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 select(short4 a, short4 b, bool4 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte4*)&c, default(byte4))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 select(short8 a, short8 b, bool4x2 c)
        {
            return X86.Sse4_1.blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte8*)&c, default(byte8))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 select(short16 a, short16 b, bool4x4 c)
        {
            return X86.Avx2.mm256_blend_epi16(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte16*)&c, default(byte16))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 select(int8 a, int8 b, bool4x2 c)
        {
            return X86.Avx2.mm256_blend_epi32(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte8*)&c, default(byte8))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 select(uint8 a, uint8 b, bool4x2 c)
        {
            return X86.Avx2.mm256_blend_epi32(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte8*)&c, default(byte8))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 select(long2 a, long2 b, bool2 c)
        {
            return X86.Sse4_1.blend_pd(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte2*)&c, default(byte2))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 select(long3 a, long3 b, bool3 c)
        {
            return X86.Avx.mm256_blend_pd(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte3*)&c, default(byte3))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 select(long4 a, long4 b, bool4 c)
        {
            return X86.Avx.mm256_blend_pd(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte4*)&c, default(byte4))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 select(ulong2 a, ulong2 b, bool2 c)
        {
            return X86.Sse4_1.blend_pd(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte2*)&c, default(byte2))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 select(ulong3 a, ulong3 b, bool3 c)
        {
            return X86.Avx.mm256_blend_pd(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte3*)&c, default(byte3))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 select(ulong4 a, ulong4 b, bool4 c)
        {
            return X86.Avx.mm256_blend_pd(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte4*)&c, default(byte4))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 select(float8 a, float8 b, bool4x2 c)
        {
            return X86.Avx.mm256_blend_ps(b, a, X86.Sse2.movemask_epi8(X86.Sse2.cmpeq_epi8(*(byte8*)&c, default(byte8))));
        }
    }
}