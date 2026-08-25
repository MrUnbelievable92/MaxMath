using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu8(v128 a, v128 b, bool promiseNonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Avx2.IsAvx2Supported)
                    {
                        switch (elements)
                        {
                            case 16:
                            {
                                v256 right16 = mm256_gcd_epu8_x16_epu16(a, b, promiseNonZero);
                                
                                // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                                v256 left16 = Avx2.mm256_cvtepu8_epi16(constexpr.IS_CONST(a) ? b : a);
                                v256 mul16 = Avx2.mm256_cvtepu8_epi16(constexpr.IS_CONST(a) ? a : b);

                                v256 result16 = Avx2.mm256_mullo_epi16(mm256_div_epu16(left16, right16), mul16);
                                
                                result = mm256_cvtepi16_epi8(result16);
                                break;
                            }
                            case 8:
                            {
                                v256 right32 = mm256_gcd_epu8_x8_epu32(a, b, promiseNonZero);
                                
                                // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                                v256 left32 = Avx2.mm256_cvtepu8_epi32(constexpr.IS_CONST(a) ? b : a);
                                v256 mul32 = Avx2.mm256_cvtepu8_epi32(constexpr.IS_CONST(a) ? a : b);

                                v256 result32 = Avx2.mm256_mullo_epi32(DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(left32), Avx.mm256_cvtepi32_ps(right32)), mul32);
                                
                                result = mm256_cvtepi32_epi8(result32);
                                break;
                            }
                            default:
                            {
                                v128 right32 = gcd_epu8_x4_epu32(a, b, promiseNonZero, elements);
                                
                                // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                                v128 left32 = cvtepu8_epi32(constexpr.IS_CONST(a) ? b : a);
                                v128 mul32 = cvtepu8_epi32(constexpr.IS_CONST(a) ? a : b);

                                v128 result32 = mullo_epi32(DIV_FLOATV_SIGNED_BYTE_RANGE_RET_INT(cvtepi32_ps(left32), cvtepi32_ps(right32)), mul32, elements);
                                
                                result = cvtepi32_epi8(result32, elements);
                                break;
                            }
                        }
                    }
                    else
                    {
                        // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                        v128 left = constexpr.IS_CONST(a) ? b : a;
                        v128 right = gcd_epu8(a, b, promiseNonZero, elements);
                        v128 mul = constexpr.IS_CONST(a) ? a : b;

                        result = divmullo_epu8(left, right, mul, out _, noOverflow: false, elements: elements);
                    }

                    Assume.lcm(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.lcm(result.Byte1,  a.Byte1,  b.Byte1);
                    Assume.lcm(result.Byte2,  a.Byte2,  b.Byte2);
                    Assume.lcm(result.Byte3,  a.Byte3,  b.Byte3);
                    Assume.lcm(result.Byte4,  a.Byte4,  b.Byte4);
                    Assume.lcm(result.Byte5,  a.Byte5,  b.Byte5);
                    Assume.lcm(result.Byte6,  a.Byte6,  b.Byte6);
                    Assume.lcm(result.Byte7,  a.Byte7,  b.Byte7);
                    Assume.lcm(result.Byte8,  a.Byte8,  b.Byte8);
                    Assume.lcm(result.Byte9,  a.Byte9,  b.Byte9);
                    Assume.lcm(result.Byte10, a.Byte10, b.Byte10);
                    Assume.lcm(result.Byte11, a.Byte11, b.Byte11);
                    Assume.lcm(result.Byte12, a.Byte12, b.Byte12);
                    Assume.lcm(result.Byte13, a.Byte13, b.Byte13);
                    Assume.lcm(result.Byte14, a.Byte14, b.Byte14);
                    Assume.lcm(result.Byte15, a.Byte15, b.Byte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu8x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                    v128 left0 = constexpr.IS_CONST(a0) ? b0 : a0;
                    v128 left1 = constexpr.IS_CONST(a1) ? b1 : a1;
                    gcd_epu8x2(a0, a1, b0, b1, out v128 right0, out v128 right1, promiseNonZero);
                    v128 mul0 = constexpr.IS_CONST(a0) ? a0 : b0;
                    v128 mul1 = constexpr.IS_CONST(a1) ? a1 : b1;

                    r0 = divmullo_epu8(left0, right0, mul0, out _, noOverflow: false, elements: 16);
                    r1 = divmullo_epu8(left1, right1, mul1, out _, noOverflow: false, elements: 16);
                    
                    Assume.lcm(r0.Byte0,  a0.Byte0,  b0.Byte0);
                    Assume.lcm(r0.Byte1,  a0.Byte1,  b0.Byte1);
                    Assume.lcm(r0.Byte2,  a0.Byte2,  b0.Byte2);
                    Assume.lcm(r0.Byte3,  a0.Byte3,  b0.Byte3);
                    Assume.lcm(r0.Byte4,  a0.Byte4,  b0.Byte4);
                    Assume.lcm(r0.Byte5,  a0.Byte5,  b0.Byte5);
                    Assume.lcm(r0.Byte6,  a0.Byte6,  b0.Byte6);
                    Assume.lcm(r0.Byte7,  a0.Byte7,  b0.Byte7);
                    Assume.lcm(r0.Byte8,  a0.Byte8,  b0.Byte8);
                    Assume.lcm(r0.Byte9,  a0.Byte9,  b0.Byte9);
                    Assume.lcm(r0.Byte10, a0.Byte10, b0.Byte10);
                    Assume.lcm(r0.Byte11, a0.Byte11, b0.Byte11);
                    Assume.lcm(r0.Byte12, a0.Byte12, b0.Byte12);
                    Assume.lcm(r0.Byte13, a0.Byte13, b0.Byte13);
                    Assume.lcm(r0.Byte14, a0.Byte14, b0.Byte14);
                    Assume.lcm(r0.Byte15, a0.Byte15, b0.Byte15);

                    Assume.lcm(r1.Byte0,  a1.Byte0,  b1.Byte0);
                    Assume.lcm(r1.Byte1,  a1.Byte1,  b1.Byte1);
                    Assume.lcm(r1.Byte2,  a1.Byte2,  b1.Byte2);
                    Assume.lcm(r1.Byte3,  a1.Byte3,  b1.Byte3);
                    Assume.lcm(r1.Byte4,  a1.Byte4,  b1.Byte4);
                    Assume.lcm(r1.Byte5,  a1.Byte5,  b1.Byte5);
                    Assume.lcm(r1.Byte6,  a1.Byte6,  b1.Byte6);
                    Assume.lcm(r1.Byte7,  a1.Byte7,  b1.Byte7);
                    Assume.lcm(r1.Byte8,  a1.Byte8,  b1.Byte8);
                    Assume.lcm(r1.Byte9,  a1.Byte9,  b1.Byte9);
                    Assume.lcm(r1.Byte10, a1.Byte10, b1.Byte10);
                    Assume.lcm(r1.Byte11, a1.Byte11, b1.Byte11);
                    Assume.lcm(r1.Byte12, a1.Byte12, b1.Byte12);
                    Assume.lcm(r1.Byte13, a1.Byte13, b1.Byte13);
                    Assume.lcm(r1.Byte14, a1.Byte14, b1.Byte14);
                    Assume.lcm(r1.Byte15, a1.Byte15, b1.Byte15);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu8(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                    v256 left = constexpr.IS_CONST(a) ? b : a;
                    v256 right = mm256_gcd_epu8(a, b, promiseNonZero);
                    v256 mul = constexpr.IS_CONST(a) ? a : b;

                    v256 result = mm256_divmullo_epu8(left, right, mul, out _, noOverflow: false);

                    Assume.lcm(result.Byte0,  a.Byte0,  b.Byte0);
                    Assume.lcm(result.Byte1,  a.Byte1,  b.Byte1);
                    Assume.lcm(result.Byte2,  a.Byte2,  b.Byte2);
                    Assume.lcm(result.Byte3,  a.Byte3,  b.Byte3);
                    Assume.lcm(result.Byte4,  a.Byte4,  b.Byte4);
                    Assume.lcm(result.Byte5,  a.Byte5,  b.Byte5);
                    Assume.lcm(result.Byte6,  a.Byte6,  b.Byte6);
                    Assume.lcm(result.Byte7,  a.Byte7,  b.Byte7);
                    Assume.lcm(result.Byte8,  a.Byte8,  b.Byte8);
                    Assume.lcm(result.Byte9,  a.Byte9,  b.Byte9);
                    Assume.lcm(result.Byte10, a.Byte10, b.Byte10);
                    Assume.lcm(result.Byte11, a.Byte11, b.Byte11);
                    Assume.lcm(result.Byte12, a.Byte12, b.Byte12);
                    Assume.lcm(result.Byte13, a.Byte13, b.Byte13);
                    Assume.lcm(result.Byte14, a.Byte14, b.Byte14);
                    Assume.lcm(result.Byte15, a.Byte15, b.Byte15);
                    Assume.lcm(result.Byte16, a.Byte16, b.Byte16);
                    Assume.lcm(result.Byte17, a.Byte17, b.Byte17);
                    Assume.lcm(result.Byte18, a.Byte18, b.Byte18);
                    Assume.lcm(result.Byte19, a.Byte19, b.Byte19);
                    Assume.lcm(result.Byte20, a.Byte20, b.Byte20);
                    Assume.lcm(result.Byte21, a.Byte21, b.Byte21);
                    Assume.lcm(result.Byte22, a.Byte22, b.Byte22);
                    Assume.lcm(result.Byte23, a.Byte23, b.Byte23);
                    Assume.lcm(result.Byte24, a.Byte24, b.Byte24);
                    Assume.lcm(result.Byte25, a.Byte25, b.Byte25);
                    Assume.lcm(result.Byte26, a.Byte26, b.Byte26);
                    Assume.lcm(result.Byte27, a.Byte27, b.Byte27);
                    Assume.lcm(result.Byte28, a.Byte28, b.Byte28);
                    Assume.lcm(result.Byte29, a.Byte29, b.Byte29);
                    Assume.lcm(result.Byte30, a.Byte30, b.Byte30);
                    Assume.lcm(result.Byte31, a.Byte31, b.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu16(v128 a, v128 b, bool promiseNonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (Avx2.IsAvx2Supported)
                    {
                        switch (elements)
                        {
                            case 8:
                            {
                                v256 right32 = mm256_gcd_epu16_x8_epu32(a, b, promiseNonZero);
                                
                                // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                                v256 left32 = Avx2.mm256_cvtepu16_epi32(constexpr.IS_CONST(a) ? b : a);
                                v128 mul = constexpr.IS_CONST(a) ? a : b;

                                v256 result32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(left32), Avx.mm256_cvtepi32_ps(right32));
                                
                                result = mullo_epi16(mm256_cvtepi32_epi16(result32), mul);
                                break;
                            }
                            default:
                            {
                                v128 right32 = gcd_epu16_x4_epu32(a, b, promiseNonZero, elements);
                                
                                // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                                v128 left32 = cvtepu16_epi32(constexpr.IS_CONST(a) ? b : a);
                                v128 mul = constexpr.IS_CONST(a) ? a : b;

                                v128 result32 = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(left32), cvtepi32_ps(right32));
                                
                                result = mullo_epi16(cvtepi32_epi16(result32, elements), mul);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            result = mullo_epi16(div_epu16(b, gcd_epu16(a, b, promiseNonZero, elements), elements), a);
                        }
                        else
                        {
                            result = mullo_epi16(div_epu16(a, gcd_epu16(a, b, promiseNonZero, elements), elements), b);
                        }
                    }

                    Assume.lcm(result.UShort0, a.UShort0, b.UShort0);
                    Assume.lcm(result.UShort1, a.UShort1, b.UShort1);
                    Assume.lcm(result.UShort2, a.UShort2, b.UShort2);
                    Assume.lcm(result.UShort3, a.UShort3, b.UShort3);
                    Assume.lcm(result.UShort4, a.UShort4, b.UShort4);
                    Assume.lcm(result.UShort5, a.UShort5, b.UShort5);
                    Assume.lcm(result.UShort6, a.UShort6, b.UShort6);
                    Assume.lcm(result.UShort7, a.UShort7, b.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu16x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    gcd_epu16x2(a0, a1, b0, b1, out v128 gcd0, out v128 gcd1, promiseNonZero);

                    if (constexpr.IS_CONST(a0))
                    {
                        r0 = mullo_epi16(div_epu16(b0, gcd0), a0);

                    }
                    else
                    {
                        r0 = mullo_epi16(div_epu16(a0, gcd0), b0);
                    }

                    if (constexpr.IS_CONST(a1))
                    {
                        r1 = mullo_epi16(div_epu16(b1, gcd1), a1);
                    }
                    else
                    {
                        r1 = mullo_epi16(div_epu16(a1, gcd1), b1);
                    }

                    Assume.lcm(r0.UShort0, a0.UShort0, b0.UShort0);
                    Assume.lcm(r0.UShort1, a0.UShort1, b0.UShort1);
                    Assume.lcm(r0.UShort2, a0.UShort2, b0.UShort2);
                    Assume.lcm(r0.UShort3, a0.UShort3, b0.UShort3);
                    Assume.lcm(r0.UShort4, a0.UShort4, b0.UShort4);
                    Assume.lcm(r0.UShort5, a0.UShort5, b0.UShort5);
                    Assume.lcm(r0.UShort6, a0.UShort6, b0.UShort6);
                    Assume.lcm(r0.UShort7, a0.UShort7, b0.UShort7);

                    Assume.lcm(r1.UShort0, a1.UShort0, b1.UShort0);
                    Assume.lcm(r1.UShort1, a1.UShort1, b1.UShort1);
                    Assume.lcm(r1.UShort2, a1.UShort2, b1.UShort2);
                    Assume.lcm(r1.UShort3, a1.UShort3, b1.UShort3);
                    Assume.lcm(r1.UShort4, a1.UShort4, b1.UShort4);
                    Assume.lcm(r1.UShort5, a1.UShort5, b1.UShort5);
                    Assume.lcm(r1.UShort6, a1.UShort6, b1.UShort6);
                    Assume.lcm(r1.UShort7, a1.UShort7, b1.UShort7);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu16(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.IS_CONST(a))
                    {
                        result = Avx2.mm256_mullo_epi16(mm256_div_epu16(b, mm256_gcd_epu16(a, b, promiseNonZero)), a);
                    }
                    else
                    {
                        result = Avx2.mm256_mullo_epi16(mm256_div_epu16(a, mm256_gcd_epu16(a, b, promiseNonZero)), b);
                    }

                    Assume.lcm(result.UShort0,  a.UShort0,  b.UShort0);
                    Assume.lcm(result.UShort1,  a.UShort1,  b.UShort1);
                    Assume.lcm(result.UShort2,  a.UShort2,  b.UShort2);
                    Assume.lcm(result.UShort3,  a.UShort3,  b.UShort3);
                    Assume.lcm(result.UShort4,  a.UShort4,  b.UShort4);
                    Assume.lcm(result.UShort5,  a.UShort5,  b.UShort5);
                    Assume.lcm(result.UShort6,  a.UShort6,  b.UShort6);
                    Assume.lcm(result.UShort7,  a.UShort7,  b.UShort7);
                    Assume.lcm(result.UShort8,  a.UShort8,  b.UShort8);
                    Assume.lcm(result.UShort9,  a.UShort9,  b.UShort9);
                    Assume.lcm(result.UShort10, a.UShort10, b.UShort10);
                    Assume.lcm(result.UShort11, a.UShort11, b.UShort11);
                    Assume.lcm(result.UShort12, a.UShort12, b.UShort12);
                    Assume.lcm(result.UShort13, a.UShort13, b.UShort13);
                    Assume.lcm(result.UShort14, a.UShort14, b.UShort14);
                    Assume.lcm(result.UShort15, a.UShort15, b.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu32(v128 a, v128 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (constexpr.IS_CONST(a))
                    {
                        result = mullo_epi32(div_epu32(b, gcd_epu32(a, b, promiseNonZero, elements), elements), a, elements);
                    }
                    else
                    {
                        result = mullo_epi32(div_epu32(a, gcd_epu32(a, b, promiseNonZero, elements), elements), b, elements);
                    }

                    Assume.lcm(result.UInt0, a.UInt0, b.UInt0);
                    Assume.lcm(result.UInt1, a.UInt1, b.UInt1);
                    Assume.lcm(result.UInt2, a.UInt2, b.UInt2);
                    Assume.lcm(result.UInt3, a.UInt3, b.UInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu32x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    gcd_epu32x2(a0, a1, b0, b1, out v128 gcd0, out v128 gcd1, promiseNonZero);

                    if (constexpr.IS_CONST(a0))
                    {
                        r0 = mullo_epi32(div_epu32(b0, gcd0), a0);

                    }
                    else
                    {
                        r0 = mullo_epi32(div_epu32(a0, gcd0), b0);
                    }

                    if (constexpr.IS_CONST(a1))
                    {
                        r1 = mullo_epi32(div_epu32(b1, gcd1), a1);
                    }
                    else
                    {
                        r1 = mullo_epi32(div_epu32(a1, gcd1), b1);
                    }

                    Assume.lcm(r0.UInt0, a0.UInt0, b0.UInt0);
                    Assume.lcm(r0.UInt1, a0.UInt1, b0.UInt1);
                    Assume.lcm(r0.UInt2, a0.UInt2, b0.UInt2);
                    Assume.lcm(r0.UInt3, a0.UInt3, b0.UInt3);

                    Assume.lcm(r1.UInt0, a1.UInt0, b1.UInt0);
                    Assume.lcm(r1.UInt1, a1.UInt1, b1.UInt1);
                    Assume.lcm(r1.UInt2, a1.UInt2, b1.UInt2);
                    Assume.lcm(r1.UInt3, a1.UInt3, b1.UInt3);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu32(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.IS_CONST(a))
                    {
                        result = Avx2.mm256_mullo_epi32(mm256_div_epu32(b, mm256_gcd_epu32(a, b, promiseNonZero)), a);
                    }
                    else
                    {
                        result = Avx2.mm256_mullo_epi32(mm256_div_epu32(a, mm256_gcd_epu32(a, b, promiseNonZero)), b);
                    }

                    Assume.lcm(result.UInt0, a.UInt0, b.UInt0);
                    Assume.lcm(result.UInt1, a.UInt1, b.UInt1);
                    Assume.lcm(result.UInt2, a.UInt2, b.UInt2);
                    Assume.lcm(result.UInt3, a.UInt3, b.UInt3);
                    Assume.lcm(result.UInt4, a.UInt4, b.UInt4);
                    Assume.lcm(result.UInt5, a.UInt5, b.UInt5);
                    Assume.lcm(result.UInt6, a.UInt6, b.UInt6);
                    Assume.lcm(result.UInt7, a.UInt7, b.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu64(v128 a, v128 b, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (constexpr.IS_CONST(a))
                    {
                        result = mullo_epi64(div_epu64(b, gcd_epu64(a, b, promiseNonZero)), a);
                    }
                    else
                    {
                        result = mullo_epi64(div_epu64(a, gcd_epu64(a, b, promiseNonZero)), b);
                    }

                    Assume.lcm(result.ULong0, a.ULong0, b.ULong0);
                    Assume.lcm(result.ULong1, a.ULong1, b.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu64x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    gcd_epu64x2(a0, a1, b0, b1, out v128 gcd0, out v128 gcd1, promiseNonZero);

                    if (constexpr.IS_CONST(a0))
                    {
                        r0 = mullo_epi64(div_epu64(b0, gcd0), a0);

                    }
                    else
                    {
                        r0 = mullo_epi64(div_epu64(a0, gcd0), b0);
                    }

                    if (constexpr.IS_CONST(a1))
                    {
                        r1 = mullo_epi64(div_epu64(b1, gcd1), a1);
                    }
                    else
                    {
                        r1 = mullo_epi64(div_epu64(a1, gcd1), b1);
                    }

                    Assume.lcm(r0.ULong0, a0.ULong0, b0.ULong0);
                    Assume.lcm(r0.ULong1, a0.ULong1, b0.ULong1);

                    Assume.lcm(r1.ULong0, a1.ULong0, b1.ULong0);
                    Assume.lcm(r1.ULong1, a1.ULong1, b1.ULong1);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu64(v256 a, v256 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.IS_CONST(a))
                    {
                        result = mm256_mullo_epi64(mm256_div_epu64(b, mm256_gcd_epu64(a, b, promiseNonZero, elements), elements: elements), a, elements);
                    }
                    else
                    {
                        result = mm256_mullo_epi64(mm256_div_epu64(a, mm256_gcd_epu64(a, b, promiseNonZero, elements), elements: elements), b, elements);
                    }

                    Assume.lcm(result.ULong0, a.ULong0, b.ULong0);
                    Assume.lcm(result.ULong1, a.ULong1, b.ULong1);
                    Assume.lcm(result.ULong2, a.ULong2, b.ULong2);
                    Assume.lcm(result.ULong3, a.ULong3, b.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void lcm(byte result, byte a, byte b)
        {
            if (constexpr.IS_TRUE(a <= byte.MaxValue >> (8 / 2))
             && constexpr.IS_TRUE(b <= byte.MaxValue >> (8 / 2)))
            {
                constexpr.ASSUME(a == 0 || result % a == 0);
                constexpr.ASSUME(b == 0 || result % b == 0);
                constexpr.ASSUME(result >= a);
                constexpr.ASSUME(result >= b);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void lcm(ushort result, ushort a, ushort b)
        {
            if (constexpr.IS_TRUE(a <= ushort.MaxValue >> (16 / 2))
             && constexpr.IS_TRUE(b <= ushort.MaxValue >> (16 / 2)))
            {
                constexpr.ASSUME(a == 0 || result % a == 0);
                constexpr.ASSUME(b == 0 || result % b == 0);
                constexpr.ASSUME(result >= a);
                constexpr.ASSUME(result >= b);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void lcm(uint result, uint a, uint b)
        {
            if (constexpr.IS_TRUE(a <= uint.MaxValue >> (32 / 2))
             && constexpr.IS_TRUE(b <= uint.MaxValue >> (32 / 2)))
            {
                constexpr.ASSUME(a == 0 || result % a == 0);
                constexpr.ASSUME(b == 0 || result % b == 0);
                constexpr.ASSUME(result >= a);
                constexpr.ASSUME(result >= b);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void lcm(ulong result, ulong a, ulong b)
        {
            if (constexpr.IS_TRUE(a <= ulong.MaxValue >> (64 / 2))
             && constexpr.IS_TRUE(b <= ulong.MaxValue >> (64 / 2)))
            {
                constexpr.ASSUME(a == 0 || result % a == 0);
                constexpr.ASSUME(b == 0 || result % b == 0);
                constexpr.ASSUME(result >= a);
                constexpr.ASSUME(result >= b);
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Returns the least common multiple of two <see cref="UInt128"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(UInt128 x, UInt128 y, Promise nonZero = Promise.Nothing)
        {
            UInt128 result;

            if (constexpr.IS_CONST(x))
            {
                result = (y / gcd(x, y, nonZero)) * x;
            }
            else
            {
                result = (x / gcd(x, y, nonZero)) * y;
            }
            
            if (constexpr.IS_TRUE(x <= UInt128.MaxValue >> (128 / 2))
             && constexpr.IS_TRUE(y <= UInt128.MaxValue >> (128 / 2)))
            {
                //constexpr.ASSUME(x == 0 || result % x == 0;
                //constexpr.ASSUME(y == 0 || result % y == 0;
                constexpr.ASSUME(result >= x);
                constexpr.ASSUME(result >= y);
            }

            return result;
        }

        /// <summary>       Returns the least common multiple of two <see cref="Int128"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(Int128 x, Int128 y, Promise nonZero = Promise.Nothing)
        {
            UInt128 result;

            UInt128 absX = (UInt128)abs(x);
            UInt128 absY = (UInt128)abs(y);

            if (constexpr.IS_CONST(absX))
            {
                result = (absY / gcd(absX, absY, nonZero)) * absX;
            }
            else
            {
                result = (absX / gcd(absX, absY, nonZero)) * absY;
            }
            
            if (constexpr.IS_TRUE((UInt128)abs(x) <= UInt128.MaxValue >> (128 / 2))
             && constexpr.IS_TRUE((UInt128)abs(y) <= UInt128.MaxValue >> (128 / 2)))
            {
                //constexpr.ASSUME(x == 0 || result % (UInt128)abs(x) == 0;
                //constexpr.ASSUME(y == 0 || result % (UInt128)abs(y) == 0;
                constexpr.ASSUME(result >= (UInt128)abs(x));
                constexpr.ASSUME(result >= (UInt128)abs(y));
            }

            return result;
        }


        /// <summary>       Returns the least common multiple of two <see cref="byte"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, (ulong)byte.MaxValue * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(byte x, byte y, Promise nonZero = Promise.Nothing)
        {
            return lcm((uint)x, (uint)y, nonZero);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="byte2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(byte2 x, byte2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="byte3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(byte3 x, byte3 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="byte4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(byte4 x, byte4 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="byte8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(byte8 x, byte8 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="byte16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(byte16 x, byte16 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 16);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="byte32"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(byte32 x, byte32 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu8(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu8x2(x.v16_0, x.v16_16, y.v16_0, y.v16_16, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new byte32(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="sbyte"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, ((ulong)sbyte.MaxValue + 1ul) * ((ulong)sbyte.MaxValue + 1ul))]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(sbyte x, sbyte y, Promise nonZero = Promise.Nothing)
        {
            return lcm((int)x, (int)y, nonZero);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="sbyte2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(sbyte2 x, sbyte2 y, Promise nonZero = Promise.Nothing)
        {
            byte2 absX = (byte2)abs(x);
            byte2 absY = (byte2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="sbyte3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(sbyte3 x, sbyte3 y, Promise nonZero = Promise.Nothing)
        {
            byte3 absX = (byte3)abs(x);
            byte3 absY = (byte3)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="sbyte4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(sbyte4 x, sbyte4 y, Promise nonZero = Promise.Nothing)
        {
            byte4 absX = (byte4)abs(x);
            byte4 absY = (byte4)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="sbyte8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(sbyte8 x, sbyte8 y, Promise nonZero = Promise.Nothing)
        {
            byte8 absX = (byte8)abs(x);
            byte8 absY = (byte8)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="sbyte16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(sbyte16 x, sbyte16 y, Promise nonZero = Promise.Nothing)
        {
            byte16 absX = (byte16)abs(x);
            byte16 absY = (byte16)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 16);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="sbyte32"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(sbyte32 x, sbyte32 y, Promise nonZero = Promise.Nothing)
        {
            byte32 absX = (byte32)abs(x);
            byte32 absY = (byte32)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu8x2(absX.v16_0, absX.v16_16, absY.v16_0, absY.v16_16, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new byte32(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="ushort"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(ushort x, ushort y, Promise nonZero = Promise.Nothing)
        {
            return lcm((uint)x, (uint)y, nonZero);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ushort2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(ushort2 x, ushort2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ushort3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(ushort3 x, ushort3 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ushort4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(ushort4 x, ushort4 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ushort8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(ushort8 x, ushort8 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ushort16"/>s.r.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(ushort16 x, ushort16 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu16(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu16x2(x.v8_0, x.v8_8, y.v8_0, y.v8_8, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ushort16(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="short"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(short x, short y, Promise nonZero = Promise.Nothing)
        {
            return lcm((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="short2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(short2 x, short2 y, Promise nonZero = Promise.Nothing)
        {
            ushort2 absX = (ushort2)abs(x);
            ushort2 absY = (ushort2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="short3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(short3 x, short3 y, Promise nonZero = Promise.Nothing)
        {
            ushort3 absX = (ushort3)abs(x);
            ushort3 absY = (ushort3)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="short4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(short4 x, short4 y, Promise nonZero = Promise.Nothing)
        {
            ushort4 absX = (ushort4)abs(x);
            ushort4 absY = (ushort4)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="short8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(short8 x, short8 y, Promise nonZero = Promise.Nothing)
        {
            ushort8 absX = (ushort8)abs(x);
            ushort8 absY = (ushort8)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="short16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(short16 x, short16 y, Promise nonZero = Promise.Nothing)
        {
            ushort16 absX = (ushort16)abs(x);
            ushort16 absY = (ushort16)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu16x2(absX.v8_0, absX.v8_8, absY.v8_0, absY.v8_8, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ushort16(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="int"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(int x, int y, Promise nonZero = Promise.Nothing)
        {
            uint result;

            uint absX = constexpr.IS_TRUE(x >= 0) ? (uint)x : (uint)abs(x);
            uint absY = constexpr.IS_TRUE(y >= 0) ? (uint)y : (uint)abs(y);

            if (constexpr.IS_CONST(absX))
            {
                result = (absY / gcd(absX, absY, nonZero)) * absX;
            }
            else
            {
                result = (absX / gcd(absX, absY, nonZero)) * absY;
            }

            Assume.lcm(result, (uint)abs(x), (uint)abs(y));

            return result;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(int2 x, int2 y, Promise nonZero = Promise.Nothing)
        {
            uint2 absX = constexpr.IS_TRUE(all(x >= 0)) ? (uint2)x : (uint2)abs(x);
            uint2 absY = constexpr.IS_TRUE(all(y >= 0)) ? (uint2)y : (uint2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu32(absX, absY, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(int3 x, int3 y, Promise nonZero = Promise.Nothing)
        {
            uint3 absX = constexpr.IS_TRUE(all(x >= 0)) ? (uint3)x : (uint3)abs(x);
            uint3 absY = constexpr.IS_TRUE(all(y >= 0)) ? (uint3)y : (uint3)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu32(absX, absY, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(int4 x, int4 y, Promise nonZero = Promise.Nothing)
        {
            uint4 absX = constexpr.IS_TRUE(all(x >= 0)) ? (uint4)x : (uint4)abs(x);
            uint4 absY = constexpr.IS_TRUE(all(y >= 0)) ? (uint4)y : (uint4)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu32(absX, absY, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(int8 x, int8 y, Promise nonZero = Promise.Nothing)
        {
            uint8 absX = constexpr.IS_TRUE(all(x >= 0)) ? (uint8)x : (uint8)abs(x);
            uint8 absY = constexpr.IS_TRUE(all(y >= 0)) ? (uint8)y : (uint8)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu32(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu32x2(absX.v4_0, absX.v4_4, absY.v4_0, absY.v4_4, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new uint8(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="uint"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(uint x, uint y, Promise nonZero = Promise.Nothing)
        {
            uint result;

            if (constexpr.IS_CONST(x))
            {
                result = (y / gcd(x, y, nonZero)) * x;
            }
            else
            {
                result = (x / gcd(x, y, nonZero)) * y;
            }

            Assume.lcm(result, x, y);

            return result;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(uint2 x, uint2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu32(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(uint3 x, uint3 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu32(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(uint4 x, uint4 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu32(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(uint8 x, uint8 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu32(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu32x2(x.v4_0, x.v4_4, y.v4_0, y.v4_4, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new uint8(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="long"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(long x, long y, Promise nonZero = Promise.Nothing)
        {
            ulong result;

            ulong absX = constexpr.IS_TRUE(x >= 0) ? (ulong)x : (ulong)abs(x);
            ulong absY = constexpr.IS_TRUE(y >= 0) ? (ulong)y : (ulong)abs(y);

            if (constexpr.IS_CONST(x))
            {
                result = (absY / gcd(absX, absY, nonZero)) * absX;
            }
            else
            {
                result = (absX / gcd(absX, absY, nonZero)) * absY;
            }

            Assume.lcm(result, (ulong)abs(x), (ulong)abs(y));

            return result;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="long2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(long2 x, long2 y, Promise nonZero = Promise.Nothing)
        {
            ulong2 absX = (ulong2)abs(x);
            ulong2 absY = (ulong2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu64(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="long3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(long3 x, long3 y, Promise nonZero = Promise.Nothing)
        {
            ulong3 absX = (ulong3)abs(x);
            ulong3 absY = (ulong3)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(absX, absY, nonZero.Promises(Promise.NonZero), 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(absX.xy, absX.zz, absY.xy, absY.zz, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="long4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(long4 x, long4 y, Promise nonZero = Promise.Nothing)
        {
            ulong4 absX = (ulong4)abs(x);
            ulong4 absY = (ulong4)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(absX, absY, nonZero.Promises(Promise.NonZero), 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(absX.xy, absX.zw, absY.xy, absY.zw, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong4(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="ulong"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(ulong x, ulong y, Promise nonZero = Promise.Nothing)
        {
            ulong result;

            if (constexpr.IS_CONST(x))
            {
                result = (y / gcd(x, y, nonZero)) * x;
            }
            else
            {
                result = (x / gcd(x, y, nonZero)) * y;
            }

            Assume.lcm(result, x, y);

            return result;
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ulong2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(ulong2 x, ulong2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu64(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ulong3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(ulong3 x, ulong3 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(x.xy, x.zz, y.xy, y.zz, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="ulong4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(ulong4 x, ulong4 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(x.xy, x.zw, y.xy, y.zw, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong4(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }
    }
}