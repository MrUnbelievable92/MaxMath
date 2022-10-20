using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 rem_epi64(v128 vector, v128 divisor)
			{
				if (constexpr.ALL_SAME_EPI64(divisor))
				{
					return rem_epi64(vector, divisor.SLong0);
				}

				return new v128(save_rem(vector.SLong0, divisor.SLong0), save_rem(vector.SLong1, divisor.SLong1));
			}

			internal static v256 mm256_rem_epi64(v256 vector, v256 divisor, byte elements = 4)
			{
                if (Avx2.IsAvx2Supported)
                {
					if (constexpr.ALL_SAME_EPI64(divisor, elements))
					{
						return mm256_rem_epi64(vector, divisor.SLong0);
					}

					divisor = mm256_blendv_si256(divisor, Avx.mm256_set1_epi64x(1), Avx2.mm256_cmpeq_epi64(divisor, Avx.mm256_setzero_si256()));
					
					return new v256(save_rem(vector.SLong0, divisor.SLong0), save_rem(vector.SLong1, divisor.SLong1), save_rem(vector.SLong2, divisor.SLong2), save_rem(vector.SLong3, divisor.SLong3));
                }
				else throw new IllegalInstructionException();

			}
		}
	}
}
