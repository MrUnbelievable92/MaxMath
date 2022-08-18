using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		public static partial class constexpr
		{
			public static v128 mullo_epu8(v128 a, byte b, byte elements = 16)
			{
                if (Sse2.IsSse2Supported)
                {
					switch (b)
					{
						case 0: return Sse2.setzero_si128();
						case 1: return a;
						case 2: return Sse2.add_epi8(a, a);
						
						case 3:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							return Sse2.add_epi8(a, _2);
						}
						case 4:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							return Sse2.add_epi8(_2, _2);
						}
						case 5:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							v128 _4 = Sse2.add_epi8(_2, _2);
							return Sse2.add_epi8(_4, a);
						}
						case 6:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							v128 _4 = Sse2.add_epi8(_2, _2);
							return Sse2.add_epi8(_2, _4);
						}
						case 7:
						{
							v128 _8 = slli_epi8(a, 3);
							return Sse2.sub_epi8(_8, a);
						}
						case 8:
						{
							return slli_epi8(a, 3);
						}
						case 9:
						{
							v128 _8 = slli_epi8(a, 3);
							return Sse2.add_epi8(_8, a);
						}
						case 10:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							v128 _8 = slli_epi8(a, 3);
							return Sse2.add_epi8(_8, _2);
						}
						case 11:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							v128 _3 = Sse2.add_epi8(_2, a);
							v128 _8 = slli_epi8(a, 3);
							return Sse2.add_epi8(_8, _3);
						}
						case 12:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							v128 _4 = Sse2.add_epi8(_2, _2);
							v128 _8 = slli_epi8(a, 3);
							return Sse2.add_epi8(_8, _4);
						}
						case 13:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							v128 _3 = Sse2.add_epi8(_2, a);
							v128 _16 = slli_epi8(a, 4);
							return Sse2.sub_epi8(_16, _3);
						}
						case 14:
						{
							v128 _2 = Sse2.add_epi8(a, a);
							v128 _16 = slli_epi8(a, 4);
							return Sse2.sub_epi8(_16, _2);
						}
						case 15:
						{
							v128 _16 = slli_epi8(a, 4);
							return Sse2.sub_epi8(_16, a);
						}
						case 16:
						{
							return slli_epi8(a, 4);
						}
						case 17:
						{
							v128 _16 = slli_epi8(a, 4);
							return Sse2.add_epi8(_16, a);
						}
						case 18:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _16 = slli_epi8(a, 4);
							return Sse2.add_epi8(_16, _2);
						}
						case 19:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _3 = Sse2.add_epi8(_2, a); 
							v128 _16 = slli_epi8(a, 4);
							return Sse2.add_epi8(_16, _3);
						}
						case 20:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _4 = Sse2.add_epi8(_2, _2); 
							v128 _16 = slli_epi8(a, 4);
							return Sse2.add_epi8(_16, _4);
						}

						
						case 28:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _4 = Sse2.add_epi8(_2, _2); 
							v128 _32 = slli_epi8(a, 5);
							return Sse2.sub_epi8(_32, _4);
						}
						case 29:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _3 = Sse2.add_epi8(_2, a); 
							v128 _32 = slli_epi8(a, 5);
							return Sse2.sub_epi8(_32, _3);
						}
						case 30:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _32 = slli_epi8(a, 5);
							return Sse2.sub_epi8(_32, _2);
						}
						case 31:
						{
							v128 _32 = slli_epi8(a, 5);
							return Sse2.sub_epi8(_32, a);
						}
						case 32:
						{
							return slli_epi8(a, 5);
						}
						case 33:
						{
							v128 _32 = slli_epi8(a, 5);
							return Sse2.add_epi8(_32, a);
						}
						case 34:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _32 = slli_epi8(a, 5);
							return Sse2.add_epi8(_32, _2);
						}
						case 35:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _3 = Sse2.add_epi8(_2, a); 
							v128 _32 = slli_epi8(a, 5);
							return Sse2.add_epi8(_32, _3);
						}
						case 36:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _4 = Sse2.add_epi8(_2, _2); 
							v128 _32 = slli_epi8(a, 5);
							return Sse2.add_epi8(_32, _4);
						}
						

						case 60:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _4 = Sse2.add_epi8(_2, _2); 
							v128 _64 = slli_epi8(a, 6);
							return Sse2.sub_epi8(_64, _4);
						}
						case 61:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _3 = Sse2.add_epi8(_2, a); 
							v128 _64 = slli_epi8(a, 6);
							return Sse2.sub_epi8(_64, _3);
						}
						case 62:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _64 = slli_epi8(a, 6);
							return Sse2.sub_epi8(_64, _2);
						}
						case 63:
						{
							v128 _64 = slli_epi8(a, 6);
							return Sse2.sub_epi8(_64, a);
						}
						case 64:
						{
							return slli_epi8(a, 6);
						}
						case 65:
						{
							v128 _64 = slli_epi8(a, 6);
							return Sse2.add_epi8(_64, a);
						}
						case 66:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _64 = slli_epi8(a, 6);
							return Sse2.add_epi8(_64, _2);
						}
						case 67:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _3 = Sse2.add_epi8(_2, a); 
							v128 _64 = slli_epi8(a, 6);
							return Sse2.add_epi8(_64, _3);
						}
						case 68:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _4 = Sse2.add_epi8(_2, _2); 
							v128 _64 = slli_epi8(a, 6);
							return Sse2.add_epi8(_64, _4);
						}
						

						case 124:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _4 = Sse2.add_epi8(_2, _2); 
							v128 _128 = slli_epi8(a, 7);
							return Sse2.sub_epi8(_128, _4);
						}
						case 125:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _3 = Sse2.add_epi8(_2, a); 
							v128 _128 = slli_epi8(a, 7);
							return Sse2.sub_epi8(_128, _3);
						}
						case 126:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _128 = slli_epi8(a, 7);
							return Sse2.sub_epi8(_128, _2);
						}
						case 127:
						{
							v128 _128 = slli_epi8(a, 7);
							return Sse2.sub_epi8(_128, a);
						}
						case 128:
						{
							return slli_epi8(a, 7);
						}
						case 129:
						{
							v128 _128 = slli_epi8(a, 7);
							return Sse2.add_epi8(_128, a);
						}
						case 130:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _128 = slli_epi8(a, 7);
							return Sse2.add_epi8(_128, _2);
						}
						case 131:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _3 = Sse2.add_epi8(_2, a); 
							v128 _128 = slli_epi8(a, 7);
							return Sse2.add_epi8(_128, _3);
						}
						case 132:
						{
							v128 _2 = Sse2.add_epi8(a, a); 
							v128 _4 = Sse2.add_epi8(_2, _2); 
							v128 _128 = slli_epi8(a, 7);
							return Sse2.add_epi8(_128, _4);
						}

						case 255: return Xse.neg_epi8(a); 

						default:
						{
							v128 MASK = Sse2.set1_epi16(byte.MaxValue);
							v128 B = Sse2.set1_epi16(b);

					        if (elements == 16)
					        {
								v128 lo = cvt2x2epu8_epi16(a, out v128 hi);
								lo = Sse2.and_si128(MASK, Sse2.mullo_epi16(lo, B));
								hi = Sse2.and_si128(MASK, Sse2.mullo_epi16(hi, B));

								return Sse2.packus_epi16(lo, hi);
					        }
							else
							{
								return cvtepi16_epi8(Sse2.and_si128(MASK, Sse2.mullo_epi16(cvtepu8_epi16(a), B)));
							}
						}
					}
				}
				else throw new IllegalInstructionException();
            }

			public static v256 mm256_mullo_epu8(v256 a, byte b)
			{
                if (Avx2.IsAvx2Supported)
                {
					switch (b)
					{
						case 0: return Avx.mm256_setzero_si256();
						case 1: return a;
						case 2: return Avx2.mm256_add_epi8(a, a);
						
						case 3:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							return Avx2.mm256_add_epi8(a, _2);
						}
						case 4:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							return Avx2.mm256_add_epi8(_2, _2);
						}
						case 5:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							v256 _4 = Avx2.mm256_add_epi8(_2, _2);
							return Avx2.mm256_add_epi8(_4, a);
						}
						case 6:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							v256 _4 = Avx2.mm256_add_epi8(_2, _2);
							return Avx2.mm256_add_epi8(_2, _4);
						}
						case 7:
						{
							v256 _8 = mm256_slli_epi8(a, 3);
							return Avx2.mm256_sub_epi8(_8, a);
						}
						case 8:
						{
							return mm256_slli_epi8(a, 3);
						}
						case 9:
						{
							v256 _8 = mm256_slli_epi8(a, 3);
							return Avx2.mm256_add_epi8(_8, a);
						}
						case 10:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							v256 _8 = mm256_slli_epi8(a, 3);
							return Avx2.mm256_add_epi8(_8, _2);
						}
						case 11:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							v256 _3 = Avx2.mm256_add_epi8(_2, a);
							v256 _8 = mm256_slli_epi8(a, 3);
							return Avx2.mm256_add_epi8(_8, _3);
						}
						case 12:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							v256 _4 = Avx2.mm256_add_epi8(_2, _2);
							v256 _8 = mm256_slli_epi8(a, 3);
							return Avx2.mm256_add_epi8(_8, _4);
						}
						case 13:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							v256 _3 = Avx2.mm256_add_epi8(_2, a);
							v256 _16 = mm256_slli_epi8(a, 4);
							return Avx2.mm256_sub_epi8(_16, _3);
						}
						case 14:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a);
							v256 _16 = mm256_slli_epi8(a, 4);
							return Avx2.mm256_sub_epi8(_16, _2);
						}
						case 15:
						{
							v256 _16 = mm256_slli_epi8(a, 4);
							return Avx2.mm256_sub_epi8(_16, a);
						}
						case 16:
						{
							return mm256_slli_epi8(a, 4);
						}
						case 17:
						{
							v256 _16 = mm256_slli_epi8(a, 4);
							return Avx2.mm256_add_epi8(_16, a);
						}
						case 18:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _16 = mm256_slli_epi8(a, 4);
							return Avx2.mm256_add_epi8(_16, _2);
						}
						case 19:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _3 = Avx2.mm256_add_epi8(_2, a); 
							v256 _16 = mm256_slli_epi8(a, 4);
							return Avx2.mm256_add_epi8(_16, _3);
						}
						case 20:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _4 = Avx2.mm256_add_epi8(_2, _2); 
							v256 _16 = mm256_slli_epi8(a, 4);
							return Avx2.mm256_add_epi8(_16, _4);
						}

						
						case 28:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _4 = Avx2.mm256_add_epi8(_2, _2); 
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_sub_epi8(_32, _4);
						}
						case 29:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _3 = Avx2.mm256_add_epi8(_2, a); 
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_sub_epi8(_32, _3);
						}
						case 30:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_sub_epi8(_32, _2);
						}
						case 31:
						{
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_sub_epi8(_32, a);
						}
						case 32:
						{
							return mm256_slli_epi8(a, 5);
						}
						case 33:
						{
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_add_epi8(_32, a);
						}
						case 34:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_add_epi8(_32, _2);
						}
						case 35:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _3 = Avx2.mm256_add_epi8(_2, a); 
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_add_epi8(_32, _3);
						}
						case 36:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _4 = Avx2.mm256_add_epi8(_2, _2); 
							v256 _32 = mm256_slli_epi8(a, 5);
							return Avx2.mm256_add_epi8(_32, _4);
						}
						

						case 60:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _4 = Avx2.mm256_add_epi8(_2, _2); 
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_sub_epi8(_64, _4);
						}
						case 61:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _3 = Avx2.mm256_add_epi8(_2, a); 
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_sub_epi8(_64, _3);
						}
						case 62:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_sub_epi8(_64, _2);
						}
						case 63:
						{
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_sub_epi8(_64, a);
						}
						case 64:
						{
							return mm256_slli_epi8(a, 6);
						}
						case 65:
						{
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_add_epi8(_64, a);
						}
						case 66:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_add_epi8(_64, _2);
						}
						case 67:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _3 = Avx2.mm256_add_epi8(_2, a); 
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_add_epi8(_64, _3);
						}
						case 68:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _4 = Avx2.mm256_add_epi8(_2, _2); 
							v256 _64 = mm256_slli_epi8(a, 6);
							return Avx2.mm256_add_epi8(_64, _4);
						}
						

						case 124:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _4 = Avx2.mm256_add_epi8(_2, _2); 
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_sub_epi8(_128, _4);
						}
						case 125:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _3 = Avx2.mm256_add_epi8(_2, a); 
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_sub_epi8(_128, _3);
						}
						case 126:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_sub_epi8(_128, _2);
						}
						case 127:
						{
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_sub_epi8(_128, a);
						}
						case 128:
						{
							return mm256_slli_epi8(a, 7);
						}
						case 129:
						{
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_add_epi8(_128, a);
						}
						case 130:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_add_epi8(_128, _2);
						}
						case 131:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _3 = Avx2.mm256_add_epi8(_2, a); 
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_add_epi8(_128, _3);
						}
						case 132:
						{
							v256 _2 = Avx2.mm256_add_epi8(a, a); 
							v256 _4 = Avx2.mm256_add_epi8(_2, _2); 
							v256 _128 = mm256_slli_epi8(a, 7);
							return Avx2.mm256_add_epi8(_128, _4);
						}

						case 255: return mm256_neg_epi8(a); 

						default:
						{
							v256 MASK = Avx.mm256_set1_epi16(byte.MaxValue);
							v256 B = Avx.mm256_set1_epi16(b);
							
							v256 lo = mm256_cvt2x2epu8_epi16(a, out v256 hi);
							lo = Avx2.mm256_and_si256(MASK, Avx2.mm256_mullo_epi16(lo, B));
							hi = Avx2.mm256_and_si256(MASK, Avx2.mm256_mullo_epi16(hi, B));

							return Avx2.mm256_packus_epi16(lo, hi);
						}
					}
				}
				else throw new IllegalInstructionException();
			}
		}
	}
}