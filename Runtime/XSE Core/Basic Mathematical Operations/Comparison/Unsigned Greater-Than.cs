using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu8(v128 a, v128 b, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU8(a, (byte)sbyte.MaxValue, elements) && constexpr.ALL_LE_EPU8(b, (byte)sbyte.MaxValue, elements))
                {
                    return cmpgt_epi8(a, b);
                }
                else
                {
                    if (constexpr.ALL_EQ_EPU8(b, byte.MaxValue, elements))
                    {
                        return setzero_si128();
                    }
                    if (constexpr.IS_CONST(b) && constexpr.ALL_LT_EPU8(b, byte.MaxValue, elements))
                    {
                        return cmpge_epu8(a, inc_epi8(b));
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_GT_EPU8(a, byte.MinValue, elements))
                    {
                        return cmple_epu8(b, dec_epi8(a));
                    }
                    if (constexpr.ALL_EQ_EPI8(b, sbyte.MaxValue, elements))
                    {
                        return cmpgt_epi8(setzero_si128(), a);
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_POW2_EPU8(a, elements))
                    {
                        return cmpeq_epi8(setzero_si128(), and_si128(b, neg_epi8(a)));
                    }


                    v128 mask = set1_epi8(1 << 7);

                    return cmpgt_epi8(xor_si128(a, mask),
                                      xor_si128(b, mask));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgtq_u8(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU8(a, (byte)sbyte.MaxValue) && constexpr.ALL_LE_EPU8(b, (byte)sbyte.MaxValue))
                {
                    return Avx2.mm256_cmpgt_epi8(a, b);
                }
                else
                {
                    if (constexpr.ALL_EQ_EPU8(b, byte.MaxValue))
                    {
                        return Avx.mm256_setzero_si256();
                    }
                    if (constexpr.IS_CONST(b) && constexpr.ALL_LT_EPU8(b, byte.MaxValue))
                    {
                        return mm256_cmpge_epu8(a, mm256_inc_epi8(b));
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_GT_EPU8(a, byte.MinValue))
                    {
                        return mm256_cmple_epu8(b, mm256_dec_epi8(a));
                    }
                    if (constexpr.ALL_EQ_EPI8(b, sbyte.MaxValue))
                    {
                        return Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a);
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_POW2_EPU8(a))
                    {
                        return Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(b, mm256_neg_epi8(a)));
                    }


                    v256 mask = mm256_set1_epi8(1 << 7);

                    return Avx2.mm256_cmpgt_epi8(Avx2.mm256_xor_si256(a, mask),
                                                 Avx2.mm256_xor_si256(b, mask));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu16(v128 a, v128 b, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue, elements))
                {
                    return cmpgt_epi16(a, b);
                }
                else
                {
                    if (constexpr.ALL_EQ_EPU16(b, ushort.MaxValue, elements))
                    {
                        return setzero_si128();
                    }
                    if (constexpr.IS_CONST(b) && constexpr.ALL_LT_EPU16(b, ushort.MaxValue, elements))
                    {
                        return cmpge_epu16(a, inc_epi16(b));
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_GT_EPU16(a, ushort.MinValue, elements))
                    {
                        return cmple_epu16(b, dec_epi16(a));
                    }
                    if (constexpr.ALL_EQ_EPI16(b, short.MaxValue, elements))
                    {
                        return srai_epi16(a, 15);
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_POW2_EPU16(a, elements))
                    {
                        return cmpeq_epi16(setzero_si128(), and_si128(b, neg_epi16(a)));
                    }


                    v128 mask = set1_epi16(1 << 15);

                    return cmpgt_epi16(xor_si128(a, mask),
                                       xor_si128(b, mask));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgtq_u16(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue))
                {
                    return Avx2.mm256_cmpgt_epi16(a, b);
                }
                else
                {
                    if (constexpr.ALL_EQ_EPU16(b, ushort.MaxValue))
                    {
                        return Avx.mm256_setzero_si256();
                    }
                    if (constexpr.IS_CONST(b) && constexpr.ALL_LT_EPU16(b, ushort.MaxValue))
                    {
                        return mm256_cmpge_epu16(a, mm256_inc_epi16(b));
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_GT_EPU16(a, ushort.MinValue))
                    {
                        return mm256_cmple_epu16(b, mm256_dec_epi16(a));
                    }
                    if (constexpr.ALL_EQ_EPI16(b, short.MaxValue))
                    {
                        return Avx2.mm256_srai_epi16(a, 15);
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_POW2_EPU16(a))
                    {
                        return Avx2.mm256_cmpeq_epi16(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(b, mm256_neg_epi16(a)));
                    }


                    v256 mask = mm256_set1_epi16(1 << 15);

                    return Avx2.mm256_cmpgt_epi16(Avx2.mm256_xor_si256(a, mask),
                                                  Avx2.mm256_xor_si256(b, mask));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue, elements) && constexpr.ALL_LE_EPU32(b, int.MaxValue, elements))
                {
                    return cmpgt_epi32(a, b);
                }
                else
                {
                    if (constexpr.ALL_EQ_EPU32(b, uint.MaxValue, elements))
                    {
                        return setzero_si128();
                    }
                    if (Sse4_1.IsSse41Supported)
                    {
                        if (constexpr.IS_CONST(b) && constexpr.ALL_LT_EPU32(b, uint.MaxValue, elements))
                        {
                            return cmpge_epu32(a, inc_epi32(b));
                        }
                        if (constexpr.IS_CONST(a) && constexpr.ALL_GT_EPU32(a, uint.MinValue, elements))
                        {
                            return cmple_epu32(b, dec_epi32(a));
                        }
                    }
                    if (constexpr.ALL_EQ_EPI32(b, int.MaxValue, elements))
                    {
                        return srai_epi32(a, 31);
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_POW2_EPU32(a, elements))
                    {
                        return cmpeq_epi32(setzero_si128(), and_si128(b, neg_epi32(a)));
                    }


                    v128 mask = new v128(1 << 31);

                    return cmpgt_epi32(xor_si128(a, mask),
                                       xor_si128(b, mask));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgtq_u32(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue) && constexpr.ALL_LE_EPU32(b, int.MaxValue))
                {
                    return Avx2.mm256_cmpgt_epi32(a, b);
                }
                else
                {
                    if (constexpr.ALL_EQ_EPU32(b, uint.MaxValue))
                    {
                        return Avx.mm256_setzero_si256();
                    }
                    if (constexpr.IS_CONST(b) && constexpr.ALL_LT_EPU32(b, uint.MaxValue))
                    {
                        return mm256_cmpge_epu32(a, mm256_inc_epi32(b));
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_GT_EPU32(a, uint.MinValue))
                    {
                        return mm256_cmple_epu32(b, mm256_dec_epi32(a));
                    }
                    if (constexpr.ALL_EQ_EPI32(b, int.MaxValue))
                    {
                        return Avx2.mm256_srai_epi32(a, 31);
                    }
                    if (constexpr.IS_CONST(a) && constexpr.ALL_POW2_EPU32(a))
                    {
                        return Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(b, mm256_neg_epi32(a)));
                    }


                    uint8 mask = 1u << 31;

                    return Avx2.mm256_cmpgt_epi32(Avx2.mm256_xor_si256(a, mask),
                                                  Avx2.mm256_xor_si256(b, mask));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(b, ulong.MaxValue))
                {
                    return setzero_si128();
                }
                if (constexpr.ALL_EQ_EPI64(b, long.MaxValue))
                {
                    v128 sign = srai_epi32(a, 31);
                    return shuffle_epi32(sign, Sse.SHUFFLE(3, 3, 1, 1));
                }
                if (constexpr.ALL_LE_EPU64(a, int.MaxValue) && constexpr.ALL_LE_EPU64(b, int.MaxValue))
                {
                    v128 cmp = cmpgt_epi32(a, b);
                    return shuffle_epi32(cmp, Sse.SHUFFLE(2, 2, 0, 0));
                }
                if (constexpr.ALL_LE_EPU64(a, long.MaxValue) && constexpr.ALL_LE_EPU64(b, long.MaxValue))
                {
                    return cmpgt_epi64(a, b);
                }
                if (constexpr.ALL_POW2_EPU64(a))
                {
                    return cmpeq_epi64(setzero_si128(), and_si128(b, neg_epi64(a)));
                }


                v128 mask = set1_epi64x(1ul << 63);

                return cmpgt_epi64(xor_si128(a, mask),
                                   xor_si128(b, mask));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgtq_u64(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu64(v256 a, v256 b, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU64(b, ulong.MaxValue, elements))
                {
                    return Avx.mm256_setzero_si256();
                }
                if (constexpr.ALL_EQ_EPI64(b, long.MaxValue, elements))
                {
                    v256 sign = Avx2.mm256_srai_epi32(a, 31);
                    return Avx2.mm256_shuffle_epi32(sign, Sse.SHUFFLE(3, 3, 1, 1));
                }
                if (constexpr.ALL_LE_EPU64(a, int.MaxValue, elements) && constexpr.ALL_LE_EPU64(b, int.MaxValue, elements))
                {
                    v256 cmp = Avx2.mm256_cmpgt_epi32(a, b);
                    return Avx2.mm256_shuffle_epi32(cmp, Sse.SHUFFLE(2, 2, 0, 0));
                }
                if (constexpr.ALL_LE_EPU64(a, long.MaxValue, elements) && constexpr.ALL_LE_EPU64(b, long.MaxValue, elements))
                {
                    return mm256_cmpgt_epi64(a, b, elements);
                }
                if (constexpr.ALL_POW2_EPU64(a, elements))
                {
                    return Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_and_si256(b, mm256_neg_epi64(a)));
                }


                v256 mask = mm256_set1_epi64x(1ul << 63);

                return mm256_cmpgt_epi64(Avx2.mm256_xor_si256(a, mask),
                                         Avx2.mm256_xor_si256(b, mask),
                                         elements);
            }
            else throw new IllegalInstructionException();
        }
    }
}