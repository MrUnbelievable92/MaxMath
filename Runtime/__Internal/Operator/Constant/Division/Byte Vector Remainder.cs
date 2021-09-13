//using DevTools;
//using Unity.Burst.Intrinsics;

//using static Unity.Burst.Intrinsics.X86;

//namespace MaxMath
//{
//	unsafe internal static partial class Operator
//	{
//		internal static v128 vrem_sbyte_const(v128 vector, sbyte divisor, int vectorElementCount, out v128 remainders)
//		{return remainders = default; }
//		internal static v256 vrem_sbyte_const(v256 vector, sbyte divisorout, out v256 remainders)
//		{return remainders = default; }

//		internal static v128 vrem_byte_const(v128 vector, byte divisor, int vectorElementCount)
//		{
//Assert.AreNotEqual(0, divisor);

//            if (divisor == 1)
//            {
//				return default(v128);
//            }
//			else if (maxmath.ispow2(divisor))
//			{
//				return vector & (byte16)((byte)(divisor - 1));
//			}
//			else if (vectorElementCount <= 8)
//			{
//				if (Sse2.IsSse2Supported)
//				{
//					v128 REM_MAGIC = Sse2.set1_epi16((short)(ushort.MaxValue / divisor + 1));
//					v128 DIVISOR16 = Sse2.set1_epi16(divisor);

//					v128 cast = Cast.ByteToShort(vector);
//					v128 remainders16 = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast, REM_MAGIC), DIVISOR16);

//					return Sse2.packus_epi16(remainders16, remainders16);
//				}
//				else throw new CPUFeatureCheckException();
//			}
//			else
//			{
//				if (Avx2.IsAvx2Supported)
//				{
//					v256 REM_MAGIC = Avx.mm256_set1_epi16((short)(ushort.MaxValue / divisor + 1));
//					v256 DIVISOR16 = Avx.mm256_set1_epi16(divisor);

//					v256 cast = Avx2.mm256_cvtepu8_epi16(vector);

//					v256 remainders16 = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast, REM_MAGIC), DIVISOR16);

//					return Sse2.packus_epi16(Avx.mm256_castsi256_si128(remainders16), Avx2.mm256_extracti128_si256(remainders16, 1));
//				}
//				else if (Sse2.IsSse2Supported)
//				{
//					v128 REM_MAGIC = new short8(ushort.MaxValue / 130 + 1);
//					v128 DIVISOR16 = new short8(divisor);
//					v128 CVT_MASK = Sse2.setzero_si128();

//					v128 cast_lo = Sse2.unpacklo_epi8(vector, CVT_MASK);
//					v128 cast_hi = Sse2.unpackhi_epi8(vector, CVT_MASK);

//					v128 remainders16_lo = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast_lo, REM_MAGIC), DIVISOR16);
//					v128 remainders16_hi = Sse2.mulhi_epu16(Sse2.mullo_epi16(cast_hi, REM_MAGIC), DIVISOR16);

//					return Sse2.packus_epi16(remainders16_lo, remainders16_hi);
//				}
//				else throw new CPUFeatureCheckException();
//			}
//		}

//		internal static v256 vrem_byte_const(v256 vector, byte divisor)
//		{
//			if (divisor == 1)
//            {
//				remainders = default(v256);
//				return vector;
//            }
//			else if (maxmath.ispow2(divisor))
//			{
//				remainders = vector & (byte32)((byte)(divisor - 1));
//				return Operator.shrl_byte(vector, maxmath.tzcnt(divisor));
//			}
//			else if (Avx2.IsAvx2Supported)
//			{
//				v256 REM_MAGIC = Avx.mm256_set1_epi16((short)(ushort.MaxValue / divisor + 1));
//				v256 DIVISOR16 = Avx.mm256_set1_epi16(divisor);
//				v256 CVT_MASK = Avx.mm256_setzero_si256();

//				v256 cast_lo = Avx2.mm256_unpacklo_epi8(vector, CVT_MASK);
//				v256 cast_hi = Avx2.mm256_unpackhi_epi8(vector, CVT_MASK);

//				v256 remainders16_lo = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast_lo, REM_MAGIC), DIVISOR16);
//				v256 remainders16_hi = Avx2.mm256_mulhi_epu16(Avx2.mm256_mullo_epi16(cast_hi, REM_MAGIC), DIVISOR16);
//				remainders = Avx2.mm256_packus_epi16(remainders16_lo, remainders16_hi);

//				if (divisor >= byte.MaxValue / 2 + 1)
//				{
//					return Constant.vdiv_byte(vector, divisor);
//				}
//				else
//				{
//					v256 quotients16_lo = new v256((byte)((byte)cast_lo.UShort0 / divisor), (byte)((byte)cast_lo.UShort1 / divisor), (byte)((byte)cast_lo.UShort2 / divisor), (byte)((byte)cast_lo.UShort3 / divisor), (byte)((byte)cast_lo.UShort4 / divisor), (byte)((byte)cast_lo.UShort5 / divisor), (byte)((byte)cast_lo.UShort6 / divisor), (byte)((byte)cast_lo.UShort7 / divisor), (byte)((byte)cast_lo.UShort8 / divisor), (byte)((byte)cast_lo.UShort9 / divisor), (byte)((byte)cast_lo.UShort10 / divisor), (byte)((byte)cast_lo.UShort11 / divisor), (byte)((byte)cast_lo.UShort12 / divisor), (byte)((byte)cast_lo.UShort13 / divisor), (byte)((byte)cast_lo.UShort14 / divisor), (byte)((byte)cast_lo.UShort15 / divisor));
//					v256 quotients16_hi = new v256((byte)((byte)cast_hi.UShort0 / divisor), (byte)((byte)cast_hi.UShort1 / divisor), (byte)((byte)cast_hi.UShort2 / divisor), (byte)((byte)cast_hi.UShort3 / divisor), (byte)((byte)cast_hi.UShort4 / divisor), (byte)((byte)cast_hi.UShort5 / divisor), (byte)((byte)cast_hi.UShort6 / divisor), (byte)((byte)cast_hi.UShort7 / divisor), (byte)((byte)cast_hi.UShort8 / divisor), (byte)((byte)cast_hi.UShort9 / divisor), (byte)((byte)cast_hi.UShort10 / divisor), (byte)((byte)cast_hi.UShort11 / divisor), (byte)((byte)cast_hi.UShort12 / divisor), (byte)((byte)cast_hi.UShort13 / divisor), (byte)((byte)cast_hi.UShort14 / divisor), (byte)((byte)cast_hi.UShort15 / divisor));
					
//					return Avx2.mm256_packus_epi16(quotients16_lo, quotients16_hi);
//				}
//			}
//			else throw new CPUFeatureCheckException();
//		}
//	}
//}