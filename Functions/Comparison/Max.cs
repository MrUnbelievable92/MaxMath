using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise maximum of two byte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 max(byte2 a, byte2 b)
        {
            return Sse2.max_epu8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two byte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 max(byte3 a, byte3 b)
        {
            return Sse2.max_epu8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two byte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 max(byte4 a, byte4 b)
        {
            return Sse2.max_epu8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two byte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 max(byte8 a, byte8 b)
        {
            return Sse2.max_epu8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two byte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 max(byte16 a, byte16 b)
        {
            return Sse2.max_epu8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two byte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 max(byte32 a, byte32 b)
        {
            return Avx2.mm256_max_epu8(a, b);
        }


        /// <summary>       Returns the componentwise maximum of two sbyte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 max(sbyte2 a, sbyte2 b)
        {
            return Sse4_1.max_epi8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two sbyte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 max(sbyte3 a, sbyte3 b)
        {
            return Sse4_1.max_epi8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two sbyte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 max(sbyte4 a, sbyte4 b)
        {
            return Sse4_1.max_epi8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two sbyte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 max(sbyte8 a, sbyte8 b)
        {
            return Sse4_1.max_epi8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two sbyte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 max(sbyte16 a, sbyte16 b)
        {
            return Sse4_1.max_epi8(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two sbyte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 max(sbyte32 a, sbyte32 b)
        {
            return Avx2.mm256_max_epi8(a, b);
        }


        /// <summary>       Returns the componentwise maximum of two ushort2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 max(ushort2 a, ushort2 b)
        {
            return Sse4_1.max_epu16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two ushort3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 max(ushort3 a, ushort3 b)
        {
            return Sse4_1.max_epu16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two ushort4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 max(ushort4 a, ushort4 b)
        {
            return Sse4_1.max_epu16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two ushort8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 max(ushort8 a, ushort8 b)
        {
            return Sse4_1.max_epu16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two ushort16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 max(ushort16 a, ushort16 b)
        {
            return Avx2.mm256_max_epu16(a, b);
        }


        /// <summary>       Returns the componentwise maximum of two short2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 max(short2 a, short2 b)
        {
            return Sse2.max_epi16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two short3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 max(short3 a, short3 b)
        {
            return Sse2.max_epi16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two short4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 max(short4 a, short4 b)
        {
            return Sse2.max_epi16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two short8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 max(short8 a, short8 b)
        {
            return Sse2.max_epi16(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two short16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 max(short16 a, short16 b)
        {
            return Avx2.mm256_max_epi16(a, b);
        }


        /// <summary>       Returns the componentwise maximum of two int8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 max(int8 a, int8 b)
        {
            return Avx2.mm256_max_epi32(a, b);
        }


        /// <summary>       Returns the componentwise maximum of two uint8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 max(uint8 a, uint8 b)
        {
            return Avx2.mm256_max_epu32(a, b);
        }


        /// <summary>       Returns the componentwise maximum of two ulong2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 max(ulong2 a, ulong2 b)
        {
            return Sse4_1.blendv_epi8(a, b, Operator.greater_mask_ulong(b, a));
        }

        /// <summary>       Returns the componentwise maximum of two ulong3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 max(ulong3 a, ulong3 b)
        {
            return Avx2.mm256_blendv_epi8(a, b, Operator.greater_mask_ulong(b, a));
        }

        /// <summary>       Returns the componentwise maximum of two ulong4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 max(ulong4 a, ulong4 b)
        {
            return Avx2.mm256_blendv_epi8(a, b, Operator.greater_mask_ulong(b, a));
        }


        /// <summary>       Returns the componentwise maximum of two long2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 max(long2 a, long2 b)
        {
            return Sse4_1.blendv_epi8(a, b, Sse4_2.cmpgt_epi64(b, a));
        }

        /// <summary>       Returns the componentwise maximum of two long3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 max(long3 a, long3 b)
        {
            return Avx2.mm256_blendv_epi8(a, b, Avx2.mm256_cmpgt_epi64(b, a));
        }

        /// <summary>       Returns the componentwise maximum of two long4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 max(long4 a, long4 b)
        {
            return Avx2.mm256_blendv_epi8(a, b, Avx2.mm256_cmpgt_epi64(b, a));
        }


        /// <summary>       Returns the componentwise maximum of two float8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 max(float8 a, float8 b)
        {
            return Avx.mm256_max_ps(a, b);
        }
    }
}