
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise minimum of two byte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 min(byte2 a, byte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epu8(a, b);
            }
            else
            {
                return new byte2((byte)math.min((uint)a.x, (uint)b.x), (byte)math.min((uint)a.y, (uint)b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two byte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 min(byte3 a, byte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epu8(a, b);
            }
            else
            {
                return new byte3((byte)math.min((uint)a.x, (uint)b.x), (byte)math.min((uint)a.y, (uint)b.y), (byte)math.min((uint)a.z, (uint)b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two byte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 min(byte4 a, byte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epu8(a, b);
            }
            else
            {
                return new byte4((byte)math.min((uint)a.x, (uint)b.x), (byte)math.min((uint)a.y, (uint)b.y), (byte)math.min((uint)a.z, (uint)b.z), (byte)math.min((uint)a.w, (uint)b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two byte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 min(byte8 a, byte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epu8(a, b);
            }
            else
            {
                return new byte8((byte)math.min((uint)a.x0, (uint)b.x0), (byte)math.min((uint)a.x1, (uint)b.x1), (byte)math.min((uint)a.x2, (uint)b.x2), (byte)math.min((uint)a.x3, (uint)b.x3), (byte)math.min((uint)a.x4, (uint)b.x4), (byte)math.min((uint)a.x5, (uint)b.x5), (byte)math.min((uint)a.x6, (uint)b.x6), (byte)math.min((uint)a.x7, (uint)b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two byte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 min(byte16 a, byte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epu8(a, b);
            }
            else
            {
                return new byte16((byte)math.min((uint)a.x0, (uint)b.x0), (byte)math.min((uint)a.x1, (uint)b.x1), (byte)math.min((uint)a.x2, (uint)b.x2), (byte)math.min((uint)a.x3, (uint)b.x3), (byte)math.min((uint)a.x4, (uint)b.x4), (byte)math.min((uint)a.x5, (uint)b.x5), (byte)math.min((uint)a.x6, (uint)b.x6), (byte)math.min((uint)a.x7, (uint)b.x7), (byte)math.min((uint)a.x8, (uint)b.x8), (byte)math.min((uint)a.x9, (uint)b.x9), (byte)math.min((uint)a.x10, (uint)b.x10), (byte)math.min((uint)a.x11, (uint)b.x11), (byte)math.min((uint)a.x12, (uint)b.x12), (byte)math.min((uint)a.x13, (uint)b.x13), (byte)math.min((uint)a.x14, (uint)b.x14), (byte)math.min((uint)a.x15, (uint)b.x15));
            }
        }

        /// <summary>       Returns the componentwise minimum of two byte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 min(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epu8(a, b);
            }
            else
            {
                return new byte32(min(a.v16_0, b.v16_0), min(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the componentwise minimum of two sbyte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 min(sbyte2 a, sbyte2 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(a, b));
            }
            else
            {
                return new sbyte2((sbyte)math.min(a.x, b.x), (sbyte)math.min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two sbyte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 min(sbyte3 a, sbyte3 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(a, b));
            }
            else
            {
                return new sbyte3((sbyte)math.min(a.x, b.x), (sbyte)math.min(a.y, b.y), (sbyte)math.min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two sbyte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 min(sbyte4 a, sbyte4 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(a, b));
            }
            else
            {
                return new sbyte4((sbyte)math.min(a.x, b.x), (sbyte)math.min(a.y, b.y), (sbyte)math.min(a.z, b.z), (sbyte)math.min(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two sbyte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 min(sbyte8 a, sbyte8 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(a, b));
            }
            else
            {
                return new sbyte8((sbyte)math.min(a.x0, b.x0), (sbyte)math.min(a.x1, b.x1), (sbyte)math.min(a.x2, b.x2), (sbyte)math.min(a.x3, b.x3), (sbyte)math.min(a.x4, b.x4), (sbyte)math.min(a.x5, b.x5), (sbyte)math.min(a.x6, b.x6), (sbyte)math.min(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two sbyte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 min(sbyte16 a, sbyte16 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(a, b));
            }
            else
            {
                return new sbyte16((sbyte)math.min(a.x0, b.x0), (sbyte)math.min(a.x1, b.x1), (sbyte)math.min(a.x2, b.x2), (sbyte)math.min(a.x3, b.x3), (sbyte)math.min(a.x4, b.x4), (sbyte)math.min(a.x5, b.x5), (sbyte)math.min(a.x6, b.x6), (sbyte)math.min(a.x7, b.x7), (sbyte)math.min(a.x8, b.x8), (sbyte)math.min(a.x9, b.x9), (sbyte)math.min(a.x10, b.x10), (sbyte)math.min(a.x11, b.x11), (sbyte)math.min(a.x12, b.x12), (sbyte)math.min(a.x13, b.x13), (sbyte)math.min(a.x14, b.x14), (sbyte)math.min(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise minimum of two sbyte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 min(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epi8(a, b);
            }
            else
            {
                return new sbyte32(min(a.v16_0, b.v16_0), min(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the componentwise minimum of two ushort2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 min(ushort2 a, ushort2 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(a, b));
            }
            else
            {
                return new ushort2((ushort)math.min((uint)a.x, (uint)b.x), (ushort)math.min((uint)a.y, (uint)b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two ushort3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 min(ushort3 a, ushort3 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(a, b));
            }
            else
            {
                return new ushort3((ushort)math.min((uint)a.x, (uint)b.x), (ushort)math.min((uint)a.y, (uint)b.y), (ushort)math.min((uint)a.z, (uint)b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two ushort4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 min(ushort4 a, ushort4 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(a, b));
            }
            else
            {
                return new ushort4((ushort)math.min((uint)a.x, (uint)b.x), (ushort)math.min((uint)a.y, (uint)b.y), (ushort)math.min((uint)a.z, (uint)b.z), (ushort)math.min((uint)a.w, (uint)b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two ushort8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 min(ushort8 a, ushort8 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.min_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(a, b));
            }
            else
            {
                return new ushort8((ushort)math.min((uint)a.x0, (uint)b.x0), (ushort)math.min((uint)a.x1, (uint)b.x1), (ushort)math.min((uint)a.x2, (uint)b.x2), (ushort)math.min((uint)a.x3, (uint)b.x3), (ushort)math.min((uint)a.x4, (uint)b.x4), (ushort)math.min((uint)a.x5, (uint)b.x5), (ushort)math.min((uint)a.x6, (uint)b.x6), (ushort)math.min((uint)a.x7, (uint)b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two ushort16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 min(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epu16(a, b);
            }
            else
            {
                return new ushort16(min(a.v8_0, b.v8_0), min(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the componentwise minimum of two short2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 min(short2 a, short2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(a, b);
            }
            else
            {
                return new short2((short)math.min(a.x, b.x), (short)math.min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two short3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 min(short3 a, short3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(a, b);
            }
            else
            {
                return new short3((short)math.min(a.x, b.x), (short)math.min(a.y, b.y), (short)math.min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two short4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 min(short4 a, short4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(a, b);
            }
            else
            {
                return new short4((short)math.min(a.x, b.x), (short)math.min(a.y, b.y), (short)math.min(a.z, b.z), (short)math.min(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two short8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 min(short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.min_epi16(a, b);
            }
            else
            {
                return new short8((short)math.min(a.x0, b.x0), (short)math.min(a.x1, b.x1), (short)math.min(a.x2, b.x2), (short)math.min(a.x3, b.x3), (short)math.min(a.x4, b.x4), (short)math.min(a.x5, b.x5), (short)math.min(a.x6, b.x6), (short)math.min(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two short16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 min(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epi16(a, b);
            }
            else
            {
                return new short16(min(a.v8_0, b.v8_0), min(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the componentwise minimum of two int8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 min(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epi32(a, b);
            }
            else
            {
                return new int8(math.min(a.v4_0, b.v4_0), math.min(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise minimum of two uint8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 min(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epu32(a, b);
            }
            else
            {
                return new uint8(math.min(a.v4_0, b.v4_0), math.min(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise minimum of two ulong2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 min(ulong2 a, ulong2 b)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return Sse4_1.blendv_epi8(a, b, Operator.greater_mask_ulong(a, b));
            }
            else
            {
                return new ulong2(math.min(a.x, b.x), math.min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two ulong3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 min(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Operator.greater_mask_ulong(a, b));
            }
            else
            {
                return new ulong3(min(a.xy, b.xy), math.min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two ulong4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 min(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Operator.greater_mask_ulong(a, b));
            }
            else
            {
                return new ulong4(min(a.xy, b.xy), min(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise minimum of two long2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 min(long2 a, long2 b)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return Sse4_1.blendv_epi8(a, b, Sse4_2.cmpgt_epi64(a, b));
            }
            else
            {
                return new long2(math.min(a.x, b.x), math.min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two long3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 min(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Avx2.mm256_cmpgt_epi64(a, b));
            }
            else
            {
                return new long3(min(a.xy, b.xy), math.min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two long4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 min(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Avx2.mm256_cmpgt_epi64(a, b));
            }
            else
            {
                return new long4(min(a.xy, b.xy), min(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise minimum of two float8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 min(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_min_ps(a, b);
            }
            else
            {
                return new float8(math.min(a.v4_0, b.v4_0), math.min(a.v4_4, b.v4_4));
            }
        }
    }
}