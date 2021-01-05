using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mul_byte(v256 left, v256 right)
        {
            v256 productEvenIndices = Avx2.mm256_mullo_epi16(left, right);

            left = Avx2.mm256_srli_epi16(left, 8);
            right = Avx2.mm256_srli_epi16(right, 8);

            v256 productOddIndices = Avx2.mm256_slli_epi16(Avx2.mm256_mullo_epi16(left, right), 8);

            return Avx2.mm256_blendv_epi8(productEvenIndices, productOddIndices, new v256(0xFF00_FF00));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 mul_long(v128 left, v128 right)
        {
            v128 product_Hi = Sse2.mul_epu32(left, right);

            v128 product_Lo = Sse4_1.mullo_epi32(left, Sse2.shuffle_epi32(right, Sse.SHUFFLE(2, 3, 0, 1)));
            product_Lo = Ssse3.hadd_epi32(product_Lo, default(v128));
            product_Lo = Sse2.shuffle_epi32(product_Lo, Sse.SHUFFLE(1, 3, 0, 3)); 
            
            return Sse2.add_epi64(product_Lo, product_Hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mul_long(v256 left, v256 right)
        {
            v256 product_Hi = Avx2.mm256_mul_epu32(left, right);

            v256 product_Lo = Avx2.mm256_mullo_epi32(left, Avx2.mm256_shuffle_epi32(right, Sse.SHUFFLE(2, 3, 0, 1)));
            product_Lo = Avx2.mm256_hadd_epi32(product_Lo, default(v256));
            product_Lo = Avx2.mm256_shuffle_epi32(product_Lo, Sse.SHUFFLE(1, 3, 0, 3));
            
            return Avx2.mm256_add_epi64(product_Lo, product_Hi);
        }
    }
}