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
                if (Architecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements);

                    v128 SIGN_MASK = set1_epi8(maxmath.bitmask8(quarter.EXPONENT_BITS + quarter.MANTISSA_BITS));
                    v128 EXPONENT_BIAS = set1_epi8((byte)math.abs(quarter.EXPONENT_BIAS));
                    v128 MANTISSA_BITS = set1_epi8(quarter.MANTISSA_BITS);
                    v128 ONE = set1_epi8(1);

                    v128 rawExponent = and_si128(a, SIGN_MASK);
                    v128 unbiasedExponent = sub_epi8(srli_epi8(rawExponent, quarter.MANTISSA_BITS), EXPONENT_BIAS);

                    v128 fractionBits = sub_epi8(MANTISSA_BITS, unbiasedExponent);
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
                if (Architecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements);
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000, elements);

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
                if (Architecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements);
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000, elements);

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
            public static v128 ceil_pq(v128 a, byte elements = 16, bool notNaNInf = false, bool positive = false, bool negative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_LT_EPU8(a, 0b1000_0000, elements);
                    negative |= constexpr.ALL_GT_EPU8(a, 0b1000_0000, elements);

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
                    else if (negative)
                    {
                        resultsLessThanOne = andnot_si128(ABS_MASK, a);
                    }
                    else
                    {
                        resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, andnot_si128(srai_epi8(a, 7), ONES_AS_QUARTERS), TernaryOperation.OxBA);
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
            public static v128 trunc_ph(v128 a, byte elements = 8, bool notNaNInf = false, bool positive = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements);

                    v128 SIGN_MASK = set1_epi16(maxmath.bitmask16(F16_EXPONENT_BITS + F16_MANTISSA_BITS));
                    v128 EXPONENT_BIAS = set1_epi16((ushort)math.abs(F16_EXPONENT_BIAS));
                    v128 MANTISSA_BITS = set1_epi16(F16_MANTISSA_BITS);

                    v128 rawExponent = and_si128(a, SIGN_MASK);
                    v128 unbiasedExponent = sub_epi16(srli_epi16(rawExponent, F16_MANTISSA_BITS), EXPONENT_BIAS);
                    v128 fractionBits = sub_epi16(MANTISSA_BITS, unbiasedExponent);

                    v128 mask = bitmask_epi16(fractionBits, elements: elements, promiseLT16: true);
                    v128 validRangeMask = srai_epi16(fractionBits, 15);

                    v128 result = ternarylogic_si128(a, mask, validRangeMask, TernaryOperation.OxBO);
                    result = and_si128(result, cmpgt_epi16(inc_epi16(MANTISSA_BITS), fractionBits));

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
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements);
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000, elements);

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
                if (Architecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements);
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000, elements);

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
            public static v128 ceil_ph(v128 a, byte elements = 8, bool positive = false, bool negative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_LT_EPU16(a, 0x8000, elements);
                    negative |= constexpr.ALL_GT_EPU16(a, 0x8000, elements);

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
                        resultsLessThanOne = ternarylogic_si128(a, ABS_MASK, andnot_si128(srai_epi16(a, 15), ONES_AS_HALFS), TernaryOperation.OxBA);
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
        }
    }


    unsafe public static partial class maxmath
    {
        internal const byte ONE_AS_QUARTER = 0b0011_0000;
        internal const ushort ONE_AS_HALF = 0x3C00;

        internal static byte F8_ROUND_SHIFT_BASE => (byte)(quarter.MANTISSA_BITS + math.abs(quarter.EXPONENT_BIAS));
        internal static ushort F16_ROUND_SHIFT_BASE => (ushort)(F16_MANTISSA_BITS + math.abs(F16_EXPONENT_BIAS));


        /// <summary>       Returns the result of a truncation of a <see cref="quarter"/> to an integral <see cref="quarter"/>.
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

            byte unbiasedExponent = (byte)((rawExponent >> quarter.MANTISSA_BITS) - math.abs(quarter.EXPONENT_BIAS));
            int fractionBits = quarter.MANTISSA_BITS - unbiasedExponent;
            int mask = (1 << fractionBits) - 1;

            byte result = andnot(x.value, (byte)mask);
            result &= (byte)-tobyte(isinrange(fractionBits, 1, quarter.MANTISSA_BITS));

            // only here to preserve negative 0
            if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x.value < 0b1000_0000)))
            {
                result |= andnot(x.value, SIGN_MASK);
            }

            return asquarter(result);
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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


        /// <summary>       Returns the result of rounding a <see cref="quarter"/> to the nearest numerical value.
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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


        /// <summary>       Returns the result of rounding a <see cref="quarter"/> down to the nearest value less or equal to the original value.
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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


        /// <summary>       Returns the result of rounding a <see cref="quarter"/> up to the nearest value greater or equal to the original value.
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if <paramref name="x"/> is infinite or NaN.       </para>
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
                        result |= andnot(ONE_AS_QUARTER, (sbyte)x.value >> 7);
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
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 ceil(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 2, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter2(ceil(x.x, promises), ceil(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter3"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 ceil(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 3, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
            }
            else
            {
                return new quarter3(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.quarter4"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns incorrect values if any <paramref name="x"/> is infinite or NaN.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 ceil(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 4, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
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
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ceil_pq(x, elements: 8, notNaNInf: promises.Promises(Promise.Unsafe0), positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
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

            int unbiasedExponent = (rawExponent >> F16_MANTISSA_BITS) - math.abs(F16_EXPONENT_BIAS);
            int fractionBits = F16_MANTISSA_BITS - unbiasedExponent;

            int mask = (1 << fractionBits) - 1;
            ushort validRangeMask = (ushort)-tobyte(fractionBits > 0);

            ushort result = andnot(x.value, (ushort)(mask & validRangeMask));
            result &= (ushort)-tobyte(fractionBits <= F16_MANTISSA_BITS);

            // only here to preserve negative 0
            if (!(promises.Promises(Promise.Positive) || constexpr.IS_TRUE(x.value < 0x8000)))
            {
                result |= andnot(x.value, SIGN_MASK);
            }

            return ashalf(result);
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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
            if (Architecture.IsSIMDSupported)
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


        /// <summary>       Returns the result of rounding a <see cref="half"/> up to the nearest value greater or equal to the original value.
        /// <remarks>
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
                        result |= andnot(ONE_AS_HALF, (short)x.value >> 15);
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
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 ceil(half2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.ceil_ph(RegisterConversion.ToV128(x), elements: 2, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half2(ceil(x.x, promises), ceil(x.y, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half3"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 ceil(half3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.ceil_ph(RegisterConversion.ToV128(x), elements: 3, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half3(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="half4"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 ceil(half4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.ceil_ph(RegisterConversion.ToV128(x), elements: 4, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative)));
            }
            else
            {
                return new half4(ceil(x.x, promises), ceil(x.y, promises), ceil(x.z, promises), ceil(x.w, promises));
            }
        }

        /// <summary>       Returns the result of rounding each component of a <see cref="MaxMath.half8"/> up to the nearest value greater or equal to the original value.    </summary>
        /// <remarks>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that are negative or 0.       </para>
        ///     <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that are positive or 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 ceil(half8 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.ceil_ph(x, elements: 8, positive: promises.Promises(Promise.Positive), negative: promises.Promises(Promise.Negative));
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
    }
}