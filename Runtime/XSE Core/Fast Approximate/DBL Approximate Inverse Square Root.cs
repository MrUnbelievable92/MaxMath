using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
        internal const ulong  MAGIC_RSQRT_PD_GUESS = 0x5FE6_EB50_C7B5_37A9ul;
        internal const double MAGIC_RSQRT_PD_MUL = 0.7039522544782403d;
        internal const double MAGIC_RSQRT_PD_SUB = 2.3892445721476962d;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rsqrt_sd(v128 a)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC_GUESS = Sse2.cvtsi64x_si128((long)MAGIC_RSQRT_PD_GUESS);
                v128 MAGIC_MUL = Sse2.cvtsi64x_si128(Unity.Mathematics.math.aslong(MAGIC_RSQRT_PD_MUL));
                v128 MAGIC_SUB = Sse2.cvtsi64x_si128(Unity.Mathematics.math.aslong(MAGIC_RSQRT_PD_SUB));

                v128 guess = Sse2.sub_epi64(MAGIC_GUESS, Sse2.srli_epi64(a, 1));
                v128 prod = Sse2.mul_sd(guess, MAGIC_MUL);
                guess = Sse2.mul_sd(guess, guess);
                guess = fnmadd_pd(a, guess, MAGIC_SUB);

                return Sse2.mul_sd(prod, guess);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rsqrt_pd(v128 a)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC_GUESS = Sse2.set1_epi64x((long)MAGIC_RSQRT_PD_GUESS);
                v128 MAGIC_MUL = Sse2.set1_pd(MAGIC_RSQRT_PD_MUL);
                v128 MAGIC_SUB = Sse2.set1_pd(MAGIC_RSQRT_PD_SUB);

                v128 guess = Sse2.sub_epi64(MAGIC_GUESS, Sse2.srli_epi64(a, 1));
                v128 prod = Sse2.mul_pd(guess, MAGIC_MUL);
                guess = Sse2.mul_pd(guess, guess);
                guess = fnmadd_pd(a, guess, MAGIC_SUB);

                return Sse2.mul_pd(prod, guess);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_rsqrt_pd(v256 a)
		{
            if (Avx2.IsAvx2Supported)
            {
                v256 MAGIC_GUESS = Avx.mm256_set1_epi64x((long)MAGIC_RSQRT_PD_GUESS);
                v256 MAGIC_MUL = Avx.mm256_set1_pd(MAGIC_RSQRT_PD_MUL);
                v256 MAGIC_SUB = Avx.mm256_set1_pd(MAGIC_RSQRT_PD_SUB);

                v256 guess = Avx2.mm256_sub_epi64(MAGIC_GUESS, Avx2.mm256_srli_epi64(a, 1));
                v256 prod = Avx.mm256_mul_pd(guess, MAGIC_MUL);
                guess = Avx.mm256_mul_pd(guess, guess);
                guess = mm256_fnmadd_pd(a, guess, MAGIC_SUB);

                return Avx.mm256_mul_pd(prod, guess);
            }
            else throw new IllegalInstructionException();
		}
	}
}