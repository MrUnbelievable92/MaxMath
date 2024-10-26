using System.Runtime.CompilerServices;
using Unity.Mathematics;
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
            public static v128 min_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.min_epi8(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_GE_EPI8(a, 0, elements) && constexpr.ALL_GE_EPI8(b, 0, elements))
                    {
                        return Sse2.min_epu8(a, b);
                    }
                    else
                    {
                        return blendv_si128(a, b, Sse2.cmpgt_epi8(a, b));
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vminq_s8(a, b);
                }
                else throw new IllegalInstructionException();
            }
            
		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 min_epi16(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.min_epi16(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vminq_s16(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 min_epi32(v128 a, v128 b)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.min_epi32(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(a, b, Sse2.cmpgt_epi32(a, b));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vminq_s32(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 min_epi64(v128 a, v128 b)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue) && constexpr.ALL_GE_EPI64(b, int.MinValue) && constexpr.ALL_LE_EPI64(a, int.MaxValue) && constexpr.ALL_LE_EPI64(b, int.MaxValue))
                    {
                        return min_epi32(a, b);
                    }

                    return blendv_si128(a, b, cmpgt_epi64(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_min_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue, elements) && constexpr.ALL_GE_EPI64(b, int.MinValue, elements) && constexpr.ALL_LE_EPI64(a, int.MaxValue, elements) && constexpr.ALL_LE_EPI64(b, int.MaxValue, elements))
                    {
                        return Avx2.mm256_min_epi32(a, b);
                    }

                    return mm256_blendv_si256(a, b, mm256_cmpgt_epi64(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }
            

		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 min_epu8(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.min_epu8(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vminq_u8(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 min_epu16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.min_epu16(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue, elements))
                    {
                        return Sse2.min_epi16(a, b);
                    }
                    else
                    {
                        ushort8 mask = 1 << 15;

                        return Sse2.xor_si128(mask,
                                              Sse2.min_epi16(Sse2.xor_si128(a, mask),
                                                             Sse2.xor_si128(b, mask)));
                    }
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vminq_u16(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 min_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.min_epu32(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(a, b, cmpgt_epu32(a, b, elements));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vminq_u32(a, b);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 min_epu64(v128 a, v128 b)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue) && constexpr.ALL_LE_EPU64(b, uint.MaxValue))
                    {
                        return min_epu32(a, b);
                    }

                    return blendv_si128(a, b, cmpgt_epu64(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_min_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements) && constexpr.ALL_LE_EPU64(b, uint.MaxValue, elements))
                    {
                        return Avx2.mm256_min_epu32(a, b);
                    }

                    return mm256_blendv_si256(a, b, mm256_cmpgt_epu64(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 min_pq(v128 a, v128 b, byte elements = 16, bool noNaNs = false, bool noZeros = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (noNaNs)
                    {
                        if (constexpr.ALL_EQ_EPU8(a, 0, elements) || constexpr.ALL_EQ_EPU8(a, 0b1000_0000, elements))
                        {
                            return and_si128(srai_epi8(b, 7), b);
                        }
                        if (constexpr.ALL_EQ_EPU8(b, 0, elements) || constexpr.ALL_EQ_EPU8(b, 0b1000_0000, elements))
                        {
                            return and_si128(srai_epi8(a, 7), a);
                        }
                    }

                    return blendv_si128(b, a, cmplt_pq(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros, elements: elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 min_ph(v128 a, v128 b, byte elements = 8, bool noNaNs = false, bool noZeros = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    return blendv_si128(b, a, cmplt_ph(a, b, promiseNeitherNaN: noNaNs, promiseNeitherZero: noZeros, elements: elements));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the minimum of two <see cref="UInt128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 min(UInt128 a, UInt128 b)
        {
            return select(b, a, a < b);
        }

        /// <summary>       Returns the minimum of two <see cref="Int128"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 min(Int128 a, Int128 b)
        {
            return select(b, a, a < b);
        }


        /// <summary>       Returns the minimum of two <see cref="byte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte min(byte a, byte b)
        {
            return a < b ? a : b;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.byte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 min(byte2 a, byte2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu8(a, b);
            }
            else
            {
                return new byte2(min(a.x, b.x), min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.byte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 min(byte3 a, byte3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu8(a, b);
            }
            else
            {
                return new byte3(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.byte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 min(byte4 a, byte4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu8(a, b);
            }
            else
            {
                return new byte4(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z), min(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.byte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 min(byte8 a, byte8 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu8(a, b);
            }
            else
            {
                return new byte8(min(a.x0, b.x0), min(a.x1, b.x1), min(a.x2, b.x2), min(a.x3, b.x3), min(a.x4, b.x4), min(a.x5, b.x5), min(a.x6, b.x6), min(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.byte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 min(byte16 a, byte16 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu8(a, b);
            }
            else
            {
                return new byte16(min(a.x0, b.x0), min(a.x1, b.x1), min(a.x2, b.x2), min(a.x3, b.x3), min(a.x4, b.x4), min(a.x5, b.x5), min(a.x6, b.x6), min(a.x7, b.x7), min(a.x8, b.x8), min(a.x9, b.x9), min(a.x10, b.x10), min(a.x11, b.x11), min(a.x12, b.x12), min(a.x13, b.x13), min(a.x14, b.x14), min(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.byte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 min(byte32 a, byte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epu8(a, b);
            }
            else
            {
                return new byte32(min(a.v16_0, b.v16_0), min(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the minimum of two <see cref="sbyte"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte min(sbyte a, sbyte b)
        {
            return a < b ? a : b;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 min(sbyte2 a, sbyte2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi8(a, b, 2);
            }
            else
            {
                return new sbyte2(min(a.x, b.x), min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 min(sbyte3 a, sbyte3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi8(a, b, 3);
            }
            else
            {
                return new sbyte3(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 min(sbyte4 a, sbyte4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi8(a, b, 4);
            }
            else
            {
                return new sbyte4(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z), min(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 min(sbyte8 a, sbyte8 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi8(a, b, 8);
            }
            else
            {
                return new sbyte8(min(a.x0, b.x0), min(a.x1, b.x1), min(a.x2, b.x2), min(a.x3, b.x3), min(a.x4, b.x4), min(a.x5, b.x5), min(a.x6, b.x6), min(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 min(sbyte16 a, sbyte16 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi8(a, b, 16);
            }
            else
            {
                return new sbyte16(min(a.x0, b.x0), min(a.x1, b.x1), min(a.x2, b.x2), min(a.x3, b.x3), min(a.x4, b.x4), min(a.x5, b.x5), min(a.x6, b.x6), min(a.x7, b.x7), min(a.x8, b.x8), min(a.x9, b.x9), min(a.x10, b.x10), min(a.x11, b.x11), min(a.x12, b.x12), min(a.x13, b.x13), min(a.x14, b.x14), min(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte32"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 min(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epi8(a, b);
            }
            else
            {
                return new sbyte32(min(a.v16_0, b.v16_0), min(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the minimum of two <see cref="ushort"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort min(ushort a, ushort b)
        {
            return a < b ? a : b;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ushort2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 min(ushort2 a, ushort2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu16(a, b, 2);
            }
            else
            {
                return new ushort2(min(a.x, b.x), min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ushort3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 min(ushort3 a, ushort3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu16(a, b, 3);
            }
            else
            {
                return new ushort3(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ushort4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 min(ushort4 a, ushort4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu16(a, b, 4);
            }
            else
            {
                return new ushort4(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z), min(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ushort8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 min(ushort8 a, ushort8 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu16(a, b, 8);
            }
            else
            {
                return new ushort8(min(a.x0, b.x0), min(a.x1, b.x1), min(a.x2, b.x2), min(a.x3, b.x3), min(a.x4, b.x4), min(a.x5, b.x5), min(a.x6, b.x6), min(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ushort16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 min(ushort16 a, ushort16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epu16(a, b);
            }
            else
            {
                return new ushort16(min(a.v8_0, b.v8_0), min(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the minimum of two <see cref="short"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short min(short a, short b)
        {
            return a < b ? a : b;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 min(short2 a, short2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi16(a, b);
            }
            else
            {
                return new short2(min(a.x, b.x), min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 min(short3 a, short3 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi16(a, b);
            }
            else
            {
                return new short3(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 min(short4 a, short4 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi16(a, b);
            }
            else
            {
                return new short4(min(a.x, b.x), min(a.y, b.y), min(a.z, b.z), min(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 min(short8 a, short8 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi16(a, b);
            }
            else
            {
                return new short8(min(a.x0, b.x0), min(a.x1, b.x1), min(a.x2, b.x2), min(a.x3, b.x3), min(a.x4, b.x4), min(a.x5, b.x5), min(a.x6, b.x6), min(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short16"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 min(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epi16(a, b);
            }
            else
            {
                return new short16(min(a.v8_0, b.v8_0), min(a.v8_8, b.v8_8));
            }
        }


        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.int8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 min(int8 a, int8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epi32(a, b);
            }
            else
            {
                return new int8(math.min(a.v4_0, b.v4_0), math.min(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.uint8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 min(uint8 a, uint8 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_min_epu32(a, b);
            }
            else
            {
                return new uint8(math.min(a.v4_0, b.v4_0), math.min(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ulong2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 min(ulong2 a, ulong2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epu64(a, b);
            }
            else
            {
                return new ulong2(math.min(a.x, b.x), math.min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ulong3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 min(ulong3 a, ulong3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_min_epu64(a, b, 3);
            }
            else
            {
                return new ulong3(min(a.xy, b.xy), math.min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.ulong4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 min(ulong4 a, ulong4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_min_epu64(a, b, 4);
            }
            else
            {
                return new ulong4(min(a.xy, b.xy), min(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.long2"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 min(long2 a, long2 b)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_epi64(a, b);
            }
            else
            {
                return new long2(math.min(a.x, b.x), math.min(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.long3"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 min(long3 a, long3 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_min_epi64(a, b, 3);
            }
            else
            {
                return new long3(min(a.xy, b.xy), math.min(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.long4"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 min(long4 a, long4 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_min_epi64(a, b, 4);
            }
            else
            {
                return new long4(min(a.xy, b.xy), min(a.zw, b.zw));
            }
        }


        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.float8"/>s.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 min(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_min_ps(a, b);
            }
            else
            {
                return new float8(math.min(a.v4_0, b.v4_0), math.min(a.v4_4, b.v4_4));
            }
        }


        /// <summary>       Returns the minimum of two <see cref="quarter"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter min(quarter a, quarter b, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0))
            {
                if (constexpr.IS_TRUE(a.IsZero))
                {
                    return asquarter((byte)(b.value & ((byte)((sbyte)b.value >> 31))));
                }
                if (constexpr.IS_TRUE(b.IsZero))
                {
                    return asquarter((byte)(a.value & ((byte)((sbyte)a.value >> 31))));
                }
            }
        
            return a.IsLessThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero)) ? a : b;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.quarter2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 min(quarter2 a, quarter2 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new quarter2(min(a.x, b.x, promises), min(a.y, b.y, promises));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.quarter3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 min(quarter3 a, quarter3 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new quarter3(min(a.x, b.x, promises), min(a.y, b.y, promises), min(a.z, b.z, promises));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.quarter4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 min(quarter4 a, quarter4 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new quarter4(min(a.x, b.x, promises), min(a.y, b.y, promises), min(a.z, b.z, promises), min(a.w, b.w, promises));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.quarter8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 min(quarter8 a, quarter8 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_pq(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new quarter8(min(a.x0, b.x0, promises),
                                    min(a.x1, b.x1, promises),
                                    min(a.x2, b.x2, promises),
                                    min(a.x3, b.x3, promises),
                                    min(a.x4, b.x4, promises),
                                    min(a.x5, b.x5, promises),
                                    min(a.x6, b.x6, promises),
                                    min(a.x7, b.x7, promises));
            }
        }


        /// <summary>       Returns the minimum of two <see cref="half"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if either <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half min(half a, half b, Promise promises = Promise.Nothing)
        {
            return a.IsLessThan(b, neitherNaN: promises.Promises(Promise.Unsafe0), neitherZero: promises.Promises(Promise.NonZero)) ? a : b;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="half2"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 min(half2 a, half2 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.min_ph(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 2));
            }
            else
            {
                return new half2(min(a.x, b.x, promises), min(a.y, b.y, promises));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="half3"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 min(half3 a, half3 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.min_ph(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 3));
            }
            else
            {
                return new half3(min(a.x, b.x, promises), min(a.y, b.y, promises), min(a.z, b.z, promises));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="half4"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 min(half4 a, half4 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.min_ph(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 4));
            }
            else
            {
                return new half4(min(a.x, b.x, promises), min(a.y, b.y, promises), min(a.z, b.z, promises), min(a.w, b.w, promises));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.half8"/>s.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results if any <paramref name="a"/> or <paramref name="b"/> is <see cref="half.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 min(half8 a, half8 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.min_ph(a, b, noNaNs: promises.Promises(Promise.Unsafe0), noZeros: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new half8(min(a.x0, b.x0, promises),
                                 min(a.x1, b.x1, promises),
                                 min(a.x2, b.x2, promises),
                                 min(a.x3, b.x3, promises),
                                 min(a.x4, b.x4, promises),
                                 min(a.x5, b.x5, promises),
                                 min(a.x6, b.x6, promises),
                                 min(a.x7, b.x7, promises));
            }
        }
    }
}