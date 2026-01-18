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
                return shuffle_epi8(x, new v128(0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (elements == 2)
                {
                    v128 y_shifted = bsrli_si128(x, 1 * sizeof(short));

                    return unpacklo_epi8(x, y_shifted);
                }
                else
                {
                    v128 clamp = and_si128(x, new v128(0x00FF_00FF_00FF_00FF, 0x00FF_00FF_00FF_00FF));

                    return packus_epi16(clamp, clamp);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi16_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(Avx2.mm256_shuffle_epi8(x, new v256(0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1,     0, 2, 4, 6, 8, 10, 12, 14,     -1, -1, -1, -1, -1, -1, -1, -1)),
                                                                              Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi8(v128 x, byte elements = 4)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return shuffle_epi8(x, new v128(0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                if (elements == 2)
                {
                    v128 y_shifted = bsrli_si128(x, 1 * sizeof(int));

                    return unpacklo_epi8(x, y_shifted);
                }
                else
                {
                    v128 clamp = and_si128(x, new v128(0x0000_00FF_0000_00FF, 0x0000_00FF_0000_00FF));

                    v128 epi16 = packs_epi32(clamp, clamp);

                    return packus_epi16(epi16, epi16);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi32_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Avx2.mm256_shuffle_epi8(x, new v256(0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,     0, 4, 8, 12,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 4, 1, 1))));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi32_epi16(v128 x, byte elements = 4)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return shuffle_epi16(x, new v128(0, 2, 4, 6,    -1, -1, -1, -1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                x = shufflelo_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));

                if (elements <= 2)
                {
                    return x;
                }
                else
                {
                    x = shufflehi_epi16(x, Sse.SHUFFLE(3, 3, 2, 0));

                    return shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi32_epi16(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                x = Xse.mm256_shuffle_epi16(x, new v256(0, 2, 4, 6,    -1, -1, -1, -1,
                                                        0, 2, 4, 6,    -1, -1, -1, -1));

                return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(x, Sse.SHUFFLE(0, 0, 2, 0)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi8(v128 x)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return shuffle_epi8(x, new v128(0, 8, -1, -1,    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 high = bsrli_si128(x, sizeof(long));
                return unpacklo_epi8(x, high);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi8(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return cvtepi32_epi8(mm256_cvtepi64_epi32(x));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi16(v128 x)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                return shuffle_epi16(x, new v128(0, 4,   -1, -1, -1, -1, -1, -1));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 high = bsrli_si128(x, sizeof(long));
                return unpacklo_epi16(x, high);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi16(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return cvtepi32_epi16(mm256_cvtepi64_epi32(x));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepi64_epi32(v128 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return shuffle_epi32(x, Sse.SHUFFLE(3, 3, 2, 0));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 mm256_cvtepi64_epi32(v256 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_castsi256_si128(Avx2.mm256_permutevar8x32_epi32(x, Avx.mm256_castsi128_si256(new v128(0, 2, 4, 6))));
            }
            else throw new IllegalInstructionException();
        }
    }
}