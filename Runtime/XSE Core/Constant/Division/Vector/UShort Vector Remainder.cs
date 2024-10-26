using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static v128 constrem_epu16(v128 vector, v128 divisor, byte elements = 8)
		{
            if (Architecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPU16(divisor, elements))
				{
					return constrem_epu16(vector, divisor.UShort0);
				}

				switch (elements)
				{
					case  2: return (ushort2)vector % new Divider<ushort2>((ushort2)divisor);
					case  3: return (ushort3)vector % new Divider<ushort3>((ushort3)divisor);
					case  4: return (ushort4)vector % new Divider<ushort4>((ushort4)divisor);
					default: return (ushort8)vector % new Divider<ushort8>((ushort8)divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}

		public static v256 mm256_constrem_epu16(v256 vector, v256 divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_SAME_EPU16(divisor))
				{
					return mm256_constrem_epu16(vector, divisor.UShort0);
				}

				return (ushort16)vector % new Divider<ushort16>((ushort16)divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
