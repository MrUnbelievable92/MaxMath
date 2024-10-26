using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 subs_epu8(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.subs_epu8(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_u8(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }
		    
		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 subs_epu16(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.subs_epu16(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_u16(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 subs_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_u32(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU32(b, 1, elements))
                    {
                        return decs_epu32(a);
                    }


                    return andnot_si128(cmpge_epu32(b, a, elements), sub_epi32(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_subs_epu32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU32(b, 1))
                    {
                        return Avx2.mm256_add_epi32(a, mm256_not_si256(Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256())));
                    }


                    return Avx2.mm256_andnot_si256(mm256_cmpge_epu32(b, a), Avx2.mm256_sub_epi32(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 subs_epu64(v128 a, v128 b)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_u64(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPU64(b, 1))
                    {
                        return decs_epu64(a);
                    }


                    return andnot_si128(cmpgt_epu64(b, a), sub_epi64(a, b));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_subs_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPU64(b, 1, elements))
                    {
                        return Avx2.mm256_add_epi64(a, mm256_not_si256(Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256())));
                    }


                    return Avx2.mm256_andnot_si256(mm256_cmpgt_epu64(b, a), Avx2.mm256_sub_epi64(a, b));
                }
                else throw new IllegalInstructionException();
            }

            
		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 subs_epi8(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.subs_epi8(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_s8(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }
		    
		    [MethodImpl(MethodImplOptions.AggressiveInlining)]
		    public static v128 subs_epi16(v128 a, v128 b)
		    {
		    	if (Sse2.IsSse2Supported)
		    	{
		    		return Sse2.subs_epi16(a, b);
		    	}
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_s16(a, b);
                }
		    	else throw new IllegalInstructionException();
		    }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 subs_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_s32(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 MAX_VALUE = set1_epi32(int.MaxValue);


                    if (constexpr.ALL_EQ_EPI32(b, -1, elements))
                    {
                        return incs_epi32(a);
                    }
                    if (constexpr.ALL_EQ_EPI32(b, 1, elements))
                    {
                        return add_epi32(a, cmpgt_epi32(a, set1_epi32(int.MinValue)));
                    }


                    v128 result = sub_epi32(a, b);
                    v128 overflow = add_epi32(MAX_VALUE, srli_epi32(a, 31));
                    v128 selectOverflow = ternarylogic_si128(overflow, b, result, TernaryOperation.Ox18);

                    return blendv_ps(result, overflow, selectOverflow);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_subs_epi32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MAX_VALUE = mm256_set1_epi32(int.MaxValue);


                    if (constexpr.ALL_EQ_EPI32(b, -1))
                    {
                        return mm256_incs_epi32(a);
                    }
                    if (constexpr.ALL_EQ_EPI32(b, 1))
                    {
                        return Avx2.mm256_add_epi32(a, Avx2.mm256_cmpgt_epi32(a, mm256_set1_epi32(int.MinValue)));
                    }


                    v256 result = Avx2.mm256_sub_epi32(a, b);
                    v256 overflow = Avx2.mm256_add_epi32(MAX_VALUE, Avx2.mm256_srli_epi32(a, 31));
                    v256 selectOverflow = mm256_ternarylogic_si256(overflow, b, result, TernaryOperation.Ox18);

                    return Avx.mm256_blendv_ps(result, overflow, selectOverflow);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 subs_epi64(v128 a, v128 b)
            {
                if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vqsubq_s64(a, b);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 MAX_VALUE = set1_epi64x(long.MaxValue);


                    if (constexpr.ALL_EQ_EPI64(b, -1))
                    {
                        return incs_epi64(a);
                    }
                    if (constexpr.ALL_EQ_EPI64(b, 1))
                    {
                        return add_epi64(a, cmpgt_epi64(a, set1_epi64x(long.MinValue)));
                    }


                    v128 result = sub_epi64(a, b);
                    v128 overflow = add_epi64(MAX_VALUE, srli_epi64(a, 63));
                    v128 selectOverflow = ternarylogic_si128(overflow, b, result, TernaryOperation.Ox18);

                    return blendv_pd(result, overflow, selectOverflow);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_subs_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MAX_VALUE = mm256_set1_epi64x(long.MaxValue);


                    if (constexpr.ALL_EQ_EPI64(b, -1, elements))
                    {
                        return mm256_incs_epi64(a);
                    }
                    if (constexpr.ALL_EQ_EPI64(b, 1, elements))
                    {
                        return Avx2.mm256_add_epi64(a, Avx2.mm256_cmpgt_epi64(a, mm256_set1_epi64x(long.MinValue)));
                    }


                    v256 result = Avx2.mm256_sub_epi64(a, b);
                    v256 overflow = Avx2.mm256_add_epi64(MAX_VALUE, Avx2.mm256_srli_epi64(a, 63));
                    v256 selectOverflow = mm256_ternarylogic_si256(overflow, b, result, TernaryOperation.Ox18);

                    return Avx.mm256_blendv_pd(result, overflow, selectOverflow);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="Int128.MaxValue"/> if overflow occurs or <see cref="Int128.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 subsaturated(Int128 x, Int128 y)
        {
            if (constexpr.IS_TRUE(y == 1))
            {
                return nextsmaller(x);
            }

	        Int128 res = x - y;
	        Int128 overflow = (x.hi64 >> 63) + Int128.MaxValue;

	        if ((long)((overflow ^ y) & (overflow ^ res)).hi64 < 0)
	        {
	        	res = overflow;
	        }

	        return res;
        }

        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="UInt128.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 subsaturated(UInt128 x, UInt128 y)
        {
            return y >= x ? 0 : x - y;
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="byte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte subsaturated(byte x, byte y)
        {
            if (constexpr.IS_TRUE(y == 1))
            {
                return nextsmaller(x);
            }

            return (byte)(y >= x ? 0 : x - y);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="byte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 subsaturated(byte2 x, byte2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu8(x, y);
            }
            else
            {
                return new byte2(subsaturated(x.x, y.x),
                                 subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="byte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 subsaturated(byte3 x, byte3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu8(x, y);
            }
            else
            {
                return new byte3(subsaturated(x.x, y.x),
                                 subsaturated(x.y, y.y),
                                 subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="byte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 subsaturated(byte4 x, byte4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu8(x, y);
            }
            else
            {
                return new byte4(subsaturated(x.x, y.x),
                                 subsaturated(x.y, y.y),
                                 subsaturated(x.z, y.z),
                                 subsaturated(x.w, y.w));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="byte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 subsaturated(byte8 x, byte8 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu8(x, y);
            }
            else
            {
                return new byte8(subsaturated(x.x0, y.x0),
                                 subsaturated(x.x1, y.x1),
                                 subsaturated(x.x2, y.x2),
                                 subsaturated(x.x3, y.x3),
                                 subsaturated(x.x4, y.x4),
                                 subsaturated(x.x5, y.x5),
                                 subsaturated(x.x6, y.x6),
                                 subsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="byte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 subsaturated(byte16 x, byte16 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu8(x, y);
            }
            else
            {
                return new byte16(subsaturated(x.x0, y.x0),
                                  subsaturated(x.x1, y.x1),
                                  subsaturated(x.x2, y.x2),
                                  subsaturated(x.x3, y.x3),
                                  subsaturated(x.x4, y.x4),
                                  subsaturated(x.x5, y.x5),
                                  subsaturated(x.x6, y.x6),
                                  subsaturated(x.x7, y.x7),
                                  subsaturated(x.x8, y.x8),
                                  subsaturated(x.x9, y.x9),
                                  subsaturated(x.x10, y.x10),
                                  subsaturated(x.x11, y.x11),
                                  subsaturated(x.x12, y.x12),
                                  subsaturated(x.x13, y.x13),
                                  subsaturated(x.x14, y.x14),
                                  subsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="byte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 subsaturated(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epu8(x, y);
            }
            else
            {
                return new byte32(subsaturated(x.v16_0, y.v16_0),
                                  subsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="ushort.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort subsaturated(ushort x, ushort y)
        {
            if (constexpr.IS_TRUE(y == 1))
            {
                return nextsmaller(x);
            }

            return (ushort)(y >= x ? 0 : x - y);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ushort.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 subsaturated(ushort2 x, ushort2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu16(x, y);
            }
            else
            {
                return new ushort2(subsaturated(x.x, y.x),
                                   subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ushort.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 subsaturated(ushort3 x, ushort3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu16(x, y);
            }
            else
            {
                return new ushort3(subsaturated(x.x, y.x),
                                   subsaturated(x.y, y.y),
                                   subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ushort.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 subsaturated(ushort4 x, ushort4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu16(x, y);
            }
            else
            {
                return new ushort4(subsaturated(x.x, y.x),
                                   subsaturated(x.y, y.y),
                                   subsaturated(x.z, y.z),
                                   subsaturated(x.w, y.w));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ushort.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 subsaturated(ushort8 x, ushort8 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu16(x, y);
            }
            else
            {
                return new ushort8(subsaturated(x.x0, y.x0),
                                   subsaturated(x.x1, y.x1),
                                   subsaturated(x.x2, y.x2),
                                   subsaturated(x.x3, y.x3),
                                   subsaturated(x.x4, y.x4),
                                   subsaturated(x.x5, y.x5),
                                   subsaturated(x.x6, y.x6),
                                   subsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ushort.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 subsaturated(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epu16(x, y);
            }
            else
            {
                return new ushort16(subsaturated(x.v8_0, y.v8_0),
                                    subsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="uint.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint subsaturated(uint x, uint y)
        {
            if (constexpr.IS_TRUE(y == 1))
            {
                return nextsmaller(x);
            }

            return y >= x ? 0 : x - y;
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="uint.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 subsaturated(uint2 x, uint2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.subs_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                return new uint2(subsaturated(x.x, y.x),
                                 subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="uint.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 subsaturated(uint3 x, uint3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.subs_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                return new uint3(subsaturated(x.x, y.x),
                                 subsaturated(x.y, y.y),
                                 subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="uint.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 subsaturated(uint4 x, uint4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.subs_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                return new uint4(subsaturated(x.x, y.x),
                                 subsaturated(x.y, y.y),
                                 subsaturated(x.z, y.z),
                                 subsaturated(x.w, y.w));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="uint.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 subsaturated(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_subs_epu32(x, y);
            }
            else
            {
                return new uint8(subsaturated(x.v4_0, y.v4_0),
                                 subsaturated(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="ulong.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong subsaturated(ulong x, ulong y)
        {
            if (constexpr.IS_TRUE(y == 1))
            {
                return nextsmaller(x);
            }

            return y >= x ? 0 : x - y;
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ulong.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 subsaturated(ulong2 x, ulong2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epu64(x, y);
            }
            else
            {
                return new ulong2(subsaturated(x.x, y.x),
                                  subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ulong.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 subsaturated(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_subs_epu64(x, y, 3);
            }
            else
            {
                return new ulong3(subsaturated(x.xy, y.xy),
                                  subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="ulong.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 subsaturated(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_subs_epu64(x, y, 4);
            }
            else
            {
                return new ulong4(subsaturated(x.xy, y.xy),
                                  subsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte subsaturated(sbyte x, sbyte y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = Xse.cvtsi32_si128((byte)x);
                v128 _y = Xse.cvtsi32_si128((byte)y);

                v128 difference = Xse.subs_epi8(_x, _y);

                return (sbyte)Xse.cvtsi128_si32(difference);
            }
            else
            {
                return (sbyte)math.clamp(x - y, sbyte.MinValue, sbyte.MaxValue);
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 subsaturated(sbyte2 x, sbyte2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi8(x, y);
            }
            else
            {
                return new sbyte2(subsaturated(x.x, y.x),
                                  subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 subsaturated(sbyte3 x, sbyte3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi8(x, y);
            }
            else
            {
                return new sbyte3(subsaturated(x.x, y.x),
                                  subsaturated(x.y, y.y),
                                  subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 subsaturated(sbyte4 x, sbyte4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi8(x, y);
            }
            else
            {
                return new sbyte4(subsaturated(x.x, y.x),
                                  subsaturated(x.y, y.y),
                                  subsaturated(x.z, y.z),
                                  subsaturated(x.w, y.w));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 subsaturated(sbyte8 x, sbyte8 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi8(x, y);
            }
            else
            {
                return new sbyte8(subsaturated(x.x0, y.x0),
                                  subsaturated(x.x1, y.x1),
                                  subsaturated(x.x2, y.x2),
                                  subsaturated(x.x3, y.x3),
                                  subsaturated(x.x4, y.x4),
                                  subsaturated(x.x5, y.x5),
                                  subsaturated(x.x6, y.x6),
                                  subsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 subsaturated(sbyte16 x, sbyte16 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi8(x, y);
            }
            else
            {
                return new sbyte16(subsaturated(x.x0, y.x0),
                                   subsaturated(x.x1, y.x1),
                                   subsaturated(x.x2, y.x2),
                                   subsaturated(x.x3, y.x3),
                                   subsaturated(x.x4, y.x4),
                                   subsaturated(x.x5, y.x5),
                                   subsaturated(x.x6, y.x6),
                                   subsaturated(x.x7, y.x7),
                                   subsaturated(x.x8, y.x8),
                                   subsaturated(x.x9, y.x9),
                                   subsaturated(x.x10, y.x10),
                                   subsaturated(x.x11, y.x11),
                                   subsaturated(x.x12, y.x12),
                                   subsaturated(x.x13, y.x13),
                                   subsaturated(x.x14, y.x14),
                                   subsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 subsaturated(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epi8(x, y);
            }
            else
            {
                return new sbyte32(subsaturated(x.v16_0, y.v16_0),
                                   subsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short subsaturated(short x, short y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 _x = Xse.cvtsi32_si128((ushort)x);
                v128 _y = Xse.cvtsi32_si128((ushort)y);

                v128 difference = Xse.subs_epi16(_x, _y);

                return (short)Xse.cvtsi128_si32(difference);
            }
            else
            {
                return (short)math.clamp(x - y, short.MinValue, short.MaxValue);
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 subsaturated(short2 x, short2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi16(x, y);
            }
            else
            {
                return new short2(subsaturated(x.x, y.x),
                                  subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 subsaturated(short3 x, short3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi16(x, y);
            }
            else
            {
                return new short3(subsaturated(x.x, y.x),
                                  subsaturated(x.y, y.y),
                                  subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 subsaturated(short4 x, short4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi16(x, y);
            }
            else
            {
                return new short4(subsaturated(x.x, y.x),
                                  subsaturated(x.y, y.y),
                                  subsaturated(x.z, y.z),
                                  subsaturated(x.w, y.w));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 subsaturated(short8 x, short8 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi16(x, y);
            }
            else
            {
                return new short8(subsaturated(x.x0, y.x0),
                                  subsaturated(x.x1, y.x1),
                                  subsaturated(x.x2, y.x2),
                                  subsaturated(x.x3, y.x3),
                                  subsaturated(x.x4, y.x4),
                                  subsaturated(x.x5, y.x5),
                                  subsaturated(x.x6, y.x6),
                                  subsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 subsaturated(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epi16(x, y);
            }
            else
            {
                return new short16(subsaturated(x.v8_0, y.v8_0),
                                   subsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int subsaturated(int x, int y)
        {
            if (Arm.Neon.IsNeonSupported)
            {
                v128 _x = Xse.cvtsi32_si128(x);
                v128 _y = Xse.cvtsi32_si128(y);

                v128 difference = Xse.subs_epi32(_x, _y);

                return Xse.cvtsi128_si32(difference);
            }
            else
            {
                return (int)math.clamp((long)x - (long)y, int.MinValue, int.MaxValue);
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 subsaturated(int2 x, int2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.subs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                return new int2(subsaturated(x.x, y.x),
                                subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 subsaturated(int3 x, int3 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.subs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                return new int3(subsaturated(x.x, y.x),
                                subsaturated(x.y, y.y),
                                subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 subsaturated(int4 x, int4 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.subs_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                return new int4(subsaturated(x.x, y.x),
                                subsaturated(x.y, y.y),
                                subsaturated(x.z, y.z),
                                subsaturated(x.w, y.w));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 subsaturated(int8 x, int8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_subs_epi32(x, y);
            }
            else
            {
                return new int8(subsaturated(x.v4_0, y.v4_0),
                                subsaturated(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long subsaturated(long x, long y)
        {
	        long result = x - y;
	        long overflow = (long)((ulong)x >> 63) + long.MaxValue;

	        if (((overflow ^ y) & (overflow ^ result)) < 0)
	        {
	        	result = overflow;
	        }

	        return result;
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 subsaturated(long2 x, long2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.subs_epi64(x, y);
            }
            else
            {
                return new long2(subsaturated(x.x, y.x),
                                 subsaturated(x.y, y.y));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 subsaturated(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_subs_epi64(x, y, 3);
            }
            else
            {
                return new long3(subsaturated(x.xy, y.xy),
                                 subsaturated(x.z, y.z));
            }
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component of <paramref name="x"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 subsaturated(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_subs_epi64(x, y, 4);
            }
            else
            {
                return new long4(subsaturated(x.xy, y.xy),
                                 subsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Subtracts <paramref name="y"/> from <paramref name=x"/> and returns the result, which is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float subsaturated(float x, float y)
        {
            return math.clamp(x - y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component <paramref name="x"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 subsaturated(float2 x, float2 y)
        {
            return math.clamp(x - y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component <paramref name="x"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 subsaturated(float3 x, float3 y)
        {
            return math.clamp(x - y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component <paramref name="x"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 subsaturated(float4 x, float4 y)
        {
            return math.clamp(x - y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component <paramref name="x"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 subsaturated(float8 x, float8 y)
        {
            return clamp(x - y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Subtracts <paramref name="y"/> from <paramref name="x"/> and returns the result, which is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double subsaturated(double x, double y)
        {
            return math.clamp(x - y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component <paramref name="x"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 subsaturated(double2 x, double2 y)
        {
            return math.clamp(x - y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component <paramref name="x"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 subsaturated(double3 x, double3 y)
        {
            return math.clamp(x - y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Subtracts each component of <paramref name="y"/> from each component <paramref name="x"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 subsaturated(double4 x, double4 y)
        {
            return math.clamp(x - y, double.MinValue, double.MaxValue);
        }
    }
}