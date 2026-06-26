using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cvtepi8_epi4(v128 v) 
        {
            if (Ssse3.IsSsse3Supported)
            {
                v = and_si128(v, NIBBLE_MASK);
        
                v128 pairs16 = maddubs_epi16(v, new v128(1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4));
                return packus_epi16(pairs16, pairs16).ULong0;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return math.bits_extractparallel(new UInt128(v.ULong0, v.ULong1), new UInt128(0x0F0F_0F0F_0F0F_0F0F, 0x0F0F_0F0F_0F0F_0F0F)).lo64;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary> lo: result.ULong0, hi: result.ULong2 </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepi8_epi4(v256 v) 
        {
            if (Avx2.IsAvx2Supported)
            {
                v = Avx2.mm256_and_si256(v, MM256_NIBBLE_MASK);
        
                v256 pairs16 = Avx2.mm256_maddubs_epi16(v, new v256(1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4, 1, 1 << 4));
                return Avx2.mm256_packus_epi16(pairs16, pairs16);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtepu4_epi8(ulong v) 
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = and_si128(cvtsi64x_si128(v), NIBBLE_MASK);
                v128 hi = and_si128(srli_epi16(cvtsi64x_si128(v), 4), NIBBLE_MASK);

                return unpacklo_epi8(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtepu4_epi8(ulong lo, ulong hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 r = Avx.mm256_castsi128_si256(cvtsi64x_si128(lo));
                r = Avx.mm256_insert_epi64(r, (long)hi, 2);
                v256 rlo = Avx2.mm256_and_si256(r, MM256_NIBBLE_MASK);
                v256 rhi = Avx2.mm256_and_si256(Avx2.mm256_srli_epi16(r, 4), MM256_NIBBLE_MASK);

                return Avx2.mm256_unpacklo_epi8(rlo, rhi);
            }
            else throw new IllegalInstructionException();
        }
    }
}