using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int truemsk<T>(int elements)
			where T : unmanaged 
		{
			return (int)((1L << (sizeof(T) * elements)) - 1);
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool alltrue_epi128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 == byte.MaxValue;
					case 2: return a.UShort0 == ushort.MaxValue;
					case 4: return a.UInt0	 == uint.MaxValue;
					case 8: return a.ULong0	 == ulong.MaxValue;

					case 3: return (a.UInt0  &			 0x00FF_FFFFu)	==			 0x00FF_FFFFu;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) == 0x0000_00FF_FFFF_FFFFul;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) == 0x0000_FFFF_FFFF_FFFFul;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) == 0x00FF_FFFF_FFFF_FFFFul;

					default:
					{
						int allTrue = truemsk<T>(elements);
						int cmp = Sse2.movemask_epi8(a);
						
						if (elements != sizeof(v128) / sizeof(T))
						{
						    cmp &= allTrue;
						}
						
						return allTrue == cmp;
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_alltrue_epi256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx2.IsAvx2Supported)
            {
				int allTrue = truemsk<T>(elements);
				int cmp = Avx2.mm256_movemask_epi8(a);
				
				if (elements != sizeof(v256) / sizeof(T))
				{
				    cmp &= allTrue;
				}
				
				return allTrue == cmp;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool alltrue_f128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
                if (sizeof(T) == 4)
                {
                    switch (elements)
                    {
						case 2: return a.ULong0 == ulong.MaxValue;
						case 3: return (Sse.movemask_ps(a) & 0b0111) == 0b1111;
						default: return Sse.movemask_ps(a) == 0b1111;
                    }
                }
				else
				{
					return Sse2.movemask_pd(a) == 0b0011;
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_alltrue_f256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx.IsAvxSupported)
            {
                if (sizeof(T) == 4)
                {
					return Avx.mm256_movemask_ps(a) == 0b1111_1111;
                    
                }
				else
				{
					int mask = Avx.mm256_movemask_pd(a);

					return (elements == 3) ? ((mask & 0b0111) == 0b0111) : (mask == 0b1111);
				}
            }
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notalltrue_epi128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 != byte.MaxValue;
					case 2: return a.UShort0 != ushort.MaxValue;
					case 4: return a.UInt0	 != uint.MaxValue;
					case 8: return a.ULong0	 != ulong.MaxValue;

					case 3: return (a.UInt0  &			 0x00FF_FFFFu)	!=			 0x00FF_FFFFu;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) != 0x0000_00FF_FFFF_FFFFul;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) != 0x0000_FFFF_FFFF_FFFFul;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) != 0x00FF_FFFF_FFFF_FFFFul;

					default:
					{
						int allTrue = truemsk<T>(elements);
						int cmp = Sse2.movemask_epi8(a);
						
						if (elements != sizeof(v128) / sizeof(T))
						{
						    cmp &= allTrue;
						}
						
						return allTrue != cmp;
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notalltrue_epi256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx2.IsAvx2Supported)
            {
				int allTrue = truemsk<T>(elements);
				int cmp = Avx2.mm256_movemask_epi8(a);
				
				if (elements != sizeof(v256) / sizeof(T))
				{
				    cmp &= allTrue;
				}
				
				return allTrue != cmp;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notalltrue_f128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
                if (sizeof(T) == 4)
                {
                    switch (elements)
                    {
						case 2: return a.ULong0 != ulong.MaxValue;
						case 3: return (Sse.movemask_ps(a) & 0b0111) != 0b1111;
						default: return Sse.movemask_ps(a) != 0b1111;
                    }
                }
				else
				{
					return Sse2.movemask_pd(a) != 0b0011;
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notalltrue_f256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx.IsAvxSupported)
            {
                if (sizeof(T) == 4)
                {
					return Avx.mm256_movemask_ps(a) != 0b1111_1111;
                    
                }
				else
				{
					int mask = Avx.mm256_movemask_pd(a);

					return (elements == 3) ? ((mask & 0b0111) != 0b0111) : (mask != 0b1111);
				}
            }
			else throw new IllegalInstructionException();
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool allfalse_epi128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 == 0;
					case 2: return a.UShort0 == 0;
					case 4: return a.UInt0	 == 0;
					case 8: return a.ULong0	 == 0;

					case 3: return (a.UInt0  &			 0x00FF_FFFFu)	== 0;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) == 0;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) == 0;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) == 0;

					default:
					{
						int cmp = Sse2.movemask_epi8(a);
						
						if (elements != sizeof(v128) / sizeof(T))
						{
						    cmp &= truemsk<T>(elements);
						}
						
						return cmp == 0;
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_allfalse_epi256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx2.IsAvx2Supported)
            {
				int cmp = Avx2.mm256_movemask_epi8(a);
				
				if (elements != sizeof(v256) / sizeof(T))
				{
				    cmp &= truemsk<T>(elements);
				}
				
				return cmp == 0;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool allfalse_f128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
                if (sizeof(T) == 4)
                {
                    switch (elements)
                    {
						case 2: return a.ULong0 == 0;
						case 3: return (Sse.movemask_ps(a) & 0b0111) == 0;
						default: return Sse.movemask_ps(a) == 0;
                    }
                }
				else
				{
					return Sse2.movemask_pd(a) == 0;
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_allfalse_f256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx.IsAvxSupported)
            {
                if (sizeof(T) == 4)
                {
					return Avx.mm256_movemask_ps(a) == 0;
                    
                }
				else
				{
					int mask = Avx.mm256_movemask_pd(a);

					return (elements == 3) ? ((mask & 0b0111) == 0) : (mask == 0);
				}
            }
			else throw new IllegalInstructionException();
		}

		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notallfalse_epi128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
				switch(sizeof(T) * elements)
				{
					case 1: return a.Byte0	 != 0;
					case 2: return a.UShort0 != 0;
					case 4: return a.UInt0	 != 0;
					case 8: return a.ULong0	 != 0;

					case 3: return (a.UInt0  &			 0x00FF_FFFFu)	!= 0;
					case 5: return (a.ULong0 & 0x0000_00FF_FFFF_FFFFul) != 0;
					case 6: return (a.ULong0 & 0x0000_FFFF_FFFF_FFFFul) != 0;
					case 7: return (a.ULong0 & 0x00FF_FFFF_FFFF_FFFFul) != 0;

					default:
					{
						int cmp = Sse2.movemask_epi8(a);
						
						if (elements != sizeof(v128) / sizeof(T))
						{
						    cmp &= truemsk<T>(elements);
						}
						
						return cmp != 0;
					}
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notallfalse_epi256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx2.IsAvx2Supported)
            {
				int cmp = Avx2.mm256_movemask_epi8(a);
				
				if (elements != sizeof(v256) / sizeof(T))
				{
				    cmp &= truemsk<T>(elements);
				}
				
				return cmp != 0;
            }
			else throw new IllegalInstructionException();
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool notallfalse_f128<T>(v128 a, int elements)
			where T : unmanaged 
		{
            if (Sse2.IsSse2Supported)
            {
                if (sizeof(T) == 4)
                {
                    switch (elements)
                    {
						case 2: return a.ULong0 != 0;
						case 3: return (Sse.movemask_ps(a) & 0b0111) != 0;
						default: return Sse.movemask_ps(a) != 0;
                    }
                }
				else
				{
					return Sse2.movemask_pd(a) != 0;
				}
            }
			else throw new IllegalInstructionException();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool mm256_notallfalse_f256<T>(v256 a, int elements)
			where T : unmanaged 
		{
            if (Avx.IsAvxSupported)
            {
                if (sizeof(T) == 4)
                {
					return Avx.mm256_movemask_ps(a) != 0;
                    
                }
				else
				{
					int mask = Avx.mm256_movemask_pd(a);

					return (elements == 3) ? ((mask & 0b0111) != 0) : (mask != 0);
				}
            }
			else throw new IllegalInstructionException();
		}
    }
}
