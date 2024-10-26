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
            if (Architecture.IsSIMDSupported)
            {
                return Xse.and_si128(input, Xse.set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse8(v128 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.andnot_si128(input, Xse.set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 IsTrue8(v256 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(input, Xse.mm256_set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 IsFalse8(v256 input)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_andnot_ps(input, Xse.mm256_set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue16(v128 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return IsTrue8(Xse.packs_epi16(input, input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse16(v128 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return IsFalse8(Xse.packs_epi16(input, input));
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

                return IsTrue8(Xse.packs_epi16(lo, hi));
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

                return IsFalse8(Xse.packs_epi16(lo, hi));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue32(v128 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return IsTrue16(Xse.packs_epi32(input, input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse32(v128 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return IsFalse16(Xse.packs_epi32(input, input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue32(v256 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                return IsTrue16(Xse.packs_epi32(lo, hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse32(v256 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                return IsFalse16(Xse.packs_epi32(lo, hi));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue64(v128 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return IsTrue32(Xse.packs_epi32(input, input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse64(v128 input)
        {
            if (Architecture.IsSIMDSupported)
            {
                return IsFalse32(Xse.packs_epi32(input, input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsTrue64(v256 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                return IsTrue32(Xse.packs_epi32(lo, hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 IsFalse64(v256 input)
        {
            if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                return IsFalse32(Xse.packs_epi32(lo, hi));
            }
            else throw new IllegalInstructionException();
        }
    }
}