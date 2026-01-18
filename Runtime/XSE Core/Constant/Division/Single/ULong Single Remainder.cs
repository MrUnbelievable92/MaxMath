using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epu64(v128 vector, ulong divisor)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
				return (ulong2)vector % new Divider<ulong>(divisor);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epu64(v256 vector, ulong divisor, byte elements = 4)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (elements == 4)
				{
					return (ulong4)vector % new Divider<ulong>(divisor);
				}
				else
				{
					return (ulong3)vector % new Divider<ulong>(divisor);
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}
