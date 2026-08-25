using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 MASK = new v128(-1, 0, 0, -1, 0, -1, -1, 0, 0, -1, -1, 0, -1, 0, 0, -1);

                        result = shuffle_epi8(MASK, ternarylogic_si128(set1_epi8(0b0000_1111), a, srli_epi16(a, 4), TernaryOperation.Ox6O));
                    }
                    else
                    {
                        v128 __a = a;
                        __a = xor_si128(__a, srli_epi16(__a, 4));
                        __a = xor_si128(__a, srli_epi16(__a, 2));
                        __a = xor_si128(__a, srli_epi16(__a, 1));

                        result = cmpeq_epi8(and_si128(__a, set1_epi8(1)), setzero_si128());
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.Byte0  == (math.parityeven(a.Byte0)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte1  == (math.parityeven(a.Byte1)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte2  == (math.parityeven(a.Byte2)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte3  == (math.parityeven(a.Byte3)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte4  == (math.parityeven(a.Byte4)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte5  == (math.parityeven(a.Byte5)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte6  == (math.parityeven(a.Byte6)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte7  == (math.parityeven(a.Byte7)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte8  == (math.parityeven(a.Byte8)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte9  == (math.parityeven(a.Byte9)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte10 == (math.parityeven(a.Byte10) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte11 == (math.parityeven(a.Byte11) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte12 == (math.parityeven(a.Byte12) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte13 == (math.parityeven(a.Byte13) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte14 == (math.parityeven(a.Byte14) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte15 == (math.parityeven(a.Byte15) ? byte.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = new v256(-1, 0, 0, -1, 0, -1, -1, 0, 0, -1, -1, 0, -1, 0, 0, -1,
                                         -1, 0, 0, -1, 0, -1, -1, 0, 0, -1, -1, 0, -1, 0, 0, -1);

                    v256 result = Avx2.mm256_shuffle_epi8(MASK, mm256_ternarylogic_si256(mm256_set1_epi8(0b0000_1111), a, mm256_srli_epi16(a, 4), TernaryOperation.Ox6O));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.Byte0  == (math.parityeven(a.Byte0)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte1  == (math.parityeven(a.Byte1)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte2  == (math.parityeven(a.Byte2)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte3  == (math.parityeven(a.Byte3)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte4  == (math.parityeven(a.Byte4)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte5  == (math.parityeven(a.Byte5)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte6  == (math.parityeven(a.Byte6)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte7  == (math.parityeven(a.Byte7)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte8  == (math.parityeven(a.Byte8)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte9  == (math.parityeven(a.Byte9)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte10 == (math.parityeven(a.Byte10) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte11 == (math.parityeven(a.Byte11) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte12 == (math.parityeven(a.Byte12) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte13 == (math.parityeven(a.Byte13) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte14 == (math.parityeven(a.Byte14) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte15 == (math.parityeven(a.Byte15) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte16 == (math.parityeven(a.Byte16) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte17 == (math.parityeven(a.Byte17) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte18 == (math.parityeven(a.Byte18) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte19 == (math.parityeven(a.Byte19) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte20 == (math.parityeven(a.Byte20) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte21 == (math.parityeven(a.Byte21) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte22 == (math.parityeven(a.Byte22) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte23 == (math.parityeven(a.Byte23) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte24 == (math.parityeven(a.Byte24) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte25 == (math.parityeven(a.Byte25) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte26 == (math.parityeven(a.Byte26) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte27 == (math.parityeven(a.Byte27) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte28 == (math.parityeven(a.Byte28) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte29 == (math.parityeven(a.Byte29) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte30 == (math.parityeven(a.Byte30) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte31 == (math.parityeven(a.Byte31) ? byte.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 __a = a;

                    __a = xor_si128(__a, srli_epi16(__a, 8));
                    __a = bpe_epi8(__a);

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        result = shuffle_epi8(__a, new v128(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                    }
                    else
                    {
                        result = neg_epi16(and_si128(__a, set1_epi16(1)));
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UShort0  == (math.parityeven(a.UShort0) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort1  == (math.parityeven(a.UShort1) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort2  == (math.parityeven(a.UShort2) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort3  == (math.parityeven(a.UShort3) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort4  == (math.parityeven(a.UShort4) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort5  == (math.parityeven(a.UShort5) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort6  == (math.parityeven(a.UShort6) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort7  == (math.parityeven(a.UShort7) ? ushort.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __a = a;

                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi16(__a, 8));
                    __a = mm256_bpe_epi8(__a);

                    v256 result = Avx2.mm256_shuffle_epi8(__a, new v256(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14,
                                                                        0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UShort0  == (math.parityeven(a.UShort0)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort1  == (math.parityeven(a.UShort1)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort2  == (math.parityeven(a.UShort2)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort3  == (math.parityeven(a.UShort3)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort4  == (math.parityeven(a.UShort4)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort5  == (math.parityeven(a.UShort5)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort6  == (math.parityeven(a.UShort6)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort7  == (math.parityeven(a.UShort7)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort8  == (math.parityeven(a.UShort8)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort9  == (math.parityeven(a.UShort9)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort10 == (math.parityeven(a.UShort10) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort11 == (math.parityeven(a.UShort11) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort12 == (math.parityeven(a.UShort12) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort13 == (math.parityeven(a.UShort13) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort14 == (math.parityeven(a.UShort14) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort15 == (math.parityeven(a.UShort15) ? ushort.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 __a = a;

                    __a = xor_si128(__a, srli_epi32(__a, 16));
                    __a = xor_si128(__a, srli_epi16(__a, 8));
                    __a = bpe_epi8(__a);

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        result = shuffle_epi8(__a, new v128(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                    }
                    else
                    {
                        result = neg_epi32(and_si128(__a, set1_epi32(1)));
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UInt0  == (math.parityeven(a.UInt0) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt1  == (math.parityeven(a.UInt1) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt2  == (math.parityeven(a.UInt2) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt3  == (math.parityeven(a.UInt3) ? uint.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __a = a;

                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi32(__a, 16));
                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi16(__a, 8));
                    __a = mm256_bpe_epi8(__a);

                    v256 result = Avx2.mm256_shuffle_epi8(__a, new v256(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12,
                                                                        0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UInt0  == (math.parityeven(a.UInt0) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt1  == (math.parityeven(a.UInt1) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt2  == (math.parityeven(a.UInt2) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt3  == (math.parityeven(a.UInt3) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt4  == (math.parityeven(a.UInt4) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt5  == (math.parityeven(a.UInt5) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt6  == (math.parityeven(a.UInt6) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt7  == (math.parityeven(a.UInt7) ? uint.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpe_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 __a = a;

                    __a = xor_si128(__a, srli_epi64(__a, 32));
                    __a = xor_si128(__a, srli_epi32(__a, 16));
                    __a = xor_si128(__a, srli_epi16(__a, 8));
                    __a = bpe_epi8(__a);

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        result = shuffle_epi8(__a, new v128(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                    }
                    else
                    {
                        result = neg_epi64(and_si128(__a, set1_epi64x(1)));
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.ULong0  == (math.parityeven(a.ULong0) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong1  == (math.parityeven(a.ULong1) ? ulong.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpe_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __a = a;

                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi64(__a, 32));
                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi32(__a, 16));
                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi16(__a, 8));
                    __a = mm256_bpe_epi8(__a);

                    v256 result = Avx2.mm256_shuffle_epi8(__a, new v256(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8,
                                                                        0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.ULong0 == (math.parityeven(a.ULong0) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong1 == (math.parityeven(a.ULong1) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong2 == (math.parityeven(a.ULong2) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong3 == (math.parityeven(a.ULong3) ? ulong.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 MASK = new v128(0, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, -1, 0, -1, -1, 0);

                        result = shuffle_epi8(MASK, ternarylogic_si128(set1_epi8(0b0000_1111), a, srli_epi16(a, 4), TernaryOperation.Ox6O));
                    }
                    else
                    {
                        v128 __a = a;
                        __a = xor_si128(__a, srli_epi16(__a, 4));
                        __a = xor_si128(__a, srli_epi16(__a, 2));
                        __a = xor_si128(__a, srli_epi16(__a, 1));

                        result = cmpeq_epi8(and_si128(__a, set1_epi8(1)), set1_epi8(1));
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.Byte0  == (math.parityodd(a.Byte0)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte1  == (math.parityodd(a.Byte1)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte2  == (math.parityodd(a.Byte2)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte3  == (math.parityodd(a.Byte3)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte4  == (math.parityodd(a.Byte4)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte5  == (math.parityodd(a.Byte5)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte6  == (math.parityodd(a.Byte6)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte7  == (math.parityodd(a.Byte7)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte8  == (math.parityodd(a.Byte8)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte9  == (math.parityodd(a.Byte9)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte10 == (math.parityodd(a.Byte10) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte11 == (math.parityodd(a.Byte11) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte12 == (math.parityodd(a.Byte12) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte13 == (math.parityodd(a.Byte13) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte14 == (math.parityodd(a.Byte14) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte15 == (math.parityodd(a.Byte15) ? byte.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MASK = new v256(0, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, -1, 0, -1, -1, 0,
                                         0, -1, -1, 0, -1, 0, 0, -1, -1, 0, 0, -1, 0, -1, -1, 0);

                    v256 result = Avx2.mm256_shuffle_epi8(MASK, mm256_ternarylogic_si256(mm256_set1_epi8(0b0000_1111), a, mm256_srli_epi16(a, 4), TernaryOperation.Ox6O));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.Byte0  == (math.parityodd(a.Byte0)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte1  == (math.parityodd(a.Byte1)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte2  == (math.parityodd(a.Byte2)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte3  == (math.parityodd(a.Byte3)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte4  == (math.parityodd(a.Byte4)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte5  == (math.parityodd(a.Byte5)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte6  == (math.parityodd(a.Byte6)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte7  == (math.parityodd(a.Byte7)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte8  == (math.parityodd(a.Byte8)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte9  == (math.parityodd(a.Byte9)  ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte10 == (math.parityodd(a.Byte10) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte11 == (math.parityodd(a.Byte11) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte12 == (math.parityodd(a.Byte12) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte13 == (math.parityodd(a.Byte13) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte14 == (math.parityodd(a.Byte14) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte15 == (math.parityodd(a.Byte15) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte16 == (math.parityodd(a.Byte16) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte17 == (math.parityodd(a.Byte17) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte18 == (math.parityodd(a.Byte18) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte19 == (math.parityodd(a.Byte19) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte20 == (math.parityodd(a.Byte20) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte21 == (math.parityodd(a.Byte21) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte22 == (math.parityodd(a.Byte22) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte23 == (math.parityodd(a.Byte23) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte24 == (math.parityodd(a.Byte24) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte25 == (math.parityodd(a.Byte25) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte26 == (math.parityodd(a.Byte26) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte27 == (math.parityodd(a.Byte27) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte28 == (math.parityodd(a.Byte28) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte29 == (math.parityodd(a.Byte29) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte30 == (math.parityodd(a.Byte30) ? byte.MaxValue : 0));
                    constexpr.ASSUME(result.Byte31 == (math.parityodd(a.Byte31) ? byte.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 __a = a;

                    __a = xor_si128(__a, srli_epi16(__a, 8));
                    __a = bpo_epi8(__a);

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        result = shuffle_epi8(__a, new v128(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                    }
                    else
                    {
                        result = neg_epi16(and_si128(__a, set1_epi16(1)));
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UShort0  == (math.parityodd(a.UShort0) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort1  == (math.parityodd(a.UShort1) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort2  == (math.parityodd(a.UShort2) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort3  == (math.parityodd(a.UShort3) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort4  == (math.parityodd(a.UShort4) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort5  == (math.parityodd(a.UShort5) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort6  == (math.parityodd(a.UShort6) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort7  == (math.parityodd(a.UShort7) ? ushort.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __a = a;

                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi16(__a, 8));
                    __a = mm256_bpo_epi8(__a);

                    v256 result = Avx2.mm256_shuffle_epi8(__a, new v256(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14,
                                                                        0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UShort0  == (math.parityodd(a.UShort0)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort1  == (math.parityodd(a.UShort1)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort2  == (math.parityodd(a.UShort2)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort3  == (math.parityodd(a.UShort3)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort4  == (math.parityodd(a.UShort4)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort5  == (math.parityodd(a.UShort5)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort6  == (math.parityodd(a.UShort6)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort7  == (math.parityodd(a.UShort7)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort8  == (math.parityodd(a.UShort8)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort9  == (math.parityodd(a.UShort9)  ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort10 == (math.parityodd(a.UShort10) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort11 == (math.parityodd(a.UShort11) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort12 == (math.parityodd(a.UShort12) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort13 == (math.parityodd(a.UShort13) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort14 == (math.parityodd(a.UShort14) ? ushort.MaxValue : 0));
                    constexpr.ASSUME(result.UShort15 == (math.parityodd(a.UShort15) ? ushort.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 __a = a;

                    __a = xor_si128(__a, srli_epi32(__a, 16));
                    __a = xor_si128(__a, srli_epi16(__a, 8));
                    __a = bpo_epi8(__a);

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        result = shuffle_epi8(__a, new v128(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                    }
                    else
                    {
                        result = neg_epi32(and_si128(__a, set1_epi32(1)));
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UInt0  == (math.parityodd(a.UInt0) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt1  == (math.parityodd(a.UInt1) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt2  == (math.parityodd(a.UInt2) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt3  == (math.parityodd(a.UInt3) ? uint.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __a = a;

                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi32(__a, 16));
                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi16(__a, 8));
                    __a = mm256_bpo_epi8(__a);

                    v256 result = Avx2.mm256_shuffle_epi8(__a, new v256(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12,
                                                                        0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.UInt0  == (math.parityodd(a.UInt0) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt1  == (math.parityodd(a.UInt1) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt2  == (math.parityodd(a.UInt2) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt3  == (math.parityodd(a.UInt3) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt4  == (math.parityodd(a.UInt4) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt5  == (math.parityodd(a.UInt5) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt6  == (math.parityodd(a.UInt6) ? uint.MaxValue : 0));
                    constexpr.ASSUME(result.UInt7  == (math.parityodd(a.UInt7) ? uint.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bpo_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    v128 __a = a;

                    __a = xor_si128(__a, srli_epi64(__a, 32));
                    __a = xor_si128(__a, srli_epi32(__a, 16));
                    __a = xor_si128(__a, srli_epi16(__a, 8));
                    __a = bpo_epi8(__a);

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        result = shuffle_epi8(__a, new v128(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                    }
                    else
                    {
                        result = neg_epi64(and_si128(__a, set1_epi64x(1)));
                    }

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.ULong0 == (math.parityodd(a.ULong0) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong1 == (math.parityodd(a.ULong1) ? ulong.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bpo_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __a = a;

                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi64(__a, 32));
                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi32(__a, 16));
                    __a = Avx2.mm256_xor_si256(__a, mm256_srli_epi16(__a, 8));
                    __a = mm256_bpo_epi8(__a);

                    v256 result = Avx2.mm256_shuffle_epi8(__a, new v256(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8,
                                                                        0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));

                    constexpr.ASSUME_IS_MASK_EPI8(result);

                    constexpr.ASSUME(result.ULong0 == (math.parityodd(a.ULong0) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong1 == (math.parityodd(a.ULong1) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong2 == (math.parityodd(a.ULong2) ? ulong.MaxValue : 0));
                    constexpr.ASSUME(result.ULong3 == (math.parityodd(a.ULong3) ? ulong.MaxValue : 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return (countbits(x) & 1) != 0;
            }
            else
            {
                x ^= (byte)(x >> 4);
                x ^= (byte)(x >> 2);
                x ^= (byte)(x >> 1);

                return (x & 1) != 0;
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 parityodd(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi8(x);
            }
            else
            {
                return new mask8x2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 parityodd(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi8(x);
            }
            else
            {
                return new mask8x3(parityodd(x.x), parityodd(x.y), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 parityodd(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi8(x);
            }
            else
            {
                return new mask8x4(parityodd(x.x), parityodd(x.y), parityodd(x.z), parityodd(x.w));
            }
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 parityodd(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi8(x);
            }
            else
            {
                return new mask8x8(parityodd(x.x0), parityodd(x.x1), parityodd(x.x2), parityodd(x.x3), parityodd(x.x4), parityodd(x.x5), parityodd(x.x6), parityodd(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 parityodd(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi8(x);
            }
            else
            {
                return new mask8x16(parityodd(x.x0), parityodd(x.x1), parityodd(x.x2), parityodd(x.x3), parityodd(x.x4), parityodd(x.x5), parityodd(x.x6), parityodd(x.x7), parityodd(x.x8), parityodd(x.x9), parityodd(x.x10), parityodd(x.x11), parityodd(x.x12), parityodd(x.x13), parityodd(x.x14), parityodd(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 parityodd(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpo_epi8(x);
            }
            else
            {
                return new mask8x32(parityodd(x.v16_0), parityodd(x.v16_16));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(ushort x)
        {
            x ^= (ushort)(x >> 8);

            return parityodd((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 parityodd(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi16(x);
            }
            else
            {
                return new mask16x2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 parityodd(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi16(x);
            }
            else
            {
                return new mask16x3(parityodd(x.x), parityodd(x.y), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 parityodd(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi16(x);
            }
            else
            {
                return new mask16x4(parityodd(x.x), parityodd(x.y), parityodd(x.z), parityodd(x.w));
            }
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 parityodd(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi16(x);
            }
            else
            {
                return new mask16x8(parityodd(x.x0), parityodd(x.x1), parityodd(x.x2), parityodd(x.x3), parityodd(x.x4), parityodd(x.x5), parityodd(x.x6), parityodd(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 parityodd(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpo_epi16(x);
            }
            else
            {
                return new mask16x16(parityodd(x.v8_0), parityodd(x.v8_8));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(uint x)
        {
            x ^= x >> 16;

            return parityodd((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 parityodd(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi32(x);
            }
            else
            {
                return new mask32x2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 parityodd(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi32(x);
            }
            else
            {
                return new mask32x3(parityodd(x.x), parityodd(x.y), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 parityodd(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi32(x);
            }
            else
            {
                return new mask32x4(parityodd(x.x), parityodd(x.y), parityodd(x.z), parityodd(x.w));
            }
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 parityodd(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpo_epi32(x);
            }
            else
            {
                return new mask32x8(parityodd(x.v4_0), parityodd(x.v4_4));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(ulong x)
        {
            if (BurstArchitecture.IsPopcntSupported)
            {
                return (countbits(x) & 1) == 1;
            }
            else
            {
                x ^= x >> 32;

                return parityodd((uint)x);
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 parityodd(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpo_epi64(x);
            }
            else
            {
                return new mask64x2(parityodd(x.x), parityodd(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 parityodd(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpo_epi64(x);
            }
            else
            {
                return new mask64x3(parityodd(x.xy), parityodd(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 parityodd(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpo_epi64(x);
            }
            else
            {
                return new mask64x4(parityodd(x.xy), parityodd(x.zw));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(UInt128 x)
        {
            return parityodd(x.lo64 ^ x.hi64);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(sbyte x)
        {
            return parityodd((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 parityodd(sbyte2 x)
        {
            return parityodd((byte2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 parityodd(sbyte3 x)
        {
            return parityodd((byte3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 parityodd(sbyte4 x)
        {
            return parityodd((byte4)x);
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 parityodd(sbyte8 x)
        {
            return parityodd((byte8)x);
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 parityodd(sbyte16 x)
        {
            return parityodd((byte16)x);
        }

        /// <summary>       Returns a <see cref="bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 parityodd(sbyte32 x)
        {
            return parityodd((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(short x)
        {
            return parityodd((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 parityodd(short2 x)
        {
            return parityodd((ushort2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 parityodd(short3 x)
        {
            return parityodd((ushort3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 parityodd(short4 x)
        {
            return parityodd((ushort4)x);
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 parityodd(short8 x)
        {
            return parityodd((ushort8)x);
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 parityodd(short16 x)
        {
            return parityodd((ushort16)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(int x)
        {
            return parityodd((uint)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 parityodd(int2 x)
        {
            return parityodd((uint2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 parityodd(int3 x)
        {
            return parityodd((uint3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 parityodd(int4 x)
        {
            return parityodd((uint4)x);
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 parityodd(int8 x)
        {
            return parityodd((uint8)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(long x)
        {
            return parityodd((ulong)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 parityodd(long2 x)
        {
            return parityodd((ulong2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 parityodd(long3 x)
        {
            return parityodd((ulong3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 parityodd(long4 x)
        {
            return parityodd((ulong4)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is odd.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityodd(Int128 x)
        {
            return parityodd((UInt128)x);
        }
        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(byte x)
        {
            if (Sse2.IsSse2Supported)
            {
                return (countbits(x) & 1) == 0;
            }
            else
            {
                x ^= (byte)(x >> 4);
                x ^= (byte)(x >> 2);
                x ^= (byte)(x >> 1);

                return (x & 1) == 0;
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 parityeven(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi8(x);
            }
            else
            {
                return new mask8x2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 parityeven(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi8(x);
            }
            else
            {
                return new mask8x3(parityeven(x.x), parityeven(x.y), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 parityeven(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi8(x);
            }
            else
            {
                return new mask8x4(parityeven(x.x), parityeven(x.y), parityeven(x.z), parityeven(x.w));
            }
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 parityeven(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi8(x);
            }
            else
            {
                return new mask8x8(parityeven(x.x0), parityeven(x.x1), parityeven(x.x2), parityeven(x.x3), parityeven(x.x4), parityeven(x.x5), parityeven(x.x6), parityeven(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 parityeven(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi8(x);
            }
            else
            {
                return new mask8x16(parityeven(x.x0), parityeven(x.x1), parityeven(x.x2), parityeven(x.x3), parityeven(x.x4), parityeven(x.x5), parityeven(x.x6), parityeven(x.x7), parityeven(x.x8), parityeven(x.x9), parityeven(x.x10), parityeven(x.x11), parityeven(x.x12), parityeven(x.x13), parityeven(x.x14), parityeven(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 parityeven(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpe_epi8(x);
            }
            else
            {
                return new mask8x32(parityeven(x.v16_0), parityeven(x.v16_16));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(ushort x)
        {
            x ^= (ushort)(x >> 8);

            return parityeven((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 parityeven(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi16(x);
            }
            else
            {
                return new mask16x2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 parityeven(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi16(x);
            }
            else
            {
                return new mask16x3(parityeven(x.x), parityeven(x.y), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 parityeven(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi16(x);
            }
            else
            {
                return new mask16x4(parityeven(x.x), parityeven(x.y), parityeven(x.z), parityeven(x.w));
            }
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 parityeven(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi16(x);
            }
            else
            {
                return new mask16x8(parityeven(x.x0), parityeven(x.x1), parityeven(x.x2), parityeven(x.x3), parityeven(x.x4), parityeven(x.x5), parityeven(x.x6), parityeven(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 parityeven(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpe_epi16(x);
            }
            else
            {
                return new mask16x16(parityeven(x.v8_0), parityeven(x.v8_8));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(uint x)
        {
            x ^= x >> 16;

            return parityeven((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 parityeven(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi32(x);
            }
            else
            {
                return new mask32x2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 parityeven(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi32(x);
            }
            else
            {
                return new mask32x3(parityeven(x.x), parityeven(x.y), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 parityeven(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi32(x);
            }
            else
            {
                return new mask32x4(parityeven(x.x), parityeven(x.y), parityeven(x.z), parityeven(x.w));
            }
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 parityeven(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpe_epi32(x);
            }
            else
            {
                return new mask32x8(parityeven(x.v4_0), parityeven(x.v4_4));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(ulong x)
        {
            if (BurstArchitecture.IsPopcntSupported)
            {
                return (countbits(x) & 1) == 0;
            }
            else
            {
                x ^= x >> 32;

                return parityeven((uint)x);
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 parityeven(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bpe_epi64(x);
            }
            else
            {
                return new mask64x2(parityeven(x.x), parityeven(x.y));
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 parityeven(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpe_epi64(x);
            }
            else
            {
                return new mask64x3(parityeven(x.xy), parityeven(x.z));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 parityeven(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bpe_epi64(x);
            }
            else
            {
                return new mask64x4(parityeven(x.xy), parityeven(x.zw));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(UInt128 x)
        {
            return parityeven(x.lo64 ^ x.hi64);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(sbyte x)
        {
            return parityeven((byte)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 parityeven(sbyte2 x)
        {
            return parityeven((byte2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 parityeven(sbyte3 x)
        {
            return parityeven((byte3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 parityeven(sbyte4 x)
        {
            return parityeven((byte4)x);
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 parityeven(sbyte8 x)
        {
            return parityeven((byte8)x);
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 parityeven(sbyte16 x)
        {
            return parityeven((byte16)x);
        }

        /// <summary>       Returns a <see cref="bool32"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 parityeven(sbyte32 x)
        {
            return parityeven((byte32)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(short x)
        {
            return parityeven((ushort)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 parityeven(short2 x)
        {
            return parityeven((ushort2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 parityeven(short3 x)
        {
            return parityeven((ushort3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 parityeven(short4 x)
        {
            return parityeven((ushort4)x);
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 parityeven(short8 x)
        {
            return parityeven((ushort8)x);
        }

        /// <summary>       Returns a <see cref="bool16"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 parityeven(short16 x)
        {
            return parityeven((ushort16)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(int x)
        {
            return parityeven((uint)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 parityeven(int2 x)
        {
            return parityeven((uint2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 parityeven(int3 x)
        {
            return parityeven((uint3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 parityeven(int4 x)
        {
            return parityeven((uint4)x);
        }

        /// <summary>       Returns a <see cref="bool8"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 parityeven(int8 x)
        {
            return parityeven((uint8)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(long x)
        {
            return parityeven((ulong)x);
        }

        /// <summary>       Returns a <see cref="bool2"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 parityeven(long2 x)
        {
            return parityeven((ulong2)x);
        }

        /// <summary>       Returns a <see cref="bool3"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 parityeven(long3 x)
        {
            return parityeven((ulong3)x);
        }

        /// <summary>       Returns a <see cref="bool4"/> with each component set to <see langword="true"/> if the number of set 1-bits in the corresponding component in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 parityeven(long4 x)
        {
            return parityeven((ulong4)x);
        }


        /// <summary>       Returns <see langword="true"/> if the number of set 1-bits in <paramref name="x"/> is even.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool parityeven(Int128 x)
        {
            return parityeven((UInt128)x);
        }
    }
}
