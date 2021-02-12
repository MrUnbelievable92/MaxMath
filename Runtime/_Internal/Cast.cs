using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static class Cast
    {
        internal const float F32_PRECISION_THRESHOLD = 8_388_608f;


        //////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////  SSE2 FALLBACK  ////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ByteToShort(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu8_epi16(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi8(x, default(v128));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SByteToShort(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi8_epi16(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi8(x, Sse2.cmpgt_epi8(default(v128), x));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ByteToInt(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu8_epi32(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 zero = default(v128);
                v128 shorts = Sse2.unpacklo_epi8(x, zero);

                return Sse2.unpacklo_epi16(shorts, zero);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SByteToInt(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi8_epi32(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 sign = Sse2.cmpgt_epi8(default(v128), x);
                v128 shorts = Sse2.unpacklo_epi8(x, sign);

                sign = Sse2.unpacklo_epi8(sign, sign);
                return Sse2.unpacklo_epi16(shorts, sign);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ByteToLong(byte2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu8_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 zero = default(v128);
                v128 shorts = Sse2.unpacklo_epi8(x, zero);
                v128 ints = Sse2.unpacklo_epi16(shorts, zero);

                return Sse2.unpacklo_epi32(ints, zero);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 SByteToLong(sbyte2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi8_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 sign = Sse2.cmpgt_epi8(default(v128), x);
                v128 shorts = Sse2.unpacklo_epi8(x, sign);

                sign = Sse2.unpacklo_epi8(sign, sign);
                v128 ints = Sse2.unpacklo_epi16(shorts, sign);

                sign = Sse2.unpacklo_epi16(sign, sign);
                return Sse2.unpacklo_epi16(ints, sign);
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UShortToInt(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu16_epi32(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi16(x, default(v128));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToInt(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi16_epi32(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi16(x, Sse2.cmpgt_epi16(default(v128), x));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UShortToLong(ushort2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu16_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 zero = default(v128);
                v128 shorts = Sse2.unpacklo_epi16(x, zero);

                return Sse2.unpacklo_epi32(shorts, zero);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToLong(short2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi16_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 sign = Sse2.cmpgt_epi16(default(v128), x);
                v128 shorts = Sse2.unpacklo_epi16(x, sign);

                sign = Sse2.unpacklo_epi16(sign, sign);
                return Sse2.unpacklo_epi32(shorts, sign);
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UIntToLong(uint2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu32_epi64(*(v128*)&x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi32(*(v128*)&x, default(v128));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IntToLong(int2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi32_epi64(*(v128*)&x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi32(*(v128*)&x, Sse2.cmpgt_epi32(default(v128), *(v128*)&x));
            }
            else throw new BurstCompilerException();
        }


        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ByteToFloat(byte2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                ushort4 shorter = new v128(F32_PRECISION_THRESHOLD);

                v128 temp = Sse4_1.insert_epi32(x, 0x4B00_0000, 3);
                temp = Ssse3.shuffle_epi8(temp, new byte8(0, 13, 14, 15,
                                                          1, 13, 14, 15));

                return Sse.sub_ps(temp, shorter);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ByteToFloat(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                x = Sse4_1.insert_epi32(x, 0x4B00_0000, 3);
                x = Ssse3.shuffle_epi8(x, new v128(0, 13, 14, 15,
                                                   1, 13, 14, 15,
                                                   2, 13, 14, 15,
                                                   3, 13, 14, 15));

                return Sse.sub_ps(x, new v128(F32_PRECISION_THRESHOLD));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UShortToFloat(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort4 shorter = new v128(F32_PRECISION_THRESHOLD);

                return Sse.sub_ps(Sse2.unpacklo_epi16(x, new ushort2(0x4B00)),
                                  shorter);
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UShortToFloat(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse.sub_ps(Sse2.unpacklo_epi16(x, new ushort4(0x4B00)),
                                  new v128(F32_PRECISION_THRESHOLD));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 UShort8ToFloat8(ushort8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 interleave = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(x), Sse.SHUFFLE(3, 1, 3, 0));

                return Avx.mm256_sub_ps(Avx2.mm256_unpacklo_epi16(interleave, new ushort16(0x4B00)),
                                        new v256(F32_PRECISION_THRESHOLD));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 2, 4, 6));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(ushort8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 2, 4, 6, 8, 10, 12, 14));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(short8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 2, 4, 6, 8, 10, 12, 14));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi8(x, new v256(0, 2, 4, 6, 8, 10, 12, 14,    0, 0, 0, 0, 0, 0, 0, 0, 0,  2, 4, 6, 8, 10, 12, 14,     0, 0, 0, 0, 0, 0, 0, 0)),
                                                                              Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToByte4(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 4, 8, 12));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToByte8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,     0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                return Sse2.unpacklo_epi32(Avx.mm256_castsi256_si128(x),
                                           Avx2.mm256_extracti128_si256(x, 1));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int2ToShort2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToShort4(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 1, 4, 5, 8, 9, 12, 13));
            }
            else throw new BurstCompilerException();
        }
         
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToShort8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0,
                                                        0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0));

                return Sse2.unpacklo_epi64(Avx.mm256_castsi256_si128(x),
                                           Avx2.mm256_extracti128_si256(x, 1));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToByte2(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 8, 0, 0));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToByte4(v256 x)
        {
            return Int4ToByte4(Long4ToInt4(x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToShort2(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 1, 8, 9));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToShort4(v256 x)
        {
            return Int4ToShort4(Long4ToInt4(x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToInt2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToInt4(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 Long4ToDouble4(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                ulong4 magic_lo  = 0x4330_0000_0000_0000;
                ulong4 magic_hi  = 0x4530_0000_8000_0000;
                ulong4 magic_dbl = 0x4530_0000_8010_0000;
                
                
                ulong4 lo = Avx2.mm256_blend_epi32(magic_lo, x, 0b0101_0101);
                ulong4 hi = magic_hi ^ ((ulong4)x >> 32);
                
                v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
                v256 result = Avx.mm256_add_pd(hi_dbl, lo);
                        

                return *(double4*)&result;
            }
            else throw new BurstCompilerException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 ULong4ToDouble4(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                ulong4 magic_lo  = 0x4330_0000_0000_0000;
                ulong4 magic_hi  = 0x4530_0000_0000_0000;
                ulong4 magic_dbl = 0x4530_0000_0010_0000;


                ulong4 lo = Avx2.mm256_blend_epi32(magic_lo, x, 0b0101_0101);
                ulong4 hi = magic_hi ^ (x >> 32);

                v256 hi_dbl = Avx.mm256_sub_pd(hi, magic_dbl);
                v256 result = Avx.mm256_add_pd(hi_dbl, lo);


                return *(double4*)&result;
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float8 UInt8ToFloat8(uint8 x)
        {
            int8 signed = (int8)x & 0x7FFF_FFFF;
            int8 signMask = ((int8)x >> 31) & 0x4F00_0000;

            return (float8)signed + (v256)signMask;
        }
    }
}