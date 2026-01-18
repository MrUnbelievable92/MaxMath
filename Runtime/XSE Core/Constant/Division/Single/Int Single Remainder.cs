using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epi32(v128 vector, int divisor, byte elements = 4)
		{
            if (BurstArchitecture.IsSIMDSupported)
		    {
				switch (elements)
				{
					case  2: return RegisterConversion.ToV128(RegisterConversion.ToInt2(vector) % new Divider<int>(divisor));
					case  3: return RegisterConversion.ToV128(RegisterConversion.ToInt3(vector) % new Divider<int>(divisor));
					default: return RegisterConversion.ToV128(RegisterConversion.ToInt4(vector) % new Divider<int>(divisor));
				}
		    }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epi32(v256 vector, int divisor)
		{
		    if (Avx2.IsAvx2Supported)
		    {
				return (int8)vector % new Divider<int>(divisor);
		    }
			else throw new IllegalInstructionException();
		}
	}
}
