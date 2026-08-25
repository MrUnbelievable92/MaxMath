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
            public static v128 t1cnt_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0, 8);
                        v128 SHUFFLE_MASK_HI = new v128(4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4, 8);

                        result = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                          shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                    }
                    else
                    {
                        result = tzcnt_epi8(not_si128(a));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.t1cnt(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.t1cnt(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.t1cnt(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.t1cnt(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.t1cnt(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.t1cnt(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.t1cnt(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.t1cnt(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.t1cnt(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.t1cnt(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.t1cnt(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.t1cnt(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.t1cnt(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.t1cnt(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.t1cnt(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.t1cnt(a.Byte15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1cnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0, 8,
                                                    0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0, 8);
                    v256 SHUFFLE_MASK_HI = new v256(4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4, 8,
                                                    4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4, 8);

                    v256 result = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                      Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.t1cnt(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.t1cnt(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.t1cnt(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.t1cnt(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.t1cnt(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.t1cnt(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.t1cnt(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.t1cnt(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.t1cnt(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.t1cnt(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.t1cnt(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.t1cnt(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.t1cnt(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.t1cnt(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.t1cnt(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.t1cnt(a.Byte15));
                    constexpr.ASSUME(result.Byte16 == math.t1cnt(a.Byte16));
                    constexpr.ASSUME(result.Byte17 == math.t1cnt(a.Byte17));
                    constexpr.ASSUME(result.Byte18 == math.t1cnt(a.Byte18));
                    constexpr.ASSUME(result.Byte19 == math.t1cnt(a.Byte19));
                    constexpr.ASSUME(result.Byte20 == math.t1cnt(a.Byte20));
                    constexpr.ASSUME(result.Byte21 == math.t1cnt(a.Byte21));
                    constexpr.ASSUME(result.Byte22 == math.t1cnt(a.Byte22));
                    constexpr.ASSUME(result.Byte23 == math.t1cnt(a.Byte23));
                    constexpr.ASSUME(result.Byte24 == math.t1cnt(a.Byte24));
                    constexpr.ASSUME(result.Byte25 == math.t1cnt(a.Byte25));
                    constexpr.ASSUME(result.Byte26 == math.t1cnt(a.Byte26));
                    constexpr.ASSUME(result.Byte27 == math.t1cnt(a.Byte27));
                    constexpr.ASSUME(result.Byte28 == math.t1cnt(a.Byte28));
                    constexpr.ASSUME(result.Byte29 == math.t1cnt(a.Byte29));
                    constexpr.ASSUME(result.Byte30 == math.t1cnt(a.Byte30));
                    constexpr.ASSUME(result.Byte31 == math.t1cnt(a.Byte31));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1cnt_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0, 16);
                        v128 SHUFFLE_MASK_HI = new v128(4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4, 16);

                        v128 t1cnt_bytes = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                                    shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                        result = min_epu8(t1cnt_bytes, srli_epi16(add_epi8(t1cnt_bytes, set1_epi8(8)), 8));
                    }
                    else
                    {
                        result = tzcnt_epi16(not_si128(a));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.t1cnt(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.t1cnt(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.t1cnt(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.t1cnt(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.t1cnt(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.t1cnt(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.t1cnt(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.t1cnt(a.UShort7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1cnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0, 16,
                                                    0, 1, 0, 2, 0, 1, 0, 3, 0, 1, 0, 2, 0, 1, 0, 16);
                    v256 SHUFFLE_MASK_HI = new v256(4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4, 16,
                                                    4, 5, 4, 6, 4, 5, 4, 7, 4, 5, 4, 6, 4, 5, 4, 16);

                    v256 t1cnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                           Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    v256 result = Avx2.mm256_min_epu8(t1cnt_bytes, Avx2.mm256_srli_epi16(Avx2.mm256_add_epi8(t1cnt_bytes, mm256_set1_epi8(8)), 8));

                    constexpr.ASSUME_LE_EPU8(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.t1cnt(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.t1cnt(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.t1cnt(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.t1cnt(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.t1cnt(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.t1cnt(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.t1cnt(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.t1cnt(a.UShort7));
                    constexpr.ASSUME(result.UShort8  == math.t1cnt(a.UShort8));
                    constexpr.ASSUME(result.UShort9  == math.t1cnt(a.UShort9));
                    constexpr.ASSUME(result.UShort10 == math.t1cnt(a.UShort10));
                    constexpr.ASSUME(result.UShort11 == math.t1cnt(a.UShort11));
                    constexpr.ASSUME(result.UShort12 == math.t1cnt(a.UShort12));
                    constexpr.ASSUME(result.UShort13 == math.t1cnt(a.UShort13));
                    constexpr.ASSUME(result.UShort14 == math.t1cnt(a.UShort14));
                    constexpr.ASSUME(result.UShort15 == math.t1cnt(a.UShort15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1cnt_epi32(v128 a, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = tzcnt_epi32(not_si128(a), elements);
                    
                    constexpr.ASSUME(result.UInt0  == math.t1cnt(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.t1cnt(a.UInt1));
                    if (elements > 2)
                    {
                        constexpr.ASSUME(result.UInt2  == math.t1cnt(a.UInt2));
                        constexpr.ASSUME(result.UInt3  == math.t1cnt(a.UInt3));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1cnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = mm256_tzcnt_epi32(mm256_not_si256(a));

                    constexpr.ASSUME(result.UInt0  == math.t1cnt(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.t1cnt(a.UInt1));
                    constexpr.ASSUME(result.UInt2  == math.t1cnt(a.UInt2));
                    constexpr.ASSUME(result.UInt3  == math.t1cnt(a.UInt3));
                    constexpr.ASSUME(result.UInt4  == math.t1cnt(a.UInt4));
                    constexpr.ASSUME(result.UInt5  == math.t1cnt(a.UInt5));
                    constexpr.ASSUME(result.UInt6  == math.t1cnt(a.UInt6));
                    constexpr.ASSUME(result.UInt7  == math.t1cnt(a.UInt7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 t1cnt_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = tzcnt_epi64(not_si128(a));

                    constexpr.ASSUME(result.ULong0  == math.t1cnt(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.t1cnt(a.ULong1));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_t1cnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = mm256_tzcnt_epi64(mm256_not_si256(a));

                    constexpr.ASSUME(result.ULong0  == math.t1cnt(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.t1cnt(a.ULong1));
                    constexpr.ASSUME(result.ULong2  == math.t1cnt(a.ULong2));
                    constexpr.ASSUME(result.ULong3  == math.t1cnt(a.ULong3));

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="UInt128"/>.    </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(UInt128 x)
        {
            if (x.lo64 == ulong.MaxValue)
            {
                return (byte)(64 + t1cnt(x.hi64));
            }
            else
            {
                return t1cnt(x.lo64);
            }
        }

        /// <summary>       Returns number of trailing ones in the binary representation of an <see cref="Int128"/>.    </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(Int128 x)
        {
            return t1cnt(x.value);
        }


        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="byte"/>.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(byte x)
        {
            return tzcnt((byte)~x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 t1cnt(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi8(x);
            }
            else
            {
                return new byte2(t1cnt(x.x), t1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 t1cnt(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi8(x);
            }
            else
            {
                return new byte3(t1cnt(x.x), t1cnt(x.y), t1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 t1cnt(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi8(x);
            }
            else
            {
                return new byte4(t1cnt(x.x), t1cnt(x.y), t1cnt(x.z), t1cnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 t1cnt(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi8(x);
            }
            else
            {
                return new byte8(t1cnt(x.x0), t1cnt(x.x1), t1cnt(x.x2), t1cnt(x.x3), t1cnt(x.x4), t1cnt(x.x5), t1cnt(x.x6), t1cnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 t1cnt(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi8(x);
            }
            else
            {
                return new byte16(t1cnt(x.x0), t1cnt(x.x1), t1cnt(x.x2), t1cnt(x.x3), t1cnt(x.x4), t1cnt(x.x5), t1cnt(x.x6), t1cnt(x.x7), t1cnt(x.x8), t1cnt(x.x9), t1cnt(x.x10), t1cnt(x.x11), t1cnt(x.x12), t1cnt(x.x13), t1cnt(x.x14), t1cnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 t1cnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1cnt_epi8(x);
            }
            else
            {
                return new byte32(t1cnt(x.v16_0), t1cnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of trailing ones in the binary representation of an <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(sbyte x)
        {
            return t1cnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of an <see cref="sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 t1cnt(sbyte2 x)
        {
            return (sbyte2)t1cnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of an <see cref="sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 t1cnt(sbyte3 x)
        {
            return (sbyte3)t1cnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of an <see cref="sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 t1cnt(sbyte4 x)
        {
            return (sbyte4)t1cnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of an <see cref="sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 t1cnt(sbyte8 x)
        {
            return (sbyte8)t1cnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of an <see cref="sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 t1cnt(sbyte16 x)
        {
            return (sbyte16)t1cnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of an <see cref="sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 t1cnt(sbyte32 x)
        {
            return (sbyte32)t1cnt((byte32)x);
        }


        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="ushort"/>.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(ushort x)
        {
            return tzcnt((ushort)~x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 t1cnt(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi16(x);
            }
            else
            {
                return new ushort2(t1cnt(x.x), t1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 t1cnt(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi16(x);
            }
            else
            {
                return new ushort3(t1cnt(x.x), t1cnt(x.y), t1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 t1cnt(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi16(x);
            }
            else
            {
                return new ushort4(t1cnt(x.x), t1cnt(x.y), t1cnt(x.z), t1cnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 t1cnt(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi16(x);
            }
            else
            {
                return new ushort8(t1cnt(x.x0), t1cnt(x.x1), t1cnt(x.x2), t1cnt(x.x3), t1cnt(x.x4), t1cnt(x.x5), t1cnt(x.x6), t1cnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 t1cnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1cnt_epi16(x);
            }
            else
            {
                return new ushort16(t1cnt(x.v8_0), t1cnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="short"/>.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(short x)
        {
            return t1cnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 t1cnt(short2 x)
        {
            return (short2)t1cnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 t1cnt(short3 x)
        {
            return (short3)t1cnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 t1cnt(short4 x)
        {
            return (short4)t1cnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 t1cnt(short8 x)
        {
            return (short8)t1cnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 t1cnt(short16 x)
        {
            return (short16)t1cnt((ushort16)x);
        }


        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="uint"/>.    </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(uint x)
        {
            return tzcnt(~x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="uint2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 t1cnt(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi32(x, 2);
            }
            else
            {
                return new int2(t1cnt(x.x), t1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="uint3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 t1cnt(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi32(x, 3);
            }
            else
            {
                return new int3(t1cnt(x.x), t1cnt(x.y), t1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="uint4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 t1cnt(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi32(x, 4);
            }
            else
            {
                return new int4(t1cnt(x.x), t1cnt(x.y), t1cnt(x.z), t1cnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 t1cnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1cnt_epi32(x);
            }
            else
            {
                return new int8(t1cnt(x.v4_0), t1cnt(x.v4_4));
            }
        }


        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="int"/>.    </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(int x)
        {
            return t1cnt((uint)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="int2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 t1cnt(int2 x)
        {
            return t1cnt((uint2)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="int3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 t1cnt(int3 x)
        {
            return t1cnt((uint3)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="int4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 t1cnt(int4 x)
        {
            return t1cnt((uint4)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of an <see cref="int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 t1cnt(int8 x)
        {
            return t1cnt((uint8)x);
        }


        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="ulong"/>.    </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(ulong x)
        {
            return tzcnt(~x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 t1cnt(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.t1cnt_epi64(x);
            }
            else
            {
                return new ulong2((uint)t1cnt(x.x), (uint)t1cnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 t1cnt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1cnt_epi64(x);
            }
            else
            {
                return new ulong3(t1cnt(x.xy), (uint)t1cnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 t1cnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_t1cnt_epi64(x);
            }
            else
            {
                return new ulong4(t1cnt(x.xy), t1cnt(x.zw));
            }
        }


        /// <summary>       Returns number of trailing ones in the binary representation of a <see cref="long"/>.    </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte t1cnt(long x)
        {
            return t1cnt((ulong)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 t1cnt(long2 x)
        {
            return (long2)t1cnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 t1cnt(long3 x)
        {
            return (long3)t1cnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of trailing ones in the binary representations of a <see cref="long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 t1cnt(long4 x)
        {
            return (long4)t1cnt((ulong4)x);
        }
    }
}