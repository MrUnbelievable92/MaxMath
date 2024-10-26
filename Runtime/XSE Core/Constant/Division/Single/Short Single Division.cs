using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constdiv_epi16(v128 vector, short divisor, byte elements = 8)
		{
            if (Architecture.IsSIMDSupported)
			{
				switch (elements)
				{
					case  2: return (short2)vector / new Divider<short>(divisor);
					case  3: return (short3)vector / new Divider<short>(divisor);
					case  4: return (short4)vector / new Divider<short>(divisor);
					default: return (short8)vector / new Divider<short>(divisor);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epi16(v256 vector, short divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				return (short16)vector / new Divider<short>(divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
