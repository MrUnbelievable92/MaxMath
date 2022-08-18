using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

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
                v128 lo = Sse4_1.cvtepu8_epi16(x);
                v128 hi = Sse4_1.cvtepu8_epi16(Sse2.bsrli_si128(x, 8 * sizeof(byte)));

                return new short16(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 lo = Sse2.unpacklo_epi8(x, ZERO);
                v128 hi = Sse2.unpackhi_epi8(x, ZERO);

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
                v128 lo = Sse4_1.cvtepi8_epi16(x);
                v128 hi = Sse4_1.cvtepi8_epi16(Sse2.bsrli_si128(x, 8 * sizeof(sbyte)));

                return new short16(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.cmpgt_epi8(Sse2.setzero_si128(), x);
                v128 lo = Sse2.unpacklo_epi8(x, negativeMask);
                v128 hi = Sse2.unpackhi_epi8(x, negativeMask);

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
                v128 lo = Sse4_1.cvtepi16_epi32(x);
                v128 hi = Sse4_1.cvtepi16_epi32(Sse2.bsrli_si128(x, 4 * sizeof(short)));

                return new int8(RegisterConversion.ToType<int4>(lo), RegisterConversion.ToType<int4>(hi));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.srai_epi16(x, 15);
                v128 lo = Sse2.unpacklo_epi16(x, negativeMask);
                v128 hi = Sse2.unpackhi_epi16(x, negativeMask);

                return new int8(RegisterConversion.ToType<int4>(lo), RegisterConversion.ToType<int4>(hi));
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
                v128 lo = Sse4_1.cvtepu16_epi32(x);
                v128 hi = Sse4_1.cvtepu16_epi32(Sse2.bsrli_si128(x, 4 * sizeof(ushort)));

                return new int8(RegisterConversion.ToType<int4>(lo), RegisterConversion.ToType<int4>(hi));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 lo = Sse2.unpacklo_epi16(x, ZERO);
                v128 hi = Sse2.unpackhi_epi16(x, ZERO);

                return new int8(RegisterConversion.ToType<int4>(lo), RegisterConversion.ToType<int4>(hi));
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
                v128 lo = Sse4_1.cvtepu32_epi64(x);
                v128 hi = Sse4_1.cvtepu32_epi64(Sse2.bsrli_si128(x, 2 * sizeof(uint)));

                return new long4(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();
                v128 lo = Sse2.unpacklo_epi32(x, ZERO);
                v128 hi = Sse2.unpackhi_epi32(x, ZERO);

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
                v128 lo = Sse4_1.cvtepi32_epi64(x);
                v128 hi = Sse4_1.cvtepi32_epi64(Sse2.bsrli_si128(x, 2 * sizeof(int)));

                return new long4(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.srai_epi32(x, 31);
                v128 lo = Sse2.unpacklo_epi32(x, negativeMask);
                v128 hi = Sse2.unpackhi_epi32(x, negativeMask);

                return new long4(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Short16To_S_Byte16_SSE2(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(0x00FF_00FF_00FF_00FF, 0x00FF_00FF_00FF_00FF);

                v128 clamp_lo = Sse2.and_si128(lo, MASK);
                v128 clamp_hi = Sse2.and_si128(hi, MASK);

                return Sse2.packus_epi16(clamp_lo, clamp_hi);
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8To_S_Byte8_SSE2(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = new v128(0x0000_00FF_0000_00FF, 0x0000_00FF_0000_00FF);

                v128 clamp_lo = Sse2.and_si128(lo, MASK);
                v128 clamp_hi = Sse2.and_si128(hi, MASK);

                v128 epi16 = Sse2.packs_epi32(clamp_lo, clamp_hi);

                return Sse2.packus_epi16(epi16, epi16);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 Int8To_U_Short8_SSE2(v128 lo, v128 hi)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MASK = new v128(0x0000_FFFF_0000_FFFF, 0x0000_FFFF_0000_FFFF);

                v128 clamp_lo = Sse2.and_si128(lo, MASK);
                v128 clamp_hi = Sse2.and_si128(hi, MASK);

                return Sse4_1.packus_epi32(clamp_lo, clamp_hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi64(Xse.cvtepi32_epi16(lo, 4), Xse.cvtepi32_epi16(hi, 4));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 UShort8To_Float8_SSE2(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 EXP_MASK = Sse2.set1_epi16(0x4B00);
                v128 MAGIC = Sse.set1_ps(LIMIT_PRECISE_I16_F32);

                hi = Sse.sub_ps(Sse2.unpackhi_epi16(a, EXP_MASK), MAGIC);
                return Sse.sub_ps(Sse2.unpacklo_epi16(a, EXP_MASK), MAGIC);
            }
            else throw new IllegalInstructionException();
        }
    }
}