using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epu8(v128 a, v128 b, byte elements = 16)
        {
            if (Ssse3.IsSsse3Supported)
            {
                if (elements <= 8)
                {
                    v128 full = Sse2.mullo_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b));

                    return Ssse3.shuffle_epi8(full, new v128(1, 3, 5, 7, 9, 11, 13, 15,   -1, -1, -1, -1, -1, -1, -1, -1));
                }
            }

            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(0xFF00_FF00);

                v128 even = Sse2.mullo_epi16(Sse2.andnot_si128(MASK, a), Sse2.andnot_si128(MASK, b));
                v128 odd = Sse2.mullo_epi16(Sse2.srli_epi16(a, 8), Sse2.srli_epi16(b, 8));
                even = Sse2.srli_epi16(even, 8);
                
                return blendv_si128(even, odd, MASK);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epu8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MASK = new v256(0xFF00_FF00);

                v256 even = Avx2.mm256_mullo_epi16(Avx2.mm256_andnot_si256(MASK, a), Avx2.mm256_andnot_si256(MASK, b));
                v256 odd = Avx2.mm256_mullo_epi16(Avx2.mm256_srli_epi16(a, 8), Avx2.mm256_srli_epi16(b, 8));
                even = Avx2.mm256_srli_epi16(even, 8);

                return mm256_blendv_si256(even, odd, MASK);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epi8(v128 a, v128 b, byte elements = 16)
        {
            if (Ssse3.IsSsse3Supported)
            {
                if (elements <= 8)
                {
                    v128 full = Sse2.mullo_epi16(cvtepi8_epi16(a), cvtepi8_epi16(b));

                    return Ssse3.shuffle_epi8(full, new v128(1, 3, 5, 7, 9, 11, 13, 15,   -1, -1, -1, -1, -1, -1, -1, -1));
                }
            }

            if (Sse2.IsSse2Supported)
            {
                v128 even = Sse2.mullo_epi16(Sse2.srai_epi16(Sse2.slli_epi16(a, 8), 8), Sse2.srai_epi16(Sse2.slli_epi16(b, 8), 8));
                v128 odd  = Sse2.mullo_epi16(Sse2.srai_epi16(a, 8), Sse2.srai_epi16(b, 8));
                
                even = Sse2.srli_epi16(even, 8);
                
                return blendv_si128(even, odd, new v128(0xFF00_FF00));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = Avx2.mm256_mullo_epi16(Avx2.mm256_srai_epi16(Avx2.mm256_slli_epi16(a, 8), 8), Avx2.mm256_srai_epi16(Avx2.mm256_slli_epi16(b, 8), 8));
                v256 odd  = Avx2.mm256_mullo_epi16(Avx2.mm256_srai_epi16(a, 8), Avx2.mm256_srai_epi16(b, 8));
                
                even = Avx2.mm256_srli_epi16(even, 8);
                
                return mm256_blendv_si256(even, odd, new v256(0xFF00_FF00));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mullo_epi8(v128 a, v128 b, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                if (elements <= 8)
                {
                    return cvtepi16_epi8(Sse2.mullo_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b)));
                }
                else
                {
                    v128 even = Sse2.mullo_epi16(a, b);
                    v128 odd = Sse2.mullo_epi16(Sse2.srli_epi16(a, 8), Sse2.srli_epi16(b, 8));
                    odd = Sse2.slli_epi16(odd, 8);

                    return blendv_si128(even, odd, new v128(0xFF00_FF00));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mullo_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = Avx2.mm256_mullo_epi16(a, b);
                v256 odd = Avx2.mm256_mullo_epi16(Avx2.mm256_srli_epi16(a, 8), Avx2.mm256_srli_epi16(b, 8));
                odd = Avx2.mm256_slli_epi16(odd, 8);

                return mm256_blendv_si256(even, odd, new v256(0xFF00_FF00));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mullo_epi32(v128 a, v128 b, byte elements = 4) 
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.mullo_epi32(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements) && constexpr.ALL_LE_EPU32(b, byte.MaxValue, elements))
                {
                    return Sse2.mullo_epi16(a, b);
                }
                else
                {
                    v128 even = Sse2.mul_epu32(a, b);
                    v128 odd  = Sse2.mul_epu32(Sse2.bsrli_si128(a, sizeof(int)),
                                               Sse2.bsrli_si128(b, sizeof(int)));

                    return Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(even, odd),
                                               Sse2.unpackhi_epi32(even, odd));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epi32(v128 a, v128 b) 
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 even = Sse4_1.mul_epi32(a, b);
                v128 odd  = Sse4_1.mul_epi32(Sse2.bsrli_si128(a, sizeof(int)),
                                             Sse2.bsrli_si128(b, sizeof(int)));

                return Sse2.unpackhi_epi64(Sse2.unpacklo_epi32(even, odd),
                                           Sse2.unpackhi_epi32(even, odd));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epu32(v128 a, v128 b) 
        {
            if (Sse2.IsSse2Supported)
            {
                v128 even = Sse2.mul_epu32(a, b);
                v128 odd  = Sse2.mul_epu32(Sse2.bsrli_si128(a, sizeof(int)),
                                           Sse2.bsrli_si128(b, sizeof(int)));

                return Sse2.unpackhi_epi64(Sse2.unpacklo_epi32(even, odd),
                                           Sse2.unpackhi_epi32(even, odd));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epi32(v256 a, v256 b) 
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = Avx2.mm256_mul_epi32(a, b);
                v256 odd  = Avx2.mm256_mul_epi32(Avx2.mm256_bsrli_epi128(a, sizeof(int)),
                                                 Avx2.mm256_bsrli_epi128(b, sizeof(int)));

                return Avx2.mm256_unpackhi_epi64(Avx2.mm256_unpacklo_epi32(even, odd),
                                                 Avx2.mm256_unpackhi_epi32(even, odd));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epu32(v256 a, v256 b) 
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = Avx2.mm256_mul_epu32(a, b);
                v256 odd  = Avx2.mm256_mul_epu32(Avx2.mm256_bsrli_epi128(a, sizeof(int)),
                                                 Avx2.mm256_bsrli_epi128(b, sizeof(int)));

                return Avx2.mm256_unpackhi_epi64(Avx2.mm256_unpacklo_epi32(even, odd),
                                                 Avx2.mm256_unpackhi_epi32(even, odd));
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mullo_epi64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU64(a, uint.MaxValue) && constexpr.ALL_LE_EPU64(b, uint.MaxValue))
                {
                    return Sse2.mul_epu32(a, b);
                }
                if (Sse4_1.IsSse41Supported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue) && constexpr.ALL_LE_EPI64(a, int.MaxValue) &&
                        constexpr.ALL_GE_EPI64(b, int.MinValue) && constexpr.ALL_LE_EPI64(b, int.MaxValue))
                    {
                        return Sse4_1.mul_epi32(a, b);
                    }
                }

                
                v128 lo = Sse2.mul_epu32(a, b);
                v128 hi;

                if (Sse4_1.IsSse41Supported)
                {
                    hi = Sse4_1.mullo_epi32(a, Sse2.shuffle_epi32(b, Sse.SHUFFLE(2, 3, 0, 1)));
                    hi = Ssse3.hadd_epi32(hi, Sse2.setzero_si128());
                    hi = Sse2.shuffle_epi32(hi, Sse.SHUFFLE(1, 3, 0, 3));
                }
                else
                {
                    v128 lhi = Sse2.mul_epu32(a, Sse2.srli_epi64(b, 32));
                    v128 rhi = Sse2.mul_epu32(b, Sse2.srli_epi64(a, 32));
                    hi = Sse2.slli_epi64(Sse2.add_epi64(lhi, rhi), 32);
                }

                return Sse2.add_epi64(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mullo_epi64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements) && constexpr.ALL_LE_EPU64(b, uint.MaxValue, elements))
                {
                    return Avx2.mm256_mul_epu32(a, b);
                }
                if (constexpr.ALL_GE_EPI64(a, int.MinValue, elements) && constexpr.ALL_LE_EPI64(a, int.MaxValue, elements) &&
                    constexpr.ALL_GE_EPI64(b, int.MinValue, elements) && constexpr.ALL_LE_EPI64(b, int.MaxValue, elements))
                {
                    return Avx2.mm256_mul_epi32(a, b);
                }
                

                v256 lo = Avx2.mm256_mul_epu32(a, b);

                v256 hi = Avx2.mm256_mullo_epi32(a, Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(2, 3, 0, 1)));
                hi = Avx2.mm256_hadd_epi32(hi, Avx.mm256_setzero_si256());
                hi = Avx2.mm256_shuffle_epi32(hi, Sse.SHUFFLE(1, 3, 0, 3));
                
                return Avx2.mm256_add_epi64(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epu64(v128 x, v128 y, out v128 low)
        {
            if (Sse2.IsSse2Supported)
            {
                low = new v128(Common.umul128(x.ULong0, y.ULong0, out ulong result0),
                               Common.umul128(x.ULong1, y.ULong1, out ulong result1));

                return new v128(result0, result1);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epi64(v128 x, v128 y, out v128 low)
        {
            if (Sse2.IsSse2Supported)
            {
                low = mulhi_epu64(x, y, out v128 high);

                if (constexpr.ALL_GE_EPI64(x, 0) && constexpr.ALL_GE_EPI64(y, 0))
                {
                    ;
                }
                else
                {
                    high = Sse2.sub_epi64(high, Sse2.add_epi64(Sse2.and_si128(y, srai_epi64(x, 63)), Sse2.and_si128(x, srai_epi64(y, 63))));
                }
                   
                return high;
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epu64(v256 x, v256 y, out v256 low, bool calcLow = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();

                v256 xHi = Avx2.mm256_shuffle_epi32(x, Sse.SHUFFLE(2, 3, 0, 1));
                v256 yHi = Avx2.mm256_shuffle_epi32(y, Sse.SHUFFLE(2, 3, 0, 1));

                v256 lo = Avx2.mm256_mul_epu32(x, y);
                v256 m1 = Avx2.mm256_mul_epu32(xHi, y);
                v256 m2 = Avx2.mm256_mul_epu32(x, yHi);
                v256 hi = Avx2.mm256_mul_epu32(xHi, yHi);

                v256 m1Lo = Avx2.mm256_blend_epi32(m1, ZERO, 0b1010_1010);
                v256 loHi = Avx2.mm256_srli_epi64(lo, 32);
                v256 m1Hi = Avx2.mm256_srli_epi64(m1, 32);

                if (calcLow)
                {
                    v256 product_Hi = Avx2.mm256_hadd_epi32(m2, ZERO);
                    product_Hi = Avx2.mm256_shuffle_epi32(product_Hi, Sse.SHUFFLE(1, 3, 0, 3));
                    
                    low = Avx2.mm256_add_epi64(lo, product_Hi);
                }
                else
                {
                    low = ZERO;
                }

                return Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(hi, m1Hi), Avx2.mm256_srli_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(loHi, m1Lo), m2), 32));
            }
            else throw new IllegalInstructionException();
        }
    }
}