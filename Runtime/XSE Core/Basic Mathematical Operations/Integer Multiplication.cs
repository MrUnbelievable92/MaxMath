using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mullo_epi8(v128 a, v128 b, byte elements = 16, bool orderMatters = true)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPI8(a, b, elements))
                {
                    return square_epi8(a, elements, orderMatters);
                }

                return impl_mullo_epi8(a, b, elements, orderMatters);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mullo_epi8(v256 a, v256 b, bool orderMatters = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPI8(a, b))
                {
                    return mm256_square_epi8(a, orderMatters);
                }

                return mm256_impl_mullo_epi8(a, b, orderMatters);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epu8(v128 a, v128 b, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result;

                if (Ssse3.IsSsse3Supported)
                {
                    if (elements <= 8)
                    {
                        v128 full = mullo_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b));
                        result = shuffle_epi8(full, new v128(1, 3, 5, 7, 9, 11, 13, 15,   -1, -1, -1, -1, -1, -1, -1, -1));

                        goto RET;
                    }
                }

                v128 MASK = new v128(0xFF00_FF00);

                v128 even = mullo_epi16(andnot_si128(MASK, a), andnot_si128(MASK, b));
                v128 odd = mullo_epi16(srli_epi16(a, 8), srli_epi16(b, 8));
                even = srli_epi16(even, 8);

                result = blendv_si128(even, odd, MASK);

            RET:

                constexpr.ASSUME(result.Byte0  == (byte)(((uint)a.Byte0  * (uint)b.Byte0)  >> 8));
                constexpr.ASSUME(result.Byte1  == (byte)(((uint)a.Byte1  * (uint)b.Byte1)  >> 8));
                constexpr.ASSUME(result.Byte2  == (byte)(((uint)a.Byte2  * (uint)b.Byte2)  >> 8));
                constexpr.ASSUME(result.Byte3  == (byte)(((uint)a.Byte3  * (uint)b.Byte3)  >> 8));
                constexpr.ASSUME(result.Byte4  == (byte)(((uint)a.Byte4  * (uint)b.Byte4)  >> 8));
                constexpr.ASSUME(result.Byte5  == (byte)(((uint)a.Byte5  * (uint)b.Byte5)  >> 8));
                constexpr.ASSUME(result.Byte6  == (byte)(((uint)a.Byte6  * (uint)b.Byte6)  >> 8));
                constexpr.ASSUME(result.Byte7  == (byte)(((uint)a.Byte7  * (uint)b.Byte7)  >> 8));
                constexpr.ASSUME(result.Byte8  == (byte)(((uint)a.Byte8  * (uint)b.Byte8)  >> 8));
                constexpr.ASSUME(result.Byte9  == (byte)(((uint)a.Byte9  * (uint)b.Byte9)  >> 8));
                constexpr.ASSUME(result.Byte10 == (byte)(((uint)a.Byte10 * (uint)b.Byte10) >> 8));
                constexpr.ASSUME(result.Byte11 == (byte)(((uint)a.Byte11 * (uint)b.Byte11) >> 8));
                constexpr.ASSUME(result.Byte12 == (byte)(((uint)a.Byte12 * (uint)b.Byte12) >> 8));
                constexpr.ASSUME(result.Byte13 == (byte)(((uint)a.Byte13 * (uint)b.Byte13) >> 8));
                constexpr.ASSUME(result.Byte14 == (byte)(((uint)a.Byte14 * (uint)b.Byte14) >> 8));
                constexpr.ASSUME(result.Byte15 == (byte)(((uint)a.Byte15 * (uint)b.Byte15) >> 8));

                constexpr.ASSUME_LT_EPU8(result, byte.MaxValue);

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a3210 = Arm.Neon.vget_low_u8(a);
                v64 b3210 = Arm.Neon.vget_low_u8(b);
                v128 ab3210 = Arm.Neon.vmull_u8(a3210, b3210);
                v128 ab7654 = Arm.Neon.vmull_high_u8(a, b);
                return Arm.Neon.vuzp2q_u8(ab3210, ab7654);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epu8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MASK = new v256(0xFF00_FF00);

                v256 even = Avx2.mm256_mullo_epi16(Avx2.mm256_andnot_si256(MASK, a), Avx2.mm256_andnot_si256(MASK, b));
                v256 odd = Avx2.mm256_mullo_epi16(Avx2.mm256_srli_epi16(a, 8), Avx2.mm256_srli_epi16(b, 8));
                even = Avx2.mm256_srli_epi16(even, 8);

                v256 result = mm256_blendv_si256(even, odd, MASK);

                constexpr.ASSUME(result.Byte0  == (byte)(((uint)a.Byte0  * (uint)b.Byte0)  >> 8));
                constexpr.ASSUME(result.Byte1  == (byte)(((uint)a.Byte1  * (uint)b.Byte1)  >> 8));
                constexpr.ASSUME(result.Byte2  == (byte)(((uint)a.Byte2  * (uint)b.Byte2)  >> 8));
                constexpr.ASSUME(result.Byte3  == (byte)(((uint)a.Byte3  * (uint)b.Byte3)  >> 8));
                constexpr.ASSUME(result.Byte4  == (byte)(((uint)a.Byte4  * (uint)b.Byte4)  >> 8));
                constexpr.ASSUME(result.Byte5  == (byte)(((uint)a.Byte5  * (uint)b.Byte5)  >> 8));
                constexpr.ASSUME(result.Byte6  == (byte)(((uint)a.Byte6  * (uint)b.Byte6)  >> 8));
                constexpr.ASSUME(result.Byte7  == (byte)(((uint)a.Byte7  * (uint)b.Byte7)  >> 8));
                constexpr.ASSUME(result.Byte8  == (byte)(((uint)a.Byte8  * (uint)b.Byte8)  >> 8));
                constexpr.ASSUME(result.Byte9  == (byte)(((uint)a.Byte9  * (uint)b.Byte9)  >> 8));
                constexpr.ASSUME(result.Byte10 == (byte)(((uint)a.Byte10 * (uint)b.Byte10) >> 8));
                constexpr.ASSUME(result.Byte11 == (byte)(((uint)a.Byte11 * (uint)b.Byte11) >> 8));
                constexpr.ASSUME(result.Byte12 == (byte)(((uint)a.Byte12 * (uint)b.Byte12) >> 8));
                constexpr.ASSUME(result.Byte13 == (byte)(((uint)a.Byte13 * (uint)b.Byte13) >> 8));
                constexpr.ASSUME(result.Byte14 == (byte)(((uint)a.Byte14 * (uint)b.Byte14) >> 8));
                constexpr.ASSUME(result.Byte15 == (byte)(((uint)a.Byte15 * (uint)b.Byte15) >> 8));
                constexpr.ASSUME(result.Byte16 == (byte)(((uint)a.Byte16 * (uint)b.Byte16) >> 8));
                constexpr.ASSUME(result.Byte17 == (byte)(((uint)a.Byte17 * (uint)b.Byte17) >> 8));
                constexpr.ASSUME(result.Byte18 == (byte)(((uint)a.Byte18 * (uint)b.Byte18) >> 8));
                constexpr.ASSUME(result.Byte19 == (byte)(((uint)a.Byte19 * (uint)b.Byte19) >> 8));
                constexpr.ASSUME(result.Byte20 == (byte)(((uint)a.Byte20 * (uint)b.Byte20) >> 8));
                constexpr.ASSUME(result.Byte21 == (byte)(((uint)a.Byte21 * (uint)b.Byte21) >> 8));
                constexpr.ASSUME(result.Byte22 == (byte)(((uint)a.Byte22 * (uint)b.Byte22) >> 8));
                constexpr.ASSUME(result.Byte23 == (byte)(((uint)a.Byte23 * (uint)b.Byte23) >> 8));
                constexpr.ASSUME(result.Byte24 == (byte)(((uint)a.Byte24 * (uint)b.Byte24) >> 8));
                constexpr.ASSUME(result.Byte25 == (byte)(((uint)a.Byte25 * (uint)b.Byte25) >> 8));
                constexpr.ASSUME(result.Byte26 == (byte)(((uint)a.Byte26 * (uint)b.Byte26) >> 8));
                constexpr.ASSUME(result.Byte27 == (byte)(((uint)a.Byte27 * (uint)b.Byte27) >> 8));
                constexpr.ASSUME(result.Byte28 == (byte)(((uint)a.Byte28 * (uint)b.Byte28) >> 8));
                constexpr.ASSUME(result.Byte29 == (byte)(((uint)a.Byte29 * (uint)b.Byte29) >> 8));
                constexpr.ASSUME(result.Byte30 == (byte)(((uint)a.Byte30 * (uint)b.Byte30) >> 8));
                constexpr.ASSUME(result.Byte31 == (byte)(((uint)a.Byte31 * (uint)b.Byte31) >> 8));

                constexpr.ASSUME_LT_EPU8(result, byte.MaxValue);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epi8(v128 a, v128 b, byte elements = 16)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result;

                if (Ssse3.IsSsse3Supported)
                {
                    if (elements <= 8)
                    {
                        v128 full = mullo_epi16(cvtepi8_epi16(a), cvtepi8_epi16(b));
                        result = shuffle_epi8(full, new v128(1, 3, 5, 7, 9, 11, 13, 15,   -1, -1, -1, -1, -1, -1, -1, -1));

                        goto RET;
                    }
                }

                v128 even = mullo_epi16(srai_epi16(slli_epi16(a, 8), 8), srai_epi16(slli_epi16(b, 8), 8));
                v128 odd  = mullo_epi16(srai_epi16(a, 8), srai_epi16(b, 8));

                even = srli_epi16(even, 8);

                result = blendv_si128(even, odd, set1_epi16(0xFF00));

            RET:

                constexpr.ASSUME(result.SByte0  == (sbyte)(((int)a.SByte0  * (int)b.SByte0)  >> 8));
                constexpr.ASSUME(result.SByte1  == (sbyte)(((int)a.SByte1  * (int)b.SByte1)  >> 8));
                constexpr.ASSUME(result.SByte2  == (sbyte)(((int)a.SByte2  * (int)b.SByte2)  >> 8));
                constexpr.ASSUME(result.SByte3  == (sbyte)(((int)a.SByte3  * (int)b.SByte3)  >> 8));
                constexpr.ASSUME(result.SByte4  == (sbyte)(((int)a.SByte4  * (int)b.SByte4)  >> 8));
                constexpr.ASSUME(result.SByte5  == (sbyte)(((int)a.SByte5  * (int)b.SByte5)  >> 8));
                constexpr.ASSUME(result.SByte6  == (sbyte)(((int)a.SByte6  * (int)b.SByte6)  >> 8));
                constexpr.ASSUME(result.SByte7  == (sbyte)(((int)a.SByte7  * (int)b.SByte7)  >> 8));
                constexpr.ASSUME(result.SByte8  == (sbyte)(((int)a.SByte8  * (int)b.SByte8)  >> 8));
                constexpr.ASSUME(result.SByte9  == (sbyte)(((int)a.SByte9  * (int)b.SByte9)  >> 8));
                constexpr.ASSUME(result.SByte10 == (sbyte)(((int)a.SByte10 * (int)b.SByte10) >> 8));
                constexpr.ASSUME(result.SByte11 == (sbyte)(((int)a.SByte11 * (int)b.SByte11) >> 8));
                constexpr.ASSUME(result.SByte12 == (sbyte)(((int)a.SByte12 * (int)b.SByte12) >> 8));
                constexpr.ASSUME(result.SByte13 == (sbyte)(((int)a.SByte13 * (int)b.SByte13) >> 8));
                constexpr.ASSUME(result.SByte14 == (sbyte)(((int)a.SByte14 * (int)b.SByte14) >> 8));
                constexpr.ASSUME(result.SByte15 == (sbyte)(((int)a.SByte15 * (int)b.SByte15) >> 8));

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a3210 = Arm.Neon.vget_low_s8(a);
                v64 b3210 = Arm.Neon.vget_low_s8(b);
                v128 ab3210 = Arm.Neon.vmull_s8(a3210, b3210);
                v128 ab7654 = Arm.Neon.vmull_high_s8(a, b);
                return Arm.Neon.vuzp2q_u8(ab3210, ab7654);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = Avx2.mm256_mullo_epi16(Avx2.mm256_srai_epi16(Avx2.mm256_slli_epi16(a, 8), 8), Avx2.mm256_srai_epi16(Avx2.mm256_slli_epi16(b, 8), 8));
                v256 odd  = Avx2.mm256_mullo_epi16(Avx2.mm256_srai_epi16(a, 8), Avx2.mm256_srai_epi16(b, 8));

                even = Avx2.mm256_srli_epi16(even, 8);

                v256 result = mm256_blendv_si256(even, odd, mm256_set1_epi16(0xFF00));

                constexpr.ASSUME(result.SByte0  == (sbyte)(((int)a.SByte0  * (int)b.SByte0)  >> 8));
                constexpr.ASSUME(result.SByte1  == (sbyte)(((int)a.SByte1  * (int)b.SByte1)  >> 8));
                constexpr.ASSUME(result.SByte2  == (sbyte)(((int)a.SByte2  * (int)b.SByte2)  >> 8));
                constexpr.ASSUME(result.SByte3  == (sbyte)(((int)a.SByte3  * (int)b.SByte3)  >> 8));
                constexpr.ASSUME(result.SByte4  == (sbyte)(((int)a.SByte4  * (int)b.SByte4)  >> 8));
                constexpr.ASSUME(result.SByte5  == (sbyte)(((int)a.SByte5  * (int)b.SByte5)  >> 8));
                constexpr.ASSUME(result.SByte6  == (sbyte)(((int)a.SByte6  * (int)b.SByte6)  >> 8));
                constexpr.ASSUME(result.SByte7  == (sbyte)(((int)a.SByte7  * (int)b.SByte7)  >> 8));
                constexpr.ASSUME(result.SByte8  == (sbyte)(((int)a.SByte8  * (int)b.SByte8)  >> 8));
                constexpr.ASSUME(result.SByte9  == (sbyte)(((int)a.SByte9  * (int)b.SByte9)  >> 8));
                constexpr.ASSUME(result.SByte10 == (sbyte)(((int)a.SByte10 * (int)b.SByte10) >> 8));
                constexpr.ASSUME(result.SByte11 == (sbyte)(((int)a.SByte11 * (int)b.SByte11) >> 8));
                constexpr.ASSUME(result.SByte12 == (sbyte)(((int)a.SByte12 * (int)b.SByte12) >> 8));
                constexpr.ASSUME(result.SByte13 == (sbyte)(((int)a.SByte13 * (int)b.SByte13) >> 8));
                constexpr.ASSUME(result.SByte14 == (sbyte)(((int)a.SByte14 * (int)b.SByte14) >> 8));
                constexpr.ASSUME(result.SByte15 == (sbyte)(((int)a.SByte15 * (int)b.SByte15) >> 8));
                constexpr.ASSUME(result.SByte16 == (sbyte)(((int)a.SByte16 * (int)b.SByte16) >> 8));
                constexpr.ASSUME(result.SByte17 == (sbyte)(((int)a.SByte17 * (int)b.SByte17) >> 8));
                constexpr.ASSUME(result.SByte18 == (sbyte)(((int)a.SByte18 * (int)b.SByte18) >> 8));
                constexpr.ASSUME(result.SByte19 == (sbyte)(((int)a.SByte19 * (int)b.SByte19) >> 8));
                constexpr.ASSUME(result.SByte20 == (sbyte)(((int)a.SByte20 * (int)b.SByte20) >> 8));
                constexpr.ASSUME(result.SByte21 == (sbyte)(((int)a.SByte21 * (int)b.SByte21) >> 8));
                constexpr.ASSUME(result.SByte22 == (sbyte)(((int)a.SByte22 * (int)b.SByte22) >> 8));
                constexpr.ASSUME(result.SByte23 == (sbyte)(((int)a.SByte23 * (int)b.SByte23) >> 8));
                constexpr.ASSUME(result.SByte24 == (sbyte)(((int)a.SByte24 * (int)b.SByte24) >> 8));
                constexpr.ASSUME(result.SByte25 == (sbyte)(((int)a.SByte25 * (int)b.SByte25) >> 8));
                constexpr.ASSUME(result.SByte26 == (sbyte)(((int)a.SByte26 * (int)b.SByte26) >> 8));
                constexpr.ASSUME(result.SByte27 == (sbyte)(((int)a.SByte27 * (int)b.SByte27) >> 8));
                constexpr.ASSUME(result.SByte28 == (sbyte)(((int)a.SByte28 * (int)b.SByte28) >> 8));
                constexpr.ASSUME(result.SByte29 == (sbyte)(((int)a.SByte29 * (int)b.SByte29) >> 8));
                constexpr.ASSUME(result.SByte30 == (sbyte)(((int)a.SByte30 * (int)b.SByte30) >> 8));
                constexpr.ASSUME(result.SByte31 == (sbyte)(((int)a.SByte31 * (int)b.SByte31) >> 8));

                return result;
            }
            else throw new IllegalInstructionException();
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mullo_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.mullo_epi16(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vmulq_s16(a, b);
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mulhi_epu16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.mulhi_epu16(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a3210 = Arm.Neon.vget_low_u16(a);
                v64 b3210 = Arm.Neon.vget_low_u16(b);
                v128 ab3210 = Arm.Neon.vmull_u16(a3210, b3210);
                v128 ab7654 = Arm.Neon.vmull_high_u16(a, b);
                return Arm.Neon.vuzp2q_u16(ab3210, ab7654);
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mulhi_epi16(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.mulhi_epi16(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a3210 = Arm.Neon.vget_low_s16(a);
                v64 b3210 = Arm.Neon.vget_low_s16(b);
                v128 ab3210 = Arm.Neon.vmull_s16(a3210, b3210);
                v128 ab7654 = Arm.Neon.vmull_high_s16(a, b);
                return Arm.Neon.vuzp2q_u16(ab3210, ab7654);
            }
			else throw new IllegalInstructionException();
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mullo_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPI32(a, b, elements))
                {
                    return square_epi32(a, elements);
                }

                return impl_mullo_epi32(a, b, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result;

                if (Sse4_1.IsSse41Supported)
                {
                    if (elements == 2)
                    {
                        v128 __a = cvtepu32_epi64(a);
                        v128 __b = cvtepu32_epi64(b);

                        result = shuffle_epi32(mul_epi32(__a, __b), Sse.SHUFFLE(0, 0, 3, 1));
                    }
                    else
                    {
                        v128 even = bsrli_si128(mul_epi32(a, b), sizeof(int));
                        v128 odd  = mul_epi32(bsrli_si128(a, sizeof(int)),
                                              bsrli_si128(b, sizeof(int)));

                        result = blend_epi16(even, odd, 0b1100_1100);
                    }
                }
                else
                {
                    result = mulhi_epu32(a, b, elements);

                    if (constexpr.ALL_GE_EPI32(a, 0, elements) 
                     && constexpr.ALL_GE_EPI32(b, 0, elements))
                    {
                        ;
                    }
                    else
                    {
                        result = sub_epi32(result, add_epi32(and_si128(b, srai_epi32(a, 31)), and_si128(a, srai_epi32(b, 31))));
                    }
                }
                
                constexpr.ASSUME(result.SInt0 == (int)(((long)a.SInt0 * (long)b.SInt0) >> 32));
                constexpr.ASSUME(result.SInt1 == (int)(((long)a.SInt1 * (long)b.SInt1) >> 32));
                if (elements > 2)
                {
                    constexpr.ASSUME(result.SInt2 == (int)(((long)a.SInt2 * (long)b.SInt2) >> 32));
                    constexpr.ASSUME(result.SInt3 == (int)(((long)a.SInt3 * (long)b.SInt3) >> 32));
                }
                
                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a3210 = Arm.Neon.vget_low_s32(a);
                v64 b3210 = Arm.Neon.vget_low_s32(b);
                v128 ab3210 = Arm.Neon.vmull_s32(a3210, b3210);
                v128 ab7654 = Arm.Neon.vmull_high_s32(a, b);
                return Arm.Neon.vuzp2q_u32(ab3210, ab7654);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epi32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = Avx2.mm256_bsrli_epi128(Avx2.mm256_mul_epi32(a, b), sizeof(int));
                v256 odd  = Avx2.mm256_mul_epi32(Avx2.mm256_bsrli_epi128(a, sizeof(int)),
                                                 Avx2.mm256_bsrli_epi128(b, sizeof(int)));

                v256 result = Avx2.mm256_blend_epi32(even, odd, 0b1010_1010);
                
                constexpr.ASSUME(result.SInt0 == (int)(((long)a.SInt0 * (long)b.SInt0) >> 32));
                constexpr.ASSUME(result.SInt1 == (int)(((long)a.SInt1 * (long)b.SInt1) >> 32));
                constexpr.ASSUME(result.SInt2 == (int)(((long)a.SInt2 * (long)b.SInt2) >> 32));
                constexpr.ASSUME(result.SInt3 == (int)(((long)a.SInt3 * (long)b.SInt3) >> 32));
                constexpr.ASSUME(result.SInt4 == (int)(((long)a.SInt4 * (long)b.SInt4) >> 32));
                constexpr.ASSUME(result.SInt5 == (int)(((long)a.SInt5 * (long)b.SInt5) >> 32));
                constexpr.ASSUME(result.SInt6 == (int)(((long)a.SInt6 * (long)b.SInt6) >> 32));
                constexpr.ASSUME(result.SInt7 == (int)(((long)a.SInt7 * (long)b.SInt7) >> 32));
                
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result;

                if (elements == 2)
                {
                    v128 __a = cvtepu32_epi64(a);
                    v128 __b = cvtepu32_epi64(b);

                    result = shuffle_epi32(mul_epu32(__a, __b), Sse.SHUFFLE(0, 0, 3, 1));
                }
                else
                {
                    v128 even = mul_epu32(a, b);
                    v128 odd  = mul_epu32(bsrli_si128(a, sizeof(int)),
                                          bsrli_si128(b, sizeof(int)));

                    if (Sse4_1.IsSse41Supported)
                    {
                        even = bsrli_si128(even, sizeof(int));

                        result = blend_epi16(even, odd, 0b1100_1100);
                    }
                    else
                    {
                        result = unpackhi_epi64(unpacklo_epi32(even, odd),
                                                unpackhi_epi32(even, odd));
                    }
                }
                
                constexpr.ASSUME(result.UInt0 == (uint)(((ulong)a.UInt0 * (ulong)b.UInt0) >> 32));
                constexpr.ASSUME(result.UInt1 == (uint)(((ulong)a.UInt1 * (ulong)b.UInt1) >> 32));
                if (elements > 2)
                {
                    constexpr.ASSUME(result.UInt2 == (uint)(((ulong)a.UInt2 * (ulong)b.UInt2) >> 32));
                    constexpr.ASSUME(result.UInt3 == (uint)(((ulong)a.UInt3 * (ulong)b.UInt3) >> 32));
                }

                constexpr.ASSUME_LT_EPU32(result, uint.MaxValue, elements);
                
                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a3210 = Arm.Neon.vget_low_u32(a);
                v64 b3210 = Arm.Neon.vget_low_u32(b);
                v128 ab3210 = Arm.Neon.vmull_u32(a3210, b3210);
                v128 ab7654 = Arm.Neon.vmull_high_u32(a, b);
                return Arm.Neon.vuzp2q_u32(ab3210, ab7654);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = Avx2.mm256_bsrli_epi128(Avx2.mm256_mul_epu32(a, b), sizeof(int));
                v256 odd  = Avx2.mm256_mul_epu32(Avx2.mm256_bsrli_epi128(a, sizeof(int)),
                                                 Avx2.mm256_bsrli_epi128(b, sizeof(int)));

                v256 result = Avx2.mm256_blend_epi32(even, odd, 0b1010_1010);
                
                constexpr.ASSUME(result.UInt0 == (uint)(((ulong)a.UInt0 * (ulong)b.UInt0) >> 32));
                constexpr.ASSUME(result.UInt1 == (uint)(((ulong)a.UInt1 * (ulong)b.UInt1) >> 32));
                constexpr.ASSUME(result.UInt2 == (uint)(((ulong)a.UInt2 * (ulong)b.UInt2) >> 32));
                constexpr.ASSUME(result.UInt3 == (uint)(((ulong)a.UInt3 * (ulong)b.UInt3) >> 32));
                constexpr.ASSUME(result.UInt4 == (uint)(((ulong)a.UInt4 * (ulong)b.UInt4) >> 32));
                constexpr.ASSUME(result.UInt5 == (uint)(((ulong)a.UInt5 * (ulong)b.UInt5) >> 32));
                constexpr.ASSUME(result.UInt6 == (uint)(((ulong)a.UInt6 * (ulong)b.UInt6) >> 32));
                constexpr.ASSUME(result.UInt7 == (uint)(((ulong)a.UInt7 * (ulong)b.UInt7) >> 32));

                constexpr.ASSUME_LT_EPU32(result, uint.MaxValue);
                
                return result;
            }
            else throw new IllegalInstructionException();
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mul_epu32(v128 a, v128 b)
		{
			if (Sse2.IsSse2Supported)
			{
				return Sse2.mul_epu32(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a_lo = Arm.Neon.vmovn_u64(a);
                v64 b_lo = Arm.Neon.vmovn_u64(b);
                return Arm.Neon.vmull_u32(a_lo, b_lo);
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mul_epi32(v128 a, v128 b)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.mul_epi32(a, b);
			}
            else if (Sse2.IsSse2Supported)
            {
                v128 unsigned = Sse2.mul_epu32(a, b);

                if (constexpr.ALL_GE_EPI32(a, 0, 3) && constexpr.ALL_GE_EPI32(b, 0, 3))
                {
                    ;
                }
                else
                {
                    v128 upShiftA = Sse2.unpacklo_epi32(Sse2.setzero_si128(), Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 0, 2, 0)));
                    v128 upShiftB = Sse2.unpacklo_epi32(Sse2.setzero_si128(), Sse2.shuffle_epi32(b, Sse.SHUFFLE(0, 0, 2, 0)));
                    unsigned = sub_epi32(unsigned, add_epi32(and_si128(upShiftB, srai_epi32(upShiftA, 31)), and_si128(upShiftA, srai_epi32(upShiftB, 31))));
                }

                return unsigned;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                v64 a_lo = Arm.Neon.vmovn_s64(a);
                v64 b_lo = Arm.Neon.vmovn_s64(b);
                return Arm.Neon.vmull_s32(a_lo, b_lo);
            }
			else throw new IllegalInstructionException();
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 maddubs_epi16(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.maddubs_epi16(a, b);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                v128 tl = Arm.Neon.vmulq_s16(Arm.Neon.vmovl_u8(Arm.Neon.vget_low_u8(a)), Arm.Neon.vmovl_s8(Arm.Neon.vget_low_s8(b)));
                v128 th = Arm.Neon.vmulq_s16(Arm.Neon.vmovl_u8(Arm.Neon.vget_high_u8(a)), Arm.Neon.vmovl_s8(Arm.Neon.vget_high_s8(b)));
                return Arm.Neon.vqaddq_s16(Arm.Neon.vuzp1q_s16(tl, th), Arm.Neon.vuzp2q_s16(tl, th));
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mulhrs_epi16(v128 a, v128 b)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.mulhrs_epi16(a, b);
			}
            else if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.mullo_epi16(a, b);
                v128 hi = Sse2.mulhi_epi16(a, b);
                
                v128 prodLo = Sse2.unpacklo_epi16(lo, hi);
                v128 prodHi = Sse2.unpackhi_epi16(lo, hi);
                
                v128 round = Sse2.set1_epi32(1 << (15 - 1));
                
                prodLo = Sse2.add_epi32(prodLo, round);
                prodHi = Sse2.add_epi32(prodHi, round);
                
                prodLo = Sse2.srai_epi32(prodLo, 15);
                prodHi = Sse2.srai_epi32(prodHi, 15);
                
                return Sse2.packs_epi32(prodLo, prodHi);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                v128 mul_lo = Arm.Neon.vmull_s16(Arm.Neon.vget_low_s16(a), Arm.Neon.vget_low_s16(b));
                v128 mul_hi = Arm.Neon.vmull_s16(Arm.Neon.vget_high_s16(a), Arm.Neon.vget_high_s16(b));

                v64 narrow_lo = Arm.Neon.vrshrn_n_s32(mul_lo, 15);
                v64 narrow_hi = Arm.Neon.vrshrn_n_s32(mul_hi, 15);

                return Arm.Neon.vcombine_s16(narrow_lo, narrow_hi);
            }
			else throw new IllegalInstructionException();
		}



		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 mpsadbw_epu8(v128 a, v128 b, int imm8)
		{
			if (Sse4_1.IsSse41Supported)
			{
				return Sse4_1.mpsadbw_epu8(a, b, imm8);
			}
            else if (Arm.Neon.IsNeonSupported)
            {
                switch (imm8 & 0x4)
                {
                    case 4: a = Xse.imm8.Arm.vextq_u32(a, a, 1); break;
                    default: break;
                }

                switch (imm8 & 0x3)
                {
                    case 0: b = Arm.Neon.vdupq_n_u32(Xse.imm8.Arm.vgetq_lane_u32(b, 0)); break;
                    case 1: b = Arm.Neon.vdupq_n_u32(Xse.imm8.Arm.vgetq_lane_u32(b, 1)); break;
                    case 2: b = Arm.Neon.vdupq_n_u32(Xse.imm8.Arm.vgetq_lane_u32(b, 2)); break;
                    case 3: b = Arm.Neon.vdupq_n_u32(Xse.imm8.Arm.vgetq_lane_u32(b, 3)); break;
                    default: break;
                }

                v128 c04, c15, c26, c37;
                v64 low_b = Arm.Neon.vget_low_u8(b);
                c04 = Arm.Neon.vabdl_u8(Arm.Neon.vget_low_u8(a), low_b);
                v128 _a_1 = Xse.imm8.Arm.vextq_u8(a, a, 1);
                c15 = Arm.Neon.vabdl_u8(Arm.Neon.vget_low_u8(_a_1), low_b);
                v128 _a_2 = Xse.imm8.Arm.vextq_u8(a, a, 2);
                c26 = Arm.Neon.vabdl_u8(Arm.Neon.vget_low_u8(_a_2), low_b);
                v128 _a_3 = Xse.imm8.Arm.vextq_u8(a, a, 3);
                c37 = Arm.Neon.vabdl_u8(Arm.Neon.vget_low_u8(_a_3), low_b);
                c04 = Arm.Neon.vpaddq_s16(c04, c26);
                c15 = Arm.Neon.vpaddq_s16(c15, c37);

                v128 trn1_c = Arm.Neon.vtrn1q_s32(c04, c15);
                v128 trn2_c = Arm.Neon.vtrn2q_s32(c04, c15);
                return Arm.Neon.vpaddq_s16(trn1_c, trn2_c);
            }
			else throw new IllegalInstructionException();
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool constcheck_mullo_epi64(v128 a, v128 b, out v128 result, bool unsigned_A_lessequalU32Max = false, bool unsigned_B_lessequalU32Max = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if ((unsigned_A_lessequalU32Max || constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                 && (unsigned_B_lessequalU32Max || constexpr.ALL_LE_EPU64(b, uint.MaxValue)))
                {
                    result = mul_epu32(a, b);

                    return true;
                }
                if (BurstArchitecture.IsMul32Supported)
                {
                    if (constexpr.ALL_GE_EPI64(a, int.MinValue) && constexpr.ALL_LE_EPI64(a, int.MaxValue)
                     && constexpr.ALL_GE_EPI64(b, int.MinValue) && constexpr.ALL_LE_EPI64(b, int.MaxValue))
                    {
                        result = mul_epi32(a, b);

                        return true;
                    }
                }

                result = default(v128);
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool constcheck_mm256_mullo_epi64(v256 a, v256 b, out v256 result, byte elements = 4, bool unsigned_A_lessequalU32Max = false, bool unsigned_B_lessequalU32Max = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if ((unsigned_A_lessequalU32Max || constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                 && (unsigned_B_lessequalU32Max || constexpr.ALL_LE_EPU64(b, uint.MaxValue, elements)))
                {
                    result = Avx2.mm256_mul_epu32(a, b);

                    return true;
                }
                if (constexpr.ALL_GE_EPI64(a, int.MinValue, elements) && constexpr.ALL_LE_EPI64(a, int.MaxValue, elements)
                 && constexpr.ALL_GE_EPI64(b, int.MinValue, elements) && constexpr.ALL_LE_EPI64(b, int.MaxValue, elements))
                {
                    result = Avx2.mm256_mul_epi32(a, b);

                    return true;
                }

                result = default(v256);
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mullo_epi64(v128 a, v128 b, bool unsigned_A_lessequalU32Max = false, bool unsigned_B_lessequalU32Max = false)
        {
            if (Arm.Neon.IsNeonSupported)
            {
                v64 ac = Arm.Neon.vmovn_s64(a);
                v64 pr = Arm.Neon.vmovn_s64(b);
                v128 hi = Arm.Neon.vmulq_s32(b, Arm.Neon.vrev64q_s32(a));

                return Arm.Neon.vmlal_u32(Arm.Neon.vshlq_n_s64(Arm.Neon.vpaddlq_u32(hi), 32), ac, pr);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.ALL_EQ_EPI64(a, b))
                {
                    return square_epi64(a);
                }
                if (constcheck_mullo_epi64(a, b, out v128 epi32Result, unsigned_A_lessequalU32Max, unsigned_B_lessequalU32Max))
                {
                    return epi32Result;
                }
                
                v128 result;

                v128 prod32 = mul_epu32(a, b);
                v128 carry32;

                if (unsigned_A_lessequalU32Max || constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                {
                    if (unsigned_B_lessequalU32Max || constexpr.ALL_LE_EPU64(b, uint.MaxValue))
                    {
                        result = prod32;
                    }
                    else
                    {
                        carry32 = slli_epi64(mul_epu32(a, srli_epi64(b, 32)), 32);
                        result = add_epi64(prod32, carry32);
                    }
                }
                else if (unsigned_B_lessequalU32Max || constexpr.ALL_LE_EPU64(b, uint.MaxValue))
                {
                    carry32 = slli_epi64(mul_epu32(b, srli_epi64(a, 32)), 32);
                    result = add_epi64(prod32, carry32);
                }
                else
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        carry32 = mullo_epi32(a, shuffle_epi32(b, Sse.SHUFFLE(2, 3, 0, 1)));
                        carry32 = hadd_epi32(carry32, setzero_si128());
                        carry32 = shuffle_epi32(carry32, Sse.SHUFFLE(1, 3, 0, 3));
                    }
                    else
                    {
                        v128 lCarry = mul_epu32(a, srli_epi64(b, 32));
                        v128 rCarry = mul_epu32(b, srli_epi64(a, 32));
                        carry32 = slli_epi64(add_epi64(lCarry, rCarry), 32);
                    }

                    result = add_epi64(prod32, carry32);
                }

                if (unsigned_A_lessequalU32Max)
                {
                    constexpr.ASSUME_LE_EPU64(a, uint.MaxValue);
                }
                if (unsigned_B_lessequalU32Max)
                {
                    constexpr.ASSUME_LE_EPU64(b, uint.MaxValue);
                }

                constexpr.ASSUME_MULTIPLICATION_EPI64(result, a, b);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mullo_epi64(v256 a, v256 b, byte elements = 4, bool unsigned_A_lessequalU32Max = false, bool unsigned_B_lessequalU32Max = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_EQ_EPI64(a, b, elements))
                {
                    return mm256_square_epi64(a, elements);
                }
                if (constcheck_mm256_mullo_epi64(a, b, out v256 epi32Result, elements, unsigned_A_lessequalU32Max, unsigned_B_lessequalU32Max))
                {
                    return epi32Result;
                }

                v256 result;

                v256 prod32 = Avx2.mm256_mul_epu32(a, b);
                v256 carry32;

                if (unsigned_A_lessequalU32Max || constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                {
                    if (unsigned_B_lessequalU32Max || constexpr.ALL_LE_EPU64(b, uint.MaxValue, elements))
                    {
                        result = prod32;
                    }
                    else
                    {
                        carry32 = Avx2.mm256_slli_epi64(Avx2.mm256_mul_epu32(a, Avx2.mm256_srli_epi64(b, 32)), 32);
                        result = Avx2.mm256_add_epi64(prod32, carry32);
                    }
                }
                else if (unsigned_B_lessequalU32Max || constexpr.ALL_LE_EPU64(b, uint.MaxValue, elements))
                {
                    carry32 = Avx2.mm256_slli_epi64(Avx2.mm256_mul_epu32(b, Avx2.mm256_srli_epi64(a, 32)), 32);
                    result = Avx2.mm256_add_epi64(prod32, carry32);
                }
                else
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        carry32 = Avx2.mm256_mullo_epi32(a, Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(2, 3, 0, 1)));
                        carry32 = Avx2.mm256_hadd_epi32(carry32, Avx.mm256_setzero_si256());
                        carry32 = Avx2.mm256_shuffle_epi32(carry32, Sse.SHUFFLE(1, 3, 0, 3));
                    }
                    else
                    {
                        v256 lCarry = Avx2.mm256_mul_epu32(a, Avx2.mm256_srli_epi64(b, 32));
                        v256 rCarry = Avx2.mm256_mul_epu32(b, Avx2.mm256_srli_epi64(a, 32));
                        carry32 = Avx2.mm256_slli_epi64(Avx2.mm256_add_epi64(lCarry, rCarry), 32);
                    }

                    result = Avx2.mm256_add_epi64(prod32, carry32);
                }

                if (unsigned_A_lessequalU32Max)
                {
                    constexpr.ASSUME_LE_EPU64(a, uint.MaxValue);
                }
                if (unsigned_B_lessequalU32Max)
                {
                    constexpr.ASSUME_LE_EPU64(b, uint.MaxValue);
                }
                
                constexpr.ASSUME_MULTIPLICATION_EPI64(result, a, b);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epi64(v128 a, v128 b, out v128 low)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = mulhi_epu64(a, b, out low);

                if (constexpr.ALL_GE_EPI64(a, 0) && constexpr.ALL_GE_EPI64(b, 0))
                {
                    ;
                }
                else
                {
                    result = sub_epi64(result, add_epi64(and_si128(b, srai_epi64(a, 63)), and_si128(a, srai_epi64(b, 63))));
                }

                constexpr.ASSUME(result.SLong0 == (long)((Int128)a.SLong0 * (Int128)b.SLong0).hi64);
                constexpr.ASSUME(result.SLong1 == (long)((Int128)a.SLong1 * (Int128)b.SLong1).hi64);
                
                constexpr.ASSUME_MULTIPLICATION_EPI64(low, a, b);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epi64(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return mulhi_epi64(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epi64(v256 a, v256 b, out v256 low, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = mm256_mulhi_epu64(a, b, out low, elements);

                if (constexpr.ALL_GE_EPI64(a, 0, elements) && constexpr.ALL_GE_EPI64(b, 0, elements))
                {
                    ;
                }
                else
                {
                    result = Avx2.mm256_sub_epi64(result, Avx2.mm256_add_epi64(Avx2.mm256_and_si256(b, mm256_srai_epi64(a, 63, elements)), Avx2.mm256_and_si256(a, mm256_srai_epi64(b, 63, elements))));
                }
                

                constexpr.ASSUME(result.SLong0 == (long)((Int128)a.SLong0 * (Int128)b.SLong0).hi64);
                constexpr.ASSUME(result.SLong1 == (long)((Int128)a.SLong1 * (Int128)b.SLong1).hi64);
                constexpr.ASSUME(result.SLong2 == (long)((Int128)a.SLong2 * (Int128)b.SLong2).hi64);
                constexpr.ASSUME(result.SLong3 == (long)((Int128)a.SLong3 * (Int128)b.SLong3).hi64);
                
                constexpr.ASSUME_MULTIPLICATION_EPI64(low, a, b);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epi64(v256 a, v256 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                return mm256_mulhi_epi64(a, b, out _, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epu64(v128 a, v128 b, out v128 low)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                UInt128 x = UInt128.umul128(a.ULong0, b.ULong0);
                UInt128 y = UInt128.umul128(a.ULong1, b.ULong1);

                low = new v128(x.lo64, y.lo64);
                v128 result = new v128(x.hi64, y.hi64);

                constexpr.ASSUME(result.ULong0 == ((UInt128)a.ULong0 * (UInt128)b.ULong0).hi64);
                constexpr.ASSUME(result.ULong1 == ((UInt128)a.ULong1 * (UInt128)b.ULong1).hi64);

                constexpr.ASSUME_MULTIPLICATION_EPI64(low, a, b);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulhi_epu64(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return mulhi_epu64(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epu64(v256 a, v256 b, out v256 low, byte elements = 4, bool unsigned_A_lessequalU32Max = false, bool unsigned_B_lessequalU32Max = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();

                v256 aHi = Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(2, 3, 0, 1));
                v256 bHi = Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(2, 3, 0, 1));

                v256 lo = Avx2.mm256_mul_epu32(a, b);
                v256 m1 = Avx2.mm256_mul_epu32(aHi, b);
                v256 m2 = Avx2.mm256_mul_epu32(a, bHi);
                v256 hi = Avx2.mm256_mul_epu32(aHi, bHi);

                v256 m1Lo = Avx2.mm256_blend_epi32(m1, ZERO, 0b1010_1010);
                v256 loHi = Avx2.mm256_srli_epi64(lo, 32);
                v256 m1Hi = Avx2.mm256_srli_epi64(m1, 32);

                low = mm256_mullo_epi64(a, b, elements, unsigned_A_lessequalU32Max, unsigned_B_lessequalU32Max);
                v256 result = Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(hi, m1Hi), Avx2.mm256_srli_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(loHi, m1Lo), m2), 32));

                constexpr.ASSUME(result.ULong0 == ((UInt128)a.ULong0 * (UInt128)b.ULong0).hi64);
                constexpr.ASSUME(result.ULong1 == ((UInt128)a.ULong1 * (UInt128)b.ULong1).hi64);
                constexpr.ASSUME(result.ULong2 == ((UInt128)a.ULong2 * (UInt128)b.ULong2).hi64);
                constexpr.ASSUME(result.ULong3 == ((UInt128)a.ULong3 * (UInt128)b.ULong3).hi64);

                constexpr.ASSUME_MULTIPLICATION_EPI64(low, a, b);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulhi_epu64(v256 a, v256 b, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                return mm256_mulhi_epu64(a, b, out _, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 squarehi_epu64(v128 a, out v128 low)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return mulhi_epu64(a, a, out low);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 squarehi_epu64(v128 a)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return squarehi_epu64(a, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_squarehi_epu64(v256 a, out v256 low, byte elements = 4, bool unsigned_A_lessequalU32Max = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 ZERO = Avx.mm256_setzero_si256();

                v256 aHi = Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(2, 3, 0, 1));

                v256 lo = Avx2.mm256_mul_epu32(a, a);
                v256 m = Avx2.mm256_mul_epu32(aHi, a);
                v256 hi = Avx2.mm256_mul_epu32(aHi, aHi);

                v256 mLo = Avx2.mm256_blend_epi32(m, ZERO, 0b1010_1010);
                v256 loHi = Avx2.mm256_srli_epi64(lo, 32);
                v256 mHi = Avx2.mm256_srli_epi64(m, 32);

                low = mm256_square_epi64(a, elements, unsigned_A_lessequalU32Max);
                v256 result = Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(hi, mHi), Avx2.mm256_srli_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(loHi, mLo), m), 32));

                constexpr.ASSUME(result.ULong0 == math.square((UInt128)a.ULong0).hi64);
                constexpr.ASSUME(result.ULong1 == math.square((UInt128)a.ULong1).hi64);
                constexpr.ASSUME(result.ULong2 == math.square((UInt128)a.ULong2).hi64);
                constexpr.ASSUME(result.ULong3 == math.square((UInt128)a.ULong3).hi64);

                constexpr.ASSUME_MULTIPLICATION_EPI64(low, a, a);
                
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_squarehi_epu64(v256 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return mm256_squarehi_epu64(a, out _);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 square_epi8(v128 a, byte elements = 16, bool orderMatters = true, bool fourBit = false)
        {
            fourBit |= constexpr.ALL_LE_EPU8(a, 15, elements);

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (fourBit)
                    {
                        result = shuffle_epi8(SQUARES_EPU4, a);

                        goto RET;
                    }
                    else if (Sse4_1.IsSse41Supported)
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                        {
                            v128 a1 = slli_epi8(a, 5, maskBefore: true, elements: elements);
                            v128 a2 = slli_epi8(a, 6, maskBefore: true, elements: elements);
                            a1 = blendv_epi8(setzero_si128(), a1, slli_epi16(a, 3));
                            a2 = blendv_epi8(setzero_si128(), a2, slli_epi16(a, 2));

                            v128 lo = shuffle_epi8(SQUARES_EPU4, and_si128(a, set1_epi8(0b1111)));

                            v128 a4 = slli_epi8(a, 7, maskBefore: false, elements: elements);
                            a4 = ternarylogic_si128(a4, lo, add_epi8(a, a), TernaryOperation.Ox6C);

                            result = add_epi8(a4, add_epi8(a2, a1));

                            goto RET;
                        }
                    }
                }

                result = impl_mullo_epi8(a, a, elements, orderMatters);

            RET:

                constexpr.ASSUME_MULTIPLICATION_EPI8(result, a, a, elements);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_square_epi8(v256 a, bool orderMatters = true, bool fourBit = false)
        {
            fourBit |= constexpr.ALL_LE_EPU8(a, 15);

            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                if (fourBit)
                {
                    result = Avx2.mm256_shuffle_epi8(MM256_SQUARES_EPU4, a);
                }
                else if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Performance)
                {
                    v256 a1 = mm256_slli_epi8(a, 5, maskBefore: true);
                    v256 a2 = mm256_slli_epi8(a, 6, maskBefore: true);
                    a1 = Avx2.mm256_blendv_epi8(Avx.mm256_setzero_si256(), a1, mm256_slli_epi16(a, 3));
                    a2 = Avx2.mm256_blendv_epi8(Avx.mm256_setzero_si256(), a2, mm256_slli_epi16(a, 2));

                    v256 lo = Avx2.mm256_shuffle_epi8(MM256_SQUARES_EPU4, Avx2.mm256_and_si256(a, mm256_set1_epi8(0b1111)));

                    v256 a4 = mm256_slli_epi8(a, 7, maskBefore: false);
                    a4 = mm256_ternarylogic_si256(a4, lo, Avx2.mm256_add_epi8(a, a), TernaryOperation.Ox6C);

                    result = Avx2.mm256_add_epi8(a4, Avx2.mm256_add_epi8(a2, a1));
                }
                else
                {
                    result = mm256_impl_mullo_epi8(a, a, orderMatters);
                }

                constexpr.ASSUME_MULTIPLICATION_EPI8(result, a, a);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 square_epi16(v128 a, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU16(a, 15, elements))
                    {
                        v128 result = shuffle_epi8(SQUARES_EPU4, a);
                        
                        constexpr.ASSUME_MULTIPLICATION_EPI16(result, a, a);

                        return result;
                    }
                }

                return mullo_epi16(a, a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_square_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU16(a, 15))
                {
                    v256 result = Avx2.mm256_shuffle_epi8(MM256_SQUARES_EPU4, a);
                        
                    constexpr.ASSUME_MULTIPLICATION_EPI16(result, a, a);
                    
                    return result;
                }

                return Avx2.mm256_mullo_epi16(a, a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 square_epi32(v128 a, byte elements = 4)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU32(a, 15, elements))
                    {
                        v128 result = shuffle_epi8(SQUARES_EPU4, a);
                        
                        constexpr.ASSUME_MULTIPLICATION_EPI32(result, a, a, elements);
                        
                        return result;
                    }
                }

                return impl_mullo_epi32(a, a, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_square_epi32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, 15))
                {
                    v256 result = Avx2.mm256_shuffle_epi8(MM256_SQUARES_EPU4, a);
                        
                    constexpr.ASSUME_MULTIPLICATION_EPI32(result, a, a);
                    
                    return result;
                }

                return Avx2.mm256_mullo_epi32(a, a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 square_epi64(v128 a, bool unsigned_A_lessequalU32Max = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.ALL_LE_EPU64(a, 15))
                    {
                        result = shuffle_epi8(SQUARES_EPU4, a);

                        goto RET;
                    }
                }

                if (constcheck_mullo_epi64(a, a, out v128 epi32Result, unsigned_A_lessequalU32Max, unsigned_A_lessequalU32Max))
                {
                    result = epi32Result;
                }
                else
                {
                    v128 lo = mul_epu32(a, a);
                    v128 carry32 = mul_epu32(a, srli_epi64(a, 32));
                    carry32 = slli_epi64(carry32, 33);

                    result = add_epi64(lo, carry32);
                }

            RET:
                        
                constexpr.ASSUME_MULTIPLICATION_EPI64(result, a, a);
                
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_square_epi64(v256 a, byte elements = 4, bool unsigned_A_lessequalU32Max = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                if (constexpr.ALL_LE_EPU64(a, 15, elements))
                {
                    result = Avx2.mm256_shuffle_epi8(MM256_SQUARES_EPU4, a);

                    goto RET;
                }

                if (constcheck_mm256_mullo_epi64(a, a, out v256 epi32Result, elements, unsigned_A_lessequalU32Max, unsigned_A_lessequalU32Max))
                {
                    result = epi32Result;
                }
                else
                {
                    v256 lo = Avx2.mm256_mul_epu32(a, a);
                    v256 carry32 = Avx2.mm256_mul_epu32(a, Avx2.mm256_srli_epi64(a, 32));
                    carry32 = Avx2.mm256_slli_epi64(carry32, 33);

                    result = Avx2.mm256_add_epi64(lo, carry32);
                }

            RET:
                        
                constexpr.ASSUME_MULTIPLICATION_EPI64(result, a, a);
                
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 impl_mullo_epi8(v128 a, v128 b, byte elements = 16, bool orderMatters = true)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 result;

                if (elements <= 8)
                {
                    result = cvtepi16_epi8(mullo_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b)));
                }
                else
                {
                    v128 even = mullo_epi16(a, b);
                    v128 odd = mullo_epi16(srli_epi16(a, 8), srli_epi16(b, 8));

                    if (orderMatters)
                    {
                        result = blendv_si128(even, slli_epi16(odd, 8), set1_epi16(0xFF00));
                    }
                    else
                    {
                        result = blendv_si128(slli_epi16(even, 8), odd, set1_epi16(0xFF00));
                    }
                }

                constexpr.ASSUME_MULTIPLICATION_EPI8(result, a, b, elements);

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vmulq_u8(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 mm256_impl_mullo_epi8(v256 a, v256 b, bool orderMatters = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                v256 even = Avx2.mm256_mullo_epi16(a, b);
                v256 odd = Avx2.mm256_mullo_epi16(Avx2.mm256_srli_epi16(a, 8), Avx2.mm256_srli_epi16(b, 8));

                if (orderMatters)
                {
                    result = mm256_blendv_si256(even, Avx2.mm256_slli_epi16(odd, 8), new v256(0xFF00_FF00));
                }
                else
                {
                    result = mm256_blendv_si256(Avx2.mm256_slli_epi16(even, 8), odd, new v256(0xFF00_FF00));
                }

                constexpr.ASSUME_MULTIPLICATION_EPI8(result, a, b);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 impl_mullo_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.mullo_epi32(a, b);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 result;

                if (constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements)
                 && constexpr.ALL_LE_EPU32(b, byte.MaxValue, elements))
                {
                    result = mullo_epi16(a, b);
                }
                else
                {
                    if (elements == 2)
                    {
                        v128 a64 = shuffle_epi32(a, Sse.SHUFFLE(0, 1, 0, 0));
                        v128 b64 = shuffle_epi32(b, Sse.SHUFFLE(0, 1, 0, 0));

                        result = shuffle_epi32(mul_epu32(a64, b64), Sse.SHUFFLE(0, 0, 2, 0));
                    }
                    else
                    {
                        v128 even = mul_epu32(a, b);
                        v128 odd  = mul_epu32(bsrli_si128(a, sizeof(int)),
                                              bsrli_si128(b, sizeof(int)));

                        result = unpacklo_epi64(unpacklo_epi32(even, odd),
                                                unpackhi_epi32(even, odd));
                    }
                }

                constexpr.ASSUME_MULTIPLICATION_EPI32(result, a, b, elements);

                return result;
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vmulq_s32(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw_epi8(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return mulw2x2_epi8(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw_epu8(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return mulw2x2_epu8(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw_epi16(v128 a, v128 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return mullo_epi32(cvtepi16_epi32(a), cvtepi16_epi32(b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return unpacklo_epi16(mullo_epi16(a, b), mulhi_epi16(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return mulw2x2_epi16(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw_epu16(v128 a, v128 b)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return mullo_epi32(cvtepu16_epi32(a), cvtepu16_epi32(b));
            }
            else if (Sse2.IsSse2Supported)
            {
                return unpacklo_epi16(mullo_epi16(a, b), mulhi_epu16(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return mulw2x2_epu16(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw_epi32(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return mulw2x2_epi32(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw_epu32(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return mulw2x2_epu32(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi16(Avx2.mm256_cvtepi8_epi16(Avx.mm256_castsi256_si128(a)), Avx2.mm256_cvtepi8_epi16(Avx.mm256_castsi256_si128(b)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw_epu8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi16(Avx2.mm256_cvtepu8_epi16(Avx.mm256_castsi256_si128(a)), Avx2.mm256_cvtepu8_epi16(Avx.mm256_castsi256_si128(b)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi32(Avx2.mm256_cvtepi16_epi32(Avx.mm256_castsi256_si128(a)), Avx2.mm256_cvtepi16_epi32(Avx.mm256_castsi256_si128(b)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw_epu16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi32(Avx2.mm256_cvtepu16_epi32(Avx.mm256_castsi256_si128(a)), Avx2.mm256_cvtepu16_epi32(Avx.mm256_castsi256_si128(b)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw_epi32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_mulw2x2_epi32(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_mulw2x2_epu32(a, b, out _);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw2x2_epi8(v128 a, v128 b, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = cvt2x2epi8_epi16(a, out v128 aHi);
                v128 bLo = cvt2x2epi8_epi16(b, out v128 bHi);

                hi = mullo_epi16(aHi, bHi);
                return mullo_epi16(aLo, bLo);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                hi = Arm.Neon.vmull_high_s8(a, b);
                return Arm.Neon.vmull_s8(Arm.Neon.vget_low_s8(a), Arm.Neon.vget_low_s8(b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw2x2_epu8(v128 a, v128 b, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 aLo = cvt2x2epu8_epi16(a, out v128 aHi);
                v128 bLo = cvt2x2epu8_epi16(b, out v128 bHi);

                hi = mullo_epi16(aHi, bHi);
                return mullo_epi16(aLo, bLo);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                hi = Arm.Neon.vmull_high_u8(a, b);
                return Arm.Neon.vmull_u8(Arm.Neon.vget_low_u8(a), Arm.Neon.vget_low_u8(b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw2x2_epi16(v128 a, v128 b, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi = unpackhi_epi16(mullo_epi16(a, b), mulhi_epi16(a, b));
                return unpacklo_epi16(mullo_epi16(a, b), mulhi_epi16(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                hi = Arm.Neon.vmull_high_s16(a, b);
                return Arm.Neon.vmull_s16(Arm.Neon.vget_low_s16(a), Arm.Neon.vget_low_s16(b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw2x2_epu16(v128 a, v128 b, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi = unpackhi_epi16(mullo_epi16(a, b), mulhi_epu16(a, b));
                return unpacklo_epi16(mullo_epi16(a, b), mulhi_epu16(a, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                hi = Arm.Neon.vmull_high_u16(a, b);
                return Arm.Neon.vmull_u16(Arm.Neon.vget_low_u16(a), Arm.Neon.vget_low_u16(b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw2x2_epi32(v128 a, v128 b, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi = mul_epi32(unpackhi_epi32(a, a), unpackhi_epi32(b, b));
                return mul_epi32(unpacklo_epi32(a, a), unpacklo_epi32(b, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                hi = Arm.Neon.vmull_high_s32(a, b);
                return Arm.Neon.vmull_s32(Arm.Neon.vget_low_s32(a), Arm.Neon.vget_low_s32(b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mulw2x2_epu32(v128 a, v128 b, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi = mul_epu32(unpackhi_epi32(a, a), unpackhi_epi32(b, b));
                return mul_epu32(unpacklo_epi32(a, a), unpacklo_epi32(b, b));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                hi = Arm.Neon.vmull_high_u32(a, b);
                return Arm.Neon.vmull_u32(Arm.Neon.vget_low_u32(a), Arm.Neon.vget_low_u32(b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw2x2_epi8(v256 a, v256 b, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 aLo = mm256_cvt2x2epi8_epi16(a, out v256 aHi);
                v256 bLo = mm256_cvt2x2epi8_epi16(b, out v256 bHi);

                hi = Avx2.mm256_mullo_epi16(aHi, bHi);
                return Avx2.mm256_mullo_epi16(aLo, bLo);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw2x2_epu8(v256 a, v256 b, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 aLo = mm256_cvt2x2epu8_epi16(a, out v256 aHi);
                v256 bLo = mm256_cvt2x2epu8_epi16(b, out v256 bHi);

                hi = Avx2.mm256_mullo_epi16(aHi, bHi);
                return Avx2.mm256_mullo_epi16(aLo, bLo);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw2x2_epi16(v256 a, v256 b, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi = Avx2.mm256_unpackhi_epi16(Avx2.mm256_mullo_epi16(a, b), Avx2.mm256_mulhi_epi16(a, b));
                return Avx2.mm256_unpacklo_epi16(Avx2.mm256_mullo_epi16(a, b), Avx2.mm256_mulhi_epi16(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw2x2_epu16(v256 a, v256 b, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi = Avx2.mm256_unpackhi_epi16(Avx2.mm256_mullo_epi16(a, b), Avx2.mm256_mulhi_epu16(a, b));
                return Avx2.mm256_unpacklo_epi16(Avx2.mm256_mullo_epi16(a, b), Avx2.mm256_mulhi_epu16(a, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw2x2_epi32(v256 a, v256 b, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi = Avx2.mm256_mul_epi32(Avx2.mm256_unpackhi_epi32(a, a), Avx2.mm256_unpackhi_epi32(b, b));
                return Avx2.mm256_mul_epi32(Avx2.mm256_unpacklo_epi32(a, a), Avx2.mm256_unpacklo_epi32(b, b));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_mulw2x2_epu32(v256 a, v256 b, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi = Avx2.mm256_mul_epu32(Avx2.mm256_unpackhi_epi32(a, a), Avx2.mm256_unpackhi_epi32(b, b));
                return Avx2.mm256_mul_epu32(Avx2.mm256_unpacklo_epi32(a, a), Avx2.mm256_unpacklo_epi32(b, b));
            }
            else throw new IllegalInstructionException();
        }
    }
}