using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epi8(v128 vector, sbyte divisor, byte elements = 16)
		{
            if (Architecture.IsSIMDSupported)
			{
				switch (elements)
				{
					case  2: return (sbyte2) vector % new Divider<sbyte>(divisor);
					case  3: return (sbyte3) vector % new Divider<sbyte>(divisor);
					case  4: return (sbyte4) vector % new Divider<sbyte>(divisor);
					case  8: return (sbyte8) vector % new Divider<sbyte>(divisor);
					default: return (sbyte16)vector % new Divider<sbyte>(divisor);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epi8(v256 vector, sbyte divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				return (sbyte32)vector % new Divider<sbyte>(divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
