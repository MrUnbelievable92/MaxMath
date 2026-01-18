using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epu8(v128 vector, v128 divisor, byte elements = 16)
		{
            if (BurstArchitecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPU8(divisor, elements))
				{
					return constrem_epu8(vector, divisor.Byte0);
				}

				switch (elements)
				{
					case  2: return (byte2) vector % new Divider<byte2> ((byte2) divisor);
					case  3: return (byte3) vector % new Divider<byte3> ((byte3) divisor);
					case  4: return (byte4) vector % new Divider<byte4> ((byte4) divisor);
					case  8: return (byte8) vector % new Divider<byte8> ((byte8) divisor);
					default: return (byte16)vector % new Divider<byte16>((byte16)divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epu8(v256 vector, v256 divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_SAME_EPU8(divisor))
				{
					return mm256_constrem_epu8(vector, divisor.Byte0);
				}

				return (byte32)vector % new Divider<byte32>((byte32)divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
