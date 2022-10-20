using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 rem_epu64(v128 vector, v128 divisor)
			{
				if (constexpr.ALL_SAME_EPU64(divisor))
				{
					return rem_epu64(vector, divisor.ULong0);
				}

				return new v128((ulong)(vector.ULong0 % divisor.ULong0), (ulong)(vector.ULong1 % divisor.ULong1));
			}

			internal static v256 mm256_rem_epu64(v256 vector, v256 divisor, byte elements = 4)
			{
                if (Avx2.IsAvx2Supported)
                {
					if (constexpr.ALL_SAME_EPU64(divisor, elements))
					{
						return mm256_rem_epu64(vector, divisor.ULong0);
					}

					divisor = mm256_blendv_si256(divisor, Avx.mm256_set1_epi64x(1), Avx2.mm256_cmpeq_epi64(divisor, Avx.mm256_setzero_si256()));

					return new v256((ulong)(vector.ULong0 % divisor.ULong0), (ulong)(vector.ULong1 % divisor.ULong1), (ulong)(vector.ULong2 % divisor.ULong2), (ulong)(vector.ULong3 % divisor.ULong3));
                }
				else throw new IllegalInstructionException();
			}
		}
	}
}
