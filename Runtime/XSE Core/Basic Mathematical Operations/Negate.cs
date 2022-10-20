using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 neg_epi8(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(Sse2.setzero_si128(), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 neg_epi16(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(Sse2.setzero_si128(), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 neg_epi32(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi32(Sse2.setzero_si128(), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 neg_epi64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi64(Sse2.setzero_si128(), a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_neg_epi8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(Avx.mm256_setzero_si256(), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_neg_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(Avx.mm256_setzero_si256(), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_neg_epi32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(Avx.mm256_setzero_si256(), a);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_neg_epi64(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(Avx.mm256_setzero_si256(), a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 neg_ph(v128 a)
        {
            if (Sse.IsSseSupported)
            {
                return Sse.xor_ps(a, new v128(unchecked((short)(1 << 15))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 neg_ps(v128 a)
        {
            if (Sse.IsSseSupported)
            {
                return Sse.xor_ps(a, new v128(1 << 31));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 neg_pd(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_pd(a, new v128(1L << 63));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_neg_ph(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_xor_ps(a, new v256(unchecked((short)(1 << 15))));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_neg_ps(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_xor_ps(a, new v256(1 << 31));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_neg_pd(v256 a)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_xor_pd(a, new v256(1L << 63));
            }
            else throw new IllegalInstructionException();
        }
    }
}
