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
            public static v128 bt_epi8(v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 7, elements))
                    {
                        return result == MaskType.One ? srli_epi8(a, 7) : srai_epi8(a, 7);
                    }
                    
                    if (Arm.Neon.IsNeonSupported)
                    {
                        v128 bit = and_si128(set1_epi8(1), srlv_epi8(a, b, inRange: true, elements: elements));

                        return result == MaskType.One ? bit : neg_epi8(bit);
                    }
                    else
                    {
                        // const (all ones) -> 1 instruction with pow2 table
                        v128 powsOf2 = sllv_epi8(set1_epi8(1), b, inRange: true, elements: elements);

                        v128 mask = cmpeq_epi8(powsOf2, and_si128(powsOf2, a));

                        return result == MaskType.One ? negmask_epi8(mask, elements) : mask;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bt_epi8(v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 7))
                    {
                        return result == MaskType.One ? mm256_srli_epi8(a, 7) : mm256_srai_epi8(a, 7);
                    }

                    // const (all ones) -> 1 instruction with pow2 table
                    v256 powsOf2 = mm256_sllv_epi8(mm256_set1_epi8(1), b);

                    v256 mask = Avx2.mm256_cmpeq_epi8(powsOf2, Avx2.mm256_and_si256(powsOf2, a));

                    return result == MaskType.One ? mm256_negmask_epi8(mask) : mask;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bt_epi16(v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 15, elements))
                    {
                        return result == MaskType.One ? srli_epi16(a, 15) : srai_epi16(a, 15);
                    }

                    if (Architecture.IsVectorShiftSupported)
                    {
                        v128 bit = and_si128(set1_epi16(1), srlv_epi16(a, b, inRange: true, elements: elements));

                        return result == MaskType.One ? bit : neg_epi16(bit);
                    }
                    else
                    {
                        v128 powsOf2 = sllv_epi16(set1_epi16(1), b, inRange: true, elements: elements);
                        v128 mask = cmpeq_epi16(powsOf2, and_si128(powsOf2, a));

                        return result == MaskType.One ? negmask_epi16(mask, elements) : mask;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bt_epi16(v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 15))
                    {
                        return result == MaskType.One ? Avx2.mm256_srli_epi16(a, 15) : Avx2.mm256_srai_epi16(a, 15);
                    }

                    v256 bit = Avx2.mm256_and_si256(mm256_set1_epi16(1), mm256_srlv_epi16(a, b));

                    return result == MaskType.One ? bit : mm256_neg_epi16(bit);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bt_epi32(v128 a, v128 b, MaskType result = MaskType.AllOnes, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 31, elements))
                    {
                        return result == MaskType.One ? srli_epi32(a, 31) : srai_epi32(a, 31);
                    }

                    if (result == MaskType.SignBit)
                    {
                        return sllv_epi32(a, sub_epi32(set1_epi32(31), b), inRange: true);
                    }
                    else
                    {
                        v128 bit = and_si128(set1_epi32(1), srlv_epi32(a, b, inRange: true, elements: elements));

                        return result == MaskType.One ? bit : negmask_epi32(bit);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bt_epi32(v256 a, v256 b, MaskType result = MaskType.AllOnes)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(b, 31))
                    {
                        return result == MaskType.One ? Avx2.mm256_srli_epi32(a, 31) : Avx2.mm256_srai_epi32(a, 31);
                    }

                    if (result == MaskType.SignBit)
                    {
                        return Avx2.mm256_sllv_epi32(a, Avx2.mm256_sub_epi32(mm256_set1_epi32(31), b));
                    }
                    else
                    {
                        v256 bit = Avx2.mm256_and_si256(mm256_set1_epi32(1), Avx2.mm256_srlv_epi32(a, b));

                        return result == MaskType.One ? bit : mm256_neg_epi32(bit);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bt_epi64(v128 a, v128 b, MaskType result = MaskType.AllOnes)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, 63))
                    {
                        return result == MaskType.One ? srli_epi64(a, 63) : srai_epi64(a, 63);
                    }

                    if (result == MaskType.SignBit)
                    {
                        return sllv_epi64(a, sub_epi64(set1_epi64x(63), b), inRange: true);
                    }
                    else
                    {
                        v128 bit = and_si128(set1_epi64x(1), srlv_epi64(a, b, inRange: true));

                        return result == MaskType.One ? bit : neg_epi64(bit);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bt_epi64(v256 a, v256 b, MaskType result = MaskType.AllOnes, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(b, 63, elements))
                    {
                        return result == MaskType.One ? Avx2.mm256_srli_epi64(a, 63) : mm256_srai_epi64(a, 63, elements);
                    }

                    if (result == MaskType.SignBit)
                    {
                        return Avx2.mm256_sllv_epi64(a, Avx2.mm256_sub_epi64(mm256_set1_epi64x(63), b));
                    }
                    else
                    {
                        v256 bit = Avx2.mm256_and_si256(mm256_set1_epi64x(1), Avx2.mm256_srlv_epi64(a, b));

                        return result == MaskType.One ? bit : mm256_neg_epi64(bit);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(UInt128 x, ulong i)
        {
            if (constexpr.IS_CONST(i))
            {
                if (i >= 64)
                {
                    return testbit(x.hi64, i - 64);
                }
                else
                {
                    return testbit(x.lo64, i);
                }
            }
            else
            {
                return (x & ((UInt128)1 << (int)i)) != 0;
            }
        }

        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(Int128 x, long i)
        {
            return testbit((UInt128)x, (ulong)i);
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(byte x, byte i)
        {
            return (x & (1 << i)) != 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(byte2 x, byte2 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(Xse.bt_epi8(x, i, MaskType.One, 2));
            }
            else
            {
                return new bool2(testbit(x.x, i.x), testbit(x.y, i.y));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(byte3 x, byte3 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(Xse.bt_epi8(x, i, MaskType.One, 3));
            }
            else
            {
                return new bool3(testbit(x.x, i.x), testbit(x.y, i.y), testbit(x.z, i.z));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(byte4 x, byte4 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(Xse.bt_epi8(x, i, MaskType.One, 4));
            }
            else
            {
                return new bool4(testbit(x.x, i.x), testbit(x.y, i.y), testbit(x.z, i.z), testbit(x.w, i.w));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbit(byte8 x, byte8 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bt_epi8(x, i, MaskType.One, 8);
            }
            else
            {
                return new bool8(testbit(x.x0, i.x0),
                                 testbit(x.x1, i.x1),
                                 testbit(x.x2, i.x2),
                                 testbit(x.x3, i.x3),
                                 testbit(x.x4, i.x4),
                                 testbit(x.x5, i.x5),
                                 testbit(x.x6, i.x6),
                                 testbit(x.x7, i.x7));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbit(byte16 x, byte16 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.bt_epi8(x, i, MaskType.One, 16);
            }
            else
            {
                return new bool16(testbit(x.x0,  i.x0),
                                  testbit(x.x1,  i.x1),
                                  testbit(x.x2,  i.x2),
                                  testbit(x.x3,  i.x3),
                                  testbit(x.x4,  i.x4),
                                  testbit(x.x5,  i.x5),
                                  testbit(x.x6,  i.x6),
                                  testbit(x.x7,  i.x7),
                                  testbit(x.x8,  i.x8),
                                  testbit(x.x9,  i.x9),
                                  testbit(x.x10, i.x10),
                                  testbit(x.x11, i.x11),
                                  testbit(x.x12, i.x12),
                                  testbit(x.x13, i.x13),
                                  testbit(x.x14, i.x14),
                                  testbit(x.x15, i.x15));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 testbit(byte32 x, byte32 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bt_epi8(x, i, MaskType.One);
            }
            else
            {
                return new bool32(testbit(x.v16_0, i.v16_0), testbit(x.v16_16, i.v16_16));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(ushort x, ushort i)
        {
            return (x & (1 << i)) != 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(ushort2 x, ushort2 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(Xse.cvtepi16_epi8(Xse.bt_epi16(x, i, MaskType.One, 2), 2));
            }
            else
            {
                return new bool2(testbit(x.x, i.x), testbit(x.y, i.y));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(ushort3 x, ushort3 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(Xse.cvtepi16_epi8(Xse.bt_epi16(x, i, MaskType.One, 3), 3));
            }
            else
            {
                return new bool3(testbit(x.x, i.x), testbit(x.y, i.y), testbit(x.z, i.z));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(ushort4 x, ushort4 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(Xse.cvtepi16_epi8(Xse.bt_epi16(x, i, MaskType.One, 4), 4));
            }
            else
            {
                return new bool4(testbit(x.x, i.x), testbit(x.y, i.y), testbit(x.z, i.z), testbit(x.w, i.w));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbit(ushort8 x, ushort8 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi8(Xse.bt_epi16(x, i, MaskType.One, 8), 8);
            }
            else
            {
                return new bool8(testbit(x.x0, i.x0),
                                 testbit(x.x1, i.x1),
                                 testbit(x.x2, i.x2),
                                 testbit(x.x3, i.x3),
                                 testbit(x.x4, i.x4),
                                 testbit(x.x5, i.x5),
                                 testbit(x.x6, i.x6),
                                 testbit(x.x7, i.x7));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbit(ushort16 x, ushort16 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi16_epi8(Xse.mm256_bt_epi16(x, i, MaskType.One));
            }
            else
            {
                return new bool16(testbit(x.v8_0, i.v8_0), testbit(x.v8_8, i.v8_8));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(uint x, uint i)
        {
            return (x & (1u << (int)i)) != 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(uint2 x, uint2 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(Xse.cvtepi32_epi8(Xse.bt_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(i), MaskType.One, 2), 2));
            }
            else
            {
                return new bool2(testbit(x.x, i.x), testbit(x.y, i.y));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(uint3 x, uint3 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(Xse.cvtepi32_epi8(Xse.bt_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(i), MaskType.One, 3), 3));
            }
            else
            {
                return new bool3(testbit(x.x, i.x), testbit(x.y, i.y), testbit(x.z, i.z));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(uint4 x, uint4 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(Xse.cvtepi32_epi8(Xse.bt_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(i), MaskType.One, 4), 4));
            }
            else
            {
                return new bool4(testbit(x.x, i.x), testbit(x.y, i.y), testbit(x.z, i.z), testbit(x.w, i.w));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbit(uint8 x, uint8 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi32_epi8(Xse.mm256_bt_epi32(x, i, MaskType.One));
            }
            else
            {
                return new bool8(testbit(x.v4_0, i.v4_0), testbit(x.v4_4, i.v4_4));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(ulong x, ulong i)
        {
            return (x & (1ul << (int)i)) != 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(ulong2 x, ulong2 i)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(Xse.cvtepi64_epi8(Xse.bt_epi64(x, i, MaskType.One)));
            }
            else
            {
                return new bool2(testbit(x.x, i.x), testbit(x.y, i.y));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(ulong3 x, ulong3 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(Xse.mm256_cvtepi64_epi8(Xse.mm256_bt_epi64(x, i, MaskType.One, 3)));
            }
            else
            {
                return new bool3(testbit(x.xy, i.xy), testbit(x.z, i.z));
            }
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(ulong4 x, ulong4 i)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool4(Xse.mm256_cvtepi64_epi8(Xse.mm256_bt_epi64(x, i, MaskType.One, 4)));
            }
            else
            {
                return new bool4(testbit(x.xy, i.xy), testbit(x.zw, i.zw));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(sbyte x, sbyte i)
        {
            return testbit((byte)x, (byte)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(sbyte2 x, sbyte2 i)
        {
            return testbit((byte2)x, (byte2)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(sbyte3 x, sbyte3 i)
        {
            return testbit((byte3)x, (byte3)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(sbyte4 x, sbyte4 i)
        {
            return testbit((byte4)x, (byte4)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbit(sbyte8 x, sbyte8 i)
        {
            return testbit((byte8)x, (byte8)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbit(sbyte16 x, sbyte16 i)
        {
            return testbit((byte16)x, (byte16)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 testbit(sbyte32 x, sbyte32 i)
        {
            return testbit((byte32)x, (byte32)i);
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(short x, short i)
        {
            return testbit((ushort)x, (ushort)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(short2 x, short2 i)
        {
            return testbit((ushort2)x, (ushort2)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(short3 x, short3 i)
        {
            return testbit((ushort3)x, (ushort3)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(short4 x, short4 i)
        {
            return testbit((ushort4)x, (ushort4)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbit(short8 x, short8 i)
        {
            return testbit((ushort8)x, (ushort8)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 testbit(short16 x, short16 i)
        {
            return testbit((ushort16)x, (ushort16)i);
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(int x, int i)
        {
            return testbit((uint)x, (uint)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(int2 x, int2 i)
        {
            return testbit((uint2)x, (uint2)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(int3 x, int3 i)
        {
            return testbit((uint3)x, (uint3)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(int4 x, int4 i)
        {
            return testbit((uint4)x, (uint4)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 testbit(int8 x, int8 i)
        {
            return testbit((uint8)x, (uint8)i);
        }


        /// <summary>       Returns <see langword="true"/> if the bit in <paramref name="x"/> at index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool testbit(long x, long i)
        {
            return testbit((ulong)x, (ulong)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 testbit(long2 x, long2 i)
        {
            return testbit((ulong2)x, (ulong2)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 testbit(long3 x, long3 i)
        {
            return testbit((ulong3)x, (ulong3)i);
        }

        /// <summary>       Returns <see langword="true"/> for each component if its bit at the corresponding index <paramref name="i"/> in LSB order is 1, <see langword="false"/> otherwise.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 testbit(long4 x, long4 i)
        {
            return testbit((ulong4)x, (ulong4)i);
        }
    }
}
