using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.ERF_C;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 erf_ps(v128 a, byte elements = 4, bool promiseFinite = false)
			{
			    if (Architecture.IsSIMDSupported)
			    {
					v128 ABS_MASK = set1_epi32(0x7FFF_FFFF);
					v128 ONE = set1_ps(1f);

					v128 rcp = div_ps(ONE, a);
					v128 aNegative = cmplt_ps(a, setzero_ps());
					v128 abs = and_si128(a, ABS_MASK);

					v128 bound0Mask = cmpgt_epi32(set1_epi32(0x3F58_0000), abs);
					v128 bound1Mask = cmpgt_epi32(set1_epi32(0x3180_0000), abs);

					v128 sq = mul_ps(a, a);

					v128 s = sq;
					v128 p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_PP4), s, set1_ps(F32_PP3)), s, set1_ps(F32_PP2)), s, set1_ps(F32_PP1)), s, set1_ps(F32_PP0));
					v128 q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_QQ5), s, set1_ps(F32_QQ4)), s, set1_ps(F32_QQ3)), s, set1_ps(F32_QQ2)), s, set1_ps(F32_QQ1)), s, ONE);
					v128 result0 = div_ps(p, q);
					result0 = fmadd_ps(result0, a, a);

					v128 result;
					v128 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						allResultsFoundMask = cmpgt_epi32(abs, set1_epi32(0x7F7F_FFFF));
						v128 nanInfResult = blendv_si128(ONE, neg_ps(ONE), aNegative);
						nanInfResult = add_ps(rcp, nanInfResult);
						result = and_ps(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = or_si128(bound1Mask, allResultsFoundMask);

						result = blendv_si128(result, result0, bound0Mask);
					}

					v128 result1 = mul_ps(set1_ps(0.125f), add_ps(mul_ps(set1_ps(8f), a), mul_ps(set1_ps(F32_EFX), a)));
					result = blendv_si128(result, result1, bound1Mask);


                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					v128 signA = andnot_ps(ABS_MASK, aNegative);

					v128 bound3Mask = cmpgt_epi32(set1_epi32(0x3FA0_0000), abs);
					bound3Mask = andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound3Mask);

					s = sub_ps(abs, ONE);
					p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_PA6), s, set1_ps(F32_PA5)), s, set1_ps(F32_PA4)), s, set1_ps(F32_PA3)), s, set1_ps(F32_PA2)), s, set1_ps(F32_PA1)), s, set1_ps(F32_PA0));
					q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_QA6), s, set1_ps(F32_QA5)), s, set1_ps(F32_QA4)), s, set1_ps(F32_QA3)), s, set1_ps(F32_QA2)), s, set1_ps(F32_QA1)), s, ONE);
					v128 result3 = div_ps(p, q);
					result3 = xor_ps(result3, signA);
					result3 = add_ps(xor_ps(set1_ps(F32_ERX), signA), result3);
					result = blendv_si128(result, result3, bound3Mask);


					v128 bound4Mask = cmpgt_epi32(abs, set1_epi32(0x40BF_FFFF));
					bound4Mask = andnot_si128(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound4Mask);
					v128 result4 = xor_ps(signA, set1_ps(1f - F32_TINY));
					result = blendv_si128(result, result4, bound4Mask);


                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


			 		s = div_ps(ONE, sq);
					v128 hiAbs = and_ps(a, set1_epi32(0xFFFF_E000));
					v128 bound5Mask = cmpgt_epi32(set1_epi32(0x4036_DB6D), abs);
					v128 exp0 = fnmadd_ps(hiAbs, hiAbs, set1_ps(-0.5625f));
					v128 mulExp1 = fmsub_ps(hiAbs, hiAbs, mul_ps(abs, abs));
					v128 result5;

					if (elements > 2)
					{
                        if (Avx.IsAvxSupported)
                        {
							v256 ss = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(s), s, 1);

							v128 qTrue = fmadd_ps(set1_ps(F32_SA8), s, set1_ps(F32_SA7));
							v256 __0True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RA7)), qTrue, 1);
							v256 __1True = new v256(F32_RA6, F32_RA6, F32_RA6, F32_RA6,		F32_SA6, F32_SA6, F32_SA6, F32_SA6);
							v256 __2True = new v256(F32_RA5, F32_RA5, F32_RA5, F32_RA5,		F32_SA5, F32_SA5, F32_SA5, F32_SA5);
							v256 __3True = new v256(F32_RA4, F32_RA4, F32_RA4, F32_RA4,		F32_SA4, F32_SA4, F32_SA4, F32_SA4);
							v256 __4True = new v256(F32_RA3, F32_RA3, F32_RA3, F32_RA3,		F32_SA3, F32_SA3, F32_SA3, F32_SA3);
							v256 __5True = new v256(F32_RA2, F32_RA2, F32_RA2, F32_RA2,		F32_SA2, F32_SA2, F32_SA2, F32_SA2);
							v256 __6True = new v256(F32_RA1, F32_RA1, F32_RA1, F32_RA1,		F32_SA1, F32_SA1, F32_SA1, F32_SA1);
							v256 __7True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RA0)), ONE, 1);

							v128 qFalse = fmadd_ps(set1_ps(F32_SB7), s, set1_ps(F32_SB6));
							v256 __0False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RB6)), qFalse, 1);
							v256 __1False = new v256(F32_RB5, F32_RB5, F32_RB5, F32_RB5,	F32_SB5, F32_SB5, F32_SB5, F32_SB5);
							v256 __2False = new v256(F32_RB4, F32_RB4, F32_RB4, F32_RB4,	F32_SB4, F32_SB4, F32_SB4, F32_SB4);
							v256 __3False = new v256(F32_RB3, F32_RB3, F32_RB3, F32_RB3,	F32_SB3, F32_SB3, F32_SB3, F32_SB3);
							v256 __4False = new v256(F32_RB2, F32_RB2, F32_RB2, F32_RB2,	F32_SB2, F32_SB2, F32_SB2, F32_SB2);
							v256 __5False = new v256(F32_RB1, F32_RB1, F32_RB1, F32_RB1,	F32_SB1, F32_SB1, F32_SB1, F32_SB1);
							v256 __6False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RB0)), ONE, 1);

							v256 pqTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True);
							v256 pqFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False);

							v256 mask = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(bound5Mask), bound5Mask, 1);
							v256 pq = Avx.mm256_blendv_ps(pqFalse, pqTrue, mask);
							v256 mulExp1_256 = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(mulExp1), mulExp1, 1);

                            pq = mm256_fdadd_ps(Avx.mm256_permute2f128_ps(pq, pq, 0b0000_0001), pq, mulExp1_256);
							v256 exp = maxmath.exp(Avx.mm256_permute2f128_ps(Avx.mm256_castps128_ps256(exp0), pq, 0b0011_0000));
							result5 = mul_ps(Avx.mm256_castps256_ps128(exp), Avx.mm256_extractf128_ps(exp, 1));
                        }
						else
						{
							v128 qTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_SA8), s, set1_ps(F32_SA7)), s, set1_ps(F32_SA6)), s, set1_ps(F32_SA5)), s, set1_ps(F32_SA4)), s, set1_ps(F32_SA3)), s, set1_ps(F32_SA2)), s, set1_ps(F32_SA1)), s, ONE);
							v128 pTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_RA7), s, set1_ps(F32_RA6)), s, set1_ps(F32_RA5)), s, set1_ps(F32_RA4)), s, set1_ps(F32_RA3)), s, set1_ps(F32_RA2)), s, set1_ps(F32_RA1)), s, set1_ps(F32_RA0));

							v128 qFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_SB7), s, set1_ps(F32_SB6)), s, set1_ps(F32_SB5)), s, set1_ps(F32_SB4)), s, set1_ps(F32_SB3)), s, set1_ps(F32_SB2)), s, set1_ps(F32_SB1)), s, ONE);
							v128 pFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_RB6), s, set1_ps(F32_RB5)), s, set1_ps(F32_RB4)), s, set1_ps(F32_RB3)), s, set1_ps(F32_RB2)), s, set1_ps(F32_RB1)), s, set1_ps(F32_RB0));

							p = blendv_si128(pFalse, pTrue, bound5Mask);
							q = blendv_si128(qFalse, qTrue, bound5Mask);

							v128 exp1 = fdadd_ps(p, q, mulExp1);
							result5 = mul_ps(RegisterConversion.ToV128(math.exp(RegisterConversion.ToFloat4(exp0))),
											 RegisterConversion.ToV128(math.exp(RegisterConversion.ToFloat4(exp1))));
						}
					}
					else
					{
						v128 ss = unpacklo_pd(s, s);

						v128 qTrue = fmadd_ps(set1_ps(F32_SA8), s, set1_ps(F32_SA7));
						v128 __0True = unpacklo_pd(set1_ps(F32_RA7), qTrue);
						v128 __1True = new v128(F32_RA6, F32_RA6, F32_SA6, F32_SA6);
						v128 __2True = new v128(F32_RA5, F32_RA5, F32_SA5, F32_SA5);
						v128 __3True = new v128(F32_RA4, F32_RA4, F32_SA4, F32_SA4);
						v128 __4True = new v128(F32_RA3, F32_RA3, F32_SA3, F32_SA3);
						v128 __5True = new v128(F32_RA2, F32_RA2, F32_SA2, F32_SA2);
						v128 __6True = new v128(F32_RA1, F32_RA1, F32_SA1, F32_SA1);
						v128 __7True = unpacklo_pd(set1_ps(F32_RA0), ONE);

						v128 qFalse = fmadd_ps(set1_ps(F32_SB7), s, set1_ps(F32_SB6));
						v128 __0False = unpacklo_pd(set1_ps(F32_RB6), qFalse);
						v128 __1False = new v128(F32_RB5, F32_RB5, F32_SB5, F32_SB5);
						v128 __2False = new v128(F32_RB4, F32_RB4, F32_SB4, F32_SB4);
						v128 __3False = new v128(F32_RB3, F32_RB3, F32_SB3, F32_SB3);
						v128 __4False = new v128(F32_RB2, F32_RB2, F32_SB2, F32_SB2);
						v128 __5False = new v128(F32_RB1, F32_RB1, F32_SB1, F32_SB1);
						v128 __6False = unpacklo_pd(set1_ps(F32_RB0), ONE);

						v128 pqTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True);
						v128 pqFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False);

						v128 mask = unpacklo_pd(bound5Mask, bound5Mask);
						v128 mulExp1_128 = unpacklo_pd(mulExp1, mulExp1);

						v128 pq = blendv_si128(pqFalse, pqTrue, mask);
						pq = div_ps(pq, bsrli_si128(pq, 2 * sizeof(float)));
						pq = add_ps(pq, mulExp1_128);
						v128 exp = unpacklo_pd(exp0, pq);
						exp = RegisterConversion.ToV128(math.exp(RegisterConversion.ToFloat4(exp)));
						result5 = mul_ps(exp, bsrli_si128(exp, 2 * sizeof(float)));
					}

					result5 = fnmsub_ps(result5, rcp, ONE);
					result = blendv_si128(result5, result, allResultsFoundMask);

					return result;
				}
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erf_ps(v256 a, bool promiseFinite = false)
			{
			    if (Avx.IsAvxSupported)
			    {
					v256 ABS_MASK = mm256_set1_epi32(0x7FFF_FFFF);
					v256 ONE = mm256_set1_ps(1f);

					v256 rcp = Avx.mm256_div_ps(ONE, a);
					v256 abs = Avx.mm256_and_ps(a, ABS_MASK);
					v256 aNegative = mm256_cmplt_ps(a, Avx.mm256_setzero_ps());

					v256 bound0Mask;
					v256 bound1Mask;
					v256 bound3Mask;
					v256 bound4Mask;
					v256 bound5Mask;
					if (Avx2.IsAvx2Supported)
					{
						bound0Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3F58_0000), abs);
						bound1Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3180_0000), abs);
						bound3Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3FA0_0000), abs);
						bound4Mask = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(0x40BF_FFFF));
						bound5Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x4036_DB6D), abs);
					}
					else
					{
						bound0Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x3F58_0000), abs);
						bound1Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x3180_0000), abs);
						bound3Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x3FA0_0000), abs);
						bound4Mask = mm256_cmpgt_ps(abs, mm256_set1_epi32(0x40BF_FFFF));
						bound5Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x4036_DB6D), abs);
					}

					v256 sq = Avx.mm256_mul_ps(a, a);

					v256 s = sq;
					v256 p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_PP4), s, mm256_set1_ps(F32_PP3)), s, mm256_set1_ps(F32_PP2)), s, mm256_set1_ps(F32_PP1)), s, mm256_set1_ps(F32_PP0));
					v256 q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_QQ5), s, mm256_set1_ps(F32_QQ4)), s, mm256_set1_ps(F32_QQ3)), s, mm256_set1_ps(F32_QQ2)), s, mm256_set1_ps(F32_QQ1)), s, ONE);
					v256 result0 = Avx.mm256_div_ps(p, q);
					result0 = mm256_fmadd_ps(result0, a, a);

					v256 result;
					v256 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						if (Avx2.IsAvx2Supported)
						{
							allResultsFoundMask = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(0x7F7F_FFFF));
						}
						else
						{
							allResultsFoundMask = Avx.mm256_or_ps(mm256_cmpunord_ps(a, a), mm256_cmpeq_ps(abs, mm256_set1_ps(float.PositiveInfinity)));
						}

						v256 nanInfResult = Avx.mm256_blendv_ps(ONE, mm256_neg_ps(ONE), aNegative);
						nanInfResult = Avx.mm256_add_ps(rcp, nanInfResult);
						result = Avx.mm256_and_ps(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = Avx.mm256_or_ps(bound1Mask, allResultsFoundMask);

						result = Avx.mm256_blendv_ps(result, result0, bound0Mask);
					}

					v256 result1 = Avx.mm256_mul_ps(mm256_set1_ps(0.125f), Avx.mm256_add_ps(Avx.mm256_mul_ps(mm256_set1_ps(8f), a), Avx.mm256_mul_ps(mm256_set1_ps(F32_EFX), a)));
					result = Avx.mm256_blendv_ps(result, result1, bound1Mask);


                    if (mm256_alltrue_f256<float>(allResultsFoundMask)) // 100% free; ILP
					{
						return result;
					}


					v256 signA = Avx.mm256_andnot_ps(ABS_MASK, aNegative);

					bound3Mask = Avx.mm256_andnot_ps(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx.mm256_or_ps(allResultsFoundMask, bound3Mask);

					s = Avx.mm256_sub_ps(abs, ONE);
					p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_PA6), s, mm256_set1_ps(F32_PA5)), s, mm256_set1_ps(F32_PA4)), s, mm256_set1_ps(F32_PA3)), s, mm256_set1_ps(F32_PA2)), s, mm256_set1_ps(F32_PA1)), s, mm256_set1_ps(F32_PA0));
					q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_QA6), s, mm256_set1_ps(F32_QA5)), s, mm256_set1_ps(F32_QA4)), s, mm256_set1_ps(F32_QA3)), s, mm256_set1_ps(F32_QA2)), s, mm256_set1_ps(F32_QA1)), s, ONE);
					v256 result3 = Avx.mm256_div_ps(p, q);
					result3 = Avx.mm256_xor_ps(result3, signA);
					result3 = Avx.mm256_add_ps(Avx.mm256_xor_ps(mm256_set1_ps(F32_ERX), signA), result3);
					result = Avx.mm256_blendv_ps(result, result3, bound3Mask);

					bound4Mask = Avx.mm256_andnot_ps(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = Avx.mm256_or_ps(allResultsFoundMask, bound4Mask);
					v256 result4 = Avx.mm256_xor_ps(signA, mm256_set1_ps(1f - F32_TINY));
					result = Avx.mm256_blendv_ps(result, result4, bound4Mask);


                    if (mm256_alltrue_f256<float>(allResultsFoundMask)) // 100% free; ILP
					{
						return result;
					}


			 		s = Avx.mm256_div_ps(ONE, sq);

					v256 hiAbs = Avx.mm256_and_ps(a, mm256_set1_epi32(0xFFFF_E000));
					v256 exp0 = mm256_fnmadd_ps(hiAbs, hiAbs, mm256_set1_ps(-0.5625f));
					v256 mulExp1 = mm256_fmsub_ps(hiAbs, hiAbs, Avx.mm256_mul_ps(abs, abs));

					v256 pTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_RA7), s, mm256_set1_ps(F32_RA6)), s, mm256_set1_ps(F32_RA5)), s, mm256_set1_ps(F32_RA4)), s, mm256_set1_ps(F32_RA3)), s, mm256_set1_ps(F32_RA2)), s, mm256_set1_ps(F32_RA1)), s, mm256_set1_ps(F32_RA0));
					v256 qTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_SA8), s, mm256_set1_ps(F32_SA7)), s, mm256_set1_ps(F32_SA6)), s, mm256_set1_ps(F32_SA5)), s, mm256_set1_ps(F32_SA4)), s, mm256_set1_ps(F32_SA3)), s, mm256_set1_ps(F32_SA2)), s, mm256_set1_ps(F32_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_RB6), s, mm256_set1_ps(F32_RB5)), s, mm256_set1_ps(F32_RB4)), s, mm256_set1_ps(F32_RB3)), s, mm256_set1_ps(F32_RB2)), s, mm256_set1_ps(F32_RB1)), s, mm256_set1_ps(F32_RB0));
					v256 qFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_SB7), s, mm256_set1_ps(F32_SB6)), s, mm256_set1_ps(F32_SB5)), s, mm256_set1_ps(F32_SB4)), s, mm256_set1_ps(F32_SB3)), s, mm256_set1_ps(F32_SB2)), s, mm256_set1_ps(F32_SB1)), s, ONE);

					p = Avx.mm256_blendv_ps(pFalse, pTrue, bound5Mask);
					q = Avx.mm256_blendv_ps(qFalse, qTrue, bound5Mask);

					v256 exp1 = mm256_fdadd_ps(p, q, mulExp1);
					v256 result5 = Avx.mm256_mul_ps(maxmath.exp(exp0), maxmath.exp(exp1));
					result5 = mm256_fnmsub_ps(result5, rcp, ONE);

					return Avx.mm256_blendv_ps(result5, result, allResultsFoundMask);
				}
				else throw new IllegalInstructionException();
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 erf_pd(v128 a, bool promiseFinite = false)
			{
				static v128 blend(v128 a, v128 b, v128 c)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return blendv_pd(a, b, c);
					}
					else if (Architecture.IsSIMDSupported)
					{
						return blendv_si128(a, b, c);
					}
					else throw new IllegalInstructionException();
				}

				static v128 cmpHiGt(v128 a, v128 b)
				{
			        if (Sse4_1.IsSse41Supported)
			        {
						return cmpgt_epi32(a, b);
			        }
					else if (Architecture.IsCMP64Supported)
					{
						return cmpgt_epi64(a, b);
					}
					else if (Architecture.IsSIMDSupported)
					{
						return shuffle_epi32(cmpgt_epi32(a, b), Sse.SHUFFLE(3, 3, 1, 1));
					}
					else throw new IllegalInstructionException();
				}


			    if (Architecture.IsSIMDSupported)
			    {
					v128 ABS_MASK = set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);
					v128 ONE = set1_pd(1d);

					v128 rcp = div_pd(ONE, a);
					v128 aNegative = cmplt_pd(a, setzero_ps());
					v128 HI32_MASK = and_si128(a, set1_epi64x(0xFFFF_FFFF_0000_0000));
					v128 hiAbs = and_si128(HI32_MASK, ABS_MASK);

					v128 bound0Mask = cmpHiGt(set1_epi32(0x3FEB_0000), hiAbs);
					v128 bound1Mask = cmpHiGt(set1_epi32(0x3E30_0000), hiAbs);
					v128 bound2Mask = cmpHiGt(set1_epi32(0x0080_0000), hiAbs);

					v128 sq = mul_pd(a, a);

					v128 s = sq;
					v128 p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_PP4), s, set1_pd(F64_PP3)), s, set1_pd(F64_PP2)), s, set1_pd(F64_PP1)), s, set1_pd(F64_PP0));
					v128 q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_QQ5), s, set1_pd(F64_QQ4)), s, set1_pd(F64_QQ3)), s, set1_pd(F64_QQ2)), s, set1_pd(F64_QQ1)), s, ONE);
					v128 result0 = div_pd(p, q);
					result0 = fmadd_pd(result0, a, a);

					v128 result;
					v128 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						allResultsFoundMask = cmpHiGt(hiAbs, set1_epi32(0x7FEF_FFFF));
						v128 nanInfResult = blendv_si128(ONE, neg_pd(ONE), aNegative);
						nanInfResult = add_pd(rcp, nanInfResult);
						result = and_pd(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = or_si128(bound1Mask, allResultsFoundMask);

						result = blend(result, result0, bound0Mask);
					}

					v128 result1 = mul_pd(set1_pd(0.125d), add_pd(mul_pd(set1_pd(8d), a), mul_pd(set1_pd(F64_EFX8), a)));
					result = blend(result, result1, bound1Mask);

					v128 result2 = fmadd_pd(set1_pd(F64_EFX), a, a);
					result = blend(result, result2, bound2Mask);


                    if (alltrue_f128<double>(allResultsFoundMask)) // 100% free; ILP
					{
						return result;
					}


					v128 absA = and_pd(ABS_MASK, a);
					v128 signA = andnot_pd(ABS_MASK, aNegative);

					v128 bound3Mask = cmpHiGt(set1_epi32(0x3FF4_0000), hiAbs);
					bound3Mask = andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound3Mask);

					s = sub_pd(absA, ONE);
					p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_PA6), s, set1_pd(F64_PA5)), s, set1_pd(F64_PA4)), s, set1_pd(F64_PA3)), s, set1_pd(F64_PA2)), s, set1_pd(F64_PA1)), s, set1_pd(F64_PA0));
					q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_QA6), s, set1_pd(F64_QA5)), s, set1_pd(F64_QA4)), s, set1_pd(F64_QA3)), s, set1_pd(F64_QA2)), s, set1_pd(F64_QA1)), s, ONE);
					v128 result3 = div_pd(p, q);
					result3 = xor_pd(result3, signA);
					result3 = add_pd(xor_pd(set1_pd(F64_ERX), signA), result3);
					result = blend(result, result3, bound3Mask);


					v128 bound4Mask = cmpHiGt(hiAbs, set1_epi32(0x4017_FFFF));
					bound4Mask = andnot_si128(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound4Mask);
					v128 result4 = xor_pd(signA, set1_pd(1d - F64_TINY));
					result = blend(result, result4, bound4Mask);


                    if (alltrue_f128<double>(allResultsFoundMask)) // 100% free; ILP
					{
						return result;
					}


			 		s = div_pd(ONE, sq);
					v128 bound5Mask = cmpHiGt(set1_epi32(0x4006_DB6E), hiAbs);
					v128 exp0 = fnmadd_pd(hiAbs, hiAbs, set1_pd(-0.5625d));
					v128 mulExp1 = fmsub_pd(hiAbs, hiAbs, mul_pd(absA, absA));
					v128 result5;

					if (Avx.IsAvxSupported)
					{
						v256 ss = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(s), s, 1);

						v128 qTrue = fmadd_pd(set1_pd(F64_SA8), s, set1_pd(F64_SA7));
						v256 __0True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RA7)), qTrue, 1);
						v256 __1True = new v256(F64_RA6, F64_RA6, F64_SA6, F64_SA6);
						v256 __2True = new v256(F64_RA5, F64_RA5, F64_SA5, F64_SA5);
						v256 __3True = new v256(F64_RA4, F64_RA4, F64_SA4, F64_SA4);
						v256 __4True = new v256(F64_RA3, F64_RA3, F64_SA3, F64_SA3);
						v256 __5True = new v256(F64_RA2, F64_RA2, F64_SA2, F64_SA2);
						v256 __6True = new v256(F64_RA1, F64_RA1, F64_SA1, F64_SA1);
						v256 __7True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RA0)), ONE, 1);

						v128 qFalse = fmadd_pd(set1_pd(F64_SB7), s, set1_pd(F64_SB6));
						v256 __0False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RB6)), qFalse, 1);
						v256 __1False = new v256(F64_RB5, F64_RB5, F64_SB5, F64_SB5);
						v256 __2False = new v256(F64_RB4, F64_RB4, F64_SB4, F64_SB4);
						v256 __3False = new v256(F64_RB3, F64_RB3, F64_SB3, F64_SB3);
						v256 __4False = new v256(F64_RB2, F64_RB2, F64_SB2, F64_SB2);
						v256 __5False = new v256(F64_RB1, F64_RB1, F64_SB1, F64_SB1);
						v256 __6False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RB0)), ONE, 1);

						v256 pqTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True);
						v256 pqFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False);


						v256 mask = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(bound5Mask), bound5Mask, 1);
						v256 mulExp1_256 = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(mulExp1), mulExp1, 1);

						v256 pq = Avx.mm256_blendv_pd(pqFalse, pqTrue, mask);
						pq = Avx.mm256_div_pd(Avx.mm256_permute2f128_pd(pq, pq, 0b0000_0001), pq);
						pq = Avx.mm256_add_pd(pq, mulExp1_256);
						v256 exp = Avx.mm256_permute2f128_pd(Avx.mm256_castpd128_pd256(exp0), pq, 0b0011_0000);
						double4 exp4 = math.exp(*(double4*)&exp);
						exp = *(v256*)&exp4;
						result5 = mul_pd(Avx.mm256_castpd256_pd128(exp), Avx.mm256_extractf128_pd(exp, 1));
					}
					else
					{
						v128 pTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_RA7), s, set1_pd(F64_RA6)), s, set1_pd(F64_RA5)), s, set1_pd(F64_RA4)), s, set1_pd(F64_RA3)), s, set1_pd(F64_RA2)), s, set1_pd(F64_RA1)), s, set1_pd(F64_RA0));
						v128 qTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_SA8), s, set1_pd(F64_SA7)), s, set1_pd(F64_SA6)), s, set1_pd(F64_SA5)), s, set1_pd(F64_SA4)), s, set1_pd(F64_SA3)), s, set1_pd(F64_SA2)), s, set1_pd(F64_SA1)), s, ONE);

						v128 pFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_RB6), s, set1_pd(F64_RB5)), s, set1_pd(F64_RB4)), s, set1_pd(F64_RB3)), s, set1_pd(F64_RB2)), s, set1_pd(F64_RB1)), s, set1_pd(F64_RB0));
						v128 qFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_SB7), s, set1_pd(F64_SB6)), s, set1_pd(F64_SB5)), s, set1_pd(F64_SB4)), s, set1_pd(F64_SB3)), s, set1_pd(F64_SB2)), s, set1_pd(F64_SB1)), s, ONE);
						
						p = blend(pFalse, pTrue, bound5Mask);
						q = blend(qFalse, qTrue, bound5Mask);

						v128 exp1 = add_pd(div_pd(p, q), mulExp1);
						double2 r0 = math.exp(*(double2*)&exp0);
						double2 r1 = math.exp(*(double2*)&exp1);
						result5 = mul_pd(*(v128*)&r0, *(v128*)&r1);
					}

					result5 = fnmsub_pd(result5, rcp, ONE);
					result = blend(result5, result, allResultsFoundMask);

					return result;
				}
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erf_pd(v256 a, byte elements = 4, bool promiseFinite = false)
			{
			    if (Avx.IsAvxSupported)
			    {
					v256 ABS_MASK = mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);
					v256 ONE = mm256_set1_pd(1d);

					v256 rcp = Avx.mm256_div_pd(ONE, a);
					v256 HI32_MASK = Avx.mm256_and_pd(a, mm256_set1_epi64x(0xFFFF_FFFF_0000_0000));
					v256 hiAbs = Avx.mm256_and_pd(HI32_MASK, ABS_MASK);
					v256 aNegative = mm256_cmplt_pd(a, Avx.mm256_setzero_pd());

					v256 bound0Mask;
					v256 bound1Mask;
					v256 bound2Mask;
					v256 bound3Mask;
					v256 bound4Mask;
					v256 bound5Mask;
					if (Avx2.IsAvx2Supported)
					{
						bound0Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3FEB_0000), hiAbs);
						bound1Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3E30_0000), hiAbs);
						bound2Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x0080_0000), hiAbs);
						bound3Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3FF4_0000), hiAbs);
						bound4Mask = Avx2.mm256_cmpgt_epi32(hiAbs, mm256_set1_epi32(0x4017_FFFF));
						bound5Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x4006_DB6E), hiAbs);
					}
					else
					{
						bound0Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x3FEB_0000_0000_0000), hiAbs);
						bound1Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x3E30_0000_0000_0000), hiAbs);
						bound2Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x0080_0000_0000_0000), hiAbs);
						bound3Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x3FF4_0000_0000_0000), hiAbs);
						bound4Mask = mm256_cmpgt_pd(hiAbs, mm256_set1_epi64x(0x4017_FFFF_0000_0000));
						bound5Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x4006_DB6E_0000_0000), hiAbs);
					}

					v256 sq = Avx.mm256_mul_pd(a, a);

					v256 s = sq;
					v256 p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_PP4), s, mm256_set1_pd(F64_PP3)), s, mm256_set1_pd(F64_PP2)), s, mm256_set1_pd(F64_PP1)), s, mm256_set1_pd(F64_PP0));
					v256 q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_QQ5), s, mm256_set1_pd(F64_QQ4)), s, mm256_set1_pd(F64_QQ3)), s, mm256_set1_pd(F64_QQ2)), s, mm256_set1_pd(F64_QQ1)), s, ONE);
					v256 result0 = Avx.mm256_div_pd(p, q);
					result0 = mm256_fmadd_pd(result0, a, a);

					v256 result;
					v256 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						if (Avx2.IsAvx2Supported)
						{
							allResultsFoundMask = Avx2.mm256_cmpgt_epi32(hiAbs, mm256_set1_epi32(0x7FEF_FFFF));
						}
						else
						{
							allResultsFoundMask = Avx.mm256_or_pd(mm256_cmpunord_pd(a, a), mm256_cmpeq_pd(hiAbs, mm256_set1_pd(double.PositiveInfinity)));
						}

						v256 nanInfResult = Avx.mm256_blendv_pd(ONE, mm256_neg_pd(ONE), a);
						nanInfResult = Avx.mm256_add_pd(rcp, nanInfResult);
						result = Avx.mm256_and_pd(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = Avx.mm256_or_pd(bound1Mask, allResultsFoundMask);

						result = Avx.mm256_blendv_pd(result, result0, bound0Mask);
					}

					v256 result1 = Avx.mm256_mul_pd(mm256_set1_pd(0.125d), Avx.mm256_add_pd(Avx.mm256_mul_pd(mm256_set1_pd(8d), a), Avx.mm256_mul_pd(mm256_set1_pd(F64_EFX8), a)));
					result = Avx.mm256_blendv_pd(result, result1, bound1Mask);

					v256 result2 = mm256_fmadd_pd(mm256_set1_pd(F64_EFX), a, a);
					result = Avx.mm256_blendv_pd(result, result2, bound2Mask);


                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					v256 absA = Avx.mm256_and_pd(ABS_MASK, a);
					v256 signA = Avx.mm256_andnot_pd(ABS_MASK, aNegative);

					bound3Mask = Avx.mm256_andnot_pd(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx.mm256_or_pd(allResultsFoundMask, bound3Mask);

					s = Avx.mm256_sub_pd(absA, ONE);
					p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_PA6), s, mm256_set1_pd(F64_PA5)), s, mm256_set1_pd(F64_PA4)), s, mm256_set1_pd(F64_PA3)), s, mm256_set1_pd(F64_PA2)), s, mm256_set1_pd(F64_PA1)), s, mm256_set1_pd(F64_PA0));
					q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_QA6), s, mm256_set1_pd(F64_QA5)), s, mm256_set1_pd(F64_QA4)), s, mm256_set1_pd(F64_QA3)), s, mm256_set1_pd(F64_QA2)), s, mm256_set1_pd(F64_QA1)), s, ONE);
					v256 result3 = Avx.mm256_div_pd(p, q);
					result3 = Avx.mm256_xor_pd(result3, signA);
					result3 = Avx.mm256_add_pd(Avx.mm256_xor_pd(mm256_set1_pd(F64_ERX), signA), result3);
					result = Avx.mm256_blendv_pd(result, result3, bound3Mask);


					bound4Mask = Avx.mm256_andnot_pd(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = Avx.mm256_or_pd(allResultsFoundMask, bound4Mask);
					v256 result4 = Avx.mm256_xor_pd(signA, mm256_set1_pd(1d - F64_TINY));
					result = Avx.mm256_blendv_pd(result, result4, bound4Mask);


                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


			 		s = Avx.mm256_div_pd(ONE, sq);
					v256 exp0 = mm256_fnmadd_pd(hiAbs, hiAbs, mm256_set1_pd(-0.5625d));
					v256 mulExp1 = mm256_fmsub_pd(hiAbs, hiAbs, Avx.mm256_mul_pd(absA, absA));
					v256 result5;

					v256 pTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_RA7), s, mm256_set1_pd(F64_RA6)), s, mm256_set1_pd(F64_RA5)), s, mm256_set1_pd(F64_RA4)), s, mm256_set1_pd(F64_RA3)), s, mm256_set1_pd(F64_RA2)), s, mm256_set1_pd(F64_RA1)), s, mm256_set1_pd(F64_RA0));
					v256 qTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_SA8), s, mm256_set1_pd(F64_SA7)), s, mm256_set1_pd(F64_SA6)), s, mm256_set1_pd(F64_SA5)), s, mm256_set1_pd(F64_SA4)), s, mm256_set1_pd(F64_SA3)), s, mm256_set1_pd(F64_SA2)), s, mm256_set1_pd(F64_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_RB6), s, mm256_set1_pd(F64_RB5)), s, mm256_set1_pd(F64_RB4)), s, mm256_set1_pd(F64_RB3)), s, mm256_set1_pd(F64_RB2)), s, mm256_set1_pd(F64_RB1)), s, mm256_set1_pd(F64_RB0));
					v256 qFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_SB7), s, mm256_set1_pd(F64_SB6)), s, mm256_set1_pd(F64_SB5)), s, mm256_set1_pd(F64_SB4)), s, mm256_set1_pd(F64_SB3)), s, mm256_set1_pd(F64_SB2)), s, mm256_set1_pd(F64_SB1)), s, ONE);

					p = Avx.mm256_blendv_pd(pFalse, pTrue, bound5Mask);
					q = Avx.mm256_blendv_pd(qFalse, qTrue, bound5Mask);

					v256 exp1 = Avx.mm256_add_pd(Avx.mm256_div_pd(p, q), mulExp1);
					double4 r0 = math.exp(*(double4*)&exp0);
					double4 r1 = math.exp(*(double4*)&exp1);
					result5 = Avx.mm256_mul_pd(*(v256*)&r0, *(v256*)&r1);

					result5 = mm256_fnmsub_pd(result5, rcp, ONE);
					result = Avx.mm256_blendv_pd(result5, result, allResultsFoundMask);

					return result;
				}
				else throw new IllegalInstructionException();
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 erfc_ps(v128 a, byte elements = 4, bool promiseFinite = false)
			{
                if (Architecture.IsSIMDSupported)
                {
					v128 ONE = set1_ps(1f);
					v128 ABS_MASK = set1_epi32(0x7FFF_FFFF);

					v128 rcp = div_ps(ONE, a);
					v128 oneMinus = sub_ps(ONE, a);
					v128 abs = and_ps(a, ABS_MASK);
					v128 aNegative = cmplt_ps(a, setzero_ps());
					v128 summands = and_ps(set1_ps(2f), aNegative);

					v128 bound0Mask = cmpgt_epi32(set1_epi32(0x3F58_0000), abs);

					v128 sq = mul_ps(a, a);
					v128 p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_PP4), sq, set1_ps(F32_PP3)), sq, set1_ps(F32_PP2)), sq, set1_ps(F32_PP1)), sq, set1_ps(F32_PP0));
					v128 q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_QQ5), sq, set1_ps(F32_QQ4)), sq, set1_ps(F32_QQ3)), sq, set1_ps(F32_QQ2)), sq, set1_ps(F32_QQ1)), sq, ONE);
				    v128 y = div_ps(p, q);

					v128 bound1Mask = cmpgt_epi32(set1_epi32(0x2380_0000), abs);
					v128 result0and1 = fnmadd_ps(andnot_ps(bound1Mask, a), y, oneMinus);

					v128 result;
					v128 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0and1;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						allResultsFoundMask = cmpgt_epi32(abs, set1_epi32(0x7F7F_FFFF));
						v128 nanInfResult = add_ps(rcp, summands);
						result = and_ps(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = or_si128(bound1Mask, allResultsFoundMask);

						result = blendv_si128(result, result0and1, bound0Mask);
					}


                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					v128 bound2Mask = cmpgt_epi32(abs, set1_epi32(0x403E_FFFF));
					bound2Mask = andnot_si128(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound2Mask);
					v128 result2 = blendv_si128(set1_ps(F32_TINY * F32_TINY), set1_ps(2f - F32_TINY), aNegative);
					result = blendv_si128(result, result2, bound2Mask);

					v128 bound3Mask = cmpgt_epi32(set1_epi32(0x3FA0_0000), abs);
					bound3Mask = andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound3Mask);

					v128 s = sub_ps(abs, ONE);
					p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_PA6), s, set1_ps(F32_PA5)), s, set1_ps(F32_PA4)), s, set1_ps(F32_PA3)), s, set1_ps(F32_PA2)), s, set1_ps(F32_PA1)), s, set1_ps(F32_PA0));
					q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_QA6), s, set1_ps(F32_QA5)), s, set1_ps(F32_QA4)), s, set1_ps(F32_QA3)), s, set1_ps(F32_QA2)), s, set1_ps(F32_QA1)), s, ONE);

					v128 sign = andnot_ps(ABS_MASK, aNegative);
					v128 result3 = xor_ps(sign, div_ps(p, q));
					v128 summands2 = add_ps(summands, xor_ps(sign, set1_ps(1f - F32_ERX)));
					result3 = sub_ps(summands2, result3);
					result = blendv_si128(result, result3, bound3Mask);


                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					s = div_ps(ONE, sq);
					v128 bound4Mask = cmpgt_epi32(set1_epi32(0x4006_DB6D), abs);
					v128 hiAbs = and_si128(abs, set1_epi32(0xFFFF_E000u));
					v128 exp0 = fnmadd_ps(hiAbs, hiAbs, set1_ps(-0.5625f));
					v128 mulExp1 = fmsub_ps(hiAbs, hiAbs, mul_ps(abs, abs));
					v128 result4;

                    if (elements > 2)
                    {
						if (Avx.IsAvxSupported)
						{
							v256 ss = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(s), s, 1);

							v128 qTrue = fmadd_ps(set1_ps(F32_SA8), s, set1_ps(F32_SA7));
							v256 __0True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RA7)), qTrue, 1);
							v256 __1True = new v256(F32_RA6, F32_RA6, F32_RA6, F32_RA6,   F32_SA6, F32_SA6, F32_SA6, F32_SA6);
							v256 __2True = new v256(F32_RA5, F32_RA5, F32_RA5, F32_RA5,   F32_SA5, F32_SA5, F32_SA5, F32_SA5);
							v256 __3True = new v256(F32_RA4, F32_RA4, F32_RA4, F32_RA4,   F32_SA4, F32_SA4, F32_SA4, F32_SA4);
							v256 __4True = new v256(F32_RA3, F32_RA3, F32_RA3, F32_RA3,   F32_SA3, F32_SA3, F32_SA3, F32_SA3);
							v256 __5True = new v256(F32_RA2, F32_RA2, F32_RA2, F32_RA2,   F32_SA2, F32_SA2, F32_SA2, F32_SA2);
							v256 __6True = new v256(F32_RA1, F32_RA1, F32_RA1, F32_RA1,   F32_SA1, F32_SA1, F32_SA1, F32_SA1);
							v256 __7True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RA0)), ONE, 1);

							v128 qFalse = fmadd_ps(set1_ps(F32_SB7), s, set1_ps(F32_SB6));
							v256 __0False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RB6)), qFalse, 1);
							v256 __1False = new v256(F32_RB5, F32_RB5, F32_RB5, F32_RB5,   F32_SB5, F32_SB5, F32_SB5, F32_SB5);
							v256 __2False = new v256(F32_RB4, F32_RB4, F32_RB4, F32_RB4,   F32_SB4, F32_SB4, F32_SB4, F32_SB4);
							v256 __3False = new v256(F32_RB3, F32_RB3, F32_RB3, F32_RB3,   F32_SB3, F32_SB3, F32_SB3, F32_SB3);
							v256 __4False = new v256(F32_RB2, F32_RB2, F32_RB2, F32_RB2,   F32_SB2, F32_SB2, F32_SB2, F32_SB2);
							v256 __5False = new v256(F32_RB1, F32_RB1, F32_RB1, F32_RB1,   F32_SB1, F32_SB1, F32_SB1, F32_SB1);
							v256 __6False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(set1_ps(F32_RB0)), ONE, 1);

							v256 pqTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True);
							v256 pqFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False);


							v256 mask = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(bound4Mask), bound4Mask, 1);
							v256 mulExp1_256 = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(mulExp1), mulExp1, 1);

							v256 pq = Avx.mm256_blendv_ps(pqFalse, pqTrue, mask);
							pq = mm256_fdadd_ps(Avx.mm256_permute2f128_ps(pq, pq, 0b0000_0001), pq, mulExp1_256);
							v256 exp = Avx.mm256_permute2f128_ps(Avx.mm256_castps128_ps256(exp0), pq, 0b0011_0000);
							exp = maxmath.exp(exp);
							result4 = mul_ps(Avx.mm256_castps256_ps128(exp), Avx.mm256_extractf128_ps(exp, 1));
						}
						else
						{
							v128 pTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_RA7), s, set1_ps(F32_RA6)), s, set1_ps(F32_RA5)), s, set1_ps(F32_RA4)), s, set1_ps(F32_RA3)), s, set1_ps(F32_RA2)), s, set1_ps(F32_RA1)), s, set1_ps(F32_RA0));
							v128 qTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_SA8), s, set1_ps(F32_SA7)), s, set1_ps(F32_SA6)), s, set1_ps(F32_SA5)), s, set1_ps(F32_SA4)), s, set1_ps(F32_SA3)), s, set1_ps(F32_SA2)), s, set1_ps(F32_SA1)), s, ONE);

							v128 pFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_RB6), s, set1_ps(F32_RB5)), s, set1_ps(F32_RB4)), s, set1_ps(F32_RB3)), s, set1_ps(F32_RB2)), s, set1_ps(F32_RB1)), s, set1_ps(F32_RB0));
							v128 qFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(F32_SB7), s, set1_ps(F32_SB6)), s, set1_ps(F32_SB5)), s, set1_ps(F32_SB4)), s, set1_ps(F32_SB3)), s, set1_ps(F32_SB2)), s, set1_ps(F32_SB1)), s, ONE);

							p = blendv_si128(pFalse, pTrue, bound4Mask);
							q = blendv_si128(qFalse, qTrue, bound4Mask);

							v128 exp1 = fdadd_ps(p, q, mulExp1);
							float4 r0 = math.exp(*(float4*)&exp0);
							float4 r1 = math.exp(*(float4*)&exp1);
							result4 = mul_ps(*(v128*)&r0, *(v128*)&r1);
						}
                    }
					else
					{
						v128 ss = unpacklo_pd(s, s);

						v128 qTrue = fmadd_ps(set1_ps(F32_SA8), s, set1_ps(F32_SA7));
						v128 __0True = unpacklo_pd(set1_ps(F32_RA7), qTrue);
						v128 __1True = new v128(F32_RA6, F32_RA6, F32_SA6, F32_SA6);
						v128 __2True = new v128(F32_RA5, F32_RA5, F32_SA5, F32_SA5);
						v128 __3True = new v128(F32_RA4, F32_RA4, F32_SA4, F32_SA4);
						v128 __4True = new v128(F32_RA3, F32_RA3, F32_SA3, F32_SA3);
						v128 __5True = new v128(F32_RA2, F32_RA2, F32_SA2, F32_SA2);
						v128 __6True = new v128(F32_RA1, F32_RA1, F32_SA1, F32_SA1);
						v128 __7True = unpacklo_pd(set1_ps(F32_RA0), ONE);

						v128 qFalse = fmadd_ps(set1_ps(F32_SB7), s, set1_ps(F32_SB6));
						v128 __0False = unpacklo_pd(set1_ps(F32_RB6), qFalse);
						v128 __1False = new v128(F32_RB5, F32_RB5, F32_SB5, F32_SB5);
						v128 __2False = new v128(F32_RB4, F32_RB4, F32_SB4, F32_SB4);
						v128 __3False = new v128(F32_RB3, F32_RB3, F32_SB3, F32_SB3);
						v128 __4False = new v128(F32_RB2, F32_RB2, F32_SB2, F32_SB2);
						v128 __5False = new v128(F32_RB1, F32_RB1, F32_SB1, F32_SB1);
						v128 __6False = unpacklo_pd(set1_ps(F32_RB0), ONE);

						v128 pqTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True);
						v128 pqFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False);


						v128 mask = unpacklo_pd(bound4Mask, bound4Mask);
						v128 mulExp1_128 = unpacklo_pd(mulExp1, mulExp1);

						v128 pq = blendv_si128(pqFalse, pqTrue, mask);
						pq = div_ps(pq, bsrli_si128(pq, 2 * sizeof(float)));
						pq = add_ps(pq, mulExp1_128);
						v128 exp = unpacklo_pd(exp0, pq);
						float4 exp4 = math.exp(*(float4*)&exp);
						exp = *(v128*)&exp4;
						result4 = mul_ps(exp, bsrli_si128(exp, 2 * sizeof(float)));
					}

					result4 = fmadd_ps(result4, rcp, summands);

					return blendv_si128(result4, result, allResultsFoundMask);
                }
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erfc_ps(v256 a, bool promiseFinite = false)
			{
                if (Avx.IsAvxSupported)
                {
					v256 ONE = mm256_set1_ps(1f);
					v256 ABS_MASK = mm256_set1_epi32(0x7FFF_FFFF);

					v256 rcp = Avx.mm256_div_ps(ONE, a);
					v256 oneMinus = Avx.mm256_sub_ps(ONE, a);
					v256 abs = Avx.mm256_and_ps(a, ABS_MASK);
					v256 aNegative = mm256_cmplt_ps(a, Avx.mm256_setzero_ps());
					v256 summands = Avx.mm256_and_ps(mm256_set1_ps(2f), aNegative);

					v256 bound0Mask;
					v256 bound1Mask;
					v256 bound2Mask;
					v256 bound3Mask;
					v256 bound4Mask;
					if (Avx2.IsAvx2Supported)
					{
						bound0Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3F58_0000), abs);
						bound1Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x2380_0000), abs);
						bound2Mask = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(0x403E_FFFF));
						bound3Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3FA0_0000), abs);
						bound4Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x4006_DB6D), abs);
					}
					else
					{
						bound0Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x3F58_0000), abs);
						bound1Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x2380_0000), abs);
						bound2Mask = mm256_cmpgt_ps(abs, mm256_set1_epi32(0x403E_FFFF));
						bound3Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x3FA0_0000), abs);
						bound4Mask = mm256_cmpgt_ps(mm256_set1_epi32(0x4006_DB6D), abs);
					}

					v256 sq = Avx.mm256_mul_ps(a, a);
					v256 p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_PP4), sq, mm256_set1_ps(F32_PP3)), sq, mm256_set1_ps(F32_PP2)), sq, mm256_set1_ps(F32_PP1)), sq, mm256_set1_ps(F32_PP0));
					v256 q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_QQ5), sq, mm256_set1_ps(F32_QQ4)), sq, mm256_set1_ps(F32_QQ3)), sq, mm256_set1_ps(F32_QQ2)), sq, mm256_set1_ps(F32_QQ1)), sq, ONE);
				    v256 y = Avx.mm256_div_ps(p, q);

					v256 result0and1 = mm256_fnmadd_ps(Avx.mm256_andnot_ps(bound1Mask, a), y, oneMinus);

					v256 result;
					v256 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0and1;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						if (Avx2.IsAvx2Supported)
						{
							allResultsFoundMask = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(0x7F7F_FFFF));
						}
						else
						{
							allResultsFoundMask = Avx.mm256_or_ps(mm256_cmpunord_ps(a, a), mm256_cmpeq_ps(abs, mm256_set1_ps(float.PositiveInfinity)));
						}

						v256 nanInfResult = Avx.mm256_add_ps(rcp, summands);
						result = Avx.mm256_and_ps(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = Avx.mm256_or_ps(allResultsFoundMask, bound0Mask);

						result = Avx.mm256_blendv_ps(result, result0and1, bound0Mask);
					}


                    if (mm256_alltrue_f256<float>(allResultsFoundMask)) // 100% free; ILP
                    {
						return result;
                    }


					bound2Mask = Avx.mm256_andnot_ps(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = Avx.mm256_or_ps(allResultsFoundMask, bound2Mask);
					v256 result2 = Avx.mm256_blendv_ps(mm256_set1_ps(F32_TINY * F32_TINY), mm256_set1_ps(2f - F32_TINY), aNegative);
					result = Avx.mm256_blendv_ps(result, result2, bound2Mask);

					bound3Mask = Avx.mm256_andnot_ps(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx.mm256_or_ps(allResultsFoundMask, bound3Mask);

					v256 s = Avx.mm256_sub_ps(abs, ONE);
					p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_PA6), s, mm256_set1_ps(F32_PA5)), s, mm256_set1_ps(F32_PA4)), s, mm256_set1_ps(F32_PA3)), s, mm256_set1_ps(F32_PA2)), s, mm256_set1_ps(F32_PA1)), s, mm256_set1_ps(F32_PA0));
					q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_QA6), s, mm256_set1_ps(F32_QA5)), s, mm256_set1_ps(F32_QA4)), s, mm256_set1_ps(F32_QA3)), s, mm256_set1_ps(F32_QA2)), s, mm256_set1_ps(F32_QA1)), s, ONE);

					v256 sign = Avx.mm256_andnot_ps(ABS_MASK, aNegative);
					v256 result3 = Avx.mm256_xor_ps(sign, Avx.mm256_div_ps(p, q));
					v256 summands2 = Avx.mm256_add_ps(summands, Avx.mm256_xor_ps(sign, mm256_set1_ps(1f - F32_ERX)));
					result3 = Avx.mm256_sub_ps(summands2, result3);
					result = Avx.mm256_blendv_ps(result, result3, bound3Mask);


                    if (mm256_alltrue_f256<float>(allResultsFoundMask)) // 100% free; ILP
                    {
						return result;
                    }


					s = Avx.mm256_div_ps(ONE, sq);
					v256 hiAbs = Avx.mm256_and_ps(abs, mm256_set1_epi32(0xFFFF_E000u));
					v256 exp0 = mm256_fnmadd_ps(hiAbs, hiAbs, mm256_set1_ps(-0.5625f));
					v256 mulExp1 = mm256_fmsub_ps(hiAbs, hiAbs, Avx.mm256_mul_ps(abs, abs));
					v256 result4;

					v256 pTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_RA7), s, mm256_set1_ps(F32_RA6)), s, mm256_set1_ps(F32_RA5)), s, mm256_set1_ps(F32_RA4)), s, mm256_set1_ps(F32_RA3)), s, mm256_set1_ps(F32_RA2)), s, mm256_set1_ps(F32_RA1)), s, mm256_set1_ps(F32_RA0));
					v256 qTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_SA8), s, mm256_set1_ps(F32_SA7)), s, mm256_set1_ps(F32_SA6)), s, mm256_set1_ps(F32_SA5)), s, mm256_set1_ps(F32_SA4)), s, mm256_set1_ps(F32_SA3)), s, mm256_set1_ps(F32_SA2)), s, mm256_set1_ps(F32_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_RB6), s, mm256_set1_ps(F32_RB5)), s, mm256_set1_ps(F32_RB4)), s, mm256_set1_ps(F32_RB3)), s, mm256_set1_ps(F32_RB2)), s, mm256_set1_ps(F32_RB1)), s, mm256_set1_ps(F32_RB0));
					v256 qFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(F32_SB7), s, mm256_set1_ps(F32_SB6)), s, mm256_set1_ps(F32_SB5)), s, mm256_set1_ps(F32_SB4)), s, mm256_set1_ps(F32_SB3)), s, mm256_set1_ps(F32_SB2)), s, mm256_set1_ps(F32_SB1)), s, ONE);

					p = Avx.mm256_blendv_ps(pFalse, pTrue, bound4Mask);
					q = Avx.mm256_blendv_ps(qFalse, qTrue, bound4Mask);

					v256 exp1 = mm256_fdadd_ps(p, q, mulExp1);
					result4 = Avx.mm256_mul_ps(maxmath.exp(exp0), maxmath.exp(exp1));
					result4 = mm256_fmadd_ps(result4, rcp, summands);

					return Avx.mm256_blendv_ps(result4, result, allResultsFoundMask);
                }
				else throw new IllegalInstructionException();
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 erfc_pd(v128 a, bool promiseFinite = false)
			{
				static v128 blend(v128 a, v128 b, v128 c)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return blendv_pd(a, b, c);
					}
					else if (Architecture.IsSIMDSupported)
					{
						return blendv_si128(a, b, c);
					}
					else throw new IllegalInstructionException();
				}

				static v128 cmpHiGt(v128 a, v128 b)
				{
			        if (Sse4_1.IsSse41Supported)
			        {
						return cmpgt_epi32(a, b);
			        }
					else if (Architecture.IsCMP64Supported)
					{
						return cmpgt_epi64(a, b);
					}
					else if (Architecture.IsSIMDSupported)
					{
						return shuffle_epi32(cmpgt_epi32(a, b), Sse.SHUFFLE(3, 3, 1, 1));
					}
					else throw new IllegalInstructionException();
				}

				
                if (Architecture.IsSIMDSupported)
                {
					v128 ONE = set1_pd(1d);
					v128 ABS_MASK = set1_pd(0x7FFF_FFFF_FFFF_FFFF);

					v128 rcp = div_pd(ONE, a);
					v128 oneMinus = sub_pd(ONE, a);
					v128 abs = and_pd(a, ABS_MASK);
					v128 aNegative = cmplt_pd(a, setzero_ps());
					v128 summands = and_pd(set1_pd(2d), aNegative);

					v128 bound0Mask = cmpHiGt(set1_epi32(0x3FEB_0000), abs);

					v128 sq = mul_pd(a, a);
					v128 p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_PP4), sq, set1_pd(F64_PP3)), sq, set1_pd(F64_PP2)), sq, set1_pd(F64_PP1)), sq, set1_pd(F64_PP0));
					v128 q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_QQ5), sq, set1_pd(F64_QQ4)), sq, set1_pd(F64_QQ3)), sq, set1_pd(F64_QQ2)), sq, set1_pd(F64_QQ1)), sq, ONE);
				    v128 y = div_pd(p, q);

					v128 bound1Mask = cmpgt_epi32(set1_epi32(0x3C70_0000), abs);
					bound1Mask = shuffle_epi32(bound1Mask, Sse.SHUFFLE(3, 3, 1, 1));
					v128 result0and1 = fnmadd_pd(andnot_pd(bound1Mask, a), y, oneMinus);

					v128 result;
					v128 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0and1;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						allResultsFoundMask = cmpHiGt(abs, set1_epi32(0x7FEF_FFFF));
						v128 nanInfResult = add_pd(rcp, summands);
						result = and_pd(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = or_si128(bound1Mask, allResultsFoundMask);

						result = blend(result, result0and1, bound0Mask);
					}


                    if (alltrue_f128<double>(allResultsFoundMask)) // 100% free; ILP
                    {
						return result;
                    }


					v128 bound2Mask = cmpHiGt(abs, set1_epi32(0x403E_FFFF));
					bound2Mask = andnot_si128(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound2Mask);
					v128 result2 = blendv_si128(set1_pd(math.asdouble(0x0010_0000_0000_0000) * math.asdouble(0x0010_0000_0000_0000)), set1_pd(2 - math.asdouble(0x0010_0000_0000_0000)), aNegative);
					result = blend(result, result2, bound2Mask);

					v128 bound3Mask = cmpHiGt(set1_epi32(0x3FF4_0000), abs);
					bound3Mask = andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = or_si128(allResultsFoundMask, bound3Mask);

					v128 s = sub_pd(abs, ONE);
					p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_PA6), s, set1_pd(F64_PA5)), s, set1_pd(F64_PA4)), s, set1_pd(F64_PA3)), s, set1_pd(F64_PA2)), s, set1_pd(F64_PA1)), s, set1_pd(F64_PA0));
					q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_QA6), s, set1_pd(F64_QA5)), s, set1_pd(F64_QA4)), s, set1_pd(F64_QA3)), s, set1_pd(F64_QA2)), s, set1_pd(F64_QA1)), s, ONE);

					v128 sign = andnot_pd(ABS_MASK, aNegative);
					v128 result3 = xor_pd(sign, div_pd(p, q));
					v128 summands2 = add_pd(summands, xor_pd(sign, set1_pd(1d - F64_ERX)));
					result3 = sub_pd(summands2, result3);
					result = blend(result, result3, bound3Mask);


                    if (alltrue_f128<double>(allResultsFoundMask)) // 100% free; ILP
                    {
						return result;
                    }


					s = div_pd(ONE, sq);
					v128 bound4Mask = cmpHiGt(set1_epi32(0x4006_DB6D), abs);
					v128 hiAbs = and_si128(abs, set1_epi64x(0xFFFF_FFFF_0000_0000ul));
					v128 exp0 = fnmadd_pd(hiAbs, hiAbs, set1_pd(-0.5625d));
					v128 mulExp1 = fmsub_pd(hiAbs, hiAbs, mul_pd(abs, abs));
					v128 result4;

					if (Avx.IsAvxSupported)
					{
						v256 ss = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(s), s, 1);

						v128 qTrue = fmadd_pd(set1_pd(F64_SA8), s, set1_pd(F64_SA7));
						v256 __0True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RA7)), qTrue, 1);
						v256 __1True = new v256(F64_RA6, F64_RA6, F64_SA6, F64_SA6);
						v256 __2True = new v256(F64_RA5, F64_RA5, F64_SA5, F64_SA5);
						v256 __3True = new v256(F64_RA4, F64_RA4, F64_SA4, F64_SA4);
						v256 __4True = new v256(F64_RA3, F64_RA3, F64_SA3, F64_SA3);
						v256 __5True = new v256(F64_RA2, F64_RA2, F64_SA2, F64_SA2);
						v256 __6True = new v256(F64_RA1, F64_RA1, F64_SA1, F64_SA1);
						v256 __7True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RA0)), ONE, 1);

						v128 qFalse = fmadd_pd(set1_pd(F64_SB7), s, set1_pd(F64_SB6));
						v256 __0False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RB6)), qFalse, 1);
						v256 __1False = new v256(F64_RB5, F64_RB5, F64_SB5, F64_SB5);
						v256 __2False = new v256(F64_RB4, F64_RB4, F64_SB4, F64_SB4);
						v256 __3False = new v256(F64_RB3, F64_RB3, F64_SB3, F64_SB3);
						v256 __4False = new v256(F64_RB2, F64_RB2, F64_SB2, F64_SB2);
						v256 __5False = new v256(F64_RB1, F64_RB1, F64_SB1, F64_SB1);
						v256 __6False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(set1_pd(F64_RB0)), ONE, 1);

						v256 pqTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True);
						v256 pqFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False);


						v256 mask = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(bound4Mask), bound4Mask, 1);
						v256 mulExp1_256 = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(mulExp1), mulExp1, 1);

						v256 pq = Avx.mm256_blendv_pd(pqFalse, pqTrue, mask);
						pq = Avx.mm256_div_pd(Avx.mm256_permute2f128_pd(pq, pq, 0b0000_0001), pq);
						pq = Avx.mm256_add_pd(pq, mulExp1_256);
						v256 exp = Avx.mm256_permute2f128_pd(Avx.mm256_castpd128_pd256(exp0), pq, 0b0011_0000);
						double4 exp4 = math.exp(*(double4*)&exp);
						exp = *(v256*)&exp4;
						result4 = mul_pd(Avx.mm256_castpd256_pd128(exp), Avx.mm256_extractf128_pd(exp, 1));
					}
					else
					{
						v128 pTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_RA7), s, set1_pd(F64_RA6)), s, set1_pd(F64_RA5)), s, set1_pd(F64_RA4)), s, set1_pd(F64_RA3)), s, set1_pd(F64_RA2)), s, set1_pd(F64_RA1)), s, set1_pd(F64_RA0));
						v128 qTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_SA8), s, set1_pd(F64_SA7)), s, set1_pd(F64_SA6)), s, set1_pd(F64_SA5)), s, set1_pd(F64_SA4)), s, set1_pd(F64_SA3)), s, set1_pd(F64_SA2)), s, set1_pd(F64_SA1)), s, ONE);

						v128 pFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_RB6), s, set1_pd(F64_RB5)), s, set1_pd(F64_RB4)), s, set1_pd(F64_RB3)), s, set1_pd(F64_RB2)), s, set1_pd(F64_RB1)), s, set1_pd(F64_RB0));
						v128 qFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(F64_SB7), s, set1_pd(F64_SB6)), s, set1_pd(F64_SB5)), s, set1_pd(F64_SB4)), s, set1_pd(F64_SB3)), s, set1_pd(F64_SB2)), s, set1_pd(F64_SB1)), s, ONE);

						p = blend(pFalse, pTrue, bound4Mask);
						q = blend(qFalse, qTrue, bound4Mask);

						v128 exp1 = add_pd(div_pd(p, q), mulExp1);
						double2 r0 = math.exp(*(double2*)&exp0);
						double2 r1 = math.exp(*(double2*)&exp1);
						result4 = mul_pd(*(v128*)&r0, *(v128*)&r1);
					}

					result4 = fmadd_pd(result4, rcp, summands);

					return blend(result4, result, allResultsFoundMask);
                }
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erfc_pd(v256 a, byte elements = 4, bool promiseFinite = false)
			{
                if (Avx.IsAvxSupported)
                {
					v256 ONE = mm256_set1_pd(1d);
					v256 ABS_MASK = mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);

					v256 rcp = Avx.mm256_div_pd(ONE, a);
					v256 oneMinus = Avx.mm256_sub_pd(ONE, a);
					v256 abs = Avx.mm256_and_pd(a, ABS_MASK);
					v256 aNegative = mm256_cmplt_pd(a, Avx.mm256_setzero_pd());
					v256 summands = Avx.mm256_and_pd(mm256_set1_pd(2d), aNegative);

					v256 bound0Mask;
					v256 bound1Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x3C70_0000_0000_0000), abs);
					v256 bound2Mask;
					v256 bound3Mask;
					v256 bound4Mask;
					if (Avx2.IsAvx2Supported)
					{
						bound0Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3FEB_0000), abs);
						bound2Mask = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(0x403E_FFFF));
						bound3Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3FF4_0000), abs);
						bound4Mask = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x4006_DB6D), abs);
					}
					else
					{
						bound0Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x3FEB_0000_0000_0000), abs);
						bound2Mask = mm256_cmpgt_pd(abs, mm256_set1_epi64x(0x403E_FFFF_FFFF_FFFF));
						bound3Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x3FF4_0000_0000_0000), abs);
						bound4Mask = mm256_cmpgt_pd(mm256_set1_epi64x(0x4006_DB6D_0000_0000), abs);
					}

					v256 sq = Avx.mm256_mul_pd(a, a);
					v256 p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_PP4), sq, mm256_set1_pd(F64_PP3)), sq, mm256_set1_pd(F64_PP2)), sq, mm256_set1_pd(F64_PP1)), sq, mm256_set1_pd(F64_PP0));
					v256 q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_QQ5), sq, mm256_set1_pd(F64_QQ4)), sq, mm256_set1_pd(F64_QQ3)), sq, mm256_set1_pd(F64_QQ2)), sq, mm256_set1_pd(F64_QQ1)), sq, ONE);
				    v256 y = Avx.mm256_div_pd(p, q);

					v256 result0and1 = mm256_fnmadd_pd(Avx.mm256_andnot_pd(bound1Mask, a), y, oneMinus);


					v256 result;
					v256 allResultsFoundMask;
					if (promiseFinite)
					{
						result = result0and1;
						allResultsFoundMask = bound1Mask;
					}
					else
					{
						if (Avx2.IsAvx2Supported)
						{
							allResultsFoundMask = Avx2.mm256_cmpgt_epi32(abs, mm256_set1_epi32(0x7FEF_FFFF));
						}
						else
						{
							allResultsFoundMask = Avx.mm256_or_pd(mm256_cmpunord_pd(a, a), mm256_cmpeq_pd(abs, mm256_set1_pd(double.PositiveInfinity)));
						}

						v256 nanInfResult = Avx.mm256_add_pd(rcp, summands);
						result = Avx.mm256_and_pd(allResultsFoundMask, nanInfResult);
						allResultsFoundMask = Avx.mm256_or_pd(allResultsFoundMask, bound1Mask);

						result = Avx.mm256_blendv_pd(result, result0and1, bound0Mask);
					}


                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					bound2Mask = Avx.mm256_andnot_pd(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = Avx.mm256_or_pd(allResultsFoundMask, bound2Mask);
					v256 result2 = Avx.mm256_blendv_pd(mm256_set1_pd(math.asdouble(0x0010_0000_0000_0000) * math.asdouble(0x0010_0000_0000_0000)), mm256_set1_pd(2 - math.asdouble(0x0010_0000_0000_0000)), aNegative);
					result = Avx.mm256_blendv_pd(result, result2, bound2Mask);

					bound3Mask = Avx.mm256_andnot_pd(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx.mm256_or_pd(allResultsFoundMask, bound3Mask);

					v256 s = Avx.mm256_sub_pd(abs, ONE);
					p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_PA6), s, mm256_set1_pd(F64_PA5)), s, mm256_set1_pd(F64_PA4)), s, mm256_set1_pd(F64_PA3)), s, mm256_set1_pd(F64_PA2)), s, mm256_set1_pd(F64_PA1)), s, mm256_set1_pd(F64_PA0));
					q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_QA6), s, mm256_set1_pd(F64_QA5)), s, mm256_set1_pd(F64_QA4)), s, mm256_set1_pd(F64_QA3)), s, mm256_set1_pd(F64_QA2)), s, mm256_set1_pd(F64_QA1)), s, ONE);

					v256 sign = Avx.mm256_andnot_pd(ABS_MASK, aNegative);
					v256 result3 = Avx.mm256_xor_pd(sign, Avx.mm256_div_pd(p, q));
					v256 summands2 = Avx.mm256_add_pd(summands, Avx.mm256_xor_pd(sign, mm256_set1_pd(1d - F64_ERX)));
					result3 = Avx.mm256_sub_pd(summands2, result3);
					result = Avx.mm256_blendv_pd(result, result3, bound3Mask);


                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					s = Avx.mm256_div_pd(ONE, sq);
					v256 hiAbs = Avx.mm256_and_pd(abs, mm256_set1_epi64x(0xFFFF_FFFF_0000_0000ul));
					v256 exp0 = mm256_fnmadd_pd(hiAbs, hiAbs, mm256_set1_pd(-0.5625d));
					v256 mulExp1 = mm256_fmsub_pd(hiAbs, hiAbs, Avx.mm256_mul_pd(abs, abs));
					v256 result4;

					v256 pTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_RA7), s, mm256_set1_pd(F64_RA6)), s, mm256_set1_pd(F64_RA5)), s, mm256_set1_pd(F64_RA4)), s, mm256_set1_pd(F64_RA3)), s, mm256_set1_pd(F64_RA2)), s, mm256_set1_pd(F64_RA1)), s, mm256_set1_pd(F64_RA0));
					v256 qTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_SA8), s, mm256_set1_pd(F64_SA7)), s, mm256_set1_pd(F64_SA6)), s, mm256_set1_pd(F64_SA5)), s, mm256_set1_pd(F64_SA4)), s, mm256_set1_pd(F64_SA3)), s, mm256_set1_pd(F64_SA2)), s, mm256_set1_pd(F64_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_RB6), s, mm256_set1_pd(F64_RB5)), s, mm256_set1_pd(F64_RB4)), s, mm256_set1_pd(F64_RB3)), s, mm256_set1_pd(F64_RB2)), s, mm256_set1_pd(F64_RB1)), s, mm256_set1_pd(F64_RB0));
					v256 qFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_SB7), s, mm256_set1_pd(F64_SB6)), s, mm256_set1_pd(F64_SB5)), s, mm256_set1_pd(F64_SB4)), s, mm256_set1_pd(F64_SB3)), s, mm256_set1_pd(F64_SB2)), s, mm256_set1_pd(F64_SB1)), s, ONE);

					p = Avx.mm256_blendv_pd(pFalse, pTrue, bound4Mask);
					q = Avx.mm256_blendv_pd(qFalse, qTrue, bound4Mask);

					v256 exp1 = Avx.mm256_add_pd(Avx.mm256_div_pd(p, q), mulExp1);
					double4 r0 = math.exp(*(double4*)&exp0);
					double4 r1 = math.exp(*(double4*)&exp1);
					result4 = Avx.mm256_mul_pd(*(v256*)&r0, *(v256*)&r1);

					result4 = mm256_fmadd_pd(result4, rcp, summands);

					return Avx.mm256_blendv_pd(result4, result, allResultsFoundMask);
                }
				else throw new IllegalInstructionException();
			}
		}
	}


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the value of the error function for <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        public static float erf(float x, Promise promises = Promise.Nothing)
        {
			int asInt = math.asint(x);
			int absAsInt = asInt & 0x7FFF_FFFF;

			if (promises.Promises(Promise.Unsafe0))
			{
				if (Hint.Unlikely(absAsInt >= 0x7F80_0000))
				{
				    return math.rcp(x) + copysign(1f, asInt, Promise.NonZero);
				}
			}

			if (absAsInt < 0x3F58_0000)
			{
			    if (absAsInt < 0x3180_0000)
				{
					return 0.125f * (8f * x + F32_EFX * x);
			    }

			    float sq = x * x;
			    float p = math.mad(math.mad(math.mad(math.mad(F32_PP4, sq, F32_PP3), sq, F32_PP2), sq, F32_PP1), sq, F32_PP0);
			    float q = math.mad(math.mad(math.mad(math.mad(math.mad(F32_QQ5, sq, F32_QQ4), sq, F32_QQ3), sq, F32_QQ2), sq, F32_QQ1), sq, 1f);

			    return math.mad(x, p / q, x);
			}
			else
			{
				float abs = math.asfloat(absAsInt);
				int signX = tobyte(x < 0) << 31;

				if (absAsInt > 0x40BF_FFFF)
				{
					return math.asfloat(signX ^ math.asint(1f - F32_TINY));
				}
				else if (absAsInt < 0x3FA0_0000)
				{
				    float s = abs - 1f;
				    float p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_PA6, s, F32_PA5), s, F32_PA4), s, F32_PA3), s, F32_PA2), s, F32_PA1), s, F32_PA0);
				    float q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_QA6, s, F32_QA5), s, F32_QA4), s, F32_QA3), s, F32_QA2), s, F32_QA1), s, 1f);
					int resultI32 = signX ^ math.asint(p / q);

					return math.asfloat(resultI32) + math.asfloat(math.asint(F32_ERX) ^ signX);
				}
				else
				{
					float rcp = math.rcp(x);
		 			float s = rcp * rcp;
					float p;
					float q;
					if (absAsInt < 0x4036_DB6D)
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_RA7, s, F32_RA6), s, F32_RA5), s, F32_RA4), s, F32_RA3), s, F32_RA2), s, F32_RA1), s, F32_RA0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_SA8, s, F32_SA7), s, F32_SA6), s, F32_SA5), s, F32_SA4), s, F32_SA3), s, F32_SA2), s, F32_SA1), s, 1f);
					}
					else
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_RB6, s, F32_RB5), s, F32_RB4), s, F32_RB3), s, F32_RB2), s, F32_RB1), s, F32_RB0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_SB7, s, F32_SB6), s, F32_SB5), s, F32_SB4), s, F32_SB3), s, F32_SB2), s, F32_SB1), s, 1f);
					}


					float z = math.asfloat(math.asuint(x) & 0xFFFF_E000);
					float2 exp = math.exp(new float2(-z * z - 0.5625f, math.mad(z, z, -(abs * abs)) + p / q));
					float result = cprod(exp);

					return math.mad(-rcp, result, math.asfloat(math.asint(1f) ^ signX));
				}
			}
        }

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 erf(float2 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat2(Xse.erf_ps(RegisterConversion.ToV128(x), 2, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new float2(erf(x.x, promises), erf(x.y, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 erf(float3 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat3(Xse.erf_ps(RegisterConversion.ToV128(x), 3, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new float3(erf(x.x, promises), erf(x.y, promises), erf(x.z, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 erf(float4 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat4(Xse.erf_ps(RegisterConversion.ToV128(x), 4, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new float4(erf(x.x, promises), erf(x.y, promises), erf(x.z, promises), erf(x.w, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 erf(float8 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return Xse.mm256_erf_ps(x, promises.Promises(Promise.Unsafe0));
            }
			else
			{
				return new float8(erf(x.v4_0, promises), erf(x.v4_4, promises));
			}
		}


		/// <summary>       Returns the value of the error function for <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double erf(double x, Promise promises = Promise.Nothing)
		{
			int hiInt = *((int*)&x + 1);
			int hiAbs = hiInt & 0x7FFF_FFFF;

			if (promises.Promises(Promise.Unsafe0))
			{
				if (Hint.Unlikely(hiAbs >= 0x7FF0_0000))
				{
				    return math.rcp(x) + copysign(1d, hiInt, Promise.NonZero);
				}
			}

			if (hiAbs < 0x3FEB_0000)
			{
			    if (hiAbs < 0x3E30_0000)
				{
					if (hiAbs < 0x0080_0000)
					{
						return 0.125d * (8.0d * x + F64_EFX8 * x);
					}

					return x + F64_EFX * x;
			    }

			    double sq = x * x;
			    double p = math.mad(math.mad(math.mad(math.mad(F64_PP4, sq, F64_PP3), sq, F64_PP2), sq, F64_PP1), sq, F64_PP0);
			    double q = math.mad(math.mad(math.mad(math.mad(math.mad(F64_QQ5, sq, F64_QQ4), sq, F64_QQ3), sq, F64_QQ2), sq, F64_QQ1), sq, 1d);

			    return math.mad(x, p / q, x);
			}
			else
			{
				ulong signX = (ulong)tobyte(x < 0) << 63;

				if (hiAbs > 0x4017_FFFF)
				{
					return math.asdouble(signX ^ math.asulong(1d - F64_TINY));
				}
				else if (hiAbs < 0x3FF4_0000)
				{
				    double s = math.abs(x) - 1d;
				    double p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_PA6, s, F64_PA5), s, F64_PA4), s, F64_PA3), s, F64_PA2), s, F64_PA1), s, F64_PA0);
				    double q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_QA6, s, F64_QA5), s, F64_QA4), s, F64_QA3), s, F64_QA2), s, F64_QA1), s, 1d);
					ulong resultI64 = signX ^ math.asulong(p / q);

					return math.asdouble(resultI64) + math.asdouble(math.asulong(F64_ERX) ^ signX);
				}
				else
				{
					double rcp = math.rcp(x);
		 			double s = rcp * rcp;
					double p;
					double q;
					if (hiAbs < 0x4006_DB6E)
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_RA7, s, F64_RA6), s, F64_RA5), s, F64_RA4), s, F64_RA3), s, F64_RA2), s, F64_RA1), s, F64_RA0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_SA8, s, F64_SA7), s, F64_SA6), s, F64_SA5), s, F64_SA4), s, F64_SA3), s, F64_SA2), s, F64_SA1), s, 1d);
					}
					else
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_RB6, s, F64_RB5), s, F64_RB4), s, F64_RB3), s, F64_RB2), s, F64_RB1), s, F64_RB0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_SB7, s, F64_SB6), s, F64_SB5), s, F64_SB4), s, F64_SB3), s, F64_SB2), s, F64_SB1), s, 1d);
					}

					double abs = math.abs(x);
					double z = math.asdouble(0xFFFF_FFFF_0000_0000 & math.asulong(abs));
					double2 exp = math.exp(new double2(-z * z - 0.5625, math.mad(z, z, -(abs * abs)) + p / q));
					double result = cprod(exp);

					return math.mad(-rcp, result, math.asdouble(math.asulong(1d) ^ signX));
				}
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 erf(double2 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToDouble2(Xse.erf_pd(RegisterConversion.ToV128(x), promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new double2(erf(x.x, promises), erf(x.y, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 erf(double3 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return RegisterConversion.ToDouble3(Xse.mm256_erf_pd(RegisterConversion.ToV256(x), 3, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new double3(erf(x.xy, promises), erf(x.z, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 erf(double4 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return RegisterConversion.ToDouble4(Xse.mm256_erf_pd(RegisterConversion.ToV256(x), 4, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new double4(erf(x.xy, promises), erf(x.zw, promises));
			}
		}


		/// <summary>       Returns the value of the complementary error function for <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float erfc(float x, Promise promises = Promise.Nothing)
		{
			int asInt = math.asint(x);
			int absAsInt = asInt & 0x7FFF_FFFF;
		    int signX = tobyte(x < 0f);

			if (promises.Promises(Promise.Unsafe0))
			{
				if (Hint.Unlikely(absAsInt > 0x7F7F_FFFF))
				{
				    return (signX << 1) + math.rcp(x);
				}
			}

			if (absAsInt < 0x3F58_0000)
			{
				float oneMinus = 1f - x;

		        if (absAsInt < 0x2380_0000)
				{
		            return oneMinus;
				}

				float sq = x * x;
				float p = math.mad(math.mad(math.mad(math.mad(F32_PP4, sq, F32_PP3), sq, F32_PP2), sq, F32_PP1), sq, F32_PP0);
				float q = math.mad(math.mad(math.mad(math.mad(math.mad(F32_QQ5, sq, F32_QQ4), sq, F32_QQ3), sq, F32_QQ2), sq, F32_QQ1), sq, 1f);
		        float y = p / q;

				return oneMinus - x * y;
		    }
		    else if (absAsInt > 0x403E_FFFF)
			{
				return tobool(signX) ? 2f - F32_TINY : F32_TINY * F32_TINY;
		    }
			else
			{
				float summand = (float)(signX << 1);

				if (absAsInt < 0x3FA0_0000)
				{
				    float s = math.abs(x) - 1f;
				    float p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_PA6, s, F32_PA5), s, F32_PA4), s, F32_PA3), s, F32_PA2), s, F32_PA1), s, F32_PA0);
				    float q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_QA6, s, F32_QA5), s, F32_QA4), s, F32_QA3), s, F32_QA2), s, F32_QA1), s, 1f);

					int sign = signX << 31;

					return (summand + math.asfloat(sign ^ math.asint(1f - F32_ERX))) - math.asfloat(sign ^ math.asint(p / q));
				}
				else
				{
					float rcp = math.rcp(x);
		 			float s = rcp * rcp;
					float p;
					float q;
					if (absAsInt < 0x4006_DB6D)
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_RA7, s, F32_RA6), s, F32_RA5), s, F32_RA4), s, F32_RA3), s, F32_RA2), s, F32_RA1), s, F32_RA0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_SA8, s, F32_SA7), s, F32_SA6), s, F32_SA5), s, F32_SA4), s, F32_SA3), s, F32_SA2), s, F32_SA1), s, 1f);
					}
					else
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_RB6, s, F32_RB5), s, F32_RB4), s, F32_RB3), s, F32_RB2), s, F32_RB1), s, F32_RB0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F32_SB7, s, F32_SB6), s, F32_SB5), s, F32_SB4), s, F32_SB3), s, F32_SB2), s, F32_SB1), s, 1f);
					}

					float z = math.asfloat(0xFFFF_E000u & (uint)absAsInt);
					float2 exp = math.exp(new float2(-z * z - 0.5625f, math.mad(z, z, -(math.asfloat(absAsInt) * math.asfloat(absAsInt))) + p / q));

					return math.mad(cprod(exp), rcp, summand);
				}
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 erfc(float2 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat2(Xse.erfc_ps(RegisterConversion.ToV128(x), 2, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new float2(erfc(x.x, promises), erfc(x.y, promises));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 erfc(float3 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat3(Xse.erfc_ps(RegisterConversion.ToV128(x), 3, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new float3(erfc(x.x, promises), erfc(x.y, promises), erfc(x.z, promises));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 erfc(float4 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat4(Xse.erfc_ps(RegisterConversion.ToV128(x), 4, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new float4(erfc(x.x, promises), erfc(x.y, promises), erfc(x.z, promises), erfc(x.w, promises));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 erfc(float8 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return Xse.mm256_erfc_ps(x, promises.Promises(Promise.Unsafe0));
            }
			else
			{
				return new float8(erfc(x.v4_0, promises), erfc(x.v4_4, promises));
			}
		}


		/// <summary>       Returns the value of the complementary error function for <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double erfc(double x, Promise promises = Promise.Nothing)
		{
			int hiInt = *((int*)&x + 1);
			int hiAbs = hiInt & 0x7FFF_FFFF;
		    int signX = tobyte(x < 0d);

			if (promises.Promises(Promise.Unsafe0))
			{
				if (Hint.Unlikely(hiAbs > 0x7FEF_FFFF))
				{
				    return (signX << 1) + math.rcp(x);
				}
			}

			if (hiAbs < 0x3FEB_0000)
			{
				double oneMinus = 1d - x;

		        if (hiAbs < 0x3C70_0000)
				{
		            return oneMinus;
				}

				double sq = x * x;
				double p = math.mad(math.mad(math.mad(math.mad(F64_PP4, sq, F64_PP3), sq, F64_PP2), sq, F64_PP1), sq, F64_PP0);
				double q = math.mad(math.mad(math.mad(math.mad(math.mad(F64_QQ5, sq, F64_QQ4), sq, F64_QQ3), sq, F64_QQ2), sq, F64_QQ1), sq, 1d);
		        double y = p / q;

				return oneMinus - x * y;
		    }
		    else if (hiAbs > 0x403E_FFFF)
			{
				return tobool(signX) ? 2 - math.asdouble(0x0010_0000_0000_0000) : math.asdouble(0x0010_0000_0000_0000) * math.asdouble(0x0010_0000_0000_0000);
		    }
			else
			{
				double summand = (double)(signX << 1);

				if (hiAbs < 0x3FF4_0000)
				{
				    double s = math.abs(x) - 1d;
				    double p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_PA6, s, F64_PA5), s, F64_PA4), s, F64_PA3), s, F64_PA2), s, F64_PA1), s, F64_PA0);
				    double q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_QA6, s, F64_QA5), s, F64_QA4), s, F64_QA3), s, F64_QA2), s, F64_QA1), s, 1d);

					ulong sign = (ulong)signX << 63;

					return (summand + math.asdouble(sign ^ math.asulong(1d - F64_ERX))) - math.asdouble(sign ^ math.asulong(p / q));
				}
				else
				{
					double rcp = math.rcp(x);
		 			double s = rcp * rcp;
					double p;
					double q;
					if (hiAbs < 0x4006_DB6D)
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_RA7, s, F64_RA6), s, F64_RA5), s, F64_RA4), s, F64_RA3), s, F64_RA2), s, F64_RA1), s, F64_RA0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_SA8, s, F64_SA7), s, F64_SA6), s, F64_SA5), s, F64_SA4), s, F64_SA3), s, F64_SA2), s, F64_SA1), s, 1d);
					}
					else
					{
					    p = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_RB6, s, F64_RB5), s, F64_RB4), s, F64_RB3), s, F64_RB2), s, F64_RB1), s, F64_RB0);
					    q = math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(math.mad(F64_SB7, s, F64_SB6), s, F64_SB5), s, F64_SB4), s, F64_SB3), s, F64_SB2), s, F64_SB1), s, 1d);
					}

					double abs = math.abs(x);
					double z = math.asdouble(0xFFFF_FFFF_0000_0000 & math.asulong(abs));
					double2 exp = math.exp(new double2(-z * z - 0.5625, math.mad(z, z, -(abs * abs)) + p / q));

					return math.mad(cprod(exp), rcp, summand);
				}
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 erfc(double2 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToDouble2(Xse.erfc_pd(RegisterConversion.ToV128(x), promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new double2(erfc(x.x, promises), erfc(x.y, promises));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 erfc(double3 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return RegisterConversion.ToDouble3(Xse.mm256_erfc_pd(RegisterConversion.ToV256(x), 3, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new double3(erfc(x.xy, promises), erfc(x.z, promises));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 erfc(double4 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return RegisterConversion.ToDouble4(Xse.mm256_erfc_pd(RegisterConversion.ToV256(x), 4, promises.Promises(Promise.Unsafe0)));
            }
			else
			{
				return new double4(erfc(x.xy, promises), erfc(x.zw, promises));
			}
		}
	}
}