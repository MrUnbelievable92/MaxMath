using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epu32(v128 vector, v128 divisor, byte elements = 4)
		{
            if (BurstArchitecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPU32(divisor, elements))
				{
					return constrem_epu32(vector, divisor.UInt0);
				}

				switch (elements)
				{
					case  2: return (uint2)vector % new Divider<uint2>(divisor);
					case  3: return (uint3)vector % new Divider<uint3>(divisor);
					default: return (uint4)vector % new Divider<uint4>(divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epu32(v256 vector, v256 divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_SAME_EPU32(divisor))
				{
					return mm256_constrem_epu32(vector, divisor.UInt0);
				}

				return (uint8)vector % new Divider<uint8>((uint8)divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
