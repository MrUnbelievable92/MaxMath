using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constmullo_epi8(v128 a, sbyte b, byte elements = 16)
		{
            if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.ALL_GE_EPI8(a, 0, elements))
				{
					return constmullo_epu8(a, (byte)b, elements);
				}
				else
				{
					if (Sse2.IsSse2Supported)
					{
						v128 B = set1_epi16(b);

						if (elements == 16)
						{
							v128 lo = cvt2x2epi8_epi16(a, out v128 hi);

							return cvt2x2epi16_epi8(mullo_epi16(lo, B), mullo_epi16(hi, B));
						}
						else
						{
							return cvtepi16_epi8(mullo_epi16(cvtepi8_epi16(a), B));
						}
					}
					else
					{
						return mullo_epi8(a, set1_epi8(b));
					}
				}
			}
			else throw new IllegalInstructionException();
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constmullo_epi8(v256 a, sbyte b)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.ALL_GE_EPI8(a, 0))
				{
					return mm256_constmullo_epu8(a, (byte)b);
				}
				else
				{
					v256 B = mm256_set1_epi16(b);
					v256 lo = mm256_cvt2x2epi8_epi16(a, out v256 hi);

					return mm256_cvt2x2epi16_epi8(Avx2.mm256_mullo_epi16(lo, B), Avx2.mm256_mullo_epi16(hi, B));
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}