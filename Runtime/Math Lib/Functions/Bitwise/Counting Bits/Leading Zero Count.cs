using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzcnt_epi8(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vclzq_u8(a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                        v128 SHUFFLE_MASK_HI = new v128(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                        result = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                          shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                    }
                    else
                    {
                        v128 ZERO = setzero_si128();

                        v128 y;
                        v128 n = set1_epi8(8);
                        v128 mask;

                        y = srli_epi8(a, 4);
                        mask = cmpeq_epi8(y, ZERO);
                        n = sub_epi8(n, andnot_si128(mask, set1_epi8(4)));
                        a = blendv_si128(y, a, mask);

                        y = srli_epi8(a, 2);
                        mask = cmpeq_epi8(y, ZERO);
                        n = sub_epi8(n, andnot_si128(mask, set1_epi8(2)));
                        a = blendv_si128(y, a, mask);

                        y = srli_epi8(a, 1);
                        mask = cmpeq_epi8(y, ZERO);

                        result = sub_epi8(n, blendv_si128(set1_epi8(2), a, mask));
                    }

                    constexpr.ASSUME_LE_EPU8(result, 8);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzcnt_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4,
                                                    8, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                    v256 SHUFFLE_MASK_HI = new v256(8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                                                    8, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                    v256 result = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                      Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    constexpr.ASSUME_LE_EPU8(result, 8);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzcnt_epi16(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vclzq_u16(a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                        v128 SHUFFLE_MASK_HI = new v128(16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                        v128 lzcnt_bytes = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                                    shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));

                        result = min_epu8(add_epi8(lzcnt_bytes, set1_epi16(8)),
                                          srli_epi16(lzcnt_bytes, 8));
                    }
                    else
                    {
                        v128 ZERO = setzero_si128();

                        v128 y;
                        v128 n = set1_epi16(16);
                        v128 mask;

                        y = srli_epi16(a, 8);
                        mask = cmpeq_epi16(y, ZERO);
                        n = sub_epi16(n, andnot_si128(mask, set1_epi16(8)));
                        a = blendv_si128(y, a, mask);

                        y = srli_epi16(a, 4);
                        mask = cmpeq_epi16(y, ZERO);
                        n = sub_epi16(n, andnot_si128(mask, set1_epi16(4)));
                        a = blendv_si128(y, a, mask);

                        y = srli_epi16(a, 2);
                        mask = cmpeq_epi16(y, ZERO);
                        n = sub_epi16(n, andnot_si128(mask, set1_epi16(2)));
                        a = blendv_si128(y, a, mask);

                        y = srli_epi16(a, 1);
                        mask = cmpeq_epi16(y, ZERO);

                        result = sub_epi16(n, blendv_si128(set1_epi16(2), a, mask));
                    }

                    constexpr.ASSUME_LE_EPU16(result, 16);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzcnt_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4,
                                                    16, 7, 6, 6, 5, 5, 5, 5, 4, 4, 4, 4, 4, 4, 4, 4);
                    v256 SHUFFLE_MASK_HI = new v256(16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0,
                                                    16, 3, 2, 2, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0);

                    v256 lzcnt_bytes = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                           Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    v256 result = Avx2.mm256_min_epu8(Avx2.mm256_add_epi8(lzcnt_bytes, mm256_set1_epi16(8)),
                                                      Avx2.mm256_srli_epi16(lzcnt_bytes, 8));

                    constexpr.ASSUME_LE_EPU16(result, 16);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzcnt_epi32(v128 a, byte elements = 4)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vclzq_u32(a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result;
                    if (elements > 2)
                    {
                        v128 loA = cvt2x2epu32_pd(a, out v128 hiA);
                        result = shuffle_ps(loA, hiA, Sse.SHUFFLE(3, 1, 3, 1));
                    }
                    else
                    {
                        result = cvtepu32_pd(a);
                        result = shuffle_epi32(result, Sse.SHUFFLE(0, 0, 3, 1));
                    }

                    result = srai_epi32(result, 52 - 32);
                    result = sub_epi16(set1_epi32(1054), result);
                    result = min_epu16(result, set1_epi32(32));

                    constexpr.ASSUME_LE_EPU32(result, 32);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzcnt_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 loA = mm256_cvt2x2epu32_pd(a, out v256 hiA);
                    v256 result = Avx.mm256_shuffle_ps(loA, hiA, Sse.SHUFFLE(3, 1, 3, 1));

                    result = Avx2.mm256_srai_epi32(result, 52 - 32);
                    result = Avx2.mm256_sub_epi16(mm256_set1_epi32(1054), result);
                    result = Avx2.mm256_min_epu16(result, mm256_set1_epi32(32));

                    constexpr.ASSUME_LE_EPU32(result, 32);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lzcnt_epi64(v128 a)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    v128 lzcnt32 = lzcnt_epi32(a);
                    v128 hi0 = shuffle_epi32(cmpeq_epi32(a, setzero_si128()), Sse.SHUFFLE(3, 3, 1, 1));

                    v128 lo = and_si128(lzcnt32, set1_epi64x(uint.MaxValue));
                    v128 hi = srli_epi64(lzcnt32, 32);

                    v128 baseAdd = blendv_si128(hi, lo, hi0);
                    v128 add = and_si128(set1_epi32(32), hi0);

                    return add_epi8(baseAdd, add);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    int lo = math.lzcnt(cvtsi128_si64x(a));
                    int hi = math.lzcnt(cvtsi128_si64x(bsrli_si128(a, sizeof(long))));

                    v128 result = unpacklo_epi64(cvtsi64x_si128((uint)lo), cvtsi64x_si128((uint)hi));

                    constexpr.ASSUME_LE_EPU64(result, 64);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzcnt_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 hi0 = Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256());

                    v256 bits = Avx.mm256_blendv_pd(Avx2.mm256_srli_epi64(a, 32), a, hi0);
                    v256 offset = Avx.mm256_blendv_pd(mm256_set1_epi64x(0x041E), mm256_set1_epi64x(0x043E), hi0);

                    bits = mm256_usfcvtepu64_pd(bits);
                    bits = Avx2.mm256_sub_epi64(offset, Avx2.mm256_srli_epi64(bits, F64_MANTISSA_BITS));

                    v256 result = Avx2.mm256_min_epu16(bits, mm256_set1_epi64x(64));
                    constexpr.ASSUME_LE_EPU64(result, 64);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            /// <summary>   As if they were 64bit integers  </summary>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lzcnt_pd(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsBetween<double4, double>(RegisterConversion.ToDouble4(a), long.MinValue, ulong.MaxValue, elements);

                    v256 EXP32 = mm256_set1_epi64x(32L << F64_MANTISSA_BITS);
                    v256 GREATER_THRESHOLD = mm256_set1_epi64x((31L - F64_EXPONENT_BIAS) << F64_MANTISSA_BITS);

                    v256 hi0 = Avx2.mm256_cmpgt_epi32(a, GREATER_THRESHOLD);

                    v256 bits = Avx.mm256_blendv_pd(Avx2.mm256_sub_epi64(a, EXP32), a, hi0);
                    v256 offset = Avx.mm256_blendv_pd(mm256_set1_epi64x(0x041E), mm256_set1_epi64x(0x043E), hi0);

                    bits = Avx2.mm256_sub_epi64(offset, Avx2.mm256_srli_epi64(bits, F64_MANTISSA_BITS));

                    v256 result = Avx2.mm256_min_epu16(bits, mm256_set1_epi64x(64));
                    constexpr.ASSUME_LE_EPU64(result, 64);
                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns number of leading zeros in the binary representation of a <see cref="UInt128"/>.    </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lzcnt(UInt128 x)
        {
            int lzcntLo = math.lzcnt(x.lo64);
            int lzcntHi = math.lzcnt(x.hi64);
            bool hi0 = x.hi64 == 0;
            int add = hi0 ? 64 : 0;

            return add + (hi0 ? lzcntLo : lzcntHi);
        }

        /// <summary>       Returns number of leading zeros in the binary representation of an <see cref="Int128"/>.    </summary>
        [return: AssumeRange(0L, 128L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lzcnt(Int128 x)
        {
            return lzcnt(x.value);
        }


        /// <summary>       Returns number of leading zeros in the binary representation of a <see cref="byte"/>.    </summary>
        [return: AssumeRange(0ul, 8ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte lzcnt(byte x)
        {
            return (byte)math.max(math.lzcnt((uint)x) - 24, 0);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.byte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lzcnt(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi8(x);
            }
            else
            {
                return new byte2(lzcnt(x.x), lzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.byte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lzcnt(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi8(x);
            }
            else
            {
                return new byte3(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.byte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lzcnt(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi8(x);
            }
            else
            {
                return new byte4(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z), lzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.byte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lzcnt(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi8(x);
            }
            else
            {
                return new byte8(lzcnt(x.x0), lzcnt(x.x1), lzcnt(x.x2), lzcnt(x.x3), lzcnt(x.x4), lzcnt(x.x5), lzcnt(x.x6), lzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.byte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lzcnt(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi8(x);
            }
            else
            {
                return new byte16(lzcnt(x.x0), lzcnt(x.x1), lzcnt(x.x2), lzcnt(x.x3), lzcnt(x.x4), lzcnt(x.x5), lzcnt(x.x6), lzcnt(x.x7), lzcnt(x.x8), lzcnt(x.x9), lzcnt(x.x10), lzcnt(x.x11), lzcnt(x.x12), lzcnt(x.x13), lzcnt(x.x14), lzcnt(x.x15));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.byte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lzcnt(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzcnt_epi8(x);
            }
            else
            {
                return new byte32(lzcnt(x.v16_0), lzcnt(x.v16_16));
            }
        }


        /// <summary>       Returns number of leading zeros in the binary representation of an <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(0, 8)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte lzcnt(sbyte x)
        {
            return (sbyte)lzcnt((byte)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 lzcnt(sbyte2 x)
        {
            return (sbyte2)lzcnt((byte2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 lzcnt(sbyte3 x)
        {
            return (sbyte3)lzcnt((byte3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 lzcnt(sbyte4 x)
        {
            return (sbyte4)lzcnt((byte4)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 lzcnt(sbyte8 x)
        {
            return (sbyte8)lzcnt((byte8)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 lzcnt(sbyte16 x)
        {
            return (sbyte16)lzcnt((byte16)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 lzcnt(sbyte32 x)
        {
            return (sbyte32)lzcnt((byte32)x);
        }


        /// <summary>       Returns number of leading zeros in the binary representation of a <see cref="ushort"/>.    </summary>
        [return: AssumeRange(0ul, 16ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort lzcnt(ushort x)
        {
            return (ushort)math.max(math.lzcnt((uint)x) - 16, 0);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ushort2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lzcnt(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi16(x);
            }
            else
            {
                return new ushort2(lzcnt(x.x), lzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ushort3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lzcnt(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi16(x);
            }
            else
            {
                return new ushort3(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ushort4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lzcnt(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi16(x);
            }
            else
            {
                return new ushort4(lzcnt(x.x), lzcnt(x.y), lzcnt(x.z), lzcnt(x.w));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ushort8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lzcnt(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi16(x);
            }
            else
            {
                return new ushort8(lzcnt(x.x0), lzcnt(x.x1), lzcnt(x.x2), lzcnt(x.x3), lzcnt(x.x4), lzcnt(x.x5), lzcnt(x.x6), lzcnt(x.x7));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ushort16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lzcnt(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzcnt_epi16(x);
            }
            else
            {
                return new ushort16(lzcnt(x.v8_0), lzcnt(x.v8_8));
            }
        }


        /// <summary>       Returns number of leading zeros in the binary representation of a <see cref="short"/>.    </summary>
        [return: AssumeRange(0, 16)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short lzcnt(short x)
        {
            return (short)lzcnt((ushort)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 lzcnt(short2 x)
        {
            return (short2)lzcnt((ushort2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 lzcnt(short3 x)
        {
            return (short3)lzcnt((ushort3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 lzcnt(short4 x)
        {
            return (short4)lzcnt((ushort4)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 lzcnt(short8 x)
        {
            return (short8)lzcnt((ushort8)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 lzcnt(short16 x)
        {
            return (short16)lzcnt((ushort16)x);
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.uint8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 lzcnt(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzcnt_epi32(x);
            }
            else
            {
                return new int8(math.lzcnt(x.v4_0), math.lzcnt(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 lzcnt(int8 x)
        {
            return (int8)lzcnt((uint8)x);
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ulong2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lzcnt(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lzcnt_epi64(x);
            }
            else
            {
                return new ulong2((ulong)math.lzcnt(x.x), (ulong)math.lzcnt(x.y));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ulong3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lzcnt(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzcnt_epi64(x);
            }
            else
            {
                return new ulong3(lzcnt(x.xy), (ulong)math.lzcnt(x.z));
            }
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.ulong4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lzcnt(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lzcnt_epi64(x);
            }
            else
            {
                return new ulong4(lzcnt(x.xy), lzcnt(x.zw));
            }
        }


        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 lzcnt(long2 x)
        {
            return (long2)lzcnt((ulong2)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 lzcnt(long3 x)
        {
            return (long3)lzcnt((ulong3)x);
        }

        /// <summary>       Returns the componentwise number of leading zeros in the binary representations of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 lzcnt(long4 x)
        {
            return (long4)lzcnt((ulong4)x);
        }
    }
}