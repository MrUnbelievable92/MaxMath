using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi8(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n == 1))
                {
                    return Sse2.add_epi8(x, x);
                }
                if (constexpr.IS_TRUE(n == 2))
                {
                    v128 x2 = Sse2.add_epi8(x, x);

                    return Sse2.add_epi8(x2, x2);
                }


                v128 mask = Sse2.set1_epi8((sbyte)(0b1111_1111 >> n));

                return slli_epi16(Sse2.and_si128(x, mask), n);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi8(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n == 1))
                {
                    return Avx2.mm256_add_epi8(x, x);
                }
                if (constexpr.IS_TRUE(n == 2))
                {
                    v256 x2 = Avx2.mm256_add_epi8(x, x);

                    return Avx2.mm256_add_epi8(x2, x2);
                }


                v256 mask = Avx.mm256_set1_epi8((byte)(0b1111_1111 >> n));

                return mm256_slli_epi16(Avx2.mm256_and_si256(x, mask), n);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi8(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.set1_epi8((sbyte)(0b1111_1111 << n));

                return srli_epi16(Sse2.and_si128(x, mask), n);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi8(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 mask = Avx.mm256_set1_epi8((byte)(0b1111_1111 << n));

                return mm256_srli_epi16(Avx2.mm256_and_si256(x, mask), n);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi8(v128 x, int n, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n == 7))
                {
                    return Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);
                }

                if (Sse4_1.IsSse41Supported && elements <= 8)
                {
                    return cvtepi16_epi8(srai_epi16(Sse4_1.cvtepi8_epi16(x), n));
                }
                else
                {
                    v128 even = srai_epi16(slli_epi16(x, 8), n + 8);
                    v128 odd = srai_epi16(x, n);

                    return blendv_si128(even, odd, new v128(0xFF00_FF00));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi8(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n == 7))
                {
                    return Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), x);
                }

                v256 even = mm256_srai_epi16(mm256_slli_epi16(x, 8), n + 8);
                v256 odd = mm256_srai_epi16(x, n);

                return mm256_blendv_si256(even, odd, new v256(0xFF00_FF00));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi16(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sll_epi16(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi16(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi16(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi16(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.srl_epi16(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi16(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi16(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi16(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sra_epi16(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi16(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi16(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi32(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sra_epi32(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi32(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi32(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi32(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.srl_epi32(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi32(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi32(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi32(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sll_epi32(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi32(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi32(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 slli_epi64(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sll_epi64(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_slli_epi64(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi64(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srli_epi64(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.srl_epi64(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srli_epi64(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi64(x, Sse2.cvtsi32_si128(n));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 srai_epi64(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 64))
                {
                    return x;
                }
                if (constexpr.IS_TRUE(n == 63))
                {
                    return Sse2.shuffle_epi32(Sse2.srai_epi32(x, 31), Sse.SHUFFLE(3, 3, 1, 1));
                }


                v128 shiftLo;
                v128 shiftHi;
                if (n <= 32)
                {
                    shiftHi = srai_epi32(x, n);
                    shiftLo = srli_epi64(x, n);
                }
                else
                {
                    shiftHi = srai_epi32(x, 31);
                    shiftLo = srai_epi32(x, n - 32);
                    shiftLo = srli_epi64(shiftLo, 32);
                }

                return blend_epi16(shiftLo, shiftHi, 0b1100_1100);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_srai_epi64(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(n <= 0 | n >= 64))
                {
                    return x;
                }
                if (constexpr.IS_TRUE(n == 63))
                {
                    return Avx2.mm256_shuffle_epi32(Avx2.mm256_srai_epi32(x, 31), Sse.SHUFFLE(3, 3, 1, 1));
                }


                v256 shiftLo;
                v256 shiftHi;
                if (n <= 32)
                {
                    shiftHi = mm256_srai_epi32(x, n);
                    shiftLo = mm256_srli_epi64(x, n);
                }
                else
                {
                    shiftHi = mm256_srai_epi32(x, 31);
                    shiftLo = mm256_srai_epi32(x, n - 32);
                    shiftLo = mm256_srli_epi64(shiftLo, 32);
                }

                return Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
            }
            else throw new IllegalInstructionException();
        }
    }
}