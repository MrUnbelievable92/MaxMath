using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static v128 constrem_epi8(v128 vector, v128 divisor, byte elements = 16)
		{
            if (Architecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPI8(divisor, elements))
				{
					return constrem_epi8(vector, divisor.SByte0);
				}

				switch (elements)
				{
					case  2: return (sbyte2) vector % new Divider<sbyte2> ((sbyte2) divisor);
					case  3: return (sbyte3) vector % new Divider<sbyte3> ((sbyte3) divisor);
					case  4: return (sbyte4) vector % new Divider<sbyte4> ((sbyte4) divisor);
					case  8: return (sbyte8) vector % new Divider<sbyte8> ((sbyte8) divisor);
					default: return (sbyte16)vector % new Divider<sbyte16>((sbyte16)divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}

		public static v256 mm256_constrem_epi8(v256 vector, v256 divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_SAME_EPI8(divisor))
				{
					return mm256_constrem_epi8(vector, divisor.SByte0);
				}

				return (sbyte32)vector % new Divider<sbyte32>((sbyte32)divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
