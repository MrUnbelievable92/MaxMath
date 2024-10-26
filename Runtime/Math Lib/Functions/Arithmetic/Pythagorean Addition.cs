using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using Unity.Burst.CompilerServices;
using System.Numerics;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 naivehypot_ps(v128 a, v128 b)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(a))
				{
					return sqrt_ps(fmadd_ps(b, b, mul_ps(a, a)));
				}
				else
				{
					return sqrt_ps(fmadd_ps(a, a, mul_ps(b, b)));
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 naivehypot_pd(v128 a, v128 b)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(a))
				{
					return sqrt_pd(fmadd_pd(b, b, mul_pd(a, a)));
				}
				else
				{
					return sqrt_pd(fmadd_pd(a, a, mul_pd(b, b)));
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_naivehypot_ps(v256 a, v256 b)
		{
			if (Avx.IsAvxSupported)
			{
				if (constexpr.IS_CONST(a))
				{
					return Avx.mm256_sqrt_ps(mm256_fmadd_ps(b, b, Avx.mm256_mul_ps(a, a)));
				}
				else
				{
					return Avx.mm256_sqrt_ps(mm256_fmadd_ps(a, a, Avx.mm256_mul_ps(b, b)));
				}
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_naivehypot_pd(v256 a, v256 b)
		{
			if (Avx.IsAvxSupported)
			{
				if (constexpr.IS_CONST(a))
				{
					return Avx.mm256_sqrt_pd(mm256_fmadd_pd(b, b, Avx.mm256_mul_pd(a, a)));
				}
				else
				{
					return Avx.mm256_sqrt_pd(mm256_fmadd_pd(a, a, Avx.mm256_mul_pd(b, b)));
				}
			}
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hypot_ps(v128 a, v128 b, byte elements = 4)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low)
				{
					return naivehypot_ps(a, b);
				}

				minmax_ps(abs_ps(a, elements), abs_ps(b, elements), out v128 min, out v128 max);

				v128 e = and_ps(max, set1_epi32(0x7C00_0000));
				v128 scalePre = sub_epi32(set1_epi32(0x7E00_0000), e);
				v128 scalePost = add_epi32(set1_epi32(0x0100_0000), e);
			
				min = mul_ps(min, scalePre);
				max = mul_ps(max, scalePre);

				v128 r = sqrt_ps(fmadd_ps(max, max, mul_ps(min, min)));

				if (!COMPILATION_OPTIONS.FLOAT_NO_NAN)
				{
					scalePost = or_ps(scalePost, cmpunord_ps(a, b));
				}
				if (!COMPILATION_OPTIONS.FLOAT_NO_INF)
				{
					scalePost = blendv_si128(scalePost, set1_ps(float.PositiveInfinity), cmpeq_ps(max, set1_ps(float.PositiveInfinity)));
				}
  
				return mul_ps(r, scalePost);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hypot_pd(v128 a, v128 b)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low)
				{
					return naivehypot_pd(a, b);
				}

				minmax_pd(abs_pd(a), abs_pd(b), out v128 min, out v128 max);
				
				v128 e = and_pd(max, set1_epi64x(0x7F80_0000_0000_0000ul));
				v128 scalePre = sub_epi64(set1_epi64x(0x7FC0_0000_0000_0000ul), e);
				v128 scalePost = add_epi64(set1_epi64x(0x0020_0000_0000_0000ul), e);
			
				min = mul_pd(min, scalePre);
				max = mul_pd(max, scalePre);

				v128 r = sqrt_pd(fmadd_pd(max, max, mul_pd(min, min)));

				if (!COMPILATION_OPTIONS.FLOAT_NO_NAN)
				{
					scalePost = or_pd(scalePost, cmpunord_pd(a, b));
				}
				if (!COMPILATION_OPTIONS.FLOAT_NO_INF)
				{
					scalePost = blendv_si128(scalePost, set1_pd(double.PositiveInfinity), cmpeq_pd(max, set1_pd(double.PositiveInfinity)));
				}
  
				return mul_pd(r, scalePost);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_hypot_ps(v256 a, v256 b)
		{
			if (Avx.IsAvxSupported)
			{
				if (COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low)
				{
					return mm256_naivehypot_ps(a, b);
				}

				mm256_minmax_ps(mm256_abs_ps(a), mm256_abs_ps(b), out v256 min, out v256 max);

				v256 e = Avx.mm256_and_ps(max, mm256_set1_epi32(0x7C00_0000));
				v256 scalePre;
				v256 scalePost;
				if (Avx2.IsAvx2Supported)
				{
					scalePre = Avx2.mm256_sub_epi32(mm256_set1_epi32(0x7E00_0000), e);
					scalePost = Avx2.mm256_add_epi32(mm256_set1_epi32(0x0100_0000), e);
				}
				else
				{
					v128 loE = Avx.mm256_castsi256_si128(e);
					v128 hiE = Avx.mm256_extractf128_si256(e, 0);

					scalePre = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(sub_epi32(set1_epi32(0x7E00_0000), loE)), sub_epi32(set1_epi32(0x7E00_0000), hiE), 1);
					scalePost = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(add_epi32(set1_epi32(0x0100_0000), loE)), add_epi32(set1_epi32(0x0100_0000), hiE), 1);
				}
					
				min = Avx.mm256_mul_ps(min, scalePre);
				max = Avx.mm256_mul_ps(max, scalePre);

				v256 r = Avx.mm256_sqrt_ps(mm256_fmadd_ps(max, max, Avx.mm256_mul_ps(min, min)));

				if (!COMPILATION_OPTIONS.FLOAT_NO_NAN)
				{
					scalePost = Avx.mm256_or_ps(scalePost, mm256_cmpunord_ps(a, b));
				}
				if (!COMPILATION_OPTIONS.FLOAT_NO_INF)
				{
					scalePost = mm256_blendv_si256(scalePost, mm256_set1_ps(float.PositiveInfinity), mm256_cmpeq_ps(max, mm256_set1_ps(float.PositiveInfinity)));
				}
  
				return Avx.mm256_mul_ps(r, scalePost);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_hypot_pd(v256 a, v256 b)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low)
				{
					return mm256_naivehypot_pd(a, b);
				}

				mm256_minmax_pd(mm256_abs_pd(a), mm256_abs_pd(b), out v256 min, out v256 max);

				v256 e = Avx.mm256_and_pd(max, mm256_set1_epi64x(0x7F80_0000_0000_0000ul));
				v256 scalePre;
				v256 scalePost;
				if (Avx2.IsAvx2Supported)
				{
					scalePre = Avx2.mm256_sub_epi64(mm256_set1_epi64x(0x7FC0_0000_0000_0000ul), e);
					scalePost = Avx2.mm256_add_epi64(mm256_set1_epi64x(0x0020_0000_0000_0000ul), e);
				}
				else
				{
					v128 loE = Avx.mm256_castsi256_si128(e);
					v128 hiE = Avx.mm256_extractf128_si256(e, 0);

					scalePre = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(sub_epi64(set1_epi64x(0x7FC0_0000_0000_0000ul), loE)), sub_epi64(set1_epi64x(0x7FC0_0000_0000_0000ul), hiE), 1);
					scalePost = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(add_epi64(set1_epi64x(0x0020_0000_0000_0000ul), loE)), add_epi64(set1_epi64x(0x0020_0000_0000_0000ul), hiE), 1);
				}
					
				min = Avx.mm256_mul_pd(min, scalePre);
				max = Avx.mm256_mul_pd(max, scalePre);

				v256 r = Avx.mm256_sqrt_pd(mm256_fmadd_pd(max, max, Avx.mm256_mul_pd(min, min)));

				if (!COMPILATION_OPTIONS.FLOAT_NO_NAN)
				{
					scalePost = Avx.mm256_or_pd(scalePost, mm256_cmpunord_pd(a, b));
				}
				if (!COMPILATION_OPTIONS.FLOAT_NO_INF)
				{
					scalePost = mm256_blendv_si256(scalePost, mm256_set1_pd(float.PositiveInfinity), mm256_cmpeq_pd(max, mm256_set1_pd(float.PositiveInfinity)));
				}
  
				return Avx.mm256_mul_pd(r, scalePost);
			}
			else throw new IllegalInstructionException();
		}

		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hypotepi8_ps(v128 a, v128 b)
		{
			if (Architecture.IsSIMDSupported)
			{
				v128 result = hypotepi16_ps(cvtepi8_epi16(a), cvtepi8_epi16(b));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2 * sbyte.MinValue * sbyte.MinValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void hypotepi8_ps(v128 a, v128 b, [NoAlias] out v128 lo, [NoAlias] out v128 hi)
		{
			if (Architecture.IsSIMDSupported)
			{
				hypotepi16_ps(cvtepi8_epi16(a), cvtepi8_epi16(b), out lo, out hi);
				constexpr.ASSUME_RANGE_PS(lo, 0f, math.sqrt(2 * sbyte.MinValue * sbyte.MinValue));
				constexpr.ASSUME_RANGE_PS(hi, 0f, math.sqrt(2 * sbyte.MinValue * sbyte.MinValue));
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_hypotepi8_ps(v128 a, v128 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 result = mm256_hypotepi16_ps(cvtepi8_epi16(a), cvtepi8_epi16(b));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2 * sbyte.MinValue * sbyte.MinValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hypotepu8_ps(v128 a, v128 b)
		{
			if (Architecture.IsSIMDSupported)
			{
				v128 result = hypotepi16_ps(cvtepu8_epi16(a), cvtepu8_epi16(b));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2 * byte.MaxValue * byte.MaxValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void hypotepu8_ps(v128 a, v128 b, [NoAlias] out v128 lo, [NoAlias] out v128 hi)
		{
			if (Architecture.IsSIMDSupported)
			{
				hypotepi16_ps(cvtepu8_epi16(a), cvtepu8_epi16(b), out lo, out hi);
				constexpr.ASSUME_RANGE_PS(lo, 0f, math.sqrt(2 * byte.MaxValue * byte.MaxValue));
				constexpr.ASSUME_RANGE_PS(hi, 0f, math.sqrt(2 * byte.MaxValue * byte.MaxValue));
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_hypotepu8_ps(v128 a, v128 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 result = mm256_hypotepi16_ps(cvtepu8_epi16(a), cvtepu8_epi16(b));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2 * byte.MaxValue * byte.MaxValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hypotepi16_ps(v128 a, v128 b)
		{
			if (Architecture.IsSIMDSupported)
			{
				v128 interleaved = unpacklo_epi16(a, b);
				
				v128 result = sqrt_ps(cvtepi32_ps(madd_epi16(interleaved, interleaved)));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2L * short.MinValue * short.MinValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void hypotepi16_ps(v128 a, v128 b, [NoAlias] out v128 lo, [NoAlias] out v128 hi)
		{
			if (Architecture.IsSIMDSupported)
			{
				lo = unpacklo_epi16(a, b);
				hi = unpackhi_epi16(a, b);
				lo = sqrt_ps(cvtepi32_ps(madd_epi16(lo, lo)));
				hi = sqrt_ps(cvtepi32_ps(madd_epi16(hi, hi)));	
				constexpr.ASSUME_RANGE_PS(lo, 0f, math.sqrt(2L * short.MinValue * short.MinValue));
				constexpr.ASSUME_RANGE_PS(hi, 0f, math.sqrt(2L * short.MinValue * short.MinValue));
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_hypotepi16_ps(v128 a, v128 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				v128 lo = unpacklo_epi16(a, b);
				v128 hi = unpackhi_epi16(a, b);
				v256 combined = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(lo), hi, 1);
				v256 result = Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(Avx2.mm256_madd_epi16(combined, combined)));

				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2L * short.MinValue * short.MinValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 hypotepu16_ps(v128 a, v128 b, byte elements = 4)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (constexpr.ALL_LE_EPU16(a, 1 << 15, elements)
			     && constexpr.ALL_LE_EPU16(b, 1 << 15, elements))
				{
					v128 shortResult = hypotepi16_ps(a, b);
					constexpr.ASSUME_LE_PS(shortResult, math.sqrt(2 * (((1 << 15) - 1) * ((1 << 15) - 1))), elements);
					return shortResult;
				}
				
				v128 result = naivehypot_ps(cvtepu16_ps(a), cvtepu16_ps(b));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2L * ushort.MaxValue * ushort.MaxValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void hypotepu16_ps(v128 a, v128 b, [NoAlias] out v128 lo, [NoAlias] out v128 hi)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (constexpr.ALL_LE_EPU16(a, 1 << 15, 8)
			     && constexpr.ALL_LE_EPU16(b, 1 << 15, 8))
				{
					hypotepi16_ps(a, b, out lo, out hi);
					constexpr.ASSUME_LE_PS(lo, math.sqrt(2 * (((1 << 15) - 1) * ((1 << 15) - 1))), 8);
					constexpr.ASSUME_LE_PS(hi, math.sqrt(2 * (((1 << 15) - 1) * ((1 << 15) - 1))), 8);

					return;
				}
				
				v128 aLo = cvt2x2epu16_ps(a, out v128 aHi);
				v128 bLo = cvt2x2epu16_ps(b, out v128 bHi);
				lo = naivehypot_ps(aLo, bLo);
				hi = naivehypot_ps(aHi, bHi);

				constexpr.ASSUME_RANGE_PS(lo, 0f, math.sqrt(2L * ushort.MaxValue * ushort.MaxValue));
				constexpr.ASSUME_RANGE_PS(hi, 0f, math.sqrt(2L * ushort.MaxValue * ushort.MaxValue));
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_hypotepu16_ps(v128 a, v128 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 result = mm256_naivehypot_ps(mm256_cvtepu16_ps(a), mm256_cvtepu16_ps(b));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2L * ushort.MaxValue * ushort.MaxValue));
				return result;
			}
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epu8(v128 a, v128 b, byte elements = 16)
		{
			if (Architecture.IsSIMDSupported)
			{
				return ihypot_ep8(a, b, false, elements);
			}
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epi8(v128 a, v128 b, byte elements = 16)
		{
			if (Architecture.IsSIMDSupported)
			{
				return ihypot_ep8(a, b, true, elements);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static v128 ihypot_ep8(v128 a, v128 b, bool signed, byte elements = 16)
		{
			if (Architecture.IsSIMDSupported)
			{
				switch (elements)
				{
					case 2:
					case 3:
					case 4:
					{
						a = signed ? cvtepi8_epi16(a) : cvtepu8_epi16(a);
						b = signed ? cvtepi8_epi16(b) : cvtepu8_epi16(b);

						v128 interleaved = unpacklo_epi16(a, b);

						return cvttps_epi8(sqrt_ps(cvtepi32_ps(madd_epi16(interleaved, interleaved))), elements);
					}
					case 8:
					{
						a = signed ? cvtepi8_epi16(a) : cvtepu8_epi16(a);
						b = signed ? cvtepi8_epi16(b) : cvtepu8_epi16(b);
						
						v128 lo = unpacklo_epi16(a, b);
						v128 hi = unpackhi_epi16(a, b);
						
						v128 lo32 = cvttps_epi32(sqrt_ps(cvtepi32_ps(madd_epi16(lo, lo))));
						v128 hi32 = cvttps_epi32(sqrt_ps(cvtepi32_ps(madd_epi16(hi, hi))));

						v128 _16 = packs_epi32(lo32, hi32);

						return packus_epi16(_16, _16); 
					}
					default:
					{
						v128 aLo = signed ? cvt2x2epi8_epi16(a, out v128 aHi) : cvt2x2epu8_epi16(a, out aHi);
						v128 bLo = signed ? cvt2x2epi8_epi16(b, out v128 bHi) : cvt2x2epu8_epi16(b, out bHi);
						
						v128 x0 = unpacklo_epi16(aLo, bLo);
						v128 x1 = unpackhi_epi16(aLo, bLo);
						v128 x2 = unpacklo_epi16(aHi, bHi);
						v128 x3 = unpackhi_epi16(aHi, bHi);
						
						v128 x0_32 = cvttps_epi32(sqrt_ps(cvtepi32_ps(madd_epi16(x0, x0))));
						v128 x1_32 = cvttps_epi32(sqrt_ps(cvtepi32_ps(madd_epi16(x1, x1))));
						v128 x2_32 = cvttps_epi32(sqrt_ps(cvtepi32_ps(madd_epi16(x2, x2))));
						v128 x3_32 = cvttps_epi32(sqrt_ps(cvtepi32_ps(madd_epi16(x3, x3))));
						
						v128 x0_16 = packs_epi32(x0_32, x1_32);
						v128 x1_16 = packs_epi32(x2_32, x3_32);

						return packus_epi16(x0_16, x1_16); 
					}
				}	
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epu8(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_ihypot_ep8(a, b, false);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epi8(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				return mm256_ihypot_ep8(a, b, true);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static v256 mm256_ihypot_ep8(v256 a, v256 b, bool signed)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 aLo = signed ? mm256_cvt2x2epi8_epi16(a, out v256 aHi) : mm256_cvt2x2epu8_epi16(a, out aHi);
				v256 bLo = signed ? mm256_cvt2x2epi8_epi16(b, out v256 bHi) : mm256_cvt2x2epu8_epi16(b, out bHi);
				
				v256 x0 = Avx2.mm256_unpacklo_epi16(aLo, bLo);
				v256 x1 = Avx2.mm256_unpackhi_epi16(aLo, bLo);
				v256 x2 = Avx2.mm256_unpacklo_epi16(aHi, bHi);
				v256 x3 = Avx2.mm256_unpackhi_epi16(aHi, bHi);

				v256 x0_32 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(Avx2.mm256_madd_epi16(x0, x0))));
				v256 x1_32 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(Avx2.mm256_madd_epi16(x1, x1))));
				v256 x2_32 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(Avx2.mm256_madd_epi16(x2, x2))));
				v256 x3_32 = Avx.mm256_cvttps_epi32(Avx.mm256_sqrt_ps(Avx.mm256_cvtepi32_ps(Avx2.mm256_madd_epi16(x3, x3))));

				v256 x0_16 = Avx2.mm256_packs_epi32(x0_32, x1_32);
				v256 x1_16 = Avx2.mm256_packs_epi32(x2_32, x3_32);
				
				return Avx2.mm256_packus_epi16(x0_16, x1_16); 
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epi16(v128 a, v128 b, byte elements = 8)
		{
			if (Architecture.IsSIMDSupported)
			{
				switch (elements)
				{
					case 2:
					case 3:
					case 4:
					{
						v128 interleaved = unpacklo_epi16(a, b);

						return cvtepi32_epi16(sqrt_epu32(madd_epi16(interleaved, interleaved), elements), elements);
					}
					default:
					{
						v128 lo = unpacklo_epi16(a, b);
						v128 hi = unpackhi_epi16(a, b);

						v128 lo32 = sqrt_epu32(madd_epi16(lo, lo));
						v128 hi32 = sqrt_epu32(madd_epi16(hi, hi));

						if (Sse4_1.IsSse41Supported)
						{
							return packus_epi32(lo32, hi32);
						}
						else
						{
							return cvt2x2epi32_epi16(lo32, hi32);
						}
					}
				}	
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epi16(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 lo = Avx2.mm256_unpacklo_epi16(a, b);
				v256 hi = Avx2.mm256_unpackhi_epi16(a, b);

				v256 lo32 = mm256_sqrt_epu32(Avx2.mm256_madd_epi16(lo, lo));
				v256 hi32 = mm256_sqrt_epu32(Avx2.mm256_madd_epi16(hi, hi));
				
				return Avx2.mm256_packus_epi32(lo32, hi32);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epu16(v128 a, v128 b, byte elements = 8)
		{
			if (Architecture.IsSIMDSupported)
			{
				switch (elements)
				{
					case 2:
					case 3:
					case 4:
					{
						v128 a32sq = mulw_epu16(a, a);
						v128 b32sq = mulw_epu16(b, b);

						return cvtepi32_epi16(sqrt_epu32(add_epi32(a32sq, b32sq), elements), elements);
					}
					default:
					{
						v128 a32sq_Lo = mulw2x2_epu16(a, a, out v128 a32sq_Hi);
						v128 b32sq_Lo = mulw2x2_epu16(b, b, out v128 b32sq_Hi);

						v128 lo32 = sqrt_epu32(add_epi32(a32sq_Lo, b32sq_Lo));
						v128 hi32 = sqrt_epu32(add_epi32(a32sq_Hi, b32sq_Hi));

						if (Sse4_1.IsSse41Supported)
						{
							return packus_epi32(lo32, hi32);
						}
						else
						{
							return cvt2x2epi32_epi16(lo32, hi32);
						}
					}
				}	
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epu16(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 a32sq_Lo = mm256_mulw2x2_epu16(a, a, out v256 a32sq_Hi);
				v256 b32sq_Lo = mm256_mulw2x2_epu16(b, b, out v256 b32sq_Hi);
				
				v256 lo32 = mm256_sqrt_epu32(Avx2.mm256_add_epi32(a32sq_Lo, b32sq_Lo));
				v256 hi32 = mm256_sqrt_epu32(Avx2.mm256_add_epi32(a32sq_Hi, b32sq_Hi));
				
				return Avx2.mm256_packus_epi32(lo32, hi32);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epi32(v128 a, v128 b, bool noOverflow = false, byte elements = 4)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					return sqrt_epu32(add_epi32(square_epi32(a), square_epi32(b)));
				}
				else
				{
					bool sqrtepi = constexpr.ALL_NEQ_EPI32(a, int.MinValue) 
								|| constexpr.ALL_NEQ_EPI32(b, int.MinValue);

					switch (elements)
					{
						case 2:
						{
							v128 a64sq = mulw_epi32(a, a);
							v128 b64sq = mulw_epi32(b, b);
							v128 sum = add_epi64(a64sq, b64sq);

							return cvtepi64_epi32(sqrtepi ? sqrt_epi64(sum) : sqrt_epu64(sum));
						}
						default:
						{
							v128 a64sq_Lo = mulw2x2_epi32(a, a, out v128 a64sq_Hi);
							v128 b64sq_Lo = mulw2x2_epi32(b, b, out v128 b64sq_Hi);

							if (Avx2.IsAvx2Supported)
							{
								v256 a64sq = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(a64sq_Lo), a64sq_Hi, 1);
								v256 b64sq = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(b64sq_Lo), b64sq_Hi, 1);
								v256 sum = Avx2.mm256_add_epi64(a64sq, b64sq);

								v256 _64 = sqrtepi ? mm256_sqrt_epi64(sum, elements) : mm256_sqrt_epu64(sum, elements);

								return mm256_cvtepi64_epi32(_64);
							}
							else
							{
								v128 lo64;
								v128 hi64;

								if (sqrtepi)
								{
									sqrt_epi64x2(add_epi64(a64sq_Lo, b64sq_Lo),
												 add_epi64(a64sq_Hi, b64sq_Hi),
												 out lo64,
												 out hi64);
								}
								else
								{
									sqrt_epu64x2(add_epi64(a64sq_Lo, b64sq_Lo),
												 add_epi64(a64sq_Hi, b64sq_Hi),
												 out lo64,
												 out hi64);
								}

								return cvt2x2epi64_epi32(lo64, hi64);
							}
						}
					}	
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ihypot_epi32x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool noOverflow = false)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					r0 = sqrt_epu32(add_epi32(square_epi32(a0), square_epi32(b0)));
					r1 = sqrt_epu32(add_epi32(square_epi32(a1), square_epi32(b1)));
				}
				else
				{
					bool sqrtepi = (constexpr.ALL_NEQ_EPI32(a0, int.MinValue) || constexpr.ALL_NEQ_EPI32(b0, int.MinValue)) 
								&& (constexpr.ALL_NEQ_EPI32(a1, int.MinValue) || constexpr.ALL_NEQ_EPI32(b1, int.MinValue));

					v128 a0_64sq_Lo = mulw2x2_epi32(a0, a0, out v128 a0_64sq_Hi);
					v128 a1_64sq_Lo = mulw2x2_epi32(a1, a1, out v128 a1_64sq_Hi);
					v128 b0_64sq_Lo = mulw2x2_epi32(b0, b0, out v128 b0_64sq_Hi);
					v128 b1_64sq_Lo = mulw2x2_epi32(b1, b1, out v128 b1_64sq_Hi);
					
					v128 lo0_64;
					v128 hi0_64;
					v128 lo1_64;
					v128 hi1_64;
					if (sqrtepi)
					{
						sqrt_epi64x4(add_epi64(a0_64sq_Lo, b0_64sq_Lo),
									 add_epi64(a0_64sq_Hi, b0_64sq_Hi),
									 add_epi64(a1_64sq_Lo, b1_64sq_Lo),
									 add_epi64(a1_64sq_Hi, b1_64sq_Hi),
									 out lo0_64,
									 out hi0_64,
									 out lo1_64,
									 out hi1_64);
					}
					else
					{
						sqrt_epu64x4(add_epi64(a0_64sq_Lo, b0_64sq_Lo),
									 add_epi64(a0_64sq_Hi, b0_64sq_Hi),
									 add_epi64(a1_64sq_Lo, b1_64sq_Lo),
									 add_epi64(a1_64sq_Hi, b1_64sq_Hi),
									 out lo0_64,
									 out hi0_64,
									 out lo1_64,
									 out hi1_64);
					}
					
					r0 = cvt2x2epi64_epi32(lo0_64, hi0_64);
					r1 = cvt2x2epi64_epi32(lo1_64, hi1_64);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epi32(v256 a, v256 b, bool noOverflow = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (noOverflow)
				{
					return mm256_sqrt_epu32(Avx2.mm256_add_epi32(mm256_square_epi32(a), mm256_square_epi32(b)));
				}
				else
				{
					bool sqrtepi = constexpr.ALL_NEQ_EPI32(a, int.MinValue) 
								|| constexpr.ALL_NEQ_EPI32(b, int.MinValue);

					v256 a64sq_Lo = mm256_mulw2x2_epi32(a, a, out v256 a64sq_Hi);
					v256 b64sq_Lo = mm256_mulw2x2_epi32(b, b, out v256 b64sq_Hi);

					v256 lo64;
					v256 hi64;
					if (sqrtepi)
					{
						mm256_sqrt_epi64x2(Avx2.mm256_add_epi64(a64sq_Lo, b64sq_Lo),
										   Avx2.mm256_add_epi64(a64sq_Hi, b64sq_Hi),
										   out lo64,
										   out hi64);
					}
					else
					{
						mm256_sqrt_epu64x2(Avx2.mm256_add_epi64(a64sq_Lo, b64sq_Lo),
										   Avx2.mm256_add_epi64(a64sq_Hi, b64sq_Hi),
										   out lo64,
										   out hi64);
					}
					
					return mm256_cvt2x2epi64_epi32(lo64, hi64);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epu32(v128 a, v128 b, byte elements = 8, bool noOverflow = false)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					return sqrt_epu32(add_epi32(square_epi32(a), square_epi32(b)));
				}
				else
				{
					switch (elements)
					{
						case 2:
						{
							v128 a64sq = mulw_epu32(a, a);
							v128 b64sq = mulw_epu32(b, b);

							return cvtepi64_epi32(sqrt_epu64(add_epi64(a64sq, b64sq)));
						}
						default:
						{
							v128 a64sq_Lo = mulw2x2_epu32(a, a, out v128 a64sq_Hi);
							v128 b64sq_Lo = mulw2x2_epu32(b, b, out v128 b64sq_Hi);

							if (Avx2.IsAvx2Supported)
							{
								v256 a64sq = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(a64sq_Lo), a64sq_Hi, 1);
								v256 b64sq = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(b64sq_Lo), b64sq_Hi, 1);

								v256 _64 = mm256_sqrt_epu64(Avx2.mm256_add_epi64(a64sq, b64sq), elements);

								return mm256_cvtepi64_epi32(_64);
							}
							else
							{
								sqrt_epu64x2(add_epi64(a64sq_Lo, b64sq_Lo),
											 add_epi64(a64sq_Hi, b64sq_Hi),
											 out v128 lo64,
											 out v128 hi64);

								return cvt2x2epi64_epi32(lo64, hi64);
							}
						}
					}	
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ihypot_epu32x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool noOverflow = false)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					r0 = sqrt_epu32(add_epi32(square_epi32(a0), square_epi32(b0)));
					r1 = sqrt_epu32(add_epi32(square_epi32(a1), square_epi32(b1)));
				}
				else
				{
					v128 a0_64sq_Lo = mulw2x2_epu32(a0, a0, out v128 a0_64sq_Hi);
					v128 a1_64sq_Lo = mulw2x2_epu32(a1, a1, out v128 a1_64sq_Hi);
					v128 b0_64sq_Lo = mulw2x2_epu32(b0, b0, out v128 b0_64sq_Hi);
					v128 b1_64sq_Lo = mulw2x2_epu32(b1, b1, out v128 b1_64sq_Hi);
					
					sqrt_epu64x4(add_epi64(a0_64sq_Lo, b0_64sq_Lo),
								 add_epi64(a0_64sq_Hi, b0_64sq_Hi),
								 add_epi64(a1_64sq_Lo, b1_64sq_Lo),
								 add_epi64(a1_64sq_Hi, b1_64sq_Hi),
								 out v128 lo0_64,
								 out v128 hi0_64,
								 out v128 lo1_64,
								 out v128 hi1_64);
					
					r0 = cvt2x2epi64_epi32(lo0_64, hi0_64);
					r1 = cvt2x2epi64_epi32(lo1_64, hi1_64);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epu32(v256 a, v256 b, bool noOverflow = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (noOverflow)
				{
					return mm256_sqrt_epu32(Avx2.mm256_add_epi32(mm256_square_epi32(a), mm256_square_epi32(b)));
				}
				else
				{
					v256 a64sq_Lo = mm256_mulw2x2_epu32(a, a, out v256 a64sq_Hi);
					v256 b64sq_Lo = mm256_mulw2x2_epu32(b, b, out v256 b64sq_Hi);
					
					mm256_sqrt_epu64x2(Avx2.mm256_add_epi64(a64sq_Lo, b64sq_Lo),
									   Avx2.mm256_add_epi64(a64sq_Hi, b64sq_Hi),
									   out v256 lo64,
									   out v256 hi64);
					
					return mm256_cvt2x2epi64_epi32(lo64, hi64);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epi64(v128 a, v128 b, bool noOverflow = false)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					return sqrt_epu64(add_epi64(square_epi64(a), square_epi64(b)));
				}
				else
				{
					Int128 a0sq = UInt128.imul128(a.SLong0, a.SLong0);
					Int128 a1sq = UInt128.imul128(a.SLong1, a.SLong1);
					Int128 b0sq = UInt128.imul128(b.SLong0, b.SLong0);
					Int128 b1sq = UInt128.imul128(b.SLong1, b.SLong1);

					Int128 sum0 = a0sq + b0sq;
					Int128 sum1 = a1sq + b1sq;

					v128 lo = new v128(sum0.lo64, sum1.lo64);
					v128 hi = new v128(sum0.hi64, sum1.hi64);
						
					return sqrt_epu128(lo, hi);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ihypot_epi64x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool noOverflow = false, byte elements = 4)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					r0 = sqrt_epu64(add_epi64(square_epi64(a0), square_epi64(b0)));
					r1 = sqrt_epu64(add_epi64(square_epi64(a1), square_epi64(b1)));
				}
				else
				{
					Int128 a0_0sq = UInt128.imul128(a0.SLong0, a0.SLong0);
					Int128 a0_1sq = UInt128.imul128(a0.SLong1, a0.SLong1);
					Int128 b0_0sq = UInt128.imul128(b0.SLong0, b0.SLong0);
					Int128 b0_1sq = UInt128.imul128(b0.SLong1, b0.SLong1);
					Int128 a1_0sq = UInt128.imul128(a1.SLong0, a1.SLong0);
					Int128 b1_0sq = UInt128.imul128(b1.SLong0, b1.SLong0);

					Int128 sum0 = a0_0sq + b0_0sq;
					Int128 sum1 = a0_1sq + b0_1sq;
					Int128 sum2 = a1_0sq + b1_0sq;

					v128 lo0 = new v128(sum0.lo64, sum1.lo64);
					v128 hi0 = new v128(sum0.hi64, sum1.hi64);
					v128 lo1 = cvtsi64x_si128(sum2.lo64);
					v128 hi1 = cvtsi64x_si128(sum2.hi64);

					if (elements == 4)
					{
						Int128 a1_1sq = UInt128.imul128(a1.SLong1, a1.SLong1);
						Int128 b1_1sq = UInt128.imul128(b1.SLong1, b1.SLong1);
						Int128 sum3 = a1_1sq + b1_1sq;
						lo1 = unpacklo_epi64(lo1, cvtsi64x_si128(sum3.lo64));
						hi1 = unpacklo_epi64(hi1, cvtsi64x_si128(sum3.hi64));
					}
						
					sqrt_epu128x2(lo0, hi0, lo1, hi1, out r0, out r1, elements);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epi64(v256 a, v256 b, bool noOverflow = false, byte elements = 4)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (noOverflow)
				{
					return mm256_sqrt_epu64(Avx2.mm256_add_epi64(mm256_square_epi64(a), mm256_square_epi64(b)));
				}
				else
				{
					v256 asqHi = mm256_mulhi_epi64(a, a, out v256 asqLo);
					v256 bsqHi = mm256_mulhi_epi64(b, b, out v256 bsqLo);

					mm256_add_epi128(asqLo, asqHi, bsqLo, bsqHi, out v256 sumLo, out v256 sumHi);
						
					return mm256_sqrt_epu128(sumLo, sumHi, elements);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ihypot_epu64(v128 a, v128 b, bool noOverflow = false)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					return sqrt_epu64(add_epi64(square_epi64(a), square_epi64(b)));
				}
				else
				{
					UInt128 a0sq = UInt128.umul128(a.ULong0, a.ULong0);
					UInt128 a1sq = UInt128.umul128(a.ULong1, a.ULong1);
					UInt128 b0sq = UInt128.umul128(b.ULong0, b.ULong0);
					UInt128 b1sq = UInt128.umul128(b.ULong1, b.ULong1);

					UInt128 sum0 = a0sq + b0sq;
					UInt128 sum1 = a1sq + b1sq;

					v128 lo = new v128(sum0.lo64, sum1.lo64);
					v128 hi = new v128(sum0.hi64, sum1.hi64);
						
					return sqrt_epu128(lo, hi);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ihypot_epu64x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool noOverflow = false, byte elements = 4)
		{
			if (Architecture.IsSIMDSupported)
			{
				if (noOverflow)
				{
					r0 = sqrt_epu64(add_epi64(square_epi64(a0), square_epi64(b0)));
					r1 = sqrt_epu64(add_epi64(square_epi64(a1), square_epi64(b1)));
				}
				else
				{
					UInt128 a0_0sq = UInt128.umul128(a0.ULong0, a0.ULong0);
					UInt128 a0_1sq = UInt128.umul128(a0.ULong1, a0.ULong1);
					UInt128 b0_0sq = UInt128.umul128(b0.ULong0, b0.ULong0);
					UInt128 b0_1sq = UInt128.umul128(b0.ULong1, b0.ULong1);
					UInt128 a1_0sq = UInt128.umul128(a1.ULong0, a1.ULong0);
					UInt128 b1_0sq = UInt128.umul128(b1.ULong0, b1.ULong0);

					UInt128 sum0 = a0_0sq + b0_0sq;
					UInt128 sum1 = a0_1sq + b0_1sq;
					UInt128 sum2 = a1_0sq + b1_0sq;

					v128 lo0 = new v128(sum0.lo64, sum1.lo64);
					v128 hi0 = new v128(sum0.hi64, sum1.hi64);
					v128 lo1 = cvtsi64x_si128(sum2.lo64);
					v128 hi1 = cvtsi64x_si128(sum2.hi64);

					if (elements == 4)
					{
						UInt128 a1_1sq = UInt128.umul128(a1.ULong1, a1.ULong1);
						UInt128 b1_1sq = UInt128.umul128(b1.ULong1, b1.ULong1);
						UInt128 sum3 = a1_1sq + b1_1sq;
						lo1 = unpacklo_epi64(lo1, cvtsi64x_si128(sum3.lo64));
						hi1 = unpacklo_epi64(hi1, cvtsi64x_si128(sum3.hi64));
					}
						
					sqrt_epu128x2(lo0, hi0, lo1, hi1, out r0, out r1, elements);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ihypot_epu64(v256 a, v256 b, bool noOverflow = false, byte elements = 4)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (noOverflow)
				{
					return mm256_sqrt_epu64(Avx2.mm256_add_epi64(mm256_square_epi64(a, elements), mm256_square_epi64(b, elements)));
				}
				else
				{
					v256 asqHi = mm256_squarehi_epu64(a, out v256 asqLo, elements);
					v256 bsqHi = mm256_squarehi_epu64(b, out v256 bsqLo, elements);
					
					mm256_add_epi128(asqLo, asqHi, bsqLo, bsqHi, out v256 sumLo, out v256 sumHi);
						    
					return mm256_sqrt_epu128(sumLo, sumHi, elements);
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}


namespace MaxMath
{
    unsafe public static partial class maxmath
    {
		/// <summary>		Returns the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float hypot(byte x, byte y)
		{
			if (Sse2.IsSse2Supported)
			{
				v128 mov = Xse.cvtsi32_si128(constexpr.IS_CONST(x) ? y | (x << 16)
																   : x | (y << 16));

				v128 result = Xse.sqrt_ss(Xse.cvtepi32_ps(Xse.madd_epi16(mov, mov)));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2 * (byte.MaxValue * byte.MaxValue)));
				return result.Float0;
			}
			else
			{
				return math.sqrt(x * x + y * y);
			}
		}
		
		/// <summary>		Returns the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float hypot(ushort x, ushort y)
		{
			if (constexpr.IS_TRUE(x < 1 << 15 && y < 1 << 15))
			{
				float result = hypot((short)x, (short)y);
				constexpr.ASSUME(result <= math.sqrt(2 * (((1 << 15) - 1) * ((1 << 15) - 1))));
				return result;
			}
			
			return math.sqrt((uint)x * x + (uint)y * y);
		}
		
		/// <summary>		Returns the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float hypot(sbyte x, sbyte y)
		{
			if (Sse2.IsSse2Supported)
			{
				v128 mov = Xse.cvtsi32_si128(constexpr.IS_CONST(x) ? (uint)(ushort)(short)y | (uint)((short)x << 16)
																   : (uint)(ushort)(short)x | (uint)((short)y << 16));
		
				v128 result = Xse.sqrt_ss(Xse.cvtepi32_ps(Xse.madd_epi16(mov, mov)));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2 * (sbyte.MinValue * sbyte.MinValue)));
				return result.Float0;
			}
			else
			{
				return math.sqrt(x * x + y * y);
			}
		}
		
		/// <summary>		Returns the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float hypot(short x, short y)
		{
			if (Sse2.IsSse2Supported)
			{
				v128 mov = Xse.cvtsi32_si128(constexpr.IS_CONST(x) ? (uint)(ushort)y | (uint)(x << 16)
																   : (uint)(ushort)x | (uint)(y << 16));

				v128 result = Xse.sqrt_ss(Xse.cvtepi32_ps(Xse.madd_epi16(mov, mov)));
				constexpr.ASSUME_RANGE_PS(result, 0f, math.sqrt(2 * ((long)short.MinValue * short.MinValue)));
				return result.Float0;
			}
			else
			{
				return math.sqrt(x * x + y * y);
			}
		}
		
		/// <summary>		Returns the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="float.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="float.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="float"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float hypot(float x, float y, Promise noOverflow = Promise.Nothing)
		{
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				if (constexpr.IS_CONST(x))
				{
					return math.sqrt(math.mad(y, y, x * x));
				}
				else
				{
					return math.sqrt(math.mad(x, x, y * y));
				}
			}

			if (Architecture.IsSIMDSupported)
			{
				return Xse.hypot_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 1).Float0;
			}
			else
			{
				float absX = math.abs(x);
				float abxY = math.abs(y);
				minmax(absX, abxY, out float min, out float max);
  
				uint e = math.asuint(max) & 0x7C00_0000;
				float scalePre = math.asfloat(0x7E00_0000 - e);
				float scalePost = math.asfloat(0x0100_0000 + e);
				
				min *= scalePre;
				max *= scalePre;

				float r = math.sqrt(math.mad(max, max, min * min));
  
				if (math.isnan(x) | math.isnan(y)) scalePost = float.NaN;
				if (math.isinf(max)) scalePost = float.PositiveInfinity;
  
				return r * scalePost;
			}
		}
		
		/// <summary>		Returns the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="double.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="double.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="double"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double hypot(double x, double y, Promise noOverflow = Promise.Nothing)
		{
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				if (constexpr.IS_CONST(x))
				{
					return math.sqrt(math.mad(y, y, x * x));
				}
				else
				{
					return math.sqrt(math.mad(x, x, y * y));
				}
			}

			if (Architecture.IsSIMDSupported)
			{
				return Xse.hypot_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)).Double0;
			}
			else
			{
				double absX = math.abs(x);
				double abxY = math.abs(y);
				minmax(absX, abxY, out double min, out double max);
  
				ulong e = math.asulong(max) & 0x7F80_0000_0000_0000ul;
				double scalePre = math.asdouble(0x7FC0_0000_0000_0000ul - e);
				double scalePost = math.asdouble(0x0020_0000_0000_0000ul + e);
				
				min *= scalePre;
				max *= scalePre;

				double r = math.sqrt(math.mad(max, max, min * min));
  
				if (math.isnan(x) | math.isnan(y)) scalePost = double.NaN;
				if (math.isinf(max)) scalePost = double.PositiveInfinity;
  
				return r * scalePost;
			}
		}
		
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 hypot(byte2 x, byte2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat2(Xse.hypotepu8_ps(x, y));
			}
			else
			{
				return new float2(hypot(x.x, y.x), hypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 hypot(byte3 x, byte3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat3(Xse.hypotepu8_ps(x, y));
			}
			else
			{
				return new float3(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 hypot(byte4 x, byte4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat4(Xse.hypotepu8_ps(x, y));
			}
			else
			{
				return new float4(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z), hypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 hypot(byte8 x, byte8 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_hypotepu8_ps(x, y);
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.hypotepu8_ps(x, y, out v128 lo, out v128 hi);

				return new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
			}
			else
			{
				return new float8(hypot(x.x0, y.x0), hypot(x.x1, y.x1), hypot(x.x2, y.x2), hypot(x.x3, y.x3), hypot(x.x4, y.x4), hypot(x.x5, y.x5), hypot(x.x6, y.x6), hypot(x.x7, y.x7));
			}
		}
		
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 hypot(ushort2 x, ushort2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat2(Xse.hypotepu16_ps(x, y, 2));
			}
			else
			{
				return new float2(hypot(x.x, y.x), hypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 hypot(ushort3 x, ushort3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat3(Xse.hypotepu16_ps(x, y, 3));
			}
			else
			{
				return new float3(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 hypot(ushort4 x, ushort4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat4(Xse.hypotepu16_ps(x, y, 4));
			}
			else
			{
				return new float4(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z), hypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 hypot(ushort8 x, ushort8 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_hypotepu16_ps(x, y);
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.hypotepu16_ps(x, y, out v128 lo, out v128 hi);

				return new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
			}
			else
			{
				return new float8(hypot(x.x0, y.x0), hypot(x.x1, y.x1), hypot(x.x2, y.x2), hypot(x.x3, y.x3), hypot(x.x4, y.x4), hypot(x.x5, y.x5), hypot(x.x6, y.x6), hypot(x.x7, y.x7));
			}
		}
		
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 hypot(sbyte2 x, sbyte2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat2(Xse.hypotepi8_ps(x, y));
			}
			else
			{
				return new float2(hypot(x.x, y.x), hypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 hypot(sbyte3 x, sbyte3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat3(Xse.hypotepi8_ps(x, y));
			}
			else
			{
				return new float3(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 hypot(sbyte4 x, sbyte4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat4(Xse.hypotepi8_ps(x, y));
			}
			else
			{
				return new float4(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z), hypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 hypot(sbyte8 x, sbyte8 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_hypotepi8_ps(x, y);
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.hypotepi8_ps(x, y, out v128 lo, out v128 hi);

				return new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
			}
			else
			{
				return new float8(hypot(x.x0, y.x0), hypot(x.x1, y.x1), hypot(x.x2, y.x2), hypot(x.x3, y.x3), hypot(x.x4, y.x4), hypot(x.x5, y.x5), hypot(x.x6, y.x6), hypot(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 hypot(short2 x, short2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat2(Xse.hypotepi16_ps(x, y));
			}
			else
			{
				return new float2(hypot(x.x, y.x), hypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 hypot(short3 x, short3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat3(Xse.hypotepi16_ps(x, y));
			}
			else
			{
				return new float3(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 hypot(short4 x, short4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToFloat4(Xse.hypotepi16_ps(x, y));
			}
			else
			{
				return new float4(hypot(x.x, y.x), hypot(x.y, y.y), hypot(x.z, y.z), hypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 hypot(short8 x, short8 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_hypotepi16_ps(x, y);
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.hypotepi16_ps(x, y, out v128 lo, out v128 hi);

				return new float8(RegisterConversion.ToFloat4(lo), RegisterConversion.ToFloat4(hi));
			}
			else
			{
				return new float8(hypot(x.x0, y.x0), hypot(x.x1, y.x1), hypot(x.x2, y.x2), hypot(x.x3, y.x3), hypot(x.x4, y.x4), hypot(x.x5, y.x5), hypot(x.x6, y.x6), hypot(x.x7, y.x7));
			}
		}
		
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="float.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="float.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="float"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 hypot(float2 x, float2 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return noOverflow.Promises(Promise.NoOverflow) ? RegisterConversion.ToFloat2(Xse.naivehypot_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)))
															   : RegisterConversion.ToFloat2(Xse.hypot_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
			}
			else
			{
				return new float2(hypot(x.x, y.x, noOverflow), hypot(x.y, y.y, noOverflow));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="float.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="float.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="float"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 hypot(float3 x, float3 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return noOverflow.Promises(Promise.NoOverflow) ? RegisterConversion.ToFloat3(Xse.naivehypot_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)))
															   : RegisterConversion.ToFloat3(Xse.hypot_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
			}
			else
			{
				return new float3(hypot(x.x, y.x, noOverflow), hypot(x.y, y.y, noOverflow), hypot(x.z, y.z, noOverflow));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="float.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="float.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="float"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 hypot(float4 x, float4 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return noOverflow.Promises(Promise.NoOverflow) ? RegisterConversion.ToFloat4(Xse.naivehypot_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)))
															   : RegisterConversion.ToFloat4(Xse.hypot_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
			}
			else
			{
				return new float4(hypot(x.x, y.x, noOverflow), hypot(x.y, y.y, noOverflow), hypot(x.z, y.z, noOverflow), hypot(x.w, y.w, noOverflow));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="float.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="float.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="float"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 hypot(float8 x, float8 y, Promise noOverflow = Promise.Nothing)
		{
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				if (Avx.IsAvxSupported)
				{
					return Xse.mm256_naivehypot_ps(x, y);
				}
			}

			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_hypot_ps(x, y);
			}
			else
			{
				return new float8(hypot(x.v4_0, y.v4_0, noOverflow), hypot(x.v4_4, y.v4_4, noOverflow));
			}
		}
		
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="double.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="double.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="double"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 hypot(double2 x, double2 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return noOverflow.Promises(Promise.NoOverflow) ? RegisterConversion.ToDouble2(Xse.naivehypot_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)))
															   : RegisterConversion.ToDouble2(Xse.hypot_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
			}
			else
			{
				return new double2(hypot(x.x, y.x, noOverflow), hypot(x.y, y.y, noOverflow));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="double.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="double.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="double"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 hypot(double3 x, double3 y, Promise noOverflow = Promise.Nothing)
		{
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				if (Avx.IsAvxSupported)
				{
					return RegisterConversion.ToDouble3(Xse.mm256_naivehypot_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y)));
				}
			}

			if (Avx2.IsAvx2Supported)
			{
				return RegisterConversion.ToDouble3(Xse.mm256_hypot_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y)));
			}
			else
			{
				return new double3(hypot(x.xy, y.xy, noOverflow), hypot(x.z, y.z, noOverflow));
			}
		}
		
		/// <summary>		Returns the componentwise Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  √(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>).
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns <see cref="double.PositiveInfinity"/> for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows to <see cref="double.PositiveInfinity"/>, even if the square root of that expression would be representable by a <see cref="double"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 hypot(double4 x, double4 y, Promise noOverflow = Promise.Nothing)
		{
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				if (Avx.IsAvxSupported)
				{
					return RegisterConversion.ToDouble4(Xse.mm256_naivehypot_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y)));
				}
			}

			if (Avx2.IsAvx2Supported)
			{
				return RegisterConversion.ToDouble4(Xse.mm256_hypot_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y)));
			}
			else
			{
				return new double4(hypot(x.xy, y.xy, noOverflow), hypot(x.zw, y.zw, noOverflow));
			}
		}
		
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[return: AssumeRange(0ul, 360ul)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint inthypot(byte x, byte y)
		{
			return intsqrt((uint)x * x + (uint)y * y);
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[return: AssumeRange(0ul, 92_680)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint inthypot(ushort x, ushort y)
		{
			return intsqrt((uint)x * x + (uint)y * y);
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint inthypot(uint x, uint y)
		{
			if (constexpr.IS_TRUE(x <= ushort.MaxValue && y <= ushort.MaxValue))
			{
				return inthypot((ushort)x, (ushort)y);
			}

			return (uint)intsqrt((ulong)x * x + (ulong)y * y);
		}

		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="ulong"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong inthypot(ulong x, ulong y, Promise noOverflow = Promise.Nothing)
		{	
			if (constexpr.IS_TRUE(x <= uint.MaxValue && y <= uint.MaxValue))
			{
				return inthypot((uint)x, (uint)y);
			}
			
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				return intsqrt(x * x + y * y);
			}
			else
			{
				return intsqrt(UInt128.umul128(x, x) + UInt128.umul128(y, y));
			}
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋	
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="UInt128"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt128 inthypot(UInt128 x, UInt128 y, Promise noOverflow = Promise.Nothing)
		{
			if (constexpr.IS_TRUE(x.hi64 == 0 && y.hi64 == 0))
			{
				return inthypot(x.lo64, y.lo64);
			}
			
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				return intsqrt(square(x) + square(y));
			}
			else
			{
				return __UInt256__.intsqrt(__UInt256__.usqr256(x) + __UInt256__.usqr256(y));
			}
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[return: AssumeRange(0ul, 181ul)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint inthypot(sbyte x, sbyte y)
		{
			return intsqrt((uint)(x * x + y * y));
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[return: AssumeRange(0ul, 46_340ul)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint inthypot(short x, short y)
		{
			return intsqrt((uint)(x * x + y * y));
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[return: AssumeRange(0ul, 3_037_000ul)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint inthypot(int x, int y)
		{
			if (constexpr.IS_TRUE(x >= 0 && x <= short.MaxValue && y >= 0 && y <= short.MaxValue))
			{
				return inthypot((short)x, (short)y);
			}

			return (uint)intsqrt((ulong)((long)x * x + (long)y * y));
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="long"/>.     </para>
        /// </remarks>
		/// </summary>
		[return: AssumeRange(0ul, 13_043_817_825_332_782_212ul)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong inthypot(long x, long y, Promise noOverflow = Promise.Nothing)
		{
			if (constexpr.IS_TRUE(x >= 0 && x <= int.MaxValue && y >= 0 && y <= int.MaxValue))
			{
				return inthypot((int)x, (int)y);
			}

			if (noOverflow.Promises(Promise.NoOverflow))
			{
				return (ulong)intsqrt(x * x + y * y);
			}
			else
			{
				return intsqrt((UInt128)(UInt128.imul128(x, x) + UInt128.imul128(y, y)));
			}
		}
		
		/// <summary>		Returns the floor of the Euclidean distance (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by an <see cref="Int128"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt128 inthypot(Int128 x, Int128 y, Promise noOverflow = Promise.Nothing)
		{
			if (constexpr.IS_TRUE(x >= 0 && x <= long.MaxValue && y >= 0 && y <= long.MaxValue))
			{
				return inthypot((long)x.lo64, (long)y.lo64);
			}
			
			if (noOverflow.Promises(Promise.NoOverflow))
			{
				return intsqrt(x * x + y * y);
			}
			else
			{
				return __UInt256__.intsqrt(__UInt256__.imul256(x, x) + __UInt256__.imul256(y, y));
			}
		}


		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 inthypot(byte2 x, byte2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu8(x, y, 2);
			}
			else
			{
				return new byte2((byte)inthypot(x.x, y.x), (byte)inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 inthypot(byte3 x, byte3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu8(x, y, 3);
			}
			else
			{
				return new byte3((byte)inthypot(x.x, y.x), (byte)inthypot(x.y, y.y), (byte)inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 inthypot(byte4 x, byte4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu8(x, y, 4);
			}
			else
			{
				return new byte4((byte)inthypot(x.x, y.x), (byte)inthypot(x.y, y.y), (byte)inthypot(x.z, y.z), (byte)inthypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 inthypot(byte8 x, byte8 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu8(x, y, 8);
			}
			else
			{
				return new byte8((byte)inthypot(x.x0, y.x0), (byte)inthypot(x.x1, y.x1), (byte)inthypot(x.x2, y.x2), (byte)inthypot(x.x3, y.x3), (byte)inthypot(x.x4, y.x4), (byte)inthypot(x.x5, y.x5), (byte)inthypot(x.x6, y.x6), (byte)inthypot(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 inthypot(byte16 x, byte16 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu8(x, y, 16);
			}
			else
			{
				return new byte16((byte)inthypot(x.x0, y.x0), (byte)inthypot(x.x1, y.x1), (byte)inthypot(x.x2, y.x2), (byte)inthypot(x.x3, y.x3), (byte)inthypot(x.x4, y.x4), (byte)inthypot(x.x5, y.x5), (byte)inthypot(x.x6, y.x6), (byte)inthypot(x.x7, y.x7), (byte)inthypot(x.x8, y.x8), (byte)inthypot(x.x9, y.x9), (byte)inthypot(x.x10, y.x10), (byte)inthypot(x.x11, y.x11), (byte)inthypot(x.x12, y.x12), (byte)inthypot(x.x13, y.x13), (byte)inthypot(x.x14, y.x14), (byte)inthypot(x.x15, y.x15));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 inthypot(byte32 x, byte32 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epu8(x, y);
			}
			else
			{
				return new byte32(inthypot(x.v16_0, y.v16_0), inthypot(x.v16_16, y.v16_16));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 inthypot(ushort2 x, ushort2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu16(x, y, 2);
			}
			else
			{
				return new ushort2((ushort)inthypot(x.x, y.x), (ushort)inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 inthypot(ushort3 x, ushort3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu16(x, y, 3);
			}
			else
			{
				return new ushort3((ushort)inthypot(x.x, y.x), (ushort)inthypot(x.y, y.y), (ushort)inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 inthypot(ushort4 x, ushort4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu16(x, y, 4);
			}
			else
			{
				return new ushort4((ushort)inthypot(x.x, y.x), (ushort)inthypot(x.y, y.y), (ushort)inthypot(x.z, y.z), (ushort)inthypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 inthypot(ushort8 x, ushort8 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu16(x, y, 8);
			}
			else
			{
				return new ushort8((ushort)inthypot(x.x0, y.x0), (ushort)inthypot(x.x1, y.x1), (ushort)inthypot(x.x2, y.x2), (ushort)inthypot(x.x3, y.x3), (ushort)inthypot(x.x4, y.x4), (ushort)inthypot(x.x5, y.x5), (ushort)inthypot(x.x6, y.x6), (ushort)inthypot(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 inthypot(ushort16 x, ushort16 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epu16(x, y);
			}
			else
			{
				return new ushort16(inthypot(x.v8_0, y.v8_0), inthypot(x.v8_8, y.v8_8));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="uint"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 inthypot(uint2 x, uint2 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt2(Xse.ihypot_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2, noOverflow.Promises(Promise.NoOverflow)));
			}
			else
			{
				return new uint2(inthypot(x.x, y.x), inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="uint"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 inthypot(uint3 x, uint3 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt3(Xse.ihypot_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3, noOverflow.Promises(Promise.NoOverflow)));
			}
			else
			{
				return new uint3(inthypot(x.x, y.x), inthypot(x.y, y.y), inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="uint"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 inthypot(uint4 x, uint4 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt4(Xse.ihypot_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4, noOverflow.Promises(Promise.NoOverflow)));
			}
			else
			{
				return new uint4(inthypot(x.x, y.x), inthypot(x.y, y.y), inthypot(x.z, y.z), inthypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="uint"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 inthypot(uint8 x, uint8 y, Promise noOverflow = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epu32(x, y, noOverflow.Promises(Promise.NoOverflow));
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.ihypot_epu32x2(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(y.v4_0), RegisterConversion.ToV128(y.v4_4), out v128 lo, out v128 hi);

				return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
			}
			else
			{
				return new uint8(inthypot(x.v4_0, y.v4_0), inthypot(x.v4_4, y.v4_4));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="ulong"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 inthypot(ulong2 x, ulong2 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epu64(x, y, noOverflow.Promises(Promise.NoOverflow));
			}
			else
			{
				return new ulong2(inthypot(x.x, y.x), inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="ulong"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 inthypot(ulong3 x, ulong3 y, Promise noOverflow = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epu64(x, y, noOverflow.Promises(Promise.NoOverflow), 3);
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.ihypot_epu64x2(x.xy, x.zz, y.xy, y.zz, out v128 lo, out v128 hi, noOverflow.Promises(Promise.NoOverflow), 3);

				return new ulong3(lo, hi.ULong0);
			}
			else
			{
				return new ulong3(inthypot(x.xy, y.xy), inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="ulong"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 inthypot(ulong4 x, ulong4 y, Promise noOverflow = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epu64(x, y, noOverflow.Promises(Promise.NoOverflow));
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.ihypot_epu64x2(x.xy, x.zw, y.xy, y.zw, out v128 lo, out v128 hi, noOverflow.Promises(Promise.NoOverflow));

				return new ulong4(lo, hi);
			}
			else
			{
				return new ulong4(inthypot(x.xy, y.xy), inthypot(x.zw, y.zw));
			}
		}
		

		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 inthypot(sbyte2 x, sbyte2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi8(x, y, 2);
			}
			else
			{
				return new byte2((byte)inthypot(x.x, y.x), (byte)inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 inthypot(sbyte3 x, sbyte3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi8(x, y, 3);
			}
			else
			{
				return new byte3((byte)inthypot(x.x, y.x), (byte)inthypot(x.y, y.y), (byte)inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 inthypot(sbyte4 x, sbyte4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi8(x, y, 4);
			}
			else
			{
				return new byte4((byte)inthypot(x.x, y.x), (byte)inthypot(x.y, y.y), (byte)inthypot(x.z, y.z), (byte)inthypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 inthypot(sbyte8 x, sbyte8 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi8(x, y, 8);
			}
			else
			{
				return new byte8((byte)inthypot(x.x0, y.x0), (byte)inthypot(x.x1, y.x1), (byte)inthypot(x.x2, y.x2), (byte)inthypot(x.x3, y.x3), (byte)inthypot(x.x4, y.x4), (byte)inthypot(x.x5, y.x5), (byte)inthypot(x.x6, y.x6), (byte)inthypot(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 inthypot(sbyte16 x, sbyte16 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi8(x, y, 16);
			}
			else
			{
				return new byte16((byte)inthypot(x.x0, y.x0), (byte)inthypot(x.x1, y.x1), (byte)inthypot(x.x2, y.x2), (byte)inthypot(x.x3, y.x3), (byte)inthypot(x.x4, y.x4), (byte)inthypot(x.x5, y.x5), (byte)inthypot(x.x6, y.x6), (byte)inthypot(x.x7, y.x7), (byte)inthypot(x.x8, y.x8), (byte)inthypot(x.x9, y.x9), (byte)inthypot(x.x10, y.x10), (byte)inthypot(x.x11, y.x11), (byte)inthypot(x.x12, y.x12), (byte)inthypot(x.x13, y.x13), (byte)inthypot(x.x14, y.x14), (byte)inthypot(x.x15, y.x15));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 inthypot(sbyte32 x, sbyte32 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epi8(x, y);
			}
			else
			{
				return new byte32(inthypot(x.v16_0, y.v16_0), inthypot(x.v16_16, y.v16_16));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 inthypot(short2 x, short2 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi16(x, y, 2);
			}
			else
			{
				return new ushort2((ushort)inthypot(x.x, y.x), (ushort)inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 inthypot(short3 x, short3 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi16(x, y, 3);
			}
			else
			{
				return new ushort3((ushort)inthypot(x.x, y.x), (ushort)inthypot(x.y, y.y), (ushort)inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 inthypot(short4 x, short4 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi16(x, y, 4);
			}
			else
			{
				return new ushort4((ushort)inthypot(x.x, y.x), (ushort)inthypot(x.y, y.y), (ushort)inthypot(x.z, y.z), (ushort)inthypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 inthypot(short8 x, short8 y)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi16(x, y, 8);
			}
			else
			{
				return new ushort8((ushort)inthypot(x.x0, y.x0), (ushort)inthypot(x.x1, y.x1), (ushort)inthypot(x.x2, y.x2), (ushort)inthypot(x.x3, y.x3), (ushort)inthypot(x.x4, y.x4), (ushort)inthypot(x.x5, y.x5), (ushort)inthypot(x.x6, y.x6), (ushort)inthypot(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋			</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 inthypot(short16 x, short16 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epi16(x, y);
			}
			else
			{
				return new ushort16(inthypot(x.v8_0, y.v8_0), inthypot(x.v8_8, y.v8_8));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by an <see cref="int"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 inthypot(int2 x, int2 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt2(Xse.ihypot_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow), 2));
			}
			else
			{
				return new uint2(inthypot(x.x, y.x), inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by an <see cref="int"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 inthypot(int3 x, int3 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt3(Xse.ihypot_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow), 3));
			}
			else
			{
				return new uint3(inthypot(x.x, y.x), inthypot(x.y, y.y), inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by an <see cref="int"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 inthypot(int4 x, int4 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt4(Xse.ihypot_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), noOverflow.Promises(Promise.NoOverflow), 4));
			}
			else
			{
				return new uint4(inthypot(x.x, y.x), inthypot(x.y, y.y), inthypot(x.z, y.z), inthypot(x.w, y.w));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by an <see cref="int"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 inthypot(int8 x, int8 y, Promise noOverflow = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epi32(x, y, noOverflow.Promises(Promise.NoOverflow));
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.ihypot_epi32x2(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(y.v4_0), RegisterConversion.ToV128(y.v4_4), out v128 lo, out v128 hi, noOverflow.Promises(Promise.NoOverflow));

				return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
			}
			else
			{
				return new uint8(inthypot(x.v4_0, y.v4_0), inthypot(x.v4_4, y.v4_4));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="long"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 inthypot(long2 x, long2 y, Promise noOverflow = Promise.Nothing)
		{
			if (Architecture.IsSIMDSupported)
			{
				return Xse.ihypot_epi64(x, y, noOverflow.Promises(Promise.NoOverflow));
			}
			else
			{
				return new ulong2(inthypot(x.x, y.x), inthypot(x.y, y.y));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="long"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 inthypot(long3 x, long3 y, Promise noOverflow = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epi64(x, y, noOverflow.Promises(Promise.NoOverflow), 3);
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.ihypot_epi64x2(x.xy, x.zz, y.xy, y.zz, out v128 lo, out v128 hi, noOverflow.Promises(Promise.NoOverflow), 3);

				return new ulong3(lo, hi.ULong0);
			}
			else
			{
				return new ulong3(inthypot(x.xy, y.xy), inthypot(x.z, y.z));
			}
		}
		
		/// <summary>		Returns the componentwise floor of the Euclidean distances (hypotenuse) between two points with coordinates (<paramref name="x"/>, 0) and (0, <paramref name="y"/>). Equivalent to  ⌊√(<paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/>)⌋
		/// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="x"/> * <paramref name="x"/> + <paramref name="y"/> * <paramref name="y"/> that overflows, even if the square root of that expression would be representable by a <see cref="long"/>.     </para>
        /// </remarks>
		/// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 inthypot(long4 x, long4 y, Promise noOverflow = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ihypot_epi64(x, y, noOverflow.Promises(Promise.NoOverflow));
			}
			else if (Architecture.IsSIMDSupported)
			{
				Xse.ihypot_epi64x2(x.xy, x.zw, y.xy, y.zw, out v128 lo, out v128 hi, noOverflow.Promises(Promise.NoOverflow));

				return new ulong4(lo, hi);
			}
			else
			{
				return new ulong4(inthypot(x.xy, y.xy), inthypot(x.zw, y.zw));
			}
		}
    }
}
