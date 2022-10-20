using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivRemBitwise(v256 dividend, v256 divisor, out v256 remainder)
        {
Assert.AreNotEqual(divisor.Byte0,  0);
Assert.AreNotEqual(divisor.Byte1,  0);
Assert.AreNotEqual(divisor.Byte2,  0);
Assert.AreNotEqual(divisor.Byte3,  0);
Assert.AreNotEqual(divisor.Byte4,  0);
Assert.AreNotEqual(divisor.Byte5,  0);
Assert.AreNotEqual(divisor.Byte6,  0);
Assert.AreNotEqual(divisor.Byte7,  0);
Assert.AreNotEqual(divisor.Byte8,  0);
Assert.AreNotEqual(divisor.Byte9,  0);
Assert.AreNotEqual(divisor.Byte10, 0);
Assert.AreNotEqual(divisor.Byte11, 0);
Assert.AreNotEqual(divisor.Byte12, 0);
Assert.AreNotEqual(divisor.Byte13, 0);
Assert.AreNotEqual(divisor.Byte14, 0);
Assert.AreNotEqual(divisor.Byte15, 0);
Assert.AreNotEqual(divisor.Byte16, 0);
Assert.AreNotEqual(divisor.Byte17, 0);
Assert.AreNotEqual(divisor.Byte18, 0);
Assert.AreNotEqual(divisor.Byte19, 0);
Assert.AreNotEqual(divisor.Byte20, 0);
Assert.AreNotEqual(divisor.Byte21, 0);
Assert.AreNotEqual(divisor.Byte22, 0);
Assert.AreNotEqual(divisor.Byte23, 0);
Assert.AreNotEqual(divisor.Byte24, 0);
Assert.AreNotEqual(divisor.Byte25, 0);
Assert.AreNotEqual(divisor.Byte26, 0);
Assert.AreNotEqual(divisor.Byte27, 0);
Assert.AreNotEqual(divisor.Byte28, 0);
Assert.AreNotEqual(divisor.Byte29, 0);
Assert.AreNotEqual(divisor.Byte30, 0);
Assert.AreNotEqual(divisor.Byte31, 0);

            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi8(1);

                remainder = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 7));

                v256 subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                v256 quotients = Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder);
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                //}
                ////////////////////////////

                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, dividend, remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);


                return quotients;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivBitwise(v256 dividend, v256 divisor)
        {
Assert.AreNotEqual(divisor.Byte0,  0);
Assert.AreNotEqual(divisor.Byte1,  0);
Assert.AreNotEqual(divisor.Byte2,  0);
Assert.AreNotEqual(divisor.Byte3,  0);
Assert.AreNotEqual(divisor.Byte4,  0);
Assert.AreNotEqual(divisor.Byte5,  0);
Assert.AreNotEqual(divisor.Byte6,  0);
Assert.AreNotEqual(divisor.Byte7,  0);
Assert.AreNotEqual(divisor.Byte8,  0);
Assert.AreNotEqual(divisor.Byte9,  0);
Assert.AreNotEqual(divisor.Byte10, 0);
Assert.AreNotEqual(divisor.Byte11, 0);
Assert.AreNotEqual(divisor.Byte12, 0);
Assert.AreNotEqual(divisor.Byte13, 0);
Assert.AreNotEqual(divisor.Byte14, 0);
Assert.AreNotEqual(divisor.Byte15, 0);
Assert.AreNotEqual(divisor.Byte16, 0);
Assert.AreNotEqual(divisor.Byte17, 0);
Assert.AreNotEqual(divisor.Byte18, 0);
Assert.AreNotEqual(divisor.Byte19, 0);
Assert.AreNotEqual(divisor.Byte20, 0);
Assert.AreNotEqual(divisor.Byte21, 0);
Assert.AreNotEqual(divisor.Byte22, 0);
Assert.AreNotEqual(divisor.Byte23, 0);
Assert.AreNotEqual(divisor.Byte24, 0);
Assert.AreNotEqual(divisor.Byte25, 0);
Assert.AreNotEqual(divisor.Byte26, 0);
Assert.AreNotEqual(divisor.Byte27, 0);
Assert.AreNotEqual(divisor.Byte28, 0);
Assert.AreNotEqual(divisor.Byte29, 0);
Assert.AreNotEqual(divisor.Byte30, 0);
Assert.AreNotEqual(divisor.Byte31, 0);

            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi8(1);

                v256 remainder = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 7));

                v256 subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                v256 quotients = Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder);
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                //}
                ////////////////////////////

                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = mm256_ternarylogic_si256(ONE, dividend, remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                quotients = mm256_ternarylogic_si256(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);


                return quotients;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 RemBitwise(v256 dividend, v256 divisor)
        {
Assert.AreNotEqual(divisor.Byte0,  0);
Assert.AreNotEqual(divisor.Byte1,  0);
Assert.AreNotEqual(divisor.Byte2,  0);
Assert.AreNotEqual(divisor.Byte3,  0);
Assert.AreNotEqual(divisor.Byte4,  0);
Assert.AreNotEqual(divisor.Byte5,  0);
Assert.AreNotEqual(divisor.Byte6,  0);
Assert.AreNotEqual(divisor.Byte7,  0);
Assert.AreNotEqual(divisor.Byte8,  0);
Assert.AreNotEqual(divisor.Byte9,  0);
Assert.AreNotEqual(divisor.Byte10, 0);
Assert.AreNotEqual(divisor.Byte11, 0);
Assert.AreNotEqual(divisor.Byte12, 0);
Assert.AreNotEqual(divisor.Byte13, 0);
Assert.AreNotEqual(divisor.Byte14, 0);
Assert.AreNotEqual(divisor.Byte15, 0);
Assert.AreNotEqual(divisor.Byte16, 0);
Assert.AreNotEqual(divisor.Byte17, 0);
Assert.AreNotEqual(divisor.Byte18, 0);
Assert.AreNotEqual(divisor.Byte19, 0);
Assert.AreNotEqual(divisor.Byte20, 0);
Assert.AreNotEqual(divisor.Byte21, 0);
Assert.AreNotEqual(divisor.Byte22, 0);
Assert.AreNotEqual(divisor.Byte23, 0);
Assert.AreNotEqual(divisor.Byte24, 0);
Assert.AreNotEqual(divisor.Byte25, 0);
Assert.AreNotEqual(divisor.Byte26, 0);
Assert.AreNotEqual(divisor.Byte27, 0);
Assert.AreNotEqual(divisor.Byte28, 0);
Assert.AreNotEqual(divisor.Byte29, 0);
Assert.AreNotEqual(divisor.Byte30, 0);
Assert.AreNotEqual(divisor.Byte31, 0);

            if (Avx2.IsAvx2Supported)
            {
                v256 ONE = Avx.mm256_set1_epi8(1);
                
                v256 remainder = Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 7));

                v256 subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = mm256_ternarylogic_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = mm256_ternarylogic_si256(ONE, dividend, remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = mm256_cmple_epu8(divisor, remainder);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));


                return remainder;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivRemBitwiseSigned(v256 dividend, v256 divisor, out v256 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPI8(dividend, 0) && constexpr.ALL_GE_EPI8(divisor, 0))
                {
                    v256 quotient = DivRemBitwise(dividend, divisor, out v256 remainders);
                    remainder = remainders;

                    return quotient;
                }
                else
                {
                    v256 quotient = DivRemBitwise(Avx2.mm256_abs_epi8(dividend), Avx2.mm256_abs_epi8(divisor), out v256 remainders);

                    remainder = Avx2.mm256_sign_epi8(remainders, dividend);

                    quotient = Avx2.mm256_sign_epi8(quotient, Avx2.mm256_xor_si256(dividend, divisor));
                    quotient = Avx2.mm256_sub_epi8(quotient, Avx2.mm256_cmpeq_epi8(dividend, divisor));

                    return quotient;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 DivBitwiseSigned(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPI8(dividend, 0) && constexpr.ALL_GE_EPI8(divisor, 0))
                {
                    return DivBitwise(dividend, divisor);
                }
                else
                {
                    v256 quotient = DivBitwise(Avx2.mm256_abs_epi8(dividend), Avx2.mm256_abs_epi8(divisor));
                    
                    quotient = Avx2.mm256_sign_epi8(quotient, Avx2.mm256_xor_si256(dividend, divisor));
                    quotient = Avx2.mm256_sub_epi8(quotient, Avx2.mm256_cmpeq_epi8(dividend, divisor));

                    return quotient;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v256 RemBitwiseSigned(v256 dividend, v256 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPI8(dividend, 0) && constexpr.ALL_GE_EPI8(divisor, 0))
                {
                    return RemBitwise(dividend, divisor);
                }
                else
                {
                    byte32 remainder = RemBitwise(Avx2.mm256_abs_epi8(dividend), Avx2.mm256_abs_epi8(divisor));

                    return Avx2.mm256_sign_epi8(remainder, dividend);
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivRemBitwise(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
Assert.AreNotEqual(divisor.Byte0,  0);
Assert.AreNotEqual(divisor.Byte1,  0);
Assert.AreNotEqual(divisor.Byte2,  0);
Assert.AreNotEqual(divisor.Byte3,  0);
Assert.AreNotEqual(divisor.Byte4,  0);
Assert.AreNotEqual(divisor.Byte5,  0);
Assert.AreNotEqual(divisor.Byte6,  0);
Assert.AreNotEqual(divisor.Byte7,  0);
Assert.AreNotEqual(divisor.Byte8,  0);
Assert.AreNotEqual(divisor.Byte9,  0);
Assert.AreNotEqual(divisor.Byte10, 0);
Assert.AreNotEqual(divisor.Byte11, 0);
Assert.AreNotEqual(divisor.Byte12, 0);
Assert.AreNotEqual(divisor.Byte13, 0);
Assert.AreNotEqual(divisor.Byte14, 0);
Assert.AreNotEqual(divisor.Byte15, 0);

            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi8(1);

                remainder = Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 7));

                v128 subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                v128 quotients = Sse2.and_si128(ONE, subtractDivisorFromRemainder);
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 6), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);

                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 5), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 4), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 3), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 2), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 1), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                //}
                ////////////////////////////

                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, dividend, remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);


                return quotients;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivBitwise(v128 dividend, v128 divisor, byte elements = 16)
        {
Assert.AreNotEqual(divisor.Byte0,  0);
Assert.AreNotEqual(divisor.Byte1,  0);
Assert.AreNotEqual(divisor.Byte2,  0);
Assert.AreNotEqual(divisor.Byte3,  0);
Assert.AreNotEqual(divisor.Byte4,  0);
Assert.AreNotEqual(divisor.Byte5,  0);
Assert.AreNotEqual(divisor.Byte6,  0);
Assert.AreNotEqual(divisor.Byte7,  0);
Assert.AreNotEqual(divisor.Byte8,  0);
Assert.AreNotEqual(divisor.Byte9,  0);
Assert.AreNotEqual(divisor.Byte10, 0);
Assert.AreNotEqual(divisor.Byte11, 0);
Assert.AreNotEqual(divisor.Byte12, 0);
Assert.AreNotEqual(divisor.Byte13, 0);
Assert.AreNotEqual(divisor.Byte14, 0);
Assert.AreNotEqual(divisor.Byte15, 0);

            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi8(1);

                v128 remainder = Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 7));

                v128 subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                v128 quotients = Sse2.and_si128(ONE, subtractDivisorFromRemainder);
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 6), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 5), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 4), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 3), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 2), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                
                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 1), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);
                //}
                ////////////////////////////

                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = ternarylogic_si128(ONE, dividend, remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                quotients = ternarylogic_si128(ONE, subtractDivisorFromRemainder, quotients, TernaryOperation.OxEA);


                return quotients;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 RemBitwise(v128 dividend, v128 divisor, byte elements = 16)
        {
Assert.AreNotEqual(divisor.Byte0,  0);
Assert.AreNotEqual(divisor.Byte1,  0);
Assert.AreNotEqual(divisor.Byte2,  0);
Assert.AreNotEqual(divisor.Byte3,  0);
Assert.AreNotEqual(divisor.Byte4,  0);
Assert.AreNotEqual(divisor.Byte5,  0);
Assert.AreNotEqual(divisor.Byte6,  0);
Assert.AreNotEqual(divisor.Byte7,  0);
Assert.AreNotEqual(divisor.Byte8,  0);
Assert.AreNotEqual(divisor.Byte9,  0);
Assert.AreNotEqual(divisor.Byte10, 0);
Assert.AreNotEqual(divisor.Byte11, 0);
Assert.AreNotEqual(divisor.Byte12, 0);
Assert.AreNotEqual(divisor.Byte13, 0);
Assert.AreNotEqual(divisor.Byte14, 0);
Assert.AreNotEqual(divisor.Byte15, 0);

            if (Sse2.IsSse2Supported)
            {
                v128 ONE = Sse2.set1_epi8(1);
                
                v128 remainder = Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 7));

                v128 subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 6), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 5), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 4), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 3), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 2), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = ternarylogic_si128(ONE, Sse2.srli_epi16(dividend, 1), remainder, TernaryOperation.OxEA);
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, dividend));
                subtractDivisorFromRemainder = cmple_epu8(divisor, remainder, elements);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));


                return remainder;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivRemBitwiseSigned(v128 dividend, v128 divisor, out v128 remainder, byte elements = 16)
        {
            if (constexpr.ALL_GE_EPI8(dividend, 0, elements) && constexpr.ALL_GE_EPI8(divisor, 0, elements))
            {
                v128 quotient = DivRemBitwise((v128)dividend, (v128)divisor, out v128 remainders, elements);
                remainder = remainders;

                return quotient;
            }
            else if (Ssse3.IsSsse3Supported)
            {
                v128 quotient = DivRemBitwise(Ssse3.abs_epi8(dividend), Ssse3.abs_epi8(divisor), out v128 remainders, elements);
                quotient = Ssse3.sign_epi8(quotient, Sse2.xor_si128(dividend, divisor));
                quotient = Sse2.sub_epi8(quotient, Sse2.cmpeq_epi8(dividend, divisor));
                
                remainder = Ssse3.sign_epi8(remainders, dividend);

                return quotient;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();

                v128 leftNegative = Sse2.cmpgt_epi8(ZERO, dividend);
                v128 rightNegative = Sse2.cmpgt_epi8(ZERO, divisor);
                dividend = Sse2.sub_epi8(Sse2.xor_si128(dividend, leftNegative), leftNegative);
                divisor = Sse2.sub_epi8(Sse2.xor_si128(divisor, rightNegative), rightNegative);

                v128 quotient = DivRemBitwise(dividend, divisor, out v128 remainders, elements);
                remainder = Sse2.sub_epi8(Sse2.xor_si128(remainders, leftNegative), leftNegative);
                v128 mustNegate = Sse2.xor_si128(leftNegative, rightNegative);
                
                return Sse2.sub_epi8(Sse2.xor_si128(quotient, mustNegate), mustNegate);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 DivBitwiseSigned(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (constexpr.ALL_GE_EPI8(dividend, 0, elements) && constexpr.ALL_GE_EPI8(divisor, 0, elements))
            {
                return DivBitwise((v128)dividend, (v128)divisor, elements);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                v128 quotient = DivBitwise(Ssse3.abs_epi8(dividend), Ssse3.abs_epi8(divisor), elements);
                quotient = Ssse3.sign_epi8(quotient, Sse2.xor_si128(dividend, divisor));
                quotient = Sse2.sub_epi8(quotient, Sse2.cmpeq_epi8(dividend, divisor));

                return quotient;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();

                v128 leftNegative = Sse2.cmpgt_epi8(ZERO, dividend);
                v128 rightNegative = Sse2.cmpgt_epi8(ZERO, divisor);
                dividend = Sse2.sub_epi8(Sse2.xor_si128(dividend, leftNegative), leftNegative);
                divisor = Sse2.sub_epi8(Sse2.xor_si128(divisor, rightNegative), rightNegative);

                v128 quotient = DivBitwise(dividend, divisor, elements);
                v128 mustNegate = Sse2.xor_si128(leftNegative, rightNegative);
                
                return Sse2.sub_epi8(Sse2.xor_si128(quotient, mustNegate), mustNegate);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static v128 RemBitwiseSigned(v128 dividend, v128 divisor, byte elements = 16)
        {
            if (constexpr.ALL_GE_EPI8(dividend, 0, elements) && constexpr.ALL_GE_EPI8(divisor, 0, elements))
            {
                return RemBitwise((v128)dividend, (v128)divisor, elements);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                v128 remainder = RemBitwise(Ssse3.abs_epi8(dividend), Ssse3.abs_epi8(divisor), elements);

                return Ssse3.sign_epi8(remainder, dividend);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();

                v128 leftNegative = Sse2.cmpgt_epi8(ZERO, dividend);
                v128 rightNegative = Sse2.cmpgt_epi8(ZERO, divisor);
                dividend = Sse2.sub_epi8(Sse2.xor_si128(dividend, leftNegative), leftNegative);
                divisor = Sse2.sub_epi8(Sse2.xor_si128(divisor, rightNegative), rightNegative);

                v128 remainder = RemBitwise(dividend, divisor, elements);

                return Sse2.sub_epi8(Sse2.xor_si128(remainder, leftNegative), leftNegative);
            }
            else throw new IllegalInstructionException();
        }
    }
}