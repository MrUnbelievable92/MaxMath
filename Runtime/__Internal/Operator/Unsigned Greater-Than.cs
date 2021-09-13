using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_byte(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.set1_epi8(unchecked((sbyte)(1 << 7)));

                return Sse2.cmpgt_epi8(Sse2.xor_si128(left, mask),
                                       Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_byte(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 mask = Avx.mm256_set1_epi8(1 << 7);

                return Avx2.mm256_cmpgt_epi8(Avx2.mm256_xor_si256(left, mask),
                                             Avx2.mm256_xor_si256(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ushort(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.set1_epi16(unchecked((short)(1 << 15)));

                return Sse2.cmpgt_epi16(Sse2.xor_si128(left, mask),
                                        Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ushort(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 mask = Avx.mm256_set1_epi16(unchecked((short)(1 << 15)));

                return Avx2.mm256_cmpgt_epi16(Avx2.mm256_xor_si256(left, mask),
                                              Avx2.mm256_xor_si256(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_uint(v128 left, v128 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = new v128(1 << 31);

                return Sse2.cmpgt_epi32(Sse2.xor_si128(left, mask),
                                        Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_uint(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                uint8 mask = 1u << 31;

                return Avx2.mm256_cmpgt_epi32(Avx2.mm256_xor_si256(left, mask),
                                              Avx2.mm256_xor_si256(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ulong(v128 left, v128 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 mask = Sse2.set1_epi64x(unchecked((long)(1ul << 63)));

                return Operator.greater_mask_long(Sse2.xor_si128(left, mask),
                                                  Sse2.xor_si128(right, mask));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 mask32 = new v128(1u << 31);

                v128 equal32 = Sse2.cmpeq_epi32(left, right);
                v128 larger32 = Sse2.cmpgt_epi32(Sse2.xor_si128(left, mask32),
                                                 Sse2.xor_si128(right, mask32));

                v128 equal64 = Sse2.and_si128(equal32, Sse2.shuffle_epi32(larger32, Sse.SHUFFLE(2, 2, 0, 0)));
                v128 larger64 = Sse2.or_si128(larger32, equal64);

                return Sse2.shuffle_epi32(larger64, Sse.SHUFFLE(3, 3, 1, 1));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ulong(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 mask = Avx.mm256_set1_epi64x(unchecked((long)(1ul << 63)));

                return Avx2.mm256_cmpgt_epi64(Avx2.mm256_xor_si256(left, mask),
                                              Avx2.mm256_xor_si256(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }
    }
}