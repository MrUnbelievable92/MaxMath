using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epi16(v128 vector, v128 divisor, byte elements = 8)
		{
            if (BurstArchitecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPI16(divisor, elements))
				{
					return constrem_epi16(vector, divisor.SShort0);
				}

				switch (elements)
				{
					case  2: return (short2)vector % new Divider<short2>((short2)divisor);
					case  3: return (short3)vector % new Divider<short3>((short3)divisor);
					case  4: return (short4)vector % new Divider<short4>((short4)divisor);
					default: return (short8)vector % new Divider<short8>((short8)divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epi16(v256 vector, v256 divisor)
		{
		    if (Avx2.IsAvx2Supported)
		    {
				if (constexpr.ALL_SAME_EPI16(divisor))
				{
					return mm256_constrem_epi16(vector, divisor.SShort0);
				}

				return (short16)vector % new Divider<short16>((short16)divisor);
		    }
			else throw new IllegalInstructionException();
		}
	}
}
