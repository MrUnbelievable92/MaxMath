using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst;
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
            private static void LOOP_pext_epi8([NoAlias] ref v128 a, [NoAlias] ref v128 mask, [NoAlias] ref v128 mk, int i)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 mp = xor_si128(mk, add_epi8(mk, mk));
                    mp = xor_si128(mp, slli_epi8(mp, 2));
                    mp = xor_si128(mp, slli_epi8(mp, 4));
                    v128 mv = and_si128(mp, mask);
                    mask = ternarylogic_si128(srli_epi8(mv, 1 << i, inRange: true), mask, mv, TernaryOperation.OxF6);
                    v128 t = and_si128(a, mv);
                    a = ternarylogic_si128(srli_epi8(t, 1 << i, inRange: true), a, t, TernaryOperation.OxF6);
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
                        case 2:  return                unpacklo_epi8(cvtsi32_si128(Bmi2.pext_u32(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(Bmi2.pext_u32(a.Byte1, mask.Byte1)));

                        case 3:  return unpacklo_epi16(unpacklo_epi8(cvtsi32_si128(Bmi2.pext_u32(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(Bmi2.pext_u32(a.Byte1, mask.Byte1))),
                                                                     cvtsi32_si128(Bmi2.pext_u32(a.Byte2, mask.Byte2)));
                        case 4:  return unpacklo_epi16(unpacklo_epi8(cvtsi32_si128(Bmi2.pext_u32(a.Byte0, mask.Byte0)),
                                                                     cvtsi32_si128(Bmi2.pext_u32(a.Byte1, mask.Byte1))),
                                                       unpacklo_epi8(cvtsi32_si128(Bmi2.pext_u32(a.Byte2, mask.Byte2)),
                                                                     cvtsi32_si128(Bmi2.pext_u32(a.Byte3, mask.Byte3))));
                        default: break;
                    }
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    a = and_si128(a, mask);
                    v128 mk = add_epi8(not_si128(mask), not_si128(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        v128 mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi8(mv, 1, inRange: true), mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi8(t, 1, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi8(mv, 2, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi8(t, 2, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi8(mk, mk));
                        mp = xor_si128(mp, slli_epi8(mp, 2));
                        mp = xor_si128(mp, slli_epi8(mp, 4));
                        mv = and_si128(mp, mask);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi8(t, 4, inRange: true), a, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            LOOP_pext_epi8(ref a, ref mask, ref mk, i);
                        }
                    }

                    return a;
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
                        a0 = and_si128(a0, mask0);
                        v128 mk0 = add_epi8(not_si128(mask0), not_si128(mask0));
                        a1 = and_si128(a1, mask1);
                        v128 mk1 = add_epi8(not_si128(mask1), not_si128(mask1));

                        for (int i = 0; i < 3; i++)
                        {
                            LOOP_pext_epi8(ref a0, ref mask0, ref mk0, i);
                            LOOP_pext_epi8(ref a1, ref mask1, ref mk1, i);
                        }

                        r0 = a0;
                        r1 = a1;
                    }
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
                        case 2:  return                unpacklo_epi16(cvtsi32_si128(Bmi2.pext_u32(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(Bmi2.pext_u32(a.UShort1, mask.UShort1)));

                        case 3:  return unpacklo_epi32(unpacklo_epi16(cvtsi32_si128(Bmi2.pext_u32(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(Bmi2.pext_u32(a.UShort1, mask.UShort1))),
                                                                      cvtsi32_si128(Bmi2.pext_u32(a.UShort2, mask.UShort2)));
                        case 4:  return unpacklo_epi32(unpacklo_epi16(cvtsi32_si128(Bmi2.pext_u32(a.UShort0, mask.UShort0)),
                                                                      cvtsi32_si128(Bmi2.pext_u32(a.UShort1, mask.UShort1))),
                                                       unpacklo_epi16(cvtsi32_si128(Bmi2.pext_u32(a.UShort2, mask.UShort2)),
                                                                      cvtsi32_si128(Bmi2.pext_u32(a.UShort3, mask.UShort3))));
                        default: break;
                    }
                }

                if (BurstArchitecture.IsSIMDSupported)
                {
                    a = and_si128(a, mask);
                    v128 mk = add_epi16(not_si128(mask), not_si128(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        v128 mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi16(mv, 1, inRange: true), mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi16(t, 1, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi16(mv, 2, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi16(t, 2, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi16(mv, 4, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi16(t, 4, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi16(mk, mk));
                        mp = xor_si128(mp, slli_epi16(mp, 2));
                        mp = xor_si128(mp, slli_epi16(mp, 4));
                        mp = xor_si128(mp, slli_epi16(mp, 8));
                        mv = and_si128(mp, mask);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi16(t, 8, inRange: true), a, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            LOOP_pext_epi16(ref a, ref mask, ref mk, i);
                        }
                    }

                    return a;
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
                        a0 = and_si128(a0, mask0);
                        v128 mk0 = add_epi16(not_si128(mask0), not_si128(mask0));
                        a1 = and_si128(a1, mask1);
                        v128 mk1 = add_epi16(not_si128(mask1), not_si128(mask1));

                        for (int i = 0; i < 4; i++)
                        {
                            LOOP_pext_epi16(ref a0, ref mask0, ref mk0, i);
                            LOOP_pext_epi16(ref a1, ref mask1, ref mk1, i);
                        }

                        r0 = a0;
                        r1 = a1;
                    }
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
                        case 2:  return cvtsi64x_si128(Bmi2.pext_u32(a.UInt0, mask.UInt0) | ((ulong)Bmi2.pext_u32(a.UInt1, mask.UInt1) << 32));
                        case 3:  return unpacklo_epi64(cvtsi64x_si128(Bmi2.pext_u32(a.UInt0, mask.UInt0) | ((ulong)Bmi2.pext_u32(a.UInt1, mask.UInt1) << 32)), cvtsi32_si128(Bmi2.pext_u32(a.UInt2, mask.UInt2)));
                        default: return unpacklo_epi64(cvtsi64x_si128(Bmi2.pext_u32(a.UInt0, mask.UInt0) | ((ulong)Bmi2.pext_u32(a.UInt1, mask.UInt1) << 32)), cvtsi64x_si128(Bmi2.pext_u32(a.UInt2, mask.UInt2) | ((ulong)Bmi2.pext_u32(a.UInt3, mask.UInt3) << 32)));
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    a = and_si128(a, mask);
                    v128 mk = add_epi32(not_si128(mask), not_si128(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        v128 mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(mv, 1, inRange: true), mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi32(t, 1, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(mv, 2, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi32(t, 2, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(mv, 4, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi32(t, 4, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi32(mv, 8, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi32(t, 8, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi32(mk, mk));
                        mp = xor_si128(mp, slli_epi32(mp, 2));
                        mp = xor_si128(mp, slli_epi32(mp, 4));
                        mp = xor_si128(mp, slli_epi32(mp, 8));
                        mp = xor_si128(mp, slli_epi32(mp, 16));
                        mv = and_si128(mp, mask);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi32(t, 16, inRange: true), a, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            LOOP_pext_epi32(ref a, ref mask, ref mk, i);
                        }
                    }

                    return a;
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
                        a0 = and_si128(a0, mask0);
                        v128 mk0 = add_epi32(not_si128(mask0), not_si128(mask0));
                        a1 = and_si128(a1, mask1);
                        v128 mk1 = add_epi32(not_si128(mask1), not_si128(mask1));

                        for (int i = 0; i < 5; i++)
                        {
                            LOOP_pext_epi32(ref a0, ref mask0, ref mk0, i);
                            LOOP_pext_epi32(ref a1, ref mask1, ref mk1, i);
                        }

                        r0 = a0;
                        r1 = a1;
                    }
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
                    return new v128(Bmi2.pext_u64(a.ULong0, mask.ULong0), Bmi2.pext_u64(a.ULong1, mask.ULong1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    a = and_si128(a, mask);
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
                        v128 mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(mv, 1, inRange: true), mask, mv, TernaryOperation.OxF6);
                        v128 t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi64(t, 1, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(mv, 2, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi64(t, 2, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(mv, 4, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi64(t, 4, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(mv, 8, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi64(t, 8, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, mask);
                        mask = ternarylogic_si128(srli_epi64(mv, 16, inRange: true), mask, mv, TernaryOperation.OxF6);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi64(t, 16, inRange: true), a, t, TernaryOperation.OxF6);
                        mk = andnot_si128(mp, mk);

                        mp = xor_si128(mk, add_epi64(mk, mk));
                        mp = xor_si128(mp, slli_epi64(mp, 2));
                        mp = xor_si128(mp, slli_epi64(mp, 4));
                        mp = xor_si128(mp, slli_epi64(mp, 8));
                        mp = xor_si128(mp, slli_epi64(mp, 16));
                        mp = xor_si128(mp, slli_epi64(mp, 32));
                        mv = and_si128(mp, mask);
                        t = and_si128(a, mv);
                        a = ternarylogic_si128(srli_epi64(t, 32, inRange: true), a, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            LOOP_pext_epi64(ref a, ref mask, ref mk, i);
                        }
                    }

                    return a;
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
                        a0 = and_si128(a0, mask0);
                        v128 mk0 = add_epi64(not_si128(mask0), not_si128(mask0));
                        a1 = and_si128(a1, mask1);
                        v128 mk1 = add_epi64(not_si128(mask1), not_si128(mask1));

                        for (int i = 0; i < 6; i++)
                        {
                            LOOP_pext_epi64(ref a0, ref mask0, ref mk0, i);
                            LOOP_pext_epi64(ref a1, ref mask1, ref mk1, i);
                        }

                        r0 = a0;
                        r1 = a1;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi8(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_and_si256(a, mask);
                    v256 mk = Avx2.mm256_add_epi8(mm256_not_si256(mask), mm256_not_si256(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        v256 mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi8(mv, 1), mask, mv, TernaryOperation.OxF6);
                        v256 t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi8(t, 1), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi8(mv, 2), mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi8(t, 2), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi8(t, 4), a, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi8(mk, mk));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 2));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi8(mp, 4));
                            v256 mv = Avx2.mm256_and_si256(mp, mask);
                            mask = mm256_ternarylogic_si256(mm256_srli_epi8(mv, 1 << i), mask, mv, TernaryOperation.OxF6);
                            v256 t = Avx2.mm256_and_si256(a, mv);
                            a = mm256_ternarylogic_si256(mm256_srli_epi8(t, 1 << i), a, t, TernaryOperation.OxF6);
                            mk = Avx2.mm256_andnot_si256(mp, mk);
                        }
                    }

                    return a;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi16(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    a = Avx2.mm256_and_si256(a, mask);
                    v256 mk = Avx2.mm256_add_epi16(mm256_not_si256(mask), mm256_not_si256(mask));

                    if (constexpr.IS_CONST(mask)
                     || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        v256 mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 1), mask, mv, TernaryOperation.OxF6);
                        v256 t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi16(t, 1), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 2), mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi16(t, 2), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 4), mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi16(t, 4), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi16(t, 8), a, t, TernaryOperation.OxF6);
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi16(mk, mk));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 2));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 4));
                            mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi16(mp, 8));
                            v256 mv = Avx2.mm256_and_si256(mp, mask);
                            mask = mm256_ternarylogic_si256(mm256_srli_epi16(mv, 1 << i), mask, mv, TernaryOperation.OxF6);
                            v256 t = Avx2.mm256_and_si256(a, mv);
                            a = mm256_ternarylogic_si256(mm256_srli_epi16(t, 1 << i), a, t, TernaryOperation.OxF6);
                            mk = Avx2.mm256_andnot_si256(mp, mk);
                        }
                    }

                    return a;
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
                        a = Avx2.mm256_and_si256(a, mask);
                        v256 mk = Avx2.mm256_add_epi32(mm256_not_si256(mask), mm256_not_si256(mask));

                        v256 mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        v256 mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 1), mask, mv, TernaryOperation.OxF6);
                        v256 t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi32(t, 1), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 2), mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi32(t, 2), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 4), mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi32(t, 4), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        mask = mm256_ternarylogic_si256(mm256_srli_epi32(mv, 8), mask, mv, TernaryOperation.OxF6);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi32(t, 8), a, t, TernaryOperation.OxF6);
                        mk = Avx2.mm256_andnot_si256(mp, mk);

                        mp = Avx2.mm256_xor_si256(mk, Avx2.mm256_add_epi32(mk, mk));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 2));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 4));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 8));
                        mp = Avx2.mm256_xor_si256(mp, mm256_slli_epi32(mp, 16));
                        mv = Avx2.mm256_and_si256(mp, mask);
                        t = Avx2.mm256_and_si256(a, mv);
                        a = mm256_ternarylogic_si256(mm256_srli_epi32(t, 16), a, t, TernaryOperation.OxF6);

                        return a;
                    }
                    else
                    {
                        return new v256(Bmi2.pext_u32(a.UInt0, mask.UInt0),
                                        Bmi2.pext_u32(a.UInt1, mask.UInt1),
                                        Bmi2.pext_u32(a.UInt2, mask.UInt2),
                                        Bmi2.pext_u32(a.UInt3, mask.UInt3),
                                        Bmi2.pext_u32(a.UInt4, mask.UInt4),
                                        Bmi2.pext_u32(a.UInt5, mask.UInt5),
                                        Bmi2.pext_u32(a.UInt6, mask.UInt6),
                                        Bmi2.pext_u32(a.UInt7, mask.UInt7));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi64(v256 a, v256 mask, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_inserti128_si256(Avx.mm256_castsi128_si256(new v128(Bmi2.pext_u64(a.ULong0, mask.ULong0), Bmi2.pext_u64(a.ULong1, mask.ULong1))),
                                                       elements == 3 ? cvtsi64x_si128(Bmi2.pext_u64(a.ULong2, mask.ULong2)) : new v128(Bmi2.pext_u64(a.ULong2, mask.ULong2), Bmi2.pext_u64(a.ULong3, mask.ULong3)),
                                                       1);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
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
            if (Bmi2.IsBmi2Supported)
            {
                ulong lo = Bmi2.pext_u64(x.lo64, mask.lo64);
                ulong hi = Bmi2.pext_u64(x.hi64, mask.hi64);
                int maskloCount = math.countbits(mask.lo64);

                return lo | ((UInt128)hi << maskloCount);
            }
            else
            {
                x &= mask;
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
                    UInt128 mv = mp & mask;
                    mask = mask ^ mv | (mv >> 1);
                    UInt128 t = x & mv;
                    x = x ^ t | (t >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 2);
                    t = x & mv;
                    x = x ^ t | (t >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 4);
                    t = x & mv;
                    x = x ^ t | (t >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 8);
                    t = x & mv;
                    x = x ^ t | (t >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 16);
                    t = x & mv;
                    x = x ^ t | (t >> 16);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 32);
                    t = x & mv;
                    x = x ^ t | (t >> 32);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mp ^= mp << 64;
                    mv = mp & mask;
                    t = x & mv;
                    x = x ^ t | (t >> 64);
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
                        UInt128 mv = mp & mask;
                        mask = mask ^ mv | (mv >> i);
                        UInt128 t = x & mv;
                        x = x ^ t | (t >> i);
                        mk = andnot(mk, mp);
                    }
                }

                return x;
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extractparallel(byte x, byte mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return (byte)Bmi2.pext_u32(x, mask);
            }
            else
            {
                x &= mask;
                byte mk = (byte)(~mask + ~mask);

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    byte mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    byte mv = (byte)(mp & mask);
                    mask = (byte)(mask ^ mv | (mv >> 1));
                    byte t = (byte)(x & mv);
                    x = (byte)(x ^ t | (t >> 1));
                    mk = andnot(mk, mp);

                    mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    mv = (byte)(mp & mask);
                    mask = (byte)(mask ^ mv | (mv >> 2));
                    t = (byte)(x & mv);
                    x = (byte)(x ^ t | (t >> 2));
                    mk = andnot(mk, mp);

                    mp = (byte)(mk ^ (mk + mk));
                    mp ^= (byte)(mp << 2);
                    mp ^= (byte)(mp << 4);
                    mv = (byte)(mp & mask);
                    t = (byte)(x & mv);
                    x = (byte)(x ^ t | (t >> 4));
                }
                else
                {
                    for (int i = 1; i <= 4; i += i)
                    {
                        byte mp = (byte)(mk ^ (mk + mk));
                        mp ^= (byte)(mp << 2);
                        mp ^= (byte)(mp << 4);
                        byte mv = (byte)(mp & mask);
                        mask = (byte)(mask ^ mv | (mv >> i));
                        byte t = (byte)(x & mv);
                        x = (byte)(x ^ t | (t >> i));
                        mk = andnot(mk, mp);
                    }
                }

                return x;
            }
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
            if (Bmi2.IsBmi2Supported)
            {
                return (ushort)Bmi2.pext_u32(x, mask);
            }
            else
            {
                x &= mask;
                ushort mk = (ushort)(~mask + ~mask);

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    ushort mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    ushort mv = (ushort)(mp & mask);
                    mask = (ushort)(mask ^ mv | (mv >> 1));
                    ushort t = (ushort)(x & mv);
                    x = (ushort)(x ^ t | (t >> 1));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    mv = (ushort)(mp & mask);
                    mask = (ushort)(mask ^ mv | (mv >> 2));
                    t = (ushort)(x & mv);
                    x = (ushort)(x ^ t | (t >> 2));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    mv = (ushort)(mp & mask);
                    mask = (ushort)(mask ^ mv | (mv >> 4));
                    t = (ushort)(x & mv);
                    x = (ushort)(x ^ t | (t >> 4));
                    mk = andnot(mk, mp);

                    mp = (ushort)(mk ^ (mk + mk));
                    mp ^= (ushort)(mp << 2);
                    mp ^= (ushort)(mp << 4);
                    mp ^= (ushort)(mp << 8);
                    mv = (ushort)(mp & mask);
                    t = (ushort)(x & mv);
                    x = (ushort)(x ^ t | (t >> 8));
                }
                else
                {
                    for (int i = 1; i <= 8; i += i)
                    {
                        ushort mp = (ushort)(mk ^ (mk + mk));
                        mp ^= (ushort)(mp << 2);
                        mp ^= (ushort)(mp << 4);
                        mp ^= (ushort)(mp << 8);
                        ushort mv = (ushort)(mp & mask);
                        mask = (ushort)(mask ^ mv | (mv >> i));
                        ushort t = (ushort)(x & mv);
                        x = (ushort)(x ^ t | (t >> i));
                        mk = andnot(mk, mp);
                    }
                }

                return x;
            }
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
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u32(x, mask);
            }
            else
            {
                x &= mask;
                uint mk = ~mask + ~mask;

                if (constexpr.IS_CONST(mask)
                 || COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                {
                    uint mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    uint mv = mp & mask;
                    mask = mask ^ mv | (mv >> 1);
                    uint t = x & mv;
                    x = x ^ t | (t >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 2);
                    t = x & mv;
                    x = x ^ t | (t >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 4);
                    t = x & mv;
                    x = x ^ t | (t >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 8);
                    t = x & mv;
                    x = x ^ t | (t >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mv = mp & mask;
                    t = x & mv;
                    x = x ^ t | (t >> 16);
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
                        uint mv = mp & mask;
                        mask = mask ^ mv | (mv >> i);
                        uint t = x & mv;
                        x = x ^ t | (t >> i);
                        mk = andnot(mk, mp);
                    }
                }

                return x;
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_extractparallel(uint2 x, uint2 mask)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.pext_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 2));
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
                return RegisterConversion.ToUInt3(Xse.pext_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 3));
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
                return RegisterConversion.ToUInt4(Xse.pext_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 4));
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
                Xse.pext_epi32x2(RegisterConversion.ToV128(x.v4_0),RegisterConversion.ToV128( x.v4_4), RegisterConversion.ToV128(mask.v4_0), RegisterConversion.ToV128(mask.v4_4), out v128 lo, out v128 hi);

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
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
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u64(x, mask);
            }
            else
            {
                x &= mask;
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
                    ulong mv = mp & mask;
                    mask = mask ^ mv | (mv >> 1);
                    ulong t = x & mv;
                    x = x ^ t | (t >> 1);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 2);
                    t = x & mv;
                    x = x ^ t | (t >> 2);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 4);
                    t = x & mv;
                    x = x ^ t | (t >> 4);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 8);
                    t = x & mv;
                    x = x ^ t | (t >> 8);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & mask;
                    mask = mask ^ mv | (mv >> 16);
                    t = x & mv;
                    x = x ^ t | (t >> 16);
                    mk = andnot(mk, mp);

                    mp = mk ^ (mk + mk);
                    mp ^= mp << 2;
                    mp ^= mp << 4;
                    mp ^= mp << 8;
                    mp ^= mp << 16;
                    mp ^= mp << 32;
                    mv = mp & mask;
                    t = x & mv;
                    x = x ^ t | (t >> 32);
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
                        ulong mv = mp & mask;
                        mask = mask ^ mv | (mv >> i);
                        ulong t = x & mv;
                        x = x ^ t | (t >> i);
                        mk = andnot(mk, mp);
                    }
                }

                return x;
            }
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