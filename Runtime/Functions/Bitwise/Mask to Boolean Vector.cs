using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns a <see cref="bool2"/> from the first two bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 tobool2(int mask)
        {
            mask &= 0b0011;

            int result = 0x0101 & (mask | (mask << 7));

            return *(bool2*)&result;
        }

        /// <summary>       Returns a <see cref="bool3"/> from the first 3 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 tobool3(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 shift = Sse2.srli_epi32(Avx2.sllv_epi32(Sse2.set1_epi32(mask), new v128(31, 30, 29, 28)), 31);
                v128 temp = Cast.Int4ToByte4(shift);

                return *(bool3*)&temp;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 temp = Sse2.sub_epi8(Sse2.setzero_si128(), Mask.SByte4FromInt(mask));
                
                return *(bool3*)&temp;
            }
            else
            {
                return tobool(1 & new byte3((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2)));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> from the first 4 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 tobool4(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 shift = Sse2.srli_epi32(Avx2.sllv_epi32(Sse2.set1_epi32(mask), new v128(31, 30, 29, 28)), 31);
                v128 temp = Cast.Int4ToByte4(shift);

                return *(bool4*)&temp;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 temp = Sse2.sub_epi8(Sse2.setzero_si128(), Mask.SByte4FromInt(mask));
                
                return *(bool4*)&temp;
            }
            else
            {
                return tobool(1 & new byte4((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3)));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> from the first 8 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 tobool8(int mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), Mask.SByte8FromInt(mask));
            }
            else
            {
                return tobool(1 & new byte8((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7)));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool16"/> from the first 16 bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 tobool16(int mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), Mask.SByte16FromInt(mask));
            }
            else
            {
                return tobool(1 & new byte16((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7), (byte)(mask >> 8), (byte)(mask >> 9), (byte)(mask >> 10), (byte)(mask >> 11), (byte)(mask >> 12), (byte)(mask >> 13), (byte)(mask >> 14), (byte)(mask >> 15)));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool32"/> from the bits of an <see cref="int"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 tobool32(int mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(Avx.mm256_setzero_si256(), Mask.SByte32FromInt(mask));
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 ZERO = Sse2.setzero_si128();

                sbyte32 vector = Mask.SByte32FromInt(mask);

                return new bool32(Sse2.sub_epi8(ZERO, vector._v16_0), Sse2.sub_epi8(ZERO, vector._v16_16));
            }
            else
            {
                return tobool(1 & new byte32((byte)mask, (byte)(mask >> 1), (byte)(mask >> 2), (byte)(mask >> 3), (byte)(mask >> 4), (byte)(mask >> 5), (byte)(mask >> 6), (byte)(mask >> 7), (byte)(mask >> 8), (byte)(mask >> 9), (byte)(mask >> 10), (byte)(mask >> 11), (byte)(mask >> 12), (byte)(mask >> 13), (byte)(mask >> 14), (byte)(mask >> 15), (byte)(mask >> 16), (byte)(mask >> 17), (byte)(mask >> 18), (byte)(mask >> 19), (byte)(mask >> 20), (byte)(mask >> 21), (byte)(mask >> 22), (byte)(mask >> 23), (byte)(mask >> 24), (byte)(mask >> 25), (byte)(mask >> 26), (byte)(mask >> 27), (byte)(mask >> 28), (byte)(mask >> 29), (byte)(mask >> 30), (byte)(mask >> 31)));
            }
        }
    }
}