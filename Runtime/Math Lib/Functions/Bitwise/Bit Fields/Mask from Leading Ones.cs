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
            public static v128 l1msk_epi8(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsTableLookupSupported)
                    {
                        v128 SHUFFLE_MASK_LO = new v128(0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1100, 0b1111_1100, 0b1111_1110, 0b1111_1111);
                        v128 SHUFFLE_MASK_HI = new v128(0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1100_0000, 0b1100_0000, 0b1110_0000, 0b1111_1111);

                        result = min_epu8(shuffle_epi8(SHUFFLE_MASK_LO, and_si128(NIBBLE_MASK, a)),
                                        shuffle_epi8(SHUFFLE_MASK_HI, and_si128(NIBBLE_MASK, srli_epi16(a, 4))));
                    }
                    else
                    {
                        result = sllv_epi8(setall_si128(), sub_epi8(set1_epi8(8), l1cnt_epi8(a)));
                    }

                    Assume.l1mask(result.Byte0,  a.Byte0);
                    Assume.l1mask(result.Byte1,  a.Byte1);
                    Assume.l1mask(result.Byte2,  a.Byte2);
                    Assume.l1mask(result.Byte3,  a.Byte3);
                    Assume.l1mask(result.Byte4,  a.Byte4);
                    Assume.l1mask(result.Byte5,  a.Byte5);
                    Assume.l1mask(result.Byte6,  a.Byte6);
                    Assume.l1mask(result.Byte7,  a.Byte7);
                    Assume.l1mask(result.Byte8,  a.Byte8);
                    Assume.l1mask(result.Byte9,  a.Byte9);
                    Assume.l1mask(result.Byte10, a.Byte10);
                    Assume.l1mask(result.Byte11, a.Byte11);
                    Assume.l1mask(result.Byte12, a.Byte12);
                    Assume.l1mask(result.Byte13, a.Byte13);
                    Assume.l1mask(result.Byte14, a.Byte14);
Assume.l1mask(result.Byte15, a.Byte15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1msk_epi16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    v128 BLEND_MASK = set1_epi16(0xFF00);
                    v128 byteMasks = l1msk_epi8(a);
                    v128 low = and_si128(byteMasks, srli_epi16(cmpeq_epi8(byteMasks, BLEND_MASK), 8));

                    if (BurstArchitecture.IsBlendSupported)
                    {
                        result = blendv_si128(low, byteMasks, BLEND_MASK);
                    }
                    else
                    {
                        result = or_si128(low, and_si128(BLEND_MASK, byteMasks));
                    }

                    Assume.l1mask(result.UShort0, a.UShort0);
                    Assume.l1mask(result.UShort1, a.UShort1);
                    Assume.l1mask(result.UShort2, a.UShort2);
                    Assume.l1mask(result.UShort3, a.UShort3);
                    Assume.l1mask(result.UShort4, a.UShort4);
                    Assume.l1mask(result.UShort5, a.UShort5);
                    Assume.l1mask(result.UShort6, a.UShort6);
                    Assume.l1mask(result.UShort7, a.UShort7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1msk_epi32(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsVectorShiftSupported)
                    {
                        result = sllv_epi32(setall_si128(), sub_epi32(set1_epi32(32), l1cnt_epi32(a)));
                    }
                    else
                    {
                        v128 BLEND_MASK = set1_epi32(0xFFFF_0000);
                        v128 shortMasks = l1msk_epi16(a);
                        v128 low = and_si128(shortMasks, srli_epi32(cmpeq_epi16(shortMasks, BLEND_MASK), 16));

                        if (BurstArchitecture.IsBlendSupported)
                        {
                            result = blend_epi16(low, shortMasks, 0b1010_1010);
                        }
                        else
                        {
                            result = or_si128(low, and_si128(BLEND_MASK, shortMasks));
                        }
                    }

                    Assume.l1mask(result.UInt0, a.UInt0);
                    Assume.l1mask(result.UInt1, a.UInt1);
                    Assume.l1mask(result.UInt2, a.UInt2);
                    Assume.l1mask(result.UInt3, a.UInt3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 l1msk_epi64(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (BurstArchitecture.IsVectorShiftSupported)
                    {
                        result = sllv_epi64(setall_si128(), sub_epi64(set1_epi64x(64), l1cnt_epi64(a)));
                    }
                    else
                    {
                        long lo = math.l1mask(cvtsi128_si64x(a));
                        long hi = math.l1mask(cvtsi128_si64x(bsrli_si128(a, sizeof(long))));
                    
                        result = unpacklo_epi64(cvtsi64x_si128(lo), cvtsi64x_si128(hi));
                    }

                    Assume.l1mask(result.ULong0, a.ULong0);
                    Assume.l1mask(result.ULong1, a.ULong1);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 SHUFFLE_MASK_LO = new v256(0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1100, 0b1111_1100, 0b1111_1110, 0b1111_1111,
                                                    0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_0000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1000, 0b1111_1100, 0b1111_1100, 0b1111_1110, 0b1111_1111);
                    v256 SHUFFLE_MASK_HI = new v256(0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1100_0000, 0b1100_0000, 0b1110_0000, 0b1111_1111,
                                                    0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b0000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1000_0000, 0b1100_0000, 0b1100_0000, 0b1110_0000, 0b1111_1111);

                    v256 result = Avx2.mm256_min_epu8(Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_LO, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, a)),
                                                      Avx2.mm256_shuffle_epi8(SHUFFLE_MASK_HI, Avx2.mm256_and_si256(MM256_NIBBLE_MASK, Avx2.mm256_srli_epi16(a, 4))));

                    Assume.l1mask(result.Byte0,  a.Byte0);
                    Assume.l1mask(result.Byte1,  a.Byte1);
                    Assume.l1mask(result.Byte2,  a.Byte2);
                    Assume.l1mask(result.Byte3,  a.Byte3);
                    Assume.l1mask(result.Byte4,  a.Byte4);
                    Assume.l1mask(result.Byte5,  a.Byte5);
                    Assume.l1mask(result.Byte6,  a.Byte6);
                    Assume.l1mask(result.Byte7,  a.Byte7);
                    Assume.l1mask(result.Byte8,  a.Byte8);
                    Assume.l1mask(result.Byte9,  a.Byte9);
                    Assume.l1mask(result.Byte10, a.Byte10);
                    Assume.l1mask(result.Byte11, a.Byte11);
                    Assume.l1mask(result.Byte12, a.Byte12);
                    Assume.l1mask(result.Byte13, a.Byte13);
                    Assume.l1mask(result.Byte14, a.Byte14);
                    Assume.l1mask(result.Byte15, a.Byte15);
                    Assume.l1mask(result.Byte16, a.Byte16);
                    Assume.l1mask(result.Byte17, a.Byte17);
                    Assume.l1mask(result.Byte18, a.Byte18);
                    Assume.l1mask(result.Byte19, a.Byte19);
                    Assume.l1mask(result.Byte20, a.Byte20);
                    Assume.l1mask(result.Byte21, a.Byte21);
                    Assume.l1mask(result.Byte22, a.Byte22);
                    Assume.l1mask(result.Byte23, a.Byte23);
                    Assume.l1mask(result.Byte24, a.Byte24);
                    Assume.l1mask(result.Byte25, a.Byte25);
                    Assume.l1mask(result.Byte26, a.Byte26);
                    Assume.l1mask(result.Byte27, a.Byte27);
                    Assume.l1mask(result.Byte28, a.Byte28);
                    Assume.l1mask(result.Byte29, a.Byte29);
                    Assume.l1mask(result.Byte30, a.Byte30);
                    Assume.l1mask(result.Byte31, a.Byte31);

                        return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 BLEND_MASK = mm256_set1_epi16(0xFF00);
                    v256 byteMasks = mm256_l1msk_epi8(a);
                    v256 low = Avx2.mm256_and_si256(byteMasks, Avx2.mm256_srli_epi16(Avx2.mm256_cmpeq_epi8(byteMasks, BLEND_MASK), 8));

                    v256 result = mm256_blendv_si256(low, byteMasks, BLEND_MASK);

                    Assume.l1mask(result.UShort0,  a.UShort0);
                    Assume.l1mask(result.UShort1,  a.UShort1);
                    Assume.l1mask(result.UShort2,  a.UShort2);
                    Assume.l1mask(result.UShort3,  a.UShort3);
                    Assume.l1mask(result.UShort4,  a.UShort4);
                    Assume.l1mask(result.UShort5,  a.UShort5);
                    Assume.l1mask(result.UShort6,  a.UShort6);
                    Assume.l1mask(result.UShort7,  a.UShort7);
                    Assume.l1mask(result.UShort8,  a.UShort8);
                    Assume.l1mask(result.UShort9,  a.UShort9);
                    Assume.l1mask(result.UShort10, a.UShort10);
                    Assume.l1mask(result.UShort11, a.UShort11);
                    Assume.l1mask(result.UShort12, a.UShort12);
                    Assume.l1mask(result.UShort13, a.UShort13);
                    Assume.l1mask(result.UShort14, a.UShort14);
                    Assume.l1mask(result.UShort15, a.UShort15);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sllv_epi32(mm256_setall_si256(), Avx2.mm256_sub_epi32(mm256_set1_epi32(32), mm256_l1cnt_epi32(a)));

                    Assume.l1mask(result.UInt0, a.UInt0);
                    Assume.l1mask(result.UInt1, a.UInt1);
                    Assume.l1mask(result.UInt2, a.UInt2);
                    Assume.l1mask(result.UInt3, a.UInt3);
                    Assume.l1mask(result.UInt4, a.UInt4);
                    Assume.l1mask(result.UInt5, a.UInt5);
                    Assume.l1mask(result.UInt6, a.UInt6);
                    Assume.l1mask(result.UInt7, a.UInt7);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_l1msk_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sllv_epi64(mm256_setall_si256(), Avx2.mm256_sub_epi64(mm256_set1_epi64x(64), mm256_l1cnt_epi64(a)));

                    Assume.l1mask(result.ULong0, a.ULong0);
                    Assume.l1mask(result.ULong1, a.ULong1);
                    Assume.l1mask(result.ULong2, a.ULong2);
                    Assume.l1mask(result.ULong3, a.ULong3);

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    unsafe internal static partial class Assume
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void l1mask(byte result, byte x)
        {
            constexpr.ASSUME(result == (byte)((byte.MaxValue << (8 - math.l1cnt(x)))));
    
            int k = math.l1cnt(x);
            constexpr.ASSUME(math.countbits(result) == k);
            constexpr.ASSUME(result == (byte)(((1u << k) - 1) << (8 - k)));
            constexpr.ASSUME((result & (byte)((1u << (8 - k)) - 1)) == 0);
            constexpr.ASSUME((x & result) == result);
            constexpr.ASSUME((x | result) == x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void l1mask(ushort result, ushort x)
        {
            constexpr.ASSUME(result == (ushort)((ushort.MaxValue << (16 - math.l1cnt(x)))));
    
            int k = math.l1cnt(x);
            constexpr.ASSUME(math.countbits(result) == k);
            constexpr.ASSUME(result == (ushort)(((1u << k) - 1) << (16 - k)));
            constexpr.ASSUME((result & (ushort)((1u << (16 - k)) - 1)) == 0);
            constexpr.ASSUME((x & result) == result);
            constexpr.ASSUME((x | result) == x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void l1mask(uint result, uint x)
        {
            constexpr.ASSUME(result == (uint)((ulong)uint.MaxValue << (32 - math.l1cnt(x))));
    
            int k = math.l1cnt(x);
            constexpr.ASSUME(math.countbits(result) == k);
            constexpr.ASSUME(result == (uint)(((1ul << k) - 1) << (32 - k)));
            constexpr.ASSUME((result & (uint)((1ul << (32 - k)) - 1)) == 0);
            constexpr.ASSUME((x & result) == result);
            constexpr.ASSUME((x | result) == x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void l1mask(ulong result, ulong x)
        {
            constexpr.ASSUME(result == (ulong)((UInt128)ulong.MaxValue << (64 - math.l1cnt(x))));
    
            int k = math.l1cnt(x);
            constexpr.ASSUME(math.countbits(result) == k);
            constexpr.ASSUME(result == (ulong)((((UInt128)1ul << k) - 1) << (64 - k)));
            constexpr.ASSUME((result & (ulong)(((UInt128)1ul << (64 - k)) - 1)) == 0);
            constexpr.ASSUME((x & result) == result);
            constexpr.ASSUME((x | result) == x);
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="UInt128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 l1mask(UInt128 x)
        {
            int __l1cnt = l1cnt(x);

            UInt128 result = __l1cnt == 0 ? 0 : UInt128.MaxValue << (128 - __l1cnt);

            constexpr.ASSUME(result == (UInt128)((__UInt256__)UInt128.MaxValue << (128 - math.l1cnt(x))));
    
            int k = math.l1cnt(x);
            constexpr.ASSUME(math.countbits(result) == k);
            constexpr.ASSUME(result == (UInt128)((((__UInt256__)1ul << k) - 1) << (128 - k)));
            constexpr.ASSUME((result & (UInt128)(((__UInt256__)1ul << (128 - k)) - 1)) == 0);
            constexpr.ASSUME((x & result) == result);
            constexpr.ASSUME((x | result) == x);

            return result;
        }

        /// <summary>       Sets all the leading ones in the binary representation of an <see cref="Int128"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 l1mask(Int128 x)
        {
            return (Int128)l1mask((UInt128)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="byte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte l1mask(byte x)
        {
            byte result;

            if (Bmi2.IsBmi2Supported)
            {
                result = bits_zerohigh(byte.MaxValue, 8 - l1cnt(x));
                result = (byte)~result;
            }
            else
            {
                result = (byte)(byte.MaxValue << (8 - l1cnt(x)));
            }

            Assume.l1mask(result, x);
            
            return result;
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="byte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 l1mask(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="byte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 l1mask(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte3(l1mask(x.x), l1mask(x.y), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="byte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 l1mask(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte4(l1mask(x.x), l1mask(x.y), l1mask(x.z), l1mask(x.w));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="byte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 l1mask(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte8(l1mask(x.x0), l1mask(x.x1), l1mask(x.x2), l1mask(x.x3), l1mask(x.x4), l1mask(x.x5), l1mask(x.x6), l1mask(x.x7));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="byte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 l1mask(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi8(x);
            }
            else
            {
                return new byte16(l1mask(x.x0), l1mask(x.x1), l1mask(x.x2), l1mask(x.x3), l1mask(x.x4), l1mask(x.x5), l1mask(x.x6), l1mask(x.x7), l1mask(x.x8), l1mask(x.x9), l1mask(x.x10), l1mask(x.x11), l1mask(x.x12), l1mask(x.x13), l1mask(x.x14), l1mask(x.x15));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="byte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 l1mask(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi8(x);
            }
            else
            {
                return new byte32(l1mask(x.v16_0), l1mask(x.v16_16));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of an <see cref="sbyte"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte l1mask(sbyte x)
        {
            return (sbyte)l1mask((byte)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="sbyte2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 l1mask(sbyte2 x)
        {
            return (sbyte2)l1mask((byte2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="sbyte3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 l1mask(sbyte3 x)
        {
            return (sbyte3)l1mask((byte3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="sbyte4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 l1mask(sbyte4 x)
        {
            return (sbyte4)l1mask((byte4)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="sbyte8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 l1mask(sbyte8 x)
        {
            return (sbyte8)l1mask((byte8)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="sbyte16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 l1mask(sbyte16 x)
        {
            return (sbyte16)l1mask((byte16)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="sbyte32"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 l1mask(sbyte32 x)
        {
            return (sbyte32)l1mask((byte32)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="ushort"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort l1mask(ushort x)
        {
            ushort result;

            if (Bmi2.IsBmi2Supported)
            {
                result = bits_zerohigh(ushort.MaxValue, 16 - l1cnt(x));
                result = (ushort)~result;
            }
            else
            {
                result = (ushort)(ushort.MaxValue << (16 - l1cnt(x)));
            }

            Assume.l1mask(result, x);
            
            return result;
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ushort2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 l1mask(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ushort3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 l1mask(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort3(l1mask(x.x), l1mask(x.y), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ushort4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 l1mask(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort4(l1mask(x.x), l1mask(x.y), l1mask(x.z), l1mask(x.w));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ushort8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 l1mask(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi16(x);
            }
            else
            {
                return new ushort8(l1mask(x.x0), l1mask(x.x1), l1mask(x.x2), l1mask(x.x3), l1mask(x.x4), l1mask(x.x5), l1mask(x.x6), l1mask(x.x7));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ushort16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 l1mask(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi16(x);
            }
            else
            {
                return new ushort16(l1mask(x.v8_0), l1mask(x.v8_8));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="short"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short l1mask(short x)
        {
            return (short)l1mask((ushort)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="short2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 l1mask(short2 x)
        {
            return (short2)l1mask((ushort2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="short3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 l1mask(short3 x)
        {
            return (short3)l1mask((ushort3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="short4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 l1mask(short4 x)
        {
            return (short4)l1mask((ushort4)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="short8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 l1mask(short8 x)
        {
            return (short8)l1mask((ushort8)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="short16"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 l1mask(short16 x)
        {
            return (short16)l1mask((ushort16)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="uint"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint l1mask(uint x)
        {
            uint result;

            if (Bmi2.IsBmi2Supported)
            {
                result = bits_zerohigh(uint.MaxValue, 32 - l1cnt(x));
                result = (uint)~result;
            }
            else
            {
                result = (uint)((ulong)uint.MaxValue << (32 - l1cnt(x)));
            }

            Assume.l1mask(result, x);
            
            return result;
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="uint2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 l1mask(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi32(x);
            }
            else
            {
                return new uint2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="uint3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 l1mask(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi32(x);
            }
            else
            {
                return new uint3(l1mask(x.x), l1mask(x.y), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="uint4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 l1mask(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi32(x);
            }
            else
            {
                return new uint4(l1mask(x.x), l1mask(x.y), l1mask(x.z), l1mask(x.w));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="uint8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 l1mask(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi32(x);
            }
            else
            {
                return new uint8(l1mask(x.v4_0), l1mask(x.v4_4));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of an <see cref="int"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int l1mask(int x)
        {
            return (int)l1mask((uint)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="int2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 l1mask(int2 x)
        {
            return (int2)l1mask((uint2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="int3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 l1mask(int3 x)
        {
            return (int3)l1mask((uint3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="int4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 l1mask(int4 x)
        {
            return (int4)l1mask((uint4)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="int8"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 l1mask(int8 x)
        {
            return (int8)l1mask((uint8)x);
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="ulong"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong l1mask(ulong x)
        {
            ulong result;

            if (Bmi2.IsBmi2Supported)
            {
                result = bits_zerohigh(ulong.MaxValue, 64 - l1cnt(x));
                result = (ulong)~result;
            }
            else
            {
                result = (ulong)((UInt128)ulong.MaxValue << (64 - l1cnt(x)));
            }

            Assume.l1mask(result, x);
            
            return result;
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ulong2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 l1mask(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.l1msk_epi64(x);
            }
            else
            {
                return new ulong2(l1mask(x.x), l1mask(x.y));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ulong3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 l1mask(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi64(x);
            }
            else
            {
                return new ulong3(l1mask(x.xy), l1mask(x.z));
            }
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="ulong4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 l1mask(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_l1msk_epi64(x);
            }
            else
            {
                return new ulong4(l1mask(x.xy), l1mask(x.zw));
            }
        }


        /// <summary>       Sets all the leading ones in the binary representation of a <see cref="long"/> to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long l1mask(long x)
        {
            return (long)l1mask((ulong)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="long2"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 l1mask(long2 x)
        {
            return (long2)l1mask((ulong2)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="long3"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 l1mask(long3 x)
        {
            return (long3)l1mask((ulong3)x);
        }

        /// <summary>       Sets all the leading ones in the binary representations of each <see cref="long4"/> component to 1 and the remaining bits to 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 l1mask(long4 x)
        {
            return (long4)l1mask((ulong4)x);
        }
    }
}
