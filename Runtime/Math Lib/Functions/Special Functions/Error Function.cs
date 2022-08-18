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
			public static v128 erf_ps(v128 a, byte elements = 4) 
			{
			    if (Sse2.IsSse2Supported)
			    {
					v128 ABS_MASK = Sse2.set1_epi32(0x7FFF_FFFF);
					v128 ONE = Sse.set1_ps(1f);

					v128 abs = Sse2.and_si128(a, ABS_MASK);


					v128 rcp = Sse.div_ps(ONE, a);
					v128 nanInfResult = movsign_epi32(Sse2.set1_epi32(1), a, false, elements);
					nanInfResult = Sse.add_ps(rcp, Sse2.cvtepi32_ps(nanInfResult));
					
					v128 allResultsFoundMask = Sse2.cmpgt_epi32(abs, Sse2.set1_epi32(0x7F7F_FFFF));
					v128 result = Sse.and_ps(allResultsFoundMask, nanInfResult);
					
					v128 bound0Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x3F58_0000), abs);
					v128 bound1Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x3180_0000), abs);
					allResultsFoundMask = Sse2.or_si128(bound0Mask, allResultsFoundMask);
					
					v128 sq = Sse.mul_ps(a, a); 
					
					v128 s = sq;
					v128 p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_PP4), s, Sse.set1_ps(F32_PP3)), s, Sse.set1_ps(F32_PP2)), s, Sse.set1_ps(F32_PP1)), s, Sse.set1_ps(F32_PP0));
					v128 q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_QQ5), s, Sse.set1_ps(F32_QQ4)), s, Sse.set1_ps(F32_QQ3)), s, Sse.set1_ps(F32_QQ2)), s, Sse.set1_ps(F32_QQ1)), s, ONE);
					v128 result0 = Sse.div_ps(p, q);
					result0 = fmadd_ps(result0, a, a);
					result = blendv_ps(result, result0, bound0Mask);
					
					v128 result1 = Sse.mul_ps(Sse.set1_ps(0.125f), Sse.add_ps(Sse.mul_ps(Sse.set1_ps(8f), a), Sse.mul_ps(Sse.set1_ps(F32_EFX), a)));
					result = blendv_ps(result, result1, bound1Mask);


                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					v128 absA = Sse.and_ps(ABS_MASK, a);
					v128 signA = Sse.andnot_ps(ABS_MASK, a);
					
					v128 bound3Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x3FA0_0000), abs);
					bound3Mask = Sse2.andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound3Mask);

					s = Sse.sub_ps(absA, ONE);
					p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_PA6), s, Sse.set1_ps(F32_PA5)), s, Sse.set1_ps(F32_PA4)), s, Sse.set1_ps(F32_PA3)), s, Sse.set1_ps(F32_PA2)), s, Sse.set1_ps(F32_PA1)), s, Sse.set1_ps(F32_PA0));
					q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_QA6), s, Sse.set1_ps(F32_QA5)), s, Sse.set1_ps(F32_QA4)), s, Sse.set1_ps(F32_QA3)), s, Sse.set1_ps(F32_QA2)), s, Sse.set1_ps(F32_QA1)), s, ONE);
					v128 result3 = Sse.div_ps(p, q);
					result3 = Sse.xor_ps(result3, signA);
					result3 = Sse.add_ps(Sse.xor_ps(Sse.set1_ps(F32_ERX), signA), result3);
					result = blendv_ps(result, result3, bound3Mask);
					
					
					v128 bound4Mask = Sse2.cmpgt_epi32(abs, Sse2.set1_epi32(0x40BF_FFFF));
					bound4Mask = Sse2.andnot_si128(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound4Mask);
					v128 result4 = Sse.xor_ps(signA, Sse.set1_ps(1f - F32_TINY));
					result = blendv_ps(result, result4, bound4Mask);

					
                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }
					
					
			 		s = Sse.div_ps(ONE, sq);
					v128 bound5Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x4036_DB6D), abs);
					v128 exp0 = fnmadd_ps(abs, abs, Sse.set1_ps(-0.5625f));
					v128 mulExp1 = Sse.mul_ps(Sse.sub_ps(abs, absA), Sse.add_ps(abs, absA));
					v128 result5 = default;

					if (elements > 2)
					{
                        if (Avx.IsAvxSupported)
                        {
							v256 ss = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(s), s, 1);
							
							v128 qTrue = fmadd_ps(Sse.set1_ps(F32_SA8), s, Sse.set1_ps(F32_SA7));
							v256 __0True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RA7)), qTrue, 1);
							v256 __1True = new v256(F32_RA6, F32_RA6, F32_RA6, F32_RA6,		F32_SA6, F32_SA6, F32_SA6, F32_SA6);
							v256 __2True = new v256(F32_RA5, F32_RA5, F32_RA5, F32_RA5,		F32_SA5, F32_SA5, F32_SA5, F32_SA5);
							v256 __3True = new v256(F32_RA4, F32_RA4, F32_RA4, F32_RA4,		F32_SA4, F32_SA4, F32_SA4, F32_SA4);
							v256 __4True = new v256(F32_RA3, F32_RA3, F32_RA3, F32_RA3,		F32_SA3, F32_SA3, F32_SA3, F32_SA3);
							v256 __5True = new v256(F32_RA2, F32_RA2, F32_RA2, F32_RA2,		F32_SA2, F32_SA2, F32_SA2, F32_SA2);
							v256 __6True = new v256(F32_RA1, F32_RA1, F32_RA1, F32_RA1,		F32_SA1, F32_SA1, F32_SA1, F32_SA1);
							v256 __7True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RA0)), ONE, 1);
							
							v128 qFalse = fmadd_ps(Sse.set1_ps(F32_SB7), s, Sse.set1_ps(F32_SB6));
							v256 __0False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RB6)), qFalse, 1);
							v256 __1False = new v256(F32_RB5, F32_RB5, F32_RB5, F32_RB5,	F32_SB5, F32_SB5, F32_SB5, F32_SB5);
							v256 __2False = new v256(F32_RB4, F32_RB4, F32_RB4, F32_RB4,	F32_SB4, F32_SB4, F32_SB4, F32_SB4);
							v256 __3False = new v256(F32_RB3, F32_RB3, F32_RB3, F32_RB3,	F32_SB3, F32_SB3, F32_SB3, F32_SB3);
							v256 __4False = new v256(F32_RB2, F32_RB2, F32_RB2, F32_RB2,	F32_SB2, F32_SB2, F32_SB2, F32_SB2);
							v256 __5False = new v256(F32_RB1, F32_RB1, F32_RB1, F32_RB1,	F32_SB1, F32_SB1, F32_SB1, F32_SB1);
							v256 __6False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RB0)), ONE, 1);
					
							v256 pqTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True); 
							v256 pqFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False); 
							
							v256 mask = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(bound5Mask), bound5Mask, 1);
							v256 pq = Avx.mm256_blendv_ps(pqFalse, pqTrue, mask);
							v256 mulExp1_256 = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(mulExp1), mulExp1, 1);
					
                            pq = mm256_fdadd_ps(Avx.mm256_permute2f128_ps(pq, pq, 0b0000_0001), pq, mulExp1_256);
							v256 exp = maxmath.exp(Avx.mm256_permute2f128_ps(Avx.mm256_castps128_ps256(exp0), pq, 0b0011_0000));
							result5 = Sse.mul_ps(Avx.mm256_castps256_ps128(exp), Avx.mm256_extractf128_ps(exp, 1));
                        }
						else
						{
							v128 qTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_SA8), s, Sse.set1_ps(F32_SA7)), s, Sse.set1_ps(F32_SA6)), s, Sse.set1_ps(F32_SA5)), s, Sse.set1_ps(F32_SA4)), s, Sse.set1_ps(F32_SA3)), s, Sse.set1_ps(F32_SA2)), s, Sse.set1_ps(F32_SA1)), s, ONE);
							v128 pTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_RA7), s, Sse.set1_ps(F32_RA6)), s, Sse.set1_ps(F32_RA5)), s, Sse.set1_ps(F32_RA4)), s, Sse.set1_ps(F32_RA3)), s, Sse.set1_ps(F32_RA2)), s, Sse.set1_ps(F32_RA1)), s, Sse.set1_ps(F32_RA0));

							v128 qFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_SB7), s, Sse.set1_ps(F32_SB6)), s, Sse.set1_ps(F32_SB5)), s, Sse.set1_ps(F32_SB4)), s, Sse.set1_ps(F32_SB3)), s, Sse.set1_ps(F32_SB2)), s, Sse.set1_ps(F32_SB1)), s, ONE);
							v128 pFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_RB6), s, Sse.set1_ps(F32_RB5)), s, Sse.set1_ps(F32_RB4)), s, Sse.set1_ps(F32_RB3)), s, Sse.set1_ps(F32_RB2)), s, Sse.set1_ps(F32_RB1)), s, Sse.set1_ps(F32_RB0));
							
							p = blendv_ps(pFalse, pTrue, bound5Mask);
							q = blendv_ps(qFalse, qTrue, bound5Mask);

							v128 exp1 = fdadd_ps(p, q, mulExp1);
							float4 r0 = math.exp(*(float4*)&exp0);
							float4 r1 = math.exp(*(float4*)&exp1);
							result5 = Sse.mul_ps(*(v128*)&r0, *(v128*)&r1);
						}
					}
					else
					{
						v128 ss = Sse2.unpacklo_pd(s, s);
							
						v128 qTrue = fmadd_ps(Sse.set1_ps(F32_SA8), s, Sse.set1_ps(F32_SA7));
						v128 __0True = Sse2.unpacklo_pd(Sse.set1_ps(F32_RA7), qTrue);
						v128 __1True = new v128(F32_RA6, F32_RA6, F32_SA6, F32_SA6);
						v128 __2True = new v128(F32_RA5, F32_RA5, F32_SA5, F32_SA5);
						v128 __3True = new v128(F32_RA4, F32_RA4, F32_SA4, F32_SA4);
						v128 __4True = new v128(F32_RA3, F32_RA3, F32_SA3, F32_SA3);
						v128 __5True = new v128(F32_RA2, F32_RA2, F32_SA2, F32_SA2);
						v128 __6True = new v128(F32_RA1, F32_RA1, F32_SA1, F32_SA1);
						v128 __7True = Sse2.unpacklo_pd(Sse.set1_ps(F32_RA0), ONE);
						
						v128 qFalse = fmadd_ps(Sse.set1_ps(F32_SB7), s, Sse.set1_ps(F32_SB6));
						v128 __0False = Sse2.unpacklo_pd(Sse.set1_ps(F32_RB6), qFalse);
						v128 __1False = new v128(F32_RB5, F32_RB5, F32_SB5, F32_SB5);
						v128 __2False = new v128(F32_RB4, F32_RB4, F32_SB4, F32_SB4);
						v128 __3False = new v128(F32_RB3, F32_RB3, F32_SB3, F32_SB3);
						v128 __4False = new v128(F32_RB2, F32_RB2, F32_SB2, F32_SB2);
						v128 __5False = new v128(F32_RB1, F32_RB1, F32_SB1, F32_SB1);
						v128 __6False = Sse2.unpacklo_pd(Sse.set1_ps(F32_RB0), ONE);
						
						v128 pqTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True); 
						v128 pqFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False); 
						
						v128 mask = Sse2.unpacklo_pd(bound5Mask, bound5Mask);
						v128 mulExp1_128 = Sse2.unpacklo_pd(mulExp1, mulExp1);
					
						v128 pq = blendv_ps(pqFalse, pqTrue, mask);
						pq = Sse.div_ps(pq, Sse2.bsrli_si128(pq, 2 * sizeof(float)));
						pq = Sse.add_ps(pq, mulExp1_128);
						v128 exp = Sse2.unpacklo_pd(exp0, pq); 
						float4 exp4 = math.exp(*(float4*)&exp);
						exp = *(v128*)&exp4;
						result5 = Sse.mul_ps(exp, Sse2.bsrli_si128(exp, 2 * sizeof(float)));
					}

					result5 = fnmsub_ps(result5, rcp, ONE);
					result = blendv_ps(result5, result, allResultsFoundMask);

					return result;
				}
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erf_ps(v256 a) 
			{
			    if (Avx2.IsAvx2Supported)
			    {
					v256 ABS_MASK = Avx.mm256_set1_epi32(0x7FFF_FFFF);
					v256 ONE = Avx.mm256_set1_ps(1f);

					v256 abs = Avx2.mm256_and_si256(a, ABS_MASK);


					v256 rcp = Avx.mm256_div_ps(ONE, a);
					v256 nanInfResult = mm256_movsign_epi32(Avx.mm256_set1_epi32(1), a);
					nanInfResult = Avx.mm256_add_ps(rcp, Avx.mm256_cvtepi32_ps(nanInfResult));
					
					v256 allResultsFoundMask = Avx2.mm256_cmpgt_epi32(abs, Avx.mm256_set1_epi32(0x7F7F_FFFF));
					v256 result = Avx.mm256_and_ps(allResultsFoundMask, nanInfResult);
					
					v256 bound0Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3F58_0000), abs);
					v256 bound1Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3180_0000), abs);
					allResultsFoundMask = Avx2.mm256_or_si256(bound0Mask, allResultsFoundMask);
					
					v256 sq = Avx.mm256_mul_ps(a, a); 
					
					v256 s = sq;
					v256 p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_PP4), s, Avx.mm256_set1_ps(F32_PP3)), s, Avx.mm256_set1_ps(F32_PP2)), s, Avx.mm256_set1_ps(F32_PP1)), s, Avx.mm256_set1_ps(F32_PP0));
					v256 q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_QQ5), s, Avx.mm256_set1_ps(F32_QQ4)), s, Avx.mm256_set1_ps(F32_QQ3)), s, Avx.mm256_set1_ps(F32_QQ2)), s, Avx.mm256_set1_ps(F32_QQ1)), s, ONE);
					v256 result0 = Avx.mm256_div_ps(p, q);
					result0 = mm256_fmadd_ps(result0, a, a);
					result = Avx.mm256_blendv_ps(result, result0, bound0Mask);
					
					v256 result1 = Avx.mm256_mul_ps(Avx.mm256_set1_ps(0.125f), Avx.mm256_add_ps(Avx.mm256_mul_ps(Avx.mm256_set1_ps(8f), a), Avx.mm256_mul_ps(Avx.mm256_set1_ps(F32_EFX), a)));
					result = Avx.mm256_blendv_ps(result, result1, bound1Mask);


                    if (Avx.mm256_movemask_ps(allResultsFoundMask) == 0b1111_1111) // 100% free; ILP
					{
						return result;
					}


					v256 absA = Avx.mm256_and_ps(ABS_MASK, a);
					v256 signA = Avx.mm256_andnot_ps(ABS_MASK, a);
					
					v256 bound3Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3FA0_0000), abs);
					bound3Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound3Mask);

					s = Avx.mm256_sub_ps(absA, ONE);
					p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_PA6), s, Avx.mm256_set1_ps(F32_PA5)), s, Avx.mm256_set1_ps(F32_PA4)), s, Avx.mm256_set1_ps(F32_PA3)), s, Avx.mm256_set1_ps(F32_PA2)), s, Avx.mm256_set1_ps(F32_PA1)), s, Avx.mm256_set1_ps(F32_PA0));
					q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_QA6), s, Avx.mm256_set1_ps(F32_QA5)), s, Avx.mm256_set1_ps(F32_QA4)), s, Avx.mm256_set1_ps(F32_QA3)), s, Avx.mm256_set1_ps(F32_QA2)), s, Avx.mm256_set1_ps(F32_QA1)), s, ONE);
					v256 result3 = Avx.mm256_div_ps(p, q);
					result3 = Avx.mm256_xor_ps(result3, signA);
					result3 = Avx.mm256_add_ps(Avx.mm256_xor_ps(Avx.mm256_set1_ps(F32_ERX), signA), result3);
					result = Avx.mm256_blendv_ps(result, result3, bound3Mask);
					
					
					v256 bound4Mask = Avx2.mm256_cmpgt_epi32(abs, Avx.mm256_set1_epi32(0x40BF_FFFF));
					bound4Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound4Mask);
					v256 result4 = Avx.mm256_xor_ps(signA, Avx.mm256_set1_ps(1f - F32_TINY));
					result = Avx.mm256_blendv_ps(result, result4, bound4Mask);

					
                    if (Avx.mm256_movemask_ps(allResultsFoundMask) == 0b1111_1111) // 100% free; ILP
					{
						return result;
					}
					
					
			 		s = Avx.mm256_div_ps(ONE, sq);
					v256 bound5Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x4036_DB6D), abs);
					v256 exp0 = mm256_fnmadd_ps(abs, abs, Avx.mm256_set1_ps(-0.5625f));
					v256 mulExp1 = Avx.mm256_mul_ps(Avx.mm256_sub_ps(abs, absA), Avx.mm256_add_ps(abs, absA));

					v256 pTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_RA7), s, Avx.mm256_set1_ps(F32_RA6)), s, Avx.mm256_set1_ps(F32_RA5)), s, Avx.mm256_set1_ps(F32_RA4)), s, Avx.mm256_set1_ps(F32_RA3)), s, Avx.mm256_set1_ps(F32_RA2)), s, Avx.mm256_set1_ps(F32_RA1)), s, Avx.mm256_set1_ps(F32_RA0));
					v256 qTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_SA8), s, Avx.mm256_set1_ps(F32_SA7)), s, Avx.mm256_set1_ps(F32_SA6)), s, Avx.mm256_set1_ps(F32_SA5)), s, Avx.mm256_set1_ps(F32_SA4)), s, Avx.mm256_set1_ps(F32_SA3)), s, Avx.mm256_set1_ps(F32_SA2)), s, Avx.mm256_set1_ps(F32_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_RB6), s, Avx.mm256_set1_ps(F32_RB5)), s, Avx.mm256_set1_ps(F32_RB4)), s, Avx.mm256_set1_ps(F32_RB3)), s, Avx.mm256_set1_ps(F32_RB2)), s, Avx.mm256_set1_ps(F32_RB1)), s, Avx.mm256_set1_ps(F32_RB0));
					v256 qFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_SB7), s, Avx.mm256_set1_ps(F32_SB6)), s, Avx.mm256_set1_ps(F32_SB5)), s, Avx.mm256_set1_ps(F32_SB4)), s, Avx.mm256_set1_ps(F32_SB3)), s, Avx.mm256_set1_ps(F32_SB2)), s, Avx.mm256_set1_ps(F32_SB1)), s, ONE);
					
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
			public static v128 erf_pd(v128 a) 
			{
				static v128 cmpHiGt(v128 a, v128 b)
				{
			        if (Sse4_1.IsSse41Supported)
			        {
						return Sse2.cmpgt_epi32(a, b);
			        }
					else if (Sse2.IsSse2Supported)
					{
						return Sse2.shuffle_epi32(Sse2.cmpgt_epi32(a, b), Sse.SHUFFLE(3, 3, 1, 1));
					}
					else throw new IllegalInstructionException();
				}


			    if (Sse2.IsSse2Supported)
			    {
					v128 ABS_MASK = Sse2.set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);
					v128 ONE = Sse2.set1_pd(1d);
					v128 HI32_MASK = Sse2.and_si128(a, Sse2.set1_epi64x(unchecked((long)0xFFFF_FFFF_0000_0000)));

					v128 hiAbs = Sse2.and_si128(HI32_MASK, ABS_MASK);


					v128 rcp = Sse2.div_pd(ONE, a);
					v128 nanInfResult = movsign_epi64(Sse2.set1_epi64x(1), a);
					nanInfResult = Sse2.add_pd(rcp, usfcvtepi64_pd(nanInfResult));
					
					v128 allResultsFoundMask = cmpHiGt(hiAbs, Sse2.set1_epi32(0x7FEF_FFFF));
					v128 result = Sse2.and_pd(allResultsFoundMask, nanInfResult);


					v128 bound0Mask = cmpHiGt(Sse2.set1_epi32(0x3FEB_0000), hiAbs);
					v128 bound1Mask = cmpHiGt(Sse2.set1_epi32(0x3E30_0000), hiAbs);
					v128 bound2Mask = cmpHiGt(Sse2.set1_epi32(0x0080_0000), hiAbs);
					allResultsFoundMask = Sse2.or_si128(bound0Mask, allResultsFoundMask);
					
					v128 sq = Sse2.mul_pd(a, a); 

					v128 s = sq;
					v128 p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_PP4), s, Sse2.set1_pd(F64_PP3)), s, Sse2.set1_pd(F64_PP2)), s, Sse2.set1_pd(F64_PP1)), s, Sse2.set1_pd(F64_PP0));
					v128 q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_QQ5), s, Sse2.set1_pd(F64_QQ4)), s, Sse2.set1_pd(F64_QQ3)), s, Sse2.set1_pd(F64_QQ2)), s, Sse2.set1_pd(F64_QQ1)), s, ONE);
					v128 result0 = Sse2.div_pd(p, q);
					result0 = fmadd_pd(result0, a, a);
					result = blendv_pd(result, result0, bound0Mask);

					v128 result1 = Sse2.mul_pd(Sse2.set1_pd(0.125d), Sse2.add_pd(Sse2.mul_pd(Sse2.set1_pd(8d), a), Sse2.mul_pd(Sse2.set1_pd(F64_EFX8), a)));
					result = blendv_pd(result, result1, bound1Mask);

					v128 result2 = fmadd_pd(Sse2.set1_pd(F64_EFX), a, a);
					result = blendv_pd(result, result2, bound2Mask);


					if (Sse2.movemask_pd(allResultsFoundMask) == 0b0011) // 100% free; ILP
					{
						return result;
					}


					v128 absA = Sse2.and_pd(ABS_MASK, a);
					v128 signA = Sse2.andnot_pd(ABS_MASK, a);
					
					v128 bound3Mask = cmpHiGt(Sse2.set1_epi32(0x3FF4_0000), hiAbs);
					bound3Mask = Sse2.andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound3Mask);

					s = Sse2.sub_pd(absA, ONE);
					p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_PA6), s, Sse2.set1_pd(F64_PA5)), s, Sse2.set1_pd(F64_PA4)), s, Sse2.set1_pd(F64_PA3)), s, Sse2.set1_pd(F64_PA2)), s, Sse2.set1_pd(F64_PA1)), s, Sse2.set1_pd(F64_PA0));
					q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_QA6), s, Sse2.set1_pd(F64_QA5)), s, Sse2.set1_pd(F64_QA4)), s, Sse2.set1_pd(F64_QA3)), s, Sse2.set1_pd(F64_QA2)), s, Sse2.set1_pd(F64_QA1)), s, ONE);
					v128 result3 = Sse2.div_pd(p, q);
					result3 = Sse2.xor_pd(result3, signA);
					result3 = Sse2.add_pd(Sse2.xor_pd(Sse2.set1_pd(F64_ERX), signA), result3);
					result = blendv_pd(result, result3, bound3Mask);
					
					
					v128 bound4Mask = cmpHiGt(hiAbs, Sse2.set1_epi32(0x4017_FFFF));
					bound4Mask = Sse2.andnot_si128(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound4Mask);
					v128 result4 = Sse2.xor_pd(signA, Sse2.set1_pd(1d - F64_TINY));
					result = blendv_pd(result, result4, bound4Mask);


					if (Sse2.movemask_pd(allResultsFoundMask) == 0b0011) // 100% free; ILP
					{
						return result;
					}
					
					
			 		s = Sse2.div_pd(ONE, sq);
					v128 bound5Mask = cmpHiGt(Sse2.set1_epi32(0x4006_DB6E), hiAbs);
					v128 exp0 = fnmadd_pd(hiAbs, hiAbs, Sse2.set1_pd(-0.5625d));
					v128 mulExp1 = Sse2.mul_pd(Sse2.sub_pd(hiAbs, absA), Sse2.add_pd(hiAbs, absA));
					v128 result5;

					if (Avx.IsAvxSupported)
					{
						v256 ss = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(s), s, 1);
						
						v128 qTrue = fmadd_pd(Sse2.set1_pd(F64_SA8), s, Sse2.set1_pd(F64_SA7));
						v256 __0True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RA7)), qTrue, 1);
						v256 __1True = new v256(F64_RA6, F64_RA6, F64_SA6, F64_SA6);
						v256 __2True = new v256(F64_RA5, F64_RA5, F64_SA5, F64_SA5);
						v256 __3True = new v256(F64_RA4, F64_RA4, F64_SA4, F64_SA4);
						v256 __4True = new v256(F64_RA3, F64_RA3, F64_SA3, F64_SA3);
						v256 __5True = new v256(F64_RA2, F64_RA2, F64_SA2, F64_SA2);
						v256 __6True = new v256(F64_RA1, F64_RA1, F64_SA1, F64_SA1);
						v256 __7True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RA0)), ONE, 1);
						
						v128 qFalse = fmadd_pd(Sse2.set1_pd(F64_SB7), s, Sse2.set1_pd(F64_SB6));
						v256 __0False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RB6)), qFalse, 1);
						v256 __1False = new v256(F64_RB5, F64_RB5, F64_SB5, F64_SB5);
						v256 __2False = new v256(F64_RB4, F64_RB4, F64_SB4, F64_SB4);
						v256 __3False = new v256(F64_RB3, F64_RB3, F64_SB3, F64_SB3);
						v256 __4False = new v256(F64_RB2, F64_RB2, F64_SB2, F64_SB2);
						v256 __5False = new v256(F64_RB1, F64_RB1, F64_SB1, F64_SB1);
						v256 __6False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RB0)), ONE, 1);

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
						result5 = Sse2.mul_pd(Avx.mm256_castpd256_pd128(exp), Avx.mm256_extractf128_pd(exp, 1));
					}
					else
					{
						v128 pTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_RA7), s, Sse2.set1_pd(F64_RA6)), s, Sse2.set1_pd(F64_RA5)), s, Sse2.set1_pd(F64_RA4)), s, Sse2.set1_pd(F64_RA3)), s, Sse2.set1_pd(F64_RA2)), s, Sse2.set1_pd(F64_RA1)), s, Sse2.set1_pd(F64_RA0));
						v128 qTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_SA8), s, Sse2.set1_pd(F64_SA7)), s, Sse2.set1_pd(F64_SA6)), s, Sse2.set1_pd(F64_SA5)), s, Sse2.set1_pd(F64_SA4)), s, Sse2.set1_pd(F64_SA3)), s, Sse2.set1_pd(F64_SA2)), s, Sse2.set1_pd(F64_SA1)), s, ONE);

						v128 pFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_RB6), s, Sse2.set1_pd(F64_RB5)), s, Sse2.set1_pd(F64_RB4)), s, Sse2.set1_pd(F64_RB3)), s, Sse2.set1_pd(F64_RB2)), s, Sse2.set1_pd(F64_RB1)), s, Sse2.set1_pd(F64_RB0));
						v128 qFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_SB7), s, Sse2.set1_pd(F64_SB6)), s, Sse2.set1_pd(F64_SB5)), s, Sse2.set1_pd(F64_SB4)), s, Sse2.set1_pd(F64_SB3)), s, Sse2.set1_pd(F64_SB2)), s, Sse2.set1_pd(F64_SB1)), s, ONE);
						
						p = blendv_pd(pFalse, pTrue, bound5Mask);
						q = blendv_pd(qFalse, qTrue, bound5Mask);

						v128 exp1 = Sse2.add_pd(Sse2.div_pd(p, q), mulExp1);
						double2 r0 = math.exp(*(double2*)&exp0);
						double2 r1 = math.exp(*(double2*)&exp1);
						result5 = Sse2.mul_pd(*(v128*)&r0, *(v128*)&r1);
					}

					result5 = fnmsub_pd(result5, rcp, ONE);
					result = blendv_pd(result5, result, allResultsFoundMask);

					return result;
				}
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erf_pd(v256 a, byte elements = 4) 
			{
			    if (Avx2.IsAvx2Supported)
			    {
					v256 ABS_MASK = Avx.mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);
					v256 ONE = Avx.mm256_set1_pd(1d);
					v256 HI32_MASK = Avx.mm256_and_pd(a, Avx.mm256_set1_epi64x(unchecked((long)0xFFFF_FFFF_0000_0000)));

					v256 hiAbs = Avx.mm256_and_pd(HI32_MASK, ABS_MASK);


					v256 rcp = Avx.mm256_div_pd(ONE, a);
					v256 nanInfResult = mm256_movsign_epi64(Avx.mm256_set1_epi64x(1), a);
					nanInfResult = Avx.mm256_add_pd(rcp, mm256_usfcvtepi64_pd(nanInfResult));
					
					v256 allResultsFoundMask = Avx2.mm256_cmpgt_epi32(hiAbs, Avx.mm256_set1_epi32(0x7FEF_FFFF));
					v256 result = Avx.mm256_and_pd(allResultsFoundMask, nanInfResult);

					v256 bound0Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3FEB_0000), hiAbs);
					v256 bound1Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3E30_0000), hiAbs);
					v256 bound2Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x0080_0000), hiAbs);
					allResultsFoundMask = Avx2.mm256_or_si256(bound0Mask, allResultsFoundMask);

					v256 sq = Avx.mm256_mul_pd(a, a); 

					v256 s = sq;
					v256 p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_PP4), s, Avx.mm256_set1_pd(F64_PP3)), s, Avx.mm256_set1_pd(F64_PP2)), s, Avx.mm256_set1_pd(F64_PP1)), s, Avx.mm256_set1_pd(F64_PP0));
					v256 q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_QQ5), s, Avx.mm256_set1_pd(F64_QQ4)), s, Avx.mm256_set1_pd(F64_QQ3)), s, Avx.mm256_set1_pd(F64_QQ2)), s, Avx.mm256_set1_pd(F64_QQ1)), s, ONE);
					v256 result0 = Avx.mm256_div_pd(p, q);
					result0 = mm256_fmadd_pd(result0, a, a);
					result = Avx.mm256_blendv_pd(result, result0, bound0Mask);

					v256 result1 = Avx.mm256_mul_pd(Avx.mm256_set1_pd(0.125d), Avx.mm256_add_pd(Avx.mm256_mul_pd(Avx.mm256_set1_pd(8d), a), Avx.mm256_mul_pd(Avx.mm256_set1_pd(F64_EFX8), a)));
					result = Avx.mm256_blendv_pd(result, result1, bound1Mask);

					v256 result2 = mm256_fmadd_pd(Avx.mm256_set1_pd(F64_EFX), a, a);
					result = Avx.mm256_blendv_pd(result, result2, bound2Mask);

					
                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					v256 absA = Avx.mm256_and_pd(ABS_MASK, a);
					v256 signA = Avx.mm256_andnot_pd(ABS_MASK, a);
					
					v256 bound3Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3FF4_0000), hiAbs);
					bound3Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound3Mask);

					s = Avx.mm256_sub_pd(absA, ONE);
					p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_PA6), s, Avx.mm256_set1_pd(F64_PA5)), s, Avx.mm256_set1_pd(F64_PA4)), s, Avx.mm256_set1_pd(F64_PA3)), s, Avx.mm256_set1_pd(F64_PA2)), s, Avx.mm256_set1_pd(F64_PA1)), s, Avx.mm256_set1_pd(F64_PA0));
					q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_QA6), s, Avx.mm256_set1_pd(F64_QA5)), s, Avx.mm256_set1_pd(F64_QA4)), s, Avx.mm256_set1_pd(F64_QA3)), s, Avx.mm256_set1_pd(F64_QA2)), s, Avx.mm256_set1_pd(F64_QA1)), s, ONE);
					v256 result3 = Avx.mm256_div_pd(p, q);
					result3 = Avx.mm256_xor_pd(result3, signA);
					result3 = Avx.mm256_add_pd(Avx.mm256_xor_pd(Avx.mm256_set1_pd(F64_ERX), signA), result3);
					result = Avx.mm256_blendv_pd(result, result3, bound3Mask);
					
					
					v256 bound4Mask = Avx2.mm256_cmpgt_epi32(hiAbs, Avx.mm256_set1_epi32(0x4017_FFFF));
					bound4Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound4Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound4Mask);
					v256 result4 = Avx.mm256_xor_pd(signA, Avx.mm256_set1_pd(1d - F64_TINY));
					result = Avx.mm256_blendv_pd(result, result4, bound4Mask);

					
                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }
					
					
			 		s = Avx.mm256_div_pd(ONE, sq);
					v256 bound5Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x4006_DB6E), hiAbs);
					v256 exp0 = mm256_fnmadd_pd(hiAbs, hiAbs, Avx.mm256_set1_pd(-0.5625d));
					v256 mulExp1 = Avx.mm256_mul_pd(Avx.mm256_sub_pd(hiAbs, absA), Avx.mm256_add_pd(hiAbs, absA));
					v256 result5;
					
					v256 pTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_RA7), s, Avx.mm256_set1_pd(F64_RA6)), s, Avx.mm256_set1_pd(F64_RA5)), s, Avx.mm256_set1_pd(F64_RA4)), s, Avx.mm256_set1_pd(F64_RA3)), s, Avx.mm256_set1_pd(F64_RA2)), s, Avx.mm256_set1_pd(F64_RA1)), s, Avx.mm256_set1_pd(F64_RA0));
					v256 qTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_SA8), s, Avx.mm256_set1_pd(F64_SA7)), s, Avx.mm256_set1_pd(F64_SA6)), s, Avx.mm256_set1_pd(F64_SA5)), s, Avx.mm256_set1_pd(F64_SA4)), s, Avx.mm256_set1_pd(F64_SA3)), s, Avx.mm256_set1_pd(F64_SA2)), s, Avx.mm256_set1_pd(F64_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_RB6), s, Avx.mm256_set1_pd(F64_RB5)), s, Avx.mm256_set1_pd(F64_RB4)), s, Avx.mm256_set1_pd(F64_RB3)), s, Avx.mm256_set1_pd(F64_RB2)), s, Avx.mm256_set1_pd(F64_RB1)), s, Avx.mm256_set1_pd(F64_RB0));
					v256 qFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_SB7), s, Avx.mm256_set1_pd(F64_SB6)), s, Avx.mm256_set1_pd(F64_SB5)), s, Avx.mm256_set1_pd(F64_SB4)), s, Avx.mm256_set1_pd(F64_SB3)), s, Avx.mm256_set1_pd(F64_SB2)), s, Avx.mm256_set1_pd(F64_SB1)), s, ONE);
					
					p = Avx.mm256_blendv_pd(pFalse, pTrue, bound5Mask);
					q = Avx.mm256_blendv_pd(qFalse, qTrue, bound5Mask);

					v256 exp1 = Avx.mm256_add_pd(Avx.mm256_div_pd(p, q), mulExp1);
					double2 r0 = math.exp(*(double2*)&exp0);
					double2 r1 = math.exp(*(double2*)&exp1);
					result5 = Avx.mm256_mul_pd(*(v256*)&r0, *(v256*)&r1);

					result5 = mm256_fnmsub_pd(result5, rcp, ONE);
					result = Avx.mm256_blendv_pd(result5, result, allResultsFoundMask);

					return result;
				}
				else throw new IllegalInstructionException();
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 erfc_ps(v128 a, byte elements = 4)
			{
                if (Sse2.IsSse2Supported)
                {
					v128 ONE = Sse.set1_ps(1f);

					v128 abs = Sse.and_ps(a, Sse2.set1_epi32(0x7FFF_FFFF));

					v128 rcp = Sse.div_ps(ONE, a);
					v128 oneMinus = Sse.sub_ps(ONE, a);
					
					v128 signOneOrZero32 = Sse2.srli_epi32(a, 31);
					v128 nanInfResult = Sse2.slli_epi32(signOneOrZero32, 1);
					nanInfResult = Sse.add_ps(rcp, Sse2.cvtepi32_ps(nanInfResult));
					
					v128 allResultsFoundMask = Sse2.cmpgt_epi32(abs, Sse2.set1_epi32(0x7F7F_FFFF));
					v128 result = Sse.and_ps(allResultsFoundMask, nanInfResult);

					v128 bound0Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x3F58_0000), abs);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound0Mask);
					
					v128 sq = Sse.mul_ps(a, a);
					v128 p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_PP4), sq, Sse.set1_ps(F32_PP3)), sq, Sse.set1_ps(F32_PP2)), sq, Sse.set1_ps(F32_PP1)), sq, Sse.set1_ps(F32_PP0));
					v128 q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_QQ5), sq, Sse.set1_ps(F32_QQ4)), sq, Sse.set1_ps(F32_QQ3)), sq, Sse.set1_ps(F32_QQ2)), sq, Sse.set1_ps(F32_QQ1)), sq, ONE);
				    v128 y = Sse.div_ps(p, q);
					
					v128 bound1Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x2380_0000), abs);
					v128 result0and1 = fnmadd_ps(Sse.andnot_ps(bound1Mask, a), y, oneMinus);
					result = blendv_ps(result, result0and1, bound0Mask);


                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					v128 bound2Mask = Sse2.cmpgt_epi32(abs, Sse2.set1_epi32(0x403E_FFFF));
					bound2Mask = Sse2.andnot_si128(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound2Mask);
					v128 result2;
                    if (Sse4_1.IsSse41Supported)
                    {
						result2 = Sse4_1.blendv_ps(Sse.set1_ps(1e-120f * 1e-120f), Sse.set1_ps(2f - 1e-120f), a); 
                    }
					else
					{
						result2 = blendv_ps(Sse.set1_ps(1e-120f * 1e-120f), Sse.set1_ps(2f - 1e-120f), Sse2.srai_epi32(a, 31)); 
					}
					result = blendv_ps(result, result2, bound2Mask);

					v128 summands = Sse2.cvtepi32_ps(Sse2.slli_epi32(signOneOrZero32, 1));
					v128 bound3Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x3FA0_0000), abs);
					bound3Mask = Sse2.andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound3Mask);
					
					v128 s = Sse.sub_ps(abs, ONE);
					p = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_PA6), s, Sse.set1_ps(F32_PA5)), s, Sse.set1_ps(F32_PA4)), s, Sse.set1_ps(F32_PA3)), s, Sse.set1_ps(F32_PA2)), s, Sse.set1_ps(F32_PA1)), s, Sse.set1_ps(F32_PA0));
					q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_QA6), s, Sse.set1_ps(F32_QA5)), s, Sse.set1_ps(F32_QA4)), s, Sse.set1_ps(F32_QA3)), s, Sse.set1_ps(F32_QA2)), s, Sse.set1_ps(F32_QA1)), s, ONE);

					v128 sign = Sse2.slli_epi32(signOneOrZero32, 31);
					v128 result3 = Sse.xor_ps(sign, Sse.div_ps(p, q));
					v128 summands2 = Sse.add_ps(summands, Sse.xor_ps(sign, Sse.set1_ps(1f - F32_ERX)));
					result3 = Sse.sub_ps(summands2, result3);
					result = blendv_ps(result, result3, bound3Mask);
						
					
                    if (alltrue_f128<float>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }
					

					s = Sse.div_ps(ONE, sq);
					v128 bound4Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x4006_DB6D), abs);
					v128 hiAbs = Sse2.and_si128(abs, Sse2.set1_epi32(unchecked((int)0xFFFF_E000u)));
					v128 exp0 = fnmadd_ps(hiAbs, hiAbs, Sse.set1_ps(-0.5625f));
					v128 mulExp1 = Sse.mul_ps(Sse.sub_ps(hiAbs, abs), Sse.add_ps(hiAbs, abs));
					v128 result4;

                    if (elements > 2)
                    {
						if (Avx.IsAvxSupported)
						{
							v256 ss = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(s), s, 1);
							
							v128 qTrue = fmadd_ps(Sse.set1_ps(F32_SA8), s, Sse.set1_ps(F32_SA7));
							v256 __0True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RA7)), qTrue, 1);
							v256 __1True = new v256(F32_RA6, F32_RA6, F32_RA6, F32_RA6,   F32_SA6, F32_SA6, F32_SA6, F32_SA6);
							v256 __2True = new v256(F32_RA5, F32_RA5, F32_RA5, F32_RA5,   F32_SA5, F32_SA5, F32_SA5, F32_SA5);
							v256 __3True = new v256(F32_RA4, F32_RA4, F32_RA4, F32_RA4,   F32_SA4, F32_SA4, F32_SA4, F32_SA4);
							v256 __4True = new v256(F32_RA3, F32_RA3, F32_RA3, F32_RA3,   F32_SA3, F32_SA3, F32_SA3, F32_SA3);
							v256 __5True = new v256(F32_RA2, F32_RA2, F32_RA2, F32_RA2,   F32_SA2, F32_SA2, F32_SA2, F32_SA2);
							v256 __6True = new v256(F32_RA1, F32_RA1, F32_RA1, F32_RA1,   F32_SA1, F32_SA1, F32_SA1, F32_SA1);
							v256 __7True = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RA0)), ONE, 1);
							
							v128 qFalse = fmadd_ps(Sse.set1_ps(F32_SB7), s, Sse.set1_ps(F32_SB6));
							v256 __0False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RB6)), qFalse, 1);
							v256 __1False = new v256(F32_RB5, F32_RB5, F32_RB5, F32_RB5,   F32_SB5, F32_SB5, F32_SB5, F32_SB5);
							v256 __2False = new v256(F32_RB4, F32_RB4, F32_RB4, F32_RB4,   F32_SB4, F32_SB4, F32_SB4, F32_SB4);
							v256 __3False = new v256(F32_RB3, F32_RB3, F32_RB3, F32_RB3,   F32_SB3, F32_SB3, F32_SB3, F32_SB3);
							v256 __4False = new v256(F32_RB2, F32_RB2, F32_RB2, F32_RB2,   F32_SB2, F32_SB2, F32_SB2, F32_SB2);
							v256 __5False = new v256(F32_RB1, F32_RB1, F32_RB1, F32_RB1,   F32_SB1, F32_SB1, F32_SB1, F32_SB1);
							v256 __6False = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(Sse.set1_ps(F32_RB0)), ONE, 1);

							v256 pqTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True); 
							v256 pqFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False); 
							

							v256 mask = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(bound4Mask), bound4Mask, 1);
							v256 mulExp1_256 = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(mulExp1), mulExp1, 1);

							v256 pq = Avx.mm256_blendv_ps(pqFalse, pqTrue, mask);
							pq = mm256_fdadd_ps(Avx.mm256_permute2f128_ps(pq, pq, 0b0000_0001), pq, mulExp1_256);
							v256 exp = Avx.mm256_permute2f128_ps(Avx.mm256_castps128_ps256(exp0), pq, 0b0011_0000);
							exp = maxmath.exp(exp);
							result4 = Sse.mul_ps(Avx.mm256_castps256_ps128(exp), Avx.mm256_extractf128_ps(exp, 1));
						}
						else
						{
							v128 pTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_RA7), s, Sse.set1_ps(F32_RA6)), s, Sse.set1_ps(F32_RA5)), s, Sse.set1_ps(F32_RA4)), s, Sse.set1_ps(F32_RA3)), s, Sse.set1_ps(F32_RA2)), s, Sse.set1_ps(F32_RA1)), s, Sse.set1_ps(F32_RA0));
							v128 qTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_SA8), s, Sse.set1_ps(F32_SA7)), s, Sse.set1_ps(F32_SA6)), s, Sse.set1_ps(F32_SA5)), s, Sse.set1_ps(F32_SA4)), s, Sse.set1_ps(F32_SA3)), s, Sse.set1_ps(F32_SA2)), s, Sse.set1_ps(F32_SA1)), s, ONE);

							v128 pFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_RB6), s, Sse.set1_ps(F32_RB5)), s, Sse.set1_ps(F32_RB4)), s, Sse.set1_ps(F32_RB3)), s, Sse.set1_ps(F32_RB2)), s, Sse.set1_ps(F32_RB1)), s, Sse.set1_ps(F32_RB0));
							v128 qFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(Sse.set1_ps(F32_SB7), s, Sse.set1_ps(F32_SB6)), s, Sse.set1_ps(F32_SB5)), s, Sse.set1_ps(F32_SB4)), s, Sse.set1_ps(F32_SB3)), s, Sse.set1_ps(F32_SB2)), s, Sse.set1_ps(F32_SB1)), s, ONE);
							
							p = blendv_ps(pFalse, pTrue, bound4Mask);
							q = blendv_ps(qFalse, qTrue, bound4Mask);

							v128 exp1 = fdadd_ps(p, q, mulExp1);
							float4 r0 = math.exp(*(float4*)&exp0);
							float4 r1 = math.exp(*(float4*)&exp1);
							result4 = Sse.mul_ps(*(v128*)&r0, *(v128*)&r1);
						}
                    }
					else
					{
						v128 ss = Sse2.unpacklo_pd(s, s);
							
						v128 qTrue = fmadd_ps(Sse.set1_ps(F32_SA8), s, Sse.set1_ps(F32_SA7));
						v128 __0True = Sse2.unpacklo_pd(Sse.set1_ps(F32_RA7), qTrue);
						v128 __1True = new v128(F32_RA6, F32_RA6, F32_SA6, F32_SA6);
						v128 __2True = new v128(F32_RA5, F32_RA5, F32_SA5, F32_SA5);
						v128 __3True = new v128(F32_RA4, F32_RA4, F32_SA4, F32_SA4);
						v128 __4True = new v128(F32_RA3, F32_RA3, F32_SA3, F32_SA3);
						v128 __5True = new v128(F32_RA2, F32_RA2, F32_SA2, F32_SA2);
						v128 __6True = new v128(F32_RA1, F32_RA1, F32_SA1, F32_SA1);
						v128 __7True = Sse2.unpacklo_pd(Sse.set1_ps(F32_RA0), ONE);
						
						v128 qFalse = fmadd_ps(Sse.set1_ps(F32_SB7), s, Sse.set1_ps(F32_SB6));
						v128 __0False = Sse2.unpacklo_pd(Sse.set1_ps(F32_RB6), qFalse);
						v128 __1False = new v128(F32_RB5, F32_RB5, F32_SB5, F32_SB5);
						v128 __2False = new v128(F32_RB4, F32_RB4, F32_SB4, F32_SB4);
						v128 __3False = new v128(F32_RB3, F32_RB3, F32_SB3, F32_SB3);
						v128 __4False = new v128(F32_RB2, F32_RB2, F32_SB2, F32_SB2);
						v128 __5False = new v128(F32_RB1, F32_RB1, F32_SB1, F32_SB1);
						v128 __6False = Sse2.unpacklo_pd(Sse.set1_ps(F32_RB0), ONE);
						
						v128 pqTrue = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0True, ss, __1True), ss, __2True), ss, __3True), ss, __4True), ss, __5True), ss, __6True), ss, __7True); 
						v128 pqFalse = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(__0False, ss, __1False), ss, __2False), ss, __3False), ss, __4False), ss, __5False), ss, __6False); 
						
						
						v128 mask = Sse2.unpacklo_pd(bound4Mask, bound4Mask);
						v128 mulExp1_128 = Sse2.unpacklo_pd(mulExp1, mulExp1);
					
						v128 pq = blendv_ps(pqFalse, pqTrue, mask);
						pq = Sse.div_ps(pq, Sse2.bsrli_si128(pq, 2 * sizeof(float)));
						pq = Sse.add_ps(pq, mulExp1_128);
						v128 exp = Sse2.unpacklo_pd(exp0, pq); 
						float4 exp4 = math.exp(*(float4*)&exp);
						exp = *(v128*)&exp4;
						result4 = Sse.mul_ps(exp, Sse2.bsrli_si128(exp, 2 * sizeof(float)));
					}

					result4 = fmadd_ps(result4, rcp, summands);
					
					return blendv_ps(result4, result, allResultsFoundMask);
                }
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erfc_ps(v256 a)
			{
                if (Avx2.IsAvx2Supported)
                {
					v256 ONE = Avx.mm256_set1_ps(1f);

					v256 abs = Avx.mm256_and_ps(a, Avx.mm256_set1_epi32(0x7FFF_FFFF));

					v256 rcp = Avx.mm256_div_ps(ONE, a);
					v256 oneMinus = Avx.mm256_sub_ps(ONE, a);
					
					v256 signOneOrZero32 = Avx2.mm256_srli_epi32(a, 31);
					v256 nanInfResult = Avx2.mm256_slli_epi32(signOneOrZero32, 1);
					nanInfResult = Avx.mm256_add_ps(rcp, Avx.mm256_cvtepi32_ps(nanInfResult));
					
					v256 allResultsFoundMask = Avx2.mm256_cmpgt_epi32(abs, Avx.mm256_set1_epi32(0x7F7F_FFFF));
					v256 result = Avx.mm256_and_ps(allResultsFoundMask, nanInfResult);

					v256 bound0Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3F58_0000), abs);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound0Mask);
					
					v256 sq = Avx.mm256_mul_ps(a, a);
					v256 p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_PP4), sq, Avx.mm256_set1_ps(F32_PP3)), sq, Avx.mm256_set1_ps(F32_PP2)), sq, Avx.mm256_set1_ps(F32_PP1)), sq, Avx.mm256_set1_ps(F32_PP0));
					v256 q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_QQ5), sq, Avx.mm256_set1_ps(F32_QQ4)), sq, Avx.mm256_set1_ps(F32_QQ3)), sq, Avx.mm256_set1_ps(F32_QQ2)), sq, Avx.mm256_set1_ps(F32_QQ1)), sq, ONE);
				    v256 y = Avx.mm256_div_ps(p, q);
					
					v256 bound1Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x2380_0000), abs);
					v256 result0and1 = mm256_fnmadd_ps(Avx.mm256_andnot_ps(bound1Mask, a), y, oneMinus);
					result = Avx.mm256_blendv_ps(result, result0and1, bound0Mask);


                    if (mm256_alltrue_f256<float>(allResultsFoundMask, 8)) // 100% free; ILP
                    {
						return result;
                    }


					v256 bound2Mask = Avx2.mm256_cmpgt_epi32(abs, Avx.mm256_set1_epi32(0x403E_FFFF));
					bound2Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound2Mask);
					v256 result2 = Avx.mm256_blendv_ps(Avx.mm256_set1_ps(1e-120f * 1e-120f), Avx.mm256_set1_ps(2f - 1e-120f), a); 
					result = Avx.mm256_blendv_ps(result, result2, bound2Mask);

					v256 summands = Avx.mm256_cvtepi32_ps(Avx2.mm256_slli_epi32(signOneOrZero32, 1));
					v256 bound3Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3FA0_0000), abs);
					bound3Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound3Mask);
					
					v256 s = Avx.mm256_sub_ps(abs, ONE);
					p = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_PA6), s, Avx.mm256_set1_ps(F32_PA5)), s, Avx.mm256_set1_ps(F32_PA4)), s, Avx.mm256_set1_ps(F32_PA3)), s, Avx.mm256_set1_ps(F32_PA2)), s, Avx.mm256_set1_ps(F32_PA1)), s, Avx.mm256_set1_ps(F32_PA0));
					q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_QA6), s, Avx.mm256_set1_ps(F32_QA5)), s, Avx.mm256_set1_ps(F32_QA4)), s, Avx.mm256_set1_ps(F32_QA3)), s, Avx.mm256_set1_ps(F32_QA2)), s, Avx.mm256_set1_ps(F32_QA1)), s, ONE);

					v256 sign = Avx2.mm256_slli_epi32(signOneOrZero32, 31);
					v256 result3 = Avx.mm256_xor_ps(sign, Avx.mm256_div_ps(p, q));
					v256 summands2 = Avx.mm256_add_ps(summands, Avx.mm256_xor_ps(sign, Avx.mm256_set1_ps(1f - F32_ERX)));
					result3 = Avx.mm256_sub_ps(summands2, result3);
					result = Avx.mm256_blendv_ps(result, result3, bound3Mask);
						
					
                    if (mm256_alltrue_f256<float>(allResultsFoundMask, 8)) // 100% free; ILP
                    {
						return result;
                    }
					

					s = Avx.mm256_div_ps(ONE, sq);
					v256 bound4Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x4006_DB6D), abs);
					v256 hiAbs = Avx2.mm256_and_si256(abs, Avx.mm256_set1_epi32(unchecked((int)0xFFFF_E000u)));
					v256 exp0 = mm256_fnmadd_ps(hiAbs, hiAbs, Avx.mm256_set1_ps(-0.5625f));
					v256 mulExp1 = Avx.mm256_mul_ps(Avx.mm256_sub_ps(hiAbs, abs), Avx.mm256_add_ps(hiAbs, abs));
					v256 result4;
					
					v256 pTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_RA7), s, Avx.mm256_set1_ps(F32_RA6)), s, Avx.mm256_set1_ps(F32_RA5)), s, Avx.mm256_set1_ps(F32_RA4)), s, Avx.mm256_set1_ps(F32_RA3)), s, Avx.mm256_set1_ps(F32_RA2)), s, Avx.mm256_set1_ps(F32_RA1)), s, Avx.mm256_set1_ps(F32_RA0));
					v256 qTrue = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_SA8), s, Avx.mm256_set1_ps(F32_SA7)), s, Avx.mm256_set1_ps(F32_SA6)), s, Avx.mm256_set1_ps(F32_SA5)), s, Avx.mm256_set1_ps(F32_SA4)), s, Avx.mm256_set1_ps(F32_SA3)), s, Avx.mm256_set1_ps(F32_SA2)), s, Avx.mm256_set1_ps(F32_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_RB6), s, Avx.mm256_set1_ps(F32_RB5)), s, Avx.mm256_set1_ps(F32_RB4)), s, Avx.mm256_set1_ps(F32_RB3)), s, Avx.mm256_set1_ps(F32_RB2)), s, Avx.mm256_set1_ps(F32_RB1)), s, Avx.mm256_set1_ps(F32_RB0));
					v256 qFalse = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(Avx.mm256_set1_ps(F32_SB7), s, Avx.mm256_set1_ps(F32_SB6)), s, Avx.mm256_set1_ps(F32_SB5)), s, Avx.mm256_set1_ps(F32_SB4)), s, Avx.mm256_set1_ps(F32_SB3)), s, Avx.mm256_set1_ps(F32_SB2)), s, Avx.mm256_set1_ps(F32_SB1)), s, ONE);
					
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
			public static v128 erfc_pd(v128 a)
			{
				static v128 cmpHiGt(v128 a, v128 b)
				{
			        if (Sse4_1.IsSse41Supported)
			        {
						return Sse2.cmpgt_epi32(a, b);
			        }
					else if (Sse2.IsSse2Supported)
					{
						return Sse2.shuffle_epi32(Sse2.cmpgt_epi32(a, b), Sse.SHUFFLE(3, 3, 1, 1));
					}
					else throw new IllegalInstructionException();
				}


                if (Sse2.IsSse2Supported)
                {
					v128 ONE = Sse2.set1_pd(1d);

					v128 abs = Sse2.and_pd(a, Sse2.set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));

					v128 rcp = Sse2.div_pd(ONE, a);
					v128 oneMinus = Sse2.sub_pd(ONE, a);

					v128 signOneOrZero64 = Sse2.srli_epi64(a, 63);
					v128 nanInfResult = Sse2.slli_epi64(signOneOrZero64, 1);
					nanInfResult = Sse2.add_pd(rcp, usfcvtepi64_pd(nanInfResult));
					
					v128 allResultsFoundMask = cmpHiGt(abs, Sse2.set1_epi32(0x7FEF_FFFF));
					v128 result = Sse2.and_pd(allResultsFoundMask, nanInfResult);
					
					v128 bound0Mask = cmpHiGt(Sse2.set1_epi32(0x3FEB_0000), abs);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound0Mask);
					
					v128 sq = Sse2.mul_pd(a, a);
					v128 p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_PP4), sq, Sse2.set1_pd(F64_PP3)), sq, Sse2.set1_pd(F64_PP2)), sq, Sse2.set1_pd(F64_PP1)), sq, Sse2.set1_pd(F64_PP0));
					v128 q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_QQ5), sq, Sse2.set1_pd(F64_QQ4)), sq, Sse2.set1_pd(F64_QQ3)), sq, Sse2.set1_pd(F64_QQ2)), sq, Sse2.set1_pd(F64_QQ1)), sq, ONE);
				    v128 y = Sse2.div_pd(p, q);
					
					v128 bound1Mask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x3C70_0000), abs);
					bound1Mask = Sse2.shuffle_epi32(bound1Mask, Sse.SHUFFLE(3, 3, 1, 1));
					v128 result0and1 = fnmadd_pd(Sse2.andnot_pd(bound1Mask, a), y, oneMinus);
					result = blendv_pd(result, result0and1, bound0Mask);


                    if (Sse2.movemask_pd(allResultsFoundMask) == 0b0011) // 100% free; ILP
                    {
						return result;
                    }

					
					v128 bound2Mask = cmpHiGt(abs, Sse2.set1_epi32(0x403E_FFFF));
					bound2Mask = Sse2.andnot_si128(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound2Mask);
					v128 result2;
                    if (Sse4_1.IsSse41Supported)
                    {
						result2 = Sse4_1.blendv_pd(Sse2.set1_pd(1e-1022d * 1e-1022d), Sse2.set1_pd(2 - 1e-1022), a); 
                    }
					else
					{
						result2 = blendv_pd(Sse2.set1_pd(1e-1022d * 1e-1022d), Sse2.set1_pd(2 - 1e-1022), srai_epi64(a, 63)); 
					}
					result = blendv_pd(result, result2, bound2Mask);
					
					v128 summands = usfcvtepi64_pd(Sse2.slli_epi64(signOneOrZero64, 1));
					v128 bound3Mask = cmpHiGt(Sse2.set1_epi32(0x3FF4_0000), abs);
					bound3Mask = Sse2.andnot_si128(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Sse2.or_si128(allResultsFoundMask, bound3Mask);
					
					v128 s = Sse2.sub_pd(abs, ONE);
					p = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_PA6), s, Sse2.set1_pd(F64_PA5)), s, Sse2.set1_pd(F64_PA4)), s, Sse2.set1_pd(F64_PA3)), s, Sse2.set1_pd(F64_PA2)), s, Sse2.set1_pd(F64_PA1)), s, Sse2.set1_pd(F64_PA0));
					q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_QA6), s, Sse2.set1_pd(F64_QA5)), s, Sse2.set1_pd(F64_QA4)), s, Sse2.set1_pd(F64_QA3)), s, Sse2.set1_pd(F64_QA2)), s, Sse2.set1_pd(F64_QA1)), s, ONE);

					v128 sign = Sse2.slli_epi64(signOneOrZero64, 63);
					v128 result3 = Sse2.xor_pd(sign, Sse2.div_pd(p, q));
					v128 summands2 = Sse2.add_pd(summands, Sse2.xor_pd(sign, Sse2.set1_pd(1d - F64_ERX)));
					result3 = Sse2.sub_pd(summands2, result3);
					result = blendv_pd(result, result3, bound3Mask);
						

                    if (Sse2.movemask_pd(allResultsFoundMask) == 0b0011) // 100% free; ILP
                    {
						return result;
                    }


					s = Sse2.div_pd(ONE, sq);
					v128 bound4Mask = cmpHiGt(Sse2.set1_epi32(0x4006_DB6D), abs);
					v128 hiAbs = Sse2.and_si128(abs, Sse2.set1_epi64x(unchecked((long)0xFFFF_FFFF_0000_0000ul)));
					v128 exp0 = fnmadd_pd(hiAbs, hiAbs, Sse2.set1_pd(-0.5625d));
					v128 mulExp1 = Sse2.mul_pd(Sse2.sub_pd(hiAbs, abs), Sse2.add_pd(hiAbs, abs));
					v128 result4;

					if (Avx.IsAvxSupported)
					{
						v256 ss = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(s), s, 1);
						
						v128 qTrue = fmadd_pd(Sse2.set1_pd(F64_SA8), s, Sse2.set1_pd(F64_SA7));
						v256 __0True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RA7)), qTrue, 1);
						v256 __1True = new v256(F64_RA6, F64_RA6, F64_SA6, F64_SA6);
						v256 __2True = new v256(F64_RA5, F64_RA5, F64_SA5, F64_SA5);
						v256 __3True = new v256(F64_RA4, F64_RA4, F64_SA4, F64_SA4);
						v256 __4True = new v256(F64_RA3, F64_RA3, F64_SA3, F64_SA3);
						v256 __5True = new v256(F64_RA2, F64_RA2, F64_SA2, F64_SA2);
						v256 __6True = new v256(F64_RA1, F64_RA1, F64_SA1, F64_SA1);
						v256 __7True = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RA0)), ONE, 1);
						
						v128 qFalse = fmadd_pd(Sse2.set1_pd(F64_SB7), s, Sse2.set1_pd(F64_SB6));
						v256 __0False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RB6)), qFalse, 1);
						v256 __1False = new v256(F64_RB5, F64_RB5, F64_SB5, F64_SB5);
						v256 __2False = new v256(F64_RB4, F64_RB4, F64_SB4, F64_SB4);
						v256 __3False = new v256(F64_RB3, F64_RB3, F64_SB3, F64_SB3);
						v256 __4False = new v256(F64_RB2, F64_RB2, F64_SB2, F64_SB2);
						v256 __5False = new v256(F64_RB1, F64_RB1, F64_SB1, F64_SB1);
						v256 __6False = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(Sse2.set1_pd(F64_RB0)), ONE, 1);

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
						result4 = Sse2.mul_pd(Avx.mm256_castpd256_pd128(exp), Avx.mm256_extractf128_pd(exp, 1));
					}
					else
					{
						v128 pTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_RA7), s, Sse2.set1_pd(F64_RA6)), s, Sse2.set1_pd(F64_RA5)), s, Sse2.set1_pd(F64_RA4)), s, Sse2.set1_pd(F64_RA3)), s, Sse2.set1_pd(F64_RA2)), s, Sse2.set1_pd(F64_RA1)), s, Sse2.set1_pd(F64_RA0));
						v128 qTrue = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_SA8), s, Sse2.set1_pd(F64_SA7)), s, Sse2.set1_pd(F64_SA6)), s, Sse2.set1_pd(F64_SA5)), s, Sse2.set1_pd(F64_SA4)), s, Sse2.set1_pd(F64_SA3)), s, Sse2.set1_pd(F64_SA2)), s, Sse2.set1_pd(F64_SA1)), s, ONE);

						v128 pFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_RB6), s, Sse2.set1_pd(F64_RB5)), s, Sse2.set1_pd(F64_RB4)), s, Sse2.set1_pd(F64_RB3)), s, Sse2.set1_pd(F64_RB2)), s, Sse2.set1_pd(F64_RB1)), s, Sse2.set1_pd(F64_RB0));
						v128 qFalse = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_SB7), s, Sse2.set1_pd(F64_SB6)), s, Sse2.set1_pd(F64_SB5)), s, Sse2.set1_pd(F64_SB4)), s, Sse2.set1_pd(F64_SB3)), s, Sse2.set1_pd(F64_SB2)), s, Sse2.set1_pd(F64_SB1)), s, ONE);
						
						p = blendv_pd(pFalse, pTrue, bound4Mask);
						q = blendv_pd(qFalse, qTrue, bound4Mask);

						v128 exp1 = Sse2.add_pd(Sse2.div_pd(p, q), mulExp1);
						double2 r0 = math.exp(*(double2*)&exp0);
						double2 r1 = math.exp(*(double2*)&exp1);
						result4 = Sse2.mul_pd(*(v128*)&r0, *(v128*)&r1);
					}

					result4 = fmadd_pd(result4, rcp, summands);
					
					return blendv_pd(result4, result, allResultsFoundMask);
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_erfc_pd(v256 a, byte elements = 4)
			{
                if (Avx2.IsAvx2Supported)
                {
					v256 ONE = Avx.mm256_set1_pd(1d);

					v256 abs = Avx.mm256_and_pd(a, Avx.mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));

					v256 rcp = Avx.mm256_div_pd(ONE, a);
					v256 oneMinus = Avx.mm256_sub_pd(ONE, a);

					v256 signOneOrZero64 = Avx2.mm256_srli_epi64(a, 63);
					v256 nanInfResult = Avx2.mm256_slli_epi64(signOneOrZero64, 1);
					nanInfResult = Avx.mm256_add_pd(rcp, mm256_usfcvtepi64_pd(nanInfResult));
					
					v256 allResultsFoundMask = Avx2.mm256_cmpgt_epi32(abs, Avx.mm256_set1_epi32(0x7FEF_FFFF));
					v256 result = Avx.mm256_and_pd(allResultsFoundMask, nanInfResult);
					
					v256 bound0Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3FEB_0000), abs);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound0Mask);
					
					v256 sq = Avx.mm256_mul_pd(a, a);
					v256 p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_PP4), sq, Avx.mm256_set1_pd(F64_PP3)), sq, Avx.mm256_set1_pd(F64_PP2)), sq, Avx.mm256_set1_pd(F64_PP1)), sq, Avx.mm256_set1_pd(F64_PP0));
					v256 q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_QQ5), sq, Avx.mm256_set1_pd(F64_QQ4)), sq, Avx.mm256_set1_pd(F64_QQ3)), sq, Avx.mm256_set1_pd(F64_QQ2)), sq, Avx.mm256_set1_pd(F64_QQ1)), sq, ONE);
				    v256 y = Avx.mm256_div_pd(p, q);
					
					v256 bound1Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3C70_0000), abs);
					bound1Mask = Avx2.mm256_shuffle_epi32(bound1Mask, Sse.SHUFFLE(3, 3, 1, 1));
					v256 result0and1 = mm256_fnmadd_pd(Avx.mm256_andnot_pd(bound1Mask, a), y, oneMinus);
					result = Avx.mm256_blendv_pd(result, result0and1, bound0Mask);

					
                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }

					
					v256 bound2Mask = Avx2.mm256_cmpgt_epi32(abs, Avx.mm256_set1_epi32(0x403E_FFFF));
					bound2Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound2Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound2Mask);
					v256 result2 = Avx.mm256_blendv_pd(Avx.mm256_set1_pd(1e-1022d * 1e-1022d), Avx.mm256_set1_pd(2 - 1e-1022), mm256_srai_epi64(a, 63)); 
					result = Avx.mm256_blendv_pd(result, result2, bound2Mask);
					
					v256 summands = mm256_usfcvtepi64_pd(Avx2.mm256_slli_epi64(signOneOrZero64, 1));
					v256 bound3Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x3FF4_0000), abs);
					bound3Mask = Avx2.mm256_andnot_si256(allResultsFoundMask, bound3Mask);
					allResultsFoundMask = Avx2.mm256_or_si256(allResultsFoundMask, bound3Mask);
					
					v256 s = Avx.mm256_sub_pd(abs, ONE);
					p = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_PA6), s, Avx.mm256_set1_pd(F64_PA5)), s, Avx.mm256_set1_pd(F64_PA4)), s, Avx.mm256_set1_pd(F64_PA3)), s, Avx.mm256_set1_pd(F64_PA2)), s, Avx.mm256_set1_pd(F64_PA1)), s, Avx.mm256_set1_pd(F64_PA0));
					q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_QA6), s, Avx.mm256_set1_pd(F64_QA5)), s, Avx.mm256_set1_pd(F64_QA4)), s, Avx.mm256_set1_pd(F64_QA3)), s, Avx.mm256_set1_pd(F64_QA2)), s, Avx.mm256_set1_pd(F64_QA1)), s, ONE);

					v256 sign = Avx2.mm256_slli_epi64(signOneOrZero64, 63);
					v256 result3 = Avx.mm256_xor_pd(sign, Avx.mm256_div_pd(p, q));
					v256 summands2 = Avx.mm256_add_pd(summands, Avx.mm256_xor_pd(sign, Avx.mm256_set1_pd(1d - F64_ERX)));
					result3 = Avx.mm256_sub_pd(summands2, result3);
					result = Avx.mm256_blendv_pd(result, result3, bound3Mask);
						
					
                    if (mm256_alltrue_f256<double>(allResultsFoundMask, elements)) // 100% free; ILP
                    {
						return result;
                    }


					s = Avx.mm256_div_pd(ONE, sq);
					v256 bound4Mask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x4006_DB6D), abs);
					v256 hiAbs = Avx2.mm256_and_si256(abs, Avx.mm256_set1_epi64x(unchecked((long)0xFFFF_FFFF_0000_0000ul)));
					v256 exp0 = mm256_fnmadd_pd(hiAbs, hiAbs, Avx.mm256_set1_pd(-0.5625d));
					v256 mulExp1 = Avx.mm256_mul_pd(Avx.mm256_sub_pd(hiAbs, abs), Avx.mm256_add_pd(hiAbs, abs));
					v256 result4;

					v256 pTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_RA7), s, Avx.mm256_set1_pd(F64_RA6)), s, Avx.mm256_set1_pd(F64_RA5)), s, Avx.mm256_set1_pd(F64_RA4)), s, Avx.mm256_set1_pd(F64_RA3)), s, Avx.mm256_set1_pd(F64_RA2)), s, Avx.mm256_set1_pd(F64_RA1)), s, Avx.mm256_set1_pd(F64_RA0));
					v256 qTrue = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_SA8), s, Avx.mm256_set1_pd(F64_SA7)), s, Avx.mm256_set1_pd(F64_SA6)), s, Avx.mm256_set1_pd(F64_SA5)), s, Avx.mm256_set1_pd(F64_SA4)), s, Avx.mm256_set1_pd(F64_SA3)), s, Avx.mm256_set1_pd(F64_SA2)), s, Avx.mm256_set1_pd(F64_SA1)), s, ONE);

					v256 pFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_RB6), s, Avx.mm256_set1_pd(F64_RB5)), s, Avx.mm256_set1_pd(F64_RB4)), s, Avx.mm256_set1_pd(F64_RB3)), s, Avx.mm256_set1_pd(F64_RB2)), s, Avx.mm256_set1_pd(F64_RB1)), s, Avx.mm256_set1_pd(F64_RB0));
					v256 qFalse = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_SB7), s, Avx.mm256_set1_pd(F64_SB6)), s, Avx.mm256_set1_pd(F64_SB5)), s, Avx.mm256_set1_pd(F64_SB4)), s, Avx.mm256_set1_pd(F64_SB3)), s, Avx.mm256_set1_pd(F64_SB2)), s, Avx.mm256_set1_pd(F64_SB1)), s, ONE);
					
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
        /// <summary>       Returns the value of the error function for <paramref name="x"/>.       </summary>
        public static float erf(float x)
        {
			int asInt = math.asint(x);
			int absAsInt = asInt & 0x7FFF_FFFF;
			 

			if (Hint.Unlikely(absAsInt >= 0x7F80_0000))
			{
			    return math.rcp(x) + copysign(1, asInt);
			}
			else if (absAsInt < 0x3F58_0000) 
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
				int signX = andnot(asInt, 0x7FFF_FFFF);

				if (absAsInt > 0x40BF_FFFF) 
				{
					return math.asfloat(signX ^ math.asint(1f - F32_TINY));
				}
				if (absAsInt < 0x3FA0_0000) 
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
					float2 exp = math.exp(new float2(-z * z - 0.5625f, (z - abs) * (z + abs) + p / q));
					float result = cprod(exp);
					
					return -(result * rcp) + math.asfloat(math.asint(1f) ^ signX);
				}
			}
        }
		
        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 erf(float2 x) 
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<float2>(Xse.erf_ps(RegisterConversion.ToV128(x), 2));
            }
			else
			{
				return new float2(erf(x.x), erf(x.y));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 erf(float3 x) 
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<float3>(Xse.erf_ps(RegisterConversion.ToV128(x), 3));
            }
			else
			{
				return new float3(erf(x.x), erf(x.y), erf(x.z));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 erf(float4 x) 
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<float4>(Xse.erf_ps(RegisterConversion.ToV128(x), 4));
            }
			else
			{
				return new float4(erf(x.x), erf(x.y), erf(x.z), erf(x.w));
			}
		}

        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 erf(float8 x) 
		{
            if (Avx2.IsAvx2Supported)
            {
				return Xse.mm256_erf_ps(x);
            }
			else
			{
				return new float8(erf(x.v4_0), erf(x.v4_4));
			}
		}
		
		
		/// <summary>       Returns the value of the error function for <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double erf(double x) 
		{
			int hiInt = *((int*)&x + 1);
			int hiAbs = hiInt & 0x7FFF_FFFF;

			if (Hint.Unlikely(hiAbs >= 0x7FF0_0000))
			{
			    return math.rcp(x) + copysign(1, hiInt);
			}
			else if (hiAbs < 0x3FEB_0000) 
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
				const ulong SIGN = 1ul << 63;
				ulong signX = SIGN & math.asulong(x); 

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
					double2 exp = math.exp(new double2(-z * z - 0.5625, (z - abs) * (z + abs) + p / q));
					double result = cprod(exp);
					
					return -(result * rcp) + math.asdouble(math.asulong(1d) ^ signX);
				}
			}
		}
		
        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 erf(double2 x) 
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<double2>(Xse.erf_pd(RegisterConversion.ToV128(x)));
            }
			else
			{
				return new double2(erf(x.x), erf(x.y));
			}
		}
		
        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 erf(double3 x) 
		{
            if (Avx2.IsAvx2Supported)
            {
				return RegisterConversion.ToType<double3>(Xse.mm256_erf_pd(RegisterConversion.ToV256(x), 3));
            }
			else
			{
				return new double3(erf(x.xy), erf(x.z));
			}
		}
		
        /// <summary>       Returns the componentwise value of the error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 erf(double4 x) 
		{
            if (Avx2.IsAvx2Supported)
            {
				return RegisterConversion.ToType<double4>(Xse.mm256_erf_pd(RegisterConversion.ToV256(x), 4));
            }
			else
			{
				return new double4(erf(x.xy), erf(x.zw));
			}
		}


		/// <summary>       Returns the value of the complementary error function for <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float erfc(float x)
		{
			int asInt = math.asint(x);
			int absAsInt = asInt & 0x7FFF_FFFF;
		    int signX = (int)((uint)asInt >> 31);

		    if (Hint.Unlikely(absAsInt > 0x7F7F_FFFF))
			{
                return (signX << 1) + math.rcp(x);
            }
		    else if (absAsInt < 0x3F58_0000) 
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
				return tobool(signX) ? 2f - 1e-120f : 1e-120f * 1e-120f;
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
					float2 exp = math.exp(new float2(-z * z - 0.5625f, (z - math.asfloat(absAsInt)) * (z + math.asfloat(absAsInt)) + p / q));
					
					return math.mad(cprod(exp), rcp, summand);
				}
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 erfc(float2 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<float2>(Xse.erfc_ps(RegisterConversion.ToV128(x), 2));
            }
			else
			{
				return new float2(erfc(x.x), erfc(x.y));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 erfc(float3 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<float3>(Xse.erfc_ps(RegisterConversion.ToV128(x), 3));
            }
			else
			{
				return new float3(erfc(x.x), erfc(x.y), erfc(x.z));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 erfc(float4 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<float4>(Xse.erfc_ps(RegisterConversion.ToV128(x), 4));
            }
			else
			{
				return new float4(erfc(x.x), erfc(x.y), erfc(x.z), erfc(x.w));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 erfc(float8 x)
		{
            if (Avx2.IsAvx2Supported)
            {
				return Xse.mm256_erfc_ps(x);
            }
			else
			{
				return new float8(erfc(x.v4_0), erfc(x.v4_4));
			}
		}


		/// <summary>       Returns the value of the complementary error function for <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double erfc(double x)
		{
			int hiInt = *((int*)&x + 1);
			int hiAbs = hiInt & 0x7FFF_FFFF;
		    int signX = (int)((uint)hiInt >> 31);

		    if (Hint.Unlikely(hiAbs > 0x7FEF_FFFF))
			{
		        return (signX << 1) + 1d / x;
		    }
		    else if (hiAbs < 0x3FEB_0000) 
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
				return tobool(signX) ? 2 - 1e-1022d : 1e-1022d * 1e-1022d;
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
					double2 exp = math.exp(new double2(-z * z - 0.5625, (z - abs) * (z + abs) + p / q));

					return math.mad(cprod(exp), rcp, summand);
				}
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 erfc(double2 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToType<double2>(Xse.erfc_pd(RegisterConversion.ToV128(x)));
            }
			else
			{
				return new double2(erfc(x.x), erfc(x.y));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 erfc(double3 x)
		{
            if (Avx2.IsAvx2Supported)
            {
				return RegisterConversion.ToType<double3>(Xse.mm256_erfc_pd(RegisterConversion.ToV256(x), 3));
            }
			else
			{
				return new double3(erfc(x.xy), erfc(x.z));
			}
		}

		/// <summary>       Returns the componentwise value of the complementary error function for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 erfc(double4 x)
		{
            if (Avx2.IsAvx2Supported)
            {
				return RegisterConversion.ToType<double4>(Xse.mm256_erfc_pd(RegisterConversion.ToV256(x), 4));
            }
			else
			{
				return new double4(erfc(x.xy), erfc(x.zw));
			}
		}
	}
}