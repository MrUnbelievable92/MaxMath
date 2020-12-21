using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static class Cast
    {
        internal const float F32_PRECISION_THRESHOLD = 8_388_608f;


        // byte8 is not worth it
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ByteToFloat(v128 x)
        {
            x = Sse4_1.insert_epi32(x, 0x4B00_0000, 3);
            x = Ssse3.shuffle_epi8(x, new v128(0, 13, 14, 15,
                                               1, 13, 14, 15,
                                               2, 13, 14, 15,
                                               3, 13, 14, 15));

            return Sse.sub_ps(x, new v128(F32_PRECISION_THRESHOLD));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UShortToFloat(v128 x)
        {
            return Sse.sub_ps(Sse2.unpacklo_epi16(x, new ushort4(0x4B00)),
                              new v128(F32_PRECISION_THRESHOLD));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 UShort8ToFloat8(ushort8 x)
        {
            v256 interleave = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(x), Sse.SHUFFLE(3, 1, 3, 0));

            return Avx.mm256_sub_ps(Avx2.mm256_unpacklo_epi16(interleave, new ushort16(0x4B00)),
                                    new v256(F32_PRECISION_THRESHOLD));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v128 x)
        {
            return Ssse3.shuffle_epi8(x, new v128((2L << 8) | (4L << 16) | (6L << 24) | (8L << 32) | (10L << 40) | (12L << 48) | (14L << 56),       0L));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v256 x)
        {
            return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi8(x, new v256(0, 2, 4, 6, 8, 10, 12, 14,    0, 0, 0, 0, 0, 0, 0, 0, 0,  2, 4, 6, 8, 10, 12, 14,     0, 0, 0, 0, 0, 0, 0, 0)),
                                                                          Sse.SHUFFLE(0, 0, 2, 0)));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToByte4(v128 x)
        {
            return Ssse3.shuffle_epi8(x, new v128((4L << 8) | (8L << 16) | (12L << 24), 0L));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToByte8(v256 x)
        {
            x = Avx2.mm256_shuffle_epi8(x, new v256(0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,     0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

            return Sse2.unpacklo_epi32(Avx.mm256_castsi256_si128(x),
                                       Avx2.mm256_extracti128_si256(x, 1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int2ToShort2(v128 x)
        {
            return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToShort4(v128 x)
        {
            return Ssse3.shuffle_epi8(x, new v128((1L << 8) | (4L << 16) | (5L << 24) | (8L << 32) | (9L << 40) | (12L << 48) | (13L << 56),        0L));
        }
         
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToShort8(v256 x)
        {
            x = Avx2.mm256_shuffle_epi8(x, new v256(0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0,
                                                    0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0));

            return Sse2.unpacklo_epi64(Avx.mm256_castsi256_si128(x),
                                       Avx2.mm256_extracti128_si256(x, 1));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToByte2(v128 x)
        {
            return Ssse3.shuffle_epi8(x, new v128(8L << 8, 0L));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToByte4(v256 x)
        {
            return Int4ToByte4(Long4ToInt4(x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToShort2(v128 x)
        {
            return Ssse3.shuffle_epi8(x, new v128((1L << 8) | (8L << 16) | (9L << 24), 0L));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToShort4(v256 x)
        {
            return Int4ToShort4(Long4ToInt4(x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToInt2(v128 x)
        {
            return Sse2.shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToInt4(v256 x)
        {
            return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 Long4ToDouble4(long4 x)
        {
            ulong4 magic_lo  = 0x4330_0000_0000_0000;
            ulong4 magic_hi  = 0x4530_0000_8000_0000;
            ulong4 magic_dbl = 0x4530_0000_8010_0000;
            
            
            ulong4 lo = Avx2.mm256_blend_epi16(magic_lo, x, 0b0011_0011_0011_0011);
            ulong4 hi = magic_hi ^ ((ulong4)x >> 32);
            
            v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
            v256 result = Avx.mm256_add_pd(hi_dbl, lo);
                    

            return *(double4*)&result;                                               
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 ULong4ToDouble4(ulong4 x)
        {
            ulong4 magic_lo  = 0x4330_0000_0000_0000;
            ulong4 magic_hi  = 0x4530_0000_0000_0000;
            ulong4 magic_dbl = 0x4530_0000_0010_0000;


            ulong4 lo = Avx2.mm256_blend_epi16(magic_lo, x, 0b0011_0011_0011_0011);
            ulong4 hi = magic_hi ^ ((ulong4)x >> 32);

            v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
            v256 result = Avx.mm256_add_pd(hi_dbl, lo);


            return *(double4*)&result;
        }


        internal static float8 Uint8ToFloat8(uint8 x)
        {
            return (float8)((int8)x & 0x7FFFFFFF) 
                   +
                   (float8)((v256)(((int8)x >> 31) & 0x4F000000));
        }
    }
}