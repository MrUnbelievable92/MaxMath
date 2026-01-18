#define EVEN_ON_TIE

using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 trunc_pq(v128 a, byte elements = 16, bool notNaNInf = false, bool positive = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU8(a, 0, elements) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements) && nonZero;

                    v128 SIGN_MASK = set1_epi8(maxmath.bitmask8(quarter.EXPONENT_BITS + quarter.MANTISSA_BITS));
                    v128 EXPONENT_BIAS = set1_epi8((byte)math.abs(quarter.EXPONENT_BIAS));
                    v128 MANTISSA_BITS = set1_epi8(quarter.MANTISSA_BITS);
                    v128 ONE = set1_epi8(1);

                    v128 rawExponent = and_si128(a, SIGN_MASK);
                    v128 unbiasedExponent = srli_epi8(rawExponent, quarter.MANTISSA_BITS);

                    v128 fractionBits = sub_epi8(add_epi8(MANTISSA_BITS, EXPONENT_BIAS), unbiasedExponent);
                    v128 validRange = cmprange_epu8(fractionBits, ONE, MANTISSA_BITS);
                    v128 mask = bitmask_epi8(fractionBits, elements: elements, promiseLT8: true);

                    v128 result = ternarylogic_si128(mask, a, validRange, TernaryOperation.OxO8);

                    // only here to preserve negative 0
                    if (!positive)
                    {
                        result = ternarylogic_si128(SIGN_MASK, a, result, TernaryOperation.OxAE);
                    }

                    if (!notNaNInf)
                    {
                        v128 SIGNALING_EXPONENT_M1 = set1_epi8(quarter.SIGNALING_EXPONENT - 1);

                        result = blendv_si128(result, a, cmpgt_epi8(rawExponent, SIGNALING_EXPONENT_M1));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 round_pq(v128 a, byte elements = 16, bool notNaNInf = false, bool positive = false, bool negative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU8(a, 0, elements) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi8(0b0111_1111);
                    v128 ONE = set1_epi8(1);
                    v128 ONES_AS_QUARTERS = set1_epi8(maxmath.ONE_AS_QUARTER);
                    v128 SIGNALING_EXPONENTS = set1_epi8(quarter.SIGNALING_EXPONENT);
                    v128 SHIFT_BASE = set1_epi8(maxmath.F8_ROUND_SHIFT_BASE);

                    v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = and_si128(ONES_AS_QUARTERS, cmpgt_epi8(__abs, blsr_epi8(ONES_AS_QUARTERS)));
                        #else
                            resultsLessThanOne = and_si128(ONES_AS_QUARTERS, cmpgt_epi8(__abs, dec_epi8(blsr_epi8(ONES_AS_QUARTERS))));
                        #endif
                    }
                    else if (negative)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_QUARTERS, cmpgt_epi8(__abs, blsr_epi8(ONES_AS_QUARTERS)), ABS_MASK, TernaryOperation.OxD5);
                        #else
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_QUARTERS, cmpgt_epi8(__abs, dec_epi8(blsr_epi8(ONES_AS_QUARTERS))), ABS_MASK, TernaryOperation.OxD5);
                        #endif
                    }
                    else
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_QUARTERS, cmpgt_epi8(__abs, blsr_epi8(ONES_AS_QUARTERS))), TernaryOperation.OxBA);
                        #else
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_QUARTERS, cmpgt_epi8(__abs, dec_epi8(blsr_epi8(ONES_AS_QUARTERS))), TernaryOperation.OxBA);
                        #endif
                    }

			    	v128 shifts = sub_epi8(SHIFT_BASE, srli_epi8(__abs, quarter.MANTISSA_BITS));
			    	v128 masks = bitmask_epi8(shifts, elements: elements, promiseLT8: true);
                    v128 resultsNonSignaling;
                    #if EVEN_ON_TIE
                        resultsNonSignaling = add_epi8(a, sub_epi8(sllv_epi8(ONE, dec_epi8(shifts), elements: elements), andnot_si128(srlv_epi8(a, shifts, elements: elements), ONE)));
                    #else
                        resultsNonSignaling = add_epi8(a, sllv_epi8(ONE, dec_epi8(shifts), elements: elements));
                    #endif

				    resultsNonSignaling = andnot_si128(masks, resultsNonSignaling);


                    if (notNaNInf)
                    {
                        v128 isLessThanOne = cmpgt_epi8(ONES_AS_QUARTERS, __abs);

                        return blendv_si128(resultsNonSignaling, resultsLessThanOne, isLessThanOne);
                    }
                    else
                    {
                        v128 isLessThanOne = cmpgt_epi8(ONES_AS_QUARTERS, __abs);
                        v128 IsNonSignaling = cmpgt_epi8(SIGNALING_EXPONENTS, __abs);

                        return blendv_si128(a, blendv_si128(resultsNonSignaling, resultsLessThanOne, isLessThanOne), IsNonSignaling);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floor_pq(v128 a, byte elements = 16, bool notNaNInf = false, bool positive = false, bool negative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU8(a, 0, elements) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi8(0b0111_1111);
                    v128 ONES_AS_QUARTERS = set1_epi8(maxmath.ONE_AS_QUARTER);
                    v128 SIGNALING_EXPONENTS = set1_epi8(quarter.SIGNALING_EXPONENT);
                    v128 SHIFT_BASE = set1_epi8(maxmath.F8_ROUND_SHIFT_BASE);

                    v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = setzero_si128();
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = ornot_si128(ABS_MASK, ONES_AS_QUARTERS);
                    }
                    else
                    {
                        resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_QUARTERS, cmpge_epu8(a, set1_epi8(0b1000_0001))), TernaryOperation.OxBA);
                    }

			    	v128 shifts = sub_epi8(SHIFT_BASE, srli_epi8(__abs, quarter.MANTISSA_BITS));
			    	v128 masks = bitmask_epi8(shifts, elements: elements, promiseLT8: true);

                    v128 resultsNonSignaling;
                    if (positive)
                    {
                        resultsNonSignaling = a;
                    }
                    else if (negative)
                    {
                        resultsNonSignaling = add_epi8(a, masks);
                    }
                    else
                    {
                        resultsNonSignaling = add_epi8(a, and_si128(masks, srai_epi8(a, 7, elements: elements)));
                    }

                    resultsNonSignaling = andnot_si128(masks, resultsNonSignaling);
                    v128 isLessThanOne = cmpgt_epi8(ONES_AS_QUARTERS, __abs);
                    v128 nonSignalingResults = blendv_si128(resultsNonSignaling, resultsLessThanOne, isLessThanOne);

                    if (notNaNInf)
                    {
                        return nonSignalingResults;
                    }
                    else
                    {
                        v128 IsNonSignaling = cmpgt_epi8(SIGNALING_EXPONENTS, __abs);

                        return blendv_si128(a, nonSignalingResults, IsNonSignaling);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceil_pq(v128 a, byte elements = 16, bool notNaNInf = false, bool positive = false, bool negative = false, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPU8(a, 0, elements) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi8(0b0111_1111);
                    v128 ONES_AS_QUARTERS = set1_epi8(maxmath.ONE_AS_QUARTER);
                    v128 SIGNALING_EXPONENTS = set1_epi8(quarter.SIGNALING_EXPONENT);
                    v128 SHIFT_BASE = set1_epi8(maxmath.F8_ROUND_SHIFT_BASE);

                    v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = ONES_AS_QUARTERS;
                    }
                    else
                    {
                        resultsLessThanOne = andnot_si128(ABS_MASK, a);
                        if (!negative)
                        {
                            v128 signTest = nonZero ? a : decs_epi8(a);
                            resultsLessThanOne = ternarylogic_si128(srai_epi8(signTest, 7), ONES_AS_QUARTERS, resultsLessThanOne, TernaryOperation.OxAE);
                        }
                    }

			    	v128 shifts = sub_epi8(SHIFT_BASE, srli_epi8(__abs, quarter.MANTISSA_BITS));
			    	v128 masks = bitmask_epi8(shifts, elements: elements, promiseLT8: true);

                    v128 resultsNonSignaling;
                    if (positive)
                    {
                        resultsNonSignaling = add_epi8(a, masks);
                    }
                    else if (negative)
                    {
                        resultsNonSignaling = a;
                    }
                    else
                    {
                        resultsNonSignaling = add_epi8(a, andnot_si128(srai_epi8(a, 7), masks));
                    }

				    resultsNonSignaling = andnot_si128(masks, resultsNonSignaling);

                    if (notNaNInf)
                    {
                        v128 isLessThanOne = cmpgt_epi8(ONES_AS_QUARTERS, __abs);

                        return blendv_si128(resultsNonSignaling, resultsLessThanOne, isLessThanOne);
                    }
                    else
                    {
                        v128 isLessThanOne = cmpgt_epi8(ONES_AS_QUARTERS, __abs);
                        v128 IsNonSignaling = cmpgt_epi8(SIGNALING_EXPONENTS, __abs);

                        return blendv_si128(a, blendv_si128(resultsNonSignaling, resultsLessThanOne, isLessThanOne), IsNonSignaling);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_trunc_pq(v256 a, bool notNaNInf = false, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU8(a, 0) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000) && nonZero;

                    v256 SIGN_MASK = mm256_set1_epi8(maxmath.bitmask8(quarter.EXPONENT_BITS + quarter.MANTISSA_BITS));
                    v256 EXPONENT_BIAS = mm256_set1_epi8((byte)math.abs(quarter.EXPONENT_BIAS));
                    v256 MANTISSA_BITS = mm256_set1_epi8(quarter.MANTISSA_BITS);
                    v256 ONE = mm256_set1_epi8(1);

                    v256 rawExponent = Avx2.mm256_and_si256(a, SIGN_MASK);
                    v256 unbiasedExponent = mm256_srli_epi8(rawExponent, quarter.MANTISSA_BITS);

                    v256 fractionBits = Avx2.mm256_sub_epi8(Avx2.mm256_add_epi8(MANTISSA_BITS, EXPONENT_BIAS), unbiasedExponent);
                    v256 validRange = mm256_cmprange_epu8(fractionBits, ONE, MANTISSA_BITS);
                    v256 mask = mm256_bitmask_epi8(fractionBits);

                    v256 result = mm256_ternarylogic_si256(mask, a, validRange, TernaryOperation.OxO8);

                    // only here to preserve negative 0
                    if (!positive)
                    {
                        result = mm256_ternarylogic_si256(SIGN_MASK, a, result, TernaryOperation.OxAE);
                    }

                    if (!notNaNInf)
                    {
                        v256 SIGNALING_EXPONENT_M1 = mm256_set1_epi8(quarter.SIGNALING_EXPONENT - 1);

                        result = mm256_blendv_si256(result, a, Avx2.mm256_cmpgt_epi8(rawExponent, SIGNALING_EXPONENT_M1));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_round_pq(v256 a, bool notNaNInf = false, bool positive = false, bool negative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU8(a, 0) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000) && nonZero;

                    v256 ABS_MASK = mm256_set1_epi8(0b0111_1111);
                    v256 ONE = mm256_set1_epi8(1);
                    v256 ONES_AS_QUARTERS = mm256_set1_epi8(maxmath.ONE_AS_QUARTER);
                    v256 SIGNALING_EXPONENTS = mm256_set1_epi8(quarter.SIGNALING_EXPONENT);
                    v256 SHIFT_BASE = mm256_set1_epi8(maxmath.F8_ROUND_SHIFT_BASE);

                    v256 __abs = positive ? a : Avx2.mm256_and_si256(a, ABS_MASK);

                    v256 resultsLessThanOne;
                    if (positive)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = Avx2.mm256_and_si256(ONES_AS_QUARTERS, Avx2.mm256_cmpgt_epi8(__abs, mm256_blsr_epi8(ONES_AS_QUARTERS)));
                        #else
                            resultsLessThanOne = Avx2.mm256_and_si256(ONES_AS_QUARTERS, Avx2.mm256_cmpgt_epi8(__abs, mm256_dec_epi8(mm256_blsr_epi8(ONES_AS_QUARTERS))));
                        #endif
                    }
                    else if (negative)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = mm256_ternarylogic_si256(ONES_AS_QUARTERS, Avx2.mm256_cmpgt_epi8(__abs, mm256_blsr_epi8(ONES_AS_QUARTERS)), ABS_MASK, TernaryOperation.OxD5);
                        #else
                            resultsLessThanOne = mm256_ternarylogic_si256(ONES_AS_QUARTERS, Avx2.mm256_cmpgt_epi8(__abs, mm256_dec_epi8(mm256_blsr_epi8(ONES_AS_QUARTERS))), ABS_MASK, TernaryOperation.OxD5);
                        #endif
                    }
                    else
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = mm256_ternarylogic_si256(a, ABS_MASK, Avx2.mm256_and_si256(ONES_AS_QUARTERS, Avx2.mm256_cmpgt_epi8(__abs, mm256_blsr_epi8(ONES_AS_QUARTERS))), TernaryOperation.OxBA);
                        #else
                            resultsLessThanOne = mm256_ternarylogic_si256(a, ABS_MASK, Avx2.mm256_and_si256(ONES_AS_QUARTERS, Avx2.mm256_cmpgt_epi8(__abs, mm256_dec_epi8(mm256_blsr_epi8(ONES_AS_QUARTERS))), TernaryOperation.OxBA);
                        #endif
                    }

			    	v256 shifts = Avx2.mm256_sub_epi8(SHIFT_BASE, mm256_srli_epi8(__abs, quarter.MANTISSA_BITS));
			    	v256 masks = mm256_bitmask_epi8(shifts);
                    v256 resultsNonSignaling;
                    #if EVEN_ON_TIE
                        resultsNonSignaling = Avx2.mm256_add_epi8(a, Avx2.mm256_sub_epi8(mm256_sllv_epi8(ONE, mm256_dec_epi8(shifts)), Avx2.mm256_andnot_si256(mm256_srlv_epi8(a, shifts), ONE)));
                    #else
                        resultsNonSignaling = Avx2.mm256_add_epi8(a, mm256_sllv_epi8(ONE, mm256_dec_epi8(shifts)));
                    #endif

				    resultsNonSignaling = Avx2.mm256_andnot_si256(masks, resultsNonSignaling);


                    if (notNaNInf)
                    {
                        v256 isLessThanOne = Avx2.mm256_cmpgt_epi8(ONES_AS_QUARTERS, __abs);

                        return mm256_blendv_si256(resultsNonSignaling, resultsLessThanOne, isLessThanOne);
                    }
                    else
                    {
                        v256 isLessThanOne = Avx2.mm256_cmpgt_epi8(ONES_AS_QUARTERS, __abs);
                        v256 IsNonSignaling = Avx2.mm256_cmpgt_epi8(SIGNALING_EXPONENTS, __abs);

                        return mm256_blendv_si256(a, mm256_blendv_si256(resultsNonSignaling, resultsLessThanOne, isLessThanOne), IsNonSignaling);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floor_pq(v256 a, bool notNaNInf = false, bool positive = false, bool negative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU8(a, 0) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000) && nonZero;

                    v256 ABS_MASK = mm256_set1_epi8(0b0111_1111);
                    v256 ONES_AS_QUARTERS = mm256_set1_epi8(maxmath.ONE_AS_QUARTER);
                    v256 SIGNALING_EXPONENTS = mm256_set1_epi8(quarter.SIGNALING_EXPONENT);
                    v256 SHIFT_BASE = mm256_set1_epi8(maxmath.F8_ROUND_SHIFT_BASE);

                    v256 __abs = positive ? a : Avx2.mm256_and_si256(a, ABS_MASK);

                    v256 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = Avx.mm256_setzero_si256();
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = mm256_ornot_si256(ABS_MASK, ONES_AS_QUARTERS);
                    }
                    else
                    {
                        resultsLessThanOne = mm256_ternarylogic_si256(a, ABS_MASK, Avx2.mm256_and_si256(ONES_AS_QUARTERS, mm256_cmpge_epu8(a, mm256_set1_epi8(0b1000_0001))), TernaryOperation.OxBA);
                    }

			    	v256 shifts = Avx2.mm256_sub_epi8(SHIFT_BASE, mm256_srli_epi8(__abs, quarter.MANTISSA_BITS));
			    	v256 masks = mm256_bitmask_epi8(shifts);

                    v256 resultsNonSignaling;
                    if (positive)
                    {
                        resultsNonSignaling = a;
                    }
                    else if (negative)
                    {
                        resultsNonSignaling = Avx2.mm256_add_epi8(a, masks);
                    }
                    else
                    {
                        resultsNonSignaling = Avx2.mm256_add_epi8(a, Avx2.mm256_and_si256(masks, mm256_srai_epi8(a, 7)));
                    }

                    resultsNonSignaling = Avx2.mm256_andnot_si256(masks, resultsNonSignaling);
                    v256 isLessThanOne = Avx2.mm256_cmpgt_epi8(ONES_AS_QUARTERS, __abs);
                    v256 nonSignalingResults = mm256_blendv_si256(resultsNonSignaling, resultsLessThanOne, isLessThanOne);

                    if (notNaNInf)
                    {
                        return nonSignalingResults;
                    }
                    else
                    {
                        v256 IsNonSignaling = Avx2.mm256_cmpgt_epi8(SIGNALING_EXPONENTS, __abs);

                        return mm256_blendv_si256(a, nonSignalingResults, IsNonSignaling);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceil_pq(v256 a, bool notNaNInf = false, bool positive = false, bool negative = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPU8(a, 0) && constexpr.ALL_NEQ_EPU8(a, 0b1000_0000);
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000) && nonZero;

                    v256 ABS_MASK = mm256_set1_epi8(0b0111_1111);
                    v256 ONES_AS_QUARTERS = mm256_set1_epi8(maxmath.ONE_AS_QUARTER);
                    v256 SIGNALING_EXPONENTS = mm256_set1_epi8(quarter.SIGNALING_EXPONENT);
                    v256 SHIFT_BASE = mm256_set1_epi8(maxmath.F8_ROUND_SHIFT_BASE);

                    v256 __abs = positive ? a : Avx2.mm256_and_si256(a, ABS_MASK);

                    v256 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = ONES_AS_QUARTERS;
                    }
                    else
                    {
                        resultsLessThanOne = Avx2.mm256_andnot_si256(ABS_MASK, a);
                        if (!negative)
                        {
                            v256 signTest = nonZero ? a : mm256_decs_epi8(a);
                            resultsLessThanOne = mm256_ternarylogic_si256(mm256_srai_epi8(signTest, 7), ONES_AS_QUARTERS, resultsLessThanOne, TernaryOperation.OxAE);
                        }
                    }

			    	v256 shifts = Avx2.mm256_sub_epi8(SHIFT_BASE, mm256_srli_epi8(__abs, quarter.MANTISSA_BITS));
			    	v256 masks = mm256_bitmask_epi8(shifts);

                    v256 resultsNonSignaling;
                    if (positive)
                    {
                        resultsNonSignaling = Avx2.mm256_add_epi8(a, masks);
                    }
                    else if (negative)
                    {
                        resultsNonSignaling = a;
                    }
                    else
                    {
                        resultsNonSignaling = Avx2.mm256_add_epi8(a, Avx2.mm256_andnot_si256(mm256_srai_epi8(a, 7), masks));
                    }

				    resultsNonSignaling = Avx2.mm256_andnot_si256(masks, resultsNonSignaling);

                    if (notNaNInf)
                    {
                        v256 isLessThanOne = Avx2.mm256_cmpgt_epi8(ONES_AS_QUARTERS, __abs);

                        return mm256_blendv_si256(resultsNonSignaling, resultsLessThanOne, isLessThanOne);
                    }
                    else
                    {
                        v256 isLessThanOne = Avx2.mm256_cmpgt_epi8(ONES_AS_QUARTERS, __abs);
                        v256 IsNonSignaling = Avx2.mm256_cmpgt_epi8(SIGNALING_EXPONENTS, __abs);

                        return mm256_blendv_si256(a, mm256_blendv_si256(resultsNonSignaling, resultsLessThanOne, isLessThanOne), IsNonSignaling);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 trunc_ph(v128 a, byte elements = 8, bool notNaNInf = false, bool positive = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU8(a, 0x8000, elements);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements) && nonZero;

                    v128 SIGN_MASK = set1_epi16(maxmath.bitmask16(F16_EXPONENT_BITS + F16_MANTISSA_BITS));
                    v128 EXPONENT_BIAS = set1_epi16((ushort)math.abs(F16_EXPONENT_BIAS));
                    v128 MANTISSA_BITS = set1_epi16(F16_MANTISSA_BITS);

                    v128 rawExponent = and_si128(a, SIGN_MASK);
                    v128 unbiasedExponent = srli_epi16(rawExponent, F16_MANTISSA_BITS);
                    v128 fractionBits = sub_epi16(add_epi16(MANTISSA_BITS, EXPONENT_BIAS), unbiasedExponent);

                    v128 mask = bitmask_epi16(fractionBits, elements: elements, promiseLT16: true);
                    v128 validRangeMask = cmpgt_epi16(MANTISSA_BITS, sub_epi16(unbiasedExponent, EXPONENT_BIAS));//srai_epi16(fractionBits, 15);

                    v128 result = and_si128(a, cmpgt_epi16(inc_epi16(MANTISSA_BITS), fractionBits));
                    result = ternarylogic_si128(mask, result, validRangeMask, TernaryOperation.Ox4C);

                    // only here to preserve negative 0
                    if (!positive)
                    {
                        result = ternarylogic_si128(SIGN_MASK, a, result, TernaryOperation.OxAE);
                    }

                    if (!notNaNInf)
                    {
                        v128 SIGNALING_EXPONENT_M1 = set1_epi16(F16_SIGNALING_EXPONENT - 1);

                        result = blendv_si128(result, a, cmpgt_epi16(rawExponent, SIGNALING_EXPONENT_M1));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 round_ph(v128 a, byte elements = 8, bool positive = false, bool negative = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU16(a, 0x8000, elements);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi16(0x7FFF);
                    v128 ONES_AS_HALFS = set1_epi16(maxmath.ONE_AS_HALF);
                    v128 MAX_PRECISE_I16 = set1_epi16(maxmath.asushort(LIMIT_PRECISE_U16_F16));
                    v128 SHIFT_BASE = set1_epi16(maxmath.F16_ROUND_SHIFT_BASE);
                    v128 ONE = set1_epi16(1);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = and_si128(ONES_AS_HALFS, cmpgt_epi16(__abs, blsr_epi16(ONES_AS_HALFS)));
                        #else
                            resultsLessThanOne = and_si128(ONES_AS_HALFS, cmpgt_epi16(__abs, dec_epi16(blsr_epi16(ONES_AS_HALFS))));
                        #endif
                    }
                    else if (negative)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_HALFS, cmpgt_epi16(__abs, blsr_epi16(ONES_AS_HALFS)), ABS_MASK, TernaryOperation.OxD5);
                        #else
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_HALFS, cmpgt_epi16(__abs, dec_epi16(blsr_epi8(ONES_AS_HALFS))), ABS_MASK, TernaryOperation.OxD5);
                        #endif
                    }
                    else
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_HALFS, cmpgt_epi16(__abs, blsr_epi16(ONES_AS_HALFS))), TernaryOperation.OxBA);
                        #else
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_HALFS, cmpgt_epi16(__abs, dec_epi16(blsr_epi16(ONES_AS_HALFS))), TernaryOperation.OxBA);
                        #endif
                    }

                    v128 shifts = sub_epi16(SHIFT_BASE, srli_epi16(__abs, F16_MANTISSA_BITS));
                    v128 masks = bitmask_epi16(shifts, elements: elements, promiseLT16: true);

                    v128 resultsWithFraction;
                    #if EVEN_ON_TIE
                        resultsWithFraction = add_epi16(a, sub_epi16(sllv_epi16(ONE, dec_epi16(shifts), elements: elements), andnot_si128(srlv_epi16(a, shifts, elements: elements), ONE)));
                    #else
                        resultsWithFraction = add_epi16(a, sllv_epi16(ONE, dec_epi16(shifts), elements: elements));
                    #endif
				    resultsWithFraction = andnot_si128(masks, resultsWithFraction);


                    v128 isLessThanOne = cmpgt_epi16(ONES_AS_HALFS, __abs);
                    v128 hasFraction = cmpgt_epi16(MAX_PRECISE_I16, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floor_ph(v128 a, byte elements = 8, bool positive = false, bool negative = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU16(a, 0x8000, elements);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi16(0x7FFF);
                    v128 ONES_AS_HALFS = set1_epi16(maxmath.ONE_AS_HALF);
                    v128 MAX_PRECISE_I16 = set1_epi16(maxmath.asushort(LIMIT_PRECISE_U16_F16));
                    v128 SHIFT_BASE = set1_epi16(maxmath.F16_ROUND_SHIFT_BASE);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = setzero_si128();
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = ornot_si128(ABS_MASK, ONES_AS_HALFS);
                    }
                    else
                    {
                        resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_HALFS, cmpge_epu16(a, set1_epi16(0x8001))), TernaryOperation.OxBA);
                    }

                    v128 shifts = sub_epi16(SHIFT_BASE, srli_epi16(__abs, F16_MANTISSA_BITS));
                    v128 masks = bitmask_epi16(shifts, elements: elements, promiseLT16: true);

                    v128 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = a;
                    }
                    else if (negative)
                    {
                        resultsWithFraction = add_epi16(a, masks);
                    }
                    else
                    {
                        resultsWithFraction = add_epi16(a, and_si128(masks, srai_epi16(a, 15)));
                    }

                    resultsWithFraction = andnot_si128(masks, resultsWithFraction);

                    v128 isLessThanOne = cmpgt_epi16(ONES_AS_HALFS, __abs);
                    v128 hasFraction = cmpgt_epi16(MAX_PRECISE_I16, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceil_ph(v128 a, byte elements = 8, bool positive = false, bool negative = false, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU16(a, 0x8000, elements);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi16(0x7FFF);
                    v128 ONES_AS_HALFS = set1_epi16(maxmath.ONE_AS_HALF);
                    v128 MAX_PRECISE_I16 = set1_epi16(maxmath.asushort(LIMIT_PRECISE_U16_F16));
                    v128 SHIFT_BASE = set1_epi16(maxmath.F16_ROUND_SHIFT_BASE);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = ONES_AS_HALFS;
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = andnot_si128(ABS_MASK, a);
                    }
                    else
                    {
                        v128 signTest = nonZero ? a : decs_epi16(a);
                        resultsLessThanOne = ternarylogic_si128(srai_epi16(signTest, 15), ONES_AS_HALFS, andnot_si128(ABS_MASK, a), TernaryOperation.OxAE);
                    }

                    v128 shifts = sub_epi16(SHIFT_BASE, srli_epi16(__abs, F16_MANTISSA_BITS));
                    v128 masks = bitmask_epi16(shifts, elements: elements, promiseLT16: true);

                    v128 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = add_epi16(a, masks);
                    }
                    else if (negative)
                    {
                        resultsWithFraction = a;
                    }
                    else
                    {
                        resultsWithFraction = add_epi16(a, andnot_si128(srai_epi16(a, 15), masks));
                    }

                    resultsWithFraction = andnot_si128(masks, resultsWithFraction);

                    v128 isLessThanOne = cmpgt_epi16(ONES_AS_HALFS, __abs);
                    v128 hasFraction = cmpgt_epi16(MAX_PRECISE_I16, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_trunc_ph(v256 a, bool notNaNInf = false, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0) && constexpr.ALL_NEQ_EPU8(a, 0x8000);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000) && nonZero;

                    v256 SIGN_MASK = mm256_set1_epi16(maxmath.bitmask16(F16_EXPONENT_BITS + F16_MANTISSA_BITS));
                    v256 EXPONENT_BIAS = mm256_set1_epi16((ushort)math.abs(F16_EXPONENT_BIAS));
                    v256 MANTISSA_BITS = mm256_set1_epi16(F16_MANTISSA_BITS);

                    v256 rawExponent = Avx2.mm256_and_si256(a, SIGN_MASK);
                    v256 unbiasedExponent = Avx2.mm256_srli_epi16(rawExponent, F16_MANTISSA_BITS);
                    v256 fractionBits = Avx2.mm256_sub_epi16(Avx2.mm256_add_epi16(MANTISSA_BITS, EXPONENT_BIAS), unbiasedExponent);

                    v256 mask = mm256_bitmask_epi16(fractionBits, promiseLT16: true);
                    v256 validRangeMask = Avx2.mm256_cmpgt_epi16(MANTISSA_BITS, Avx2.mm256_sub_epi16(unbiasedExponent, EXPONENT_BIAS));//srai_epi16(fractionBits, 15);

                    v256 result = Avx2.mm256_and_si256(a, Avx2.mm256_cmpgt_epi16(mm256_inc_epi16(MANTISSA_BITS), fractionBits));
                    result = mm256_ternarylogic_si256(mask, result, validRangeMask, TernaryOperation.Ox4C);

                    // only here to preserve negative 0
                    if (!positive)
                    {
                        result = mm256_ternarylogic_si256(SIGN_MASK, a, result, TernaryOperation.OxAE);
                    }

                    if (!notNaNInf)
                    {
                        v256 SIGNALING_EXPONENT_M1 = mm256_set1_epi16(F16_SIGNALING_EXPONENT - 1);

                        result = mm256_blendv_si256(result, a, Avx2.mm256_cmpgt_epi16(rawExponent, SIGNALING_EXPONENT_M1));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_round_ph(v256 a, bool positive = false, bool negative = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0) && constexpr.ALL_NEQ_EPU16(a, 0x8000);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000) && nonZero;

                    v256 ABS_MASK = mm256_set1_epi16(0x7FFF);
                    v256 ONES_AS_HALFS = mm256_set1_epi16(maxmath.ONE_AS_HALF);
                    v256 MAX_PRECISE_I16 = mm256_set1_epi16(maxmath.asushort(LIMIT_PRECISE_U16_F16));
                    v256 SHIFT_BASE = mm256_set1_epi16(maxmath.F16_ROUND_SHIFT_BASE);
                    v256 ONE = mm256_set1_epi16(1);

			        v256 __abs = positive ? a : Avx2.mm256_and_si256(a, ABS_MASK);

                    v256 resultsLessThanOne;
                    if (positive)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = Avx2.mm256_and_si256(ONES_AS_HALFS, Avx2.mm256_cmpgt_epi16(__abs, mm256_blsr_epi16(ONES_AS_HALFS)));
                        #else
                            resultsLessThanOne = Avx2.mm256_and_si256(ONES_AS_HALFS, Avx2.mm256_cmpgt_epi16(__abs, mm256_dec_epi16(mm256_blsr_epi16(ONES_AS_HALFS))));
                        #endif
                    }
                    else if (negative)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = mm256_ternarylogic_si256(ONES_AS_HALFS, Avx2.mm256_cmpgt_epi16(__abs, mm256_blsr_epi16(ONES_AS_HALFS)), ABS_MASK, TernaryOperation.OxD5);
                        #else
                            resultsLessThanOne = mm256_ternarylogic_si256(ONES_AS_HALFS, Avx2.mm256_cmpgt_epi16(__abs, mm256_dec_epi16(mm256_blsr_epi8(ONES_AS_HALFS))), ABS_MASK, TernaryOperation.OxD5);
                        #endif
                    }
                    else
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = mm256_ternarylogic_si256(a, ABS_MASK, Avx2.mm256_and_si256(ONES_AS_HALFS, Avx2.mm256_cmpgt_epi16(__abs, mm256_blsr_epi16(ONES_AS_HALFS))), TernaryOperation.OxBA);
                        #else
                            resultsLessThanOne = mm256_ternarylogic_si256(a, ABS_MASK, Avx2.mm256_and_si256(ONES_AS_HALFS, Avx2.mm256_cmpgt_epi16(__abs, mm256_dec_epi16(mm256_blsr_epi16(ONES_AS_HALFS))), TernaryOperation.OxBA);
                        #endif
                    }

                    v256 shifts = Avx2.mm256_sub_epi16(SHIFT_BASE, Avx2.mm256_srli_epi16(__abs, F16_MANTISSA_BITS));
                    v256 masks = mm256_bitmask_epi16(shifts, promiseLT16: true);

                    v256 resultsWithFraction;
                    #if EVEN_ON_TIE
                        resultsWithFraction = Avx2.mm256_add_epi16(a, Avx2.mm256_sub_epi16(mm256_sllv_epi16(ONE, mm256_dec_epi16(shifts)), Avx2.mm256_andnot_si256(mm256_srlv_epi16(a, shifts), ONE)));
                    #else
                        resultsWithFraction = Avx2.mm256_add_epi16(a, mm256_sllv_epi16(ONE, mm256_dec_epi16(shifts)));
                    #endif
				    resultsWithFraction = Avx2.mm256_andnot_si256(masks, resultsWithFraction);


                    v256 isLessThanOne = Avx2.mm256_cmpgt_epi16(ONES_AS_HALFS, __abs);
                    v256 hasFraction = Avx2.mm256_cmpgt_epi16(MAX_PRECISE_I16, __abs);

                    return mm256_blendv_si256(a, mm256_blendv_si256(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floor_ph(v256 a, bool positive = false, bool negative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0) && constexpr.ALL_NEQ_EPU16(a, 0x8000);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000) && nonZero;

                    v256 ABS_MASK = mm256_set1_epi16(0x7FFF);
                    v256 ONES_AS_HALFS = mm256_set1_epi16(maxmath.ONE_AS_HALF);
                    v256 MAX_PRECISE_I16 = mm256_set1_epi16(maxmath.asushort(LIMIT_PRECISE_U16_F16));
                    v256 SHIFT_BASE = mm256_set1_epi16(maxmath.F16_ROUND_SHIFT_BASE);

			        v256 __abs = positive ? a : Avx2.mm256_and_si256(a, ABS_MASK);

                    v256 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = Avx.mm256_setzero_si256();
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = mm256_ornot_si256(ABS_MASK, ONES_AS_HALFS);
                    }
                    else
                    {
                        resultsLessThanOne = mm256_ternarylogic_si256(a, ABS_MASK, Avx2.mm256_and_si256(ONES_AS_HALFS, mm256_cmpge_epu16(a, mm256_set1_epi16(0x8001))), TernaryOperation.OxBA);
                    }

                    v256 shifts = Avx2.mm256_sub_epi16(SHIFT_BASE, Avx2.mm256_srli_epi16(__abs, F16_MANTISSA_BITS));
                    v256 masks = mm256_bitmask_epi16(shifts, promiseLT16: true);

                    v256 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = a;
                    }
                    else if (negative)
                    {
                        resultsWithFraction = Avx2.mm256_add_epi16(a, masks);
                    }
                    else
                    {
                        resultsWithFraction = Avx2.mm256_add_epi16(a, Avx2.mm256_and_si256(masks, Avx2.mm256_srai_epi16(a, 15)));
                    }

                    resultsWithFraction = Avx2.mm256_andnot_si256(masks, resultsWithFraction);

                    v256 isLessThanOne = Avx2.mm256_cmpgt_epi16(ONES_AS_HALFS, __abs);
                    v256 hasFraction = Avx2.mm256_cmpgt_epi16(MAX_PRECISE_I16, __abs);

                    return mm256_blendv_si256(a, mm256_blendv_si256(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_ceil_ph(v256 a, bool positive = false, bool negative = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPU16(a, 0) && constexpr.ALL_NEQ_EPU16(a, 0x8000);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000) && nonZero;

                    v256 ABS_MASK = mm256_set1_epi16(0x7FFF);
                    v256 ONES_AS_HALFS = mm256_set1_epi16(maxmath.ONE_AS_HALF);
                    v256 MAX_PRECISE_I16 = mm256_set1_epi16(maxmath.asushort(LIMIT_PRECISE_U16_F16));
                    v256 SHIFT_BASE = mm256_set1_epi16(maxmath.F16_ROUND_SHIFT_BASE);

			        v256 __abs = positive ? a : Avx2.mm256_and_si256(a, ABS_MASK);

                    v256 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = ONES_AS_HALFS;
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = Avx2.mm256_andnot_si256(ABS_MASK, a);
                    }
                    else
                    {
                        v256 signTest = nonZero ? a : mm256_decs_epi16(a);
                        resultsLessThanOne = mm256_ternarylogic_si256(Avx2.mm256_srai_epi16(signTest, 15), ONES_AS_HALFS, Avx2.mm256_andnot_si256(ABS_MASK, a), TernaryOperation.OxAE);
                    }

                    v256 shifts = Avx2.mm256_sub_epi16(SHIFT_BASE, Avx2.mm256_srli_epi16(__abs, F16_MANTISSA_BITS));
                    v256 masks = mm256_bitmask_epi16(shifts, promiseLT16: true);

                    v256 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = Avx2.mm256_add_epi16(a, masks);
                    }
                    else if (negative)
                    {
                        resultsWithFraction = a;
                    }
                    else
                    {
                        resultsWithFraction = Avx2.mm256_add_epi16(a, Avx2.mm256_andnot_si256(Avx2.mm256_srai_epi16(a, 15), masks));
                    }

                    resultsWithFraction = Avx2.mm256_andnot_si256(masks, resultsWithFraction);

                    v256 isLessThanOne = Avx2.mm256_cmpgt_epi16(ONES_AS_HALFS, __abs);
                    v256 hasFraction = Avx2.mm256_cmpgt_epi16(MAX_PRECISE_I16, __abs);

                    return mm256_blendv_si256(a, mm256_blendv_si256(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        internal const byte ONE_AS_QUARTER = 0b0011_0000;
        internal const ushort ONE_AS_HALF = 0x3C00;

        internal static byte F8_ROUND_SHIFT_BASE => (byte)(quarter.MANTISSA_BITS + math.abs(quarter.EXPONENT_BIAS));
        internal static ushort F16_ROUND_SHIFT_BASE => (ushort)(F16_MANTISSA_BITS + math.abs(F16_EXPONENT_BIAS));


        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.quarter"/> to an integral <see cref="MaxMath.quarter"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter trunc(quarter x, Promise promises = Promise.Nothing)
        {
            const byte SIGN_MASK = 0b0111_1111;


            byte rawExponent = (byte)(x.value & SIGN_MASK);

            if (!(promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE((x.value & SIGN_MASK) < quarter.SIGNALING_EXPONENT)))
            {
                if (Hint.Unlikely(rawExponent >= quarter.SIGNALING_EXPONENT))
                {
                    return x;
                }
            }

            int unbiasedExponent = rawExponent >> quarter.MANTISSA_BITS;
            int fractionBits = (quarter.MANTISSA_BITS + math.abs(quarter.EXPONENT_BIAS)) - unbiasedExponent;
            int mask = (1 << fractionBits) - 1;

            int result = x.value & -tobyte(isinrange(fractionBits, 1, quarter.MANTISSA_BITS));
            result = andnot(result, mask);

            // only here to preserve negative 0
            if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x.value < 0b1000_0000)))
            {
                result |= andnot(x.value, SIGN_MASK);
            }

            return asquarter((byte)result);
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.quarter2"/> to an integral <see cref="MaxMath.quarter2"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 trunc(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_pq(x, 2, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter2(trunc(x.x, promises), trunc(x.y, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.quarter3"/> to an integral <see cref="MaxMath.quarter3"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 trunc(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_pq(x, 3, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter3(trunc(x.x, promises), trunc(x.y, promises), trunc(x.z, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.quarter4"/> to an integral <see cref="MaxMath.quarter4"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 trunc(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_pq(x, 4, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter4(trunc(x.x, promises), trunc(x.y, promises), trunc(x.z, promises), trunc(x.w, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.quarter8"/> to an integral <see cref="MaxMath.quarter8"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 trunc(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_pq(x, 8, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter8(trunc(x.x0, promises),
                                    trunc(x.x1, promises),
                                    trunc(x.x2, promises),
                                    trunc(x.x3, promises),
                                    trunc(x.x4, promises),
                                    trunc(x.x5, promises),
                                    trunc(x.x6, promises),
                                    trunc(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.quarter16"/> to an integral <see cref="MaxMath.quarter16"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 trunc(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_pq(x, 16, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter16(trunc(x.x0, promises),
                                     trunc(x.x1, promises),
                                     trunc(x.x2, promises),
                                     trunc(x.x3, promises),
                                     trunc(x.x4, promises),
                                     trunc(x.x5, promises),
                                     trunc(x.x6, promises),
                                     trunc(x.x7, promises),
                                     trunc(x.x8, promises),
                                     trunc(x.x9, promises),
                                     trunc(x.x10, promises),
                                     trunc(x.x11, promises),
                                     trunc(x.x12, promises),
                                     trunc(x.x13, promises),
                                     trunc(x.x14, promises),
                                     trunc(x.x15, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.quarter32"/> to an integral <see cref="MaxMath.quarter32"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 trunc(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_trunc_pq(x, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter32(trunc(x.v16_0, promises), trunc(x.v16_16, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.quarter"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter round(quarter x, Promise promises = Promise.Nothing)
        {
			int result = x.value;
			int __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= 0b0111_1111;
            }

			if (Hint.Unlikely(__abs < ONE_AS_QUARTER))
			{
                if (promises.Promises(Promise.Positive))
                {
                    #if EVEN_ON_TIE
                        result = ONE_AS_QUARTER & -tobyte(__abs >= (byte)(bits_resetlowest(ONE_AS_QUARTER) | 1));
                    #else
                        result = ONE_AS_QUARTER & -tobyte(__abs >= bits_resetlowest(ONE_AS_QUARTER));
                    #endif
                }
                else if (promises.Promises(Promise.Negative))
                {
                    #if EVEN_ON_TIE
                        result = __abs >= (byte)(bits_resetlowest(ONE_AS_QUARTER) | 1) ? (0b1000_0000 | ONE_AS_QUARTER) : 0b1000_0000;
                    #else
                        result = __abs >= bits_resetlowest(ONE_AS_QUARTER) ? (0b1000_0000 | ONE_AS_QUARTER) : 0b1000_0000;
                    #endif
                }
                else
                {
				    result &= 0b1000_0000;

                    #if EVEN_ON_TIE
                        result |= ONE_AS_QUARTER & -tobyte(__abs >= (byte)(bits_resetlowest(ONE_AS_QUARTER) | 1));
                    #else
                        result |= ONE_AS_QUARTER & -tobyte(__abs >= bits_resetlowest(ONE_AS_QUARTER));
                    #endif
                }
			}
			else
			{
                if (!promises.Promises(Promise.Unsafe0))
                {
                    if (__abs >= quarter.SIGNALING_EXPONENT)
                    {
                        return asquarter((byte)result);
                    }
                }

				int shift = F8_ROUND_SHIFT_BASE - (__abs >> quarter.MANTISSA_BITS);
				int mask = bitmask8(shift);

                #if EVEN_ON_TIE
                    result += (1 << (shift - 1)) - andnot(1, result >> shift);
                #else
                    result += 1 << (shift - 1);
                #endif

				result = andnot(result, mask);
			}

			return asquarter((byte)result);
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter2"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 round(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_pq(x, elements: 2, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter2(round(x.x, promises), round(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter3"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 round(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_pq(x, elements: 3, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter3(round(x.x, promises), round(x.y, promises), round(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter4"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 round(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_pq(x, elements: 4, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter4(round(x.x, promises), round(x.y, promises), round(x.z, promises), round(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter8"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 round(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_pq(x, elements: 8, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter8(round(x.x0, promises),
                                    round(x.x1, promises),
                                    round(x.x2, promises),
                                    round(x.x3, promises),
                                    round(x.x4, promises),
                                    round(x.x5, promises),
                                    round(x.x6, promises),
                                    round(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter16"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 round(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_pq(x, elements: 16, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter16(round(x.x0, promises),
                                     round(x.x1, promises),
                                     round(x.x2, promises),
                                     round(x.x3, promises),
                                     round(x.x4, promises),
                                     round(x.x5, promises),
                                     round(x.x6, promises),
                                     round(x.x7, promises),
                                     round(x.x8, promises),
                                     round(x.x9, promises),
                                     round(x.x10, promises),
                                     round(x.x11, promises),
                                     round(x.x12, promises),
                                     round(x.x13, promises),
                                     round(x.x14, promises),
                                     round(x.x15, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter32"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 round(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_round_pq(x, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter32(round(x.v16_0, promises), round(x.v16_16, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.quarter"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter floor(quarter x, Promise promises = Promise.Nothing)
        {
			int result = x.value;
			int __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= 0b0111_1111;
            }

			if (Hint.Unlikely(__abs < ONE_AS_QUARTER))
			{
                if (promises.Promises(Promise.Positive))
                {
                    result = 0;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    result = 0b1000_0000 | ONE_AS_QUARTER;
                }
                else
                {
				    result &= 0b1000_0000;
                    result |= ONE_AS_QUARTER & -tobyte(x.value > 0b1000_0000);
                }
			}
			else
			{
                if (!promises.Promises(Promise.Unsafe0))
                {
                    if (__abs >= quarter.SIGNALING_EXPONENT)
                    {
                        return asquarter((byte)result);
                    }
                }

				int shift = F8_ROUND_SHIFT_BASE - (__abs >> quarter.MANTISSA_BITS);
				int mask = bitmask8(shift);

                if (promises.Promises(Promise.Positive))
                {
                    ;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    result += mask;
                }
                else
                {
				    result += mask & ((sbyte)x.value >> 7);
                }

				result = andnot(result, mask);
			}

			return asquarter((byte)result);
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter2"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 floor(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_pq(x, elements: 2, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter2(floor(x.x, promises), floor(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter3"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 floor(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_pq(x, elements: 3, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter3(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter4"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 floor(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_pq(x, elements: 4, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter4(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises), floor(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter8"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 floor(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_pq(x, elements: 8, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter8(floor(x.x0, promises),
                                    floor(x.x1, promises),
                                    floor(x.x2, promises),
                                    floor(x.x3, promises),
                                    floor(x.x4, promises),
                                    floor(x.x5, promises),
                                    floor(x.x6, promises),
                                    floor(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter16"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 floor(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_pq(x, elements: 16, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter16(floor(x.x0, promises),
                                     floor(x.x1, promises),
                                     floor(x.x2, promises),
                                     floor(x.x3, promises),
                                     floor(x.x4, promises),
                                     floor(x.x5, promises),
                                     floor(x.x6, promises),
                                     floor(x.x7, promises),
                                     floor(x.x8, promises),
                                     floor(x.x9, promises),
                                     floor(x.x10, promises),
                                     floor(x.x11, promises),
                                     floor(x.x12, promises),
                                     floor(x.x13, promises),
                                     floor(x.x14, promises),
                                     floor(x.x15, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter32"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 floor(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floor_pq(x, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter32(floor(x.v16_0, promises), floor(x.v16_16, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.quarter"/> up to the nearest value greater or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter ceil(quarter x, Promise promises = Promise.Nothing)
        {
			int result = x.value;
			int __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= 0b0111_1111;
            }

			if (Hint.Unlikely(__abs < ONE_AS_QUARTER))
			{
                if (promises.Promises(Promise.Positive))
                {
                    result = ONE_AS_QUARTER;
                }
                else
                {
                    result &= 0b1000_0000;

                    if (!promises.Promises(Promise.Negative))
                    {
                        byte signTest = x.value;
                        if (!promises.Promises(Promise.NonZero))
                        {
                            signTest -= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? tobyte(x.value != 1 << 7) : (byte)1;
                        }

                        result |= andnot(ONE_AS_QUARTER, (sbyte)signTest >> 7);
                    }
                }
			}
			else
			{
                if (!promises.Promises(Promise.Unsafe0))
                {
                    if (__abs >= quarter.SIGNALING_EXPONENT)
                    {
                        return asquarter((byte)result);
                    }
                }

				int shift = F8_ROUND_SHIFT_BASE - (__abs >> quarter.MANTISSA_BITS);
				int mask = bitmask8(shift);

                if (promises.Promises(Promise.Positive))
                {
                    result += mask;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    ;
                }
                else
                {
				    result += andnot(mask, (sbyte)x.value >> 7);
                }

				result = andnot(result, mask);
			}

			return asquarter((byte)result);
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter2"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 ceil(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 2, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter2(ceil(x.x, promises), ceil(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter3"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 ceil(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 3, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter3(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter4"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 ceil(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 4, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter4(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises), ceil(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter8"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 ceil(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 8, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter8(ceil(x.x0, promises),
                                    ceil(x.x1, promises),
                                    ceil(x.x2, promises),
                                    ceil(x.x3, promises),
                                    ceil(x.x4, promises),
                                    ceil(x.x5, promises),
                                    ceil(x.x6, promises),
                                    ceil(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter16"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 ceil(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 16, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter16(ceil(x.x0, promises),
                                     ceil(x.x1, promises),
                                     ceil(x.x2, promises),
                                     ceil(x.x3, promises),
                                     ceil(x.x4, promises),
                                     ceil(x.x5, promises),
                                     ceil(x.x6, promises),
                                     ceil(x.x7, promises),
                                     ceil(x.x8, promises),
                                     ceil(x.x9, promises),
                                     ceil(x.x10, promises),
                                     ceil(x.x11, promises),
                                     ceil(x.x12, promises),
                                     ceil(x.x13, promises),
                                     ceil(x.x14, promises),
                                     ceil(x.x15, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter32"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 ceil(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceil_pq(x, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new quarter32(ceil(x.v16_0, promises), ceil(x.v16_16, promises));
            }
        }


        /// <summary>       Returns the result of a truncation of a <see cref="half"/> to an integral <see cref="half"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half trunc(half x, Promise promises = Promise.Nothing)
        {
            const ushort SIGN_MASK = 0x7FFF;


            ushort rawExponent = (ushort)(x.value & SIGN_MASK);

            if (!(promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE((x.value & SIGN_MASK) < F16_SIGNALING_EXPONENT)))
            {
                if (Hint.Unlikely(rawExponent >= F16_SIGNALING_EXPONENT))
                {
                    return x;
                }
            }

            int unbiasedExponent = rawExponent >> F16_MANTISSA_BITS;
            int fractionBits = (F16_MANTISSA_BITS + math.abs(F16_EXPONENT_BIAS)) - unbiasedExponent;

            int mask = (1 << fractionBits) - 1;
            ushort validRangeMask = (ushort)-tobyte(unbiasedExponent - math.abs(F16_EXPONENT_BIAS) < F16_MANTISSA_BITS);

            int result = x.value & -tobyte(fractionBits <= F16_MANTISSA_BITS);
            result = andnot(result, mask & validRangeMask);

            // only here to preserve negative 0
            if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x.value < 0x8000)))
            {
                result |= andnot(x.value, SIGN_MASK);
            }

            return ashalf((ushort)result);
        }

        /// <summary>       Returns the result of a truncation of a <see cref="half2"/> to an integral <see cref="half2"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 trunc(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.trunc_ph(RegisterConversion.ToV128(x), 2, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive)));
            }
            else
            {
                return new half2(trunc(x.x, promises), trunc(x.y, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.half3"/> to an integral <see cref="MaxMath.half3"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 trunc(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.trunc_ph(RegisterConversion.ToV128(x), 3, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive)));
            }
            else
            {
                return new half3(trunc(x.x, promises), trunc(x.y, promises), trunc(x.z, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="half4"/> to an integral <see cref="half4"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 trunc(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.trunc_ph(RegisterConversion.ToV128(x), 4, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive)));
            }
            else
            {
                return new half4(trunc(x.x, promises), trunc(x.y, promises), trunc(x.z, promises), trunc(x.w, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.half8"/> to an integral <see cref="MaxMath.half8"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 trunc(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_ph(x, 8, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new half8(trunc(x.x0, promises),
                                 trunc(x.x1, promises),
                                 trunc(x.x2, promises),
                                 trunc(x.x3, promises),
                                 trunc(x.x4, promises),
                                 trunc(x.x5, promises),
                                 trunc(x.x6, promises),
                                 trunc(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.half16"/> to an integral <see cref="MaxMath.half16"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns postive 0 if truncating a negative <paramref name="x"/> would result in negative 0 when adhering to the IEEE 754 standard.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 trunc(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_trunc_ph(x, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new half16(trunc(x.v8_0, promises), trunc(x.v8_8, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="half"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half round(half x, Promise promises = Promise.Nothing)
        {
			int result = x.value;
			int __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= 0x7FFF;
            }

			if (Hint.Unlikely(__abs < ONE_AS_HALF))
			{
                if (promises.Promises(Promise.Positive))
                {
                    #if EVEN_ON_TIE
                        result = ONE_AS_HALF & -tobyte(__abs >= (ushort)(bits_resetlowest(ONE_AS_HALF) | 1));
                    #else
                        result = ONE_AS_HALF & -tobyte(__abs >= bits_resetlowest(ONE_AS_HALF));
                    #endif
                }
                else if (promises.Promises(Promise.Negative))
                {
                    #if EVEN_ON_TIE
                        result = __abs >= (ushort)(bits_resetlowest(ONE_AS_HALF) | 1) ? (0x8000 | ONE_AS_HALF) : 0x8000;
                    #else
                        result = __abs >= bits_resetlowest(ONE_AS_HALF) ? (0x8000 | ONE_AS_HALF) : 0x8000;
                    #endif
                }
                else
                {
				    result &= 0x8000;

                    #if EVEN_ON_TIE
                        result |= ONE_AS_HALF & -tobyte(__abs >= (ushort)(bits_resetlowest(ONE_AS_HALF) | 1));
                    #else
                        result |= ONE_AS_HALF & -tobyte(__abs >= bits_resetlowest(ONE_AS_HALF));
                    #endif
                }
			}
			else if (__abs < asushort(LIMIT_PRECISE_U16_F16))
			{
				int shift = F16_ROUND_SHIFT_BASE - (__abs >> F16_MANTISSA_BITS);
				int mask = bitmask16(shift);

                #if EVEN_ON_TIE
                    result += (1 << (shift - 1)) - andnot(1, result >> shift);
                #else
                    result += 1 << (shift - 1);
                #endif

				result = andnot(result, mask);
			}

			return ashalf((ushort)result);
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half2"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 round(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.round_ph(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half2(round(x.x, promises), round(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half3"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 round(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.round_ph(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half3(round(x.x, promises), round(x.y, promises), round(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half4"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 round(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.round_ph(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half4(round(x.x, promises), round(x.y, promises), round(x.z, promises), round(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half8"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 round(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_ph(x, elements: 8, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half8(round(x.x0, promises),
                                 round(x.x1, promises),
                                 round(x.x2, promises),
                                 round(x.x3, promises),
                                 round(x.x4, promises),
                                 round(x.x5, promises),
                                 round(x.x6, promises),
                                 round(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half16"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 round(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_round_ph(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half16(round(x.v8_0, promises), round(x.v8_8, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="half"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half floor(half x, Promise promises = Promise.Nothing)
        {
			int result = x.value;
			int __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= 0x7FFF;
            }

			if (Hint.Unlikely(__abs < ONE_AS_HALF))
			{
                if (promises.Promises(Promise.Positive))
                {
                    result = 0;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    result = (0x8000 | ONE_AS_HALF);
                }
                else
                {
				    result &= 0x8000;
                    result |= ONE_AS_HALF & -tobyte(x.value > 0x8000);
                }
			}
			else if (__abs < asushort(LIMIT_PRECISE_U16_F16))
			{
				int shift = F16_ROUND_SHIFT_BASE - (__abs >> F16_MANTISSA_BITS);
				int mask = bitmask16(shift);

                if (promises.Promises(Promise.Positive))
                {
                    ;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    result += mask;
                }
                else
                {
				    result += mask & ((short)x.value >> 15);
                }

				result = andnot(result, mask);
			}

			return ashalf((ushort)result);
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half2"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 floor(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.floor_ph(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half2(floor(x.x, promises), floor(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half3"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 floor(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.floor_ph(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half3(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half4"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 floor(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.floor_ph(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half4(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises), floor(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half8"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 floor(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_ph(x, elements: 8, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half8(floor(x.x0, promises),
                                 floor(x.x1, promises),
                                 floor(x.x2, promises),
                                 floor(x.x3, promises),
                                 floor(x.x4, promises),
                                 floor(x.x5, promises),
                                 floor(x.x6, promises),
                                 floor(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half16"/> down to the nearest value less or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 floor(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floor_ph(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half16(floor(x.v8_0, promises), floor(x.v8_8, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="half"/> up to the nearest value greater or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half ceil(half x, Promise promises = Promise.Nothing)
        {
			int result = x.value;
			int __abs = result;
            if (!promises.Promises(Promise.Positive))
            {
                __abs &= 0x7FFF;
            }

			if (Hint.Unlikely(__abs < ONE_AS_HALF))
			{
                if (promises.Promises(Promise.Positive))
                {
                    result = ONE_AS_HALF;
                }
                else
                {
                    result &= 0x8000;

                    if (!promises.Promises(Promise.Negative))
                    {
                        ushort signTest = x.value;
                        if (!promises.Promises(Promise.NonZero))
                        {
                            signTest -= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? toushort(x.value != 1 << 15) : (ushort)1;
                        }

                        result |= andnot(ONE_AS_HALF, (short)signTest >> 15);
                    }
                }
			}
			else if (__abs < asushort(LIMIT_PRECISE_U16_F16))
			{
				int shift = F16_ROUND_SHIFT_BASE - (__abs >> F16_MANTISSA_BITS);
				int mask = bitmask16(shift);

                if (promises.Promises(Promise.Positive))
                {
                    result += mask;
                }
                else if (promises.Promises(Promise.Negative))
                {
                    ;
                }
                else
                {
				    result += andnot(mask, (short)x.value >> 15);
                }

				result = andnot(result, mask);
			}

			return ashalf((ushort)result);
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half2"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 ceil(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.ceil_ph(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new half2(ceil(x.x, promises), ceil(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half3"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 ceil(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.ceil_ph(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new half3(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half4"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 ceil(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.ceil_ph(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero)));
            }
            else
            {
                return new half4(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises), ceil(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half8"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 ceil(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_ph(x, elements: 8, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half8(ceil(x.x0, promises),
                                 ceil(x.x1, promises),
                                 ceil(x.x2, promises),
                                 ceil(x.x3, promises),
                                 ceil(x.x4, promises),
                                 ceil(x.x5, promises),
                                 ceil(x.x6, promises),
                                 ceil(x.x7, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half16"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 ceil(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_ceil_ph(x, nonZero: promises.Promises(Promise.NonZero), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half16(ceil(x.v8_0, promises), ceil(x.v8_8, promises));
            }
        }
    }
}