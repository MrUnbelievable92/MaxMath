using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long imul128(long x, long y, out long hi)
        {
            ulong lo = Common.umul128((ulong)x, (ulong)y, out ulong high);

            if (Constant.IsConstantExpression(x >= 0 && y >= 0) && (x >= 0 && y >= 0))
            {
                ;
            }
            else
            {
                high -= (ulong)(((x >> 63) & y) + ((y >> 63) & x));
            }
                
            hi = (long)high;
            return (long)lo;
        }


        // AVX2 to SSE fallback

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 mul_byte(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 productEvenIndices = Sse2.mullo_epi16(left, right);

                left = Sse2.srli_epi16(left, 8);
                right = Sse2.srli_epi16(right, 8);

                v128 productOddIndices = Sse2.slli_epi16(Sse2.mullo_epi16(left, right), 8);

                return Mask.BlendV(productEvenIndices, productOddIndices, new v128(0xFF00_FF00));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mul_byte(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 productEvenIndices = Avx2.mm256_mullo_epi16(left, right);

                left = Avx2.mm256_srli_epi16(left, 8);
                right = Avx2.mm256_srli_epi16(right, 8);

                v256 productOddIndices = Avx2.mm256_slli_epi16(Avx2.mm256_mullo_epi16(left, right), 8);

                return Avx2.mm256_blendv_epi8(productEvenIndices, productOddIndices, new v256(0xFF00_FF00));
            }
            else throw new CPUFeatureCheckException();
        }


        // SSE2 

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 mul_int(v128 left, v128 right) 
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.mullo_epi32(left, right);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 even = Sse2.mul_epu32(left, right);
                v128 odd  = Sse2.mul_epu32(Sse2.shuffle_epi32(left,  Sse.SHUFFLE(3, 3, 1, 1)),
                                           Sse2.shuffle_epi32(right, Sse.SHUFFLE(3, 3, 1, 1)));

                return Sse2.unpacklo_epi64(Sse2.unpacklo_epi32(even, odd),
                                           Sse2.unpackhi_epi32(even, odd));
            }
            else throw new CPUFeatureCheckException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 mul_long(v128 left, v128 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 product_Lo = Sse2.mul_epu32(left, right);

                v128 product_Hi = Sse4_1.mullo_epi32(left, Sse2.shuffle_epi32(right, Sse.SHUFFLE(2, 3, 0, 1)));
                product_Hi = Ssse3.hadd_epi32(product_Hi, Sse2.setzero_si128());
                product_Hi = Sse2.shuffle_epi32(product_Hi, Sse.SHUFFLE(1, 3, 0, 3));

                return Sse2.add_epi64(product_Hi, product_Lo);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ac = Sse2.mul_epu32(left, right);
                v128 b = Sse2.srli_epi64(left, 32);

                v128 bc = Sse2.mul_epu32(b, right);
                v128 d = Sse2.srli_epi64(right, 32);
                v128 ad = Sse2.mul_epu32(left, d);

                v128 hi = Sse2.add_epi64(bc, ad);
                hi = Sse2.slli_epi64(hi, 32);

                return Sse2.add_epi64(hi, ac);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mul_long(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 product_Lo = Avx2.mm256_mul_epu32(left, right);

                v256 product_Hi = Avx2.mm256_mullo_epi32(left, Avx2.mm256_shuffle_epi32(right, Sse.SHUFFLE(2, 3, 0, 1)));
                product_Hi = Avx2.mm256_hadd_epi32(product_Hi, Avx.mm256_setzero_si256());
                product_Hi = Avx2.mm256_shuffle_epi32(product_Hi, Sse.SHUFFLE(1, 3, 0, 3));
                
                return Avx2.mm256_add_epi64(product_Hi, product_Lo);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 umul128(v256 x, v256 y, out v256 high, bool low = true)
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

                high = Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(hi, m1Hi), Avx2.mm256_srli_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(loHi, m1Lo), m2), 32));

                if (low)
                {
                    v256 product_Hi = Avx2.mm256_hadd_epi32(m2, ZERO);
                    product_Hi = Avx2.mm256_shuffle_epi32(product_Hi, Sse.SHUFFLE(1, 3, 0, 3));
                    
                    return Avx2.mm256_add_epi64(product_Hi, lo);
                }
                else
                {
                    return ZERO;
                }
            }
            else throw new CPUFeatureCheckException();
        }
    }
}