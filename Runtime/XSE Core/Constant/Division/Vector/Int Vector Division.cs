using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constdiv_epi32(v128 vector, v128 divisor, byte elements = 4)
		{
            if (Architecture.IsSIMDSupported)
		    {
				if (constexpr.ALL_SAME_EPI32(divisor, elements))
				{
					return constdiv_epi32(vector, divisor.SInt0);
				}

				switch (elements)
				{
					case  2: return RegisterConversion.ToV128(RegisterConversion.ToInt2(vector) / new Divider<int2>(RegisterConversion.ToInt2(divisor)));
					case  3: return RegisterConversion.ToV128(RegisterConversion.ToInt3(vector) / new Divider<int3>(RegisterConversion.ToInt3(divisor)));
					default: return RegisterConversion.ToV128(RegisterConversion.ToInt4(vector) / new Divider<int4>(RegisterConversion.ToInt4(divisor)));
				}
		    }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epi32(v256 vector, v256 divisor)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_SAME_EPI32(divisor))
				{
					return mm256_constdiv_epi32(vector, divisor.SInt0);
				}

				return (int8)vector / new Divider<int8>((int8)divisor);
			}
			else throw new IllegalInstructionException();
		}
	}
}
