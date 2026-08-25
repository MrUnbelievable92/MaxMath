using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
	unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epu8(v128 a, v128 b, byte elements = 16, bool noOverflow = false)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 2:
						{
							Divider<byte2> __b = new Divider<byte2>(b);
							return sub_epi8((byte2)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						case 3:
						{
							Divider<byte3> __b = new Divider<byte3>(b);
							return sub_epi8((byte3)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						case 4:
						{
							Divider<byte4> __b = new Divider<byte4>(b);
							return sub_epi8((byte4)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						case 8:
						{
							Divider<byte8> __b = new Divider<byte8>(b);
							return sub_epi8((byte8)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						default:
						{
							Divider<byte16> __b = new Divider<byte16>(b);
							return sub_epi8((byte16)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
					}
				}
				else
				{
					if (noOverflow)
					{
						if (constexpr.IS_CONST(a)
						 && constexpr.ALL_NEQ_EPI8(a, 0, elements))
						{
							return div_epu8(add_epi8(dec_epi8(a), b), b, elements);
						}
						else
						{
							return div_epu8(add_epi8(a, dec_epi8(b)), b, elements);
						}
					}
					else
					{
						v128 q = divrem_epu8(a, b, out v128 r, elements);
						return sub_epi8(q, andnot_si128(cmpeq_epi8(r, setzero_si128()), setall_si128()));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epu16(v128 a, v128 b, byte elements = 8)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 2:
						{
							Divider<ushort2> __b = new Divider<ushort2>(b);
							return sub_epi16((ushort2)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						case 3:
						{
							Divider<ushort3> __b = new Divider<ushort3>(b);
							return sub_epi16((ushort3)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						case 4:
						{
							Divider<ushort4> __b = new Divider<ushort4>(b);
							return sub_epi16((ushort4)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						default:
						{
							Divider<ushort8> __b = new Divider<ushort8>(b);
							return sub_epi16((ushort8)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
					}
				}
				else
				{
					if (constexpr.IS_CONST(a)
					 && constexpr.ALL_NEQ_EPI16(a, 0, elements))
					{
						return divsum_epu16(dec_epi16(a), b, b, /*noOverflow:*/ saturated: true, elements);
					}
					else
					{
						return divsum_epu16(a, dec_epi16(b), b, /*noOverflow:*/ saturated: true, elements);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epu32(v128 a, v128 b, byte elements = 4)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 2:
						{
							Divider<uint2> __b = new Divider<uint2>(b);
							return sub_epi32((uint2)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						case 3:
						{
							Divider<uint3> __b = new Divider<uint3>(b);
							return sub_epi32((uint3)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
						default:
						{
							Divider<uint4> __b = new Divider<uint4>(b);
							return sub_epi32((uint4)a / __b, andnot_si128(__b.EvenlyDivides(a), setall_si128()));
						}
					}
				}
				else
				{
					if (constexpr.IS_CONST(a)
					 && constexpr.ALL_NEQ_EPI32(a, 0, elements))
					{
						return divsum_epu32(dec_epi32(a), b, b, elements);
					}
					else
					{
						return divsum_epu32(a, dec_epi32(b), b, elements);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epu64(v128 a, v128 b)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return new v128(math.ceildiv(a.ULong0, b.ULong0), math.ceildiv(a.ULong1, b.ULong1));
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epu8(v256 a, v256 b, bool noOverflow = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<byte32> __b = new Divider<byte32>(b);
					return Avx2.mm256_sub_epi8((byte32)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_setall_si256()));
				}
				else
				{
					if (noOverflow)
					{
						if (constexpr.IS_CONST(a)
						 && constexpr.ALL_NEQ_EPI8(a, 0))
						{
							return mm256_div_epu8(Avx2.mm256_add_epi8(mm256_dec_epi8(a), b), b);
						}
						else
						{
							return mm256_div_epu8(Avx2.mm256_add_epi8(a, mm256_dec_epi8(b)), b);
						}
					}
					else
					{
						v256 q = mm256_divrem_epu8(a, b, out v256 r);
						return Avx2.mm256_sub_epi8(q, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(r, Avx.mm256_setzero_si256()), mm256_setall_si256()));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epu16(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<ushort16> __b = new Divider<ushort16>(b);
					return Avx2.mm256_sub_epi16((ushort16)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_setall_si256()));
				}
				else
				{
					if (constexpr.IS_CONST(a)
					 && constexpr.ALL_NEQ_EPI16(a, 0))
					{
						return mm256_divsum_epu16(mm256_dec_epi16(a), b, b, /*noOverflow:*/ saturated: true);
					}
					else
					{
						return mm256_divsum_epu16(a, mm256_dec_epi16(b), b, /*noOverflow:*/ saturated: true);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epu32(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<uint8> __b = new Divider<uint8>(b);
					return Avx2.mm256_sub_epi32((uint8)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_setall_si256()));
				}
				else
				{
					if (constexpr.IS_CONST(a)
					 && constexpr.ALL_NEQ_EPI32(a, 0))
					{
						return mm256_divsum_epu32(mm256_dec_epi32(a), b, b);
					}
					else
					{
						return mm256_divsum_epu32(a, mm256_dec_epi32(b), b);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epu64(v256 a, v256 b, byte elements = 4, bool bLEu32max = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 3:
						{
							Divider<ulong3> __b = new Divider<ulong3>(b);
							return Avx2.mm256_sub_epi64((ulong3)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_setall_si256()));
						}
						default:
						{
							Divider<ulong4> __b = new Divider<ulong4>(b);
							return Avx2.mm256_sub_epi64((ulong4)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_setall_si256()));
						}
					}
				}
				else
				{
					v256 q = mm256_divrem_epu64(a, b, out v256 r, elements: elements, bLEu32max: bLEu32max);
					return Avx2.mm256_sub_epi64(q, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(r, Avx.mm256_setzero_si256()), mm256_setall_si256()));
				}
			}
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epi8(v128 a, v128 b, byte elements = 16, bool noOverflow = false)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 2:
						{
							Divider<sbyte2> __b = new Divider<sbyte2>(b);
							return sub_epi8((sbyte2)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						case 3:
						{
							Divider<sbyte3> __b = new Divider<sbyte3>(b);
							return sub_epi8((sbyte3)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						case 4:
						{
							Divider<sbyte4> __b = new Divider<sbyte4>(b);
							return sub_epi8((sbyte4)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						case 8:
						{
							Divider<sbyte8> __b = new Divider<sbyte8>(b);
							return sub_epi8((sbyte8)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						default:
						{
							Divider<sbyte16> __b = new Divider<sbyte16>(b);
							return sub_epi8((sbyte16)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
					}
				}
				else
				{
					if (noOverflow)
					{
						v128 adjust = movsign_epi8(set1_epi8(1), b, nonZeroS: true, elements: elements);
						adjust = sub_epi8(b, adjust);
						adjust = blendv_epi8(adjust, setzero_si128(), xor_si128(a, b));

						return div_epi8(add_epi8(a, adjust), b, elements: elements);
					}
					else
					{
						v128 q = divrem_epi8(a, b, out v128 r, elements);
						return sub_epi8(q, nor_si128(cmpeq_epi8(r, setzero_si128()), srai_epi8(xor_si128(a, b), 7)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epi16(v128 a, v128 b, byte elements = 8)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 2:
						{
							Divider<short2> __b = new Divider<short2>(b);
							return sub_epi16((short2)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
						case 3:
						{
							Divider<short3> __b = new Divider<short3>(b);
							return sub_epi16((short3)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
						case 4:
						{
							Divider<short4> __b = new Divider<short4>(b);
							return sub_epi16((short4)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
						default:
						{
							Divider<short8> __b = new Divider<short8>(b);
							return sub_epi16((short8)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
					}
				}
				else
				{
					v128 adjust = movsign_epi16(set1_epi16(1), b, nonZeroS: true, elements: elements);
					adjust = sub_epi16(b, adjust);
					adjust = andnot_si128(srai_epi16(xor_si128(a, b), 15), adjust);

					return divsum_epi16(a, adjust, b, elements: elements);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epi32(v128 a, v128 b, byte elements = 4, bool noOverflow = false)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 2:
						{
							Divider<int2> __b = new Divider<int2>(b);
							return sub_epi32((int2)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi32(xor_si128(a, b), 31)));
						}
						case 3:
						{
							Divider<int3> __b = new Divider<int3>(b);
							return sub_epi32((int3)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi32(xor_si128(a, b), 31)));
						}
						default:
						{
							Divider<int4> __b = new Divider<int4>(b);
							return sub_epi32((int4)a / __b, nor_si128(__b.EvenlyDivides(a), srai_epi32(xor_si128(a, b), 31)));
						}
					}
				}
				else
				{
					if (noOverflow)
					{
						v128 adjust = movsign_epi32(set1_epi32(1), b, nonZeroS: true, elements: elements);
						adjust = sub_epi32(b, adjust);
						adjust = blendv_ps(adjust, setzero_si128(), xor_si128(a, b));

						return div_epi32(add_epi32(a, adjust), b, elements: elements);
					}
					else
					{
						v128 q = divrem_epi32(a, b, out v128 r, elements);
						return sub_epi32(q, nor_si128(cmpeq_epi32(r, setzero_si128()), srai_epi32(xor_si128(a, b), 31)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 ceildiv_epi64(v128 a, v128 b)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return new v128(math.ceildiv(a.SLong0, b.SLong0), math.ceildiv(a.SLong1, b.SLong1));
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epi8(v256 a, v256 b, bool noOverflow = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<sbyte32> __b = new Divider<sbyte32>(b);
					return Avx2.mm256_sub_epi8((sbyte32)a / __b, mm256_nor_si256(__b.EvenlyDivides(a), mm256_srai_epi8(Avx2.mm256_xor_si256(a, b), 7)));
				}
				else
				{
					if (noOverflow)
					{
						v256 adjust = mm256_movsign_epi8(mm256_set1_epi8(1), b, nonZeroS: true);
						adjust = Avx2.mm256_sub_epi8(b, adjust);
						adjust = Avx2.mm256_blendv_epi8(adjust, Avx.mm256_setzero_si256(), Avx2.mm256_xor_si256(a, b));

						return mm256_div_epi8(Avx2.mm256_add_epi8(a, adjust), b);
					}
					else
					{
						v256 q = mm256_divrem_epi8(a, b, out v256 r);
						return Avx2.mm256_sub_epi8(q, mm256_nor_si256(Avx2.mm256_cmpeq_epi8(r, Avx.mm256_setzero_si256()), mm256_srai_epi8(Avx2.mm256_xor_si256(a, b), 7)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epi16(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<short16> __b = new Divider<short16>(b);
					return Avx2.mm256_sub_epi16((short16)a / __b, mm256_nor_si256(__b.EvenlyDivides(a), mm256_srai_epi16(Avx2.mm256_xor_si256(a, b), 15)));
				}
				else
				{
					v256 adjust = mm256_movsign_epi16(mm256_set1_epi16(1), b, nonZeroS: true);
					adjust = Avx2.mm256_sub_epi16(b, adjust);
					adjust = Avx2.mm256_andnot_si256(mm256_srai_epi16(Avx2.mm256_xor_si256(a, b), 15), adjust);

					return mm256_divsum_epi16(a, adjust, b);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epi32(v256 a, v256 b, bool noOverflow = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<int8> __b = new Divider<int8>(b);
					return Avx2.mm256_sub_epi32((int8)a / __b, mm256_nor_si256(__b.EvenlyDivides(a), mm256_srai_epi32(Avx2.mm256_xor_si256(a, b), 31)));
				}
				else
				{
					if (noOverflow)
					{
						v256 adjust = mm256_movsign_epi32(mm256_set1_epi32(1), b, nonZeroS: true);
						adjust = Avx2.mm256_sub_epi32(b, adjust);
						adjust = Avx.mm256_blendv_ps(adjust, Avx.mm256_setzero_si256(), Avx2.mm256_xor_si256(a, b));

						return mm256_div_epi32(Avx2.mm256_add_epi32(a, adjust), b);
					}
					else
					{
						v256 q = mm256_divrem_epi32(a, b, out v256 r);
						return Avx2.mm256_sub_epi32(q, mm256_nor_si256(Avx2.mm256_cmpeq_epi32(r, Avx.mm256_setzero_si256()), mm256_srai_epi32(Avx2.mm256_xor_si256(a, b), 31)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_ceildiv_epi64(v256 a, v256 b, byte elements = 4, bool bLEu32max = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					switch (elements)
					{
						case 3:
						{
							Divider<long3> __b = new Divider<long3>(b);
							return Avx2.mm256_sub_epi64((long3)a / __b, mm256_nor_si256(__b.EvenlyDivides(a), mm256_srai_epi64(Avx2.mm256_xor_si256(a, b), 63)));
						}
						default:
						{
							Divider<long4> __b = new Divider<long4>(b);
							return Avx2.mm256_sub_epi64((long4)a / __b, mm256_nor_si256(__b.EvenlyDivides(a), mm256_srai_epi64(Avx2.mm256_xor_si256(a, b), 63)));
						}
					}
				}
				else
				{
					v256 q = mm256_divrem_epi64(a, b, out v256 r, elements: elements, bLEu32max: bLEu32max);
					return Avx2.mm256_sub_epi64(q, mm256_nor_si256(Avx2.mm256_cmpeq_epi64(r, Avx.mm256_setzero_si256()), mm256_srai_epi64(Avx2.mm256_xor_si256(a, b), 63)));
				}
			}
			else throw new IllegalInstructionException();
		}
	}
}

namespace MaxMath
{
	unsafe public static partial class math
	{
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte ceildiv(byte x, byte y)
		{
			if (constexpr.IS_CONST(y)
			 || constexpr.IS_CONST(x))
			{
				return (byte)(((uint)x + y - 1) / y);
			}
			else
			{
				// cmp r, 1;
				// sbb q, 0
				return (byte)((x / y) + tobyte(!isdivisible(x, y)));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort ceildiv(ushort x, ushort y)
		{
			if (constexpr.IS_CONST(y)
			 || constexpr.IS_CONST(x))
			{
				return (ushort)(((uint)x + y - 1) / y);
			}
			else
			{
				// cmp r, 1;
				// sbb q, 0
				return (ushort)((x / y) + tobyte(!isdivisible(x, y)));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint ceildiv(uint x, uint y)
		{
			if (constexpr.IS_CONST(y))
			// 64 bit div is slower by ~5 cycles, only for constant y
			{
				return (uint)(((ulong)x + y - 1) / y);
			}
			else
			{
				// cmp r, 1;
				// sbb q, 0
				return (x / y) + tobyte(!isdivisible(x, y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong ceildiv(ulong x, ulong y)
		{
			// cmp r, 1;
			// sbb q, 0
			return (x / y) + tobyte(!isdivisible(x, y));
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> + <paramref name="y"/> <see langword="-"/> 1 that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt128 ceildiv(UInt128 x, UInt128 y, Promise promises = Promise.Nothing)
		{
			if (constexpr.IS_CONST(y))
			{
				return (x / y) + tobyte(!isdivisible(x, y));
			}
			else
			{
				if (promises.Promises(Promise.NoOverflow))
				{
					if (constexpr.IS_CONST(x)
					 && constexpr.IS_TRUE(x != 0))
					{
						return ((x - 1) + y) / y;
					}
					else
					{
						return (x + (y - 1)) / y;
					}
				}
				else
				{
					return divrem(x, y, out UInt128 r) + tobyte(r != 0);
				}
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte ceildiv(sbyte x, sbyte y)
		{
			return (sbyte)((x / y) - (isdivisible(x, y) ? 0 : ~(x ^ y) >> 7));
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short ceildiv(short x, short y)
		{
			return (short)((x / y) - (isdivisible(x, y) ? 0 : ~(x ^ y) >> 15));
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int ceildiv(int x, int y)
		{
			return (x / y) - (isdivisible(x, y) ? 0 : ~(x ^ y) >> 31);
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long ceildiv(long x, long y)
		{
			return (x / y) - (isdivisible(x, y) ? 0 : ~(x ^ y) >> 63);
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 ceildiv(Int128 x, Int128 y, Promise promises = Promise.NoOverflow)
		{
			if (constexpr.IS_CONST(y))
			{
				return (x / y) - (isdivisible(x, y) ? 0 : ~(x ^ y) >> 127);
			}
			else
			{
				if (promises.Promises(Promise.NoOverflow))
				{
					Int128 adj = (x ^ y) < 0 ? 0 : (y - sign(y));

					return (x + adj) / y;
				}
				else
				{
					return divrem(x, y, out Int128 r) - (r != 0 ? ~(x ^ y) >> 127 : 0);
				}
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> + <paramref name="y"/> <see langword="-"/> 1 that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 ceildiv(byte2 x, byte2 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu8(x, y, 2, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new byte2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> + <paramref name="y"/> <see langword="-"/> 1 that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 ceildiv(byte3 x, byte3 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu8(x, y, 3, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new byte3(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> + <paramref name="y"/> <see langword="-"/> 1 that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 ceildiv(byte4 x, byte4 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu8(x, y, 4, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new byte4(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z), ceildiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> + <paramref name="y"/> <see langword="-"/> 1 that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 ceildiv(byte8 x, byte8 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu8(x, y, 8, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new byte8(ceildiv(x.x0, y.x0), ceildiv(x.x1, y.x1), ceildiv(x.x2, y.x2), ceildiv(x.x3, y.x3), ceildiv(x.x4, y.x4), ceildiv(x.x5, y.x5), ceildiv(x.x6, y.x6), ceildiv(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> + <paramref name="y"/> <see langword="-"/> 1 that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 ceildiv(byte16 x, byte16 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu8(x, y, 16, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new byte16(ceildiv(x.x0, y.x0), ceildiv(x.x1, y.x1), ceildiv(x.x2, y.x2), ceildiv(x.x3, y.x3), ceildiv(x.x4, y.x4), ceildiv(x.x5, y.x5), ceildiv(x.x6, y.x6), ceildiv(x.x7, y.x7), ceildiv(x.x8, y.x8), ceildiv(x.x9, y.x9), ceildiv(x.x10, y.x10), ceildiv(x.x11, y.x11), ceildiv(x.x12, y.x12), ceildiv(x.x13, y.x13), ceildiv(x.x14, y.x14), ceildiv(x.x15, y.x15));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> + <paramref name="y"/> <see langword="-"/> 1 that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 ceildiv(byte32 x, byte32 y, Promise promises = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epu8(x, y, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new byte32(ceildiv(x.v16_0, y.v16_0, promises), ceildiv(x.v16_16, y.v16_16, promises));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 ceildiv(ushort2 x, ushort2 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu16(x, y, 2);
			}
			else
			{
				return new ushort2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 ceildiv(ushort3 x, ushort3 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu16(x, y, 3);
			}
			else
			{
				return new ushort3(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 ceildiv(ushort4 x, ushort4 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu16(x, y, 4);
			}
			else
			{
				return new ushort4(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z), ceildiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 ceildiv(ushort8 x, ushort8 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu16(x, y);
			}
			else
			{
				return new ushort8(ceildiv(x.x0, y.x0), ceildiv(x.x1, y.x1), ceildiv(x.x2, y.x2), ceildiv(x.x3, y.x3), ceildiv(x.x4, y.x4), ceildiv(x.x5, y.x5), ceildiv(x.x6, y.x6), ceildiv(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 ceildiv(ushort16 x, ushort16 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epu16(x, y);
			}
			else
			{
				return new ushort16(ceildiv(x.v8_0, y.v8_0), ceildiv(x.v8_8, y.v8_8));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 ceildiv(uint2 x, uint2 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu32(x, y, 2);
			}
			else
			{
				return new uint2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 ceildiv(uint3 x, uint3 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu32(x, y, 3);
			}
			else
			{
				return new uint3(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 ceildiv(uint4 x, uint4 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu32(x, y, 4);
			}
			else
			{
				return new uint4(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z), ceildiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 ceildiv(uint8 x, uint8 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epu32(x, y);
			}
			else
			{
				return new uint8(ceildiv(x.v4_0, y.v4_0), ceildiv(x.v4_4, y.v4_4));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 ceildiv(ulong2 x, ulong2 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epu64(x, y);
			}
			else
			{
				return new ulong2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 ceildiv(ulong3 x, ulong3 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epu64(x, y, 3);
			}
			else
			{
				return new ulong3(ceildiv(x.xy, y.xy), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 ceildiv(ulong4 x, ulong4 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epu64(x, y, 4);
			}
			else
			{
				return new ulong4(ceildiv(x.xy, y.xy), ceildiv(x.zw, y.zw));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 ceildiv(sbyte2 x, sbyte2 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi8(x, y, 2, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 ceildiv(sbyte3 x, sbyte3 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi8(x, y, 3, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte3(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 ceildiv(sbyte4 x, sbyte4 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi8(x, y, 4, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte4(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z), ceildiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 ceildiv(sbyte8 x, sbyte8 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi8(x, y, 8, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte8(ceildiv(x.x0, y.x0), ceildiv(x.x1, y.x1), ceildiv(x.x2, y.x2), ceildiv(x.x3, y.x3), ceildiv(x.x4, y.x4), ceildiv(x.x5, y.x5), ceildiv(x.x6, y.x6), ceildiv(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 ceildiv(sbyte16 x, sbyte16 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi8(x, y, 16, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte16(ceildiv(x.x0, y.x0), ceildiv(x.x1, y.x1), ceildiv(x.x2, y.x2), ceildiv(x.x3, y.x3), ceildiv(x.x4, y.x4), ceildiv(x.x5, y.x5), ceildiv(x.x6, y.x6), ceildiv(x.x7, y.x7), ceildiv(x.x8, y.x8), ceildiv(x.x9, y.x9), ceildiv(x.x10, y.x10), ceildiv(x.x11, y.x11), ceildiv(x.x12, y.x12), ceildiv(x.x13, y.x13), ceildiv(x.x14, y.x14), ceildiv(x.x15, y.x15));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 ceildiv(sbyte32 x, sbyte32 y, Promise promises = Promise.NoOverflow)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epi8(x, y, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte32(ceildiv(x.v16_0, y.v16_0, promises), ceildiv(x.v16_16, y.v16_16, promises));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 ceildiv(short2 x, short2 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi16(x, y, 2);
			}
			else
			{
				return new short2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 ceildiv(short3 x, short3 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi16(x, y, 3);
			}
			else
			{
				return new short3(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 ceildiv(short4 x, short4 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi16(x, y, 4);
			}
			else
			{
				return new short4(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z), ceildiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 ceildiv(short8 x, short8 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi16(x, y, 8);
			}
			else
			{
				return new short8(ceildiv(x.x0, y.x0), ceildiv(x.x1, y.x1), ceildiv(x.x2, y.x2), ceildiv(x.x3, y.x3), ceildiv(x.x4, y.x4), ceildiv(x.x5, y.x5), ceildiv(x.x6, y.x6), ceildiv(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 ceildiv(short16 x, short16 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epi16(x, y);
			}
			else
			{
				return new short16(ceildiv(x.v8_0, y.v8_0), ceildiv(x.v8_8, y.v8_8));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 ceildiv(int2 x, int2 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi32(x, y, 2, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 ceildiv(int3 x, int3 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi32(x, y, 3, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int3(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 ceildiv(int4 x, int4 y, Promise promises = Promise.NoOverflow)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi32(x, y, 4, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int4(ceildiv(x.x, y.x), ceildiv(x.y, y.y), ceildiv(x.z, y.z), ceildiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="+"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="0"/> <see langword=":"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 ceildiv(int8 x, int8 y, Promise promises = Promise.NoOverflow)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epi32(x, y, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int8(ceildiv(x.v4_0, y.v4_0, promises), ceildiv(x.v4_4, y.v4_4, promises));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 ceildiv(long2 x, long2 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.ceildiv_epi64(x, y);
			}
			else
			{
				return new long2(ceildiv(x.x, y.x), ceildiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 ceildiv(long3 x, long3 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epi64(x, y, 3);
			}
			else
			{
				return new long3(ceildiv(x.xy, y.xy), ceildiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards positive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 ceildiv(long4 x, long4 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_ceildiv_epi64(x, y, 4);
			}
			else
			{
				return new long4(ceildiv(x.xy, y.xy), ceildiv(x.zw, y.zw));
			}
		}
	}
}
