using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // LLVM does not unroll + constant fold (the latter is relevant) if compiling for size
    // The code size is smaller than the loop version if `mask` is constant

    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_pext_epi8([NoAlias] ref v128 a, [NoAlias] ref v128 mask, [NoAlias] ref v128 mk, int i, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi8(mk, mk));
                    mp = xor_si128(mp, slli_epi8(mp, 2));
                    mp = xor_si128(mp, slli_epi8(mp, 4));
                    v128 mv = and_si128(mp, mask);
                    mask = ternarylogic_si128(srli_epi8(mv, 1 << i, inRange: true, elements: elements), mask, mv, TernaryOperation.OxF6);
                    v128 t = and_si128(a, mv);
                    a = ternarylogic_si128(srli_epi8(t, 1 << i, inRange: true, elements: elements), a, t, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pext_epi8(v128 a, v128 mask, byte elements = 16)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    switch (elements)
                    {
                        case 2:  return                unpacklo_epi8(cvtsi32_si128(math.bits_extractparallel(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(math.bits_extractparallel(a.Byte1, mask.Byte1)));

                        case 3:  return unpacklo_epi16(unpacklo_epi8(cvtsi32_si128(math.bits_extractparallel(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(math.bits_extractparallel(a.Byte1, mask.Byte1))),
                                                                     cvtsi32_si128(math.bits_extractparallel(a.Byte2, mask.Byte2)));
                        case 4:  return unpacklo_epi16(unpacklo_epi8(cvtsi32_si128(math.bits_extractparallel(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(math.bits_extractparallel(a.Byte1, mask.Byte1))),
                                                       unpacklo_epi8(cvtsi32_si128(math.bits_extractparallel(a.Byte2, mask.Byte2)),
                                                                     cvtsi32_si128(math.bits_extractparallel(a.Byte3, mask.Byte3))));
                        default: break;
                    }
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result = a;
                    v128 __mask = mask;

                    result = and_si128(result, __mask);
                    v128 mk = add_epi8(not_si128(__mask), not_si128(__mask));

                    if (constexpr.IS_CONST(__mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        v128 mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi8(mv, 1, inRange: true, elements: elements), __mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi8(t, 1, inRange: true, elements: elements), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi8(mv, 2, inRange: true, elements: elements), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi8(t, 2, inRange: true, elements: elements), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        mv = and_si128(mp, __mask);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi8(t, 4, inRange: true, elements: elements), result, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            LOOP_pext_epi8(ref result, ref __mask, ref mk, i, elements);
                        }
                    }

                    Assume.bits_extractparallel(result.Byte0,  a.Byte0,  mask.Byte0);
                    Assume.bits_extractparallel(result.Byte1,  a.Byte1,  mask.Byte1);
                    Assume.bits_extractparallel(result.Byte2,  a.Byte2,  mask.Byte2);
                    Assume.bits_extractparallel(result.Byte3,  a.Byte3,  mask.Byte3);
                    Assume.bits_extractparallel(result.Byte4,  a.Byte4,  mask.Byte4);
                    Assume.bits_extractparallel(result.Byte5,  a.Byte5,  mask.Byte5);
                    Assume.bits_extractparallel(result.Byte6,  a.Byte6,  mask.Byte6);
                    Assume.bits_extractparallel(result.Byte7,  a.Byte7,  mask.Byte7);
                    Assume.bits_extractparallel(result.Byte8,  a.Byte8,  mask.Byte8);
                    Assume.bits_extractparallel(result.Byte9,  a.Byte9,  mask.Byte9);
                    Assume.bits_extractparallel(result.Byte10, a.Byte10, mask.Byte10);
                    Assume.bits_extractparallel(result.Byte11, a.Byte11, mask.Byte11);
                    Assume.bits_extractparallel(result.Byte12, a.Byte12, mask.Byte12);
                    Assume.bits_extractparallel(result.Byte13, a.Byte13, mask.Byte13);
                    Assume.bits_extractparallel(result.Byte14, a.Byte14, mask.Byte14);
                    Assume.bits_extractparallel(result.Byte15, a.Byte15, mask.Byte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pext_epi8x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pext_epi8(a0, mask0);
                        r1 = pext_epi8(a1, mask1);
                    }
                    else
                    {
                        v128 __mask0 = mask0;
                        v128 __mask1 = mask1;
                        v128 __a0 = and_si128(a0, mask0);
                        v128 mk0 = add_epi8(not_si128(__mask0), not_si128(__mask0));
                        v128 __a1 = and_si128(a1, mask1);
                        v128 mk1 = add_epi8(not_si128(__mask1), not_si128(__mask1));

                        for (int i = 0; i < 3; i++)
                        {
                            LOOP_pext_epi8(ref __a0, ref __mask0, ref mk0, i, 16);
                            LOOP_pext_epi8(ref __a1, ref __mask1, ref mk1, i, 16);
                        }

                        r0 = __a0;
                        r1 = __a1;
                    }

                    Assume.bits_extractparallel(r0.Byte0,  a0.Byte0,  mask0.Byte0);
                    Assume.bits_extractparallel(r0.Byte1,  a0.Byte1,  mask0.Byte1);
                    Assume.bits_extractparallel(r0.Byte2,  a0.Byte2,  mask0.Byte2);
                    Assume.bits_extractparallel(r0.Byte3,  a0.Byte3,  mask0.Byte3);
                    Assume.bits_extractparallel(r0.Byte4,  a0.Byte4,  mask0.Byte4);
                    Assume.bits_extractparallel(r0.Byte5,  a0.Byte5,  mask0.Byte5);
                    Assume.bits_extractparallel(r0.Byte6,  a0.Byte6,  mask0.Byte6);
                    Assume.bits_extractparallel(r0.Byte7,  a0.Byte7,  mask0.Byte7);
                    Assume.bits_extractparallel(r0.Byte8,  a0.Byte8,  mask0.Byte8);
                    Assume.bits_extractparallel(r0.Byte9,  a0.Byte9,  mask0.Byte9);
                    Assume.bits_extractparallel(r0.Byte10, a0.Byte10, mask0.Byte10);
                    Assume.bits_extractparallel(r0.Byte11, a0.Byte11, mask0.Byte11);
                    Assume.bits_extractparallel(r0.Byte12, a0.Byte12, mask0.Byte12);
                    Assume.bits_extractparallel(r0.Byte13, a0.Byte13, mask0.Byte13);
                    Assume.bits_extractparallel(r0.Byte14, a0.Byte14, mask0.Byte14);
                    Assume.bits_extractparallel(r0.Byte15, a0.Byte15, mask0.Byte15);

                    Assume.bits_extractparallel(r1.Byte0,  a1.Byte0,  mask1.Byte0);
                    Assume.bits_extractparallel(r1.Byte1,  a1.Byte1,  mask1.Byte1);
                    Assume.bits_extractparallel(r1.Byte2,  a1.Byte2,  mask1.Byte2);
                    Assume.bits_extractparallel(r1.Byte3,  a1.Byte3,  mask1.Byte3);
                    Assume.bits_extractparallel(r1.Byte4,  a1.Byte4,  mask1.Byte4);
                    Assume.bits_extractparallel(r1.Byte5,  a1.Byte5,  mask1.Byte5);
                    Assume.bits_extractparallel(r1.Byte6,  a1.Byte6,  mask1.Byte6);
                    Assume.bits_extractparallel(r1.Byte7,  a1.Byte7,  mask1.Byte7);
                    Assume.bits_extractparallel(r1.Byte8,  a1.Byte8,  mask1.Byte8);
                    Assume.bits_extractparallel(r1.Byte9,  a1.Byte9,  mask1.Byte9);
                    Assume.bits_extractparallel(r1.Byte10, a1.Byte10, mask1.Byte10);
                    Assume.bits_extractparallel(r1.Byte11, a1.Byte11, mask1.Byte11);
                    Assume.bits_extractparallel(r1.Byte12, a1.Byte12, mask1.Byte12);
                    Assume.bits_extractparallel(r1.Byte13, a1.Byte13, mask1.Byte13);
                    Assume.bits_extractparallel(r1.Byte14, a1.Byte14, mask1.Byte14);
                    Assume.bits_extractparallel(r1.Byte15, a1.Byte15, mask1.Byte15);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_pext_epi16([NoAlias] ref v128 a, [NoAlias] ref v128 mask, [NoAlias] ref v128 mk, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi16(mk, mk));
                    mp = xor_si128(mp, slli_epi16(mp, 2));
                    mp = xor_si128(mp, slli_epi16(mp, 4));
                    mp = xor_si128(mp, slli_epi16(mp, 8));
                    v128 mv = and_si128(mp, mask);
                    mask = ternarylogic_si128(srli_epi16(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    v128 t = and_si128(a, mv);
                    a = ternarylogic_si128(srli_epi16(t, 1 << i, inRange: true), a, t, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pext_epi16(v128 a, v128 mask, byte elements = 8)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    switch (elements)
                    {
                        case 2:  return                unpacklo_epi16(cvtsi32_si128(math.bits_extractparallel(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(math.bits_extractparallel(a.UShort1, mask.UShort1)));

                        case 3:  return unpacklo_epi32(unpacklo_epi16(cvtsi32_si128(math.bits_extractparallel(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(math.bits_extractparallel(a.UShort1, mask.UShort1))),
                                                                      cvtsi32_si128(math.bits_extractparallel(a.UShort2, mask.UShort2)));
                        case 4:  return unpacklo_epi32(unpacklo_epi16(cvtsi32_si128(math.bits_extractparallel(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(math.bits_extractparallel(a.UShort1, mask.UShort1))),
                                                       unpacklo_epi16(cvtsi32_si128(math.bits_extractparallel(a.UShort2, mask.UShort2)),
                                                                      cvtsi32_si128(math.bits_extractparallel(a.UShort3, mask.UShort3))));
                        default: break;
                    }
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 __mask = mask;
                    v128 result = and_si128(a, __mask);
                    v128 mk = add_epi16(not_si128(__mask), not_si128(__mask));

                    if (constexpr.IS_CONST(__mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        v128 mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi16(mv, 1, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi16(t, 1, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi16(mv, 2, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi16(t, 2, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi16(mv, 4, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi16(t, 4, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        mv = and_si128(mp, __mask);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi16(t, 8, inRange: true), result, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            LOOP_pext_epi16(ref result, ref __mask, ref mk, i);
                        }
                    }
                    
                    Assume.bits_extractparallel(result.UShort0, a.UShort0, mask.UShort0);
                    Assume.bits_extractparallel(result.UShort1, a.UShort1, mask.UShort1);
                    Assume.bits_extractparallel(result.UShort2, a.UShort2, mask.UShort2);
                    Assume.bits_extractparallel(result.UShort3, a.UShort3, mask.UShort3);
                    Assume.bits_extractparallel(result.UShort4, a.UShort4, mask.UShort4);
                    Assume.bits_extractparallel(result.UShort5, a.UShort5, mask.UShort5);
                    Assume.bits_extractparallel(result.UShort6, a.UShort6, mask.UShort6);
                    Assume.bits_extractparallel(result.UShort7, a.UShort7, mask.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pext_epi16x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pext_epi16(a0, mask0);
                        r1 = pext_epi16(a1, mask1);
                    }
                    else
                    {
                        v128 __mask0 = mask0;
                        v128 __mask1 = mask1;
                        v128 __a0 = and_si128(a0, __mask0);
                        v128 mk0 = add_epi16(not_si128(__mask0), not_si128(__mask0));
                        v128 __a1 = and_si128(a1, __mask1);
                        v128 mk1 = add_epi16(not_si128(__mask1), not_si128(__mask1));

                        for (int i = 0; i < 4; i++)
                        {
                            LOOP_pext_epi16(ref __a0, ref __mask0, ref mk0, i);
                            LOOP_pext_epi16(ref __a1, ref __mask1, ref mk1, i);
                        }

                        r0 = __a0;
                        r1 = __a1;
                    }
                    
                    Assume.bits_extractparallel(r0.UShort0, a0.UShort0, mask0.UShort0);
                    Assume.bits_extractparallel(r0.UShort1, a0.UShort1, mask0.UShort1);
                    Assume.bits_extractparallel(r0.UShort2, a0.UShort2, mask0.UShort2);
                    Assume.bits_extractparallel(r0.UShort3, a0.UShort3, mask0.UShort3);
                    Assume.bits_extractparallel(r0.UShort4, a0.UShort4, mask0.UShort4);
                    Assume.bits_extractparallel(r0.UShort5, a0.UShort5, mask0.UShort5);
                    Assume.bits_extractparallel(r0.UShort6, a0.UShort6, mask0.UShort6);
                    Assume.bits_extractparallel(r0.UShort7, a0.UShort7, mask0.UShort7);
                    
                    Assume.bits_extractparallel(r1.UShort0, a1.UShort0, mask1.UShort0);
                    Assume.bits_extractparallel(r1.UShort1, a1.UShort1, mask1.UShort1);
                    Assume.bits_extractparallel(r1.UShort2, a1.UShort2, mask1.UShort2);
                    Assume.bits_extractparallel(r1.UShort3, a1.UShort3, mask1.UShort3);
                    Assume.bits_extractparallel(r1.UShort4, a1.UShort4, mask1.UShort4);
                    Assume.bits_extractparallel(r1.UShort5, a1.UShort5, mask1.UShort5);
                    Assume.bits_extractparallel(r1.UShort6, a1.UShort6, mask1.UShort6);
                    Assume.bits_extractparallel(r1.UShort7, a1.UShort7, mask1.UShort7);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_pext_epi32([NoAlias] ref v128 a, [NoAlias] ref v128 mask, [NoAlias] ref v128 mk, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi32(mk, mk));
                    mp = xor_si128(mp, slli_epi32(mp, 2));
                    mp = xor_si128(mp, slli_epi32(mp, 4));
                    mp = xor_si128(mp, slli_epi32(mp, 8));
                    mp = xor_si128(mp, slli_epi32(mp, 16));
                    v128 mv = and_si128(mp, mask);
                    mask = ternarylogic_si128(srli_epi32(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    v128 t = and_si128(a, mv);
                    a = ternarylogic_si128(srli_epi32(t, 1 << i, inRange: true), a, t, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pext_epi32(v128 a, v128 mask, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    switch (elements)
                    {
                        case 2:  return cvtsi64x_si128(math.bits_extractparallel(a.UInt0, mask.UInt0) | ((ulong)math.bits_extractparallel(a.UInt1, mask.UInt1) << 32));
                        case 3:  return unpacklo_epi64(cvtsi64x_si128(math.bits_extractparallel(a.UInt0, mask.UInt0) | ((ulong)math.bits_extractparallel(a.UInt1, mask.UInt1) << 32)), cvtsi32_si128(math.bits_extractparallel(a.UInt2, mask.UInt2)));
                        default: return unpacklo_epi64(cvtsi64x_si128(math.bits_extractparallel(a.UInt0, mask.UInt0) | ((ulong)math.bits_extractparallel(a.UInt1, mask.UInt1) << 32)), cvtsi64x_si128(math.bits_extractparallel(a.UInt2, mask.UInt2) | ((ulong)math.bits_extractparallel(a.UInt3, mask.UInt3) << 32)));
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 __mask = mask;
                    v128 result = and_si128(a, __mask);
                    v128 mk = add_epi32(not_si128(__mask), not_si128(__mask));

                    if (constexpr.IS_CONST(__mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        v128 mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi32(mv, 1, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi32(t, 1, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi32(mv, 2, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi32(t, 2, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi32(mv, 4, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi32(t, 4, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi32(mv, 8, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi32(t, 8, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, __mask);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi32(t, 16, inRange: true), result, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            LOOP_pext_epi32(ref result, ref __mask, ref mk, i);
                        }
                    }
                    
                    Assume.bits_extractparallel(result.UInt0, a.UInt0, mask.UInt0);
                    Assume.bits_extractparallel(result.UInt1, a.UInt1, mask.UInt1);
                    Assume.bits_extractparallel(result.UInt2, a.UInt2, mask.UInt2);
                    Assume.bits_extractparallel(result.UInt3, a.UInt3, mask.UInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pext_epi32x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pext_epi32(a0, mask0);
                        r1 = pext_epi32(a1, mask1);
                    }
                    else
                    {
                        v128 __mask0 = mask0;
                        v128 __mask1 = mask1;
                        v128 __a0 = and_si128(a0, __mask0);
                        v128 mk0 = add_epi32(not_si128(__mask0), not_si128(__mask0));
                        v128 __a1 = and_si128(a1, __mask1);
                        v128 mk1 = add_epi32(not_si128(__mask1), not_si128(__mask1));

                        for (int i = 0; i < 5; i++)
                        {
                            LOOP_pext_epi32(ref __a0, ref __mask0, ref mk0, i);
                            LOOP_pext_epi32(ref __a1, ref __mask1, ref mk1, i);
                        }

                        r0 = __a0;
                        r1 = __a1;
                    }

                    Assume.bits_extractparallel(r0.UInt0, a0.UInt0, mask0.UInt0);
                    Assume.bits_extractparallel(r0.UInt1, a0.UInt1, mask0.UInt1);
                    Assume.bits_extractparallel(r0.UInt2, a0.UInt2, mask0.UInt2);
                    Assume.bits_extractparallel(r0.UInt3, a0.UInt3, mask0.UInt3);
                    
                    Assume.bits_extractparallel(r1.UInt0, a1.UInt0, mask1.UInt0);
                    Assume.bits_extractparallel(r1.UInt1, a1.UInt1, mask1.UInt1);
                    Assume.bits_extractparallel(r1.UInt2, a1.UInt2, mask1.UInt2);
                    Assume.bits_extractparallel(r1.UInt3, a1.UInt3, mask1.UInt3);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_pext_epi64([NoAlias] ref v128 a, [NoAlias] ref v128 mask, [NoAlias] ref v128 mk, int i)
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
                    mask = ternarylogic_si128(srli_epi64(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    v128 t = and_si128(a, mv);
                    a = ternarylogic_si128(srli_epi64(t, 1 << i, inRange: true), a, t, TernaryOperation.OxF6);
                    mk = andnot_si128(mp, mk);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pext_epi64(v128 a, v128 mask)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    return new v128(math.bits_extractparallel(a.ULong0, mask.ULong0), math.bits_extractparallel(a.ULong1, mask.ULong1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 __mask = mask;
                    v128 result = and_si128(a, __mask);
                    v128 mk = add_epi64(not_si128(__mask), not_si128(__mask));

                    if (constexpr.IS_CONST(__mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        v128 mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi64(mv, 1, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi64(t, 1, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi64(mv, 2, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi64(t, 2, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi64(mv, 4, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi64(t, 4, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi64(mv, 8, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi64(t, 8, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, __mask);
                        __mask = ternarylogic_si128(srli_epi64(mv, 16, inRange: true), __mask, mv, TernaryOperation.OxF6);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi64(t, 16, inRange: true), result, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, __mask);
                        t = and_si128(result, mv);
                        result = ternarylogic_si128(srli_epi64(t, 32, inRange: true), result, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            LOOP_pext_epi64(ref result, ref __mask, ref mk, i);
                        }
                    }

                    Assume.bits_extractparallel(result.ULong0, a.ULong0, mask.ULong0);
                    Assume.bits_extractparallel(result.ULong1, a.ULong1, mask.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pext_epi64x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(mask0)
                     || constexpr.IS_CONST(mask1)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        r0 = pext_epi64(a0, mask0);
                        r1 = pext_epi64(a1, mask1);
                    }
                    else
                    {
                        v128 __mask0 = mask0;
                        v128 __mask1 = mask1;
                        v128 __a0 = and_si128(a0, __mask0);
                        v128 mk0 = add_epi64(not_si128(__mask0), not_si128(__mask0));
                        v128 __a1 = and_si128(a1, __mask1);
                        v128 mk1 = add_epi64(not_si128(__mask1), not_si128(__mask1));

                        for (int i = 0; i < 6; i++)
                        {
                            LOOP_pext_epi64(ref __a0, ref __mask0, ref mk0, i);
                            LOOP_pext_epi64(ref __a1, ref __mask1, ref mk1, i);
                        }

                        r0 = __a0;
                        r1 = __a1;
                    }

                    Assume.bits_extractparallel(r0.ULong0, a0.ULong0, mask0.ULong0);
                    Assume.bits_extractparallel(r0.ULong1, a0.ULong1, mask0.ULong1);

                    Assume.bits_extractparallel(r1.ULong0, a1.ULong0, mask1.ULong0);
                    Assume.bits_extractparallel(r1.ULong1, a1.ULong1, mask1.ULong1);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi8(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __mask = mask;
                    v256 result = Avx2.mm256_and_si256(a, mask);
                    v256 mk = Avx2.mm256_add_epi8(mm256_not_si256(__mask), mm256_not_si256(__mask));

                    if (constexpr.IS_CONST(__mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        v256 mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi8(mv, 1), __mask, mv, TernaryOperation.OxF6);
                        v256 t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi8(t, 1), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi8(mv, 2), __mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi8(t, 2), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi8(t, 4), result, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                            v256 mv = Avx2.mm256_and_si256(mp, __mask);
                            __mask = mm256_ternarylogic_si256(mm256_srli_epi8(mv, 1 << i), __mask, mv, TernaryOperation.OxF6);
                            v256 t = Avx2.mm256_and_si256(result, mv);
                            result = mm256_ternarylogic_si256(mm256_srli_epi8(t, 1 << i), result, t, TernaryOperation.OxF6);
                            mk = Avx2.mm256_andnot_si256(mp, mk);
                        }
                    }

                    Assume.bits_extractparallel(result.Byte0,  a.Byte0,  mask.Byte0);
                    Assume.bits_extractparallel(result.Byte1,  a.Byte1,  mask.Byte1);
                    Assume.bits_extractparallel(result.Byte2,  a.Byte2,  mask.Byte2);
                    Assume.bits_extractparallel(result.Byte3,  a.Byte3,  mask.Byte3);
                    Assume.bits_extractparallel(result.Byte4,  a.Byte4,  mask.Byte4);
                    Assume.bits_extractparallel(result.Byte5,  a.Byte5,  mask.Byte5);
                    Assume.bits_extractparallel(result.Byte6,  a.Byte6,  mask.Byte6);
                    Assume.bits_extractparallel(result.Byte7,  a.Byte7,  mask.Byte7);
                    Assume.bits_extractparallel(result.Byte8,  a.Byte8,  mask.Byte8);
                    Assume.bits_extractparallel(result.Byte9,  a.Byte9,  mask.Byte9);
                    Assume.bits_extractparallel(result.Byte10, a.Byte10, mask.Byte10);
                    Assume.bits_extractparallel(result.Byte11, a.Byte11, mask.Byte11);
                    Assume.bits_extractparallel(result.Byte12, a.Byte12, mask.Byte12);
                    Assume.bits_extractparallel(result.Byte13, a.Byte13, mask.Byte13);
                    Assume.bits_extractparallel(result.Byte14, a.Byte14, mask.Byte14);
                    Assume.bits_extractparallel(result.Byte15, a.Byte15, mask.Byte15);
                    Assume.bits_extractparallel(result.Byte16, a.Byte16, mask.Byte16);
                    Assume.bits_extractparallel(result.Byte17, a.Byte17, mask.Byte17);
                    Assume.bits_extractparallel(result.Byte18, a.Byte18, mask.Byte18);
                    Assume.bits_extractparallel(result.Byte19, a.Byte19, mask.Byte19);
                    Assume.bits_extractparallel(result.Byte20, a.Byte20, mask.Byte20);
                    Assume.bits_extractparallel(result.Byte21, a.Byte21, mask.Byte21);
                    Assume.bits_extractparallel(result.Byte22, a.Byte22, mask.Byte22);
                    Assume.bits_extractparallel(result.Byte23, a.Byte23, mask.Byte23);
                    Assume.bits_extractparallel(result.Byte24, a.Byte24, mask.Byte24);
                    Assume.bits_extractparallel(result.Byte25, a.Byte25, mask.Byte25);
                    Assume.bits_extractparallel(result.Byte26, a.Byte26, mask.Byte26);
                    Assume.bits_extractparallel(result.Byte27, a.Byte27, mask.Byte27);
                    Assume.bits_extractparallel(result.Byte28, a.Byte28, mask.Byte28);
                    Assume.bits_extractparallel(result.Byte29, a.Byte29, mask.Byte29);
                    Assume.bits_extractparallel(result.Byte30, a.Byte30, mask.Byte30);
                    Assume.bits_extractparallel(result.Byte31, a.Byte31, mask.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi16(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 __mask = mask;
                    v256 result = Avx2.mm256_and_si256(a, mask);
                    v256 mk = Avx2.mm256_add_epi16(mm256_not_si256(__mask), mm256_not_si256(__mask));

                    if (constexpr.IS_CONST(__mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        v256 mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 1), __mask, mv, TernaryOperation.OxF6);
                        v256 t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi16(t, 1), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 2), __mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi16(t, 2), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 4), __mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi16(t, 4), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi16(t, 8), result, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                            v256 mv = Avx2.mm256_and_si256(mp, __mask);
                            __mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 1 << i), __mask, mv, TernaryOperation.OxF6);
                            v256 t = Avx2.mm256_and_si256(result, mv);
                            result = mm256_ternarylogic_si256(mm256_srli_epi16(t, 1 << i), result, t, TernaryOperation.OxF6);
                            mk = Avx2.mm256_andnot_si256(mp, mk);
                        }
                    }

                    Assume.bits_extractparallel(result.UShort0,  a.UShort0,  mask.UShort0);
                    Assume.bits_extractparallel(result.UShort1,  a.UShort1,  mask.UShort1);
                    Assume.bits_extractparallel(result.UShort2,  a.UShort2,  mask.UShort2);
                    Assume.bits_extractparallel(result.UShort3,  a.UShort3,  mask.UShort3);
                    Assume.bits_extractparallel(result.UShort4,  a.UShort4,  mask.UShort4);
                    Assume.bits_extractparallel(result.UShort5,  a.UShort5,  mask.UShort5);
                    Assume.bits_extractparallel(result.UShort6,  a.UShort6,  mask.UShort6);
                    Assume.bits_extractparallel(result.UShort7,  a.UShort7,  mask.UShort7);
                    Assume.bits_extractparallel(result.UShort8,  a.UShort8,  mask.UShort8);
                    Assume.bits_extractparallel(result.UShort9,  a.UShort9,  mask.UShort9);
                    Assume.bits_extractparallel(result.UShort10, a.UShort10, mask.UShort10);
                    Assume.bits_extractparallel(result.UShort11, a.UShort11, mask.UShort11);
                    Assume.bits_extractparallel(result.UShort12, a.UShort12, mask.UShort12);
                    Assume.bits_extractparallel(result.UShort13, a.UShort13, mask.UShort13);
                    Assume.bits_extractparallel(result.UShort14, a.UShort14, mask.UShort14);
                    Assume.bits_extractparallel(result.UShort15, a.UShort15, mask.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi32(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(mask))
                    {
                        v256 __mask = mask;
                        v256 result = Avx2.mm256_and_si256(a, mask);
                        v256 mk = Avx2.mm256_add_epi32(mm256_not_si256(__mask), mm256_not_si256(__mask));

                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        v256 mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 1), __mask, mv, TernaryOperation.OxF6);
                        v256 t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi32(t, 1), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 2), __mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi32(t, 2), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 4), __mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi32(t, 4), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        __mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 8), __mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi32(t, 8), result, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, __mask);
                        t = Avx2.mm256_and_si256(result, mv);
                        result = mm256_ternarylogic_si256(mm256_srli_epi32(t, 16), result, t, TernaryOperation.OxF6);

                        Assume.bits_extractparallel(result.UInt0, a.UInt0, mask.UInt0);
                        Assume.bits_extractparallel(result.UInt1, a.UInt1, mask.UInt1);
                        Assume.bits_extractparallel(result.UInt2, a.UInt2, mask.UInt2);
                        Assume.bits_extractparallel(result.UInt3, a.UInt3, mask.UInt3);
                        Assume.bits_extractparallel(result.UInt4, a.UInt4, mask.UInt4);
                        Assume.bits_extractparallel(result.UInt5, a.UInt5, mask.UInt5);
                        Assume.bits_extractparallel(result.UInt6, a.UInt6, mask.UInt6);
                        Assume.bits_extractparallel(result.UInt7, a.UInt7, mask.UInt7);

                        return result;
                    }
                    else
                    {
                        return new v256(math.bits_extractparallel(a.UInt0, mask.UInt0),
                                        math.bits_extractparallel(a.UInt1, mask.UInt1),
                                        math.bits_extractparallel(a.UInt2, mask.UInt2),
                                        math.bits_extractparallel(a.UInt3, mask.UInt3),
                                        math.bits_extractparallel(a.UInt4, mask.UInt4),
                                        math.bits_extractparallel(a.UInt5, mask.UInt5),
                                        math.bits_extractparallel(a.UInt6, mask.UInt6),
                                        math.bits_extractparallel(a.UInt7, mask.UInt7));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi64(v256 a, v256 mask, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(new v128(math.bits_extractparallel(a.ULong0, mask.ULong0), math.bits_extractparallel(a.ULong1, mask.ULong1))),
                                                       elements == 3 ? cvtsi64x_si128(math.bits_extractparallel(a.ULong2, mask.ULong2)) : new v128(math.bits_extractparallel(a.ULong2, mask.ULong2), math.bits_extractparallel(a.ULong3, mask.ULong3)),
                                                       1);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_extractparallel(byte result, byte x, byte mask)
        {
            if (constexpr.IS_TRUE(mask != byte.MaxValue))
            {
                int k = math.countbits(mask);

                constexpr.ASSUME((result & (byte)(byte.MaxValue << k)) == 0);
            }
            else if (constexpr.IS_TRUE(mask == byte.MaxValue))
            {
                constexpr.ASSUME(result == x);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_extractparallel(ushort result, ushort x, ushort mask)
        {
            if (constexpr.IS_TRUE(mask != ushort.MaxValue))
            {
                int k = math.countbits(mask);

                constexpr.ASSUME((result & (ushort)(ushort.MaxValue << k)) == 0);
            }
            else if (constexpr.IS_TRUE(mask == ushort.MaxValue))
            {
                constexpr.ASSUME(result == x);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_extractparallel(uint result, uint x, uint mask)
        {
            if (constexpr.IS_TRUE(mask != uint.MaxValue))
            {
                int k = math.countbits(mask);

                constexpr.ASSUME((result & (uint.MaxValue << k)) == 0);
            }
            else if (constexpr.IS_TRUE(mask == uint.MaxValue))
            {
                constexpr.ASSUME(result == x);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_extractparallel(ulong result, ulong x, ulong mask)
        {
            if (constexpr.IS_TRUE(mask != ulong.MaxValue))
            {
                int k = math.countbits(mask);

                constexpr.ASSUME((result & (ulong.MaxValue << k)) == 0);
            }
            else if (constexpr.IS_TRUE(mask == ulong.MaxValue))
            {
                constexpr.ASSUME(result == x);
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extractparallel(Int128 x, Int128 mask)
        {
            return (Int128)bits_extractparallel((UInt128)x, (UInt128)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extractparallel(UInt128 x, UInt128 mask)
        {
            UInt128 result = x;

            if (Bmi2.IsBmi2Supported)
            {
                ulong lo = Bmi2.pext_u64(x.lo64, mask.lo64);
                ulong hi = Bmi2.pext_u64(x.hi64, mask.hi64);
                int maskloCount = countbits(mask.lo64);

                result = lo | ((UInt128)hi << maskloCount);
            }
            else
            {
                UInt128 __mask = mask;

                result &= __mask;
                UInt128 mk = ~__mask + ~__mask;

                if (constexpr.IS_CONST(__mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    UInt128 mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    UInt128 mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 1);
                    UInt128 t = result & mv;
                    result = result ^ t | (t >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 2);
                    t = result & mv;
                    result = result ^ t | (t >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 4);
                    t = result & mv;
                    result = result ^ t | (t >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 8);
                    t = result & mv;
                    result = result ^ t | (t >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 16);
                    t = result & mv;
                    result = result ^ t | (t >> 16);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 32);
                    t = result & mv;
                    result = result ^ t | (t >> 32);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & __mask;
                    t = result & mv;
                    result = result ^ t | (t >> 64);
                }
                else
                {
                    for (int i = 1; i <= 64; i += i)
                    {
                        UInt128 mp = mk ^ (mk + mk);
                        mp ^= mp << 2;
                        mp ^= mp << 4;
                        mp ^= mp << 8;
                        mp ^= mp << 16;
                        mp ^= mp << 32;
                        mp ^= mp << 64;
                        UInt128 mv = mp & __mask;
                        __mask = __mask ^ mv | (mv >> i);
                        UInt128 t = result & mv;
                        result = result ^ t | (t >> i);
                        mk = andnot(mk, mp);
                    }
                }
            }
                
            if (constexpr.IS_TRUE(mask != UInt128.MaxValue))
            {
                int k = math.countbits(mask);
            
                constexpr.ASSUME((result & (UInt128.MaxValue << k)) == 0);
            }
            else if (constexpr.IS_TRUE(mask == UInt128.MaxValue))
            {
                constexpr.ASSUME(result == x);
            }
            
            return result;
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extractparallel(byte x, byte mask)
        {
            byte result = x;

            if (Bmi2.IsBmi2Supported)
            {
                result = (byte)Bmi2.pext_u32(x, mask);
            }
            else
            {
                byte __mask = mask;

                result &= __mask;
                byte mk = (byte)(~__mask + ~__mask);

                if (constexpr.IS_CONST(__mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    byte mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    byte mv = (byte)(mp & __mask);
                    __mask = (byte)(__mask ^ mv | (mv >> 1));
                    byte t = (byte)(result & mv);
                    result = (byte)(result ^ t | (t >> 1));
                    mk = andnot(mk, mp);

                    mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    mv = (byte)(mp & __mask);
                    __mask = (byte)(__mask ^ mv | (mv >> 2));
                    t = (byte)(result & mv);
                    result = (byte)(result ^ t | (t >> 2));
                    mk = andnot(mk, mp);

                    mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    mv = (byte)(mp & __mask);
                    t = (byte)(result & mv);
                    result = (byte)(result ^ t | (t >> 4));
                }
                else
                {
                    for (int i = 1; i <= 4; i += i)
                    {
                        byte mp = (byte)(mk ^ (mk + mk));
                        mp ^= (byte)(mp << 2);
                        mp ^= (byte)(mp << 4);
                        byte mv = (byte)(mp & __mask);
                        __mask = (byte)(__mask ^ mv | (mv >> i));
                        byte t = (byte)(result & mv);
                        result = (byte)(result ^ t | (t >> i));
                        mk = andnot(mk, mp);
                    }
                }
            }

            Assume.bits_extractparallel(result, x, mask);

            return result;
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extractparallel(byte2 x, byte2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi8(x, mask, 2);
            }
            else
            {
                return new byte2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_extractparallel(byte3 x, byte3 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi8(x, mask, 3);
            }
            else
            {
                return new byte3(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_extractparallel(byte4 x, byte4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi8(x, mask, 4);
            }
            else
            {
                return new byte4(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z), bits_extractparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_extractparallel(byte8 x, byte8 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi8(x, mask, 8);
            }
            else
            {
                return new byte8(bits_extractparallel(x.x0, mask.x0), bits_extractparallel(x.x1, mask.x1), bits_extractparallel(x.x2, mask.x2), bits_extractparallel(x.x3, mask.x3), bits_extractparallel(x.x4, mask.x4), bits_extractparallel(x.x5, mask.x5), bits_extractparallel(x.x6, mask.x6), bits_extractparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_extractparallel(byte16 x, byte16 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi8(x, mask, 16);
            }
            else
            {
                return new byte16(bits_extractparallel(x.x0, mask.x0), bits_extractparallel(x.x1, mask.x1), bits_extractparallel(x.x2, mask.x2), bits_extractparallel(x.x3, mask.x3), bits_extractparallel(x.x4, mask.x4), bits_extractparallel(x.x5, mask.x5), bits_extractparallel(x.x6, mask.x6), bits_extractparallel(x.x7, mask.x7), bits_extractparallel(x.x8, mask.x8), bits_extractparallel(x.x9, mask.x9), bits_extractparallel(x.x10, mask.x10), bits_extractparallel(x.x11, mask.x11), bits_extractparallel(x.x12, mask.x12), bits_extractparallel(x.x13, mask.x13), bits_extractparallel(x.x14, mask.x14), bits_extractparallel(x.x15, mask.x15));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_extractparallel(byte32 x, byte32 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi8(x, mask);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pext_epi8x2(x.v16_0, x.v16_16, mask.v16_0, mask.v16_16, out v128 lo, out v128 hi);

                return new byte32(lo, hi);
            }
            else
            {
                return new byte32(bits_extractparallel(x.v16_0, mask.v16_0), bits_extractparallel(x.v16_16, mask.v16_16));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extractparallel(sbyte x, sbyte mask)
        {
            return (sbyte)bits_extractparallel((byte)x, (byte)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_extractparallel(sbyte2 x, sbyte2 mask)
        {
            return (sbyte2)bits_extractparallel((byte2)x, (byte2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_extractparallel(sbyte3 x, sbyte3 mask)
        {
            return (sbyte3)bits_extractparallel((byte3)x, (byte3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_extractparallel(sbyte4 x, sbyte4 mask)
        {
            return (sbyte4)bits_extractparallel((byte4)x, (byte4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_extractparallel(sbyte8 x, sbyte8 mask)
        {
            return (sbyte8)bits_extractparallel((byte8)x, (byte8)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_extractparallel(sbyte16 x, sbyte16 mask)
        {
            return (sbyte16)bits_extractparallel((byte16)x, (byte16)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_extractparallel(sbyte32 x, sbyte32 mask)
        {
            return (sbyte32)bits_extractparallel((byte32)x, (byte32)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extractparallel(ushort x, ushort mask)
        {
            ushort result = x;

            if (Bmi2.IsBmi2Supported)
            {
                result = (ushort)Bmi2.pext_u32(x, mask);
            }
            else
            {
                ushort __mask = mask;

                result &= __mask;
                ushort mk = (ushort)(~__mask + ~__mask);

                if (constexpr.IS_CONST(__mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    ushort mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    ushort mv = (ushort)(mp & __mask);
                    __mask = (ushort)(__mask ^ mv | (mv >> 1));
                    ushort t = (ushort)(result & mv);
                    result = (ushort)(result ^ t | (t >> 1));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    mv = (ushort)(mp & __mask);
                    __mask = (ushort)(__mask ^ mv | (mv >> 2));
                    t = (ushort)(result & mv);
                    result = (ushort)(result ^ t | (t >> 2));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    mv = (ushort)(mp & __mask);
                    __mask = (ushort)(__mask ^ mv | (mv >> 4));
                    t = (ushort)(result & mv);
                    result = (ushort)(result ^ t | (t >> 4));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    mv = (ushort)(mp & __mask);
                    t = (ushort)(result & mv);
                    result = (ushort)(result ^ t | (t >> 8));
                }
                else
                {
                    for (int i = 1; i <= 8; i += i)
                    {
                        ushort mp = (ushort)(mk ^ (mk + mk));
                        mp ^= (ushort)(mp << 2);
                        mp ^= (ushort)(mp << 4);
                        mp ^= (ushort)(mp << 8);
                        ushort mv = (ushort)(mp & __mask);
                        __mask = (ushort)(__mask ^ mv | (mv >> i));
                        ushort t = (ushort)(result & mv);
                        result = (ushort)(result ^ t | (t >> i));
                        mk = andnot(mk, mp);
                    }
                }
            }

            Assume.bits_extractparallel(result, x, mask);

            return result;
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_extractparallel(ushort2 x, ushort2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi16(x, mask, 2);
            }
            else
            {
                return new ushort2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_extractparallel(ushort3 x, ushort3 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi16(x, mask, 3);
            }
            else
            {
                return new ushort3(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_extractparallel(ushort4 x, ushort4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi16(x, mask, 4);
            }
            else
            {
                return new ushort4(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z), bits_extractparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_extractparallel(ushort8 x, ushort8 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi16(x, mask, 8);
            }
            else
            {
                return new ushort8(bits_extractparallel(x.x0, mask.x0), bits_extractparallel(x.x1, mask.x1), bits_extractparallel(x.x2, mask.x2), bits_extractparallel(x.x3, mask.x3), bits_extractparallel(x.x4, mask.x4), bits_extractparallel(x.x5, mask.x5), bits_extractparallel(x.x6, mask.x6), bits_extractparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_extractparallel(ushort16 x, ushort16 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi16(x, mask);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pext_epi16x2(x.v8_0, x.v8_8, mask.v8_0, mask.v8_8, out v128 lo, out v128 hi);

                return new ushort16(lo, hi);
            }
            else
            {
                return new ushort16(bits_extractparallel(x.v8_0, mask.v8_0), bits_extractparallel(x.v8_8, mask.v8_8));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extractparallel(short x, short mask)
        {
            return (short)bits_extractparallel((ushort)x, (ushort)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_extractparallel(short2 x, short2 mask)
        {
            return (short2)bits_extractparallel((ushort2)x, (ushort2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_extractparallel(short3 x, short3 mask)
        {
            return (short3)bits_extractparallel((ushort3)x, (ushort3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_extractparallel(short4 x, short4 mask)
        {
            return (short4)bits_extractparallel((ushort4)x, (ushort4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_extractparallel(short8 x, short8 mask)
        {
            return (short8)bits_extractparallel((ushort8)x, (ushort8)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_extractparallel(short16 x, short16 mask)
        {
            return (short16)bits_extractparallel((ushort16)x, (ushort16)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractparallel(uint x, uint mask)
        {
            uint result = x;

            if (Bmi2.IsBmi2Supported)
            {
                result = Bmi2.pext_u32(x, mask);
            }
            else
            {
                uint __mask = mask; 

                result &= __mask;
                uint mk = ~__mask + ~__mask;

                if (constexpr.IS_CONST(__mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    uint mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    uint mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 1);
                    uint t = result & mv;
                    result = result ^ t | (t >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 2);
                    t = result & mv;
                    result = result ^ t | (t >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 4);
                    t = result & mv;
                    result = result ^ t | (t >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 8);
                    t = result & mv;
                    result = result ^ t | (t >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & __mask;
                    t = result & mv;
                    result = result ^ t | (t >> 16);
                }
                else
                {
                    for (int i = 1; i <= 16; i += i)
                    {
                        uint mp = mk ^ (mk + mk);
                        mp ^= mp << 2;
                        mp ^= mp << 4;
                        mp ^= mp << 8;
                        mp ^= mp << 16;
                        uint mv = mp & __mask;
                        __mask = __mask ^ mv | (mv >> i);
                        uint t = result & mv;
                        result = result ^ t | (t >> i);
                        mk = andnot(mk, mp);
                    }
                }
            }

            Assume.bits_extractparallel(result, x, mask);

            return result;
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_extractparallel(uint2 x, uint2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi32(x, mask, 2);
            }
            else
            {
                return new uint2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_extractparallel(uint3 x, uint3 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi32(x, mask, 3);
            }
            else
            {
                return new uint3(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_extractparallel(uint4 x, uint4 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi32(x, mask, 4);
            }
            else
            {
                return new uint4(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z), bits_extractparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_extractparallel(uint8 x, uint8 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi32(x, mask);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pext_epi32x2(x.v4_0, x.v4_4, mask.v4_0, mask.v4_4, out v128 lo, out v128 hi);

                return new uint8(lo, hi);
            }
            else
            {
                return new uint8(bits_extractparallel(x.v4_0, mask.v4_0), bits_extractparallel(x.v4_4, mask.v4_4));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractparallel(int x, int mask)
        {
            return (int)bits_extractparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_extractparallel(int2 x, int2 mask)
        {
            return (int2)bits_extractparallel((uint2)x, (uint2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_extractparallel(int3 x, int3 mask)
        {
            return (int3)bits_extractparallel((uint3)x, (uint3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_extractparallel(int4 x, int4 mask)
        {
            return (int4)bits_extractparallel((uint4)x, (uint4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_extractparallel(int8 x, int8 mask)
        {
            return (int8)bits_extractparallel((uint8)x, (uint8)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractparallel(ulong x, ulong mask)
        {
            ulong result = x;

            if (Bmi2.IsBmi2Supported)
            {
                result = Bmi2.pext_u64(x, mask);
            }
            else
            {
                ulong __mask = mask;

                result &= __mask;
                ulong mk = ~__mask + ~__mask;

                if (constexpr.IS_CONST(__mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    ulong mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    ulong mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 1);
                    ulong t = result & mv;
                    result = result ^ t | (t >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 2);
                    t = result & mv;
                    result = result ^ t | (t >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 4);
                    t = result & mv;
                    result = result ^ t | (t >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 8);
                    t = result & mv;
                    result = result ^ t | (t >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & __mask;
                    __mask = __mask ^ mv | (mv >> 16);
                    t = result & mv;
                    result = result ^ t | (t >> 16);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & __mask;
                    t = result & mv;
                    result = result ^ t | (t >> 32);
                }
                else
                {
                    for (int i = 1; i <= 32; i += i)
                    {
                        ulong mp = mk ^ (mk + mk);
                        mp ^= mp << 2;
                        mp ^= mp << 4;
                        mp ^= mp << 8;
                        mp ^= mp << 16;
                        mp ^= mp << 32;
                        ulong mv = mp & __mask;
                        __mask = __mask ^ mv | (mv >> i);
                        ulong t = result & mv;
                        result = result ^ t | (t >> i);
                        mk = andnot(mk, mp);
                    }
                }
            }

            Assume.bits_extractparallel(result, x, mask);

            return result;
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_extractparallel(ulong2 x, ulong2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pext_epi64(x, mask);
            }
            else
            {
                return new ulong2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_extractparallel(ulong3 x, ulong3 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi64(x, mask, 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pext_epi64x2(x.xy, x.zz, mask.xy, mask.zz, out v128 lo, out v128 hi);

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                return new ulong3(bits_extractparallel(x.xy, mask.xy), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_extractparallel(ulong4 x, ulong4 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi64(x, mask, 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.pext_epi64x2(x.xy, x.zw, mask.xy, mask.zw, out v128 lo, out v128 hi);

                return new ulong4(lo, hi);
            }
            else
            {
                return new ulong4(bits_extractparallel(x.xy, mask.xy), bits_extractparallel(x.zw, mask.zw));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractparallel(long x, long mask)
        {
            return (long)bits_extractparallel((ulong)x, (ulong)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_extractparallel(long2 x, long2 mask)
        {
            return (long2)bits_extractparallel((ulong2)x, (ulong2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_extractparallel(long3 x, long3 mask)
        {
            return (long3)bits_extractparallel((ulong3)x, (ulong3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_extractparallel(long4 x, long4 mask)
        {
            return (long4)bits_extractparallel((ulong4)x, (ulong4)mask);
        }
    }
}