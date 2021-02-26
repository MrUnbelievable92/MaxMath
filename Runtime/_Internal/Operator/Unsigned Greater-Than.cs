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
                byte4 mask = 1 << 7;

                return Sse2.cmpgt_epi8(Sse2.xor_si128(left, mask),
                                       Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_byte(byte8 left, byte8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                byte8 mask = 1 << 7;

                return Sse2.cmpgt_epi8(Sse2.xor_si128(left, mask),
                                       Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_byte(byte16 left, byte16 right)
        {
            if (Sse2.IsSse2Supported)
            {
                byte16 mask = 1 << 7;

                return Sse2.cmpgt_epi8(Sse2.xor_si128(left, mask),
                                       Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_byte(byte32 left, byte32 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 mask = 1 << 7;

                return Avx2.mm256_cmpgt_epi8(Avx2.mm256_xor_si256(left, mask),
                                             Avx2.mm256_xor_si256(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ushort(ushort2 left, ushort2 right)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort2 mask = 1 << 15;

                return Sse2.cmpgt_epi16(Sse2.xor_si128(left, mask),
                                        Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ushort(ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort4 mask = 1 << 15;

                return Sse2.cmpgt_epi16(Sse2.xor_si128(left, mask),
                                        Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ushort(ushort4 left, ushort4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort4 mask = 1 << 15;

                return Sse2.cmpgt_epi16(Sse2.xor_si128(left, mask),
                                        Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 greater_mask_ushort(ushort8 left, ushort8 right)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort8 mask = 1 << 15;

                return Sse2.cmpgt_epi16(Sse2.xor_si128(left, mask),
                                        Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ushort(ushort16 left, ushort16 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                ushort16 mask = 1 << 15;

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
        internal static v256 greater_mask_uint(uint8 left, uint8 right)
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
        internal static v128 greater_mask_ulong(ulong2 left, ulong2 right)
        {
            if (Sse4_2.IsSse42Supported)
            {
                ulong2 mask = 1ul << 63;

                return Sse4_2.cmpgt_epi64(Sse2.xor_si128(left, mask),
                                          Sse2.xor_si128(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 greater_mask_ulong(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                ulong4 mask = 1ul << 63;

                return Avx2.mm256_cmpgt_epi64(Avx2.mm256_xor_si256(left, mask),
                                              Avx2.mm256_xor_si256(right, mask));
            }
            else throw new CPUFeatureCheckException();
        }
    }
}