using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epu32(v128 vector, uint divisor, byte elements = 4)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				switch (elements)
				{
					case  2: return (uint2)vector % new Divider<uint>(divisor);
					case  3: return (uint3)vector % new Divider<uint>(divisor);
					default: return (uint4)vector % new Divider<uint>(divisor);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epu32(v256 vector, uint divisor)
		{
            if (Avx2.IsAvx2Supported)
            {
				return (uint8)vector % new Divider<uint>(divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
