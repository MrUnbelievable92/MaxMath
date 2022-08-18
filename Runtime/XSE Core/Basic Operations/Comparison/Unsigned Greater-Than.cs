using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu8(v128 left, v128 right, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU8(left, (byte)sbyte.MaxValue, elements) && constexpr.ALL_LE_EPU8(right, (byte)sbyte.MaxValue, elements))
                {
                    return Sse2.cmpgt_epi8(left, right);
                }
                else
                {
                    if (Constant.IsConstantExpression(right) && constexpr.ALL_LT_EPU8(right, byte.MaxValue, elements))
                    {
                        return cmpge_epu8(left, inc_epi8(right));
                    }
                    if (Constant.IsConstantExpression(left) && constexpr.ALL_GT_EPU8(left, byte.MinValue, elements))
                    {
                        return cmple_epu8(right, dec_epi8(left));
                    }
                    if (constexpr.ALL_EQ_EPI8(right, sbyte.MaxValue, elements))
                    {
                        return Sse2.cmpgt_epi8(Sse2.setzero_si128(), left);
                    }


                    v128 mask = Sse2.set1_epi8(unchecked((sbyte)(1 << 7)));

                    return Sse2.cmpgt_epi8(Sse2.xor_si128(left, mask),
                                           Sse2.xor_si128(right, mask));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu8(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU8(left, (byte)sbyte.MaxValue) && constexpr.ALL_LE_EPU8(right, (byte)sbyte.MaxValue))
                {
                    return Avx2.mm256_cmpgt_epi8(left, right);
                }
                else
                {
                    if (Constant.IsConstantExpression(right) && constexpr.ALL_LT_EPU8(right, byte.MaxValue))
                    {
                        return mm256_cmpge_epu8(left, mm256_inc_epi8(right));
                    }
                    if (Constant.IsConstantExpression(left) && constexpr.ALL_GT_EPU8(left, byte.MinValue))
                    {
                        return mm256_cmple_epu8(right, mm256_dec_epi8(left));
                    }
                    if (constexpr.ALL_EQ_EPI8(right, sbyte.MaxValue))
                    {
                        return Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), left);
                    }


                    v256 mask = Avx.mm256_set1_epi8(1 << 7);

                    return Avx2.mm256_cmpgt_epi8(Avx2.mm256_xor_si256(left, mask),
                                                 Avx2.mm256_xor_si256(right, mask));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu16(v128 left, v128 right, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU16(left, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(right, (ushort)short.MaxValue, elements))
                {
                    return Sse2.cmpgt_epi16(left, right);
                }
                else
                {
                    if (Constant.IsConstantExpression(right) && constexpr.ALL_LT_EPU16(right, ushort.MaxValue, elements))
                    {
                        return cmpge_epu16(left, inc_epi16(right));
                    }
                    if (Constant.IsConstantExpression(left) && constexpr.ALL_GT_EPU16(left, ushort.MinValue, elements))
                    {
                        return cmple_epu16(right, dec_epi16(left));
                    }
                    if (constexpr.ALL_EQ_EPI16(right, short.MaxValue, elements))
                    {
                        return Sse2.srai_epi16(left, 15);
                    }


                    v128 mask = Sse2.set1_epi16(unchecked((short)(1 << 15)));

                    return Sse2.cmpgt_epi16(Sse2.xor_si128(left, mask),
                                            Sse2.xor_si128(right, mask));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu16(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU16(left, (ushort)short.MaxValue) && constexpr.ALL_LE_EPU16(right, (ushort)short.MaxValue))
                {
                    return Avx2.mm256_cmpgt_epi16(left, right);
                }
                else
                {
                    if (Constant.IsConstantExpression(right) && constexpr.ALL_LT_EPU16(right, ushort.MaxValue))
                    {
                        return mm256_cmpge_epu16(left, mm256_inc_epi16(right));
                    }
                    if (Constant.IsConstantExpression(left) && constexpr.ALL_GT_EPU16(left, ushort.MinValue))
                    {
                        return mm256_cmple_epu16(right, mm256_dec_epi16(left));
                    }
                    if (constexpr.ALL_EQ_EPI16(right, short.MaxValue))
                    {
                        return Avx2.mm256_srai_epi16(left, 15);
                    }


                    v256 mask = Avx.mm256_set1_epi16(unchecked((short)(1 << 15)));

                    return Avx2.mm256_cmpgt_epi16(Avx2.mm256_xor_si256(left, mask),
                                                  Avx2.mm256_xor_si256(right, mask));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu32(v128 left, v128 right, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU32(left, int.MaxValue, elements) && constexpr.ALL_LE_EPU32(right, int.MaxValue, elements))
                {
                    return Sse2.cmpgt_epi32(left, right);
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        if (Constant.IsConstantExpression(right) && constexpr.ALL_LT_EPU32(right, uint.MaxValue, elements))
                        {
                            return cmpge_epu32(left, inc_epi32(right));
                        }
                        if (Constant.IsConstantExpression(left) && constexpr.ALL_GT_EPU32(left, uint.MinValue, elements))
                        {
                            return cmple_epu32(right, dec_epi32(left));
                        }
                    }
                    if (constexpr.ALL_EQ_EPI32(right, int.MaxValue, elements))
                    {
                        return Sse2.srai_epi32(left, 31);
                    }


                    v128 mask = new v128(1 << 31);

                    return Sse2.cmpgt_epi32(Sse2.xor_si128(left, mask),
                                            Sse2.xor_si128(right, mask));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu32(v256 left, v256 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU32(left, int.MaxValue) && constexpr.ALL_LE_EPU32(right, int.MaxValue))
                {
                    return Avx2.mm256_cmpgt_epi32(left, right);
                }
                else
                {
                    if (Constant.IsConstantExpression(right) && constexpr.ALL_LT_EPU32(right, uint.MaxValue))
                    {
                        return mm256_cmpge_epu32(left, mm256_inc_epi32(right));
                    }
                    if (Constant.IsConstantExpression(left) && constexpr.ALL_GT_EPU32(left, uint.MinValue))
                    {
                        return mm256_cmple_epu32(right, mm256_dec_epi32(left));
                    }
                    if (constexpr.ALL_EQ_EPI32(right, int.MaxValue))
                    {
                        return Avx2.mm256_srai_epi32(left, 31);
                    }


                    uint8 mask = 1u << 31;

                    return Avx2.mm256_cmpgt_epi32(Avx2.mm256_xor_si256(left, mask),
                                                  Avx2.mm256_xor_si256(right, mask));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpgt_epu64(v128 a, v128 b)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(b, long.MaxValue))
                {
                    v128 sign = Sse2.srai_epi32(a, 31);
                    return Sse2.shuffle_epi32(sign, Sse.SHUFFLE(3, 3, 1, 1));
                }
                if (constexpr.ALL_LE_EPU64(a, int.MaxValue) && constexpr.ALL_LE_EPU64(b, int.MaxValue))
                {
                    v128 cmp = Sse2.cmpgt_epi32(a, b);
                    return Sse2.shuffle_epi32(cmp, Sse.SHUFFLE(2, 2, 0, 0));
                }
                if (constexpr.ALL_LE_EPU64(a, long.MaxValue) && constexpr.ALL_LE_EPU64(b, long.MaxValue))
                {
                    return cmpgt_epi64(a, b);
                }
                
                
                v128 mask = Sse2.set1_epi64x(unchecked((long)(1ul << 63)));
                
                return cmpgt_epi64(Sse2.xor_si128(a, mask),
                                   Sse2.xor_si128(b, mask));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpgt_epu64(v256 left, v256 right, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(right, long.MaxValue, elements))
                {
                    v256 sign = Avx2.mm256_srai_epi32(left, 31);
                    return Avx2.mm256_shuffle_epi32(sign, Sse.SHUFFLE(3, 3, 1, 1));
                }
                if (constexpr.ALL_LE_EPU64(left, int.MaxValue, elements) && constexpr.ALL_LE_EPU64(right, int.MaxValue, elements))
                {
                    v256 cmp = Avx2.mm256_cmpgt_epi32(left, right);
                    return Avx2.mm256_shuffle_epi32(cmp, Sse.SHUFFLE(2, 2, 0, 0));
                }
                if (constexpr.ALL_LE_EPU64(left, long.MaxValue, elements) && constexpr.ALL_LE_EPU64(right, long.MaxValue, elements))
                {
                    return mm256_cmpgt_epi64(left, right, elements);
                }


                v256 mask = Avx.mm256_set1_epi64x(unchecked((long)(1ul << 63)));
                
                return mm256_cmpgt_epi64(Avx2.mm256_xor_si256(left, mask),
                                         Avx2.mm256_xor_si256(right, mask),
                                         elements);
            }
            else throw new IllegalInstructionException();
        }
    }
}