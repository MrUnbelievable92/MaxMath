using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivRemBitwise(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
VectorAssert.AreNotEqual<byte16, byte>(divisor, 0, 16);
            
            if (Architecture.IsSIMDSupported)
            {
                v128 ONE = set1_epi8(1);
                v128 SIGN_BIT = set1_epi8(1 << 7);
                v128 quotients;

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotients = setzero_si128();
                    remainder = setzero_si128();

                    for (int i = 7; i >= 0; i--)
                    {
                        remainder = add_epi8(remainder, remainder);
                        quotients = add_epi8(quotients, quotients);
                        remainder = ternarylogic_si128(ONE, srli_epi16(dividend, i), remainder, TernaryOperation.OxEA);
                        v128 subtractFromRemainder = cmple_epu8(divisor, remainder, elements);
                        remainder = sub_epi8(remainder, and_si128(divisor, subtractFromRemainder));
                        quotients = sub_epi8(quotients, subtractFromRemainder);
                    }
                }
                else
                {
                    v128 flippedDivisor = xor_si128(divisor, SIGN_BIT);
                    v128 bit = and_si128(ONE, srli_epi16(dividend, 7));
                    v128 cmpbit = ternarylogic_si128(SIGN_BIT, ONE, srli_epi16(dividend, 7), TernaryOperation.OxF8);
                    v128 retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = bit;
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = andnot_si128(retainRemainder, ONE);

                    //for (int i = 6; i != 0; i--)
                    //{
                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 6));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 5));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 4));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 3));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 2));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, srli_epi16(dividend, 1));
                    cmpbit = ternarylogic_si128(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                    //}
                    ////////////////////////////

                    remainder = add_epi8(remainder, remainder);
                    quotients = add_epi8(quotients, quotients);
                    bit = and_si128(ONE, dividend);
                    cmpbit = ternarylogic_si128(SIGN_BIT, remainder, bit, TernaryOperation.Ox1E);
                    retainRemainder = cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = or_si128(bit, remainder);
                    remainder = sub_epi8(remainder, andnot_si128(retainRemainder, divisor));
                    quotients = ternarylogic_si128(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                }

                constexpr.ASSUME_LT_EPU8(remainder, divisor, elements);
                return quotients;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivRemBitwise(v256 dividend, v256 divisor, out v256 remainder)
        {
VectorAssert.AreNotEqual<byte32, byte>(divisor, 0, 32);

            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = mm256_set1_epi8(1);
                v256 SIGN_BIT = mm256_set1_epi8(1 << 7);
                v256 quotients;

                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    quotients = Avx.mm256_setzero_si256();
                    remainder = Avx.mm256_setzero_si256();

                    for (int i = 7; i >= 0; i--)
                    {
                        remainder = Avx2.mm256_add_epi8(remainder, remainder);
                        quotients = Avx2.mm256_add_epi8(quotients, quotients);
                        remainder = mm256_ternarylogic_si256(ONE, mm256_srli_epi16(dividend, i), remainder, TernaryOperation.OxEA);
                        v256 subtractFromRemainder = mm256_cmple_epu8(divisor, remainder);
                        remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractFromRemainder));
                        quotients = Avx2.mm256_sub_epi8(quotients, subtractFromRemainder);
                    }
                }
                else
                {
                    v256 flippedDivisor = Avx2.mm256_xor_si256(divisor, SIGN_BIT);
                    v256 bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 7));
                    v256 cmpbit = mm256_ternarylogic_si256(SIGN_BIT, ONE, Avx2.mm256_srli_epi16(dividend, 7), TernaryOperation.OxF8);
                    v256 retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = bit;
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = Avx2.mm256_andnot_si256(retainRemainder, ONE);

                    //for (int i = 6; i != 0; i--)
                    //{
                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1));
                    cmpbit = mm256_ternarylogic_si256(remainder, bit, SIGN_BIT, TernaryOperation.OxFE);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                    //}
                    ////////////////////////////

                    remainder = Avx2.mm256_add_epi8(remainder, remainder);
                    quotients = Avx2.mm256_add_epi8(quotients, quotients);
                    bit = Avx2.mm256_and_si256(ONE, dividend);
                    cmpbit = mm256_ternarylogic_si256(SIGN_BIT, remainder, bit, TernaryOperation.Ox1E);
                    retainRemainder = Avx2.mm256_cmpgt_epi8(flippedDivisor, cmpbit);
                    remainder = Avx2.mm256_or_si256(bit, remainder);
                    remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_andnot_si256(retainRemainder, divisor));
                    quotients = mm256_ternarylogic_si256(retainRemainder, ONE, quotients, TernaryOperation.OxAE);
                }

                constexpr.ASSUME_LT_EPU8(remainder, divisor);
                return quotients;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivRemBitwiseSigned(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    if (elements <= 8)
                    {
                        Divider<sbyte>.bminit_epi8(divisor, out v128 mul16, Promise.Nothing, elements);

                        remainder = Divider<sbyte>.bmrem_epi8(dividend, mul16, divisor, Promise.Nothing, elements);
                        return Divider<sbyte>.bmdiv_epi8(dividend, mul16, divisor, Promise.Nothing, elements);
                    }
                    else
                    {
                        Divider<sbyte>.bminit_epi8(divisor, out v128 mul16Lo, out v128 mul16Hi, Promise.Nothing);

                        remainder = Divider<sbyte>.bmrem_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                        return Divider<sbyte>.bmdiv_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                    }
                }

                v128 unsignedQuotient = DivRemBitwise(abs_epi8(dividend, elements), abs_epi8(divisor, elements), out v128 unsignedRemainder, elements);

                return SIGNED_FROM_UNSIGNED_DIV_EPI8(out remainder, dividend, divisor, unsignedQuotient, unsignedRemainder, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivRemBitwiseSigned(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(divisor))
                {
                    Divider<sbyte>.mm256_bminit_epi8(divisor, out v256 mul16Lo, out v256 mul16Hi, Promise.Nothing);

                    remainder = Divider<sbyte>.mm256_bmrem_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                    return Divider<sbyte>.mm256_bmdiv_epi8(dividend, mul16Lo, mul16Hi, divisor, Promise.Nothing);
                }

                v256 unsignedQuotient = DivRemBitwise(mm256_abs_epi8(dividend), mm256_abs_epi8(divisor), out v256 unsignedRemainders);

                return SIGNED_FROM_UNSIGNED_DIV_EPI8(out remainder, dividend, divisor, unsignedQuotient, unsignedRemainders);
            }
            else throw new IllegalInstructionException();
        }
    }
}