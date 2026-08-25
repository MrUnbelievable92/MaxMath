using System.Runtime.CompilerServices;
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
            public static v128 bzhi_epi8(v128 a, v128 startIndex, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (constexpr.ALL_EQ_EPI8(startIndex, 0, elements))
                    {
                        result = setzero_si128();
                    }
                    else if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 LOOKUP = new v128(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                        result = and_si128(a, shuffle_epi8(LOOKUP, startIndex));
                    }
                    else
                    {
                        v128 ONE = set1_epi8(1);

                        result = and_si128(a, sub_epi8(sllv_epi8(ONE, startIndex, inRange: true, elements: elements), ONE));
                    }

                    Assume.bits_zerohigh(result.Byte0,  a.Byte0,  startIndex.Byte0);
                    Assume.bits_zerohigh(result.Byte1,  a.Byte1,  startIndex.Byte1);
                    Assume.bits_zerohigh(result.Byte2,  a.Byte2,  startIndex.Byte2);
                    Assume.bits_zerohigh(result.Byte3,  a.Byte3,  startIndex.Byte3);
                    Assume.bits_zerohigh(result.Byte4,  a.Byte4,  startIndex.Byte4);
                    Assume.bits_zerohigh(result.Byte5,  a.Byte5,  startIndex.Byte5);
                    Assume.bits_zerohigh(result.Byte6,  a.Byte6,  startIndex.Byte6);
                    Assume.bits_zerohigh(result.Byte7,  a.Byte7,  startIndex.Byte7);
                    Assume.bits_zerohigh(result.Byte8,  a.Byte8,  startIndex.Byte8);
                    Assume.bits_zerohigh(result.Byte9,  a.Byte9,  startIndex.Byte9);
                    Assume.bits_zerohigh(result.Byte10, a.Byte10, startIndex.Byte10);
                    Assume.bits_zerohigh(result.Byte11, a.Byte11, startIndex.Byte11);
                    Assume.bits_zerohigh(result.Byte12, a.Byte12, startIndex.Byte12);
                    Assume.bits_zerohigh(result.Byte13, a.Byte13, startIndex.Byte13);
                    Assume.bits_zerohigh(result.Byte14, a.Byte14, startIndex.Byte14);
                    Assume.bits_zerohigh(result.Byte15, a.Byte15, startIndex.Byte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bzhi_epi16(v128 a, v128 startIndex, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (constexpr.ALL_EQ_EPI16(startIndex, 0, elements))
                    {
                        result = setzero_si128();
                    }
                    else
                    {
                        v128 ONE = set1_epi16(1);

                        result = and_si128(a, sub_epi16(sllv_epi16(ONE, startIndex, inRange: true, elements: elements), ONE));
                    }

                    Assume.bits_zerohigh(result.UShort0,  a.UShort0,  startIndex.UShort0);
                    Assume.bits_zerohigh(result.UShort1,  a.UShort1,  startIndex.UShort1);
                    Assume.bits_zerohigh(result.UShort2,  a.UShort2,  startIndex.UShort2);
                    Assume.bits_zerohigh(result.UShort3,  a.UShort3,  startIndex.UShort3);
                    Assume.bits_zerohigh(result.UShort4,  a.UShort4,  startIndex.UShort4);
                    Assume.bits_zerohigh(result.UShort5,  a.UShort5,  startIndex.UShort5);
                    Assume.bits_zerohigh(result.UShort6,  a.UShort6,  startIndex.UShort6);
                    Assume.bits_zerohigh(result.UShort7,  a.UShort7,  startIndex.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bzhi_epi32(v128 a, v128 startIndex, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (constexpr.ALL_EQ_EPI32(startIndex, 0, elements))
                    {
                        result = setzero_si128();
                    }
                    else
                    {
                        result = andnot_si128(sllv_epi32(setall_si128(), startIndex, inRange: true, elements: elements), a);
                    }

                    Assume.bits_zerohigh(result.UInt0, a.UInt0, startIndex.UInt0);
                    Assume.bits_zerohigh(result.UInt1, a.UInt1, startIndex.UInt1);
                    Assume.bits_zerohigh(result.UInt2, a.UInt2, startIndex.UInt2);
                    Assume.bits_zerohigh(result.UInt3, a.UInt3, startIndex.UInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 bzhi_epi64(v128 a, v128 startIndex)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (constexpr.ALL_EQ_EPI64(startIndex, 0))
                    {
                        result = setzero_si128();
                    }
                    else
                    {
                        result = andnot_si128(sllv_epi64(setall_si128(), startIndex, inRange: true), a);
                    }

                    Assume.bits_zerohigh(result.ULong0, a.ULong0, startIndex.ULong0);
                    Assume.bits_zerohigh(result.ULong1, a.ULong1, startIndex.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi8(v256 a, v256 startIndex)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_EQ_EPI8(startIndex, 0))
                    {
                        result = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        v256 LOOKUP = new v256(0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111,
                                               0b0000_0000, 0b0000_0001, 0b0000_0011, 0b0000_0111, 0b0000_1111, 0b0001_1111, 0b0011_1111, 0b0111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111, 0b1111_1111);

                        result = Avx2.mm256_and_si256(a, Avx2.mm256_shuffle_epi8(LOOKUP, startIndex));
                    }

                    Assume.bits_zerohigh(result.Byte0,  a.Byte0,  startIndex.Byte0);
                    Assume.bits_zerohigh(result.Byte1,  a.Byte1,  startIndex.Byte1);
                    Assume.bits_zerohigh(result.Byte2,  a.Byte2,  startIndex.Byte2);
                    Assume.bits_zerohigh(result.Byte3,  a.Byte3,  startIndex.Byte3);
                    Assume.bits_zerohigh(result.Byte4,  a.Byte4,  startIndex.Byte4);
                    Assume.bits_zerohigh(result.Byte5,  a.Byte5,  startIndex.Byte5);
                    Assume.bits_zerohigh(result.Byte6,  a.Byte6,  startIndex.Byte6);
                    Assume.bits_zerohigh(result.Byte7,  a.Byte7,  startIndex.Byte7);
                    Assume.bits_zerohigh(result.Byte8,  a.Byte8,  startIndex.Byte8);
                    Assume.bits_zerohigh(result.Byte9,  a.Byte9,  startIndex.Byte9);
                    Assume.bits_zerohigh(result.Byte10, a.Byte10, startIndex.Byte10);
                    Assume.bits_zerohigh(result.Byte11, a.Byte11, startIndex.Byte11);
                    Assume.bits_zerohigh(result.Byte12, a.Byte12, startIndex.Byte12);
                    Assume.bits_zerohigh(result.Byte13, a.Byte13, startIndex.Byte13);
                    Assume.bits_zerohigh(result.Byte14, a.Byte14, startIndex.Byte14);
                    Assume.bits_zerohigh(result.Byte15, a.Byte15, startIndex.Byte15);
                    Assume.bits_zerohigh(result.Byte16, a.Byte16, startIndex.Byte16);
                    Assume.bits_zerohigh(result.Byte17, a.Byte17, startIndex.Byte17);
                    Assume.bits_zerohigh(result.Byte18, a.Byte18, startIndex.Byte18);
                    Assume.bits_zerohigh(result.Byte19, a.Byte19, startIndex.Byte19);
                    Assume.bits_zerohigh(result.Byte20, a.Byte20, startIndex.Byte20);
                    Assume.bits_zerohigh(result.Byte21, a.Byte21, startIndex.Byte21);
                    Assume.bits_zerohigh(result.Byte22, a.Byte22, startIndex.Byte22);
                    Assume.bits_zerohigh(result.Byte23, a.Byte23, startIndex.Byte23);
                    Assume.bits_zerohigh(result.Byte24, a.Byte24, startIndex.Byte24);
                    Assume.bits_zerohigh(result.Byte25, a.Byte25, startIndex.Byte25);
                    Assume.bits_zerohigh(result.Byte26, a.Byte26, startIndex.Byte26);
                    Assume.bits_zerohigh(result.Byte27, a.Byte27, startIndex.Byte27);
                    Assume.bits_zerohigh(result.Byte28, a.Byte28, startIndex.Byte28);
                    Assume.bits_zerohigh(result.Byte29, a.Byte29, startIndex.Byte29);
                    Assume.bits_zerohigh(result.Byte30, a.Byte30, startIndex.Byte30);
                    Assume.bits_zerohigh(result.Byte31, a.Byte31, startIndex.Byte31);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi16(v256 a, v256 startIndex)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_EQ_EPI16(startIndex, 0))
                    {
                        result = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        v256 ONE = mm256_set1_epi16(1);

                        result = Avx2.mm256_and_si256(a, Avx2.mm256_sub_epi16(mm256_sllv_epi16(ONE, startIndex), ONE));
                    }

                    Assume.bits_zerohigh(result.UShort0,  a.UShort0,  startIndex.UShort0);
                    Assume.bits_zerohigh(result.UShort1,  a.UShort1,  startIndex.UShort1);
                    Assume.bits_zerohigh(result.UShort2,  a.UShort2,  startIndex.UShort2);
                    Assume.bits_zerohigh(result.UShort3,  a.UShort3,  startIndex.UShort3);
                    Assume.bits_zerohigh(result.UShort4,  a.UShort4,  startIndex.UShort4);
                    Assume.bits_zerohigh(result.UShort5,  a.UShort5,  startIndex.UShort5);
                    Assume.bits_zerohigh(result.UShort6,  a.UShort6,  startIndex.UShort6);
                    Assume.bits_zerohigh(result.UShort7,  a.UShort7,  startIndex.UShort7);
                    Assume.bits_zerohigh(result.UShort8,  a.UShort8,  startIndex.UShort8);
                    Assume.bits_zerohigh(result.UShort9,  a.UShort9,  startIndex.UShort9);
                    Assume.bits_zerohigh(result.UShort10, a.UShort10, startIndex.UShort10);
                    Assume.bits_zerohigh(result.UShort11, a.UShort11, startIndex.UShort11);
                    Assume.bits_zerohigh(result.UShort12, a.UShort12, startIndex.UShort12);
                    Assume.bits_zerohigh(result.UShort13, a.UShort13, startIndex.UShort13);
                    Assume.bits_zerohigh(result.UShort14, a.UShort14, startIndex.UShort14);
                    Assume.bits_zerohigh(result.UShort15, a.UShort15, startIndex.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi32(v256 a, v256 startIndex)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_EQ_EPI32(startIndex, 0))
                    {
                        result = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi32(mm256_setall_si256(), startIndex), a);
                    }

                    Assume.bits_zerohigh(result.UInt0, a.UInt0, startIndex.UInt0);
                    Assume.bits_zerohigh(result.UInt1, a.UInt1, startIndex.UInt1);
                    Assume.bits_zerohigh(result.UInt2, a.UInt2, startIndex.UInt2);
                    Assume.bits_zerohigh(result.UInt3, a.UInt3, startIndex.UInt3);
                    Assume.bits_zerohigh(result.UInt4, a.UInt4, startIndex.UInt4);
                    Assume.bits_zerohigh(result.UInt5, a.UInt5, startIndex.UInt5);
                    Assume.bits_zerohigh(result.UInt6, a.UInt6, startIndex.UInt6);
                    Assume.bits_zerohigh(result.UInt7, a.UInt7, startIndex.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_bzhi_epi64(v256 a, v256 startIndex, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_EQ_EPI64(startIndex, 0, elements))
                    {
                        result = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_sllv_epi64(mm256_setall_si256(), startIndex), a);
                    }

                    Assume.bits_zerohigh(result.ULong0, a.ULong0, startIndex.ULong0);
                    Assume.bits_zerohigh(result.ULong1, a.ULong1, startIndex.ULong1);
                    Assume.bits_zerohigh(result.ULong2, a.ULong2, startIndex.ULong2);
                    Assume.bits_zerohigh(result.ULong3, a.ULong3, startIndex.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_zerohigh(byte result, byte x, byte index)
        {
            if (constexpr.IS_TRUE(index <= 7))
            {
                constexpr.ASSUME(math.lzcnt(result) >= 8 - index);
                constexpr.ASSUME(math.countbits(result) <= index);
                constexpr.ASSUME(result <= x);
                constexpr.ASSUME(result <= (byte)((1 << index) - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_zerohigh(ushort result, ushort x, ushort index)
        {
            if (constexpr.IS_TRUE(index <= 15))
            {
                constexpr.ASSUME(math.lzcnt(result) >= 16 - index);
                constexpr.ASSUME(math.countbits(result) <= index);
                constexpr.ASSUME(result <= x);
                constexpr.ASSUME(result <= (ushort)((1 << index) - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_zerohigh(uint result, uint x, uint index)
        {
            if (constexpr.IS_TRUE(index <= 31))
            {
                constexpr.ASSUME(math.lzcnt(result) >= 32 - index);
                constexpr.ASSUME(math.countbits(result) <= index);
                constexpr.ASSUME(result <= x);
                constexpr.ASSUME(result <= (uint)((1ul << (int)index) - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void bits_zerohigh(ulong result, ulong x, ulong index)
        {
            if (constexpr.IS_TRUE(index <= 63))
            {
                constexpr.ASSUME(math.lzcnt(result) >= 64 - index);
                constexpr.ASSUME(math.countbits(result) <= index);
                constexpr.ASSUME(result <= x);
                constexpr.ASSUME(result <= (ulong)(((UInt128)1 << (int)index) - 1));
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_zerohigh(Int128 x, int startIndex)
        {
            return (Int128)bits_zerohigh((UInt128)x, startIndex);
        }

        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_zerohigh(UInt128 x, int startIndex)
        {
            UInt128 result = andnot(x, UInt128.MaxValue << startIndex);
            
            if (constexpr.IS_TRUE(startIndex <= 127))
            {
                constexpr.ASSUME(math.lzcnt(result) >= 128 - startIndex);
                constexpr.ASSUME(math.countbits(result) <= startIndex);
                constexpr.ASSUME(result <= x);
                constexpr.ASSUME(result <= (UInt128)(((__UInt256__)1 << (int)startIndex) - 1));
            }

            return result;
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_zerohigh(byte x, int startIndex)
        {
            return (byte)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_zerohigh(byte2 x, byte2 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi8(x, startIndex, 2);
            }
            else
            {
                return new byte2(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_zerohigh(byte3 x, byte3 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi8(x, startIndex, 3);
            }
            else
            {
                return new byte3(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_zerohigh(byte4 x, byte4 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi8(x, startIndex, 4);
            }
            else
            {
                return new byte4(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z), bits_zerohigh(x.w, startIndex.w));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_zerohigh(byte8 x, byte8 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi8(x, startIndex, 8);
            }
            else
            {
                return new byte8(bits_zerohigh(x.x0, startIndex.x0), bits_zerohigh(x.x1, startIndex.x1), bits_zerohigh(x.x2, startIndex.x2), bits_zerohigh(x.x3, startIndex.x3), bits_zerohigh(x.x4, startIndex.x4), bits_zerohigh(x.x5, startIndex.x5), bits_zerohigh(x.x6, startIndex.x6), bits_zerohigh(x.x7, startIndex.x7));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_zerohigh(byte16 x, byte16 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi8(x, startIndex, 16);
            }
            else
            {
                return new byte16(bits_zerohigh(x.x0, startIndex.x0), bits_zerohigh(x.x1, startIndex.x1), bits_zerohigh(x.x2, startIndex.x2), bits_zerohigh(x.x3, startIndex.x3), bits_zerohigh(x.x4, startIndex.x4), bits_zerohigh(x.x5, startIndex.x5), bits_zerohigh(x.x6, startIndex.x6), bits_zerohigh(x.x7, startIndex.x7), bits_zerohigh(x.x8, startIndex.x8), bits_zerohigh(x.x9, startIndex.x9), bits_zerohigh(x.x10, startIndex.x10), bits_zerohigh(x.x11, startIndex.x11), bits_zerohigh(x.x12, startIndex.x12), bits_zerohigh(x.x13, startIndex.x13), bits_zerohigh(x.x14, startIndex.x14), bits_zerohigh(x.x15, startIndex.x15));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_zerohigh(byte32 x, byte32 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi8(x, startIndex);
            }
            else
            {
                return new byte32(bits_zerohigh(x.v16_0, startIndex.v16_0), bits_zerohigh(x.v16_16, startIndex.v16_16));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_zerohigh(sbyte x, int startIndex)
        {
            return (sbyte)bits_zerohigh((byte)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_zerohigh(sbyte2 x, sbyte2 startIndex)
        {
            return (sbyte2)bits_zerohigh((byte2)x, (byte2)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_zerohigh(sbyte3 x, sbyte3 startIndex)
        {
            return (sbyte3)bits_zerohigh((byte3)x, (byte3)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_zerohigh(sbyte4 x, sbyte4 startIndex)
        {
            return (sbyte4)bits_zerohigh((byte4)x, (byte4)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_zerohigh(sbyte8 x, sbyte8 startIndex)
        {
            return (sbyte8)bits_zerohigh((byte8)x, (byte8)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_zerohigh(sbyte16 x, sbyte16 startIndex)
        {
            return (sbyte16)bits_zerohigh((byte16)x, (byte16)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_zerohigh(sbyte32 x, sbyte32 startIndex)
        {
            return (sbyte32)bits_zerohigh((byte32)x, (byte32)startIndex);
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_zerohigh(ushort x, int startIndex)
        {
            return (ushort)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_zerohigh(ushort2 x, ushort2 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi16(x, startIndex, 2);
            }
            else
            {
                return new ushort2(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_zerohigh(ushort3 x, ushort3 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi16(x, startIndex, 3);
            }
            else
            {
                return new ushort3(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_zerohigh(ushort4 x, ushort4 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi16(x, startIndex, 4);
            }
            else
            {
                return new ushort4(bits_zerohigh(x.x, startIndex.x), bits_zerohigh(x.y, startIndex.y), bits_zerohigh(x.z, startIndex.z), bits_zerohigh(x.w, startIndex.w));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_zerohigh(ushort8 x, ushort8 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi16(x, startIndex, 8);
            }
            else
            {
                return new ushort8(bits_zerohigh(x.x0, startIndex.x0), bits_zerohigh(x.x1, startIndex.x1), bits_zerohigh(x.x2, startIndex.x2), bits_zerohigh(x.x3, startIndex.x3), bits_zerohigh(x.x4, startIndex.x4), bits_zerohigh(x.x5, startIndex.x5), bits_zerohigh(x.x6, startIndex.x6), bits_zerohigh(x.x7, startIndex.x7));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_zerohigh(ushort16 x, ushort16 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi16(x, startIndex);
            }
            else
            {
                return new ushort16(bits_zerohigh(x.v8_0, startIndex.v8_0), bits_zerohigh(x.v8_8, startIndex.v8_8));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_zerohigh(short x, int startIndex)
        {
            return (short)bits_zerohigh((ushort)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_zerohigh(short2 x, short2 startIndex)
        {
            return (short2)bits_zerohigh((ushort2)x, (ushort2)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_zerohigh(short3 x, short3 startIndex)
        {
            return (short3)bits_zerohigh((ushort3)x, (ushort3)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_zerohigh(short4 x, short4 startIndex)
        {
            return (short4)bits_zerohigh((ushort4)x, (ushort4)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_zerohigh(short8 x, short8 startIndex)
        {
            return (short8)bits_zerohigh((ushort8)x, (ushort8)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_zerohigh(short16 x, short16 startIndex)
        {
            return (short16)bits_zerohigh((ushort16)x, (ushort16)startIndex);
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_zerohigh(uint x, int startIndex)
        {
            uint result;

            if (Bmi2.IsBmi2Supported)
            {
                result = Bmi2.bzhi_u32(x, (uint)startIndex);
            }
            else
            {
                result = andnot(x, uint.MaxValue << startIndex);
            }

            Assume.bits_zerohigh(result, x, (uint)startIndex);

            return result;
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_zerohigh(uint2 x, uint2 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi32(x, startIndex, 2);
            }
            else
            {
                return new uint2(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_zerohigh(uint3 x, uint3 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi32(x, startIndex, 3);
            }
            else
            {
                return new uint3(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y), bits_zerohigh(x.z, (int)startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_zerohigh(uint4 x, uint4 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi32(x, startIndex, 4);
            }
            else
            {
                return new uint4(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y), bits_zerohigh(x.z, (int)startIndex.z), bits_zerohigh(x.w, (int)startIndex.w));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_zerohigh(uint8 x, uint8 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi32(x, startIndex);
            }
            else
            {
                return new uint8(bits_zerohigh(x.v4_0, startIndex.v4_0), bits_zerohigh(x.v4_4, startIndex.v4_4));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_zerohigh(int x, int startIndex)
        {
            return (int)bits_zerohigh((uint)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_zerohigh(int2 x, int2 startIndex)
        {
            return (int2)bits_zerohigh((uint2)x, (uint2)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_zerohigh(int3 x, int3 startIndex)
        {
            return (int3)bits_zerohigh((uint3)x, (uint3)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_zerohigh(int4 x, int4 startIndex)
        {
            return (int4)bits_zerohigh((uint4)x, (uint4)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_zerohigh(int8 x, int8 startIndex)
        {
            return (int8)bits_zerohigh((uint8)x, (uint8)startIndex);
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_zerohigh(ulong x, int startIndex)
        {
            ulong result;

            if (Bmi2.IsBmi2Supported)
            {
                result = Bmi2.bzhi_u64(x, (uint)startIndex);
            }
            else
            {
                result = andnot(x, ulong.MaxValue << startIndex);
            }

            Assume.bits_zerohigh(result, x, (ulong)startIndex);

            return result;
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_zerohigh(ulong2 x, ulong2 startIndex)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.bzhi_epi64(x, startIndex);
            }
            else
            {
                return new ulong2(bits_zerohigh(x.x, (int)startIndex.x), bits_zerohigh(x.y, (int)startIndex.y));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_zerohigh(ulong3 x, ulong3 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi64(x, startIndex, 3);
            }
            else
            {
                return new ulong3(bits_zerohigh(x.xy, startIndex.xy), bits_zerohigh(x.z, (int)startIndex.z));
            }
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_zerohigh(ulong4 x, ulong4 startIndex)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_bzhi_epi64(x, startIndex, 4);
            }
            else
            {
                return new ulong4(bits_zerohigh(x.xy, startIndex.xy), bits_zerohigh(x.zw, startIndex.zw));
            }
        }


        /// <summary>       Zeros out all the high order bits in <paramref name="x"/> starting at bit <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_zerohigh(long x, int startIndex)
        {
            return (long)bits_zerohigh((ulong)x, startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_zerohigh(long2 x, long2 startIndex)
        {
            return (long2)bits_zerohigh((ulong2)x, (ulong2)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_zerohigh(long3 x, long3 startIndex)
        {
            return (long3)bits_zerohigh((ulong3)x, (ulong3)startIndex);
        }

        /// <summary>       Zeros out all the respective high order bits in each <paramref name="x"/> component, starting at the corresponding index <paramref name="startIndex"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_zerohigh(long4 x, long4 startIndex)
        {
            return (long4)bits_zerohigh((ulong4)x, (ulong4)startIndex);
        }
    }
}