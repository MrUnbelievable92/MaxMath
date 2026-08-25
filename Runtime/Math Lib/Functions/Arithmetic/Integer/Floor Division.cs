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
		public static v128 floordiv_epi8(v128 a, v128 b, byte elements = 16, bool noOverflow = false)
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
							return add_epi8((sbyte2)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						case 3:
						{
							Divider<sbyte3> __b = new Divider<sbyte3>(b);
							return add_epi8((sbyte3)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						case 4:
						{
							Divider<sbyte4> __b = new Divider<sbyte4>(b);
							return add_epi8((sbyte4)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						case 8:
						{
							Divider<sbyte8> __b = new Divider<sbyte8>(b);
							return add_epi8((sbyte8)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
						default:
						{
							Divider<sbyte16> __b = new Divider<sbyte16>(b);
							return add_epi8((sbyte16)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi8(xor_si128(a, b), 7)));
						}
					}
				}
				else
				{
					if (noOverflow)
					{
						v128 adjust = movsign_epi8(set1_epi8(1), b, nonZeroS: true, elements: elements);
						adjust = sub_epi8(b, adjust);
						adjust = blendv_epi8(setzero_si128(), adjust, xor_si128(a, b));

						return div_epi8(sub_epi8(a, adjust), b, elements: elements);
					}
					else
					{
						v128 q = divrem_epi8(a, b, out v128 r, elements);
						return add_epi8(q, andnot_si128(cmpeq_epi8(r, setzero_si128()), srai_epi8(xor_si128(a, b), 7)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 floordiv_epi16(v128 a, v128 b, byte elements = 8)
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
							return add_epi16((short2)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
						case 3:
						{
							Divider<short3> __b = new Divider<short3>(b);
							return add_epi16((short3)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
						case 4:
						{
							Divider<short4> __b = new Divider<short4>(b);
							return add_epi16((short4)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
						default:
						{
							Divider<short8> __b = new Divider<short8>(b);
							return add_epi16((short8)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi16(xor_si128(a, b), 15)));
						}
					}
				}
				else
				{
					v128 adjust = movsign_epi16(set1_epi16(1), b, nonZeroS: true, elements: elements);
					adjust = sub_epi16(b, adjust);
					adjust = and_si128(srai_epi16(xor_si128(a, b), 15), adjust);

					return divdiff_epi16(a, adjust, b, elements: elements);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 floordiv_epi32(v128 a, v128 b, byte elements = 4, bool noOverflow = false)
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
							return add_epi32((int2)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi32(xor_si128(a, b), 31)));
						}
						case 3:
						{
							Divider<int3> __b = new Divider<int3>(b);
							return add_epi32((int3)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi32(xor_si128(a, b), 31)));
						}
						default:
						{
							Divider<int4> __b = new Divider<int4>(b);
							return add_epi32((int4)a / __b, andnot_si128(__b.EvenlyDivides(a), srai_epi32(xor_si128(a, b), 31)));
						}
					}
				}
				else
				{
					if (noOverflow)
					{
						v128 adjust = movsign_epi32(set1_epi32(1), b, nonZeroS: true, elements: elements);
						adjust = sub_epi32(b, adjust);
						adjust = blendv_ps(setzero_si128(), adjust, xor_si128(a, b));

						return div_epi32(sub_epi32(a, adjust), b, elements: elements);
					}
					else
					{
						v128 q = divrem_epi32(a, b, out v128 r, elements);
						return add_epi32(q, andnot_si128(cmpeq_epi32(r, setzero_si128()), srai_epi32(xor_si128(a, b), 31)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 floordiv_epi64(v128 a, v128 b)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return new v128(math.floordiv(a.SLong0, b.SLong0), math.floordiv(a.SLong1, b.SLong1));
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_floordiv_epi8(v256 a, v256 b, bool noOverflow = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<sbyte32> __b = new Divider<sbyte32>(b);
					return Avx2.mm256_add_epi8((sbyte32)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_srai_epi8(Avx2.mm256_xor_si256(a, b), 7)));
				}
				else
				{
					if (noOverflow)
					{
						v256 adjust = mm256_movsign_epi8(mm256_set1_epi8(1), b, nonZeroS: true);
						adjust = Avx2.mm256_sub_epi8(b, adjust);
						adjust = Avx2.mm256_blendv_epi8(Avx.mm256_setzero_si256(), adjust, Avx2.mm256_xor_si256(a, b));

						return mm256_div_epi8(Avx2.mm256_sub_epi8(a, adjust), b);
					}
					else
					{
						v256 q = mm256_divrem_epi8(a, b, out v256 r);
						return Avx2.mm256_add_epi8(q, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(r, Avx.mm256_setzero_si256()), mm256_srai_epi8(Avx2.mm256_xor_si256(a, b), 7)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_floordiv_epi16(v256 a, v256 b)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<short16> __b = new Divider<short16>(b);
					return Avx2.mm256_add_epi16((short16)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_srai_epi16(Avx2.mm256_xor_si256(a, b), 15)));
				}
				else
				{
					v256 adjust = mm256_movsign_epi16(mm256_set1_epi16(1), b, nonZeroS: true);
					adjust = Avx2.mm256_sub_epi16(b, adjust);
					adjust = Avx2.mm256_and_si256(mm256_srai_epi16(Avx2.mm256_xor_si256(a, b), 15), adjust);

					return mm256_divdiff_epi16(a, adjust, b);
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_floordiv_epi32(v256 a, v256 b, bool noOverflow = false)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(b))
				{
					Divider<int8> __b = new Divider<int8>(b);
					return Avx2.mm256_add_epi32((int8)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_srai_epi32(Avx2.mm256_xor_si256(a, b), 31)));
				}
				else
				{
					if (noOverflow)
					{
						v256 adjust = mm256_movsign_epi32(mm256_set1_epi32(1), b, nonZeroS: true);
						adjust = Avx2.mm256_sub_epi32(b, adjust);
						adjust = Avx.mm256_blendv_ps(Avx.mm256_setzero_si256(), adjust, Avx2.mm256_xor_si256(a, b));

						return mm256_div_epi32(Avx2.mm256_sub_epi32(a, adjust), b);
					}
					else
					{
						v256 q = mm256_divrem_epi32(a, b, out v256 r);
						return Avx2.mm256_add_epi32(q, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(r, Avx.mm256_setzero_si256()), mm256_srai_epi32(Avx2.mm256_xor_si256(a, b), 31)));
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v256 mm256_floordiv_epi64(v256 a, v256 b, byte elements = 4, bool bLEu32max = false)
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
							return Avx2.mm256_add_epi64((long3)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_srai_epi64(Avx2.mm256_xor_si256(a, b), 63)));
						}
						default:
						{
							Divider<long4> __b = new Divider<long4>(b);
							return Avx2.mm256_add_epi64((long4)a / __b, Avx2.mm256_andnot_si256(__b.EvenlyDivides(a), mm256_srai_epi64(Avx2.mm256_xor_si256(a, b), 63)));
						}
					}
				}
				else
				{
					v256 q = mm256_divrem_epi64(a, b, out v256 r, elements: elements, bLEu32max: bLEu32max);
					return Avx2.mm256_add_epi64(q, Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(r, Avx.mm256_setzero_si256()), mm256_srai_epi64(Avx2.mm256_xor_si256(a, b), 63)));
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
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte floordiv(byte x, byte y)
		{
			return (byte)(x / y);
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort floordiv(ushort x, ushort y)
		{
			return (ushort)(x / y);
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint floordiv(uint x, uint y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong floordiv(ulong x, ulong y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static UInt128 floordiv(UInt128 x, UInt128 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte floordiv(sbyte x, sbyte y)
		{
			return (sbyte)((x / y) + (isdivisible(x, y) ? 0 : (x ^ y) >> 7));
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short floordiv(short x, short y)
		{
			return (short)((x / y) + (isdivisible(x, y) ? 0 : (x ^ y) >> 15));
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int floordiv(int x, int y)
		{
			return (x / y) + (isdivisible(x, y) ? 0 : (x ^ y) >> 31);
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long floordiv(long x, long y)
		{
			return (x / y) + (isdivisible(x, y) ? 0 : (x ^ y) >> 63);
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negaive infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 floordiv(Int128 x, Int128 y, Promise promises = Promise.Nothing)
		{
			if (constexpr.IS_CONST(y))
			{
				return (x / y) + (isdivisible(x, y) ? 0 : (x ^ y) >> 127);
			}
			else
			{
				if (promises.Promises(Promise.NoOverflow))
				{
					Int128 adj = (x ^ y) < 0 ? (y - sign(y)) : 0;

					return (x - adj) / y;
				}
				else
				{
					return divrem(x, y, out Int128 r) + (r != 0 ? (x ^ y) >> 127 : 0);
				}
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte2 floordiv(byte2 x, byte2 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte3 floordiv(byte3 x, byte3 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte4 floordiv(byte4 x, byte4 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte8 floordiv(byte8 x, byte8 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte16 floordiv(byte16 x, byte16 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte32 floordiv(byte32 x, byte32 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort2 floordiv(ushort2 x, ushort2 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort3 floordiv(ushort3 x, ushort3 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort4 floordiv(ushort4 x, ushort4 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort8 floordiv(ushort8 x, ushort8 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ushort16 floordiv(ushort16 x, ushort16 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint2 floordiv(uint2 x, uint2 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint3 floordiv(uint3 x, uint3 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint4 floordiv(uint4 x, uint4 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static uint8 floordiv(uint8 x, uint8 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 floordiv(ulong2 x, ulong2 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong3 floordiv(ulong3 x, ulong3 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 floordiv(ulong4 x, ulong4 y)
		{
			return x / y;
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte2 floordiv(sbyte2 x, sbyte2 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi8(x, y, 2, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte2(floordiv(x.x, y.x), floordiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte3 floordiv(sbyte3 x, sbyte3 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi8(x, y, 3, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte3(floordiv(x.x, y.x), floordiv(x.y, y.y), floordiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte4 floordiv(sbyte4 x, sbyte4 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi8(x, y, 4, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte4(floordiv(x.x, y.x), floordiv(x.y, y.y), floordiv(x.z, y.z), floordiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte8 floordiv(sbyte8 x, sbyte8 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi8(x, y, 8, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte8(floordiv(x.x0, y.x0), floordiv(x.x1, y.x1), floordiv(x.x2, y.x2), floordiv(x.x3, y.x3), floordiv(x.x4, y.x4), floordiv(x.x5, y.x5), floordiv(x.x6, y.x6), floordiv(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte16 floordiv(sbyte16 x, sbyte16 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi8(x, y, 16, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte16(floordiv(x.x0, y.x0), floordiv(x.x1, y.x1), floordiv(x.x2, y.x2), floordiv(x.x3, y.x3), floordiv(x.x4, y.x4), floordiv(x.x5, y.x5), floordiv(x.x6, y.x6), floordiv(x.x7, y.x7), floordiv(x.x8, y.x8), floordiv(x.x9, y.x9), floordiv(x.x10, y.x10), floordiv(x.x11, y.x11), floordiv(x.x12, y.x12), floordiv(x.x13, y.x13), floordiv(x.x14, y.x14), floordiv(x.x15, y.x15));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static sbyte32 floordiv(sbyte32 x, sbyte32 y, Promise promises = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_floordiv_epi8(x, y, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new sbyte32(floordiv(x.v16_0, y.v16_0, promises), floordiv(x.v16_16, y.v16_16, promises));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short2 floordiv(short2 x, short2 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi16(x, y, 2);
			}
			else
			{
				return new short2(floordiv(x.x, y.x), floordiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short3 floordiv(short3 x, short3 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi16(x, y, 3);
			}
			else
			{
				return new short3(floordiv(x.x, y.x), floordiv(x.y, y.y), floordiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short4 floordiv(short4 x, short4 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi16(x, y, 4);
			}
			else
			{
				return new short4(floordiv(x.x, y.x), floordiv(x.y, y.y), floordiv(x.z, y.z), floordiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short8 floordiv(short8 x, short8 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi16(x, y, 8);
			}
			else
			{
				return new short8(floordiv(x.x0, y.x0), floordiv(x.x1, y.x1), floordiv(x.x2, y.x2), floordiv(x.x3, y.x3), floordiv(x.x4, y.x4), floordiv(x.x5, y.x5), floordiv(x.x6, y.x6), floordiv(x.x7, y.x7));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static short16 floordiv(short16 x, short16 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_floordiv_epi16(x, y);
			}
			else
			{
				return new short16(floordiv(x.v8_0, y.v8_0), floordiv(x.v8_8, y.v8_8));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int2 floordiv(int2 x, int2 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi32(x, y, 2, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int2(floordiv(x.x, y.x), floordiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int3 floordiv(int3 x, int3 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi32(x, y, 3, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int3(floordiv(x.x, y.x), floordiv(x.y, y.y), floordiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int4 floordiv(int4 x, int4 y, Promise promises = Promise.Nothing)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi32(x, y, 4, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int4(floordiv(x.x, y.x), floordiv(x.y, y.y), floordiv(x.z, y.z), floordiv(x.w, y.w));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> returns undefined results for any <paramref name="x"/> <see langword="-"/> <see langword="("/><see langword="("/><paramref name="x"/> <see langword="^"/> <paramref name="y"/><see langword=")"/> <see langword="&lt;"/> <see langword="0"/> <see langword="?"/> <see langword="("/><paramref name="y"/> <see langword="-"/> sign<see langword="("/><paramref name="y"/><see langword=")"/><see langword=")"/> <see langword=":"/> <see langword="0"/> that overflows.       </para>
        /// </remarks>
        /// </summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int8 floordiv(int8 x, int8 y, Promise promises = Promise.Nothing)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_floordiv_epi32(x, y, promises.Promises(Promise.NoOverflow));
			}
			else
			{
				return new int8(floordiv(x.v4_0, y.v4_0, promises), floordiv(x.v4_4, y.v4_4, promises));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long2 floordiv(long2 x, long2 y)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.floordiv_epi64(x, y);
			}
			else
			{
				return new long2(floordiv(x.x, y.x), floordiv(x.y, y.y));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 floordiv(long3 x, long3 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_floordiv_epi64(x, y, 3);
			}
			else
			{
				return new long3(floordiv(x.xy, y.xy), floordiv(x.z, y.z));
			}
		}
		
		/// <summary>		Returns <paramref name="x"/> divided by <paramref name="y"/> with rounding towards negative infinity.		</summary>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 floordiv(long4 x, long4 y)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_floordiv_epi64(x, y, 4);
			}
			else
			{
				return new long4(floordiv(x.xy, y.xy), floordiv(x.zw, y.zw));
			}
		}
	}
}
