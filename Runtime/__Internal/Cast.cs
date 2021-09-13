using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static class Cast
    {
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
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 Byte16ToShort16(byte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi16(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Sse4_1.cvtepu8_epi16(x);
                v128 hi = Sse4_1.cvtepu8_epi16(Sse2.bsrli_si128(x, 8 * sizeof(byte)));

                return new short16(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 lo = Sse2.unpacklo_epi8(x, ZERO);
                v128 hi = Sse2.unpackhi_epi8(x, ZERO);

                return new short16(lo, hi);
            }
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 SByte16ToShort16(sbyte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi16(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Sse4_1.cvtepi8_epi16(x);
                v128 hi = Sse4_1.cvtepi8_epi16(Sse2.bsrli_si128(x, 8 * sizeof(sbyte)));

                return new short16(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);
                v128 lo = Sse2.unpacklo_epi8(x, negativeMask);
                v128 hi = Sse2.unpackhi_epi8(x, negativeMask);

                return new short16(lo, hi);
            }
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int8 UShort8ToInt8(ushort8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi32(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Sse4_1.cvtepu16_epi32(x);
                v128 hi = Sse4_1.cvtepu16_epi32(Sse2.bsrli_si128(x, 4 * sizeof(ushort)));

                return new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 lo = Sse2.unpacklo_epi16(x, ZERO);
                v128 hi = Sse2.unpackhi_epi16(x, ZERO);

                return new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int8 Short8ToInt8(short8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi32(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Sse4_1.cvtepi16_epi32(x);
                v128 hi = Sse4_1.cvtepi16_epi32(Sse2.bsrli_si128(x, 4 * sizeof(short)));

                return new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.cmpgt_epi16(Sse2.setzero_si128(), x);
                v128 lo = Sse2.unpacklo_epi16(x, negativeMask);
                v128 hi = Sse2.unpackhi_epi16(x, negativeMask);

                return new int8(*(int4*)&lo, *(int4*)&hi);
            }
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UIntToLong(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu32_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi32(x, default(v128));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long4 UInt4ToLong4(v128 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu32_epi64(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Sse4_1.cvtepu32_epi64(x);
                v128 hi = Sse4_1.cvtepu32_epi64(Sse2.bsrli_si128(x, 2 * sizeof(uint)));

                return new long4(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 lo = Sse2.unpacklo_epi32(x, ZERO);
                v128 hi = Sse2.unpackhi_epi32(x, ZERO);

                return new long4(lo, hi);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IntToLong(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi32_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi32(x, Sse2.cmpgt_epi32(default(v128), x));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long4 Int4ToLong4(v128 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Sse4_1.cvtepi32_epi64(x);
                v128 hi = Sse4_1.cvtepi32_epi64(Sse2.bsrli_si128(x, 2 * sizeof(int)));

                return new long4(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.cmpgt_epi32(Sse2.setzero_si128(), x);
                v128 lo = Sse2.unpacklo_epi32(x, negativeMask);
                v128 hi = Sse2.unpackhi_epi32(x, negativeMask);

                return new long4(lo, hi);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short2To_S_Byte2_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(short));

                return Sse2.unpacklo_epi8(x, y_shifted);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short16To_S_Byte16_SSE2(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(0x00FF_00FF_00FF_00FF, 0x00FF_00FF_00FF_00FF);

                v128 clamp_lo = Sse2.and_si128(lo, MASK);
                v128 clamp_hi = Sse2.and_si128(hi, MASK);

                return Sse2.packus_epi16(clamp_lo, clamp_hi);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int2To_S_Byte2_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(int));

                return Sse2.unpacklo_epi8(x, y_shifted);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8To_S_Byte8_SSE2(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(0x0000_00FF_0000_00FF, 0x0000_00FF_0000_00FF);

                v128 clamp_lo = Sse2.and_si128(lo, MASK);
                v128 clamp_hi = Sse2.and_si128(hi, MASK);

                v128 epi16 = Sse2.packs_epi32(clamp_lo, clamp_hi);

                return Sse2.packus_epi16(epi16, epi16);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8To_U_Short8_SSE4_1(v128 lo, v128 hi)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MASK = new v128(0x0000_FFFF_0000_FFFF, 0x0000_FFFF_0000_FFFF);

                v128 clamp_lo = Sse2.and_si128(lo, MASK);
                v128 clamp_hi = Sse2.and_si128(hi, MASK);

                return Sse4_1.packus_epi32(clamp_lo, clamp_hi);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2To_S_Byte2_SSE2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(long));

                return Sse2.unpacklo_epi8(x, y_shifted);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short4ToByte4(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 2, 4, 6));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 clamp = Sse2.and_si128(x, Sse2.cvtsi64x_si128(0x00FF_00FF_00FF_00FF));

                return Sse2.packus_epi16(clamp, clamp);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 2, 4, 6, 8, 10, 12, 14));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 clamp = Sse2.and_si128(x, new v128(0x00FF_00FF_00FF_00FF, 0x00FF_00FF_00FF_00FF));

                return Sse2.packus_epi16(clamp, clamp);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 ShortToByte(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi8(x, new v256(0, 2, 4, 6, 8, 10, 12, 14,    0, 0, 0, 0, 0, 0, 0, 0, 0,  2, 4, 6, 8, 10, 12, 14,     0, 0, 0, 0, 0, 0, 0, 0)),
                                                                              Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToByte4(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 4, 8, 12));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 clamp = Sse2.and_si128(x, new v128(0x0000_00FF_0000_00FF, 0x0000_00FF_0000_00FF));

                v128 epi16 = Sse2.packs_epi32(clamp, clamp);

                return Sse2.packus_epi16(epi16, epi16);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToByte8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,     0, 4, 8, 12,    0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 4, 0, 0))));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int2ToShort2(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int4ToShort4(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte8(0, 1, 4, 5, 8, 9, 12, 13));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8ToShort8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0,
                                                        0, 1,   4, 5,   8, 9,   12, 13,   0, 0, 0, 0, 0, 0, 0, 0));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long2ToByte2(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new byte4(0, 8, 0, 0));
            }
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Long4ToInt4(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi32(x, Sse.SHUFFLE(0, 0, 2, 0)), Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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
            else throw new CPUFeatureCheckException();
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