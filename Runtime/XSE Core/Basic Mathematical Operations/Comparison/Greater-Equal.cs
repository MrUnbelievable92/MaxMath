using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpge_epu8(v128 a, v128 b, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU8(b, 1 << 7, elements))
                {
                    return cmpgt_epi8(setzero_si128(), a);
                }
                if (constexpr.ALL_LT_EPU8(a, (byte)sbyte.MaxValue, elements) && constexpr.ALL_LE_EPU8(b, (byte)sbyte.MaxValue, elements))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return cmpgt_epi8(a, dec_epi8(b));
                    }
                    if (constexpr.IS_CONST(a))
                    {
                        return cmpgt_epi8(inc_epi8(a), b);
                    }
                }


                return cmpeq_epi8(max_epu8(a, b), a);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgeq_u8(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpge_epu16(v128 a, v128 b, byte elements = 8)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU16(b, 1 << 15, elements))
                {
                    return srai_epi16(a, 15);
                }
                if (constexpr.ALL_LT_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LT_EPU16(b, (ushort)short.MaxValue, elements))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return cmpgt_epi16(a, dec_epi16(b));
                    }
                    if (constexpr.IS_CONST(a))
                    {
                        return cmpgt_epi16(inc_epi16(a), b);
                    }
                }


                if (Sse4_1.IsSse41Supported)
                {
                    return cmpeq_epi16(max_epu16(a, b), a);
                }
                else
                {
                    return cmpeq_epi16(setzero_si128(), subs_epu16(b, a));
                }
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgeq_u16(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cmpge_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_EQ_EPU32(b, 1u << 31, elements))
                {
                    return srai_epi32(a, 31);
                }
                if (constexpr.ALL_LT_EPU32(a, (uint)int.MaxValue, elements) && constexpr.ALL_LT_EPU32(b, (uint)int.MaxValue, elements))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return cmpgt_epi32(a, dec_epi32(b));
                    }
                    if (constexpr.IS_CONST(a))
                    {
                        return cmpgt_epi32(inc_epi32(a), b);
                    }
                }


                return cmpeq_epi32(max_epu32(a, b, elements), a);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vcgeq_u32(a, b);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpge_epu8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU8(b, 1 << 7))
                {
                    return Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a);
                }
                if (constexpr.ALL_LT_EPU8(a, (byte)sbyte.MaxValue) && constexpr.ALL_LT_EPU8(b, (byte)sbyte.MaxValue))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return Avx2.mm256_cmpgt_epi8(a, mm256_dec_epi8(b));
                    }
                    if (constexpr.IS_CONST(a))
                    {
                        return Avx2.mm256_cmpgt_epi8(mm256_inc_epi8(a), b);
                    }
                }


                return Avx2.mm256_cmpeq_epi8(Avx2.mm256_max_epu8(a, b), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpge_epu16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU16(b, 1 << 15))
                {
                    return Avx2.mm256_srai_epi16(a, 15);
                }
                if (constexpr.ALL_LT_EPU16(a, (ushort)short.MaxValue) && constexpr.ALL_LT_EPU16(b, (ushort)short.MaxValue))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return Avx2.mm256_cmpgt_epi16(a, mm256_dec_epi16(b));
                    }
                    if (constexpr.IS_CONST(a))
                    {
                        return Avx2.mm256_cmpgt_epi16(mm256_inc_epi16(a), b);
                    }
                }


                return Avx2.mm256_cmpeq_epi16(Avx2.mm256_max_epu16(a, b), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpge_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPU32(b, 1u << 31))
                {
                    return Avx2.mm256_srai_epi32(a, 31);
                }
                if (constexpr.ALL_LT_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LT_EPU32(b, (uint)int.MaxValue))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        return Avx2.mm256_cmpgt_epi32(a, mm256_dec_epi32(b));
                    }
                    if (constexpr.IS_CONST(a))
                    {
                        return Avx2.mm256_cmpgt_epi32(mm256_inc_epi32(a), b);
                    }
                }


                return Avx2.mm256_cmpeq_epi32(Avx2.mm256_max_epu32(a, b), a);
            }
            else throw new IllegalInstructionException();
        }
    }
}
