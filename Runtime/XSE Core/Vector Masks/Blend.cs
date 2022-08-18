using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_blendv_si256(v256 a, v256 b, v256 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not byte-by-byte
            //    return mm256_ternarylogic_si256(A, B, C, TernaryOperation.OxD8);
            //}
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_blendv_epi8(a, b, mask);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blendv_si128(v128 a, v128 b, v128 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not byte-by-byte
            //    return ternarylogic_si128(A, B, C, TernaryOperation.OxD8);
            //}
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blendv_epi8(a, b, mask);
            }
            else if (Sse2.IsSse2Supported)
            {
                // UNSAFE - performs bit-by-bit blend and not byte-by-byte
                return Sse2.or_si128(Sse2.and_si128(mask, b),
                                     Sse2.andnot_si128(mask, a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blendv_ps(v128 a, v128 b, v128 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not byte-by-byte
            //    return ternarylogic_si128(A, B, C, TernaryOperation.OxD8);
            //}
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blendv_ps(a, b, mask);
            }
            else if (Sse2.IsSse2Supported)
            {
                // UNSAFE - performs bit-by-bit blend and not byte-by-byte
                return Sse.or_ps(Sse.and_ps(mask, b),
                                 Sse.andnot_ps(mask, a));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blendv_pd(v128 a, v128 b, v128 mask)
        {
            //if (Avx512.IsAvx512Supported)
            //{
            //    UNSAFE - performs bit-by-bit blend and not byte-by-byte
            //    return ternarylogic_si128(A, B, C, TernaryOperation.OxD8);
            //}
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blendv_pd(a, b, mask);
            }
            else if (Sse2.IsSse2Supported)
            {
                // UNSAFE - performs bit-by-bit blend and not byte-by-byte
                return Sse2.or_pd(Sse2.and_pd(mask, b),
                                  Sse2.andnot_pd(mask, a));
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 blend_epi16(v128 a, v128 b, byte bitmask)
        {
            //if (Sse4_1.IsSse41Supported)
            //{
            //    if (Constant.IsConstantExpression(bitmask))
            //    {
            //        return Sse4_1.blend_epi16(a, b, bitmask);
            //    }
            //}
            if (Sse2.IsSse2Supported)
            {
                return blendv_si128(a, b, new v128((short)(-((bitmask >> 0) & 1)),
                                                   (short)(-((bitmask >> 1) & 1)),
                                                   (short)(-((bitmask >> 2) & 1)),
                                                   (short)(-((bitmask >> 3) & 1)),
                                                   (short)(-((bitmask >> 4) & 1)),
                                                   (short)(-((bitmask >> 5) & 1)),
                                                   (short)(-((bitmask >> 6) & 1)),
                                                   (short)(-((bitmask >> 7) & 1))));
            }
            else throw new IllegalInstructionException();
        }
    }
}
