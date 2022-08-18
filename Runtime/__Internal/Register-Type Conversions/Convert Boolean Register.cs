using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class RegisterConversion
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsTrue8<T>(v128 input)
            where T : unmanaged
        {
            if (Sse2.IsSse2Supported)
            {
                return ToType<T>(Xse.negmask_epi8(input));  
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsFalse8<T>(v128 input)
            where T : unmanaged
        {
            if (Sse2.IsSse2Supported)
            {
                return ToType<T>(Xse.inc_epi8(input));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 IsTrue8(v256 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_abs_epi8(input);  
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
        internal static T IsTrue16<T>(v128 input)
            where T : unmanaged
        {
            if (Sse2.IsSse2Supported)
            {
                return ToType<T>(IsTrue8<v128>(Sse2.packs_epi16(input, input)));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsFalse16<T>(v128 input)
            where T : unmanaged
        {
            if (Sse2.IsSse2Supported)
            {
                return ToType<T>(IsFalse8<v128>(Sse2.packs_epi16(input, input)));
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
                
                return IsTrue8<v128>(Sse2.packs_epi16(lo, hi));
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
                
                return IsFalse8<v128>(Sse2.packs_epi16(lo, hi));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsTrue32<T>(v128 input)
            where T : unmanaged
        {
            if (Sse2.IsSse2Supported)
            {
                return ToType<T>(IsTrue16<v128>(Sse2.packs_epi32(input, input)));
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
                
                return IsTrue8<v128>(Sse2.packs_epi16(_16, _16));
            }
            else if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                v128 _16 = Sse2.packs_epi32(lo, hi);
                
                return IsTrue8<v128>(Sse2.packs_epi16(_16, _16));
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
                
                return IsFalse8<v128>(Sse2.packs_epi16(_16, _16));
            }
            else if (Avx.IsAvxSupported)
            {
                v128 lo = Avx.mm256_castsi256_si128(input);
                v128 hi = Avx.mm256_extractf128_ps(input, 1);

                v128 _16 = Sse2.packs_epi32(lo, hi);
                
                return IsTrue8<v128>(Sse2.packs_epi16(_16, _16));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsTrue64<T>(v128 input)
            where T : unmanaged
        {
            if (Sse2.IsSse2Supported)
            {
                int r = 0x0101 & Sse2.movemask_epi8(input);

                return *(T*)&r;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsFalse64<T>(v128 input)
            where T : unmanaged
        {
            if (Sse2.IsSse2Supported)
            {
                int r = maxmath.andnot(0x0101, Sse2.movemask_epi8(input));

                return *(T*)&r;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsTrue64<T>(v256 input)
            where T : unmanaged
        {
            if (Avx2.IsAvx2Supported)
            {
                int r = 0x0101_0101 & Avx2.mm256_movemask_epi8(input);

                return *(T*)&r;
            }
            else throw new IllegalInstructionException();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T IsFalse64<T>(v256 input) 
            where T : unmanaged
        {
            if (Avx2.IsAvx2Supported)
            {
                int r = maxmath.andnot(0x0101_0101, Avx2.mm256_movemask_epi8(input));

                return *(T*)&r;
            }
            else throw new IllegalInstructionException();
        }
    }
}