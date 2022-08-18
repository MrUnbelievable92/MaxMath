using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 div_epu32(v128 vector, v128 divisor, byte elements = 4)
			{
                if (Sse2.IsSse2Supported)
                {
					if (constexpr.ALL_SAME_EPU32(divisor, elements))
					{
						return div_epu32(vector, divisor.UInt0);
					}

					divisor = blendv_si128(divisor, Sse2.set1_epi32(1), Sse2.cmpeq_epi32(divisor, Sse2.setzero_si128()));
					
					return new v128((uint)(vector.UInt0 / divisor.UInt0), (uint)(vector.UInt1 / divisor.UInt1), (uint)(vector.UInt2 / divisor.UInt2), (uint)(vector.UInt3 / divisor.UInt3));
                }
				else throw new IllegalInstructionException();
			}

			internal static v256 mm256_div_epu32(v256 vector, v256 divisor)
			{
				if (constexpr.ALL_SAME_EPU32(divisor))
				{
					return mm256_div_epu32(vector, divisor.UInt0);
				}

				return new v256((uint)(vector.UInt0 / divisor.UInt0), (uint)(vector.UInt1 / divisor.UInt1), (uint)(vector.UInt2 / divisor.UInt2), (uint)(vector.UInt3 / divisor.UInt3), (uint)(vector.UInt4 / divisor.UInt4), (uint)(vector.UInt5 / divisor.UInt5), (uint)(vector.UInt6 / divisor.UInt6), (uint)(vector.UInt7 / divisor.UInt7));
			}
		}
	}
}
