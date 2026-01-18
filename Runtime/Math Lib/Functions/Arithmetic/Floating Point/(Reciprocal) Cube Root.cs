using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.R_CBRT;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    // https://www.mdpi.com/1996-1073/14/4/1058/htm

    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_ps(v128 a, byte elements = 4, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f, elements);

                    v128 ONE = set1_ps(1f);
                    v128 ONE_THIRD  = set1_ps(1f / 3f);
                    v128 TWO_THIRDS = set1_ps(2f / 3f);
                    v128 SIGN_MASK = set1_epi32(1u << 31);
                    v128 SIGNALING_EXPONENT_M1 = set1_epi32(F32_SIGNALING_EXPONENT - 1);


	                v128 absA = promisePositive ? a : abs_ps(a, elements);
                    v128 y;

	                if (promiseNormalized || constexpr.ALL_GE_PS(absA, math.asfloat(1 << 23), elements))
                    {
                        y = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(absA, 3, elements, true));

                        if (!(promiseFinite || (constexpr.ALL_LE_PS(absA, float.MaxValue, elements) && constexpr.ALL_NOTNAN_PS(absA, elements))))
                        {
                            v128 naninf = cmpgt_epi32(absA, SIGNALING_EXPONENT_M1);
                            absA = andnot_si128(naninf, absA);
                        }

                        v128 c = mul_ps(mul_ps(absA, y), mul_ps(y, y));
                        y = mul_ps(y, fnmadd_ps(fnmadd_ps(set1_ps(F32_C2), c, set1_ps(F32_C1)), c, set1_ps(F32_C0)));
                        v128 d = mul_ps(absA, y);
                        c = fnmadd_ps(d, mul_ps(y, y), ONE);
                        y = mul_ps(mul_ps(d, y), fmadd_ps(c, ONE_THIRD, ONE));
	                }
                    else
                    {
                        v128 absAc = absA;
                        v128 absAd = absA;


                        v128 yd = mul_ps(absAd, set1_epi32(0x4B80_0000));
                        yd = constdiv_epu32(yd, 3, elements, true);
                        yd = add_epi32(set1_epi32(F32_DIVD), yd);
                        v128 y2d = mul_ps(yd, yd);

                        v128 muld = yd;
                        if (!(promiseNonZero || constexpr.ALL_NEQ_PS(a, 0f, elements)))
                        {
                            v128 isZero = cmpeq_ps(a, setzero_ps());
                            TWO_THIRDS = andnot_ps(isZero, TWO_THIRDS);

                            muld = blendv_si128(yd, set1_ps(1f / 5.26301e-31f), isZero);
                        }

                        v128 y3 = mul_ps(y2d, muld);
                        yd = mul_ps(yd, div_ps(fmadd_ps(y2d, muld, add_ps(absAd, absAd)),
                                        add_ps(y3, fmadd_ps(y2d, muld, absAd))));


                        v128 yc = constdiv_epu32(absAc, 3, elements, true);
                        yc = sub_epi32(set1_epi32(F32_DIVC), yc);

                        if (!(promiseFinite || (constexpr.ALL_LE_PS(absA, float.MaxValue, elements) && constexpr.ALL_NOTNAN_PS(absA, elements))))
                        {
                            v128 naninf = cmpgt_epi32(absAc, SIGNALING_EXPONENT_M1);
                            absAc = andnot_si128(naninf, absAc);
                        }

                        v128 c = mul_ps(mul_ps(absAc, yc), mul_ps(yc, yc));
                        yc = mul_ps(yc, fnmadd_ps(fnmadd_ps(set1_ps(F32_C2), c, set1_ps(F32_C1)), c, set1_ps(F32_C0)));
                        v128 d = mul_ps(absAc, yc);
                        c = fnmadd_ps(d, mul_ps(yc, yc), ONE);
                        yc = mul_ps(mul_ps(d, yc), fmadd_ps(c, ONE_THIRD, ONE));

                        v128 subnormal = cmpgt_epi32(set1_epi32(1 << 23), absA);
                        y = blendv_si128(yc, yd, subnormal);
                    }

                    if (!promisePositive)
                    {
                        TWO_THIRDS = ternarylogic_si128(TWO_THIRDS, SIGN_MASK, a, TernaryOperation.OxF8);
                    }

	                return add_ps(div_ps(mul_ps(ONE_THIRD, a), mul_ps(y, y)), mul_ps(TWO_THIRDS, y));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_ps(v256 a, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false)
            {
                if (Avx.IsAvxSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f);

                    v256 ONE = mm256_set1_ps(1f);
                    v256 ONE_THIRD  = mm256_set1_ps(1f / 3f);
                    v256 TWO_THIRDS = mm256_set1_ps(2f / 3f);
                    v256 SIGN_MASK = mm256_set1_epi32(1u << 31);
                    v256 SIGNALING_EXPONENT_M1 = mm256_set1_epi32(F32_SIGNALING_EXPONENT - 1);

	                v256 absA = promisePositive ? a : mm256_abs_ps(a);

                    v256 y;
	                if (promiseNormalized || constexpr.ALL_GE_PS(absA, math.asfloat(1 << 23)))
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            y = Avx2.mm256_sub_epi32(mm256_set1_epi32(F32_DIVC), mm256_constdiv_epu32(absA, 3, true));

                            if (!(promiseFinite || (constexpr.ALL_LE_PS(absA, float.MaxValue) && constexpr.ALL_NOTNAN_PS(absA))))
                            {
                                v256 naninf = Avx2.mm256_cmpgt_epi32(absA, SIGNALING_EXPONENT_M1);
                                absA = Avx2.mm256_andnot_si256(naninf, absA);
                            }
                        }
                        else
                        {
                            v128 yLo = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_castsi256_si128(absA), 3, 4, true));
                            v128 yHi = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_extractf128_ps(absA, 1), 3, 4, true));

                            y = Avx.mm256_insertf128_ps(Avx.mm256_castsi128_si256(yLo), yHi, 1);

                            if (!(promiseFinite || (constexpr.ALL_LE_PS(absA, float.MaxValue) && constexpr.ALL_NOTNAN_PS(absA))))
                            {
                                v256 nan = Xse.mm256_cmpunord_ps(absA, absA);
                                v256 inf = Xse.mm256_cmpeq_ps(absA, mm256_set1_ps(float.PositiveInfinity));
                                absA = Avx.mm256_andnot_ps(Avx.mm256_or_ps(nan, inf), absA);
                            }
                        }

                        v256 c = Avx.mm256_mul_ps(Avx.mm256_mul_ps(absA, y), Avx.mm256_mul_ps(y, y));
                        y = Avx.mm256_mul_ps(y, mm256_fnmadd_ps(mm256_fnmadd_ps(mm256_set1_ps(F32_C2), c, mm256_set1_ps(F32_C1)), c, mm256_set1_ps(F32_C0)));
                        v256 d = Avx.mm256_mul_ps(absA, y);
                        c = mm256_fnmadd_ps(d, Avx.mm256_mul_ps(y, y), ONE);
                        y = Avx.mm256_mul_ps(Avx.mm256_mul_ps(d, y), mm256_fmadd_ps(c, ONE_THIRD, ONE));
	                }
                    else
                    {
                        v256 absAc = absA;
                        v256 absAd = absA;

                        v256 yd = Avx.mm256_mul_ps(absAd, mm256_set1_epi32(0x4B80_0000));
                        if (Avx2.IsAvx2Supported)
                        {
                            yd = Avx2.mm256_add_epi32(mm256_set1_epi32(F32_DIVD), mm256_constdiv_epu32(yd, 3, true));
                        }
                        else
                        {
                            v128 ydLo = add_epi32(set1_epi32(F32_DIVD), constdiv_epu32(Avx.mm256_castsi256_si128(yd), 3, 4, true));
                            v128 ydHi = add_epi32(set1_epi32(F32_DIVD), constdiv_epu32(Avx.mm256_extractf128_ps(yd, 1), 3, 4, true));

                            yd = Avx.mm256_insertf128_ps(Avx.mm256_castsi128_si256(ydLo), ydHi, 1);
                        }
                        v256 y2d = Avx.mm256_mul_ps(yd, yd);

                        v256 muld = yd;
                        if (!(promiseNonZero || constexpr.ALL_NEQ_PS(a, 0f)))
                        {
                            v256 isZero = Xse.mm256_cmpeq_ps(a, Avx.mm256_setzero_ps());
                            TWO_THIRDS = Avx.mm256_andnot_ps(isZero, TWO_THIRDS);

                            muld = Avx.mm256_blendv_ps(yd, mm256_set1_ps(1f / 5.26301e-31f), isZero);
                        }

                        v256 y3 = Avx.mm256_mul_ps(y2d, muld);
                        yd = Avx.mm256_mul_ps(yd, Avx.mm256_div_ps(mm256_fmadd_ps(y2d, muld, Avx.mm256_add_ps(absAd, absAd)),
                                                                   Avx.mm256_add_ps(y3, mm256_fmadd_ps(y2d, muld, absAd))));

                        v256 yc;
                        if (Avx2.IsAvx2Supported)
                        {
                            yc = Avx2.mm256_sub_epi32(mm256_set1_epi32(F32_DIVC), mm256_constdiv_epu32(absAc, 3, true));

                            if (!(promiseFinite || constexpr.ALL_LE_PS(absAc, float.MaxValue)))
                            {
                                v256 naninf = Avx2.mm256_cmpgt_epi32(absA, SIGNALING_EXPONENT_M1);
                                absAc = Avx2.mm256_andnot_si256(naninf, absAc);
                            }
                        }
                        else
                        {
                            v128 ycLo = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_castsi256_si128(absAc), 3, 4, true));
                            v128 ycHi = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_extractf128_ps(absAc, 1), 3, 4, true));

                            yc = Avx.mm256_insertf128_ps(Avx.mm256_castsi128_si256(ycLo), ycHi, 1);

                            if (!(promiseFinite || (constexpr.ALL_LE_PS(absA, float.MaxValue) && constexpr.ALL_NOTNAN_PS(absA))))
                            {
                                v256 nan = Xse.mm256_cmpunord_ps(absAc, absAc);
                                v256 inf = Xse.mm256_cmpeq_ps(absAc, mm256_set1_ps(float.PositiveInfinity));
                                absAc = Avx.mm256_andnot_ps(Avx.mm256_or_ps(nan, inf), absAc);
                            }
                        }

                        v256 c = Avx.mm256_mul_ps(Avx.mm256_mul_ps(absAc, yc), Avx.mm256_mul_ps(yc, yc));
                        yc = Avx.mm256_mul_ps(yc, mm256_fnmadd_ps(mm256_fnmadd_ps(mm256_set1_ps(F32_C2), c, mm256_set1_ps(F32_C1)), c, mm256_set1_ps(F32_C0)));
                        v256 d = Avx.mm256_mul_ps(absAc, yc);
                        c = mm256_fnmadd_ps(d, Avx.mm256_mul_ps(yc, yc), ONE);
                        yc = Avx.mm256_mul_ps(Avx.mm256_mul_ps(d, yc), mm256_fmadd_ps(c, ONE_THIRD, ONE));

                        v256 subnormal = Xse.mm256_cmpgt_ps(mm256_set1_epi32(1 << 23), absA);
                        y = Avx.mm256_blendv_ps(yc, yd, subnormal);
                    }

                    if (!promisePositive)
                    {
                        TWO_THIRDS = mm256_ternarylogic_si256(TWO_THIRDS, SIGN_MASK, a, TernaryOperation.OxF8);
                    }

	                return Avx.mm256_add_ps(Avx.mm256_div_ps(Avx.mm256_mul_ps(ONE_THIRD, a), Avx.mm256_mul_ps(y, y)), Avx.mm256_mul_ps(TWO_THIRDS, y));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_pd(v128 a, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false)
            {
                static v128 constdiv3(v128 hi, v128 add)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        //inlined (more efficient shuffles)
                        v128 RCP3 = set1_epi64x(2_863_311_531);
					    hi = mul_epu32(RCP3, srli_epi64(hi, 32));
					    hi = srli_epi64(hi, 33);
					    hi = add_epi64(hi, add);
					    hi = slli_epi64(hi, 32);

                        return hi;
                    }
                    else throw new IllegalInstructionException();
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PD(a, 0d);
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0d);

                    v128 SIGN_BIT = set1_epi64x(1L << 63);
                    v128 ONE = set1_pd(1d);

                    v128 absA = a;
                    if (!promisePositive)
                    {
                        absA = andnot_pd(SIGN_BIT, a);

                        promiseNormalized |= constexpr.ALL_GT_PD(absA, math.asdouble(1L << 52));
                        promiseFinite |= constexpr.ALL_LE_PD(absA, double.MaxValue) && constexpr.ALL_NOTNAN_PD(absA);
                    }
                    else
                    {
                        promiseNormalized |= constexpr.ALL_GT_PD(a, math.asdouble(1L << 52));
                        promiseFinite |= constexpr.ALL_LE_PD(a, double.MaxValue) && constexpr.ALL_NOTNAN_PD(a);
                    }

                    v128 y;
                    v128 r;
                    if (promiseNormalized)
                    {
	                    y = constdiv3(absA, set1_epi32(F64_DIVC));

                        r = mul_pd(mul_pd(y, y), mul_pd(y, div_pd(ONE, absA)));
                    }
                    else
                    {
                        v128 subnormal;
                        if (Sse4_1.IsSse41Supported)
                        {
                            subnormal = cmpgt_epi32(set1_epi32(0x0010_0000), absA);
                            y = mul_pd(absA, blendv_pd(ONE, set1_epi64x(0x4350_0000_0000_0000ul), subnormal));
	                        y = constdiv3(y, blendv_pd(set1_epi32(F64_DIVC), set1_epi32(F64_DIVD), subnormal));
                        }
                        else
                        {
                            subnormal = shuffle_epi32(cmpgt_epi32(set1_epi32(0x0010_0000), absA), Sse.SHUFFLE(3, 3, 1, 1));
                            y = mul_pd(absA, blendv_si128(ONE, set1_epi64x(0x4350_0000_0000_0000ul), subnormal));
	                        y = constdiv3(y, blendv_si128(set1_epi32(F64_DIVC), set1_epi32(F64_DIVD), subnormal));
                        }

                        r = mul_pd(mul_pd(y, y), div_pd(y, absA));
                    }

                    if (!promisePositive)
                    {
	                    y = ternarylogic_si128(y, SIGN_BIT, a, TernaryOperation.OxF8);
                    }

                    v128 c = mul_pd(mul_pd(r, r), r);
                    y = mul_pd(y, fmadd_pd(c, fmadd_pd(set1_pd(F64_C4), r, set1_pd(F64_C3)), fmadd_pd(fmadd_pd(set1_pd(F64_C2), r, set1_pd(F64_C1)), r, set1_pd(F64_C0))));
                    y = add_epi64(y, set1_epi64x(1u << 31));

                    v128 mul;
                    v128 add;
                    if (promiseNonZero)
                    {
                        y = and_pd(y, set1_epi64x(0xFFFF_FFFF_C000_0000ul));

                        if (!promiseFinite)
                        {
                            v128 isInf = cmpeq_pd(absA, set1_pd(double.PositiveInfinity));

                            mul = andnot_pd(isInf, y);
                            add = blendv_si128(y, a, isInf);
                            a = blendv_si128(a, ONE, isInf);
                        }
                        else
                        {
                            mul = y;
                            add = y;
                        }
                    }
                    else
                    {
                        v128 isZero = cmpeq_pd(a, setzero_si128());

                        y = and_pd(y, blendv_si128(set1_epi64x(0xFFFF_FFFF_C000_0000ul), ONE, isZero));

                        if (!promiseFinite)
                        {
                            v128 isInf = cmpeq_pd(absA, set1_pd(double.PositiveInfinity));
                            v128 eitherMask = or_pd(isZero, isInf);

                            mul = andnot_pd(eitherMask, y);
                            add = blendv_si128(y, a, eitherMask);
                            a = blendv_si128(a, ONE, isInf);
                        }
                        else
                        {
                            mul = andnot_pd(isZero, y);
                            add = blendv_si128(y, a, isZero);
                        }
                    }

                    r = div_pd(a, mul_pd(y, y));
                    r = div_pd(sub_pd(r, y), add_pd(r, add_pd(y, y)));

	                return fmadd_pd(r, mul, add);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_pd(v256 a, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false, byte elements = 4)
            {
                if (Avx.IsAvxSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PD(a, 0d, elements);
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0d, elements);

                    v256 SIGN_BIT = mm256_set1_epi64x(1L << 63);
                    v256 ONE = mm256_set1_pd(1d);

                    v256 absA = a;
                    if (!promisePositive)
                    {
                        absA = Avx.mm256_andnot_pd(SIGN_BIT, a);

                        promiseNormalized |= constexpr.ALL_GT_PD(absA, math.asdouble(1L << 52), elements);
                        promiseFinite |= constexpr.ALL_LE_PD(absA, double.MaxValue, elements) && constexpr.ALL_NOTNAN_PD(absA, elements);
                    }
                    else
                    {
                        promiseNormalized |= constexpr.ALL_GT_PD(a, math.asdouble(1L << 52), elements);
                        promiseFinite |= constexpr.ALL_LE_PD(a, double.MaxValue, elements) && constexpr.ALL_NOTNAN_PD(a, elements);
                    }

                    v256 y;
                    v256 r;
                    if (promiseNormalized)
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            //inlined (more efficient shuffles)
                            v256 RCP3 = mm256_set1_epi64x(2_863_311_531);
					        y = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_srli_epi64(absA, 32));
					        y = Avx2.mm256_srli_epi64(y, 33);
					        y = Avx2.mm256_add_epi64(y, mm256_set1_epi32(F64_DIVC));
					        y = Avx2.mm256_slli_epi64(y, 32);
                        }
                        else
                        {
                            v128 ylo = Avx.mm256_extractf128_pd(absA, 0);
                            v128 yhi = Avx.mm256_extractf128_pd(absA, 1);

                            ylo = srli_epi64(slli_epi64(ylo, 1), 33);
                            yhi = srli_epi64(slli_epi64(yhi, 1), 33);

                            //inlined __const.div_epu32 (more efficient shuffles)
                            ylo = mul_epu32(set1_epi64x(2_863_311_531), ylo);
                            yhi = mul_epu32(set1_epi64x(2_863_311_531), yhi);
                            ylo = srli_epi64(ylo, 33);
                            yhi = srli_epi64(yhi, 33);
                            ylo = add_epi64(ylo, set1_epi32(F64_DIVC));
                            yhi = add_epi64(yhi, set1_epi32(F64_DIVC));
                            ylo = slli_epi64(ylo, 32);
                            yhi = slli_epi64(yhi, 32);

                            y = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(ylo), yhi, 1);
                        }

                        r = Avx.mm256_mul_pd(Avx.mm256_mul_pd(y, y), Avx.mm256_mul_pd(y, Avx.mm256_div_pd(ONE, absA)));
                    }
                    else
                    {
                        v256 subnormal;
                        if (Avx2.IsAvx2Supported)
                        {
                            subnormal = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x0010_0000), absA);
                        }
                        else
                        {
                            subnormal = Xse.mm256_cmpgt_pd(mm256_set1_epi64x(0x0010_0000_0000_0000), absA);
                        }

                        y = Avx.mm256_mul_pd(absA, Avx.mm256_blendv_pd(ONE, mm256_set1_epi64x(0x4350_0000_0000_0000ul), subnormal));
                        v256 summand = Avx.mm256_blendv_pd(mm256_set1_epi32(F64_DIVC), mm256_set1_epi32(F64_DIVD), subnormal);

                        if (Avx2.IsAvx2Supported)
                        {
                            //inlined (more efficient shuffles)
                            v256 RCP3 = mm256_set1_epi64x(2_863_311_531);
					        y = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_srli_epi64(y, 32));
					        y = Avx2.mm256_srli_epi64(y, 33);
					        y = Avx2.mm256_add_epi64(y, summand);
					        y = Avx2.mm256_slli_epi64(y, 32);
                        }
                        else if (Avx.IsAvxSupported)
                        {
                            v128 ylo = Avx.mm256_extractf128_pd(y, 0);
                            v128 yhi = Avx.mm256_extractf128_pd(y, 1);

                            ylo = srli_epi64(slli_epi64(ylo, 1), 33);
                            yhi = srli_epi64(slli_epi64(yhi, 1), 33);

                            //inlined __const.div_epu32 (more efficient shuffles)
                            ylo = mul_epu32(set1_epi64x(2_863_311_531), ylo);
                            yhi = mul_epu32(set1_epi64x(2_863_311_531), yhi);
                            ylo = srli_epi64(ylo, 33);
                            yhi = srli_epi64(yhi, 33);
                            ylo = add_epi64(ylo, Avx.mm256_extractf128_pd(summand, 0));
                            yhi = add_epi64(yhi, Avx.mm256_extractf128_pd(summand, 1));
                            ylo = slli_epi64(ylo, 32);
                            yhi = slli_epi64(yhi, 32);

                            y = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(ylo), yhi, 1);
                        }

                        r = Avx.mm256_mul_pd(Avx.mm256_mul_pd(y, y), Avx.mm256_div_pd(y, absA));
                    }

                    if (!promisePositive)
                    {
	                    y = mm256_ternarylogic_si256(y, SIGN_BIT, a, TernaryOperation.OxF8);
                    }

                    v256 c = Avx.mm256_mul_pd(Avx.mm256_mul_pd(r, r), r);
                    y = Avx.mm256_mul_pd(y, mm256_fmadd_pd(c, mm256_fmadd_pd(mm256_set1_pd(F64_C4), r, mm256_set1_pd(F64_C3)), mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_C2), r, mm256_set1_pd(F64_C1)), r, mm256_set1_pd(F64_C0))));

                    if (Avx2.IsAvx2Supported)
                    {
                        y = Avx2.mm256_add_epi64(y, mm256_set1_epi64x(1u << 31));
                    }
                    else
                    {
                        v128 ylo = Avx.mm256_extractf128_pd(y, 0);
                        v128 yhi = Avx.mm256_extractf128_pd(y, 1);

                        ylo = add_epi64(ylo, set1_epi64x(1u << 31));
                        yhi = add_epi64(yhi, set1_epi64x(1u << 31));

                        y = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(ylo), yhi, 1);
                    }


                    v256 mul;
                    v256 add;
                    if (promiseNonZero)
                    {
                        y = Avx.mm256_and_pd(y, mm256_set1_epi64x(0xFFFF_FFFF_C000_0000ul));

                        if (!promiseFinite)
                        {
                            v256 isInf = Xse.mm256_cmpeq_pd(absA, mm256_set1_pd(double.PositiveInfinity));

                            mul = Avx.mm256_andnot_pd(isInf, y);
                            add = Avx.mm256_blendv_pd(y, a, isInf);
                            a = Avx.mm256_blendv_pd(a, ONE, isInf);
                        }
                        else
                        {
                            mul = y;
                            add = y;
                        }
                    }
                    else
                    {
                        v256 isZero = Xse.mm256_cmpeq_pd(a, Avx.mm256_setzero_si256());

                        y = Avx.mm256_and_pd(y, Avx.mm256_blendv_pd(mm256_set1_epi64x(0xFFFF_FFFF_C000_0000ul), ONE, isZero));

                        if (!promiseFinite)
                        {
                            v256 isInf = Xse.mm256_cmpeq_pd(absA, mm256_set1_pd(double.PositiveInfinity));
                            v256 eitherMask = Avx.mm256_or_pd(isZero, isInf);

                            mul = Avx.mm256_andnot_pd(eitherMask, y);
                            add = Avx.mm256_blendv_pd(y, a, eitherMask);
                            a = Avx.mm256_blendv_pd(a, ONE, isInf);
                        }
                        else
                        {
                            mul = Avx.mm256_andnot_pd(isZero, y);
                            add = Avx.mm256_blendv_pd(y, a, isZero);
                        }
                    }

                    r = Avx.mm256_div_pd(a, Avx.mm256_mul_pd(y, y));
                    r = Avx.mm256_div_pd(Avx.mm256_sub_pd(r, y), Avx.mm256_add_pd(r, Avx.mm256_add_pd(y, y)));

	                return mm256_fmadd_pd(r, mul, add);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rcbrt_ps(v128 a, byte elements = 4, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f, elements);
                    promiseNonZero |= constexpr.ALL_NEQ_PS(a, 0f, elements);

                    v128 ONE = set1_ps(1f);
                    v128 ONE_THIRD  = set1_ps(1f / 3f);
                    v128 SIGNALING_EXPONENT = set1_epi32(F32_SIGNALING_EXPONENT);

	                v128 absA = a;
                    if (!promisePositive)
                    {
                        v128 SIGN_MASK = set1_epi32(1u << 31);
                        absA = andnot_ps(SIGN_MASK, a);
                        ONE = ternarylogic_si128(ONE, SIGN_MASK, a, TernaryOperation.OxF8);
                    }

                    v128 y;
	                if (promiseNormalized || constexpr.ALL_GE_PS(absA, math.asfloat(1 << 23), elements))
                    {
                        y = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(absA, 3, elements, true));

                        v128 C0 = set1_ps(F32_C0);
                        if (!promiseFinite)
                        {
                            v128 naninf = cmpeq_epi32(absA, and_si128(absA, SIGNALING_EXPONENT));

                            C0 = andnot_si128(naninf, C0);
                            absA = andnot_si128(naninf, absA);
                            a = andnot_si128(naninf, a);
                        }

                        v128 r = mul_ps(mul_ps(absA, y), mul_ps(y, y));
                        y = mul_ps(y, fnmadd_ps(r, fnmadd_ps(set1_ps(F32_C2), r, set1_ps(F32_C1)), C0));
	                }
                    else
                    {
                        v128 absAc = absA;
                        v128 absAd = absA;

                        v128 yd = mul_ps(absAd, set1_epi32(0x4B80_0000));
                        yd = constdiv_epu32(yd, 3, elements, true);
                        yd = add_epi32(set1_epi32(F32_DIVD), yd);

                        v128 rd = div_ps(absAd, yd);
                        if (BurstArchitecture.IsFMASupported)
                        {
                            yd = div_ps(add_ps(div_ps(rd, yd), add_ps(yd, yd)), fmadd_ps(set1_ps(2f), rd, mul_ps(yd, yd)));
                        }
                        else
                        {
                            yd = div_ps(add_ps(div_ps(rd, yd), add_ps(yd, yd)), fmadd_ps(yd, yd, add_ps(rd, rd)));
                        }

                        if (!promiseNonZero)
                        {
                            ONE_THIRD = blendv_si128(ONE_THIRD, SIGNALING_EXPONENT, cmpeq_ps(a, setzero_ps()));
                        }


                        v128 yc = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(absAc, 3, elements, true));

                        v128 C0 = set1_ps(F32_C0);
                        if (!promiseFinite)
                        {
                            v128 naninf = cmpeq_epi32(absAc, SIGNALING_EXPONENT);

                            C0 = andnot_si128(naninf, C0);
                            absAc = andnot_si128(naninf, absAc);
                            a = andnot_si128(naninf, a);
                        }

                        v128 rc = mul_ps(mul_ps(absAc, yc), mul_ps(yc, yc));
                        yc = mul_ps(yc, fnmadd_ps(rc, fnmadd_ps(set1_ps(F32_C2), rc, set1_ps(F32_C1)), C0));

                        v128 subnormal = cmpgt_epi32(set1_epi32(1 << 23), absA);
                        y = blendv_si128(yc, yd, subnormal);
                    }

                    v128 c = fnmadd_ps(mul_ps(a, y), mul_ps(y, y), ONE);
                    y = mul_ps(y, fmadd_ps(c, ONE_THIRD, ONE));

                    return y;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rcbrt_ps(v256 a, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false)
            {
                if (Avx.IsAvxSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f);
                    promiseNonZero |= constexpr.ALL_NEQ_PS(a, 0f);

                    v256 ONE = mm256_set1_ps(1f);
                    v256 ONE_THIRD  = mm256_set1_ps(1f / 3f);
                    v256 SIGNALING_EXPONENT = mm256_set1_epi32(F32_SIGNALING_EXPONENT);

	                v256 absA = a;
                    if (!promisePositive)
                    {
                        v256 SIGN_MASK = mm256_set1_epi32(1u << 31);
                        absA = Avx.mm256_andnot_ps(SIGN_MASK, a);
                        ONE = mm256_ternarylogic_si256(ONE, SIGN_MASK, a, TernaryOperation.OxF8);
                    }

                    v256 y;
	                if (promiseNormalized || constexpr.ALL_GE_PS(absA, math.asfloat(1 << 23)))
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            y = Avx2.mm256_sub_epi32(mm256_set1_epi32(F32_DIVC), mm256_constdiv_epu32(absA, 3, true));
                        }
                        else
                        {
                            v128 yLo = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_castsi256_si128(absA), 3, 4, true));
                            v128 yHi = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_extractf128_ps(absA, 1), 3, 4, true));

                            y = Avx.mm256_insertf128_ps(Avx.mm256_castsi128_si256(yLo), yHi, 1);
                        }

                        v256 C0 = mm256_set1_ps(F32_C0);
                        if (!promiseFinite)
                        {
                            v256 naninf;
                            if (Avx2.IsAvx2Supported)
                            {
                                naninf = Avx2.mm256_cmpeq_epi32(absA, SIGNALING_EXPONENT);
                            }
                            else
                            {
                                naninf = Xse.mm256_cmpeq_ps(absA, SIGNALING_EXPONENT);
                            }

                            C0 = Avx.mm256_andnot_ps(naninf, C0);
                            absA = Avx.mm256_andnot_ps(naninf, absA);
                            a = Avx.mm256_andnot_ps(naninf, a);
                        }

                        v256 r = Avx.mm256_mul_ps(Avx.mm256_mul_ps(absA, y), Avx.mm256_mul_ps(y, y));
                        y = Avx.mm256_mul_ps(y, mm256_fnmadd_ps(r, mm256_fnmadd_ps(mm256_set1_ps(F32_C2), r, mm256_set1_ps(F32_C1)), C0));
	                }
                    else
                    {
                        v256 absAc = absA;
                        v256 absAd = absA;

                        v256 yd = Avx.mm256_mul_ps(absAd, mm256_set1_epi32(0x4B80_0000));
                        if (Avx2.IsAvx2Supported)
                        {
                            yd = Avx2.mm256_add_epi32(mm256_set1_epi32(F32_DIVD), mm256_constdiv_epu32(yd, 3, true));
                        }
                        else
                        {
                            v128 ydLo = add_epi32(set1_epi32(F32_DIVD), constdiv_epu32(Avx.mm256_castsi256_si128(yd), 3, 4, true));
                            v128 ydHi = add_epi32(set1_epi32(F32_DIVD), constdiv_epu32(Avx.mm256_extractf128_ps(yd, 1), 3, 4, true));

                            yd = Avx.mm256_insertf128_ps(Avx.mm256_castsi128_si256(ydLo), ydHi, 1);
                        }

                        v256 rd = Avx.mm256_div_ps(absAd, yd);
                        if (Avx2.IsAvx2Supported)
                        {
                            yd = Avx.mm256_div_ps(Avx.mm256_add_ps(Avx.mm256_div_ps(rd, yd), Avx.mm256_add_ps(yd, yd)), mm256_fmadd_ps(mm256_set1_ps(2f), rd, Avx.mm256_mul_ps(yd, yd)));
                        }
                        else
                        {
                            yd = Avx.mm256_div_ps(Avx.mm256_add_ps(Avx.mm256_div_ps(rd, yd), Avx.mm256_add_ps(yd, yd)), mm256_fmadd_ps(yd, yd, Avx.mm256_add_ps(rd, rd)));
                        }

                        if (!promiseNonZero)
                        {
                            ONE_THIRD = Avx.mm256_blendv_ps(ONE_THIRD, SIGNALING_EXPONENT, Xse.mm256_cmpeq_ps(a, Avx.mm256_setzero_ps()));
                        }

                        v256 yc;
                        if (Avx2.IsAvx2Supported)
                        {
                            yc = Avx2.mm256_sub_epi32(mm256_set1_epi32(F32_DIVC), mm256_constdiv_epu32(absAc, 3, true));
                        }
                        else
                        {
                            v128 ycLo = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_castsi256_si128(absAc), 3, 4, true));
                            v128 ycHi = sub_epi32(set1_epi32(F32_DIVC), constdiv_epu32(Avx.mm256_extractf128_ps(absAc, 1), 3, 4, true));

                            yc = Avx.mm256_insertf128_ps(Avx.mm256_castsi128_si256(ycLo), ycHi, 1);
                        }

                        v256 C0 = mm256_set1_ps(F32_C0);
                        if (!promiseFinite)
                        {
                            v256 naninf;
                            if (Avx2.IsAvx2Supported)
                            {
                                naninf = Avx2.mm256_cmpeq_epi32(absAc, SIGNALING_EXPONENT);
                            }
                            else
                            {
                                naninf = Xse.mm256_cmpeq_ps(absAc, SIGNALING_EXPONENT);
                            }

                            C0 = Avx.mm256_andnot_ps(naninf, C0);
                            absAc = Avx.mm256_andnot_ps(naninf, absAc);
                            a = Avx.mm256_andnot_ps(naninf, a);
                        }

                        v256 rc = Avx.mm256_mul_ps(Avx.mm256_mul_ps(absAc, yc), Avx.mm256_mul_ps(yc, yc));
                        yc = Avx.mm256_mul_ps(yc, mm256_fnmadd_ps(rc, mm256_fnmadd_ps(mm256_set1_ps(F32_C2), rc, mm256_set1_ps(F32_C1)), C0));

                        v256 subnormal = Xse.mm256_cmpgt_ps(mm256_set1_epi32(1 << 23), absA);
                        y = Avx.mm256_blendv_ps(yc, yd, subnormal);
                    }

                    v256 c = mm256_fnmadd_ps(Avx.mm256_mul_ps(a, y), Avx.mm256_mul_ps(y, y), ONE);
                    y = Avx.mm256_mul_ps(y, mm256_fmadd_ps(c, ONE_THIRD, ONE));

                    return y;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rcbrt_pd(v128 a, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false)
            {
                static v128 constdiv3(v128 hi, v128 add)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        //inlined (more efficient shuffles)
                        v128 RCP3 = set1_epi64x(2_863_311_531);
					    hi = mul_epu32(RCP3, srli_epi64(hi, 32));
					    hi = srli_epi64(hi, 33);
					    hi = add_epi64(hi, add);
					    hi = slli_epi64(hi, 32);

                        return hi;
                    }
                    else throw new IllegalInstructionException();
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PD(a, 0d);
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0d);

                    v128 SIGN_BIT = set1_epi64x(1L << 63);
                    v128 ONE = set1_pd(1d);

                    v128 absA = a;
                    if (!promisePositive)
                    {
                        absA = andnot_pd(SIGN_BIT, a);

                        promiseNormalized |= constexpr.ALL_GT_PD(absA, math.asdouble(1L << 52));
                        promiseFinite |= constexpr.ALL_LE_PD(absA, double.MaxValue) && constexpr.ALL_NOTNAN_PD(absA);
                    }
                    else
                    {
                        promiseNormalized |= constexpr.ALL_GT_PD(a, math.asdouble(1L << 52));
                        promiseFinite |= constexpr.ALL_LE_PD(a, double.MaxValue) && constexpr.ALL_NOTNAN_PD(a);
                    }

                    v128 y;
                    v128 r;
                    if (promiseNormalized)
                    {
	                    y = constdiv3(absA, set1_epi32(F64_DIVC));
                        r = mul_pd(mul_pd(y, y), mul_pd(promisePositive ? y : ternarylogic_si128(y, a, SIGN_BIT, TernaryOperation.OxF8), div_pd(ONE, a)));
                    }
                    else
                    {
                        v128 subnormal;
                        if (Sse4_1.IsSse41Supported)
                        {
                            subnormal = cmpgt_epi32(set1_epi32(0x0010_0000), absA);
                            y = mul_pd(absA, blendv_pd(ONE, set1_epi64x(0x4350_0000_0000_0000ul), subnormal));
	                        y = constdiv3(y, blendv_pd(set1_epi32(F64_DIVC), set1_epi32(F64_DIVD), subnormal));
                        }
                        else
                        {
                            subnormal = shuffle_epi32(cmpgt_epi32(set1_epi32(0x0010_0000), absA), Sse.SHUFFLE(3, 3, 1, 1));
                            y = mul_pd(absA, blendv_si128(ONE, set1_epi64x(0x4350_0000_0000_0000ul), subnormal));
	                        y = constdiv3(y, blendv_si128(set1_epi32(F64_DIVC), set1_epi32(F64_DIVD), subnormal));
                        }

                        r = mul_pd(mul_pd(y, y), div_pd(promisePositive ? y : ternarylogic_si128(y, a, SIGN_BIT, TernaryOperation.OxF8), a));
                    }

                    if (!promisePositive)
                    {
                        y = ternarylogic_si128(y, a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    v128 c = mul_pd(mul_pd(r, r), r);
                    y = mul_pd(y, fmadd_pd(c, fmadd_pd(set1_pd(F64_C4), r, set1_pd(F64_C3)), fmadd_pd(fmadd_pd(set1_pd(F64_C2), r, set1_pd(F64_C1)), r, set1_pd(F64_C0))));
                    y = add_epi64(y, set1_epi64x(1u << 31));

                    v128 add;
                    if (promiseNonZero)
                    {
                        y = and_pd(y, set1_epi64x(0xFFFF_FFFF_C000_0000ul));
                        add = y;
                    }
                    else
                    {
                        v128 neqZero = cmpneq_pd(a, setzero_si128());

                        y = and_pd(y, blendv_si128(ONE, set1_epi64x(0xFFFF_FFFF_C000_0000ul), neqZero));
                        add = blendv_si128(ternarylogic_si128(set1_pd(double.PositiveInfinity), SIGN_BIT, a, TernaryOperation.OxF8), y, neqZero);
                    }
                    add = add_pd(y, add);

                    v128 div = a;
                    if (!promiseFinite)
                    {
                        v128 isInf = cmpeq_pd(absA, set1_pd(double.PositiveInfinity));

                        div = blendv_si128(a,   and_pd(SIGN_BIT, a), isInf);
                        add = blendv_si128(add, and_pd(SIGN_BIT, a), isInf);
                    }

                    r = div_pd(div, y);

                    if (BurstArchitecture.IsFMASupported)
                    {
                        return div_pd(fmadd_pd(r, div_pd(ONE, y), add), fmadd_pd(set1_pd(2d), r, mul_pd(y, y)));
                    }
                    else
                    {
                        return div_pd(fmadd_pd(r, div_pd(ONE, y), add), add_pd(fmadd_pd(y, y, r), r));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rcbrt_pd(v256 a, bool promisePositive = false, bool promiseNonZero = false, bool promiseFinite = false, bool promiseNormalized = false, byte elements = 4)
            {
                if (Avx.IsAvxSupported)
                {
                    promisePositive |= constexpr.ALL_GT_PD(a, 0d, elements);
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0d, elements);

                    v256 SIGN_BIT = mm256_set1_epi64x(1L << 63);
                    v256 ONE = mm256_set1_pd(1d);

                    v256 absA = a;
                    if (!promisePositive)
                    {
                        absA = Avx.mm256_andnot_pd(SIGN_BIT, a);

                        promiseNormalized |= constexpr.ALL_GT_PD(absA, math.asdouble(1L << 52), elements);
                        promiseFinite |= constexpr.ALL_LE_PD(absA, double.MaxValue, elements) && constexpr.ALL_NOTNAN_PD(absA, elements);
                    }
                    else
                    {
                        promiseNormalized |= constexpr.ALL_GT_PD(a, math.asdouble(1L << 52), elements);
                        promiseFinite |= constexpr.ALL_LE_PD(a, double.MaxValue, elements) && constexpr.ALL_NOTNAN_PD(a, elements);
                    }

                    v256 y;
                    v256 r;
                    if (promiseNormalized)
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            //inlined (more efficient shuffles)
                            v256 RCP3 = mm256_set1_epi64x(2_863_311_531);
					        y = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_srli_epi64(absA, 32));
					        y = Avx2.mm256_srli_epi64(y, 33);
					        y = Avx2.mm256_add_epi64(y, mm256_set1_epi32(F64_DIVC));
					        y = Avx2.mm256_slli_epi64(y, 32);
                        }
                        else
                        {
                            v128 ylo = Avx.mm256_extractf128_pd(absA, 0);
                            v128 yhi = Avx.mm256_extractf128_pd(absA, 1);

                            ylo = srli_epi64(slli_epi64(ylo, 1), 33);
                            yhi = srli_epi64(slli_epi64(yhi, 1), 33);

                            //inlined __const.div_epu32 (more efficient shuffles)
                            ylo = mul_epu32(set1_epi64x(2_863_311_531), ylo);
                            yhi = mul_epu32(set1_epi64x(2_863_311_531), yhi);
                            ylo = srli_epi64(ylo, 33);
                            yhi = srli_epi64(yhi, 33);
                            ylo = add_epi64(ylo, set1_epi32(F64_DIVC));
                            yhi = add_epi64(yhi, set1_epi32(F64_DIVC));
                            ylo = slli_epi64(ylo, 32);
                            yhi = slli_epi64(yhi, 32);

                            y = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(ylo), yhi, 1);
                        }

                        r = Avx.mm256_mul_pd(Avx.mm256_mul_pd(y, y), Avx.mm256_mul_pd(promisePositive ? y : mm256_ternarylogic_si256(y, a, SIGN_BIT, TernaryOperation.OxF8), Avx.mm256_div_pd(ONE, a)));
                    }
                    else
                    {
                        v256 subnormal;
                        if (Avx2.IsAvx2Supported)
                        {
                            subnormal = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(0x0010_0000), absA);
                        }
                        else
                        {
                            subnormal = Xse.mm256_cmpgt_pd(mm256_set1_epi64x(0x0010_0000_0000_0000), absA);
                        }

                        y = Avx.mm256_mul_pd(absA, Avx.mm256_blendv_pd(ONE, mm256_set1_epi64x(0x4350_0000_0000_0000ul), subnormal));
                        v256 summand = Avx.mm256_blendv_pd(mm256_set1_epi32(F64_DIVC), mm256_set1_epi32(F64_DIVD), subnormal);

                        if (Avx2.IsAvx2Supported)
                        {
                            //inlined (more efficient shuffles)
                            v256 RCP3 = mm256_set1_epi64x(2_863_311_531);
					        y = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_srli_epi64(y, 32));
					        y = Avx2.mm256_srli_epi64(y, 33);
					        y = Avx2.mm256_add_epi64(y, summand);
					        y = Avx2.mm256_slli_epi64(y, 32);
                        }
                        else if (Avx.IsAvxSupported)
                        {
                            v128 ylo = Avx.mm256_extractf128_pd(y, 0);
                            v128 yhi = Avx.mm256_extractf128_pd(y, 1);

                            ylo = srli_epi64(slli_epi64(ylo, 1), 33);
                            yhi = srli_epi64(slli_epi64(yhi, 1), 33);

                            //inlined __const.div_epu32 (more efficient shuffles)
                            ylo = mul_epu32(set1_epi64x(2_863_311_531), ylo);
                            yhi = mul_epu32(set1_epi64x(2_863_311_531), yhi);
                            ylo = srli_epi64(ylo, 33);
                            yhi = srli_epi64(yhi, 33);
                            ylo = add_epi64(ylo, Avx.mm256_extractf128_pd(summand, 0));
                            yhi = add_epi64(yhi, Avx.mm256_extractf128_pd(summand, 1));
                            ylo = slli_epi64(ylo, 32);
                            yhi = slli_epi64(yhi, 32);

                            y = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(ylo), yhi, 1);
                        }

                        r = Avx.mm256_mul_pd(Avx.mm256_mul_pd(y, y), Avx.mm256_div_pd(promisePositive ? y : mm256_ternarylogic_si256(y, a, SIGN_BIT, TernaryOperation.OxF8), a));
                    }

                    if (!promisePositive)
                    {
                        y = mm256_ternarylogic_si256(y, a, SIGN_BIT, TernaryOperation.OxF8);
                    }

                    v256 c = Avx.mm256_mul_pd(Avx.mm256_mul_pd(r, r), r);
                    y = Avx.mm256_mul_pd(y, mm256_fmadd_pd(c, mm256_fmadd_pd(mm256_set1_pd(F64_C4), r, mm256_set1_pd(F64_C3)), mm256_fmadd_pd(mm256_fmadd_pd(mm256_set1_pd(F64_C2), r, mm256_set1_pd(F64_C1)), r, mm256_set1_pd(F64_C0))));

                    if (Avx2.IsAvx2Supported)
                    {
                        y = Avx2.mm256_add_epi64(y, mm256_set1_epi64x(1u << 31));
                    }
                    else
                    {
                        v128 ylo = Avx.mm256_extractf128_pd(y, 0);
                        v128 yhi = Avx.mm256_extractf128_pd(y, 1);

                        ylo = add_epi64(ylo, set1_epi64x(1u << 31));
                        yhi = add_epi64(yhi, set1_epi64x(1u << 31));

                        y = Avx.mm256_insertf128_pd(Avx.mm256_castpd128_pd256(ylo), yhi, 1);
                    }

                    v256 add;
                    if (promiseNonZero)
                    {
                        y = Avx.mm256_and_pd(y, mm256_set1_epi64x(0xFFFF_FFFF_C000_0000ul));
                        add = y;
                    }
                    else
                    {
                        v256 neqZero = Xse.mm256_cmpneq_pd(a, Avx.mm256_setzero_si256());

                        y = Avx.mm256_and_pd(y, Avx.mm256_blendv_pd(ONE, mm256_set1_epi64x(0xFFFF_FFFF_C000_0000ul), neqZero));
                        add = Avx.mm256_blendv_pd(mm256_ternarylogic_si256(mm256_set1_pd(double.PositiveInfinity), SIGN_BIT, a, TernaryOperation.OxF8), y, neqZero);
                    }
                    add = Avx.mm256_add_pd(y, add);

                    v256 div = a;
                    if (!promiseFinite)
                    {
                        v256 isInf = Xse.mm256_cmpeq_pd(absA, mm256_set1_pd(double.PositiveInfinity));

                        div = Avx.mm256_blendv_pd(a,   Avx.mm256_and_pd(SIGN_BIT, a), isInf);
                        add = Avx.mm256_blendv_pd(add, Avx.mm256_and_pd(SIGN_BIT, a), isInf);
                    }

                    r = Avx.mm256_div_pd(div, y);

                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx.mm256_div_pd(mm256_fmadd_pd(r, Avx.mm256_div_pd(ONE, y), add), mm256_fmadd_pd(mm256_set1_pd(2d), r, Avx.mm256_mul_pd(y, y)));
                    }
                    else
                    {
                        return Avx.mm256_div_pd(mm256_fmadd_pd(r, Avx.mm256_div_pd(ONE, y), add), Avx.mm256_add_pd(mm256_fmadd_pd(y, y, r), r));
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the cube root of a <see cref="float"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cbrt(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_ps(RegisterConversion.ToV128(x), 1, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)).Float0;
            }
            else
            {
                bool POSITIVE = promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x > 0f);
                bool NON_ZERO = promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0f);

                float ONE = 1f;
                float ONE_THIRD  = 1f / 3f;
                float TWO_THIRDS = 2f / 3f;
                uint SIGN_MASK = (1u << 31);


	            uint sign = POSITIVE ? 0 : math.asuint(x) & SIGN_MASK;
	            float absX = POSITIVE ? x : math.abs(x);
                float y;

	            if (promises.Promises(Promise.Unsafe1) || Hint.Likely(absX >= (1 << 23)))
                {
                    y = math.asfloat(F32_DIVC - math.asuint(absX) / 3);

                    if (!(promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(math.isfinite(x) && !math.isnan(x))))
                    {
                        absX = math.asfloat(math.asint(absX) & -tobyte((math.asint(absX) & F32_SIGNALING_EXPONENT) != F32_SIGNALING_EXPONENT));
                    }

                    float c = (absX * y) * (y * y);
                    y *= F32_C0 - c * (F32_C1 - F32_C2 * c);
                    float d = absX * y;
                    c = ONE - d * (y * y);
                    y = (d * y) * (ONE + ONE_THIRD * c);
	            }
                else
                {
	            	y = absX * math.asfloat(0x4B80_0000);
	            	y = math.asfloat(F32_DIVD + math.asuint(y) / 3);

                    float y3 = y * y;
                    float mul = y;
                    if (!NON_ZERO)
                    {
                        if (absX == 0)
                        {
                            mul = 1f / 5.26301e-31f;
                            TWO_THIRDS = 0f;
                        }
                    }

                    y3 *= mul;
                    y *= (absX + absX + y3) / (absX + y3 + y3);
                }

                if (!POSITIVE)
                {
                    TWO_THIRDS = math.asfloat(sign | math.asuint(TWO_THIRDS));
                }

                y = (TWO_THIRDS * y) + ((ONE_THIRD * x) / (y * y));

	            return y;
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cbrt(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.cbrt_ps(RegisterConversion.ToV128(x), 2, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new float2(cbrt(x.x, promises), cbrt(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cbrt(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.cbrt_ps(RegisterConversion.ToV128(x), 3, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new float3(cbrt(x.x, promises), cbrt(x.y, promises), cbrt(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cbrt(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.cbrt_ps(RegisterConversion.ToV128(x), 4, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new float4(cbrt(x.x, promises), cbrt(x.y, promises), cbrt(x.z, promises), cbrt(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="MaxMath.float8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cbrt(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cbrt_ps(x, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1));
            }
            else
            {
                return new float8(cbrt(x.v4_0, promises), cbrt(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the cube root of a <see cref="double"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.                                                              </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cbrt(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_pd(RegisterConversion.ToV128(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)).Double0;
            }
            else
            {
                bool POSITIVE = promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x > 0d);
                bool NON_ZERO = promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0d);

                double absX = POSITIVE ? x : math.asdouble(math.asulong(x) & ((1ul << 63) - 1));
	            uint hi = (uint)(math.asulong(absX) >> 32);
                bool isInf = hi == (uint)(F64_SIGNALING_EXPONENT >> 32);
                ulong sign = math.asulong(x) & (1ul << 63);

                double r;
                double y;
                if (promises.Promises(Promise.Unsafe1) || Hint.Likely(math.asulong(absX) >= 0x0010_0000_0000_0000))
                {
                    hi = hi / 3 + F64_DIVC;

                    y = math.asdouble((ulong)hi << 32);
                    r = (y * y) * (y * (1d / absX));
                }
                else
                {
		            hi = (uint)(math.asulong(absX * math.asdouble(0x4350_0000_0000_0000ul)) >> 32);
		            hi = hi / 3 + F64_DIVD;

                    y = math.asdouble((ulong)hi << 32);
                    r = (y * y) * (y / absX);
                }

                if (!POSITIVE)
                {
	                y = math.asdouble(math.asulong(y) | sign);
                }

                y *= math.mad(r * r * r, math.mad(F64_C4, r, F64_C3), math.mad(math.mad(F64_C2, r, F64_C1), r, F64_C0));
                y = math.asdouble((math.asulong(y) + (1u << 31)) & ((NON_ZERO || x != 0d) ? 0xFFFF_FFFF_C000_0000ul : math.asulong(1d)));

                double mul = y;
                double add = y;
                if (!NON_ZERO)
                {
                    mul = x != 0d ? mul : 0d;
                    add = x != 0d ? add : x;
                }
                if (!promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(math.isfinite(x) && !math.isnan(x)))
                {
                    mul = isInf ? 0d : mul;
                    add = isInf ? x  : add;
                    x   = isInf ? 1d : x;
                }

	            r = x / (y * y);
	            r = (r - y) / ((y + y) + r);

	            return r * mul + add;
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0 values, including negative 0.                                                                </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/> 0 values, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cbrt(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.cbrt_pd(RegisterConversion.ToV128(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new double2(cbrt(x.x, promises), cbrt(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0 values, including negative 0.                                                                </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/> 0 values, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cbrt(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_cbrt_pd(RegisterConversion.ToV256(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1), 3));
            }
            else
            {
                return new double3(cbrt(x.xy, promises), cbrt(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0 values, including negative 0.                                                                </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/> 0 values, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cbrt(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_cbrt_pd(RegisterConversion.ToV256(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1), 4));
            }
            else
            {
                return new double4(cbrt(x.xy, promises), cbrt(x.zw, promises));
            }
        }


        /// <summary>       Returns the reciprocal cube root of a <see cref="float"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float rcbrt(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcbrt_ps(RegisterConversion.ToV128(x), 1, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)).Float0;
            }
            else
            {
                bool POSITIVE = promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x > 0f);

                float ONE = 1f;
                float ONE_THIRD = 1f / 3f;
                float absX = x;

                if (!POSITIVE)
                {
                    uint SIGN_MASK = (1u << 31);
                    uint sign = math.asuint(x) & SIGN_MASK;
                    absX = math.asfloat(andnot(math.asuint(x), SIGN_MASK));
                    ONE = math.asfloat(sign | math.asuint(ONE));
                }

                float y;
	            if (promises.Promises(Promise.Unsafe1) || Hint.Likely(absX >= (1 << 23)))
                {
                    y = math.asfloat(F32_DIVC - math.asuint(absX) / 3);

                    float C0 = F32_C0;

                    if (!promises.Promises(Promise.Unsafe0))
                    {
                        if (math.isinf(x))
                        {
                            C0 = 0f;
                            absX = 0f;
                            x = 0f;
                        }
                    }

                    float r = (absX * y) * (y * y);
                    y *= C0 - r * (F32_C1 - F32_C2 * r);
                }
                else
                {
	            	y = absX * math.asfloat(0x4B80_0000);
	            	y = math.asfloat(F32_DIVD + math.asuint(y) / 3);

                    float r = absX / y;
                    y = (y + y + r * (1f / y)) / (r + r + y * y);

                    if (!promises.Promises(Promise.NonZero))
                    {
                        ONE_THIRD = x == 0 ? float.PositiveInfinity : ONE_THIRD;
                    }
                }

                float c = ONE - (x * y) * (y * y);
                y *= ONE + ONE_THIRD * c;

                return y;
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 rcbrt(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.rcbrt_ps(RegisterConversion.ToV128(x), 2, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new float2(rcbrt(x.x, promises), rcbrt(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rcbrt(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.rcbrt_ps(RegisterConversion.ToV128(x), 3, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new float3(rcbrt(x.x, promises), rcbrt(x.y, promises), rcbrt(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 rcbrt(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.rcbrt_ps(RegisterConversion.ToV128(x), 4, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new float4(rcbrt(x.x, promises), rcbrt(x.y, promises), rcbrt(x.z, promises), rcbrt(x.w, promises));
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="MaxMath.float8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~1.175494E-38.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rcbrt(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_rcbrt_ps(x, promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1));
            }
            else
            {
                return new float8(rcbrt(x.v4_0, promises), rcbrt(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the reciprocal cube root of a <see cref="double"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.                                                              </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double rcbrt(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcbrt_pd(RegisterConversion.ToV128(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)).Double0;
            }
            else
            {
                bool POSITIVE = promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x > 0d);
                bool NON_ZERO = promises.Promises(Promise.NonZero) || constexpr.IS_TRUE(x != 0d);

                double absX = POSITIVE ? x : math.asdouble(math.asulong(x) & ((1ul << 63) - 1));
	            uint hi = (uint)(math.asulong(absX) >> 32);
                bool isInf = hi == (uint)(F64_SIGNALING_EXPONENT >> 32);
                ulong sign = math.asulong(x) & (1ul << 63);

                double y;
                double r;
                if (promises.Promises(Promise.Unsafe1) || Hint.Likely(math.asulong(absX) >= 0x0010_0000_0000_0000))
                {
                    hi = hi / 3 + F64_DIVC;

	                y = math.asdouble(sign | ((ulong)hi << 32));
                    r = (y * y) * (y * (1d / x));
                }
                else
                {
		            hi = (uint)(math.asulong(absX * math.asdouble(0x4350_0000_0000_0000ul)) >> 32);
		            hi = hi / 3 + F64_DIVD;

	                y = math.asdouble(sign | ((ulong)hi << 32));
                    r = (y * y) * (y / x);
                }

                y *= math.mad(r * r * r, math.mad(F64_C4, r, F64_C3), math.mad(math.mad(F64_C2, r, F64_C1), r, F64_C0));
                y = math.asdouble((math.asulong(y) + (1u << 31)) & ((NON_ZERO || x != 0d) ? 0xFFFF_FFFF_C000_0000ul : math.asulong(1d)));

                double add = y;
                double div = x;
                if (!NON_ZERO)
                {
                    add = x != 0 ? y : math.asdouble(sign | math.asulong(double.PositiveInfinity));
                }

                add += y;

                if (!promises.Promises(Promise.Unsafe0))
                {
                    div = isInf ? math.asdouble(sign) : x;
                    add = isInf ? math.asdouble(sign) : add;
                }

                r = div / y;
                y = (add + r * (1d / y)) / (r + r + y * y);

                return y;
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.                                                              </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 rcbrt(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.rcbrt_pd(RegisterConversion.ToV128(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1)));
            }
            else
            {
                return new double2(rcbrt(x.x, promises), rcbrt(x.y, promises));
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.                                                              </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 rcbrt(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_rcbrt_pd(RegisterConversion.ToV256(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1), 3));
            }
            else
            {
                return new double3(rcbrt(x.xy, promises), rcbrt(x.z, promises));
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.       </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for 0, including negative 0.                                                              </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for subnormal values, i.e. values with magnitude greater or equal to 0 and magnitude less than or equal to ~2.2250738585072E-308.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 rcbrt(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_rcbrt_pd(RegisterConversion.ToV256(x), promises.Promises(Promise.Positive), promises.Promises(Promise.NonZero), promises.Promises(Promise.Unsafe0), promises.Promises(Promise.Unsafe1), 4));
            }
            else
            {
                return new double4(rcbrt(x.xy, promises), rcbrt(x.zw, promises));
            }
        }
    }
}