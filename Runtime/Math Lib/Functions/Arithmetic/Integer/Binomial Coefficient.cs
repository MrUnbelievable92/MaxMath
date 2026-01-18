using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FACTORIAL;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            public static v128 comb_epu8(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return comb_ep8(n, k, false, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }

            public static v128 comb_epi8(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<sbyte16, sbyte>(n, elements, NumericDataType.Integer);
VectorAssert.IsNonNegative<sbyte16, sbyte>(k, elements, NumericDataType.Integer);

                    return comb_ep8(n, k, true, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epu8x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    comb_ep8x2(n0, n1, k0, k1, out r0, out r1, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epi8x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<sbyte16, sbyte>(n0, 16, NumericDataType.Integer);
VectorAssert.IsNonNegative<sbyte16, sbyte>(k0, 16, NumericDataType.Integer);
VectorAssert.IsNonNegative<sbyte16, sbyte>(n1, 16, NumericDataType.Integer);
VectorAssert.IsNonNegative<sbyte16, sbyte>(k1, 16, NumericDataType.Integer);

                    comb_ep8x2(n0, n1, k0, k1, out r0, out r1, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v128 comb_epu16(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return comb_ep16(n, k, false, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }

            public static v128 comb_epi16(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<short8, short>(n, elements, NumericDataType.Integer);
VectorAssert.IsNonNegative<short8, short>(k, elements, NumericDataType.Integer);

                    return comb_ep16(n, k, true, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epu16x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    comb_ep16x2(n0, n1, k0, k1, out r0, out r1, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epi16x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<short8, short>(n0, 8, NumericDataType.Integer);
VectorAssert.IsNonNegative<short8, short>(k0, 8, NumericDataType.Integer);
VectorAssert.IsNonNegative<short8, short>(n1, 8, NumericDataType.Integer);
VectorAssert.IsNonNegative<short8, short>(k1, 8, NumericDataType.Integer);

                    comb_ep16x2(n0, n1, k0, k1, out r0, out r1, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v128 comb_epu32(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return comb_ep32(n, k, false, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }

            public static v128 comb_epi32(v128 n, v128 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<int4, int>(RegisterConversion.ToInt4(n), elements, NumericDataType.Integer);
VectorAssert.IsNonNegative<int4, int>(RegisterConversion.ToInt4(k), elements, NumericDataType.Integer);

                    return comb_ep32(n, k, true, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epu32x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    comb_ep32x2(n0, n1, k0, k1, out r0, out r1, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epi32x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<int4, int>(RegisterConversion.ToInt4(n0), 4, NumericDataType.Integer);
VectorAssert.IsNonNegative<int4, int>(RegisterConversion.ToInt4(k0), 4, NumericDataType.Integer);
VectorAssert.IsNonNegative<int4, int>(RegisterConversion.ToInt4(n1), 4, NumericDataType.Integer);
VectorAssert.IsNonNegative<int4, int>(RegisterConversion.ToInt4(k1), 4, NumericDataType.Integer);

                    comb_ep32x2(n0, n1, k0, k1, out r0, out r1, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v128 comb_epu64(v128 n, v128 k, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return comb_ep64(n, k, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v128 comb_epi64(v128 n, v128 k, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<long2, long>(n, 2, NumericDataType.Integer);
VectorAssert.IsNonNegative<long2, long>(k, 2, NumericDataType.Integer);

                    return comb_ep64(n, k, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epu64x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    comb_ep64x2(n0, n1, k0, k1, out r0, out r1, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static void comb_epi64x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNonNegative<long2, long>(n0, 2, NumericDataType.Integer);
VectorAssert.IsNonNegative<long2, long>(k0, 2, NumericDataType.Integer);
VectorAssert.IsNonNegative<long2, long>(n1, 2, NumericDataType.Integer);
VectorAssert.IsNonNegative<long2, long>(k1, 2, NumericDataType.Integer);

                    comb_ep64x2(n0, n1, k0, k1, out r0, out r1, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epu8(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_comb_ep8(n, k, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epi8(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNonNegative<sbyte32, sbyte>(n, 32, NumericDataType.Integer);
VectorAssert.IsNonNegative<sbyte32, sbyte>(k, 32, NumericDataType.Integer);

                    return mm256_comb_ep8(n, k, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epu16(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_comb_ep16(n, k, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epi16(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNonNegative<short16, short>(n, 16, NumericDataType.Integer);
VectorAssert.IsNonNegative<short16, short>(k, 16, NumericDataType.Integer);

                    return mm256_comb_ep16(n, k, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epu32(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_comb_ep32(n, k, false, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epi32(v256 n, v256 k, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNonNegative<int8, int>(n, 8, NumericDataType.Integer);
VectorAssert.IsNonNegative<int8, int>(k, 8, NumericDataType.Integer);

                    return mm256_comb_ep32(n, k, true, unsafeLevels);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epu64(v256 n, v256 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_comb_ep64(n, k, false, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }

            public static v256 mm256_comb_epi64(v256 n, v256 k, byte unsafeLevels = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNonNegative<long4, long>(n, elements, NumericDataType.Integer);
VectorAssert.IsNonNegative<long4, long>(k, elements, NumericDataType.Integer);

                    return mm256_comb_ep64(n, k, true, unsafeLevels, elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<byte16> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 15;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                        d = new Divider<byte16>((byte16)adds_epu8(d.Divisor, set1_epi8(16)), d._promises);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<byte32> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (Avx2.IsAvx2Supported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 31;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                        d = new Divider<byte32>((byte32)Avx2.mm256_adds_epu8(d.Divisor, mm256_set1_epi8(32)), d._promises);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<ushort8> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 7;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                        d = new Divider<ushort8>((ushort8)adds_epu16(d.Divisor, set1_epi16(8)), d._promises);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<ushort16> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (Avx2.IsAvx2Supported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 15;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                        d = new Divider<ushort16>((ushort16)Avx2.mm256_adds_epu16(d.Divisor, mm256_set1_epi16(16)), d._promises);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<uint4> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 3;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                    #if DEBUG
                        d = new Divider<uint4>(RegisterConversion.ToUInt4(adds_epu32(RegisterConversion.ToV128(d.Divisor), set1_epi32(4))), d._promises);
                    #else
                        d = new Divider<uint4>(RegisterConversion.ToUInt4(add_epi32(RegisterConversion.ToV128(d.Divisor), set1_epi32(4))), d._promises);
                    #endif
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<uint8> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (Avx2.IsAvx2Supported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 7;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                    #if DEBUG
                        d = new Divider<uint8>((uint8)mm256_adds_epu32(d.Divisor, mm256_set1_epi32(8)), d._promises);
                    #else
                        d = new Divider<uint8>((uint8)Avx2.mm256_add_epi32(d.Divisor, mm256_set1_epi32(8)), d._promises);
                    #endif
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<ulong2> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 1;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                    #if DEBUG
                        d = new Divider<ulong2>((ulong2)adds_epu64(d.Divisor, set1_epi64x(2)), d._promises);
                    #else
                        d = new Divider<ulong2>((ulong2)add_epi64(d.Divisor, set1_epi64x(2)), d._promises);
                    #endif
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static void next_comb_divider([NoAlias] ref Divider<ulong4> d, [NoAlias] ref int indexCurrentDivider)
            {
                if (Avx2.IsAvx2Supported)
                {
                    indexCurrentDivider++;
                    indexCurrentDivider &= 3;
                    if (Hint.Unlikely(indexCurrentDivider == 0))
                    {
                    #if DEBUG
                        d = new Divider<ulong4>((ulong4)mm256_adds_epu64(d.Divisor, mm256_set1_epi64x(4)), d._promises);
                    #else
                        d = new Divider<ulong4>((ulong4)Avx2.mm256_add_epi64(d.Divisor, mm256_set1_epi64x(4)), d._promises);
                    #endif
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naivecomb_epu8(v128 n, v128 k, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 nom = gamma_epu8(n, true, elements);
                    v128 denom = mullo_epi8(gamma_epu8(k, true, elements), gamma_epu8(sub_epi8(n, k), true, elements), elements);

                    return div_epu8(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naivecomb_epu16(v128 n, v128 k, bool epu8range = false, byte elements = 8)
            {
                v128 nom;
                v128 denom;
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (epu8range || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8, elements))
                    {
                        if (BurstArchitecture.IsTableLookupSupported)
                        {
                            nom = gamma_epu16_epu8range(n);
                            denom = mullo_epi16(gamma_epu16_epu8range(k), gamma_epu16_epu8range(sub_epi16(n, k)));

                            return div_epu16(nom, denom, elements);
                        }
                    }

                    nom = gamma_epu16(n, true, elements);
                    denom = mullo_epi16(gamma_epu16(k, true, elements), gamma_epu16(sub_epi16(n, k), true, elements));

                    return div_epu16(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naivecomb_epu32(v128 n, v128 k, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 nom = gamma_epu32(n, true, elements);
                    v128 denom = mullo_epi32(gamma_epu32(k, true, elements), gamma_epu32(sub_epi32(n, k), true, elements));

                    return div_epu32(nom, denom, elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 naivecomb_epu64(v128 n, v128 k, bool useFPU = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 nom = gamma_epu64(n, true);
                    v128 denom = mullo_epi64(gamma_epu64(k, true), gamma_epu64(sub_epi64(n, k), true));

                    return div_epu64(nom, denom, useFPU: useFPU);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu8(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu8(n, true);
                    v256 denom = mm256_mullo_epi8(mm256_gamma_epu8(k, true), mm256_gamma_epu8(Avx2.mm256_sub_epi8(n, k), true));

                    return mm256_div_epu8(nom, denom);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu16(v256 n, v256 k, bool epu8range = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (epu8range || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8))
                    {
                        v256 nom = mm256_gamma_epu16_epu8range(n);
                        v256 denom = Avx2.mm256_mullo_epi16(mm256_gamma_epu16_epu8range(k), mm256_gamma_epu16_epu8range(Avx2.mm256_sub_epi16(n, k)));

                        return mm256_div_epu16(nom, denom);
                    }
                    else
                    {
                        v256 nom = mm256_gamma_epu16(n, true);
                        v256 denom = Avx2.mm256_mullo_epi16(mm256_gamma_epu16(k, true), mm256_gamma_epu16(Avx2.mm256_sub_epi16(n, k), true));

                        return mm256_div_epu16(nom, denom);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu32(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu32(n, true);
                    v256 denom = Avx2.mm256_mullo_epi32(mm256_gamma_epu32(k, true), mm256_gamma_epu32(Avx2.mm256_sub_epi32(n, k), true));

                    return mm256_div_epu32(nom, denom);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_naivecomb_epu64(v256 n, v256 k, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 nom = mm256_gamma_epu64(n, true, elements);
                    v256 denom = mm256_mullo_epi64(mm256_gamma_epu64(k, true), mm256_gamma_epu64(Avx2.mm256_sub_epi64(n, k), true, elements));

                    return mm256_div_epu64(nom, denom, elements: elements);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 castcomb_epu16(v128 n, v128 k, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi16(1);
                    Divider<ushort8> loopDividerSSE = new Divider<ushort8>(new ushort8(9, 10, 11, 12, 13, 14, 15, 16), Divider<ushort16>.WELL_KNOWN_COMB_PROMISES);
                    Divider<ushort16> loopDividerAVX = new Divider<ushort16>(loopDividerSSE, new Divider<ushort8>(new ushort8(17, 18, 19, 20, 21, 22, 23, 24), Divider<ushort8>.WELL_KNOWN_COMB_PROMISES));
                    int indexCurrentDivider = 0;

                    v128 cmp;
                    v128 results;
                    v128 i = ONE;
                    v128 c = n;
                    k = min_epu8(k, sub_epi16(n, k));
                    results = blendv_si128(c, ONE, cmpeq_epi16(k, setzero_si128()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = mullo_epi16(c, n);
                        c = constdiv_epu16(c, 2, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = mullo_epi16(c, n);
                        c = constdiv_epu16(c, 3, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = mullo_epi16(c, n);
                        c = constdiv_epu16(c, 4, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = mullo_epi16(c, n);
                        c = constdiv_epu16(c, 5, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = mullo_epi16(c, n);
                        c = constdiv_epu16(c, 6, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = mullo_epi16(c, n);
                        c = constdiv_epu16(c, 7, elements);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = mullo_epi16(c, n);
                        c = constdiv_epu16(c, 8, elements);
                        results = blendv_si128(results, c, cmp);
                    }

                    while (notallfalse_epi128<ushort>(cmp = cmpgt_epi16(k, i), elements))
                    {
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);

                        c = mullo_epi16(c, n);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            c = div_epu16(c, i, elements);
                        }
                        else
                        {
                            Divider<ushort> currentDivider;
                            if (Avx2.IsAvx2Supported)
                            {
                                currentDivider = loopDividerAVX.GetInnerDivider<ushort>(indexCurrentDivider);
                                next_comb_divider(ref loopDividerAVX, ref indexCurrentDivider);
                            }
                            else
                            {
                                currentDivider = loopDividerSSE.GetInnerDivider<ushort>(indexCurrentDivider);
                                next_comb_divider(ref loopDividerSSE, ref indexCurrentDivider);
                            }
                            switch (elements)
                            {
                                case 2:  c = (ushort2)c / currentDivider; break;
                                case 3:  c = (ushort3)c / currentDivider; break;
                                case 4:  c = (ushort4)c / currentDivider; break;
                                default: c = (ushort8)c / currentDivider; break;
                            }
                        }

                        results = blendv_si128(results, c, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 castcomb_epu32(v128 n, v128 k, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi32(1);
                    Divider<uint4> loopDividerSSE = new Divider<uint4>(new uint4(9, 10, 11, 12), Divider<uint4>.WELL_KNOWN_COMB_PROMISES);
                    Divider<uint8> loopDividerAVX = new Divider<uint8>(loopDividerSSE, new Divider<uint4>(new uint4(13, 14, 15, 16), Divider<uint4>.WELL_KNOWN_COMB_PROMISES));
                    int indexCurrentDivider = 0;

                    v128 cmp;
                    v128 results;
                    v128 i = ONE;
                    v128 c = n;
                    k = min_epu16(k, sub_epi32(n, k), (byte)(2 * elements));
                    results = blendv_si128(c, ONE, cmpeq_epi32(k, setzero_si128()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = mullo_epi32(c, n, elements);
                        c = constdiv_epu32(c, 2, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = mullo_epi32(c, n, elements);
                        c = constdiv_epu32(c, 3, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = mullo_epi32(c, n, elements);
                        c = constdiv_epu32(c, 4, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = mullo_epi32(c, n, elements);
                        c = constdiv_epu32(c, 5, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = mullo_epi32(c, n, elements);
                        c = constdiv_epu32(c, 6, elements, __unsafe: true);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = mullo_epi32(c, n, elements);
                        c = constdiv_epu32(c, 7, elements);
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = mullo_epi32(c, n, elements);
                        c = constdiv_epu32(c, 8, elements);
                        results = blendv_si128(results, c, cmp);
                    }

                    while (notallfalse_epi128<uint>(cmp = cmpgt_epi32(k, i), elements))
                    {
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);

                        c = mullo_epi32(c, n, elements);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            c = div_epu32(c, i, elements);
                        }
                        else
                        {
                            Divider<uint> currentDivider;
                            if (Avx2.IsAvx2Supported)
                            {
                                currentDivider = loopDividerAVX.GetInnerDivider<uint>(indexCurrentDivider);
                                next_comb_divider(ref loopDividerAVX, ref indexCurrentDivider);
                            }
                            else
                            {
                                currentDivider = loopDividerSSE.GetInnerDivider<uint>(indexCurrentDivider);
                                next_comb_divider(ref loopDividerSSE, ref indexCurrentDivider);
                            }
                            switch (elements)
                            {
                                case 2:  c = RegisterConversion.ToV128(RegisterConversion.ToUInt2(c) / currentDivider); break;
                                case 3:  c = RegisterConversion.ToV128(RegisterConversion.ToUInt3(c) / currentDivider); break;
                                default: c = RegisterConversion.ToV128(RegisterConversion.ToUInt4(c) / currentDivider); break;
                            }
                        }

                        results = blendv_si128(results, c, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_castcomb_epu16(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ONE = mm256_set1_epi16(1);
                    Divider<ushort16> loopDivider = new Divider<ushort16>(new ushort16(9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24), Divider<ushort16>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    v256 cmp;
                    v256 results;
                    v256 i = ONE;
                    v256 c = n;
                    k = Avx2.mm256_min_epu8(k, Avx2.mm256_sub_epi16(n, k));
                    results = mm256_blendv_si256(c, ONE, Avx2.mm256_cmpeq_epi16(k, Avx.mm256_setzero_si256()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_mullo_epi16(c, n);
                        c = mm256_constdiv_epu16(c, 2, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_mullo_epi16(c, n);
                        c = mm256_constdiv_epu16(c, 3, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_mullo_epi16(c, n);
                        c = mm256_constdiv_epu16(c, 4, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_mullo_epi16(c, n);
                        c = mm256_constdiv_epu16(c, 5, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_mullo_epi16(c, n);
                        c = mm256_constdiv_epu16(c, 6, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_mullo_epi16(c, n);
                        c = mm256_constdiv_epu16(c, 7);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_mullo_epi16(c, n);
                        c = mm256_constdiv_epu16(c, 8);
                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    while (mm256_notallfalse_epi256<ushort>(cmp = Avx2.mm256_cmpgt_epi16(k, i)))
                    {
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);

                        c = Avx2.mm256_mullo_epi16(c, n);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            c = mm256_div_epu16(c, i);
                        }
                        else
                        {
                            c = (ushort16)c / loopDivider.GetInnerDivider<ushort>(indexCurrentDivider);
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }

                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_castcomb_epu32(v256 n, v256 k)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ONE = mm256_set1_epi32(1);
                    Divider<uint8> loopDivider = new Divider<uint8>(new uint8(9, 10, 11, 12, 13, 14, 15, 16), Divider<uint8>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    v256 cmp;
                    v256 results;
                    v256 i = ONE;
                    v256 c = n;
                    k = Avx2.mm256_min_epu16(k, Avx2.mm256_sub_epi32(n, k));
                    results = mm256_blendv_si256(c, ONE, Avx2.mm256_cmpeq_epi32(k, Avx.mm256_setzero_si256()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_mullo_epi32(c, n);
                        c = mm256_constdiv_epu32(c, 2, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_mullo_epi32(c, n);
                        c = mm256_constdiv_epu32(c, 3, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_mullo_epi32(c, n);
                        c = mm256_constdiv_epu32(c, 4, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_mullo_epi32(c, n);
                        c = mm256_constdiv_epu32(c, 5, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_mullo_epi32(c, n);
                        c = mm256_constdiv_epu32(c, 6, __unsafe: true);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_mullo_epi32(c, n);
                        c = mm256_constdiv_epu32(c, 7);
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_mullo_epi32(c, n);
                        c = mm256_constdiv_epu32(c, 8);
                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    while (mm256_notallfalse_epi256<uint>(cmp = Avx2.mm256_cmpgt_epi32(k, i)))
                    {
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);

                        c = Avx2.mm256_mullo_epi32(c, n);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            c = mm256_div_epu32(c, i);
                        }
                        else
                        {
                            c = (uint8)c / loopDivider.GetInnerDivider<uint>(indexCurrentDivider);
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }

                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_comb_ep8([NoAlias] ref v128 n, [NoAlias] ref v128 k, [NoAlias] out v128 results, [NoAlias] out v128 i, [NoAlias] out v128 c)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi8(1);

                    v128 cmp;
                    i = ONE;
                    c = n;
                    k = min_epu8(k, sub_epi8(n, k));
                    results = blendv_si128(c, ONE, cmpeq_epi8(k, setzero_si128()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = cmpgt_epi8(k, ONE);
                        n = sub_epi8(n, ONE);
                        c = add_epi8(mullo_epi8(constdiv_epu8(c, 2), n), and_si128(neg_epi8(constrem_epu8(c, 2)), constdiv_epu8(n, 2)));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi8(k, set1_epi8(2));
                        n = sub_epi8(n, ONE);
                        v128 rem3 = constrem_epu8(c, 3);
                        v128 rem3is1orMore = cmpgt_epi8(rem3, setzero_si128());
                        v128 rem3is2orMore = cmpgt_epi8(rem3, ONE);
                        v128 mulrem3 = add_epi8(and_si128(rem3is1orMore, n), and_si128(rem3is2orMore, n));
                        c = add_epi8(mullo_epi8(constdiv_epu8(c, 3), n), constdiv_epu8(mulrem3, 3));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi8(k, set1_epi8(3));
                        n = sub_epi8(n, ONE);
                        v128 rem4 = constrem_epu8(c, 4);
                        v128 rem4is1orMore = cmpgt_epi8(rem4, setzero_si128());
                        v128 rem4is2orMore = cmpgt_epi8(rem4, ONE);
                        v128 rem4is3orMore = cmpgt_epi8(rem4, set1_epi8(2));
                        v128 mulrem4 = add_epi8(and_si128(rem4is1orMore, n), add_epi8(and_si128(rem4is2orMore, n), and_si128(rem4is3orMore, n)));
                        c = add_epi8(mullo_epi8(constdiv_epu8(c, 4), n), constdiv_epu8(mulrem4, 4));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi8(k, set1_epi8(4));
                        n = sub_epi8(n, ONE);
                        v128 rem5 = constrem_epu8(c, 5);
                        v128 rem5is1orMore = cmpgt_epi8(rem5, setzero_si128());
                        v128 rem5is2orMore = cmpgt_epi8(rem5, ONE);
                        v128 rem5is3orMore = cmpgt_epi8(rem5, set1_epi8(2));
                        v128 rem5is4orMore = cmpgt_epi8(rem5, set1_epi8(3));
                        v128 mulrem5 = add_epi8(add_epi8(and_si128(rem5is1orMore, n), and_si128(rem5is2orMore, n)), add_epi8(and_si128(rem5is3orMore, n), and_si128(rem5is4orMore, n)));
                        c = add_epi8(mullo_epi8(constdiv_epu8(c, 5), n), constdiv_epu8(mulrem5, 5));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi8(k, set1_epi8(5));
                        n = sub_epi8(n, ONE);
                        v128 rem6 = constrem_epu8(c, 6);
                        v128 rem6is1orMore = cmpgt_epi8(rem6, setzero_si128());
                        v128 rem6is2orMore = cmpgt_epi8(rem6, ONE);
                        v128 rem6is3orMore = cmpgt_epi8(rem6, set1_epi8(2));
                        v128 rem6is4orMore = cmpgt_epi8(rem6, set1_epi8(3));
                        v128 rem6is5orMore = cmpgt_epi8(rem6, set1_epi8(4));
                        v128 mulrem6 = add_epi8(add_epi8(add_epi8(and_si128(rem6is1orMore, n), and_si128(rem6is2orMore, n)), add_epi8(and_si128(rem6is3orMore, n), and_si128(rem6is4orMore, n))), and_si128(rem6is5orMore, n));
                        c = add_epi8(mullo_epi8(constdiv_epu8(c, 6), n), constdiv_epu8(mulrem6, 6));
                        results = blendv_si128(results, c, cmp);

                        i = set1_epi8(6);
                        cmp = cmpgt_epi8(k, i);
                        i = add_epi8(i, ONE);
                        n = sub_epi8(n, ONE);
                        v128 rem7 = constrem_epu8(c, 7);
                        v128 rem7is1orMore = cmpgt_epi8(rem7, setzero_si128());
                        v128 rem7is2orMore = cmpgt_epi8(rem7, ONE);
                        v128 rem7is3orMore = cmpgt_epi8(rem7, set1_epi8(2));
                        v128 rem7is4orMore = cmpgt_epi8(rem7, set1_epi8(3));
                        v128 rem7is5orMore = cmpgt_epi8(rem7, set1_epi8(4));
                        v128 rem7is6orMore = cmpgt_epi8(rem7, set1_epi8(5));
                        v128 mulrem7 = add_epi8(add_epi8(add_epi8(and_si128(rem7is1orMore, n), and_si128(rem7is2orMore, n)), add_epi8(and_si128(rem7is3orMore, n), and_si128(rem7is4orMore, n))), add_epi8(and_si128(rem7is5orMore, n), and_si128(rem7is6orMore, n)));
                        c = add_epi8(mullo_epi8(constdiv_epu8(c, 7), n), constdiv_epu8(mulrem7, 7));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi8(k, i);
                        i = add_epi8(i, ONE);
                        n = sub_epi8(n, ONE);
                        c = add_epi8(mullo_epi8(constdiv_epu8(c, 8), n), constdiv_epu8(mullo_epi8(constrem_epu8(c, 8), n), 8));
                        results = blendv_si128(results, c, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_comb_ep8([NoAlias] ref v128 n, [NoAlias] ref v128 i, [NoAlias] ref v128 c, [NoAlias] ref v128 results, [NoAlias] ref Divider<byte16> loopDivider, [NoAlias] ref int indexCurrentDivider, v128 cmp, bool CMP_EPI, bool nextDividerTest)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi8(1);

                    i = add_epi8(i, ONE);
                    n = sub_epi8(n, ONE);

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v128 q = divrem_epu8(c, i, out v128 r);
                        c = add_epi8(mullo_epi8(q, n), div_epu8(mullo_epi8(r, n), i));
                    }
                    else
                    {
                        Divider<byte> currentDivider = loopDivider.GetInnerDivider<byte>(indexCurrentDivider);
                        v128 q = currentDivider.DivRem(c, out byte16 r);
                        c = add_epi8(mullo_epi8(q, n), (r * n) / currentDivider);

                        if (nextDividerTest)
                        {
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }
                    }

                    if (!nextDividerTest)
                    {
                        i = sub_epi8(i, ONE);
                    }

                    results = CMP_EPI ? blendv_si128(results, c, cmp)
                                      : blendv_si128(c, results, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 comb_ep8(v128 n, v128 k, bool signed, byte unsafeLevels = 0, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<byte16, byte>(k, n, elements);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U16, elements))
                            {
                                if (unsafeLevels > 3 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U8, elements))
                                {
                                    return naivecomb_epu8(n, k, elements);
                                }
                                else
                                {
                                    if (elements <= 8)
                                    {
                                        return cvtepi16_epi8(naivecomb_epu16(cvtepu8_epi16(n), cvtepu8_epi16(k), false, elements), elements);
                                    }
                                    else
                                    {
                                        if (Avx2.IsAvx2Supported)
                                        {
                                            return mm256_cvtepi16_epi8(mm256_naivecomb_epu16(Avx2.mm256_cvtepu8_epi16(n), Avx2.mm256_cvtepu8_epi16(k), false));
                                        }
                                        else
                                        {
                                            v128 nLo16 = cvt2x2epu8_epi16(n, out v128 nHi16);
                                            v128 kLo16 = cvt2x2epu8_epi16(k, out v128 kHi16);

                                            v128 resultLo = naivecomb_epu16(nLo16, kLo16, false, elements);
                                            v128 resultHi = naivecomb_epu16(nHi16, kHi16, false, elements);

                                            return cvt2x2epi16_epi8(resultLo, resultHi);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (elements <= 4)
                                {
                                    return cvtepi32_epi8(naivecomb_epu32(cvtepu8_epi32(n), cvtepu8_epi32(k), elements));
                                }
                                else
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        if (elements == 8)
                                        {
                                            return mm256_cvtepi32_epi8(mm256_naivecomb_epu32(Avx2.mm256_cvtepu8_epi32(n), Avx2.mm256_cvtepu8_epi32(k)));
                                        }
                                        else
                                        {
                                            v256 loN32 = Avx2.mm256_cvtepu8_epi32(n);
                                            v256 hiN32 = Avx2.mm256_cvtepu8_epi32(bsrli_si128(n, 8 * sizeof(byte)));
                                            v256 loK32 = Avx2.mm256_cvtepu8_epi32(k);
                                            v256 hiK32 = Avx2.mm256_cvtepu8_epi32(bsrli_si128(k, 8 * sizeof(byte)));

                                            v128 resultLo = mm256_cvtepi32_epi8(mm256_naivecomb_epu32(loN32, loK32));
                                            v128 resultHi = mm256_cvtepi32_epi8(mm256_naivecomb_epu32(hiN32, hiK32));

                                            return unpacklo_epi64(resultLo, resultHi);
                                        }
                                    }
                                    else
                                    {
                                        if (elements == 8)
                                        {
                                            v128 loN32 = cvt2x2epu8_epi32(n, out v128 hiN32);
                                            v128 loK32 = cvt2x2epu8_epi32(k, out v128 hiK32);

                                            v128 resultLo = naivecomb_epu32(loN32, loK32);
                                            v128 resultHi = naivecomb_epu32(hiN32, hiK32);

                                            v128 result = cvt2x2epi32_epi16(resultLo, resultHi);

                                            return cvt2x2epi16_epi8(result, result);
                                        }
                                        else
                                        {
                                            cvt4x4epu8_epi32(n, out v128 n32_0, out v128 n32_1, out v128 n32_2, out v128 n32_3);
                                            cvt4x4epu8_epi32(k, out v128 k32_0, out v128 k32_1, out v128 k32_2, out v128 k32_3);

                                            v128 result32_0 = naivecomb_epu32(n32_0, k32_0);
                                            v128 result32_1 = naivecomb_epu32(n32_1, k32_1);
                                            v128 result32_2 = naivecomb_epu32(n32_2, k32_2);
                                            v128 result32_3 = naivecomb_epu32(n32_3, k32_3);

                                            v128 result16_0 = cvt2x2epi32_epi16(result32_0, result32_1);
                                            v128 result16_1 = cvt2x2epi32_epi16(result32_2, result32_3);

                                            return cvt2x2epi16_epi8(result16_0, result16_1);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            switch (elements)
                            {
                                case 2:
                                {
                                    return unpacklo_epi8(cvtsi64x_si128(maxmath.comb((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), Promise.Unsafe0)),
                                                         cvtsi64x_si128(maxmath.comb((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), Promise.Unsafe0)));
                                }

                                case 3:
                                case 4:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi64_epi8(mm256_naivecomb_epu64(Avx2.mm256_cvtepu8_epi64(n), Avx2.mm256_cvtepu8_epi64(k), elements));
                                    }
                                    else
                                    {
                                        return new v128((byte)maxmath.comb((ulong)extract_epi8(n, 0), (ulong)extract_epi8(k, 0), Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 1), (ulong)extract_epi8(k, 1), Promise.Unsafe0),
                                                        (byte)maxmath.comb((ulong)extract_epi8(n, 2), (ulong)extract_epi8(k, 2), Promise.Unsafe0),
                                                        (byte)(elements == 4 ? maxmath.comb((ulong)extract_epi8(n, 3), (ulong)extract_epi8(k, 3), Promise.Unsafe0) : 0),
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0,
                                                        0);
                                    }
                                }

                                case 8:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        v256 n64Lo = Avx2.mm256_cvtepu8_epi64(n);
                                        v256 k64Lo = Avx2.mm256_cvtepu8_epi64(k);
                                        v256 n64Hi = Avx2.mm256_cvtepu8_epi64(bsrli_si128(n, 4 * sizeof(byte)));
                                        v256 k64Hi = Avx2.mm256_cvtepu8_epi64(bsrli_si128(k, 4 * sizeof(byte)));

                                        v128 lo = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n64Lo, k64Lo));
                                        v128 hi = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n64Hi, k64Hi));

                                        return unpacklo_epi32(lo, hi);
                                    }
                                    else
                                    {
                                        v128 _0_1 = naivecomb_epu64(cvtepu8_epi64(n), cvtepu8_epi64(k), true);
                                        v128 _2_3 = naivecomb_epu64(cvtepu8_epi64(bsrli_si128(n, 2 * sizeof(byte))), cvtepu8_epi64(bsrli_si128(k, 2 * sizeof(byte))), true);

                                        v128 _4 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 4), (ulong)extract_epi8(k, 4), Promise.Unsafe0));
                                        v128 _5 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 5), (ulong)extract_epi8(k, 5), Promise.Unsafe0));
                                        v128 _6 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 6), (ulong)extract_epi8(k, 6), Promise.Unsafe0));
                                        v128 _7 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 7), (ulong)extract_epi8(k, 7), Promise.Unsafe0));

                                        v128 _0_1_2_3 = unpacklo_epi16(cvtepi64_epi8(_0_1), cvtepi64_epi8(_2_3));
                                        v128 _4_5 = unpacklo_epi8(_4, _5);
                                        v128 _6_7 = unpacklo_epi8(_6, _7);
                                        v128 _4_5_6_7 = unpacklo_epi16(_4_5, _6_7);

                                        return unpacklo_epi32(_0_1_2_3, _4_5_6_7);
                                    }
                                }

                                default:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        v256 n0 = Avx2.mm256_cvtepu8_epi64(n);
                                        v256 k0 = Avx2.mm256_cvtepu8_epi64(k);
                                        v256 n1 = Avx2.mm256_cvtepu8_epi64(bsrli_si128(n,  4 * sizeof(byte)));
                                        v256 k1 = Avx2.mm256_cvtepu8_epi64(bsrli_si128(k,  4 * sizeof(byte)));
                                        v256 n2 = Avx2.mm256_cvtepu8_epi64(bsrli_si128(n,  8 * sizeof(byte)));
                                        v256 k2 = Avx2.mm256_cvtepu8_epi64(bsrli_si128(k,  8 * sizeof(byte)));
                                        v256 n3 = Avx2.mm256_cvtepu8_epi64(bsrli_si128(n, 12 * sizeof(byte)));
                                        v256 k3 = Avx2.mm256_cvtepu8_epi64(bsrli_si128(k, 12 * sizeof(byte)));

                                        v128 result0 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n0, k0));
                                        v128 result1 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n1, k1));
                                        v128 result2 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n2, k2));
                                        v128 result3 = mm256_cvtepi64_epi8(mm256_naivecomb_epu64(n3, k3));

                                        return unpacklo_epi64(unpacklo_epi32(result0, result1), unpacklo_epi32(result2, result3));
                                    }
                                    else
                                    {
                                        v128 _0_1 = naivecomb_epu64(cvtepu8_epi64(n), cvtepu8_epi64(k), true);
                                        v128 _2_3 = naivecomb_epu64(cvtepu8_epi64(bsrli_si128(n, 2 * sizeof(byte))), cvtepu8_epi64(bsrli_si128(k, 2 * sizeof(byte))), true);
                                        v128 _4_5 = naivecomb_epu64(cvtepu8_epi64(bsrli_si128(n, 4 * sizeof(byte))), cvtepu8_epi64(bsrli_si128(k, 4 * sizeof(byte))), true);
                                        v128 _6_7 = naivecomb_epu64(cvtepu8_epi64(bsrli_si128(n, 6 * sizeof(byte))), cvtepu8_epi64(bsrli_si128(k, 6 * sizeof(byte))), true);

                                        v128 _8  = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 8),  (ulong)extract_epi8(k, 8),  Promise.Unsafe0));
                                        v128 _9  = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 9),  (ulong)extract_epi8(k, 9),  Promise.Unsafe0));
                                        v128 _10 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 10), (ulong)extract_epi8(k, 10), Promise.Unsafe0));
                                        v128 _11 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 11), (ulong)extract_epi8(k, 11), Promise.Unsafe0));
                                        v128 _12 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 12), (ulong)extract_epi8(k, 12), Promise.Unsafe0));
                                        v128 _13 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 13), (ulong)extract_epi8(k, 13), Promise.Unsafe0));
                                        v128 _14 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 14), (ulong)extract_epi8(k, 14), Promise.Unsafe0));
                                        v128 _15 = cvtsi32_si128((byte)maxmath.comb((ulong)extract_epi8(n, 15), (ulong)extract_epi8(k, 15), Promise.Unsafe0));

                                        v128 _0_1_2_3 = unpacklo_epi16(cvtepi64_epi8(_0_1), cvtepi64_epi8(_2_3));
                                        v128 _4_5_6_7 = unpacklo_epi16(cvtepi64_epi8(_4_5), cvtepi64_epi8(_6_7));
                                        v128 lo = unpacklo_epi32(_0_1_2_3, _4_5_6_7);

                                        v128 _8_9   = unpacklo_epi8( _8,  _9);
                                        v128 _10_11 = unpacklo_epi8(_10, _11);
                                        v128 _12_13 = unpacklo_epi8(_12, _13);
                                        v128 _14_15 = unpacklo_epi8(_14, _15);
                                        v128 _8_9_10_11 = unpacklo_epi16(_8_9, _10_11);
                                        v128 _12_13_14_15 = unpacklo_epi16(_12_13, _14_15);
                                        v128 hi = unpacklo_epi32(_8_9_10_11, _12_13_14_15);

                                        return unpacklo_epi64(lo, hi);
                                    }
                                }
                            }
                        }
                    }


                    // ARM has native mullo_epi8, X86 does not
                    if (Sse2.IsSse2Supported)
                    {
                        if (elements <= 8)
                        {
                            return cvtepi16_epi8(castcomb_epu16(cvtepu8_epi16(n), cvtepu8_epi16(k), elements: elements), elements);
                        }
                        else if (Avx2.IsAvx2Supported)
                        {
                            return mm256_cvtepi16_epi8(mm256_castcomb_epu16(Avx2.mm256_cvtepu8_epi16(n), Avx2.mm256_cvtepu8_epi16(k)));
                        }
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU8(n, byte.MaxValue);
                    Divider<byte16> loopDivider = new Divider<byte16>(new byte16(9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24), Divider<byte16>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep8(ref n, ref k, out v128 results, out v128 i, out v128 c);

                    v128 cmp;

                    while (CMP_EPI ? notallfalse_epi128<byte>(cmp = cmpgt_epi8(k, i))
                                   : notalltrue_epi128<byte>(cmp = cmple_epu8(k, i)))
                    {
                        LOOP_comb_ep8(ref n, ref i, ref c, ref results, ref loopDivider, ref indexCurrentDivider, cmp, CMP_EPI, nextDividerTest: true);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void comb_ep8x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed, byte unsafeLevels = 0)
            {
                static bool ContinueLoop(v128 k0, v128 k1, v128 i, [NoAlias] ref v128 cmp0, [NoAlias] ref v128 cmp1, bool CMP_EPI)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (CMP_EPI)
                        {
                            cmp0 = cmpgt_epi8(k0, i);
                            cmp1 = cmpgt_epi8(k1, i);

                            return notallfalse_epi128<byte>(or_si128(cmp0, cmp1));
                        }
                        else
                        {
                            cmp0 = cmple_epu8(k0, i);
                            cmp1 = cmple_epu8(k1, i);

                            return notalltrue_epi128<byte>(and_si128(cmp0, cmp1));
                        }
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<byte16, byte>(k0, n0, 16);
VectorAssert.IsNotGreater<byte16, byte>(k1, n1, 16);

                    if (unsafeLevels > 0 || (constexpr.ALL_LE_EPU8(n0, MAX_INVERSE_FACTORIAL_U64) && constexpr.ALL_LE_EPU8(n1, MAX_INVERSE_FACTORIAL_U64)))
                    {
                        r0 = comb_ep8(n0, k0, signed, unsafeLevels);
                        r1 = comb_ep8(n1, k1, signed, unsafeLevels);

                        return;
                    }

                    bool CMP_EPI = signed || (constexpr.ALL_LT_EPU8(n0, byte.MaxValue) && constexpr.ALL_LT_EPU8(n1, byte.MaxValue));
                    Divider<byte16> loopDivider = new Divider<byte16>(new byte16(9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24), Divider<byte16>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep8(ref n0, ref k0, out r0, out v128 i, out v128 c0);
                    PRELOOP_comb_ep8(ref n1, ref k1, out r1, out _,      out v128 c1);

                    v128 cmp0 = Uninitialized<byte16>.Create();
                    v128 cmp1 = Uninitialized<byte16>.Create();

                    while (ContinueLoop(k0, k1, i, ref cmp0, ref cmp1, CMP_EPI))
                    {
                        LOOP_comb_ep8(ref n0, ref i, ref c0, ref r0, ref loopDivider, ref indexCurrentDivider, cmp0, CMP_EPI, nextDividerTest: false);
                        LOOP_comb_ep8(ref n1, ref i, ref c1, ref r1, ref loopDivider, ref indexCurrentDivider, cmp1, CMP_EPI, nextDividerTest: true);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_comb_ep16([NoAlias] ref v128 n, [NoAlias] ref v128 k, [NoAlias] out v128 results, [NoAlias] out v128 i, [NoAlias] out v128 c)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi16(1);

                    v128 cmp;
                    i = ONE;
                    c = n;
                    k = min_epu16(k, sub_epi16(n, k));
                    results = blendv_si128(c, ONE, cmpeq_epi16(k, setzero_si128()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = add_epi16(mullo_epi16(constdiv_epu16(c, 2), n), and_si128(neg_epi16(constrem_epu16(c, 2)), constdiv_epu16(n, 2)));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        v128 rem3 = constrem_epu16(c, 3);
                        v128 rem3is1orMore = cmpgt_epi16(rem3, setzero_si128());
                        v128 rem3is2orMore = cmpgt_epi16(rem3, ONE);
                        v128 mulrem3 = add_epi16(and_si128(rem3is1orMore, n), and_si128(rem3is2orMore, n));
                        c = add_epi16(mullo_epi16(constdiv_epu16(c, 3), n), constdiv_epu16(mulrem3, 3));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = add_epi16(mullo_epi16(constdiv_epu16(c, 4), n), constdiv_epu16(mullo_epi16(constrem_epu16(c, 4), n), 4));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = add_epi16(mullo_epi16(constdiv_epu16(c, 5), n), constdiv_epu16(mullo_epi16(constrem_epu16(c, 5), n), 5));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = add_epi16(mullo_epi16(constdiv_epu16(c, 6), n), constdiv_epu16(mullo_epi16(constrem_epu16(c, 6), n), 6));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = add_epi16(mullo_epi16(constdiv_epu16(c, 7), n), constdiv_epu16(mullo_epi16(constrem_epu16(c, 7), n), 7));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi16(k, i);
                        i = add_epi16(i, ONE);
                        n = sub_epi16(n, ONE);
                        c = add_epi16(mullo_epi16(constdiv_epu16(c, 8), n), constdiv_epu16(mullo_epi16(constrem_epu16(c, 8), n), 8));
                        results = blendv_si128(results, c, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_comb_ep16([NoAlias] ref v128 n, [NoAlias] ref v128 i, [NoAlias] ref v128 c, [NoAlias] ref v128 results, [NoAlias] ref Divider<ushort8> loopDivider, [NoAlias] ref int indexCurrentDivider, v128 cmp, bool CMP_EPI, bool nextDividerTest, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi16(1);

                    i = add_epi16(i, ONE);
                    n = sub_epi16(n, ONE);

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v128 q = divrem_epu16(c, i, out v128 r, elements);
                        c = add_epi16(mullo_epi16(q, n), div_epu16(mullo_epi16(r, n), i, elements));
                    }
                    else
                    {
                        Divider<ushort> currentDivider = loopDivider.GetInnerDivider<ushort>(indexCurrentDivider);
                        if (elements <= 4)
                        {
                            v128 q = currentDivider.DivRem(c, out ushort4 r);
                            c = add_epi16(mullo_epi16(q, n), (ushort4)(r * n) / currentDivider);
                        }
                        else
                        {
                            v128 q = currentDivider.DivRem(c, out ushort8 r);
                            c = add_epi16(mullo_epi16(q, n), (ushort8)(r * n) / currentDivider);
                        }

                        if (nextDividerTest)
                        {
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }
                    }

                    if (!nextDividerTest)
                    {
                        i = sub_epi16(i, ONE);
                    }

                    if (CMP_EPI)
                    {
                        results = blendv_si128(results, c, cmp);
                    }
                    else
                    {
                        if (Sse4_1.IsSse41Supported)
                        {
                            results = blendv_si128(c, results, cmp);
                        }
                        else
                        {
                            results = blendv_si128(results, c, cmp);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 comb_ep16(v128 n, v128 k, bool signed, byte unsafeLevels = 0, byte elements = 8)
            {
                static bool ContinueLoop(v128 k, v128 i, ref v128 cmp, bool CMP_EPI, byte elements)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (CMP_EPI)
                        {
                            return notallfalse_epi128<ushort>(cmp = cmpgt_epi16(k, i), elements);
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                return notalltrue_epi128<ushort>(cmp = cmple_epu16(k, i, elements), elements);
                            }
                            else
                            {
                                return notallfalse_epi128<ushort>(cmp = cmpgt_epu16(k, i, elements), elements);
                            }
                        }
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<ushort8, ushort>(k, n, elements);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U16, elements))
                            {
                                return naivecomb_epu16(n, k, unsafeLevels > 3 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8, elements), elements);
                            }
                            else
                            {
                                if (elements <= 4)
                                {
                                    return cvtepi32_epi16(naivecomb_epu32(cvtepu16_epi32(n), cvtepu16_epi32(k), elements), elements);
                                }
                                else
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi32_epi16(mm256_naivecomb_epu32(Avx2.mm256_cvtepu16_epi32(n), Avx2.mm256_cvtepu16_epi32(k)));
                                    }
                                    else
                                    {
                                        v128 nLo32 = cvt2x2epu16_epi32(n, out v128 nHi32);
                                        v128 kLo32 = cvt2x2epu16_epi32(k, out v128 kHi32);

                                        return cvt2x2epi32_epi16(naivecomb_epu32(nLo32, kLo32), naivecomb_epu32(nHi32, kHi32));
                                    }
                                }
                            }
                        }
                        else
                        {
                            switch (elements)
                            {
                                case 2:
                                {
                                    return unpacklo_epi16(cvtsi32_si128((int)maxmath.comb((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), Promise.Unsafe0)),
                                                          cvtsi32_si128((int)maxmath.comb((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), Promise.Unsafe0)));
                                }

                                case 3:
                                case 4:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        return mm256_cvtepi64_epi16(mm256_naivecomb_epu64(Avx2.mm256_cvtepu16_epi64(n), Avx2.mm256_cvtepu16_epi64(k), elements));
                                    }
                                    else
                                    {
                                        return new v128((ushort)maxmath.comb((ulong)extract_epi16(n, 0), (ulong)extract_epi16(k, 0), Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 1), (ulong)extract_epi16(k, 1), Promise.Unsafe0),
                                                        (ushort)maxmath.comb((ulong)extract_epi16(n, 2), (ulong)extract_epi16(k, 2), Promise.Unsafe0),
                                                        (ushort)(elements == 4 ? maxmath.comb((ulong)extract_epi16(n, 3), (ulong)extract_epi16(k, 3), Promise.Unsafe0) : 0),
                                                        0,
                                                        0,
                                                        0,
                                                        0);
                                    }
                                }

                                default:
                                {
                                    if (Avx2.IsAvx2Supported)
                                    {
                                        v256 n64Lo = Avx2.mm256_cvtepu16_epi64(n);
                                        v256 k64Lo = Avx2.mm256_cvtepu16_epi64(k);
                                        v256 n64Hi = Avx2.mm256_cvtepu16_epi64(bsrli_si128(n, 4 * sizeof(ushort)));
                                        v256 k64Hi = Avx2.mm256_cvtepu16_epi64(bsrli_si128(k, 4 * sizeof(ushort)));

                                        v128 result64Lo = mm256_cvtepi64_epi16(mm256_naivecomb_epu64(n64Lo, k64Lo));
                                        v128 result64Hi = mm256_cvtepi64_epi16(mm256_naivecomb_epu64(n64Hi, k64Hi));

                                        return unpacklo_epi64(result64Lo, result64Hi);
                                    }
                                    else
                                    {
                                        v128 _0_1 = naivecomb_epu64(cvtepu16_epi64(n), cvtepu16_epi64(k), true);
                                        v128 _2_3 = naivecomb_epu64(cvtepu16_epi64(bsrli_si128(n, 2 * sizeof(ushort))), cvtepu16_epi64(bsrli_si128(k, 2 * sizeof(ushort))), true);

                                        v128 _4 = cvtsi32_si128((ushort)maxmath.comb((ulong)extract_epi16(n, 4), (ulong)extract_epi16(k, 4), Promise.Unsafe0));
                                        v128 _5 = cvtsi32_si128((ushort)maxmath.comb((ulong)extract_epi16(n, 5), (ulong)extract_epi16(k, 5), Promise.Unsafe0));
                                        v128 _6 = cvtsi32_si128((ushort)maxmath.comb((ulong)extract_epi16(n, 6), (ulong)extract_epi16(k, 6), Promise.Unsafe0));
                                        v128 _7 = cvtsi32_si128((ushort)maxmath.comb((ulong)extract_epi16(n, 7), (ulong)extract_epi16(k, 7), Promise.Unsafe0));

                                        v128 _0_1_2_3 = unpacklo_epi32(cvtepi64_epi16(_0_1), cvtepi64_epi16(_2_3));
                                        v128 _4_5 = unpacklo_epi16(_4, _5);
                                        v128 _6_7 = unpacklo_epi16(_6, _7);
                                        v128 _4_5_6_7 = unpacklo_epi32(_4_5, _6_7);

                                        return unpacklo_epi64(_0_1_2_3, _4_5_6_7);
                                    }
                                }
                            }
                        }
                    }
                    if (elements <= 4)
                    {
                        return cvtepi32_epi16(castcomb_epu32(cvtepu16_epi32(n), cvtepu16_epi32(k), elements), elements);
                    }
                    if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi32_epi16(mm256_castcomb_epu32(Avx2.mm256_cvtepu16_epi32(n), Avx2.mm256_cvtepu16_epi32(k)));
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU16(n, ushort.MaxValue);
                    Divider<ushort8> loopDivider = new Divider<ushort8>(new ushort8(9, 10, 11, 12, 13, 14, 15, 16), Divider<ushort8>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep16(ref n, ref k, out v128 results, out v128 i, out v128 c);

                    v128 cmp = Uninitialized<ushort8>.Create();

                    while (ContinueLoop(k, i, ref cmp, CMP_EPI, elements))
                    {
                        LOOP_comb_ep16(ref n, ref i, ref c, ref results, ref loopDivider, ref indexCurrentDivider, cmp, CMP_EPI, true, elements);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void comb_ep16x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed, byte unsafeLevels = 0)
            {
                static bool ContinueLoop(v128 k0, v128 k1, v128 i, [NoAlias] ref v128 cmp0, [NoAlias] ref v128 cmp1, bool CMP_EPI)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (CMP_EPI)
                        {
                            cmp0 = cmpgt_epi16(k0, i);
                            cmp1 = cmpgt_epi16(k1, i);

                            return notallfalse_epi128<ushort>(or_si128(cmp0, cmp1));
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                cmp0 = cmple_epu16(k0, i);
                                cmp1 = cmple_epu16(k1, i);

                                return notalltrue_epi128<ushort>(and_si128(cmp0, cmp1));
                            }
                            else
                            {
                                cmp0 = cmpgt_epu16(k0, i);
                                cmp1 = cmpgt_epu16(k1, i);

                                return notallfalse_epi128<ushort>(or_si128(cmp0, cmp1));
                            }
                        }
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<ushort8, ushort>(k0, n0, 8);
VectorAssert.IsNotGreater<ushort8, ushort>(k1, n1, 8);

                    if (unsafeLevels > 0 || (constexpr.ALL_LE_EPU16(n0, MAX_INVERSE_FACTORIAL_U64) && constexpr.ALL_LE_EPU16(n1, MAX_INVERSE_FACTORIAL_U64)))
                    {
                        r0 = comb_ep16(n0, k0, signed, unsafeLevels);
                        r1 = comb_ep16(n1, k1, signed, unsafeLevels);

                        return;
                    }

                    bool CMP_EPI = signed || (constexpr.ALL_LT_EPU16(n0, ushort.MaxValue) && constexpr.ALL_LT_EPU16(n1, ushort.MaxValue));
                    Divider<ushort8> loopDivider = new Divider<ushort8>(new ushort8(9, 10, 11, 12, 13, 14, 15, 16), Divider<ushort8>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep16(ref n0, ref k0, out r0, out v128 i, out v128 c0);
                    PRELOOP_comb_ep16(ref n1, ref k1, out r1, out _,      out v128 c1);

                    v128 cmp0 = Uninitialized<ushort8>.Create();
                    v128 cmp1 = Uninitialized<ushort8>.Create();

                    while (ContinueLoop(k0, k1, i, ref cmp0, ref cmp1, CMP_EPI))
                    {
                        LOOP_comb_ep16(ref n0, ref i, ref c0, ref r0, ref loopDivider, ref indexCurrentDivider, cmp0, CMP_EPI, nextDividerTest: false);
                        LOOP_comb_ep16(ref n1, ref i, ref c1, ref r1, ref loopDivider, ref indexCurrentDivider, cmp1, CMP_EPI, nextDividerTest: true);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_comb_ep32([NoAlias] ref v128 n, [NoAlias] ref v128 k, [NoAlias] out v128 results, [NoAlias] out v128 i, [NoAlias] out v128 c, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi32(1);

                    i = ONE;
                    c = n;
                    k = constexpr.ALL_LE_EPU32(n, (uint)int.MaxValue)
                      ? min_epi32(k, sub_epi32(n, k))
                      : min_epu32(k, sub_epi32(n, k));

                    results = blendv_si128(c, ONE, cmpeq_epi32(k, setzero_si128()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = add_epi32(mullo_epi32(constdiv_epu32(c, 2, elements), n, elements), and_si128(neg_epi32(constrem_epu32(c, 2, elements)), constdiv_epu32(n, 2, elements)));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        v128 rem3 = constrem_epu32(c, 3);
                        v128 rem3is1orMore = cmpgt_epi32(rem3, setzero_si128());
                        v128 rem3is2orMore = cmpgt_epi32(rem3, ONE);
                        v128 mulrem3 = add_epi32(and_si128(rem3is1orMore, n), and_si128(rem3is2orMore, n));
                        c = add_epi32(mullo_epi32(constdiv_epu32(c, 3), n), constdiv_epu32(mulrem3, 3));
                        results = blendv_si128(results, c, cmp);

                        if (BurstArchitecture.IsMul32Supported)
                        {
                            cmp = cmpgt_epi32(k, i);
                            i = add_epi32(i, ONE);
                            n = sub_epi32(n, ONE);
                            c = add_epi32(mullo_epi32(constdiv_epu32(c, 4, elements), n, elements), constdiv_epu32(mullo_epi32(constrem_epu32(c, 4, elements), n, elements), 4));
                            results = blendv_si128(results, c, cmp);

                            cmp = cmpgt_epi32(k, i);
                            i = add_epi32(i, ONE);
                            n = sub_epi32(n, ONE);
                            c = add_epi32(mullo_epi32(constdiv_epu32(c, 5, elements), n, elements), constdiv_epu32(mullo_epi32(constrem_epu32(c, 5, elements), n, elements), 5));
                            results = blendv_si128(results, c, cmp);

                            cmp = cmpgt_epi32(k, i);
                            i = add_epi32(i, ONE);
                            n = sub_epi32(n, ONE);
                            c = add_epi32(mullo_epi32(constdiv_epu32(c, 6, elements), n, elements), constdiv_epu32(mullo_epi32(constrem_epu32(c, 6, elements), n, elements), 6));
                            results = blendv_si128(results, c, cmp);

                            cmp = cmpgt_epi32(k, i);
                            i = add_epi32(i, ONE);
                            n = sub_epi32(n, ONE);
                            c = add_epi32(mullo_epi32(constdiv_epu32(c, 7, elements), n, elements), constdiv_epu32(mullo_epi32(constrem_epu32(c, 7, elements), n, elements), 7));
                            results = blendv_si128(results, c, cmp);
                        }
                        else
                        {
                            cmp = cmpgt_epi32(k, i);
                            i = add_epi32(i, ONE);
                            n = sub_epi32(n, ONE);
                            v128 rem4 = constrem_epu32(c, 4);
                            v128 rem4is1orMore = cmpgt_epi32(rem4, setzero_si128());
                            v128 rem4is2orMore = cmpgt_epi32(rem4, ONE);
                            v128 rem4is3orMore = cmpgt_epi32(rem4, set1_epi32(2));
                            v128 mulrem4 = add_epi32(and_si128(rem4is1orMore, n), add_epi32(and_si128(rem4is2orMore, n), and_si128(rem4is3orMore, n)));
                            c = add_epi32(mullo_epi32(constdiv_epu32(c, 4), n), constdiv_epu32(mulrem4, 4));
                            results = blendv_si128(results, c, cmp);

                            cmp = cmpgt_epi32(k, i);
                            i = add_epi32(i, ONE);
                            n = sub_epi32(n, ONE);
                            v128 rem5 = constrem_epu32(c, 5);
                            v128 rem5is1orMore = cmpgt_epi32(rem5, setzero_si128());
                            v128 rem5is2orMore = cmpgt_epi32(rem5, ONE);
                            v128 rem5is3orMore = cmpgt_epi32(rem5, set1_epi32(2));
                            v128 rem5is4orMore = cmpgt_epi32(rem5, set1_epi32(3));
                            v128 mulrem5 = add_epi32(add_epi32(and_si128(rem5is1orMore, n), and_si128(rem5is2orMore, n)), add_epi32(and_si128(rem5is3orMore, n), and_si128(rem5is4orMore, n)));
                            c = add_epi32(mullo_epi32(constdiv_epu32(c, 5), n), constdiv_epu32(mulrem5, 5));
                            results = blendv_si128(results, c, cmp);

                            if (elements > 2)
                            {
                                cmp = cmpgt_epi32(k, i);
                                i = add_epi32(i, ONE);
                                n = sub_epi32(n, ONE);
                                v128 rem6 = constrem_epu32(c, 6);
                                v128 rem6is1orMore = cmpgt_epi32(rem6, setzero_si128());
                                v128 rem6is2orMore = cmpgt_epi32(rem6, ONE);
                                v128 rem6is3orMore = cmpgt_epi32(rem6, set1_epi32(2));
                                v128 rem6is4orMore = cmpgt_epi32(rem6, set1_epi32(3));
                                v128 rem6is5orMore = cmpgt_epi32(rem6, set1_epi32(4));
                                v128 mulrem6 = add_epi32(add_epi32(add_epi32(and_si128(rem6is1orMore, n), and_si128(rem6is2orMore, n)), add_epi32(and_si128(rem6is3orMore, n), and_si128(rem6is4orMore, n))), and_si128(rem6is5orMore, n));
                                c = add_epi32(mullo_epi32(constdiv_epu32(c, 6), n), constdiv_epu32(mulrem6, 6));
                                results = blendv_si128(results, c, cmp);

                                cmp = cmpgt_epi32(k, i);
                                i = add_epi32(i, ONE);
                                n = sub_epi32(n, ONE);
                                v128 rem7 = constrem_epu32(c, 7);
                                v128 rem7is1orMore = cmpgt_epi32(rem7, setzero_si128());
                                v128 rem7is2orMore = cmpgt_epi32(rem7, ONE);
                                v128 rem7is3orMore = cmpgt_epi32(rem7, set1_epi32(2));
                                v128 rem7is4orMore = cmpgt_epi32(rem7, set1_epi32(3));
                                v128 rem7is5orMore = cmpgt_epi32(rem7, set1_epi32(4));
                                v128 rem7is6orMore = cmpgt_epi32(rem7, set1_epi32(5));
                                v128 mulrem7 = add_epi32(add_epi32(add_epi32(and_si128(rem7is1orMore, n), and_si128(rem7is2orMore, n)), add_epi32(and_si128(rem7is3orMore, n), and_si128(rem7is4orMore, n))), add_epi32(and_si128(rem7is5orMore, n), and_si128(rem7is6orMore, n)));
                                c = add_epi32(mullo_epi32(constdiv_epu32(c, 7), n), constdiv_epu32(mulrem7, 7));
                                results = blendv_si128(results, c, cmp);
                            }
                            else
                            {
                                cmp = cmpgt_epi32(k, i);
                                i = add_epi32(i, ONE);
                                n = sub_epi32(n, ONE);
                                c = add_epi32(mullo_epi32(constdiv_epu32(c, 6, elements), n, elements), constdiv_epu32(mullo_epi32(constrem_epu32(c, 6, elements), n, elements), 6));
                                results = blendv_si128(results, c, cmp);

                                cmp = cmpgt_epi32(k, i);
                                i = add_epi32(i, ONE);
                                n = sub_epi32(n, ONE);
                                c = add_epi32(mullo_epi32(constdiv_epu32(c, 7, elements), n, elements), constdiv_epu32(mullo_epi32(constrem_epu32(c, 7, elements), n, elements), 7));
                                results = blendv_si128(results, c, cmp);
                            }
                        }

                        cmp = cmpgt_epi32(k, i);
                        i = add_epi32(i, ONE);
                        n = sub_epi32(n, ONE);
                        c = add_epi32(mullo_epi32(constdiv_epu32(c, 8, elements), n, elements), constdiv_epu32(mullo_epi32(constrem_epu32(c, 8, elements), n, elements), 8));
                        results = blendv_si128(results, c, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_comb_ep32([NoAlias] ref v128 n, [NoAlias] ref v128 i, [NoAlias] ref v128 c, [NoAlias] ref v128 results, [NoAlias] ref Divider<uint4> loopDividerSSE, [NoAlias] ref Divider<uint8> loopDividerAVX, [NoAlias] ref int indexCurrentDivider, v128 cmp, bool CMP_EPI, bool nextDividerTest, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi32(1);

                    i = add_epi32(i, ONE);
                    n = sub_epi32(n, ONE);

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v128 q = divrem_epu32(c, i, out v128 r, elements);
                        c = add_epi32(mullo_epi32(q, n, elements), div_epu32(mullo_epi32(r, n, elements), i, elements));
                    }
                    else
                    {
                        Divider<uint> currentDivider;
                        if (Avx2.IsAvx2Supported)
                        {
                            currentDivider = loopDividerAVX.GetInnerDivider<uint>(indexCurrentDivider);

                            if (nextDividerTest)
                            {
                                next_comb_divider(ref loopDividerAVX, ref indexCurrentDivider);
                            }
                        }
                        else
                        {
                            currentDivider = loopDividerSSE.GetInnerDivider<uint>(indexCurrentDivider);

                            if (nextDividerTest)
                            {
                                next_comb_divider(ref loopDividerSSE, ref indexCurrentDivider);
                            }
                        }
                        if (elements == 2)
                        {
                            uint2 q = currentDivider.DivRem(RegisterConversion.ToUInt2(c), out uint2 r);
                            c = add_epi32(mullo_epi32(RegisterConversion.ToV128(q), n, 2), RegisterConversion.ToV128(RegisterConversion.ToUInt2(mullo_epi32(RegisterConversion.ToV128(r), n, 2)) / currentDivider));
                        }
                        else if (elements == 3)
                        {
                            uint3 q = currentDivider.DivRem(RegisterConversion.ToUInt3(c), out uint3 r);
                            c = add_epi32(mullo_epi32(RegisterConversion.ToV128(q), n, 3), RegisterConversion.ToV128(RegisterConversion.ToUInt3(mullo_epi32(RegisterConversion.ToV128(r), n, 3)) / currentDivider));
                        }
                        else
                        {
                            uint4 q = currentDivider.DivRem(RegisterConversion.ToUInt4(c), out uint4 r);
                            c = add_epi32(mullo_epi32(RegisterConversion.ToV128(q), n, 4), RegisterConversion.ToV128(RegisterConversion.ToUInt4(mullo_epi32(RegisterConversion.ToV128(r), n, 4)) / currentDivider));
                        }
                    }

                    if (!nextDividerTest)
                    {
                        i = sub_epi32(i, ONE);
                    }

                    if (CMP_EPI)
                    {
                        results = blendv_si128(results, c, cmp);
                    }
                    else
                    {
                        if (Sse4_1.IsSse41Supported)
                        {
                            results = blendv_si128(c, results, cmp);
                        }
                        else
                        {
                            results = blendv_si128(results, c, cmp);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 comb_ep32(v128 n, v128 k, bool signed, byte unsafeLevels = 0, byte elements = 4)
            {
                static bool ContinueLoop(v128 k, v128 i, ref v128 cmp, bool CMP_EPI, byte elements)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (CMP_EPI)
                        {
                            return notallfalse_epi128<uint>(cmp = cmpgt_epi32(k, i), elements);
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                return notalltrue_epi128<uint>(cmp = cmple_epu32(k, i, elements), elements);
                            }
                            else
                            {
                                return notallfalse_epi128<uint>(cmp = cmpgt_epu32(k, i, elements), elements);
                            }
                        }
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<uint4, uint>(RegisterConversion.ToUInt4(k), RegisterConversion.ToUInt4(n), elements);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U64, elements))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U32, elements))
                        {
                            return naivecomb_epu32(n, k, elements);
                        }
                        else
                        {
                            if (elements > 2)
                            {
                                if (Avx2.IsAvx2Supported)
                                {
                                    return mm256_cvtepi64_epi32(mm256_naivecomb_epu64(Avx2.mm256_cvtepu32_epi64(n), Avx2.mm256_cvtepu32_epi64(k), elements));
                                }
                                else
                                {
                                    v128 lo = unpacklo_epi32(cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 0), (ulong)extract_epi32(k, 0), Promise.Unsafe0)),
                                                             cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 1), (ulong)extract_epi32(k, 1), Promise.Unsafe0)));
                                    v128 hi = cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 2), (ulong)extract_epi32(k, 2), Promise.Unsafe0));

                                    if (elements == 4)
                                    {
                                        hi = unpacklo_epi32(hi, cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 3), (ulong)extract_epi32(k, 3), Promise.Unsafe0)));
                                    }

                                    return unpacklo_epi64(lo, hi);
                                }
                            }
                            else
                            {
                                return unpacklo_epi32(cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 0), (ulong)extract_epi32(k, 0), Promise.Unsafe0)),
                                                      cvtsi32_si128((int)maxmath.comb((ulong)extract_epi32(n, 1), (ulong)extract_epi32(k, 1), Promise.Unsafe0)));
                            }
                        }
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU32(n, uint.MaxValue);
                    Divider<uint4> loopDividerSSE = new Divider<uint4>(new uint4(9, 10, 11, 12), Divider<uint4>.WELL_KNOWN_COMB_PROMISES);
                    Divider<uint8> loopDividerAVX = new Divider<uint8>(loopDividerSSE, new Divider<uint4>(new uint4(13, 14, 15, 16), Divider<uint4>.WELL_KNOWN_COMB_PROMISES));
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep32(ref n, ref k, out v128 results, out v128 i, out v128 c, elements);

                    v128 cmp = Uninitialized<ulong2>.Create();

                    while (ContinueLoop(k, i, ref cmp, CMP_EPI, elements))
                    {
                        LOOP_comb_ep32(ref n, ref i, ref c, ref results, ref loopDividerSSE, ref loopDividerAVX, ref indexCurrentDivider, cmp, CMP_EPI, true, elements);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void comb_ep32x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed, byte unsafeLevels = 0)
            {
                static bool ContinueLoop(v128 k0, v128 k1, v128 i, [NoAlias] ref v128 cmp0, [NoAlias] ref v128 cmp1, bool CMP_EPI)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (CMP_EPI)
                        {
                            cmp0 = cmpgt_epi32(k0, i);
                            cmp1 = cmpgt_epi32(k1, i);

                            return notallfalse_epi128<uint>(or_si128(cmp0, cmp1));
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                cmp0 = cmple_epu32(k0, i);
                                cmp1 = cmple_epu32(k1, i);

                                return notalltrue_epi128<uint>(and_si128(cmp0, cmp1));
                            }
                            else
                            {
                                cmp0 = cmpgt_epu32(k0, i);
                                cmp1 = cmpgt_epu32(k1, i);

                                return notallfalse_epi128<uint>(or_si128(cmp0, cmp1));
                            }
                        }
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<uint4, uint>(RegisterConversion.ToUInt4(k0), RegisterConversion.ToUInt4(n0), 4);
VectorAssert.IsNotGreater<uint4, uint>(RegisterConversion.ToUInt4(k1), RegisterConversion.ToUInt4(n1), 4);

                    if (unsafeLevels > 0 || (constexpr.ALL_LE_EPU32(n0, MAX_INVERSE_FACTORIAL_U64) && constexpr.ALL_LE_EPU32(n1, MAX_INVERSE_FACTORIAL_U64)))
                    {
                        r0 = comb_ep32(n0, k0, signed, unsafeLevels);
                        r1 = comb_ep32(n1, k1, signed, unsafeLevels);

                        return;
                    }

                    bool CMP_EPI = signed || (constexpr.ALL_LT_EPU32(n0, uint.MaxValue) && constexpr.ALL_LT_EPU32(n1, uint.MaxValue));
                    Divider<uint4> loopDividerSSE = new Divider<uint4>(new uint4(9, 10, 11, 12), Divider<uint4>.WELL_KNOWN_COMB_PROMISES);
                    Divider<uint8> loopDividerAVX = new Divider<uint8>(loopDividerSSE, new Divider<uint4>(new uint4(13, 14, 15, 16), Divider<uint4>.WELL_KNOWN_COMB_PROMISES));
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep32(ref n0, ref k0, out r0, out v128 i, out v128 c0);
                    PRELOOP_comb_ep32(ref n1, ref k1, out r1, out _,      out v128 c1);

                    v128 cmp0 = Uninitialized<ulong2>.Create();
                    v128 cmp1 = Uninitialized<ulong2>.Create();

                    while (ContinueLoop(k0, k1, i, ref cmp0, ref cmp1, CMP_EPI))
                    {
                        LOOP_comb_ep32(ref n0, ref i, ref c0, ref r0, ref loopDividerSSE, ref loopDividerAVX, ref indexCurrentDivider, cmp0, CMP_EPI, nextDividerTest: false);
                        LOOP_comb_ep32(ref n1, ref i, ref c1, ref r1, ref loopDividerSSE, ref loopDividerAVX, ref indexCurrentDivider, cmp1, CMP_EPI, nextDividerTest: true);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_comb_ep64([NoAlias] ref v128 n, [NoAlias] ref v128 k, [NoAlias] out v128 results, [NoAlias] out v128 i, [NoAlias] out v128 c, bool signed)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi64x(1);

                    i = ONE;
                    c = n;
                    k = signed || constexpr.ALL_LE_EPU64(n, (ulong)long.MaxValue)
                      ? min_epi64(k, sub_epi64(n, k))
                      : min_epu64(k, sub_epi64(n, k));

                    results = blendv_si128(c, ONE, cmpeq_epi64(k, setzero_si128()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        v128 cmp = cmpgt_epi64(k, i);
                        n = sub_epi64(n, ONE);
                        c = add_epi64(mullo_epi64(constdiv_epu64(c, 2), n), and_si128(neg_epi64(constrem_epu64(c, 2)), constdiv_epu64(n, 2)));
                        results = blendv_si128(results, c, cmp);

                        cmp = cmpgt_epi64(k, set1_epi64x(2));
                        n = sub_epi64(n, ONE);
                        v128 rem3 = constrem_epu64(c, 3);
                        v128 rem3is1orMore = shuffle_epi32(cmpgt_epi32(rem3, setzero_si128()), Sse.SHUFFLE(2, 2, 0, 0));
                        v128 rem3is2orMore = shuffle_epi32(cmpgt_epi32(rem3, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                        v128 mulrem3 = add_epi64(and_si128(rem3is1orMore, n), and_si128(rem3is2orMore, n));
                        c = add_epi64(mullo_epi64(constdiv_epu64(c, 3), n), constdiv_epu64(mulrem3, 3));
                        results = blendv_si128(results, c, cmp);

                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = cmpgt_epi64(k, i);
                        //    i = add_epi64(i, ONE);
                        //    n = sub_epi64(n, ONE);
                        //    c = add_epi64(mullo_epi64(constdiv_epu64(c, 4), n), constdiv_epu64(mullo_epi64(constrem_epu64(c, 4), n), 4));
                        //    results = blendv_si128(results, c, cmp);
                        //
                        //    cmp = cmpgt_epi64(k, i);
                        //    i = add_epi64(i, ONE);
                        //    n = sub_epi64(n, ONE);
                        //    c = add_epi64(mullo_epi64(constdiv_epu64(c, 5), n), constdiv_epu64(mullo_epi64(constrem_epu64(c, 5), n), 5));
                        //    results = blendv_si128(results, c, cmp);
                        //
                        //    cmp = cmpgt_epi64(k, i);
                        //    i = add_epi64(i, ONE);
                        //    n = sub_epi64(n, ONE);
                        //    c = add_epi64(mullo_epi64(constdiv_epu64(c, 6), n), constdiv_epu64(mullo_epi64(constrem_epu64(c, 6), n), 6));
                        //    results = blendv_si128(results, c, cmp);
                        //
                        //    cmp = cmpgt_epi64(k, i);
                        //    i = add_epi64(i, ONE);
                        //    n = sub_epi64(n, ONE);
                        //    c = add_epi64(mullo_epi64(constdiv_epu64(c, 7), n), constdiv_epu64(mullo_epi64(constrem_epu64(c, 7), n), 7));
                        //    results = blendv_si128(results, c, cmp);
                        //
                        //    cmp = cmpgt_epi64(k, i);
                        //    i = add_epi64(i, ONE);
                        //    n = sub_epi64(n, ONE);
                        //    c = add_epi64(mullo_epi64(constdiv_epu64(c, 8), n), constdiv_epu64(mullo_epi64(constrem_epu64(c, 8), n), 8));
                        //    results = blendv_si128(results, c, cmp);
                        //}
                        //else
                        //{
                              cmp = cmpgt_epi64(k, set1_epi64x(3));
                              n = sub_epi64(n, ONE);
                              v128 rem4 = constrem_epu64(c, 4);
                              v128 rem4is1orMore = shuffle_epi32(cmpgt_epi32(rem4, setzero_si128()), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem4is2orMore = shuffle_epi32(cmpgt_epi32(rem4, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem4is3orMore = shuffle_epi32(cmpgt_epi32(rem4, set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 mulrem4 = add_epi64(and_si128(rem4is1orMore, n), add_epi64(and_si128(rem4is2orMore, n), and_si128(rem4is3orMore, n)));
                              c = add_epi64(mullo_epi64(constdiv_epu64(c, 4), n), constdiv_epu64(mulrem4, 4));
                              results = blendv_si128(results, c, cmp);

                              cmp = cmpgt_epi64(k, set1_epi64x(4));
                              n = sub_epi64(n, ONE);
                              v128 rem5 = constrem_epu64(c, 5);
                              v128 rem5is1orMore = shuffle_epi32(cmpgt_epi32(rem5, setzero_si128()), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem5is2orMore = shuffle_epi32(cmpgt_epi32(rem5, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem5is3orMore = shuffle_epi32(cmpgt_epi32(rem5, set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem5is4orMore = shuffle_epi32(cmpgt_epi32(rem5, set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 mulrem5 = add_epi64(add_epi64(and_si128(rem5is1orMore, n), and_si128(rem5is2orMore, n)), add_epi64(and_si128(rem5is3orMore, n), and_si128(rem5is4orMore, n)));
                              c = add_epi64(mullo_epi64(constdiv_epu64(c, 5), n), constdiv_epu64(mulrem5, 5));
                              results = blendv_si128(results, c, cmp);

                              cmp = cmpgt_epi64(k, set1_epi64x(5));
                              n = sub_epi64(n, ONE);
                              v128 rem6 = constrem_epu64(c, 6);
                              v128 rem6is1orMore = shuffle_epi32(cmpgt_epi32(rem6, setzero_si128()), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem6is2orMore = shuffle_epi32(cmpgt_epi32(rem6, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem6is3orMore = shuffle_epi32(cmpgt_epi32(rem6, set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem6is4orMore = shuffle_epi32(cmpgt_epi32(rem6, set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem6is5orMore = shuffle_epi32(cmpgt_epi32(rem6, set1_epi64x(4)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 mulrem6 = add_epi64(add_epi64(add_epi64(and_si128(rem6is1orMore, n), and_si128(rem6is2orMore, n)), add_epi64(and_si128(rem6is3orMore, n), and_si128(rem6is4orMore, n))), and_si128(rem6is5orMore, n));
                              c = add_epi64(mullo_epi64(constdiv_epu64(c, 6), n), constdiv_epu64(mulrem6, 6));
                              results = blendv_si128(results, c, cmp);

                              cmp = cmpgt_epi64(k, set1_epi64x(6));
                              n = sub_epi64(n, ONE);
                              v128 rem7 = constrem_epu64(c, 7);
                              v128 rem7is1orMore = shuffle_epi32(cmpgt_epi32(rem7, setzero_si128()), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem7is2orMore = shuffle_epi32(cmpgt_epi32(rem7, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem7is3orMore = shuffle_epi32(cmpgt_epi32(rem7, set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem7is4orMore = shuffle_epi32(cmpgt_epi32(rem7, set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem7is5orMore = shuffle_epi32(cmpgt_epi32(rem7, set1_epi64x(4)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem7is6orMore = shuffle_epi32(cmpgt_epi32(rem7, set1_epi64x(5)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 mulrem7 = add_epi64(add_epi64(add_epi64(and_si128(rem7is1orMore, n), and_si128(rem7is2orMore, n)), add_epi64(and_si128(rem7is3orMore, n), and_si128(rem7is4orMore, n))), add_epi64(and_si128(rem7is5orMore, n), and_si128(rem7is6orMore, n)));
                              c = add_epi64(mullo_epi64(constdiv_epu64(c, 7), n), constdiv_epu64(mulrem7, 7));
                              results = blendv_si128(results, c, cmp);

                              i = set1_epi64x(7);
                              cmp = cmpgt_epi64(k, i);
                              i = add_epi64(i, ONE);
                              n = sub_epi64(n, ONE);
                              v128 rem8 = constrem_epu64(c, 8);
                              v128 rem8is1orMore = shuffle_epi32(cmpgt_epi32(rem8, setzero_si128()), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem8is2orMore = shuffle_epi32(cmpgt_epi32(rem8, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem8is3orMore = shuffle_epi32(cmpgt_epi32(rem8, set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem8is4orMore = shuffle_epi32(cmpgt_epi32(rem8, set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem8is5orMore = shuffle_epi32(cmpgt_epi32(rem8, set1_epi64x(4)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem8is6orMore = shuffle_epi32(cmpgt_epi32(rem8, set1_epi64x(5)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 rem8is7orMore = shuffle_epi32(cmpgt_epi32(rem8, set1_epi64x(6)), Sse.SHUFFLE(2, 2, 0, 0));
                              v128 mulrem8 = add_epi64(add_epi64(add_epi64(add_epi64(and_si128(rem8is1orMore, n), and_si128(rem8is2orMore, n)), add_epi64(and_si128(rem8is3orMore, n), and_si128(rem8is4orMore, n))), add_epi64(and_si128(rem8is5orMore, n), and_si128(rem8is6orMore, n))), and_si128(rem8is7orMore, n));
                              c = add_epi64(mullo_epi64(constdiv_epu64(c, 8), n), constdiv_epu64(mulrem8, 8));
                              results = blendv_si128(results, c, cmp);
                        //}
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_comb_ep64([NoAlias] ref v128 n, [NoAlias] ref v128 i, [NoAlias] ref v128 c, [NoAlias] ref v128 results, [NoAlias] ref Divider<ulong4> loopDividerAVX, [NoAlias] ref int indexCurrentDivider, v128 cmp, bool CMP_EPI, bool nextDividerTest)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi64x(1);

                    i = add_epi64(i, ONE);
                    n = sub_epi64(n, ONE);

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        v128 q = divrem_epu64(c, i, out v128 r, bLEu32max: true);
                        c = add_epi64(mullo_epi64(q, n), div_epu64(mullo_epi64(r, n), i, bLEu32max: true));
                    }
                    else
                    {
                        if (Avx2.IsAvx2Supported)
                        {
                            Divider<ulong> currentDivider = loopDividerAVX.GetInnerDivider<ulong>(indexCurrentDivider);
                            v128 q = currentDivider.DivRem(c, out ulong2 r);
                            c = add_epi64(mullo_epi64(q, n), (ulong2)mullo_epi64(r, n) / currentDivider);

                            if (nextDividerTest)
                            {
                                next_comb_divider(ref loopDividerAVX, ref indexCurrentDivider);
                            }
                        }
                        else
                        {
                            v128 q = divrem_epu64(c, i, out v128 r, bLEu32max: true);
                            c = add_epi64(mullo_epi64(q, n), div_epu64(mullo_epi64(r, n), i, bLEu32max: true));
                        }
                    }

                    if (!nextDividerTest)
                    {
                        i = sub_epi64(i, ONE);
                    }

                    results = blendv_si128(results, c, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 comb_ep64(v128 n, v128 k, bool signed, byte unsafeLevels = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<ulong2, ulong>(k, n, 2);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            v128 nFactorial  = gamma_epu64(n, true);
                            v128 kFactorial  = gamma_epu64(k, true);
                            v128 nkFactorial = gamma_epu64(sub_epi64(n, k), true);

                            return cvttpd_epu64(div_pd(usfcvtepu64_pd(nFactorial), usfcvtepu64_pd(mullo_epi64(kFactorial, nkFactorial))), nonZero: true);
                        }
                        else
                        {
                            return unpacklo_epi64(cvtsi64x_si128(maxmath.comb(extract_epi64(n, 0), extract_epi64(k, 0), Promise.Unsafe0)),
                                                  cvtsi64x_si128(maxmath.comb(extract_epi64(n, 1), extract_epi64(k, 1), Promise.Unsafe0)));
                        }
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU64(n, ulong.MaxValue);
                    Divider<ulong4> loopDividerAVX = new Divider<ulong4>(new ulong4(9, 10, 11, 12), Divider<ulong4>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep64(ref n, ref k, out v128 results, out v128 i, out v128 c, signed);

                    v128 cmp = Uninitialized<ulong2>.Create();

                    while (notallfalse_epi128<ulong>(cmp = CMP_EPI ? cmpgt_epi64(k, i)
                                                                   : cmpgt_epu64(k, i)))
                    {
                        LOOP_comb_ep64(ref n, ref i, ref c, ref results, ref loopDividerAVX, ref indexCurrentDivider, cmp, CMP_EPI, true);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void comb_ep64x2(v128 n0, v128 n1, v128 k0, v128 k1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool signed, byte unsafeLevels = 0)
            {
                static bool ContinueLoop(v128 k0, v128 k1, v128 i, [NoAlias] ref v128 cmp0, [NoAlias] ref v128 cmp1, bool CMP_EPI)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (CMP_EPI)
                        {
                            cmp0 = cmpgt_epi64(k0, i);
                            cmp1 = cmpgt_epi64(k1, i);
                        }
                        else
                        {
                            cmp0 = cmpgt_epu64(k0, i);
                            cmp1 = cmpgt_epu64(k1, i);
                        }

                        return notallfalse_epi128<uint>(or_si128(cmp0, cmp1));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
VectorAssert.IsNotGreater<ulong2, ulong>(k0, n0, 2);
VectorAssert.IsNotGreater<ulong2, ulong>(k1, n1, 2);

                    if (unsafeLevels > 0 || (constexpr.ALL_LE_EPU64(n0, MAX_INVERSE_FACTORIAL_U64) && constexpr.ALL_LE_EPU64(n1, MAX_INVERSE_FACTORIAL_U64)))
                    {
                        r0 = comb_ep64(n0, k0, signed, unsafeLevels);
                        r1 = comb_ep64(n1, k1, signed, unsafeLevels);

                        return;
                    }

                    bool CMP_EPI = signed || (constexpr.ALL_LT_EPU64(n0, ulong.MaxValue) && constexpr.ALL_LT_EPU64(n1, ulong.MaxValue));
                    Divider<ulong4> loopDividerAVX = new Divider<ulong4>(new ulong4(9, 10, 11, 12), Divider<ulong4>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    PRELOOP_comb_ep64(ref n0, ref k0, out r0, out v128 i, out v128 c0, signed);
                    PRELOOP_comb_ep64(ref n1, ref k1, out r1, out _,      out v128 c1, signed);

                    v128 cmp0 = Uninitialized<ulong2>.Create();
                    v128 cmp1 = Uninitialized<ulong2>.Create();

                    while (ContinueLoop(k0, k1, i, ref cmp0, ref cmp1, CMP_EPI))
                    {
                        LOOP_comb_ep64(ref n0, ref i, ref c0, ref r0, ref loopDividerAVX, ref indexCurrentDivider, cmp0, CMP_EPI, nextDividerTest: false);
                        LOOP_comb_ep64(ref n1, ref i, ref c1, ref r1, ref loopDividerAVX, ref indexCurrentDivider, cmp1, CMP_EPI, nextDividerTest: true);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_comb_ep8(v256 n, v256 k, bool signed, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotGreater<byte32, byte>(k, n, 32);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U16))
                            {
                                if (unsafeLevels > 3 || constexpr.ALL_LE_EPU8(n, MAX_INVERSE_FACTORIAL_U8))
                                {
                                    return mm256_naivecomb_epu8(n, k);
                                }
                                else
                                {
                                    v256 nLo16 = mm256_cvt2x2epu8_epi16(n, out v256 nHi16);
                                    v256 kLo16 = mm256_cvt2x2epu8_epi16(k, out v256 kHi16);

                                    return mm256_cvt2x2epi16_epi8(mm256_naivecomb_epu16(nLo16, kLo16), mm256_naivecomb_epu16(nHi16, kHi16));
                                }
                            }
                            else
                            {
                                mm256_cvt4x4epu8_epi32(n, out v256 n32_0, out v256 n32_1, out v256 n32_2, out v256 n32_3);
                                mm256_cvt4x4epu8_epi32(k, out v256 k32_0, out v256 k32_1, out v256 k32_2, out v256 k32_3);

                                v256 result32_0 = mm256_naivecomb_epu32(n32_0, k32_0);
                                v256 result32_1 = mm256_naivecomb_epu32(n32_1, k32_1);
                                v256 result32_2 = mm256_naivecomb_epu32(n32_2, k32_2);
                                v256 result32_3 = mm256_naivecomb_epu32(n32_3, k32_3);

                                v256 result16_0 = mm256_cvt2x2epi32_epi16(result32_0, result32_1);
                                v256 result16_1 = mm256_cvt2x2epi32_epi16(result32_2, result32_3);

                                return mm256_cvt2x2epi16_epi8(result16_0, result16_1);
                            }
                        }
                        else
                        {
                            mm256_cvt8x8epu8_epi64(n, out v256 n64_0, out v256 n64_1, out v256 n64_2, out v256 n64_3, out v256 n64_4, out v256 n64_5, out v256 n64_6, out v256 n64_7);
                            mm256_cvt8x8epu8_epi64(k, out v256 k64_0, out v256 k64_1, out v256 k64_2, out v256 k64_3, out v256 k64_4, out v256 k64_5, out v256 k64_6, out v256 k64_7);

                            v256 result64_0 = mm256_naivecomb_epu64(n64_0, k64_0);
                            v256 result64_1 = mm256_naivecomb_epu64(n64_1, k64_1);
                            v256 result64_2 = mm256_naivecomb_epu64(n64_2, k64_2);
                            v256 result64_3 = mm256_naivecomb_epu64(n64_3, k64_3);
                            v256 result64_4 = mm256_naivecomb_epu64(n64_4, k64_4);
                            v256 result64_5 = mm256_naivecomb_epu64(n64_5, k64_5);
                            v256 result64_6 = mm256_naivecomb_epu64(n64_6, k64_6);
                            v256 result64_7 = mm256_naivecomb_epu64(n64_7, k64_7);

                            v256 result32_0 = mm256_cvt2x2epi64_epi32(result64_0, result64_1);
                            v256 result32_1 = mm256_cvt2x2epi64_epi32(result64_2, result64_3);
                            v256 result32_2 = mm256_cvt2x2epi64_epi32(result64_4, result64_5);
                            v256 result32_3 = mm256_cvt2x2epi64_epi32(result64_6, result64_7);

                            v256 result16_0 = mm256_cvt2x2epi32_epi16(result32_0, result32_1);
                            v256 result16_1 = mm256_cvt2x2epi32_epi16(result32_2, result32_3);

                            return mm256_cvt2x2epi16_epi8(result16_0, result16_1);
                        }
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU8(n, byte.MaxValue);
                    v256 ONE = mm256_set1_epi8(1);
                    Divider<byte32> loopDivider = new Divider<byte32>(new byte32(9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40), Divider<byte32>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    v256 cmp;
                    v256 results;
                    v256 i = ONE;
                    v256 c = n;
                    k = Avx2.mm256_min_epu8(k, Avx2.mm256_sub_epi8(n, k));
                    results = mm256_blendv_si256(c, ONE, Avx2.mm256_cmpeq_epi8(k, Avx.mm256_setzero_si256()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = Avx2.mm256_cmpgt_epi8(k, ONE);
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_constdiv_epu8(c, 2), n), Avx2.mm256_and_si256(mm256_neg_epi8(mm256_constrem_epu8(c, 2)), mm256_constdiv_epu8(n, 2)));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi8(k, mm256_set1_epi8(2));
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        v256 rem3 = mm256_constrem_epu8(c, 3);
                        v256 rem3is1orMore = Avx2.mm256_cmpgt_epi8(rem3, Avx.mm256_setzero_si256());
                        v256 rem3is2orMore = Avx2.mm256_cmpgt_epi8(rem3, ONE);
                        v256 mulrem3 = Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem3is1orMore, n), Avx2.mm256_and_si256(rem3is2orMore, n));
                        c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_constdiv_epu8(c, 3), n), mm256_constdiv_epu8(mulrem3, 3));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi8(k, mm256_set1_epi8(3));
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        v256 rem4 = mm256_constrem_epu8(c, 4);
                        v256 rem4is1orMore = Avx2.mm256_cmpgt_epi8(rem4, Avx.mm256_setzero_si256());
                        v256 rem4is2orMore = Avx2.mm256_cmpgt_epi8(rem4, ONE);
                        v256 rem4is3orMore = Avx2.mm256_cmpgt_epi8(rem4, mm256_set1_epi8(2));
                        v256 mulrem4 = Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem4is1orMore, n), Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem4is2orMore, n), Avx2.mm256_and_si256(rem4is3orMore, n)));
                        c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_constdiv_epu8(c, 4), n), mm256_constdiv_epu8(mulrem4, 4));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi8(k, mm256_set1_epi8(4));
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        v256 rem5 = mm256_constrem_epu8(c, 5);
                        v256 rem5is1orMore = Avx2.mm256_cmpgt_epi8(rem5, Avx.mm256_setzero_si256());
                        v256 rem5is2orMore = Avx2.mm256_cmpgt_epi8(rem5, ONE);
                        v256 rem5is3orMore = Avx2.mm256_cmpgt_epi8(rem5, mm256_set1_epi8(2));
                        v256 rem5is4orMore = Avx2.mm256_cmpgt_epi8(rem5, mm256_set1_epi8(3));
                        v256 mulrem5 = Avx2.mm256_add_epi8(Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem5is1orMore, n), Avx2.mm256_and_si256(rem5is2orMore, n)), Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem5is3orMore, n), Avx2.mm256_and_si256(rem5is4orMore, n)));
                        c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_constdiv_epu8(c, 5), n), mm256_constdiv_epu8(mulrem5, 5));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi8(k, mm256_set1_epi8(5));
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        v256 rem6 = mm256_constrem_epu8(c, 6);
                        v256 rem6is1orMore = Avx2.mm256_cmpgt_epi8(rem6, Avx.mm256_setzero_si256());
                        v256 rem6is2orMore = Avx2.mm256_cmpgt_epi8(rem6, ONE);
                        v256 rem6is3orMore = Avx2.mm256_cmpgt_epi8(rem6, mm256_set1_epi8(2));
                        v256 rem6is4orMore = Avx2.mm256_cmpgt_epi8(rem6, mm256_set1_epi8(3));
                        v256 rem6is5orMore = Avx2.mm256_cmpgt_epi8(rem6, mm256_set1_epi8(4));
                        v256 mulrem6 = Avx2.mm256_add_epi8(Avx2.mm256_add_epi8(Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem6is1orMore, n), Avx2.mm256_and_si256(rem6is2orMore, n)), Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem6is3orMore, n), Avx2.mm256_and_si256(rem6is4orMore, n))), Avx2.mm256_and_si256(rem6is5orMore, n));
                        c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_constdiv_epu8(c, 6), n), mm256_constdiv_epu8(mulrem6, 6));
                        results = mm256_blendv_si256(results, c, cmp);

                        i = mm256_set1_epi8(6);
                        cmp = Avx2.mm256_cmpgt_epi8(k, i);
                        i = Avx2.mm256_add_epi8(i, ONE);
                        n = Avx2.mm256_sub_epi8(n, ONE);
                        v256 rem7 = mm256_constrem_epu8(c, 7);
                        v256 rem7is1orMore = Avx2.mm256_cmpgt_epi8(rem7, Avx.mm256_setzero_si256());
                        v256 rem7is2orMore = Avx2.mm256_cmpgt_epi8(rem7, ONE);
                        v256 rem7is3orMore = Avx2.mm256_cmpgt_epi8(rem7, mm256_set1_epi8(2));
                        v256 rem7is4orMore = Avx2.mm256_cmpgt_epi8(rem7, mm256_set1_epi8(3));
                        v256 rem7is5orMore = Avx2.mm256_cmpgt_epi8(rem7, mm256_set1_epi8(4));
                        v256 rem7is6orMore = Avx2.mm256_cmpgt_epi8(rem7, mm256_set1_epi8(5));
                        v256 mulrem7 = Avx2.mm256_add_epi8(Avx2.mm256_add_epi8(Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem7is1orMore, n), Avx2.mm256_and_si256(rem7is2orMore, n)), Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem7is3orMore, n), Avx2.mm256_and_si256(rem7is4orMore, n))), Avx2.mm256_add_epi8(Avx2.mm256_and_si256(rem7is5orMore, n), Avx2.mm256_and_si256(rem7is6orMore, n)));
                        c = Avx2.mm256_add_epi8(mm256_mullo_epi8(mm256_constdiv_epu8(c, 7), n), mm256_constdiv_epu8(mulrem7, 7));
                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    while (CMP_EPI ? mm256_notallfalse_epi256<byte>(cmp = Avx2.mm256_cmpgt_epi8(k, i))
                                   : mm256_notalltrue_epi256<byte>(cmp = mm256_cmple_epu8(k, i)))
                    {
                        i = Avx2.mm256_add_epi8(i, ONE);
                        n = Avx2.mm256_sub_epi8(n, ONE);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v256 q = mm256_divrem_epu8(c, i, out v256 r);
                            c = Avx2.mm256_add_epi8(mm256_mullo_epi8(q, n), mm256_div_epu8(mm256_mullo_epi8(r, n), i));
                        }
                        else
                        {
                            Divider<byte> currentDivider = loopDivider.GetInnerDivider<byte>(indexCurrentDivider);
                            v256 q = currentDivider.DivRem(c, out byte32 r);
                            c = Avx2.mm256_add_epi8(mm256_mullo_epi8(q, n), (r * n) / currentDivider);
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }

                        results = CMP_EPI ? mm256_blendv_si256(results, c, cmp)
                                          : mm256_blendv_si256(c, results, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_comb_ep16(v256 n, v256 k, bool signed, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotGreater<ushort16, ushort>(k, n, 16);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            if (unsafeLevels > 2 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U16))
                            {
                                return mm256_naivecomb_epu16(n, k, unsafeLevels > 3 || constexpr.ALL_LE_EPU16(n, MAX_INVERSE_FACTORIAL_U8));
                            }
                            else
                            {
                                v256 nLo32 = mm256_cvt2x2epu16_epi32(n, out v256 nHi32);
                                v256 kLo32 = mm256_cvt2x2epu16_epi32(k, out v256 kHi32);

                                v256 resultLo = mm256_naivecomb_epu32(nLo32, kLo32);
                                v256 resultHi = mm256_naivecomb_epu32(nHi32, kHi32);

                                return mm256_cvt2x2epi32_epi16(resultLo, resultHi);
                            }
                        }
                        else
                        {
                            v256 nLo32 = mm256_cvt2x2epu16_epi32(n, out v256 nHi32);
                            v256 kLo32 = mm256_cvt2x2epu16_epi32(k, out v256 kHi32);
                            v256 n64LoLo = mm256_cvt2x2epu32_epi64(nLo32, out v256 n64LoHi);
                            v256 n64HiLo = mm256_cvt2x2epu32_epi64(nHi32, out v256 n64HiHi);
                            v256 k64LoLo = mm256_cvt2x2epu32_epi64(kLo32, out v256 k64LoHi);
                            v256 k64HiLo = mm256_cvt2x2epu32_epi64(kHi32, out v256 k64HiHi);

                            v256 resultLoLo = mm256_naivecomb_epu64(n64LoLo, k64LoLo);
                            v256 resultLoHi = mm256_naivecomb_epu64(n64LoHi, k64LoHi);
                            v256 resultHiLo = mm256_naivecomb_epu64(n64HiLo, k64HiLo);
                            v256 resultHiHi = mm256_naivecomb_epu64(n64HiHi, k64HiHi);

                            v256 result32Lo = mm256_cvt2x2epi64_epi32(resultLoLo, resultLoHi);
                            v256 result32Hi = mm256_cvt2x2epi64_epi32(resultHiLo, resultHiHi);

                            return mm256_cvt2x2epi32_epi16(result32Lo, result32Hi);
                        }
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU16(n, ushort.MaxValue);
                    v256 ONE = mm256_set1_epi16(1);
                    Divider<ushort16> loopDivider = new Divider<ushort16>(new ushort16(9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24), Divider<ushort16>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    v256 cmp;
                    v256 results;
                    v256 i = ONE;
                    v256 c = n;
                    k = Avx2.mm256_min_epu16(k, Avx2.mm256_sub_epi16(n, k));
                    results = mm256_blendv_si256(c, ONE, Avx2.mm256_cmpeq_epi16(k, Avx.mm256_setzero_si256()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(mm256_constdiv_epu16(c, 2), n), Avx2.mm256_and_si256(mm256_neg_epi16(mm256_constrem_epu16(c, 2)), mm256_constdiv_epu16(n, 2)));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        v256 rem3 = mm256_constrem_epu16(c, 3);
                        v256 rem3is1orMore = Avx2.mm256_cmpgt_epi16(rem3, Avx.mm256_setzero_si256());
                        v256 rem3is2orMore = Avx2.mm256_cmpgt_epi16(rem3, ONE);
                        v256 mulrem3 = Avx2.mm256_add_epi16(Avx2.mm256_and_si256(rem3is1orMore, n), Avx2.mm256_and_si256(rem3is2orMore, n));
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(mm256_constdiv_epu16(c, 3), n), mm256_constdiv_epu16(mulrem3, 3));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(mm256_constdiv_epu16(c, 4), n), mm256_constdiv_epu16(Avx2.mm256_mullo_epi16(mm256_constrem_epu16(c, 4), n), 4));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(mm256_constdiv_epu16(c, 5), n), mm256_constdiv_epu16(Avx2.mm256_mullo_epi16(mm256_constrem_epu16(c, 5), n), 5));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(mm256_constdiv_epu16(c, 6), n), mm256_constdiv_epu16(Avx2.mm256_mullo_epi16(mm256_constrem_epu16(c, 6), n), 6));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(mm256_constdiv_epu16(c, 7), n), mm256_constdiv_epu16(Avx2.mm256_mullo_epi16(mm256_constrem_epu16(c, 7), n), 7));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi16(k, i);
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);
                        c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(mm256_constdiv_epu16(c, 8), n), mm256_constdiv_epu16(Avx2.mm256_mullo_epi16(mm256_constrem_epu16(c, 8), n), 8));
                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    while (CMP_EPI ? mm256_notallfalse_epi256<byte>(cmp = Avx2.mm256_cmpgt_epi16(k, i))
                                   : mm256_notalltrue_epi256<byte>(cmp = mm256_cmple_epu16(k, i)))
                    {
                        i = Avx2.mm256_add_epi16(i, ONE);
                        n = Avx2.mm256_sub_epi16(n, ONE);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v256 q = mm256_divrem_epu16(c, i, out v256 r);
                            c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(q, n), mm256_div_epu16(Avx2.mm256_mullo_epi16(r, n), i));
                        }
                        else
                        {
                            Divider<ushort> currentDivider = loopDivider.GetInnerDivider<ushort>(indexCurrentDivider);
                            v256 q = currentDivider.DivRem(c, out ushort16 r);
                            c = Avx2.mm256_add_epi16(Avx2.mm256_mullo_epi16(q, n), (r * n) / currentDivider);
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }

                        results = CMP_EPI ? mm256_blendv_si256(results, c, cmp)
                                          : mm256_blendv_si256(c, results, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_comb_ep32(v256 n, v256 k, bool signed, byte unsafeLevels = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotGreater<uint8, uint>(k, n, 8);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU32(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            return mm256_naivecomb_epu32(n, k);
                        }
                        else
                        {
                            v256 n64Lo = mm256_cvt2x2epu32_epi64(n, out v256 n64Hi);
                            v256 k64Lo = mm256_cvt2x2epu32_epi64(k, out v256 k64Hi);

                            v256 resultLo = mm256_naivecomb_epu64(n64Lo, k64Lo);
                            v256 resultHi = mm256_naivecomb_epu64(n64Hi, k64Hi);

                            return mm256_cvt2x2epi64_epi32(resultLo, resultHi);
                        }
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU32(n, uint.MaxValue);
                    v256 ONE = mm256_set1_epi32(1);
                    Divider<uint8> loopDivider = new Divider<uint8>(new uint8(9, 10, 11, 12, 13, 14, 15, 16), Divider<uint8>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    v256 cmp;
                    v256 results;
                    v256 i = ONE;
                    v256 c = n;
                    k = Avx2.mm256_min_epu32(k, Avx2.mm256_sub_epi32(n, k));
                    results = mm256_blendv_si256(c, ONE, Avx2.mm256_cmpeq_epi32(k, Avx.mm256_setzero_si256()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(mm256_constdiv_epu32(c, 2), n), Avx2.mm256_and_si256(mm256_neg_epi32(mm256_constrem_epu32(c, 2)), mm256_constdiv_epu32(n, 2)));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        v256 rem3 = mm256_constrem_epu32(c, 3);
                        v256 rem3is1orMore = Avx2.mm256_cmpgt_epi32(rem3, Avx.mm256_setzero_si256());
                        v256 rem3is2orMore = Avx2.mm256_cmpgt_epi32(rem3, ONE);
                        v256 mulrem3 = Avx2.mm256_add_epi32(Avx2.mm256_and_si256(rem3is1orMore, n), Avx2.mm256_and_si256(rem3is2orMore, n));
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(mm256_constdiv_epu32(c, 3), n), mm256_constdiv_epu32(mulrem3, 3));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(mm256_constdiv_epu32(c, 4), n), mm256_constdiv_epu32(Avx2.mm256_mullo_epi32(mm256_constrem_epu32(c, 4), n), 4));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(mm256_constdiv_epu32(c, 5), n), mm256_constdiv_epu32(Avx2.mm256_mullo_epi32(mm256_constrem_epu32(c, 5), n), 5));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(mm256_constdiv_epu32(c, 6), n), mm256_constdiv_epu32(Avx2.mm256_mullo_epi32(mm256_constrem_epu32(c, 6), n), 6));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(mm256_constdiv_epu32(c, 7), n), mm256_constdiv_epu32(Avx2.mm256_mullo_epi32(mm256_constrem_epu32(c, 7), n), 7));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi32(k, i);
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);
                        c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(mm256_constdiv_epu32(c, 8), n), mm256_constdiv_epu32(Avx2.mm256_mullo_epi32(mm256_constrem_epu32(c, 8), n), 8));
                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    while (CMP_EPI ? mm256_notallfalse_epi256<uint>(cmp = Avx2.mm256_cmpgt_epi32(k, i))
                                   : mm256_notalltrue_epi256<uint>(cmp = mm256_cmple_epu32(k, i)))
                    {
                        i = Avx2.mm256_add_epi32(i, ONE);
                        n = Avx2.mm256_sub_epi32(n, ONE);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v256 q = mm256_divrem_epu32(c, i, out v256 r);
                            c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(q, n), mm256_div_epu32(Avx2.mm256_mullo_epi32(r, n), i));
                        }
                        else
                        {
                            Divider<uint> currentDivider = loopDivider.GetInnerDivider<uint>(indexCurrentDivider);
                            v256 q = currentDivider.DivRem(c, out uint8 r);
                            c = Avx2.mm256_add_epi32(Avx2.mm256_mullo_epi32(q, n), (r * n) / currentDivider);
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }

                        results = CMP_EPI ? mm256_blendv_si256(results, c, cmp)
                                          : mm256_blendv_si256(c, results, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 mm256_comb_ep64(v256 n, v256 k, bool signed, byte unsafeLevels = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
VectorAssert.IsNotGreater<ulong4, ulong>(k, n, elements);

                    if (unsafeLevels > 0 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U64))
                    {
                        if (unsafeLevels > 1 || constexpr.ALL_LE_EPU64(n, MAX_INVERSE_FACTORIAL_U32))
                        {
                            v256 nFactorial  = mm256_gamma_epu64(n, true);
                            v256 kFactorial  = mm256_gamma_epu64(k, true);
                            v256 nkFactorial = mm256_gamma_epu64(Avx2.mm256_sub_epi64(n, k), true);

                            return mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(nFactorial), mm256_usfcvtepu64_pd(mm256_mullo_epi64(kFactorial, nkFactorial, elements))), elements: elements, nonZero: true);
                        }
                        else
                        {
                            return mm256_naivecomb_epu64(n, k, elements);
                        }
                    }

                    bool CMP_EPI = signed || constexpr.ALL_LT_EPU64(n, ulong.MaxValue, elements);
                    v256 ONE = mm256_set1_epi64x(1);
                    Divider<ulong4> loopDivider = new Divider<ulong4>(new ulong4(9, 10, 11, 12), Divider<ulong4>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    v256 cmp;
                    v256 results;
                    v256 i = ONE;
                    v256 c = n;
                    k = signed || constexpr.ALL_LE_EPU64(n, (ulong)long.MaxValue)
                      ? mm256_min_epi64(k, Avx2.mm256_sub_epi64(n, k))
                      : mm256_min_epu64(k, Avx2.mm256_sub_epi64(n, k));
                    results = mm256_blendv_si256(c, ONE, Avx2.mm256_cmpeq_epi64(k, Avx.mm256_setzero_si256()));

                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR != OptimizeFor.Size)
                    {
                        cmp = Avx2.mm256_cmpgt_epi64(k, i);
                        i = Avx2.mm256_add_epi64(i, ONE);
                        n = Avx2.mm256_sub_epi64(n, ONE);
                        c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 2, elements), n, elements), Avx2.mm256_and_si256(mm256_neg_epi64(mm256_constrem_epu64(c, 2, elements)), mm256_constdiv_epu64(n, 2, elements)));
                        results = mm256_blendv_si256(results, c, cmp);

                        cmp = Avx2.mm256_cmpgt_epi64(k, i);
                        i = Avx2.mm256_add_epi64(i, ONE);
                        n = Avx2.mm256_sub_epi64(n, ONE);
                        v256 rem3 = mm256_constrem_epu64(c, 3, elements);
                        v256 rem3is1orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem3, Avx.mm256_setzero_si256()), Sse.SHUFFLE(2, 2, 0, 0));
                        v256 rem3is2orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem3, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                        v256 mulrem3 = Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem3is1orMore, n), Avx2.mm256_and_si256(rem3is2orMore, n));
                        c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 3, elements), n, elements), mm256_constdiv_epu64(mulrem3, 3, elements));
                        results = mm256_blendv_si256(results, c, cmp);

                        //if (Avx512.IsAvx512Supported)
                        //{
                        //    cmp = Avx2.mm256_cmpgt_epi64(k, i);
                        //    i = Avx2.mm256_add_epi64(i, ONE);
                        //    n = Avx2.mm256_sub_epi64(n, ONE);
                        //    c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 4, elements), n, elements), mm256_constdiv_epu64(mm256_mullo_epi64(mm256_constrem_epu64(c, 4, elements), n, elements), 4, elements));
                        //    results = mm256_blendv_si256(results, c, cmp);
                        //
                        //    cmp = Avx2.mm256_cmpgt_epi64(k, i);
                        //    i = Avx2.mm256_add_epi64(i, ONE);
                        //    n = Avx2.mm256_sub_epi64(n, ONE);
                        //    c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 5, elements), n, elements), mm256_constdiv_epu64(mm256_mullo_epi64(mm256_constrem_epu64(c, 5, elements), n, elements), 5, elements));
                        //    results = mm256_blendv_si256(results, c, cmp);
                        //
                        //    cmp = Avx2.mm256_cmpgt_epi64(k, i);
                        //    i = Avx2.mm256_add_epi64(i, ONE);
                        //    n = Avx2.mm256_sub_epi64(n, ONE);
                        //    c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 6, elements), n, elements), mm256_constdiv_epu64(mm256_mullo_epi64(mm256_constrem_epu64(c, 6, elements), n, elements), 6, elements));
                        //    results = mm256_blendv_si256(results, c, cmp);
                        //
                        //    cmp = Avx2.mm256_cmpgt_epi64(k, i);
                        //    i = Avx2.mm256_add_epi64(i, ONE);
                        //    n = Avx2.mm256_sub_epi64(n, ONE);
                        //    c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 7, elements), n, elements), mm256_constdiv_epu64(mm256_mullo_epi64(mm256_constrem_epu64(c, 7, elements), n, elements), 7, elements));
                        //    results = mm256_blendv_si256(results, c, cmp);
                        //
                        //    cmp = Avx2.mm256_cmpgt_epi64(k, i);
                        //    i = Avx2.mm256_add_epi64(i, ONE);
                        //    n = Avx2.mm256_sub_epi64(n, ONE);
                        //    c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 8, elements), n, elements), mm256_constdiv_epu64(mm256_mullo_epi64(mm256_constrem_epu64(c, 8, elements), n, elements), 8, elements));
                        //    results = mm256_blendv_si256(results, c, cmp);
                        //}
                        //else
                        //{
                              cmp = Avx2.mm256_cmpgt_epi64(k, mm256_set1_epi64x(3));
                              n = Avx2.mm256_sub_epi64(n, ONE);
                              v256 rem4 = mm256_constrem_epu64(c, 4, elements);
                              v256 rem4is1orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem4, Avx.mm256_setzero_si256()), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem4is2orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem4, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem4is3orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem4, mm256_set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 mulrem4 = Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem4is1orMore, n), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem4is2orMore, n), Avx2.mm256_and_si256(rem4is3orMore, n)));
                              c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 4, elements), n, elements), mm256_constdiv_epu64(mulrem4, 4, elements));
                              results = mm256_blendv_si256(results, c, cmp);

                              cmp = Avx2.mm256_cmpgt_epi64(k, mm256_set1_epi64x(4));
                              n = Avx2.mm256_sub_epi64(n, ONE);
                              v256 rem5 = mm256_constrem_epu64(c, 5, elements);
                              v256 rem5is1orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem5, Avx.mm256_setzero_si256()), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem5is2orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem5, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem5is3orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem5, mm256_set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem5is4orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem5, mm256_set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 mulrem5 = Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem5is1orMore, n), Avx2.mm256_and_si256(rem5is2orMore, n)), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem5is3orMore, n), Avx2.mm256_and_si256(rem5is4orMore, n)));
                              c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 5, elements), n, elements), mm256_constdiv_epu64(mulrem5, 5, elements));
                              results = mm256_blendv_si256(results, c, cmp);

                              cmp = Avx2.mm256_cmpgt_epi64(k, mm256_set1_epi64x(5));
                              n = Avx2.mm256_sub_epi64(n, ONE);
                              v256 rem6 = mm256_constrem_epu64(c, 6, elements);
                              v256 rem6is1orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem6, Avx.mm256_setzero_si256()), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem6is2orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem6, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem6is3orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem6, mm256_set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem6is4orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem6, mm256_set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem6is5orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem6, mm256_set1_epi64x(4)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 mulrem6 = Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem6is1orMore, n), Avx2.mm256_and_si256(rem6is2orMore, n)), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem6is3orMore, n), Avx2.mm256_and_si256(rem6is4orMore, n))), Avx2.mm256_and_si256(rem6is5orMore, n));
                              c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 6, elements), n, elements), mm256_constdiv_epu64(mulrem6, 6, elements));
                              results = mm256_blendv_si256(results, c, cmp);

                              cmp = Avx2.mm256_cmpgt_epi64(k, mm256_set1_epi64x(6));
                              n = Avx2.mm256_sub_epi64(n, ONE);
                              v256 rem7 = mm256_constrem_epu64(c, 7, elements);
                              v256 rem7is1orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem7, Avx.mm256_setzero_si256()), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem7is2orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem7, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem7is3orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem7, mm256_set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem7is4orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem7, mm256_set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem7is5orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem7, mm256_set1_epi64x(4)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem7is6orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem7, mm256_set1_epi64x(5)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 mulrem7 = Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem7is1orMore, n), Avx2.mm256_and_si256(rem7is2orMore, n)), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem7is3orMore, n), Avx2.mm256_and_si256(rem7is4orMore, n))), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem7is5orMore, n), Avx2.mm256_and_si256(rem7is6orMore, n)));
                              c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 7, elements), n, elements), mm256_constdiv_epu64(mulrem7, 7, elements));
                              results = mm256_blendv_si256(results, c, cmp);

                              i = mm256_set1_epi64x(7);
                              cmp = Avx2.mm256_cmpgt_epi64(k, i);
                              i = Avx2.mm256_add_epi64(i, ONE);
                              n = Avx2.mm256_sub_epi64(n, ONE);
                              v256 rem8 = mm256_constrem_epu64(c, 8, elements);
                              v256 rem8is1orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem8, Avx.mm256_setzero_si256()), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem8is2orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem8, ONE), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem8is3orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem8, mm256_set1_epi64x(2)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem8is4orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem8, mm256_set1_epi64x(3)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem8is5orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem8, mm256_set1_epi64x(4)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem8is6orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem8, mm256_set1_epi64x(5)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 rem8is7orMore = Avx2.mm256_shuffle_epi32(Avx2.mm256_cmpgt_epi32(rem8, mm256_set1_epi64x(6)), Sse.SHUFFLE(2, 2, 0, 0));
                              v256 mulrem8 = Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem8is1orMore, n), Avx2.mm256_and_si256(rem8is2orMore, n)), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem8is3orMore, n), Avx2.mm256_and_si256(rem8is4orMore, n))), Avx2.mm256_add_epi64(Avx2.mm256_and_si256(rem8is5orMore, n), Avx2.mm256_and_si256(rem8is6orMore, n))), Avx2.mm256_and_si256(rem8is7orMore, n));
                              c = Avx2.mm256_add_epi64(mm256_mullo_epi64(mm256_constdiv_epu64(c, 8, elements), n, elements), mm256_constdiv_epu64(mulrem8, 8, elements));
                              results = mm256_blendv_si256(results, c, cmp);
                        //}
                    }

                    while (mm256_notallfalse_epi256<ulong>(cmp = CMP_EPI ? mm256_cmpgt_epi64(k, i, elements)
                                                                         : mm256_cmpgt_epu64(k, i, elements), elements))
                    {
                        i = Avx2.mm256_add_epi64(i, ONE);
                        n = Avx2.mm256_sub_epi64(n, ONE);

                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            v256 q = mm256_divrem_epu64(c, i, out v256 r, bLEu32max: true);
                            c = Avx2.mm256_add_epi64(mm256_mullo_epi64(q, n, elements), mm256_div_epu64(mm256_mullo_epi64(r, n, elements), i, bLEu32max: true));
                        }
                        else
                        {
                            Divider<ulong> currentDivider = loopDivider.GetInnerDivider<ulong>(indexCurrentDivider);
                            if (elements == 3)
                            {
                                v256 q = currentDivider.DivRem(c, out ulong3 r);
                                c = Avx2.mm256_add_epi64(mm256_mullo_epi64(q, n, 3), (ulong3)mm256_mullo_epi64(r, n, 3) / currentDivider);
                            }
                            else
                            {
                                v256 q = currentDivider.DivRem(c, out ulong4 r);
                                c = Avx2.mm256_add_epi64(mm256_mullo_epi64(q, n, 4), (ulong4)mm256_mullo_epi64(r, n, 4) / currentDivider);
                            }
                            next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                        }

                        results = mm256_blendv_si256(results, c, cmp);
                    }

                    return results;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 128 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 comb(UInt128 n, UInt128 k, Promise useFactorial = Promise.Nothing)
        {
            static void LoopIteration([NoAlias] ref UInt128 c, [NoAlias] ref UInt128 n, ulong i)
            {
                UInt128 q = divrem(c, i, out ulong r);
                n--;
                c = (q * n) + ((r * n) / i);
            }


Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U128))
            {
                return factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial(n - k, Promise.NoOverflow));
            }


            // going beyond ulong.MaxValue iterations is not realistic whatsoever (takes literal years of runtime) - optimized
            ulong i;
            UInt128 c = n;
            k = min(k, n - k);

            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                if (Hint.Unlikely(k.IsZero))
                {
                    return 1;
                }

                i = 1;

                while (k > i++)
                {
                    LoopIteration(ref c, ref n, i);
                }
            }
            else
            {
                if (Hint.Unlikely(k <= 1))
                {
                    return select(n, 1, k.IsZero);
                }

                i = 8;

                n--;
                c = ((c >> 1) * n) + select(n >> 1, 0, (c.lo64 & 1) == 0);

                if (Hint.Unlikely(k <= 2)) return c;
                LoopIteration(ref c, ref n, 3);

                if (Hint.Unlikely(k <= 3)) return c;
                LoopIteration(ref c, ref n, 4);

                if (Hint.Unlikely(k <= 4)) return c;
                LoopIteration(ref c, ref n, 5);

                if (Hint.Unlikely(k <= 5)) return c;
                LoopIteration(ref c, ref n, 6);

                if (Hint.Unlikely(k <= 6)) return c;
                LoopIteration(ref c, ref n, 7);

                if (Hint.Unlikely(k <= 7)) return c;
                LoopIteration(ref c, ref n, 8);

                while (k > i++)
                {
                    LoopIteration(ref c, ref n, i);
                }
            }

            return c;
        }

        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 128 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 128 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 comb(Int128 n, Int128 k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsTrue(k >= 0);
Assert.IsTrue(n >= 0);

            return comb((UInt128)n, (UInt128)k, useFactorial);
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte comb(byte n, byte k, Promise useFactorial = Promise.Nothing)
        {
            static void FallbackLoopIteration([NoAlias] ref ushort c, [NoAlias] ref byte n, ushort i)
            {
                c *= --n;
                c /= i;
            }


            if (useFactorial.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    if (useFactorial.CountUnsafeLevels() > 2 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U16))
                    {
                        if (useFactorial.CountUnsafeLevels() > 3 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U8))
                        {
                            return (byte)(factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial((byte)(n - k), Promise.NoOverflow)));
                        }
                        else
                        {
                            return (byte)(factorial((ushort)n, Promise.NoOverflow) / (factorial((ushort)k, Promise.NoOverflow) * factorial((ushort)(n - k), Promise.NoOverflow)));
                        }
                    }
                    else
                    {
                        return (byte)(factorial((uint)n, Promise.NoOverflow) / (factorial((uint)k, Promise.NoOverflow) * factorial((uint)(n - k), Promise.NoOverflow)));
                    }
                }
                else
                {
                    return (byte)(factorial((ulong)n, Promise.NoOverflow) / (factorial((ulong)k, Promise.NoOverflow) * factorial((ulong)(n - k), Promise.NoOverflow)));
                }
            }


            ushort i;
            ushort c = n;
            k = min(k, (byte)(n - k));

            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                if (Hint.Unlikely(k == 0))
                {
                    return 1;
                }

                i = 1;

                while (k > i++)
                {
                    FallbackLoopIteration(ref c, ref n, i);
                }
            }
            else
            {
                if (Hint.Unlikely(k <= 1))
                {
                    return k == 0 ? (byte)1 : n;
                }

                i = 8;

                FallbackLoopIteration(ref c, ref n, 2);

                if (Hint.Unlikely(k <= 2)) return (byte)c;
                FallbackLoopIteration(ref c, ref n, 3);

                if (Hint.Unlikely(k <= 3)) return (byte)c;
                FallbackLoopIteration(ref c, ref n, 4);

                if (Hint.Unlikely(k <= 4)) return (byte)c;
                FallbackLoopIteration(ref c, ref n, 5);

                if (Hint.Unlikely(k <= 5)) return (byte)c;
                FallbackLoopIteration(ref c, ref n, 6);

                if (Hint.Unlikely(k <= 6)) return (byte)c;
                FallbackLoopIteration(ref c, ref n, 7);

                if (Hint.Unlikely(k <= 7)) return (byte)c;
                FallbackLoopIteration(ref c, ref n, 8);

                if (Avx2.IsAvx2Supported)
                {
                    Divider<ushort16> loopDivider = new Divider<ushort16>(new ushort16(9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24), Divider<ushort16>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    while (k > i++)
                    {
                        c *= --n;
                        c /= loopDivider.GetInnerDivider<ushort>(indexCurrentDivider);
                        Xse.next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    Divider<ushort8> loopDivider = new Divider<ushort8>(new ushort8(9, 10, 11, 12, 13, 14, 15, 16), Divider<ushort8>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    while (k > i++)
                    {
                        c *= --n;
                        c /= loopDivider.GetInnerDivider<ushort>(indexCurrentDivider);
                        Xse.next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                    }
                }
                else
                {
                    while (k > i++)
                    {
                        FallbackLoopIteration(ref c, ref n, i);
                    }
                }
            }

            return (byte)c;
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 comb(byte2 n, byte2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new byte2(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 comb(byte3 n, byte3 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new byte3(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial),
                                 comb(n.z, k.z, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 comb(byte4 n, byte4 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new byte4(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial),
                                 comb(n.z, k.z, useFactorial),
                                 comb(n.w, k.w, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 comb(byte8 n, byte8 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new byte8(comb(n.x0, k.x0, useFactorial),
                                 comb(n.x1, k.x1, useFactorial),
                                 comb(n.x2, k.x2, useFactorial),
                                 comb(n.x3, k.x3, useFactorial),
                                 comb(n.x4, k.x4, useFactorial),
                                 comb(n.x5, k.x5, useFactorial),
                                 comb(n.x6, k.x6, useFactorial),
                                 comb(n.x7, k.x7, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 comb(byte16 n, byte16 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu8(n, k, useFactorial.CountUnsafeLevels(), 16);
            }
            else
            {
                return new byte16(comb(n.x0,  k.x0,  useFactorial),
                                  comb(n.x1,  k.x1,  useFactorial),
                                  comb(n.x2,  k.x2,  useFactorial),
                                  comb(n.x3,  k.x3,  useFactorial),
                                  comb(n.x4,  k.x4,  useFactorial),
                                  comb(n.x5,  k.x5,  useFactorial),
                                  comb(n.x6,  k.x6,  useFactorial),
                                  comb(n.x7,  k.x7,  useFactorial),
                                  comb(n.x8,  k.x8,  useFactorial),
                                  comb(n.x9,  k.x9,  useFactorial),
                                  comb(n.x10, k.x10, useFactorial),
                                  comb(n.x11, k.x11, useFactorial),
                                  comb(n.x12, k.x12, useFactorial),
                                  comb(n.x13, k.x13, useFactorial),
                                  comb(n.x14, k.x14, useFactorial),
                                  comb(n.x15, k.x15, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 comb(byte32 n, byte32 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu8(n, k, useFactorial.CountUnsafeLevels());
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epu8x2(n.v16_0, n.v16_16, k.v16_0, k.v16_16, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new byte32(lo, hi);
            }
            else
            {
                return new byte32(comb(n.v16_0,  k.v16_0,  useFactorial),
                                  comb(n.v16_16, k.v16_16, useFactorial));
            }
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte comb(sbyte n, sbyte k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);

            return comb((byte)n, (byte)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 comb(sbyte2 n, sbyte2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new byte2(comb((byte)n.x, (byte)k.x, useFactorial),
                                 comb((byte)n.y, (byte)k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 comb(sbyte3 n, sbyte3 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new byte3(comb((byte)n.x, (byte)k.x, useFactorial),
                                 comb((byte)n.y, (byte)k.y, useFactorial),
                                 comb((byte)n.z, (byte)k.z, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 comb(sbyte4 n, sbyte4 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new byte4(comb((byte)n.x, (byte)k.x, useFactorial),
                                 comb((byte)n.y, (byte)k.y, useFactorial),
                                 comb((byte)n.z, (byte)k.z, useFactorial),
                                 comb((byte)n.w, (byte)k.w, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 comb(sbyte8 n, sbyte8 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new byte8(comb((byte)n.x0, (byte)k.x0, useFactorial),
                                 comb((byte)n.x1, (byte)k.x1, useFactorial),
                                 comb((byte)n.x2, (byte)k.x2, useFactorial),
                                 comb((byte)n.x3, (byte)k.x3, useFactorial),
                                 comb((byte)n.x4, (byte)k.x4, useFactorial),
                                 comb((byte)n.x5, (byte)k.x5, useFactorial),
                                 comb((byte)n.x6, (byte)k.x6, useFactorial),
                                 comb((byte)n.x7, (byte)k.x7, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 comb(sbyte16 n, sbyte16 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi8(n, k, useFactorial.CountUnsafeLevels(), 16);
            }
            else
            {
                return new byte16(comb((byte)n.x0,  (byte)k.x0,  useFactorial),
                                  comb((byte)n.x1,  (byte)k.x1,  useFactorial),
                                  comb((byte)n.x2,  (byte)k.x2,  useFactorial),
                                  comb((byte)n.x3,  (byte)k.x3,  useFactorial),
                                  comb((byte)n.x4,  (byte)k.x4,  useFactorial),
                                  comb((byte)n.x5,  (byte)k.x5,  useFactorial),
                                  comb((byte)n.x6,  (byte)k.x6,  useFactorial),
                                  comb((byte)n.x7,  (byte)k.x7,  useFactorial),
                                  comb((byte)n.x8,  (byte)k.x8,  useFactorial),
                                  comb((byte)n.x9,  (byte)k.x9,  useFactorial),
                                  comb((byte)n.x10, (byte)k.x10, useFactorial),
                                  comb((byte)n.x11, (byte)k.x11, useFactorial),
                                  comb((byte)n.x12, (byte)k.x12, useFactorial),
                                  comb((byte)n.x13, (byte)k.x13, useFactorial),
                                  comb((byte)n.x14, (byte)k.x14, useFactorial),
                                  comb((byte)n.x15, (byte)k.x15, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 8 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 comb(sbyte32 n, sbyte32 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi8(n, k, useFactorial.CountUnsafeLevels());
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epi8x2(n.v16_0, n.v16_16, k.v16_0, k.v16_16, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new byte32(lo, hi);
            }
            else
            {
                return new byte32(comb(n.v16_0,  k.v16_0,  useFactorial),
                                  comb(n.v16_16, k.v16_16, useFactorial));
            }
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort comb(ushort n, ushort k, Promise useFactorial = Promise.Nothing)
        {
            static void FallbackLoopIteration([NoAlias] ref uint c, [NoAlias] ref ushort n, uint i)
            {
                c *= --n;
                c /= i;
            }


            if (useFactorial.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    if (useFactorial.CountUnsafeLevels() > 2 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U16))
                    {
                        if (useFactorial.CountUnsafeLevels() > 3 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U8))
                        {
                            return (ushort)(factorial((byte)n, Promise.NoOverflow) / (factorial((byte)k, Promise.NoOverflow) * factorial((byte)(n - k), Promise.NoOverflow)));
                        }
                        else
                        {
                            return (ushort)(factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial((ushort)(n - k), Promise.NoOverflow)));
                        }
                    }
                    else
                    {
                        return (ushort)(factorial((uint)n, Promise.NoOverflow) / (factorial((uint)k, Promise.NoOverflow) * factorial((uint)(n - k), Promise.NoOverflow)));
                    }
                }
                else
                {
                    return (ushort)(factorial((ulong)n, Promise.NoOverflow) / (factorial((ulong)k, Promise.NoOverflow) * factorial((ulong)(n - k), Promise.NoOverflow)));
                }
            }


            uint i;
            uint c = n;
            k = min(k, (ushort)(n - k));

            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                if (Hint.Unlikely(k == 0))
                {
                    return 1;
                }

                i = 1;

                while (k > i++)
                {
                    FallbackLoopIteration(ref c, ref n, i);
                }
            }
            else
            {
                if (Hint.Unlikely(k <= 1))
                {
                    return k == 0 ? (ushort)1 : n;
                }

                i = 8;

                FallbackLoopIteration(ref c, ref n, 2);

                if (Hint.Unlikely(k <= 2)) return (ushort)c;
                FallbackLoopIteration(ref c, ref n, 3);

                if (Hint.Unlikely(k <= 3)) return (ushort)c;
                FallbackLoopIteration(ref c, ref n, 4);

                if (Hint.Unlikely(k <= 4)) return (ushort)c;
                FallbackLoopIteration(ref c, ref n, 5);

                if (Hint.Unlikely(k <= 5)) return (ushort)c;
                FallbackLoopIteration(ref c, ref n, 6);

                if (Hint.Unlikely(k <= 6)) return (ushort)c;
                FallbackLoopIteration(ref c, ref n, 7);

                if (Hint.Unlikely(k <= 7)) return (ushort)c;
                FallbackLoopIteration(ref c, ref n, 8);

                if (Avx2.IsAvx2Supported)
                {
                    Divider<uint8> loopDivider = new Divider<uint8>(new uint8(9, 10, 11, 12, 13, 14, 15, 16), Divider<uint8>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    while (k > i++)
                    {
                        Divider<uint> currentDivider = loopDivider.GetInnerDivider<uint>(indexCurrentDivider);

                        c *= --n;
                        c /= currentDivider;

                        Xse.next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                    }
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    Divider<uint4> loopDivider = new Divider<uint4>(new uint4(9, 10, 11, 12), Divider<uint4>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    while (k > i++)
                    {
                        c *= --n;
                        c /= loopDivider.GetInnerDivider<uint>(indexCurrentDivider);
                        Xse.next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                    }
                }
                else
                {
                    while (k > i++)
                    {
                        FallbackLoopIteration(ref c, ref n, i);
                    }
                }
            }

            return (ushort)c;
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 comb(ushort2 n, ushort2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new ushort2(comb(n.x, k.x, useFactorial),
                                   comb(n.y, k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 comb(ushort3 n, ushort3 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new ushort3(comb(n.x, k.x, useFactorial),
                                   comb(n.y, k.y, useFactorial),
                                   comb(n.z, k.z, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 comb(ushort4 n, ushort4 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ushort4(comb(n.x, k.x, useFactorial),
                                   comb(n.y, k.y, useFactorial),
                                   comb(n.z, k.z, useFactorial),
                                   comb(n.w, k.w, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 comb(ushort8 n, ushort8 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu16(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new ushort8(comb(n.x0, k.x0, useFactorial),
                                   comb(n.x1, k.x1, useFactorial),
                                   comb(n.x2, k.x2, useFactorial),
                                   comb(n.x3, k.x3, useFactorial),
                                   comb(n.x4, k.x4, useFactorial),
                                   comb(n.x5, k.x5, useFactorial),
                                   comb(n.x6, k.x6, useFactorial),
                                   comb(n.x7, k.x7, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 comb(ushort16 n, ushort16 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu16(n, k, useFactorial.CountUnsafeLevels());
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epu16x2(n.v8_0, n.v8_8, k.v8_0, k.v8_8, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new ushort16(lo, hi);
            }
            else
            {
                return new ushort16(comb(n.v8_0, k.v8_0, useFactorial),
                                    comb(n.v8_8, k.v8_8, useFactorial));
            }
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort comb(short n, short k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);

            return comb((ushort)n, (ushort)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 comb(short2 n, short2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 2);
            }
            else
            {
                return new ushort2(comb((ushort)n.x, (ushort)k.x, useFactorial),
                                   comb((ushort)n.y, (ushort)k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 comb(short3 n, short3 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else
            {
                return new ushort3(comb((ushort)n.x, (ushort)k.x, useFactorial),
                                   comb((ushort)n.y, (ushort)k.y, useFactorial),
                                   comb((ushort)n.z, (ushort)k.z, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 comb(short4 n, short4 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ushort4(comb((ushort)n.x, (ushort)k.x, useFactorial),
                                   comb((ushort)n.y, (ushort)k.y, useFactorial),
                                   comb((ushort)n.z, (ushort)k.z, useFactorial),
                                   comb((ushort)n.w, (ushort)k.w, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 comb(short8 n, short8 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi16(n, k, useFactorial.CountUnsafeLevels(), 8);
            }
            else
            {
                return new ushort8(comb((ushort)n.x0, (ushort)k.x0, useFactorial),
                                   comb((ushort)n.x1, (ushort)k.x1, useFactorial),
                                   comb((ushort)n.x2, (ushort)k.x2, useFactorial),
                                   comb((ushort)n.x3, (ushort)k.x3, useFactorial),
                                   comb((ushort)n.x4, (ushort)k.x4, useFactorial),
                                   comb((ushort)n.x5, (ushort)k.x5, useFactorial),
                                   comb((ushort)n.x6, (ushort)k.x6, useFactorial),
                                   comb((ushort)n.x7, (ushort)k.x7, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 16 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe2"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 16 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe3"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 8 bit overflow.         </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 comb(short16 n, short16 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi16(n, k, useFactorial.CountUnsafeLevels());
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epi16x2(n.v8_0, n.v8_8, k.v8_0, k.v8_8, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new ushort16(lo, hi);
            }
            else
            {
                return new ushort16(comb(n.v8_0, k.v8_0, useFactorial),
                                    comb(n.v8_8, k.v8_8, useFactorial));
            }
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint comb(uint n, uint k, Promise useFactorial = Promise.Nothing)
        {
            static void FallbackLoopIteration([NoAlias] ref ulong c, [NoAlias] ref uint n, ulong i)
            {
                c *= --n;
                c /= i;
            }


Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    return factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial(n - k, Promise.NoOverflow));
                }
                else
                {
                    return (uint)(factorial((ulong)n, Promise.NoOverflow) / (factorial((ulong)k, Promise.NoOverflow) * factorial((ulong)n - (ulong)k, Promise.NoOverflow)));
                }
            }


            ulong i;
            ulong c = n;
            k = math.min(k, n - k);

            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                if (Hint.Unlikely(k == 0))
                {
                    return 1;
                }

                i = 1;

                while (k > i++)
                {
                    FallbackLoopIteration(ref c, ref n, i);
                }
            }
            else
            {
                if (Hint.Unlikely(k <= 1))
                {
                    return k == 0 ? 1 : n;
                }

                i = 8;

                FallbackLoopIteration(ref c, ref n, 2);

                if (Hint.Unlikely(k <= 2)) return (uint)c;
                FallbackLoopIteration(ref c, ref n, 3);

                if (Hint.Unlikely(k <= 3)) return (uint)c;
                FallbackLoopIteration(ref c, ref n, 4);

                if (Hint.Unlikely(k <= 4)) return (uint)c;
                FallbackLoopIteration(ref c, ref n, 5);

                if (Hint.Unlikely(k <= 5)) return (uint)c;
                FallbackLoopIteration(ref c, ref n, 6);

                if (Hint.Unlikely(k <= 6)) return (uint)c;
                FallbackLoopIteration(ref c, ref n, 7);

                if (Hint.Unlikely(k <= 7)) return (uint)c;
                FallbackLoopIteration(ref c, ref n, 8);

                while (k > i++)
                {
                    FallbackLoopIteration(ref c, ref n, i);
                }
            }

            return (uint)c;
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 comb(uint2 n, uint2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.comb_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 2));
            }
            else
            {
                return new uint2(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 comb(uint3 n, uint3 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.comb_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 3));
            }
            else
            {
                return new uint3(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial),
                                 comb(n.z, k.z, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 comb(uint4 n, uint4 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.comb_epu32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 4));
            }
            else
            {
                return new uint4(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial),
                                 comb(n.z, k.z, useFactorial),
                                 comb(n.w, k.w, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 comb(uint8 n, uint8 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu32(n, k, useFactorial.CountUnsafeLevels());
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epu32x2(RegisterConversion.ToV128(n.v4_0), RegisterConversion.ToV128(n.v4_4), RegisterConversion.ToV128(k.v4_0), RegisterConversion.ToV128(k.v4_4), out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                return new uint8(comb(n.v4_0, k.v4_0, useFactorial),
                                 comb(n.v4_4, k.v4_4, useFactorial));
            }
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint comb(int n, int k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);

            return comb((uint)n, (uint)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 comb(int2 n, int2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.comb_epi32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 2));
            }
            else
            {
                return new uint2(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 comb(int3 n, int3 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.comb_epi32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 3));
            }
            else
            {
                return new uint3(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial),
                                 comb(n.z, k.z, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 comb(int4 n, int4 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.comb_epi32(RegisterConversion.ToV128(n), RegisterConversion.ToV128(k), useFactorial.CountUnsafeLevels(), 4));
            }
            else
            {
                return new uint4(comb(n.x, k.x, useFactorial),
                                 comb(n.y, k.y, useFactorial),
                                 comb(n.z, k.z, useFactorial),
                                 comb(n.w, k.w, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>".
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 comb(int8 n, int8 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi32(n, k, useFactorial.CountUnsafeLevels());
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epi32x2(RegisterConversion.ToV128(n.v4_0), RegisterConversion.ToV128(n.v4_4), RegisterConversion.ToV128(k.v4_0), RegisterConversion.ToV128(k.v4_4), out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                return new uint8(comb(n.v4_0, k.v4_0, useFactorial),
                                 comb(n.v4_4, k.v4_4, useFactorial));
            }
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong comb(ulong n, ulong k, Promise useFactorial = Promise.Nothing)
        {
            static void FallbackLoopIteration([NoAlias] ref ulong c, [NoAlias] ref ulong n, ulong i)
            {
                ulong q = divrem(c, i, out ulong r);
                n--;
                c = (q * n) + ((r * n) / i);
            }


Assert.IsNotGreater(k, n);

            if (useFactorial.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U64))
            {
                if (useFactorial.CountUnsafeLevels() > 1 || constexpr.IS_TRUE(n <= MAX_INVERSE_FACTORIAL_U32))
                {
                    return (ulong)factorial((uint)n, Promise.NoOverflow) / (ulong)(factorial((uint)k, Promise.NoOverflow) * factorial((uint)n - (uint)k, Promise.NoOverflow));
                }
                else
                {
                    return factorial(n, Promise.NoOverflow) / (factorial(k, Promise.NoOverflow) * factorial(n - k, Promise.NoOverflow));
                }
            }


            ulong i;
            ulong c = n;
            k = math.min(k, n - k);

            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                if (Hint.Unlikely(k == 0))
                {
                    return 1;
                }

                i = 1;

                while (k > i++)
                {
                    FallbackLoopIteration(ref c, ref n, i);
                }
            }
            else
            {
                if (Hint.Unlikely(k <= 1))
                {
                    return k == 0 ? 1 : n;
                }

                i = 8;
                n--;
                c = ((c >> 1) * n) + ((c & 1) == 0 ? 0 : n >> 1);

                if (Hint.Unlikely(k <= 2)) return c;
                FallbackLoopIteration(ref c, ref n, 3);

                if (Hint.Unlikely(k <= 3)) return c;
                FallbackLoopIteration(ref c, ref n, 4);

                if (Hint.Unlikely(k <= 4)) return c;
                FallbackLoopIteration(ref c, ref n, 5);

                if (Hint.Unlikely(k <= 5)) return c;
                FallbackLoopIteration(ref c, ref n, 6);

                if (Hint.Unlikely(k <= 6)) return c;
                FallbackLoopIteration(ref c, ref n, 7);

                if (Hint.Unlikely(k <= 7)) return c;
                FallbackLoopIteration(ref c, ref n, 8);

                if (Avx2.IsAvx2Supported)
                {
                    Divider<ulong4> loopDivider = new Divider<ulong4>(new ulong4(9, 10, 11, 12), Divider<ulong4>.WELL_KNOWN_COMB_PROMISES);
                    int indexCurrentDivider = 0;

                    while (k > i++)
                    {
                        Divider<ulong> currentDivider = loopDivider.GetInnerDivider<ulong>(indexCurrentDivider);

                        ulong q = currentDivider.DivRem(c, out ulong r);
                        n--;
                        c = (q * n) + ((r * n) / currentDivider);

                        Xse.next_comb_divider(ref loopDivider, ref indexCurrentDivider);
                    }
                }
                else
                {
                    while (k > i++)
                    {
                        FallbackLoopIteration(ref c, ref n, i);
                    }
                }
            }

            return c;
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 comb(ulong2 n, ulong2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epu64(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ulong2(comb(n.x, k.x, useFactorial),
                                  comb(n.y, k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 comb(ulong3 n, ulong3 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu64(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epu64x2(n.xy, n.zz, k.xy, k.zz, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                return new ulong3(comb(n.xy, k.xy, useFactorial),
                                  comb(n.z,  k.z,  useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 comb(ulong4 n, ulong4 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epu64(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epu64x2(n.xy, n.zw, k.xy, k.zw, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new ulong4(lo, hi);
            }
            else
            {
                return new ulong4(comb(n.xy, k.xy, useFactorial),
                                  comb(n.zw, k.zw, useFactorial));
            }
        }


        /// <summary>       Returns the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong comb(long n, long k, Promise useFactorial = Promise.Nothing)
        {
Assert.IsNonNegative(k);
Assert.IsNonNegative(n);

            return comb((ulong)n, (ulong)k, useFactorial);
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 comb(long2 n, long2 k, Promise useFactorial = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.comb_epi64(n, k, useFactorial.CountUnsafeLevels());
            }
            else
            {
                return new ulong2(comb(n.x, k.x, useFactorial),
                                  comb(n.y, k.y, useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 comb(long3 n, long3 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi64(n, k, useFactorial.CountUnsafeLevels(), 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epi64x2(n.xy, n.zz, k.xy, k.zz, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                return new ulong3(comb(n.xy, k.xy, useFactorial),
                                  comb(n.z,  k.z,  useFactorial));
            }
        }

        /// <summary>       Returns for each pair of corresponding components the number of ways to choose <paramref name="k"/> items from <paramref name="n"/> items without repetition and without order. Also known as the binomial coefficient or "<paramref name="n"/> choose <paramref name="k"/>". Results from arguments that produce an unsigned 64 bit overflow are undefined.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe0"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 64 bit overflow.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="useFactorial"/>' with its <see cref="Promise.Unsafe1"/> flag set may cause a memory access violation for any <paramref name="n"/>! that result in an unsigned 32 bit overflow.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 comb(long4 n, long4 k, Promise useFactorial = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_comb_epi64(n, k, useFactorial.CountUnsafeLevels(), 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.comb_epu64x2(n.xy, n.zw, k.xy, k.zw, out v128 lo, out v128 hi, useFactorial.CountUnsafeLevels());

                return new ulong4(lo, hi);
            }
            else
            {
                return new ulong4(comb(n.xy, k.xy, useFactorial),
                                  comb(n.zw, k.zw, useFactorial));
            }
        }
    }
}