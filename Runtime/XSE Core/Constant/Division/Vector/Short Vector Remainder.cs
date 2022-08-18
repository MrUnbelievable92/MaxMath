using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 rem_epi16(v128 vector, v128 divisor, byte elements = 8)
			{
                if (Sse2.IsSse2Supported)
                {
					if (constexpr.ALL_SAME_EPI16(divisor, elements))
					{
						return rem_epi16(vector, divisor.SShort0);
					}

					divisor = blendv_si128(divisor, Sse2.set1_epi16(1), Sse2.cmpeq_epi16(divisor, Sse2.setzero_si128()));
					
					return new v128((short)(vector.SShort0 % divisor.SShort0), (short)(vector.SShort1 % divisor.SShort1), (short)(vector.SShort2 % divisor.SShort2), (short)(vector.SShort3 % divisor.SShort3), (short)(vector.SShort4 % divisor.SShort4), (short)(vector.SShort5 % divisor.SShort5), (short)(vector.SShort6 % divisor.SShort6), (short)(vector.SShort7 % divisor.SShort7));
                }
				else throw new IllegalInstructionException();
			}

			internal static v256 mm256_rem_epi16(v256 vector, v256 divisor)
			{
				if (constexpr.ALL_SAME_EPI16(divisor))
				{
					return mm256_rem_epi16(vector, divisor.SShort0);
				}

				return new v256((short)(vector.SShort0 % divisor.SShort0), (short)(vector.SShort1 % divisor.SShort1), (short)(vector.SShort2 % divisor.SShort2), (short)(vector.SShort3 % divisor.SShort3), (short)(vector.SShort4 % divisor.SShort4), (short)(vector.SShort5 % divisor.SShort5), (short)(vector.SShort6 % divisor.SShort6), (short)(vector.SShort7 % divisor.SShort7), (short)(vector.SShort8 % divisor.SShort8), (short)(vector.SShort9 % divisor.SShort9), (short)(vector.SShort10 % divisor.SShort10), (short)(vector.SShort11 % divisor.SShort11), (short)(vector.SShort12 % divisor.SShort12), (short)(vector.SShort13 % divisor.SShort13), (short)(vector.SShort14 % divisor.SShort14), (short)(vector.SShort15 % divisor.SShort15));
			}
		}
	}
}
