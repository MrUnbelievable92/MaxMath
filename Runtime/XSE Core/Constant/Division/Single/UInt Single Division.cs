using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constdiv_epu32(v128 vector, uint divisor, byte elements = 4, bool __unsafe = false)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				__unsafe |= constexpr.ALL_LE_EPU32(vector, 0x7FFF_FFFFu, elements);

				switch (divisor)
				{
					case 3:
					{
                        if (__unsafe)
                        {
							v128 RCP3 = set1_epi64x(1_431_655_766L);

							if (elements > 2)
							{
								v128 lo = mul_epu32(RCP3, shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
								v128 hi = mul_epu32(RCP3, shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));

								return shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
							}
							else
							{
								v128 div = mul_epu32(RCP3, shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));

								return shuffle_epi32(div, Sse.SHUFFLE(3, 1, 3, 1));
							}
                        }
						else
						{
							v128 RCP3 = set1_epi64x(2_863_311_531L);

							if (elements > 2)
							{
								v128 lo = mul_epu32(RCP3, shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
								v128 hi = mul_epu32(RCP3, shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));
								lo = srli_epi32(lo, 1);
								hi = srli_epi32(hi, 1);

								return shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
							}
							else
							{
								v128 div = mul_epu32(RCP3, shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
								div = srli_epi32(div, 1);

								return shuffle_epi32(div, Sse.SHUFFLE(3, 1, 3, 1));
							}
						}
					}
					case 6:
					{
                        if (__unsafe)
                        {
							v128 RCP6 = set1_epi64x(715_827_883L);

							if (elements > 2)
							{
								v128 lo = mul_epu32(RCP6, shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
								v128 hi = mul_epu32(RCP6, shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));

								return shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
							}
							else
							{
								v128 div = mul_epu32(RCP6, shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));

								return shuffle_epi32(div, Sse.SHUFFLE(3, 1, 3, 1));
							}
                        }
						else goto default;
					}

					default:
					{
						switch (elements)
						{
							case 2:  return RegisterConversion.ToV128(RegisterConversion.ToUInt2(vector) / new Divider<uint>(divisor));
							case 3:  return RegisterConversion.ToV128(RegisterConversion.ToUInt3(vector) / new Divider<uint>(divisor));
							default: return RegisterConversion.ToV128(RegisterConversion.ToUInt4(vector) / new Divider<uint>(divisor));
						}
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epu32(v256 vector, uint divisor, bool __unsafe = false)
		{
            if (Avx2.IsAvx2Supported)
            {
				__unsafe |= constexpr.ALL_LE_EPU32(vector, 0x7FFF_FFFFu);

				switch (divisor)
				{
					case 3:
					{
                        if (__unsafe)
                        {
							v256 RCP3 = mm256_set1_epi64x(1_431_655_766L);

							v256 lo = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
							v256 hi = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));

							return Avx.mm256_shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
                        }
						else
						{
							v256 RCP3 = mm256_set1_epi64x(2_863_311_531L);

							v256 lo = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
							v256 hi = Avx2.mm256_mul_epu32(RCP3, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));
							lo = Avx2.mm256_srli_epi32(lo, 1);
							hi = Avx2.mm256_srli_epi32(hi, 1);

							return Avx.mm256_shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
						}
					}
					case 6:
					{
                        if (__unsafe)
                        {
							v256 RCP6 = mm256_set1_epi64x(715_827_883L);

							v256 lo = Avx2.mm256_mul_epu32(RCP6, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(1, 1, 0, 0)));
							v256 hi = Avx2.mm256_mul_epu32(RCP6, Avx2.mm256_shuffle_epi32(vector, Sse.SHUFFLE(3, 3, 2, 2)));

							return Avx.mm256_shuffle_ps(lo, hi, Sse.SHUFFLE(3, 1, 3, 1));
                        }
						else goto default;
					}

					default:
					{
						return (uint8)vector / new Divider<uint>(divisor);
					}
				}
            }
			else throw new IllegalInstructionException();
		}
	}
}
