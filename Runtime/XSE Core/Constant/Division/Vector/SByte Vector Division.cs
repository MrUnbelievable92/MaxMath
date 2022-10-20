using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			internal static v128 div_epi8(v128 vector, v128 divisor, byte elements = 16)
			{
                if (Sse2.IsSse2Supported)
                {
					if (constexpr.ALL_SAME_EPI8(divisor, elements))
					{
						return div_epi8(vector, divisor.SByte0, elements);
					}

					divisor = blendv_si128(divisor, Sse2.set1_epi8(1), Sse2.cmpeq_epi8(divisor, Sse2.setzero_si128()));
					
					return new v128((sbyte)(vector.SByte0 / divisor.SByte0), (sbyte)(vector.SByte1 / divisor.SByte1), (sbyte)(vector.SByte2 / divisor.SByte2), (sbyte)(vector.SByte3 / divisor.SByte3), (sbyte)(vector.SByte4 / divisor.SByte4), (sbyte)(vector.SByte5 / divisor.SByte5), (sbyte)(vector.SByte6 / divisor.SByte6), (sbyte)(vector.SByte7 / divisor.SByte7), (sbyte)(vector.SByte8 / divisor.SByte8), (sbyte)(vector.SByte9 / divisor.SByte9), (sbyte)(vector.SByte10 / divisor.SByte10), (sbyte)(vector.SByte11 / divisor.SByte11), (sbyte)(vector.SByte12 / divisor.SByte12), (sbyte)(vector.SByte13 / divisor.SByte13), (sbyte)(vector.SByte14 / divisor.SByte14), (sbyte)(vector.SByte15 / divisor.SByte15));
                }
				else throw new IllegalInstructionException();
			}

			internal static v256 mm256_div_epi8(v256 vector, v256 divisor)
			{
				if (constexpr.ALL_SAME_EPI8(divisor))
				{
					return mm256_div_epi8(vector, divisor.SByte0);
				}

				return new v256((sbyte)(vector.SByte0 / divisor.SByte0), (sbyte)(vector.SByte1 / divisor.SByte1), (sbyte)(vector.SByte2 / divisor.SByte2), (sbyte)(vector.SByte3 / divisor.SByte3), (sbyte)(vector.SByte4 / divisor.SByte4), (sbyte)(vector.SByte5 / divisor.SByte5), (sbyte)(vector.SByte6 / divisor.SByte6), (sbyte)(vector.SByte7 / divisor.SByte7), (sbyte)(vector.SByte8 / divisor.SByte8), (sbyte)(vector.SByte9 / divisor.SByte9), (sbyte)(vector.SByte10 / divisor.SByte10), (sbyte)(vector.SByte11 / divisor.SByte11), (sbyte)(vector.SByte12 / divisor.SByte12), (sbyte)(vector.SByte13 / divisor.SByte13), (sbyte)(vector.SByte14 / divisor.SByte14), (sbyte)(vector.SByte15 / divisor.SByte15), (sbyte)(vector.SByte16 / divisor.SByte16), (sbyte)(vector.SByte17 / divisor.SByte17), (sbyte)(vector.SByte18 / divisor.SByte18), (sbyte)(vector.SByte19 / divisor.SByte19), (sbyte)(vector.SByte20 / divisor.SByte20), (sbyte)(vector.SByte21 / divisor.SByte21), (sbyte)(vector.SByte22 / divisor.SByte22), (sbyte)(vector.SByte23 / divisor.SByte23), (sbyte)(vector.SByte24 / divisor.SByte24), (sbyte)(vector.SByte25 / divisor.SByte25), (sbyte)(vector.SByte26 / divisor.SByte26), (sbyte)(vector.SByte27 / divisor.SByte27), (sbyte)(vector.SByte28 / divisor.SByte28), (sbyte)(vector.SByte29 / divisor.SByte29), (sbyte)(vector.SByte30 / divisor.SByte30), (sbyte)(vector.SByte31 / divisor.SByte31));
			}
		}
	}
}
