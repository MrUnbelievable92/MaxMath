using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;

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

				v128 result;

				if (divisor == 128)
				{
					result = srli_epi8(vector, 7, elements: elements);
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
						cmp = cmpge_epu8(vector, set1_epi8(divisor), elements: elements);
					}

					result = neg_epi8(cmp);
				}
				else if (divisor > 84)
				{
					v128 cmp1 = cmpge_epu8(vector, set1_epi8(divisor), elements: elements);
					v128 cmp2 = cmpge_epu8(vector, set1_epi8((byte)(2 * divisor)), elements: elements);

					cmp1 = neg_epi8(cmp1);

                    if (divisor == 85)
                    {
						v128 cmp3 = cmpeq_epi8(vector, set1_epi8(byte.MaxValue));
						cmp2 = add_epi8(cmp2, cmp3);
                    }

					result = sub_epi8(cmp1, cmp2);
				}
				else
				{
					switch (divisor)
					{
						case 1:  result = vector;									break;
						case 2:  result = srli_epi8(vector, 1, elements: elements);	break;
						case 4:	 result = srli_epi8(vector, 2, elements: elements);	break;
						case 8:	 result = srli_epi8(vector, 3, elements: elements);	break;
						case 16: result = srli_epi8(vector, 4, elements: elements);	break;
						case 32: result = srli_epi8(vector, 5, elements: elements);	break;
						case 64: result = srli_epi8(vector, 6, elements: elements);	break;

						case 3:
						{
							if (__unsafe)
							{
								result = mulhi_epu8(vector, set1_epi8(86), elements);
								break;
							}
							else goto default;
						}
						case 6:
						{
							if (__unsafe)
							{
								result = mulhi_epu8(vector, set1_epi8(43), elements);
								break;
							}
							else goto default;
						}

						default:
						{
							switch (elements)
							{
								case  2: result = (byte2) vector / new Divider<byte>(divisor); break;
								case  3: result = (byte3) vector / new Divider<byte>(divisor); break;
								case  4: result = (byte4) vector / new Divider<byte>(divisor); break;
								case  8: result = (byte8) vector / new Divider<byte>(divisor); break;
								default: result = (byte16)vector / new Divider<byte>(divisor); break;
							}

							break;
						}
					}
				}

				constexpr.ASSUME_DIVISION_EPU8(result, vector, set1_epi8(divisor), elements);
				
				return result;
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_constdiv_epu8(v256 vector, byte divisor, bool __unsafe = false)
		{
            if (Avx2.IsAvx2Supported)
            {
				__unsafe |= constexpr.ALL_LT_EPU8(vector, 1 << 7);

				v256 result;

				if (divisor == 128)
				{
					result = mm256_srli_epi8(vector, 7);
				}
				else if (divisor > 127)
				{
					if (divisor == byte.MaxValue)
					{
						result = mm256_abs_epi8(Avx2.mm256_cmpeq_epi8(vector, mm256_set1_epi8(byte.MaxValue)));
					}
					else
					{
						result = mm256_abs_epi8(mm256_cmpge_epu8(vector, mm256_set1_epi8(divisor)));
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

					result = Avx2.mm256_sub_epi8(cmp1, cmp2);
				}
				else
				{
					switch (divisor)
					{
						case 1:  result = vector;					  break;
						case 2:  result = mm256_srli_epi8(vector, 1); break;
						case 4:	 result = mm256_srli_epi8(vector, 2); break;
						case 8:	 result = mm256_srli_epi8(vector, 3); break;
						case 16: result = mm256_srli_epi8(vector, 4); break;
						case 32: result = mm256_srli_epi8(vector, 5); break;
						case 64: result = mm256_srli_epi8(vector, 6); break;

						case 3:
						{
							if (__unsafe)
							{
								result = mm256_mulhi_epu8(vector, mm256_set1_epi8(86));
								break;
							}
							else goto default;
						}
						case 6:
						{
							if (__unsafe)
							{
								result = mm256_mulhi_epu8(vector, mm256_set1_epi8(43));
								break;
							}
							else goto default;
						}

						default:
						{
							result = (byte32)vector / new Divider<byte>(divisor);
							break;
						}
					}
				}

				constexpr.ASSUME_DIVISION_EPU8(result, vector, mm256_set1_epi8(divisor));

				return result;
            }
			else throw new IllegalInstructionException();
		}
	}
}
