using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;
using MaxMath.CompilerServices;
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
			private static void lngamma_sincospd_ps(v128 a, [NoAlias] out v128 s, [NoAlias] out v128 c)
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 z = mul_pd(a, a);
					v128 w = mul_pd(z, z);

					v128 r_s = fmadd_pd(z, set1_pd(2.7183114939898219e-06), set1_pd(-0.00019839334836096632));
					s = mul_pd(z, a);
					s = fmadd_pd(mul_pd(s, w), r_s, fmadd_pd(fmadd_pd(z, set1_pd(-0.0083333293858894632), set1_pd(-0.16666666641626524)), s, a));
					s = cvtpd_ps(s);
					
					c = fmadd_pd(z, set1_pd(0.0000243904487962774090654), set1_pd(-0.00138867637746099294692));
					c = fmadd_pd(mul_pd(w, z), c, fmadd_pd(w, set1_pd(0.0416666233237390631894), fmadd_pd(z, set1_pd(-0.499999997251031003120), set1_pd(1))));
					c = cvtpd_ps(c);
				}
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void mm256_lngamma_sincospd_ps(v256 a, [NoAlias] out v128 s, [NoAlias] out v128 c)
			{
				if (Avx.IsAvxSupported)
				{
					v256 z = Avx.mm256_mul_pd(a, a);
					v256 w = Avx.mm256_mul_pd(z, z);

					v256 r_s = mm256_fmadd_pd(z, mm256_set1_pd(2.7183114939898219e-06), mm256_set1_pd(-0.00019839334836096632));
					v256 s128 = Avx.mm256_mul_pd(z, a);
					s128 = mm256_fmadd_pd(Avx.mm256_mul_pd(s128, w), r_s, mm256_fmadd_pd(mm256_fmadd_pd(z, mm256_set1_pd(-0.0083333293858894632), mm256_set1_pd(-0.16666666641626524)), s128, a));
					s = Avx.mm256_cvtpd_ps(s128);
					
					v256 c128 = mm256_fmadd_pd(z, mm256_set1_pd(0.0000243904487962774090654), mm256_set1_pd(-0.00138867637746099294692));
					c128 = mm256_fmadd_pd(Avx.mm256_mul_pd(w, z), c128, mm256_fmadd_pd(w, mm256_set1_pd(0.0416666233237390631894), mm256_fmadd_pd(z, mm256_set1_pd(-0.499999997251031003120), mm256_set1_pd(1))));
					c = Avx.mm256_cvtpd_ps(c128);
				}
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static v128 lngamma_sinpipd_ps(v128 a, byte elements = 4)
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					a = mul_ps(set1_ps(2), fmsub_ps(a, set1_ps(0.5f), floor_ps(mul_ps(a, set1_ps(0.5f)))));
			
					v128 n = cvttps_epi32(mul_ps(set1_ps(4), a));
					n = srli_epi32(inc_epi32(n), 1);

					v128 s;
					v128 c;
					if (elements == 2)
					{
						v128 y = fnmadd_pd(set1_pd(0.5), cvtepi32_pd(n), cvtps_pd(a));
						y = mul_pd(y, set1_pd(math.PI_DBL));
						lngamma_sincospd_ps(y, out s, out c);
					}
					else
					{
						if (Avx.IsAvxSupported)
						{
							v256 y = mm256_fnmadd_pd(mm256_set1_pd(0.5), Avx.mm256_cvtepi32_pd(n), Avx.mm256_cvtps_pd(a));
							y = Avx.mm256_mul_pd(y, mm256_set1_pd(math.PI_DBL));
							mm256_lngamma_sincospd_ps(y, out s, out c);
						}
						else
						{
							v128 y0 = fnmadd_pd(set1_pd(0.5), cvtepi32_pd(n), cvtps_pd(a));
							v128 y1 = fnmadd_pd(set1_pd(0.5), cvtepi32_pd(bsrli_si128(n, 2 * sizeof(int))), cvtps_pd(bsrli_si128(a, 2 * sizeof(float))));
							y0 = mul_pd(y0, set1_pd(math.PI_DBL));
							y1 = mul_pd(y1, set1_pd(math.PI_DBL));
							lngamma_sincospd_ps(y0, out v128 s0, out v128 c0);
							lngamma_sincospd_ps(y1, out v128 s1, out v128 c1);
							s = unpacklo_epi64(s0, s1);
							c = unpacklo_epi64(c0, c1);
						}
					}

					v128 nOddMSB = slli_epi32(n, 31);
					v128 neg = slli_epi32(cmprange_epi32(n, set1_epi32(2), set1_epi32(3)), 31);
					
					return xor_si128(neg, blendv_ps(s, c, nOddMSB));
				}
				else throw new IllegalInstructionException();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static v256 mm256_lngamma_sinpipd_ps(v256 a)
			{
				if (Avx2.IsAvx2Supported)
				{
					a = Avx.mm256_mul_ps(mm256_set1_ps(2), mm256_fmsub_ps(a, mm256_set1_ps(0.5f), mm256_floor_ps(Avx.mm256_mul_ps(a, mm256_set1_ps(0.5f)))));
			
					v256 n = Avx.mm256_cvttps_epi32(Avx.mm256_mul_ps(mm256_set1_ps(4), a));
					n = Avx2.mm256_srli_epi32(mm256_inc_epi32(n), 1);

					v256 y0 = mm256_fnmadd_pd(mm256_set1_pd(0.5), Avx.mm256_cvtepi32_pd(Avx.mm256_castsi256_si128(n)),      Avx.mm256_cvtps_pd(Avx.mm256_castsi256_si128(a)));
					v256 y1 = mm256_fnmadd_pd(mm256_set1_pd(0.5), Avx.mm256_cvtepi32_pd(Avx.mm256_extractf128_si256(n, 1)), Avx.mm256_cvtps_pd(Avx.mm256_extractf128_si256(n, 1)));
					y0 = Avx.mm256_mul_pd(y0, mm256_set1_pd(math.PI_DBL));
					y1 = Avx.mm256_mul_pd(y1, mm256_set1_pd(math.PI_DBL));
					mm256_lngamma_sincospd_ps(y0, out v128 s0, out v128 c0);
					mm256_lngamma_sincospd_ps(y1, out v128 s1, out v128 c1);
					v256 s = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(s0), s1, 1);
					v256 c = Avx.mm256_insertf128_ps(Avx.mm256_castps128_ps256(c0), c1, 1);

					v256 nOddMSB = Avx2.mm256_slli_epi32(n, 31);
					v256 neg = Avx2.mm256_slli_epi32(mm256_cmprange_epi32(n, mm256_set1_epi32(2), mm256_set1_epi32(3)), 31);
					
					return Avx2.mm256_xor_si256(neg, Avx.mm256_blendv_ps(s, c, nOddMSB));
				}
				else throw new IllegalInstructionException();
			}
			
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void lngamma_sincos_pd(v128 a, [NoAlias] out v128 s, [NoAlias] out v128 c)
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 z = mul_pd(a, a);
					v128 w = mul_pd(z, z);
					v128 v = mul_pd(z, a);

					v128 r_s = fmadd_pd(mul_pd(z, w), fmadd_pd(set1_pd(1.58969099521155010221e-10), z, set1_pd(-2.50507602534068634195e-08)), fmadd_pd(fmadd_pd(set1_pd(2.75573137070700676789e-06), z, set1_pd(-1.98412698298579493134e-04)), z, set1_pd(8.33333333332248946124e-03)));
					v128 r_c  = fmadd_pd(mul_pd(w, w), fmadd_pd(fmadd_pd(set1_pd(-1.13596475577881948265e-11), z, set1_pd(2.08757232129817482790e-09)), z, set1_pd(-2.75573143513906633035e-07)), mul_pd(z, fmadd_pd(fmadd_pd(set1_pd(2.48015872894767294178e-05), z, set1_pd(-1.38888888888741095749e-03)), z, set1_pd(4.16666666666666019037e-02))));
					
					v128 hz = mul_pd(set1_pd(0.5), z);
					w = fnmadd_pd(set1_pd(0.5), z, set1_pd(1.0));

					s = fmadd_pd(fmadd_pd(z, r_s, set1_pd(-1.66666666666666324348e-01)), v, a);
					c = fmadd_pd(z, r_c, add_pd(w, (sub_pd(sub_pd(set1_pd(1.0), w), hz))));
				}
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static void mm256_lngamma_sincos_pd(v256 a, [NoAlias] out v256 s, [NoAlias] out v256 c)
			{
				if (Avx.IsAvxSupported)
				{
					v256 z = Avx.mm256_mul_pd(a, a);
					v256 w = Avx.mm256_mul_pd(z, z);
					v256 v = Avx.mm256_mul_pd(z, a);

					v256 r_s = mm256_fmadd_pd(Avx.mm256_mul_pd(z, w), mm256_fmadd_pd(mm256_set1_pd(1.58969099521155010221e-10), z, mm256_set1_pd(-2.50507602534068634195e-08)), mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(2.75573137070700676789e-06), z, mm256_set1_pd(-1.98412698298579493134e-04)), z, mm256_set1_pd(8.33333333332248946124e-03)));
					v256 r_c  = mm256_fmadd_pd(Avx.mm256_mul_pd(w, w), mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(-1.13596475577881948265e-11), z, mm256_set1_pd(2.08757232129817482790e-09)), z, mm256_set1_pd(-2.75573143513906633035e-07)), Avx.mm256_mul_pd(z, mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(2.48015872894767294178e-05), z, mm256_set1_pd(-1.38888888888741095749e-03)), z, mm256_set1_pd(4.16666666666666019037e-02))));
					
					v256 hz = Avx.mm256_mul_pd(mm256_set1_pd(0.5), z);
					w = mm256_fnmadd_pd(mm256_set1_pd(0.5), z, mm256_set1_pd(1.0));

					s = mm256_fmadd_pd(mm256_fmadd_pd(z, r_s, mm256_set1_pd(-1.66666666666666324348e-01)), v, a);
					c = mm256_fmadd_pd(z, r_c, Avx.mm256_add_pd(w, (Avx.mm256_sub_pd(Avx.mm256_sub_pd(mm256_set1_pd(1.0), w), hz))));
				}
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static v128 lngamma_sinpi_pd(v128 a)
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					a = mul_pd(set1_pd(2), fmsub_pd(a, set1_pd(0.5), floor_pd(mul_pd(a, set1_pd(0.5)))));
			
					v128 n = cvttpd_epi32(mul_pd(set1_pd(4), a));
					n = srli_epi32(inc_epi32(n), 1);
					
					v128 y = fnmadd_pd(set1_pd(0.5), cvtepi32_pd(n), a);
					y = mul_pd(y, set1_pd(math.PI_DBL));
					lngamma_sincos_pd(y, out v128 s, out v128 c);

					v128 n128 = cvtepu32_epi64(n);
					v128 nOddMSB = slli_epi64(n128, 63);
					v128 neg = slli_epi64(cmprange_epi64(n128, set1_epi64x(2), set1_epi64x(3)), 63);
					
					return xor_si128(neg, blendv_pd(s, c, nOddMSB));
				}
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static v256 mm256_lngamma_sinpi_pd(v256 a)
			{
				if (Avx2.IsAvx2Supported)
				{
					a = Avx.mm256_mul_pd(mm256_set1_pd(2), mm256_fmsub_pd(a, mm256_set1_pd(0.5), mm256_floor_pd(Avx.mm256_mul_pd(a, mm256_set1_pd(0.5)))));
			
					v128 n = Avx.mm256_cvttpd_epi32(Avx.mm256_mul_pd(mm256_set1_pd(4), a));
					n = srli_epi32(inc_epi32(n), 1);
					
					v256 y = mm256_fnmadd_pd(mm256_set1_pd(0.5), Avx.mm256_cvtepi32_pd(n), a);
					y = Avx.mm256_mul_pd(y, mm256_set1_pd(math.PI_DBL));
					mm256_lngamma_sincos_pd(y, out v256 s, out v256 c);
					
					v256 n256 = Avx2.mm256_cvtepu32_epi64(n);
					v256 nOddMSB = Avx2.mm256_slli_epi64(n256, 63);
					v256 neg = Avx2.mm256_slli_epi64(mm256_cmprange_epi64(n256, mm256_set1_epi64x(2), mm256_set1_epi64x(3)), 63);
					
					return Avx2.mm256_xor_si256(neg, Avx.mm256_blendv_pd(s, c, nOddMSB));
				}
				else throw new IllegalInstructionException();
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 CORE_lngamma_ps(v128 a, out v128 cmp5)
            {
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 ZERO = setzero_ps();;
					v128 ONE = set1_ps(1f);
					v128 HALF = set1_ps(0.5f);

                #region cmp1
					v128 cmp5a = cmpgt_epi32(a, set1_epi32(0x3E6D_3307));
					v128 cmp6a = cmpgt_epi32(a, set1_epi32(0x3F3B_4A1F));
					v128 cmp5b = cmpgt_epi32(a, set1_epi32(0x3F9D_A61F));
					v128 cmp6b = cmpgt_epi32(a, set1_epi32(0x3FDD_A617));

					v128 suba = blendv_si128(and_si128(set1_ps(tc - 1.0f), cmp5a), a, cmp6a);
					v128 subb = blendv_si128(ONE, blendv_si128(set1_ps(tc), a, cmp6b), cmp5b);
					v128 subfroma = blendv_si128(a, ONE, cmp6a);
					v128 subfromb = blendv_si128(a, set1_ps(2), cmp6b);
					v128 ya = sub_ps(subfroma, suba);
					v128 yb = sub_ps(subfromb, subb);

					v128 ia = set1_epi32(2);
					ia = add_epi32(ia, cmp6a);
					ia = add_epi32(ia, cmp5a);
					v128 ib = set1_epi32(2);
					ib = add_epi32(ib, cmp6b);
					ib = add_epi32(ib, cmp5b);

					v128 cmp4_1 = cmpgt_epi32(set1_epi32(0x3F66_6667), a);
					v128 i = blendv_si128(ib, ia, cmp4_1);
					v128 y0 = blendv_si128(yb, ya, cmp4_1);

					v128 cmpi0 = cmpeq_epi32(i, ZERO);
					v128 cmpi1 = cmpeq_epi32(i, set1_epi32(1));

					v128 madd_arg = blendv_si128(blendv_si128(y0, mul_ps(mul_ps(y0, y0), y0), cmpi1), mul_ps(y0, y0), cmpi0);

					v128 p3 = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(t14), madd_arg, set1_ps(t11)), madd_arg, set1_ps(t8)), madd_arg, set1_ps(t5)), madd_arg, set1_ps(t2));

					v128 madd2_0 = blendv_si128(blendv_si128(set1_ps(v5), set1_ps(t13), cmpi1), set1_ps(a11), cmpi0);
					v128 madd2_1 = blendv_si128(blendv_si128(set1_ps(v4), set1_ps(t10), cmpi1), set1_ps(a9), cmpi0);
					v128 madd2_2 = blendv_si128(blendv_si128(set1_ps(v3), set1_ps(t7), cmpi1), set1_ps(a7), cmpi0);
					v128 madd2_3 = blendv_si128(blendv_si128(set1_ps(v2), set1_ps(t4), cmpi1), set1_ps(a5), cmpi0);
					v128 madd2_4 = blendv_si128(blendv_si128(set1_ps(v1), set1_ps(t1), cmpi1), set1_ps(a3), cmpi0);
					v128 p2 = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(madd2_0, madd_arg, madd2_1), madd_arg, madd2_2), madd_arg, madd2_3), madd_arg, madd2_4);

					v128 madd1_0 = blendv_si128(blendv_si128(set1_ps(u5), set1_ps(t12), cmpi1), set1_ps(a10), cmpi0);
					v128 madd1_1 = blendv_si128(blendv_si128(set1_ps(u4), set1_ps(t9), cmpi1), set1_ps(a8), cmpi0);
					v128 madd1_2 = blendv_si128(blendv_si128(set1_ps(u3), set1_ps(t6), cmpi1), set1_ps(a6), cmpi0);
					v128 madd1_3 = blendv_si128(blendv_si128(set1_ps(u2), set1_ps(t3), cmpi1), set1_ps(a4), cmpi0);
					v128 madd1_4 = blendv_si128(blendv_si128(set1_ps(u1), set1_ps(t0), cmpi1), set1_ps(a2), cmpi0);
					v128 p1 = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(madd1_0, madd_arg, madd1_1), madd_arg, madd1_2), madd_arg, madd1_3), madd_arg, madd1_4);

					v128 add2;
					v128 add1 = add_ps(set1_ps(tf), fmsub_ps(mul_ps(y0, y0), p1, fnmadd_ps(fmadd_ps(p3, y0, p2), madd_arg, set1_ps(tt))));
					v128 add0;

					v128 p2mul = blendv_si128(ONE, madd_arg, cmpi0);
					v128 p2fadd = blendv_si128(ONE, set1_ps(a1), cmpi0);
					v128 p1mul = blendv_si128(madd_arg, ONE, cmpi0);
					v128 p1fadd = blendv_si128(set1_ps(u0), set1_ps(a0), cmpi0);

					p2 = mul_ps(p2mul, fmadd_ps(p2, madd_arg, p2fadd));
					p1 = mul_ps(p1mul, fmadd_ps(p1, madd_arg, p1fadd));

					add2 = fnmadd_ps(HALF, madd_arg, div_ps(p1, p2));
					add0 = fnmadd_ps(HALF, y0, fmadd_ps(y0, p1, p2));
                #endregion

                #region cmp2
					v128 toInt = trunc_ps(a);
					v128 frac = sub_ps(a, toInt);
					v128 p4 = mul_ps(frac, fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(s6), frac, set1_ps(s5)), frac, set1_ps(s4)), frac, set1_ps(s3)), frac, set1_ps(s2)), frac, set1_ps(s1)), frac, set1_ps(s0)));
					v128 q = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(set1_ps(r6), frac, set1_ps(r5)), frac, set1_ps(r4)), frac, set1_ps(r3)), frac, set1_ps(r2)), frac, set1_ps(r1)), frac, ONE);
					v128 res2 = fmadd_ps(HALF, frac, div_ps(p4, q));

					v128 chain3 = add_ps(frac, set1_ps(2));
					v128 chain4 = mul_ps(chain3, add_ps(frac, set1_ps(3)));
					v128 chain5 = mul_ps(chain4, add_ps(frac, set1_ps(4)));
					v128 chain6 = mul_ps(chain5, add_ps(frac, set1_ps(5)));
					v128 chain7 = mul_ps(chain6, add_ps(frac, set1_ps(6)));

					v128 chain = blendv_si128(blendv_si128(chain3, chain4, cmpeq_ps(toInt, set1_ps(4))),
					                          blendv_si128(chain5, chain6, cmpeq_ps(toInt, set1_ps(6))),
					                          cmpgt_ps(toInt, set1_ps(4)));

					chain = blendv_si128(chain, chain7, cmpeq_ps(toInt, set1_ps(7)));
                #endregion

                #region cmp3
					v128 rcp = div_ps(ONE, a);
					v128 y2 = mul_ps(rcp, rcp);
					v128 w = fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(fmadd_ps(y2, set1_ps(w6), set1_ps(w5)), y2, set1_ps(w4)), y2, set1_ps(w3)), y2, set1_ps(w2)), y2, set1_ps(w1)), rcp, set1_ps(w0));
                #endregion

					v128 cmp1 = cmpgt_epi32(set1_epi32(0x4000_0000), a);
					v128 cmp2 = cmpgt_epi32(set1_epi32(0x4100_0000), a);
					v128 cmp3 = cmpgt_epi32(set1_epi32(0x5C80_0000), a);
					cmp5 = cmpgt_epi32(set1_epi32(0x3500_0000), a);
					v128 log = math.log((float4)blendv_si128(a, chain, andnot_si128(cmp1, cmp2)));

					v128 res1 = sub_ps(blendv_si128(blendv_si128(add2, add0, cmpi0), add1, cmpi1), and_si128(log, cmp4_1));
					res2 = add_ps(res2, and_si128(log, cmpgt_ps(toInt, set1_ps(2))));
					v128 res3 = fmadd_ps(sub_ps(a, HALF), sub_ps(log, ONE), w);
					v128 res4 = mul_ps(a, sub_ps(log, ONE));
					v128 res5 = neg_ps(log);

					v128 r = blendv_si128(blendv_si128(blendv_si128(blendv_si128(res4, res3, cmp3), res2, cmp2), res1, cmp1), res5, cmp5);
					return  ternarylogic_si128(r, cmpeq_epi32(a, set1_epi32(0x3F80_0000)), cmpeq_epi32(a, set1_epi32(0x4000_0000)), TernaryOperation.Ox1O);
				}
				else throw new IllegalInstructionException();
            }
			
			[MethodImpl(MethodImplOptions.NoInlining)]
            public static v128 BASE__EITHER__SIGN__lngamma_ps(v128 a, out v128 sign, byte elements = 4)
			{
				if (BurstArchitecture.IsSIMDSupported)
                {
					v128 ZERO = setzero_ps();

					v128 negative = cmplt_ps(a, ZERO);
					sign = set1_epi32(1);
					a = abs_ps(a);
					
                    v128 r = CORE_lngamma_ps(a, out v128 cmp5);

					if (notallfalse_f128<float>(negative, elements)) 
					{
						v128 t = lngamma_sinpipd_ps(a);
						
						sign = or_si128(sign, cmpgt_ps(t, ZERO));
						v128 cmp0 = cmpeq_ps(t, ZERO);
						v128 res0 = set1_ps(float.PositiveInfinity);
						v128 nadj = math.log((float4)div_ps(set1_ps(math.PI), mul_ps(abs_ps(t), a)));

						r = blendv_si128(blendv_si128(r, sub_ps(nadj, r), negative), res0, cmp0);
					}

					sign = ternarylogic_si128(sign, negative, cmp5, TernaryOperation.OxF8);

					return r;
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.NoInlining)]
			public static v128 BASE__POSITIVE__lngamma_ps(v128 a, out v128 sign)
			{
				if (BurstArchitecture.IsSIMDSupported)
                {
					sign = set1_epi32(1);
					
                    return CORE_lngamma_ps(a, out _);
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 lngamma_ps(v128 a, out v128 sign, byte elements = 4, bool promisePositive = false, bool promiseFinite = false)
			{
				if (BurstArchitecture.IsSIMDSupported)
                {
					v128 r = promisePositive 
						   ? BASE__POSITIVE__lngamma_ps(a, out sign)
						   : BASE__EITHER__SIGN__lngamma_ps(a, out sign, elements);

					if (!promiseFinite)
					{
						v128 aCMP = promisePositive ? a : abs_ps(a);
						r = blendv_si128(r, mul_ps(a, a), cmpgt_epi32(aCMP, set1_epi32(0x7F7F_FFFF)));
					}
					
					return r;
                }
				else throw new IllegalInstructionException();
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 CORE_mm256_lngamma_ps(v256 a, out v256 cmp5)
            {
				if (Avx2.IsAvx2Supported)
				{
					v256 ZERO = Avx.mm256_setzero_ps();;
					v256 ONE = Avx.mm256_set1_ps(1f);
					v256 HALF = Avx.mm256_set1_ps(0.5f);

                #region cmp1
					v256 cmp5a = Avx2.mm256_cmpgt_epi32(a, mm256_set1_epi32(0x3E6D_3307));
					v256 cmp6a = Avx2.mm256_cmpgt_epi32(a, mm256_set1_epi32(0x3F3B_4A1F));
					v256 cmp5b = Avx2.mm256_cmpgt_epi32(a, mm256_set1_epi32(0x3F9D_A61F));
					v256 cmp6b = Avx2.mm256_cmpgt_epi32(a, mm256_set1_epi32(0x3FDD_A617));

					v256 suba = mm256_blendv_si256(Avx2.mm256_and_si256(mm256_set1_ps(tc - 1.0f), cmp5a), a, cmp6a);
					v256 subb = mm256_blendv_si256(ONE, mm256_blendv_si256(mm256_set1_ps(tc), a, cmp6b), cmp5b);
					v256 subfroma = mm256_blendv_si256(a, ONE, cmp6a);
					v256 subfromb = mm256_blendv_si256(a, mm256_set1_ps(2), cmp6b);
					v256 ya = Avx.mm256_sub_ps(subfroma, suba);
					v256 yb = Avx.mm256_sub_ps(subfromb, subb);

					v256 ia = mm256_set1_epi32(2);
					ia = Avx2.mm256_add_epi32(ia, cmp6a);
					ia = Avx2.mm256_add_epi32(ia, cmp5a);
					v256 ib = mm256_set1_epi32(2);
					ib = Avx2.mm256_add_epi32(ib, cmp6b);
					ib = Avx2.mm256_add_epi32(ib, cmp5b);

					v256 cmp4_1 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3F66_6667), a);
					v256 i = mm256_blendv_si256(ib, ia, cmp4_1);
					v256 y0 = mm256_blendv_si256(yb, ya, cmp4_1);

					v256 cmpi0 = Avx2.mm256_cmpeq_epi32(i, ZERO);
					v256 cmpi1 = Avx2.mm256_cmpeq_epi32(i, mm256_set1_epi32(1));

					v256 madd_arg = mm256_blendv_si256(mm256_blendv_si256(y0, Avx.mm256_mul_ps(Avx.mm256_mul_ps(y0, y0), y0), cmpi1), Avx.mm256_mul_ps(y0, y0), cmpi0);

					v256 p3 = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(t14), madd_arg, mm256_set1_ps(t11)), madd_arg, mm256_set1_ps(t8)), madd_arg, mm256_set1_ps(t5)), madd_arg, mm256_set1_ps(t2));

					v256 madd2_0 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(v5), mm256_set1_ps(t13), cmpi1), mm256_set1_ps(a11), cmpi0);
					v256 madd2_1 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(v4), mm256_set1_ps(t10), cmpi1), mm256_set1_ps(a9), cmpi0);
					v256 madd2_2 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(v3), mm256_set1_ps(t7), cmpi1), mm256_set1_ps(a7), cmpi0);
					v256 madd2_3 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(v2), mm256_set1_ps(t4), cmpi1), mm256_set1_ps(a5), cmpi0);
					v256 madd2_4 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(v1), mm256_set1_ps(t1), cmpi1), mm256_set1_ps(a3), cmpi0);
					v256 p2 = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(madd2_0, madd_arg, madd2_1), madd_arg, madd2_2), madd_arg, madd2_3), madd_arg, madd2_4);

					v256 madd1_0 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(u5), mm256_set1_ps(t12), cmpi1), mm256_set1_ps(a10), cmpi0);
					v256 madd1_1 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(u4), mm256_set1_ps(t9), cmpi1), mm256_set1_ps(a8), cmpi0);
					v256 madd1_2 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(u3), mm256_set1_ps(t6), cmpi1), mm256_set1_ps(a6), cmpi0);
					v256 madd1_3 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(u2), mm256_set1_ps(t3), cmpi1), mm256_set1_ps(a4), cmpi0);
					v256 madd1_4 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_ps(u1), mm256_set1_ps(t0), cmpi1), mm256_set1_ps(a2), cmpi0);
					v256 p1 = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(madd1_0, madd_arg, madd1_1), madd_arg, madd1_2), madd_arg, madd1_3), madd_arg, madd1_4);

					v256 add2;
					v256 add1 = Avx.mm256_add_ps(mm256_set1_ps(tf), mm256_fmsub_ps(Avx.mm256_mul_ps(y0, y0), p1, mm256_fnmadd_ps(mm256_fmadd_ps(p3, y0, p2), madd_arg, mm256_set1_ps(tt))));
					v256 add0;

					v256 p2mul = mm256_blendv_si256(ONE, madd_arg, cmpi0);
					v256 p2fadd = mm256_blendv_si256(ONE, mm256_set1_ps(a1), cmpi0);
					v256 p1mul = mm256_blendv_si256(madd_arg, ONE, cmpi0);
					v256 p1fadd = mm256_blendv_si256(mm256_set1_ps(u0), mm256_set1_ps(a0), cmpi0);

					p2 = Avx.mm256_mul_ps(p2mul, mm256_fmadd_ps(p2, madd_arg, p2fadd));
					p1 = Avx.mm256_mul_ps(p1mul, mm256_fmadd_ps(p1, madd_arg, p1fadd));

					add2 = mm256_fnmadd_ps(HALF, madd_arg, Avx.mm256_div_ps(p1, p2));
					add0 = mm256_fnmadd_ps(HALF, y0, mm256_fmadd_ps(y0, p1, p2));
                #endregion

                #region cmp2
					v256 toInt = mm256_trunc_ps(a);
					v256 frac = Avx.mm256_sub_ps(a, toInt);
					v256 p4 = Avx.mm256_mul_ps(frac, mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(s6), frac, mm256_set1_ps(s5)), frac, mm256_set1_ps(s4)), frac, mm256_set1_ps(s3)), frac, mm256_set1_ps(s2)), frac, mm256_set1_ps(s1)), frac, mm256_set1_ps(s0)));
					v256 q = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_set1_ps(r6), frac, mm256_set1_ps(r5)), frac, mm256_set1_ps(r4)), frac, mm256_set1_ps(r3)), frac, mm256_set1_ps(r2)), frac, mm256_set1_ps(r1)), frac, ONE);
					v256 res2 = mm256_fmadd_ps(HALF, frac, Avx.mm256_div_ps(p4, q));

					v256 chain3 = Avx.mm256_add_ps(frac, mm256_set1_ps(2));
					v256 chain4 = Avx.mm256_mul_ps(chain3, Avx.mm256_add_ps(frac, mm256_set1_ps(3)));
					v256 chain5 = Avx.mm256_mul_ps(chain4, Avx.mm256_add_ps(frac, mm256_set1_ps(4)));
					v256 chain6 = Avx.mm256_mul_ps(chain5, Avx.mm256_add_ps(frac, mm256_set1_ps(5)));
					v256 chain7 = Avx.mm256_mul_ps(chain6, Avx.mm256_add_ps(frac, mm256_set1_ps(6)));

					v256 chain = mm256_blendv_si256(mm256_blendv_si256(chain3, chain4, mm256_cmpeq_ps(toInt, mm256_set1_ps(4))),
													mm256_blendv_si256(chain5, chain6, mm256_cmpeq_ps(toInt, mm256_set1_ps(6))),
													mm256_cmpgt_ps(toInt, mm256_set1_ps(4)));

					chain = mm256_blendv_si256(chain, chain7, mm256_cmpeq_ps(toInt, mm256_set1_ps(7)));
                #endregion

                #region cmp3
					v256 rcp = Avx.mm256_div_ps(ONE, a);
					v256 y2 = Avx.mm256_mul_ps(rcp, rcp);
					v256 w = mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(mm256_fmadd_ps(y2, mm256_set1_ps(w6), mm256_set1_ps(w5)), y2, mm256_set1_ps(w4)), y2, mm256_set1_ps(w3)), y2, mm256_set1_ps(w2)), y2, mm256_set1_ps(w1)), rcp, mm256_set1_ps(w0));
                #endregion

					v256 cmp1 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x4000_0000), a);
					v256 cmp2 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x4100_0000), a);
					v256 cmp3 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x5C80_0000), a);
					cmp5 = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x3500_0000), a);
					v256 log = math.log((float8)mm256_blendv_si256(a, chain, Avx2.mm256_andnot_si256(cmp1, cmp2)));

					v256 res1 = Avx.mm256_sub_ps(mm256_blendv_si256(mm256_blendv_si256(add2, add0, cmpi0), add1, cmpi1), Avx2.mm256_and_si256(log, cmp4_1));
					res2 = Avx.mm256_add_ps(res2, Avx2.mm256_and_si256(log, mm256_cmpgt_ps(toInt, mm256_set1_ps(2))));
					v256 res3 = mm256_fmadd_ps(Avx.mm256_sub_ps(a, HALF), Avx.mm256_sub_ps(log, ONE), w);
					v256 res4 = Avx.mm256_mul_ps(a, Avx.mm256_sub_ps(log, ONE));
					v256 res5 = mm256_neg_ps(log);

					v256 r = mm256_blendv_si256(mm256_blendv_si256(mm256_blendv_si256(mm256_blendv_si256(res4, res3, cmp3), res2, cmp2), res1, cmp1), res5, cmp5);
					return  mm256_ternarylogic_si256(r, Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(0x3F80_0000)), Avx2.mm256_cmpeq_epi32(a, mm256_set1_epi32(0x4000_0000)), TernaryOperation.Ox1O);
				}
				else throw new IllegalInstructionException();
            }
			
			[MethodImpl(MethodImplOptions.NoInlining)]
            public static v256 BASE__EITHER__SIGN__mm256_lngamma_ps(v256 a, out v256 sign)
			{
				if (Avx2.IsAvx2Supported)
                {
					v256 ZERO = Avx.mm256_setzero_ps();

					v256 negative = mm256_cmplt_ps(a, ZERO);
					sign = mm256_set1_epi32(1);
					a = mm256_abs_ps(a);
					
                    v256 r = CORE_mm256_lngamma_ps(a, out v256 cmp5);

					if (mm256_notallfalse_f256<float>(negative)) 
					{
						v256 t = mm256_lngamma_sinpipd_ps(a);

						sign = Avx2.mm256_or_si256(sign, mm256_cmpgt_ps(t, ZERO));
						v256 cmp0 = mm256_cmpeq_ps(t, ZERO);
						v256 res0 = mm256_set1_ps(float.PositiveInfinity);
						v256 nadj = math.log((float8)Avx.mm256_div_ps(mm256_set1_ps(math.PI), Avx.mm256_mul_ps(mm256_abs_ps(t), a)));
						r = mm256_blendv_si256(mm256_blendv_si256(r, Avx.mm256_sub_ps(nadj, r), negative), res0, cmp0); 
					}

					sign = mm256_ternarylogic_si256(sign, negative, cmp5, TernaryOperation.OxF8);

					return r;
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.NoInlining)]
			public static v256 BASE__POSITIVE__mm256_lngamma_ps(v256 a, out v256 sign)
			{
				if (Avx2.IsAvx2Supported)
                {
					sign = mm256_set1_epi32(1);
					
                    return CORE_mm256_lngamma_ps(a, out _);
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_lngamma_ps(v256 a, out v256 sign, bool promisePositive = false, bool promiseFinite = false)
			{
				if (Avx2.IsAvx2Supported)
                {
					v256 r = promisePositive 
						   ? BASE__POSITIVE__mm256_lngamma_ps(a, out sign)
						   : BASE__EITHER__SIGN__mm256_lngamma_ps(a, out sign);

					if (!promiseFinite)
					{
						v256 aCMP = promisePositive ? a : mm256_abs_ps(a);
						r = mm256_blendv_si256(r, Avx.mm256_mul_ps(a, a), Avx2.mm256_cmpgt_epi32(aCMP, mm256_set1_epi32(0x7F7F_FFFF)));
					}
					
					return r;
                }
				else throw new IllegalInstructionException();
			}


			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 CORE_lngamma_pd(v128 a, out v128 cmp5)
            {
				if (BurstArchitecture.IsSIMDSupported)
				{
					v128 ZERO = setzero_si128();
					v128 ONE = set1_pd(1);
					v128 HALF = set1_pd(0.5);

                #region cmp1
					v128 cmp5a = cmpgt_epi64(a, set1_epi64x(0x3FCD_A660_FFFF_FFFF));
					v128 cmp6a = cmpgt_epi64(a, set1_epi64x(0x3FE7_6943_FFFF_FFFF));
					v128 cmp5b = cmpgt_epi64(a, set1_epi64x(0x3FF3_B4C3_FFFF_FFFF));
					v128 cmp6b = cmpgt_epi64(a, set1_epi64x(0x3FFB_B4C2_FFFF_FFFF));

					v128 suba = blendv_si128(and_si128(set1_pd(tc_DBL - 1.0), cmp5a), a, cmp6a);
					v128 subb = blendv_si128(ONE, blendv_si128(set1_pd(tc_DBL), a, cmp6b), cmp5b);
					v128 subfroma = blendv_si128(a, ONE, cmp6a);
					v128 subfromb = blendv_si128(a, set1_pd(2), cmp6b);
					v128 ya = sub_pd(subfroma, suba);
					v128 yb = sub_pd(subfromb, subb);

					v128 ia = set1_epi64x(2);
					ia = add_epi64(ia, cmp6a);
					ia = add_epi64(ia, cmp5a);
					v128 ib = set1_epi64x(2);
					ib = add_epi64(ib, cmp6b);
					ib = add_epi64(ib, cmp5b);

					v128 cmp4_1 = cmpgt_epi64(set1_epi64x(0x3FEC_CCCC_0000_0001), a);
					v128 i = blendv_si128(ib, ia, cmp4_1);
					v128 y0 = blendv_si128(yb, ya, cmp4_1);

					v128 cmpi0 = cmpeq_epi64(i, ZERO);
					v128 cmpi1 = cmpeq_epi64(i, set1_epi64x(1));

					v128 madd_arg = blendv_si128(blendv_si128(y0, mul_pd(mul_pd(y0, y0), y0), cmpi1), mul_pd(y0, y0), cmpi0);

					v128 p3 = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(t14_DBL), madd_arg, set1_pd(t11_DBL)), madd_arg, set1_pd(t8_DBL)), madd_arg, set1_pd(t5_DBL)), madd_arg, set1_pd(t2_DBL));

					v128 madd2_0 = blendv_si128(blendv_si128(set1_pd(v5_DBL), set1_pd(t13_DBL), cmpi1), set1_pd(a11_DBL), cmpi0);
					v128 madd2_1 = blendv_si128(blendv_si128(set1_pd(v4_DBL), set1_pd(t10_DBL), cmpi1), set1_pd(a9_DBL), cmpi0);
					v128 madd2_2 = blendv_si128(blendv_si128(set1_pd(v3_DBL), set1_pd(t7_DBL),  cmpi1), set1_pd(a7_DBL), cmpi0);
					v128 madd2_3 = blendv_si128(blendv_si128(set1_pd(v2_DBL), set1_pd(t4_DBL),  cmpi1), set1_pd(a5_DBL), cmpi0);
					v128 madd2_4 = blendv_si128(blendv_si128(set1_pd(v1_DBL), set1_pd(t1_DBL),  cmpi1), set1_pd(a3_DBL), cmpi0);
					v128 p2 = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(madd2_0, madd_arg, madd2_1), madd_arg, madd2_2), madd_arg, madd2_3), madd_arg, madd2_4);

					v128 madd1_0 = blendv_si128(blendv_si128(set1_pd(u5_DBL), set1_pd(t12_DBL), cmpi1), set1_pd(a10_DBL), cmpi0);
					v128 madd1_1 = blendv_si128(blendv_si128(set1_pd(u4_DBL), set1_pd(t9_DBL), cmpi1),  set1_pd(a8_DBL),  cmpi0);
					v128 madd1_2 = blendv_si128(blendv_si128(set1_pd(u3_DBL), set1_pd(t6_DBL), cmpi1),  set1_pd(a6_DBL),  cmpi0);
					v128 madd1_3 = blendv_si128(blendv_si128(set1_pd(u2_DBL), set1_pd(t3_DBL), cmpi1),  set1_pd(a4_DBL),  cmpi0);
					v128 madd1_4 = blendv_si128(blendv_si128(set1_pd(u1_DBL), set1_pd(t0_DBL), cmpi1),  set1_pd(a2_DBL),  cmpi0);
					v128 p1 = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(madd1_0, madd_arg, madd1_1), madd_arg, madd1_2), madd_arg, madd1_3), madd_arg, madd1_4);

					v128 add2;
					v128 add1 = add_pd(set1_pd(tf_DBL), fmsub_pd(mul_pd(y0, y0), p1, fnmadd_pd(fmadd_pd(p3, y0, p2), madd_arg, set1_pd(tt_DBL))));
					v128 add0;

					v128 p2mul = blendv_si128(ONE, madd_arg, cmpi0);
					v128 p2fadd = blendv_si128(ONE, set1_pd(a1_DBL), cmpi0);
					v128 p1mul = blendv_si128(madd_arg, ONE, cmpi0);
					v128 p1fadd = blendv_si128(set1_pd(u0_DBL), set1_pd(a0_DBL), cmpi0);

					p2 = mul_pd(p2mul, fmadd_pd(p2, madd_arg, p2fadd));
					p1 = mul_pd(p1mul, fmadd_pd(p1, madd_arg, p1fadd));

					add2 = fnmadd_pd(HALF, madd_arg, div_pd(p1, p2));
					add0 = fnmadd_pd(HALF, y0, fmadd_pd(y0, p1, p2));
                #endregion

                #region cmp2
					v128 toInt = trunc_pd(a);
					v128 frac = sub_pd(a, toInt);
					v128 p4 = mul_pd(frac, fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(s6_DBL), frac, set1_pd(s5_DBL)), frac, set1_pd(s4_DBL)), frac, set1_pd(s3_DBL)), frac, set1_pd(s2_DBL)), frac, set1_pd(s1_DBL)), frac, set1_pd(s0_DBL)));
					v128 q = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(set1_pd(r6_DBL), frac, set1_pd(r5_DBL)), frac, set1_pd(r4_DBL)), frac, set1_pd(r3_DBL)), frac, set1_pd(r2_DBL)), frac, set1_pd(r1_DBL)), frac, ONE);
					v128 res2 = fmadd_pd(HALF, frac, div_pd(p4, q));

					v128 chain3 = add_pd(frac, set1_pd(2));
					v128 chain4 = mul_pd(chain3, add_pd(frac, set1_pd(3)));
					v128 chain5 = mul_pd(chain4, add_pd(frac, set1_pd(4)));
					v128 chain6 = mul_pd(chain5, add_pd(frac, set1_pd(5)));
					v128 chain7 = mul_pd(chain6, add_pd(frac, set1_pd(6)));

					v128 chain = blendv_si128(blendv_si128(chain3, chain4, cmpeq_pd(toInt, set1_pd(4))),
					                          blendv_si128(chain5, chain6, cmpeq_pd(toInt, set1_pd(6))),
					                          cmpgt_pd(toInt, set1_pd(4)));

					chain = blendv_si128(chain, chain7, cmpeq_pd(toInt, set1_pd(7)));
                #endregion

                #region cmp3
					v128 rcp = div_pd(ONE, a);
					v128 y2 = mul_pd(rcp, rcp);
					v128 w = fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(fmadd_pd(y2, set1_pd(w6_DBL), set1_pd(w5_DBL)), y2, set1_pd(w4_DBL)), y2, set1_pd(w3_DBL)), y2, set1_pd(w2_DBL)), y2, set1_pd(w1_DBL)), rcp, set1_pd(w0_DBL));
                #endregion

					v128 cmp1 = cmpgt_epi64(set1_epi64x(0x4000_0000_0000_0000), a);
					v128 cmp2 = cmpgt_epi64(set1_epi64x(0x4020_0000_0000_0000), a);
					v128 cmp3 = cmpgt_epi64(set1_epi64x(0x4390_0000_0000_0000), a);
					cmp5 = cmpgt_epi64(set1_epi64x((0x3FFul - 70) << 52), a);
					v128 log = math.log((double2)blendv_si128(a, chain, andnot_si128(cmp1, cmp2)));

					v128 res1 = sub_pd(blendv_si128(blendv_si128(add2, add0, cmpi0), add1, cmpi1), and_si128(log, cmp4_1));
					res2 = add_pd(res2, and_si128(log, cmpgt_pd(toInt, set1_pd(2))));
					v128 res3 = fmadd_pd(sub_pd(a, HALF), sub_pd(log, ONE), w);
					v128 res4 = mul_pd(a, sub_pd(log, ONE));
					v128 res5 = neg_pd(log);
					
					v128 r = blendv_si128(blendv_si128(blendv_si128(blendv_si128(res4, res3, cmp3), res2, cmp2), res1, cmp1), res5, cmp5);
					return  ternarylogic_si128(r, cmpeq_epi64(a, set1_epi64x(0x3FF0_0000_0000_0000)), cmpeq_epi64(a, set1_epi64x(0x4000_0000_0000_0000)), TernaryOperation.Ox1O);
				}
				else throw new IllegalInstructionException();
            }
			
			[MethodImpl(MethodImplOptions.NoInlining)]
            public static v128 BASE__EITHER__SIGN__lngamma_pd(v128 a, out v128 sign)
			{
				if (BurstArchitecture.IsSIMDSupported)
                {
					v128 ZERO = setzero_si128();

					v128 negative = cmplt_pd(a, ZERO);
					sign = set1_epi64x(1);
					a = abs_pd(a);
					
                    v128 r = CORE_lngamma_pd(a, out v128 cmp5);

					if (notallfalse_f128<double>(negative, 2)) 
					{
						v128 t = lngamma_sinpi_pd(a);

						sign = or_si128(sign, cmpgt_pd(t, ZERO));
						v128 cmp0 = cmpeq_pd(t, ZERO);
						v128 res0 = set1_pd(double.PositiveInfinity);
						v128 nadj = math.log((double2)div_pd(set1_pd(math.PI_DBL), mul_pd(abs_pd(t), a)));
						r = blendv_si128(blendv_si128(r, sub_pd(nadj, r), negative), res0, cmp0);  
					}

					sign = ternarylogic_si128(sign, negative, cmp5, TernaryOperation.OxF8);

					return r;
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.NoInlining)]
			public static v128 BASE__POSITIVE__lngamma_pd(v128 a, out v128 sign)
			{
				if (BurstArchitecture.IsSIMDSupported)
                {
					sign = set1_epi64x(1);
					
                    return CORE_lngamma_pd(a, out _);
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 lngamma_pd(v128 a, out v128 sign, bool promisePositive = false, bool promiseFinite = false)
			{
				if (BurstArchitecture.IsSIMDSupported)
                {
					v128 r = promisePositive 
						   ? BASE__POSITIVE__lngamma_pd(a, out sign)
						   : BASE__EITHER__SIGN__lngamma_pd(a, out sign);

					if (!promiseFinite)
					{
						v128 aCMP = promisePositive ? a : abs_pd(a);
						r = blendv_si128(r, mul_pd(a, a), cmpgt_epi64(aCMP, set1_epi64x(0x7FEF_FFFF_FFFF_FFFF)));
					}
					
					return r;
                }
				else throw new IllegalInstructionException();
			}
			

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 CORE_mm256_lngamma_pd(v256 a, out v256 cmp5)
            {
				if (Avx2.IsAvx2Supported)
				{
					v256 ZERO = Avx.mm256_setzero_pd();;
					v256 ONE = Avx.mm256_set1_pd(1);
					v256 HALF = Avx.mm256_set1_pd(0.5);

                #region cmp1
					v256 cmp5a = Avx2.mm256_cmpgt_epi64(a, mm256_set1_epi64x(0x3FCD_A660_FFFF_FFFF));
					v256 cmp6a = Avx2.mm256_cmpgt_epi64(a, mm256_set1_epi64x(0x3FE7_6943_FFFF_FFFF));
					v256 cmp5b = Avx2.mm256_cmpgt_epi64(a, mm256_set1_epi64x(0x3FF3_B4C3_FFFF_FFFF));
					v256 cmp6b = Avx2.mm256_cmpgt_epi64(a, mm256_set1_epi64x(0x3FFB_B4C2_FFFF_FFFF));

					v256 suba = mm256_blendv_si256(Avx2.mm256_and_si256(mm256_set1_pd(tc_DBL - 1.0), cmp5a), a, cmp6a);
					v256 subb = mm256_blendv_si256(ONE, mm256_blendv_si256(mm256_set1_pd(tc_DBL), a, cmp6b), cmp5b);
					v256 subfroma = mm256_blendv_si256(a, ONE, cmp6a);
					v256 subfromb = mm256_blendv_si256(a, mm256_set1_pd(2), cmp6b);
					v256 ya = Avx.mm256_sub_pd(subfroma, suba);
					v256 yb = Avx.mm256_sub_pd(subfromb, subb);

					v256 ia = mm256_set1_epi64x(2);
					ia = Avx2.mm256_add_epi64(ia, cmp6a);
					ia = Avx2.mm256_add_epi64(ia, cmp5a);
					v256 ib = mm256_set1_epi64x(2);
					ib = Avx2.mm256_add_epi64(ib, cmp6b);
					ib = Avx2.mm256_add_epi64(ib, cmp5b);

					v256 cmp4_1 = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x(0x3FEC_CCCC_0000_0001), a);
					v256 i = mm256_blendv_si256(ib, ia, cmp4_1);
					v256 y0 = mm256_blendv_si256(yb, ya, cmp4_1);

					v256 cmpi0 = Avx2.mm256_cmpeq_epi64(i, ZERO);
					v256 cmpi1 = Avx2.mm256_cmpeq_epi64(i, mm256_set1_epi64x(1));

					v256 madd_arg = mm256_blendv_si256(mm256_blendv_si256(y0, Avx.mm256_mul_pd(Avx.mm256_mul_pd(y0, y0), y0), cmpi1), Avx.mm256_mul_pd(y0, y0), cmpi0);

					v256 p3 = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(t14_DBL), madd_arg, mm256_set1_pd(t11_DBL)), madd_arg, mm256_set1_pd(t8_DBL)), madd_arg, mm256_set1_pd(t5_DBL)), madd_arg, mm256_set1_pd(t2_DBL));

					v256 madd2_0 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(v5_DBL), mm256_set1_pd(t13_DBL),  cmpi1), mm256_set1_pd(a11_DBL), cmpi0);
					v256 madd2_1 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(v4_DBL), mm256_set1_pd(t10_DBL),  cmpi1), mm256_set1_pd(a9_DBL),  cmpi0);
					v256 madd2_2 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(v3_DBL), mm256_set1_pd(t7_DBL),  cmpi1),  mm256_set1_pd(a7_DBL),  cmpi0);
					v256 madd2_3 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(v2_DBL), mm256_set1_pd(t4_DBL),  cmpi1),  mm256_set1_pd(a5_DBL),  cmpi0);
					v256 madd2_4 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(v1_DBL), mm256_set1_pd(t1_DBL),  cmpi1),  mm256_set1_pd(a3_DBL),  cmpi0);
					v256 p2 = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(madd2_0, madd_arg, madd2_1), madd_arg, madd2_2), madd_arg, madd2_3), madd_arg, madd2_4);

					v256 madd1_0 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(u5_DBL), mm256_set1_pd(t12_DBL), cmpi1), mm256_set1_pd(a10_DBL), cmpi0);
					v256 madd1_1 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(u4_DBL), mm256_set1_pd(t9_DBL), cmpi1),  mm256_set1_pd(a8_DBL),  cmpi0);
					v256 madd1_2 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(u3_DBL), mm256_set1_pd(t6_DBL), cmpi1),  mm256_set1_pd(a6_DBL),  cmpi0);
					v256 madd1_3 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(u2_DBL), mm256_set1_pd(t3_DBL), cmpi1),  mm256_set1_pd(a4_DBL),  cmpi0);
					v256 madd1_4 = mm256_blendv_si256(mm256_blendv_si256(mm256_set1_pd(u1_DBL), mm256_set1_pd(t0_DBL), cmpi1),  mm256_set1_pd(a2_DBL),  cmpi0);
					v256 p1 = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(madd1_0, madd_arg, madd1_1), madd_arg, madd1_2), madd_arg, madd1_3), madd_arg, madd1_4);

					v256 add2;
					v256 add1 = Avx.mm256_add_pd(mm256_set1_pd(tf_DBL), mm256_fmsub_pd(Avx.mm256_mul_pd(y0, y0), p1, mm256_fnmadd_pd(mm256_fmadd_pd(p3, y0, p2), madd_arg, mm256_set1_pd(tt_DBL))));
					v256 add0;

					v256 p2mul = mm256_blendv_si256(ONE, madd_arg, cmpi0);
					v256 p2fadd = mm256_blendv_si256(ONE, mm256_set1_pd(a1_DBL), cmpi0);
					v256 p1mul = mm256_blendv_si256(madd_arg, ONE, cmpi0);
					v256 p1fadd = mm256_blendv_si256(mm256_set1_pd(u0_DBL), mm256_set1_pd(a0_DBL), cmpi0);

					p2 = Avx.mm256_mul_pd(p2mul, mm256_fmadd_pd(p2, madd_arg, p2fadd));
					p1 = Avx.mm256_mul_pd(p1mul, mm256_fmadd_pd(p1, madd_arg, p1fadd));

					add2 = mm256_fnmadd_pd(HALF, madd_arg, Avx.mm256_div_pd(p1, p2));
					add0 = mm256_fnmadd_pd(HALF, y0, mm256_fmadd_pd(y0, p1, p2));
                #endregion

                #region cmp2
					v256 toInt = mm256_trunc_pd(a);
					v256 frac = Avx.mm256_sub_pd(a, toInt);
					v256 p4 = Avx.mm256_mul_pd(frac, mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(s6_DBL), frac, mm256_set1_pd(s5_DBL)), frac, mm256_set1_pd(s4_DBL)), frac, mm256_set1_pd(s3_DBL)), frac, mm256_set1_pd(s2_DBL)), frac, mm256_set1_pd(s1_DBL)), frac, mm256_set1_pd(s0_DBL)));
					v256 q = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(r6_DBL), frac, mm256_set1_pd(r5_DBL)), frac, mm256_set1_pd(r4_DBL)), frac, mm256_set1_pd(r3_DBL)), frac, mm256_set1_pd(r2_DBL)), frac, mm256_set1_pd(r1_DBL)), frac, ONE);
					v256 res2 = mm256_fmadd_pd(HALF, frac, Avx.mm256_div_pd(p4, q));

					v256 chain3 = Avx.mm256_add_pd(frac, mm256_set1_pd(2));
					v256 chain4 = Avx.mm256_mul_pd(chain3, Avx.mm256_add_pd(frac, mm256_set1_pd(3)));
					v256 chain5 = Avx.mm256_mul_pd(chain4, Avx.mm256_add_pd(frac, mm256_set1_pd(4)));
					v256 chain6 = Avx.mm256_mul_pd(chain5, Avx.mm256_add_pd(frac, mm256_set1_pd(5)));
					v256 chain7 = Avx.mm256_mul_pd(chain6, Avx.mm256_add_pd(frac, mm256_set1_pd(6)));

					v256 chain = mm256_blendv_si256(mm256_blendv_si256(chain3, chain4, mm256_cmpeq_pd(toInt, mm256_set1_pd(4))),
													mm256_blendv_si256(chain5, chain6, mm256_cmpeq_pd(toInt, mm256_set1_pd(6))),
													mm256_cmpgt_pd(toInt, mm256_set1_pd(4)));

					chain = mm256_blendv_si256(chain, chain7, mm256_cmpeq_pd(toInt, mm256_set1_pd(7)));
                #endregion

                #region cmp3
					v256 rcp = Avx.mm256_div_pd(ONE, a);
					v256 y2 = Avx.mm256_mul_pd(rcp, rcp);
					v256 w = mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(mm256_fmadd_pd(y2, mm256_set1_pd(w6_DBL), mm256_set1_pd(w5_DBL)), y2, mm256_set1_pd(w4_DBL)), y2, mm256_set1_pd(w3_DBL)), y2, mm256_set1_pd(w2_DBL)), y2, mm256_set1_pd(w1_DBL)), rcp, mm256_set1_pd(w0_DBL));
                #endregion

					v256 cmp1 = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x(0x4000_0000_0000_0000), a);
					v256 cmp2 = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x(0x4020_0000_0000_0000), a);
					v256 cmp3 = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x(0x4390_0000_0000_0000), a);
					cmp5 = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x((0x3FFul - 70) << 52), a);
					v256 log = math.log((double4)mm256_blendv_si256(a, chain, Avx2.mm256_andnot_si256(cmp1, cmp2)));

					v256 res1 = Avx.mm256_sub_pd(mm256_blendv_si256(mm256_blendv_si256(add2, add0, cmpi0), add1, cmpi1), Avx2.mm256_and_si256(log, cmp4_1));
					res2 = Avx.mm256_add_pd(res2, Avx2.mm256_and_si256(log, mm256_cmpgt_pd(toInt, mm256_set1_pd(2))));
					v256 res3 = mm256_fmadd_pd(Avx.mm256_sub_pd(a, HALF), Avx.mm256_sub_pd(log, ONE), w);
					v256 res4 = Avx.mm256_mul_pd(a, Avx.mm256_sub_pd(log, ONE));
					v256 res5 = mm256_neg_pd(log);

					v256 r = mm256_blendv_si256(mm256_blendv_si256(mm256_blendv_si256(mm256_blendv_si256(res4, res3, cmp3), res2, cmp2), res1, cmp1), res5, cmp5);
					return  mm256_ternarylogic_si256(r, Avx2.mm256_cmpeq_epi64(a, mm256_set1_epi64x(0x3FF0_0000_0000_0000)), Avx2.mm256_cmpeq_epi64(a, mm256_set1_epi64x(0x4000_0000_0000_0000)), TernaryOperation.Ox1O);
				}
				else throw new IllegalInstructionException();
            }
			
			[MethodImpl(MethodImplOptions.NoInlining)]
            public static v256 BASE__EITHER__SIGN__mm256_lngamma_pd(v256 a, out v256 sign)
			{
				if (Avx2.IsAvx2Supported)
                {
					v256 ZERO = Avx.mm256_setzero_pd();

					v256 negative = mm256_cmplt_pd(a, ZERO);
					sign = mm256_set1_epi64x(1);
					a = mm256_abs_pd(a);

                    v256 r = CORE_mm256_lngamma_pd(a, out v256 cmp5);

					if (mm256_notallfalse_f256<float>(negative)) 
					{
						v256 t = mm256_lngamma_sinpi_pd(a);

						sign = Avx2.mm256_or_si256(sign, mm256_cmpgt_pd(t, ZERO));
						v256 cmp0 = mm256_cmpeq_pd(t, ZERO);
						v256 res0 = mm256_set1_pd(double.PositiveInfinity);
						v256 nadj = math.log((double4)Avx.mm256_div_pd(mm256_set1_pd(math.PI_DBL), Avx.mm256_mul_pd(mm256_abs_pd(t), a)));
						r = mm256_blendv_si256(mm256_blendv_si256(r, Avx.mm256_sub_pd(nadj, r), negative), res0, cmp0);  
					}

					sign = mm256_ternarylogic_si256(sign, negative, cmp5, TernaryOperation.OxF8);

					return r;
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.NoInlining)]
			public static v256 BASE__POSITIVE__mm256_lngamma_pd(v256 a, out v256 sign)
			{
				if (Avx2.IsAvx2Supported)
                {
					sign = mm256_set1_epi64x(1);
					
                    return CORE_mm256_lngamma_pd(a, out _);
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_lngamma_pd(v256 a, out v256 sign, bool promisePositive = false, bool promiseFinite = false)
			{
				if (Avx2.IsAvx2Supported)
                {
					v256 r = promisePositive 
						   ? BASE__POSITIVE__mm256_lngamma_pd(a, out sign)
						   : BASE__EITHER__SIGN__mm256_lngamma_pd(a, out sign);

					if (!promiseFinite)
					{
						v256 aCMP = promisePositive ? a : mm256_abs_pd(a);
						r = mm256_blendv_si256(r, Avx.mm256_mul_pd(a, a), Avx2.mm256_cmpgt_epi64(aCMP, mm256_set1_epi64x(0x7FEF_FFFF_FFFF_FFFF)));
					}
					
					return r;
                }
				else throw new IllegalInstructionException();
			}
			

			public static v128 gamma_ps(v128 a, byte elements = 4, bool promiseFinite = false, bool promiseGEzero = false)
			{
				if (BurstArchitecture.IsSIMDSupported)
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
					v128 r = mul_ps(div_ps(num, den), math.exp((float4)neg_ps(y)));
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
							sinpi = math.sin((float4)sinpi);
							sinpi = ternarylogic_si128(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = div_ps(set1_ps(-math.PI), mul_ps(sinpi, mul_ps(absX, r)));
							z = ternarylogic_si128(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v128 result = mul_ps(r, math.pow((float4)y, (float4)z));

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
					v256 r = Avx.mm256_mul_ps(Avx.mm256_div_ps(num, den), math.exp((float8)mm256_neg_ps(y)));
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
							sinpi = math.sin((float8)sinpi);
							sinpi = mm256_ternarylogic_si256(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = Avx.mm256_div_ps(mm256_set1_ps(-math.PI), Avx.mm256_mul_ps(sinpi, Avx.mm256_mul_ps(absX, r)));
							z = mm256_ternarylogic_si256(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v256 result = Avx.mm256_mul_ps(r, math.pow((float8)y, (float8)z));

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


			public static v128 gamma_pd(v128 a, bool promiseFinite = false, bool promiseGEzero = false)
			{
                if (BurstArchitecture.IsSIMDSupported)
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
					v128 r = mul_pd(div_pd(num, den), math.exp((double2)neg_pd(y)));
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
							if (BurstArchitecture.IsCMP64Supported)
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
							sinpi = math.sin((double2)sinpi);
							sinpi = ternarylogic_si128(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = div_pd(set1_pd(-math.PI_DBL), mul_pd(sinpi, mul_pd(absX, r)));
							z = ternarylogic_si128(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v128 result = mul_pd(r, math.pow((double2)y, z));

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
					v256 r = Avx.mm256_mul_pd(Avx.mm256_div_pd(num, den), math.exp((double4)mm256_neg_pd(y)));
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
							sinpi = math.sin((double4)sinpi);
							sinpi = mm256_ternarylogic_si256(ABS_MASK, q3, sinpi, TernaryOperation.OxA6);

							r = Avx.mm256_div_pd(mm256_set1_pd(-math.PI_DBL), Avx.mm256_mul_pd(sinpi, Avx.mm256_mul_pd(absX, r)));
							z = mm256_ternarylogic_si256(ABS_MASK, xNegative, z, TernaryOperation.OxA6);
						}
					}

					v256 result = Avx.mm256_mul_pd(r, math.pow((double4)y, (double4)z));

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


    unsafe public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float __sindf(double x)
		{
			double z = square(x);	
			double w = square(z);
			double r = mad(z, 2.7183114939898219e-06, -0.00019839334836096632);
			double s = z * x;
			return (float)mad(s * w, r, mad(mad(z, -0.0083333293858894632, -0.16666666641626524), s, x));
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float __cosdf(double x)
		{
			double z = square(x);
			double w = square(z);
			double r = mad(z, 0.0000243904487962774090654, -0.00138867637746099294692);

			return (float)mad(w * z, r, mad(w, 0.0416666233237390631894, mad(z, -0.499999997251031003120, 1.0)));
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static float __sinpi(float x)
		{
			x = 2 * msub(x, 0.5f, floor(x * 0.5f));
		
			int n = (int)(x * 4);
			n = (n + 1) >> 1;
			double y = mad(-0.5d, n, x);
			y *= PI_DBL;
			switch (n) 
			{
				default:
				case 0: return __sindf(y);
				case 1: return __cosdf(y);
				case 2: return -__sindf(y);
				case 3: return -__cosdf(y);
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static  double __sin(double x)
		{
			double z = x * x;
			double w = z * z;
			double r = mad(z * w, mad(1.58969099521155010221e-10, z, -2.50507602534068634195e-08), mad(mad(2.75573137070700676789e-06, z, -1.98412698298579493134e-04), z, 8.33333333332248946124e-03));
			double v = z * x;

			return mad(mad(z, r, -1.66666666666666324348e-01), v, x);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static  double __cos(double x)
		{
			double z  = x * x;
			double w  = z * z;
			double r  = mad(w * w, mad(mad(-1.13596475577881948265e-11, z, 2.08757232129817482790e-09), z, -2.75573143513906633035e-07), z * mad(mad(2.48015872894767294178e-05, z, -1.38888888888741095749e-03), z, 4.16666666666666019037e-02));
			double hz = 0.5 * z;
			w = mad(-0.5, z, 1.0);
			return mad(z, r, w + ((1.0 - w) - hz));
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static double __sinpi(double x)
		{
			x = 2 * msub(x, 0.5, floor(x * 0.5));
		
			int n = (int)(x * 4);
			n = (n + 1) >> 1;
			double y = mad(-0.5d, n, x);
			y *= PI_DBL;

			switch (n) 
			{
				default:
				case 0: return __sin(y);
				case 1: return __cos(y);
				case 2: return -__sin(y);
				case 3: return -__cos(y);
			}
		}


        /// <summary>       Returns the value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        public static float gamma(float x, Promise promises = Promise.Nothing)
        {
			uint u = *(uint*)&x;
			uint ix = u & 0x7FFF_FFFFu;
			uint sign = andnot(u, 0x7FFF_FFFFu);

			float absX = abs(x);
			float _rcp = rcp(absX);

			if (!promises.Promises(Promise.Unsafe0))
			{
				if (ix >= 0x7F80_0000)
				{
				    return x + float.PositiveInfinity;
				}
			}

			if (x == floor(x) && (sign != 0 | x == 0d))
			{
				return float.NaN;
			}
			if (ix >= 0x420C_0000)
			{
				if (sign != 0)
				{
					return negateif(0f, floor(x) * 0.5f != floor(x * 0.5f));
				}

				return x * float.MaxValue;
			}
			if (ix < (uint)(0x7F - 54) << 23)
			{
			    return _rcp;
			}

			float num;
			float den;
			float absrcp = abs(_rcp);
			if (x < 8)
			{
			    num = mad((float)F64_SNUM12, absX, (float)F64_SNUM11);
			    den = absX + (float)F64_SDEN11;
			    num = mad(num, absX, (float)F64_SNUM10);
			    den = mad(den, absX, (float)F64_SDEN10);
			    num = mad(num, absX, (float)F64_SNUM9);
			    den = mad(den, absX, (float)F64_SDEN9);
			    num = mad(num, absX, (float)F64_SNUM8);
			    den = mad(den, absX, (float)F64_SDEN8);
			    num = mad(num, absX, (float)F64_SNUM7);
			    den = mad(den, absX, (float)F64_SDEN7);
			    num = mad(num, absX, (float)F64_SNUM6);
			    den = mad(den, absX, (float)F64_SDEN6);
			    num = mad(num, absX, (float)F64_SNUM5);
			    den = mad(den, absX, (float)F64_SDEN5);
			    num = mad(num, absX, (float)F64_SNUM4);
			    den = mad(den, absX, (float)F64_SDEN4);
			    num = mad(num, absX, (float)F64_SNUM3);
			    den = mad(den, absX, (float)F64_SDEN3);
			    num = mad(num, absX, (float)F64_SNUM2);
			    den = mad(den, absX, (float)F64_SDEN2);
			    num = mad(num, absX, (float)F64_SNUM1);
			    den = mad(den, absX, (float)F64_SDEN1);
			    num = mad(num, absX, (float)F64_SNUM0);
			    den *= absX;
			}
			else
			{
			    num = mad((float)F64_SNUM0, absrcp, (float)F64_SNUM1);
			    den = (float)F64_SDEN1;
			    num = mad(num, absrcp, (float)F64_SNUM2);
			    den = mad(den, absrcp, (float)F64_SDEN2);
			    num = mad(num, absrcp, (float)F64_SNUM3);
			    den = mad(den, absrcp, (float)F64_SDEN3);
			    num = mad(num, absrcp, (float)F64_SNUM4);
			    den = mad(den, absrcp, (float)F64_SDEN4);
			    num = mad(num, absrcp, (float)F64_SNUM5);
			    den = mad(den, absrcp, (float)F64_SDEN5);
			    num = mad(num, absrcp, (float)F64_SNUM6);
			    den = mad(den, absrcp, (float)F64_SDEN6);
			    num = mad(num, absrcp, (float)F64_SNUM7);
			    den = mad(den, absrcp, (float)F64_SDEN7);
			    num = mad(num, absrcp, (float)F64_SNUM8);
			    den = mad(den, absrcp, (float)F64_SDEN8);
			    num = mad(num, absrcp, (float)F64_SNUM9);
			    den = mad(den, absrcp, (float)F64_SDEN9);
			    num = mad(num, absrcp, (float)F64_SNUM10);
			    den = mad(den, absrcp, (float)F64_SDEN10);
			    num = mad(num, absrcp, (float)F64_SNUM11);
			    den = mad(den, absrcp, (float)F64_SDEN11);
			    num = mad(num, absrcp, (float)F64_SNUM12);
			    den = mad(den, absrcp, 1f);
			}

			float y = absX + (float)GM_HALF;
			float z = absX - 0.5f;
			float r = (num / den) * exp(-y);

			if (!promises.Promises(Promise.ZeroOrGreater))
			{
				if (x < 0)
				{
				    float sinpi = absX * 0.5f;
				    sinpi -= floor(sinpi);
					sinpi += sinpi;

				    int n = ((int)(sinpi * 4) + 1) >> 1;
				    sinpi -= n * 0.5f;
				    sinpi *= PI;

					sinpi = negateif(sin(negateif(sinpi + ((n == 1 | n == 3) ? PI : 0f), n == 2)), n == 3);

				    r = -PI / (sinpi * (absX * r));
				    z = -z;
				}
			}

			return r * pow(y, z);
        }

        /// <summary>       Returns the componentwise value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 gamma(float2 x, Promise promises = Promise.Nothing)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.gamma_ps(x, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
			else
			{
				return new float2(gamma(x.x, promises), gamma(x.y, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 gamma(float3 x, Promise promises = Promise.Nothing)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.gamma_ps(x, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
			else
			{
				return new float3(gamma(x.x, promises), gamma(x.y, promises), gamma(x.z, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float4 gamma(float4 x, Promise promises = Promise.Nothing)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.gamma_ps(x, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
			else
			{
				return new float4(gamma(x.x, promises), gamma(x.y, promises), gamma(x.z, promises), gamma(x.w, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
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


		/// <summary>       Returns the value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
		public static double gamma(double x, Promise promises = Promise.Nothing)
		{
			ulong u = *(ulong*)&x;
			ulong ix = u & 0x7FFF_FFFF_FFFF_FFFFul;
			ulong sign = andnot(u, 0x7FFF_FFFF_FFFF_FFFFul);

			double absX = abs(x);
			double _rcp = rcp(absX);

			if (!promises.Promises(Promise.Unsafe0))
			{
				if (ix >= 0x7FF0_0000_0000_0000)
				{
				    return x + double.PositiveInfinity;
				}
			}

			if (x == floor(x) && (sign != 0 | x == 0d))
			{
				return double.NaN;
			}
			if (ix >= 0x4067_0000_0000_0000)
			{
				if (sign != 0)
				{
					return negateif(0d, floor(x) * 0.5d != floor(x * 0.5d));
				}

				return x * double.MaxValue;
			}
			if (ix < (ulong)(0x3FF - 54) << 52)
			{
			    return _rcp;
			}

			double num;
			double den;
			double absrcp = abs(_rcp);
			if (x < 8)
			{
			    num = mad(F64_SNUM12, absX, F64_SNUM11);
			    den = absX + F64_SDEN11;
			    num = mad(num, absX, F64_SNUM10);
			    den = mad(den, absX, F64_SDEN10);
			    num = mad(num, absX, F64_SNUM9);
			    den = mad(den, absX, F64_SDEN9);
			    num = mad(num, absX, F64_SNUM8);
			    den = mad(den, absX, F64_SDEN8);
			    num = mad(num, absX, F64_SNUM7);
			    den = mad(den, absX, F64_SDEN7);
			    num = mad(num, absX, F64_SNUM6);
			    den = mad(den, absX, F64_SDEN6);
			    num = mad(num, absX, F64_SNUM5);
			    den = mad(den, absX, F64_SDEN5);
			    num = mad(num, absX, F64_SNUM4);
			    den = mad(den, absX, F64_SDEN4);
			    num = mad(num, absX, F64_SNUM3);
			    den = mad(den, absX, F64_SDEN3);
			    num = mad(num, absX, F64_SNUM2);
			    den = mad(den, absX, F64_SDEN2);
			    num = mad(num, absX, F64_SNUM1);
			    den = mad(den, absX, F64_SDEN1);
			    num = mad(num, absX, F64_SNUM0);
			    den *= absX;
			}
			else
			{
			    num = mad(F64_SNUM0, absrcp, F64_SNUM1);
			    den = F64_SDEN1;
			    num = mad(num, absrcp, F64_SNUM2);
			    den = mad(den, absrcp, F64_SDEN2);
			    num = mad(num, absrcp, F64_SNUM3);
			    den = mad(den, absrcp, F64_SDEN3);
			    num = mad(num, absrcp, F64_SNUM4);
			    den = mad(den, absrcp, F64_SDEN4);
			    num = mad(num, absrcp, F64_SNUM5);
			    den = mad(den, absrcp, F64_SDEN5);
			    num = mad(num, absrcp, F64_SNUM6);
			    den = mad(den, absrcp, F64_SDEN6);
			    num = mad(num, absrcp, F64_SNUM7);
			    den = mad(den, absrcp, F64_SDEN7);
			    num = mad(num, absrcp, F64_SNUM8);
			    den = mad(den, absrcp, F64_SDEN8);
			    num = mad(num, absrcp, F64_SNUM9);
			    den = mad(den, absrcp, F64_SDEN9);
			    num = mad(num, absrcp, F64_SNUM10);
			    den = mad(den, absrcp, F64_SDEN10);
			    num = mad(num, absrcp, F64_SNUM11);
			    den = mad(den, absrcp, F64_SDEN11);
			    num = mad(num, absrcp, F64_SNUM12);
			    den = mad(den, absrcp, 1d);
			}

			double y = absX + GM_HALF;
			double z = absX - 0.5d;
			double r = (num / den) * exp(-y);

			if (!promises.Promises(Promise.ZeroOrGreater))
			{
				if (x < 0)
				{
				    double sinpi = absX * 0.5d;
				    sinpi -= floor(sinpi);
					sinpi += sinpi;

				    int n = ((int)(sinpi * 4) + 1) >> 1;
				    sinpi -= n * 0.5d;
				    sinpi *= PI_DBL;

					sinpi = negateif(sin(negateif(sinpi + ((n == 1 | n == 3) ? PI_DBL : 0d), n == 2)), n == 3);

				    r = -PI_DBL / (sinpi * (absX * r));
				    z = -z;
				}
			}

			return r * pow(y, z);
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double2 gamma(double2 x, Promise promises = Promise.Nothing)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.gamma_pd(x, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
			else
			{
				return new double2(gamma(x.x, promises), gamma(x.y, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double3 gamma(double3 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return Xse.mm256_gamma_pd(x, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
			else
			{
				return new double3(gamma(x.xy, promises), gamma(x.z, promises));
			}
		}

        /// <summary>       Returns the componentwise value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static double4 gamma(double4 x, Promise promises = Promise.Nothing)
		{
            if (Avx.IsAvxSupported)
            {
				return Xse.mm256_gamma_pd(x, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
			else
			{
				return new double4(gamma(x.xy, promises), gamma(x.zw, promises));
			}
		}
        
		
        /// <summary>       Returns the value of the gamma function Γ(<paramref name="x"/>) = (<paramref name="x"/> - 1)!.		</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple gamma(quadruple x)
        {
            quadruple.ConstChecked ret;
        
            if (abs(x) == 0)
            {
                return copysign(quadruple.PositiveInfinity, x);
            }
            if ((((long)x.value.hi64 < 0) 
               & (x.value.hi64 < 0xFFFF_0000_0000_0000) 
               & isint(x))
              | (x.value.hi64 & quadruple.SIGNALING_EXPONENT.hi64) == quadruple.SIGNALING_EXPONENT.hi64)
            {
                return quadruple.NaN;
            }
        
            if (x >= 1756)
            {
                return quadruple.PositiveInfinity;
            }
            else
            {
                bool negTest = false;
                if (x > 0)
        	    {
        	        ret = gammal_positive(x, out int exp2_adj);
        	        ret = scalbn(ret, exp2_adj);
        	    }
                else if (x >= new quadruple(0, 0xBF8D_0000_0000_0000))
        	    {
        	        ret = rcp(x);
        	    }
                else
        	    {
                    negTest = true;
        	        if (x <= -1775)
                    {
                        ret = 0;
                    }
        	        else
        	        {
	                    quadruple tx = trunc(x);
	                    quadruple frac = tx - x;
        	            if (frac > 0.5)
                        {
                            frac = 1 - frac;
                        }
        	    	    
        	            quadruple sinpix = (frac <= 0.25
        	    	    		         ? sin(PI_QUAD * frac)
        	    	    		         : cos(PI_QUAD * (0.5 - frac)));

        	            ret = PI_QUAD / (-x * sinpix * gammal_positive(-x, out int exp2_adj));
        	            ret = scalbn(ret, -exp2_adj);
        	        }
        	    }

                if (isinf(ret) 
                  & x != 0)
                {
                    return copysign(quadruple.PositiveInfinity, negateif(x, negTest & ((int)x & 1) == 0));
                }
                else if (ret == 0)
                {
                    return copysign(0, negateif(x, negTest & ((int)x & 1) == 0));
                }
                else
                {
                    return negateif(ret, negTest & ((int)x & 1) == 0);
                }
            }
        }

		
        /// <summary>       Returns the value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The sign of Γ(<paramref name="x"/>) is returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lngamma(float x, out int sign, Promise promises = Promise.Nothing)
		{
			uint u = asuint(x);
			float nadj = Uninitialized<float>.Create();

			sign = 1;
			bool negative = tobool(u >> 31);
			uint ix = promises.Promises(Promise.Positive) ? u : u & 0x7FFF_FFFF;
			if (!promises.Promises(Promise.Unsafe0))
			{
				if (ix >= 0x7F80_0000)
				{
					return x * x;
				}
			}
			if (ix < 0x3500_0000) 
			{
				if (!promises.Promises(Promise.Positive))
				{
					if (negative) 
					{
						sign = -1;
						x = -x;
					}
				}

				return -log(x);
			}
			
			if (!promises.Promises(Promise.Positive))
			{
				if (negative) 
				{
					x = -x;
					float t = __sinpi(x);
					if (t == 0.0f)
					{
						return float.PositiveInfinity;
					}
					if (t > 0.0f)
					{
						sign = -1;
					}
					else
					{
						t = -t;
					}
					nadj = log(PI / (t * x));
				}
			}

			float r;

			if ((ix == 0x3F80_0000)
			  | (ix == 0x4000_0000))
			{
				r = 0;
			}
			else if (ix < 0x4000_0000) 
			{
				int i;
				float y;
				if (ix <= 0x3F66_6666) 
				{
					r = -log(x);
					if (ix >= 0x3F3B_4A20) 
					{
						y = 1.0f - x;
						i = 0;
					} 
					else if (ix >= 0x3E6D_3308) 
					{
						y = x - (tc - 1.0f);
						i = 1;
					} 
					else 
					{
						y = x;
						i = 2;
					}
				} 
				else 
				{
					r = 0.0f;
					if (ix >= 0x3FDD_A618) 
					{
						y = 2.0f - x;
						i = 0;
					} 
					else if (ix >= 0x3F9D_A620) 
					{
						y = x - tc;
						i = 1;
					} 
					else 
					{
						y = x - 1.0f;
						i = 2;
					}
				}

				switch(i)
				{
					case 0:
					{
						float z = square(y);
						float p1 = mad(mad(mad(mad(mad(a10, z, a8), z, a6), z, a4), z, a2), z, a0);
						float p2 = z * mad(mad(mad(mad(mad(a11, z, a9), z, a7), z, a5), z, a3), z, a1);
						float p = mad(y, p1, p2);
						r += mad(-0.5f, y, p);
						break;
					}
					case 1:
					{
						float z = square(y);
						float w = z * y;
						float p1 = mad(mad(mad(mad(t12, w, t9 ), w, t6), w, t3), w, t0);
						float p2 = mad(mad(mad(mad(t13, w, t10), w, t7), w, t4), w, t1);
						float p3 = mad(mad(mad(mad(t14, w, t11), w, t8), w, t5), w, t2);
						float p = msub(z, p1, mad(mad(p3, y, p2), -w, tt));
						r += tf + p;
						break;
					}
					case 2:
					{
						float p1 = y * mad(mad(mad(mad(mad(u5, y, u4), y, u3), y, u2), y, u1), y, u0);
						float p2 = mad(mad(mad(mad(mad(v5, y, v4), y, v3), y, v2), y, v1), y, 1.0f);
						r += mad(-0.5f, y, p1 / p2);
						break;
					}
				}
			} 
			else if (ix < 0x4100_0000) 
			{
				float y = frac(x);
				float p = y * mad(mad(mad(mad(mad(mad(s6, y, s5), y, s4), y, s3), y, s2), y, s1), y, s0);
				float q = mad(mad(mad(mad(mad(mad(r6, y, r5), y, r4), y, r3), y, r2), y, r1), y, 1.0f);
				r = mad(0.5f, y, p / q);
				float z = 1.0f;
				switch ((int)x) 
				{
					case 7: z  = y + 6.0f;  goto case 6;
					case 6: z *= y + 5.0f;  goto case 5;
					case 5: z *= y + 4.0f;  goto case 4;
					case 4: z *= y + 3.0f;  goto case 3;
					case 3:
					{
						z *= y + 2.0f;
						r += log(z);
						break;
					}
				}
			} 
			else if (ix < 0x5C80_0000) 
			{
				float z = rcp(x);
				float y = square(z);
				float w = mad(mad(mad(mad(mad(mad(y, w6, w5), y, w4), y, w3), y, w2), y, w1), z, w0);
				r = mad(x - 0.5f, log(x) - 1.0f, w);
			} 
			else
			{
				r =  x * (log(x) - 1.0f);
			}

			if (negative)
			{
				r = nadj - r;
			}

			return r;
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The signs of Γ(<paramref name="x"/>) components are returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 lngamma(float2 x, out int2 sign, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				v128 f = Xse.lngamma_ps(x, out v128 __sign, elements: 2, promiseFinite: promises.Promises(Promise.Unsafe0), promisePositive: promises.Promises(Promise.Positive));

				sign = __sign;
				return f;
			}
			else
			{
				sign = Uninitialized<int2>.Create();

				return new float2(lngamma(x.x, out sign.x, promises), lngamma(x.y, out sign.y, promises));
			}
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The signs of Γ(<paramref name="x"/>) components are returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 lngamma(float3 x, out int3 sign, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				v128 f = Xse.lngamma_ps(x, out v128 __sign, elements: 3, promiseFinite: promises.Promises(Promise.Unsafe0), promisePositive: promises.Promises(Promise.Positive));

				sign = __sign;
				return f;
			}
			else
			{
				sign = Uninitialized<int3>.Create();

				return new float3(lngamma(x.x, out sign.x, promises), lngamma(x.y, out sign.y, promises), lngamma(x.z, out sign.z, promises));
			}
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The signs of Γ(<paramref name="x"/>) components are returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 lngamma(float4 x, out int4 sign, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				v128 f = Xse.lngamma_ps(x, out v128 __sign, elements: 4, promiseFinite: promises.Promises(Promise.Unsafe0), promisePositive: promises.Promises(Promise.Positive));

				sign = __sign;
				return f;
			}
			else
			{
				sign = Uninitialized<int4>.Create();

				return new float4(lngamma(x.x, out sign.x, promises), lngamma(x.y, out sign.y, promises), lngamma(x.z, out sign.z, promises), lngamma(x.w, out sign.w, promises));
			}
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The signs of Γ(<paramref name="x"/>) components are returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lngamma(float8 x, out int8 sign, Promise promises = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 f = Xse.mm256_lngamma_ps(x, out v256 __sign, promiseFinite: promises.Promises(Promise.Unsafe0), promisePositive: promises.Promises(Promise.Positive));

				sign = __sign;
				return f;
			}
			else
			{
				float4 lo = lngamma(x.v4_0, out int4 signLo, promises);
				float4 hi = lngamma(x.v4_4, out int4 signHi, promises);

				sign = new int8(signLo, signHi);
				return new float8(lo, hi);
			}
		}
		
        /// <summary>       Returns the value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lngamma(float x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 lngamma(float2 x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 lngamma(float3 x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 lngamma(float4 x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> and <see cref="float.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 lngamma(float8 x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}

		
        /// <summary>       Returns the value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The sign of Γ(<paramref name="x"/>) is returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lngamma(double x, out long sign, Promise promises = Promise.Nothing)
		{
			ulong u = asulong(x);
			double nadj = Uninitialized<double>.Create();

			sign = 1;
			bool negative = tobool(u >> 63);
			ulong ix = promises.Promises(Promise.Positive) ? u : u & 0x7FFF_FFFF_FFFF_FFFF;
			if (!promises.Promises(Promise.Unsafe0))
			{
				if (ix >= 0x7FF0_0000_0000_0000)
				{
					return x * x;
				}
			}
			if (ix < (0x3FFul - 70) << 52) 
			{
				if (!promises.Promises(Promise.Positive))
				{
					if (negative) 
					{
						sign = -1;
						x = -x;
					}
				}

				return -log(x);
			}
			
			if (!promises.Promises(Promise.Positive))
			{
				if (negative) 
				{
					x = -x;
					double t = __sinpi(x);
					if (t == 0.0)
					{
						return double.PositiveInfinity;
					}
					if (t > 0.0)
					{
						sign = -1;
					}
					else
					{
						t = -t;
					}
					nadj = log(PI_DBL / (t * x));
				}
			}

			double r;
			if ((ix == 0x3FF0_0000_0000_0000)
			  | (ix == 0x4000_0000_0000_0000))
			{	
				r = 0;
			}
			else if (ix < 0x4000_0000_0000_0000) 
			{
				int i;
				double y;
				if (ix <= 0x3FEC_CCCC_0000_0000) 
				{
					r = -log(x);
					if (ix >= 0x3FE7_6944_0000_0000) 
					{
						y = 1.0 - x;
						i = 0;
					} 
					else if (ix >= 0x3FCD_A661_0000_0000) 
					{
						y = x - (tc_DBL - 1.0);
						i = 1;
					} 
					else 
					{
						y = x;
						i = 2;
					}
				} 
				else 
				{
					r = 0.0;
					if (ix >= 0x3FFB_B4C3_0000_0000) 
					{
						y = 2.0 - x;
						i = 0;
					} 
					else if (ix >= 0x3FF3_B4C4_0000_0000) 
					{
						y = x - tc_DBL;
						i = 1;
					} 
					else 
					{
						y = x - 1.0;
						i = 2;
					}
				}

				switch(i)
				{
					case 0:
					{
						double z = square(y);
						double p1 = mad(mad(mad(mad(mad(a10_DBL, z, a8_DBL), z, a6_DBL), z, a4_DBL), z, a2_DBL), z, a0_DBL);
						double p2 = z * mad(mad(mad(mad(mad(a11_DBL, z, a9_DBL), z, a7_DBL), z, a5_DBL), z, a3_DBL), z, a1_DBL);
						double p = mad(y, p1, p2);
						r += mad(-0.5, y, p);
						break;
					}
					case 1:
					{
						double z = square(y);
						double w = z * y;
						double p1 = mad(mad(mad(mad(t12_DBL, w,  t9_DBL), w, t6_DBL), w, t3_DBL), w, t0_DBL);
						double p2 = mad(mad(mad(mad(t13_DBL, w, t10_DBL), w, t7_DBL), w, t4_DBL), w, t1_DBL);
						double p3 = mad(mad(mad(mad(t14_DBL, w, t11_DBL), w, t8_DBL), w, t5_DBL), w, t2_DBL);
						double p = msub(z, p1, mad(mad(p3, y, p2), -w, tt_DBL));
						r += tf_DBL + p;
						break;
					}
					case 2:
					{
						double p1 = y * mad(mad(mad(mad(mad(u5_DBL, y, u4_DBL), y, u3_DBL), y, u2_DBL), y, u1_DBL), y, u0_DBL);
						double p2 = mad(mad(mad(mad(mad(v5_DBL, y, v4_DBL), y, v3_DBL), y, v2_DBL), y, v1_DBL), y, 1.0);
						r += mad(-0.5, y, p1 / p2);
						break;
					}
				}
			} 
			else if (ix < 0x4020_0000_0000_0000) 
			{
				double y = frac(x);
				double p = y * mad(mad(mad(mad(mad(mad(s6_DBL, y, s5_DBL), y, s4_DBL), y, s3_DBL), y, s2_DBL), y, s1_DBL), y, s0_DBL);
				double q = mad(mad(mad(mad(mad(mad(r6_DBL, y, r5_DBL), y, r4_DBL), y, r3_DBL), y, r2_DBL), y, r1_DBL), y, 1.0);
				r = mad(0.5, y, p / q);
				double z = 1.0;
				switch ((int)x) 
				{
					case 7: z  = y + 6.0;  goto case 6;
					case 6: z *= y + 5.0;  goto case 5;
					case 5: z *= y + 4.0;  goto case 4;
					case 4: z *= y + 3.0;  goto case 3;
					case 3:
					{
						z *= y + 2.0;
						r += log(z);
						break;
					}
				}
			} 
			else if (ix < 0x4390_0000_0000_0000) 
			{
				double z = rcp(x);
				double y = square(z);
				double w = mad(mad(mad(mad(mad(mad(y, w6_DBL, w5_DBL), y, w4_DBL), y, w3_DBL), y, w2_DBL), y, w1_DBL), z, w0_DBL);
				r = mad(x - 0.5, log(x) - 1.0, w);
			} 
			else
			{
				r =  x * (log(x) - 1.0);
			}

			if (negative)
			{
				r = nadj - r;
			}

			return r;
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The signs of Γ(<paramref name="x"/>) components are returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 lngamma(double2 x, out long2 sign, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				v128 f = Xse.lngamma_pd(x, out v128 __sign, promiseFinite: promises.Promises(Promise.Unsafe0), promisePositive: promises.Promises(Promise.Positive));

				sign = __sign;
				return f;
			}
			else
			{
				sign = Uninitialized<long2>.Create();

				return new double2(lngamma(x.x, out sign.x, promises), lngamma(x.y, out sign.y, promises));
			}
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The signs of Γ(<paramref name="x"/>) components are returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 lngamma(double3 x, out long3 sign, Promise promises = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 f = Xse.mm256_lngamma_pd(x, out v256 __sign, promiseFinite: promises.Promises(Promise.Unsafe0), promisePositive: promises.Promises(Promise.Positive));

				sign = __sign;
				return f;
			}
			else
			{
				double2 lo = lngamma(x.xy, out long2 signLo, promises);
				double  hi = lngamma(x.z,  out long  signHi, promises);

				sign = new long3(signLo, signHi);
				return new double3(lo, hi);
			}
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The signs of Γ(<paramref name="x"/>) components are returned via <paramref name="sign"/> as an <see langword="out"/> parameter.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 lngamma(double4 x, out long4 sign, Promise promises = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				v256 f = Xse.mm256_lngamma_pd(x, out v256 __sign, promiseFinite: promises.Promises(Promise.Unsafe0), promisePositive: promises.Promises(Promise.Positive));

				sign = __sign;
				return f;
			}
			else
			{
				double2 lo = lngamma(x.xy, out long2 signLo, promises);
				double2 hi = lngamma(x.zw, out long2 signHi, promises);

				sign = new long4(signLo, signHi);
				return new double4(lo, hi);
			}
		}
		
        /// <summary>       Returns the value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double lngamma(double x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 lngamma(double2 x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 lngamma(double3 x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.																   </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> and <see cref="double.NaN"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 lngamma(double4 x, Promise promises = Promise.Nothing)
		{
			return lngamma(x, out _, promises);
		}

		
        /// <summary>       Returns the value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|. The sign of Γ(<paramref name="x"/>) is returned via <paramref name="sign"/> as an <see langword="out"/> parameter.		</summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple lngamma(quadruple x, out int sign)
        {
            return base_lngamma(x, out sign);
        }
		
        /// <summary>       Returns the componentwise value of the natural logarithm of the absolute value of the gamma function ln|Γ(<paramref name="x"/>)| = ln|<paramref name="x"/> - 1)!|.		</summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple lngamma(quadruple x)
        {
            return base_lngamma(x, out _);
        }

		

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple gamma_product(quadruple x, quadruple x_eps, int n, out quadruple eps)
        {
            quadruple ret = x;
            eps = x_eps / x;
            for (int i = 1; i < n; i++)
            {
                eps += x_eps / (x + i);
                quadruple hi = ret * (x + i);
                quadruple lo = quadruple.mulAddF128(ret, x + i, hi, false, true);
                ret = hi;
                eps += lo / ret;
            }
            return ret;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple gamma_neval(quadruple x, int p, int n)
        {
            quadruple y;
        
            int idx = n;
            y = LUT.QUADRUPLE.gamma_NEVAL(p + idx--);
            do
            {
                y = quadruple.fmadd(y, x, LUT.QUADRUPLE.gamma_NEVAL(p + idx--));
            }
            while (--n > 0);
            return y;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple gamma_deval(quadruple x, int p, int n)
        {
            quadruple y;
        
            int idx = n;
            y = x + LUT.QUADRUPLE.gamma_DEVAL(p + idx--);
            do
            {
                y = quadruple.fmadd(y, x, LUT.QUADRUPLE.gamma_DEVAL(p + idx--));
            }
            while (--n > 0);
            return y;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void lg_sincospi(quadruple x, out quadruple s, out quadruple c)
        {
            if (x <= 0.25)
            {
                sincos(PI_QUAD * x, out s, out c);
            }
            else
            {
                sincos(PI_QUAD * (0.5 - x), out c, out s);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple lg_sinpi(quadruple x)
        {
            if (x <= 0.25)
            {
                return sin(PI_QUAD * x);
            }
            else
            {
                return cos(PI_QUAD * (0.5 - x));
            }
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple lgamma_product(quadruple t, quadruple x, quadruple x_eps, int n)
        {
            quadruple ret = 0, ret_eps = 0;
            for (int i = 0; i < n; i++)
            {
                quadruple xi = x + i;
                quadruple quot = t / xi;
                quadruple mhi = quot * xi;
                quadruple mlo = quadruple.mulAddF128(quot, xi, mhi, false, true);
                quadruple quot_lo = (t - mhi - mlo) / xi - t * x_eps / (xi * xi);
                quadruple rhi = ret * quot;
                quadruple rlo = quadruple.mulAddF128(ret, quot, rhi, false, true);
                quadruple rpq = ret + quot;
                quadruple rpq_eps = (ret - rpq) + quot;
                quadruple nret = rpq + rhi;
                quadruple nret_eps = (rpq - nret) + rhi;
                ret_eps += quadruple.fmadd(ret_eps, quot, rpq_eps + nret_eps + rlo) + quot_lo + quot_lo * (ret + ret_eps);
                ret = nret;
            }
            return ret + ret_eps;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple lgamma_neg(quadruple x)
        {
            quadruple e_hi = new quadruple(0x9535_5FB8_AC40_4E7A, 0x4000_5BF0_A8B1_4576);
            quadruple e_lo = new quadruple(0x7169_B4AD_4F09_B209, 0x3F8E_E78E_C5CE_2C1E);
            
            int i = floortoint(-2 * x);
            if (((i & 1) == 0 )
              & (i == -2 * x))
            {
                return quadruple.PositiveInfinity;
            }
              
            quadruple xn = ((i & 1) == 0 ? -i / 2 : (-i - 1) / 2);
            i -= 4;
        
            quadruple x0_hi = LUT.QUADRUPLE.gamma_lgamma_zeros(2 * i);
            quadruple x0_lo = LUT.QUADRUPLE.gamma_lgamma_zeros(2 * i + 1);
            quadruple xdiff = x - x0_hi - x0_lo;
        
            if (i < 2)
            {
                int j = floortoint(-8 * x) - 16;
                quadruple x_adj = quadruple.fnmadd(-33 - 2 * j, 0.0625, x);

                int deg = LUT.QUADRUPLE.gamma_poly_deg(j);
                int end = LUT.QUADRUPLE.gamma_poly_end(j);
                quadruple g = LUT.QUADRUPLE.gamma_poly_coeff(end);

                for (j = 1; j <= deg; j++)
                {
                    g = quadruple.fmadd(g, x_adj, LUT.QUADRUPLE.gamma_poly_coeff(end - j));
                }
        	    
                return log1p(g * xdiff / (x - xn));
            }
        
            quadruple x_idiff = abs(xn - x), x0_idiff = abs(xn - x0_hi - x0_lo);
            quadruple log_sinpi_ratio;
            if (x0_idiff < x_idiff * 0.5)
            {
                log_sinpi_ratio = log(lg_sinpi(x0_idiff) / lg_sinpi(x_idiff));
            }
            else
            {
                quadruple x0diff2 = negateif(xdiff, (i & 1) == 0) * 0.5;
                lg_sincospi(x0diff2, out quadruple sx0d2, out quadruple cx0d2);
                lg_sincospi(x_idiff, out quadruple q, out quadruple p);
                log_sinpi_ratio = log1p(2 * sx0d2 * quadruple.fmsub(cx0d2, p / q, sx0d2));
            }
        
            quadruple log_gamma_ratio;
            quadruple y0 = 1 - x0_hi;
            quadruple y0_eps = -x0_hi + (1 - y0) - x0_lo;
            quadruple y = 1 - x;
            quadruple y_eps = -x + (1 - y);
            quadruple log_gamma_adj = 0;
            if (i < 20)
            {
                int n_up = (21 - i) / 2;
                quadruple ny0 = y0 + n_up;
                quadruple ny0_eps = y0 - (ny0 - n_up) + y0_eps;
                y0 = ny0;
                y0_eps = ny0_eps;
                quadruple ny = y + n_up;
                quadruple ny_eps = y - (ny - n_up) + y_eps;
                y = ny;
                y_eps = ny_eps;
                quadruple prodm1 = lgamma_product(xdiff, y - n_up, y_eps, n_up);
                log_gamma_adj = -log1p(prodm1);
            }
            quadruple log_gamma_high = (xdiff * log1p((y0 - e_hi - e_lo + y0_eps) / e_hi) + (y - 0.5 + y_eps) * log1p(xdiff / y) + log_gamma_adj);
            quadruple y0r = rcp(y0);
            quadruple yr = rcp(y);
            quadruple y0r2 = square(y0r);
            quadruple yr2 = square(yr);
            quadruple rdiff = -xdiff / (y * y0);
            quadruple* bterm = stackalloc quadruple[27];
            quadruple dlast = rdiff;
            quadruple elast = rdiff * yr * (yr + y0r);
            bterm[0] = dlast * LUT.QUADRUPLE.gamma_lgamma_coeff(0);
            for (int j = 1; j < 27; j++)
            {
                quadruple dnext = quadruple.fmadd(dlast, y0r2, elast);
                quadruple enext = elast * yr2;
                bterm[j] = dnext * LUT.QUADRUPLE.gamma_lgamma_coeff(j);
                dlast = dnext;
                elast = enext;
            }
            quadruple log_gamma_low = 0;
            for (int j = 0; j < 27; j++)
            {
                log_gamma_low += bterm[27 - 1 - j];
            }

            log_gamma_ratio = log_gamma_high + log_gamma_low;
            return log_sinpi_ratio + log_gamma_ratio;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quadruple base_lngamma(quadruple x, out int sign)
        {
            quadruple p, q, w, z;
        
            sign = 1;
        
            if (x == 0)
            {
                sign |= (int)(x.value.hi64 >> 63);
            }
        
            if (x < 0)
            {
                if (x < -2 & x > -50)
                {
        	        return lgamma_neg(x);
                }
                q = -x;
                p = floor(q);
                if (isint(x))
                {
                    return rcp(abs(p - p));
                }
        	    
                quadruple halfp = p * 0.5;
        	    sign = negateif(1, isint(halfp));
                if (q < new quadruple(0, 0x3F87_0000_0000_0000))
                {
                    return -log(q);
                }
        	    
                z = q - p;
                if (z > 0.5)
        	    {
        	        p += 1;
        	        z = p - q;
        	    }
                z = q * sin(PI_QUAD * z);
                w = lngamma(q);
                z = log(PI_QUAD / z) - w;
                return z;
            }
        
            if (x < 13.5)
            {
                p = 0;
                switch (floortoint(x + 0.5))
                {
                    case 0:
                    {
                        if (x < new quadruple(0, 0x3F87_0000_0000_0000))
                        {
                            return -log(x);
                        }
                        else if (x <= 0.125)
                        {
                            p = x * gamma_neval(x, LUT.QUADRUPLE.gamma_RN1, LUT.QUADRUPLE.gamma_NRN1) / gamma_deval(x, LUT.QUADRUPLE.gamma_RD1, LUT.QUADRUPLE.gamma_NRD1);
                        }
                        else if (x <= 0.375)
                        {
                            z = x - 0.25;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R25, LUT.QUADRUPLE.gamma_NRN1R25) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R25, LUT.QUADRUPLE.gamma_NRD1R25);
                            p += LUT.QUADRUPLE.gamma_lgam1r25b;
                            p += LUT.QUADRUPLE.gamma_lgam1r25a;
                        }
                        else if (x <= 0.625)
                        {
                            z = x + (1 - LUT.QUADRUPLE.gamma_x0a);
                            z -= LUT.QUADRUPLE.gamma_x0b;
                            p = gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R5, LUT.QUADRUPLE.gamma_NRN1R5) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R5, LUT.QUADRUPLE.gamma_NRD1R5);
                            p *= z;
                            p = quadruple.fmadd(p, z, LUT.QUADRUPLE.gamma_y0b);
                            p += LUT.QUADRUPLE.gamma_y0a;
                        }
                        else if (x <= 0.875)
                        {
                            z = x - 0.75;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R75, LUT.QUADRUPLE.gamma_NRN1R75) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R75, LUT.QUADRUPLE.gamma_NRD1R75);
                            p += LUT.QUADRUPLE.gamma_lgam1r75b;
                            p += LUT.QUADRUPLE.gamma_lgam1r75a;
                        }
                        else
                        {
                            z = x - 1;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN2, LUT.QUADRUPLE.gamma_NRN2) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD2, LUT.QUADRUPLE.gamma_NRD2);
                        }
                        p -= log(x);
                        break;
                    }
                    case 1:
                    {
                        if (x < 0.875)
                        {
                            if (x <= 0.625)
                    	    {
                    	        z = x + (1 - LUT.QUADRUPLE.gamma_x0a);
                    	        z -= LUT.QUADRUPLE.gamma_x0b;
                    	        p = gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R5, LUT.QUADRUPLE.gamma_NRN1R5) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R5, LUT.QUADRUPLE.gamma_NRD1R5);
                                p *= z;
                                p = quadruple.fmadd(p, z, LUT.QUADRUPLE.gamma_y0b);
                                p += LUT.QUADRUPLE.gamma_y0a;
                    	    }
                            else if (x <= 0.875)
                    	    {
                    	        z = x - 0.75;
                    	        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R75, LUT.QUADRUPLE.gamma_NRN1R75) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R75, LUT.QUADRUPLE.gamma_NRD1R75);
                    	        p += LUT.QUADRUPLE.gamma_lgam1r75b;
                    	        p += LUT.QUADRUPLE.gamma_lgam1r75a;
                    	    }
                            else
                    	    {
                    	        z = x - 1;
                    	        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN2, LUT.QUADRUPLE.gamma_NRN2) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD2, LUT.QUADRUPLE.gamma_NRD2);
                    	    }

                            p -= log(x);
                        }
                        else if (x < 1)
                        {
                            z = x - 1;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RNR9, LUT.QUADRUPLE.gamma_NRNR9) / gamma_deval(z, LUT.QUADRUPLE.gamma_RDR9, LUT.QUADRUPLE.gamma_NRDR9);
                        }
                        else if (x == 1)
                        {
                            p = 0;
                        }
                        else if (x <= 1.125)
                        {
                            z = x - 1;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN1, LUT.QUADRUPLE.gamma_NRN1) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1, LUT.QUADRUPLE.gamma_NRD1);
                        }
                        else if (x <= 1.375)
                        {
                            z = x - 1.25;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R25, LUT.QUADRUPLE.gamma_NRN1R25) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R25, LUT.QUADRUPLE.gamma_NRD1R25);
                            p += LUT.QUADRUPLE.gamma_lgam1r25b;
                            p += LUT.QUADRUPLE.gamma_lgam1r25a;
                        }
                        else
                        {
                            z = x - LUT.QUADRUPLE.gamma_x0a;
                            z -= LUT.QUADRUPLE.gamma_x0b;
                            p = gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R5, LUT.QUADRUPLE.gamma_NRN1R5) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R5, LUT.QUADRUPLE.gamma_NRD1R5);
                            p *= z;
                            p = quadruple.fmadd(p, z, LUT.QUADRUPLE.gamma_y0b);
                            p += LUT.QUADRUPLE.gamma_y0a;
                        }
                        break;
                    }
                    case 2:
                    {
                        if (x < 1.625)
                        {
                            z = x - LUT.QUADRUPLE.gamma_x0a;
                            z -= LUT.QUADRUPLE.gamma_x0b;
                            p = gamma_neval(z, LUT.QUADRUPLE.gamma_RN1R5, LUT.QUADRUPLE.gamma_NRN1R5) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R5, LUT.QUADRUPLE.gamma_NRD1R5);
                            p *= z;
                            p = quadruple.fmadd(p, z, LUT.QUADRUPLE.gamma_y0b);
                            p += LUT.QUADRUPLE.gamma_y0a;
                        }
                        else if (x < 1.875)
                        {
                            z = x - 1.75;
                            p = z * gamma_neval(z,LUT.QUADRUPLE.gamma_RN1R75, LUT.QUADRUPLE.gamma_NRN1R75) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD1R75, LUT.QUADRUPLE.gamma_NRD1R75);
                            p += LUT.QUADRUPLE.gamma_lgam1r75b;
                            p += LUT.QUADRUPLE.gamma_lgam1r75a;
                        }
                        else if (x == 2)
                        {
                            p = 0;
                        }
                        else if (x < 2.375)
                        {
                            z = x - 2;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN2, LUT.QUADRUPLE.gamma_NRN2) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD2, LUT.QUADRUPLE.gamma_NRD2);
                        }
                        else
                        {
                            z = x - 2.5;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN2R5, LUT.QUADRUPLE.gamma_NRN2R5) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD2R5, LUT.QUADRUPLE.gamma_NRD2R5);
                            p += LUT.QUADRUPLE.gamma_lgam2r5b;
                            p += LUT.QUADRUPLE.gamma_lgam2r5a;
                        }
                        break;
                    }
                    case 3:
                    {
                        if (x < 2.75)
                        {
                            z = x - 2.5;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN2R5, LUT.QUADRUPLE.gamma_NRN2R5) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD2R5, LUT.QUADRUPLE.gamma_NRD2R5);
                            p += LUT.QUADRUPLE.gamma_lgam2r5b;
                            p += LUT.QUADRUPLE.gamma_lgam2r5a;
                        }
                        else
                        {
                            z = x - 3;
                            p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN3, LUT.QUADRUPLE.gamma_NRN3) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD3, LUT.QUADRUPLE.gamma_NRD3);
                            p += LUT.QUADRUPLE.gamma_lgam3b;
                            p += LUT.QUADRUPLE.gamma_lgam3a;
                        }
                        break;
                    }
                    case 4:
                    {
                        z = x - 4;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN4, LUT.QUADRUPLE.gamma_NRN4) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD4, LUT.QUADRUPLE.gamma_NRD4);
                        p += LUT.QUADRUPLE.gamma_lgam4b;
                        p += LUT.QUADRUPLE.gamma_lgam4a;
                        break;
                    }
                    case 5:
                    {
                        z = x - 5;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN5, LUT.QUADRUPLE.gamma_NRN5) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD5, LUT.QUADRUPLE.gamma_NRD5);
                        p += LUT.QUADRUPLE.gamma_lgam5b;
                        p += LUT.QUADRUPLE.gamma_lgam5a;
                        break;
                    }
                    case 6:
                    {
                        z = x - 6;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN6, LUT.QUADRUPLE.gamma_NRN6) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD6, LUT.QUADRUPLE.gamma_NRD6);
                        p += LUT.QUADRUPLE.gamma_lgam6b;
                        p += LUT.QUADRUPLE.gamma_lgam6a;
                        break;
                    }
                    case 7:
                    {
                        z = x - 7;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN7, LUT.QUADRUPLE.gamma_NRN7) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD7, LUT.QUADRUPLE.gamma_NRD7);
                        p += LUT.QUADRUPLE.gamma_lgam7b;
                        p += LUT.QUADRUPLE.gamma_lgam7a;
                        break;
                    }
                    case 8:
                    {
                        z = x - 8;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN8, LUT.QUADRUPLE.gamma_NRN8) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD8, LUT.QUADRUPLE.gamma_NRD8);
                        p += LUT.QUADRUPLE.gamma_lgam8b;
                        p += LUT.QUADRUPLE.gamma_lgam8a;
                        break;
                    }
                    case 9:
                    {
                        z = x - 9;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN9, LUT.QUADRUPLE.gamma_NRN9) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD9, LUT.QUADRUPLE.gamma_NRD9);
                        p += LUT.QUADRUPLE.gamma_lgam9b;
                        p += LUT.QUADRUPLE.gamma_lgam9a;
                        break;
                    }
                    case 10:
                    {
                        z = x - 10;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN10, LUT.QUADRUPLE.gamma_NRN10) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD10, LUT.QUADRUPLE.gamma_NRD10);
                        p += LUT.QUADRUPLE.gamma_lgam10b;
                        p += LUT.QUADRUPLE.gamma_lgam10a;
                        break;
                    }
                    case 11:
                    {
                        z = x - 11;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN11, LUT.QUADRUPLE.gamma_NRN11) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD11, LUT.QUADRUPLE.gamma_NRD11);
                        p += LUT.QUADRUPLE.gamma_lgam11b;
                        p += LUT.QUADRUPLE.gamma_lgam11a;
                        break;
                    }
                    case 12:
                    {
                        z = x - 12;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN12, LUT.QUADRUPLE.gamma_NRN12) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD12, LUT.QUADRUPLE.gamma_NRD12);
                        p += LUT.QUADRUPLE.gamma_lgam12b;
                        p += LUT.QUADRUPLE.gamma_lgam12a;
                        break;
                    }
                    case 13:
                    {
                        z = x - 13;
                        p = z * gamma_neval(z, LUT.QUADRUPLE.gamma_RN13, LUT.QUADRUPLE.gamma_NRN13) / gamma_deval(z, LUT.QUADRUPLE.gamma_RD13, LUT.QUADRUPLE.gamma_NRD13);
                        p += LUT.QUADRUPLE.gamma_lgam13b;
                        p += LUT.QUADRUPLE.gamma_lgam13a;
                        break;
                    }
                }

                return p;
            }
            else
            {
                if (x > new quadruple(0xD7EA_44AE_6D20_3DF6, 0x7FF1_71AA_9917_FFFB))
                {
                    return negateif(quadruple.PositiveInfinity, sign < 0);
                }
                if (x > new quadruple(0x0000_0000_0000_0000, 0x4077_0000_0000_0000))
                {
                    return x * (log(x) - 1);
                }

                q = new quadruple(0x4A69_2979_2002_8832, 0x3FFE_D67F_1C86_4BEB) - x;
                q = quadruple.fmadd(x - 0.5, log(x), q);
                if (x > new quadruple(0x0000_0000_0000_0000, 0x403A_BC16_D674_EC80))
                {
                    return q;
                }

                p = rcp(square(x));
                q += gamma_neval(p, LUT.QUADRUPLE.gamma_RASY, LUT.QUADRUPLE.gamma_NRASY) / x;
                return (q);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static quadruple gammal_positive(quadruple x, out int exp2_adj)
        {
            quadruple gamma_coeff0  = new quadruple(0x5555_5555_5555_5555, 0x3FFB_5555_5555_5555);
            quadruple gamma_coeff1  = new quadruple(0x6C16_C16C_16C1_6C17, 0xBFF6_6C16_C16C_16C1);
            quadruple gamma_coeff2  = new quadruple(0xA01A_01A0_1A01_A01A, 0x3FF4_A01A_01A0_1A01);
            quadruple gamma_coeff3  = new quadruple(0x3813_8138_1381_3814, 0xBFF4_3813_8138_1381);
            quadruple gamma_coeff4  = new quadruple(0x3570_EA73_806E_5479, 0x3FF4_B951_E2B1_8FF2);
            quadruple gamma_coeff5  = new quadruple(0xC81F_6AB0_D999_3C7D, 0xBFF5_F6AB_0D99_93C7);
            quadruple gamma_coeff6  = new quadruple(0xA41A_41A4_1A41_A41A, 0x3FF7_A41A_41A4_1A41);
            quadruple gamma_coeff7  = new quadruple(0x7DC2_064A_8ED3_175C, 0xBFF9_E428_6CB0_F539);
            quadruple gamma_coeff8  = new quadruple(0xFFA1_876F_E963_81E0, 0x3FFC_6FE9_6381_E067);
            quadruple gamma_coeff9  = new quadruple(0x9EDB_DB9C_E625_987D, 0xBFFF_6476_7011_81F3);
            quadruple gamma_coeff10 = new quadruple(0x5A74_F539_10C8_B380, 0x4002_ACE4_4322_CE00);
            quadruple gamma_coeff11 = new quadruple(0xAAB6_7EE2_5D73_C0F9, 0xC006_39B2_525C_CCC1);
            quadruple gamma_coeff12 = new quadruple(0x1B4E_81B4_E81B_4E82, 0x400A_1223_4E81_B4E8);
            quadruple gamma_coeff13 = new quadruple(0x7EB3_FEDD_D849_6920, 0xC00E_1A19_8AE1_C4AB);

            exp2_adj = 0;
            if (x < 12.5)
            {
                quadruple lgammaArg;
                quadruple n = Uninitialized<quadruple>.Create();;
                if (x < 0.5)
                {
                    lgammaArg = x + 1;
                }
                else if (x <= 1.5)
                {
                    lgammaArg = x;
                }
                else
                {
                    n = ceil(x - 1.5);
                    lgammaArg = x - n;
                }
                
                quadruple __xx = exp(lngamma(lgammaArg));

                if (x < 0.5)
                {
                    return __xx / x;
                }
                else if (x <= 1.5)
                {
                    return __xx;
                }
                else
                {
                    quadruple prod = gamma_product(lgammaArg, 0, (int)n, out quadruple eps);
                    return __xx * prod * (1 + eps);
                }
            }
            else
            {
                quadruple eps = 0;
                quadruple x_eps = 0;
                quadruple x_adj = x;
                quadruple prod = 1;
                if (x < 24)
	            {
	                quadruple n = ceil(24 - x);
	                x_adj = x + n;
	                x_eps = x - (x_adj - n);
	                prod = gamma_product(x_adj - n, x_eps, (int)n, out eps);
	            }
                quadruple exp_adj = -eps;
                quadruple x_adj_int = round(x_adj);
                quadruple x_adj_frac = x_adj - x_adj_int;
                quadruple x_adj_mant = frexp(x_adj, out int x_adj_log2);
                if (x_adj_mant < new quadruple(0xC908_B2FB_1366_EA95, 0x3FFE_6A09_E667_F3BC))
	            {
	                x_adj_log2--;
	                x_adj_mant *= 2;
	            }
                exp2_adj = x_adj_log2 * (int)x_adj_int;
                quadruple ret = (pow(x_adj_mant, x_adj)
	            	          * exp2(x_adj_log2 * x_adj_frac)
	            	          * exp(-x_adj)
	            	          * sqrt(TAU_QUAD / x_adj)
	            	          / prod);
                exp_adj = quadruple.fmadd(x_eps, log(x_adj), exp_adj);
                quadruple bsum = gamma_coeff13;
                quadruple x_adj2 = square(x_adj);
	            bsum = bsum / x_adj2 + gamma_coeff12;
	            bsum = bsum / x_adj2 + gamma_coeff11;
	            bsum = bsum / x_adj2 + gamma_coeff10;
	            bsum = bsum / x_adj2 + gamma_coeff9;
	            bsum = bsum / x_adj2 + gamma_coeff8;
	            bsum = bsum / x_adj2 + gamma_coeff7;
	            bsum = bsum / x_adj2 + gamma_coeff6;
	            bsum = bsum / x_adj2 + gamma_coeff5;
	            bsum = bsum / x_adj2 + gamma_coeff4;
	            bsum = bsum / x_adj2 + gamma_coeff3;
	            bsum = bsum / x_adj2 + gamma_coeff2;
	            bsum = bsum / x_adj2 + gamma_coeff1;
	            bsum = bsum / x_adj2 + gamma_coeff0;
                exp_adj += bsum / x_adj;

                return quadruple.fmadd(ret, expm1(exp_adj), ret);
            }
        }
	}
}
