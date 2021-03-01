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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }


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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }


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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }


        internal static v128 Short2To_S_Byte2_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(short));

                return Sse2.unpacklo_epi8(x, y_shifted);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Short3To_S_Byte3_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(short));
                v128 z_shifted = Sse2.bsrli_si128(x, 2 * sizeof(short));

                v128 xy = Sse2.unpacklo_epi8(x, y_shifted);

                return Sse2.unpacklo_epi16(xy, z_shifted);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Short4To_S_Byte4_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(short));
                v128 z_shifted = Sse2.bsrli_si128(x, 2 * sizeof(short));
                v128 w_shifted = Sse2.bsrli_si128(x, 3 * sizeof(short));

                v128 xy = Sse2.unpacklo_epi8(x, y_shifted);
                v128 zw = Sse2.unpacklo_epi8(z_shifted, w_shifted);

                return Sse2.unpacklo_epi16(xy, zw);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Short8To_S_Byte8_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 x1x5_shifted = Sse2.bsrli_si128(x, 1 * sizeof(short));
                v128 x2x6_shifted = Sse2.bsrli_si128(x, 2 * sizeof(short));
                v128 x3x7_shifted = Sse2.bsrli_si128(x, 3 * sizeof(short));

                v128 x0x1 = Sse2.unpacklo_epi8(x,            x1x5_shifted);
                v128 x2x3 = Sse2.unpacklo_epi8(x2x6_shifted, x3x7_shifted);
                v128 x4x5 = Sse2.unpackhi_epi8(x,            x1x5_shifted);
                v128 x6x7 = Sse2.unpackhi_epi8(x2x6_shifted, x3x7_shifted);

                v128 x0x3 = Sse2.unpacklo_epi16(x0x1, x2x3);
                v128 x4x7 = Sse2.unpacklo_epi16(x4x5, x6x7);

                return Sse2.unpacklo_epi32(x0x3, x4x7);
            }
            else throw new CPUFeatureCheckException();
        }


        internal static v128 Int2To_S_Byte2_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(int));

                return Sse2.unpacklo_epi8(x, y_shifted);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Int3To_S_Byte3_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(int));
                v128 z_shifted = Sse2.bsrli_si128(x, 2 * sizeof(int));

                v128 xy = Sse2.unpacklo_epi8(x, y_shifted);

                return Sse2.unpacklo_epi16(xy, z_shifted);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Int4To_S_Byte4_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 yw_shifted = Sse2.bsrli_si128(x, 1 * sizeof(int));

                v128 xy = Sse2.unpacklo_epi8(x, yw_shifted);
                v128 zw = Sse2.unpackhi_epi8(x, yw_shifted);

                return Sse2.unpacklo_epi16(xy, zw);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Long2To_S_Byte2_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(long));

                return Sse2.unpacklo_epi8(x, y_shifted);
            }
            else throw new CPUFeatureCheckException();
        }


        internal static v128 Int3To_U_Short3_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(int));
                v128 z_shifted = Sse2.bsrli_si128(x, 2 * sizeof(int));

                v128 xy = Sse2.unpacklo_epi16(x, y_shifted);

                return Sse2.unpacklo_epi32(xy, z_shifted);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Int4To_U_Short4_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 yw_shifted = Sse2.bsrli_si128(x, 1 * sizeof(int));

                v128 xy = Sse2.unpacklo_epi16(x, yw_shifted);
                v128 zw = Sse2.unpackhi_epi16(x, yw_shifted);

                return Sse2.unpacklo_epi32(xy, zw);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Long2To_U_Short2_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(long));

                return Sse2.unpacklo_epi16(x, y_shifted);
            }
            else throw new CPUFeatureCheckException();
        }
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////


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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }


        internal static v128 UShortToFloat(ushort2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort4 shorter = new v128(F32_PRECISION_THRESHOLD);

                return Sse.sub_ps(Sse2.unpacklo_epi16(x, new ushort2(0x4B00)),
                                  shorter);
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 UShortToFloat(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse.sub_ps(Sse2.unpacklo_epi16(x, new ushort4(0x4B00)),
                                  new v128(F32_PRECISION_THRESHOLD));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v256 UShort8ToFloat8(ushort8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 interleave = Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(x), Sse.SHUFFLE(3, 1, 3, 0));

                return Avx.mm256_sub_ps(Avx2.mm256_unpacklo_epi16(interleave, new ushort16(0x4B00)),
                                        new v256(F32_PRECISION_THRESHOLD));
            }
            else throw new CPUFeatureCheckException();
        }


        internal static v128 ShortToByte(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 2, 4, 6));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 ShortToByte(ushort8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 2, 4, 6, 8, 10, 12, 14));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 ShortToByte(short8 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 2, 4, 6, 8, 10, 12, 14));
            }
            else throw new CPUFeatureCheckException();
        }


        internal static v128 ShortToByte(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi8(x, new v256(0, 2, 4, 6, 8, 10, 12, 14,    0, 0, 0, 0, 0, 0, 0, 0, 0,  2, 4, 6, 8, 10, 12, 14,     0, 0, 0, 0, 0, 0, 0, 0)),
                                                                              Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new CPUFeatureCheckException();
        }


        internal static v128 Int4ToByte4(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 4, 8, 12));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Int8ToByte8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,     0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 4, 0, 0))));
            }
            else throw new CPUFeatureCheckException();
        }


        internal static v128 Int2ToShort2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Int4ToShort4(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 1, 4, 5, 8, 9, 12, 13));
            }
            else throw new CPUFeatureCheckException();
        }
         
        internal static v128 Int8ToShort8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0,
                                                        0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 1, 4, 5))));
            }
            else throw new CPUFeatureCheckException();
        }


        internal static v128 Long2ToByte2(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 8, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Long4ToByte4(v256 x)
        {
            return Int4ToByte4(Long4ToInt4(x));
        }


        internal static v128 Long2ToShort2(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 1, 8, 9));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Long4ToShort4(v256 x)
        {
            return Int4ToShort4(Long4ToInt4(x));
        }


        internal static v128 Long2ToInt2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        internal static v128 Long4ToInt4(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
            }
            else throw new CPUFeatureCheckException();
        }


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
            else throw new CPUFeatureCheckException();
        }

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
            else throw new CPUFeatureCheckException();
        }


        internal static float8 UInt8ToFloat8(uint8 x)
        {
            int8 signed = (int8)x & 0x7FFF_FFFF;
            int8 signMask = ((int8)x >> 31) & 0x4F00_0000;

            return (float8)signed + (v256)signMask;
        }
    }
}