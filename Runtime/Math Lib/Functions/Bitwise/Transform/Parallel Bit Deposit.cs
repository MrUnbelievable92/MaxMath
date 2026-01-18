using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    // LLVM does not unroll + constant fold (the latter is relevant) if compiling for size
    // The code size is smaller than the loop version if `mask` is constant

    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP0_pdep_epi8([NoAlias] ref v128 mask, [NoAlias] ref v128 mk, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi8(mk, mk));
                    mp = xor_si128(mp, slli_epi8(mp, 2));
                    mp = xor_si128(mp, slli_epi8(mp, 4));
                    v128 mv = and_si128(mp, mask);
                    array[i] = mv;
                    mask = ternarylogic_si128(srli_epi8(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP1_pdep_epi8([NoAlias] ref v128 a, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    a = blendb_si128(a, slli_epi8(a, 1 << i, inRange: true), array[i]);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi8(v128 a, v128 mask, byte elements = 16)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    switch (elements)
                    {
                        case 2:  return                unpacklo_epi8(cvtsi32_si128(Bmi2.pdep_u32(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(Bmi2.pdep_u32(a.Byte1, mask.Byte1)));

                        case 3:  return unpacklo_epi16(unpacklo_epi8(cvtsi32_si128(Bmi2.pdep_u32(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(Bmi2.pdep_u32(a.Byte1, mask.Byte1))),
                                                                     cvtsi32_si128(Bmi2.pdep_u32(a.Byte2, mask.Byte2)));
                        case 4:  return unpacklo_epi16(unpacklo_epi8(cvtsi32_si128(Bmi2.pdep_u32(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(Bmi2.pdep_u32(a.Byte1, mask.Byte1))),
                                                       unpacklo_epi8(cvtsi32_si128(Bmi2.pdep_u32(a.Byte2, mask.Byte2)),
                                                                     cvtsi32_si128(Bmi2.pdep_u32(a.Byte3, mask.Byte3))));
                        default: break;
                    }
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 m0 = mask;
                    v128 mk = add_epi8(not_si128(mask), not_si128(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        v128 a0 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi8(a0, 1), mask, a0, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        v128 a1 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi8(a1, 2), mask, a1, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        v128 a2 = and_si128(mp, mask);

                        a = blendb_si128(a, slli_epi8(a, 4), a2);
                        a = blendb_si128(a, slli_epi8(a, 2), a1);
                        a = blendb_si128(a, slli_epi8(a, 1), a0);
                    }
                    else
                    {
                        v128* array = stackalloc v128[3];
                        for (int i = 0; i < 3; i++)
                        {
                            LOOP0_pdep_epi8(ref mask, ref mk, array, i);
                        }
                        for (int i = 2; i >= 0; i--)
                        {
                            LOOP1_pdep_epi8(ref a, array, i);
                        }
                    }

                    return and_si128(a, m0);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi8x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pdep_epi8(a0, mask0);
                        r1 = pdep_epi8(a1, mask1);
                    }
                    else
                    {
                        v128 m00 = mask0;
                        v128 mk0 = add_epi8(not_si128(mask0), not_si128(mask0));
                        v128 m01 = mask1;
                        v128 mk1 = add_epi8(not_si128(mask1), not_si128(mask1));

                        v128* array0 = stackalloc v128[3];
                        v128* array1 = stackalloc v128[3];
                        for (int i = 0; i < 3; i++)
                        {
                            LOOP0_pdep_epi8(ref mask0, ref mk0, array0, i);
                            LOOP0_pdep_epi8(ref mask1, ref mk1, array1, i);
                        }
                        for (int i = 2; i >= 0; i--)
                        {
                            LOOP1_pdep_epi8(ref a0, array0, i);
                            LOOP1_pdep_epi8(ref a1, array1, i);
                        }

                        r0 = and_si128(a0, m00);
                        r1 = and_si128(a1, m01);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP0_pdep_epi16([NoAlias] ref v128 mask, [NoAlias] ref v128 mk, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi16(mk, mk));
                    mp = xor_si128(mp, slli_epi16(mp, 2));
                    mp = xor_si128(mp, slli_epi16(mp, 4));
                    mp = xor_si128(mp, slli_epi16(mp, 8));
                    v128 mv = and_si128(mp, mask);
                    array[i] = mv;
                    mask = ternarylogic_si128(srli_epi16(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP1_pdep_epi16([NoAlias] ref v128 a, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    a = blendb_si128(a, slli_epi16(a, 1 << i, inRange: true), array[i]);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi16(v128 a, v128 mask, byte elements = 8)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    switch (elements)
                    {
                        case 2:  return                unpacklo_epi16(cvtsi32_si128(Bmi2.pdep_u32(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(Bmi2.pdep_u32(a.UShort1, mask.UShort1)));

                        case 3:  return unpacklo_epi32(unpacklo_epi16(cvtsi32_si128(Bmi2.pdep_u32(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(Bmi2.pdep_u32(a.UShort1, mask.UShort1))),
                                                                      cvtsi32_si128(Bmi2.pdep_u32(a.UShort2, mask.UShort2)));
                        case 4:  return unpacklo_epi32(unpacklo_epi16(cvtsi32_si128(Bmi2.pdep_u32(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(Bmi2.pdep_u32(a.UShort1, mask.UShort1))),
                                                       unpacklo_epi16(cvtsi32_si128(Bmi2.pdep_u32(a.UShort2, mask.UShort2)),
                                                                      cvtsi32_si128(Bmi2.pdep_u32(a.UShort3, mask.UShort3))));
                        default: break;
                    }
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 m0 = mask;
                    v128 mk = add_epi16(not_si128(mask), not_si128(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        v128 a0 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi16(a0, 1), mask, a0, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        v128 a1 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi16(a1, 2), mask, a1, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        v128 a2 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi16(a2, 4), mask, a2, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        v128 a3 = and_si128(mp, mask);

                        a = blendb_si128(a, slli_epi16(a, 8), a3);
                        a = blendb_si128(a, slli_epi16(a, 4), a2);
                        a = blendb_si128(a, slli_epi16(a, 2), a1);
                        a = blendb_si128(a, slli_epi16(a, 1), a0);
                    }
                    else
                    {
                        v128* array = stackalloc v128[4];
                        for (int i = 0; i < 4; i++)
                        {
                            LOOP0_pdep_epi16(ref mask, ref mk, array, i);
                        }
                        for (int i = 3; i >= 0; i--)
                        {
                            LOOP1_pdep_epi16(ref a, array, i);
                        }
                    }

                    return and_si128(a, m0);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi16x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pdep_epi16(a0, mask0);
                        r1 = pdep_epi16(a1, mask1);
                    }
                    else
                    {
                        v128 m00 = mask0;
                        v128 mk0 = add_epi16(not_si128(mask0), not_si128(mask0));
                        v128 m01 = mask1;
                        v128 mk1 = add_epi16(not_si128(mask1), not_si128(mask1));

                        v128* array0 = stackalloc v128[4];
                        v128* array1 = stackalloc v128[4];
                        for (int i = 0; i < 4; i++)
                        {
                            LOOP0_pdep_epi16(ref mask0, ref mk0, array0, i);
                            LOOP0_pdep_epi16(ref mask1, ref mk1, array1, i);
                        }
                        for (int i = 3; i >= 0; i--)
                        {
                            LOOP1_pdep_epi16(ref a0, array0, i);
                            LOOP1_pdep_epi16(ref a1, array1, i);
                        }

                        r0 = and_si128(a0, m00);
                        r1 = and_si128(a1, m01);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP0_pdep_epi32([NoAlias] ref v128 mask, [NoAlias] ref v128 mk, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi32(mk, mk));
                    mp = xor_si128(mp, slli_epi32(mp, 2));
                    mp = xor_si128(mp, slli_epi32(mp, 4));
                    mp = xor_si128(mp, slli_epi32(mp, 8));
                    mp = xor_si128(mp, slli_epi32(mp, 16));
                    v128 mv = and_si128(mp, mask);
                    array[i] = mv;
                    mask = ternarylogic_si128(srli_epi32(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP1_pdep_epi32([NoAlias] ref v128 a, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    a = blendb_si128(a, slli_epi32(a, 1 << i, inRange: true), array[i]);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi32(v128 a, v128 mask, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    switch (elements)
                    {
                        case 2:  return cvtsi64x_si128(Bmi2.pdep_u32(a.UInt0, mask.UInt0) | ((ulong)Bmi2.pdep_u32(a.UInt1, mask.UInt1) << 32));
                        case 3:  return unpacklo_epi64(cvtsi64x_si128(Bmi2.pdep_u32(a.UInt0, mask.UInt0) | ((ulong)Bmi2.pdep_u32(a.UInt1, mask.UInt1) << 32)), cvtsi32_si128(Bmi2.pdep_u32(a.UInt2, mask.UInt2)));
                        default: return unpacklo_epi64(cvtsi64x_si128(Bmi2.pdep_u32(a.UInt0, mask.UInt0) | ((ulong)Bmi2.pdep_u32(a.UInt1, mask.UInt1) << 32)), cvtsi64x_si128(Bmi2.pdep_u32(a.UInt2, mask.UInt2) | ((ulong)Bmi2.pdep_u32(a.UInt3, mask.UInt3) << 32)));
                    }
                }
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 m0 = mask;
                    v128 mk = add_epi32(not_si128(mask), not_si128(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        v128 a0 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(a0, 1), mask, a0, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        v128 a1 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(a1, 2), mask, a1, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        v128 a2 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(a2, 4), mask, a2, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        v128 a3 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(a3, 8), mask, a3, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        v128 a4 = and_si128(mp, mask);

                        a = blendb_si128(a, slli_epi32(a, 16), a4);
                        a = blendb_si128(a, slli_epi32(a, 8),  a3);
                        a = blendb_si128(a, slli_epi32(a, 4),  a2);
                        a = blendb_si128(a, slli_epi32(a, 2),  a1);
                        a = blendb_si128(a, slli_epi32(a, 1),  a0);
                    }
                    else
                    {
                        v128* array = stackalloc v128[5];
                        for (int i = 0; i < 5; i++)
                        {
                            LOOP0_pdep_epi32(ref mask, ref mk, array, i);
                        }
                        for (int i = 4; i >= 0; i--)
                        {
                            LOOP1_pdep_epi32(ref a, array, i);
                        }
                    }

                    return and_si128(a, m0);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi32x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pdep_epi32(a0, mask0);
                        r1 = pdep_epi32(a1, mask1);
                    }
                    else
                    {
                        v128 m00 = mask0;
                        v128 mk0 = add_epi32(not_si128(mask0), not_si128(mask0));
                        v128 m01 = mask1;
                        v128 mk1 = add_epi32(not_si128(mask1), not_si128(mask1));

                        v128* array0 = stackalloc v128[5];
                        v128* array1 = stackalloc v128[5];
                        for (int i = 0; i < 5; i++)
                        {
                            LOOP0_pdep_epi32(ref mask0, ref mk0, array0, i);
                            LOOP0_pdep_epi32(ref mask1, ref mk1, array1, i);
                        }
                        for (int i = 4; i >= 0; i--)
                        {
                            LOOP1_pdep_epi32(ref a0, array0, i);
                            LOOP1_pdep_epi32(ref a1, array1, i);
                        }

                        r0 = and_si128(a0, m00);
                        r1 = and_si128(a1, m01);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP0_pdep_epi64([NoAlias] ref v128 mask, [NoAlias] ref v128 mk, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi64(mk, mk));
                    mp = xor_si128(mp, slli_epi64(mp, 2));
                    mp = xor_si128(mp, slli_epi64(mp, 4));
                    mp = xor_si128(mp, slli_epi64(mp, 8));
                    mp = xor_si128(mp, slli_epi64(mp, 16));
                    mp = xor_si128(mp, slli_epi64(mp, 32));
                    v128 mv = and_si128(mp, mask);
                    array[i] = mv;
                    mask = ternarylogic_si128(srli_epi64(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP1_pdep_epi64([NoAlias] ref v128 a, [NoAlias] v128* array, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    a = blendb_si128(a, slli_epi64(a, 1 << i, inRange: true), array[i]);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi64(v128 a, v128 mask)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    return new v128(Bmi2.pdep_u64(a.ULong0, mask.ULong0), Bmi2.pdep_u64(a.ULong1, mask.ULong1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 m0 = mask;
                    v128 mk = add_epi64(not_si128(mask), not_si128(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        v128 a0 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(a0, 1), mask, a0, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        v128 a1 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(a1, 2), mask, a1, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        v128 a2 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(a2, 4), mask, a2, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        v128 a3 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(a3, 8), mask, a3, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        v128 a4 = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(a4, 16), mask, a4, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        v128 a5 = and_si128(mp, mask);

                        a = blendb_si128(a, slli_epi64(a, 32), a5);
                        a = blendb_si128(a, slli_epi64(a, 16), a4);
                        a = blendb_si128(a, slli_epi64(a, 8),  a3);
                        a = blendb_si128(a, slli_epi64(a, 4),  a2);
                        a = blendb_si128(a, slli_epi64(a, 2),  a1);
                        a = blendb_si128(a, slli_epi64(a, 1),  a0);
                    }
                    else
                    {
                        v128* array = stackalloc v128[6];
                        for (int i = 0; i < 6; i++)
                        {
                            LOOP0_pdep_epi64(ref mask, ref mk, array, i);
                        }
                        for (int i = 5; i >= 0; i--)
                        {
                            LOOP1_pdep_epi64(ref a, array, i);
                        }
                    }

                    return and_si128(a, m0);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi64x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    r0 = new v128(Bmi2.pdep_u64(a0.ULong0, mask0.ULong0), Bmi2.pdep_u64(a0.ULong1, mask0.ULong1));
                    r1 = new v128(Bmi2.pdep_u64(a1.ULong0, mask1.ULong0), Bmi2.pdep_u64(a1.ULong1, mask1.ULong1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pdep_epi64(a0, mask0);
                        r1 = pdep_epi64(a1, mask1);
                    }
                    else
                    {
                        v128 m00 = mask0;
                        v128 mk0 = add_epi64(not_si128(mask0), not_si128(mask0));
                        v128 m01 = mask1;
                        v128 mk1 = add_epi64(not_si128(mask1), not_si128(mask1));

                        v128* array0 = stackalloc v128[6];
                        v128* array1 = stackalloc v128[6];
                        for (int i = 0; i < 6; i++)
                        {
                            LOOP0_pdep_epi64(ref mask0, ref mk0, array0, i);
                            LOOP0_pdep_epi64(ref mask1, ref mk1, array1, i);
                        }
                        for (int i = 5; i >= 0; i--)
                        {
                            LOOP1_pdep_epi64(ref a0, array0, i);
                            LOOP1_pdep_epi64(ref a1, array1, i);
                        }

                        r0 = and_si128(a0, m00);
                        r1 = and_si128(a1, m01);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP0_pdep_epi8([NoAlias] ref v256 mask, [NoAlias] ref v256 mk, [NoAlias] v256* array, int i)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                    mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                    mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                    v256 mv = Avx2.mm256_and_si256(mp, mask);
                    array[i] = mv;
                    mask = mm256_ternarylogic_si256(mm256_srli_epi8(mv, 1 << i), mask, mv, TernaryOperation.OxF6);
                    mk = Avx2.mm256_andnot_si256(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP1_pdep_epi8([NoAlias] ref v256 a, [NoAlias] v256* array, int i)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = mm256_blendb_si256(a, mm256_slli_epi8(a, 1 << i), array[i]);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi8(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 m0 = mask;
                    v256 mk = Avx2.mm256_add_epi8(mm256_not_si256(mask), mm256_not_si256(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        v256 a0 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi8(a0, 1), mask, a0, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        v256 a1 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi8(a1, 2), mask, a1, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        v256 a2 = Avx2.mm256_and_si256(mp, mask);

                        a = mm256_blendb_si256(a, mm256_slli_epi8(a, 4), a2);
                        a = mm256_blendb_si256(a, mm256_slli_epi8(a, 2), a1);
                        a = mm256_blendb_si256(a, mm256_slli_epi8(a, 1), a0);
                    }
                    else
                    {
                        v256* array = stackalloc v256[3];
                        for (int i = 0; i < 3; i++)
                        {
                            LOOP0_pdep_epi8(ref mask, ref mk, array, i);
                        }
                        for (int i = 2; i >= 0; i--)
                        {
                            LOOP1_pdep_epi8(ref a, array, i);
                        }
                    }

                    return Avx2.mm256_and_si256(a, m0);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP0_pdep_epi16([NoAlias] ref v256 mask, [NoAlias] ref v256 mk, [NoAlias] v256* array, int i)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                    mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                    mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                    mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                    v256 mv = Avx2.mm256_and_si256(mp, mask);
                    array[i] = mv;
                    mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 1 << i), mask, mv, TernaryOperation.OxF6);
                    mk = Avx2.mm256_andnot_si256(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP1_pdep_epi16([NoAlias] ref v256 a, [NoAlias] v256* array, int i)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = mm256_blendb_si256(a, mm256_slli_epi16(a, 1 << i), array[i]);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi16(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 m0 = mask;
                    v256 mk = Avx2.mm256_add_epi16(mm256_not_si256(mask), mm256_not_si256(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        v256 a0 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi16(a0, 1), mask, a0, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        v256 a1 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi16(a1, 2), mask, a1, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        v256 a2 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi16(a2, 4), mask, a2, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        v256 a3 = Avx2.mm256_and_si256(mp, mask);

                        a = mm256_blendb_si256(a, mm256_slli_epi16(a, 8), a3);
                        a = mm256_blendb_si256(a, mm256_slli_epi16(a, 4), a2);
                        a = mm256_blendb_si256(a, mm256_slli_epi16(a, 2), a1);
                        a = mm256_blendb_si256(a, mm256_slli_epi16(a, 1), a0);
                    }
                    else
                    {
                        v256* array = stackalloc v256[4];
                        for (int i = 0; i < 4; i++)
                        {
                            LOOP0_pdep_epi16(ref mask, ref mk, array, i);
                        }
                        for (int i = 3; i >= 0; i--)
                        {
                            LOOP1_pdep_epi16(ref a, array, i);
                        }
                    }

                    return Avx2.mm256_and_si256(a, m0);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi32(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(mask))
                    {
                        v256 m0 = mask;
                        v256 mk = Avx2.mm256_add_epi32(mm256_not_si256(mask), mm256_not_si256(mask));

                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        v256 a0 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(a0, 1), mask, a0, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        v256 a1 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(a1, 2), mask, a1, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        v256 a2 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(a2, 4), mask, a2, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        v256 a3 = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(a3, 8), mask, a3, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        v256 a4 = Avx2.mm256_and_si256(mp, mask);

                        a = mm256_blendb_si256(a, mm256_slli_epi32(a, 16), a4);
                        a = mm256_blendb_si256(a, mm256_slli_epi32(a, 8),  a3);
                        a = mm256_blendb_si256(a, mm256_slli_epi32(a, 4),  a2);
                        a = mm256_blendb_si256(a, mm256_slli_epi32(a, 2),  a1);
                        a = mm256_blendb_si256(a, mm256_slli_epi32(a, 1),  a0);

                        return Avx2.mm256_and_si256(a, m0);
                    }
                    else
                    {
                        return new v256(Bmi2.pdep_u32(a.UInt0, mask.UInt0),
                                        Bmi2.pdep_u32(a.UInt1, mask.UInt1),
                                        Bmi2.pdep_u32(a.UInt2, mask.UInt2),
                                        Bmi2.pdep_u32(a.UInt3, mask.UInt3),
                                        Bmi2.pdep_u32(a.UInt4, mask.UInt4),
                                        Bmi2.pdep_u32(a.UInt5, mask.UInt5),
                                        Bmi2.pdep_u32(a.UInt6, mask.UInt6),
                                        Bmi2.pdep_u32(a.UInt7, mask.UInt7));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi64(v256 a, v256 mask, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(new v128(Bmi2.pdep_u64(a.ULong0, mask.ULong0), Bmi2.pdep_u64(a.ULong1, mask.ULong1))),
                                                       elements == 3 ? cvtsi64x_si128(Bmi2.pdep_u64(a.ULong2, mask.ULong2)) : new v128(Bmi2.pdep_u64(a.ULong2, mask.ULong2), Bmi2.pdep_u64(a.ULong3, mask.ULong3)),
                                                       1);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_depositparallel(Int128 x, Int128 mask)
        {
            return (Int128)bits_depositparallel((UInt128)x, (UInt128)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_depositparallel(UInt128 x, UInt128 mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                int maskLoCount = math.countbits(mask.lo64);
                ulong lo = Bmi2.pdep_u64(x.lo64, mask.lo64);
                x >>= maskLoCount;

                ulong hi = Bmi2.pdep_u64(x.lo64, mask.hi64);

                return new UInt128(lo, hi);
            }
            else
            {
                UInt128 m0 = mask;
                UInt128 mk = ~mask + ~mask;

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    UInt128 mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 a0 = mp & mask;
                    mask = (mask ^ a0) | (a0 >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 a1 = mp & mask;
                    mask = (mask ^ a1) | (a1 >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 a2 = mp & mask;
                    mask = (mask ^ a2) | (a2 >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 a3 = mp & mask;
                    mask = (mask ^ a3) | (a3 >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 a4 = mp & mask;
                    mask = (mask ^ a4) | (a4 >> 16);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 a5 = mp & mask;
                    mask = (mask ^ a5) | (a5 >> 32);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 a6 = mp & mask;

                    x = bits_select(x, x << 64, a6);
                    x = bits_select(x, x << 32, a5);
                    x = bits_select(x, x << 16, a4);
                    x = bits_select(x, x << 8,  a3);
                    x = bits_select(x, x << 4,  a2);
                    x = bits_select(x, x << 2,  a1);
                    x = bits_select(x, x << 1,  a0);
                }
                else
                {
                    UInt128* array = stackalloc UInt128[7];
                    for (int i = 0; i < 7; i++)
                    {
                        UInt128 mp = mk ^ (mk + mk);
                        mp ^= mp << 2;
                        mp ^= mp << 4;
                        mp ^= mp << 8;
                        mp ^= mp << 16;
                        mp ^= mp << 32;
                        mp ^= mp << 64;
                        UInt128 mv = mp & mask;
                        array[i] = mv;
                        mask = (mask ^ mv) | (mv >> (1 << i));
                        mk = andnot(mk, mp);
                    }
                    for (int i = 6; i >= 0; i--)
                    {
                        x = bits_select(x, x << (1 << i), array[i]);
                    }
                }

                return x & m0;
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_depositparallel(byte x, byte mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return (byte)Bmi2.pdep_u32(x, mask);
            }
            else
            {
                byte m0 = mask;
                byte mk = (byte)(~mask + ~mask);

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    byte mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    byte a0 = (byte)(mp & mask);
                    mask = (byte)((mask ^ a0) | (a0 >> 1));
                    mk = andnot(mk, mp);

                    mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    byte a1 = (byte)(mp & mask);
                    mask = (byte)((mask ^ a1) | (a1 >> 2));
                    mk = andnot(mk, mp);

                    mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    byte a2 = (byte)(mp & mask);

                    x = bits_select(x, (byte)(x << 4), a2);
                    x = bits_select(x, (byte)(x << 2), a1);
                    x = bits_select(x, (byte)(x << 1), a0);
                }
                else
                {
                    byte* array = stackalloc byte[3];
                    for (int i = 0; i < 3; i++)
                    {
                        byte mp = (byte)(mk ^ (mk + mk));
                        mp ^= (byte)(mp << 2);
                        mp ^= (byte)(mp << 4);
                        byte mv = (byte)(mp & mask);
                        array[i] = mv;
                        mask = (byte)((mask ^ mv) | (mv >> (1 << i)));
                        mk = andnot(mk, mp);
                    }
                    for (int i = 2; i >= 0; i--)
                    {
                        x = bits_select(x, (byte)(x << (1 << i)), array[i]);
                    }
                }

                return (byte)(x & m0);
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_depositparallel(byte2 x, byte2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 2);
            }
            else
            {
                return new byte2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_depositparallel(byte3 x, byte3 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 3);
            }
            else
            {
                return new byte3(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_depositparallel(byte4 x, byte4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 4);
            }
            else
            {
                return new byte4(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z), bits_depositparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_depositparallel(byte8 x, byte8 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 8);
            }
            else
            {
                return new byte8(bits_depositparallel(x.x0, mask.x0), bits_depositparallel(x.x1, mask.x1), bits_depositparallel(x.x2, mask.x2), bits_depositparallel(x.x3, mask.x3), bits_depositparallel(x.x4, mask.x4), bits_depositparallel(x.x5, mask.x5), bits_depositparallel(x.x6, mask.x6), bits_depositparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_depositparallel(byte16 x, byte16 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask);
            }
            else
            {
                return new byte16(bits_depositparallel(x.x0, mask.x0), bits_depositparallel(x.x1, mask.x1), bits_depositparallel(x.x2, mask.x2), bits_depositparallel(x.x3, mask.x3), bits_depositparallel(x.x4, mask.x4), bits_depositparallel(x.x5, mask.x5), bits_depositparallel(x.x6, mask.x6), bits_depositparallel(x.x7, mask.x7), bits_depositparallel(x.x8, mask.x8), bits_depositparallel(x.x9, mask.x9), bits_depositparallel(x.x10, mask.x10), bits_depositparallel(x.x11, mask.x11), bits_depositparallel(x.x12, mask.x12), bits_depositparallel(x.x13, mask.x13), bits_depositparallel(x.x14, mask.x14), bits_depositparallel(x.x15, mask.x15));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_depositparallel(byte32 x, byte32 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi8(x, mask);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pdep_epi8x2(x.v16_0, x.v16_16, mask.v16_0, mask.v16_16, out v128 lo, out v128 hi);

                return new byte32(lo, hi);
            }
            else
            {
                return new byte32(bits_depositparallel(x.v16_0, mask.v16_0), bits_depositparallel(x.v16_16, mask.v16_16));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_depositparallel(sbyte x, sbyte mask)
        {
            return (sbyte)bits_depositparallel((byte)x, (byte)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_depositparallel(sbyte2 x, sbyte2 mask)
        {
            return (sbyte2)bits_depositparallel((byte2)x, (byte2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_depositparallel(sbyte3 x, sbyte3 mask)
        {
            return (sbyte3)bits_depositparallel((byte3)x, (byte3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_depositparallel(sbyte4 x, sbyte4 mask)
        {
            return (sbyte4)bits_depositparallel((byte4)x, (byte4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_depositparallel(sbyte8 x, sbyte8 mask)
        {
            return (sbyte8)bits_depositparallel((byte8)x, (byte8)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_depositparallel(sbyte16 x, sbyte16 mask)
        {
            return (sbyte16)bits_depositparallel((byte16)x, (byte16)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_depositparallel(sbyte32 x, sbyte32 mask)
        {
            return (sbyte32)bits_depositparallel((byte32)x, (byte32)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_depositparallel(ushort x, ushort mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return (ushort)Bmi2.pdep_u32(x, mask);
            }
            else
            {
                ushort m0 = mask;
                ushort mk = (ushort)(~mask + ~mask);

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    ushort mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    ushort a0 = (ushort)(mp & mask);
                    mask = (ushort)((mask ^ a0) | (a0 >> 1));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    ushort a1 = (ushort)(mp & mask);
                    mask = (ushort)((mask ^ a1) | (a1 >> 2));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    ushort a2 = (ushort)(mp & mask);
                    mask = (ushort)((mask ^ a2) | (a2 >> 4));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    ushort a3 = (ushort)(mp & mask);

                    x = bits_select(x, (ushort)(x << 8), a3);
                    x = bits_select(x, (ushort)(x << 4), a2);
                    x = bits_select(x, (ushort)(x << 2), a1);
                    x = bits_select(x, (ushort)(x << 1), a0);
                }
                else
                {
                    ushort* array = stackalloc ushort[4];
                    for (int i = 0; i < 4; i++)
                    {
                        ushort mp = (ushort)(mk ^ (mk + mk));
                        mp ^= (ushort)(mp << 2);
                        mp ^= (ushort)(mp << 4);
                        mp ^= (ushort)(mp << 8);
                        ushort mv = (ushort)(mp & mask);
                        array[i] = mv;
                        mask = (ushort)((mask ^ mv) | (mv >> (1 << i)));
                        mk = andnot(mk, mp);
                    }
                    for (int i = 3; i >= 0; i--)
                    {
                        x = bits_select(x, (ushort)(x << (1 << i)), array[i]);
                    }
                }

                return (ushort)(x & m0);
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_depositparallel(ushort2 x, ushort2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask, 2);
            }
            else
            {
                return new ushort2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_depositparallel(ushort3 x, ushort3 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask, 3);
            }
            else
            {
                return new ushort3(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_depositparallel(ushort4 x, ushort4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask, 4);
            }
            else
            {
                return new ushort4(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z), bits_depositparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_depositparallel(ushort8 x, ushort8 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask);
            }
            else
            {
                return new ushort8(bits_depositparallel(x.x0, mask.x0), bits_depositparallel(x.x1, mask.x1), bits_depositparallel(x.x2, mask.x2), bits_depositparallel(x.x3, mask.x3), bits_depositparallel(x.x4, mask.x4), bits_depositparallel(x.x5, mask.x5), bits_depositparallel(x.x6, mask.x6), bits_depositparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_depositparallel(ushort16 x, ushort16 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi16(x, mask);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pdep_epi16x2(x.v8_0, x.v8_8, mask.v8_0, mask.v8_8, out v128 lo, out v128 hi);

                return new ushort16(lo, hi);
            }
            else
            {
                return new ushort16(bits_depositparallel(x.v8_0, mask.v8_0), bits_depositparallel(x.v8_8, mask.v8_8));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_depositparallel(short x, short mask)
        {
            return (short)bits_depositparallel((ushort)x, (ushort)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_depositparallel(short2 x, short2 mask)
        {
            return (short2)bits_depositparallel((ushort2)x, (ushort2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_depositparallel(short3 x, short3 mask)
        {
            return (short3)bits_depositparallel((ushort3)x, (ushort3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_depositparallel(short4 x, short4 mask)
        {
            return (short4)bits_depositparallel((ushort4)x, (ushort4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_depositparallel(short8 x, short8 mask)
        {
            return (short8)bits_depositparallel((ushort8)x, (ushort8)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_depositparallel(short16 x, short16 mask)
        {
            return (short16)bits_depositparallel((ushort16)x, (ushort16)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_depositparallel(uint x, uint mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u32(x, mask);
            }
            else
            {
                uint m0 = mask;
                uint mk = ~mask + ~mask;

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    uint mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    uint a0 = mp & mask;
                    mask = (mask ^ a0) | (a0 >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    uint a1 = mp & mask;
                    mask = (mask ^ a1) | (a1 >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    uint a2 = mp & mask;
                    mask = (mask ^ a2) | (a2 >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    uint a3 = mp & mask;
                    mask = (mask ^ a3) | (a3 >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    uint a4 = mp & mask;

                    x = bits_select(x, x << 16, a4);
                    x = bits_select(x, x << 8,  a3);
                    x = bits_select(x, x << 4,  a2);
                    x = bits_select(x, x << 2,  a1);
                    x = bits_select(x, x << 1,  a0);
                }
                else
                {
                    uint* array = stackalloc uint[5];
                    for (int i = 0; i < 5; i++)
                    {
                        uint mp = mk ^ (mk + mk);
                        mp ^= mp << 2;
                        mp ^= mp << 4;
                        mp ^= mp << 8;
                        mp ^= mp << 16;
                        uint mv = mp & mask;
                        array[i] = mv;
                        mask = (mask ^ mv) | (mv >> (1 << i));
                        mk = andnot(mk, mp);
                    }
                    for (int i = 4; i >= 0; i--)
                    {
                        x = bits_select(x, x << (1 << i), array[i]);
                    }
                }

                return x & m0;
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_depositparallel(uint2 x, uint2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.pdep_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 2));
            }
            else
            {
                return new uint2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_depositparallel(uint3 x, uint3 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.pdep_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 3));
            }
            else
            {
                return new uint3(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_depositparallel(uint4 x, uint4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.pdep_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 4));
            }
            else
            {
                return new uint4(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z), bits_depositparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_depositparallel(uint8 x, uint8 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi32(x, mask);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pdep_epi32x2(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(mask.v4_0), RegisterConversion.ToV128(mask.v4_4), out v128 lo, out v128 hi);

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                return new uint8(bits_depositparallel(x.v4_0, mask.v4_0), bits_depositparallel(x.v4_4, mask.v4_4));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_depositparallel(int x, int mask)
        {
            return (int)bits_depositparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_depositparallel(int2 x, int2 mask)
        {
            return (int2)bits_depositparallel((uint2)x, (uint2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_depositparallel(int3 x, int3 mask)
        {
            return (int3)bits_depositparallel((uint3)x, (uint3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_depositparallel(int4 x, int4 mask)
        {
            return (int4)bits_depositparallel((uint4)x, (uint4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_depositparallel(int8 x, int8 mask)
        {
            return (int8)bits_depositparallel((uint8)x, (uint8)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_depositparallel(ulong x, ulong mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u64(x, mask);
            }
            else
            {
                ulong m0 = mask;
                ulong mk = ~mask + ~mask;

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    ulong mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    ulong a0 = mp & mask;
                    mask = (mask ^ a0) | (a0 >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    ulong a1 = mp & mask;
                    mask = (mask ^ a1) | (a1 >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    ulong a2 = mp & mask;
                    mask = (mask ^ a2) | (a2 >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    ulong a3 = mp & mask;
                    mask = (mask ^ a3) | (a3 >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    ulong a4 = mp & mask;
                    mask = (mask ^ a4) | (a4 >> 16);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    ulong a5 = mp & mask;

                    x = bits_select(x, x << 32, a5);
                    x = bits_select(x, x << 16, a4);
                    x = bits_select(x, x << 8,  a3);
                    x = bits_select(x, x << 4,  a2);
                    x = bits_select(x, x << 2,  a1);
                    x = bits_select(x, x << 1,  a0);
                }
                else
                {
                    ulong* array = stackalloc ulong[6];
                    for (int i = 0; i < 6; i++)
                    {
                        ulong mp = mk ^ (mk + mk);
                        mp ^= mp << 2;
                        mp ^= mp << 4;
                        mp ^= mp << 8;
                        mp ^= mp << 16;
                        mp ^= mp << 32;
                        ulong mv = mp & mask;
                        array[i] = mv;
                        mask = (mask ^ mv) | (mv >> (1 << i));
                        mk = andnot(mk, mp);
                    }
                    for (int i = 5; i >= 0; i--)
                    {
                        x = bits_select(x, x << (1 << i), array[i]);
                    }
                }

                return x & m0;
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_depositparallel(ulong2 x, ulong2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pdep_epi64(x, mask);
            }
            else
            {
                return new ulong2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_depositparallel(ulong3 x, ulong3 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi64(x, mask, 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pdep_epi64x2(x.xy, x.zz, mask.xy, mask.zz, out v128 lo, out v128 hi);

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                return new ulong3(bits_depositparallel(x.xy, mask.xy), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_depositparallel(ulong4 x, ulong4 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi64(x, mask, 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pdep_epi64x2(x.xy, x.zw, mask.xy, mask.zw, out v128 lo, out v128 hi);

                return new ulong4(lo, hi);
            }
            else
            {
                return new ulong4(bits_depositparallel(x.xy, mask.xy), bits_depositparallel(x.zw, mask.zw));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_depositparallel(long x, long mask)
        {
            return (long)bits_depositparallel((ulong)x, (ulong)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_depositparallel(long2 x, long2 mask)
        {
            return (long2)bits_depositparallel((ulong2)x, (ulong2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_depositparallel(long3 x, long3 mask)
        {
            return (long3)bits_depositparallel((ulong3)x, (ulong3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_depositparallel(long4 x, long4 mask)
        {
            return (long4)bits_depositparallel((ulong4)x, (ulong4)mask);
        }
    }
}