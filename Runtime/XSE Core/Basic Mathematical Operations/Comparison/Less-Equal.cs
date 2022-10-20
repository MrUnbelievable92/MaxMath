using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmple_epu8(v128 a, v128 b, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPU8(a, (byte)sbyte.MaxValue, elements) && constexpr.ALL_LT_EPU8(b, (byte)sbyte.MaxValue, elements))
                {
                    if (Constant.IsConstantExpression(b))
                    {
                        return Sse2.cmpgt_epi8(inc_epi8(b), a);
                    }
                    if (Constant.IsConstantExpression(a))
                    {
                        return Sse2.cmpgt_epi8(b, dec_epi8(a));
                    }
                }


                return Sse2.cmpeq_epi8(Sse2.min_epu8(a, b), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmple_epu16(v128 a, v128 b, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LT_EPU16(b, (ushort)short.MaxValue, elements))
                {
                    if (Constant.IsConstantExpression(b))
                    {
                        return Sse2.cmpgt_epi16(inc_epi16(b), a);
                    }
                    if (Constant.IsConstantExpression(a))
                    {
                        return Sse2.cmpgt_epi16(b, dec_epi16(a));
                    }
                }


                if (Sse4_1.IsSse41Supported)
                {
                    return Sse2.cmpeq_epi16(Sse4_1.min_epu16(a, b), a);
                }
                else
                {
                    return Sse2.cmpeq_epi16(Sse2.setzero_si128(), Sse2.subs_epu16(a, b));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmple_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPU32(a, (uint)int.MaxValue, elements) && constexpr.ALL_LT_EPU32(b, (uint)int.MaxValue, elements))
                {
                    if (Constant.IsConstantExpression(b))
                    {
                        return Sse2.cmpgt_epi32(inc_epi32(b), a);
                    }
                    if (Constant.IsConstantExpression(a))
                    {
                        return Sse2.cmpgt_epi32(b, dec_epi32(a));
                    }
                }


                return Sse2.cmpeq_epi32(min_epu32(a, b, elements), a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmple_epu8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPU8(a, (byte)sbyte.MaxValue) && constexpr.ALL_LT_EPU8(b, (byte)sbyte.MaxValue))
                {
                    if (Constant.IsConstantExpression(b))
                    {
                        return Avx2.mm256_cmpgt_epi8(mm256_inc_epi8(b), a);
                    }
                    if (Constant.IsConstantExpression(a))
                    {
                        return Avx2.mm256_cmpgt_epi8(b, mm256_dec_epi8(a));
                    }
                }


                return Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(a, b), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmple_epu16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPU16(a, (ushort)short.MaxValue) && constexpr.ALL_LT_EPU16(b, (ushort)short.MaxValue))
                {
                    if (Constant.IsConstantExpression(b))
                    {
                        return Avx2.mm256_cmpgt_epi16(mm256_inc_epi16(b), a);
                    }
                    if (Constant.IsConstantExpression(a))
                    {
                        return Avx2.mm256_cmpgt_epi16(b, mm256_dec_epi16(a));
                    }
                }


                return Avx2.mm256_cmpeq_epi16(Avx2.mm256_min_epu16(a, b), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmple_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LT_EPU32(b, (uint)int.MaxValue))
                {
                    if (Constant.IsConstantExpression(b))
                    {
                        return Avx2.mm256_cmpgt_epi32(mm256_inc_epi32(b), a);
                    }
                    if (Constant.IsConstantExpression(a))
                    {
                        return Avx2.mm256_cmpgt_epi32(b, mm256_dec_epi32(a));
                    }
                }


                return Avx2.mm256_cmpeq_epi32(Avx2.mm256_min_epu32(a, b), a);
            }
            else throw new IllegalInstructionException();
        }
    }
}
