using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epu16(v128 vector, ushort divisor, byte elements = 8)
		{
            if (Architecture.IsSIMDSupported)
			{
				switch (elements)
				{
					case  2: return (ushort2)vector % new Divider<ushort>(divisor);
					case  3: return (ushort3)vector % new Divider<ushort>(divisor);
					case  4: return (ushort4)vector % new Divider<ushort>(divisor);
					default: return (ushort8)vector % new Divider<ushort>(divisor);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epu16(v256 vector, ushort divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				return (ushort16)vector % new Divider<ushort>(divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
