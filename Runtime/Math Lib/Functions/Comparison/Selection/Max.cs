using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epi8(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_GE_EPI8(a, 0, elements) && constexpr.ALL_GE_EPI8(b, 0, elements))
                    {
                        return max_epu8(a, b);
                    }
                    else
                    {
                        return blendv_si128(a, b, cmpgt_epi8(b, a));
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vmaxq_s8(a, b);
                }
                else throw new IllegalInstructionException();
            }

		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 max_epi16(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.max_epi16(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vmaxq_s16(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epi32(v128 a, v128 b)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epi32(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(a, b, cmpgt_epi32(b, a));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vmaxq_s32(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epi64(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue) && constexpr.ALL_GE_EPI64(b, int.MinValue) && constexpr.ALL_LE_EPI64(a, int.MaxValue) && constexpr.ALL_LE_EPI64(b, int.MaxValue))
                    {
                        return max_epi32(a, b);
                    }

                    return blendv_si128(a, b, cmpgt_epi64(b, a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_max_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue, elements) && constexpr.ALL_GE_EPI64(b, int.MinValue, elements) && constexpr.ALL_LE_EPI64(a, int.MaxValue, elements) && constexpr.ALL_LE_EPI64(b, int.MaxValue, elements))
                    {
                        return Avx2.mm256_max_epi32(a, b);
                    }

                    return mm256_blendv_si256(a, b, Avx2.mm256_cmpgt_epi64(b, a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epu8(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.max_epu8(a, b);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vmaxq_u8(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epu16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epu16(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue, elements))
                    {
                        return max_epi16(a, b);
                    }
                    else
                    {
                        ushort8 mask = 1 << 15;

                        return xor_si128(mask,
                                         max_epi16(xor_si128(a, mask),
                                                   xor_si128(b, mask)));
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vmaxq_u16(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.max_epu32(b, a);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(a, b, cmpgt_epu32(b, a, elements));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vmaxq_u32(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_epu64(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue) && constexpr.ALL_LE_EPU64(b, uint.MaxValue))
                    {
                        return max_epu32(a, b);
                    }

                    return blendv_si128(a, b, cmpgt_epu64(b, a));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_max_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements) && constexpr.ALL_LE_EPU64(b, uint.MaxValue, elements))
                    {
                        return Avx2.mm256_max_epu32(a, b);
                    }

                    return mm256_blendv_si256(a, b, mm256_cmpgt_epu64(b, a));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_pq(v128 a, v128 b, byte elements = 16, bool noNaNs = false, bool noZeros = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (noNaNs)
                    {
                        if (constexpr.ALL_EQ_EPU8(a, 0, elements) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                        {
                            return andnot_si128(srai_epi8(b, 7), b);
                        }
                        if (constexpr.ALL_EQ_EPU8(b, 0, elements) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                        {
                            return andnot_si128(srai_epi8(a, 7), a);
                        }
                    }

                    return blendv_si128(a, b, cmplt_pq(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros, elements: elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_max_pq(v256 a, v256 b, bool noNaNs = false, bool noZeros = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (noNaNs)
                    {
                        if (constexpr.ALL_EQ_EPU8(a, 0) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000))
                        {
                            return Avx2.mm256_andnot_si256(mm256_srai_epi8(b, 7), b);
                        }
                        if (constexpr.ALL_EQ_EPU8(b, 0) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000))
                        {
                            return Avx2.mm256_andnot_si256(mm256_srai_epi8(a, 7), a);
                        }
                    }

                    return mm256_blendv_si256(a, b, mm256_cmplt_pq(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 max_ph(v128 a, v128 b, byte elements = 8, bool noNaNs = false, bool noZeros = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (noNaNs)
                    {
                        if (constexpr.ALL_EQ_EPU16(a, 0, elements) || constexpr.ALL_EQ_EPU16(a, 0x8000, elements))
                        {
                            return andnot_si128(srai_epi16(b, 15), b);
                        }
                        if (constexpr.ALL_EQ_EPU16(b, 0, elements) || constexpr.ALL_EQ_EPU16(b, 0x8000, elements))
                        {
                            return andnot_si128(srai_epi16(a, 15), a);
                        }
                    }

                    return blendv_si128(a, b, cmplt_ph(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros, elements: elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_max_ph(v256 a, v256 b, bool noNaNs = false, bool noZeros = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (noNaNs)
                    {
                        if (constexpr.ALL_EQ_EPU16(a, 0) || constexpr.ALL_EQ_EPU16(a, 0x8000))
                        {
                            return Avx2.mm256_andnot_si256(mm256_srai_epi16(b, 15), b);
                        }
                        if (constexpr.ALL_EQ_EPU16(b, 0) || constexpr.ALL_EQ_EPU16(b, 0x8000))
                        {
                            return Avx2.mm256_andnot_si256(mm256_srai_epi16(a, 15), a);
                        }
                    }

                    return mm256_blendv_si256(a, b, mm256_cmplt_ph(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns the maximum of two <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 max(UInt128 a, UInt128 b)
        {
            return select(b, a, a > b);
        }

        /// <summary>       Returns the maximum of two <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 max(Int128 a, Int128 b)
        {
            return select(b, a, a > b);
        }


        /// <summary>       Returns the maximum of two <see cref="byte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte max(byte a, byte b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 max(byte2 a, byte2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu8(a, b);
            }
            else
            {
                return new byte2(max(a.x, b.x), max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 max(byte3 a, byte3 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu8(a, b);
            }
            else
            {
                return new byte3(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 max(byte4 a, byte4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu8(a, b);
            }
            else
            {
                return new byte4(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z), max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 max(byte8 a, byte8 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu8(a, b);
            }
            else
            {
                return new byte8(max(a.x0, b.x0), max(a.x1, b.x1), max(a.x2, b.x2), max(a.x3, b.x3), max(a.x4, b.x4), max(a.x5, b.x5), max(a.x6, b.x6), max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 max(byte16 a, byte16 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu8(a, b);
            }
            else
            {
                return new byte16(max(a.x0, b.x0), max(a.x1, b.x1), max(a.x2, b.x2), max(a.x3, b.x3), max(a.x4, b.x4), max(a.x5, b.x5), max(a.x6, b.x6), max(a.x7, b.x7), max(a.x8, b.x8), max(a.x9, b.x9), max(a.x10, b.x10), max(a.x11, b.x11), max(a.x12, b.x12), max(a.x13, b.x13), max(a.x14, b.x14), max(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 max(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu8(a, b);
            }
            else
            {
                return new byte32(max(a.v16_0, b.v16_0), max(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="sbyte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte max(sbyte a, sbyte b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 max(sbyte2 a, sbyte2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi8(a, b, 2);
            }
            else
            {
                return new sbyte2(max(a.x, b.x), max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 max(sbyte3 a, sbyte3 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi8(a, b, 3);
            }
            else
            {
                return new sbyte3(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 max(sbyte4 a, sbyte4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi8(a, b, 4);
            }
            else
            {
                return new sbyte4(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z), max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 max(sbyte8 a, sbyte8 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi8(a, b, 8);
            }
            else
            {
                return new sbyte8(max(a.x0, b.x0), max(a.x1, b.x1), max(a.x2, b.x2), max(a.x3, b.x3), max(a.x4, b.x4), max(a.x5, b.x5), max(a.x6, b.x6), max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 max(sbyte16 a, sbyte16 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi8(a, b, 16);
            }
            else
            {
                return new sbyte16(max(a.x0, b.x0), max(a.x1, b.x1), max(a.x2, b.x2), max(a.x3, b.x3), max(a.x4, b.x4), max(a.x5, b.x5), max(a.x6, b.x6), max(a.x7, b.x7), max(a.x8, b.x8), max(a.x9, b.x9), max(a.x10, b.x10), max(a.x11, b.x11), max(a.x12, b.x12), max(a.x13, b.x13), max(a.x14, b.x14), max(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 max(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi8(a, b);
            }
            else
            {
                return new sbyte32(max(a.v16_0, b.v16_0), max(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="ushort"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort max(ushort a, ushort b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 max(ushort2 a, ushort2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu16(a, b, 2);
            }
            else
            {
                return new ushort2(max(a.x, b.x), max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 max(ushort3 a, ushort3 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu16(a, b, 3);
            }
            else
            {
                return new ushort3(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 max(ushort4 a, ushort4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu16(a, b, 4);
            }
            else
            {
                return new ushort4(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z), max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 max(ushort8 a, ushort8 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu16(a, b, 8);
            }
            else
            {
                return new ushort8(max(a.x0, b.x0), max(a.x1, b.x1), max(a.x2, b.x2), max(a.x3, b.x3), max(a.x4, b.x4), max(a.x5, b.x5), max(a.x6, b.x6), max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 max(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu16(a, b);
            }
            else
            {
                return new ushort16(max(a.v8_0, b.v8_0), max(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="short"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short max(short a, short b)
        {
            return a > b ? a : b;
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 max(short2 a, short2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi16(a, b);
            }
            else
            {
                return new short2(max(a.x, b.x), max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 max(short3 a, short3 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi16(a, b);
            }
            else
            {
                return new short3(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 max(short4 a, short4 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi16(a, b);
            }
            else
            {
                return new short4(max(a.x, b.x), max(a.y, b.y), max(a.z, b.z), max(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 max(short8 a, short8 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi16(a, b);
            }
            else
            {
                return new short8(max(a.x0, b.x0), max(a.x1, b.x1), max(a.x2, b.x2), max(a.x3, b.x3), max(a.x4, b.x4), max(a.x5, b.x5), max(a.x6, b.x6), max(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 max(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi16(a, b);
            }
            else
            {
                return new short16(max(a.v8_0, b.v8_0), max(a.v8_8, b.v8_8));
            }
        }

        
        /// <summary>       Returns the maximum of two <see cref="int"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int max(int a, int b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.int2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 max(int2 a, int2 b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.int3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 max(int3 a, int3 b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.int4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 max(int4 a, int4 b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 max(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epi32(a, b);
            }
            else
            {
                return new int8(max(a.v4_0, b.v4_0), max(a.v4_4, b.v4_4));
            }
        }

        
        /// <summary>       Returns the maximum of two <see cref="uint"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint max(uint a, uint b)
        {
            return Unity.Mathematics.math.max(a, b);
        }
        
        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.uint2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 max(uint2 a, uint2 b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.uint3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 max(uint3 a, uint3 b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.uint4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 max(uint4 a, uint4 b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 max(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_max_epu32(a, b);
            }
            else
            {
                return new uint8(max(a.v4_0, b.v4_0), max(a.v4_4, b.v4_4));
            }
        }

        
        /// <summary>       Returns the maximum of two <see cref="ulong"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong max(ulong a, ulong b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 max(ulong2 a, ulong2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epu64(a, b);
            }
            else
            {
                return new ulong2(max(a.x, b.x), max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 max(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epu64(a, b, 3);
            }
            else
            {
                return new ulong3(max(a.xy, b.xy), max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 max(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epu64(a, b, 4);
            }
            else
            {
                return new ulong4(max(a.xy, b.xy), max(a.zw, b.zw));
            }
        }

        
        /// <summary>       Returns the maximum of two <see cref="long"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long max(long a, long b)
        {
            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 max(long2 a, long2 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.max_epi64(a, b);
            }
            else
            {
                return new long2(max(a.x, b.x), max(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 max(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epi64(a, b, 3);
            }
            else
            {
                return new long3(max(a.xy, b.xy), max(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 max(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_max_epi64(a, b, 4);
            }
            else
            {
                return new long4(max(a.xy, b.xy), max(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="MaxMath.quarter"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter max(quarter a, quarter b, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0))
            {
                if (constexpr.IS_TRUE(a.IsZero))
                {
                    return asquarter(andnot(b.value, (byte)((sbyte)b.value >> 31)));
                }
                if (constexpr.IS_TRUE(b.IsZero))
                {
                    return asquarter(andnot(a.value, (byte)((sbyte)a.value >> 31)));
                }
            }

            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                return a.IsGreaterThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero)) ? a : b;
            }
            else
            {
                return (isnan(b) | a.IsGreaterThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero))) ? a : b;
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.quarter2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 max(quarter2 a, quarter2 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                quarter2 result = Xse.max_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 2);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new quarter2(max(a.x, b.x, promises), max(a.y, b.y, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.quarter3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 max(quarter3 a, quarter3 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                quarter3 result = Xse.max_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 3);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new quarter3(max(a.x, b.x, promises), max(a.y, b.y, promises), max(a.z, b.z, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.quarter4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 max(quarter4 a, quarter4 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                quarter4 result = Xse.max_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 4);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new quarter4(max(a.x, b.x, promises), max(a.y, b.y, promises), max(a.z, b.z, promises), max(a.w, b.w, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.quarter8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 max(quarter8 a, quarter8 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                quarter8 result = Xse.max_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 8);
                
                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new quarter8(max(a.x0, b.x0, promises),
                                    max(a.x1, b.x1, promises),
                                    max(a.x2, b.x2, promises),
                                    max(a.x3, b.x3, promises),
                                    max(a.x4, b.x4, promises),
                                    max(a.x5, b.x5, promises),
                                    max(a.x6, b.x6, promises),
                                    max(a.x7, b.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.quarter16"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 max(quarter16 a, quarter16 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                quarter16 result = Xse.max_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero));

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new quarter16(max(a.x0,  b.x0,  promises),
                                     max(a.x1,  b.x1,  promises),
                                     max(a.x2,  b.x2,  promises),
                                     max(a.x3,  b.x3,  promises),
                                     max(a.x4,  b.x4,  promises),
                                     max(a.x5,  b.x5,  promises),
                                     max(a.x6,  b.x6,  promises),
                                     max(a.x7,  b.x7,  promises),
                                     max(a.x8,  b.x8,  promises),
                                     max(a.x9,  b.x9,  promises),
                                     max(a.x10, b.x10, promises),
                                     max(a.x11, b.x11, promises),
                                     max(a.x12, b.x12, promises),
                                     max(a.x13, b.x13, promises),
                                     max(a.x14, b.x14, promises),
                                     max(a.x15, b.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.quarter32"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 max(quarter32 a, quarter32 b, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                quarter32 result = Xse.mm256_max_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero));

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new quarter32(max(a.v16_0, b.v16_0, promises), max(a.v16_16, b.v16_16, promises));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="MaxMath.half"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half max(half a, half b, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0))
            {
                if (constexpr.IS_TRUE(a.IsZero))
                {
                    return ashalf(andnot(b.value, (ushort)((short)b.value >> 31)));
                }
                if (constexpr.IS_TRUE(b.IsZero))
                {
                    return ashalf(andnot(a.value, (ushort)((short)a.value >> 31)));
                }
            }

            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                return a.IsGreaterThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero)) ? a : b;
            }
            else
            {
                return (isnan(b) | a.IsGreaterThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero))) ? a : b;
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.half2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 max(half2 a, half2 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                half2 result = Xse.max_ph(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 2);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new half2(max(a.x, b.x, promises), max(a.y, b.y, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.half3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 max(half3 a, half3 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                half3 result = Xse.max_ph(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 3);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new half3(max(a.x, b.x, promises), max(a.y, b.y, promises), max(a.z, b.z, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.half4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 max(half4 a, half4 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                half4 result = Xse.max_ph(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 4);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new half4(max(a.x, b.x, promises), max(a.y, b.y, promises), max(a.z, b.z, promises), max(a.w, b.w, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.half8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 max(half8 a, half8 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                half8 result = Xse.max_ph(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 8);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new half8(max(a.x0, b.x0, promises),
                                 max(a.x1, b.x1, promises),
                                 max(a.x2, b.x2, promises),
                                 max(a.x3, b.x3, promises),
                                 max(a.x4, b.x4, promises),
                                 max(a.x5, b.x5, promises),
                                 max(a.x6, b.x6, promises),
                                 max(a.x7, b.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.half16"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="MaxMath.half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 max(half16 a, half16 b, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                half16 result = Xse.mm256_max_ph(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero));

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new half16(max(a.v8_0, b.v8_0, promises), max(a.v8_8, b.v8_8, promises));
            }
        }


        /// <summary>       Returns the maximum of two <see cref="float"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float max(float a, float b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                return a > b ? a : b;
            }

            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.float2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 max(float2 a, float2 b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.max_ps(a, b);
                }
            }

            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.float3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 max(float3 a, float3 b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.max_ps(a, b);
                }
            }

            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.float4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 max(float4 a, float4 b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.max_ps(a, b);
                }
            }

            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.float8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 max(float8 a, float8 b, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                float8 result = Avx.mm256_max_ps(a, b);

                if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN
                   || promises.Promises(Promise.Unsafe0)))
                {
                    result = select(result, a, isnan(b));
                }

                return result;
            }
            else
            {
                return new float8(max(a.v4_0, b.v4_0, promises), max(a.v4_4, b.v4_4, promises));
            }
        }

        
        /// <summary>       Returns the maximum of two <see cref="double"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double max(double a, double b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                return a > b ? a : b;
            }

            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.double2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 max(double2 a, double2 b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.max_pd(a, b);
                }
            }

            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.double3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 max(double3 a, double3 b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_max_pd(a, b);
                }
                else
                {
                    return new double3(max(a.xy, b.xy, promises), max(a.z, b.z, promises));
                }
            }

            return Unity.Mathematics.math.max(a, b);
        }

        /// <summary>       Returns the componentwise maximum of two <see cref="MaxMath.double4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 max(double4 a, double4 b, Promise promises = Promise.Nothing)
        {
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             || promises.Promises(Promise.Unsafe0))
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_max_pd(a, b);
                }
                else
                {
                    return new double4(max(a.xy, b.xy, promises), max(a.zw, b.zw, promises));
                }
            }

            return Unity.Mathematics.math.max(a, b);
        }
    }
}