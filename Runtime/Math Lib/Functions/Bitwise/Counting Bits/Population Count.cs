using System.Runtime.CompilerServices;
using Unity.Burst;
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
            public static v128 popcnt_epi8(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vcntq_u8(a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 LOOKUP = new v128(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);

                        v128 countLo = shuffle_epi8(LOOKUP, and_si128(NIBBLE_MASK, a));
                        v128 countHi = shuffle_epi8(LOOKUP, and_si128(NIBBLE_MASK, srli_epi16(a, 4)));

                        result = add_epi8(countLo, countHi);
                    }
                    else
                    {
                        v128 __a = sub_epi8(a, and_si128(srli_epi16(a, 1), set1_epi8(0x55)));
                        __a = add_epi8(and_si128(__a, set1_epi8(0x33)), and_si128(srli_epi16(__a, 2), set1_epi8(0x33)));
                        result = and_si128(NIBBLE_MASK, add_epi8(__a, srli_epi16(__a, 4)));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.countbits(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.countbits(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.countbits(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.countbits(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.countbits(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.countbits(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.countbits(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.countbits(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.countbits(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.countbits(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.countbits(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.countbits(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.countbits(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.countbits(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.countbits(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.countbits(a.Byte15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 LOOKUP = new v256(0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4,
                                           0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4);

                    v256 countLo = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a));
                    v256 countHi = Avx2.mm256_shuffle_epi8(LOOKUP, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4)));

                    v256 result = Avx2.mm256_add_epi8(countLo, countHi);

                    constexpr.ASSUME_LE_EPU8(result, 8);

                    constexpr.ASSUME(result.Byte0  == math.countbits(a.Byte0));
                    constexpr.ASSUME(result.Byte1  == math.countbits(a.Byte1));
                    constexpr.ASSUME(result.Byte2  == math.countbits(a.Byte2));
                    constexpr.ASSUME(result.Byte3  == math.countbits(a.Byte3));
                    constexpr.ASSUME(result.Byte4  == math.countbits(a.Byte4));
                    constexpr.ASSUME(result.Byte5  == math.countbits(a.Byte5));
                    constexpr.ASSUME(result.Byte6  == math.countbits(a.Byte6));
                    constexpr.ASSUME(result.Byte7  == math.countbits(a.Byte7));
                    constexpr.ASSUME(result.Byte8  == math.countbits(a.Byte8));
                    constexpr.ASSUME(result.Byte9  == math.countbits(a.Byte9));
                    constexpr.ASSUME(result.Byte10 == math.countbits(a.Byte10));
                    constexpr.ASSUME(result.Byte11 == math.countbits(a.Byte11));
                    constexpr.ASSUME(result.Byte12 == math.countbits(a.Byte12));
                    constexpr.ASSUME(result.Byte13 == math.countbits(a.Byte13));
                    constexpr.ASSUME(result.Byte14 == math.countbits(a.Byte14));
                    constexpr.ASSUME(result.Byte15 == math.countbits(a.Byte15));
                    constexpr.ASSUME(result.Byte16 == math.countbits(a.Byte16));
                    constexpr.ASSUME(result.Byte17 == math.countbits(a.Byte17));
                    constexpr.ASSUME(result.Byte18 == math.countbits(a.Byte18));
                    constexpr.ASSUME(result.Byte19 == math.countbits(a.Byte19));
                    constexpr.ASSUME(result.Byte20 == math.countbits(a.Byte20));
                    constexpr.ASSUME(result.Byte21 == math.countbits(a.Byte21));
                    constexpr.ASSUME(result.Byte22 == math.countbits(a.Byte22));
                    constexpr.ASSUME(result.Byte23 == math.countbits(a.Byte23));
                    constexpr.ASSUME(result.Byte24 == math.countbits(a.Byte24));
                    constexpr.ASSUME(result.Byte25 == math.countbits(a.Byte25));
                    constexpr.ASSUME(result.Byte26 == math.countbits(a.Byte26));
                    constexpr.ASSUME(result.Byte27 == math.countbits(a.Byte27));
                    constexpr.ASSUME(result.Byte28 == math.countbits(a.Byte28));
                    constexpr.ASSUME(result.Byte29 == math.countbits(a.Byte29));
                    constexpr.ASSUME(result.Byte30 == math.countbits(a.Byte30));
                    constexpr.ASSUME(result.Byte31 == math.countbits(a.Byte31));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 popcnt_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 byteBits = popcnt_epi8(a);

                    if (BurstArchitecture.IsAdjacentMultiplyAddEpi8Supported)
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v128 sizeResult = maddubs_epi16(byteBits, set1_epi8(1));

                            constexpr.ASSUME_LE_EPU16(sizeResult, 16);
                            return sizeResult;
                        }
                    }

                    v128 lo = and_si128(byteBits, set1_epi16(0x00FF));
                    v128 hi = srli_epi16(byteBits, 8);
                    
                    v128 result = add_epi16(lo, hi);
                    
                    constexpr.ASSUME_LE_EPU16(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.countbits(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.countbits(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.countbits(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.countbits(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.countbits(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.countbits(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.countbits(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.countbits(a.UShort7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 byteBits = mm256_popcnt_epi8(a);
                    v256 result;
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        result = Avx2.mm256_maddubs_epi16(byteBits, mm256_set1_epi8(1));
                    }
                    else
                    {
                        v256 lo = Avx2.mm256_and_si256(byteBits, mm256_set1_epi16(0x00FF));
                        v256 hi = Avx2.mm256_srli_epi16(byteBits, 8);

                        result = Avx2.mm256_add_epi16(lo, hi);
                    }

                    constexpr.ASSUME_LE_EPU16(result, 16);

                    constexpr.ASSUME(result.UShort0  == math.countbits(a.UShort0));
                    constexpr.ASSUME(result.UShort1  == math.countbits(a.UShort1));
                    constexpr.ASSUME(result.UShort2  == math.countbits(a.UShort2));
                    constexpr.ASSUME(result.UShort3  == math.countbits(a.UShort3));
                    constexpr.ASSUME(result.UShort4  == math.countbits(a.UShort4));
                    constexpr.ASSUME(result.UShort5  == math.countbits(a.UShort5));
                    constexpr.ASSUME(result.UShort6  == math.countbits(a.UShort6));
                    constexpr.ASSUME(result.UShort7  == math.countbits(a.UShort7));
                    constexpr.ASSUME(result.UShort8  == math.countbits(a.UShort8));
                    constexpr.ASSUME(result.UShort9  == math.countbits(a.UShort9));
                    constexpr.ASSUME(result.UShort10 == math.countbits(a.UShort10));
                    constexpr.ASSUME(result.UShort11 == math.countbits(a.UShort11));
                    constexpr.ASSUME(result.UShort12 == math.countbits(a.UShort12));
                    constexpr.ASSUME(result.UShort13 == math.countbits(a.UShort13));
                    constexpr.ASSUME(result.UShort14 == math.countbits(a.UShort14));
                    constexpr.ASSUME(result.UShort15 == math.countbits(a.UShort15));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 popcnt_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 byteBits = popcnt_epi16(a);

                    if (BurstArchitecture.IsAdjacentMultiplyAddEpi16Supported)
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v128 sizeResult = madd_epi16(byteBits, set1_epi16(1));

                            constexpr.ASSUME_LE_EPU16(sizeResult, 16);
                            return sizeResult;
                        }
                    }

                    v128 lo = and_si128(byteBits, set1_epi32(0x0000_FFFF));
                    v128 hi = srli_epi32(byteBits, 16);

                    v128 result = add_epi32(lo, hi);

                    constexpr.ASSUME_LE_EPU32(result, 32);

                    constexpr.ASSUME(result.UInt0  == math.countbits(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.countbits(a.UInt1));
                    constexpr.ASSUME(result.UInt2  == math.countbits(a.UInt2));
                    constexpr.ASSUME(result.UInt3  == math.countbits(a.UInt3));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 shortBits = mm256_popcnt_epi16(a);

                    v256 result;
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        result = Avx2.mm256_madd_epi16(shortBits, mm256_set1_epi16(1));
                    }
                    else
                    {
                        v256 lo = Avx2.mm256_and_si256(shortBits, mm256_set1_epi32(0x0000_FFFF));
                        v256 hi = Avx2.mm256_srli_epi32(shortBits, 16);

                        result = Avx2.mm256_add_epi32(lo, hi);
                    }

                    constexpr.ASSUME_LE_EPU32(result, 32);

                    constexpr.ASSUME(result.UInt0  == math.countbits(a.UInt0));
                    constexpr.ASSUME(result.UInt1  == math.countbits(a.UInt1));
                    constexpr.ASSUME(result.UInt2  == math.countbits(a.UInt2));
                    constexpr.ASSUME(result.UInt3  == math.countbits(a.UInt3));
                    constexpr.ASSUME(result.UInt4  == math.countbits(a.UInt4));
                    constexpr.ASSUME(result.UInt5  == math.countbits(a.UInt5));
                    constexpr.ASSUME(result.UInt6  == math.countbits(a.UInt6));
                    constexpr.ASSUME(result.UInt7  == math.countbits(a.UInt7));

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 popcnt_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Popcnt.IsPopcntSupported)
                    {
                        int lo = Popcnt.popcnt_u64((ulong)cvtsi128_si64x(a));
                        int hi = Popcnt.popcnt_u64((ulong)cvtsi128_si64x(bsrli_si128(a, sizeof(ulong))));

                        result = unpacklo_epi64(cvtsi32_si128(lo), cvtsi32_si128(hi));
                    }
                    else
                    {
                        result = sad_epu8(popcnt_epi8(a), setzero_si128());
                    }

                    constexpr.ASSUME_LE_EPU64(result, 64);

                    constexpr.ASSUME(result.ULong0  == math.countbits(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.countbits(a.ULong1));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_popcnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sad_epu8(mm256_popcnt_epi8(a), Avx.mm256_setzero_si256());

                    constexpr.ASSUME_LE_EPU64(result, 64);

                    constexpr.ASSUME(result.ULong0  == math.countbits(a.ULong0));
                    constexpr.ASSUME(result.ULong1  == math.countbits(a.ULong1));
                    constexpr.ASSUME(result.ULong2  == math.countbits(a.ULong2));
                    constexpr.ASSUME(result.ULong3  == math.countbits(a.ULong3));

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="UInt128"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(UInt128 x)
        {
            return (byte)(countbits(x.lo64) + countbits(x.hi64));
        }

        /// <summary>       Returns number of 1-bits in the binary representation of an <see cref="Int128"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 128ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(Int128 x)
        {
            return countbits((UInt128)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="byte32"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 countbits(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi8(x);
            }
            else
            {
                return new byte32(countbits(x.v16_0), countbits(x.v16_16));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="byte16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 countbits(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte16((byte)countbits((uint)x.x0), (byte)countbits((uint)x.x1), (byte)countbits((uint)x.x2), (byte)countbits((uint)x.x3), (byte)countbits((uint)x.x4), (byte)countbits((uint)x.x5), (byte)countbits((uint)x.x6), (byte)countbits((uint)x.x7), (byte)countbits((uint)x.x8), (byte)countbits((uint)x.x9), (byte)countbits((uint)x.x10), (byte)countbits((uint)x.x11), (byte)countbits((uint)x.x12), (byte)countbits((uint)x.x13), (byte)countbits((uint)x.x14), (byte)countbits((uint)x.x15));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="byte8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 countbits(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte8((byte)countbits((uint)x.x0), (byte)countbits((uint)x.x1), (byte)countbits((uint)x.x2), (byte)countbits((uint)x.x3), (byte)countbits((uint)x.x4), (byte)countbits((uint)x.x5), (byte)countbits((uint)x.x6), (byte)countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="byte4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 countbits(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte4((byte)countbits((uint)x.x), (byte)countbits((uint)x.y), (byte)countbits((uint)x.z), (byte)countbits((uint)x.w));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="byte3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 countbits(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte3((byte)countbits((uint)x.x), (byte)countbits((uint)x.y), (byte)countbits((uint)x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="byte2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 countbits(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte2((byte)countbits((uint)x.x), (byte)countbits((uint)x.y));
            }
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="byte"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(byte x)
        {
            if (Popcnt.IsPopcntSupported)
            {
                return countbits((uint)x);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Xse.popcnt_epi8(new byte16(x, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)).Byte0;
            }
            else
            {
                uint r = x;

                r -= (r >> 1) & 0x55;
                r = (r & 0x33) + ((r >> 2) & 0x33);
                r = (r + (r >> 4)) & 0x0F;

                return (byte)r;
            }
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="sbyte32"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 countbits(sbyte32 x)
        {
            return (sbyte32)countbits((byte32)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="sbyte16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 countbits(sbyte16 x)
        {
            return (sbyte16)countbits((byte16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="sbyte8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 countbits(sbyte8 x)
        {
            return (sbyte8)countbits((byte8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="sbyte4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 countbits(sbyte4 x)
        {
            return (sbyte4)countbits((byte4)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="sbyte3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 countbits(sbyte3 x)
        {
            return (sbyte3)countbits((byte3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="sbyte2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 countbits(sbyte2 x)
        {
            return (sbyte2)countbits((byte2)x);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of an <see cref="sbyte"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(sbyte x)
        {
            return countbits((byte)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ushort16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 countbits(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi16(x);
            }
            else
            {
                return new ushort16(countbits(x.v8_0), countbits(x.v8_8));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ushort8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 countbits(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort8((ushort)countbits((uint)x.x0), (ushort)countbits((uint)x.x1), (ushort)countbits((uint)x.x2), (ushort)countbits((uint)x.x3), (ushort)countbits((uint)x.x4), (ushort)countbits((uint)x.x5), (ushort)countbits((uint)x.x6), (ushort)countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ushort4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 countbits(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort4((ushort)countbits((uint)x.x), (ushort)countbits((uint)x.y), (ushort)countbits((uint)x.z), (ushort)countbits((uint)x.w));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ushort3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 countbits(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort3((ushort)countbits((uint)x.x), (ushort)countbits((uint)x.y), (ushort)countbits((uint)x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ushort2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 countbits(ushort2 x)
        {
            return new ushort2((ushort)countbits((uint)x.x), (ushort)countbits((uint)x.y));
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="ushort"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(ushort x)
        {
            if (Popcnt.IsPopcntSupported)
            {
                return countbits((uint)x);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                ushort byteBits = Xse.popcnt_epi8(new ushort8(x, 0, 0, 0, 0, 0, 0, 0)).UShort0;

                return (byte)((byteBits & 0xFF) + (byteBits >> 8));
            }
            else
            {
                uint r = x;
                
                r = r - ((r >> 1) & 0x5555);
                r = (r & 0x3333) + ((r >> 2) & 0x3333);
                r = (r + (r >> 4)) & 0x0F0F;
                r = r + (r >> 8);

                return (byte)(r & 0x001F);
            }
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="short16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 countbits(short16 x)
        {
            return (short16)countbits((ushort16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="short8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 countbits(short8 x)
        {
            return (short8)countbits((ushort8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="short4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 countbits(short4 x)
        {
            return (short4)countbits((ushort4)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="short3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 countbits(short3 x)
        {
            return (short3)countbits((ushort3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="short2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 countbits(short2 x)
        {
            return (short2)countbits((ushort2)x);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="short"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(short x)
        {
            return countbits((uint)(ushort)x);
        }

        
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="uint8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countbits(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi32(x);
            }
            else
            {
                return new int8(countbits(x.v4_0), countbits(x.v4_4));
            }
        }
        
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="uint4"/>. Also known as the Hamming weight, popcnt on x46, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 countbits(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi32(x);
            }
            else
            {
                return new int4(countbits(x.x), countbits(x.y), countbits(x.z), countbits(x.w));
            }
        }
        
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="uint3"/>. Also known as the Hamming weight, popcnt on x36, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 countbits(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi32(x);
            }
            else
            {
                return new int3(countbits(x.x), countbits(x.y), countbits(x.z));
            }
        }
        
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="uint2"/>. Also known as the Hamming weight, popcnt on x26, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 countbits(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi32(x);
            }
            else
            {
                return new int2(countbits(x.x), countbits(x.y));
            }
        }
        
        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="uint"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(uint x)
        {
            return (byte)Unity.Mathematics.math.countbits(x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="int8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countbits(int8 x)
        {
            return (int8)countbits((uint8)x);
        }
        
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="int4"/>. Also known as the Hamming weight, popcnt on x46, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 countbits(int4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi32(x);
            }
            else
            {
                return new int4(countbits(x.x), countbits(x.y), countbits(x.z), countbits(x.w));
            }
        }
        
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="int3"/>. Also known as the Hamming weight, popcnt on x36, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 countbits(int3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi32(x);
            }
            else
            {
                return new int3(countbits(x.x), countbits(x.y), countbits(x.z));
            }
        }
        
        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="int2"/>. Also known as the Hamming weight, popcnt on x26, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 countbits(int2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi32(x);
            }
            else
            {
                return new int2(countbits(x.x), countbits(x.y));
            }
        }
        
        /// <summary>       Returns number of 1-bits in the binary representation of an <see cref="int"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 32ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(int x)
        {
            return (byte)Unity.Mathematics.math.countbits(x);
        }
        
        
        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="ulong"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(ulong x)
        {
            return (byte)Unity.Mathematics.math.countbits(x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ulong2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 countbits(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi64(x);
            }
            else
            {
                return new ulong2((uint)countbits(x.x), (uint)countbits(x.y));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ulong3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 countbits(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi64(x);
            }
            else
            {
                return new ulong3(countbits(x.xy), (uint)countbits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="ulong4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 countbits(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi64(x);
            }
            else
            {
                return new ulong4(countbits(x.xy), countbits(x.zw));
            }
        }

        
        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="long"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0ul, 64ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte countbits(long x)
        {
            return (byte)Unity.Mathematics.math.countbits(x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="long2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 countbits(long2 x)
        {
            return (long2)countbits((ulong2)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="long3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 countbits(long3 x)
        {
            return (long3)countbits((ulong3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="long4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 countbits(long4 x)
        {
            return (long4)countbits((ulong4)x);
        }
    }
}