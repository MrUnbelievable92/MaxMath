using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 rem_epi32(v128 vector, v128 divisor, byte elements = 4)
			{
                if (Sse2.IsSse2Supported)
                {
					if (constexpr.ALL_SAME_EPI32(divisor, elements))
					{
						return rem_epi32(vector, divisor.SInt0);
					}

					divisor = blendv_si128(divisor, Sse2.set1_epi32(1), Sse2.cmpeq_epi32(divisor, Sse2.setzero_si128()));

					return new v128((int)((long)vector.SInt0 % divisor.SInt0), (int)((long)vector.SInt1 % divisor.SInt1), (int)((long)vector.SInt2 % divisor.SInt2), (int)((long)vector.SInt3 % divisor.SInt3));
                }
				else throw new IllegalInstructionException();
			}

			internal static v256 mm256_rem_epi32(v256 vector, v256 divisor)
			{
				if (constexpr.ALL_SAME_EPI32(divisor))
				{
					return mm256_rem_epi32(vector, divisor.SInt0);
				}

				return new v256((int)((long)vector.SInt0 % divisor.SInt0), (int)((long)vector.SInt1 % divisor.SInt1), (int)((long)vector.SInt2 % divisor.SInt2), (int)((long)vector.SInt3 % divisor.SInt3), (int)((long)vector.SInt4 % divisor.SInt4), (int)((long)vector.SInt5 % divisor.SInt5), (int)((long)vector.SInt6 % divisor.SInt6), (int)((long)vector.SInt7 % divisor.SInt7));
			}
		}
	}
}
