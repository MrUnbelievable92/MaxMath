using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class RegisterConversion
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue8(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.neg_epi8(input);  
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse8(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.inc_epi8(input);  
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 IsTrue8(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi8(input);  
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 IsFalse8(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi8(input);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue16(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return IsTrue8(Sse2.packs_epi16(input, input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse16(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return IsFalse8(Sse2.packs_epi16(input, input));
            }
            else throw new IllegalInstructionException();
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
            else throw new IllegalInstructionException();
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
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue32(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return IsTrue16(Sse2.packs_epi32(input, input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse32(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return IsFalse16(Sse2.packs_epi32(input, input));
            }
            else throw new IllegalInstructionException();
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
            else throw new IllegalInstructionException();
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
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsTrue64(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return 0x0101 & Sse2.movemask_epi8(input);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsFalse64(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return maxmath.andnot(0x0101, Sse2.movemask_epi8(input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsTrue64(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return 0x0101_0101 & Avx2.mm256_movemask_epi8(input);
            }
            else throw new IllegalInstructionException();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int IsFalse64(v256 input) 
        {
            if (Avx2.IsAvx2Supported)
            {
                return maxmath.andnot(0x0101_0101, Avx2.mm256_movemask_epi8(input));
            }
            else throw new IllegalInstructionException();
        }
    }
}