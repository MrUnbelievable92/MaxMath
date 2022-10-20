using System;
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
			internal static v128 div_epu8_TAKE_AND_RET_EPU16(v128 vector, byte divisor)
			{
                if (Sse2.IsSse2Supported)
                {
					switch (divisor)
					{
						case 3:   return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(21846));
						case 5:   return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(13108));
						case 6:   return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(10923));
						case 7:   return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(9363));
						case 9:   return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(7282));
						case 10:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(6554));
						case 11:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(5958));
						case 12:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(5462));
						case 13:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(5042));
						case 14:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(4682));
						case 15:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(4370));
						case 17:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(3856));
						case 18:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(3641));
						case 19:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(3450));
						case 20:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(3277));
						case 21:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(3121));
						case 22:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2979));
						case 23:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2850));
						case 24:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2731));
						case 25:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2622));
						case 26:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2521));
						case 27:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2428));
						case 28:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2341));
						case 29:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2260));
						case 30:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2185));
						case 31:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(2115));
						case 33:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1986));
						case 34:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1928));
						case 35:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1873));
						case 36:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1821));
						case 37:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1772));
						case 38:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1725));
						case 39:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1681));
						case 40:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1639));
						case 41:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1599));
						case 42:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1561));
						case 43:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1525));
						case 44:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1490));
						case 45:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1457));
						case 46:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1425));
						case 47:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1395));
						case 48:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1366));
						case 49:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1338));
						case 50:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1311));
						case 51:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1286));
						case 52:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1261));
						case 53:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1237));
						case 54:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1214));
						case 55:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1192));
						case 56:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1171));
						case 57:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1150));
						case 58:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1130));
						case 59:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1111));
						case 60:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1093));
						case 61:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1075));
						case 62:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1058));
						case 63:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1041));
						case 65:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(1009));
						case 66:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(993));
						case 67:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(979));
						case 68:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(964));
						case 69:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(950));
						case 70:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(937));
						case 71:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(924));
						case 72:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(911));
						case 73:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(898));
						case 74:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(886));
						case 75:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(874));
						case 76:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(863));
						case 77:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(852));
						case 78:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(841));
						case 79:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(830));
						case 80:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(820));
						case 81:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(810));
						case 82:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(800));
						case 83:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(790));
						case 84:  return Sse2.mulhi_epi16(vector, Sse2.set1_epi16(781));

					    default: throw new Exception(nameof(vector) + "/" + divisor.ToString() + " is calculated quicker with" + nameof(constexpr) + "." + nameof(div_epu8));
					}
                }
				else throw new IllegalInstructionException();
            }
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static v256 mm256_div_epu8_TAKE_AND_RET_EPU16(v256 vector, byte divisor)
			{
                if (Avx2.IsAvx2Supported)
                {
					switch (divisor)
					{
						case 3:   return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(21846));
						case 5:   return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(13108));
						case 6:   return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(10923));
						case 7:   return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(9363));
						case 9:   return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(7282));
						case 10:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(6554));
						case 11:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(5958));
						case 12:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(5462));
						case 13:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(5042));
						case 14:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(4682));
						case 15:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(4370));
						case 17:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(3856));
						case 18:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(3641));
						case 19:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(3450));
						case 20:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(3277));
						case 21:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(3121));
						case 22:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2979));
						case 23:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2850));
						case 24:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2731));
						case 25:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2622));
						case 26:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2521));
						case 27:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2428));
						case 28:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2341));
						case 29:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2260));
						case 30:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2185));
						case 31:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(2115));
						case 33:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1986));
						case 34:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1928));
						case 35:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1873));
						case 36:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1821));
						case 37:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1772));
						case 38:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1725));
						case 39:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1681));
						case 40:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1639));
						case 41:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1599));
						case 42:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1561));
						case 43:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1525));
						case 44:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1490));
						case 45:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1457));
						case 46:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1425));
						case 47:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1395));
						case 48:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1366));
						case 49:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1338));
						case 50:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1311));
						case 51:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1286));
						case 52:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1261));
						case 53:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1237));
						case 54:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1214));
						case 55:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1192));
						case 56:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1171));
						case 57:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1150));
						case 58:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1130));
						case 59:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1111));
						case 60:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1093));
						case 61:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1075));
						case 62:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1058));
						case 63:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1041));
						case 65:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(1009));
						case 66:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(993));
						case 67:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(979));
						case 68:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(964));
						case 69:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(950));
						case 70:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(937));
						case 71:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(924));
						case 72:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(911));
						case 73:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(898));
						case 74:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(886));
						case 75:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(874));
						case 76:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(863));
						case 77:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(852));
						case 78:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(841));
						case 79:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(830));
						case 80:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(820));
						case 81:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(810));
						case 82:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(800));
						case 83:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(790));
						case 84:  return Avx2.mm256_mulhi_epi16(vector, Avx.mm256_set1_epi16(781));

					    default: throw new Exception(nameof(vector) + "/" + divisor.ToString() + " is calculated quicker with" + nameof(constexpr) + "." + nameof(div_epu8));
					}
                }
				else throw new IllegalInstructionException();
            }

			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v128 div_epu8(v128 vector, byte divisor, byte elements = 16)
			{
                if (Sse2.IsSse2Supported)
                {
					if (divisor == 128)
					{
						return srli_epi8(vector, 7);
					}
					else if (divisor > 127)
					{
						v128 cmp;
						
						if (divisor == byte.MaxValue)
						{
							cmp = Sse2.cmpeq_epi8(vector, Sse2.set1_epi8(unchecked((sbyte)byte.MaxValue)));
						}
						else
						{
							cmp = cmpge_epu8(vector, Sse2.set1_epi8(unchecked((sbyte)divisor)));
						}
						
						return negmask_epi8(cmp);
					}
					else if (divisor > 84)
					{
						v128 cmp1 = cmpge_epu8(vector, Sse2.set1_epi8(unchecked((sbyte)divisor)));
						v128 cmp2 = cmpge_epu8(vector, Sse2.set1_epi8(unchecked((sbyte)(2 * divisor))));
						
						cmp1 = negmask_epi8(cmp1);

                        if (divisor == 85)
                        {
							v128 cmp3 = Sse2.cmpeq_epi8(vector, Sse2.set1_epi8(unchecked((sbyte)byte.MaxValue)));
							cmp2 = Sse2.add_epi8(cmp2, cmp3);
                        }

						return Sse2.sub_epi8(cmp1, cmp2);
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

							default:
							{
								if (elements <= 8)
								{
									v128 t = div_epu8_TAKE_AND_RET_EPU16(cvtepu8_epi16(vector), divisor);

									return Sse2.packus_epi16(t, t);
								}
								else
								{
									v128 tLo = cvt2x2epu8_epi16(vector, out v128 tHi);
									
									return Sse2.packus_epi16(div_epu8_TAKE_AND_RET_EPU16(tLo, divisor), div_epu8_TAKE_AND_RET_EPU16(tHi, divisor));
								}
							}
						}
					}
                }
				else throw new IllegalInstructionException();
			}
			
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static v256 mm256_div_epu8(v256 vector, byte divisor)
			{
                if (Avx2.IsAvx2Supported)
                {
					if (divisor == 128)
					{
						return mm256_srli_epi8(vector, 7);
					}
					else if (divisor > 127)
					{
						if (divisor == byte.MaxValue)
						{
							return Avx2.mm256_abs_epi8(Avx2.mm256_cmpeq_epi8(vector, Avx.mm256_set1_epi8(byte.MaxValue)));
						}
						else
						{
							return Avx2.mm256_abs_epi8(mm256_cmpge_epu8(vector, Avx.mm256_set1_epi8(divisor)));
						}
					}
					else if (divisor > 84)
					{
						v256 cmp1 = mm256_cmpge_epu8(vector, Avx.mm256_set1_epi8(divisor));
						v256 cmp2 = mm256_cmpge_epu8(vector, Avx.mm256_set1_epi8((byte)(2 * divisor)));
						
						cmp1 = Avx2.mm256_abs_epi8(cmp1);

                        if (divisor == 85)
                        {
							v256 cmp3 = Avx2.mm256_cmpeq_epi8(vector, Avx.mm256_set1_epi8(byte.MaxValue));
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

							default:
							{
								v256 tLo = mm256_cvt2x2epu8_epi16(vector, out v256 tHi);
								
								return Avx2.mm256_packus_epi16(mm256_div_epu8_TAKE_AND_RET_EPU16(tLo, divisor), mm256_div_epu8_TAKE_AND_RET_EPU16(tHi, divisor));
							}
						}
					}
                }
				else throw new IllegalInstructionException();
			}
		}
	}
}
