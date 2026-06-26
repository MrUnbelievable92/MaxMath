using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_epi16(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepu8_epi16(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    result = unpacklo_epi8(x, setzero_si128());
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    v128 u8x16 = x;
                    v128 u16x8 = Arm.Neon.vmovl_u8(Arm.Neon.vget_low_u8(u8x16));
                    result = u16x8;
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.UShort0 == x.Byte0);
                constexpr.ASSUME(result.UShort1 == x.Byte1);
                constexpr.ASSUME(result.UShort2 == x.Byte2);
                constexpr.ASSUME(result.UShort3 == x.Byte3);
                constexpr.ASSUME(result.UShort4 == x.Byte4);
                constexpr.ASSUME(result.UShort5 == x.Byte5);
                constexpr.ASSUME(result.UShort6 == x.Byte6);
                constexpr.ASSUME(result.UShort7 == x.Byte7);
                constexpr.ASSUME_LE_EPU16(result, byte.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_epi16(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepi8_epi16(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    result = srai_epi16(unpacklo_epi8(x, x), 8);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    v128 s8x16 = x;
                    v128 s16x8 = Arm.Neon.vmovl_s8(Arm.Neon.vget_low_s8(s8x16));
                    result = s16x8;
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.SShort0 == x.SByte0);
                constexpr.ASSUME(result.SShort1 == x.SByte1);
                constexpr.ASSUME(result.SShort2 == x.SByte2);
                constexpr.ASSUME(result.SShort3 == x.SByte3);
                constexpr.ASSUME(result.SShort4 == x.SByte4);
                constexpr.ASSUME(result.SShort5 == x.SByte5);
                constexpr.ASSUME(result.SShort6 == x.SByte6);
                constexpr.ASSUME(result.SShort7 == x.SByte7);
                constexpr.ASSUME_RANGE_EPI16(result, sbyte.MinValue, sbyte.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_epi32(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepu8_epi32(x);
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    result = shuffle_epi8(x, new v128(0, -1, -1, -1,   1, -1, -1, -1,   2, -1, -1, -1,   3, -1, -1, -1));
                }
                else
                {
                    v128 zero = setzero_si128();
                    v128 shorts = unpacklo_epi8(x, zero);

                    result = unpacklo_epi16(shorts, zero);
                }

                constexpr.ASSUME(result.UInt0 == x.Byte0);
                constexpr.ASSUME(result.UInt1 == x.Byte1);
                constexpr.ASSUME(result.UInt2 == x.Byte2);
                constexpr.ASSUME(result.UInt3 == x.Byte3);
                constexpr.ASSUME_LE_EPU32(result, byte.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_epi32(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepi8_epi32(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 whoop = unpacklo_epi8(x, x);
                    v128 dee = unpacklo_epi16(whoop, whoop);
                    v128 dup = srai_epi32(dee, 24);

                    result = dup;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    v128 s8x16 = x;
                    v128 s16x8 = Arm.Neon.vmovl_s8(Arm.Neon.vget_low_s8(s8x16));
                    v128 s32x4 = Arm.Neon.vmovl_s16(Arm.Neon.vget_low_s16(s16x8));
                    result = s32x4;
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.SInt0 == x.SByte0);
                constexpr.ASSUME(result.SInt1 == x.SByte1);
                constexpr.ASSUME(result.SInt2 == x.SByte2);
                constexpr.ASSUME(result.SInt3 == x.SByte3);
                constexpr.ASSUME_RANGE_EPI32(result, sbyte.MinValue, sbyte.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu8_epi64(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepu8_epi64(x);
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    result = shuffle_epi8(x, new v128(0, -1, -1, -1, -1, -1, -1, -1,   1, -1, -1, -1, -1, -1, -1, -1));
                }
                else
                {
                    v128 zero = setzero_si128();
                    v128 shorts = unpacklo_epi8(x, zero);
                    v128 ints = unpacklo_epi16(shorts, zero);

                    result = unpacklo_epi32(ints, zero);
                }

                constexpr.ASSUME(result.ULong0 == x.Byte0);
                constexpr.ASSUME(result.ULong1 == x.Byte1);
                constexpr.ASSUME_LE_EPU64(result, byte.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi8_epi64(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepi8_epi64(x);
                }
                else if (Ssse3.IsSsse3Supported)
                {
                    v128 shorts = unpacklo_epi8(x, x);
                    shorts = srai_epi16(shorts, 8);

                    result = shuffle_epi8(shorts, new v128(0, 1, 1, 1, 1, 1, 1, 1,   2, 3, 3, 3, 3, 3, 3, 3));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 sign = srai_epi8(x, 7);
                    v128 shorts = unpacklo_epi8(x, sign);

                    sign = unpacklo_epi8(sign, sign);
                    v128 ints = unpacklo_epi16(shorts, sign);

                    sign = unpacklo_epi16(sign, sign);
                    result = unpacklo_epi32(ints, sign);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    v128 s8x16 = x;
                    v128 s16x8 = Arm.Neon.vmovl_s8(Arm.Neon.vget_low_s8(s8x16));
                    v128 s32x4 = Arm.Neon.vmovl_s16(Arm.Neon.vget_low_s16(s16x8));
                    v128 s64x2 = Arm.Neon.vmovl_s32(Arm.Neon.vget_low_s32(s32x4));
                    result = s64x2;
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.SLong0 == x.SByte0);
                constexpr.ASSUME(result.SLong1 == x.SByte1);
                constexpr.ASSUME_RANGE_EPI64(result, sbyte.MinValue, sbyte.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_epi32(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepu16_epi32(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    result = unpacklo_epi16(x, setzero_si128());
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    result = Arm.Neon.vmovl_u16(Arm.Neon.vget_low_u16(x));
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.UInt0 == x.UShort0);
                constexpr.ASSUME(result.UInt1 == x.UShort1);
                constexpr.ASSUME(result.UInt2 == x.UShort2);
                constexpr.ASSUME(result.UInt3 == x.UShort3);
                constexpr.ASSUME_LE_EPU32(result, ushort.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_epi32(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepi16_epi32(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    result = unpacklo_epi16(x, srai_epi16(x, 15));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    result = Arm.Neon.vmovl_s16(Arm.Neon.vget_low_s16(x));
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.SInt0 == x.SShort0);
                constexpr.ASSUME(result.SInt1 == x.SShort1);
                constexpr.ASSUME(result.SInt2 == x.SShort2);
                constexpr.ASSUME(result.SInt3 == x.SShort3);
                constexpr.ASSUME_RANGE_EPI32(result, short.MinValue, short.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu16_epi64(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepu16_epi64(x);
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    result = shuffle_epi16(x, new v128(0, -1, -1, -1,    1, -1, -1, -1));
                }
                else
                {
                    v128 zero = setzero_si128();
                    v128 shorts = unpacklo_epi16(x, zero);

                    result = unpacklo_epi32(shorts, zero);
                }

                constexpr.ASSUME(result.ULong0 == x.UShort0);
                constexpr.ASSUME(result.ULong1 == x.UShort1);
                constexpr.ASSUME_LE_EPU64(result, ushort.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_epi64(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepi16_epi64(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 sign = srai_epi16(x, 15);
                    v128 shorts = unpacklo_epi16(x, sign);

                    sign = unpacklo_epi16(sign, sign);
                    result = unpacklo_epi32(shorts, sign);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    v128 s16x8 = x;
                    v128 s32x4 = Arm.Neon.vmovl_s16(Arm.Neon.vget_low_s16(s16x8));
                    v128 s64x2 = Arm.Neon.vmovl_s32(Arm.Neon.vget_low_s32(s32x4));
                    result = s64x2;
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.SLong0 == x.SShort0);
                constexpr.ASSUME(result.SLong1 == x.SShort1);
                constexpr.ASSUME_RANGE_EPI64(result, short.MinValue, short.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu32_epi64(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepu32_epi64(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    result = unpacklo_epi32(x, setzero_si128());
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    result = Arm.Neon.vmovl_u32(Arm.Neon.vget_low_u32(x));
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.ULong0 == x.UInt0);
                constexpr.ASSUME(result.ULong1 == x.UInt1);
                constexpr.ASSUME_LE_EPU64(result, uint.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi64(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (Sse4_1.IsSse41Supported)
                {
                    result = Sse4_1.cvtepi32_epi64(x);
                }
                else if (Sse2.IsSse2Supported)
                {
                    result = unpacklo_epi32(x, srai_epi32(x, 31));
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    result = Arm.Neon.vmovl_s32(Arm.Neon.vget_low_s32(x));
                }
                else throw Assert.Unreachable();

                constexpr.ASSUME(result.SLong0 == x.SInt0);
                constexpr.ASSUME(result.SLong1 == x.SInt1);
                constexpr.ASSUME_RANGE_EPI64(result, int.MinValue, int.MaxValue);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi16_epi8(v128 x, byte elements = 8)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi8(x, new v128(0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1));

                constexpr.ASSUME(result.Byte0 == (byte)x.UShort0);
                constexpr.ASSUME(result.Byte1 == (byte)x.UShort1);
                constexpr.ASSUME(result.Byte2 == (byte)x.UShort2);
                constexpr.ASSUME(result.Byte3 == (byte)x.UShort3);
                constexpr.ASSUME(result.Byte4 == (byte)x.UShort4);
                constexpr.ASSUME(result.Byte5 == (byte)x.UShort5);
                constexpr.ASSUME(result.Byte6 == (byte)x.UShort6);
                constexpr.ASSUME(result.Byte7 == (byte)x.UShort7);
                return result;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (elements == 2)
                {
                    v128 y_shifted = bsrli_si128(x, 1 * sizeof(short));

                    v128 result = unpacklo_epi8(x, y_shifted);

                    constexpr.ASSUME(result.Byte0 == (byte)x.UShort0);
                    constexpr.ASSUME(result.Byte1 == (byte)x.UShort1);
                    return result;
                }
                else
                {
                    v128 clamp = and_si128(x, new v128(0x00FF_00FF_00FF_00FF, 0x00FF_00FF_00FF_00FF));

                    v128 result = packus_epi16(clamp, clamp);

                    constexpr.ASSUME(result.Byte0 == (byte)x.UShort0);
                    constexpr.ASSUME(result.Byte1 == (byte)x.UShort1);
                    constexpr.ASSUME(result.Byte2 == (byte)x.UShort2);
                    constexpr.ASSUME(result.Byte3 == (byte)x.UShort3);
                    constexpr.ASSUME(result.Byte4 == (byte)x.UShort4);
                    constexpr.ASSUME(result.Byte5 == (byte)x.UShort5);
                    constexpr.ASSUME(result.Byte6 == (byte)x.UShort6);
                    constexpr.ASSUME(result.Byte7 == (byte)x.UShort7);
                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi16_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi8(x, new v256(0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1,     0, 2, 4, 6, 8, 10, 12, 14,     -1, -1, -1, -1, -1, -1, -1, -1)),
                                                                                     Sse.SHUFFLE(0, 0, 2, 0)));

                constexpr.ASSUME(result.Byte0  == (byte)x.UShort0);
                constexpr.ASSUME(result.Byte1  == (byte)x.UShort1);
                constexpr.ASSUME(result.Byte2  == (byte)x.UShort2);
                constexpr.ASSUME(result.Byte3  == (byte)x.UShort3);
                constexpr.ASSUME(result.Byte4  == (byte)x.UShort4);
                constexpr.ASSUME(result.Byte5  == (byte)x.UShort5);
                constexpr.ASSUME(result.Byte6  == (byte)x.UShort6);
                constexpr.ASSUME(result.Byte7  == (byte)x.UShort7);
                constexpr.ASSUME(result.Byte8  == (byte)x.UShort8);
                constexpr.ASSUME(result.Byte9  == (byte)x.UShort9);
                constexpr.ASSUME(result.Byte10 == (byte)x.UShort10);
                constexpr.ASSUME(result.Byte11 == (byte)x.UShort11);
                constexpr.ASSUME(result.Byte12 == (byte)x.UShort12);
                constexpr.ASSUME(result.Byte13 == (byte)x.UShort13);
                constexpr.ASSUME(result.Byte14 == (byte)x.UShort14);
                constexpr.ASSUME(result.Byte15 == (byte)x.UShort15);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi8(v128 x, byte elements = 4)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi8(x, new v128(0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));

                constexpr.ASSUME(result.Byte0 == (byte)x.UInt0);
                constexpr.ASSUME(result.Byte1 == (byte)x.UInt1);
                constexpr.ASSUME(result.Byte2 == (byte)x.UInt2);
                constexpr.ASSUME(result.Byte3 == (byte)x.UInt3);
                return result;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (elements == 2)
                {
                    v128 y_shifted = bsrli_si128(x, 1 * sizeof(int));

                    v128 result = unpacklo_epi8(x, y_shifted);

                    constexpr.ASSUME(result.Byte0 == (byte)x.UInt0);
                    constexpr.ASSUME(result.Byte1 == (byte)x.UInt1);
                    return result;
                }
                else
                {
                    v128 clamp = and_si128(x, new v128(0x0000_00FF_0000_00FF, 0x0000_00FF_0000_00FF));

                    v128 epi16 = packs_epi32(clamp, clamp);

                    v128 result = packus_epi16(epi16, epi16);

                    constexpr.ASSUME(result.Byte0 == (byte)x.UInt0);
                    constexpr.ASSUME(result.Byte1 == (byte)x.UInt1);
                    constexpr.ASSUME(result.Byte2 == (byte)x.UInt2);
                    constexpr.ASSUME(result.Byte3 == (byte)x.UInt3);
                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi32_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __x = Avx2.mm256_shuffle_epi8(x, new v256(0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,     0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));

                v128 result = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(__x, Avx.mm256_castsi128_si256(new v128(0, 4, 1, 1))));

                constexpr.ASSUME(result.Byte0 == (byte)x.UInt0);
                constexpr.ASSUME(result.Byte1 == (byte)x.UInt1);
                constexpr.ASSUME(result.Byte2 == (byte)x.UInt2);
                constexpr.ASSUME(result.Byte3 == (byte)x.UInt3);
                constexpr.ASSUME(result.Byte4 == (byte)x.UInt4);
                constexpr.ASSUME(result.Byte5 == (byte)x.UInt5);
                constexpr.ASSUME(result.Byte6 == (byte)x.UInt6);
                constexpr.ASSUME(result.Byte7 == (byte)x.UInt7);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi16(v128 x, byte elements = 4)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi16(x, new v128(0, 2, 4, 6,    -1, -1, -1, -1));

                constexpr.ASSUME(result.UShort0 == (ushort)x.UInt0);
                constexpr.ASSUME(result.UShort1 == (ushort)x.UInt1);
                constexpr.ASSUME(result.UShort2 == (ushort)x.UInt2);
                constexpr.ASSUME(result.UShort3 == (ushort)x.UInt3);
                return result;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));

                if (elements <= 2)
                {
                    constexpr.ASSUME(result.UShort0 == (ushort)x.UInt0);
                    constexpr.ASSUME(result.UShort1 == (ushort)x.UInt1);
                    return result;
                }
                else
                {
                    result = shufflehi_epi16(result, Sse.SHUFFLE(3, 3, 2, 0));
                    result = shuffle_epi32(result, Sse.SHUFFLE(3, 3, 2, 0));

                    constexpr.ASSUME(result.UShort0 == (ushort)x.UInt0);
                    constexpr.ASSUME(result.UShort1 == (ushort)x.UInt1);
                    constexpr.ASSUME(result.UShort2 == (ushort)x.UInt2);
                    constexpr.ASSUME(result.UShort3 == (ushort)x.UInt3);
                    return result;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi32_epi16(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 __x = Xse.mm256_shuffle_epi16(x, new v256(0, 2, 4, 6,    -1, -1, -1, -1,
                                                               0, 2, 4, 6,    -1, -1, -1, -1));

                v128 result = Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(__x, Sse.SHUFFLE(0, 0, 2, 0)));

                constexpr.ASSUME(result.UShort0 == (ushort)x.UInt0);
                constexpr.ASSUME(result.UShort1 == (ushort)x.UInt1);
                constexpr.ASSUME(result.UShort2 == (ushort)x.UInt2);
                constexpr.ASSUME(result.UShort3 == (ushort)x.UInt3);
                constexpr.ASSUME(result.UShort4 == (ushort)x.UInt4);
                constexpr.ASSUME(result.UShort5 == (ushort)x.UInt5);
                constexpr.ASSUME(result.UShort6 == (ushort)x.UInt6);
                constexpr.ASSUME(result.UShort7 == (ushort)x.UInt7);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi8(v128 x)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi8(x, new v128(0, 8, -1, -1,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));

                constexpr.ASSUME(result.Byte0 == (byte)x.ULong0);
                constexpr.ASSUME(result.Byte1 == (byte)x.ULong1);
                return result;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 high = bsrli_si128(x, sizeof(long));
                v128 result = unpacklo_epi8(x, high);

                constexpr.ASSUME(result.Byte0 == (byte)x.ULong0);
                constexpr.ASSUME(result.Byte1 == (byte)x.ULong1);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = cvtepi32_epi8(mm256_cvtepi64_epi32(x));

                constexpr.ASSUME(result.Byte0 == (byte)x.ULong0);
                constexpr.ASSUME(result.Byte1 == (byte)x.ULong1);
                constexpr.ASSUME(result.Byte2 == (byte)x.ULong2);
                constexpr.ASSUME(result.Byte3 == (byte)x.ULong3);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi16(v128 x)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 result = shuffle_epi16(x, new v128(0, 4,   -1, -1, -1, -1, -1, -1));

                constexpr.ASSUME(result.UShort0 == (ushort)x.ULong0);
                constexpr.ASSUME(result.UShort1 == (ushort)x.ULong1);
                return result;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 high = bsrli_si128(x, sizeof(long));
                v128 result = unpacklo_epi16(x, high);

                constexpr.ASSUME(result.UShort0 == (ushort)x.ULong0);
                constexpr.ASSUME(result.UShort1 == (ushort)x.ULong1);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi16(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = cvtepi32_epi16(mm256_cvtepi64_epi32(x));

                constexpr.ASSUME(result.UShort0 == (ushort)x.ULong0);
                constexpr.ASSUME(result.UShort1 == (ushort)x.ULong1);
                constexpr.ASSUME(result.UShort2 == (ushort)x.ULong2);
                constexpr.ASSUME(result.UShort3 == (ushort)x.ULong3);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi32(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));

                constexpr.ASSUME(result.UInt0 == (uint)x.ULong0);
                constexpr.ASSUME(result.UInt1 == (uint)x.ULong1);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi32(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 result = Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));

                constexpr.ASSUME(result.UInt0 == (uint)x.ULong0);
                constexpr.ASSUME(result.UInt1 == (uint)x.ULong1);
                constexpr.ASSUME(result.UInt2 == (uint)x.ULong2);
                constexpr.ASSUME(result.UInt3 == (uint)x.ULong3);
                return result;
            }
            else throw new IllegalInstructionException();
        }
    }
}