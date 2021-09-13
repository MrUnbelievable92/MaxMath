using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // Even though the code size is "large" and the C# source looks like a mess, 
    // this long division algorithm is about FIVE times faster than - (byte16 case), or EIGHT times faster than (byte32 case) scalar division of bytes 
    // or even via float conversion when compiled natively without Divide-By-Zero checks (release mode) - without requiring RAM-bandwidth-bound table-lookups.
    // Additionally, each loop iteration is a fantastic candidate for instruction level parallelism.
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 vdivrem_byte(v256 dividend, v256 divisor, out v256 remainder)
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

                v256 quotients = Avx.mm256_setzero_si256();
                remainder = Operator.shrl_byte(dividend, 7);

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, dividend));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));


                return quotients;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 vdiv_byte(v256 dividend, v256 divisor)
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

                v256 quotients = Avx.mm256_setzero_si256();
                v256 remainder = Operator.shrl_byte(dividend, 7);

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                quotients = Avx2.mm256_add_epi8(quotients, quotients);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, dividend));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                quotients = Avx2.mm256_or_si256(quotients, Avx2.mm256_and_si256(ONE, subtractDivisorFromRemainder));


                return quotients;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 vrem_byte(v256 dividend, v256 divisor)
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
                
                v256 remainder = Operator.shrl_byte(dividend, 7);

                v256 subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 6)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 5)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 4)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 3)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 2)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                
                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, Avx2.mm256_srli_epi16(dividend, 1)));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Avx2.mm256_add_epi8(remainder, remainder);
                remainder = Avx2.mm256_or_si256(remainder, Avx2.mm256_and_si256(ONE, dividend));
                subtractDivisorFromRemainder = Avx2.mm256_cmpeq_epi8(Avx2.mm256_min_epu8(divisor, remainder), divisor);
                remainder = Avx2.mm256_sub_epi8(remainder, Avx2.mm256_and_si256(divisor, subtractDivisorFromRemainder));


                return remainder;
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vdivrem_sbyte(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 quotient = vdivrem_byte(Avx2.mm256_abs_epi8(dividend), Avx2.mm256_abs_epi8(divisor), out v256 remainders);

                byte32 mustNegate = Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend);

                remainder = Avx2.mm256_sub_epi8(Avx2.mm256_xor_si256(remainders, mustNegate), mustNegate);

                mustNegate = Avx2.mm256_xor_si256(Avx2.mm256_cmpgt_epi8(sbyte32.zero, divisor),
                                                  Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend));

                return Avx2.mm256_sub_epi8(Avx2.mm256_xor_si256(quotient, mustNegate), mustNegate);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vdiv_sbyte(sbyte32 dividend, sbyte32 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 quotient = vdiv_byte(Avx2.mm256_abs_epi8(dividend), Avx2.mm256_abs_epi8(divisor));

                byte32 mustNegate = Avx2.mm256_xor_si256(Avx2.mm256_cmpgt_epi8(sbyte32.zero, divisor),
                                                         Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend));

                return Avx2.mm256_sub_epi8(Avx2.mm256_xor_si256(quotient, mustNegate), mustNegate);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte32 vrem_sbyte(sbyte32 dividend, sbyte32 divisor)
        {
            if (Avx2.IsAvx2Supported)
            {
                byte32 remainder = vrem_byte(Avx2.mm256_abs_epi8(dividend), Avx2.mm256_abs_epi8(divisor));

                byte32 mustNegate = Avx2.mm256_cmpgt_epi8(sbyte32.zero, dividend);

                return Avx2.mm256_sub_epi8(Avx2.mm256_xor_si256(remainder, mustNegate), mustNegate);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdivrem_byte(v128 dividend, v128 divisor, out v128 remainder)
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

                v128 quotients = Sse2.setzero_si128();
                remainder = Operator.shrl_byte(dividend, 7);

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 6)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 5)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 4)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 3)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 2)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 1)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, dividend));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));


                return quotients;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_byte(v128 dividend, v128 divisor)
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

                v128 quotients = Sse2.setzero_si128();
                v128 remainder = Operator.shrl_byte(dividend, 7);

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 6)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 5)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 4)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 3)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 2)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 1)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Sse2.add_epi8(remainder, remainder);
                quotients = Sse2.add_epi8(quotients, quotients);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, dividend));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                quotients = Sse2.or_si128(quotients, Sse2.and_si128(ONE, subtractDivisorFromRemainder));


                return quotients;
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vrem_byte(v128 dividend, v128 divisor)
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
                
                v128 remainder = Operator.shrl_byte(dividend, 7);

                v128 subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                // NOT ALWAYS UNROLLED BY THE COMPILER !! //
                //for (int i = 6; i > 0; i--)
                //{
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 6)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 5)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 4)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 3)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 2)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                
                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, Sse2.srli_epi16(dividend, 1)));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));
                //}
                ////////////////////////////

                remainder = Sse2.add_epi8(remainder, remainder);
                remainder = Sse2.or_si128(remainder, Sse2.and_si128(ONE, dividend));
                subtractDivisorFromRemainder = Sse2.cmpeq_epi8(Sse2.min_epu8(divisor, remainder), divisor);
                remainder = Sse2.sub_epi8(remainder, Sse2.and_si128(divisor, subtractDivisorFromRemainder));


                return remainder;
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdivrem_sbyte(v128 dividend, v128 divisor, out v128 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                byte16 quotient = vdivrem_byte(maxmath.abs((sbyte16)dividend), maxmath.abs((sbyte16)divisor), out v128 remainders);

                byte16 mustNegate = Sse2.cmpgt_epi8(sbyte16.zero, dividend);

                remainder = Sse2.sub_epi8(Sse2.xor_si128(remainders, mustNegate), mustNegate);

                mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte16.zero, divisor),
                                            Sse2.cmpgt_epi8(sbyte16.zero, dividend));

                return Sse2.sub_epi8(Sse2.xor_si128(quotient, mustNegate), mustNegate);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vdiv_sbyte(v128 dividend, v128 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
                byte16 quotient = vdiv_byte(maxmath.abs((sbyte16)dividend), maxmath.abs((sbyte16)divisor));

                byte16 mustNegate = Sse2.xor_si128(Sse2.cmpgt_epi8(sbyte16.zero, divisor),
                                                   Sse2.cmpgt_epi8(sbyte16.zero, dividend));

                return Sse2.sub_epi8(Sse2.xor_si128(quotient, mustNegate), mustNegate);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 vrem_sbyte(v128 dividend, v128 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
                byte16 remainder = vrem_byte(maxmath.abs((sbyte16)dividend), maxmath.abs((sbyte16)divisor));

                byte16 mustNegate = Sse2.cmpgt_epi8(sbyte16.zero, dividend);

                return Sse2.sub_epi8(Sse2.xor_si128(remainder, mustNegate), mustNegate);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vdivrem_byte_SSE_FALLBACK(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
#if DEBUG
                v128 ONE = Sse2.set1_epi8(1);

                byte8 quotients = (v128)vdivrem_byte(Sse2.unpacklo_epi64(dividend, ONE), Sse2.unpacklo_epi64(divisor, ONE), out v128 remainders);
                remainder = remainders;
                return quotients;
                
#else
                byte8 quotients = (v128)vdivrem_byte((v128)dividend, (v128)divisor, out v128 remainders);
                remainder = remainders;
                return quotients;
#endif
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vdiv_byte_SSE_FALLBACK(byte8 dividend, byte8 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
#if DEBUG
                v128 ONE = Sse2.set1_epi8(1);

                return vdiv_byte(Sse2.unpacklo_epi64(dividend, ONE), Sse2.unpacklo_epi64(divisor, ONE));
                
#else
                return vdiv_byte((v128)dividend, (v128)divisor);
#endif
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte8 vrem_byte_SSE_FALLBACK(byte8 dividend, byte8 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
#if DEBUG
                v128 ONE = Sse2.set1_epi8(1);

                return vrem_byte(Sse2.unpacklo_epi64(dividend, ONE), Sse2.unpacklo_epi64(divisor, ONE));
                
#else
                return vrem_byte((v128)dividend, (v128)divisor);
#endif
            }
            else throw new CPUFeatureCheckException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdivrem_sbyte_SSE_FALLBACK(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
#if DEBUG
                v128 ONE = Sse2.set1_epi8(1);

                sbyte8 quotients = (v128)vdivrem_sbyte(Sse2.unpacklo_epi64(dividend, ONE), Sse2.unpacklo_epi64(divisor, ONE), out v128 remainders);
                remainder = remainders;
                return quotients;
                
#else
                sbyte8 quotients = (v128)vdivrem_sbyte((v128)dividend, (v128)divisor, out v128 remainders);
                remainder = remainders;
                return quotients;
#endif
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vdiv_sbyte_SSE_FALLBACK(sbyte8 dividend, sbyte8 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
#if DEBUG
                v128 ONE = Sse2.set1_epi8(1);

                return vdiv_sbyte(Sse2.unpacklo_epi64(dividend, ONE), Sse2.unpacklo_epi64(divisor, ONE));
                
#else
                return vdiv_sbyte((v128)dividend, (v128)divisor);
#endif
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static sbyte8 vrem_sbyte_SSE_FALLBACK(sbyte8 dividend, sbyte8 divisor)
        {
            if (Sse2.IsSse2Supported)
            {
#if DEBUG
                v128 ONE = Sse2.set1_epi8(1);

                return vrem_sbyte(Sse2.unpacklo_epi64(dividend, ONE), Sse2.unpacklo_epi64(divisor, ONE));
                
#else
                return vrem_sbyte((v128)dividend, (v128)divisor);
#endif
            }
            else throw new CPUFeatureCheckException();
        }
    }
}