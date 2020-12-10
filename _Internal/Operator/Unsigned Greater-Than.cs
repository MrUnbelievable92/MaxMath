using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_byte(byte32 lhs, byte32 rhs)
        {
            byte32 mask = 1 << 7;

            byte32 lhs_sign = lhs & mask;
            byte32 rhs_sign = rhs & mask;

            return Avx2.mm256_blendv_epi8(Avx2.mm256_cmpgt_epi8(rhs_sign, lhs_sign),
                                          Avx2.mm256_cmpgt_epi8(maxmath.andn(lhs, mask), maxmath.andn(rhs, mask)),
                                          Avx2.mm256_cmpeq_epi8(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ushort(ushort16 lhs, ushort16 rhs)
        {
            ushort16 mask = (ushort)maxmath.bitmask32(15);

            ushort16 lhs_sign = Avx2.mm256_srai_epi16(lhs, 31);
            ushort16 rhs_sign = Avx2.mm256_srai_epi16(rhs, 31);

            return Avx2.mm256_blendv_epi8(lhs_sign,
                                          Avx2.mm256_cmpgt_epi16(lhs & mask, rhs & mask),
                                          Avx2.mm256_cmpeq_epi16(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_uint(uint8 lhs, uint8 rhs)
        {
            uint8 mask = maxmath.bitmask32(31);

            int8 lhs_sign = Avx2.mm256_srai_epi32(lhs, 31);
            int8 rhs_sign = Avx2.mm256_srai_epi32(rhs, 31);

            return Avx2.mm256_blendv_epi8(lhs_sign,
                                          Avx2.mm256_cmpgt_epi32(lhs & mask, rhs & mask),
                                          Avx2.mm256_cmpeq_epi32(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ulong(ulong2 lhs, ulong2 rhs)
        {
            ulong2 mask = 1ul << 63;

            ulong2 lhs_sign = lhs & mask;
            ulong2 rhs_sign = rhs & mask;

            return Sse4_1.blendv_epi8(Sse4_2.cmpgt_epi64(rhs_sign, lhs_sign),
                                      Sse4_2.cmpgt_epi64(maxmath.andn(lhs, mask), maxmath.andn(rhs, mask)),
                                      Sse4_1.cmpeq_epi64(rhs_sign, lhs_sign));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ulong(v256 lhs, v256 rhs)
        {
            ulong4 mask = 1ul << 63;

            ulong4 lhs_sign = lhs & mask;
            ulong4 rhs_sign = rhs & mask;

            return Avx2.mm256_blendv_epi8(Avx2.mm256_cmpgt_epi64(rhs_sign, lhs_sign),
                                          Avx2.mm256_cmpgt_epi64(maxmath.andn(lhs, mask), maxmath.andn(rhs, mask)),
                                          Avx2.mm256_cmpeq_epi64(rhs_sign, lhs_sign));
        }
    }
}