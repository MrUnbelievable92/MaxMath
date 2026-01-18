using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Cast
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 Byte16ToShort16(byte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi16(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Xse.cvtepu8_epi16(x);
                v128 hi = Xse.cvtepu8_epi16(Xse.bsrli_si128(x, 8 * sizeof(byte)));

                return new short16(lo, hi);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 ZERO = Xse.setzero_si128();
                v128 lo = Xse.unpacklo_epi8(x, ZERO);
                v128 hi = Xse.unpackhi_epi8(x, ZERO);

                return new short16(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static short16 SByte16ToShort16(sbyte16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi16(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Xse.cvtepi8_epi16(x);
                v128 hi = Xse.cvtepi8_epi16(Xse.bsrli_si128(x, 8 * sizeof(sbyte)));

                return new short16(lo, hi);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 negativeMask = Xse.cmpgt_epi8(Xse.setzero_si128(), x);
                v128 lo = Xse.unpacklo_epi8(x, negativeMask);
                v128 hi = Xse.unpackhi_epi8(x, negativeMask);

                return new short16(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int8 Short8ToInt8(short8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi32(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Xse.cvtepi16_epi32(x);
                v128 hi = Xse.cvtepi16_epi32(Xse.bsrli_si128(x, 4 * sizeof(short)));

                return new int8(RegisterConversion.ToInt4(lo), RegisterConversion.ToInt4(hi));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 negativeMask = Xse.srai_epi16(x, 15);
                v128 lo = Xse.unpacklo_epi16(x, negativeMask);
                v128 hi = Xse.unpackhi_epi16(x, negativeMask);

                return new int8(RegisterConversion.ToInt4(lo), RegisterConversion.ToInt4(hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int8 UShort8ToInt8(ushort8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi32(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Xse.cvtepu16_epi32(x);
                v128 hi = Xse.cvtepu16_epi32(Xse.bsrli_si128(x, 4 * sizeof(ushort)));

                return new int8(RegisterConversion.ToInt4(lo), RegisterConversion.ToInt4(hi));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 ZERO = Xse.setzero_si128();
                v128 lo = Xse.unpacklo_epi16(x, ZERO);
                v128 hi = Xse.unpackhi_epi16(x, ZERO);

                return new int8(RegisterConversion.ToInt4(lo), RegisterConversion.ToInt4(hi));
            }
            else throw new IllegalInstructionException();
        }



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long4 UInt4ToLong4(v128 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu32_epi64(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Xse.cvtepu32_epi64(x);
                v128 hi = Xse.cvtepu32_epi64(Xse.bsrli_si128(x, 2 * sizeof(uint)));

                return new long4(lo, hi);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 ZERO = Xse.setzero_si128();
                v128 lo = Xse.unpacklo_epi32(x, ZERO);
                v128 hi = Xse.unpackhi_epi32(x, ZERO);

                return new long4(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long4 Int4ToLong4(v128 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(x);
            }
            else if (Sse4_1.IsSse41Supported)
            {
                v128 lo = Xse.cvtepi32_epi64(x);
                v128 hi = Xse.cvtepi32_epi64(Xse.bsrli_si128(x, 2 * sizeof(int)));

                return new long4(lo, hi);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 negativeMask = Xse.srai_epi32(x, 31);
                v128 lo = Xse.unpacklo_epi32(x, negativeMask);
                v128 hi = Xse.unpackhi_epi32(x, negativeMask);

                return new long4(lo, hi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short16To_S_Byte16_SSE2(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 MASK = new v128(0x00FF_00FF_00FF_00FF, 0x00FF_00FF_00FF_00FF);

                v128 clamp_lo = Xse.and_si128(lo, MASK);
                v128 clamp_hi = Xse.and_si128(hi, MASK);

                return Xse.packus_epi16(clamp_lo, clamp_hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8To_S_Byte8_SSE2(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 MASK = new v128(0x0000_00FF_0000_00FF, 0x0000_00FF_0000_00FF);

                v128 clamp_lo = Xse.and_si128(lo, MASK);
                v128 clamp_hi = Xse.and_si128(hi, MASK);

                v128 epi16 = Xse.packs_epi32(clamp_lo, clamp_hi);

                return Xse.packus_epi16(epi16, epi16);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8To_U_Short8_SSE2(v128 lo, v128 hi)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MASK = new v128(0x0000_FFFF_0000_FFFF, 0x0000_FFFF_0000_FFFF);

                v128 clamp_lo = Xse.and_si128(lo, MASK);
                v128 clamp_hi = Xse.and_si128(hi, MASK);

                return Xse.packus_epi32(clamp_lo, clamp_hi);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.unpacklo_epi64(Xse.cvtepi32_epi16(lo, 4), Xse.cvtepi32_epi16(hi, 4));
            }
            else throw new IllegalInstructionException();
        }
    }
}