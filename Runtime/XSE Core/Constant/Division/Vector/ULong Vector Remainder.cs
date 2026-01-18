using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epu64(v128 vector, v128 divisor)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.ALL_SAME_EPI64(divisor))
				{
					return constrem_epu64(vector, divisor.ULong0);
				}

				return (ulong2)vector % new Divider<ulong2>((ulong2)divisor);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epu64(v256 vector, v256 divisor, byte elements = 4)
		{
		    if (Avx2.IsAvx2Supported)
		    {
				if (constexpr.ALL_SAME_EPI64(divisor, elements))
				{
					return mm256_constrem_epu64(vector, divisor.ULong0);
				}

				if (elements == 4)
				{
					return (ulong4)vector % new Divider<ulong4>((ulong4)divisor);
				}
				else
				{
					return (ulong3)vector % new Divider<ulong3>((ulong3)divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}
	}
}
