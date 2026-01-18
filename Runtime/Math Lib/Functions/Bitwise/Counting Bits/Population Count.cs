using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
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
                        v128 ONE = set1_epi8(1);

                        result = add_epi8(add_epi8(add_epi8(and_si128(ONE, a),
                                                            and_si128(ONE, srli_epi16(a, 1))),
                                                   add_epi8(and_si128(ONE, srli_epi16(a, 2)),
                                                            and_si128(ONE, srli_epi16(a, 3)))),
                                          add_epi8(add_epi8(and_si128(ONE, srli_epi16(a, 4)),
                                                            and_si128(ONE, srli_epi16(a, 5))),
                                                   add_epi8(and_si128(ONE, srli_epi16(a, 6)),
                                                            and_si128(ONE, srli_epi16(a, 7)))));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 8);
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

                    v128 lo = and_si128(byteBits, set1_epi16(0x00FF));
                    v128 hi = srli_epi16(byteBits, 8);

                    v128 result = add_epi16(lo, hi);

                    constexpr.ASSUME_LE_EPU16(result, 16);
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
                    v256 lo = Avx2.mm256_and_si256(byteBits, mm256_set1_epi16(0x00FF));
                    v256 hi = Avx2.mm256_srli_epi16(byteBits, 8);

                    v256 result = Avx2.mm256_add_epi16(lo, hi);

                    constexpr.ASSUME_LE_EPU16(result, 16);
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

                    v128 lo = and_si128(byteBits, set1_epi32(0x0000_FFFF));
                    v128 hi = srli_epi32(byteBits, 16);

                    v128 result = add_epi32(lo, hi);

                    constexpr.ASSUME_LE_EPU32(result, 32);
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
                    v256 lo = Avx2.mm256_and_si256(shortBits, mm256_set1_epi32(0x0000_FFFF));
                    v256 hi = Avx2.mm256_srli_epi32(shortBits, 16);

                    v256 result = Avx2.mm256_add_epi32(lo, hi);

                    constexpr.ASSUME_LE_EPU32(result, 32);
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
                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="UInt128"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int countbits(UInt128 x)
        {
            return math.countbits(x.lo64) + math.countbits(x.hi64);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of an <see cref="Int128"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int countbits(Int128 x)
        {
            return countbits((UInt128)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte32"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
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

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 countbits(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte16((byte)math.countbits((uint)x.x0), (byte)math.countbits((uint)x.x1), (byte)math.countbits((uint)x.x2), (byte)math.countbits((uint)x.x3), (byte)math.countbits((uint)x.x4), (byte)math.countbits((uint)x.x5), (byte)math.countbits((uint)x.x6), (byte)math.countbits((uint)x.x7), (byte)math.countbits((uint)x.x8), (byte)math.countbits((uint)x.x9), (byte)math.countbits((uint)x.x10), (byte)math.countbits((uint)x.x11), (byte)math.countbits((uint)x.x12), (byte)math.countbits((uint)x.x13), (byte)math.countbits((uint)x.x14), (byte)math.countbits((uint)x.x15));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 countbits(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte8((byte)math.countbits((uint)x.x0), (byte)math.countbits((uint)x.x1), (byte)math.countbits((uint)x.x2), (byte)math.countbits((uint)x.x3), (byte)math.countbits((uint)x.x4), (byte)math.countbits((uint)x.x5), (byte)math.countbits((uint)x.x6), (byte)math.countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 countbits(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte4((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y), (byte)math.countbits((uint)x.z), (byte)math.countbits((uint)x.w));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 countbits(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte3((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y), (byte)math.countbits((uint)x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.byte2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 countbits(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi8(x);
            }
            else
            {
                return new byte2((byte)math.countbits((uint)x.x), (byte)math.countbits((uint)x.y));
            }
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="byte"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 8L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int countbits(byte x)
        {
            return math.countbits((uint)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte32"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 countbits(sbyte32 x)
        {
            return (sbyte32)countbits((byte32)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 countbits(sbyte16 x)
        {
            return (sbyte16)countbits((byte16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 countbits(sbyte8 x)
        {
            return (sbyte8)countbits((byte8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 countbits(sbyte4 x)
        {
            return (sbyte4)countbits((byte4)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 countbits(sbyte3 x)
        {
            return (sbyte3)countbits((byte3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.sbyte2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 countbits(sbyte2 x)
        {
            return (sbyte2)countbits((byte2)x);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of an <see cref="sbyte"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 8L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int countbits(sbyte x)
        {
            return math.countbits((uint)(byte)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
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

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 countbits(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort8((ushort)math.countbits((uint)x.x0), (ushort)math.countbits((uint)x.x1), (ushort)math.countbits((uint)x.x2), (ushort)math.countbits((uint)x.x3), (ushort)math.countbits((uint)x.x4), (ushort)math.countbits((uint)x.x5), (ushort)math.countbits((uint)x.x6), (ushort)math.countbits((uint)x.x7));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 countbits(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort4((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y), (ushort)math.countbits((uint)x.z), (ushort)math.countbits((uint)x.w));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 countbits(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi16(x);
            }
            else
            {
                return new ushort3((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y), (ushort)math.countbits((uint)x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ushort2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 countbits(ushort2 x)
        {
            return new ushort2((ushort)math.countbits((uint)x.x), (ushort)math.countbits((uint)x.y));
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="ushort"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 16L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int countbits(ushort x)
        {
            return math.countbits((uint)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short16"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 countbits(short16 x)
        {
            return (short16)countbits((ushort16)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 countbits(short8 x)
        {
            return (short8)countbits((ushort8)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 countbits(short4 x)
        {
            return (short4)countbits((ushort4)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 countbits(short3 x)
        {
            return (short3)countbits((ushort3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.short2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 countbits(short2 x)
        {
            return (short2)countbits((ushort2)x);
        }

        /// <summary>       Returns number of 1-bits in the binary representation of a <see cref="short"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.     </summary>
        [return: AssumeRange(0L, 16L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int countbits(short x)
        {
            return math.countbits((uint)(ushort)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.uint8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countbits(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi32(x);
            }
            else
            {
                return new int8(math.countbits(x.v4_0), math.countbits(x.v4_4));
            }
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of an <see cref="MaxMath.int8"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 countbits(int8 x)
        {
            return (int8)countbits((uint8)x);
        }


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ulong2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 countbits(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.popcnt_epi64(x);
            }
            else
            {
                return new ulong2((uint)math.countbits(x.x), (uint)math.countbits(x.y));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ulong3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 countbits(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_popcnt_epi64(x);
            }
            else
            {
                return new ulong3(countbits(x.xy), (uint)math.countbits(x.z));
            }
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.ulong4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
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


        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.long2"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 countbits(long2 x)
        {
            return (long2)countbits((ulong2)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.long3"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 countbits(long3 x)
        {
            return (long3)countbits((ulong3)x);
        }

        /// <summary>       Returns component-wise number of 1-bits in the binary representation of a <see cref="MaxMath.long4"/>. Also known as the Hamming weight, popcnt on x86, and vcnt on ARM.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 countbits(long4 x)
        {
            return (long4)countbits((ulong4)x);
        }
    }
}