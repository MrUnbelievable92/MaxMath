#define EVEN_ON_TIE

using System.Runtime.CompilerServices;
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

                    v128 SIGN_MASK = set1_epi8(math.bitmask8(MaxMath.quarter.EXPONENT_BITS + MaxMath.quarter.MANTISSA_BITS));
                    v128 EXPONENT_BIAS = set1_epi8((byte)math.abs(MaxMath.quarter.EXPONENT_BIAS));
                    v128 MANTISSA_BITS = set1_epi8(MaxMath.quarter.MANTISSA_BITS);
                    v128 ONE = set1_epi8(1);

                    v128 rawExponent = and_si128(a, SIGN_MASK);
                    v128 unbiasedExponent = srli_epi8(rawExponent, MaxMath.quarter.MANTISSA_BITS);

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
                        v128 SIGNALING_EXPONENT_M1 = set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT - 1);

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
                    v128 ONES_AS_QUARTERS = set1_epi8(math.ONE_AS_QUARTER);
                    v128 SIGNALING_EXPONENTS = set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT);
                    v128 SHIFT_BASE = set1_epi8(math.F8_ROUND_SHIFT_BASE);

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

			    	v128 shifts = sub_epi8(SHIFT_BASE, srli_epi8(__abs, MaxMath.quarter.MANTISSA_BITS));
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
                    v128 ONES_AS_QUARTERS = set1_epi8(math.ONE_AS_QUARTER);
                    v128 SIGNALING_EXPONENTS = set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT);
                    v128 SHIFT_BASE = set1_epi8(math.F8_ROUND_SHIFT_BASE);

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

			    	v128 shifts = sub_epi8(SHIFT_BASE, srli_epi8(__abs, MaxMath.quarter.MANTISSA_BITS));
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
                    v128 ONES_AS_QUARTERS = set1_epi8(math.ONE_AS_QUARTER);
                    v128 SIGNALING_EXPONENTS = set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT);
                    v128 SHIFT_BASE = set1_epi8(math.F8_ROUND_SHIFT_BASE);

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

			    	v128 shifts = sub_epi8(SHIFT_BASE, srli_epi8(__abs, MaxMath.quarter.MANTISSA_BITS));
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

                    v256 SIGN_MASK = mm256_set1_epi8(math.bitmask8(MaxMath.quarter.EXPONENT_BITS + MaxMath.quarter.MANTISSA_BITS));
                    v256 EXPONENT_BIAS = mm256_set1_epi8((byte)math.abs(MaxMath.quarter.EXPONENT_BIAS));
                    v256 MANTISSA_BITS = mm256_set1_epi8(MaxMath.quarter.MANTISSA_BITS);
                    v256 ONE = mm256_set1_epi8(1);

                    v256 rawExponent = Avx2.mm256_and_si256(a, SIGN_MASK);
                    v256 unbiasedExponent = mm256_srli_epi8(rawExponent, MaxMath.quarter.MANTISSA_BITS);

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
                        v256 SIGNALING_EXPONENT_M1 = mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT - 1);

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
                    v256 ONES_AS_QUARTERS = mm256_set1_epi8(math.ONE_AS_QUARTER);
                    v256 SIGNALING_EXPONENTS = mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT);
                    v256 SHIFT_BASE = mm256_set1_epi8(math.F8_ROUND_SHIFT_BASE);

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

			    	v256 shifts = Avx2.mm256_sub_epi8(SHIFT_BASE, mm256_srli_epi8(__abs, MaxMath.quarter.MANTISSA_BITS));
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
                    v256 ONES_AS_QUARTERS = mm256_set1_epi8(math.ONE_AS_QUARTER);
                    v256 SIGNALING_EXPONENTS = mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT);
                    v256 SHIFT_BASE = mm256_set1_epi8(math.F8_ROUND_SHIFT_BASE);

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

			    	v256 shifts = Avx2.mm256_sub_epi8(SHIFT_BASE, mm256_srli_epi8(__abs, MaxMath.quarter.MANTISSA_BITS));
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
                    v256 ONES_AS_QUARTERS = mm256_set1_epi8(math.ONE_AS_QUARTER);
                    v256 SIGNALING_EXPONENTS = mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT);
                    v256 SHIFT_BASE = mm256_set1_epi8(math.F8_ROUND_SHIFT_BASE);

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

			    	v256 shifts = Avx2.mm256_sub_epi8(SHIFT_BASE, mm256_srli_epi8(__abs, MaxMath.quarter.MANTISSA_BITS));
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
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU16(a, 0x8000, elements);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements) && nonZero;

                    v128 SIGN_MASK = set1_epi16(math.bitmask16(F16_EXPONENT_BITS + F16_MANTISSA_BITS));
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
                if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0, elements) && constexpr.ALL_NEQ_EPU16(a, 0x8000, elements);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi16(0x7FFF);
                    v128 ONES_AS_HALFS = set1_epi16(math.ONE_AS_HALF);
                    v128 MAX_PRECISE_I16 = set1_epi16(math.asushort(LIMIT_PRECISE_U16_F16));
                    v128 SHIFT_BASE = set1_epi16(math.F16_ROUND_SHIFT_BASE);
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
                    v128 ONES_AS_HALFS = set1_epi16(math.ONE_AS_HALF);
                    v128 MAX_PRECISE_I16 = set1_epi16(math.asushort(LIMIT_PRECISE_U16_F16));
                    v128 SHIFT_BASE = set1_epi16(math.F16_ROUND_SHIFT_BASE);

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
                    v128 ONES_AS_HALFS = set1_epi16(math.ONE_AS_HALF);
                    v128 MAX_PRECISE_I16 = set1_epi16(math.asushort(LIMIT_PRECISE_U16_F16));
                    v128 SHIFT_BASE = set1_epi16(math.F16_ROUND_SHIFT_BASE);

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

                    v256 SIGN_MASK = mm256_set1_epi16(math.bitmask16(F16_EXPONENT_BITS + F16_MANTISSA_BITS));
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
                if (Avx2.IsAvx2Supported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU16(a, 0) && constexpr.ALL_NEQ_EPU16(a, 0x8000);
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000) && nonZero;

                    v256 ABS_MASK = mm256_set1_epi16(0x7FFF);
                    v256 ONES_AS_HALFS = mm256_set1_epi16(math.ONE_AS_HALF);
                    v256 MAX_PRECISE_I16 = mm256_set1_epi16(math.asushort(LIMIT_PRECISE_U16_F16));
                    v256 SHIFT_BASE = mm256_set1_epi16(math.F16_ROUND_SHIFT_BASE);
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
                    v256 ONES_AS_HALFS = mm256_set1_epi16(math.ONE_AS_HALF);
                    v256 MAX_PRECISE_I16 = mm256_set1_epi16(math.asushort(LIMIT_PRECISE_U16_F16));
                    v256 SHIFT_BASE = mm256_set1_epi16(math.F16_ROUND_SHIFT_BASE);

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
                    v256 ONES_AS_HALFS = mm256_set1_epi16(math.ONE_AS_HALF);
                    v256 MAX_PRECISE_I16 = mm256_set1_epi16(math.asushort(LIMIT_PRECISE_U16_F16));
                    v256 SHIFT_BASE = mm256_set1_epi16(math.F16_ROUND_SHIFT_BASE);

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


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 trunc_ps(v128 a, byte elements = 4, bool notNaNInf = false, bool positive = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.round_ps(a, (int)RoundingMode.FROUND_TRUNC);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndq_f32(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU32(a, 0, elements) && constexpr.ALL_NEQ_EPU32(a, 0x8000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU32(a, 0x8000_0000, elements) && nonZero;

                    v128 SIGN_MASK = set1_epi32(math.bitmask32(F32_EXPONENT_BITS + F32_MANTISSA_BITS));
                    v128 EXPONENT_BIAS = set1_epi32((uint)math.abs(F32_EXPONENT_BIAS));
                    v128 MANTISSA_BITS = set1_epi32(F32_MANTISSA_BITS);

                    v128 rawExponent = and_si128(a, SIGN_MASK);
                    v128 unbiasedExponent = srli_epi32(rawExponent, F32_MANTISSA_BITS);
                    v128 fractionBits = sub_epi32(add_epi32(MANTISSA_BITS, EXPONENT_BIAS), unbiasedExponent);

                    v128 mask = bitmask_epi32(fractionBits, elements: elements, promiseLT32: true);
                    v128 validRangeMask = cmpgt_epi32(MANTISSA_BITS, sub_epi32(unbiasedExponent, EXPONENT_BIAS));//srai_epi32(fractionBits, 31);

                    v128 result = and_si128(a, cmpgt_epi32(inc_epi32(MANTISSA_BITS), fractionBits));
                    result = ternarylogic_si128(mask, result, validRangeMask, TernaryOperation.Ox4C);

                    // only here to preserve negative 0
                    if (!positive)
                    {
                        result = ternarylogic_si128(SIGN_MASK, a, result, TernaryOperation.OxAE);
                    }

                    if (!notNaNInf)
                    {
                        v128 SIGNALING_EXPONENT_M1 = set1_epi32(F32_SIGNALING_EXPONENT - 1);

                        result = blendv_si128(result, a, cmpgt_epi32(rawExponent, SIGNALING_EXPONENT_M1));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 round_ps(v128 a, byte elements = 4, bool positive = false, bool negative = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.round_ps(a, (int)RoundingMode.FROUND_NINT);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndnq_f32(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU32(a, 0, elements) && constexpr.ALL_NEQ_EPU32(a, 0x8000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU32(a, 0x8000_0000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU32(a, 0x8000_0000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi32(0x7FFF_FFFF);
                    v128 ONES_AS_FLOATS = set1_epi32(math.asint(1f));
                    v128 MAX_PRECISE_I32 = set1_epi32(math.asint(LIMIT_PRECISE_U32_F32));
                    v128 SHIFT_BASE = set1_epi32(math.F32_ROUND_SHIFT_BASE);
                    v128 ONE = set1_epi32(1);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = and_si128(ONES_AS_FLOATS, cmpgt_epi32(__abs, blsr_epi32(ONES_AS_FLOATS)));
                        #else
                            resultsLessThanOne = and_si128(ONES_AS_FLOATS, cmpgt_epi32(__abs, dec_epi32(blsr_epi32(ONES_AS_FLOATS))));
                        #endif
                    }
                    else if (negative)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_FLOATS, cmpgt_epi32(__abs, blsr_epi32(ONES_AS_FLOATS)), ABS_MASK, TernaryOperation.OxD5);
                        #else
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_FLOATS, cmpgt_epi32(__abs, dec_epi32(blsr_epi8(ONES_AS_FLOATS))), ABS_MASK, TernaryOperation.OxD5);
                        #endif
                    }
                    else
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_FLOATS, cmpgt_epi32(__abs, blsr_epi32(ONES_AS_FLOATS))), TernaryOperation.OxBA);
                        #else
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_FLOATS, cmpgt_epi32(__abs, dec_epi32(blsr_epi32(ONES_AS_FLOATS))), TernaryOperation.OxBA);
                        #endif
                    }

                    v128 shifts = sub_epi32(SHIFT_BASE, srli_epi32(__abs, F32_MANTISSA_BITS));
                    v128 masks = bitmask_epi32(shifts, elements: elements, promiseLT32: true);

                    v128 resultsWithFraction;
                    #if EVEN_ON_TIE
                        resultsWithFraction = add_epi32(a, sub_epi32(sllv_epi32(ONE, dec_epi32(shifts), elements: elements), andnot_si128(srlv_epi32(a, shifts, elements: elements), ONE)));
                    #else
                        resultsWithFraction = add_epi32(a, sllv_epi32(ONE, dec_epi32(shifts), elements: elements));
                    #endif
				    resultsWithFraction = andnot_si128(masks, resultsWithFraction);


                    v128 isLessThanOne = cmpgt_epi32(ONES_AS_FLOATS, __abs);
                    v128 hasFraction = cmpgt_epi32(MAX_PRECISE_I32, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floor_ps(v128 a, byte elements = 4, bool positive = false, bool negative = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.floor_ps(a);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndmq_f32(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU32(a, 0, elements) && constexpr.ALL_NEQ_EPU32(a, 0x8000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU32(a, 0x8000_0000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU32(a, 0x8000_0000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi32(0x7FFF_FFFF);
                    v128 ONES_AS_FLOATS = set1_epi32(math.asint(1f));
                    v128 MAX_PRECISE_I32 = set1_epi32(math.asint(LIMIT_PRECISE_U32_F32));
                    v128 SHIFT_BASE = set1_epi32(math.F32_ROUND_SHIFT_BASE);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = setzero_si128();
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = ornot_si128(ABS_MASK, ONES_AS_FLOATS);
                    }
                    else
                    {
                        resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_FLOATS, cmpge_epu32(a, set1_epi32(0x8000_0001))), TernaryOperation.OxBA);
                    }

                    v128 shifts = sub_epi32(SHIFT_BASE, srli_epi32(__abs, F32_MANTISSA_BITS));
                    v128 masks = bitmask_epi32(shifts, elements: elements, promiseLT32: true);

                    v128 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = a;
                    }
                    else if (negative)
                    {
                        resultsWithFraction = add_epi32(a, masks);
                    }
                    else
                    {
                        resultsWithFraction = add_epi32(a, and_si128(masks, srai_epi32(a, 31)));
                    }

                    resultsWithFraction = andnot_si128(masks, resultsWithFraction);

                    v128 isLessThanOne = cmpgt_epi32(ONES_AS_FLOATS, __abs);
                    v128 hasFraction = cmpgt_epi32(MAX_PRECISE_I32, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceil_ps(v128 a, byte elements = 4, bool positive = false, bool negative = false, bool nonZero = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.ceil_ps(a);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndpq_f32(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPU32(a, 0, elements) && constexpr.ALL_NEQ_EPU32(a, 0x8000_0000, elements);
                    positive |= constexpr.ALL_LT_EPU32(a, 0x8000_0000, elements) && nonZero;
                    negative |= constexpr.ALL_GT_EPU32(a, 0x8000_0000, elements) && nonZero;

                    v128 ABS_MASK = set1_epi32(0x7FFF_FFFF);
                    v128 ONES_AS_FLOATS = set1_epi32(math.asint(1f));
                    v128 MAX_PRECISE_I32 = set1_epi32(math.asint(LIMIT_PRECISE_U32_F32));
                    v128 SHIFT_BASE = set1_epi32(math.F32_ROUND_SHIFT_BASE);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = ONES_AS_FLOATS;
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = andnot_si128(ABS_MASK, a);
                    }
                    else
                    {
                        v128 signTest = nonZero ? a : decs_epi32(a);
                        resultsLessThanOne = ternarylogic_si128(srai_epi32(signTest, 31), ONES_AS_FLOATS, andnot_si128(ABS_MASK, a), TernaryOperation.OxAE);
                    }

                    v128 shifts = sub_epi32(SHIFT_BASE, srli_epi32(__abs, F32_MANTISSA_BITS));
                    v128 masks = bitmask_epi32(shifts, elements: elements, promiseLT32: true);

                    v128 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = add_epi32(a, masks);
                    }
                    else if (negative)
                    {
                        resultsWithFraction = a;
                    }
                    else
                    {
                        resultsWithFraction = add_epi32(a, andnot_si128(srai_epi32(a, 31), masks));
                    }

                    resultsWithFraction = andnot_si128(masks, resultsWithFraction);

                    v128 isLessThanOne = cmpgt_epi32(ONES_AS_FLOATS, __abs);
                    v128 hasFraction = cmpgt_epi32(MAX_PRECISE_I32, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 trunc_pd(v128 a, bool notNaNInf = false, bool positive = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.round_pd(a, (int)RoundingMode.FROUND_TRUNC);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndq_f64(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU64(a, 0) && constexpr.ALL_NEQ_EPU64(a, 0x8000_0000_0000_0000);
                    positive |= constexpr.ALL_LT_EPU64(a, 0x8000_0000_0000_0000) && nonZero;

                    v128 SIGN_MASK = set1_epi64x(math.bitmask64((long)F64_EXPONENT_BITS + F64_MANTISSA_BITS));
                    v128 EXPONENT_BIAS = set1_epi64x((ulong)math.abs(F64_EXPONENT_BIAS));
                    v128 MANTISSA_BITS = set1_epi64x(F64_MANTISSA_BITS);

                    v128 rawExponent = and_si128(a, SIGN_MASK);
                    v128 unbiasedExponent = srli_epi64(rawExponent, F64_MANTISSA_BITS);
                    v128 fractionBits = sub_epi64(add_epi64(MANTISSA_BITS, EXPONENT_BIAS), unbiasedExponent);

                    v128 mask = bitmask_epi64(fractionBits, promiseLT64: true);
                    v128 validRangeMask = cmpgt_epi64(MANTISSA_BITS, sub_epi64(unbiasedExponent, EXPONENT_BIAS));//srai_epi64(fractionBits, 63);

                    v128 result = and_si128(a, cmpgt_epi64(inc_epi64(MANTISSA_BITS), fractionBits));
                    result = ternarylogic_si128(mask, result, validRangeMask, TernaryOperation.Ox4C);

                    // only here to preserve negative 0
                    if (!positive)
                    {
                        result = ternarylogic_si128(SIGN_MASK, a, result, TernaryOperation.OxAE);
                    }

                    if (!notNaNInf)
                    {
                        v128 SIGNALING_EXPONENT_M1 = set1_epi64x(F64_SIGNALING_EXPONENT - 1);

                        result = blendv_si128(result, a, cmpgt_epi64(rawExponent, SIGNALING_EXPONENT_M1));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 round_pd(v128 a, bool positive = false, bool negative = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.round_pd(a, (int)RoundingMode.FROUND_NINT);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndnq_f64(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU64(a, 0) && constexpr.ALL_NEQ_EPU64(a, 0x8000_0000_0000_0000);
                    positive |= constexpr.ALL_LT_EPU64(a, 0x8000_0000_0000_0000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU64(a, 0x8000_0000_0000_0000) && nonZero;

                    v128 ABS_MASK = set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);
                    v128 ONES_AS_DOUBLES = set1_epi64x(math.aslong(1d));
                    v128 MAX_PRECISE_I64 = set1_epi64x(math.aslong(LIMIT_PRECISE_U64_F64));
                    v128 SHIFT_BASE = set1_epi64x(math.F64_ROUND_SHIFT_BASE);
                    v128 ONE = set1_epi64x(1);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = and_si128(ONES_AS_DOUBLES, cmpgt_epi64(__abs, blsr_epi64(ONES_AS_DOUBLES)));
                        #else
                            resultsLessThanOne = and_si128(ONES_AS_DOUBLES, cmpgt_epi64(__abs, dec_epi64(blsr_epi64(ONES_AS_DOUBLES))));
                        #endif
                    }
                    else if (negative)
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_DOUBLES, cmpgt_epi64(__abs, blsr_epi64(ONES_AS_DOUBLES)), ABS_MASK, TernaryOperation.OxD5);
                        #else
                            resultsLessThanOne = ternarylogic_si128(ONES_AS_DOUBLES, cmpgt_epi64(__abs, dec_epi64(blsr_epi8(ONES_AS_DOUBLES))), ABS_MASK, TernaryOperation.OxD5);
                        #endif
                    }
                    else
                    {
                        #if EVEN_ON_TIE
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_DOUBLES, cmpgt_epi64(__abs, blsr_epi64(ONES_AS_DOUBLES))), TernaryOperation.OxBA);
                        #else
                            resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_DOUBLES, cmpgt_epi64(__abs, dec_epi64(blsr_epi64(ONES_AS_DOUBLES))), TernaryOperation.OxBA);
                        #endif
                    }

                    v128 shifts = sub_epi64(SHIFT_BASE, srli_epi64(__abs, F64_MANTISSA_BITS));
                    v128 masks = bitmask_epi64(shifts, promiseLT64: true);

                    v128 resultsWithFraction;
                    #if EVEN_ON_TIE
                        resultsWithFraction = add_epi64(a, sub_epi64(sllv_epi64(ONE, dec_epi64(shifts)), andnot_si128(srlv_epi64(a, shifts), ONE)));
                    #else
                        resultsWithFraction = add_epi64(a, sllv_epi64(ONE, dec_epi64(shifts)));
                    #endif
				    resultsWithFraction = andnot_si128(masks, resultsWithFraction);


                    v128 isLessThanOne = cmpgt_epi64(ONES_AS_DOUBLES, __abs);
                    v128 hasFraction = cmpgt_epi64(MAX_PRECISE_I64, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floor_pd(v128 a, bool positive = false, bool negative = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.floor_pd(a);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndmq_f64(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    bool nonZero = constexpr.ALL_NEQ_EPU64(a, 0) && constexpr.ALL_NEQ_EPU64(a, 0x8000_0000_0000_0000);
                    positive |= constexpr.ALL_LT_EPU64(a, 0x8000_0000_0000_0000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU64(a, 0x8000_0000_0000_0000) && nonZero;

                    v128 ABS_MASK = set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);
                    v128 ONES_AS_DOUBLES = set1_epi64x(math.aslong(1d));
                    v128 MAX_PRECISE_I64 = set1_epi64x(math.aslong(LIMIT_PRECISE_U64_F64));
                    v128 SHIFT_BASE = set1_epi64x(math.F64_ROUND_SHIFT_BASE);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = setzero_si128();
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = ornot_si128(ABS_MASK, ONES_AS_DOUBLES);
                    }
                    else
                    {
                        resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, and_si128(ONES_AS_DOUBLES, cmpgt_epu64(set1_epi64x(0x8000_0000_0000_0001), a)), TernaryOperation.Ox75);
                    }

                    v128 shifts = sub_epi64(SHIFT_BASE, srli_epi64(__abs, F64_MANTISSA_BITS));
                    v128 masks = bitmask_epi64(shifts, promiseLT64: true);

                    v128 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = a;
                    }
                    else if (negative)
                    {
                        resultsWithFraction = add_epi64(a, masks);
                    }
                    else
                    {
                        resultsWithFraction = add_epi64(a, and_si128(masks, srai_epi64(a, 63)));
                    }

                    resultsWithFraction = andnot_si128(masks, resultsWithFraction);

                    v128 isLessThanOne = cmpgt_epi64(ONES_AS_DOUBLES, __abs);
                    v128 hasFraction = cmpgt_epi64(MAX_PRECISE_I64, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 ceil_pd(v128 a, bool positive = false, bool negative = false, bool nonZero = false)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.ceil_pd(a);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vrndpq_f64(a);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPU64(a, 0) && constexpr.ALL_NEQ_EPU64(a, 0x8000_0000_0000_0000);
                    positive |= constexpr.ALL_LT_EPU64(a, 0x8000_0000_0000_0000) && nonZero;
                    negative |= constexpr.ALL_GT_EPU64(a, 0x8000_0000_0000_0000) && nonZero;

                    v128 ABS_MASK = set1_epi64x(0x7FFF_FFFF_FFFF_FFFF);
                    v128 ONES_AS_DOUBLES = set1_epi64x(math.aslong(1d));
                    v128 MAX_PRECISE_I64 = set1_epi64x(math.aslong(LIMIT_PRECISE_U64_F64));
                    v128 SHIFT_BASE = set1_epi64x(math.F64_ROUND_SHIFT_BASE);

			        v128 __abs = positive ? a : and_si128(a, ABS_MASK);

                    v128 resultsLessThanOne;
                    if (positive)
                    {
                        resultsLessThanOne = ONES_AS_DOUBLES;
                    }
                    else if (negative)
                    {
                        resultsLessThanOne = andnot_si128(ABS_MASK, a);
                    }
                    else
                    {
                        v128 signTest = nonZero ? a : decs_epi64(a);
                        resultsLessThanOne = ternarylogic_si128(srai_epi64(signTest, 63), ONES_AS_DOUBLES, andnot_si128(ABS_MASK, a), TernaryOperation.OxAE);
                    }

                    v128 shifts = sub_epi64(SHIFT_BASE, srli_epi64(__abs, F64_MANTISSA_BITS));
                    v128 masks = bitmask_epi64(shifts, promiseLT64: true);

                    v128 resultsWithFraction;
                    if (positive)
                    {
                        resultsWithFraction = add_epi64(a, masks);
                    }
                    else if (negative)
                    {
                        resultsWithFraction = a;
                    }
                    else
                    {
                        resultsWithFraction = add_epi64(a, andnot_si128(srai_epi64(a, 63), masks));
                    }

                    resultsWithFraction = andnot_si128(masks, resultsWithFraction);

                    v128 isLessThanOne = cmpgt_epi64(ONES_AS_DOUBLES, __abs);
                    v128 hasFraction = cmpgt_epi64(MAX_PRECISE_I64, __abs);

                    return blendv_si128(a, blendv_si128(resultsWithFraction, resultsLessThanOne, isLessThanOne), hasFraction);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        internal const byte ONE_AS_QUARTER = 0b0011_0000;
        internal const ushort ONE_AS_HALF = 0x3C00;

        internal static byte F8_ROUND_SHIFT_BASE => (byte)(MaxMath.quarter.MANTISSA_BITS + abs(MaxMath.quarter.EXPONENT_BIAS));
        internal static ushort F16_ROUND_SHIFT_BASE => (ushort)(F16_MANTISSA_BITS + abs(F16_EXPONENT_BIAS));
        internal static int F32_ROUND_SHIFT_BASE => F32_MANTISSA_BITS + abs(F32_EXPONENT_BIAS);
        internal static int F64_ROUND_SHIFT_BASE => F64_MANTISSA_BITS + abs(F64_EXPONENT_BIAS);


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

            if (!(promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE((x.value & SIGN_MASK) < MaxMath.quarter.SIGNALING_EXPONENT)))
            {
                if (Hint.Unlikely(rawExponent >= MaxMath.quarter.SIGNALING_EXPONENT))
                {
                    return x;
                }
            }

            int unbiasedExponent = rawExponent >> MaxMath.quarter.MANTISSA_BITS;
            int fractionBits = (MaxMath.quarter.MANTISSA_BITS + abs(MaxMath.quarter.EXPONENT_BIAS)) - unbiasedExponent;
            int mask = (1 << fractionBits) - 1;

            int result = x.value & -tobyte(isinrange(fractionBits, 1, MaxMath.quarter.MANTISSA_BITS));
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
                    if (__abs >= MaxMath.quarter.SIGNALING_EXPONENT)
                    {
                        return asquarter((byte)result);
                    }
                }

				int shift = F8_ROUND_SHIFT_BASE - (__abs >> MaxMath.quarter.MANTISSA_BITS);
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


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.quarter"/> down to the nearest integral value less than or equal to to the original value.
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
                    if (__abs >= MaxMath.quarter.SIGNALING_EXPONENT)
                    {
                        return asquarter((byte)result);
                    }
                }

				int shift = F8_ROUND_SHIFT_BASE - (__abs >> MaxMath.quarter.MANTISSA_BITS);
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter2"/> down to the nearest integral value less than or equal to to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter3"/> down to the nearest integral value less than or equal to to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter4"/> down to the nearest integral value less than or equal to to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter8"/> down to the nearest integral value less than or equal to to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter16"/> down to the nearest integral value less than or equal to to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter32"/> down to the nearest integral value less than or equal to to the original value.
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


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.quarter"/> up to the nearest value greater than or equal to the original value.
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
                    if (__abs >= MaxMath.quarter.SIGNALING_EXPONENT)
                    {
                        return asquarter((byte)result);
                    }
                }

				int shift = F8_ROUND_SHIFT_BASE - (__abs >> MaxMath.quarter.MANTISSA_BITS);
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter2"/> up to the nearest value greater than or equal to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter3"/> up to the nearest value greater than or equal to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter4"/> up to the nearest value greater than or equal to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter8"/> up to the nearest value greater than or equal to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter16"/> up to the nearest value greater than or equal to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter32"/> up to the nearest value greater than or equal to the original value.
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


        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.half"/> to an integral <see cref="MaxMath.half"/>.
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
            int fractionBits = (F16_MANTISSA_BITS + abs(F16_EXPONENT_BIAS)) - unbiasedExponent;

            int mask = (1 << fractionBits) - 1;
            ushort validRangeMask = (ushort)-tobyte(unbiasedExponent - abs(F16_EXPONENT_BIAS) < F16_MANTISSA_BITS);

            int result = x.value & -tobyte(fractionBits <= F16_MANTISSA_BITS);
            result = andnot(result, mask & validRangeMask);

            // only here to preserve negative 0
            if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x.value < 0x8000)))
            {
                result |= andnot(x.value, SIGN_MASK);
            }

            return ashalf((ushort)result);
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.half2"/> to an integral <see cref="MaxMath.half2"/>.
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
                return Xse.trunc_ph(x, 2, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
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
                return Xse.trunc_ph(x, 3, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
            }
            else
            {
                return new half3(trunc(x.x, promises), trunc(x.y, promises), trunc(x.z, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.half4"/> to an integral <see cref="MaxMath.half4"/>.
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
                return Xse.trunc_ph(x, 4, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive));
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


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.half"/> to the nearest numerical value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half2"/> to the nearest numerical value.
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
                return Xse.round_ph(x, elements: 2, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half2(round(x.x, promises), round(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half3"/> to the nearest numerical value.
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
                return Xse.round_ph(x, elements: 3, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half3(round(x.x, promises), round(x.y, promises), round(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half4"/> to the nearest numerical value.
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
                return Xse.round_ph(x, elements: 4, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
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


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.half"/> down to the nearest integral value less than or equal to to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half2"/> down to the nearest integral value less than or equal to to the original value.
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
                return Xse.floor_ph(x, elements: 2, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half2(floor(x.x, promises), floor(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half3"/> down to the nearest integral value less than or equal to to the original value.
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
                return Xse.floor_ph(x, elements: 3, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half3(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half4"/> down to the nearest integral value less than or equal to to the original value.
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
                return Xse.floor_ph(x, elements: 4, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new half4(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises), floor(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half8"/> down to the nearest integral value less than or equal to to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half16"/> down to the nearest integral value less than or equal to to the original value.
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


        /// <summary>       Returns the result of rounding a <see cref="MaxMath.half"/> up to the nearest value greater than or equal to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half2"/> up to the nearest value greater than or equal to the original value.
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
                return Xse.ceil_ph(x, elements: 2, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half2(ceil(x.x, promises), ceil(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half3"/> up to the nearest value greater than or equal to the original value.
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
                return Xse.ceil_ph(x, elements: 3, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half3(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half4"/> up to the nearest value greater than or equal to the original value.
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
                return Xse.ceil_ph(x, elements: 4, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new half4(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises), ceil(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half8"/> up to the nearest value greater than or equal to the original value.
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

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half16"/> up to the nearest value greater than or equal to the original value.
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


        /// <summary>       Returns the result of a truncation of a <see cref="float"/> to an integral <see cref="float"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float trunc(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.trunc(x);
            }
            else
            {
                const int SIGN_MASK = 0x7FFF_FFFF;


                int rawExponent = asint(x) & SIGN_MASK;

                if (!(promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE((asint(x) & SIGN_MASK) < F32_SIGNALING_EXPONENT)))
                {
                    if (Hint.Unlikely(rawExponent >= F32_SIGNALING_EXPONENT))
                    {
                        return x;
                    }
                }

                int unbiasedExponent = rawExponent >> F32_MANTISSA_BITS;
                int fractionBits = (F32_MANTISSA_BITS + abs(F32_EXPONENT_BIAS)) - unbiasedExponent;

                int mask = (1 << fractionBits) - 1;
                int validRangeMask = -tobyte(unbiasedExponent - abs(F32_EXPONENT_BIAS) < F32_MANTISSA_BITS);

                int result = asint(x) & (int)-tobyte(fractionBits <= F32_MANTISSA_BITS);
                result = andnot(result, mask & validRangeMask);

                // only here to preserve negative 0
                if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(asuint(x) < 0x8000_0000)))
                {
                    result |= andnot(asint(x), SIGN_MASK);
                }

                return asfloat(result);
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.float2"/> to an integral <see cref="MaxMath.float2"/>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 trunc(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_ps(x, positive: promises.Promises(Promise.Positive), notNaNInf: promises.Promises(Promise.Unsafe0), elements: 2);
            }
            else
            {
                return new float2(trunc(x.x, promises), trunc(x.y, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.float3"/> to an integral <see cref="MaxMath.float3"/>.     </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 trunc(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_ps(x, positive: promises.Promises(Promise.Positive), notNaNInf: promises.Promises(Promise.Unsafe0), elements: 3);
            }
            else
            {
                return new float3(trunc(x.x, promises), trunc(x.y, promises), trunc(x.z, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.float4"/> to an integral <see cref="MaxMath.float4"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 trunc(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_ps(x, positive: promises.Promises(Promise.Positive), notNaNInf: promises.Promises(Promise.Unsafe0), elements: 4);
            }
            else
            {
                return new float4(trunc(x.x, promises), trunc(x.y, promises), trunc(x.z, promises), trunc(x.w, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.float8"/> to an integral <see cref="MaxMath.float8"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 trunc(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_trunc_ps(x);
            }
            else
            {
                return new float8(trunc(x.v4_0, promises), trunc(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the result of a rounding a <see cref="float"/> to the nearest integral value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float round(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.round(x);
            }
            else
            {
			    uint result = asuint(x);
			    uint __abs = result;
                if (!promises.Promises(Promise.Positive))
                {
                    __abs &= 0x7FFF_FFFF;
                }

			    if (Hint.Unlikely(__abs < asuint(1f)))
			    {
                    if (promises.Promises(Promise.Positive))
                    {
                        #if EVEN_ON_TIE
                            result = asuint(1f) & (uint)-tobyte(__abs >= (bits_resetlowest(asuint(1f)) | 1));
                        #else
                            result = asuint(1f) & (uint)-tobyte(__abs >= bits_resetlowest(asuint(1f)));
                        #endif
                    }
                    else if (promises.Promises(Promise.Negative))
                    {
                        #if EVEN_ON_TIE
                            result = __abs >= (bits_resetlowest(asuint(1f)) | 1) ? (0x8000_0000 | asuint(1f)) : 0x8000_0000;
                        #else
                            result = __abs >= bits_resetlowest(asuint(1f)) ? (0x8000_0000 | asuint(1f)) : 0x8000_0000;
                        #endif
                    }
                    else
                    {
			    	    result &= 0x8000_0000;

                        #if EVEN_ON_TIE
                            result |= asuint(1f) & (uint)-tobyte(__abs >= (bits_resetlowest(asuint(1f)) | 1));
                        #else
                            result |= asuint(1f) & (uint)-tobyte(__abs >= bits_resetlowest(asuint(1f)));
                        #endif
                    }
			    }
			    else if (__abs < asuint(LIMIT_PRECISE_U32_F32))
			    {
			    	uint shift = (uint)F32_ROUND_SHIFT_BASE - (__abs >> F32_MANTISSA_BITS);
			    	uint mask = bitmask32(shift);

                    #if EVEN_ON_TIE
                        result += (1u << ((int)shift - 1)) - andnot(1, result >> (int)shift);
                    #else
                        result += 1u << ((int)shift - 1);
                    #endif

			    	result = andnot(result, mask);
			    }

			    return asfloat(result);
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float2"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 round(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), elements: 2);
            }
            else
            {
                return new float2(round(x.x, promises), round(x.y, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float3"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 round(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), elements: 3);
            }
            else
            {
                return new float3(round(x.x, promises), round(x.y, promises), round(x.z, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float4"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 round(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), elements: 4);
            }
            else
            {
                return new float4(round(x.x, promises), round(x.y, promises), round(x.z, promises), round(x.w, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 round(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_round_ps(x);
            }
            else
            {
                return new float8(round(x.v4_0, promises), round(x.v4_4, promises));
            }
        }
        

        /// <summary>       Returns the result of rounding a <see cref="float"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float floor(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.floor(x);
            }
            else
            {
			    uint result = asuint(x);
			    uint __abs = result;
                if (!promises.Promises(Promise.Positive))
                {
                    __abs &= 0x7FFF_FFFF;
                }

			    if (Hint.Unlikely(__abs < asuint(1f)))
			    {
                    if (promises.Promises(Promise.Positive))
                    {
                        result = 0;
                    }
                    else if (promises.Promises(Promise.Negative))
                    {
                        result = (0x8000_0000 | asuint(1f));
                    }
                    else
                    {
			    	    result &= 0x8000_0000;
                        result |= asuint(1f) & (uint)-tobyte(asuint(x) > 0x8000_0000);
                    }
			    }
			    else if (__abs < asuint(LIMIT_PRECISE_U32_F32))
			    {
			    	uint shift = (uint)F32_ROUND_SHIFT_BASE - (__abs >> F32_MANTISSA_BITS);
			    	uint mask = bitmask32(shift);

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
			    	    result += mask & (uint)(asint(x) >> 31);
                    }

			    	result = andnot(result, mask);
			    }

			    return asfloat(result);
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float2"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 floor(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), elements: 2);
            }
            else
            {
                return new float2(floor(x.x, promises), floor(x.y, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float3"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 floor(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), elements: 3);
            }
            else
            {
                return new float3(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float4"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 floor(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), elements: 4);
            }
            else
            {
                return new float4(floor(x.x, promises), floor(x.y, promises), floor(x.z, promises), floor(x.w, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 floor(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_floor_ps(x);
            }
            else
            {
                return new float8(floor(x.v4_0, promises), floor(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="float"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ceil(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.ceil(x);
            }
            else
            {
			    uint result = asuint(x);
			    uint __abs = result;
                if (!promises.Promises(Promise.Positive))
                {
                    __abs &= 0x7FFF_FFFF;
                }

			    if (Hint.Unlikely(__abs < asuint(1f)))
			    {
                    if (promises.Promises(Promise.Positive))
                    {
                        result = asuint(1f);
                    }
                    else
                    {
                        result &= 0x8000_0000;

                        if (!promises.Promises(Promise.Negative))
                        {
                            uint signTest = asuint(x);
                            if (!promises.Promises(Promise.NonZero))
                            {
                                signTest -= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? touint(asuint(x) != 1u << 31) : 1;
                            }

                            result |= andnot(asuint(1f), (uint)((int)signTest >> 31));
                        }
                    }
			    }
			    else if (__abs < asuint(LIMIT_PRECISE_U32_F32))
			    {
			    	uint shift = (uint)F32_ROUND_SHIFT_BASE - (__abs >> F32_MANTISSA_BITS);
			    	uint mask = bitmask32(shift);

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
			    	    result += andnot(mask, (uint)(asint(x) >> 31));
                    }

			    	result = andnot(result, mask);
			    }

			    return asfloat(result);
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float2"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ceil(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new float2(ceil(x.x, promises), ceil(x.y, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float3"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ceil(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new float3(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float4"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ceil(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_ps(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new float4(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises), ceil(x.w, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.float8"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 ceil(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ceil_ps(x);
            }
            else
            {
                return new float8(ceil(x.v4_0, promises), ceil(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the result of a truncation of a <see cref="double"/> to an integral <see cref="double"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double trunc(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.trunc(x);
            }
            else
            {
                const long SIGN_MASK = 0x7FFF_FFFF_FFFF_FFFF;


                long rawExponent = aslong(x) & SIGN_MASK;

                if (!(promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE((aslong(x) & SIGN_MASK) < F64_SIGNALING_EXPONENT)))
                {
                    if (Hint.Unlikely(rawExponent >= F64_SIGNALING_EXPONENT))
                    {
                        return x;
                    }
                }

                long unbiasedExponent = rawExponent >> F64_MANTISSA_BITS;
                long fractionBits = (F64_MANTISSA_BITS + (long)abs(F64_EXPONENT_BIAS)) - unbiasedExponent;

                long mask = (1L << (int)fractionBits) - 1;
                long validRangeMask = (long)-tobyte(unbiasedExponent - (long)abs(F64_EXPONENT_BIAS) < F64_MANTISSA_BITS);

                long result = aslong(x) & (long)-tolong(fractionBits <= F64_MANTISSA_BITS);
                result = andnot(result, mask & validRangeMask);

                // only here to preserve negative 0
                if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(asulong(x) < 0x8000_0000_0000_0000)))
                {
                    result |= andnot(aslong(x), SIGN_MASK);
                }

                return asdouble(result);
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.double2"/> to an integral <see cref="MaxMath.double2"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 trunc(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.trunc_pd(x, positive: promises.Promises(Promise.Positive), notNaNInf: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new double2(trunc(x.x, promises), trunc(x.y, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.double3"/> to an integral <see cref="MaxMath.double3"/>.     </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 trunc(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_trunc_pd(x);
            }
            else
            {
                return new double3(trunc(x.xy, promises), trunc(x.z, promises));
            }
        }

        /// <summary>       Returns the result of a truncation of a <see cref="MaxMath.double4"/> to an integral <see cref="MaxMath.double4"/>.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 trunc(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_trunc_pd(x);
            }
            else
            {
                return new double4(trunc(x.xy, promises), trunc(x.zw, promises));
            }
        }


        /// <summary>       Returns the result of a rounding a <see cref="double"/> to the nearest integral value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double round(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.round(x);
            }
            else
            {
			    ulong result = asulong(x);
			    ulong __abs = result;
                if (!promises.Promises(Promise.Positive))
                {
                    __abs &= 0x7FFF_FFFF_FFFF_FFFF;
                }

			    if (Hint.Unlikely(__abs < asulong(1d)))
			    {
                    if (promises.Promises(Promise.Positive))
                    {
                        #if EVEN_ON_TIE
                            result = asulong(1d) & (ulong)-tolong(__abs >= (bits_resetlowest(asulong(1d)) | 1));
                        #else
                            result = asulong(1d) & (ulong)-tolong(__abs >= bits_resetlowest(asulong(1d)));
                        #endif
                    }
                    else if (promises.Promises(Promise.Negative))
                    {
                        #if EVEN_ON_TIE
                            result = __abs >= (bits_resetlowest(asulong(1d)) | 1) ? (0x8000_0000_0000_0000 | asulong(1d)) : 0x8000_0000_0000_0000;
                        #else
                            result = __abs >= bits_resetlowest(asulong(1d)) ? (0x8000_0000_0000_0000 | asulong(1d)) : 0x8000_0000_0000_0000;
                        #endif
                    }
                    else
                    {
			    	    result &= 0x8000_0000_0000_0000;

                        #if EVEN_ON_TIE
                            result |= asulong(1d) & (ulong)-tolong(__abs >= (bits_resetlowest(asulong(1d)) | 1));
                        #else
                            result |= asulong(1d) & (ulong)-tolong(__abs >= bits_resetlowest(asulong(1d)));
                        #endif
                    }
			    }
			    else if (__abs < asulong(LIMIT_PRECISE_U64_F64))
			    {
			    	ulong shift = (ulong)F64_ROUND_SHIFT_BASE - (__abs >> F64_MANTISSA_BITS);
			    	ulong mask = bitmask64(shift);

                    #if EVEN_ON_TIE
                        result += (1ul << ((int)shift - 1)) - andnot(1, result >> (int)shift);
                    #else
                        result += 1ul << ((int)shift - 1);
                    #endif

			    	result = andnot(result, mask);
			    }

			    return asdouble(result);
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double2"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 round(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.round_pd(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new double2(round(x.x, promises), round(x.y, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double3"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 round(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_round_pd(x);
            }
            else
            {
                return new double3(round(x.xy, promises), round(x.z, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double4"/> to the nearest numerical value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 round(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_round_pd(x);
            }
            else
            {
                return new double4(round(x.xy, promises), round(x.zw, promises));
            }
        }
        

        /// <summary>       Returns the result of rounding a <see cref="double"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double floor(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.floor(x);
            }
            else
            {
			    ulong result = asulong(x);
			    ulong __abs = result;
                if (!promises.Promises(Promise.Positive))
                {
                    __abs &= 0x7FFF_FFFF_FFFF_FFFF;
                }

			    if (Hint.Unlikely(__abs < asulong(1d)))
			    {
                    if (promises.Promises(Promise.Positive))
                    {
                        result = 0;
                    }
                    else if (promises.Promises(Promise.Negative))
                    {
                        result = (0x8000_0000_0000_0000 | asulong(1d));
                    }
                    else
                    {
			    	    result &= 0x8000_0000_0000_0000;
                        result |= asulong(1d) & (ulong)-tobyte(asulong(x) > 0x8000_0000_0000_0000);
                    }
			    }
			    else if (__abs < asulong(LIMIT_PRECISE_U64_F64))
			    {
			    	ulong shift = (ulong)F64_ROUND_SHIFT_BASE - (__abs >> F64_MANTISSA_BITS);
			    	ulong mask = bitmask64(shift);

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
			    	    result += mask & (ulong)(aslong(x) >> 63);
                    }

			    	result = andnot(result, mask);
			    }

			    return asdouble(result);
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double2"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 floor(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.floor_pd(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new double2(floor(x.x, promises), floor(x.y, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double3"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 floor(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_floor_pd(x);
            }
            else
            {
                return new double3(floor(x.xy, promises), floor(x.z, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double4"/> down to the nearest integral value less than or equal to to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 floor(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_floor_pd(x);
            }
            else
            {
                return new double4(floor(x.xy, promises), floor(x.zw, promises));
            }
        }


        /// <summary>       Returns the result of rounding a <see cref="double"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ceil(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsMul32Supported)
            {
                return Unity.Mathematics.math.ceil(x);
            }
            else
            {
			    ulong result = asulong(x);
			    ulong __abs = result;
                if (!promises.Promises(Promise.Positive))
                {
                    __abs &= 0x7FFF_FFFF_FFFF_FFFF;
                }

			    if (Hint.Unlikely(__abs < asulong(1d)))
			    {
                    if (promises.Promises(Promise.Positive))
                    {
                        result = asulong(1d);
                    }
                    else
                    {
                        result &= 0x8000_0000_0000_0000;

                        if (!promises.Promises(Promise.Negative))
                        {
                            ulong signTest = asulong(x);
                            if (!promises.Promises(Promise.NonZero))
                            {
                                signTest -= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? toulong(asulong(x) != 1ul << 63) : 1;
                            }

                            result |= andnot(asulong(1d), (ulong)((long)signTest >> 63));
                        }
                    }
			    }
			    else if (__abs < asulong(LIMIT_PRECISE_U64_F64))
			    {
			    	ulong shift = (ulong)F64_ROUND_SHIFT_BASE - (__abs >> F64_MANTISSA_BITS);
			    	ulong mask = bitmask64(shift);

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
			    	    result += andnot(mask, (ulong)(aslong(x) >> 63));
                    }

			    	result = andnot(result, mask);
			    }

			    return asdouble(result);
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double2"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 ceil(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.ceil_pd(x, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new double2(ceil(x.x, promises), ceil(x.y, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double3"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ceil(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ceil_pd(x);
            }
            else
            {
                return new double3(ceil(x.xy, promises), ceil(x.z, promises));
            }
        }
        
        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.double4"/> up to the nearest value greater than or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that are equal to 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ceil(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_ceil_pd(x);
            }
            else
            {
                return new double4(ceil(x.xy, promises), ceil(x.zw, promises));
            }
        }
    }
}