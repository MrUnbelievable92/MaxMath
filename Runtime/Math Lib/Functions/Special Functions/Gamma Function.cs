using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.GAMMA;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 gamma_ps(v128 a, byte elements = 4, bool promiseFinite = false, bool promiseGEzero = false)
			{
				if (Architecture.IsSIMDSupported)
                {
					v128 ZERO = setzero_si128();
					v128 ONE = set1_ps(1f);
					v128 HALF = set1_ps(0.5f);
					v128 PI = set1_ps(math.PI);
					v128 ABS_MASK = set1_epi32(0x7FFF_FFFF);

					v128 absX = and_ps(ABS_MASK, a);
					v128 rcp = div_ps(ONE, a);

					v128 fmaddMask = cmplt_ps(a, set1_ps(8f));
					v128 rcpfma = blendv_si128(and_si128(ABS_MASK, rcp), absX, fmaddMask);

					v128 num = fmadd_ps(blendv_ps(set1_ps((float)F64_SNUM0), set1_ps((float)F64_SNUM12), fmaddMask), rcpfma, blendv_ps(set1_ps((float)F64_SNUM1), set1_ps((float)F64_SNUM11), fmaddMask));
					v128 den = add_ps(and_ps(fmaddMask, rcpfma), blendv_ps(set1_ps((float)F64_SDEN1), set1_ps((float)F64_SDEN11), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM2),  set1_ps((float)F64_SNUM10), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN2),  set1_ps((float)F64_SDEN10), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM3),  set1_ps((float)F64_SNUM9),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN3),  set1_ps((float)F64_SDEN9),  fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM4),  set1_ps((float)F64_SNUM8),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN4),  set1_ps((float)F64_SDEN8),  fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM5),  set1_ps((float)F64_SNUM7),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN5),  set1_ps((float)F64_SDEN7),  fmaddMask));
					num = fmadd_ps(num, rcpfma, set1_ps((float)F64_SNUM6));
					den = fmadd_ps(den, rcpfma, set1_ps((float)F64_SDEN6));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM7),  set1_ps((float)F64_SNUM5),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN7),  set1_ps((float)F64_SDEN5),  fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM8),  set1_ps((float)F64_SNUM4),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN8),  set1_ps((float)F64_SDEN4),  fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM9),  set1_ps((float)F64_SNUM3),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN9),  set1_ps((float)F64_SDEN3),  fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM10), set1_ps((float)F64_SNUM2),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN10), set1_ps((float)F64_SDEN2),  fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM11), set1_ps((float)F64_SNUM1),  fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_si128(set1_ps((float)F64_SDEN11), set1_ps((float)F64_SDEN1),  fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_si128(set1_ps((float)F64_SNUM12), set1_ps((float)F64_SNUM0),  fmaddMask));
					den = fmadd_ps(den, rcpfma, andnot_ps(fmaddMask, ONE));

					v128 y = add_ps(absX, set1_ps((float)GM_HALF));
					v128 z = sub_ps(absX, HALF);
					v128 r = mul_ps(div_ps(num, den), RegisterConversion.ToV128(math.exp(-RegisterConversion.ToFloat4(y))));
					v128 xNegative = default(v128);

					if (!promiseGEzero)
					{
						xNegative = cmplt_ps(a, setzero_ps());

						if (notallfalse_f128<float>(xNegative, elements))
						{
						    v128 sinpi = mul_ps(absX, HALF);
							v128 floorsinpi = floor_ps(sinpi);
						    sinpi = sub_ps(sinpi, floorsinpi);
						    sinpi = add_ps(sinpi, sinpi);

						    v128 n = cvttps_epi32(mul_ps(sinpi, set1_ps(4f)));
						    n = srli_epi32(inc_epi32(n), 1);
							v128 q1 = cmpeq_epi32(n, set1_epi32(1));
							v128 q2 = cmpeq_epi32(n, set1_epi32(2));
							v128 q3 = cmpeq_epi32(n, set1_epi32(3));

							sinpi = fnmadd_ps(cvtepi32_ps(n), HALF, sinpi);
							sinpi = fmadd_ps(sinpi, PI, ternarylogic_si128(PI, q1, q3, TernaryOperation.OxEO));
							sinpi = ternarylogic_si128(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
							sinpi = RegisterConversion.ToV128(math.sin(RegisterConversion.ToFloat4(sinpi)));
							sinpi = ternarylogic_si128(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = div_ps(set1_ps(-math.PI), mul_ps(sinpi, mul_ps(absX, r)));
							z = ternarylogic_si128(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v128 result = mul_ps(r, RegisterConversion.ToV128(math.pow(RegisterConversion.ToFloat4(y), RegisterConversion.ToFloat4(z))));

					// the following is 100% free, ILP
					v128 result3 = rcp;
					v128 floorX = floor_ps(a);
					v128 floorHalfX = floor_ps(mul_ps(a, HALF));

					v128 mask0 = default(v128);
					if (!promiseFinite)
					{
						mask0 = cmpgt_epi32(absX, set1_epi32(0x7F80_0000 - 1));
						v128 result0 = add_ps(a, set1_ps(float.PositiveInfinity));

						result3 = blendv_si128(result3, result0, mask0);
					}

					v128 mask1 = and_ps(cmpeq_ps(a, floorX), cmple_ps(a, ZERO));
					v128 result1 = set1_ps(float.NaN);
					result3 = blendv_si128(result3, result1, mask1);

					v128 mask2 = cmpgt_epi32(absX, set1_epi32(0x420C_0000 - 1));
					v128 result2 = mul_ps(set1_ps(float.MaxValue), a);
					if (!promiseGEzero)
					{
						v128 result2_2 = andnot_ps(ABS_MASK, cmpneq_ps(floorX, floorHalfX));
						result2 = blendv_si128(result2, result2_2, xNegative);
					}
					result3 = blendv_si128(result3, result2, mask2);

					v128 mask3 = cmpgt_epi32(set1_epi32((0x7F - 54) << 23), absX);
					mask3 = ternarylogic_si128(mask1, mask2, mask3, TernaryOperation.OxFE);
					if (!promiseFinite)
					{
						mask3 = or_si128(mask0, mask3);
					}

					return blendv_si128(result, result3, mask3);
                }
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_gamma_ps(v256 a, bool promiseFinite = false, bool promiseGEzero = false)
			{
			    if (Avx.IsAvxSupported)
                {
					v256 ZERO = Avx.mm256_setzero_si256();
					v256 ONE = mm256_set1_ps(1f);
					v256 HALF = mm256_set1_ps(0.5f);
					v256 PI = mm256_set1_ps(math.PI);
					v256 ABS_MASK = mm256_set1_epi32(0x7FFF_FFFF);

					v256 absX = Avx.mm256_and_ps(ABS_MASK, a);
					v256 rcp = Avx.mm256_div_ps(ONE, a);

					v256 fmaddMask = mm256_cmplt_ps(a, mm256_set1_ps(8f));
					v256 rcpfma = Avx.mm256_blendv_ps(Avx.mm256_and_ps(ABS_MASK, rcp), absX, fmaddMask);

					v256 num = mm256_fmadd_ps(Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM0), mm256_set1_ps((float)F64_SNUM12), fmaddMask), rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM1), mm256_set1_ps((float)F64_SNUM11), fmaddMask));
					v256 den = Avx.mm256_add_ps(Avx.mm256_and_ps(fmaddMask, rcpfma), Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN1), mm256_set1_ps((float)F64_SDEN11), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM2),  mm256_set1_ps((float)F64_SNUM10), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN2),  mm256_set1_ps((float)F64_SDEN10), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM3),  mm256_set1_ps((float)F64_SNUM9),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN3),  mm256_set1_ps((float)F64_SDEN9),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM4),  mm256_set1_ps((float)F64_SNUM8),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN4),  mm256_set1_ps((float)F64_SDEN8),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM5),  mm256_set1_ps((float)F64_SNUM7),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN5),  mm256_set1_ps((float)F64_SDEN7),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, mm256_set1_ps((float)F64_SNUM6));
					den = mm256_fmadd_ps(den, rcpfma, mm256_set1_ps((float)F64_SDEN6));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM7),  mm256_set1_ps((float)F64_SNUM5),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN7),  mm256_set1_ps((float)F64_SDEN5),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM8),  mm256_set1_ps((float)F64_SNUM4),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN8),  mm256_set1_ps((float)F64_SDEN4),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM9),  mm256_set1_ps((float)F64_SNUM3),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN9),  mm256_set1_ps((float)F64_SDEN3),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM10), mm256_set1_ps((float)F64_SNUM2),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN10), mm256_set1_ps((float)F64_SDEN2),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM11), mm256_set1_ps((float)F64_SNUM1),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SDEN11), mm256_set1_ps((float)F64_SDEN1),  fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(mm256_set1_ps((float)F64_SNUM12), mm256_set1_ps((float)F64_SNUM0),  fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_andnot_ps(fmaddMask, ONE));

					v256 y = Avx.mm256_add_ps(absX, mm256_set1_ps((float)GM_HALF));
					v256 z = Avx.mm256_sub_ps(absX, HALF);
					v256 r = Avx.mm256_mul_ps(Avx.mm256_div_ps(num, den), maxmath.exp(mm256_neg_ps(y)));
					v256 xNegative = default(v256);

					if (!promiseGEzero)
					{
						xNegative = mm256_cmplt_ps(a, Avx.mm256_setzero_ps());

						if (mm256_notallfalse_f256<float>(xNegative))
						{
						    v256 sinpi = Avx.mm256_mul_ps(absX, HALF);
							v256 floorsinpi = Avx.mm256_floor_ps(sinpi);
						    sinpi = Avx.mm256_sub_ps(sinpi, floorsinpi);
						    sinpi = Avx.mm256_add_ps(sinpi, sinpi);

						    v256 n = Avx.mm256_cvttps_epi32(Avx.mm256_mul_ps(sinpi, Avx.mm256_set1_ps(4f)));
							v256 q1;
							v256 q2;
							v256 q3;
							if (Avx2.IsAvx2Supported)
							{
								n = Avx2.mm256_srli_epi32(mm256_inc_epi32(n), 1);
							    q1 = Avx2.mm256_cmpeq_epi32(n, mm256_set1_epi32(1));
							    q2 = Avx2.mm256_cmpeq_epi32(n, mm256_set1_epi32(2));
							    q3 = Avx2.mm256_cmpeq_epi32(n, mm256_set1_epi32(3));
							}
							else
							{
								v128 nLo = Avx.mm256_castsi256_si128(n);
								v128 nHi = Avx.mm256_extractf128_si256(n, 1);

								nLo = srli_epi32(inc_epi32(nLo), 1);
								nHi = srli_epi32(inc_epi32(nHi), 1);

								v128 q1Lo = cmpeq_epi32(nLo, set1_epi32(1));
								v128 q1Hi = cmpeq_epi32(nHi, set1_epi32(1));
								v128 q2Lo = cmpeq_epi32(nLo, set1_epi32(2));
								v128 q2Hi = cmpeq_epi32(nHi, set1_epi32(2));
								v128 q3Lo = cmpeq_epi32(nLo, set1_epi32(3));
								v128 q3Hi = cmpeq_epi32(nHi, set1_epi32(3));

							    q1 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(q1Lo), q1Hi, 1);
							    q2 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(q2Lo), q2Hi, 1);
							    q3 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(q3Lo), q3Hi, 1);
							}

							sinpi = mm256_fnmadd_ps(Avx.mm256_cvtepi32_ps(n), HALF, sinpi);
							sinpi = mm256_fmadd_ps(sinpi, PI, mm256_ternarylogic_si256(PI, q1, q3, TernaryOperation.OxEO));
							sinpi = mm256_ternarylogic_si256(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
							sinpi = maxmath.sin(sinpi);
							sinpi = mm256_ternarylogic_si256(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = Avx.mm256_div_ps(mm256_set1_ps(-math.PI), Avx.mm256_mul_ps(sinpi, Avx.mm256_mul_ps(absX, r)));
							z = mm256_ternarylogic_si256(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v256 result = Avx.mm256_mul_ps(r, maxmath.pow(y, z));

					// the following is 100% free, ILP
					v256 INFINITY = mm256_set1_ps(float.PositiveInfinity);

					v256 result3 = rcp;
					v256 floorX = Avx.mm256_floor_ps(a);
					v256 floorHalfX = Avx.mm256_floor_ps(Avx.mm256_mul_ps(a, HALF));

					v256 mask0 = default(v256);
					if (!promiseFinite)
					{
						v256 result0 = Avx.mm256_add_ps(a, INFINITY);

						if (Avx2.IsAvx2Supported)
						{
							mask0 = Avx2.mm256_cmpgt_epi32(absX, mm256_set1_epi32(0x7F80_0000 - 1));
						}
						else
						{
							mask0 = Avx.mm256_or_ps(mm256_cmpunord_ps(a, a), mm256_cmpeq_ps(absX, INFINITY));
						}

						result3 = Avx.mm256_blendv_ps(result3, result0, mask0);
					}

					v256 result1 = mm256_set1_ps(float.NaN);
					v256 mask1 = Avx.mm256_and_ps(mm256_cmpeq_ps(a, floorX), mm256_cmple_ps(a, ZERO));
					result3 = Avx.mm256_blendv_ps(result3, result1, mask1);

					v256 mask2;
					v256 mask3;
					v256 result2 = Avx.mm256_mul_ps(mm256_set1_ps(float.MaxValue), a);
					if (Avx2.IsAvx2Supported)
					{
						mask2 = Avx2.mm256_cmpgt_epi32(absX, mm256_set1_epi32(0x420C_0000 - 1));
						mask3 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32((0x7F - 54) << 23), absX);
					}
					else
					{
						mask2 = mm256_cmpge_ps(absX, mm256_set1_epi32(0x420C_0000));
						mask3 = mm256_cmpgt_ps(mm256_set1_epi32((0x7F - 54) << 23), absX);
					}

					if (!promiseGEzero)
					{
						v256 result2_2 = Avx.mm256_andnot_ps(ABS_MASK, mm256_cmpneq_ps(floorX, floorHalfX));
						result2 = Avx.mm256_blendv_ps(result2, result2_2, xNegative);
					}

					result3 = Avx.mm256_blendv_ps(result3, result2, mask2);
					mask3 = mm256_ternarylogic_si256(mask1, mask2, mask3, TernaryOperation.OxFE);
					if (!promiseFinite)
					{
						mask3 = Avx.mm256_or_ps(mask0, mask3);
					}

					return Avx.mm256_blendv_ps(result, result3, mask3);
                }
				else throw new IllegalInstructionException();
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 gamma_pd(v128 a, bool promiseFinite = false, bool promiseGEzero = false)
			{
                if (Architecture.IsSIMDSupported)
                {
					v128 ZERO = setzero_si128();
					v128 ONE = set1_pd(1d);
					v128 HALF = set1_pd(0.5d);
					v128 PI = set1_pd(math.PI_DBL);
					v128 ABS_MASK = set1_epi64x(0x7FFF_FFFF_FFFF_FFFFL);

					v128 absX = and_pd(ABS_MASK, a);
					v128 rcp = div_pd(ONE, a);

					v128 fmaddMask = cmplt_pd(a, set1_pd(8d));
					v128 rcpfma = blendv_si128(and_si128(ABS_MASK, rcp), absX, fmaddMask);

					v128 num = fmadd_pd(blendv_pd(set1_pd(F64_SNUM0), set1_pd(F64_SNUM12), fmaddMask), rcpfma, blendv_pd(set1_pd(F64_SNUM1), set1_pd(F64_SNUM11), fmaddMask));
					v128 den = add_pd(and_pd(fmaddMask, rcpfma), blendv_pd(set1_pd(F64_SDEN1), set1_pd(F64_SDEN11), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM2),  set1_pd(F64_SNUM10), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN2),  set1_pd(F64_SDEN10), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM3),  set1_pd(F64_SNUM9),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN3),  set1_pd(F64_SDEN9),  fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM4),  set1_pd(F64_SNUM8),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN4),  set1_pd(F64_SDEN8),  fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM5),  set1_pd(F64_SNUM7),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN5),  set1_pd(F64_SDEN7),  fmaddMask));
					num = fmadd_pd(num, rcpfma, set1_pd(F64_SNUM6));
					den = fmadd_pd(den, rcpfma, set1_pd(F64_SDEN6));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM7),  set1_pd(F64_SNUM5),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN7),  set1_pd(F64_SDEN5),  fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM8),  set1_pd(F64_SNUM4),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN8),  set1_pd(F64_SDEN4),  fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM9),  set1_pd(F64_SNUM3),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN9),  set1_pd(F64_SDEN3),  fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM10), set1_pd(F64_SNUM2),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN10), set1_pd(F64_SDEN2),  fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM11), set1_pd(F64_SNUM1),  fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_si128(set1_pd(F64_SDEN11), set1_pd(F64_SDEN1),  fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_si128(set1_pd(F64_SNUM12), set1_pd(F64_SNUM0),  fmaddMask));
					den = fmadd_pd(den, rcpfma, andnot_pd(fmaddMask, ONE));

					v128 y = add_pd(absX, set1_pd(GM_HALF));
					v128 z = sub_pd(absX, HALF);
					v128 r = mul_pd(div_pd(num, den), RegisterConversion.ToV128(math.exp(-RegisterConversion.ToDouble2(y))));
					v128 xNegative = default(v128);

					if (!promiseGEzero)
					{
						xNegative = cmplt_pd(a, setzero_ps());

						if (notallfalse_f128<double>(xNegative))
						{
						    v128 sinpi = mul_pd(absX, HALF);
							v128 floorsinpi = floor_pd(sinpi);
						    sinpi = sub_pd(sinpi, floorsinpi);
						    sinpi = add_pd(sinpi, sinpi);

						    v128 n = cvttpd_epu64(mul_pd(sinpi, set1_pd(4d)));
						    n = srli_epi64(inc_epi64(n), 1);
							v128 q1;
							v128 q2;
							v128 q3;
							if (Architecture.IsCMP64Supported)
							{
								q1 = cmpeq_epi64(n, set1_epi64x(1));
								q2 = cmpeq_epi64(n, set1_epi64x(2));
								q3 = cmpeq_epi64(n, set1_epi64x(3));
							}
							else
							{
								q1 = shuffle_epi32(cmpeq_epi32(n, set1_epi64x(1)), Sse.SHUFFLE(2, 2, 0, 0));
								q2 = shuffle_epi32(cmpeq_epi32(n, set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
								q3 = shuffle_epi32(cmpeq_epi32(n, set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
							}

							sinpi = fnmadd_pd(usfcvtepu64_pd(n), HALF, sinpi);
							sinpi = fmadd_pd(sinpi, PI, ternarylogic_si128(PI, q1, q3, TernaryOperation.OxEO));
							sinpi = ternarylogic_si128(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
							sinpi = RegisterConversion.ToV128(math.sin(RegisterConversion.ToDouble2(sinpi)));
							sinpi = ternarylogic_si128(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = div_pd(set1_pd(-math.PI_DBL), mul_pd(sinpi, mul_pd(absX, r)));
							z = ternarylogic_si128(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v128 result = mul_pd(r, RegisterConversion.ToV128(math.pow(RegisterConversion.ToDouble2(y), RegisterConversion.ToDouble2(z))));

					v128 result3 = rcp;
					v128 floorX = floor_pd(a);
					v128 floorHalfX = floor_pd(mul_pd(a, HALF));

					v128 mask0   = default(v128);
					if (!promiseFinite)
					{
						mask0 = cmpgt_epi32(absX, set1_epi64x(0x7FF0_0000_0000_0000 - 1));
						v128 result0 = add_pd(a, set1_pd(double.PositiveInfinity));

						if (Sse4_1.IsSse41Supported)
						{
							result3 = blendv_pd(result3, result0, mask0);
						}
						else
						{
							mask0 = shuffle_epi32(mask0, Sse.SHUFFLE(3, 3, 1, 1));
							result3 = blendv_si128(result3, result0, mask0);
						}
					}

					v128 mask1 = and_pd(cmpeq_pd(a, floorX), cmple_pd(a, ZERO));
					v128 result1 = set1_pd(double.NaN);
					if (Sse4_1.IsSse41Supported)
					{
						result3 = blendv_pd(result3, result1, mask1);
					}
					else
					{
						mask1 = shuffle_epi32(mask1, Sse.SHUFFLE(3, 3, 1, 1));
						result3 = blendv_si128(result3, result1, mask1);
					}

					v128 mask2 = cmpgt_epi32(absX, set1_epi64x(0x4067_0000_0000_0000 - 1));
					v128 result2 = mul_pd(set1_pd(double.MaxValue), a);
					if (!promiseGEzero)
					{
						v128 result2_2 = andnot_si128(ABS_MASK, cmpneq_pd(floorX, floorHalfX));
						result2 = blendv_si128(result2, result2_2, xNegative);
					}
					if (Sse4_1.IsSse41Supported)
					{
						result3 = blendv_pd(result3, result2, mask2);
					}
					else
					{
						mask2 = shuffle_epi32(mask2, Sse.SHUFFLE(3, 3, 1, 1));
						result3 = blendv_si128(result3, result2, mask2);
					}

					v128 mask3 = cmpgt_epi32(set1_epi64x((0x3FF - 54) << 52), absX);
					if (Sse4_1.IsSse41Supported)
					{
						;
					}
					else
					{
						mask3 = shuffle_epi32(mask3, Sse.SHUFFLE(3, 3, 1, 1));
					}
					mask3 = ternarylogic_si128(mask1, mask2, mask3, TernaryOperation.OxFE);
					if (!promiseFinite)
					{
						mask3 = or_si128(mask0, mask3);
					}
					
                    if (Sse4_1.IsSse41Supported)
                    {
						return blendv_pd(result, result3, mask3);
                    }
					else
					{
						return blendv_si128(result, result3, mask3);
					}
                }
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_gamma_pd(v256 a, byte elements = 4, bool promiseFinite = false, bool promiseGEzero = false)
			{
			    if (Avx.IsAvxSupported)
                {
					v256 ZERO = Avx.mm256_setzero_si256();
					v256 ONE = mm256_set1_pd(1d);
					v256 HALF = mm256_set1_pd(0.5d);
					v256 PI = mm256_set1_pd(math.PI_DBL);
					v256 ABS_MASK = mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFFL);

					v256 absX = Avx.mm256_and_pd(ABS_MASK, a);
					v256 rcp = Avx.mm256_div_pd(ONE, a);

					v256 fmaddMask = mm256_cmplt_pd(a, mm256_set1_pd(8d));
					v256 rcpfma = Avx.mm256_blendv_pd(Avx.mm256_and_pd(ABS_MASK, rcp), absX, fmaddMask);

					v256 num = mm256_fmadd_pd(Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM0), mm256_set1_pd(F64_SNUM12), fmaddMask), rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM1), mm256_set1_pd(F64_SNUM11), fmaddMask));
					v256 den = Avx.mm256_add_pd(Avx.mm256_and_pd(fmaddMask, rcpfma), Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN1), mm256_set1_pd(F64_SDEN11), fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM2),  mm256_set1_pd(F64_SNUM10), fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN2),  mm256_set1_pd(F64_SDEN10), fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM3),  mm256_set1_pd(F64_SNUM9),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN3),  mm256_set1_pd(F64_SDEN9),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM4),  mm256_set1_pd(F64_SNUM8),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN4),  mm256_set1_pd(F64_SDEN8),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM5),  mm256_set1_pd(F64_SNUM7),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN5),  mm256_set1_pd(F64_SDEN7),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, mm256_set1_pd(F64_SNUM6));
					den = mm256_fmadd_pd(den, rcpfma, mm256_set1_pd(F64_SDEN6));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM7),  mm256_set1_pd(F64_SNUM5),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN7),  mm256_set1_pd(F64_SDEN5),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM8),  mm256_set1_pd(F64_SNUM4),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN8),  mm256_set1_pd(F64_SDEN4),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM9),  mm256_set1_pd(F64_SNUM3),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN9),  mm256_set1_pd(F64_SDEN3),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM10), mm256_set1_pd(F64_SNUM2),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN10), mm256_set1_pd(F64_SDEN2),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM11), mm256_set1_pd(F64_SNUM1),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SDEN11), mm256_set1_pd(F64_SDEN1),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(mm256_set1_pd(F64_SNUM12), mm256_set1_pd(F64_SNUM0),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_andnot_pd(fmaddMask, ONE));

					v256 y = Avx.mm256_add_pd(absX, mm256_set1_pd(GM_HALF));
					v256 z = Avx.mm256_sub_pd(absX, HALF);
					v256 r = Avx.mm256_mul_pd(Avx.mm256_div_pd(num, den), RegisterConversion.ToV256(math.exp(-RegisterConversion.ToDouble4(y))));
					v256 xNegative = default(v256);

					if (!promiseGEzero)
					{
						xNegative = mm256_cmplt_pd(a, Avx.mm256_setzero_pd());

						if (mm256_notallfalse_f256<double>(xNegative, elements))
						{
						    v256 sinpi = Avx.mm256_mul_pd(absX, HALF);
							v256 floorsinpi = Avx.mm256_floor_pd(sinpi);
						    sinpi = Avx.mm256_sub_pd(sinpi, floorsinpi);
						    sinpi = Avx.mm256_add_pd(sinpi, sinpi);

							v256 q1;
							v256 q2;
							v256 q3;
							if (Avx2.IsAvx2Supported)
							{
								v256 n = mm256_cvttpd_epu64(Avx.mm256_mul_pd(sinpi, Avx.mm256_set1_pd(4d)), elements);
								n = Avx2.mm256_srli_epi64(mm256_inc_epi64(n), 1);
								q1 = Avx2.mm256_cmpeq_epi64(n, mm256_set1_epi64x(1));
								q2 = Avx2.mm256_cmpeq_epi64(n, mm256_set1_epi64x(2));
								q3 = Avx2.mm256_cmpeq_epi64(n, mm256_set1_epi64x(3));

								sinpi = mm256_fnmadd_pd(mm256_usfcvtepu64_pd(n), HALF, sinpi);
							}
							else
							{
								v128 n = Avx.mm256_cvttpd_epi32(Avx.mm256_mul_pd(sinpi, Avx.mm256_set1_pd(4d)));
								n = srli_epi32(add_epi32(n, set1_epi32(1 << 2)), 3);
								v128 q1_128 = cmpeq_epi32(n, set1_epi32(1));
								v128 q2_128 = cmpeq_epi32(n, set1_epi32(2));
								v128 q3_128 = cmpeq_epi32(n, set1_epi32(3));
								q1 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(shuffle_epi32(q1_128, Sse.SHUFFLE(1, 1, 0, 0))), shuffle_epi32(q1_128, Sse.SHUFFLE(3, 3, 2, 2)), 1);
								q2 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(shuffle_epi32(q2_128, Sse.SHUFFLE(1, 1, 0, 0))), shuffle_epi32(q2_128, Sse.SHUFFLE(3, 3, 2, 2)), 1);
								q3 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(shuffle_epi32(q3_128, Sse.SHUFFLE(1, 1, 0, 0))), shuffle_epi32(q3_128, Sse.SHUFFLE(3, 3, 2, 2)), 1);

								sinpi = mm256_fnmadd_pd(Avx.mm256_cvtepi32_pd(n), HALF, sinpi);
							}

							sinpi = mm256_fmadd_pd(sinpi, PI, mm256_ternarylogic_si256(PI, q1, q3, TernaryOperation.OxEO));
							sinpi = mm256_ternarylogic_si256(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
							sinpi = RegisterConversion.ToV256(math.sin(RegisterConversion.ToDouble4(sinpi)));
							sinpi = mm256_ternarylogic_si256(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = Avx.mm256_div_pd(mm256_set1_pd(-math.PI_DBL), Avx.mm256_mul_pd(sinpi, Avx.mm256_mul_pd(absX, r)));
							z = mm256_ternarylogic_si256(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v256 result = Avx.mm256_mul_pd(r, RegisterConversion.ToV256(math.pow(RegisterConversion.ToDouble4(y), RegisterConversion.ToDouble4(z))));

					v256 INFINITY = mm256_set1_pd(double.PositiveInfinity);

					v256 result3 = rcp;
					v256 floorX = Avx.mm256_floor_pd(a);
					v256 floorHalfX = Avx.mm256_floor_pd(Avx.mm256_mul_pd(a, HALF));

					v256 mask0   = default(v256);
					if (!promiseFinite)
					{
						v256 result0 = Avx.mm256_add_pd(a, INFINITY);

						if (Avx2.IsAvx2Supported)
						{
							mask0 = Avx2.mm256_cmpgt_epi32(absX, mm256_set1_epi64x(0x7FF0_0000_0000_0000 - 1));
						}
						else
						{
							mask0 = Avx.mm256_or_pd(mm256_cmpunord_pd(a, a), mm256_cmpeq_pd(absX, INFINITY));
						}

						result3 = Avx.mm256_blendv_pd(result3, result0, mask0);
					}

					v256 mask1 = Avx.mm256_and_pd(mm256_cmpeq_pd(a, floorX), mm256_cmple_pd(a, ZERO));
					v256 result1 = mm256_set1_pd(double.NaN);
					result3 = Avx.mm256_blendv_pd(result3, result1, mask1);

					v256 mask2;
					v256 mask3;
					if (Avx2.IsAvx2Supported)
					{
						mask2 = Avx2.mm256_cmpgt_epi32(absX, mm256_set1_epi64x(0x4067_0000_0000_0000 - 1));
						mask3 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi64x((0x3FF - 54) << 52), absX);
					}
					else
					{
						mask2 = mm256_cmpge_pd(absX, mm256_set1_epi64x(0x4067_0000_0000_0000));
						mask3 = mm256_cmpgt_pd(mm256_set1_epi64x((0x3FF - 54) << 52), absX);
					}
					v256 result2 = Avx.mm256_mul_pd(mm256_set1_pd(double.MaxValue), a);
					if (!promiseGEzero)
					{
						v256 result2_2 = Avx.mm256_andnot_pd(ABS_MASK, mm256_cmpneq_pd(floorX, floorHalfX));
						result2 = Avx.mm256_blendv_pd(result2, result2_2, xNegative);
					}
					result3 = Avx.mm256_blendv_pd(result3, result2, mask2);

					mask3 = mm256_ternarylogic_si256(mask1, mask2, mask3, TernaryOperation.OxFE);
					if (!promiseFinite)
					{
						mask3 = Avx.mm256_or_pd(mask0, mask3);
					}

					return Avx.mm256_blendv_pd(result, result3, mask3);
                }
				else throw new IllegalInstructionException();
			}
		}
	}


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the value of the gamma function Γ(x + 1) = x! for <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float gamma(float x, Promise promises = Promise.Nothing)
        {
			uint u = *(uint*)&x;
			uint ix = u & 0x7FFF_FFFFu;
			uint sign = andnot(u, 0x7FFF_FFFFu);

			float absX = math.abs(x);
			float rcp = math.rcp(absX);

			if (!promises.Promises(Promise.Unsafe0))
			{
				if (ix >= 0x7F80_0000)
				{
				    return x + float.PositiveInfinity;
				}
			}

			if (x == math.floor(x) && (sign != 0 | x == 0d))
			{
				return float.NaN;
			}
			if (ix >= 0x420C_0000)
			{
				if (sign != 0)
				{
					return negate(0f, math.floor(x) * 0.5f != math.floor(x * 0.5f));
				}

				return x * float.MaxValue;
			}
			if (ix < (uint)(0x7F - 54) << 23)
			{
			    return rcp;
			}

			float num;
			float den;
			float absrcp = math.abs(rcp);
			if (x < 8)
			{
			    num = math.mad((float)F64_SNUM12, absX, (float)F64_SNUM11);
			    den = absX + (float)F64_SDEN11;
			    num = math.mad(num, absX, (float)F64_SNUM10);
			    den = math.mad(den, absX, (float)F64_SDEN10);
			    num = math.mad(num, absX, (float)F64_SNUM9);
			    den = math.mad(den, absX, (float)F64_SDEN9);
			    num = math.mad(num, absX, (float)F64_SNUM8);
			    den = math.mad(den, absX, (float)F64_SDEN8);
			    num = math.mad(num, absX, (float)F64_SNUM7);
			    den = math.mad(den, absX, (float)F64_SDEN7);
			    num = math.mad(num, absX, (float)F64_SNUM6);
			    den = math.mad(den, absX, (float)F64_SDEN6);
			    num = math.mad(num, absX, (float)F64_SNUM5);
			    den = math.mad(den, absX, (float)F64_SDEN5);
			    num = math.mad(num, absX, (float)F64_SNUM4);
			    den = math.mad(den, absX, (float)F64_SDEN4);
			    num = math.mad(num, absX, (float)F64_SNUM3);
			    den = math.mad(den, absX, (float)F64_SDEN3);
			    num = math.mad(num, absX, (float)F64_SNUM2);
			    den = math.mad(den, absX, (float)F64_SDEN2);
			    num = math.mad(num, absX, (float)F64_SNUM1);
			    den = math.mad(den, absX, (float)F64_SDEN1);
			    num = math.mad(num, absX, (float)F64_SNUM0);
			    den = den * absX;
			}
			else
			{
			    num = math.mad((float)F64_SNUM0, absrcp, (float)F64_SNUM1);
			    den = (float)F64_SDEN1;
			    num = math.mad(num, absrcp, (float)F64_SNUM2);
			    den = math.mad(den, absrcp, (float)F64_SDEN2);
			    num = math.mad(num, absrcp, (float)F64_SNUM3);
			    den = math.mad(den, absrcp, (float)F64_SDEN3);
			    num = math.mad(num, absrcp, (float)F64_SNUM4);
			    den = math.mad(den, absrcp, (float)F64_SDEN4);
			    num = math.mad(num, absrcp, (float)F64_SNUM5);
			    den = math.mad(den, absrcp, (float)F64_SDEN5);
			    num = math.mad(num, absrcp, (float)F64_SNUM6);
			    den = math.mad(den, absrcp, (float)F64_SDEN6);
			    num = math.mad(num, absrcp, (float)F64_SNUM7);
			    den = math.mad(den, absrcp, (float)F64_SDEN7);
			    num = math.mad(num, absrcp, (float)F64_SNUM8);
			    den = math.mad(den, absrcp, (float)F64_SDEN8);
			    num = math.mad(num, absrcp, (float)F64_SNUM9);
			    den = math.mad(den, absrcp, (float)F64_SDEN9);
			    num = math.mad(num, absrcp, (float)F64_SNUM10);
			    den = math.mad(den, absrcp, (float)F64_SDEN10);
			    num = math.mad(num, absrcp, (float)F64_SNUM11);
			    den = math.mad(den, absrcp, (float)F64_SDEN11);
			    num = math.mad(num, absrcp, (float)F64_SNUM12);
			    den = math.mad(den, absrcp, 1f);
			}

			float y = absX + (float)GM_HALF;
			float z = absX - 0.5f;
			float r = (num / den) * math.exp(-y);

			if (!promises.Promises(Promise.ZeroOrGreater))
			{
				if (x < 0)
				{
				    float sinpi = absX * 0.5f;
				    sinpi -= math.floor(sinpi);
					sinpi += sinpi;

				    int n = ((int)(sinpi * 4) + 1) >> 1;
				    sinpi -= n * 0.5f;
				    sinpi *= math.PI;

					sinpi = negate(math.sin(negate(sinpi + ((n == 1 | n == 3) ? math.PI : 0f), n == 2)), n == 3);

				    r = -math.PI / (sinpi * (absX * r));
				    z = -z;
				}
			}

			return r * pow(y, z);
        }

        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 gamma(float2 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat2(Xse.gamma_ps(RegisterConversion.ToV128(x), 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
			else
			{
				return new float2(gamma(x.x, promises), gamma(x.y, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 gamma(float3 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat3(Xse.gamma_ps(RegisterConversion.ToV128(x), 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
			else
			{
				return new float3(gamma(x.x, promises), gamma(x.y, promises), gamma(x.z, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 gamma(float4 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToFloat4(Xse.gamma_ps(RegisterConversion.ToV128(x), 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
			else
			{
				return new float4(gamma(x.x, promises), gamma(x.y, promises), gamma(x.z, promises), gamma(x.w, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 gamma(float8 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return Xse.mm256_gamma_ps(x, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
			else
			{
				return new float8(gamma(x.v4_0, promises), gamma(x.v4_4, promises));
			}
		}


		/// <summary>       Returns the value of the gamma function Γ(x + 1) = x! for <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double gamma(double x, Promise promises = Promise.Nothing)
		{
			ulong u = *(ulong*)&x;
			ulong ix = u & 0x7FFF_FFFF_FFFF_FFFFul;
			ulong sign = andnot(u, 0x7FFF_FFFF_FFFF_FFFFul);

			double absX = math.abs(x);
			double rcp = math.rcp(absX);

			if (!promises.Promises(Promise.Unsafe0))
			{
				if (ix >= 0x7FF0_0000_0000_0000)
				{
				    return x + double.PositiveInfinity;
				}
			}

			if (x == math.floor(x) && (sign != 0 | x == 0d))
			{
				return double.NaN;
			}
			if (ix >= 0x4067_0000_0000_0000)
			{
				if (sign != 0)
				{
					return negate(0d, math.floor(x) * 0.5d != math.floor(x * 0.5d));
				}

				return x * double.MaxValue;
			}
			if (ix < (ulong)(0x3FF - 54) << 52)
			{
			    return rcp;
			}

			double num;
			double den;
			double absrcp = math.abs(rcp);
			if (x < 8)
			{
			    num = math.mad(F64_SNUM12, absX, F64_SNUM11);
			    den = absX + F64_SDEN11;
			    num = math.mad(num, absX, F64_SNUM10);
			    den = math.mad(den, absX, F64_SDEN10);
			    num = math.mad(num, absX, F64_SNUM9);
			    den = math.mad(den, absX, F64_SDEN9);
			    num = math.mad(num, absX, F64_SNUM8);
			    den = math.mad(den, absX, F64_SDEN8);
			    num = math.mad(num, absX, F64_SNUM7);
			    den = math.mad(den, absX, F64_SDEN7);
			    num = math.mad(num, absX, F64_SNUM6);
			    den = math.mad(den, absX, F64_SDEN6);
			    num = math.mad(num, absX, F64_SNUM5);
			    den = math.mad(den, absX, F64_SDEN5);
			    num = math.mad(num, absX, F64_SNUM4);
			    den = math.mad(den, absX, F64_SDEN4);
			    num = math.mad(num, absX, F64_SNUM3);
			    den = math.mad(den, absX, F64_SDEN3);
			    num = math.mad(num, absX, F64_SNUM2);
			    den = math.mad(den, absX, F64_SDEN2);
			    num = math.mad(num, absX, F64_SNUM1);
			    den = math.mad(den, absX, F64_SDEN1);
			    num = math.mad(num, absX, F64_SNUM0);
			    den = den * absX;
			}
			else
			{
			    num = math.mad(F64_SNUM0, absrcp, F64_SNUM1);
			    den = F64_SDEN1;
			    num = math.mad(num, absrcp, F64_SNUM2);
			    den = math.mad(den, absrcp, F64_SDEN2);
			    num = math.mad(num, absrcp, F64_SNUM3);
			    den = math.mad(den, absrcp, F64_SDEN3);
			    num = math.mad(num, absrcp, F64_SNUM4);
			    den = math.mad(den, absrcp, F64_SDEN4);
			    num = math.mad(num, absrcp, F64_SNUM5);
			    den = math.mad(den, absrcp, F64_SDEN5);
			    num = math.mad(num, absrcp, F64_SNUM6);
			    den = math.mad(den, absrcp, F64_SDEN6);
			    num = math.mad(num, absrcp, F64_SNUM7);
			    den = math.mad(den, absrcp, F64_SDEN7);
			    num = math.mad(num, absrcp, F64_SNUM8);
			    den = math.mad(den, absrcp, F64_SDEN8);
			    num = math.mad(num, absrcp, F64_SNUM9);
			    den = math.mad(den, absrcp, F64_SDEN9);
			    num = math.mad(num, absrcp, F64_SNUM10);
			    den = math.mad(den, absrcp, F64_SDEN10);
			    num = math.mad(num, absrcp, F64_SNUM11);
			    den = math.mad(den, absrcp, F64_SDEN11);
			    num = math.mad(num, absrcp, F64_SNUM12);
			    den = math.mad(den, absrcp, 1d);
			}

			double y = absX + GM_HALF;
			double z = absX - 0.5d;
			double r = (num / den) * math.exp(-y);

			if (!promises.Promises(Promise.ZeroOrGreater))
			{
				if (x < 0)
				{
				    double sinpi = absX * 0.5d;
				    sinpi -= math.floor(sinpi);
					sinpi += sinpi;

				    int n = ((int)(sinpi * 4) + 1) >> 1;
				    sinpi -= n * 0.5d;
				    sinpi *= math.PI_DBL;

					sinpi = negate(math.sin(negate(sinpi + ((n == 1 | n == 3) ? math.PI_DBL : 0d), n == 2)), n == 3);

				    r = -math.PI_DBL / (sinpi * (absX * r));
				    z = -z;
				}
			}

			return r * pow(y, z);
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 gamma(double2 x, Promise promises = Promise.Nothing)
		{
            if (Architecture.IsSIMDSupported)
            {
				return RegisterConversion.ToDouble2(Xse.gamma_pd(RegisterConversion.ToV128(x), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
			else
			{
				return new double2(gamma(x.x, promises), gamma(x.y, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 gamma(double3 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return RegisterConversion.ToDouble3(Xse.mm256_gamma_pd(RegisterConversion.ToV256(x), 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
			else
			{
				return new double3(gamma(x.xy, promises), gamma(x.z, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.                                       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 gamma(double4 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return RegisterConversion.ToDouble4(Xse.mm256_gamma_pd(RegisterConversion.ToV256(x), 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
			else
			{
				return new double4(gamma(x.xy, promises), gamma(x.zw, promises));
			}
		}
	}
}
