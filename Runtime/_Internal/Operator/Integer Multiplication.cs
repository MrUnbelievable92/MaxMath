using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mul_byte(v256 lhs, v256 rhs)
        {
            v256 productEvenIndices = Avx2.mm256_mullo_epi16(lhs, rhs);

            lhs = Avx2.mm256_srli_epi16(lhs, 8);
            rhs = Avx2.mm256_srli_epi16(rhs, 8);

            v256 productOddIndices = Avx2.mm256_slli_epi16(Avx2.mm256_mullo_epi16(lhs, rhs), 8);

            return Avx2.mm256_blendv_epi8(productOddIndices,
                                          productEvenIndices,
                                          new v256(0x00FF_00FF));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mul_long(v128 lhs, v128 rhs)
        {
            v128 product_Lo = Sse2.mul_epu32(lhs, rhs);

            v128 product_Hi = Sse4_1.mullo_epi32(lhs, Sse2.shuffle_epi32(rhs, Sse.SHUFFLE(2, 3, 0, 1)));
            product_Hi = Ssse3.hadd_epi32(product_Hi, default(v128));
            product_Hi = Sse2.shuffle_epi32(product_Hi, Sse.SHUFFLE(1, 3, 0, 3)); 
            
            return Sse2.add_epi64(product_Lo, product_Hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mul_long(v256 lhs, v256 rhs)
        {
            v256 product_Lo = Avx2.mm256_mul_epu32(lhs, rhs);

            v256 product_Hi = Avx2.mm256_mullo_epi32(lhs, Avx2.mm256_shuffle_epi32(rhs, Sse.SHUFFLE(2, 3, 0, 1)));
            product_Hi = Avx2.mm256_hadd_epi32(product_Hi, default(v256));
            product_Hi = Avx2.mm256_shuffle_epi32(product_Hi, Sse.SHUFFLE(1, 3, 0, 3));
            
            return Avx2.mm256_add_epi64(product_Lo, product_Hi);
        }
    }
}