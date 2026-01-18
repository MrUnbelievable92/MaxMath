using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 constdiv_epu8(v128 vector, byte divisor, byte elements = 16, bool __unsafe = false)
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				__unsafe |= constexpr.ALL_LT_EPU8(vector, 1 << 7, elements);

				if (divisor == 128)
				{
					return srli_epi8(vector, 7);
				}
				else if (divisor > 127)
				{
					v128 cmp;

					if (divisor == byte.MaxValue)
					{
						cmp = cmpeq_epi8(vector, set1_epi8(byte.MaxValue));
					}
					else
					{
						cmp = cmpge_epu8(vector, set1_epi8(divisor));
					}

					return neg_epi8(cmp);
				}
				else if (divisor > 84)
				{
					v128 cmp1 = cmpge_epu8(vector, set1_epi8(divisor));
					v128 cmp2 = cmpge_epu8(vector, set1_epi8((byte)(2 * divisor)));

					cmp1 = neg_epi8(cmp1);

                    if (divisor == 85)
                    {
						v128 cmp3 = cmpeq_epi8(vector, set1_epi8(byte.MaxValue));
						cmp2 = add_epi8(cmp2, cmp3);
                    }

					return sub_epi8(cmp1, cmp2);
				}
				else
				{
					switch (divisor)
					{
						case 1:  return vector;
						case 2:  return srli_epi8(vector, 1);
						case 4:	 return srli_epi8(vector, 2);
						case 8:	 return srli_epi8(vector, 3);
						case 16: return srli_epi8(vector, 4);
						case 32: return srli_epi8(vector, 5);
						case 64: return srli_epi8(vector, 6);

						case 3:
						{
							if (__unsafe)
							{
								return mulhi_epu8(vector, set1_epi8(86), elements);
							}
							else goto default;
						}
						case 6:
						{
							if (__unsafe)
							{
								return mulhi_epu8(vector, set1_epi8(43), elements);
							}
							else goto default;
						}

						default:
						{
							switch (elements)
							{
								case  2: return (byte2) vector / new Divider<byte>(divisor);
								case  3: return (byte3) vector / new Divider<byte>(divisor);
								case  4: return (byte4) vector / new Divider<byte>(divisor);
								case  8: return (byte8) vector / new Divider<byte>(divisor);
								default: return (byte16)vector / new Divider<byte>(divisor);
							}
						}
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epu8(v256 vector, byte divisor, bool __unsafe = false)
		{
            if (Avx2.IsAvx2Supported)
            {
				__unsafe |= constexpr.ALL_LT_EPU8(vector, 1 << 7);

				if (divisor == 128)
				{
					return mm256_srli_epi8(vector, 7);
				}
				else if (divisor > 127)
				{
					if (divisor == byte.MaxValue)
					{
						return mm256_abs_epi8(Avx2.mm256_cmpeq_epi8(vector, mm256_set1_epi8(byte.MaxValue)));
					}
					else
					{
						return mm256_abs_epi8(mm256_cmpge_epu8(vector, mm256_set1_epi8(divisor)));
					}
				}
				else if (divisor > 84)
				{
					v256 cmp1 = mm256_cmpge_epu8(vector, mm256_set1_epi8(divisor));
					v256 cmp2 = mm256_cmpge_epu8(vector, mm256_set1_epi8((byte)(2 * divisor)));

					cmp1 = mm256_abs_epi8(cmp1);

                    if (divisor == 85)
                    {
						v256 cmp3 = Avx2.mm256_cmpeq_epi8(vector, mm256_set1_epi8(byte.MaxValue));
						cmp2 = Avx2.mm256_add_epi8(cmp2, cmp3);
                    }

					return Avx2.mm256_sub_epi8(cmp1, cmp2);
				}
				else
				{
					switch (divisor)
					{
						case 1:  return vector;
						case 2:  return mm256_srli_epi8(vector, 1);
						case 4:	 return mm256_srli_epi8(vector, 2);
						case 8:	 return mm256_srli_epi8(vector, 3);
						case 16: return mm256_srli_epi8(vector, 4);
						case 32: return mm256_srli_epi8(vector, 5);
						case 64: return mm256_srli_epi8(vector, 6);

						case 3:
						{
							if (__unsafe)
							{
								return mm256_mulhi_epu8(vector, mm256_set1_epi8(86));
							}
							else goto default;
						}
						case 6:
						{
							if (__unsafe)
							{
								return mm256_mulhi_epu8(vector, mm256_set1_epi8(43));
							}
							else goto default;
						}

						default:
						{
							return (byte32)vector / new Divider<byte>(divisor);
						}
					}
				}
            }
			else throw new IllegalInstructionException();
		}
	}
}
