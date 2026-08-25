using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;

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
                v128 result;

                if (constexpr.ALL_EQ_EPU8(b, 1 << 7, elements))
                {
                    result = cmpgt_epi8(setzero_si128(), a);
                }
                else if (constexpr.ALL_LT_EPU8(a, (byte)sbyte.MaxValue, elements) && constexpr.ALL_LE_EPU8(b, (byte)sbyte.MaxValue, elements))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        result = cmpgt_epi8(a, dec_epi8(b));
                    }
                    else if (constexpr.IS_CONST(a))
                    {
                        result = cmpgt_epi8(inc_epi8(a), b);
                    }
                    else
                    {
                        result = cmpeq_epi8(max_epu8(a, b), a);
                    }
                }
                else
                {
                    result = cmpeq_epi8(max_epu8(a, b), a);
                }
                
                constexpr.ASSUME(result.Byte0  == (a.Byte0  >= b.Byte0  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte1  == (a.Byte1  >= b.Byte1  ? byte.MaxValue : 0));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.Byte2  == (a.Byte2  >= b.Byte2  ? byte.MaxValue : 0));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.Byte3  == (a.Byte3  >= b.Byte3  ? byte.MaxValue : 0));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.Byte4  == (a.Byte4  >= b.Byte4  ? byte.MaxValue : 0));
                            constexpr.ASSUME(result.Byte5  == (a.Byte5  >= b.Byte5  ? byte.MaxValue : 0));
                            constexpr.ASSUME(result.Byte6  == (a.Byte6  >= b.Byte6  ? byte.MaxValue : 0));
                            constexpr.ASSUME(result.Byte7  == (a.Byte7  >= b.Byte7  ? byte.MaxValue : 0));

                            if (elements > 8)
                            {
                                constexpr.ASSUME(result.Byte8  == (a.Byte8  >= b.Byte8  ? byte.MaxValue : 0));
                                constexpr.ASSUME(result.Byte9  == (a.Byte9  >= b.Byte9  ? byte.MaxValue : 0));
                                constexpr.ASSUME(result.Byte10 == (a.Byte10 >= b.Byte10 ? byte.MaxValue : 0));
                                constexpr.ASSUME(result.Byte11 == (a.Byte11 >= b.Byte11 ? byte.MaxValue : 0));
                                constexpr.ASSUME(result.Byte12 == (a.Byte12 >= b.Byte12 ? byte.MaxValue : 0));
                                constexpr.ASSUME(result.Byte13 == (a.Byte13 >= b.Byte13 ? byte.MaxValue : 0));
                                constexpr.ASSUME(result.Byte14 == (a.Byte14 >= b.Byte14 ? byte.MaxValue : 0));
                                constexpr.ASSUME(result.Byte15 == (a.Byte15 >= b.Byte15 ? byte.MaxValue : 0));
                            }
                        }
                    }
                }
                
                constexpr.ASSUME_IS_MASK_EPI8(result);

                return result;
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
                v128 result;

                if (constexpr.ALL_EQ_EPU16(b, 1 << 15, elements))
                {
                    result = srai_epi16(a, 15);
                }
                else if (constexpr.ALL_LT_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LT_EPU16(b, (ushort)short.MaxValue, elements))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        result = cmpgt_epi16(a, dec_epi16(b));
                    }
                    else if (constexpr.IS_CONST(a))
                    {
                        result = cmpgt_epi16(inc_epi16(a), b);
                    }
                    else
                    {
                        if (Sse4_1.IsSse41Supported)
                        {
                            result = cmpeq_epi16(max_epu16(a, b), a);
                        }
                        else
                        {
                            result = cmpeq_epi16(setzero_si128(), subs_epu16(b, a));
                        }
                    }
                }
                else
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        result = cmpeq_epi16(max_epu16(a, b), a);
                    }
                    else
                    {
                        result = cmpeq_epi16(setzero_si128(), subs_epu16(b, a));
                    }
                }
                
                constexpr.ASSUME(result.UShort0 == (a.UShort0 >= b.UShort0 ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort1 == (a.UShort1 >= b.UShort1 ? ushort.MaxValue : 0));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.UShort2 == (a.UShort2 >= b.UShort2 ? ushort.MaxValue : 0));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.UShort3 == (a.UShort3 >= b.UShort3 ? ushort.MaxValue : 0));

                        if (elements > 4)
                        {
                            constexpr.ASSUME(result.UShort4 == (a.UShort4 >= b.UShort4 ? ushort.MaxValue : 0));
                            constexpr.ASSUME(result.UShort5 == (a.UShort5 >= b.UShort5 ? ushort.MaxValue : 0));
                            constexpr.ASSUME(result.UShort6 == (a.UShort6 >= b.UShort6 ? ushort.MaxValue : 0));
                            constexpr.ASSUME(result.UShort7 == (a.UShort7 >= b.UShort7 ? ushort.MaxValue : 0));
                        }
                    }
                }
                
                constexpr.ASSUME_IS_MASK_EPI16(result);

                return result;
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
                v128 result;

                if (constexpr.ALL_EQ_EPU32(b, 1u << 31, elements))
                {
                    result = srai_epi32(a, 31);
                }
                else if (constexpr.ALL_LT_EPU32(a, (uint)int.MaxValue, elements) && constexpr.ALL_LT_EPU32(b, (uint)int.MaxValue, elements))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        result = cmpgt_epi32(a, dec_epi32(b));
                    }
                    else if (constexpr.IS_CONST(a))
                    {
                        result = cmpgt_epi32(inc_epi32(a), b);
                    }
                    else
                    {
                        result = cmpeq_epi32(max_epu32(a, b, elements), a);
                    }
                }
                else
                {
                    result = cmpeq_epi32(max_epu32(a, b, elements), a);
                }

                constexpr.ASSUME(result.UInt0 == (a.UInt0 >= b.UInt0 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt1 == (a.UInt1 >= b.UInt1 ? uint.MaxValue : 0));

                if (elements > 2)
                {
                    constexpr.ASSUME(result.UInt2 == (a.UInt2 >= b.UInt2 ? uint.MaxValue : 0));

                    if (elements > 3)
                    {
                        constexpr.ASSUME(result.UInt3 == (a.UInt3 >= b.UInt3 ? uint.MaxValue : 0));
                    }
                }
                
                constexpr.ASSUME_IS_MASK_EPI32(result);

                return result;
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
                v256 result;

                if (constexpr.ALL_EQ_EPU8(b, 1 << 7))
                {
                    result = Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), a);
                }
                else if (constexpr.ALL_LT_EPU8(a, (byte)sbyte.MaxValue) && constexpr.ALL_LT_EPU8(b, (byte)sbyte.MaxValue))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        result = Avx2.mm256_cmpgt_epi8(a, mm256_dec_epi8(b));
                    }
                    else if (constexpr.IS_CONST(a))
                    {
                        result = Avx2.mm256_cmpgt_epi8(mm256_inc_epi8(a), b);
                    }
                    else
                    {
                        result = Avx2.mm256_cmpeq_epi8(Avx2.mm256_max_epu8(a, b), a);
                    }
                }
                else
                {
                    result = Avx2.mm256_cmpeq_epi8(Avx2.mm256_max_epu8(a, b), a);
                }
                
                constexpr.ASSUME(result.Byte0  == (a.Byte0  >= b.Byte0  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte1  == (a.Byte1  >= b.Byte1  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte2  == (a.Byte2  >= b.Byte2  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte3  == (a.Byte3  >= b.Byte3  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte4  == (a.Byte4  >= b.Byte4  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte5  == (a.Byte5  >= b.Byte5  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte6  == (a.Byte6  >= b.Byte6  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte7  == (a.Byte7  >= b.Byte7  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte8  == (a.Byte8  >= b.Byte8  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte9  == (a.Byte9  >= b.Byte9  ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte10 == (a.Byte10 >= b.Byte10 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte11 == (a.Byte11 >= b.Byte11 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte12 == (a.Byte12 >= b.Byte12 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte13 == (a.Byte13 >= b.Byte13 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte14 == (a.Byte14 >= b.Byte14 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte15 == (a.Byte15 >= b.Byte15 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte16 == (a.Byte16 >= b.Byte16 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte17 == (a.Byte17 >= b.Byte17 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte18 == (a.Byte18 >= b.Byte18 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte19 == (a.Byte19 >= b.Byte19 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte20 == (a.Byte20 >= b.Byte20 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte21 == (a.Byte21 >= b.Byte21 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte22 == (a.Byte22 >= b.Byte22 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte23 == (a.Byte23 >= b.Byte23 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte24 == (a.Byte24 >= b.Byte24 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte25 == (a.Byte25 >= b.Byte25 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte26 == (a.Byte26 >= b.Byte26 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte27 == (a.Byte27 >= b.Byte27 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte28 == (a.Byte28 >= b.Byte28 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte29 == (a.Byte29 >= b.Byte29 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte30 == (a.Byte30 >= b.Byte30 ? byte.MaxValue : 0));
                constexpr.ASSUME(result.Byte31 == (a.Byte31 >= b.Byte31 ? byte.MaxValue : 0));
                
                constexpr.ASSUME_IS_MASK_EPI8(result);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpge_epu16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                if (constexpr.ALL_EQ_EPU16(b, 1 << 15))
                {
                    result = Avx2.mm256_srai_epi16(a, 15);
                }
                else if (constexpr.ALL_LT_EPU16(a, (ushort)short.MaxValue) && constexpr.ALL_LT_EPU16(b, (ushort)short.MaxValue))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        result = Avx2.mm256_cmpgt_epi16(a, mm256_dec_epi16(b));
                    }
                    else if (constexpr.IS_CONST(a))
                    {
                        result = Avx2.mm256_cmpgt_epi16(mm256_inc_epi16(a), b);
                    }
                    else
                    {
                        result = Avx2.mm256_cmpeq_epi16(Avx2.mm256_max_epu16(a, b), a);
                    }
                }
                else
                {
                    result = Avx2.mm256_cmpeq_epi16(Avx2.mm256_max_epu16(a, b), a);
                }
                
                constexpr.ASSUME(result.UShort0  == (a.UShort0  >= b.UShort0  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort1  == (a.UShort1  >= b.UShort1  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort2  == (a.UShort2  >= b.UShort2  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort3  == (a.UShort3  >= b.UShort3  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort4  == (a.UShort4  >= b.UShort4  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort5  == (a.UShort5  >= b.UShort5  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort6  == (a.UShort6  >= b.UShort6  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort7  == (a.UShort7  >= b.UShort7  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort8  == (a.UShort8  >= b.UShort8  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort9  == (a.UShort9  >= b.UShort9  ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort10 == (a.UShort10 >= b.UShort10 ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort11 == (a.UShort11 >= b.UShort11 ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort12 == (a.UShort12 >= b.UShort12 ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort13 == (a.UShort13 >= b.UShort13 ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort14 == (a.UShort14 >= b.UShort14 ? ushort.MaxValue : 0));
                constexpr.ASSUME(result.UShort15 == (a.UShort15 >= b.UShort15 ? ushort.MaxValue : 0));
                
                constexpr.ASSUME_IS_MASK_EPI16(result);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cmpge_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                if (constexpr.ALL_EQ_EPU32(b, 1u << 31))
                {
                    result = Avx2.mm256_srai_epi32(a, 31);
                }
                else if (constexpr.ALL_LT_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LT_EPU32(b, (uint)int.MaxValue))
                {
                    if (constexpr.IS_CONST(b))
                    {
                        result = Avx2.mm256_cmpgt_epi32(a, mm256_dec_epi32(b));
                    }
                    else if (constexpr.IS_CONST(a))
                    {
                        result = Avx2.mm256_cmpgt_epi32(mm256_inc_epi32(a), b);
                    }
                    else
                    {
                        result = Avx2.mm256_cmpeq_epi32(Avx2.mm256_max_epu32(a, b), a);
                    }
                }
                else
                {
                    result = Avx2.mm256_cmpeq_epi32(Avx2.mm256_max_epu32(a, b), a);
                }
                
                constexpr.ASSUME(result.UInt0 == (a.UInt0 >= b.UInt0 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt1 == (a.UInt1 >= b.UInt1 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt2 == (a.UInt2 >= b.UInt2 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt3 == (a.UInt3 >= b.UInt3 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt4 == (a.UInt4 >= b.UInt4 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt5 == (a.UInt5 >= b.UInt5 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt6 == (a.UInt6 >= b.UInt6 ? uint.MaxValue : 0));
                constexpr.ASSUME(result.UInt7 == (a.UInt7 >= b.UInt7 ? uint.MaxValue : 0));

                constexpr.ASSUME_IS_MASK_EPI32(result);

                return result;
            }
            else throw new IllegalInstructionException();
        }
    }
}
