using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_epi16(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu8_epi16(x);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, -1,    1, -1,    2, -1,    3, -1,    4, -1,    5, -1,    6, -1,    7, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi8(x, Sse2.setzero_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_epi16(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi8_epi16(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.srai_epi16(Sse2.unpacklo_epi8(x, x), 8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_epi32(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu8_epi32(x);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, -1, -1, -1,   1, -1, -1, -1,   2, -1, -1, -1,   3, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 zero = Sse2.setzero_si128();
                v128 shorts = Sse2.unpacklo_epi8(x, zero);

                return Sse2.unpacklo_epi16(shorts, zero);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_epi32(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi8_epi32(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 whoop = Sse2.unpacklo_epi8(x, x);
                v128 dee = Sse2.unpacklo_epi16(whoop, whoop);
                v128 dup = Sse2.srai_epi32(dee, 24);

                return dup;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_epi64(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu8_epi64(x);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, -1, -1, -1, -1, -1, -1, -1,   1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 zero = Sse2.setzero_si128();
                v128 shorts = Sse2.unpacklo_epi8(x, zero);
                v128 ints = Sse2.unpacklo_epi16(shorts, zero);

                return Sse2.unpacklo_epi32(ints, zero);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_epi64(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi8_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 sign = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);
                v128 shorts = Sse2.unpacklo_epi8(x, sign);

                sign = Sse2.unpacklo_epi8(sign, sign);
                v128 ints = Sse2.unpacklo_epi16(shorts, sign);

                sign = Sse2.unpacklo_epi16(sign, sign);
                return Sse2.unpacklo_epi32(ints, sign);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_epi32(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu16_epi32(x);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 1, -1, -1,    2, 3, -1, -1,    4, 5, -1, -1,    6, 7, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi16(x, Sse2.setzero_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_epi32(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi16_epi32(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi16(x, Sse2.srai_epi16(x, 15));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_epi64(ushort2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu16_epi64(x);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 1, -1, -1, -1, -1, -1, -1,    2, 3, -1, -1, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 zero = Sse2.setzero_si128();
                v128 shorts = Sse2.unpacklo_epi16(x, zero);

                return Sse2.unpacklo_epi32(shorts, zero);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_epi64(short2 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi16_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 sign = Sse2.srai_epi16(x, 15);
                v128 shorts = Sse2.unpacklo_epi16(x, sign);

                sign = Sse2.unpacklo_epi16(sign, sign);
                return Sse2.unpacklo_epi32(shorts, sign);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_epi64(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepu32_epi64(x);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 1, 2, 3, -1, -1, -1, -1,    4, 5, 6, 7, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi32(x, Sse2.setzero_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi64(v128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.cvtepi32_epi64(x);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi32(x, Sse2.srai_epi32(x, 31));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_epi8(v128 x, byte elements = 8)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                if (elements == 2)
                {
                    v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(short));

                    return Sse2.unpacklo_epi8(x, y_shifted);
                }
                else
                {
                    v128 clamp = Sse2.and_si128(x, new v128(0x00FF_00FF_00FF_00FF, 0x00FF_00FF_00FF_00FF));

                    return Sse2.packus_epi16(clamp, clamp);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi16_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi8(x, new v256(0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1,     0, 2, 4, 6, 8, 10, 12, 14,     -1, -1, -1, -1, -1, -1, -1, -1)),
                                                                              Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi8(v128 x, byte elements = 4)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                if (elements == 2)
                {
                    v128 y_shifted = Sse2.bsrli_si128(x, 1 * sizeof(int));

                    return Sse2.unpacklo_epi8(x, y_shifted);
                }
                else
                {
                    v128 clamp = Sse2.and_si128(x, new v128(0x0000_00FF_0000_00FF, 0x0000_00FF_0000_00FF));

                    v128 epi16 = Sse2.packs_epi32(clamp, clamp);

                    return Sse2.packus_epi16(epi16, epi16);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi32_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,     0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 4, 1, 1))));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi16(v128 x, byte elements = 4)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 1, 4, 5, 8, 9, 12, 13,    -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                x = Sse2.shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));

                if (elements <= 2)
                {
                    return x;
                }
                else
                {
                    x = Sse2.shufflehi_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));

                    return Sse2.shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi32_epi16(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 1,   4, 5,   8, 9,   12, 13,   -1, -1, -1, -1, -1, -1, -1, -1,
                                                        0, 1,   4, 5,   8, 9,   12, 13,   -1, -1, -1, -1, -1, -1, -1, -1));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi8(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 8, -1, -1,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 high = Sse2.bsrli_si128(x, sizeof(long));
                return Sse2.unpacklo_epi8(x, high);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi8(v256 x)
        {
            return cvtepi32_epi8(mm256_cvtepi64_epi32(x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi16(v128 x)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Ssse3.shuffle_epi8(x, new v128(0, 1, 8, 9,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 high = Sse2.bsrli_si128(x, sizeof(long));
                return Sse2.unpacklo_epi16(x, high);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi16(v256 x)
        {
            return cvtepi32_epi16(mm256_cvtepi64_epi32(x));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi32(v128 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi32(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
            }
            else throw new IllegalInstructionException();
        }
    }
}