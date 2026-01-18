using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static long movemask_epi8x4(v128 a)
		{
			if (Arm.Neon.IsNeonSupported)
			{
				return Arm.Neon.vget_lane_s64(Arm.Neon.vshrn_n_u16(a, 4), 0);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int truemsk32<T>(int elements)
			where T : unmanaged
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return (int)truemsk64<T>(elements);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static long truemsk64<T>(int elements)
			where T : unmanaged
		{
			if (Sse2.IsSse2Supported)
			{
				return maxmath.bitmask64(sizeof(T) * elements);
			}
			else if (Arm.Neon.IsNeonSupported)
			{
				return maxmath.bitmask64(4 * sizeof(T) * elements);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static v128 truemsk128<T>(int elements)
			where T : unmanaged
		{
			if (Sse2.IsSse2Supported)
			{
				return (UInt128.MaxValue >> (128 - (8 * sizeof(T) * elements))).Reinterpret<UInt128, v128>();
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static v256 truemsk256<T>(int elements)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				return (__UInt256__.MaxValue >> (256 - (8 * sizeof(T) * elements))).Reinterpret<__UInt256__, v256>();
			}
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool alltrue_epi128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 == byte.MaxValue;
					case 2: return a.UShort0 == ushort.MaxValue;
					case 4: return a.UInt0	 == uint.MaxValue;
					case 8: return a.ULong0	 == ulong.MaxValue;

					case 3: return (a.UInt0  &		     0x00FF_FFFFu ) == 	         0x00FF_FFFFu ;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) == 0x0000_00FF_FFFF_FFFFul;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) == 0x0000_FFFF_FFFF_FFFFul;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) == 0x00FF_FFFF_FFFF_FFFFul;

					default:
					{
						if (Sse2.IsSse2Supported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8(a) == truemsk32<T>(elements)
								 : (movemask_epi8(a) & truemsk32<T>(elements)) == truemsk32<T>(elements);
						}
						else if (Arm.Neon.IsNeonSupported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8x4(a) == truemsk64<T>(elements)
								 : (movemask_epi8x4(a) & truemsk64<T>(elements)) == truemsk64<T>(elements);
						}
						else throw new IllegalInstructionException();
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_alltrue_epi256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return alltrue_epi128<T>(Avx.mm256_castsi256_si128(a), elements);
				}
				else
				{
					if (Avx2.IsAvx2Supported)
					{
						return sizeof(T) * elements == sizeof(v256)
							 ? Avx2.mm256_movemask_epi8(a) == truemsk32<T>(elements)
							 : (Avx2.mm256_movemask_epi8(a) & truemsk32<T>(elements)) == truemsk32<T>(elements);
					}
					else
					{
						return mm256_alltrue_f256<T>(a, elements);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool alltrue_f128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
			if (Sse2.IsSse2Supported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				if (Sse2.IsSse2Supported)
				{
					if (elements * sizeof(T) <= sizeof(ulong)
					 || sizeof(T) < sizeof(float))
					{
						return alltrue_epi128<T>(a, elements);
					}
					else
					{
						int cmp = sizeof(T) == sizeof(float) ? movemask_ps(a) : movemask_pd(a);

						return sizeof(T) * elements == sizeof(v128)
							 ? cmp == truemsk32<byte>(elements)
							 : (cmp & truemsk32<byte>(elements)) == truemsk32<byte>(elements);
					}
				}
				else
				{
					int cmp = Sse.movemask_ps(a);

					return sizeof(T) * elements == sizeof(v128)
						 ? cmp == (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements))
						 : (cmp & (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements))) == (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements));
				}
            }
			else if (Arm.Neon.IsNeonSupported)
			{
				return alltrue_epi128<T>(a, elements);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_alltrue_f256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return alltrue_f128<T>(Avx.mm256_castps256_ps128(a), elements);
				}
				else if (sizeof(T) < sizeof(float))
				{
					if (Avx2.IsAvx2Supported)
					{
						return mm256_alltrue_epi256<T>(a, elements);
					}
					else
					{
						return Avx.mm256_testc_si256(a, truemsk256<T>(elements)) == 1;
					}
				}
				else
				{
					int cmp = sizeof(T) == sizeof(float) ? Avx.mm256_movemask_ps(a) : Avx.mm256_movemask_pd(a);

					return sizeof(T) * elements == sizeof(v256)
						 ? cmp == truemsk32<byte>(elements)
						 : (cmp & truemsk32<byte>(elements)) == truemsk32<byte>(elements);
				}
			}
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notalltrue_epi128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 != byte.MaxValue;
					case 2: return a.UShort0 != ushort.MaxValue;
					case 4: return a.UInt0	 != uint.MaxValue;
					case 8: return a.ULong0	 != ulong.MaxValue;

					case 3: return (a.UInt0  &		     0x00FF_FFFFu ) != 	         0x00FF_FFFFu ;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) != 0x0000_00FF_FFFF_FFFFul;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) != 0x0000_FFFF_FFFF_FFFFul;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) != 0x00FF_FFFF_FFFF_FFFFul;

					default:
					{
						if (Sse2.IsSse2Supported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8(a) != truemsk32<T>(elements)
								 : (movemask_epi8(a) & truemsk32<T>(elements)) != truemsk32<T>(elements);
						}
						else if (Arm.Neon.IsNeonSupported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8x4(a) != truemsk64<T>(elements)
								 : (movemask_epi8x4(a) & truemsk64<T>(elements)) != truemsk64<T>(elements);
						}
						else throw new IllegalInstructionException();
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notalltrue_epi256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return notalltrue_epi128<T>(Avx.mm256_castsi256_si128(a), elements);
				}
				else
				{
					if (Avx2.IsAvx2Supported)
					{
						return sizeof(T) * elements == sizeof(v256)
							 ? Avx2.mm256_movemask_epi8(a) != truemsk32<T>(elements)
							 : (Avx2.mm256_movemask_epi8(a) & truemsk32<T>(elements)) != truemsk32<T>(elements);
					}
					else
					{
						return mm256_notalltrue_f256<T>(a, elements);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notalltrue_f128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
			if (Sse2.IsSse2Supported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				if (Sse2.IsSse2Supported)
				{
					if (elements * sizeof(T) <= sizeof(ulong)
					 || sizeof(T) < sizeof(float))
					{
						return notalltrue_epi128<T>(a, elements);
					}
					else
					{
						int cmp = sizeof(T) == sizeof(float) ? movemask_ps(a) : movemask_pd(a);

						return sizeof(T) * elements == sizeof(v128)
							 ? cmp != truemsk32<byte>(elements)
							 : (cmp & truemsk32<byte>(elements)) != truemsk32<byte>(elements);
					}
				}
				else
				{
					int cmp = Sse.movemask_ps(a);

					return sizeof(T) * elements == sizeof(v128)
						 ? cmp != (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements))
						 : (cmp & (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements))) != (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements));
				}
            }
			else if (Arm.Neon.IsNeonSupported)
			{
				return notalltrue_epi128<T>(a, elements);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notalltrue_f256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return notalltrue_f128<T>(Avx.mm256_castps256_ps128(a), elements);
				}
				else if (sizeof(T) < sizeof(float))
				{
					if (Avx2.IsAvx2Supported)
					{
						return mm256_notalltrue_epi256<T>(a, elements);
					}
					else
					{
						return Avx.mm256_testc_si256(a, truemsk256<T>(elements)) == 0;
					}
				}
				else
				{
					int cmp = sizeof(T) != sizeof(float) ? Avx.mm256_movemask_ps(a) : Avx.mm256_movemask_pd(a);

					return sizeof(T) * elements == sizeof(v256)
						 ? cmp != truemsk32<byte>(elements)
						 : (cmp & truemsk32<byte>(elements)) != truemsk32<byte>(elements);
				}
			}
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool allfalse_epi128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 == 0;
					case 2: return a.UShort0 == 0;
					case 4: return a.UInt0	 == 0;
					case 8: return a.ULong0	 == 0;

					case 3: return (a.UInt0  &		     0x00FF_FFFFu ) == 0ul;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) == 0ul;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) == 0ul;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) == 0ul;

					default:
					{
						if (Sse2.IsSse2Supported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8(a) == 0
								 : (movemask_epi8(a) & truemsk32<T>(elements)) == 0;
						}
						else if (Arm.Neon.IsNeonSupported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8x4(a) == 0
								 : (movemask_epi8x4(a) & truemsk64<T>(elements)) == 0;
						}
						else throw new IllegalInstructionException();
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_allfalse_epi256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return allfalse_epi128<T>(Avx.mm256_castsi256_si128(a), elements);
				}
				else
				{
					if (Avx2.IsAvx2Supported)
					{
						return sizeof(T) * elements == sizeof(v256)
							 ? Avx2.mm256_movemask_epi8(a) == 0
							 : (Avx2.mm256_movemask_epi8(a) & truemsk32<T>(elements)) == 0;
					}
					else
					{
						return mm256_allfalse_f256<T>(a, elements);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool allfalse_f128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
			if (Sse2.IsSse2Supported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				if (Sse2.IsSse2Supported)
				{
					if (elements * sizeof(T) <= sizeof(ulong)
					 || sizeof(T) < sizeof(float))
					{
						return allfalse_epi128<T>(a, elements);
					}
					else
					{
						int cmp = sizeof(T) == sizeof(float) ? movemask_ps(a) : movemask_pd(a);

						return sizeof(T) * elements == sizeof(v128)
							 ? cmp == 0
							 : (cmp & truemsk32<byte>(elements)) == 0;
					}
				}
				else
				{
					int cmp = Sse.movemask_ps(a);

					return sizeof(T) * elements == sizeof(v128)
						 ? cmp == 0
						 : (cmp & (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements))) == 0;
				}
            }
			else if (Arm.Neon.IsNeonSupported)
			{
				return allfalse_epi128<T>(a, elements);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_allfalse_f256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return allfalse_f128<T>(Avx.mm256_castps256_ps128(a), elements);
				}
				else if (sizeof(T) < sizeof(float))
				{
					if (Avx2.IsAvx2Supported)
					{
						return mm256_allfalse_epi256<T>(a, elements);
					}
					else
					{
						return Avx.mm256_testz_si256(a, elements * sizeof(T) == sizeof(v256) ? a : truemsk256<T>(elements)) == 1;
					}
				}
				else
				{
					int cmp = sizeof(T) == sizeof(float) ? Avx.mm256_movemask_ps(a) : Avx.mm256_movemask_pd(a);

					return sizeof(T) * elements == sizeof(v256)
						 ? cmp == 0
						 : (cmp & truemsk32<byte>(elements)) == 0;
				}
			}
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notallfalse_epi128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
            if (BurstArchitecture.IsSIMDSupported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 != 0;
					case 2: return a.UShort0 != 0;
					case 4: return a.UInt0	 != 0;
					case 8: return a.ULong0	 != 0;

					case 3: return (a.UInt0  &		     0x00FF_FFFFu ) != 0ul;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) != 0ul;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) != 0ul;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) != 0ul;

					default:
					{
						if (Sse2.IsSse2Supported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8(a) != 0
								 : (movemask_epi8(a) & truemsk32<T>(elements)) != 0;
						}
						else if (Arm.Neon.IsNeonSupported)
						{
							return sizeof(T) * elements == sizeof(v128)
								 ? movemask_epi8x4(a) != 0
								 : (movemask_epi8x4(a) & truemsk64<T>(elements)) != 0;
						}
						else throw new IllegalInstructionException();
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notallfalse_epi256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return notallfalse_epi128<T>(Avx.mm256_castsi256_si128(a), elements);
				}
				else
				{
					if (Avx2.IsAvx2Supported)
					{
						return sizeof(T) * elements == sizeof(v256)
							 ? Avx2.mm256_movemask_epi8(a) != 0
							 : (Avx2.mm256_movemask_epi8(a) & truemsk32<T>(elements)) != 0;
					}
					else
					{
						return mm256_notallfalse_f256<T>(a, elements);
					}
				}
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notallfalse_f128<T>(v128 a, int elements = 0)
			where T : unmanaged
		{
			if (Sse2.IsSse2Supported)
            {
				elements = elements != 0 ? elements : sizeof(v128) / sizeof(T);

				if (Sse2.IsSse2Supported)
				{
					if (elements * sizeof(T) <= sizeof(ulong)
					 || sizeof(T) < sizeof(float))
					{
						return notallfalse_epi128<T>(a, elements);
					}
					else
					{
						int cmp = sizeof(T) == sizeof(float) ? movemask_ps(a) : movemask_pd(a);

						return sizeof(T) * elements == sizeof(v128)
							 ? cmp != 0
							 : (cmp & truemsk32<byte>(elements)) != 0;
					}
				}
				else
				{
					int cmp = Sse.movemask_ps(a);

					return sizeof(T) * elements == sizeof(v128)
						 ? cmp != 0
						 : (cmp & (sizeof(T) == sizeof(float) ? truemsk32<byte>(elements) : truemsk32<short>(elements))) != 0;
				}
            }
			else if (Arm.Neon.IsNeonSupported)
			{
				return notallfalse_epi128<T>(a, elements);
			}
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notallfalse_f256<T>(v256 a, int elements = 0)
			where T : unmanaged
		{
			if (Avx.IsAvxSupported)
			{
				elements = elements != 0 ? elements : sizeof(v256) / sizeof(T);

				if (sizeof(T) * elements <= sizeof(v128))
				{
					return notallfalse_f128<T>(Avx.mm256_castps256_ps128(a), elements);
				}
				else if (sizeof(T) < sizeof(float))
				{
					if (Avx2.IsAvx2Supported)
					{
						return mm256_notallfalse_epi256<T>(a, elements);
					}
					else
					{
						return Avx.mm256_testz_si256(a, elements * sizeof(T) == sizeof(v256) ? a : truemsk256<T>(elements)) == 1;
					}
				}
				else
				{
					int cmp = sizeof(T) == sizeof(float) ? Avx.mm256_movemask_ps(a) : Avx.mm256_movemask_pd(a);

					return sizeof(T) * elements == sizeof(v256)
						 ? cmp != 0
						 : (cmp & truemsk32<byte>(elements)) != 0;
				}
			}
			else throw new IllegalInstructionException();
		}
    }
}
