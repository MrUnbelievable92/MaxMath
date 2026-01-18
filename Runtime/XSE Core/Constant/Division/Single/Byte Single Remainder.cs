using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constrem_epu8(v128 vector, byte divisor, byte elements = 16)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (divisor > 0b1000_0000)
                {
					v128 DIV = set1_epi8(divisor);
					v128 resultQuestionMark = sub_epi8(vector, DIV);

					v128 result = blendv_si128(vector, resultQuestionMark, cmpge_epu8(vector, DIV, elements));
					constexpr.ASSUME_LT_EPU8(result, divisor);
					return result;
                }

				switch (elements)
				{
					case  2: return (byte2) vector % new Divider<byte>(divisor);
					case  3: return (byte3) vector % new Divider<byte>(divisor);
					case  4: return (byte4) vector % new Divider<byte>(divisor);
					case  8: return (byte8) vector % new Divider<byte>(divisor);
					default: return (byte16)vector % new Divider<byte>(divisor);
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constrem_epu8(v256 vector, byte divisor)
		{
            if (Avx2.IsAvx2Supported)
            {
                if (divisor > 0b1000_0000)
                {
					v256 DIV = mm256_set1_epi8(divisor);
					v256 resultQuestionMark = Avx2.mm256_sub_epi8(vector, DIV);

					v256 result = Avx2.mm256_blendv_epi8(vector, resultQuestionMark, mm256_cmpge_epu8(vector, DIV));
					constexpr.ASSUME_LT_EPU8(result, divisor);
					return result;
                }

				return (byte32)vector % new Divider<byte>(divisor);
            }
			else throw new IllegalInstructionException();
		}
	}
}
