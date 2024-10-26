using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static v128 constdiv_epu32(v128 vector, v128 divisor, byte elements = 4)
		{
            if (Architecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPU32(divisor, elements))
				{
					return constdiv_epu32(vector, divisor.UInt0);
				}

				switch (elements)
				{
					case  2: return RegisterConversion.ToV128(RegisterConversion.ToUInt2(vector) / new Divider<uint2>(RegisterConversion.ToUInt2(divisor)));
					case  3: return RegisterConversion.ToV128(RegisterConversion.ToUInt3(vector) / new Divider<uint3>(RegisterConversion.ToUInt3(divisor)));
					default: return RegisterConversion.ToV128(RegisterConversion.ToUInt4(vector) / new Divider<uint4>(RegisterConversion.ToUInt4(divisor)));
				}
		    }
			else throw new IllegalInstructionException();
		}

		public static v256 mm256_constdiv_epu32(v256 vector, v256 divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_SAME_EPU32(divisor))
				{
					return mm256_constdiv_epu32(vector, divisor.UInt0);
				}

				return (uint8)vector / new Divider<uint8>((uint8)divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
