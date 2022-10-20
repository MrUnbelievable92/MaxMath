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
			public static v128 gamma_ps(v128 a, byte elements = 4)
			{
				if (Sse2.IsSse2Supported)
                {
					v128 ZERO = Sse2.setzero_si128();
					v128 ONE = Sse.set1_ps(1f);
					v128 HALF = Sse.set1_ps(0.5f);
					v128 PI = Sse.set1_ps(math.PI);
					v128 ABS_MASK = Sse2.set1_epi32(0x7FFF_FFFF);

					v128 absX = Sse.and_ps(ABS_MASK, a);
					v128 rcp = Sse.div_ps(ONE, a);
					
					v128 fmaddMask = Sse.cmplt_ps(a, Sse.set1_ps(8f));
					v128 rcpfma = blendv_ps(Sse2.and_si128(ABS_MASK, rcp), absX, fmaddMask);
					
					v128 num = fmadd_ps(blendv_ps(Sse.set1_ps((float)F64_SNUM0), Sse.set1_ps((float)F64_SNUM12), fmaddMask), rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM1), Sse.set1_ps((float)F64_SNUM11), fmaddMask));
					v128 den = Sse.add_ps(Sse.and_ps(fmaddMask, rcpfma), blendv_ps(Sse.set1_ps((float)F64_SDEN1), Sse.set1_ps((float)F64_SDEN11), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM2),  Sse.set1_ps((float)F64_SNUM10), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN2),  Sse.set1_ps((float)F64_SDEN10), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM3),  Sse.set1_ps((float)F64_SNUM9), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN3),  Sse.set1_ps((float)F64_SDEN9), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM4),  Sse.set1_ps((float)F64_SNUM8), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN4),  Sse.set1_ps((float)F64_SDEN8), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM5),  Sse.set1_ps((float)F64_SNUM7), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN5),  Sse.set1_ps((float)F64_SDEN7), fmaddMask));
					num = fmadd_ps(num, rcpfma, Sse.set1_ps((float)F64_SNUM6));
					den = fmadd_ps(den, rcpfma, Sse.set1_ps((float)F64_SDEN6));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM7),  Sse.set1_ps((float)F64_SNUM5), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN7),  Sse.set1_ps((float)F64_SDEN5), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM8),  Sse.set1_ps((float)F64_SNUM4), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN8),  Sse.set1_ps((float)F64_SDEN4), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM9),  Sse.set1_ps((float)F64_SNUM3), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN9),  Sse.set1_ps((float)F64_SDEN3), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM10), Sse.set1_ps((float)F64_SNUM2), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN10), Sse.set1_ps((float)F64_SDEN2), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM11), Sse.set1_ps((float)F64_SNUM1), fmaddMask));
					den = fmadd_ps(den, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SDEN11), Sse.set1_ps((float)F64_SDEN1), fmaddMask));
					num = fmadd_ps(num, rcpfma, blendv_ps(Sse.set1_ps((float)F64_SNUM12), Sse.set1_ps((float)F64_SNUM0), fmaddMask));
					den = fmadd_ps(den, rcpfma, Sse.andnot_ps(fmaddMask, ONE));

					v128 y = Sse.add_ps(absX, Sse.set1_ps((float)GM_HALF));
					v128 z = Sse.sub_ps(absX, HALF);
					v128 r = Sse.mul_ps(Sse.div_ps(num, den), RegisterConversion.ToV128(math.exp(-RegisterConversion.ToFloat4(y))));
					
					bool reflect;
                    if		(elements == 2) reflect = (Sse.movemask_ps(a) & 0b0011) != 0;
                    else if (elements == 3) reflect = (Sse.movemask_ps(a) & 0b0111) != 0;
                    else					reflect = Sse.movemask_ps(a) != 0;

					if (reflect) 
					{
					    v128 sinpi = Sse.mul_ps(absX, HALF);
						v128 floorsinpi;
						if (Sse4_1.IsSse41Supported)
						{
							floorsinpi = Sse4_1.floor_ps(sinpi);
						}
						else
						{
							floorsinpi = RegisterConversion.ToV128(math.floor(RegisterConversion.ToFloat4(sinpi)));
						}
					    sinpi = Sse.sub_ps(sinpi, floorsinpi);
					    sinpi = Sse.add_ps(sinpi, sinpi);
					
					    v128 n = Sse2.cvttps_epi32(sinpi);
					    n = Sse2.srli_epi32(Sse2.add_epi32(n, Sse2.set1_epi32(1 << 2)), 3);
						v128 q1 = Sse2.cmpeq_epi32(n, Sse2.set1_epi32(1));
						v128 q2 = Sse2.cmpeq_epi32(n, Sse2.set1_epi32(2));
						v128 q3 = Sse2.cmpeq_epi32(n, Sse2.set1_epi32(3)); 

						sinpi = fnmadd_ps(Sse2.cvtepi32_ps(n), HALF, sinpi);
						sinpi = fmadd_ps(sinpi, PI, ternarylogic_si128(PI, q1, q3, TernaryOperation.OxEO));
						sinpi = ternarylogic_si128(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
						sinpi = RegisterConversion.ToV128(math.sin(RegisterConversion.ToFloat4(sinpi)));
						sinpi = ternarylogic_si128(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

						r = Sse.div_ps(Sse.set1_ps(-math.PI), Sse.mul_ps(sinpi, Sse.mul_ps(absX, r)));
						z = ternarylogic_si128(ABS_MASK, a, z, TernaryOperation.OxA6);
					}

					v128 result = Sse.mul_ps(r, RegisterConversion.ToV128(math.pow(RegisterConversion.ToFloat4(y), RegisterConversion.ToFloat4(z))));
					
					// the following is 100% free, ILP
					v128 negative;
					v128 floorX;
					v128 floorHalfX;
                    if (Sse4_1.IsSse41Supported)
                    {
						floorX = Sse4_1.floor_ps(a);
						floorHalfX = Sse4_1.floor_ps(Sse.mul_ps(a, HALF));
						negative = Sse.andnot_ps(ABS_MASK, a);
                    }
					else
					{
						floorX = RegisterConversion.ToV128(math.floor(RegisterConversion.ToFloat4(a)));
						floorHalfX = RegisterConversion.ToV128(math.floor(RegisterConversion.ToFloat4(HALF) * RegisterConversion.ToFloat4(a)));
						negative = Sse2.srai_epi32(a, 31);
					}
					

					v128 mask0 = Sse2.cmpgt_epi32(absX, Sse2.set1_epi32(0x7F80_0000));
					v128 result0 = Sse.add_ps(a, Sse.set1_ps(float.PositiveInfinity));

					v128 mask1 = ternarylogic_si128(Sse.cmpeq_ps(a, floorX), Sse.cmpeq_ps(a, ZERO), negative, TernaryOperation.OxEO);
					v128 result1 = Sse.set1_ps(float.NaN);
					
					v128 mask2 = Sse2.cmpgt_epi32(absX, Sse2.set1_epi32(0x420C_0000));
					v128 result2_1 = Sse.mul_ps(Sse.set1_ps(float.MaxValue), a);
					v128 result2_2 = Sse.andnot_ps(ABS_MASK, Sse.cmpneq_ps(floorX, floorHalfX));
					v128 result2 = blendv_ps(result2_1, result2_2, negative);
					
					v128 mask3 = Sse2.cmpgt_epi32(Sse2.set1_epi32((0x7F - 54) << 23), absX);
					v128 result3 = rcp;

					result3 = blendv_ps(result3, result2, mask2);
					result3 = blendv_ps(result3, result1, mask1);
					result3 = blendv_ps(result3, result0, mask0);
					mask3 = Sse2.or_si128(mask3, ternarylogic_si128(mask0, mask1, mask2, TernaryOperation.OxFE));

					return blendv_ps(result, result3, mask3);
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_gamma_ps(v256 a)
			{
			    if (Avx2.IsAvx2Supported)
                {
					v256 ZERO = Avx.mm256_setzero_si256();
					v256 ONE = Avx.mm256_set1_ps(1f);
					v256 HALF = Avx.mm256_set1_ps(0.5f);
					v256 PI = Avx.mm256_set1_ps(math.PI);
					v256 ABS_MASK = Avx.mm256_set1_epi32(0x7FFF_FFFF);

					v256 absX = Avx.mm256_and_ps(ABS_MASK, a);
					v256 rcp = Avx.mm256_div_ps(ONE, a);
					
					v256 fmaddMask = Avx.mm256_cmp_ps(a, Avx.mm256_set1_ps(8f), (int)Avx.CMP.LT_OQ);
					v256 rcpfma = Avx.mm256_blendv_ps(Avx2.mm256_and_si256(ABS_MASK, rcp), absX, fmaddMask);
					
					v256 num = mm256_fmadd_ps(Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM0), Avx.mm256_set1_ps((float)F64_SNUM12), fmaddMask), rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM1), Avx.mm256_set1_ps((float)F64_SNUM11), fmaddMask));
					v256 den = Avx.mm256_add_ps(Avx.mm256_and_ps(fmaddMask, rcpfma), Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN1), Avx.mm256_set1_ps((float)F64_SDEN11), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM2),  Avx.mm256_set1_ps((float)F64_SNUM10), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN2),  Avx.mm256_set1_ps((float)F64_SDEN10), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM3),  Avx.mm256_set1_ps((float)F64_SNUM9), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN3),  Avx.mm256_set1_ps((float)F64_SDEN9), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM4),  Avx.mm256_set1_ps((float)F64_SNUM8), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN4),  Avx.mm256_set1_ps((float)F64_SDEN8), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM5),  Avx.mm256_set1_ps((float)F64_SNUM7), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN5),  Avx.mm256_set1_ps((float)F64_SDEN7), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_set1_ps((float)F64_SNUM6));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_set1_ps((float)F64_SDEN6));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM7),  Avx.mm256_set1_ps((float)F64_SNUM5), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN7),  Avx.mm256_set1_ps((float)F64_SDEN5), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM8),  Avx.mm256_set1_ps((float)F64_SNUM4), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN8),  Avx.mm256_set1_ps((float)F64_SDEN4), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM9),  Avx.mm256_set1_ps((float)F64_SNUM3), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN9),  Avx.mm256_set1_ps((float)F64_SDEN3), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM10), Avx.mm256_set1_ps((float)F64_SNUM2), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN10), Avx.mm256_set1_ps((float)F64_SDEN2), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM11), Avx.mm256_set1_ps((float)F64_SNUM1), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SDEN11), Avx.mm256_set1_ps((float)F64_SDEN1), fmaddMask));
					num = mm256_fmadd_ps(num, rcpfma, Avx.mm256_blendv_ps(Avx.mm256_set1_ps((float)F64_SNUM12), Avx.mm256_set1_ps((float)F64_SNUM0), fmaddMask));
					den = mm256_fmadd_ps(den, rcpfma, Avx.mm256_andnot_ps(fmaddMask, ONE));

					v256 y = Avx.mm256_add_ps(absX, Avx.mm256_set1_ps((float)GM_HALF));
					v256 z = Avx.mm256_sub_ps(absX, HALF);
					v256 r = Avx.mm256_mul_ps(Avx.mm256_div_ps(num, den), maxmath.exp(mm256_neg_ps(y)));
					
					if (Avx.mm256_movemask_ps(a) != 0) 
					{
					    v256 sinpi = Avx.mm256_mul_ps(absX, HALF);
						v256 floorsinpi = Avx.mm256_floor_ps(sinpi);
					    sinpi = Avx.mm256_sub_ps(sinpi, floorsinpi);
					    sinpi = Avx.mm256_add_ps(sinpi, sinpi);
					
					    v256 n = Avx.mm256_cvttps_epi32(sinpi);
					    n = Avx2.mm256_srli_epi32(Avx2.mm256_add_epi32(n, Avx.mm256_set1_epi32(1 << 2)), 3);
						v256 q1 = Avx2.mm256_cmpeq_epi32(n, Avx.mm256_set1_epi32(1));
						v256 q2 = Avx2.mm256_cmpeq_epi32(n, Avx.mm256_set1_epi32(2));
						v256 q3 = Avx2.mm256_cmpeq_epi32(n, Avx.mm256_set1_epi32(3)); 

						sinpi = mm256_fnmadd_ps(Avx.mm256_cvtepi32_ps(n), HALF, sinpi);
						sinpi = mm256_fmadd_ps(sinpi, PI, mm256_ternarylogic_si256(PI, q1, q3, TernaryOperation.OxEO));
						sinpi = mm256_ternarylogic_si256(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
						sinpi = maxmath.sin(sinpi);
						sinpi = mm256_ternarylogic_si256(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

						r = Avx.mm256_div_ps(Avx.mm256_set1_ps(-math.PI), Avx.mm256_mul_ps(sinpi, Avx.mm256_mul_ps(absX, r)));
						z = mm256_ternarylogic_si256(ABS_MASK, a, z, TernaryOperation.OxA6);
					}

					v256 result = Avx.mm256_mul_ps(r, maxmath.pow(y, z));
					
					// the following is 100% free, ILP
					v256 negative = Avx.mm256_andnot_ps(ABS_MASK, a);
					v256 floorX = Avx.mm256_floor_ps(a);
					v256 floorHalfX = Avx.mm256_floor_ps(Avx.mm256_mul_ps(a, HALF));

					v256 mask0 = Avx2.mm256_cmpgt_epi32(absX, Avx.mm256_set1_epi32(0x7F80_0000));
					v256 result0 = Avx.mm256_add_ps(a, Avx.mm256_set1_ps(float.PositiveInfinity));

					v256 mask1 = mm256_ternarylogic_si256(Avx.mm256_cmp_ps(a, floorX, (int)Avx.CMP.EQ_OQ), Avx.mm256_cmp_ps(a, ZERO, (int)Avx.CMP.EQ_OQ), negative, TernaryOperation.OxEO);
					v256 result1 = Avx.mm256_set1_ps(float.NaN);
					
					v256 mask2 = Avx2.mm256_cmpgt_epi32(absX, Avx.mm256_set1_epi32(0x420C_0000));
					v256 result2_1 = Avx.mm256_mul_ps(Avx.mm256_set1_ps(float.MaxValue), a);
					v256 result2_2 = Avx.mm256_andnot_ps(ABS_MASK, Avx.mm256_cmp_ps(floorX, floorHalfX, (int)Avx.CMP.NEQ_OQ));
					v256 result2 = Avx.mm256_blendv_ps(result2_1, result2_2, negative);
					
					v256 mask3 = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32((0x7F - 54) << 23), absX);
					v256 result3 = rcp;

					result3 = Avx.mm256_blendv_ps(result3, result2, mask2);
					result3 = Avx.mm256_blendv_ps(result3, result1, mask1);
					result3 = Avx.mm256_blendv_ps(result3, result0, mask0);
					mask3 = Avx2.mm256_or_si256(mask3, mm256_ternarylogic_si256(mask0, mask1, mask2, TernaryOperation.OxFE));

					return Avx.mm256_blendv_ps(result, result3, mask3);
                }
				else throw new IllegalInstructionException();
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 gamma_pd(v128 a)
			{
                if (Sse2.IsSse2Supported)
                {
					v128 ZERO = Sse2.setzero_si128();
					v128 ONE = Sse2.set1_pd(1d);
					v128 HALF = Sse2.set1_pd(0.5d);
					v128 PI = Sse2.set1_pd(math.PI_DBL);
					v128 ABS_MASK = Sse2.set1_epi64x(0x7FFF_FFFF_FFFF_FFFFL);

					v128 absX = Sse2.and_pd(ABS_MASK, a);
					v128 rcp = Sse2.div_pd(ONE, a);
					
					v128 fmaddMask = Sse2.cmplt_pd(a, Sse2.set1_pd(8d));
					v128 rcpfma = blendv_pd(Sse2.and_si128(ABS_MASK, rcp), absX, fmaddMask);
					
					v128 num = fmadd_pd(blendv_pd(Sse2.set1_pd(F64_SNUM0), Sse2.set1_pd(F64_SNUM12), fmaddMask), rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM1), Sse2.set1_pd(F64_SNUM11), fmaddMask));
					v128 den = Sse2.add_pd(Sse2.and_pd(fmaddMask, rcpfma), blendv_pd(Sse2.set1_pd(F64_SDEN1), Sse2.set1_pd(F64_SDEN11), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM2),  Sse2.set1_pd(F64_SNUM10), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN2),  Sse2.set1_pd(F64_SDEN10), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM3),  Sse2.set1_pd(F64_SNUM9), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN3),  Sse2.set1_pd(F64_SDEN9), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM4),  Sse2.set1_pd(F64_SNUM8), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN4),  Sse2.set1_pd(F64_SDEN8), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM5),  Sse2.set1_pd(F64_SNUM7), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN5),  Sse2.set1_pd(F64_SDEN7), fmaddMask));
					num = fmadd_pd(num, rcpfma, Sse2.set1_pd(F64_SNUM6));
					den = fmadd_pd(den, rcpfma, Sse2.set1_pd(F64_SDEN6));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM7),  Sse2.set1_pd(F64_SNUM5), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN7),  Sse2.set1_pd(F64_SDEN5), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM8),  Sse2.set1_pd(F64_SNUM4), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN8),  Sse2.set1_pd(F64_SDEN4), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM9),  Sse2.set1_pd(F64_SNUM3), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN9),  Sse2.set1_pd(F64_SDEN3), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM10), Sse2.set1_pd(F64_SNUM2), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN10), Sse2.set1_pd(F64_SDEN2), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM11), Sse2.set1_pd(F64_SNUM1), fmaddMask));
					den = fmadd_pd(den, rcpfma, blendv_pd(Sse2.set1_pd(F64_SDEN11), Sse2.set1_pd(F64_SDEN1), fmaddMask));
					num = fmadd_pd(num, rcpfma, blendv_pd(Sse2.set1_pd(F64_SNUM12), Sse2.set1_pd(F64_SNUM0), fmaddMask));
					den = fmadd_pd(den, rcpfma, Sse2.andnot_pd(fmaddMask, ONE));

					v128 y = Sse2.add_pd(absX, Sse2.set1_pd(GM_HALF));
					v128 z = Sse2.sub_pd(absX, HALF);
					v128 r = Sse2.mul_pd(Sse2.div_pd(num, den), RegisterConversion.ToV128(math.exp(-RegisterConversion.ToDouble2(y))));
					
					if (Sse2.movemask_pd(a) != 0) 
					{
					    v128 sinpi = Sse2.mul_pd(absX, HALF);
						v128 floorsinpi;
						if (Sse4_1.IsSse41Supported)
						{
							floorsinpi = Sse4_1.floor_pd(sinpi);
						}
						else
						{
							floorsinpi = RegisterConversion.ToV128(math.floor(RegisterConversion.ToDouble2(sinpi)));
						}
					    sinpi = Sse2.sub_pd(sinpi, floorsinpi);
					    sinpi = Sse2.add_pd(sinpi, sinpi);
					
					    v128 n = usfcvttpd_epu64(sinpi);
					    n = Sse2.srli_epi64(Sse2.add_epi64(n, Sse2.set1_epi64x(1 << 2)), 3);
						v128 q1 = Sse2.cmpeq_epi32(n, Sse2.set1_epi64x(1));
						v128 q2 = Sse2.cmpeq_epi32(n, Sse2.set1_epi64x(2));
						v128 q3 = Sse2.cmpeq_epi32(n, Sse2.set1_epi64x(3)); 
						if (Sse4_1.IsSse41Supported)
						{
							;
						}
						else
						{
							q1 = Sse2.shuffle_epi32(q1, Sse.SHUFFLE(2, 2, 0, 0));
							q2 = Sse2.shuffle_epi32(q2, Sse.SHUFFLE(2, 2, 0, 0));
							q3 = Sse2.shuffle_epi32(q3, Sse.SHUFFLE(2, 2, 0, 0));
						}

						sinpi = fnmadd_pd(usfcvtepu64_pd(n), HALF, sinpi);
						sinpi = fmadd_pd(sinpi, PI, ternarylogic_si128(PI, q1, q3, TernaryOperation.OxEO));
						sinpi = ternarylogic_si128(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
						sinpi = RegisterConversion.ToV128(math.sin(RegisterConversion.ToDouble2(sinpi)));
						sinpi = ternarylogic_si128(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

						r = Sse2.div_pd(Sse2.set1_pd(-math.PI_DBL), Sse2.mul_pd(sinpi, Sse2.mul_pd(absX, r)));
						z = ternarylogic_si128(ABS_MASK, a, z, TernaryOperation.OxA6);
					}

					v128 result = Sse2.mul_pd(r, RegisterConversion.ToV128(math.pow(RegisterConversion.ToDouble2(y), RegisterConversion.ToDouble2(z))));
					
					v128 negative = Sse2.andnot_pd(ABS_MASK, a);
					v128 floorX;
					v128 floorHalfX;
                    if (Sse4_1.IsSse41Supported)
                    {
						floorX = Sse4_1.floor_pd(a);
						floorHalfX = Sse4_1.floor_pd(Sse2.mul_pd(a, HALF));
                    }
					else
					{
						floorX = RegisterConversion.ToV128(math.floor(RegisterConversion.ToDouble2(a)));
						floorHalfX = RegisterConversion.ToV128(math.floor(RegisterConversion.ToDouble2(HALF) * RegisterConversion.ToDouble2(a)));
						negative = srai_epi64(negative, 63);
					}
					

					v128 mask0 = Sse2.cmpgt_epi32(absX, Sse2.set1_epi64x(0x7FEF_FFFF_FFFF_FFFFL));
					v128 result0 = Sse2.add_pd(a, Sse2.set1_pd(double.PositiveInfinity));

					v128 mask1 = ternarylogic_si128(Sse2.cmpeq_pd(a, floorX), Sse2.cmpeq_pd(a, ZERO), negative, TernaryOperation.OxEO);
					v128 result1 = Sse2.set1_pd(double.NaN);
					
					v128 mask2 = Sse2.cmpgt_epi32(absX, Sse2.set1_epi64x(0x4066_FFFF_FFFF_FFFF));
					v128 result2_1 = Sse2.mul_pd(Sse2.set1_pd(double.MaxValue), a);
					v128 result2_2 = Sse2.andnot_si128(ABS_MASK, Sse2.cmpneq_pd(floorX, floorHalfX));
					v128 result2 = blendv_pd(result2_1, result2_2, negative);
					
					v128 mask3 = Sse2.cmpgt_epi32(Sse2.set1_epi64x((long)(0x3FF - 54) << 52), absX);
					v128 result3 = rcp;

                    if (Sse4_1.IsSse41Supported)
                    {
						;
                    }
					else
					{
						mask0 = Sse2.shuffle_epi32(mask0, Sse.SHUFFLE(3, 3, 1, 1));
						mask1 = Sse2.shuffle_epi32(mask1, Sse.SHUFFLE(3, 3, 1, 1));
						mask2 = Sse2.shuffle_epi32(mask2, Sse.SHUFFLE(3, 3, 1, 1));
						mask3 = Sse2.shuffle_epi32(mask3, Sse.SHUFFLE(3, 3, 1, 1));
					}

					result3 = blendv_pd(result3, result2, mask2);
					result3 = blendv_pd(result3, result1, mask1);
					result3 = blendv_pd(result3, result0, mask0);
					mask3 = Sse2.or_si128(mask3, ternarylogic_si128(mask0, mask1, mask2, TernaryOperation.OxFE));

					return blendv_pd(result, result3, mask3);
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_gamma_pd(v256 a, byte elements = 4)
			{
			    if (Avx2.IsAvx2Supported)
                {
					v256 ZERO = Avx.mm256_setzero_si256();
					v256 ONE = Avx.mm256_set1_pd(1d);
					v256 HALF = Avx.mm256_set1_pd(0.5d);
					v256 PI = Avx.mm256_set1_pd(math.PI_DBL);
					v256 ABS_MASK = Avx.mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFFL);

					v256 absX = Avx.mm256_and_pd(ABS_MASK, a);
					v256 rcp = Avx.mm256_div_pd(ONE, a);
					
					v256 fmaddMask = Avx.mm256_cmp_pd(a, Avx.mm256_set1_pd(8d), (int)Avx.CMP.LT_OQ);
					v256 rcpfma = Avx.mm256_blendv_pd(Avx2.mm256_and_si256(ABS_MASK, rcp), absX, fmaddMask);
					
					v256 num = mm256_fmadd_pd(Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM0), Avx.mm256_set1_pd(F64_SNUM12), fmaddMask), rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM1), Avx.mm256_set1_pd(F64_SNUM11), fmaddMask));
					v256 den = Avx.mm256_add_pd(Avx.mm256_and_pd(fmaddMask, rcpfma), Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN1), Avx.mm256_set1_pd(F64_SDEN11), fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM2),  Avx.mm256_set1_pd(F64_SNUM10), fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN2),  Avx.mm256_set1_pd(F64_SDEN10), fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM3),  Avx.mm256_set1_pd(F64_SNUM9),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN3),  Avx.mm256_set1_pd(F64_SDEN9),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM4),  Avx.mm256_set1_pd(F64_SNUM8),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN4),  Avx.mm256_set1_pd(F64_SDEN8),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM5),  Avx.mm256_set1_pd(F64_SNUM7),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN5),  Avx.mm256_set1_pd(F64_SDEN7),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_set1_pd(F64_SNUM6));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_set1_pd(F64_SDEN6));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM7),  Avx.mm256_set1_pd(F64_SNUM5),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN7),  Avx.mm256_set1_pd(F64_SDEN5),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM8),  Avx.mm256_set1_pd(F64_SNUM4),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN8),  Avx.mm256_set1_pd(F64_SDEN4),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM9),  Avx.mm256_set1_pd(F64_SNUM3),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN9),  Avx.mm256_set1_pd(F64_SDEN3),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM10), Avx.mm256_set1_pd(F64_SNUM2),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN10), Avx.mm256_set1_pd(F64_SDEN2),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM11), Avx.mm256_set1_pd(F64_SNUM1),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SDEN11), Avx.mm256_set1_pd(F64_SDEN1),  fmaddMask));
					num = mm256_fmadd_pd(num, rcpfma, Avx.mm256_blendv_pd(Avx.mm256_set1_pd(F64_SNUM12), Avx.mm256_set1_pd(F64_SNUM0),  fmaddMask));
					den = mm256_fmadd_pd(den, rcpfma, Avx.mm256_andnot_pd(fmaddMask, ONE));

					v256 y = Avx.mm256_add_pd(absX, Avx.mm256_set1_pd(GM_HALF));
					v256 z = Avx.mm256_sub_pd(absX, HALF);
					v256 r = Avx.mm256_mul_pd(Avx.mm256_div_pd(num, den), RegisterConversion.ToV256(math.exp(-RegisterConversion.ToDouble4(y))));
					
					bool reflect;
                    if (elements == 3) reflect = (Avx.mm256_movemask_pd(a) & 0b0111) != 0;
                    else			   reflect = Avx.mm256_movemask_pd(a) != 0;

					if (reflect) 
					{
					    v256 sinpi = Avx.mm256_mul_pd(absX, HALF);
						v256 floorsinpi = Avx.mm256_floor_pd(sinpi);
					    sinpi = Avx.mm256_sub_pd(sinpi, floorsinpi);
					    sinpi = Avx.mm256_add_pd(sinpi, sinpi);
					
					    v256 n = mm256_usfcvttpd_epu64(sinpi);
					    n = Avx2.mm256_srli_epi64(Avx2.mm256_add_epi64(n, Avx.mm256_set1_epi64x(1 << 2)), 3);
						v256 q1 = Avx2.mm256_cmpeq_epi32(n, Avx.mm256_set1_epi64x(1));
						v256 q2 = Avx2.mm256_cmpeq_epi32(n, Avx.mm256_set1_epi64x(2));
						v256 q3 = Avx2.mm256_cmpeq_epi32(n, Avx.mm256_set1_epi64x(3)); 

						sinpi = mm256_fnmadd_pd(mm256_usfcvtepu64_pd(n), HALF, sinpi);
						sinpi = mm256_fmadd_pd(sinpi, PI, mm256_ternarylogic_si256(PI, q1, q3, TernaryOperation.OxEO));
						sinpi = mm256_ternarylogic_si256(ABS_MASK, q2, sinpi, TernaryOperation.OxA6);
						sinpi = RegisterConversion.ToV256(math.sin(RegisterConversion.ToDouble4(sinpi)));
						sinpi = mm256_ternarylogic_si256(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

						r = Avx.mm256_div_pd(Avx.mm256_set1_pd(-math.PI_DBL), Avx.mm256_mul_pd(sinpi, Avx.mm256_mul_pd(absX, r)));
						z = mm256_ternarylogic_si256(ABS_MASK, a, z, TernaryOperation.OxA6);
					}

					v256 result = Avx.mm256_mul_pd(r, RegisterConversion.ToV256(math.pow(RegisterConversion.ToDouble4(y), RegisterConversion.ToDouble4(z))));
					
					v256 negative = Avx.mm256_andnot_pd(ABS_MASK, a);
					v256 floorX = Avx.mm256_floor_pd(a);
					v256 floorHalfX = Avx.mm256_floor_pd(Avx.mm256_mul_pd(a, HALF));

					v256 mask0 = Avx2.mm256_cmpgt_epi32(absX, Avx.mm256_set1_epi64x(0x7FEF_FFFF_FFFF_FFFFL));
					v256 result0 = Avx.mm256_add_pd(a, Avx.mm256_set1_pd(double.PositiveInfinity));

					v256 mask1 = mm256_ternarylogic_si256(Avx.mm256_cmp_pd(a, floorX, (int)Avx.CMP.EQ_OQ), Avx.mm256_cmp_pd(a, ZERO, (int)Avx.CMP.EQ_OQ), negative, TernaryOperation.OxEO);
					v256 result1 = Avx.mm256_set1_pd(double.NaN);
					
					v256 mask2 = Avx2.mm256_cmpgt_epi32(absX, Avx.mm256_set1_epi64x(0x4066_FFFF_FFFF_FFFF));
					v256 result2_1 = Avx.mm256_mul_pd(Avx.mm256_set1_pd(double.MaxValue), a);
					v256 result2_2 = Avx2.mm256_andnot_si256(ABS_MASK, Avx.mm256_cmp_pd(floorX, floorHalfX, (int)Avx.CMP.NEQ_OQ));
					v256 result2 = Avx.mm256_blendv_pd(result2_1, result2_2, negative);
					
					v256 mask3 = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi64x((long)(0x3FF - 54) << 52), absX);
					v256 result3 = rcp;

					result3 = Avx.mm256_blendv_pd(result3, result2, mask2);
					result3 = Avx.mm256_blendv_pd(result3, result1, mask1);
					result3 = Avx.mm256_blendv_pd(result3, result0, mask0);
					mask3 = Avx2.mm256_or_si256(mask3, mm256_ternarylogic_si256(mask0, mask1, mask2, TernaryOperation.OxFE));

					return Avx.mm256_blendv_pd(result, result3, mask3);
                }
				else throw new IllegalInstructionException();
			}
		}
	}
	

    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the value of the gamma function Γ(x + 1) = x! for <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float gamma(float x)
        {
			uint u = *(uint*)&x;
			uint ix = u & 0x7FFF_FFFFu;
			uint sign = andnot(u, 0x7FFF_FFFFu);
			
			float absX = math.abs(x);
			float rcp = math.rcp(absX);

			if (ix >= 0x7F80_0000)
			{
			    return x + float.PositiveInfinity;
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
			
			if (x < 0) 
			{
			    float sinpi = absX * 0.5f;
			    sinpi = sinpi - math.floor(sinpi);
				sinpi += sinpi;

			    int n = 4 * (int)sinpi;
			    n = (n + 1) >> 1;
			    sinpi -= n * 0.5f;
			    sinpi *= math.PI;

				sinpi = negate(math.sin(negate(sinpi + ((n == 1 | n == 3) ? math.PI : 0f), n == 2)), n == 3);

			    r = -math.PI / (sinpi * (absX * r));
			    z = -z;
			}

			return r * pow(y, z);
        }
		
        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 gamma(float2 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToFloat2(Xse.gamma_ps(RegisterConversion.ToV128(x), 2));
            }
			else
			{
				return new float2(gamma(x.x), gamma(x.y));
			}
		}
		
        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 gamma(float3 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToFloat3(Xse.gamma_ps(RegisterConversion.ToV128(x), 3));
            }
			else
			{
				return new float3(gamma(x.x), gamma(x.y), gamma(x.z));
			}
		}
		
        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 gamma(float4 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToFloat4(Xse.gamma_ps(RegisterConversion.ToV128(x), 4));
            }
			else
			{
				return new float4(gamma(x.x), gamma(x.y), gamma(x.z), gamma(x.w));
			}
		}
		
        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float8 gamma(float8 x)
		{
            if (Avx2.IsAvx2Supported)
            {
				return Xse.mm256_gamma_ps(x);
            }
			else
			{
				return new float8(gamma(x.v4_0), gamma(x.v4_4));
			}
		}
		
		
		/// <summary>       Returns the value of the gamma function Γ(x + 1) = x! for <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double gamma(double x)
		{
			ulong u = *(ulong*)&x;
			ulong ix = u & 0x7FFF_FFFF_FFFF_FFFFul;
			ulong sign = andnot(u, 0x7FFF_FFFF_FFFF_FFFFul);
			
			double absX = math.abs(x);
			double rcp = math.rcp(absX);
			
			if (ix >= 0x7FF0_0000_0000_0000)
			{
			    return x + double.PositiveInfinity;
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
			
			if (x < 0) 
			{
			    double sinpi = absX * 0.5d;
			    sinpi = sinpi - math.floor(sinpi);
				sinpi += sinpi;

			    int n = 4 * (int)sinpi;
			    n = (n + 1) >> 1;
			    sinpi -= n * 0.5d;
			    sinpi *= math.PI_DBL;

				sinpi = negate(math.sin(negate(sinpi + ((n == 1 | n == 3) ? math.PI_DBL : 0d), n == 2)), n == 3);

			    r = -math.PI_DBL / (sinpi * (absX * r));
			    z = -z;
			}

			return r * pow(y, z);
		}
		
        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 gamma(double2 x)
		{
            if (Sse2.IsSse2Supported)
            {
				return RegisterConversion.ToDouble2(Xse.gamma_pd(RegisterConversion.ToV128(x)));
            }
			else
			{
				return new double2(gamma(x.x), gamma(x.y));
			}
		}
		
        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 gamma(double3 x)
		{
            if (Avx2.IsAvx2Supported)
            {
				return RegisterConversion.ToDouble3(Xse.mm256_gamma_pd(RegisterConversion.ToV256(x), 3));
            }
			else
			{
				return new double3(gamma(x.xy), gamma(x.z));
			}
		}
		
        /// <summary>       Returns the componentwise value of the gamma function Γ(x + 1) = x! for each <paramref name="x"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 gamma(double4 x)
		{
            if (Avx2.IsAvx2Supported)
            {
				return RegisterConversion.ToDouble4(Xse.mm256_gamma_pd(RegisterConversion.ToV256(x), 4));
            }
			else
			{
				return new double4(gamma(x.xy), gamma(x.zw));
			}
		}
	}
}
