using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
        internal const long MAGIC_RCP_PD = 0x7FDE_6238_22FC_16E6;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rcp_sd(v128 a)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC = Sse2.cvtsi64x_si128(MAGIC_RCP_PD);
                v128 TWO = Sse2.cvtsi64x_si128(Unity.Mathematics.math.aslong(2d));

                v128 guess = Sse2.sub_epi64(MAGIC, a);
                a = fnmadd_pd(a, guess, TWO);  

                return Sse2.mul_sd(a, guess);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 rcp_pd(v128 a)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC = Sse2.set1_epi64x(MAGIC_RCP_PD);
                v128 TWO = Sse2.set1_pd(2d);

                v128 guess = Sse2.sub_epi64(MAGIC, a);
                a = fnmadd_pd(a, guess, TWO);  

                return Sse2.mul_pd(a, guess);
            }
            else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_rcp_pd(v256 a)
		{
            if (Avx2.IsAvx2Supported)
            {
                v256 MAGIC = Avx.mm256_set1_epi64x(MAGIC_RCP_PD);
                v256 TWO = Avx.mm256_set1_pd(2d);

                v256 guess = Avx2.mm256_sub_epi64(MAGIC, a);
                a = mm256_fnmadd_pd(a, guess, TWO); 

                return Avx.mm256_mul_pd(a, guess);
            }
            else throw new IllegalInstructionException();
		}
	}
}