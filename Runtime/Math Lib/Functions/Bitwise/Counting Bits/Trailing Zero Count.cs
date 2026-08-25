using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
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
            public static v128 tzcnt_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                        v128 SHUFFLE_MASK_HI = new v128(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                        result = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                          shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                    }
                    else
                    {
                        v128 compareMask = blsi_epi8(a);

                        v128 first  = and_si128(set1_epi8(4), cmpeq_epi8(and_si128(compareMask, set1_epi8(0x0F)), setzero_si128()));
                        v128 second = and_si128(set1_epi8(2), cmpeq_epi8(and_si128(compareMask, set1_epi8(0x33)), setzero_si128()));
                        v128 third  = and_si128(set1_epi8(1), cmpeq_epi8(and_si128(compareMask, set1_epi8(0x55)), setzero_si128()));

                        v128 count = add_epi8(add_epi8(first, second), third);
                        result = sub_epi8(count, cmpeq_epi8(compareMask, setzero_si128()));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.tzcnt(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.tzcnt(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.tzcnt(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.tzcnt(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.tzcnt(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.tzcnt(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.tzcnt(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.tzcnt(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.tzcnt(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.tzcnt(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.tzcnt(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.tzcnt(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.tzcnt(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.tzcnt(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.tzcnt(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.tzcnt(a.Byte15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
                                                    8, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                    v256 SHUFFLE_MASK_HI = new v256(8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4,
                                                    8, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                    v256 result = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                      Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.tzcnt(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.tzcnt(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.tzcnt(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.tzcnt(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.tzcnt(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.tzcnt(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.tzcnt(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.tzcnt(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.tzcnt(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.tzcnt(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.tzcnt(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.tzcnt(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.tzcnt(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.tzcnt(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.tzcnt(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.tzcnt(a.Byte15));
                    constexpr.ASSUME(result.Byte16 == math.tzcnt(a.Byte16));
                    constexpr.ASSUME(result.Byte17 == math.tzcnt(a.Byte17));
                    constexpr.ASSUME(result.Byte18 == math.tzcnt(a.Byte18));
                    constexpr.ASSUME(result.Byte19 == math.tzcnt(a.Byte19));
                    constexpr.ASSUME(result.Byte20 == math.tzcnt(a.Byte20));
                    constexpr.ASSUME(result.Byte21 == math.tzcnt(a.Byte21));
                    constexpr.ASSUME(result.Byte22 == math.tzcnt(a.Byte22));
                    constexpr.ASSUME(result.Byte23 == math.tzcnt(a.Byte23));
                    constexpr.ASSUME(result.Byte24 == math.tzcnt(a.Byte24));
                    constexpr.ASSUME(result.Byte25 == math.tzcnt(a.Byte25));
                    constexpr.ASSUME(result.Byte26 == math.tzcnt(a.Byte26));
                    constexpr.ASSUME(result.Byte27 == math.tzcnt(a.Byte27));
                    constexpr.ASSUME(result.Byte28 == math.tzcnt(a.Byte28));
                    constexpr.ASSUME(result.Byte29 == math.tzcnt(a.Byte29));
                    constexpr.ASSUME(result.Byte30 == math.tzcnt(a.Byte30));
                    constexpr.ASSUME(result.Byte31 == math.tzcnt(a.Byte31));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzcnt_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                        v128 SHUFFLE_MASK_HI = new v128(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                        v128 tzcnt_bytes = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                                    shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                        result = min_epu8(tzcnt_bytes, srli_epi16(add_epi8(tzcnt_bytes, set1_epi8(8)), 8));
                    }
                    else
                    {
                        v128 compareMask = blsi_epi16(a);

                        v128 first  = and_si128(set1_epi16(8), cmpeq_epi16(and_si128(compareMask, set1_epi16(0x00FF)), setzero_si128()));
                        v128 second = and_si128(set1_epi16(4), cmpeq_epi16(and_si128(compareMask, set1_epi16(0x0F0F)), setzero_si128()));
                        v128 third  = and_si128(set1_epi16(2), cmpeq_epi16(and_si128(compareMask, set1_epi16(0x3333)), setzero_si128()));
                        v128 fourth = and_si128(set1_epi16(1), cmpeq_epi16(and_si128(compareMask, set1_epi16(0x5555)), setzero_si128()));

                        v128 count = add_epi16(add_epi16(first, second), add_epi16(third, fourth));
                        result = sub_epi16(count, cmpeq_epi16(compareMask, setzero_si128()));
                    }

                    constexpr.ASSUME_LE_EPU16(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.tzcnt(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.tzcnt(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.tzcnt(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.tzcnt(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.tzcnt(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.tzcnt(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.tzcnt(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.tzcnt(a.UShort7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0,
                                                    16, 0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0);
                    v256 SHUFFLE_MASK_HI = new v256(16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4,
                                                    16, 4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4);

                    v256 tzcnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                           Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    v256 result = Avx2.mm256_min_epu8(tzcnt_bytes, Avx2.mm256_srli_epi16(Avx2.mm256_add_epi8(tzcnt_bytes, mm256_set1_epi8(8)), 8));

                    constexpr.ASSUME_LE_EPU16(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.tzcnt(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.tzcnt(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.tzcnt(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.tzcnt(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.tzcnt(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.tzcnt(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.tzcnt(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.tzcnt(a.UShort7));
                    constexpr.ASSUME(result.UShort8  == math.tzcnt(a.UShort8));
                    constexpr.ASSUME(result.UShort9  == math.tzcnt(a.UShort9));
                    constexpr.ASSUME(result.UShort10 == math.tzcnt(a.UShort10));
                    constexpr.ASSUME(result.UShort11 == math.tzcnt(a.UShort11));
                    constexpr.ASSUME(result.UShort12 == math.tzcnt(a.UShort12));
                    constexpr.ASSUME(result.UShort13 == math.tzcnt(a.UShort13));
                    constexpr.ASSUME(result.UShort14 == math.tzcnt(a.UShort14));
                    constexpr.ASSUME(result.UShort15 == math.tzcnt(a.UShort15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzcnt_epi32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    if (elements > 2)
                    {
                        v128 loA = cvt2x2epu32_pd(blsi_epi32(a), out v128 hiA);
                        result = shuffle_ps(loA, hiA, Sse.SHUFFLE(3, 1, 3, 1));
                    }
                    else
                    {
                        result = cvtepu32_pd(blsi_epi32(a));
                        result = shuffle_epi32(result, Sse.SHUFFLE(0, 0, 3, 1));
                    }

                    result = srai_epi32(result, 52 - 32);
                    result = sub_epi16(result, set1_epi32(1023));
                    result = min_epu16(result, set1_epi32(32));

                    constexpr.ASSUME_LE_EPU32(result, 32);

                    constexpr.ASSUME(result.UInt0  == math.tzcnt(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.tzcnt(a.UInt1));
                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.UInt2  == math.tzcnt(a.UInt2));
                        constexpr.ASSUME(result.UInt3  == math.tzcnt(a.UInt3));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 loA = mm256_cvt2x2epu32_pd(mm256_blsi_epi32(a), out v256 hiA);
                    v256 result = Avx.mm256_shuffle_ps(loA, hiA, Sse.SHUFFLE(3, 1, 3, 1));
                    result = Avx2.mm256_srai_epi32(result, 52 - 32);
                    result = Avx2.mm256_sub_epi16(result, mm256_set1_epi32(1023));
                    result = Avx2.mm256_min_epu16(result, mm256_set1_epi32(32));

                    constexpr.ASSUME_LE_EPU32(result, 32);

                    constexpr.ASSUME(result.UInt0  == math.tzcnt(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.tzcnt(a.UInt1));
                    constexpr.ASSUME(result.UInt2  == math.tzcnt(a.UInt2));
                    constexpr.ASSUME(result.UInt3  == math.tzcnt(a.UInt3));
                    constexpr.ASSUME(result.UInt4  == math.tzcnt(a.UInt4));
                    constexpr.ASSUME(result.UInt5  == math.tzcnt(a.UInt5));
                    constexpr.ASSUME(result.UInt6  == math.tzcnt(a.UInt6));
                    constexpr.ASSUME(result.UInt7  == math.tzcnt(a.UInt7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 tzcnt_epi64(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    v128 result = popcnt_epi64(tzmsk_epi64(a));

                    constexpr.ASSUME_LE_EPU64(result, 64);

                    constexpr.ASSUME(result.ULong0  == math.tzcnt(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.tzcnt(a.ULong1));

                    return result;
                }
                if (BurstArchitecture.IsSIMDSupported)
                {
                    int lo = math.tzcnt(cvtsi128_si64x(a));
                    int hi = math.tzcnt(cvtsi128_si64x(bsrli_si128(a, sizeof(long))));

                    v128 result = unpacklo_epi64(cvtsi64x_si128((uint)lo), cvtsi64x_si128((uint)hi));

                    constexpr.ASSUME_LE_EPU64(result, 64);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_tzcnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = mm256_popcnt_epi64(mm256_tzmsk_epi64(a));

                    constexpr.ASSUME_LE_EPU64(result, 64);

                    constexpr.ASSUME(result.ULong0  == math.tzcnt(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.tzcnt(a.ULong1));
                    constexpr.ASSUME(result.ULong2  == math.tzcnt(a.ULong2));
                    constexpr.ASSUME(result.ULong3  == math.tzcnt(a.ULong3));

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="UInt128"/>.    </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(UInt128 x)
        {
            int tzcntLo = tzcnt(x.lo64);
            int tzcntHi = tzcnt(x.hi64);
            bool lo0 = x.lo64 == 0;
            int add = lo0 ? 64 : 0;

            return (byte)(add + (lo0 ? tzcntHi : tzcntLo));
        }

        /// <summary>       Returns number of trailing zeros in the binary representation of an <see cref="Int128"/>.    </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(Int128 x)
        {
            return tzcnt(x.value);
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="byte"/>.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(byte x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 8) adds another branch (for whatever reason)

            return (x == 0) ? (byte)8 : (byte)tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 tzcnt(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte2(tzcnt(x.x), tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 tzcnt(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 tzcnt(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 tzcnt(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 tzcnt(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi8(x);
            }
            else
            {
                return new byte16(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7), tzcnt(x.x8), tzcnt(x.x9), tzcnt(x.x10), tzcnt(x.x11), tzcnt(x.x12), tzcnt(x.x13), tzcnt(x.x14), tzcnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 tzcnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi8(x);
            }
            else
            {
                return new byte32(tzcnt(x.v16_0), tzcnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of an <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(sbyte x)
        {
            return tzcnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 tzcnt(sbyte2 x)
        {
            return (sbyte2)tzcnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 tzcnt(sbyte3 x)
        {
            return (sbyte3)tzcnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 tzcnt(sbyte4 x)
        {
            return (sbyte4)tzcnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 tzcnt(sbyte8 x)
        {
            return (sbyte8)tzcnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 tzcnt(sbyte16 x)
        {
            return (sbyte16)tzcnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 tzcnt(sbyte32 x)
        {
            return (sbyte32)tzcnt((byte32)x);
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="ushort"/>.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(ushort x)
        {
            // eliminates second test hardcoded by Unity; min(tzcnt, 16) adds another branch (for whatever reason)

            return (x == 0) ? (byte)16 : tzcnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 tzcnt(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort2(tzcnt(x.x), tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 tzcnt(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort3(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 tzcnt(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort4(tzcnt(x.x), tzcnt(x.y), tzcnt(x.z), tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 tzcnt(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi16(x);
            }
            else
            {
                return new ushort8(tzcnt(x.x0), tzcnt(x.x1), tzcnt(x.x2), tzcnt(x.x3), tzcnt(x.x4), tzcnt(x.x5), tzcnt(x.x6), tzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 tzcnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi16(x);
            }
            else
            {
                return new ushort16(tzcnt(x.v8_0), tzcnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="short"/>.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(short x)
        {
            return tzcnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 tzcnt(short2 x)
        {
            return (short2)tzcnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 tzcnt(short3 x)
        {
            return (short3)tzcnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 tzcnt(short4 x)
        {
            return (short4)tzcnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 tzcnt(short8 x)
        {
            return (short8)tzcnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 tzcnt(short16 x)
        {
            return (short16)tzcnt((ushort16)x);
        }

        
        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="uint"/>.    </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(uint x)
        {
            return (byte)Unity.Mathematics.math.tzcnt(x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tzcnt(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi32(x);
            }
            else
            {
                return new int2(Unity.Mathematics.math.tzcnt(x.x), Unity.Mathematics.math.tzcnt(x.y));
            }
        }
        
        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tzcnt(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi32(x);
            }
            else
            {
                return new int3(Unity.Mathematics.math.tzcnt(x.x), Unity.Mathematics.math.tzcnt(x.y), Unity.Mathematics.math.tzcnt(x.z));
            }
        }
        
        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tzcnt(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi32(x);
            }
            else
            {
                return new int4(Unity.Mathematics.math.tzcnt(x.x), Unity.Mathematics.math.tzcnt(x.y), Unity.Mathematics.math.tzcnt(x.z), Unity.Mathematics.math.tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzcnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi32(x);
            }
            else
            {
                return new int8(tzcnt(x.v4_0), tzcnt(x.v4_4));
            }
        }

        
        /// <summary>       Returns number of trailing zeros in the binary representation of an <see cref="int"/>.    </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(int x)
        {
            return (byte)Unity.Mathematics.math.tzcnt(x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 tzcnt(int2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi32(x);
            }
            else
            {
                return new int2(Unity.Mathematics.math.tzcnt(x.x), Unity.Mathematics.math.tzcnt(x.y));
            }
        }
        
        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 tzcnt(int3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi32(x);
            }
            else
            {
                return new int3(Unity.Mathematics.math.tzcnt(x.x), Unity.Mathematics.math.tzcnt(x.y), Unity.Mathematics.math.tzcnt(x.z));
            }
        }
        
        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 tzcnt(int4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi32(x);
            }
            else
            {
                return new int4(Unity.Mathematics.math.tzcnt(x.x), Unity.Mathematics.math.tzcnt(x.y), Unity.Mathematics.math.tzcnt(x.z), Unity.Mathematics.math.tzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of an <see cref="int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 tzcnt(int8 x)
        {
            return (int8)tzcnt((uint8)x);
        }

        
        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="ulong"/>.    </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(ulong x)
        {
            return (byte)Unity.Mathematics.math.tzcnt(x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 tzcnt(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.tzcnt_epi64(x);
            }
            else
            {
                return new ulong2((ulong)tzcnt(x.x), (ulong)tzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 tzcnt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi64(x);
            }
            else
            {
                return new ulong3(tzcnt(x.xy), (ulong)tzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 tzcnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_tzcnt_epi64(x);
            }
            else
            {
                return new ulong4(tzcnt(x.xy), tzcnt(x.zw));
            }
        }

        
        /// <summary>       Returns number of trailing zeros in the binary representation of a <see cref="long"/>.    </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte tzcnt(long x)
        {
            return (byte)Unity.Mathematics.math.tzcnt(x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 tzcnt(long2 x)
        {
            return (long2)tzcnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 tzcnt(long3 x)
        {
            return (long3)tzcnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of trailing zeros in the binary representations of a <see cref="long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 tzcnt(long4 x)
        {
            return (long4)tzcnt((ulong4)x);
        }
    }
}