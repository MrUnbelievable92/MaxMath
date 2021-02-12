using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise maximum of two byte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 max(byte2 a, byte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte2((byte)math.max((uint)a.x, (uint)b.x), (byte)math.max((uint)a.y, (uint)b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two byte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 max(byte3 a, byte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte3((byte)math.max((uint)a.x, (uint)b.x), (byte)math.max((uint)a.y, (uint)b.y), (byte)math.max((uint)a.z, (uint)b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two byte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 max(byte4 a, byte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte4((byte)math.max((uint)a.x, (uint)b.x), (byte)math.max((uint)a.y, (uint)b.y), (byte)math.max((uint)a.z, (uint)b.z), (byte)math.max((uint)a.w, (uint)b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two byte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 max(byte8 a, byte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte8((byte)math.max((uint)a.x0, (uint)b.x0), (byte)math.max((uint)a.x1, (uint)b.x1), (byte)math.max((uint)a.x2, (uint)b.x2), (byte)math.max((uint)a.x3, (uint)b.x3), (byte)math.max((uint)a.x4, (uint)b.x4), (byte)math.max((uint)a.x5, (uint)b.x5), (byte)math.max((uint)a.x6, (uint)b.x6), (byte)math.max((uint)a.x7, (uint)b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two byte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 max(byte16 a, byte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epu8(a, b);
            }
            else
            {
                return new byte16((byte)math.max((uint)a.x0, (uint)b.x0), (byte)math.max((uint)a.x1, (uint)b.x1), (byte)math.max((uint)a.x2, (uint)b.x2), (byte)math.max((uint)a.x3, (uint)b.x3), (byte)math.max((uint)a.x4, (uint)b.x4), (byte)math.max((uint)a.x5, (uint)b.x5), (byte)math.max((uint)a.x6, (uint)b.x6), (byte)math.max((uint)a.x7, (uint)b.x7), (byte)math.max((uint)a.x8, (uint)b.x8), (byte)math.max((uint)a.x9, (uint)b.x9), (byte)math.max((uint)a.x10, (uint)b.x10), (byte)math.max((uint)a.x11, (uint)b.x11), (byte)math.max((uint)a.x12, (uint)b.x12), (byte)math.max((uint)a.x13, (uint)b.x13), (byte)math.max((uint)a.x14, (uint)b.x14), (byte)math.max((uint)a.x15, (uint)b.x15));
            }
        }

        /// <summary>       Returns the componentwise maximum of two byte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 max(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu8(a, b);
            }
            else
            {
                return new byte32(max(a.v16_0, b.v16_0), max(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the componentwise maximum of two sbyte2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 max(sbyte2 a, sbyte2 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(b, a));
            }
            else
            {
                return new sbyte2((sbyte)math.max(a.x, b.x), (sbyte)math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two sbyte3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 max(sbyte3 a, sbyte3 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(b, a));
            }
            else
            {
                return new sbyte3((sbyte)math.max(a.x, b.x), (sbyte)math.max(a.y, b.y), (sbyte)math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two sbyte4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 max(sbyte4 a, sbyte4 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(b, a));
            }
            else
            {
                return new sbyte4((sbyte)math.max(a.x, b.x), (sbyte)math.max(a.y, b.y), (sbyte)math.max(a.z, b.z), (sbyte)math.max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two sbyte8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 max(sbyte8 a, sbyte8 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(b, a));
            }
            else
            {
                return new sbyte8((sbyte)math.max(a.x0, b.x0), (sbyte)math.max(a.x1, b.x1), (sbyte)math.max(a.x2, b.x2), (sbyte)math.max(a.x3, b.x3), (sbyte)math.max(a.x4, b.x4), (sbyte)math.max(a.x5, b.x5), (sbyte)math.max(a.x6, b.x6), (sbyte)math.max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two sbyte16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 max(sbyte16 a, sbyte16 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epi8(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Sse2.cmpgt_epi8(b, a));
            }
            else
            {
                return new sbyte16((sbyte)math.max(a.x0, b.x0), (sbyte)math.max(a.x1, b.x1), (sbyte)math.max(a.x2, b.x2), (sbyte)math.max(a.x3, b.x3), (sbyte)math.max(a.x4, b.x4), (sbyte)math.max(a.x5, b.x5), (sbyte)math.max(a.x6, b.x6), (sbyte)math.max(a.x7, b.x7), (sbyte)math.max(a.x8, b.x8), (sbyte)math.max(a.x9, b.x9), (sbyte)math.max(a.x10, b.x10), (sbyte)math.max(a.x11, b.x11), (sbyte)math.max(a.x12, b.x12), (sbyte)math.max(a.x13, b.x13), (sbyte)math.max(a.x14, b.x14), (sbyte)math.max(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise maximum of two sbyte32 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 max(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi8(a, b);
            }
            else
            {
                return new sbyte32(max(a.v16_0, b.v16_0), max(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the componentwise maximum of two ushort2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 max(ushort2 a, ushort2 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(b, a));
            }
            else
            {
                return new ushort2((ushort)math.max((uint)a.x, (uint)b.x), (ushort)math.max((uint)a.y, (uint)b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two ushort3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 max(ushort3 a, ushort3 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(b, a));
            }
            else
            {
                return new ushort3((ushort)math.max((uint)a.x, (uint)b.x), (ushort)math.max((uint)a.y, (uint)b.y), (ushort)math.max((uint)a.z, (uint)b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two ushort4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 max(ushort4 a, ushort4 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(b, a));
            }
            else
            {
                return new ushort4((ushort)math.max((uint)a.x, (uint)b.x), (ushort)math.max((uint)a.y, (uint)b.y), (ushort)math.max((uint)a.z, (uint)b.z), (ushort)math.max((uint)a.w, (uint)b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two ushort8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 max(ushort8 a, ushort8 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.max_epu16(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendV(a, b, Operator.greater_mask_ushort(b, a));
            }
            else
            {
                return new ushort8((ushort)math.max((uint)a.x0, (uint)b.x0), (ushort)math.max((uint)a.x1, (uint)b.x1), (ushort)math.max((uint)a.x2, (uint)b.x2), (ushort)math.max((uint)a.x3, (uint)b.x3), (ushort)math.max((uint)a.x4, (uint)b.x4), (ushort)math.max((uint)a.x5, (uint)b.x5), (ushort)math.max((uint)a.x6, (uint)b.x6), (ushort)math.max((uint)a.x7, (uint)b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two ushort16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 max(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu16(a, b);
            }
            else
            {
                return new ushort16(max(a.v8_0, b.v8_0), max(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the componentwise maximum of two short2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 max(short2 a, short2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short2((short)math.max(a.x, b.x), (short)math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two short3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 max(short3 a, short3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short3((short)math.max(a.x, b.x), (short)math.max(a.y, b.y), (short)math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two short4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 max(short4 a, short4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short4((short)math.max(a.x, b.x), (short)math.max(a.y, b.y), (short)math.max(a.z, b.z), (short)math.max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two short8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 max(short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.max_epi16(a, b);
            }
            else
            {
                return new short8((short)math.max(a.x0, b.x0), (short)math.max(a.x1, b.x1), (short)math.max(a.x2, b.x2), (short)math.max(a.x3, b.x3), (short)math.max(a.x4, b.x4), (short)math.max(a.x5, b.x5), (short)math.max(a.x6, b.x6), (short)math.max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two short16 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 max(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi16(a, b);
            }
            else
            {
                return new short16(max(a.v8_0, b.v8_0), max(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the componentwise maximum of two int8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 max(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi32(a, b);
            }
            else
            {
                return new int8(math.max(a.v4_0, b.v4_0), math.max(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise maximum of two uint8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 max(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu32(a, b);
            }
            else
            {
                return new uint8(math.max(a.v4_0, b.v4_0), math.max(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise maximum of two ulong2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 max(ulong2 a, ulong2 b)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return Sse4_1.blendv_epi8(a, b, Operator.greater_mask_ulong(b, a));
            }
            else
            {
                return new ulong2(math.max(a.x, b.x), math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two ulong3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 max(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Operator.greater_mask_ulong(b, a));
            }
            else
            {
                return new ulong3(max(a.xy, b.xy), math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two ulong4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 max(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Operator.greater_mask_ulong(b, a));
            }
            else
            {
                return new ulong4(max(a.xy, b.xy), max(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise maximum of two long2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 max(long2 a, long2 b)
        {
            if (Sse4_2.IsSse42Supported)
            {
                return Sse4_1.blendv_epi8(a, b, Sse4_2.cmpgt_epi64(b, a));
            }
            else
            {
                return new long2(math.max(a.x, b.x), math.max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two long3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 max(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Avx2.mm256_cmpgt_epi64(b, a));
            }
            else
            {
                return new long3(max(a.xy, b.xy), math.max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two long4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 max(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, Avx2.mm256_cmpgt_epi64(b, a));
            }
            else
            {
                return new long4(max(a.xy, b.xy), max(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise maximum of two float8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 max(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_max_ps(a, b);
            }
            else
            {
                return new float8(math.max(a.v4_0, b.v4_0), math.max(a.v4_4, b.v4_4));
            }
        }
    }
}