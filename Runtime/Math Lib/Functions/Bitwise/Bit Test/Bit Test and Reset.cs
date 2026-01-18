using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 btr_epi8(ref v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 7, elements))
                    {
                        v128 ret = result == MaskType.One ? srli_epi8(a, 7) : srai_epi8(a, 7);
                        a = andnot_si128(set1_epi8(1 << 7), a);

                        return ret;
                    }

                    // const (all ones) -> 1 instruction with pow2 table
                    v128 powsOf2 = sllv_epi8(set1_epi8(1), b, inRange: true, elements: elements);

                    v128 mask = cmpeq_epi8(powsOf2, and_si128(powsOf2, a));
                    a = andnot_si128(powsOf2, a);

                    return result == MaskType.One ? neg_epi8(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btr_epi8(ref v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 7))
                    {
                        v256 ret = result == MaskType.One ? mm256_srli_epi8(a, 7) : mm256_srai_epi8(a, 7);
                        a = Avx2.mm256_andnot_si256(mm256_set1_epi8(1 << 7), a);

                        return ret;
                    }

                    // const (all ones) -> 1 instruction with pow2 table
                    v256 powsOf2 = mm256_sllv_epi8(mm256_set1_epi8(1), b);

                    v256 mask = Avx2.mm256_cmpeq_epi8(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_andnot_si256(powsOf2, a);

                    return result == MaskType.One ? mm256_neg_epi8(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 btr_epi16(ref v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 15, elements))
                    {
                        v128 ret = result == MaskType.One ? srli_epi16(a, 15) : srai_epi16(a, 15);
                        a = or_si128(a, set1_epi16(1 << 15));

                        return ret;
                    }

                    v128 powsOf2 = sllv_epi16(set1_epi16(1), b, inRange: true, elements: elements);
                    v128 mask = cmpeq_epi16(powsOf2, and_si128(powsOf2, a));
                    a = andnot_si128(powsOf2, a);

                    return result == MaskType.One ? neg_epi16(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btr_epi16(ref v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 15))
                    {
                        v256 ret = result == MaskType.One ? Avx2.mm256_srli_epi16(a, 15) : Avx2.mm256_srai_epi16(a, 15);
                        a = Avx2.mm256_andnot_si256(mm256_set1_epi16(1 << 15), a);

                        return ret;
                    }

                    v256 powsOf2 = mm256_sllv_epi16(mm256_set1_epi16(1), b);
                    v256 mask = Avx2.mm256_cmpeq_epi16(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_andnot_si256(powsOf2, a);

                    return result == MaskType.One ? mm256_neg_epi16(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 btr_epi32(ref v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 4)
            {
            if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 31, elements))
                    {
                        v128 ret = result == MaskType.One ? srli_epi32(a, 31) : srai_epi32(a, 31);
                        a = or_si128(a, set1_epi32(1 << 31));

                        return ret;
                    }

                    v128 powsOf2 = sllv_epi32(set1_epi32(1), b, inRange: true, elements: elements);
                    v128 mask = cmpeq_epi32(powsOf2, and_si128(powsOf2, a));
                    a = andnot_si128(powsOf2, a);

                    return result == MaskType.One ? neg_epi32(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btr_epi32(ref v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 31))
                    {
                        v256 ret = result == MaskType.One ? Avx2.mm256_srli_epi32(a, 31) : Avx2.mm256_srai_epi32(a, 31);
                        a = Avx2.mm256_andnot_si256(mm256_set1_epi32(1 << 31), a);

                        return ret;
                    }

                    v256 powsOf2 = Avx2.mm256_sllv_epi32(mm256_set1_epi32(1), b);
                    v256 mask = Avx2.mm256_cmpeq_epi32(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_andnot_si256(powsOf2, a);

                    return result == MaskType.One ? mm256_neg_epi32(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 btr_epi64(ref v128 a, v128 b, MaskType result = MaskType.AllOnes)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, 63))
                    {
                        v128 ret = result == MaskType.One ? srli_epi64(a, 63) : srai_epi64(a, 63);
                        a = or_si128(a, set1_epi64x(1ul << 63));

                        return ret;
                    }

                    v128 powsOf2 = sllv_epi64(set1_epi64x(1), b, inRange: true);
                    v128 mask = cmpeq_epi64(powsOf2, and_si128(powsOf2, a));
                    a = andnot_si128(powsOf2, a);

                    return result == MaskType.One ? neg_epi64(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_btr_epi64(ref v256 a, v256 b, MaskType result = MaskType.AllOnes, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, 63, elements))
                    {
                        v256 ret = result == MaskType.One ? Avx2.mm256_srli_epi64(a, 63) : mm256_srai_epi64(a, 63, elements);
                        a = Avx2.mm256_andnot_si256(mm256_set1_epi64x(1ul << 63), a);

                        return ret;
                    }

                    v256 powsOf2 = Avx2.mm256_sllv_epi64(mm256_set1_epi64x(1), b);
                    v256 mask = Avx2.mm256_cmpeq_epi64(powsOf2, Avx2.mm256_and_si256(powsOf2, a));
                    a = Avx2.mm256_andnot_si256(powsOf2, a);

                    return result == MaskType.One ? mm256_neg_epi64(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref UInt128 x, ulong i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (i >= 64)
                {
                    ulong __ref = x.hi64;
                    bool result = testbitreset(ref __ref, i - 64);
                    x = new UInt128(x.lo64, __ref);

                    return result;
                }
                else
                {
                    ulong __ref = x.lo64;
                    bool result = testbitreset(ref __ref, i);
                    x = new UInt128(__ref, x.hi64);

                    return result;
                }
            }
            else
            {
                return (x & ((UInt128)1 << (int)i)) != 0;
            }
        }

        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref Int128 x, long i)
        {
            UInt128 __ref = (UInt128)x;
            bool result = testbitreset(ref __ref, (ulong)i);
            x = (Int128)__ref;

            return result;
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref byte x, byte i)
        {
            uint bit = 1u << i;
            bool result = (x & bit) != 0;
            x = andnot(x, (byte)bit);

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref byte2 x, byte2 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool2 result = RegisterConversion.ToBool2(Xse.btr_epi8(ref __ref, i, MaskType.One, 2));
                x = __ref;

                return result;
            }
            else
            {
                return new bool2(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref byte3 x, byte3 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool3 result = RegisterConversion.ToBool3(Xse.btr_epi8(ref __ref, i, MaskType.One, 3));
                x = __ref;

                return result;
            }
            else
            {
                return new bool3(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y), testbitreset(ref x.z, i.z));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref byte4 x, byte4 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool4 result = RegisterConversion.ToBool4(Xse.btr_epi8(ref __ref, i, MaskType.One, 4));
                x = __ref;

                return result;
            }
            else
            {
                return new bool4(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y), testbitreset(ref x.z, i.z), testbitreset(ref x.w, i.w));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitreset(ref byte8 x, byte8 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool8 result = Xse.btr_epi8(ref __ref, i, MaskType.One, 8);
                x = __ref;

                return result;
            }
            else
            {
                return new bool8(testbitreset(ref x.x0, i.x0),
                                 testbitreset(ref x.x1, i.x1),
                                 testbitreset(ref x.x2, i.x2),
                                 testbitreset(ref x.x3, i.x3),
                                 testbitreset(ref x.x4, i.x4),
                                 testbitreset(ref x.x5, i.x5),
                                 testbitreset(ref x.x6, i.x6),
                                 testbitreset(ref x.x7, i.x7));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitreset(ref byte16 x, byte16 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool16 result = Xse.btr_epi8(ref __ref, i, MaskType.One, 16);
                x = __ref;

                return result;
            }
            else
            {
                return new bool16(testbitreset(ref x.x0,  x.x0),
                                  testbitreset(ref x.x1,  x.x1),
                                  testbitreset(ref x.x2,  x.x2),
                                  testbitreset(ref x.x3,  x.x3),
                                  testbitreset(ref x.x4,  x.x4),
                                  testbitreset(ref x.x5,  x.x5),
                                  testbitreset(ref x.x6,  x.x6),
                                  testbitreset(ref x.x7,  x.x7),
                                  testbitreset(ref x.x8,  x.x8),
                                  testbitreset(ref x.x9,  x.x9),
                                  testbitreset(ref x.x10, x.x10),
                                  testbitreset(ref x.x11, x.x11),
                                  testbitreset(ref x.x12, x.x12),
                                  testbitreset(ref x.x13, x.x13),
                                  testbitreset(ref x.x14, x.x14),
                                  testbitreset(ref x.x15, x.x15));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 testbitreset(ref byte32 x, byte32 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool32 result = Xse.mm256_btr_epi8(ref __ref, i, MaskType.One);
                x = __ref;

                return result;
            }
            else
            {
                byte16 xLo = x.v16_0;
                byte16 xHi = x.v16_16;
                bool32 result = new bool32(testbitreset(ref xLo, i.v16_0), testbitreset(ref xHi, i.v16_16));
                x = new byte32(xLo, xHi);

                return result;
            }
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref ushort x, ushort i)
        {
            uint bit = 1u << i;
            bool result = (x & bit) != 0;
            x = andnot(x, (ushort)bit);

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref ushort2 x, ushort2 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool2 result = RegisterConversion.ToBool2(Xse.cvtepi16_epi8(Xse.btr_epi16(ref __ref, i, MaskType.One, 2), 2));
                x = __ref;

                return result;
            }
            else
            {
                return new bool2(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref ushort3 x, ushort3 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool3 result = RegisterConversion.ToBool3(Xse.cvtepi16_epi8(Xse.btr_epi16(ref __ref, i, MaskType.One, 3), 3));
                x = __ref;

                return result;
            }
            else
            {
                return new bool3(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y), testbitreset(ref x.z, i.z));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref ushort4 x, ushort4 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool4 result = RegisterConversion.ToBool4(Xse.cvtepi16_epi8(Xse.btr_epi16(ref __ref, i, MaskType.One, 4), 4));
                x = __ref;

                return result;
            }
            else
            {
                return new bool4(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y), testbitreset(ref x.z, i.z), testbitreset(ref x.w, i.w));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitreset(ref ushort8 x, ushort8 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool8 result = Xse.cvtepi16_epi8(Xse.btr_epi16(ref __ref, i, MaskType.One, 8), 8);
                x = __ref;

                return result;
            }
            else
            {
                return new bool8(testbitreset(ref x.x0, i.x0),
                                 testbitreset(ref x.x1, i.x1),
                                 testbitreset(ref x.x2, i.x2),
                                 testbitreset(ref x.x3, i.x3),
                                 testbitreset(ref x.x4, i.x4),
                                 testbitreset(ref x.x5, i.x5),
                                 testbitreset(ref x.x6, i.x6),
                                 testbitreset(ref x.x7, i.x7));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitreset(ref ushort16 x, ushort16 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool16 result = Xse.mm256_cvtepi16_epi8(Xse.mm256_btr_epi16(ref __ref, i, MaskType.One));
                x = __ref;

                return result;
            }
            else
            {
                ushort8 xLo = x.v8_0;
                ushort8 xHi = x.v8_8;
                bool16 result = new bool16(testbitreset(ref xLo, i.v8_0), testbitreset(ref xHi, i.v8_8));
                x = new ushort16(xLo, xHi);

                return result;
            }
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref uint x, uint i)
        {
            uint bit = 1u << (int)i;
            bool result = (x & bit) != 0;
            x = andnot(x, bit);

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref uint2 x, uint2 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = RegisterConversion.ToV128(x);
                bool2 result = RegisterConversion.ToBool2(Xse.cvtepi32_epi8(Xse.btr_epi32(ref __ref, RegisterConversion.ToV128(i), MaskType.One, 2), 2));
                x = RegisterConversion.ToUInt2(__ref);

                return result;
            }
            else
            {
                return new bool2(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref uint3 x, uint3 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = RegisterConversion.ToV128(x);
                bool3 result = RegisterConversion.ToBool3(Xse.cvtepi32_epi8(Xse.btr_epi32(ref __ref, RegisterConversion.ToV128(i), MaskType.One, 3), 3));
                x = RegisterConversion.ToUInt3(__ref);

                return result;
            }
            else
            {
                return new bool3(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y), testbitreset(ref x.z, i.z));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref uint4 x, uint4 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = RegisterConversion.ToV128(x);
                bool4 result = RegisterConversion.ToBool4(Xse.cvtepi32_epi8(Xse.btr_epi32(ref __ref, RegisterConversion.ToV128(i), MaskType.One, 4), 4));
                x = RegisterConversion.ToUInt4(__ref);

                return result;
            }
            else
            {
                return new bool4(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y), testbitreset(ref x.z, i.z), testbitreset(ref x.w, i.w));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitreset(ref uint8 x, uint8 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool8 result = Xse.mm256_cvtepi32_epi8(Xse.mm256_btr_epi32(ref __ref, i, MaskType.One));
                x = __ref;

                return result;
            }
            else
            {
                uint4 xLo = x.v4_0;
                uint4 xHi = x.v4_4;
                bool8 result = new bool8(testbitreset(ref xLo, i.v4_0), testbitreset(ref xHi, i.v4_4));
                x = new uint8(xLo, xHi);

                return result;
            }
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref ulong x, ulong i)
        {
            ulong bit = 1ul << (int)i;
            bool result = (x & bit) != 0;
            x = andnot(x, bit);

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref ulong2 x, ulong2 i)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 __ref = x;
                bool2 result = RegisterConversion.ToBool2(Xse.cvtepi64_epi8(Xse.btr_epi64(ref __ref, i, MaskType.One)));
                x = __ref;

                return result;
            }
            else
            {
                return new bool2(testbitreset(ref x.x, i.x), testbitreset(ref x.y, i.y));
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref ulong3 x, ulong3 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool3 result = RegisterConversion.ToBool3(Xse.mm256_cvtepi64_epi8(Xse.mm256_btr_epi64(ref __ref, i, MaskType.One)));
                x = __ref;

                return result;
            }
            else
            {
                ulong2 __ref = x.xy;
                bool3 result = new bool3(testbitreset(ref __ref, i.xy), testbitreset(ref x.z, i.z));
                x = new ulong3(__ref, x.z);

                return result;
            }
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref ulong4 x, ulong4 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __ref = x;
                bool4 result = RegisterConversion.ToBool4(Xse.mm256_cvtepi64_epi8(Xse.mm256_btr_epi64(ref __ref, i, MaskType.One)));
                x = __ref;

                return result;
            }
            else
            {
                ulong2 __xy = x.xy;
                ulong2 __zw = x.zw;
                bool4 result = new bool4(testbitreset(ref __xy, i.xy), testbitreset(ref __zw, i.zw));
                x = new ulong4(__xy, __zw);

                return result;
            }
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref sbyte x, sbyte i)
        {
            byte __ref = (byte)x;
            bool result = testbitreset(ref __ref, (byte)i);
            x = (sbyte)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref sbyte2 x, sbyte2 i)
        {
            byte2 __ref = (byte2)x;
            bool2 result = testbitreset(ref __ref, (byte2)i);
            x = (sbyte2)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref sbyte3 x, sbyte3 i)
        {
            byte3 __ref = (byte3)x;
            bool3 result = testbitreset(ref __ref, (byte3)i);
            x = (sbyte3)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref sbyte4 x, sbyte4 i)
        {
            byte4 __ref = (byte4)x;
            bool4 result = testbitreset(ref __ref, (byte4)i);
            x = (sbyte4)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitreset(ref sbyte8 x, sbyte8 i)
        {
            byte8 __ref = (byte8)x;
            bool8 result = testbitreset(ref __ref, (byte8)i);
            x = (sbyte8)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitreset(ref sbyte16 x, sbyte16 i)
        {
            byte16 __ref = (byte16)x;
            bool16 result = testbitreset(ref __ref, (byte16)i);
            x = (sbyte16)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 testbitreset(ref sbyte32 x, sbyte32 i)
        {
            byte32 __ref = (byte32)x;
            bool32 result = testbitreset(ref __ref, (byte32)i);
            x = (sbyte32)__ref;

            return result;
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref short x, short i)
        {
            ushort __ref = (ushort)x;
            bool result = testbitreset(ref __ref, (ushort)i);
            x = (short)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref short2 x, short2 i)
        {
            ushort2 __ref = (ushort2)x;
            bool2 result = testbitreset(ref __ref, (ushort2)i);
            x = (short2)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref short3 x, short3 i)
        {
            ushort3 __ref = (ushort3)x;
            bool3 result = testbitreset(ref __ref, (ushort3)i);
            x = (short3)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref short4 x, short4 i)
        {
            ushort4 __ref = (ushort4)x;
            bool4 result = testbitreset(ref __ref, (ushort4)i);
            x = (short4)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitreset(ref short8 x, short8 i)
        {
            ushort8 __ref = (ushort8)x;
            bool8 result = testbitreset(ref __ref, (ushort8)i);
            x = (short8)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbitreset(ref short16 x, short16 i)
        {
            ushort16 __ref = (ushort16)x;
            bool16 result = testbitreset(ref __ref, (ushort16)i);
            x = (short16)__ref;

            return result;
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref int x, int i)
        {
            uint __ref = (uint)x;
            bool result = testbitreset(ref __ref, (uint)i);
            x = (int)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref int2 x, int2 i)
        {
            uint2 __ref = (uint2)x;
            bool2 result = testbitreset(ref __ref, (uint2)i);
            x = (int2)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref int3 x, int3 i)
        {
            uint3 __ref = (uint3)x;
            bool3 result = testbitreset(ref __ref, (uint3)i);
            x = (int3)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref int4 x, int4 i)
        {
            uint4 __ref = (uint4)x;
            bool4 result = testbitreset(ref __ref, (uint4)i);
            x = (int4)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbitreset(ref int8 x, int8 i)
        {
            uint8 __ref = (uint8)x;
            bool8 result = testbitreset(ref __ref, (uint8)i);
            x = (int8)__ref;

            return result;
        }


        /// <summary>       Resets the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbitreset(ref long x, long i)
        {
            ulong __ref = (ulong)x;
            bool result = testbitreset(ref __ref, (ulong)i);
            x = (long)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbitreset(ref long2 x, long2 i)
        {
            ulong2 __ref = (ulong2)x;
            bool2 result = testbitreset(ref __ref, (ulong2)i);
            x = (long2)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbitreset(ref long3 x, long3 i)
        {
            ulong3 __ref = (ulong3)x;
            bool3 result = testbitreset(ref __ref, (ulong3)i);
            x = (long3)__ref;

            return result;
        }

        /// <summary>       Resets the bit in each component of <paramref name="x"/> at the corresponding index in <paramref name="i"/> in LSB order to 0 and returns <see langword="true"/> for that component if the bit was previously set, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbitreset(ref long4 x, long4 i)
        {
            ulong4 __ref = (ulong4)x;
            bool4 result = testbitreset(ref __ref, (ulong4)i);
            x = (long4)__ref;

            return result;
        }
    }
}
