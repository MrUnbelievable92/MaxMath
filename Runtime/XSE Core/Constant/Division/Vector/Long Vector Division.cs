using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constdiv_epi64(v128 vector, v128 divisor)
		{
            if (Architecture.IsSIMDSupported)
			{
				if (constexpr.ALL_SAME_EPI64(divisor))
				{
					return constdiv_epi64(vector, divisor.SLong0);
				}

				return (long2)vector / new Divider<long2>((long2)divisor);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epi64(v256 vector, v256 divisor, byte elements = 4)
		{
		    if (Avx2.IsAvx2Supported)
		    {
				if (constexpr.ALL_SAME_EPI64(divisor, elements))
				{
					return mm256_constdiv_epi64(vector, divisor.SLong0);
				}

				if (elements == 4)
				{
					return (long4)vector / new Divider<long4>((long4)divisor);
				}
				else
				{
					return (long3)vector / new Divider<long3>((long3)divisor);
				}
		    }
			else throw new IllegalInstructionException();
		}
	}
}
