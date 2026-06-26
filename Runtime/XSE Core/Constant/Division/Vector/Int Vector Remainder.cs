using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epi32(v128 vector, v128 divisor, byte elements = 4)
		{
            if (BurstArchitecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPI32(divisor, elements))
				{
					return constrem_epi32(vector, divisor.SInt0);
				}

				switch (elements)
				{
					case  2: return (int2)vector % new Divider<int2>(divisor);
					case  3: return (int3)vector % new Divider<int3>(divisor);
					default: return (int4)vector % new Divider<int4>(divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epi32(v256 vector, v256 divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_SAME_EPI32(divisor))
				{
					return mm256_constrem_epi32(vector, divisor.SInt0);
				}

				return (int8)vector % new Divider<int8>((int8)divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
