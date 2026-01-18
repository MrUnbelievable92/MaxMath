using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epi64(v128 vector, long divisor)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
				return (long2)vector % new Divider<long>(divisor);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epi64(v256 vector, long divisor, byte elements = 4)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (elements == 4)
				{
					return (long4)vector % new Divider<long>(divisor);
				}
				else
				{
					return (long3)vector % new Divider<long>(divisor);
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}
