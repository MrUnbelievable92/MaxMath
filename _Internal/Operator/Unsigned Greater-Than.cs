using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_byte(v128 lhs, v128 rhs)
        {
            byte16 mask = 1 << 7;

            return Sse2.cmpgt_epi8(Sse2.xor_si128(lhs, mask),
                                   Sse2.xor_si128(rhs, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_byte(byte32 lhs, byte32 rhs)
        {
            byte32 mask = 1 << 7;

            return Avx2.mm256_cmpgt_epi8(Avx2.mm256_xor_si256(lhs, mask),
                                         Avx2.mm256_xor_si256(rhs, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ushort(v128 lhs, v128 rhs)
        {
            ushort8 mask = 1 << 15;

            return Sse2.cmpgt_epi16(Sse2.xor_si128(lhs, mask),
                                    Sse2.xor_si128(rhs, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ushort(ushort16 lhs, ushort16 rhs)
        {
            ushort16 mask = 1 << 15;

            return Avx2.mm256_cmpgt_epi16(Avx2.mm256_xor_si256(lhs, mask),
                                          Avx2.mm256_xor_si256(rhs, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_uint(uint8 lhs, uint8 rhs)
        {
            uint8 mask = 1u << 31;

            return Avx2.mm256_cmpgt_epi32(Avx2.mm256_xor_si256(lhs, mask),
                                          Avx2.mm256_xor_si256(rhs, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ulong(ulong2 lhs, ulong2 rhs)
        {
            ulong2 mask = 1ul << 63;

            return Sse4_2.cmpgt_epi64(Sse2.xor_si128(lhs, mask),
                                      Sse2.xor_si128(rhs, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ulong(v256 lhs, v256 rhs)
        {
            ulong4 mask = 1ul << 63;

            return Avx2.mm256_cmpgt_epi64(Avx2.mm256_xor_si256(lhs, mask),
                                          Avx2.mm256_xor_si256(rhs, mask));
        }
    }
}