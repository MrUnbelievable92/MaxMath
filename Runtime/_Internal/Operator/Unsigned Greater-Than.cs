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
            byte16 mask = 1 << 7;

            return Sse2.cmpgt_epi8(Sse2.xor_si128(left, mask),
                                   Sse2.xor_si128(right, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_byte(byte32 left, byte32 right)
        {
            byte32 mask = 1 << 7;

            return Avx2.mm256_cmpgt_epi8(Avx2.mm256_xor_si256(left, mask),
                                         Avx2.mm256_xor_si256(right, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ushort(v128 left, v128 right)
        {
            ushort8 mask = 1 << 15;

            return Sse2.cmpgt_epi16(Sse2.xor_si128(left, mask),
                                    Sse2.xor_si128(right, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ushort(ushort16 left, ushort16 right)
        {
            ushort16 mask = 1 << 15;

            return Avx2.mm256_cmpgt_epi16(Avx2.mm256_xor_si256(left, mask),
                                          Avx2.mm256_xor_si256(right, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_uint(uint8 left, uint8 right)
        {
            uint8 mask = 1u << 31;

            return Avx2.mm256_cmpgt_epi32(Avx2.mm256_xor_si256(left, mask),
                                          Avx2.mm256_xor_si256(right, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ulong(ulong2 left, ulong2 right)
        {
            ulong2 mask = 1ul << 63;

            return Sse4_2.cmpgt_epi64(Sse2.xor_si128(left, mask),
                                      Sse2.xor_si128(right, mask));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ulong(v256 left, v256 right)
        {
            ulong4 mask = 1ul << 63;

            return Avx2.mm256_cmpgt_epi64(Avx2.mm256_xor_si256(left, mask),
                                          Avx2.mm256_xor_si256(right, mask));
        }
    }
}