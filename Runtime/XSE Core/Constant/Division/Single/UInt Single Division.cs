using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v128 div_epu32(v128 vector, uint divisor, byte elements = 4, bool __unsafe = false)
			{
                if (Sse2.IsSse2Supported)
                {
					switch (divisor)
					{
						case 3:
						{
                            if (__unsafe || ALL_LE_EPU32(vector, 0x7FFF_FFFFu, elements))
                            {
								v128 RCP3 = Sse2.set1_epi64x(1_431_655_766L);

								if (elements > 2)
								{
									v128 lo = Sse2.mul_epu32(RCP3, Sse2.shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
									v128 hi = Sse2.mul_epu32(RCP3, Sse2.shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));

									return Sse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
								}
								else
								{
									v128 div = Sse2.mul_epu32(RCP3, Sse2.shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));

									return Sse2.shuffle_epi32(div, Sse.SHUFFLE(3, 1, 3, 1));
								}
                            }
							else
							{
								v128 RCP3 = Sse2.set1_epi64x(2_863_311_531L);

								if (elements > 2)
								{
									v128 lo = Sse2.mul_epu32(RCP3, Sse2.shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
									v128 hi = Sse2.mul_epu32(RCP3, Sse2.shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));
									lo = Sse2.srli_epi32(lo, 1);
									hi = Sse2.srli_epi32(hi, 1);

									return Sse.shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
								}
								else
								{
									v128 div = Sse2.mul_epu32(RCP3, Sse2.shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
									div = Sse2.srli_epi32(div, 1);

									return Sse2.shuffle_epi32(div, Sse.SHUFFLE(3, 1, 3, 1));
								}
							}
						}

						default: break;
					}
                }

				return new v128((uint)(vector.UInt0 / divisor), (uint)(vector.UInt1 / divisor), (uint)(vector.UInt2 / divisor), (uint)(vector.UInt3 / divisor));
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_div_epu32(v256 vector, uint divisor, bool __unsafe = false)
			{
                if (Avx2.IsAvx2Supported)
                {
					switch (divisor)
					{
						case 3:
						{
                            if (__unsafe || ALL_LE_EPU32(vector, 0x7FFF_FFFFu))
                            {
								v256 RCP3 = Avx.mm256_set1_epi64x(1_431_655_766L);

								v256 lo = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
								v256 hi = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));

								return Avx.mm256_shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
                            }
							else
							{
								v256 RCP3 = Avx.mm256_set1_epi64x(2_863_311_531L);
								
								v256 lo = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
								v256 hi = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));
								lo = Avx2.mm256_srli_epi32(lo, 1);
								hi = Avx2.mm256_srli_epi32(hi, 1);

								return Avx.mm256_shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
							}
						}

						default: break;
					}
                }

				return new v256((uint)(vector.UInt0 / divisor), (uint)(vector.UInt1 / divisor), (uint)(vector.UInt2 / divisor), (uint)(vector.UInt3 / divisor), (uint)(vector.UInt4 / divisor), (uint)(vector.UInt5 / divisor), (uint)(vector.UInt6 / divisor), (uint)(vector.UInt7 / divisor));
			}
		}
	}
}
