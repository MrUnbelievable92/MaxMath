using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    internal static class ConvertToBool
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue8(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), input);  
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse8(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(input, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 IsTrue8(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(Avx.mm256_setzero_si256(), input);  
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 IsFalse8(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(input, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue16(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return IsTrue8(Sse2.packs_epi16(input, input));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse16(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return IsFalse8(Sse2.packs_epi16(input, input));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue16(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx2.mm256_extracti128_si256(input, 1);
                
                return IsTrue8(Sse2.packs_epi16(lo, hi));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse16(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx2.mm256_extracti128_si256(input, 1);
                
                return IsFalse8(Sse2.packs_epi16(lo, hi));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue32(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx2.mm256_extracti128_si256(input, 1);

                v128 _16 = Sse2.packs_epi32(lo, hi);
                
                return IsTrue8(Sse2.packs_epi16(_16, _16));
            }
            else if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                v128 _16 = Sse2.packs_epi32(lo, hi);
                
                return IsTrue8(Sse2.packs_epi16(_16, _16));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse32(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx2.mm256_extracti128_si256(input, 1);

                v128 _16 = Sse2.packs_epi32(lo, hi);
                
                return IsFalse8(Sse2.packs_epi16(_16, _16));
            }
            else if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                v128 _16 = Sse2.packs_epi32(lo, hi);
                
                return IsTrue8(Sse2.packs_epi16(_16, _16));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsTrue64(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return  0x0101 & Sse2.movemask_epi8(input);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsFalse64(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return maxmath.andnot(0x0101, Sse2.movemask_epi8(input));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsTrue64(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0x0101_0101 & Avx2.mm256_movemask_epi8(input);
            }
            else throw new CPUFeatureCheckException();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsFalse64(v256 input) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return maxmath.andnot(0x0101_0101, Avx2.mm256_movemask_epi8(input));
            }
            else throw new CPUFeatureCheckException();
        }
    }
}
