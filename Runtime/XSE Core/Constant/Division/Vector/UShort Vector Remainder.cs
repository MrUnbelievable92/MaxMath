using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 rem_epu16(v128 vector, v128 divisor, byte elements = 8)
			{
                if (Sse2.IsSse2Supported)
                {
					if (constexpr.ALL_SAME_EPU16(divisor, elements))
					{
						return rem_epu16(vector, divisor.UShort0);
					}

					divisor = blendv_si128(divisor, Sse2.set1_epi16(1), Sse2.cmpeq_epi16(divisor, Sse2.setzero_si128()));
					
					return new v128((ushort)(vector.UShort0 % divisor.UShort0), (ushort)(vector.UShort1 % divisor.UShort1), (ushort)(vector.UShort2 % divisor.UShort2), (ushort)(vector.UShort3 % divisor.UShort3), (ushort)(vector.UShort4 % divisor.UShort4), (ushort)(vector.UShort5 % divisor.UShort5), (ushort)(vector.UShort6 % divisor.UShort6), (ushort)(vector.UShort7 % divisor.UShort7));
                }
				else throw new IllegalInstructionException();
			}

			internal static v256 mm256_rem_epu16(v256 vector, v256 divisor)
			{
				if (constexpr.ALL_SAME_EPU16(divisor))
				{
					return mm256_rem_epu16(vector, divisor.UShort0);
				}

				return new v256((ushort)(vector.UShort0 % divisor.UShort0), (ushort)(vector.UShort1 % divisor.UShort1), (ushort)(vector.UShort2 % divisor.UShort2), (ushort)(vector.UShort3 % divisor.UShort3), (ushort)(vector.UShort4 % divisor.UShort4), (ushort)(vector.UShort5 % divisor.UShort5), (ushort)(vector.UShort6 % divisor.UShort6), (ushort)(vector.UShort7 % divisor.UShort7), (ushort)(vector.UShort8 % divisor.UShort8), (ushort)(vector.UShort9 % divisor.UShort9), (ushort)(vector.UShort10 % divisor.UShort10), (ushort)(vector.UShort11 % divisor.UShort11), (ushort)(vector.UShort12 % divisor.UShort12), (ushort)(vector.UShort13 % divisor.UShort13), (ushort)(vector.UShort14 % divisor.UShort14), (ushort)(vector.UShort15 % divisor.UShort15));
			}
		}
	}
}
