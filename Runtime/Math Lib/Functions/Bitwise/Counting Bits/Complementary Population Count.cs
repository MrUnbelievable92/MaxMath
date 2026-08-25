using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

// Wojciech Mula's algorithm
namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 unpopcnt_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 LOOKUP = new v128(4, 3, 3, 2, 3, 2, 2, 1, 3, 2, 2, 1, 2, 1, 1, 0);

                        v128 countLo = shuffle_epi8(LOOKUP, and_si128(NIBBLE_MASK, a));
                        v128 countHi = shuffle_epi8(LOOKUP, and_si128(NIBBLE_MASK, srli_epi16(a, 4)));

                        result = add_epi8(countLo, countHi);
                    }
                    else
                    {
                        v128 __a = sub_epi8(not_si128(a), andnot_si128(srli_epi16(a, 1), set1_epi8(0x55)));
                        __a = add_epi8(and_si128(__a, set1_epi8(0x33)), and_si128(srli_epi16(__a, 2), set1_epi8(0x33)));
                        result = and_si128(NIBBLE_MASK, add_epi8(__a, srli_epi16(__a, 4)));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.countzerobits(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.countzerobits(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.countzerobits(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.countzerobits(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.countzerobits(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.countzerobits(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.countzerobits(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.countzerobits(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.countzerobits(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.countzerobits(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.countzerobits(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.countzerobits(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.countzerobits(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.countzerobits(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.countzerobits(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.countzerobits(a.Byte15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_unpopcnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 LOOKUP = new v256(4, 3, 3, 2, 3, 2, 2, 1, 3, 2, 2, 1, 2, 1, 1, 0,
                                           4, 3, 3, 2, 3, 2, 2, 1, 3, 2, 2, 1, 2, 1, 1, 0);

                    v256 countLo = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a));
                    v256 countHi = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4)));

                    v256 result = Avx2.mm256_add_epi8(countLo, countHi);

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.countzerobits(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.countzerobits(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.countzerobits(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.countzerobits(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.countzerobits(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.countzerobits(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.countzerobits(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.countzerobits(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.countzerobits(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.countzerobits(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.countzerobits(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.countzerobits(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.countzerobits(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.countzerobits(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.countzerobits(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.countzerobits(a.Byte15));
                    constexpr.ASSUME(result.Byte16 == math.countzerobits(a.Byte16));
                    constexpr.ASSUME(result.Byte17 == math.countzerobits(a.Byte17));
                    constexpr.ASSUME(result.Byte18 == math.countzerobits(a.Byte18));
                    constexpr.ASSUME(result.Byte19 == math.countzerobits(a.Byte19));
                    constexpr.ASSUME(result.Byte20 == math.countzerobits(a.Byte20));
                    constexpr.ASSUME(result.Byte21 == math.countzerobits(a.Byte21));
                    constexpr.ASSUME(result.Byte22 == math.countzerobits(a.Byte22));
                    constexpr.ASSUME(result.Byte23 == math.countzerobits(a.Byte23));
                    constexpr.ASSUME(result.Byte24 == math.countzerobits(a.Byte24));
                    constexpr.ASSUME(result.Byte25 == math.countzerobits(a.Byte25));
                    constexpr.ASSUME(result.Byte26 == math.countzerobits(a.Byte26));
                    constexpr.ASSUME(result.Byte27 == math.countzerobits(a.Byte27));
                    constexpr.ASSUME(result.Byte28 == math.countzerobits(a.Byte28));
                    constexpr.ASSUME(result.Byte29 == math.countzerobits(a.Byte29));
                    constexpr.ASSUME(result.Byte30 == math.countzerobits(a.Byte30));
                    constexpr.ASSUME(result.Byte31 == math.countzerobits(a.Byte31));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 unpopcnt_epi16(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return popcnt_epi16(not_si128(a));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 byteBits = unpopcnt_epi8(a);

                    v128 lo = and_si128(byteBits, set1_epi16(0x00FF));
                    v128 hi = srli_epi16(byteBits, 8);

                    v128 result = add_epi16(lo, hi);

                    constexpr.ASSUME_LE_EPU16(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.countzerobits(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.countzerobits(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.countzerobits(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.countzerobits(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.countzerobits(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.countzerobits(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.countzerobits(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.countzerobits(a.UShort7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_unpopcnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 byteBits = mm256_unpopcnt_epi8(a);
                    v256 lo = Avx2.mm256_and_si256(byteBits, mm256_set1_epi16(0x00FF));
                    v256 hi = Avx2.mm256_srli_epi16(byteBits, 8);

                    v256 result = Avx2.mm256_add_epi16(lo, hi);

                    constexpr.ASSUME_LE_EPU16(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.countzerobits(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.countzerobits(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.countzerobits(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.countzerobits(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.countzerobits(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.countzerobits(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.countzerobits(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.countzerobits(a.UShort7));
                    constexpr.ASSUME(result.UShort8  == math.countzerobits(a.UShort8));
                    constexpr.ASSUME(result.UShort9  == math.countzerobits(a.UShort9));
                    constexpr.ASSUME(result.UShort10 == math.countzerobits(a.UShort10));
                    constexpr.ASSUME(result.UShort11 == math.countzerobits(a.UShort11));
                    constexpr.ASSUME(result.UShort12 == math.countzerobits(a.UShort12));
                    constexpr.ASSUME(result.UShort13 == math.countzerobits(a.UShort13));
                    constexpr.ASSUME(result.UShort14 == math.countzerobits(a.UShort14));
                    constexpr.ASSUME(result.UShort15 == math.countzerobits(a.UShort15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 unpopcnt_epi32(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return popcnt_epi32(not_si128(a));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 byteBits = unpopcnt_epi16(a);

                    v128 lo = and_si128(byteBits, set1_epi32(0x0000_FFFF));
                    v128 hi = srli_epi32(byteBits, 16);

                    v128 result = add_epi32(lo, hi);

                    constexpr.ASSUME_LE_EPU32(result, 32);

                    constexpr.ASSUME(result.UInt0  == math.countzerobits(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.countzerobits(a.UInt1));
                    constexpr.ASSUME(result.UInt2  == math.countzerobits(a.UInt2));
                    constexpr.ASSUME(result.UInt3  == math.countzerobits(a.UInt3));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_unpopcnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 shortBits = mm256_unpopcnt_epi16(a);
                    v256 lo = Avx2.mm256_and_si256(shortBits, mm256_set1_epi32(0x0000_FFFF));
                    v256 hi = Avx2.mm256_srli_epi32(shortBits, 16);

                    v256 result = Avx2.mm256_add_epi32(lo, hi);

                    constexpr.ASSUME_LE_EPU32(result, 32);

                    constexpr.ASSUME(result.UInt0  == math.countzerobits(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.countzerobits(a.UInt1));
                    constexpr.ASSUME(result.UInt2  == math.countzerobits(a.UInt2));
                    constexpr.ASSUME(result.UInt3  == math.countzerobits(a.UInt3));
                    constexpr.ASSUME(result.UInt4  == math.countzerobits(a.UInt4));
                    constexpr.ASSUME(result.UInt5  == math.countzerobits(a.UInt5));
                    constexpr.ASSUME(result.UInt6  == math.countzerobits(a.UInt6));
                    constexpr.ASSUME(result.UInt7  == math.countzerobits(a.UInt7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 unpopcnt_epi64(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return popcnt_epi64(not_si128(a));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (Popcnt.IsPopcntSupported)
                    {
                        result = popcnt_epi64(not_si128(a));
                    }
                    else
                    {
                        result = sad_epu8(unpopcnt_epi8(a), setzero_si128());
                    }

                    constexpr.ASSUME_LE_EPU64(result, 64);

                    constexpr.ASSUME(result.ULong0  == math.countzerobits(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.countzerobits(a.ULong1));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_unpopcnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sad_epu8(mm256_unpopcnt_epi8(a), Avx.mm256_setzero_si256());

                    constexpr.ASSUME_LE_EPU64(result, 64);

                    constexpr.ASSUME(result.ULong0  == math.countzerobits(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.countzerobits(a.ULong1));
                    constexpr.ASSUME(result.ULong2  == math.countzerobits(a.ULong2));
                    constexpr.ASSUME(result.ULong3  == math.countzerobits(a.ULong3));

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="UInt128"/>.     </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(UInt128 x)
        {
            return (byte)(countzerobits(x.lo64) + countzerobits(x.hi64));
        }

        /// <summary>       Returns number of 0-bits in the binary representation of an <see cref="Int128"/>.     </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(Int128 x)
        {
            return (byte)(countzerobits(x.lo64) + countzerobits(x.hi64));
        }


        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="byte32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 countzerobits(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_unpopcnt_epi8(x);
            }
            else
            {
                return new byte32(countzerobits(x.v16_0), countzerobits(x.v16_16));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="byte16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 countzerobits(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi8(x);
            }
            else
            {
                return new byte16((byte)countzerobits(x.x0), (byte)countzerobits(x.x1), (byte)countzerobits(x.x2), (byte)countzerobits(x.x3), (byte)countzerobits(x.x4), (byte)countzerobits(x.x5), (byte)countzerobits(x.x6), (byte)countzerobits(x.x7), (byte)countzerobits(x.x8), (byte)countzerobits(x.x9), (byte)countzerobits(x.x10), (byte)countzerobits(x.x11), (byte)countzerobits(x.x12), (byte)countzerobits(x.x13), (byte)countzerobits(x.x14), (byte)countzerobits(x.x15));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="byte8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 countzerobits(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi8(x);
            }
            else
            {
                return new byte8((byte)countzerobits(x.x0), (byte)countzerobits(x.x1), (byte)countzerobits(x.x2), (byte)countzerobits(x.x3), (byte)countzerobits(x.x4), (byte)countzerobits(x.x5), (byte)countzerobits(x.x6), (byte)countzerobits(x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="byte4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 countzerobits(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi8(x);
            }
            else
            {
                return new byte4((byte)countzerobits(x.x), (byte)countzerobits(x.y), (byte)countzerobits(x.z), (byte)countzerobits(x.w));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="byte3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 countzerobits(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi8(x);
            }
            else
            {
                return new byte3((byte)countzerobits(x.x), (byte)countzerobits(x.y), (byte)countzerobits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="byte2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 countzerobits(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi8(x);
            }
            else
            {
                return new byte2((byte)countzerobits(x.x), (byte)countzerobits(x.y));
            }
        }

        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="byte"/>.     </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(byte x)
        {
            return countbits((uint)(byte)~x);
        }


        /// <summary>       Returns component-wise number of 0-bits in the binary representation of an <see cref="sbyte32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 countzerobits(sbyte32 x)
        {
            return (sbyte32)countzerobits((byte32)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of an <see cref="sbyte16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 countzerobits(sbyte16 x)
        {
            return (sbyte16)countzerobits((byte16)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of an <see cref="sbyte8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 countzerobits(sbyte8 x)
        {
            return (sbyte8)countzerobits((byte8)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of an <see cref="sbyte4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 countzerobits(sbyte4 x)
        {
            return (sbyte4)countzerobits((byte4)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of an <see cref="sbyte3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 countzerobits(sbyte3 x)
        {
            return (sbyte3)countzerobits((byte3)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of an <see cref="sbyte2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 countzerobits(sbyte2 x)
        {
            return (sbyte2)countzerobits((byte2)x);
        }

        /// <summary>       Returns number of 0-bits in the binary representation of an <see cref="sbyte"/>.     </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(sbyte x)
        {
            return countzerobits((byte)x);
        }


        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ushort16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 countzerobits(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_unpopcnt_epi16(x);
            }
            else
            {
                return new ushort16(countzerobits(x.v8_0), countzerobits(x.v8_8));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ushort8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 countzerobits(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi16(x);
            }
            else
            {
                return new ushort8((ushort)countzerobits(x.x0), (ushort)countzerobits(x.x1), (ushort)countzerobits(x.x2), (ushort)countzerobits(x.x3), (ushort)countzerobits(x.x4), (ushort)countzerobits(x.x5), (ushort)countzerobits(x.x6), (ushort)countzerobits(x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ushort4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 countzerobits(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi16(x);
            }
            else
            {
                return new ushort4((ushort)countzerobits(x.x), (ushort)countzerobits(x.y), (ushort)countzerobits(x.z), (ushort)countzerobits(x.w));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ushort3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 countzerobits(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi16(x);
            }
            else
            {
                return new ushort3((ushort)countzerobits(x.x), (ushort)countzerobits(x.y), (ushort)countzerobits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ushort2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 countzerobits(ushort2 x)
        {
            if (Arm.Neon.IsNeonSupported)
            {
                return Xse.unpopcnt_epi16(x);
            }
            else
            {
                return new ushort2((ushort)countzerobits(x.x), (ushort)countzerobits(x.y));
            }
        }

        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="ushort"/>.     </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(ushort x)
        {
            return countbits((uint)(ushort)~x);
        }


        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="short16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 countzerobits(short16 x)
        {
            return (short16)countzerobits((ushort16)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="short8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 countzerobits(short8 x)
        {
            return (short8)countzerobits((ushort8)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="short4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 countzerobits(short4 x)
        {
            return (short4)countzerobits((ushort4)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="short3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 countzerobits(short3 x)
        {
            return (short3)countzerobits((ushort3)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="short2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 countzerobits(short2 x)
        {
            return (short2)countzerobits((ushort2)x);
        }

        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="short"/>.     </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(short x)
        {
            return countzerobits((ushort)x);
        }


        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="uint8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countzerobits(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_unpopcnt_epi32(x);
            }
            else
            {
                return new int8(countzerobits(x.v4_0), countzerobits(x.v4_4));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="uint4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 countzerobits(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi32(x);
            }
            else
            {
                return new int4(countzerobits(x.x), countzerobits(x.y), countzerobits(x.z), countzerobits(x.w));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="uint3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 countzerobits(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpopcnt_epi32(x);
            }
            else
            {
                return new int3(countzerobits(x.x), countzerobits(x.y), countzerobits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="uint2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 countzerobits(uint2 x)
        {
            if (Arm.Neon.IsNeonSupported)
            {
                return Xse.unpopcnt_epi32(x);
            }
            else
            {
                return new int2(countzerobits(x.x), countzerobits(x.y));
            }
        }

        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="uint"/>.     </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(uint x)
        {
            return countbits(~x);
        }


        /// <summary>       Returns component-wise number of 0-bits in the binary representation of an <see cref="int8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countzerobits(int8 x)
        {
            return countzerobits((uint8)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="int4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 countzerobits(int4 x)
        {
            return countzerobits((uint4)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="int3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 countzerobits(int3 x)
        {
            return countzerobits((uint3)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="int2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 countzerobits(int2 x)
        {
            return countzerobits((uint2)x);
        }

        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="int"/>.     </summary>
        [return: AssumeRange(0L, 32L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(int x)
        {
            return countzerobits((uint)x);
        }


        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="ulong"/>.     </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(ulong x)
        {
            return countbits(~x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ulong2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 countzerobits(ulong2 x)
        {
            if (Arm.Neon.IsNeonSupported)
            {
                return Xse.unpopcnt_epi64(x);
            }
            else
            {
                return new ulong2((uint)countzerobits(x.x), (uint)countzerobits(x.y));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ulong3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 countzerobits(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_unpopcnt_epi64(x);
            }
            else
            {
                return new ulong3(countzerobits(x.xy), (uint)countzerobits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="ulong4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 countzerobits(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_unpopcnt_epi64(x);
            }
            else
            {
                return new ulong4(countzerobits(x.xy), countzerobits(x.zw));
            }
        }


        /// <summary>       Returns number of 0-bits in the binary representation of a <see cref="long"/>.     </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countzerobits(long x)
        {
            return countzerobits((ulong)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="long2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 countzerobits(long2 x)
        {
            return (long2)countzerobits((ulong2)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="long3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 countzerobits(long3 x)
        {
            return (long3)countzerobits((ulong3)x);
        }

        /// <summary>       Returns component-wise number of 0-bits in the binary representation of a <see cref="long4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 countzerobits(long4 x)
        {
            return (long4)countzerobits((ulong4)x);
        }
    }
}