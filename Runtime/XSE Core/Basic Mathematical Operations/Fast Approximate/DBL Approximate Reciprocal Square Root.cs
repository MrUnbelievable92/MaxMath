using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
        internal const ulong MAGIC_RSQRT_PD = 0xBFCD_D6A1_8F6A_6F55ul;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rsqrt_sd(v128 a)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC = cvtsi64x_si128(MAGIC_RSQRT_PD);

                v128 g = srli_epi64(sub_epi64(MAGIC, a), 1);

                v128 mHalfA = mul_sd(a, set1_pd(-0.5d));
                v128 gSq = mul_sd(g, g);
                v128 threeHalfsG = mul_sd(g, set1_pd(3d / 2d));

                return fmadd_pd(mul_sd(mHalfA, g), gSq, threeHalfsG);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrsqrteq_f64(a);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rsqrt_pd(v128 a)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC = set1_epi64x(MAGIC_RSQRT_PD);

                v128 g = srli_epi64(sub_epi64(MAGIC, a), 1);

                v128 mHalfA = mul_pd(a, set1_pd(-0.5d));
                v128 gSq = mul_pd(g, g);
                v128 threeHalfsG = mul_pd(g, set1_pd(3d / 2d));

                return fmadd_pd(mul_pd(mHalfA, g), gSq, threeHalfsG);
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return Arm.Neon.vrsqrteq_f64(a);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_rsqrt_pd(v256 a)
		{
            if (Avx2.IsAvx2Supported)
            {
                v256 MAGIC = mm256_set1_epi64x(MAGIC_RSQRT_PD);

                v256 g = Avx2.mm256_srli_epi64(Avx2.mm256_sub_epi64(MAGIC, a), 1);

                v256 mHalfA = Avx.mm256_mul_pd(a, mm256_set1_pd(-0.5d));
                v256 gSq = Avx.mm256_mul_pd(g, g);
                v256 threeHalfsG = Avx.mm256_mul_pd(g, mm256_set1_pd(3d / 2d));

                return mm256_fmadd_pd(Avx.mm256_mul_pd(mHalfA, g), gSq, threeHalfsG);
            }
            else throw new IllegalInstructionException();
		}
	}
}