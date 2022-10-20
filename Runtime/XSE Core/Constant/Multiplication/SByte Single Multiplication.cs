using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			public static v128 mullo_epi8(v128 a, sbyte b, byte elements = 16)
			{
				if (ALL_GE_EPI8(a, 0, elements))
				{
					return mullo_epu8(a, (byte)b, elements);
				}
				else
				{
					if (Sse2.IsSse2Supported)
					{
						switch (b)
						{
							default:
							{
								v128 MASK = Sse2.set1_epi16(byte.MaxValue);
								v128 B = Sse2.set1_epi16(b);

						        if (elements == 16)
						        {
									v128 lo = cvt2x2epi8_epi16(a, out v128 hi);
									lo = cvtepi16_epi8(Sse2.mullo_epi16(lo, B));
									hi = cvtepi16_epi8(Sse2.mullo_epi16(hi, B));

									return Sse2.unpacklo_epi64(lo, hi);
						        }
								else
								{
									return cvtepi16_epi8(Sse2.and_si128(MASK, Sse2.mullo_epi16(cvtepi8_epi16(a), B)));
								}
							}
						}
					}
					else throw new IllegalInstructionException();
				}
            }

			public static v256 mm256_mullo_epi8(v256 a, sbyte b)
			{
				if (ALL_GE_EPI8(a, 0))
				{
					return mm256_mullo_epu8(a, (byte)b);
				}
				else
				{
					if (Avx2.IsAvx2Supported)
					{
						switch (b)
						{
							default:
							{
								v256 MASK = new v256(0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1,  	0, 2, 4, 6, 8, 10, 12, 14,    -1, -1, -1, -1, -1, -1, -1, -1);
								v256 B = Avx.mm256_set1_epi16(b);
								
								v256 lo = mm256_cvt2x2epi8_epi16(a, out v256 hi);
								lo = Avx2.mm256_shuffle_epi8(Avx2.mm256_mullo_epi16(lo, B), MASK);
								hi = Avx2.mm256_shuffle_epi8(Avx2.mm256_mullo_epi16(hi, B), MASK);
								
								return Avx2.mm256_unpacklo_epi64(lo, hi);
							}
						}
					}
					else throw new IllegalInstructionException();
				}
			}
		}
	}
}